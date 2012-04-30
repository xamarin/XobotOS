using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="Reader">Reader</see>
	/// and adds functionality to "push back"
	/// characters that have been read, so that they can be read again. Parsers may
	/// find this useful. The number of characters which may be pushed back can be
	/// specified during construction. If the buffer of pushed back bytes is empty,
	/// characters are read from the underlying reader.
	/// </summary>
	[Sharpen.Sharpened]
	public class PushbackReader : java.io.FilterReader
	{
		/// <summary>
		/// The
		/// <code>char</code>
		/// array containing the chars to read.
		/// </summary>
		internal char[] buf;

		/// <summary>
		/// The current position within the char array
		/// <code>buf</code>
		/// . A value
		/// equal to buf.length indicates no chars available. A value of 0 indicates
		/// the buffer is full.
		/// </summary>
		internal int pos;

		/// <summary>
		/// Constructs a new
		/// <code>PushbackReader</code>
		/// with the specified reader as
		/// source. The size of the pushback buffer is set to the default value of 1
		/// character.
		/// </summary>
		/// <param name="in">the source reader.</param>
		public PushbackReader(java.io.Reader @in) : base(@in)
		{
			buf = new char[1];
			pos = 1;
		}

		/// <summary>
		/// Constructs a new
		/// <code>PushbackReader</code>
		/// with
		/// <code>in</code>
		/// as source reader.
		/// The size of the pushback buffer is set to
		/// <code>size</code>
		/// .
		/// </summary>
		/// <param name="in">the source reader.</param>
		/// <param name="size">the size of the pushback buffer.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>size</code>
		/// is negative.
		/// </exception>
		public PushbackReader(java.io.Reader @in, int size) : base(@in)
		{
			if (size <= 0)
			{
				throw new System.ArgumentException("size <= 0");
			}
			buf = new char[size];
			pos = size;
		}

		/// <summary>Closes this reader.</summary>
		/// <remarks>
		/// Closes this reader. This implementation closes the source reader
		/// and releases the pushback buffer.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this reader.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void close()
		{
			lock (@lock)
			{
				buf = null;
				@in.close();
			}
		}

		/// <summary>Marks the current position in this stream.</summary>
		/// <remarks>
		/// Marks the current position in this stream. Setting a mark is not
		/// supported in this class; this implementation always throws an
		/// <code>IOException</code>
		/// .
		/// </remarks>
		/// <param name="readAheadLimit">
		/// the number of character that can be read from this reader
		/// before the mark is invalidated; this parameter is ignored.
		/// </param>
		/// <exception cref="IOException">if this method is called.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void mark(int readAheadLimit)
		{
			throw new System.IO.IOException("mark/reset not supported");
		}

		/// <summary>
		/// Indicates whether this reader supports the
		/// <code>mark(int)</code>
		/// and
		/// <code>reset()</code>
		/// methods.
		/// <code>PushbackReader</code>
		/// does not support them, so
		/// it returns
		/// <code>false</code>
		/// .
		/// </summary>
		/// <returns>
		/// always
		/// <code>false</code>
		/// .
		/// </returns>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool markSupported()
		{
			return false;
		}

		/// <summary>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0.
		/// </summary>
		/// <remarks>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0. Returns -1 if the end of the
		/// reader has been reached. If the pushback buffer does not contain any
		/// available characters then a character from the source reader is returned.
		/// Blocks until one character has been read, the end of the source reader is
		/// detected or an exception is thrown.
		/// </remarks>
		/// <returns>
		/// the character read or -1 if the end of the source reader has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">
		/// if this reader is closed or an I/O error occurs while reading
		/// from this reader.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read()
		{
			lock (@lock)
			{
				checkNotClosed();
				if (pos < buf.Length)
				{
					return buf[pos++];
				}
				return @in.read();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void checkNotClosed()
		{
			if (buf == null)
			{
				throw new System.IO.IOException("PushbackReader is closed");
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>length</code>
		/// bytes from this reader and stores them in
		/// byte array
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// . Characters are
		/// read from the pushback buffer first, then from the source reader if more
		/// bytes are required. Blocks until
		/// <code>count</code>
		/// characters have been read,
		/// the end of the source reader is detected or an exception is thrown.
		/// </summary>
		/// <param name="buffer">
		/// the array in which to store the characters read from this
		/// reader.
		/// </param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the characters
		/// read from this reader.
		/// </param>
		/// <param name="count">
		/// the maximum number of bytes to store in
		/// <code>buffer</code>
		/// .
		/// </param>
		/// <returns>
		/// the number of bytes read or -1 if the end of the source reader
		/// has been reached.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is greater than the length of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">
		/// if this reader is closed or another I/O error occurs while
		/// reading from this reader.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read(char[] buffer, int offset, int count)
		{
			lock (@lock)
			{
				checkNotClosed();
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, count);
				int copiedChars = 0;
				int copyLength = 0;
				int newOffset = offset;
				if (pos < buf.Length)
				{
					copyLength = (buf.Length - pos >= count) ? count : buf.Length - pos;
					System.Array.Copy(buf, pos, buffer, newOffset, copyLength);
					newOffset += copyLength;
					copiedChars += copyLength;
					pos += copyLength;
				}
				if (copyLength == count)
				{
					return count;
				}
				int inCopied = @in.read(buffer, newOffset, count - copiedChars);
				if (inCopied > 0)
				{
					return inCopied + copiedChars;
				}
				if (copiedChars == 0)
				{
					return inCopied;
				}
				return copiedChars;
			}
		}

		/// <summary>Indicates whether this reader is ready to be read without blocking.</summary>
		/// <remarks>
		/// Indicates whether this reader is ready to be read without blocking.
		/// Returns
		/// <code>true</code>
		/// if this reader will not block when
		/// <code>read</code>
		/// is
		/// called,
		/// <code>false</code>
		/// if unknown or blocking will occur.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the receiver will not block when
		/// <code>read()</code>
		/// is called,
		/// <code>false</code>
		/// if unknown
		/// or blocking will occur.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <seealso cref="read()">read()</seealso>
		/// <seealso cref="read(char[], int, int)">read(char[], int, int)</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool ready()
		{
			lock (@lock)
			{
				if (buf == null)
				{
					throw new System.IO.IOException("Reader is closed");
				}
				return (buf.Length - pos > 0 || @in.ready());
			}
		}

		/// <summary>Resets this reader to the last marked position.</summary>
		/// <remarks>
		/// Resets this reader to the last marked position. Resetting the reader is
		/// not supported in this class; this implementation always throws an
		/// <code>IOException</code>
		/// .
		/// </remarks>
		/// <exception cref="IOException">if this method is called.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void reset()
		{
			throw new System.IO.IOException("mark/reset not supported");
		}

		/// <summary>
		/// Pushes all the characters in
		/// <code>buffer</code>
		/// back to this reader. The
		/// characters are pushed back in such a way that the next character read
		/// from this reader is buffer[0], then buffer[1] and so on.
		/// <p>
		/// If this reader's internal pushback buffer cannot store the entire
		/// contents of
		/// <code>buffer</code>
		/// , an
		/// <code>IOException</code>
		/// is thrown. Parts of
		/// <code>buffer</code>
		/// may have already been copied to the pushback buffer when
		/// the exception is thrown.
		/// </summary>
		/// <param name="buffer">
		/// the buffer containing the characters to push back to this
		/// reader.
		/// </param>
		/// <exception cref="IOException">
		/// if this reader is closed or the free space in the internal
		/// pushback buffer is not sufficient to store the contents of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void unread(char[] buffer)
		{
			unread(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Pushes a subset of the characters in
		/// <code>buffer</code>
		/// back to this reader.
		/// The subset is defined by the start position
		/// <code>offset</code>
		/// within
		/// <code>buffer</code>
		/// and the number of characters specified by
		/// <code>length</code>
		/// .
		/// The bytes are pushed back in such a way that the next byte read from this
		/// stream is
		/// <code>buffer[offset]</code>
		/// , then
		/// <code>buffer[1]</code>
		/// and so on.
		/// <p>
		/// If this stream's internal pushback buffer cannot store the selected
		/// subset of
		/// <code>buffer</code>
		/// , an
		/// <code>IOException</code>
		/// is thrown. Parts of
		/// <code>buffer</code>
		/// may have already been copied to the pushback buffer when
		/// the exception is thrown.
		/// </summary>
		/// <param name="buffer">
		/// the buffer containing the characters to push back to this
		/// reader.
		/// </param>
		/// <param name="offset">
		/// the index of the first byte in
		/// <code>buffer</code>
		/// to push back.
		/// </param>
		/// <param name="length">the number of bytes to push back.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is greater than the length of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">
		/// if this reader is closed or the free space in the internal
		/// pushback buffer is not sufficient to store the selected
		/// contents of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>buffer</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void unread(char[] buffer, int offset, int length)
		{
			lock (@lock)
			{
				checkNotClosed();
				if (length > pos)
				{
					throw new System.IO.IOException("Pushback buffer full");
				}
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
				{
					for (int i = offset + length - 1; i >= offset; i--)
					{
						unread(buffer[i]);
					}
				}
			}
		}

		/// <summary>
		/// Pushes the specified character
		/// <code>oneChar</code>
		/// back to this reader. This
		/// is done in such a way that the next character read from this reader is
		/// <code>(char) oneChar</code>
		/// .
		/// <p>
		/// If this reader's internal pushback buffer cannot store the character, an
		/// <code>IOException</code>
		/// is thrown.
		/// </summary>
		/// <param name="oneChar">the character to push back to this stream.</param>
		/// <exception cref="IOException">
		/// if this reader is closed or the internal pushback buffer is
		/// full.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void unread(int oneChar)
		{
			lock (@lock)
			{
				checkNotClosed();
				if (pos == 0)
				{
					throw new System.IO.IOException("Pushback buffer full");
				}
				buf[--pos] = (char)oneChar;
			}
		}

		/// <summary>
		/// Skips
		/// <code>charCount</code>
		/// characters in this reader. This implementation skips
		/// characters in the pushback buffer first and then in the source reader if
		/// necessary.
		/// </summary>
		/// <returns>the number of characters actually skipped.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>charCount &lt; 0</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this reader is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override long skip(long charCount)
		{
			if (charCount < 0)
			{
				throw new System.ArgumentException("charCount < 0: " + charCount);
			}
			lock (@lock)
			{
				checkNotClosed();
				if (charCount == 0)
				{
					return 0;
				}
				long inSkipped;
				int availableFromBuffer = buf.Length - pos;
				if (availableFromBuffer > 0)
				{
					long requiredFromIn = charCount - availableFromBuffer;
					if (requiredFromIn <= 0)
					{
						pos += (int)(charCount);
						return charCount;
					}
					pos += availableFromBuffer;
					inSkipped = @in.skip(requiredFromIn);
				}
				else
				{
					inSkipped = @in.skip(charCount);
				}
				return inSkipped + availableFromBuffer;
			}
		}
	}
}
