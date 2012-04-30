using Sharpen;

namespace java.io
{
	/// <summary>A class for turning a character stream into a byte stream.</summary>
	/// <remarks>
	/// A class for turning a character stream into a byte stream. Data written to
	/// the target input stream is converted into bytes by either a default or a
	/// provided character converter. The default encoding is taken from the
	/// "file.encoding" system property.
	/// <code>OutputStreamWriter</code>
	/// contains a buffer
	/// of bytes to be written to target stream and converts these into characters as
	/// needed. The buffer size is 8K.
	/// </remarks>
	/// <seealso cref="InputStreamReader">InputStreamReader</seealso>
	[Sharpen.Sharpened]
	public class OutputStreamWriter : java.io.Writer
	{
		private readonly java.io.OutputStream @out;

		private java.nio.charset.CharsetEncoder encoder;

		private java.nio.ByteBuffer bytes = java.nio.ByteBuffer.allocate(8192);

		/// <summary>
		/// Constructs a new OutputStreamWriter using
		/// <code>out</code>
		/// as the target
		/// stream to write converted characters to. The default character encoding
		/// is used.
		/// </summary>
		/// <param name="out">the non-null target stream to write converted bytes to.</param>
		public OutputStreamWriter(java.io.OutputStream @out) : this(@out, java.nio.charset.Charset
			.defaultCharset())
		{
		}

		/// <summary>
		/// Constructs a new OutputStreamWriter using
		/// <code>out</code>
		/// as the target
		/// stream to write converted characters to and
		/// <code>enc</code>
		/// as the character
		/// encoding. If the encoding cannot be found, an
		/// UnsupportedEncodingException error is thrown.
		/// </summary>
		/// <param name="out">the target stream to write converted bytes to.</param>
		/// <param name="enc">the string describing the desired character encoding.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>enc</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="UnsupportedEncodingException">
		/// if the encoding specified by
		/// <code>enc</code>
		/// cannot be found.
		/// </exception>
		/// <exception cref="java.io.UnsupportedEncodingException"></exception>
		public OutputStreamWriter(java.io.OutputStream @out, string enc) : base(@out)
		{
			if (enc == null)
			{
				throw new System.ArgumentNullException();
			}
			this.@out = @out;
			try
			{
				encoder = java.nio.charset.Charset.forName(enc).newEncoder();
			}
			catch (System.Exception)
			{
				throw new java.io.UnsupportedEncodingException(enc);
			}
			encoder.onMalformedInput(java.nio.charset.CodingErrorAction.REPLACE);
			encoder.onUnmappableCharacter(java.nio.charset.CodingErrorAction.REPLACE);
		}

		/// <summary>
		/// Constructs a new OutputStreamWriter using
		/// <code>out</code>
		/// as the target
		/// stream to write converted characters to and
		/// <code>cs</code>
		/// as the character
		/// encoding.
		/// </summary>
		/// <param name="out">the target stream to write converted bytes to.</param>
		/// <param name="cs">
		/// the
		/// <code>Charset</code>
		/// that specifies the character encoding.
		/// </param>
		public OutputStreamWriter(java.io.OutputStream @out, java.nio.charset.Charset cs)
			 : base(@out)
		{
			this.@out = @out;
			encoder = cs.newEncoder();
			encoder.onMalformedInput(java.nio.charset.CodingErrorAction.REPLACE);
			encoder.onUnmappableCharacter(java.nio.charset.CodingErrorAction.REPLACE);
		}

		/// <summary>
		/// Constructs a new OutputStreamWriter using
		/// <code>out</code>
		/// as the target
		/// stream to write converted characters to and
		/// <code>enc</code>
		/// as the character
		/// encoder.
		/// </summary>
		/// <param name="out">the target stream to write converted bytes to.</param>
		/// <param name="enc">the character encoder used for character conversion.</param>
		public OutputStreamWriter(java.io.OutputStream @out, java.nio.charset.CharsetEncoder
			 enc) : base(@out)
		{
			enc.charset();
			this.@out = @out;
			encoder = enc;
		}

		/// <summary>Closes this writer.</summary>
		/// <remarks>
		/// Closes this writer. This implementation flushes the buffer as well as the
		/// target stream. The target stream is then closed and the resources for the
		/// buffer and converter are released.
		/// <p>Only the first invocation of this method has any effect. Subsequent calls
		/// do nothing.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void close()
		{
			lock (@lock)
			{
				if (encoder != null)
				{
					drainEncoder();
					flushBytes(false);
					@out.close();
					encoder = null;
					bytes = null;
				}
			}
		}

