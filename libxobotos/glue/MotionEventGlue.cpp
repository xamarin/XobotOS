#include <MotionEventGlue.h>

static const int HISTORY_CURRENT = -0x80000000;

void
MotionEventGlue::coordsToNative (const Coords& src, float xOffset, float yOffset, PointerCoords* outCoords)
{
	outCoords->clear();
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_X, src.x - xOffset);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_Y, src.y - yOffset);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_PRESSURE, src.pressure);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_SIZE, src.size);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_TOUCH_MAJOR, src.touchMajor);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_TOUCH_MINOR, src.touchMinor);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_TOOL_MAJOR, src.toolMajor);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_TOOL_MINOR, src.toolMinor);
	outCoords->setAxisValue(AMOTION_EVENT_AXIS_ORIENTATION, src.orientation);

	uint64_t bits = src.packedAxisBits;
	if (bits) {
		if (src.packedAxisValues) {
			uint32_t index = 0;
			do {
				uint32_t axis = __builtin_ctzll(bits);
				uint64_t axisBit = 1LL << axis;
				bits &= ~axisBit;
				outCoords->setAxisValue(axis, (*src.packedAxisValues)[index++]);
			} while (bits);
		}
	}
}

void
MotionEventGlue::obtainPackedAxisValuesArray(uint32_t minSize, Coords* outCoords)
{
	if (outCoords->packedAxisValues) {
		if (minSize <= outCoords->packedAxisValues->length())
			return;
		delete outCoords->packedAxisValues;
		outCoords->packedAxisValues = NULL;
	}

	uint32_t size = 8;
	while (size < minSize) {
		size *= 2;
	}

	outCoords->packedAxisValues = new NativeArray<float>(size);
}

void
MotionEventGlue::coordsFromNative (const PointerCoords& src, float xOffset, float yOffset, Coords* outCoords)
{
	outCoords->x = src.getAxisValue(AMOTION_EVENT_AXIS_X) + xOffset;
	outCoords->y = src.getAxisValue(AMOTION_EVENT_AXIS_Y) + yOffset;
	outCoords->pressure = src.getAxisValue(AMOTION_EVENT_AXIS_PRESSURE);
	outCoords->size = src.getAxisValue(AMOTION_EVENT_AXIS_SIZE);
	outCoords->touchMajor = src.getAxisValue(AMOTION_EVENT_AXIS_TOUCH_MAJOR);
	outCoords->touchMinor = src.getAxisValue(AMOTION_EVENT_AXIS_TOUCH_MINOR);
	outCoords->toolMajor = src.getAxisValue(AMOTION_EVENT_AXIS_TOOL_MAJOR);
	outCoords->toolMinor = src.getAxisValue(AMOTION_EVENT_AXIS_TOOL_MINOR);
	outCoords->orientation = src.getAxisValue(AMOTION_EVENT_AXIS_ORIENTATION);

	const uint64_t unpackedAxisBits = 0
		| (1LL << AMOTION_EVENT_AXIS_X)
		| (1LL << AMOTION_EVENT_AXIS_Y)
		| (1LL << AMOTION_EVENT_AXIS_PRESSURE)
		| (1LL << AMOTION_EVENT_AXIS_SIZE)
		| (1LL << AMOTION_EVENT_AXIS_TOUCH_MAJOR)
		| (1LL << AMOTION_EVENT_AXIS_TOUCH_MINOR)
		| (1LL << AMOTION_EVENT_AXIS_TOOL_MAJOR)
		| (1LL << AMOTION_EVENT_AXIS_TOOL_MINOR)
		| (1LL << AMOTION_EVENT_AXIS_ORIENTATION);

	uint64_t outBits = 0;
	uint64_t remainingBits = src.bits & ~unpackedAxisBits;
	if (remainingBits) {
		uint32_t packedAxesCount = __builtin_popcountll(remainingBits);

		obtainPackedAxisValuesArray(packedAxesCount, outCoords);
		if (!outCoords->packedAxisValues) {
			return; // OOM
		}

		uint32_t index = 0;
		do {
			uint32_t axis = __builtin_ctzll(remainingBits);
			uint64_t axisBit = 1LL << axis;
			remainingBits &= ~axisBit;
			outBits |= axisBit;
			(*outCoords->packedAxisValues)[index++] = src.getAxisValue(axis);
		} while (remainingBits);
	}

	outCoords->packedAxisBits = outBits;
}

void
MotionEventGlue::propertiesToNative (const Properties& src, PointerProperties* outProperties)
{
	outProperties->clear();
	outProperties->id = src.id;
	outProperties->toolType = src.toolType;
}

void
MotionEventGlue::propertiesFromNative (const PointerProperties& src, Properties* outProperties)
{
	outProperties->id = src.id;
	outProperties->toolType = src.toolType;
}

