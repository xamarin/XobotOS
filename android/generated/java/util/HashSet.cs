using Sharpen;

namespace java.util
{
	/// <summary>HashSet is an implementation of a Set.</summary>
	/// <remarks>
	/// HashSet is an implementation of a Set. All optional operations (adding and
	/// removing) are supported. The elements can be any objects.
	/// </remarks>
	[Sharpen.Sharpened]
	public static class HashSet
	{
		internal const long serialVersionUID = -5024744406713321676L;
	}

	/// <summary>HashSet is an implementation of a Set.</summary>
	/// <remarks>
	/// HashSet is an implementation of a Set. All optional operations (adding and
	/// removing) are supported. The elements can be any objects.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class HashSet<E> : java.util.AbstractSet<E>, java.util.Set<E>, System.ICloneable
	{
		[System.NonSerialized]
		internal java.util.HashMap<E, java.util.HashSet<E>> backingMap;

		/// <summary>
		/// Constructs a new empty instance of
		/// <code>HashSet</code>
		/// .
		/// </summary>
		public HashSet() : this(new java.util.HashMap<E, java.util.HashSet<E>>())
		{
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>HashSet</code>
		/// with the specified capacity.
		/// </summary>
		/// <param name="capacity">
		/// the initial capacity of this
		/// <code>HashSet</code>
		/// .
		/// </param>
		public HashSet(int capacity) : this(new java.util.HashMap<E, java.util.HashSet<E>
			>(capacity))
		{
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>HashSet</code>
		/// with the specified capacity
		/// and load factor.
		/// </summary>
		/// <param name="capacity">the initial capacity.</param>
		/// <param name="loadFactor">the initial load factor.</param>
		public HashSet(int capacity, float loadFactor) : this(new java.util.HashMap<E, java.util.HashSet
			<E>>(capacity, loadFactor))
		{
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>HashSet</code>
		/// containing the unique
		/// elements in the specified collection.
		/// </summary>
		/// <param name="collection">the collection of elements to add.</param>
		public HashSet(java.util.Collection<E> collection) : this(new java.util.HashMap<E
			, java.util.HashSet<E>>(collection.size() < 6 ? 11 : collection.size() * 2))
		{
			foreach (E e in Sharpen.IterableProxy.Create(collection))
			{
				add(e);
			}
		}

		internal HashSet(java.util.HashMap<E, java.util.HashSet<E>> backingMap)
		{
			this.backingMap = backingMap;
		}

		/// <summary>
		/// Adds the specified object to this
		/// <code>HashSet</code>
		/// if not already present.
		/// </summary>
		/// <param name="object">the object to add.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// when this
		/// <code>HashSet</code>
		/// did not already contain
		/// the object,
		/// <code>false</code>
		/// otherwise
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool add(E @object)
		{
			return backingMap.put(@object, this) == null;
		}

		/// <summary>
		/// Removes all elements from this
		/// <code>HashSet</code>
		/// , leaving it empty.
		/// </summary>
		/// <seealso cref="HashSet{E}.isEmpty()">HashSet&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="HashSet{E}.size()">HashSet&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override void clear()
		{
			backingMap.clear();
		}

		/// <summary>
		/// Returns a new
		/// <code>HashSet</code>
		/// with the same elements and size as this
		/// <code>HashSet</code>
		/// .
		/// </summary>
		/// <returns>
		/// a shallow copy of this
		/// <code>HashSet</code>
		/// .
		/// </returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		public virtual object clone()
		{
			java.util.HashSet<E> clone_1 = (java.util.HashSet<E>)base.MemberwiseClone();
			clone_1.backingMap = (java.util.HashMap<E, java.util.HashSet<E>>)backingMap.clone
				();
			return clone_1;
		}

		/// <summary>
		/// Searches this
		/// <code>HashSet</code>
		/// for the specified object.
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>object</code>
		/// is an element of this
		/// <code>HashSet</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool contains(object @object)
		{
			return backingMap.containsKey(@object);
		}

		/// <summary>
		/// Returns true if this
		/// <code>HashSet</code>
		/// has no elements, false otherwise.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>HashSet</code>
		/// has no elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="HashSet{E}.size()">HashSet&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool isEmpty()
		{
			return backingMap.isEmpty();
		}

		/// <summary>
		/// Returns an Iterator on the elements of this
		/// <code>HashSet</code>
		/// .
		/// </summary>
		/// <returns>
		/// an Iterator on the elements of this
		/// <code>HashSet</code>
		/// .
		/// </returns>
		/// <seealso cref="Iterator{E}">Iterator&lt;E&gt;</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override java.util.Iterator<E> iterator()
		{
			return backingMap.keySet().iterator();
		}

		/// <summary>
		/// Removes the specified object from this
		/// <code>HashSet</code>
		/// .
		/// </summary>
		/// <param name="object">the object to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the object was removed,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool remove(object @object)
		{
			return backingMap.remove(@object) != null;
		}

		/// <summary>
		/// Returns the number of elements in this
		/// <code>HashSet</code>
		/// .
		/// </summary>
		/// <returns>
		/// the number of elements in this
		/// <code>HashSet</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override int size()
		{
			return backingMap.size();
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			stream.defaultWriteObject();
			stream.writeInt(backingMap.table.Length);
			stream.writeFloat(java.util.HashMap.DEFAULT_LOAD_FACTOR);
			stream.writeInt(size());
			foreach (E e in Sharpen.IterableProxy.Create(this))
			{
				stream.writeObject(e);
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream stream)
		{
			stream.defaultReadObject();
			int length = stream.readInt();
			float loadFactor = stream.readFloat();
			backingMap = createBackingMap(length, loadFactor);
			int elementCount = stream.readInt();
			{
				for (int i = elementCount; --i >= 0; )
				{
					E key = (E)stream.readObject();
					backingMap.put(key, this);
				}
			}
		}

		internal virtual java.util.HashMap<E, java.util.HashSet<E>> createBackingMap(int 
			capacity, float loadFactor)
		{
			return new java.util.HashMap<E, java.util.HashSet<E>>(capacity, loadFactor);
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
