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
	/// ReadOnlyCharArrayBuffer extends CharArrayBuffer with all the write methods
	/// throwing read only exception.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadOnlyCharArrayBuffer : java.nio.CharArrayBuffer
	{
		internal static java.nio.ReadOnlyCharArrayBuffer copy(java.nio.CharArrayBuffer other
			, int markOfOther)
		{
			java.nio.ReadOnlyCharArrayBuffer buf = new java.nio.ReadOnlyCharArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadOnlyCharArrayBuffer(int capacity_1, char[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer asReadOnlyBuffer()
		{
			return duplicate();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer compact()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override char[] protectedArray()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(char c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(int index, char c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override java.nio.CharBuffer put(char[] src, int srcOffset, int charCount
			)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override java.nio.CharBuffer put(java.nio.CharBuffer src)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer put(string src, int start, int end)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer slice()
		{
			return new java.nio.ReadOnlyCharArrayBuffer(remaining(), backingArray, offset + _position
				);
		}
	}
}
