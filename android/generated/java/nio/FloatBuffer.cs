using Sharpen;

namespace java.nio
{
	/// <summary>A buffer of floats.</summary>
	/// <remarks>
	/// A buffer of floats.
	/// <p>
	/// A float buffer can be created in either of the following ways:
	/// <ul>
	/// <li>
	/// <see cref="allocate(int)">Allocate</see>
	/// a new float array and create a buffer
	/// based on it;</li>
	/// <li>
	/// <see cref="wrap(float[])">Wrap</see>
	/// an existing float array to create a new
	/// buffer;</li>
	/// <li>Use
	/// <see cref="ByteBuffer.asFloatBuffer()">ByteBuffer.asFloatBuffer</see>
	/// to create a float buffer based on a byte buffer.</li>
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class FloatBuffer : java.nio.Buffer, java.lang.Comparable<java.nio.FloatBuffer
		>
	{
		/// <summary>Creates a float buffer based on a newly allocated float array.</summary>
		/// <remarks>Creates a float buffer based on a newly allocated float array.</remarks>
		/// <param name="capacity">the capacity of the new buffer.</param>
		/// <returns>the created float buffer.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity</code>
		/// is less than zero.
		/// </exception>
		public static java.nio.FloatBuffer allocate(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			return new java.nio.ReadWriteFloatArrayBuffer(capacity_1);
		}

		/// <summary>Creates a new float buffer by wrapping the given float array.</summary>
		/// <remarks>
		/// Creates a new float buffer by wrapping the given float array.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>wrap(array, 0, array.length)</code>
		/// .
		/// </remarks>
		/// <param name="array">the float array which the new buffer will be based on.</param>
		/// <returns>the created float buffer.</returns>
		public static java.nio.FloatBuffer wrap(float[] array_1)
		{
			return wrap(array_1, 0, array_1.Length);
		}

		/// <summary>Creates a new float buffer by wrapping the given float array.</summary>
		/// <remarks>
		/// Creates a new float buffer by wrapping the given float array.
		/// <p>
		/// The new buffer's position will be
		/// <code>start</code>
		/// , limit will be
		/// <code>start + floatCount</code>
		/// , capacity will be the length of the array.
		/// </remarks>
		/// <param name="array">the float array which the new buffer will be based on.</param>
		/// <param name="start">
		/// the start index, must not be negative and not greater than
		/// <code>array.length</code>
		/// .
		/// </param>
		/// <param name="floatCount">
		/// the length, must not be negative and not greater than
		/// <code>array.length - start</code>
		/// .
		/// </param>
		/// <returns>the created float buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>floatCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// NullPointerException
		/// if
		/// <code>array</code>
		/// is null.
		/// </exception>
		public static java.nio.FloatBuffer wrap(float[] array_1, int start, int floatCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(array_1.Length, start, floatCount);
			java.nio.FloatBuffer buf = new java.nio.ReadWriteFloatArrayBuffer(array_1);
			buf._position = start;
			buf._limit = start + floatCount;
			return buf;
		}

		internal FloatBuffer(int capacity_1) : base(2, capacity_1, null)
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
		/// and mark are the same as this buffer.
		/// <p>
		/// The new buffer shares its content with this buffer, which means this
		/// buffer's change of content will be visible to the new buffer. The two
		/// buffer's position, limit and mark are independent.
		/// </remarks>
		/// <returns>a read-only version of this buffer.</returns>
		public abstract java.nio.FloatBuffer asReadOnlyBuffer();

		/// <summary>Compacts this float buffer.</summary>
		/// <remarks>
		/// Compacts this float buffer.
		/// <p>
		/// The remaining floats will be moved to the head of the buffer, starting
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
		public abstract java.nio.FloatBuffer compact();

		/// <summary>
		/// Compare the remaining floats of this buffer to another float buffer's
		/// remaining floats.
		/// </summary>
		/// <remarks>
		/// Compare the remaining floats of this buffer to another float buffer's
		/// remaining floats.
		/// </remarks>
		/// <param name="otherBuffer">another float buffer.</param>
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
		/// is not a float buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(java.nio.FloatBuffer otherBuffer)
		{
			int compareRemaining = (remaining() < otherBuffer.remaining()) ? remaining() : otherBuffer
				.remaining();
			int thisPos = _position;
			int otherPos = otherBuffer._position;
			float thisFloat;
			float otherFloat;
			while (compareRemaining > 0)
			{
				thisFloat = get(thisPos);
				otherFloat = otherBuffer.get(otherPos);
				// checks for float and NaN inequality
				if ((thisFloat != otherFloat) && ((thisFloat == thisFloat) || (otherFloat == otherFloat
					)))
				{
					return thisFloat < otherFloat ? -1 : 1;
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
		/// are same as this buffer too.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a duplicated buffer that shares its content with this buffer.</returns>
		public abstract java.nio.FloatBuffer duplicate();

		/// <summary>Checks whether this float buffer is equal to another object.</summary>
		/// <remarks>
		/// Checks whether this float buffer is equal to another object. If
		/// <code>other</code>
		/// is not a
		/// <code>FloatBuffer</code>
		/// then
		/// <code>false</code>
		/// is returned.
		/// <p>Two float buffers are equal if their remaining floats are equal.
		/// Position, limit, capacity and mark are not considered.
		/// <p>This method considers two floats
		/// <code>a</code>
		/// and
		/// <code>b</code>
		/// to be equal
		/// if
		/// <code>a == b</code>
		/// or if
		/// <code>a</code>
		/// and
		/// <code>b</code>
		/// are both
		/// <code>NaN</code>
		/// .
		/// Unlike
		/// <see cref="float.Equals(object)">float.Equals(object)</see>
		/// , this method considers
		/// <code>-0.0</code>
		/// and
		/// <code>+0.0</code>
		/// to be equal.
		/// </remarks>
		/// <param name="other">the object to compare with this float buffer.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this float buffer is equal to
		/// <code>other</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			if (!(other is java.nio.FloatBuffer))
			{
				return false;
			}
			java.nio.FloatBuffer otherBuffer = (java.nio.FloatBuffer)other;
			if (remaining() != otherBuffer.remaining())
			{
				return false;
			}
			int myPosition = _position;
			int otherPosition = otherBuffer._position;
			bool equalSoFar = true;
			while (equalSoFar && (myPosition < _limit))
			{
				float a = get(myPosition++);
				float b = otherBuffer.get(otherPosition++);
				equalSoFar = a == b || (a != a && b != b);
			}
			return equalSoFar;
		}

		/// <summary>
		/// Returns the float at the current position and increases the position by
		/// 1.
		/// </summary>
		/// <remarks>
		/// Returns the float at the current position and increases the position by
		/// 1.
		/// </remarks>
		/// <returns>the float at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is equal or greater than limit.
		/// </exception>
		public abstract float get();

		/// <summary>
		/// Reads floats from the current position into the specified float array and
		/// increases the position by the number of floats read.
		/// </summary>
		/// <remarks>
		/// Reads floats from the current position into the specified float array and
		/// increases the position by the number of floats read.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>get(dst, 0, dst.length)</code>
		/// .
		/// </remarks>
		/// <param name="dst">the destination float array.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>dst.length</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.FloatBuffer get(float[] dst)
		{
			return get(dst, 0, dst.Length);
		}

		/// <summary>
		/// Reads floats from the current position into the specified float array,
		/// starting from the specified offset, and increases the position by the
		/// number of floats read.
		/// </summary>
		/// <remarks>
		/// Reads floats from the current position into the specified float array,
		/// starting from the specified offset, and increases the position by the
		/// number of floats read.
		/// </remarks>
		/// <param name="dst">the target float array.</param>
		/// <param name="dstOffset">
		/// the offset of the float array, must not be negative and no
		/// greater than
		/// <code>dst.length</code>
		/// .
		/// </param>
		/// <param name="floatCount">
		/// the number of floats to read, must be no less than zero and no
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
		/// <code>floatCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>floatCount</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.FloatBuffer get(float[] dst, int dstOffset, int floatCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(dst.Length, dstOffset, floatCount);
			if (floatCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			{
				for (int i = dstOffset; i < dstOffset + floatCount; ++i)
				{
					dst[i] = get();
				}
			}
			return this;
		}

		/// <summary>Returns a float at the specified index; the position is not changed.</summary>
		/// <remarks>Returns a float at the specified index; the position is not changed.</remarks>
		/// <param name="index">the index, must not be negative and less than limit.</param>
		/// <returns>a float at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		public abstract float get(int index);

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
		/// <returns>the hash code calculated from the remaining floats.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int myPosition = _position;
			int hash = 0;
			while (myPosition < _limit)
			{
				hash = hash + Sharpen.Util.FloatToIntBits(get(myPosition++));
			}
			return hash;
		}

		/// <summary>Indicates whether this buffer is direct.</summary>
		/// <remarks>
		/// Indicates whether this buffer is direct. A direct buffer will try its
		/// best to take advantage of native memory APIs and it may not stay in the
		/// Java heap, so it is not affected by garbage collection.
		/// <p>
		/// A float buffer is direct if it is based on a byte buffer and the byte
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
		/// Returns the byte order used by this buffer when converting floats from/to
		/// bytes.
		/// </summary>
		/// <remarks>
		/// Returns the byte order used by this buffer when converting floats from/to
		/// bytes.
		/// <p>
		/// If this buffer is not based on a byte buffer, then always return the
		/// platform's native byte order.
		/// </remarks>
		/// <returns>
		/// the byte order used by this buffer when converting floats from/to
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
		internal abstract float[] protectedArray();

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
		/// Writes the given float to the current position and increases the position
		/// by 1.
		/// </summary>
		/// <remarks>
		/// Writes the given float to the current position and increases the position
		/// by 1.
		/// </remarks>
		/// <param name="f">the float to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is equal or greater than limit.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.FloatBuffer put(float f);

		/// <summary>
		/// Writes floats from the given float array to the current position and
		/// increases the position by the number of floats written.
		/// </summary>
		/// <remarks>
		/// Writes floats from the given float array to the current position and
		/// increases the position by the number of floats written.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>put(src, 0, src.length)</code>
		/// .
		/// </remarks>
		/// <param name="src">the source float array.</param>
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
		public java.nio.FloatBuffer put(float[] src)
		{
			return put(src, 0, src.Length);
		}

		/// <summary>
		/// Writes floats from the given float array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of floats written.
		/// </summary>
		/// <remarks>
		/// Writes floats from the given float array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of floats written.
		/// </remarks>
		/// <param name="src">the source float array.</param>
		/// <param name="srcOffset">
		/// the offset of float array, must not be negative and not
		/// greater than
		/// <code>src.length</code>
		/// .
		/// </param>
		/// <param name="floatCount">
		/// the number of floats to write, must be no less than zero and
		/// no greater than
		/// <code>src.length - srcOffset</code>
		/// .
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than
		/// <code>floatCount</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>srcOffset</code>
		/// or
		/// <code>floatCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.FloatBuffer put(float[] src, int srcOffset, int floatCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(src.Length, srcOffset, floatCount);
			if (floatCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			{
				for (int i = srcOffset; i < srcOffset + floatCount; ++i)
				{
					put(src[i]);
				}
			}
			return this;
		}

		/// <summary>
		/// Writes all the remaining floats of the
		/// <code>src</code>
		/// float buffer to this
		/// buffer's current position, and increases both buffers' position by the
		/// number of floats copied.
		/// </summary>
		/// <param name="src">the source float buffer.</param>
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
		public virtual java.nio.FloatBuffer put(java.nio.FloatBuffer src)
		{
			if (src == this)
			{
				throw new System.ArgumentException();
			}
			if (src.remaining() > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			float[] contents = new float[src.remaining()];
			src.get(contents);
			put(contents);
			return this;
		}

		/// <summary>
		/// Writes a float to the specified index of this buffer; the position is not
		/// changed.
		/// </summary>
		/// <remarks>
		/// Writes a float to the specified index of this buffer; the position is not
		/// changed.
		/// </remarks>
		/// <param name="index">the index, must not be negative and less than the limit.</param>
		/// <param name="f">the float to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.FloatBuffer put(int index, float f);

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
		public abstract java.nio.FloatBuffer slice();
	}
}
