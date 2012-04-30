using Sharpen;

namespace java.nio
{
	[Sharpen.Stub]
	public abstract class MappedByteBuffer : java.nio.ByteBuffer
	{
		[Sharpen.Stub]
		internal MappedByteBuffer(java.nio.ByteBuffer directBuffer) : base(directBuffer._capacity
			, directBuffer.block)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal MappedByteBuffer(java.nio.MemoryBlock block, int capacity_1, int offset, 
			java.nio.channels.FileChannel.MapMode mapMode) : base(capacity_1, block)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isLoaded()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.nio.MappedByteBuffer load()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.nio.MappedByteBuffer force()
		{
			throw new System.NotImplementedException();
		}
	}
}
