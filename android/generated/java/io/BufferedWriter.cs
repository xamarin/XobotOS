using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="Writer">Writer</see>
	/// and <em>buffers</em> the output. Expensive
	/// interaction with the underlying reader is minimized, since most (smaller)
	/// requests can be satisfied by accessing the buffer alone. The drawback is that
	/// some extra space is required to hold the buffer and that copying takes place
	/// when filling that buffer, but this is usually outweighed by the performance
	/// benefits.
	/// <p/>A typical application pattern for the class looks like this:<p/>
	/// <pre>
	/// BufferedWriter buf = new BufferedWriter(new FileWriter(&quot;file.java&quot;));
	/// </pre>
	/// </summary>
	/// <seealso cref="BufferedReader">BufferedReader</seealso>
	[Sharpen.Sharpened]
	public class BufferedWriter : java.io.Writer
	{
		private java.io.Writer @out;

		private char[] buf;

		private int pos;

		/// <summary>
		/// Constructs a new
		/// <code>BufferedWriter</code>
		/// , providing
		/// <code>out</code>
		/// with a buffer
		/// of 8192 bytes.
		/// </summary>
		/// <param name="out">
		/// the
		/// <code>Writer</code>
		/// the buffer writes to.
		/// </param>
		public BufferedWriter(java.io.Writer @out) : this(@out, 8192)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>BufferedWriter</code>
		/// , providing
		/// <code>out</code>
		/// with
		/// <code>size</code>
		/// bytes
		/// of buffer.
		/// </summary>
		/// <param name="out">
		/// the
		/// <code>OutputStream</code>
		/// the buffer writes to.
		/// </param>
		/// <param name="size">the size of buffer in bytes.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>size &lt;= 0</code>
		/// .
		/// </exception>
		public BufferedWriter(java.io.Writer @out, int size) : base(@out)
		{
			if (size <= 0)
			{
				throw new System.ArgumentException("size <= 0");
			}
			this.@out = @out;
			this.buf = new char[size];
		}

		/// <summary>Closes this writer.</summary>
		/// <remarks>
		/// Closes this writer. The contents of the buffer are flushed, the target
		/// writer is closed, and the buffer is released. Only the first invocation
		/// of close has any effect.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void close()
		{
			lock (@lock)
			{
				if (isClosed())
				{
					return;
				}
				System.Exception thrown = null;
				try
				{
					flushInternal();
				}
				catch (System.Exception e)
				{
					thrown = e;
				}
				buf = null;
				try
				{
					@out.close();
				}
				catch (System.Exception e)
				{
					if (thrown == null)
					{
						thrown = e;
					}
				}
				@out = null;
				if (thrown != null)
				{
					Sharpen.Util.Throw(thrown);
				}
			}
		}

		/// <summary>Flushes this writer.</summary>
		/// <remarks>
		/// Flushes this writer. The contents of the buffer are committed to the
		/// target writer and it is then flushed.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while flushing this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void flush()
		{
			lock (@lock)
			{
				checkNotClosed();
				flushInternal();
				@out.flush();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void checkNotClosed()
		{
			if (isClosed())
			{
				throw new System.IO.IOException("BufferedWriter is closed");
			}
		}

		/// <summary>Flushes the internal buffer.</summary>
		/// <remarks>Flushes the internal buffer.</remarks>
		/// <exception cref="System.IO.IOException"></exception>
		private void flushInternal()
		{
			if (pos > 0)
			{
				@out.write(buf, 0, pos);
			}
			pos = 0;
		}

		/// <summary>Indicates whether this writer is closed.</summary>
		/// <remarks>Indicates whether this writer is closed.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this writer is closed,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		private bool isClosed()
		{
			return @out == null;
		}

		/// <summary>Writes a newline to this writer.</summary>
		/// <remarks>
		/// Writes a newline to this writer. On Android, this is
		/// <code>"\n"</code>
		/// .
		/// The target writer may or may not be flushed when a newline is written.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs attempting to write to this writer.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void newLine()
		{
			write(System.Environment.NewLine);
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// in
		/// <code>cbuf</code>
		/// to this writer. If
		/// <code>count</code>
		/// is greater than this
		/// writer's buffer, then the buffer is flushed and the characters are
		/// written directly to the target writer.
		/// </summary>
		/// <param name="cbuf">the array containing characters to write.</param>
		/// <param name="offset">
		/// the start position in
		/// <code>cbuf</code>
		/// for retrieving characters.
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
		/// <code>cbuf</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] cbuf, int offset, int count)
		{
			lock (@lock)
			{
				checkNotClosed();
				if (cbuf == null)
				{
					throw new System.ArgumentNullException("buffer == null");
				}
				java.util.Arrays.checkOffsetAndCount(cbuf.Length, offset, count);
				if (pos == 0 && count >= this.buf.Length)
				{
					@out.write(cbuf, offset, count);
					return;
				}
				int available = this.buf.Length - pos;
				if (count < available)
				{
					available = count;
				}
				if (available > 0)
				{
					System.Array.Copy(cbuf, offset, this.buf, pos, available);
					pos += available;
				}
				if (pos == this.buf.Length)
				{
					@out.write(this.buf, 0, this.buf.Length);
					pos = 0;
					if (count > available)
					{
						offset += available;
						available = count - available;
						if (available >= this.buf.Length)
						{
							@out.write(cbuf, offset, available);
							return;
						}
						System.Array.Copy(cbuf, offset, this.buf, pos, available);
						pos += available;
					}
				}
			}
		}

		/// <summary>
		/// Writes the character
		/// <code>oneChar</code>
		/// to this writer. If the buffer
		/// gets full by writing this character, this writer is flushed. Only the
		/// lower two bytes of the integer
		/// <code>oneChar</code>
		/// are written.
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
				checkNotClosed();
				if (pos >= buf.Length)
				{
					@out.write(buf, 0, buf.Length);
					pos = 0;
				}
				buf[pos++] = (char)oneChar;
			}
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// in
		/// <code>str</code>
		/// to this writer. If
		/// <code>count</code>
		/// is greater than this writer's buffer,
		/// then this writer is flushed and the remaining characters are written
		/// directly to the target writer. If count is negative no characters are
		/// written to the buffer. This differs from the behavior of the superclass.
		/// </summary>
		/// <param name="str">the non-null String containing characters to write.</param>
		/// <param name="offset">
		/// the start position in
		/// <code>str</code>
		/// for retrieving characters.
		/// </param>
		/// <param name="count">maximum number of characters to write.</param>
		/// <exception cref="IOException">
		/// if this writer has already been closed or another I/O error
		/// occurs.
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>offset + count</code>
		/// is greater
		/// than the length of
		/// <code>str</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str, int offset, int count)
		{
			lock (@lock)
			{
				checkNotClosed();
				if (count <= 0)
				{
					return;
				}
				if (offset < 0 || offset > str.Length - count)
				{
					throw new java.lang.StringIndexOutOfBoundsException(str, offset, count);
				}
				if (pos == 0 && count >= buf.Length)
				{
					char[] chars = new char[count];
					Sharpen.StringHelper.GetCharsForString(str, offset, offset + count, chars, 0);
					@out.write(chars, 0, count);
					return;
				}
				int available = buf.Length - pos;
				if (count < available)
				{
					available = count;
				}
				if (available > 0)
				{
					Sharpen.StringHelper.GetCharsForString(str, offset, offset + available, buf, pos);
					pos += available;
				}
				if (pos == buf.Length)
				{
					@out.write(this.buf, 0, this.buf.Length);
					pos = 0;
					if (count > available)
					{
						offset += available;
						available = count - available;
						if (available >= buf.Length)
						{
							char[] chars = new char[count];
							Sharpen.StringHelper.GetCharsForString(str, offset, offset + available, chars, 0);
							@out.write(chars, 0, available);
							return;
						}
						Sharpen.StringHelper.GetCharsForString(str, offset, offset + available, buf, pos);
						pos += available;
					}
				}
			}
		}
	}
}
