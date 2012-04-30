using System;
using System.IO;

namespace XobotOS.IO
{
	public class StreamOutputStream : java.io.OutputStream
	{
		Stream stream;

		public StreamOutputStream (Stream stream)
		{
			this.stream = stream;
		}

		public bool AutoFlush {
			get;
			set;
		}

		public override void close ()
		{
			stream.Close ();
		}

		public override void flush ()
		{
			stream.Flush ();
		}

		public override void write (int oneByte)
		{
			stream.WriteByte ((byte)oneByte);
			if (AutoFlush)
				stream.Flush ();
		}

		public override void write (byte[] buffer)
		{
			stream.Write (buffer, 0, buffer.Length);
			if (AutoFlush)
				stream.Flush ();
		}

		public override void write (byte[] buffer, int offset, int count)
		{
			stream.Write (buffer, offset, count);
			if (AutoFlush)
				stream.Flush ();
		}
	}
}

