using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class PipedInputStream : java.io.InputStream
	{
		[Sharpen.Stub]
		public PipedInputStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PipedInputStream(java.io.PipedOutputStream @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PipedInputStream(int pipeSize)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PipedInputStream(java.io.PipedOutputStream @out, int pipeSize) : this(pipeSize
			)
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

		[Sharpen.Stub]
		public virtual void connect(java.io.PipedOutputStream src)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void establishConnection()
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
		public override int read(byte[] bytes, int offset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void receive(int oneByte)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void done()
		{
			throw new System.NotImplementedException();
		}
	}
}
