using Sharpen;

namespace java.nio
{
	[Sharpen.Stub]
	internal sealed class ReadWriteDirectByteBuffer : java.nio.DirectByteBuffer
	{
		[Sharpen.Stub]
		internal static java.nio.ReadWriteDirectByteBuffer copy(java.nio.DirectByteBuffer
			 other, int markOfOther)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ReadWriteDirectByteBuffer(int capacity_1) : base(java.nio.MemoryBlock.allocate
			(capacity_1), capacity_1, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ReadWriteDirectByteBuffer(int address, int capacity_1) : base(java.nio.MemoryBlock
			.wrapFromJni(address, capacity_1), capacity_1, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ReadWriteDirectByteBuffer(java.nio.MemoryBlock block, int capacity_1, int
			 offset) : base(block, capacity_1, offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer asReadOnlyBuffer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer compact()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer duplicate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(byte value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(int index, byte value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer put(byte[] src, int srcOffset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void put(char[] src, int srcOffset, int charCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void put(double[] src, int srcOffset, int doubleCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void put(float[] src, int srcOffset, int floatCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void put(int[] src, int srcOffset, int intCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void put(long[] src, int srcOffset, int longCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void put(short[] src, int srcOffset, int shortCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putChar(char value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putChar(int index, char value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putDouble(double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putDouble(int index, double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putFloat(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putFloat(int index, float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putInt(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putInt(int index, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putLong(long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putLong(int index, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putShort(short value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer putShort(int index, short value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.nio.ByteBuffer")]
		public override java.nio.ByteBuffer slice()
		{
			throw new System.NotImplementedException();
		}
	}
}
