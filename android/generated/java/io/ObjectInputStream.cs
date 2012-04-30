using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class ObjectInputStream : java.io.InputStream, java.io.ObjectInput, java.io.ObjectStreamConstants
	{
		static ObjectInputStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class InputValidationDesc
		{
		}

		[Sharpen.Stub]
		public abstract class GetField
		{
			[Sharpen.Stub]
			public abstract java.io.ObjectStreamClass getObjectStreamClass();

			[Sharpen.Stub]
			public abstract bool defaulted(string name);

			[Sharpen.Stub]
			public abstract bool get(string name, bool defaultValue);

			[Sharpen.Stub]
			public abstract char get(string name, char defaultValue);

			[Sharpen.Stub]
			public abstract byte get(string name, byte defaultValue);

			[Sharpen.Stub]
			public abstract short get(string name, short defaultValue);

			[Sharpen.Stub]
			public abstract int get(string name, int defaultValue);

			[Sharpen.Stub]
			public abstract long get(string name, long defaultValue);

			[Sharpen.Stub]
			public abstract float get(string name, float defaultValue);

			[Sharpen.Stub]
			public abstract double get(string name, double defaultValue);

			[Sharpen.Stub]
			public abstract object get(string name, object defaultValue);
		}

		[Sharpen.Stub]
		protected internal ObjectInputStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ObjectInputStream(java.io.InputStream input)
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
		public virtual void defaultReadObject()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool enableResolveObject(bool enable)
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
		public override int read(byte[] buffer, int offset, int length)
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
		public virtual java.io.ObjectInputStream.GetField readFields()
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
		[System.ObsoleteAttribute(@"Use BufferedReader")]
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
		protected internal virtual java.io.ObjectStreamClass readClassDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual System.Type resolveProxyClass(string[] interfaceNames)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.ObjectInput")]
		public virtual object readObject()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object readUnshared()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual object readObjectOverride()
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
		protected internal virtual void readStreamHeader()
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
		public virtual void registerValidation(java.io.ObjectInputValidation @object, int
			 priority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual System.Type resolveClass(java.io.ObjectStreamClass osClass
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual object resolveObject(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataInput")]
		public virtual int skipBytes(int length)
		{
			throw new System.NotImplementedException();
		}
	}
}
