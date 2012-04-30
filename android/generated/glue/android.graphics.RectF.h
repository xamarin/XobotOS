#ifndef ANDROID_GRAPHICS_RECTF_GLUE_H
#define ANDROID_GRAPHICS_RECTF_GLUE_H 1

#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"

struct RectF_Struct;

class RectF_Helper
{
public:
	static void unwrap(SkRect& from, RectF_Struct* to);
	static RectF_Struct* unwrap(SkRect* src);
	static void marshalOut(const SkRect& from, RectF_Struct* to);
	static void wrap(const RectF_Struct& from, SkRect* to);
	static SkRect* wrap(const RectF_Struct* src);
	static const SkRect* wrapConst(const RectF_Struct* src);
	static void freeMembers(RectF_Struct& obj);
	static void destructor(RectF_Struct* obj);

private:
	RectF_Helper();

};



#endif
