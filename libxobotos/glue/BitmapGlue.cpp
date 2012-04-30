#include <BitmapGlue.h>
#include <SkPixelRef.h>
#include <SkColorPriv.h>
#include <SkDither.h>
#include <SkUnPreMultiply.h>

///////////////////////////////////////////////////////////////////////////////
// Conversions to/from SkColor, for get/setPixels, and the create method, which
// is basically like setPixels

typedef void (*FromColorProc)(void* dst, const SkColor src[], int width, int x, int y);

static void FromColor_D32(void* dst, const SkColor src[], int width, int, int) {
	SkPMColor* d = (SkPMColor*)dst;

	for (int i = 0; i < width; i++) {
		*d++ = SkPreMultiplyColor(*src++);
	}
}

static void FromColor_D565(void* dst, const SkColor src[], int width, int x, int y) {
	uint16_t* d = (uint16_t*)dst;

	DITHER_565_SCAN(y);
	for (int stop = x + width; x < stop; x++) {
		SkColor c = *src++;
		*d++ = SkDitherRGBTo565(SkColorGetR(c), SkColorGetG(c), SkColorGetB(c),
					DITHER_VALUE(x));
	}
}

static void FromColor_D4444(void* dst, const SkColor src[], int width,
                            int x, int y) {
	SkPMColor16* d = (SkPMColor16*)dst;

	DITHER_4444_SCAN(y);
	for (int stop = x + width; x < stop; x++) {
		SkPMColor c = SkPreMultiplyColor(*src++);
		*d++ = SkDitherARGB32To4444(c, DITHER_VALUE(x));
		//        *d++ = SkPixel32ToPixel4444(c);
	}
}

// can return NULL
static FromColorProc ChooseFromColorProc(SkBitmap::Config config) {
	switch (config) {
        case SkBitmap::kARGB_8888_Config:
		return FromColor_D32;
        case SkBitmap::kARGB_4444_Config:
		return FromColor_D4444;
        case SkBitmap::kRGB_565_Config:
		return FromColor_D565;
        default:
		break;
	}
	return NULL;
}

//////////////////// ToColor procs

typedef void (*ToColorProc)(SkColor dst[], const void* src, int width, SkColorTable*);

static void ToColor_S32_Alpha(SkColor dst[], const void* src, int width,
                              SkColorTable*) {
	SkASSERT(width > 0);
	const SkPMColor* s = (const SkPMColor*)src;
	do {
		*dst++ = SkUnPreMultiply::PMColorToColor(*s++);
	} while (--width != 0);
}

static void ToColor_S32_Opaque(SkColor dst[], const void* src, int width,
                               SkColorTable*) {
	SkASSERT(width > 0);
	const SkPMColor* s = (const SkPMColor*)src;
	do {
		SkPMColor c = *s++;
		*dst++ = SkColorSetRGB(SkGetPackedR32(c), SkGetPackedG32(c),
				       SkGetPackedB32(c));
	} while (--width != 0);
}

static void ToColor_S4444_Alpha(SkColor dst[], const void* src, int width,
                                SkColorTable*) {
	SkASSERT(width > 0);
	const SkPMColor16* s = (const SkPMColor16*)src;
	do {
		*dst++ = SkUnPreMultiply::PMColorToColor(SkPixel4444ToPixel32(*s++));
	} while (--width != 0);
}

static void ToColor_S4444_Opaque(SkColor dst[], const void* src, int width,
                                 SkColorTable*) {
	SkASSERT(width > 0);
	const SkPMColor* s = (const SkPMColor*)src;
	do {
		SkPMColor c = SkPixel4444ToPixel32(*s++);
		*dst++ = SkColorSetRGB(SkGetPackedR32(c), SkGetPackedG32(c),
				       SkGetPackedB32(c));
	} while (--width != 0);
}

static void ToColor_S565(SkColor dst[], const void* src, int width,
                         SkColorTable*) {
	SkASSERT(width > 0);
	const uint16_t* s = (const uint16_t*)src;
	do {
		uint16_t c = *s++;
		*dst++ =  SkColorSetRGB(SkPacked16ToR32(c), SkPacked16ToG32(c),
					SkPacked16ToB32(c));
	} while (--width != 0);
}

