#include <AssetManagerGlue.h>
#include <utils/String16.h>
#include <utils/Asset.h>
#include <utils/AssetManager.h>
#include <utils/ResourceTypes.h>

#define DEBUG_STYLES(x) // x

enum {
	STYLE_NUM_ENTRIES = 6,
	STYLE_TYPE = 0,
	STYLE_DATA = 1,
	STYLE_ASSET_COOKIE = 2,
	STYLE_RESOURCE_ID = 3,
	STYLE_CHANGING_CONFIGURATIONS = 4,
	STYLE_DENSITY = 5
};

void
AssetManagerGlue::setConfiguration(int mcc, int mnc, const NativeString* locale, int orientation,
				   int touchscreen, int density, int keyboard, int keyboardHidden,
				   int navigation, int screenWidth, int screenHeight,
				   int smallestScreenWidthDp, int screenWidthDp, int screenHeightDp,
				   int screenLayout, int uiMode, int sdkVersion)
{
	ResTable_config config;
	memset(&config, 0, sizeof(config));

	config.mcc = (uint16_t)mcc;
	config.mnc = (uint16_t)mnc;
	config.orientation = (uint8_t)orientation;
	config.touchscreen = (uint8_t)touchscreen;
	config.density = (uint16_t)density;
	config.keyboard = (uint8_t)keyboard;
	config.inputFlags = (uint8_t)keyboardHidden;
	config.navigation = (uint8_t)navigation;
	config.screenWidth = (uint16_t)screenWidth;
	config.screenHeight = (uint16_t)screenHeight;
	config.smallestScreenWidthDp = (uint16_t)smallestScreenWidthDp;
	config.screenWidthDp = (uint16_t)screenWidthDp;
	config.screenHeightDp = (uint16_t)screenHeightDp;
	config.screenLayout = (uint8_t)screenLayout;
	config.uiMode = (uint8_t)uiMode;
	config.sdkVersion = (uint16_t)sdkVersion;
	config.minorVersion = 0;
	AssetManager::setConfiguration(config, locale ? String8(*locale).string() : NULL);
}

int
AssetManagerGlue::addAssetPath(const NativeString& pathStr)
{
	void* cookie;
	bool res = AssetManager::addAssetPath(String8(pathStr), &cookie);

	return (res) ? (int)(long)cookie : 0;
}

int
AssetManagerGlue::getStringBlockCount()
{
	return getResources().getTableCount();
}

AssetManagerGlue::StringBlock*
AssetManagerGlue::getNativeStringBlock(size_t index)
{
	return new StringBlock(getResources().getTableStringBlock(index), false);
}

AssetManagerGlue::StringBlock::StringBlock(const ResStringPool* block, bool owns_handle)
{
	this->block = block;
	this->owns_handle = owns_handle;
}

AssetManagerGlue::StringBlock::~StringBlock()
{
	if (owns_handle)
		delete block;
	block = NULL;
}

int
AssetManagerGlue::StringBlock::nativeGetSize()
{
	return block->size();
}

NativeString*
AssetManagerGlue::StringBlock::nativeGetString(int idx)
{
	size_t len;

	const char* str8 = block->string8At(idx, &len);
	if (str8 != NULL)
		return new NativeString(str8);

	const char16_t* str = block->stringAt(idx, &len);
	if (str)
		return new NativeString(len, str);

	return NULL;
}

NativeArray<int>*
AssetManagerGlue::StringBlock::nativeGetStyle(int idx)
{
	return NULL;
}

AssetManagerGlue::Theme*
AssetManagerGlue::newTheme()
{
	return new AssetManagerGlue::Theme(getResources());
}

AssetManagerGlue::Theme::Theme(const ResTable& resources) : ResTable::Theme(resources)
{ }

