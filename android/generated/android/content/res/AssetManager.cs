using System.Runtime.InteropServices;
using Sharpen;

namespace android.content.res
{
	[Sharpen.Sharpened]
	public sealed partial class AssetManager : System.IDisposable
	{
		public const int ACCESS_UNKNOWN = 0;

		public const int ACCESS_RANDOM = 1;

		public const int ACCESS_STREAMING = 2;

		public const int ACCESS_BUFFER = 3;

		internal const string TAG = "AssetManager";

		internal const bool localLOGV = false || false;

		internal const bool DEBUG_REFS = false;

		private static readonly object sSync = new object();

		internal static android.content.res.AssetManager sSystem = null;

		private readonly android.util.TypedValue mValue = new android.util.TypedValue();

		private readonly long[] mOffsets = new long[2];

		internal android.content.res.AssetManager.NativeAssetManager mObject;

		private int mNObject;

		private android.content.res.StringBlock[] mStringBlocks = null;

		private int mNumRefs = 1;

		private bool mOpen = true;

		private java.util.HashMap<int, java.lang.RuntimeException> mRefStacks;

		private static void ensureSystemAssets()
		{
			lock (sSync)
			{
				if (sSystem == null)
				{
					android.content.res.AssetManager system = new android.content.res.AssetManager(true
						);
					system.makeStringBlocks(false);
					sSystem = system;
				}
			}
		}

		public static android.content.res.AssetManager getSystem()
		{
			ensureSystemAssets();
			return sSystem;
		}

		public void close()
		{
			lock (this)
			{
				if (mOpen)
				{
					mOpen = false;
					decRefsLocked(this.GetHashCode());
				}
			}
		}

		internal java.lang.CharSequence getResourceText(int ident)
		{
			lock (this)
			{
				android.util.TypedValue tmpValue = mValue;
				int block = loadResourceValue(ident, (short)0, tmpValue, true);
				if (block >= 0)
				{
					if (tmpValue.type == android.util.TypedValue.TYPE_STRING)
					{
						return mStringBlocks[block].get(tmpValue.data);
					}
					return tmpValue.coerceToString();
				}
			}
			return null;
		}

		internal java.lang.CharSequence getResourceBagText(int ident, int bagEntryId)
		{
			lock (this)
			{
				android.util.TypedValue tmpValue = mValue;
				int block = loadResourceBagValue(ident, bagEntryId, tmpValue, true);
				if (block >= 0)
				{
					if (tmpValue.type == android.util.TypedValue.TYPE_STRING)
					{
						return mStringBlocks[block].get(tmpValue.data);
					}
					return tmpValue.coerceToString();
				}
			}
			return null;
		}

		internal string[] getResourceStringArray(int id)
		{
			string[] retArray = getArrayStringResource(id);
			return retArray;
		}

		internal bool getResourceValue(int ident, int density, android.util.TypedValue outValue
			, bool resolveRefs)
		{
			int block = loadResourceValue(ident, (short)density, outValue, resolveRefs);
			if (block >= 0)
			{
				if (outValue.type != android.util.TypedValue.TYPE_STRING)
				{
					return true;
				}
				outValue.@string = mStringBlocks[block].get(outValue.data);
				return true;
			}
			return false;
		}

		internal java.lang.CharSequence[] getResourceTextArray(int id)
		{
			int[] rawInfoArray = getArrayStringInfo(id);
			int rawInfoArrayLen = rawInfoArray.Length;
			int infoArrayLen = rawInfoArrayLen / 2;
			int block;
			int index;
			java.lang.CharSequence[] retArray = new java.lang.CharSequence[infoArrayLen];
			{
				int i = 0;
				int j = 0;
				for (; i < rawInfoArrayLen; i = i + 2, j++)
				{
					block = rawInfoArray[i];
					index = rawInfoArray[i + 1];
					retArray[j] = index >= 0 ? mStringBlocks[block].get(index) : null;
				}
			}
			return retArray;
		}

