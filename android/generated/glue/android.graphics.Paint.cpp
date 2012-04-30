#include "android.graphics.Paint.h"

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Paint_destructor(PaintGlue* ptr)
{
	delete ptr;
}

struct FontMetrics_Struct
{
	uint32_t _owner;
	float fTop;
	float fAscent;
	float fDescent;
	float fBottom;
	float fLeading;
};

void
FontMetrics_Helper::unwrap(SkPaint::FontMetrics& from, FontMetrics_Struct* to)
{
	to->_owner = 0x7380548b;
	to->fTop = from.fTop;
	to->fAscent = from.fAscent;
	to->fDescent = from.fDescent;
	to->fBottom = from.fBottom;
	to->fLeading = from.fLeading;
}

FontMetrics_Struct*
FontMetrics_Helper::unwrap(SkPaint::FontMetrics* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	FontMetrics_Struct* retval = new FontMetrics_Struct();
	FontMetrics_Helper::unwrap(*src, retval);
	return retval;
}

void
FontMetrics_Helper::marshalOut(const SkPaint::FontMetrics& from, FontMetrics_Struct*
	 to)
{
	to->fTop = from.fTop;
	to->fAscent = from.fAscent;
	to->fDescent = from.fDescent;
	to->fBottom = from.fBottom;
	to->fLeading = from.fLeading;
}

void
FontMetrics_Helper::wrap(const FontMetrics_Struct& from, SkPaint::FontMetrics* to)
{
	to->fTop = from.fTop;
	to->fAscent = from.fAscent;
	to->fDescent = from.fDescent;
	to->fBottom = from.fBottom;
	to->fLeading = from.fLeading;
}

SkPaint::FontMetrics*
FontMetrics_Helper::wrap(const FontMetrics_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	SkPaint::FontMetrics* retval = new SkPaint::FontMetrics();
	FontMetrics_Helper::wrap(*src, retval);
	return retval;
}

const SkPaint::FontMetrics*
FontMetrics_Helper::wrapConst(const FontMetrics_Struct* src)
{
	return const_cast<const SkPaint::FontMetrics*>(FontMetrics_Helper::wrap(src));
}

