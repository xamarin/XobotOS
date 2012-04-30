using Sharpen;

namespace java.util
{
	/// <summary>LinkedHashSet is a variant of HashSet.</summary>
	/// <remarks>
	/// LinkedHashSet is a variant of HashSet. Its entries are kept in a
	/// doubly-linked list. The iteration order is the order in which entries were
	/// inserted.
	/// <p>
	/// Null elements are allowed, and all the optional Set operations are supported.
	/// <p>
	/// Like HashSet, LinkedHashSet is not thread safe, so access by multiple threads
	/// must be synchronized by an external mechanism such as
	/// <see cref="Collections.synchronizedSet{E}(Set{E})">Collections.synchronizedSet&lt;E&gt;(Set&lt;E&gt;)
	/// 	</see>
	/// .
	/// </remarks>
	/// <since>1.4</since>
	[Sharpen.Sharpened]
	public static class LinkedHashSet
	{
		internal const long serialVersionUID = -2851667679971038690L;
	}

	/// <summary>LinkedHashSet is a variant of HashSet.</summary>
	/// <remarks>
	/// LinkedHashSet is a variant of HashSet. Its entries are kept in a
	/// doubly-linked list. The iteration order is the order in which entries were
	/// inserted.
	/// <p>
	/// Null elements are allowed, and all the optional Set operations are supported.
	/// <p>
	/// Like HashSet, LinkedHashSet is not thread safe, so access by multiple threads
	/// must be synchronized by an external mechanism such as
	/// <see cref="Collections.synchronizedSet{E}(Set{E})">Collections.synchronizedSet&lt;E&gt;(Set&lt;E&gt;)
	/// 	</see>
	/// .
	/// </remarks>
	/// <since>1.4</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class LinkedHashSet<E> : java.util.HashSet<E>, java.util.Set<E>, System.ICloneable
	{
		/// <summary>
		/// Constructs a new empty instance of
		/// <code>LinkedHashSet</code>
		/// .
		/// </summary>
		public LinkedHashSet() : base(new java.util.LinkedHashMap<E, java.util.HashSet<E>
			>())
		{
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>LinkedHashSet</code>
		/// with the specified
		/// capacity.
		/// </summary>
		/// <param name="capacity">
		/// the initial capacity of this
		/// <code>LinkedHashSet</code>
		/// .
		/// </param>
		public LinkedHashSet(int capacity) : base(new java.util.LinkedHashMap<E, java.util.HashSet
			<E>>(capacity))
		{
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>LinkedHashSet</code>
		/// with the specified
		/// capacity and load factor.
		/// </summary>
		/// <param name="capacity">the initial capacity.</param>
		/// <param name="loadFactor">the initial load factor.</param>
		public LinkedHashSet(int capacity, float loadFactor) : base(new java.util.LinkedHashMap
			<E, java.util.HashSet<E>>(capacity, loadFactor))
		{
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>LinkedHashSet</code>
		/// containing the unique
		/// elements in the specified collection.
		/// </summary>
		/// <param name="collection">the collection of elements to add.</param>
		public LinkedHashSet(java.util.Collection<E> collection) : base(new java.util.LinkedHashMap
			<E, java.util.HashSet<E>>(collection.size() < 6 ? 11 : collection.size() * 2))
		{
			foreach (E e in Sharpen.IterableProxy.Create(collection))
			{
				add(e);
			}
		}

		[Sharpen.OverridesMethod(@"java.util.HashSet")]
		internal override java.util.HashMap<E, java.util.HashSet<E>> createBackingMap(int
			 capacity, float loadFactor)
		{
			return new java.util.LinkedHashMap<E, java.util.HashSet<E>>(capacity, loadFactor);
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
