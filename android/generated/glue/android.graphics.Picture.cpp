#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <PictureGlue.h>
#include <CanvasGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Picture_destructor(PictureGlue* ptr)
{
	SkSafeUnref(ptr);
}


extern "C" DLL_EXPORT int
libxobotos_Picture_width(PictureGlue* _instance)
{
	int _retval = _instance->width();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Picture_endRecording(PictureGlue* nativeCanvas)
{
	nativeCanvas->endRecording();
}

extern "C" DLL_EXPORT void
libxobotos_Picture_draw(SkCanvas* nativeCanvas, PictureGlue* nativePicture)
{
	PictureGlue::draw(nativeCanvas, nativePicture);
}

extern "C" DLL_EXPORT SkCanvas*
libxobotos_Picture_beginRecording(PictureGlue* nativeCanvas, int w, int h)
{
	SkCanvas* _retval = nativeCanvas->beginRecording(w, h);
	return _retval;
}

extern "C" DLL_EXPORT PictureGlue*
libxobotos_Picture_create(PictureGlue* nativeSrcOr0)
{
	PictureGlue* _retval = PictureGlue::create(nativeSrcOr0);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Picture_height(PictureGlue* _instance)
{
	int _retval = _instance->height();
	return _retval;
}

