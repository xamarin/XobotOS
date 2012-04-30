using Sharpen;

namespace android
{
	[Sharpen.Sharpened]
	public sealed class Manifest
	{
		public sealed class permission
		{
			/// <summary>Allow an application to read and write the cache partition.</summary>
			/// <remarks>Allow an application to read and write the cache partition.</remarks>
			/// <hide></hide>
			public const string ACCESS_CACHE_FILESYSTEM = "android.permission.ACCESS_CACHE_FILESYSTEM";

			/// <summary>
			/// Allows read/write access to the "properties" table in the checkin
			/// database, to change values that get uploaded.
			/// </summary>
			/// <remarks>
			/// Allows read/write access to the "properties" table in the checkin
			/// database, to change values that get uploaded.
			/// </remarks>
			public const string ACCESS_CHECKIN_PROPERTIES = "android.permission.ACCESS_CHECKIN_PROPERTIES";

			/// <summary>Allows an application to access coarse (e.g., Cell-ID, WiFi) location</summary>
			public const string ACCESS_COARSE_LOCATION = "android.permission.ACCESS_COARSE_LOCATION";

			/// <summary>Allows an application to access fine (e.g., GPS) location</summary>
			public const string ACCESS_FINE_LOCATION = "android.permission.ACCESS_FINE_LOCATION";

			/// <summary>Allows an application to access extra location provider commands</summary>
			public const string ACCESS_LOCATION_EXTRA_COMMANDS = "android.permission.ACCESS_LOCATION_EXTRA_COMMANDS";

			/// <summary>Allows an application to create mock location providers for testing</summary>
			public const string ACCESS_MOCK_LOCATION = "android.permission.ACCESS_MOCK_LOCATION";

			/// <summary>Allows an application to access the MTP USB kernel driver.</summary>
			/// <remarks>
			/// Allows an application to access the MTP USB kernel driver.
			/// For use only by the device side MTP implementation.
			/// </remarks>
			/// <hide></hide>
			public const string ACCESS_MTP = "android.permission.ACCESS_MTP";

			/// <summary>Allows applications to access information about networks</summary>
			public const string ACCESS_NETWORK_STATE = "android.permission.ACCESS_NETWORK_STATE";

			/// <summary>Allows an application to use SurfaceFlinger's low level features</summary>
			public const string ACCESS_SURFACE_FLINGER = "android.permission.ACCESS_SURFACE_FLINGER";

			/// <summary>Allows applications to access information about Wi-Fi networks</summary>
			public const string ACCESS_WIFI_STATE = "android.permission.ACCESS_WIFI_STATE";

			/// <summary>Allows applications to call into AccountAuthenticators.</summary>
			/// <remarks>
			/// Allows applications to call into AccountAuthenticators. Only
			/// the system can get this permission.
			/// </remarks>
			public const string ACCOUNT_MANAGER = "android.permission.ACCOUNT_MANAGER";

			/// <summary>Allows an application to add voicemails into the system.</summary>
			/// <remarks>Allows an application to add voicemails into the system.</remarks>
			public const string ADD_VOICEMAIL = "com.android.voicemail.permission.ADD_VOICEMAIL";

			/// <summary>Allows access to ASEC non-destructive API calls</summary>
			/// <hide></hide>
			public const string ASEC_ACCESS = "android.permission.ASEC_ACCESS";

			/// <summary>Allows creation of ASEC volumes</summary>
			/// <hide></hide>
			public const string ASEC_CREATE = "android.permission.ASEC_CREATE";

			/// <summary>Allows destruction of ASEC volumes</summary>
			/// <hide></hide>
			public const string ASEC_DESTROY = "android.permission.ASEC_DESTROY";

			/// <summary>Allows mount / unmount of ASEC volumes</summary>
			/// <hide></hide>
			public const string ASEC_MOUNT_UNMOUNT = "android.permission.ASEC_MOUNT_UNMOUNT";

			/// <summary>Allows rename of ASEC volumes</summary>
			/// <hide></hide>
			public const string ASEC_RENAME = "android.permission.ASEC_RENAME";

			/// <summary>
			/// Allows an application to act as an AccountAuthenticator for
			/// the AccountManager
			/// </summary>
			public const string AUTHENTICATE_ACCOUNTS = "android.permission.AUTHENTICATE_ACCOUNTS";

			/// <summary>Allows an application to control the backup and restore process</summary>
			/// <hide>pending API council</hide>
			public const string BACKUP = "android.permission.BACKUP";

			/// <summary>Allows an application to collect battery statistics</summary>
			public const string BATTERY_STATS = "android.permission.BATTERY_STATS";

			/// <summary>
			/// Allows an application to tell the AppWidget service which application
			/// can access AppWidget's data.
			/// </summary>
			/// <remarks>
			/// Allows an application to tell the AppWidget service which application
			/// can access AppWidget's data.  The normal user flow is that a user
			/// picks an AppWidget to go into a particular host, thereby giving that
			/// host application access to the private data from the AppWidget app.
			/// An application that has this permission should honor that contract.
			/// Very few applications should need to use this permission.
			/// </remarks>
			public const string BIND_APPWIDGET = "android.permission.BIND_APPWIDGET";

			/// <summary>
			/// Must be required by device administration receiver, to ensure that only the
			/// system can interact with it.
			/// </summary>
			/// <remarks>
			/// Must be required by device administration receiver, to ensure that only the
			/// system can interact with it.
			/// </remarks>
			public const string BIND_DEVICE_ADMIN = "android.permission.BIND_DEVICE_ADMIN";

			/// <summary>
			/// Must be required by an
			/// <see cref="android.inputmethodservice.InputMethodService">android.inputmethodservice.InputMethodService
			/// 	</see>
			/// ,
			/// to ensure that only the system can bind to it.
			/// </summary>
			public const string BIND_INPUT_METHOD = "android.permission.BIND_INPUT_METHOD";

			/// <summary>
			/// Must be required by package verifier receiver, to ensure that only the
			/// system can interact with it.
			/// </summary>
			/// <remarks>
			/// Must be required by package verifier receiver, to ensure that only the
			/// system can interact with it.
			/// </remarks>
			/// <hide></hide>
			public const string BIND_PACKAGE_VERIFIER = "android.permission.BIND_PACKAGE_VERIFIER";

