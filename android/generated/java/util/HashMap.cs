using Sharpen;

namespace java.util
{
	/// <summary>
	/// HashMap is an implementation of
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// . All optional operations are supported.
	/// <p>All elements are permitted as keys or values, including null.
	/// <p>Note that the iteration order for HashMap is non-deterministic. If you want
	/// deterministic iteration, use
	/// <see cref="LinkedHashMap{K, V}">LinkedHashMap&lt;K, V&gt;</see>
	/// .
	/// <p>Note: the implementation of
	/// <code>HashMap</code>
	/// is not synchronized.
	/// If one thread of several threads accessing an instance modifies the map
	/// structurally, access to the map needs to be synchronized. A structural
	/// modification is an operation that adds or removes an entry. Changes in
	/// the value of an entry are not structural changes.
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
	/// <?></?>
	/// <?></?>
	[Sharpen.Sharpened]
	public static class HashMap
	{
		/// <summary>Min capacity (other than zero) for a HashMap.</summary>
		/// <remarks>
		/// Min capacity (other than zero) for a HashMap. Must be a power of two
		/// greater than 1 (and less than 1 &lt;&lt; 30).
		/// </remarks>
		internal const int MINIMUM_CAPACITY = 4;

		/// <summary>Max capacity for a HashMap.</summary>
		/// <remarks>Max capacity for a HashMap. Must be a power of two &gt;= MINIMUM_CAPACITY.
		/// 	</remarks>
		internal const int MAXIMUM_CAPACITY = 1 << 30;

		/// <summary>The default load factor.</summary>
		/// <remarks>
		/// The default load factor. Note that this implementation ignores the
		/// load factor, but cannot do away with it entirely because it's
		/// mentioned in the API.
		/// <p>Note that this constant has no impact on the behavior of the program,
		/// but it is emitted as part of the serialized form. The load factor of
		/// .75 is hardwired into the program, which uses cheap shifts in place of
		/// expensive division.
		/// </remarks>
		internal const float DEFAULT_LOAD_FACTOR = .75F;

		internal class HashMapEntry<K, V> : java.util.MapClass.Entry<K, V>
		{
			internal readonly K key;

			internal V value;

			internal readonly int hash;

			internal java.util.HashMap.HashMapEntry<K, V> next;

