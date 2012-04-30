#ifndef VELOCITY_TRACKER_GLUE_H
#define VELOCITY_TRACKER_GLUE_H

#include <libxobotos.h>
#include <MotionEventGlue.h>

using namespace android;

class VelocityTrackerGlue
{
public:
	void clear();
	void computeCurrentVelocity(int32_t units, float maxVelocity);
	float getXVelocity(int32_t id);
	float getYVelocity(int32_t id);
	void addMovement(const MotionEventGlue& event);
	bool getEstimator(int32_t id, uint32_t degree, nsecs_t horizon,
			  VelocityTracker::Estimator* outEstimator);

protected:
	void getVelocity(int32_t id, float* outVx, float* outVy);

private:
	struct Velocity {
		float vx, vy;
	};

	VelocityTracker mVelocityTracker;
	int32_t mActivePointerId;
	BitSet32 mCalculatedIdBits;
	Velocity mCalculatedVelocity[MAX_POINTERS];
};

#endif
