#ifndef BITMAP_FACTORY_GLUE_H
#define BITMAP_FACTORY_GLUE_H

#include <libxobotos.h>
#include <BitmapGlue.h>
#include <AssetManagerGlue.h>
#include <SkImageDecoder.h>
#include <SkStream.h>
 
class BitmapFactoryGlue
{
public:
	struct Options {
		bool isMutable;
		bool justDecodeBounds;
		int sampleSize;
		bool doDither;
		bool isPurgeable;
		SkBitmap::Config config;
		BitmapGlue* bitmap;

		int width;
		int height;
	};

	static BitmapGlue* decodeByteArray(const NativeArray<uint8_t>& data, int offset, int length,
					   Options& options);
	static BitmapGlue* nativeDecodeAsset(Asset& asset, SkIRect padding, Options& options);
	static void setDefaultConfig(SkBitmap::Config config);

private:
	static SkPixelRef* installPixelRef(SkBitmap* bitmap, SkStream* stream,
					   int sampleSize, bool ditherImage);
	static const char* getMimeTypeString(SkImageDecoder::Format format);
	static BitmapGlue* doDecode(SkStream* stream, Options& options,
				    bool allowPurgeable, bool forcePurgeable = false);
	static SkStream* copyAssetToStream(Asset& asset);

	BitmapFactoryGlue() { }

	class AssetStreamAdaptor : public SkStream
	{
	public:
		AssetStreamAdaptor(Asset& a) : fAsset(a) {}
		virtual bool rewind();
		virtual size_t read(void* buffer, size_t size);
	private:
		Asset& fAsset;
	};
};

#endif
