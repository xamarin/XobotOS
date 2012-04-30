// -*- c-basic-offset: 8 -*-
#define LOG_TAG "Buffer"
#include <xobotos/FileBuffer.h>
#include <utils/Log.h>

#include <string.h>
#include <fcntl.h>
#include <errno.h>
#include <assert.h>
#include <unistd.h>

/*
 * We must open binary files using open(path, ... | O_BINARY) under Windows.
 * Otherwise strange read errors will happen.
 */
#ifndef O_BINARY
#  define O_BINARY  0
#endif

/*
 * TEMP_FAILURE_RETRY is defined by some, but not all, versions of
 * <unistd.h>. (Alas, it is not as standard as we'd hoped!) So, if it's
 * not already defined, then define it here.
 */
#ifndef TEMP_FAILURE_RETRY
/* Used to retry syscalls that can return EINTR. */
#define TEMP_FAILURE_RETRY(exp) ({         \
    typeof (exp) _rc;                      \
    do {                                   \
        _rc = (exp);                       \
    } while (_rc == -1 && errno == EINTR); \
    _rc; })
#endif

using namespace XobotOS;

FileBuffer*
FileBuffer::open(const char* filename)
{
	int fd;
	size_t len;

	fd = ::open(filename, O_RDONLY | O_BINARY);
	if (fd < 0) {
		LOGW("Unable to open file '%s': %s\n", filename, strerror(errno));
		return NULL;
	}

	len = lseek(fd, 0, SEEK_END);
	lseek(fd, 0, SEEK_SET);

	return new FileBuffer(fd, len);
}

off_t
FileBuffer::tell()
{
	return lseek(mFd, 0, SEEK_CUR);
}

off_t
FileBuffer::seek(off_t offset, int whence)
{
	return lseek(mFd, offset, whence);
}

ssize_t
FileBuffer::read(void* buf, size_t size)
{
	return TEMP_FAILURE_RETRY(::read(mFd, buf, size));
}

FileBuffer::~FileBuffer()
{
	if (mFd >= 0)
		TEMP_FAILURE_RETRY(close(mFd));
}

FileMap*
FileBuffer::createMap(off_t offset, size_t size)
{
	FileMap* map = new FileMap();
	if (!map)
		return NULL;

	if (!map->create(NULL, mFd, offset, size, true)) {
		map->release();
		return NULL;
	}

	return map;
}

