using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="OutputStream">OutputStream</see>
	/// and <em>buffers</em> the output.
	/// Expensive interaction with the underlying input stream is minimized, since
	/// most (smaller) requests can be satisfied by accessing the buffer alone. The
	/// drawback is that some extra space is required to hold the buffer and that
	/// copying takes place when flushing that buffer, but this is usually outweighed
	/// by the performance benefits.
	/// <p/>A typical application pattern for the class looks like this:<p/>
	/// <pre>
	/// BufferedOutputStream buf = new BufferedOutputStream(new FileOutputStream(&quot;file.java&quot;));
	/// </pre>
	/// </summary>
	/// <seealso cref="BufferedInputStream">BufferedInputStream</seealso>
	[Sharpen.Sharpened]
	public class BufferedOutputStream : java.io.FilterOutputStream
	{
		/// <summary>The buffer containing the bytes to be written to the target stream.</summary>
		/// <remarks>The buffer containing the bytes to be written to the target stream.</remarks>
		protected internal byte[] buf;

		/// <summary>
		/// The total number of bytes inside the byte array
		/// <code>buf</code>
		/// .
		/// </summary>
		protected internal int count;

		/// <summary>
		/// Constructs a new
		/// <code>BufferedOutputStream</code>
		/// , providing
		/// <code>out</code>
		/// with a buffer
		/// of 8192 bytes.
		/// </summary>
		/// <param name="out">
		/// the
		/// <code>OutputStream</code>
		/// the buffer writes to.
		/// </param>
		public BufferedOutputStream(java.io.OutputStream @out) : this(@out, 8192)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>BufferedOutputStream</code>
		/// , providing
		/// <code>out</code>
		/// with
		/// <code>size</code>
		/// bytes
		/// of buffer.
		/// </summary>
		/// <param name="out">
		/// the
		/// <code>OutputStream</code>
		/// the buffer writes to.
		/// </param>
		/// <param name="size">the size of buffer in bytes.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>size &lt;= 0</code>
		/// .
		/// </exception>
		public BufferedOutputStream(java.io.OutputStream @out, int size) : base(@out)
		{
			if (size <= 0)
			{
				throw new System.ArgumentException("size <= 0");
			}
			buf = new byte[size];
		}

		/// <summary>
		/// Flushes this stream to ensure all pending data is written out to the
		/// target stream.
		/// </summary>
		/// <remarks>
		/// Flushes this stream to ensure all pending data is written out to the
		/// target stream. In addition, the target stream is flushed.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs attempting to flush this stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void flush()
		{
			lock (this)
			{
				checkNotClosed();
				flushInternal();
				@out.flush();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void checkNotClosed()
		{
			if (buf == null)
			{
				throw new System.IO.IOException("BufferedOutputStream is closed");
			}
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// bytes from the byte array
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// to this stream. If there is room in the buffer to hold the
		/// bytes, they are copied in. If not, the buffered bytes plus the bytes in
		/// <code>buffer</code>
		/// are written to the target stream, the target is flushed,
		/// and the buffer is cleared.
		/// </summary>
		/// <param name="buffer">the buffer to be written.</param>
		/// <param name="offset">
		/// the start position in
		/// <code>buffer</code>
		/// from where to get bytes.
		/// </param>
		/// <param name="length">
		/// the number of bytes from
		/// <code>buffer</code>
		/// to write to this
		/// stream.
		/// </param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>length &lt; 0</code>
		/// , or if
		/// <code>offset + length</code>
		/// is greater than the size of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if an error occurs attempting to write to this stream.
		/// 	</exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>buffer</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">If offset or count is outside of bounds.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(byte[] buffer, int offset, int length)
		{
			lock (this)
			{
				checkNotClosed();
				if (buffer == null)
				{
					throw new System.ArgumentNullException("buffer == null");
				}
				byte[] internalBuffer = buf;
				if (length >= internalBuffer.Length)
				{
					flushInternal();
					@out.write(buffer, offset, length);
					return;
				}
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
				// flush the internal buffer first if we have not enough space left
				if (length > (internalBuffer.Length - count))
				{
					flushInternal();
				}
				System.Array.Copy(buffer, offset, internalBuffer, count, length);
				count += length;
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void close()
		{
			lock (this)
			{
				if (buf == null)
				{
					return;
				}
				try
				{
					base.close();
				}
				finally
				{
					buf = null;
				}
			}
		}

		/// <summary>Writes one byte to this stream.</summary>
		/// <remarks>
		/// Writes one byte to this stream. Only the low order byte of the integer
		/// <code>oneByte</code>
		/// is written. If there is room in the buffer, the byte is
		/// copied into the buffer and the count incremented. Otherwise, the buffer
		/// plus
		/// <code>oneByte</code>
		/// are written to the target stream, the target is
		/// flushed, and the buffer is reset.
		/// </remarks>
		/// <param name="oneByte">the byte to be written.</param>
		/// <exception cref="IOException">if an error occurs attempting to write to this stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(int oneByte)
		{
			lock (this)
			{
				checkNotClosed();
				if (count == buf.Length)
				{
					@out.write(buf, 0, count);
					count = 0;
				}
				buf[count++] = unchecked((byte)oneByte);
			}
		}

		/// <summary>Flushes only internal buffer.</summary>
		/// <remarks>Flushes only internal buffer.</remarks>
		/// <exception cref="System.IO.IOException"></exception>
		private void flushInternal()
		{
			if (count > 0)
			{
				@out.write(buf, 0, count);
				count = 0;
			}
		}
	}
}
