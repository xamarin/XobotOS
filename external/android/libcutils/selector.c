/*
 * Copyright (C) 2007 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#define LOG_TAG "selector"

#include <assert.h>
#include <errno.h>
#include <pthread.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <unistd.h>

#include <cutils/array.h>
#include <cutils/selector.h>

#include "loghack.h"

struct Selector {
    Array* selectableFds;
    bool looping;
    fd_set readFds;
    fd_set writeFds;
    fd_set exceptFds;
    int maxFd;
    int wakeupPipe[2];
    SelectableFd* wakeupFd;

    bool inSelect;
    pthread_mutex_t inSelectLock; 
};

/** Reads and ignores wake up data. */ 
static void eatWakeupData(SelectableFd* wakeupFd) {
    static char garbage[64];
    if (read(wakeupFd->fd, garbage, sizeof(garbage)) < 0) {
        if (errno == EINTR) {
            LOGI("read() interrupted.");    
        } else {
            LOG_ALWAYS_FATAL("This should never happen: %s", strerror(errno));
        }
    }
}

static void setInSelect(Selector* selector, bool inSelect) {
    pthread_mutex_lock(&selector->inSelectLock);
    selector->inSelect = inSelect;
    pthread_mutex_unlock(&selector->inSelectLock);
}

static bool isInSelect(Selector* selector) {
    pthread_mutex_lock(&selector->inSelectLock);
    bool inSelect = selector->inSelect;
    pthread_mutex_unlock(&selector->inSelectLock);
    return inSelect;
}

void selectorWakeUp(Selector* selector) {
    if (!isInSelect(selector)) {
        // We only need to write wake-up data if we're blocked in select().
        return;
    }
    
    static char garbage[1];
    if (write(selector->wakeupPipe[1], garbage, sizeof(garbage)) < 0) {
        if (errno == EINTR) {
            LOGI("read() interrupted.");    
        } else {
            LOG_ALWAYS_FATAL("This should never happen: %s", strerror(errno));
        }
    }
}

Selector* selectorCreate(void) {
    Selector* selector = calloc(1, sizeof(Selector));
    if (selector == NULL) {
        LOG_ALWAYS_FATAL("malloc() error.");
    }
    selector->selectableFds = arrayCreate();
    
    // Set up wake-up pipe.
    if (pipe(selector->wakeupPipe) < 0) {
        LOG_ALWAYS_FATAL("pipe() error: %s", strerror(errno));
    }
    
    LOGD("Wakeup fd: %d", selector->wakeupPipe[0]);
    
    SelectableFd* wakeupFd = selectorAdd(selector, selector->wakeupPipe[0]);
    if (wakeupFd == NULL) {
        LOG_ALWAYS_FATAL("malloc() error.");
    }
    wakeupFd->onReadable = &eatWakeupData; 
    
    pthread_mutex_init(&selector->inSelectLock, NULL);

    return selector;
}

SelectableFd* selectorAdd(Selector* selector, int fd) {
    assert(selector != NULL);

    SelectableFd* selectableFd = calloc(1, sizeof(SelectableFd));
    if (selectableFd != NULL) {
        selectableFd->selector = selector;
        selectableFd->fd = fd;
    
        arrayAdd(selector->selectableFds, selectableFd);
    }

    return selectableFd;
}

/**
 * Adds an fd to the given set if the callback is non-null. Returns true
 * if the fd was added.
 */
static inline bool maybeAdd(SelectableFd* selectableFd,
        void (*callback)(SelectableFd*), fd_set* fdSet) {
    if (callback != NULL) {
        FD_SET(selectableFd->fd, fdSet);
        return true;
    }
    return false;
}

/**
 * Removes stale file descriptors and initializes file descriptor sets.
 */
static void prepareForSelect(Selector* selector) {
    fd_set* exceptFds = &selector->exceptFds;
    fd_set* readFds = &selector->readFds;
    fd_set* writeFds = &selector->writeFds;
    
    FD_ZERO(exceptFds);
    FD_ZERO(readFds);
    FD_ZERO(writeFds);

    Array* selectableFds = selector->selectableFds;
    int i = 0;
    selector->maxFd = 0;
    int size = arraySize(selectableFds);
    while (i < size) {
        SelectableFd* selectableFd = arrayGet(selectableFds, i);
        if (selectableFd->remove) {
            // This descriptor should be removed.
            arrayRemove(selectableFds, i);
            size--;
            if (selectableFd->onRemove != NULL) {
                selectableFd->onRemove(selectableFd);
            }
            free(selectableFd);
        } else {
            if (selectableFd->beforeSelect != NULL) {
                selectableFd->beforeSelect(selectableFd);
            }
            
            bool inSet = false;
            if (maybeAdd(selectableFd, selectableFd->onExcept, exceptFds)) {
            	LOGD("Selecting fd %d for writing...", selectableFd->fd);
                inSet = true;
            }
            if (maybeAdd(selectableFd, selectableFd->onReadable, readFds)) {
            	LOGD("Selecting fd %d for reading...", selectableFd->fd);
                inSet = true;
            }
            if (maybeAdd(selectableFd, selectableFd->onWritable, writeFds)) {
                inSet = true;
            }

            if (inSet) {
                // If the fd is in a set, check it against max.
                int fd = selectableFd->fd;
                if (fd > selector->maxFd) {
                    selector->maxFd = fd;
                }
            }
            
            // Move to next descriptor.
            i++;
        }
    }
}

/**
 * Invokes a callback if the callback is non-null and the fd is in the given
 * set.
 */
static inline void maybeInvoke(SelectableFd* selectableFd,
        void (*callback)(SelectableFd*), fd_set* fdSet) {
	if (callback != NULL && !selectableFd->remove && 
            FD_ISSET(selectableFd->fd, fdSet)) {
		LOGD("Selected fd %d.", selectableFd->fd);
        callback(selectableFd);
    }
}

/**
 * Notifies user if file descriptors are readable or writable, or if
 * out-of-band data is present.
 */
static void fireEvents(Selector* selector) {
    Array* selectableFds = selector->selectableFds;
    int size = arraySize(selectableFds);
    int i;
    for (i = 0; i < size; i++) {
        SelectableFd* selectableFd = arrayGet(selectableFds, i);
        maybeInvoke(selectableFd, selectableFd->onExcept,
                &selector->exceptFds);
        maybeInvoke(selectableFd, selectableFd->onReadable,
                &selector->readFds);
        maybeInvoke(selectableFd, selectableFd->onWritable,
                &selector->writeFds);
    }
}

void selectorLoop(Selector* selector) {
    // Make sure we're not already looping.
    if (selector->looping) {
        LOG_ALWAYS_FATAL("Already looping.");
    }
    selector->looping = true;
    
    while (true) {
        setInSelect(selector, true);
        
        prepareForSelect(selector);

        LOGD("Entering select().");
        
        // Select file descriptors.
        int result = select(selector->maxFd + 1, &selector->readFds, 
                &selector->writeFds, &selector->exceptFds, NULL);
        
        LOGD("Exiting select().");
        
        setInSelect(selector, false);
        
        if (result == -1) {
            // Abort on everything except EINTR.
            if (errno == EINTR) {
                LOGI("select() interrupted.");    
            } else {
                LOG_ALWAYS_FATAL("select() error: %s", 
                        strerror(errno));
            }
        } else if (result > 0) {
            fireEvents(selector);
        }
    }
}
