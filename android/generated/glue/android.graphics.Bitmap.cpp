#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <BitmapGlue.h>
#include <PaintGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Bitmap_destructor(BitmapGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT BitmapGlue*
libxobotos_Bitmap_extractAlpha(BitmapGlue* nativeBitmap, PaintGlue* nativePaint, 
	Array_int_Struct* offsetXY_ptr)
{
	NativeArray<int>* offsetXY = Array_int_Helper::wrap(offsetXY_ptr);
	BitmapGlue* _retval = nativeBitmap->extractAlpha(nativePaint, offsetXY);
	delete offsetXY;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Bitmap_hasAlpha(BitmapGlue* nativeBitmap)
{
	bool _retval = nativeBitmap->hasAlpha();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Bitmap_isMutable(BitmapGlue* _instance)
{
	bool _retval = _instance->isMutable();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Bitmap_width(BitmapGlue* nativeBitmap)
{
	int _retval = nativeBitmap->width();
	return _retval;
}

extern "C" DLL_EXPORT BitmapGlue*
libxobotos_Bitmap_create(Array_int_Struct* colors_ptr, int offset, int stride, int
	 width, int height, int nativeConfig, bool _mutable)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	BitmapGlue* _retval = new BitmapGlue(colors, offset, stride, width, height, (SkBitmap::Config)
		nativeConfig, _mutable);
	delete colors;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Bitmap_height(BitmapGlue* nativeBitmap)
{
	int _retval = nativeBitmap->height();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Bitmap_getPixels(BitmapGlue* nativeBitmap, Array_int_Struct* pixels_ptr,
	int offset, int stride, int x, int y, int width, int height)
{
	NativeArray<int>* pixels = Array_int_Helper::wrap(pixels_ptr);
	nativeBitmap->getPixels(*pixels, offset, stride, x, y, width, height);
	delete pixels;
}

extern "C" DLL_EXPORT void
libxobotos_Bitmap_setHasAlpha(BitmapGlue* nBitmap, bool hasAlpha)
{
	nBitmap->setHasAlpha(hasAlpha);
}

extern "C" DLL_EXPORT void
libxobotos_Bitmap_recycle(BitmapGlue* nativeBitmap)
{
	nativeBitmap->recycle();
}

extern "C" DLL_EXPORT int
libxobotos_Bitmap_rowBytes(BitmapGlue* nativeBitmap)
{
	int _retval = nativeBitmap->rowBytes();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Bitmap_getPixel(BitmapGlue* nativeBitmap, int x, int y)
{
	int _retval = nativeBitmap->getPixel(x, y);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Bitmap_setPixel(BitmapGlue* nativeBitmap, int x, int y, int color)
{
	nativeBitmap->setPixel(x, y, color);
}

extern "C" DLL_EXPORT bool
libxobotos_Bitmap_sameAs(BitmapGlue* nb0, BitmapGlue* nb1)
{
	bool _retval = nb0->sameAs(*nb1);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Bitmap_getGenerationID(BitmapGlue* nativeBitmap)
{
	int _retval = nativeBitmap->getGenerationID();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Bitmap_prepareToDraw(BitmapGlue* nativeBitmap)
{
	nativeBitmap->prepareToDraw();
}

extern "C" DLL_EXPORT void
libxobotos_Bitmap_setPixels(BitmapGlue* nativeBitmap, Array_int_Struct* colors_ptr,
	int offset, int stride, int x, int y, int width, int height)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	nativeBitmap->setPixels(*colors, offset, stride, x, y, width, height);
	delete colors;
}

extern "C" DLL_EXPORT int
libxobotos_Bitmap_config(BitmapGlue* nativeBitmap)
{
	int _retval = nativeBitmap->config();
	return _retval;
}

extern "C" DLL_EXPORT BitmapGlue*
libxobotos_Bitmap_copy(BitmapGlue* srcBitmap, int nativeConfig, bool isMutable)
{
	BitmapGlue* _retval = srcBitmap->copy((SkBitmap::Config)nativeConfig, isMutable);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Bitmap_eraseColor(BitmapGlue* nativeBitmap, int color)
{
	nativeBitmap->eraseColor(color);
}

