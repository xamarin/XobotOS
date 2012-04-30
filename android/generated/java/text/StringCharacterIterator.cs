using Sharpen;

namespace java.text
{
	/// <summary>
	/// An implementation of
	/// <see cref="CharacterIterator">CharacterIterator</see>
	/// for strings.
	/// </summary>
	[Sharpen.Sharpened]
	public sealed class StringCharacterIterator : java.text.CharacterIterator
	{
		internal string @string;

		internal int start;

		internal int end;

		internal int offset;

		/// <summary>
		/// Constructs a new
		/// <code>StringCharacterIterator</code>
		/// on the specified string.
		/// The begin and current indices are set to the beginning of the string, the
		/// end index is set to the length of the string.
		/// </summary>
		/// <param name="value">the source string to iterate over.</param>
		public StringCharacterIterator(string value)
		{
			@string = value;
			start = offset = 0;
			end = @string.Length;
		}

		/// <summary>
		/// Constructs a new
		/// <code>StringCharacterIterator</code>
		/// on the specified string
		/// with the current index set to the specified value. The begin index is set
		/// to the beginning of the string, the end index is set to the length of the
		/// string.
		/// </summary>
		/// <param name="value">the source string to iterate over.</param>
		/// <param name="location">the current index.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>location</code>
		/// is negative or greater than the length
		/// of the source string.
		/// </exception>
		public StringCharacterIterator(string value, int location)
		{
			@string = value;
			start = 0;
			end = @string.Length;
			if (location < 0 || location > end)
			{
				throw new System.ArgumentException();
			}
			offset = location;
		}

		/// <summary>
		/// Constructs a new
		/// <code>StringCharacterIterator</code>
		/// on the specified string
		/// with the begin, end and current index set to the specified values.
		/// </summary>
		/// <param name="value">the source string to iterate over.</param>
		/// <param name="start">the index of the first character to iterate.</param>
		/// <param name="end">the index one past the last character to iterate.</param>
		/// <param name="location">the current index.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &lt; 0</code>
		/// ,
		/// <code>start &gt; end</code>
		/// ,
		/// <code>
		/// location &lt;
		/// start
		/// </code>
		/// ,
		/// <code>location &gt; end</code>
		/// or if
		/// <code>end</code>
		/// is greater
		/// than the length of
		/// <code>value</code>
		/// .
		/// </exception>
		public StringCharacterIterator(string value, int start, int end, int location)
		{
			@string = value;
			if (start < 0 || end > @string.Length || start > end || location < start || location
				 > end)
			{
				throw new System.ArgumentException();
			}
			this.start = start;
			this.end = end;
			offset = location;
		}

		/// <summary>
		/// Returns a new
		/// <code>StringCharacterIterator</code>
		/// with the same source
		/// string, begin, end, and current index as this iterator.
		/// </summary>
		/// <returns>a shallow copy of this iterator.</returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		/// <summary>Returns the character at the current index in the source string.</summary>
		/// <remarks>Returns the character at the current index in the source string.</remarks>
		/// <returns>
		/// the current character, or
		/// <code>DONE</code>
		/// if the current index is
		/// past the end.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public char current()
		{
			if (offset == end)
			{
				return java.text.CharacterIteratorClass.DONE;
			}
			return @string[offset];
		}

		/// <summary>
		/// Compares the specified object with this
		/// <code>StringCharacterIterator</code>
		/// and indicates if they are equal. In order to be equal,
		/// <code>object</code>
		/// must be an instance of
		/// <code>StringCharacterIterator</code>
		/// that iterates over
		/// the same sequence of characters with the same index.
		/// </summary>
		/// <param name="object">the object to compare with this object.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the specified object is equal to this
		/// <code>StringCharacterIterator</code>
		/// ;
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="GetHashCode()">GetHashCode()</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			if (!(@object is java.text.StringCharacterIterator))
			{
				return false;
			}
			java.text.StringCharacterIterator it = (java.text.StringCharacterIterator)@object;
			return @string.Equals(it.@string) && start == it.start && end == it.end && offset
				 == it.offset;
		}

