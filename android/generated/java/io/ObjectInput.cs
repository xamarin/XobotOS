using Sharpen;

namespace java.io
{
	/// <summary>Defines an interface for classes that allow reading serialized objects.</summary>
	/// <remarks>Defines an interface for classes that allow reading serialized objects.</remarks>
	/// <seealso cref="ObjectInputStream">ObjectInputStream</seealso>
	/// <seealso cref="ObjectOutput">ObjectOutput</seealso>
	[Sharpen.Sharpened]
	public interface ObjectInput : java.io.DataInput, java.lang.AutoCloseable
	{
		/// <summary>
		/// Indicates the number of bytes of primitive data that can be read without
		/// blocking.
		/// </summary>
		/// <remarks>
		/// Indicates the number of bytes of primitive data that can be read without
		/// blocking.
		/// </remarks>
		/// <returns>the number of bytes available.</returns>
		/// <exception cref="IOException">if an I/O error occurs.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		int available();

		/// <summary>Closes this stream.</summary>
		/// <remarks>
		/// Closes this stream. Implementations of this method should free any
		/// resources used by the stream.
		/// </remarks>
		/// <exception cref="IOException">if an I/O error occurs while closing the input stream.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void close();

		/// <summary>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255.
		/// </summary>
		/// <remarks>
		/// Reads a single byte from this stream and returns it as an integer in the
		/// range from 0 to 255. Returns -1 if the end of this stream has been
		/// reached. Blocks if no input is available.
		/// </remarks>
		/// <returns>the byte read or -1 if the end of this stream has been reached.</returns>
		/// <exception cref="IOException">if this stream is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		int read();

		/// <summary>
		/// Reads bytes from this stream into the byte array
		/// <code>buffer</code>
		/// . Blocks
		/// while waiting for input.
		/// </summary>
		/// <param name="buffer">the array in which to store the bytes read.</param>
		/// <returns>
		/// the number of bytes read or -1 if the end of this stream has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">if this stream is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		int read(byte[] buffer);

		/// <summary>
		/// Reads at most
		/// <code>count</code>
		/// bytes from this stream and stores them in
		/// byte array
		/// <code>buffer</code>
		/// starting at offset
		/// <code>count</code>
		/// . Blocks while
		/// waiting for input.
		/// </summary>
		/// <param name="buffer">the array in which to store the bytes read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the bytes read
		/// from this stream.
		/// </param>
		/// <param name="count">
		/// the maximum number of bytes to store in
		/// <code>buffer</code>
		/// .
		/// </param>
		/// <returns>
		/// the number of bytes read or -1 if the end of this stream has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">if this stream is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		int read(byte[] buffer, int offset, int count);

		/// <summary>Reads the next object from this stream.</summary>
		/// <remarks>Reads the next object from this stream.</remarks>
		/// <returns>the object read.</returns>
		/// <exception cref="java.lang.ClassNotFoundException">if the object's class cannot be found.
		/// 	</exception>
		/// <exception cref="IOException">if this stream is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		object readObject();

		/// <summary>
		/// Skips
		/// <code>byteCount</code>
		/// bytes on this stream. Less than
		/// <code>byteCount</code>
		/// byte are
		/// skipped if the end of this stream is reached before the operation
		/// completes.
		/// </summary>
		/// <returns>the number of bytes actually skipped.</returns>
		/// <exception cref="IOException">if this stream is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		long skip(long byteCount);
	}
}
