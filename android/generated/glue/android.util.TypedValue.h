#ifndef ANDROID_UTIL_TYPEDVALUE_GLUE_H
#define ANDROID_UTIL_TYPEDVALUE_GLUE_H 1

#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <AssetManagerGlue.h>

struct TypedValue_Struct;

class TypedValue_Helper
{
public:
	static void unwrap(AssetManagerGlue::TypedValue& from, TypedValue_Struct* to);
	static TypedValue_Struct* unwrap(AssetManagerGlue::TypedValue* src);
	static void marshalOut(const AssetManagerGlue::TypedValue& from, TypedValue_Struct*
		 to);
	static void wrap(const TypedValue_Struct& from, AssetManagerGlue::TypedValue* to);
	static AssetManagerGlue::TypedValue* wrap(const TypedValue_Struct* src);
	static const AssetManagerGlue::TypedValue* wrapConst(const TypedValue_Struct* src);
	static void freeMembers(TypedValue_Struct& obj);
	static void destructor(TypedValue_Struct* obj);

private:
	TypedValue_Helper();

};



#endif
