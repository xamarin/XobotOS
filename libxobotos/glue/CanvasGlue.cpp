#include <CanvasGlue.h>
#include <SkDevice.h>
#include <SkGraphics.h>
#include <SkTemplates.h>
#include <SkShader.h>

SkCanvas*
CanvasGlue::create(const SkBitmap* bitmap)
{
	if (bitmap)
		return new SkCanvas(*bitmap);
	else
		return new SkCanvas();
}

void
CanvasGlue::freeCaches()
{
        // these are called in no particular order
	// FIXME
        // SkImageRef_GlobalPool::SetRAMUsed(0);
        // SkGraphics::SetFontCacheUsed(0);
}

bool
CanvasGlue::isOpaque(SkCanvas& canvas)
{
        return canvas.getDevice()->accessBitmap(false).isOpaque();
}
    
int
CanvasGlue::getWidth(SkCanvas& canvas)
{
        return canvas.getDevice()->accessBitmap(false).width();
}

int
CanvasGlue::getHeight(SkCanvas& canvas)
{
        return canvas.getDevice()->accessBitmap(false).height();
}

void
CanvasGlue::setBitmap(SkCanvas& canvas, const SkBitmap* bitmap)
{
        if (bitmap) {
		canvas.setBitmapDevice(*bitmap);
        } else {
		canvas.setDevice(NULL);
        }
}

bool
CanvasGlue::clipIRect(SkCanvas& canvas, SkIRect rect)
{
	SkRect r;
	r.set(rect);
	return canvas.clipRect(r);
}

bool
CanvasGlue::clipIRect(SkCanvas& canvas, int left, int top, int right, int bottom)
{
	SkRect r = SkRect::MakeLTRB(left, top, right, bottom);
	return canvas.clipRect(r);
}

bool
CanvasGlue::clipRect(SkCanvas& canvas, float left, float top, float right, float bottom)
{
	SkRect r = SkRect::MakeLTRB(left, top, right, bottom);
	return canvas.clipRect(r);
}

bool
CanvasGlue::clipRectValues(SkCanvas& canvas, float left, float top, float right, float bottom, SkRegion::Op regionOp)
{
	SkRect r = SkRect::MakeLTRB(left, top, right, bottom);
	return canvas.clipRect(r, regionOp);
}

bool
CanvasGlue::getClipBoundsIRect(SkCanvas& canvas, SkIRect& bounds)
{
        SkRect r;
        bool result = canvas.getClipBounds(&r, SkCanvas::kBW_EdgeType);
        r.round(&bounds);
	return result;
}

void
CanvasGlue::getCTM(SkCanvas& canvas, SkMatrix* matrix)
{
        *matrix = canvas.getTotalMatrix();
}

void
CanvasGlue::drawBitmap(SkCanvas& canvas, SkBitmap bitmap, float left, float top, const SkPaint* paint,
		       int canvasDensity, int screenDensity,  int bitmapDensity)
{
	SkScalar left_ = SkFloatToScalar(left);
        SkScalar top_ = SkFloatToScalar(top);

        if (canvasDensity == bitmapDensity || canvasDensity == 0 || bitmapDensity == 0) {
		if (screenDensity != 0 && screenDensity != bitmapDensity) {
			SkPaint filteredPaint;
			if (paint) {
				filteredPaint = *paint;
			}
			filteredPaint.setFilterBitmap(true);
			canvas.drawBitmap(bitmap, left_, top_, &filteredPaint);
		} else {
			canvas.drawBitmap(bitmap, left_, top_, paint);
		}
        } else {
		canvas.save();
		SkScalar scale_ = SkFloatToScalar(canvasDensity / (float)bitmapDensity);
		canvas.translate(left_, top_);
		canvas.scale(scale_, scale_);

		SkPaint filteredPaint;
		if (paint) {
			filteredPaint = *paint;
		}
		filteredPaint.setFilterBitmap(true);

		canvas.drawBitmap(bitmap, 0, 0, &filteredPaint);

		canvas.restore();
        }
}

void
CanvasGlue::drawBitmapRect(SkCanvas& canvas, SkBitmap bitmap, const SkIRect* src, const SkRect& dst,
			   const SkPaint* paint, int screenDensity, int bitmapDensity)
{
        if (screenDensity != 0 && screenDensity != bitmapDensity) {
		SkPaint filteredPaint;
		if (paint) {
			filteredPaint = *paint;
		}
		filteredPaint.setFilterBitmap(true);
		canvas.drawBitmapRect(bitmap, src, dst, &filteredPaint);
        } else {
		canvas.drawBitmapRect(bitmap, src, dst, paint);
        }
}

void
CanvasGlue::drawBitmapRect(SkCanvas& canvas, SkBitmap bitmap, const SkIRect* src, const SkIRect &idst,
			   const SkPaint* paint, int screenDensity, int bitmapDensity)
{
	SkRect dst;
	dst.set(idst);
	drawBitmapRect(canvas, bitmap, src, dst, paint, screenDensity, bitmapDensity);
}

