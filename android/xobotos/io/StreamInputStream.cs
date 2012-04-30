using System;
using System.IO;

namespace XobotOS.IO
{
	public class StreamInputStream : java.io.InputStream
	{
		Stream stream;

		public StreamInputStream (Stream stream)
		{
			this.stream = stream;
		}

		public override void close ()
		{
			stream.Close ();
		}

		public override int read ()
		{
			return stream.ReadByte ();
		}

		public override int read (byte[] buffer)
		{
			return read (buffer, 0, buffer.Length);
		}

		public override int read (byte[] buffer, int offset, int length)
		{
			return stream.Read (buffer, offset, length);
		}
	}
}
