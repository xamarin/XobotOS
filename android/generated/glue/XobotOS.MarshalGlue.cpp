#include "XobotOS.MarshalGlue.h"

struct String_Struct
{
	uint32_t _owner;
	uint32_t length;
	char16_t* ptr;
};

void
String_Helper::unwrap(NativeString& from, String_Struct* to)
{
	to->_owner = 0x7380548b;
	to->length = from.length();
	to->ptr = from.takeOwnership();
}

String_Struct*
String_Helper::unwrap(NativeString* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	String_Struct* retval = new String_Struct();
	String_Helper::unwrap(*src, retval);
	return retval;
}

void
String_Helper::marshalOut(const NativeString& from, String_Struct* to)
{
	assert(false);
}

void
String_Helper::wrap(const String_Struct& from, NativeString* to)
{
}

NativeString*
String_Helper::wrap(const String_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	NativeString* retval = new NativeString(src->length, src->ptr);
	String_Helper::wrap(*src, retval);
	return retval;
}

const NativeString*
String_Helper::wrapConst(const String_Struct* src)
{
	return const_cast<const NativeString*>(String_Helper::wrap(src));
}

void
String_Helper::freeMembers(String_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	MarshalHelper::freeArray<char16_t>(obj.ptr, obj.length);
}

void
String_Helper::destructor(String_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	String_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_XobotOS_MarshalGlue_String_destructor(String_Struct* obj)
{
	String_Helper::destructor(obj);
}

struct Array_char_Struct
{
	uint32_t _owner;
	uint32_t length;
	char16_t* ptr;
};

void
Array_char_Helper::unwrap(NativeArray<char16_t>& from, Array_char_Struct* to)
{
	to->_owner = 0x7380548b;
	to->length = from.length();
	to->ptr = from.takeOwnership();
}

Array_char_Struct*
Array_char_Helper::unwrap(NativeArray<char16_t>* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Array_char_Struct* retval = new Array_char_Struct();
	Array_char_Helper::unwrap(*src, retval);
	return retval;
}

void
Array_char_Helper::marshalOut(const NativeArray<char16_t>& from, Array_char_Struct*
	 to)
{
	assert(from.length() == to->length);
	assert(false);
}

NativeArray<char16_t>*
Array_char_Helper::wrap(const Array_char_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	return new NativeArray<char16_t>(src->length, src->ptr);
}

void
Array_char_Helper::wrap(const Array_char_Struct& from, NativeArray<char16_t>* to)
{
	assert(from.length == to->length());
	for(uint32_t i = 0; i < from.length; i++)
	{
		to->item(i) = from.ptr[i];
	}
}

const NativeArray<char16_t>*
Array_char_Helper::wrapConst(const Array_char_Struct* src)
{
	return const_cast<const NativeArray<char16_t>*>(Array_char_Helper::wrap(src));
}

void
Array_char_Helper::freeMembers(Array_char_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	MarshalHelper::freeArray<char16_t>(obj.ptr, obj.length);
}

void
Array_char_Helper::destructor(Array_char_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Array_char_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_XobotOS_MarshalGlue_Array_char_destructor(Array_char_Struct* obj)
{
	Array_char_Helper::destructor(obj);
}

struct Array_byte_Struct
{
	uint32_t _owner;
	uint32_t length;
	uint8_t* ptr;
};

void
Array_byte_Helper::unwrap(NativeArray<uint8_t>& from, Array_byte_Struct* to)
{
	to->_owner = 0x7380548b;
	to->length = from.length();
	to->ptr = from.takeOwnership();
}

Array_byte_Struct*
Array_byte_Helper::unwrap(NativeArray<uint8_t>* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Array_byte_Struct* retval = new Array_byte_Struct();
	Array_byte_Helper::unwrap(*src, retval);
	return retval;
}

void
Array_byte_Helper::marshalOut(const NativeArray<uint8_t>& from, Array_byte_Struct*
	 to)
{
	assert(from.length() == to->length);
	assert(false);
}

NativeArray<uint8_t>*
Array_byte_Helper::wrap(const Array_byte_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	return new NativeArray<uint8_t>(src->length, src->ptr);
}

void
Array_byte_Helper::wrap(const Array_byte_Struct& from, NativeArray<uint8_t>* to)
{
	assert(from.length == to->length());
	for(uint32_t i = 0; i < from.length; i++)
	{
		to->item(i) = from.ptr[i];
	}
}

const NativeArray<uint8_t>*
Array_byte_Helper::wrapConst(const Array_byte_Struct* src)
{
	return const_cast<const NativeArray<uint8_t>*>(Array_byte_Helper::wrap(src));
}

void
Array_byte_Helper::freeMembers(Array_byte_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	MarshalHelper::freeArray<uint8_t>(obj.ptr, obj.length);
}

void
Array_byte_Helper::destructor(Array_byte_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Array_byte_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_XobotOS_MarshalGlue_Array_byte_destructor(Array_byte_Struct* obj)
{
	Array_byte_Helper::destructor(obj);
}

struct Array_int_Struct
{
	uint32_t _owner;
	uint32_t length;
	int* ptr;
};

void
Array_int_Helper::unwrap(NativeArray<int>& from, Array_int_Struct* to)
{
	to->_owner = 0x7380548b;
	to->length = from.length();
	to->ptr = from.takeOwnership();
}

Array_int_Struct*
Array_int_Helper::unwrap(NativeArray<int>* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Array_int_Struct* retval = new Array_int_Struct();
	Array_int_Helper::unwrap(*src, retval);
	return retval;
}

void
Array_int_Helper::marshalOut(const NativeArray<int>& from, Array_int_Struct* to)
{
	assert(from.length() == to->length);
	assert(false);
}

NativeArray<int>*
Array_int_Helper::wrap(const Array_int_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	return new NativeArray<int>(src->length, src->ptr);
}

void
Array_int_Helper::wrap(const Array_int_Struct& from, NativeArray<int>* to)
{
	assert(from.length == to->length());
	for(uint32_t i = 0; i < from.length; i++)
	{
		to->item(i) = from.ptr[i];
	}
}

const NativeArray<int>*
Array_int_Helper::wrapConst(const Array_int_Struct* src)
{
	return const_cast<const NativeArray<int>*>(Array_int_Helper::wrap(src));
}

void
Array_int_Helper::freeMembers(Array_int_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	MarshalHelper::freeArray<int>(obj.ptr, obj.length);
}

void
Array_int_Helper::destructor(Array_int_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Array_int_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_XobotOS_MarshalGlue_Array_int_destructor(Array_int_Struct* obj)
{
	Array_int_Helper::destructor(obj);
}

struct Array_long_Struct
{
	uint32_t _owner;
	uint32_t length;
	long* ptr;
};

void
Array_long_Helper::unwrap(NativeArray<long>& from, Array_long_Struct* to)
{
	to->_owner = 0x7380548b;
	to->length = from.length();
	to->ptr = from.takeOwnership();
}

Array_long_Struct*
Array_long_Helper::unwrap(NativeArray<long>* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Array_long_Struct* retval = new Array_long_Struct();
	Array_long_Helper::unwrap(*src, retval);
	return retval;
}

void
Array_long_Helper::marshalOut(const NativeArray<long>& from, Array_long_Struct* to)
{
	assert(from.length() == to->length);
	assert(false);
}

NativeArray<long>*
Array_long_Helper::wrap(const Array_long_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	return new NativeArray<long>(src->length, src->ptr);
}

void
Array_long_Helper::wrap(const Array_long_Struct& from, NativeArray<long>* to)
{
	assert(from.length == to->length());
	for(uint32_t i = 0; i < from.length; i++)
	{
		to->item(i) = from.ptr[i];
	}
}

const NativeArray<long>*
Array_long_Helper::wrapConst(const Array_long_Struct* src)
{
	return const_cast<const NativeArray<long>*>(Array_long_Helper::wrap(src));
}

void
Array_long_Helper::freeMembers(Array_long_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	MarshalHelper::freeArray<long>(obj.ptr, obj.length);
}

void
Array_long_Helper::destructor(Array_long_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Array_long_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_XobotOS_MarshalGlue_Array_long_destructor(Array_long_Struct* obj)
{
	Array_long_Helper::destructor(obj);
}

struct Array_float_Struct
{
	uint32_t _owner;
	uint32_t length;
	float* ptr;
};

void
Array_float_Helper::unwrap(NativeArray<float>& from, Array_float_Struct* to)
{
	to->_owner = 0x7380548b;
	to->length = from.length();
	to->ptr = from.takeOwnership();
}

Array_float_Struct*
Array_float_Helper::unwrap(NativeArray<float>* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Array_float_Struct* retval = new Array_float_Struct();
	Array_float_Helper::unwrap(*src, retval);
	return retval;
}

void
Array_float_Helper::marshalOut(const NativeArray<float>& from, Array_float_Struct*
	 to)
{
	assert(from.length() == to->length);
	assert(false);
}

NativeArray<float>*
Array_float_Helper::wrap(const Array_float_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	return new NativeArray<float>(src->length, src->ptr);
}

void
Array_float_Helper::wrap(const Array_float_Struct& from, NativeArray<float>* to)
{
	assert(from.length == to->length());
	for(uint32_t i = 0; i < from.length; i++)
	{
		to->item(i) = from.ptr[i];
	}
}

const NativeArray<float>*
Array_float_Helper::wrapConst(const Array_float_Struct* src)
{
	return const_cast<const NativeArray<float>*>(Array_float_Helper::wrap(src));
}

void
Array_float_Helper::freeMembers(Array_float_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	MarshalHelper::freeArray<float>(obj.ptr, obj.length);
}

void
Array_float_Helper::destructor(Array_float_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Array_float_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_XobotOS_MarshalGlue_Array_float_destructor(Array_float_Struct* obj)
{
	Array_float_Helper::destructor(obj);
}


