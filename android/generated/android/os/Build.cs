using Sharpen;

namespace android.os
{
	/// <summary>Information about the current build, extracted from system properties.</summary>
	/// <remarks>Information about the current build, extracted from system properties.</remarks>
	[Sharpen.Sharpened]
	public partial class Build
	{
		/// <summary>Value used for when a build property is unknown.</summary>
		/// <remarks>Value used for when a build property is unknown.</remarks>
		public const string UNKNOWN = "unknown";

		/// <summary>Either a changelist number, or a label like "M4-rc20".</summary>
		/// <remarks>Either a changelist number, or a label like "M4-rc20".</remarks>
		public static readonly string ID = getString("ro.build.id");

		/// <summary>A build ID string meant for displaying to the user</summary>
		public static readonly string DISPLAY = getString("ro.build.display.id");

		/// <summary>The name of the overall product.</summary>
		/// <remarks>The name of the overall product.</remarks>
		public static readonly string PRODUCT = getString("ro.product.name");

		/// <summary>The name of the industrial design.</summary>
		/// <remarks>The name of the industrial design.</remarks>
		public static readonly string DEVICE = getString("ro.product.device");

		/// <summary>The name of the underlying board, like "goldfish".</summary>
		/// <remarks>The name of the underlying board, like "goldfish".</remarks>
		public static readonly string BOARD = getString("ro.product.board");

		/// <summary>The name of the instruction set (CPU type + ABI convention) of native code.
		/// 	</summary>
		/// <remarks>The name of the instruction set (CPU type + ABI convention) of native code.
		/// 	</remarks>
		public static readonly string CPU_ABI = getString("ro.product.cpu.abi");

		/// <summary>The name of the second instruction set (CPU type + ABI convention) of native code.
		/// 	</summary>
		/// <remarks>The name of the second instruction set (CPU type + ABI convention) of native code.
		/// 	</remarks>
		public static readonly string CPU_ABI2 = getString("ro.product.cpu.abi2");

		/// <summary>The manufacturer of the product/hardware.</summary>
		/// <remarks>The manufacturer of the product/hardware.</remarks>
		public static readonly string MANUFACTURER = getString("ro.product.manufacturer");

		/// <summary>The brand (e.g., carrier) the software is customized for, if any.</summary>
		/// <remarks>The brand (e.g., carrier) the software is customized for, if any.</remarks>
		public static readonly string BRAND = getString("ro.product.brand");

		/// <summary>The end-user-visible name for the end product.</summary>
		/// <remarks>The end-user-visible name for the end product.</remarks>
		public static readonly string MODEL = getString("ro.product.model");

		/// <summary>The system bootloader version number.</summary>
		/// <remarks>The system bootloader version number.</remarks>
		public static readonly string BOOTLOADER = getString("ro.bootloader");

		/// <summary>The radio firmware version number.</summary>
		/// <remarks>The radio firmware version number.</remarks>
		[System.ObsoleteAttribute(@"The radio firmware version is frequently not available when this class is initialized, leading to a blank or ""unknown"" value for this string.  UsegetRadioVersion() instead."
			)]
		public static readonly string RADIO = null;

		/// <summary>The name of the hardware (from the kernel command line or /proc).</summary>
		/// <remarks>The name of the hardware (from the kernel command line or /proc).</remarks>
		public static readonly string HARDWARE = getString("ro.hardware");

		/// <summary>A hardware serial number, if available.</summary>
		/// <remarks>A hardware serial number, if available.  Alphanumeric only, case-insensitive.
		/// 	</remarks>
		public static readonly string SERIAL = getString("ro.serialno");

		/// <summary>Various version strings.</summary>
		/// <remarks>Various version strings.</remarks>
		public class VERSION
		{
			/// <summary>
			/// The internal value used by the underlying source control to
			/// represent this build.
			/// </summary>
			/// <remarks>
			/// The internal value used by the underlying source control to
			/// represent this build.  E.g., a perforce changelist number
			/// or a git hash.
			/// </remarks>
			public static readonly string INCREMENTAL = getString("ro.build.version.incremental"
				);

			/// <summary>The user-visible version string.</summary>
			/// <remarks>The user-visible version string.  E.g., "1.0" or "3.4b5".</remarks>
			public static readonly string RELEASE = getString("ro.build.version.release");

