#ifndef MOTION_EVENT_GLUE_H
#define MOTION_EVENT_GLUE_H

#include <libxobotos.h>
#include <MatrixGlue.h>
#include <ui/Input.h>

using namespace android;

class MotionEventGlue : public MotionEvent
{
public:
	struct Coords
	{
	public:
		long packedAxisBits;
		NativeArray<float>* packedAxisValues;
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

	struct Properties
	{
		int id;
		int toolType;
	};

	static MotionEventGlue* initialize(MotionEventGlue* ptr, int deviceId, int source, int action,
					   int flags, int edgeFlags, int metaState, int buttonState,
					   float xOffset, float yOffset, float xPrecision, float yPrecision,
					   long downTimeNanos, long eventTimeNanos, size_t pointerCount,
					   const NativeArray<Properties>& pointerIds,
					   const NativeArray<Coords>& pointerCoords);
	static MotionEventGlue* copy(MotionEventGlue* dest, const MotionEventGlue& source, bool keepHistory);
	void addBatch(long eventTimeNanos, const NativeArray<Coords>& pointerCoords, int metaState);
	long getEventTimeNanos(int historyPos);
	float getRawAxisValue(int axis, int pointerIndex, int historyPos);
	float getAxisValue(int axis, int pointerIndex, int historyPos);
	void getPointerCoords(int pointerIndex, int historyPos, Coords* outCoords);
	void getPointerProperties(int pointerIndex, Properties* outProperties);

private:
	static void coordsToNative (const Coords& src, float xOffset, float yOffset, PointerCoords *outCoords);
	static void coordsFromNative (const PointerCoords& src, float xOffset, float yOffset, Coords* outCoords);
	static void obtainPackedAxisValuesArray(uint32_t minSize, Coords* outCoords);

	static void propertiesToNative (const Properties& src, PointerProperties* outProperties);
	static void propertiesFromNative (const PointerProperties& src, Properties* outProperties);

	bool initialize(int deviceId, int source, int action, int flags, int edgeFlags, int metaState,
			int buttonState, float xOffset, float yOffset, float xPrecision, float yPrecision,
			long downTimeNanos, long eventTimeNanos, size_t pointerCount,
			const NativeArray<Properties>& pointerIds,
			const NativeArray<Coords>& pointerCoords);

	MotionEventGlue() { }
};

#endif
