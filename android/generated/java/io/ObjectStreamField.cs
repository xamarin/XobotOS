using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public class ObjectStreamField : java.lang.Comparable<object>
	{
		[Sharpen.Stub]
		public ObjectStreamField(string name, System.Type cl)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ObjectStreamField(string name, System.Type cl, bool unshared)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ObjectStreamField(string signature, string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(object o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getOffset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual System.Type getTypeInternal()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.Type getType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual char getTypeCode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getTypeString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPrimitive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool writeField(java.io.DataOutputStream @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void setOffset(int newValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void resolve(java.lang.ClassLoader loader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isUnshared()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setUnshared(bool unshared)
		{
			throw new System.NotImplementedException();
		}
	}
}
