using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="InputStream">InputStream</see>
	/// and <em>buffers</em> the input.
	/// Expensive interaction with the underlying input stream is minimized, since
	/// most (smaller) requests can be satisfied by accessing the buffer alone. The
	/// drawback is that some extra space is required to hold the buffer and that
	/// copying takes place when filling that buffer, but this is usually outweighed
	/// by the performance benefits.
	/// <p/>A typical application pattern for the class looks like this:<p/>
	/// <pre>
	/// BufferedInputStream buf = new BufferedInputStream(new FileInputStream(&quot;file.java&quot;));
	/// </pre>
	/// </summary>
	/// <seealso cref="BufferedOutputStream">BufferedOutputStream</seealso>
	[Sharpen.Sharpened]
	public class BufferedInputStream : java.io.FilterInputStream
	{
		/// <summary>The buffer containing the current bytes read from the target InputStream.
		/// 	</summary>
		/// <remarks>The buffer containing the current bytes read from the target InputStream.
		/// 	</remarks>
		protected internal volatile byte[] buf;

		/// <summary>
		/// The total number of bytes inside the byte array
		/// <code>buf</code>
		/// .
		/// </summary>
		protected internal int count;

		/// <summary>The current limit, which when passed, invalidates the current mark.</summary>
		/// <remarks>The current limit, which when passed, invalidates the current mark.</remarks>
		protected internal int marklimit;

		/// <summary>The currently marked position.</summary>
		/// <remarks>
		/// The currently marked position. -1 indicates no mark has been set or the
		/// mark has been invalidated.
		/// </remarks>
		protected internal int markpos = -1;

		/// <summary>
		/// The current position within the byte array
		/// <code>buf</code>
		/// .
		/// </summary>
		protected internal int pos;

		/// <summary>
		/// Constructs a new
		/// <code>BufferedInputStream</code>
		/// , providing
		/// <code>in</code>
		/// with a buffer
		/// of 8192 bytes.
		/// <p><strong>Warning:</strong> passing a null source creates a closed
		/// <code>BufferedInputStream</code>
		/// . All read operations on such a stream will
		/// fail with an IOException.
		/// </summary>
		/// <param name="in">
		/// the
		/// <code>InputStream</code>
		/// the buffer reads from.
		/// </param>
		public BufferedInputStream(java.io.InputStream @in) : this(@in, 8192)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>BufferedInputStream</code>
		/// , providing
		/// <code>in</code>
		/// with
		/// <code>size</code>
		/// bytes
		/// of buffer.
		/// <p><strong>Warning:</strong> passing a null source creates a closed
		/// <code>BufferedInputStream</code>
		/// . All read operations on such a stream will
		/// fail with an IOException.
		/// </summary>
		/// <param name="in">
		/// the
		/// <code>InputStream</code>
		/// the buffer reads from.
		/// </param>
		/// <param name="size">the size of buffer in bytes.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>size &lt;= 0</code>
		/// .
		/// </exception>
		public BufferedInputStream(java.io.InputStream @in, int size) : base(@in)
		{
			if (size <= 0)
			{
				throw new System.ArgumentException("size <= 0");
			}
			buf = new byte[size];
		}

		/// <summary>
		/// Returns an estimated number of bytes that can be read or skipped without blocking for more
		/// input.
		/// </summary>
		/// <remarks>
		/// Returns an estimated number of bytes that can be read or skipped without blocking for more
		/// input. This method returns the number of bytes available in the buffer
		/// plus those available in the source stream, but see
		/// <see cref="InputStream.available()">InputStream.available()</see>
		/// for
		/// important caveats.
		/// </remarks>
		/// <returns>the estimated number of bytes available</returns>
		/// <exception cref="IOException">if this stream is closed or an error occurs</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int available()
		{
			lock (this)
			{
				java.io.InputStream localIn = @in;
				// 'in' could be invalidated by close()
				if (buf == null || localIn == null)
				{
					throw streamClosed();
				}
				return count - pos + localIn.available();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private System.IO.IOException streamClosed()
		{
			throw new System.IO.IOException("BufferedInputStream is closed");
		}

		/// <summary>Closes this stream.</summary>
		/// <remarks>
		/// Closes this stream. The source stream is closed and any resources
		/// associated with it are released.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this stream.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void close()
		{
			buf = null;
			java.io.InputStream localIn = @in;
			@in = null;
			if (localIn != null)
			{
				localIn.close();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private int fillbuf(java.io.InputStream localIn, byte[] localBuf)
		{
			if (markpos == -1 || (pos - markpos >= marklimit))
			{
				int result = localIn.read(localBuf);
				if (result > 0)
				{
					markpos = -1;
					pos = 0;
					count = result == -1 ? 0 : result;
				}
				return result;
			}
			if (markpos == 0 && marklimit > localBuf.Length)
			{
				int newLength = localBuf.Length * 2;
				if (newLength > marklimit)
				{
					newLength = marklimit;
				}
				byte[] newbuf = new byte[newLength];
				System.Array.Copy(localBuf, 0, newbuf, 0, localBuf.Length);
				// Reassign buf, which will invalidate any local references
				// FIXME: what if buf was null?
				localBuf = buf = newbuf;
			}
			else
			{
				if (markpos > 0)
				{
					System.Array.Copy(localBuf, markpos, localBuf, 0, localBuf.Length - markpos);
				}
			}
			pos -= markpos;
			count = markpos = 0;
			int bytesread = localIn.read(localBuf, pos, localBuf.Length - pos);
			count = bytesread <= 0 ? pos : pos + bytesread;
			return bytesread;
		}

		/// <summary>Sets a mark position in this stream.</summary>
		/// <remarks>
		/// Sets a mark position in this stream. The parameter
		/// <code>readlimit</code>
		/// indicates how many bytes can be read before a mark is invalidated.
		/// Calling
		/// <code>reset()</code>
		/// will reposition the stream back to the marked
		/// position if
		/// <code>readlimit</code>
		/// has not been surpassed. The underlying
		/// buffer may be increased in size to allow
		/// <code>readlimit</code>
		/// number of
		/// bytes to be supported.
		/// </remarks>
		/// <param name="readlimit">
		/// the number of bytes that can be read before the mark is
		/// invalidated.
		/// </param>
		/// <seealso cref="reset()">reset()</seealso>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void mark(int readlimit)
		{
			lock (this)
			{
				marklimit = readlimit;
				markpos = pos;
			}
		}

		/// <summary>
		/// Indicates whether
		/// <code>BufferedInputStream</code>
		/// supports the
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// methods.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// for BufferedInputStreams.
		/// </returns>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override bool markSupported()
		{
			return true;
		}

		/// <summary>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255.
		/// </summary>
		/// <remarks>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255. Returns -1 if the end of the source string has been
		/// reached. If the internal buffer does not contain any available bytes then
		/// it is filled from the source stream and the first byte is returned.
		/// </remarks>
		/// <returns>
		/// the byte read or -1 if the end of the source stream has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">if this stream is closed or another IOException occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read()
		{
			lock (this)
			{
				// Use local refs since buf and in may be invalidated by an
				// unsynchronized close()
				byte[] localBuf = buf;
				java.io.InputStream localIn = @in;
				if (localBuf == null || localIn == null)
				{
					throw streamClosed();
				}
				if (pos >= count && fillbuf(localIn, localBuf) == -1)
				{
					return -1;
				}
				// localBuf may have been invalidated by fillbuf
				if (localBuf != buf)
				{
					localBuf = buf;
					if (localBuf == null)
					{
						throw streamClosed();
					}
				}
				if (count - pos > 0)
				{
					return localBuf[pos++] & unchecked((int)(0xFF));
				}
				return -1;
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>byteCount</code>
		/// bytes from this stream and stores them in
		/// byte array
		/// <code>buffer</code>
		/// starting at offset
		/// <code>offset</code>
		/// . Returns the
		/// number of bytes actually read or -1 if no bytes were read and the end of
		/// the stream was encountered. If all the buffered bytes have been used, a
		/// mark has not been set and the requested number of bytes is larger than
		/// the receiver's buffer size, this implementation bypasses the buffer and
		/// simply places the results directly into
		/// <code>buffer</code>
		/// .
		/// </summary>
		/// <param name="buffer">the byte array in which to store the bytes read.</param>
		/// <returns>the number of bytes actually read or -1 if end of stream.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>byteCount &lt; 0</code>
		/// , or if
		/// <code>offset + byteCount</code>
		/// is greater than the size of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">
		/// if the stream is already closed or another IOException
		/// occurs.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read(byte[] buffer, int offset, int byteCount)
		{
			lock (this)
			{
				// Use local ref since buf may be invalidated by an unsynchronized
				// close()
				byte[] localBuf = buf;
				if (localBuf == null)
				{
					throw streamClosed();
				}
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, byteCount);
				if (byteCount == 0)
				{
					return 0;
				}
				java.io.InputStream localIn = @in;
				if (localIn == null)
				{
					throw streamClosed();
				}
				int required;
				if (pos < count)
				{
					int copylength = count - pos >= byteCount ? byteCount : count - pos;
					System.Array.Copy(localBuf, pos, buffer, offset, copylength);
					pos += copylength;
					if (copylength == byteCount || localIn.available() == 0)
					{
						return copylength;
					}
					offset += copylength;
					required = byteCount - copylength;
				}
				else
				{
					required = byteCount;
				}
				while (true)
				{
					int read_1;
					if (markpos == -1 && required >= localBuf.Length)
					{
						read_1 = localIn.read(buffer, offset, required);
						if (read_1 == -1)
						{
							return required == byteCount ? -1 : byteCount - required;
						}
					}
					else
					{
						if (fillbuf(localIn, localBuf) == -1)
						{
							return required == byteCount ? -1 : byteCount - required;
						}
						// localBuf may have been invalidated by fillbuf
						if (localBuf != buf)
						{
							localBuf = buf;
							if (localBuf == null)
							{
								throw streamClosed();
							}
						}
						read_1 = count - pos >= required ? required : count - pos;
						System.Array.Copy(localBuf, pos, buffer, offset, read_1);
						pos += read_1;
					}
					required -= read_1;
					if (required == 0)
					{
						return byteCount;
					}
					if (localIn.available() == 0)
					{
						return byteCount - required;
					}
					offset += read_1;
				}
			}
		}

		/// <summary>Resets this stream to the last marked location.</summary>
		/// <remarks>Resets this stream to the last marked location.</remarks>
		/// <exception cref="IOException">
		/// if this stream is closed, no mark has been set or the mark is
		/// no longer valid because more than
		/// <code>readlimit</code>
		/// bytes
		/// have been read since setting the mark.
		/// </exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void reset()
		{
			lock (this)
			{
				if (buf == null)
				{
					throw new System.IO.IOException("Stream is closed");
				}
				if (-1 == markpos)
				{
					throw new System.IO.IOException("Mark has been invalidated.");
				}
				pos = markpos;
			}
		}

		/// <summary>
		/// Skips
		/// <code>byteCount</code>
		/// bytes in this stream. Subsequent calls to
		/// <code>read</code>
		/// will not return these bytes unless
		/// <code>reset</code>
		/// is
		/// used.
		/// </summary>
		/// <param name="byteCount">
		/// the number of bytes to skip.
		/// <code>skip</code>
		/// does nothing and
		/// returns 0 if
		/// <code>byteCount</code>
		/// is less than zero.
		/// </param>
		/// <returns>the number of bytes actually skipped.</returns>
		/// <exception cref="IOException">if this stream is closed or another IOException occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override long skip(long byteCount)
		{
			lock (this)
			{
				// Use local refs since buf and in may be invalidated by an
				// unsynchronized close()
				byte[] localBuf = buf;
				java.io.InputStream localIn = @in;
				if (localBuf == null)
				{
					throw streamClosed();
				}
				if (byteCount < 1)
				{
					return 0;
				}
				if (localIn == null)
				{
					throw streamClosed();
				}
				if (count - pos >= byteCount)
				{
					pos += (int)(byteCount);
					return byteCount;
				}
				long read_1 = count - pos;
				pos = count;
				if (markpos != -1)
				{
					if (byteCount <= marklimit)
					{
						if (fillbuf(localIn, localBuf) == -1)
						{
							return read_1;
						}
						if (count - pos >= byteCount - read_1)
						{
							pos += (int)(byteCount - read_1);
							return byteCount;
						}
						// Couldn't get all the bytes, skip what we read
						read_1 += (count - pos);
						pos = count;
						return read_1;
					}
				}
				return read_1 + localIn.skip(byteCount - read_1);
			}
		}
	}
}
