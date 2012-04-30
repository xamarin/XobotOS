#include <PaintGlue.h>
#include <SkBlurDrawLooper.h>

PaintGlue::PaintGlue()
{
	setTextEncoding(SkPaint::kUTF16_TextEncoding);
}

PaintGlue::PaintGlue(const PaintGlue& paint) : SkPaint(paint)
{
	setTextEncoding(SkPaint::kUTF16_TextEncoding);
}

void
PaintGlue::setShadowLayer(float radius, float dx, float dy, SkColor color)
{
	if (radius <= 0) {
		setLooper(NULL);
        } else {
		setLooper(new SkBlurDrawLooper(SkFloatToScalar(radius),
					       SkFloatToScalar(dx),
					       SkFloatToScalar(dy),
					       color))->unref();
        }
}

float
PaintGlue::ascent()
{
        SkPaint::FontMetrics metrics;
	getFontMetrics(&metrics);
        return SkScalarToFloat(metrics.fAscent);
}

float
PaintGlue::descent()
{
        SkPaint::FontMetrics metrics;
	getFontMetrics(&metrics);
        return SkScalarToFloat(metrics.fDescent);
}

void
PaintGlue::set(const PaintGlue src)
{
	*this = src;
}

int
PaintGlue::getFontMetricsInt(FontMetricsInt* fmi)
{
	SkPaint::FontMetrics metrics;
	getFontMetrics(&metrics);
	fmi->top = SkScalarFloor(metrics.fTop);
	fmi->ascent = SkScalarRound(metrics.fAscent);
	fmi->descent = SkScalarRound(metrics.fDescent);
	fmi->leading = SkScalarRound(metrics.fLeading);
	fmi->bottom = SkScalarCeil(metrics.fBottom);
	return fmi->descent - fmi->ascent + fmi->leading;
}

int
PaintGlue::breakText(const NativeArray<char16_t>& text, int index, int count, float maxWidth,
		     NativeArray<float>* measuredWidth, SkPaint::TextBufferDirection tbd)
{
	SkASSERT(getTextEncoding() == SkPaint::kUTF16_TextEncoding);

        SkScalar     measured;
        size_t       bytes = SkPaint::breakText(text.ptr(index, count), count << 1, SkFloatToScalar(maxWidth), &measured, tbd);
        SkASSERT((bytes & 1) == 0);

        if (measuredWidth && measuredWidth->length() > 0) {
		measuredWidth->item(0) = SkScalarToFloat(measured);
        }
        return bytes >> 1;
}

int
PaintGlue::breakTextC(const NativeArray<char16_t>& chars, int index, int count, float maxWidth,
		      NativeArray<float>* measuredWidth)
{
        SkPaint::TextBufferDirection tbd;
        if (count < 0) {
            tbd = SkPaint::kBackward_TextBufferDirection;
            count = -count;
        } else {
            tbd = SkPaint::kForward_TextBufferDirection;
        }

	SkASSERT((index >= 0) && (index + count <= (int)chars.length()));

        return breakText(chars, index, count, maxWidth, measuredWidth, tbd);
}

int
PaintGlue::breakTextS(const NativeString& text, bool measureForwards, float maxWidth,
		      NativeArray<float>* measuredWidth)
{
        SkPaint::TextBufferDirection tbd = measureForwards ?
		SkPaint::kForward_TextBufferDirection :
		SkPaint::kBackward_TextBufferDirection;

        return breakText(text, 0, text.length(), maxWidth, measuredWidth, tbd);
}

float
PaintGlue::measureTextC(const NativeArray<char16_t>& chars, int index, int count)
{
	SkASSERT(((index | count) >= 0) && (index + count <= (int)chars.length()));

	if (count == 0)
		return 0;

#if RTL_USE_HARFBUZZ
        float result = 0;
        TextLayout::getTextRunAdvances(this, chars, index, count, chars.length(),
				       getFlags(), NULL /* dont need all advances */, &result);
	return result;
#else
        // we double count, since measureText wants a byteLength
        return SkPaint::measureText(chars.ptr(index,count), count << 1);
#endif
}

