using Sharpen;

namespace java.io
{
	/// <summary>A writable sink for bytes.</summary>
	/// <remarks>
	/// A writable sink for bytes.
	/// <p>Most clients will use output streams that write data to the file system
	/// (
	/// <see cref="FileOutputStream">FileOutputStream</see>
	/// ), the network (
	/// <see cref="java.net.Socket.getOutputStream()">java.net.Socket.getOutputStream()</see>
	/// /
	/// <see cref="java.net.URLConnection.getOutputStream()">java.net.URLConnection.getOutputStream()
	/// 	</see>
	/// ), or to an in-memory byte array
	/// (
	/// <see cref="ByteArrayOutputStream">ByteArrayOutputStream</see>
	/// ).
	/// <p>Use
	/// <see cref="OutputStreamWriter">OutputStreamWriter</see>
	/// to adapt a byte stream like this one into a
	/// character stream.
	/// <p>Most clients should wrap their output stream with
	/// <see cref="BufferedOutputStream">BufferedOutputStream</see>
	/// . Callers that do only bulk writes may omit buffering.
	/// <h3>Subclassing OutputStream</h3>
	/// Subclasses that decorate another output stream should consider subclassing
	/// <see cref="FilterOutputStream">FilterOutputStream</see>
	/// , which delegates all calls to the target output
	/// stream.
	/// <p>All output stream subclasses should override <strong>both</strong>
	/// <see cref="write(int)">write(int)</see>
	/// and
	/// <see cref="write(byte[], int, int)">write(byte[],int,int)</see>
	/// . The
	/// three argument overload is necessary for bulk access to the data. This is
	/// much more efficient than byte-by-byte access.
	/// </remarks>
	/// <seealso cref="InputStream">InputStream</seealso>
	[Sharpen.Sharpened]
	public abstract class OutputStream : java.io.Closeable, java.io.Flushable
	{
		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		public OutputStream()
		{
		}

		/// <summary>Closes this stream.</summary>
		/// <remarks>
		/// Closes this stream. Implementations of this method should free any
		/// resources used by the stream. This implementation does nothing.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this stream.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.AutoCloseable")]
		public virtual void close()
		{
		}

		/// <summary>Flushes this stream.</summary>
		/// <remarks>
		/// Flushes this stream. Implementations of this method should ensure that
		/// any buffered data is written out. This implementation does nothing.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while flushing this stream.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.io.Flushable")]
		public virtual void flush()
		{
		}

		/// <summary>
		/// Equivalent to
		/// <code>write(buffer, 0, buffer.length)</code>
		/// .
		/// </summary>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void write(byte[] buffer)
		{
			write(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// bytes from the byte array
		/// <code>buffer</code>
		/// starting at
		/// position
		/// <code>offset</code>
		/// to this stream.
		/// </summary>
		/// <param name="buffer">the buffer to be written.</param>
		/// <param name="offset">
		/// the start position in
		/// <code>buffer</code>
		/// from where to get bytes.
		/// </param>
		/// <param name="count">
		/// the number of bytes from
		/// <code>buffer</code>
		/// to write to this
		/// stream.
		/// </param>
		/// <exception cref="IOException">if an error occurs while writing to this stream.</exception>
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
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void write(byte[] buffer, int offset, int count)
		{
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, count);
			{
				for (int i = offset; i < offset + count; i++)
				{
					write(buffer[i]);
				}
			}
		}

		/// <summary>Writes a single byte to this stream.</summary>
		/// <remarks>
		/// Writes a single byte to this stream. Only the least significant byte of
		/// the integer
		/// <code>oneByte</code>
		/// is written to the stream.
		/// </remarks>
		/// <param name="oneByte">the byte to be written.</param>
		/// <exception cref="IOException">if an error occurs while writing to this stream.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public abstract void write(int oneByte);

		/// <summary>Returns true if this writer has encountered and suppressed an error.</summary>
		/// <remarks>
		/// Returns true if this writer has encountered and suppressed an error. Used
		/// by PrintStreams as an alternative to checked exceptions.
		/// </remarks>
		internal virtual bool checkError()
		{
			return false;
		}
	}
}