bool
AssetManagerGlue::Theme::applyStyle(int defStyleAttr, int defStyleRes, XmlParser* xmlParser,
				    const NativeArray<int>* attrs, NativeArray<int>* outValues,
				    NativeArray<int>* outIndices)
{
	DEBUG_STYLES(LOGI("APPLY STYLE: defStyleAttr=0x%x defStyleRes=0x%x xml=%p",
			  defStyleAttr, defStyleRes, xmlParser));

	const ResTable& res = getResTable();
	ResTable_config config;
	Res_value value;

	if (!attrs || !outValues)
		return false;

	const size_t NI = attrs->length();
	const size_t NV = outValues->length();
	SkASSERT(NV >= (NI*STYLE_NUM_ENTRIES));

	int indicesIdx = 0;
	bool haveIndices = false;
	if (outIndices) {
		if (outIndices->length() > NI)
			haveIndices = true;
	}

	// Load default style from attribute, if specified...
	uint32_t defStyleBagTypeSetFlags = 0;
	if (defStyleAttr != 0) {
		Res_value value;
		if (getAttribute(defStyleAttr, &value, &defStyleBagTypeSetFlags) >= 0) {
			DEBUG_STYLES(LOGI("Got attribute: %x / %x", value.dataType, value.data));
			if (value.dataType == Res_value::TYPE_REFERENCE) {
				defStyleRes = value.data;
			}
		}
	}

	// Retrieve the style class associated with the current XML tag.
	int style = 0;
	uint32_t styleBagTypeSetFlags = 0;
	if (xmlParser != NULL) {
		ssize_t idx = xmlParser->indexOfStyle();
		if (idx >= 0 && xmlParser->getAttributeValue(idx, &value) >= 0) {
			if (value.dataType == value.TYPE_ATTRIBUTE) {
				if (getAttribute(value.data, &value, &styleBagTypeSetFlags) < 0) {
					value.dataType = Res_value::TYPE_NULL;
				}
			}
			if (value.dataType == value.TYPE_REFERENCE) {
				style = value.data;
			}
		}
	}

	// Now lock down the resource object and start pulling stuff from it.
	res.lock();

	// Retrieve the default style bag, if requested.
	const ResTable::bag_entry* defStyleEnt = NULL;
	uint32_t defStyleTypeSetFlags = 0;
	ssize_t bagOff = defStyleRes != 0
		? res.getBagLocked(defStyleRes, &defStyleEnt, &defStyleTypeSetFlags) : -1;
	defStyleTypeSetFlags |= defStyleBagTypeSetFlags;
	const ResTable::bag_entry* endDefStyleEnt = defStyleEnt +
		(bagOff >= 0 ? bagOff : 0);

	DEBUG_STYLES(LOGI("DEF STYLE: %x - %p - %x", defStyleRes, defStyleEnt, (int)bagOff));

	// Retrieve the style class bag, if requested.
	const ResTable::bag_entry* styleEnt = NULL;
	uint32_t styleTypeSetFlags = 0;
	bagOff = style != 0 ? res.getBagLocked(style, &styleEnt, &styleTypeSetFlags) : -1;
	styleTypeSetFlags |= styleBagTypeSetFlags;
	const ResTable::bag_entry* endStyleEnt = styleEnt +
		(bagOff >= 0 ? bagOff : 0);

	DEBUG_STYLES(LOGI("STYLE: %x - %p - %x", style, styleEnt, (int)bagOff));

	// Retrieve the XML attributes, if requested.
	const size_t NX = xmlParser ? xmlParser->getAttributeCount() : 0;
	size_t ix=0;
	uint32_t curXmlAttr = xmlParser ? xmlParser->getAttributeNameResID(ix) : 0;

	static const ssize_t kXmlBlock = 0x10000000;

	// Now iterate through all of the attributes that the client has requested,
	// filling in each with whatever data we can find.
	size_t offset = 0;
	ssize_t block = 0;
	uint32_t typeSetFlags;
	for (size_t ii=0; ii<NI; ii++) {
		const uint32_t curIdent = (*attrs)[ii];

		DEBUG_STYLES(LOGI("RETRIEVING ATTR 0x%08x...", curIdent));

		// Try to find a value for this attribute...  we prioritize values
		// coming from, first XML attributes, then XML style, then default
		// style, and finally the theme.
		value.dataType = Res_value::TYPE_NULL;
		value.data = 0;
		typeSetFlags = 0;
		config.density = 0;

		// Skip through XML attributes until the end or the next possible match.
		while (ix < NX && curIdent > curXmlAttr) {
			ix++;
			curXmlAttr = xmlParser->getAttributeNameResID(ix);
		}
		// Retrieve the current XML attribute if it matches, and step to next.
		if (ix < NX && curIdent == curXmlAttr) {
			block = kXmlBlock;
			xmlParser->getAttributeValue(ix, &value);
			ix++;
			curXmlAttr = xmlParser->getAttributeNameResID(ix);
			DEBUG_STYLES(LOGI("-> From XML: type=0x%x, data=0x%08x",
					  value.dataType, value.data));
		}

		// Skip through the style values until the end or the next possible match.
		while (styleEnt < endStyleEnt && curIdent > styleEnt->map.name.ident) {
			styleEnt++;
		}
		// Retrieve the current style attribute if it matches, and step to next.
		if (styleEnt < endStyleEnt && curIdent == styleEnt->map.name.ident) {
			if (value.dataType == Res_value::TYPE_NULL) {
				block = styleEnt->stringBlock;
				typeSetFlags = styleTypeSetFlags;
				value = styleEnt->map.value;
				DEBUG_STYLES(LOGI("-> From style: type=0x%x, data=0x%08x",
						  value.dataType, value.data));
			}
			styleEnt++;
		}

		// Skip through the default style values until the end or the next possible match.
		while (defStyleEnt < endDefStyleEnt && curIdent > defStyleEnt->map.name.ident) {
			defStyleEnt++;
		}
		// Retrieve the current default style attribute if it matches, and step to next.
		if (defStyleEnt < endDefStyleEnt && curIdent == defStyleEnt->map.name.ident) {
			if (value.dataType == Res_value::TYPE_NULL) {
				block = defStyleEnt->stringBlock;
				typeSetFlags = defStyleTypeSetFlags;
				value = defStyleEnt->map.value;
				DEBUG_STYLES(LOGI("-> From def style: type=0x%x, data=0x%08x",
						  value.dataType, value.data));
			}
			defStyleEnt++;
		}

		uint32_t resid = 0;
		if (value.dataType != Res_value::TYPE_NULL) {
			// Take care of resolving the found resource to its final value.
			ssize_t newBlock = resolveAttributeReference(&value, block,
									    &resid, &typeSetFlags, &config);
			if (newBlock >= 0) block = newBlock;
			DEBUG_STYLES(LOGI("-> Resolved attr: type=0x%x, data=0x%08x",
					  value.dataType, value.data));
		} else {
			// If we still don't have a value for this attribute, try to find
			// it in the theme!
			ssize_t newBlock = getAttribute(curIdent, &value, &typeSetFlags);
			if (newBlock >= 0) {
				DEBUG_STYLES(LOGI("-> From theme: type=0x%x, data=0x%08x",
						  value.dataType, value.data));
				newBlock = res.resolveReference(&value, block, &resid,
								&typeSetFlags, &config);
#if THROW_ON_BAD_ID
				if (newBlock == BAD_INDEX) {
					jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
					return JNI_FALSE;
				}
#endif
				if (newBlock >= 0) block = newBlock;
				DEBUG_STYLES(LOGI("-> Resolved theme: type=0x%x, data=0x%08x",
						  value.dataType, value.data));
			}
		}

		// Deal with the special @null value -- it turns back to TYPE_NULL.
		if (value.dataType == Res_value::TYPE_REFERENCE && value.data == 0) {
			DEBUG_STYLES(LOGI("-> Setting to @null!"));
			value.dataType = Res_value::TYPE_NULL;
			block = kXmlBlock;
		}

		DEBUG_STYLES(LOGI("Attribute 0x%08x: type=0x%x, data=0x%08x",
				  curIdent, value.dataType, value.data));

		// Write the final value back to Java.
		outValues->set(offset+STYLE_TYPE, value.dataType);
		outValues->set(offset+STYLE_DATA, value.data);
		// FIXME: This is a pointer!
		// dest[STYLE_ASSET_COOKIE] = block != kXmlBlock ? res.getTableCookie(block) : NULL;
		if (block != kXmlBlock) {
			void* cookie = res.getTableCookie(block);
			DEBUG_STYLES(LOGI("COOKIE: %p - %x", cookie, (int)(long)cookie));
			SkASSERT((int)(long)cookie == (long)cookie);
			outValues->set(offset+STYLE_ASSET_COOKIE, (int)(long)cookie);
		} else {
			outValues->set(offset+STYLE_ASSET_COOKIE, -1);
		}
		outValues->set(offset+STYLE_RESOURCE_ID, resid);
		outValues->set(offset+STYLE_CHANGING_CONFIGURATIONS, typeSetFlags);
		outValues->set(offset+STYLE_DENSITY, config.density);

		if (haveIndices && value.dataType != Res_value::TYPE_NULL) {
			indicesIdx++;
			outIndices->set(indicesIdx, ii);
		}

		offset += STYLE_NUM_ENTRIES;
	}

	res.unlock();

	if (haveIndices)
		outIndices->set(0, indicesIdx);

	return true;
}

