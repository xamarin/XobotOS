using System;
using XobotOS.IO;
using android.util;
using java.nio.charset;
using java.util.regex;

namespace XobotOS.Runtime
{
	public static class Util
	{
		public static void PrintStackTrace (Exception e)
		{
			Console.Error.WriteLine (e.StackTrace);
		}

		public static void PrintStackTrace (Exception e, java.io.PrintWriter pw)
		{
			pw.println (e.StackTrace);
		}

		public static void FatalError (string tag, Exception e)
		{
			Console.Error.WriteLine ("FATAL ERROR ({0}):\n{1}", tag, e);
			Environment.Exit (-1);
		}

		internal static void FillInStackTrace (java.lang.RuntimeException e)
		{
			; // Do nothing
		}

		public static void SetStackTrace (java.lang.RuntimeException e, object o)
		{
			throw new NotImplementedException ();
		}

		#region Strings and Charsets

		public static string GetStringForBytes (byte[] buffer, Charset charset)
		{
			return GetStringForBytes (buffer, 0, buffer.Length, charset);
		}

		public static string GetStringForBytes (byte[] buffer, int offset, int count, Charset charset)
		{
			MonoCharset mono_set = (MonoCharset)charset;
			return mono_set.Encoding.GetString (buffer, offset, count);
		}

		public static byte[] GetBytesForString (string str, Charset charset)
		{
			MonoCharset mono_set = (MonoCharset)charset;
			return mono_set.Encoding.GetBytes (str);
		}

		public static string[] SplitStringRegex (string str, string expression)
		{
			return SplitStringRegex (str, expression, 0);
		}

		public static string[] SplitStringRegex (string str, string expression, int limit)
		{
			string[] result = Splitter.fastSplit (expression, str, limit);
			if (result != null)
				return result;
			java.lang.CharSequence csq = java.lang.CharSequenceProxy.Wrap (str);
			return Pattern.compile (expression).split (csq, limit);
		}

		#endregion

		internal static void LogI (string message, Exception ex)
		{
			Log.i ("XobotOS Runtime", message, ex);
		}

		internal static void LogI (string message)
		{
			Log.i ("XobotOS Runtime", message);
		}

		internal static void LogW (string message, Exception ex)
		{
			Log.w ("XobotOS Runtime", message, ex);
		}

		internal static void LogW (string message)
		{
			Log.w ("XobotOS Runtime", message);
		}

		internal static void LogE (string message, Exception ex)
		{
			Log.e ("XobotOS Runtime", message, ex);
		}

		internal static void LogE (string message)
		{
			Log.e ("XobotOS Runtime", message);
		}
	}
}