			internal HashMapEntry(K key, V value, int hash, java.util.HashMap.HashMapEntry<K, 
				V> next)
			{
				// Views - lazily initialized
				// Forces first put invocation to replace EMPTY_TABLE
				// Forces first put() to replace EMPTY_TABLE
				// Multiply by 3/2 to allow for growth
				// boolean expr is equivalent to result >= 0 && result<MAXIMUM_CAPACITY
				// Restore clone to empty state, retaining our capacity and threshold
				// Give subclass a chance to initialize itself
				// Calls method overridden in subclass!!
				// Doug Lea's supplemental secondaryHash function (inlined)
				// Doug Lea's supplemental secondaryHash function (inlined)
				// value is non-null
				// No entry for (non-null) key is present; create one
				// No entry for (non-null) key is present; create one
				// We're growing by at least 4x, rehash in the obvious way
				// 3/4 capacity
				this.key = key;
				this.value = value;
				this.hash = hash;
				this.next = next;
			}

			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public virtual K getKey()
			{
				return key;
			}

			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public virtual V getValue()
			{
				return value;
			}

			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public virtual V setValue(V value)
			{
				V oldValue = this.value;
				this.value = value;
				return oldValue;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public sealed override bool Equals(object o)
			{
				if (!(o is java.util.MapClass.Entry<K, V>))
				{
					return false;
				}
				java.util.MapClass.Entry<object, object> e = (java.util.MapClass.Entry<object, object
					>)o;
				return libcore.util.Objects.equal(e.getKey(), key) && libcore.util.Objects.equal(
					e.getValue(), value);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public sealed override int GetHashCode()
			{
				return ((object)key == null ? 0 : key.GetHashCode()) ^ ((object)value == null ? 0
					 : value.GetHashCode());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public sealed override string ToString()
			{
				return key + "=" + value;
			}
		}

		internal const long serialVersionUID = 362498820763181265L;
	}

	/// <summary>
	/// HashMap is an implementation of
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// . All optional operations are supported.
	/// <p>All elements are permitted as keys or values, including null.
	/// <p>Note that the iteration order for HashMap is non-deterministic. If you want
	/// deterministic iteration, use
	/// <see cref="LinkedHashMap{K, V}">LinkedHashMap&lt;K, V&gt;</see>
	/// .
	/// <p>Note: the implementation of
	/// <code>HashMap</code>
	/// is not synchronized.
	/// If one thread of several threads accessing an instance modifies the map
	/// structurally, access to the map needs to be synchronized. A structural
	/// modification is an operation that adds or removes an entry. Changes in
	/// the value of an entry are not structural changes.
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
	/// <?></?>
	/// <?></?>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class HashMap<K, V> : java.util.AbstractMap<K, V>, System.ICloneable
	{
		/// <summary>
		/// An empty table shared by all zero-capacity maps (typically from default
		/// constructor).
		/// </summary>
		/// <remarks>
		/// An empty table shared by all zero-capacity maps (typically from default
		/// constructor). It is never written to, and replaced on first put. Its size
		/// is set to half the minimum, so that the first resize will create a
		/// minimum-sized table.
		/// </remarks>
		private static readonly java.util.MapClass.Entry<K, V>[] EMPTY_TABLE = new java.util.HashMap
			.HashMapEntry<K, V>[(int)(((uint)java.util.HashMap.MINIMUM_CAPACITY) >> 1)];

		/// <summary>The hash table.</summary>
		/// <remarks>
		/// The hash table. If this hash map contains a mapping for null, it is
		/// not represented this hash table.
		/// </remarks>
		[System.NonSerialized]
		internal java.util.HashMap.HashMapEntry<K, V>[] table;

		/// <summary>The entry representing the null key, or null if there's no such mapping.
		/// 	</summary>
		/// <remarks>The entry representing the null key, or null if there's no such mapping.
		/// 	</remarks>
		[System.NonSerialized]
		internal java.util.HashMap.HashMapEntry<K, V> entryForNullKey;

		/// <summary>The number of mappings in this hash map.</summary>
		/// <remarks>The number of mappings in this hash map.</remarks>
		[System.NonSerialized]
		internal int _size;

		/// <summary>
		/// Incremented by "structural modifications" to allow (best effort)
		/// detection of concurrent modification.
		/// </summary>
		/// <remarks>
		/// Incremented by "structural modifications" to allow (best effort)
		/// detection of concurrent modification.
		/// </remarks>
		[System.NonSerialized]
		internal int modCount;

		/// <summary>The table is rehashed when its size exceeds this threshold.</summary>
		/// <remarks>
		/// The table is rehashed when its size exceeds this threshold.
		/// The value of this field is generally .75 * capacity, except when
		/// the capacity is zero, as described in the EMPTY_TABLE declaration
		/// above.
		/// </remarks>
		[System.NonSerialized]
		private int threshold;

		[System.NonSerialized]
		private java.util.Set<K> _keySet;

		[System.NonSerialized]
		private java.util.Set<java.util.MapClass.Entry<K, V>> _entrySet;

		[System.NonSerialized]
		private java.util.Collection<V> _values;

		/// <summary>
		/// Constructs a new empty
		/// <code>HashMap</code>
		/// instance.
		/// </summary>
		public HashMap()
		{
			table = (java.util.HashMap.HashMapEntry<K, V>[])EMPTY_TABLE;
			threshold = -1;
		}

		/// <summary>
		/// Constructs a new
		/// <code>HashMap</code>
		/// instance with the specified capacity.
		/// </summary>
		/// <param name="capacity">the initial capacity of this hash map.</param>
		/// <exception cref="System.ArgumentException">when the capacity is less than zero.</exception>
		public HashMap(int capacity)
		{
			if (capacity < 0)
			{
				throw new System.ArgumentException("Capacity: " + capacity);
			}
			if (capacity == 0)
			{
				java.util.HashMap.HashMapEntry<K, V>[] tab = (java.util.HashMap.HashMapEntry<K, V
					>[])EMPTY_TABLE;
				table = tab;
				threshold = -1;
				return;
			}
			if (capacity < java.util.HashMap.MINIMUM_CAPACITY)
			{
				capacity = java.util.HashMap.MINIMUM_CAPACITY;
			}
			else
			{
				if (capacity > java.util.HashMap.MAXIMUM_CAPACITY)
				{
					capacity = java.util.HashMap.MAXIMUM_CAPACITY;
				}
				else
				{
					capacity = roundUpToPowerOfTwo(capacity);
				}
			}
			makeTable(capacity);
		}

		/// <summary>
		/// Constructs a new
		/// <code>HashMap</code>
		/// instance with the specified capacity and
		/// load factor.
		/// </summary>
		/// <param name="capacity">the initial capacity of this hash map.</param>
		/// <param name="loadFactor">the initial load factor.</param>
		/// <exception cref="System.ArgumentException">
		/// when the capacity is less than zero or the load factor is
		/// less or equal to zero or NaN.
		/// </exception>
		public HashMap(int capacity, float loadFactor) : this(capacity)
		{
			if (loadFactor <= 0 || float.IsNaN(loadFactor))
			{
				throw new System.ArgumentException("Load factor: " + loadFactor);
			}
		}

		/// <summary>
		/// Constructs a new
		/// <code>HashMap</code>
		/// instance containing the mappings from
		/// the specified map.
		/// </summary>
		/// <param name="map">the mappings to add.</param>
		public HashMap(java.util.Map<K, V> map) : this(capacityForInitSize(map.size()))
		{
			constructorPutAll(map);
		}

		/// <summary>
		/// Inserts all of the elements of map into this HashMap in a manner
		/// suitable for use by constructors and pseudo-constructors (i.e., clone,
		/// readObject).
		/// </summary>
		/// <remarks>
		/// Inserts all of the elements of map into this HashMap in a manner
		/// suitable for use by constructors and pseudo-constructors (i.e., clone,
		/// readObject). Also used by LinkedHashMap.
		/// </remarks>
		internal void constructorPutAll<_T0, _T1>(java.util.Map<_T0, _T1> map) where _T0:
			K where _T1:V
		{
			foreach (java.util.MapClass.Entry<K, V> e in Sharpen.IterableProxy.Create(map.entrySet
				()))
			{
				constructorPut(e.getKey(), e.getValue());
			}
		}

		/// <summary>Returns an appropriate capacity for the specified initial size.</summary>
		/// <remarks>
		/// Returns an appropriate capacity for the specified initial size. Does
		/// not round the result up to a power of two; the caller must do this!
		/// The returned value will be between 0 and MAXIMUM_CAPACITY (inclusive).
		/// </remarks>
		internal static int capacityForInitSize(int size_1)
		{
			int result = (size_1 >> 1) + size_1;
			return (result & ~(java.util.HashMap.MAXIMUM_CAPACITY - 1)) == 0 ? result : java.util.HashMap.MAXIMUM_CAPACITY;
		}

		/// <summary>Returns a shallow copy of this map.</summary>
		/// <remarks>Returns a shallow copy of this map.</remarks>
		/// <returns>a shallow copy of this map.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		protected internal override object clone()
		{
			java.util.HashMap<K, V> result;
			result = (java.util.HashMap<K, V>)base.clone();
			result.makeTable(table.Length);
			result.entryForNullKey = null;
			result._size = 0;
			result._keySet = null;
			result._entrySet = null;
			result._values = null;
			result.init();
			result.constructorPutAll(this);
			return result;
		}

		/// <summary>
		/// This method is called from the pseudo-constructors (clone and readObject)
		/// prior to invoking constructorPut/constructorPutAll, which invoke the
		/// overridden constructorNewEntry method.
		/// </summary>
		/// <remarks>
		/// This method is called from the pseudo-constructors (clone and readObject)
		/// prior to invoking constructorPut/constructorPutAll, which invoke the
		/// overridden constructorNewEntry method. Normally it is a VERY bad idea to
		/// invoke an overridden method from a pseudo-constructor (Effective Java
		/// Item 17). In this case it is unavoidable, and the init method provides a
		/// workaround.
		/// </remarks>
		internal virtual void init()
		{
		}

		/// <summary>Returns whether this map is empty.</summary>
		/// <remarks>Returns whether this map is empty.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this map has no elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="HashMap{K, V}.size()">HashMap&lt;K, V&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override bool isEmpty()
		{
			return _size == 0;
		}

		/// <summary>Returns the number of elements in this map.</summary>
		/// <remarks>Returns the number of elements in this map.</remarks>
		/// <returns>the number of elements in this map.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override int size()
		{
			return _size;
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
				return e == null ? default(V) : e.value;
			}
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
						return e_1.value;
					}
				}
			}
			return default(V);
		}

