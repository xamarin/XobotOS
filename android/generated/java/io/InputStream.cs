using Sharpen;

namespace java.io
{
	/// <summary>A readable source of bytes.</summary>
	/// <remarks>
	/// A readable source of bytes.
	/// <p>Most clients will use input streams that read data from the file system
	/// (
	/// <see cref="FileInputStream">FileInputStream</see>
	/// ), the network (
	/// <see cref="java.net.Socket.getInputStream()">java.net.Socket.getInputStream()</see>
	/// /
	/// <see cref="java.net.URLConnection.getInputStream()">java.net.URLConnection.getInputStream()
	/// 	</see>
	/// ), or from an in-memory byte
	/// array (
	/// <see cref="ByteArrayInputStream">ByteArrayInputStream</see>
	/// ).
	/// <p>Use
	/// <see cref="InputStreamReader">InputStreamReader</see>
	/// to adapt a byte stream like this one into a
	/// character stream.
	/// <p>Most clients should wrap their input stream with
	/// <see cref="BufferedInputStream">BufferedInputStream</see>
	/// . Callers that do only bulk reads may omit buffering.
	/// <p>Some implementations support marking a position in the input stream and
	/// resetting back to this position later. Implementations that don't return
	/// false from
	/// <see cref="markSupported()">markSupported()</see>
	/// and throw an
	/// <see cref="IOException">IOException</see>
	/// when
	/// <see cref="reset()">reset()</see>
	/// is called.
	/// <h3>Subclassing InputStream</h3>
	/// Subclasses that decorate another input stream should consider subclassing
	/// <see cref="FilterInputStream">FilterInputStream</see>
	/// , which delegates all calls to the source input
	/// stream.
	/// <p>All input stream subclasses should override <strong>both</strong>
	/// <see cref="read()">read()</see>
	/// and
	/// <see cref="read(byte[], int, int)">read(byte[],int,int)</see>
	/// . The
	/// three argument overload is necessary for bulk access to the data. This is
	/// much more efficient than byte-by-byte access.
	/// </remarks>
	/// <seealso cref="OutputStream">OutputStream</seealso>
	[Sharpen.Sharpened]
	public abstract class InputStream : object, java.io.Closeable
	{
		/// <summary>This constructor does nothing.</summary>
		/// <remarks>
		/// This constructor does nothing. It is provided for signature
		/// compatibility.
		/// </remarks>
		public InputStream()
		{
		}

		/// <summary>
		/// Returns an estimated number of bytes that can be read or skipped without blocking for more
		/// input.
		/// </summary>
		/// <remarks>
		/// Returns an estimated number of bytes that can be read or skipped without blocking for more
		/// input.
		/// <p>Note that this method provides such a weak guarantee that it is not very useful in
		/// practice.
		/// <p>Firstly, the guarantee is "without blocking for more input" rather than "without
		/// blocking": a read may still block waiting for I/O to complete&nbsp;&mdash; the guarantee is
		/// merely that it won't have to wait indefinitely for data to be written. The result of this
		/// method should not be used as a license to do I/O on a thread that shouldn't be blocked.
		/// <p>Secondly, the result is a
		/// conservative estimate and may be significantly smaller than the actual number of bytes
		/// available. In particular, an implementation that always returns 0 would be correct.
		/// In general, callers should only use this method if they'd be satisfied with
		/// treating the result as a boolean yes or no answer to the question "is there definitely
		/// data ready?".
		/// <p>Thirdly, the fact that a given number of bytes is "available" does not guarantee that a
		/// read or skip will actually read or skip that many bytes: they may read or skip fewer.
		/// <p>It is particularly important to realize that you <i>must not</i> use this method to
		/// size a container and assume that you can read the entirety of the stream without needing
		/// to resize the container. Such callers should probably write everything they read to a
		/// <see cref="ByteArrayOutputStream">ByteArrayOutputStream</see>
		/// and convert that to a byte array. Alternatively, if you're
		/// reading from a file,
		/// <see cref="File.length()">File.length()</see>
		/// returns the current length of the file (though
		/// assuming the file's length can't change may be incorrect, reading a file is inherently
		/// racy).
		/// <p>The default implementation of this method in
		/// <code>InputStream</code>
		/// always returns 0.
		/// Subclasses should override this method if they are able to indicate the number of bytes
		/// available.
		/// </remarks>
		/// <returns>the estimated number of bytes available</returns>
		/// <exception cref="IOException">if this stream is closed or an error occurs</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual int available()
		{
			return 0;
		}

