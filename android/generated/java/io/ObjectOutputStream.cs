using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class ObjectOutputStream : java.io.OutputStream, java.io.ObjectOutput, java.io.ObjectStreamConstants
	{
		[Sharpen.Stub]
		public abstract class PutField
		{
			[Sharpen.Stub]
			public abstract void put(string name, bool value);

			[Sharpen.Stub]
			public abstract void put(string name, char value);

			[Sharpen.Stub]
			public abstract void put(string name, byte value);

			[Sharpen.Stub]
			public abstract void put(string name, short value);

			[Sharpen.Stub]
			public abstract void put(string name, int value);

			[Sharpen.Stub]
			public abstract void put(string name, long value);

			[Sharpen.Stub]
			public abstract void put(string name, float value);

			[Sharpen.Stub]
			public abstract void put(string name, double value);

			[Sharpen.Stub]
			public abstract void put(string name, object value);

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"This method is unsafe and may corrupt the target stream. Use ObjectOutputStream#writeFields() instead."
				)]
			public abstract void write(java.io.ObjectOutput @out);
		}

		[Sharpen.Stub]
		protected internal ObjectOutputStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ObjectOutputStream(java.io.OutputStream output)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void annotateClass<_T0>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void annotateProxyClass<_T0>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void defaultWriteObject()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void drain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool enableReplaceObject(bool enable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void flush()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.io.ObjectOutputStream.PutField putFields()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual object replaceObject(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void useProtocolVersion(int version)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(byte[] buffer, int offset, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeBoolean(bool value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeByte(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeBytes(string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeChar(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeChars(string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeDouble(double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void writeFields()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeFloat(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeInt(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeLong(long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void writeClassDescriptor(java.io.ObjectStreamClass classDesc
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.ObjectOutput")]
		public virtual void writeObject(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void writeUnshared(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void writeObjectOverride(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeShort(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void writeStreamHeader()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.io.DataOutput")]
		public virtual void writeUTF(string value)
		{
			throw new System.NotImplementedException();
		}
	}
}
