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
	/// ReadOnlyLongArrayBuffer extends LongArrayBuffer with all the write methods
	/// throwing read only exception.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadOnlyLongArrayBuffer : java.nio.LongArrayBuffer
	{
		internal static java.nio.ReadOnlyLongArrayBuffer copy(java.nio.LongArrayBuffer other
			, int markOfOther)
		{
			java.nio.ReadOnlyLongArrayBuffer buf = new java.nio.ReadOnlyLongArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadOnlyLongArrayBuffer(int capacity_1, long[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer asReadOnlyBuffer()
		{
			return duplicate();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer compact()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override long[] protectedArray()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(long c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(int index, long c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(java.nio.LongBuffer buf)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public sealed override java.nio.LongBuffer put(long[] src, int srcOffset, int longCount
			)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer slice()
		{
			return new java.nio.ReadOnlyLongArrayBuffer(remaining(), backingArray, offset + _position
				);
		}
	}
}
