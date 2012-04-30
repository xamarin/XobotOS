using Sharpen;

namespace java.util
{
	/// <summary>TreeSet is an implementation of SortedSet.</summary>
	/// <remarks>
	/// TreeSet is an implementation of SortedSet. All optional operations (adding
	/// and removing) are supported. The elements can be any objects which are
	/// comparable to each other either using their natural order or a specified
	/// Comparator.
	/// </remarks>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public static partial class TreeSet
	{
		internal const long serialVersionUID = -2479143000061671589L;
	}

	/// <summary>TreeSet is an implementation of SortedSet.</summary>
	/// <remarks>
	/// TreeSet is an implementation of SortedSet. All optional operations (adding
	/// and removing) are supported. The elements can be any objects which are
	/// comparable to each other either using their natural order or a specified
	/// Comparator.
	/// </remarks>
	/// <since>1.2</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public partial class TreeSet<E> : java.util.AbstractSet<E>, java.util.NavigableSet
		<E>, System.ICloneable
	{
		/// <summary>Keys are this set's elements.</summary>
		/// <remarks>Keys are this set's elements. Values are always Boolean.TRUE</remarks>
		[System.NonSerialized]
		private java.util.NavigableMap<E, object> backingMap;

		[System.NonSerialized]
		private java.util.NavigableSet<E> _descendingSet;

		internal TreeSet(java.util.NavigableMap<E, object> map)
		{
			backingMap = map;
		}

		/// <summary>
		/// Constructs a new empty instance of
		/// <code>TreeSet</code>
		/// which uses natural
		/// ordering.
		/// </summary>
		public TreeSet()
		{
			backingMap = new java.util.TreeMap<E, object>();
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>TreeSet</code>
		/// which uses natural ordering
		/// and containing the unique elements in the specified collection.
		/// </summary>
		/// <param name="collection">the collection of elements to add.</param>
		/// <exception cref="System.InvalidCastException">
		/// when an element in the collection does not implement the
		/// Comparable interface, or the elements in the collection
		/// cannot be compared.
		/// </exception>
		public TreeSet(java.util.Collection<E> collection) : this()
		{
			addAll(collection);
		}

		/// <summary>
		/// Constructs a new empty instance of
		/// <code>TreeSet</code>
		/// which uses the
		/// specified comparator.
		/// </summary>
		/// <param name="comparator">the comparator to use.</param>
		public TreeSet(java.util.Comparator<E> comparator_1)
		{
			backingMap = new java.util.TreeMap<E, object>(comparator_1);
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>TreeSet</code>
		/// containing the elements of
		/// the specified SortedSet and using the same Comparator.
		/// </summary>
		/// <param name="set">the SortedSet of elements to add.</param>
		public TreeSet(java.util.SortedSet<E> set) : this(set.comparator())
		{
			java.util.Iterator<E> it = set.iterator();
			while (it.hasNext())
			{
				add(it.next());
			}
		}

		/// <summary>
		/// Adds the specified object to this
		/// <code>TreeSet</code>
		/// .
		/// </summary>
		/// <param name="object">the object to add.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// when this
		/// <code>TreeSet</code>
		/// did not already contain
		/// the object,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// when the object cannot be compared with the elements in this
		/// <code>TreeSet</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// when the object is null and the comparator cannot handle
		/// null.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool add(E @object)
		{
			return backingMap.put(@object, true) == null;
		}

		/// <summary>
		/// Adds the objects in the specified collection to this
		/// <code>TreeSet</code>
		/// .
		/// </summary>
		/// <param name="collection">the collection of objects to add.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>TreeSet</code>
		/// was modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// when an object in the collection cannot be compared with the
		/// elements in this
		/// <code>TreeSet</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// when an object in the collection is null and the comparator
		/// cannot handle null.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool addAll<_T0>(java.util.Collection<_T0> collection)
		{
			return base.addAll(collection);
		}

		/// <summary>
		/// Removes all elements from this
		/// <code>TreeSet</code>
		/// , leaving it empty.
		/// </summary>
		/// <seealso cref="TreeSet{E}.isEmpty()">TreeSet&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="TreeSet{E}.size()">TreeSet&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override void clear()
		{
			backingMap.clear();
		}

		/// <summary>
		/// Returns the comparator used to compare elements in this
		/// <code>TreeSet</code>
		/// .
		/// </summary>
		/// <returns>a Comparator or null if the natural ordering is used</returns>
		[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
		public virtual java.util.Comparator<E> comparator()
		{
			return backingMap.comparator();
		}

		/// <summary>
		/// Searches this
		/// <code>TreeSet</code>
		/// for the specified object.
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>object</code>
		/// is an element of this
		/// <code>TreeSet</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// when the object cannot be compared with the elements in this
		/// <code>TreeSet</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// when the object is null and the comparator cannot handle
		/// null.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool contains(object @object)
		{
			return backingMap.containsKey(@object);
		}

		/// <summary>
		/// Returns true if this
		/// <code>TreeSet</code>
		/// has no element, otherwise false.
		/// </summary>
		/// <returns>
		/// true if this
		/// <code>TreeSet</code>
		/// has no element.
		/// </returns>
		/// <seealso cref="TreeSet{E}.size()">TreeSet&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool isEmpty()
		{
			return backingMap.isEmpty();
		}

		/// <summary>
		/// Returns an Iterator on the elements of this
		/// <code>TreeSet</code>
		/// .
		/// </summary>
		/// <returns>
		/// an Iterator on the elements of this
		/// <code>TreeSet</code>
		/// .
		/// </returns>
		/// <seealso cref="Iterator{E}">Iterator&lt;E&gt;</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override java.util.Iterator<E> iterator()
		{
			return backingMap.keySet().iterator();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.descendingIterator()">NavigableSet&lt;E&gt;.descendingIterator()
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual java.util.Iterator<E> descendingIterator()
		{
			return descendingSet().iterator();
		}

		/// <summary>
		/// Removes an occurrence of the specified object from this
		/// <code>TreeSet</code>
		/// .
		/// </summary>
		/// <param name="object">the object to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>TreeSet</code>
		/// was modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// when the object cannot be compared with the elements in this
		/// <code>TreeSet</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// when the object is null and the comparator cannot handle
		/// null.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool remove(object @object)
		{
			return backingMap.remove(@object) != null;
		}

		/// <summary>
		/// Returns the number of elements in this
		/// <code>TreeSet</code>
		/// .
		/// </summary>
		/// <returns>
		/// the number of elements in this
		/// <code>TreeSet</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override int size()
		{
			return backingMap.size();
		}

		/// <summary>Returns the first element in this set.</summary>
		/// <remarks>Returns the first element in this set.</remarks>
		/// <exception>
		/// NoSuchElementException
		/// when this TreeSet is empty
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
		public virtual E first()
		{
			return backingMap.firstKey();
		}

		/// <summary>Returns the last element in this set.</summary>
		/// <remarks>Returns the last element in this set.</remarks>
		/// <exception>
		/// NoSuchElementException
		/// when this TreeSet is empty
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
		public virtual E last()
		{
			return backingMap.lastKey();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.pollFirst()">NavigableSet&lt;E&gt;.pollFirst()</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual E pollFirst()
		{
			java.util.MapClass.Entry<E, object> entry = backingMap.pollFirstEntry();
			return (entry == null) ? default(E) : entry.getKey();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.pollLast()">NavigableSet&lt;E&gt;.pollLast()</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual E pollLast()
		{
			java.util.MapClass.Entry<E, object> entry = backingMap.pollLastEntry();
			return (entry == null) ? default(E) : entry.getKey();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.higher(object)">NavigableSet&lt;E&gt;.higher(object)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual E higher(E e)
		{
			return backingMap.higherKey(e);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.lower(object)">NavigableSet&lt;E&gt;.lower(object)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual E lower(E e)
		{
			return backingMap.lowerKey(e);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.ceiling(object)">NavigableSet&lt;E&gt;.ceiling(object)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual E ceiling(E e)
		{
			return backingMap.ceilingKey(e);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.floor(object)">NavigableSet&lt;E&gt;.floor(object)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual E floor(E e)
		{
			return backingMap.floorKey(e);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.descendingSet()">NavigableSet&lt;E&gt;.descendingSet()
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual java.util.NavigableSet<E> descendingSet()
		{
			return (_descendingSet != null) ? _descendingSet : (_descendingSet = new java.util.TreeSet
				<E>(backingMap.descendingMap()));
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.subSet(object, bool, object, bool)">NavigableSet&lt;E&gt;.subSet(object, bool, object, bool)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual java.util.NavigableSet<E> subSet(E start, bool startInclusive, E end
			, bool endInclusive)
		{
			java.util.Comparator<E> c = backingMap.comparator();
			int compare = (c == null) ? ((java.lang.Comparable<E>)start).compareTo(end) : c.compare
				(start, end);
			if (compare <= 0)
			{
				return new java.util.TreeSet<E>(backingMap.subMap(start, startInclusive, end, endInclusive
					));
			}
			throw new System.ArgumentException();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.headSet(object, bool)">NavigableSet&lt;E&gt;.headSet(object, bool)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual java.util.NavigableSet<E> headSet(E end, bool endInclusive)
		{
			// Check for errors
			java.util.Comparator<E> c = backingMap.comparator();
			if (c == null)
			{
				((java.lang.Comparable<E>)end).compareTo(end);
			}
			else
			{
				c.compare(end, end);
			}
			return new java.util.TreeSet<E>(backingMap.headMap(end, endInclusive));
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="NavigableSet{E}.tailSet(object, bool)">NavigableSet&lt;E&gt;.tailSet(object, bool)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
		public virtual java.util.NavigableSet<E> tailSet(E start, bool startInclusive)
		{
			// Check for errors
			java.util.Comparator<E> c = backingMap.comparator();
			if (c == null)
			{
				((java.lang.Comparable<E>)start).compareTo(start);
			}
			else
			{
				c.compare(start, start);
			}
			return new java.util.TreeSet<E>(backingMap.tailMap(start, startInclusive));
		}

		/// <summary>
		/// Returns a
		/// <code>SortedSet</code>
		/// of the specified portion of this
		/// <code>TreeSet</code>
		/// which
		/// contains elements greater or equal to the start element but less than the
		/// end element. The returned SortedSet is backed by this TreeSet so changes
		/// to one are reflected by the other.
		/// </summary>
		/// <param name="start">the start element</param>
		/// <param name="end">the end element</param>
		/// <returns>
		/// a subset where the elements are greater or equal to
		/// <code>start</code> and less than <code>end</code>
		/// </returns>
		/// <exception>
		/// ClassCastException
		/// when the start or end object cannot be compared with the
		/// elements in this TreeSet
		/// </exception>
		/// <exception>
		/// NullPointerException
		/// when the start or end object is null and the comparator
		/// cannot handle null
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
		public virtual java.util.SortedSet<E> subSet(E start, E end)
		{
			return subSet(start, true, end, false);
		}

		/// <summary>
		/// Returns a
		/// <code>SortedSet</code>
		/// of the specified portion of this
		/// <code>TreeSet</code>
		/// which
		/// contains elements less than the end element. The returned SortedSet is
		/// backed by this TreeSet so changes to one are reflected by the other.
		/// </summary>
		/// <param name="end">the end element</param>
		/// <returns>a subset where the elements are less than <code>end</code></returns>
		/// <exception>
		/// ClassCastException
		/// when the end object cannot be compared with the elements
		/// in this TreeSet
		/// </exception>
		/// <exception>
		/// NullPointerException
		/// when the end object is null and the comparator cannot
		/// handle null
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
		public virtual java.util.SortedSet<E> headSet(E end)
		{
			return headSet(end, false);
		}

		/// <summary>
		/// Returns a
		/// <code>SortedSet</code>
		/// of the specified portion of this
		/// <code>TreeSet</code>
		/// which
		/// contains elements greater or equal to the start element. The returned
		/// SortedSet is backed by this TreeSet so changes to one are reflected by
		/// the other.
		/// </summary>
		/// <param name="start">the start element</param>
		/// <returns>
		/// a subset where the elements are greater or equal to
		/// <code>start</code>
		/// </returns>
		/// <exception>
		/// ClassCastException
		/// when the start object cannot be compared with the elements
		/// in this TreeSet
		/// </exception>
		/// <exception>
		/// NullPointerException
		/// when the start object is null and the comparator cannot
		/// handle null
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
		public virtual java.util.SortedSet<E> tailSet(E start)
		{
			return tailSet(start, true);
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			stream.defaultWriteObject();
			stream.writeObject(backingMap.comparator());
			int size_1 = backingMap.size();
			stream.writeInt(size_1);
			if (size_1 > 0)
			{
				java.util.Iterator<E> it = backingMap.keySet().iterator();
				while (it.hasNext())
				{
					stream.writeObject(it.next());
				}
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream stream)
		{
			stream.defaultReadObject();
			java.util.TreeMap<E, object> map = new java.util.TreeMap<E, object>((java.util.Comparator
				<E>)stream.readObject());
			int size_1 = stream.readInt();
			if (size_1 > 0)
			{
				{
					for (int i = 0; i < size_1; i++)
					{
						E elem = (E)stream.readObject();
						map.put(elem, true);
					}
				}
			}
			backingMap = map;
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
