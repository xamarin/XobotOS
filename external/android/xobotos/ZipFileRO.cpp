// -*- c-basic-offset: 4 -*-
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

//
// Read-only access to Zip archives, with minimal heap allocation.
//
#define LOG_TAG "zipro"
#include <utils/ZipFileRO.h>
#include <utils/Log.h>

#include <zlib.h>

#include <string.h>
#include <assert.h>

#if HAVE_PRINTF_ZD
#  define ZD "%zd"
#  define ZD_TYPE ssize_t
#else
#  define ZD "%ld"
#  define ZD_TYPE long
#endif

using namespace android;

/*
 * Uncompress "deflate" data from one buffer to another.
 */
/*static*/ bool ZipFileRO::inflateBuffer(void* outBuf, const void* inBuf,
    size_t uncompLen, size_t compLen)
{
    bool result = false;
    z_stream zstream;
    int zerr;

    /*
     * Initialize the zlib stream struct.
     */
    memset(&zstream, 0, sizeof(zstream));
    zstream.zalloc = Z_NULL;
    zstream.zfree = Z_NULL;
    zstream.opaque = Z_NULL;
    zstream.next_in = (Bytef*)inBuf;
    zstream.avail_in = compLen;
    zstream.next_out = (Bytef*) outBuf;
    zstream.avail_out = uncompLen;
    zstream.data_type = Z_UNKNOWN;

    /*
     * Use the undocumented "negative window bits" feature to tell zlib
     * that there's no zlib header waiting for it.
     */
    zerr = inflateInit2(&zstream, -MAX_WBITS);
    if (zerr != Z_OK) {
        if (zerr == Z_VERSION_ERROR) {
            LOGE("Installed zlib is not compatible with linked version (%s)\n",
                ZLIB_VERSION);
        } else {
            LOGE("Call to inflateInit2 failed (zerr=%d)\n", zerr);
        }
        goto bail;
    }

    /*
     * Expand data.
     */
    zerr = inflate(&zstream, Z_FINISH);
    if (zerr != Z_STREAM_END) {
        LOGW("Zip inflate failed, zerr=%d (nIn=%p aIn=%u nOut=%p aOut=%u)\n",
            zerr, zstream.next_in, zstream.avail_in,
            zstream.next_out, zstream.avail_out);
        goto z_bail;
    }

    /* paranoia */
    if (zstream.total_out != uncompLen) {
        LOGW("Size mismatch on inflated file (%ld vs " ZD ")\n",
            zstream.total_out, (ZD_TYPE) uncompLen);
        goto z_bail;
    }

    result = true;

z_bail:
    inflateEnd(&zstream);        /* free up any allocated structures */

bail:
    return result;
}

/*
 * Uncompress "deflate" data from one buffer to an open file descriptor.
 */
/*static*/ bool ZipFileRO::inflateBuffer(int fd, const void* inBuf,
    size_t uncompLen, size_t compLen)
{
    bool result = false;
    const size_t kWriteBufSize = 32768;
    unsigned char writeBuf[kWriteBufSize];
    z_stream zstream;
    int zerr;

    /*
     * Initialize the zlib stream struct.
     */
    memset(&zstream, 0, sizeof(zstream));
    zstream.zalloc = Z_NULL;
    zstream.zfree = Z_NULL;
    zstream.opaque = Z_NULL;
    zstream.next_in = (Bytef*)inBuf;
    zstream.avail_in = compLen;
    zstream.next_out = (Bytef*) writeBuf;
    zstream.avail_out = sizeof(writeBuf);
    zstream.data_type = Z_UNKNOWN;

    /*
     * Use the undocumented "negative window bits" feature to tell zlib
     * that there's no zlib header waiting for it.
     */
    zerr = inflateInit2(&zstream, -MAX_WBITS);
    if (zerr != Z_OK) {
        if (zerr == Z_VERSION_ERROR) {
            LOGE("Installed zlib is not compatible with linked version (%s)\n",
                ZLIB_VERSION);
        } else {
            LOGE("Call to inflateInit2 failed (zerr=%d)\n", zerr);
        }
        goto bail;
    }

    /*
     * Loop while we have more to do.
     */
    do {
        /*
         * Expand data.
         */
        zerr = inflate(&zstream, Z_NO_FLUSH);
        if (zerr != Z_OK && zerr != Z_STREAM_END) {
            LOGW("zlib inflate: zerr=%d (nIn=%p aIn=%u nOut=%p aOut=%u)\n",
                zerr, zstream.next_in, zstream.avail_in,
                zstream.next_out, zstream.avail_out);
            goto z_bail;
        }

        /* write when we're full or when we're done */
        if (zstream.avail_out == 0 ||
            (zerr == Z_STREAM_END && zstream.avail_out != sizeof(writeBuf)))
        {
            long writeSize = zstream.next_out - writeBuf;
            int cc = write(fd, writeBuf, writeSize);
            if (cc != (int) writeSize) {
                LOGW("write failed in inflate (%d vs %ld)\n", cc, writeSize);
                goto z_bail;
            }

            zstream.next_out = writeBuf;
            zstream.avail_out = sizeof(writeBuf);
        }
    } while (zerr == Z_OK);

    assert(zerr == Z_STREAM_END);       /* other errors should've been caught */

    /* paranoia */
    if (zstream.total_out != uncompLen) {
        LOGW("Size mismatch on inflated file (%ld vs " ZD ")\n",
            zstream.total_out, (ZD_TYPE) uncompLen);
        goto z_bail;
    }

    result = true;

z_bail:
    inflateEnd(&zstream);        /* free up any allocated structures */

bail:
    return result;
}
