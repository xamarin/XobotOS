using Sharpen;

namespace java.nio
{
	/// <summary>This class wraps a byte buffer to be a float buffer.</summary>
	/// <remarks>
	/// This class wraps a byte buffer to be a float buffer.
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
	internal sealed class FloatToByteBufferAdapter : java.nio.FloatBuffer
	{
		private readonly java.nio.ByteBuffer byteBuffer;

		internal static java.nio.FloatBuffer asFloatBuffer(java.nio.ByteBuffer byteBuffer
			)
		{
			java.nio.ByteBuffer slice_1 = byteBuffer.slice();
			slice_1.order(byteBuffer.order());
			return new java.nio.FloatToByteBufferAdapter(slice_1);
		}

		internal FloatToByteBufferAdapter(java.nio.ByteBuffer byteBuffer) : base(byteBuffer
			.capacity() / libcore.io.SizeOf.FLOAT)
		{
			this.byteBuffer = byteBuffer;
			this.byteBuffer.clear();
			this.effectiveDirectAddress = byteBuffer.effectiveDirectAddress;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer asReadOnlyBuffer()
		{
			java.nio.FloatToByteBufferAdapter buf = new java.nio.FloatToByteBufferAdapter(byteBuffer
				.asReadOnlyBuffer());
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			buf.byteBuffer._order = byteBuffer._order;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer compact()
		{
			if (byteBuffer.isReadOnly())
			{
				throw new java.nio.ReadOnlyBufferException();
			}
			byteBuffer.limit(_limit * libcore.io.SizeOf.FLOAT);
			byteBuffer.position(_position * libcore.io.SizeOf.FLOAT);
			byteBuffer.compact();
			byteBuffer.clear();
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer duplicate()
		{
			java.nio.ByteBuffer bb = byteBuffer.duplicate().order(byteBuffer.order());
			java.nio.FloatToByteBufferAdapter buf = new java.nio.FloatToByteBufferAdapter(bb);
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override float get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return byteBuffer.getFloat(_position++ * libcore.io.SizeOf.FLOAT);
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override float get(int index)
		{
			checkIndex(index);
			return byteBuffer.getFloat(index * libcore.io.SizeOf.FLOAT);
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer get(float[] dst, int dstOffset, int floatCount
			)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.FLOAT);
			byteBuffer.position(_position * libcore.io.SizeOf.FLOAT);
			if (byteBuffer is java.nio.DirectByteBuffer)
			{
				((java.nio.DirectByteBuffer)byteBuffer).get(dst, dstOffset, floatCount);
			}
			else
			{
				((java.nio.HeapByteBuffer)byteBuffer).get(dst, dstOffset, floatCount);
			}
			this._position += floatCount;
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

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.ByteOrder order()
		{
			return byteBuffer.order();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override float[] protectedArray()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(float c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			byteBuffer.putFloat(_position++ * libcore.io.SizeOf.FLOAT, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(int index, float c)
		{
			checkIndex(index);
			byteBuffer.putFloat(index * libcore.io.SizeOf.FLOAT, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(float[] src, int srcOffset, int floatCount
			)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.FLOAT);
			byteBuffer.position(_position * libcore.io.SizeOf.FLOAT);
			if (byteBuffer is java.nio.ReadWriteDirectByteBuffer)
			{
				((java.nio.ReadWriteDirectByteBuffer)byteBuffer).put(src, srcOffset, floatCount);
			}
			else
			{
				((java.nio.ReadWriteHeapByteBuffer)byteBuffer).put(src, srcOffset, floatCount);
			}
			this._position += floatCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer slice()
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.FLOAT);
			byteBuffer.position(_position * libcore.io.SizeOf.FLOAT);
			java.nio.ByteBuffer bb = byteBuffer.slice().order(byteBuffer.order());
			java.nio.FloatBuffer result = new java.nio.FloatToByteBufferAdapter(bb);
			byteBuffer.clear();
			return result;
		}
	}
}
