using Sharpen;

namespace java.util
{
	/// <summary>
	/// Hashtable is a synchronized implementation of
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// . All optional operations are supported.
	/// <p>Neither keys nor values can be null. (Use
	/// <code>HashMap</code>
	/// or
	/// <code>LinkedHashMap</code>
	/// if you
	/// need null keys or values.)
	/// </summary>
	/// <?></?>
	/// <?></?>
	/// <seealso cref="HashMap{K, V}">HashMap&lt;K, V&gt;</seealso>
	[Sharpen.Sharpened]
	public static partial class Hashtable
	{
		/// <summary>Min capacity (other than zero) for a Hashtable.</summary>
		/// <remarks>
		/// Min capacity (other than zero) for a Hashtable. Must be a power of two
		/// greater than 1 (and less than 1 &lt;&lt; 30).
		/// </remarks>
		internal const int MINIMUM_CAPACITY = 4;

		/// <summary>Max capacity for a Hashtable.</summary>
		/// <remarks>Max capacity for a Hashtable. Must be a power of two &gt;= MINIMUM_CAPACITY.
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

		/// <summary>
		/// Note: technically the methods of this class should synchronize the
		/// backing map.
		/// </summary>
		/// <remarks>
		/// Note: technically the methods of this class should synchronize the
		/// backing map.  However, this would require them to have a reference
		/// to it, which would cause considerable bloat.  Moreover, the RI
		/// behaves the same way.
		/// </remarks>
		internal class HashtableEntry<K, V> : java.util.MapClass.Entry<K, V>
		{
			internal readonly K key;

			internal V value;

			internal readonly int hash;

			internal java.util.Hashtable.HashtableEntry<K, V> next;

			internal HashtableEntry(K key, V value, int hash, java.util.Hashtable.HashtableEntry
				<K, V> next)
			{
				// Views - lazily initialized
				// Forces first put invocation to replace EMPTY_TABLE
				// Forces first put() to replace EMPTY_TABLE
				// Multiply by 3/2 to allow for growth
				// boolean expr is equivalent to result >= 0 && result<MAXIMUM_CAPACITY
				// Restore clone to empty state, retaining our capacity and threshold
				// Doug Lea's supplemental secondaryHash function (inlined)
				// Doug Lea's supplemental secondaryHash function (inlined)
				// No entry for key is present; create one
				// Does nothing!!
				// No entry for key is present; create one
				// Does nothing!!
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
				if ((object)value == null)
				{
					throw new System.ArgumentNullException();
				}
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
				return key.Equals(e.getKey()) && value.Equals(e.getValue());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public sealed override int GetHashCode()
			{
				return key.GetHashCode() ^ value.GetHashCode();
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public sealed override string ToString()
			{
				return key + "=" + value;
			}
		}

		/// <summary>
		/// A rough estimate of the number of characters per entry, for use
		/// when creating a string buffer in the toString method.
		/// </summary>
		/// <remarks>
		/// A rough estimate of the number of characters per entry, for use
		/// when creating a string buffer in the toString method.
		/// </remarks>
		internal const int CHARS_PER_ENTRY = 15;

		internal const long serialVersionUID = 1421746759512286392L;
	}

	/// <summary>
	/// Hashtable is a synchronized implementation of
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// . All optional operations are supported.
	/// <p>Neither keys nor values can be null. (Use
	/// <code>HashMap</code>
	/// or
	/// <code>LinkedHashMap</code>
	/// if you
	/// need null keys or values.)
	/// </summary>
	/// <?></?>
	/// <?></?>
	/// <seealso cref="HashMap{K, V}">HashMap&lt;K, V&gt;</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public partial class Hashtable<K, V> : java.util.Dictionary<K, V>, java.util.Map<
		K, V>, System.ICloneable
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
		private static readonly java.util.MapClass.Entry<K, V>[] EMPTY_TABLE = new java.util.Hashtable
			.HashtableEntry<K, V>[(int)(((uint)java.util.Hashtable.MINIMUM_CAPACITY) >> 1)];

		/// <summary>The hash table.</summary>
		/// <remarks>The hash table.</remarks>
		[System.NonSerialized]
		private java.util.Hashtable.HashtableEntry<K, V>[] table;

