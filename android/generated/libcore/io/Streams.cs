using Sharpen;

namespace libcore.io
{
	[Sharpen.Sharpened]
	public sealed class Streams
	{
		private static XobotOS.Runtime.AtomicReference<byte[]> skipBuffer = XobotOS.Runtime.AtomicReference.create<byte[]>(null);

		private Streams()
		{
		}

		/// <summary>Implements InputStream.read(int) in terms of InputStream.read(byte[], int, int).
		/// 	</summary>
		/// <remarks>
		/// Implements InputStream.read(int) in terms of InputStream.read(byte[], int, int).
		/// InputStream assumes that you implement InputStream.read(int) and provides default
		/// implementations of the others, but often the opposite is more efficient.
		/// </remarks>
		/// <exception cref="System.IO.IOException"></exception>
		public static int readSingleByte(java.io.InputStream @in)
		{
			byte[] buffer = new byte[1];
			int result = @in.read(buffer, 0, 1);
			return (result != -1) ? buffer[0] & unchecked((int)(0xff)) : -1;
		}

		/// <summary>Implements OutputStream.write(int) in terms of OutputStream.write(byte[], int, int).
		/// 	</summary>
		/// <remarks>
		/// Implements OutputStream.write(int) in terms of OutputStream.write(byte[], int, int).
		/// OutputStream assumes that you implement OutputStream.write(int) and provides default
		/// implementations of the others, but often the opposite is more efficient.
		/// </remarks>
		/// <exception cref="System.IO.IOException"></exception>
		public static void writeSingleByte(java.io.OutputStream @out, int b)
		{
			byte[] buffer = new byte[1];
			buffer[0] = unchecked((byte)(b & unchecked((int)(0xff))));
			@out.write(buffer);
		}

		/// <summary>Fills 'dst' with bytes from 'in', throwing EOFException if insufficient bytes are available.
		/// 	</summary>
		/// <remarks>Fills 'dst' with bytes from 'in', throwing EOFException if insufficient bytes are available.
		/// 	</remarks>
		/// <exception cref="System.IO.IOException"></exception>
		public static void readFully(java.io.InputStream @in, byte[] dst)
		{
			readFully(@in, dst, 0, dst.Length);
		}

		/// <summary>
		/// Reads exactly 'byteCount' bytes from 'in' (into 'dst' at offset 'offset'), and throws
		/// EOFException if insufficient bytes are available.
		/// </summary>
		/// <remarks>
		/// Reads exactly 'byteCount' bytes from 'in' (into 'dst' at offset 'offset'), and throws
		/// EOFException if insufficient bytes are available.
		/// Used to implement
		/// <see cref="java.io.DataInputStream.readFully(byte[], int, int)">java.io.DataInputStream.readFully(byte[], int, int)
		/// 	</see>
		/// .
		/// </remarks>
		/// <exception cref="System.IO.IOException"></exception>
		public static void readFully(java.io.InputStream @in, byte[] dst, int offset, int
			 byteCount)
		{
			if (byteCount == 0)
			{
				return;
			}
			if (@in == null)
			{
				throw new System.ArgumentNullException("in == null");
			}
			if (dst == null)
			{
				throw new System.ArgumentNullException("dst == null");
			}
			java.util.Arrays.checkOffsetAndCount(dst.Length, offset, byteCount);
			while (byteCount > 0)
			{
				int bytesRead = @in.read(dst, offset, byteCount);
				if (bytesRead < 0)
				{
					throw new java.io.EOFException();
				}
				offset += bytesRead;
				byteCount -= bytesRead;
			}
		}

		/// <summary>Returns a byte[] containing the remainder of 'in', closing it when done.
		/// 	</summary>
		/// <remarks>Returns a byte[] containing the remainder of 'in', closing it when done.
		/// 	</remarks>
		/// <exception cref="System.IO.IOException"></exception>
		public static byte[] readFully(java.io.InputStream @in)
		{
			try
			{
				return readFullyNoClose(@in);
			}
			finally
			{
				@in.close();
			}
		}

