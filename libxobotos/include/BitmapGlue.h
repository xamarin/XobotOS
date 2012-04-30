#ifndef BITMAP_GLUE_H
#define BITMAP_GLUE_H

#include <libxobotos.h>
#include <SkBitmap.h>
 
class BitmapGlue : public SkBitmap
{
public:
	BitmapGlue(const NativeArray<int>* colors, int offset, int stride,
		   int width, int height, SkBitmap::Config config, bool isMutable);
	BitmapGlue(bool is_mutable = true);
	BitmapGlue(const BitmapGlue& src);

	void recycle();
	bool hasAlpha();
	void setHasAlpha(bool hasAlpha);
	int getPixel(int x, int y);
	void setPixel(int x, int y, SkColor color);
	bool sameAs(const SkBitmap& other);
	void prepareToDraw();
	bool setPixels(const NativeArray<int>& colors, int offset, int stride,
		       int x, int y, int width, int height);
	bool isMutable() { return _is_mutable; }

	BitmapGlue* copy(SkBitmap::Config dst_config, bool is_mutable);
	BitmapGlue* extractAlpha(const SkPaint* paint, NativeArray<int>* offsets);
	void* getPixels() const;
	void getPixels(NativeArray<int>& pixels, int offset, int stride,
		       int x, int y, int width, int height);

private:
	bool _is_mutable;
};

#endif
