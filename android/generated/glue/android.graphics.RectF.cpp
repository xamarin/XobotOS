#include "android.graphics.RectF.h"

struct RectF_Struct
{
	uint32_t _owner;
	float fLeft;
	float fTop;
	float fRight;
	float fBottom;
};

void
RectF_Helper::unwrap(SkRect& from, RectF_Struct* to)
{
	to->_owner = 0x7380548b;
	to->fLeft = from.fLeft;
	to->fTop = from.fTop;
	to->fRight = from.fRight;
	to->fBottom = from.fBottom;
}

RectF_Struct*
RectF_Helper::unwrap(SkRect* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	RectF_Struct* retval = new RectF_Struct();
	RectF_Helper::unwrap(*src, retval);
	return retval;
}

void
RectF_Helper::marshalOut(const SkRect& from, RectF_Struct* to)
{
	to->fLeft = from.fLeft;
	to->fTop = from.fTop;
	to->fRight = from.fRight;
	to->fBottom = from.fBottom;
}

void
RectF_Helper::wrap(const RectF_Struct& from, SkRect* to)
{
	to->fLeft = from.fLeft;
	to->fTop = from.fTop;
	to->fRight = from.fRight;
	to->fBottom = from.fBottom;
}

SkRect*
RectF_Helper::wrap(const RectF_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	SkRect* retval = new SkRect();
	RectF_Helper::wrap(*src, retval);
	return retval;
}

const SkRect*
RectF_Helper::wrapConst(const RectF_Struct* src)
{
	return const_cast<const SkRect*>(RectF_Helper::wrap(src));
}

void
RectF_Helper::freeMembers(RectF_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
RectF_Helper::destructor(RectF_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	RectF_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_graphics_RectF_RectF_destructor(RectF_Struct* obj)
{
	RectF_Helper::destructor(obj);
}