static void ToColor_SI8_Alpha(SkColor dst[], const void* src, int width,
                              SkColorTable* ctable) {
	SkASSERT(width > 0);
	const uint8_t* s = (const uint8_t*)src;
	const SkPMColor* colors = ctable->lockColors();
	do {
		*dst++ = SkUnPreMultiply::PMColorToColor(colors[*s++]);
	} while (--width != 0);
	ctable->unlockColors(false);
}

static void ToColor_SI8_Opaque(SkColor dst[], const void* src, int width,
                               SkColorTable* ctable) {
	SkASSERT(width > 0);
	const uint8_t* s = (const uint8_t*)src;
	const SkPMColor* colors = ctable->lockColors();
	do {
		SkPMColor c = colors[*s++];
		*dst++ = SkColorSetRGB(SkGetPackedR32(c), SkGetPackedG32(c),
				       SkGetPackedB32(c));
	} while (--width != 0);
	ctable->unlockColors(false);
}

// can return NULL
static ToColorProc ChooseToColorProc(const SkBitmap& src) {
	switch (src.config()) {
        case SkBitmap::kARGB_8888_Config:
		return src.isOpaque() ? ToColor_S32_Opaque : ToColor_S32_Alpha;
        case SkBitmap::kARGB_4444_Config:
		return src.isOpaque() ? ToColor_S4444_Opaque : ToColor_S4444_Alpha;
        case SkBitmap::kRGB_565_Config:
		return ToColor_S565;
        case SkBitmap::kIndex8_Config:
		if (src.getColorTable() == NULL) {
			return NULL;
		}
		return src.isOpaque() ? ToColor_SI8_Opaque : ToColor_SI8_Alpha;
        default:
		break;
	}
	return NULL;
}

///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////

void
BitmapGlue::recycle()
{
#ifdef USE_OPENGL_RENDERER
	if (android::uirenderer::Caches::hasInstance()) {
		android::uirenderer::Caches::getInstance().resourceCache.recycle(this);
		return;
	}
#endif // USE_OPENGL_RENDERER
	SkBitmap::setPixels(NULL, NULL);
}

bool
BitmapGlue::hasAlpha()
{
	return !isOpaque();
}

void
BitmapGlue::setHasAlpha(bool hasAlpha)
{
	setIsOpaque(!hasAlpha);
}

int
BitmapGlue::getPixel(int x, int y)
{
	SkAutoLockPixels alp(*this);

	ToColorProc proc = ChooseToColorProc(*this);
	if (NULL == proc) {
		return 0;
	}
	const void* src = getAddr(x, y);
	if (NULL == src) {
		return 0;
	}

	SkColor dst[1];
	proc(dst, src, 1, getColorTable());
	return dst[0];
}

void
BitmapGlue::setPixel(int x, int y, SkColor color)
{
	SkAutoLockPixels alp(*this);
	if (NULL == getPixels()) {
		return;
	}

	FromColorProc proc = ChooseFromColorProc(config());
	if (NULL == proc) {
		return;
	}

	proc(getAddr(x, y), &color, 1, x, y);
	notifyPixelsChanged();
}

bool
BitmapGlue::sameAs(const SkBitmap& other)
{
	if (width() != other.width() ||
	    height() != other.height() ||
	    config() != other.config()) {
		return false;
	}

	SkAutoLockPixels alp0(*this);
	SkAutoLockPixels alp1(other);

	// if we can't load the pixels, return false
	if (NULL == getPixels() || NULL == other.getPixels()) {
		return false;
	}

	if (config() == SkBitmap::kIndex8_Config) {
		SkColorTable* ct0 = getColorTable();
		SkColorTable* ct1 = other.getColorTable();
		if (NULL == ct0 || NULL == ct1) {
			return false;
		}
		if (ct0->count() != ct1->count()) {
			return false;
		}

		SkAutoLockColors alc0(ct0);
		SkAutoLockColors alc1(ct1);
		const size_t size = ct0->count() * sizeof(SkPMColor);
		if (memcmp(alc0.colors(), alc1.colors(), size) != 0) {
			return false;
		}
	}

	// now compare each scanline. We can't do the entire buffer at once,
	// since we don't care about the pixel values that might extend beyond
	// the width (since the scanline might be larger than the logical width)
	const int h = height();
	const size_t size = width() * bytesPerPixel();
	for (int y = 0; y < h; y++) {
		if (memcmp(getAddr(0, y), other.getAddr(0, y), size) != 0) {
			return false;
		}
	}
	return true;
}

