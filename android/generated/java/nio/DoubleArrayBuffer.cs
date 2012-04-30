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
	/// DoubleArrayBuffer implements all the shared readonly methods and is extended
	/// by the other two classes.
	/// </p>
	/// <p>
	/// All methods are marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class DoubleArrayBuffer : java.nio.DoubleBuffer
	{
		protected internal readonly double[] backingArray;

		protected internal readonly int offset;

		internal DoubleArrayBuffer(double[] array_1) : this(array_1.Length, array_1, 0)
		{
		}

		internal DoubleArrayBuffer(int capacity_1) : this(capacity_1, new double[capacity_1
			], 0)
		{
		}

		internal DoubleArrayBuffer(int capacity_1, double[] backingArray, int offset) : base
			(capacity_1)
		{
			this.backingArray = backingArray;
			this.offset = offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public sealed override double get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return backingArray[offset + _position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public sealed override double get(int index)
		{
			checkIndex(index);
			return backingArray[offset + index];
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public sealed override java.nio.DoubleBuffer get(double[] dst, int dstOffset, int
			 doubleCount)
		{
			if (doubleCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			System.Array.Copy(backingArray, offset + _position, dst, dstOffset, doubleCount);
			_position += doubleCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool isDirect()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public sealed override java.nio.ByteOrder order()
		{
			return java.nio.ByteOrder.nativeOrder();
		}
	}
}
