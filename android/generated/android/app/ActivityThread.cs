using Sharpen;

namespace android.app
{
	[System.Serializable]
	[Sharpen.Sharpened]
	internal sealed class SuperNotCalledException : android.util.AndroidRuntimeException
	{
		public SuperNotCalledException(string msg) : base(msg)
		{
		}
	}

	[System.Serializable]
	[Sharpen.Sharpened]
	internal sealed class RemoteServiceException : android.util.AndroidRuntimeException
	{
		public RemoteServiceException(string msg) : base(msg)
		{
		}
	}

	/// <summary>
	/// This manages the execution of the main thread in an
	/// application process, scheduling and executing activities,
	/// broadcasts, and other operations on it as the activity
	/// manager requests.
	/// </summary>
	/// <remarks>
	/// This manages the execution of the main thread in an
	/// application process, scheduling and executing activities,
	/// broadcasts, and other operations on it as the activity
	/// manager requests.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed partial class ActivityThread
	{
		/// <hide></hide>
		internal const string TAG = "ActivityThread";

		private static readonly android.graphics.Bitmap.Config THUMBNAIL_FORMAT = android.graphics.Bitmap.Config
			.RGB_565;

		private const bool localLOGV = false;

		private const bool DEBUG_MESSAGES = false;

		/// <hide></hide>
		private const bool DEBUG_BROADCAST = false;

		private const bool DEBUG_RESULTS = false;

		private const bool DEBUG_BACKUP = true;

		private const bool DEBUG_CONFIGURATION = false;

		private const long MIN_TIME_BETWEEN_GCS = 5 * 1000;

		private static readonly java.util.regex.Pattern PATTERN_SEMICOLON = java.util.regex.Pattern
			.compile(";");

		private const int SQLITE_MEM_RELEASED_EVENT_LOG_TAG = 75003;

		private const int LOG_ON_PAUSE_CALLED = 30021;

		private const int LOG_ON_RESUME_CALLED = 30022;

		internal static android.app.ContextImpl mSystemContext = null;

		private static android.content.pm.IPackageManager sPackageManager;

		private readonly android.app.ActivityThread.ApplicationThread mAppThread;

		internal readonly android.os.Looper mLooper;

		private readonly android.app.ActivityThread.H mH;

		private readonly java.util.HashMap<android.os.IBinder, android.app.ActivityThread
			.ActivityClientRecord> mActivities = new java.util.HashMap<android.os.IBinder, android.app.ActivityThread
			.ActivityClientRecord>();

		private android.app.ActivityThread.ActivityClientRecord mNewActivities = null;

		private int mNumVisibleActivities = 0;

		private readonly java.util.HashMap<android.os.IBinder, android.app.Service> mServices
			 = new java.util.HashMap<android.os.IBinder, android.app.Service>();

		private android.app.ActivityThread.AppBindData mBoundApplication;

		private android.app.ActivityThread.Profiler mProfiler;

		private android.content.res.Configuration mConfiguration;

		private android.content.res.Configuration mCompatConfiguration;

		private android.content.res.Configuration mResConfiguration;

		private android.content.res.CompatibilityInfo mResCompatibilityInfo;

		private android.app.Application mInitialApplication;

		internal readonly java.util.ArrayList<android.app.Application> mAllApplications = 
			new java.util.ArrayList<android.app.Application>();

		private readonly java.util.HashMap<string, android.app.backup.BackupAgent> mBackupAgents
			 = new java.util.HashMap<string, android.app.backup.BackupAgent>();

		private static readonly java.lang.ThreadLocal<android.app.ActivityThread> sThreadLocal
			 = new java.lang.ThreadLocal<android.app.ActivityThread>();

		internal android.app.Instrumentation mInstrumentation;

		internal string mInstrumentationAppDir = null;

		internal string mInstrumentationAppPackage = null;

		internal string mInstrumentedAppDir = null;

		private bool mSystemThread = false;

		private bool mJitEnabled = false;

		private readonly java.util.HashMap<string, java.lang.@ref.WeakReference<android.app.LoadedApk
			>> mPackages = new java.util.HashMap<string, java.lang.@ref.WeakReference<android.app.LoadedApk
			>>();

		private readonly java.util.HashMap<string, java.lang.@ref.WeakReference<android.app.LoadedApk
			>> mResourcePackages = new java.util.HashMap<string, java.lang.@ref.WeakReference
			<android.app.LoadedApk>>();

		private readonly java.util.HashMap<android.content.res.CompatibilityInfo, android.util.DisplayMetrics
			> mDisplayMetrics = new java.util.HashMap<android.content.res.CompatibilityInfo, 
			android.util.DisplayMetrics>();

		private readonly java.util.HashMap<android.app.ActivityThread.ResourcesKey, java.lang.@ref.WeakReference
			<android.content.res.Resources>> mActiveResources = new java.util.HashMap<android.app.ActivityThread
			.ResourcesKey, java.lang.@ref.WeakReference<android.content.res.Resources>>();

		private readonly java.util.ArrayList<android.app.ActivityThread.ActivityClientRecord
			> mRelaunchingActivities = new java.util.ArrayList<android.app.ActivityThread.ActivityClientRecord
			>();

		private android.content.res.Configuration mPendingConfiguration = null;

		private readonly java.util.HashMap<string, android.app.ActivityThread.ProviderClientRecord
			> mProviderMap = new java.util.HashMap<string, android.app.ActivityThread.ProviderClientRecord
			>();

		private readonly java.util.HashMap<android.os.IBinder, android.app.ActivityThread
			.ProviderRefCount> mProviderRefCountMap = new java.util.HashMap<android.os.IBinder
			, android.app.ActivityThread.ProviderRefCount>();

		private readonly java.util.HashMap<android.os.IBinder, android.app.ActivityThread
			.ProviderClientRecord> mLocalProviders = new java.util.HashMap<android.os.IBinder
			, android.app.ActivityThread.ProviderClientRecord>();

		private readonly java.util.HashMap<android.app.Activity, java.util.ArrayList<android.app.OnActivityPausedListener
			>> mOnPauseListeners = new java.util.HashMap<android.app.Activity, java.util.ArrayList
			<android.app.OnActivityPausedListener>>();

		internal readonly android.app.ActivityThread.GcIdler mGcIdler;

		private bool mGcIdlerScheduled = false;

		private static android.os.Handler sMainThreadHandler;

		private android.os.Bundle mCoreSettings = null;

		internal sealed class ActivityClientRecord
		{
			internal android.os.IBinder token;

			internal int ident;

			internal android.content.Intent intent;

			internal android.os.Bundle state;

			internal android.app.Activity activity;

			internal android.view.Window window;

			internal android.app.Activity parent;

			internal string embeddedID;

			internal android.app.Activity.NonConfigurationInstances lastNonConfigurationInstances;

			internal bool paused;

			internal bool stopped;

			internal bool hideForNow;

			internal android.content.res.Configuration newConfig;

			internal android.content.res.Configuration createdConfig;

			internal android.app.ActivityThread.ActivityClientRecord nextIdle;

			internal string profileFile;

			internal android.os.ParcelFileDescriptor profileFd;

			internal bool autoStopProfiler;

			internal android.content.pm.ActivityInfo activityInfo;

			internal android.content.res.CompatibilityInfo compatInfo;

			internal android.app.LoadedApk packageInfo;

			internal java.util.List<android.app.ResultInfo> pendingResults;

			internal java.util.List<android.content.Intent> pendingIntents;

			internal bool startsNotResumed;

			internal bool isForward;

			internal int pendingConfigChanges;

			internal bool onlyLocalRequest;

			internal android.view.View mPendingRemoveWindow;

			internal android.view.WindowManager mPendingRemoveWindowManager;

			internal ActivityClientRecord()
			{
				// List of new activities (via ActivityRecord.nextIdle) that should
				// be reported when next we idle.
				// Number of activities that are currently visible on-screen.
				// set of instantiated backup agents, keyed by package name
				// These can be accessed by multiple threads; mPackages is the lock.
				// XXX For now we keep around information about all packages we have
				// seen, not removing entries from this map.
				// NOTE: The activity manager in its process needs to call in to
				// ActivityThread to do things like update resource configurations,
				// which means this lock gets held while the activity manager holds its
				// own lock.  Thus you MUST NEVER call back into the activity manager
				// or anything that depends on it while holding this lock.
				// The lock of mProviderMap protects the following variables.
				// set once in main()
				parent = null;
				embeddedID = null;
				paused = false;
				stopped = false;
				hideForNow = false;
				nextIdle = null;
			}

			public bool isPreHoneycomb()
			{
				if (activity != null)
				{
					return activity.getApplicationInfo().targetSdkVersion < android.os.Build.VERSION_CODES
						.HONEYCOMB;
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				android.content.ComponentName componentName = intent.getComponent();
				return "ActivityRecord{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " token=" + token + " " + (componentName == null ? "no component name"
					 : componentName.toShortString()) + "}";
			}
		}

		[Sharpen.Stub]
		internal sealed class ProviderClientRecord : android.os.IBinderClass.DeathRecipient
		{
			internal readonly string mName;

			internal readonly android.content.IContentProvider mProvider;

			internal readonly android.content.ContentProvider mLocalProvider;

			[Sharpen.Stub]
			internal ProviderClientRecord(ActivityThread _enclosing, string name, android.content.IContentProvider
				 provider, android.content.ContentProvider localProvider)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IBinder.DeathRecipient")]
			public void binderDied()
			{
				throw new System.NotImplementedException();
			}

			private readonly ActivityThread _enclosing;
		}

		[Sharpen.Stub]
		internal sealed class NewIntentData
		{
			internal java.util.List<android.content.Intent> intents;

			internal android.os.IBinder token;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class ReceiverData : android.content.BroadcastReceiver.PendingResult
		{
			[Sharpen.Stub]
			public ReceiverData(android.content.Intent intent, int resultCode, string resultData
				, android.os.Bundle resultExtras, bool ordered, bool sticky, android.os.IBinder 
				token) : base(resultCode, resultData, resultExtras, TYPE_COMPONENT, ordered, sticky
				, token)
			{
				throw new System.NotImplementedException();
			}

			internal android.content.Intent intent;

			internal android.content.pm.ActivityInfo info;

			internal android.content.res.CompatibilityInfo compatInfo;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class CreateBackupAgentData
		{
			internal android.content.pm.ApplicationInfo appInfo;

			internal android.content.res.CompatibilityInfo compatInfo;

			internal int backupMode;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class CreateServiceData
		{
			internal android.os.IBinder token;

			internal android.content.pm.ServiceInfo info;

			internal android.content.res.CompatibilityInfo compatInfo;

			internal android.content.Intent intent;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class BindServiceData
		{
			internal android.os.IBinder token;

			internal android.content.Intent intent;

			internal bool rebind;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class ServiceArgsData
		{
			internal android.os.IBinder token;

			internal bool taskRemoved;

			internal int startId;

			internal int flags;

			internal android.content.Intent args;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class AppBindData
		{
			internal android.app.LoadedApk info;

			internal string processName;

			internal android.content.pm.ApplicationInfo appInfo;

			internal java.util.List<android.content.pm.ProviderInfo> providers;

			internal android.content.ComponentName instrumentationName;

			internal android.os.Bundle instrumentationArgs;

			internal android.app.IInstrumentationWatcher instrumentationWatcher;

			internal int debugMode;

			internal bool restrictedBackupMode;

			internal bool persistent;

			internal android.content.res.Configuration config;

			internal android.content.res.CompatibilityInfo compatInfo;

			internal string initProfileFile;

			internal android.os.ParcelFileDescriptor initProfileFd;

			internal bool initAutoStopProfiler;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class Profiler
		{
			internal string profileFile;

			internal android.os.ParcelFileDescriptor profileFd;

			internal bool autoStopProfiler;

			internal bool profiling;

			internal bool handlingProfiling;

			[Sharpen.Stub]
			public void setProfiler(string file, android.os.ParcelFileDescriptor fd)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void startProfiling()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void stopProfiling()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class DumpComponentInfo
		{
			internal android.os.ParcelFileDescriptor fd;

			internal android.os.IBinder token;

			internal string prefix;

			internal string[] args;
		}

		[Sharpen.Stub]
		internal sealed class ResultData
		{
			internal android.os.IBinder token;

			internal java.util.List<android.app.ResultInfo> results;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class ContextCleanupInfo
		{
			internal android.app.ContextImpl context;

			internal string what;

			internal string who;
		}

		[Sharpen.Stub]
		internal sealed class ProfilerControlData
		{
			internal string path;

			internal android.os.ParcelFileDescriptor fd;
		}

		[Sharpen.Stub]
		internal sealed class DumpHeapData
		{
			internal string path;

			internal android.os.ParcelFileDescriptor fd;
		}

		[Sharpen.Stub]
		internal sealed class UpdateCompatibilityData
		{
			internal string pkg;

			internal android.content.res.CompatibilityInfo info;
		}

		[Sharpen.NativeStub]
		private void dumpGraphicsInfo(java.io.FileDescriptor fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class ApplicationThread : android.app.ApplicationThreadNative
		{
			internal const string HEAP_COLUMN = "%13s %8s %8s %8s %8s %8s %8s";

			internal const string ONE_COUNT_COLUMN = "%21s %8d";

			internal const string TWO_COUNT_COLUMNS = "%21s %8d %21s %8d";

			internal const string TWO_COUNT_COLUMNS_DB = "%21s %8d %21s %8d";

			internal const string DB_INFO_FORMAT = "  %8s %8s %14s %14s  %s";

			internal const int ACTIVITY_THREAD_CHECKIN_VERSION = 1;

			[Sharpen.Stub]
			internal void updatePendingConfiguration(android.content.res.Configuration config
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void schedulePauseActivity(android.os.IBinder token, bool finished
				, bool userLeaving, int configChanges)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleStopActivity(android.os.IBinder token, bool showWindow
				, int configChanges)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleWindowVisibility(android.os.IBinder token, bool showWindow
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleSleeping(android.os.IBinder token, bool sleeping)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleResumeActivity(android.os.IBinder token, bool isForward
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleSendResult(android.os.IBinder token, java.util.List<
				android.app.ResultInfo> results)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleLaunchActivity(android.content.Intent intent, android.os.IBinder
				 token, int ident, android.content.pm.ActivityInfo info, android.content.res.Configuration
				 curConfig, android.content.res.CompatibilityInfo compatInfo, android.os.Bundle 
				state, java.util.List<android.app.ResultInfo> pendingResults, java.util.List<android.content.Intent
				> pendingNewIntents, bool notResumed, bool isForward, string profileName, android.os.ParcelFileDescriptor
				 profileFd, bool autoStopProfiler)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleRelaunchActivity(android.os.IBinder token, java.util.List
				<android.app.ResultInfo> pendingResults, java.util.List<android.content.Intent> 
				pendingNewIntents, int configChanges, bool notResumed, android.content.res.Configuration
				 config)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleNewIntent(java.util.List<android.content.Intent> intents
				, android.os.IBinder token)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleDestroyActivity(android.os.IBinder token, bool finishing
				, int configChanges)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleReceiver(android.content.Intent intent, android.content.pm.ActivityInfo
				 info, android.content.res.CompatibilityInfo compatInfo, int resultCode, string 
				data, android.os.Bundle extras, bool sync)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleCreateBackupAgent(android.content.pm.ApplicationInfo
				 app, android.content.res.CompatibilityInfo compatInfo, int backupMode)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleDestroyBackupAgent(android.content.pm.ApplicationInfo
				 app, android.content.res.CompatibilityInfo compatInfo)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleCreateService(android.os.IBinder token, android.content.pm.ServiceInfo
				 info, android.content.res.CompatibilityInfo compatInfo)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleBindService(android.os.IBinder token, android.content.Intent
				 intent, bool rebind)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleUnbindService(android.os.IBinder token, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleServiceArgs(android.os.IBinder token, bool taskRemoved
				, int startId, int flags, android.content.Intent args)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleStopService(android.os.IBinder token)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void bindApplication(string processName, android.content.pm.ApplicationInfo
				 appInfo, java.util.List<android.content.pm.ProviderInfo> providers, android.content.ComponentName
				 instrumentationName, string profileFile, android.os.ParcelFileDescriptor profileFd
				, bool autoStopProfiler, android.os.Bundle instrumentationArgs, android.app.IInstrumentationWatcher
				 instrumentationWatcher, int debugMode, bool isRestrictedBackupMode, bool persistent
				, android.content.res.Configuration config, android.content.res.CompatibilityInfo
				 compatInfo, java.util.Map<string, android.os.IBinder> services, android.os.Bundle
				 coreSettings)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleExit()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleSuicide()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void requestThumbnail(android.os.IBinder token)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleConfigurationChanged(android.content.res.Configuration
				 config)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void updateTimeZone()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void clearDnsCache()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void setHttpProxy(string host, string port, string exclList)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void processInBackground()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void dumpService(java.io.FileDescriptor fd, android.os.IBinder servicetoken
				, string[] args)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleRegisteredReceiver(android.content.IIntentReceiver receiver
				, android.content.Intent intent, int resultCode, string dataStr, android.os.Bundle
				 extras, bool ordered, bool sticky)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleLowMemory()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleActivityConfigurationChanged(android.os.IBinder token
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void profilerControl(bool start, string path, android.os.ParcelFileDescriptor
				 fd, int profileType)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void dumpHeap(bool managed, string path, android.os.ParcelFileDescriptor
				 fd)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void setSchedulingGroup(int group)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void getMemoryInfo(android.os.Debug.MemoryInfo outInfo)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void dispatchPackageBroadcast(int cmd, string[] packages)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleCrash(string msg)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void dumpActivity(java.io.FileDescriptor fd, android.os.IBinder activitytoken
				, string prefix, string[] args)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override android.os.Debug.MemoryInfo dumpMemInfo(java.io.FileDescriptor fd
				, bool checkin, bool all, string[] args)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal android.os.Debug.MemoryInfo dumpMemInfo(java.io.PrintWriter pw, bool checkin
				, bool all, string[] args)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void dumpGfxInfo(java.io.FileDescriptor fd, string[] args)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void printRow(java.io.PrintWriter pw, string format, params object[] objs
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void setCoreSettings(android.os.Bundle coreSettings)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void updatePackageCompatibilityInfo(string pkg, android.content.res.CompatibilityInfo
				 info)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
			public override void scheduleTrimMemory(int level)
			{
				throw new System.NotImplementedException();
			}

			internal ApplicationThread(ActivityThread _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityThread _enclosing;
		}

		[Sharpen.Stub]
		private class H : android.os.Handler
		{
			public const int LAUNCH_ACTIVITY = 100;

			public const int PAUSE_ACTIVITY = 101;

			public const int PAUSE_ACTIVITY_FINISHING = 102;

			public const int STOP_ACTIVITY_SHOW = 103;

			public const int STOP_ACTIVITY_HIDE = 104;

			public const int SHOW_WINDOW = 105;

			public const int HIDE_WINDOW = 106;

			public const int RESUME_ACTIVITY = 107;

			public const int SEND_RESULT = 108;

			public const int DESTROY_ACTIVITY = 109;

			public const int BIND_APPLICATION = 110;

			public const int EXIT_APPLICATION = 111;

			public const int NEW_INTENT = 112;

			public const int RECEIVER = 113;

			public const int CREATE_SERVICE = 114;

			public const int SERVICE_ARGS = 115;

			public const int STOP_SERVICE = 116;

			public const int REQUEST_THUMBNAIL = 117;

			public const int CONFIGURATION_CHANGED = 118;

			public const int CLEAN_UP_CONTEXT = 119;

			public const int GC_WHEN_IDLE = 120;

			public const int BIND_SERVICE = 121;

			public const int UNBIND_SERVICE = 122;

			public const int DUMP_SERVICE = 123;

			public const int LOW_MEMORY = 124;

			public const int ACTIVITY_CONFIGURATION_CHANGED = 125;

			public const int RELAUNCH_ACTIVITY = 126;

			public const int PROFILER_CONTROL = 127;

			public const int CREATE_BACKUP_AGENT = 128;

			public const int DESTROY_BACKUP_AGENT = 129;

			public const int SUICIDE = 130;

			public const int REMOVE_PROVIDER = 131;

			public const int ENABLE_JIT = 132;

			public const int DISPATCH_PACKAGE_BROADCAST = 133;

			public const int SCHEDULE_CRASH = 134;

			public const int DUMP_HEAP = 135;

			public const int DUMP_ACTIVITY = 136;

			public const int SLEEPING = 137;

			public const int SET_CORE_SETTINGS = 138;

			public const int UPDATE_PACKAGE_COMPATIBILITY_INFO = 139;

			public const int TRIM_MEMORY = 140;

			[Sharpen.Stub]
			internal virtual string codeToString(int code)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void maybeSnapshot()
			{
				throw new System.NotImplementedException();
			}

			internal H(ActivityThread _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityThread _enclosing;
		}

		[Sharpen.Stub]
		private class Idler : android.os.MessageQueue.IdleHandler
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.MessageQueue.IdleHandler")]
			public virtual bool queueIdle()
			{
				throw new System.NotImplementedException();
			}

			internal Idler(ActivityThread _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityThread _enclosing;
		}

		[Sharpen.Stub]
		internal sealed class GcIdler : android.os.MessageQueue.IdleHandler
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.MessageQueue.IdleHandler")]
			public bool queueIdle()
			{
				throw new System.NotImplementedException();
			}

			internal GcIdler(ActivityThread _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityThread _enclosing;
		}

		private class ResourcesKey
		{
			internal readonly string mResDir;

			internal readonly float mScale;

			internal readonly int mHash;

			internal ResourcesKey(string resDir, float scale)
			{
				// Formatting for checkin service - update version if row format changes
				// we use token to identify this activity without having to send the
				// activity itself back to the activity manager. (matters more with ipc)
				// Setup the service cache in the ServiceManager
				// a non-standard API to get this to libcore
				// This function exists to make sure all receiver dispatching is
				// correctly ordered, since these are one-way calls and the binder driver
				// applies transaction ordering per object for such calls.
				// Note: do this immediately, since going into the foreground
				// should happen regardless of what pending work we have to do
				// and the activity manager will wait for us to report back that
				// we are done before sending us to the background.
				// For checkin, we print one long comma-separated list of values
				// NOTE: if you change anything significant below, also consider changing
				// ACTIVITY_THREAD_CHECKIN_VERSION.
				// Header
				// Heap info - max
				// Heap info - allocated
				// Heap info - free
				// Heap info - proportional set size
				// Heap info - shared
				// Heap info - private
				// Object counts
				// SQL
				// otherwise, show human-readable format
				// SQLite mem info
				// Asset details.
				// convert the *private* ActivityThread.PackageInfo to *public* known
				// android.content.pm.PackageInfo
				// Ignore
				mResDir = resDir;
				mScale = scale;
				mHash = mResDir.GetHashCode() << 2 + (int)(mScale * 2);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return mHash;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object obj)
			{
				if (!(obj is android.app.ActivityThread.ResourcesKey))
				{
					return false;
				}
				android.app.ActivityThread.ResourcesKey peer = (android.app.ActivityThread.ResourcesKey
					)obj;
				return mResDir.Equals(peer.mResDir) && mScale == peer.mScale;
			}
		}

		public static android.app.ActivityThread currentActivityThread()
		{
			return sThreadLocal.get();
		}

		public static string currentPackageName()
		{
			android.app.ActivityThread am = currentActivityThread();
			return (am != null && am.mBoundApplication != null) ? am.mBoundApplication.processName
				 : null;
		}

		public static android.app.Application currentApplication()
		{
			android.app.ActivityThread am = currentActivityThread();
			return am != null ? am.mInitialApplication : null;
		}

		public static android.content.pm.IPackageManager getPackageManager()
		{
			if (sPackageManager != null)
			{
				//Slog.v("PackageManager", "returning cur default = " + sPackageManager);
				return sPackageManager;
			}
			android.os.IBinder b = android.os.ServiceManager.getService("package");
			//Slog.v("PackageManager", "default service binder = " + b);
			sPackageManager = android.content.pm.IPackageManagerClass.Stub.asInterface(b);
			//Slog.v("PackageManager", "default service = " + sPackageManager);
			return sPackageManager;
		}

		internal android.util.DisplayMetrics getDisplayMetricsLocked(android.content.res.CompatibilityInfo
			 ci, bool forceUpdate)
		{
			android.util.DisplayMetrics dm = mDisplayMetrics.get(ci);
			if (dm != null && !forceUpdate)
			{
				return dm;
			}
			if (dm == null)
			{
				dm = new android.util.DisplayMetrics();
				mDisplayMetrics.put(ci, dm);
			}
			android.view.Display d = android.view.WindowManagerImpl.getDefault(ci).getDefaultDisplay
				();
			d.getMetrics(dm);
			//Slog.i("foo", "New metrics: w=" + metrics.widthPixels + " h="
			//        + metrics.heightPixels + " den=" + metrics.density
			//        + " xdpi=" + metrics.xdpi + " ydpi=" + metrics.ydpi);
			return dm;
		}

		internal static android.content.res.Configuration applyConfigCompat(android.content.res.Configuration
			 config, android.content.res.CompatibilityInfo compat)
		{
			if (config == null)
			{
				return null;
			}
			if (compat != null && !compat.supportsScreen())
			{
				config = new android.content.res.Configuration(config);
				compat.applyToConfiguration(config);
			}
			return config;
		}

		private android.content.res.Configuration mMainThreadConfig = new android.content.res.Configuration
			();

		internal android.content.res.Configuration applyConfigCompatMainThread(android.content.res.Configuration
			 config, android.content.res.CompatibilityInfo compat)
		{
			if (config == null)
			{
				return null;
			}
			if (compat != null && !compat.supportsScreen())
			{
				mMainThreadConfig.setTo(config);
				config = mMainThreadConfig;
				compat.applyToConfiguration(config);
			}
			return config;
		}

		/// <summary>Creates the top level Resources for applications with the given compatibility info.
		/// 	</summary>
		/// <remarks>Creates the top level Resources for applications with the given compatibility info.
		/// 	</remarks>
		/// <param name="resDir">the resource directory.</param>
		/// <param name="compInfo">
		/// the compability info. It will use the default compatibility info when it's
		/// null.
		/// </param>
		internal android.content.res.Resources getTopLevelResources(string resDir, android.content.res.CompatibilityInfo
			 compInfo)
		{
			android.app.ActivityThread.ResourcesKey key = new android.app.ActivityThread.ResourcesKey
				(resDir, compInfo.applicationScale);
			android.content.res.Resources r;
			lock (mPackages)
			{
				// Resources is app scale dependent.
				if (false)
				{
					android.util.Slog.w(TAG, "getTopLevelResources: " + resDir + " / " + compInfo.applicationScale
						);
				}
				java.lang.@ref.WeakReference<android.content.res.Resources> wr = mActiveResources
					.get(key);
				r = wr != null ? wr.get() : null;
				//if (r != null) Slog.i(TAG, "isUpToDate " + resDir + ": " + r.getAssets().isUpToDate());
				if (r != null && r.getAssets().isUpToDate())
				{
					if (false)
					{
						android.util.Slog.w(TAG, "Returning cached resources " + r + " " + resDir + ": appScale="
							 + r.getCompatibilityInfo().applicationScale);
					}
					return r;
				}
			}
			//if (r != null) {
			//    Slog.w(TAG, "Throwing away out-of-date resources!!!! "
			//            + r + " " + resDir);
			//}
			android.content.res.AssetManager assets = new android.content.res.AssetManager();
			if (assets.addAssetPath(resDir) == 0)
			{
				return null;
			}
			//Slog.i(TAG, "Resource: key=" + key + ", display metrics=" + metrics);
			android.util.DisplayMetrics metrics = getDisplayMetricsLocked(null, false);
			r = new android.content.res.Resources(assets, metrics, getConfiguration(), compInfo
				);
			if (false)
			{
				android.util.Slog.i(TAG, "Created app resources " + resDir + " " + r + ": " + r.getConfiguration
					() + " appScale=" + r.getCompatibilityInfo().applicationScale);
			}
			lock (mPackages)
			{
				java.lang.@ref.WeakReference<android.content.res.Resources> wr = mActiveResources
					.get(key);
				android.content.res.Resources existing = wr != null ? wr.get() : null;
				if (existing != null && existing.getAssets().isUpToDate())
				{
					// Someone else already created the resources while we were
					// unlocked; go ahead and use theirs.
					r.getAssets().close();
					return existing;
				}
				// XXX need to remove entries when weak references go away
				mActiveResources.put(key, new java.lang.@ref.WeakReference<android.content.res.Resources
					>(r));
				return r;
			}
		}

		/// <summary>Creates the top level resources for the given package.</summary>
		/// <remarks>Creates the top level resources for the given package.</remarks>
		internal android.content.res.Resources getTopLevelResources(string resDir, android.app.LoadedApk
			 pkgInfo)
		{
			return getTopLevelResources(resDir, pkgInfo.mCompatibilityInfo.get());
		}

		internal android.os.Handler getHandler()
		{
			return mH;
		}

		internal android.app.LoadedApk getPackageInfo(string packageName, android.content.res.CompatibilityInfo
			 compatInfo, int flags)
		{
			lock (mPackages)
			{
				java.lang.@ref.WeakReference<android.app.LoadedApk> @ref;
				if ((flags & android.content.Context.CONTEXT_INCLUDE_CODE) != 0)
				{
					@ref = mPackages.get(packageName);
				}
				else
				{
					@ref = mResourcePackages.get(packageName);
				}
				android.app.LoadedApk packageInfo = @ref != null ? @ref.get() : null;
				//Slog.i(TAG, "getPackageInfo " + packageName + ": " + packageInfo);
				//if (packageInfo != null) Slog.i(TAG, "isUptoDate " + packageInfo.mResDir
				//        + ": " + packageInfo.mResources.getAssets().isUpToDate());
				if (packageInfo != null && (packageInfo.mResources == null || packageInfo.mResources
					.getAssets().isUpToDate()))
				{
					if (packageInfo.isSecurityViolation() && (flags & android.content.Context.CONTEXT_IGNORE_SECURITY
						) == 0)
					{
						throw new System.Security.SecurityException("Requesting code from " + packageName
							 + " to be run in process " + mBoundApplication.processName + "/" + mBoundApplication
							.appInfo.uid);
					}
					return packageInfo;
				}
			}
			android.content.pm.ApplicationInfo ai = null;
			try
			{
				ai = getPackageManager().getApplicationInfo(packageName, android.content.pm.PackageManager
					.GET_SHARED_LIBRARY_FILES);
			}
			catch (android.os.RemoteException)
			{
			}
			// Ignore
			if (ai != null)
			{
				return getPackageInfo(ai, compatInfo, flags);
			}
			return null;
		}

		internal android.app.LoadedApk getPackageInfo(android.content.pm.ApplicationInfo 
			ai, android.content.res.CompatibilityInfo compatInfo, int flags)
		{
			bool includeCode = (flags & android.content.Context.CONTEXT_INCLUDE_CODE) != 0;
			bool securityViolation = includeCode && ai.uid != 0 && ai.uid != android.os.Process
				.SYSTEM_UID && (mBoundApplication != null ? ai.uid != mBoundApplication.appInfo.
				uid : true);
			if ((flags & (android.content.Context.CONTEXT_INCLUDE_CODE | android.content.Context
				.CONTEXT_IGNORE_SECURITY)) == android.content.Context.CONTEXT_INCLUDE_CODE)
			{
				if (securityViolation)
				{
					string msg = "Requesting code from " + ai.packageName + " (with uid " + ai.uid + 
						")";
					if (mBoundApplication != null)
					{
						msg = msg + " to be run in process " + mBoundApplication.processName + " (with uid "
							 + mBoundApplication.appInfo.uid + ")";
					}
					throw new System.Security.SecurityException(msg);
				}
			}
			return getPackageInfo(ai, compatInfo, null, securityViolation, includeCode);
		}

		internal android.app.LoadedApk getPackageInfoNoCheck(android.content.pm.ApplicationInfo
			 ai, android.content.res.CompatibilityInfo compatInfo)
		{
			return getPackageInfo(ai, compatInfo, null, false, true);
		}

		public android.app.LoadedApk peekPackageInfo(string packageName, bool includeCode
			)
		{
			lock (mPackages)
			{
				java.lang.@ref.WeakReference<android.app.LoadedApk> @ref;
				if (includeCode)
				{
					@ref = mPackages.get(packageName);
				}
				else
				{
					@ref = mResourcePackages.get(packageName);
				}
				return @ref != null ? @ref.get() : null;
			}
		}

		internal android.app.LoadedApk getPackageInfo(android.content.pm.ApplicationInfo 
			aInfo, android.content.res.CompatibilityInfo compatInfo, java.lang.ClassLoader baseLoader
			, bool securityViolation, bool includeCode)
		{
			lock (mPackages)
			{
				java.lang.@ref.WeakReference<android.app.LoadedApk> @ref;
				if (includeCode)
				{
					@ref = mPackages.get(aInfo.packageName);
				}
				else
				{
					@ref = mResourcePackages.get(aInfo.packageName);
				}
				android.app.LoadedApk packageInfo = @ref != null ? @ref.get() : null;
				if (packageInfo == null || (packageInfo.mResources != null && !packageInfo.mResources
					.getAssets().isUpToDate()))
				{
					packageInfo = new android.app.LoadedApk(this, aInfo, compatInfo, this, baseLoader
						, securityViolation, includeCode && (aInfo.flags & android.content.pm.ApplicationInfo
						.FLAG_HAS_CODE) != 0);
					if (includeCode)
					{
						mPackages.put(aInfo.packageName, new java.lang.@ref.WeakReference<android.app.LoadedApk
							>(packageInfo));
					}
					else
					{
						mResourcePackages.put(aInfo.packageName, new java.lang.@ref.WeakReference<android.app.LoadedApk
							>(packageInfo));
					}
				}
				return packageInfo;
			}
		}

		internal android.app.ActivityThread.ApplicationThread getApplicationThread()
		{
			return mAppThread;
		}

		public android.app.Instrumentation getInstrumentation()
		{
			return mInstrumentation;
		}

		public android.content.res.Configuration getConfiguration()
		{
			return mResConfiguration;
		}

		public bool isProfiling()
		{
			return mProfiler != null && mProfiler.profileFile != null && mProfiler.profileFd 
				== null;
		}

		public string getProfileFilePath()
		{
			return mProfiler.profileFile;
		}

		public android.os.Looper getLooper()
		{
			return mLooper;
		}

		public android.app.Application getApplication()
		{
			return mInitialApplication;
		}

		public string getProcessName()
		{
			return mBoundApplication.processName;
		}

		internal android.app.ContextImpl getSystemContext()
		{
			lock (this)
			{
				if (mSystemContext == null)
				{
					android.app.ContextImpl context = android.app.ContextImpl.createSystemContext(this
						);
					android.app.LoadedApk info = new android.app.LoadedApk(this, "android", context, 
						null, android.content.res.CompatibilityInfo.DEFAULT_COMPATIBILITY_INFO);
					context.init(info, null, this);
					context.getResources().updateConfiguration(getConfiguration(), getDisplayMetricsLocked
						(android.content.res.CompatibilityInfo.DEFAULT_COMPATIBILITY_INFO, false));
					mSystemContext = context;
				}
			}
			//Slog.i(TAG, "Created system resources " + context.getResources()
			//        + ": " + context.getResources().getConfiguration());
			return mSystemContext;
		}

		public void installSystemApplicationInfo(android.content.pm.ApplicationInfo info)
		{
			lock (this)
			{
				android.app.ContextImpl context = getSystemContext();
				context.init(new android.app.LoadedApk(this, "android", context, info, android.content.res.CompatibilityInfo
					.DEFAULT_COMPATIBILITY_INFO), null, this);
				// give ourselves a default profiler
				mProfiler = new android.app.ActivityThread.Profiler();
			}
		}

		[Sharpen.Stub]
		internal void ensureJitEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void scheduleGcIdler()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void unscheduleGcIdler()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void doGcIfNeeded()
		{
			throw new System.NotImplementedException();
		}

		//Slog.i(TAG, "**** WE MIGHT WANT TO GC: then=" + Binder.getLastGcTime()
		//        + "m now=" + now);
		//Slog.i(TAG, "**** WE DO, WE DO WANT TO GC!");
		public void registerOnActivityPausedListener(android.app.Activity activity, android.app.OnActivityPausedListener
			 listener)
		{
			lock (mOnPauseListeners)
			{
				java.util.ArrayList<android.app.OnActivityPausedListener> list = mOnPauseListeners
					.get(activity);
				if (list == null)
				{
					list = new java.util.ArrayList<android.app.OnActivityPausedListener>();
					mOnPauseListeners.put(activity, list);
				}
				list.add(listener);
			}
		}

		public void unregisterOnActivityPausedListener(android.app.Activity activity, android.app.OnActivityPausedListener
			 listener)
		{
			lock (mOnPauseListeners)
			{
				java.util.ArrayList<android.app.OnActivityPausedListener> list = mOnPauseListeners
					.get(activity);
				if (list != null)
				{
					list.remove(listener);
				}
			}
		}

		public android.content.pm.ActivityInfo resolveActivityInfo(android.content.Intent
			 intent)
		{
			android.content.pm.ActivityInfo aInfo = intent.resolveActivityInfo(mInitialApplication
				.getPackageManager(), android.content.pm.PackageManager.GET_SHARED_LIBRARY_FILES
				);
			if (aInfo == null)
			{
				// Throw an exception.
				android.app.Instrumentation.checkStartActivityResult(android.app.IActivityManagerClass.START_CLASS_NOT_FOUND
					, intent);
			}
			return aInfo;
		}

		internal android.app.Activity startActivityNow(android.app.Activity parent, string
			 id, android.content.Intent intent, android.content.pm.ActivityInfo activityInfo
			, android.os.IBinder token, android.os.Bundle state, android.app.Activity.NonConfigurationInstances
			 lastNonConfigurationInstances)
		{
			android.app.ActivityThread.ActivityClientRecord r = new android.app.ActivityThread
				.ActivityClientRecord();
			r.token = token;
			r.ident = 0;
			r.intent = intent;
			r.state = state;
			r.parent = parent;
			r.embeddedID = id;
			r.activityInfo = activityInfo;
			r.lastNonConfigurationInstances = lastNonConfigurationInstances;
			return performLaunchActivity(r, null);
		}

		public android.app.Activity getActivity(android.os.IBinder token)
		{
			return mActivities.get(token).activity;
		}

		public void sendActivityResult(android.os.IBinder token, string id, int requestCode
			, int resultCode, android.content.Intent data)
		{
			java.util.ArrayList<android.app.ResultInfo> list = new java.util.ArrayList<android.app.ResultInfo
				>();
			list.add(new android.app.ResultInfo(id, requestCode, resultCode, data));
			mAppThread.scheduleSendResult(token, list);
		}

		// if the thread hasn't started yet, we don't have the handler, so just
		// save the messages until we're ready.
		private void queueOrSendMessage(int what, object obj)
		{
			queueOrSendMessage(what, obj, 0, 0);
		}

		private void queueOrSendMessage(int what, object obj, int arg1)
		{
			queueOrSendMessage(what, obj, arg1, 0);
		}

		private void queueOrSendMessage(int what, object obj, int arg1, int arg2)
		{
			lock (this)
			{
				android.os.Message msg = android.os.Message.obtain();
				msg.what = what;
				msg.obj = obj;
				msg.arg1 = arg1;
				msg.arg2 = arg2;
				mH.sendMessage(msg);
			}
		}

		internal void scheduleContextCleanup(android.app.ContextImpl context, string who, 
			string what)
		{
			android.app.ActivityThread.ContextCleanupInfo cci = new android.app.ActivityThread
				.ContextCleanupInfo();
			cci.context = context;
			cci.who = who;
			cci.what = what;
			queueOrSendMessage(android.app.ActivityThread.H.CLEAN_UP_CONTEXT, cci);
		}

		internal android.app.Activity performLaunchActivity(android.app.ActivityThread.ActivityClientRecord
			 r, android.content.Intent customIntent)
		{
			// System.out.println("##### [" + System.currentTimeMillis() + "] ActivityThread.performLaunchActivity(" + r + ")");
			android.content.pm.ActivityInfo aInfo = r.activityInfo;
			if (r.packageInfo == null)
			{
				r.packageInfo = getPackageInfo(aInfo.applicationInfo, r.compatInfo, android.content.Context
					.CONTEXT_INCLUDE_CODE);
			}
			android.content.ComponentName component = r.intent.getComponent();
			if (component == null)
			{
				component = r.intent.resolveActivity(mInitialApplication.getPackageManager());
				r.intent.setComponent(component);
			}
			if (r.activityInfo.targetActivity != null)
			{
				component = new android.content.ComponentName(r.activityInfo.packageName, r.activityInfo
					.targetActivity);
			}
			android.app.Activity activity = null;
			try
			{
				java.lang.ClassLoader cl = r.packageInfo.getClassLoader();
				activity = mInstrumentation.newActivity(cl, component.getClassName(), r.intent);
				android.os.StrictMode.incrementExpectedActivityCount(activity.GetType());
				r.intent.setExtrasClassLoader(cl);
				if (r.state != null)
				{
					r.state.setClassLoader(cl);
				}
			}
			catch (System.Exception e)
			{
				if (!mInstrumentation.onException(activity, e))
				{
					throw new java.lang.RuntimeException("Unable to instantiate activity " + component
						 + ": " + e.ToString(), e);
				}
			}
			try
			{
				android.app.Application app = r.packageInfo.makeApplication(false, mInstrumentation
					);
				if (activity != null)
				{
					android.app.ContextImpl appContext = new android.app.ContextImpl();
					appContext.init(r.packageInfo, r.token, this);
					appContext.setOuterContext(activity);
					java.lang.CharSequence title = r.activityInfo.loadLabel(appContext.getPackageManager
						());
					android.content.res.Configuration config = new android.content.res.Configuration(
						mCompatConfiguration);
					activity.attach(appContext, this, getInstrumentation(), r.token, r.ident, app, r.
						intent, r.activityInfo, title, r.parent, r.embeddedID, r.lastNonConfigurationInstances
						, config);
					if (customIntent != null)
					{
						activity.mIntent = customIntent;
					}
					r.lastNonConfigurationInstances = null;
					activity.mStartedActivity = false;
					int theme = r.activityInfo.getThemeResource();
					if (theme != 0)
					{
						activity.setTheme(theme);
					}
					activity.mCalled = false;
					mInstrumentation.callActivityOnCreate(activity, r.state);
					if (!activity.mCalled)
					{
						throw new android.app.SuperNotCalledException("Activity " + r.intent.getComponent
							().toShortString() + " did not call through to super.onCreate()");
					}
					r.activity = activity;
					r.stopped = true;
					if (!r.activity.mFinished)
					{
						activity.performStart();
						r.stopped = false;
					}
					if (!r.activity.mFinished)
					{
						if (r.state != null)
						{
							mInstrumentation.callActivityOnRestoreInstanceState(activity, r.state);
						}
					}
					if (!r.activity.mFinished)
					{
						activity.mCalled = false;
						mInstrumentation.callActivityOnPostCreate(activity, r.state);
						if (!activity.mCalled)
						{
							throw new android.app.SuperNotCalledException("Activity " + r.intent.getComponent
								().toShortString() + " did not call through to super.onPostCreate()");
						}
					}
				}
				r.paused = true;
				mActivities.put(r.token, r);
			}
			catch (android.app.SuperNotCalledException e)
			{
				throw;
			}
			catch (System.Exception e)
			{
				if (!mInstrumentation.onException(activity, e))
				{
					throw new java.lang.RuntimeException("Unable to start activity " + component + ": "
						 + e.ToString(), e);
				}
			}
			return activity;
		}

		internal void handleLaunchActivity(android.app.ActivityThread.ActivityClientRecord
			 r, android.content.Intent customIntent)
		{
			// If we are getting ready to gc after going to the background, well
			// we are back active so skip it.
			unscheduleGcIdler();
			if (r.profileFd != null)
			{
				mProfiler.setProfiler(r.profileFile, r.profileFd);
				mProfiler.startProfiling();
				mProfiler.autoStopProfiler = r.autoStopProfiler;
			}
			// Make sure we are running with the most recent config.
			handleConfigurationChanged(null, null);
			android.app.Activity a = performLaunchActivity(r, customIntent);
			if (a != null)
			{
				r.createdConfig = new android.content.res.Configuration(mConfiguration);
				android.os.Bundle oldState = r.state;
				handleResumeActivity(r.token, false, r.isForward);
				if (!r.activity.mFinished && r.startsNotResumed)
				{
					// The activity manager actually wants this one to start out
					// paused, because it needs to be visible but isn't in the
					// foreground.  We accomplish this by going through the
					// normal startup (because activities expect to go through
					// onResume() the first time they run, before their window
					// is displayed), and then pausing it.  However, in this case
					// we do -not- need to do the full pause cycle (of freezing
					// and such) because the activity manager assumes it can just
					// retain the current state it has.
					try
					{
						r.activity.mCalled = false;
						mInstrumentation.callActivityOnPause(r.activity);
						// We need to keep around the original state, in case
						// we need to be created again.
						r.state = oldState;
						if (!r.activity.mCalled)
						{
							throw new android.app.SuperNotCalledException("Activity " + r.intent.getComponent
								().toShortString() + " did not call through to super.onPause()");
						}
					}
					catch (android.app.SuperNotCalledException e)
					{
						throw;
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to pause activity " + r.intent.getComponent
								().toShortString() + ": " + e.ToString(), e);
						}
					}
					r.paused = true;
				}
			}
			else
			{
				// If there was an error, for any reason, tell the activity
				// manager to stop us.
				try
				{
					android.app.ActivityManagerNative.getDefault().finishActivity(r.token, android.app.Activity
						.RESULT_CANCELED, null);
				}
				catch (android.os.RemoteException)
				{
				}
			}
		}

		// Ignore
		internal void deliverNewIntents(android.app.ActivityThread.ActivityClientRecord r
			, java.util.List<android.content.Intent> intents)
		{
			int N = intents.size();
			{
				for (int i = 0; i < N; i++)
				{
					android.content.Intent intent = intents.get(i);
					intent.setExtrasClassLoader(r.activity.getClassLoader());
					r.activity.mFragments.noteStateNotSaved();
					mInstrumentation.callActivityOnNewIntent(r.activity, intent);
				}
			}
		}

		public void performNewIntents(android.os.IBinder token, java.util.List<android.content.Intent
			> intents)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			if (r != null)
			{
				bool resumed = !r.paused;
				if (resumed)
				{
					r.activity.mTemporaryPause = true;
					mInstrumentation.callActivityOnPause(r.activity);
				}
				deliverNewIntents(r, intents);
				if (resumed)
				{
					r.activity.performResume();
					r.activity.mTemporaryPause = false;
				}
			}
		}

		internal void handleNewIntent(android.app.ActivityThread.NewIntentData data)
		{
			performNewIntents(data.token, data.intents);
		}

		private static readonly java.lang.ThreadLocal<android.content.Intent> sCurrentBroadcastIntent
			 = new java.lang.ThreadLocal<android.content.Intent>();

		/// <summary>
		/// Return the Intent that's currently being handled by a
		/// BroadcastReceiver on this thread, or null if none.
		/// </summary>
		/// <remarks>
		/// Return the Intent that's currently being handled by a
		/// BroadcastReceiver on this thread, or null if none.
		/// </remarks>
		/// <hide></hide>
		public static android.content.Intent getIntentBeingBroadcast()
		{
			return sCurrentBroadcastIntent.get();
		}

		[Sharpen.Stub]
		internal void handleReceiver(android.app.ActivityThread.ReceiverData data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void handleCreateBackupAgent(android.app.ActivityThread.CreateBackupAgentData
			 data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void handleDestroyBackupAgent(android.app.ActivityThread.CreateBackupAgentData
			 data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void handleCreateService(android.app.ActivityThread.CreateServiceData data
			)
		{
			throw new System.NotImplementedException();
		}

		// If we are getting ready to gc after going to the background, well
		// we are back active so skip it.
		// Instantiate a BackupAgent and tell it that it's alive
		// no longer idle; we have backup work to do
		// instantiate the BackupAgent class named in the manifest
		// full backup operation but no app-supplied agent?  use the default implementation
		// set up the agent's context
		// If this is during restore, fail silently; otherwise go
		// ahead and let the user see the crash.
		// falling through with 'binder' still null
		// tell the OS that we're live now
		// nothing to do.
		// Tear down a BackupAgent
		// If we are getting ready to gc after going to the background, well
		// we are back active so skip it.
		// nothing to do.
		internal void handleBindService(android.app.ActivityThread.BindServiceData data)
		{
			android.app.Service s = mServices.get(data.token);
			if (s != null)
			{
				try
				{
					data.intent.setExtrasClassLoader(s.getClassLoader());
					try
					{
						if (!data.rebind)
						{
							android.os.IBinder binder = s.onBind(data.intent);
							android.app.ActivityManagerNative.getDefault().publishService(data.token, data.intent
								, binder);
						}
						else
						{
							s.onRebind(data.intent);
							android.app.ActivityManagerNative.getDefault().serviceDoneExecuting(data.token, 0
								, 0, 0);
						}
						ensureJitEnabled();
					}
					catch (android.os.RemoteException)
					{
					}
				}
				catch (System.Exception e)
				{
					if (!mInstrumentation.onException(s, e))
					{
						throw new java.lang.RuntimeException("Unable to bind to service " + s + " with " 
							+ data.intent + ": " + e.ToString(), e);
					}
				}
			}
		}

		internal void handleUnbindService(android.app.ActivityThread.BindServiceData data
			)
		{
			android.app.Service s = mServices.get(data.token);
			if (s != null)
			{
				try
				{
					data.intent.setExtrasClassLoader(s.getClassLoader());
					bool doRebind = s.onUnbind(data.intent);
					try
					{
						if (doRebind)
						{
							android.app.ActivityManagerNative.getDefault().unbindFinished(data.token, data.intent
								, doRebind);
						}
						else
						{
							android.app.ActivityManagerNative.getDefault().serviceDoneExecuting(data.token, 0
								, 0, 0);
						}
					}
					catch (android.os.RemoteException)
					{
					}
				}
				catch (System.Exception e)
				{
					if (!mInstrumentation.onException(s, e))
					{
						throw new java.lang.RuntimeException("Unable to unbind to service " + s + " with "
							 + data.intent + ": " + e.ToString(), e);
					}
				}
			}
		}

		internal void handleDumpService(android.app.ActivityThread.DumpComponentInfo info
			)
		{
			android.app.Service s = mServices.get(info.token);
			if (s != null)
			{
				java.io.PrintWriter pw = new java.io.PrintWriter(new java.io.FileOutputStream(info
					.fd.getFileDescriptor()));
				s.dump(info.fd.getFileDescriptor(), pw, info.args);
				pw.flush();
				try
				{
					info.fd.close();
				}
				catch (System.IO.IOException)
				{
				}
			}
		}

		internal void handleDumpActivity(android.app.ActivityThread.DumpComponentInfo info
			)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(info.token);
			if (r != null && r.activity != null)
			{
				java.io.PrintWriter pw = new java.io.PrintWriter(new java.io.FileOutputStream(info
					.fd.getFileDescriptor()));
				r.activity.dump(info.prefix, info.fd.getFileDescriptor(), pw, info.args);
				pw.flush();
				try
				{
					info.fd.close();
				}
				catch (System.IO.IOException)
				{
				}
			}
		}

		internal void handleServiceArgs(android.app.ActivityThread.ServiceArgsData data)
		{
			android.app.Service s = mServices.get(data.token);
			if (s != null)
			{
				try
				{
					if (data.args != null)
					{
						data.args.setExtrasClassLoader(s.getClassLoader());
					}
					int res;
					if (!data.taskRemoved)
					{
						res = s.onStartCommand(data.args, data.flags, data.startId);
					}
					else
					{
						s.onTaskRemoved(data.args);
						res = android.app.Service.START_TASK_REMOVED_COMPLETE;
					}
					android.app.QueuedWork.waitToFinish();
					try
					{
						android.app.ActivityManagerNative.getDefault().serviceDoneExecuting(data.token, 1
							, data.startId, res);
					}
					catch (android.os.RemoteException)
					{
					}
					// nothing to do.
					ensureJitEnabled();
				}
				catch (System.Exception e)
				{
					if (!mInstrumentation.onException(s, e))
					{
						throw new java.lang.RuntimeException("Unable to start service " + s + " with " + 
							data.args + ": " + e.ToString(), e);
					}
				}
			}
		}

		private void handleStopService(android.os.IBinder token)
		{
			android.app.Service s = mServices.remove(token);
			if (s != null)
			{
				try
				{
					s.onDestroy();
					android.content.Context context = s.getBaseContext();
					if (context is android.app.ContextImpl)
					{
						string who = s.getClassName();
						((android.app.ContextImpl)context).scheduleFinalCleanup(who, "Service");
					}
					android.app.QueuedWork.waitToFinish();
					try
					{
						android.app.ActivityManagerNative.getDefault().serviceDoneExecuting(token, 0, 0, 
							0);
					}
					catch (android.os.RemoteException)
					{
					}
				}
				catch (System.Exception e)
				{
					// nothing to do.
					if (!mInstrumentation.onException(s, e))
					{
						throw new java.lang.RuntimeException("Unable to stop service " + s + ": " + e.ToString
							(), e);
					}
				}
			}
		}

		//Slog.i(TAG, "Running services: " + mServices);
		internal android.app.ActivityThread.ActivityClientRecord performResumeActivity(android.os.IBinder
			 token, bool clearHide)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			if (r != null && !r.activity.mFinished)
			{
				if (clearHide)
				{
					r.hideForNow = false;
					r.activity.mStartedActivity = false;
				}
				try
				{
					if (r.pendingIntents != null)
					{
						deliverNewIntents(r, r.pendingIntents);
						r.pendingIntents = null;
					}
					if (r.pendingResults != null)
					{
						deliverResults(r, r.pendingResults);
						r.pendingResults = null;
					}
					r.activity.performResume();
					android.util.EventLog.writeEvent(LOG_ON_RESUME_CALLED, r.activity.getComponentName
						().getClassName());
					r.paused = false;
					r.stopped = false;
					r.state = null;
				}
				catch (System.Exception e)
				{
					if (!mInstrumentation.onException(r.activity, e))
					{
						throw new java.lang.RuntimeException("Unable to resume activity " + r.intent.getComponent
							().toShortString() + ": " + e.ToString(), e);
					}
				}
			}
			return r;
		}

		internal void cleanUpPendingRemoveWindows(android.app.ActivityThread.ActivityClientRecord
			 r)
		{
			if (r.mPendingRemoveWindow != null)
			{
				r.mPendingRemoveWindowManager.removeViewImmediate(r.mPendingRemoveWindow);
				android.os.IBinder wtoken = r.mPendingRemoveWindow.getWindowToken();
				if (wtoken != null)
				{
					android.view.WindowManagerImpl.getDefault().closeAll(wtoken, r.activity.GetType()
						.FullName, "Activity");
				}
			}
			r.mPendingRemoveWindow = null;
			r.mPendingRemoveWindowManager = null;
		}

		[Sharpen.Stub]
		internal void handleResumeActivity(android.os.IBinder token, bool clearHide, bool
			 isForward)
		{
			throw new System.NotImplementedException();
		}

		private int mThumbnailWidth = -1;

		private int mThumbnailHeight = -1;

		private android.graphics.Bitmap mAvailThumbnailBitmap = null;

		private android.graphics.Canvas mThumbnailCanvas = null;

		// If we are getting ready to gc after going to the background, well
		// we are back active so skip it.
		// If the window hasn't yet been added to the window manager,
		// and this guy didn't finish itself or start another activity,
		// then go ahead and add the window.
		// If the window has already been added, but during resume
		// we started another activity, then don't yet make the
		// window visible.
		// Get rid of anything left hanging around.
		// The window is now visible if it has been added, we are not
		// simply finishing, and we are not starting another activity.
		// If an exception was thrown when trying to resume, then
		// just end this activity.
		internal android.graphics.Bitmap createThumbnailBitmap(android.app.ActivityThread
			.ActivityClientRecord r)
		{
			android.graphics.Bitmap thumbnail = mAvailThumbnailBitmap;
			try
			{
				if (thumbnail == null)
				{
					int w = mThumbnailWidth;
					int h;
					if (w < 0)
					{
						android.content.res.Resources res = r.activity.getResources();
						mThumbnailHeight = h = res.getDimensionPixelSize(android.@internal.R.dimen.thumbnail_height
							);
						mThumbnailWidth = w = res.getDimensionPixelSize(android.@internal.R.dimen.thumbnail_width
							);
					}
					else
					{
						h = mThumbnailHeight;
					}
					// On platforms where we don't want thumbnails, set dims to (0,0)
					if ((w > 0) && (h > 0))
					{
						thumbnail = android.graphics.Bitmap.createBitmap(w, h, THUMBNAIL_FORMAT);
						thumbnail.eraseColor(0);
					}
				}
				if (thumbnail != null)
				{
					android.graphics.Canvas cv = mThumbnailCanvas;
					if (cv == null)
					{
						mThumbnailCanvas = cv = new android.graphics.Canvas();
					}
					cv.setBitmap(thumbnail);
					if (!r.activity.onCreateThumbnail(thumbnail, cv))
					{
						mAvailThumbnailBitmap = thumbnail;
						thumbnail = null;
					}
					cv.setBitmap(null);
				}
			}
			catch (System.Exception e)
			{
				if (!mInstrumentation.onException(r.activity, e))
				{
					throw new java.lang.RuntimeException("Unable to create thumbnail of " + r.intent.
						getComponent().toShortString() + ": " + e.ToString(), e);
				}
				thumbnail = null;
			}
			return thumbnail;
		}

		private void handlePauseActivity(android.os.IBinder token, bool finished, bool userLeaving
			, int configChanges)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			if (r != null)
			{
				//Slog.v(TAG, "userLeaving=" + userLeaving + " handling pause of " + r);
				if (userLeaving)
				{
					performUserLeavingActivity(r);
				}
				r.activity.mConfigChangeFlags |= configChanges;
				performPauseActivity(token, finished, r.isPreHoneycomb());
				// Make sure any pending writes are now committed.
				if (r.isPreHoneycomb())
				{
					android.app.QueuedWork.waitToFinish();
				}
				// Tell the activity manager we have paused.
				try
				{
					android.app.ActivityManagerNative.getDefault().activityPaused(token);
				}
				catch (android.os.RemoteException)
				{
				}
			}
		}

		internal void performUserLeavingActivity(android.app.ActivityThread.ActivityClientRecord
			 r)
		{
			mInstrumentation.callActivityOnUserLeaving(r.activity);
		}

		internal android.os.Bundle performPauseActivity(android.os.IBinder token, bool finished
			, bool saveState)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			return r != null ? performPauseActivity(r, finished, saveState) : null;
		}

		internal android.os.Bundle performPauseActivity(android.app.ActivityThread.ActivityClientRecord
			 r, bool finished, bool saveState)
		{
			if (r.paused)
			{
				if (r.activity.mFinished)
				{
					// If we are finishing, we won't call onResume() in certain cases.
					// So here we likewise don't want to call onPause() if the activity
					// isn't resumed.
					return null;
				}
				java.lang.RuntimeException e = new java.lang.RuntimeException("Performing pause of activity that is not resumed: "
					 + r.intent.getComponent().toShortString());
				android.util.Slog.e(TAG, e.Message, e);
			}
			android.os.Bundle state = null;
			if (finished)
			{
				r.activity.mFinished = true;
			}
			try
			{
				// Next have the activity save its current state and managed dialogs...
				if (!r.activity.mFinished && saveState)
				{
					state = new android.os.Bundle();
					state.setAllowFds(false);
					mInstrumentation.callActivityOnSaveInstanceState(r.activity, state);
					r.state = state;
				}
				// Now we are idle.
				r.activity.mCalled = false;
				mInstrumentation.callActivityOnPause(r.activity);
				android.util.EventLog.writeEvent(LOG_ON_PAUSE_CALLED, r.activity.getComponentName
					().getClassName());
				if (!r.activity.mCalled)
				{
					throw new android.app.SuperNotCalledException("Activity " + r.intent.getComponent
						().toShortString() + " did not call through to super.onPause()");
				}
			}
			catch (android.app.SuperNotCalledException e)
			{
				throw;
			}
			catch (System.Exception e)
			{
				if (!mInstrumentation.onException(r.activity, e))
				{
					throw new java.lang.RuntimeException("Unable to pause activity " + r.intent.getComponent
						().toShortString() + ": " + e.ToString(), e);
				}
			}
			r.paused = true;
			// Notify any outstanding on paused listeners
			java.util.ArrayList<android.app.OnActivityPausedListener> listeners;
			lock (mOnPauseListeners)
			{
				listeners = mOnPauseListeners.remove(r.activity);
			}
			int size = (listeners != null ? listeners.size() : 0);
			{
				for (int i = 0; i < size; i++)
				{
					listeners.get(i).onPaused(r.activity);
				}
			}
			return state;
		}

		internal void performStopActivity(android.os.IBinder token, bool saveState)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			performStopActivityInner(r, null, false, saveState);
		}

		[Sharpen.Stub]
		private class StopInfo
		{
			internal android.graphics.Bitmap thumbnail;

			internal java.lang.CharSequence description;
		}

		[Sharpen.Stub]
		private class ProviderRefCount
		{
			public int count;

			[Sharpen.Stub]
			internal ProviderRefCount(ActivityThread _enclosing, int pCount)
			{
				throw new System.NotImplementedException();
			}

			private readonly ActivityThread _enclosing;
		}

		/// <summary>Core implementation of stopping an activity.</summary>
		/// <remarks>
		/// Core implementation of stopping an activity.  Note this is a little
		/// tricky because the server's meaning of stop is slightly different
		/// than our client -- for the server, stop means to save state and give
		/// it the result when it is done, but the window may still be visible.
		/// For the client, we want to call onStop()/onStart() to indicate when
		/// the activity's UI visibillity changes.
		/// </remarks>
		private void performStopActivityInner(android.app.ActivityThread.ActivityClientRecord
			 r, android.app.ActivityThread.StopInfo info, bool keepShown, bool saveState)
		{
			android.os.Bundle state = null;
			if (r != null)
			{
				if (!keepShown && r.stopped)
				{
					if (r.activity.mFinished)
					{
						// If we are finishing, we won't call onResume() in certain
						// cases.  So here we likewise don't want to call onStop()
						// if the activity isn't resumed.
						return;
					}
					java.lang.RuntimeException e = new java.lang.RuntimeException("Performing stop of activity that is not resumed: "
						 + r.intent.getComponent().toShortString());
					android.util.Slog.e(TAG, e.Message, e);
				}
				if (info != null)
				{
					try
					{
						// First create a thumbnail for the activity...
						info.thumbnail = createThumbnailBitmap(r);
						info.description = r.activity.onCreateDescription();
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to save state of activity " + r.intent
								.getComponent().toShortString() + ": " + e.ToString(), e);
						}
					}
				}
				// Next have the activity save its current state and managed dialogs...
				if (!r.activity.mFinished && saveState)
				{
					if (r.state == null)
					{
						state = new android.os.Bundle();
						state.setAllowFds(false);
						mInstrumentation.callActivityOnSaveInstanceState(r.activity, state);
						r.state = state;
					}
					else
					{
						state = r.state;
					}
				}
				if (!keepShown)
				{
					try
					{
						// Now we are idle.
						r.activity.performStop();
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to stop activity " + r.intent.getComponent
								().toShortString() + ": " + e.ToString(), e);
						}
					}
					r.stopped = true;
				}
				r.paused = true;
			}
		}

		internal void updateVisibility(android.app.ActivityThread.ActivityClientRecord r, 
			bool show)
		{
			android.view.View v = r.activity.mDecor;
			if (v != null)
			{
				if (show)
				{
					if (!r.activity.mVisibleFromServer)
					{
						r.activity.mVisibleFromServer = true;
						mNumVisibleActivities++;
						if (r.activity.mVisibleFromClient)
						{
							r.activity.makeVisible();
						}
					}
					if (r.newConfig != null)
					{
						performConfigurationChanged(r.activity, r.newConfig);
						r.newConfig = null;
					}
				}
				else
				{
					if (r.activity.mVisibleFromServer)
					{
						r.activity.mVisibleFromServer = false;
						mNumVisibleActivities--;
						v.setVisibility(android.view.View.INVISIBLE);
					}
				}
			}
		}

		private void handleStopActivity(android.os.IBinder token, bool show, int configChanges
			)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			r.activity.mConfigChangeFlags |= configChanges;
			android.app.ActivityThread.StopInfo info = new android.app.ActivityThread.StopInfo
				();
			performStopActivityInner(r, info, show, true);
			updateVisibility(r, show);
			// Make sure any pending writes are now committed.
			if (!r.isPreHoneycomb())
			{
				android.app.QueuedWork.waitToFinish();
			}
			// Tell activity manager we have been stopped.
			try
			{
				android.app.ActivityManagerNative.getDefault().activityStopped(r.token, r.state, 
					info.thumbnail, info.description);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		internal void performRestartActivity(android.os.IBinder token)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			if (r.stopped)
			{
				r.activity.performRestart();
				r.stopped = false;
			}
		}

		private void handleWindowVisibility(android.os.IBinder token, bool show)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			if (r == null)
			{
				android.util.Log.w(TAG, "handleWindowVisibility: no activity for token " + token);
				return;
			}
			if (!show && !r.stopped)
			{
				performStopActivityInner(r, null, show, false);
			}
			else
			{
				if (show && r.stopped)
				{
					// If we are getting ready to gc after going to the background, well
					// we are back active so skip it.
					unscheduleGcIdler();
					r.activity.performRestart();
					r.stopped = false;
				}
			}
			if (r.activity.mDecor != null)
			{
				if (false)
				{
					android.util.Slog.v(TAG, "Handle window " + r + " visibility: " + show);
				}
				updateVisibility(r, show);
			}
		}

		private void handleSleeping(android.os.IBinder token, bool sleeping)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			if (r == null)
			{
				android.util.Log.w(TAG, "handleSleeping: no activity for token " + token);
				return;
			}
			if (sleeping)
			{
				if (!r.stopped && !r.isPreHoneycomb())
				{
					try
					{
						// Now we are idle.
						r.activity.performStop();
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to stop activity " + r.intent.getComponent
								().toShortString() + ": " + e.ToString(), e);
						}
					}
					r.stopped = true;
				}
				// Make sure any pending writes are now committed.
				if (!r.isPreHoneycomb())
				{
					android.app.QueuedWork.waitToFinish();
				}
				// Tell activity manager we slept.
				try
				{
					android.app.ActivityManagerNative.getDefault().activitySlept(r.token);
				}
				catch (android.os.RemoteException)
				{
				}
			}
			else
			{
				if (r.stopped && r.activity.mVisibleFromServer)
				{
					r.activity.performRestart();
					r.stopped = false;
				}
			}
		}

		private void handleSetCoreSettings(android.os.Bundle coreSettings)
		{
			lock (mPackages)
			{
				mCoreSettings = coreSettings;
			}
		}

		internal void handleUpdatePackageCompatibilityInfo(android.app.ActivityThread.UpdateCompatibilityData
			 data)
		{
			android.app.LoadedApk apk = peekPackageInfo(data.pkg, false);
			if (apk != null)
			{
				apk.mCompatibilityInfo.set(data.info);
			}
			apk = peekPackageInfo(data.pkg, true);
			if (apk != null)
			{
				apk.mCompatibilityInfo.set(data.info);
			}
			handleConfigurationChanged(mConfiguration, data.info);
			android.view.WindowManagerImpl.getDefault().reportNewConfiguration(mConfiguration
				);
		}

		internal void deliverResults(android.app.ActivityThread.ActivityClientRecord r, java.util.List
			<android.app.ResultInfo> results)
		{
			int N = results.size();
			{
				for (int i = 0; i < N; i++)
				{
					android.app.ResultInfo ri = results.get(i);
					try
					{
						if (ri.mData != null)
						{
							ri.mData.setExtrasClassLoader(r.activity.getClassLoader());
						}
						r.activity.dispatchActivityResult(ri.mResultWho, ri.mRequestCode, ri.mResultCode, 
							ri.mData);
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Failure delivering result " + ri + " to activity "
								 + r.intent.getComponent().toShortString() + ": " + e.ToString(), e);
						}
					}
				}
			}
		}

		internal void handleSendResult(android.app.ActivityThread.ResultData res)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(res.token);
			if (r != null)
			{
				bool resumed = !r.paused;
				if (!r.activity.mFinished && r.activity.mDecor != null && r.hideForNow && resumed)
				{
					// We had hidden the activity because it started another
					// one...  we have gotten a result back and we are not
					// paused, so make sure our window is visible.
					updateVisibility(r, true);
				}
				if (resumed)
				{
					try
					{
						// Now we are idle.
						r.activity.mCalled = false;
						r.activity.mTemporaryPause = true;
						mInstrumentation.callActivityOnPause(r.activity);
						if (!r.activity.mCalled)
						{
							throw new android.app.SuperNotCalledException("Activity " + r.intent.getComponent
								().toShortString() + " did not call through to super.onPause()");
						}
					}
					catch (android.app.SuperNotCalledException e)
					{
						throw;
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to pause activity " + r.intent.getComponent
								().toShortString() + ": " + e.ToString(), e);
						}
					}
				}
				deliverResults(r, res.results);
				if (resumed)
				{
					r.activity.performResume();
					r.activity.mTemporaryPause = false;
				}
			}
		}

		internal android.app.ActivityThread.ActivityClientRecord performDestroyActivity(android.os.IBinder
			 token, bool finishing)
		{
			return performDestroyActivity(token, finishing, 0, false);
		}

		internal android.app.ActivityThread.ActivityClientRecord performDestroyActivity(android.os.IBinder
			 token, bool finishing, int configChanges, bool getNonConfigInstance)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			System.Type activityClass = null;
			if (r != null)
			{
				activityClass = r.activity.GetType();
				r.activity.mConfigChangeFlags |= configChanges;
				if (finishing)
				{
					r.activity.mFinished = true;
				}
				if (!r.paused)
				{
					try
					{
						r.activity.mCalled = false;
						mInstrumentation.callActivityOnPause(r.activity);
						android.util.EventLog.writeEvent(LOG_ON_PAUSE_CALLED, r.activity.getComponentName
							().getClassName());
						if (!r.activity.mCalled)
						{
							throw new android.app.SuperNotCalledException("Activity " + safeToComponentShortString
								(r.intent) + " did not call through to super.onPause()");
						}
					}
					catch (android.app.SuperNotCalledException e)
					{
						throw;
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to pause activity " + safeToComponentShortString
								(r.intent) + ": " + e.ToString(), e);
						}
					}
					r.paused = true;
				}
				if (!r.stopped)
				{
					try
					{
						r.activity.performStop();
					}
					catch (android.app.SuperNotCalledException e)
					{
						throw;
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to stop activity " + safeToComponentShortString
								(r.intent) + ": " + e.ToString(), e);
						}
					}
					r.stopped = true;
				}
				if (getNonConfigInstance)
				{
					try
					{
						r.lastNonConfigurationInstances = r.activity.retainNonConfigurationInstances();
					}
					catch (System.Exception e)
					{
						if (!mInstrumentation.onException(r.activity, e))
						{
							throw new java.lang.RuntimeException("Unable to retain activity " + r.intent.getComponent
								().toShortString() + ": " + e.ToString(), e);
						}
					}
				}
				try
				{
					r.activity.mCalled = false;
					mInstrumentation.callActivityOnDestroy(r.activity);
					if (!r.activity.mCalled)
					{
						throw new android.app.SuperNotCalledException("Activity " + safeToComponentShortString
							(r.intent) + " did not call through to super.onDestroy()");
					}
					if (r.window != null)
					{
						r.window.closeAllPanels();
					}
				}
				catch (android.app.SuperNotCalledException e)
				{
					throw;
				}
				catch (System.Exception e)
				{
					if (!mInstrumentation.onException(r.activity, e))
					{
						throw new java.lang.RuntimeException("Unable to destroy activity " + safeToComponentShortString
							(r.intent) + ": " + e.ToString(), e);
					}
				}
			}
			mActivities.remove(token);
			android.os.StrictMode.decrementExpectedActivityCount(activityClass);
			return r;
		}

		private static string safeToComponentShortString(android.content.Intent intent)
		{
			android.content.ComponentName component = intent.getComponent();
			return component == null ? "[Unknown]" : component.toShortString();
		}

		private void handleDestroyActivity(android.os.IBinder token, bool finishing, int 
			configChanges, bool getNonConfigInstance)
		{
			android.app.ActivityThread.ActivityClientRecord r = performDestroyActivity(token, 
				finishing, configChanges, getNonConfigInstance);
			if (r != null)
			{
				cleanUpPendingRemoveWindows(r);
				android.view.WindowManager wm = r.activity.getWindowManager();
				android.view.View v = r.activity.mDecor;
				if (v != null)
				{
					if (r.activity.mVisibleFromServer)
					{
						mNumVisibleActivities--;
					}
					android.os.IBinder wtoken = v.getWindowToken();
					if (r.activity.mWindowAdded)
					{
						if (r.onlyLocalRequest)
						{
							// Hold off on removing this until the new activity's
							// window is being added.
							r.mPendingRemoveWindow = v;
							r.mPendingRemoveWindowManager = wm;
						}
						else
						{
							wm.removeViewImmediate(v);
						}
					}
					if (wtoken != null && r.mPendingRemoveWindow == null)
					{
						android.view.WindowManagerImpl.getDefault().closeAll(wtoken, r.activity.GetType()
							.FullName, "Activity");
					}
					r.activity.mDecor = null;
				}
				if (r.mPendingRemoveWindow == null)
				{
					// If we are delaying the removal of the activity window, then
					// we can't clean up all windows here.  Note that we can't do
					// so later either, which means any windows that aren't closed
					// by the app will leak.  Well we try to warning them a lot
					// about leaking windows, because that is a bug, so if they are
					// using this recreate facility then they get to live with leaks.
					android.view.WindowManagerImpl.getDefault().closeAll(token, r.activity.GetType().
						FullName, "Activity");
				}
				// Mocked out contexts won't be participating in the normal
				// process lifecycle, but if we're running with a proper
				// ApplicationContext we need to have it tear down things
				// cleanly.
				android.content.Context c = r.activity.getBaseContext();
				if (c is android.app.ContextImpl)
				{
					((android.app.ContextImpl)c).scheduleFinalCleanup(r.activity.GetType().FullName, 
						"Activity");
				}
			}
			if (finishing)
			{
				try
				{
					android.app.ActivityManagerNative.getDefault().activityDestroyed(token);
				}
				catch (android.os.RemoteException)
				{
				}
			}
		}

		// If the system process has died, it's game over for everyone.
		public void requestRelaunchActivity(android.os.IBinder token, java.util.List<android.app.ResultInfo
			> pendingResults, java.util.List<android.content.Intent> pendingNewIntents, int 
			configChanges, bool notResumed, android.content.res.Configuration config, bool fromServer
			)
		{
			android.app.ActivityThread.ActivityClientRecord target = null;
			lock (mPackages)
			{
				{
					for (int i = 0; i < mRelaunchingActivities.size(); i++)
					{
						android.app.ActivityThread.ActivityClientRecord r = mRelaunchingActivities.get(i);
						if (r.token == token)
						{
							target = r;
							if (pendingResults != null)
							{
								if (r.pendingResults != null)
								{
									r.pendingResults.addAll(pendingResults);
								}
								else
								{
									r.pendingResults = pendingResults;
								}
							}
							if (pendingNewIntents != null)
							{
								if (r.pendingIntents != null)
								{
									r.pendingIntents.addAll(pendingNewIntents);
								}
								else
								{
									r.pendingIntents = pendingNewIntents;
								}
							}
							break;
						}
					}
				}
				if (target == null)
				{
					target = new android.app.ActivityThread.ActivityClientRecord();
					target.token = token;
					target.pendingResults = pendingResults;
					target.pendingIntents = pendingNewIntents;
					if (!fromServer)
					{
						android.app.ActivityThread.ActivityClientRecord existing = mActivities.get(token);
						if (existing != null)
						{
							target.startsNotResumed = existing.paused;
						}
						target.onlyLocalRequest = true;
					}
					mRelaunchingActivities.add(target);
					queueOrSendMessage(android.app.ActivityThread.H.RELAUNCH_ACTIVITY, target);
				}
				if (fromServer)
				{
					target.startsNotResumed = notResumed;
					target.onlyLocalRequest = false;
				}
				if (config != null)
				{
					target.createdConfig = config;
				}
				target.pendingConfigChanges |= configChanges;
			}
		}

		internal void handleRelaunchActivity(android.app.ActivityThread.ActivityClientRecord
			 tmp)
		{
			// If we are getting ready to gc after going to the background, well
			// we are back active so skip it.
			unscheduleGcIdler();
			android.content.res.Configuration changedConfig = null;
			int configChanges = 0;
			// First: make sure we have the most recent configuration and most
			// recent version of the activity, or skip it if some previous call
			// had taken a more recent version.
			lock (mPackages)
			{
				int N = mRelaunchingActivities.size();
				android.os.IBinder token = tmp.token;
				tmp = null;
				{
					for (int i = 0; i < N; i++)
					{
						android.app.ActivityThread.ActivityClientRecord r = mRelaunchingActivities.get(i);
						if (r.token == token)
						{
							tmp = r;
							configChanges |= tmp.pendingConfigChanges;
							mRelaunchingActivities.remove(i);
							i--;
							N--;
						}
					}
				}
				if (tmp == null)
				{
					return;
				}
				if (mPendingConfiguration != null)
				{
					changedConfig = mPendingConfiguration;
					mPendingConfiguration = null;
				}
			}
			if (tmp.createdConfig != null)
			{
				// If the activity manager is passing us its current config,
				// assume that is really what we want regardless of what we
				// may have pending.
				if (mConfiguration == null || (tmp.createdConfig.isOtherSeqNewer(mConfiguration) 
					&& mConfiguration.diff(tmp.createdConfig) != 0))
				{
					if (changedConfig == null || tmp.createdConfig.isOtherSeqNewer(changedConfig))
					{
						changedConfig = tmp.createdConfig;
					}
				}
			}
			// If there was a pending configuration change, execute it first.
			if (changedConfig != null)
			{
				handleConfigurationChanged(changedConfig, null);
			}
			android.app.ActivityThread.ActivityClientRecord r_1 = mActivities.get(tmp.token);
			if (r_1 == null)
			{
				return;
			}
			r_1.activity.mConfigChangeFlags |= configChanges;
			r_1.onlyLocalRequest = tmp.onlyLocalRequest;
			android.content.Intent currentIntent = r_1.activity.mIntent;
			r_1.activity.mChangingConfigurations = true;
			// Need to ensure state is saved.
			if (!r_1.paused)
			{
				performPauseActivity(r_1.token, false, r_1.isPreHoneycomb());
			}
			if (r_1.state == null && !r_1.stopped && !r_1.isPreHoneycomb())
			{
				r_1.state = new android.os.Bundle();
				r_1.state.setAllowFds(false);
				mInstrumentation.callActivityOnSaveInstanceState(r_1.activity, r_1.state);
			}
			handleDestroyActivity(r_1.token, false, configChanges, true);
			r_1.activity = null;
			r_1.window = null;
			r_1.hideForNow = false;
			r_1.nextIdle = null;
			// Merge any pending results and pending intents; don't just replace them
			if (tmp.pendingResults != null)
			{
				if (r_1.pendingResults == null)
				{
					r_1.pendingResults = tmp.pendingResults;
				}
				else
				{
					r_1.pendingResults.addAll(tmp.pendingResults);
				}
			}
			if (tmp.pendingIntents != null)
			{
				if (r_1.pendingIntents == null)
				{
					r_1.pendingIntents = tmp.pendingIntents;
				}
				else
				{
					r_1.pendingIntents.addAll(tmp.pendingIntents);
				}
			}
			r_1.startsNotResumed = tmp.startsNotResumed;
			handleLaunchActivity(r_1, currentIntent);
		}

		private void handleRequestThumbnail(android.os.IBinder token)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			android.graphics.Bitmap thumbnail = createThumbnailBitmap(r);
			java.lang.CharSequence description = null;
			try
			{
				description = r.activity.onCreateDescription();
			}
			catch (System.Exception e)
			{
				if (!mInstrumentation.onException(r.activity, e))
				{
					throw new java.lang.RuntimeException("Unable to create description of activity " 
						+ r.intent.getComponent().toShortString() + ": " + e.ToString(), e);
				}
			}
			//System.out.println("Reporting top thumbnail " + thumbnail);
			try
			{
				android.app.ActivityManagerNative.getDefault().reportThumbnail(token, thumbnail, 
					description);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		internal java.util.ArrayList<android.content.ComponentCallbacks2> collectComponentCallbacksLocked
			(bool allActivities, android.content.res.Configuration newConfig)
		{
			java.util.ArrayList<android.content.ComponentCallbacks2> callbacks = new java.util.ArrayList
				<android.content.ComponentCallbacks2>();
			if (mActivities.size() > 0)
			{
				java.util.Iterator<android.app.ActivityThread.ActivityClientRecord> it = mActivities
					.values().iterator();
				while (it.hasNext())
				{
					android.app.ActivityThread.ActivityClientRecord ar = it.next();
					android.app.Activity a = ar.activity;
					if (a != null)
					{
						android.content.res.Configuration thisConfig = applyConfigCompatMainThread(newConfig
							, ar.packageInfo.mCompatibilityInfo.getIfNeeded());
						if (!ar.activity.mFinished && (allActivities || (a != null && !ar.paused)))
						{
							// If the activity is currently resumed, its configuration
							// needs to change right now.
							callbacks.add(a);
						}
						else
						{
							if (thisConfig != null)
							{
								// Otherwise, we will tell it about the change
								// the next time it is resumed or shown.  Note that
								// the activity manager may, before then, decide the
								// activity needs to be destroyed to handle its new
								// configuration.
								ar.newConfig = thisConfig;
							}
						}
					}
				}
			}
			if (mServices.size() > 0)
			{
				java.util.Iterator<android.app.Service> it = mServices.values().iterator();
				while (it.hasNext())
				{
					callbacks.add(it.next());
				}
			}
			lock (mProviderMap)
			{
				if (mLocalProviders.size() > 0)
				{
					java.util.Iterator<android.app.ActivityThread.ProviderClientRecord> it = mLocalProviders
						.values().iterator();
					while (it.hasNext())
					{
						callbacks.add(it.next().mLocalProvider);
					}
				}
			}
			int N = mAllApplications.size();
			{
				for (int i = 0; i < N; i++)
				{
					callbacks.add(mAllApplications.get(i));
				}
			}
			return callbacks;
		}

		private void performConfigurationChanged(android.content.ComponentCallbacks2 cb, 
			android.content.res.Configuration config)
		{
			// Only for Activity objects, check that they actually call up to their
			// superclass implementation.  ComponentCallbacks2 is an interface, so
			// we check the runtime type and act accordingly.
			android.app.Activity activity = (cb is android.app.Activity) ? (android.app.Activity
				)cb : null;
			if (activity != null)
			{
				activity.mCalled = false;
			}
			bool shouldChangeConfig = false;
			if ((activity == null) || (activity.mCurrentConfig == null))
			{
				shouldChangeConfig = true;
			}
			else
			{
				// If the new config is the same as the config this Activity
				// is already running with then don't bother calling
				// onConfigurationChanged
				int diff = activity.mCurrentConfig.diff(config);
				if (diff != 0)
				{
					// If this activity doesn't handle any of the config changes
					// then don't bother calling onConfigurationChanged as we're
					// going to destroy it.
					if ((~activity.mActivityInfo.getRealConfigChanged() & diff) == 0)
					{
						shouldChangeConfig = true;
					}
				}
			}
			if (shouldChangeConfig)
			{
				cb.onConfigurationChanged(config);
				if (activity != null)
				{
					if (!activity.mCalled)
					{
						throw new android.app.SuperNotCalledException("Activity " + activity.getLocalClassName
							() + " did not call through to super.onConfigurationChanged()");
					}
					activity.mConfigChangeFlags = 0;
					activity.mCurrentConfig = new android.content.res.Configuration(config);
				}
			}
		}

		public void applyConfigurationToResources(android.content.res.Configuration config
			)
		{
			lock (mPackages)
			{
				applyConfigurationToResourcesLocked(config, null);
			}
		}

		internal bool applyConfigurationToResourcesLocked(android.content.res.Configuration
			 config, android.content.res.CompatibilityInfo compat)
		{
			if (mResConfiguration == null)
			{
				mResConfiguration = new android.content.res.Configuration();
			}
			if (!mResConfiguration.isOtherSeqNewer(config) && compat == null)
			{
				return false;
			}
			int changes = mResConfiguration.updateFrom(config);
			android.util.DisplayMetrics dm = getDisplayMetricsLocked(null, true);
			if (compat != null && (mResCompatibilityInfo == null || !mResCompatibilityInfo.Equals
				(compat)))
			{
				mResCompatibilityInfo = compat;
				changes |= android.content.pm.ActivityInfo.CONFIG_SCREEN_LAYOUT | android.content.pm.ActivityInfo
					.CONFIG_SCREEN_SIZE | android.content.pm.ActivityInfo.CONFIG_SMALLEST_SCREEN_SIZE;
			}
			// set it for java, this also affects newly created Resources
			if (config.locale != null)
			{
				Sharpen.Util.SetCurrentCulture(config.locale);
			}
			android.content.res.Resources.updateSystemConfiguration(config, dm, compat);
			android.app.ApplicationPackageManager.configurationChanged();
			//Slog.i(TAG, "Configuration changed in " + currentPackageName());
			java.util.Iterator<java.lang.@ref.WeakReference<android.content.res.Resources>> it
				 = mActiveResources.values().iterator();
			//Iterator<Map.Entry<String, WeakReference<Resources>>> it =
			//    mActiveResources.entrySet().iterator();
			while (it.hasNext())
			{
				java.lang.@ref.WeakReference<android.content.res.Resources> v = it.next();
				android.content.res.Resources r = v.get();
				if (r != null)
				{
					r.updateConfiguration(config, dm, compat);
				}
				else
				{
					//Slog.i(TAG, "Updated app resources " + v.getKey()
					//        + " " + r + ": " + r.getConfiguration());
					//Slog.i(TAG, "Removing old resources " + v.getKey());
					it.remove();
				}
			}
			return changes != 0;
		}

		internal android.content.res.Configuration applyCompatConfiguration()
		{
			android.content.res.Configuration config = mConfiguration;
			if (mCompatConfiguration == null)
			{
				mCompatConfiguration = new android.content.res.Configuration();
			}
			mCompatConfiguration.setTo(mConfiguration);
			if (mResCompatibilityInfo != null && !mResCompatibilityInfo.supportsScreen())
			{
				mResCompatibilityInfo.applyToConfiguration(mCompatConfiguration);
				config = mCompatConfiguration;
			}
			return config;
		}

		internal void handleConfigurationChanged(android.content.res.Configuration config
			, android.content.res.CompatibilityInfo compat)
		{
			java.util.ArrayList<android.content.ComponentCallbacks2> callbacks = null;
			lock (mPackages)
			{
				if (mPendingConfiguration != null)
				{
					if (!mPendingConfiguration.isOtherSeqNewer(config))
					{
						config = mPendingConfiguration;
					}
					mPendingConfiguration = null;
				}
				if (config == null)
				{
					return;
				}
				applyConfigurationToResourcesLocked(config, compat);
				if (mConfiguration == null)
				{
					mConfiguration = new android.content.res.Configuration();
				}
				if (!mConfiguration.isOtherSeqNewer(config) && compat == null)
				{
					return;
				}
				mConfiguration.updateFrom(config);
				config = applyCompatConfiguration();
				callbacks = collectComponentCallbacksLocked(false, config);
			}
			// Cleanup hardware accelerated stuff
			android.view.WindowManagerImpl.getDefault().trimLocalMemory();
			if (callbacks != null)
			{
				int N = callbacks.size();
				{
					for (int i = 0; i < N; i++)
					{
						performConfigurationChanged(callbacks.get(i), config);
					}
				}
			}
		}

		internal void handleActivityConfigurationChanged(android.os.IBinder token)
		{
			android.app.ActivityThread.ActivityClientRecord r = mActivities.get(token);
			if (r == null || r.activity == null)
			{
				return;
			}
			performConfigurationChanged(r.activity, mCompatConfiguration);
		}

		[Sharpen.Stub]
		internal void handleProfilerControl(bool start, android.app.ActivityThread.ProfilerControlData
			 pcd, int profileType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void handleDumpHeap(bool managed, android.app.ActivityThread.DumpHeapData
			 dhd)
		{
			throw new System.NotImplementedException();
		}

		internal void handleDispatchPackageBroadcast(int cmd, string[] packages)
		{
			bool hasPkgInfo = false;
			if (packages != null)
			{
				{
					for (int i = packages.Length - 1; i >= 0; i--)
					{
						//Slog.i(TAG, "Cleaning old package: " + packages[i]);
						if (!hasPkgInfo)
						{
							java.lang.@ref.WeakReference<android.app.LoadedApk> @ref;
							@ref = mPackages.get(packages[i]);
							if (@ref != null && @ref.get() != null)
							{
								hasPkgInfo = true;
							}
							else
							{
								@ref = mResourcePackages.get(packages[i]);
								if (@ref != null && @ref.get() != null)
								{
									hasPkgInfo = true;
								}
							}
						}
						mPackages.remove(packages[i]);
						mResourcePackages.remove(packages[i]);
					}
				}
			}
			android.app.ApplicationPackageManager.handlePackageBroadcast(cmd, packages, hasPkgInfo
				);
		}

		[Sharpen.Stub]
		internal void handleLowMemory()
		{
			throw new System.NotImplementedException();
		}

		// Ask SQLite to free up as much memory as it can, mostly from its page caches.
		// Ask graphics to free up as much as possible (font/image caches)
		internal void handleTrimMemory(int level)
		{
			android.view.WindowManagerImpl.getDefault().trimMemory(level);
			java.util.ArrayList<android.content.ComponentCallbacks2> callbacks;
			lock (mPackages)
			{
				callbacks = collectComponentCallbacksLocked(true, null);
			}
			int N = callbacks.size();
			{
				for (int i = 0; i < N; i++)
				{
					callbacks.get(i).onTrimMemory(level);
				}
			}
		}

		[Sharpen.Stub]
		internal void handleBindApplication(android.app.ActivityThread.AppBindData data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void finishInstrumentation(int resultCode, android.os.Bundle results)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void installContentProviders(android.content.Context context, java.util.List
			<android.content.pm.ProviderInfo> providers)
		{
			throw new System.NotImplementedException();
		}

		// send up app name; do this *before* waiting for debugger
		// Persistent processes on low-memory devices do not get to
		// use hardware accelerated drawing, since this can add too much
		// overhead to the process.
		// If the app is Honeycomb MR1 or earlier, switch its AsyncTask
		// implementation to use the pool executor.  Normally, we use the
		// serialized executor as the default. This has to happen in the
		// main thread so the main looper is set right.
		// XXX should have option to change the port.
		// If the app is being launched for full backup or restore, bring it up in
		// a restricted environment with the base application class.
		// don't bring up providers in restricted mode; they may depend on the
		// app's custom Application class
		// For process that contains content providers, we want to
		// ensure that the JIT is enabled "at some point".
		//Slog.i(TAG, "am: " + ActivityManagerNative.getDefault()
		//      + ", app thr: " + mAppThread);
		// Don't ever unload this provider from the process.
		private android.content.IContentProvider getExistingProvider(android.content.Context
			 context, string name)
		{
			lock (mProviderMap)
			{
				android.app.ActivityThread.ProviderClientRecord pr = mProviderMap.get(name);
				if (pr != null)
				{
					return pr.mProvider;
				}
				return null;
			}
		}

		private android.content.IContentProvider getProvider(android.content.Context context
			, string name)
		{
			android.content.IContentProvider existing = getExistingProvider(context, name);
			if (existing != null)
			{
				return existing;
			}
			android.app.IActivityManagerClass.ContentProviderHolder holder = null;
			try
			{
				holder = android.app.ActivityManagerNative.getDefault().getContentProvider(getApplicationThread
					(), name);
			}
			catch (android.os.RemoteException)
			{
			}
			if (holder == null)
			{
				android.util.Slog.e(TAG, "Failed to find provider info for " + name);
				return null;
			}
			android.content.IContentProvider prov = installProvider(context, holder.provider, 
				holder.info, true);
			//Slog.i(TAG, "noReleaseNeeded=" + holder.noReleaseNeeded);
			if (holder.noReleaseNeeded || holder.provider == null)
			{
				// We are not going to release the provider if it is an external
				// provider that doesn't care about being released, or if it is
				// a local provider running in this process.
				//Slog.i(TAG, "*** NO RELEASE NEEDED");
				lock (mProviderMap)
				{
					mProviderRefCountMap.put(prov.asBinder(), new android.app.ActivityThread.ProviderRefCount
						(this, 10000));
				}
			}
			return prov;
		}

		public android.content.IContentProvider acquireProvider(android.content.Context c
			, string name)
		{
			android.content.IContentProvider provider = getProvider(c, name);
			if (provider == null)
			{
				return null;
			}
			android.os.IBinder jBinder = provider.asBinder();
			lock (mProviderMap)
			{
				android.app.ActivityThread.ProviderRefCount prc = mProviderRefCountMap.get(jBinder
					);
				if (prc == null)
				{
					mProviderRefCountMap.put(jBinder, new android.app.ActivityThread.ProviderRefCount
						(this, 1));
				}
				else
				{
					prc.count++;
				}
			}
			//end else
			//end synchronized
			return provider;
		}

		public android.content.IContentProvider acquireExistingProvider(android.content.Context
			 c, string name)
		{
			android.content.IContentProvider provider = getExistingProvider(c, name);
			if (provider == null)
			{
				return null;
			}
			android.os.IBinder jBinder = provider.asBinder();
			lock (mProviderMap)
			{
				android.app.ActivityThread.ProviderRefCount prc = mProviderRefCountMap.get(jBinder
					);
				if (prc == null)
				{
					mProviderRefCountMap.put(jBinder, new android.app.ActivityThread.ProviderRefCount
						(this, 1));
				}
				else
				{
					prc.count++;
				}
			}
			//end else
			//end synchronized
			return provider;
		}

		public bool releaseProvider(android.content.IContentProvider provider)
		{
			if (provider == null)
			{
				return false;
			}
			android.os.IBinder jBinder = provider.asBinder();
			lock (mProviderMap)
			{
				android.app.ActivityThread.ProviderRefCount prc = mProviderRefCountMap.get(jBinder
					);
				if (prc == null)
				{
					return false;
				}
				else
				{
					prc.count--;
					if (prc.count == 0)
					{
						// Schedule the actual remove asynchronously, since we
						// don't know the context this will be called in.
						// TODO: it would be nice to post a delayed message, so
						// if we come back and need the same provider quickly
						// we will still have it available.
						android.os.Message msg = mH.obtainMessage(android.app.ActivityThread.H.REMOVE_PROVIDER
							, provider);
						mH.sendMessage(msg);
					}
				}
			}
			//end if
			//end else
			//end synchronized
			return true;
		}

		internal void completeRemoveProvider(android.content.IContentProvider provider)
		{
			android.os.IBinder jBinder = provider.asBinder();
			string name = null;
			lock (mProviderMap)
			{
				android.app.ActivityThread.ProviderRefCount prc = mProviderRefCountMap.get(jBinder
					);
				if (prc != null && prc.count == 0)
				{
					mProviderRefCountMap.remove(jBinder);
					//invoke removeProvider to dereference provider
					name = removeProviderLocked(provider);
				}
			}
			if (name != null)
			{
				try
				{
					android.app.ActivityManagerNative.getDefault().removeContentProvider(getApplicationThread
						(), name);
				}
				catch (android.os.RemoteException)
				{
				}
			}
		}

		//do nothing content provider object is dead any way
		//end catch
		public string removeProviderLocked(android.content.IContentProvider provider)
		{
			if (provider == null)
			{
				return null;
			}
			android.os.IBinder providerBinder = provider.asBinder();
			string name = null;
			// remove the provider from mProviderMap
			java.util.Iterator<android.app.ActivityThread.ProviderClientRecord> iter = mProviderMap
				.values().iterator();
			while (iter.hasNext())
			{
				android.app.ActivityThread.ProviderClientRecord pr = iter.next();
				android.os.IBinder myBinder = pr.mProvider.asBinder();
				if (myBinder == providerBinder)
				{
					//find if its published by this process itself
					if (pr.mLocalProvider != null)
					{
						return name;
					}
					//content provider is in another process
					myBinder.unlinkToDeath(pr, 0);
					iter.remove();
					//invoke remove only once for the very first name seen
					if (name == null)
					{
						name = pr.mName;
					}
				}
			}
			//end if myBinder
			//end while iter
			return name;
		}

		internal void removeDeadProvider(string name, android.content.IContentProvider provider
			)
		{
			lock (mProviderMap)
			{
				android.app.ActivityThread.ProviderClientRecord pr = mProviderMap.get(name);
				if (pr != null && pr.mProvider.asBinder() == provider.asBinder())
				{
					android.util.Slog.i(TAG, "Removing dead content provider: " + name);
					android.app.ActivityThread.ProviderClientRecord removed = mProviderMap.remove(name
						);
					if (removed != null)
					{
						removed.mProvider.asBinder().unlinkToDeath(removed, 0);
					}
				}
			}
		}

		[Sharpen.Stub]
		private android.content.IContentProvider installProvider(android.content.Context 
			context, android.content.IContentProvider provider, android.content.pm.ProviderInfo
			 info, bool noisy)
		{
			throw new System.NotImplementedException();
		}

		// Ignore
		// XXX Need to create the correct context for this provider.
		// Cache the pointer for the remote provider.
		// Ignore
		// Don't set application object here -- if the system crashes,
		// we can't display an alert, we just want to die die die.
		// We need to apply this change to the resources
		// immediately, because upon returning the view
		// hierarchy will be informed about it.
		// This actually changed the resources!  Tell
		// everyone about it.
		public void installSystemProviders(java.util.List<android.content.pm.ProviderInfo
			> providers)
		{
			if (providers != null)
			{
				installContentProviders(mInitialApplication, providers);
			}
		}

		public int getIntCoreSetting(string key, int defaultValue)
		{
			lock (mPackages)
			{
				if (mCoreSettings != null)
				{
					return mCoreSettings.getInt(key, defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}
		// CloseGuard defaults to true and can be quite spammy.  We
		// disable it here, but selectively enable it later (via
		// StrictMode) on debug builds, but using DropBox, not logs.
	}
}