void
AssetManagerGlue::Theme::applyThemeStyle(int styleRes, bool force)
{
	ResTable::Theme::applyStyle(styleRes, force);
}

void
AssetManagerGlue::Theme::copyTheme(const AssetManagerGlue::Theme& src)
{
	setTo(src);
}

AssetManagerGlue::XmlBlock*
AssetManagerGlue::openXmlAssetNative(int cookie, const NativeString& fileName)
{
	Asset* a = cookie
		? AssetManager::openNonAsset((void*)cookie, String8(fileName), Asset::ACCESS_BUFFER)
		: AssetManager::openNonAsset(String8(fileName), Asset::ACCESS_BUFFER);

	if (!a)
		return NULL;

	XmlBlock* block = new XmlBlock();
	status_t err = block->setTo(a->getBuffer(true), a->getLength(), true);
	a->close();
	delete a;

	if (err != NO_ERROR)
		return NULL;

	return block;
}

AssetManagerGlue::StringBlock*
AssetManagerGlue::XmlBlock::nativeGetStringBlock()
{
	return new StringBlock(&getStrings(), false);
}

AssetManagerGlue::XmlParser*
AssetManagerGlue::XmlBlock::nativeCreateParseState()
{
	XmlParser* parser = new XmlParser(*this);
	parser->restart();
	return parser;
}

