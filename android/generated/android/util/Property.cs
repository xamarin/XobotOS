using Sharpen;

namespace android.util
{
	/// <summary>
	/// A property is an abstraction that can be used to represent a <emb>mutable</em> value that is held
	/// in a <em>host</em> object.
	/// </summary>
	/// <remarks>
	/// A property is an abstraction that can be used to represent a <emb>mutable</em> value that is held
	/// in a <em>host</em> object. The Property's
	/// <see cref="Property{T, V}.set(object, object)">Property&lt;T, V&gt;.set(object, object)
	/// 	</see>
	/// or
	/// <see cref="Property{T, V}.get(object)">Property&lt;T, V&gt;.get(object)</see>
	/// methods can be implemented in terms of the private fields of the host object, or via "setter" and
	/// "getter" methods or by some other mechanism, as appropriate.
	/// </remarks>
	/// <?></?>
	/// <?></?>
	[Sharpen.Sharpened]
	public abstract class Property<T, V>
	{
		private readonly string mName;

		private readonly System.Type mType;

		/// <summary>
		/// This factory method creates and returns a Property given the <code>class</code> and
		/// <code>name</code> parameters, where the <code>"name"</code> parameter represents either:
		/// <ul>
		/// <li>a public <code>getName()</code> method on the class which takes no arguments, plus an
		/// optional public <code>setName()</code> method which takes a value of the same type
		/// returned by <code>getName()</code>
		/// <li>a public <code>isName()</code> method on the class which takes no arguments, plus an
		/// optional public <code>setName()</code> method which takes a value of the same type
		/// returned by <code>isName()</code>
		/// <li>a public <code>name</code> field on the class
		/// </ul>
		/// <p>If either of the get/is method alternatives is found on the class, but an appropriate
		/// <code>setName()</code> method is not found, the <code>Property</code> will be
		/// <see cref="Property{T, V}.isReadOnly()">readOnly</see>
		/// . Calling the
		/// <see cref="Property{T, V}.set(object, object)">Property&lt;T, V&gt;.set(object, object)
		/// 	</see>
		/// method on such
		/// a property is allowed, but will have no effect.</p>
		/// <p>If neither the methods nor the field are found on the class a
		/// <see cref="NoSuchPropertyException">NoSuchPropertyException</see>
		/// exception will be thrown.</p>
		/// </summary>
		public static android.util.Property<T, V> of<T, V>(string name)
		{
			System.Type hostType = typeof(T);
			System.Type valueType = typeof(V);
			return new android.util.ReflectiveProperty<T, V>(hostType, valueType, name);
		}

		/// <summary>
		/// A constructor that takes an identifying name and
		/// <see cref="Property{T, V}.getType()">type</see>
		/// for the property.
		/// </summary>
		public Property(System.Type type, string name)
		{
			mName = name;
			mType = type;
		}

		/// <summary>
		/// Returns true if the
		/// <see cref="Property{T, V}.set(object, object)">Property&lt;T, V&gt;.set(object, object)
		/// 	</see>
		/// method does not set the value on the target
		/// object (in which case the
		/// <see cref="Property{T, V}.set(object, object)">set()</see>
		/// method should throw a
		/// <see cref="NoSuchPropertyException">NoSuchPropertyException</see>
		/// exception). This may happen if the Property wraps functionality that
		/// allows querying the underlying value but not setting it. For example, the
		/// <see cref="Property{T, V}.of{T, V}(System.Type{T}, System.Type{T}, string)">Property&lt;T, V&gt;.of&lt;T, V&gt;(System.Type&lt;T&gt;, System.Type&lt;T&gt;, string)
		/// 	</see>
		/// factory method may return a Property with name "foo" for an object that has
		/// only a <code>getFoo()</code> or <code>isFoo()</code> method, but no matching
		/// <code>setFoo()</code> method.
		/// </summary>
		public virtual bool isReadOnly()
		{
			return false;
		}

		/// <summary>Sets the value on <code>object</code> which this property represents.</summary>
		/// <remarks>
		/// Sets the value on <code>object</code> which this property represents. If the method is unable
		/// to set the value on the target object it will throw an
		/// <see cref="System.NotSupportedException">System.NotSupportedException</see>
		/// exception.
		/// </remarks>
		public virtual void set(T @object, V value)
		{
			throw new System.NotSupportedException("Property " + getName() + " is read-only");
		}

		/// <summary>Returns the current value that this property represents on the given <code>object</code>.
		/// 	</summary>
		/// <remarks>Returns the current value that this property represents on the given <code>object</code>.
		/// 	</remarks>
		public abstract V get(T @object);

		/// <summary>Returns the name for this property.</summary>
		/// <remarks>Returns the name for this property.</remarks>
		public virtual string getName()
		{
			return mName;
		}

		/// <summary>Returns the type for this property.</summary>
		/// <remarks>Returns the type for this property.</remarks>
		public virtual System.Type getType()
		{
			return mType;
		}
	}
}
