using Sharpen;
using System;

namespace android.os
{
	/// <summary>Gives access to the system properties store.</summary>
	/// <remarks>
	/// Gives access to the system properties store.  The system properties
	/// store contains a list of string key-value pairs.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public class SystemProperties
	{
		public const int PROP_NAME_MAX = 31;
		public const int PROP_VALUE_MAX = 91;

		/// <summary>Get the value for the given key.</summary>
		/// <remarks>Get the value for the given key.</remarks>
		/// <returns>an empty string if the key isn't found</returns>
		/// <exception cref="System.ArgumentException">if the key exceeds 32 characters</exception>
		[Sharpen.Stub]
		public static string get (string key)
		{
			if (key.Length > PROP_NAME_MAX) {
				throw new ArgumentException ("key.length > " + PROP_NAME_MAX);
			}
			return string.Empty;
		}

		/// <summary>Get the value for the given key.</summary>
		/// <remarks>Get the value for the given key.</remarks>
		/// <returns>if the key isn't found, return def if it isn't null, or an empty string otherwise
		/// 	</returns>
		/// <exception cref="System.ArgumentException">if the key exceeds 32 characters</exception>
		[Sharpen.Stub]
		public static string get (string key, string def)
		{
			if (key.Length > PROP_NAME_MAX) {
				throw new ArgumentException ("key.length > " + PROP_NAME_MAX);
			}
			return def;
		}

		/// <summary>Get the value for the given key, and return as an integer.</summary>
		/// <remarks>Get the value for the given key, and return as an integer.</remarks>
		/// <param name="key">the key to lookup</param>
		/// <param name="def">a default value to return</param>
		/// <returns>
		/// the key parsed as an integer, or def if the key isn't found or
		/// cannot be parsed
		/// </returns>
		/// <exception cref="System.ArgumentException">if the key exceeds 32 characters</exception>
		[Sharpen.Stub]
		public static int getInt (string key, int def)
		{
			if (key.Length > PROP_NAME_MAX) {
				throw new ArgumentException ("key.length > " + PROP_NAME_MAX);
			}
			return def;
		}

		/// <summary>Get the value for the given key, and return as a long.</summary>
		/// <remarks>Get the value for the given key, and return as a long.</remarks>
		/// <param name="key">the key to lookup</param>
		/// <param name="def">a default value to return</param>
		/// <returns>
		/// the key parsed as a long, or def if the key isn't found or
		/// cannot be parsed
		/// </returns>
		/// <exception cref="System.ArgumentException">if the key exceeds 32 characters</exception>
		[Sharpen.Stub]
		public static long getLong (string key, long def)
		{
			if (key.Length > PROP_NAME_MAX) {
				throw new ArgumentException ("key.length > " + PROP_NAME_MAX);
			}
			return def;
		}

		/// <summary>Get the value for the given key, returned as a boolean.</summary>
		/// <remarks>
		/// Get the value for the given key, returned as a boolean.
		/// Values 'n', 'no', '0', 'false' or 'off' are considered false.
		/// Values 'y', 'yes', '1', 'true' or 'on' are considered true.
		/// (case sensitive).
		/// If the key does not exist, or has any other value, then the default
		/// result is returned.
		/// </remarks>
		/// <param name="key">the key to lookup</param>
		/// <param name="def">a default value to return</param>
		/// <returns>
		/// the key parsed as a boolean, or def if the key isn't found or is
		/// not able to be parsed as a boolean.
		/// </returns>
		/// <exception cref="System.ArgumentException">if the key exceeds 32 characters</exception>
		[Sharpen.Stub]
		public static bool getBoolean (string key, bool def)
		{
			if (key.Length > PROP_NAME_MAX) {
				throw new ArgumentException ("key.length > " + PROP_NAME_MAX);
			}
			return def;
		}

		/// <summary>Set the value for the given key.</summary>
		/// <remarks>Set the value for the given key.</remarks>
		/// <exception cref="System.ArgumentException">if the key exceeds 32 characters</exception>
		/// <exception cref="System.ArgumentException">if the value exceeds 92 characters</exception>
		[Sharpen.Stub]
		public static void set (string key, string val)
		{
			if (key.Length > PROP_NAME_MAX) {
				throw new ArgumentException ("key.length > " + PROP_NAME_MAX);
			}
			if (val != null && val.Length > PROP_VALUE_MAX) {
				throw new ArgumentException ("val.length > " + PROP_VALUE_MAX);
			}
			throw new NotImplementedException ();
		}
	}
}
