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

#define LOG_TAG "buffer"

#include <assert.h>
#include <errno.h>
#include <stdlib.h>
#include <unistd.h>

#include "buffer.h"
#include "loghack.h"

Buffer* bufferCreate(size_t capacity) {
    Buffer* buffer = malloc(sizeof(Buffer));
    if (buffer == NULL) {
        return NULL;
    }
    buffer->capacity = capacity;
    buffer->expected = 0;
    buffer->data = malloc(capacity);
    if (buffer->data == NULL) {
        free(buffer);
        return NULL;
    }
    return buffer;
}

void bufferFree(Buffer* buffer) {
    free(buffer->data);
    free(buffer);
}

Buffer* bufferWrap(char* data, size_t capacity, size_t size) {
    Buffer* buffer = malloc(sizeof(Buffer));
    if (buffer == NULL) {
        return NULL;
    }

    buffer->data = data;
    buffer->capacity = capacity;
    buffer->size = size;
    buffer->expected = 0;
    return buffer;
}

int bufferPrepareForRead(Buffer* buffer, size_t expected) {
    if (expected > buffer->capacity) {
        // Expand buffer.
        char* expanded = realloc(buffer->data, expected);
        if (expanded == NULL) {
            errno = ENOMEM;
            return -1;
        }
        buffer->capacity = expected;
        buffer->data = expanded;
    }

    buffer->size = 0;
    buffer->expected = expected;
    return 0;
}

ssize_t bufferRead(Buffer* buffer, int fd) {
    assert(buffer->size < buffer->expected);
    
    ssize_t bytesRead = read(fd, 
            buffer->data + buffer->size, 
            buffer->expected - buffer->size);

    if (bytesRead > 0) {
        buffer->size += bytesRead;
        return buffer->size;        
    }

    return bytesRead;
}

void bufferPrepareForWrite(Buffer* buffer) {
    buffer->remaining = buffer->size;
}

ssize_t bufferWrite(Buffer* buffer, int fd) {
    assert(buffer->remaining > 0);
    assert(buffer->remaining <= buffer->size);

    ssize_t bytesWritten = write(fd, 
            buffer->data + buffer->size - buffer->remaining,
            buffer->remaining);

    if (bytesWritten >= 0) {
        buffer->remaining -= bytesWritten;

        LOGD("Buffer bytes written: %d", (int) bytesWritten);
        LOGD("Buffer size: %d", (int) buffer->size);
        LOGD("Buffer remaining: %d", (int) buffer->remaining);        

        return buffer->remaining;
    }

    return bytesWritten;
}

