#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <MaskFilterGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_MaskFilter_destructor(SkMaskFilter* ptr)
{
	SkSafeUnref(ptr);
}


