using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="OutputStream">OutputStream</see>
	/// and performs some transformation on
	/// the output data while it is being written. Transformations can be anything
	/// from a simple byte-wise filtering output data to an on-the-fly compression or
	/// decompression of the underlying stream. Output streams that wrap another
	/// output stream and provide some additional functionality on top of it usually
	/// inherit from this class.
	/// </summary>
	/// <seealso cref="FilterOutputStream">FilterOutputStream</seealso>
	[Sharpen.Sharpened]
	public class FilterOutputStream : java.io.OutputStream
	{
		/// <summary>The target output stream for this filter stream.</summary>
		/// <remarks>The target output stream for this filter stream.</remarks>
		protected internal java.io.OutputStream @out;

		/// <summary>
		/// Constructs a new
		/// <code>FilterOutputStream</code>
		/// with
		/// <code>out</code>
		/// as its
		/// target stream.
		/// </summary>
		/// <param name="out">the target stream that this stream writes to.</param>
		public FilterOutputStream(java.io.OutputStream @out)
		{
			this.@out = @out;
		}

		/// <summary>Closes this stream.</summary>
		/// <remarks>Closes this stream. This implementation closes the target stream.</remarks>
		/// <exception cref="IOException">if an error occurs attempting to close this stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void close()
		{
			System.Exception thrown = null;
			try
			{
				flush();
			}
			catch (System.Exception e)
			{
				thrown = e;
			}
			try
			{
				@out.close();
			}
			catch (System.Exception e)
			{
				if (thrown == null)
				{
					thrown = e;
				}
			}
			if (thrown != null)
			{
				Sharpen.Util.Throw(thrown);
			}
		}

		/// <summary>Ensures that all pending data is sent out to the target stream.</summary>
		/// <remarks>
		/// Ensures that all pending data is sent out to the target stream. This
		/// implementation flushes the target stream.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs attempting to flush this stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void flush()
		{
			@out.flush();
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// bytes from the byte array
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// to the target stream.
		/// </summary>
		/// <param name="buffer">the buffer to write.</param>
		/// <param name="offset">
		/// the index of the first byte in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <param name="length">
		/// the number of bytes in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is bigger than the length of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if an I/O error occurs while writing to this stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(byte[] buffer, int offset, int length)
		{
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
			{
				for (int i = 0; i < length; i++)
				{
					// Call write() instead of out.write() since subclasses could
					// override the write() method.
					write(buffer[offset + i]);
				}
			}
		}

		/// <summary>Writes one byte to the target stream.</summary>
		/// <remarks>
		/// Writes one byte to the target stream. Only the low order byte of the
		/// integer
		/// <code>oneByte</code>
		/// is written.
		/// </remarks>
		/// <param name="oneByte">the byte to be written.</param>
		/// <exception cref="IOException">if an I/O error occurs while writing to this stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(int oneByte)
		{
			@out.write(oneByte);
		}
	}
}