		/// <summary>Returns whether this map contains the specified key.</summary>
		/// <remarks>Returns whether this map contains the specified key.</remarks>
		/// <param name="key">the key to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this map contains the specified key,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override bool containsKey(object key)
		{
			if (key == null)
			{
				return entryForNullKey != null;
			}
			int hash = key.GetHashCode();
			hash ^= ((int)(((uint)hash) >> 20)) ^ ((int)(((uint)hash) >> 12));
			hash ^= ((int)(((uint)hash) >> 7)) ^ ((int)(((uint)hash) >> 4));
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			{
				for (java.util.HashMap.HashMapEntry<K, V> e = tab[hash & (tab.Length - 1)]; e != 
					null; e = e.next)
				{
					K eKey = e.key;
					if (Sharpen.Util.Equals(eKey, key) || (e.hash == hash && key.Equals(eKey)))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Returns whether this map contains the specified value.</summary>
		/// <remarks>Returns whether this map contains the specified value.</remarks>
		/// <param name="value">the value to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this map contains the specified value,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override bool containsValue(object value)
		{
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			int len = tab.Length;
			if (value == null)
			{
				{
					for (int i = 0; i < len; i++)
					{
						{
							for (java.util.HashMap.HashMapEntry<K, V> e = tab[i]; e != null; e = e.next)
							{
								if (e.value == null)
								{
									return true;
								}
							}
						}
					}
				}
				return entryForNullKey != null && (object)entryForNullKey.value == null;
			}
			{
				for (int i_1 = 0; i_1 < len; i_1++)
				{
					{
						for (java.util.HashMap.HashMapEntry<K, V> e = tab[i_1]; e != null; e = e.next)
						{
							if (value.Equals(e.value))
							{
								return true;
							}
						}
					}
				}
			}
			return entryForNullKey != null && value.Equals(entryForNullKey.value);
		}

		/// <summary>Maps the specified key to the specified value.</summary>
		/// <remarks>Maps the specified key to the specified value.</remarks>
		/// <param name="key">the key.</param>
		/// <param name="value">the value.</param>
		/// <returns>
		/// the value of any previous mapping with the specified key or
		/// <code>null</code>
		/// if there was no such mapping.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override V put(K key, V value)
		{
			if ((object)key == null)
			{
				return putValueForNullKey(value);
			}
			int hash = secondaryHash(key.GetHashCode());
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			int index = hash & (tab.Length - 1);
			{
				for (java.util.HashMap.HashMapEntry<K, V> e = tab[index]; e != null; e = e.next)
				{
					if (e.hash == hash && key.Equals(e.key))
					{
						preModify(e);
						V oldValue = e.value;
						e.value = value;
						return oldValue;
					}
				}
			}
			modCount++;
			if (_size++ > threshold)
			{
				tab = doubleCapacity();
				index = hash & (tab.Length - 1);
			}
			addNewEntry(key, value, hash, index);
			return default(V);
		}

		private V putValueForNullKey(V value)
		{
			java.util.HashMap.HashMapEntry<K, V> entry = entryForNullKey;
			if (entry == null)
			{
				addNewEntryForNullKey(value);
				_size++;
				modCount++;
				return default(V);
			}
			else
			{
				preModify(entry);
				V oldValue = entry.value;
				entry.value = value;
				return oldValue;
			}
		}

		/// <summary>
		/// Give LinkedHashMap a chance to take action when we modify an existing
		/// entry.
		/// </summary>
		/// <remarks>
		/// Give LinkedHashMap a chance to take action when we modify an existing
		/// entry.
		/// </remarks>
		/// <param name="e">the entry we're about to modify.</param>
		internal virtual void preModify(java.util.HashMap.HashMapEntry<K, V> e)
		{
		}

		/// <summary>
		/// This method is just like put, except that it doesn't do things that
		/// are inappropriate or unnecessary for constructors and pseudo-constructors
		/// (i.e., clone, readObject).
		/// </summary>
		/// <remarks>
		/// This method is just like put, except that it doesn't do things that
		/// are inappropriate or unnecessary for constructors and pseudo-constructors
		/// (i.e., clone, readObject). In particular, this method does not check to
		/// ensure that capacity is sufficient, and does not increment modCount.
		/// </remarks>
		private void constructorPut(K key, V value)
		{
			if ((object)key == null)
			{
				java.util.HashMap.HashMapEntry<K, V> entry = entryForNullKey;
				if (entry == null)
				{
					entryForNullKey = constructorNewEntry(default(K), value, 0, null);
					_size++;
				}
				else
				{
					entry.value = value;
				}
				return;
			}
			int hash = secondaryHash(key.GetHashCode());
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			int index = hash & (tab.Length - 1);
			java.util.HashMap.HashMapEntry<K, V> first = tab[index];
			{
				for (java.util.HashMap.HashMapEntry<K, V> e = first; e != null; e = e.next)
				{
					if (e.hash == hash && key.Equals(e.key))
					{
						e.value = value;
						return;
					}
				}
			}
			tab[index] = constructorNewEntry(key, value, hash, first);
			_size++;
		}

		/// <summary>
		/// Creates a new entry for the given key, value, hash, and index and
		/// inserts it into the hash table.
		/// </summary>
		/// <remarks>
		/// Creates a new entry for the given key, value, hash, and index and
		/// inserts it into the hash table. This method is called by put
		/// (and indirectly, putAll), and overridden by LinkedHashMap. The hash
		/// must incorporate the secondary hash function.
		/// </remarks>
		internal virtual void addNewEntry(K key, V value, int hash, int index)
		{
			table[index] = new java.util.HashMap.HashMapEntry<K, V>(key, value, hash, table[index
				]);
		}

		/// <summary>
		/// Creates a new entry for the null key, and the given value and
		/// inserts it into the hash table.
		/// </summary>
		/// <remarks>
		/// Creates a new entry for the null key, and the given value and
		/// inserts it into the hash table. This method is called by put
		/// (and indirectly, putAll), and overridden by LinkedHashMap.
		/// </remarks>
		internal virtual void addNewEntryForNullKey(V value)
		{
			entryForNullKey = new java.util.HashMap.HashMapEntry<K, V>(default(K), value, 0, 
				null);
		}

		/// <summary>
		/// Like newEntry, but does not perform any activity that would be
		/// unnecessary or inappropriate for constructors.
		/// </summary>
		/// <remarks>
		/// Like newEntry, but does not perform any activity that would be
		/// unnecessary or inappropriate for constructors. In this class, the
		/// two methods behave identically; in LinkedHashMap, they differ.
		/// </remarks>
		internal virtual java.util.HashMap.HashMapEntry<K, V> constructorNewEntry(K key, 
			V value, int hash, java.util.HashMap.HashMapEntry<K, V> first)
		{
			return new java.util.HashMap.HashMapEntry<K, V>(key, value, hash, first);
		}

		/// <summary>Copies all the mappings in the specified map to this map.</summary>
		/// <remarks>
		/// Copies all the mappings in the specified map to this map. These mappings
		/// will replace all mappings that this map had for any of the keys currently
		/// in the given map.
		/// </remarks>
		/// <param name="map">the map to copy mappings from.</param>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override void putAll<_T0, _T1>(java.util.Map<_T0, _T1> map)
		{
			ensureCapacity(map.size());
			base.putAll(map);
		}

		/// <summary>
		/// Ensures that the hash table has sufficient capacity to store the
		/// specified number of mappings, with room to grow.
		/// </summary>
		/// <remarks>
		/// Ensures that the hash table has sufficient capacity to store the
		/// specified number of mappings, with room to grow. If not, it increases the
		/// capacity as appropriate. Like doubleCapacity, this method moves existing
		/// entries to new buckets as appropriate. Unlike doubleCapacity, this method
		/// can grow the table by factors of 2^n for n &gt; 1. Hopefully, a single call
		/// to this method will be faster than multiple calls to doubleCapacity.
		/// <p>This method is called only by putAll.
		/// </remarks>
		private void ensureCapacity(int numMappings)
		{
			int newCapacity = roundUpToPowerOfTwo(capacityForInitSize(numMappings));
			java.util.HashMap.HashMapEntry<K, V>[] oldTable = table;
			int oldCapacity = oldTable.Length;
			if (newCapacity <= oldCapacity)
			{
				return;
			}
			if (newCapacity == oldCapacity * 2)
			{
				doubleCapacity();
				return;
			}
			java.util.HashMap.HashMapEntry<K, V>[] newTable = makeTable(newCapacity);
			if (_size != 0)
			{
				int newMask = newCapacity - 1;
				{
					for (int i = 0; i < oldCapacity; i++)
					{
						{
							for (java.util.HashMap.HashMapEntry<K, V> e = oldTable[i]; e != null; )
							{
								java.util.HashMap.HashMapEntry<K, V> oldNext = e.next;
								int newIndex = e.hash & newMask;
								java.util.HashMap.HashMapEntry<K, V> newNext = newTable[newIndex];
								newTable[newIndex] = e;
								e.next = newNext;
								e = oldNext;
							}
						}
					}
				}
			}
		}

		/// <summary>Allocate a table of the given capacity and set the threshold accordingly.
		/// 	</summary>
		/// <remarks>Allocate a table of the given capacity and set the threshold accordingly.
		/// 	</remarks>
		/// <param name="newCapacity">must be a power of two</param>
		internal java.util.HashMap.HashMapEntry<K, V>[] makeTable(int newCapacity)
		{
			java.util.HashMap.HashMapEntry<K, V>[] newTable = (java.util.HashMap.HashMapEntry
				<K, V>[])new java.util.HashMap.HashMapEntry<K, V>[newCapacity];
			table = newTable;
			threshold = (newCapacity >> 1) + (newCapacity >> 2);
			return newTable;
		}

		/// <summary>Doubles the capacity of the hash table.</summary>
		/// <remarks>
		/// Doubles the capacity of the hash table. Existing entries are placed in
		/// the correct bucket on the enlarged table. If the current capacity is,
		/// MAXIMUM_CAPACITY, this method is a no-op. Returns the table, which
		/// will be new unless we were already at MAXIMUM_CAPACITY.
		/// </remarks>
		internal java.util.HashMap.HashMapEntry<K, V>[] doubleCapacity()
		{
			java.util.HashMap.HashMapEntry<K, V>[] oldTable = table;
			int oldCapacity = oldTable.Length;
			if (oldCapacity == java.util.HashMap.MAXIMUM_CAPACITY)
			{
				return oldTable;
			}
			int newCapacity = oldCapacity * 2;
			java.util.HashMap.HashMapEntry<K, V>[] newTable = makeTable(newCapacity);
			if (_size == 0)
			{
				return newTable;
			}
			{
				for (int j = 0; j < oldCapacity; j++)
				{
					java.util.HashMap.HashMapEntry<K, V> e = oldTable[j];
					if (e == null)
					{
						continue;
					}
					int highBit = e.hash & oldCapacity;
					java.util.HashMap.HashMapEntry<K, V> broken = null;
					newTable[j | highBit] = e;
					{
						for (java.util.HashMap.HashMapEntry<K, V> n = e.next; n != null; e = n, n = n.next)
						{
							int nextHighBit = n.hash & oldCapacity;
							if (nextHighBit != highBit)
							{
								if (broken == null)
								{
									newTable[j | nextHighBit] = n;
								}
								else
								{
									broken.next = n;
								}
								broken = e;
								highBit = nextHighBit;
							}
						}
					}
					if (broken != null)
					{
						broken.next = null;
					}
				}
			}
			return newTable;
		}

		/// <summary>Removes the mapping with the specified key from this map.</summary>
		/// <remarks>Removes the mapping with the specified key from this map.</remarks>
		/// <param name="key">the key of the mapping to remove.</param>
		/// <returns>
		/// the value of the removed mapping or
		/// <code>null</code>
		/// if no mapping
		/// for the specified key was found.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override V remove(object key)
		{
			if (key == null)
			{
				return removeNullKey();
			}
			int hash = secondaryHash(key.GetHashCode());
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			int index = hash & (tab.Length - 1);
			{
				java.util.HashMap.HashMapEntry<K, V> e = tab[index];
				java.util.HashMap.HashMapEntry<K, V> prev = null;
				for (; e != null; prev = e, e = e.next)
				{
					if (e.hash == hash && key.Equals(e.key))
					{
						if (prev == null)
						{
							tab[index] = e.next;
						}
						else
						{
							prev.next = e.next;
						}
						modCount++;
						_size--;
						postRemove(e);
						return e.value;
					}
				}
			}
			return default(V);
		}

		private V removeNullKey()
		{
			java.util.HashMap.HashMapEntry<K, V> e = entryForNullKey;
			if (e == null)
			{
				return default(V);
			}
			entryForNullKey = null;
			modCount++;
			_size--;
			postRemove(e);
			return e.value;
		}

		/// <summary>Subclass overrides this method to unlink entry.</summary>
		/// <remarks>Subclass overrides this method to unlink entry.</remarks>
		internal virtual void postRemove(java.util.HashMap.HashMapEntry<K, V> e)
		{
		}

		/// <summary>Removes all mappings from this hash map, leaving it empty.</summary>
		/// <remarks>Removes all mappings from this hash map, leaving it empty.</remarks>
		/// <seealso cref="HashMap{K, V}.isEmpty()">HashMap&lt;K, V&gt;.isEmpty()</seealso>
		/// <seealso cref="HashMap{K, V}._size">HashMap&lt;K, V&gt;._size</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override void clear()
		{
			if (_size != 0)
			{
				java.util.Arrays.fill(table, null);
				entryForNullKey = null;
				modCount++;
				_size = 0;
			}
		}

		/// <summary>Returns a set of the keys contained in this map.</summary>
		/// <remarks>
		/// Returns a set of the keys contained in this map. The set is backed by
		/// this map so changes to one are reflected by the other. The set does not
		/// support adding.
		/// </remarks>
		/// <returns>a set of the keys.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override java.util.Set<K> keySet()
		{
			java.util.Set<K> ks = _keySet;
			return (ks != null) ? ks : (_keySet = new java.util.HashMap<K, V>.KeySet(this));
		}

		/// <summary>Returns a collection of the values contained in this map.</summary>
		/// <remarks>
		/// Returns a collection of the values contained in this map. The collection
		/// is backed by this map so changes to one are reflected by the other. The
		/// collection supports remove, removeAll, retainAll and clear operations,
		/// and it does not support add or addAll operations.
		/// <p>
		/// This method returns a collection which is the subclass of
		/// AbstractCollection. The iterator method of this subclass returns a
		/// "wrapper object" over the iterator of map's entrySet(). The
		/// <code>size</code>
		/// method wraps the map's size method and the
		/// <code>contains</code>
		/// method wraps
		/// the map's containsValue method.
		/// </p>
		/// <p>
		/// The collection is created when this method is called for the first time
		/// and returned in response to all subsequent calls. This method may return
		/// different collections when multiple concurrent calls occur, since no
		/// synchronization is performed.
		/// </p>
		/// </remarks>
		/// <returns>a collection of the values contained in this map.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override java.util.Collection<V> values()
		{
			java.util.Collection<V> vs = _values;
			return (vs != null) ? vs : (_values = new java.util.HashMap<K, V>.Values(this));
		}

		/// <summary>Returns a set containing all of the mappings in this map.</summary>
		/// <remarks>
		/// Returns a set containing all of the mappings in this map. Each mapping is
		/// an instance of
		/// <see cref="Entry{K, V}">Entry&lt;K, V&gt;</see>
		/// . As the set is backed by this map,
		/// changes in one will be reflected in the other.
		/// </remarks>
		/// <returns>a set of the mappings.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
		{
			java.util.Set<java.util.MapClass.Entry<K, V>> es = _entrySet;
			return (es != null) ? es : (_entrySet = new java.util.HashMap<K, V>.EntrySet(this
				));
		}

		private abstract class HashIterator
		{
			internal int nextIndex;

			internal java.util.HashMap.HashMapEntry<K, V> _nextEntry;

			internal java.util.HashMap.HashMapEntry<K, V> lastEntryReturned;

			internal int expectedModCount;

			internal HashIterator(HashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
				_nextEntry = this._enclosing.entryForNullKey;
				expectedModCount = this._enclosing.modCount;
				if (this._nextEntry == null)
				{
					java.util.HashMap.HashMapEntry<K, V>[] tab = this._enclosing.table;
					java.util.HashMap.HashMapEntry<K, V> next = null;
					while (next == null && this.nextIndex < tab.Length)
					{
						next = tab[this.nextIndex++];
					}
					this._nextEntry = next;
				}
			}

			public virtual bool hasNext()
			{
				return this._nextEntry != null;
			}

			internal virtual java.util.HashMap.HashMapEntry<K, V> nextEntry()
			{
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				if (this._nextEntry == null)
				{
					throw new java.util.NoSuchElementException();
				}
				java.util.HashMap.HashMapEntry<K, V> entryToReturn = this._nextEntry;
				java.util.HashMap.HashMapEntry<K, V>[] tab = this._enclosing.table;
				java.util.HashMap.HashMapEntry<K, V> next = entryToReturn.next;
				while (next == null && this.nextIndex < tab.Length)
				{
					next = tab[this.nextIndex++];
				}
				this._nextEntry = next;
				return this.lastEntryReturned = entryToReturn;
			}

			public virtual void remove()
			{
				if (this.lastEntryReturned == null)
				{
					throw new System.InvalidOperationException();
				}
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				this._enclosing.remove(this.lastEntryReturned.key);
				this.lastEntryReturned = null;
				this.expectedModCount = this._enclosing.modCount;
			}

			private readonly HashMap<K, V> _enclosing;
		}

		private sealed class KeyIterator : java.util.HashMap<K, V>.HashIterator, java.util.Iterator
			<K>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public K next()
			{
				return this.nextEntry().key;
			}

			internal KeyIterator(HashMap<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly HashMap<K, V> _enclosing;
		}

		private sealed class ValueIterator : java.util.HashMap<K, V>.HashIterator, java.util.Iterator
			<V>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public V next()
			{
				return this.nextEntry().value;
			}

			internal ValueIterator(HashMap<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly HashMap<K, V> _enclosing;
		}

		private sealed class EntryIterator : java.util.HashMap<K, V>.HashIterator, java.util.Iterator
			<java.util.MapClass.Entry<K, V>>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public java.util.MapClass.Entry<K, V> next()
			{
				return this.nextEntry();
			}

			internal EntryIterator(HashMap<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly HashMap<K, V> _enclosing;
		}

		/// <summary>Returns true if this map contains the specified mapping.</summary>
		/// <remarks>Returns true if this map contains the specified mapping.</remarks>
		private bool containsMapping(object key, object value)
		{
			if (key == null)
			{
				java.util.HashMap.HashMapEntry<K, V> e = entryForNullKey;
				return e != null && libcore.util.Objects.equal(value, e.value);
			}
			int hash = secondaryHash(key.GetHashCode());
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			int index = hash & (tab.Length - 1);
			{
				for (java.util.HashMap.HashMapEntry<K, V> e_1 = tab[index]; e_1 != null; e_1 = e_1
					.next)
				{
					if (e_1.hash == hash && key.Equals(e_1.key))
					{
						return libcore.util.Objects.equal(value, e_1.value);
					}
				}
			}
			return false;
		}

		// No entry for key
		/// <summary>
		/// Removes the mapping from key to value and returns true if this mapping
		/// exists; otherwise, returns does nothing and returns false.
		/// </summary>
		/// <remarks>
		/// Removes the mapping from key to value and returns true if this mapping
		/// exists; otherwise, returns does nothing and returns false.
		/// </remarks>
		private bool removeMapping(object key, object value)
		{
			if (key == null)
			{
				java.util.HashMap.HashMapEntry<K, V> e = entryForNullKey;
				if (e == null || !libcore.util.Objects.equal(value, e.value))
				{
					return false;
				}
				entryForNullKey = null;
				modCount++;
				_size--;
				postRemove(e);
				return true;
			}
			int hash = secondaryHash(key.GetHashCode());
			java.util.HashMap.HashMapEntry<K, V>[] tab = table;
			int index = hash & (tab.Length - 1);
			{
				java.util.HashMap.HashMapEntry<K, V> e_1 = tab[index];
				java.util.HashMap.HashMapEntry<K, V> prev = null;
				for (; e_1 != null; prev = e_1, e_1 = e_1.next)
				{
					if (e_1.hash == hash && key.Equals(e_1.key))
					{
						if (!libcore.util.Objects.equal(value, e_1.value))
						{
							return false;
						}
						// Map has wrong value for key
						if (prev == null)
						{
							tab[index] = e_1.next;
						}
						else
						{
							prev.next = e_1.next;
						}
						modCount++;
						_size--;
						postRemove(e_1);
						return true;
					}
				}
			}
			return false;
		}

		// No entry for key
		// Subclass (LinkedHashMap) overrides these for correct iteration order
		internal virtual java.util.Iterator<K> newKeyIterator()
		{
			return new java.util.HashMap<K, V>.KeyIterator(this);
		}

		internal virtual java.util.Iterator<V> newValueIterator()
		{
			return new java.util.HashMap<K, V>.ValueIterator(this);
		}

		internal virtual java.util.Iterator<java.util.MapClass.Entry<K, V>> newEntryIterator
			()
		{
			return new java.util.HashMap<K, V>.EntryIterator(this);
		}

		private sealed class KeySet : java.util.AbstractSet<K>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<K> iterator()
			{
				return this._enclosing.newKeyIterator();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing._size;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool isEmpty()
			{
				return this._enclosing._size == 0;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object o)
			{
				return this._enclosing.containsKey(o);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool remove(object o)
			{
				int oldSize = this._enclosing._size;
				this._enclosing.remove(o);
				return this._enclosing._size != oldSize;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				this._enclosing.clear();
			}

			internal KeySet(HashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly HashMap<K, V> _enclosing;
		}

		private sealed class Values : java.util.AbstractCollection<V>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<V> iterator()
			{
				return this._enclosing.newValueIterator();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing._size;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool isEmpty()
			{
				return this._enclosing._size == 0;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object o)
			{
				return this._enclosing.containsValue(o);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				this._enclosing.clear();
			}

			internal Values(HashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly HashMap<K, V> _enclosing;
		}

		private sealed class EntrySet : java.util.AbstractSet<java.util.MapClass.Entry<K, 
			V>>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<java.util.MapClass.Entry<K, V>> iterator()
			{
				return this._enclosing.newEntryIterator();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object o)
			{
				if (!(o is java.util.MapClass.Entry<K, V>))
				{
					return false;
				}
				java.util.MapClass.Entry<object, object> e = (java.util.MapClass.Entry<object, object
					>)o;
				return this._enclosing.containsMapping(e.getKey(), e.getValue());
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool remove(object o)
			{
				if (!(o is java.util.MapClass.Entry<K, V>))
				{
					return false;
				}
				java.util.MapClass.Entry<object, object> e = (java.util.MapClass.Entry<object, object
					>)o;
				return this._enclosing.removeMapping(e.getKey(), e.getValue());
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing._size;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool isEmpty()
			{
				return this._enclosing._size == 0;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				this._enclosing.clear();
			}

			internal EntrySet(HashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly HashMap<K, V> _enclosing;
		}

		/// <summary>
		/// Applies a supplemental hash function to a given hashCode, which defends
		/// against poor quality hash functions.
		/// </summary>
		/// <remarks>
		/// Applies a supplemental hash function to a given hashCode, which defends
		/// against poor quality hash functions. This is critical because HashMap
		/// uses power-of-two length hash tables, that otherwise encounter collisions
		/// for hashCodes that do not differ in lower or upper bits.
		/// </remarks>
		private static int secondaryHash(int h)
		{
			// Doug Lea's supplemental hash function
			h ^= ((int)(((uint)h) >> 20)) ^ ((int)(((uint)h) >> 12));
			return h ^ ((int)(((uint)h) >> 7)) ^ ((int)(((uint)h) >> 4));
		}

		/// <summary>
		/// Returns the smallest power of two &gt;= its argument, with several caveats:
		/// If the argument is negative but not Integer.MIN_VALUE, the method returns
		/// zero.
		/// </summary>
		/// <remarks>
		/// Returns the smallest power of two &gt;= its argument, with several caveats:
		/// If the argument is negative but not Integer.MIN_VALUE, the method returns
		/// zero. If the argument is &gt; 2^30 or equal to Integer.MIN_VALUE, the method
		/// returns Integer.MIN_VALUE. If the argument is zero, the method returns
		/// zero.
		/// </remarks>
		private static int roundUpToPowerOfTwo(int i)
		{
			i--;
			// If input is a power of two, shift its high-order bit right
			// "Smear" the high-order bit all the way to the right
			i |= (int)(((uint)i) >> 1);
			i |= (int)(((uint)i) >> 2);
			i |= (int)(((uint)i) >> 4);
			i |= (int)(((uint)i) >> 8);
			i |= (int)(((uint)i) >> 16);
			return i + 1;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			// Emulate loadFactor field for other implementations to read
			java.io.ObjectOutputStream.PutField fields = stream.putFields();
			fields.put("loadFactor", java.util.HashMap.DEFAULT_LOAD_FACTOR);
			stream.writeFields();
			stream.writeInt(table.Length);
			// Capacity
			stream.writeInt(_size);
			foreach (java.util.MapClass.Entry<K, V> e in Sharpen.IterableProxy.Create(entrySet
				()))
			{
				stream.writeObject(e.getKey());
				stream.writeObject(e.getValue());
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream stream)
		{
			stream.defaultReadObject();
			int capacity = stream.readInt();
			if (capacity < 0)
			{
				throw new java.io.InvalidObjectException("Capacity: " + capacity);
			}
			if (capacity < java.util.HashMap.MINIMUM_CAPACITY)
			{
				capacity = java.util.HashMap.MINIMUM_CAPACITY;
			}
			else
			{
				if (capacity > java.util.HashMap.MAXIMUM_CAPACITY)
				{
					capacity = java.util.HashMap.MAXIMUM_CAPACITY;
				}
				else
				{
					capacity = roundUpToPowerOfTwo(capacity);
				}
			}
			makeTable(capacity);
			int size_1 = stream.readInt();
			if (size_1 < 0)
			{
				throw new java.io.InvalidObjectException("Size: " + size_1);
			}
			init();
			{
				// Give subclass (LinkedHashMap) a chance to initialize itself
				for (int i = 0; i < size_1; i++)
				{
					K key = (K)stream.readObject();
					V val = (V)stream.readObject();
					constructorPut(key, val);
				}
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
