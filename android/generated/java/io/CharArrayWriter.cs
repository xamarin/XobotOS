using Sharpen;

namespace java.io
{
	/// <summary>
	/// A specialized
	/// <see cref="Writer">Writer</see>
	/// for class for writing content to an (internal)
	/// char array. As bytes are written to this writer, the char array may be
	/// expanded to hold more characters. When the writing is considered to be
	/// finished, a copy of the char array can be requested from the class.
	/// </summary>
	/// <seealso cref="CharArrayReader">CharArrayReader</seealso>
	[Sharpen.Sharpened]
	public class CharArrayWriter : java.io.Writer
	{
		/// <summary>The buffer for characters.</summary>
		/// <remarks>The buffer for characters.</remarks>
		protected internal char[] buf;

		/// <summary>The ending index of the buffer.</summary>
		/// <remarks>The ending index of the buffer.</remarks>
		protected internal int count;

		/// <summary>
		/// Constructs a new
		/// <code>CharArrayWriter</code>
		/// which has a buffer allocated
		/// with the default size of 32 characters. This buffer is also used as the
		/// <code>lock</code>
		/// to synchronize access to this writer.
		/// </summary>
		public CharArrayWriter()
		{
			buf = new char[32];
			@lock = buf;
		}

		/// <summary>
		/// Constructs a new
		/// <code>CharArrayWriter</code>
		/// which has a buffer allocated
		/// with the size of
		/// <code>initialSize</code>
		/// characters. The buffer is also used
		/// as the
		/// <code>lock</code>
		/// to synchronize access to this writer.
		/// </summary>
		/// <param name="initialSize">the initial size of this CharArrayWriters buffer.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>initialSize &lt; 0</code>
		/// .
		/// </exception>
		public CharArrayWriter(int initialSize)
		{
			if (initialSize < 0)
			{
				throw new System.ArgumentException("size < 0");
			}
			buf = new char[initialSize];
			@lock = buf;
		}

		/// <summary>Closes this writer.</summary>
		/// <remarks>
		/// Closes this writer. The implementation in
		/// <code>CharArrayWriter</code>
		/// does nothing.
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void close()
		{
		}

		private void expand(int i)
		{
			if (count + i <= buf.Length)
			{
				return;
			}
			int newLen = System.Math.Max(2 * buf.Length, count + i);
			char[] newbuf = new char[newLen];
			System.Array.Copy(buf, 0, newbuf, 0, count);
			buf = newbuf;
		}

		/// <summary>Flushes this writer.</summary>
		/// <remarks>
		/// Flushes this writer. The implementation in
		/// <code>CharArrayWriter</code>
		/// does nothing.
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void flush()
		{
		}

		/// <summary>Resets this writer.</summary>
		/// <remarks>
		/// Resets this writer. The current write position is reset to the beginning
		/// of the buffer. All written characters are lost and the size of this
		/// writer is set to 0.
		/// </remarks>
		public virtual void reset()
		{
			lock (@lock)
			{
				count = 0;
			}
		}

		/// <summary>
		/// Returns the size of this writer, that is the number of characters it
		/// stores.
		/// </summary>
		/// <remarks>
		/// Returns the size of this writer, that is the number of characters it
		/// stores. This number changes if this writer is reset or when more
		/// characters are written to it.
		/// </remarks>
		/// <returns>this CharArrayWriter's current size in characters.</returns>
		public virtual int size()
		{
			lock (@lock)
			{
				return count;
			}
		}

		/// <summary>Returns the contents of the receiver as a char array.</summary>
		/// <remarks>
		/// Returns the contents of the receiver as a char array. The array returned
		/// is a copy and any modifications made to this writer after calling this
		/// method are not reflected in the result.
		/// </remarks>
		/// <returns>this CharArrayWriter's contents as a new char array.</returns>
		public virtual char[] toCharArray()
		{
			lock (@lock)
			{
				char[] result = new char[count];
				System.Array.Copy(buf, 0, result, 0, count);
				return result;
			}
		}

		/// <summary>
		/// Returns the contents of this
		/// <code>CharArrayWriter</code>
		/// as a string. The
		/// string returned is a copy and any modifications made to this writer after
		/// calling this method are not reflected in the result.
		/// </summary>
		/// <returns>this CharArrayWriters contents as a new string.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			lock (@lock)
			{
				return new string(buf, 0, count);
			}
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// in
		/// <code>c</code>
		/// to this writer.
		/// </summary>
		/// <param name="buffer">the non-null array containing characters to write.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>buf</code>
		/// to write.
		/// </param>
		/// <param name="len">maximum number of characters to write.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>len &lt; 0</code>
		/// , or if
		/// <code>offset + len</code>
		/// is bigger than the size of
		/// <code>c</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] buffer, int offset, int len)
		{
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, len);
			lock (@lock)
			{
				expand(len);
				System.Array.Copy(buffer, offset, this.buf, this.count, len);
				this.count += len;
			}
		}

