using System;
using java.io;
using java.nio.charset;

namespace android.util.@internal
{
	partial class FastXmlSerializer
	{
		/// <exception cref="System.IO.IOException"></exception>
		private void flushBytes ()
		{
			int position;
			if ((position = mBytes.position ()) > 0) {
				mBytes.flip ();
				mOutputStream.write ((byte[])mBytes.array (), 0, position);
				mBytes.clear ();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void setOutput (OutputStream os, string encoding)
		{
			if (os == null) {
				throw new ArgumentException ();
			}
			if (true) {
				try {
					mCharset = Charset.forName (encoding).newEncoder ();
				} catch (IllegalCharsetNameException e) {
					throw new UnsupportedEncodingException (encoding, e);
				} catch (UnsupportedCharsetException e) {
					throw new UnsupportedEncodingException (encoding, e);
				}
				mOutputStream = os;
			} else {
				setOutput (encoding == null ? new OutputStreamWriter (os) : new OutputStreamWriter
					(os, encoding));
			}
		}
	}
}

