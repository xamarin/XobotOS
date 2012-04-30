using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class FileInputStream : java.io.InputStream, java.io.Closeable
	{
		[Sharpen.Stub]
		public FileInputStream(java.io.File file)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FileInputStream(java.io.FileDescriptor fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FileInputStream(string path) : this(new java.io.File(path))
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int available()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		~FileInputStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.nio.channels.FileChannel getChannel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.io.FileDescriptor getFD()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override int read(byte[] buffer, int byteOffset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public override long skip(long byteCount)
		{
			throw new System.NotImplementedException();
		}
	}
}
