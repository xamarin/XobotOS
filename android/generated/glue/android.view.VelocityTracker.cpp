#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <VelocityTrackerGlue.h>
#include <MotionEventGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_view_VelocityTracker_destructor(VelocityTrackerGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT VelocityTrackerGlue*
libxobotos_VelocityTracker_nativeInitialize()
{
	VelocityTrackerGlue* _retval = new VelocityTrackerGlue();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_VelocityTracker_getXVelocity(VelocityTrackerGlue* ptr, int id)
{
	float _retval = ptr->getXVelocity(id);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_VelocityTracker_addMovement(VelocityTrackerGlue* ptr, MotionEventGlue*
	 event)
{
	ptr->addMovement(*event);
}

extern "C" DLL_EXPORT void
libxobotos_VelocityTracker_clear(VelocityTrackerGlue* ptr)
{
	ptr->clear();
}

extern "C" DLL_EXPORT float
libxobotos_VelocityTracker_getYVelocity(VelocityTrackerGlue* ptr, int id)
{
	float _retval = ptr->getYVelocity(id);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_VelocityTracker_computeCurrentVelocity(VelocityTrackerGlue* ptr, int units,
	float maxVelocity)
{
	ptr->computeCurrentVelocity(units, maxVelocity);
}

