#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <CanvasGlue.h>
#include <BitmapGlue.h>
#include <PaintGlue.h>
#include "android.graphics.RectF.h"
#include "android.graphics.Rect.h"
#include <DrawFilterGlue.h>
#include <PathGlue.h>
#include <MatrixGlue.h>
#include <PictureGlue.h>
#include <RegionGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Canvas_destructor(SkCanvas* ptr)
{
	SkSafeUnref(ptr);
}

struct Array_short_Struct
{
	uint32_t _owner;
	uint32_t length;
	short* ptr;
};

class Array_short_Helper
{
public:
	static void
	unwrap(NativeArray<short>& from, Array_short_Struct* to)
	{
		to->_owner = 0x7380548b;
		to->length = from.length();
		{
			to->ptr = MarshalHelper::allocArray<short>(from.length());
			for(uint32_t i = 0; i < from.length(); i++)
			{
				to->ptr[i] = from.item(i);
			}
		}
	}

	static Array_short_Struct*
	unwrap(NativeArray<short>* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		Array_short_Struct* retval = new Array_short_Struct();
		Array_short_Helper::unwrap(*src, retval);
		return retval;
	}

	static void
	marshalOut(const NativeArray<short>& from, Array_short_Struct* to)
	{
		assert(from.length() == to->length);
		for(uint32_t i = 0; i < from.length(); i++)
		{
			to->ptr[i] = from.item(i);
		}
	}

	static void
	wrap(const Array_short_Struct& from, NativeArray<short>* to)
	{
		assert(from.length == to->length());
		for(uint32_t i = 0; i < from.length; i++)
		{
			to->item(i) = from.ptr[i];
		}
	}

	static NativeArray<short>*
	wrap(const Array_short_Struct* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		NativeArray<short>* retval = new NativeArray<short>(src->length);
		Array_short_Helper::wrap(*src, retval);
		return retval;
	}

	static const NativeArray<short>*
	wrapConst(const Array_short_Struct* src)
	{
		return const_cast<const NativeArray<short>*>(Array_short_Helper::wrap(src));
	}

	static void
	freeMembers(Array_short_Struct& obj)
	{
		assert(obj._owner == 0x7380548b);
		MarshalHelper::freeArray<short>(obj.ptr, obj.length);
	}

	static void
	destructor(Array_short_Struct* obj)
	{
		if (obj == NULL)
		{
			return;
		}
		Array_short_Helper::freeMembers(*obj);
		delete obj;
	}


private:
	Array_short_Helper();

};

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Canvas_Array_short_destructor(Array_short_Struct* obj)
{
	Array_short_Helper::destructor(obj);
}


