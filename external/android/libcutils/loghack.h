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

/**
 * This is a temporary hack to enable logging from cutils.
 */

#ifndef _CUTILS_LOGHACK_H
#define _CUTILS_LOGHACK_H

#ifdef HAVE_ANDROID_OS
#include <cutils/log.h>
#else
#include <stdio.h>
#define LOG(level, ...) \
        ((void)printf("cutils:" level "/" LOG_TAG ": " __VA_ARGS__))
#define LOGV(...)   LOG("V", __VA_ARGS__)
#define LOGD(...)   LOG("D", __VA_ARGS__)
#define LOGI(...)   LOG("I", __VA_ARGS__)
#define LOGW(...)   LOG("W", __VA_ARGS__)
#define LOGE(...)   LOG("E", __VA_ARGS__)
#define LOG_ALWAYS_FATAL(...)   do { LOGE(__VA_ARGS__); exit(1); } while (0)
#endif

#endif // _CUTILS_LOGHACK_H
