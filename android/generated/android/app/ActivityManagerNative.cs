using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class ActivityManagerNative : android.os.Binder, android.app.IActivityManager
	{
		[Sharpen.Stub]
		public static android.app.IActivityManager asInterface(android.os.IBinder obj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.IActivityManager getDefault()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isSystemReady()
		{
			throw new System.NotImplementedException();
		}

		internal static bool sSystemReady = false;

		[Sharpen.Stub]
		public static void broadcastStickyIntent(android.content.Intent intent, string permission
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void noteWakeupAlarm(android.app.PendingIntent ps)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ActivityManagerNative()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Binder")]
		protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
			 reply, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IInterface")]
		public virtual android.os.IBinder asBinder()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Singleton_1569 : android.util.Singleton<android.app.IActivityManager
			>
		{
			public _Singleton_1569()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.util.Singleton")]
			protected internal override android.app.IActivityManager create()
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly android.util.Singleton<android.app.IActivityManager> gDefault
			 = new _Singleton_1569();

		public abstract void activityDestroyed(android.os.IBinder arg1);

		public abstract void activityIdle(android.os.IBinder arg1, android.content.res.Configuration
			 arg2, bool arg3);

		public abstract void activityPaused(android.os.IBinder arg1);

		public abstract void activitySlept(android.os.IBinder arg1);

		public abstract void activityStopped(android.os.IBinder arg1, android.os.Bundle arg2
			, android.graphics.Bitmap arg3, java.lang.CharSequence arg4);

		public abstract void attachApplication(android.app.IApplicationThread arg1);

		public abstract void backupAgentCreated(string arg1, android.os.IBinder arg2);

		public abstract bool bindBackupAgent(android.content.pm.ApplicationInfo arg1, int
			 arg2);

		public abstract int bindService(android.app.IApplicationThread arg1, android.os.IBinder
			 arg2, android.content.Intent arg3, string arg4, android.app.IServiceConnection 
			arg5, int arg6);

		public abstract int broadcastIntent(android.app.IApplicationThread arg1, android.content.Intent
			 arg2, string arg3, android.content.IIntentReceiver arg4, int arg5, string arg6, 
			android.os.Bundle arg7, string arg8, bool arg9, bool arg10);

		public abstract void cancelIntentSender(android.content.IIntentSender arg1);

		public abstract int checkGrantUriPermission(int arg1, string arg2, System.Uri arg3
			, int arg4);

		public abstract int checkPermission(string arg1, int arg2, int arg3);

		public abstract int checkUriPermission(System.Uri arg1, int arg2, int arg3, int arg4
			);

		public abstract bool clearApplicationUserData(string arg1, android.content.pm.IPackageDataObserver
			 arg2);

		public abstract void closeSystemDialogs(string arg1);

		public abstract void crashApplication(int arg1, int arg2, string arg3, string arg4
			);

		public abstract void dismissKeyguardOnNextActivity();

		public abstract bool dumpHeap(string arg1, bool arg2, string arg3, android.os.ParcelFileDescriptor
			 arg4);

		public abstract void enterSafeMode();

		public abstract bool finishActivity(android.os.IBinder arg1, int arg2, android.content.Intent
			 arg3);

		public abstract void finishHeavyWeightApp();

		public abstract void finishInstrumentation(android.app.IApplicationThread arg1, int
			 arg2, android.os.Bundle arg3);

		public abstract void finishOtherInstances(android.os.IBinder arg1, android.content.ComponentName
			 arg2);

		public abstract void finishReceiver(android.os.IBinder arg1, int arg2, string arg3
			, android.os.Bundle arg4, bool arg5);

		public abstract void finishSubActivity(android.os.IBinder arg1, string arg2, int 
			arg3);

		public abstract void forceStopPackage(string arg1);

		public abstract android.content.ComponentName getActivityClassForToken(android.os.IBinder
			 arg1);

		public abstract android.content.ComponentName getCallingActivity(android.os.IBinder
			 arg1);

		public abstract string getCallingPackage(android.os.IBinder arg1);

		public abstract android.content.res.Configuration getConfiguration();

		public abstract android.app.IActivityManagerClass.ContentProviderHolder getContentProvider
			(android.app.IApplicationThread arg1, string arg2);

		public abstract android.content.pm.ConfigurationInfo getDeviceConfigurationInfo();

		public abstract int getFrontActivityScreenCompatMode();

		public abstract android.content.IIntentSender getIntentSender(int arg1, string arg2
			, android.os.IBinder arg3, string arg4, int arg5, android.content.Intent[] arg6, 
			string[] arg7, int arg8);

		public abstract void getMemoryInfo(android.app.ActivityManager.MemoryInfo arg1);

		public abstract bool getPackageAskScreenCompat(string arg1);

		public abstract string getPackageForIntentSender(android.content.IIntentSender arg1
			);

		public abstract string getPackageForToken(android.os.IBinder arg1);

		public abstract int getPackageScreenCompatMode(string arg1);

		public abstract int getProcessLimit();

		public abstract android.os.Debug.MemoryInfo[] getProcessMemoryInfo(int[] arg1);

		public abstract long[] getProcessPss(int[] arg1);

		public abstract java.util.List<android.app.ActivityManager.ProcessErrorStateInfo>
			 getProcessesInErrorState();

		public abstract string getProviderMimeType(System.Uri arg1);

		public abstract java.util.List<android.app.ActivityManager.RecentTaskInfo> getRecentTasks
			(int arg1, int arg2);

		public abstract int getRequestedOrientation(android.os.IBinder arg1);

		public abstract java.util.List<android.app.ActivityManager.RunningAppProcessInfo>
			 getRunningAppProcesses();

		public abstract java.util.List<android.content.pm.ApplicationInfo> getRunningExternalApplications
			();

		public abstract android.app.PendingIntent getRunningServiceControlPanel(android.content.ComponentName
			 arg1);

		public abstract java.util.List<object> getServices(int arg1, int arg2);

		public abstract int getTaskForActivity(android.os.IBinder arg1, bool arg2);

		public abstract android.app.ActivityManager.TaskThumbnails getTaskThumbnails(int 
			arg1);

		public abstract java.util.List<object> getTasks(int arg1, int arg2, android.app.IThumbnailReceiver
			 arg3);

		public abstract void goingToSleep();

		public abstract void grantUriPermission(android.app.IApplicationThread arg1, string
			 arg2, System.Uri arg3, int arg4);

		public abstract void grantUriPermissionFromOwner(android.os.IBinder arg1, int arg2
			, string arg3, System.Uri arg4, int arg5);

		public abstract void handleApplicationCrash(android.os.IBinder arg1, android.app.ApplicationErrorReport
			.CrashInfo arg2);

		public abstract void handleApplicationStrictModeViolation(android.os.IBinder arg1
			, int arg2, android.os.StrictMode.ViolationInfo arg3);

		public abstract bool handleApplicationWtf(android.os.IBinder arg1, string arg2, android.app.ApplicationErrorReport
			.CrashInfo arg3);

		public abstract bool isImmersive(android.os.IBinder arg1);

		public abstract bool isIntentSenderTargetedToPackage(android.content.IIntentSender
			 arg1);

		public abstract bool isTopActivityImmersive();

		public abstract bool isUserAMonkey();

		public abstract void killApplicationProcess(string arg1, int arg2);

		public abstract void killApplicationWithUid(string arg1, int arg2);

		public abstract void killBackgroundProcesses(string arg1);

		public abstract bool killPids(int[] arg1, string arg2, bool arg3);

		public abstract bool moveActivityTaskToBack(android.os.IBinder arg1, bool arg2);

		public abstract void moveTaskBackwards(int arg1);

		public abstract void moveTaskToBack(int arg1);

		public abstract void moveTaskToFront(int arg1, int arg2);

		public abstract android.os.IBinder newUriPermissionOwner(string arg1);

		public abstract void noteWakeupAlarm(android.content.IIntentSender arg1);

		public abstract android.os.ParcelFileDescriptor openContentUri(System.Uri arg1);

		public abstract void overridePendingTransition(android.os.IBinder arg1, string arg2
			, int arg3, int arg4);

		public abstract android.os.IBinder peekService(android.content.Intent arg1, string
			 arg2);

		public abstract bool profileControl(string arg1, bool arg2, string arg3, android.os.ParcelFileDescriptor
			 arg4, int arg5);

		public abstract void publishContentProviders(android.app.IApplicationThread arg1, 
			java.util.List<android.app.IActivityManagerClass.ContentProviderHolder> arg2);

		public abstract void publishService(android.os.IBinder arg1, android.content.Intent
			 arg2, android.os.IBinder arg3);

		public abstract void registerActivityWatcher(android.app.IActivityWatcher arg1);

		public abstract void registerProcessObserver(android.app.IProcessObserver arg1);

		public abstract android.content.Intent registerReceiver(android.app.IApplicationThread
			 arg1, string arg2, android.content.IIntentReceiver arg3, android.content.IntentFilter
			 arg4, string arg5);

		public abstract void removeContentProvider(android.app.IApplicationThread arg1, string
			 arg2);

		public abstract bool removeSubTask(int arg1, int arg2);

		public abstract bool removeTask(int arg1, int arg2);

		public abstract void reportThumbnail(android.os.IBinder arg1, android.graphics.Bitmap
			 arg2, java.lang.CharSequence arg3);

		public abstract void resumeAppSwitches();

		public abstract void revokeUriPermission(android.app.IApplicationThread arg1, System.Uri
			 arg2, int arg3);

		public abstract void revokeUriPermissionFromOwner(android.os.IBinder arg1, System.Uri
			 arg2, int arg3);

		public abstract void serviceDoneExecuting(android.os.IBinder arg1, int arg2, int 
			arg3, int arg4);

		public abstract void setActivityController(android.app.IActivityController arg1);

		public abstract void setAlwaysFinish(bool arg1);

		public abstract void setDebugApp(string arg1, bool arg2, bool arg3);

		public abstract void setFrontActivityScreenCompatMode(int arg1);

		public abstract void setImmersive(android.os.IBinder arg1, bool arg2);

		public abstract void setPackageAskScreenCompat(string arg1, bool arg2);

		public abstract void setPackageScreenCompatMode(string arg1, int arg2);

		public abstract void setProcessForeground(android.os.IBinder arg1, int arg2, bool
			 arg3);

		public abstract void setProcessLimit(int arg1);

		public abstract void setRequestedOrientation(android.os.IBinder arg1, int arg2);

		public abstract void setServiceForeground(android.content.ComponentName arg1, android.os.IBinder
			 arg2, int arg3, android.app.Notification arg4, bool arg5);

		public abstract void showBootMessage(java.lang.CharSequence arg1, bool arg2);

		public abstract void showWaitingForDebugger(android.app.IApplicationThread arg1, 
			bool arg2);

		public abstract bool shutdown(int arg1);

		public abstract void signalPersistentProcesses(int arg1);

		public abstract int startActivities(android.app.IApplicationThread arg1, android.content.Intent
			[] arg2, string[] arg3, android.os.IBinder arg4);

		public abstract int startActivitiesInPackage(int arg1, android.content.Intent[] arg2
			, string[] arg3, android.os.IBinder arg4);

		public abstract int startActivity(android.app.IApplicationThread arg1, android.content.Intent
			 arg2, string arg3, System.Uri[] arg4, int arg5, android.os.IBinder arg6, string
			 arg7, int arg8, bool arg9, bool arg10, string arg11, android.os.ParcelFileDescriptor
			 arg12, bool arg13);

		public abstract android.app.IActivityManagerClass.WaitResult startActivityAndWait
			(android.app.IApplicationThread arg1, android.content.Intent arg2, string arg3, 
			System.Uri[] arg4, int arg5, android.os.IBinder arg6, string arg7, int arg8, bool
			 arg9, bool arg10, string arg11, android.os.ParcelFileDescriptor arg12, bool arg13
			);

		public abstract int startActivityInPackage(int arg1, android.content.Intent arg2, 
			string arg3, android.os.IBinder arg4, string arg5, int arg6, bool arg7);

		public abstract int startActivityIntentSender(android.app.IApplicationThread arg1
			, android.content.IntentSender arg2, android.content.Intent arg3, string arg4, android.os.IBinder
			 arg5, string arg6, int arg7, int arg8, int arg9);

		public abstract int startActivityWithConfig(android.app.IApplicationThread arg1, 
			android.content.Intent arg2, string arg3, System.Uri[] arg4, int arg5, android.os.IBinder
			 arg6, string arg7, int arg8, bool arg9, bool arg10, android.content.res.Configuration
			 arg11);

		public abstract bool startInstrumentation(android.content.ComponentName arg1, string
			 arg2, int arg3, android.os.Bundle arg4, android.app.IInstrumentationWatcher arg5
			);

		public abstract bool startNextMatchingActivity(android.os.IBinder arg1, android.content.Intent
			 arg2);

		public abstract void startRunning(string arg1, string arg2, string arg3, string arg4
			);

		public abstract android.content.ComponentName startService(android.app.IApplicationThread
			 arg1, android.content.Intent arg2, string arg3);

		public abstract void stopAppSwitches();

		public abstract int stopService(android.app.IApplicationThread arg1, android.content.Intent
			 arg2, string arg3);

		public abstract bool stopServiceToken(android.content.ComponentName arg1, android.os.IBinder
			 arg2, int arg3);

		public abstract bool switchUser(int arg1);

		public abstract bool testIsSystemReady();

		public abstract void unbindBackupAgent(android.content.pm.ApplicationInfo arg1);

		public abstract void unbindFinished(android.os.IBinder arg1, android.content.Intent
			 arg2, bool arg3);

		public abstract bool unbindService(android.app.IServiceConnection arg1);

		public abstract void unbroadcastIntent(android.app.IApplicationThread arg1, android.content.Intent
			 arg2);

		public abstract void unhandledBack();

		public abstract void unregisterActivityWatcher(android.app.IActivityWatcher arg1);

		public abstract void unregisterProcessObserver(android.app.IProcessObserver arg1);

		public abstract void unregisterReceiver(android.content.IIntentReceiver arg1);

		public abstract void updateConfiguration(android.content.res.Configuration arg1);

		public abstract void updatePersistentConfiguration(android.content.res.Configuration
			 arg1);

		public abstract void wakingUp();

		public abstract bool willActivityBeVisible(android.os.IBinder arg1);
	}

	[Sharpen.Stub]
	internal class ActivityManagerProxy : android.app.IActivityManager
	{
		[Sharpen.Stub]
		public ActivityManagerProxy(android.os.IBinder remote)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IInterface")]
		public virtual android.os.IBinder asBinder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int startActivity(android.app.IApplicationThread caller, android.content.Intent
			 intent, string resolvedType, System.Uri[] grantedUriPermissions, int grantedMode
			, android.os.IBinder resultTo, string resultWho, int requestCode, bool onlyIfNeeded
			, bool debug, string profileFile, android.os.ParcelFileDescriptor profileFd, bool
			 autoStopProfiler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.app.IActivityManagerClass.WaitResult startActivityAndWait(
			android.app.IApplicationThread caller, android.content.Intent intent, string resolvedType
			, System.Uri[] grantedUriPermissions, int grantedMode, android.os.IBinder resultTo
			, string resultWho, int requestCode, bool onlyIfNeeded, bool debug, string profileFile
			, android.os.ParcelFileDescriptor profileFd, bool autoStopProfiler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int startActivityWithConfig(android.app.IApplicationThread caller, 
			android.content.Intent intent, string resolvedType, System.Uri[] grantedUriPermissions
			, int grantedMode, android.os.IBinder resultTo, string resultWho, int requestCode
			, bool onlyIfNeeded, bool debug, android.content.res.Configuration config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int startActivityIntentSender(android.app.IApplicationThread caller
			, android.content.IntentSender intent, android.content.Intent fillInIntent, string
			 resolvedType, android.os.IBinder resultTo, string resultWho, int requestCode, int
			 flagsMask, int flagsValues)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool startNextMatchingActivity(android.os.IBinder callingActivity, 
			android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool finishActivity(android.os.IBinder token, int resultCode, android.content.Intent
			 resultData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void finishSubActivity(android.os.IBinder token, string resultWho, 
			int requestCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool willActivityBeVisible(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.content.Intent registerReceiver(android.app.IApplicationThread
			 caller, string packageName, android.content.IIntentReceiver receiver, android.content.IntentFilter
			 filter, string perm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void unregisterReceiver(android.content.IIntentReceiver receiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int broadcastIntent(android.app.IApplicationThread caller, android.content.Intent
			 intent, string resolvedType, android.content.IIntentReceiver resultTo, int resultCode
			, string resultData, android.os.Bundle map, string requiredPermission, bool serialized
			, bool sticky)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void unbroadcastIntent(android.app.IApplicationThread caller, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void finishReceiver(android.os.IBinder who, int resultCode, string
			 resultData, android.os.Bundle map, bool abortBroadcast)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void attachApplication(android.app.IApplicationThread app)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void activityIdle(android.os.IBinder token, android.content.res.Configuration
			 config, bool stopProfiling)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void activityPaused(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void activityStopped(android.os.IBinder token, android.os.Bundle state
			, android.graphics.Bitmap thumbnail, java.lang.CharSequence description)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void activitySlept(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void activityDestroyed(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual string getCallingPackage(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.content.ComponentName getCallingActivity(android.os.IBinder
			 token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual java.util.List<object> getTasks(int maxNum, int flags, android.app.IThumbnailReceiver
			 receiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual java.util.List<android.app.ActivityManager.RecentTaskInfo> getRecentTasks
			(int maxNum, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.app.ActivityManager.TaskThumbnails getTaskThumbnails(int id
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual java.util.List<object> getServices(int maxNum, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual java.util.List<android.app.ActivityManager.ProcessErrorStateInfo> 
			getProcessesInErrorState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual java.util.List<android.app.ActivityManager.RunningAppProcessInfo> 
			getRunningAppProcesses()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual java.util.List<android.content.pm.ApplicationInfo> getRunningExternalApplications
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void moveTaskToFront(int task, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void moveTaskToBack(int task)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool moveActivityTaskToBack(android.os.IBinder token, bool nonRoot
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void moveTaskBackwards(int task)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int getTaskForActivity(android.os.IBinder token, bool onlyRoot)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void finishOtherInstances(android.os.IBinder token, android.content.ComponentName
			 className)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void reportThumbnail(android.os.IBinder token, android.graphics.Bitmap
			 thumbnail, java.lang.CharSequence description)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.app.IActivityManagerClass.ContentProviderHolder getContentProvider
			(android.app.IApplicationThread caller, string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void publishContentProviders(android.app.IApplicationThread caller
			, java.util.List<android.app.IActivityManagerClass.ContentProviderHolder> providers
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void removeContentProvider(android.app.IApplicationThread caller, 
			string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.app.PendingIntent getRunningServiceControlPanel(android.content.ComponentName
			 service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.content.ComponentName startService(android.app.IApplicationThread
			 caller, android.content.Intent service, string resolvedType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int stopService(android.app.IApplicationThread caller, android.content.Intent
			 service, string resolvedType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool stopServiceToken(android.content.ComponentName className, android.os.IBinder
			 token, int startId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setServiceForeground(android.content.ComponentName className, 
			android.os.IBinder token, int id, android.app.Notification notification, bool removeNotification
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int bindService(android.app.IApplicationThread caller, android.os.IBinder
			 token, android.content.Intent service, string resolvedType, android.app.IServiceConnection
			 connection, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool unbindService(android.app.IServiceConnection connection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void publishService(android.os.IBinder token, android.content.Intent
			 intent, android.os.IBinder service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void unbindFinished(android.os.IBinder token, android.content.Intent
			 intent, bool doRebind)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void serviceDoneExecuting(android.os.IBinder token, int type, int 
			startId, int res)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.os.IBinder peekService(android.content.Intent service, string
			 resolvedType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool bindBackupAgent(android.content.pm.ApplicationInfo app, int backupRestoreMode
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void backupAgentCreated(string packageName, android.os.IBinder agent
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void unbindBackupAgent(android.content.pm.ApplicationInfo app)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool startInstrumentation(android.content.ComponentName className, 
			string profileFile, int flags, android.os.Bundle arguments, android.app.IInstrumentationWatcher
			 watcher)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void finishInstrumentation(android.app.IApplicationThread target, 
			int resultCode, android.os.Bundle results)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.content.res.Configuration getConfiguration()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void updateConfiguration(android.content.res.Configuration values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setRequestedOrientation(android.os.IBinder token, int requestedOrientation
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int getRequestedOrientation(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.content.ComponentName getActivityClassForToken(android.os.IBinder
			 token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual string getPackageForToken(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.content.IIntentSender getIntentSender(int type, string packageName
			, android.os.IBinder token, string resultWho, int requestCode, android.content.Intent
			[] intents, string[] resolvedTypes, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void cancelIntentSender(android.content.IIntentSender sender)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual string getPackageForIntentSender(android.content.IIntentSender sender
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setProcessLimit(int max)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int getProcessLimit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setProcessForeground(android.os.IBinder token, int pid, bool 
			isForeground)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int checkPermission(string permission, int pid, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool clearApplicationUserData(string packageName, android.content.pm.IPackageDataObserver
			 observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int checkUriPermission(System.Uri uri, int pid, int uid, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void grantUriPermission(android.app.IApplicationThread caller, string
			 targetPkg, System.Uri uri, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void revokeUriPermission(android.app.IApplicationThread caller, System.Uri
			 uri, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void showWaitingForDebugger(android.app.IApplicationThread who, bool
			 waiting)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void getMemoryInfo(android.app.ActivityManager.MemoryInfo outInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void unhandledBack()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.os.ParcelFileDescriptor openContentUri(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void goingToSleep()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void wakingUp()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setDebugApp(string packageName, bool waitForDebugger, bool persistent
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setAlwaysFinish(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setActivityController(android.app.IActivityController watcher
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void enterSafeMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void noteWakeupAlarm(android.content.IIntentSender sender)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool killPids(int[] pids, string reason, bool secure)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void startRunning(string pkg, string cls, string action, string indata
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool testIsSystemReady()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void handleApplicationCrash(android.os.IBinder app, android.app.ApplicationErrorReport
			.CrashInfo crashInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool handleApplicationWtf(android.os.IBinder app, string tag, android.app.ApplicationErrorReport
			.CrashInfo crashInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void handleApplicationStrictModeViolation(android.os.IBinder app, 
			int violationMask, android.os.StrictMode.ViolationInfo info)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void signalPersistentProcesses(int sig)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void killBackgroundProcesses(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void forceStopPackage(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.content.pm.ConfigurationInfo getDeviceConfigurationInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool profileControl(string process, bool start, string path, android.os.ParcelFileDescriptor
			 fd, int profileType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool shutdown(int timeout)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void stopAppSwitches()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void resumeAppSwitches()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void registerActivityWatcher(android.app.IActivityWatcher watcher)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void unregisterActivityWatcher(android.app.IActivityWatcher watcher
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int startActivityInPackage(int uid, android.content.Intent intent, 
			string resolvedType, android.os.IBinder resultTo, string resultWho, int requestCode
			, bool onlyIfNeeded)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void killApplicationWithUid(string pkg, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void closeSystemDialogs(string reason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.os.Debug.MemoryInfo[] getProcessMemoryInfo(int[] pids)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void killApplicationProcess(string processName, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void overridePendingTransition(android.os.IBinder token, string packageName
			, int enterAnim, int exitAnim)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool isUserAMonkey()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void finishHeavyWeightApp()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setImmersive(android.os.IBinder token, bool immersive)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool isImmersive(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool isTopActivityImmersive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void crashApplication(int uid, int initialPid, string packageName, 
			string message)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual string getProviderMimeType(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual android.os.IBinder newUriPermissionOwner(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void grantUriPermissionFromOwner(android.os.IBinder owner, int fromUid
			, string targetPkg, System.Uri uri, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void revokeUriPermissionFromOwner(android.os.IBinder owner, System.Uri
			 uri, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int checkGrantUriPermission(int callingUid, string targetPkg, System.Uri
			 uri, int modeFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool dumpHeap(string process, bool managed, string path, android.os.ParcelFileDescriptor
			 fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int startActivities(android.app.IApplicationThread caller, android.content.Intent
			[] intents, string[] resolvedTypes, android.os.IBinder resultTo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int startActivitiesInPackage(int uid, android.content.Intent[] intents
			, string[] resolvedTypes, android.os.IBinder resultTo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int getFrontActivityScreenCompatMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setFrontActivityScreenCompatMode(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual int getPackageScreenCompatMode(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setPackageScreenCompatMode(string packageName, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool getPackageAskScreenCompat(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void setPackageAskScreenCompat(string packageName, bool ask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool switchUser(int userid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool removeSubTask(int taskId, int subTaskIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool removeTask(int taskId, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void registerProcessObserver(android.app.IProcessObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void unregisterProcessObserver(android.app.IProcessObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual bool isIntentSenderTargetedToPackage(android.content.IIntentSender
			 sender)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void updatePersistentConfiguration(android.content.res.Configuration
			 values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual long[] getProcessPss(int[] pids)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void showBootMessage(java.lang.CharSequence msg, bool always)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IActivityManager")]
		public virtual void dismissKeyguardOnNextActivity()
		{
			throw new System.NotImplementedException();
		}

		private android.os.IBinder mRemote;
	}
}
