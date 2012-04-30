using Sharpen;

namespace java.nio
{
	/// <summary>
	/// Serves as the root of other byte buffer impl classes, implements common
	/// methods that can be shared by child classes.
	/// </summary>
	/// <remarks>
	/// Serves as the root of other byte buffer impl classes, implements common
	/// methods that can be shared by child classes.
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class BaseByteBuffer : java.nio.ByteBuffer
	{
		internal BaseByteBuffer(int capacity_1, java.nio.MemoryBlock block) : base(capacity_1
			, block)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override java.nio.CharBuffer asCharBuffer()
		{
			return java.nio.CharToByteBufferAdapter.asCharBuffer(this);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override java.nio.DoubleBuffer asDoubleBuffer()
		{
			return java.nio.DoubleToByteBufferAdapter.asDoubleBuffer(this);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override java.nio.FloatBuffer asFloatBuffer()
		{
			return java.nio.FloatToByteBufferAdapter.asFloatBuffer(this);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override java.nio.IntBuffer asIntBuffer()
		{
			return java.nio.IntToByteBufferAdapter.asIntBuffer(this);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override java.nio.LongBuffer asLongBuffer()
		{
			return java.nio.LongToByteBufferAdapter.asLongBuffer(this);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public sealed override java.nio.ShortBuffer asShortBuffer()
		{
			return java.nio.ShortToByteBufferAdapter.asShortBuffer(this);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override char getChar()
		{
			return (char)getShort();
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override char getChar(int index)
		{
			return (char)getShort(index);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putChar(char value)
		{
			return putShort((short)value);
		}

		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putChar(int index, char value)
		{
			return putShort(index, (short)value);
		}
	}
}
