using Sharpen;

namespace java.nio
{
	/// <summary>
	/// FloatArrayBuffer, ReadWriteFloatArrayBuffer and ReadOnlyFloatArrayBuffer
	/// compose the implementation of array based float buffers.
	/// </summary>
	/// <remarks>
	/// FloatArrayBuffer, ReadWriteFloatArrayBuffer and ReadOnlyFloatArrayBuffer
	/// compose the implementation of array based float buffers.
	/// <p>
	/// ReadWriteFloatArrayBuffer extends FloatArrayBuffer with all the write
	/// methods.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadWriteFloatArrayBuffer : java.nio.FloatArrayBuffer
	{
		internal static java.nio.ReadWriteFloatArrayBuffer copy(java.nio.FloatArrayBuffer
			 other, int markOfOther)
		{
			java.nio.ReadWriteFloatArrayBuffer buf = new java.nio.ReadWriteFloatArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadWriteFloatArrayBuffer(float[] array_1) : base(array_1)
		{
		}

		internal ReadWriteFloatArrayBuffer(int capacity_1) : base(capacity_1)
		{
		}

		internal ReadWriteFloatArrayBuffer(int capacity_1, float[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer asReadOnlyBuffer()
		{
			return java.nio.ReadOnlyFloatArrayBuffer.copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer compact()
		{
			System.Array.Copy(backingArray, _position + offset, backingArray, offset, remaining
				());
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override float[] protectedArray()
		{
			return backingArray;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override int protectedArrayOffset()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override bool protectedHasArray()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(float c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			backingArray[offset + _position++] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(int index, float c)
		{
			checkIndex(index);
			backingArray[offset + index] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(float[] src, int srcOffset, int floatCount
			)
		{
			if (floatCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			System.Array.Copy(src, srcOffset, backingArray, offset + _position, floatCount);
			_position += floatCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer slice()
		{
			return new java.nio.ReadWriteFloatArrayBuffer(remaining(), backingArray, offset +
				 _position);
		}
	}
}