			/// <summary>
			/// Must be required by a
			/// <see cref="android.widget.RemoteViewsService">android.widget.RemoteViewsService</see>
			/// ,
			/// to ensure that only the system can bind to it.
			/// </summary>
			public const string BIND_REMOTEVIEWS = "android.permission.BIND_REMOTEVIEWS";

			/// <summary>Must be required by a TextService (e.g.</summary>
			/// <remarks>
			/// Must be required by a TextService (e.g. SpellCheckerService)
			/// to ensure that only the system can bind to it.
			/// </remarks>
			public const string BIND_TEXT_SERVICE = "android.permission.BIND_TEXT_SERVICE";

			/// <summary>
			/// Must be required by an
			/// <see cref="android.net.VpnService">android.net.VpnService</see>
			/// ,
			/// to ensure that only the system can bind to it.
			/// </summary>
			public const string BIND_VPN_SERVICE = "android.permission.BIND_VPN_SERVICE";

			/// <summary>
			/// Must be required by a
			/// <see cref="android.service.wallpaper.WallpaperService">android.service.wallpaper.WallpaperService
			/// 	</see>
			/// ,
			/// to ensure that only the system can bind to it.
			/// </summary>
			public const string BIND_WALLPAPER = "android.permission.BIND_WALLPAPER";

			/// <summary>Allows applications to connect to paired bluetooth devices</summary>
			public const string BLUETOOTH = "android.permission.BLUETOOTH";

			/// <summary>Allows applications to discover and pair bluetooth devices</summary>
			public const string BLUETOOTH_ADMIN = "android.permission.BLUETOOTH_ADMIN";

			/// <summary>Required to be able to disable the device (very dangerous!).</summary>
			/// <remarks>Required to be able to disable the device (very dangerous!).</remarks>
			public const string BRICK = "android.permission.BRICK";

			/// <summary>
			/// Allows an application to broadcast a notification that an application
			/// package has been removed.
			/// </summary>
			/// <remarks>
			/// Allows an application to broadcast a notification that an application
			/// package has been removed.
			/// </remarks>
			public const string BROADCAST_PACKAGE_REMOVED = "android.permission.BROADCAST_PACKAGE_REMOVED";

			/// <summary>Allows an application to broadcast an SMS receipt notification</summary>
			public const string BROADCAST_SMS = "android.permission.BROADCAST_SMS";

			/// <summary>Allows an application to broadcast sticky intents.</summary>
			/// <remarks>
			/// Allows an application to broadcast sticky intents.  These are
			/// broadcasts whose data is held by the system after being finished,
			/// so that clients can quickly retrieve that data without having
			/// to wait for the next broadcast.
			/// </remarks>
			public const string BROADCAST_STICKY = "android.permission.BROADCAST_STICKY";

			/// <summary>Allows an application to broadcast a WAP PUSH receipt notification</summary>
			public const string BROADCAST_WAP_PUSH = "android.permission.BROADCAST_WAP_PUSH";

			/// <summary>C2DM permission.</summary>
			/// <remarks>C2DM permission.</remarks>
			/// <hide>Used internally.</hide>
			public const string C2D_MESSAGE = "android.intent.category.MASTER_CLEAR.permission.C2D_MESSAGE";

			/// <summary>
			/// Allows an application to initiate a phone call without going through
			/// the Dialer user interface for the user to confirm the call
			/// being placed.
			/// </summary>
			/// <remarks>
			/// Allows an application to initiate a phone call without going through
			/// the Dialer user interface for the user to confirm the call
			/// being placed.
			/// </remarks>
			public const string CALL_PHONE = "android.permission.CALL_PHONE";

			/// <summary>
			/// Allows an application to call any phone number, including emergency
			/// numbers, without going through the Dialer user interface for the user
			/// to confirm the call being placed.
			/// </summary>
			/// <remarks>
			/// Allows an application to call any phone number, including emergency
			/// numbers, without going through the Dialer user interface for the user
			/// to confirm the call being placed.
			/// </remarks>
			public const string CALL_PRIVILEGED = "android.permission.CALL_PRIVILEGED";

			/// <summary>Required to be able to access the camera device.</summary>
			/// <remarks>
			/// Required to be able to access the camera device.
			/// <p>This will automatically enforce the &lt;a
			/// href="
			/// <docRoot></docRoot>
			/// guide/topics/manifest/uses-feature-element.html"&gt;
			/// <code>&lt;uses-feature&gt;</code>
			/// </a> manifest element for <em>all</em> camera features.
			/// If you do not require all camera features or can properly operate if a camera
			/// is not available, then you must modify your manifest as appropriate in order to
			/// install on devices that don't support all camera features.</p>
			/// </remarks>
			public const string CAMERA = "android.permission.CAMERA";

			/// <summary>Allows applications to change the background data setting</summary>
			/// <hide>pending API council</hide>
			public const string CHANGE_BACKGROUND_DATA_SETTING = "android.permission.CHANGE_BACKGROUND_DATA_SETTING";

			/// <summary>
			/// Allows an application to change whether an application component (other than its own) is
			/// enabled or not.
			/// </summary>
			/// <remarks>
			/// Allows an application to change whether an application component (other than its own) is
			/// enabled or not.
			/// </remarks>
			public const string CHANGE_COMPONENT_ENABLED_STATE = "android.permission.CHANGE_COMPONENT_ENABLED_STATE";

			/// <summary>
			/// Allows an application to modify the current configuration, such
			/// as locale.
			/// </summary>
			/// <remarks>
			/// Allows an application to modify the current configuration, such
			/// as locale.
			/// </remarks>
			public const string CHANGE_CONFIGURATION = "android.permission.CHANGE_CONFIGURATION";

			/// <summary>Allows applications to change network connectivity state</summary>
			public const string CHANGE_NETWORK_STATE = "android.permission.CHANGE_NETWORK_STATE";

			/// <summary>Allows applications to enter Wi-Fi Multicast mode</summary>
			public const string CHANGE_WIFI_MULTICAST_STATE = "android.permission.CHANGE_WIFI_MULTICAST_STATE";

			/// <summary>Allows applications to change Wi-Fi connectivity state</summary>
			public const string CHANGE_WIFI_STATE = "android.permission.CHANGE_WIFI_STATE";