int
AssetManagerGlue::XmlParser::nativeNext()
{
	do {
		int code = next();
		switch (code) {
		case ResXMLParser::START_TAG:
			return 2;
		case ResXMLParser::END_TAG:
			return 3;
		case ResXMLParser::TEXT:
			return 4;
		case ResXMLParser::START_DOCUMENT:
			return 0;
		case ResXMLParser::END_DOCUMENT:
			return 1;
		case ResXMLParser::BAD_DOCUMENT:
			goto bad;
		}
	} while (true);

 bad:
	return ResXMLParser::BAD_DOCUMENT;
}

int
AssetManagerGlue::XmlParser::nativeGetAttributeIndex(const NativeString* ns, const NativeString& name)
{
	return indexOfAttribute(ns ? ns->ptr(0, ns->length()) : NULL, ns ? ns->length() : 0,
				name.ptr(0, name.length()), name.length());
}

int
AssetManagerGlue::XmlParser::nativeGetIdAttribute()
{
	ssize_t idx = indexOfID();
	return idx >= 0 ? getAttributeValueStringID(idx) : -1;
}

int
AssetManagerGlue::XmlParser::nativeGetClassAttribute()
{
	ssize_t idx = indexOfClass();
	return idx >= 0 ? getAttributeValueStringID(idx) : -1;
}

int
AssetManagerGlue::XmlParser::nativeGetStyleAttribute()
{
	ssize_t idx = indexOfStyle();
	if (idx < 0)
		return 0;

	Res_value value;
	if (getAttributeValue(idx, &value) < 0)
		return 0;

	return value.dataType == value.TYPE_REFERENCE
		|| value.dataType == value.TYPE_ATTRIBUTE
		? value.data : 0;
}