		internal bool getThemeValue(android.content.res.Resources.Theme.NativeTheme theme
			, int ident, android.util.TypedValue outValue, bool resolveRefs)
		{
			int block = loadThemeAttributeValue(theme, ident, outValue, resolveRefs);
			if (block >= 0)
			{
				if (outValue.type != android.util.TypedValue.TYPE_STRING)
				{
					return true;
				}
				android.content.res.StringBlock[] blocks = mStringBlocks;
				if (blocks == null)
				{
					ensureStringBlocks();
					blocks = mStringBlocks;
				}
				outValue.@string = blocks[block].get(outValue.data);
				return true;
			}
			return false;
		}

		internal void ensureStringBlocks()
		{
			if (mStringBlocks == null)
			{
				lock (this)
				{
					if (mStringBlocks == null)
					{
						makeStringBlocks(true);
					}
				}
			}
		}

		internal void makeStringBlocks(bool copyFromSystem)
		{
			int sysNum = copyFromSystem ? sSystem.mStringBlocks.Length : 0;
			int num = getStringBlockCount();
			mStringBlocks = new android.content.res.StringBlock[num];
			{
				for (int i = 0; i < num; i++)
				{
					if (i < sysNum)
					{
						mStringBlocks[i] = sSystem.mStringBlocks[i];
					}
					else
					{
						mStringBlocks[i] = new android.content.res.StringBlock(getNativeStringBlock(i), true
							);
					}
				}
			}
		}

		internal java.lang.CharSequence getPooledString(int block, int id)
		{
			return mStringBlocks[block - 1].get(id);
		}

