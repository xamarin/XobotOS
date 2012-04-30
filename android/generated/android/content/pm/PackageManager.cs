using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Class for retrieving various kinds of information related to the application
	/// packages that are currently installed on the device.
	/// </summary>
	/// <remarks>
	/// Class for retrieving various kinds of information related to the application
	/// packages that are currently installed on the device.
	/// You can find this class through
	/// <see cref="android.content.Context.getPackageManager()">android.content.Context.getPackageManager()
	/// 	</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class PackageManager
	{
		/// <summary>
		/// This exception is thrown when a given package, application, or component
		/// name can not be found.
		/// </summary>
		/// <remarks>
		/// This exception is thrown when a given package, application, or component
		/// name can not be found.
		/// </remarks>
		[System.Serializable]
		public class NameNotFoundException : android.util.AndroidException
		{
			public NameNotFoundException()
			{
			}

			public NameNotFoundException(string name) : base(name)
			{
			}
		}

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about
		/// activities in the package in
		/// <see cref="PackageInfo.activities">PackageInfo.activities</see>
		/// .
		/// </summary>
		public const int GET_ACTIVITIES = unchecked((int)(0x00000001));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about
		/// intent receivers in the package in
		/// <see cref="PackageInfo.receivers">PackageInfo.receivers</see>
		/// .
		/// </summary>
		public const int GET_RECEIVERS = unchecked((int)(0x00000002));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about
		/// services in the package in
		/// <see cref="PackageInfo.services">PackageInfo.services</see>
		/// .
		/// </summary>
		public const int GET_SERVICES = unchecked((int)(0x00000004));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about
		/// content providers in the package in
		/// <see cref="PackageInfo.providers">PackageInfo.providers</see>
		/// .
		/// </summary>
		public const int GET_PROVIDERS = unchecked((int)(0x00000008));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about
		/// instrumentation in the package in
		/// <see cref="PackageInfo.instrumentation">PackageInfo.instrumentation</see>
		/// .
		/// </summary>
		public const int GET_INSTRUMENTATION = unchecked((int)(0x00000010));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about the
		/// intent filters supported by the activity.
		/// </summary>
		public const int GET_INTENT_FILTERS = unchecked((int)(0x00000020));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about the
		/// signatures included in the package.
		/// </summary>
		public const int GET_SIGNATURES = unchecked((int)(0x00000040));

		/// <summary>
		/// <see cref="ResolveInfo">ResolveInfo</see>
		/// flag: return the IntentFilter that
		/// was matched for a particular ResolveInfo in
		/// <see cref="ResolveInfo.filter">ResolveInfo.filter</see>
		/// .
		/// </summary>
		public const int GET_RESOLVED_FILTER = unchecked((int)(0x00000040));

		/// <summary>
		/// <see cref="ComponentInfo">ComponentInfo</see>
		/// flag: return the
		/// <see cref="PackageItemInfo.metaData">PackageItemInfo.metaData</see>
		/// data
		/// <see cref="android.os.Bundle">android.os.Bundle</see>
		/// s that are associated with a component.
		/// This applies for any API returning a ComponentInfo subclass.
		/// </summary>
		public const int GET_META_DATA = unchecked((int)(0x00000080));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return the
		/// <see cref="PackageInfo.gids">group ids</see>
		/// that are associated with an
		/// application.
		/// This applies for any API returning an PackageInfo class, either
		/// directly or nested inside of another.
		/// </summary>
		public const int GET_GIDS = unchecked((int)(0x00000100));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: include disabled components in the returned info.
		/// </summary>
		public const int GET_DISABLED_COMPONENTS = unchecked((int)(0x00000200));

		/// <summary>
		/// <see cref="ApplicationInfo">ApplicationInfo</see>
		/// flag: return the
		/// <see cref="ApplicationInfo.sharedLibraryFiles">paths to the shared libraries</see>
		/// that are associated with an application.
		/// This applies for any API returning an ApplicationInfo class, either
		/// directly or nested inside of another.
		/// </summary>
		public const int GET_SHARED_LIBRARY_FILES = unchecked((int)(0x00000400));

		/// <summary>
		/// <see cref="ProviderInfo">ProviderInfo</see>
		/// flag: return the
		/// <see cref="ProviderInfo.uriPermissionPatterns">URI permission patterns</see>
		/// that are associated with a content provider.
		/// This applies for any API returning an ProviderInfo class, either
		/// directly or nested inside of another.
		/// </summary>
		public const int GET_URI_PERMISSION_PATTERNS = unchecked((int)(0x00000800));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about
		/// permissions in the package in
		/// <see cref="PackageInfo.permissions">PackageInfo.permissions</see>
		/// .
		/// </summary>
		public const int GET_PERMISSIONS = unchecked((int)(0x00001000));

		/// <summary>Flag parameter to retrieve all applications(even uninstalled ones) with data directories.
		/// 	</summary>
		/// <remarks>
		/// Flag parameter to retrieve all applications(even uninstalled ones) with data directories.
		/// This state could have resulted if applications have been deleted with flag
		/// DONT_DELETE_DATA
		/// with a possibility of being replaced or reinstalled in future
		/// </remarks>
		public const int GET_UNINSTALLED_PACKAGES = unchecked((int)(0x00002000));

		/// <summary>
		/// <see cref="PackageInfo">PackageInfo</see>
		/// flag: return information about
		/// hardware preferences in
		/// <see cref="PackageInfo.configPreferences">PackageInfo.configPreferences</see>
		/// and
		/// requested features in
		/// <see cref="PackageInfo.reqFeatures">PackageInfo.reqFeatures</see>
		/// .
		/// </summary>
		public const int GET_CONFIGURATIONS = unchecked((int)(0x00004000));

		/// <summary>
		/// Resolution and querying flag: if set, only filters that support the
		/// <see cref="android.content.Intent.CATEGORY_DEFAULT">android.content.Intent.CATEGORY_DEFAULT
		/// 	</see>
		/// will be considered for
		/// matching.  This is a synonym for including the CATEGORY_DEFAULT in your
		/// supplied Intent.
		/// </summary>
		public const int MATCH_DEFAULT_ONLY = unchecked((int)(0x00010000));

		/// <summary>
		/// Permission check result: this is returned by
		/// <see cref="checkPermission(string, string)">checkPermission(string, string)</see>
		/// if the permission has been granted to the given package.
		/// </summary>
		public const int PERMISSION_GRANTED = 0;

		/// <summary>
		/// Permission check result: this is returned by
		/// <see cref="checkPermission(string, string)">checkPermission(string, string)</see>
		/// if the permission has not been granted to the given package.
		/// </summary>
		public const int PERMISSION_DENIED = -1;

		/// <summary>
		/// Signature check result: this is returned by
		/// <see cref="checkSignatures(string, string)">checkSignatures(string, string)</see>
		/// if all signatures on the two packages match.
		/// </summary>
		public const int SIGNATURE_MATCH = 0;

		/// <summary>
		/// Signature check result: this is returned by
		/// <see cref="checkSignatures(string, string)">checkSignatures(string, string)</see>
		/// if neither of the two packages is signed.
		/// </summary>
		public const int SIGNATURE_NEITHER_SIGNED = 1;

		/// <summary>
		/// Signature check result: this is returned by
		/// <see cref="checkSignatures(string, string)">checkSignatures(string, string)</see>
		/// if the first package is not signed but the second is.
		/// </summary>
		public const int SIGNATURE_FIRST_NOT_SIGNED = -1;

		/// <summary>
		/// Signature check result: this is returned by
		/// <see cref="checkSignatures(string, string)">checkSignatures(string, string)</see>
		/// if the second package is not signed but the first is.
		/// </summary>
		public const int SIGNATURE_SECOND_NOT_SIGNED = -2;

		/// <summary>
		/// Signature check result: this is returned by
		/// <see cref="checkSignatures(string, string)">checkSignatures(string, string)</see>
		/// if not all signatures on both packages match.
		/// </summary>
		public const int SIGNATURE_NO_MATCH = -3;

		/// <summary>
		/// Signature check result: this is returned by
		/// <see cref="checkSignatures(string, string)">checkSignatures(string, string)</see>
		/// if either of the packages are not valid.
		/// </summary>
		public const int SIGNATURE_UNKNOWN_PACKAGE = -4;

		/// <summary>
		/// Flag for
		/// <see cref="setApplicationEnabledSetting(string, int, int)">setApplicationEnabledSetting(string, int, int)
		/// 	</see>
		/// and
		/// <see cref="setComponentEnabledSetting(android.content.ComponentName, int, int)">setComponentEnabledSetting(android.content.ComponentName, int, int)
		/// 	</see>
		/// : This
		/// component or application is in its default enabled state (as specified
		/// in its manifest).
		/// </summary>
		public const int COMPONENT_ENABLED_STATE_DEFAULT = 0;

		/// <summary>
		/// Flag for
		/// <see cref="setApplicationEnabledSetting(string, int, int)">setApplicationEnabledSetting(string, int, int)
		/// 	</see>
		/// and
		/// <see cref="setComponentEnabledSetting(android.content.ComponentName, int, int)">setComponentEnabledSetting(android.content.ComponentName, int, int)
		/// 	</see>
		/// : This
		/// component or application has been explictily enabled, regardless of
		/// what it has specified in its manifest.
		/// </summary>
		public const int COMPONENT_ENABLED_STATE_ENABLED = 1;

		/// <summary>
		/// Flag for
		/// <see cref="setApplicationEnabledSetting(string, int, int)">setApplicationEnabledSetting(string, int, int)
		/// 	</see>
		/// and
		/// <see cref="setComponentEnabledSetting(android.content.ComponentName, int, int)">setComponentEnabledSetting(android.content.ComponentName, int, int)
		/// 	</see>
		/// : This
		/// component or application has been explicitly disabled, regardless of
		/// what it has specified in its manifest.
		/// </summary>
		public const int COMPONENT_ENABLED_STATE_DISABLED = 2;

		/// <summary>
		/// Flag for
		/// <see cref="setApplicationEnabledSetting(string, int, int)">setApplicationEnabledSetting(string, int, int)
		/// 	</see>
		/// only: The
		/// user has explicitly disabled the application, regardless of what it has
		/// specified in its manifest.  Because this is due to the user's request,
		/// they may re-enable it if desired through the appropriate system UI.  This
		/// option currently <strong>can not</strong> be used with
		/// <see cref="setComponentEnabledSetting(android.content.ComponentName, int, int)">setComponentEnabledSetting(android.content.ComponentName, int, int)
		/// 	</see>
		/// .
		/// </summary>
		public const int COMPONENT_ENABLED_STATE_DISABLED_USER = 3;

		/// <summary>
		/// Flag parameter for
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// to
		/// indicate that this package should be installed as forward locked, i.e. only the app itself
		/// should have access to its code and non-resource assets.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FORWARD_LOCK = unchecked((int)(0x00000001));

		/// <summary>
		/// Flag parameter for
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// to indicate that you want to replace an already
		/// installed package, if one exists.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_REPLACE_EXISTING = unchecked((int)(0x00000002));

		/// <summary>
		/// Flag parameter for
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// to indicate that you want to
		/// allow test packages (those that have set android:testOnly in their
		/// manifest) to be installed.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_ALLOW_TEST = unchecked((int)(0x00000004));

		/// <summary>
		/// Flag parameter for
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// to indicate that this
		/// package has to be installed on the sdcard.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_EXTERNAL = unchecked((int)(0x00000008));

		/// <summary>
		/// Flag parameter for
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// to indicate that this package
		/// has to be installed on the sdcard.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_INTERNAL = unchecked((int)(0x00000010));

		/// <summary>
		/// Flag parameter for
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// to indicate that this install
		/// was initiated via ADB.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FROM_ADB = unchecked((int)(0x00000020));

		/// <summary>
		/// Flag parameter for
		/// <see cref="setComponentEnabledSetting(android.content.ComponentName, int, int)">setComponentEnabledSetting(android.content.ComponentName, int, int)
		/// 	</see>
		/// to indicate
		/// that you don't want to kill the app containing the component.  Be careful when you set this
		/// since changing component states can make the containing application's behavior unpredictable.
		/// </summary>
		public const int DONT_KILL_APP = unchecked((int)(0x00000001));

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// on success.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_SUCCEEDED = 1;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the package is
		/// already installed.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_ALREADY_EXISTS = -1;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the package archive
		/// file is invalid.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_INVALID_APK = -2;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the URI passed in
		/// is invalid.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_INVALID_URI = -3;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the package manager
		/// service found that the device didn't have enough storage space to install the app.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_INSUFFICIENT_STORAGE = -4;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if a
		/// package is already installed with the same name.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_DUPLICATE_PACKAGE = -5;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the requested shared user does not exist.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_NO_SHARED_USER = -6;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// a previously installed package of the same name has a different signature
		/// than the new package (and the old package's data was not removed).
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_UPDATE_INCOMPATIBLE = -7;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package is requested a shared user which is already installed on the
		/// device and does not have matching signature.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_SHARED_USER_INCOMPATIBLE = -8;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package uses a shared library that is not available.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_MISSING_SHARED_LIBRARY = -9;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package uses a shared library that is not available.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_REPLACE_COULDNT_DELETE = -10;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package failed while optimizing and validating its dex files,
		/// either because there was not enough storage or the validation failed.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_DEXOPT = -11;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package failed because the current SDK version is older than
		/// that required by the package.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_OLDER_SDK = -12;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package failed because it contains a content provider with the
		/// same authority as a provider already installed in the system.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_CONFLICTING_PROVIDER = -13;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package failed because the current SDK version is newer than
		/// that required by the package.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_NEWER_SDK = -14;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package failed because it has specified that it is a test-only
		/// package and the caller has not supplied the
		/// <see cref="INSTALL_ALLOW_TEST">INSTALL_ALLOW_TEST</see>
		/// flag.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_TEST_ONLY = -15;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the package being installed contains native code, but none that is
		/// compatible with the the device's CPU_ABI.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_CPU_ABI_INCOMPATIBLE = -16;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package uses a feature that is not available.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_MISSING_FEATURE = -17;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// a secure container mount point couldn't be accessed on external media.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_CONTAINER_ERROR = -18;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package couldn't be installed in the specified install
		/// location.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_INVALID_INSTALL_LOCATION = -19;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package couldn't be installed in the specified install
		/// location because the media is not available.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_MEDIA_UNAVAILABLE = -20;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package couldn't be installed because the verification timed out.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_VERIFICATION_TIMEOUT = -21;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the new package couldn't be installed because the verification did not succeed.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_VERIFICATION_FAILURE = -22;

		/// <summary>
		/// Installation return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if
		/// the package changed from what the calling program expected.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_PACKAGE_CHANGED = -23;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser was given a path that is not a file, or does not end with the expected
		/// '.apk' extension.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_NOT_APK = -100;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser was unable to retrieve the AndroidManifest.xml file.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_BAD_MANIFEST = -101;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser encountered an unexpected exception.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_UNEXPECTED_EXCEPTION = -102;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser did not find any certificates in the .apk.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_NO_CERTIFICATES = -103;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser found inconsistent certificates on the files in the .apk.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_INCONSISTENT_CERTIFICATES = -104;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser encountered a CertificateEncodingException in one of the
		/// files in the .apk.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_CERTIFICATE_ENCODING = -105;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser encountered a bad or missing package name in the manifest.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_BAD_PACKAGE_NAME = -106;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser encountered a bad shared user id name in the manifest.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_BAD_SHARED_USER_ID = -107;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser encountered some structural problem in the manifest.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_MANIFEST_MALFORMED = -108;

		/// <summary>
		/// Installation parse return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the parser did not find any actionable tags (instrumentation or application)
		/// in the manifest.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_PARSE_FAILED_MANIFEST_EMPTY = -109;

		/// <summary>
		/// Installation failed return code: this is passed to the
		/// <see cref="IPackageInstallObserver">IPackageInstallObserver</see>
		/// by
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// if the system failed to install the package because of system issues.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_FAILED_INTERNAL_ERROR = -110;

		/// <summary>
		/// Flag parameter for
		/// <see cref="deletePackage(string, IPackageDeleteObserver, int)">deletePackage(string, IPackageDeleteObserver, int)
		/// 	</see>
		/// to indicate that you don't want to delete the
		/// package's data directory.
		/// </summary>
		/// <hide></hide>
		public const int DONT_DELETE_DATA = unchecked((int)(0x00000001));

		/// <summary>Return code for when package deletion succeeds.</summary>
		/// <remarks>
		/// Return code for when package deletion succeeds. This is passed to the
		/// <see cref="IPackageDeleteObserver">IPackageDeleteObserver</see>
		/// by
		/// <see cref="deletePackage(string, IPackageDeleteObserver, int)">deletePackage(string, IPackageDeleteObserver, int)
		/// 	</see>
		/// if the system
		/// succeeded in deleting the package.
		/// </remarks>
		/// <hide></hide>
		public const int DELETE_SUCCEEDED = 1;

		/// <summary>
		/// Deletion failed return code: this is passed to the
		/// <see cref="IPackageDeleteObserver">IPackageDeleteObserver</see>
		/// by
		/// <see cref="deletePackage(string, IPackageDeleteObserver, int)">deletePackage(string, IPackageDeleteObserver, int)
		/// 	</see>
		/// if the system
		/// failed to delete the package for an unspecified reason.
		/// </summary>
		/// <hide></hide>
		public const int DELETE_FAILED_INTERNAL_ERROR = -1;

		/// <summary>
		/// Deletion failed return code: this is passed to the
		/// <see cref="IPackageDeleteObserver">IPackageDeleteObserver</see>
		/// by
		/// <see cref="deletePackage(string, IPackageDeleteObserver, int)">deletePackage(string, IPackageDeleteObserver, int)
		/// 	</see>
		/// if the system
		/// failed to delete the package because it is the active DevicePolicy
		/// manager.
		/// </summary>
		/// <hide></hide>
		public const int DELETE_FAILED_DEVICE_POLICY_MANAGER = -2;

		/// <summary>
		/// Return code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// when the
		/// package has been successfully moved by the system.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_SUCCEEDED = 1;

		/// <summary>
		/// Error code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// when the package hasn't been successfully moved by the system
		/// because of insufficient memory on specified media.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_FAILED_INSUFFICIENT_STORAGE = -1;

		/// <summary>
		/// Error code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// if the specified package doesn't exist.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_FAILED_DOESNT_EXIST = -2;

		/// <summary>
		/// Error code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// if the specified package cannot be moved since its a system package.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_FAILED_SYSTEM_PACKAGE = -3;

		/// <summary>
		/// Error code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// if the specified package cannot be moved since its forward locked.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_FAILED_FORWARD_LOCKED = -4;

		/// <summary>
		/// Error code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// if the specified package cannot be moved to the specified location.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_FAILED_INVALID_LOCATION = -5;

		/// <summary>
		/// Error code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// if the specified package cannot be moved to the specified location.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_FAILED_INTERNAL_ERROR = -6;

		/// <summary>
		/// Error code that is passed to the
		/// <see cref="IPackageMoveObserver">IPackageMoveObserver</see>
		/// by
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// if the
		/// specified package already has an operation pending in the
		/// <see cref="PackageHandler">PackageHandler</see>
		/// queue.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_FAILED_OPERATION_PENDING = -7;

		/// <summary>
		/// Flag parameter for
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// to indicate that
		/// the package should be moved to internal storage if its
		/// been installed on external media.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_INTERNAL = unchecked((int)(0x00000001));

		/// <summary>
		/// Flag parameter for
		/// <see cref="movePackage(string, IPackageMoveObserver, int)">movePackage(string, IPackageMoveObserver, int)
		/// 	</see>
		/// to indicate that
		/// the package should be moved to external media.
		/// </summary>
		/// <hide></hide>
		public const int MOVE_EXTERNAL_MEDIA = unchecked((int)(0x00000002));

		/// <summary>
		/// Usable by the required verifier as the
		/// <code>verificationCode</code>
		/// argument
		/// for
		/// <see cref="verifyPendingInstall(int, int)">verifyPendingInstall(int, int)</see>
		/// to indicate that it will
		/// allow the installation to proceed without any of the optional verifiers
		/// needing to vote.
		/// </summary>
		/// <hide></hide>
		public const int VERIFICATION_ALLOW_WITHOUT_SUFFICIENT = 2;

		/// <summary>
		/// Used as the
		/// <code>verificationCode</code>
		/// argument for
		/// <see cref="verifyPendingInstall(int, int)">verifyPendingInstall(int, int)</see>
		/// to indicate that the calling
		/// package verifier allows the installation to proceed.
		/// </summary>
		public const int VERIFICATION_ALLOW = 1;

		/// <summary>
		/// Used as the
		/// <code>verificationCode</code>
		/// argument for
		/// <see cref="verifyPendingInstall(int, int)">verifyPendingInstall(int, int)</see>
		/// to indicate the calling
		/// package verifier does not vote to allow the installation to proceed.
		/// </summary>
		public const int VERIFICATION_REJECT = -1;

		/// <summary>Range of IDs allocated for a user.</summary>
		/// <remarks>Range of IDs allocated for a user.</remarks>
		/// <hide></hide>
		public const int PER_USER_RANGE = 100000;

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device's
		/// audio pipeline is low-latency, more suitable for audio applications sensitive to delays or
		/// lag in sound input or output.
		/// </summary>
		public const string FEATURE_AUDIO_LOW_LATENCY = "android.hardware.audio.low_latency";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device is capable of communicating with
		/// other devices via Bluetooth.
		/// </summary>
		public const string FEATURE_BLUETOOTH = "android.hardware.bluetooth";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device has a camera facing away
		/// from the screen.
		/// </summary>
		public const string FEATURE_CAMERA = "android.hardware.camera";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device's camera supports auto-focus.
		/// </summary>
		public const string FEATURE_CAMERA_AUTOFOCUS = "android.hardware.camera.autofocus";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device's camera supports flash.
		/// </summary>
		public const string FEATURE_CAMERA_FLASH = "android.hardware.camera.flash";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device has a front facing camera.
		/// </summary>
		public const string FEATURE_CAMERA_FRONT = "android.hardware.camera.front";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports one or more methods of
		/// reporting current location.
		/// </summary>
		public const string FEATURE_LOCATION = "android.hardware.location";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device has a Global Positioning System
		/// receiver and can report precise location.
		/// </summary>
		public const string FEATURE_LOCATION_GPS = "android.hardware.location.gps";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device can report location with coarse
		/// accuracy using a network-based geolocation system.
		/// </summary>
		public const string FEATURE_LOCATION_NETWORK = "android.hardware.location.network";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device can record audio via a
		/// microphone.
		/// </summary>
		public const string FEATURE_MICROPHONE = "android.hardware.microphone";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device can communicate using Near-Field
		/// Communications (NFC).
		/// </summary>
		public const string FEATURE_NFC = "android.hardware.nfc";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device includes an accelerometer.
		/// </summary>
		public const string FEATURE_SENSOR_ACCELEROMETER = "android.hardware.sensor.accelerometer";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device includes a barometer (air
		/// pressure sensor.)
		/// </summary>
		public const string FEATURE_SENSOR_BAROMETER = "android.hardware.sensor.barometer";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device includes a magnetometer (compass).
		/// </summary>
		public const string FEATURE_SENSOR_COMPASS = "android.hardware.sensor.compass";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device includes a gyroscope.
		/// </summary>
		public const string FEATURE_SENSOR_GYROSCOPE = "android.hardware.sensor.gyroscope";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device includes a light sensor.
		/// </summary>
		public const string FEATURE_SENSOR_LIGHT = "android.hardware.sensor.light";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device includes a proximity sensor.
		/// </summary>
		public const string FEATURE_SENSOR_PROXIMITY = "android.hardware.sensor.proximity";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device has a telephony radio with data
		/// communication support.
		/// </summary>
		public const string FEATURE_TELEPHONY = "android.hardware.telephony";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device has a CDMA telephony stack.
		/// </summary>
		public const string FEATURE_TELEPHONY_CDMA = "android.hardware.telephony.cdma";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device has a GSM telephony stack.
		/// </summary>
		public const string FEATURE_TELEPHONY_GSM = "android.hardware.telephony.gsm";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports connecting to USB devices
		/// as the USB host.
		/// </summary>
		public const string FEATURE_USB_HOST = "android.hardware.usb.host";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports connecting to USB accessories.
		/// </summary>
		public const string FEATURE_USB_ACCESSORY = "android.hardware.usb.accessory";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The SIP API is enabled on the device.
		/// </summary>
		public const string FEATURE_SIP = "android.software.sip";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports SIP-based VOIP.
		/// </summary>
		public const string FEATURE_SIP_VOIP = "android.software.sip.voip";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device's display has a touch screen.
		/// </summary>
		public const string FEATURE_TOUCHSCREEN = "android.hardware.touchscreen";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device's touch screen supports
		/// multitouch sufficient for basic two-finger gesture detection.
		/// </summary>
		public const string FEATURE_TOUCHSCREEN_MULTITOUCH = "android.hardware.touchscreen.multitouch";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device's touch screen is capable of
		/// tracking two or more fingers fully independently.
		/// </summary>
		public const string FEATURE_TOUCHSCREEN_MULTITOUCH_DISTINCT = "android.hardware.touchscreen.multitouch.distinct";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device's touch screen is capable of
		/// tracking a full hand of fingers fully independently -- that is, 5 or
		/// more simultaneous independent pointers.
		/// </summary>
		public const string FEATURE_TOUCHSCREEN_MULTITOUCH_JAZZHAND = "android.hardware.touchscreen.multitouch.jazzhand";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device does not have a touch screen, but
		/// does support touch emulation for basic events. For instance, the
		/// device might use a mouse or remote control to drive a cursor, and
		/// emulate basic touch pointer events like down, up, drag, etc. All
		/// devices that support android.hardware.touchscreen or a sub-feature are
		/// presumed to also support faketouch.
		/// </summary>
		public const string FEATURE_FAKETOUCH = "android.hardware.faketouch";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device does not have a touch screen, but
		/// does support touch emulation for basic events that supports distinct
		/// tracking of two or more fingers.  This is an extension of
		/// <see cref="FEATURE_FAKETOUCH">FEATURE_FAKETOUCH</see>
		/// for input devices with this capability.  Note
		/// that unlike a distinct multitouch screen as defined by
		/// <see cref="FEATURE_TOUCHSCREEN_MULTITOUCH_DISTINCT">FEATURE_TOUCHSCREEN_MULTITOUCH_DISTINCT
		/// 	</see>
		/// , these kinds of input
		/// devices will not actually provide full two-finger gestures since the
		/// input is being transformed to cursor movement on the screen.  That is,
		/// single finger gestures will move a cursor; two-finger swipes will
		/// result in single-finger touch events; other two-finger gestures will
		/// result in the corresponding two-finger touch event.
		/// </summary>
		public const string FEATURE_FAKETOUCH_MULTITOUCH_DISTINCT = "android.hardware.faketouch.multitouch.distinct";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device does not have a touch screen, but
		/// does support touch emulation for basic events that supports tracking
		/// a hand of fingers (5 or more fingers) fully independently.
		/// This is an extension of
		/// <see cref="FEATURE_FAKETOUCH">FEATURE_FAKETOUCH</see>
		/// for input devices with this capability.  Note
		/// that unlike a multitouch screen as defined by
		/// <see cref="FEATURE_TOUCHSCREEN_MULTITOUCH_JAZZHAND">FEATURE_TOUCHSCREEN_MULTITOUCH_JAZZHAND
		/// 	</see>
		/// , not all two finger
		/// gestures can be detected due to the limitations described for
		/// <see cref="FEATURE_FAKETOUCH_MULTITOUCH_DISTINCT">FEATURE_FAKETOUCH_MULTITOUCH_DISTINCT
		/// 	</see>
		/// .
		/// </summary>
		public const string FEATURE_FAKETOUCH_MULTITOUCH_JAZZHAND = "android.hardware.faketouch.multitouch.jazzhand";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports portrait orientation
		/// screens.  For backwards compatibility, you can assume that if neither
		/// this nor
		/// <see cref="FEATURE_SCREEN_LANDSCAPE">FEATURE_SCREEN_LANDSCAPE</see>
		/// is set then the device supports
		/// both portrait and landscape.
		/// </summary>
		public const string FEATURE_SCREEN_PORTRAIT = "android.hardware.screen.portrait";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports landscape orientation
		/// screens.  For backwards compatibility, you can assume that if neither
		/// this nor
		/// <see cref="FEATURE_SCREEN_PORTRAIT">FEATURE_SCREEN_PORTRAIT</see>
		/// is set then the device supports
		/// both portrait and landscape.
		/// </summary>
		public const string FEATURE_SCREEN_LANDSCAPE = "android.hardware.screen.landscape";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports live wallpapers.
		/// </summary>
		public const string FEATURE_LIVE_WALLPAPER = "android.software.live_wallpaper";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports WiFi (802.11) networking.
		/// </summary>
		public const string FEATURE_WIFI = "android.hardware.wifi";

		/// <summary>
		/// Feature for
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// and
		/// <see cref="hasSystemFeature(string)">hasSystemFeature(string)</see>
		/// : The device supports Wi-Fi Direct networking.
		/// </summary>
		public const string FEATURE_WIFI_DIRECT = "android.hardware.wifi.direct";

		/// <summary>Action to external storage service to clean out removed apps.</summary>
		/// <remarks>Action to external storage service to clean out removed apps.</remarks>
		/// <hide></hide>
		public const string ACTION_CLEAN_EXTERNAL_STORAGE = "android.content.pm.CLEAN_EXTERNAL_STORAGE";

		/// <summary>Extra field name for the URI to a verification file.</summary>
		/// <remarks>
		/// Extra field name for the URI to a verification file. Passed to a package
		/// verifier.
		/// </remarks>
		/// <hide></hide>
		public const string EXTRA_VERIFICATION_URI = "android.content.pm.extra.VERIFICATION_URI";

		/// <summary>Extra field name for the ID of a package pending verification.</summary>
		/// <remarks>
		/// Extra field name for the ID of a package pending verification. Passed to
		/// a package verifier and is used to call back to
		/// <see cref="verifyPendingInstall(int, int)">verifyPendingInstall(int, int)</see>
		/// </remarks>
		public const string EXTRA_VERIFICATION_ID = "android.content.pm.extra.VERIFICATION_ID";

		/// <summary>
		/// Extra field name for the package identifier which is trying to install
		/// the package.
		/// </summary>
		/// <remarks>
		/// Extra field name for the package identifier which is trying to install
		/// the package.
		/// </remarks>
		/// <hide></hide>
		public const string EXTRA_VERIFICATION_INSTALLER_PACKAGE = "android.content.pm.extra.VERIFICATION_INSTALLER_PACKAGE";

		/// <summary>
		/// Extra field name for the requested install flags for a package pending
		/// verification.
		/// </summary>
		/// <remarks>
		/// Extra field name for the requested install flags for a package pending
		/// verification. Passed to a package verifier.
		/// </remarks>
		/// <hide></hide>
		public const string EXTRA_VERIFICATION_INSTALL_FLAGS = "android.content.pm.extra.VERIFICATION_INSTALL_FLAGS";

		// ------ Errors related to sdcard
		/// <summary>
		/// Retrieve overall information about an application package that is
		/// installed on the system.
		/// </summary>
		/// <remarks>
		/// Retrieve overall information about an application package that is
		/// installed on the system.
		/// <p>
		/// Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a package with the given name can
		/// not be found on the system.
		/// </remarks>
		/// <param name="packageName">
		/// The full name (i.e. com.google.apps.contacts) of the
		/// desired package.
		/// </param>
		/// <param name="flags">
		/// Additional option flags. Use any combination of
		/// <see cref="GET_ACTIVITIES">GET_ACTIVITIES</see>
		/// ,
		/// <see cref="GET_GIDS">GET_GIDS</see>
		/// ,
		/// <see cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</see>
		/// ,
		/// <see cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</see>
		/// ,
		/// <see cref="GET_PERMISSIONS">GET_PERMISSIONS</see>
		/// ,
		/// <see cref="GET_PROVIDERS">GET_PROVIDERS</see>
		/// ,
		/// <see cref="GET_RECEIVERS">GET_RECEIVERS</see>
		/// ,
		/// <see cref="GET_SERVICES">GET_SERVICES</see>
		/// ,
		/// <see cref="GET_SIGNATURES">GET_SIGNATURES</see>
		/// ,
		/// <see cref="GET_UNINSTALLED_PACKAGES">GET_UNINSTALLED_PACKAGES</see>
		/// to
		/// modify the data returned.
		/// </param>
		/// <returns>
		/// Returns a PackageInfo object containing information about the
		/// package. If flag GET_UNINSTALLED_PACKAGES is set and if the
		/// package is not found in the list of installed applications, the
		/// package information is retrieved from the list of uninstalled
		/// applications(which includes installed applications as well as
		/// applications with data directory ie applications which had been
		/// deleted with DONT_DELTE_DATA flag set).
		/// </returns>
		/// <seealso cref="GET_ACTIVITIES">GET_ACTIVITIES</seealso>
		/// <seealso cref="GET_GIDS">GET_GIDS</seealso>
		/// <seealso cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</seealso>
		/// <seealso cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</seealso>
		/// <seealso cref="GET_PERMISSIONS">GET_PERMISSIONS</seealso>
		/// <seealso cref="GET_PROVIDERS">GET_PROVIDERS</seealso>
		/// <seealso cref="GET_RECEIVERS">GET_RECEIVERS</seealso>
		/// <seealso cref="GET_SERVICES">GET_SERVICES</seealso>
		/// <seealso cref="GET_SIGNATURES">GET_SIGNATURES</seealso>
		/// <seealso cref="GET_UNINSTALLED_PACKAGES">GET_UNINSTALLED_PACKAGES</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.PackageInfo getPackageInfo(string packageName, 
			int flags);

		/// <summary>
		/// Map from the current package names in use on the device to whatever
		/// the current canonical name of that package is.
		/// </summary>
		/// <remarks>
		/// Map from the current package names in use on the device to whatever
		/// the current canonical name of that package is.
		/// </remarks>
		/// <param name="names">Array of current names to be mapped.</param>
		/// <returns>
		/// Returns an array of the same size as the original, containing
		/// the canonical name for each package.
		/// </returns>
		public abstract string[] currentToCanonicalPackageNames(string[] names);

		/// <summary>Map from a packages canonical name to the current name in use on the device.
		/// 	</summary>
		/// <remarks>Map from a packages canonical name to the current name in use on the device.
		/// 	</remarks>
		/// <param name="names">Array of new names to be mapped.</param>
		/// <returns>
		/// Returns an array of the same size as the original, containing
		/// the current name for each package.
		/// </returns>
		public abstract string[] canonicalToCurrentPackageNames(string[] names);

		/// <summary>
		/// Return a "good" intent to launch a front-door activity in a package,
		/// for use for example to implement an "open" button when browsing through
		/// packages.
		/// </summary>
		/// <remarks>
		/// Return a "good" intent to launch a front-door activity in a package,
		/// for use for example to implement an "open" button when browsing through
		/// packages.  The current implementation will look first for a main
		/// activity in the category
		/// <see cref="android.content.Intent.CATEGORY_INFO">android.content.Intent.CATEGORY_INFO
		/// 	</see>
		/// , next for a
		/// main activity in the category
		/// <see cref="android.content.Intent.CATEGORY_LAUNCHER">android.content.Intent.CATEGORY_LAUNCHER
		/// 	</see>
		/// , or return
		/// null if neither are found.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a package with the given
		/// name can not be found on the system.
		/// </remarks>
		/// <param name="packageName">The name of the package to inspect.</param>
		/// <returns>
		/// Returns either a fully-qualified Intent that can be used to
		/// launch the main activity in the package, or null if the package does
		/// not contain such an activity.
		/// </returns>
		public abstract android.content.Intent getLaunchIntentForPackage(string packageName
			);

		/// <summary>
		/// Return an array of all of the secondary group-ids that have been
		/// assigned to a package.
		/// </summary>
		/// <remarks>
		/// Return an array of all of the secondary group-ids that have been
		/// assigned to a package.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a package with the given
		/// name can not be found on the system.
		/// </remarks>
		/// <param name="packageName">
		/// The full name (i.e. com.google.apps.contacts) of the
		/// desired package.
		/// </param>
		/// <returns>
		/// Returns an int array of the assigned gids, or null if there
		/// are none.
		/// </returns>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract int[] getPackageGids(string packageName);

		/// <summary>Retrieve all of the information we know about a particular permission.</summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular permission.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a permission with the given
		/// name can not be found on the system.
		/// </remarks>
		/// <param name="name">
		/// The fully qualified name (i.e. com.google.permission.LOGIN)
		/// of the permission you are interested in.
		/// </param>
		/// <param name="flags">
		/// Additional option flags.  Use
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// to
		/// retrieve any meta-data associated with the permission.
		/// </param>
		/// <returns>
		/// Returns a
		/// <see cref="PermissionInfo">PermissionInfo</see>
		/// containing information about the
		/// permission.
		/// </returns>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.PermissionInfo getPermissionInfo(string name, 
			int flags);

		/// <summary>Query for all of the permissions associated with a particular group.</summary>
		/// <remarks>
		/// Query for all of the permissions associated with a particular group.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if the given group does not
		/// exist.
		/// </remarks>
		/// <param name="group">
		/// The fully qualified name (i.e. com.google.permission.LOGIN)
		/// of the permission group you are interested in.  Use null to
		/// find all of the permissions not associated with a group.
		/// </param>
		/// <param name="flags">
		/// Additional option flags.  Use
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// to
		/// retrieve any meta-data associated with the permissions.
		/// </param>
		/// <returns>
		/// Returns a list of
		/// <see cref="PermissionInfo">PermissionInfo</see>
		/// containing information
		/// about all of the permissions in the given group.
		/// </returns>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract java.util.List<android.content.pm.PermissionInfo> queryPermissionsByGroup
			(string group, int flags);

		/// <summary>
		/// Retrieve all of the information we know about a particular group of
		/// permissions.
		/// </summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular group of
		/// permissions.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a permission group with the given
		/// name can not be found on the system.
		/// </remarks>
		/// <param name="name">
		/// The fully qualified name (i.e. com.google.permission_group.APPS)
		/// of the permission you are interested in.
		/// </param>
		/// <param name="flags">
		/// Additional option flags.  Use
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// to
		/// retrieve any meta-data associated with the permission group.
		/// </param>
		/// <returns>
		/// Returns a
		/// <see cref="PermissionGroupInfo">PermissionGroupInfo</see>
		/// containing information
		/// about the permission.
		/// </returns>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.PermissionGroupInfo getPermissionGroupInfo(string
			 name, int flags);

		/// <summary>Retrieve all of the known permission groups in the system.</summary>
		/// <remarks>Retrieve all of the known permission groups in the system.</remarks>
		/// <param name="flags">
		/// Additional option flags.  Use
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// to
		/// retrieve any meta-data associated with the permission group.
		/// </param>
		/// <returns>
		/// Returns a list of
		/// <see cref="PermissionGroupInfo">PermissionGroupInfo</see>
		/// containing
		/// information about all of the known permission groups.
		/// </returns>
		public abstract java.util.List<android.content.pm.PermissionGroupInfo> getAllPermissionGroups
			(int flags);

		/// <summary>
		/// Retrieve all of the information we know about a particular
		/// package/application.
		/// </summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular
		/// package/application.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if an application with the given
		/// package name can not be found on the system.
		/// </remarks>
		/// <param name="packageName">
		/// The full name (i.e. com.google.apps.contacts) of an
		/// application.
		/// </param>
		/// <param name="flags">
		/// Additional option flags. Use any combination of
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// ,
		/// <see cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</see>
		/// ,
		/// <see cref="GET_UNINSTALLED_PACKAGES">GET_UNINSTALLED_PACKAGES</see>
		/// to modify the data returned.
		/// </param>
		/// <returns>
		/// 
		/// <see cref="ApplicationInfo">ApplicationInfo</see>
		/// Returns ApplicationInfo object containing
		/// information about the package.
		/// If flag GET_UNINSTALLED_PACKAGES is set and  if the package is not
		/// found in the list of installed applications,
		/// the application information is retrieved from the
		/// list of uninstalled applications(which includes
		/// installed applications as well as applications
		/// with data directory ie applications which had been
		/// deleted with DONT_DELTE_DATA flag set).
		/// </returns>
		/// <seealso cref="GET_META_DATA">GET_META_DATA</seealso>
		/// <seealso cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</seealso>
		/// <seealso cref="GET_UNINSTALLED_PACKAGES">GET_UNINSTALLED_PACKAGES</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.ApplicationInfo getApplicationInfo(string packageName
			, int flags);

		/// <summary>
		/// Retrieve all of the information we know about a particular activity
		/// class.
		/// </summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular activity
		/// class.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if an activity with the given
		/// class name can not be found on the system.
		/// </remarks>
		/// <param name="component">
		/// The full component name (i.e.
		/// com.google.apps.contacts/com.google.apps.contacts.ContactsList) of an Activity
		/// class.
		/// </param>
		/// <param name="flags">
		/// Additional option flags. Use any combination of
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// ,
		/// <see cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</see>
		/// ,
		/// to modify the data (in ApplicationInfo) returned.
		/// </param>
		/// <returns>
		/// 
		/// <see cref="ActivityInfo">ActivityInfo</see>
		/// containing information about the activity.
		/// </returns>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_META_DATA">GET_META_DATA</seealso>
		/// <seealso cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.ActivityInfo getActivityInfo(android.content.ComponentName
			 component, int flags);

		/// <summary>
		/// Retrieve all of the information we know about a particular receiver
		/// class.
		/// </summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular receiver
		/// class.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a receiver with the given
		/// class name can not be found on the system.
		/// </remarks>
		/// <param name="component">
		/// The full component name (i.e.
		/// com.google.apps.calendar/com.google.apps.calendar.CalendarAlarm) of a Receiver
		/// class.
		/// </param>
		/// <param name="flags">
		/// Additional option flags.  Use any combination of
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// ,
		/// <see cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</see>
		/// ,
		/// to modify the data returned.
		/// </param>
		/// <returns>
		/// 
		/// <see cref="ActivityInfo">ActivityInfo</see>
		/// containing information about the receiver.
		/// </returns>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_META_DATA">GET_META_DATA</seealso>
		/// <seealso cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.ActivityInfo getReceiverInfo(android.content.ComponentName
			 component, int flags);

		/// <summary>
		/// Retrieve all of the information we know about a particular service
		/// class.
		/// </summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular service
		/// class.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a service with the given
		/// class name can not be found on the system.
		/// </remarks>
		/// <param name="component">
		/// The full component name (i.e.
		/// com.google.apps.media/com.google.apps.media.BackgroundPlayback) of a Service
		/// class.
		/// </param>
		/// <param name="flags">
		/// Additional option flags.  Use any combination of
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// ,
		/// <see cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</see>
		/// ,
		/// to modify the data returned.
		/// </param>
		/// <returns>ServiceInfo containing information about the service.</returns>
		/// <seealso cref="GET_META_DATA">GET_META_DATA</seealso>
		/// <seealso cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.ServiceInfo getServiceInfo(android.content.ComponentName
			 component, int flags);

		/// <summary>
		/// Retrieve all of the information we know about a particular content
		/// provider class.
		/// </summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular content
		/// provider class.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if a provider with the given
		/// class name can not be found on the system.
		/// </remarks>
		/// <param name="component">
		/// The full component name (i.e.
		/// com.google.providers.media/com.google.providers.media.MediaProvider) of a
		/// ContentProvider class.
		/// </param>
		/// <param name="flags">
		/// Additional option flags.  Use any combination of
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// ,
		/// <see cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</see>
		/// ,
		/// to modify the data returned.
		/// </param>
		/// <returns>ProviderInfo containing information about the service.</returns>
		/// <seealso cref="GET_META_DATA">GET_META_DATA</seealso>
		/// <seealso cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.ProviderInfo getProviderInfo(android.content.ComponentName
			 component, int flags);

		/// <summary>
		/// Return a List of all packages that are installed
		/// on the device.
		/// </summary>
		/// <remarks>
		/// Return a List of all packages that are installed
		/// on the device.
		/// </remarks>
		/// <param name="flags">
		/// Additional option flags. Use any combination of
		/// <see cref="GET_ACTIVITIES">GET_ACTIVITIES</see>
		/// ,
		/// <see cref="GET_GIDS">GET_GIDS</see>
		/// ,
		/// <see cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</see>
		/// ,
		/// <see cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</see>
		/// ,
		/// <see cref="GET_PERMISSIONS">GET_PERMISSIONS</see>
		/// ,
		/// <see cref="GET_PROVIDERS">GET_PROVIDERS</see>
		/// ,
		/// <see cref="GET_RECEIVERS">GET_RECEIVERS</see>
		/// ,
		/// <see cref="GET_SERVICES">GET_SERVICES</see>
		/// ,
		/// <see cref="GET_SIGNATURES">GET_SIGNATURES</see>
		/// ,
		/// <see cref="GET_UNINSTALLED_PACKAGES">GET_UNINSTALLED_PACKAGES</see>
		/// to modify the data returned.
		/// </param>
		/// <returns>
		/// A List of PackageInfo objects, one for each package that is
		/// installed on the device.  In the unlikely case of there being no
		/// installed packages, an empty list is returned.
		/// If flag GET_UNINSTALLED_PACKAGES is set, a list of all
		/// applications including those deleted with DONT_DELETE_DATA
		/// (partially installed apps with data directory) will be returned.
		/// </returns>
		/// <seealso cref="GET_ACTIVITIES">GET_ACTIVITIES</seealso>
		/// <seealso cref="GET_GIDS">GET_GIDS</seealso>
		/// <seealso cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</seealso>
		/// <seealso cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</seealso>
		/// <seealso cref="GET_PERMISSIONS">GET_PERMISSIONS</seealso>
		/// <seealso cref="GET_PROVIDERS">GET_PROVIDERS</seealso>
		/// <seealso cref="GET_RECEIVERS">GET_RECEIVERS</seealso>
		/// <seealso cref="GET_SERVICES">GET_SERVICES</seealso>
		/// <seealso cref="GET_SIGNATURES">GET_SIGNATURES</seealso>
		/// <seealso cref="GET_UNINSTALLED_PACKAGES">GET_UNINSTALLED_PACKAGES</seealso>
		public abstract java.util.List<android.content.pm.PackageInfo> getInstalledPackages
			(int flags);

		/// <summary>
		/// Check whether a particular package has been granted a particular
		/// permission.
		/// </summary>
		/// <remarks>
		/// Check whether a particular package has been granted a particular
		/// permission.
		/// </remarks>
		/// <param name="permName">The name of the permission you are checking for,</param>
		/// <param name="pkgName">The name of the package you are checking against.</param>
		/// <returns>
		/// If the package has the permission, PERMISSION_GRANTED is
		/// returned.  If it does not have the permission, PERMISSION_DENIED
		/// is returned.
		/// </returns>
		/// <seealso cref="PERMISSION_GRANTED">PERMISSION_GRANTED</seealso>
		/// <seealso cref="PERMISSION_DENIED">PERMISSION_DENIED</seealso>
		public abstract int checkPermission(string permName, string pkgName);

		/// <summary>Add a new dynamic permission to the system.</summary>
		/// <remarks>
		/// Add a new dynamic permission to the system.  For this to work, your
		/// package must have defined a permission tree through the
		/// <see cref="android.R.styleable.AndroidManifestPermissionTree">&lt;permission-tree&gt;
		/// 	</see>
		/// tag in its manifest.  A package can only add
		/// permissions to trees that were defined by either its own package or
		/// another with the same user id; a permission is in a tree if it
		/// matches the name of the permission tree + ".": for example,
		/// "com.foo.bar" is a member of the permission tree "com.foo".
		/// <p>It is good to make your permission tree name descriptive, because you
		/// are taking possession of that entire set of permission names.  Thus, it
		/// must be under a domain you control, with a suffix that will not match
		/// any normal permissions that may be declared in any applications that
		/// are part of that domain.
		/// <p>New permissions must be added before
		/// any .apks are installed that use those permissions.  Permissions you
		/// add through this method are remembered across reboots of the device.
		/// If the given permission already exists, the info you supply here
		/// will be used to update it.
		/// </remarks>
		/// <param name="info">Description of the permission to be added.</param>
		/// <returns>
		/// Returns true if a new permission was created, false if an
		/// existing one was updated.
		/// </returns>
		/// <exception cref="System.Security.SecurityException">
		/// if you are not allowed to add the
		/// given permission name.
		/// </exception>
		/// <seealso cref="removePermission(string)">removePermission(string)</seealso>
		public abstract bool addPermission(android.content.pm.PermissionInfo info);

		/// <summary>
		/// Like
		/// <see cref="addPermission(PermissionInfo)">addPermission(PermissionInfo)</see>
		/// but asynchronously
		/// persists the package manager state after returning from the call,
		/// allowing it to return quicker and batch a series of adds at the
		/// expense of no guarantee the added permission will be retained if
		/// the device is rebooted before it is written.
		/// </summary>
		public abstract bool addPermissionAsync(android.content.pm.PermissionInfo info);

		/// <summary>
		/// Removes a permission that was previously added with
		/// <see cref="addPermission(PermissionInfo)">addPermission(PermissionInfo)</see>
		/// .  The same ownership rules apply
		/// -- you are only allowed to remove permissions that you are allowed
		/// to add.
		/// </summary>
		/// <param name="name">The name of the permission to remove.</param>
		/// <exception cref="System.Security.SecurityException">
		/// if you are not allowed to remove the
		/// given permission name.
		/// </exception>
		/// <seealso cref="addPermission(PermissionInfo)">addPermission(PermissionInfo)</seealso>
		public abstract void removePermission(string name);

		/// <summary>
		/// Compare the signatures of two packages to determine if the same
		/// signature appears in both of them.
		/// </summary>
		/// <remarks>
		/// Compare the signatures of two packages to determine if the same
		/// signature appears in both of them.  If they do contain the same
		/// signature, then they are allowed special privileges when working
		/// with each other: they can share the same user-id, run instrumentation
		/// against each other, etc.
		/// </remarks>
		/// <param name="pkg1">First package name whose signature will be compared.</param>
		/// <param name="pkg2">Second package name whose signature will be compared.</param>
		/// <returns>
		/// Returns an integer indicating whether all signatures on the
		/// two packages match. The value is &gt;= 0 (
		/// <see cref="SIGNATURE_MATCH">SIGNATURE_MATCH</see>
		/// ) if
		/// all signatures match or &lt; 0 if there is not a match (
		/// <see cref="SIGNATURE_NO_MATCH">SIGNATURE_NO_MATCH</see>
		/// or
		/// <see cref="SIGNATURE_UNKNOWN_PACKAGE">SIGNATURE_UNKNOWN_PACKAGE</see>
		/// ).
		/// </returns>
		/// <seealso cref="checkSignatures(int, int)">checkSignatures(int, int)</seealso>
		/// <seealso cref="SIGNATURE_MATCH">SIGNATURE_MATCH</seealso>
		/// <seealso cref="SIGNATURE_NO_MATCH">SIGNATURE_NO_MATCH</seealso>
		/// <seealso cref="SIGNATURE_UNKNOWN_PACKAGE">SIGNATURE_UNKNOWN_PACKAGE</seealso>
		public abstract int checkSignatures(string pkg1, string pkg2);

		/// <summary>
		/// Like
		/// <see cref="checkSignatures(string, string)">checkSignatures(string, string)</see>
		/// , but takes UIDs of
		/// the two packages to be checked.  This can be useful, for example,
		/// when doing the check in an IPC, where the UID is the only identity
		/// available.  It is functionally identical to determining the package
		/// associated with the UIDs and checking their signatures.
		/// </summary>
		/// <param name="uid1">First UID whose signature will be compared.</param>
		/// <param name="uid2">Second UID whose signature will be compared.</param>
		/// <returns>
		/// Returns an integer indicating whether all signatures on the
		/// two packages match. The value is &gt;= 0 (
		/// <see cref="SIGNATURE_MATCH">SIGNATURE_MATCH</see>
		/// ) if
		/// all signatures match or &lt; 0 if there is not a match (
		/// <see cref="SIGNATURE_NO_MATCH">SIGNATURE_NO_MATCH</see>
		/// or
		/// <see cref="SIGNATURE_UNKNOWN_PACKAGE">SIGNATURE_UNKNOWN_PACKAGE</see>
		/// ).
		/// </returns>
		/// <seealso cref="checkSignatures(string, string)">checkSignatures(string, string)</seealso>
		/// <seealso cref="SIGNATURE_MATCH">SIGNATURE_MATCH</seealso>
		/// <seealso cref="SIGNATURE_NO_MATCH">SIGNATURE_NO_MATCH</seealso>
		/// <seealso cref="SIGNATURE_UNKNOWN_PACKAGE">SIGNATURE_UNKNOWN_PACKAGE</seealso>
		public abstract int checkSignatures(int uid1, int uid2);

		/// <summary>
		/// Retrieve the names of all packages that are associated with a particular
		/// user id.
		/// </summary>
		/// <remarks>
		/// Retrieve the names of all packages that are associated with a particular
		/// user id.  In most cases, this will be a single package name, the package
		/// that has been assigned that user id.  Where there are multiple packages
		/// sharing the same user id through the "sharedUserId" mechanism, all
		/// packages with that id will be returned.
		/// </remarks>
		/// <param name="uid">
		/// The user id for which you would like to retrieve the
		/// associated packages.
		/// </param>
		/// <returns>
		/// Returns an array of one or more packages assigned to the user
		/// id, or null if there are no known packages with the given id.
		/// </returns>
		public abstract string[] getPackagesForUid(int uid);

		/// <summary>Retrieve the official name associated with a user id.</summary>
		/// <remarks>
		/// Retrieve the official name associated with a user id.  This name is
		/// guaranteed to never change, though it is possibly for the underlying
		/// user id to be changed.  That is, if you are storing information about
		/// user ids in persistent storage, you should use the string returned
		/// by this function instead of the raw user-id.
		/// </remarks>
		/// <param name="uid">The user id for which you would like to retrieve a name.</param>
		/// <returns>
		/// Returns a unique name for the given user id, or null if the
		/// user id is not currently assigned.
		/// </returns>
		public abstract string getNameForUid(int uid);

		/// <summary>Return the user id associated with a shared user name.</summary>
		/// <remarks>
		/// Return the user id associated with a shared user name. Multiple
		/// applications can specify a shared user name in their manifest and thus
		/// end up using a common uid. This might be used for new applications
		/// that use an existing shared user name and need to know the uid of the
		/// shared user.
		/// </remarks>
		/// <param name="sharedUserName">The shared user name whose uid is to be retrieved.</param>
		/// <returns>
		/// Returns the uid associated with the shared user, or  NameNotFoundException
		/// if the shared user name is not being used by any installed packages
		/// </returns>
		/// <hide></hide>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract int getUidForSharedUser(string sharedUserName);

		/// <summary>
		/// Return a List of all application packages that are installed on the
		/// device.
		/// </summary>
		/// <remarks>
		/// Return a List of all application packages that are installed on the
		/// device. If flag GET_UNINSTALLED_PACKAGES has been set, a list of all
		/// applications including those deleted with DONT_DELETE_DATA(partially
		/// installed apps with data directory) will be returned.
		/// </remarks>
		/// <param name="flags">
		/// Additional option flags. Use any combination of
		/// <see cref="GET_META_DATA">GET_META_DATA</see>
		/// ,
		/// <see cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</see>
		/// ,
		/// {link #GET_UNINSTALLED_PACKAGES} to modify the data returned.
		/// </param>
		/// <returns>
		/// A List of ApplicationInfo objects, one for each application that
		/// is installed on the device.  In the unlikely case of there being
		/// no installed applications, an empty list is returned.
		/// If flag GET_UNINSTALLED_PACKAGES is set, a list of all
		/// applications including those deleted with DONT_DELETE_DATA
		/// (partially installed apps with data directory) will be returned.
		/// </returns>
		/// <seealso cref="GET_META_DATA">GET_META_DATA</seealso>
		/// <seealso cref="GET_SHARED_LIBRARY_FILES">GET_SHARED_LIBRARY_FILES</seealso>
		/// <seealso cref="GET_UNINSTALLED_PACKAGES">GET_UNINSTALLED_PACKAGES</seealso>
		public abstract java.util.List<android.content.pm.ApplicationInfo> getInstalledApplications
			(int flags);

		/// <summary>
		/// Get a list of shared libraries that are available on the
		/// system.
		/// </summary>
		/// <remarks>
		/// Get a list of shared libraries that are available on the
		/// system.
		/// </remarks>
		/// <returns>
		/// An array of shared library names that are
		/// available on the system, or null if none are installed.
		/// </returns>
		public abstract string[] getSystemSharedLibraryNames();

		/// <summary>
		/// Get a list of features that are available on the
		/// system.
		/// </summary>
		/// <remarks>
		/// Get a list of features that are available on the
		/// system.
		/// </remarks>
		/// <returns>
		/// An array of FeatureInfo classes describing the features
		/// that are available on the system, or null if there are none(!!).
		/// </returns>
		public abstract android.content.pm.FeatureInfo[] getSystemAvailableFeatures();

		/// <summary>
		/// Check whether the given feature name is one of the available
		/// features as returned by
		/// <see cref="getSystemAvailableFeatures()">getSystemAvailableFeatures()</see>
		/// .
		/// </summary>
		/// <returns>
		/// Returns true if the devices supports the feature, else
		/// false.
		/// </returns>
		public abstract bool hasSystemFeature(string name);

		/// <summary>Determine the best action to perform for a given Intent.</summary>
		/// <remarks>
		/// Determine the best action to perform for a given Intent.  This is how
		/// <see cref="android.content.Intent.resolveActivity(PackageManager)">android.content.Intent.resolveActivity(PackageManager)
		/// 	</see>
		/// finds an activity if a class has not
		/// been explicitly specified.
		/// <p><em>Note:</em> if using an implicit Intent (without an explicit ComponentName
		/// specified), be sure to consider whether to set the
		/// <see cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</see>
		/// only flag.  You need to do so to resolve the activity in the same way
		/// that
		/// <see cref="android.content.Context.startActivity(android.content.Intent)">android.content.Context.startActivity(android.content.Intent)
		/// 	</see>
		/// and
		/// <see cref="android.content.Intent.resolveActivity(PackageManager)">Intent.resolveActivity(PackageManager)
		/// 	</see>
		/// do.</p>
		/// </remarks>
		/// <param name="intent">
		/// An intent containing all of the desired specification
		/// (action, data, type, category, and/or component).
		/// </param>
		/// <param name="flags">
		/// Additional option flags.  The most important is
		/// <see cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</see>
		/// , to limit the resolution to only
		/// those activities that support the
		/// <see cref="android.content.Intent.CATEGORY_DEFAULT">android.content.Intent.CATEGORY_DEFAULT
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns a ResolveInfo containing the final activity intent that
		/// was determined to be the best action.  Returns null if no
		/// matching activity was found. If multiple matching activities are
		/// found and there is no default set, returns a ResolveInfo
		/// containing something else, such as the activity resolver.
		/// </returns>
		/// <seealso cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</seealso>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_RESOLVED_FILTER">GET_RESOLVED_FILTER</seealso>
		public abstract android.content.pm.ResolveInfo resolveActivity(android.content.Intent
			 intent, int flags);

		/// <summary>Retrieve all activities that can be performed for the given intent.</summary>
		/// <remarks>Retrieve all activities that can be performed for the given intent.</remarks>
		/// <param name="intent">The desired intent as per resolveActivity().</param>
		/// <param name="flags">
		/// Additional option flags.  The most important is
		/// <see cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</see>
		/// , to limit the resolution to only
		/// those activities that support the
		/// <see cref="android.content.Intent.CATEGORY_DEFAULT">android.content.Intent.CATEGORY_DEFAULT
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// A List&lt;ResolveInfo&gt; containing one entry for each matching
		/// Activity. These are ordered from best to worst match -- that
		/// is, the first item in the list is what is returned by
		/// <see cref="resolveActivity(android.content.Intent, int)">resolveActivity(android.content.Intent, int)
		/// 	</see>
		/// .  If there are no matching activities, an empty
		/// list is returned.
		/// </returns>
		/// <seealso cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</seealso>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_RESOLVED_FILTER">GET_RESOLVED_FILTER</seealso>
		public abstract java.util.List<android.content.pm.ResolveInfo> queryIntentActivities
			(android.content.Intent intent, int flags);

		/// <summary>
		/// Retrieve a set of activities that should be presented to the user as
		/// similar options.
		/// </summary>
		/// <remarks>
		/// Retrieve a set of activities that should be presented to the user as
		/// similar options.  This is like
		/// <see cref="queryIntentActivities(android.content.Intent, int)">queryIntentActivities(android.content.Intent, int)
		/// 	</see>
		/// , except it
		/// also allows you to supply a list of more explicit Intents that you would
		/// like to resolve to particular options, and takes care of returning the
		/// final ResolveInfo list in a reasonable order, with no duplicates, based
		/// on those inputs.
		/// </remarks>
		/// <param name="caller">
		/// The class name of the activity that is making the
		/// request.  This activity will never appear in the output
		/// list.  Can be null.
		/// </param>
		/// <param name="specifics">
		/// An array of Intents that should be resolved to the
		/// first specific results.  Can be null.
		/// </param>
		/// <param name="intent">The desired intent as per resolveActivity().</param>
		/// <param name="flags">
		/// Additional option flags.  The most important is
		/// <see cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</see>
		/// , to limit the resolution to only
		/// those activities that support the
		/// <see cref="android.content.Intent.CATEGORY_DEFAULT">android.content.Intent.CATEGORY_DEFAULT
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// A List&lt;ResolveInfo&gt; containing one entry for each matching
		/// Activity. These are ordered first by all of the intents resolved
		/// in <var>specifics</var> and then any additional activities that
		/// can handle <var>intent</var> but did not get included by one of
		/// the <var>specifics</var> intents.  If there are no matching
		/// activities, an empty list is returned.
		/// </returns>
		/// <seealso cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</seealso>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_RESOLVED_FILTER">GET_RESOLVED_FILTER</seealso>
		public abstract java.util.List<android.content.pm.ResolveInfo> queryIntentActivityOptions
			(android.content.ComponentName caller, android.content.Intent[] specifics, android.content.Intent
			 intent, int flags);

		/// <summary>Retrieve all receivers that can handle a broadcast of the given intent.</summary>
		/// <remarks>Retrieve all receivers that can handle a broadcast of the given intent.</remarks>
		/// <param name="intent">The desired intent as per resolveActivity().</param>
		/// <param name="flags">Additional option flags.</param>
		/// <returns>
		/// A List&lt;ResolveInfo&gt; containing one entry for each matching
		/// Receiver. These are ordered from first to last in priority.  If
		/// there are no matching receivers, an empty list is returned.
		/// </returns>
		/// <seealso cref="MATCH_DEFAULT_ONLY">MATCH_DEFAULT_ONLY</seealso>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_RESOLVED_FILTER">GET_RESOLVED_FILTER</seealso>
		public abstract java.util.List<android.content.pm.ResolveInfo> queryBroadcastReceivers
			(android.content.Intent intent, int flags);

		/// <summary>Determine the best service to handle for a given Intent.</summary>
		/// <remarks>Determine the best service to handle for a given Intent.</remarks>
		/// <param name="intent">
		/// An intent containing all of the desired specification
		/// (action, data, type, category, and/or component).
		/// </param>
		/// <param name="flags">Additional option flags.</param>
		/// <returns>
		/// Returns a ResolveInfo containing the final service intent that
		/// was determined to be the best action.  Returns null if no
		/// matching service was found.
		/// </returns>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_RESOLVED_FILTER">GET_RESOLVED_FILTER</seealso>
		public abstract android.content.pm.ResolveInfo resolveService(android.content.Intent
			 intent, int flags);

		/// <summary>Retrieve all services that can match the given intent.</summary>
		/// <remarks>Retrieve all services that can match the given intent.</remarks>
		/// <param name="intent">The desired intent as per resolveService().</param>
		/// <param name="flags">Additional option flags.</param>
		/// <returns>
		/// A List&lt;ResolveInfo&gt; containing one entry for each matching
		/// ServiceInfo. These are ordered from best to worst match -- that
		/// is, the first item in the list is what is returned by
		/// resolveService().  If there are no matching services, an empty
		/// list is returned.
		/// </returns>
		/// <seealso cref="GET_INTENT_FILTERS">GET_INTENT_FILTERS</seealso>
		/// <seealso cref="GET_RESOLVED_FILTER">GET_RESOLVED_FILTER</seealso>
		public abstract java.util.List<android.content.pm.ResolveInfo> queryIntentServices
			(android.content.Intent intent, int flags);

		/// <summary>Find a single content provider by its base path name.</summary>
		/// <remarks>Find a single content provider by its base path name.</remarks>
		/// <param name="name">The name of the provider to find.</param>
		/// <param name="flags">Additional option flags.  Currently should always be 0.</param>
		/// <returns>
		/// ContentProviderInfo Information about the provider, if found,
		/// else null.
		/// </returns>
		public abstract android.content.pm.ProviderInfo resolveContentProvider(string name
			, int flags);

		/// <summary>Retrieve content provider information.</summary>
		/// <remarks>
		/// Retrieve content provider information.
		/// <p><em>Note: unlike most other methods, an empty result set is indicated
		/// by a null return instead of an empty list.</em>
		/// </remarks>
		/// <param name="processName">
		/// If non-null, limits the returned providers to only
		/// those that are hosted by the given process.  If null,
		/// all content providers are returned.
		/// </param>
		/// <param name="uid">
		/// If <var>processName</var> is non-null, this is the required
		/// uid owning the requested content providers.
		/// </param>
		/// <param name="flags">Additional option flags.  Currently should always be 0.</param>
		/// <returns>
		/// A List&lt;ContentProviderInfo&gt; containing one entry for each
		/// content provider either patching <var>processName</var> or, if
		/// <var>processName</var> is null, all known content providers.
		/// <em>If there are no matching providers, null is returned.</em>
		/// </returns>
		public abstract java.util.List<android.content.pm.ProviderInfo> queryContentProviders
			(string processName, int uid, int flags);

		/// <summary>
		/// Retrieve all of the information we know about a particular
		/// instrumentation class.
		/// </summary>
		/// <remarks>
		/// Retrieve all of the information we know about a particular
		/// instrumentation class.
		/// <p>Throws
		/// <see cref="NameNotFoundException">NameNotFoundException</see>
		/// if instrumentation with the
		/// given class name can not be found on the system.
		/// </remarks>
		/// <param name="className">
		/// The full name (i.e.
		/// com.google.apps.contacts.InstrumentList) of an
		/// Instrumentation class.
		/// </param>
		/// <param name="flags">Additional option flags.  Currently should always be 0.</param>
		/// <returns>
		/// InstrumentationInfo containing information about the
		/// instrumentation.
		/// </returns>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.pm.InstrumentationInfo getInstrumentationInfo(android.content.ComponentName
			 className, int flags);

		/// <summary>Retrieve information about available instrumentation code.</summary>
		/// <remarks>
		/// Retrieve information about available instrumentation code.  May be used
		/// to retrieve either all instrumentation code, or only the code targeting
		/// a particular package.
		/// </remarks>
		/// <param name="targetPackage">
		/// If null, all instrumentation is returned; only the
		/// instrumentation targeting this package name is
		/// returned.
		/// </param>
		/// <param name="flags">Additional option flags.  Currently should always be 0.</param>
		/// <returns>
		/// A List&lt;InstrumentationInfo&gt; containing one entry for each
		/// matching available Instrumentation.  Returns an empty list if
		/// there is no instrumentation available for the given package.
		/// </returns>
		public abstract java.util.List<android.content.pm.InstrumentationInfo> queryInstrumentation
			(string targetPackage, int flags);

		/// <summary>Retrieve an image from a package.</summary>
		/// <remarks>
		/// Retrieve an image from a package.  This is a low-level API used by
		/// the various package manager info structures (such as
		/// <see cref="ComponentInfo">ComponentInfo</see>
		/// to implement retrieval of their associated
		/// icon.
		/// </remarks>
		/// <param name="packageName">
		/// The name of the package that this icon is coming from.
		/// Can not be null.
		/// </param>
		/// <param name="resid">The resource identifier of the desired image.  Can not be 0.</param>
		/// <param name="appInfo">
		/// Overall information about <var>packageName</var>.  This
		/// may be null, in which case the application information will be retrieved
		/// for you if needed; if you already have this information around, it can
		/// be much more efficient to supply it here.
		/// </param>
		/// <returns>
		/// Returns a Drawable holding the requested image.  Returns null if
		/// an image could not be found for any reason.
		/// </returns>
		public abstract android.graphics.drawable.Drawable getDrawable(string packageName
			, int resid, android.content.pm.ApplicationInfo appInfo);

		/// <summary>Retrieve the icon associated with an activity.</summary>
		/// <remarks>
		/// Retrieve the icon associated with an activity.  Given the full name of
		/// an activity, retrieves the information about it and calls
		/// <see cref="PackageItemInfo.loadIcon(PackageManager)">ComponentInfo.loadIcon()</see>
		/// to return its icon.
		/// If the activity can not be found, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="activityName">Name of the activity whose icon is to be retrieved.</param>
		/// <returns>
		/// Returns the image of the icon, or the default activity icon if
		/// it could not be found.  Does not return null.
		/// </returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for the given
		/// activity could not be loaded.
		/// </exception>
		/// <seealso cref="getActivityIcon(android.content.Intent)">getActivityIcon(android.content.Intent)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.graphics.drawable.Drawable getActivityIcon(android.content.ComponentName
			 activityName);

		/// <summary>Retrieve the icon associated with an Intent.</summary>
		/// <remarks>
		/// Retrieve the icon associated with an Intent.  If intent.getClassName() is
		/// set, this simply returns the result of
		/// getActivityIcon(intent.getClassName()).  Otherwise it resolves the intent's
		/// component and returns the icon associated with the resolved component.
		/// If intent.getClassName() can not be found or the Intent can not be resolved
		/// to a component, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="intent">The intent for which you would like to retrieve an icon.</param>
		/// <returns>
		/// Returns the image of the icon, or the default activity icon if
		/// it could not be found.  Does not return null.
		/// </returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for application
		/// matching the given intent could not be loaded.
		/// </exception>
		/// <seealso cref="getActivityIcon(android.content.ComponentName)">getActivityIcon(android.content.ComponentName)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.graphics.drawable.Drawable getActivityIcon(android.content.Intent
			 intent);

		/// <summary>
		/// Return the generic icon for an activity that is used when no specific
		/// icon is defined.
		/// </summary>
		/// <remarks>
		/// Return the generic icon for an activity that is used when no specific
		/// icon is defined.
		/// </remarks>
		/// <returns>Drawable Image of the icon.</returns>
		public abstract android.graphics.drawable.Drawable getDefaultActivityIcon();

		/// <summary>Retrieve the icon associated with an application.</summary>
		/// <remarks>
		/// Retrieve the icon associated with an application.  If it has not defined
		/// an icon, the default app icon is returned.  Does not return null.
		/// </remarks>
		/// <param name="info">Information about application being queried.</param>
		/// <returns>
		/// Returns the image of the icon, or the default application icon
		/// if it could not be found.
		/// </returns>
		/// <seealso cref="getApplicationIcon(string)">getApplicationIcon(string)</seealso>
		public abstract android.graphics.drawable.Drawable getApplicationIcon(android.content.pm.ApplicationInfo
			 info);

		/// <summary>Retrieve the icon associated with an application.</summary>
		/// <remarks>
		/// Retrieve the icon associated with an application.  Given the name of the
		/// application's package, retrieves the information about it and calls
		/// getApplicationIcon() to return its icon. If the application can not be
		/// found, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="packageName">
		/// Name of the package whose application icon is to be
		/// retrieved.
		/// </param>
		/// <returns>
		/// Returns the image of the icon, or the default application icon
		/// if it could not be found.  Does not return null.
		/// </returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for the given
		/// application could not be loaded.
		/// </exception>
		/// <seealso cref="getApplicationIcon(ApplicationInfo)">getApplicationIcon(ApplicationInfo)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.graphics.drawable.Drawable getApplicationIcon(string packageName
			);

		/// <summary>Retrieve the logo associated with an activity.</summary>
		/// <remarks>
		/// Retrieve the logo associated with an activity.  Given the full name of
		/// an activity, retrieves the information about it and calls
		/// <see cref="PackageItemInfo.loadLogo(PackageManager)">ComponentInfo.loadLogo()</see>
		/// to return its logo.
		/// If the activity can not be found, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="activityName">Name of the activity whose logo is to be retrieved.</param>
		/// <returns>
		/// Returns the image of the logo or null if the activity has no
		/// logo specified.
		/// </returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for the given
		/// activity could not be loaded.
		/// </exception>
		/// <seealso cref="getActivityLogo(android.content.Intent)">getActivityLogo(android.content.Intent)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.graphics.drawable.Drawable getActivityLogo(android.content.ComponentName
			 activityName);

		/// <summary>Retrieve the logo associated with an Intent.</summary>
		/// <remarks>
		/// Retrieve the logo associated with an Intent.  If intent.getClassName() is
		/// set, this simply returns the result of
		/// getActivityLogo(intent.getClassName()).  Otherwise it resolves the intent's
		/// component and returns the logo associated with the resolved component.
		/// If intent.getClassName() can not be found or the Intent can not be resolved
		/// to a component, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="intent">The intent for which you would like to retrieve a logo.</param>
		/// <returns>
		/// Returns the image of the logo, or null if the activity has no
		/// logo specified.
		/// </returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for application
		/// matching the given intent could not be loaded.
		/// </exception>
		/// <seealso cref="getActivityLogo(android.content.ComponentName)">getActivityLogo(android.content.ComponentName)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.graphics.drawable.Drawable getActivityLogo(android.content.Intent
			 intent);

		/// <summary>Retrieve the logo associated with an application.</summary>
		/// <remarks>
		/// Retrieve the logo associated with an application.  If it has not specified
		/// a logo, this method returns null.
		/// </remarks>
		/// <param name="info">Information about application being queried.</param>
		/// <returns>
		/// Returns the image of the logo, or null if no logo is specified
		/// by the application.
		/// </returns>
		/// <seealso cref="getApplicationLogo(string)">getApplicationLogo(string)</seealso>
		public abstract android.graphics.drawable.Drawable getApplicationLogo(android.content.pm.ApplicationInfo
			 info);

		/// <summary>Retrieve the logo associated with an application.</summary>
		/// <remarks>
		/// Retrieve the logo associated with an application.  Given the name of the
		/// application's package, retrieves the information about it and calls
		/// getApplicationLogo() to return its logo. If the application can not be
		/// found, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="packageName">
		/// Name of the package whose application logo is to be
		/// retrieved.
		/// </param>
		/// <returns>
		/// Returns the image of the logo, or null if no application logo
		/// has been specified.
		/// </returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for the given
		/// application could not be loaded.
		/// </exception>
		/// <seealso cref="getApplicationLogo(ApplicationInfo)">getApplicationLogo(ApplicationInfo)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.graphics.drawable.Drawable getApplicationLogo(string packageName
			);

		/// <summary>Retrieve text from a package.</summary>
		/// <remarks>
		/// Retrieve text from a package.  This is a low-level API used by
		/// the various package manager info structures (such as
		/// <see cref="ComponentInfo">ComponentInfo</see>
		/// to implement retrieval of their associated
		/// labels and other text.
		/// </remarks>
		/// <param name="packageName">
		/// The name of the package that this text is coming from.
		/// Can not be null.
		/// </param>
		/// <param name="resid">The resource identifier of the desired text.  Can not be 0.</param>
		/// <param name="appInfo">
		/// Overall information about <var>packageName</var>.  This
		/// may be null, in which case the application information will be retrieved
		/// for you if needed; if you already have this information around, it can
		/// be much more efficient to supply it here.
		/// </param>
		/// <returns>
		/// Returns a CharSequence holding the requested text.  Returns null
		/// if the text could not be found for any reason.
		/// </returns>
		public abstract java.lang.CharSequence getText(string packageName, int resid, android.content.pm.ApplicationInfo
			 appInfo);

		/// <summary>Retrieve an XML file from a package.</summary>
		/// <remarks>
		/// Retrieve an XML file from a package.  This is a low-level API used to
		/// retrieve XML meta data.
		/// </remarks>
		/// <param name="packageName">
		/// The name of the package that this xml is coming from.
		/// Can not be null.
		/// </param>
		/// <param name="resid">The resource identifier of the desired xml.  Can not be 0.</param>
		/// <param name="appInfo">
		/// Overall information about <var>packageName</var>.  This
		/// may be null, in which case the application information will be retrieved
		/// for you if needed; if you already have this information around, it can
		/// be much more efficient to supply it here.
		/// </param>
		/// <returns>
		/// Returns an XmlPullParser allowing you to parse out the XML
		/// data.  Returns null if the xml resource could not be found for any
		/// reason.
		/// </returns>
		public abstract android.content.res.XmlResourceParser getXml(string packageName, 
			int resid, android.content.pm.ApplicationInfo appInfo);

		/// <summary>Return the label to use for this application.</summary>
		/// <remarks>Return the label to use for this application.</remarks>
		/// <returns>
		/// Returns the label associated with this application, or null if
		/// it could not be found for any reason.
		/// </returns>
		/// <param name="info">The application to get the label of</param>
		public abstract java.lang.CharSequence getApplicationLabel(android.content.pm.ApplicationInfo
			 info);

		/// <summary>Retrieve the resources associated with an activity.</summary>
		/// <remarks>
		/// Retrieve the resources associated with an activity.  Given the full
		/// name of an activity, retrieves the information about it and calls
		/// getResources() to return its application's resources.  If the activity
		/// can not be found, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="activityName">
		/// Name of the activity whose resources are to be
		/// retrieved.
		/// </param>
		/// <returns>Returns the application's Resources.</returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for the given
		/// application could not be loaded.
		/// </exception>
		/// <seealso cref="getResourcesForApplication(ApplicationInfo)">getResourcesForApplication(ApplicationInfo)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.res.Resources getResourcesForActivity(android.content.ComponentName
			 activityName);

		/// <summary>Retrieve the resources for an application.</summary>
		/// <remarks>
		/// Retrieve the resources for an application.  Throws NameNotFoundException
		/// if the package is no longer installed.
		/// </remarks>
		/// <param name="app">Information about the desired application.</param>
		/// <returns>Returns the application's Resources.</returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for the given
		/// application could not be loaded (most likely because it was uninstalled).
		/// </exception>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.res.Resources getResourcesForApplication(android.content.pm.ApplicationInfo
			 app);

		/// <summary>Retrieve the resources associated with an application.</summary>
		/// <remarks>
		/// Retrieve the resources associated with an application.  Given the full
		/// package name of an application, retrieves the information about it and
		/// calls getResources() to return its application's resources.  If the
		/// appPackageName can not be found, NameNotFoundException is thrown.
		/// </remarks>
		/// <param name="appPackageName">
		/// Package name of the application whose resources
		/// are to be retrieved.
		/// </param>
		/// <returns>Returns the application's Resources.</returns>
		/// <exception cref="NameNotFoundException">
		/// Thrown if the resources for the given
		/// application could not be loaded.
		/// </exception>
		/// <seealso cref="getResourcesForApplication(ApplicationInfo)">getResourcesForApplication(ApplicationInfo)
		/// 	</seealso>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		public abstract android.content.res.Resources getResourcesForApplication(string appPackageName
			);

		/// <summary>
		/// Retrieve overall information about an application package defined
		/// in a package archive file
		/// </summary>
		/// <param name="archiveFilePath">The path to the archive file</param>
		/// <param name="flags">
		/// Additional option flags. Use any combination of
		/// <see cref="GET_ACTIVITIES">GET_ACTIVITIES</see>
		/// ,
		/// <see cref="GET_GIDS">GET_GIDS</see>
		/// ,
		/// <see cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</see>
		/// ,
		/// <see cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</see>
		/// ,
		/// <see cref="GET_PERMISSIONS">GET_PERMISSIONS</see>
		/// ,
		/// <see cref="GET_PROVIDERS">GET_PROVIDERS</see>
		/// ,
		/// <see cref="GET_RECEIVERS">GET_RECEIVERS</see>
		/// ,
		/// <see cref="GET_SERVICES">GET_SERVICES</see>
		/// ,
		/// <see cref="GET_SIGNATURES">GET_SIGNATURES</see>
		/// , to modify the data returned.
		/// </param>
		/// <returns>
		/// Returns the information about the package. Returns
		/// null if the package could not be successfully parsed.
		/// </returns>
		/// <seealso cref="GET_ACTIVITIES">GET_ACTIVITIES</seealso>
		/// <seealso cref="GET_GIDS">GET_GIDS</seealso>
		/// <seealso cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</seealso>
		/// <seealso cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</seealso>
		/// <seealso cref="GET_PERMISSIONS">GET_PERMISSIONS</seealso>
		/// <seealso cref="GET_PROVIDERS">GET_PROVIDERS</seealso>
		/// <seealso cref="GET_RECEIVERS">GET_RECEIVERS</seealso>
		/// <seealso cref="GET_SERVICES">GET_SERVICES</seealso>
		/// <seealso cref="GET_SIGNATURES">GET_SIGNATURES</seealso>
		public virtual android.content.pm.PackageInfo getPackageArchiveInfo(string archiveFilePath
			, int flags)
		{
			android.content.pm.PackageParser packageParser = new android.content.pm.PackageParser
				(archiveFilePath);
			android.util.DisplayMetrics metrics = new android.util.DisplayMetrics();
			metrics.setToDefaults();
			java.io.File sourceFile = new java.io.File(archiveFilePath);
			android.content.pm.PackageParser.Package pkg = packageParser.parsePackage(sourceFile
				, archiveFilePath, metrics, 0);
			if (pkg == null)
			{
				return null;
			}
			if ((flags & GET_SIGNATURES) != 0)
			{
				packageParser.collectCertificates(pkg, 0);
			}
			return android.content.pm.PackageParser.generatePackageInfo(pkg, null, flags, 0, 
				0);
		}

		/// <hide>
		/// Install a package. Since this may take a little while, the result will
		/// be posted back to the given observer.  An installation will fail if the calling context
		/// lacks the
		/// <see cref="android.Manifest.permission.INSTALL_PACKAGES">android.Manifest.permission.INSTALL_PACKAGES
		/// 	</see>
		/// permission, if the
		/// package named in the package file's manifest is already installed, or if there's no space
		/// available on the device.
		/// </hide>
		/// <param name="packageURI">
		/// The location of the package file to install.  This can be a 'file:' or a
		/// 'content:' URI.
		/// </param>
		/// <param name="observer">
		/// An observer callback to get notified when the package installation is
		/// complete.
		/// <see cref="IPackageInstallObserver.packageInstalled(string, int)">IPackageInstallObserver.packageInstalled(string, int)
		/// 	</see>
		/// will be
		/// called when that happens.  observer may be null to indicate that no callback is desired.
		/// </param>
		/// <param name="flags">
		/// - possible values:
		/// <see cref="INSTALL_FORWARD_LOCK">INSTALL_FORWARD_LOCK</see>
		/// ,
		/// <see cref="INSTALL_REPLACE_EXISTING">INSTALL_REPLACE_EXISTING</see>
		/// ,
		/// <see cref="INSTALL_ALLOW_TEST">INSTALL_ALLOW_TEST</see>
		/// .
		/// </param>
		/// <param name="installerPackageName">
		/// Optional package name of the application that is performing the
		/// installation. This identifies which market the package came from.
		/// </param>
		public abstract void installPackage(System.Uri packageURI, android.content.pm.IPackageInstallObserver
			 observer, int flags, string installerPackageName);

		/// <summary>
		/// Similar to
		/// <see cref="installPackage(System.Uri, IPackageInstallObserver, int, string)">installPackage(System.Uri, IPackageInstallObserver, int, string)
		/// 	</see>
		/// but
		/// with an extra verification file provided.
		/// </summary>
		/// <param name="packageURI">
		/// The location of the package file to install. This can
		/// be a 'file:' or a 'content:' URI.
		/// </param>
		/// <param name="observer">
		/// An observer callback to get notified when the package
		/// installation is complete.
		/// <see cref="IPackageInstallObserver.packageInstalled(string, int)">IPackageInstallObserver.packageInstalled(string, int)
		/// 	</see>
		/// will be called when that happens. observer may be null to
		/// indicate that no callback is desired.
		/// </param>
		/// <param name="flags">
		/// - possible values:
		/// <see cref="INSTALL_FORWARD_LOCK">INSTALL_FORWARD_LOCK</see>
		/// ,
		/// <see cref="INSTALL_REPLACE_EXISTING">INSTALL_REPLACE_EXISTING</see>
		/// ,
		/// <see cref="INSTALL_ALLOW_TEST">INSTALL_ALLOW_TEST</see>
		/// .
		/// </param>
		/// <param name="installerPackageName">
		/// Optional package name of the application that
		/// is performing the installation. This identifies which market
		/// the package came from.
		/// </param>
		/// <param name="verificationURI">
		/// The location of the supplementary verification
		/// file. This can be a 'file:' or a 'content:' URI.
		/// </param>
		/// <hide></hide>
		public abstract void installPackageWithVerification(System.Uri packageURI, android.content.pm.IPackageInstallObserver
			 observer, int flags, string installerPackageName, System.Uri verificationURI, android.content.pm.ManifestDigest
			 manifestDigest);

		/// <summary>
		/// Allows a package listening to the
		/// <see cref="android.content.Intent.ACTION_PACKAGE_NEEDS_VERIFICATION">
		/// package verification
		/// broadcast
		/// </see>
		/// to respond to the package manager. The response must include
		/// the
		/// <code>verificationCode</code>
		/// which is one of
		/// <see cref="VERIFICATION_ALLOW">VERIFICATION_ALLOW</see>
		/// or
		/// <see cref="VERIFICATION_REJECT">VERIFICATION_REJECT</see>
		/// .
		/// </summary>
		/// <param name="id">
		/// pending package identifier as passed via the
		/// <see cref="EXTRA_VERIFICATION_ID">EXTRA_VERIFICATION_ID</see>
		/// Intent extra
		/// </param>
		/// <param name="verificationCode">
		/// either
		/// <see cref="VERIFICATION_ALLOW">VERIFICATION_ALLOW</see>
		/// or
		/// <see cref="VERIFICATION_REJECT">VERIFICATION_REJECT</see>
		/// .
		/// </param>
		public abstract void verifyPendingInstall(int id, int verificationCode);

		/// <summary>Change the installer associated with a given package.</summary>
		/// <remarks>
		/// Change the installer associated with a given package.  There are limitations
		/// on how the installer package can be changed; in particular:
		/// <ul>
		/// <li> A SecurityException will be thrown if <var>installerPackageName</var>
		/// is not signed with the same certificate as the calling application.
		/// <li> A SecurityException will be thrown if <var>targetPackage</var> already
		/// has an installer package, and that installer package is not signed with
		/// the same certificate as the calling application.
		/// </ul>
		/// </remarks>
		/// <param name="targetPackage">The installed package whose installer will be changed.
		/// 	</param>
		/// <param name="installerPackageName">
		/// The package name of the new installer.  May be
		/// null to clear the association.
		/// </param>
		public abstract void setInstallerPackageName(string targetPackage, string installerPackageName
			);

		/// <summary>Attempts to delete a package.</summary>
		/// <remarks>
		/// Attempts to delete a package.  Since this may take a little while, the result will
		/// be posted back to the given observer.  A deletion will fail if the calling context
		/// lacks the
		/// <see cref="android.Manifest.permission.DELETE_PACKAGES">android.Manifest.permission.DELETE_PACKAGES
		/// 	</see>
		/// permission, if the
		/// named package cannot be found, or if the named package is a "system package".
		/// (TODO: include pointer to documentation on "system packages")
		/// </remarks>
		/// <param name="packageName">The name of the package to delete</param>
		/// <param name="observer">
		/// An observer callback to get notified when the package deletion is
		/// complete.
		/// <see cref="IPackageDeleteObserver.packageDeleted(string, int)">IPackageDeleteObserver.packageDeleted(string, int)
		/// 	</see>
		/// will be
		/// called when that happens.  observer may be null to indicate that no callback is desired.
		/// </param>
		/// <param name="flags">
		/// - possible values:
		/// <see cref="DONT_DELETE_DATA">DONT_DELETE_DATA</see>
		/// </param>
		/// <hide></hide>
		public abstract void deletePackage(string packageName, android.content.pm.IPackageDeleteObserver
			 observer, int flags);

		/// <summary>Retrieve the package name of the application that installed a package.</summary>
		/// <remarks>
		/// Retrieve the package name of the application that installed a package. This identifies
		/// which market the package came from.
		/// </remarks>
		/// <param name="packageName">The name of the package to query</param>
		public abstract string getInstallerPackageName(string packageName);

		/// <summary>Attempts to clear the user data directory of an application.</summary>
		/// <remarks>
		/// Attempts to clear the user data directory of an application.
		/// Since this may take a little while, the result will
		/// be posted back to the given observer.  A deletion will fail if the
		/// named package cannot be found, or if the named package is a "system package".
		/// </remarks>
		/// <param name="packageName">The name of the package</param>
		/// <param name="observer">
		/// An observer callback to get notified when the operation is finished
		/// <see cref="IPackageDataObserver.onRemoveCompleted(string, bool)">IPackageDataObserver.onRemoveCompleted(string, bool)
		/// 	</see>
		/// will be called when that happens.  observer may be null to indicate that
		/// no callback is desired.
		/// </param>
		/// <hide></hide>
		public abstract void clearApplicationUserData(string packageName, android.content.pm.IPackageDataObserver
			 observer);

		/// <summary>Attempts to delete the cache files associated with an application.</summary>
		/// <remarks>
		/// Attempts to delete the cache files associated with an application.
		/// Since this may take a little while, the result will
		/// be posted back to the given observer.  A deletion will fail if the calling context
		/// lacks the
		/// <see cref="android.Manifest.permission.DELETE_CACHE_FILES">android.Manifest.permission.DELETE_CACHE_FILES
		/// 	</see>
		/// permission, if the
		/// named package cannot be found, or if the named package is a "system package".
		/// </remarks>
		/// <param name="packageName">The name of the package to delete</param>
		/// <param name="observer">
		/// An observer callback to get notified when the cache file deletion
		/// is complete.
		/// <see cref="IPackageDataObserver.onRemoveCompleted(string, bool)">IPackageDataObserver.onRemoveCompleted(string, bool)
		/// 	</see>
		/// will be called when that happens.  observer may be null to indicate that
		/// no callback is desired.
		/// </param>
		/// <hide></hide>
		public abstract void deleteApplicationCacheFiles(string packageName, android.content.pm.IPackageDataObserver
			 observer);

		/// <summary>
		/// Free storage by deleting LRU sorted list of cache files across
		/// all applications.
		/// </summary>
		/// <remarks>
		/// Free storage by deleting LRU sorted list of cache files across
		/// all applications. If the currently available free storage
		/// on the device is greater than or equal to the requested
		/// free storage, no cache files are cleared. If the currently
		/// available storage on the device is less than the requested
		/// free storage, some or all of the cache files across
		/// all applications are deleted (based on last accessed time)
		/// to increase the free storage space on the device to
		/// the requested value. There is no guarantee that clearing all
		/// the cache files from all applications will clear up
		/// enough storage to achieve the desired value.
		/// </remarks>
		/// <param name="freeStorageSize">
		/// The number of bytes of storage to be
		/// freed by the system. Say if freeStorageSize is XX,
		/// and the current free storage is YY,
		/// if XX is less than YY, just return. if not free XX-YY number
		/// of bytes if possible.
		/// </param>
		/// <param name="observer">
		/// call back used to notify when
		/// the operation is completed
		/// </param>
		/// <hide></hide>
		public abstract void freeStorageAndNotify(long freeStorageSize, android.content.pm.IPackageDataObserver
			 observer);

		/// <summary>
		/// Free storage by deleting LRU sorted list of cache files across
		/// all applications.
		/// </summary>
		/// <remarks>
		/// Free storage by deleting LRU sorted list of cache files across
		/// all applications. If the currently available free storage
		/// on the device is greater than or equal to the requested
		/// free storage, no cache files are cleared. If the currently
		/// available storage on the device is less than the requested
		/// free storage, some or all of the cache files across
		/// all applications are deleted (based on last accessed time)
		/// to increase the free storage space on the device to
		/// the requested value. There is no guarantee that clearing all
		/// the cache files from all applications will clear up
		/// enough storage to achieve the desired value.
		/// </remarks>
		/// <param name="freeStorageSize">
		/// The number of bytes of storage to be
		/// freed by the system. Say if freeStorageSize is XX,
		/// and the current free storage is YY,
		/// if XX is less than YY, just return. if not free XX-YY number
		/// of bytes if possible.
		/// </param>
		/// <param name="pi">
		/// IntentSender call back used to
		/// notify when the operation is completed.May be null
		/// to indicate that no call back is desired.
		/// </param>
		/// <hide></hide>
		public abstract void freeStorage(long freeStorageSize, android.content.IntentSender
			 pi);

		/// <summary>Retrieve the size information for a package.</summary>
		/// <remarks>
		/// Retrieve the size information for a package.
		/// Since this may take a little while, the result will
		/// be posted back to the given observer.  The calling context
		/// should have the
		/// <see cref="android.Manifest.permission.GET_PACKAGE_SIZE">android.Manifest.permission.GET_PACKAGE_SIZE
		/// 	</see>
		/// permission.
		/// </remarks>
		/// <param name="packageName">The name of the package whose size information is to be retrieved
		/// 	</param>
		/// <param name="observer">
		/// An observer callback to get notified when the operation
		/// is complete.
		/// <see cref="IPackageStatsObserver.onGetStatsCompleted(PackageStats, bool)">IPackageStatsObserver.onGetStatsCompleted(PackageStats, bool)
		/// 	</see>
		/// The observer's callback is invoked with a PackageStats object(containing the
		/// code, data and cache sizes of the package) and a boolean value representing
		/// the status of the operation. observer may be null to indicate that
		/// no callback is desired.
		/// </param>
		/// <hide></hide>
		public abstract void getPackageSizeInfo(string packageName, android.content.pm.IPackageStatsObserver
			 observer);

		[System.ObsoleteAttribute(@"This function no longer does anything; it was an old approach to managing preferred activities, which has been superceeded (and conflicts with) the modern activity-based preferences."
			)]
		public abstract void addPackageToPreferred(string packageName);

		[System.ObsoleteAttribute(@"This function no longer does anything; it was an old approach to managing preferred activities, which has been superceeded (and conflicts with) the modern activity-based preferences."
			)]
		public abstract void removePackageFromPreferred(string packageName);

		/// <summary>Retrieve the list of all currently configured preferred packages.</summary>
		/// <remarks>
		/// Retrieve the list of all currently configured preferred packages.  The
		/// first package on the list is the most preferred, the last is the
		/// least preferred.
		/// </remarks>
		/// <param name="flags">
		/// Additional option flags. Use any combination of
		/// <see cref="GET_ACTIVITIES">GET_ACTIVITIES</see>
		/// ,
		/// <see cref="GET_GIDS">GET_GIDS</see>
		/// ,
		/// <see cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</see>
		/// ,
		/// <see cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</see>
		/// ,
		/// <see cref="GET_PERMISSIONS">GET_PERMISSIONS</see>
		/// ,
		/// <see cref="GET_PROVIDERS">GET_PROVIDERS</see>
		/// ,
		/// <see cref="GET_RECEIVERS">GET_RECEIVERS</see>
		/// ,
		/// <see cref="GET_SERVICES">GET_SERVICES</see>
		/// ,
		/// <see cref="GET_SIGNATURES">GET_SIGNATURES</see>
		/// , to modify the data returned.
		/// </param>
		/// <returns>
		/// Returns a list of PackageInfo objects describing each
		/// preferred application, in order of preference.
		/// </returns>
		/// <seealso cref="GET_ACTIVITIES">GET_ACTIVITIES</seealso>
		/// <seealso cref="GET_GIDS">GET_GIDS</seealso>
		/// <seealso cref="GET_CONFIGURATIONS">GET_CONFIGURATIONS</seealso>
		/// <seealso cref="GET_INSTRUMENTATION">GET_INSTRUMENTATION</seealso>
		/// <seealso cref="GET_PERMISSIONS">GET_PERMISSIONS</seealso>
		/// <seealso cref="GET_PROVIDERS">GET_PROVIDERS</seealso>
		/// <seealso cref="GET_RECEIVERS">GET_RECEIVERS</seealso>
		/// <seealso cref="GET_SERVICES">GET_SERVICES</seealso>
		/// <seealso cref="GET_SIGNATURES">GET_SIGNATURES</seealso>
		public abstract java.util.List<android.content.pm.PackageInfo> getPreferredPackages
			(int flags);

		/// <param name="filter">
		/// The set of intents under which this activity will be
		/// made preferred.
		/// </param>
		/// <param name="match">
		/// The IntentFilter match category that this preference
		/// applies to.
		/// </param>
		/// <param name="set">
		/// The set of activities that the user was picking from when
		/// this preference was made.
		/// </param>
		/// <param name="activity">
		/// The component name of the activity that is to be
		/// preferred.
		/// </param>
		[System.ObsoleteAttribute(@"This is a protected API that should not have been available to third party applications.  It is the platform's responsibility for assigning preferred activities and this can not be directly modified. Add a new preferred activity mapping to the system.  This will be used to automatically select the given activity component whenandroid.content.Context.startActivity(android.content.Intent) Context.startActivity() finds multiple matching activities and also matches the given filter."
			)]
		public abstract void addPreferredActivity(android.content.IntentFilter filter, int
			 match, android.content.ComponentName[] set, android.content.ComponentName activity
			);

		/// <param name="filter">
		/// The set of intents under which this activity will be
		/// made preferred.
		/// </param>
		/// <param name="match">
		/// The IntentFilter match category that this preference
		/// applies to.
		/// </param>
		/// <param name="set">
		/// The set of activities that the user was picking from when
		/// this preference was made.
		/// </param>
		/// <param name="activity">
		/// The component name of the activity that is to be
		/// preferred.
		/// </param>
		/// <hide></hide>
		[System.ObsoleteAttribute(@"This is a protected API that should not have been available to third party applications.  It is the platform's responsibility for assigning preferred activities and this can not be directly modified. Replaces an existing preferred activity mapping to the system, and if that were not present adds a new preferred activity.  This will be used to automatically select the given activity component whenandroid.content.Context.startActivity(android.content.Intent) Context.startActivity() finds multiple matching activities and also matches the given filter."
			)]
		public abstract void replacePreferredActivity(android.content.IntentFilter filter
			, int match, android.content.ComponentName[] set, android.content.ComponentName 
			activity);

		/// <summary>
		/// Remove all preferred activity mappings, previously added with
		/// <see cref="addPreferredActivity(android.content.IntentFilter, int, android.content.ComponentName[], android.content.ComponentName)
		/// 	">addPreferredActivity(android.content.IntentFilter, int, android.content.ComponentName[], android.content.ComponentName)
		/// 	</see>
		/// , from the
		/// system whose activities are implemented in the given package name.
		/// An application can only clear its own package(s).
		/// </summary>
		/// <param name="packageName">
		/// The name of the package whose preferred activity
		/// mappings are to be removed.
		/// </param>
		public abstract void clearPackagePreferredActivities(string packageName);

		/// <summary>
		/// Retrieve all preferred activities, previously added with
		/// <see cref="addPreferredActivity(android.content.IntentFilter, int, android.content.ComponentName[], android.content.ComponentName)
		/// 	">addPreferredActivity(android.content.IntentFilter, int, android.content.ComponentName[], android.content.ComponentName)
		/// 	</see>
		/// , that are
		/// currently registered with the system.
		/// </summary>
		/// <param name="outFilters">
		/// A list in which to place the filters of all of the
		/// preferred activities, or null for none.
		/// </param>
		/// <param name="outActivities">
		/// A list in which to place the component names of
		/// all of the preferred activities, or null for none.
		/// </param>
		/// <param name="packageName">
		/// An option package in which you would like to limit
		/// the list.  If null, all activities will be returned; if non-null, only
		/// those activities in the given package are returned.
		/// </param>
		/// <returns>
		/// Returns the total number of registered preferred activities
		/// (the number of distinct IntentFilter records, not the number of unique
		/// activity components) that were found.
		/// </returns>
		public abstract int getPreferredActivities(java.util.List<android.content.IntentFilter
			> outFilters, java.util.List<android.content.ComponentName> outActivities, string
			 packageName);

		/// <summary>Set the enabled setting for a package component (activity, receiver, service, provider).
		/// 	</summary>
		/// <remarks>
		/// Set the enabled setting for a package component (activity, receiver, service, provider).
		/// This setting will override any enabled state which may have been set by the component in its
		/// manifest.
		/// </remarks>
		/// <param name="componentName">The component to enable</param>
		/// <param name="newState">
		/// The new enabled state for the component.  The legal values for this state
		/// are:
		/// <see cref="COMPONENT_ENABLED_STATE_ENABLED">COMPONENT_ENABLED_STATE_ENABLED</see>
		/// ,
		/// <see cref="COMPONENT_ENABLED_STATE_DISABLED">COMPONENT_ENABLED_STATE_DISABLED</see>
		/// and
		/// <see cref="COMPONENT_ENABLED_STATE_DEFAULT">COMPONENT_ENABLED_STATE_DEFAULT</see>
		/// The last one removes the setting, thereby restoring the component's state to
		/// whatever was set in it's manifest (or enabled, by default).
		/// </param>
		/// <param name="flags">
		/// Optional behavior flags:
		/// <see cref="DONT_KILL_APP">DONT_KILL_APP</see>
		/// or 0.
		/// </param>
		public abstract void setComponentEnabledSetting(android.content.ComponentName componentName
			, int newState, int flags);

		/// <summary>
		/// Return the the enabled setting for a package component (activity,
		/// receiver, service, provider).
		/// </summary>
		/// <remarks>
		/// Return the the enabled setting for a package component (activity,
		/// receiver, service, provider).  This returns the last value set by
		/// <see cref="setComponentEnabledSetting(android.content.ComponentName, int, int)">setComponentEnabledSetting(android.content.ComponentName, int, int)
		/// 	</see>
		/// ; in most
		/// cases this value will be
		/// <see cref="COMPONENT_ENABLED_STATE_DEFAULT">COMPONENT_ENABLED_STATE_DEFAULT</see>
		/// since
		/// the value originally specified in the manifest has not been modified.
		/// </remarks>
		/// <param name="componentName">The component to retrieve.</param>
		/// <returns>
		/// Returns the current enabled state for the component.  May
		/// be one of
		/// <see cref="COMPONENT_ENABLED_STATE_ENABLED">COMPONENT_ENABLED_STATE_ENABLED</see>
		/// ,
		/// <see cref="COMPONENT_ENABLED_STATE_DISABLED">COMPONENT_ENABLED_STATE_DISABLED</see>
		/// , or
		/// <see cref="COMPONENT_ENABLED_STATE_DEFAULT">COMPONENT_ENABLED_STATE_DEFAULT</see>
		/// .  The last one means the
		/// component's enabled state is based on the original information in
		/// the manifest as found in
		/// <see cref="ComponentInfo">ComponentInfo</see>
		/// .
		/// </returns>
		public abstract int getComponentEnabledSetting(android.content.ComponentName componentName
			);

		/// <summary>
		/// Set the enabled setting for an application
		/// This setting will override any enabled state which may have been set by the application in
		/// its manifest.
		/// </summary>
		/// <remarks>
		/// Set the enabled setting for an application
		/// This setting will override any enabled state which may have been set by the application in
		/// its manifest.  It also overrides the enabled state set in the manifest for any of the
		/// application's components.  It does not override any enabled state set by
		/// <see cref="setComponentEnabledSetting(android.content.ComponentName, int, int)">setComponentEnabledSetting(android.content.ComponentName, int, int)
		/// 	</see>
		/// for any of the application's components.
		/// </remarks>
		/// <param name="packageName">The package name of the application to enable</param>
		/// <param name="newState">
		/// The new enabled state for the component.  The legal values for this state
		/// are:
		/// <see cref="COMPONENT_ENABLED_STATE_ENABLED">COMPONENT_ENABLED_STATE_ENABLED</see>
		/// ,
		/// <see cref="COMPONENT_ENABLED_STATE_DISABLED">COMPONENT_ENABLED_STATE_DISABLED</see>
		/// and
		/// <see cref="COMPONENT_ENABLED_STATE_DEFAULT">COMPONENT_ENABLED_STATE_DEFAULT</see>
		/// The last one removes the setting, thereby restoring the applications's state to
		/// whatever was set in its manifest (or enabled, by default).
		/// </param>
		/// <param name="flags">
		/// Optional behavior flags:
		/// <see cref="DONT_KILL_APP">DONT_KILL_APP</see>
		/// or 0.
		/// </param>
		public abstract void setApplicationEnabledSetting(string packageName, int newState
			, int flags);

		/// <summary>Return the the enabled setting for an application.</summary>
		/// <remarks>
		/// Return the the enabled setting for an application.  This returns
		/// the last value set by
		/// <see cref="setApplicationEnabledSetting(string, int, int)">setApplicationEnabledSetting(string, int, int)
		/// 	</see>
		/// ; in most
		/// cases this value will be
		/// <see cref="COMPONENT_ENABLED_STATE_DEFAULT">COMPONENT_ENABLED_STATE_DEFAULT</see>
		/// since
		/// the value originally specified in the manifest has not been modified.
		/// </remarks>
		/// <param name="packageName">The component to retrieve.</param>
		/// <returns>
		/// Returns the current enabled state for the component.  May
		/// be one of
		/// <see cref="COMPONENT_ENABLED_STATE_ENABLED">COMPONENT_ENABLED_STATE_ENABLED</see>
		/// ,
		/// <see cref="COMPONENT_ENABLED_STATE_DISABLED">COMPONENT_ENABLED_STATE_DISABLED</see>
		/// , or
		/// <see cref="COMPONENT_ENABLED_STATE_DEFAULT">COMPONENT_ENABLED_STATE_DEFAULT</see>
		/// .  The last one means the
		/// application's enabled state is based on the original information in
		/// the manifest as found in
		/// <see cref="ComponentInfo">ComponentInfo</see>
		/// .
		/// </returns>
		/// <exception cref="System.ArgumentException">if the named package does not exist.</exception>
		public abstract int getApplicationEnabledSetting(string packageName);

		/// <summary>Return whether the device has been booted into safe mode.</summary>
		/// <remarks>Return whether the device has been booted into safe mode.</remarks>
		public abstract bool isSafeMode();

		/// <summary>Attempts to move package resources from internal to external media or vice versa.
		/// 	</summary>
		/// <remarks>
		/// Attempts to move package resources from internal to external media or vice versa.
		/// Since this may take a little while, the result will
		/// be posted back to the given observer.   This call may fail if the calling context
		/// lacks the
		/// <see cref="android.Manifest.permission.MOVE_PACKAGE">android.Manifest.permission.MOVE_PACKAGE
		/// 	</see>
		/// permission, if the
		/// named package cannot be found, or if the named package is a "system package".
		/// </remarks>
		/// <param name="packageName">The name of the package to delete</param>
		/// <param name="observer">
		/// An observer callback to get notified when the package move is
		/// complete.
		/// <see cref="IPackageMoveObserver.packageMoved(string, int)">IPackageMoveObserver.packageMoved(string, int)
		/// 	</see>
		/// will be
		/// called when that happens.  observer may be null to indicate that no callback is desired.
		/// </param>
		/// <param name="flags">
		/// To indicate install location
		/// <see cref="MOVE_INTERNAL">MOVE_INTERNAL</see>
		/// or
		/// <see cref="MOVE_EXTERNAL_MEDIA">MOVE_EXTERNAL_MEDIA</see>
		/// </param>
		/// <hide></hide>
		public abstract void movePackage(string packageName, android.content.pm.IPackageMoveObserver
			 observer, int flags);

		/// <summary>Creates a user with the specified name and options.</summary>
		/// <remarks>Creates a user with the specified name and options.</remarks>
		/// <param name="name">the user's name</param>
		/// <param name="flags">flags that identify the type of user and other properties.</param>
		/// <seealso cref="UserInfo">UserInfo</seealso>
		/// <returns>the UserInfo object for the created user, or null if the user could not be created.
		/// 	</returns>
		/// <hide></hide>
		public abstract android.content.pm.UserInfo createUser(string name, int flags);

		/// <returns>the list of users that were created</returns>
		/// <hide></hide>
		public abstract java.util.List<android.content.pm.UserInfo> getUsers();

		/// <param name="id">the ID of the user, where 0 is the primary user.</param>
		/// <hide></hide>
		public abstract bool removeUser(int id);

		/// <summary>Updates the user's name.</summary>
		/// <remarks>Updates the user's name.</remarks>
		/// <param name="id">the user's id</param>
		/// <param name="name">the new name for the user</param>
		/// <hide></hide>
		public abstract void updateUserName(int id, string name);

		/// <summary>Changes the user's properties specified by the flags.</summary>
		/// <remarks>Changes the user's properties specified by the flags.</remarks>
		/// <param name="id">the user's id</param>
		/// <param name="flags">the new flags for the user</param>
		/// <hide></hide>
		public abstract void updateUserFlags(int id, int flags);

		/// <summary>
		/// Checks to see if the user id is the same for the two uids, i.e., they belong to the same
		/// user.
		/// </summary>
		/// <remarks>
		/// Checks to see if the user id is the same for the two uids, i.e., they belong to the same
		/// user.
		/// </remarks>
		/// <hide></hide>
		public static bool isSameUser(int uid1, int uid2)
		{
			return getUserId(uid1) == getUserId(uid2);
		}

		/// <summary>Returns the user id for a given uid.</summary>
		/// <remarks>Returns the user id for a given uid.</remarks>
		/// <hide></hide>
		public static int getUserId(int uid)
		{
			return uid / PER_USER_RANGE;
		}

		/// <summary>Returns the uid that is composed from the userId and the appId.</summary>
		/// <remarks>Returns the uid that is composed from the userId and the appId.</remarks>
		/// <hide></hide>
		public static int getUid(int userId, int appId)
		{
			return userId * PER_USER_RANGE + (appId % PER_USER_RANGE);
		}

		/// <summary>Returns the app id (or base uid) for a given uid, stripping out the user id from it.
		/// 	</summary>
		/// <remarks>Returns the app id (or base uid) for a given uid, stripping out the user id from it.
		/// 	</remarks>
		/// <hide></hide>
		public static int getAppId(int uid)
		{
			return uid % PER_USER_RANGE;
		}

		/// <summary>
		/// Returns the device identity that verifiers can use to associate their
		/// scheme to a particular device.
		/// </summary>
		/// <remarks>
		/// Returns the device identity that verifiers can use to associate their
		/// scheme to a particular device. This should not be used by anything other
		/// than a package verifier.
		/// </remarks>
		/// <returns>identity that uniquely identifies current device</returns>
		/// <hide></hide>
		public abstract android.content.pm.VerifierDeviceIdentity getVerifierDeviceIdentity
			();
	}
}
