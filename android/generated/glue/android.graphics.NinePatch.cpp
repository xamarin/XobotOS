#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <NinePatchGlue.h>
#include <CanvasGlue.h>
#include "android.graphics.RectF.h"
#include <BitmapGlue.h>
#include <PaintGlue.h>
#include "android.graphics.Rect.h"
#include <RegionGlue.h>


extern "C" DLL_EXPORT void
libxobotos_NinePatch_drawF(SkCanvas* canvas_instance, RectF_Struct* loc_ptr, BitmapGlue*
	 bitmap_instance, Array_byte_Struct* c_ptr, PaintGlue* paint_instance_or_null, int
	 destDensity, int srcDensity)
{
	SkRect* loc = RectF_Helper::wrap(loc_ptr);
	const NativeArray<uint8_t>* c = Array_byte_Helper::wrapConst(c_ptr);
	NinePatchGlue::draw(*canvas_instance, *loc, *bitmap_instance, *c, paint_instance_or_null,
		destDensity, srcDensity);
	if (loc_ptr != NULL)
	{
		RectF_Helper::marshalOut(*loc, loc_ptr);
	}
	delete loc;
	delete c;
}

extern "C" DLL_EXPORT void
libxobotos_NinePatch_drawI(SkCanvas* canvas_instance, Rect_Struct* loc_ptr, BitmapGlue*
	 bitmap_instance, Array_byte_Struct* c_ptr, PaintGlue* paint_instance_or_null, int
	 destDensity, int srcDensity)
{
	SkIRect* loc = Rect_Helper::wrap(loc_ptr);
	const NativeArray<uint8_t>* c = Array_byte_Helper::wrapConst(c_ptr);
	NinePatchGlue::draw(*canvas_instance, *loc, *bitmap_instance, *c, paint_instance_or_null,
		destDensity, srcDensity);
	if (loc_ptr != NULL)
	{
		Rect_Helper::marshalOut(*loc, loc_ptr);
	}
	delete loc;
	delete c;
}

extern "C" DLL_EXPORT RegionGlue*
libxobotos_NinePatch_getTransparentRegion(BitmapGlue* bitmap, Array_byte_Struct* 
	chunk_ptr, Rect_Struct* location_ptr)
{
	const NativeArray<uint8_t>* chunk = Array_byte_Helper::wrapConst(chunk_ptr);
	const SkIRect* location = Rect_Helper::wrapConst(location_ptr);
	RegionGlue* _retval = NinePatchGlue::getTransparentRegion(*bitmap, *chunk, *location);
	delete chunk;
	delete location;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_NinePatch_validateNinePatchChunk(BitmapGlue* bitmap, Array_byte_Struct*
	 chunk_ptr)
{
	const NativeArray<uint8_t>* chunk = Array_byte_Helper::wrapConst(chunk_ptr);
	NinePatchGlue::validateNinePatchChunk(*bitmap, *chunk);
	delete chunk;
}

extern "C" DLL_EXPORT bool
libxobotos_NinePatch_isNinePatchChunk(Array_byte_Struct* chunk_ptr)
{
	const NativeArray<uint8_t>* chunk = Array_byte_Helper::wrapConst(chunk_ptr);
	bool _retval = NinePatchGlue::isNinePatchChunk(chunk);
	delete chunk;
	return _retval;
}