void
BitmapGlue::prepareToDraw()
{
	lockPixels();
	unlockPixels();
}

bool
BitmapGlue::setPixels(const NativeArray<int>& colors, int offset, int stride,
		      int x, int y, int width, int height)
{
	SkAutoLockPixels alp(*this);
	void* dst = getPixels();
	FromColorProc proc = ChooseFromColorProc(config());

	if (colors.length() < SkAbs32(stride) * (size_t)height)
		return false;

	if (NULL == dst || NULL == proc) {
		return false;
	}

	const SkColor* src = (const SkColor*)&colors.item(offset);

	// reset to to actual choice from caller
	dst = getAddr(x, y);
	// now copy/convert each scanline
	for (int y = 0; y < height; y++) {
		proc(dst, src, width, x, y);
		src += stride;
		dst = (char*)dst + rowBytes();
	}

	notifyPixelsChanged();

	return true;
}

BitmapGlue::BitmapGlue(bool is_mutable) : SkBitmap()
{
	_is_mutable = is_mutable;
}

BitmapGlue::BitmapGlue(const BitmapGlue& src) : SkBitmap(src)
{
	_is_mutable = src._is_mutable;
}

BitmapGlue::BitmapGlue(const NativeArray<int>* colors, int offset, int stride,
		       int width, int height, SkBitmap::Config config, bool isMutable)
{
	_is_mutable = isMutable;

	if (colors)
		SkASSERT(colors->length() >= SkAbs32(stride) * (size_t)height);

	setConfig(config, width, height);

	allocPixels();

	if (colors)
		setPixels(*colors, offset, stride, 0, 0, width, height);
}

BitmapGlue*
BitmapGlue::copy(SkBitmap::Config dst_config, bool is_mutable)
{
	BitmapGlue* result = new BitmapGlue(is_mutable);

	if (!copyTo(result, dst_config, NULL)) {
		delete result;
		return NULL;
	}

	return result;
}

BitmapGlue*
BitmapGlue::extractAlpha(const SkPaint* paint, NativeArray<int>* offsets)
{
	SkIPoint  offset;
	BitmapGlue* dst = new BitmapGlue();

	SkBitmap::extractAlpha(dst, paint, NULL, &offset);
	// If Skia can't allocate pixels for destination bitmap, it resets
	// it, that is set its pixels buffer to NULL, and zero width and height.
	if (dst->getPixels() == NULL && getPixels() != NULL) {
		delete dst;
		return NULL;
	}

	if (offsets && (offsets->length() >= 2)) {
		offsets->item(0) = offset.fX;
		offsets->item(1) = offset.fY;
	}

	return dst;
}

void*
BitmapGlue::getPixels() const
{
	return SkBitmap::getPixels();
}

void
BitmapGlue::getPixels(NativeArray<int>& pixel_array, int offset, int stride,
		      int x, int y, int width, int height)
{
	SkAutoLockPixels alp(*this);

	ToColorProc proc = ChooseToColorProc(*this);
	if (NULL == proc) {
		return;
	}
	const void* src = getAddr(x, y);
	if (NULL == src) {
		return;
	}

	SkColorTable* ctable = getColorTable();
	int d = offset;
	while (--height >= 0) {
		proc((SkColor*)&pixel_array.item(d), src, width, ctable);
		d += stride;
		src = (void*)((const char*)src + rowBytes());
	}
}
