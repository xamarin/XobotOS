#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <MatrixGlue.h>
#include "android.graphics.RectF.h"

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Matrix_destructor(MatrixGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT bool
libxobotos_Matrix_postSkew(MatrixGlue* native_object, float kx, float ky, float px,
	float py)
{
	bool _retval = native_object->postSkew(kx, ky, px, py);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setValues(MatrixGlue* native_object, Array_float_Struct* values_ptr)
{
	const NativeArray<float>* values = Array_float_Helper::wrapConst(values_ptr);
	native_object->setValues(*values);
	delete values;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_mapRect(MatrixGlue* native_object, RectF_Struct* dst_ptr, RectF_Struct*
	 src_ptr)
{
	SkRect* dst = RectF_Helper::wrap(dst_ptr);
	const SkRect* src = RectF_Helper::wrapConst(src_ptr);
	bool _retval = native_object->mapRect(*dst, *src);
	if (dst_ptr != NULL)
	{
		RectF_Helper::marshalOut(*dst, dst_ptr);
	}
	delete dst;
	delete src;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_postSkew_0(MatrixGlue* native_object, float kx, float ky)
{
	bool _retval = native_object->postSkew(kx, ky);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_getValues(MatrixGlue* native_object, Array_float_Struct* values_ptr)
{
	NativeArray<float>* values = Array_float_Helper::wrap(values_ptr);
	native_object->getValues(*values);
	delete values;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preRotate(MatrixGlue* native_object, float degrees, float px, float
	 py)
{
	bool _retval = native_object->preRotate(degrees, px, py);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_postScale_0(MatrixGlue* native_object, float sx, float sy)
{
	bool _retval = native_object->postScale(sx, sy);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_equals(MatrixGlue* native_a, MatrixGlue* native_b)
{
	bool _retval = MatrixGlue::equals(*native_a, *native_b);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setRotate(MatrixGlue* native_object, float degrees, float px, float
	 py)
{
	native_object->setRotate(degrees, px, py);
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_postRotate(MatrixGlue* native_object, float degrees, float px, 
	float py)
{
	bool _retval = native_object->postRotate(degrees, px, py);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_mapPoints(MatrixGlue* native_object, Array_float_Struct* dst_ptr,
	int dstIndex, Array_float_Struct* src_ptr, int srcIndex, int ptCount, bool isPts)
{
	NativeArray<float>* dst = Array_float_Helper::wrap(dst_ptr);
	const NativeArray<float>* src = Array_float_Helper::wrapConst(src_ptr);
	native_object->mapPoints(*dst, dstIndex, *src, srcIndex, ptCount, isPts);
	delete dst;
	delete src;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preSkew(MatrixGlue* native_object, float kx, float ky, float px,
	float py)
{
	bool _retval = native_object->preSkew(kx, ky, px, py);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setRotate_0(MatrixGlue* native_object, float degrees)
{
	native_object->setRotate(degrees);
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_postScale(MatrixGlue* native_object, float sx, float sy, float 
	px, float py)
{
	bool _retval = native_object->postScale(sx, sy, px, py);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_invert(MatrixGlue* native_object, MatrixGlue* inverse)
{
	bool _retval = native_object->invert(inverse);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preScale_0(MatrixGlue* native_object, float sx, float sy)
{
	bool _retval = native_object->preScale(sx, sy);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_postRotate_0(MatrixGlue* native_object, float degrees)
{
	bool _retval = native_object->postRotate(degrees);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preRotate_0(MatrixGlue* native_object, float degrees)
{
	bool _retval = native_object->preRotate(degrees);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setSinCos_0(MatrixGlue* native_object, float sinValue, float cosValue)
{
	native_object->setSinCos(sinValue, cosValue);
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setScale(MatrixGlue* native_object, float sx, float sy, float px,
	float py)
{
	native_object->setScale(sx, sy, px, py);
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preTranslate(MatrixGlue* native_object, float dx, float dy)
{
	bool _retval = native_object->preTranslate(dx, dy);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_reset(MatrixGlue* native_object)
{
	native_object->reset();
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setSinCos(MatrixGlue* native_object, float sinValue, float cosValue,
	float px, float py)
{
	native_object->setSinCos(sinValue, cosValue, px, py);
}

extern "C" DLL_EXPORT float
libxobotos_Matrix_mapRadius(MatrixGlue* native_object, float radius)
{
	float _retval = native_object->mapRadius(radius);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_set(MatrixGlue* native_object, MatrixGlue* other)
{
	native_object->set(*other);
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_isIdentity(MatrixGlue* native_object)
{
	bool _retval = native_object->isIdentity();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setScale_0(MatrixGlue* native_object, float sx, float sy)
{
	native_object->setScale(sx, sy);
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_postTranslate(MatrixGlue* native_object, float dx, float dy)
{
	bool _retval = native_object->postTranslate(dx, dy);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setSkew(MatrixGlue* native_object, float kx, float ky, float px,
	float py)
{
	native_object->setSkew(kx, ky, px, py);
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setTranslate(MatrixGlue* native_object, float dx, float dy)
{
	native_object->setTranslate(dx, dy);
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_postConcat(MatrixGlue* native_object, MatrixGlue* other_matrix)
{
	bool _retval = native_object->postConcat(*other_matrix);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_setConcat(MatrixGlue* native_object, MatrixGlue* a, MatrixGlue*
	 b)
{
	bool _retval = native_object->setConcat(*a, *b);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matrix_setSkew_0(MatrixGlue* native_object, float kx, float ky)
{
	native_object->setSkew(kx, ky);
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preScale(MatrixGlue* native_object, float sx, float sy, float px,
	float py)
{
	bool _retval = native_object->preScale(sx, sy, px, py);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_setRectToRect(MatrixGlue* native_object, RectF_Struct* src_ptr,
	RectF_Struct* dst_ptr, int stf)
{
	const SkRect* src = RectF_Helper::wrapConst(src_ptr);
	const SkRect* dst = RectF_Helper::wrapConst(dst_ptr);
	bool _retval = native_object->setRectToRect(*src, *dst, (SkMatrix::ScaleToFit)stf);
	delete src;
	delete dst;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preConcat(MatrixGlue* native_object, MatrixGlue* other_matrix)
{
	bool _retval = native_object->preConcat(*other_matrix);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_rectStaysRect(MatrixGlue* native_object)
{
	bool _retval = native_object->rectStaysRect();
	return _retval;
}

extern "C" DLL_EXPORT MatrixGlue*
libxobotos_Matrix_constructor(MatrixGlue* native_src_or_zero)
{
	MatrixGlue* _retval = new MatrixGlue(native_src_or_zero);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_preSkew_0(MatrixGlue* native_object, float kx, float ky)
{
	bool _retval = native_object->preSkew(kx, ky);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matrix_setPolyToPoly(MatrixGlue* native_object, Array_float_Struct* src_ptr,
	int srcIndex, Array_float_Struct* dst_ptr, int dstIndex, int pointCount)
{
	const NativeArray<float>* src = Array_float_Helper::wrapConst(src_ptr);
	const NativeArray<float>* dst = Array_float_Helper::wrapConst(dst_ptr);
	bool _retval = native_object->setPolyToPoly(*src, srcIndex, *dst, dstIndex, pointCount);
	delete src;
	delete dst;
	return _retval;
}