			/// <summary>
			/// The user-visible SDK version of the framework in its raw String
			/// representation; use
			/// <see cref="SDK_INT">SDK_INT</see>
			/// instead.
			/// </summary>
			[System.ObsoleteAttribute(@"Use SDK_INT to easily get this as an integer.")]
			public static readonly string SDK = getString("ro.build.version.sdk");

			/// <summary>
			/// The user-visible SDK version of the framework; its possible
			/// values are defined in
			/// <see cref="VERSION_CODES">VERSION_CODES</see>
			/// .
			/// </summary>
			public static readonly int SDK_INT = VERSION_CODES.ICE_CREAM_SANDWICH;

			/// <summary>
			/// The current development codename, or the string "REL" if this is
			/// a release build.
			/// </summary>
			/// <remarks>
			/// The current development codename, or the string "REL" if this is
			/// a release build.
			/// </remarks>
			public static readonly string CODENAME = getString("ro.build.version.codename");

			/// <summary>The SDK version to use when accessing resources.</summary>
			/// <remarks>
			/// The SDK version to use when accessing resources.
			/// Use the current SDK version code.  If we are a development build,
			/// also allow the previous SDK version + 1.
			/// </remarks>
			/// <hide></hide>
			public static readonly int RESOURCES_SDK_INT = SDK_INT + ("REL".Equals(CODENAME) ? 
				0 : 1);
		}

		/// <summary>Enumeration of the currently known SDK version codes.</summary>
		/// <remarks>
		/// Enumeration of the currently known SDK version codes.  These are the
		/// values that can be found in
		/// <see cref="VERSION.SDK">VERSION.SDK</see>
		/// .  Version numbers
		/// increment monotonically with each official platform release.
		/// </remarks>
		public class VERSION_CODES
		{
			/// <summary>
			/// Magic version number for a current development build, which has
			/// not yet turned into an official release.
			/// </summary>
			/// <remarks>
			/// Magic version number for a current development build, which has
			/// not yet turned into an official release.
			/// </remarks>
			public const int CUR_DEVELOPMENT = 10000;

			/// <summary>October 2008: The original, first, version of Android.</summary>
			/// <remarks>October 2008: The original, first, version of Android.  Yay!</remarks>
			public const int BASE = 1;

			/// <summary>February 2009: First Android update, officially called 1.1.</summary>
			/// <remarks>February 2009: First Android update, officially called 1.1.</remarks>
			public const int BASE_1_1 = 2;

			/// <summary>May 2009: Android 1.5.</summary>
			/// <remarks>May 2009: Android 1.5.</remarks>
			public const int CUPCAKE = 3;

			/// <summary>September 2009: Android 1.6.</summary>
			/// <remarks>
			/// September 2009: Android 1.6.
			/// <p>Applications targeting this or a later release will get these
			/// new changes in behavior:</p>
			/// <ul>
			/// <li> They must explicitly request the
			/// <see cref="android.Manifest.permission.WRITE_EXTERNAL_STORAGE">android.Manifest.permission.WRITE_EXTERNAL_STORAGE
			/// 	</see>
			/// permission to be
			/// able to modify the contents of the SD card.  (Apps targeting
			/// earlier versions will always request the permission.)
			/// <li> They must explicitly request the
			/// <see cref="android.Manifest.permission.READ_PHONE_STATE">android.Manifest.permission.READ_PHONE_STATE
			/// 	</see>
			/// permission to be
			/// able to be able to retrieve phone state info.  (Apps targeting
			/// earlier versions will always request the permission.)
			/// <li> They are assumed to support different screen densities and
			/// sizes.  (Apps targeting earlier versions are assumed to only support
			/// medium density normal size screens unless otherwise indicated).
			/// They can still explicitly specify screen support either way with the
			/// supports-screens manifest tag.
			/// </ul>
			/// </remarks>
			public const int DONUT = 4;