MotionEventGlue*
MotionEventGlue::initialize(MotionEventGlue* ptr, int deviceId, int source, int action,
			    int flags, int edgeFlags, int metaState, int buttonState,
			    float xOffset, float yOffset, float xPrecision, float yPrecision,
			    long downTimeNanos, long eventTimeNanos, size_t pointerCount,
			    const NativeArray<Properties>& pointerIds,
			    const NativeArray<Coords>& pointerCoords)
{
	if (pointerIds.length() < pointerCount)
		return NULL;
	if (pointerCoords.length() < pointerCount)
		return NULL;

	MotionEventGlue* instance;

	instance = ptr ? ptr : new MotionEventGlue ();

	if (!instance->initialize(deviceId, source, action, flags, edgeFlags, metaState, buttonState,
				  xOffset, yOffset, xPrecision, yPrecision, downTimeNanos, eventTimeNanos,
				  pointerCount, pointerIds, pointerCoords)) {
		if (!ptr)
			delete instance;
		return NULL;
	}

	return instance;
}

bool
MotionEventGlue::initialize(int deviceId, int source, int action, int flags, int edgeFlags,
			    int metaState, int buttonState, float xOffset, float yOffset,
			    float xPrecision, float yPrecision, long downTimeNanos, long eventTimeNanos,
			    size_t pointerCount, const NativeArray<Properties>& pointerIds,
			    const NativeArray<Coords>& pointerCoords)
{
	PointerProperties pointerProperties[pointerCount];
	PointerCoords rawPointerCoords[pointerCount];

	for (size_t i = 0; i < pointerCount; i++) {
		propertiesToNative(pointerIds[i], &pointerProperties[i]);
		coordsToNative(pointerCoords[i], xOffset, yOffset, &rawPointerCoords[i]);
	}

	MotionEvent::initialize(deviceId, source, action, flags, edgeFlags, metaState, buttonState,
				xOffset, yOffset, xPrecision, yPrecision, downTimeNanos, eventTimeNanos,
				pointerCount, pointerProperties, rawPointerCoords);

	return true;
}

MotionEventGlue*
MotionEventGlue::copy(MotionEventGlue* dest, const MotionEventGlue& source, bool keepHistory)
{
	if (!dest)
		dest = new MotionEventGlue ();
	dest->copyFrom(&source, keepHistory);
	return dest;
}

void
MotionEventGlue::addBatch(long eventTimeNanos, const NativeArray<Coords>& pointerCoords, int metaState)
{
	size_t pointerCount = getPointerCount();
	if (pointerCoords.length() < pointerCount)
		return;

	PointerCoords rawPointerCoords[pointerCount];

	for (size_t i = 0; i < pointerCount; i++) {
		coordsToNative(pointerCoords[i], getXOffset(), getYOffset(), &rawPointerCoords[i]);
	}

	addSample(eventTimeNanos, rawPointerCoords);
	setMetaState(getMetaState() | metaState);
}

long
MotionEventGlue::getEventTimeNanos(int historyPos)
{
	if (historyPos == HISTORY_CURRENT) {
		return getEventTime();
	} else {
		size_t historySize = getHistorySize();
		if (historyPos < 0 || size_t(historyPos) >= historySize)
			return 0;
		return getHistoricalEventTime(historyPos);
	}
}

float
MotionEventGlue::getRawAxisValue(int axis, int pointerIndex, int historyPos)
{
	size_t pointerCount = getPointerCount();
	if (pointerIndex < 0 || size_t(pointerIndex) >= pointerCount)
		return 0;

	if (historyPos == HISTORY_CURRENT) {
		return MotionEvent::getRawAxisValue(axis, pointerIndex);
	} else {
		size_t historySize = getHistorySize();
		if (historyPos < 0 || size_t(historyPos) >= historySize)
			return 0;
		return getHistoricalRawAxisValue(axis, pointerIndex, historyPos);
	}
}

float
MotionEventGlue::getAxisValue(int axis, int pointerIndex, int historyPos)
{
	size_t pointerCount = getPointerCount();
	if (pointerIndex < 0 || size_t(pointerIndex) >= pointerCount)
		return 0;

	if (historyPos == HISTORY_CURRENT) {
		return MotionEvent::getAxisValue(axis, pointerIndex);
	} else {
		size_t historySize = getHistorySize();
		if (historyPos < 0 || size_t(historyPos) >= historySize)
			return 0;
		return getHistoricalAxisValue(axis, pointerIndex, historyPos);
	}
}

void
MotionEventGlue::getPointerCoords(int pointerIndex, int historyPos, MotionEventGlue::Coords* outCoords)
{
	size_t pointerCount = getPointerCount();
	SkASSERT (pointerIndex >= 0 && size_t(pointerIndex) < pointerCount);

	const PointerCoords* rawPointerCoords;
	if (historyPos == HISTORY_CURRENT) {
		rawPointerCoords = getRawPointerCoords(pointerIndex);
	} else {
		size_t historySize = getHistorySize();
		SkASSERT (historyPos >= 0 && size_t(historyPos) < historySize);
		rawPointerCoords = getHistoricalRawPointerCoords(pointerIndex, historyPos);
	}

	coordsFromNative(*rawPointerCoords, getXOffset(), getYOffset(), outCoords);
}

void
MotionEventGlue::getPointerProperties(int pointerIndex, Properties* outProperties)
{
	size_t pointerCount = getPointerCount();
	SkASSERT (pointerIndex >= 0 && size_t(pointerIndex) < pointerCount);

	const PointerProperties* rawPointerProperties = MotionEvent::getPointerProperties(pointerIndex);
	propertiesFromNative(*rawPointerProperties, outProperties);
}
