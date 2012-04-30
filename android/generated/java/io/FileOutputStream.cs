using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class FileOutputStream : java.io.OutputStream, java.io.Closeable
	{
		[Sharpen.Stub]
		public FileOutputStream(java.io.File file) : this(file, false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FileOutputStream(java.io.File file, bool append)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FileOutputStream(java.io.FileDescriptor fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FileOutputStream(string path) : this(path, false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FileOutputStream(string path, bool append) : this(new java.io.File(path), 
			append)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		~FileOutputStream()
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
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(byte[] buffer, int byteOffset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(int oneByte)
		{
			throw new System.NotImplementedException();
		}
	}
}
