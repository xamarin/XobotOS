// -*- c-basic-offset: 8 -*-
#ifndef XOBOTOS_MEMORY_BUFFER_H
#define XOBOTOS_MEMORY_BUFFER_H

#include <xobotos/Buffer.h>

namespace XobotOS {

using namespace android;

class MemoryBuffer : public Buffer
{
public:
	MemoryBuffer(const void* ptr, size_t size) : Buffer(size), mPtr(ptr), mOffset(0)
	{ }

	off_t tell();
	off_t seek(off_t offset, int whence);
	ssize_t read(void* buf, size_t size);

	FileMap* createMap(off_t offset, size_t size);

private:
	const void* mPtr;
	off_t mOffset;
};

}

#endif
