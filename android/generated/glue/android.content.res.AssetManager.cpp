#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <AssetManagerGlue.h>
#include "android.util.TypedValue.h"

extern "C" DLL_EXPORT void
libxobotos_android_content_res_AssetManager_destructor(AssetManagerGlue* ptr)
{
	delete ptr;
}

extern "C" DLL_EXPORT void
libxobotos_android_content_res_AssetManager_AssetInputStream_destructor(android::Asset*
	 ptr)
{
	delete ptr;
}

struct Array_String_Struct
{
	uint32_t _owner;
	uint32_t length;
	String_Struct** ptr;
};

class Array_String_Helper
{
public:
	static void
	unwrap(NativePtrArray<NativeString>& from, Array_String_Struct* to)
	{
		to->_owner = 0x7380548b;
		to->length = from.length();
		{
			to->ptr = MarshalHelper::allocArray<String_Struct*>(from.length());
			for(uint32_t i = 0; i < from.length(); i++)
			{
				to->ptr[i] = String_Helper::unwrap(from.item(i));
			}
		}
	}

	static Array_String_Struct*
	unwrap(NativePtrArray<NativeString>* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		Array_String_Struct* retval = new Array_String_Struct();
		Array_String_Helper::unwrap(*src, retval);
		return retval;
	}

	static void
	marshalOut(const NativePtrArray<NativeString>& from, Array_String_Struct* to)
	{
		assert(from.length() == to->length);
		assert(false);
	}

	static void
	wrap(const Array_String_Struct& from, NativePtrArray<NativeString>* to)
	{
		assert(from.length == to->length());
		for(uint32_t i = 0; i < from.length; i++)
		{
			to->item(i) = String_Helper::wrap(from.ptr[i]);
		}
	}

	static NativePtrArray<NativeString>*
	wrap(const Array_String_Struct* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		NativePtrArray<NativeString>* retval = new NativePtrArray<NativeString>(src->length);
		Array_String_Helper::wrap(*src, retval);
		return retval;
	}

	static const NativePtrArray<NativeString>*
	wrapConst(const Array_String_Struct* src)
	{
		return const_cast<const NativePtrArray<NativeString>*>(Array_String_Helper::wrap(
			src));
	}

	static void
	freeMembers(Array_String_Struct& obj)
	{
		assert(obj._owner == 0x7380548b);
		{
			for(uint32_t i = 0; i < obj.length; i++)
			{
				String_Helper::destructor(obj.ptr[i]);
			}
			MarshalHelper::freeArray<String_Struct*>(obj.ptr, obj.length);
		}
	}

	static void
	destructor(Array_String_Struct* obj)
	{
		if (obj == NULL)
		{
			return;
		}
		Array_String_Helper::freeMembers(*obj);
		delete obj;
	}


private:
	Array_String_Helper();

};

extern "C" DLL_EXPORT void
libxobotos_android_content_res_AssetManager_Array_String_destructor(Array_String_Struct*
	 obj)
{
	Array_String_Helper::destructor(obj);
}


