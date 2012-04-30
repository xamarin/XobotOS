using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Package archive parsing
	/// <hide></hide>
	/// </summary>
	[Sharpen.Sharpened]
	public class PackageParser
	{
		internal const bool DEBUG_JAR = false;

		internal const bool DEBUG_PARSER = false;

		internal const bool DEBUG_BACKUP = false;

		/// <summary>File name in an APK for the Android manifest.</summary>
		/// <remarks>File name in an APK for the Android manifest.</remarks>
		internal const string ANDROID_MANIFEST_FILENAME = "AndroidManifest.xml";

		/// <hide></hide>
		public class NewPermissionInfo
		{
			public readonly string name;

			public readonly int sdkVersion;

			public readonly int fileVersion;

			public NewPermissionInfo(string name, int sdkVersion, int fileVersion)
			{
				this.name = name;
				this.sdkVersion = sdkVersion;
				this.fileVersion = fileVersion;
			}
		}

		/// <summary>List of new permissions that have been added since 1.0.</summary>
		/// <remarks>
		/// List of new permissions that have been added since 1.0.
		/// NOTE: These must be declared in SDK version order, with permissions
		/// added to older SDKs appearing before those added to newer SDKs.
		/// </remarks>
		/// <hide></hide>
		public static readonly android.content.pm.PackageParser.NewPermissionInfo[] NEW_PERMISSIONS
			 = new android.content.pm.PackageParser.NewPermissionInfo[] { new android.content.pm.PackageParser
			.NewPermissionInfo(android.Manifest.permission.WRITE_EXTERNAL_STORAGE, android.os.Build
			.VERSION_CODES.DONUT, 0), new android.content.pm.PackageParser.NewPermissionInfo
			(android.Manifest.permission.READ_PHONE_STATE, android.os.Build.VERSION_CODES.DONUT
			, 0) };

		private string mArchiveSourcePath;

		private string[] mSeparateProcesses;

		private bool mOnlyCoreApps;

		private static readonly int SDK_VERSION = android.os.Build.VERSION.SDK_INT;

		private static readonly string SDK_CODENAME = "REL".Equals(android.os.Build.VERSION
			.CODENAME) ? null : android.os.Build.VERSION.CODENAME;

		private int mParseError = android.content.pm.PackageManager.INSTALL_SUCCEEDED;

		private static readonly object mSync = new object();

		private static java.lang.@ref.WeakReference<byte[]> mReadBuffer;

		private static bool sCompatibilityModeEnabled = true;

		internal const int PARSE_DEFAULT_INSTALL_LOCATION = android.content.pm.PackageInfo
			.INSTALL_LOCATION_UNSPECIFIED;

		internal class ParsePackageItemArgs
		{
			internal readonly android.content.pm.PackageParser.Package owner;

			internal readonly string[] outError;

			internal readonly int nameRes;

			internal readonly int labelRes;

			internal readonly int iconRes;

			internal readonly int logoRes;

			internal string tag;

			internal android.content.res.TypedArray sa;

			internal ParsePackageItemArgs(android.content.pm.PackageParser.Package _owner, string
				[] _outError, int _nameRes, int _labelRes, int _iconRes, int _logoRes)
			{
				owner = _owner;
				outError = _outError;
				nameRes = _nameRes;
				labelRes = _labelRes;
				iconRes = _iconRes;
				logoRes = _logoRes;
			}
		}

		internal class ParseComponentArgs : android.content.pm.PackageParser.ParsePackageItemArgs
		{
			internal readonly string[] sepProcesses;

			internal readonly int processRes;

			internal readonly int descriptionRes;

			internal readonly int enabledRes;

			internal int flags;

			internal ParseComponentArgs(android.content.pm.PackageParser.Package _owner, string
				[] _outError, int _nameRes, int _labelRes, int _iconRes, int _logoRes, string[] 
				_sepProcesses, int _processRes, int _descriptionRes, int _enabledRes) : base(_owner
				, _outError, _nameRes, _labelRes, _iconRes, _logoRes)
			{
				sepProcesses = _sepProcesses;
				processRes = _processRes;
				descriptionRes = _descriptionRes;
				enabledRes = _enabledRes;
			}
		}

		public class PackageLite
		{
			public readonly string packageName;

			public readonly int installLocation;

			public readonly android.content.pm.VerifierInfo[] verifiers;

			public PackageLite(string packageName, int installLocation, java.util.List<android.content.pm.VerifierInfo
				> verifiers)
			{
				this.packageName = packageName;
				this.installLocation = installLocation;
				this.verifiers = verifiers.toArray(new android.content.pm.VerifierInfo[verifiers.
					size()]);
			}
		}

		private android.content.pm.PackageParser.ParsePackageItemArgs mParseInstrumentationArgs;

		private android.content.pm.PackageParser.ParseComponentArgs mParseActivityArgs;

		private android.content.pm.PackageParser.ParseComponentArgs mParseActivityAliasArgs;

		private android.content.pm.PackageParser.ParseComponentArgs mParseServiceArgs;

		private android.content.pm.PackageParser.ParseComponentArgs mParseProviderArgs;

		/// <summary>
		/// If set to true, we will only allow package files that exactly match
		/// the DTD.
		/// </summary>
		/// <remarks>
		/// If set to true, we will only allow package files that exactly match
		/// the DTD.  Otherwise, we try to get as much from the package as we
		/// can without failing.  This should normally be set to false, to
		/// support extensions to the DTD in future versions.
		/// </remarks>
		internal const bool RIGID_PARSER = false;

		internal const string TAG = "PackageParser";

		public PackageParser(string archiveSourcePath)
		{
			mArchiveSourcePath = archiveSourcePath;
		}

		public virtual void setSeparateProcesses(string[] procs)
		{
			mSeparateProcesses = procs;
		}

		public virtual void setOnlyCoreApps(bool onlyCoreApps)
		{
			mOnlyCoreApps = onlyCoreApps;
		}

		private static bool isPackageFilename(string name)
		{
			return name.EndsWith(".apk");
		}

		/// <summary>
		/// Generate and return the
		/// <see cref="PackageInfo">PackageInfo</see>
		/// for a parsed package.
		/// </summary>
		/// <param name="p">the parsed package.</param>
		/// <param name="flags">indicating which optional information is included.</param>
		public static android.content.pm.PackageInfo generatePackageInfo(android.content.pm.PackageParser
			.Package p, int[] gids, int flags, long firstInstallTime, long lastUpdateTime)
		{
			android.content.pm.PackageInfo pi = new android.content.pm.PackageInfo();
			pi.packageName = p.packageName;
			pi.versionCode = p.mVersionCode;
			pi.versionName = p.mVersionName;
			pi.sharedUserId = p.mSharedUserId;
			pi.sharedUserLabel = p.mSharedUserLabel;
			pi.applicationInfo = generateApplicationInfo(p, flags);
			pi.installLocation = p.installLocation;
			pi.firstInstallTime = firstInstallTime;
			pi.lastUpdateTime = lastUpdateTime;
			if ((flags & android.content.pm.PackageManager.GET_GIDS) != 0)
			{
				pi.gids = gids;
			}
			if ((flags & android.content.pm.PackageManager.GET_CONFIGURATIONS) != 0)
			{
				int N = p.configPreferences.size();
				if (N > 0)
				{
					pi.configPreferences = new android.content.pm.ConfigurationInfo[N];
					p.configPreferences.toArray(pi.configPreferences);
				}
				N = p.reqFeatures != null ? p.reqFeatures.size() : 0;
				if (N > 0)
				{
					pi.reqFeatures = new android.content.pm.FeatureInfo[N];
					p.reqFeatures.toArray(pi.reqFeatures);
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_ACTIVITIES) != 0)
			{
				int N = p.activities.size();
				if (N > 0)
				{
					if ((flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS) != 0)
					{
						pi.activities = new android.content.pm.ActivityInfo[N];
					}
					else
					{
						int num = 0;
						{
							for (int i = 0; i < N; i++)
							{
								if (p.activities.get(i).info.enabled)
								{
									num++;
								}
							}
						}
						pi.activities = new android.content.pm.ActivityInfo[num];
					}
					{
						int i_1 = 0;
						int j = 0;
						for (; i_1 < N; i_1++)
						{
							android.content.pm.PackageParser.Activity activity = p.activities.get(i_1);
							if (activity.info.enabled || (flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS
								) != 0)
							{
								pi.activities[j++] = generateActivityInfo(p.activities.get(i_1), flags);
							}
						}
					}
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_RECEIVERS) != 0)
			{
				int N = p.receivers.size();
				if (N > 0)
				{
					if ((flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS) != 0)
					{
						pi.receivers = new android.content.pm.ActivityInfo[N];
					}
					else
					{
						int num = 0;
						{
							for (int i = 0; i < N; i++)
							{
								if (p.receivers.get(i).info.enabled)
								{
									num++;
								}
							}
						}
						pi.receivers = new android.content.pm.ActivityInfo[num];
					}
					{
						int i_1 = 0;
						int j = 0;
						for (; i_1 < N; i_1++)
						{
							android.content.pm.PackageParser.Activity activity = p.receivers.get(i_1);
							if (activity.info.enabled || (flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS
								) != 0)
							{
								pi.receivers[j++] = generateActivityInfo(p.receivers.get(i_1), flags);
							}
						}
					}
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_SERVICES) != 0)
			{
				int N = p.services.size();
				if (N > 0)
				{
					if ((flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS) != 0)
					{
						pi.services = new android.content.pm.ServiceInfo[N];
					}
					else
					{
						int num = 0;
						{
							for (int i = 0; i < N; i++)
							{
								if (p.services.get(i).info.enabled)
								{
									num++;
								}
							}
						}
						pi.services = new android.content.pm.ServiceInfo[num];
					}
					{
						int i_1 = 0;
						int j = 0;
						for (; i_1 < N; i_1++)
						{
							android.content.pm.PackageParser.Service service = p.services.get(i_1);
							if (service.info.enabled || (flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS
								) != 0)
							{
								pi.services[j++] = generateServiceInfo(p.services.get(i_1), flags);
							}
						}
					}
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_PROVIDERS) != 0)
			{
				int N = p.providers.size();
				if (N > 0)
				{
					if ((flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS) != 0)
					{
						pi.providers = new android.content.pm.ProviderInfo[N];
					}
					else
					{
						int num = 0;
						{
							for (int i = 0; i < N; i++)
							{
								if (p.providers.get(i).info.enabled)
								{
									num++;
								}
							}
						}
						pi.providers = new android.content.pm.ProviderInfo[num];
					}
					{
						int i_1 = 0;
						int j = 0;
						for (; i_1 < N; i_1++)
						{
							android.content.pm.PackageParser.Provider provider = p.providers.get(i_1);
							if (provider.info.enabled || (flags & android.content.pm.PackageManager.GET_DISABLED_COMPONENTS
								) != 0)
							{
								pi.providers[j++] = generateProviderInfo(p.providers.get(i_1), flags);
							}
						}
					}
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_INSTRUMENTATION) != 0)
			{
				int N = p.instrumentation.size();
				if (N > 0)
				{
					pi.instrumentation = new android.content.pm.InstrumentationInfo[N];
					{
						for (int i = 0; i < N; i++)
						{
							pi.instrumentation[i] = generateInstrumentationInfo(p.instrumentation.get(i), flags
								);
						}
					}
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_PERMISSIONS) != 0)
			{
				int N = p.permissions.size();
				if (N > 0)
				{
					pi.permissions = new android.content.pm.PermissionInfo[N];
					{
						for (int i = 0; i < N; i++)
						{
							pi.permissions[i] = generatePermissionInfo(p.permissions.get(i), flags);
						}
					}
				}
				N = p.requestedPermissions.size();
				if (N > 0)
				{
					pi.requestedPermissions = new string[N];
					{
						for (int i = 0; i < N; i++)
						{
							pi.requestedPermissions[i] = p.requestedPermissions.get(i);
						}
					}
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_SIGNATURES) != 0)
			{
				int N = (p.mSignatures != null) ? p.mSignatures.Length : 0;
				if (N > 0)
				{
					pi.signatures = new android.content.pm.Signature[N];
					System.Array.Copy(p.mSignatures, 0, pi.signatures, 0, N);
				}
			}
			return pi;
		}

		[Sharpen.Stub]
		private java.security.cert.Certificate[] loadCertificates(java.util.jar.JarFile jarFile
			, java.util.jar.JarEntry je, byte[] readBuffer)
		{
			throw new System.NotImplementedException();
		}

		public const int PARSE_IS_SYSTEM = 1 << 0;

		public const int PARSE_CHATTY = 1 << 1;

		public const int PARSE_MUST_BE_APK = 1 << 2;

		public const int PARSE_IGNORE_PROCESSES = 1 << 3;

		public const int PARSE_FORWARD_LOCK = 1 << 4;

		public const int PARSE_ON_SDCARD = 1 << 5;

		public const int PARSE_IS_SYSTEM_DIR = 1 << 6;

		// We must read the stream for the JarEntry to retrieve
		// its certificates.
		// not using
		public virtual int getParseError()
		{
			return mParseError;
		}

		public virtual android.content.pm.PackageParser.Package parsePackage(java.io.File
			 sourceFile, string destCodePath, android.util.DisplayMetrics metrics, int flags
			)
		{
			mParseError = android.content.pm.PackageManager.INSTALL_SUCCEEDED;
			mArchiveSourcePath = sourceFile.getPath();
			if (!sourceFile.isFile())
			{
				android.util.Slog.w(TAG, "Skipping dir: " + mArchiveSourcePath);
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_NOT_APK;
				return null;
			}
			if (!isPackageFilename(sourceFile.getName()) && (flags & PARSE_MUST_BE_APK) != 0)
			{
				if ((flags & PARSE_IS_SYSTEM) == 0)
				{
					// We expect to have non-.apk files in the system dir,
					// so don't warn about them.
					android.util.Slog.w(TAG, "Skipping non-package file: " + mArchiveSourcePath);
				}
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_NOT_APK;
				return null;
			}
			android.content.res.XmlResourceParser parser = null;
			android.content.res.AssetManager assmgr = null;
			android.content.res.Resources res = null;
			bool assetError = true;
			try
			{
				assmgr = new android.content.res.AssetManager();
				int cookie = assmgr.addAssetPath(mArchiveSourcePath);
				if (cookie != 0)
				{
					res = new android.content.res.Resources(assmgr, metrics, null);
					assmgr.setConfiguration(0, 0, null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, android.os.Build
						.VERSION.RESOURCES_SDK_INT);
					parser = assmgr.openXmlResourceParser(cookie, ANDROID_MANIFEST_FILENAME);
					assetError = false;
				}
				else
				{
					android.util.Slog.w(TAG, "Failed adding asset path:" + mArchiveSourcePath);
				}
			}
			catch (System.Exception e)
			{
				android.util.Slog.w(TAG, "Unable to read AndroidManifest.xml of " + mArchiveSourcePath
					, e);
			}
			if (assetError)
			{
				if (assmgr != null)
				{
					assmgr.close();
				}
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_BAD_MANIFEST;
				return null;
			}
			string[] errorText = new string[1];
			android.content.pm.PackageParser.Package pkg = null;
			System.Exception errorException = null;
			try
			{
				// XXXX todo: need to figure out correct configuration.
				pkg = parsePackage(res, parser, flags, errorText);
			}
			catch (System.Exception e)
			{
				errorException = e;
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_UNEXPECTED_EXCEPTION;
			}
			if (pkg == null)
			{
				// If we are only parsing core apps, then a null with INSTALL_SUCCEEDED
				// just means to skip this app so don't make a fuss about it.
				if (!mOnlyCoreApps || mParseError != android.content.pm.PackageManager.INSTALL_SUCCEEDED)
				{
					if (errorException != null)
					{
						android.util.Slog.w(TAG, mArchiveSourcePath, errorException);
					}
					else
					{
						android.util.Slog.w(TAG, mArchiveSourcePath + " (at " + parser.getPositionDescription
							() + "): " + errorText[0]);
					}
					if (mParseError == android.content.pm.PackageManager.INSTALL_SUCCEEDED)
					{
						mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
					}
				}
				parser.close();
				assmgr.close();
				return null;
			}
			parser.close();
			assmgr.close();
			// Set code and resource paths
			pkg.mPath = destCodePath;
			pkg.mScanPath = mArchiveSourcePath;
			//pkg.applicationInfo.sourceDir = destCodePath;
			//pkg.applicationInfo.publicSourceDir = destRes;
			pkg.mSignatures = null;
			return pkg;
		}

		[Sharpen.Stub]
		public virtual bool collectCertificates(android.content.pm.PackageParser.Package 
			pkg, int flags)
		{
			throw new System.NotImplementedException();
		}

		// If this package comes from the system image, then we
		// can trust it...  we'll just use the AndroidManifest.xml
		// to retrieve its signatures, not validating all of the
		// files.
		// Ensure all certificates match.
		public static android.content.pm.PackageParser.PackageLite parsePackageLite(string
			 packageFilePath, int flags)
		{
			android.content.res.AssetManager assmgr = null;
			android.content.res.XmlResourceParser parser;
			android.content.res.Resources res;
			try
			{
				assmgr = new android.content.res.AssetManager();
				assmgr.setConfiguration(0, 0, null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, android.os.Build
					.VERSION.RESOURCES_SDK_INT);
				int cookie = assmgr.addAssetPath(packageFilePath);
				if (cookie == 0)
				{
					return null;
				}
				android.util.DisplayMetrics metrics = new android.util.DisplayMetrics();
				metrics.setToDefaults();
				res = new android.content.res.Resources(assmgr, metrics, null);
				parser = assmgr.openXmlResourceParser(cookie, ANDROID_MANIFEST_FILENAME);
			}
			catch (System.Exception e)
			{
				if (assmgr != null)
				{
					assmgr.close();
				}
				android.util.Slog.w(TAG, "Unable to read AndroidManifest.xml of " + packageFilePath
					, e);
				return null;
			}
			android.util.AttributeSet attrs = parser;
			string[] errors = new string[1];
			android.content.pm.PackageParser.PackageLite packageLite = null;
			try
			{
				packageLite = parsePackageLite(res, parser, attrs, flags, errors);
			}
			catch (System.IO.IOException e)
			{
				android.util.Slog.w(TAG, packageFilePath, e);
			}
			catch (org.xmlpull.v1.XmlPullParserException e)
			{
				android.util.Slog.w(TAG, packageFilePath, e);
			}
			finally
			{
				if (parser != null)
				{
					parser.close();
				}
				if (assmgr != null)
				{
					assmgr.close();
				}
			}
			if (packageLite == null)
			{
				android.util.Slog.e(TAG, "parsePackageLite error: " + errors[0]);
				return null;
			}
			return packageLite;
		}

		private static string validateName(string name, bool requiresSeparator)
		{
			int N = name.Length;
			bool hasSep = false;
			bool front = true;
			{
				for (int i = 0; i < N; i++)
				{
					char c = name[i];
					if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
					{
						front = false;
						continue;
					}
					if (!front)
					{
						if ((c >= '0' && c <= '9') || c == '_')
						{
							continue;
						}
					}
					if (c == '.')
					{
						hasSep = true;
						front = true;
						continue;
					}
					return "bad character '" + c + "'";
				}
			}
			return hasSep || !requiresSeparator ? null : "must have at least one '.' separator";
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		private static string parsePackageName(org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet
			 attrs, int flags, string[] outError)
		{
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG && type
				 != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
			}
			if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
			{
				outError[0] = "No start tag found";
				return null;
			}
			if (!parser.getName().Equals("manifest"))
			{
				outError[0] = "No <manifest> tag";
				return null;
			}
			string pkgName = attrs.getAttributeValue(null, "package");
			if (pkgName == null || pkgName.Length == 0)
			{
				outError[0] = "<manifest> does not specify package";
				return null;
			}
			string nameError = validateName(pkgName, true);
			if (nameError != null && !"android".Equals(pkgName))
			{
				outError[0] = "<manifest> specifies bad package name \"" + pkgName + "\": " + nameError;
				return null;
			}
			return string.Intern(pkgName);
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		private static android.content.pm.PackageParser.PackageLite parsePackageLite(android.content.res.Resources
			 res, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs, int 
			flags, string[] outError)
		{
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG && type
				 != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
			}
			if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
			{
				outError[0] = "No start tag found";
				return null;
			}
			if (!parser.getName().Equals("manifest"))
			{
				outError[0] = "No <manifest> tag";
				return null;
			}
			string pkgName = attrs.getAttributeValue(null, "package");
			if (pkgName == null || pkgName.Length == 0)
			{
				outError[0] = "<manifest> does not specify package";
				return null;
			}
			string nameError = validateName(pkgName, true);
			if (nameError != null && !"android".Equals(pkgName))
			{
				outError[0] = "<manifest> specifies bad package name \"" + pkgName + "\": " + nameError;
				return null;
			}
			int installLocation = PARSE_DEFAULT_INSTALL_LOCATION;
			{
				for (int i = 0; i < attrs.getAttributeCount(); i++)
				{
					string attr = attrs.getAttributeName(i);
					if (attr.Equals("installLocation"))
					{
						installLocation = attrs.getAttributeIntValue(i, PARSE_DEFAULT_INSTALL_LOCATION);
						break;
					}
				}
			}
			// Only search the tree when the tag is directly below <manifest>
			int searchDepth = parser.getDepth() + 1;
			java.util.List<android.content.pm.VerifierInfo> verifiers = new java.util.ArrayList
				<android.content.pm.VerifierInfo>();
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() >= searchDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				if (parser.getDepth() == searchDepth && "package-verifier".Equals(parser.getName(
					)))
				{
					android.content.pm.VerifierInfo verifier = parseVerifier(res, parser, attrs, flags
						, outError);
					if (verifier != null)
					{
						verifiers.add(verifier);
					}
				}
			}
			return new android.content.pm.PackageParser.PackageLite(string.Intern(pkgName), installLocation
				, verifiers);
		}

		/// <summary>Temporary.</summary>
		/// <remarks>Temporary.</remarks>
		public static android.content.pm.Signature stringToSignature(string str)
		{
			int N = str.Length;
			byte[] sig = new byte[N];
			{
				for (int i = 0; i < N; i++)
				{
					sig[i] = unchecked((byte)str[i]);
				}
			}
			return new android.content.pm.Signature(sig);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Package parsePackage(android.content.res.Resources
			 res, android.content.res.XmlResourceParser parser, int flags, string[] outError
			)
		{
			android.util.AttributeSet attrs = parser;
			mParseInstrumentationArgs = null;
			mParseActivityArgs = null;
			mParseServiceArgs = null;
			mParseProviderArgs = null;
			string pkgName = parsePackageName(parser, attrs, flags, outError);
			if (pkgName == null)
			{
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_BAD_PACKAGE_NAME;
				return null;
			}
			int type;
			if (mOnlyCoreApps)
			{
				bool core = attrs.getAttributeBooleanValue(null, "coreApp", false);
				if (!core)
				{
					mParseError = android.content.pm.PackageManager.INSTALL_SUCCEEDED;
					return null;
				}
			}
			android.content.pm.PackageParser.Package pkg = new android.content.pm.PackageParser
				.Package(pkgName);
			bool foundApp = false;
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifest);
			pkg.mVersionCode = sa.getInteger(android.@internal.R.styleable.AndroidManifest_versionCode
				, 0);
			pkg.mVersionName = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifest_versionName
				, 0);
			if (pkg.mVersionName != null)
			{
				pkg.mVersionName = string.Intern(pkg.mVersionName);
			}
			string str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifest_sharedUserId
				, 0);
			if (str != null && str.Length > 0)
			{
				string nameError = validateName(str, true);
				if (nameError != null && !"android".Equals(pkgName))
				{
					outError[0] = "<manifest> specifies bad sharedUserId name \"" + str + "\": " + nameError;
					mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_BAD_SHARED_USER_ID;
					return null;
				}
				pkg.mSharedUserId = string.Intern(str);
				pkg.mSharedUserLabel = sa.getResourceId(android.@internal.R.styleable.AndroidManifest_sharedUserLabel
					, 0);
			}
			sa.recycle();
			pkg.installLocation = sa.getInteger(android.@internal.R.styleable.AndroidManifest_installLocation
				, PARSE_DEFAULT_INSTALL_LOCATION);
			pkg.applicationInfo.installLocation = pkg.installLocation;
			// Resource boolean are -1, so 1 means we don't know the value.
			int supportsSmallScreens = 1;
			int supportsNormalScreens = 1;
			int supportsLargeScreens = 1;
			int supportsXLargeScreens = 1;
			int resizeable = 1;
			int anyDensity = 1;
			int outerDepth = parser.getDepth();
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				string tagName = parser.getName();
				if (tagName.Equals("application"))
				{
					if (foundApp)
					{
						android.util.Slog.w(TAG, "<manifest> has more than one <application>");
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
						continue;
					}
					foundApp = true;
					if (!parseApplication(pkg, res, parser, attrs, flags, outError))
					{
						return null;
					}
				}
				else
				{
					if (tagName.Equals("permission-group"))
					{
						if (parsePermissionGroup(pkg, res, parser, attrs, outError) == null)
						{
							return null;
						}
					}
					else
					{
						if (tagName.Equals("permission"))
						{
							if (parsePermission(pkg, res, parser, attrs, outError) == null)
							{
								return null;
							}
						}
						else
						{
							if (tagName.Equals("permission-tree"))
							{
								if (parsePermissionTree(pkg, res, parser, attrs, outError) == null)
								{
									return null;
								}
							}
							else
							{
								if (tagName.Equals("uses-permission"))
								{
									sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestUsesPermission
										);
									// Note: don't allow this value to be a reference to a resource
									// that may change.
									string name = sa.getNonResourceString(android.@internal.R.styleable.AndroidManifestUsesPermission_name
										);
									sa.recycle();
									if (name != null && !pkg.requestedPermissions.contains(name))
									{
										pkg.requestedPermissions.add(string.Intern(name));
									}
									android.util.@internal.XmlUtils.skipCurrentTag(parser);
								}
								else
								{
									if (tagName.Equals("uses-configuration"))
									{
										android.content.pm.ConfigurationInfo cPref = new android.content.pm.ConfigurationInfo
											();
										sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestUsesConfiguration
											);
										cPref.reqTouchScreen = sa.getInt(android.@internal.R.styleable.AndroidManifestUsesConfiguration_reqTouchScreen
											, android.content.res.Configuration.TOUCHSCREEN_UNDEFINED);
										cPref.reqKeyboardType = sa.getInt(android.@internal.R.styleable.AndroidManifestUsesConfiguration_reqKeyboardType
											, android.content.res.Configuration.KEYBOARD_UNDEFINED);
										if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestUsesConfiguration_reqHardKeyboard
											, false))
										{
											cPref.reqInputFeatures |= android.content.pm.ConfigurationInfo.INPUT_FEATURE_HARD_KEYBOARD;
										}
										cPref.reqNavigation = sa.getInt(android.@internal.R.styleable.AndroidManifestUsesConfiguration_reqNavigation
											, android.content.res.Configuration.NAVIGATION_UNDEFINED);
										if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestUsesConfiguration_reqFiveWayNav
											, false))
										{
											cPref.reqInputFeatures |= android.content.pm.ConfigurationInfo.INPUT_FEATURE_FIVE_WAY_NAV;
										}
										sa.recycle();
										pkg.configPreferences.add(cPref);
										android.util.@internal.XmlUtils.skipCurrentTag(parser);
									}
									else
									{
										if (tagName.Equals("uses-feature"))
										{
											android.content.pm.FeatureInfo fi = new android.content.pm.FeatureInfo();
											sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestUsesFeature
												);
											// Note: don't allow this value to be a reference to a resource
											// that may change.
											fi.name = sa.getNonResourceString(android.@internal.R.styleable.AndroidManifestUsesFeature_name
												);
											if (fi.name == null)
											{
												fi.reqGlEsVersion = sa.getInt(android.@internal.R.styleable.AndroidManifestUsesFeature_glEsVersion
													, android.content.pm.FeatureInfo.GL_ES_VERSION_UNDEFINED);
											}
											if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestUsesFeature_required
												, true))
											{
												fi.flags |= android.content.pm.FeatureInfo.FLAG_REQUIRED;
											}
											sa.recycle();
											if (pkg.reqFeatures == null)
											{
												pkg.reqFeatures = new java.util.ArrayList<android.content.pm.FeatureInfo>();
											}
											pkg.reqFeatures.add(fi);
											if (fi.name == null)
											{
												android.content.pm.ConfigurationInfo cPref = new android.content.pm.ConfigurationInfo
													();
												cPref.reqGlEsVersion = fi.reqGlEsVersion;
												pkg.configPreferences.add(cPref);
											}
											android.util.@internal.XmlUtils.skipCurrentTag(parser);
										}
										else
										{
											if (tagName.Equals("uses-sdk"))
											{
												if (SDK_VERSION > 0)
												{
													sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestUsesSdk
														);
													int minVers = 0;
													string minCode = null;
													int targetVers = 0;
													string targetCode = null;
													android.util.TypedValue val = sa.peekValue(android.@internal.R.styleable.AndroidManifestUsesSdk_minSdkVersion
														);
													if (val != null)
													{
														if (val.type == android.util.TypedValue.TYPE_STRING && val.@string != null)
														{
															targetCode = minCode = val.@string.ToString();
														}
														else
														{
															// If it's not a string, it's an integer.
															targetVers = minVers = val.data;
														}
													}
													val = sa.peekValue(android.@internal.R.styleable.AndroidManifestUsesSdk_targetSdkVersion
														);
													if (val != null)
													{
														if (val.type == android.util.TypedValue.TYPE_STRING && val.@string != null)
														{
															targetCode = minCode = val.@string.ToString();
														}
														else
														{
															// If it's not a string, it's an integer.
															targetVers = val.data;
														}
													}
													sa.recycle();
													if (minCode != null)
													{
														if (!minCode.Equals(SDK_CODENAME))
														{
															if (SDK_CODENAME != null)
															{
																outError[0] = "Requires development platform " + minCode + " (current platform is "
																	 + SDK_CODENAME + ")";
															}
															else
															{
																outError[0] = "Requires development platform " + minCode + " but this is a release platform.";
															}
															mParseError = android.content.pm.PackageManager.INSTALL_FAILED_OLDER_SDK;
															return null;
														}
													}
													else
													{
														if (minVers > SDK_VERSION)
														{
															outError[0] = "Requires newer sdk version #" + minVers + " (current version is #"
																 + SDK_VERSION + ")";
															mParseError = android.content.pm.PackageManager.INSTALL_FAILED_OLDER_SDK;
															return null;
														}
													}
													if (targetCode != null)
													{
														if (!targetCode.Equals(SDK_CODENAME))
														{
															if (SDK_CODENAME != null)
															{
																outError[0] = "Requires development platform " + targetCode + " (current platform is "
																	 + SDK_CODENAME + ")";
															}
															else
															{
																outError[0] = "Requires development platform " + targetCode + " but this is a release platform.";
															}
															mParseError = android.content.pm.PackageManager.INSTALL_FAILED_OLDER_SDK;
															return null;
														}
														// If the code matches, it definitely targets this SDK.
														pkg.applicationInfo.targetSdkVersion = android.os.Build.VERSION_CODES.CUR_DEVELOPMENT;
													}
													else
													{
														pkg.applicationInfo.targetSdkVersion = targetVers;
													}
												}
												android.util.@internal.XmlUtils.skipCurrentTag(parser);
											}
											else
											{
												if (tagName.Equals("supports-screens"))
												{
													sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestSupportsScreens
														);
													pkg.applicationInfo.requiresSmallestWidthDp = sa.getInteger(android.@internal.R.styleable
														.AndroidManifestSupportsScreens_requiresSmallestWidthDp, 0);
													pkg.applicationInfo.compatibleWidthLimitDp = sa.getInteger(android.@internal.R.styleable
														.AndroidManifestSupportsScreens_compatibleWidthLimitDp, 0);
													pkg.applicationInfo.largestWidthLimitDp = sa.getInteger(android.@internal.R.styleable
														.AndroidManifestSupportsScreens_largestWidthLimitDp, 0);
													// This is a trick to get a boolean and still able to detect
													// if a value was actually set.
													supportsSmallScreens = sa.getInteger(android.@internal.R.styleable.AndroidManifestSupportsScreens_smallScreens
														, supportsSmallScreens);
													supportsNormalScreens = sa.getInteger(android.@internal.R.styleable.AndroidManifestSupportsScreens_normalScreens
														, supportsNormalScreens);
													supportsLargeScreens = sa.getInteger(android.@internal.R.styleable.AndroidManifestSupportsScreens_largeScreens
														, supportsLargeScreens);
													supportsXLargeScreens = sa.getInteger(android.@internal.R.styleable.AndroidManifestSupportsScreens_xlargeScreens
														, supportsXLargeScreens);
													resizeable = sa.getInteger(android.@internal.R.styleable.AndroidManifestSupportsScreens_resizeable
														, resizeable);
													anyDensity = sa.getInteger(android.@internal.R.styleable.AndroidManifestSupportsScreens_anyDensity
														, anyDensity);
													sa.recycle();
													android.util.@internal.XmlUtils.skipCurrentTag(parser);
												}
												else
												{
													if (tagName.Equals("protected-broadcast"))
													{
														sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestProtectedBroadcast
															);
														// Note: don't allow this value to be a reference to a resource
														// that may change.
														string name = sa.getNonResourceString(android.@internal.R.styleable.AndroidManifestProtectedBroadcast_name
															);
														sa.recycle();
														if (name != null && (flags & PARSE_IS_SYSTEM) != 0)
														{
															if (pkg.protectedBroadcasts == null)
															{
																pkg.protectedBroadcasts = new java.util.ArrayList<string>();
															}
															if (!pkg.protectedBroadcasts.contains(name))
															{
																pkg.protectedBroadcasts.add(string.Intern(name));
															}
														}
														android.util.@internal.XmlUtils.skipCurrentTag(parser);
													}
													else
													{
														if (tagName.Equals("instrumentation"))
														{
															if (parseInstrumentation(pkg, res, parser, attrs, outError) == null)
															{
																return null;
															}
														}
														else
														{
															if (tagName.Equals("original-package"))
															{
																sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestOriginalPackage
																	);
																string orig = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestOriginalPackage_name
																	, 0);
																if (!pkg.packageName.Equals(orig))
																{
																	if (pkg.mOriginalPackages == null)
																	{
																		pkg.mOriginalPackages = new java.util.ArrayList<string>();
																		pkg.mRealPackage = pkg.packageName;
																	}
																	pkg.mOriginalPackages.add(orig);
																}
																sa.recycle();
																android.util.@internal.XmlUtils.skipCurrentTag(parser);
															}
															else
															{
																if (tagName.Equals("adopt-permissions"))
																{
																	sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestOriginalPackage
																		);
																	string name = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestOriginalPackage_name
																		, 0);
																	sa.recycle();
																	if (name != null)
																	{
																		if (pkg.mAdoptPermissions == null)
																		{
																			pkg.mAdoptPermissions = new java.util.ArrayList<string>();
																		}
																		pkg.mAdoptPermissions.add(name);
																	}
																	android.util.@internal.XmlUtils.skipCurrentTag(parser);
																}
																else
																{
																	if (tagName.Equals("uses-gl-texture"))
																	{
																		// Just skip this tag
																		android.util.@internal.XmlUtils.skipCurrentTag(parser);
																		continue;
																	}
																	else
																	{
																		if (tagName.Equals("compatible-screens"))
																		{
																			// Just skip this tag
																			android.util.@internal.XmlUtils.skipCurrentTag(parser);
																			continue;
																		}
																		else
																		{
																			if (tagName.Equals("eat-comment"))
																			{
																				// Just skip this tag
																				android.util.@internal.XmlUtils.skipCurrentTag(parser);
																				continue;
																			}
																			else
																			{
																				android.util.Slog.w(TAG, "Unknown element under <manifest>: " + parser.getName() 
																					+ " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
																				android.util.@internal.XmlUtils.skipCurrentTag(parser);
																				continue;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (!foundApp && pkg.instrumentation.size() == 0)
			{
				outError[0] = "<manifest> does not contain an <application> or <instrumentation>";
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_EMPTY;
			}
			int NP = android.content.pm.PackageParser.NEW_PERMISSIONS.Length;
			java.lang.StringBuilder implicitPerms = null;
			{
				for (int ip = 0; ip < NP; ip++)
				{
					android.content.pm.PackageParser.NewPermissionInfo npi = android.content.pm.PackageParser
						.NEW_PERMISSIONS[ip];
					if (pkg.applicationInfo.targetSdkVersion >= npi.sdkVersion)
					{
						break;
					}
					if (!pkg.requestedPermissions.contains(npi.name))
					{
						if (implicitPerms == null)
						{
							implicitPerms = new java.lang.StringBuilder(128);
							implicitPerms.append(pkg.packageName);
							implicitPerms.append(": compat added ");
						}
						else
						{
							implicitPerms.append(' ');
						}
						implicitPerms.append(npi.name);
						pkg.requestedPermissions.add(npi.name);
					}
				}
			}
			if (implicitPerms != null)
			{
				android.util.Slog.i(TAG, implicitPerms.ToString());
			}
			if (supportsSmallScreens < 0 || (supportsSmallScreens > 0 && pkg.applicationInfo.
				targetSdkVersion >= android.os.Build.VERSION_CODES.DONUT))
			{
				pkg.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_SUPPORTS_SMALL_SCREENS;
			}
			if (supportsNormalScreens != 0)
			{
				pkg.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_SUPPORTS_NORMAL_SCREENS;
			}
			if (supportsLargeScreens < 0 || (supportsLargeScreens > 0 && pkg.applicationInfo.
				targetSdkVersion >= android.os.Build.VERSION_CODES.DONUT))
			{
				pkg.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_SUPPORTS_LARGE_SCREENS;
			}
			if (supportsXLargeScreens < 0 || (supportsXLargeScreens > 0 && pkg.applicationInfo
				.targetSdkVersion >= android.os.Build.VERSION_CODES.GINGERBREAD))
			{
				pkg.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_SUPPORTS_XLARGE_SCREENS;
			}
			if (resizeable < 0 || (resizeable > 0 && pkg.applicationInfo.targetSdkVersion >= 
				android.os.Build.VERSION_CODES.DONUT))
			{
				pkg.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_RESIZEABLE_FOR_SCREENS;
			}
			if (anyDensity < 0 || (anyDensity > 0 && pkg.applicationInfo.targetSdkVersion >= 
				android.os.Build.VERSION_CODES.DONUT))
			{
				pkg.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_SUPPORTS_SCREEN_DENSITIES;
			}
			return pkg;
		}

		private static string buildClassName(string pkg, java.lang.CharSequence clsSeq, string
			[] outError)
		{
			if (clsSeq == null || clsSeq.Length <= 0)
			{
				outError[0] = "Empty class name in package " + pkg;
				return null;
			}
			string cls = clsSeq.ToString();
			char c = cls[0];
			if (c == '.')
			{
				return string.Intern((pkg + cls));
			}
			if (cls.IndexOf('.') < 0)
			{
				java.lang.StringBuilder b = new java.lang.StringBuilder(pkg);
				b.append('.');
				b.append(cls);
				return string.Intern(b.ToString());
			}
			if (c >= 'a' && c <= 'z')
			{
				return string.Intern(cls);
			}
			outError[0] = "Bad class name " + cls + " in package " + pkg;
			return null;
		}

		private static string buildCompoundName(string pkg, java.lang.CharSequence procSeq
			, string type, string[] outError)
		{
			string proc = procSeq.ToString();
			char c = proc[0];
			if (pkg != null && c == ':')
			{
				if (proc.Length < 2)
				{
					outError[0] = "Bad " + type + " name " + proc + " in package " + pkg + ": must be at least two characters";
					return null;
				}
				string subName = Sharpen.StringHelper.Substring(proc, 1);
				string nameError = validateName(subName, false);
				if (nameError != null)
				{
					outError[0] = "Invalid " + type + " name " + proc + " in package " + pkg + ": " +
						 nameError;
					return null;
				}
				return string.Intern((pkg + proc));
			}
			string nameError_1 = validateName(proc, true);
			if (nameError_1 != null && !"system".Equals(proc))
			{
				outError[0] = "Invalid " + type + " name " + proc + " in package " + pkg + ": " +
					 nameError_1;
				return null;
			}
			return string.Intern(proc);
		}

		private static string buildProcessName(string pkg, string defProc, java.lang.CharSequence
			 procSeq, int flags, string[] separateProcesses, string[] outError)
		{
			if ((flags & PARSE_IGNORE_PROCESSES) != 0 && !"system".Equals(procSeq))
			{
				return defProc != null ? defProc : pkg;
			}
			if (separateProcesses != null)
			{
				{
					for (int i = separateProcesses.Length - 1; i >= 0; i--)
					{
						string sp = separateProcesses[i];
						if (sp.Equals(pkg) || sp.Equals(defProc) || sp.Equals(procSeq))
						{
							return pkg;
						}
					}
				}
			}
			if (procSeq == null || procSeq.Length <= 0)
			{
				return defProc;
			}
			return buildCompoundName(pkg, procSeq, "process", outError);
		}

		private static string buildTaskAffinityName(string pkg, string defProc, java.lang.CharSequence
			 procSeq, string[] outError)
		{
			if (procSeq == null)
			{
				return defProc;
			}
			if (procSeq.Length <= 0)
			{
				return null;
			}
			return buildCompoundName(pkg, procSeq, "taskAffinity", outError);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.PermissionGroup parsePermissionGroup(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, string[] outError)
		{
			android.content.pm.PackageParser.PermissionGroup perm = new android.content.pm.PackageParser
				.PermissionGroup(owner);
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestPermissionGroup);
			if (!parsePackageItemInfo(owner, perm.info, outError, "<permission-group>", sa, android.@internal.R
				.styleable.AndroidManifestPermissionGroup_name, android.@internal.R.styleable.AndroidManifestPermissionGroup_label
				, android.@internal.R.styleable.AndroidManifestPermissionGroup_icon, android.@internal.R
				.styleable.AndroidManifestPermissionGroup_logo))
			{
				sa.recycle();
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			perm.info.descriptionRes = sa.getResourceId(android.@internal.R.styleable.AndroidManifestPermissionGroup_description
				, 0);
			sa.recycle();
			if (!parseAllMetaData(res, parser, attrs, "<permission-group>", perm, outError))
			{
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			owner.permissionGroups.add(perm);
			return perm;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Permission parsePermission(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, string[] outError)
		{
			android.content.pm.PackageParser.Permission perm = new android.content.pm.PackageParser
				.Permission(owner);
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestPermission);
			if (!parsePackageItemInfo(owner, perm.info, outError, "<permission>", sa, android.@internal.R
				.styleable.AndroidManifestPermission_name, android.@internal.R.styleable.AndroidManifestPermission_label
				, android.@internal.R.styleable.AndroidManifestPermission_icon, android.@internal.R
				.styleable.AndroidManifestPermission_logo))
			{
				sa.recycle();
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			// Note: don't allow this value to be a reference to a resource
			// that may change.
			perm.info.group = sa.getNonResourceString(android.@internal.R.styleable.AndroidManifestPermission_permissionGroup
				);
			if (perm.info.group != null)
			{
				perm.info.group = string.Intern(perm.info.group);
			}
			perm.info.descriptionRes = sa.getResourceId(android.@internal.R.styleable.AndroidManifestPermission_description
				, 0);
			perm.info.protectionLevel = sa.getInt(android.@internal.R.styleable.AndroidManifestPermission_protectionLevel
				, android.content.pm.PermissionInfo.PROTECTION_NORMAL);
			sa.recycle();
			if (perm.info.protectionLevel == -1)
			{
				outError[0] = "<permission> does not specify protectionLevel";
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			if (!parseAllMetaData(res, parser, attrs, "<permission>", perm, outError))
			{
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			owner.permissions.add(perm);
			return perm;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Permission parsePermissionTree(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, string[] outError)
		{
			android.content.pm.PackageParser.Permission perm = new android.content.pm.PackageParser
				.Permission(owner);
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestPermissionTree);
			if (!parsePackageItemInfo(owner, perm.info, outError, "<permission-tree>", sa, android.@internal.R
				.styleable.AndroidManifestPermissionTree_name, android.@internal.R.styleable.AndroidManifestPermissionTree_label
				, android.@internal.R.styleable.AndroidManifestPermissionTree_icon, android.@internal.R
				.styleable.AndroidManifestPermissionTree_logo))
			{
				sa.recycle();
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			sa.recycle();
			int index = perm.info.name.IndexOf('.');
			if (index > 0)
			{
				index = perm.info.name.IndexOf('.', index + 1);
			}
			if (index < 0)
			{
				outError[0] = "<permission-tree> name has less than three segments: " + perm.info
					.name;
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			perm.info.descriptionRes = 0;
			perm.info.protectionLevel = android.content.pm.PermissionInfo.PROTECTION_NORMAL;
			perm.tree = true;
			if (!parseAllMetaData(res, parser, attrs, "<permission-tree>", perm, outError))
			{
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			owner.permissions.add(perm);
			return perm;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Instrumentation parseInstrumentation(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, string[] outError)
		{
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestInstrumentation);
			if (mParseInstrumentationArgs == null)
			{
				mParseInstrumentationArgs = new android.content.pm.PackageParser.ParsePackageItemArgs
					(owner, outError, android.@internal.R.styleable.AndroidManifestInstrumentation_name
					, android.@internal.R.styleable.AndroidManifestInstrumentation_label, android.@internal.R
					.styleable.AndroidManifestInstrumentation_icon, android.@internal.R.styleable.AndroidManifestInstrumentation_logo
					);
				mParseInstrumentationArgs.tag = "<instrumentation>";
			}
			mParseInstrumentationArgs.sa = sa;
			android.content.pm.PackageParser.Instrumentation a = new android.content.pm.PackageParser
				.Instrumentation(mParseInstrumentationArgs, new android.content.pm.InstrumentationInfo
				());
			if (outError[0] != null)
			{
				sa.recycle();
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			string str;
			// Note: don't allow this value to be a reference to a resource
			// that may change.
			str = sa.getNonResourceString(android.@internal.R.styleable.AndroidManifestInstrumentation_targetPackage
				);
			a.info.targetPackage = str != null ? string.Intern(str) : null;
			a.info.handleProfiling = sa.getBoolean(android.@internal.R.styleable.AndroidManifestInstrumentation_handleProfiling
				, false);
			a.info.functionalTest = sa.getBoolean(android.@internal.R.styleable.AndroidManifestInstrumentation_functionalTest
				, false);
			sa.recycle();
			if (a.info.targetPackage == null)
			{
				outError[0] = "<instrumentation> does not specify targetPackage";
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			if (!parseAllMetaData(res, parser, attrs, "<instrumentation>", a, outError))
			{
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return null;
			}
			owner.instrumentation.add(a);
			return a;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private bool parseApplication(android.content.pm.PackageParser.Package owner, android.content.res.Resources
			 res, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs, int 
			flags, string[] outError)
		{
			android.content.pm.ApplicationInfo ai = owner.applicationInfo;
			string pkgName = owner.applicationInfo.packageName;
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestApplication);
			string name = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestApplication_name
				, 0);
			if (name != null)
			{
				ai.className = buildClassName(pkgName, java.lang.CharSequenceProxy.Wrap(name), outError
					);
				if (ai.className == null)
				{
					sa.recycle();
					mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
					return false;
				}
			}
			string manageSpaceActivity = sa.getNonConfigurationString(android.@internal.R.styleable
				.AndroidManifestApplication_manageSpaceActivity, 0);
			if (manageSpaceActivity != null)
			{
				ai.manageSpaceActivityName = buildClassName(pkgName, java.lang.CharSequenceProxy.Wrap
					(manageSpaceActivity), outError);
			}
			bool allowBackup = sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_allowBackup
				, true);
			if (allowBackup)
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_ALLOW_BACKUP;
				// backupAgent, killAfterRestore, and restoreAnyVersion are only relevant
				// if backup is possible for the given application.
				string backupAgent = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestApplication_backupAgent
					, 0);
				if (backupAgent != null)
				{
					ai.backupAgentName = buildClassName(pkgName, java.lang.CharSequenceProxy.Wrap(backupAgent
						), outError);
					if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_killAfterRestore
						, true))
					{
						ai.flags |= android.content.pm.ApplicationInfo.FLAG_KILL_AFTER_RESTORE;
					}
					if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_restoreAnyVersion
						, false))
					{
						ai.flags |= android.content.pm.ApplicationInfo.FLAG_RESTORE_ANY_VERSION;
					}
				}
			}
			android.util.TypedValue v = sa.peekValue(android.@internal.R.styleable.AndroidManifestApplication_label
				);
			if (v != null && (ai.labelRes = v.resourceId) == 0)
			{
				ai.nonLocalizedLabel = v.coerceToString();
			}
			ai.icon = sa.getResourceId(android.@internal.R.styleable.AndroidManifestApplication_icon
				, 0);
			ai.logo = sa.getResourceId(android.@internal.R.styleable.AndroidManifestApplication_logo
				, 0);
			ai.theme = sa.getResourceId(android.@internal.R.styleable.AndroidManifestApplication_theme
				, 0);
			ai.descriptionRes = sa.getResourceId(android.@internal.R.styleable.AndroidManifestApplication_description
				, 0);
			if ((flags & PARSE_IS_SYSTEM) != 0)
			{
				if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_persistent
					, false))
				{
					ai.flags |= android.content.pm.ApplicationInfo.FLAG_PERSISTENT;
				}
			}
			if ((flags & PARSE_FORWARD_LOCK) != 0)
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_FORWARD_LOCK;
			}
			if ((flags & PARSE_ON_SDCARD) != 0)
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_EXTERNAL_STORAGE;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_debuggable
				, false))
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_DEBUGGABLE;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_vmSafeMode
				, false))
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_VM_SAFE_MODE;
			}
			bool hardwareAccelerated = sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_hardwareAccelerated
				, owner.applicationInfo.targetSdkVersion >= android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH
				);
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_hasCode
				, true))
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_HAS_CODE;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_allowTaskReparenting
				, false))
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_ALLOW_TASK_REPARENTING;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_allowClearUserData
				, true))
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_ALLOW_CLEAR_USER_DATA;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_testOnly
				, false))
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_TEST_ONLY;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_largeHeap
				, false))
			{
				ai.flags |= android.content.pm.ApplicationInfo.FLAG_LARGE_HEAP;
			}
			string str;
			str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestApplication_permission
				, 0);
			ai.permission = (str != null && str.Length > 0) ? string.Intern(str) : null;
			if (owner.applicationInfo.targetSdkVersion >= android.os.Build.VERSION_CODES.FROYO)
			{
				str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestApplication_taskAffinity
					, 0);
			}
			else
			{
				// Some older apps have been seen to use a resource reference
				// here that on older builds was ignored (with a warning).  We
				// need to continue to do this for them so they don't break.
				str = sa.getNonResourceString(android.@internal.R.styleable.AndroidManifestApplication_taskAffinity
					);
			}
			ai.taskAffinity = buildTaskAffinityName(ai.packageName, ai.packageName, java.lang.CharSequenceProxy.Wrap
				(str), outError);
			if (outError[0] == null)
			{
				java.lang.CharSequence pname;
				if (owner.applicationInfo.targetSdkVersion >= android.os.Build.VERSION_CODES.FROYO)
				{
					pname = java.lang.CharSequenceProxy.Wrap(sa.getNonConfigurationString(android.@internal.R
						.styleable.AndroidManifestApplication_process, 0));
				}
				else
				{
					// Some older apps have been seen to use a resource reference
					// here that on older builds was ignored (with a warning).  We
					// need to continue to do this for them so they don't break.
					pname = java.lang.CharSequenceProxy.Wrap(sa.getNonResourceString(android.@internal.R
						.styleable.AndroidManifestApplication_process));
				}
				ai.processName = buildProcessName(ai.packageName, null, pname, flags, mSeparateProcesses
					, outError);
				ai.enabled = sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_enabled
					, true);
				if (false)
				{
					if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestApplication_cantSaveState
						, false))
					{
						ai.flags |= android.content.pm.ApplicationInfo.FLAG_CANT_SAVE_STATE;
						// A heavy-weight application can not be in a custom process.
						// We can do direct compare because we intern all strings.
						if (ai.processName != null && ai.processName != ai.packageName)
						{
							outError[0] = "cantSaveState applications can not use custom processes";
						}
					}
				}
			}
			ai.uiOptions = sa.getInt(android.@internal.R.styleable.AndroidManifestApplication_uiOptions
				, 0);
			sa.recycle();
			if (outError[0] != null)
			{
				mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
				return false;
			}
			int innerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > innerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				string tagName = parser.getName();
				if (tagName.Equals("activity"))
				{
					android.content.pm.PackageParser.Activity a = parseActivity(owner, res, parser, attrs
						, flags, outError, false, hardwareAccelerated);
					if (a == null)
					{
						mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
						return false;
					}
					owner.activities.add(a);
				}
				else
				{
					if (tagName.Equals("receiver"))
					{
						android.content.pm.PackageParser.Activity a = parseActivity(owner, res, parser, attrs
							, flags, outError, true, false);
						if (a == null)
						{
							mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
							return false;
						}
						owner.receivers.add(a);
					}
					else
					{
						if (tagName.Equals("service"))
						{
							android.content.pm.PackageParser.Service s = parseService(owner, res, parser, attrs
								, flags, outError);
							if (s == null)
							{
								mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
								return false;
							}
							owner.services.add(s);
						}
						else
						{
							if (tagName.Equals("provider"))
							{
								android.content.pm.PackageParser.Provider p = parseProvider(owner, res, parser, attrs
									, flags, outError);
								if (p == null)
								{
									mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
									return false;
								}
								owner.providers.add(p);
							}
							else
							{
								if (tagName.Equals("activity-alias"))
								{
									android.content.pm.PackageParser.Activity a = parseActivityAlias(owner, res, parser
										, attrs, flags, outError);
									if (a == null)
									{
										mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
										return false;
									}
									owner.activities.add(a);
								}
								else
								{
									if (parser.getName().Equals("meta-data"))
									{
										// note: application meta-data is stored off to the side, so it can
										// remain null in the primary copy (we like to avoid extra copies because
										// it can be large)
										if ((owner.mAppMetaData = parseMetaData(res, parser, attrs, owner.mAppMetaData, outError
											)) == null)
										{
											mParseError = android.content.pm.PackageManager.INSTALL_PARSE_FAILED_MANIFEST_MALFORMED;
											return false;
										}
									}
									else
									{
										if (tagName.Equals("uses-library"))
										{
											sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestUsesLibrary
												);
											// Note: don't allow this value to be a reference to a resource
											// that may change.
											string lname = sa.getNonResourceString(android.@internal.R.styleable.AndroidManifestUsesLibrary_name
												);
											bool req = sa.getBoolean(android.@internal.R.styleable.AndroidManifestUsesLibrary_required
												, true);
											sa.recycle();
											if (lname != null)
											{
												if (req)
												{
													if (owner.usesLibraries == null)
													{
														owner.usesLibraries = new java.util.ArrayList<string>();
													}
													if (!owner.usesLibraries.contains(lname))
													{
														owner.usesLibraries.add(string.Intern(lname));
													}
												}
												else
												{
													if (owner.usesOptionalLibraries == null)
													{
														owner.usesOptionalLibraries = new java.util.ArrayList<string>();
													}
													if (!owner.usesOptionalLibraries.contains(lname))
													{
														owner.usesOptionalLibraries.add(string.Intern(lname));
													}
												}
											}
											android.util.@internal.XmlUtils.skipCurrentTag(parser);
										}
										else
										{
											if (tagName.Equals("uses-package"))
											{
												// Dependencies for app installers; we don't currently try to
												// enforce this.
												android.util.@internal.XmlUtils.skipCurrentTag(parser);
											}
											else
											{
												android.util.Slog.w(TAG, "Unknown element under <application>: " + tagName + " at "
													 + mArchiveSourcePath + " " + parser.getPositionDescription());
												android.util.@internal.XmlUtils.skipCurrentTag(parser);
												continue;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}

		private bool parsePackageItemInfo(android.content.pm.PackageParser.Package owner, 
			android.content.pm.PackageItemInfo outInfo, string[] outError, string tag, android.content.res.TypedArray
			 sa, int nameRes, int labelRes, int iconRes, int logoRes)
		{
			string name = sa.getNonConfigurationString(nameRes, 0);
			if (name == null)
			{
				outError[0] = tag + " does not specify android:name";
				return false;
			}
			outInfo.name = buildClassName(owner.applicationInfo.packageName, java.lang.CharSequenceProxy.Wrap
				(name), outError);
			if (outInfo.name == null)
			{
				return false;
			}
			int iconVal = sa.getResourceId(iconRes, 0);
			if (iconVal != 0)
			{
				outInfo.icon = iconVal;
				outInfo.nonLocalizedLabel = null;
			}
			int logoVal = sa.getResourceId(logoRes, 0);
			if (logoVal != 0)
			{
				outInfo.logo = logoVal;
			}
			android.util.TypedValue v = sa.peekValue(labelRes);
			if (v != null && (outInfo.labelRes = v.resourceId) == 0)
			{
				outInfo.nonLocalizedLabel = v.coerceToString();
			}
			outInfo.packageName = owner.packageName;
			return true;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Activity parseActivity(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, int flags, string[] outError, bool receiver
			, bool hardwareAccelerated)
		{
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestActivity);
			if (mParseActivityArgs == null)
			{
				mParseActivityArgs = new android.content.pm.PackageParser.ParseComponentArgs(owner
					, outError, android.@internal.R.styleable.AndroidManifestActivity_name, android.@internal.R
					.styleable.AndroidManifestActivity_label, android.@internal.R.styleable.AndroidManifestActivity_icon
					, android.@internal.R.styleable.AndroidManifestActivity_logo, mSeparateProcesses
					, android.@internal.R.styleable.AndroidManifestActivity_process, android.@internal.R
					.styleable.AndroidManifestActivity_description, android.@internal.R.styleable.AndroidManifestActivity_enabled
					);
			}
			mParseActivityArgs.tag = receiver ? "<receiver>" : "<activity>";
			mParseActivityArgs.sa = sa;
			mParseActivityArgs.flags = flags;
			android.content.pm.PackageParser.Activity a = new android.content.pm.PackageParser
				.Activity(mParseActivityArgs, new android.content.pm.ActivityInfo());
			if (outError[0] != null)
			{
				sa.recycle();
				return null;
			}
			bool setExported = sa.hasValue(android.@internal.R.styleable.AndroidManifestActivity_exported
				);
			if (setExported)
			{
				a.info.exported = sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_exported
					, false);
			}
			a.info.theme = sa.getResourceId(android.@internal.R.styleable.AndroidManifestActivity_theme
				, 0);
			a.info.uiOptions = sa.getInt(android.@internal.R.styleable.AndroidManifestActivity_uiOptions
				, a.info.applicationInfo.uiOptions);
			string str;
			str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestActivity_permission
				, 0);
			if (str == null)
			{
				a.info.permission = owner.applicationInfo.permission;
			}
			else
			{
				a.info.permission = str.Length > 0 ? string.Intern(str.ToString()) : null;
			}
			str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestActivity_taskAffinity
				, 0);
			a.info.taskAffinity = buildTaskAffinityName(owner.applicationInfo.packageName, owner
				.applicationInfo.taskAffinity, java.lang.CharSequenceProxy.Wrap(str), outError);
			a.info.flags = 0;
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_multiprocess
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_MULTIPROCESS;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_finishOnTaskLaunch
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_FINISH_ON_TASK_LAUNCH;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_clearTaskOnLaunch
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_CLEAR_TASK_ON_LAUNCH;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_noHistory
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_NO_HISTORY;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_alwaysRetainTaskState
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_ALWAYS_RETAIN_TASK_STATE;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_stateNotNeeded
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_STATE_NOT_NEEDED;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_excludeFromRecents
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_EXCLUDE_FROM_RECENTS;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_allowTaskReparenting
				, (owner.applicationInfo.flags & android.content.pm.ApplicationInfo.FLAG_ALLOW_TASK_REPARENTING
				) != 0))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_ALLOW_TASK_REPARENTING;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_finishOnCloseSystemDialogs
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_FINISH_ON_CLOSE_SYSTEM_DIALOGS;
			}
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_immersive
				, false))
			{
				a.info.flags |= android.content.pm.ActivityInfo.FLAG_IMMERSIVE;
			}
			if (!receiver)
			{
				if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivity_hardwareAccelerated
					, hardwareAccelerated))
				{
					a.info.flags |= android.content.pm.ActivityInfo.FLAG_HARDWARE_ACCELERATED;
				}
				a.info.launchMode = sa.getInt(android.@internal.R.styleable.AndroidManifestActivity_launchMode
					, android.content.pm.ActivityInfo.LAUNCH_MULTIPLE);
				a.info.screenOrientation = sa.getInt(android.@internal.R.styleable.AndroidManifestActivity_screenOrientation
					, android.content.pm.ActivityInfo.SCREEN_ORIENTATION_UNSPECIFIED);
				a.info.configChanges = sa.getInt(android.@internal.R.styleable.AndroidManifestActivity_configChanges
					, 0);
				a.info.softInputMode = sa.getInt(android.@internal.R.styleable.AndroidManifestActivity_windowSoftInputMode
					, 0);
			}
			else
			{
				a.info.launchMode = android.content.pm.ActivityInfo.LAUNCH_MULTIPLE;
				a.info.configChanges = 0;
			}
			sa.recycle();
			if (receiver && (owner.applicationInfo.flags & android.content.pm.ApplicationInfo
				.FLAG_CANT_SAVE_STATE) != 0)
			{
				// A heavy-weight application can not have receives in its main process
				// We can do direct compare because we intern all strings.
				if (a.info.processName == owner.packageName)
				{
					outError[0] = "Heavy-weight applications can not have receivers in main process";
				}
			}
			if (outError[0] != null)
			{
				return null;
			}
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				if (parser.getName().Equals("intent-filter"))
				{
					android.content.pm.PackageParser.ActivityIntentInfo intent = new android.content.pm.PackageParser
						.ActivityIntentInfo(a);
					if (!parseIntent(res, parser, attrs, flags, intent, outError, !receiver))
					{
						return null;
					}
					if (intent.countActions() == 0)
					{
						android.util.Slog.w(TAG, "No actions in intent filter at " + mArchiveSourcePath +
							 " " + parser.getPositionDescription());
					}
					else
					{
						a.intents.add(intent);
					}
				}
				else
				{
					if (parser.getName().Equals("meta-data"))
					{
						if ((a.metaData = parseMetaData(res, parser, attrs, a.metaData, outError)) == null)
						{
							return null;
						}
					}
					else
					{
						android.util.Slog.w(TAG, "Problem in package " + mArchiveSourcePath + ":");
						if (receiver)
						{
							android.util.Slog.w(TAG, "Unknown element under <receiver>: " + parser.getName() 
								+ " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
						}
						else
						{
							android.util.Slog.w(TAG, "Unknown element under <activity>: " + parser.getName() 
								+ " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
						}
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
						continue;
					}
				}
			}
			if (!setExported)
			{
				a.info.exported = a.intents.size() > 0;
			}
			return a;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Activity parseActivityAlias(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, int flags, string[] outError)
		{
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestActivityAlias);
			string targetActivity = sa.getNonConfigurationString(android.@internal.R.styleable
				.AndroidManifestActivityAlias_targetActivity, 0);
			if (targetActivity == null)
			{
				outError[0] = "<activity-alias> does not specify android:targetActivity";
				sa.recycle();
				return null;
			}
			targetActivity = buildClassName(owner.applicationInfo.packageName, java.lang.CharSequenceProxy.Wrap
				(targetActivity), outError);
			if (targetActivity == null)
			{
				sa.recycle();
				return null;
			}
			if (mParseActivityAliasArgs == null)
			{
				mParseActivityAliasArgs = new android.content.pm.PackageParser.ParseComponentArgs
					(owner, outError, android.@internal.R.styleable.AndroidManifestActivityAlias_name
					, android.@internal.R.styleable.AndroidManifestActivityAlias_label, android.@internal.R
					.styleable.AndroidManifestActivityAlias_icon, android.@internal.R.styleable.AndroidManifestActivityAlias_logo
					, mSeparateProcesses, 0, android.@internal.R.styleable.AndroidManifestActivityAlias_description
					, android.@internal.R.styleable.AndroidManifestActivityAlias_enabled);
				mParseActivityAliasArgs.tag = "<activity-alias>";
			}
			mParseActivityAliasArgs.sa = sa;
			mParseActivityAliasArgs.flags = flags;
			android.content.pm.PackageParser.Activity target = null;
			int NA = owner.activities.size();
			{
				for (int i = 0; i < NA; i++)
				{
					android.content.pm.PackageParser.Activity t = owner.activities.get(i);
					if (targetActivity.Equals(t.info.name))
					{
						target = t;
						break;
					}
				}
			}
			if (target == null)
			{
				outError[0] = "<activity-alias> target activity " + targetActivity + " not found in manifest";
				sa.recycle();
				return null;
			}
			android.content.pm.ActivityInfo info = new android.content.pm.ActivityInfo();
			info.targetActivity = targetActivity;
			info.configChanges = target.info.configChanges;
			info.flags = target.info.flags;
			info.icon = target.info.icon;
			info.logo = target.info.logo;
			info.labelRes = target.info.labelRes;
			info.nonLocalizedLabel = target.info.nonLocalizedLabel;
			info.launchMode = target.info.launchMode;
			info.processName = target.info.processName;
			if (info.descriptionRes == 0)
			{
				info.descriptionRes = target.info.descriptionRes;
			}
			info.screenOrientation = target.info.screenOrientation;
			info.taskAffinity = target.info.taskAffinity;
			info.theme = target.info.theme;
			info.softInputMode = target.info.softInputMode;
			info.uiOptions = target.info.uiOptions;
			android.content.pm.PackageParser.Activity a = new android.content.pm.PackageParser
				.Activity(mParseActivityAliasArgs, info);
			if (outError[0] != null)
			{
				sa.recycle();
				return null;
			}
			bool setExported = sa.hasValue(android.@internal.R.styleable.AndroidManifestActivityAlias_exported
				);
			if (setExported)
			{
				a.info.exported = sa.getBoolean(android.@internal.R.styleable.AndroidManifestActivityAlias_exported
					, false);
			}
			string str;
			str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestActivityAlias_permission
				, 0);
			if (str != null)
			{
				a.info.permission = str.Length > 0 ? string.Intern(str.ToString()) : null;
			}
			sa.recycle();
			if (outError[0] != null)
			{
				return null;
			}
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				if (parser.getName().Equals("intent-filter"))
				{
					android.content.pm.PackageParser.ActivityIntentInfo intent = new android.content.pm.PackageParser
						.ActivityIntentInfo(a);
					if (!parseIntent(res, parser, attrs, flags, intent, outError, true))
					{
						return null;
					}
					if (intent.countActions() == 0)
					{
						android.util.Slog.w(TAG, "No actions in intent filter at " + mArchiveSourcePath +
							 " " + parser.getPositionDescription());
					}
					else
					{
						a.intents.add(intent);
					}
				}
				else
				{
					if (parser.getName().Equals("meta-data"))
					{
						if ((a.metaData = parseMetaData(res, parser, attrs, a.metaData, outError)) == null)
						{
							return null;
						}
					}
					else
					{
						android.util.Slog.w(TAG, "Unknown element under <activity-alias>: " + parser.getName
							() + " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
						continue;
					}
				}
			}
			if (!setExported)
			{
				a.info.exported = a.intents.size() > 0;
			}
			return a;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Provider parseProvider(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, int flags, string[] outError)
		{
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestProvider);
			if (mParseProviderArgs == null)
			{
				mParseProviderArgs = new android.content.pm.PackageParser.ParseComponentArgs(owner
					, outError, android.@internal.R.styleable.AndroidManifestProvider_name, android.@internal.R
					.styleable.AndroidManifestProvider_label, android.@internal.R.styleable.AndroidManifestProvider_icon
					, android.@internal.R.styleable.AndroidManifestProvider_logo, mSeparateProcesses
					, android.@internal.R.styleable.AndroidManifestProvider_process, android.@internal.R
					.styleable.AndroidManifestProvider_description, android.@internal.R.styleable.AndroidManifestProvider_enabled
					);
				mParseProviderArgs.tag = "<provider>";
			}
			mParseProviderArgs.sa = sa;
			mParseProviderArgs.flags = flags;
			android.content.pm.PackageParser.Provider p = new android.content.pm.PackageParser
				.Provider(mParseProviderArgs, new android.content.pm.ProviderInfo());
			if (outError[0] != null)
			{
				sa.recycle();
				return null;
			}
			p.info.exported = sa.getBoolean(android.@internal.R.styleable.AndroidManifestProvider_exported
				, true);
			string cpname = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestProvider_authorities
				, 0);
			p.info.isSyncable = sa.getBoolean(android.@internal.R.styleable.AndroidManifestProvider_syncable
				, false);
			string permission = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestProvider_permission
				, 0);
			string str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestProvider_readPermission
				, 0);
			if (str == null)
			{
				str = permission;
			}
			if (str == null)
			{
				p.info.readPermission = owner.applicationInfo.permission;
			}
			else
			{
				p.info.readPermission = str.Length > 0 ? string.Intern(str.ToString()) : null;
			}
			str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestProvider_writePermission
				, 0);
			if (str == null)
			{
				str = permission;
			}
			if (str == null)
			{
				p.info.writePermission = owner.applicationInfo.permission;
			}
			else
			{
				p.info.writePermission = str.Length > 0 ? string.Intern(str.ToString()) : null;
			}
			p.info.grantUriPermissions = sa.getBoolean(android.@internal.R.styleable.AndroidManifestProvider_grantUriPermissions
				, false);
			p.info.multiprocess = sa.getBoolean(android.@internal.R.styleable.AndroidManifestProvider_multiprocess
				, false);
			p.info.initOrder = sa.getInt(android.@internal.R.styleable.AndroidManifestProvider_initOrder
				, 0);
			sa.recycle();
			if ((owner.applicationInfo.flags & android.content.pm.ApplicationInfo.FLAG_CANT_SAVE_STATE
				) != 0)
			{
				// A heavy-weight application can not have providers in its main process
				// We can do direct compare because we intern all strings.
				if (p.info.processName == owner.packageName)
				{
					outError[0] = "Heavy-weight applications can not have providers in main process";
					return null;
				}
			}
			if (cpname == null)
			{
				outError[0] = "<provider> does not incude authorities attribute";
				return null;
			}
			p.info.authority = string.Intern(cpname);
			if (!parseProviderTags(res, parser, attrs, p, outError))
			{
				return null;
			}
			return p;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private bool parseProviderTags(android.content.res.Resources res, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs, android.content.pm.PackageParser.Provider
			 outInfo, string[] outError)
		{
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				if (parser.getName().Equals("meta-data"))
				{
					if ((outInfo.metaData = parseMetaData(res, parser, attrs, outInfo.metaData, outError
						)) == null)
					{
						return false;
					}
				}
				else
				{
					if (parser.getName().Equals("grant-uri-permission"))
					{
						android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
							.styleable.AndroidManifestGrantUriPermission);
						android.os.PatternMatcher pa = null;
						string str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestGrantUriPermission_path
							, 0);
						if (str != null)
						{
							pa = new android.os.PatternMatcher(str, android.os.PatternMatcher.PATTERN_LITERAL
								);
						}
						str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestGrantUriPermission_pathPrefix
							, 0);
						if (str != null)
						{
							pa = new android.os.PatternMatcher(str, android.os.PatternMatcher.PATTERN_PREFIX);
						}
						str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestGrantUriPermission_pathPattern
							, 0);
						if (str != null)
						{
							pa = new android.os.PatternMatcher(str, android.os.PatternMatcher.PATTERN_SIMPLE_GLOB
								);
						}
						sa.recycle();
						if (pa != null)
						{
							if (outInfo.info.uriPermissionPatterns == null)
							{
								outInfo.info.uriPermissionPatterns = new android.os.PatternMatcher[1];
								outInfo.info.uriPermissionPatterns[0] = pa;
							}
							else
							{
								int N = outInfo.info.uriPermissionPatterns.Length;
								android.os.PatternMatcher[] newp = new android.os.PatternMatcher[N + 1];
								System.Array.Copy(outInfo.info.uriPermissionPatterns, 0, newp, 0, N);
								newp[N] = pa;
								outInfo.info.uriPermissionPatterns = newp;
							}
							outInfo.info.grantUriPermissions = true;
						}
						else
						{
							android.util.Slog.w(TAG, "Unknown element under <path-permission>: " + parser.getName
								() + " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
							android.util.@internal.XmlUtils.skipCurrentTag(parser);
							continue;
						}
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
					}
					else
					{
						if (parser.getName().Equals("path-permission"))
						{
							android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
								.styleable.AndroidManifestPathPermission);
							android.content.pm.PathPermission pa = null;
							string permission = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestPathPermission_permission
								, 0);
							string readPermission = sa.getNonConfigurationString(android.@internal.R.styleable
								.AndroidManifestPathPermission_readPermission, 0);
							if (readPermission == null)
							{
								readPermission = permission;
							}
							string writePermission = sa.getNonConfigurationString(android.@internal.R.styleable
								.AndroidManifestPathPermission_writePermission, 0);
							if (writePermission == null)
							{
								writePermission = permission;
							}
							bool havePerm = false;
							if (readPermission != null)
							{
								readPermission = string.Intern(readPermission);
								havePerm = true;
							}
							if (writePermission != null)
							{
								writePermission = string.Intern(writePermission);
								havePerm = true;
							}
							if (!havePerm)
							{
								android.util.Slog.w(TAG, "No readPermission or writePermssion for <path-permission>: "
									 + parser.getName() + " at " + mArchiveSourcePath + " " + parser.getPositionDescription
									());
								android.util.@internal.XmlUtils.skipCurrentTag(parser);
								continue;
							}
							string path = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestPathPermission_path
								, 0);
							if (path != null)
							{
								pa = new android.content.pm.PathPermission(path, android.os.PatternMatcher.PATTERN_LITERAL
									, readPermission, writePermission);
							}
							path = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestPathPermission_pathPrefix
								, 0);
							if (path != null)
							{
								pa = new android.content.pm.PathPermission(path, android.os.PatternMatcher.PATTERN_PREFIX
									, readPermission, writePermission);
							}
							path = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestPathPermission_pathPattern
								, 0);
							if (path != null)
							{
								pa = new android.content.pm.PathPermission(path, android.os.PatternMatcher.PATTERN_SIMPLE_GLOB
									, readPermission, writePermission);
							}
							sa.recycle();
							if (pa != null)
							{
								if (outInfo.info.pathPermissions == null)
								{
									outInfo.info.pathPermissions = new android.content.pm.PathPermission[1];
									outInfo.info.pathPermissions[0] = pa;
								}
								else
								{
									int N = outInfo.info.pathPermissions.Length;
									android.content.pm.PathPermission[] newp = new android.content.pm.PathPermission[
										N + 1];
									System.Array.Copy(outInfo.info.pathPermissions, 0, newp, 0, N);
									newp[N] = pa;
									outInfo.info.pathPermissions = newp;
								}
							}
							else
							{
								android.util.Slog.w(TAG, "No path, pathPrefix, or pathPattern for <path-permission>: "
									 + parser.getName() + " at " + mArchiveSourcePath + " " + parser.getPositionDescription
									());
								android.util.@internal.XmlUtils.skipCurrentTag(parser);
								continue;
								outError[0] = "No path, pathPrefix, or pathPattern for <path-permission>";
								return false;
							}
							android.util.@internal.XmlUtils.skipCurrentTag(parser);
						}
						else
						{
							android.util.Slog.w(TAG, "Unknown element under <provider>: " + parser.getName() 
								+ " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
							android.util.@internal.XmlUtils.skipCurrentTag(parser);
							continue;
						}
					}
				}
			}
			return true;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.content.pm.PackageParser.Service parseService(android.content.pm.PackageParser
			.Package owner, android.content.res.Resources res, org.xmlpull.v1.XmlPullParser 
			parser, android.util.AttributeSet attrs, int flags, string[] outError)
		{
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestService);
			if (mParseServiceArgs == null)
			{
				mParseServiceArgs = new android.content.pm.PackageParser.ParseComponentArgs(owner
					, outError, android.@internal.R.styleable.AndroidManifestService_name, android.@internal.R
					.styleable.AndroidManifestService_label, android.@internal.R.styleable.AndroidManifestService_icon
					, android.@internal.R.styleable.AndroidManifestService_logo, mSeparateProcesses, 
					android.@internal.R.styleable.AndroidManifestService_process, android.@internal.R
					.styleable.AndroidManifestService_description, android.@internal.R.styleable.AndroidManifestService_enabled
					);
				mParseServiceArgs.tag = "<service>";
			}
			mParseServiceArgs.sa = sa;
			mParseServiceArgs.flags = flags;
			android.content.pm.PackageParser.Service s = new android.content.pm.PackageParser
				.Service(mParseServiceArgs, new android.content.pm.ServiceInfo());
			if (outError[0] != null)
			{
				sa.recycle();
				return null;
			}
			bool setExported = sa.hasValue(android.@internal.R.styleable.AndroidManifestService_exported
				);
			if (setExported)
			{
				s.info.exported = sa.getBoolean(android.@internal.R.styleable.AndroidManifestService_exported
					, false);
			}
			string str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestService_permission
				, 0);
			if (str == null)
			{
				s.info.permission = owner.applicationInfo.permission;
			}
			else
			{
				s.info.permission = str.Length > 0 ? string.Intern(str.ToString()) : null;
			}
			s.info.flags = 0;
			if (sa.getBoolean(android.@internal.R.styleable.AndroidManifestService_stopWithTask
				, false))
			{
				s.info.flags |= android.content.pm.ServiceInfo.FLAG_STOP_WITH_TASK;
			}
			sa.recycle();
			if ((owner.applicationInfo.flags & android.content.pm.ApplicationInfo.FLAG_CANT_SAVE_STATE
				) != 0)
			{
				// A heavy-weight application can not have services in its main process
				// We can do direct compare because we intern all strings.
				if (s.info.processName == owner.packageName)
				{
					outError[0] = "Heavy-weight applications can not have services in main process";
					return null;
				}
			}
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				if (parser.getName().Equals("intent-filter"))
				{
					android.content.pm.PackageParser.ServiceIntentInfo intent = new android.content.pm.PackageParser
						.ServiceIntentInfo(s);
					if (!parseIntent(res, parser, attrs, flags, intent, outError, false))
					{
						return null;
					}
					s.intents.add(intent);
				}
				else
				{
					if (parser.getName().Equals("meta-data"))
					{
						if ((s.metaData = parseMetaData(res, parser, attrs, s.metaData, outError)) == null)
						{
							return null;
						}
					}
					else
					{
						android.util.Slog.w(TAG, "Unknown element under <service>: " + parser.getName() +
							 " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
						continue;
					}
				}
			}
			if (!setExported)
			{
				s.info.exported = s.intents.size() > 0;
			}
			return s;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private bool parseAllMetaData(android.content.res.Resources res, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs, string tag, android.content.pm.PackageParser
			.Component<android.content.pm.PackageParser.IntentInfo> outInfo, string[] outError
			)
		{
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				if (parser.getName().Equals("meta-data"))
				{
					if ((outInfo.metaData = parseMetaData(res, parser, attrs, outInfo.metaData, outError
						)) == null)
					{
						return false;
					}
				}
				else
				{
					android.util.Slog.w(TAG, "Unknown element under " + tag + ": " + parser.getName()
						 + " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
					android.util.@internal.XmlUtils.skipCurrentTag(parser);
					continue;
				}
			}
			return true;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private android.os.Bundle parseMetaData(android.content.res.Resources res, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs, android.os.Bundle data, string[] outError
			)
		{
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestMetaData);
			if (data == null)
			{
				data = new android.os.Bundle();
			}
			string name = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestMetaData_name
				, 0);
			if (name == null)
			{
				outError[0] = "<meta-data> requires an android:name attribute";
				sa.recycle();
				return null;
			}
			name = string.Intern(name);
			android.util.TypedValue v = sa.peekValue(android.@internal.R.styleable.AndroidManifestMetaData_resource
				);
			if (v != null && v.resourceId != 0)
			{
				//Slog.i(TAG, "Meta data ref " + name + ": " + v);
				data.putInt(name, v.resourceId);
			}
			else
			{
				v = sa.peekValue(android.@internal.R.styleable.AndroidManifestMetaData_value);
				//Slog.i(TAG, "Meta data " + name + ": " + v);
				if (v != null)
				{
					if (v.type == android.util.TypedValue.TYPE_STRING)
					{
						java.lang.CharSequence cs = v.coerceToString();
						data.putString(name, cs != null ? string.Intern(cs.ToString()) : null);
					}
					else
					{
						if (v.type == android.util.TypedValue.TYPE_INT_BOOLEAN)
						{
							data.putBoolean(name, v.data != 0);
						}
						else
						{
							if (v.type >= android.util.TypedValue.TYPE_FIRST_INT && v.type <= android.util.TypedValue
								.TYPE_LAST_INT)
							{
								data.putInt(name, v.data);
							}
							else
							{
								if (v.type == android.util.TypedValue.TYPE_FLOAT)
								{
									data.putFloat(name, v.getFloat());
								}
								else
								{
									android.util.Slog.w(TAG, "<meta-data> only supports string, integer, float, color, boolean, and resource reference types: "
										 + parser.getName() + " at " + mArchiveSourcePath + " " + parser.getPositionDescription
										());
								}
							}
						}
					}
				}
				else
				{
					outError[0] = "<meta-data> requires an android:value or android:resource attribute";
					data = null;
				}
			}
			sa.recycle();
			android.util.@internal.XmlUtils.skipCurrentTag(parser);
			return data;
		}

		[Sharpen.Stub]
		private static android.content.pm.VerifierInfo parseVerifier(android.content.res.Resources
			 res, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs, int 
			flags, string[] outError)
		{
			throw new System.NotImplementedException();
		}

		internal const string ANDROID_RESOURCES = "http://schemas.android.com/apk/res/android";

		// Not a RSA public key.
		// Not a DSA public key.
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private bool parseIntent(android.content.res.Resources res, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs, int flags, android.content.pm.PackageParser
			.IntentInfo outInfo, string[] outError, bool isActivity)
		{
			android.content.res.TypedArray sa = res.obtainAttributes(attrs, android.@internal.R
				.styleable.AndroidManifestIntentFilter);
			int priority = sa.getInt(android.@internal.R.styleable.AndroidManifestIntentFilter_priority
				, 0);
			outInfo.setPriority(priority);
			android.util.TypedValue v = sa.peekValue(android.@internal.R.styleable.AndroidManifestIntentFilter_label
				);
			if (v != null && (outInfo.labelRes = v.resourceId) == 0)
			{
				outInfo.nonLocalizedLabel = v.coerceToString();
			}
			outInfo.icon = sa.getResourceId(android.@internal.R.styleable.AndroidManifestIntentFilter_icon
				, 0);
			outInfo.logo = sa.getResourceId(android.@internal.R.styleable.AndroidManifestIntentFilter_logo
				, 0);
			sa.recycle();
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				string nodeName = parser.getName();
				if (nodeName.Equals("action"))
				{
					string value = attrs.getAttributeValue(ANDROID_RESOURCES, "name");
					if (value == null || value == string.Empty)
					{
						outError[0] = "No value supplied for <android:name>";
						return false;
					}
					android.util.@internal.XmlUtils.skipCurrentTag(parser);
					outInfo.addAction(value);
				}
				else
				{
					if (nodeName.Equals("category"))
					{
						string value = attrs.getAttributeValue(ANDROID_RESOURCES, "name");
						if (value == null || value == string.Empty)
						{
							outError[0] = "No value supplied for <android:name>";
							return false;
						}
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
						outInfo.addCategory(value);
					}
					else
					{
						if (nodeName.Equals("data"))
						{
							sa = res.obtainAttributes(attrs, android.@internal.R.styleable.AndroidManifestData
								);
							string str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestData_mimeType
								, 0);
							if (str != null)
							{
								try
								{
									outInfo.addDataType(str);
								}
								catch (android.content.IntentFilter.MalformedMimeTypeException e)
								{
									outError[0] = e.ToString();
									sa.recycle();
									return false;
								}
							}
							str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestData_scheme
								, 0);
							if (str != null)
							{
								outInfo.addDataScheme(str);
							}
							string host = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestData_host
								, 0);
							string port = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestData_port
								, 0);
							if (host != null)
							{
								outInfo.addDataAuthority(host, port);
							}
							str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestData_path
								, 0);
							if (str != null)
							{
								outInfo.addDataPath(str, android.os.PatternMatcher.PATTERN_LITERAL);
							}
							str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestData_pathPrefix
								, 0);
							if (str != null)
							{
								outInfo.addDataPath(str, android.os.PatternMatcher.PATTERN_PREFIX);
							}
							str = sa.getNonConfigurationString(android.@internal.R.styleable.AndroidManifestData_pathPattern
								, 0);
							if (str != null)
							{
								outInfo.addDataPath(str, android.os.PatternMatcher.PATTERN_SIMPLE_GLOB);
							}
							sa.recycle();
							android.util.@internal.XmlUtils.skipCurrentTag(parser);
						}
						else
						{
							android.util.Slog.w(TAG, "Unknown element under <intent-filter>: " + parser.getName
								() + " at " + mArchiveSourcePath + " " + parser.getPositionDescription());
							android.util.@internal.XmlUtils.skipCurrentTag(parser);
						}
					}
				}
			}
			outInfo.hasDefault = outInfo.hasCategory(android.content.Intent.CATEGORY_DEFAULT);
			return true;
		}

		public sealed class Package
		{
			public string packageName;

			public readonly android.content.pm.ApplicationInfo applicationInfo = new android.content.pm.ApplicationInfo
				();

			public readonly java.util.ArrayList<android.content.pm.PackageParser.Permission> 
				permissions = new java.util.ArrayList<android.content.pm.PackageParser.Permission
				>(0);

			public readonly java.util.ArrayList<android.content.pm.PackageParser.PermissionGroup
				> permissionGroups = new java.util.ArrayList<android.content.pm.PackageParser.PermissionGroup
				>(0);

			public readonly java.util.ArrayList<android.content.pm.PackageParser.Activity> activities
				 = new java.util.ArrayList<android.content.pm.PackageParser.Activity>(0);

			public readonly java.util.ArrayList<android.content.pm.PackageParser.Activity> receivers
				 = new java.util.ArrayList<android.content.pm.PackageParser.Activity>(0);

			public readonly java.util.ArrayList<android.content.pm.PackageParser.Provider> providers
				 = new java.util.ArrayList<android.content.pm.PackageParser.Provider>(0);

			public readonly java.util.ArrayList<android.content.pm.PackageParser.Service> services
				 = new java.util.ArrayList<android.content.pm.PackageParser.Service>(0);

			public readonly java.util.ArrayList<android.content.pm.PackageParser.Instrumentation
				> instrumentation = new java.util.ArrayList<android.content.pm.PackageParser.Instrumentation
				>(0);

			public readonly java.util.ArrayList<string> requestedPermissions = new java.util.ArrayList
				<string>();

			public java.util.ArrayList<string> protectedBroadcasts;

			public java.util.ArrayList<string> usesLibraries = null;

			public java.util.ArrayList<string> usesOptionalLibraries = null;

			public string[] usesLibraryFiles = null;

			public java.util.ArrayList<string> mOriginalPackages = null;

			public string mRealPackage = null;

			public java.util.ArrayList<string> mAdoptPermissions = null;

			public android.os.Bundle mAppMetaData = null;

			public string mPath;

			public int mVersionCode;

			public string mVersionName;

			public string mSharedUserId;

			public int mSharedUserLabel;

			public android.content.pm.Signature[] mSignatures;

			public int mPreferredOrder = 0;

			public string mScanPath;

			public bool mDidDexOpt;

			public int mSetEnabled = android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_DEFAULT;

			public bool mSetStopped = false;

			public object mExtras;

			public bool mOperationPending;

			public readonly java.util.ArrayList<android.content.pm.ConfigurationInfo> configPreferences
				 = new java.util.ArrayList<android.content.pm.ConfigurationInfo>();

			public java.util.ArrayList<android.content.pm.FeatureInfo> reqFeatures = null;

			public int installLocation;

			/// <summary>
			/// Digest suitable for comparing whether this package's manifest is the
			/// same as another.
			/// </summary>
			/// <remarks>
			/// Digest suitable for comparing whether this package's manifest is the
			/// same as another.
			/// </remarks>
			public android.content.pm.ManifestDigest manifestDigest;

			public Package(string _name)
			{
				// For now we only support one application per package.
				// We store the application meta-data independently to avoid multiple unwanted references
				// If this is a 3rd party app, this is the path of the zip file.
				// The version code declared for this package.
				// The version name declared for this package.
				// The shared user id that this package wants to use.
				// The shared user label that this package wants to use.
				// Signatures that were read from the package.
				// For use by package manager service for quick lookup of
				// preferred up order.
				// For use by the package manager to keep track of the path to the
				// file an app came from.
				// For use by package manager to keep track of where it has done dexopt.
				// User set enabled state.
				// Whether the package has been stopped.
				// Additional data supplied by callers.
				// Whether an operation is currently pending on this package
				packageName = _name;
				applicationInfo.packageName = _name;
				applicationInfo.uid = -1;
			}

			public void setPackageName(string newName)
			{
				packageName = newName;
				applicationInfo.packageName = newName;
				{
					for (int i = permissions.size() - 1; i >= 0; i--)
					{
						permissions.get(i).setPackageName(newName);
					}
				}
				{
					for (int i_1 = permissionGroups.size() - 1; i_1 >= 0; i_1--)
					{
						permissionGroups.get(i_1).setPackageName(newName);
					}
				}
				{
					for (int i_2 = activities.size() - 1; i_2 >= 0; i_2--)
					{
						activities.get(i_2).setPackageName(newName);
					}
				}
				{
					for (int i_3 = receivers.size() - 1; i_3 >= 0; i_3--)
					{
						receivers.get(i_3).setPackageName(newName);
					}
				}
				{
					for (int i_4 = providers.size() - 1; i_4 >= 0; i_4--)
					{
						providers.get(i_4).setPackageName(newName);
					}
				}
				{
					for (int i_5 = services.size() - 1; i_5 >= 0; i_5--)
					{
						services.get(i_5).setPackageName(newName);
					}
				}
				{
					for (int i_6 = instrumentation.size() - 1; i_6 >= 0; i_6--)
					{
						instrumentation.get(i_6).setPackageName(newName);
					}
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "Package{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this
					)) + " " + packageName + "}";
			}
		}

		public class Component<II> where II:android.content.pm.PackageParser.IntentInfo
		{
			public readonly android.content.pm.PackageParser.Package owner;

			public readonly java.util.ArrayList<II> intents;

			public readonly string className;

			public android.os.Bundle metaData;

			internal android.content.ComponentName componentName;

			internal string componentShortName;

			public Component(android.content.pm.PackageParser.Package _owner)
			{
				owner = _owner;
				intents = null;
				className = null;
			}

			internal Component(android.content.pm.PackageParser.ParsePackageItemArgs args, android.content.pm.PackageItemInfo
				 outInfo)
			{
				owner = args.owner;
				intents = new java.util.ArrayList<II>(0);
				string name = args.sa.getNonConfigurationString(args.nameRes, 0);
				if (name == null)
				{
					className = null;
					args.outError[0] = args.tag + " does not specify android:name";
					return;
				}
				outInfo.name = buildClassName(owner.applicationInfo.packageName, java.lang.CharSequenceProxy.Wrap
					(name), args.outError);
				if (outInfo.name == null)
				{
					className = null;
					args.outError[0] = args.tag + " does not have valid android:name";
					return;
				}
				className = outInfo.name;
				int iconVal = args.sa.getResourceId(args.iconRes, 0);
				if (iconVal != 0)
				{
					outInfo.icon = iconVal;
					outInfo.nonLocalizedLabel = null;
				}
				int logoVal = args.sa.getResourceId(args.logoRes, 0);
				if (logoVal != 0)
				{
					outInfo.logo = logoVal;
				}
				android.util.TypedValue v = args.sa.peekValue(args.labelRes);
				if (v != null && (outInfo.labelRes = v.resourceId) == 0)
				{
					outInfo.nonLocalizedLabel = v.coerceToString();
				}
				outInfo.packageName = owner.packageName;
			}

			internal Component(android.content.pm.PackageParser.ParseComponentArgs args, android.content.pm.ComponentInfo
				 outInfo) : this(args, (android.content.pm.PackageItemInfo)outInfo)
			{
				if (args.outError[0] != null)
				{
					return;
				}
				if (args.processRes != 0)
				{
					java.lang.CharSequence pname;
					if (owner.applicationInfo.targetSdkVersion >= android.os.Build.VERSION_CODES.FROYO)
					{
						pname = java.lang.CharSequenceProxy.Wrap(args.sa.getNonConfigurationString(args.processRes
							, 0));
					}
					else
					{
						// Some older apps have been seen to use a resource reference
						// here that on older builds was ignored (with a warning).  We
						// need to continue to do this for them so they don't break.
						pname = java.lang.CharSequenceProxy.Wrap(args.sa.getNonResourceString(args.processRes
							));
					}
					outInfo.processName = buildProcessName(owner.applicationInfo.packageName, owner.applicationInfo
						.processName, pname, args.flags, args.sepProcesses, args.outError);
				}
				if (args.descriptionRes != 0)
				{
					outInfo.descriptionRes = args.sa.getResourceId(args.descriptionRes, 0);
				}
				outInfo.enabled = args.sa.getBoolean(args.enabledRes, true);
			}

			public Component(android.content.pm.PackageParser.Component<II> clone_1)
			{
				owner = clone_1.owner;
				intents = clone_1.intents;
				className = clone_1.className;
				componentName = clone_1.componentName;
				componentShortName = clone_1.componentShortName;
			}

			public virtual android.content.ComponentName getComponentName()
			{
				if (componentName != null)
				{
					return componentName;
				}
				if (className != null)
				{
					componentName = new android.content.ComponentName(owner.applicationInfo.packageName
						, className);
				}
				return componentName;
			}

			public virtual string getComponentShortName()
			{
				if (componentShortName != null)
				{
					return componentShortName;
				}
				android.content.ComponentName component = getComponentName();
				if (component != null)
				{
					componentShortName = component.flattenToShortString();
				}
				return componentShortName;
			}

			public virtual void setPackageName(string packageName)
			{
				componentName = null;
				componentShortName = null;
			}
		}

		public sealed class Permission : android.content.pm.PackageParser.Component<android.content.pm.PackageParser
			.IntentInfo>
		{
			public readonly android.content.pm.PermissionInfo info;

			public bool tree;

			public android.content.pm.PackageParser.PermissionGroup group;

			public Permission(android.content.pm.PackageParser.Package _owner) : base(_owner)
			{
				info = new android.content.pm.PermissionInfo();
			}

			public Permission(android.content.pm.PackageParser.Package _owner, android.content.pm.PermissionInfo
				 _info) : base(_owner)
			{
				info = _info;
			}

			[Sharpen.OverridesMethod(@"android.content.pm.PackageParser.Component")]
			public override void setPackageName(string packageName)
			{
				base.setPackageName(packageName);
				info.packageName = packageName;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "Permission{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(
					this)) + " " + info.name + "}";
			}
		}

		public sealed class PermissionGroup : android.content.pm.PackageParser.Component<
			android.content.pm.PackageParser.IntentInfo>
		{
			public readonly android.content.pm.PermissionGroupInfo info;

			public PermissionGroup(android.content.pm.PackageParser.Package _owner) : base(_owner
				)
			{
				info = new android.content.pm.PermissionGroupInfo();
			}

			public PermissionGroup(android.content.pm.PackageParser.Package _owner, android.content.pm.PermissionGroupInfo
				 _info) : base(_owner)
			{
				info = _info;
			}

			[Sharpen.OverridesMethod(@"android.content.pm.PackageParser.Component")]
			public override void setPackageName(string packageName)
			{
				base.setPackageName(packageName);
				info.packageName = packageName;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "PermissionGroup{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " " + info.name + "}";
			}
		}

		private static bool copyNeeded(int flags, android.content.pm.PackageParser.Package
			 p, android.os.Bundle metaData)
		{
			if (p.mSetEnabled != android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_DEFAULT)
			{
				bool enabled = p.mSetEnabled == android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_ENABLED;
				if (p.applicationInfo.enabled != enabled)
				{
					return true;
				}
			}
			if ((flags & android.content.pm.PackageManager.GET_META_DATA) != 0 && (metaData !=
				 null || p.mAppMetaData != null))
			{
				return true;
			}
			if ((flags & android.content.pm.PackageManager.GET_SHARED_LIBRARY_FILES) != 0 && 
				p.usesLibraryFiles != null)
			{
				return true;
			}
			return false;
		}

		public static android.content.pm.ApplicationInfo generateApplicationInfo(android.content.pm.PackageParser
			.Package p, int flags)
		{
			if (p == null)
			{
				return null;
			}
			if (!copyNeeded(flags, p, null))
			{
				// CompatibilityMode is global state. It's safe to modify the instance
				// of the package.
				if (!sCompatibilityModeEnabled)
				{
					p.applicationInfo.disableCompatibilityMode();
				}
				if (p.mSetStopped)
				{
					p.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_STOPPED;
				}
				else
				{
					p.applicationInfo.flags &= ~android.content.pm.ApplicationInfo.FLAG_STOPPED;
				}
				return p.applicationInfo;
			}
			// Make shallow copy so we can store the metadata/libraries safely
			android.content.pm.ApplicationInfo ai = new android.content.pm.ApplicationInfo(p.
				applicationInfo);
			if ((flags & android.content.pm.PackageManager.GET_META_DATA) != 0)
			{
				ai.metaData = p.mAppMetaData;
			}
			if ((flags & android.content.pm.PackageManager.GET_SHARED_LIBRARY_FILES) != 0)
			{
				ai.sharedLibraryFiles = p.usesLibraryFiles;
			}
			if (!sCompatibilityModeEnabled)
			{
				ai.disableCompatibilityMode();
			}
			if (p.mSetStopped)
			{
				p.applicationInfo.flags |= android.content.pm.ApplicationInfo.FLAG_STOPPED;
			}
			else
			{
				p.applicationInfo.flags &= ~android.content.pm.ApplicationInfo.FLAG_STOPPED;
			}
			if (p.mSetEnabled == android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_ENABLED)
			{
				ai.enabled = true;
			}
			else
			{
				if (p.mSetEnabled == android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_DISABLED
					 || p.mSetEnabled == android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_DISABLED_USER)
				{
					ai.enabled = false;
				}
			}
			ai.enabledSetting = p.mSetEnabled;
			return ai;
		}

		public static android.content.pm.PermissionInfo generatePermissionInfo(android.content.pm.PackageParser
			.Permission p, int flags)
		{
			if (p == null)
			{
				return null;
			}
			if ((flags & android.content.pm.PackageManager.GET_META_DATA) == 0)
			{
				return p.info;
			}
			android.content.pm.PermissionInfo pi = new android.content.pm.PermissionInfo(p.info
				);
			pi.metaData = p.metaData;
			return pi;
		}

		public static android.content.pm.PermissionGroupInfo generatePermissionGroupInfo(
			android.content.pm.PackageParser.PermissionGroup pg, int flags)
		{
			if (pg == null)
			{
				return null;
			}
			if ((flags & android.content.pm.PackageManager.GET_META_DATA) == 0)
			{
				return pg.info;
			}
			android.content.pm.PermissionGroupInfo pgi = new android.content.pm.PermissionGroupInfo
				(pg.info);
			pgi.metaData = pg.metaData;
			return pgi;
		}

		public sealed class Activity : android.content.pm.PackageParser.Component<android.content.pm.PackageParser
			.ActivityIntentInfo>
		{
			public readonly android.content.pm.ActivityInfo info;

			internal Activity(android.content.pm.PackageParser.ParseComponentArgs args, android.content.pm.ActivityInfo
				 _info) : base(args, _info)
			{
				info = _info;
				info.applicationInfo = args.owner.applicationInfo;
			}

			[Sharpen.OverridesMethod(@"android.content.pm.PackageParser.Component")]
			public override void setPackageName(string packageName)
			{
				base.setPackageName(packageName);
				info.packageName = packageName;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "Activity{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this
					)) + " " + getComponentShortName() + "}";
			}
		}

		public static android.content.pm.ActivityInfo generateActivityInfo(android.content.pm.PackageParser
			.Activity a, int flags)
		{
			if (a == null)
			{
				return null;
			}
			if (!copyNeeded(flags, a.owner, a.metaData))
			{
				return a.info;
			}
			// Make shallow copies so we can store the metadata safely
			android.content.pm.ActivityInfo ai = new android.content.pm.ActivityInfo(a.info);
			ai.metaData = a.metaData;
			ai.applicationInfo = generateApplicationInfo(a.owner, flags);
			return ai;
		}

		public sealed class Service : android.content.pm.PackageParser.Component<android.content.pm.PackageParser
			.ServiceIntentInfo>
		{
			public readonly android.content.pm.ServiceInfo info;

			internal Service(android.content.pm.PackageParser.ParseComponentArgs args, android.content.pm.ServiceInfo
				 _info) : base(args, _info)
			{
				info = _info;
				info.applicationInfo = args.owner.applicationInfo;
			}

			[Sharpen.OverridesMethod(@"android.content.pm.PackageParser.Component")]
			public override void setPackageName(string packageName)
			{
				base.setPackageName(packageName);
				info.packageName = packageName;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "Service{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this
					)) + " " + getComponentShortName() + "}";
			}
		}

		public static android.content.pm.ServiceInfo generateServiceInfo(android.content.pm.PackageParser
			.Service s, int flags)
		{
			if (s == null)
			{
				return null;
			}
			if (!copyNeeded(flags, s.owner, s.metaData))
			{
				return s.info;
			}
			// Make shallow copies so we can store the metadata safely
			android.content.pm.ServiceInfo si = new android.content.pm.ServiceInfo(s.info);
			si.metaData = s.metaData;
			si.applicationInfo = generateApplicationInfo(s.owner, flags);
			return si;
		}

		public sealed class Provider : android.content.pm.PackageParser.Component<android.content.pm.PackageParser
			.IntentInfo>
		{
			public readonly android.content.pm.ProviderInfo info;

			public bool syncable;

			internal Provider(android.content.pm.PackageParser.ParseComponentArgs args, android.content.pm.ProviderInfo
				 _info) : base(args, _info)
			{
				info = _info;
				info.applicationInfo = args.owner.applicationInfo;
				syncable = false;
			}

			public Provider(android.content.pm.PackageParser.Provider existingProvider) : base
				(existingProvider)
			{
				this.info = existingProvider.info;
				this.syncable = existingProvider.syncable;
			}

			[Sharpen.OverridesMethod(@"android.content.pm.PackageParser.Component")]
			public override void setPackageName(string packageName)
			{
				base.setPackageName(packageName);
				info.packageName = packageName;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "Provider{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this
					)) + " " + info.name + "}";
			}
		}

		public static android.content.pm.ProviderInfo generateProviderInfo(android.content.pm.PackageParser
			.Provider p, int flags)
		{
			if (p == null)
			{
				return null;
			}
			if (!copyNeeded(flags, p.owner, p.metaData) && ((flags & android.content.pm.PackageManager
				.GET_URI_PERMISSION_PATTERNS) != 0 || p.info.uriPermissionPatterns == null))
			{
				return p.info;
			}
			// Make shallow copies so we can store the metadata safely
			android.content.pm.ProviderInfo pi = new android.content.pm.ProviderInfo(p.info);
			pi.metaData = p.metaData;
			if ((flags & android.content.pm.PackageManager.GET_URI_PERMISSION_PATTERNS) == 0)
			{
				pi.uriPermissionPatterns = null;
			}
			pi.applicationInfo = generateApplicationInfo(p.owner, flags);
			return pi;
		}

		public sealed class Instrumentation : android.content.pm.PackageParser.Component<
			android.content.pm.PackageParser.IntentInfo>
		{
			public readonly android.content.pm.InstrumentationInfo info;

			internal Instrumentation(android.content.pm.PackageParser.ParsePackageItemArgs args
				, android.content.pm.InstrumentationInfo _info) : base(args, _info)
			{
				info = _info;
			}

			[Sharpen.OverridesMethod(@"android.content.pm.PackageParser.Component")]
			public override void setPackageName(string packageName)
			{
				base.setPackageName(packageName);
				info.packageName = packageName;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "Instrumentation{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " " + getComponentShortName() + "}";
			}
		}

		public static android.content.pm.InstrumentationInfo generateInstrumentationInfo(
			android.content.pm.PackageParser.Instrumentation i, int flags)
		{
			if (i == null)
			{
				return null;
			}
			if ((flags & android.content.pm.PackageManager.GET_META_DATA) == 0)
			{
				return i.info;
			}
			android.content.pm.InstrumentationInfo ii = new android.content.pm.InstrumentationInfo
				(i.info);
			ii.metaData = i.metaData;
			return ii;
		}

		public class IntentInfo : android.content.IntentFilter
		{
			public bool hasDefault;

			public int labelRes;

			public java.lang.CharSequence nonLocalizedLabel;

			public int icon;

			public int logo;
		}

		public sealed class ActivityIntentInfo : android.content.pm.PackageParser.IntentInfo
		{
			public readonly android.content.pm.PackageParser.Activity activity;

			public ActivityIntentInfo(android.content.pm.PackageParser.Activity _activity)
			{
				activity = _activity;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "ActivityIntentInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " " + activity.info.name + "}";
			}
		}

		public sealed class ServiceIntentInfo : android.content.pm.PackageParser.IntentInfo
		{
			public readonly android.content.pm.PackageParser.Service service;

			public ServiceIntentInfo(android.content.pm.PackageParser.Service _service)
			{
				service = _service;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "ServiceIntentInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " " + service.info.name + "}";
			}
		}

		/// <hide></hide>
		public static void setCompatibilityModeEnabled(bool compatibilityModeEnabled)
		{
			sCompatibilityModeEnabled = compatibilityModeEnabled;
		}
	}
}
