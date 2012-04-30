using Sharpen;

namespace java.nio
{
	/// <summary>This class wraps a byte buffer to be a char buffer.</summary>
	/// <remarks>
	/// This class wraps a byte buffer to be a char buffer.
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
	internal sealed class CharToByteBufferAdapter : java.nio.CharBuffer
	{
		private readonly java.nio.ByteBuffer byteBuffer;

		internal static java.nio.CharBuffer asCharBuffer(java.nio.ByteBuffer byteBuffer)
		{
			java.nio.ByteBuffer slice_1 = byteBuffer.slice();
			slice_1.order(byteBuffer.order());
			return new java.nio.CharToByteBufferAdapter(slice_1);
		}

		private CharToByteBufferAdapter(java.nio.ByteBuffer byteBuffer) : base(byteBuffer
			.capacity() / libcore.io.SizeOf.CHAR)
		{
			this.byteBuffer = byteBuffer;
			this.byteBuffer.clear();
			this.effectiveDirectAddress = byteBuffer.effectiveDirectAddress;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer asReadOnlyBuffer()
		{
			java.nio.CharToByteBufferAdapter buf = new java.nio.CharToByteBufferAdapter(byteBuffer
				.asReadOnlyBuffer());
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			buf.byteBuffer._order = byteBuffer._order;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer compact()
		{
			if (byteBuffer.isReadOnly())
			{
				throw new java.nio.ReadOnlyBufferException();
			}
			byteBuffer.limit(_limit * libcore.io.SizeOf.CHAR);
			byteBuffer.position(_position * libcore.io.SizeOf.CHAR);
			byteBuffer.compact();
			byteBuffer.clear();
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer duplicate()
		{
			java.nio.ByteBuffer bb = byteBuffer.duplicate().order(byteBuffer.order());
			java.nio.CharToByteBufferAdapter buf = new java.nio.CharToByteBufferAdapter(bb);
			buf._limit = _limit;
			buf._position = _position;
			buf._mark = _mark;
			return buf;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override char get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return byteBuffer.getChar(_position++ * libcore.io.SizeOf.CHAR);
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override char get(int index)
		{
			checkIndex(index);
			return byteBuffer.getChar(index * libcore.io.SizeOf.CHAR);
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer get(char[] dst, int dstOffset, int charCount)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.CHAR);
			byteBuffer.position(_position * libcore.io.SizeOf.CHAR);
			if (byteBuffer is java.nio.DirectByteBuffer)
			{
				((java.nio.DirectByteBuffer)byteBuffer).get(dst, dstOffset, charCount);
			}
			else
			{
				((java.nio.HeapByteBuffer)byteBuffer).get(dst, dstOffset, charCount);
			}
			this._position += charCount;
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

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.ByteOrder order()
		{
			return byteBuffer.order();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override char[] protectedArray()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(char c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			byteBuffer.putChar(_position++ * libcore.io.SizeOf.CHAR, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(int index, char c)
		{
			checkIndex(index);
			byteBuffer.putChar(index * libcore.io.SizeOf.CHAR, c);
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(char[] src, int srcOffset, int charCount)
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.CHAR);
			byteBuffer.position(_position * libcore.io.SizeOf.CHAR);
			if (byteBuffer is java.nio.ReadWriteDirectByteBuffer)
			{
				((java.nio.ReadWriteDirectByteBuffer)byteBuffer).put(src, srcOffset, charCount);
			}
			else
			{
				((java.nio.ReadWriteHeapByteBuffer)byteBuffer).put(src, srcOffset, charCount);
			}
			this._position += charCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer slice()
		{
			byteBuffer.limit(_limit * libcore.io.SizeOf.CHAR);
			byteBuffer.position(_position * libcore.io.SizeOf.CHAR);
			java.nio.ByteBuffer bb = byteBuffer.slice().order(byteBuffer.order());
			java.nio.CharBuffer result = new java.nio.CharToByteBufferAdapter(bb);
			byteBuffer.clear();
			return result;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.lang.CharSequence SubSequence(int start, int end)
		{
			checkStartEndRemaining(start, end);
			java.nio.CharBuffer result = duplicate();
			result.limit(_position + end);
			result.position(_position + start);
			return result;
		}
	}
}
