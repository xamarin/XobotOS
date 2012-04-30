using Sharpen;

namespace android.content.pm
{
	/// <summary>Overall information about the contents of a package.</summary>
	/// <remarks>
	/// Overall information about the contents of a package.  This corresponds
	/// to all of the information collected from AndroidManifest.xml.
	/// </remarks>
	[Sharpen.Sharpened]
	public class PackageInfo : android.os.Parcelable
	{
		/// <summary>The name of this package.</summary>
		/// <remarks>
		/// The name of this package.  From the &lt;manifest&gt; tag's "name"
		/// attribute.
		/// </remarks>
		public string packageName;

		/// <summary>
		/// The version number of this package, as specified by the &lt;manifest&gt;
		/// tag's
		/// <see cref="android.R.styleable.AndroidManifest_versionCode">versionCode</see>
		/// attribute.
		/// </summary>
		public int versionCode;

		/// <summary>
		/// The version name of this package, as specified by the &lt;manifest&gt;
		/// tag's
		/// <see cref="android.R.styleable.AndroidManifest_versionName">versionName</see>
		/// attribute.
		/// </summary>
		public string versionName;

		/// <summary>
		/// The shared user ID name of this package, as specified by the &lt;manifest&gt;
		/// tag's
		/// <see cref="android.R.styleable.AndroidManifest_sharedUserId">sharedUserId</see>
		/// attribute.
		/// </summary>
		public string sharedUserId;

		/// <summary>
		/// The shared user ID label of this package, as specified by the &lt;manifest&gt;
		/// tag's
		/// <see cref="android.R.styleable.AndroidManifest_sharedUserLabel">sharedUserLabel</see>
		/// attribute.
		/// </summary>
		public int sharedUserLabel;

		/// <summary>
		/// Information collected from the &lt;application&gt; tag, or null if
		/// there was none.
		/// </summary>
		/// <remarks>
		/// Information collected from the &lt;application&gt; tag, or null if
		/// there was none.
		/// </remarks>
		public android.content.pm.ApplicationInfo applicationInfo;

		/// <summary>The time at which the app was first installed.</summary>
		/// <remarks>
		/// The time at which the app was first installed.  Units are as
		/// per
		/// <see cref="Sharpen.Util.CurrentTimeMillis()">Sharpen.Util.CurrentTimeMillis()</see>
		/// .
		/// </remarks>
		public long firstInstallTime;

		/// <summary>The time at which the app was last updated.</summary>
		/// <remarks>
		/// The time at which the app was last updated.  Units are as
		/// per
		/// <see cref="Sharpen.Util.CurrentTimeMillis()">Sharpen.Util.CurrentTimeMillis()</see>
		/// .
		/// </remarks>
		public long lastUpdateTime;

		/// <summary>All kernel group-IDs that have been assigned to this package.</summary>
		/// <remarks>
		/// All kernel group-IDs that have been assigned to this package.
		/// This is only filled in if the flag
		/// <see cref="PackageManager.GET_GIDS">PackageManager.GET_GIDS</see>
		/// was set.
		/// </remarks>
		public int[] gids;

		/// <summary>
		/// Array of all
		/// <see cref="android.R.styleable.AndroidManifestActivity">&lt;activity&gt;</see>
		/// tags included under &lt;application&gt;,
		/// or null if there were none.  This is only filled in if the flag
		/// <see cref="PackageManager.GET_ACTIVITIES">PackageManager.GET_ACTIVITIES</see>
		/// was set.
		/// </summary>
		public android.content.pm.ActivityInfo[] activities;

		/// <summary>
		/// Array of all
		/// <see cref="android.R.styleable.AndroidManifestReceiver">&lt;receiver&gt;</see>
		/// tags included under &lt;application&gt;,
		/// or null if there were none.  This is only filled in if the flag
		/// <see cref="PackageManager.GET_RECEIVERS">PackageManager.GET_RECEIVERS</see>
		/// was set.
		/// </summary>
		public android.content.pm.ActivityInfo[] receivers;

