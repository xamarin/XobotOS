#ifndef MARTIN_TEST_GLUE_H
#define MARTIN_TEST_GLUE_H 1

#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <MartinTest.h>

struct Foo_Struct;

class Foo_Helper
{
public:
	static void unwrap(MartinTest::Foo& from, Foo_Struct* to);
	static Foo_Struct* unwrap(MartinTest::Foo* src);
	static void marshalOut(const MartinTest::Foo& from, Foo_Struct* to);
	static void wrap(const Foo_Struct& from, MartinTest::Foo* to);
	static MartinTest::Foo* wrap(const Foo_Struct* src);
	static const MartinTest::Foo* wrapConst(const Foo_Struct* src);
	static void freeMembers(Foo_Struct& obj);
	static void destructor(Foo_Struct* obj);

private:
	Foo_Helper();

};

struct Blittable_Struct;

class Blittable_Helper
{
public:
	static void unwrap(MartinTest::Blittable& from, Blittable_Struct* to);
	static Blittable_Struct* unwrap(MartinTest::Blittable* src);
	static void marshalOut(const MartinTest::Blittable& from, Blittable_Struct* to);
	static void wrap(const Blittable_Struct& from, MartinTest::Blittable* to);
	static MartinTest::Blittable* wrap(const Blittable_Struct* src);
	static const MartinTest::Blittable* wrapConst(const Blittable_Struct* src);
	static void freeMembers(Blittable_Struct& obj);
	static void destructor(Blittable_Struct* obj);

private:
	Blittable_Helper();

};

struct Complex_Struct;

class Complex_Helper
{
public:
	static void unwrap(MartinTest::Complex& from, Complex_Struct* to);
	static Complex_Struct* unwrap(MartinTest::Complex* src);
	static void marshalOut(const MartinTest::Complex& from, Complex_Struct* to);
	static void wrap(const Complex_Struct& from, MartinTest::Complex* to);
	static MartinTest::Complex* wrap(const Complex_Struct* src);
	static const MartinTest::Complex* wrapConst(const Complex_Struct* src);
	static void freeMembers(Complex_Struct& obj);
	static void destructor(Complex_Struct* obj);

private:
	Complex_Helper();

};



#endif
