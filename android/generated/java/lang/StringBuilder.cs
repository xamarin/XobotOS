using Sharpen;

namespace java.lang
{
	/// <summary>
	/// A modifiable
	/// <see cref="CharSequence">sequence of characters</see>
	/// for use in creating
	/// strings. This class is intended as a direct replacement of
	/// <see cref="StringBuffer">StringBuffer</see>
	/// for non-concurrent use; unlike
	/// <code>StringBuffer</code>
	/// this
	/// class is not synchronized.
	/// <p>For particularly complex string-building needs, consider
	/// <see cref="java.util.Formatter">java.util.Formatter</see>
	/// .
	/// <p>The majority of the modification methods on this class return
	/// <code>this</code>
	/// so that method calls can be chained together. For example:
	/// <code>new StringBuilder("a").append("b").append("c").toString()</code>
	/// .
	/// </summary>
	/// <seealso cref="CharSequence">CharSequence</seealso>
	/// <seealso cref="Appendable">Appendable</seealso>
	/// <seealso cref="StringBuffer">StringBuffer</seealso>
	/// <seealso cref="string">string</seealso>
	/// <seealso cref="string.Format(string, object[])">string.Format(string, object[])</seealso>
	/// <since>1.5</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public sealed partial class StringBuilder : java.lang.AbstractStringBuilder, java.lang.Appendable
		, java.lang.CharSequence
	{
		internal const long serialVersionUID = 4383685877147921099L;

		/// <summary>
		/// Constructs an instance with an initial capacity of
		/// <code>16</code>
		/// .
		/// </summary>
		/// <seealso cref="AbstractStringBuilder.capacity()">AbstractStringBuilder.capacity()
		/// 	</seealso>
		public StringBuilder()
		{
		}

		/// <summary>Constructs an instance with the specified capacity.</summary>
		/// <remarks>Constructs an instance with the specified capacity.</remarks>
		/// <param name="capacity">the initial capacity to use.</param>
		/// <exception cref="NegativeArraySizeException">
		/// if the specified
		/// <code>capacity</code>
		/// is negative.
		/// </exception>
		/// <seealso cref="AbstractStringBuilder.capacity()">AbstractStringBuilder.capacity()
		/// 	</seealso>
		public StringBuilder(int capacity_1) : base(capacity_1)
		{
		}

		/// <summary>
		/// Constructs an instance that's initialized with the contents of the
		/// specified
		/// <code>CharSequence</code>
		/// . The capacity of the new builder will be
		/// the length of the
		/// <code>CharSequence</code>
		/// plus 16.
		/// </summary>
		/// <param name="seq">
		/// the
		/// <code>CharSequence</code>
		/// to copy into the builder.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>seq</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public StringBuilder(java.lang.CharSequence seq) : base(seq.ToString())
		{
		}

		/// <summary>
		/// Constructs an instance that's initialized with the contents of the
		/// specified
		/// <code>String</code>
		/// . The capacity of the new builder will be the
		/// length of the
		/// <code>String</code>
		/// plus 16.
		/// </summary>
		/// <param name="str">
		/// the
		/// <code>String</code>
		/// to copy into the builder.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>str</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public StringBuilder(string str) : base(str)
		{
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>boolean</code>
		/// value.
		/// The
		/// <code>boolean</code>
		/// value is converted to a String according to the rule
		/// defined by
		/// <see cref="string.ToString(bool)">string.ToString(bool)</see>
		/// .
		/// </summary>
		/// <param name="b">
		/// the
		/// <code>boolean</code>
		/// value to append.
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="string.ToString(bool)">string.ToString(bool)</seealso>
		public java.lang.StringBuilder append(bool b)
		{
			append0(b ? "true" : "false");
			return this;
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(char c)
		{
			return append(c);
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>char</code>
		/// value.
		/// The
		/// <code>char</code>
		/// value is converted to a string according to the rule
		/// defined by
		/// <see cref="string.ToString(char)">string.ToString(char)</see>
		/// .
		/// </summary>
		/// <param name="c">
		/// the
		/// <code>char</code>
		/// value to append.
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="string.ToString(char)">string.ToString(char)</seealso>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public java.lang.StringBuilder append(char c)
		{
			append0(c);
			return this;
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>Object</code>
		/// .
		/// The
		/// <code>Object</code>
		/// value is converted to a string according to the rule
		/// defined by
		/// <see cref="Sharpen.StringHelper.GetValueOf(object)">Sharpen.StringHelper.GetValueOf(object)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="obj">
		/// the
		/// <code>Object</code>
		/// to append.
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="Sharpen.StringHelper.GetValueOf(object)">Sharpen.StringHelper.GetValueOf(object)
		/// 	</seealso>
		public java.lang.StringBuilder append(object obj)
		{
			if (obj == null)
			{
				appendNull();
			}
			else
			{
				append0(obj.ToString());
			}
			return this;
		}

		/// <summary>Appends the contents of the specified string.</summary>
		/// <remarks>
		/// Appends the contents of the specified string. If the string is
		/// <code>null</code>
		/// , then the string
		/// <code>"null"</code>
		/// is appended.
		/// </remarks>
		/// <param name="str">the string to append.</param>
		/// <returns>this builder.</returns>
		public java.lang.StringBuilder append(string str)
		{
			append0(str);
			return this;
		}

		/// <summary>
		/// Appends the contents of the specified
		/// <code>StringBuffer</code>
		/// . If the
		/// StringBuffer is
		/// <code>null</code>
		/// , then the string
		/// <code>"null"</code>
		/// is
		/// appended.
		/// </summary>
		/// <param name="sb">
		/// the
		/// <code>StringBuffer</code>
		/// to append.
		/// </param>
		/// <returns>this builder.</returns>
		public java.lang.StringBuilder append(java.lang.StringBuffer sb)
		{
			if (sb == null)
			{
				appendNull();
			}
			else
			{
				append0(sb.getValue(), 0, sb.Length);
			}
			return this;
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>char[]</code>
		/// .
		/// The
		/// <code>char[]</code>
		/// is converted to a string according to the rule
		/// defined by
		/// <see cref="string.ToString(char[])">string.ToString(char[])</see>
		/// .
		/// </summary>
		/// <param name="chars">
		/// the
		/// <code>char[]</code>
		/// to append..
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="string.ToString(char[])">string.ToString(char[])</seealso>
		public java.lang.StringBuilder append(char[] chars)
		{
			append0(chars);
			return this;
		}

		/// <summary>
		/// Appends the string representation of the specified subset of the
		/// <code>char[]</code>
		/// . The
		/// <code>char[]</code>
		/// value is converted to a String according to
		/// the rule defined by
		/// <see cref="string.ToString(char[], int, int)">string.ToString(char[], int, int)</see>
		/// .
		/// </summary>
		/// <param name="str">
		/// the
		/// <code>char[]</code>
		/// to append.
		/// </param>
		/// <param name="offset">the inclusive offset index.</param>
		/// <param name="len">the number of characters.</param>
		/// <returns>this builder.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>offset</code>
		/// and
		/// <code>len</code>
		/// do not specify a valid
		/// subsequence.
		/// </exception>
		/// <seealso cref="string.ToString(char[], int, int)">string.ToString(char[], int, int)
		/// 	</seealso>
		public java.lang.StringBuilder append(char[] str, int offset, int len)
		{
			append0(str, offset, len);
			return this;
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence csq)
		{
			return append(csq);
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>CharSequence</code>
		/// .
		/// If the
		/// <code>CharSequence</code>
		/// is
		/// <code>null</code>
		/// , then the string
		/// <code>"null"</code>
		/// is appended.
		/// </summary>
		/// <param name="csq">
		/// the
		/// <code>CharSequence</code>
		/// to append.
		/// </param>
		/// <returns>this builder.</returns>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public java.lang.StringBuilder append(java.lang.CharSequence csq)
		{
			if (csq == null)
			{
				appendNull();
			}
			else
			{
				append0(csq, 0, csq.Length);
			}
			return this;
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence csq, int 
			start, int end)
		{
			return append(csq, start, end);
		}

		/// <summary>
		/// Appends the string representation of the specified subsequence of the
		/// <code>CharSequence</code>
		/// . If the
		/// <code>CharSequence</code>
		/// is
		/// <code>null</code>
		/// , then
		/// the string
		/// <code>"null"</code>
		/// is used to extract the subsequence from.
		/// </summary>
		/// <param name="csq">
		/// the
		/// <code>CharSequence</code>
		/// to append.
		/// </param>
		/// <param name="start">the beginning index.</param>
		/// <param name="end">the ending index.</param>
		/// <returns>this builder.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>start</code>
		/// or
		/// <code>end</code>
		/// are negative,
		/// <code>start</code>
		/// is greater than
		/// <code>end</code>
		/// or
		/// <code>end</code>
		/// is greater than
		/// the length of
		/// <code>csq</code>
		/// .
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public java.lang.StringBuilder append(java.lang.CharSequence csq, int start, int 
			end)
		{
			append0(csq, start, end);
			return this;
		}

		[Sharpen.Stub]
		public java.lang.StringBuilder appendCodePoint(int codePoint)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Deletes a sequence of characters specified by
		/// <code>start</code>
		/// and
		/// <code>end</code>
		/// . Shifts any remaining characters to the left.
		/// </summary>
		/// <param name="start">the inclusive start index.</param>
		/// <param name="end">the exclusive end index.</param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>start</code>
		/// is less than zero, greater than the current
		/// length or greater than
		/// <code>end</code>
		/// .
		/// </exception>
		public java.lang.StringBuilder delete(int start, int end)
		{
			delete0(start, end);
			return this;
		}

		/// <summary>Deletes the character at the specified index.</summary>
		/// <remarks>
		/// Deletes the character at the specified index. shifts any remaining
		/// characters to the left.
		/// </remarks>
		/// <param name="index">the index of the character to delete.</param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index</code>
		/// is less than zero or is greater than or
		/// equal to the current length.
		/// </exception>
		public java.lang.StringBuilder deleteCharAt(int index)
		{
			deleteCharAt0(index);
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>boolean</code>
		/// value
		/// at the specified
		/// <code>offset</code>
		/// . The
		/// <code>boolean</code>
		/// value is converted
		/// to a string according to the rule defined by
		/// <see cref="string.ToString(bool)">string.ToString(bool)</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="b">
		/// the
		/// <code>boolean</code>
		/// value to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length</code>
		/// .
		/// </exception>
		/// <seealso cref="string.ToString(bool)">string.ToString(bool)</seealso>
		public java.lang.StringBuilder insert(int offset, bool b)
		{
			insert0(offset, b ? "true" : "false");
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>char</code>
		/// value at
		/// the specified
		/// <code>offset</code>
		/// . The
		/// <code>char</code>
		/// value is converted to a
		/// string according to the rule defined by
		/// <see cref="string.ToString(char)">string.ToString(char)</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="c">
		/// the
		/// <code>char</code>
		/// value to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		/// <seealso cref="string.ToString(char)">string.ToString(char)</seealso>
		public java.lang.StringBuilder insert(int offset, char c)
		{
			insert0(offset, c);
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>int</code>
		/// value at
		/// the specified
		/// <code>offset</code>
		/// . The
		/// <code>int</code>
		/// value is converted to a
		/// String according to the rule defined by
		/// <see cref="string.ToString(int)">string.ToString(int)</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="i">
		/// the
		/// <code>int</code>
		/// value to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		/// <seealso cref="string.ToString(int)">string.ToString(int)</seealso>
		public java.lang.StringBuilder insert(int offset, int i)
		{
			insert0(offset, System.Convert.ToString(i));
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>long</code>
		/// value at
		/// the specified
		/// <code>offset</code>
		/// . The
		/// <code>long</code>
		/// value is converted to a
		/// String according to the rule defined by
		/// <see cref="string.ToString(long)">string.ToString(long)</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="l">
		/// the
		/// <code>long</code>
		/// value to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// {code length()}.
		/// </exception>
		/// <seealso cref="string.ToString(long)">string.ToString(long)</seealso>
		public java.lang.StringBuilder insert(int offset, long l)
		{
			insert0(offset, System.Convert.ToString(l));
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>float</code>
		/// value at
		/// the specified
		/// <code>offset</code>
		/// . The
		/// <code>float</code>
		/// value is converted to a
		/// string according to the rule defined by
		/// <see cref="string.ToString(float)">string.ToString(float)</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="f">
		/// the
		/// <code>float</code>
		/// value to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		/// <seealso cref="string.ToString(float)">string.ToString(float)</seealso>
		public java.lang.StringBuilder insert(int offset, float f)
		{
			insert0(offset, System.Convert.ToString(f));
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>double</code>
		/// value
		/// at the specified
		/// <code>offset</code>
		/// . The
		/// <code>double</code>
		/// value is converted
		/// to a String according to the rule defined by
		/// <see cref="string.ToString(double)">string.ToString(double)</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="d">
		/// the
		/// <code>double</code>
		/// value to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		/// <seealso cref="string.ToString(double)">string.ToString(double)</seealso>
		public java.lang.StringBuilder insert(int offset, double d)
		{
			insert0(offset, System.Convert.ToString(d));
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>Object</code>
		/// at the
		/// specified
		/// <code>offset</code>
		/// . The
		/// <code>Object</code>
		/// value is converted to a
		/// String according to the rule defined by
		/// <see cref="Sharpen.StringHelper.GetValueOf(object)">Sharpen.StringHelper.GetValueOf(object)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="obj">
		/// the
		/// <code>Object</code>
		/// to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		/// <seealso cref="Sharpen.StringHelper.GetValueOf(object)">Sharpen.StringHelper.GetValueOf(object)
		/// 	</seealso>
		public java.lang.StringBuilder insert(int offset, object obj)
		{
			insert0(offset, obj == null ? "null" : obj.ToString());
			return this;
		}

		/// <summary>
		/// Inserts the specified string at the specified
		/// <code>offset</code>
		/// . If the
		/// specified string is null, then the String
		/// <code>"null"</code>
		/// is inserted.
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="str">
		/// the
		/// <code>String</code>
		/// to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuilder insert(int offset, string str)
		{
			insert0(offset, str);
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>char[]</code>
		/// at the
		/// specified
		/// <code>offset</code>
		/// . The
		/// <code>char[]</code>
		/// value is converted to a
		/// String according to the rule defined by
		/// <see cref="string.ToString(char[])">string.ToString(char[])</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="ch">
		/// the
		/// <code>char[]</code>
		/// to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		/// <seealso cref="string.ToString(char[])">string.ToString(char[])</seealso>
		public java.lang.StringBuilder insert(int offset, char[] ch)
		{
			insert0(offset, ch);
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified subsequence of the
		/// <code>char[]</code>
		/// at the specified
		/// <code>offset</code>
		/// . The
		/// <code>char[]</code>
		/// value
		/// is converted to a String according to the rule defined by
		/// <see cref="string.ToString(char[], int, int)">string.ToString(char[], int, int)</see>
		/// .
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="str">
		/// the
		/// <code>char[]</code>
		/// to insert.
		/// </param>
		/// <param name="strOffset">the inclusive index.</param>
		/// <param name="strLen">the number of characters.</param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// , or
		/// <code>strOffset</code>
		/// and
		/// <code>strLen</code>
		/// do
		/// not specify a valid subsequence.
		/// </exception>
		/// <seealso cref="string.ToString(char[], int, int)">string.ToString(char[], int, int)
		/// 	</seealso>
		public java.lang.StringBuilder insert(int offset, char[] str, int strOffset, int 
			strLen)
		{
			insert0(offset, str, strOffset, strLen);
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified
		/// <code>CharSequence</code>
		/// at the specified
		/// <code>offset</code>
		/// . The
		/// <code>CharSequence</code>
		/// is converted
		/// to a String as defined by
		/// <see cref="CharSequence.ToString()">CharSequence.ToString()</see>
		/// . If
		/// <code>s</code>
		/// is
		/// <code>null</code>
		/// , then the String
		/// <code>"null"</code>
		/// is inserted.
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="s">
		/// the
		/// <code>CharSequence</code>
		/// to insert.
		/// </param>
		/// <returns>this builder.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// .
		/// </exception>
		/// <seealso cref="CharSequence.ToString()">CharSequence.ToString()</seealso>
		public java.lang.StringBuilder insert(int offset, java.lang.CharSequence s)
		{
			insert0(offset, s == null ? "null" : s.ToString());
			return this;
		}

		/// <summary>
		/// Inserts the string representation of the specified subsequence of the
		/// <code>CharSequence</code>
		/// at the specified
		/// <code>offset</code>
		/// . The
		/// <code>CharSequence</code>
		/// is converted to a String as defined by
		/// <see cref="CharSequence.SubSequence(int, int)">CharSequence.SubSequence(int, int)
		/// 	</see>
		/// . If the
		/// <code>CharSequence</code>
		/// is
		/// <code>null</code>
		/// , then the string
		/// <code>"null"</code>
		/// is used to determine the
		/// subsequence.
		/// </summary>
		/// <param name="offset">the index to insert at.</param>
		/// <param name="s">
		/// the
		/// <code>CharSequence</code>
		/// to insert.
		/// </param>
		/// <param name="start">the start of the subsequence of the character sequence.</param>
		/// <param name="end">the end of the subsequence of the character sequence.</param>
		/// <returns>this builder.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>offset</code>
		/// is negative or greater than the current
		/// <code>length()</code>
		/// , or
		/// <code>start</code>
		/// and
		/// <code>end</code>
		/// do not
		/// specify a valid subsequence.
		/// </exception>
		/// <seealso cref="CharSequence.SubSequence(int, int)">CharSequence.SubSequence(int, int)
		/// 	</seealso>
		public java.lang.StringBuilder insert(int offset, java.lang.CharSequence s, int start
			, int end)
		{
			insert0(offset, s, start, end);
			return this;
		}

		/// <summary>
		/// Replaces the specified subsequence in this builder with the specified
		/// string.
		/// </summary>
		/// <remarks>
		/// Replaces the specified subsequence in this builder with the specified
		/// string.
		/// </remarks>
		/// <param name="start">the inclusive begin index.</param>
		/// <param name="end">the exclusive end index.</param>
		/// <param name="str">the replacement string.</param>
		/// <returns>this builder.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>start</code>
		/// is negative, greater than the current
		/// <code>length()</code>
		/// or greater than
		/// <code>end</code>
		/// .
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>str</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public java.lang.StringBuilder replace(int start, int end, string str)
		{
			replace0(start, end, str);
			return this;
		}

		/// <summary>Reverses the order of characters in this builder.</summary>
		/// <remarks>Reverses the order of characters in this builder.</remarks>
		/// <returns>this buffer.</returns>
		public java.lang.StringBuilder reverse()
		{
			reverse0();
			return this;
		}

		/// <summary>Returns the contents of this builder.</summary>
		/// <remarks>Returns the contents of this builder.</remarks>
		/// <returns>the string representation of the data in this builder.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return base.ToString();
		}

		/// <summary>
		/// Reads the state of a
		/// <code>StringBuilder</code>
		/// from the passed stream and
		/// restores it to this instance.
		/// </summary>
		/// <param name="in">the stream to read the state from.</param>
		/// <exception cref="System.IO.IOException">if the stream throws it during the read.</exception>
		/// <exception cref="ClassNotFoundException">if the stream throws it during the read.
		/// 	</exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream @in)
		{
			@in.defaultReadObject();
			int count = @in.readInt();
			char[] value = (char[])@in.readObject();
			set(value, count);
		}

		/// <summary>Writes the state of this object to the stream passed.</summary>
		/// <remarks>Writes the state of this object to the stream passed.</remarks>
		/// <param name="out">the stream to write the state to.</param>
		/// <exception cref="System.IO.IOException">if the stream throws it during the write.
		/// 	</exception>
		/// <serialData>
		/// 
		/// <code>int</code>
		/// - the length of this object.
		/// <code>char[]</code>
		/// - the
		/// buffer from this object, which may be larger than the length
		/// field.
		/// </serialData>
		private void writeObject(java.io.ObjectOutputStream @out)
		{
			@out.defaultWriteObject();
			@out.writeInt(Length);
			@out.writeObject(getValue());
		}
	}
}