bool
AssetManagerGlue::retrieveAttributes(XmlParser& xmlParser, const NativeArray<int>& attrs,
				     NativeArray<int>* outValues, NativeArray<int>* outIndices)
{
	const ResTable& res(getResources());
	ResTable_config config;
	Res_value value;

	const size_t NI = attrs.length();
	const size_t NV = outValues->length();
	SkASSERT(NV >= (NI * STYLE_NUM_ENTRIES));

	// int* src = attrs;
	// int* baseDest = outValues;
	// int* dest = baseDest;

	int indicesIdx = 0;
	bool haveIndices = false;
	if (outIndices != NULL) {
		if (outIndices->length() > NI)
			haveIndices = true;
        }

	// Now lock down the resource object and start pulling stuff from it.
	res.lock();

	// Retrieve the XML attributes, if requested.
	const size_t NX = xmlParser.getAttributeCount();
	size_t ix=0;
	uint32_t curXmlAttr = xmlParser.getAttributeNameResID(ix);

	static const ssize_t kXmlBlock = 0x10000000;

	// Now iterate through all of the attributes that the client has requested,
	// filling in each with whatever data we can find.
	size_t offset = 0;
	ssize_t block = 0;
	uint32_t typeSetFlags;
	for (size_t ii=0; ii<NI; ii++) {
		const uint32_t curIdent = attrs[ii];

		// Try to find a value for this attribute...
		value.dataType = Res_value::TYPE_NULL;
		value.data = 0;
		typeSetFlags = 0;
		config.density = 0;

		// Skip through XML attributes until the end or the next possible match.
		while (ix < NX && curIdent > curXmlAttr) {
			ix++;
			curXmlAttr = xmlParser.getAttributeNameResID(ix);
		}
		// Retrieve the current XML attribute if it matches, and step to next.
		if (ix < NX && curIdent == curXmlAttr) {
			block = kXmlBlock;
			xmlParser.getAttributeValue(ix, &value);
			ix++;
			curXmlAttr = xmlParser.getAttributeNameResID(ix);
		}

		//printf("Attribute 0x%08x: type=0x%x, data=0x%08x\n", curIdent, value.dataType, value.data);
		uint32_t resid = 0;
		if (value.dataType != Res_value::TYPE_NULL) {
			// Take care of resolving the found resource to its final value.
			//printf("Resolving attribute reference\n");
			ssize_t newBlock = res.resolveReference(&value, block, &resid,
								&typeSetFlags, &config);
#if THROW_ON_BAD_ID
			if (newBlock == BAD_INDEX) {
				jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
				return JNI_FALSE;
			}
#endif
			if (newBlock >= 0) block = newBlock;
		}

		// Deal with the special @null value -- it turns back to TYPE_NULL.
		if (value.dataType == Res_value::TYPE_REFERENCE && value.data == 0) {
			value.dataType = Res_value::TYPE_NULL;
		}

		//printf("Attribute 0x%08x: final type=0x%x, data=0x%08x\n", curIdent, value.dataType, value.data);

		// Write the final value back to Java.
		outValues->set(offset+STYLE_TYPE, value.dataType);
		outValues->set(offset+STYLE_DATA, value.data);
		// FIXME: This is a pointer!
		// dest[STYLE_ASSET_COOKIE] = block != kXmlBlock ? res.getTableCookie(block) : NULL;
		if (block != kXmlBlock) {
			void* cookie = res.getTableCookie(block);
			DEBUG_STYLES(LOGI("COOKIE: %p - %x", cookie, (int)(long)cookie));
			SkASSERT((int)(long)cookie == (long)cookie);
			outValues->set(offset+STYLE_ASSET_COOKIE, (int)(long)cookie);
		} else {
			outValues->set(offset+STYLE_ASSET_COOKIE, -1);
		}
		outValues->set(offset+STYLE_RESOURCE_ID, resid);
		outValues->set(offset+STYLE_CHANGING_CONFIGURATIONS, typeSetFlags);
		outValues->set(offset+STYLE_DENSITY, config.density);

		if (haveIndices && value.dataType != Res_value::TYPE_NULL) {
			indicesIdx++;
			outIndices->set(indicesIdx, ii);
		}

		offset += STYLE_NUM_ENTRIES;
	}

	res.unlock();

	if (haveIndices)
		outIndices->set(0, indicesIdx);

	return true;
}

