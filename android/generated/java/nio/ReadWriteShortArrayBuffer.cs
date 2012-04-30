using Sharpen;

namespace java.nio
{
	/// <summary>
	/// ShortArrayBuffer, ReadWriteShortArrayBuffer and ReadOnlyShortArrayBuffer
	/// compose the implementation of array based short buffers.
	/// </summary>
	/// <remarks>
	/// ShortArrayBuffer, ReadWriteShortArrayBuffer and ReadOnlyShortArrayBuffer
	/// compose the implementation of array based short buffers.
	/// <p>
	/// ReadWriteShortArrayBuffer extends ShortArrayBuffer with all the write
	/// methods.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadWriteShortArrayBuffer : java.nio.ShortArrayBuffer
	{
		internal static java.nio.ReadWriteShortArrayBuffer copy(java.nio.ShortArrayBuffer
			 other, int markOfOther)
		{
			java.nio.ReadWriteShortArrayBuffer buf = new java.nio.ReadWriteShortArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadWriteShortArrayBuffer(short[] array_1) : base(array_1)
		{
		}

		internal ReadWriteShortArrayBuffer(int capacity_1) : base(capacity_1)
		{
		}

		internal ReadWriteShortArrayBuffer(int capacity_1, short[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer asReadOnlyBuffer()
		{
			return java.nio.ReadOnlyShortArrayBuffer.copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer compact()
		{
			System.Array.Copy(backingArray, _position + offset, backingArray, offset, remaining
				());
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override short[] protectedArray()
		{
			return backingArray;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override int protectedArrayOffset()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override bool protectedHasArray()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(short c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			backingArray[offset + _position++] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(int index, short c)
		{
			checkIndex(index);
			backingArray[offset + index] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(short[] src, int srcOffset, int shortCount
			)
		{
			if (shortCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			System.Array.Copy(src, srcOffset, backingArray, offset + _position, shortCount);
			_position += shortCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer slice()
		{
			return new java.nio.ReadWriteShortArrayBuffer(remaining(), backingArray, offset +
				 _position);
		}
	}
}
