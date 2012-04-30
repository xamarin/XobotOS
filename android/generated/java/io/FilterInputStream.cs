using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="InputStream">InputStream</see>
	/// and performs some transformation on
	/// the input data while it is being read. Transformations can be anything from a
	/// simple byte-wise filtering input data to an on-the-fly compression or
	/// decompression of the underlying stream. Input streams that wrap another input
	/// stream and provide some additional functionality on top of it usually inherit
	/// from this class.
	/// </summary>
	/// <seealso cref="FilterOutputStream">FilterOutputStream</seealso>
	[Sharpen.Sharpened]
	public class FilterInputStream : java.io.InputStream
	{
		/// <summary>The source input stream that is filtered.</summary>
		/// <remarks>The source input stream that is filtered.</remarks>
		protected internal volatile java.io.InputStream @in;

		/// <summary>
		/// Constructs a new
		/// <code>FilterInputStream</code>
		/// with the specified input
		/// stream as source.
		/// <p><strong>Warning:</strong> passing a null source creates an invalid
		/// <code>FilterInputStream</code>
		/// , that fails on every method that is not
		/// overridden. Subclasses should check for null in their constructors.
		/// </summary>
		/// <param name="in">the input stream to filter reads on.</param>
		protected internal FilterInputStream(java.io.InputStream @in)
		{
			this.@in = @in;
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int available()
		{
			return @in.available();
		}

		/// <summary>Closes this stream.</summary>
		/// <remarks>Closes this stream. This implementation closes the filtered stream.</remarks>
		/// <exception cref="IOException">if an error occurs while closing this stream.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void close()
		{
			@in.close();
		}

		/// <summary>Sets a mark position in this stream.</summary>
		/// <remarks>
		/// Sets a mark position in this stream. The parameter
		/// <code>readlimit</code>
		/// indicates how many bytes can be read before the mark is invalidated.
		/// Sending
		/// <code>reset()</code>
		/// will reposition this stream back to the marked
		/// position, provided that
		/// <code>readlimit</code>
		/// has not been surpassed.
		/// <p>
		/// This implementation sets a mark in the filtered stream.
		/// </remarks>
		/// <param name="readlimit">
		/// the number of bytes that can be read from this stream before
		/// the mark is invalidated.
		/// </param>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void mark(int readlimit)
		{
			lock (this)
			{
				@in.mark(readlimit);
			}
		}

		/// <summary>
		/// Indicates whether this stream supports
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// .
		/// This implementation returns whether or not the filtered stream supports
		/// marking.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// are supported,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <seealso cref="skip(long)">skip(long)</seealso>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override bool markSupported()
		{
			return @in.markSupported();
		}

		/// <summary>
		/// Reads a single byte from the filtered stream and returns it as an integer
		/// in the range from 0 to 255.
		/// </summary>
		/// <remarks>
		/// Reads a single byte from the filtered stream and returns it as an integer
		/// in the range from 0 to 255. Returns -1 if the end of this stream has been
		/// reached.
		/// </remarks>
		/// <returns>
		/// the byte read or -1 if the end of the filtered stream has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">if the stream is closed or another IOException occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read()
		{
			return @in.read();
		}

		/// <summary>
		/// Reads at most
		/// <code>count</code>
		/// bytes from this stream and stores them in the
		/// byte array
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// . Returns the number
		/// of bytes actually read or -1 if no bytes have been read and the end of
		/// this stream has been reached. This implementation reads bytes from the
		/// filtered stream.
		/// </summary>
		/// <param name="buffer">the byte array in which to store the bytes read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the bytes
		/// read from this stream.
		/// </param>
		/// <param name="count">
		/// the maximum number of bytes to store in
		/// <code>buffer</code>
		/// .
		/// </param>
		/// <returns>
		/// the number of bytes actually read or -1 if the end of the
		/// filtered stream has been reached while reading.
		/// </returns>
		/// <exception cref="IOException">if this stream is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read(byte[] buffer, int offset, int count)
		{
			return @in.read(buffer, offset, count);
		}

		/// <summary>Resets this stream to the last marked location.</summary>
		/// <remarks>
		/// Resets this stream to the last marked location. This implementation
		/// resets the target stream.
		/// </remarks>
		/// <exception cref="IOException">
		/// if this stream is already closed, no mark has been set or the
		/// mark is no longer valid because more than
		/// <code>readlimit</code>
		/// bytes have been read since setting the mark.
		/// </exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void reset()
		{
			lock (this)
			{
				@in.reset();
			}
		}

		/// <summary>
		/// Skips
		/// <code>byteCount</code>
		/// bytes in this stream. Subsequent
		/// calls to
		/// <code>read</code>
		/// will not return these bytes unless
		/// <code>reset</code>
		/// is
		/// used. This implementation skips
		/// <code>byteCount</code>
		/// bytes in the
		/// filtered stream.
		/// </summary>
		/// <returns>the number of bytes actually skipped.</returns>
		/// <exception cref="IOException">if this stream is closed or another IOException occurs.
		/// 	</exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override long skip(long byteCount)
		{
			return @in.skip(byteCount);
		}
	}
}
