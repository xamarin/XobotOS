using Sharpen;

namespace android.util
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public sealed class Slog
	{
		private Slog()
		{
		}

		public static int v(string tag, string msg)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.VERBOSE, tag, msg);
		}

		public static int v(string tag, string msg, System.Exception tr)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.VERBOSE, tag, msg + '\n' + android.util.Log.getStackTraceString(tr));
		}

		public static int d(string tag, string msg)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.DEBUG, tag, msg);
		}

		public static int d(string tag, string msg, System.Exception tr)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.DEBUG, tag, msg + '\n' + android.util.Log.getStackTraceString(tr));
		}

		public static int i(string tag, string msg)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.INFO, tag, msg);
		}

		public static int i(string tag, string msg, System.Exception tr)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.INFO, tag, msg + '\n' + android.util.Log.getStackTraceString(tr));
		}

		public static int w(string tag, string msg)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.WARN, tag, msg);
		}

		public static int w(string tag, string msg, System.Exception tr)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.WARN, tag, msg + '\n' + android.util.Log.getStackTraceString(tr));
		}

		public static int w(string tag, System.Exception tr)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.WARN, tag, android.util.Log.getStackTraceString(tr));
		}

		public static int e(string tag, string msg)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.ERROR, tag, msg);
		}

		public static int e(string tag, string msg, System.Exception tr)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, android.util.Log
				.ERROR, tag, msg + '\n' + android.util.Log.getStackTraceString(tr));
		}

		public static int println(int priority, string tag, string msg)
		{
			return android.util.Log.println_native(android.util.Log.LOG_ID_SYSTEM, priority, 
				tag, msg);
		}
	}
}