		/// <summary>
		/// Sets the current position to the begin index and returns the character at
		/// the new position in the source string.
		/// </summary>
		/// <remarks>
		/// Sets the current position to the begin index and returns the character at
		/// the new position in the source string.
		/// </remarks>
		/// <returns>
		/// the character at the begin index or
		/// <code>DONE</code>
		/// if the begin
		/// index is equal to the end index.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public char first()
		{
			if (start == end)
			{
				return java.text.CharacterIteratorClass.DONE;
			}
			offset = start;
			return @string[offset];
		}

		/// <summary>Returns the begin index in the source string.</summary>
		/// <remarks>Returns the begin index in the source string.</remarks>
		/// <returns>the index of the first character of the iteration.</returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public int getBeginIndex()
		{
			return start;
		}

		/// <summary>Returns the end index in the source string.</summary>
		/// <remarks>Returns the end index in the source string.</remarks>
		/// <returns>the index one past the last character of the iteration.</returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public int getEndIndex()
		{
			return end;
		}

		/// <summary>Returns the current index in the source string.</summary>
		/// <remarks>Returns the current index in the source string.</remarks>
		/// <returns>the current index.</returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public int getIndex()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			return @string.GetHashCode() + start + end + offset;
		}

		/// <summary>
		/// Sets the current position to the end index - 1 and returns the character
		/// at the new position.
		/// </summary>
		/// <remarks>
		/// Sets the current position to the end index - 1 and returns the character
		/// at the new position.
		/// </remarks>
		/// <returns>
		/// the character before the end index or
		/// <code>DONE</code>
		/// if the begin
		/// index is equal to the end index.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public char last()
		{
			if (start == end)
			{
				return java.text.CharacterIteratorClass.DONE;
			}
			offset = end - 1;
			return @string[offset];
		}

		/// <summary>Increments the current index and returns the character at the new index.
		/// 	</summary>
		/// <remarks>Increments the current index and returns the character at the new index.
		/// 	</remarks>
		/// <returns>
		/// the character at the next index, or
		/// <code>DONE</code>
		/// if the next
		/// index would be past the end.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public char next()
		{
			if (offset >= (end - 1))
			{
				offset = end;
				return java.text.CharacterIteratorClass.DONE;
			}
			return @string[++offset];
		}

		/// <summary>Decrements the current index and returns the character at the new index.
		/// 	</summary>
		/// <remarks>Decrements the current index and returns the character at the new index.
		/// 	</remarks>
		/// <returns>
		/// the character at the previous index, or
		/// <code>DONE</code>
		/// if the
		/// previous index would be past the beginning.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public char previous()
		{
			if (offset == start)
			{
				return java.text.CharacterIteratorClass.DONE;
			}
			return @string[--offset];
		}

		/// <summary>Sets the current index in the source string.</summary>
		/// <remarks>Sets the current index in the source string.</remarks>
		/// <param name="location">the index the current position is set to.</param>
		/// <returns>
		/// the character at the new index, or
		/// <code>DONE</code>
		/// if
		/// <code>location</code>
		/// is set to the end index.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>location</code>
		/// is smaller than the begin index or greater
		/// than the end index.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.text.CharacterIterator")]
		public char setIndex(int location)
		{
			if (location < start || location > end)
			{
				throw new System.ArgumentException();
			}
			offset = location;
			if (offset == end)
			{
				return java.text.CharacterIteratorClass.DONE;
			}
			return @string[offset];
		}

		/// <summary>Sets the source string to iterate over.</summary>
		/// <remarks>
		/// Sets the source string to iterate over. The begin and end positions are
		/// set to the start and end of this string.
		/// </remarks>
		/// <param name="value">the new source string.</param>
		public void setText(string value)
		{
			@string = value;
			start = offset = 0;
			end = value.Length;
		}
	}
}
