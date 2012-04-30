using System;
using System.Text;

namespace Sharpen
{
	public static class StringHelper
	{
		public static string Substring (string str, int beginIndex)
		{
			return str.Substring (beginIndex);
		}
		
		public static string Substring (string str, int beginIndex, int endIndex)
		{
			return str.Substring (beginIndex, endIndex - beginIndex);
		}
		
		public static bool EqualsIgnoreCase (string a, string b)
		{
			throw new NotImplementedException ();
		}

		public static void GetCharsForString (string str, int start, int end, char[] buffer, int index)
		{
			Array.Copy (str.ToCharArray (), start, buffer, index, end - start);
		}

		public static string CopyValueOf (char[] backingArray, int offset, int count)
		{
			char[] array = new char[count];
			Array.Copy (backingArray, offset, array, 0, count);
			return new string (array);
		}

		public static byte[] GetBytesForString (string str)
		{
			UTF8Encoding enc = new UTF8Encoding ();
			return enc.GetBytes (str);
		}

		public static byte[] GetBytesForString (string str, string encoding)
		{
			Encoding enc = Encoding.GetEncoding (encoding);
			if (enc == null)
				throw new ArgumentException ("Invalid encoding '" + encoding + "'");
			return enc.GetBytes (str);
		}

		public static string GetStringForBytes (byte[] buffer)
		{
			return GetStringForBytes (buffer, 0, buffer.Length);
		}

		public static string GetStringForBytes (byte[] buffer, int offset, int count)
		{
			return GetStringForBytes (buffer, offset, count, new UTF8Encoding ());
		}

		public static string GetStringForBytes (byte[] buffer, int offset, int count, string charset)
		{
			Encoding enc = Encoding.GetEncoding (charset);
			if (enc == null)
				throw new ArgumentException ("Invalid encoding '" + charset + "'");
			return GetStringForBytes (buffer, offset, count, enc);
		}

		static string GetStringForBytes (byte[] buffer, int offset, int count, Encoding enc)
		{
			return enc.GetString (buffer, offset, count);
		}

		public static string GetValueOf (object obj)
		{
			return obj != null ? obj.ToString () : "null";
		}

		public static string GetString (int offset, int count, char[] buffer)
		{
			return new string (buffer, offset, count);
		}

		public static bool RegionMatches (string @this, int thisStart, string @string, int start, int length)
		{
			if (@string == null)
				throw new System.NullReferenceException ();
			if (start < 0 || @string.Length - start < length)
				return false;
			if (thisStart < 0 || @this.Length - thisStart < length)
				return false;
			if (length <= 0)
				return true;
			char[] value1 = @this.ToCharArray ();
			char[] value2 = @string.ToCharArray ();
			for (int i = 0; i < length; ++i) {
				if (value1 [thisStart + i] != value2 [start + i])
					return false;
			}
			return true;
		}

		public static bool StartsWith (string str, string prefix, int start)
		{
			return RegionMatches (str, start, prefix, 0, prefix.Length);
		}

		public static int CompareToIgnoreCase (string str1, string str2)
		{
			return str1.ToLower ().CompareTo (str2.ToLower ());
		}
	}
}

