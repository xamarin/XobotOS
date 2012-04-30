// -*- c-basic-offset: 8 -*-
#ifndef XOBOTOS_BUFFER_H
#define XOBOTOS_BUFFER_H

#include <utils/FileMap.h>
#include <sys/types.h>
#include <stdio.h>

namespace XobotOS {

using namespace android;

class Buffer
{
public:
	size_t size() const { return mSize; }
	virtual off_t tell() = 0;
	virtual off_t seek(off_t offset, int whence) = 0;
	virtual ssize_t read(void* buf, size_t size) = 0;
	virtual FileMap* createMap(off_t offset, size_t size) = 0;

protected:
	Buffer(size_t size) : mSize(size) { }

	size_t mSize;

private:
	/* these are private and not defined */ 
	Buffer(const Buffer& src);
	Buffer& operator=(const Buffer& src);
};

}

#endif