		/// <summary>
		/// Array of all
		/// <see cref="android.R.styleable.AndroidManifestService">&lt;service&gt;</see>
		/// tags included under &lt;application&gt;,
		/// or null if there were none.  This is only filled in if the flag
		/// <see cref="PackageManager.GET_SERVICES">PackageManager.GET_SERVICES</see>
		/// was set.
		/// </summary>
		public android.content.pm.ServiceInfo[] services;

		/// <summary>
		/// Array of all
		/// <see cref="android.R.styleable.AndroidManifestProvider">&lt;provider&gt;</see>
		/// tags included under &lt;application&gt;,
		/// or null if there were none.  This is only filled in if the flag
		/// <see cref="PackageManager.GET_PROVIDERS">PackageManager.GET_PROVIDERS</see>
		/// was set.
		/// </summary>
		public android.content.pm.ProviderInfo[] providers;

		/// <summary>
		/// Array of all
		/// <see cref="android.R.styleable.AndroidManifestInstrumentation">&lt;instrumentation&gt;
		/// 	</see>
		/// tags included under &lt;manifest&gt;,
		/// or null if there were none.  This is only filled in if the flag
		/// <see cref="PackageManager.GET_INSTRUMENTATION">PackageManager.GET_INSTRUMENTATION
		/// 	</see>
		/// was set.
		/// </summary>
		public android.content.pm.InstrumentationInfo[] instrumentation;

		/// <summary>
		/// Array of all
		/// <see cref="android.R.styleable.AndroidManifestPermission">&lt;permission&gt;</see>
		/// tags included under &lt;manifest&gt;,
		/// or null if there were none.  This is only filled in if the flag
		/// <see cref="PackageManager.GET_PERMISSIONS">PackageManager.GET_PERMISSIONS</see>
		/// was set.
		/// </summary>
		public android.content.pm.PermissionInfo[] permissions;

		/// <summary>
		/// Array of all
		/// <see cref="android.R.styleable.AndroidManifestUsesPermission">&lt;uses-permission&gt;
		/// 	</see>
		/// tags included under &lt;manifest&gt;,
		/// or null if there were none.  This is only filled in if the flag
		/// <see cref="PackageManager.GET_PERMISSIONS">PackageManager.GET_PERMISSIONS</see>
		/// was set.  This list includes
		/// all permissions requested, even those that were not granted or known
		/// by the system at install time.
		/// </summary>
		public string[] requestedPermissions;

		/// <summary>Array of all signatures read from the package file.</summary>
		/// <remarks>
		/// Array of all signatures read from the package file.  This is only filled
		/// in if the flag
		/// <see cref="PackageManager.GET_SIGNATURES">PackageManager.GET_SIGNATURES</see>
		/// was set.
		/// </remarks>
		public android.content.pm.Signature[] signatures;

		/// <summary>
		/// Application specified preferred configuration
		/// <see cref="android.R.styleable.AndroidManifestUsesConfiguration">&lt;uses-configuration&gt;
		/// 	</see>
		/// tags included under &lt;manifest&gt;,
		/// or null if there were none. This is only filled in if the flag
		/// <see cref="PackageManager.GET_CONFIGURATIONS">PackageManager.GET_CONFIGURATIONS</see>
		/// was set.
		/// </summary>
		public android.content.pm.ConfigurationInfo[] configPreferences;

		/// <summary>The features that this application has said it requires.</summary>
		/// <remarks>The features that this application has said it requires.</remarks>
		public android.content.pm.FeatureInfo[] reqFeatures;

		/// <summary>
		/// Constant corresponding to <code>auto</code> in
		/// the
		/// <see cref="android.R.attr.installLocation">android.R.attr.installLocation</see>
		/// attribute.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_LOCATION_UNSPECIFIED = -1;

		/// <summary>
		/// Constant corresponding to <code>auto</code> in
		/// the
		/// <see cref="android.R.attr.installLocation">android.R.attr.installLocation</see>
		/// attribute.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_LOCATION_AUTO = 0;

		/// <summary>
		/// Constant corresponding to <code>internalOnly</code> in
		/// the
		/// <see cref="android.R.attr.installLocation">android.R.attr.installLocation</see>
		/// attribute.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_LOCATION_INTERNAL_ONLY = 1;