			/// <summary>
			/// Allows an application to clear the caches of all installed
			/// applications on the device.
			/// </summary>
			/// <remarks>
			/// Allows an application to clear the caches of all installed
			/// applications on the device.
			/// </remarks>
			public const string CLEAR_APP_CACHE = "android.permission.CLEAR_APP_CACHE";

			/// <summary>Allows an application to clear user data</summary>
			public const string CLEAR_APP_USER_DATA = "android.permission.CLEAR_APP_USER_DATA";

			/// <summary>Allows a package to launch the secure full-backup confirmation UI.</summary>
			/// <remarks>
			/// Allows a package to launch the secure full-backup confirmation UI.
			/// ONLY the system process may hold this permission.
			/// </remarks>
			/// <hide></hide>
			public const string CONFIRM_FULL_BACKUP = "android.permission.CONFIRM_FULL_BACKUP";

			/// <summary>
			/// Allows an internal user to use privaledged ConnectivityManager
			/// APIs.
			/// </summary>
			/// <remarks>
			/// Allows an internal user to use privaledged ConnectivityManager
			/// APIs.
			/// </remarks>
			/// <hide></hide>
			public const string CONNECTIVITY_INTERNAL = "android.permission.CONNECTIVITY_INTERNAL";

			/// <summary>
			/// Allows enabling/disabling location update notifications from
			/// the radio.
			/// </summary>
			/// <remarks>
			/// Allows enabling/disabling location update notifications from
			/// the radio. Not for use by normal applications.
			/// </remarks>
			public const string CONTROL_LOCATION_UPDATES = "android.permission.CONTROL_LOCATION_UPDATES";

			/// <summary>
			/// Must be required by default container service so that only
			/// the system can bind to it and use it to copy
			/// protected data to secure containers or files
			/// accessible to the system.
			/// </summary>
			/// <remarks>
			/// Must be required by default container service so that only
			/// the system can bind to it and use it to copy
			/// protected data to secure containers or files
			/// accessible to the system.
			/// </remarks>
			/// <hide></hide>
			public const string COPY_PROTECTED_DATA = "android.permission.COPY_PROTECTED_DATA";

			/// <summary>Internal permission protecting access to the encryption methods</summary>
			/// <hide></hide>
			public const string CRYPT_KEEPER = "android.permission.CRYPT_KEEPER";

			/// <summary>Allows an application to delete cache files.</summary>
			/// <remarks>Allows an application to delete cache files.</remarks>
			public const string DELETE_CACHE_FILES = "android.permission.DELETE_CACHE_FILES";

			/// <summary>Allows an application to delete packages.</summary>
			/// <remarks>Allows an application to delete packages.</remarks>
			public const string DELETE_PACKAGES = "android.permission.DELETE_PACKAGES";

			/// <summary>Allows low-level access to power management</summary>
			public const string DEVICE_POWER = "android.permission.DEVICE_POWER";

			/// <summary>Allows applications to RW to diagnostic resources.</summary>
			/// <remarks>Allows applications to RW to diagnostic resources.</remarks>
			public const string DIAGNOSTIC = "android.permission.DIAGNOSTIC";

			/// <summary>Allows applications to disable the keyguard</summary>
			public const string DISABLE_KEYGUARD = "android.permission.DISABLE_KEYGUARD";

			/// <summary>
			/// Allows an application to retrieve state dump information from system
			/// services.
			/// </summary>
			/// <remarks>
			/// Allows an application to retrieve state dump information from system
			/// services.
			/// </remarks>
			public const string DUMP = "android.permission.DUMP";

			/// <summary>Allows an application to expand or collapse the status bar.</summary>
			/// <remarks>Allows an application to expand or collapse the status bar.</remarks>
			public const string EXPAND_STATUS_BAR = "android.permission.EXPAND_STATUS_BAR";

			/// <summary>Run as a manufacturer test application, running as the root user.</summary>
			/// <remarks>
			/// Run as a manufacturer test application, running as the root user.
			/// Only available when the device is running in manufacturer test mode.
			/// </remarks>
			public const string FACTORY_TEST = "android.permission.FACTORY_TEST";

			/// <summary>Allows access to the flashlight</summary>
			public const string FLASHLIGHT = "android.permission.FLASHLIGHT";

			/// <summary>
			/// Allows an application to force a BACK operation on whatever is the
			/// top activity.
			/// </summary>
			/// <remarks>
			/// Allows an application to force a BACK operation on whatever is the
			/// top activity.
			/// </remarks>
			public const string FORCE_BACK = "android.permission.FORCE_BACK";

			/// <summary>
			/// Allows an application to call
			/// <see cref="android.app.ActivityManager.forceStopPackage(string)">android.app.ActivityManager.forceStopPackage(string)
			/// 	</see>
			/// .
			/// </summary>
			/// <hide></hide>
			public const string FORCE_STOP_PACKAGES = "android.permission.FORCE_STOP_PACKAGES";

			/// <summary>Allows access to the list of accounts in the Accounts Service</summary>
			public const string GET_ACCOUNTS = "android.permission.GET_ACCOUNTS";

			/// <summary>Allows an application to find out the space used by any package.</summary>
			/// <remarks>Allows an application to find out the space used by any package.</remarks>
			public const string GET_PACKAGE_SIZE = "android.permission.GET_PACKAGE_SIZE";

			/// <summary>
			/// Allows an application to get information about the currently
			/// or recently running tasks: a thumbnail representation of the tasks,
			/// what activities are running in it, etc.
			/// </summary>
			/// <remarks>
			/// Allows an application to get information about the currently
			/// or recently running tasks: a thumbnail representation of the tasks,
			/// what activities are running in it, etc.
			/// </remarks>
			public const string GET_TASKS = "android.permission.GET_TASKS";

			/// <summary>
			/// This permission can be used on content providers to allow the global
			/// search system to access their data.
			/// </summary>
			/// <remarks>
			/// This permission can be used on content providers to allow the global
			/// search system to access their data.  Typically it used when the
			/// provider has some permissions protecting it (which global search
			/// would not be expected to hold), and added as a read-only permission
			/// to the path in the provider where global search queries are
			/// performed.  This permission can not be held by regular applications;
			/// it is used by applications to protect themselves from everyone else
			/// besides global search.
			/// </remarks>
			public const string GLOBAL_SEARCH = "android.permission.GLOBAL_SEARCH";

