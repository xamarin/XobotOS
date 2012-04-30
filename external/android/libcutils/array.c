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

#include <cutils/array.h>
#include <assert.h>
#include <stdlib.h>
#include <string.h>
#include <limits.h>

#define INITIAL_CAPACITY (4)
#define MAX_CAPACITY     ((int)(UINT_MAX/sizeof(void*)))

struct Array {
    void** contents;
    int size;
    int capacity;
};

Array* arrayCreate() {
    return calloc(1, sizeof(struct Array));
}

void arrayFree(Array* array) {
    assert(array != NULL);

    // Free internal array.
    free(array->contents);

    // Free the Array itself.
    free(array);
}

/** Returns 0 if successful, < 0 otherwise.. */
static int ensureCapacity(Array* array, int capacity) {
    int oldCapacity = array->capacity;
    if (capacity > oldCapacity) {
        int newCapacity = (oldCapacity == 0) ? INITIAL_CAPACITY : oldCapacity;

        // Ensure we're not doing something nasty
        if (capacity > MAX_CAPACITY)
            return -1;

        // Keep doubling capacity until we surpass necessary capacity.
        while (newCapacity < capacity) {
            int  newCap = newCapacity*2;
            // Handle integer overflows
            if (newCap < newCapacity || newCap > MAX_CAPACITY) {
                newCap = MAX_CAPACITY;
            }
            newCapacity = newCap;
        }

        // Should not happen, but better be safe than sorry
        if (newCapacity < 0 || newCapacity > MAX_CAPACITY)
            return -1;

        void** newContents;
        if (array->contents == NULL) {
            // Allocate new array.
            newContents = malloc(newCapacity * sizeof(void*));
            if (newContents == NULL) {
                return -1;
            }
        } else {
            // Expand existing array.
            newContents = realloc(array->contents, sizeof(void*) * newCapacity);
            if (newContents == NULL) {
                return -1;
            }
        }

        array->capacity = newCapacity;
        array->contents = newContents;
    }

    return 0;
}

int arrayAdd(Array* array, void* pointer) {
    assert(array != NULL);
    int size = array->size;
    int result = ensureCapacity(array, size + 1);
    if (result < 0) {
        return result;
    }
    array->contents[size] = pointer;
    array->size++;
    return 0;
}

static inline void checkBounds(Array* array, int index) {
    assert(array != NULL);
    assert(index < array->size);
    assert(index >= 0);
}

void* arrayGet(Array* array, int index) {
    checkBounds(array, index);
    return array->contents[index];
}

void* arrayRemove(Array* array, int index) {
    checkBounds(array, index);

    void* pointer = array->contents[index];
    
    int newSize = array->size - 1;
    
    // Shift entries left.
    if (index != newSize) {
        memmove(array->contents + index, array->contents + index + 1, 
                (sizeof(void*)) * (newSize - index));
    }

    array->size = newSize;

    return pointer;
}

void* arraySet(Array* array, int index, void* pointer) {
    checkBounds(array, index);
    void* old = array->contents[index];
    array->contents[index] = pointer;
    return old;
}

int arraySetSize(Array* array, int newSize) {
    assert(array != NULL);
    assert(newSize >= 0);
   
    int oldSize = array->size;
    
    if (newSize > oldSize) {
        // Expand.
        int result = ensureCapacity(array, newSize);
        if (result < 0) {
            return result;
        }

        // Zero out new entries.
        memset(array->contents + sizeof(void*) * oldSize, 0,
                sizeof(void*) * (newSize - oldSize));
    }

    array->size = newSize;

    return 0;
}

int arraySize(Array* array) {
    assert(array != NULL);
    return array->size;
}

const void** arrayUnwrap(Array* array) {
    return (const void**)array->contents;
}
