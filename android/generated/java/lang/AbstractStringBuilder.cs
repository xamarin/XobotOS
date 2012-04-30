using Sharpen;

namespace java.lang
{
	/// <summary>
	/// A modifiable
	/// <see cref="CharSequence">sequence of characters</see>
	/// for use in creating
	/// and modifying Strings. This class is intended as a base class for
	/// <see cref="StringBuffer">StringBuffer</see>
	/// and
	/// <see cref="StringBuilder">StringBuilder</see>
	/// .
	/// </summary>
	/// <seealso cref="StringBuffer">StringBuffer</seealso>
	/// <seealso cref="StringBuilder">StringBuilder</seealso>
	/// <since>1.5</since>
	[Sharpen.Sharpened]
	public abstract class AbstractStringBuilder
	{
		internal const int INITIAL_CAPACITY = 16;

		private char[] value;

		private int count;

		private bool shared;

		internal char[] getValue()
		{
			return value;
		}

		internal char[] shareValue()
		{
			shared = true;
			return value;
		}

		/// <exception cref="java.io.InvalidObjectException"></exception>
		internal void set(char[] val, int len)
		{
			if (val == null)
			{
				val = libcore.util.EmptyArray.CHAR;
			}
			if (val.Length < len)
			{
				throw new java.io.InvalidObjectException("count out of range");
			}
			shared = false;
			value = val;
			count = len;
		}

		internal AbstractStringBuilder()
		{
			value = new char[INITIAL_CAPACITY];
		}

		internal AbstractStringBuilder(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			value = new char[capacity_1];
		}

		internal AbstractStringBuilder(string @string)
		{
			count = @string.Length;
			shared = false;
			value = new char[count + INITIAL_CAPACITY];
			Sharpen.StringHelper.GetCharsForString(@string, 0, count, value, 0);
		}

		private void enlargeBuffer(int min)
		{
			int newCount = ((value.Length >> 1) + value.Length) + 2;
			char[] newData = new char[min > newCount ? min : newCount];
			System.Array.Copy(value, 0, newData, 0, count);
			value = newData;
			shared = false;
		}

		internal void appendNull()
		{
			int newCount = count + 4;
			if (newCount > value.Length)
			{
				enlargeBuffer(newCount);
			}
			value[count++] = 'n';
			value[count++] = 'u';
			value[count++] = 'l';
			value[count++] = 'l';
		}

		internal void append0(char[] chars)
		{
			int newCount = count + chars.Length;
			if (newCount > value.Length)
			{
				enlargeBuffer(newCount);
			}
			System.Array.Copy(chars, 0, value, count, chars.Length);
			count = newCount;
		}

		internal void append0(char[] chars, int offset, int length_1)
		{
			java.util.Arrays.checkOffsetAndCount(chars.Length, offset, length_1);
			int newCount = count + length_1;
			if (newCount > value.Length)
			{
				enlargeBuffer(newCount);
			}
			System.Array.Copy(chars, offset, value, count, length_1);
			count = newCount;
		}

		internal void append0(char ch)
		{
			if (count == value.Length)
			{
				enlargeBuffer(count + 1);
			}
			value[count++] = ch;
		}

		internal void append0(string @string)
		{
			if (@string == null)
			{
				appendNull();
				return;
			}
			int length_1 = @string.Length;
			int newCount = count + length_1;
			if (newCount > value.Length)
			{
				enlargeBuffer(newCount);
			}
			Sharpen.StringHelper.GetCharsForString(@string, 0, length_1, value, count);
			count = newCount;
		}

