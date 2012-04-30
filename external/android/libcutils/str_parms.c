/*
 * Copyright (C) 2011 The Android Open Source Project
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

#define LOG_TAG "str_params"
//#define LOG_NDEBUG 0

#define _GNU_SOURCE 1
#include <errno.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <cutils/hashmap.h>
#include <cutils/log.h>
#include <cutils/memory.h>

#include <cutils/str_parms.h>

struct str_parms {
    Hashmap *map;
};


static bool str_eq(void *key_a, void *key_b)
{
    return !strcmp((const char *)key_a, (const char *)key_b);
}

/* use djb hash unless we find it inadequate */
static int str_hash_fn(void *str)
{
    uint32_t hash = 5381;
    char *p;

    for (p = str; p && *p; p++)
        hash = ((hash << 5) + hash) + *p;
    return (int)hash;
}

struct str_parms *str_parms_create(void)
{
    struct str_parms *str_parms;

    str_parms = calloc(1, sizeof(struct str_parms));
    if (!str_parms)
        return NULL;

    str_parms->map = hashmapCreate(5, str_hash_fn, str_eq);
    if (!str_parms->map)
        goto err;

    return str_parms;

err:
    free(str_parms);
    return NULL;
}

static bool remove_pair(void *key, void *value, void *context)
{
    struct str_parms *str_parms = context;

    hashmapRemove(str_parms->map, key);
    free(key);
    free(value);
    return true;
}

void str_parms_destroy(struct str_parms *str_parms)
{
    hashmapForEach(str_parms->map, remove_pair, str_parms);
    hashmapFree(str_parms->map);
    free(str_parms);
}

struct str_parms *str_parms_create_str(const char *_string)
{
    struct str_parms *str_parms;
    char *str;
    char *kvpair;
    char *tmpstr;
    int items = 0;

    str_parms = str_parms_create();
    if (!str_parms)
        goto err_create_str_parms;

    str = strdup(_string);
    if (!str)
        goto err_strdup;

    LOGV("%s: source string == '%s'\n", __func__, _string);

    kvpair = strtok_r(str, ";", &tmpstr);
    while (kvpair && *kvpair) {
        char *eq = strchr(kvpair, '='); /* would love strchrnul */
        char *value;
        char *key;
        void *old_val;

        if (eq == kvpair)
            goto next_pair;

        if (eq) {
            key = strndup(kvpair, eq - kvpair);
            if (*(++eq))
                value = strdup(eq);
            else
                value = strdup("");
        } else {
            key = strdup(kvpair);
            value = strdup("");
        }

        /* if we replaced a value, free it */
        old_val = hashmapPut(str_parms->map, key, value);
        if (old_val)
            free(old_val);

        items++;
next_pair:
        kvpair = strtok_r(NULL, ";", &tmpstr);
    }

    if (!items)
        LOGV("%s: no items found in string\n", __func__);

    free(str);

    return str_parms;

err_strdup:
    str_parms_destroy(str_parms);
err_create_str_parms:
    return NULL;
}

void str_parms_del(struct str_parms *str_parms, const char *key)
{
    hashmapRemove(str_parms->map, (void *)key);
}

int str_parms_add_str(struct str_parms *str_parms, const char *key,
                      const char *value)
{
    void *old_val;
    char *tmp;

    tmp = strdup(value);
    old_val = hashmapPut(str_parms->map, (void *)key, tmp);

    if (old_val) {
        free(old_val);
    } else if (errno == ENOMEM) {
        free(tmp);
        return -ENOMEM;
    }
    return 0;
}

int str_parms_add_int(struct str_parms *str_parms, const char *key, int value)
{
    char val_str[12];
    int ret;

    ret = snprintf(val_str, sizeof(val_str), "%d", value);
    if (ret < 0)
        return -EINVAL;

    ret = str_parms_add_str(str_parms, key, val_str);
    return ret;
}

int str_parms_add_float(struct str_parms *str_parms, const char *key,
                        float value)
{
    char val_str[23];
    int ret;

    ret = snprintf(val_str, sizeof(val_str), "%.10f", value);
    if (ret < 0)
        return -EINVAL;

    ret = str_parms_add_str(str_parms, key, val_str);
    return ret;
}

int str_parms_get_str(struct str_parms *str_parms, const char *key, char *val,
                      int len)
{
    char *value;

    value = hashmapGet(str_parms->map, (void *)key);
    if (value)
        return strlcpy(val, value, len);

    return -ENOENT;
}

int str_parms_get_int(struct str_parms *str_parms, const char *key, int *val)
{
    char *value;
    char *end;

    value = hashmapGet(str_parms->map, (void *)key);
    if (!value)
        return -ENOENT;

    *val = (int)strtol(value, &end, 0);
    if (*value != '\0' && *end == '\0')
        return 0;

    return -EINVAL;
}

int str_parms_get_float(struct str_parms *str_parms, const char *key,
                        float *val)
{
    float out;
    char *value;
    char *end;

    value = hashmapGet(str_parms->map, (void *)key);
    if (!value)
        return -ENOENT;

    out = strtof(value, &end);
    if (*value != '\0' && *end == '\0')
        return 0;

    return -EINVAL;
}

static bool combine_strings(void *key, void *value, void *context)
{
    char **old_str = context;
    char *new_str;
    int ret;

    ret = asprintf(&new_str, "%s%s%s=%s",
                   *old_str ? *old_str : "",
                   *old_str ? ";" : "",
                   (char *)key,
                   (char *)value);
    if (*old_str)
        free(*old_str);

    if (ret >= 0) {
        *old_str = new_str;
        return true;
    }

    *old_str = NULL;
    return false;
}

char *str_parms_to_str(struct str_parms *str_parms)
{
    char *str = NULL;

    if (hashmapSize(str_parms->map) > 0)
        hashmapForEach(str_parms->map, combine_strings, &str);
    else
        str = strdup("");
    return str;
}

static bool dump_entry(void *key, void *value, void *context)
{
    LOGI("key: '%s' value: '%s'\n", (char *)key, (char *)value);
    return true;
}

void str_parms_dump(struct str_parms *str_parms)
{
    hashmapForEach(str_parms->map, dump_entry, str_parms);
}

#ifdef TEST_STR_PARMS
static void test_str_parms_str(const char *str)
{
    struct str_parms *str_parms;
    char *out_str;
    int ret;

    str_parms = str_parms_create_str(str);
    str_parms_dump(str_parms);
    out_str = str_parms_to_str(str_parms);
    str_parms_destroy(str_parms);
    LOGI("%s: '%s' stringified is '%s'", __func__, str, out_str);
    free(out_str);
}

int main(void)
{
    struct str_parms *str_parms;

    test_str_parms_str("");
    test_str_parms_str(";");
    test_str_parms_str("=");
    test_str_parms_str("=;");
    test_str_parms_str("=bar");
    test_str_parms_str("=bar;");
    test_str_parms_str("foo=");
    test_str_parms_str("foo=;");
    test_str_parms_str("foo=bar");
    test_str_parms_str("foo=bar;");
    test_str_parms_str("foo=bar;baz");
    test_str_parms_str("foo=bar;baz=");
    test_str_parms_str("foo=bar;baz=bat");
    test_str_parms_str("foo=bar;baz=bat;");

    return 0;
}
#endif
