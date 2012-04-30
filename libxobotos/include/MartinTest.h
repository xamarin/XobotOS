// -*- c-basic-offset: 8 -*-
#ifndef MARTIN_TEST_H
#define MARTIN_TEST_H

#include <libxobotos.h>
#include <utils/String8.h>
#include <utils/String16.h>

class MartinTest
{
public:
	static void hello(const NativeArray<int>& array);

	class Foo {
	public:
		int hello;
		NativeArray<int>* a;

	public:
		Foo();
		~Foo();
	};

	struct Blittable {
	public:
		int hello;
	};

	class Complex {
	public:
		NativeArray<Foo>* foo;
		NativeString* str;

	public:
		Complex();
		~Complex();
	};

	static void dumpMemoryUsage();

	static void foo(const Foo& foo);
	static void bar(const NativeArray<Foo>& bar);

	static void refFunc(Foo& foo);
	static void outFunc(Foo* foo);
	static Foo* retFunc();

	static void blittableFunc(const Blittable& arg);
	static void blittableRef(Blittable& arg);

	static void complex(const Complex& arg);
	static Complex* complexRet();

	static void stringFunc(const NativeString& str);
	static void stringArray(const NativePtrArray<NativeString>& array);
	static NativeString* returnString();
	static NativePtrArray<NativeString>* returnStringArray();

	static NativeArray<int>* returnIntArray();
};

#endif
