#include "android.graphics.Rect.h"

struct Rect_Struct
{
	uint32_t _owner;
	int fLeft;
	int fTop;
	int fRight;
	int fBottom;
};

void
Rect_Helper::unwrap(SkIRect& from, Rect_Struct* to)
{
	to->_owner = 0x7380548b;
	to->fLeft = from.fLeft;
	to->fTop = from.fTop;
	to->fRight = from.fRight;
	to->fBottom = from.fBottom;
}

Rect_Struct*
Rect_Helper::unwrap(SkIRect* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Rect_Struct* retval = new Rect_Struct();
	Rect_Helper::unwrap(*src, retval);
	return retval;
}

void
Rect_Helper::marshalOut(const SkIRect& from, Rect_Struct* to)
{
	to->fLeft = from.fLeft;
	to->fTop = from.fTop;
	to->fRight = from.fRight;
	to->fBottom = from.fBottom;
}

void
Rect_Helper::wrap(const Rect_Struct& from, SkIRect* to)
{
	to->fLeft = from.fLeft;
	to->fTop = from.fTop;
	to->fRight = from.fRight;
	to->fBottom = from.fBottom;
}

SkIRect*
Rect_Helper::wrap(const Rect_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	SkIRect* retval = new SkIRect();
	Rect_Helper::wrap(*src, retval);
	return retval;
}

const SkIRect*
Rect_Helper::wrapConst(const Rect_Struct* src)
{
	return const_cast<const SkIRect*>(Rect_Helper::wrap(src));
}

void
Rect_Helper::freeMembers(Rect_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
Rect_Helper::destructor(Rect_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Rect_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_graphics_Rect_Rect_destructor(Rect_Struct* obj)
{
	Rect_Helper::destructor(obj);
}


