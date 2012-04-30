using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="Reader">Reader</see>
	/// and <em>buffers</em> the input. Expensive
	/// interaction with the underlying reader is minimized, since most (smaller)
	/// requests can be satisfied by accessing the buffer alone. The drawback is that
	/// some extra space is required to hold the buffer and that copying takes place
	/// when filling that buffer, but this is usually outweighed by the performance
	/// benefits.
	/// <p/>A typical application pattern for the class looks like this:<p/>
	/// <pre>
	/// BufferedReader buf = new BufferedReader(new FileReader(&quot;file.java&quot;));
	/// </pre>
	/// </summary>
	/// <seealso cref="BufferedWriter">BufferedWriter</seealso>
	/// <since>1.1</since>
	[Sharpen.Sharpened]
	public class BufferedReader : java.io.Reader
	{
		private java.io.Reader @in;

		/// <summary>The characters that can be read and refilled in bulk.</summary>
		/// <remarks>
		/// The characters that can be read and refilled in bulk. We maintain three
		/// indices into this buffer:<pre>
		/// { X X X X X X X X X X X X - - }
		/// ^     ^             ^
		/// |     |             |
		/// mark   pos           end</pre>
		/// Pos points to the next readable character. End is one greater than the
		/// last readable character. When
		/// <code>pos == end</code>
		/// , the buffer is empty and
		/// must be
		/// <see cref="fillBuf()">filled</see>
		/// before characters can be read.
		/// <p>Mark is the value pos will be set to on calls to
		/// <see cref="reset()">reset()</see>
		/// . Its
		/// value is in the range
		/// <code>[0...pos]</code>
		/// . If the mark is
		/// <code>-1</code>
		/// , the
		/// buffer cannot be reset.
		/// <p>MarkLimit limits the distance between the mark and the pos. When this
		/// limit is exceeded,
		/// <see cref="reset()">reset()</see>
		/// is permitted (but not required) to
		/// throw an exception. For shorter distances,
		/// <see cref="reset()">reset()</see>
		/// shall not throw
		/// (unless the reader is closed).
		/// </remarks>
		private char[] buf;

		private int pos;

		private int end;

		private int _mark = -1;

		private int markLimit = -1;

		/// <summary>
		/// Constructs a new
		/// <code>BufferedReader</code>
		/// , providing
		/// <code>in</code>
		/// with a buffer
		/// of 8192 characters.
		/// </summary>
		/// <param name="in">
		/// the
		/// <code>Reader</code>
		/// the buffer reads from.
		/// </param>
		public BufferedReader(java.io.Reader @in) : this(@in, 8192)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>BufferedReader</code>
		/// , providing
		/// <code>in</code>
		/// with
		/// <code>size</code>
		/// characters
		/// of buffer.
		/// </summary>
		/// <param name="in">
		/// the
		/// <code>InputStream</code>
		/// the buffer reads from.
		/// </param>
		/// <param name="size">the size of buffer in characters.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>size &lt;= 0</code>
		/// .
		/// </exception>
		public BufferedReader(java.io.Reader @in, int size) : base(@in)
		{
			if (size <= 0)
			{
				throw new System.ArgumentException("size <= 0");
			}
			this.@in = @in;
			buf = new char[size];
		}

		/// <summary>Closes this reader.</summary>
		/// <remarks>
		/// Closes this reader. This implementation closes the buffered source reader
		/// and releases the buffer. Nothing is done if this reader has already been
		/// closed.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this reader.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void close()
		{
			lock (@lock)
			{
				if (!isClosed())
				{
					@in.close();
					buf = null;
				}
			}
		}

		/// <summary>Populates the buffer with data.</summary>
		/// <remarks>
		/// Populates the buffer with data. It is an error to call this method when
		/// the buffer still contains data; ie. if
		/// <code>pos &lt; end</code>
		/// .
		/// </remarks>
		/// <returns>
		/// the number of bytes read into the buffer, or -1 if the end of the
		/// source stream has been reached.
		/// </returns>
		/// <exception cref="System.IO.IOException"></exception>
		private int fillBuf()
		{
			// assert(pos == end);
			if (_mark == -1 || (pos - _mark >= markLimit))
			{
				int result = @in.read(buf, 0, buf.Length);
				if (result > 0)
				{
					_mark = -1;
					pos = 0;
					end = result;
				}
				return result;
			}
			if (_mark == 0 && markLimit > buf.Length)
			{
				int newLength = buf.Length * 2;
				if (newLength > markLimit)
				{
					newLength = markLimit;
				}
				char[] newbuf = new char[newLength];
				System.Array.Copy(buf, 0, newbuf, 0, buf.Length);
				buf = newbuf;
			}
			else
			{
				if (_mark > 0)
				{
					System.Array.Copy(buf, _mark, buf, 0, buf.Length - _mark);
					pos -= _mark;
					end -= _mark;
					_mark = 0;
				}
			}
			int count = @in.read(buf, pos, buf.Length - pos);
			if (count != -1)
			{
				end += count;
			}
			return count;
		}

		/// <summary>Indicates whether or not this reader is closed.</summary>
		/// <remarks>Indicates whether or not this reader is closed.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this reader is closed,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		private bool isClosed()
		{
			return buf == null;
		}

		/// <summary>Sets a mark position in this reader.</summary>
		/// <remarks>
		/// Sets a mark position in this reader. The parameter
		/// <code>markLimit</code>
		/// indicates how many characters can be read before the mark is invalidated.
		/// Calling
		/// <code>reset()</code>
		/// will reposition the reader back to the marked
		/// position if
		/// <code>markLimit</code>
		/// has not been surpassed.
		/// </remarks>
		/// <param name="markLimit">
		/// the number of characters that can be read before the mark is
		/// invalidated.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>markLimit &lt; 0</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if an error occurs while setting a mark in this reader.
		/// 	</exception>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void mark(int markLimit)
		{
			if (markLimit < 0)
			{
				throw new System.ArgumentException();
			}
			lock (@lock)
			{
				checkNotClosed();
				this.markLimit = markLimit;
				_mark = pos;
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void checkNotClosed()
		{
			if (isClosed())
			{
				throw new System.IO.IOException("BufferedReader is closed");
			}
		}

		/// <summary>
		/// Indicates whether this reader supports the
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// methods. This implementation returns
		/// <code>true</code>
		/// .
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// for
		/// <code>BufferedReader</code>
		/// .
		/// </returns>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool markSupported()
		{
			return true;
		}

		/// <summary>
		/// Reads a single character from this reader and returns it with the two
		/// higher-order bytes set to 0.
		/// </summary>
		/// <remarks>
		/// Reads a single character from this reader and returns it with the two
		/// higher-order bytes set to 0. If possible, BufferedReader returns a
		/// character from the buffer. If there are no characters available in the
		/// buffer, it fills the buffer and then returns a character. It returns -1
		/// if there are no more characters in the source reader.
		/// </remarks>
		/// <returns>
		/// the character read or -1 if the end of the source reader has been
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
				checkNotClosed();
				if (pos < end || fillBuf() != -1)
				{
					return buf[pos++];
				}
				return -1;
			}
		}

		/// <summary>
		/// Reads at most
		/// <code>length</code>
		/// characters from this reader and stores them
		/// at
		/// <code>offset</code>
		/// in the character array
		/// <code>buffer</code>
		/// . Returns the
		/// number of characters actually read or -1 if the end of the source reader
		/// has been reached. If all the buffered characters have been used, a mark
		/// has not been set and the requested number of characters is larger than
		/// this readers buffer size, BufferedReader bypasses the buffer and simply
		/// places the results directly into
		/// <code>buffer</code>
		/// .
		/// </summary>
		/// <param name="buffer">the character array to store the characters read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the bytes read
		/// from this reader.
		/// </param>
		/// <param name="length">
		/// the maximum number of characters to read, must be
		/// non-negative.
		/// </param>
		/// <returns>
		/// number of characters read or -1 if the end of the source reader
		/// has been reached.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>length &lt; 0</code>
		/// , or if
		/// <code>offset + length</code>
		/// is greater than the size of
		/// <code>buffer</code>
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
				checkNotClosed();
				java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
				int outstanding = length;
				while (outstanding > 0)
				{
					int available = end - pos;
					if (available > 0)
					{
						int count = available >= outstanding ? outstanding : available;
						System.Array.Copy(buf, pos, buffer, offset, count);
						pos += count;
						offset += count;
						outstanding -= count;
					}
					if (outstanding == 0 || (outstanding < length && !@in.ready()))
					{
						break;
					}
					// assert(pos == end);
					if ((_mark == -1 || (pos - _mark >= markLimit)) && outstanding >= buf.Length)
					{
						int count = @in.read(buffer, offset, outstanding);
						if (count > 0)
						{
							outstanding -= count;
							_mark = -1;
						}
						break;
					}
					// assume the source stream gave us all that it could
					if (fillBuf() == -1)
					{
						break;
					}
				}
				// source is exhausted
				int count_1 = length - outstanding;
				return (count_1 > 0 || count_1 == length) ? count_1 : -1;
			}
		}

		/// <summary>Peeks at the next input character, refilling the buffer if necessary.</summary>
		/// <remarks>
		/// Peeks at the next input character, refilling the buffer if necessary. If
		/// this character is a newline character ("\n"), it is discarded.
		/// </remarks>
		/// <exception cref="System.IO.IOException"></exception>
		internal void chompNewline()
		{
			if ((pos != end || fillBuf() != -1) && buf[pos] == '\n')
			{
				pos++;
			}
		}

		/// <summary>Returns the next line of text available from this reader.</summary>
		/// <remarks>
		/// Returns the next line of text available from this reader. A line is
		/// represented by zero or more characters followed by
		/// <code>'\n'</code>
		/// ,
		/// <code>'\r'</code>
		/// ,
		/// <code>"\r\n"</code>
		/// or the end of the reader. The string does
		/// not include the newline sequence.
		/// </remarks>
		/// <returns>
		/// the contents of the line or
		/// <code>null</code>
		/// if no characters were
		/// read before the end of the reader has been reached.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual string readLine()
		{
			lock (@lock)
			{
				checkNotClosed();
				if (pos == end && fillBuf() == -1)
				{
					return null;
				}
				{
					for (int charPos = pos; charPos < end; charPos++)
					{
						char ch = buf[charPos];
						if (ch > '\r')
						{
							continue;
						}
						if (ch == '\n')
						{
							string res = new string(buf, pos, charPos - pos);
							pos = charPos + 1;
							return res;
						}
						else
						{
							if (ch == '\r')
							{
								string res = new string(buf, pos, charPos - pos);
								pos = charPos + 1;
								if (((pos < end) || (fillBuf() != -1)) && (buf[pos] == '\n'))
								{
									pos++;
								}
								return res;
							}
						}
					}
				}
				char eol = '\0';
				java.lang.StringBuilder result = new java.lang.StringBuilder(80);
				result.append(buf, pos, end - pos);
				while (true)
				{
					pos = end;
					if (eol == '\n')
					{
						return result.ToString();
					}
					// attempt to fill buffer
					if (fillBuf() == -1)
					{
						// characters or null.
						return result.Length > 0 || eol != '\0' ? result.ToString() : null;
					}
					{
						for (int charPos_1 = pos; charPos_1 < end; charPos_1++)
						{
							char c = buf[charPos_1];
							if (eol == '\0')
							{
								if ((c == '\n' || c == '\r'))
								{
									eol = c;
								}
							}
							else
							{
								if (eol == '\r' && c == '\n')
								{
									if (charPos_1 > pos)
									{
										result.append(buf, pos, charPos_1 - pos - 1);
									}
									pos = charPos_1 + 1;
									return result.ToString();
								}
								else
								{
									if (charPos_1 > pos)
									{
										result.append(buf, pos, charPos_1 - pos - 1);
									}
									pos = charPos_1;
									return result.ToString();
								}
							}
						}
					}
					if (eol == '\0')
					{
						result.append(buf, pos, end - pos);
					}
					else
					{
						result.append(buf, pos, end - pos - 1);
					}
				}
			}
		}

		/// <summary>Indicates whether this reader is ready to be read without blocking.</summary>
		/// <remarks>Indicates whether this reader is ready to be read without blocking.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this reader will not block when
		/// <code>read</code>
		/// is
		/// called,
		/// <code>false</code>
		/// if unknown or blocking will occur.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <seealso cref="read()">read()</seealso>
		/// <seealso cref="read(char[], int, int)">read(char[], int, int)</seealso>
		/// <seealso cref="readLine()">readLine()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool ready()
		{
			lock (@lock)
			{
				checkNotClosed();
				return ((end - pos) > 0) || @in.ready();
			}
		}

		/// <summary>
		/// Resets this reader's position to the last
		/// <code>mark()</code>
		/// location.
		/// Invocations of
		/// <code>read()</code>
		/// and
		/// <code>skip()</code>
		/// will occur from this new
		/// location.
		/// </summary>
		/// <exception cref="IOException">if this reader is closed or no mark has been set.</exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void reset()
		{
			lock (@lock)
			{
				checkNotClosed();
				if (_mark == -1)
				{
					throw new System.IO.IOException("Invalid mark");
				}
				pos = _mark;
			}
		}

		/// <summary>
		/// Skips
		/// <code>byteCount</code>
		/// bytes in this stream. Subsequent calls to
		/// <code>read</code>
		/// will not return these bytes unless
		/// <code>reset</code>
		/// is
		/// used.
		/// Skipping characters may invalidate a mark if
		/// <code>markLimit</code>
		/// is surpassed.
		/// </summary>
		/// <param name="byteCount">the maximum number of characters to skip.</param>
		/// <returns>the number of characters actually skipped.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>byteCount &lt; 0</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override long skip(long byteCount)
		{
			if (byteCount < 0)
			{
				throw new System.ArgumentException("byteCount < 0: " + byteCount);
			}
			lock (@lock)
			{
				checkNotClosed();
				if (byteCount < 1)
				{
					return 0;
				}
				if (end - pos >= byteCount)
				{
					pos += (int)(byteCount);
					return byteCount;
				}
				long read_1 = end - pos;
				pos = end;
				while (read_1 < byteCount)
				{
					if (fillBuf() == -1)
					{
						return read_1;
					}
					if (end - pos >= byteCount - read_1)
					{
						pos += (int)(byteCount - read_1);
						return byteCount;
					}
					// Couldn't get all the characters, skip what we read
					read_1 += (end - pos);
					pos = end;
				}
				return byteCount;
			}
		}
	}
}
