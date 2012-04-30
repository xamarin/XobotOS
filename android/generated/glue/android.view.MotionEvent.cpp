#include "android.view.MotionEvent.h"

extern "C" DLL_EXPORT void
libxobotos_android_view_MotionEvent_destructor(MotionEventGlue* ptr)
{
	delete ptr;
}

struct PointerCoords_Struct
{
	uint32_t _owner;
	long packedAxisBits;
	Array_float_Struct* packedAxisValues;
	float x;
	float y;
	float pressure;
	float size;
	float touchMajor;
	float touchMinor;
	float toolMajor;
	float toolMinor;
	float orientation;
};

void
PointerCoords_Helper::unwrap(MotionEventGlue::Coords& from, PointerCoords_Struct*
	 to)
{
	to->_owner = 0x7380548b;
	to->packedAxisBits = from.packedAxisBits;
	to->packedAxisValues = Array_float_Helper::unwrap(from.packedAxisValues);
	to->x = from.x;
	to->y = from.y;
	to->pressure = from.pressure;
	to->size = from.size;
	to->touchMajor = from.touchMajor;
	to->touchMinor = from.touchMinor;
	to->toolMajor = from.toolMajor;
	to->toolMinor = from.toolMinor;
	to->orientation = from.orientation;
}

PointerCoords_Struct*
PointerCoords_Helper::unwrap(MotionEventGlue::Coords* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	PointerCoords_Struct* retval = new PointerCoords_Struct();
	PointerCoords_Helper::unwrap(*src, retval);
	return retval;
}

void
PointerCoords_Helper::marshalOut(const MotionEventGlue::Coords& from, PointerCoords_Struct*
	 to)
{
	to->packedAxisBits = from.packedAxisBits;
	Array_float_Helper::marshalOut(*from.packedAxisValues, to->packedAxisValues);
	to->x = from.x;
	to->y = from.y;
	to->pressure = from.pressure;
	to->size = from.size;
	to->touchMajor = from.touchMajor;
	to->touchMinor = from.touchMinor;
	to->toolMajor = from.toolMajor;
	to->toolMinor = from.toolMinor;
	to->orientation = from.orientation;
}

void
PointerCoords_Helper::wrap(const PointerCoords_Struct& from, MotionEventGlue::Coords*
	 to)
{
	to->packedAxisBits = from.packedAxisBits;
	to->packedAxisValues = Array_float_Helper::wrap(from.packedAxisValues);
	to->x = from.x;
	to->y = from.y;
	to->pressure = from.pressure;
	to->size = from.size;
	to->touchMajor = from.touchMajor;
	to->touchMinor = from.touchMinor;
	to->toolMajor = from.toolMajor;
	to->toolMinor = from.toolMinor;
	to->orientation = from.orientation;
}

MotionEventGlue::Coords*
PointerCoords_Helper::wrap(const PointerCoords_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	MotionEventGlue::Coords* retval = new MotionEventGlue::Coords();
	PointerCoords_Helper::wrap(*src, retval);
	return retval;
}

const MotionEventGlue::Coords*
PointerCoords_Helper::wrapConst(const PointerCoords_Struct* src)
{
	return const_cast<const MotionEventGlue::Coords*>(PointerCoords_Helper::wrap(src));
}

void
PointerCoords_Helper::freeMembers(PointerCoords_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
	Array_float_Helper::destructor(obj.packedAxisValues);
}

