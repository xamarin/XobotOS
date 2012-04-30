using Sharpen;

namespace java.io
{
	/// <summary>A class for turning a byte stream into a character stream.</summary>
	/// <remarks>
	/// A class for turning a byte stream into a character stream. Data read from the
	/// source input stream is converted into characters by either a default or a
	/// provided character converter. The default encoding is taken from the
	/// "file.encoding" system property.
	/// <code>InputStreamReader</code>
	/// contains a buffer
	/// of bytes read from the source stream and converts these into characters as
	/// needed. The buffer size is 8K.
	/// </remarks>
	/// <seealso cref="OutputStreamWriter">OutputStreamWriter</seealso>
	[Sharpen.Sharpened]
	public partial class InputStreamReader : java.io.Reader
	{
		private java.io.InputStream @in;

		private bool endOfInput = false;

		private java.nio.charset.CharsetDecoder decoder;

		private readonly java.nio.ByteBuffer bytes = java.nio.ByteBuffer.allocate(8192);

		/// <summary>
		/// Constructs a new
		/// <code>InputStreamReader</code>
		/// on the
		/// <see cref="InputStream">InputStream</see>
		/// <code>in</code>
		/// . This constructor sets the character converter to the encoding
		/// specified in the "file.encoding" property and falls back to ISO 8859_1
		/// (ISO-Latin-1) if the property doesn't exist.
		/// </summary>
		/// <param name="in">the input stream from which to read characters.</param>
		public InputStreamReader(java.io.InputStream @in) : this(@in, java.nio.charset.Charset
			.defaultCharset())
		{
		}

		/// <summary>
		/// Constructs a new InputStreamReader on the InputStream
		/// <code>in</code>
		/// and
		/// CharsetDecoder
		/// <code>dec</code>
		/// .
		/// </summary>
		/// <param name="in">the source InputStream from which to read characters.</param>
		/// <param name="dec">the CharsetDecoder used by the character conversion.</param>
		public InputStreamReader(java.io.InputStream @in, java.nio.charset.CharsetDecoder
			 dec) : base(@in)
		{
			dec.averageCharsPerByte();
			this.@in = @in;
			decoder = dec;
			bytes.limit(0);
		}

		/// <summary>
		/// Constructs a new InputStreamReader on the InputStream
		/// <code>in</code>
		/// and
		/// Charset
		/// <code>charset</code>
		/// .
		/// </summary>
		/// <param name="in">the source InputStream from which to read characters.</param>
		/// <param name="charset">the Charset that defines the character converter</param>
		public InputStreamReader(java.io.InputStream @in, java.nio.charset.Charset charset
			) : base(@in)
		{
			this.@in = @in;
			decoder = charset.newDecoder().onMalformedInput(java.nio.charset.CodingErrorAction
				.REPLACE).onUnmappableCharacter(java.nio.charset.CodingErrorAction.REPLACE);
			bytes.limit(0);
		}

