using System;
using System.Runtime.InteropServices;

namespace Sharpen
{
	public class StubAttribute : System.Attribute
	{ }
	
	public class NakedStubAttribute : System.Attribute
	{ }
	
	public class EditedStubAttribute : System.Attribute
	{ }
	
	public class ProxyAttribute : System.Attribute
	{ }

	public class SharpenedAttribute : System.Attribute
	{ }

	public class NativeStubAttribute : System.Attribute
	{ }

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class OverridesMethodAttribute : System.Attribute
	{
		public OverridesMethodAttribute(string name)
		{
			this.Name = name;
		}

		public readonly string Name;
	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class ImplementsInterfaceAttribute : System.Attribute
	{
		public ImplementsInterfaceAttribute(string iface)
		{
			this.Interface = iface;
		}

		public readonly string Interface;
	}

	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class Comment : System.Attribute
	{
		public Comment(string name)
		{
			this.Name = name;
		}

		public readonly string Name;
	}

	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class UsesStub : System.Attribute
	{
		public UsesStub(string name)
		{
			this.Name = name;
		}

		public readonly string Name;
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class MarshalHelper : System.Attribute
	{
		public MarshalHelper(string name)
		{
			this.NativeType = name;
		}

		public readonly string NativeType;
	}

}

