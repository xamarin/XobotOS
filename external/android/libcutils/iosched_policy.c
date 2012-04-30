
/* libs/cutils/iosched_policy.c
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

#ifdef HAVE_SCHED_H

#include <cutils/iosched_policy.h>

extern int ioprio_set(int which, int who, int ioprio);

enum {
    WHO_PROCESS = 1,
    WHO_PGRP,
    WHO_USER,
};

#define CLASS_SHIFT 13
#define IOPRIO_NORM 4

int android_set_ioprio(int pid, IoSchedClass clazz, int ioprio) {
#ifdef HAVE_ANDROID_OS
    if (ioprio_set(WHO_PROCESS, pid, ioprio | (clazz << CLASS_SHIFT))) {
        return -1;
    }
#endif
    return 0;
}

int android_get_ioprio(int pid, IoSchedClass *clazz, int *ioprio) {
#ifdef HAVE_ANDROID_OS
    int rc;

    if ((rc = ioprio_get(WHO_PROCESS, pid)) < 0) {
        return -1;
    }

    *clazz = (rc >> CLASS_SHIFT);
    *ioprio = (rc & 0xff);
#else
    *clazz = IoSchedClass_NONE;
    *ioprio = 0;
#endif
    return 0;
}

#endif /* HAVE_SCHED_H */
