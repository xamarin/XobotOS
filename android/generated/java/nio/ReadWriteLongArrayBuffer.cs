using Sharpen;

namespace java.nio
{
	/// <summary>
	/// LongArrayBuffer, ReadWriteLongArrayBuffer and ReadOnlyLongArrayBuffer compose
	/// the implementation of array based long buffers.
	/// </summary>
	/// <remarks>
	/// LongArrayBuffer, ReadWriteLongArrayBuffer and ReadOnlyLongArrayBuffer compose
	/// the implementation of array based long buffers.
	/// <p>
	/// ReadWriteLongArrayBuffer extends LongArrayBuffer with all the write methods.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadWriteLongArrayBuffer : java.nio.LongArrayBuffer
	{
		internal static java.nio.ReadWriteLongArrayBuffer copy(java.nio.LongArrayBuffer other
			, int markOfOther)
		{
			java.nio.ReadWriteLongArrayBuffer buf = new java.nio.ReadWriteLongArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadWriteLongArrayBuffer(long[] array_1) : base(array_1)
		{
		}

		internal ReadWriteLongArrayBuffer(int capacity_1) : base(capacity_1)
		{
		}

		internal ReadWriteLongArrayBuffer(int capacity_1, long[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer asReadOnlyBuffer()
		{
			return java.nio.ReadOnlyLongArrayBuffer.copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer compact()
		{
			System.Array.Copy(backingArray, _position + offset, backingArray, offset, remaining
				());
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override long[] protectedArray()
		{
			return backingArray;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override int protectedArrayOffset()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override bool protectedHasArray()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(long c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			backingArray[offset + _position++] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(int index, long c)
		{
			checkIndex(index);
			backingArray[offset + index] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(long[] src, int srcOffset, int longCount)
		{
			if (longCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			System.Array.Copy(src, srcOffset, backingArray, offset + _position, longCount);
			_position += longCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer slice()
		{
			return new java.nio.ReadWriteLongArrayBuffer(remaining(), backingArray, offset + 
				_position);
		}
	}
}
