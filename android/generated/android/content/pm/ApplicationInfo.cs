using Sharpen;

namespace android.content.pm
{
	/// <summary>Information you can retrieve about a particular application.</summary>
	/// <remarks>
	/// Information you can retrieve about a particular application.  This
	/// corresponds to information collected from the AndroidManifest.xml's
	/// &lt;application&gt; tag.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ApplicationInfo : android.content.pm.PackageItemInfo, android.os.Parcelable
	{
		/// <summary>Default task affinity of all activities in this application.</summary>
		/// <remarks>
		/// Default task affinity of all activities in this application. See
		/// <see cref="ActivityInfo.taskAffinity">ActivityInfo.taskAffinity</see>
		/// for more information.  This comes
		/// from the "taskAffinity" attribute.
		/// </remarks>
		public string taskAffinity;

		/// <summary>
		/// Optional name of a permission required to be able to access this
		/// application's components.
		/// </summary>
		/// <remarks>
		/// Optional name of a permission required to be able to access this
		/// application's components.  From the "permission" attribute.
		/// </remarks>
		public string permission;

		/// <summary>The name of the process this application should run in.</summary>
		/// <remarks>
		/// The name of the process this application should run in.  From the
		/// "process" attribute or, if not set, the same as
		/// <var>packageName</var>.
		/// </remarks>
		public string processName;

		/// <summary>Class implementing the Application object.</summary>
		/// <remarks>
		/// Class implementing the Application object.  From the "class"
		/// attribute.
		/// </remarks>
		public string className;

		/// <summary>
		/// A style resource identifier (in the package's resources) of the
		/// description of an application.
		/// </summary>
		/// <remarks>
		/// A style resource identifier (in the package's resources) of the
		/// description of an application.  From the "description" attribute
		/// or, if not set, 0.
		/// </remarks>
		public int descriptionRes;

		/// <summary>
		/// A style resource identifier (in the package's resources) of the
		/// default visual theme of the application.
		/// </summary>
		/// <remarks>
		/// A style resource identifier (in the package's resources) of the
		/// default visual theme of the application.  From the "theme" attribute
		/// or, if not set, 0.
		/// </remarks>
		public int theme;

		/// <summary>
		/// Class implementing the Application's manage space
		/// functionality.
		/// </summary>
		/// <remarks>
		/// Class implementing the Application's manage space
		/// functionality.  From the "manageSpaceActivity"
		/// attribute. This is an optional attribute and will be null if
		/// applications don't specify it in their manifest
		/// </remarks>
		public string manageSpaceActivityName;

		/// <summary>Class implementing the Application's backup functionality.</summary>
		/// <remarks>
		/// Class implementing the Application's backup functionality.  From
		/// the "backupAgent" attribute.  This is an optional attribute and
		/// will be null if the application does not specify it in its manifest.
		/// <p>If android:allowBackup is set to false, this attribute is ignored.
		/// </remarks>
		public string backupAgentName;

		/// <summary>The default extra UI options for activities in this application.</summary>
		/// <remarks>
		/// The default extra UI options for activities in this application.
		/// Set from the
		/// <see cref="android.R.attr.uiOptions">android.R.attr.uiOptions</see>
		/// attribute in the
		/// activity's manifest.
		/// </remarks>
		public int uiOptions = 0;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : if set, this application is installed in the
		/// device's system image.
		/// </summary>
		public const int FLAG_SYSTEM = 1 << 0;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to true if this application would like to
		/// allow debugging of its
		/// code, even when installed on a non-development system.  Comes
		/// from
		/// <see cref="android.R.styleable.AndroidManifestApplication_debuggable">android:debuggable
		/// 	</see>
		/// of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_DEBUGGABLE = 1 << 1;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to true if this application has code
		/// associated with it.  Comes
		/// from
		/// <see cref="android.R.styleable.AndroidManifestApplication_hasCode">android:hasCode
		/// 	</see>
		/// of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_HAS_CODE = 1 << 2;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to true if this application is persistent.
		/// Comes from
		/// <see cref="android.R.styleable.AndroidManifestApplication_persistent">android:persistent
		/// 	</see>
		/// of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_PERSISTENT = 1 << 3;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to true if this application holds the
		/// <see cref="android.Manifest.permission.FACTORY_TEST">android.Manifest.permission.FACTORY_TEST
		/// 	</see>
		/// permission and the
		/// device is running in factory test mode.
		/// </summary>
		public const int FLAG_FACTORY_TEST = 1 << 4;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : default value for the corresponding ActivityInfo flag.
		/// Comes from
		/// <see cref="android.R.styleable.AndroidManifestApplication_allowTaskReparenting">android:allowTaskReparenting
		/// 	</see>
		/// of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_ALLOW_TASK_REPARENTING = 1 << 5;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : default value for the corresponding ActivityInfo flag.
		/// Comes from
		/// <see cref="android.R.styleable.AndroidManifestApplication_allowClearUserData">android:allowClearUserData
		/// 	</see>
		/// of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_ALLOW_CLEAR_USER_DATA = 1 << 6;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : this is set if this application has been
		/// install as an update to a built-in system application.
		/// </summary>
		public const int FLAG_UPDATED_SYSTEM_APP = 1 << 7;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : this is set of the application has specified
		/// <see cref="android.R.styleable.AndroidManifestApplication_testOnly">android:testOnly
		/// 	</see>
		/// to be true.
		/// </summary>
		public const int FLAG_TEST_ONLY = 1 << 8;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application's window can be
		/// reduced in size for smaller screens.  Corresponds to
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_smallScreens">android:smallScreens
		/// 	</see>
		/// .
		/// </summary>
		public const int FLAG_SUPPORTS_SMALL_SCREENS = 1 << 9;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application's window can be
		/// displayed on normal screens.  Corresponds to
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_normalScreens">android:normalScreens
		/// 	</see>
		/// .
		/// </summary>
		public const int FLAG_SUPPORTS_NORMAL_SCREENS = 1 << 10;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application's window can be
		/// increased in size for larger screens.  Corresponds to
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_largeScreens">android:largeScreens
		/// 	</see>
		/// .
		/// </summary>
		public const int FLAG_SUPPORTS_LARGE_SCREENS = 1 << 11;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application knows how to adjust
		/// its UI for different screen sizes.  Corresponds to
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_resizeable">android:resizeable
		/// 	</see>
		/// .
		/// </summary>
		public const int FLAG_RESIZEABLE_FOR_SCREENS = 1 << 12;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application knows how to
		/// accomodate different screen densities.  Corresponds to
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_anyDensity">android:anyDensity
		/// 	</see>
		/// .
		/// </summary>
		public const int FLAG_SUPPORTS_SCREEN_DENSITIES = 1 << 13;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to true if this application would like to
		/// request the VM to operate under the safe mode. Comes from
		/// <see cref="android.R.styleable.AndroidManifestApplication_vmSafeMode">android:vmSafeMode
		/// 	</see>
		/// of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_VM_SAFE_MODE = 1 << 14;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to <code>false</code> if the application does not wish
		/// to permit any OS-driven backups of its data; <code>true</code> otherwise.
		/// <p>Comes from the
		/// <see cref="android.R.styleable.AndroidManifestApplication_allowBackup">android:allowBackup
		/// 	</see>
		/// attribute of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_ALLOW_BACKUP = 1 << 15;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to <code>false</code> if the application must be kept
		/// in memory following a full-system restore operation; <code>true</code> otherwise.
		/// Ordinarily, during a full system restore operation each application is shut down
		/// following execution of its agent's onRestore() method.  Setting this attribute to
		/// <code>false</code> prevents this.  Most applications will not need to set this attribute.
		/// <p>If
		/// <see cref="android.R.styleable.AndroidManifestApplication_allowBackup">android:allowBackup
		/// 	</see>
		/// is set to <code>false</code> or no
		/// <see cref="android.R.styleable.AndroidManifestApplication_backupAgent">android:backupAgent
		/// 	</see>
		/// is specified, this flag will be ignored.
		/// <p>Comes from the
		/// <see cref="android.R.styleable.AndroidManifestApplication_killAfterRestore">android:killAfterRestore
		/// 	</see>
		/// attribute of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_KILL_AFTER_RESTORE = 1 << 16;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : Set to <code>true</code> if the application's backup
		/// agent claims to be able to handle restore data even "from the future,"
		/// i.e. from versions of the application with a versionCode greater than
		/// the one currently installed on the device.  <i>Use with caution!</i>  By default
		/// this attribute is <code>false</code> and the Backup Manager will ensure that data
		/// from "future" versions of the application are never supplied during a restore operation.
		/// <p>If
		/// <see cref="android.R.styleable.AndroidManifestApplication_allowBackup">android:allowBackup
		/// 	</see>
		/// is set to <code>false</code> or no
		/// <see cref="android.R.styleable.AndroidManifestApplication_backupAgent">android:backupAgent
		/// 	</see>
		/// is specified, this flag will be ignored.
		/// <p>Comes from the
		/// <see cref="android.R.styleable.AndroidManifestApplication_restoreAnyVersion">android:restoreAnyVersion
		/// 	</see>
		/// attribute of the &lt;application&gt; tag.
		/// </summary>
		public const int FLAG_RESTORE_ANY_VERSION = 1 << 17;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : Set to true if the application is
		/// currently installed on external/removable/unprotected storage.  Such
		/// applications may not be available if their storage is not currently
		/// mounted.  When the storage it is on is not available, it will look like
		/// the application has been uninstalled (its .apk is no longer available)
		/// but its persistent data is not removed.
		/// </summary>
		public const int FLAG_EXTERNAL_STORAGE = 1 << 18;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application's window can be
		/// increased in size for extra large screens.  Corresponds to
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_xlargeScreens">android:xlargeScreens
		/// 	</see>
		/// .
		/// </summary>
		public const int FLAG_SUPPORTS_XLARGE_SCREENS = 1 << 19;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application has requested a
		/// large heap for its processes.  Corresponds to
		/// <see cref="android.R.styleable.AndroidManifestApplication_largeHeap">android:largeHeap
		/// 	</see>
		/// .
		/// </summary>
		public const int FLAG_LARGE_HEAP = 1 << 20;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true if this application's package is in
		/// the stopped state.
		/// </summary>
		public const int FLAG_STOPPED = 1 << 21;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : Set to true if the application has been
		/// installed using the forward lock option.
		/// NOTE: DO NOT CHANGE THIS VALUE!  It is saved in packages.xml.
		/// <hide></hide>
		/// </summary>
		public const int FLAG_FORWARD_LOCK = 1 << 29;

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : set to <code>true</code> if the application
		/// has reported that it is heavy-weight, and thus can not participate in
		/// the normal application lifecycle.
		/// <p>Comes from the
		/// <see cref="android.R.styleable#AndroidManifestApplication_cantSaveState">android:cantSaveState
		/// 	</see>
		/// attribute of the &lt;application&gt; tag.
		/// <hide></hide>
		/// </summary>
		public const int FLAG_CANT_SAVE_STATE = 1 << 28;

		/// <summary>Flags associated with the application.</summary>
		/// <remarks>
		/// Flags associated with the application.  Any combination of
		/// <see cref="FLAG_SYSTEM">FLAG_SYSTEM</see>
		/// ,
		/// <see cref="FLAG_DEBUGGABLE">FLAG_DEBUGGABLE</see>
		/// ,
		/// <see cref="FLAG_HAS_CODE">FLAG_HAS_CODE</see>
		/// ,
		/// <see cref="FLAG_PERSISTENT">FLAG_PERSISTENT</see>
		/// ,
		/// <see cref="FLAG_FACTORY_TEST">FLAG_FACTORY_TEST</see>
		/// , and
		/// <see cref="FLAG_ALLOW_TASK_REPARENTING">FLAG_ALLOW_TASK_REPARENTING</see>
		/// <see cref="FLAG_ALLOW_CLEAR_USER_DATA">FLAG_ALLOW_CLEAR_USER_DATA</see>
		/// ,
		/// <see cref="FLAG_UPDATED_SYSTEM_APP">FLAG_UPDATED_SYSTEM_APP</see>
		/// ,
		/// <see cref="FLAG_TEST_ONLY">FLAG_TEST_ONLY</see>
		/// ,
		/// <see cref="FLAG_SUPPORTS_SMALL_SCREENS">FLAG_SUPPORTS_SMALL_SCREENS</see>
		/// ,
		/// <see cref="FLAG_SUPPORTS_NORMAL_SCREENS">FLAG_SUPPORTS_NORMAL_SCREENS</see>
		/// ,
		/// <see cref="FLAG_SUPPORTS_LARGE_SCREENS">FLAG_SUPPORTS_LARGE_SCREENS</see>
		/// ,
		/// <see cref="FLAG_SUPPORTS_XLARGE_SCREENS">FLAG_SUPPORTS_XLARGE_SCREENS</see>
		/// ,
		/// <see cref="FLAG_RESIZEABLE_FOR_SCREENS">FLAG_RESIZEABLE_FOR_SCREENS</see>
		/// ,
		/// <see cref="FLAG_SUPPORTS_SCREEN_DENSITIES">FLAG_SUPPORTS_SCREEN_DENSITIES</see>
		/// ,
		/// <see cref="FLAG_VM_SAFE_MODE">FLAG_VM_SAFE_MODE</see>
		/// </remarks>
		public int flags = 0;

		/// <summary>The required smallest screen width the application can run on.</summary>
		/// <remarks>
		/// The required smallest screen width the application can run on.  If 0,
		/// nothing has been specified.  Comes from
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_requiresSmallestWidthDp
		/// 	">android:requiresSmallestWidthDp</see>
		/// attribute of the &lt;supports-screens&gt; tag.
		/// </remarks>
		public int requiresSmallestWidthDp = 0;

		/// <summary>The maximum smallest screen width the application is designed for.</summary>
		/// <remarks>
		/// The maximum smallest screen width the application is designed for.  If 0,
		/// nothing has been specified.  Comes from
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_compatibleWidthLimitDp
		/// 	">android:compatibleWidthLimitDp</see>
		/// attribute of the &lt;supports-screens&gt; tag.
		/// </remarks>
		public int compatibleWidthLimitDp = 0;

		/// <summary>The maximum smallest screen width the application will work on.</summary>
		/// <remarks>
		/// The maximum smallest screen width the application will work on.  If 0,
		/// nothing has been specified.  Comes from
		/// <see cref="android.R.styleable.AndroidManifestSupportsScreens_largestWidthLimitDp
		/// 	">android:largestWidthLimitDp</see>
		/// attribute of the &lt;supports-screens&gt; tag.
		/// </remarks>
		public int largestWidthLimitDp = 0;

		/// <summary>Full path to the location of this package.</summary>
		/// <remarks>Full path to the location of this package.</remarks>
		public string sourceDir;

		/// <summary>
		/// Full path to the location of the publicly available parts of this
		/// package (i.e.
		/// </summary>
		/// <remarks>
		/// Full path to the location of the publicly available parts of this
		/// package (i.e. the primary resource package and manifest).  For
		/// non-forward-locked apps this will be the same as
		/// <see>#sourceDir).</see>
		/// </remarks>
		public string publicSourceDir;

		/// <summary>
		/// Full paths to the locations of extra resource packages this application
		/// uses.
		/// </summary>
		/// <remarks>
		/// Full paths to the locations of extra resource packages this application
		/// uses. This field is only used if there are extra resource packages,
		/// otherwise it is null.
		/// <hide></hide>
		/// </remarks>
		public string[] resourceDirs;

		/// <summary>Paths to all shared libraries this application is linked against.</summary>
		/// <remarks>
		/// Paths to all shared libraries this application is linked against.  This
		/// field is only set if the
		/// <see cref="PackageManager.GET_SHARED_LIBRARY_FILES">PackageManager.GET_SHARED_LIBRARY_FILES
		/// 	</see>
		/// flag was used when retrieving
		/// the structure.
		/// </remarks>
		public string[] sharedLibraryFiles;

		/// <summary>
		/// Full path to a directory assigned to the package for its persistent
		/// data.
		/// </summary>
		/// <remarks>
		/// Full path to a directory assigned to the package for its persistent
		/// data.
		/// </remarks>
		public string dataDir;

		/// <summary>Full path to the directory where native JNI libraries are stored.</summary>
		/// <remarks>Full path to the directory where native JNI libraries are stored.</remarks>
		public string nativeLibraryDir;

		/// <summary>
		/// The kernel user-ID that has been assigned to this application;
		/// currently this is not a unique ID (multiple applications can have
		/// the same uid).
		/// </summary>
		/// <remarks>
		/// The kernel user-ID that has been assigned to this application;
		/// currently this is not a unique ID (multiple applications can have
		/// the same uid).
		/// </remarks>
		public int uid;

		/// <summary>The minimum SDK version this application targets.</summary>
		/// <remarks>
		/// The minimum SDK version this application targets.  It may run on earlier
		/// versions, but it knows how to work with any new behavior added at this
		/// version.  Will be
		/// <see cref="android.os.Build.VERSION_CODES.CUR_DEVELOPMENT">android.os.Build.VERSION_CODES.CUR_DEVELOPMENT
		/// 	</see>
		/// if this is a development build and the app is targeting that.  You should
		/// compare that this number is &gt;= the SDK version number at which your
		/// behavior was introduced.
		/// </remarks>
		public int targetSdkVersion;

		/// <summary>
		/// When false, indicates that all components within this application are
		/// considered disabled, regardless of their individually set enabled status.
		/// </summary>
		/// <remarks>
		/// When false, indicates that all components within this application are
		/// considered disabled, regardless of their individually set enabled status.
		/// </remarks>
		public bool enabled = true;

		/// <summary>For convenient access to the current enabled setting of this app.</summary>
		/// <remarks>For convenient access to the current enabled setting of this app.</remarks>
		/// <hide></hide>
		public int enabledSetting = android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_DEFAULT;

		/// <summary>For convenient access to package's install location.</summary>
		/// <remarks>For convenient access to package's install location.</remarks>
		/// <hide></hide>
		public int installLocation = android.content.pm.PackageInfo.INSTALL_LOCATION_UNSPECIFIED;

		public virtual void dump(android.util.Printer pw, string prefix)
		{
			base.dumpFront(pw, prefix);
			if (className != null)
			{
				pw.println(prefix + "className=" + className);
			}
			if (permission != null)
			{
				pw.println(prefix + "permission=" + permission);
			}
			pw.println(prefix + "processName=" + processName);
			pw.println(prefix + "taskAffinity=" + taskAffinity);
			pw.println(prefix + "uid=" + uid + " flags=0x" + Sharpen.Util.IntToHexString(flags
				) + " theme=0x" + Sharpen.Util.IntToHexString(theme));
			pw.println(prefix + "requiresSmallestWidthDp=" + requiresSmallestWidthDp + " compatibleWidthLimitDp="
				 + compatibleWidthLimitDp + " largestWidthLimitDp=" + largestWidthLimitDp);
			pw.println(prefix + "sourceDir=" + sourceDir);
			if (sourceDir == null)
			{
				if (publicSourceDir != null)
				{
					pw.println(prefix + "publicSourceDir=" + publicSourceDir);
				}
			}
			else
			{
				if (!sourceDir.Equals(publicSourceDir))
				{
					pw.println(prefix + "publicSourceDir=" + publicSourceDir);
				}
			}
			if (resourceDirs != null)
			{
				pw.println(prefix + "resourceDirs=" + resourceDirs);
			}
			pw.println(prefix + "dataDir=" + dataDir);
			if (sharedLibraryFiles != null)
			{
				pw.println(prefix + "sharedLibraryFiles=" + sharedLibraryFiles);
			}
			pw.println(prefix + "enabled=" + enabled + " targetSdkVersion=" + targetSdkVersion
				);
			if (manageSpaceActivityName != null)
			{
				pw.println(prefix + "manageSpaceActivityName=" + manageSpaceActivityName);
			}
			if (descriptionRes != 0)
			{
				pw.println(prefix + "description=0x" + Sharpen.Util.IntToHexString(descriptionRes
					));
			}
			if (uiOptions != 0)
			{
				pw.println(prefix + "uiOptions=0x" + Sharpen.Util.IntToHexString(uiOptions));
			}
			base.dumpBack(pw, prefix);
		}

		public class DisplayNameComparator : java.util.Comparator<android.content.pm.ApplicationInfo
			>
		{
			public DisplayNameComparator(android.content.pm.PackageManager pm)
			{
				mPM = pm;
			}

			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public virtual int compare(android.content.pm.ApplicationInfo aa, android.content.pm.ApplicationInfo
				 ab)
			{
				java.lang.CharSequence sa = mPM.getApplicationLabel(aa);
				if (sa == null)
				{
					sa = java.lang.CharSequenceProxy.Wrap(aa.packageName);
				}
				java.lang.CharSequence sb = mPM.getApplicationLabel(ab);
				if (sb == null)
				{
					sb = java.lang.CharSequenceProxy.Wrap(ab.packageName);
				}
				return sCollator.compare(sa.ToString(), sb.ToString());
			}

			private readonly java.text.Collator sCollator = java.text.Collator.getInstance();

			private android.content.pm.PackageManager mPM;
		}

		public ApplicationInfo()
		{
		}

		public ApplicationInfo(android.content.pm.ApplicationInfo orig) : base(orig)
		{
			taskAffinity = orig.taskAffinity;
			permission = orig.permission;
			processName = orig.processName;
			className = orig.className;
			theme = orig.theme;
			flags = orig.flags;
			requiresSmallestWidthDp = orig.requiresSmallestWidthDp;
			compatibleWidthLimitDp = orig.compatibleWidthLimitDp;
			largestWidthLimitDp = orig.largestWidthLimitDp;
			sourceDir = orig.sourceDir;
			publicSourceDir = orig.publicSourceDir;
			nativeLibraryDir = orig.nativeLibraryDir;
			resourceDirs = orig.resourceDirs;
			sharedLibraryFiles = orig.sharedLibraryFiles;
			dataDir = orig.dataDir;
			uid = orig.uid;
			targetSdkVersion = orig.targetSdkVersion;
			enabled = orig.enabled;
			enabledSetting = orig.enabledSetting;
			installLocation = orig.installLocation;
			manageSpaceActivityName = orig.manageSpaceActivityName;
			descriptionRes = orig.descriptionRes;
			uiOptions = orig.uiOptions;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ApplicationInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
				(this)) + " " + packageName + "}";
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		public override void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			base.writeToParcel(dest, parcelableFlags);
			dest.writeString(taskAffinity);
			dest.writeString(permission);
			dest.writeString(processName);
			dest.writeString(className);
			dest.writeInt(theme);
			dest.writeInt(flags);
			dest.writeInt(requiresSmallestWidthDp);
			dest.writeInt(compatibleWidthLimitDp);
			dest.writeInt(largestWidthLimitDp);
			dest.writeString(sourceDir);
			dest.writeString(publicSourceDir);
			dest.writeString(nativeLibraryDir);
			dest.writeStringArray(resourceDirs);
			dest.writeStringArray(sharedLibraryFiles);
			dest.writeString(dataDir);
			dest.writeInt(uid);
			dest.writeInt(targetSdkVersion);
			dest.writeInt(enabled ? 1 : 0);
			dest.writeInt(enabledSetting);
			dest.writeInt(installLocation);
			dest.writeString(manageSpaceActivityName);
			dest.writeString(backupAgentName);
			dest.writeInt(descriptionRes);
			dest.writeInt(uiOptions);
		}