			/// <summary>
			/// Internal permission protecting access to the global search
			/// system: ensures that only the system can access the provider
			/// to perform queries (since this otherwise provides unrestricted
			/// access to a variety of content providers), and to write the
			/// search statistics (to keep applications from gaming the source
			/// ranking).
			/// </summary>
			/// <remarks>
			/// Internal permission protecting access to the global search
			/// system: ensures that only the system can access the provider
			/// to perform queries (since this otherwise provides unrestricted
			/// access to a variety of content providers), and to write the
			/// search statistics (to keep applications from gaming the source
			/// ranking).
			/// </remarks>
			/// <hide></hide>
			public const string GLOBAL_SEARCH_CONTROL = "android.permission.GLOBAL_SEARCH_CONTROL";

			/// <summary>Allows access to hardware peripherals.</summary>
			/// <remarks>Allows access to hardware peripherals.  Intended only for hardware testing
			/// 	</remarks>
			public const string HARDWARE_TEST = "android.permission.HARDWARE_TEST";

			/// <summary>
			/// Allows an application to inject user events (keys, touch, trackball)
			/// into the event stream and deliver them to ANY window.
			/// </summary>
			/// <remarks>
			/// Allows an application to inject user events (keys, touch, trackball)
			/// into the event stream and deliver them to ANY window.  Without this
			/// permission, you can only deliver events to windows in your own process.
			/// Very few applications should need to use this permission.
			/// </remarks>
			public const string INJECT_EVENTS = "android.permission.INJECT_EVENTS";

			/// <summary>Allows an application to install a location provider into the Location Manager
			/// 	</summary>
			public const string INSTALL_LOCATION_PROVIDER = "android.permission.INSTALL_LOCATION_PROVIDER";

			/// <summary>Allows an application to install packages.</summary>
			/// <remarks>Allows an application to install packages.</remarks>
			public const string INSTALL_PACKAGES = "android.permission.INSTALL_PACKAGES";

			/// <summary>
			/// Allows an application to open windows that are for use by parts
			/// of the system user interface.
			/// </summary>
			/// <remarks>
			/// Allows an application to open windows that are for use by parts
			/// of the system user interface.  Not for use by third party apps.
			/// </remarks>
			public const string INTERNAL_SYSTEM_WINDOW = "android.permission.INTERNAL_SYSTEM_WINDOW";

			/// <summary>Allows applications to open network sockets.</summary>
			/// <remarks>Allows applications to open network sockets.</remarks>
			public const string INTERNET = "android.permission.INTERNET";

			/// <summary>
			/// Allows an application to call
			/// <see cref="android.app.ActivityManager.killBackgroundProcesses(string)">android.app.ActivityManager.killBackgroundProcesses(string)
			/// 	</see>
			/// .
			/// </summary>
			public const string KILL_BACKGROUND_PROCESSES = "android.permission.KILL_BACKGROUND_PROCESSES";

			/// <summary>Allows an application to manage the list of accounts in the AccountManager
			/// 	</summary>
			public const string MANAGE_ACCOUNTS = "android.permission.MANAGE_ACCOUNTS";

			/// <summary>
			/// Allows an application to manage (create, destroy,
			/// Z-order) application tokens in the window manager.
			/// </summary>
			/// <remarks>
			/// Allows an application to manage (create, destroy,
			/// Z-order) application tokens in the window manager.  This is only
			/// for use by the system.
			/// </remarks>
			public const string MANAGE_APP_TOKENS = "android.permission.MANAGE_APP_TOKENS";

			/// <summary>
			/// Allows an application to manage network policies (such as warning and disable
			/// limits) and to define application-specific rules.
			/// </summary>
			/// <remarks>
			/// Allows an application to manage network policies (such as warning and disable
			/// limits) and to define application-specific rules. @hide
			/// </remarks>
			public const string MANAGE_NETWORK_POLICY = "android.permission.MANAGE_NETWORK_POLICY";

			/// <summary>Allows an application to manage preferences and permissions for USB devices
			/// 	</summary>
			/// <hide></hide>
			public const string MANAGE_USB = "android.permission.MANAGE_USB";

			public const string MASTER_CLEAR = "android.permission.MASTER_CLEAR";

			/// <summary>Allows an application to modify global audio settings</summary>
			public const string MODIFY_AUDIO_SETTINGS = "android.permission.MODIFY_AUDIO_SETTINGS";

			/// <summary>Allows an application to account its network traffic against other UIDs.
			/// 	</summary>
			/// <remarks>
			/// Allows an application to account its network traffic against other UIDs. Used
			/// by system services like download manager and media server. Not for use by
			/// third party apps. @hide
			/// </remarks>
			public const string MODIFY_NETWORK_ACCOUNTING = "android.permission.MODIFY_NETWORK_ACCOUNTING";

			/// <summary>Allows modification of the telephony state - power on, mmi, etc.</summary>
			/// <remarks>
			/// Allows modification of the telephony state - power on, mmi, etc.
			/// Does not include placing calls.
			/// </remarks>
			public const string MODIFY_PHONE_STATE = "android.permission.MODIFY_PHONE_STATE";

			/// <summary>Allows formatting file systems for removable storage.</summary>
			/// <remarks>Allows formatting file systems for removable storage.</remarks>
			public const string MOUNT_FORMAT_FILESYSTEMS = "android.permission.MOUNT_FORMAT_FILESYSTEMS";

			/// <summary>Allows mounting and unmounting file systems for removable storage.</summary>
			/// <remarks>Allows mounting and unmounting file systems for removable storage.</remarks>
			public const string MOUNT_UNMOUNT_FILESYSTEMS = "android.permission.MOUNT_UNMOUNT_FILESYSTEMS";

			/// <summary>Allows an application to move location of installed package.</summary>
			/// <remarks>Allows an application to move location of installed package.</remarks>
			/// <hide></hide>
			public const string MOVE_PACKAGE = "android.permission.MOVE_PACKAGE";

			/// <summary>Allows access to configure network interfaces, configure/use IPSec, etc.
			/// 	</summary>
			/// <remarks>Allows access to configure network interfaces, configure/use IPSec, etc.
			/// 	</remarks>
			/// <hide></hide>
			public const string NET_ADMIN = "android.permission.NET_ADMIN";

