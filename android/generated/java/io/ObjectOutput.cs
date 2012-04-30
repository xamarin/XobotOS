using Sharpen;

namespace java.io
{
	/// <summary>Defines an interface for classes that allow reading serialized objects.</summary>
	/// <remarks>Defines an interface for classes that allow reading serialized objects.</remarks>
	/// <seealso cref="ObjectOutputStream">ObjectOutputStream</seealso>
	/// <seealso cref="ObjectInput">ObjectInput</seealso>
	[Sharpen.Sharpened]
	public interface ObjectOutput : java.io.DataOutput, java.lang.AutoCloseable
	{
		/// <summary>Closes the target stream.</summary>
		/// <remarks>
		/// Closes the target stream. Implementations of this method should free any
		/// resources used by the stream.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing the target stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void close();

		/// <summary>Flushes the target stream.</summary>
		/// <remarks>
		/// Flushes the target stream. Implementations of this method should ensure
		/// that any pending writes are written out to the target stream.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while flushing the target stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void flush();

		/// <summary>
		/// Writes the entire contents of the byte array
		/// <code>buffer</code>
		/// to the output
		/// stream. Blocks until all bytes are written.
		/// </summary>
		/// <param name="buffer">the buffer to write.</param>
		/// <exception cref="IOException">if an error occurs while writing to the target stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void write(byte[] buffer);

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// bytes from the byte array
		/// <code>buffer</code>
		/// starting at
		/// position
		/// <code>offset</code>
		/// to the target stream. Blocks until all bytes are
		/// written.
		/// </summary>
		/// <param name="buffer">the buffer to write.</param>
		/// <param name="offset">
		/// the index of the first byte in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <param name="count">
		/// the number of bytes from
		/// <code>buffer</code>
		/// to write to the target
		/// stream.
		/// </param>
		/// <exception cref="IOException">if an error occurs while writing to the target stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void write(byte[] buffer, int offset, int count);

		/// <summary>Writes a single byte to the target stream.</summary>
		/// <remarks>
		/// Writes a single byte to the target stream. Only the least significant
		/// byte of the integer
		/// <code>value</code>
		/// is written to the stream. Blocks until
		/// the byte is actually written.
		/// </remarks>
		/// <param name="value">the byte to write.</param>
		/// <exception cref="IOException">if an error occurs while writing to the target stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void write(int value);

		/// <summary>
		/// Writes the specified object
		/// <code>obj</code>
		/// to the target stream.
		/// </summary>
		/// <param name="obj">the object to write.</param>
		/// <exception cref="IOException">if an error occurs while writing to the target stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void writeObject(object obj);
	}
}
