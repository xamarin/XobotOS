using Sharpen;

namespace java.nio
{
	/// <summary>This class wraps a byte buffer to be a short buffer.</summary>
	/// <remarks>
	/// This class wraps a byte buffer to be a short buffer.
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
	internal sealed class ShortToByteBufferAdapter : java.nio.ShortBuffer
	{
		private readonly java.nio.ByteBuffer byteBuffer;

		internal static java.nio.ShortBuffer asShortBuffer(java.nio.ByteBuffer byteBuffer
			)
		{
			java.nio.ByteBuffer slice_1 = byteBuffer.slice();
			slice_1.order(byteBuffer.order());
			return new java.nio.ShortToByteBufferAdapter(slice_1);
		}

		private ShortToByteBufferAdapter(java.nio.ByteBuffer byteBuffer) : base(byteBuffer
			.capacity() / libcore.io.SizeOf.SHORT)
		{
			this.byteBuffer = byteBuffer;
			this.byteBuffer.clear();
			this.effectiveDirectAddress = byteBuffer.effectiveDirectAddress;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer asReadOnlyBuffer()
		{
			java.nio.ShortToByteBufferAdapter buf = new java.nio.ShortToByteBufferAdapter(byteBuffer
				.asReadOnlyBuffer());
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			buf.byteBuffer._order = byteBuffer._order;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer compact()
		{
			if (byteBuffer.isReadOnly())
			{
				throw new java.nio.ReadOnlyBufferException();
			}
			byteBuffer.limit(_limit * libcore.io.SizeOf.SHORT);
			byteBuffer.position(_position * libcore.io.SizeOf.SHORT);
			byteBuffer.compact();
			byteBuffer.clear();
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer duplicate()
		{
			java.nio.ByteBuffer bb = byteBuffer.duplicate().order(byteBuffer.order());
			java.nio.ShortToByteBufferAdapter buf = new java.nio.ShortToByteBufferAdapter(bb);
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override short get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return byteBuffer.getShort(_position++ * libcore.io.SizeOf.SHORT);
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override short get(int index)
		{
			checkIndex(index);
			return byteBuffer.getShort(index * libcore.io.SizeOf.SHORT);
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer get(short[] dst, int dstOffset, int shortCount
			)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.SHORT);
			byteBuffer.position(_position * libcore.io.SizeOf.SHORT);
			if (byteBuffer is java.nio.DirectByteBuffer)
			{
				((java.nio.DirectByteBuffer)byteBuffer).get(dst, dstOffset, shortCount);
			}
			else
			{
				((java.nio.HeapByteBuffer)byteBuffer).get(dst, dstOffset, shortCount);
			}
			this._position += shortCount;
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

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ByteOrder order()
		{
			return byteBuffer.order();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override short[] protectedArray()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(short c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			byteBuffer.putShort(_position++ * libcore.io.SizeOf.SHORT, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(int index, short c)
		{
			checkIndex(index);
			byteBuffer.putShort(index * libcore.io.SizeOf.SHORT, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer put(short[] src, int srcOffset, int shortCount
			)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.SHORT);
			byteBuffer.position(_position * libcore.io.SizeOf.SHORT);
			if (byteBuffer is java.nio.ReadWriteDirectByteBuffer)
			{
				((java.nio.ReadWriteDirectByteBuffer)byteBuffer).put(src, srcOffset, shortCount);
			}
			else
			{
				((java.nio.ReadWriteHeapByteBuffer)byteBuffer).put(src, srcOffset, shortCount);
			}
			this._position += shortCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.ShortBuffer")]
		public override java.nio.ShortBuffer slice()
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.SHORT);
			byteBuffer.position(_position * libcore.io.SizeOf.SHORT);
			java.nio.ByteBuffer bb = byteBuffer.slice().order(byteBuffer.order());
			java.nio.ShortBuffer result = new java.nio.ShortToByteBufferAdapter(bb);
			byteBuffer.clear();
			return result;
		}
	}
}
