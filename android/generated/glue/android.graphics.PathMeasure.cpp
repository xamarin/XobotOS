#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <PathMeasureGlue.h>
#include <PathGlue.h>
#include <MatrixGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_PathMeasure_destructor(PathMeasureGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT bool
libxobotos_PathMeasure_isClosed(PathMeasureGlue* native_instance)
{
	bool _retval = native_instance->isClosed();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_PathMeasure_getSegment(PathMeasureGlue* native_instance, float startD,
	float stopD, PathGlue* native_path, bool startWithMoveTo)
{
	bool _retval = native_instance->getSegment(startD, stopD, native_path, startWithMoveTo);
	return _retval;
}

extern "C" DLL_EXPORT PathMeasureGlue*
libxobotos_PathMeasure_create(PathGlue* native_path, bool forceClosed)
{
	PathMeasureGlue* _retval = PathMeasureGlue::create(native_path, forceClosed);
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_PathMeasure_getLength(PathMeasureGlue* native_instance)
{
	float _retval = native_instance->getLength();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_PathMeasure_setPath(PathMeasureGlue* native_instance, PathGlue* native_path,
	bool forceClosed)
{
	native_instance->setPath(native_path, forceClosed);
}

extern "C" DLL_EXPORT bool
libxobotos_PathMeasure_getPosTan(PathMeasureGlue* native_instance, float distance,
	Array_float_Struct* pos_ptr, Array_float_Struct* tan_ptr)
{
	NativeArray<float>* pos = Array_float_Helper::wrap(pos_ptr);
	NativeArray<float>* tan = Array_float_Helper::wrap(tan_ptr);
	bool _retval = native_instance->getPosTan(distance, pos, tan);
	delete pos;
	delete tan;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_PathMeasure_getMatrix(PathMeasureGlue* native_instance, float distance,
	MatrixGlue* native_matrix, int flags)
{
	bool _retval = native_instance->getMatrix(distance, native_matrix, (SkPathMeasure::MatrixFlags)
		flags);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_PathMeasure_isClosed_0(PathMeasureGlue* native_instance)
{
	bool _retval = native_instance->isClosed();
	return _retval;
}

