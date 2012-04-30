using Sharpen;

namespace android.util.@internal
{
	/// <summary>
	/// This is a quick and dirty implementation of XmlSerializer that isn't horribly
	/// painfully slow like the normal one.
	/// </summary>
	/// <remarks>
	/// This is a quick and dirty implementation of XmlSerializer that isn't horribly
	/// painfully slow like the normal one.  It only does what is needed for the
	/// specific XML files being written with it.
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class FastXmlSerializer : org.xmlpull.v1.XmlSerializer
	{
		private static readonly string[] ESCAPE_TABLE = new string[] { null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, null, null
			, null, null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, "&quot;", null, null, null, "&amp;", null, null, null, null
			, null, null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, "&lt;", null, "&gt;", null };

		internal const int BUFFER_LEN = 8192;

		private readonly char[] mText = new char[BUFFER_LEN];

		private int mPos;

		private java.io.Writer mWriter;

		private java.io.OutputStream mOutputStream;

		private java.nio.charset.CharsetEncoder mCharset;

		private java.nio.ByteBuffer mBytes = java.nio.ByteBuffer.allocate(BUFFER_LEN);

		private bool mInTag;

		// 0-7
		// 8-15
		// 16-23
		// 24-31
		// 32-39
		// 40-47
		// 48-55
		// 56-63
		/// <exception cref="System.IO.IOException"></exception>
		private void append(char c)
		{
			int pos = mPos;
			if (pos >= (BUFFER_LEN - 1))
			{
				flush();
				pos = mPos;
			}
			mText[pos] = c;
			mPos = pos + 1;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void append(string str, int i, int length)
		{
			if (length > BUFFER_LEN)
			{
				int end = i + length;
				while (i < end)
				{
					int next = i + BUFFER_LEN;
					append(str, i, next < end ? BUFFER_LEN : (end - i));
					i = next;
				}
				return;
			}
			int pos = mPos;
			if ((pos + length) > BUFFER_LEN)
			{
				flush();
				pos = mPos;
			}
			Sharpen.StringHelper.GetCharsForString(str, i, i + length, mText, pos);
			mPos = pos + length;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void append(char[] buf, int i, int length)
		{
			if (length > BUFFER_LEN)
			{
				int end = i + length;
				while (i < end)
				{
					int next = i + BUFFER_LEN;
					append(buf, i, next < end ? BUFFER_LEN : (end - i));
					i = next;
				}
				return;
			}
			int pos = mPos;
			if ((pos + length) > BUFFER_LEN)
			{
				flush();
				pos = mPos;
			}
			System.Array.Copy(buf, i, mText, pos, length);
			mPos = pos + length;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void append(string str)
		{
			append(str, 0, str.Length);
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void escapeAndAppendString(string @string)
		{
			int N = @string.Length;
			char NE = (char)ESCAPE_TABLE.Length;
			string[] escapes = ESCAPE_TABLE;
			int lastPos = 0;
			int pos;
			for (pos = 0; pos < N; pos++)
			{
				char c = @string[pos];
				if (c >= NE)
				{
					continue;
				}
				string escape = escapes[c];
				if (escape == null)
				{
					continue;
				}
				if (lastPos < pos)
				{
					append(@string, lastPos, pos - lastPos);
				}
				lastPos = pos + 1;
				append(escape);
			}
			if (lastPos < pos)
			{
				append(@string, lastPos, pos - lastPos);
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void escapeAndAppendString(char[] buf, int start, int len)
		{
			char NE = (char)ESCAPE_TABLE.Length;
			string[] escapes = ESCAPE_TABLE;
			int end = start + len;
			int lastPos = start;
			int pos;
			for (pos = start; pos < end; pos++)
			{
				char c = buf[pos];
				if (c >= NE)
				{
					continue;
				}
				string escape = escapes[c];
				if (escape == null)
				{
					continue;
				}
				if (lastPos < pos)
				{
					append(buf, lastPos, pos - lastPos);
				}
				lastPos = pos + 1;
				append(escape);
			}
			if (lastPos < pos)
			{
				append(buf, lastPos, pos - lastPos);
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual org.xmlpull.v1.XmlSerializer attribute(string @namespace, string name
			, string value)
		{
			append(' ');
			if (@namespace != null)
			{
				append(@namespace);
				append(':');
			}
			append(name);
			append("=\"");
			escapeAndAppendString(value);
			append('"');
			return this;
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void cdsect(string text_1)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void comment(string text_1)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void docdecl(string text_1)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void endDocument()
		{
			flush();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual org.xmlpull.v1.XmlSerializer endTag(string @namespace, string name
			)
		{
			if (mInTag)
			{
				append(" />\n");
			}
			else
			{
				append("</");
				if (@namespace != null)
				{
					append(@namespace);
					append(':');
				}
				append(name);
				append(">\n");
			}
			mInTag = false;
			return this;
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void entityRef(string text_1)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void flush()
		{
			//Log.i("PackageManager", "flush mPos=" + mPos);
			if (mPos > 0)
			{
				if (mOutputStream != null)
				{
					java.nio.CharBuffer charBuffer = java.nio.CharBuffer.wrap(mText, 0, mPos);
					java.nio.charset.CoderResult result = mCharset.encode(charBuffer, mBytes, true);
					while (true)
					{
						if (result.isError())
						{
							throw new System.IO.IOException(result.ToString());
						}
						else
						{
							if (result.isOverflow())
							{
								flushBytes();
								result = mCharset.encode(charBuffer, mBytes, true);
								continue;
							}
						}
						break;
					}
					flushBytes();
					mOutputStream.flush();
				}
				else
				{
					mWriter.write(mText, 0, mPos);
					mWriter.flush();
				}
				mPos = 0;
			}
		}

		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual int getDepth()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual bool getFeature(string name)
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual string getName()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual string getNamespace()
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.ArgumentException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual string getPrefix(string @namespace, bool generatePrefix)
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual object getProperty(string name)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void ignorableWhitespace(string text_1)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void processingInstruction(string text_1)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void setFeature(string name, bool state)
		{
			if (name.Equals("http://xmlpull.org/v1/doc/features.html#indent-output"))
			{
				return;
			}
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void setOutput(java.io.Writer writer)
		{
			mWriter = writer;
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void setPrefix(string prefix, string @namespace)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void setProperty(string name, object value)
		{
			throw new System.NotSupportedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual void startDocument(string encoding, bool standalone)
		{
			append("<?xml version='1.0' encoding='utf-8' standalone='" + (standalone ? "yes" : 
				"no") + "' ?>\n");
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual org.xmlpull.v1.XmlSerializer startTag(string @namespace, string name
			)
		{
			if (mInTag)
			{
				append(">\n");
			}
			append('<');
			if (@namespace != null)
			{
				append(@namespace);
				append(':');
			}
			append(name);
			mInTag = true;
			return this;
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual org.xmlpull.v1.XmlSerializer text(char[] buf, int start, int len)
		{
			if (mInTag)
			{
				append(">");
				mInTag = false;
			}
			escapeAndAppendString(buf, start, len);
			return this;
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.InvalidOperationException"></exception>
		[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlSerializer")]
		public virtual org.xmlpull.v1.XmlSerializer text(string text_1)
		{
			if (mInTag)
			{
				append(">");
				mInTag = false;
			}
			escapeAndAppendString(text_1);
			return this;
		}
	}
}
