using Sharpen;

namespace java.nio
{
	/// <summary>A buffer for bytes.</summary>
	/// <remarks>
	/// A buffer for bytes.
	/// <p>
	/// A byte buffer can be created in either one of the following ways:
	/// <ul>
	/// <li>
	/// <see cref="allocate(int)">Allocate</see>
	/// a new byte array and create a buffer
	/// based on it;</li>
	/// <li>
	/// <see cref="allocateDirect(int)">Allocate</see>
	/// a memory block and create a direct
	/// buffer based on it;</li>
	/// <li>
	/// <see cref="wrap(byte[])">Wrap</see>
	/// an existing byte array to create a new
	/// buffer.</li>
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract partial class ByteBuffer : java.nio.Buffer, java.lang.Comparable<
		java.nio.ByteBuffer>
	{
		/// <summary>Creates a byte buffer based on a newly allocated byte array.</summary>
		/// <remarks>Creates a byte buffer based on a newly allocated byte array.</remarks>
		/// <param name="capacity">the capacity of the new buffer</param>
		/// <returns>the created byte buffer.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity &lt; 0</code>
		/// .
		/// </exception>
		public static java.nio.ByteBuffer allocate(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			return new java.nio.ReadWriteHeapByteBuffer(capacity_1);
		}

		/// <summary>Creates a new byte buffer by wrapping the given byte array.</summary>
		/// <remarks>
		/// Creates a new byte buffer by wrapping the given byte array.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>wrap(array, 0, array.length)</code>
		/// .
		/// </remarks>
		/// <param name="array">the byte array which the new buffer will be based on</param>
		/// <returns>the created byte buffer.</returns>
		public static java.nio.ByteBuffer wrap(byte[] array_1)
		{
			return new java.nio.ReadWriteHeapByteBuffer(array_1);
		}

		/// <summary>Creates a new byte buffer by wrapping the given byte array.</summary>
		/// <remarks>
		/// Creates a new byte buffer by wrapping the given byte array.
		/// <p>
		/// The new buffer's position will be
		/// <code>start</code>
		/// , limit will be
		/// <code>start + byteCount</code>
		/// , capacity will be the length of the array.
		/// </remarks>
		/// <param name="array">the byte array which the new buffer will be based on.</param>
		/// <param name="start">
		/// the start index, must not be negative and not greater than
		/// <code>array.length</code>
		/// .
		/// </param>
		/// <param name="byteCount">
		/// the length, must not be negative and not greater than
		/// <code>array.length - start</code>
		/// .
		/// </param>
		/// <returns>the created byte buffer.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>start</code>
		/// or
		/// <code>byteCount</code>
		/// is invalid.
		/// </exception>
		public static java.nio.ByteBuffer wrap(byte[] array_1, int start, int byteCount)
		{
			java.util.Arrays.checkOffsetAndCount(array_1.Length, start, byteCount);
			java.nio.ByteBuffer buf = new java.nio.ReadWriteHeapByteBuffer(array_1);
			buf._position = start;
			buf._limit = start + byteCount;
			return buf;
		}

		/// <summary>
		/// The byte order of this buffer, default is
		/// <code>BIG_ENDIAN</code>
		/// .
		/// </summary>
		internal java.nio.ByteOrder _order = java.nio.ByteOrder.BIG_ENDIAN;

		internal ByteBuffer(int capacity_1, java.nio.MemoryBlock block) : base(0, capacity_1
			, block)
		{
		}

		/// <summary>Returns the byte array which this buffer is based on, if there is one.</summary>
		/// <remarks>Returns the byte array which this buffer is based on, if there is one.</remarks>
		/// <returns>the byte array which this buffer is based on.</returns>
		/// <exception>
		/// ReadOnlyBufferException
		/// if this buffer is based on a read-only array.
		/// </exception>
		/// <exception>
		/// UnsupportedOperationException
		/// if this buffer is not based on an array.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override object array()
		{
			return protectedArray();
		}

		/// <summary>
		/// Returns the offset of the byte array which this buffer is based on, if
		/// there is one.
		/// </summary>
		/// <remarks>
		/// Returns the offset of the byte array which this buffer is based on, if
		/// there is one.
		/// <p>
		/// The offset is the index of the array which corresponds to the zero
		/// position of the buffer.
		/// </remarks>
		/// <returns>the offset of the byte array which this buffer is based on.</returns>
		/// <exception>
		/// ReadOnlyBufferException
		/// if this buffer is based on a read-only array.
		/// </exception>
		/// <exception>
		/// UnsupportedOperationException
		/// if this buffer is not based on an array.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override int arrayOffset()
		{
			return protectedArrayOffset();
		}

		/// <summary>
		/// Returns a char buffer which is based on the remaining content of this
		/// byte buffer.
		/// </summary>
		/// <remarks>
		/// Returns a char buffer which is based on the remaining content of this
		/// byte buffer.
		/// <p>
		/// The new buffer's position is zero, its limit and capacity is the number
		/// of remaining bytes divided by two, and its mark is not set. The new
		/// buffer's read-only property and byte order are the same as this buffer's.
		/// The new buffer is direct if this byte buffer is direct.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a char buffer which is based on the content of this byte buffer.</returns>
		public abstract java.nio.CharBuffer asCharBuffer();

		/// <summary>
		/// Returns a double buffer which is based on the remaining content of this
		/// byte buffer.
		/// </summary>
		/// <remarks>
		/// Returns a double buffer which is based on the remaining content of this
		/// byte buffer.
		/// <p>
		/// The new buffer's position is zero, its limit and capacity is the number
		/// of remaining bytes divided by eight, and its mark is not set. The new
		/// buffer's read-only property and byte order are the same as this buffer's.
		/// The new buffer is direct if this byte buffer is direct.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>
		/// a double buffer which is based on the content of this byte
		/// buffer.
		/// </returns>
		public abstract java.nio.DoubleBuffer asDoubleBuffer();

		/// <summary>
		/// Returns a float buffer which is based on the remaining content of this
		/// byte buffer.
		/// </summary>
		/// <remarks>
		/// Returns a float buffer which is based on the remaining content of this
		/// byte buffer.
		/// <p>
		/// The new buffer's position is zero, its limit and capacity is the number
		/// of remaining bytes divided by four, and its mark is not set. The new
		/// buffer's read-only property and byte order are the same as this buffer's.
		/// The new buffer is direct if this byte buffer is direct.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a float buffer which is based on the content of this byte buffer.</returns>
		public abstract java.nio.FloatBuffer asFloatBuffer();

		/// <summary>
		/// Returns a int buffer which is based on the remaining content of this byte
		/// buffer.
		/// </summary>
		/// <remarks>
		/// Returns a int buffer which is based on the remaining content of this byte
		/// buffer.
		/// <p>
		/// The new buffer's position is zero, its limit and capacity is the number
		/// of remaining bytes divided by four, and its mark is not set. The new
		/// buffer's read-only property and byte order are the same as this buffer's.
		/// The new buffer is direct if this byte buffer is direct.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a int buffer which is based on the content of this byte buffer.</returns>
		public abstract java.nio.IntBuffer asIntBuffer();

		/// <summary>
		/// Returns a long buffer which is based on the remaining content of this
		/// byte buffer.
		/// </summary>
		/// <remarks>
		/// Returns a long buffer which is based on the remaining content of this
		/// byte buffer.
		/// <p>
		/// The new buffer's position is zero, its limit and capacity is the number
		/// of remaining bytes divided by eight, and its mark is not set. The new
		/// buffer's read-only property and byte order are the same as this buffer's.
		/// The new buffer is direct if this byte buffer is direct.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a long buffer which is based on the content of this byte buffer.</returns>
		public abstract java.nio.LongBuffer asLongBuffer();

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
		public abstract java.nio.ByteBuffer asReadOnlyBuffer();

		/// <summary>
		/// Returns a short buffer which is based on the remaining content of this
		/// byte buffer.
		/// </summary>
		/// <remarks>
		/// Returns a short buffer which is based on the remaining content of this
		/// byte buffer.
		/// <p>
		/// The new buffer's position is zero, its limit and capacity is the number
		/// of remaining bytes divided by two, and its mark is not set. The new
		/// buffer's read-only property and byte order are the same as this buffer's.
		/// The new buffer is direct if this byte buffer is direct.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a short buffer which is based on the content of this byte buffer.</returns>
		public abstract java.nio.ShortBuffer asShortBuffer();

		/// <summary>Compacts this byte buffer.</summary>
		/// <remarks>
		/// Compacts this byte buffer.
		/// <p>
		/// The remaining bytes will be moved to the head of the
		/// buffer, starting from position zero. Then the position is set to
		/// <code>remaining()</code>
		/// ; the limit is set to capacity; the mark is
		/// cleared.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer compact();

		/// <summary>
		/// Compares the remaining bytes of this buffer to another byte buffer's
		/// remaining bytes.
		/// </summary>
		/// <remarks>
		/// Compares the remaining bytes of this buffer to another byte buffer's
		/// remaining bytes.
		/// </remarks>
		/// <param name="otherBuffer">another byte buffer.</param>
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
		/// is not a byte buffer.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(java.nio.ByteBuffer otherBuffer)
		{
			int compareRemaining = (remaining() < otherBuffer.remaining()) ? remaining() : otherBuffer
				.remaining();
			int thisPos = _position;
			int otherPos = otherBuffer._position;
			byte thisByte;
			byte otherByte;
			while (compareRemaining > 0)
			{
				thisByte = get(thisPos);
				otherByte = otherBuffer.get(otherPos);
				if (thisByte != otherByte)
				{
					return ((sbyte)thisByte) < otherByte ? -1 : 1;
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
		/// order are the same as this buffer's too.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a duplicated buffer that shares its content with this buffer.</returns>
		public abstract java.nio.ByteBuffer duplicate();

		/// <summary>Checks whether this byte buffer is equal to another object.</summary>
		/// <remarks>
		/// Checks whether this byte buffer is equal to another object.
		/// <p>
		/// If
		/// <code>other</code>
		/// is not a byte buffer then
		/// <code>false</code>
		/// is returned. Two
		/// byte buffers are equal if and only if their remaining bytes are exactly
		/// the same. Position, limit, capacity and mark are not considered.
		/// </remarks>
		/// <param name="other">the object to compare with this byte buffer.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this byte buffer is equal to
		/// <code>other</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			if (!(other is java.nio.ByteBuffer))
			{
				return false;
			}
			java.nio.ByteBuffer otherBuffer = (java.nio.ByteBuffer)other;
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

		/// <summary>Returns the byte at the current position and increases the position by 1.
		/// 	</summary>
		/// <remarks>Returns the byte at the current position and increases the position by 1.
		/// 	</remarks>
		/// <returns>the byte at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is equal or greater than limit.
		/// </exception>
		public abstract byte get();

		/// <summary>
		/// Reads bytes from the current position into the specified byte array and
		/// increases the position by the number of bytes read.
		/// </summary>
		/// <remarks>
		/// Reads bytes from the current position into the specified byte array and
		/// increases the position by the number of bytes read.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>get(dst, 0, dst.length)</code>
		/// .
		/// </remarks>
		/// <param name="dst">the destination byte array.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>dst.length</code>
		/// is greater than
		/// <code>remaining()</code>
		/// .
		/// </exception>
		public virtual java.nio.ByteBuffer get(byte[] dst)
		{
			return get(dst, 0, dst.Length);
		}

		/// <summary>
		/// Reads bytes from the current position into the specified byte array,
		/// starting at the specified offset, and increases the position by the
		/// number of bytes read.
		/// </summary>
		/// <remarks>
		/// Reads bytes from the current position into the specified byte array,
		/// starting at the specified offset, and increases the position by the
		/// number of bytes read.
		/// </remarks>
		/// <param name="dst">the target byte array.</param>
		/// <param name="dstOffset">
		/// the offset of the byte array, must not be negative and
		/// not greater than
		/// <code>dst.length</code>
		/// .
		/// </param>
		/// <param name="byteCount">
		/// the number of bytes to read, must not be negative and not
		/// greater than
		/// <code>dst.length - dstOffset</code>
		/// </param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>dstOffset &lt; 0 ||  byteCount &lt; 0</code>
		/// </exception>
		/// <exception>
		/// BufferUnderflowException
		/// if
		/// <code>byteCount &gt; remaining()</code>
		/// </exception>
		public virtual java.nio.ByteBuffer get(byte[] dst, int dstOffset, int byteCount)
		{
			java.util.Arrays.checkOffsetAndCount(dst.Length, dstOffset, byteCount);
			if (byteCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			{
				for (int i = dstOffset; i < dstOffset + byteCount; ++i)
				{
					dst[i] = get();
				}
			}
			return this;
		}

		/// <summary>Returns the byte at the specified index and does not change the position.
		/// 	</summary>
		/// <remarks>Returns the byte at the specified index and does not change the position.
		/// 	</remarks>
		/// <param name="index">the index, must not be negative and less than limit.</param>
		/// <returns>the byte at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if index is invalid.
		/// </exception>
		public abstract byte get(int index);

		/// <summary>Returns the char at the current position and increases the position by 2.
		/// 	</summary>
		/// <remarks>
		/// Returns the char at the current position and increases the position by 2.
		/// <p>
		/// The 2 bytes starting at the current position are composed into a char
		/// according to the current byte order and returned.
		/// </remarks>
		/// <returns>the char at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is greater than
		/// <code>limit - 2</code>
		/// .
		/// </exception>
		public abstract char getChar();

		/// <summary>Returns the char at the specified index.</summary>
		/// <remarks>
		/// Returns the char at the specified index.
		/// <p>
		/// The 2 bytes starting from the specified index are composed into a char
		/// according to the current byte order and returned. The position is not
		/// changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 2</code>
		/// .
		/// </param>
		/// <returns>the char at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		public abstract char getChar(int index);

		/// <summary>
		/// Returns the double at the current position and increases the position by
		/// 8.
		/// </summary>
		/// <remarks>
		/// Returns the double at the current position and increases the position by
		/// 8.
		/// <p>
		/// The 8 bytes starting from the current position are composed into a double
		/// according to the current byte order and returned.
		/// </remarks>
		/// <returns>the double at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is greater than
		/// <code>limit - 8</code>
		/// .
		/// </exception>
		public abstract double getDouble();

		/// <summary>Returns the double at the specified index.</summary>
		/// <remarks>
		/// Returns the double at the specified index.
		/// <p>
		/// The 8 bytes starting at the specified index are composed into a double
		/// according to the current byte order and returned. The position is not
		/// changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 8</code>
		/// .
		/// </param>
		/// <returns>the double at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		public abstract double getDouble(int index);

		/// <summary>
		/// Returns the float at the current position and increases the position by
		/// 4.
		/// </summary>
		/// <remarks>
		/// Returns the float at the current position and increases the position by
		/// 4.
		/// <p>
		/// The 4 bytes starting at the current position are composed into a float
		/// according to the current byte order and returned.
		/// </remarks>
		/// <returns>the float at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is greater than
		/// <code>limit - 4</code>
		/// .
		/// </exception>
		public abstract float getFloat();

		/// <summary>Returns the float at the specified index.</summary>
		/// <remarks>
		/// Returns the float at the specified index.
		/// <p>
		/// The 4 bytes starting at the specified index are composed into a float
		/// according to the current byte order and returned. The position is not
		/// changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 4</code>
		/// .
		/// </param>
		/// <returns>the float at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		public abstract float getFloat(int index);

		/// <summary>Returns the int at the current position and increases the position by 4.
		/// 	</summary>
		/// <remarks>
		/// Returns the int at the current position and increases the position by 4.
		/// <p>
		/// The 4 bytes starting at the current position are composed into a int
		/// according to the current byte order and returned.
		/// </remarks>
		/// <returns>the int at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is greater than
		/// <code>limit - 4</code>
		/// .
		/// </exception>
		public abstract int getInt();

		/// <summary>Returns the int at the specified index.</summary>
		/// <remarks>
		/// Returns the int at the specified index.
		/// <p>
		/// The 4 bytes starting at the specified index are composed into a int
		/// according to the current byte order and returned. The position is not
		/// changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 4</code>
		/// .
		/// </param>
		/// <returns>the int at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		public abstract int getInt(int index);

		/// <summary>Returns the long at the current position and increases the position by 8.
		/// 	</summary>
		/// <remarks>
		/// Returns the long at the current position and increases the position by 8.
		/// <p>
		/// The 8 bytes starting at the current position are composed into a long
		/// according to the current byte order and returned.
		/// </remarks>
		/// <returns>the long at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is greater than
		/// <code>limit - 8</code>
		/// .
		/// </exception>
		public abstract long getLong();

		/// <summary>Returns the long at the specified index.</summary>
		/// <remarks>
		/// Returns the long at the specified index.
		/// <p>
		/// The 8 bytes starting at the specified index are composed into a long
		/// according to the current byte order and returned. The position is not
		/// changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 8</code>
		/// .
		/// </param>
		/// <returns>the long at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		public abstract long getLong(int index);

		/// <summary>Returns the short at the current position and increases the position by 2.
		/// 	</summary>
		/// <remarks>
		/// Returns the short at the current position and increases the position by 2.
		/// <p>
		/// The 2 bytes starting at the current position are composed into a short
		/// according to the current byte order and returned.
		/// </remarks>
		/// <returns>the short at the current position.</returns>
		/// <exception>
		/// BufferUnderflowException
		/// if the position is greater than
		/// <code>limit - 2</code>
		/// .
		/// </exception>
		public abstract short getShort();

		/// <summary>Returns the short at the specified index.</summary>
		/// <remarks>
		/// Returns the short at the specified index.
		/// <p>
		/// The 2 bytes starting at the specified index are composed into a short
		/// according to the current byte order and returned. The position is not
		/// changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 2</code>
		/// .
		/// </param>
		/// <returns>the short at the specified index.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		public abstract short getShort(int index);

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
		/// <returns>the hash code calculated from the remaining bytes.</returns>
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
		/// <remarks>Indicates whether this buffer is direct.</remarks>
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
		/// Returns the byte order used by this buffer when converting bytes from/to
		/// other primitive types.
		/// </summary>
		/// <remarks>
		/// Returns the byte order used by this buffer when converting bytes from/to
		/// other primitive types.
		/// <p>
		/// The default byte order of byte buffer is always
		/// <see cref="ByteOrder.BIG_ENDIAN">BIG_ENDIAN</see>
		/// </remarks>
		/// <returns>
		/// the byte order used by this buffer when converting bytes from/to
		/// other primitive types.
		/// </returns>
		public java.nio.ByteOrder order()
		{
			return _order;
		}

		/// <summary>Sets the byte order of this buffer.</summary>
		/// <remarks>Sets the byte order of this buffer.</remarks>
		/// <param name="byteOrder">
		/// the byte order to set. If
		/// <code>null</code>
		/// then the order
		/// will be
		/// <see cref="ByteOrder.LITTLE_ENDIAN">LITTLE_ENDIAN</see>
		/// .
		/// </param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <seealso cref="ByteOrder">ByteOrder</seealso>
		public java.nio.ByteBuffer order(java.nio.ByteOrder byteOrder)
		{
			orderImpl(byteOrder);
			return this;
		}

		/// <summary>Subverts the fact that order(ByteOrder) is final, for the benefit of MappedByteBufferAdapter.
		/// 	</summary>
		/// <remarks>Subverts the fact that order(ByteOrder) is final, for the benefit of MappedByteBufferAdapter.
		/// 	</remarks>
		internal virtual void orderImpl(java.nio.ByteOrder byteOrder)
		{
			if (byteOrder == null)
			{
				byteOrder = java.nio.ByteOrder.LITTLE_ENDIAN;
			}
			_order = byteOrder;
		}

		/// <summary>
		/// Child class implements this method to realize
		/// <code>array()</code>
		/// .
		/// </summary>
		/// <seealso cref="array()">array()</seealso>
		internal abstract byte[] protectedArray();

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
		/// Writes the given byte to the current position and increases the position
		/// by 1.
		/// </summary>
		/// <remarks>
		/// Writes the given byte to the current position and increases the position
		/// by 1.
		/// </remarks>
		/// <param name="b">the byte to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is equal or greater than limit.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer put(byte b);

		/// <summary>
		/// Writes bytes in the given byte array to the current position and
		/// increases the position by the number of bytes written.
		/// </summary>
		/// <remarks>
		/// Writes bytes in the given byte array to the current position and
		/// increases the position by the number of bytes written.
		/// <p>
		/// Calling this method has the same effect as
		/// <code>put(src, 0, src.length)</code>
		/// .
		/// </remarks>
		/// <param name="src">the source byte array.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
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
		public java.nio.ByteBuffer put(byte[] src)
		{
			return put(src, 0, src.Length);
		}

		/// <summary>
		/// Writes bytes in the given byte array, starting from the specified offset,
		/// to the current position and increases the position by the number of bytes
		/// written.
		/// </summary>
		/// <remarks>
		/// Writes bytes in the given byte array, starting from the specified offset,
		/// to the current position and increases the position by the number of bytes
		/// written.
		/// </remarks>
		/// <param name="src">the source byte array.</param>
		/// <param name="srcOffset">
		/// the offset of byte array, must not be negative and not greater
		/// than
		/// <code>src.length</code>
		/// .
		/// </param>
		/// <param name="byteCount">
		/// the number of bytes to write, must not be negative and not
		/// greater than
		/// <code>src.length - srcOffset</code>
		/// .
		/// </param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if
		/// <code>remaining()</code>
		/// is less than
		/// <code>byteCount</code>
		/// .
		/// </exception>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if either
		/// <code>srcOffset</code>
		/// or
		/// <code>byteCount</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public virtual java.nio.ByteBuffer put(byte[] src, int srcOffset, int byteCount)
		{
			java.util.Arrays.checkOffsetAndCount(src.Length, srcOffset, byteCount);
			if (byteCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			{
				for (int i = srcOffset; i < srcOffset + byteCount; ++i)
				{
					put(src[i]);
				}
			}
			return this;
		}

		/// <summary>
		/// Write a byte to the specified index of this buffer without changing the
		/// position.
		/// </summary>
		/// <remarks>
		/// Write a byte to the specified index of this buffer without changing the
		/// position.
		/// </remarks>
		/// <param name="index">the index, must not be negative and less than the limit.</param>
		/// <param name="b">the byte to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer put(int index, byte b);

		/// <summary>
		/// Writes the given char to the current position and increases the position
		/// by 2.
		/// </summary>
		/// <remarks>
		/// Writes the given char to the current position and increases the position
		/// by 2.
		/// <p>
		/// The char is converted to bytes using the current byte order.
		/// </remarks>
		/// <param name="value">the char to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is greater than
		/// <code>limit - 2</code>
		/// .
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putChar(char value);

		/// <summary>Writes the given char to the specified index of this buffer.</summary>
		/// <remarks>
		/// Writes the given char to the specified index of this buffer.
		/// <p>
		/// The char is converted to bytes using the current byte order. The position
		/// is not changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 2</code>
		/// .
		/// </param>
		/// <param name="value">the char to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putChar(int index, char value);

		/// <summary>
		/// Writes the given double to the current position and increases the position
		/// by 8.
		/// </summary>
		/// <remarks>
		/// Writes the given double to the current position and increases the position
		/// by 8.
		/// <p>
		/// The double is converted to bytes using the current byte order.
		/// </remarks>
		/// <param name="value">the double to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is greater than
		/// <code>limit - 8</code>
		/// .
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putDouble(double value);

		/// <summary>Writes the given double to the specified index of this buffer.</summary>
		/// <remarks>
		/// Writes the given double to the specified index of this buffer.
		/// <p>
		/// The double is converted to bytes using the current byte order. The
		/// position is not changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 8</code>
		/// .
		/// </param>
		/// <param name="value">the double to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putDouble(int index, double value);

		/// <summary>
		/// Writes the given float to the current position and increases the position
		/// by 4.
		/// </summary>
		/// <remarks>
		/// Writes the given float to the current position and increases the position
		/// by 4.
		/// <p>
		/// The float is converted to bytes using the current byte order.
		/// </remarks>
		/// <param name="value">the float to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is greater than
		/// <code>limit - 4</code>
		/// .
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putFloat(float value);

		/// <summary>Writes the given float to the specified index of this buffer.</summary>
		/// <remarks>
		/// Writes the given float to the specified index of this buffer.
		/// <p>
		/// The float is converted to bytes using the current byte order. The
		/// position is not changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 4</code>
		/// .
		/// </param>
		/// <param name="value">the float to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putFloat(int index, float value);

		/// <summary>
		/// Writes the given int to the current position and increases the position by
		/// 4.
		/// </summary>
		/// <remarks>
		/// Writes the given int to the current position and increases the position by
		/// 4.
		/// <p>
		/// The int is converted to bytes using the current byte order.
		/// </remarks>
		/// <param name="value">the int to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is greater than
		/// <code>limit - 4</code>
		/// .
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putInt(int value);

		/// <summary>Writes the given int to the specified index of this buffer.</summary>
		/// <remarks>
		/// Writes the given int to the specified index of this buffer.
		/// <p>
		/// The int is converted to bytes using the current byte order. The position
		/// is not changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 4</code>
		/// .
		/// </param>
		/// <param name="value">the int to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putInt(int index, int value);

		/// <summary>
		/// Writes the given long to the current position and increases the position
		/// by 8.
		/// </summary>
		/// <remarks>
		/// Writes the given long to the current position and increases the position
		/// by 8.
		/// <p>
		/// The long is converted to bytes using the current byte order.
		/// </remarks>
		/// <param name="value">the long to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is greater than
		/// <code>limit - 8</code>
		/// .
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putLong(long value);

		/// <summary>Writes the given long to the specified index of this buffer.</summary>
		/// <remarks>
		/// Writes the given long to the specified index of this buffer.
		/// <p>
		/// The long is converted to bytes using the current byte order. The position
		/// is not changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 8</code>
		/// .
		/// </param>
		/// <param name="value">the long to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putLong(int index, long value);

		/// <summary>
		/// Writes the given short to the current position and increases the position
		/// by 2.
		/// </summary>
		/// <remarks>
		/// Writes the given short to the current position and increases the position
		/// by 2.
		/// <p>
		/// The short is converted to bytes using the current byte order.
		/// </remarks>
		/// <param name="value">the short to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// BufferOverflowException
		/// if position is greater than
		/// <code>limit - 2</code>
		/// .
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putShort(short value);

		/// <summary>Writes the given short to the specified index of this buffer.</summary>
		/// <remarks>
		/// Writes the given short to the specified index of this buffer.
		/// <p>
		/// The short is converted to bytes using the current byte order. The
		/// position is not changed.
		/// </remarks>
		/// <param name="index">
		/// the index, must not be negative and equal or less than
		/// <code>limit - 2</code>
		/// .
		/// </param>
		/// <param name="value">the short to write.</param>
		/// <returns>
		/// 
		/// <code>this</code>
		/// </returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// if
		/// <code>index</code>
		/// is invalid.
		/// </exception>
		/// <exception>
		/// ReadOnlyBufferException
		/// if no changes may be made to the contents of this buffer.
		/// </exception>
		public abstract java.nio.ByteBuffer putShort(int index, short value);

		/// <summary>Returns a sliced buffer that shares its content with this buffer.</summary>
		/// <remarks>
		/// Returns a sliced buffer that shares its content with this buffer.
		/// <p>
		/// The sliced buffer's capacity will be this buffer's
		/// <code>remaining()</code>
		/// , and it's zero position will correspond to
		/// this buffer's current position. The new buffer's position will be 0,
		/// limit will be its capacity, and its mark is cleared. The new buffer's
		/// read-only property and byte order are the same as this buffer's.
		/// <p>
		/// The new buffer shares its content with this buffer, which means either
		/// buffer's change of content will be visible to the other. The two buffer's
		/// position, limit and mark are independent.
		/// </remarks>
		/// <returns>a sliced buffer that shares its content with this buffer.</returns>
		public abstract java.nio.ByteBuffer slice();
	}
}
