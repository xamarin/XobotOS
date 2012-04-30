#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ColorFilterGlue.h>


extern "C" DLL_EXPORT SkColorFilter*
libxobotos_PorterDuffColorFilter_PorterDuffFilter_create(int srcColor, int porterDuffMode)
{
	SkColorFilter* _retval = ColorFilterGlue::PorterDuffFilter_create((SkColor)srcColor,
		(SkPorterDuff::Mode)porterDuffMode);
	return _retval;
}

extern "C" DLL_EXPORT const void*
libxobotos_PorterDuffColorFilter_PorterDuffFilter_postCreate(SkColorFilter* nativeFilter,
	int srcColor, int porterDuffMode)
{
	const void* _retval = ColorFilterGlue::PorterDuffFilter_postCreate(nativeFilter, 
		(SkColor)srcColor, (SkPorterDuff::Mode)porterDuffMode);
	return _retval;
}

