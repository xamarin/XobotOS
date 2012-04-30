using Sharpen;

namespace java.nio
{
	/// <summary>
	/// HeapByteBuffer, ReadWriteHeapByteBuffer and ReadOnlyHeapByteBuffer compose
	/// the implementation of array based byte buffers.
	/// </summary>
	/// <remarks>
	/// HeapByteBuffer, ReadWriteHeapByteBuffer and ReadOnlyHeapByteBuffer compose
	/// the implementation of array based byte buffers.
	/// <p>
	/// ReadOnlyHeapByteBuffer extends HeapByteBuffer with all the write methods
	/// throwing read only exception.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadOnlyHeapByteBuffer : java.nio.HeapByteBuffer
	{
		internal static java.nio.ReadOnlyHeapByteBuffer copy(java.nio.HeapByteBuffer other
			, int markOfOther)
		{
			java.nio.ReadOnlyHeapByteBuffer buf = new java.nio.ReadOnlyHeapByteBuffer(other.backingArray
				, other.capacity(), other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadOnlyHeapByteBuffer(byte[] backingArray, int capacity_1, int arrayOffset_1
			) : base(backingArray, capacity_1, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer asReadOnlyBuffer()
		{
			return java.nio.ReadOnlyHeapByteBuffer.copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer compact()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		internal override byte[] protectedArray()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(byte b)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(int index, byte b)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(byte[] src, int srcOffset, int byteCount)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putDouble(double value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putDouble(int index, double value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putFloat(float value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putFloat(int index, float value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putInt(int value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putInt(int index, int value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putLong(int index, long value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putLong(long value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putShort(int index, short value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putShort(short value)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(java.nio.ByteBuffer buf)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer slice()
		{
			return new java.nio.ReadOnlyHeapByteBuffer(backingArray, remaining(), offset + _position
				);
		}
	}
}
