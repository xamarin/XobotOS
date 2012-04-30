using Sharpen;

namespace java.nio
{
	/// <summary>
	/// CharArrayBuffer, ReadWriteCharArrayBuffer and ReadOnlyCharArrayBuffer compose
	/// the implementation of array based char buffers.
	/// </summary>
	/// <remarks>
	/// CharArrayBuffer, ReadWriteCharArrayBuffer and ReadOnlyCharArrayBuffer compose
	/// the implementation of array based char buffers.
	/// <p>
	/// ReadWriteCharArrayBuffer extends CharArrayBuffer with all the write methods.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadWriteCharArrayBuffer : java.nio.CharArrayBuffer
	{
		internal static java.nio.ReadWriteCharArrayBuffer copy(java.nio.CharArrayBuffer other
			, int markOfOther)
		{
			java.nio.ReadWriteCharArrayBuffer buf = new java.nio.ReadWriteCharArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadWriteCharArrayBuffer(char[] array_1) : base(array_1)
		{
		}

		internal ReadWriteCharArrayBuffer(int capacity_1) : base(capacity_1)
		{
		}

		internal ReadWriteCharArrayBuffer(int capacity_1, char[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer asReadOnlyBuffer()
		{
			return java.nio.ReadOnlyCharArrayBuffer.copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer compact()
		{
			System.Array.Copy(backingArray, _position + offset, backingArray, offset, remaining
				());
			_position = _limit - _position;
			_limit = _capacity;
			_mark = UNSET_MARK;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override char[] protectedArray()
		{
			return backingArray;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override int protectedArrayOffset()
		{
			return offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override bool protectedHasArray()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(char c)
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferOverflowException();
			}
			backingArray[offset + _position++] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(int index, char c)
		{
			checkIndex(index);
			backingArray[offset + index] = c;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(char[] src, int srcOffset, int charCount)
		{
			if (charCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			System.Array.Copy(src, srcOffset, backingArray, offset + _position, charCount);
			_position += charCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer slice()
		{
			return new java.nio.ReadWriteCharArrayBuffer(remaining(), backingArray, offset + 
				_position);
		}
	}
}
