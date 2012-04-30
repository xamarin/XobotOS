#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <MaskFilterGlue.h>


extern "C" DLL_EXPORT SkMaskFilter*
libxobotos_TableMaskFilter_newClip(int min, int max)
{
	SkMaskFilter* _retval = MaskFilterGlue::Table_createClip(min, max);
	return _retval;
}

extern "C" DLL_EXPORT SkMaskFilter*
libxobotos_TableMaskFilter_newTable(Array_byte_Struct* table_ptr)
{
	const NativeArray<uint8_t>* table = Array_byte_Helper::wrapConst(table_ptr);
	SkMaskFilter* _retval = MaskFilterGlue::Table_create(*table);
	delete table;
	return _retval;
}

extern "C" DLL_EXPORT SkMaskFilter*
libxobotos_TableMaskFilter_newGamma(float gamma)
{
	SkMaskFilter* _retval = MaskFilterGlue::Table_createGamma(gamma);
	return _retval;
}

