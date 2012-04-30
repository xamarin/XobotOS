#include "martin.Test.h"

extern "C" DLL_EXPORT void
libxobotos_martin_Test_destructor(MartinTest* ptr)
{
	delete ptr;
}

struct Foo_Struct
{
	uint32_t _owner;
	int hello;
	Array_int_Struct* a;
};

void
Foo_Helper::unwrap(MartinTest::Foo& from, Foo_Struct* to)
{
	to->_owner = 0x7380548b;
	to->hello = from.hello;
	to->a = Array_int_Helper::unwrap(from.a);
}

Foo_Struct*
Foo_Helper::unwrap(MartinTest::Foo* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Foo_Struct* retval = new Foo_Struct();
	Foo_Helper::unwrap(*src, retval);
	return retval;
}

void
Foo_Helper::marshalOut(const MartinTest::Foo& from, Foo_Struct* to)
{
	to->hello = from.hello;
	Array_int_Helper::marshalOut(*from.a, to->a);
}

void
Foo_Helper::wrap(const Foo_Struct& from, MartinTest::Foo* to)
{
	to->hello = from.hello;
	to->a = Array_int_Helper::wrap(from.a);
}

MartinTest::Foo*
Foo_Helper::wrap(const Foo_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	MartinTest::Foo* retval = new MartinTest::Foo();
	Foo_Helper::wrap(*src, retval);
	return retval;
}

const MartinTest::Foo*
Foo_Helper::wrapConst(const Foo_Struct* src)
{
	return const_cast<const MartinTest::Foo*>(Foo_Helper::wrap(src));
}

void
Foo_Helper::freeMembers(Foo_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	Array_int_Helper::destructor(obj.a);
}