			/// <summary>Allows applications to perform I/O operations over NFC</summary>
			public const string NFC = "android.permission.NFC";

			/// <summary>
			/// Allows an application to collect component usage
			/// statistics @hide
			/// </summary>
			public const string PACKAGE_USAGE_STATS = "android.permission.PACKAGE_USAGE_STATS";

			/// <summary>
			/// Package verifier needs to have this permission before the PackageManager will
			/// trust it to verify packages.
			/// </summary>
			/// <remarks>
			/// Package verifier needs to have this permission before the PackageManager will
			/// trust it to verify packages.
			/// </remarks>
			/// <hide></hide>
			public const string PACKAGE_VERIFICATION_AGENT = "android.permission.PACKAGE_VERIFICATION_AGENT";

			/// <summary>Allows an application to perform CDMA OTA provisioning @hide</summary>
			public const string PERFORM_CDMA_PROVISIONING = "android.permission.PERFORM_CDMA_PROVISIONING";

			[System.ObsoleteAttribute(@"This functionality will be removed in the future; please do not use. Allow an application to make its activities persistent."
				)]
			public const string PERSISTENT_ACTIVITY = "android.permission.PERSISTENT_ACTIVITY";

			/// <summary>
			/// Allows an application to monitor, modify, or abort outgoing
			/// calls.
			/// </summary>
			/// <remarks>
			/// Allows an application to monitor, modify, or abort outgoing
			/// calls.
			/// </remarks>
			public const string PROCESS_OUTGOING_CALLS = "android.permission.PROCESS_OUTGOING_CALLS";

			/// <summary>Allows an application to read the user's calendar data.</summary>
			/// <remarks>Allows an application to read the user's calendar data.</remarks>
			public const string READ_CALENDAR = "android.permission.READ_CALENDAR";

			/// <summary>Allows an application to read the user's contacts data.</summary>
			/// <remarks>Allows an application to read the user's contacts data.</remarks>
			public const string READ_CONTACTS = "android.permission.READ_CONTACTS";

			/// <summary>
			/// Allows an application to take screen shots and more generally
			/// get access to the frame buffer data
			/// </summary>
			public const string READ_FRAME_BUFFER = "android.permission.READ_FRAME_BUFFER";

			/// <summary>
			/// Allows an application to read (but not write) the user's
			/// browsing history and bookmarks.
			/// </summary>
			/// <remarks>
			/// Allows an application to read (but not write) the user's
			/// browsing history and bookmarks.
			/// </remarks>
			public const string READ_HISTORY_BOOKMARKS = "com.android.browser.permission.READ_HISTORY_BOOKMARKS";

			/// <summary>
			/// Allows an application to retrieve the current state of keys and
			/// switches.
			/// </summary>
			/// <remarks>
			/// Allows an application to retrieve the current state of keys and
			/// switches.  This is only for use by the system.
			/// </remarks>
			public const string READ_INPUT_STATE = "android.permission.READ_INPUT_STATE";

			/// <summary>Allows an application to read the low-level system log files.</summary>
			/// <remarks>
			/// Allows an application to read the low-level system log files.
			/// Log entries can contain the user's private information,
			/// which is why this permission is 'dangerous'.
			/// </remarks>
			public const string READ_LOGS = "android.permission.READ_LOGS";

			/// <summary>
			/// Allows an application to read historical network usage for
			/// specific networks and applications.
			/// </summary>
			/// <remarks>
			/// Allows an application to read historical network usage for
			/// specific networks and applications. @hide
			/// </remarks>
			public const string READ_NETWORK_USAGE_HISTORY = "android.permission.READ_NETWORK_USAGE_HISTORY";

			/// <summary>Allows read only access to phone state.</summary>
			/// <remarks>Allows read only access to phone state.</remarks>
			public const string READ_PHONE_STATE = "android.permission.READ_PHONE_STATE";

			/// <summary>Allows read access to privileged phone state.</summary>
			/// <remarks>Allows read access to privileged phone state.</remarks>
			/// <hide>Used internally.</hide>
			public const string READ_PRIVILEGED_PHONE_STATE = "android.permission.READ_PRIVILEGED_PHONE_STATE";

			/// <summary>Allows an application to read the user's personal profile data.</summary>
			/// <remarks>Allows an application to read the user's personal profile data.</remarks>
			public const string READ_PROFILE = "android.permission.READ_PROFILE";

			/// <summary>Allows an application to read SMS messages.</summary>
			/// <remarks>Allows an application to read SMS messages.</remarks>
			public const string READ_SMS = "android.permission.READ_SMS";

			/// <summary>Allows an application to read from the user's social stream.</summary>
			/// <remarks>Allows an application to read from the user's social stream.</remarks>
			/// <hide></hide>
			public const string READ_SOCIAL_STREAM = "android.permission.READ_SOCIAL_STREAM";

			/// <summary>Allows applications to read the sync settings</summary>
			public const string READ_SYNC_SETTINGS = "android.permission.READ_SYNC_SETTINGS";

			/// <summary>Allows applications to read the sync stats</summary>
			public const string READ_SYNC_STATS = "android.permission.READ_SYNC_STATS";

			/// <summary>Allows an application to read the user dictionary.</summary>
			/// <remarks>
			/// Allows an application to read the user dictionary. This should
			/// really only be required by an IME, or a dictionary editor like
			/// the Settings app.
			/// </remarks>
			/// <hide>Pending API council approval</hide>
			public const string READ_USER_DICTIONARY = "android.permission.READ_USER_DICTIONARY";

			/// <summary>Required to be able to reboot the device.</summary>
			/// <remarks>Required to be able to reboot the device.</remarks>
			public const string REBOOT = "android.permission.REBOOT";

			/// <summary>
			/// Allows an application to receive the
			/// <see cref="android.content.Intent.ACTION_BOOT_COMPLETED">android.content.Intent.ACTION_BOOT_COMPLETED
			/// 	</see>
			/// that is
			/// broadcast after the system finishes booting.  If you don't
			/// request this permission, you will not receive the broadcast at
			/// that time.  Though holding this permission does not have any
			/// security implications, it can have a negative impact on the
			/// user experience by increasing the amount of time it takes the
			/// system to start and allowing applications to have themselves
			/// running without the user being aware of them.  As such, you must
			/// explicitly declare your use of this facility to make that visible
			/// to the user.
			/// </summary>
			public const string RECEIVE_BOOT_COMPLETED = "android.permission.RECEIVE_BOOT_COMPLETED";

