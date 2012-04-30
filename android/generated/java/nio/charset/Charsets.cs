using Sharpen;

namespace java.nio.charset
{
	/// <summary>Provides convenient access to the most important built-in charsets.</summary>
	/// <remarks>
	/// Provides convenient access to the most important built-in charsets. Saves a hash lookup and
	/// unnecessary handling of UnsupportedEncodingException at call sites, compared to using the
	/// charset's name.
	/// Also various special-case charset conversions (for performance).
	/// </remarks>
	/// <hide>internal use only</hide>
	[Sharpen.Sharpened]
	public class Charsets
	{
		/// <summary>A cheap and type-safe constant for the ISO-8859-1 Charset.</summary>
		/// <remarks>A cheap and type-safe constant for the ISO-8859-1 Charset.</remarks>
		public static readonly java.nio.charset.Charset ISO_8859_1 = java.nio.charset.Charset
			.forName("ISO-8859-1");

		/// <summary>A cheap and type-safe constant for the US-ASCII Charset.</summary>
		/// <remarks>A cheap and type-safe constant for the US-ASCII Charset.</remarks>
		public static readonly java.nio.charset.Charset US_ASCII = java.nio.charset.Charset
			.forName("US-ASCII");

		/// <summary>A cheap and type-safe constant for the UTF-8 Charset.</summary>
		/// <remarks>A cheap and type-safe constant for the UTF-8 Charset.</remarks>
		public static readonly java.nio.charset.Charset UTF_8 = java.nio.charset.Charset.
			forName("UTF-8");

		/// <summary>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in US-ASCII.
		/// </summary>
		/// <remarks>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in US-ASCII. Unrepresentable characters are replaced by (byte) '?'.
		/// </remarks>
		[Sharpen.NativeStub]
		public static byte[] toAsciiBytes(char[] chars, int offset, int length)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in ISO-8859-1.
		/// </summary>
		/// <remarks>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in ISO-8859-1. Unrepresentable characters are replaced by (byte) '?'.
		/// </remarks>
		[Sharpen.NativeStub]
		public static byte[] toIsoLatin1Bytes(char[] chars, int offset, int length)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in UTF-8.
		/// </summary>
		/// <remarks>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in UTF-8. All characters are representable in UTF-8.
		/// </remarks>
		[Sharpen.NativeStub]
		public static byte[] toUtf8Bytes(char[] chars, int offset, int length)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in UTF-16BE.
		/// </summary>
		/// <remarks>
		/// Returns a new byte array containing the bytes corresponding to the given characters,
		/// encoded in UTF-16BE. All characters are representable in UTF-16BE.
		/// </remarks>
		public static byte[] toBigEndianUtf16Bytes(char[] chars, int offset, int length)
		{
			byte[] result = new byte[length * 2];
			int end = offset + length;
			int resultIndex = 0;
			{
				for (int i = offset; i < end; ++i)
				{
					char ch = chars[i];
					result[resultIndex++] = unchecked((byte)(ch >> 8));
					result[resultIndex++] = unchecked((byte)ch);
				}
			}
			return result;
		}

		/// <summary>Decodes the given US-ASCII bytes into the given char[].</summary>
		/// <remarks>
		/// Decodes the given US-ASCII bytes into the given char[]. Equivalent to but faster than:
		/// for (int i = 0; i &lt; count; ++i) {
		/// char ch = (char) (data[start++] & 0xff);
		/// value[i] = (ch &lt;= 0x7f) ? ch : REPLACEMENT_CHAR;
		/// }
		/// </remarks>
		[Sharpen.NativeStub]
		public static void asciiBytesToChars(byte[] bytes, int offset, int length, char[]
			 chars)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Decodes the given ISO-8859-1 bytes into the given char[].</summary>
		/// <remarks>
		/// Decodes the given ISO-8859-1 bytes into the given char[]. Equivalent to but faster than:
		/// for (int i = 0; i &lt; count; ++i) {
		/// value[i] = (char) (data[start++] & 0xff);
		/// }
		/// </remarks>
		[Sharpen.NativeStub]
		public static void isoLatin1BytesToChars(byte[] bytes, int offset, int length, char
			[] chars)
		{
			throw new System.NotImplementedException();
		}

		private Charsets()
		{
		}
	}
}
