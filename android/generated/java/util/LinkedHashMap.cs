using Sharpen;

namespace java.util
{
	/// <summary>
	/// LinkedHashMap is an implementation of
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// that guarantees iteration order.
	/// All optional operations are supported.
	/// <p>All elements are permitted as keys or values, including null.
	/// <p>Entries are kept in a doubly-linked list. The iteration order is, by default, the
	/// order in which keys were inserted. Reinserting an already-present key doesn't change the
	/// order. If the three argument constructor is used, and
	/// <code>accessOrder</code>
	/// is specified as
	/// <code>true</code>
	/// , the iteration will be in the order that entries were accessed.
	/// The access order is affected by
	/// <code>put</code>
	/// ,
	/// <code>get</code>
	/// , and
	/// <code>putAll</code>
	/// operations,
	/// but not by operations on the collection views.
	/// <p>Note: the implementation of
	/// <code>LinkedHashMap</code>
	/// is not synchronized.
	/// If one thread of several threads accessing an instance modifies the map
	/// structurally, access to the map needs to be synchronized. For
	/// insertion-ordered instances a structural modification is an operation that
	/// removes or adds an entry. Access-ordered instances also are structurally
	/// modified by
	/// <code>put</code>
	/// ,
	/// <code>get</code>
	/// , and
	/// <code>putAll</code>
	/// since these methods
	/// change the order of the entries. Changes in the value of an entry are not structural changes.
	/// <p>The
	/// <code>Iterator</code>
	/// created by calling the
	/// <code>iterator</code>
	/// method
	/// may throw a
	/// <code>ConcurrentModificationException</code>
	/// if the map is structurally
	/// changed while an iterator is used to iterate over the elements. Only the
	/// <code>remove</code>
	/// method that is provided by the iterator allows for removal of
	/// elements during iteration. It is not possible to guarantee that this
	/// mechanism works in all cases of unsynchronized concurrent modification. It
	/// should only be used for debugging purposes.
	/// </summary>
	[Sharpen.Sharpened]
	public static class LinkedHashMap
	{
		/// <summary>LinkedEntry adds nxt/prv double-links to plain HashMapEntry.</summary>
		/// <remarks>LinkedEntry adds nxt/prv double-links to plain HashMapEntry.</remarks>
		internal class LinkedEntry<K, V> : java.util.HashMap.HashMapEntry<K, V>
		{
			internal java.util.LinkedHashMap.LinkedEntry<K, V> nxt;

			internal java.util.LinkedHashMap.LinkedEntry<K, V> prv;

			/// <summary>Create the header entry</summary>
			internal LinkedEntry() : base(default(K), default(V), 0, null)
			{
				nxt = prv = this;
			}

			/// <summary>Create a normal entry</summary>
			internal LinkedEntry(K key, V value, int hash, java.util.HashMap.HashMapEntry<K, 
				V> next, java.util.LinkedHashMap.LinkedEntry<K, V> nxt, java.util.LinkedHashMap.
				LinkedEntry<K, V> prv) : base(key, value, hash, next)
			{
				this.nxt = nxt;
				this.prv = prv;
			}
		}

		internal const long serialVersionUID = 3801124242820219131L;
	}