int
AssetManagerGlue::copyValue(TypedValue* outValue, const ResTable* table, Res_value& value, uint32_t ref,
			    ssize_t block, uint32_t typeSpecFlags, ResTable_config* config)
{
	outValue->mType = value.dataType;
	outValue->mAssetCookie = (long)table->getTableCookie(block);
	outValue->mData = value.data;
	outValue->mResourceId = ref;
	outValue->mChangingConfigurations = typeSpecFlags;
	outValue->mDensity = config != 0 ? config->density : 0;
	return block;
}

int
AssetManagerGlue::loadResourceValue(int ident, int density, TypedValue* outValue, bool resolve)
{
	const ResTable& res(getResources());

	Res_value value;
	ResTable_config config;
	uint32_t typeSpecFlags;
	ssize_t block = res.getResource(ident, &value, false, density, &typeSpecFlags, &config);
#if THROW_ON_BAD_ID
	if (block == BAD_INDEX) {
		jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
		return 0;
	}
#endif
	uint32_t ref = ident;
	if (resolve) {
		block = res.resolveReference(&value, block, &ref);
#if THROW_ON_BAD_ID
		if (block == BAD_INDEX) {
			jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
			return 0;
		}
#endif
	}
	return block >= 0 ? copyValue(outValue, &res, value, ref, block, typeSpecFlags, &config) : block;
}

int
AssetManagerGlue::Theme::loadThemeAttributeValue(int ident, TypedValue* outValue, bool resolve)
{
	const ResTable& res(getResTable());

	Res_value value;
	// XXX value could be different in different configs!
	uint32_t typeSpecFlags = 0;
	ssize_t block = getAttribute(ident, &value, &typeSpecFlags);
	uint32_t ref = 0;
	if (resolve) {
		block = res.resolveReference(&value, block, &ref, &typeSpecFlags);
#if THROW_ON_BAD_ID
		if (block == BAD_INDEX) {
			jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
			return 0;
		}
#endif
	}
	return block >= 0 ? copyValue(outValue, &res, value, ref, block, typeSpecFlags) : block;
}

Asset*
AssetManagerGlue::openNonAssetNative(int cookie, const NativeString& fileNameStr, Asset::AccessMode mode)
{
	String8 fileName(fileNameStr);
	return cookie
		? openNonAsset((void*)cookie, fileName, mode)
		: openNonAsset(fileName, mode);
}

int
AssetManagerGlue::readAssetChar(Asset& asset)
{
	uint8_t b;
	ssize_t res = asset.read(&b, 1);
	return res == 1 ? b : -1;
}

int
AssetManagerGlue::readAsset(Asset& asset, NativeArray<uint8_t>& array, size_t off, size_t len)
{
	if (len == 0)
		return 0;

	return asset.read(array.ptr(off, len), len);
}

long
AssetManagerGlue::seekAsset(Asset& asset, long offset, int whence)
{
	return asset.seek(offset, (whence > 0) ? SEEK_END : (whence < 0 ? SEEK_SET : SEEK_CUR));
}

long
AssetManagerGlue::getAssetLength(Asset& asset)
{
	return asset.getLength();
}

long
AssetManagerGlue::getAssetRemainingLength(Asset& asset)
{
	return asset.getRemainingLength();
}

int
AssetManagerGlue::getArraySize(int id)
{
	const ResTable& res(getResources());

	res.lock();
	const ResTable::bag_entry* defStyleEnt = NULL;
	ssize_t bagOff = res.getBagLocked(id, &defStyleEnt);
	res.unlock();

	return bagOff;
}

