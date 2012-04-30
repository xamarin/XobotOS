using System;
using System.Text;
using java.nio;
using java.nio.charset;

namespace XobotOS.IO
{
	internal class MonoCharsetEncoder : CharsetEncoder
	{
		Encoder encoder;

		public MonoCharsetEncoder (MonoCharset cs)
			: base(cs, 1, 2)
		{
			this.encoder = cs.Encoding.GetEncoder ();
		}

		#region implemented abstract members of java.nio.charset.CharsetEncoder
		internal protected override CoderResult encodeLoop (CharBuffer @in, ByteBuffer @out)
		{
			int char_count = @in.remaining ();
			int byte_count = @out.capacity ();
			if (char_count < 1)
				return CoderResult.UNDERFLOW;
			char[] chars = new char [char_count];
				@in.get (chars, 0, char_count);

			byte[] bytes = new byte [byte_count];
			int bytes_used, chars_used;
			bool completed;
			encoder.Convert (
				chars, 0, char_count, bytes, 0, byte_count, false,
				out chars_used, out bytes_used, out completed);

			if (chars_used != char_count)
				return CoderResult.OVERFLOW;

			@out.put (bytes, 0, bytes_used);
			return CoderResult.UNDERFLOW;
		}
		#endregion
	}
}

