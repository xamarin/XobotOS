using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="InputStream">InputStream</see>
	/// and adds functionality to "push back"
	/// bytes that have been read, so that they can be read again. Parsers may find
	/// this useful. The number of bytes which may be pushed back can be specified
	/// during construction. If the buffer of pushed back bytes is empty, bytes are
	/// read from the underlying input stream.
	/// </summary>
	[Sharpen.Sharpened]
	public class PushbackInputStream : java.io.FilterInputStream
	{
		/// <summary>The buffer that contains pushed-back bytes.</summary>
		/// <remarks>The buffer that contains pushed-back bytes.</remarks>
		protected internal byte[] buf;

		/// <summary>
		/// The current position within
		/// <code>buf</code>
		/// . A value equal to
		/// <code>buf.length</code>
		/// indicates that no bytes are available. A value of 0
		/// indicates that the buffer is full.
		/// </summary>
		protected internal int pos;

		/// <summary>
		/// Constructs a new
		/// <code>PushbackInputStream</code>
		/// with the specified input
		/// stream as source. The size of the pushback buffer is set to the default
		/// value of 1 byte.
		/// <p><strong>Warning:</strong> passing a null source creates an invalid
		/// <code>PushbackInputStream</code>
		/// . All read operations on such a stream will
		/// fail.
		/// </summary>
		/// <param name="in">the source input stream.</param>
		public PushbackInputStream(java.io.InputStream @in) : base(@in)
		{
			buf = (@in == null) ? null : new byte[1];
			pos = 1;
		}

		/// <summary>
		/// Constructs a new
		/// <code>PushbackInputStream</code>
		/// with
		/// <code>in</code>
		/// as source
		/// input stream. The size of the pushback buffer is set to
		/// <code>size</code>
		/// .
		/// <p><strong>Warning:</strong> passing a null source creates an invalid
		/// <code>PushbackInputStream</code>
		/// . All read operations on such a stream will
		/// fail.
		/// </summary>
		/// <param name="in">the source input stream.</param>
		/// <param name="size">the size of the pushback buffer.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>size</code>
		/// is negative.
		/// </exception>
		public PushbackInputStream(java.io.InputStream @in, int size) : base(@in)
		{
			if (size <= 0)
			{
				throw new System.ArgumentException("size <= 0");
			}
			buf = (@in == null) ? null : new byte[size];
			pos = size;
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int available()
		{
			if (buf == null)
			{
				throw new System.IO.IOException();
			}
			return buf.Length - pos + @in.available();
		}

		/// <summary>Closes this stream.</summary>
		/// <remarks>
		/// Closes this stream. This implementation closes the source stream
		/// and releases the pushback buffer.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this stream.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void close()
		{
			if (@in != null)
			{
				@in.close();
				@in = null;
				buf = null;
			}
		}

		/// <summary>
		/// Indicates whether this stream supports the
		/// <code>mark(int)</code>
		/// and
		/// <code>reset()</code>
		/// methods.
		/// <code>PushbackInputStream</code>
		/// does not support
		/// them, so it returns
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
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override bool markSupported()
		{
			return false;
		}

		/// <summary>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255.
		/// </summary>
		/// <remarks>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255. If the pushback buffer does not contain any
		/// available bytes then a byte from the source input stream is returned.
		/// Blocks until one byte has been read, the end of the source stream is
		/// detected or an exception is thrown.
		/// </remarks>
		/// <returns>
		/// the byte read or -1 if the end of the source stream has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">
		/// if this stream is closed or an I/O error occurs while reading
		/// from this stream.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read()
		{
			if (buf == null)
			{
				throw new System.IO.IOException();
			}
			// Is there a pushback byte available?
			if (pos < buf.Length)
			{
				return (buf[pos++] & unchecked((int)(0xFF)));
			}
			// Assume read() in the InputStream will return low-order byte or -1
			// if end of stream.
			return @in.read();
		}

		/// <summary>
		/// Reads at most
		/// <code>length</code>
		/// bytes from this stream and stores them in
		/// the byte array
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// . Bytes are read
		/// from the pushback buffer first, then from the source stream if more bytes
		/// are required. Blocks until
		/// <code>count</code>
		/// bytes have been read, the end of
		/// the source stream is detected or an exception is thrown.
		/// </summary>
		/// <param name="buffer">the array in which to store the bytes read from this stream.
		/// 	</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the bytes read
		/// from this stream.
		/// </param>
		/// <param name="length">
		/// the maximum number of bytes to store in
		/// <code>buffer</code>
		/// .
		/// </param>
		/// <returns>
		/// the number of bytes read or -1 if the end of the source stream
		/// has been reached.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>length &lt; 0</code>
		/// , or if
		/// <code>offset + length</code>
		/// is greater than the length of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">
		/// if this stream is closed or another I/O error occurs while
		/// reading from this stream.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>buffer</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read(byte[] buffer, int offset, int length)
		{
			if (buf == null)
			{
				throw streamClosed();
			}
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
			int copiedBytes = 0;
			int copyLength = 0;
			int newOffset = offset;
			// Are there pushback bytes available?
			if (pos < buf.Length)
			{
				copyLength = (buf.Length - pos >= length) ? length : buf.Length - pos;
				System.Array.Copy(buf, pos, buffer, newOffset, copyLength);
				newOffset += copyLength;
				copiedBytes += copyLength;
				// Use up the bytes in the local buffer
				pos += copyLength;
			}
			// Have we copied enough?
			if (copyLength == length)
			{
				return length;
			}
			int inCopied = @in.read(buffer, newOffset, length - copiedBytes);
			if (inCopied > 0)
			{
				return inCopied + copiedBytes;
			}
			if (copiedBytes == 0)
			{
				return inCopied;
			}
			return copiedBytes;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private System.IO.IOException streamClosed()
		{
			throw new System.IO.IOException("PushbackInputStream is closed");
		}

		/// <summary>
		/// Skips
		/// <code>byteCount</code>
		/// bytes in this stream. This implementation skips bytes
		/// in the pushback buffer first and then in the source stream if necessary.
		/// </summary>
		/// <returns>the number of bytes actually skipped.</returns>
		/// <exception cref="IOException">if this stream is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override long skip(long byteCount)
		{
			if (@in == null)
			{
				throw streamClosed();
			}
			if (byteCount <= 0)
			{
				return 0;
			}
			int numSkipped = 0;
			if (pos < buf.Length)
			{
				numSkipped += (int)((byteCount < buf.Length - pos) ? byteCount : buf.Length - pos
					);
				pos += numSkipped;
			}
			if (numSkipped < byteCount)
			{
				numSkipped += (int)(@in.skip(byteCount - numSkipped));
			}
			return numSkipped;
		}

		/// <summary>
		/// Pushes all the bytes in
		/// <code>buffer</code>
		/// back to this stream. The bytes are
		/// pushed back in such a way that the next byte read from this stream is
		/// buffer[0], then buffer[1] and so on.
		/// <p>
		/// If this stream's internal pushback buffer cannot store the entire
		/// contents of
		/// <code>buffer</code>
		/// , an
		/// <code>IOException</code>
		/// is thrown. Parts of
		/// <code>buffer</code>
		/// may have already been copied to the pushback buffer when
		/// the exception is thrown.
		/// </summary>
		/// <param name="buffer">the buffer containing the bytes to push back to this stream.
		/// 	</param>
		/// <exception cref="IOException">
		/// if the free space in the internal pushback buffer is not
		/// sufficient to store the contents of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void unread(byte[] buffer)
		{
			unread(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Pushes a subset of the bytes in
		/// <code>buffer</code>
		/// back to this stream. The
		/// subset is defined by the start position
		/// <code>offset</code>
		/// within
		/// <code>buffer</code>
		/// and the number of bytes specified by
		/// <code>length</code>
		/// . The
		/// bytes are pushed back in such a way that the next byte read from this
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
		/// <param name="buffer">the buffer containing the bytes to push back to this stream.
		/// 	</param>
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
		/// <code>length &lt; 0</code>
		/// , or if
		/// <code>offset + length</code>
		/// is greater than the length of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">
		/// if the free space in the internal pushback buffer is not
		/// sufficient to store the selected contents of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void unread(byte[] buffer, int offset, int length)
		{
			if (length > pos)
			{
				throw new System.IO.IOException("Pushback buffer full");
			}
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
			if (buf == null)
			{
				throw streamClosed();
			}
			System.Array.Copy(buffer, offset, buf, pos - length, length);
			pos = pos - length;
		}

		/// <summary>
		/// Pushes the specified byte
		/// <code>oneByte</code>
		/// back to this stream. Only the
		/// least significant byte of the integer
		/// <code>oneByte</code>
		/// is pushed back.
		/// This is done in such a way that the next byte read from this stream is
		/// <code>(byte) oneByte</code>
		/// .
		/// <p>
		/// If this stream's internal pushback buffer cannot store the byte, an
		/// <code>IOException</code>
		/// is thrown.
		/// </summary>
		/// <param name="oneByte">the byte to push back to this stream.</param>
		/// <exception cref="IOException">
		/// if this stream is closed or the internal pushback buffer is
		/// full.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void unread(int oneByte)
		{
			if (buf == null)
			{
				throw new System.IO.IOException();
			}
			if (pos == 0)
			{
				throw new System.IO.IOException("Pushback buffer full");
			}
			buf[--pos] = unchecked((byte)oneByte);
		}

		/// <summary>Marks the current position in this stream.</summary>
		/// <remarks>
		/// Marks the current position in this stream. Setting a mark is not
		/// supported in this class; this implementation does nothing.
		/// </remarks>
		/// <param name="readlimit">
		/// the number of bytes that can be read from this stream before
		/// the mark is invalidated; this parameter is ignored.
		/// </param>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void mark(int readlimit)
		{
		}

		/// <summary>Resets this stream to the last marked position.</summary>
		/// <remarks>
		/// Resets this stream to the last marked position. Resetting the stream is
		/// not supported in this class; this implementation always throws an
		/// <code>IOException</code>
		/// .
		/// </remarks>
		/// <exception cref="IOException">if this method is called.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void reset()
		{
			throw new System.IO.IOException();
		}
	}
}
