using Sharpen;

namespace java.nio
{
	/// <summary>A buffer of shorts.</summary>
	/// <remarks>
	/// A buffer of shorts.
	/// <p>
	/// A short buffer can be created in either of the following ways:
	/// <ul>
	/// <li>
	/// <see cref="allocate(int)">Allocate</see>
	/// a new short array and create a buffer
	/// based on it;</li>
	/// <li>
	/// <see cref="wrap(short[])">Wrap</see>
	/// an existing short array to create a new
	/// buffer;</li>
	/// <li>Use
	/// <see cref="ByteBuffer.asShortBuffer()">ByteBuffer.asShortBuffer</see>
	/// to create a short buffer based on a byte buffer.</li>
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class ShortBuffer : java.nio.Buffer, java.lang.Comparable<java.nio.ShortBuffer
		>
	{
		/// <summary>Creates a short buffer based on a newly allocated short array.</summary>
		/// <remarks>Creates a short buffer based on a newly allocated short array.</remarks>
		/// <param name="capacity">the capacity of the new buffer.</param>
		/// <returns>the created short buffer.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity</code>
		/// is less than zero.
		/// </exception>
		public static java.nio.ShortBuffer allocate(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			return new java.nio.ReadWriteShortArrayBuffer(capacity_1);
		}

		/// <summary>Creates a new short buffer by wrapping the given short array.</summary>
		/// <remarks>
		/// Creates a new short buffer by wrapping the given short array.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>wrap(array, 0, array.length)</code>
		/// .
		/// </remarks>
		/// <param name="array">the short array which the new buffer will be based on.</param>
		/// <returns>the created short buffer.</returns>
		public static java.nio.ShortBuffer wrap(short[] array_1)
		{
			return wrap(array_1, 0, array_1.Length);
		}

		/// <summary>Creates a new short buffer by wrapping the given short array.</summary>
		/// <remarks>
		/// Creates a new short buffer by wrapping the given short array.
		/// <p>
		/// The new buffer's position will be
		/// <code>start</code>
		/// , limit will be
		/// <code>start + shortCount</code>
		/// , capacity will be the length of the array.
		/// </remarks>
		/// <param name="array">the short array which the new buffer will be based on.</param>
		/// <param name="start">
		/// the start index, must not be negative and not greater than
		/// <code>array.length</code>
		/// .
		/// </param>
		/// <param name="shortCount">
		/// the length, must not be negative and not greater than
		/// <code>array.length - start</code>
		/// .
		/// </param>
		/// <returns>the created short buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>shortCount</code>
		/// is invalid.
		/// </exception>
		public static java.nio.ShortBuffer wrap(short[] array_1, int start, int shortCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(array_1.Length, start, shortCount);
			java.nio.ShortBuffer buf = new java.nio.ReadWriteShortArrayBuffer(array_1);
			buf._position = start;
			buf._limit = start + shortCount;
			return buf;
		}

		internal ShortBuffer(int capacity_1) : base(1, capacity_1, null)
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
		public abstract java.nio.ShortBuffer asReadOnlyBuffer();

		/// <summary>Compacts this short buffer.</summary>
		/// <remarks>
		/// Compacts this short buffer.
		/// <p>
		/// The remaining shorts will be moved to the head of the buffer, starting
		/// from position zero. Then the position is set to
		/// <code>remaining()</code>
		/// ; the
		/// limit is set to capacity; the mark is cleared.
		/// </remarks>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ShortBuffer compact();

		/// <summary>
		/// Compare the remaining shorts of this buffer to another short buffer's
		/// remaining shorts.
		/// </summary>
		/// <remarks>
		/// Compare the remaining shorts of this buffer to another short buffer's
		/// remaining shorts.
		/// </remarks>
		/// <param name="otherBuffer">another short buffer.</param>
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
		/// is not a short buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(java.nio.ShortBuffer otherBuffer)
		{
			int compareRemaining = (remaining() < otherBuffer.remaining()) ? remaining() : otherBuffer
				.remaining();
			int thisPos = _position;
			int otherPos = otherBuffer._position;
			short thisByte;
			short otherByte;
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
		/// The duplicated buffer's position, limit, capacity and mark are the same
		/// as this buffer. The duplicated buffer's read-only property and byte order
		/// are the same as this buffer's.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a duplicated buffer that shares its content with this buffer.</returns>
		public abstract java.nio.ShortBuffer duplicate();

		/// <summary>Checks whether this short buffer is equal to another object.</summary>
		/// <remarks>
		/// Checks whether this short buffer is equal to another object.
		/// <p>
		/// If
		/// <code>other</code>
		/// is not a short buffer then
		/// <code>false</code>
		/// is returned.
		/// Two short buffers are equal if and only if their remaining shorts are
		/// exactly the same. Position, limit, capacity and mark are not considered.
		/// </remarks>
		/// <param name="other">the object to compare with this short buffer.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this short buffer is equal to
		/// <code>other</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			if (!(other is java.nio.ShortBuffer))
			{
				return false;
			}
			java.nio.ShortBuffer otherBuffer = (java.nio.ShortBuffer)other;
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

		/// <summary>
		/// Returns the short at the current position and increases the position by
		/// 1.
		/// </summary>
		/// <remarks>
		/// Returns the short at the current position and increases the position by
		/// 1.
		/// </remarks>
		/// <returns>the short at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is equal or greater than limit.
		/// </exception>
		public abstract short get();

		/// <summary>
		/// Reads shorts from the current position into the specified short array and
		/// increases the position by the number of shorts read.
		/// </summary>
		/// <remarks>
		/// Reads shorts from the current position into the specified short array and
		/// increases the position by the number of shorts read.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>get(dst, 0, dst.length)</code>
		/// .
		/// </remarks>
		/// <param name="dst">the destination short array.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>dst.length</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.ShortBuffer get(short[] dst)
		{
			return get(dst, 0, dst.Length);
		}

		/// <summary>
		/// Reads shorts from the current position into the specified short array,
		/// starting from the specified offset, and increases the position by the
		/// number of shorts read.
		/// </summary>
		/// <remarks>
		/// Reads shorts from the current position into the specified short array,
		/// starting from the specified offset, and increases the position by the
		/// number of shorts read.
		/// </remarks>
		/// <param name="dst">the target short array.</param>
		/// <param name="dstOffset">
		/// the offset of the short array, must not be negative and not
		/// greater than
		/// <code>dst.length</code>
		/// .
		/// </param>
		/// <param name="shortCount">
		/// the number of shorts to read, must be no less than zero and
		/// not greater than
		/// <code>dst.length - dstOffset</code>
		/// .
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>dstOffset</code>
		/// or
		/// <code>shortCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>shortCount</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.ShortBuffer get(short[] dst, int dstOffset, int shortCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(dst.Length, dstOffset, shortCount);
			if (shortCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			{
				for (int i = dstOffset; i < dstOffset + shortCount; ++i)
				{
					dst[i] = get();
				}
			}
			return this;
		}

		/// <summary>Returns the short at the specified index; the position is not changed.</summary>
		/// <remarks>Returns the short at the specified index; the position is not changed.</remarks>
		/// <param name="index">the index, must not be negative and less than limit.</param>
		/// <returns>a short at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		public abstract short get(int index);

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
		/// <returns>the hash code calculated from the remaining shorts.</returns>
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
		/// A short buffer is direct if it is based on a byte buffer and the byte
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

		/// <summary>
		/// Returns the byte order used by this buffer when converting shorts from/to
		/// bytes.
		/// </summary>
		/// <remarks>
		/// Returns the byte order used by this buffer when converting shorts from/to
		/// bytes.
		/// <p>
		/// If this buffer is not based on a byte buffer, then always return the
		/// platform's native byte order.
		/// </remarks>
		/// <returns>
		/// the byte order used by this buffer when converting shorts from/to
		/// bytes.
		/// </returns>
		public abstract java.nio.ByteOrder order();

		/// <summary>
		/// Child class implements this method to realize
		/// <code>array()</code>
		/// .
		/// </summary>
		/// <returns>
		/// see
		/// <code>array()</code>
		/// </returns>
		internal abstract short[] protectedArray();

		/// <summary>
		/// Child class implements this method to realize
		/// <code>arrayOffset()</code>
		/// .
		/// </summary>
		/// <returns>
		/// see
		/// <code>arrayOffset()</code>
		/// </returns>
		internal abstract int protectedArrayOffset();

		/// <summary>
		/// Child class implements this method to realize
		/// <code>hasArray()</code>
		/// .
		/// </summary>
		/// <returns>
		/// see
		/// <code>hasArray()</code>
		/// </returns>
		internal abstract bool protectedHasArray();

		/// <summary>
		/// Writes the given short to the current position and increases the position
		/// by 1.
		/// </summary>
		/// <remarks>
		/// Writes the given short to the current position and increases the position
		/// by 1.
		/// </remarks>
		/// <param name="s">the short to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is equal or greater than limit.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ShortBuffer put(short s);

		/// <summary>
		/// Writes shorts from the given short array to the current position and
		/// increases the position by the number of shorts written.
		/// </summary>
		/// <remarks>
		/// Writes shorts from the given short array to the current position and
		/// increases the position by the number of shorts written.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>put(src, 0, src.length)</code>
		/// .
		/// </remarks>
		/// <param name="src">the source short array.</param>
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
		public java.nio.ShortBuffer put(short[] src)
		{
			return put(src, 0, src.Length);
		}

		/// <summary>
		/// Writes shorts from the given short array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of shorts written.
		/// </summary>
		/// <remarks>
		/// Writes shorts from the given short array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of shorts written.
		/// </remarks>
		/// <param name="src">the source short array.</param>
		/// <param name="srcOffset">
		/// the offset of short array, must not be negative and not
		/// greater than
		/// <code>src.length</code>
		/// .
		/// </param>
		/// <param name="shortCount">
		/// the number of shorts to write, must be no less than zero and
		/// not greater than
		/// <code>src.length - srcOffset</code>
		/// .
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than
		/// <code>shortCount</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>srcOffset</code>
		/// or
		/// <code>shortCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.ShortBuffer put(short[] src, int srcOffset, int shortCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(src.Length, srcOffset, shortCount);
			if (shortCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			{
				for (int i = srcOffset; i < srcOffset + shortCount; ++i)
				{
					put(src[i]);
				}
			}
			return this;
		}

		/// <summary>
		/// Writes all the remaining shorts of the
		/// <code>src</code>
		/// short buffer to this
		/// buffer's current position, and increases both buffers' position by the
		/// number of shorts copied.
		/// </summary>
		/// <param name="src">the source short buffer.</param>
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
		public virtual java.nio.ShortBuffer put(java.nio.ShortBuffer src)
		{
			if (src == this)
			{
				throw new System.ArgumentException();
			}
			if (src.remaining() > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			short[] contents = new short[src.remaining()];
			src.get(contents);
			put(contents);
			return this;
		}

		/// <summary>
		/// Writes a short to the specified index of this buffer; the position is not
		/// changed.
		/// </summary>
		/// <remarks>
		/// Writes a short to the specified index of this buffer; the position is not
		/// changed.
		/// </remarks>
		/// <param name="index">the index, must not be negative and less than the limit.</param>
		/// <param name="s">the short to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ShortBuffer put(int index, short s);

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
		/// same as this buffer's.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a sliced buffer that shares its content with this buffer.</returns>
		public abstract java.nio.ShortBuffer slice();
	}
}
