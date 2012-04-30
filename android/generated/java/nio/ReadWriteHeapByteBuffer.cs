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
	/// ReadWriteHeapByteBuffer extends HeapByteBuffer with all the write methods.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadWriteHeapByteBuffer : java.nio.HeapByteBuffer
	{
		internal static java.nio.ReadWriteHeapByteBuffer copy(java.nio.HeapByteBuffer other
			, int markOfOther)
		{
			java.nio.ReadWriteHeapByteBuffer buf = new java.nio.ReadWriteHeapByteBuffer(other
				.backingArray, other.capacity(), other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadWriteHeapByteBuffer(byte[] backingArray) : base(backingArray)
		{
		}

		internal ReadWriteHeapByteBuffer(int capacity_1) : base(capacity_1)
		{
		}

		internal ReadWriteHeapByteBuffer(byte[] backingArray, int capacity_1, int arrayOffset_1
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
			System.Array.Copy(backingArray, _position + offset, backingArray, offset, remaining
				());
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		internal override byte[] protectedArray()
		{
			return backingArray;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		internal override int protectedArrayOffset()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		internal override bool protectedHasArray()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(byte b)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			backingArray[offset + _position++] = b;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(int index, byte b)
		{
			checkIndex(index);
			backingArray[offset + index] = b;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(byte[] src, int srcOffset, int byteCount)
		{
			checkPutBounds(1, src.Length, srcOffset, byteCount);
			System.Array.Copy(src, srcOffset, backingArray, offset + _position, byteCount);
			_position += byteCount;
			return this;
		}

		internal void put(char[] src, int srcOffset, int charCount)
		{
			int byteCount = checkPutBounds(libcore.io.SizeOf.CHAR, src.Length, srcOffset, charCount
				);
			libcore.io.Memory.unsafeBulkPut(backingArray, offset + _position, byteCount, src, 
				srcOffset, libcore.io.SizeOf.CHAR, _order.needsSwap);
			_position += byteCount;
		}

		internal void put(double[] src, int srcOffset, int doubleCount)
		{
			int byteCount = checkPutBounds(libcore.io.SizeOf.DOUBLE, src.Length, srcOffset, doubleCount
				);
			libcore.io.Memory.unsafeBulkPut(backingArray, offset + _position, byteCount, src, 
				srcOffset, libcore.io.SizeOf.DOUBLE, _order.needsSwap);
			_position += byteCount;
		}

		internal void put(float[] src, int srcOffset, int floatCount)
		{
			int byteCount = checkPutBounds(libcore.io.SizeOf.FLOAT, src.Length, srcOffset, floatCount
				);
			libcore.io.Memory.unsafeBulkPut(backingArray, offset + _position, byteCount, src, 
				srcOffset, libcore.io.SizeOf.FLOAT, _order.needsSwap);
			_position += byteCount;
		}

		internal void put(int[] src, int srcOffset, int intCount)
		{
			int byteCount = checkPutBounds(libcore.io.SizeOf.INT, src.Length, srcOffset, intCount
				);
			libcore.io.Memory.unsafeBulkPut(backingArray, offset + _position, byteCount, src, 
				srcOffset, libcore.io.SizeOf.INT, _order.needsSwap);
			_position += byteCount;
		}

		internal void put(long[] src, int srcOffset, int longCount)
		{
			int byteCount = checkPutBounds(libcore.io.SizeOf.LONG, src.Length, srcOffset, longCount
				);
			libcore.io.Memory.unsafeBulkPut(backingArray, offset + _position, byteCount, src, 
				srcOffset, libcore.io.SizeOf.LONG, _order.needsSwap);
			_position += byteCount;
		}

		internal void put(short[] src, int srcOffset, int shortCount)
		{
			int byteCount = checkPutBounds(libcore.io.SizeOf.SHORT, src.Length, srcOffset, shortCount
				);
			libcore.io.Memory.unsafeBulkPut(backingArray, offset + _position, byteCount, src, 
				srcOffset, libcore.io.SizeOf.SHORT, _order.needsSwap);
			_position += byteCount;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putChar(int index, char value)
		{
			checkIndex(index, libcore.io.SizeOf.CHAR);
			libcore.io.Memory.pokeShort(backingArray, offset + index, (short)value, _order);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putChar(char value)
		{
			int newPosition = _position + libcore.io.SizeOf.CHAR;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			libcore.io.Memory.pokeShort(backingArray, offset + _position, (short)value, _order
				);
			_position = newPosition;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putDouble(double value)
		{
			return putLong(Sharpen.Util.DoubleToRawLongBits(value));
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putDouble(int index, double value)
		{
			return putLong(index, Sharpen.Util.DoubleToRawLongBits(value));
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putFloat(float value)
		{
			return putInt(Sharpen.Util.FloatToRawIntBits(value));
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putFloat(int index, float value)
		{
			return putInt(index, Sharpen.Util.FloatToRawIntBits(value));
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putInt(int value)
		{
			int newPosition = _position + libcore.io.SizeOf.INT;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			libcore.io.Memory.pokeInt(backingArray, offset + _position, value, _order);
			_position = newPosition;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putInt(int index, int value)
		{
			checkIndex(index, libcore.io.SizeOf.INT);
			libcore.io.Memory.pokeInt(backingArray, offset + index, value, _order);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putLong(int index, long value)
		{
			checkIndex(index, libcore.io.SizeOf.LONG);
			libcore.io.Memory.pokeLong(backingArray, offset + index, value, _order);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putLong(long value)
		{
			int newPosition = _position + libcore.io.SizeOf.LONG;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			libcore.io.Memory.pokeLong(backingArray, offset + _position, value, _order);
			_position = newPosition;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putShort(int index, short value)
		{
			checkIndex(index, libcore.io.SizeOf.SHORT);
			libcore.io.Memory.pokeShort(backingArray, offset + index, value, _order);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putShort(short value)
		{
			int newPosition = _position + libcore.io.SizeOf.SHORT;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			libcore.io.Memory.pokeShort(backingArray, offset + _position, value, _order);
			_position = newPosition;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer slice()
		{
			return new java.nio.ReadWriteHeapByteBuffer(backingArray, remaining(), offset + _position
				);
		}
	}
}
