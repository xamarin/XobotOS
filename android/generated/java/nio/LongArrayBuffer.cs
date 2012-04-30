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
	/// LongArrayBuffer implements all the shared readonly methods and is extended by
	/// the other two classes.
	/// </p>
	/// <p>
	/// All methods are marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class LongArrayBuffer : java.nio.LongBuffer
	{
		protected internal readonly long[] backingArray;

		protected internal readonly int offset;

		internal LongArrayBuffer(long[] array_1) : this(array_1.Length, array_1, 0)
		{
		}

		internal LongArrayBuffer(int capacity_1) : this(capacity_1, new long[capacity_1], 
			0)
		{
		}

		internal LongArrayBuffer(int capacity_1, long[] backingArray, int offset) : base(
			capacity_1)
		{
			this.backingArray = backingArray;
			this.offset = offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public sealed override long get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return backingArray[offset + _position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public sealed override long get(int index)
		{
			checkIndex(index);
			return backingArray[offset + index];
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public sealed override java.nio.LongBuffer get(long[] dst, int dstOffset, int longCount
			)
		{
			if (longCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			System.Array.Copy(backingArray, offset + _position, dst, dstOffset, longCount);
			_position += longCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool isDirect()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public sealed override java.nio.ByteOrder order()
		{
			return java.nio.ByteOrder.nativeOrder();
		}
	}
}