int
AssetManagerGlue::retrieveArray(int id, NativeArray<int>& array)
{
	const ResTable& res(getResources());
	ResTable_config config;
	Res_value value;
	ssize_t block;

	const size_t NV = array.length();

	// Now lock down the resource object and start pulling stuff from it.
	res.lock();

	const ResTable::bag_entry* arrayEnt = NULL;
	uint32_t arrayTypeSetFlags = 0;
	ssize_t bagOff = res.getBagLocked(id, &arrayEnt, &arrayTypeSetFlags);
	const ResTable::bag_entry* endArrayEnt = arrayEnt +
		(bagOff >= 0 ? bagOff : 0);

	size_t i = 0;
	off_t offset = 0;
	uint32_t typeSetFlags;
	while (i < NV && arrayEnt < endArrayEnt) {
		block = arrayEnt->stringBlock;
		typeSetFlags = arrayTypeSetFlags;
		config.density = 0;
		value = arrayEnt->map.value;

		uint32_t resid = 0;
		if (value.dataType != Res_value::TYPE_NULL) {
			// Take care of resolving the found resource to its final value.
			//printf("Resolving attribute reference\n");
			ssize_t newBlock = res.resolveReference(&value, block, &resid,
								&typeSetFlags, &config);
#if THROW_ON_BAD_ID
			if (newBlock == BAD_INDEX) {
				jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
				return JNI_FALSE;
			}
#endif
			if (newBlock >= 0) block = newBlock;
		}

		// Deal with the special @null value -- it turns back to TYPE_NULL.
		if (value.dataType == Res_value::TYPE_REFERENCE && value.data == 0) {
			value.dataType = Res_value::TYPE_NULL;
		}

		//printf("Attribute 0x%08x: final type=0x%x, data=0x%08x\n", curIdent, value.dataType, value.data);

		// Write the final value back to Java.
		array.set(offset + STYLE_TYPE, value.dataType);
		array.set(offset + STYLE_DATA, value.data);
		array.set(offset + STYLE_ASSET_COOKIE, (int)(long)res.getTableCookie(block));
		array.set(offset + STYLE_RESOURCE_ID, resid);
		array.set(offset + STYLE_CHANGING_CONFIGURATIONS, typeSetFlags);
		array.set(offset + STYLE_DENSITY, config.density);
		offset += STYLE_NUM_ENTRIES;
		i+= STYLE_NUM_ENTRIES;
		arrayEnt++;
	}

	i /= STYLE_NUM_ENTRIES;

	res.unlock();

	return i;
}

NativeArray<int>*
AssetManagerGlue::getArrayIntResource(int id)
{
	const ResTable& res(getResources());

	const ResTable::bag_entry* startOfBag;
	const ssize_t N = res.lockBag(id, &startOfBag);
	if (N < 0) {
		return NULL;
	}

	NativeArray<int>* array = new NativeArray<int>(N);
	if (array == NULL) {
		res.unlockBag(startOfBag);
		return NULL;
	}

	Res_value value;
	const ResTable::bag_entry* bag = startOfBag;
	for (size_t i=0; ((ssize_t)i)<N; i++, bag++) {
		value = bag->map.value;

		// Take care of resolving the found resource to its final value.
		ssize_t block = res.resolveReference(&value, bag->stringBlock, NULL);
		if (block == BAD_INDEX) {
#if THROW_ON_BAD_ID
			jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
			return array;
#else
			LOGE("Bad resource!");
			delete array;
			return NULL;
#endif
		}
		if (value.dataType >= Res_value::TYPE_FIRST_INT
		    && value.dataType <= Res_value::TYPE_LAST_INT) {
			array->set(i, value.data);
		}
        }
        res.unlockBag(startOfBag);
        return array;
}

int
AssetManagerGlue::getResourceIdentifier(const NativeString& name, const NativeString* defType,
					const NativeString* defPackage)
{
	return getResources().identifierForName(name.ptr(0, name.length()), name.length(),
						defType ? defType->ptr(0, defType->length()) : NULL,
						defType ? defType->length() : 0,
						defPackage ? defPackage->ptr(0, defPackage->length()) : NULL,
						defPackage ? defPackage->length() : 0);
}

NativeString*
AssetManagerGlue::getResourceName(int resid)
{
	ResTable::resource_name name;
	if (!getResources().getResourceName(resid, &name)) {
		return NULL;
	}

	String16 str;
	if (name.package != NULL) {
		str.setTo(name.package, name.packageLen);
	}
	if (name.type != NULL) {
		if (str.size() > 0) {
			char16_t div = ':';
			str.append(&div, 1);
		}
		str.append(name.type, name.typeLen);
	}
	if (name.name != NULL) {
		if (str.size() > 0) {
			char16_t div = '/';
			str.append(&div, 1);
		}
		str.append(name.name, name.nameLen);
	}

	return new NativeString(str);
}

