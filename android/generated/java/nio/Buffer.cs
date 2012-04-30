using Sharpen;

namespace java.nio
{
	/// <summary>A buffer is a list of elements of a specific primitive type.</summary>
	/// <remarks>
	/// A buffer is a list of elements of a specific primitive type.
	/// <p>
	/// A buffer can be described by the following properties:
	/// <ul>
	/// <li>Capacity: the number of elements a buffer can hold. Capacity may not be
	/// negative and never changes.</li>
	/// <li>Position: a cursor of this buffer. Elements are read or written at the
	/// position if you do not specify an index explicitly. Position may not be
	/// negative and not greater than the limit.</li>
	/// <li>Limit: controls the scope of accessible elements. You can only read or
	/// write elements from index zero to <code>limit - 1</code>. Accessing
	/// elements out of the scope will cause an exception. Limit may not be negative
	/// and not greater than capacity.</li>
	/// <li>Mark: used to remember the current position, so that you can reset the
	/// position later. Mark may not be negative and no greater than position.</li>
	/// <li>A buffer can be read-only or read-write. Trying to modify the elements
	/// of a read-only buffer will cause a <code>ReadOnlyBufferException</code>,
	/// while changing the position, limit and mark of a read-only buffer is OK.</li>
	/// <li>A buffer can be direct or indirect. A direct buffer will try its best to
	/// take advantage of native memory APIs and it may not stay in the Java heap,
	/// thus it is not affected by garbage collection.</li>
	/// </ul>
	/// <p>
	/// Buffers are not thread-safe. If concurrent access to a buffer instance is
	/// required, then the callers are responsible to take care of the
	/// synchronization issues.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Buffer
	{
		/// <summary><code>UNSET_MARK</code> means the mark has not been set.</summary>
		/// <remarks><code>UNSET_MARK</code> means the mark has not been set.</remarks>
		internal const int UNSET_MARK = -1;

		/// <summary>The capacity of this buffer, which never changes.</summary>
		/// <remarks>The capacity of this buffer, which never changes.</remarks>
		internal readonly int _capacity;

		/// <summary><code>limit - 1</code> is the last element that can be read or written.</summary>
		/// <remarks>
		/// <code>limit - 1</code> is the last element that can be read or written.
		/// Limit must be no less than zero and no greater than <code>capacity</code>.
		/// </remarks>
		internal int _limit;

		/// <summary>Mark is where position will be set when <code>reset()</code> is called.</summary>
		/// <remarks>
		/// Mark is where position will be set when <code>reset()</code> is called.
		/// Mark is not set by default. Mark is always no less than zero and no
		/// greater than <code>position</code>.
		/// </remarks>
		internal int _mark = UNSET_MARK;

		/// <summary>The current position of this buffer.</summary>
		/// <remarks>
		/// The current position of this buffer. Position is always no less than zero
		/// and no greater than <code>limit</code>.
		/// </remarks>
		internal int _position = 0;

		/// <summary>The log base 2 of the element size of this buffer.</summary>
		/// <remarks>
		/// The log base 2 of the element size of this buffer.  Each typed subclass
		/// (ByteBuffer, CharBuffer, etc.) is responsible for initializing this
		/// value.  The value is used by JNI code in frameworks/base/ to avoid the
		/// need for costly 'instanceof' tests.
		/// </remarks>
		internal readonly int _elementSizeShift;

		/// <summary>For direct buffers, the effective address of the data; zero otherwise.</summary>
		/// <remarks>
		/// For direct buffers, the effective address of the data; zero otherwise.
		/// This is set in the constructor.
		/// TODO: make this final at the cost of loads of extra constructors? [how many?]
		/// </remarks>
		internal int effectiveDirectAddress;

		/// <summary>For direct buffers, the underlying MemoryBlock; null otherwise.</summary>
		/// <remarks>For direct buffers, the underlying MemoryBlock; null otherwise.</remarks>
		internal readonly java.nio.MemoryBlock block;

		internal Buffer(int elementSizeShift, int capacity_1, java.nio.MemoryBlock block)
		{
			this._elementSizeShift = elementSizeShift;
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException("capacity < 0: " + capacity_1);
			}
			this._capacity = this._limit = capacity_1;
			this.block = block;
		}

		/// <summary>Returns the array that backs this buffer (optional operation).</summary>
		/// <remarks>
		/// Returns the array that backs this buffer (optional operation).
		/// The returned value is the actual array, not a copy, so modifications
		/// to the array write through to the buffer.
		/// <p>Subclasses should override this method with a covariant return type
		/// to provide the exact type of the array.
		/// <p>Use
		/// <code>hasArray</code>
		/// to ensure this method won't throw.
		/// (A separate call to
		/// <code>isReadOnly</code>
		/// is not necessary.)
		/// </remarks>
		/// <returns>the array</returns>
		/// <exception cref="ReadOnlyBufferException">
		/// if the buffer is read-only
		/// UnsupportedOperationException if the buffer does not expose an array
		/// </exception>
		/// <since>1.6</since>
		public abstract object array();