void
PointerCoords_Helper::destructor(PointerCoords_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	PointerCoords_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_view_MotionEvent_PointerCoords_destructor(PointerCoords_Struct*
	 obj)
{
	PointerCoords_Helper::destructor(obj);
}

struct PointerProperties_Struct
{
	uint32_t _owner;
	int id;
	int toolType;
};

void
PointerProperties_Helper::unwrap(MotionEventGlue::Properties& from, PointerProperties_Struct*
	 to)
{
	to->_owner = 0x7380548b;
	to->id = from.id;
	to->toolType = from.toolType;
}

PointerProperties_Struct*
PointerProperties_Helper::unwrap(MotionEventGlue::Properties* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	PointerProperties_Struct* retval = new PointerProperties_Struct();
	PointerProperties_Helper::unwrap(*src, retval);
	return retval;
}

void
PointerProperties_Helper::marshalOut(const MotionEventGlue::Properties& from, PointerProperties_Struct*
	 to)
{
	to->id = from.id;
	to->toolType = from.toolType;
}

void
PointerProperties_Helper::wrap(const PointerProperties_Struct& from, MotionEventGlue::Properties*
	 to)
{
	to->id = from.id;
	to->toolType = from.toolType;
}

MotionEventGlue::Properties*
PointerProperties_Helper::wrap(const PointerProperties_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	MotionEventGlue::Properties* retval = new MotionEventGlue::Properties();
	PointerProperties_Helper::wrap(*src, retval);
	return retval;
}

const MotionEventGlue::Properties*
PointerProperties_Helper::wrapConst(const PointerProperties_Struct* src)
{
	return const_cast<const MotionEventGlue::Properties*>(PointerProperties_Helper::wrap
		(src));
}

void
PointerProperties_Helper::freeMembers(PointerProperties_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
PointerProperties_Helper::destructor(PointerProperties_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	PointerProperties_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_view_MotionEvent_PointerProperties_destructor(PointerProperties_Struct*
	 obj)
{
	PointerProperties_Helper::destructor(obj);
}

struct Array_PointerProperties_Struct
{
	uint32_t _owner;
	uint32_t length;
	PointerProperties_Struct* ptr;
};

class Array_PointerProperties_Helper
{
public:
	static void
	unwrap(NativeArray<MotionEventGlue::Properties>& from, Array_PointerProperties_Struct*
		 to)
	{
		to->_owner = 0x7380548b;
		to->length = from.length();
		{
			to->ptr = MarshalHelper::allocArray<PointerProperties_Struct>(from.length());
			for(uint32_t i = 0; i < from.length(); i++)
			{
				PointerProperties_Helper::unwrap(from.item(i), &(to->ptr[i]));
			}
		}
	}

	static Array_PointerProperties_Struct*
	unwrap(NativeArray<MotionEventGlue::Properties>* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		Array_PointerProperties_Struct* retval = new Array_PointerProperties_Struct();
		Array_PointerProperties_Helper::unwrap(*src, retval);
		return retval;
	}

	static void
	marshalOut(const NativeArray<MotionEventGlue::Properties>& from, Array_PointerProperties_Struct*
		 to)
	{
		assert(from.length() == to->length);
		for(uint32_t i = 0; i < from.length(); i++)
		{
			PointerProperties_Helper::marshalOut(from.item(i), &(to->ptr[i]));
		}
	}

	static void
	wrap(const Array_PointerProperties_Struct& from, NativeArray<MotionEventGlue::Properties>*
		 to)
	{
		assert(from.length == to->length());
		for(uint32_t i = 0; i < from.length; i++)
		{
			PointerProperties_Helper::wrap(from.ptr[i], &(to->item(i)));
		}
	}

	static NativeArray<MotionEventGlue::Properties>*
	wrap(const Array_PointerProperties_Struct* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		NativeArray<MotionEventGlue::Properties>* retval = new NativeArray<MotionEventGlue::Properties>
			(src->length);
		Array_PointerProperties_Helper::wrap(*src, retval);
		return retval;
	}

	static const NativeArray<MotionEventGlue::Properties>*
	wrapConst(const Array_PointerProperties_Struct* src)
	{
		return const_cast<const NativeArray<MotionEventGlue::Properties>*>(Array_PointerProperties_Helper
			::wrap(src));
	}

	static void
	freeMembers(Array_PointerProperties_Struct& obj)
	{
		assert(obj._owner == 0x7380548b);
		{
			for(uint32_t i = 0; i < obj.length; i++)
			{
				PointerProperties_Helper::freeMembers(obj.ptr[i]);
			}
			MarshalHelper::freeArray<PointerProperties_Struct>(obj.ptr, obj.length);
		}
	}

	static void
	destructor(Array_PointerProperties_Struct* obj)
	{
		if (obj == NULL)
		{
			return;
		}
		Array_PointerProperties_Helper::freeMembers(*obj);
		delete obj;
	}


private:
	Array_PointerProperties_Helper();

};

extern "C" DLL_EXPORT void
libxobotos_android_view_MotionEvent_Array_PointerProperties_destructor(Array_PointerProperties_Struct*
	 obj)
{
	Array_PointerProperties_Helper::destructor(obj);
}

struct Array_PointerCoords_Struct
{
	uint32_t _owner;
	uint32_t length;
	PointerCoords_Struct* ptr;
};

class Array_PointerCoords_Helper
{
public:
	static void
	unwrap(NativeArray<MotionEventGlue::Coords>& from, Array_PointerCoords_Struct* to)
	{
		to->_owner = 0x7380548b;
		to->length = from.length();
		{
			to->ptr = MarshalHelper::allocArray<PointerCoords_Struct>(from.length());
			for(uint32_t i = 0; i < from.length(); i++)
			{
				PointerCoords_Helper::unwrap(from.item(i), &(to->ptr[i]));
			}
		}
	}

	static Array_PointerCoords_Struct*
	unwrap(NativeArray<MotionEventGlue::Coords>* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		Array_PointerCoords_Struct* retval = new Array_PointerCoords_Struct();
		Array_PointerCoords_Helper::unwrap(*src, retval);
		return retval;
	}

	static void
	marshalOut(const NativeArray<MotionEventGlue::Coords>& from, Array_PointerCoords_Struct*
		 to)
	{
		assert(from.length() == to->length);
		for(uint32_t i = 0; i < from.length(); i++)
		{
			PointerCoords_Helper::marshalOut(from.item(i), &(to->ptr[i]));
		}
	}

	static void
	wrap(const Array_PointerCoords_Struct& from, NativeArray<MotionEventGlue::Coords>*
		 to)
	{
		assert(from.length == to->length());
		for(uint32_t i = 0; i < from.length; i++)
		{
			PointerCoords_Helper::wrap(from.ptr[i], &(to->item(i)));
		}
	}

	static NativeArray<MotionEventGlue::Coords>*
	wrap(const Array_PointerCoords_Struct* src)
	{
		if (src == NULL)
		{
			return NULL;
		}
		NativeArray<MotionEventGlue::Coords>* retval = new NativeArray<MotionEventGlue::Coords>
			(src->length);
		Array_PointerCoords_Helper::wrap(*src, retval);
		return retval;
	}

	static const NativeArray<MotionEventGlue::Coords>*
	wrapConst(const Array_PointerCoords_Struct* src)
	{
		return const_cast<const NativeArray<MotionEventGlue::Coords>*>(Array_PointerCoords_Helper
			::wrap(src));
	}

	static void
	freeMembers(Array_PointerCoords_Struct& obj)
	{
		assert(obj._owner == 0x7380548b);
		{
			for(uint32_t i = 0; i < obj.length; i++)
			{
				PointerCoords_Helper::freeMembers(obj.ptr[i]);
			}
			MarshalHelper::freeArray<PointerCoords_Struct>(obj.ptr, obj.length);
		}
	}

	static void
	destructor(Array_PointerCoords_Struct* obj)
	{
		if (obj == NULL)
		{
			return;
		}
		Array_PointerCoords_Helper::freeMembers(*obj);
		delete obj;
	}


private:
	Array_PointerCoords_Helper();

};

extern "C" DLL_EXPORT void
libxobotos_android_view_MotionEvent_Array_PointerCoords_destructor(Array_PointerCoords_Struct*
	 obj)
{
	Array_PointerCoords_Helper::destructor(obj);
}


extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getToolType(MotionEventGlue* nativePtr, int pointerIndex)
{
	int _retval = nativePtr->getToolType(pointerIndex);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_offsetLocation(MotionEventGlue* nativePtr, float deltaX, float
	 deltaY)
{
	nativePtr->offsetLocation(deltaX, deltaY);
}

extern "C" DLL_EXPORT bool
libxobotos_MotionEvent_isTouchEvent(MotionEventGlue* nativePtr)
{
	bool _retval = nativePtr->isTouchEvent();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getFlags(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getFlags();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getButtonState(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getButtonState();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_MotionEvent_getYOffset(MotionEventGlue* nativePtr)
{
	float _retval = nativePtr->getYOffset();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getMetaState(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getMetaState();
	return _retval;
}

extern "C" DLL_EXPORT long
libxobotos_MotionEvent_getDownTime(MotionEventGlue* nativePtr)
{
	long _retval = nativePtr->getDownTime();
	return _retval;
}

extern "C" DLL_EXPORT MotionEventGlue*
libxobotos_MotionEvent_initialize(MotionEventGlue* nativePtr, int deviceId, int source,
	int action, int flags, int edgeFlags, int metaState, int buttonState, float xOffset,
	float yOffset, float xPrecision, float yPrecision, long downTimeNanos, long eventTimeNanos,
	int pointerCount, Array_PointerProperties_Struct* pointerIds_ptr, Array_PointerCoords_Struct*
	 pointerCoords_ptr)
{
	const NativeArray<MotionEventGlue::Properties>* pointerIds = Array_PointerProperties_Helper
		::wrapConst(pointerIds_ptr);
	const NativeArray<MotionEventGlue::Coords>* pointerCoords = Array_PointerCoords_Helper
		::wrapConst(pointerCoords_ptr);
	MotionEventGlue* _retval = MotionEventGlue::initialize(nativePtr, deviceId, source,
		action, flags, edgeFlags, metaState, buttonState, xOffset, yOffset, xPrecision, 
		yPrecision, downTimeNanos, eventTimeNanos, pointerCount, *pointerIds, *pointerCoords);
	delete pointerIds;
	delete pointerCoords;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getPointerCount(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getPointerCount();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_scale(MotionEventGlue* nativePtr, float scale)
{
	nativePtr->scale(scale);
}

extern "C" DLL_EXPORT float
libxobotos_MotionEvent_getAxisValue(MotionEventGlue* nativePtr, int axis, int pointerIndex,
	int historyPos)
{
	float _retval = nativePtr->getAxisValue(axis, pointerIndex, historyPos);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getHistorySize(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getHistorySize();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getEdgeFlags(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getEdgeFlags();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_MotionEvent_getXOffset(MotionEventGlue* nativePtr)
{
	float _retval = nativePtr->getXOffset();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_MotionEvent_getXPrecision(MotionEventGlue* nativePtr)
{
	float _retval = nativePtr->getXPrecision();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getSource(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getSource();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getDeviceId(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getDeviceId();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_setFlags(MotionEventGlue* nativePtr, int flags)
{
	nativePtr->setFlags(flags);
}

extern "C" DLL_EXPORT MotionEventGlue*
libxobotos_MotionEvent_copy(MotionEventGlue* destNativePtr, MotionEventGlue* sourceNativePtr,
	bool keepHistory)
{
	MotionEventGlue* _retval = MotionEventGlue::copy(destNativePtr, *sourceNativePtr,
		keepHistory);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_setEdgeFlags(MotionEventGlue* nativePtr, int action)
{
	nativePtr->setEdgeFlags(action);
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_getPointerProperties(MotionEventGlue* nativePtr, int pointerIndex,
	PointerProperties_Struct** outPointerProperties_ptr)
{
	MotionEventGlue::Properties outPointerProperties;
	nativePtr->getPointerProperties(pointerIndex, &outPointerProperties);
	*outPointerProperties_ptr = PointerProperties_Helper::unwrap(&outPointerProperties);
}

extern "C" DLL_EXPORT float
libxobotos_MotionEvent_getRawAxisValue(MotionEventGlue* nativePtr, int axis, int 
	pointerIndex, int historyPos)
{
	float _retval = nativePtr->getRawAxisValue(axis, pointerIndex, historyPos);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getAction(MotionEventGlue* nativePtr)
{
	int _retval = nativePtr->getAction();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_MotionEvent_getYPrecision(MotionEventGlue* nativePtr)
{
	float _retval = nativePtr->getYPrecision();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_setSource(MotionEventGlue* nativePtr, int source)
{
	nativePtr->setSource(source);
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_getPointerCoords(MotionEventGlue* nativePtr, int pointerIndex,
	int historyPos, PointerCoords_Struct** outPointerCoords_ptr)
{
	MotionEventGlue::Coords outPointerCoords;
	nativePtr->getPointerCoords(pointerIndex, historyPos, &outPointerCoords);
	*outPointerCoords_ptr = PointerCoords_Helper::unwrap(&outPointerCoords);
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_getPointerId(MotionEventGlue* nativePtr, int pointerIndex)
{
	int _retval = nativePtr->getPointerId(pointerIndex);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_setAction(MotionEventGlue* nativePtr, int action)
{
	nativePtr->setAction(action);
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_addBatch(MotionEventGlue* nativePtr, long eventTimeNanos, 
	Array_PointerCoords_Struct* pointerCoords_ptr, int metaState)
{
	const NativeArray<MotionEventGlue::Coords>* pointerCoords = Array_PointerCoords_Helper
		::wrapConst(pointerCoords_ptr);
	nativePtr->addBatch(eventTimeNanos, *pointerCoords, metaState);
	delete pointerCoords;
}

extern "C" DLL_EXPORT long
libxobotos_MotionEvent_getEventTimeNanos(MotionEventGlue* nativePtr, int historyPos)
{
	long _retval = nativePtr->getEventTimeNanos(historyPos);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_MotionEvent_findPointerIndex(MotionEventGlue* nativePtr, int pointerId)
{
	int _retval = nativePtr->findPointerIndex(pointerId);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_MotionEvent_setDownTime(MotionEventGlue* nativePtr, long downTime)
{
	nativePtr->setDownTime(downTime);
}