			/// <summary>
			/// November 2009: Android 2.0
			/// <p>Applications targeting this or a later release will get these
			/// new changes in behavior:</p>
			/// <ul>
			/// <li> The
			/// <see cref="android.app.Service.onStartCommand(android.content.Intent, int, int)">Service.onStartCommand
			/// 	</see>
			/// function will return the new
			/// <see cref="android.app.Service.START_STICKY">android.app.Service.START_STICKY</see>
			/// behavior instead of the
			/// old compatibility
			/// <see cref="android.app.Service.START_STICKY_COMPATIBILITY">android.app.Service.START_STICKY_COMPATIBILITY
			/// 	</see>
			/// .
			/// <li> The
			/// <see cref="android.app.Activity">android.app.Activity</see>
			/// class will now execute back
			/// key presses on the key up instead of key down, to be able to detect
			/// canceled presses from virtual keys.
			/// <li> The
			/// <see cref="android.widget.TabWidget">android.widget.TabWidget</see>
			/// class will use a new color scheme
			/// for tabs. In the new scheme, the foreground tab has a medium gray background
			/// the background tabs have a dark gray background.
			/// </ul>
			/// </summary>
			public const int ECLAIR = 5;

			/// <summary>December 2009: Android 2.0.1</summary>
			public const int ECLAIR_0_1 = 6;

			/// <summary>January 2010: Android 2.1</summary>
			public const int ECLAIR_MR1 = 7;

			/// <summary>June 2010: Android 2.2</summary>
			public const int FROYO = 8;

			/// <summary>November 2010: Android 2.3</summary>
			public const int GINGERBREAD = 9;

			/// <summary>February 2011: Android 2.3.3.</summary>
			/// <remarks>February 2011: Android 2.3.3.</remarks>
			public const int GINGERBREAD_MR1 = 10;

			/// <summary>February 2011: Android 3.0.</summary>
			/// <remarks>
			/// February 2011: Android 3.0.
			/// <p>Applications targeting this or a later release will get these
			/// new changes in behavior:</p>
			/// <ul>
			/// <li> The default theme for applications is now dark holographic:
			/// <see cref="android.R.style.Theme_Holo">android.R.style.Theme_Holo</see>
			/// .
			/// <li> The activity lifecycle has changed slightly as per
			/// <see cref="android.app.Activity">android.app.Activity</see>
			/// .
			/// <li> When an application requires a permission to access one of
			/// its components (activity, receiver, service, provider), this
			/// permission is no longer enforced when the application wants to
			/// access its own component.  This means it can require a permission
			/// on a component that it does not itself hold and still access that
			/// component.
			/// </ul>
			/// </remarks>
			public const int HONEYCOMB = 11;

			/// <summary>May 2011: Android 3.1.</summary>
			/// <remarks>May 2011: Android 3.1.</remarks>
			public const int HONEYCOMB_MR1 = 12;

			/// <summary>June 2011: Android 3.2.</summary>
			/// <remarks>
			/// June 2011: Android 3.2.
			/// <p>Update to Honeycomb MR1 to support 7 inch tablets, improve
			/// screen compatibility mode, etc.</p>
			/// <p>As of this version, applications that don't say whether they
			/// support XLARGE screens will be assumed to do so only if they target
			/// <see cref="HONEYCOMB">HONEYCOMB</see>
			/// or later; it had been
			/// <see cref="GINGERBREAD">GINGERBREAD</see>
			/// or
			/// later.  Applications that don't support a screen size at least as
			/// large as the current screen will provide the user with a UI to
			/// switch them in to screen size compatibility mode.</p>
			/// <p>This version introduces new screen size resource qualifiers
			/// based on the screen size in dp: see
			/// <see cref="android.content.res.Configuration.screenWidthDp">android.content.res.Configuration.screenWidthDp
			/// 	</see>
			/// ,
			/// <see cref="android.content.res.Configuration.screenHeightDp">android.content.res.Configuration.screenHeightDp
			/// 	</see>
			/// , and
			/// <see cref="android.content.res.Configuration.smallestScreenWidthDp">android.content.res.Configuration.smallestScreenWidthDp
			/// 	</see>
			/// .
			/// Supplying these in &lt;supports-screens&gt; as per
			/// <see cref="android.content.pm.ApplicationInfo.requiresSmallestWidthDp">android.content.pm.ApplicationInfo.requiresSmallestWidthDp
			/// 	</see>
			/// ,
			/// <see cref="android.content.pm.ApplicationInfo.compatibleWidthLimitDp">android.content.pm.ApplicationInfo.compatibleWidthLimitDp
			/// 	</see>
			/// , and
			/// <see cref="android.content.pm.ApplicationInfo.largestWidthLimitDp">android.content.pm.ApplicationInfo.largestWidthLimitDp
			/// 	</see>
			/// is
			/// preferred over the older screen size buckets and for older devices
			/// the appropriate buckets will be inferred from them.</p>
			/// <p>New
			/// <see cref="android.content.pm.PackageManager.FEATURE_SCREEN_PORTRAIT">android.content.pm.PackageManager.FEATURE_SCREEN_PORTRAIT
			/// 	</see>
			/// and
			/// <see cref="android.content.pm.PackageManager.FEATURE_SCREEN_LANDSCAPE">android.content.pm.PackageManager.FEATURE_SCREEN_LANDSCAPE
			/// 	</see>
			/// features are introduced in this release.  Applications that target
			/// previous platform versions are assumed to require both portrait and
			/// landscape support in the device; when targeting Honeycomb MR1 or
			/// greater the application is responsible for specifying any specific
			/// orientation it requires.</p>
			/// </remarks>
			public const int HONEYCOMB_MR2 = 13;

