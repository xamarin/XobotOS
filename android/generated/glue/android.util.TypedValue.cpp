#include "android.util.TypedValue.h"

struct TypedValue_Struct
{
	uint32_t _owner;
	int mType;
	int mData;
	int mAssetCookie;
	int mResourceId;
	int mDensity;
};

void
TypedValue_Helper::unwrap(AssetManagerGlue::TypedValue& from, TypedValue_Struct* 
	to)
{
	to->_owner = 0x7380548b;
	to->mType = from.mType;
	to->mData = from.mData;
	to->mAssetCookie = from.mAssetCookie;
	to->mResourceId = from.mResourceId;
	to->mDensity = from.mDensity;
}

TypedValue_Struct*
TypedValue_Helper::unwrap(AssetManagerGlue::TypedValue* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	TypedValue_Struct* retval = new TypedValue_Struct();
	TypedValue_Helper::unwrap(*src, retval);
	return retval;
}

void
TypedValue_Helper::marshalOut(const AssetManagerGlue::TypedValue& from, TypedValue_Struct*
	 to)
{
	to->mType = from.mType;
	to->mData = from.mData;
	to->mAssetCookie = from.mAssetCookie;
	to->mResourceId = from.mResourceId;
	to->mDensity = from.mDensity;
}

void
TypedValue_Helper::wrap(const TypedValue_Struct& from, AssetManagerGlue::TypedValue*
	 to)
{
	to->mType = from.mType;
	to->mData = from.mData;
	to->mAssetCookie = from.mAssetCookie;
	to->mResourceId = from.mResourceId;
	to->mDensity = from.mDensity;
}

AssetManagerGlue::TypedValue*
TypedValue_Helper::wrap(const TypedValue_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	AssetManagerGlue::TypedValue* retval = new AssetManagerGlue::TypedValue();
	TypedValue_Helper::wrap(*src, retval);
	return retval;
}

const AssetManagerGlue::TypedValue*
TypedValue_Helper::wrapConst(const TypedValue_Struct* src)
{
	return const_cast<const AssetManagerGlue::TypedValue*>(TypedValue_Helper::wrap(src));
}

void
TypedValue_Helper::freeMembers(TypedValue_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
TypedValue_Helper::destructor(TypedValue_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	TypedValue_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_util_TypedValue_TypedValue_destructor(TypedValue_Struct* obj)
{
	TypedValue_Helper::destructor(obj);
}