		[Sharpen.Stub]
		public java.io.InputStream open(string fileName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.io.InputStream open(string fileName, int accessMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.res.AssetFileDescriptor openFd(string fileName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		public string[] list(string path)
		{
			throw new System.NotImplementedException();
		}

		public java.io.InputStream openNonAsset(string fileName)
		{
			return openNonAsset(0, fileName, ACCESS_STREAMING);
		}

		public java.io.InputStream openNonAsset(string fileName, int accessMode)
		{
			return openNonAsset(0, fileName, accessMode);
		}

		public java.io.InputStream openNonAsset(int cookie, string fileName)
		{
			return openNonAsset(cookie, fileName, ACCESS_STREAMING);
		}

		public java.io.InputStream openNonAsset(int cookie, string fileName, int accessMode
			)
		{
			lock (this)
			{
				if (!mOpen)
				{
					throw new java.lang.RuntimeException("Assetmanager has been closed");
				}
				android.content.res.AssetManager.AssetInputStream.NativeAsset asset = openNonAssetNative
					(cookie, fileName, accessMode);
				if (asset != null)
				{
					android.content.res.AssetManager.AssetInputStream res = new android.content.res.AssetManager
						.AssetInputStream(this, asset);
					incRefsLocked(res.GetHashCode());
					return res;
				}
			}
			throw new java.io.FileNotFoundException("Asset absolute file: " + fileName);
		}

		[Sharpen.Stub]
		public android.content.res.AssetFileDescriptor openNonAssetFd(string fileName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.res.AssetFileDescriptor openNonAssetFd(int cookie, string 
			fileName)
		{
			throw new System.NotImplementedException();
		}

		public android.content.res.XmlResourceParser openXmlResourceParser(string fileName
			)
		{
			return openXmlResourceParser(0, fileName);
		}

		public android.content.res.XmlResourceParser openXmlResourceParser(int cookie, string
			 fileName)
		{
			android.content.res.XmlBlock block = openXmlBlockAsset(cookie, fileName);
			android.content.res.XmlResourceParser rp = block.newParser();
			block.close();
			return rp;
		}

		internal android.content.res.XmlBlock openXmlBlockAsset(string fileName)
		{
			return openXmlBlockAsset(0, fileName);
		}

		internal android.content.res.XmlBlock openXmlBlockAsset(int cookie, string fileName
			)
		{
			lock (this)
			{
				if (!mOpen)
				{
					throw new java.lang.RuntimeException("Assetmanager has been closed");
				}
				android.content.res.XmlBlock.NativeXmlBlock xmlBlock = openXmlAssetNative(cookie, 
					fileName);
				if (xmlBlock != null)
				{
					android.content.res.XmlBlock res = new android.content.res.XmlBlock(this, xmlBlock
						);
					incRefsLocked(res.GetHashCode());
					return res;
				}
			}
			throw new java.io.FileNotFoundException("Asset XML file: " + fileName);
		}

		internal void xmlBlockGone(int id)
		{
			lock (this)
			{
				decRefsLocked(id);
			}
		}

		internal void releaseTheme(int theme)
		{
			lock (this)
			{
				deleteTheme(theme);
				decRefsLocked(theme);
			}
		}

		public sealed partial class AssetInputStream : java.io.InputStream, System.IDisposable
		{
			internal AssetInputStream(AssetManager _enclosing, android.content.res.AssetManager.AssetInputStream.NativeAsset
				 asset)
			{
				this._enclosing = _enclosing;
				this.mAsset = asset;
				this.mLength = this._enclosing.getAssetLength(asset);
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override int read()
			{
				return this._enclosing.readAssetChar(this.mAsset);
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override bool markSupported()
			{
				return true;
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override int available()
			{
				long len = this._enclosing.getAssetRemainingLength(this.mAsset);
				return len > int.MaxValue ? int.MaxValue : (int)len;
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override void mark(int readlimit)
			{
				this.mMarkPos = this._enclosing.seekAsset(this.mAsset, 0, 0);
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override void reset()
			{
				this._enclosing.seekAsset(this.mAsset, this.mMarkPos, -1);
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override int read(byte[] b)
			{
				return this._enclosing.readAsset(this.mAsset, b, 0, b.Length);
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override int read(byte[] b, int off, int len)
			{
				return this._enclosing.readAsset(this.mAsset, b, off, len);
			}

			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override long skip(long n)
			{
				long pos = this._enclosing.seekAsset(this.mAsset, 0, 0);
				if ((pos + n) > this.mLength)
				{
					n = this.mLength - pos;
				}
				if (n > 0)
				{
					this._enclosing.seekAsset(this.mAsset, n, 0);
				}
				return n;
			}

			internal android.content.res.AssetManager.AssetInputStream.NativeAsset mAsset;

			private long mLength;

			private long mMarkPos;

			public void Dispose()
			{
				mAsset.Dispose();
			}

			internal class NativeAsset : System.Runtime.InteropServices.SafeHandle
			{
				internal NativeAsset() : base(System.IntPtr.Zero, true)
				{
				}

				internal NativeAsset(System.IntPtr handle) : base(System.IntPtr.Zero, true)
				{
					this.handle = handle;
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_content_res_AssetManager_AssetInputStream_destructor
					(System.IntPtr handle);

				internal System.IntPtr Handle
				{
					get
					{
						return handle;
					}
				}

				public static readonly NativeAsset Zero = new NativeAsset();

				protected override bool ReleaseHandle()
				{
					if (handle != System.IntPtr.Zero)
					{
						libxobotos_android_content_res_AssetManager_AssetInputStream_destructor(handle);
					}
					handle = System.IntPtr.Zero;
					return true;
				}

				public override bool IsInvalid
				{
					get
					{
						return handle == System.IntPtr.Zero;
					}
				}
			}

			private readonly AssetManager _enclosing;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_addAssetPath(android.content.res.AssetManager.NativeAssetManager
			 _instance, System.IntPtr path);

		public int addAssetPath(string path)
		{
			System.IntPtr path_ptr = System.IntPtr.Zero;
			try
			{
				path_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(path);
				return libxobotos_AssetManager_addAssetPath(mObject, path_ptr);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(path_ptr);
			}
		}

		public int[] addAssetPaths(string[] paths)
		{
			if (paths == null)
			{
				return null;
			}
			int[] cookies = new int[paths.Length];
			{
				for (int i = 0; i < paths.Length; i++)
				{
					cookies[i] = addAssetPath(paths[i]);
				}
			}
			return cookies;
		}

		[Sharpen.NativeStub]
		public bool isUpToDate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		public void setLocale(string locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		public string[] getLocales()
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_AssetManager_setConfiguration(android.content.res.AssetManager.NativeAssetManager
			 _instance, int mcc, int mnc, System.IntPtr locale, int orientation, int touchscreen
			, int density, int keyboard, int keyboardHidden, int navigation, int screenWidth
			, int screenHeight, int smallestScreenWidthDp, int screenWidthDp, int screenHeightDp
			, int screenLayout, int uiMode, int majorVersion);

		public void setConfiguration(int mcc, int mnc, string locale, int orientation, int
			 touchscreen, int density, int keyboard, int keyboardHidden, int navigation, int
			 screenWidth, int screenHeight, int smallestScreenWidthDp, int screenWidthDp, int
			 screenHeightDp, int screenLayout, int uiMode, int majorVersion)
		{
			System.IntPtr locale_ptr = System.IntPtr.Zero;
			try
			{
				locale_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(locale);
				libxobotos_AssetManager_setConfiguration(mObject, mcc, mnc, locale_ptr, orientation
					, touchscreen, density, keyboard, keyboardHidden, navigation, screenWidth, screenHeight
					, smallestScreenWidthDp, screenWidthDp, screenHeightDp, screenLayout, uiMode, majorVersion
					);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(locale_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_getResourceIdentifier(android.content.res.AssetManager.NativeAssetManager
			 _instance, System.IntPtr type, System.IntPtr name, System.IntPtr defPackage);

		internal int getResourceIdentifier(string type, string name, string defPackage)
		{
			System.IntPtr type_ptr = System.IntPtr.Zero;
			System.IntPtr name_ptr = System.IntPtr.Zero;
			System.IntPtr defPackage_ptr = System.IntPtr.Zero;
			try
			{
				type_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(type);
				name_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(name);
				defPackage_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(defPackage
					);
				return libxobotos_AssetManager_getResourceIdentifier(mObject, type_ptr, name_ptr, 
					defPackage_ptr);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(type_ptr);
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(name_ptr);
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(defPackage_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_AssetManager_getResourceName(android.content.res.AssetManager.NativeAssetManager
			 _instance, int resid);

		internal string getResourceName(int resid)
		{
			System.IntPtr _retval_ptr = libxobotos_AssetManager_getResourceName(mObject, resid
				);
			string _retval = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_AssetManager_getResourcePackageName
			(android.content.res.AssetManager.NativeAssetManager _instance, int resid);

		internal string getResourcePackageName(int resid)
		{
			System.IntPtr _retval_ptr = libxobotos_AssetManager_getResourcePackageName(mObject
				, resid);
			string _retval = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_AssetManager_getResourceTypeName(android.content.res.AssetManager.NativeAssetManager
			 _instance, int resid);

		internal string getResourceTypeName(int resid)
		{
			System.IntPtr _retval_ptr = libxobotos_AssetManager_getResourceTypeName(mObject, 
				resid);
			string _retval = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_AssetManager_getResourceEntryName(
			android.content.res.AssetManager.NativeAssetManager _instance, int resid);

		internal string getResourceEntryName(int resid)
		{
			System.IntPtr _retval_ptr = libxobotos_AssetManager_getResourceEntryName(mObject, 
				resid);
			string _retval = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[Sharpen.NativeStub]
		private int openAsset(string fileName, int accessMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private android.os.ParcelFileDescriptor openAssetFd(string fileName, long[] outOffsets
			)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.content.res.AssetManager.AssetInputStream.NativeAsset
			 libxobotos_AssetManager_openNonAssetNative(android.content.res.AssetManager.NativeAssetManager
			 _instance, int cookie, System.IntPtr fileName, int accessMode);

		private android.content.res.AssetManager.AssetInputStream.NativeAsset openNonAssetNative
			(int cookie, string fileName, int accessMode)
		{
			System.IntPtr fileName_ptr = System.IntPtr.Zero;
			try
			{
				fileName_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(fileName
					);
				return libxobotos_AssetManager_openNonAssetNative(mObject, cookie, fileName_ptr, 
					accessMode);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(fileName_ptr);
			}
		}

		[Sharpen.NativeStub]
		private android.os.ParcelFileDescriptor openNonAssetFdNative(int cookie, string fileName
			, long[] outOffsets)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_readAssetChar(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset);

		private int readAssetChar(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset)
		{
			return libxobotos_AssetManager_readAssetChar(asset);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_readAsset(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset, System.IntPtr b, int off, int len);

		private int readAsset(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset, byte[] b, int off, int len)
		{
			Sharpen.INativeHandle b_handle = null;
			try
			{
				b_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(b);
				return libxobotos_AssetManager_readAsset(asset, b_handle.Address, off, len);
			}
			finally
			{
				if (b_handle != null)
				{
					b_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern long libxobotos_AssetManager_seekAsset(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset, long offset, int whence);

		private long seekAsset(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset, long offset, int whence)
		{
			return libxobotos_AssetManager_seekAsset(asset, offset, whence);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern long libxobotos_AssetManager_getAssetLength(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset);

		private long getAssetLength(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset)
		{
			return libxobotos_AssetManager_getAssetLength(asset);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern long libxobotos_AssetManager_getAssetRemainingLength(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset);

		private long getAssetRemainingLength(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset)
		{
			return libxobotos_AssetManager_getAssetRemainingLength(asset);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_loadResourceValue(android.content.res.AssetManager.NativeAssetManager
			 _instance, int ident, short density, out System.IntPtr outValue, bool resolve);

		private int loadResourceValue(int ident, short density, android.util.TypedValue outValue
			, bool resolve)
		{
			System.IntPtr outValue_ptr = System.IntPtr.Zero;
			try
			{
				int _retval = libxobotos_AssetManager_loadResourceValue(mObject, ident, density, 
					out outValue_ptr, resolve);
				android.util.TypedValue.TypedValue_Helper.MarshalOut(outValue_ptr, outValue);
				return _retval;
			}
			finally
			{
				android.util.TypedValue.TypedValue_Helper.FreeNativePtr(outValue_ptr);
			}
		}

		[Sharpen.NativeStub]
		private int loadResourceBagValue(int ident, int bagEntryId, android.util.TypedValue
			 outValue, bool resolve)
		{
			throw new System.NotImplementedException();
		}

		internal const int STYLE_NUM_ENTRIES = 6;

		internal const int STYLE_TYPE = 0;

		internal const int STYLE_DATA = 1;

		internal const int STYLE_ASSET_COOKIE = 2;

		internal const int STYLE_RESOURCE_ID = 3;

		internal const int STYLE_CHANGING_CONFIGURATIONS = 4;

		internal const int STYLE_DENSITY = 5;

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_AssetManager_applyStyle(android.content.res.Resources.Theme.NativeTheme
			 theme, int defStyleAttr, int defStyleRes, android.content.res.XmlBlock.Parser.NativeXmlParser
			 xmlParser, System.IntPtr inAttrs, System.IntPtr outValues, System.IntPtr outIndices
			);

		internal static bool applyStyle(android.content.res.Resources.Theme.NativeTheme theme
			, int defStyleAttr, int defStyleRes, android.content.res.XmlBlock.Parser.NativeXmlParser
			 xmlParser, int[] inAttrs, int[] outValues, int[] outIndices)
		{
			Sharpen.INativeHandle inAttrs_handle = null;
			Sharpen.INativeHandle outValues_handle = null;
			Sharpen.INativeHandle outIndices_handle = null;
			try
			{
				inAttrs_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(inAttrs
					);
				outValues_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(outValues
					);
				outIndices_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(outIndices
					);
				return libxobotos_AssetManager_applyStyle(theme, defStyleAttr, defStyleRes, xmlParser
					 != null ? xmlParser : android.content.res.XmlBlock.Parser.NativeXmlParser.Zero, 
					inAttrs_handle != null ? inAttrs_handle.Address : System.IntPtr.Zero, outValues_handle
					 != null ? outValues_handle.Address : System.IntPtr.Zero, outIndices_handle != null
					 ? outIndices_handle.Address : System.IntPtr.Zero);
			}
			finally
			{
				if (inAttrs_handle != null)
				{
					inAttrs_handle.Free();
				}
				if (outValues_handle != null)
				{
					outValues_handle.Free();
				}
				if (outIndices_handle != null)
				{
					outIndices_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_AssetManager_retrieveAttributes(android.content.res.AssetManager.NativeAssetManager
			 _instance, android.content.res.XmlBlock.Parser.NativeXmlParser xmlParser, System.IntPtr
			 inAttrs, System.IntPtr outValues, System.IntPtr outIndices);

		internal bool retrieveAttributes(android.content.res.XmlBlock.Parser.NativeXmlParser
			 xmlParser, int[] inAttrs, int[] outValues, int[] outIndices)
		{
			Sharpen.INativeHandle inAttrs_handle = null;
			Sharpen.INativeHandle outValues_handle = null;
			Sharpen.INativeHandle outIndices_handle = null;
			try
			{
				inAttrs_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(inAttrs
					);
				outValues_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(outValues
					);
				outIndices_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(outIndices
					);
				return libxobotos_AssetManager_retrieveAttributes(mObject, xmlParser, inAttrs_handle
					.Address, outValues_handle != null ? outValues_handle.Address : System.IntPtr.Zero
					, outIndices_handle != null ? outIndices_handle.Address : System.IntPtr.Zero);
			}
			finally
			{
				if (inAttrs_handle != null)
				{
					inAttrs_handle.Free();
				}
				if (outValues_handle != null)
				{
					outValues_handle.Free();
				}
				if (outIndices_handle != null)
				{
					outIndices_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_getArraySize(android.content.res.AssetManager.NativeAssetManager
			 _instance, int resource);

		internal int getArraySize(int resource)
		{
			return libxobotos_AssetManager_getArraySize(mObject, resource);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_retrieveArray(android.content.res.AssetManager.NativeAssetManager
			 _instance, int resource, System.IntPtr outValues);

		internal int retrieveArray(int resource, int[] outValues)
		{
			Sharpen.INativeHandle outValues_handle = null;
			try
			{
				outValues_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(outValues
					);
				return libxobotos_AssetManager_retrieveArray(mObject, resource, outValues_handle.
					Address);
			}
			finally
			{
				if (outValues_handle != null)
				{
					outValues_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_getStringBlockCount(android.content.res.AssetManager.NativeAssetManager
			 _instance);

		private int getStringBlockCount()
		{
			return libxobotos_AssetManager_getStringBlockCount(mObject);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.content.res.StringBlock.NativeStringBlock libxobotos_AssetManager_getNativeStringBlock
			(android.content.res.AssetManager.NativeAssetManager _instance, int block);

		private android.content.res.StringBlock.NativeStringBlock getNativeStringBlock(int
			 block)
		{
			return libxobotos_AssetManager_getNativeStringBlock(mObject, block);
		}

		[Sharpen.NativeStub]
		public string getCookieName(int cookie)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		public static int getGlobalAssetCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		public static string getAssetAllocations()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		public static int getGlobalAssetManagerCount()
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.content.res.Resources.Theme.NativeTheme libxobotos_AssetManager_newTheme
			(android.content.res.AssetManager.NativeAssetManager _instance);

		private android.content.res.Resources.Theme.NativeTheme newTheme()
		{
			return libxobotos_AssetManager_newTheme(mObject);
		}

		[Sharpen.NativeStub]
		private void deleteTheme(int theme)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_AssetManager_applyThemeStyle(android.content.res.Resources.Theme.NativeTheme
			 theme, int styleRes, bool force);

		internal static void applyThemeStyle(android.content.res.Resources.Theme.NativeTheme
			 theme, int styleRes, bool force)
		{
			libxobotos_AssetManager_applyThemeStyle(theme, styleRes, force);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_AssetManager_copyTheme(android.content.res.Resources.Theme.NativeTheme
			 dest, android.content.res.Resources.Theme.NativeTheme source);

		internal static void copyTheme(android.content.res.Resources.Theme.NativeTheme dest
			, android.content.res.Resources.Theme.NativeTheme source)
		{
			libxobotos_AssetManager_copyTheme(dest, source);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_AssetManager_loadThemeAttributeValue(android.content.res.Resources.Theme.NativeTheme
			 theme, int ident, out System.IntPtr outValue, bool resolve);

		internal static int loadThemeAttributeValue(android.content.res.Resources.Theme.NativeTheme
			 theme, int ident, android.util.TypedValue outValue, bool resolve)
		{
			System.IntPtr outValue_ptr = System.IntPtr.Zero;
			try
			{
				int _retval = libxobotos_AssetManager_loadThemeAttributeValue(theme, ident, out outValue_ptr
					, resolve);
				android.util.TypedValue.TypedValue_Helper.MarshalOut(outValue_ptr, outValue);
				return _retval;
			}
			finally
			{
				android.util.TypedValue.TypedValue_Helper.FreeNativePtr(outValue_ptr);
			}
		}

		[Sharpen.NativeStub]
		internal static void dumpTheme(int theme, int priority, string tag, string prefix
			)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.content.res.XmlBlock.NativeXmlBlock libxobotos_AssetManager_openXmlAssetNative
			(android.content.res.AssetManager.NativeAssetManager _instance, int cookie, System.IntPtr
			 fileName);

		private android.content.res.XmlBlock.NativeXmlBlock openXmlAssetNative(int cookie
			, string fileName)
		{
			System.IntPtr fileName_ptr = System.IntPtr.Zero;
			try
			{
				fileName_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(fileName
					);
				return libxobotos_AssetManager_openXmlAssetNative(mObject, cookie, fileName_ptr);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(fileName_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_AssetManager_getArrayStringResource
			(android.content.res.AssetManager.NativeAssetManager _instance, int arrayRes);

		private string[] getArrayStringResource(int arrayRes)
		{
			System.IntPtr _retval_ptr = libxobotos_AssetManager_getArrayStringResource(mObject
				, arrayRes);
			string[] _retval = Array_String_Helper.NativeToManaged(_retval_ptr);
			Array_String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_AssetManager_getArrayStringInfo(android.content.res.AssetManager.NativeAssetManager
			 _instance, int arrayRes);

		private int[] getArrayStringInfo(int arrayRes)
		{
			System.IntPtr _retval_ptr = libxobotos_AssetManager_getArrayStringInfo(mObject, arrayRes
				);
			int[] _retval = XobotOS.Runtime.MarshalGlue.Array_int_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.Array_int_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_AssetManager_getArrayIntResource(android.content.res.AssetManager.NativeAssetManager
			 _instance, int arrayRes);

		internal int[] getArrayIntResource(int arrayRes)
		{
			System.IntPtr _retval_ptr = libxobotos_AssetManager_getArrayIntResource(mObject, 
				arrayRes);
			int[] _retval = XobotOS.Runtime.MarshalGlue.Array_int_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.Array_int_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.content.res.AssetManager.NativeAssetManager libxobotos_AssetManager_init
			();

		private android.content.res.AssetManager.NativeAssetManager init()
		{
			return libxobotos_AssetManager_init();
		}

		[Sharpen.NativeStub]
		private void destroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.MarshalHelper(@"NativePtrArray<NativeString>")]
		internal static class Array_String_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_String_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_String_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, string[] arg)
			{
				Array_String_Struct obj = new Array_String_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + Array_String_Helper.NativeSize;
					System.IntPtr[] vector = new System.IntPtr[arg.Length];
					for (int i = 0; i < arg.Length; i++)
					{
						vector[i] = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(arg[i]);
					}
					Marshal.Copy(vector, 0, obj.ptr, arg.Length);
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, string[] arg)
			{
				Array_String_Struct obj = (Array_String_Struct)Marshal.PtrToStructure(ptr, typeof(
					Array_String_Struct));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += XobotOS.Runtime.MarshalGlue.String_Helper
						.NativeSize)
					{
						XobotOS.Runtime.MarshalGlue.String_Helper.MarshalOut(addr, arg[i]);
					}
				}
			}

			public static System.IntPtr ManagedToNative(string[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Array_String_Helper.NativeSize + Marshal.SizeOf
					(typeof(System.IntPtr)) * arg.Length);
				Array_String_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static string[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_String_Struct obj = (Array_String_Struct)Marshal.PtrToStructure(ptr, typeof(
					Array_String_Struct));
				string[] arg = new string[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr[] vector = new System.IntPtr[obj.length];
					Marshal.Copy(obj.ptr, vector, 0, obj.length);
					for (int i = 0; i < obj.length; i++)
					{
						arg[i] = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(vector[i]);
					}
				}
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_android_content_res_AssetManager_Array_String_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_content_res_AssetManager_Array_String_destructor
				(System.IntPtr ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_String_Struct obj = (Array_String_Struct)Marshal.PtrToStructure(ptr, typeof(
					Array_String_Struct));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr[] vector = new System.IntPtr[obj.length];
					Marshal.Copy(obj.ptr, vector, 0, obj.length);
					for (int i = 0; i < obj.length; i++)
					{
						XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(vector[i]);
					}
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				Array_String_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}

		public void Dispose()
		{
			mObject.Dispose();
		}

		internal class NativeAssetManager : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeAssetManager() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeAssetManager(System.IntPtr handle) : base(System.IntPtr.Zero, true
				)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_content_res_AssetManager_destructor
				(System.IntPtr handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeAssetManager Zero = new NativeAssetManager();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_content_res_AssetManager_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
