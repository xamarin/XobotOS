using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="Reader">Reader</see>
	/// and performs some transformation on the
	/// input data while it is being read. Transformations can be anything from a
	/// simple byte-wise filtering input data to an on-the-fly compression or
	/// decompression of the underlying reader. Readers that wrap another reader and
	/// provide some additional functionality on top of it usually inherit from this
	/// class.
	/// </summary>
	/// <seealso cref="FilterWriter">FilterWriter</seealso>
	[Sharpen.Sharpened]
	public abstract class FilterReader : java.io.Reader
	{
		/// <summary>The target Reader which is being filtered.</summary>
		/// <remarks>The target Reader which is being filtered.</remarks>
		protected internal java.io.Reader @in;

		/// <summary>
		/// Constructs a new FilterReader on the Reader
		/// <code>in</code>
		/// .
		/// </summary>
		/// <param name="in">The non-null Reader to filter reads on.</param>
		protected internal FilterReader(java.io.Reader @in) : base(@in)
		{
			this.@in = @in;
		}

		/// <summary>Closes this reader.</summary>
		/// <remarks>Closes this reader. This implementation closes the filtered reader.</remarks>
		/// <exception cref="IOException">if an error occurs while closing this reader.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void close()
		{
			lock (@lock)
			{
				@in.close();
			}
		}

		/// <summary>Sets a mark position in this reader.</summary>
		/// <remarks>
		/// Sets a mark position in this reader. The parameter
		/// <code>readlimit</code>
		/// indicates how many bytes can be read before the mark is invalidated.
		/// Sending
		/// <code>reset()</code>
		/// will reposition this reader back to the marked
		/// position, provided that
		/// <code>readlimit</code>
		/// has not been surpassed.
		/// <p>
		/// This implementation sets a mark in the filtered reader.
		/// </remarks>
		/// <param name="readlimit">
		/// the number of bytes that can be read from this reader before
		/// the mark is invalidated.
		/// </param>
		/// <exception cref="IOException">if an error occurs while marking this reader.</exception>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void mark(int readlimit)
		{
			lock (this)
			{
				lock (@lock)
				{
					@in.mark(readlimit);
				}
			}
		}

		/// <summary>
		/// Indicates whether this reader supports
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// .
		/// This implementation returns whether the filtered reader supports marking.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// are supported
		/// by the filtered reader,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <seealso cref="skip(long)">skip(long)</seealso>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool markSupported()
		{
			lock (@lock)
			{
				return @in.markSupported();
			}
		}

		/// <summary>
		/// Reads a single character from the filtered reader and returns it as an
		/// integer with the two higher-order bytes set to 0.
		/// </summary>
		/// <remarks>
		/// Reads a single character from the filtered reader and returns it as an
		/// integer with the two higher-order bytes set to 0. Returns -1 if the end
		/// of the filtered reader has been reached.
		/// </remarks>
		/// <returns>
		/// The character read or -1 if the end of the filtered reader has
		/// been reached.
		/// </returns>
		/// <exception cref="IOException">if an error occurs while reading from this reader.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read()
		{
			lock (@lock)
			{
				return @in.read();
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>count</code>
		/// characters from the filtered reader and stores them
		/// in the byte array
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// . Returns the
		/// number of characters actually read or -1 if no characters were read and
		/// the end of the filtered reader was encountered.
		/// </summary>
		/// <param name="buffer">the char array in which to store the characters read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the characters
		/// read from this reader.
		/// </param>
		/// <param name="count">
		/// the maximum number of characters to store in
		/// <code>buffer</code>
		/// .
		/// </param>
		/// <returns>
		/// the number of characters actually read or -1 if the end of the
		/// filtered reader has been reached while reading.
		/// </returns>
		/// <exception cref="IOException">if an error occurs while reading from this reader.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read(char[] buffer, int offset, int count)
		{
			lock (@lock)
			{
				return @in.read(buffer, offset, count);
			}
		}

		/// <summary>Indicates whether this reader is ready to be read without blocking.</summary>
		/// <remarks>
		/// Indicates whether this reader is ready to be read without blocking. If
		/// the result is
		/// <code>true</code>
		/// , the next
		/// <code>read()</code>
		/// will not block. If
		/// the result is
		/// <code>false</code>
		/// , this reader may or may not block when
		/// <code>read()</code>
		/// is sent.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this reader will not block when
		/// <code>read()</code>
		/// is called,
		/// <code>false</code>
		/// if unknown or blocking will occur.
		/// </returns>
		/// <exception cref="IOException">if the reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool ready()
		{
			lock (@lock)
			{
				return @in.ready();
			}
		}

		/// <summary>Resets this reader's position to the last marked location.</summary>
		/// <remarks>
		/// Resets this reader's position to the last marked location. Invocations of
		/// <code>read()</code>
		/// and
		/// <code>skip()</code>
		/// will occur from this new location. If
		/// this reader was not marked, the behavior depends on the implementation of
		/// <code>reset()</code>
		/// in the Reader subclass that is filtered by this reader.
		/// The default behavior for Reader is to throw an
		/// <code>IOException</code>
		/// .
		/// </remarks>
		/// <exception cref="IOException">
		/// if a problem occurred or the filtered reader does not support
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// .
		/// </exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void reset()
		{
			lock (@lock)
			{
				@in.reset();
			}
		}

		/// <summary>
		/// Skips
		/// <code>charCount</code>
		/// characters in this reader. Subsequent calls to
		/// <code>read</code>
		/// will not return these characters unless
		/// <code>reset</code>
		/// is used. The
		/// default implementation is to skip characters in the filtered reader.
		/// </summary>
		/// <returns>the number of characters actually skipped.</returns>
		/// <exception cref="IOException">
		/// if the filtered reader is closed or some other I/O error
		/// occurs.
		/// </exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override long skip(long charCount)
		{
			lock (@lock)
			{
				return @in.skip(charCount);
			}
		}
	}
}
