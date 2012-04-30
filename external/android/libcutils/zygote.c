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

#define LOG_TAG "Zygote"

#include <cutils/sockets.h>
#include <cutils/zygote.h>
#include <cutils/log.h>

#include <stdio.h>
#include <string.h>
#include <errno.h>
#include <time.h>
#include <stdint.h>
#include <stdlib.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/types.h>
#include <sys/socket.h>

#define ZYGOTE_SOCKET "zygote"

#define ZYGOTE_RETRY_COUNT 1000
#define ZYGOTE_RETRY_MILLIS 500

static void replace_nl(char *str);

/*
 * If sendStdio is non-zero, the current process's stdio file descriptors
 * will be sent and inherited by the spawned process.
 */
static int send_request(int fd, int sendStdio, int argc, const char **argv)
{
#ifndef HAVE_ANDROID_OS
    // not supported on simulator targets
    //LOGE("zygote_* not supported on simulator targets");
    return -1;
#else /* HAVE_ANDROID_OS */
    uint32_t pid;
    int i;
    struct iovec ivs[2];
    struct msghdr msg;
    char argc_buffer[12];
    const char *newline_string = "\n";
    struct cmsghdr *cmsg;
    char msgbuf[CMSG_SPACE(sizeof(int) * 3)];
    int *cmsg_payload;
    ssize_t ret;

    memset(&msg, 0, sizeof(msg));
    memset(&ivs, 0, sizeof(ivs));

    // First line is arg count 
    snprintf(argc_buffer, sizeof(argc_buffer), "%d\n", argc);

    ivs[0].iov_base = argc_buffer;
    ivs[0].iov_len = strlen(argc_buffer);

    msg.msg_iov = ivs;
    msg.msg_iovlen = 1;

    if (sendStdio != 0) {
        // Pass the file descriptors with the first write
        msg.msg_control = msgbuf;
        msg.msg_controllen = sizeof msgbuf;

        cmsg = CMSG_FIRSTHDR(&msg);

        cmsg->cmsg_len = CMSG_LEN(3 * sizeof(int));
        cmsg->cmsg_level = SOL_SOCKET;
        cmsg->cmsg_type = SCM_RIGHTS;

        cmsg_payload = (int *)CMSG_DATA(cmsg);
        cmsg_payload[0] = STDIN_FILENO;
        cmsg_payload[1] = STDOUT_FILENO;
        cmsg_payload[2] = STDERR_FILENO;
    }

    do {
        ret = sendmsg(fd, &msg, MSG_NOSIGNAL);
    } while (ret < 0 && errno == EINTR);

    if (ret < 0) {
        return -1;
    }

    // Only send the fd's once
    msg.msg_control = NULL;
    msg.msg_controllen = 0;

    // replace any newlines with spaces and send the args
    for (i = 0; i < argc; i++) {
        char *tofree = NULL;
        const char *toprint;

        toprint = argv[i];

        if (strchr(toprint, '\n') != NULL) {
            tofree = strdup(toprint);
            toprint = tofree;
            replace_nl(tofree);
        }

        ivs[0].iov_base = (char *)toprint;
        ivs[0].iov_len = strlen(toprint);
        ivs[1].iov_base = (char *)newline_string;
        ivs[1].iov_len = 1;

        msg.msg_iovlen = 2;

        do {
            ret = sendmsg(fd, &msg, MSG_NOSIGNAL);
        } while (ret < 0 && errno == EINTR);

        if (tofree != NULL) {
            free(tofree);
        }

        if (ret < 0) {
            return -1;
        }
    }

    // Read the pid, as a 4-byte network-order integer

    ivs[0].iov_base = &pid;
    ivs[0].iov_len = sizeof(pid);
    msg.msg_iovlen = 1;

    do {
        do {
            ret = recvmsg(fd, &msg, MSG_NOSIGNAL | MSG_WAITALL);
        } while (ret < 0 && errno == EINTR);

        if (ret < 0) {
            return -1;
        }

        ivs[0].iov_len -= ret;
        ivs[0].iov_base += ret;
    } while (ivs[0].iov_len > 0);

    pid = ntohl(pid);

    return pid;
#endif /* HAVE_ANDROID_OS */
}

int zygote_run_wait(int argc, const char **argv, void (*post_run_func)(int))
{
    int fd;
    int pid;
    int err;
    const char *newargv[argc + 1];

    fd = socket_local_client(ZYGOTE_SOCKET, 
            ANDROID_SOCKET_NAMESPACE_RESERVED, AF_LOCAL);

    if (fd < 0) {
        return -1;
    }

    // The command socket is passed to the peer as close-on-exec
    // and will close when the peer dies
    newargv[0] = "--peer-wait";
    memcpy(newargv + 1, argv, argc * sizeof(*argv)); 

    pid = send_request(fd, 1, argc + 1, newargv);

    if (pid > 0 && post_run_func != NULL) {
        post_run_func(pid);
    }

    // Wait for socket to close
    do {
        int dummy;
        err = read(fd, &dummy, sizeof(dummy));
    } while ((err < 0 && errno == EINTR) || err != 0);

    do {
        err = close(fd);
    } while (err < 0 && errno == EINTR);

    return 0;
}

/**
 * Spawns a new dalvik instance via the Zygote process. The non-zygote
 * arguments are passed to com.android.internal.os.RuntimeInit(). The
 * first non-option argument should be a class name in the system class path.
 *
 * The arg list  may start with zygote params such as --set-uid.
 *
 * If sendStdio is non-zero, the current process's stdio file descriptors
 * will be sent and inherited by the spawned process.
 *
 * The pid of the child process is returned, or -1 if an error was 
 * encountered.
 *
 * zygote_run_oneshot waits up to ZYGOTE_RETRY_COUNT * 
 * ZYGOTE_RETRY_MILLIS for the zygote socket to be available.
 */
int zygote_run_oneshot(int sendStdio, int argc, const char **argv) 
{
    int fd = -1;
    int err;
    int i;
    int retries;
    int pid;
    const char **newargv = argv;
    const int newargc = argc;

    for (retries = 0; (fd < 0) && (retries < ZYGOTE_RETRY_COUNT); retries++) {
        if (retries > 0) { 
            struct timespec ts;

            memset(&ts, 0, sizeof(ts));
            ts.tv_nsec = ZYGOTE_RETRY_MILLIS * 1000 * 1000;

            do {
                err = nanosleep (&ts, &ts);
            } while (err < 0 && errno == EINTR);
        }
        fd = socket_local_client(ZYGOTE_SOCKET, AF_LOCAL, 
                ANDROID_SOCKET_NAMESPACE_RESERVED);
    }

    if (fd < 0) {
        return -1;
    }

    pid = send_request(fd, 0, newargc, newargv);

    do {
        err = close(fd);
    } while (err < 0 && errno == EINTR);

    return pid;
}

/**
 * Replaces all occurrances of newline with space.
 */
static void replace_nl(char *str)
{
    for(; *str; str++) {
        if (*str == '\n') {
            *str = ' ';
        }
    }
}



