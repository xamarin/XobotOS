using Sharpen;

namespace android.util
{
	/// <summary>API for sending log output.</summary>
	/// <remarks>
	/// API for sending log output.
	/// <p>Generally, use the Log.v() Log.d() Log.i() Log.w() and Log.e()
	/// methods.
	/// <p>The order in terms of verbosity, from least to most is
	/// ERROR, WARN, INFO, DEBUG, VERBOSE.  Verbose should never be compiled
	/// into an application except during development.  Debug logs are compiled
	/// in but stripped at runtime.  Error, warning and info logs are always kept.
	/// <p><b>Tip:</b> A good convention is to declare a <code>TAG</code> constant
	/// in your class:
	/// <pre>private static final String TAG = "MyActivity";</pre>
	/// and use that in subsequent calls to the log methods.
	/// </p>
	/// <p><b>Tip:</b> Don't forget that when you make a call like
	/// <pre>Log.v(TAG, "index=" + i);</pre>
	/// that when you're building the string to pass into Log.d, the compiler uses a
	/// StringBuilder and at least three allocations occur: the StringBuilder
	/// itself, the buffer, and the String object.  Realistically, there is also
	/// another buffer allocation and copy, and even more pressure on the gc.
	/// That means that if your log message is filtered out, you might be doing
	/// significant work and incurring significant overhead.
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed partial class Log
	{
		/// <summary>Priority constant for the println method; use Log.v.</summary>
		/// <remarks>Priority constant for the println method; use Log.v.</remarks>
		public const int VERBOSE = 2;

		/// <summary>Priority constant for the println method; use Log.d.</summary>
		/// <remarks>Priority constant for the println method; use Log.d.</remarks>
		public const int DEBUG = 3;

		/// <summary>Priority constant for the println method; use Log.i.</summary>
		/// <remarks>Priority constant for the println method; use Log.i.</remarks>
		public const int INFO = 4;

		/// <summary>Priority constant for the println method; use Log.w.</summary>
		/// <remarks>Priority constant for the println method; use Log.w.</remarks>
		public const int WARN = 5;

		/// <summary>Priority constant for the println method; use Log.e.</summary>
		/// <remarks>Priority constant for the println method; use Log.e.</remarks>
		public const int ERROR = 6;

		/// <summary>Priority constant for the println method.</summary>
		/// <remarks>Priority constant for the println method.</remarks>
		public const int ASSERT = 7;

		/// <summary>
		/// Exception class used to capture a stack trace in
		/// <see cref="#wtf()">#wtf()</see>
		/// .
		/// </summary>
		[System.Serializable]
		internal class TerribleFailure : System.Exception
		{
			internal TerribleFailure(string msg, System.Exception cause) : base(msg, cause)
			{
			}
		}

		/// <summary>
		/// Interface to handle terrible failures from
		/// <see cref="#wtf()">#wtf()</see>
		/// .
		/// </summary>
		/// <hide></hide>
		internal interface TerribleFailureHandler
		{
			void onTerribleFailure(string tag, android.util.Log.TerribleFailure what);
		}

		private sealed class _TerribleFailureHandler_101 : android.util.Log.TerribleFailureHandler
		{
			public _TerribleFailureHandler_101()
			{
			}

			[Sharpen.ImplementsInterface(@"android.util.Log.TerribleFailureHandler")]
			public void onTerribleFailure(string tag, android.util.Log.TerribleFailure what)
			{
				XobotOS.Runtime.Util.FatalError(tag, what);
			}
		}

		private static android.util.Log.TerribleFailureHandler sWtfHandler = new _TerribleFailureHandler_101
			();

		/// <summary>
		/// Send a
		/// <see cref="VERBOSE">VERBOSE</see>
		/// log message.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		public static int v(string tag, string msg)
		{
			return println_native(LOG_ID_MAIN, VERBOSE, tag, msg);
		}

		/// <summary>
		/// Send a
		/// <see cref="VERBOSE">VERBOSE</see>
		/// log message and log the exception.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		/// <param name="tr">An exception to log</param>
		public static int v(string tag, string msg, System.Exception tr)
		{
			return println_native(LOG_ID_MAIN, VERBOSE, tag, msg + '\n' + getStackTraceString
				(tr));
		}

		/// <summary>
		/// Send a
		/// <see cref="DEBUG">DEBUG</see>
		/// log message.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		public static int d(string tag, string msg)
		{
			return println_native(LOG_ID_MAIN, DEBUG, tag, msg);
		}

		/// <summary>
		/// Send a
		/// <see cref="DEBUG">DEBUG</see>
		/// log message and log the exception.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		/// <param name="tr">An exception to log</param>
		public static int d(string tag, string msg, System.Exception tr)
		{
			return println_native(LOG_ID_MAIN, DEBUG, tag, msg + '\n' + getStackTraceString(tr
				));
		}

		/// <summary>
		/// Send an
		/// <see cref="INFO">INFO</see>
		/// log message.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		public static int i(string tag, string msg)
		{
			return println_native(LOG_ID_MAIN, INFO, tag, msg);
		}

		/// <summary>
		/// Send a
		/// <see cref="INFO">INFO</see>
		/// log message and log the exception.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		/// <param name="tr">An exception to log</param>
		public static int i(string tag, string msg, System.Exception tr)
		{
			return println_native(LOG_ID_MAIN, INFO, tag, msg + '\n' + getStackTraceString(tr
				));
		}

		/// <summary>
		/// Send a
		/// <see cref="WARN">WARN</see>
		/// log message.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		public static int w(string tag, string msg)
		{
			return println_native(LOG_ID_MAIN, WARN, tag, msg);
		}

		/// <summary>
		/// Send a
		/// <see cref="WARN">WARN</see>
		/// log message and log the exception.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		/// <param name="tr">An exception to log</param>
		public static int w(string tag, string msg, System.Exception tr)
		{
			return println_native(LOG_ID_MAIN, WARN, tag, msg + '\n' + getStackTraceString(tr
				));
		}

		public static int w(string tag, System.Exception tr)
		{
			return println_native(LOG_ID_MAIN, WARN, tag, getStackTraceString(tr));
		}

		/// <summary>
		/// Send an
		/// <see cref="ERROR">ERROR</see>
		/// log message.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		public static int e(string tag, string msg)
		{
			return println_native(LOG_ID_MAIN, ERROR, tag, msg);
		}

		/// <summary>
		/// Send a
		/// <see cref="ERROR">ERROR</see>
		/// log message and log the exception.
		/// </summary>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		/// <param name="tr">An exception to log</param>
		public static int e(string tag, string msg, System.Exception tr)
		{
			return println_native(LOG_ID_MAIN, ERROR, tag, msg + '\n' + getStackTraceString(tr
				));
		}

		/// <summary>What a Terrible Failure: Report a condition that should never happen.</summary>
		/// <remarks>
		/// What a Terrible Failure: Report a condition that should never happen.
		/// The error will always be logged at level ASSERT with the call stack.
		/// Depending on system configuration, a report may be added to the
		/// <see cref="android.os.DropBoxManager">android.os.DropBoxManager</see>
		/// and/or the process may be terminated
		/// immediately with an error dialog.
		/// </remarks>
		/// <param name="tag">Used to identify the source of a log message.</param>
		/// <param name="msg">The message you would like logged.</param>
		public static int wtf(string tag, string msg)
		{
			return wtf(tag, msg, null);
		}

		/// <summary>What a Terrible Failure: Report an exception that should never happen.</summary>
		/// <remarks>
		/// What a Terrible Failure: Report an exception that should never happen.
		/// Similar to
		/// <see cref="wtf(string, string)">wtf(string, string)</see>
		/// , with an exception to log.
		/// </remarks>
		/// <param name="tag">Used to identify the source of a log message.</param>
		/// <param name="tr">An exception to log.</param>
		public static int wtf(string tag, System.Exception tr)
		{
			return wtf(tag, tr.Message, tr);
		}

		/// <summary>What a Terrible Failure: Report an exception that should never happen.</summary>
		/// <remarks>
		/// What a Terrible Failure: Report an exception that should never happen.
		/// Similar to
		/// <see cref="wtf(string, System.Exception)">wtf(string, System.Exception)</see>
		/// , with a message as well.
		/// </remarks>
		/// <param name="tag">Used to identify the source of a log message.</param>
		/// <param name="msg">The message you would like logged.</param>
		/// <param name="tr">An exception to log.  May be null.</param>
		public static int wtf(string tag, string msg, System.Exception tr)
		{
			android.util.Log.TerribleFailure what = new android.util.Log.TerribleFailure(msg, 
				tr);
			int bytes = println_native(LOG_ID_MAIN, ASSERT, tag, msg + '\n' + getStackTraceString
				(tr));
			sWtfHandler.onTerribleFailure(tag, what);
			return bytes;
		}

		/// <summary>Sets the terrible failure handler, for testing.</summary>
		/// <remarks>Sets the terrible failure handler, for testing.</remarks>
		/// <returns>the old handler</returns>
		/// <hide></hide>
		internal static android.util.Log.TerribleFailureHandler setWtfHandler(android.util.Log
			.TerribleFailureHandler handler)
		{
			if (handler == null)
			{
				throw new System.ArgumentNullException("handler == null");
			}
			android.util.Log.TerribleFailureHandler oldHandler = sWtfHandler;
			sWtfHandler = handler;
			return oldHandler;
		}

		/// <summary>Handy function to get a loggable stack trace from a Throwable</summary>
		/// <param name="tr">An exception to log</param>
		public static string getStackTraceString(System.Exception tr)
		{
			if (tr == null)
			{
				return string.Empty;
			}
			// This is to reduce the amount of log spew that apps do in the non-error
			// condition of the network being unavailable.
			System.Exception t = tr;
			while (t != null)
			{
				if (t is java.net.UnknownHostException)
				{
					return string.Empty;
				}
				t = t.InnerException;
			}
			java.io.StringWriter sw = new java.io.StringWriter();
			java.io.PrintWriter pw = new java.io.PrintWriter(sw);
			XobotOS.Runtime.Util.PrintStackTrace(tr, pw);
			return sw.ToString();
		}

		/// <summary>Low-level logging call.</summary>
		/// <remarks>Low-level logging call.</remarks>
		/// <param name="priority">The priority/type of this log message</param>
		/// <param name="tag">
		/// Used to identify the source of a log message.  It usually identifies
		/// the class or activity where the log call occurs.
		/// </param>
		/// <param name="msg">The message you would like logged.</param>
		/// <returns>The number of bytes written.</returns>
		public static int println(int priority, string tag, string msg)
		{
			return println_native(LOG_ID_MAIN, priority, tag, msg);
		}

		/// <hide></hide>
		public const int LOG_ID_MAIN = 0;

		/// <hide></hide>
		public const int LOG_ID_RADIO = 1;

		/// <hide></hide>
		public const int LOG_ID_EVENTS = 2;

		/// <hide></hide>
		public const int LOG_ID_SYSTEM = 3;
	}
}
