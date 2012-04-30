using Sharpen;

namespace android.util
{
	[Sharpen.Stub]
	internal static class ReflectiveProperty
	{
		internal const string PREFIX_GET = "get";

		internal const string PREFIX_IS = "is";

		internal const string PREFIX_SET = "set";
	}

	[Sharpen.Stub]
	internal class ReflectiveProperty<T, V> : android.util.Property<T, V>
	{
		private System.Reflection.MethodInfo mSetter;

		private System.Reflection.MethodInfo mGetter;

		private System.Reflection.FieldInfo mField;

		[Sharpen.Stub]
		public ReflectiveProperty(System.Type propertyHolder, System.Type valueType, string
			 name) : base(valueType, name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool typesMatch(System.Type getterType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.util.Property")]
		public override void set(T @object, V value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.util.Property")]
		public override V get(T @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.util.Property")]
		public override bool isReadOnly()
		{
			throw new System.NotImplementedException();
		}
	}
}
