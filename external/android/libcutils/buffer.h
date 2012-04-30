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
 * Byte buffer utilities.
 */

#ifndef __BUFFER_H
#define __BUFFER_H

#ifdef __cplusplus
extern "C" {
#endif

#include <stdlib.h>

/** 
 * Byte buffer of known size. Keeps track of how much data has been read
 * into or written out of the buffer.
 */
typedef struct {
    /** Buffered data. */
    char* data;

    union {
        /** For reading. # of bytes we expect. */
        size_t expected;

        /** For writing. # of bytes to write. */
        size_t remaining;
    };

    /** Actual # of bytes in the buffer. */
    size_t size;

    /** Amount of memory allocated for this buffer. */
    size_t capacity;
} Buffer;

/**
 * Returns true if all data has been read into the buffer.
 */
#define bufferReadComplete(buffer) (buffer->expected == buffer->size)

/**
 * Returns true if the buffer has been completely written.
 */
#define bufferWriteComplete(buffer) (buffer->remaining == 0)

/**
 * Creates a new buffer with the given initial capacity.
 */
Buffer* bufferCreate(size_t initialCapacity);

/**
 * Wraps an existing byte array.
 */
Buffer* bufferWrap(char* data, size_t capacity, size_t size);

/**
 * Frees and its data.
 */
void bufferFree(Buffer* buffer);

/**
 * Prepares buffer to read 'expected' number of bytes. Expands capacity if
 * necessary. Returns 0 if successful or -1 if an error occurs allocating
 * memory.
 */
int bufferPrepareForRead(Buffer* buffer, size_t expected);

/**
 * Reads some data into a buffer. Returns -1 in case of an error and sets 
 * errno (see read()). Returns 0 for EOF. Updates buffer->size and returns
 * the new size after a succesful read. 
 *
 * Precondition: buffer->size < buffer->expected
 */
ssize_t bufferRead(Buffer* buffer, int fd);

/**
 * Prepares a buffer to be written out.
 */
void bufferPrepareForWrite(Buffer* buffer);

/**
 * Writes data from buffer to the given fd. Returns -1 and sets errno in case
 * of an error. Updates buffer->remaining and returns the number of remaining
 * bytes to be written after a successful write. 
 *
 * Precondition: buffer->remaining > 0
 */
ssize_t bufferWrite(Buffer* buffer, int fd);

#ifdef __cplusplus
}
#endif

#endif /* __BUFFER_H */ 
