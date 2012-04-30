using Sharpen;

namespace java.lang
{
	/// <summary>
	/// A modifiable
	/// <see cref="CharSequence">sequence of characters</see>
	/// for use in creating
	/// strings, where all accesses are synchronized. This class has mostly been replaced
	/// by
	/// <see cref="StringBuilder">StringBuilder</see>
	/// because this synchronization is rarely useful. This
	/// class is mainly used to interact with legacy APIs that expose it.
	/// <p>For particularly complex string-building needs, consider
	/// <see cref="java.util.Formatter">java.util.Formatter</see>
	/// .
	/// <p>The majority of the modification methods on this class return
	/// <code>this</code>
	/// so that method calls can be chained together. For example:
	/// <code>new StringBuffer("a").append("b").append("c").toString()</code>
	/// .
	/// </summary>
	/// <seealso cref="CharSequence">CharSequence</seealso>
	/// <seealso cref="Appendable">Appendable</seealso>
	/// <seealso cref="StringBuilder">StringBuilder</seealso>
	/// <seealso cref="string">string</seealso>
	/// <seealso cref="string.Format(string, object[])">string.Format(string, object[])</seealso>
	/// <since>1.0</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public sealed partial class StringBuffer : java.lang.AbstractStringBuilder, java.lang.Appendable
		, java.lang.CharSequence
	{
		internal const long serialVersionUID = 3388685877147921107L;

		/// <summary>Constructs a new StringBuffer using the default capacity which is 16.</summary>
		/// <remarks>Constructs a new StringBuffer using the default capacity which is 16.</remarks>
		public StringBuffer()
		{
		}

		/// <summary>Constructs a new StringBuffer using the specified capacity.</summary>
		/// <remarks>Constructs a new StringBuffer using the specified capacity.</remarks>
		/// <param name="capacity">the initial capacity.</param>
		public StringBuffer(int capacity_1) : base(capacity_1)
		{
		}

		/// <summary>
		/// Constructs a new StringBuffer containing the characters in the specified
		/// string.
		/// </summary>
		/// <remarks>
		/// Constructs a new StringBuffer containing the characters in the specified
		/// string. The capacity of the new buffer will be the length of the
		/// <code>String</code>
		/// plus the default capacity.
		/// </remarks>
		/// <param name="string">the string content with which to initialize the new instance.
		/// 	</param>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>string</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public StringBuffer(string @string) : base(@string)
		{
		}

		/// <summary>
		/// Constructs a StringBuffer and initializes it with the content from the
		/// specified
		/// <code>CharSequence</code>
		/// . The capacity of the new buffer will be
		/// the length of the
		/// <code>CharSequence</code>
		/// plus the default capacity.
		/// </summary>
		/// <param name="cs">the content to initialize the instance.</param>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>cs</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <since>1.5</since>
		public StringBuffer(java.lang.CharSequence cs) : base(cs.ToString())
		{
		}

		/// <summary>
		/// Adds the string representation of the specified boolean to the end of
		/// this StringBuffer.
		/// </summary>
		/// <remarks>
		/// Adds the string representation of the specified boolean to the end of
		/// this StringBuffer.
		/// <p>
		/// If the argument is
		/// <code>true</code>
		/// the string
		/// <code>"true"</code>
		/// is appended,
		/// otherwise the string
		/// <code>"false"</code>
		/// is appended.
		/// </remarks>
		/// <param name="b">the boolean to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <seealso cref="string.ToString(bool)">string.ToString(bool)</seealso>
		public java.lang.StringBuffer append(bool b)
		{
			return append(b ? "true" : "false");
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(char ch)
		{
			return append(ch);
		}

		/// <summary>Adds the specified character to the end of this buffer.</summary>
		/// <remarks>Adds the specified character to the end of this buffer.</remarks>
		/// <param name="ch">the character to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <seealso cref="string.ToString(char)">string.ToString(char)</seealso>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public java.lang.StringBuffer append(char ch)
		{
			lock (this)
			{
				append0(ch);
				return this;
			}
		}

		/// <summary>
		/// Adds the string representation of the specified object to the end of this
		/// StringBuffer.
		/// </summary>
		/// <remarks>
		/// Adds the string representation of the specified object to the end of this
		/// StringBuffer.
		/// <p>
		/// If the specified object is
		/// <code>null</code>
		/// the string
		/// <code>"null"</code>
		/// is
		/// appended, otherwise the objects
		/// <code>toString</code>
		/// is used to get its
		/// string representation.
		/// </remarks>
		/// <param name="obj">the object to append (may be null).</param>
		/// <returns>this StringBuffer.</returns>
		/// <seealso cref="Sharpen.StringHelper.GetValueOf(object)">Sharpen.StringHelper.GetValueOf(object)
		/// 	</seealso>
		public java.lang.StringBuffer append(object obj)
		{
			lock (this)
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
		}

		/// <summary>Adds the specified string to the end of this buffer.</summary>
		/// <remarks>
		/// Adds the specified string to the end of this buffer.
		/// <p>
		/// If the specified string is
		/// <code>null</code>
		/// the string
		/// <code>"null"</code>
		/// is
		/// appended, otherwise the contents of the specified string is appended.
		/// </remarks>
		/// <param name="string">the string to append (may be null).</param>
		/// <returns>this StringBuffer.</returns>
		public java.lang.StringBuffer append(string @string)
		{
			lock (this)
			{
				append0(@string);
				return this;
			}
		}

		/// <summary>Adds the specified StringBuffer to the end of this buffer.</summary>
		/// <remarks>
		/// Adds the specified StringBuffer to the end of this buffer.
		/// <p>
		/// If the specified StringBuffer is
		/// <code>null</code>
		/// the string
		/// <code>"null"</code>
		/// is appended, otherwise the contents of the specified StringBuffer is
		/// appended.
		/// </remarks>
		/// <param name="sb">the StringBuffer to append (may be null).</param>
		/// <returns>this StringBuffer.</returns>
		/// <since>1.4</since>
		public java.lang.StringBuffer append(java.lang.StringBuffer sb)
		{
			lock (this)
			{
				if (sb == null)
				{
					appendNull();
				}
				else
				{
					lock (sb)
					{
						append0(sb.getValue(), 0, sb.Length);
					}
				}
				return this;
			}
		}

		/// <summary>Adds the character array to the end of this buffer.</summary>
		/// <remarks>Adds the character array to the end of this buffer.</remarks>
		/// <param name="chars">the character array to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>chars</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer append(char[] chars)
		{
			lock (this)
			{
				append0(chars);
				return this;
			}
		}

		/// <summary>Adds the specified sequence of characters to the end of this buffer.</summary>
		/// <remarks>Adds the specified sequence of characters to the end of this buffer.</remarks>
		/// <param name="chars">the character array to append.</param>
		/// <param name="start">the starting offset.</param>
		/// <param name="length">the number of characters.</param>
		/// <returns>this StringBuffer.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>length &lt; 0</code>
		/// ,
		/// <code>start &lt; 0</code>
		/// or
		/// <code>
		/// start +
		/// length &gt; chars.length
		/// </code>
		/// .
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>chars</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer append(char[] chars, int start, int length_1)
		{
			lock (this)
			{
				append0(chars, start, length_1);
				return this;
			}
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence s)
		{
			return append(s);
		}

		/// <summary>Appends the specified CharSequence to this buffer.</summary>
		/// <remarks>
		/// Appends the specified CharSequence to this buffer.
		/// <p>
		/// If the specified CharSequence is
		/// <code>null</code>
		/// the string
		/// <code>"null"</code>
		/// is appended, otherwise the contents of the specified CharSequence is
		/// appended.
		/// </remarks>
		/// <param name="s">the CharSequence to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <since>1.5</since>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public java.lang.StringBuffer append(java.lang.CharSequence s)
		{
			lock (this)
			{
				if (s == null)
				{
					appendNull();
				}
				else
				{
					append0(s, 0, s.Length);
				}
				return this;
			}
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence s, int start
			, int end)
		{
			return append(s, start, end);
		}

		/// <summary>Appends the specified subsequence of the CharSequence to this buffer.</summary>
		/// <remarks>
		/// Appends the specified subsequence of the CharSequence to this buffer.
		/// <p>
		/// If the specified CharSequence is
		/// <code>null</code>
		/// , then the string
		/// <code>"null"</code>
		/// is used to extract a subsequence.
		/// </remarks>
		/// <param name="s">the CharSequence to append.</param>
		/// <param name="start">the inclusive start index.</param>
		/// <param name="end">the exclusive end index.</param>
		/// <returns>this StringBuffer.</returns>
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
		/// <code>s</code>
		/// .
		/// </exception>
		/// <since>1.5</since>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public java.lang.StringBuffer append(java.lang.CharSequence s, int start, int end
			)
		{
			lock (this)
			{
				append0(s, start, end);
				return this;
			}
		}

		[Sharpen.Stub]
		public java.lang.StringBuffer appendCodePoint(int codePoint)
		{
			throw new System.NotImplementedException();
		}

		public override char this[int index]
		{
			get
			{
				lock (this)
				{
					return base[index];
				}
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override int codePointAt(int index)
		{
			lock (this)
			{
				return base.codePointAt(index);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override int codePointBefore(int index)
		{
			lock (this)
			{
				return base.codePointBefore(index);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override int codePointCount(int beginIndex, int endIndex)
		{
			lock (this)
			{
				return base.codePointCount(beginIndex, endIndex);
			}
		}

		/// <summary>Deletes a range of characters.</summary>
		/// <remarks>Deletes a range of characters.</remarks>
		/// <param name="start">the offset of the first character.</param>
		/// <param name="end">the offset one past the last character.</param>
		/// <returns>this StringBuffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>start &lt; 0</code>
		/// ,
		/// <code>start &gt; end</code>
		/// or
		/// <code>
		/// end &gt;
		/// length()
		/// </code>
		/// .
		/// </exception>
		public java.lang.StringBuffer delete(int start, int end)
		{
			lock (this)
			{
				delete0(start, end);
				return this;
			}
		}

		/// <summary>Deletes the character at the specified offset.</summary>
		/// <remarks>Deletes the character at the specified offset.</remarks>
		/// <param name="location">the offset of the character to delete.</param>
		/// <returns>this StringBuffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>location &lt; 0</code>
		/// or
		/// <code>location &gt;= length()</code>
		/// </exception>
		public java.lang.StringBuffer deleteCharAt(int location)
		{
			lock (this)
			{
				deleteCharAt0(location);
				return this;
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override void ensureCapacity(int min)
		{
			lock (this)
			{
				base.ensureCapacity(min);
			}
		}

		/// <summary>
		/// Copies the requested sequence of characters to the
		/// <code>char[]</code>
		/// passed
		/// starting at
		/// <code>idx</code>
		/// .
		/// </summary>
		/// <param name="start">the starting offset of characters to copy.</param>
		/// <param name="end">the ending offset of characters to copy.</param>
		/// <param name="buffer">the destination character array.</param>
		/// <param name="idx">the starting offset in the character array.</param>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// ,
		/// <code>end &gt; length()</code>
		/// ,
		/// <code>
		/// start &gt;
		/// end
		/// </code>
		/// ,
		/// <code>index &lt; 0</code>
		/// ,
		/// <code>
		/// end - start &gt; buffer.length -
		/// index
		/// </code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override void getChars(int start, int end, char[] buffer, int idx)
		{
			lock (this)
			{
				base.getChars(start, end, buffer, idx);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override int indexOf(string subString, int start)
		{
			lock (this)
			{
				return base.indexOf(subString, start);
			}
		}

		/// <summary>Inserts the character into this buffer at the specified offset.</summary>
		/// <remarks>Inserts the character into this buffer at the specified offset.</remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="ch">the character to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, char ch)
		{
			lock (this)
			{
				insert0(index, ch);
				return this;
			}
		}

		/// <summary>
		/// Inserts the string representation of the specified boolean into this
		/// buffer at the specified offset.
		/// </summary>
		/// <remarks>
		/// Inserts the string representation of the specified boolean into this
		/// buffer at the specified offset.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="b">the boolean to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, bool b)
		{
			return insert(index, b ? "true" : "false");
		}

		/// <summary>
		/// Inserts the string representation of the specified integer into this
		/// buffer at the specified offset.
		/// </summary>
		/// <remarks>
		/// Inserts the string representation of the specified integer into this
		/// buffer at the specified offset.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="i">the integer to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, int i)
		{
			return insert(index, System.Convert.ToString(i));
		}

		/// <summary>
		/// Inserts the string representation of the specified long into this buffer
		/// at the specified offset.
		/// </summary>
		/// <remarks>
		/// Inserts the string representation of the specified long into this buffer
		/// at the specified offset.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="l">the long to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, long l)
		{
			return insert(index, System.Convert.ToString(l));
		}

		/// <summary>
		/// Inserts the string representation of the specified into this buffer
		/// double at the specified offset.
		/// </summary>
		/// <remarks>
		/// Inserts the string representation of the specified into this buffer
		/// double at the specified offset.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="d">the double to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, double d)
		{
			return insert(index, System.Convert.ToString(d));
		}

		/// <summary>
		/// Inserts the string representation of the specified float into this buffer
		/// at the specified offset.
		/// </summary>
		/// <remarks>
		/// Inserts the string representation of the specified float into this buffer
		/// at the specified offset.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="f">the float to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, float f)
		{
			return insert(index, System.Convert.ToString(f));
		}

		/// <summary>
		/// Inserts the string representation of the specified object into this
		/// buffer at the specified offset.
		/// </summary>
		/// <remarks>
		/// Inserts the string representation of the specified object into this
		/// buffer at the specified offset.
		/// <p>
		/// If the specified object is
		/// <code>null</code>
		/// , the string
		/// <code>"null"</code>
		/// is
		/// inserted, otherwise the objects
		/// <code>toString</code>
		/// method is used to get
		/// its string representation.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="obj">the object to insert (may be null).</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, object obj)
		{
			return insert(index, obj == null ? "null" : obj.ToString());
		}

		/// <summary>Inserts the string into this buffer at the specified offset.</summary>
		/// <remarks>
		/// Inserts the string into this buffer at the specified offset.
		/// <p>
		/// If the specified string is
		/// <code>null</code>
		/// , the string
		/// <code>"null"</code>
		/// is
		/// inserted, otherwise the contents of the string is inserted.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="string">the string to insert (may be null).</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, string @string)
		{
			lock (this)
			{
				insert0(index, @string);
				return this;
			}
		}

		/// <summary>Inserts the character array into this buffer at the specified offset.</summary>
		/// <remarks>Inserts the character array into this buffer at the specified offset.</remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="chars">the character array to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>chars</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer insert(int index, char[] chars)
		{
			lock (this)
			{
				insert0(index, chars);
				return this;
			}
		}

		/// <summary>
		/// Inserts the specified subsequence of characters into this buffer at the
		/// specified index.
		/// </summary>
		/// <remarks>
		/// Inserts the specified subsequence of characters into this buffer at the
		/// specified index.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="chars">the character array to insert.</param>
		/// <param name="start">the starting offset.</param>
		/// <param name="length">the number of characters.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>chars</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>length &lt; 0</code>
		/// ,
		/// <code>start &lt; 0</code>
		/// ,
		/// <code>
		/// start +
		/// length &gt; chars.length
		/// </code>
		/// ,
		/// <code>index &lt; 0</code>
		/// or
		/// <code>
		/// index &gt;
		/// length()
		/// </code>
		/// </exception>
		public java.lang.StringBuffer insert(int index, char[] chars, int start, int length_1
			)
		{
			lock (this)
			{
				insert0(index, chars, start, length_1);
				return this;
			}
		}

		/// <summary>
		/// Inserts the specified CharSequence into this buffer at the specified
		/// index.
		/// </summary>
		/// <remarks>
		/// Inserts the specified CharSequence into this buffer at the specified
		/// index.
		/// <p>
		/// If the specified CharSequence is
		/// <code>null</code>
		/// , the string
		/// <code>"null"</code>
		/// is inserted, otherwise the contents of the CharSequence.
		/// </remarks>
		/// <param name="index">The index at which to insert.</param>
		/// <param name="s">The char sequence to insert.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index &lt; 0</code>
		/// or
		/// <code>index &gt; length()</code>
		/// .
		/// </exception>
		/// <since>1.5</since>
		public java.lang.StringBuffer insert(int index, java.lang.CharSequence s)
		{
			lock (this)
			{
				insert0(index, s == null ? "null" : s.ToString());
				return this;
			}
		}

		/// <summary>
		/// Inserts the specified subsequence into this buffer at the specified
		/// index.
		/// </summary>
		/// <remarks>
		/// Inserts the specified subsequence into this buffer at the specified
		/// index.
		/// <p>
		/// If the specified CharSequence is
		/// <code>null</code>
		/// , the string
		/// <code>"null"</code>
		/// is inserted, otherwise the contents of the CharSequence.
		/// </remarks>
		/// <param name="index">The index at which to insert.</param>
		/// <param name="s">The char sequence to insert.</param>
		/// <param name="start">The inclusive start index in the char sequence.</param>
		/// <param name="end">The exclusive end index in the char sequence.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index</code>
		/// is negative or greater than the current
		/// length,
		/// <code>start</code>
		/// or
		/// <code>end</code>
		/// are negative,
		/// <code>start</code>
		/// is greater than
		/// <code>end</code>
		/// or
		/// <code>end</code>
		/// is greater
		/// than the length of
		/// <code>s</code>
		/// .
		/// </exception>
		/// <since>1.5</since>
		public java.lang.StringBuffer insert(int index, java.lang.CharSequence s, int start
			, int end)
		{
			lock (this)
			{
				insert0(index, s, start, end);
				return this;
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override int lastIndexOf(string subString, int start)
		{
			lock (this)
			{
				return base.lastIndexOf(subString, start);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override int offsetByCodePoints(int index, int codePointOffset)
		{
			lock (this)
			{
				return base.offsetByCodePoints(index, codePointOffset);
			}
		}

		/// <summary>
		/// Replaces the characters in the specified range with the contents of the
		/// specified string.
		/// </summary>
		/// <remarks>
		/// Replaces the characters in the specified range with the contents of the
		/// specified string.
		/// </remarks>
		/// <param name="start">the inclusive begin index.</param>
		/// <param name="end">the exclusive end index.</param>
		/// <param name="string">the string that will replace the contents in the range.</param>
		/// <returns>this buffer.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
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
		/// <code>s</code>
		/// .
		/// </exception>
		public java.lang.StringBuffer replace(int start, int end, string @string)
		{
			lock (this)
			{
				replace0(start, end, @string);
				return this;
			}
		}

		/// <summary>Reverses the order of characters in this buffer.</summary>
		/// <remarks>Reverses the order of characters in this buffer.</remarks>
		/// <returns>this buffer.</returns>
		public java.lang.StringBuffer reverse()
		{
			lock (this)
			{
				reverse0();
				return this;
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override void setCharAt(int index, char ch)
		{
			lock (this)
			{
				base.setCharAt(index, ch);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override void setLength(int length_1)
		{
			lock (this)
			{
				base.setLength(length_1);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override java.lang.CharSequence SubSequence(int start, int end)
		{
			lock (this)
			{
				return java.lang.CharSequenceProxy.Wrap(base.substring(start, end));
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override string substring(int start)
		{
			lock (this)
			{
				return base.substring(start);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override string substring(int start, int end)
		{
			lock (this)
			{
				return base.substring(start, end);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			lock (this)
			{
				return base.ToString();
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.AbstractStringBuilder")]
		public override void trimToSize()
		{
			lock (this)
			{
				base.trimToSize();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream @out)
		{
			lock (this)
			{
				java.io.ObjectOutputStream.PutField fields = @out.putFields();
				fields.put("count", Length);
				fields.put("shared", false);
				fields.put("value", getValue());
				@out.writeFields();
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream @in)
		{
			java.io.ObjectInputStream.GetField fields = @in.readFields();
			int count = fields.get("count", 0);
			char[] value = (char[])fields.get("value", null);
			set(value, count);
		}
	}
}
