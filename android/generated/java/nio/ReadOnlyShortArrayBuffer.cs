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
	/// ReadOnlyShortArrayBuffer extends ShortArrayBuffer with all the write methods
	/// throwing read only exception.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadOnlyShortArrayBuffer : java.nio.ShortArrayBuffer
	{
		internal static java.nio.ReadOnlyShortArrayBuffer copy(java.nio.ShortArrayBuffer 
			other, int markOfOther)
		{
			java.nio.ReadOnlyShortArrayBuffer buf = new java.nio.ReadOnlyShortArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadOnlyShortArrayBuffer(int capacity_1, short[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer asReadOnlyBuffer()
		{
			return duplicate();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer compact()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override short[] protectedArray()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(java.nio.ShortBuffer buf)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(short c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(int index, short c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public sealed override java.nio.ShortBuffer put(short[] src, int srcOffset, int shortCount
			)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer slice()
		{
			return new java.nio.ReadOnlyShortArrayBuffer(remaining(), backingArray, offset + 
				_position);
		}
	}
}
