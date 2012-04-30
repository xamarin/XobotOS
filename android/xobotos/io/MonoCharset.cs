using System;
using System.Text;
using java.nio.charset;

namespace XobotOS.IO
{
	internal class MonoCharset : Charset
	{
		public Encoding Encoding {
			get; private set;
		}

		public string Name {
			get { return Encoding.HeaderName; }
		}

		public MonoCharset(Encoding encoding)
			: base(encoding.HeaderName, null)
		{
			this.Encoding = encoding;
		}

		#region implemented abstract members of java.nio.charset.Charset
		public override bool contains (Charset charset)
		{
			return charset == this;
		}

		public override CharsetEncoder newEncoder ()
		{
			return new MonoCharsetEncoder (this);
		}

		public override CharsetDecoder newDecoder ()
		{
			return new MonoCharsetDecoder (this);
		}
		#endregion
	}
}