void
CanvasGlue::drawBitmapColors(SkCanvas& canvas, const NativeArray<int>& colors, int offset, int stride,
			     float x, float y, int width, int height, bool hasAlpha, const PaintGlue* paint)
{
	BitmapGlue bitmap;

        bitmap.setConfig(hasAlpha ? SkBitmap::kARGB_8888_Config :
                         SkBitmap::kRGB_565_Config, width, height);
        if (!bitmap.allocPixels())
		return;

        if (!bitmap.setPixels(colors, offset, stride, 0, 0, width, height))
		return;

	canvas.drawBitmap(bitmap, SkFloatToScalar(x), SkFloatToScalar(y), paint);
}


void
CanvasGlue::drawBitmapMesh(SkCanvas& canvas, const BitmapGlue& bitmap, int meshWidth, int meshHeight,
			   const NativeArray<float>& vertArray, int vertIndex,
			   const NativeArray<int>* colorArray, int colorIndex,
			   const PaintGlue* paint)
{
        const int ptCount = (meshWidth + 1) * (meshHeight + 1);
        const int indexCount = meshWidth * meshHeight * 6;

	SkASSERT(vertArray.length() >= (size_t)(vertIndex + (ptCount << 1)));
	if (colorArray)
		SkASSERT(colorArray->length() >= (size_t)(colorIndex + ptCount));

        /*  Our temp storage holds 2 or 3 arrays.
            texture points [ptCount * sizeof(SkPoint)]
            optionally vertex points [ptCount * sizeof(SkPoint)] if we need a
                copy to convert from float to fixed
            indices [ptCount * sizeof(uint16_t)]
        */
        size_t storageSize = ptCount * sizeof(SkPoint); // texs[]
        storageSize += indexCount * sizeof(uint16_t);  // indices[]

        SkAutoMalloc storage(storageSize);
        SkPoint* texs = (SkPoint*)storage.get();
        uint16_t* indices;
        indices = (uint16_t*)(texs + ptCount);

        // cons up texture coordinates and indices
        {
		const SkScalar w = SkIntToScalar(bitmap.width());
		const SkScalar h = SkIntToScalar(bitmap.height());
		const SkScalar dx = w / meshWidth;
		const SkScalar dy = h / meshHeight;

		SkPoint* texsPtr = texs;
		SkScalar y = 0;
		for (int i = 0; i <= meshHeight; i++) {
			if (i == meshHeight) {
				y = h;  // to ensure numerically we hit h exactly
			}
			SkScalar x = 0;
			for (int j = 0; j < meshWidth; j++) {
				texsPtr->set(x, y);
				texsPtr += 1;
				x += dx;
			}
			texsPtr->set(w, y);
			texsPtr += 1;
			y += dy;
		}
		SkASSERT(texsPtr - texs == ptCount);
        }

        // cons up indices
        {
		uint16_t* indexPtr = indices;
		int index = 0;
		for (int i = 0; i < meshHeight; i++) {
			for (int j = 0; j < meshWidth; j++) {
				// lower-left triangle
				*indexPtr++ = index;
				*indexPtr++ = index + meshWidth + 1;
				*indexPtr++ = index + meshWidth + 2;
				// upper-right triangle
				*indexPtr++ = index;
				*indexPtr++ = index + meshWidth + 2;
				*indexPtr++ = index + 1;
				// bump to the next cell
				index += 1;
			}
			// bump to the next row
			index += 1;
		}
		SkASSERT(indexPtr - indices == indexCount);
		SkASSERT((size_t)((char*)indexPtr - (char*)storage.get()) == storageSize);
        }

        // double-check that we have legal indices
#ifdef SK_DEBUG
        {
		for (int i = 0; i < indexCount; i++) {
			SkASSERT((unsigned)indices[i] < (unsigned)ptCount);
		}
        }
#endif

        // cons-up a shader for the bitmap
        SkPaint tmpPaint;
        if (paint) {
		tmpPaint = *paint;
        }
        SkShader* shader = SkShader::CreateBitmapShader(bitmap,
							SkShader::kClamp_TileMode, SkShader::kClamp_TileMode);
        SkSafeUnref(tmpPaint.setShader(shader));

	canvas.drawVertices(SkCanvas::kTriangles_VertexMode, ptCount,
			    (SkPoint*)vertArray.ptr(vertIndex, ptCount << 1), texs,
			    colorArray ? (SkColor*)colorArray->ptr(colorIndex, ptCount) : NULL,
			    NULL, indices, indexCount, tmpPaint);
}