NativeString*
AssetManagerGlue::getResourcePackageName(int resid)
{
	ResTable::resource_name name;
	if (!getResources().getResourceName(resid, &name)) {
		return NULL;
	}

	if (name.package != NULL) {
		return new NativeString(name.packageLen, name.package);
	}

	return NULL;
}

NativeString*
AssetManagerGlue::getResourceTypeName(int resid)
{
	ResTable::resource_name name;
	if (!getResources().getResourceName(resid, &name)) {
		return NULL;
	}

	if (name.type != NULL) {
		return new NativeString(name.typeLen, name.type);
	}

	return NULL;
}

NativeString*
AssetManagerGlue::getResourceEntryName(int resid)
{
	ResTable::resource_name name;
	if (!getResources().getResourceName(resid, &name)) {
		return NULL;
	}

	if (name.name != NULL) {
		return new NativeString(name.nameLen, name.name);
	}

	return NULL;
}

NativeString*
AssetManagerGlue::getCookieName(int cookie)
{
	String8 name(getAssetPath((void*)cookie));
	if (name.length() == 0) {
		return NULL;
	}
	return new NativeString(name);
}

NativeArray<int>*
AssetManagerGlue::getArrayStringInfo(int arrayResId)
{
	const ResTable& res(getResources());

	const ResTable::bag_entry* startOfBag;
	const ssize_t N = res.lockBag(arrayResId, &startOfBag);
	if (N < 0) {
		return NULL;
	}

	NativeArray<int>* array = new NativeArray<int>(N * 2);
	if (array == NULL) {
		res.unlockBag(startOfBag);
		return NULL;
	}

	Res_value value;
	const ResTable::bag_entry* bag = startOfBag;
	for (size_t i = 0, j = 0; ((ssize_t)i)<N; i++, bag++) {
		int stringIndex = -1;
		int stringBlock = 0;
		value = bag->map.value;

		// Take care of resolving the found resource to its final value.
		stringBlock = res.resolveReference(&value, bag->stringBlock, NULL);
		if (value.dataType == Res_value::TYPE_STRING) {
			stringIndex = value.data;
		}

#if THROW_ON_BAD_ID
		if (stringBlock == BAD_INDEX) {
			jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
			return array;
		}
#endif

		//todo: It might be faster to allocate a C array to contain
		//      the blocknums and indices, put them in there and then
		//      do just one SetIntArrayRegion()
		array->set(j, stringBlock);
		array->set(j+1, stringIndex);
		j = j + 2;
	}
	res.unlockBag(startOfBag);
	return array;
}

NativePtrArray<NativeString>*
AssetManagerGlue::getArrayStringResource(int arrayResId)
{
	const ResTable& res(getResources());

	const ResTable::bag_entry* startOfBag;
	const ssize_t N = res.lockBag(arrayResId, &startOfBag);
	if (N < 0) {
		return NULL;
	}

	NativePtrArray<NativeString>* array = new NativePtrArray<NativeString>(N);

	Res_value value;
	const ResTable::bag_entry* bag = startOfBag;
	size_t strLen = 0;
	for (size_t i=0; ((ssize_t)i)<N; i++, bag++) {
		value = bag->map.value;
		NativeString* str = NULL;

		// Take care of resolving the found resource to its final value.
		ssize_t block = res.resolveReference(&value, bag->stringBlock, NULL);
#if THROW_ON_BAD_ID
		if (block == BAD_INDEX) {
			jniThrowException(env, "java/lang/IllegalStateException", "Bad resource!");
			return array;
		}
#endif
		if (value.dataType == Res_value::TYPE_STRING) {
			const ResStringPool* pool = res.getTableStringBlock(block);
			const char* str8 = pool->string8At(value.data, &strLen);
			if (str8 != NULL) {
				str = new NativeString(String8(str8));
			} else {
				const char16_t* str16 = pool->stringAt(value.data, &strLen);
				str = new NativeString(strLen, str16);
			}

			array->set(i, str);
		}
	}
	res.unlockBag(startOfBag);
	return array;
}
