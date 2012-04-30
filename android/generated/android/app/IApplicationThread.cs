using Sharpen;

namespace android.app
{
	/// <summary>System private API for communicating with the application.</summary>
	/// <remarks>
	/// System private API for communicating with the application.  This is given to
	/// the activity manager by an application  when it starts up, for the activity
	/// manager to tell the application about things it needs to do.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public interface IApplicationThread : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void schedulePauseActivity(android.os.IBinder token, bool finished, bool userLeaving
			, int configChanges);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleStopActivity(android.os.IBinder token, bool showWindow, int configChanges
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleWindowVisibility(android.os.IBinder token, bool showWindow);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleSleeping(android.os.IBinder token, bool sleeping);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleResumeActivity(android.os.IBinder token, bool isForward);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleSendResult(android.os.IBinder token, java.util.List<android.app.ResultInfo
			> results);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleLaunchActivity(android.content.Intent intent, android.os.IBinder token
			, int ident, android.content.pm.ActivityInfo info, android.content.res.Configuration
			 curConfig, android.content.res.CompatibilityInfo compatInfo, android.os.Bundle 
			state, java.util.List<android.app.ResultInfo> pendingResults, java.util.List<android.content.Intent
			> pendingNewIntents, bool notResumed, bool isForward, string profileName, android.os.ParcelFileDescriptor
			 profileFd, bool autoStopProfiler);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleRelaunchActivity(android.os.IBinder token, java.util.List<android.app.ResultInfo
			> pendingResults, java.util.List<android.content.Intent> pendingNewIntents, int 
			configChanges, bool notResumed, android.content.res.Configuration config);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleNewIntent(java.util.List<android.content.Intent> intent, android.os.IBinder
			 token);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleDestroyActivity(android.os.IBinder token, bool finished, int configChanges
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleReceiver(android.content.Intent intent, android.content.pm.ActivityInfo
			 info, android.content.res.CompatibilityInfo compatInfo, int resultCode, string 
			data, android.os.Bundle extras, bool sync);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleCreateBackupAgent(android.content.pm.ApplicationInfo app, android.content.res.CompatibilityInfo
			 compatInfo, int backupMode);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleDestroyBackupAgent(android.content.pm.ApplicationInfo app, android.content.res.CompatibilityInfo
			 compatInfo);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleCreateService(android.os.IBinder token, android.content.pm.ServiceInfo
			 info, android.content.res.CompatibilityInfo compatInfo);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleBindService(android.os.IBinder token, android.content.Intent intent, 
			bool rebind);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleUnbindService(android.os.IBinder token, android.content.Intent intent
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleServiceArgs(android.os.IBinder token, bool taskRemoved, int startId, 
			int flags, android.content.Intent args);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleStopService(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		void bindApplication(string packageName, android.content.pm.ApplicationInfo info, 
			java.util.List<android.content.pm.ProviderInfo> providers, android.content.ComponentName
			 testName, string profileName, android.os.ParcelFileDescriptor profileFd, bool autoStopProfiler
			, android.os.Bundle testArguments, android.app.IInstrumentationWatcher testWatcher
			, int debugMode, bool restrictedBackupMode, bool persistent, android.content.res.Configuration
			 config, android.content.res.CompatibilityInfo compatInfo, java.util.Map<string, 
			android.os.IBinder> services, android.os.Bundle coreSettings);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleExit();

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleSuicide();

		/// <exception cref="android.os.RemoteException"></exception>
		void requestThumbnail(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleConfigurationChanged(android.content.res.Configuration config);

		/// <exception cref="android.os.RemoteException"></exception>
		void updateTimeZone();

		/// <exception cref="android.os.RemoteException"></exception>
		void clearDnsCache();

		/// <exception cref="android.os.RemoteException"></exception>
		void setHttpProxy(string proxy, string port, string exclList);

		/// <exception cref="android.os.RemoteException"></exception>
		void processInBackground();

		/// <exception cref="android.os.RemoteException"></exception>
		void dumpService(java.io.FileDescriptor fd, android.os.IBinder servicetoken, string
			[] args);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleRegisteredReceiver(android.content.IIntentReceiver receiver, android.content.Intent
			 intent, int resultCode, string data, android.os.Bundle extras, bool ordered, bool
			 sticky);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleLowMemory();

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleActivityConfigurationChanged(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		void profilerControl(bool start, string path, android.os.ParcelFileDescriptor fd, 
			int profileType);

		/// <exception cref="android.os.RemoteException"></exception>
		void dumpHeap(bool managed, string path, android.os.ParcelFileDescriptor fd);

		/// <exception cref="android.os.RemoteException"></exception>
		void setSchedulingGroup(int group);

		/// <exception cref="android.os.RemoteException"></exception>
		void getMemoryInfo(android.os.Debug.MemoryInfo outInfo);

		/// <exception cref="android.os.RemoteException"></exception>
		void dispatchPackageBroadcast(int cmd, string[] packages);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleCrash(string msg);

		/// <exception cref="android.os.RemoteException"></exception>
		void dumpActivity(java.io.FileDescriptor fd, android.os.IBinder servicetoken, string
			 prefix, string[] args);

		/// <exception cref="android.os.RemoteException"></exception>
		void setCoreSettings(android.os.Bundle coreSettings);

		/// <exception cref="android.os.RemoteException"></exception>
		void updatePackageCompatibilityInfo(string pkg, android.content.res.CompatibilityInfo
			 info);

		/// <exception cref="android.os.RemoteException"></exception>
		void scheduleTrimMemory(int level);

		/// <exception cref="android.os.RemoteException"></exception>
		android.os.Debug.MemoryInfo dumpMemInfo(java.io.FileDescriptor fd, bool checkin, 
			bool all, string[] args);

		/// <exception cref="android.os.RemoteException"></exception>
		void dumpGfxInfo(java.io.FileDescriptor fd, string[] args);
	}

	/// <summary>System private API for communicating with the application.</summary>
	/// <remarks>
	/// System private API for communicating with the application.  This is given to
	/// the activity manager by an application  when it starts up, for the activity
	/// manager to tell the application about things it needs to do.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public static class IApplicationThreadClass
	{
		public const int BACKUP_MODE_INCREMENTAL = 0;

		public const int BACKUP_MODE_FULL = 1;

		public const int BACKUP_MODE_RESTORE = 2;

		public const int BACKUP_MODE_RESTORE_FULL = 3;

		public const int DEBUG_OFF = 0;

		public const int DEBUG_ON = 1;

		public const int DEBUG_WAIT = 2;

		public const int PACKAGE_REMOVED = 0;

		public const int EXTERNAL_STORAGE_UNAVAILABLE = 1;

		public const string descriptor = "android.app.IApplicationThread";

		public const int SCHEDULE_PAUSE_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION;

		public const int SCHEDULE_STOP_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 2;

		public const int SCHEDULE_WINDOW_VISIBILITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 3;

		public const int SCHEDULE_RESUME_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 4;

		public const int SCHEDULE_SEND_RESULT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 5;

		public const int SCHEDULE_LAUNCH_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 6;

		public const int SCHEDULE_NEW_INTENT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 7;

		public const int SCHEDULE_FINISH_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 8;

		public const int SCHEDULE_RECEIVER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 9;

		public const int SCHEDULE_CREATE_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 10;

		public const int SCHEDULE_STOP_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 11;

		public const int BIND_APPLICATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 12;

		public const int SCHEDULE_EXIT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 13;

		public const int REQUEST_THUMBNAIL_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 14;

		public const int SCHEDULE_CONFIGURATION_CHANGED_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 15;

		public const int SCHEDULE_SERVICE_ARGS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 16;

		public const int UPDATE_TIME_ZONE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 17;

		public const int PROCESS_IN_BACKGROUND_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 18;

		public const int SCHEDULE_BIND_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 19;

		public const int SCHEDULE_UNBIND_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 20;

		public const int DUMP_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 21;

		public const int SCHEDULE_REGISTERED_RECEIVER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 22;

		public const int SCHEDULE_LOW_MEMORY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 23;

		public const int SCHEDULE_ACTIVITY_CONFIGURATION_CHANGED_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 24;

		public const int SCHEDULE_RELAUNCH_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 25;

		public const int SCHEDULE_SLEEPING_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 26;

		public const int PROFILER_CONTROL_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 27;

		public const int SET_SCHEDULING_GROUP_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 28;

		public const int SCHEDULE_CREATE_BACKUP_AGENT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 29;

		public const int SCHEDULE_DESTROY_BACKUP_AGENT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 30;

		public const int GET_MEMORY_INFO_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 31;

		public const int SCHEDULE_SUICIDE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 32;

		public const int DISPATCH_PACKAGE_BROADCAST_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 33;

		public const int SCHEDULE_CRASH_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 34;

		public const int DUMP_HEAP_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 35;

		public const int DUMP_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 36;

		public const int CLEAR_DNS_CACHE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 37;

		public const int SET_HTTP_PROXY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 38;

		public const int SET_CORE_SETTINGS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 39;

		public const int UPDATE_PACKAGE_COMPATIBILITY_INFO_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 40;

		public const int SCHEDULE_TRIM_MEMORY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 41;

		public const int DUMP_MEM_INFO_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 42;

		public const int DUMP_GFX_INFO_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 43;
	}
}
