
/* libs/cutils/sched_policy.c
**
** Copyright 2007, The Android Open Source Project
**
** Licensed under the Apache License, Version 2.0 (the "License"); 
** you may not use this file except in compliance with the License. 
** You may obtain a copy of the License at 
**
**     http://www.apache.org/licenses/LICENSE-2.0 
**
** Unless required by applicable law or agreed to in writing, software 
** distributed under the License is distributed on an "AS IS" BASIS, 
** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
** See the License for the specific language governing permissions and 
** limitations under the License.
*/

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <errno.h>
#include <fcntl.h>

#define LOG_TAG "SchedPolicy"
#include "cutils/log.h"

#ifdef HAVE_SCHED_H
#ifdef HAVE_PTHREADS

#include <sched.h>
#include <pthread.h>

#include <cutils/sched_policy.h>

#ifndef SCHED_NORMAL
  #define SCHED_NORMAL 0
#endif

#ifndef SCHED_BATCH
  #define SCHED_BATCH 3
#endif

#define POLICY_DEBUG 0

static pthread_once_t the_once = PTHREAD_ONCE_INIT;

static int __sys_supports_schedgroups = -1;

// File descriptors open to /dev/cpuctl/../tasks, setup by initialize, or -1 on error.
static int normal_cgroup_fd = -1;
static int bg_cgroup_fd = -1;

/* Add tid to the scheduling group defined by the policy */
static int add_tid_to_cgroup(int tid, SchedPolicy policy)
{
    int fd;

    if (policy == SP_BACKGROUND) {
        fd = bg_cgroup_fd;
    } else {
        fd = normal_cgroup_fd;
    }

    if (fd < 0) {
        SLOGE("add_tid_to_cgroup failed; background=%d\n",
              policy == SP_BACKGROUND ? 1 : 0);
        return -1;
    }

    // specialized itoa -- works for tid > 0
    char text[22];
    char *end = text + sizeof(text) - 1;
    char *ptr = end;
    *ptr = '\0';
    while (tid > 0) {
        *--ptr = '0' + (tid % 10);
        tid = tid / 10;
    }

    if (write(fd, ptr, end - ptr) < 0) {
        /*
         * If the thread is in the process of exiting,
         * don't flag an error
         */
        if (errno == ESRCH)
                return 0;
        SLOGW("add_tid_to_cgroup failed to write '%s' (%s); background=%d\n",
              ptr, strerror(errno), policy == SP_BACKGROUND ? 1 : 0);
        return -1;
    }

    return 0;
}

static void __initialize(void) {
    char* filename;
    if (!access("/dev/cpuctl/tasks", F_OK)) {
        __sys_supports_schedgroups = 1;

        filename = "/dev/cpuctl/tasks";
        normal_cgroup_fd = open(filename, O_WRONLY);
        if (normal_cgroup_fd < 0) {
            SLOGE("open of %s failed: %s\n", filename, strerror(errno));
        }

        filename = "/dev/cpuctl/bg_non_interactive/tasks";
        bg_cgroup_fd = open(filename, O_WRONLY);
        if (bg_cgroup_fd < 0) {
            SLOGE("open of %s failed: %s\n", filename, strerror(errno));
        }
    } else {
        __sys_supports_schedgroups = 0;
    }
}

/*
 * Try to get the scheduler group.
 *
 * The data from /proc/<pid>/cgroup looks (something) like:
 *  2:cpu:/bg_non_interactive
 *  1:cpuacct:/
 *
 * We return the part after the "/", which will be an empty string for
 * the default cgroup.  If the string is longer than "bufLen", the string
 * will be truncated.
 */
static int getSchedulerGroup(int tid, char* buf, size_t bufLen)
{
#ifdef HAVE_ANDROID_OS
    char pathBuf[32];
    char lineBuf[256];
    FILE *fp;

    snprintf(pathBuf, sizeof(pathBuf), "/proc/%d/cgroup", tid);
    if (!(fp = fopen(pathBuf, "r"))) {
        return -1;
    }

    while(fgets(lineBuf, sizeof(lineBuf) -1, fp)) {
        char *next = lineBuf;
        char *subsys;
        char *grp;
        size_t len;

        /* Junk the first field */
        if (!strsep(&next, ":")) {
            goto out_bad_data;
        }

        if (!(subsys = strsep(&next, ":"))) {
            goto out_bad_data;
        }

        if (strcmp(subsys, "cpu")) {
            /* Not the subsys we're looking for */
            continue;
        }

        if (!(grp = strsep(&next, ":"))) {
            goto out_bad_data;
        }
        grp++; /* Drop the leading '/' */
        len = strlen(grp);
        grp[len-1] = '\0'; /* Drop the trailing '\n' */

        if (bufLen <= len) {
            len = bufLen - 1;
        }
        strncpy(buf, grp, len);
        buf[len] = '\0';
        fclose(fp);
        return 0;
    }

    SLOGE("Failed to find cpu subsys");
    fclose(fp);
    return -1;
 out_bad_data:
    SLOGE("Bad cgroup data {%s}", lineBuf);
    fclose(fp);
    return -1;
#else
    errno = ENOSYS;
    return -1;
#endif
}

int get_sched_policy(int tid, SchedPolicy *policy)
{
    pthread_once(&the_once, __initialize);

    if (__sys_supports_schedgroups) {
        char grpBuf[32];
        if (getSchedulerGroup(tid, grpBuf, sizeof(grpBuf)) < 0)
            return -1;
        if (grpBuf[0] == '\0') {
            *policy = SP_FOREGROUND;
        } else if (!strcmp(grpBuf, "bg_non_interactive")) {
            *policy = SP_BACKGROUND;
        } else {
            errno = ERANGE;
            return -1;
        }
    } else {
        int rc = sched_getscheduler(tid);
        if (rc < 0)
            return -1;
        else if (rc == SCHED_NORMAL)
            *policy = SP_FOREGROUND;
        else if (rc == SCHED_BATCH)
            *policy = SP_BACKGROUND;
        else {
            errno = ERANGE;
            return -1;
        }
    }
    return 0;
}

int set_sched_policy(int tid, SchedPolicy policy)
{
    pthread_once(&the_once, __initialize);

#if POLICY_DEBUG
    char statfile[64];
    char statline[1024];
    char thread_name[255];
    int fd;

    sprintf(statfile, "/proc/%d/stat", tid);
    memset(thread_name, 0, sizeof(thread_name));

    fd = open(statfile, O_RDONLY);
    if (fd >= 0) {
        int rc = read(fd, statline, 1023);
        close(fd);
        statline[rc] = 0;
        char *p = statline;
        char *q;

        for (p = statline; *p != '('; p++);
        p++;
        for (q = p; *q != ')'; q++);

        strncpy(thread_name, p, (q-p));
    }
    if (policy == SP_BACKGROUND) {
        SLOGD("vvv tid %d (%s)", tid, thread_name);
    } else if (policy == SP_FOREGROUND) {
        SLOGD("^^^ tid %d (%s)", tid, thread_name);
    } else {
        SLOGD("??? tid %d (%s)", tid, thread_name);
    }
#endif

    if (__sys_supports_schedgroups) {
        if (add_tid_to_cgroup(tid, policy)) {
            if (errno != ESRCH && errno != ENOENT)
                return -errno;
        }
    } else {
        struct sched_param param;

        param.sched_priority = 0;
        sched_setscheduler(tid,
                           (policy == SP_BACKGROUND) ?
                            SCHED_BATCH : SCHED_NORMAL,
                           &param);
    }

    return 0;
}

#endif /* HAVE_PTHREADS */
#endif /* HAVE_SCHED_H */