		private sealed class _Creator_565 : android.os.ParcelableClass.Creator<android.content.pm.ApplicationInfo
			>
		{
			public _Creator_565()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ApplicationInfo createFromParcel(android.os.Parcel source
				)
			{
				return new android.content.pm.ApplicationInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ApplicationInfo[] newArray(int size)
			{
				return new android.content.pm.ApplicationInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ApplicationInfo
			> CREATOR = new _Creator_565();

		private ApplicationInfo(android.os.Parcel source) : base(source)
		{
			taskAffinity = source.readString();
			permission = source.readString();
			processName = source.readString();
			className = source.readString();
			theme = source.readInt();
			flags = source.readInt();
			requiresSmallestWidthDp = source.readInt();
			compatibleWidthLimitDp = source.readInt();
			largestWidthLimitDp = source.readInt();
			sourceDir = source.readString();
			publicSourceDir = source.readString();
			nativeLibraryDir = source.readString();
			resourceDirs = source.readStringArray();
			sharedLibraryFiles = source.readStringArray();
			dataDir = source.readString();
			uid = source.readInt();
			targetSdkVersion = source.readInt();
			enabled = source.readInt() != 0;
			enabledSetting = source.readInt();
			installLocation = source.readInt();
			manageSpaceActivityName = source.readString();
			backupAgentName = source.readString();
			descriptionRes = source.readInt();
			uiOptions = source.readInt();
		}

		/// <summary>Retrieve the textual description of the application.</summary>
		/// <remarks>
		/// Retrieve the textual description of the application.  This
		/// will call back on the given PackageManager to load the description from
		/// the application.
		/// </remarks>
		/// <param name="pm">
		/// A PackageManager from which the label can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <returns>
		/// Returns a CharSequence containing the application's description.
		/// If there is no description, null is returned.
		/// </returns>
		public virtual java.lang.CharSequence loadDescription(android.content.pm.PackageManager
			 pm)
		{
			if (descriptionRes != 0)
			{
				java.lang.CharSequence label = pm.getText(packageName, descriptionRes, this);
				if (label != null)
				{
					return label;
				}
			}
			return null;
		}

		/// <summary>Disable compatibility mode</summary>
		/// <hide></hide>
		public virtual void disableCompatibilityMode()
		{
			flags |= (FLAG_SUPPORTS_LARGE_SCREENS | FLAG_SUPPORTS_NORMAL_SCREENS | FLAG_SUPPORTS_SMALL_SCREENS
				 | FLAG_RESIZEABLE_FOR_SCREENS | FLAG_SUPPORTS_SCREEN_DENSITIES | FLAG_SUPPORTS_XLARGE_SCREENS
				);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		protected internal override android.graphics.drawable.Drawable loadDefaultIcon(android.content.pm.PackageManager
			 pm)
		{
			if ((flags & FLAG_EXTERNAL_STORAGE) != 0 && isPackageUnavailable(pm))
			{
				return android.content.res.Resources.getSystem().getDrawable(android.@internal.R.
					drawable.sym_app_on_sd_unavailable_icon);
			}
			return pm.getDefaultActivityIcon();
		}

		private bool isPackageUnavailable(android.content.pm.PackageManager pm)
		{
			try
			{
				return pm.getPackageInfo(packageName, 0) == null;
			}
			catch (android.content.pm.PackageManager.NameNotFoundException)
			{
				return true;
			}
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		protected internal override android.content.pm.ApplicationInfo getApplicationInfo
			()
		{
			return this;
		}
	}
}
