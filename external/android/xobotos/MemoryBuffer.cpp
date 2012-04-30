// -*- c-basic-offset: 8 -*-
#define LOG_TAG "Buffer"
#include <xobotos/MemoryBuffer.h>
#include <utils/Log.h>
#include <string.h>
#include <assert.h>

using namespace XobotOS;

off_t
MemoryBuffer::tell()
{
	return mOffset;
}

off_t
MemoryBuffer::seek(off_t offset, int whence)
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
MemoryBuffer::read(void* buf, size_t size)
{
	if (mOffset+size > mSize)
		return -1;

	memcpy(buf, (const char*)mPtr+mOffset, size);
	mOffset += size;
	return size;
}

FileMap*
MemoryBuffer::createMap(off_t offset, size_t size)
{
	return new FileMap((char*)mPtr+offset, size);
}