float
PaintGlue::measureTextS(const NativeString& text, int start, int end)
{
        int count = end - start;
	SkASSERT(((start | count) >= 0) && (end <= (int)text.length()));

	if (count == 0)
		return 0;

#if RTL_USE_HARFBUZZ
        float width = 0;
        TextLayout::getTextRunAdvances(this, text, start, count, text.length(),
				       getFlags(), NULL /* dont need all advances */, &width);
	return width;
#else
	return SkPaint::measureText(text.ptr(start,count), count << 1);
#endif
}

float
PaintGlue::measureTextS2(const NativeString& text)
{
        if (text.length() == 0)
		return 0;

#if RTL_USE_HARFBUZZ
        float width = 0;
        TextLayout::getTextRunAdvances(this, text, 0, text.length(), text.length(),
				       getFlags(), NULL /* dont need all advances */, &width);
	return width;
#else
        return SkPaint::measureText(text.ptr(0,text.length()), text.length() << 1);
#endif
}

SkIRect
PaintGlue::doTextBounds(const NativeArray<char16_t>& text, int start, int count)
{
        SkRect  r;
        SkIRect ir;

	SkPaint::measureText(text.ptr(start,count), count << 1, &r);
        r.roundOut(&ir);
	return ir;
}

void
PaintGlue::getStringBounds(const NativeString& text, int start, int end, SkIRect* bounds)
{
	SkASSERT((start >= 0) && (end >= start) && (start + end <= (int)text.length()));
	*bounds = doTextBounds(text, start, end - start);
}

void
PaintGlue::getCharArrayBounds(const NativeArray<char16_t>& chars, int index, int count, SkIRect* bounds)
{
	SkASSERT((index >= 0) && (count >= 0) && (index + count <= (int)chars.length()));
        *bounds = doTextBounds(chars, index, count);
}

int
PaintGlue::dotextwidths(const NativeArray<char16_t>& chars, int index, int count, NativeArray<float>& widths)
{
	SkASSERT((count >= 0) && (count <= (int)widths.length()));

        if (count == 0)
		return 0;

#if RTL_USE_HARFBUZZ
        TextLayout::getTextRunAdvances(this, text, 0, count, count,
				       getFlags(), widths.ptr(0,count), NULL /* dont need totalAdvance */);
#else
        count = SkPaint::getTextWidths(chars.ptr(index,count), count << 1, widths.ptr(0,count));
#endif
        return count;
}

int
PaintGlue::getTextWidthsC(const NativeArray<char16_t>& chars, int index, int count, NativeArray<float>& widths)
{
        return dotextwidths(chars, index, count, widths);
}

int
PaintGlue::getTextWidthsS(const NativeString& text, int start, int end, NativeArray<float>& widths)
{
        return dotextwidths(text, start, end - start, widths);
}

void
PaintGlue::getTextPathC(int, const NativeArray<char16_t>& chars, int index, int count,
			float x, float y, PathGlue* path)
{
	SkPaint::getTextPath(chars.ptr(index,count), count, x, y, path);
}

void
PaintGlue::getTextPathS(int, const NativeString& text, int start, int end,
			float x, float y, PathGlue* path)
{
	SkPaint::getTextPath(text.ptr(start,end-start), end - start, x, y, path);
}

float
PaintGlue::TextLayout_computeAdvancesWithICU(const NativeArray<char16_t>& text, size_t index, size_t count,
					     float* out_advances)
{
	size_t widths = SkPaint::getTextWidths(text.ptr(index,count), count << 1, out_advances);

	float total_advance = 0;
	if (widths < count) {
		// Skia operates on code points, not code units, so surrogate pairs return only
		// one value. Expand the result so we have one value per UTF-16 code unit.

		// Note, skia's getTextWidth gets confused if it encounters a surrogate pair,
		// leaving the remaining widths zero.  Not nice.
		for (size_t i = 0, p = 0; i < widths; ++i) {
			total_advance += out_advances[p++];
#if 0
			if (p < count &&
			    text[p] >= UNICODE_FIRST_LOW_SURROGATE &&
			    text[p] < UNICODE_FIRST_PRIVATE_USE &&
			    text[p-1] >= UNICODE_FIRST_HIGH_SURROGATE &&
			    text[p-1] < UNICODE_FIRST_LOW_SURROGATE) {
				out_advances[p++] = 0;
			}
#endif
		}
	} else {
		for (size_t i = 0; i < count; i++) {
			total_advance += out_advances[i];
		}
	}
	return total_advance;
}


