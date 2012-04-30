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

#ifndef HAVE_SYS_UIO_H

#include <cutils/uio.h>
#include <unistd.h>

int  readv( int  fd, struct iovec*  vecs, int  count )
{
    int   total = 0;

    for ( ; count > 0; count--, vecs++ ) {
        const char*  buf = vecs->iov_base;
        int          len = vecs->iov_len;
        
        while (len > 0) {
            int  ret = read( fd, buf, len );
            if (ret < 0) {
                if (total == 0)
                    total = -1;
                goto Exit;
            }
            if (ret == 0)
                goto Exit;

            total += ret;
            buf   += ret;
            len   -= ret;
        }
    }
Exit:
    return total;
}

int  writev( int  fd, const struct iovec*  vecs, int  count )
{
    int   total = 0;

    for ( ; count > 0; count--, vecs++ ) {
        const char*  buf = (const char*)vecs->iov_base;
        int          len = (int)vecs->iov_len;
        
        while (len > 0) {
            int  ret = write( fd, buf, len );
            if (ret < 0) {
                if (total == 0)
                    total = -1;
                goto Exit;
            }
            if (ret == 0)
                goto Exit;

            total += ret;
            buf   += ret;
            len   -= ret;
        }
    }
Exit:    
    return total;
}

#endif /* !HAVE_SYS_UIO_H */
