using Sharpen;

namespace java.io
{
	/// <summary>
	/// A specialized
	/// <see cref="InputStream">InputStream</see>
	/// that reads bytes from a
	/// <code>String</code>
	/// in
	/// a sequential manner.
	/// </summary>
	[Sharpen.Sharpened]
	[System.ObsoleteAttribute(@"Use StringReader")]
	public class StringBufferInputStream : java.io.InputStream
	{
		/// <summary>The source string containing the data to read.</summary>
		/// <remarks>The source string containing the data to read.</remarks>
		protected internal string buffer;

		/// <summary>The total number of characters in the source string.</summary>
		/// <remarks>The total number of characters in the source string.</remarks>
		protected internal int count;

		/// <summary>The current position within the source string.</summary>
		/// <remarks>The current position within the source string.</remarks>
		protected internal int pos;

		/// <summary>
		/// Construct a new
		/// <code>StringBufferInputStream</code>
		/// with
		/// <code>str</code>
		/// as
		/// source. The size of the stream is set to the
		/// <code>length()</code>
		/// of the
		/// string.
		/// </summary>
		/// <param name="str">the source string for this stream.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>str</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public StringBufferInputStream(string str)
		{
			if (str == null)
			{
				throw new System.ArgumentNullException();
			}
			buffer = str;
			count = str.Length;
		}

		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int available()
		{
			lock (this)
			{
				return count - pos;
			}
		}

		/// <summary>
		/// Reads a single byte from the source string and returns it as an integer
		/// in the range from 0 to 255.
		/// </summary>
		/// <remarks>
		/// Reads a single byte from the source string and returns it as an integer
		/// in the range from 0 to 255. Returns -1 if the end of the source string
		/// has been reached.
		/// </remarks>
		/// <returns>
		/// the byte read or -1 if the end of the source string has been
		/// reached.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read()
		{
			lock (this)
			{
				return pos < count ? buffer[pos++] & unchecked((int)(0xFF)) : -1;
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>length</code>
		/// bytes from the source string and stores them
		/// in the byte array
		/// <code>b</code>
		/// starting at
		/// <code>offset</code>
		/// .
		/// </summary>
		/// <param name="buffer">the byte array in which to store the bytes read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>b</code>
		/// to store the bytes read from
		/// this stream.
		/// </param>
		/// <param name="length">
		/// the maximum number of bytes to store in
		/// <code>b</code>
		/// .
		/// </param>
		/// <returns>
		/// the number of bytes actually read or -1 if the end of the source
		/// string has been reached.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>length &lt; 0</code>
		/// , or if
		/// <code>offset + length</code>
		/// is greater than the length of
		/// <code>b</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>b</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read(byte[] buffer, int offset, int length)
		{
			lock (this)
			{
				if (buffer == null)
				{
					throw new System.ArgumentNullException("buffer == null");
				}
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
				if (length == 0)
				{
					return 0;
				}
				int copylen = count - pos < length ? count - pos : length;
				{
					for (int i = 0; i < copylen; i++)
					{
						buffer[offset + i] = unchecked((byte)this.buffer[pos + i]);
					}
				}
				pos += copylen;
				return copylen;
			}
		}

		/// <summary>Resets this stream to the beginning of the source string.</summary>
		/// <remarks>Resets this stream to the beginning of the source string.</remarks>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void reset()
		{
			lock (this)
			{
				pos = 0;
			}
		}

		/// <summary>
		/// Skips
		/// <code>charCount</code>
		/// characters in the source string. It does nothing and
		/// returns 0 if
		/// <code>charCount</code>
		/// is negative. Less than
		/// <code>charCount</code>
		/// characters are
		/// skipped if the end of the source string is reached before the operation
		/// completes.
		/// </summary>
		/// <returns>the number of characters actually skipped.</returns>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override long skip(long charCount)
		{
			lock (this)
			{
				if (charCount <= 0)
				{
					return 0;
				}
				int numskipped;
				if (this.count - pos < charCount)
				{
					numskipped = this.count - pos;
					pos = this.count;
				}
				else
				{
					numskipped = (int)charCount;
					pos += (int)(charCount);
				}
				return numskipped;
			}
		}
	}
}
