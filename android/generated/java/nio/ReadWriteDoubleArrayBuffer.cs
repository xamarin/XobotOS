using Sharpen;

namespace java.nio
{
	/// <summary>
	/// DoubleArrayBuffer, ReadWriteDoubleArrayBuffer and ReadOnlyDoubleArrayBuffer
	/// compose the implementation of array based double buffers.
	/// </summary>
	/// <remarks>
	/// DoubleArrayBuffer, ReadWriteDoubleArrayBuffer and ReadOnlyDoubleArrayBuffer
	/// compose the implementation of array based double buffers.
	/// <p>
	/// ReadWriteDoubleArrayBuffer extends DoubleArrayBuffer with all the write
	/// methods.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadWriteDoubleArrayBuffer : java.nio.DoubleArrayBuffer
	{
		internal static java.nio.ReadWriteDoubleArrayBuffer copy(java.nio.DoubleArrayBuffer
			 other, int markOfOther)
		{
			java.nio.ReadWriteDoubleArrayBuffer buf = new java.nio.ReadWriteDoubleArrayBuffer
				(other.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadWriteDoubleArrayBuffer(double[] array_1) : base(array_1)
		{
		}

		internal ReadWriteDoubleArrayBuffer(int capacity_1) : base(capacity_1)
		{
		}

		internal ReadWriteDoubleArrayBuffer(int capacity_1, double[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer asReadOnlyBuffer()
		{
			return java.nio.ReadOnlyDoubleArrayBuffer.copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer compact()
		{
			System.Array.Copy(backingArray, _position + offset, backingArray, offset, remaining
				());
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override double[] protectedArray()
		{
			return backingArray;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override int protectedArrayOffset()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override bool protectedHasArray()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(double c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			backingArray[offset + _position++] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(int index, double c)
		{
			checkIndex(index);
			backingArray[offset + index] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(double[] src, int srcOffset, int doubleCount
			)
		{
			if (doubleCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			System.Array.Copy(src, srcOffset, backingArray, offset + _position, doubleCount);
			_position += doubleCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer slice()
		{
			return new java.nio.ReadWriteDoubleArrayBuffer(remaining(), backingArray, offset 
				+ _position);
		}
	}
}