			/// <summary>
			/// Allows an application to receive emergency cell broadcast messages,
			/// to record or display them to the user.
			/// </summary>
			/// <remarks>
			/// Allows an application to receive emergency cell broadcast messages,
			/// to record or display them to the user. Reserved for system apps.
			/// </remarks>
			/// <hide>Pending API council approval</hide>
			public const string RECEIVE_EMERGENCY_BROADCAST = "android.permission.RECEIVE_EMERGENCY_BROADCAST";

			/// <summary>
			/// Allows an application to monitor incoming MMS messages, to record
			/// or perform processing on them.
			/// </summary>
			/// <remarks>
			/// Allows an application to monitor incoming MMS messages, to record
			/// or perform processing on them.
			/// </remarks>
			public const string RECEIVE_MMS = "android.permission.RECEIVE_MMS";

			/// <summary>
			/// Allows an application to monitor incoming SMS messages, to record
			/// or perform processing on them.
			/// </summary>
			/// <remarks>
			/// Allows an application to monitor incoming SMS messages, to record
			/// or perform processing on them.
			/// </remarks>
			public const string RECEIVE_SMS = "android.permission.RECEIVE_SMS";

			/// <summary>Allows an application to monitor incoming WAP push messages.</summary>
			/// <remarks>Allows an application to monitor incoming WAP push messages.</remarks>
			public const string RECEIVE_WAP_PUSH = "android.permission.RECEIVE_WAP_PUSH";

			/// <summary>Allows an application to record audio</summary>
			public const string RECORD_AUDIO = "android.permission.RECORD_AUDIO";

			/// <hide>Allows an application to change to remove/kill tasks</hide>
			public const string REMOVE_TASKS = "android.permission.REMOVE_TASKS";

			/// <summary>Allows an application to change the Z-order of tasks</summary>
			public const string REORDER_TASKS = "android.permission.REORDER_TASKS";

			[System.ObsoleteAttribute(@"The android.app.ActivityManager.restartPackage(string) API is no longer supported."
				)]
			public const string RESTART_PACKAGES = "android.permission.RESTART_PACKAGES";

			/// <hide>
			/// Allows an application to retrieve the content of the active window
			/// An active window is the window that has fired an accessibility event.
			/// </hide>
			public const string RETRIEVE_WINDOW_CONTENT = "android.permission.RETRIEVE_WINDOW_CONTENT";

			/// <summary>Allows an application to send SMS messages.</summary>
			/// <remarks>Allows an application to send SMS messages.</remarks>
			public const string SEND_SMS = "android.permission.SEND_SMS";

			/// <summary>
			/// Allows an application to send SMS messages via the Messaging app with no user
			/// input or confirmation.
			/// </summary>
			/// <remarks>
			/// Allows an application to send SMS messages via the Messaging app with no user
			/// input or confirmation.
			/// </remarks>
			/// <hide></hide>
			public const string SEND_SMS_NO_CONFIRMATION = "android.permission.SEND_SMS_NO_CONFIRMATION";

			/// <summary>
			/// Allows an application to watch and control how activities are
			/// started globally in the system.
			/// </summary>
			/// <remarks>
			/// Allows an application to watch and control how activities are
			/// started globally in the system.  Only for is in debugging
			/// (usually the monkey command).
			/// </remarks>
			public const string SET_ACTIVITY_WATCHER = "android.permission.SET_ACTIVITY_WATCHER";

			/// <summary>
			/// Allows an application to broadcast an Intent to set an alarm for the
			/// user.
			/// </summary>
			/// <remarks>
			/// Allows an application to broadcast an Intent to set an alarm for the
			/// user.
			/// </remarks>
			public const string SET_ALARM = "com.android.alarm.permission.SET_ALARM";

			/// <summary>
			/// Allows an application to control whether activities are immediately
			/// finished when put in the background.
			/// </summary>
			/// <remarks>
			/// Allows an application to control whether activities are immediately
			/// finished when put in the background.
			/// </remarks>
			public const string SET_ALWAYS_FINISH = "android.permission.SET_ALWAYS_FINISH";

			/// <summary>Modify the global animation scaling factor.</summary>
			/// <remarks>Modify the global animation scaling factor.</remarks>
			public const string SET_ANIMATION_SCALE = "android.permission.SET_ANIMATION_SCALE";

			/// <summary>Configure an application for debugging.</summary>
			/// <remarks>Configure an application for debugging.</remarks>
			public const string SET_DEBUG_APP = "android.permission.SET_DEBUG_APP";

			/// <summary>
			/// Allows low-level access to setting the orientation (actually
			/// rotation) of the screen.
			/// </summary>
			/// <remarks>
			/// Allows low-level access to setting the orientation (actually
			/// rotation) of the screen.  Not for use by normal applications.
			/// </remarks>
			public const string SET_ORIENTATION = "android.permission.SET_ORIENTATION";

			/// <summary>Allows low-level access to setting the pointer speed.</summary>
			/// <remarks>
			/// Allows low-level access to setting the pointer speed.
			/// Not for use by normal applications.
			/// </remarks>
			public const string SET_POINTER_SPEED = "android.permission.SET_POINTER_SPEED";

			[System.ObsoleteAttribute(@"No longer useful, seeandroid.content.pm.PackageManager.addPackageToPreferred(string) for details."
				)]
			public const string SET_PREFERRED_APPLICATIONS = "android.permission.SET_PREFERRED_APPLICATIONS";

			/// <summary>
			/// Allows an application to set the maximum number of (not needed)
			/// application processes that can be running.
			/// </summary>
			/// <remarks>
			/// Allows an application to set the maximum number of (not needed)
			/// application processes that can be running.
			/// </remarks>
			public const string SET_PROCESS_LIMIT = "android.permission.SET_PROCESS_LIMIT";

			/// <summary>Allows applications to set the system time</summary>
			public const string SET_TIME = "android.permission.SET_TIME";

			/// <summary>Allows applications to set the system time zone</summary>
			public const string SET_TIME_ZONE = "android.permission.SET_TIME_ZONE";

