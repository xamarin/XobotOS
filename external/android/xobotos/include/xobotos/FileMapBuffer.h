// -*- c-basic-offset: 8 -*-
#ifndef XOBOTOS_FILE_MAP_BUFFER_H
#define XOBOTOS_FILE_MAP_BUFFER_H

#include <xobotos/Buffer.h>

namespace XobotOS {

using namespace android;

class FileMapBuffer : public Buffer
{
public:
	FileMapBuffer(FileMap* map) : Buffer(map->getDataLength()), mMap(map)
	{ }

	~FileMapBuffer()
	{
		mMap->release();
	}

	static FileMap* createMap(const char* filename);
	static FileMapBuffer* create(const char* filename);

	off_t tell();
	off_t seek(off_t offset, int whence);
	ssize_t read(void* buf, size_t size);

	FileMap* createMap(off_t offset, size_t size);

private:
	FileMap* mMap;
	off_t mOffset;
};

}

#endif
