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
	/// IntArrayBuffer implements all the shared readonly methods and is extended by
	/// the other two classes.
	/// </p>
	/// <p>
	/// All methods are marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class IntArrayBuffer : java.nio.IntBuffer
	{
		protected internal readonly int[] backingArray;

		protected internal readonly int offset;

		internal IntArrayBuffer(int[] array_1) : this(array_1.Length, array_1, 0)
		{
		}

		internal IntArrayBuffer(int capacity_1) : this(capacity_1, new int[capacity_1], 0
			)
		{
		}

		internal IntArrayBuffer(int capacity_1, int[] backingArray, int offset) : base(capacity_1
			)
		{
			this.backingArray = backingArray;
			this.offset = offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public sealed override int get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return backingArray[offset + _position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public sealed override int get(int index)
		{
			checkIndex(index);
			return backingArray[offset + index];
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public sealed override java.nio.IntBuffer get(int[] dst, int dstOffset, int intCount
			)
		{
			if (intCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			System.Array.Copy(backingArray, offset + _position, dst, dstOffset, intCount);
			_position += intCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool isDirect()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public sealed override java.nio.ByteOrder order()
		{
			return java.nio.ByteOrder.nativeOrder();
		}
	}
}
