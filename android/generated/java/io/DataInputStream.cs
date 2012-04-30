using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class DataInputStream : java.io.FilterInputStream, java.io.DataInput
	{
		[Sharpen.Stub]
		public DataInputStream(java.io.InputStream @in) : base(@in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public sealed override int read(byte[] buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.InputStream")]
		public sealed override int read(byte[] buffer, int offset, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual bool readBoolean()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual byte readByte()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual char readChar()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual double readDouble()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual float readFloat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual void readFully(byte[] dst)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual void readFully(byte[] dst, int offset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual int readInt()
		{
			throw new System.NotImplementedException();
		}

		[System.Obsolete]
		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual string readLine()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual long readLong()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual short readShort()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual int readUnsignedByte()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual int readUnsignedShort()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual string readUTF()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual string decodeUTF(int utfSize)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string readUTF(java.io.DataInput @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual int skipBytes(int count)
		{
			throw new System.NotImplementedException();
		}
	}
}
