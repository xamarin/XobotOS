// -*- c-basic-offset: 8 -*-
#ifndef LIBXOBOTOS_MARSHAL_HELPER_H
#define LIBXOBOTOS_MARSHAL_HELPER_H

#include <utils/Unicode.h>
#include <utils/String8.h>
#include <utils/String16.h>
#include <assert.h>

#include <vector>

namespace XobotOS
{
class MarshalHelper
{
public:
	static void trackAlloc(const void* ptr, size_t size);
	static void trackFree(const void* ptr, size_t size);

	static void dumpMemoryUsage();

	template<typename T>
	static T* allocArray(size_t size)
	{
		T* ptr = new T [size];
		trackAlloc(ptr, size * sizeof (T));
		return ptr;
	}

	template<typename T>
	static void freeArray(T* ptr, size_t size)
	{
		trackFree(ptr, size * sizeof (T));
		delete[] ptr;
	}

private:
	static size_t _totalAlloc;
	MarshalHelper();
};

class Noncopyable
{
public:
	Noncopyable() {}

private:
	Noncopyable(const Noncopyable&);
	Noncopyable& operator=(const Noncopyable&);
};

template<typename T>
class NativeArray : Noncopyable
{
public:
	NativeArray(size_t count, const T* ptr)
	{
		this->_count = count;
		this->_ptr = const_cast<T*>(ptr);
		this->_ownsPtr = false;

		MarshalHelper::trackAlloc(this, sizeof (this));
	}

	NativeArray(size_t count)
	{
		this->_count = count;
		this->_ptr = new T[count];
		this->_ownsPtr = true;

		MarshalHelper::trackAlloc(this, sizeof (this) + _count * sizeof (T));
	}

	size_t length() const { return _count; }

	T* ptr(size_t offset, size_t length) const
	{
		SkASSERT(offset+length <= _count);
		return _ptr + offset;
	}

	T* takeOwnership()
	{
		assert(_ownsPtr);
		_ownsPtr = false;
		return _ptr;
	}

	NativeArray<T>* copy()
	{
		NativeArray<T>* retval = new NativeArray<T> (_count);
		for (size_t i = 0; i < _count; i++) {
			retval->item(i) = _ptr[i];
		}
		return retval;
	}

	T& operator[] (size_t index) const {
		SkASSERT(index < _count);
		return _ptr[index];
	}

	T& item (size_t index) const {
		SkASSERT(index < _count);
		return _ptr[index];
	}

	void set (size_t index, T item) const {
		SkASSERT(index < _count);
		_ptr[index] = item;
	}

	~NativeArray()
	{
		if (_ownsPtr) {
			MarshalHelper::trackFree(this, sizeof (this) + _count * sizeof (T));

			delete[] _ptr;
			_ptr = NULL;
			_count = 0;
			_ownsPtr = false;
		} else {
			MarshalHelper::trackFree(this, sizeof (this));
		}
	}

private:
	size_t _count;
	T* _ptr;
	bool _ownsPtr;

	NativeArray(const NativeArray&);
};

class NativeString : public NativeArray<char16_t>
{
public:
	NativeString(size_t length, const char16_t* str)
		: NativeArray<char16_t>(length)
	{
		memcpy(ptr(0, length), str, 2 * length);
	}

	NativeString(const android::String16& str)
		: NativeArray<char16_t>(str.size())
	{
		memcpy(ptr(0, length()), str.string(), 2 * length());
	}

	NativeString(const char* str)
		: NativeArray<char16_t>(strlen(str))
	{
		android::String16 str16(str);
		memcpy(ptr(0, length()), str16.string(), 2 * length());
	}

	inline operator android::String16() const
	{
		return android::String16(ptr(0, length()), length());
	}

private:
	NativeString(const NativeString&);
};

template<class T>
class NativePtrArray : Noncopyable
{
public:
	NativePtrArray(size_t count) : _count(count), _vector(count)
	{
		MarshalHelper::trackAlloc(this, sizeof (this) + _count * sizeof (T));
	}

	size_t length() const { return _vector.size(); }

	T*& operator[] (size_t index) const {
		SkASSERT(index < _count);
		return const_cast<T*&>(_vector.at(index));
	}

	T*& item (size_t index) const {
		SkASSERT(index < _count);
		return const_cast<T*&>(_vector.at(index));
	}

	const T& valueAt(size_t index) const {
		SkASSERT(index < _count);
		return *_vector.at(index);
	}

	void set (size_t index, T* item) {
		SkASSERT(index < _count);
		_vector[index] = item;
	}

	~NativePtrArray()
	{
		MarshalHelper::trackFree(this, sizeof (this) + _count * sizeof (T));
		for (size_t index = 0; index < _count; index++)
			delete _vector[index];
		_count = 0;
	}

private:
	size_t _count;
	std::vector<T*> _vector;

	NativePtrArray(const NativePtrArray&);
};

};

#endif
