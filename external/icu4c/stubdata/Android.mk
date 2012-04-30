# Copyright (C) 2008 The Android Open Source Project
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

#
# Common definitions for all variants.
#

LOCAL_PATH:= $(call my-dir)

include $(CLEAR_VARS)

# Build configuration:
#
# 'all' includes all ICU's locale data, but is currently missing some Android
# extensions (mostly extra charset converters).
#
# 'default' (icudt46l-default.txt) includes all the most-used locales,
#   covering 94% of internet users
#   (http://googleblog.blogspot.com/2008/07/hitting-40-languages.html):
#   ar, bg, ca, cs, da, de, el, en, es, fa, fi, fil, fr, he, hi, hr, hu, in,
#   it, ja, ko, lt, lv, nb, nl, pl, ps, pt, rm, ro, ru, sk, sl, sr, sv, th,
#   tr, uk, vi, zh.
config := default

include $(LOCAL_PATH)/root.mk

LOCAL_MODULE := icu.dat
LOCAL_MODULE_TAGS := optional
LOCAL_MODULE_CLASS := ETC
LOCAL_MODULE_PATH := $(TARGET_OUT)/usr/icu
LOCAL_MODULE_STEM := $(root).dat
LOCAL_SRC_FILES := $(root)-$(config).dat
include $(BUILD_PREBUILT)

ifeq ($(WITH_HOST_DALVIK),true)
    $(eval $(call copy-one-file,$(LOCAL_PATH)/$(root)-$(config).dat,$(HOST_OUT)/usr/icu/$(root).dat))
endif
