using System;
using System.Collections.Generic;

namespace android.util
{
	partial class Log
	{
		#region XobotOS API additions

		static Dictionary<string,int> log_levels = new Dictionary<string, int> ();

		public static void SetLogLevel (string tag, int level)
		{
			log_levels [tag] = level;
		}

		public static int GetLogLevel (string tag)
		{
			if (log_levels.ContainsKey (tag))
				return log_levels [tag];

			return INFO;
		}

		#endregion

		/// <summary>Checks to see whether or not a log for the specified tag is loggable at the specified level.
		/// 	</summary>
		/// <remarks>
		/// Checks to see whether or not a log for the specified tag is loggable at the specified level.
		/// The default level of any tag is set to INFO. This means that any level above and including
		/// INFO will be logged. Before you make any calls to a logging method you should check to see
		/// if your tag should be logged. You can change the default level by setting a system property:
		/// 'setprop log.tag.&lt;YOUR_LOG_TAG&gt; &lt;LEVEL&gt;'
		/// Where level is either VERBOSE, DEBUG, INFO, WARN, ERROR, ASSERT, or SUPPRESS. SUPPRESS will
		/// turn off all logging for your tag. You can also create a local.prop file that with the
		/// following in it:
		/// 'log.tag.&lt;YOUR_LOG_TAG&gt;=&lt;LEVEL&gt;'
		/// and place that in /data/local.prop.
		/// </remarks>
		/// <param name="tag">The tag to check.</param>
		/// <param name="level">The level to check.</param>
		/// <returns>Whether or not that this is allowed to be logged.</returns>
		/// <exception cref="System.ArgumentException">is thrown if the tag.length() &gt; 23.
		/// 	</exception>
		public static bool isLoggable (string tag, int level)
		{
			return level >= GetLogLevel (tag);
		}

		public static int println_native (int bufID, int priority, string tag, string msg)
		{
			DateTime now = DateTime.Now;
			string buf_name = GetBufName (bufID);
			string output = String.Format ("[{0:u}:{1}:{2}] {3}", now, buf_name, tag, msg);
			Console.Error.WriteLine (output);
			return output.Length;
		}

		private static string GetBufName (int bufID)
		{
			switch (bufID) {
			case LOG_ID_MAIN:
				return "MAIN";
			case LOG_ID_RADIO:
				return "RADIO";
			case LOG_ID_EVENTS:
				return "EVENTS";
			case LOG_ID_SYSTEM:
				return "SYSTEM";
			default:
				return "UNKNOWN";
			}
		}
	}
}
