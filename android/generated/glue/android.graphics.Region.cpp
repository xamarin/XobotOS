#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <RegionGlue.h>
#include "android.graphics.Rect.h"
#include <PathGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Region_destructor(RegionGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT bool
libxobotos_Region_isComplex(RegionGlue* _instance)
{
	bool _retval = _instance->isComplex();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Region_translate(RegionGlue* _instance, int dx, int dy, RegionGlue* dst)
{
	_instance->translate(dx, dy, dst);
}

extern "C" DLL_EXPORT bool
libxobotos_Region_quickRejectRect(RegionGlue* _instance, int left, int top, int right,
	int bottom)
{
	bool _retval = _instance->quickRejectRect(left, top, right, bottom);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_contains(RegionGlue* _instance, int x, int y)
{
	bool _retval = _instance->contains(x, y);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_isEmpty(RegionGlue* _instance)
{
	bool _retval = _instance->isEmpty();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_recOp(RegionGlue* native_dst, int left, int top, int right, int
	 bottom, int op)
{
	bool _retval = native_dst->op(left, top, right, bottom, (SkRegion::Op)op);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_getBounds(RegionGlue* native_region, Rect_Struct* rect_ptr)
{
	SkIRect* rect = Rect_Helper::wrap(rect_ptr);
	bool _retval = native_region->getBounds(*rect);
	if (rect_ptr != NULL)
	{
		Rect_Helper::marshalOut(*rect, rect_ptr);
	}
	delete rect;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_getBoundaryPath(RegionGlue* native_region, PathGlue* native_path)
{
	bool _retval = native_region->getBoundaryPath(native_path);
	return _retval;
}

extern "C" DLL_EXPORT RegionGlue*
libxobotos_Region_constructor()
{
	RegionGlue* _retval = new RegionGlue();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_op(RegionGlue* native_dst, RegionGlue* native_region1, RegionGlue*
	 native_region2, int op)
{
	bool _retval = native_dst->op(*native_region1, *native_region2, (SkRegion::Op)op);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_quickContains(RegionGlue* _instance, int left, int top, int right,
	int bottom)
{
	bool _retval = _instance->quickContains(left, top, right, bottom);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_setRect(RegionGlue* native_dst, int left, int top, int right, int
	 bottom)
{
	bool _retval = native_dst->setRect(left, top, right, bottom);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Region_scale(RegionGlue* _instance, float scale, RegionGlue* dst)
{
	_instance->scale(scale, dst);
}

extern "C" DLL_EXPORT bool
libxobotos_Region_setPath(RegionGlue* native_dst, PathGlue* native_path, RegionGlue*
	 native_clip)
{
	bool _retval = native_dst->setPath(*native_path, *native_clip);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_rectOp(RegionGlue* native_dst, Rect_Struct* rect_ptr, RegionGlue*
	 native_region, int op)
{
	const SkIRect* rect = Rect_Helper::wrapConst(rect_ptr);
	bool _retval = native_dst->op(*rect, *native_region, (SkRegion::Op)op);
	delete rect;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_setRegion(RegionGlue* native_dst, RegionGlue* native_src)
{
	bool _retval = native_dst->setRegion(*native_src);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_quickReject(RegionGlue* _instance, RegionGlue* rgn)
{
	bool _retval = _instance->quickReject(*rgn);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_isRect(RegionGlue* _instance)
{
	bool _retval = _instance->isRect();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Region_equals(RegionGlue* native_r1, RegionGlue* native_r2)
{
	bool _retval = native_r1->equals(*native_r2);
	return _retval;
}