			/// <summary>Android 4.0.</summary>
			/// <remarks>
			/// Android 4.0.
			/// <p>Applications targeting this or a later release will get these
			/// new changes in behavior:</p>
			/// <ul>
			/// <li> For devices without a dedicated menu key, the software compatibility
			/// menu key will not be shown even on phones.  By targeting Ice Cream Sandwich
			/// or later, your UI must always have its own menu UI affordance if needed,
			/// on both tablets and phones.  The ActionBar will take care of this for you.
			/// <li> 2d drawing hardware acceleration is now turned on by default.
			/// You can use
			/// <see cref="android.R.attr.hardwareAccelerated">android:hardwareAccelerated</see>
			/// to turn it off if needed, although this is strongly discouraged since
			/// it will result in poor performance on larger screen devices.
			/// <li> The default theme for applications is now the "device default" theme:
			/// <see cref="android.R.style.Theme_DeviceDefault">android.R.style.Theme_DeviceDefault
			/// 	</see>
			/// . This may be the
			/// holo dark theme or a different dark theme defined by the specific device.
			/// The
			/// <see cref="android.R.style.Theme_Holo">android.R.style.Theme_Holo</see>
			/// family must not be modified
			/// for a device to be considered compatible. Applications that explicitly
			/// request a theme from the Holo family will be guaranteed that these themes
			/// will not change character within the same platform version. Applications
			/// that wish to blend in with the device should use a theme from the
			/// <see cref="android.R.style.Theme_DeviceDefault">android.R.style.Theme_DeviceDefault
			/// 	</see>
			/// family.
			/// <li> Managed cursors can now throw an exception if you directly close
			/// the cursor yourself without stopping the management of it; previously failures
			/// would be silently ignored.
			/// <li> The fadingEdge attribute on views will be ignored (fading edges is no
			/// longer a standard part of the UI).  A new requiresFadingEdge attribute allows
			/// applications to still force fading edges on for special cases.
			/// </ul>
			/// </remarks>
			public const int ICE_CREAM_SANDWICH = 14;
		}

		/// <summary>The type of build, like "user" or "eng".</summary>
		/// <remarks>The type of build, like "user" or "eng".</remarks>
		public static readonly string TYPE = getString("ro.build.type");

		/// <summary>Comma-separated tags describing the build, like "unsigned,debug".</summary>
		/// <remarks>Comma-separated tags describing the build, like "unsigned,debug".</remarks>
		public static readonly string TAGS = getString("ro.build.tags");

		/// <summary>A string that uniquely identifies this build.</summary>
		/// <remarks>A string that uniquely identifies this build.  Do not attempt to parse this value.
		/// 	</remarks>
		public static readonly string FINGERPRINT = getString("ro.build.fingerprint");

		public static readonly long TIME = getLong("ro.build.date.utc") * 1000;

		public static readonly string USER = getString("ro.build.user");

		public static readonly string HOST = getString("ro.build.host");
		// The following properties only make sense for internal engineering builds.
	}
}
