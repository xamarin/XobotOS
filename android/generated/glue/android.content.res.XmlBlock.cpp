#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <AssetManagerGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_content_res_XmlBlock_destructor(AssetManagerGlue::XmlBlock* ptr)
{
	delete ptr;
}

extern "C" DLL_EXPORT void
libxobotos_android_content_res_XmlBlock_Parser_destructor(AssetManagerGlue::XmlParser*
	 ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT AssetManagerGlue::XmlParser*
libxobotos_XmlBlock_nativeCreateParseState(AssetManagerGlue::XmlBlock* obj)
{
	AssetManagerGlue::XmlParser* _retval = obj->nativeCreateParseState();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getElementNameID(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->getElementNameID();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getAttributeValueStringID(AssetManagerGlue::XmlParser* state,
	int idx)
{
	int _retval = state->getAttributeValueStringID(idx);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_nativeGetIdAttribute(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->nativeGetIdAttribute();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getAttributeData(AssetManagerGlue::XmlParser* state, int idx)
{
	int _retval = state->getAttributeData(idx);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_nativeGetStyleAttribute(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->nativeGetStyleAttribute();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getElementNamespaceID(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->getElementNamespaceID();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getAttributeNamespaceID(AssetManagerGlue::XmlParser* state, int
	 idx)
{
	int _retval = state->getAttributeNamespaceID(idx);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_nativeGetClassAttribute(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->nativeGetClassAttribute();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getLineNumber(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->getLineNumber();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getAttributeCount(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->getAttributeCount();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_nativeGetAttributeIndex(AssetManagerGlue::XmlParser* state, String_Struct*
	 _namespace_ptr, String_Struct* name_ptr)
{
	const NativeString* _namespace = String_Helper::wrapConst(_namespace_ptr);
	const NativeString* name = String_Helper::wrapConst(name_ptr);
	int _retval = state->nativeGetAttributeIndex(_namespace, *name);
	delete _namespace;
	delete name;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getTextID(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->getTextID();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getAttributeNameID(AssetManagerGlue::XmlParser* state, int idx)
{
	int _retval = state->getAttributeNameID(idx);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getAttributeNameResID(AssetManagerGlue::XmlParser* state, int
	 idx)
{
	int _retval = state->getAttributeNameResID(idx);
	return _retval;
}

extern "C" DLL_EXPORT AssetManagerGlue::StringBlock*
libxobotos_XmlBlock_nativeGetStringBlock(AssetManagerGlue::XmlBlock* obj)
{
	AssetManagerGlue::StringBlock* _retval = obj->nativeGetStringBlock();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_nativeNext(AssetManagerGlue::XmlParser* state)
{
	int _retval = state->nativeNext();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_XmlBlock_getAttributeDataType(AssetManagerGlue::XmlParser* state, int 
	idx)
{
	int _retval = state->getAttributeDataType(idx);
	return _retval;
}

