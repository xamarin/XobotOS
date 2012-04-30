#include <BitmapFactoryGlue.h>
#include <SkImageDecoder.h>
#include <SkImageRef_GlobalPool.h>
#include <SkPixelRef.h>
#include <SkStream.h>
#include <SkTemplates.h>
#include <SkUtils.h>

SkPixelRef*
BitmapFactoryGlue::installPixelRef(SkBitmap* bitmap, SkStream* stream,
                                   int sampleSize, bool ditherImage)
{
	SkImageRef* pr = new SkImageRef_GlobalPool(stream, bitmap->config(), sampleSize);
	pr->setDitherImage(ditherImage);
	bitmap->setPixelRef(pr)->unref();
	pr->isOpaque(bitmap);
	return pr;
}

const char*
BitmapFactoryGlue::getMimeTypeString(SkImageDecoder::Format format)
{
	static const struct {
		SkImageDecoder::Format fFormat;
		const char*            fMimeType;
	} gMimeTypes[] = {
		{ SkImageDecoder::kBMP_Format,  "image/bmp" },
		{ SkImageDecoder::kGIF_Format,  "image/gif" },
		{ SkImageDecoder::kICO_Format,  "image/x-ico" },
		{ SkImageDecoder::kJPEG_Format, "image/jpeg" },
		{ SkImageDecoder::kPNG_Format,  "image/png" },
		{ SkImageDecoder::kWBMP_Format, "image/vnd.wap.wbmp" }
	};

	for (size_t i = 0; i < SK_ARRAY_COUNT(gMimeTypes); i++) {
		if (gMimeTypes[i].fFormat == format)
			return gMimeTypes[i].fMimeType;
	}

	return NULL;
}

BitmapGlue*
BitmapFactoryGlue::doDecode(SkStream* stream, Options& options,
			    bool allowPurgeable, bool forcePurgeable)
{
	int sampleSize = 1;
	SkImageDecoder::Mode mode = SkImageDecoder::kDecodePixels_Mode;
	SkBitmap::Config prefConfig = SkBitmap::kARGB_8888_Config;
	bool doDither = true;
	bool isMutable = false;
	bool isPurgeable = forcePurgeable || (allowPurgeable && options.isPurgeable);
	BitmapGlue* javaBitmap = NULL;

	sampleSize = options.sampleSize;
	if (options.justDecodeBounds)
		mode = SkImageDecoder::kDecodeBounds_Mode;
	// initialize these, in case we fail later on
	options.width = -1;
	options.height = -1;

	prefConfig = options.config;
	isMutable = options.isMutable;
	doDither = options.doDither;
	javaBitmap = options.bitmap;

	SkImageDecoder* decoder = SkImageDecoder::Factory(stream);
	if (NULL == decoder)
		return NULL;

	decoder->setSampleSize(sampleSize);
	decoder->setDitherImage(doDither);

	BitmapGlue* bitmap;
	if (javaBitmap == NULL) {
		bitmap = new BitmapGlue;
	} else {
		if (sampleSize != 1) {
			return NULL;
		}
		bitmap = javaBitmap;
		// config of supplied bitmap overrules config set in options
		prefConfig = bitmap->getConfig();
	}

	SkAutoTDelete<SkImageDecoder>   add(decoder);
	SkAutoTDelete<SkBitmap>         adb(bitmap, (javaBitmap == NULL));

	SkImageDecoder::Mode decodeMode = mode;
	if (isPurgeable) {
		decodeMode = SkImageDecoder::kDecodeBounds_Mode;
	}
	if (!decoder->decode(stream, bitmap, prefConfig, decodeMode))
		return NULL;

	// update options (if any)
	options.width = bitmap->width();
	options.height = bitmap->height();

	// if we're in justBounds mode, return now (skip the java bitmap)
	if (SkImageDecoder::kDecodeBounds_Mode == mode) {
		return NULL;
	}

	// detach bitmap from its autodeleter, since we want to own it now
	adb.detach();

	SkPixelRef* pr;
	if (isPurgeable) {
		pr = installPixelRef(bitmap, stream, sampleSize, doDither);
	} else {
		// if we get here, we're in kDecodePixels_Mode and will therefore
		// already have a pixelref installed.
		pr = bitmap->pixelRef();
	}

	if (!isMutable) {
		// promise we will never change our pixels (great for sharing and pictures)
		pr->setImmutable();
	}

	if (javaBitmap != NULL) {
		// If a java bitmap was passed in for reuse, pass it back
		return javaBitmap;
	}
	// now create the java bitmap
	return bitmap;
}