		/// <summary>The number of mappings in this hash map.</summary>
		/// <remarks>The number of mappings in this hash map.</remarks>
		[System.NonSerialized]
		private int _size;

		/// <summary>
		/// Incremented by "structural modifications" to allow (best effort)
		/// detection of concurrent modification.
		/// </summary>
		/// <remarks>
		/// Incremented by "structural modifications" to allow (best effort)
		/// detection of concurrent modification.
		/// </remarks>
		[System.NonSerialized]
		private int modCount;

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
		/// Constructs a new
		/// <code>Hashtable</code>
		/// using the default capacity and load
		/// factor.
		/// </summary>
		public Hashtable()
		{
			table = (java.util.Hashtable.HashtableEntry<K, V>[])EMPTY_TABLE;
			threshold = -1;
		}

		/// <summary>
		/// Constructs a new
		/// <code>Hashtable</code>
		/// using the specified capacity and the
		/// default load factor.
		/// </summary>
		/// <param name="capacity">the initial capacity.</param>
		public Hashtable(int capacity)
		{
			if (capacity < 0)
			{
				throw new System.ArgumentException("Capacity: " + capacity);
			}
			if (capacity == 0)
			{
				java.util.Hashtable.HashtableEntry<K, V>[] tab = (java.util.Hashtable.HashtableEntry
					<K, V>[])EMPTY_TABLE;
				table = tab;
				threshold = -1;
				return;
			}
			if (capacity < java.util.Hashtable.MINIMUM_CAPACITY)
			{
				capacity = java.util.Hashtable.MINIMUM_CAPACITY;
			}
			else
			{
				if (capacity > java.util.Hashtable.MAXIMUM_CAPACITY)
				{
					capacity = java.util.Hashtable.MAXIMUM_CAPACITY;
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
		/// <code>Hashtable</code>
		/// using the specified capacity and load
		/// factor.
		/// </summary>
		/// <param name="capacity">the initial capacity.</param>
		/// <param name="loadFactor">the initial load factor.</param>
		public Hashtable(int capacity, float loadFactor) : this(capacity)
		{
			if (loadFactor <= 0 || float.IsNaN(loadFactor))
			{
				throw new System.ArgumentException("Load factor: " + loadFactor);
			}
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>Hashtable</code>
		/// containing the mappings
		/// from the specified map.
		/// </summary>
		/// <param name="map">the mappings to add.</param>
		public Hashtable(java.util.Map<K, V> map) : this(capacityForInitSize(map.size()))
		{
			constructorPutAll(map);
		}

		/// <summary>
		/// Inserts all of the elements of map into this Hashtable in a manner
		/// suitable for use by constructors and pseudo-constructors (i.e., clone,
		/// readObject).
		/// </summary>
		/// <remarks>
		/// Inserts all of the elements of map into this Hashtable in a manner
		/// suitable for use by constructors and pseudo-constructors (i.e., clone,
		/// readObject).
		/// </remarks>
		private void constructorPutAll<_T0, _T1>(java.util.Map<_T0, _T1> map) where _T0:K
			 where _T1:V
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
		private static int capacityForInitSize(int size_1)
		{
			int result = (size_1 >> 1) + size_1;
			return (result & ~(java.util.Hashtable.MAXIMUM_CAPACITY - 1)) == 0 ? result : java.util.Hashtable.MAXIMUM_CAPACITY;
		}

		/// <summary>
		/// Returns a new
		/// <code>Hashtable</code>
		/// with the same key/value pairs, capacity
		/// and load factor.
		/// </summary>
		/// <returns>
		/// a shallow copy of this
		/// <code>Hashtable</code>
		/// .
		/// </returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		public virtual object clone()
		{
			lock (this)
			{
				java.util.Hashtable<K, V> result;
				result = (java.util.Hashtable<K, V>)base.MemberwiseClone();
				result.makeTable(table.Length);
				result._size = 0;
				result._keySet = null;
				result._entrySet = null;
				result._values = null;
				result.constructorPutAll(this);
				return result;
			}
		}

		/// <summary>
		/// Returns true if this
		/// <code>Hashtable</code>
		/// has no key/value pairs.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>Hashtable</code>
		/// has no key/value pairs,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Hashtable{K, V}._size">Hashtable&lt;K, V&gt;._size</seealso>
		[Sharpen.OverridesMethod(@"java.util.Dictionary")]
		public override bool isEmpty()
		{
			lock (this)
			{
				return _size == 0;
			}
		}

		/// <summary>
		/// Returns the number of key/value pairs in this
		/// <code>Hashtable</code>
		/// .
		/// </summary>
		/// <returns>
		/// the number of key/value pairs in this
		/// <code>Hashtable</code>
		/// .
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.elements()">Hashtable&lt;K, V&gt;.elements()</seealso>
		/// <seealso cref="Hashtable{K, V}.keys()">Hashtable&lt;K, V&gt;.keys()</seealso>
		[Sharpen.OverridesMethod(@"java.util.Dictionary")]
		public override int size()
		{
			lock (this)
			{
				return _size;
			}
		}

		/// <summary>
		/// Returns the value associated with the specified key in this
		/// <code>Hashtable</code>
		/// .
		/// </summary>
		/// <param name="key">the key of the value returned.</param>
		/// <returns>
		/// the value associated with the specified key, or
		/// <code>null</code>
		/// if
		/// the specified key does not exist.
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.put(object, object)">Hashtable&lt;K, V&gt;.put(object, object)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"java.util.Dictionary")]
		public override V get(object key)
		{
			lock (this)
			{
				int hash = key.GetHashCode();
				hash ^= ((int)(((uint)hash) >> 20)) ^ ((int)(((uint)hash) >> 12));
				hash ^= ((int)(((uint)hash) >> 7)) ^ ((int)(((uint)hash) >> 4));
				java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
				{
					for (java.util.Hashtable.HashtableEntry<K, V> e = tab[hash & (tab.Length - 1)]; e
						 != null; e = e.next)
					{
						K eKey = e.key;
						if (Sharpen.Util.Equals(eKey, key) || (e.hash == hash && key.Equals(eKey)))
						{
							return e.value;
						}
					}
				}
				return default(V);
			}
		}

		/// <summary>
		/// Returns true if this
		/// <code>Hashtable</code>
		/// contains the specified object as a
		/// key of one of the key/value pairs.
		/// </summary>
		/// <param name="key">
		/// the object to look for as a key in this
		/// <code>Hashtable</code>
		/// .
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if object is a key in this
		/// <code>Hashtable</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.contains(object)">Hashtable&lt;K, V&gt;.contains(object)
		/// 	</seealso>
		/// <seealso cref="object.Equals(object)">object.Equals(object)</seealso>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual bool containsKey(object key)
		{
			lock (this)
			{
				int hash = key.GetHashCode();
				hash ^= ((int)(((uint)hash) >> 20)) ^ ((int)(((uint)hash) >> 12));
				hash ^= ((int)(((uint)hash) >> 7)) ^ ((int)(((uint)hash) >> 4));
				java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
				{
					for (java.util.Hashtable.HashtableEntry<K, V> e = tab[hash & (tab.Length - 1)]; e
						 != null; e = e.next)
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
		}

		/// <summary>
		/// Searches this
		/// <code>Hashtable</code>
		/// for the specified value.
		/// </summary>
		/// <param name="value">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>value</code>
		/// is a value of this
		/// <code>Hashtable</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual bool containsValue(object value)
		{
			lock (this)
			{
				if (value == null)
				{
					throw new System.ArgumentNullException();
				}
				java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
				int len = tab.Length;
				{
					for (int i = 0; i < len; i++)
					{
						{
							for (java.util.Hashtable.HashtableEntry<K, V> e = tab[i]; e != null; e = e.next)
							{
								if (value.Equals(e.value))
								{
									return true;
								}
							}
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		/// Returns true if this
		/// <code>Hashtable</code>
		/// contains the specified object as
		/// the value of at least one of the key/value pairs.
		/// </summary>
		/// <param name="value">
		/// the object to look for as a value in this
		/// <code>Hashtable</code>
		/// .
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if object is a value in this
		/// <code>Hashtable</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.containsKey(object)">Hashtable&lt;K, V&gt;.containsKey(object)
		/// 	</seealso>
		/// <seealso cref="object.Equals(object)">object.Equals(object)</seealso>
		public virtual bool contains(object value)
		{
			return containsValue(value);
		}

		/// <summary>
		/// Associate the specified value with the specified key in this
		/// <code>Hashtable</code>
		/// . If the key already exists, the old value is replaced.
		/// The key and value cannot be null.
		/// </summary>
		/// <param name="key">the key to add.</param>
		/// <param name="value">the value to add.</param>
		/// <returns>
		/// the old value associated with the specified key, or
		/// <code>null</code>
		/// if the key did not exist.
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.elements()">Hashtable&lt;K, V&gt;.elements()</seealso>
		/// <seealso cref="Hashtable{K, V}.get(object)">Hashtable&lt;K, V&gt;.get(object)</seealso>
		/// <seealso cref="Hashtable{K, V}.keys()">Hashtable&lt;K, V&gt;.keys()</seealso>
		/// <seealso cref="object.Equals(object)">object.Equals(object)</seealso>
		[Sharpen.OverridesMethod(@"java.util.Dictionary")]
		public override V put(K key, V value)
		{
			lock (this)
			{
				if ((object)value == null)
				{
					throw new System.ArgumentNullException();
				}
				int hash = secondaryHash(key.GetHashCode());
				java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
				int index = hash & (tab.Length - 1);
				java.util.Hashtable.HashtableEntry<K, V> first = tab[index];
				{
					for (java.util.Hashtable.HashtableEntry<K, V> e = first; e != null; e = e.next)
					{
						if (e.hash == hash && key.Equals(e.key))
						{
							V oldValue = e.value;
							e.value = value;
							return oldValue;
						}
					}
				}
				modCount++;
				if (_size++ > threshold)
				{
					rehash();
					tab = doubleCapacity();
					index = hash & (tab.Length - 1);
					first = tab[index];
				}
				tab[index] = new java.util.Hashtable.HashtableEntry<K, V>(key, value, hash, first
					);
				return default(V);
			}
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
			if ((object)value == null)
			{
				throw new System.ArgumentNullException();
			}
			int hash = secondaryHash(key.GetHashCode());
			java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
			int index = hash & (tab.Length - 1);
			java.util.Hashtable.HashtableEntry<K, V> first = tab[index];
			{
				for (java.util.Hashtable.HashtableEntry<K, V> e = first; e != null; e = e.next)
				{
					if (e.hash == hash && key.Equals(e.key))
					{
						e.value = value;
						return;
					}
				}
			}
			tab[index] = new java.util.Hashtable.HashtableEntry<K, V>(key, value, hash, first
				);
			_size++;
		}

		/// <summary>
		/// Copies every mapping to this
		/// <code>Hashtable</code>
		/// from the specified map.
		/// </summary>
		/// <param name="map">the map to copy mappings from.</param>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual void putAll<_T0, _T1>(java.util.Map<_T0, _T1> map) where _T0:K where 
			_T1:V
		{
			lock (this)
			{
				ensureCapacity(map.size());
				foreach (java.util.MapClass.Entry<K, V> e in Sharpen.IterableProxy.Create(map.entrySet
					()))
				{
					put(e.getKey(), e.getValue());
				}
			}
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
			java.util.Hashtable.HashtableEntry<K, V>[] oldTable = table;
			int oldCapacity = oldTable.Length;
			if (newCapacity <= oldCapacity)
			{
				return;
			}
			rehash();
			if (newCapacity == oldCapacity * 2)
			{
				doubleCapacity();
				return;
			}
			java.util.Hashtable.HashtableEntry<K, V>[] newTable = makeTable(newCapacity);
			if (_size != 0)
			{
				int newMask = newCapacity - 1;
				{
					for (int i = 0; i < oldCapacity; i++)
					{
						{
							for (java.util.Hashtable.HashtableEntry<K, V> e = oldTable[i]; e != null; )
							{
								java.util.Hashtable.HashtableEntry<K, V> oldNext = e.next;
								int newIndex = e.hash & newMask;
								java.util.Hashtable.HashtableEntry<K, V> newNext = newTable[newIndex];
								newTable[newIndex] = e;
								e.next = newNext;
								e = oldNext;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Increases the capacity of this
		/// <code>Hashtable</code>
		/// . This method is called
		/// when the size of this
		/// <code>Hashtable</code>
		/// exceeds the load factor.
		/// </summary>
		protected internal virtual void rehash()
		{
		}

		/// <summary>Allocate a table of the given capacity and set the threshold accordingly.
		/// 	</summary>
		/// <remarks>Allocate a table of the given capacity and set the threshold accordingly.
		/// 	</remarks>
		/// <param name="newCapacity">must be a power of two</param>
		private java.util.Hashtable.HashtableEntry<K, V>[] makeTable(int newCapacity)
		{
			java.util.Hashtable.HashtableEntry<K, V>[] newTable = (java.util.Hashtable.HashtableEntry
				<K, V>[])new java.util.Hashtable.HashtableEntry<K, V>[newCapacity];
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
		private java.util.Hashtable.HashtableEntry<K, V>[] doubleCapacity()
		{
			java.util.Hashtable.HashtableEntry<K, V>[] oldTable = table;
			int oldCapacity = oldTable.Length;
			if (oldCapacity == java.util.Hashtable.MAXIMUM_CAPACITY)
			{
				return oldTable;
			}
			int newCapacity = oldCapacity * 2;
			java.util.Hashtable.HashtableEntry<K, V>[] newTable = makeTable(newCapacity);
			if (_size == 0)
			{
				return newTable;
			}
			{
				for (int j = 0; j < oldCapacity; j++)
				{
					java.util.Hashtable.HashtableEntry<K, V> e = oldTable[j];
					if (e == null)
					{
						continue;
					}
					int highBit = e.hash & oldCapacity;
					java.util.Hashtable.HashtableEntry<K, V> broken = null;
					newTable[j | highBit] = e;
					{
						for (java.util.Hashtable.HashtableEntry<K, V> n = e.next; n != null; e = n, n = n
							.next)
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

		/// <summary>
		/// Removes the key/value pair with the specified key from this
		/// <code>Hashtable</code>
		/// .
		/// </summary>
		/// <param name="key">the key to remove.</param>
		/// <returns>
		/// the value associated with the specified key, or
		/// <code>null</code>
		/// if
		/// the specified key did not exist.
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.get(object)">Hashtable&lt;K, V&gt;.get(object)</seealso>
		/// <seealso cref="Hashtable{K, V}.put(object, object)">Hashtable&lt;K, V&gt;.put(object, object)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"java.util.Dictionary")]
		public override V remove(object key)
		{
			lock (this)
			{
				int hash = secondaryHash(key.GetHashCode());
				java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
				int index = hash & (tab.Length - 1);
				{
					java.util.Hashtable.HashtableEntry<K, V> e = tab[index];
					java.util.Hashtable.HashtableEntry<K, V> prev = null;
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
							return e.value;
						}
					}
				}
				return default(V);
			}
		}

		/// <summary>
		/// Removes all key/value pairs from this
		/// <code>Hashtable</code>
		/// , leaving the
		/// size zero and the capacity unchanged.
		/// </summary>
		/// <seealso cref="Hashtable{K, V}.isEmpty()">Hashtable&lt;K, V&gt;.isEmpty()</seealso>
		/// <seealso cref="Hashtable{K, V}._size">Hashtable&lt;K, V&gt;._size</seealso>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual void clear()
		{
			lock (this)
			{
				if (_size != 0)
				{
					java.util.Arrays.fill(table, null);
					modCount++;
					_size = 0;
				}
			}
		}

		/// <summary>
		/// Returns a set of the keys contained in this
		/// <code>Hashtable</code>
		/// . The set
		/// is backed by this
		/// <code>Hashtable</code>
		/// so changes to one are reflected by
		/// the other. The set does not support adding.
		/// </summary>
		/// <returns>a set of the keys.</returns>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual java.util.Set<K> keySet()
		{
			lock (this)
			{
				java.util.Set<K> ks = _keySet;
				return (ks != null) ? ks : (_keySet = new java.util.Hashtable<K, V>.KeySet(this));
			}
		}

		/// <summary>
		/// Returns a collection of the values contained in this
		/// <code>Hashtable</code>
		/// .
		/// The collection is backed by this
		/// <code>Hashtable</code>
		/// so changes to one are
		/// reflected by the other. The collection does not support adding.
		/// </summary>
		/// <returns>a collection of the values.</returns>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual java.util.Collection<V> values()
		{
			lock (this)
			{
				java.util.Collection<V> vs = _values;
				return (vs != null) ? vs : (_values = new java.util.Hashtable<K, V>.Values(this));
			}
		}

		/// <summary>
		/// Returns a set of the mappings contained in this
		/// <code>Hashtable</code>
		/// . Each
		/// element in the set is a
		/// <see cref="Entry{K, V}">Entry&lt;K, V&gt;</see>
		/// . The set is backed by this
		/// <code>Hashtable</code>
		/// so changes to one are reflected by the other. The set
		/// does not support adding.
		/// </summary>
		/// <returns>a set of the mappings.</returns>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
		{
			lock (this)
			{
				java.util.Set<java.util.MapClass.Entry<K, V>> es = _entrySet;
				return (es != null) ? es : (_entrySet = new java.util.Hashtable<K, V>.EntrySet(this
					));
			}
		}

		/// <summary>
		/// Returns an enumeration on the keys of this
		/// <code>Hashtable</code>
		/// instance.
		/// The results of the enumeration may be affected if the contents of this
		/// <code>Hashtable</code>
		/// are modified.
		/// </summary>
		/// <returns>
		/// an enumeration of the keys of this
		/// <code>Hashtable</code>
		/// .
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.elements()">Hashtable&lt;K, V&gt;.elements()</seealso>
		/// <seealso cref="Hashtable{K, V}._size">Hashtable&lt;K, V&gt;._size</seealso>
		/// <seealso cref="Enumeration{E}">Enumeration&lt;E&gt;</seealso>
		[Sharpen.OverridesMethod(@"java.util.Dictionary")]
		public override java.util.Enumeration<K> keys()
		{
			lock (this)
			{
				return new java.util.Hashtable<K, V>.KeyEnumeration(this);
			}
		}

		/// <summary>
		/// Returns an enumeration on the values of this
		/// <code>Hashtable</code>
		/// . The
		/// results of the Enumeration may be affected if the contents of this
		/// <code>Hashtable</code>
		/// are modified.
		/// </summary>
		/// <returns>
		/// an enumeration of the values of this
		/// <code>Hashtable</code>
		/// .
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.keys()">Hashtable&lt;K, V&gt;.keys()</seealso>
		/// <seealso cref="Hashtable{K, V}._size">Hashtable&lt;K, V&gt;._size</seealso>
		/// <seealso cref="Enumeration{E}">Enumeration&lt;E&gt;</seealso>
		[Sharpen.OverridesMethod(@"java.util.Dictionary")]
		public override java.util.Enumeration<V> elements()
		{
			lock (this)
			{
				return new java.util.Hashtable<K, V>.ValueEnumeration(this);
			}
		}

		private abstract class HashIterator
		{
			internal int nextIndex;

			internal java.util.Hashtable.HashtableEntry<K, V> _nextEntry;

			internal java.util.Hashtable.HashtableEntry<K, V> lastEntryReturned;

			internal int expectedModCount;

			internal HashIterator(Hashtable<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
				expectedModCount = this._enclosing.modCount;
				java.util.Hashtable.HashtableEntry<K, V>[] tab = this._enclosing.table;
				java.util.Hashtable.HashtableEntry<K, V> next = null;
				while (next == null && this.nextIndex < tab.Length)
				{
					next = tab[this.nextIndex++];
				}
				this._nextEntry = next;
			}

			public virtual bool hasNext()
			{
				return this._nextEntry != null;
			}

			internal virtual java.util.Hashtable.HashtableEntry<K, V> nextEntry()
			{
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				if (this._nextEntry == null)
				{
					throw new java.util.NoSuchElementException();
				}
				java.util.Hashtable.HashtableEntry<K, V> entryToReturn = this._nextEntry;
				java.util.Hashtable.HashtableEntry<K, V>[] tab = this._enclosing.table;
				java.util.Hashtable.HashtableEntry<K, V> next = entryToReturn.next;
				while (next == null && this.nextIndex < tab.Length)
				{
					next = tab[this.nextIndex++];
				}
				this._nextEntry = next;
				return this.lastEntryReturned = entryToReturn;
			}

			internal virtual java.util.Hashtable.HashtableEntry<K, V> nextEntryNotFailFast()
			{
				if (this._nextEntry == null)
				{
					throw new java.util.NoSuchElementException();
				}
				java.util.Hashtable.HashtableEntry<K, V> entryToReturn = this._nextEntry;
				java.util.Hashtable.HashtableEntry<K, V>[] tab = this._enclosing.table;
				java.util.Hashtable.HashtableEntry<K, V> next = entryToReturn.next;
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

			private readonly Hashtable<K, V> _enclosing;
		}

		private sealed class KeyIterator : java.util.Hashtable<K, V>.HashIterator, java.util.Iterator
			<K>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public K next()
			{
				return this.nextEntry().key;
			}

			internal KeyIterator(Hashtable<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		private sealed class ValueIterator : java.util.Hashtable<K, V>.HashIterator, java.util.Iterator
			<V>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public V next()
			{
				return this.nextEntry().value;
			}

			internal ValueIterator(Hashtable<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		private sealed class EntryIterator : java.util.Hashtable<K, V>.HashIterator, java.util.Iterator
			<java.util.MapClass.Entry<K, V>>
		{
			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public java.util.MapClass.Entry<K, V> next()
			{
				return this.nextEntry();
			}

			internal EntryIterator(Hashtable<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		private sealed class KeyEnumeration : java.util.Hashtable<K, V>.HashIterator, java.util.Enumeration
			<K>
		{
			[Sharpen.ImplementsInterface(@"java.util.Enumeration")]
			public bool hasMoreElements()
			{
				return this.hasNext();
			}

			[Sharpen.ImplementsInterface(@"java.util.Enumeration")]
			public K nextElement()
			{
				return this.nextEntryNotFailFast().key;
			}

			internal KeyEnumeration(Hashtable<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		private sealed class ValueEnumeration : java.util.Hashtable<K, V>.HashIterator, java.util.Enumeration
			<V>
		{
			[Sharpen.ImplementsInterface(@"java.util.Enumeration")]
			public bool hasMoreElements()
			{
				return this.hasNext();
			}

			[Sharpen.ImplementsInterface(@"java.util.Enumeration")]
			public V nextElement()
			{
				return this.nextEntryNotFailFast().value;
			}

			internal ValueEnumeration(Hashtable<K, V> _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		/// <summary>Returns true if this map contains the specified mapping.</summary>
		/// <remarks>Returns true if this map contains the specified mapping.</remarks>
		private bool containsMapping(object key, object value)
		{
			lock (this)
			{
				int hash = secondaryHash(key.GetHashCode());
				java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
				int index = hash & (tab.Length - 1);
				{
					for (java.util.Hashtable.HashtableEntry<K, V> e = tab[index]; e != null; e = e.next)
					{
						if (e.hash == hash && e.key.Equals(key))
						{
							return e.value.Equals(value);
						}
					}
				}
				return false;
			}
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
			lock (this)
			{
				int hash = secondaryHash(key.GetHashCode());
				java.util.Hashtable.HashtableEntry<K, V>[] tab = table;
				int index = hash & (tab.Length - 1);
				{
					java.util.Hashtable.HashtableEntry<K, V> e = tab[index];
					java.util.Hashtable.HashtableEntry<K, V> prev = null;
					for (; e != null; prev = e, e = e.next)
					{
						if (e.hash == hash && e.key.Equals(key))
						{
							if (!e.value.Equals(value))
							{
								return false;
							}
							// Map has wrong value for key
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
							return true;
						}
					}
				}
				return false;
			}
		}

		// No entry for key
		/// <summary>
		/// Compares this
		/// <code>Hashtable</code>
		/// with the specified object and indicates
		/// if they are equal. In order to be equal,
		/// <code>object</code>
		/// must be an
		/// instance of Map and contain the same key/value pairs.
		/// </summary>
		/// <param name="object">the object to compare with this object.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the specified object is equal to this Map,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Hashtable{K, V}.GetHashCode()">Hashtable&lt;K, V&gt;.GetHashCode()
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			lock (this)
			{
				return (@object is java.util.Map<K, V>) && entrySet().Equals(((java.util.Map<object
					, object>)@object).entrySet());
			}
		}

		private sealed class KeySet : java.util.AbstractSet<K>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<K> iterator()
			{
				return new java.util.Hashtable<K, V>.KeyIterator(this._enclosing);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing.size();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object o)
			{
				return this._enclosing.containsKey(o);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool remove(object o)
			{
				lock (this._enclosing)
				{
					int oldSize = this._enclosing._size;
					this._enclosing.remove(o);
					return this._enclosing._size != oldSize;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				this._enclosing.clear();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool removeAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return base.removeAll(collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool retainAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return base.retainAll(collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool containsAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return base.containsAll(collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				lock (this._enclosing)
				{
					return base.Equals(@object);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				lock (this._enclosing)
				{
					return base.GetHashCode();
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				lock (this._enclosing)
				{
					return base.ToString();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override object[] toArray()
			{
				lock (this._enclosing)
				{
					return base.toArray();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override T[] toArray<T>(T[] a)
			{
				lock (this._enclosing)
				{
					return base.toArray(a);
				}
			}

			internal KeySet(Hashtable<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		private sealed class Values : java.util.AbstractCollection<V>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<V> iterator()
			{
				return new java.util.Hashtable<K, V>.ValueIterator(this._enclosing);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing.size();
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

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool containsAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return base.containsAll(collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				lock (this._enclosing)
				{
					return base.ToString();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override object[] toArray()
			{
				lock (this._enclosing)
				{
					return base.toArray();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override T[] toArray<T>(T[] a)
			{
				lock (this._enclosing)
				{
					return base.toArray(a);
				}
			}

			internal Values(Hashtable<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		private sealed class EntrySet : java.util.AbstractSet<java.util.MapClass.Entry<K, 
			V>>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<java.util.MapClass.Entry<K, V>> iterator()
			{
				return new java.util.Hashtable<K, V>.EntryIterator(this._enclosing);
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
				return this._enclosing.size();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				this._enclosing.clear();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool removeAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return base.removeAll(collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool retainAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return base.retainAll(collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool containsAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return base.containsAll(collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				lock (this._enclosing)
				{
					return base.Equals(@object);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return this._enclosing.GetHashCode();
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				lock (this._enclosing)
				{
					return base.ToString();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override object[] toArray()
			{
				lock (this._enclosing)
				{
					return base.toArray();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override T[] toArray<T>(T[] a)
			{
				lock (this._enclosing)
				{
					return base.toArray(a);
				}
			}

			internal EntrySet(Hashtable<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Hashtable<K, V> _enclosing;
		}

		/// <summary>
		/// Applies a supplemental hash function to a given hashCode, which defends
		/// against poor quality hash functions.
		/// </summary>
		/// <remarks>
		/// Applies a supplemental hash function to a given hashCode, which defends
		/// against poor quality hash functions. This is critical because Hashtable
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

		private static readonly java.io.ObjectStreamField[] serialPersistentFields = new 
			java.io.ObjectStreamField[] { new java.io.ObjectStreamField("threshold", typeof(
			int)), new java.io.ObjectStreamField("loadFactor", typeof(float)) };

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			lock (this)
			{
				// Emulate loadFactor field for other implementations to read
				java.io.ObjectOutputStream.PutField fields = stream.putFields();
				fields.put("threshold", (int)(java.util.Hashtable.DEFAULT_LOAD_FACTOR * table.Length
					));
				fields.put("loadFactor", java.util.Hashtable.DEFAULT_LOAD_FACTOR);
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
			if (capacity < java.util.Hashtable.MINIMUM_CAPACITY)
			{
				capacity = java.util.Hashtable.MINIMUM_CAPACITY;
			}
			else
			{
				if (capacity > java.util.Hashtable.MAXIMUM_CAPACITY)
				{
					capacity = java.util.Hashtable.MAXIMUM_CAPACITY;
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
			{
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
