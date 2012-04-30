#ifndef ANDROID_VIEW_MOTIONEVENT_GLUE_H
#define ANDROID_VIEW_MOTIONEVENT_GLUE_H 1

#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <MotionEventGlue.h>

struct PointerCoords_Struct;

class PointerCoords_Helper
{
public:
	static void unwrap(MotionEventGlue::Coords& from, PointerCoords_Struct* to);
	static PointerCoords_Struct* unwrap(MotionEventGlue::Coords* src);
	static void marshalOut(const MotionEventGlue::Coords& from, PointerCoords_Struct*
		 to);
	static void wrap(const PointerCoords_Struct& from, MotionEventGlue::Coords* to);
	static MotionEventGlue::Coords* wrap(const PointerCoords_Struct* src);
	static const MotionEventGlue::Coords* wrapConst(const PointerCoords_Struct* src);
	static void freeMembers(PointerCoords_Struct& obj);
	static void destructor(PointerCoords_Struct* obj);

private:
	PointerCoords_Helper();

};

struct PointerProperties_Struct;

class PointerProperties_Helper
{
public:
	static void unwrap(MotionEventGlue::Properties& from, PointerProperties_Struct* to);
	static PointerProperties_Struct* unwrap(MotionEventGlue::Properties* src);
	static void marshalOut(const MotionEventGlue::Properties& from, PointerProperties_Struct*
		 to);
	static void wrap(const PointerProperties_Struct& from, MotionEventGlue::Properties*
		 to);
	static MotionEventGlue::Properties* wrap(const PointerProperties_Struct* src);
	static const MotionEventGlue::Properties* wrapConst(const PointerProperties_Struct*
		 src);
	static void freeMembers(PointerProperties_Struct& obj);
	static void destructor(PointerProperties_Struct* obj);

private:
	PointerProperties_Helper();

};



#endif
