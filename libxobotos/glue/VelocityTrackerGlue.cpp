#include <VelocityTrackerGlue.h>

// Special constant to request the velocity of the active pointer.
static const int ACTIVE_POINTER_ID = -1;

void
VelocityTrackerGlue::clear()
{
	mVelocityTracker.clear();
	mActivePointerId = -1;
	mCalculatedIdBits.clear();
}

void
VelocityTrackerGlue::computeCurrentVelocity(int32_t units, float maxVelocity)
{
	BitSet32 idBits(mVelocityTracker.getCurrentPointerIdBits());
	mCalculatedIdBits = idBits;

	for (uint32_t index = 0; !idBits.isEmpty(); index++) {
		uint32_t id = idBits.clearFirstMarkedBit();

		float vx, vy;
		mVelocityTracker.getVelocity(id, &vx, &vy);

		vx = vx * units / 1000;
		vy = vy * units / 1000;

		if (vx > maxVelocity) {
			vx = maxVelocity;
		} else if (vx < -maxVelocity) {
			vx = -maxVelocity;
		}
		if (vy > maxVelocity) {
			vy = maxVelocity;
		} else if (vy < -maxVelocity) {
			vy = -maxVelocity;
		}

		Velocity& velocity = mCalculatedVelocity[index];
		velocity.vx = vx;
		velocity.vy = vy;
	}
}

void
VelocityTrackerGlue::getVelocity(int32_t id, float* outVx, float* outVy)
{
	if (id == ACTIVE_POINTER_ID) {
		id = mVelocityTracker.getActivePointerId();
	}

	float vx, vy;
	if (id >= 0 && id <= MAX_POINTER_ID && mCalculatedIdBits.hasBit(id)) {
		uint32_t index = mCalculatedIdBits.getIndexOfBit(id);
		const Velocity& velocity = mCalculatedVelocity[index];
		vx = velocity.vx;
		vy = velocity.vy;
	} else {
		vx = 0;
		vy = 0;
	}

	if (outVx) {
		*outVx = vx;
	}
	if (outVy) {
		*outVy = vy;
	}
}

float
VelocityTrackerGlue::getXVelocity(int32_t id)
{
	float vx;
	getVelocity(id, &vx, NULL);
	return vx;
}

float
VelocityTrackerGlue::getYVelocity(int32_t id)
{
	float vy;
	getVelocity(id, NULL, &vy);
	return vy;
}

void
VelocityTrackerGlue::addMovement(const MotionEventGlue& event)
{
	mVelocityTracker.addMovement(&event);
}

bool
VelocityTrackerGlue::getEstimator(int32_t id, uint32_t degree, nsecs_t horizon,
				  VelocityTracker::Estimator* outEstimator)
{
	return mVelocityTracker.getEstimator(id, degree, horizon, outEstimator);
}
