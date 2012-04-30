using Sharpen;

namespace android.util
{
	/// <summary>
	/// An implementation of
	/// <see cref="Property{T, V}">Property&lt;T, V&gt;</see>
	/// to be used specifically with fields of type
	/// <code>int</code>. This type-specific subclass enables performance benefit by allowing
	/// calls to a
	/// <see cref="IntProperty{T}.set(object, int)">set()</see>
	/// function that takes the primitive
	/// <code>int</code> type and avoids autoboxing and other overhead associated with the
	/// <code>Integer</code> class.
	/// </summary>
	/// <?></?>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public abstract class IntProperty<T> : android.util.Property<T, int>
	{
		public IntProperty(string name) : base(typeof(int), name)
		{
		}

		/// <summary>
		/// A type-specific override of the
		/// <see cref="IntProperty{T}.set(object, int)">IntProperty&lt;T&gt;.set(object, int)
		/// 	</see>
		/// that is faster when dealing
		/// with fields of type <code>int</code>.
		/// </summary>
		public abstract void setValue(T @object, int value);

		[Sharpen.OverridesMethod(@"android.util.Property")]
		public sealed override void set(T @object, int value)
		{
			set(@object, value);
		}
	}
}
