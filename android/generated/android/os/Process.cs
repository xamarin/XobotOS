using Sharpen;

namespace android.os
{
	[Sharpen.NakedStub]
	public class ZygoteStartFailedEx
	{
	}

	[Sharpen.Stub]
	public partial class Process
	{
		internal const string LOG_TAG = "Process";

		internal const string ZYGOTE_SOCKET = "zygote";

		public const string ANDROID_SHARED_MEDIA = "com.android.process.media";

		public const string GOOGLE_SHARED_APP_CONTENT = "com.google.process.content";

		public const int SYSTEM_UID = 1000;

		public const int PHONE_UID = 1001;

		public const int SHELL_UID = 2000;

		public const int LOG_UID = 1007;

		public const int WIFI_UID = 1010;

		public const int MEDIA_UID = 1013;

		public const int SDCARD_RW_GID = 1015;

		public const int NFC_UID = 1025;

		public const int MEDIA_RW_GID = 1023;

		public const int FIRST_APPLICATION_UID = 10000;

		public const int LAST_APPLICATION_UID = 99999;

		public const int BLUETOOTH_GID = 2000;

		public const int THREAD_PRIORITY_DEFAULT = 0;

		public const int THREAD_PRIORITY_LOWEST = 19;

		public const int THREAD_PRIORITY_BACKGROUND = 10;

		public const int THREAD_PRIORITY_FOREGROUND = -2;

		public const int THREAD_PRIORITY_DISPLAY = -4;

		public const int THREAD_PRIORITY_URGENT_DISPLAY = -8;

		public const int THREAD_PRIORITY_AUDIO = -16;

		public const int THREAD_PRIORITY_URGENT_AUDIO = -19;

		public const int THREAD_PRIORITY_MORE_FAVORABLE = -1;

		public const int THREAD_PRIORITY_LESS_FAVORABLE = +1;

		public const int THREAD_GROUP_DEFAULT = 0;

		public const int THREAD_GROUP_BG_NONINTERACTIVE = 1;

		public const int THREAD_GROUP_FG_BOOST = 2;

		public const int SIGNAL_QUIT = 3;

		public const int SIGNAL_KILL = 9;

		public const int SIGNAL_USR1 = 10;

		internal static android.net.LocalSocket sZygoteSocket;

		internal static java.io.DataInputStream sZygoteInputStream;

		internal static java.io.BufferedWriter sZygoteWriter;

		internal static bool sPreviousZygoteOpenFailed;

		[Sharpen.Stub]
		public static android.os.Process.ProcessStartResult start(string processClass, string
			 niceName, int uid, int gid, int[] gids, int debugFlags, int targetSdkVersion, string
			[] zygoteArgs)
		{
			throw new System.NotImplementedException();
		}

		internal const int ZYGOTE_RETRY_MILLIS = 500;

		[Sharpen.Stub]
		private static void openZygoteSocketIfNeeded()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.os.Process.ProcessStartResult zygoteSendArgsAndGetResult(java.util.ArrayList
			<string> args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.os.Process.ProcessStartResult startViaZygote(string processClass
			, string niceName, int uid, int gid, int[] gids, int debugFlags, int targetSdkVersion
			, string[] extraArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getElapsedCpuTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int myPid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int myTid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getUidForName(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getGidForName(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getUidForPid(int pid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getParentPid(int pid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setThreadPriority(int tid, int priority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setCanSelfBackground(bool backgroundOk)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setThreadGroup(int tid, int group)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setProcessGroup(int pid, int group)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setThreadPriority(int priority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getThreadPriority(int tid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method always returns true.  Do not use.")]
		public static bool supportsProcesses()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool setOomAdj(int pid, int amt)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setArgV0(string text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void killProcess(int pid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setUid(int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setGid(int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sendSignal(int pid, int signal)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void killProcessQuiet(int pid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sendSignalQuiet(int pid, int signal)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getFreeMemory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void readProcLines(string path, string[] reqFields, long[] outSizes
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int[] getPids(string path, int[] lastArray)
		{
			throw new System.NotImplementedException();
		}

		public const int PROC_TERM_MASK = unchecked((int)(0xff));

		public const int PROC_ZERO_TERM = 0;

		public const int PROC_SPACE_TERM = (int)' ';

		public const int PROC_TAB_TERM = (int)'\t';

		public const int PROC_COMBINE = unchecked((int)(0x100));

		public const int PROC_PARENS = unchecked((int)(0x200));

		public const int PROC_OUT_STRING = unchecked((int)(0x1000));

		public const int PROC_OUT_LONG = unchecked((int)(0x2000));

		public const int PROC_OUT_FLOAT = unchecked((int)(0x4000));

		[Sharpen.Stub]
		public static bool readProcFile(string file, int[] format, string[] outStrings, long
			[] outLongs, float[] outFloats)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool parseProcLine(byte[] buffer, int startIndex, int endIndex, int
			[] format, string[] outStrings, long[] outLongs, float[] outFloats)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getPss(int pid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class ProcessStartResult
		{
			public int pid;

			public bool usingWrapper;
		}
	}
}
