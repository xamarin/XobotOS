using System;
using System.Text;
using java.nio;
using java.nio.charset;

namespace XobotOS.IO
{
	internal class MonoCharsetDecoder : CharsetDecoder
	{
		Decoder decoder;

		public MonoCharsetDecoder (MonoCharset cs)
			: base(cs, 1, 2)
		{
			this.decoder = cs.Encoding.GetDecoder ();
		}

		#region implemented abstract members of java.nio.charset.CharsetDecoder
		internal protected override CoderResult decodeLoop (ByteBuffer @in, CharBuffer @out)
		{
			int byte_count = @in.remaining ();
			int char_count = @out.capacity ();
			if (byte_count < 1)
				return CoderResult.UNDERFLOW;
			byte[] bytes = new byte [byte_count];
			@in.get (bytes, 0, byte_count);

			char[] chars = new char [char_count];
			int bytes_used, chars_used;
			bool completed;
			decoder.Convert (
				bytes, 0, byte_count, chars, 0, char_count, false,
				out bytes_used, out chars_used, out completed);

			if (bytes_used != byte_count)
				return CoderResult.OVERFLOW;

			@out.put (chars, 0, chars_used);
			return CoderResult.UNDERFLOW;
		}
		#endregion
	}
}