		/// <summary>
		/// Writes the specified character
		/// <code>oneChar</code>
		/// to this writer.
		/// This implementation writes the two low order bytes of the integer
		/// <code>oneChar</code>
		/// to the buffer.
		/// </summary>
		/// <param name="oneChar">the character to write.</param>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(int oneChar)
		{
			lock (@lock)
			{
				expand(1);
				buf[count++] = (char)oneChar;
			}
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// from
		/// the string
		/// <code>str</code>
		/// to this CharArrayWriter.
		/// </summary>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>str</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="java.lang.StringIndexOutOfBoundsException">
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
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str, int offset, int count)
		{
			if (str == null)
			{
				throw new System.ArgumentNullException("str == null");
			}
			if ((offset | count) < 0 || offset > str.Length - count)
			{
				throw new java.lang.StringIndexOutOfBoundsException(str, offset, count);
			}
			lock (@lock)
			{
				expand(count);
				Sharpen.StringHelper.GetCharsForString(str, offset, offset + count, buf, this.count
					);
				this.count += count;
			}
		}

		/// <summary>
		/// Writes the contents of this
		/// <code>CharArrayWriter</code>
		/// to another
		/// <code>Writer</code>
		/// . The output is all the characters that have been written to the
		/// receiver since the last reset or since it was created.
		/// </summary>
		/// <param name="out">
		/// the non-null
		/// <code>Writer</code>
		/// on which to write the contents.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>out</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if an error occurs attempting to write out the contents.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void writeTo(java.io.Writer @out)
		{
			lock (@lock)
			{
				@out.write(buf, 0, count);
			}
		}

		/// <summary>
		/// Appends a char
		/// <code>c</code>
		/// to the
		/// <code>CharArrayWriter</code>
		/// . The method works
		/// the same way as
		/// <code>write(c)</code>
		/// .
		/// </summary>
		/// <param name="c">the character appended to the CharArrayWriter.</param>
		/// <returns>this CharArrayWriter.</returns>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(char c)
		{
			write(c);
			return this;
		}

		/// <summary>
		/// Appends a
		/// <code>CharSequence</code>
		/// to the
		/// <code>CharArrayWriter</code>
		/// . The method
		/// works the same way as
		/// <code>write(csq.toString())</code>
		/// . If
		/// <code>csq</code>
		/// is
		/// <code>null</code>
		/// , then it will be substituted with the string
		/// <code>"null"</code>
		/// .
		/// </summary>
		/// <param name="csq">
		/// the
		/// <code>CharSequence</code>
		/// appended to the
		/// <code>CharArrayWriter</code>
		/// , may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <returns>this CharArrayWriter.</returns>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(java.lang.CharSequence csq)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			append(csq, 0, csq.Length);
			return this;
		}

		/// <summary>
		/// Append a subsequence of a
		/// <code>CharSequence</code>
		/// to the
		/// <code>CharArrayWriter</code>
		/// . The first and last characters of the subsequence are
		/// specified by the parameters
		/// <code>start</code>
		/// and
		/// <code>end</code>
		/// . A call to
		/// <code>CharArrayWriter.append(csq)</code>
		/// works the same way as
		/// <code>CharArrayWriter.write(csq.subSequence(start, end).toString)</code>
		/// . If
		/// <code>csq</code>
		/// is
		/// <code>null</code>
		/// , then it will be substituted with the string
		/// <code>"null"</code>
		/// .
		/// </summary>
		/// <param name="csq">
		/// the
		/// <code>CharSequence</code>
		/// appended to the
		/// <code>CharArrayWriter</code>
		/// , may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <param name="start">
		/// the index of the first character in the
		/// <code>CharSequence</code>
		/// appended to the
		/// <code>CharArrayWriter</code>
		/// .
		/// </param>
		/// <param name="end">
		/// the index of the character after the last one in the
		/// <code>CharSequence</code>
		/// appended to the
		/// <code>CharArrayWriter</code>
		/// .
		/// </param>
		/// <returns>this CharArrayWriter.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// ,
		/// <code>end &lt; 0</code>
		/// ,
		/// <code>start &gt; end</code>
		/// ,
		/// or if
		/// <code>end</code>
		/// is greater than the length of
		/// <code>csq</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(java.lang.CharSequence csq, int start, int 
			end)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			string output = csq.SubSequence(start, end).ToString();
			write(output, 0, output.Length);
			return this;
		}
	}
}