void
CanvasGlue::drawVertices(SkCanvas& canvas, SkCanvas::VertexMode mode, int vertexCount,
			 const NativeArray<float>& vertArray, int vertIndex,
			 const NativeArray<float>* texArray, int texIndex,
			 const NativeArray<int>* colorArray, int colorIndex,
			 const NativeArray<short>* indexArray, int indexIndex,
			 int indexCount, const PaintGlue& paint)
{
	SkASSERT(vertArray.length() >= (size_t)(vertIndex + vertexCount));
	if (texArray)
		SkASSERT(texArray->length() >= (size_t)(texIndex + vertexCount));
	if (colorArray)
		SkASSERT(colorArray->length() >= (size_t)(colorIndex + vertexCount));
	if (indexArray)
		SkASSERT(indexArray->length() >= (size_t)(indexIndex + indexCount));

        const int ptCount = vertexCount >> 1;

        SkPoint* verts = (SkPoint*)vertArray.ptr(vertIndex, vertexCount);
        SkPoint* texs = NULL;
        if (texArray != NULL)
		texs = (SkPoint*)texArray->ptr(texIndex, indexCount);

        const SkColor* colors = NULL;
        const uint16_t* indices = NULL;
        if (colorArray != NULL)
		colors = (const SkColor*)(colorArray + colorIndex);
        if (indexArray != NULL)
		indices = (const uint16_t*)(indexArray + indexIndex);

	canvas.drawVertices(mode, ptCount, verts, texs, colors, NULL,
			    indices, indexCount, paint);
}

void
CanvasGlue::drawRGB(SkCanvas& canvas, int r, int g, int b)
{
	canvas.drawARGB(0xFF, r, g, b);
}

int
CanvasGlue::saveLayerValues(SkCanvas& canvas, float l, float t, float r, float b, const SkPaint* paint, SaveFlags layerFlags)
{
	SkRect rect = SkRect::MakeLTRB(l, t, r, b);
	return canvas.saveLayer(&rect, paint, layerFlags);
}

int
CanvasGlue::saveLayerAlphaValues(SkCanvas& canvas, float l, float t, float r, float b, int alpha, SaveFlags layerFlags)
{
	SkRect rect = SkRect::MakeLTRB(l, t, r, b);
	return canvas.saveLayerAlpha(&rect, alpha, layerFlags);
}

void
CanvasGlue::drawTextC(SkCanvas& canvas, const NativeArray<char16_t>& text, int index, int count,
		      float x, float y, int flags, const PaintGlue& paint)
{
	canvas.drawText(text.ptr(index,count), count << 1, x, y, paint);
}

void
CanvasGlue::drawTextS(SkCanvas& canvas, const NativeString& text, int start, int end,
		      float x, float y, int flags, const PaintGlue& paint)
{
	canvas.drawText(text.ptr(start, end-start), (end - start) << 1, x, y, paint);
}

void
CanvasGlue::doPoints(SkCanvas& canvas, const NativeArray<float>& floats, int offset, int count,
		     const PaintGlue& paint, SkCanvas::PointMode mode)
{
	SkASSERT(((offset | count) >= 0) && ((size_t)(offset + count) <= floats.length()));

        // now convert the floats into SkPoints
        count >>= 1;    // now it is the number of points
        SkAutoSTMalloc<32, SkPoint> storage(count);
        SkPoint* pts = storage.get();
	int src = offset;
        for (int i = 0; i < count; i++) {
		pts[i].set(SkFloatToScalar(floats[src]), SkFloatToScalar(floats[src+1]));
		src += 2;
        }
	canvas.drawPoints(mode, count, pts, paint);
}

void
CanvasGlue::drawPoints(SkCanvas& canvas, const NativeArray<float>& pts, int offset, int count, const PaintGlue& paint)
{
	doPoints(canvas, pts, offset, count, paint, SkCanvas::kPoints_PointMode);
}

void
CanvasGlue::drawLines(SkCanvas& canvas, const NativeArray<float>& pts, int offset, int count, const PaintGlue& paint)
{
	doPoints(canvas, pts, offset, count, paint, SkCanvas::kLines_PointMode);
}

void
CanvasGlue::drawTextRunC(SkCanvas& canvas, const NativeArray<char16_t>& text, int index, int count,
			 int context_index, int context_count, float x, float y, int flags, const PaintGlue& paint)
{
	drawTextRun(canvas, text, index, count, x, y, paint);
}

void
CanvasGlue::drawTextRunS(SkCanvas& canvas, const NativeString& text, int start, int end,
			 int context_start, int context_end, float x, float y, int flags,
			 const PaintGlue& paint)
{
	drawTextRun(canvas, text, start, end - start, x, y, paint);
}

void
CanvasGlue::drawTextRun(SkCanvas& canvas, const NativeArray<char16_t>& chars, int start, int count,
			float x, float y, const PaintGlue& paint)
{
	canvas.drawText(chars.ptr(start,count), count << 1, x, y, paint);
}

void
CanvasGlue::drawRect(SkCanvas& canvas, float left, float top, float right, float bottom, const PaintGlue& paint)
{
	SkRect rect = SkRect::MakeLTRB(left, top, right, bottom);
	canvas.drawRect(rect, paint);
}

bool
CanvasGlue::quickReject(SkCanvas& canvas, float left, float top, float right, float bottom, SkCanvas::EdgeType edgeType)
{
	SkRect rect = SkRect::MakeLTRB(left, top, right, bottom);
	return canvas.quickReject(rect, edgeType);
}