		/// <summary>Flushes this writer.</summary>
		/// <remarks>
		/// Flushes this writer. This implementation ensures that all buffered bytes
		/// are written to the target stream. After writing the bytes, the target
		/// stream is flushed as well.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while flushing this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void flush()
		{
			flushBytes(true);
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void flushBytes(bool flushUnderlyingStream)
		{
			lock (@lock)
			{
				checkStatus();
				int position = bytes.position();
				if (position > 0)
				{
					bytes.flip();
					@out.write(((byte[])bytes.array()), bytes.arrayOffset(), position);
					bytes.clear();
				}
				if (flushUnderlyingStream)
				{
					@out.flush();
				}
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void convert(java.nio.CharBuffer chars)
		{
			while (true)
			{
				java.nio.charset.CoderResult result = encoder.encode(chars, bytes, false);
				if (result.isOverflow())
				{
					// Make room and try again.
					flushBytes(false);
					continue;
				}
				else
				{
					if (result.isError())
					{
						result.throwException();
					}
				}
				break;
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void drainEncoder()
		{
			// Strictly speaking, I think it's part of the CharsetEncoder contract that you call
			// encode with endOfInput true before flushing. Our ICU-based implementations don't
			// actually need this, and you'd hope that any reasonable implementation wouldn't either.
			// CharsetEncoder.encode doesn't actually pass the boolean through to encodeLoop anyway!
			java.nio.CharBuffer chars = java.nio.CharBuffer.allocate(0);
			while (true)
			{
				java.nio.charset.CoderResult result = encoder.encode(chars, bytes, true);
				if (result.isError())
				{
					result.throwException();
				}
				else
				{
					if (result.isOverflow())
					{
						flushBytes(false);
						continue;
					}
				}
				break;
			}
			// Some encoders (such as ISO-2022-JP) have stuff to write out after all the
			// characters (such as shifting back into a default state). In our implementation,
			// this is actually the first time ICU is told that we've run out of input.
			java.nio.charset.CoderResult result_1 = encoder.flush(bytes);
			while (!result_1.isUnderflow())
			{
				if (result_1.isOverflow())
				{
					flushBytes(false);
					result_1 = encoder.flush(bytes);
				}
				else
				{
					result_1.throwException();
				}
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void checkStatus()
		{
			if (encoder == null)
			{
				throw new System.IO.IOException("OutputStreamWriter is closed");
			}
		}

		/// <summary>
		/// Returns the historical name of the encoding used by this writer to convert characters to
		/// bytes, or null if this writer has been closed.
		/// </summary>
		/// <remarks>
		/// Returns the historical name of the encoding used by this writer to convert characters to
		/// bytes, or null if this writer has been closed. Most callers should probably keep
		/// track of the String or Charset they passed in; this method may not return the same
		/// name.
		/// </remarks>
		public virtual string getEncoding()
		{
			if (encoder == null)
			{
				return null;
			}
			return java.io.HistoricalCharsetNames.get(encoder.charset());
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// in
		/// <code>buf</code>
		/// to this writer. The characters are immediately converted to bytes by the
		/// character converter and stored in a local buffer. If the buffer gets full
		/// as a result of the conversion, this writer is flushed.
		/// </summary>
		/// <param name="buffer">the array containing characters to write.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>buf</code>
		/// to write.
		/// </param>
		/// <param name="count">the maximum number of characters to write.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is greater than the size of
		/// <code>buf</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">
		/// if this writer has already been closed or another I/O error
		/// occurs.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] buffer, int offset, int count)
		{
			lock (@lock)
			{
				checkStatus();
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, count);
				java.nio.CharBuffer chars = java.nio.CharBuffer.wrap(buffer, offset, count);
				convert(chars);
			}
		}

		/// <summary>
		/// Writes the character
		/// <code>oneChar</code>
		/// to this writer. The lowest two bytes
		/// of the integer
		/// <code>oneChar</code>
		/// are immediately converted to bytes by the
		/// character converter and stored in a local buffer. If the buffer gets full
		/// by converting this character, this writer is flushed.
		/// </summary>
		/// <param name="oneChar">the character to write.</param>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(int oneChar)
		{
			lock (@lock)
			{
				checkStatus();
				java.nio.CharBuffer chars = java.nio.CharBuffer.wrap(new char[] { (char)oneChar }
					);
				convert(chars);
			}
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// in
		/// <code>str</code>
		/// to this writer. The characters are immediately converted to bytes by the
		/// character converter and stored in a local buffer. If the buffer gets full
		/// as a result of the conversion, this writer is flushed.
		/// </summary>
		/// <param name="str">the string containing characters to write.</param>
		/// <param name="offset">
		/// the start position in
		/// <code>str</code>
		/// for retrieving characters.
		/// </param>
		/// <param name="count">the maximum number of characters to write.</param>
		/// <exception cref="IOException">
		/// if this writer has already been closed or another I/O error
		/// occurs.
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is bigger than the length of
		/// <code>str</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str, int offset, int count)
		{
			lock (@lock)
			{
				if (count < 0)
				{
					throw new java.lang.StringIndexOutOfBoundsException(str, offset, count);
				}
				if (str == null)
				{
					throw new System.ArgumentNullException("str == null");
				}
				if ((offset | count) < 0 || offset > str.Length - count)
				{
					throw new java.lang.StringIndexOutOfBoundsException(str, offset, count);
				}
				checkStatus();
				java.nio.CharBuffer chars = java.nio.CharBuffer.wrap(java.lang.CharSequenceProxy.Wrap
					(str), offset, count + offset);
				convert(chars);
			}
		}

		[Sharpen.OverridesMethod(@"java.io.Writer")]
		internal override bool checkError()
		{
			return @out.checkError();
		}
	}
}
