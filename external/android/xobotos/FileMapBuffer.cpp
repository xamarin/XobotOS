// -*- c-basic-offset: 8 -*-
#define LOG_TAG "Buffer"
#include <xobotos/FileMapBuffer.h>
#include <xobotos/MonoImageResource.h>
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

using namespace XobotOS;

FileMap*
FileMapBuffer::createMap(const char* filename)
{
	int fd;
	size_t length;

	fd = ::open(filename, O_RDONLY | O_BINARY);
	if (fd < 0) {
		LOGW("Unable to open file '%s': %s\n", filename, strerror(errno));
		return NULL;
	}

	length = lseek(fd, 0, SEEK_END);
	lseek(fd, 0, SEEK_SET);

	FileMap* map = new FileMap();
	if (!map) {
		LOGW("Unable to create file map for '%s': %s\n", filename, strerror(errno));
		return NULL;
	}

	if (!map->create(filename, fd, 0, length, true)) {
		map->release();
		LOGW("Unable to create file map for '%s': %s\n", filename, strerror(errno));
		return NULL;
	}

	close(fd);

	return map;
}

FileMapBuffer*
FileMapBuffer::create(const char* filename)
{
	FileMap* map = createMap(filename);
	if (!map)
		return NULL;

	return new FileMapBuffer(map);
}

off_t
FileMapBuffer::tell()
{
	return mOffset;
}

off_t
FileMapBuffer::seek(off_t offset, int whence)
{
	off_t newOffset;

	switch (whence) {
	case SEEK_SET:
		newOffset = offset;
		break;
	case SEEK_CUR:
		newOffset = mOffset + offset;
		break;
	case SEEK_END:
		newOffset = mSize + offset;
		break;
	default:
		LOGW("unexpected whence %d\n", whence);
		assert(false);
		return (off_t) -1;
	}

	if (newOffset < 0 || (size_t)newOffset > mSize) {
		LOGW("seek out of range: want %ld, end=%ld\n",
		     (long) newOffset, (long) mSize);
		return (off_t) -1;
	}

	mOffset = newOffset;
	return newOffset;
}

ssize_t
FileMapBuffer::read(void* buf, size_t size)
{
	if (mOffset+size > mSize)
		return -1;

	memcpy(buf, (const char*)mMap->getDataPtr()+mOffset, size);
	mOffset += size;
	return size;
}

FileMap*
FileMapBuffer::createMap(off_t offset, size_t size)
{
	return mMap->createSubMap(offset, size);
}
