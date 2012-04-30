using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class ActivityManager
	{
		private static string TAG = "ActivityManager";

		private static bool localLOGV = false;

		private readonly android.content.Context mContext;

		private readonly android.os.Handler mHandler;

		[Sharpen.Stub]
		internal ActivityManager(android.content.Context context, android.os.Handler handler
			)
		{
			throw new System.NotImplementedException();
		}

		public const int COMPAT_MODE_ALWAYS = -1;

		public const int COMPAT_MODE_NEVER = -2;

		public const int COMPAT_MODE_UNKNOWN = -3;

		public const int COMPAT_MODE_DISABLED = 0;

		public const int COMPAT_MODE_ENABLED = 1;

		public const int COMPAT_MODE_TOGGLE = 2;

		[Sharpen.Stub]
		public virtual int getFrontActivityScreenCompatMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFrontActivityScreenCompatMode(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPackageScreenCompatMode(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPackageScreenCompatMode(string packageName, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getPackageAskScreenCompat(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPackageAskScreenCompat(string packageName, bool ask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMemoryClass()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int staticGetMemoryClass()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLargeMemoryClass()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int staticGetLargeMemoryClass()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isHighEndGfx(android.view.Display display)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isLargeRAM()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class RecentTaskInfo : android.os.Parcelable
		{
			public int id;

			public int persistentId;

			public android.content.Intent baseIntent;

			public android.content.ComponentName origActivity;

			public java.lang.CharSequence description;

			[Sharpen.Stub]
			public RecentTaskInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_325 : android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RecentTaskInfo>
			{
				public _Creator_325()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RecentTaskInfo createFromParcel(android.os.Parcel
					 source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RecentTaskInfo[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RecentTaskInfo> CREATOR = new _Creator_325();

			[Sharpen.Stub]
			private RecentTaskInfo(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}
		}

		public const int RECENT_WITH_EXCLUDED = unchecked((int)(0x0001));

		public const int RECENT_IGNORE_UNAVAILABLE = unchecked((int)(0x0002));

		[Sharpen.Stub]
		public virtual java.util.List<android.app.ActivityManager.RecentTaskInfo> getRecentTasks
			(int maxNum, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class RunningTaskInfo : android.os.Parcelable
		{
			public int id;

			public android.content.ComponentName baseActivity;

			public android.content.ComponentName topActivity;

			public android.graphics.Bitmap thumbnail;

			public java.lang.CharSequence description;

			public int numActivities;

			public int numRunning;

			[Sharpen.Stub]
			public RunningTaskInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_464 : android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RunningTaskInfo>
			{
				public _Creator_464()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RunningTaskInfo createFromParcel(android.os.Parcel
					 source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RunningTaskInfo[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RunningTaskInfo> CREATOR = new _Creator_464();

			[Sharpen.Stub]
			private RunningTaskInfo(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.app.ActivityManager.RunningTaskInfo> getRunningTasks
			(int maxNum, int flags, android.app.IThumbnailReceiver receiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.app.ActivityManager.RunningTaskInfo> getRunningTasks
			(int maxNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool removeSubTask(int taskId, int subTaskIndex)
		{
			throw new System.NotImplementedException();
		}

		public const int REMOVE_TASK_KILL_PROCESS = unchecked((int)(0x0001));

		[Sharpen.Stub]
		public virtual bool removeTask(int taskId, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class TaskThumbnails : android.os.Parcelable
		{
			public android.graphics.Bitmap mainThumbnail;

			public int numSubThumbbails;

			public android.app.IThumbnailRetriever retriever;

			[Sharpen.Stub]
			public TaskThumbnails()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.graphics.Bitmap getSubThumbnail(int index)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_631 : android.os.ParcelableClass.Creator<android.app.ActivityManager
				.TaskThumbnails>
			{
				public _Creator_631()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.TaskThumbnails createFromParcel(android.os.Parcel
					 source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.TaskThumbnails[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.ActivityManager
				.TaskThumbnails> CREATOR = new _Creator_631();

			[Sharpen.Stub]
			private TaskThumbnails(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual android.app.ActivityManager.TaskThumbnails getTaskThumbnails(int id
			)
		{
			throw new System.NotImplementedException();
		}

		public const int MOVE_TASK_WITH_HOME = unchecked((int)(0x00000001));

		public const int MOVE_TASK_NO_USER_ACTION = unchecked((int)(0x00000002));

		[Sharpen.Stub]
		public virtual void moveTaskToFront(int taskId, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class RunningServiceInfo : android.os.Parcelable
		{
			public android.content.ComponentName service;

			public int pid;

			public int uid;

			public string process;

			public bool foreground;

			public long activeSince;

			public bool started;

			public int clientCount;

			public int crashCount;

			public long lastActivityTime;

			public long restarting;

			public const int FLAG_STARTED = 1 << 0;

			public const int FLAG_FOREGROUND = 1 << 1;

			public const int FLAG_SYSTEM_PROCESS = 1 << 2;

			public const int FLAG_PERSISTENT_PROCESS = 1 << 3;

			public int flags;

			public string clientPackage;

			public int clientLabel;

			[Sharpen.Stub]
			public RunningServiceInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_837 : android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RunningServiceInfo>
			{
				public _Creator_837()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RunningServiceInfo createFromParcel(android.os.Parcel
					 source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RunningServiceInfo[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RunningServiceInfo> CREATOR = new _Creator_837();

			[Sharpen.Stub]
			private RunningServiceInfo(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.app.ActivityManager.RunningServiceInfo> getRunningServices
			(int maxNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.PendingIntent getRunningServiceControlPanel(android.content.ComponentName
			 service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class MemoryInfo : android.os.Parcelable
		{
			public long availMem;

			public long threshold;

			public bool lowMemory;

			public long hiddenAppThreshold;

			public long secondaryServerThreshold;

			public long visibleAppThreshold;

			public long foregroundAppThreshold;

			[Sharpen.Stub]
			public MemoryInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_951 : android.os.ParcelableClass.Creator<android.app.ActivityManager
				.MemoryInfo>
			{
				public _Creator_951()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.MemoryInfo createFromParcel(android.os.Parcel 
					source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.MemoryInfo[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.ActivityManager
				.MemoryInfo> CREATOR = new _Creator_951();

			[Sharpen.Stub]
			private MemoryInfo(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual void getMemoryInfo(android.app.ActivityManager.MemoryInfo outInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool clearApplicationUserData(string packageName, android.content.pm.IPackageDataObserver
			 observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class ProcessErrorStateInfo : android.os.Parcelable
		{
			public const int NO_ERROR = 0;

			public const int CRASHED = 1;

			public const int NOT_RESPONDING = 2;

			public int condition;

			public string processName;

			public int pid;

			public int uid;

			public string tag;

			public string shortMsg;

			public string longMsg;

			public string stackTrace;

			public byte[] crashData = null;

			[Sharpen.Stub]
			public ProcessErrorStateInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_1072 : android.os.ParcelableClass.Creator<android.app.ActivityManager
				.ProcessErrorStateInfo>
			{
				public _Creator_1072()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.ProcessErrorStateInfo createFromParcel(android.os.Parcel
					 source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.ProcessErrorStateInfo[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.ActivityManager
				.ProcessErrorStateInfo> CREATOR = new _Creator_1072();

			[Sharpen.Stub]
			private ProcessErrorStateInfo(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.app.ActivityManager.ProcessErrorStateInfo> 
			getProcessesInErrorState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class RunningAppProcessInfo : android.os.Parcelable
		{
			public string processName;

			public int pid;

			public int uid;

			public string[] pkgList;

			public const int FLAG_CANT_SAVE_STATE = 1 << 0;

			public const int FLAG_PERSISTENT = 1 << 1;

			public int flags;

			public const int IMPORTANCE_FOREGROUND = 100;

			public const int IMPORTANCE_VISIBLE = 200;

			public const int IMPORTANCE_PERCEPTIBLE = 130;

			public const int IMPORTANCE_CANT_SAVE_STATE = 170;

			public const int IMPORTANCE_SERVICE = 300;

			public const int IMPORTANCE_BACKGROUND = 400;

			public const int IMPORTANCE_EMPTY = 500;

			public int importance;

			public int lru;

			public const int REASON_UNKNOWN = 0;

			public const int REASON_PROVIDER_IN_USE = 1;

			public const int REASON_SERVICE_IN_USE = 2;

			public int importanceReasonCode;

			public int importanceReasonPid;

			public android.content.ComponentName importanceReasonComponent;

			public int importanceReasonImportance;

			[Sharpen.Stub]
			public RunningAppProcessInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public RunningAppProcessInfo(string pProcessName, int pPid, string[] pArr)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_1307 : android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RunningAppProcessInfo>
			{
				public _Creator_1307()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RunningAppProcessInfo createFromParcel(android.os.Parcel
					 source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.ActivityManager.RunningAppProcessInfo[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.app.ActivityManager
				.RunningAppProcessInfo> CREATOR = new _Creator_1307();

			[Sharpen.Stub]
			private RunningAppProcessInfo(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.content.pm.ApplicationInfo> getRunningExternalApplications
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.app.ActivityManager.RunningAppProcessInfo> 
			getRunningAppProcesses()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.Debug.MemoryInfo[] getProcessMemoryInfo(int[] pids)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This is now just a wrapper forkillBackgroundProcesses(string) ; the previous behavior here is no longer available to applications because it allows them to break other applications by removing their alarms, stopping their services, etc."
			)]
		public virtual void restartPackage(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void killBackgroundProcesses(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void forceStopPackage(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.pm.ConfigurationInfo getDeviceConfigurationInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLauncherLargeIconDensity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLauncherLargeIconSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isUserAMonkey()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isRunningInTestHarness()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.Map<string, int> getAllPackageLaunchCounts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.@internal.PkgUsageStats[] getAllPackageUsageStats()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool switchUser(int userid)
		{
			throw new System.NotImplementedException();
		}
	}
}
