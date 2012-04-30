#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <SkPathEffect.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_ComposePathEffect_destructor(SkComposePathEffect* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT SkComposePathEffect*
libxobotos_ComposePathEffect_create(SkPathEffect* outerpe, SkPathEffect* innerpe)
{
	SkComposePathEffect* _retval = new SkComposePathEffect(outerpe, innerpe);
	return _retval;
}

