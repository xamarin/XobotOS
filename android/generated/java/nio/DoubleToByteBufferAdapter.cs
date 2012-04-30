using Sharpen;

namespace java.nio
{
	/// <summary>This class wraps a byte buffer to be a double buffer.</summary>
	/// <remarks>
	/// This class wraps a byte buffer to be a double buffer.
	/// <p>
	/// Implementation notice:
	/// <ul>
	/// <li>After a byte buffer instance is wrapped, it becomes privately owned by
	/// the adapter. It must NOT be accessed outside the adapter any more.</li>
	/// <li>The byte buffer's position and limit are NOT linked with the adapter.
	/// The adapter extends Buffer, thus has its own position and limit.</li>
	/// </ul>
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class DoubleToByteBufferAdapter : java.nio.DoubleBuffer
	{
		private readonly java.nio.ByteBuffer byteBuffer;

		internal static java.nio.DoubleBuffer asDoubleBuffer(java.nio.ByteBuffer byteBuffer
			)
		{
			java.nio.ByteBuffer slice_1 = byteBuffer.slice();
			slice_1.order(byteBuffer.order());
			return new java.nio.DoubleToByteBufferAdapter(slice_1);
		}

		private DoubleToByteBufferAdapter(java.nio.ByteBuffer byteBuffer) : base(byteBuffer
			.capacity() / libcore.io.SizeOf.DOUBLE)
		{
			this.byteBuffer = byteBuffer;
			this.byteBuffer.clear();
			this.effectiveDirectAddress = byteBuffer.effectiveDirectAddress;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer asReadOnlyBuffer()
		{
			java.nio.DoubleToByteBufferAdapter buf = new java.nio.DoubleToByteBufferAdapter(byteBuffer
				.asReadOnlyBuffer());
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			buf.byteBuffer._order = byteBuffer._order;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer compact()
		{
			if (byteBuffer.isReadOnly())
			{
				throw new java.nio.ReadOnlyBufferException();
			}
			byteBuffer.limit(_limit * libcore.io.SizeOf.DOUBLE);
			byteBuffer.position(_position * libcore.io.SizeOf.DOUBLE);
			byteBuffer.compact();
			byteBuffer.clear();
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer duplicate()
		{
			java.nio.ByteBuffer bb = byteBuffer.duplicate().order(byteBuffer.order());
			java.nio.DoubleToByteBufferAdapter buf = new java.nio.DoubleToByteBufferAdapter(bb
				);
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override double get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return byteBuffer.getDouble(_position++ * libcore.io.SizeOf.DOUBLE);
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override double get(int index)
		{
			checkIndex(index);
			return byteBuffer.getDouble(index * libcore.io.SizeOf.DOUBLE);
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer get(double[] dst, int dstOffset, int doubleCount
			)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.DOUBLE);
			byteBuffer.position(_position * libcore.io.SizeOf.DOUBLE);
			if (byteBuffer is java.nio.DirectByteBuffer)
			{
				((java.nio.DirectByteBuffer)byteBuffer).get(dst, dstOffset, doubleCount);
			}
			else
			{
				((java.nio.HeapByteBuffer)byteBuffer).get(dst, dstOffset, doubleCount);
			}
			this._position += doubleCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isDirect()
		{
			return byteBuffer.isDirect();
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return byteBuffer.isReadOnly();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.ByteOrder order()
		{
			return byteBuffer.order();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override double[] protectedArray()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(double c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			byteBuffer.putDouble(_position++ * libcore.io.SizeOf.DOUBLE, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(int index, double c)
		{
			checkIndex(index);
			byteBuffer.putDouble(index * libcore.io.SizeOf.DOUBLE, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer put(double[] src, int srcOffset, int doubleCount
			)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.DOUBLE);
			byteBuffer.position(_position * libcore.io.SizeOf.DOUBLE);
			if (byteBuffer is java.nio.ReadWriteDirectByteBuffer)
			{
				((java.nio.ReadWriteDirectByteBuffer)byteBuffer).put(src, srcOffset, doubleCount);
			}
			else
			{
				((java.nio.ReadWriteHeapByteBuffer)byteBuffer).put(src, srcOffset, doubleCount);
			}
			this._position += doubleCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.DoubleBuffer")]
		public override java.nio.DoubleBuffer slice()
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.DOUBLE);
			byteBuffer.position(_position * libcore.io.SizeOf.DOUBLE);
			java.nio.ByteBuffer bb = byteBuffer.slice().order(byteBuffer.order());
			java.nio.DoubleBuffer result = new java.nio.DoubleToByteBufferAdapter(bb);
			byteBuffer.clear();
			return result;
		}
	}
}