			/// <summary>Allows applications to set the wallpaper</summary>
			public const string SET_WALLPAPER = "android.permission.SET_WALLPAPER";

			/// <summary>Allows applications to set a live wallpaper.</summary>
			/// <remarks>Allows applications to set a live wallpaper.</remarks>
			/// <hide>
			/// XXX Change to signature once the picker is moved to its
			/// own apk as Ghod Intended.
			/// </hide>
			public const string SET_WALLPAPER_COMPONENT = "android.permission.SET_WALLPAPER_COMPONENT";

			/// <summary>Allows applications to set the wallpaper hints</summary>
			public const string SET_WALLPAPER_HINTS = "android.permission.SET_WALLPAPER_HINTS";

			/// <summary>
			/// Allows an application to call the activity manager shutdown() API
			/// to put the higher-level system there into a shutdown state.
			/// </summary>
			/// <remarks>
			/// Allows an application to call the activity manager shutdown() API
			/// to put the higher-level system there into a shutdown state.
			/// </remarks>
			/// <hide></hide>
			public const string SHUTDOWN = "android.permission.SHUTDOWN";

			/// <summary>Allow an application to request that a signal be sent to all persistent processes
			/// 	</summary>
			public const string SIGNAL_PERSISTENT_PROCESSES = "android.permission.SIGNAL_PERSISTENT_PROCESSES";

			/// <summary>
			/// Allows an application to open, close, or disable the status bar
			/// and its icons.
			/// </summary>
			/// <remarks>
			/// Allows an application to open, close, or disable the status bar
			/// and its icons.
			/// </remarks>
			public const string STATUS_BAR = "android.permission.STATUS_BAR";

			/// <summary>Allows an application to be the status bar.</summary>
			/// <remarks>Allows an application to be the status bar.  Currently used only by SystemUI.apk
			/// 	</remarks>
			/// <hide></hide>
			public const string STATUS_BAR_SERVICE = "android.permission.STATUS_BAR_SERVICE";

			/// <summary>
			/// Allows an application to tell the activity manager to temporarily
			/// stop application switches, putting it into a special mode that
			/// prevents applications from immediately switching away from some
			/// critical UI such as the home screen.
			/// </summary>
			/// <remarks>
			/// Allows an application to tell the activity manager to temporarily
			/// stop application switches, putting it into a special mode that
			/// prevents applications from immediately switching away from some
			/// critical UI such as the home screen.
			/// </remarks>
			/// <hide></hide>
			public const string STOP_APP_SWITCHES = "android.permission.STOP_APP_SWITCHES";

			/// <summary>
			/// Allows an application to allow access the subscribed feeds
			/// ContentProvider.
			/// </summary>
			/// <remarks>
			/// Allows an application to allow access the subscribed feeds
			/// ContentProvider.
			/// </remarks>
			public const string SUBSCRIBED_FEEDS_READ = "android.permission.SUBSCRIBED_FEEDS_READ";

			public const string SUBSCRIBED_FEEDS_WRITE = "android.permission.SUBSCRIBED_FEEDS_WRITE";

			/// <summary>
			/// Allows an application to open windows using the type
			/// <see cref="android.view.WindowManagerClass.LayoutParams.TYPE_SYSTEM_ALERT">android.view.WindowManagerClass.LayoutParams.TYPE_SYSTEM_ALERT
			/// 	</see>
			/// ,
			/// shown on top of all other applications.  Very few applications
			/// should use this permission; these windows are intended for
			/// system-level interaction with the user.
			/// </summary>
			public const string SYSTEM_ALERT_WINDOW = "android.permission.SYSTEM_ALERT_WINDOW";

			/// <summary>Allows an application to update device statistics.</summary>
			/// <remarks>
			/// Allows an application to update device statistics. Not for
			/// use by third party apps.
			/// </remarks>
			public const string UPDATE_DEVICE_STATS = "android.permission.UPDATE_DEVICE_STATS";

			/// <summary>Allows an application to request authtokens from the AccountManager</summary>
			public const string USE_CREDENTIALS = "android.permission.USE_CREDENTIALS";

			/// <summary>Allows an application to use SIP service</summary>
			public const string USE_SIP = "android.permission.USE_SIP";

			/// <summary>Allows access to the vibrator</summary>
			public const string VIBRATE = "android.permission.VIBRATE";

			/// <summary>
			/// Allows using PowerManager WakeLocks to keep processor from sleeping or screen
			/// from dimming
			/// </summary>
			public const string WAKE_LOCK = "android.permission.WAKE_LOCK";

			/// <summary>Allows applications to write the apn settings</summary>
			public const string WRITE_APN_SETTINGS = "android.permission.WRITE_APN_SETTINGS";

			/// <summary>
			/// Allows an application to write (but not read) the user's
			/// calendar data.
			/// </summary>
			/// <remarks>
			/// Allows an application to write (but not read) the user's
			/// calendar data.
			/// </remarks>
			public const string WRITE_CALENDAR = "android.permission.WRITE_CALENDAR";

			/// <summary>
			/// Allows an application to write (but not read) the user's
			/// contacts data.
			/// </summary>
			/// <remarks>
			/// Allows an application to write (but not read) the user's
			/// contacts data.
			/// </remarks>
			public const string WRITE_CONTACTS = "android.permission.WRITE_CONTACTS";

			/// <summary>Allows an application to write to external storage</summary>
			public const string WRITE_EXTERNAL_STORAGE = "android.permission.WRITE_EXTERNAL_STORAGE";

			/// <summary>Allows an application to modify the Google service map.</summary>
			/// <remarks>Allows an application to modify the Google service map.</remarks>
			public const string WRITE_GSERVICES = "android.permission.WRITE_GSERVICES";

			/// <summary>
			/// Allows an application to write (but not read) the user's
			/// browsing history and bookmarks.
			/// </summary>
			/// <remarks>
			/// Allows an application to write (but not read) the user's
			/// browsing history and bookmarks.
			/// </remarks>
			public const string WRITE_HISTORY_BOOKMARKS = "com.android.browser.permission.WRITE_HISTORY_BOOKMARKS";

			/// <summary>Allows an application to write to internal media storage</summary>
			/// <hide></hide>
			public const string WRITE_MEDIA_STORAGE = "android.permission.WRITE_MEDIA_STORAGE";

