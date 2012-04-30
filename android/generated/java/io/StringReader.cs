using Sharpen;

namespace java.io
{
	/// <summary>
	/// A specialized
	/// <see cref="Reader">Reader</see>
	/// that reads characters from a
	/// <code>String</code>
	/// in
	/// a sequential manner.
	/// </summary>
	/// <seealso cref="StringWriter">StringWriter</seealso>
	[Sharpen.Sharpened]
	public class StringReader : java.io.Reader
	{
		private string str;

		private int markpos = -1;

		private int pos;

		private int count;

		/// <summary>
		/// Construct a new
		/// <code>StringReader</code>
		/// with
		/// <code>str</code>
		/// as source. The size
		/// of the reader is set to the
		/// <code>length()</code>
		/// of the string and the Object
		/// to synchronize access through is set to
		/// <code>str</code>
		/// .
		/// </summary>
		/// <param name="str">the source string for this reader.</param>
		public StringReader(string str)
		{
			this.str = str;
			this.count = str.Length;
		}

		/// <summary>Closes this reader.</summary>
		/// <remarks>
		/// Closes this reader. Once it is closed, read operations on this reader
		/// will throw an
		/// <code>IOException</code>
		/// . Only the first invocation of this
		/// method has any effect.
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void close()
		{
			str = null;
		}

		/// <summary>Returns a boolean indicating whether this reader is closed.</summary>
		/// <remarks>Returns a boolean indicating whether this reader is closed.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if closed, otherwise
		/// <code>false</code>
		/// .
		/// </returns>
		private bool isClosed()
		{
			return str == null;
		}

		/// <summary>Sets a mark position in this reader.</summary>
		/// <remarks>
		/// Sets a mark position in this reader. The parameter
		/// <code>readLimit</code>
		/// is
		/// ignored for this class. Calling
		/// <code>reset()</code>
		/// will reposition the
		/// reader back to the marked position.
		/// </remarks>
		/// <param name="readLimit">
		/// ignored for
		/// <code>StringReader</code>
		/// instances.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>readLimit &lt; 0</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void mark(int readLimit)
		{
			if (readLimit < 0)
			{
				throw new System.ArgumentException();
			}
			lock (@lock)
			{
				checkNotClosed();
				markpos = pos;
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void checkNotClosed()
		{
			if (isClosed())
			{
				throw new System.IO.IOException("StringReader is closed");
			}
		}

		/// <summary>
		/// Indicates whether this reader supports the
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// methods. This implementation returns
		/// <code>true</code>
		/// .
		/// </summary>
		/// <returns>
		/// always
		/// <code>true</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool markSupported()
		{
			return true;
		}

		/// <summary>
		/// Reads a single character from the source string and returns it as an
		/// integer with the two higher-order bytes set to 0.
		/// </summary>
		/// <remarks>
		/// Reads a single character from the source string and returns it as an
		/// integer with the two higher-order bytes set to 0. Returns -1 if the end
		/// of the source string has been reached.
		/// </remarks>
		/// <returns>
		/// the character read or -1 if the end of the source string has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read()
		{
			lock (@lock)
			{
				checkNotClosed();
				if (pos != count)
				{
					return str[pos++];
				}
				return -1;
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>len</code>
		/// characters from the source string and stores
		/// them at
		/// <code>offset</code>
		/// in the character array
		/// <code>buf</code>
		/// . Returns the
		/// number of characters actually read or -1 if the end of the source string
		/// has been reached.
		/// </summary>
		/// <param name="buf">the character array to store the characters read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the characters
		/// read from this reader.
		/// </param>
		/// <param name="len">the maximum number of characters to read.</param>
		/// <returns>
		/// the number of characters read or -1 if the end of the reader has
		/// been reached.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>len &lt; 0</code>
		/// , or if
		/// <code>offset + len</code>
		/// is greater than the size of
		/// <code>buf</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read(char[] buf, int offset, int len)
		{
			lock (@lock)
			{
				checkNotClosed();
				java.util.Arrays.checkOffsetAndCount(buf.Length, offset, len);
				if (len == 0)
				{
					return 0;
				}
				if (pos == this.count)
				{
					return -1;
				}
				int end = pos + len > this.count ? this.count : pos + len;
				Sharpen.StringHelper.GetCharsForString(str, pos, end, buf, offset);
				int read_1 = end - pos;
				pos = end;
				return read_1;
			}
		}

		/// <summary>Indicates whether this reader is ready to be read without blocking.</summary>
		/// <remarks>
		/// Indicates whether this reader is ready to be read without blocking. This
		/// implementation always returns
		/// <code>true</code>
		/// .
		/// </remarks>
		/// <returns>
		/// always
		/// <code>true</code>
		/// .
		/// </returns>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <seealso cref="read()">read()</seealso>
		/// <seealso cref="read(char[], int, int)">read(char[], int, int)</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool ready()
		{
			lock (@lock)
			{
				checkNotClosed();
				return true;
			}
		}

		/// <summary>
		/// Resets this reader's position to the last
		/// <code>mark()</code>
		/// location.
		/// Invocations of
		/// <code>read()</code>
		/// and
		/// <code>skip()</code>
		/// will occur from this new
		/// location. If this reader has not been marked, it is reset to the
		/// beginning of the source string.
		/// </summary>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void reset()
		{
			lock (@lock)
			{
				checkNotClosed();
				pos = markpos != -1 ? markpos : 0;
			}
		}

		/// <summary>
		/// Moves
		/// <code>charCount</code>
		/// characters in the source string. Unlike the
		/// <see cref="Reader.skip(long)">overridden method</see>
		/// , this method may skip negative skip
		/// distances: this rewinds the input so that characters may be read again.
		/// When the end of the source string has been reached, the input cannot be
		/// rewound.
		/// </summary>
		/// <param name="charCount">
		/// the maximum number of characters to skip. Positive values skip
		/// forward; negative values skip backward.
		/// </param>
		/// <returns>
		/// the number of characters actually skipped. This is bounded below
		/// by the number of characters already read and above by the
		/// number of characters remaining:<br />
		/// <code>
		/// -(num chars already
		/// read) &lt;= distance skipped &lt;= num chars remaining
		/// </code>
		/// .
		/// </returns>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override long skip(long charCount)
		{
			lock (@lock)
			{
				checkNotClosed();
				int minSkip = -pos;
				int maxSkip = count - pos;
				if (maxSkip == 0 || charCount > maxSkip)
				{
					charCount = maxSkip;
				}
				else
				{
					// no rewinding if we're at the end
					if (charCount < minSkip)
					{
						charCount = minSkip;
					}
				}
				pos += (int)(charCount);
				return charCount;
			}
		}
	}
}
