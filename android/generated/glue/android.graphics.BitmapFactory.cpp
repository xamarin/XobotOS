#include "android.graphics.BitmapFactory.h"

struct Options_Struct
{
	uint32_t _owner;
	int isMutable;
	int justDecodeBounds;
	int sampleSize;
	int doDither;
	int isPurgeable;
	int config;
	BitmapGlue* bitmap;
	int width;
	int height;
};

void
Options_Helper::unwrap(BitmapFactoryGlue::Options& from, Options_Struct* to)
{
	to->_owner = 0x7380548b;
	to->isMutable = from.isMutable;
	to->justDecodeBounds = from.justDecodeBounds;
	to->sampleSize = from.sampleSize;
	to->doDither = from.doDither;
	to->isPurgeable = from.isPurgeable;
	to->config = from.config;
	to->bitmap = from.bitmap;
	to->width = from.width;
	to->height = from.height;
}

Options_Struct*
Options_Helper::unwrap(BitmapFactoryGlue::Options* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	Options_Struct* retval = new Options_Struct();
	Options_Helper::unwrap(*src, retval);
	return retval;
}

void
Options_Helper::marshalOut(const BitmapFactoryGlue::Options& from, Options_Struct*
	 to)
{
	to->width = from.width;
	to->height = from.height;
}

void
Options_Helper::wrap(const Options_Struct& from, BitmapFactoryGlue::Options* to)
{
	to->isMutable = from.isMutable;
	to->justDecodeBounds = from.justDecodeBounds;
	to->sampleSize = from.sampleSize;
	to->doDither = from.doDither;
	to->isPurgeable = from.isPurgeable;
	to->config = (SkBitmap::Config)from.config;
	to->bitmap = from.bitmap;
	to->width = from.width;
	to->height = from.height;
}

BitmapFactoryGlue::Options*
Options_Helper::wrap(const Options_Struct* src)
{
	if (src == NULL)
	{
		return NULL;
	}
	BitmapFactoryGlue::Options* retval = new BitmapFactoryGlue::Options();
	Options_Helper::wrap(*src, retval);
	return retval;
}

const BitmapFactoryGlue::Options*
Options_Helper::wrapConst(const Options_Struct* src)
{
	return const_cast<const BitmapFactoryGlue::Options*>(Options_Helper::wrap(src));
}

void
Options_Helper::freeMembers(Options_Struct& obj)
{
	assert(obj._owner == 0x7380548b);
}

void
Options_Helper::destructor(Options_Struct* obj)
{
	if (obj == NULL)
	{
		return;
	}
	Options_Helper::freeMembers(*obj);
	delete obj;
}


extern "C" DLL_EXPORT void
libxobotos_android_graphics_BitmapFactory_Options_destructor(Options_Struct* obj)
{
	Options_Helper::destructor(obj);
}


extern "C" DLL_EXPORT BitmapGlue*
libxobotos_BitmapFactory_nativeDecodeAsset(android::Asset* asset, Rect_Struct* padding_ptr,
	Options_Struct* opts_ptr)
{
	const SkIRect* padding = Rect_Helper::wrapConst(padding_ptr);
	BitmapFactoryGlue::Options* opts = Options_Helper::wrap(opts_ptr);
	BitmapGlue* _retval = BitmapFactoryGlue::nativeDecodeAsset(*asset, *padding, *opts);
	delete padding;
	if (opts_ptr != NULL)
	{
		Options_Helper::marshalOut(*opts, opts_ptr);
	}
	delete opts;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_BitmapFactory_setDefaultConfig(int nativeConfig)
{
	BitmapFactoryGlue::setDefaultConfig((SkBitmap::Config)nativeConfig);
}

extern "C" DLL_EXPORT BitmapGlue*
libxobotos_BitmapFactory_decodeByteArray(Array_byte_Struct* data_ptr, int offset,
	int length, Options_Struct* opts_ptr)
{
	const NativeArray<uint8_t>* data = Array_byte_Helper::wrapConst(data_ptr);
	BitmapFactoryGlue::Options* opts = Options_Helper::wrap(opts_ptr);
	BitmapGlue* _retval = BitmapFactoryGlue::decodeByteArray(*data, offset, length, *
		opts);
	delete data;
	if (opts_ptr != NULL)
	{
		Options_Helper::marshalOut(*opts, opts_ptr);
	}
	delete opts;
	return _retval;
}

