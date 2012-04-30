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
	/// HeapByteBuffer implements all the shared readonly methods and is extended by
	/// the other two classes.
	/// </p>
	/// <p>
	/// All methods are marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class HeapByteBuffer : java.nio.BaseByteBuffer
	{
		/// <summary>These fields are non-private for NioUtils.unsafeArray.</summary>
		/// <remarks>These fields are non-private for NioUtils.unsafeArray.</remarks>
		internal readonly byte[] backingArray;

		internal readonly int offset;

		internal HeapByteBuffer(byte[] backingArray) : this(backingArray, backingArray.Length
			, 0)
		{
		}

		internal HeapByteBuffer(int capacity_1) : this(new byte[capacity_1], capacity_1, 
			0)
		{
		}

		internal HeapByteBuffer(byte[] backingArray, int capacity_1, int offset) : base(capacity_1
			, null)
		{
			this.backingArray = backingArray;
			this.offset = offset;
			if (offset + capacity_1 > backingArray.Length)
			{
				throw new System.IndexOutOfRangeException("backingArray.length=" + backingArray.Length
					 + ", capacity=" + capacity_1 + ", offset=" + offset);
			}
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override java.nio.ByteBuffer get(byte[] dst, int dstOffset, int byteCount
			)
		{
			checkGetBounds(1, dst.Length, dstOffset, byteCount);
			System.Array.Copy(backingArray, offset + _position, dst, dstOffset, byteCount);
			_position += byteCount;
			return this;
		}

		internal void get(char[] dst, int dstOffset, int charCount)
		{
			int byteCount = checkGetBounds(libcore.io.SizeOf.CHAR, dst.Length, dstOffset, charCount
				);
			libcore.io.Memory.unsafeBulkGet(dst, dstOffset, byteCount, backingArray, offset +
				 _position, libcore.io.SizeOf.CHAR, _order.needsSwap);
			_position += byteCount;
		}

		internal void get(double[] dst, int dstOffset, int doubleCount)
		{
			int byteCount = checkGetBounds(libcore.io.SizeOf.DOUBLE, dst.Length, dstOffset, doubleCount
				);
			libcore.io.Memory.unsafeBulkGet(dst, dstOffset, byteCount, backingArray, offset +
				 _position, libcore.io.SizeOf.DOUBLE, _order.needsSwap);
			_position += byteCount;
		}

		internal void get(float[] dst, int dstOffset, int floatCount)
		{
			int byteCount = checkGetBounds(libcore.io.SizeOf.FLOAT, dst.Length, dstOffset, floatCount
				);
			libcore.io.Memory.unsafeBulkGet(dst, dstOffset, byteCount, backingArray, offset +
				 _position, libcore.io.SizeOf.FLOAT, _order.needsSwap);
			_position += byteCount;
		}

		internal void get(int[] dst, int dstOffset, int intCount)
		{
			int byteCount = checkGetBounds(libcore.io.SizeOf.INT, dst.Length, dstOffset, intCount
				);
			libcore.io.Memory.unsafeBulkGet(dst, dstOffset, byteCount, backingArray, offset +
				 _position, libcore.io.SizeOf.INT, _order.needsSwap);
			_position += byteCount;
		}

		internal void get(long[] dst, int dstOffset, int longCount)
		{
			int byteCount = checkGetBounds(libcore.io.SizeOf.LONG, dst.Length, dstOffset, longCount
				);
			libcore.io.Memory.unsafeBulkGet(dst, dstOffset, byteCount, backingArray, offset +
				 _position, libcore.io.SizeOf.LONG, _order.needsSwap);
			_position += byteCount;
		}

		internal void get(short[] dst, int dstOffset, int shortCount)
		{
			int byteCount = checkGetBounds(libcore.io.SizeOf.SHORT, dst.Length, dstOffset, shortCount
				);
			libcore.io.Memory.unsafeBulkGet(dst, dstOffset, byteCount, backingArray, offset +
				 _position, libcore.io.SizeOf.SHORT, _order.needsSwap);
			_position += byteCount;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override byte get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return backingArray[offset + _position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override byte get(int index)
		{
			checkIndex(index);
			return backingArray[offset + index];
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override char getChar()
		{
			int newPosition = _position + libcore.io.SizeOf.CHAR;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			char result = (char)libcore.io.Memory.peekShort(backingArray, offset + _position, 
				_order);
			_position = newPosition;
			return result;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override char getChar(int index)
		{
			checkIndex(index, libcore.io.SizeOf.CHAR);
			return (char)libcore.io.Memory.peekShort(backingArray, offset + index, _order);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override double getDouble()
		{
			return Sharpen.Util.LongBitsToDouble(getLong());
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override double getDouble(int index)
		{
			return Sharpen.Util.LongBitsToDouble(getLong(index));
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override float getFloat()
		{
			return Sharpen.Util.IntBitsToFloat(getInt());
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override float getFloat(int index)
		{
			return Sharpen.Util.IntBitsToFloat(getInt(index));
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override int getInt()
		{
			int newPosition = _position + libcore.io.SizeOf.INT;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			int result = libcore.io.Memory.peekInt(backingArray, offset + _position, _order);
			_position = newPosition;
			return result;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override int getInt(int index)
		{
			checkIndex(index, libcore.io.SizeOf.INT);
			return libcore.io.Memory.peekInt(backingArray, offset + index, _order);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override long getLong()
		{
			int newPosition = _position + libcore.io.SizeOf.LONG;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			long result = libcore.io.Memory.peekLong(backingArray, offset + _position, _order
				);
			_position = newPosition;
			return result;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override long getLong(int index)
		{
			checkIndex(index, libcore.io.SizeOf.LONG);
			return libcore.io.Memory.peekLong(backingArray, offset + index, _order);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override short getShort()
		{
			int newPosition = _position + libcore.io.SizeOf.SHORT;
			if (newPosition > _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			short result = libcore.io.Memory.peekShort(backingArray, offset + _position, _order
				);
			_position = newPosition;
			return result;
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override short getShort(int index)
		{
			checkIndex(index, libcore.io.SizeOf.SHORT);
			return libcore.io.Memory.peekShort(backingArray, offset + index, _order);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool isDirect()
		{
			return false;
		}
	}
}
