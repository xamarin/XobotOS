#ifndef ASSET_MANAGER_GLUE_H
#define ASSET_MANAGER_GLUE_H

#include <libxobotos.h>
#include <utils/Asset.h>
#include <utils/AssetManager.h>
#include <utils/ResourceTypes.h>

using namespace android;
 
class AssetManagerGlue : public AssetManager
{
public:
	AssetManagerGlue() { }

	class StringBlock;
	class Theme;
	class XmlParser;
	class XmlBlock;

	struct TypedValue;

	void setConfiguration(int mcc, int mnc, const NativeString* locale, int orientation,
			      int touchscreen, int density, int keyboard, int keyboardHidden,
			      int navigation, int screenWidth, int screenHeight,
			      int smallestScreenWidthDp, int screenWidthDp, int screenHeightDp,
			      int screenLayout, int uiMode, int sdkVersion);
	int addAssetPath(const NativeString& path);

	int getStringBlockCount();
	StringBlock* getNativeStringBlock(size_t index);

	Theme* newTheme();

	XmlBlock* openXmlAssetNative(int cookie, const NativeString& fileName);

	bool retrieveAttributes(XmlParser& xmlParser, const NativeArray<int>& attrs,
				NativeArray<int>* outValues, NativeArray<int>* outIndices);

	int loadResourceValue(int ident, int density, TypedValue* outValue, bool resolve);

	Asset* openNonAssetNative(int cookie, const NativeString& fileName, Asset::AccessMode mode);
	static int readAssetChar(Asset& asset);
	static int readAsset(Asset& asset, NativeArray<uint8_t>& array, size_t off, size_t len);
	static long seekAsset(Asset& asset, long offset, int whence);
	static long getAssetLength(Asset& asset);
	static long getAssetRemainingLength(Asset& asset);

	NativeString* getCookieName(int cookie);

	int getArraySize(int id);
	int retrieveArray(int id, NativeArray<int>& array);
	NativeArray<int>* getArrayIntResource(int id);

	int getResourceIdentifier(const NativeString& name, const NativeString* defType,
				  const NativeString* defPackage);
	NativeString* getResourceName(int resid);
	NativeString* getResourcePackageName(int resid);
	NativeString* getResourceTypeName(int resid);
	NativeString* getResourceEntryName(int resid);

	NativeArray<int>* getArrayStringInfo(int arrayResId);
	NativePtrArray<NativeString>* getArrayStringResource(int arrayResId);

	class StringBlock
	{
	public:
		StringBlock(const ResStringPool* block, bool owns_handle);
		~StringBlock();

		int nativeGetSize();
		NativeString* nativeGetString(int idx);
		NativeArray<int>* nativeGetStyle(int idx);

	private:
		bool owns_handle;
		const ResStringPool* block;
	};

	class Theme : public ResTable::Theme
	{
	public:
		Theme(const ResTable& resources);
		bool applyStyle(int defStyleAttr, int defStyleRes, XmlParser* xmlParser,
				const NativeArray<int>* attrs, NativeArray<int>* outValues,
				NativeArray<int>* outIndices);
		void applyThemeStyle(int styleRes, bool force);
		void copyTheme(const AssetManagerGlue::Theme& src);
		int loadThemeAttributeValue(int ident, TypedValue* outValue, bool resolve);
	};

	class XmlBlock : public ResXMLTree
	{
	public:
		StringBlock* nativeGetStringBlock();
		XmlParser* nativeCreateParseState();
	};

	class XmlParser : public ResXMLParser
	{
	public:
		XmlParser(const XmlBlock& block) : ResXMLParser(block) { }

		int nativeNext();
		int nativeGetAttributeIndex(const NativeString* ns, const NativeString& name);
		int nativeGetIdAttribute();
		int nativeGetClassAttribute();
		int nativeGetStyleAttribute();
	};

	struct TypedValue
	{
		int mType;
		long mAssetCookie;
		int mData;
		int mResourceId;
		int mChangingConfigurations;
		int mDensity;
	};

private:
	static int copyValue(TypedValue* outValue, const ResTable* table, Res_value& value,
			     uint32_t ref, ssize_t block, uint32_t typeSpecFlags,
			     ResTable_config* config = NULL);
};

#endif
