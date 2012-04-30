// -*- c-basic-offset: 8 -*-
#include <MartinTest.h>

#define LOG_TAG "MartinTest"
#include <utils/Log.h>
#include <vector>

MartinTest::Foo::Foo()
{
	LOGI("FOO CONSTRUCTOR: %p\n", this);
	MarshalHelper::trackAlloc(this, sizeof(this));
}

MartinTest::Foo::~Foo()
{
	LOGI("FOO DESTRUCTOR: %p - %p - %ld!\n", this, a, sizeof (a));
	delete a;
	MarshalHelper::trackFree(this, sizeof(this));
}

MartinTest::Complex::Complex()
{
	LOGI("COMPLEX CONSTRUCTOR!\n");
	foo = NULL;
	str = NULL;
	MarshalHelper::trackAlloc(this, sizeof(this));
}

MartinTest::Complex::~Complex()
{
	LOGI("COMPLEX DESTRUCTOR: %p - %p!\n", this, foo);
	delete foo;
	delete str;
	MarshalHelper::trackFree(this, sizeof(this));
}

void
MartinTest::dumpMemoryUsage()
{
	MarshalHelper::dumpMemoryUsage();
}

void
MartinTest::hello(const NativeArray<int>& array)
{
	LOGI("HELLO: %ld - %d\n", array.length(), array[0]);
	array[0] = 999;
}

void
MartinTest::foo(const Foo& foo)
{
	LOGI("FOO: %d - %p\n", foo.hello, foo.a);
	hello(*foo.a);
}

void
MartinTest::bar(const NativeArray<Foo>& bar)
{
	LOGI("BAR: %ld\n", bar.length());
	foo(bar[0]);
}

void
MartinTest::refFunc(Foo& foo)
{
	LOGI("REF FUNC: %x!\n", foo.hello);
	foo.hello = 0x12345678;
}

void
MartinTest::outFunc(Foo* foo)
{
	foo->hello = 0x87654321;
	foo->a = new NativeArray<int>(0);
	LOGI("OUT FUNC: %p - %x!\n", foo, foo->hello);
}

MartinTest::Foo*
MartinTest::retFunc()
{
	Foo* foo = new Foo();
	foo->hello = 0xdeadbeaf;
	foo->a = new NativeArray<int>(0);
	LOGI("RET FUNC: %p - %x!\n", foo, foo->hello);
	return foo;
}

void
MartinTest::blittableFunc(const Blittable& arg)
{
	LOGI("BLITTABLE FUNC: %x\n", arg.hello);
	const_cast<Blittable&>(arg).hello = 0xdeadbeaf;
}

void
MartinTest::blittableRef(Blittable& arg)
{
	LOGI("BLITTABLE REF: %x\n", arg.hello);
	arg.hello = 0xdeadbeaf;
}

void
MartinTest::complex(const Complex& arg)
{
	LOGI("COMPLEX: %p - %ld!\n", arg.foo, arg.foo->length());
}

MartinTest::Complex*
MartinTest::complexRet()
{
	LOGI("COMPLEX RET\n");

	Complex* complex = new Complex();

	complex->str = new NativeString("I am a Xobot monkey!");

	NativeArray<int>* a = new NativeArray<int> (4);
	a->set(0,1);
	a->set(1, 0x12345678);
	a->set(2, 0xdeadbeaf);
	a->set(3, 769);

	NativeArray<int>* b = new NativeArray<int> (2);
	(*b)[0] = 128;
	(*b)[1] = 65535;

	complex->foo = new NativeArray<Foo> (2);
	complex->foo->item(0).hello = 1;
	complex->foo->item(0).a = a;
	complex->foo->item(1).hello = 2;
	complex->foo->item(1).a = b;

	LOGI("COMPLEX RET: %p - %p\n", complex, complex->foo);
	return complex;
}

void
MartinTest::stringFunc(const NativeString& str)
{
	LOGI("TEST: %s\n", ((android::String8)str).string());
}

void
MartinTest::stringArray(const NativePtrArray<NativeString>& array)
{
	LOGI("STRING ARRAY: %ld\n", array.length());
	for (size_t i = 0; i < array.length(); i++) {
		LOGI("STRING ARRAY #1: %s\n", ((android::String8)array.valueAt(i)).string());
	}
}

NativeString*
MartinTest::returnString()
{
	return new NativeString("I am a Xobot monkey!");
}

NativePtrArray<NativeString>*
MartinTest::returnStringArray()
{
	NativePtrArray<NativeString>* array = new NativePtrArray<NativeString> (3);
	array->set(0, new NativeString("Hello World!"));
	array->set(1, new NativeString("I am a Xobot monkey!"));
	return array;
}

NativeArray<int>*
MartinTest::returnIntArray()
{
	NativeArray<int>* array = new NativeArray<int>(2);
	array->set(0,16384);
	array->set(1,5);
	return array;
}
