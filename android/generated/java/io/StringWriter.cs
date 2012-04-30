using Sharpen;

namespace java.io
{
	/// <summary>
	/// A specialized
	/// <see cref="Writer">Writer</see>
	/// that writes characters to a
	/// <code>StringBuffer</code>
	/// in a sequential manner, appending them in the process. The result can later
	/// be queried using the
	/// <see cref="StringWriter(int)">StringWriter(int)</see>
	/// or
	/// <see cref="ToString()">ToString()</see>
	/// methods.
	/// </summary>
	/// <seealso cref="StringReader">StringReader</seealso>
	[Sharpen.Sharpened]
	public class StringWriter : java.io.Writer
	{
		private java.lang.StringBuffer buf;

		/// <summary>
		/// Constructs a new
		/// <code>StringWriter</code>
		/// which has a
		/// <see cref="java.lang.StringBuffer">java.lang.StringBuffer</see>
		/// allocated with the default size of 16 characters. The
		/// <code>StringBuffer</code>
		/// is also the
		/// <code>lock</code>
		/// used to synchronize access to this
		/// writer.
		/// </summary>
		public StringWriter()
		{
			buf = new java.lang.StringBuffer(16);
			@lock = buf;
		}

		/// <summary>
		/// Constructs a new
		/// <code>StringWriter</code>
		/// which has a
		/// <see cref="java.lang.StringBuffer">java.lang.StringBuffer</see>
		/// allocated with a size of
		/// <code>initialSize</code>
		/// characters. The
		/// <code>StringBuffer</code>
		/// is also the
		/// <code>lock</code>
		/// used to synchronize access to this
		/// writer.
		/// </summary>
		/// <param name="initialSize">the intial size of the target string buffer.</param>
		public StringWriter(int initialSize)
		{
			if (initialSize < 0)
			{
				throw new System.ArgumentException();
			}
			buf = new java.lang.StringBuffer(initialSize);
			@lock = buf;
		}

		/// <summary>Calling this method has no effect.</summary>
		/// <remarks>
		/// Calling this method has no effect. In contrast to most
		/// <code>Writer</code>
		/// subclasses,
		/// the other methods in
		/// <code>StringWriter</code>
		/// do not throw an
		/// <code>IOException</code>
		/// if
		/// <code>close()</code>
		/// has been called.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this writer.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void close()
		{
		}

		/// <summary>Calling this method has no effect.</summary>
		/// <remarks>Calling this method has no effect.</remarks>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void flush()
		{
		}

		/// <summary>
		/// Gets a reference to this writer's internal
		/// <see cref="java.lang.StringBuffer">java.lang.StringBuffer</see>
		/// . Any
		/// changes made to the returned buffer are reflected in this writer.
		/// </summary>
		/// <returns>
		/// a reference to this writer's internal
		/// <code>StringBuffer</code>
		/// .
		/// </returns>
		public virtual java.lang.StringBuffer getBuffer()
		{
			return buf;
		}

		/// <summary>Gets a copy of the contents of this writer as a string.</summary>
		/// <remarks>Gets a copy of the contents of this writer as a string.</remarks>
		/// <returns>this writer's contents as a string.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return buf.ToString();
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters starting at
		/// <code>offset</code>
		/// in
		/// <code>buf</code>
		/// to this writer's
		/// <code>StringBuffer</code>
		/// .
		/// </summary>
		/// <param name="chars">the non-null character array to write.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>chars</code>
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
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] chars, int offset, int count)
		{
			java.util.Arrays.checkOffsetAndCount(chars.Length, offset, count);
			if (count == 0)
			{
				return;
			}
			buf.append(chars, offset, count);
		}

		/// <summary>
		/// Writes one character to this writer's
		/// <code>StringBuffer</code>
		/// . Only the two
		/// least significant bytes of the integer
		/// <code>oneChar</code>
		/// are written.
		/// </summary>
		/// <param name="oneChar">
		/// the character to write to this writer's
		/// <code>StringBuffer</code>
		/// .
		/// </param>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(int oneChar)
		{
			buf.append((char)oneChar);
		}

		/// <summary>
		/// Writes the characters from the specified string to this writer's
		/// <code>StringBuffer</code>
		/// .
		/// </summary>
		/// <param name="str">the non-null string containing the characters to write.</param>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str)
		{
			buf.append(str);
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters from
		/// <code>str</code>
		/// starting at
		/// <code>offset</code>
		/// to this writer's
		/// <code>StringBuffer</code>
		/// .
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
		/// <exception cref="java.lang.StringIndexOutOfBoundsException">
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
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str, int offset, int count)
		{
			string sub = Sharpen.StringHelper.Substring(str, offset, offset + count);
			buf.append(sub);
		}

		/// <summary>
		/// Appends the character
		/// <code>c</code>
		/// to this writer's
		/// <code>StringBuffer</code>
		/// .
		/// This method works the same way as
		/// <see cref="write(int)">write(int)</see>
		/// .
		/// </summary>
		/// <param name="c">the character to append to the target stream.</param>
		/// <returns>this writer.</returns>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(char c)
		{
			write(c);
			return this;
		}

		/// <summary>
		/// Appends the character sequence
		/// <code>csq</code>
		/// to this writer's
		/// <code>StringBuffer</code>
		/// . This method works the same way as
		/// <code>StringWriter.write(csq.toString())</code>
		/// . If
		/// <code>csq</code>
		/// is
		/// <code>null</code>
		/// , then
		/// the string "null" is written to the target stream.
		/// </summary>
		/// <param name="csq">the character sequence appended to the target.</param>
		/// <returns>this writer.</returns>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(java.lang.CharSequence csq)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			write(csq.ToString());
			return this;
		}

		/// <summary>
		/// Appends a subsequence of the character sequence
		/// <code>csq</code>
		/// to this
		/// writer's
		/// <code>StringBuffer</code>
		/// . This method works the same way as
		/// <code>StringWriter.writer(csq.subsequence(start, end).toString())</code>
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
