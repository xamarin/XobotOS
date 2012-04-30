using Sharpen;

namespace java.nio
{
	/// <summary>This class wraps a byte buffer to be a long buffer.</summary>
	/// <remarks>
	/// This class wraps a byte buffer to be a long buffer.
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
	internal sealed class LongToByteBufferAdapter : java.nio.LongBuffer
	{
		private readonly java.nio.ByteBuffer byteBuffer;

		internal static java.nio.LongBuffer asLongBuffer(java.nio.ByteBuffer byteBuffer)
		{
			java.nio.ByteBuffer slice_1 = byteBuffer.slice();
			slice_1.order(byteBuffer.order());
			return new java.nio.LongToByteBufferAdapter(slice_1);
		}

		private LongToByteBufferAdapter(java.nio.ByteBuffer byteBuffer) : base(byteBuffer
			.capacity() / libcore.io.SizeOf.LONG)
		{
			this.byteBuffer = byteBuffer;
			this.byteBuffer.clear();
			this.effectiveDirectAddress = byteBuffer.effectiveDirectAddress;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer asReadOnlyBuffer()
		{
			java.nio.LongToByteBufferAdapter buf = new java.nio.LongToByteBufferAdapter(byteBuffer
				.asReadOnlyBuffer());
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			buf.byteBuffer._order = byteBuffer._order;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer compact()
		{
			if (byteBuffer.isReadOnly())
			{
				throw new java.nio.ReadOnlyBufferException();
			}
			byteBuffer.limit(_limit * libcore.io.SizeOf.LONG);
			byteBuffer.position(_position * libcore.io.SizeOf.LONG);
			byteBuffer.compact();
			byteBuffer.clear();
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer duplicate()
		{
			java.nio.ByteBuffer bb = byteBuffer.duplicate().order(byteBuffer.order());
			java.nio.LongToByteBufferAdapter buf = new java.nio.LongToByteBufferAdapter(bb);
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override long get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return byteBuffer.getLong(_position++ * libcore.io.SizeOf.LONG);
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override long get(int index)
		{
			checkIndex(index);
			return byteBuffer.getLong(index * libcore.io.SizeOf.LONG);
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer get(long[] dst, int dstOffset, int longCount)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.LONG);
			byteBuffer.position(_position * libcore.io.SizeOf.LONG);
			if (byteBuffer is java.nio.DirectByteBuffer)
			{
				((java.nio.DirectByteBuffer)byteBuffer).get(dst, dstOffset, longCount);
			}
			else
			{
				((java.nio.HeapByteBuffer)byteBuffer).get(dst, dstOffset, longCount);
			}
			this._position += longCount;
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

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.ByteOrder order()
		{
			return byteBuffer.order();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override long[] protectedArray()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(long c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			byteBuffer.putLong(_position++ * libcore.io.SizeOf.LONG, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(int index, long c)
		{
			checkIndex(index);
			byteBuffer.putLong(index * libcore.io.SizeOf.LONG, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer put(long[] src, int srcOffset, int longCount)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.LONG);
			byteBuffer.position(_position * libcore.io.SizeOf.LONG);
			if (byteBuffer is java.nio.ReadWriteDirectByteBuffer)
			{
				((java.nio.ReadWriteDirectByteBuffer)byteBuffer).put(src, srcOffset, longCount);
			}
			else
			{
				((java.nio.ReadWriteHeapByteBuffer)byteBuffer).put(src, srcOffset, longCount);
			}
			this._position += longCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.LongBuffer")]
		public override java.nio.LongBuffer slice()
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.LONG);
			byteBuffer.position(_position * libcore.io.SizeOf.LONG);
			java.nio.ByteBuffer bb = byteBuffer.slice().order(byteBuffer.order());
			java.nio.LongBuffer result = new java.nio.LongToByteBufferAdapter(bb);
			byteBuffer.clear();
			return result;
		}
	}
}