void
FontMetrics_Helper::freeMembers(FontMetrics_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
FontMetrics_Helper::destructor(FontMetrics_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	FontMetrics_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_graphics_Paint_FontMetrics_destructor(FontMetrics_Struct* obj)
{
	FontMetrics_Helper::destructor(obj);
}

struct FontMetricsInt_Struct
{
	uint32_t _owner;
	int top;
	int ascent;
	int descent;
	int bottom;
	int leading;
};

void
FontMetricsInt_Helper::unwrap(PaintGlue::FontMetricsInt& from, FontMetricsInt_Struct*
	 to)
{
	to->_owner = 0x7380548b;
	to->top = from.top;
	to->ascent = from.ascent;
	to->descent = from.descent;
	to->bottom = from.bottom;
	to->leading = from.leading;
}

FontMetricsInt_Struct*
FontMetricsInt_Helper::unwrap(PaintGlue::FontMetricsInt* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	FontMetricsInt_Struct* retval = new FontMetricsInt_Struct();
	FontMetricsInt_Helper::unwrap(*src, retval);
	return retval;
}

void
FontMetricsInt_Helper::marshalOut(const PaintGlue::FontMetricsInt& from, FontMetricsInt_Struct*
	 to)
{
	to->top = from.top;
	to->ascent = from.ascent;
	to->descent = from.descent;
	to->bottom = from.bottom;
	to->leading = from.leading;
}

void
FontMetricsInt_Helper::wrap(const FontMetricsInt_Struct& from, PaintGlue::FontMetricsInt*
	 to)
{
	to->top = from.top;
	to->ascent = from.ascent;
	to->descent = from.descent;
	to->bottom = from.bottom;
	to->leading = from.leading;
}

PaintGlue::FontMetricsInt*
FontMetricsInt_Helper::wrap(const FontMetricsInt_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	PaintGlue::FontMetricsInt* retval = new PaintGlue::FontMetricsInt();
	FontMetricsInt_Helper::wrap(*src, retval);
	return retval;
}

const PaintGlue::FontMetricsInt*
FontMetricsInt_Helper::wrapConst(const FontMetricsInt_Struct* src)
{
	return const_cast<const PaintGlue::FontMetricsInt*>(FontMetricsInt_Helper::wrap(src));
}

void
FontMetricsInt_Helper::freeMembers(FontMetricsInt_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
FontMetricsInt_Helper::destructor(FontMetricsInt_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	FontMetricsInt_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_graphics_Paint_FontMetricsInt_destructor(FontMetricsInt_Struct*
	 obj)
{
	FontMetricsInt_Helper::destructor(obj);
}


extern "C" DLL_EXPORT int
libxobotos_Paint_getTextRunCursorC(PaintGlue* native_object, Array_char_Struct* text_ptr,
	int contextStart, int contextLength, int flags, int offset, int cursorOpt)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	int _retval = native_object->getTextRunCursorC(*text, contextStart, contextLength,
		flags, offset, cursorOpt);
	delete text;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_getTextPathS(PaintGlue* native_object, int bidiFlags, String_Struct*
	 text_ptr, int start, int end, float x, float y, PathGlue* path)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	native_object->getTextPathS(bidiFlags, *text, start, end, x, y, path);
	delete text;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setXfermode(PaintGlue* native_object, SkXfermode* xfermode)
{
	native_object->setXfermode(xfermode);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getColor(PaintGlue* _instance)
{
	int _retval = _instance->getColor();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setRasterizer(PaintGlue* native_object, SkRasterizer* rasterizer)
{
	native_object->setRasterizer(rasterizer);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setMaskFilter(PaintGlue* native_object, SkMaskFilter* maskfilter)
{
	native_object->setMaskFilter(maskfilter);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getFontMetrics(PaintGlue* _instance, FontMetrics_Struct** metrics_ptr)
{
	SkPaint::FontMetrics metrics;
	float _retval = _instance->getFontMetrics(&metrics);
	*metrics_ptr = FontMetrics_Helper::unwrap(&metrics);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_getTextPathC(PaintGlue* native_object, int bidiFlags, Array_char_Struct*
	 text_ptr, int index, int count, float x, float y, PathGlue* path)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	native_object->getTextPathC(bidiFlags, *text, index, count, x, y, path);
	delete text;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setStrokeCap(PaintGlue* native_object, int cap)
{
	native_object->setStrokeCap((SkPaint::Cap)cap);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setShadowLayer(PaintGlue* _instance, float radius, float dx, float
	 dy, int color)
{
	_instance->setShadowLayer(radius, dx, dy, color);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getTextSkewX(PaintGlue* _instance)
{
	float _retval = _instance->getTextSkewX();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setFlags(PaintGlue* _instance, int flags)
{
	_instance->setFlags(flags);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setSubpixelText(PaintGlue* _instance, bool subpixelText)
{
	_instance->setSubpixelText(subpixelText);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getFlags(PaintGlue* _instance)
{
	int _retval = _instance->getFlags();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setHinting(PaintGlue* _instance, int mode)
{
	_instance->setHinting((SkPaint::Hinting)mode);
}

extern "C" DLL_EXPORT PaintGlue*
libxobotos_Paint_init()
{
	PaintGlue* _retval = new PaintGlue();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setAlpha(PaintGlue* _instance, int a)
{
	_instance->setAlpha(a);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_getStringBounds(PaintGlue* nativePaint, String_Struct* text_ptr,
	int start, int end, Rect_Struct** bounds_ptr)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	SkIRect bounds;
	nativePaint->getStringBounds(*text, start, end, &bounds);
	delete text;
	*bounds_ptr = Rect_Helper::unwrap(&bounds);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_measureTextC(PaintGlue* _instance, Array_char_Struct* text_ptr, 
	int index, int count)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	float _retval = _instance->measureTextC(*text, index, count);
	delete text;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setStrikeThruText(PaintGlue* _instance, bool strikeThruText)
{
	_instance->setStrikeThruText(strikeThruText);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_ascent(PaintGlue* _instance)
{
	float _retval = _instance->ascent();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getStrokeWidth(PaintGlue* _instance)
{
	float _retval = _instance->getStrokeWidth();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Paint_breakTextC(PaintGlue* _instance, Array_char_Struct* text_ptr, int
	 index, int count, float maxWidth, Array_float_Struct* measuredWidth_ptr)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	NativeArray<float>* measuredWidth = Array_float_Helper::wrap(measuredWidth_ptr);
	int _retval = _instance->breakTextC(*text, index, count, maxWidth, measuredWidth);
	delete text;
	delete measuredWidth;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setStyle(PaintGlue* native_object, int style)
{
	native_object->setStyle((SkPaint::Style)style);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getTextScaleX(PaintGlue* _instance)
{
	float _retval = _instance->getTextScaleX();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getTextRunCursorS(PaintGlue* native_object, String_Struct* text_ptr,
	int contextStart, int contextEnd, int flags, int offset, int cursorOpt)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	int _retval = native_object->getTextRunCursorS(*text, contextStart, contextEnd, flags,
		offset, cursorOpt);
	delete text;
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_Paint_measureTextS(PaintGlue* _instance, String_Struct* text_ptr, int 
	start, int end)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	float _retval = _instance->measureTextS(*text, start, end);
	delete text;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setAntiAlias(PaintGlue* _instance, bool aa)
{
	_instance->setAntiAlias(aa);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getHinting(PaintGlue* _instance)
{
	int _retval = _instance->getHinting();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Paint_breakTextS(PaintGlue* _instance, String_Struct* text_ptr, bool measureForwards,
	float maxWidth, Array_float_Struct* measuredWidth_ptr)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	NativeArray<float>* measuredWidth = Array_float_Helper::wrap(measuredWidth_ptr);
	int _retval = _instance->breakTextS(*text, measureForwards, maxWidth, measuredWidth);
	delete text;
	delete measuredWidth;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setTextAlign(PaintGlue* native_object, int align)
{
	native_object->setTextAlign((SkPaint::Align)align);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setPathEffect(PaintGlue* native_object, SkPathEffect* effect)
{
	native_object->setPathEffect(effect);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getFontMetricsInt(PaintGlue* _instance, FontMetricsInt_Struct** 
	fmi_ptr)
{
	PaintGlue::FontMetricsInt fmi;
	int _retval = _instance->getFontMetricsInt(&fmi);
	*fmi_ptr = FontMetricsInt_Helper::unwrap(&fmi);
	return _retval;
}

extern "C" DLL_EXPORT PaintGlue*
libxobotos_Paint_initWithPaint(PaintGlue* paint)
{
	PaintGlue* _retval = new PaintGlue(*paint);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setStrokeJoin(PaintGlue* native_object, int join)
{
	native_object->setStrokeJoin((SkPaint::Join)join);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getTextRunAdvancesS(PaintGlue* native_object, String_Struct* text_ptr,
	int start, int end, int contextStart, int contextEnd, int flags, Array_float_Struct*
	 advances_ptr, int advancesIndex, int reserved)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	NativeArray<float>* advances = Array_float_Helper::wrap(advances_ptr);
	float _retval = native_object->getTextRunAdvancesS(*text, start, end, contextStart,
		contextEnd, flags, advances, advancesIndex, reserved);
	delete text;
	delete advances;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setFilterBitmap(PaintGlue* _instance, bool filter)
{
	_instance->setFilterBitmap(filter);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getTextWidthsS(PaintGlue* native_object, String_Struct* text_ptr,
	int start, int end, Array_float_Struct* widths_ptr)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	NativeArray<float>* widths = Array_float_Helper::wrap(widths_ptr);
	int _retval = native_object->getTextWidthsS(*text, start, end, *widths);
	delete text;
	delete widths;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setFakeBoldText(PaintGlue* _instance, bool fakeBoldText)
{
	_instance->setFakeBoldText(fakeBoldText);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setLinearText(PaintGlue* _instance, bool linearText)
{
	_instance->setLinearText(linearText);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setTextSize(PaintGlue* _instance, float textSize)
{
	_instance->setTextSize(textSize);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setTextSkewX(PaintGlue* _instance, float skewX)
{
	_instance->setTextSkewX(skewX);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getTextSize(PaintGlue* _instance)
{
	float _retval = _instance->getTextSize();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_Paint_descent(PaintGlue* _instance)
{
	float _retval = _instance->descent();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getStrokeJoin(PaintGlue* native_object)
{
	int _retval = native_object->getStrokeJoin();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setShader(PaintGlue* native_object, SkShader* shader)
{
	native_object->setShader(shader);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setColorFilter(PaintGlue* native_object, SkColorFilter* filter)
{
	native_object->setColorFilter(filter);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setDither(PaintGlue* _instance, bool dither)
{
	_instance->setDither(dither);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getTextWidthsC(PaintGlue* native_object, Array_char_Struct* text_ptr,
	int index, int count, Array_float_Struct* widths_ptr)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	NativeArray<float>* widths = Array_float_Helper::wrap(widths_ptr);
	int _retval = native_object->getTextWidthsC(*text, index, count, *widths);
	delete text;
	delete widths;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setStrokeMiter(PaintGlue* _instance, float miter)
{
	_instance->setStrokeMiter(miter);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_getCharArrayBounds(PaintGlue* nativePaint, Array_char_Struct* text_ptr,
	int index, int count, Rect_Struct** bounds_ptr)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	SkIRect bounds;
	nativePaint->getCharArrayBounds(*text, index, count, &bounds);
	delete text;
	*bounds_ptr = Rect_Helper::unwrap(&bounds);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setColor(PaintGlue* _instance, int color)
{
	_instance->setColor(color);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setTypeface(PaintGlue* native_object, SkTypeface* typeface)
{
	native_object->setTypeface(typeface);
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setUnderlineText(PaintGlue* _instance, bool underlineText)
{
	_instance->setUnderlineText(underlineText);
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getFontMetrics_0(PaintGlue* native_paint, FontMetrics_Struct** metrics_ptr)
{
	SkPaint::FontMetrics metrics;
	float _retval = native_paint->getFontMetrics(&metrics);
	*metrics_ptr = FontMetrics_Helper::unwrap(&metrics);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_set(PaintGlue* native_dst, PaintGlue* native_src)
{
	native_dst->set(*native_src);
}

extern "C" DLL_EXPORT bool
libxobotos_Paint_getFillPath(PaintGlue* native_object, PathGlue* src, PathGlue* dst)
{
	bool _retval = native_object->getFillPath(*src, dst);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_reset(PaintGlue* native_object)
{
	native_object->reset();
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getStrokeCap(PaintGlue* native_object)
{
	int _retval = native_object->getStrokeCap();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setTextScaleX(PaintGlue* _instance, float scaleX)
{
	_instance->setTextScaleX(scaleX);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getAlpha(PaintGlue* _instance)
{
	int _retval = _instance->getAlpha();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getStrokeMiter(PaintGlue* _instance)
{
	float _retval = _instance->getStrokeMiter();
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getTextAlign(PaintGlue* native_object)
{
	int _retval = native_object->getTextAlign();
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_Paint_measureTextS2(PaintGlue* _instance, String_Struct* text_ptr)
{
	const NativeString* text = String_Helper::wrapConst(text_ptr);
	float _retval = _instance->measureTextS2(*text);
	delete text;
	return _retval;
}

extern "C" DLL_EXPORT float
libxobotos_Paint_getTextRunAdvancesC(PaintGlue* native_object, Array_char_Struct*
	 text_ptr, int index, int count, int contextIndex, int contextCount, int flags, 
	Array_float_Struct* advances_ptr, int advancesIndex, int reserved)
{
	const NativeArray<char16_t>* text = Array_char_Helper::wrapConst(text_ptr);
	NativeArray<float>* advances = Array_float_Helper::wrap(advances_ptr);
	float _retval = native_object->getTextRunAdvancesC(*text, index, count, contextIndex,
		contextCount, flags, advances, advancesIndex, reserved);
	delete text;
	delete advances;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Paint_setStrokeWidth(PaintGlue* _instance, float width)
{
	_instance->setStrokeWidth(width);
}

extern "C" DLL_EXPORT int
libxobotos_Paint_getStyle(PaintGlue* native_object)
{
	int _retval = native_object->getStyle();
	return _retval;
}