void
Foo_Helper::destructor(Foo_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Foo_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_martin_Test_Foo_destructor(Foo_Struct* obj)
{
	Foo_Helper::destructor(obj);
}

struct Blittable_Struct
{
	uint32_t _owner;
	int hello;
};

void
Blittable_Helper::unwrap(MartinTest::Blittable& from, Blittable_Struct* to)
{
	to->_owner = 0x7380548b;
	to->hello = from.hello;
}

Blittable_Struct*
Blittable_Helper::unwrap(MartinTest::Blittable* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Blittable_Struct* retval = new Blittable_Struct();
	Blittable_Helper::unwrap(*src, retval);
	return retval;
}

void
Blittable_Helper::marshalOut(const MartinTest::Blittable& from, Blittable_Struct*
	 to)
{
	to->hello = from.hello;
}

void
Blittable_Helper::wrap(const Blittable_Struct& from, MartinTest::Blittable* to)
{
	to->hello = from.hello;
}

MartinTest::Blittable*
Blittable_Helper::wrap(const Blittable_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	MartinTest::Blittable* retval = new MartinTest::Blittable();
	Blittable_Helper::wrap(*src, retval);
	return retval;
}

const MartinTest::Blittable*
Blittable_Helper::wrapConst(const Blittable_Struct* src)
{
	return const_cast<const MartinTest::Blittable*>(Blittable_Helper::wrap(src));
}

void
Blittable_Helper::freeMembers(Blittable_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
Blittable_Helper::destructor(Blittable_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Blittable_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_martin_Test_Blittable_destructor(Blittable_Struct* obj)
{
	Blittable_Helper::destructor(obj);
}

struct Array_Foo_Struct
{
	uint32_t _owner;
	uint32_t length;
	Foo_Struct* ptr;
};

class Array_Foo_Helper
{
public:
	static void
	unwrap(NativeArray<MartinTest::Foo>& from, Array_Foo_Struct* to)
	{
		to->_owner = 0x7380548b;
		to->length = from.length();
		{
			to->ptr = MarshalHelper::allocArray<Foo_Struct>(from.length());
			for(uint32_t i = 0; i < from.length(); i++)
			{
				Foo_Helper::unwrap(from.item(i), &(to->ptr[i]));
			}
		}
	}

	static Array_Foo_Struct*
	unwrap(NativeArray<MartinTest::Foo>* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		Array_Foo_Struct* retval = new Array_Foo_Struct();
		Array_Foo_Helper::unwrap(*src, retval);
		return retval;
	}

	static void
	marshalOut(const NativeArray<MartinTest::Foo>& from, Array_Foo_Struct* to)
	{
		assert(from.length() == to->length);
		for(uint32_t i = 0; i < from.length(); i++)
		{
			Foo_Helper::marshalOut(from.item(i), &(to->ptr[i]));
		}
	}

	static void
	wrap(const Array_Foo_Struct& from, NativeArray<MartinTest::Foo>* to)
	{
		assert(from.length == to->length());
		for(uint32_t i = 0; i < from.length; i++)
		{
			Foo_Helper::wrap(from.ptr[i], &(to->item(i)));
		}
	}

	static NativeArray<MartinTest::Foo>*
	wrap(const Array_Foo_Struct* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		NativeArray<MartinTest::Foo>* retval = new NativeArray<MartinTest::Foo>(src->length);
		Array_Foo_Helper::wrap(*src, retval);
		return retval;
	}

	static const NativeArray<MartinTest::Foo>*
	wrapConst(const Array_Foo_Struct* src)
	{
		return const_cast<const NativeArray<MartinTest::Foo>*>(Array_Foo_Helper::wrap(src));
	}

	static void
	freeMembers(Array_Foo_Struct& obj)
	{
		assert(obj._owner == 0x7380548b);
		{
			for(uint32_t i = 0; i < obj.length; i++)
			{
				Foo_Helper::freeMembers(obj.ptr[i]);
			}
			MarshalHelper::freeArray<Foo_Struct>(obj.ptr, obj.length);
		}
	}

	static void
	destructor(Array_Foo_Struct* obj)
	{
		if (obj == NULL)
		{
			return;
		}
		Array_Foo_Helper::freeMembers(*obj);
		delete obj;
	}


private:
	Array_Foo_Helper();

};

extern "C" DLL_EXPORT void
libxobotos_martin_Test_Array_Foo_destructor(Array_Foo_Struct* obj)
{
	Array_Foo_Helper::destructor(obj);
}

struct Complex_Struct
{
	uint32_t _owner;
	Array_Foo_Struct* foo;
	String_Struct* str;
};

void
Complex_Helper::unwrap(MartinTest::Complex& from, Complex_Struct* to)
{
	to->_owner = 0x7380548b;
	to->foo = Array_Foo_Helper::unwrap(from.foo);
	to->str = String_Helper::unwrap(from.str);
}

Complex_Struct*
Complex_Helper::unwrap(MartinTest::Complex* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Complex_Struct* retval = new Complex_Struct();
	Complex_Helper::unwrap(*src, retval);
	return retval;
}

void
Complex_Helper::marshalOut(const MartinTest::Complex& from, Complex_Struct* to)
{
	Array_Foo_Helper::marshalOut(*from.foo, to->foo);
	String_Helper::marshalOut(*from.str, to->str);
}

void
Complex_Helper::wrap(const Complex_Struct& from, MartinTest::Complex* to)
{
	to->foo = Array_Foo_Helper::wrap(from.foo);
	to->str = String_Helper::wrap(from.str);
}

MartinTest::Complex*
Complex_Helper::wrap(const Complex_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	MartinTest::Complex* retval = new MartinTest::Complex();
	Complex_Helper::wrap(*src, retval);
	return retval;
}

const MartinTest::Complex*
Complex_Helper::wrapConst(const Complex_Struct* src)
{
	return const_cast<const MartinTest::Complex*>(Complex_Helper::wrap(src));
}

void
Complex_Helper::freeMembers(Complex_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	Array_Foo_Helper::destructor(obj.foo);
	String_Helper::destructor(obj.str);
}

void
Complex_Helper::destructor(Complex_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Complex_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_martin_Test_Complex_destructor(Complex_Struct* obj)
{
	Complex_Helper::destructor(obj);
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
libxobotos_martin_Test_Array_String_destructor(Array_String_Struct* obj)
{
	Array_String_Helper::destructor(obj);
}


extern "C" DLL_EXPORT void
libxobotos_Test_stringFunc(String_Struct* str_ptr)
{
	const NativeString* str = String_Helper::wrapConst(str_ptr);
	MartinTest::stringFunc(*str);
	delete str;
}

extern "C" DLL_EXPORT String_Struct*
libxobotos_Test_returnString()
{
	NativeString* _returnObj = MartinTest::returnString();
	String_Struct* _retval = String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Test_blittableFunc(Blittable_Struct* arg_ptr)
{
	const MartinTest::Blittable* arg = Blittable_Helper::wrapConst(arg_ptr);
	MartinTest::blittableFunc(*arg);
	delete arg;
}

extern "C" DLL_EXPORT void
libxobotos_Test_complex(Complex_Struct* arg_ptr)
{
	const MartinTest::Complex* arg = Complex_Helper::wrapConst(arg_ptr);
	MartinTest::complex(*arg);
	delete arg;
}

extern "C" DLL_EXPORT void
libxobotos_Test_outFunc(Foo_Struct** arg_ptr)
{
	MartinTest::Foo arg;
	MartinTest::outFunc(&arg);
	*arg_ptr = Foo_Helper::unwrap(&arg);
}

extern "C" DLL_EXPORT void
libxobotos_Test_dumpMemoryUsage()
{
	MartinTest::dumpMemoryUsage();
}

extern "C" DLL_EXPORT void
libxobotos_Test_foo(Foo_Struct* arg_ptr)
{
	const MartinTest::Foo* arg = Foo_Helper::wrapConst(arg_ptr);
	MartinTest::foo(*arg);
	delete arg;
}

extern "C" DLL_EXPORT void
libxobotos_Test_blittableRef(Blittable_Struct* arg_ptr)
{
	MartinTest::Blittable* arg = Blittable_Helper::wrap(arg_ptr);
	MartinTest::blittableRef(*arg);
	if (arg_ptr != NULL)
	{
		Blittable_Helper::marshalOut(*arg, arg_ptr);
	}
	delete arg;
}

extern "C" DLL_EXPORT Complex_Struct*
libxobotos_Test_complexRet()
{
	MartinTest::Complex* _returnObj = MartinTest::complexRet();
	Complex_Struct* _retval = Complex_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Test_stringArray(Array_String_Struct* array_ptr)
{
	const NativePtrArray<NativeString>* array = Array_String_Helper::wrapConst(array_ptr);
	MartinTest::stringArray(*array);
	delete array;
}

extern "C" DLL_EXPORT Array_int_Struct*
libxobotos_Test_returnIntArray()
{
	NativeArray<int>* _returnObj = MartinTest::returnIntArray();
	Array_int_Struct* _retval = Array_int_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Test_refFunc(Foo_Struct* arg_ptr)
{
	MartinTest::Foo* arg = Foo_Helper::wrap(arg_ptr);
	MartinTest::refFunc(*arg);
	if (arg_ptr != NULL)
	{
		Foo_Helper::marshalOut(*arg, arg_ptr);
	}
	delete arg;
}

extern "C" DLL_EXPORT Array_String_Struct*
libxobotos_Test_returnStringArray()
{
	NativePtrArray<NativeString>* _returnObj = MartinTest::returnStringArray();
	Array_String_Struct* _retval = Array_String_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Test_hello(Array_int_Struct* a_ptr)
{
	NativeArray<int>* a = Array_int_Helper::wrap(a_ptr);
	MartinTest::hello(*a);
	delete a;
}

extern "C" DLL_EXPORT void
libxobotos_Test_bar(Array_Foo_Struct* arg_ptr)
{
	const NativeArray<MartinTest::Foo>* arg = Array_Foo_Helper::wrapConst(arg_ptr);
	MartinTest::bar(*arg);
	delete arg;
}

extern "C" DLL_EXPORT Foo_Struct*
libxobotos_Test_retFunc()
{
	MartinTest::Foo* _returnObj = MartinTest::retFunc();
	Foo_Struct* _retval = Foo_Helper::unwrap(_returnObj);
	delete _returnObj;
	return _retval;
}