	/// <summary>
	/// LinkedHashMap is an implementation of
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// that guarantees iteration order.
	/// All optional operations are supported.
	/// <p>All elements are permitted as keys or values, including null.
	/// <p>Entries are kept in a doubly-linked list. The iteration order is, by default, the
	/// order in which keys were inserted. Reinserting an already-present key doesn't change the
	/// order. If the three argument constructor is used, and
	/// <code>accessOrder</code>
	/// is specified as
	/// <code>true</code>
	/// , the iteration will be in the order that entries were accessed.
	/// The access order is affected by
	/// <code>put</code>
	/// ,
	/// <code>get</code>
	/// , and
	/// <code>putAll</code>
	/// operations,
	/// but not by operations on the collection views.
	/// <p>Note: the implementation of
	/// <code>LinkedHashMap</code>
	/// is not synchronized.
	/// If one thread of several threads accessing an instance modifies the map
	/// structurally, access to the map needs to be synchronized. For
	/// insertion-ordered instances a structural modification is an operation that
	/// removes or adds an entry. Access-ordered instances also are structurally
	/// modified by
	/// <code>put</code>
	/// ,
	/// <code>get</code>
	/// , and
	/// <code>putAll</code>
	/// since these methods
	/// change the order of the entries. Changes in the value of an entry are not structural changes.
	/// <p>The
	/// <code>Iterator</code>
	/// created by calling the
	/// <code>iterator</code>
	/// method
	/// may throw a
	/// <code>ConcurrentModificationException</code>
	/// if the map is structurally
	/// changed while an iterator is used to iterate over the elements. Only the
	/// <code>remove</code>
	/// method that is provided by the iterator allows for removal of
	/// elements during iteration. It is not possible to guarantee that this
	/// mechanism works in all cases of unsynchronized concurrent modification. It
	/// should only be used for debugging purposes.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class LinkedHashMap<K, V> : java.util.HashMap<K, V>
	{
		/// <summary>A dummy entry in the circular linked list of entries in the map.</summary>
		/// <remarks>
		/// A dummy entry in the circular linked list of entries in the map.
		/// The first real entry is header.nxt, and the last is header.prv.
		/// If the map is empty, header.nxt == header && header.prv == header.
		/// </remarks>
		[System.NonSerialized]
		internal java.util.LinkedHashMap.LinkedEntry<K, V> header;

		/// <summary>True if access ordered, false if insertion ordered.</summary>
		/// <remarks>True if access ordered, false if insertion ordered.</remarks>
		private readonly bool accessOrder;

		/// <summary>
		/// Constructs a new empty
		/// <code>LinkedHashMap</code>
		/// instance.
		/// </summary>
		public LinkedHashMap()
		{
			init();
			accessOrder = false;
		}

		/// <summary>
		/// Constructs a new
		/// <code>LinkedHashMap</code>
		/// instance with the specified
		/// capacity.
		/// </summary>
		/// <param name="initialCapacity">the initial capacity of this map.</param>
		/// <exception>
		/// IllegalArgumentException
		/// when the capacity is less than zero.
		/// </exception>
		public LinkedHashMap(int initialCapacity) : this(initialCapacity, java.util.HashMap.DEFAULT_LOAD_FACTOR
			)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>LinkedHashMap</code>
		/// instance with the specified
		/// capacity and load factor.
		/// </summary>
		/// <param name="initialCapacity">the initial capacity of this map.</param>
		/// <param name="loadFactor">the initial load factor.</param>
		/// <exception cref="System.ArgumentException">
		/// when the capacity is less than zero or the load factor is
		/// less or equal to zero.
		/// </exception>
		public LinkedHashMap(int initialCapacity, float loadFactor) : this(initialCapacity
			, loadFactor, false)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>LinkedHashMap</code>
		/// instance with the specified
		/// capacity, load factor and a flag specifying the ordering behavior.
		/// </summary>
		/// <param name="initialCapacity">the initial capacity of this hash map.</param>
		/// <param name="loadFactor">the initial load factor.</param>
		/// <param name="accessOrder">
		/// <code>true</code>
		/// if the ordering should be done based on the last
		/// access (from least-recently accessed to most-recently
		/// accessed), and
		/// <code>false</code>
		/// if the ordering should be the
		/// order in which the entries were inserted.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// when the capacity is less than zero or the load factor is
		/// less or equal to zero.
		/// </exception>
		public LinkedHashMap(int initialCapacity, float loadFactor, bool accessOrder) : base
			(initialCapacity, loadFactor)
		{
			init();
			this.accessOrder = accessOrder;
		}

		/// <summary>
		/// Constructs a new
		/// <code>LinkedHashMap</code>
		/// instance containing the mappings
		/// from the specified map. The order of the elements is preserved.
		/// </summary>
		/// <param name="map">the mappings to add.</param>
		public LinkedHashMap(java.util.Map<K, V> map) : this(capacityForInitSize(map.size
			()))
		{
			constructorPutAll(map);
		}

		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override void init()
		{
			header = new java.util.LinkedHashMap.LinkedEntry<K, V>();
		}

		/// <summary>
		/// Returns the eldest entry in the map, or
		/// <code>null</code>
		/// if the map is empty.
		/// </summary>
		/// <hide></hide>
		public virtual java.util.MapClass.Entry<K, V> eldest()
		{
			java.util.LinkedHashMap.LinkedEntry<K, V> eldest_1 = header.nxt;
			return eldest_1 != header ? eldest_1 : null;
		}

		/// <summary>
		/// Evicts eldest entry if instructed, creates a new entry and links it in
		/// as head of linked list.
		/// </summary>
		/// <remarks>
		/// Evicts eldest entry if instructed, creates a new entry and links it in
		/// as head of linked list. This method should call constructorNewEntry
		/// (instead of duplicating code) if the performance of your VM permits.
		/// <p>It may seem strange that this method is tasked with adding the entry
		/// to the hash table (which is properly the province of our superclass).
		/// The alternative of passing the "next" link in to this method and
		/// returning the newly created element does not work! If we remove an
		/// (eldest) entry that happens to be the first entry in the same bucket
		/// as the newly created entry, the "next" link would become invalid, and
		/// the resulting hash table corrupt.
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override void addNewEntry(K key, V value, int hash, int index)
		{
			java.util.LinkedHashMap.LinkedEntry<K, V> header = this.header;
			// Remove eldest entry if instructed to do so.
			java.util.LinkedHashMap.LinkedEntry<K, V> eldest_1 = header.nxt;
			if (eldest_1 != header && removeEldestEntry(eldest_1))
			{
				remove(eldest_1.key);
			}
			// Create new entry, link it on to list, and put it into table
			java.util.LinkedHashMap.LinkedEntry<K, V> oldTail = header.prv;
			java.util.LinkedHashMap.LinkedEntry<K, V> newTail = new java.util.LinkedHashMap.LinkedEntry
				<K, V>(key, value, hash, table[index], header, oldTail);
			table[index] = oldTail.nxt = header.prv = newTail;
		}

		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override void addNewEntryForNullKey(V value)
		{
			java.util.LinkedHashMap.LinkedEntry<K, V> header = this.header;
			// Remove eldest entry if instructed to do so.
			java.util.LinkedHashMap.LinkedEntry<K, V> eldest_1 = header.nxt;
			if (eldest_1 != header && removeEldestEntry(eldest_1))
			{
				remove(eldest_1.key);
			}
			// Create new entry, link it on to list, and put it into table
			java.util.LinkedHashMap.LinkedEntry<K, V> oldTail = header.prv;
			java.util.LinkedHashMap.LinkedEntry<K, V> newTail = new java.util.LinkedHashMap.LinkedEntry
				<K, V>(default(K), value, 0, null, header, oldTail);
			entryForNullKey = oldTail.nxt = header.prv = newTail;
		}

		/// <summary>As above, but without eviction.</summary>
		/// <remarks>As above, but without eviction.</remarks>
		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override java.util.HashMap.HashMapEntry<K, V> constructorNewEntry(K key, 
			V value, int hash, java.util.HashMap.HashMapEntry<K, V> next)
		{
			java.util.LinkedHashMap.LinkedEntry<K, V> header = this.header;
			java.util.LinkedHashMap.LinkedEntry<K, V> oldTail = header.prv;
			java.util.LinkedHashMap.LinkedEntry<K, V> newTail = new java.util.LinkedHashMap.LinkedEntry
				<K, V>(key, value, hash, next, header, oldTail);
			return oldTail.nxt = header.prv = newTail;
		}

		/// <summary>Returns the value of the mapping with the specified key.</summary>
		/// <remarks>Returns the value of the mapping with the specified key.</remarks>
		/// <param name="key">the key.</param>
		/// <returns>
		/// the value of the mapping with the specified key, or
		/// <code>null</code>
		/// if no mapping for the specified key is found.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override V get(object key)
		{
			if (key == null)
			{
				java.util.HashMap.HashMapEntry<K, V> e = entryForNullKey;
				if (e == null)
				{
					return default(V);
				}
				if (accessOrder)
				{
					makeTail((java.util.LinkedHashMap.LinkedEntry<K, V>)e);
				}
				return e.value;
			}
			// Doug Lea's supplemental secondaryHash function (inlined)
			int hash = key.GetHashCode();
			hash ^= ((int)(((uint)hash) >> 20)) ^ ((int)(((uint)hash) >> 12));
			hash ^= ((int)(((uint)hash) >> 7)) ^ ((int)(((uint)hash) >> 4));
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			{
				for (java.util.HashMap.HashMapEntry<K, V> e_1 = tab[hash & (tab.Length - 1)]; e_1
					 != null; e_1 = e_1.next)
				{
					K eKey = e_1.key;
					if (Sharpen.Util.Equals(eKey, key) || (e_1.hash == hash && key.Equals(eKey)))
					{
						if (accessOrder)
						{
							makeTail((java.util.LinkedHashMap.LinkedEntry<K, V>)e_1);
						}
						return e_1.value;
					}
				}
			}
			return default(V);
		}

		/// <summary>Relinks the given entry to the tail of the list.</summary>
		/// <remarks>
		/// Relinks the given entry to the tail of the list. Under access ordering,
		/// this method is invoked whenever the value of a  pre-existing entry is
		/// read by Map.get or modified by Map.put.
		/// </remarks>
		internal void makeTail(java.util.LinkedHashMap.LinkedEntry<K, V> e)
		{
			// Unlink e
			e.prv.nxt = e.nxt;
			e.nxt.prv = e.prv;
			// Relink e as tail
			java.util.LinkedHashMap.LinkedEntry<K, V> header = this.header;
			java.util.LinkedHashMap.LinkedEntry<K, V> oldTail = header.prv;
			e.nxt = header;
			e.prv = oldTail;
			oldTail.nxt = header.prv = e;
			modCount++;
		}

		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override void preModify(java.util.HashMap.HashMapEntry<K, V> e)
		{
			if (accessOrder)
			{
				makeTail((java.util.LinkedHashMap.LinkedEntry<K, V>)e);
			}
		}

		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override void postRemove(java.util.HashMap.HashMapEntry<K, V> e)
		{
			java.util.LinkedHashMap.LinkedEntry<K, V> le = (java.util.LinkedHashMap.LinkedEntry
				<K, V>)e;
			le.prv.nxt = le.nxt;
			le.nxt.prv = le.prv;
			le.nxt = le.prv = null;
		}

		// Help the GC (for performance)
		/// <summary>
		/// This override is done for LinkedHashMap performance: iteration is cheaper
		/// via LinkedHashMap nxt links.
		/// </summary>
		/// <remarks>
		/// This override is done for LinkedHashMap performance: iteration is cheaper
		/// via LinkedHashMap nxt links.
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override bool containsValue(object value)
		{
			if (value == null)
			{
				{
					java.util.LinkedHashMap.LinkedEntry<K, V> header = this.header;
					java.util.LinkedHashMap.LinkedEntry<K, V> e = header.nxt;
					for (; e != header; e = e.nxt)
					{
						if ((object)e.value == null)
						{
							return true;
						}
					}
				}
				return false;
			}
			{
				java.util.LinkedHashMap.LinkedEntry<K, V> header_1 = this.header;
				java.util.LinkedHashMap.LinkedEntry<K, V> e_1 = header_1.nxt;
				// value is non-null
				for (; e_1 != header_1; e_1 = e_1.nxt)
				{
					if (value.Equals(e_1.value))
					{
						return true;
					}
				}
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override void clear()
		{
			base.clear();
			// Clear all links to help GC
			java.util.LinkedHashMap.LinkedEntry<K, V> header = this.header;
			{
				for (java.util.LinkedHashMap.LinkedEntry<K, V> e = header.nxt; e != header; )
				{
					java.util.LinkedHashMap.LinkedEntry<K, V> nxt = e.nxt;
					e.nxt = e.prv = null;
					e = nxt;
				}
			}
			header.nxt = header.prv = header;
		}

		private abstract class LinkedHashIterator<T> : java.util.Iterator<T>
		{
			internal java.util.LinkedHashMap.LinkedEntry<K, V> _next;

			internal java.util.LinkedHashMap.LinkedEntry<K, V> lastReturned;

			internal int expectedModCount;

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				return this._next != this._enclosing.header;
			}

			internal java.util.LinkedHashMap.LinkedEntry<K, V> nextEntry()
			{
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				java.util.LinkedHashMap.LinkedEntry<K, V> e = this._next;
				if (e == this._enclosing.header)
				{
					throw new java.util.NoSuchElementException();
				}
				this._next = e.nxt;
				return this.lastReturned = e;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				if (this.lastReturned == null)
				{
					throw new System.InvalidOperationException();
				}
				this._enclosing.remove(this.lastReturned.key);
				this.lastReturned = null;
				this.expectedModCount = this._enclosing.modCount;
			}

			public abstract T next();

			public LinkedHashIterator(LinkedHashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
				_next = this._enclosing.header.nxt;
				lastReturned = null;
				expectedModCount = this._enclosing.modCount;
			}

			private readonly LinkedHashMap<K, V> _enclosing;
		}

		private sealed class KeyIterator : java.util.LinkedHashMap<K, V>.LinkedHashIterator
			<K>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public override K next()
			{
				return this.nextEntry().key;
			}

			internal KeyIterator(LinkedHashMap<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly LinkedHashMap<K, V> _enclosing;
		}

		private sealed class ValueIterator : java.util.LinkedHashMap<K, V>.LinkedHashIterator
			<V>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public override V next()
			{
				return this.nextEntry().value;
			}

			internal ValueIterator(LinkedHashMap<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly LinkedHashMap<K, V> _enclosing;
		}

		private sealed class EntryIterator : java.util.LinkedHashMap<K, V>.LinkedHashIterator
			<java.util.MapClass.Entry<K, V>>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public override java.util.MapClass.Entry<K, V> next()
			{
				return this.nextEntry();
			}

			internal EntryIterator(LinkedHashMap<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly LinkedHashMap<K, V> _enclosing;
		}

		// Override view iterator methods to generate correct iteration order
		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override java.util.Iterator<K> newKeyIterator()
		{
			return new java.util.LinkedHashMap<K, V>.KeyIterator(this);
		}

		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override java.util.Iterator<V> newValueIterator()
		{
			return new java.util.LinkedHashMap<K, V>.ValueIterator(this);
		}

		[Sharpen.OverridesMethod(@"java.util.HashMap")]
		internal override java.util.Iterator<java.util.MapClass.Entry<K, V>> newEntryIterator
			()
		{
			return new java.util.LinkedHashMap<K, V>.EntryIterator(this);
		}

		protected internal virtual bool removeEldestEntry(java.util.MapClass.Entry<K, V> 
			eldest_1)
		{
			return false;
		}
	}
}