		/// <summary>Closes this stream.</summary>
		/// <remarks>
		/// Closes this stream. Concrete implementations of this class should free
		/// any resources during close. This implementation does nothing.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this stream.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.AutoCloseable")]
		public virtual void close()
		{
		}

		/// <summary>Sets a mark position in this InputStream.</summary>
		/// <remarks>
		/// Sets a mark position in this InputStream. The parameter
		/// <code>readlimit</code>
		/// indicates how many bytes can be read before the mark is invalidated.
		/// Sending
		/// <code>reset()</code>
		/// will reposition the stream back to the marked
		/// position provided
		/// <code>readLimit</code>
		/// has not been surpassed.
		/// <p>
		/// This default implementation does nothing and concrete subclasses must
		/// provide their own implementation.
		/// </remarks>
		/// <param name="readlimit">
		/// the number of bytes that can be read from this stream before
		/// the mark is invalidated.
		/// </param>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		public virtual void mark(int readlimit)
		{
		}

		/// <summary>
		/// Indicates whether this stream supports the
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// methods. The default implementation returns
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
		public virtual bool markSupported()
		{
			return false;
		}

		/// <summary>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255.
		/// </summary>
		/// <remarks>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255. Returns -1 if the end of the stream has been
		/// reached. Blocks until one byte has been read, the end of the source
		/// stream is detected or an exception is thrown.
		/// </remarks>
		/// <returns>the byte read or -1 if the end of stream has been reached.</returns>
		/// <exception cref="IOException">if the stream is closed or another IOException occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public abstract int read();

		/// <summary>
		/// Equivalent to
		/// <code>read(buffer, 0, buffer.length)</code>
		/// .
		/// </summary>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual int read(byte[] buffer)
		{
			return read(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Reads at most
		/// <code>length</code>
		/// bytes from this stream and stores them in
		/// the byte array
		/// <code>b</code>
		/// starting at
		/// <code>offset</code>
		/// .
		/// </summary>
		/// <param name="buffer">the byte array in which to store the bytes read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the bytes read
		/// from this stream.
		/// </param>
		/// <param name="length">
		/// the maximum number of bytes to store in
		/// <code>b</code>
		/// .
		/// </param>
		/// <returns>
		/// the number of bytes actually read or -1 if the end of the stream
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
		/// <code>b</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if the stream is closed or another IOException occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual int read(byte[] buffer, int offset, int length)
		{
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
			{
				for (int i = 0; i < length; i++)
				{
					int c;
					try
					{
						if ((c = read()) == -1)
						{
							return i == 0 ? -1 : i;
						}
					}
					catch (System.IO.IOException e)
					{
						if (i != 0)
						{
							return i;
						}
						throw;
					}
					buffer[offset + i] = unchecked((byte)c);
				}
			}
			return length;
		}

		/// <summary>Resets this stream to the last marked location.</summary>
		/// <remarks>
		/// Resets this stream to the last marked location. Throws an
		/// <code>IOException</code>
		/// if the number of bytes read since the mark has been
		/// set is greater than the limit provided to
		/// <code>mark</code>
		/// , or if no mark
		/// has been set.
		/// <p>
		/// This implementation always throws an
		/// <code>IOException</code>
		/// and concrete
		/// subclasses should provide the proper implementation.
		/// </remarks>
		/// <exception cref="IOException">if this stream is closed or another IOException occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void reset()
		{
			lock (this)
			{
				throw new System.IO.IOException();
			}
		}

		/// <summary>
		/// Skips at most
		/// <code>n</code>
		/// bytes in this stream. This method does nothing and returns
		/// 0 if
		/// <code>n</code>
		/// is negative, but some subclasses may throw.
		/// <p>Note the "at most" in the description of this method: this method may choose to skip
		/// fewer bytes than requested. Callers should <i>always</i> check the return value.
		/// <p>This default implementation reads bytes into a temporary
		/// buffer. Concrete subclasses should provide their own implementation.
		/// </summary>
		/// <param name="byteCount">the number of bytes to skip.</param>
		/// <returns>the number of bytes actually skipped.</returns>
		/// <exception cref="IOException">if this stream is closed or another IOException occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual long skip(long byteCount)
		{
			return libcore.io.Streams.skipByReading(this, byteCount);
		}
	}
}
