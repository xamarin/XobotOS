using Sharpen;

namespace java.io
{
	/// <summary>The base class for all writers.</summary>
	/// <remarks>
	/// The base class for all writers. A writer is a means of writing data to a
	/// target in a character-wise manner. Most output streams expect the
	/// <see cref="flush()">flush()</see>
	/// method to be called before closing the stream, to ensure all
	/// data is actually written out.
	/// <p>
	/// This abstract class does not provide a fully working implementation, so it
	/// needs to be subclassed, and at least the
	/// <see cref="write(char[], int, int)">write(char[], int, int)</see>
	/// ,
	/// <see cref="close()">close()</see>
	/// and
	/// <see cref="flush()">flush()</see>
	/// methods needs to be overridden.
	/// Overriding some of the non-abstract methods is also often advised, since it
	/// might result in higher efficiency.
	/// <p>
	/// Many specialized readers for purposes like reading from a file already exist
	/// in this package.
	/// </remarks>
	/// <seealso cref="Reader">Reader</seealso>
	[Sharpen.Sharpened]
	public abstract class Writer : java.lang.Appendable, java.io.Closeable, java.io.Flushable
	{
		/// <summary>The object used to synchronize access to the writer.</summary>
		/// <remarks>The object used to synchronize access to the writer.</remarks>
		protected internal object @lock;

		/// <summary>
		/// Constructs a new
		/// <code>Writer</code>
		/// with
		/// <code>this</code>
		/// as the object used to
		/// synchronize critical sections.
		/// </summary>
		protected internal Writer()
		{
			@lock = this;
		}

		/// <summary>
		/// Constructs a new
		/// <code>Writer</code>
		/// with
		/// <code>lock</code>
		/// used to synchronize
		/// critical sections.
		/// </summary>
		/// <param name="lock">
		/// the
		/// <code>Object</code>
		/// used to synchronize critical sections.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>lock</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		protected internal Writer(object @lock)
		{
			if (@lock == null)
			{
				throw new System.ArgumentNullException();
			}
			this.@lock = @lock;
		}

		/// <summary>Closes this writer.</summary>
		/// <remarks>
		/// Closes this writer. Implementations of this method should free any
		/// resources associated with the writer.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.AutoCloseable")]
		public abstract void close();

		/// <summary>Flushes this writer.</summary>
		/// <remarks>
		/// Flushes this writer. Implementations of this method should ensure that
		/// all buffered characters are written to the target.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while flushing this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.io.Flushable")]
		public abstract void flush();

		/// <summary>
		/// Writes the entire character buffer
		/// <code>buf</code>
		/// to the target.
		/// </summary>
		/// <param name="buf">the non-null array containing characters to write.</param>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void write(char[] buf)
		{
			write(buf, 0, buf.Length);
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// in
		/// <code>buf</code>
		/// to the target.
		/// </summary>
		/// <param name="buf">the non-null character array to write.</param>
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
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public abstract void write(char[] buf, int offset, int count);

		/// <summary>Writes one character to the target.</summary>
		/// <remarks>
		/// Writes one character to the target. Only the two least significant bytes
		/// of the integer
		/// <code>oneChar</code>
		/// are written.
		/// </remarks>
		/// <param name="oneChar">the character to write to the target.</param>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void write(int oneChar)
		{
			lock (@lock)
			{
				char[] oneCharArray = new char[1];
				oneCharArray[0] = (char)oneChar;
				write(oneCharArray);
			}
		}

		/// <summary>Writes the characters from the specified string to the target.</summary>
		/// <remarks>Writes the characters from the specified string to the target.</remarks>
		/// <param name="str">the non-null string containing the characters to write.</param>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void write(string str)
		{
			write(str, 0, str.Length);
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters from
		/// <code>str</code>
		/// starting at
		/// <code>offset</code>
		/// to the target.
		/// </summary>
		/// <param name="str">the non-null string containing the characters to write.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>str</code>
		/// to write.
		/// </param>
		/// <param name="count">
		/// the number of characters from
		/// <code>str</code>
		/// to write.
		/// </param>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is greater than the length of
		/// <code>str</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void write(string str, int offset, int count)
		{
			if ((offset | count) < 0 || offset > str.Length - count)
			{
				throw new java.lang.StringIndexOutOfBoundsException(str, offset, count);
			}
			char[] buf = new char[count];
			Sharpen.StringHelper.GetCharsForString(str, offset, offset + count, buf, 0);
			lock (@lock)
			{
				write(buf, 0, buf.Length);
			}
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(char c)
		{
			return append(c);
		}

		/// <summary>
		/// Appends the character
		/// <code>c</code>
		/// to the target. This method works the same
		/// way as
		/// <see cref="write(int)">write(int)</see>
		/// .
		/// </summary>
		/// <param name="c">the character to append to the target stream.</param>
		/// <returns>this writer.</returns>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.io.Writer append(char c)
		{
			write(c);
			return this;
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence csq)
		{
			return append(csq);
		}

		/// <summary>
		/// Appends the character sequence
		/// <code>csq</code>
		/// to the target. This method
		/// works the same way as
		/// <code>Writer.write(csq.toString())</code>
		/// . If
		/// <code>csq</code>
		/// is
		/// <code>null</code>
		/// , then the string "null" is written to the target
		/// stream.
		/// </summary>
		/// <param name="csq">the character sequence appended to the target.</param>
		/// <returns>this writer.</returns>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.io.Writer append(java.lang.CharSequence csq)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			write(csq.ToString());
			return this;
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence csq, int 
			start, int end)
		{
			return append(csq, start, end);
		}

		/// <summary>
		/// Appends a subsequence of the character sequence
		/// <code>csq</code>
		/// to the
		/// target. This method works the same way as
		/// <code>Writer.writer(csq.subsequence(start, end).toString())</code>
		/// . If
		/// <code>csq</code>
		/// is
		/// <code>null</code>
		/// , then the specified subsequence of the string "null"
		/// will be written to the target.
		/// </summary>
		/// <param name="csq">the character sequence appended to the target.</param>
		/// <param name="start">
		/// the index of the first char in the character sequence appended
		/// to the target.
		/// </param>
		/// <param name="end">
		/// the index of the character following the last character of the
		/// subsequence appended to the target.
		/// </param>
		/// <returns>this writer.</returns>
		/// <exception cref="IOException">if this writer is closed or another I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &gt; end</code>
		/// ,
		/// <code>start &lt; 0</code>
		/// ,
		/// <code>end &lt; 0</code>
		/// or
		/// either
		/// <code>start</code>
		/// or
		/// <code>end</code>
		/// are greater or equal than
		/// the length of
		/// <code>csq</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.io.Writer append(java.lang.CharSequence csq, int start, int end
			)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			write(csq.SubSequence(start, end).ToString());
			return this;
		}

		/// <summary>Returns true if this writer has encountered and suppressed an error.</summary>
		/// <remarks>
		/// Returns true if this writer has encountered and suppressed an error. Used
		/// by PrintWriters as an alternative to checked exceptions.
		/// </remarks>
		internal virtual bool checkError()
		{
			return false;
		}
	}
}
