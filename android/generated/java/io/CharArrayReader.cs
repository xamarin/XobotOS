using Sharpen;

namespace java.io
{
	/// <summary>
	/// A specialized
	/// <see cref="Reader">Reader</see>
	/// for reading the contents of a char array.
	/// </summary>
	/// <seealso cref="CharArrayWriter">CharArrayWriter</seealso>
	[Sharpen.Sharpened]
	public class CharArrayReader : java.io.Reader
	{
		/// <summary>The buffer for characters.</summary>
		/// <remarks>The buffer for characters.</remarks>
		protected internal char[] buf;

		/// <summary>The current buffer position.</summary>
		/// <remarks>The current buffer position.</remarks>
		protected internal int pos;

		/// <summary>The current mark position.</summary>
		/// <remarks>The current mark position.</remarks>
		protected internal int markedPos = -1;

		/// <summary>The ending index of the buffer.</summary>
		/// <remarks>The ending index of the buffer.</remarks>
		protected internal int count;

		/// <summary>
		/// Constructs a CharArrayReader on the char array
		/// <code>buf</code>
		/// . The size of
		/// the reader is set to the length of the buffer and the object to to read
		/// from is set to
		/// <code>buf</code>
		/// .
		/// </summary>
		/// <param name="buf">the char array from which to read.</param>
		public CharArrayReader(char[] buf)
		{
			this.buf = buf;
			this.count = buf.Length;
		}

		/// <summary>
		/// Constructs a CharArrayReader on the char array
		/// <code>buf</code>
		/// . The size of
		/// the reader is set to
		/// <code>length</code>
		/// and the start position from which to
		/// read the buffer is set to
		/// <code>offset</code>
		/// .
		/// </summary>
		/// <param name="buf">the char array from which to read.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>buf</code>
		/// to read.
		/// </param>
		/// <param name="length">
		/// the number of characters that can be read from
		/// <code>buf</code>
		/// .
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>length &lt; 0</code>
		/// , or if
		/// <code>offset</code>
		/// is greater than the size of
		/// <code>buf</code>
		/// .
		/// </exception>
		public CharArrayReader(char[] buf, int offset, int length)
		{
			if (offset < 0 || offset > buf.Length || length < 0 || offset + length < 0)
			{
				throw new System.ArgumentException();
			}
			this.buf = buf;
			this.pos = offset;
			this.markedPos = offset;
			int bufferLength = buf.Length;
			this.count = offset + length < bufferLength ? length : bufferLength;
		}

		/// <summary>This method closes this CharArrayReader.</summary>
		/// <remarks>
		/// This method closes this CharArrayReader. Once it is closed, you can no
		/// longer read from it. Only the first invocation of this method has any
		/// effect.
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void close()
		{
			lock (@lock)
			{
				if (isOpen())
				{
					buf = null;
				}
			}
		}

		/// <summary>Indicates whether this reader is open.</summary>
		/// <remarks>Indicates whether this reader is open.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the reader is open,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		private bool isOpen()
		{
			return buf != null;
		}

		/// <summary>Indicates whether this reader is closed.</summary>
		/// <remarks>Indicates whether this reader is closed.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the reader is closed,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		private bool isClosed()
		{
			return buf == null;
		}

		/// <summary>Sets a mark position in this reader.</summary>
		/// <remarks>
		/// Sets a mark position in this reader. The parameter
		/// <code>readLimit</code>
		/// is
		/// ignored for CharArrayReaders. Calling
		/// <code>reset()</code>
		/// will reposition the
		/// reader back to the marked position provided the mark has not been
		/// invalidated.
		/// </remarks>
		/// <param name="readLimit">ignored for CharArrayReaders.</param>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void mark(int readLimit)
		{
			lock (@lock)
			{
				checkNotClosed();
				markedPos = pos;
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void checkNotClosed()
		{
			if (isClosed())
			{
				throw new System.IO.IOException("CharArrayReader is closed");
			}
		}

		/// <summary>
		/// Indicates whether this reader supports the
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// methods.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// for CharArrayReader.
		/// </returns>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool markSupported()
		{
			return true;
		}

		/// <summary>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0.
		/// </summary>
		/// <remarks>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0. Returns -1 if no more
		/// characters are available from this reader.
		/// </remarks>
		/// <returns>
		/// the character read as an int or -1 if the end of the reader has
		/// been reached.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read()
		{
			lock (@lock)
			{
				checkNotClosed();
				if (pos == count)
				{
					return -1;
				}
				return buf[pos++];
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>count</code>
		/// characters from this CharArrayReader and
		/// stores them at
		/// <code>offset</code>
		/// in the character array
		/// <code>buf</code>
		/// .
		/// Returns the number of characters actually read or -1 if the end of reader
		/// was encountered.
		/// </summary>
		/// <param name="buffer">the character array to store the characters read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the characters
		/// read from this reader.
		/// </param>
		/// <param name="len">the maximum number of characters to read.</param>
		/// <returns>
		/// number of characters read or -1 if the end of the reader has been
		/// reached.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>len &lt; 0</code>
		/// , or if
		/// <code>offset + len</code>
		/// is bigger than the size of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read(char[] buffer, int offset, int len)
		{
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, len);
			lock (@lock)
			{
				checkNotClosed();
				if (pos < this.count)
				{
					int bytesRead = pos + len > this.count ? this.count - pos : len;
					System.Array.Copy(this.buf, pos, buffer, offset, bytesRead);
					pos += bytesRead;
					return bytesRead;
				}
				return -1;
			}
		}

		/// <summary>Indicates whether this reader is ready to be read without blocking.</summary>
		/// <remarks>
		/// Indicates whether this reader is ready to be read without blocking.
		/// Returns
		/// <code>true</code>
		/// if the next
		/// <code>read</code>
		/// will not block. Returns
		/// <code>false</code>
		/// if this reader may or may not block when
		/// <code>read</code>
		/// is
		/// called. The implementation in CharArrayReader always returns
		/// <code>true</code>
		/// even when it has been closed.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this reader will not block when
		/// <code>read</code>
		/// is
		/// called,
		/// <code>false</code>
		/// if unknown or blocking will occur.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool ready()
		{
			lock (@lock)
			{
				checkNotClosed();
				return pos != count;
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
		/// beginning of the string.
		/// </summary>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void reset()
		{
			lock (@lock)
			{
				checkNotClosed();
				pos = markedPos != -1 ? markedPos : 0;
			}
		}

		/// <summary>
		/// Skips
		/// <code>charCount</code>
		/// characters in this reader. Subsequent calls to
		/// <code>read</code>
		/// will not return these characters unless
		/// <code>reset</code>
		/// is used. This method does nothing and returns 0 if
		/// <code>charCount &lt;= 0</code>
		/// .
		/// </summary>
		/// <returns>the number of characters actually skipped.</returns>
		/// <exception cref="IOException">if this reader is closed.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override long skip(long charCount)
		{
			lock (@lock)
			{
				checkNotClosed();
				if (charCount <= 0)
				{
					return 0;
				}
				long skipped = 0;
				if (charCount < this.count - pos)
				{
					pos = pos + (int)charCount;
					skipped = charCount;
				}
				else
				{
					skipped = this.count - pos;
					pos = this.count;
				}
				return skipped;
			}
		}
	}
}
