#include <InterpolatorGlue.h>
#include <SkTemplates.h>

InterpolatorGlue::InterpolatorGlue(int value_count, int frame_count) : SkInterpolator(value_count, frame_count)
{ }

void
InterpolatorGlue::setKeyFrame(int index, int msec, const NativeArray<float>& valueArray,
			      const NativeArray<float>* blendArray)
{
	SkInterpolator::setKeyFrame(index, msec, valueArray.ptr(0, valueArray.length()),
				    blendArray ? blendArray->ptr(0,4) : NULL);
}

void
InterpolatorGlue::setRepeatMirror(float repeat_count, bool mirror)
{
	if (repeat_count > 32000)
		repeat_count = 32000;

	SkInterpolator::setRepeatCount(repeat_count);
	SkInterpolator::setMirror(mirror);
}

int
InterpolatorGlue::timeToValues(int msec, NativeArray<float>* values)
{
	return SkInterpolator::timeToValues(msec, values ? values->ptr(0, fElemCount) : NULL);
}