extern "C" DLL_EXPORT void
libxobotos_Canvas_drawBitmap(SkCanvas* nativeCanvas, BitmapGlue* bitmap, float left,
	float top, PaintGlue* nativePaintOrZero, int canvasDensity, int screenDensity, int
	 bitmapDensity)
{
	CanvasGlue::drawBitmap(*nativeCanvas, *bitmap, left, top, nativePaintOrZero, canvasDensity,
		screenDensity, bitmapDensity);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawArc(SkCanvas* nativeCanvas, RectF_Struct* oval_ptr, float startAngle,
	float sweep, bool useCenter, PaintGlue* paint)
{
	const SkRect* oval = RectF_Helper::wrapConst(oval_ptr);
	nativeCanvas->drawArc(*oval, startAngle, sweep, useCenter, *paint);
	delete oval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawBitmapRect(SkCanvas* nativeCanvas, BitmapGlue* bitmap, Rect_Struct*
	 src_ptr, Rect_Struct* dst_ptr, PaintGlue* nativePaintOrZero, int screenDensity,
	int bitmapDensity)
{
	const SkIRect* src = Rect_Helper::wrapConst(src_ptr);
	const SkIRect* dst = Rect_Helper::wrapConst(dst_ptr);
	CanvasGlue::drawBitmapRect(*nativeCanvas, *bitmap, src, *dst, nativePaintOrZero, 
		screenDensity, bitmapDensity);
	delete src;
	delete dst;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_rotate(SkCanvas* _instance, float degrees)
{
	_instance->rotate(degrees);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawPoints(CanvasGlue* _instance, Array_float_Struct* pts_ptr, 
	int offset, int count, PaintGlue* paint)
{
	const NativeArray<float>* pts = Array_float_Helper::wrapConst(pts_ptr);
	CanvasGlue::drawPoints(*_instance, *pts, offset, count, *paint);
	delete pts;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_setDrawFilter(SkCanvas* nativeCanvas, SkDrawFilter* nativeFilter)
{
	nativeCanvas->setDrawFilter(nativeFilter);
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_saveLayer(SkCanvas* nativeCanvas, RectF_Struct* bounds_ptr, PaintGlue*
	 paint, int layerFlags)
{
	const SkRect* bounds = RectF_Helper::wrapConst(bounds_ptr);
	int _retval = nativeCanvas->saveLayer(bounds, paint, (SkCanvas::SaveFlags)layerFlags);
	delete bounds;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_quickReject_0(SkCanvas* nativeCanvas, PathGlue* path, int native_edgeType)
{
	bool _retval = nativeCanvas->quickReject(*path, (SkCanvas::EdgeType)native_edgeType);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_quickReject_1(SkCanvas* nativeCanvas, float left, float top, float
	 right, float bottom, int native_edgeType)
{
	bool _retval = CanvasGlue::quickReject(*nativeCanvas, left, top, right, bottom, (
		SkCanvas::EdgeType)native_edgeType);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawColor_0(SkCanvas* nativeCanvas, int color, int mode)
{
	nativeCanvas->drawColor((SkColor)color, (SkXfermode::Mode)mode);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawPaint(SkCanvas* nativeCanvas, PaintGlue* paint)
{
	nativeCanvas->drawPaint(*paint);
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_getHeight(CanvasGlue* _instance)
{
	int _retval = CanvasGlue::getHeight(*_instance);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_setMatrix(SkCanvas* nCanvas, MatrixGlue* nMatrix)
{
	nCanvas->setMatrix(*nMatrix);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawVertices(SkCanvas* nCanvas, int mode, int n, Array_float_Struct*
	 verts_ptr, int vertOffset, Array_float_Struct* texs_ptr, int texOffset, Array_int_Struct*
	 colors_ptr, int colorOffset, Array_short_Struct* indices_ptr, int indexOffset, 
	int indexCount, PaintGlue* nPaint)
{
	const NativeArray<float>* verts = Array_float_Helper::wrapConst(verts_ptr);
	const NativeArray<float>* texs = Array_float_Helper::wrapConst(texs_ptr);
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	const NativeArray<short>* indices = Array_short_Helper::wrapConst(indices_ptr);
	CanvasGlue::drawVertices(*nCanvas, (SkCanvas::VertexMode)mode, n, *verts, vertOffset,
		texs, texOffset, colors, colorOffset, indices, indexOffset, indexCount, *nPaint);
	delete verts;
	delete texs;
	delete colors;
	delete indices;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawPoint(SkCanvas* _instance, float x, float y, PaintGlue* paint)
{
	_instance->drawPoint(x, y, *paint);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawRect_0(SkCanvas* nativeCanvas, float left, float top, float
	 right, float bottom, PaintGlue* paint)
{
	CanvasGlue::drawRect(*nativeCanvas, left, top, right, bottom, *paint);
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_clipIRect_0(CanvasGlue* _instance, int left, int top, int right,
	int bottom)
{
	bool _retval = CanvasGlue::clipIRect(*_instance, left, top, right, bottom);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawRGB(SkCanvas* nativeCanvas, int r, int g, int b)
{
	CanvasGlue::drawRGB(*nativeCanvas, r, g, b);
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_save_0(SkCanvas* _instance, int saveFlags)
{
	int _retval = _instance->save((SkCanvas::SaveFlags)saveFlags);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawTextRunC(SkCanvas* nativeCanvas, Array_char_Struct* text_ptr,
	int start, int count, int contextStart, int contextCount, float x, float y, int 
	flags, PaintGlue* paint)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	CanvasGlue::drawTextRunC(*nativeCanvas, *text, start, count, contextStart, contextCount,
		x, y, flags, *paint);
	delete text;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_clipRect(SkCanvas* _instance, RectF_Struct* rect_ptr)
{
	const SkRect* rect = RectF_Helper::wrapConst(rect_ptr);
	bool _retval = _instance->clipRect(*rect);
	delete rect;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_setBitmap(SkCanvas* nativeCanvas, BitmapGlue* bitmap)
{
	CanvasGlue::setBitmap(*nativeCanvas, bitmap);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_scale(SkCanvas* _instance, float sx, float sy)
{
	_instance->scale(sx, sy);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_translate(SkCanvas* _instance, float dx, float dy)
{
	_instance->translate(dx, dy);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawBitmapMesh(SkCanvas* nCanvas, BitmapGlue* nBitmap, int meshWidth,
	int meshHeight, Array_float_Struct* verts_ptr, int vertOffset, Array_int_Struct*
	 colors_ptr, int colorOffset, PaintGlue* nPaint)
{
	const NativeArray<float>* verts = Array_float_Helper::wrapConst(verts_ptr);
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	CanvasGlue::drawBitmapMesh(*nCanvas, *nBitmap, meshWidth, meshHeight, *verts, vertOffset,
		colors, colorOffset, nPaint);
	delete verts;
	delete colors;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawTextRunS(SkCanvas* nativeCanvas, String_Struct* text_ptr, int
	 start, int end, int contextStart, int contextEnd, float x, float y, int flags, 
	PaintGlue* paint)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	CanvasGlue::drawTextRunS(*nativeCanvas, *text, start, end, contextStart, contextEnd,
		x, y, flags, *paint);
	delete text;
}

extern "C" DLL_EXPORT SkCanvas*
libxobotos_Canvas_create(BitmapGlue* nativeBitmapOrZero)
{
	SkCanvas* _retval = CanvasGlue::create(nativeBitmapOrZero);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_clipPath(SkCanvas* nativeCanvas, PathGlue* nativePath, int regionOp)
{
	bool _retval = nativeCanvas->clipPath(*nativePath, (SkRegion::Op)regionOp);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawColor(SkCanvas* nativeCanvas, int color)
{
	nativeCanvas->drawColor((SkColor)color);
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_quickReject(SkCanvas* nativeCanvas, RectF_Struct* rect_ptr, int
	 native_edgeType)
{
	const SkRect* rect = RectF_Helper::wrapConst(rect_ptr);
	bool _retval = nativeCanvas->quickReject(*rect, (SkCanvas::EdgeType)native_edgeType);
	delete rect;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_freeCaches()
{
	CanvasGlue::freeCaches();
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawLine(SkCanvas* nativeCanvas, float startX, float startY, float
	 stopX, float stopY, PaintGlue* paint)
{
	nativeCanvas->drawLine(startX, startY, stopX, stopY, *paint);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_skew(SkCanvas* _instance, float sx, float sy)
{
	_instance->skew(sx, sy);
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_getSaveCount(SkCanvas* _instance)
{
	int _retval = _instance->getSaveCount();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawBitmapColors(SkCanvas* nativeCanvas, Array_int_Struct* colors_ptr,
	int offset, int stride, float x, float y, int width, int height, bool hasAlpha, 
	PaintGlue* nativePaintOrZero)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	CanvasGlue::drawBitmapColors(*nativeCanvas, *colors, offset, stride, x, y, width,
		height, hasAlpha, nativePaintOrZero);
	delete colors;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_isOpaque(CanvasGlue* _instance)
{
	bool _retval = CanvasGlue::isOpaque(*_instance);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawPicture(SkCanvas* nativeCanvas, PictureGlue* nativePicture)
{
	nativeCanvas->drawPicture(*nativePicture);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawARGB(SkCanvas* nativeCanvas, int a, int r, int g, int b)
{
	nativeCanvas->drawARGB(a, r, g, b);
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_getWidth(CanvasGlue* _instance)
{
	int _retval = CanvasGlue::getWidth(*_instance);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawTextS(SkCanvas* nativeCanvas, String_Struct* text_ptr, int 
	start, int end, float x, float y, int flags, PaintGlue* paint)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	CanvasGlue::drawTextS(*nativeCanvas, *text, start, end, x, y, flags, *paint);
	delete text;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawPath(SkCanvas* nativeCanvas, PathGlue* path, PaintGlue* paint)
{
	nativeCanvas->drawPath(*path, *paint);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawBitmapMatrix(SkCanvas* nCanvas, BitmapGlue* nBitmap, MatrixGlue*
	 nMatrix, PaintGlue* nPaint)
{
	nCanvas->drawBitmapMatrix(*nBitmap, *nMatrix, nPaint);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawLines(CanvasGlue* _instance, Array_float_Struct* pts_ptr, int
	 offset, int count, PaintGlue* paint)
{
	const NativeArray<float>* pts = Array_float_Helper::wrapConst(pts_ptr);
	CanvasGlue::drawLines(*_instance, *pts, offset, count, *paint);
	delete pts;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_restoreToCount(SkCanvas* _instance, int saveCount)
{
	_instance->restoreToCount(saveCount);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawRect(SkCanvas* nativeCanvas, RectF_Struct* rect_ptr, PaintGlue*
	 paint)
{
	const SkRect* rect = RectF_Helper::wrapConst(rect_ptr);
	nativeCanvas->drawRect(*rect, *paint);
	delete rect;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_clipRectValues(SkCanvas* nCanvas, float left, float top, float 
	right, float bottom, int regionOp)
{
	bool _retval = CanvasGlue::clipRectValues(*nCanvas, left, top, right, bottom, (SkRegion::Op)
		regionOp);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_getClipBoundsIRect(SkCanvas* nativeCanvas, Rect_Struct* bounds_ptr)
{
	SkIRect* bounds = Rect_Helper::wrap(bounds_ptr);
	bool _retval = CanvasGlue::getClipBoundsIRect(*nativeCanvas, *bounds);
	if (bounds_ptr != NULL)
	{
		Rect_Helper::marshalOut(*bounds, bounds_ptr);
	}
	delete bounds;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawRoundRect(SkCanvas* nativeCanvas, RectF_Struct* rect_ptr, float
	 rx, float ry, PaintGlue* paint)
{
	const SkRect* rect = RectF_Helper::wrapConst(rect_ptr);
	nativeCanvas->drawRoundRect(*rect, rx, ry, *paint);
	delete rect;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_clipRect_0(CanvasGlue* _instance, float left, float top, float 
	right, float bottom)
{
	bool _retval = CanvasGlue::clipRect(*_instance, left, top, right, bottom);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawOval(SkCanvas* nativeCanvas, RectF_Struct* oval_ptr, PaintGlue*
	 paint)
{
	const SkRect* oval = RectF_Helper::wrapConst(oval_ptr);
	nativeCanvas->drawOval(*oval, *paint);
	delete oval;
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_saveLayerAlpha(SkCanvas* nativeCanvas, RectF_Struct* bounds_ptr,
	int alpha, int layerFlags)
{
	const SkRect* bounds = RectF_Helper::wrapConst(bounds_ptr);
	int _retval = nativeCanvas->saveLayerAlpha(bounds, alpha, (SkCanvas::SaveFlags)layerFlags);
	delete bounds;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawTextC(SkCanvas* nativeCanvas, Array_char_Struct* text_ptr, 
	int index, int count, float x, float y, int flags, PaintGlue* paint)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	CanvasGlue::drawTextC(*nativeCanvas, *text, index, count, x, y, flags, *paint);
	delete text;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawCircle(SkCanvas* nativeCanvas, float cx, float cy, float radius,
	PaintGlue* paint)
{
	nativeCanvas->drawCircle(cx, cy, radius, *paint);
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_restore(SkCanvas* _instance)
{
	_instance->restore();
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_saveLayerValues(SkCanvas* nativeCanvas, float l, float t, float
	 r, float b, PaintGlue* paint, int layerFlags)
{
	int _retval = CanvasGlue::saveLayerValues(*nativeCanvas, l, t, r, b, paint, (SkCanvas::SaveFlags)
		layerFlags);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_save(SkCanvas* _instance)
{
	int _retval = _instance->save();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_drawBitmapRectF(SkCanvas* nativeCanvas, BitmapGlue* bitmap, Rect_Struct*
	 src_ptr, RectF_Struct* dst_ptr, PaintGlue* nativePaintOrZero, int screenDensity,
	int bitmapDensity)
{
	const SkIRect* src = Rect_Helper::wrapConst(src_ptr);
	const SkRect* dst = RectF_Helper::wrapConst(dst_ptr);
	CanvasGlue::drawBitmapRect(*nativeCanvas, *bitmap, src, *dst, nativePaintOrZero, 
		screenDensity, bitmapDensity);
	delete src;
	delete dst;
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_clipRegion(SkCanvas* nativeCanvas, RegionGlue* nativeRegion, int
	 regionOp)
{
	bool _retval = nativeCanvas->clipRegion(*nativeRegion, (SkRegion::Op)regionOp);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Canvas_saveLayerAlphaValues(SkCanvas* nativeCanvas, float l, float t, 
	float r, float b, int alpha, int layerFlags)
{
	int _retval = CanvasGlue::saveLayerAlphaValues(*nativeCanvas, l, t, r, b, alpha, 
		(SkCanvas::SaveFlags)layerFlags);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_concat(SkCanvas* nCanvas, MatrixGlue* nMatrix)
{
	nCanvas->concat(*nMatrix);
}

extern "C" DLL_EXPORT bool
libxobotos_Canvas_clipIRect(CanvasGlue* _instance, Rect_Struct* rect_ptr)
{
	const SkIRect* rect = Rect_Helper::wrapConst(rect_ptr);
	bool _retval = CanvasGlue::clipIRect(*_instance, *rect);
	delete rect;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Canvas_getCTM(SkCanvas* canvas, MatrixGlue* matrix)
{
	CanvasGlue::getCTM(*canvas, matrix);
}

