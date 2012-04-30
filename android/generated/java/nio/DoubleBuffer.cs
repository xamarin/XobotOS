using Sharpen;

namespace java.nio
{
	/// <summary>A buffer of doubles.</summary>
	/// <remarks>
	/// A buffer of doubles.
	/// <p>
	/// A double buffer can be created in either one of the following ways:
	/// <ul>
	/// <li>
	/// <see cref="allocate(int)">Allocate</see>
	/// a new double array and create a buffer
	/// based on it;</li>
	/// <li>
	/// <see cref="wrap(double[])">Wrap</see>
	/// an existing double array to create a new
	/// buffer;</li>
	/// <li>Use
	/// <see cref="ByteBuffer.asDoubleBuffer()">ByteBuffer.asDoubleBuffer</see>
	/// to
	/// create a double buffer based on a byte buffer.</li>
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class DoubleBuffer : java.nio.Buffer, java.lang.Comparable<java.nio.DoubleBuffer
		>
	{
		/// <summary>Creates a double buffer based on a newly allocated double array.</summary>
		/// <remarks>Creates a double buffer based on a newly allocated double array.</remarks>
		/// <param name="capacity">the capacity of the new buffer.</param>
		/// <returns>the created double buffer.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity</code>
		/// is less than zero.
		/// </exception>
		public static java.nio.DoubleBuffer allocate(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			return new java.nio.ReadWriteDoubleArrayBuffer(capacity_1);
		}

		/// <summary>Creates a new double buffer by wrapping the given double array.</summary>
		/// <remarks>
		/// Creates a new double buffer by wrapping the given double array.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>wrap(array, 0, array.length)</code>
		/// .
		/// </remarks>
		/// <param name="array">the double array which the new buffer will be based on.</param>
		/// <returns>the created double buffer.</returns>
		public static java.nio.DoubleBuffer wrap(double[] array_1)
		{
			return wrap(array_1, 0, array_1.Length);
		}

		/// <summary>Creates a new double buffer by wrapping the given double array.</summary>
		/// <remarks>
		/// Creates a new double buffer by wrapping the given double array.
		/// <p>
		/// The new buffer's position will be
		/// <code>start</code>
		/// , limit will be
		/// <code>start + doubleCount</code>
		/// , capacity will be the length of the array.
		/// </remarks>
		/// <param name="array">the double array which the new buffer will be based on.</param>
		/// <param name="start">
		/// the start index, must not be negative and not greater than
		/// <code>array.length</code>
		/// .
		/// </param>
		/// <param name="doubleCount">
		/// the length, must not be negative and not greater than
		/// <code>array.length - start</code>
		/// .
		/// </param>
		/// <returns>the created double buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>doubleCount</code>
		/// is invalid.
		/// </exception>
		public static java.nio.DoubleBuffer wrap(double[] array_1, int start, int doubleCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(array_1.Length, start, doubleCount);
			java.nio.DoubleBuffer buf = new java.nio.ReadWriteDoubleArrayBuffer(array_1);
			buf._position = start;
			buf._limit = start + doubleCount;
			return buf;
		}

		internal DoubleBuffer(int capacity_1) : base(3, capacity_1, null)
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
		/// The new buffer shares its content with this buffer, which means that this
		/// buffer's change of content will be visible to the new buffer. The two
		/// buffer's position, limit and mark are independent.
		/// </remarks>
		/// <returns>a read-only version of this buffer.</returns>
		public abstract java.nio.DoubleBuffer asReadOnlyBuffer();

		/// <summary>Compacts this double buffer.</summary>
		/// <remarks>
		/// Compacts this double buffer.
		/// <p>
		/// The remaining doubles will be moved to the head of the buffer, staring
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
		public abstract java.nio.DoubleBuffer compact();

		/// <summary>
		/// Compare the remaining doubles of this buffer to another double buffer's
		/// remaining doubles.
		/// </summary>
		/// <remarks>
		/// Compare the remaining doubles of this buffer to another double buffer's
		/// remaining doubles.
		/// </remarks>
		/// <param name="otherBuffer">another double buffer.</param>
		/// <returns>
		/// a negative value if this is less than
		/// <code>other</code>
		/// ; 0 if this
		/// equals to
		/// <code>other</code>
		/// ; a positive value if this is greater
		/// than
		/// <code>other</code>
		/// .
		/// </returns>
		/// <exception>
		/// ClassCastException
		/// if
		/// <code>other</code>
		/// is not a double buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(java.nio.DoubleBuffer otherBuffer)
		{
			int compareRemaining = (remaining() < otherBuffer.remaining()) ? remaining() : otherBuffer
				.remaining();
			int thisPos = _position;
			int otherPos = otherBuffer._position;
			double thisDouble;
			double otherDouble;
			while (compareRemaining > 0)
			{
				thisDouble = get(thisPos);
				otherDouble = otherBuffer.get(otherPos);
				// checks for double and NaN inequality
				if ((thisDouble != otherDouble) && ((thisDouble == thisDouble) || (otherDouble ==
					 otherDouble)))
				{
					return thisDouble < otherDouble ? -1 : 1;
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
		/// as this buffer's. The duplicated buffer's read-only property and byte
		/// order are the same as this buffer's, too.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a duplicated buffer that shares its content with this buffer.</returns>
		public abstract java.nio.DoubleBuffer duplicate();

		/// <summary>Checks whether this double buffer is equal to another object.</summary>
		/// <remarks>
		/// Checks whether this double buffer is equal to another object. If
		/// <code>other</code>
		/// is not a
		/// <code>DoubleBuffer</code>
		/// then
		/// <code>false</code>
		/// is returned.
		/// <p>Two double buffers are equal if their remaining doubles are equal.
		/// Position, limit, capacity and mark are not considered.
		/// <p>This method considers two doubles
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
		/// <see cref="double.Equals(object)">double.Equals(object)</see>
		/// , this method considers
		/// <code>-0.0</code>
		/// and
		/// <code>+0.0</code>
		/// to be equal.
		/// </remarks>
		/// <param name="other">the object to compare with this double buffer.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this double buffer is equal to
		/// <code>other</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			if (!(other is java.nio.DoubleBuffer))
			{
				return false;
			}
			java.nio.DoubleBuffer otherBuffer = (java.nio.DoubleBuffer)other;
			if (remaining() != otherBuffer.remaining())
			{
				return false;
			}
			int myPosition = _position;
			int otherPosition = otherBuffer._position;
			bool equalSoFar = true;
			while (equalSoFar && (myPosition < _limit))
			{
				double a = get(myPosition++);
				double b = otherBuffer.get(otherPosition++);
				equalSoFar = a == b || (a != a && b != b);
			}
			return equalSoFar;
		}

		/// <summary>
		/// Returns the double at the current position and increases the position by
		/// 1.
		/// </summary>
		/// <remarks>
		/// Returns the double at the current position and increases the position by
		/// 1.
		/// </remarks>
		/// <returns>the double at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is equal or greater than limit.
		/// </exception>
		public abstract double get();

		/// <summary>
		/// Reads doubles from the current position into the specified double array
		/// and increases the position by the number of doubles read.
		/// </summary>
		/// <remarks>
		/// Reads doubles from the current position into the specified double array
		/// and increases the position by the number of doubles read.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>get(dst, 0, dst.length)</code>
		/// .
		/// </remarks>
		/// <param name="dst">the destination double array.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>dst.length</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.DoubleBuffer get(double[] dst)
		{
			return get(dst, 0, dst.Length);
		}

		/// <summary>
		/// Reads doubles from the current position into the specified double array,
		/// starting from the specified offset, and increases the position by the
		/// number of doubles read.
		/// </summary>
		/// <remarks>
		/// Reads doubles from the current position into the specified double array,
		/// starting from the specified offset, and increases the position by the
		/// number of doubles read.
		/// </remarks>
		/// <param name="dst">the target double array.</param>
		/// <param name="dstOffset">
		/// the offset of the double array, must not be negative and not
		/// greater than
		/// <code>dst.length</code>
		/// .
		/// </param>
		/// <param name="doubleCount">
		/// the number of doubles to read, must be no less than zero and
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
		/// <code>doubleCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>doubleCount</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.DoubleBuffer get(double[] dst, int dstOffset, int doubleCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(dst.Length, dstOffset, doubleCount);
			if (doubleCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			{
				for (int i = dstOffset; i < dstOffset + doubleCount; ++i)
				{
					dst[i] = get();
				}
			}
			return this;
		}

		/// <summary>Returns a double at the specified index; the position is not changed.</summary>
		/// <remarks>Returns a double at the specified index; the position is not changed.</remarks>
		/// <param name="index">the index, must not be negative and less than limit.</param>
		/// <returns>a double at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		public abstract double get(int index);

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
			long l;
			while (myPosition < _limit)
			{
				l = Sharpen.Util.DoubleToLongBits(get(myPosition++));
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
		/// A double buffer is direct if it is based on a byte buffer and the byte
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
		/// Returns the byte order used by this buffer when converting doubles
		/// from/to bytes.
		/// </summary>
		/// <remarks>
		/// Returns the byte order used by this buffer when converting doubles
		/// from/to bytes.
		/// <p>
		/// If this buffer is not based on a byte buffer, then this always returns
		/// the platform's native byte order.
		/// </remarks>
		/// <returns>
		/// the byte order used by this buffer when converting doubles
		/// from/to bytes.
		/// </returns>
		public abstract java.nio.ByteOrder order();

		/// <summary>
		/// Child class implements this method to realize
		/// <code>array()</code>
		/// .
		/// </summary>
		/// <seealso cref="array()">array()</seealso>
		internal abstract double[] protectedArray();

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
		/// Writes the given double to the current position and increases the
		/// position by 1.
		/// </summary>
		/// <remarks>
		/// Writes the given double to the current position and increases the
		/// position by 1.
		/// </remarks>
		/// <param name="d">the double to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is equal or greater than limit.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.DoubleBuffer put(double d);

		/// <summary>
		/// Writes doubles from the given double array to the current position and
		/// increases the position by the number of doubles written.
		/// </summary>
		/// <remarks>
		/// Writes doubles from the given double array to the current position and
		/// increases the position by the number of doubles written.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>put(src, 0, src.length)</code>
		/// .
		/// </remarks>
		/// <param name="src">the source double array.</param>
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
		public java.nio.DoubleBuffer put(double[] src)
		{
			return put(src, 0, src.Length);
		}

		/// <summary>
		/// Writes doubles from the given double array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of doubles written.
		/// </summary>
		/// <remarks>
		/// Writes doubles from the given double array, starting from the specified
		/// offset, to the current position and increases the position by the number
		/// of doubles written.
		/// </remarks>
		/// <param name="src">the source double array.</param>
		/// <param name="srcOffset">
		/// the offset of double array, must not be negative and not
		/// greater than
		/// <code>src.length</code>
		/// .
		/// </param>
		/// <param name="doubleCount">
		/// the number of doubles to write, must be no less than zero and
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
		/// <code>doubleCount</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>srcOffset</code>
		/// or
		/// <code>doubleCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.DoubleBuffer put(double[] src, int srcOffset, int doubleCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(src.Length, srcOffset, doubleCount);
			if (doubleCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			{
				for (int i = srcOffset; i < srcOffset + doubleCount; ++i)
				{
					put(src[i]);
				}
			}
			return this;
		}

		/// <summary>
		/// Writes all the remaining doubles of the
		/// <code>src</code>
		/// double buffer to this
		/// buffer's current position, and increases both buffers' position by the
		/// number of doubles copied.
		/// </summary>
		/// <param name="src">the source double buffer.</param>
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
		public virtual java.nio.DoubleBuffer put(java.nio.DoubleBuffer src)
		{
			if (src == this)
			{
				throw new System.ArgumentException();
			}
			if (src.remaining() > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			double[] doubles = new double[src.remaining()];
			src.get(doubles);
			put(doubles);
			return this;
		}

		/// <summary>
		/// Write a double to the specified index of this buffer and the position is
		/// not changed.
		/// </summary>
		/// <remarks>
		/// Write a double to the specified index of this buffer and the position is
		/// not changed.
		/// </remarks>
		/// <param name="index">the index, must not be negative and less than the limit.</param>
		/// <param name="d">the double to write.</param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.DoubleBuffer put(int index, double d);

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
		/// the same as this buffer's.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a sliced buffer that shares its content with this buffer.</returns>
		public abstract java.nio.DoubleBuffer slice();
	}
}
