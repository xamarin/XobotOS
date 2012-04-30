// -*- c-basic-offset: 8 -*-
#define LOG_TAG "MonoImageResource"
#include <utils/Log.h>

#include <xobotos/MonoImageResource.h>
#include <mono/metadata/metadata.h>
#include <mono/metadata/assembly.h>
#include <string.h>
#include <assert.h>

using namespace XobotOS;

MonoImageResource::_init MonoImageResource::_initializer;

const void*
MonoImageResource::GetManifestResource (MonoImage* image, const char* name, uint32_t* size) 
{
	const MonoTableInfo* table = mono_image_get_table_info (image, MONO_TABLE_MANIFESTRESOURCE);
	uint32_t i, rows;
	uint32_t cols [MONO_MANIFEST_SIZE];
	uint32_t impl, file_idx;
	const char* val;
	MonoImage* module;

	rows = mono_table_info_get_rows (table);

	for (i = 0; i < rows; ++i) {
		mono_metadata_decode_row (table, i, cols, MONO_MANIFEST_SIZE);
		val = mono_metadata_string_heap (image, cols [MONO_MANIFEST_NAME]);
		if (strcmp (val, name) == 0)
			break;
	}
	if (i == rows)
		return NULL;
	/* FIXME */
	impl = cols [MONO_MANIFEST_IMPLEMENTATION];
	if (impl) {
		/*
		 * this code should only be called after obtaining the 
		 * ResourceInfo and handling the other cases.
		 */
		assert ((impl & MONO_IMPLEMENTATION_MASK) == MONO_IMPLEMENTATION_FILE);
		file_idx = impl >> MONO_IMPLEMENTATION_BITS;

		module = mono_image_load_file_for_image (image, file_idx);
		if (!module)
			return NULL;
	}
	else
		module = image;

	return (const void*)mono_image_get_resource (module, cols [MONO_MANIFEST_OFFSET], size);
}

MonoImageResource*
MonoImageResource::open(FileMap* map, const char* resname)
{
	MonoImage* image = mono_image_open_from_data((char*)map->getDataPtr(), map->getDataLength(), false, NULL);
	if (!image)
		return NULL;

	uint32_t size;
	const void* ptr = GetManifestResource(image, resname, &size);
	if (!ptr) {
		mono_image_close(image);
		return NULL;
	}

	return new MonoImageResource(map, image, ptr, size);
}

MonoImageResource::MonoImageResource(FileMap* map, MonoImage* image, const void* ptr, size_t size)
	: MemoryBuffer(ptr, size), mMap(map), mImage(image)
{
	assert(ptr >= map->getDataPtr());
	assert((char*)ptr+size <= (char*)map->getDataPtr()+map->getDataLength());
}

MonoImageResource::~MonoImageResource()
{
	mono_image_close(mImage);
	mMap->release();
}
