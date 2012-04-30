#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <PathGlue.h>
#include "android.graphics.RectF.h"
#include <MatrixGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Path_destructor(PathGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT void
libxobotos_Path_arcTo(PathGlue* nPath, RectF_Struct* oval_ptr, float startAngle, 
	float sweepAngle, bool forceMoveTo)
{
	const SkRect* oval = RectF_Helper::wrapConst(oval_ptr);
	nPath->arcTo(*oval, startAngle, sweepAngle, forceMoveTo);
	delete oval;
}

extern "C" DLL_EXPORT void
libxobotos_Path_rLineTo(PathGlue* nPath, float dx, float dy)
{
	nPath->rLineTo(dx, dy);
}

extern "C" DLL_EXPORT void
libxobotos_Path_setLastPt(PathGlue* nPath, float dx, float dy)
{
	nPath->setLastPt(dx, dy);
}

extern "C" DLL_EXPORT void
libxobotos_Path_quadTo(PathGlue* nPath, float x1, float y1, float x2, float y2)
{
	nPath->quadTo(x1, y1, x2, y2);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addRect(PathGlue* nPath, RectF_Struct* rect_ptr, int dir)
{
	const SkRect* rect = RectF_Helper::wrapConst(rect_ptr);
	nPath->addRect(*rect, (SkPath::Direction)dir);
	delete rect;
}

extern "C" DLL_EXPORT bool
libxobotos_Path_isEmpty(PathGlue* nPath)
{
	bool _retval = nPath->isEmpty();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Path_transform(PathGlue* nPath, MatrixGlue* matrix, PathGlue* dst_path)
{
	nPath->transform(*matrix, dst_path);
}

extern "C" DLL_EXPORT void
libxobotos_Path_setFillType(PathGlue* nPath, int ft)
{
	nPath->setFillType((SkPath::FillType)ft);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addRect_0(PathGlue* nPath, float left, float top, float right, float
	 bottom, int dir)
{
	nPath->addRect(left, top, right, bottom, (SkPath::Direction)dir);
}

extern "C" DLL_EXPORT void
libxobotos_Path_rMoveTo(PathGlue* nPath, float dx, float dy)
{
	nPath->rMoveTo(dx, dy);
}

extern "C" DLL_EXPORT PathGlue*
libxobotos_Path_init2(PathGlue* nPath)
{
	PathGlue* _retval = new PathGlue(*nPath);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Path_rCubicTo(PathGlue* nPath, float x1, float y1, float x2, float y2,
	float x3, float y3)
{
	nPath->rCubicTo(x1, y1, x2, y2, x3, y3);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addPath(PathGlue* nPath, PathGlue* src, float dx, float dy)
{
	nPath->addPath(*src, dx, dy);
}

extern "C" DLL_EXPORT void
libxobotos_Path_offset(PathGlue* nPath, float dx, float dy, PathGlue* dst_path)
{
	nPath->offset(dx, dy, dst_path);
}

extern "C" DLL_EXPORT void
libxobotos_Path_getBounds(PathGlue* nPath, RectF_Struct** bounds_ptr)
{
	SkRect bounds;
	nPath->getBounds(&bounds);
	*bounds_ptr = RectF_Helper::unwrap(&bounds);
}

extern "C" DLL_EXPORT int
libxobotos_Path_getFillType(PathGlue* nPath)
{
	int _retval = nPath->getFillType();
	return _retval;
}

extern "C" DLL_EXPORT PathGlue*
libxobotos_Path_init1()
{
	PathGlue* _retval = new PathGlue();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Path_addOval(PathGlue* nPath, RectF_Struct* oval_ptr, int dir)
{
	const SkRect* oval = RectF_Helper::wrapConst(oval_ptr);
	nPath->addOval(*oval, (SkPath::Direction)dir);
	delete oval;
}

extern "C" DLL_EXPORT void
libxobotos_Path_addCircle(PathGlue* nPath, float x, float y, float radius, int dir)
{
	nPath->addCircle(x, y, radius, (SkPath::Direction)dir);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addRoundRect_0(PathGlue* nPath, RectF_Struct* r_ptr, Array_float_Struct*
	 radii_ptr, int dir)
{
	const SkRect* r = RectF_Helper::wrapConst(r_ptr);
	const NativeArray<float>* radii = Array_float_Helper::wrapConst(radii_ptr);
	nPath->addRoundRect(*r, *radii, (SkPath::Direction)dir);
	delete r;
	delete radii;
}

extern "C" DLL_EXPORT void
libxobotos_Path_transform_0(PathGlue* nPath, MatrixGlue* matrix)
{
	nPath->transform(*matrix);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addRoundRect(PathGlue* nPath, RectF_Struct* rect_ptr, float rx, float
	 ry, int dir)
{
	const SkRect* rect = RectF_Helper::wrapConst(rect_ptr);
	nPath->addRoundRect(*rect, rx, ry, (SkPath::Direction)dir);
	delete rect;
}

extern "C" DLL_EXPORT void
libxobotos_Path_moveTo(PathGlue* nPath, float x, float y)
{
	nPath->moveTo(x, y);
}

extern "C" DLL_EXPORT void
libxobotos_Path_close(PathGlue* nPath)
{
	nPath->close();
}

extern "C" DLL_EXPORT void
libxobotos_Path_rQuadTo(PathGlue* nPath, float dx1, float dy1, float dx2, float dy2)
{
	nPath->rQuadTo(dx1, dy1, dx2, dy2);
}

extern "C" DLL_EXPORT void
libxobotos_Path_cubicTo(PathGlue* nPath, float x1, float y1, float x2, float y2, 
	float x3, float y3)
{
	nPath->cubicTo(x1, y1, x2, y2, x3, y3);
}

extern "C" DLL_EXPORT void
libxobotos_Path_lineTo(PathGlue* nPath, float x, float y)
{
	nPath->lineTo(x, y);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addPath_0(PathGlue* nPath, PathGlue* src)
{
	nPath->addPath(*src);
}

extern "C" DLL_EXPORT void
libxobotos_Path_incReserve(PathGlue* nPath, int extraPtCount)
{
	nPath->incReserve(extraPtCount);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addPath_1(PathGlue* nPath, PathGlue* src, MatrixGlue* matrix)
{
	nPath->addPath(*src, *matrix);
}

extern "C" DLL_EXPORT void
libxobotos_Path_addArc(PathGlue* nPath, RectF_Struct* oval_ptr, float startAngle,
	float sweepAngle)
{
	const SkRect* oval = RectF_Helper::wrapConst(oval_ptr);
	nPath->addArc(*oval, startAngle, sweepAngle);
	delete oval;
}

extern "C" DLL_EXPORT void
libxobotos_Path_set(PathGlue* native_dst, PathGlue* native_src)
{
	native_dst->set(*native_src);
}

extern "C" DLL_EXPORT void
libxobotos_Path_offset_0(PathGlue* nPath, float dx, float dy)
{
	nPath->offset(dx, dy);
}

extern "C" DLL_EXPORT void
libxobotos_Path_rewind(PathGlue* nPath)
{
	nPath->rewind();
}

extern "C" DLL_EXPORT void
libxobotos_Path_reset(PathGlue* nPath)
{
	nPath->reset();
}

extern "C" DLL_EXPORT bool
libxobotos_Path_isRect(PathGlue* nPath, RectF_Struct* rect_ptr)
{
	SkRect* rect = RectF_Helper::wrap(rect_ptr);
	bool _retval = nPath->isRect(rect);
	if (rect_ptr != NULL)
	{
		RectF_Helper::marshalOut(*rect, rect_ptr);
	}
	delete rect;
	return _retval;
}

