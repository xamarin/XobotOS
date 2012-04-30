using Sharpen;

namespace java.nio
{
	/// <summary>This class wraps a byte buffer to be a int buffer.</summary>
	/// <remarks>
	/// This class wraps a byte buffer to be a int buffer.
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
	internal sealed class IntToByteBufferAdapter : java.nio.IntBuffer
	{
		private readonly java.nio.ByteBuffer byteBuffer;

		internal static java.nio.IntBuffer asIntBuffer(java.nio.ByteBuffer byteBuffer)
		{
			java.nio.ByteBuffer slice_1 = byteBuffer.slice();
			slice_1.order(byteBuffer.order());
			return new java.nio.IntToByteBufferAdapter(slice_1);
		}

		private IntToByteBufferAdapter(java.nio.ByteBuffer byteBuffer) : base(byteBuffer.
			capacity() / libcore.io.SizeOf.INT)
		{
			this.byteBuffer = byteBuffer;
			this.byteBuffer.clear();
			this.effectiveDirectAddress = byteBuffer.effectiveDirectAddress;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer asReadOnlyBuffer()
		{
			java.nio.IntToByteBufferAdapter buf = new java.nio.IntToByteBufferAdapter(byteBuffer
				.asReadOnlyBuffer());
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			buf.byteBuffer._order = byteBuffer._order;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer compact()
		{
			if (byteBuffer.isReadOnly())
			{
				throw new java.nio.ReadOnlyBufferException();
			}
			byteBuffer.limit(_limit * libcore.io.SizeOf.INT);
			byteBuffer.position(_position * libcore.io.SizeOf.INT);
			byteBuffer.compact();
			byteBuffer.clear();
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer duplicate()
		{
			java.nio.ByteBuffer bb = byteBuffer.duplicate().order(byteBuffer.order());
			java.nio.IntToByteBufferAdapter buf = new java.nio.IntToByteBufferAdapter(bb);
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override int get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return byteBuffer.getInt(_position++ * libcore.io.SizeOf.INT);
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override int get(int index)
		{
			checkIndex(index);
			return byteBuffer.getInt(index * libcore.io.SizeOf.INT);
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer get(int[] dst, int dstOffset, int intCount)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.INT);
			byteBuffer.position(_position * libcore.io.SizeOf.INT);
			if (byteBuffer is java.nio.DirectByteBuffer)
			{
				((java.nio.DirectByteBuffer)byteBuffer).get(dst, dstOffset, intCount);
			}
			else
			{
				((java.nio.HeapByteBuffer)byteBuffer).get(dst, dstOffset, intCount);
			}
			this._position += intCount;
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

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.ByteOrder order()
		{
			return byteBuffer.order();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override int[] protectedArray()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			byteBuffer.putInt(_position++ * libcore.io.SizeOf.INT, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int index, int c)
		{
			checkIndex(index);
			byteBuffer.putInt(index * libcore.io.SizeOf.INT, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer put(int[] src, int srcOffset, int intCount)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.INT);
			byteBuffer.position(_position * libcore.io.SizeOf.INT);
			if (byteBuffer is java.nio.ReadWriteDirectByteBuffer)
			{
				((java.nio.ReadWriteDirectByteBuffer)byteBuffer).put(src, srcOffset, intCount);
			}
			else
			{
				((java.nio.ReadWriteHeapByteBuffer)byteBuffer).put(src, srcOffset, intCount);
			}
			this._position += intCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.IntBuffer")]
		public override java.nio.IntBuffer slice()
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.INT);
			byteBuffer.position(_position * libcore.io.SizeOf.INT);
			java.nio.ByteBuffer bb = byteBuffer.slice().order(byteBuffer.order());
			java.nio.IntBuffer result = new java.nio.IntToByteBufferAdapter(bb);
			byteBuffer.clear();
			return result;
		}
	}
}
