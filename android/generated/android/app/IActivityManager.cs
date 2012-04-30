using Sharpen;

namespace android.app
{
	/// <summary>System private API for talking with the activity manager service.</summary>
	/// <remarks>
	/// System private API for talking with the activity manager service.  This
	/// provides calls from the application back to the activity manager.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public interface IActivityManager : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		int startActivity(android.app.IApplicationThread caller, android.content.Intent intent
			, string resolvedType, System.Uri[] grantedUriPermissions, int grantedMode, android.os.IBinder
			 resultTo, string resultWho, int requestCode, bool onlyIfNeeded, bool debug, string
			 profileFile, android.os.ParcelFileDescriptor profileFd, bool autoStopProfiler);

		/// <exception cref="android.os.RemoteException"></exception>
		android.app.IActivityManagerClass.WaitResult startActivityAndWait(android.app.IApplicationThread
			 caller, android.content.Intent intent, string resolvedType, System.Uri[] grantedUriPermissions
			, int grantedMode, android.os.IBinder resultTo, string resultWho, int requestCode
			, bool onlyIfNeeded, bool debug, string profileFile, android.os.ParcelFileDescriptor
			 profileFd, bool autoStopProfiler);

		/// <exception cref="android.os.RemoteException"></exception>
		int startActivityWithConfig(android.app.IApplicationThread caller, android.content.Intent
			 intent, string resolvedType, System.Uri[] grantedUriPermissions, int grantedMode
			, android.os.IBinder resultTo, string resultWho, int requestCode, bool onlyIfNeeded
			, bool debug, android.content.res.Configuration newConfig);

		/// <exception cref="android.os.RemoteException"></exception>
		int startActivityIntentSender(android.app.IApplicationThread caller, android.content.IntentSender
			 intent, android.content.Intent fillInIntent, string resolvedType, android.os.IBinder
			 resultTo, string resultWho, int requestCode, int flagsMask, int flagsValues);

		/// <exception cref="android.os.RemoteException"></exception>
		bool startNextMatchingActivity(android.os.IBinder callingActivity, android.content.Intent
			 intent);

		/// <exception cref="android.os.RemoteException"></exception>
		bool finishActivity(android.os.IBinder token, int code, android.content.Intent data
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void finishSubActivity(android.os.IBinder token, string resultWho, int requestCode
			);

		/// <exception cref="android.os.RemoteException"></exception>
		bool willActivityBeVisible(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		android.content.Intent registerReceiver(android.app.IApplicationThread caller, string
			 callerPackage, android.content.IIntentReceiver receiver, android.content.IntentFilter
			 filter, string requiredPermission);

		/// <exception cref="android.os.RemoteException"></exception>
		void unregisterReceiver(android.content.IIntentReceiver receiver);

		/// <exception cref="android.os.RemoteException"></exception>
		int broadcastIntent(android.app.IApplicationThread caller, android.content.Intent
			 intent, string resolvedType, android.content.IIntentReceiver resultTo, int resultCode
			, string resultData, android.os.Bundle map, string requiredPermission, bool serialized
			, bool sticky);

		/// <exception cref="android.os.RemoteException"></exception>
		void unbroadcastIntent(android.app.IApplicationThread caller, android.content.Intent
			 intent);

		/// <exception cref="android.os.RemoteException"></exception>
		void finishReceiver(android.os.IBinder who, int resultCode, string resultData, android.os.Bundle
			 map, bool abortBroadcast);

		/// <exception cref="android.os.RemoteException"></exception>
		void attachApplication(android.app.IApplicationThread app);

		/// <exception cref="android.os.RemoteException"></exception>
		void activityIdle(android.os.IBinder token, android.content.res.Configuration config
			, bool stopProfiling);

		/// <exception cref="android.os.RemoteException"></exception>
		void activityPaused(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		void activityStopped(android.os.IBinder token, android.os.Bundle state, android.graphics.Bitmap
			 thumbnail, java.lang.CharSequence description);

		/// <exception cref="android.os.RemoteException"></exception>
		void activitySlept(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		void activityDestroyed(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		string getCallingPackage(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		android.content.ComponentName getCallingActivity(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		java.util.List<object> getTasks(int maxNum, int flags, android.app.IThumbnailReceiver
			 receiver);

		/// <exception cref="android.os.RemoteException"></exception>
		java.util.List<android.app.ActivityManager.RecentTaskInfo> getRecentTasks(int maxNum
			, int flags);

		/// <exception cref="android.os.RemoteException"></exception>
		android.app.ActivityManager.TaskThumbnails getTaskThumbnails(int taskId);

		/// <exception cref="android.os.RemoteException"></exception>
		java.util.List<object> getServices(int maxNum, int flags);

		/// <exception cref="android.os.RemoteException"></exception>
		java.util.List<android.app.ActivityManager.ProcessErrorStateInfo> getProcessesInErrorState
			();

		/// <exception cref="android.os.RemoteException"></exception>
		void moveTaskToFront(int task, int flags);

		/// <exception cref="android.os.RemoteException"></exception>
		void moveTaskToBack(int task);

		/// <exception cref="android.os.RemoteException"></exception>
		bool moveActivityTaskToBack(android.os.IBinder token, bool nonRoot);

		/// <exception cref="android.os.RemoteException"></exception>
		void moveTaskBackwards(int task);

		/// <exception cref="android.os.RemoteException"></exception>
		int getTaskForActivity(android.os.IBinder token, bool onlyRoot);

		/// <exception cref="android.os.RemoteException"></exception>
		void finishOtherInstances(android.os.IBinder token, android.content.ComponentName
			 className);

		/// <exception cref="android.os.RemoteException"></exception>
		void reportThumbnail(android.os.IBinder token, android.graphics.Bitmap thumbnail, 
			java.lang.CharSequence description);

		/// <exception cref="android.os.RemoteException"></exception>
		android.app.IActivityManagerClass.ContentProviderHolder getContentProvider(android.app.IApplicationThread
			 caller, string name);

		/// <exception cref="android.os.RemoteException"></exception>
		void removeContentProvider(android.app.IApplicationThread caller, string name);

		/// <exception cref="android.os.RemoteException"></exception>
		void publishContentProviders(android.app.IApplicationThread caller, java.util.List
			<android.app.IActivityManagerClass.ContentProviderHolder> providers);

		/// <exception cref="android.os.RemoteException"></exception>
		android.app.PendingIntent getRunningServiceControlPanel(android.content.ComponentName
			 service);

		/// <exception cref="android.os.RemoteException"></exception>
		android.content.ComponentName startService(android.app.IApplicationThread caller, 
			android.content.Intent service, string resolvedType);

		/// <exception cref="android.os.RemoteException"></exception>
		int stopService(android.app.IApplicationThread caller, android.content.Intent service
			, string resolvedType);

		/// <exception cref="android.os.RemoteException"></exception>
		bool stopServiceToken(android.content.ComponentName className, android.os.IBinder
			 token, int startId);

		/// <exception cref="android.os.RemoteException"></exception>
		void setServiceForeground(android.content.ComponentName className, android.os.IBinder
			 token, int id, android.app.Notification notification, bool keepNotification);

		/// <exception cref="android.os.RemoteException"></exception>
		int bindService(android.app.IApplicationThread caller, android.os.IBinder token, 
			android.content.Intent service, string resolvedType, android.app.IServiceConnection
			 connection, int flags);

		/// <exception cref="android.os.RemoteException"></exception>
		bool unbindService(android.app.IServiceConnection connection);

		/// <exception cref="android.os.RemoteException"></exception>
		void publishService(android.os.IBinder token, android.content.Intent intent, android.os.IBinder
			 service);

		/// <exception cref="android.os.RemoteException"></exception>
		void unbindFinished(android.os.IBinder token, android.content.Intent service, bool
			 doRebind);

		/// <exception cref="android.os.RemoteException"></exception>
		void serviceDoneExecuting(android.os.IBinder token, int type, int startId, int res
			);

		/// <exception cref="android.os.RemoteException"></exception>
		android.os.IBinder peekService(android.content.Intent service, string resolvedType
			);

		/// <exception cref="android.os.RemoteException"></exception>
		bool bindBackupAgent(android.content.pm.ApplicationInfo appInfo, int backupRestoreMode
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void backupAgentCreated(string packageName, android.os.IBinder agent);

		/// <exception cref="android.os.RemoteException"></exception>
		void unbindBackupAgent(android.content.pm.ApplicationInfo appInfo);

		/// <exception cref="android.os.RemoteException"></exception>
		void killApplicationProcess(string processName, int uid);

		/// <exception cref="android.os.RemoteException"></exception>
		bool startInstrumentation(android.content.ComponentName className, string profileFile
			, int flags, android.os.Bundle arguments, android.app.IInstrumentationWatcher watcher
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void finishInstrumentation(android.app.IApplicationThread target, int resultCode, 
			android.os.Bundle results);

		/// <exception cref="android.os.RemoteException"></exception>
		android.content.res.Configuration getConfiguration();

		/// <exception cref="android.os.RemoteException"></exception>
		void updateConfiguration(android.content.res.Configuration values);

		/// <exception cref="android.os.RemoteException"></exception>
		void setRequestedOrientation(android.os.IBinder token, int requestedOrientation);

		/// <exception cref="android.os.RemoteException"></exception>
		int getRequestedOrientation(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		android.content.ComponentName getActivityClassForToken(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		string getPackageForToken(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		android.content.IIntentSender getIntentSender(int type, string packageName, android.os.IBinder
			 token, string resultWho, int requestCode, android.content.Intent[] intents, string
			[] resolvedTypes, int flags);

		/// <exception cref="android.os.RemoteException"></exception>
		void cancelIntentSender(android.content.IIntentSender sender);

		/// <exception cref="android.os.RemoteException"></exception>
		bool clearApplicationUserData(string packageName, android.content.pm.IPackageDataObserver
			 observer);

		/// <exception cref="android.os.RemoteException"></exception>
		string getPackageForIntentSender(android.content.IIntentSender sender);

		/// <exception cref="android.os.RemoteException"></exception>
		void setProcessLimit(int max);

		/// <exception cref="android.os.RemoteException"></exception>
		int getProcessLimit();

		/// <exception cref="android.os.RemoteException"></exception>
		void setProcessForeground(android.os.IBinder token, int pid, bool isForeground);

		/// <exception cref="android.os.RemoteException"></exception>
		int checkPermission(string permission, int pid, int uid);

		/// <exception cref="android.os.RemoteException"></exception>
		int checkUriPermission(System.Uri uri, int pid, int uid, int mode);

		/// <exception cref="android.os.RemoteException"></exception>
		void grantUriPermission(android.app.IApplicationThread caller, string targetPkg, 
			System.Uri uri, int mode);

		/// <exception cref="android.os.RemoteException"></exception>
		void revokeUriPermission(android.app.IApplicationThread caller, System.Uri uri, int
			 mode);

		/// <exception cref="android.os.RemoteException"></exception>
		void showWaitingForDebugger(android.app.IApplicationThread who, bool waiting);

		/// <exception cref="android.os.RemoteException"></exception>
		void getMemoryInfo(android.app.ActivityManager.MemoryInfo outInfo);

		/// <exception cref="android.os.RemoteException"></exception>
		void killBackgroundProcesses(string packageName);

		/// <exception cref="android.os.RemoteException"></exception>
		void forceStopPackage(string packageName);

		// Note: probably don't want to allow applications access to these.
		/// <exception cref="android.os.RemoteException"></exception>
		void goingToSleep();

		/// <exception cref="android.os.RemoteException"></exception>
		void wakingUp();

		/// <exception cref="android.os.RemoteException"></exception>
		void unhandledBack();

		/// <exception cref="android.os.RemoteException"></exception>
		android.os.ParcelFileDescriptor openContentUri(System.Uri uri);

		/// <exception cref="android.os.RemoteException"></exception>
		void setDebugApp(string packageName, bool waitForDebugger, bool persistent);

		/// <exception cref="android.os.RemoteException"></exception>
		void setAlwaysFinish(bool enabled);

		/// <exception cref="android.os.RemoteException"></exception>
		void setActivityController(android.app.IActivityController watcher);

		/// <exception cref="android.os.RemoteException"></exception>
		void enterSafeMode();

		/// <exception cref="android.os.RemoteException"></exception>
		void noteWakeupAlarm(android.content.IIntentSender sender);

		/// <exception cref="android.os.RemoteException"></exception>
		bool killPids(int[] pids, string reason, bool secure);

		// Special low-level communication with activity manager.
		/// <exception cref="android.os.RemoteException"></exception>
		void startRunning(string pkg, string cls, string action, string data);

		/// <exception cref="android.os.RemoteException"></exception>
		void handleApplicationCrash(android.os.IBinder app, android.app.ApplicationErrorReport
			.CrashInfo crashInfo);

		/// <exception cref="android.os.RemoteException"></exception>
		bool handleApplicationWtf(android.os.IBinder app, string tag, android.app.ApplicationErrorReport
			.CrashInfo crashInfo);

		// A StrictMode violation to be handled.  The violationMask is a
		// subset of the original StrictMode policy bitmask, with only the
		// bit violated and penalty bits to be executed by the
		// ActivityManagerService remaining set.
		/// <exception cref="android.os.RemoteException"></exception>
		void handleApplicationStrictModeViolation(android.os.IBinder app, int violationMask
			, android.os.StrictMode.ViolationInfo crashInfo);

		/// <exception cref="android.os.RemoteException"></exception>
		void signalPersistentProcesses(int signal);

		// Retrieve info of applications installed on external media that are currently
		// running.
		/// <exception cref="android.os.RemoteException"></exception>
		java.util.List<android.app.ActivityManager.RunningAppProcessInfo> getRunningAppProcesses
			();

		// Retrieve running application processes in the system
		/// <exception cref="android.os.RemoteException"></exception>
		java.util.List<android.content.pm.ApplicationInfo> getRunningExternalApplications
			();

		// Get device configuration
		/// <exception cref="android.os.RemoteException"></exception>
		android.content.pm.ConfigurationInfo getDeviceConfigurationInfo();

		// Turn on/off profiling in a particular process.
		/// <exception cref="android.os.RemoteException"></exception>
		bool profileControl(string process, bool start, string path, android.os.ParcelFileDescriptor
			 fd, int profileType);

		/// <exception cref="android.os.RemoteException"></exception>
		bool shutdown(int timeout);

		/// <exception cref="android.os.RemoteException"></exception>
		void stopAppSwitches();

		/// <exception cref="android.os.RemoteException"></exception>
		void resumeAppSwitches();

		/// <exception cref="android.os.RemoteException"></exception>
		void registerActivityWatcher(android.app.IActivityWatcher watcher);

		/// <exception cref="android.os.RemoteException"></exception>
		void unregisterActivityWatcher(android.app.IActivityWatcher watcher);

		/// <exception cref="android.os.RemoteException"></exception>
		int startActivityInPackage(int uid, android.content.Intent intent, string resolvedType
			, android.os.IBinder resultTo, string resultWho, int requestCode, bool onlyIfNeeded
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void killApplicationWithUid(string pkg, int uid);

		/// <exception cref="android.os.RemoteException"></exception>
		void closeSystemDialogs(string reason);

		/// <exception cref="android.os.RemoteException"></exception>
		android.os.Debug.MemoryInfo[] getProcessMemoryInfo(int[] pids);

		/// <exception cref="android.os.RemoteException"></exception>
		void overridePendingTransition(android.os.IBinder token, string packageName, int 
			enterAnim, int exitAnim);

		/// <exception cref="android.os.RemoteException"></exception>
		bool isUserAMonkey();

		/// <exception cref="android.os.RemoteException"></exception>
		void finishHeavyWeightApp();

		/// <exception cref="android.os.RemoteException"></exception>
		void setImmersive(android.os.IBinder token, bool immersive);

		/// <exception cref="android.os.RemoteException"></exception>
		bool isImmersive(android.os.IBinder token);

		/// <exception cref="android.os.RemoteException"></exception>
		bool isTopActivityImmersive();

		/// <exception cref="android.os.RemoteException"></exception>
		void crashApplication(int uid, int initialPid, string packageName, string message
			);

		/// <exception cref="android.os.RemoteException"></exception>
		string getProviderMimeType(System.Uri uri);

		/// <exception cref="android.os.RemoteException"></exception>
		android.os.IBinder newUriPermissionOwner(string name);

		/// <exception cref="android.os.RemoteException"></exception>
		void grantUriPermissionFromOwner(android.os.IBinder owner, int fromUid, string targetPkg
			, System.Uri uri, int mode);

		/// <exception cref="android.os.RemoteException"></exception>
		void revokeUriPermissionFromOwner(android.os.IBinder owner, System.Uri uri, int mode
			);

		/// <exception cref="android.os.RemoteException"></exception>
		int checkGrantUriPermission(int callingUid, string targetPkg, System.Uri uri, int
			 modeFlags);

		// Cause the specified process to dump the specified heap.
		/// <exception cref="android.os.RemoteException"></exception>
		bool dumpHeap(string process, bool managed, string path, android.os.ParcelFileDescriptor
			 fd);

		/// <exception cref="android.os.RemoteException"></exception>
		int startActivities(android.app.IApplicationThread caller, android.content.Intent
			[] intents, string[] resolvedTypes, android.os.IBinder resultTo);

		/// <exception cref="android.os.RemoteException"></exception>
		int startActivitiesInPackage(int uid, android.content.Intent[] intents, string[] 
			resolvedTypes, android.os.IBinder resultTo);

		/// <exception cref="android.os.RemoteException"></exception>
		int getFrontActivityScreenCompatMode();

		/// <exception cref="android.os.RemoteException"></exception>
		void setFrontActivityScreenCompatMode(int mode);

		/// <exception cref="android.os.RemoteException"></exception>
		int getPackageScreenCompatMode(string packageName);

		/// <exception cref="android.os.RemoteException"></exception>
		void setPackageScreenCompatMode(string packageName, int mode);

		/// <exception cref="android.os.RemoteException"></exception>
		bool getPackageAskScreenCompat(string packageName);

		/// <exception cref="android.os.RemoteException"></exception>
		void setPackageAskScreenCompat(string packageName, bool ask);

		// Multi-user APIs
		/// <exception cref="android.os.RemoteException"></exception>
		bool switchUser(int userid);

		/// <exception cref="android.os.RemoteException"></exception>
		bool removeSubTask(int taskId, int subTaskIndex);

		/// <exception cref="android.os.RemoteException"></exception>
		bool removeTask(int taskId, int flags);

		/// <exception cref="android.os.RemoteException"></exception>
		void registerProcessObserver(android.app.IProcessObserver observer);

		/// <exception cref="android.os.RemoteException"></exception>
		void unregisterProcessObserver(android.app.IProcessObserver observer);

		/// <exception cref="android.os.RemoteException"></exception>
		bool isIntentSenderTargetedToPackage(android.content.IIntentSender sender);

		/// <exception cref="android.os.RemoteException"></exception>
		void updatePersistentConfiguration(android.content.res.Configuration values);

		/// <exception cref="android.os.RemoteException"></exception>
		long[] getProcessPss(int[] pids);

		/// <exception cref="android.os.RemoteException"></exception>
		void showBootMessage(java.lang.CharSequence msg, bool always);

		/// <exception cref="android.os.RemoteException"></exception>
		void dismissKeyguardOnNextActivity();

		bool testIsSystemReady();
		// Please keep these transaction codes the same -- they are also
		// sent by C++ code.
		// Remaining non-native transaction codes.
	}

	/// <summary>System private API for talking with the activity manager service.</summary>
	/// <remarks>
	/// System private API for talking with the activity manager service.  This
	/// provides calls from the application back to the activity manager.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public static class IActivityManagerClass
	{
		/// <summary>
		/// Returned by startActivity() if the start request was canceled because
		/// app switches are temporarily canceled to ensure the user's last request
		/// (such as pressing home) is performed.
		/// </summary>
		/// <remarks>
		/// Returned by startActivity() if the start request was canceled because
		/// app switches are temporarily canceled to ensure the user's last request
		/// (such as pressing home) is performed.
		/// </remarks>
		public const int START_SWITCHES_CANCELED = 4;

		/// <summary>
		/// Returned by startActivity() if an activity wasn't really started, but
		/// the given Intent was given to the existing top activity.
		/// </summary>
		/// <remarks>
		/// Returned by startActivity() if an activity wasn't really started, but
		/// the given Intent was given to the existing top activity.
		/// </remarks>
		public const int START_DELIVERED_TO_TOP = 3;

		/// <summary>
		/// Returned by startActivity() if an activity wasn't really started, but
		/// a task was simply brought to the foreground.
		/// </summary>
		/// <remarks>
		/// Returned by startActivity() if an activity wasn't really started, but
		/// a task was simply brought to the foreground.
		/// </remarks>
		public const int START_TASK_TO_FRONT = 2;

		/// <summary>
		/// Returned by startActivity() if the caller asked that the Intent not
		/// be executed if it is the recipient, and that is indeed the case.
		/// </summary>
		/// <remarks>
		/// Returned by startActivity() if the caller asked that the Intent not
		/// be executed if it is the recipient, and that is indeed the case.
		/// </remarks>
		public const int START_RETURN_INTENT_TO_CALLER = 1;

		/// <summary>Activity was started successfully as normal.</summary>
		/// <remarks>Activity was started successfully as normal.</remarks>
		public const int START_SUCCESS = 0;

		public const int START_INTENT_NOT_RESOLVED = -1;

		public const int START_CLASS_NOT_FOUND = -2;

		public const int START_FORWARD_AND_REQUEST_CONFLICT = -3;

		public const int START_PERMISSION_DENIED = -4;

		public const int START_NOT_ACTIVITY = -5;

		public const int START_CANCELED = -6;

		public const int BROADCAST_SUCCESS = 0;

		public const int BROADCAST_STICKY_CANT_HAVE_PERMISSION = -1;

		public const int INTENT_SENDER_BROADCAST = 1;

		public const int INTENT_SENDER_ACTIVITY = 2;

		public const int INTENT_SENDER_ACTIVITY_RESULT = 3;

		public const int INTENT_SENDER_SERVICE = 4;

		/// <summary>Information you can retrieve about a particular application.</summary>
		/// <remarks>Information you can retrieve about a particular application.</remarks>
		public class ContentProviderHolder : android.os.Parcelable
		{
			public readonly android.content.pm.ProviderInfo info;

			public android.content.IContentProvider provider;

			public bool noReleaseNeeded;

			public ContentProviderHolder(android.content.pm.ProviderInfo _info)
			{
				info = _info;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				info.writeToParcel(dest, 0);
				if (provider != null)
				{
					dest.writeStrongBinder(provider.asBinder());
				}
				else
				{
					dest.writeStrongBinder(null);
				}
				dest.writeInt(noReleaseNeeded ? 1 : 0);
			}

			private sealed class _Creator_407 : android.os.ParcelableClass.Creator<android.app.IActivityManagerClass
				.ContentProviderHolder>
			{
				public _Creator_407()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.IActivityManagerClass.ContentProviderHolder createFromParcel(android.os.Parcel
					 source)
				{
					return new android.app.IActivityManagerClass.ContentProviderHolder(source);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.IActivityManagerClass.ContentProviderHolder[] newArray(int size
					)
				{
					return new android.app.IActivityManagerClass.ContentProviderHolder[size];
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.IActivityManagerClass
				.ContentProviderHolder> CREATOR = new _Creator_407();

			private ContentProviderHolder(android.os.Parcel source)
			{
				info = android.content.pm.ProviderInfo.CREATOR.createFromParcel(source);
				provider = android.content.ContentProviderNative.asInterface(source.readStrongBinder
					());
				noReleaseNeeded = source.readInt() != 0;
			}
		}

		/// <summary>Information returned after waiting for an activity start.</summary>
		/// <remarks>Information returned after waiting for an activity start.</remarks>
		public class WaitResult : android.os.Parcelable
		{
			public int result;

			public bool timeout;

			public android.content.ComponentName who;

			public long thisTime;

			public long totalTime;

			public WaitResult()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				dest.writeInt(result);
				dest.writeInt(timeout ? 1 : 0);
				android.content.ComponentName.writeToParcel(who, dest);
				dest.writeLong(thisTime);
				dest.writeLong(totalTime);
			}

			private sealed class _Creator_449 : android.os.ParcelableClass.Creator<android.app.IActivityManagerClass
				.WaitResult>
			{
				public _Creator_449()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.IActivityManagerClass.WaitResult createFromParcel(android.os.Parcel
					 source)
				{
					return new android.app.IActivityManagerClass.WaitResult(source);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.IActivityManagerClass.WaitResult[] newArray(int size)
				{
					return new android.app.IActivityManagerClass.WaitResult[size];
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.IActivityManagerClass
				.WaitResult> CREATOR = new _Creator_449();

			private WaitResult(android.os.Parcel source)
			{
				result = source.readInt();
				timeout = source.readInt() != 0;
				who = android.content.ComponentName.readFromParcel(source);
				thisTime = source.readLong();
				totalTime = source.readLong();
			}
		}

		public const string descriptor = "android.app.IActivityManager";

		public const int START_RUNNING_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION;

		public const int HANDLE_APPLICATION_CRASH_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 1;

		public const int START_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 2;

		public const int UNHANDLED_BACK_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 3;

		public const int OPEN_CONTENT_URI_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 4;

		public const int FINISH_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 10;

		public const int REGISTER_RECEIVER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 11;

		public const int UNREGISTER_RECEIVER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 12;

		public const int BROADCAST_INTENT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 13;

		public const int UNBROADCAST_INTENT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 14;

		public const int FINISH_RECEIVER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 15;

		public const int ATTACH_APPLICATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 16;

		public const int ACTIVITY_IDLE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 17;

		public const int ACTIVITY_PAUSED_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 18;

		public const int ACTIVITY_STOPPED_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 19;

		public const int GET_CALLING_PACKAGE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 20;

		public const int GET_CALLING_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 21;

		public const int GET_TASKS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 22;

		public const int MOVE_TASK_TO_FRONT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 23;

		public const int MOVE_TASK_TO_BACK_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 24;

		public const int MOVE_TASK_BACKWARDS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 25;

		public const int GET_TASK_FOR_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 26;

		public const int REPORT_THUMBNAIL_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 27;

		public const int GET_CONTENT_PROVIDER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 28;

		public const int PUBLISH_CONTENT_PROVIDERS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 29;

		public const int FINISH_SUB_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 31;

		public const int GET_RUNNING_SERVICE_CONTROL_PANEL_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 32;

		public const int START_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 33;

		public const int STOP_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 34;

		public const int BIND_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 35;

		public const int UNBIND_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 36;

		public const int PUBLISH_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 37;

		public const int FINISH_OTHER_INSTANCES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 38;

		public const int GOING_TO_SLEEP_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 39;

		public const int WAKING_UP_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 40;

		public const int SET_DEBUG_APP_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 41;

		public const int SET_ALWAYS_FINISH_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 42;

		public const int START_INSTRUMENTATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 43;

		public const int FINISH_INSTRUMENTATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 44;

		public const int GET_CONFIGURATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 45;

		public const int UPDATE_CONFIGURATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 46;

		public const int STOP_SERVICE_TOKEN_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 47;

		public const int GET_ACTIVITY_CLASS_FOR_TOKEN_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 48;

		public const int GET_PACKAGE_FOR_TOKEN_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 49;

		public const int SET_PROCESS_LIMIT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 50;

		public const int GET_PROCESS_LIMIT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 51;

		public const int CHECK_PERMISSION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 52;

		public const int CHECK_URI_PERMISSION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 53;

		public const int GRANT_URI_PERMISSION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 54;

		public const int REVOKE_URI_PERMISSION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 55;

		public const int SET_ACTIVITY_CONTROLLER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 56;

		public const int SHOW_WAITING_FOR_DEBUGGER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 57;

		public const int SIGNAL_PERSISTENT_PROCESSES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 58;

		public const int GET_RECENT_TASKS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 59;

		public const int SERVICE_DONE_EXECUTING_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 60;

		public const int ACTIVITY_DESTROYED_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 61;

		public const int GET_INTENT_SENDER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 62;

		public const int CANCEL_INTENT_SENDER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 63;

		public const int GET_PACKAGE_FOR_INTENT_SENDER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 64;

		public const int ENTER_SAFE_MODE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 65;

		public const int START_NEXT_MATCHING_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 66;

		public const int NOTE_WAKEUP_ALARM_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 67;

		public const int REMOVE_CONTENT_PROVIDER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 68;

		public const int SET_REQUESTED_ORIENTATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 69;

		public const int GET_REQUESTED_ORIENTATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 70;

		public const int UNBIND_FINISHED_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 71;

		public const int SET_PROCESS_FOREGROUND_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 72;

		public const int SET_SERVICE_FOREGROUND_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 73;

		public const int MOVE_ACTIVITY_TASK_TO_BACK_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 74;

		public const int GET_MEMORY_INFO_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 75;

		public const int GET_PROCESSES_IN_ERROR_STATE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 76;

		public const int CLEAR_APP_DATA_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 77;

		public const int FORCE_STOP_PACKAGE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 78;

		public const int KILL_PIDS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 79;

		public const int GET_SERVICES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 80;

		public const int GET_TASK_THUMBNAILS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 81;

		public const int GET_RUNNING_APP_PROCESSES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 82;

		public const int GET_DEVICE_CONFIGURATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 83;

		public const int PEEK_SERVICE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 84;

		public const int PROFILE_CONTROL_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 85;

		public const int SHUTDOWN_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 86;

		public const int STOP_APP_SWITCHES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 87;

		public const int RESUME_APP_SWITCHES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 88;

		public const int START_BACKUP_AGENT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 89;

		public const int BACKUP_AGENT_CREATED_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 90;

		public const int UNBIND_BACKUP_AGENT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 91;

		public const int REGISTER_ACTIVITY_WATCHER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 92;

		public const int UNREGISTER_ACTIVITY_WATCHER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 93;

		public const int START_ACTIVITY_IN_PACKAGE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 94;

		public const int KILL_APPLICATION_WITH_UID_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 95;

		public const int CLOSE_SYSTEM_DIALOGS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 96;

		public const int GET_PROCESS_MEMORY_INFO_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 97;

		public const int KILL_APPLICATION_PROCESS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 98;

		public const int START_ACTIVITY_INTENT_SENDER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 99;

		public const int OVERRIDE_PENDING_TRANSITION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 100;

		public const int HANDLE_APPLICATION_WTF_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 101;

		public const int KILL_BACKGROUND_PROCESSES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 102;

		public const int IS_USER_A_MONKEY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 103;

		public const int START_ACTIVITY_AND_WAIT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 104;

		public const int WILL_ACTIVITY_BE_VISIBLE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 105;

		public const int START_ACTIVITY_WITH_CONFIG_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 106;

		public const int GET_RUNNING_EXTERNAL_APPLICATIONS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 107;

		public const int FINISH_HEAVY_WEIGHT_APP_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 108;

		public const int HANDLE_APPLICATION_STRICT_MODE_VIOLATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 109;

		public const int IS_IMMERSIVE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 110;

		public const int SET_IMMERSIVE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 111;

		public const int IS_TOP_ACTIVITY_IMMERSIVE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 112;

		public const int CRASH_APPLICATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 113;

		public const int GET_PROVIDER_MIME_TYPE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 114;

		public const int NEW_URI_PERMISSION_OWNER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 115;

		public const int GRANT_URI_PERMISSION_FROM_OWNER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 116;

		public const int REVOKE_URI_PERMISSION_FROM_OWNER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 117;

		public const int CHECK_GRANT_URI_PERMISSION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 118;

		public const int DUMP_HEAP_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 119;

		public const int START_ACTIVITIES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 120;

		public const int START_ACTIVITIES_IN_PACKAGE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 121;

		public const int ACTIVITY_SLEPT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 122;

		public const int GET_FRONT_ACTIVITY_SCREEN_COMPAT_MODE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 123;

		public const int SET_FRONT_ACTIVITY_SCREEN_COMPAT_MODE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 124;

		public const int GET_PACKAGE_SCREEN_COMPAT_MODE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 125;

		public const int SET_PACKAGE_SCREEN_COMPAT_MODE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 126;

		public const int GET_PACKAGE_ASK_SCREEN_COMPAT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 127;

		public const int SET_PACKAGE_ASK_SCREEN_COMPAT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 128;

		public const int SWITCH_USER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 129;

		public const int REMOVE_SUB_TASK_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 130;

		public const int REMOVE_TASK_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 131;

		public const int REGISTER_PROCESS_OBSERVER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 132;

		public const int UNREGISTER_PROCESS_OBSERVER_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 133;

		public const int IS_INTENT_SENDER_TARGETED_TO_PACKAGE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 134;

		public const int UPDATE_PERSISTENT_CONFIGURATION_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 135;

		public const int GET_PROCESS_PSS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 136;

		public const int SHOW_BOOT_MESSAGE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 137;

		public const int DISMISS_KEYGUARD_ON_NEXT_ACTIVITY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 138;
	}
}