		/// <summary>
		/// Returns the offset into the array returned by
		/// <code>array</code>
		/// of the first
		/// element of the buffer (optional operation). The backing array (if there is one)
		/// is not necessarily the same size as the buffer, and position 0 in the buffer is
		/// not necessarily the 0th element in the array. Use
		/// <code>buffer.array()[offset + buffer.arrayOffset()</code>
		/// to access element
		/// <code>offset</code>
		/// in
		/// <code>buffer</code>
		/// .
		/// <p>Use
		/// <code>hasArray</code>
		/// to ensure this method won't throw.
		/// (A separate call to
		/// <code>isReadOnly</code>
		/// is not necessary.)
		/// </summary>
		/// <returns>the offset</returns>
		/// <exception cref="ReadOnlyBufferException">
		/// if the buffer is read-only
		/// UnsupportedOperationException if the buffer does not expose an array
		/// </exception>
		/// <since>1.6</since>
		public abstract int arrayOffset();

		/// <summary>Returns the capacity of this buffer.</summary>
		/// <remarks>Returns the capacity of this buffer.</remarks>
		/// <returns>the number of elements that are contained in this buffer.</returns>
		public int capacity()
		{
			return _capacity;
		}

		/// <summary>Used for the scalar get/put operations.</summary>
		/// <remarks>Used for the scalar get/put operations.</remarks>
		internal virtual void checkIndex(int index)
		{
			if (index < 0 || index >= _limit)
			{
				throw new System.IndexOutOfRangeException("index=" + index + ", limit=" + _limit);
			}
		}

		/// <summary>Used for the ByteBuffer operations that get types larger than a byte.</summary>
		/// <remarks>Used for the ByteBuffer operations that get types larger than a byte.</remarks>
		internal virtual void checkIndex(int index, int sizeOfType)
		{
			if (index < 0 || index > _limit - sizeOfType)
			{
				throw new System.IndexOutOfRangeException("index=" + index + ", limit=" + _limit 
					+ ", size of type=" + sizeOfType);
			}
		}

