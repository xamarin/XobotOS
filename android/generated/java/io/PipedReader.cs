using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class PipedReader : java.io.Reader
	{
		[Sharpen.Stub]
		public PipedReader()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PipedReader(java.io.PipedWriter @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PipedReader(int pipeSize)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PipedReader(java.io.PipedWriter @out, int pipeSize) : this(pipeSize)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void connect(java.io.PipedWriter src)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void establishConnection()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override int read(char[] buffer, int offset, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.Reader")]
		public override bool ready()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void receive(char oneChar)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void receive(char[] chars, int offset, int count)
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
