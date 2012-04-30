using Sharpen;

namespace java.nio
{
	/// <summary>This class wraps a char sequence to be a char buffer.</summary>
	/// <remarks>
	/// This class wraps a char sequence to be a char buffer.
	/// <p>
	/// Implementation notice:
	/// <ul>
	/// <li>Char sequence based buffer is always readonly.</li>
	/// </ul>
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class CharSequenceAdapter : java.nio.CharBuffer
	{
		internal static java.nio.CharSequenceAdapter copy(java.nio.CharSequenceAdapter other
			)
		{
			java.nio.CharSequenceAdapter buf = new java.nio.CharSequenceAdapter(other.sequence
				);
			buf._limit = other._limit;
			buf._position = other._position;
			buf._mark = other._mark;
			return buf;
		}

		internal readonly java.lang.CharSequence sequence;

		internal CharSequenceAdapter(java.lang.CharSequence chseq) : base(chseq.Length)
		{
			sequence = chseq;
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
			return copy(this);
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override char get()
		{
			if (_position == _limit)
			{
				throw new java.nio.BufferUnderflowException();
			}
			return sequence[_position++];
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override char get(int index)
		{
			checkIndex(index);
			return sequence[index];
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public sealed override java.nio.CharBuffer get(char[] dst, int dstOffset, int charCount
			)
		{
			java.util.Arrays.checkOffsetAndCount(dst.Length, dstOffset, charCount);
			if (charCount > remaining())
			{
				throw new java.nio.BufferUnderflowException();
			}
			int newPosition = _position + charCount;
			Sharpen.StringHelper.GetCharsForString(sequence.ToString(), _position, newPosition
				, dst, dstOffset);
			_position = newPosition;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isDirect()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.ByteOrder order()
		{
			return java.nio.ByteOrder.nativeOrder();
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
		public override java.nio.CharBuffer put(string src, int start, int end)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.nio.CharBuffer slice()
		{
			return new java.nio.CharSequenceAdapter(sequence.SubSequence(_position, _limit));
		}

		[Sharpen.OverridesMethod(@"java.nio.CharBuffer")]
		public override java.lang.CharSequence SubSequence(int start, int end)
		{
			checkStartEndRemaining(start, end);
			java.nio.CharSequenceAdapter result = copy(this);
			result._position = _position + start;
			result._limit = _position + end;
			return result;
		}
	}
}
