using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="Writer">Writer</see>
	/// and performs some transformation on the
	/// output data while it is being written. Transformations can be anything from a
	/// simple byte-wise filtering output data to an on-the-fly compression or
	/// decompression of the underlying writer. Writers that wrap another writer and
	/// provide some additional functionality on top of it usually inherit from this
	/// class.
	/// </summary>
	/// <seealso cref="FilterReader">FilterReader</seealso>
	[Sharpen.Sharpened]
	public abstract class FilterWriter : java.io.Writer
	{
		/// <summary>The Writer being filtered.</summary>
		/// <remarks>The Writer being filtered.</remarks>
		protected internal java.io.Writer @out;

		/// <summary>
		/// Constructs a new FilterWriter on the Writer
		/// <code>out</code>
		/// . All writes are
		/// now filtered through this writer.
		/// </summary>
		/// <param name="out">the target Writer to filter writes on.</param>
		protected internal FilterWriter(java.io.Writer @out) : base(@out)
		{
			this.@out = @out;
		}

		/// <summary>Closes this writer.</summary>
		/// <remarks>Closes this writer. This implementation closes the target writer.</remarks>
		/// <exception cref="IOException">if an error occurs attempting to close this writer.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void close()
		{
			lock (@lock)
			{
				@out.close();
			}
		}

		/// <summary>
		/// Flushes this writer to ensure all pending data is sent out to the target
		/// writer.
		/// </summary>
		/// <remarks>
		/// Flushes this writer to ensure all pending data is sent out to the target
		/// writer. This implementation flushes the target writer.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs attempting to flush this writer.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void flush()
		{
			lock (@lock)
			{
				@out.flush();
			}
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters from the char array
		/// <code>buffer</code>
		/// starting at position
		/// <code>offset</code>
		/// to the target writer.
		/// </summary>
		/// <param name="buffer">the buffer to write.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <param name="count">
		/// the number of characters in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <exception cref="IOException">if an error occurs while writing to this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] buffer, int offset, int count)
		{
			lock (@lock)
			{
				@out.write(buffer, offset, count);
			}
		}

		/// <summary>
		/// Writes the specified character
		/// <code>oneChar</code>
		/// to the target writer. Only the
		/// two least significant bytes of the integer
		/// <code>oneChar</code>
		/// are written.
		/// </summary>
		/// <param name="oneChar">the char to write to the target writer.</param>
		/// <exception cref="IOException">if an error occurs while writing to this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(int oneChar)
		{
			lock (@lock)
			{
				@out.write(oneChar);
			}
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters from the string
		/// <code>str</code>
		/// starting at
		/// position
		/// <code>index</code>
		/// to this writer. This implementation writes
		/// <code>str</code>
		/// to the target writer.
		/// </summary>
		/// <param name="str">the string to be written.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>str</code>
		/// to write.
		/// </param>
		/// <param name="count">
		/// the number of chars in
		/// <code>str</code>
		/// to write.
		/// </param>
		/// <exception cref="IOException">if an error occurs while writing to this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str, int offset, int count)
		{
			lock (@lock)
			{
				@out.write(str, offset, count);
			}
		}
	}
}