BitmapGlue*
BitmapFactoryGlue::decodeByteArray(const NativeArray<uint8_t>& data, int offset, int length, Options& options)
{
	/*  If optionsShareable() we could decide to just wrap the java array and
	    share it, but that means adding a globalref to the java array object
	    and managing its lifetime. For now we just always copy the array's data
	    if optionsPurgeable(), unless we're just decoding bounds.
	*/
	bool purgeable = options.isPurgeable && !options.justDecodeBounds;
	SkStream* stream = new SkMemoryStream(data.ptr(offset,length), length, purgeable);
	SkAutoUnref aur(stream);
	return doDecode(stream, options, purgeable);
}

void
BitmapFactoryGlue::setDefaultConfig(SkBitmap::Config config)
{
	// these are the only default configs that make sense for codecs right now
	static const SkBitmap::Config gValidDefConfig[] = {
		SkBitmap::kRGB_565_Config,
		SkBitmap::kARGB_8888_Config,
	};

	for (size_t i = 0; i < SK_ARRAY_COUNT(gValidDefConfig); i++) {
		if (config == gValidDefConfig[i]) {
			SkImageDecoder::SetDeviceConfig(config);
			break;
		}
	}
}

bool
BitmapFactoryGlue::AssetStreamAdaptor::rewind()
{
	off64_t pos = fAsset.seek(0, SEEK_SET);
	if (pos == (off64_t)-1) {
		SkDebugf("----- fAsset->seek(rewind) failed\n");
		return false;
	}
	return true;
}

size_t
BitmapFactoryGlue::AssetStreamAdaptor::read(void* buffer, size_t size)
{
	ssize_t amount;

	if (NULL == buffer) {
		if (0 == size) {  // caller is asking us for our total length
			return fAsset.getLength();
		}
		// asset->seek returns new total offset
		// we want to return amount that was skipped

		off64_t oldOffset = fAsset.seek(0, SEEK_CUR);
		if (-1 == oldOffset) {
			SkDebugf("---- fAsset->seek(oldOffset) failed\n");
			return 0;
		}
		off64_t newOffset = fAsset.seek(size, SEEK_CUR);
		if (-1 == newOffset) {
			SkDebugf("---- fAsset->seek(%d) failed\n", size);
			return 0;
		}
		amount = newOffset - oldOffset;
	} else {
		amount = fAsset.read(buffer, size);
		if (amount <= 0) {
			SkDebugf("---- fAsset->read(%d) returned %d\n", size, amount);
		}
	}

	if (amount < 0) {
		amount = 0;
	}
	return amount;
}

/*  make a deep copy of the asset, and return it as a stream, or NULL if there
    was an error.
 */
SkStream*
BitmapFactoryGlue::copyAssetToStream(Asset& asset)
{
	// if we could "ref/reopen" the asset, we may not need to copy it here
	off64_t size = asset.seek(0, SEEK_SET);
	if ((off64_t)-1 == size) {
		SkDebugf("---- copyAsset: asset rewind failed\n");
		return NULL;
	}

	size = asset.getLength();
	if (size <= 0) {
		SkDebugf("---- copyAsset: asset->getLength() returned %d\n", size);
		return NULL;
	}

	SkStream* stream = new SkMemoryStream(size);
	void* data = const_cast<void*>(stream->getMemoryBase());
	off64_t len = asset.read(data, size);
	if (len != size) {
		SkDebugf("---- copyAsset: asset->read(%d) returned %d\n", size, len);
		delete stream;
		stream = NULL;
	}
	return stream;
}

BitmapGlue*
BitmapFactoryGlue::nativeDecodeAsset(Asset& asset, SkIRect padding, Options& options)
{
	SkStream* stream;
	bool forcePurgeable = options.isPurgeable;
	if (forcePurgeable) {
		// if we could "ref/reopen" the asset, we may not need to copy it here
		// and we could assume optionsShareable, since assets are always RO
		stream = copyAssetToStream(asset);
		if (NULL == stream) {
			return NULL;
		}
	} else {
		// since we know we'll be done with the asset when we return, we can
		// just use a simple wrapper
		stream = new AssetStreamAdaptor(asset);
	}
	SkAutoUnref aur(stream);
	return doDecode(stream, options, true, forcePurgeable);
}