float
PaintGlue::doTextRunAdvances(const NativeArray<char16_t>& text, int index, int count,
			     int context_idx, int context_count, int flags,
			     int advances_idx, NativeArray<float>* advances)
{
	SkASSERT((count >= 0) && (context_count >= 0) && (advances_idx >= 0));
	SkASSERT (context_count >= count);

        if (count == 0)
		return 0;

        float advances_array[count];

        if (advances)
		SkASSERT(advances->length() >= (size_t)count);

        float total_advance;

        total_advance = TextLayout_computeAdvancesWithICU(text, index, (size_t)count, advances_array);

	if (advances)
		memcpy (advances->ptr(0, count), advances_array, count * sizeof(float));

	return total_advance;
}

float
PaintGlue::getTextRunAdvancesC(const NativeArray<char16_t>& chars, int index, int count,
			       int context_idx, int context_count, int flags,
			       NativeArray<float>* advances, int advances_idx, int reserved)
{
	return doTextRunAdvances(chars, index, count, context_idx, context_count, flags,
				 advances_idx, advances);
}

float
PaintGlue::getTextRunAdvancesS(const NativeString& text, int start, int end,
			       int context_start, int context_end, int flags,
			       NativeArray<float>* advances, int advances_idx, int reserved)
{
	return doTextRunAdvances(text, start, end - start, context_start, context_end - context_start, flags,
				 advances_idx, advances);
}

int
PaintGlue::doTextRunCursor(const NativeArray<char16_t>& chars, int start, int count, int offset, MoveOpt opt)
{
	float scalarArray[count];

        int widths = SkPaint::getTextWidths(chars.ptr(start,count), count << 1, scalarArray);

        if (widths < count) {
		// Skia operates on code points, not code units, so surrogate pairs return only one
		// value. Expand the result so we have one value per UTF-16 code unit.

		// Note, skia's getTextWidth gets confused if it encounters a surrogate pair,
		// leaving the remaining widths zero.  Not nice.
		for (int i = count, p = widths - 1; --i > p;) {
			if (chars[start+i] >= 0xdc00 && chars[start+i] < 0xe000 &&
			    chars[start+i-1] >= 0xd800 && chars[start+i-1] < 0xdc00) {
				scalarArray[i] = 0;
			} else {
				scalarArray[i] = scalarArray[--p];
			}
		}
        }

        int pos = offset - start;
        switch (opt) {
        case AFTER:
		if (pos < count) {
			pos += 1;
		}
		// fall through
        case AT_OR_AFTER:
		while (pos < count && scalarArray[pos] == 0) {
			++pos;
		}
		break;
        case BEFORE:
		if (pos > 0) {
			--pos;
		}
		// fall through
        case AT_OR_BEFORE:
		while (pos > 0 && scalarArray[pos] == 0) {
			--pos;
		}
		break;
        case AT:
        default:
		if (scalarArray[pos] == 0) {
			pos = -1;
		}
		break;
        }

        if (pos != -1) {
		pos += start;
        }

        return pos;
}

int
PaintGlue::getTextRunCursorC(const NativeArray<char16_t>& chars, int context_start, int context_count,
			     int flags, int offset, int opt)
{
	return doTextRunCursor(chars, context_start, context_count, offset, (MoveOpt)opt);
}

int
PaintGlue::getTextRunCursorS(const NativeString& text, int context_start, int context_end,
			     int flags, int offset, int opt)
{
	return doTextRunCursor(text, context_start, context_end - context_start, offset, (MoveOpt)opt);
}

void
PaintGlue::setShader(SkShader* shader)
{
	SkPaint::setShader(shader);
}

void
PaintGlue::setColorFilter(SkColorFilter* filter)
{
	SkPaint::setColorFilter(filter);
}

void
PaintGlue::setXfermode(SkXfermode* xfermode)
{
	SkPaint::setXfermode(xfermode);
}

void
PaintGlue::setPathEffect(SkPathEffect* effect)
{
	SkPaint::setPathEffect(effect);
}

void
PaintGlue::setMaskFilter(SkMaskFilter* maskfilter)
{
	SkPaint::setMaskFilter(maskfilter);
}

void
PaintGlue::setTypeface(SkTypeface* typeface)
{
	SkPaint::setTypeface(typeface);
}

void
PaintGlue::setRasterizer(SkRasterizer* rasterizer)
{
	SkPaint::setRasterizer(rasterizer);
}
