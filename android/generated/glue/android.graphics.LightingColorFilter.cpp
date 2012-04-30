#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ColorFilterGlue.h>


extern "C" DLL_EXPORT const void*
libxobotos_LightingColorFilter_LightingFilter_postCreate(SkColorFilter* nativeFilter,
	int mul, int add)
{
	const void* _retval = ColorFilterGlue::LightingFilter_postCreate(nativeFilter, mul,
		add);
	return _retval;
}

extern "C" DLL_EXPORT SkColorFilter*
libxobotos_LightingColorFilter_LightingFilter_create(int mul, int add)
{
	SkColorFilter* _retval = ColorFilterGlue::LightingFilter_create(mul, add);
	return _retval;
}

