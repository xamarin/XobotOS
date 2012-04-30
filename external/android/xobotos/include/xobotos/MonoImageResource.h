// -*- c-basic-offset: 8 -*-
#ifndef XOBOTOS_MONO_IMAGE_RESOURCE_H
#define XOBOTOS_MONO_IMAGE_RESOURCE_H

#include <xobotos/MemoryBuffer.h>
#include <mono/metadata/metadata.h>
#include <mono/metadata/image.h>

namespace XobotOS {

extern "C" void mono_perfcounters_init(void);

class MonoImageResource : public MemoryBuffer
{
public:
	static MonoImageResource* open(FileMap* map, const char* resname);

private:
	FileMap* mMap;
	MonoImage* mImage;

	static class _init {
	public:
		_init() {
			// mono_perfcounters_init();
			// mono_images_init();
		}
	} _initializer;

	static const void* GetManifestResource(MonoImage* image, const char* name, uint32_t* size);

	MonoImageResource(FileMap* map, MonoImage* image, const void* ptr, size_t size);
	~MonoImageResource();
};

}

#endif
