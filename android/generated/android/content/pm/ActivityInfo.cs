using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Information you can retrieve about a particular application
	/// activity or receiver.
	/// </summary>
	/// <remarks>
	/// Information you can retrieve about a particular application
	/// activity or receiver. This corresponds to information collected
	/// from the AndroidManifest.xml's &lt;activity&gt; and
	/// &lt;receiver&gt; tags.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ActivityInfo : android.content.pm.ComponentInfo, android.os.Parcelable
	{
		/// <summary>
		/// A style resource identifier (in the package's resources) of this
		/// activity's theme.
		/// </summary>
		/// <remarks>
		/// A style resource identifier (in the package's resources) of this
		/// activity's theme.  From the "theme" attribute or, if not set, 0.
		/// </remarks>
		public int theme;

		/// <summary>
		/// Constant corresponding to <code>standard</code> in
		/// the
		/// <see cref="android.R.attr.launchMode">android.R.attr.launchMode</see>
		/// attribute.
		/// </summary>
		public const int LAUNCH_MULTIPLE = 0;

		/// <summary>
		/// Constant corresponding to <code>singleTop</code> in
		/// the
		/// <see cref="android.R.attr.launchMode">android.R.attr.launchMode</see>
		/// attribute.
		/// </summary>
		public const int LAUNCH_SINGLE_TOP = 1;

		/// <summary>
		/// Constant corresponding to <code>singleTask</code> in
		/// the
		/// <see cref="android.R.attr.launchMode">android.R.attr.launchMode</see>
		/// attribute.
		/// </summary>
		public const int LAUNCH_SINGLE_TASK = 2;

		/// <summary>
		/// Constant corresponding to <code>singleInstance</code> in
		/// the
		/// <see cref="android.R.attr.launchMode">android.R.attr.launchMode</see>
		/// attribute.
		/// </summary>
		public const int LAUNCH_SINGLE_INSTANCE = 3;

		/// <summary>The launch mode style requested by the activity.</summary>
		/// <remarks>
		/// The launch mode style requested by the activity.  From the
		/// <see cref="android.R.attr.launchMode">android.R.attr.launchMode</see>
		/// attribute, one of
		/// <see cref="LAUNCH_MULTIPLE">LAUNCH_MULTIPLE</see>
		/// ,
		/// <see cref="LAUNCH_SINGLE_TOP">LAUNCH_SINGLE_TOP</see>
		/// ,
		/// <see cref="LAUNCH_SINGLE_TASK">LAUNCH_SINGLE_TASK</see>
		/// , or
		/// <see cref="LAUNCH_SINGLE_INSTANCE">LAUNCH_SINGLE_INSTANCE</see>
		/// .
		/// </remarks>
		public int launchMode;

		/// <summary>
		/// Optional name of a permission required to be able to access this
		/// Activity.
		/// </summary>
		/// <remarks>
		/// Optional name of a permission required to be able to access this
		/// Activity.  From the "permission" attribute.
		/// </remarks>
		public string permission;

		/// <summary>The affinity this activity has for another task in the system.</summary>
		/// <remarks>
		/// The affinity this activity has for another task in the system.  The
		/// string here is the name of the task, often the package name of the
		/// overall package.  If null, the activity has no affinity.  Set from the
		/// <see cref="android.R.attr.taskAffinity">android.R.attr.taskAffinity</see>
		/// attribute.
		/// </remarks>
		public string taskAffinity;

		/// <summary>
		/// If this is an activity alias, this is the real activity class to run
		/// for it.
		/// </summary>
		/// <remarks>
		/// If this is an activity alias, this is the real activity class to run
		/// for it.  Otherwise, this is null.
		/// </remarks>
		public string targetActivity;

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// indicating whether this activity is able to
		/// run in multiple processes.  If
		/// true, the system may instantiate it in the some process as the
		/// process starting it in order to conserve resources.  If false, the
		/// default, it always runs in
		/// <see cref="ComponentInfo.processName">ComponentInfo.processName</see>
		/// .  Set from the
		/// <see cref="android.R.attr.multiprocess">android.R.attr.multiprocess</see>
		/// attribute.
		/// </summary>
		public const int FLAG_MULTIPROCESS = unchecked((int)(0x0001));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// indicating that, when the activity's task is
		/// relaunched from home, this activity should be finished.
		/// Set from the
		/// <see cref="android.R.attr.finishOnTaskLaunch">android.R.attr.finishOnTaskLaunch</see>
		/// attribute.
		/// </summary>
		public const int FLAG_FINISH_ON_TASK_LAUNCH = unchecked((int)(0x0002));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// indicating that, when the activity is the root
		/// of a task, that task's stack should be cleared each time the user
		/// re-launches it from home.  As a result, the user will always
		/// return to the original activity at the top of the task.
		/// This flag only applies to activities that
		/// are used to start the root of a new task.  Set from the
		/// <see cref="android.R.attr.clearTaskOnLaunch">android.R.attr.clearTaskOnLaunch</see>
		/// attribute.
		/// </summary>
		public const int FLAG_CLEAR_TASK_ON_LAUNCH = unchecked((int)(0x0004));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// indicating that, when the activity is the root
		/// of a task, that task's stack should never be cleared when it is
		/// relaunched from home.  Set from the
		/// <see cref="android.R.attr.alwaysRetainTaskState">android.R.attr.alwaysRetainTaskState
		/// 	</see>
		/// attribute.
		/// </summary>
		public const int FLAG_ALWAYS_RETAIN_TASK_STATE = unchecked((int)(0x0008));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// indicating that the activity's state
		/// is not required to be saved, so that if there is a failure the
		/// activity will not be removed from the activity stack.  Set from the
		/// <see cref="android.R.attr.stateNotNeeded">android.R.attr.stateNotNeeded</see>
		/// attribute.
		/// </summary>
		public const int FLAG_STATE_NOT_NEEDED = unchecked((int)(0x0010));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// that indicates that the activity should not
		/// appear in the list of recently launched activities.  Set from the
		/// <see cref="android.R.attr.excludeFromRecents">android.R.attr.excludeFromRecents</see>
		/// attribute.
		/// </summary>
		public const int FLAG_EXCLUDE_FROM_RECENTS = unchecked((int)(0x0020));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// that indicates that the activity can be moved
		/// between tasks based on its task affinity.  Set from the
		/// <see cref="android.R.attr.allowTaskReparenting">android.R.attr.allowTaskReparenting
		/// 	</see>
		/// attribute.
		/// </summary>
		public const int FLAG_ALLOW_TASK_REPARENTING = unchecked((int)(0x0040));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// indicating that, when the user navigates away
		/// from an activity, it should be finished.
		/// Set from the
		/// <see cref="android.R.attr.noHistory">android.R.attr.noHistory</see>
		/// attribute.
		/// </summary>
		public const int FLAG_NO_HISTORY = unchecked((int)(0x0080));

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// indicating that, when a request to close system
		/// windows happens, this activity is finished.
		/// Set from the
		/// <see cref="android.R.attr.finishOnCloseSystemDialogs">android.R.attr.finishOnCloseSystemDialogs
		/// 	</see>
		/// attribute.
		/// </summary>
		public const int FLAG_FINISH_ON_CLOSE_SYSTEM_DIALOGS = unchecked((int)(0x0100));

		/// <summary>
		/// Value for
		/// <see cref="flags">flags</see>
		/// : true when the application's rendering should
		/// be hardware accelerated.
		/// </summary>
		public const int FLAG_HARDWARE_ACCELERATED = unchecked((int)(0x0200));

		/// <hide>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// corresponding to an immersive activity
		/// that wishes not to be interrupted by notifications.
		/// Applications that hide the system notification bar with
		/// <see cref="android.view.WindowManagerClass.LayoutParams.FLAG_FULLSCREEN">android.view.WindowManagerClass.LayoutParams.FLAG_FULLSCREEN
		/// 	</see>
		/// may still be interrupted by high-priority notifications; for example, an
		/// incoming phone call may use
		/// <see cref="android.app.Notification.fullScreenIntent">fullScreenIntent</see>
		/// to present a full-screen in-call activity to the user, pausing the
		/// current activity as a side-effect. An activity with
		/// <see cref="FLAG_IMMERSIVE">FLAG_IMMERSIVE</see>
		/// set, however, will not be interrupted; the
		/// notification may be shown in some other way (such as a small floating
		/// "toast" window).
		/// <seealso>android.app.Notification#FLAG_HIGH_PRIORITY</seealso>
		/// </hide>
		public const int FLAG_IMMERSIVE = unchecked((int)(0x0400));

		/// <summary>
		/// Options that have been set in the activity declaration in the
		/// manifest.
		/// </summary>
		/// <remarks>
		/// Options that have been set in the activity declaration in the
		/// manifest.
		/// These include:
		/// <see cref="FLAG_MULTIPROCESS">FLAG_MULTIPROCESS</see>
		/// ,
		/// <see cref="FLAG_FINISH_ON_TASK_LAUNCH">FLAG_FINISH_ON_TASK_LAUNCH</see>
		/// ,
		/// <see cref="FLAG_CLEAR_TASK_ON_LAUNCH">FLAG_CLEAR_TASK_ON_LAUNCH</see>
		/// ,
		/// <see cref="FLAG_ALWAYS_RETAIN_TASK_STATE">FLAG_ALWAYS_RETAIN_TASK_STATE</see>
		/// ,
		/// <see cref="FLAG_STATE_NOT_NEEDED">FLAG_STATE_NOT_NEEDED</see>
		/// ,
		/// <see cref="FLAG_EXCLUDE_FROM_RECENTS">FLAG_EXCLUDE_FROM_RECENTS</see>
		/// ,
		/// <see cref="FLAG_ALLOW_TASK_REPARENTING">FLAG_ALLOW_TASK_REPARENTING</see>
		/// ,
		/// <see cref="FLAG_NO_HISTORY">FLAG_NO_HISTORY</see>
		/// ,
		/// <see cref="FLAG_FINISH_ON_CLOSE_SYSTEM_DIALOGS">FLAG_FINISH_ON_CLOSE_SYSTEM_DIALOGS
		/// 	</see>
		/// ,
		/// <see cref="FLAG_HARDWARE_ACCELERATED">FLAG_HARDWARE_ACCELERATED</see>
		/// </remarks>
		public int flags;

		/// <summary>
		/// Constant corresponding to <code>unspecified</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_UNSPECIFIED = -1;

		/// <summary>
		/// Constant corresponding to <code>landscape</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_LANDSCAPE = 0;

		/// <summary>
		/// Constant corresponding to <code>portrait</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_PORTRAIT = 1;

		/// <summary>
		/// Constant corresponding to <code>user</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_USER = 2;

		/// <summary>
		/// Constant corresponding to <code>behind</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_BEHIND = 3;

		/// <summary>
		/// Constant corresponding to <code>sensor</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_SENSOR = 4;

		/// <summary>
		/// Constant corresponding to <code>nosensor</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_NOSENSOR = 5;

		/// <summary>
		/// Constant corresponding to <code>sensorLandscape</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_SENSOR_LANDSCAPE = 6;

		/// <summary>
		/// Constant corresponding to <code>sensorPortrait</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_SENSOR_PORTRAIT = 7;

		/// <summary>
		/// Constant corresponding to <code>reverseLandscape</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_REVERSE_LANDSCAPE = 8;

		/// <summary>
		/// Constant corresponding to <code>reversePortrait</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_REVERSE_PORTRAIT = 9;

		/// <summary>
		/// Constant corresponding to <code>fullSensor</code> in
		/// the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute.
		/// </summary>
		public const int SCREEN_ORIENTATION_FULL_SENSOR = 10;

		/// <summary>The preferred screen orientation this activity would like to run in.</summary>
		/// <remarks>
		/// The preferred screen orientation this activity would like to run in.
		/// From the
		/// <see cref="android.R.attr.screenOrientation">android.R.attr.screenOrientation</see>
		/// attribute, one of
		/// <see cref="SCREEN_ORIENTATION_UNSPECIFIED">SCREEN_ORIENTATION_UNSPECIFIED</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_LANDSCAPE">SCREEN_ORIENTATION_LANDSCAPE</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_PORTRAIT">SCREEN_ORIENTATION_PORTRAIT</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_USER">SCREEN_ORIENTATION_USER</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_BEHIND">SCREEN_ORIENTATION_BEHIND</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_SENSOR">SCREEN_ORIENTATION_SENSOR</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_NOSENSOR">SCREEN_ORIENTATION_NOSENSOR</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_SENSOR_LANDSCAPE">SCREEN_ORIENTATION_SENSOR_LANDSCAPE
		/// 	</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_SENSOR_PORTRAIT">SCREEN_ORIENTATION_SENSOR_PORTRAIT
		/// 	</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_REVERSE_LANDSCAPE">SCREEN_ORIENTATION_REVERSE_LANDSCAPE
		/// 	</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_REVERSE_PORTRAIT">SCREEN_ORIENTATION_REVERSE_PORTRAIT
		/// 	</see>
		/// ,
		/// <see cref="SCREEN_ORIENTATION_FULL_SENSOR">SCREEN_ORIENTATION_FULL_SENSOR</see>
		/// .
		/// </remarks>
		public int screenOrientation = SCREEN_ORIENTATION_UNSPECIFIED;

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the IMSI MCC.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_MCC = unchecked((int)(0x0001));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the IMSI MNC.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_MNC = unchecked((int)(0x0002));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the locale.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_LOCALE = unchecked((int)(0x0004));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the touchscreen type.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_TOUCHSCREEN = unchecked((int)(0x0008));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the keyboard type.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_KEYBOARD = unchecked((int)(0x0010));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the keyboard or navigation being hidden/exposed.
		/// Note that inspite of the name, this applies to the changes to any
		/// hidden states: keyboard or navigation.
		/// Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_KEYBOARD_HIDDEN = unchecked((int)(0x0020));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the navigation type.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_NAVIGATION = unchecked((int)(0x0040));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the screen orientation.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_ORIENTATION = unchecked((int)(0x0080));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the screen layout.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_SCREEN_LAYOUT = unchecked((int)(0x0100));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle the ui mode. Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </summary>
		public const int CONFIG_UI_MODE = unchecked((int)(0x0200));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle the screen size. Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.  This will be
		/// set by default for applications that target an earlier version
		/// than
		/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB_MR2">android.os.Build.VERSION_CODES.HONEYCOMB_MR2
		/// 	</see>
		/// ...
		/// <b>however</b>, you will not see the bit set here becomes some
		/// applications incorrectly compare
		/// <see cref="configChanges">configChanges</see>
		/// against
		/// an absolute value rather than correctly masking out the bits
		/// they are interested in.  Please don't do that, thanks.
		/// </summary>
		public const int CONFIG_SCREEN_SIZE = unchecked((int)(0x0400));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle the smallest screen size. Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.  This will be
		/// set by default for applications that target an earlier version
		/// than
		/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB_MR2">android.os.Build.VERSION_CODES.HONEYCOMB_MR2
		/// 	</see>
		/// ...
		/// <b>however</b>, you will not see the bit set here becomes some
		/// applications incorrectly compare
		/// <see cref="configChanges">configChanges</see>
		/// against
		/// an absolute value rather than correctly masking out the bits
		/// they are interested in.  Please don't do that, thanks.
		/// </summary>
		public const int CONFIG_SMALLEST_SCREEN_SIZE = unchecked((int)(0x0800));

		/// <summary>
		/// Bit in
		/// <see cref="configChanges">configChanges</see>
		/// that indicates that the activity
		/// can itself handle changes to the font scaling factor.  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.  This is
		/// not a core resource configutation, but a higher-level value, so its
		/// constant starts at the high bits.
		/// </summary>
		public const int CONFIG_FONT_SCALE = unchecked((int)(0x40000000));

		/// <hide>
		/// Unfortunately the constants for config changes in native code are
		/// different from ActivityInfo. :(  Here are the values we should use for the
		/// native side given the bit we have assigned in ActivityInfo.
		/// </hide>
		public static int[] CONFIG_NATIVE_BITS = new int[] { unchecked((int)(0x0001)), unchecked(
			(int)(0x0002)), unchecked((int)(0x0004)), unchecked((int)(0x0008)), unchecked((int
			)(0x0010)), unchecked((int)(0x0020)), unchecked((int)(0x0040)), unchecked((int)(
			0x0080)), unchecked((int)(0x0800)), unchecked((int)(0x1000)), unchecked((int)(0x0200
			)), unchecked((int)(0x2000)) };

		// MNC
		// MCC
		// LOCALE
		// TOUCH SCREEN
		// KEYBOARD
		// KEYBOARD HIDDEN
		// NAVIGATION
		// ORIENTATION
		// SCREEN LAYOUT
		// UI MODE
		// SCREEN SIZE
		// SMALLEST SCREEN SIZE
		/// <hide>Convert Java change bits to native.</hide>
		public static int activityInfoConfigToNative(int input)
		{
			int output = 0;
			{
				for (int i = 0; i < CONFIG_NATIVE_BITS.Length; i++)
				{
					if ((input & (1 << i)) != 0)
					{
						output |= CONFIG_NATIVE_BITS[i];
					}
				}
			}
			return output;
		}

		/// <hide>
		/// Unfortunately some developers (OpenFeint I am looking at you) have
		/// compared the configChanges bit field against absolute values, so if we
		/// introduce a new bit they break.  To deal with that, we will make sure
		/// the public field will not have a value that breaks them, and let the
		/// framework call here to get the real value.
		/// </hide>
		public virtual int getRealConfigChanged()
		{
			return applicationInfo.targetSdkVersion < android.os.Build.VERSION_CODES.HONEYCOMB_MR2
				 ? (configChanges | android.content.pm.ActivityInfo.CONFIG_SCREEN_SIZE | android.content.pm.ActivityInfo
				.CONFIG_SMALLEST_SCREEN_SIZE) : configChanges;
		}

		/// <summary>
		/// Bit mask of kinds of configuration changes that this activity
		/// can handle itself (without being restarted by the system).
		/// </summary>
		/// <remarks>
		/// Bit mask of kinds of configuration changes that this activity
		/// can handle itself (without being restarted by the system).
		/// Contains any combination of
		/// <see cref="CONFIG_FONT_SCALE">CONFIG_FONT_SCALE</see>
		/// ,
		/// <see cref="CONFIG_MCC">CONFIG_MCC</see>
		/// ,
		/// <see cref="CONFIG_MNC">CONFIG_MNC</see>
		/// ,
		/// <see cref="CONFIG_LOCALE">CONFIG_LOCALE</see>
		/// ,
		/// <see cref="CONFIG_TOUCHSCREEN">CONFIG_TOUCHSCREEN</see>
		/// ,
		/// <see cref="CONFIG_KEYBOARD">CONFIG_KEYBOARD</see>
		/// ,
		/// <see cref="CONFIG_NAVIGATION">CONFIG_NAVIGATION</see>
		/// ,
		/// <see cref="CONFIG_ORIENTATION">CONFIG_ORIENTATION</see>
		/// , and
		/// <see cref="CONFIG_SCREEN_LAYOUT">CONFIG_SCREEN_LAYOUT</see>
		/// .  Set from the
		/// <see cref="android.R.attr.configChanges">android.R.attr.configChanges</see>
		/// attribute.
		/// </remarks>
		public int configChanges;

		/// <summary>The desired soft input mode for this activity's main window.</summary>
		/// <remarks>
		/// The desired soft input mode for this activity's main window.
		/// Set from the
		/// <see cref="android.R.attr.windowSoftInputMode">android.R.attr.windowSoftInputMode
		/// 	</see>
		/// attribute
		/// in the activity's manifest.  May be any of the same values allowed
		/// for
		/// <see cref="android.view.WindowManagerClass.LayoutParams.softInputMode">WindowManager.LayoutParams.softInputMode
		/// 	</see>
		/// .  If 0 (unspecified),
		/// the mode from the theme will be used.
		/// </remarks>
		public int softInputMode;

		/// <summary>The desired extra UI options for this activity and its main window.</summary>
		/// <remarks>
		/// The desired extra UI options for this activity and its main window.
		/// Set from the
		/// <see cref="android.R.attr.uiOptions">android.R.attr.uiOptions</see>
		/// attribute in the
		/// activity's manifest.
		/// </remarks>
		public int uiOptions = 0;

		/// <summary>
		/// Flag for use with
		/// <see cref="uiOptions">uiOptions</see>
		/// .
		/// Indicates that the action bar should put all action items in a separate bar when
		/// the screen is narrow.
		/// <p>This value corresponds to "splitActionBarWhenNarrow" for the
		/// <see cref="uiOptions">uiOptions</see>
		/// XML
		/// attribute.
		/// </summary>
		public const int UIOPTION_SPLIT_ACTION_BAR_WHEN_NARROW = 1;

		public ActivityInfo()
		{
		}

		public ActivityInfo(android.content.pm.ActivityInfo orig) : base(orig)
		{
			theme = orig.theme;
			launchMode = orig.launchMode;
			permission = orig.permission;
			taskAffinity = orig.taskAffinity;
			targetActivity = orig.targetActivity;
			flags = orig.flags;
			screenOrientation = orig.screenOrientation;
			configChanges = orig.configChanges;
			softInputMode = orig.softInputMode;
			uiOptions = orig.uiOptions;
		}

		/// <summary>Return the theme resource identifier to use for this activity.</summary>
		/// <remarks>
		/// Return the theme resource identifier to use for this activity.  If
		/// the activity defines a theme, that is used; else, the application
		/// theme is used.
		/// </remarks>
		/// <returns>The theme associated with this activity.</returns>
		public int getThemeResource()
		{
			return theme != 0 ? theme : applicationInfo.theme;
		}

		public virtual void dump(android.util.Printer pw, string prefix)
		{
			base.dumpFront(pw, prefix);
			if (permission != null)
			{
				pw.println(prefix + "permission=" + permission);
			}
			pw.println(prefix + "taskAffinity=" + taskAffinity + " targetActivity=" + targetActivity
				);
			if (launchMode != 0 || flags != 0 || theme != 0)
			{
				pw.println(prefix + "launchMode=" + launchMode + " flags=0x" + Sharpen.Util.IntToHexString
					(flags) + " theme=0x" + Sharpen.Util.IntToHexString(theme));
			}
			if (screenOrientation != SCREEN_ORIENTATION_UNSPECIFIED || configChanges != 0 || 
				softInputMode != 0)
			{
				pw.println(prefix + "screenOrientation=" + screenOrientation + " configChanges=0x"
					 + Sharpen.Util.IntToHexString(configChanges) + " softInputMode=0x" + Sharpen.Util.IntToHexString
					(softInputMode));
			}
			if (uiOptions != 0)
			{
				pw.println(prefix + " uiOptions=0x" + Sharpen.Util.IntToHexString(uiOptions));
			}
			base.dumpBack(pw, prefix);
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ActivityInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
				(this)) + " " + name + "}";
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
			dest.writeInt(theme);
			dest.writeInt(launchMode);
			dest.writeString(permission);
			dest.writeString(taskAffinity);
			dest.writeString(targetActivity);
			dest.writeInt(flags);
			dest.writeInt(screenOrientation);
			dest.writeInt(configChanges);
			dest.writeInt(softInputMode);
			dest.writeInt(uiOptions);
		}

		private sealed class _Creator_530 : android.os.ParcelableClass.Creator<android.content.pm.ActivityInfo
			>
		{
			public _Creator_530()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ActivityInfo createFromParcel(android.os.Parcel source)
			{
				return new android.content.pm.ActivityInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ActivityInfo[] newArray(int size)
			{
				return new android.content.pm.ActivityInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ActivityInfo
			> CREATOR = new _Creator_530();

		private ActivityInfo(android.os.Parcel source) : base(source)
		{
			theme = source.readInt();
			launchMode = source.readInt();
			permission = source.readString();
			taskAffinity = source.readString();
			targetActivity = source.readString();
			flags = source.readInt();
			screenOrientation = source.readInt();
			configChanges = source.readInt();
			softInputMode = source.readInt();
			uiOptions = source.readInt();
		}
	}
}
