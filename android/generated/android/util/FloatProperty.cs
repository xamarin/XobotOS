using Sharpen;

namespace android.util
{
	/// <summary>
	/// An implementation of
	/// <see cref="Property{T, V}">Property&lt;T, V&gt;</see>
	/// to be used specifically with fields of type
	/// <code>float</code>. This type-specific subclass enables performance benefit by allowing
	/// calls to a
	/// <see cref="FloatProperty{T}.set(object, float)">set()</see>
	/// function that takes the primitive
	/// <code>float</code> type and avoids autoboxing and other overhead associated with the
	/// <code>Float</code> class.
	/// </summary>
	/// <?></?>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public abstract class FloatProperty<T> : android.util.Property<T, float>
	{
		public FloatProperty(string name) : base(typeof(float), name)
		{
		}

		/// <summary>
		/// A type-specific override of the
		/// <see cref="FloatProperty{T}.set(object, float)">FloatProperty&lt;T&gt;.set(object, float)
		/// 	</see>
		/// that is faster when dealing
		/// with fields of type <code>float</code>.
		/// </summary>
		public abstract void setValue(T @object, float value);

		[Sharpen.OverridesMethod(@"android.util.Property")]
		public sealed override void set(T @object, float value)
		{
			setValue(@object, value);
		}
	}
}
