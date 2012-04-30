/*
 * Copyright 2009, The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#include <stdlib.h>
#include <errno.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/socket.h>
#include <sys/poll.h>

#include "cutils/abort_socket.h"

struct asocket *asocket_init(int fd) {
    int abort_fd[2];
    int flags;
    struct asocket *s;

    /* set primary socket to non-blocking */
    flags = fcntl(fd, F_GETFL);
    if (flags == -1)
        return NULL;
    if (fcntl(fd, F_SETFL, flags | O_NONBLOCK))
        return NULL;

    /* create pipe with non-blocking write, so that asocket_close() cannot
       block */
    if (pipe(abort_fd))
        return NULL;
    flags = fcntl(abort_fd[1], F_GETFL);
    if (flags == -1)
        return NULL;
    if (fcntl(abort_fd[1], F_SETFL, flags | O_NONBLOCK))
        return NULL;

    s = malloc(sizeof(struct asocket));
    if (!s)
        return NULL;

    s->fd = fd;
    s->abort_fd[0] = abort_fd[0];
    s->abort_fd[1] = abort_fd[1];

    return s;
}

int asocket_connect(struct asocket *s, const struct sockaddr *addr,
        socklen_t addrlen, int timeout) {

    int ret;

    do {
        ret = connect(s->fd, addr, addrlen);
    } while (ret && errno == EINTR);

    if (ret && errno == EINPROGRESS) {
        /* ready to poll() */
        socklen_t retlen;
        struct pollfd pfd[2];

        pfd[0].fd = s->fd;
        pfd[0].events = POLLOUT;
        pfd[0].revents = 0;
        pfd[1].fd = s->abort_fd[0];
        pfd[1].events = POLLIN;
        pfd[1].revents = 0;

        do {
            ret = poll(pfd, 2, timeout);
        } while (ret < 0 && errno == EINTR);

        if (ret < 0)
            return -1;
        else if (ret == 0) {
            /* timeout */
            errno = ETIMEDOUT;
            return -1;
        }

        if (pfd[1].revents) {
            /* abort due to asocket_abort() */
            errno = ECANCELED;
            return -1;
        }

        if (pfd[0].revents) {
            if (pfd[0].revents & POLLOUT) {
                /* connect call complete, read return code */
                retlen = sizeof(ret);
                if (getsockopt(s->fd, SOL_SOCKET, SO_ERROR, &ret, &retlen))
                    return -1;
                /* got connect() return code */
                if (ret) {
                    errno = ret;
                }
            } else {
                /* some error event on this fd */
                errno = ECONNABORTED;
                return -1;
            }
        }
    }

    return ret;
}

int asocket_accept(struct asocket *s, struct sockaddr *addr,
        socklen_t *addrlen, int timeout) {

    int ret;
    struct pollfd pfd[2];

    pfd[0].fd = s->fd;
    pfd[0].events = POLLIN;
    pfd[0].revents = 0;
    pfd[1].fd = s->abort_fd[0];
    pfd[1].events = POLLIN;
    pfd[1].revents = 0;

    do {
        ret = poll(pfd, 2, timeout);
    } while (ret < 0 && errno == EINTR);

    if (ret < 0)
        return -1;
    else if (ret == 0) {
        /* timeout */
        errno = ETIMEDOUT;
        return -1;
    }

    if (pfd[1].revents) {
        /* abort due to asocket_abort() */
        errno = ECANCELED;
        return -1;
    }

    if (pfd[0].revents) {
        if (pfd[0].revents & POLLIN) {
            /* ready to accept() without blocking */
            do {
                ret = accept(s->fd, addr, addrlen);
            } while (ret < 0 && errno == EINTR);
        } else {
            /* some error event on this fd */
            errno = ECONNABORTED;
            return -1;
        }
    }

    return ret;
}

int asocket_read(struct asocket *s, void *buf, size_t count, int timeout) {
    int ret;
    struct pollfd pfd[2];

    pfd[0].fd = s->fd;
    pfd[0].events = POLLIN;
    pfd[0].revents = 0;
    pfd[1].fd = s->abort_fd[0];
    pfd[1].events = POLLIN;
    pfd[1].revents = 0;

    do {
        ret = poll(pfd, 2, timeout);
    } while (ret < 0 && errno == EINTR);

    if (ret < 0)
        return -1;
    else if (ret == 0) {
        /* timeout */
        errno = ETIMEDOUT;
        return -1;
    }

    if (pfd[1].revents) {
        /* abort due to asocket_abort() */
        errno = ECANCELED;
        return -1;
    }

    if (pfd[0].revents) {
        if (pfd[0].revents & POLLIN) {
            /* ready to read() without blocking */
            do {
                ret = read(s->fd, buf, count);
            } while (ret < 0 && errno == EINTR);
        } else {
            /* some error event on this fd */
            errno = ECONNABORTED;
            return -1;
        }
    }

    return ret;
}

int asocket_write(struct asocket *s, const void *buf, size_t count,
        int timeout) {
    int ret;
    struct pollfd pfd[2];

    pfd[0].fd = s->fd;
    pfd[0].events = POLLOUT;
    pfd[0].revents = 0;
    pfd[1].fd = s->abort_fd[0];
    pfd[1].events = POLLIN;
    pfd[1].revents = 0;

    do {
        ret = poll(pfd, 2, timeout);
    } while (ret < 0 && errno == EINTR);

    if (ret < 0)
        return -1;
    else if (ret == 0) {
        /* timeout */
        errno = ETIMEDOUT;
        return -1;
    }

    if (pfd[1].revents) {
        /* abort due to asocket_abort() */
        errno = ECANCELED;
        return -1;
    }

    if (pfd[0].revents) {
        if (pfd[0].revents & POLLOUT) {
            /* ready to write() without blocking */
            do {
                ret = write(s->fd, buf, count);
            } while (ret < 0 && errno == EINTR);
        } else {
            /* some error event on this fd */
            errno = ECONNABORTED;
            return -1;
        }
    }

    return ret;
}

void asocket_abort(struct asocket *s) {
    int ret;
    char buf = 0;

    /* Prevent further use of fd, without yet releasing the fd */
    shutdown(s->fd, SHUT_RDWR);

    /* wake up calls blocked at poll() */
    do {
        ret = write(s->abort_fd[1], &buf, 1);
    } while (ret < 0 && errno == EINTR);
}

void asocket_destroy(struct asocket *s) {
    struct asocket s_copy = *s;

    /* Clients should *not* be using these fd's after calling
       asocket_destroy(), but in case they do, set to -1 so they cannot use a
       stale fd */
    s->fd = -1;
    s->abort_fd[0] = -1;
    s->abort_fd[1] = -1;

    /* Call asocket_abort() in case there are still threads blocked on this
       socket. Clients should not rely on this behavior - it is racy because we
       are about to close() these sockets - clients should instead make sure
       all threads are done with the socket before calling asocket_destory().
     */
    asocket_abort(&s_copy);

    /* enough safety checks, close and release memory */
    close(s_copy.abort_fd[1]);
    close(s_copy.abort_fd[0]);
    close(s_copy.fd);

    free(s);
}
