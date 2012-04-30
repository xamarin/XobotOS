#ifndef XOBOTOS_MARSHALGLUE_GLUE_H
#define XOBOTOS_MARSHALGLUE_GLUE_H 1

#include <libxobotos.h>

struct String_Struct;

class String_Helper
{
public:
	static void unwrap(NativeString& from, String_Struct* to);
	static String_Struct* unwrap(NativeString* src);
	static void marshalOut(const NativeString& from, String_Struct* to);
	static void wrap(const String_Struct& from, NativeString* to);
	static NativeString* wrap(const String_Struct* src);
	static const NativeString* wrapConst(const String_Struct* src);
	static void freeMembers(String_Struct& obj);
	static void destructor(String_Struct* obj);

private:
	String_Helper();

};

struct Array_char_Struct;

class Array_char_Helper
{
public:
	static void unwrap(NativeArray<char16_t>& from, Array_char_Struct* to);
	static Array_char_Struct* unwrap(NativeArray<char16_t>* src);
	static void marshalOut(const NativeArray<char16_t>& from, Array_char_Struct* to);
	static NativeArray<char16_t>* wrap(const Array_char_Struct* src);
	static void wrap(const Array_char_Struct& from, NativeArray<char16_t>* to);
	static const NativeArray<char16_t>* wrapConst(const Array_char_Struct* src);
	static void freeMembers(Array_char_Struct& obj);
	static void destructor(Array_char_Struct* obj);

private:
	Array_char_Helper();

};

struct Array_byte_Struct;

class Array_byte_Helper
{
public:
	static void unwrap(NativeArray<uint8_t>& from, Array_byte_Struct* to);
	static Array_byte_Struct* unwrap(NativeArray<uint8_t>* src);
	static void marshalOut(const NativeArray<uint8_t>& from, Array_byte_Struct* to);
	static NativeArray<uint8_t>* wrap(const Array_byte_Struct* src);
	static void wrap(const Array_byte_Struct& from, NativeArray<uint8_t>* to);
	static const NativeArray<uint8_t>* wrapConst(const Array_byte_Struct* src);
	static void freeMembers(Array_byte_Struct& obj);
	static void destructor(Array_byte_Struct* obj);

private:
	Array_byte_Helper();

};

struct Array_int_Struct;

class Array_int_Helper
{
public:
	static void unwrap(NativeArray<int>& from, Array_int_Struct* to);
	static Array_int_Struct* unwrap(NativeArray<int>* src);
	static void marshalOut(const NativeArray<int>& from, Array_int_Struct* to);
	static NativeArray<int>* wrap(const Array_int_Struct* src);
	static void wrap(const Array_int_Struct& from, NativeArray<int>* to);
	static const NativeArray<int>* wrapConst(const Array_int_Struct* src);
	static void freeMembers(Array_int_Struct& obj);
	static void destructor(Array_int_Struct* obj);

private:
	Array_int_Helper();

};

struct Array_long_Struct;

class Array_long_Helper
{
public:
	static void unwrap(NativeArray<long>& from, Array_long_Struct* to);
	static Array_long_Struct* unwrap(NativeArray<long>* src);
	static void marshalOut(const NativeArray<long>& from, Array_long_Struct* to);
	static NativeArray<long>* wrap(const Array_long_Struct* src);
	static void wrap(const Array_long_Struct& from, NativeArray<long>* to);
	static const NativeArray<long>* wrapConst(const Array_long_Struct* src);
	static void freeMembers(Array_long_Struct& obj);
	static void destructor(Array_long_Struct* obj);

private:
	Array_long_Helper();

};

struct Array_float_Struct;

class Array_float_Helper
{
public:
	static void unwrap(NativeArray<float>& from, Array_float_Struct* to);
	static Array_float_Struct* unwrap(NativeArray<float>* src);
	static void marshalOut(const NativeArray<float>& from, Array_float_Struct* to);
	static NativeArray<float>* wrap(const Array_float_Struct* src);
	static void wrap(const Array_float_Struct& from, NativeArray<float>* to);
	static const NativeArray<float>* wrapConst(const Array_float_Struct* src);
	static void freeMembers(Array_float_Struct& obj);
	static void destructor(Array_float_Struct* obj);

private:
	Array_float_Helper();

};



#endif