		internal void append0(java.lang.CharSequence s, int start, int end)
		{
			if (s == null)
			{
				s = java.lang.CharSequenceProxy.Wrap("null");
			}
			if ((start | end) < 0 || start > end || end > s.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			int length_1 = end - start;
			int newCount = count + length_1;
			if (newCount > value.Length)
			{
				enlargeBuffer(newCount);
			}
			else
			{
				if (shared)
				{
					value = (char[])value.Clone();
					shared = false;
				}
			}
			if (java.lang.CharSequenceProxy.IsStringProxy(s))
			{
				Sharpen.StringHelper.GetCharsForString((java.lang.CharSequenceProxy.UnWrap(s)), start
					, end, value, count);
			}
			else
			{
				if (s is java.lang.AbstractStringBuilder)
				{
					java.lang.AbstractStringBuilder other = (java.lang.AbstractStringBuilder)s;
					System.Array.Copy(other.value, start, value, count, length_1);
				}
				else
				{
					int j = count;
					{
						// Destination index.
						for (int i = start; i < end; i++)
						{
							value[j++] = s[i];
						}
					}
				}
			}
			this.count = newCount;
		}

		/// <summary>Returns the number of characters that can be held without growing.</summary>
		/// <remarks>Returns the number of characters that can be held without growing.</remarks>
		/// <returns>the capacity</returns>
		/// <seealso cref="ensureCapacity(int)">ensureCapacity(int)</seealso>
		/// <seealso cref="Length()">Length()</seealso>
		public virtual int capacity()
		{
			return value.Length;
		}

		/// <summary>
		/// Retrieves the character at the
		/// <code>index</code>
		/// .
		/// </summary>
		/// <param name="index">the index of the character to retrieve.</param>
		/// <returns>the char value.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index</code>
		/// is negative or greater than or equal to the
		/// current
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		public virtual char this[int index]
		{
			get
			{
				if (index < 0 || index >= count)
				{
					throw indexAndLength(index);
				}
				return value[index];
			}
		}

		private java.lang.StringIndexOutOfBoundsException indexAndLength(int index)
		{
			throw new java.lang.StringIndexOutOfBoundsException(count, index);
		}

		private java.lang.StringIndexOutOfBoundsException startEndAndLength(int start, int
			 end)
		{
			throw new java.lang.StringIndexOutOfBoundsException(count, start, end - start);
		}

		internal void delete0(int start, int end)
		{
			if (start >= 0)
			{
				if (end > count)
				{
					end = count;
				}
				if (end == start)
				{
					return;
				}
				if (end > start)
				{
					int length_1 = count - end;
					if (length_1 >= 0)
					{
						if (!shared)
						{
							System.Array.Copy(value, end, value, start, length_1);
						}
						else
						{
							char[] newData = new char[value.Length];
							System.Array.Copy(value, 0, newData, 0, start);
							System.Array.Copy(value, end, newData, start, length_1);
							value = newData;
							shared = false;
						}
					}
					count -= end - start;
					return;
				}
			}
			throw startEndAndLength(start, end);
		}

		internal void deleteCharAt0(int index)
		{
			if (index < 0 || index >= count)
			{
				throw indexAndLength(index);
			}
			int length_1 = count - index - 1;
			if (length_1 > 0)
			{
				if (!shared)
				{
					System.Array.Copy(value, index + 1, value, index, length_1);
				}
				else
				{
					char[] newData = new char[value.Length];
					System.Array.Copy(value, 0, newData, 0, index);
					System.Array.Copy(value, index + 1, newData, index, length_1);
					value = newData;
					shared = false;
				}
			}
			count--;
		}

		/// <summary>
		/// Ensures that this object has a minimum capacity available before
		/// requiring the internal buffer to be enlarged.
		/// </summary>
		/// <remarks>
		/// Ensures that this object has a minimum capacity available before
		/// requiring the internal buffer to be enlarged. The general policy of this
		/// method is that if the
		/// <code>minimumCapacity</code>
		/// is larger than the current
		/// <see cref="capacity()">capacity()</see>
		/// , then the capacity will be increased to the largest
		/// value of either the
		/// <code>minimumCapacity</code>
		/// or the current capacity
		/// multiplied by two plus two. Although this is the general policy, there is
		/// no guarantee that the capacity will change.
		/// </remarks>
		/// <param name="min">the new minimum capacity to set.</param>
		public virtual void ensureCapacity(int min)
		{
			if (min > value.Length)
			{
				int ourMin = value.Length * 2 + 2;
				enlargeBuffer(System.Math.Max(ourMin, min));
			}
		}

		/// <summary>
		/// Copies the requested sequence of characters into
		/// <code>dst</code>
		/// passed
		/// starting at
		/// <code>dst</code>
		/// .
		/// </summary>
		/// <param name="start">the inclusive start index of the characters to copy.</param>
		/// <param name="end">the exclusive end index of the characters to copy.</param>
		/// <param name="dst">
		/// the
		/// <code>char[]</code>
		/// to copy the characters to.
		/// </param>
		/// <param name="dstStart">
		/// the inclusive start index of
		/// <code>dst</code>
		/// to begin copying to.
		/// </param>
		/// <exception cref="IndexOutOfRangeException">
		/// if the
		/// <code>start</code>
		/// is negative, the
		/// <code>dstStart</code>
		/// is
		/// negative, the
		/// <code>start</code>
		/// is greater than
		/// <code>end</code>
		/// , the
		/// <code>end</code>
		/// is greater than the current
		/// <see cref="Length()">Length()</see>
		/// or
		/// <code>dstStart + end - begin</code>
		/// is greater than
		/// <code>dst.length</code>
		/// .
		/// </exception>
		public virtual void getChars(int start, int end, char[] dst, int dstStart)
		{
			if (start > count || end > count || start > end)
			{
				throw startEndAndLength(start, end);
			}
			System.Array.Copy(value, start, dst, dstStart, end - start);
		}

		internal void insert0(int index, char[] chars)
		{
			if (index < 0 || index > count)
			{
				throw indexAndLength(index);
			}
			if (chars.Length != 0)
			{
				move(chars.Length, index);
				System.Array.Copy(chars, 0, value, index, chars.Length);
				count += chars.Length;
			}
		}

		internal void insert0(int index, char[] chars, int start, int length_1)
		{
			if (index >= 0 && index <= count)
			{
				// start + length could overflow, start/length maybe MaxInt
				if (start >= 0 && length_1 >= 0 && length_1 <= chars.Length - start)
				{
					if (length_1 != 0)
					{
						move(length_1, index);
						System.Array.Copy(chars, start, value, index, length_1);
						count += length_1;
					}
					return;
				}
			}
			throw new java.lang.StringIndexOutOfBoundsException("this.length=" + count + "; index="
				 + index + "; chars.length=" + chars.Length + "; start=" + start + "; length=" +
				 length_1);
		}

		internal void insert0(int index, char ch)
		{
			if (index < 0 || index > count)
			{
				// RI compatible exception type
				throw Sharpen.Util.IndexOutOfRangeCtor(count, index);
			}
			move(1, index);
			value[index] = ch;
			count++;
		}

		internal void insert0(int index, string @string)
		{
			if (index >= 0 && index <= count)
			{
				if (@string == null)
				{
					@string = "null";
				}
				int min = @string.Length;
				if (min != 0)
				{
					move(min, index);
					Sharpen.StringHelper.GetCharsForString(@string, 0, min, value, index);
					count += min;
				}
			}
			else
			{
				throw indexAndLength(index);
			}
		}

		internal void insert0(int index, java.lang.CharSequence s, int start, int end)
		{
			if (s == null)
			{
				s = java.lang.CharSequenceProxy.Wrap("null");
			}
			if ((index | start | end) < 0 || index > count || start > end || end > s.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			insert0(index, s.SubSequence(start, end).ToString());
		}

		/// <summary>The current length.</summary>
		/// <remarks>The current length.</remarks>
		/// <returns>the number of characters contained in this instance.</returns>
		public virtual int Length
		{
			get
			{
				return count;
			}
		}

		private void move(int size, int index)
		{
			int newCount;
			if (value.Length - count >= size)
			{
				if (!shared)
				{
					// index == count case is no-op
					System.Array.Copy(value, index, value, index + size, count - index);
					return;
				}
				newCount = value.Length;
			}
			else
			{
				newCount = System.Math.Max(count + size, value.Length * 2 + 2);
			}
			char[] newData = new char[newCount];
			System.Array.Copy(value, 0, newData, 0, index);
			// index == count case is no-op
			System.Array.Copy(value, index, newData, index + size, count - index);
			value = newData;
			shared = false;
		}

		internal void replace0(int start, int end, string @string)
		{
			if (start >= 0)
			{
				if (end > count)
				{
					end = count;
				}
				if (end > start)
				{
					int stringLength = @string.Length;
					int diff = end - start - stringLength;
					if (diff > 0)
					{
						// replacing with fewer characters
						if (!shared)
						{
							// index == count case is no-op
							System.Array.Copy(value, end, value, start + stringLength, count - end);
						}
						else
						{
							char[] newData = new char[value.Length];
							System.Array.Copy(value, 0, newData, 0, start);
							// index == count case is no-op
							System.Array.Copy(value, end, newData, start + stringLength, count - end);
							value = newData;
							shared = false;
						}
					}
					else
					{
						if (diff < 0)
						{
							// replacing with more characters...need some room
							move(-diff, end);
						}
						else
						{
							if (shared)
							{
								value = (char[])value.Clone();
								shared = false;
							}
						}
					}
					Sharpen.StringHelper.GetCharsForString(@string, 0, stringLength, value, start);
					count -= diff;
					return;
				}
				if (start == end)
				{
					if (@string == null)
					{
						throw new System.ArgumentNullException();
					}
					insert0(start, @string);
					return;
				}
			}
			throw startEndAndLength(start, end);
		}

		internal void reverse0()
		{
			if (count < 2)
			{
				return;
			}
			if (!shared)
			{
				int end = count - 1;
				char frontHigh = value[0];
				char endLow = value[end];
				bool allowFrontSur = true;
				bool allowEndSur = true;
				{
					int i = 0;
					int mid = count / 2;
					for (; i < mid; i++, --end)
					{
						char frontLow = value[i + 1];
						char endHigh = value[end - 1];
						bool surAtFront = allowFrontSur && frontLow >= unchecked((int)(0xdc00)) && frontLow
							 <= unchecked((int)(0xdfff)) && frontHigh >= unchecked((int)(0xd800)) && frontHigh
							 <= unchecked((int)(0xdbff));
						if (surAtFront && (count < 3))
						{
							return;
						}
						bool surAtEnd = allowEndSur && endHigh >= unchecked((int)(0xd800)) && endHigh <= 
							unchecked((int)(0xdbff)) && endLow >= unchecked((int)(0xdc00)) && endLow <= unchecked(
							(int)(0xdfff));
						allowFrontSur = allowEndSur = true;
						if (surAtFront == surAtEnd)
						{
							if (surAtFront)
							{
								// both surrogates
								value[end] = frontLow;
								value[end - 1] = frontHigh;
								value[i] = endHigh;
								value[i + 1] = endLow;
								frontHigh = value[i + 2];
								endLow = value[end - 2];
								i++;
								end--;
							}
							else
							{
								// neither surrogates
								value[end] = frontHigh;
								value[i] = endLow;
								frontHigh = frontLow;
								endLow = endHigh;
							}
						}
						else
						{
							if (surAtFront)
							{
								// surrogate only at the front
								value[end] = frontLow;
								value[i] = endLow;
								endLow = endHigh;
								allowFrontSur = false;
							}
							else
							{
								// surrogate only at the end
								value[end] = frontHigh;
								value[i] = endHigh;
								frontHigh = frontLow;
								allowEndSur = false;
							}
						}
					}
				}
				if ((count & 1) == 1 && (!allowFrontSur || !allowEndSur))
				{
					value[end] = allowFrontSur ? endLow : frontHigh;
				}
			}
			else
			{
				char[] newData = new char[value.Length];
				{
					int i = 0;
					int end = count;
					for (; i < count; i++)
					{
						char high = value[i];
						if ((i + 1) < count && high >= unchecked((int)(0xd800)) && high <= unchecked((int
							)(0xdbff)))
						{
							char low = value[i + 1];
							if (low >= unchecked((int)(0xdc00)) && low <= unchecked((int)(0xdfff)))
							{
								newData[--end] = low;
								i++;
							}
						}
						newData[--end] = high;
					}
				}
				value = newData;
				shared = false;
			}
		}

		/// <summary>
		/// Sets the character at the
		/// <code>index</code>
		/// .
		/// </summary>
		/// <param name="index">the zero-based index of the character to replace.</param>
		/// <param name="ch">the character to set.</param>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index</code>
		/// is negative or greater than or equal to the
		/// current
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		public virtual void setCharAt(int index, char ch)
		{
			if (index < 0 || index >= count)
			{
				throw indexAndLength(index);
			}
			if (shared)
			{
				value = (char[])value.Clone();
				shared = false;
			}
			value[index] = ch;
		}

		/// <summary>Sets the current length to a new value.</summary>
		/// <remarks>
		/// Sets the current length to a new value. If the new length is larger than
		/// the current length, then the new characters at the end of this object
		/// will contain the
		/// <code>char</code>
		/// value of
		/// <code>\u0000</code>
		/// .
		/// </remarks>
		/// <param name="length">the new length of this StringBuffer.</param>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>length &lt; 0</code>
		/// .
		/// </exception>
		/// <seealso cref="Length()">Length()</seealso>
		public virtual void setLength(int length_1)
		{
			if (length_1 < 0)
			{
				throw new java.lang.StringIndexOutOfBoundsException("length < 0: " + length_1);
			}
			if (length_1 > value.Length)
			{
				enlargeBuffer(length_1);
			}
			else
			{
				if (shared)
				{
					char[] newData = new char[value.Length];
					System.Array.Copy(value, 0, newData, 0, count);
					value = newData;
					shared = false;
				}
				else
				{
					if (count < length_1)
					{
						java.util.Arrays.fill(value, count, length_1, (char)0);
					}
				}
			}
			count = length_1;
		}

		/// <summary>
		/// Returns the String value of the subsequence from the
		/// <code>start</code>
		/// index
		/// to the current end.
		/// </summary>
		/// <param name="start">the inclusive start index to begin the subsequence.</param>
		/// <returns>a String containing the subsequence.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>start</code>
		/// is negative or greater than the current
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		public virtual string substring(int start)
		{
			if (start >= 0 && start <= count)
			{
				if (start == count)
				{
					return string.Empty;
				}
				// Remove String sharing for more performance
				return new string(value, start, count - start);
			}
			throw indexAndLength(start);
		}

		/// <summary>
		/// Returns the String value of the subsequence from the
		/// <code>start</code>
		/// index
		/// to the
		/// <code>end</code>
		/// index.
		/// </summary>
		/// <param name="start">the inclusive start index to begin the subsequence.</param>
		/// <param name="end">the exclusive end index to end the subsequence.</param>
		/// <returns>a String containing the subsequence.</returns>
		/// <exception cref="StringIndexOutOfBoundsException">
		/// if
		/// <code>start</code>
		/// is negative, greater than
		/// <code>end</code>
		/// or if
		/// <code>end</code>
		/// is greater than the current
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		public virtual string substring(int start, int end)
		{
			if (start >= 0 && start <= end && end <= count)
			{
				if (start == end)
				{
					return string.Empty;
				}
				// Remove String sharing for more performance
				return new string(value, start, end - start);
			}
			throw startEndAndLength(start, end);
		}

		/// <summary>Returns the current String representation.</summary>
		/// <remarks>Returns the current String representation.</remarks>
		/// <returns>a String containing the characters in this instance.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			if (count == 0)
			{
				return string.Empty;
			}
			// Optimize String sharing for more performance
			int wasted = value.Length - count;
			if (wasted >= 256 || (wasted >= INITIAL_CAPACITY && wasted >= (count >> 1)))
			{
				return new string(value, 0, count);
			}
			shared = true;
			return Sharpen.StringHelper.GetString(0, count, value);
		}

		/// <summary>
		/// Returns a
		/// <code>CharSequence</code>
		/// of the subsequence from the
		/// <code>start</code>
		/// index to the
		/// <code>end</code>
		/// index.
		/// </summary>
		/// <param name="start">the inclusive start index to begin the subsequence.</param>
		/// <param name="end">the exclusive end index to end the subsequence.</param>
		/// <returns>a CharSequence containing the subsequence.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>start</code>
		/// is negative, greater than
		/// <code>end</code>
		/// or if
		/// <code>end</code>
		/// is greater than the current
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		/// <since>1.4</since>
		public virtual java.lang.CharSequence SubSequence(int start, int end)
		{
			return java.lang.CharSequenceProxy.Wrap(substring(start, end));
		}

		/// <summary>Searches for the first index of the specified character.</summary>
		/// <remarks>
		/// Searches for the first index of the specified character. The search for
		/// the character starts at the beginning and moves towards the end.
		/// </remarks>
		/// <param name="string">the string to find.</param>
		/// <returns>
		/// the index of the specified character, -1 if the character isn't
		/// found.
		/// </returns>
		/// <seealso cref="lastIndexOf(string)">lastIndexOf(string)</seealso>
		/// <since>1.4</since>
		public virtual int indexOf(string @string)
		{
			return indexOf(@string, 0);
		}

		/// <summary>Searches for the index of the specified character.</summary>
		/// <remarks>
		/// Searches for the index of the specified character. The search for the
		/// character starts at the specified offset and moves towards the end.
		/// </remarks>
		/// <param name="subString">the string to find.</param>
		/// <param name="start">the starting offset.</param>
		/// <returns>
		/// the index of the specified character, -1 if the character isn't
		/// found
		/// </returns>
		/// <seealso cref="lastIndexOf(string, int)">lastIndexOf(string, int)</seealso>
		/// <since>1.4</since>
		public virtual int indexOf(string subString, int start)
		{
			if (start < 0)
			{
				start = 0;
			}
			int subCount = subString.Length;
			if (subCount > 0)
			{
				if (subCount + start > count)
				{
					return -1;
				}
				// TODO optimize charAt to direct array access
				char firstChar = subString[0];
				while (true)
				{
					int i = start;
					bool found = false;
					for (; i < count; i++)
					{
						if (value[i] == firstChar)
						{
							found = true;
							break;
						}
					}
					if (!found || subCount + i > count)
					{
						return -1;
					}
					// handles subCount > count || start >= count
					int o1 = i;
					int o2 = 0;
					while (++o2 < subCount && value[++o1] == subString[o2])
					{
					}
					// Intentionally empty
					if (o2 == subCount)
					{
						return i;
					}
					start = i + 1;
				}
			}
			return (start < count || start == 0) ? start : count;
		}

		/// <summary>Searches for the last index of the specified character.</summary>
		/// <remarks>
		/// Searches for the last index of the specified character. The search for
		/// the character starts at the end and moves towards the beginning.
		/// </remarks>
		/// <param name="string">the string to find.</param>
		/// <returns>
		/// the index of the specified character, -1 if the character isn't
		/// found.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>string</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <seealso cref="string.LastIndexOf(string)">string.LastIndexOf(string)</seealso>
		/// <since>1.4</since>
		public virtual int lastIndexOf(string @string)
		{
			return lastIndexOf(@string, count);
		}

		/// <summary>Searches for the index of the specified character.</summary>
		/// <remarks>
		/// Searches for the index of the specified character. The search for the
		/// character starts at the specified offset and moves towards the beginning.
		/// </remarks>
		/// <param name="subString">the string to find.</param>
		/// <param name="start">the starting offset.</param>
		/// <returns>
		/// the index of the specified character, -1 if the character isn't
		/// found.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// if
		/// <code>subString</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <seealso cref="string.LastIndexOf(string, int)">string.LastIndexOf(string, int)</seealso>
		/// <since>1.4</since>
		public virtual int lastIndexOf(string subString, int start)
		{
			int subCount = subString.Length;
			if (subCount <= count && start >= 0)
			{
				if (subCount > 0)
				{
					if (start > count - subCount)
					{
						start = count - subCount;
					}
					// count and subCount are both
					// >= 1
					// TODO optimize charAt to direct array access
					char firstChar = subString[0];
					while (true)
					{
						int i = start;
						bool found = false;
						for (; i >= 0; --i)
						{
							if (value[i] == firstChar)
							{
								found = true;
								break;
							}
						}
						if (!found)
						{
							return -1;
						}
						int o1 = i;
						int o2 = 0;
						while (++o2 < subCount && value[++o1] == subString[o2])
						{
						}
						// Intentionally empty
						if (o2 == subCount)
						{
							return i;
						}
						start = i - 1;
					}
				}
				return start < count ? start : count;
			}
			return -1;
		}

		/// <summary>Trims off any extra capacity beyond the current length.</summary>
		/// <remarks>
		/// Trims off any extra capacity beyond the current length. Note, this method
		/// is NOT guaranteed to change the capacity of this object.
		/// </remarks>
		/// <since>1.5</since>
		public virtual void trimToSize()
		{
			if (count < value.Length)
			{
				char[] newValue = new char[count];
				System.Array.Copy(value, 0, newValue, 0, count);
				value = newValue;
				shared = false;
			}
		}

		/// <summary>
		/// Retrieves the Unicode code point value at the
		/// <code>index</code>
		/// .
		/// </summary>
		/// <param name="index">
		/// the index to the
		/// <code>char</code>
		/// code unit.
		/// </param>
		/// <returns>the Unicode code point value.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index</code>
		/// is negative or greater than or equal to
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		/// <seealso cref="char">char</seealso>
		/// <seealso cref="Sharpen.CharHelper.CodePointAt(char[], int, int)">Sharpen.CharHelper.CodePointAt(char[], int, int)
		/// 	</seealso>
		/// <since>1.5</since>
		public virtual int codePointAt(int index)
		{
			if (index < 0 || index >= count)
			{
				throw indexAndLength(index);
			}
			return Sharpen.CharHelper.CodePointAt(value, index, count);
		}

		/// <summary>
		/// Retrieves the Unicode code point value that precedes the
		/// <code>index</code>
		/// .
		/// </summary>
		/// <param name="index">
		/// the index to the
		/// <code>char</code>
		/// code unit within this object.
		/// </param>
		/// <returns>the Unicode code point value.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index</code>
		/// is less than 1 or greater than
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		/// <seealso cref="char">char</seealso>
		/// <seealso cref="Sharpen.CharHelper.CodePointBefore(char[], int, int)">Sharpen.CharHelper.CodePointBefore(char[], int, int)
		/// 	</seealso>
		/// <since>1.5</since>
		public virtual int codePointBefore(int index)
		{
			if (index < 1 || index > count)
			{
				throw indexAndLength(index);
			}
			return Sharpen.CharHelper.CodePointBefore(value, index);
		}

		/// <summary>
		/// Calculates the number of Unicode code points between
		/// <code>start</code>
		/// and
		/// <code>end</code>
		/// .
		/// </summary>
		/// <param name="start">the inclusive beginning index of the subsequence.</param>
		/// <param name="end">the exclusive end index of the subsequence.</param>
		/// <returns>the number of Unicode code points in the subsequence.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>start</code>
		/// is negative or greater than
		/// <code>end</code>
		/// or
		/// <code>end</code>
		/// is greater than
		/// <see cref="Length()">Length()</see>
		/// .
		/// </exception>
		/// <seealso cref="char">char</seealso>
		/// <seealso cref="Sharpen.CharHelper.CodePointCount(char[], int, int)">Sharpen.CharHelper.CodePointCount(char[], int, int)
		/// 	</seealso>
		/// <since>1.5</since>
		public virtual int codePointCount(int start, int end)
		{
			if (start < 0 || end > count || start > end)
			{
				throw startEndAndLength(start, end);
			}
			return Sharpen.CharHelper.CodePointCount(value, start, end - start);
		}

		/// <summary>
		/// Returns the index that is offset
		/// <code>codePointOffset</code>
		/// code points from
		/// <code>index</code>
		/// .
		/// </summary>
		/// <param name="index">the index to calculate the offset from.</param>
		/// <param name="codePointOffset">the number of code points to count.</param>
		/// <returns>
		/// the index that is
		/// <code>codePointOffset</code>
		/// code points away from
		/// index.
		/// </returns>
		/// <exception cref="IndexOutOfRangeException">
		/// if
		/// <code>index</code>
		/// is negative or greater than
		/// <see cref="Length()">Length()</see>
		/// or if there aren't enough code points
		/// before or after
		/// <code>index</code>
		/// to match
		/// <code>codePointOffset</code>
		/// .
		/// </exception>
		/// <seealso cref="char">char</seealso>
		/// <seealso cref="Sharpen.CharHelper.OffsetByCodePoints(char[], int, int, int, int)"
		/// 	>Sharpen.CharHelper.OffsetByCodePoints(char[], int, int, int, int)</seealso>
		/// <since>1.5</since>
		public virtual int offsetByCodePoints(int index, int codePointOffset)
		{
			return Sharpen.CharHelper.OffsetByCodePoints(value, 0, count, index, codePointOffset
				);
		}
	}
}
