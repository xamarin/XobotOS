using Sharpen;

namespace java.nio
{
	[Sharpen.Stub]
	internal sealed class IoVec
	{
		internal enum Direction
		{
			READV,
			WRITEV
		}

		[Sharpen.Stub]
		internal IoVec(java.nio.ByteBuffer[] byteBuffers, int offset, int bufferCount, java.nio.IoVec
			.Direction direction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal int init()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal int doTransfer(java.io.FileDescriptor fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void didTransfer(int byteCount)
		{
			throw new System.NotImplementedException();
		}
	}
}
