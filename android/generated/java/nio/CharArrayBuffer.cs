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
	/// CharArrayBuffer implements all the shared readonly methods and is extended by
	/// the other two classes.
	/// </p>
	/// <p>
	/// All methods are marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class CharArrayBuffer : java.nio.CharBuffer
	{
		protected internal readonly char[] backingArray;

		protected internal readonly int offset;

		internal CharArrayBuffer(char[] array_1) : this(array_1.Length, array_1, 0)
		{
		}

		internal CharArrayBuffer(int capacity_1) : this(capacity_1, new char[capacity_1], 
			0)
		{
		}

		internal CharArrayBuffer(int capacity_1, char[] backingArray, int offset) : base(
			capacity_1)
		{
			this.backingArray = backingArray;
			this.offset = offset;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override char get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return backingArray[offset + _position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override char get(int index)
		{
			checkIndex(index);
			return backingArray[offset + index];
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override java.nio.CharBuffer get(char[] dst, int srcOffset, int charCount
			)
		{
			if (charCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			System.Array.Copy(backingArray, offset + _position, dst, srcOffset, charCount);
			_position += charCount;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public sealed override bool isDirect()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override java.nio.ByteOrder order()
		{
			return java.nio.ByteOrder.nativeOrder();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override java.lang.CharSequence SubSequence(int start, int end)
		{
			checkStartEndRemaining(start, end);
			java.nio.CharBuffer result = duplicate();
			result.limit(_position + end);
			result.position(_position + start);
			return result;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override string ToString()
		{
			return Sharpen.StringHelper.CopyValueOf(backingArray, offset + _position, remaining
				());
		}
	}
}