extern "C" DLL_EXPORT bool
libxobotos_AssetManager_retrieveAttributes(AssetManagerGlue* _instance, AssetManagerGlue::XmlParser*
	 xmlParser, Array_int_Struct* inAttrs_ptr, Array_int_Struct* outValues_ptr, Array_int_Struct*
	 outIndices_ptr)
{
	const NativeArray<int>* inAttrs = Array_int_Helper::wrapConst(inAttrs_ptr);
	NativeArray<int>* outValues = Array_int_Helper::wrap(outValues_ptr);
	NativeArray<int>* outIndices = Array_int_Helper::wrap(outIndices_ptr);
	bool _retval = _instance->retrieveAttributes(*xmlParser, *inAttrs, outValues, outIndices);
	delete inAttrs;
	delete outValues;
	delete outIndices;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_getArraySize(AssetManagerGlue* _instance, int resource)
{
	int _retval = _instance->getArraySize(resource);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_getStringBlockCount(AssetManagerGlue* _instance)
{
	int _retval = _instance->getStringBlockCount();
	return _retval;
}

extern "C" DLL_EXPORT AssetManagerGlue::StringBlock*
libxobotos_AssetManager_getNativeStringBlock(AssetManagerGlue* _instance, int block)
{
	AssetManagerGlue::StringBlock* _retval = _instance->getNativeStringBlock(block);
	return _retval;
}

extern "C" DLL_EXPORT Array_int_Struct*
libxobotos_AssetManager_getArrayStringInfo(AssetManagerGlue* _instance, int arrayRes)
{
	NativeArray<int>* _returnObj = _instance->getArrayStringInfo(arrayRes);
	Array_int_Struct* _retval = Array_int_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT String_Struct*
libxobotos_AssetManager_getResourcePackageName(AssetManagerGlue* _instance, int resid)
{
	NativeString* _returnObj = _instance->getResourcePackageName(resid);
	String_Struct* _retval = String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_retrieveArray(AssetManagerGlue* _instance, int resource, 
	Array_int_Struct* outValues_ptr)
{
	NativeArray<int>* outValues = Array_int_Helper::wrap(outValues_ptr);
	int _retval = _instance->retrieveArray(resource, *outValues);
	delete outValues;
	return _retval;
}

extern "C" DLL_EXPORT AssetManagerGlue::XmlBlock*
libxobotos_AssetManager_openXmlAssetNative(AssetManagerGlue* _instance, int cookie,
	String_Struct* fileName_ptr)
{
	const NativeString* fileName = String_Helper::wrapConst(fileName_ptr);
	AssetManagerGlue::XmlBlock* _retval = _instance->openXmlAssetNative(cookie, *fileName);
	delete fileName;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_readAsset(android::Asset* asset, Array_byte_Struct* b_ptr,
	int off, int len)
{
	NativeArray<uint8_t>* b = Array_byte_Helper::wrap(b_ptr);
	int _retval = AssetManagerGlue::readAsset(*asset, *b, off, len);
	delete b;
	return _retval;
}

extern "C" DLL_EXPORT long
libxobotos_AssetManager_seekAsset(android::Asset* asset, long offset, int whence)
{
	long _retval = AssetManagerGlue::seekAsset(*asset, offset, whence);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_AssetManager_applyStyle(AssetManagerGlue::Theme* theme, int defStyleAttr,
	int defStyleRes, AssetManagerGlue::XmlParser* xmlParser, Array_int_Struct* inAttrs_ptr,
	Array_int_Struct* outValues_ptr, Array_int_Struct* outIndices_ptr)
{
	const NativeArray<int>* inAttrs = Array_int_Helper::wrapConst(inAttrs_ptr);
	NativeArray<int>* outValues = Array_int_Helper::wrap(outValues_ptr);
	NativeArray<int>* outIndices = Array_int_Helper::wrap(outIndices_ptr);
	bool _retval = theme->applyStyle(defStyleAttr, defStyleRes, xmlParser, inAttrs, outValues,
		outIndices);
	delete inAttrs;
	delete outValues;
	delete outIndices;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_AssetManager_copyTheme(AssetManagerGlue::Theme* dest, AssetManagerGlue::Theme*
	 source)
{
	dest->copyTheme(*source);
}

extern "C" DLL_EXPORT Array_int_Struct*
libxobotos_AssetManager_getArrayIntResource(AssetManagerGlue* _instance, int arrayRes)
{
	NativeArray<int>* _returnObj = _instance->getArrayIntResource(arrayRes);
	Array_int_Struct* _retval = Array_int_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT android::Asset*
libxobotos_AssetManager_openNonAssetNative(AssetManagerGlue* _instance, int cookie,
	String_Struct* fileName_ptr, int accessMode)
{
	const NativeString* fileName = String_Helper::wrapConst(fileName_ptr);
	android::Asset* _retval = _instance->openNonAssetNative(cookie, *fileName, (android::Asset::AccessMode)
		accessMode);
	delete fileName;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_loadResourceValue(AssetManagerGlue* _instance, int ident,
	short density, TypedValue_Struct** outValue_ptr, bool resolve)
{
	AssetManagerGlue::TypedValue outValue;
	int _retval = _instance->loadResourceValue(ident, density, &outValue, resolve);
	*outValue_ptr = TypedValue_Helper::unwrap(&outValue);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_AssetManager_applyThemeStyle(AssetManagerGlue::Theme* theme, int styleRes,
	bool force)
{
	theme->applyThemeStyle(styleRes, force);
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_getResourceIdentifier(AssetManagerGlue* _instance, String_Struct*
	 type_ptr, String_Struct* name_ptr, String_Struct* defPackage_ptr)
{
	const NativeString* type = String_Helper::wrapConst(type_ptr);
	const NativeString* name = String_Helper::wrapConst(name_ptr);
	const NativeString* defPackage = String_Helper::wrapConst(defPackage_ptr);
	int _retval = _instance->getResourceIdentifier(*type, name, defPackage);
	delete type;
	delete name;
	delete defPackage;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_AssetManager_setConfiguration(AssetManagerGlue* _instance, int mcc, int
	 mnc, String_Struct* locale_ptr, int orientation, int touchscreen, int density, 
	int keyboard, int keyboardHidden, int navigation, int screenWidth, int screenHeight,
	int smallestScreenWidthDp, int screenWidthDp, int screenHeightDp, int screenLayout,
	int uiMode, int majorVersion)
{
	const NativeString* locale = String_Helper::wrapConst(locale_ptr);
	_instance->setConfiguration(mcc, mnc, locale, orientation, touchscreen, density, 
		keyboard, keyboardHidden, navigation, screenWidth, screenHeight, smallestScreenWidthDp,
		screenWidthDp, screenHeightDp, screenLayout, uiMode, majorVersion);
	delete locale;
}

extern "C" DLL_EXPORT long
libxobotos_AssetManager_getAssetLength(android::Asset* asset)
{
	long _retval = AssetManagerGlue::getAssetLength(*asset);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_readAssetChar(android::Asset* asset)
{
	int _retval = AssetManagerGlue::readAssetChar(*asset);
	return _retval;
}

extern "C" DLL_EXPORT String_Struct*
libxobotos_AssetManager_getResourceEntryName(AssetManagerGlue* _instance, int resid)
{
	NativeString* _returnObj = _instance->getResourceEntryName(resid);
	String_Struct* _retval = String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT AssetManagerGlue::Theme*
libxobotos_AssetManager_newTheme(AssetManagerGlue* _instance)
{
	AssetManagerGlue::Theme* _retval = _instance->newTheme();
	return _retval;
}

extern "C" DLL_EXPORT long
libxobotos_AssetManager_getAssetRemainingLength(android::Asset* asset)
{
	long _retval = AssetManagerGlue::getAssetRemainingLength(*asset);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_addAssetPath(AssetManagerGlue* _instance, String_Struct* 
	path_ptr)
{
	const NativeString* path = String_Helper::wrapConst(path_ptr);
	int _retval = _instance->addAssetPath(*path);
	delete path;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_AssetManager_loadThemeAttributeValue(AssetManagerGlue::Theme* theme, int
	 ident, TypedValue_Struct** outValue_ptr, bool resolve)
{
	AssetManagerGlue::TypedValue outValue;
	int _retval = theme->loadThemeAttributeValue(ident, &outValue, resolve);
	*outValue_ptr = TypedValue_Helper::unwrap(&outValue);
	return _retval;
}

extern "C" DLL_EXPORT String_Struct*
libxobotos_AssetManager_getResourceName(AssetManagerGlue* _instance, int resid)
{
	NativeString* _returnObj = _instance->getResourceName(resid);
	String_Struct* _retval = String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT AssetManagerGlue*
libxobotos_AssetManager_init()
{
	AssetManagerGlue* _retval = new AssetManagerGlue();
	return _retval;
}

extern "C" DLL_EXPORT String_Struct*
libxobotos_AssetManager_getResourceTypeName(AssetManagerGlue* _instance, int resid)
{
	NativeString* _returnObj = _instance->getResourceTypeName(resid);
	String_Struct* _retval = String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT Array_String_Struct*
libxobotos_AssetManager_getArrayStringResource(AssetManagerGlue* _instance, int arrayRes)
{
	NativePtrArray<NativeString>* _returnObj = _instance->getArrayStringResource(arrayRes);
	Array_String_Struct* _retval = Array_String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