		/// <summary>Closes this reader.</summary>
		/// <remarks>
		/// Closes this reader. This implementation closes the source InputStream and
		/// releases all local storage.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs attempting to close this reader.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void close()
		{
			lock (@lock)
			{
				if (decoder != null)
				{
					decoder.reset();
				}
				decoder = null;
				if (@in != null)
				{
					@in.close();
					@in = null;
				}
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
			if (!isOpen())
			{
				return null;
			}
			return java.io.HistoricalCharsetNames.get(decoder.charset());
		}

		/// <summary>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0.
		/// </summary>
		/// <remarks>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0. Returns -1 if the end of the
		/// reader has been reached. The byte value is either obtained from
		/// converting bytes in this reader's buffer or by first filling the buffer
		/// from the source InputStream and then reading from the buffer.
		/// </remarks>
		/// <returns>
		/// the character read or -1 if the end of the reader has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read()
		{
			lock (@lock)
			{
				if (!isOpen())
				{
					throw new System.IO.IOException("InputStreamReader is closed");
				}
				char[] buf = new char[1];
				return read(buf, 0, 1) != -1 ? buf[0] : -1;
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>length</code>
		/// characters from this reader and stores them
		/// at position
		/// <code>offset</code>
		/// in the character array
		/// <code>buf</code>
		/// . Returns
		/// the number of characters actually read or -1 if the end of the reader has
		/// been reached. The bytes are either obtained from converting bytes in this
		/// reader's buffer or by first filling the buffer from the source
		/// InputStream and then reading from the buffer.
		/// </summary>
		/// <param name="buffer">the array to store the characters read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buf</code>
		/// to store the characters
		/// read from this reader.
		/// </param>
		/// <param name="length">the maximum number of characters to read.</param>
		/// <returns>
		/// the number of characters read or -1 if the end of the reader has
		/// been reached.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>length &lt; 0</code>
		/// , or if
		/// <code>offset + length</code>
		/// is greater than the length of
		/// <code>buf</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read(char[] buffer, int offset, int length)
		{
			lock (@lock)
			{
				if (!isOpen())
				{
					throw new System.IO.IOException("InputStreamReader is closed");
				}
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
				if (length == 0)
				{
					return 0;
				}
				java.nio.CharBuffer @out = java.nio.CharBuffer.wrap(buffer, offset, length);
				java.nio.charset.CoderResult result = java.nio.charset.CoderResult.UNDERFLOW;
				// bytes.remaining() indicates number of bytes in buffer
				// when 1-st time entered, it'll be equal to zero
				bool needInput = !bytes.hasRemaining();
				while (@out.hasRemaining())
				{
					// fill the buffer if needed
					if (needInput)
					{
						try
						{
							if (@in.available() == 0 && @out.position() > offset)
							{
								// we could return the result without blocking read
								break;
							}
						}
						catch (System.IO.IOException)
						{
						}
						// available didn't work so just try the read
						int desiredByteCount = bytes.capacity() - bytes.limit();
						int off = bytes.arrayOffset() + bytes.limit();
						int actualByteCount = @in.read(((byte[])bytes.array()), off, desiredByteCount);
						if (actualByteCount == -1)
						{
							endOfInput = true;
							break;
						}
						else
						{
							if (actualByteCount == 0)
							{
								break;
							}
						}
						bytes.limit(bytes.limit() + actualByteCount);
						needInput = false;
					}
					// decode bytes
					result = decoder.decode(bytes, @out, false);
					if (result.isUnderflow())
					{
						// compact the buffer if no space left
						if (bytes.limit() == bytes.capacity())
						{
							bytes.compact();
							bytes.limit(bytes.position());
							bytes.position(0);
						}
						needInput = true;
					}
					else
					{
						break;
					}
				}
				if (result == java.nio.charset.CoderResult.UNDERFLOW && endOfInput)
				{
					result = decoder.decode(bytes, @out, true);
					decoder.flush(@out);
					decoder.reset();
				}
				if (result.isMalformed() || result.isUnmappable())
				{
					result.throwException();
				}
				return @out.position() - offset == 0 ? -1 : @out.position() - offset;
			}
		}

		private bool isOpen()
		{
			return @in != null;
		}

		/// <summary>Indicates whether this reader is ready to be read without blocking.</summary>
		/// <remarks>
		/// Indicates whether this reader is ready to be read without blocking. If
		/// the result is
		/// <code>true</code>
		/// , the next
		/// <code>read()</code>
		/// will not block. If
		/// the result is
		/// <code>false</code>
		/// then this reader may or may not block when
		/// <code>read()</code>
		/// is called. This implementation returns
		/// <code>true</code>
		/// if
		/// there are bytes available in the buffer or the source stream has bytes
		/// available.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the receiver will not block when
		/// <code>read()</code>
		/// is called,
		/// <code>false</code>
		/// if unknown or blocking will occur.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool ready()
		{
			lock (@lock)
			{
				if (@in == null)
				{
					throw new System.IO.IOException("InputStreamReader is closed");
				}
				try
				{
					return bytes.hasRemaining() || @in.available() > 0;
				}
				catch (System.IO.IOException)
				{
					return false;
				}
			}
		}
	}
}