			/// <summary>
			/// Allows an application to write (but not read) the user's
			/// personal profile data.
			/// </summary>
			/// <remarks>
			/// Allows an application to write (but not read) the user's
			/// personal profile data.
			/// </remarks>
			public const string WRITE_PROFILE = "android.permission.WRITE_PROFILE";

			/// <summary>Allows an application to read or write the secure system settings.</summary>
			/// <remarks>Allows an application to read or write the secure system settings.</remarks>
			public const string WRITE_SECURE_SETTINGS = "android.permission.WRITE_SECURE_SETTINGS";

			/// <summary>Allows an application to read or write the system settings.</summary>
			/// <remarks>Allows an application to read or write the system settings.</remarks>
			public const string WRITE_SETTINGS = "android.permission.WRITE_SETTINGS";

			/// <summary>Allows an application to write SMS messages.</summary>
			/// <remarks>Allows an application to write SMS messages.</remarks>
			public const string WRITE_SMS = "android.permission.WRITE_SMS";

			/// <summary>
			/// Allows an application to write (but not read) the user's
			/// social stream data.
			/// </summary>
			/// <remarks>
			/// Allows an application to write (but not read) the user's
			/// social stream data.
			/// </remarks>
			/// <hide></hide>
			public const string WRITE_SOCIAL_STREAM = "android.permission.WRITE_SOCIAL_STREAM";

			/// <summary>Allows applications to write the sync settings</summary>
			public const string WRITE_SYNC_SETTINGS = "android.permission.WRITE_SYNC_SETTINGS";

			/// <summary>Allows an application to write to the user dictionary.</summary>
			/// <remarks>Allows an application to write to the user dictionary.</remarks>
			/// <hide>Pending API council approval</hide>
			public const string WRITE_USER_DICTIONARY = "android.permission.WRITE_USER_DICTIONARY";
		}

		public sealed class permission_group
		{
			/// <summary>
			/// Permissions for direct access to the accounts managed
			/// by the Account Manager.
			/// </summary>
			/// <remarks>
			/// Permissions for direct access to the accounts managed
			/// by the Account Manager.
			/// </remarks>
			public const string ACCOUNTS = "android.permission-group.ACCOUNTS";

			/// <summary>
			/// Used for permissions that can be used to make the user spend money
			/// without their direct involvement.
			/// </summary>
			/// <remarks>
			/// Used for permissions that can be used to make the user spend money
			/// without their direct involvement.  For example, this is the group
			/// for permissions that allow you to directly place phone calls,
			/// directly send SMS messages, etc.
			/// </remarks>
			public const string COST_MONEY = "android.permission-group.COST_MONEY";

			/// <summary>Group of permissions that are related to development features.</summary>
			/// <remarks>
			/// Group of permissions that are related to development features.  These
			/// are not permissions that should appear in normal applications; they
			/// protect APIs that are intended only to be used for development
			/// purposes.
			/// </remarks>
			public const string DEVELOPMENT_TOOLS = "android.permission-group.DEVELOPMENT_TOOLS";

			/// <summary>
			/// Used for permissions that provide direct access to the hardware on
			/// the device.
			/// </summary>
			/// <remarks>
			/// Used for permissions that provide direct access to the hardware on
			/// the device.  This includes audio, the camera, vibrator, etc.
			/// </remarks>
			public const string HARDWARE_CONTROLS = "android.permission-group.HARDWARE_CONTROLS";

			/// <summary>
			/// Used for permissions that allow access to the user's current
			/// location.
			/// </summary>
			/// <remarks>
			/// Used for permissions that allow access to the user's current
			/// location.
			/// </remarks>
			public const string LOCATION = "android.permission-group.LOCATION";

			/// <summary>
			/// Used for permissions that allow an application to send messages
			/// on behalf of the user or intercept messages being received by the
			/// user.
			/// </summary>
			/// <remarks>
			/// Used for permissions that allow an application to send messages
			/// on behalf of the user or intercept messages being received by the
			/// user.  This is primarily intended for SMS/MMS messaging, such as
			/// receiving or reading an MMS.
			/// </remarks>
			public const string MESSAGES = "android.permission-group.MESSAGES";

			/// <summary>Used for permissions that provide access to networking services.</summary>
			/// <remarks>
			/// Used for permissions that provide access to networking services.  The
			/// main permission here is internet access, but this is also an
			/// appropriate group for accessing or modifying any network configuration
			/// or other related network operations.
			/// </remarks>
			public const string NETWORK = "android.permission-group.NETWORK";

			/// <summary>
			/// Used for permissions that provide access to the user's private data,
			/// such as contacts, calendar events, e-mail messages, etc.
			/// </summary>
			/// <remarks>
			/// Used for permissions that provide access to the user's private data,
			/// such as contacts, calendar events, e-mail messages, etc.  This includes
			/// both reading and writing of this data (which should generally be
			/// expressed as two distinct permissions).
			/// </remarks>
			public const string PERSONAL_INFO = "android.permission-group.PERSONAL_INFO";

			/// <summary>
			/// Used for permissions that are associated with accessing and modifyign
			/// telephony state: intercepting outgoing calls, reading
			/// and modifying the phone state.
			/// </summary>
			/// <remarks>
			/// Used for permissions that are associated with accessing and modifyign
			/// telephony state: intercepting outgoing calls, reading
			/// and modifying the phone state.  Note that
			/// placing phone calls is not in this group, since that is in the
			/// more important "takin' yer moneys" group.
			/// </remarks>
			public const string PHONE_CALLS = "android.permission-group.PHONE_CALLS";

			/// <summary>Group of permissions that are related to SD card access.</summary>
			/// <remarks>Group of permissions that are related to SD card access.</remarks>
			public const string STORAGE = "android.permission-group.STORAGE";

			/// <summary>Group of permissions that are related to system APIs.</summary>
			/// <remarks>
			/// Group of permissions that are related to system APIs.  Many
			/// of these are not permissions the user will be expected to understand,
			/// and such permissions should generally be marked as "normal" protection
			/// level so they don't get displayed.  This can also, however, be used
			/// for miscellaneous features that provide access to the operating system,
			/// such as writing the global system settings.
			/// </remarks>
			public const string SYSTEM_TOOLS = "android.permission-group.SYSTEM_TOOLS";
		}
	}
}
