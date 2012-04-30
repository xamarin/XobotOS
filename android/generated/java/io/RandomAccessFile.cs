using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class RandomAccessFile : java.io.DataInput, java.io.DataOutput, java.io.Closeable
	{
		[Sharpen.Stub]
		public RandomAccessFile(java.io.File file, string mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public RandomAccessFile(string fileName, string mode) : this(new java.io.File(fileName
			), mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.lang.AutoCloseable")]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		~RandomAccessFile()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.nio.channels.FileChannel getChannel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.io.FileDescriptor getFD()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getFilePointer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long length()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int read()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int read(byte[] buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int read(byte[] buffer, int byteOffset, int byteCount)
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
		public virtual void seek(long offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLength(long newLength)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual int skipBytes(int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void write(byte[] buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void write(byte[] buffer, int byteOffset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void write(int oneByte)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeBoolean(bool val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeByte(int val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeBytes(string str)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeChar(int val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeChars(string str)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeDouble(double val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeFloat(float val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeInt(int val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeLong(long val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeShort(int val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeUTF(string str)
		{
			throw new System.NotImplementedException();
		}
	}
}
