using Sharpen;

namespace java.nio
{
	/// <summary>A buffer of chars.</summary>
	/// <remarks>
	/// A buffer of chars.
	/// <p>
	/// A char buffer can be created in either one of the following ways:
	/// <ul>
	/// <li>
	/// <see cref="allocate(int)">Allocate</see>
	/// a new char array and create a buffer
	/// based on it;</li>
	/// <li>
	/// <see cref="wrap(char[])">Wrap</see>
	/// an existing char array to create a new
	/// buffer;</li>
	/// <li>
	/// <see cref="wrap(java.lang.CharSequence)">Wrap</see>
	/// an existing char sequence to create a
	/// new buffer;</li>
	/// <li>Use
	/// <see cref="ByteBuffer.asCharBuffer()">ByteBuffer.asCharBuffer</see>
	/// to create a char buffer based on a byte buffer.</li>
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract partial class CharBuffer : java.nio.Buffer, java.lang.Comparable<
		java.nio.CharBuffer>, java.lang.CharSequence, java.lang.Appendable, java.lang.Readable
	{
		/// <summary>Creates a char buffer based on a newly allocated char array.</summary>
		/// <remarks>Creates a char buffer based on a newly allocated char array.</remarks>
		/// <param name="capacity">the capacity of the new buffer.</param>
		/// <returns>the created char buffer.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity</code>
		/// is less than zero.
		/// </exception>
		public static java.nio.CharBuffer allocate(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			return new java.nio.ReadWriteCharArrayBuffer(capacity_1);
		}

		/// <summary>Creates a new char buffer by wrapping the given char array.</summary>
		/// <remarks>
		/// Creates a new char buffer by wrapping the given char array.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>wrap(array, 0, array.length)</code>
		/// .
		/// </remarks>
		/// <param name="array">the char array which the new buffer will be based on.</param>
		/// <returns>the created char buffer.</returns>
		public static java.nio.CharBuffer wrap(char[] array_1)
		{
			return wrap(array_1, 0, array_1.Length);
		}

		/// <summary>Creates a new char buffer by wrapping the given char array.</summary>
		/// <remarks>
		/// Creates a new char buffer by wrapping the given char array.
		/// <p>
		/// The new buffer's position will be
		/// <code>start</code>
		/// , limit will be
		/// <code>start + charCount</code>
		/// , capacity will be the length of the array.
		/// </remarks>
		/// <param name="array">the char array which the new buffer will be based on.</param>
		/// <param name="start">
		/// the start index, must not be negative and not greater than
		/// <code>array.length</code>
		/// .
		/// </param>
		/// <param name="charCount">
		/// the length, must not be negative and not greater than
		/// <code>array.length - start</code>
		/// .
		/// </param>
		/// <returns>the created char buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>charCount</code>
		/// is invalid.
		/// </exception>
		public static java.nio.CharBuffer wrap(char[] array_1, int start, int charCount)
		{
			java.util.Arrays.checkOffsetAndCount(array_1.Length, start, charCount);
			java.nio.CharBuffer buf = new java.nio.ReadWriteCharArrayBuffer(array_1);
			buf._position = start;
			buf._limit = start + charCount;
			return buf;
		}

		/// <summary>Creates a new char buffer by wrapping the given char sequence.</summary>
		/// <remarks>
		/// Creates a new char buffer by wrapping the given char sequence.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>wrap(chseq, 0, chseq.length())</code>
		/// .
		/// </remarks>
		/// <param name="chseq">the char sequence which the new buffer will be based on.</param>
		/// <returns>the created char buffer.</returns>
		public static java.nio.CharBuffer wrap(java.lang.CharSequence chseq)
		{
			return new java.nio.CharSequenceAdapter(chseq);
		}

		/// <summary>Creates a new char buffer by wrapping the given char sequence.</summary>
		/// <remarks>
		/// Creates a new char buffer by wrapping the given char sequence.
		/// <p>
		/// The new buffer's position will be
		/// <code>start</code>
		/// , limit will be
		/// <code>end</code>
		/// , capacity will be the length of the char sequence. The new
		/// buffer is read-only.
		/// </remarks>
		/// <param name="cs">the char sequence which the new buffer will be based on.</param>
		/// <param name="start">
		/// the start index, must not be negative and not greater than
		/// <code>cs.length()</code>
		/// .
		/// </param>
		/// <param name="end">
		/// the end index, must be no less than
		/// <code>start</code>
		/// and no
		/// greater than
		/// <code>cs.length()</code>
		/// .
		/// </param>
		/// <returns>the created char buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>end</code>
		/// is invalid.
		/// </exception>
		public static java.nio.CharBuffer wrap(java.lang.CharSequence cs, int start, int 
			end)
		{
			if (start < 0 || end < start || end > cs.Length)
			{
				throw new System.IndexOutOfRangeException("cs.length()=" + cs.Length + ", start="
					 + start + ", end=" + end);
			}
			java.nio.CharBuffer result = new java.nio.CharSequenceAdapter(cs);
			result._position = start;
			result._limit = end;
			return result;
		}

		internal CharBuffer(int capacity_1) : base(1, capacity_1, null)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override object array()
		{
			return protectedArray();
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override int arrayOffset()
		{
			return protectedArrayOffset();
		}

		/// <summary>Returns a read-only buffer that shares its content with this buffer.</summary>
		/// <remarks>
		/// Returns a read-only buffer that shares its content with this buffer.
		/// <p>
		/// The returned buffer is guaranteed to be a new instance, even if this
		/// buffer is read-only itself. The new buffer's position, limit, capacity
		/// and mark are the same as this buffer's.
		/// <p>
		/// The new buffer shares its content with this buffer, which means this
		/// buffer's change of content will be visible to the new buffer. The two
		/// buffer's position, limit and mark are independent.
		/// </remarks>
		/// <returns>a read-only version of this buffer.</returns>
		public abstract java.nio.CharBuffer asReadOnlyBuffer();

		/// <summary>Returns the character located at the specified index in the buffer.</summary>
		/// <remarks>
		/// Returns the character located at the specified index in the buffer. The
		/// index value is referenced from the current buffer position.
		/// </remarks>
		/// <param name="index">
		/// the index referenced from the current buffer position. It must
		/// not be less than zero but less than the value obtained from a
		/// call to
		/// <code>remaining()</code>
		/// .
		/// </param>
		/// <returns>
		/// the character located at the specified index (referenced from the
		/// current position) in the buffer.
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if the index is invalid.
		/// </exception>
		public char this[int index]
		{
			get
			{
				if (index < 0 || index >= remaining())
				{
					throw new System.IndexOutOfRangeException("index=" + index + ", remaining()=" + remaining
						());
				}
				return get(_position + index);
			}
		}

		/// <summary>Compacts this char buffer.</summary>
		/// <remarks>
		/// Compacts this char buffer.
		/// <p>
		/// The remaining chars will be moved to the head of the buffer,
		/// starting from position zero. Then the position is set to
		/// <code>remaining()</code>
		/// ; the limit is set to capacity; the mark is cleared.
		/// </remarks>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.CharBuffer compact();

		/// <summary>
		/// Compare the remaining chars of this buffer to another char
		/// buffer's remaining chars.
		/// </summary>
		/// <remarks>
		/// Compare the remaining chars of this buffer to another char
		/// buffer's remaining chars.
		/// </remarks>
		/// <param name="otherBuffer">another char buffer.</param>
		/// <returns>
		/// a negative value if this is less than
		/// <code>otherBuffer</code>
		/// ; 0 if
		/// this equals to
		/// <code>otherBuffer</code>
		/// ; a positive value if this is
		/// greater than
		/// <code>otherBuffer</code>
		/// .
		/// </returns>
		/// <exception>
		/// ClassCastException
		/// if
		/// <code>otherBuffer</code>
		/// is not a char buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(java.nio.CharBuffer otherBuffer)
		{
			int compareRemaining = (remaining() < otherBuffer.remaining()) ? remaining() : otherBuffer
				.remaining();
			int thisPos = _position;
			int otherPos = otherBuffer._position;
			char thisByte;
			char otherByte;
			while (compareRemaining > 0)
			{
				thisByte = get(thisPos);
				otherByte = otherBuffer.get(otherPos);
				if (thisByte != otherByte)
				{
					return thisByte < otherByte ? -1 : 1;
				}
				thisPos++;
				otherPos++;
				compareRemaining--;
			}
			return remaining() - otherBuffer.remaining();
		}

		/// <summary>Returns a duplicated buffer that shares its content with this buffer.</summary>
		/// <remarks>
		/// Returns a duplicated buffer that shares its content with this buffer.
		/// <p>
		/// The duplicated buffer's initial position, limit, capacity and mark are
		/// the same as this buffer's. The duplicated buffer's read-only property and
		/// byte order are the same as this buffer's, too.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a duplicated buffer that shares its content with this buffer.</returns>
		public abstract java.nio.CharBuffer duplicate();

		/// <summary>Checks whether this char buffer is equal to another object.</summary>
		/// <remarks>
		/// Checks whether this char buffer is equal to another object.
		/// <p>
		/// If
		/// <code>other</code>
		/// is not a char buffer then
		/// <code>false</code>
		/// is returned. Two
		/// char buffers are equal if and only if their remaining chars are exactly
		/// the same. Position, limit, capacity and mark are not considered.
		/// </remarks>
		/// <param name="other">the object to compare with this char buffer.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this char buffer is equal to
		/// <code>other</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			if (!(other is java.nio.CharBuffer))
			{
				return false;
			}
			java.nio.CharBuffer otherBuffer = (java.nio.CharBuffer)other;
			if (remaining() != otherBuffer.remaining())
			{
				return false;
			}
			int myPosition = _position;
			int otherPosition = otherBuffer._position;
			bool equalSoFar = true;
			while (equalSoFar && (myPosition < _limit))
			{
				equalSoFar = get(myPosition++) == otherBuffer.get(otherPosition++);
			}
			return equalSoFar;
		}

		/// <summary>Returns the char at the current position and increases the position by 1.
		/// 	</summary>
		/// <remarks>Returns the char at the current position and increases the position by 1.
		/// 	</remarks>
		/// <returns>the char at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is equal or greater than limit.
		/// </exception>
		public abstract char get();

		/// <summary>
		/// Reads chars from the current position into the specified char array and
		/// increases the position by the number of chars read.
		/// </summary>
		/// <remarks>
		/// Reads chars from the current position into the specified char array and
		/// increases the position by the number of chars read.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>get(dst, 0, dst.length)</code>
		/// .
		/// </remarks>
		/// <param name="dst">the destination char array.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>dst.length</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.CharBuffer get(char[] dst)
		{
			return get(dst, 0, dst.Length);
		}

		/// <summary>
		/// Reads chars from the current position into the specified char array,
		/// starting from the specified offset, and increases the position by the
		/// number of chars read.
		/// </summary>
		/// <remarks>
		/// Reads chars from the current position into the specified char array,
		/// starting from the specified offset, and increases the position by the
		/// number of chars read.
		/// </remarks>
		/// <param name="dst">the target char array.</param>
		/// <param name="dstOffset">
		/// the offset of the char array, must not be negative and not
		/// greater than
		/// <code>dst.length</code>
		/// .
		/// </param>
		/// <param name="charCount">
		/// The number of chars to read, must be no less than zero and no
		/// greater than
		/// <code>dst.length - dstOffset</code>
		/// .
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>dstOffset</code>
		/// or
		/// <code>charCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>charCount</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.CharBuffer get(char[] dst, int dstOffset, int charCount)
		{
			java.util.Arrays.checkOffsetAndCount(dst.Length, dstOffset, charCount);
			if (charCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			{
				for (int i = dstOffset; i < dstOffset + charCount; ++i)
				{
					dst[i] = get();
				}
			}
			return this;
		}

		/// <summary>Returns a char at the specified index; the position is not changed.</summary>
		/// <remarks>Returns a char at the specified index; the position is not changed.</remarks>
		/// <param name="index">the index, must not be negative and less than limit.</param>
		/// <returns>a char at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		public abstract char get(int index);

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool hasArray()
		{
			return protectedHasArray();
		}

		/// <summary>Calculates this buffer's hash code from the remaining chars.</summary>
		/// <remarks>
		/// Calculates this buffer's hash code from the remaining chars. The
		/// position, limit, capacity and mark don't affect the hash code.
		/// </remarks>
		/// <returns>the hash code calculated from the remaining chars.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int myPosition = _position;
			int hash = 0;
			while (myPosition < _limit)
			{
				hash = hash + get(myPosition++);
			}
			return hash;
		}

		/// <summary>Indicates whether this buffer is direct.</summary>
		/// <remarks>
		/// Indicates whether this buffer is direct. A direct buffer will try its
		/// best to take advantage of native memory APIs and it may not stay in the
		/// Java heap, so it is not affected by garbage collection.
		/// <p>
		/// A char buffer is direct if it is based on a byte buffer and the byte
		/// buffer is direct.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this buffer is direct,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public abstract override bool isDirect();

		/// <summary>Returns the number of remaining chars.</summary>
		/// <remarks>Returns the number of remaining chars.</remarks>
		/// <returns>the number of remaining chars.</returns>
		public int Length
		{
			get
			{
				return remaining();
			}
		}

		/// <summary>
		/// Returns the byte order used by this buffer when converting chars from/to
		/// bytes.
		/// </summary>
		/// <remarks>
		/// Returns the byte order used by this buffer when converting chars from/to
		/// bytes.
		/// <p>
		/// If this buffer is not based on a byte buffer, then this always returns
		/// the platform's native byte order.
		/// </remarks>
		/// <returns>
		/// the byte order used by this buffer when converting chars from/to
		/// bytes.
		/// </returns>
		public abstract java.nio.ByteOrder order();

		/// <summary>
		/// Child class implements this method to realize
		/// <code>array()</code>
		/// .
		/// </summary>
		/// <seealso cref="array()">array()</seealso>
		internal abstract char[] protectedArray();

		/// <summary>
		/// Child class implements this method to realize
		/// <code>arrayOffset()</code>
		/// .
		/// </summary>
		/// <seealso cref="arrayOffset()">arrayOffset()</seealso>
		internal abstract int protectedArrayOffset();

		/// <summary>
		/// Child class implements this method to realize
		/// <code>hasArray()</code>
		/// .
		/// </summary>
		/// <seealso cref="hasArray()">hasArray()</seealso>
		internal abstract bool protectedHasArray();

		/// <summary>
		/// Writes the given char to the current position and increases the position
		/// by 1.
		/// </summary>
		/// <remarks>
		/// Writes the given char to the current position and increases the position
		/// by 1.
		/// </remarks>
		/// <param name="c">the char to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is equal or greater than limit.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.CharBuffer put(char c);

		/// <summary>
		/// Writes chars from the given char array to the current position and
		/// increases the position by the number of chars written.
		/// </summary>
		/// <remarks>
		/// Writes chars from the given char array to the current position and
		/// increases the position by the number of chars written.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>put(src, 0, src.length)</code>
		/// .
		/// </remarks>
		/// <param name="src">the source char array.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than
		/// <code>src.length</code>
		/// .
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public java.nio.CharBuffer put(char[] src)
		{
			return put(src, 0, src.Length);
		}

		/// <summary>
		/// Writes chars from the given char array, starting from the specified offset,
		/// to the current position and increases the position by the number of chars
		/// written.
		/// </summary>
		/// <remarks>
		/// Writes chars from the given char array, starting from the specified offset,
		/// to the current position and increases the position by the number of chars
		/// written.
		/// </remarks>
		/// <param name="src">the source char array.</param>
		/// <param name="srcOffset">
		/// the offset of char array, must not be negative and not greater
		/// than
		/// <code>src.length</code>
		/// .
		/// </param>
		/// <param name="charCount">
		/// the number of chars to write, must be no less than zero and no
		/// greater than
		/// <code>src.length - srcOffset</code>
		/// .
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than
		/// <code>charCount</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>srcOffset</code>
		/// or
		/// <code>charCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.CharBuffer put(char[] src, int srcOffset, int charCount)
		{
			java.util.Arrays.checkOffsetAndCount(src.Length, srcOffset, charCount);
			if (charCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			{
				for (int i = srcOffset; i < srcOffset + charCount; ++i)
				{
					put(src[i]);
				}
			}
			return this;
		}

		/// <summary>
		/// Writes all the remaining chars of the
		/// <code>src</code>
		/// char buffer to this
		/// buffer's current position, and increases both buffers' position by the
		/// number of chars copied.
		/// </summary>
		/// <param name="src">the source char buffer.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>src.remaining()</code>
		/// is greater than this buffer's
		/// <code>remaining()</code>
		/// .
		/// </exception>
		/// <exception>
		/// IllegalArgumentException
		/// if
		/// <code>src</code>
		/// is this buffer.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.CharBuffer put(java.nio.CharBuffer src)
		{
			if (src == this)
			{
				throw new System.ArgumentException();
			}
			if (src.remaining() > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			char[] contents = new char[src.remaining()];
			src.get(contents);
			put(contents);
			return this;
		}

		/// <summary>
		/// Writes a char to the specified index of this buffer; the position is not
		/// changed.
		/// </summary>
		/// <remarks>
		/// Writes a char to the specified index of this buffer; the position is not
		/// changed.
		/// </remarks>
		/// <param name="index">the index, must be no less than zero and less than the limit.
		/// 	</param>
		/// <param name="c">the char to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.CharBuffer put(int index, char c);

		/// <summary>
		/// Writes all chars of the given string to the current position of this
		/// buffer, and increases the position by the length of string.
		/// </summary>
		/// <remarks>
		/// Writes all chars of the given string to the current position of this
		/// buffer, and increases the position by the length of string.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>put(str, 0, str.length())</code>
		/// .
		/// </remarks>
		/// <param name="str">the string to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than the length of string.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public java.nio.CharBuffer put(string str)
		{
			return put(str, 0, str.Length);
		}

		/// <summary>
		/// Writes chars of the given string to the current position of this buffer,
		/// and increases the position by the number of chars written.
		/// </summary>
		/// <remarks>
		/// Writes chars of the given string to the current position of this buffer,
		/// and increases the position by the number of chars written.
		/// </remarks>
		/// <param name="str">the string to write.</param>
		/// <param name="start">
		/// the first char to write, must not be negative and not greater
		/// than
		/// <code>str.length()</code>
		/// .
		/// </param>
		/// <param name="end">
		/// the last char to write (excluding), must be less than
		/// <code>start</code>
		/// and not greater than
		/// <code>str.length()</code>
		/// .
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than
		/// <code>end - start</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>end</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.CharBuffer put(string str, int start, int end)
		{
			if (start < 0 || end < start || end > str.Length)
			{
				throw new System.IndexOutOfRangeException("str.length()=" + str.Length + ", start="
					 + start + ", end=" + end);
			}
			if (end - start > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			{
				for (int i = start; i < end; i++)
				{
					put(str[i]);
				}
			}
			return this;
		}

		/// <summary>Returns a sliced buffer that shares its content with this buffer.</summary>
		/// <remarks>
		/// Returns a sliced buffer that shares its content with this buffer.
		/// <p>
		/// The sliced buffer's capacity will be this buffer's
		/// <code>remaining()</code>
		/// ,
		/// and its zero position will correspond to this buffer's current position.
		/// The new buffer's position will be 0, limit will be its capacity, and its
		/// mark is cleared. The new buffer's read-only property and byte order are
		/// same as this buffer.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a sliced buffer that shares its content with this buffer.</returns>
		public abstract java.nio.CharBuffer slice();

		/// <summary>Returns a string representing the current remaining chars of this buffer.
		/// 	</summary>
		/// <remarks>Returns a string representing the current remaining chars of this buffer.
		/// 	</remarks>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder result = new java.lang.StringBuilder(_limit - _position);
			{
				for (int i = _position; i < _limit; i++)
				{
					result.append(get(i));
				}
			}
			return result.ToString();
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(char c)
		{
			return append(c);
		}

		/// <summary>
		/// Writes the given char to the current position and increases the position
		/// by 1.
		/// </summary>
		/// <remarks>
		/// Writes the given char to the current position and increases the position
		/// by 1.
		/// </remarks>
		/// <param name="c">the char to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is equal or greater than limit.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.nio.CharBuffer append(char c)
		{
			return put(c);
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence csq)
		{
			return append(csq);
		}

		/// <summary>
		/// Writes all chars of the given character sequence
		/// <code>csq</code>
		/// to the
		/// current position of this buffer, and increases the position by the length
		/// of the csq.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>append(csq.toString())</code>
		/// .
		/// If the
		/// <code>CharSequence</code>
		/// is
		/// <code>null</code>
		/// the string "null" will be
		/// written to the buffer.
		/// </summary>
		/// <param name="csq">
		/// the
		/// <code>CharSequence</code>
		/// to write.
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than the length of csq.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.nio.CharBuffer append(java.lang.CharSequence csq)
		{
			if (csq != null)
			{
				return put(csq.ToString());
			}
			return put("null");
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence csq, int 
			start, int end)
		{
			return append(csq, start, end);
		}

		/// <summary>
		/// Writes chars of the given
		/// <code>CharSequence</code>
		/// to the current position of
		/// this buffer, and increases the position by the number of chars written.
		/// </summary>
		/// <param name="csq">
		/// the
		/// <code>CharSequence</code>
		/// to write.
		/// </param>
		/// <param name="start">
		/// the first char to write, must not be negative and not greater
		/// than
		/// <code>csq.length()</code>
		/// .
		/// </param>
		/// <param name="end">
		/// the last char to write (excluding), must be less than
		/// <code>start</code>
		/// and not greater than
		/// <code>csq.length()</code>
		/// .
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than
		/// <code>end - start</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>end</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.nio.CharBuffer append(java.lang.CharSequence csq, int start, 
			int end)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			java.lang.CharSequence cs = csq.SubSequence(start, end);
			if (cs.Length > 0)
			{
				return put(cs.ToString());
			}
			return this;
		}

		/// <summary>
		/// Reads characters from this buffer and puts them into
		/// <code>target</code>
		/// . The
		/// number of chars that are copied is either the number of remaining chars
		/// in this buffer or the number of remaining chars in
		/// <code>target</code>
		/// ,
		/// whichever is smaller.
		/// </summary>
		/// <param name="target">the target char buffer.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>target</code>
		/// is this buffer.
		/// </exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="ReadOnlyBufferException">
		/// if no changes may be made to the contents of
		/// <code>target</code>
		/// .
		/// </exception>
		/// <returns>
		/// the number of chars copied or -1 if there are no chars left to be
		/// read from this buffer.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.lang.Readable")]
		public virtual int read(java.nio.CharBuffer target)
		{
			int remaining_1 = remaining();
			if (target == this)
			{
				if (remaining_1 == 0)
				{
					return -1;
				}
				throw new System.ArgumentException();
			}
			if (remaining_1 == 0)
			{
				return _limit > 0 && target.remaining() == 0 ? 0 : -1;
			}
			remaining_1 = System.Math.Min(target.remaining(), remaining_1);
			if (remaining_1 > 0)
			{
				char[] chars = new char[remaining_1];
				get(chars);
				target.put(chars);
			}
			return remaining_1;
		}
	}
}
