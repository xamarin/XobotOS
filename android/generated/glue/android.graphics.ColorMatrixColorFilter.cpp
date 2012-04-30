#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ColorFilterGlue.h>


extern "C" DLL_EXPORT const void*
libxobotos_ColorMatrixColorFilter_ColorMatrixFilter_postCreate(SkColorFilter* nativeFilter,
	Array_float_Struct* array_ptr)
{
	const NativeArray<float>* array = Array_float_Helper::wrapConst(array_ptr);
	const void* _retval = ColorFilterGlue::ColorMatrixFilter_postCreate(nativeFilter,
		*array);
	delete array;
	return _retval;
}

extern "C" DLL_EXPORT SkColorFilter*
libxobotos_ColorMatrixColorFilter_ColorMatrixFilter_create(Array_float_Struct* array_ptr)
{
	const NativeArray<float>* array = Array_float_Helper::wrapConst(array_ptr);
	SkColorFilter* _retval = ColorFilterGlue::ColorMatrixFilter_create(*array);
	delete array;
	return _retval;
}

