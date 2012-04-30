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
	/// ReadOnlyDoubleArrayBuffer extends DoubleArrayBuffer with all the write
	/// methods throwing read only exception.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadOnlyDoubleArrayBuffer : java.nio.DoubleArrayBuffer
	{
		internal static java.nio.ReadOnlyDoubleArrayBuffer copy(java.nio.DoubleArrayBuffer
			 other, int markOfOther)
		{
			java.nio.ReadOnlyDoubleArrayBuffer buf = new java.nio.ReadOnlyDoubleArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadOnlyDoubleArrayBuffer(int capacity_1, double[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer asReadOnlyBuffer()
		{
			return duplicate();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer compact()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override double[] protectedArray()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(double c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(int index, double c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public sealed override java.nio.DoubleBuffer put(double[] src, int srcOffset, int
			 byteCount)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public sealed override java.nio.DoubleBuffer put(java.nio.DoubleBuffer buf)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer slice()
		{
			return new java.nio.ReadOnlyDoubleArrayBuffer(remaining(), backingArray, offset +
				 _position);
		}
	}
}
