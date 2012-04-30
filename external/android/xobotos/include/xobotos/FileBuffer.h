// -*- c-basic-offset: 8 -*-
#ifndef XOBOTOS_FILE_BUFFER_H
#define XOBOTOS_FILE_BUFFER_H

#include <xobotos/Buffer.h>

namespace XobotOS {

using namespace android;

class FileBuffer : public Buffer
{
public:
	FileBuffer(int fd, size_t size) : Buffer(size), mFd(fd)
	{ }

	~FileBuffer();

	static FileBuffer* open(const char* filename);

	off_t tell();
	off_t seek(off_t offset, int whence);
	ssize_t read(void* buf, size_t size);

	FileMap* createMap(off_t offset, size_t size);

private:
	int mFd;
};

}

#endif
