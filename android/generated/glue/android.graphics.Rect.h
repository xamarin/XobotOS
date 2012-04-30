#ifndef ANDROID_GRAPHICS_RECT_GLUE_H
#define ANDROID_GRAPHICS_RECT_GLUE_H 1

#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"

struct Rect_Struct;

class Rect_Helper
{
public:
	static void unwrap(SkIRect& from, Rect_Struct* to);
	static Rect_Struct* unwrap(SkIRect* src);
	static void marshalOut(const SkIRect& from, Rect_Struct* to);
	static void wrap(const Rect_Struct& from, SkIRect* to);
	static SkIRect* wrap(const Rect_Struct* src);
	static const SkIRect* wrapConst(const Rect_Struct* src);
	static void freeMembers(Rect_Struct& obj);
	static void destructor(Rect_Struct* obj);

private:
	Rect_Helper();

};



#endif
