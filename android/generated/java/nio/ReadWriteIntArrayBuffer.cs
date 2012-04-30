using Sharpen;

namespace java.nio
{
	/// <summary>
	/// IntArrayBuffer, ReadWriteIntArrayBuffer and ReadOnlyIntArrayBuffer compose
	/// the implementation of array based int buffers.
	/// </summary>
	/// <remarks>
	/// IntArrayBuffer, ReadWriteIntArrayBuffer and ReadOnlyIntArrayBuffer compose
	/// the implementation of array based int buffers.
	/// <p>
	/// ReadWriteIntArrayBuffer extends IntArrayBuffer with all the write methods.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadWriteIntArrayBuffer : java.nio.IntArrayBuffer
	{
		internal static java.nio.ReadWriteIntArrayBuffer copy(java.nio.IntArrayBuffer other
			, int markOfOther)
		{
			java.nio.ReadWriteIntArrayBuffer buf = new java.nio.ReadWriteIntArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadWriteIntArrayBuffer(int[] array_1) : base(array_1)
		{
		}

		internal ReadWriteIntArrayBuffer(int capacity_1) : base(capacity_1)
		{
		}

		internal ReadWriteIntArrayBuffer(int capacity_1, int[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer asReadOnlyBuffer()
		{
			return java.nio.ReadOnlyIntArrayBuffer.copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer compact()
		{
			System.Array.Copy(backingArray, _position + offset, backingArray, offset, remaining
				());
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override int[] protectedArray()
		{
			return backingArray;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override int protectedArrayOffset()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override bool protectedHasArray()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			backingArray[offset + _position++] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int index, int c)
		{
			checkIndex(index);
			backingArray[offset + index] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int[] src, int srcOffset, int intCount)
		{
			if (intCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			System.Array.Copy(src, srcOffset, backingArray, offset + _position, intCount);
			_position += intCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer slice()
		{
			return new java.nio.ReadWriteIntArrayBuffer(remaining(), backingArray, offset + _position
				);
		}
	}
}
