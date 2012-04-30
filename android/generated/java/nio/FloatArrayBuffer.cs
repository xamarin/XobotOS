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
	/// FloatArrayBuffer implements all the shared readonly methods and is extended
	/// by the other two classes.
	/// </p>
	/// <p>
	/// All methods are marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class FloatArrayBuffer : java.nio.FloatBuffer
	{
		protected internal readonly float[] backingArray;

		protected internal readonly int offset;

		internal FloatArrayBuffer(float[] array_1) : this(array_1.Length, array_1, 0)
		{
		}

		internal FloatArrayBuffer(int capacity_1) : this(capacity_1, new float[capacity_1
			], 0)
		{
		}

		internal FloatArrayBuffer(int capacity_1, float[] backingArray, int offset) : base
			(capacity_1)
		{
			this.backingArray = backingArray;
			this.offset = offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public sealed override float get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return backingArray[offset + _position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public sealed override float get(int index)
		{
			checkIndex(index);
			return backingArray[offset + index];
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public sealed override java.nio.FloatBuffer get(float[] dst, int dstOffset, int floatCount
			)
		{
			if (floatCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			System.Array.Copy(backingArray, offset + _position, dst, dstOffset, floatCount);
			_position += floatCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool isDirect()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public sealed override java.nio.ByteOrder order()
		{
			return java.nio.ByteOrder.nativeOrder();
		}
	}
}
