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

#include <dirent.h>
#include <errno.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sha1.h>
#include <unistd.h>
#include <limits.h>

#include <sys/stat.h>

#include <netinet/in.h>
#include <resolv.h>

#include <cutils/dir_hash.h>

/**
 * Copies, if it fits within max_output_string bytes, into output_string
 * a hash of the contents, size, permissions, uid, and gid of the file
 * specified by path, using the specified algorithm.  Returns the length
 * of the output string, or a negative number if the buffer is too short.
 */
int get_file_hash(HashAlgorithm algorithm, const char *path,
                  char *output_string, size_t max_output_string) {
    SHA1_CTX context;
    struct stat sb;
    unsigned char md[SHA1_DIGEST_LENGTH];
    int used;
    size_t n;

    if (algorithm != SHA_1) {
        errno = EINVAL;
        return -1;
    }

    if (stat(path, &sb) != 0) {
        return -1;
    }

    if (S_ISLNK(sb.st_mode)) {
        char buf[PATH_MAX];
        int len;

        len = readlink(path, buf, sizeof(buf));
        if (len < 0) {
            return -1;
        }

        SHA1Init(&context);
        SHA1Update(&context, (unsigned char *) buf, len);
        SHA1Final(md, &context);
    } else if (S_ISREG(sb.st_mode)) {
        char buf[10000];
        FILE *f = fopen(path, "rb");
        int len;

        if (f == NULL) {
            return -1;
        }

        SHA1Init(&context);

        while ((len = fread(buf, 1, sizeof(buf), f)) > 0) {
            SHA1Update(&context, (unsigned char *) buf, len);
        }

        if (ferror(f)) {
            fclose(f);
            return -1;
        }

        fclose(f);
        SHA1Final(md, &context);
    }

    if (S_ISLNK(sb.st_mode) || S_ISREG(sb.st_mode)) {
        used = b64_ntop(md, SHA1_DIGEST_LENGTH,
                        output_string, max_output_string);
        if (used < 0) {
            errno = ENOSPC;
            return -1;
        }

        n = snprintf(output_string + used, max_output_string - used,
                     " %d 0%o %d %d", (int) sb.st_size, sb.st_mode,
                     (int) sb.st_uid, (int) sb.st_gid);
    } else {
        n = snprintf(output_string, max_output_string,
                     "- - 0%o %d %d", sb.st_mode,
                     (int) sb.st_uid, (int) sb.st_gid);
    }

    if (n >= max_output_string - used) {
        errno = ENOSPC;
        return -(used + n);
    }

    return used + n;
}

struct list {
    char *name;
    struct list *next;
};

static int cmp(const void *a, const void *b) {
    struct list *const *ra = a;
    struct list *const *rb = b;

    return strcmp((*ra)->name, (*rb)->name);
}

static int recurse(HashAlgorithm algorithm, const char *directory_path,
                    struct list **out) {
    struct list *list = NULL;
    struct list *f;

    struct dirent *de;
    DIR *d = opendir(directory_path);

    if (d == NULL) {
        return -1;
    }

    while ((de = readdir(d)) != NULL) {
        if (strcmp(de->d_name, ".") == 0) {
            continue;
        }
        if (strcmp(de->d_name, "..") == 0) {
            continue;
        }

        char *name = malloc(strlen(de->d_name) + 1);
        struct list *node = malloc(sizeof(struct list));

        if (name == NULL || node == NULL) {
            struct list *next;
            for (f = list; f != NULL; f = next) {
                next = f->next;
                free(f->name);
                free(f);
            }

            free(name);
            free(node);
            return -1;
        }

        strcpy(name, de->d_name);

        node->name = name;
        node->next = list;
        list = node;
    }

    closedir(d);

    for (f = list; f != NULL; f = f->next) {
        struct stat sb;
        char *name;
        char outstr[NAME_MAX + 100];
        char *keep;
        struct list *res;

        name = malloc(strlen(f->name) + strlen(directory_path) + 2);
        if (name == NULL) {
            struct list *next;
            for (f = list; f != NULL; f = f->next) {
                next = f->next;
                free(f->name);
                free(f);
            }
            for (f = *out; f != NULL; f = f->next) {
                next = f->next;
                free(f->name);
                free(f);
            }
            *out = NULL;
            return -1;
        }

        sprintf(name, "%s/%s", directory_path, f->name);

        int len = get_file_hash(algorithm, name,
                                outstr, sizeof(outstr));
        if (len < 0) {
            // should not happen
            return -1;
        }

        keep = malloc(len + strlen(name) + 3);
        res = malloc(sizeof(struct list));

        if (keep == NULL || res == NULL) {
            struct list *next;
            for (f = list; f != NULL; f = f->next) {
                next = f->next;
                free(f->name);
                free(f);
            }
            for (f = *out; f != NULL; f = f->next) {
                next = f->next;
                free(f->name);
                free(f);
            }
            *out = NULL;

            free(keep);
            free(res);
            return -1;
        }

        sprintf(keep, "%s %s\n", name, outstr);

        res->name = keep;
        res->next = *out;
        *out = res;

        if ((stat(name, &sb) == 0) && S_ISDIR(sb.st_mode)) {
            if (recurse(algorithm, name, out) < 0) {
                struct list *next;
                for (f = list; f != NULL; f = next) {
                    next = f->next;
                    free(f->name);
                    free(f);
                }

                return -1;
            }
        }
    }

    struct list *next;
    for (f = list; f != NULL; f = next) {
        next = f->next;

        free(f->name);
        free(f);
    }
}

/**
 * Allocates a string containing the names and hashes of all files recursively
 * reached under the specified directory_path, using the specified algorithm.
 * The string is returned as *output_string; the return value is the length
 * of the string, or a negative number if there was a failure.
 */
int get_recursive_hash_manifest(HashAlgorithm algorithm,
                                const char *directory_path,
                                char **output_string) {
    struct list *out = NULL;
    struct list *r;
    struct list **list;
    int count = 0;
    int len = 0;
    int retlen = 0;
    int i;
    char *buf;
    
    if (recurse(algorithm, directory_path, &out) < 0) {
        return -1;
    }

    for (r = out; r != NULL; r = r->next) {
        count++;
        len += strlen(r->name);
    }

    list = malloc(count * sizeof(struct list *));
    if (list == NULL) {
        struct list *next;
        for (r = out; r != NULL; r = next) {
            next = r->next;
            free(r->name);
            free(r);
        }
        return -1;
    }

    count = 0;
    for (r = out; r != NULL; r = r->next) {
        list[count++] = r;
    }

    qsort(list, count, sizeof(struct list *), cmp);

    buf = malloc(len + 1);
    if (buf == NULL) {
        struct list *next;
        for (r = out; r != NULL; r = next) {
            next = r->next;
            free(r->name);
            free(r);
        }
        free(list);
        return -1;
    }

    for (i = 0; i < count; i++) {
        int n = strlen(list[i]->name);

        strcpy(buf + retlen, list[i]->name);
        retlen += n;
    }

    free(list);

    struct list *next;
    for (r = out; r != NULL; r = next) {
        next = r->next;

        free(r->name);
        free(r);
    }

    *output_string = buf;
    return retlen;
}
