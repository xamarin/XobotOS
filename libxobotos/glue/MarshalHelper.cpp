// -*- c-basic-offset: 8 -*-
#include <libxobotos.h>

#define LOG_TAG "MarshalHelper"
#include <utils/Log.h>

size_t MarshalHelper::_totalAlloc = 0;

void
MarshalHelper::trackAlloc(const void* ptr, size_t size)
{
	_totalAlloc += size;
#if DEBUG
	LOGI("ALLOC(%p,%ld): %ld\n", ptr, size, _totalAlloc);
#endif
}

void
MarshalHelper::trackFree(const void* ptr, size_t size)
{
	_totalAlloc -= size;
#if DEBUG
	LOGI("DEALLOC(%p,%ld): %ld\n", ptr, size, _totalAlloc);
#endif
}

void
MarshalHelper::dumpMemoryUsage()
{
	LOGI("MEMORY USAGE: %ld\n", _totalAlloc);
}

