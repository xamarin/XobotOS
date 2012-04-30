#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <AssetManagerGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_content_res_StringBlock_destructor(AssetManagerGlue::StringBlock*
	 ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT Array_int_Struct*
libxobotos_StringBlock_nativeGetStyle(AssetManagerGlue::StringBlock* obj, int idx)
{
	NativeArray<int>* _returnObj = obj->nativeGetStyle(idx);
	Array_int_Struct* _retval = Array_int_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT String_Struct*
libxobotos_StringBlock_nativeGetString(AssetManagerGlue::StringBlock* obj, int idx)
{
	NativeString* _returnObj = obj->nativeGetString(idx);
	String_Struct* _retval = String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_StringBlock_nativeGetSize(AssetManagerGlue::StringBlock* obj)
{
	int _retval = obj->nativeGetSize();
	return _retval;
}