		internal virtual int checkGetBounds(int bytesPerElement, int length, int offset, 
			int count)
		{
			int byteCount = bytesPerElement * count;
			if ((offset | count) < 0 || offset > length || length - offset < count)
			{
				throw new System.IndexOutOfRangeException("offset=" + offset + ", count=" + count
					 + ", length=" + length);
			}
			if (byteCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			return byteCount;
		}

		internal virtual int checkPutBounds(int bytesPerElement, int length, int offset, 
			int count)
		{
			int byteCount = bytesPerElement * count;
			if ((offset | count) < 0 || offset > length || length - offset < count)
			{
				throw new System.IndexOutOfRangeException("offset=" + offset + ", count=" + count
					 + ", length=" + length);
			}
			if (byteCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			if (isReadOnly())
			{
				throw new java.nio.ReadOnlyBufferException();
			}
			return byteCount;
		}

		internal virtual void checkStartEndRemaining(int start, int end)
		{
			if (end < start || start < 0 || end > remaining())
			{
				throw new System.IndexOutOfRangeException("start=" + start + ", end=" + end + ", remaining()="
					 + remaining());
			}
		}

		/// <summary>Clears this buffer.</summary>
		/// <remarks>
		/// Clears this buffer.
		/// <p>
		/// While the content of this buffer is not changed, the following internal
		/// changes take place: the current position is reset back to the start of
		/// the buffer, the value of the buffer limit is made equal to the capacity
		/// and mark is cleared.
		/// </remarks>
		/// <returns>this buffer.</returns>
		public java.nio.Buffer clear()
		{
			_position = 0;
			_mark = UNSET_MARK;
			_limit = _capacity;
			return this;
		}

		/// <summary>Flips this buffer.</summary>
		/// <remarks>
		/// Flips this buffer.
		/// <p>
		/// The limit is set to the current position, then the position is set to
		/// zero, and the mark is cleared.
		/// <p>
		/// The content of this buffer is not changed.
		/// </remarks>
		/// <returns>this buffer.</returns>
		public java.nio.Buffer flip()
		{
			_limit = _position;
			_position = 0;
			_mark = UNSET_MARK;
			return this;
		}

		/// <summary>
		/// Returns true if
		/// <code>array</code>
		/// and
		/// <code>arrayOffset</code>
		/// won't throw. This method does not
		/// return true for buffers not backed by arrays because the other methods would throw
		/// <code>UnsupportedOperationException</code>
		/// , nor does it return true for buffers backed by
		/// read-only arrays, because the other methods would throw
		/// <code>ReadOnlyBufferException</code>
		/// .
		/// </summary>
		/// <since>1.6</since>
		public abstract bool hasArray();

		/// <summary>
		/// Indicates if there are elements remaining in this buffer, that is if
		/// <code>position &lt; limit</code>
		/// .
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if there are elements remaining in this buffer,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public bool hasRemaining()
		{
			return _position < _limit;
		}

		/// <summary>Returns true if this is a direct buffer.</summary>
		/// <remarks>Returns true if this is a direct buffer.</remarks>
		/// <since>1.6</since>
		public abstract bool isDirect();

		/// <summary>Indicates whether this buffer is read-only.</summary>
		/// <remarks>Indicates whether this buffer is read-only.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this buffer is read-only,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public abstract bool isReadOnly();

		internal void checkWritable()
		{
			if (isReadOnly())
			{
				throw new System.ArgumentException("read-only buffer");
			}
		}

		/// <summary>Returns the limit of this buffer.</summary>
		/// <remarks>Returns the limit of this buffer.</remarks>
		/// <returns>the limit of this buffer.</returns>
		public int limit()
		{
			return _limit;
		}

		/// <summary>Sets the limit of this buffer.</summary>
		/// <remarks>
		/// Sets the limit of this buffer.
		/// <p>
		/// If the current position in the buffer is in excess of
		/// <code>newLimit</code> then, on returning from this call, it will have
		/// been adjusted to be equivalent to <code>newLimit</code>. If the mark
		/// is set and is greater than the new limit, then it is cleared.
		/// </remarks>
		/// <param name="newLimit">
		/// the new limit, must not be negative and not greater than
		/// capacity.
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IllegalArgumentException
		/// if <code>newLimit</code> is invalid.
		/// </exception>
		public java.nio.Buffer limit(int newLimit)
		{
			limitImpl(newLimit);
			return this;
		}

		/// <summary>Subverts the fact that limit(int) is final, for the benefit of MappedByteBufferAdapter.
		/// 	</summary>
		/// <remarks>Subverts the fact that limit(int) is final, for the benefit of MappedByteBufferAdapter.
		/// 	</remarks>
		internal virtual void limitImpl(int newLimit)
		{
			if (newLimit < 0 || newLimit > _capacity)
			{
				throw new System.ArgumentException("Bad limit (capacity " + _capacity + "): " + newLimit
					);
			}
			_limit = newLimit;
			if (_position > newLimit)
			{
				_position = newLimit;
			}
			if ((_mark != UNSET_MARK) && (_mark > newLimit))
			{
				_mark = UNSET_MARK;
			}
		}

		/// <summary>
		/// Marks the current position, so that the position may return to this point
		/// later by calling <code>reset()</code>.
		/// </summary>
		/// <remarks>
		/// Marks the current position, so that the position may return to this point
		/// later by calling <code>reset()</code>.
		/// </remarks>
		/// <returns>this buffer.</returns>
		public java.nio.Buffer mark()
		{
			_mark = _position;
			return this;
		}

		/// <summary>Returns the position of this buffer.</summary>
		/// <remarks>Returns the position of this buffer.</remarks>
		/// <returns>the value of this buffer's current position.</returns>
		public int position()
		{
			return _position;
		}

		/// <summary>Sets the position of this buffer.</summary>
		/// <remarks>
		/// Sets the position of this buffer.
		/// <p>
		/// If the mark is set and it is greater than the new position, then it is
		/// cleared.
		/// </remarks>
		/// <param name="newPosition">
		/// the new position, must be not negative and not greater than
		/// limit.
		/// </param>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// IllegalArgumentException
		/// if <code>newPosition</code> is invalid.
		/// </exception>
		public java.nio.Buffer position(int newPosition)
		{
			positionImpl(newPosition);
			return this;
		}

		internal virtual void positionImpl(int newPosition)
		{
			if (newPosition < 0 || newPosition > _limit)
			{
				throw new System.ArgumentException("Bad position (limit " + _limit + "): " + newPosition
					);
			}
			_position = newPosition;
			if ((_mark != UNSET_MARK) && (_mark > _position))
			{
				_mark = UNSET_MARK;
			}
		}

		/// <summary>
		/// Returns the number of remaining elements in this buffer, that is
		/// <code>limit - position</code>
		/// .
		/// </summary>
		/// <returns>the number of remaining elements in this buffer.</returns>
		public int remaining()
		{
			return _limit - _position;
		}

		/// <summary>Resets the position of this buffer to the <code>mark</code>.</summary>
		/// <remarks>Resets the position of this buffer to the <code>mark</code>.</remarks>
		/// <returns>this buffer.</returns>
		/// <exception>
		/// InvalidMarkException
		/// if the mark is not set.
		/// </exception>
		public java.nio.Buffer reset()
		{
			if (_mark == UNSET_MARK)
			{
				throw new java.nio.InvalidMarkException("Mark not set");
			}
			_position = _mark;
			return this;
		}

		/// <summary>Rewinds this buffer.</summary>
		/// <remarks>
		/// Rewinds this buffer.
		/// <p>
		/// The position is set to zero, and the mark is cleared. The content of this
		/// buffer is not changed.
		/// </remarks>
		/// <returns>this buffer.</returns>
		public java.nio.Buffer rewind()
		{
			_position = 0;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder buf = new java.lang.StringBuilder();
			buf.append(GetType().FullName);
			buf.append(", status: capacity=");
			buf.append(_capacity);
			buf.append(" position=");
			buf.append(_position);
			buf.append(" limit=");
			buf.append(_limit);
			return buf.ToString();
		}
	}
}
