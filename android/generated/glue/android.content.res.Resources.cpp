#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <AssetManagerGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_content_res_Resources_Theme_destructor(AssetManagerGlue::Theme*
	 ptr)
{
	delete ptr;
}