		/// <summary>Returns a byte[] containing the remainder of 'in'.</summary>
		/// <remarks>Returns a byte[] containing the remainder of 'in'.</remarks>
		/// <exception cref="System.IO.IOException"></exception>
		public static byte[] readFullyNoClose(java.io.InputStream @in)
		{
			java.io.ByteArrayOutputStream bytes = new java.io.ByteArrayOutputStream();
			byte[] buffer = new byte[1024];
			int count;
			while ((count = @in.read(buffer)) != -1)
			{
				bytes.write(buffer, 0, count);
			}
			return bytes.toByteArray();
		}

		/// <summary>Returns the remainder of 'reader' as a string, closing it when done.</summary>
		/// <remarks>Returns the remainder of 'reader' as a string, closing it when done.</remarks>
		/// <exception cref="System.IO.IOException"></exception>
		public static string readFully(java.io.Reader reader)
		{
			try
			{
				java.io.StringWriter writer = new java.io.StringWriter();
				char[] buffer = new char[1024];
				int count;
				while ((count = reader.read(buffer)) != -1)
				{
					writer.write(buffer, 0, count);
				}
				return writer.ToString();
			}
			finally
			{
				reader.close();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		public static void skipAll(java.io.InputStream @in)
		{
			do
			{
				@in.skip(long.MaxValue);
			}
			while (@in.read() != -1);
		}

		/// <summary>
		/// Call
		/// <code>in.read()</code>
		/// repeatedly until either the stream is exhausted or
		/// <code>byteCount</code>
		/// bytes have been read.
		/// <p>This method reuses the skip buffer but is careful to never use it at
		/// the same time that another stream is using it. Otherwise streams that use
		/// the caller's buffer for consistency checks like CRC could be clobbered by
		/// other threads. A thread-local buffer is also insufficient because some
		/// streams may call other streams in their skip() method, also clobbering the
		/// buffer.
		/// </summary>
		/// <exception cref="System.IO.IOException"></exception>
		public static long skipByReading(java.io.InputStream @in, long byteCount)
		{
			// acquire the shared skip buffer.
			byte[] buffer = skipBuffer.getAndSet(null);
			if (buffer == null)
			{
				buffer = new byte[4096];
			}
			long skipped = 0;
			while (skipped < byteCount)
			{
				int toRead = (int)System.Math.Min(byteCount - skipped, buffer.Length);
				int read = @in.read(buffer, 0, toRead);
				if (read == -1)
				{
					break;
				}
				skipped += read;
				if (read < toRead)
				{
					break;
				}
			}
			// release the shared skip buffer.
			skipBuffer.set(buffer);
			return skipped;
		}

		/// <summary>
		/// Copies all of the bytes from
		/// <code>in</code>
		/// to
		/// <code>out</code>
		/// . Neither stream is closed.
		/// Returns the total number of bytes transferred.
		/// </summary>
		/// <exception cref="System.IO.IOException"></exception>
		public static int copy(java.io.InputStream @in, java.io.OutputStream @out)
		{
			int total = 0;
			byte[] buffer = new byte[8192];
			int c;
			while ((c = @in.read(buffer)) != -1)
			{
				total += c;
				@out.write(buffer, 0, c);
			}
			return total;
		}

		/// <summary>
		/// Returns the ASCII characters up to but not including the next "\r\n", or
		/// "\n".
		/// </summary>
		/// <remarks>
		/// Returns the ASCII characters up to but not including the next "\r\n", or
		/// "\n".
		/// </remarks>
		/// <exception cref="java.io.EOFException">
		/// if the stream is exhausted before the next newline
		/// character.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static string readAsciiLine(java.io.InputStream @in)
		{
			// TODO: support UTF-8 here instead
			java.lang.StringBuilder result = new java.lang.StringBuilder(80);
			while (true)
			{
				int c = @in.read();
				if (c == -1)
				{
					throw new java.io.EOFException();
				}
				else
				{
					if (c == '\n')
					{
						break;
					}
				}
				result.append((char)c);
			}
			int length = result.Length;
			if (length > 0 && result[length - 1] == '\r')
			{
				result.setLength(length - 1);
			}
			return result.ToString();
		}
	}
}
