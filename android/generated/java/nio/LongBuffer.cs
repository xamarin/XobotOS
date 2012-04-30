using Sharpen;

namespace java.nio
{
	/// <summary>A buffer of longs.</summary>
	/// <remarks>
	/// A buffer of longs.
	/// <p>
	/// A long buffer can be created in either of the following ways:
	/// <ul>
	/// <li>
	/// <see cref="allocate(int)">Allocate</see>
	/// a new long array and create a buffer
	/// based on it;</li>
	/// <li>
	/// <see cref="wrap(long[])">Wrap</see>
	/// an existing long array to create a new
	/// buffer;</li>
	/// <li>Use
	/// <see cref="ByteBuffer.asLongBuffer()">ByteBuffer.asLongBuffer</see>
	/// to create a long buffer based on a byte buffer.</li>
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class LongBuffer : java.nio.Buffer, java.lang.Comparable<java.nio.LongBuffer
		>
	{
		/// <summary>Creates a long buffer based on a newly allocated long array.</summary>
		/// <remarks>Creates a long buffer based on a newly allocated long array.</remarks>
		/// <param name="capacity">the capacity of the new buffer.</param>
		/// <returns>the created long buffer.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity</code>
		/// is less than zero.
		/// </exception>
		public static java.nio.LongBuffer allocate(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			return new java.nio.ReadWriteLongArrayBuffer(capacity_1);
		}

		/// <summary>Creates a new long buffer by wrapping the given long array.</summary>
		/// <remarks>
		/// Creates a new long buffer by wrapping the given long array.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>wrap(array, 0, array.length)</code>
		/// .
		/// </remarks>
		/// <param name="array">the long array which the new buffer will be based on.</param>
		/// <returns>the created long buffer.</returns>
		public static java.nio.LongBuffer wrap(long[] array_1)
		{
			return wrap(array_1, 0, array_1.Length);
		}

		/// <summary>Creates a new long buffer by wrapping the given long array.</summary>
		/// <remarks>
		/// Creates a new long buffer by wrapping the given long array.
		/// <p>
		/// The new buffer's position will be
		/// <code>start</code>
		/// , limit will be
		/// <code>start + longCount</code>
		/// , capacity will be the length of the array.
		/// </remarks>
		/// <param name="array">the long array which the new buffer will be based on.</param>
		/// <param name="start">
		/// the start index, must not be negative and not greater than
		/// <code>array.length</code>
		/// .
		/// </param>
		/// <param name="longCount">
		/// the length, must not be negative and not greater than
		/// <code>array.length - start</code>
		/// .
		/// </param>
		/// <returns>the created long buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>longCount</code>
		/// is invalid.
		/// </exception>
		public static java.nio.LongBuffer wrap(long[] array_1, int start, int longCount)
		{
			java.util.Arrays.checkOffsetAndCount(array_1.Length, start, longCount);
			java.nio.LongBuffer buf = new java.nio.ReadWriteLongArrayBuffer(array_1);
			buf._position = start;
			buf._limit = start + longCount;
			return buf;
		}

		internal LongBuffer(int capacity_1) : base(3, capacity_1, null)
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
		public abstract java.nio.LongBuffer asReadOnlyBuffer();

		/// <summary>Compacts this long buffer.</summary>
		/// <remarks>
		/// Compacts this long buffer.
		/// <p>
		/// The remaining longs will be moved to the head of the buffer, staring from
		/// position zero. Then the position is set to
		/// <code>remaining()</code>
		/// ; the
		/// limit is set to capacity; the mark is cleared.
		/// </remarks>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.LongBuffer compact();

		/// <summary>
		/// Compare the remaining longs of this buffer to another long buffer's
		/// remaining longs.
		/// </summary>
		/// <remarks>
		/// Compare the remaining longs of this buffer to another long buffer's
		/// remaining longs.
		/// </remarks>
		/// <param name="otherBuffer">another long buffer.</param>
		/// <returns>
		/// a negative value if this is less than
		/// <code>otherBuffer</code>
		/// ; 0 if
		/// this equals to
		/// <code>otherBuffer</code>
		/// ; a positive value if this is
		/// greater than
		/// <code>otherBuffer</code>
		/// </returns>
		/// <exception>
		/// ClassCastException
		/// if
		/// <code>otherBuffer</code>
		/// is not a long buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(java.nio.LongBuffer otherBuffer)
		{
			int compareRemaining = (remaining() < otherBuffer.remaining()) ? remaining() : otherBuffer
				.remaining();
			int thisPos = _position;
			int otherPos = otherBuffer._position;
			long thisLong;
			long otherLong;
			while (compareRemaining > 0)
			{
				thisLong = get(thisPos);
				otherLong = otherBuffer.get(otherPos);
				if (thisLong != otherLong)
				{
					return thisLong < otherLong ? -1 : 1;
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
		/// are same as this buffer's, too.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a duplicated buffer that shares its content with this buffer.</returns>
		public abstract java.nio.LongBuffer duplicate();

		/// <summary>Checks whether this long buffer is equal to another object.</summary>
		/// <remarks>
		/// Checks whether this long buffer is equal to another object.
		/// <p>
		/// If
		/// <code>other</code>
		/// is not a long buffer then
		/// <code>false</code>
		/// is returned. Two
		/// long buffers are equal if and only if their remaining longs are exactly
		/// the same. Position, limit, capacity and mark are not considered.
		/// </remarks>
		/// <param name="other">the object to compare with this long buffer.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this long buffer is equal to
		/// <code>other</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			if (!(other is java.nio.LongBuffer))
			{
				return false;
			}
			java.nio.LongBuffer otherBuffer = (java.nio.LongBuffer)other;
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

		/// <summary>Returns the long at the current position and increase the position by 1.
		/// 	</summary>
		/// <remarks>Returns the long at the current position and increase the position by 1.
		/// 	</remarks>
		/// <returns>the long at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is equal or greater than limit.
		/// </exception>
		public abstract long get();

		/// <summary>
		/// Reads longs from the current position into the specified long array and
		/// increases the position by the number of longs read.
		/// </summary>
		/// <remarks>
		/// Reads longs from the current position into the specified long array and
		/// increases the position by the number of longs read.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>get(dst, 0, dst.length)</code>
		/// .
		/// </remarks>
		/// <param name="dst">the destination long array.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>dst.length</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.LongBuffer get(long[] dst)
		{
			return get(dst, 0, dst.Length);
		}

		/// <summary>
		/// Reads longs from the current position into the specified long array,
		/// starting from the specified offset, and increase the position by the
		/// number of longs read.
		/// </summary>
		/// <remarks>
		/// Reads longs from the current position into the specified long array,
		/// starting from the specified offset, and increase the position by the
		/// number of longs read.
		/// </remarks>
		/// <param name="dst">the target long array.</param>
		/// <param name="dstOffset">
		/// the offset of the long array, must not be negative and not
		/// greater than
		/// <code>dst.length</code>
		/// .
		/// </param>
		/// <param name="longCount">
		/// the number of longs to read, must be no less than zero and not
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
		/// <code>longCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>longCount</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.LongBuffer get(long[] dst, int dstOffset, int longCount)
		{
			java.util.Arrays.checkOffsetAndCount(dst.Length, dstOffset, longCount);
			if (longCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			{
				for (int i = dstOffset; i < dstOffset + longCount; ++i)
				{
					dst[i] = get();
				}
			}
			return this;
		}

		/// <summary>Returns the long at the specified index; the position is not changed.</summary>
		/// <remarks>Returns the long at the specified index; the position is not changed.</remarks>
		/// <param name="index">the index, must not be negative and less than limit.</param>
		/// <returns>the long at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		public abstract long get(int index);

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
		/// <returns>the hash code calculated from the remaining longs.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int myPosition = _position;
			int hash = 0;
			long l;
			while (myPosition < _limit)
			{
				l = get(myPosition++);
				hash = hash + ((int)l) ^ ((int)(l >> 32));
			}
			return hash;
		}

		/// <summary>Indicates whether this buffer is direct.</summary>
		/// <remarks>
		/// Indicates whether this buffer is direct. A direct buffer will try its
		/// best to take advantage of native memory APIs and it may not stay in the
		/// Java heap, so it is not affected by garbage collection.
		/// <p>
		/// A long buffer is direct if it is based on a byte buffer and the byte
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
		/// Returns the byte order used by this buffer when converting longs from/to
		/// bytes.
		/// </summary>
		/// <remarks>
		/// Returns the byte order used by this buffer when converting longs from/to
		/// bytes.
		/// <p>
		/// If this buffer is not based on a byte buffer, then always return the
		/// platform's native byte order.
		/// </remarks>
		/// <returns>
		/// the byte order used by this buffer when converting longs from/to
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
		internal abstract long[] protectedArray();

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
		/// Writes the given long to the current position and increases the position
		/// by 1.
		/// </summary>
		/// <remarks>
		/// Writes the given long to the current position and increases the position
		/// by 1.
		/// </remarks>
		/// <param name="l">the long to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is equal or greater than limit.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.LongBuffer put(long l);

		/// <summary>
		/// Writes longs from the given long array to the current position and
		/// increases the position by the number of longs written.
		/// </summary>
		/// <remarks>
		/// Writes longs from the given long array to the current position and
		/// increases the position by the number of longs written.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>put(src, 0, src.length)</code>
		/// .
		/// </remarks>
		/// <param name="src">the source long array.</param>
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
		public java.nio.LongBuffer put(long[] src)
		{
			return put(src, 0, src.Length);
		}

		/// <summary>
		/// Writes longs from the given long array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of longs written.
		/// </summary>
		/// <remarks>
		/// Writes longs from the given long array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of longs written.
		/// </remarks>
		/// <param name="src">the source long array.</param>
		/// <param name="srcOffset">
		/// the offset of long array, must not be negative and not greater
		/// than
		/// <code>src.length</code>
		/// .
		/// </param>
		/// <param name="longCount">
		/// the number of longs to write, must be no less than zero and
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
		/// <code>longCount</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>srcOffset</code>
		/// or
		/// <code>longCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.LongBuffer put(long[] src, int srcOffset, int longCount)
		{
			java.util.Arrays.checkOffsetAndCount(src.Length, srcOffset, longCount);
			if (longCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			{
				for (int i = srcOffset; i < srcOffset + longCount; ++i)
				{
					put(src[i]);
				}
			}
			return this;
		}

		/// <summary>
		/// Writes all the remaining longs of the
		/// <code>src</code>
		/// long buffer to this
		/// buffer's current position, and increases both buffers' position by the
		/// number of longs copied.
		/// </summary>
		/// <param name="src">the source long buffer.</param>
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
		public virtual java.nio.LongBuffer put(java.nio.LongBuffer src)
		{
			if (src == this)
			{
				throw new System.ArgumentException();
			}
			if (src.remaining() > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			long[] contents = new long[src.remaining()];
			src.get(contents);
			put(contents);
			return this;
		}

		/// <summary>
		/// Writes a long to the specified index of this buffer; the position is not
		/// changed.
		/// </summary>
		/// <remarks>
		/// Writes a long to the specified index of this buffer; the position is not
		/// changed.
		/// </remarks>
		/// <param name="index">the index, must not be negative and less than the limit.</param>
		/// <param name="l">the long to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.LongBuffer put(int index, long l);

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
		public abstract java.nio.LongBuffer slice();
	}
}
