using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class ApplicationErrorReport : android.os.Parcelable
	{
		internal const string SYSTEM_APPS_ERROR_RECEIVER_PROPERTY = "ro.error.receiver.system.apps";

		internal const string DEFAULT_ERROR_RECEIVER_PROPERTY = "ro.error.receiver.default";

		public const int TYPE_NONE = 0;

		public const int TYPE_CRASH = 1;

		public const int TYPE_ANR = 2;

		public const int TYPE_BATTERY = 3;

		public const int TYPE_RUNNING_SERVICE = 5;

		public int type;

		public string packageName;

		public string installerPackageName;

		public string processName;

		public long time;

		public bool systemApp;

		public android.app.ApplicationErrorReport.CrashInfo crashInfo;

		public android.app.ApplicationErrorReport.AnrInfo anrInfo;

		public android.app.ApplicationErrorReport.BatteryInfo batteryInfo;

		public android.app.ApplicationErrorReport.RunningServiceInfo runningServiceInfo;

		[Sharpen.Stub]
		public ApplicationErrorReport()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ApplicationErrorReport(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ComponentName getErrorReportReceiver(android.content.Context
			 context, string packageName, int appFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.content.ComponentName getErrorReportReceiver(android.content.pm.PackageManager
			 pm, string errorPackage, string receiverPackage)
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
		public virtual void readFromParcel(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class CrashInfo
		{
			public string exceptionClassName;

			public string exceptionMessage;

			public string throwFileName;

			public string throwClassName;

			public string throwMethodName;

			public int throwLineNumber;

			public string stackTrace;

			[Sharpen.Stub]
			public CrashInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public CrashInfo(System.Exception tr)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public CrashInfo(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void dump(android.util.Printer pw, string prefix)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class AnrInfo
		{
			public string activity;

			public string cause;

			public string info;

			[Sharpen.Stub]
			public AnrInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public AnrInfo(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void dump(android.util.Printer pw, string prefix)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class BatteryInfo
		{
			public int usagePercent;

			public long durationMicros;

			public string usageDetails;

			public string checkinDetails;

			[Sharpen.Stub]
			public BatteryInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public BatteryInfo(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void dump(android.util.Printer pw, string prefix)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class RunningServiceInfo
		{
			public long durationMillis;

			public string serviceDetails;

			[Sharpen.Stub]
			public RunningServiceInfo()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public RunningServiceInfo(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void dump(android.util.Printer pw, string prefix)
			{
				throw new System.NotImplementedException();
			}
		}

		private sealed class _Creator_563 : android.os.ParcelableClass.Creator<android.app.ApplicationErrorReport
			>
		{
			public _Creator_563()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.ApplicationErrorReport createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.ApplicationErrorReport[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.app.ApplicationErrorReport
			> CREATOR = new _Creator_563();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dump(android.util.Printer pw, string prefix)
		{
			throw new System.NotImplementedException();
		}
	}
}
