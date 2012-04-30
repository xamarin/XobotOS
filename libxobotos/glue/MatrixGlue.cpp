#include <MatrixGlue.h>

MatrixGlue::MatrixGlue(const MatrixGlue* src)
{
	if (src)
		*this = *src;
	else
		reset();
}

void
MatrixGlue::set(const MatrixGlue& src)
{
	*this = src;
}

bool
MatrixGlue::mapRect(SkRect& dst, const SkRect& src)
{
	return SkMatrix::mapRect(&dst, src);
}

bool
MatrixGlue::setPolyToPoly(const NativeArray<float>& src, int srcIndex, const NativeArray<float>& dst,
			  int dstIndex, int ptCount)
{
	return SkMatrix::setPolyToPoly((const SkPoint*)src.ptr(srcIndex, 2 * ptCount),
				       (const SkPoint*)dst.ptr(dstIndex, 2 * ptCount),
				       ptCount);
}

void
MatrixGlue::mapPoints(NativeArray<float>& dst, int dstIndex, const NativeArray<float>& src, int srcIndex,
		      int ptCount, bool isPts)
{
	if (isPts)
		SkMatrix::mapPoints((SkPoint*)dst.ptr(dstIndex, 2 * ptCount),
				    (const SkPoint*)src.ptr(srcIndex, 2 * ptCount),
				    ptCount);
	else
		SkMatrix::mapVectors((SkVector*)dst.ptr(dstIndex, 2 * ptCount),
				     (const SkVector*)src.ptr(srcIndex, 2 * ptCount),
				     ptCount);
}

void
MatrixGlue::getValues(NativeArray<float>& dst)
{
        for (int i = 0; i < 9; i++) {
		dst.item(i) = get(i);
        }
}

void
MatrixGlue::setValues(const NativeArray<float>& src)
{
        for (int i = 0; i < 9; i++) {
		SkMatrix::set(i, src[i]);
        }
}

bool
MatrixGlue::equals(const MatrixGlue& a, const MatrixGlue& b)
{
	return a == b;
}