		/// <summary>
		/// Constant corresponding to <code>preferExternal</code> in
		/// the
		/// <see cref="android.R.attr.installLocation">android.R.attr.installLocation</see>
		/// attribute.
		/// </summary>
		/// <hide></hide>
		public const int INSTALL_LOCATION_PREFER_EXTERNAL = 2;

		/// <summary>The install location requested by the activity.</summary>
		/// <remarks>
		/// The install location requested by the activity.  From the
		/// <see cref="android.R.attr.installLocation">android.R.attr.installLocation</see>
		/// attribute, one of
		/// <see cref="INSTALL_LOCATION_AUTO">INSTALL_LOCATION_AUTO</see>
		/// ,
		/// <see cref="INSTALL_LOCATION_INTERNAL_ONLY">INSTALL_LOCATION_INTERNAL_ONLY</see>
		/// ,
		/// <see cref="INSTALL_LOCATION_PREFER_EXTERNAL">INSTALL_LOCATION_PREFER_EXTERNAL</see>
		/// </remarks>
		/// <hide></hide>
		public int installLocation = INSTALL_LOCATION_INTERNAL_ONLY;

		public PackageInfo()
		{
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "PackageInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
				(this)) + " " + packageName + "}";
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			dest.writeString(packageName);
			dest.writeInt(versionCode);
			dest.writeString(versionName);
			dest.writeString(sharedUserId);
			dest.writeInt(sharedUserLabel);
			if (applicationInfo != null)
			{
				dest.writeInt(1);
				applicationInfo.writeToParcel(dest, parcelableFlags);
			}
			else
			{
				dest.writeInt(0);
			}
			dest.writeLong(firstInstallTime);
			dest.writeLong(lastUpdateTime);
			dest.writeIntArray(gids);
			dest.writeTypedArray(activities, parcelableFlags);
			dest.writeTypedArray(receivers, parcelableFlags);
			dest.writeTypedArray(services, parcelableFlags);
			dest.writeTypedArray(providers, parcelableFlags);
			dest.writeTypedArray(instrumentation, parcelableFlags);
			dest.writeTypedArray(permissions, parcelableFlags);
			dest.writeStringArray(requestedPermissions);
			dest.writeTypedArray(signatures, parcelableFlags);
			dest.writeTypedArray(configPreferences, parcelableFlags);
			dest.writeTypedArray(reqFeatures, parcelableFlags);
			dest.writeInt(installLocation);
		}

		private sealed class _Creator_239 : android.os.ParcelableClass.Creator<android.content.pm.PackageInfo
			>
		{
			public _Creator_239()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PackageInfo createFromParcel(android.os.Parcel source)
			{
				return new android.content.pm.PackageInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PackageInfo[] newArray(int size)
			{
				return new android.content.pm.PackageInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.PackageInfo
			> CREATOR = new _Creator_239();

		private PackageInfo(android.os.Parcel source)
		{
			packageName = source.readString();
			versionCode = source.readInt();
			versionName = source.readString();
			sharedUserId = source.readString();
			sharedUserLabel = source.readInt();
			int hasApp = source.readInt();
			if (hasApp != 0)
			{
				applicationInfo = android.content.pm.ApplicationInfo.CREATOR.createFromParcel(source
					);
			}
			firstInstallTime = source.readLong();
			lastUpdateTime = source.readLong();
			gids = source.createIntArray();
			activities = source.createTypedArray(android.content.pm.ActivityInfo.CREATOR);
			receivers = source.createTypedArray(android.content.pm.ActivityInfo.CREATOR);
			services = source.createTypedArray(android.content.pm.ServiceInfo.CREATOR);
			providers = source.createTypedArray(android.content.pm.ProviderInfo.CREATOR);
			instrumentation = source.createTypedArray(android.content.pm.InstrumentationInfo.
				CREATOR);
			permissions = source.createTypedArray(android.content.pm.PermissionInfo.CREATOR);
			requestedPermissions = source.createStringArray();
			signatures = source.createTypedArray(android.content.pm.Signature.CREATOR);
			configPreferences = source.createTypedArray(android.content.pm.ConfigurationInfo.
				CREATOR);
			reqFeatures = source.createTypedArray(android.content.pm.FeatureInfo.CREATOR);
			installLocation = source.readInt();
		}
	}
}
