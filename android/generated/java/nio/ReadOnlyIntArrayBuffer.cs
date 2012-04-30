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
	/// ReadOnlyIntArrayBuffer extends IntArrayBuffer with all the write methods
	/// throwing read only exception.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadOnlyIntArrayBuffer : java.nio.IntArrayBuffer
	{
		internal static java.nio.ReadOnlyIntArrayBuffer copy(java.nio.IntArrayBuffer other
			, int markOfOther)
		{
			java.nio.ReadOnlyIntArrayBuffer buf = new java.nio.ReadOnlyIntArrayBuffer(other.capacity
				(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadOnlyIntArrayBuffer(int capacity_1, int[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer asReadOnlyBuffer()
		{
			return duplicate();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer compact()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override int[] protectedArray()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int index, int c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(java.nio.IntBuffer buf)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public sealed override java.nio.IntBuffer put(int[] src, int srcOffset, int intCount
			)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer slice()
		{
			return new java.nio.ReadOnlyIntArrayBuffer(remaining(), backingArray, offset + _position
				);
		}
	}
}
