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
	/// ShortArrayBuffer implements all the shared readonly methods and is extended
	/// by the other two classes.
	/// </p>
	/// <p>
	/// All methods are marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class ShortArrayBuffer : java.nio.ShortBuffer
	{
		protected internal readonly short[] backingArray;

		protected internal readonly int offset;

		internal ShortArrayBuffer(short[] array_1) : this(array_1.Length, array_1, 0)
		{
		}

		internal ShortArrayBuffer(int capacity_1) : this(capacity_1, new short[capacity_1
			], 0)
		{
		}

		internal ShortArrayBuffer(int capacity_1, short[] backingArray, int offset) : base
			(capacity_1)
		{
			this.backingArray = backingArray;
			this.offset = offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public sealed override short get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return backingArray[offset + _position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public sealed override short get(int index)
		{
			checkIndex(index);
			return backingArray[offset + index];
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public sealed override java.nio.ShortBuffer get(short[] dst, int dstOffset, int shortCount
			)
		{
			if (shortCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			System.Array.Copy(backingArray, offset + _position, dst, dstOffset, shortCount);
			_position += shortCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool isDirect()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public sealed override java.nio.ByteOrder order()
		{
			return java.nio.ByteOrder.nativeOrder();
		}
	}
}
