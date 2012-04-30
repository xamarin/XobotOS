using Sharpen;

namespace java.util
{
	/// <summary>WeakHashMap is an implementation of Map with keys which are WeakReferences.
	/// 	</summary>
	/// <remarks>
	/// WeakHashMap is an implementation of Map with keys which are WeakReferences. A
	/// key/value mapping is removed when the key is no longer referenced. All
	/// optional operations (adding and removing) are supported. Keys and values can
	/// be any objects. Note that the garbage collector acts similar to a second
	/// thread on this collection, possibly removing keys.
	/// </remarks>
	/// <since>1.2</since>
	/// <seealso cref="HashMap{K, V}">HashMap&lt;K, V&gt;</seealso>
	/// <seealso cref="java.lang.@ref.WeakReference{T}">java.lang.@ref.WeakReference&lt;T&gt;
	/// 	</seealso>
	[Sharpen.Sharpened]
	public static partial class WeakHashMap
	{
		internal const int DEFAULT_SIZE = 16;

		internal static partial class Entry
		{
			internal interface Type<R, K, V>
			{
				// Simple utility method to isolate unchecked cast for array creation
				R get(java.util.MapClass.Entry<K, V> entry);
			}
		}

		internal sealed partial class Entry<K, V> : java.lang.@ref.WeakReference<K>, java.util.MapClass
			.Entry<K, V>
		{
			internal int hash;

			internal bool isNull;

			internal V value;

			internal java.util.WeakHashMap.Entry<K, V> next;

			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public K getKey()
			{
				return base.get();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public V getValue()
			{
				return value;
			}

			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public V setValue(V @object)
			{
				V result = value;
				value = @object;
				return result;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return hash + ((object)value == null ? 0 : value.GetHashCode());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return base.get() + "=" + value;
			}
		}
	}

	/// <summary>WeakHashMap is an implementation of Map with keys which are WeakReferences.
	/// 	</summary>
	/// <remarks>
	/// WeakHashMap is an implementation of Map with keys which are WeakReferences. A
	/// key/value mapping is removed when the key is no longer referenced. All
	/// optional operations (adding and removing) are supported. Keys and values can
	/// be any objects. Note that the garbage collector acts similar to a second
	/// thread on this collection, possibly removing keys.
	/// </remarks>
	/// <since>1.2</since>
	/// <seealso cref="HashMap{K, V}">HashMap&lt;K, V&gt;</seealso>
	/// <seealso cref="java.lang.@ref.WeakReference{T}">java.lang.@ref.WeakReference&lt;T&gt;
	/// 	</seealso>
	[Sharpen.Sharpened]
	public partial class WeakHashMap<K, V> : java.util.AbstractMap<K, V>, java.util.Map
		<K, V>
	{
		private readonly java.lang.@ref.ReferenceQueue<K> referenceQueue;

		internal int elementCount;

		private java.util.WeakHashMap.Entry<K, V>[] elementData;

		private readonly int loadFactor;

		private int threshold;

		internal volatile int modCount;

		internal class HashIterator<R> : java.util.Iterator<R>
		{
			private int position;

			private int expectedModCount;

			private java.util.WeakHashMap.Entry<K, V> currentEntry;

			private java.util.WeakHashMap.Entry<K, V> nextEntry;

			private K nextKey;

			internal readonly java.util.WeakHashMap.Entry.Type<R, K, V> type;

			internal HashIterator(WeakHashMap<K, V> _enclosing, java.util.WeakHashMap.Entry.Type
				<R, K, V> type)
			{
				this._enclosing = _enclosing;
				position = 0;
				this.type = type;
				this.expectedModCount = this._enclosing.modCount;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				if (this.nextEntry != null && ((object)this.nextKey != null || this.nextEntry.isNull
					))
				{
					return true;
				}
				while (true)
				{
					if (this.nextEntry == null)
					{
						while (this.position < this._enclosing.elementData.Length)
						{
							if ((this.nextEntry = this._enclosing.elementData[this.position++]) != null)
							{
								break;
							}
						}
						if (this.nextEntry == null)
						{
							return false;
						}
					}
					// ensure key of next entry is not gc'ed
					this.nextKey = this.nextEntry.get();
					if ((object)this.nextKey != null || this.nextEntry.isNull)
					{
						return true;
					}
					this.nextEntry = this.nextEntry.next;
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual R next()
			{
				if (this.expectedModCount == this._enclosing.modCount)
				{
					if (this.hasNext())
					{
						this.currentEntry = this.nextEntry;
						this.nextEntry = this.currentEntry.next;
						R result = this.type.get(this.currentEntry);
						// free the key
						this.nextKey = default(K);
						return result;
					}
					throw new java.util.NoSuchElementException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				if (this.expectedModCount == this._enclosing.modCount)
				{
					if (this.currentEntry != null)
					{
						this._enclosing.removeEntry(this.currentEntry);
						this.currentEntry = null;
						this.expectedModCount++;
					}
					else
					{
						// cannot poll() as that would change the expectedModCount
						throw new System.InvalidOperationException();
					}
				}
				else
				{
					throw new java.util.ConcurrentModificationException();
				}
			}

			private readonly WeakHashMap<K, V> _enclosing;
		}

		/// <summary>
		/// Constructs a new empty
		/// <code>WeakHashMap</code>
		/// instance.
		/// </summary>
		public WeakHashMap() : this(java.util.WeakHashMap.DEFAULT_SIZE)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>WeakHashMap</code>
		/// instance with the specified
		/// capacity.
		/// </summary>
		/// <param name="capacity">the initial capacity of this map.</param>
		/// <exception cref="System.ArgumentException">if the capacity is less than zero.</exception>
		public WeakHashMap(int capacity)
		{
			if (capacity >= 0)
			{
				elementCount = 0;
				elementData = newEntryArray(capacity == 0 ? 1 : capacity);
				loadFactor = 7500;
				// Default load factor of 0.75
				computeMaxSize();
				referenceQueue = new java.lang.@ref.ReferenceQueue<K>();
			}
			else
			{
				throw new System.ArgumentException();
			}
		}

		/// <summary>
		/// Constructs a new
		/// <code>WeakHashMap</code>
		/// instance with the specified capacity
		/// and load factor.
		/// </summary>
		/// <param name="capacity">the initial capacity of this map.</param>
		/// <param name="loadFactor">the initial load factor.</param>
		/// <exception cref="System.ArgumentException">
		/// if the capacity is less than zero or the load factor is less
		/// or equal to zero.
		/// </exception>
		public WeakHashMap(int capacity, float loadFactor)
		{
			if (capacity >= 0 && loadFactor > 0)
			{
				elementCount = 0;
				elementData = newEntryArray(capacity == 0 ? 1 : capacity);
				this.loadFactor = (int)(loadFactor * 10000);
				computeMaxSize();
				referenceQueue = new java.lang.@ref.ReferenceQueue<K>();
			}
			else
			{
				throw new System.ArgumentException();
			}
		}

		/// <summary>
		/// Constructs a new
		/// <code>WeakHashMap</code>
		/// instance containing the mappings
		/// from the specified map.
		/// </summary>
		/// <param name="map">the mappings to add.</param>
		public WeakHashMap(java.util.Map<K, V> map) : this(map.size() < 6 ? 11 : map.size
			() * 2)
		{
			putAllImpl(map);
		}

		/// <summary>Removes all mappings from this map, leaving it empty.</summary>
		/// <remarks>Removes all mappings from this map, leaving it empty.</remarks>
		/// <seealso cref="WeakHashMap{K, V}.isEmpty()">WeakHashMap&lt;K, V&gt;.isEmpty()</seealso>
		/// <seealso cref="WeakHashMap{K, V}.size()">WeakHashMap&lt;K, V&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override void clear()
		{
			if (elementCount > 0)
			{
				elementCount = 0;
				java.util.Arrays.fill(elementData, null);
				modCount++;
				while (referenceQueue.poll() != null)
				{
				}
			}
		}

		// do nothing
		private void computeMaxSize()
		{
			threshold = (int)((long)elementData.Length * loadFactor / 10000);
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
			return getEntry(key) != null;
		}

		private sealed class _AbstractSet_294 : java.util.AbstractSet<java.util.MapClass.
			Entry<K, V>>
		{
			public _AbstractSet_294(WeakHashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
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
			public override bool remove(object @object)
			{
				if (this.contains(@object))
				{
					this._enclosing.remove(((java.util.MapClass.Entry<object, object>)@object).getKey
						());
					return true;
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object @object)
			{
				if (@object is java.util.MapClass.Entry<K, V>)
				{
					java.util.WeakHashMap.Entry<K, V> entry = this._enclosing.getEntry(((java.util.MapClass
						.Entry<object, object>)@object).getKey());
					if (entry != null)
					{
						object key = entry.get();
						if (key != null || entry.isNull)
						{
							return @object.Equals(entry);
						}
					}
				}
				return false;
			}

			private sealed class _Type_333 : java.util.WeakHashMap.Entry.Type<java.util.MapClass
				.Entry<K, V>, K, V>
			{
				public _Type_333()
				{
				}

				[Sharpen.ImplementsInterface(@"java.util.WeakHashMap.Entry.Type")]
				public java.util.MapClass.Entry<K, V> get(java.util.MapClass.Entry<K, V> entry)
				{
					return entry;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<java.util.MapClass.Entry<K, V>> iterator()
			{
				return new java.util.WeakHashMap<K, V>.HashIterator<java.util.MapClass.Entry<K, V
					>>(this._enclosing, new _Type_333());
			}

			private readonly WeakHashMap<K, V> _enclosing;
		}

		/// <summary>Returns a set containing all of the mappings in this map.</summary>
		/// <remarks>
		/// Returns a set containing all of the mappings in this map. Each mapping is
		/// an instance of
		/// <see cref="Entry{K, V}">Entry&lt;K, V&gt;</see>
		/// . As the set is backed by this map,
		/// changes in one will be reflected in the other. It does not support adding
		/// operations.
		/// </remarks>
		/// <returns>a set of the mappings.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
		{
			poll();
			return new _AbstractSet_294(this);
		}

		private sealed class _AbstractSet_353 : java.util.AbstractSet<K>
		{
			public _AbstractSet_353(WeakHashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object @object)
			{
				return this._enclosing.containsKey(@object);
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
			public override bool remove(object key)
			{
				if (this._enclosing.containsKey(key))
				{
					this._enclosing.remove(key);
					return true;
				}
				return false;
			}

			private sealed class _Type_380 : java.util.WeakHashMap.Entry.Type<K, K, V>
			{
				public _Type_380()
				{
				}

				[Sharpen.ImplementsInterface(@"java.util.WeakHashMap.Entry.Type")]
				public K get(java.util.MapClass.Entry<K, V> entry)
				{
					return entry.getKey();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<K> iterator()
			{
				return new java.util.WeakHashMap<K, V>.HashIterator<K>(this._enclosing, new _Type_380
					());
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override object[] toArray()
			{
				java.util.Collection<K> coll = new java.util.ArrayList<K>(this.size());
				{
					for (java.util.Iterator<K> iter = this.iterator(); iter.hasNext(); )
					{
						coll.add(iter.next());
					}
				}
				return coll.toArray();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override T[] toArray<T>(T[] contents)
			{
				java.util.Collection<K> coll = new java.util.ArrayList<K>(this.size());
				{
					for (java.util.Iterator<K> iter = this.iterator(); iter.hasNext(); )
					{
						coll.add(iter.next());
					}
				}
				return coll.toArray<T>(contents);
			}

			private readonly WeakHashMap<K, V> _enclosing;
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
			poll();
			if (_keySet == null)
			{
				_keySet = new _AbstractSet_353(this);
			}
			return _keySet;
		}

		private sealed class _AbstractCollection_434 : java.util.AbstractCollection<V>
		{
			public _AbstractCollection_434(WeakHashMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
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
			public override bool contains(object @object)
			{
				return this._enclosing.containsValue(@object);
			}

			private sealed class _Type_452 : java.util.WeakHashMap.Entry.Type<V, K, V>
			{
				public _Type_452()
				{
				}

				[Sharpen.ImplementsInterface(@"java.util.WeakHashMap.Entry.Type")]
				public V get(java.util.MapClass.Entry<K, V> entry)
				{
					return entry.getValue();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<V> iterator()
			{
				return new java.util.WeakHashMap<K, V>.HashIterator<V>(this._enclosing, new _Type_452
					());
			}

			private readonly WeakHashMap<K, V> _enclosing;
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
		/// "wrapper object" over the iterator of map's entrySet(). The size method
		/// wraps the map's size method and the contains method wraps the map's
		/// containsValue method.
		/// <p>
		/// The collection is created when this method is called at first time and
		/// returned in response to all subsequent calls. This method may return
		/// different Collection when multiple calls to this method, since it has no
		/// synchronization performed.
		/// </remarks>
		/// <returns>a collection of the values contained in this map.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override java.util.Collection<V> values()
		{
			poll();
			if (valuesCollection == null)
			{
				valuesCollection = new _AbstractCollection_434(this);
			}
			return valuesCollection;
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
			poll();
			if (key != null)
			{
				int index = (key.GetHashCode() & unchecked((int)(0x7FFFFFFF))) % elementData.Length;
				java.util.WeakHashMap.Entry<K, V> entry = elementData[index];
				while (entry != null)
				{
					if (key.Equals(entry.get()))
					{
						return entry.value;
					}
					entry = entry.next;
				}
				return default(V);
			}
			java.util.WeakHashMap.Entry<K, V> entry_1 = elementData[0];
			while (entry_1 != null)
			{
				if (entry_1.isNull)
				{
					return entry_1.value;
				}
				entry_1 = entry_1.next;
			}
			return default(V);
		}

		private java.util.WeakHashMap.Entry<K, V> getEntry(object key)
		{
			poll();
			if (key != null)
			{
				int index = (key.GetHashCode() & unchecked((int)(0x7FFFFFFF))) % elementData.Length;
				java.util.WeakHashMap.Entry<K, V> entry = elementData[index];
				while (entry != null)
				{
					if (key.Equals(entry.get()))
					{
						return entry;
					}
					entry = entry.next;
				}
				return null;
			}
			java.util.WeakHashMap.Entry<K, V> entry_1 = elementData[0];
			while (entry_1 != null)
			{
				if (entry_1.isNull)
				{
					return entry_1;
				}
				entry_1 = entry_1.next;
			}
			return null;
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
			poll();
			if (value != null)
			{
				{
					for (int i = elementData.Length; --i >= 0; )
					{
						java.util.WeakHashMap.Entry<K, V> entry = elementData[i];
						while (entry != null)
						{
							K key = entry.get();
							if (((object)key != null || entry.isNull) && value.Equals(entry.value))
							{
								return true;
							}
							entry = entry.next;
						}
					}
				}
			}
			else
			{
				{
					for (int i = elementData.Length; --i >= 0; )
					{
						java.util.WeakHashMap.Entry<K, V> entry = elementData[i];
						while (entry != null)
						{
							K key = entry.get();
							if (((object)key != null || entry.isNull) && (object)entry.value == null)
							{
								return true;
							}
							entry = entry.next;
						}
					}
				}
			}
			return false;
		}

		/// <summary>Returns the number of elements in this map.</summary>
		/// <remarks>Returns the number of elements in this map.</remarks>
		/// <returns>the number of elements in this map.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override bool isEmpty()
		{
			return size() == 0;
		}

		private void removeEntry(java.util.WeakHashMap.Entry<K, V> toRemove)
		{
			java.util.WeakHashMap.Entry<K, V> entry;
			java.util.WeakHashMap.Entry<K, V> last = null;
			int index = (toRemove.hash & unchecked((int)(0x7FFFFFFF))) % elementData.Length;
			entry = elementData[index];
			// Ignore queued entries which cannot be found, the user could
			// have removed them before they were queued, i.e. using clear()
			while (entry != null)
			{
				if (toRemove == entry)
				{
					modCount++;
					if (last == null)
					{
						elementData[index] = entry.next;
					}
					else
					{
						last.next = entry.next;
					}
					elementCount--;
					break;
				}
				last = entry;
				entry = entry.next;
			}
		}

		/// <summary>Maps the specified key to the specified value.</summary>
		/// <remarks>Maps the specified key to the specified value.</remarks>
		/// <param name="key">the key.</param>
		/// <param name="value">the value.</param>
		/// <returns>
		/// the value of any previous mapping with the specified key or
		/// <code>null</code>
		/// if there was no mapping.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override V put(K key, V value)
		{
			poll();
			int index = 0;
			java.util.WeakHashMap.Entry<K, V> entry;
			if ((object)key != null)
			{
				index = (key.GetHashCode() & unchecked((int)(0x7FFFFFFF))) % elementData.Length;
				entry = elementData[index];
				while (entry != null && !key.Equals(entry.get()))
				{
					entry = entry.next;
				}
			}
			else
			{
				entry = elementData[0];
				while (entry != null && !entry.isNull)
				{
					entry = entry.next;
				}
			}
			if (entry == null)
			{
				modCount++;
				if (++elementCount > threshold)
				{
					rehash();
					index = (object)key == null ? 0 : (key.GetHashCode() & unchecked((int)(0x7FFFFFFF
						))) % elementData.Length;
				}
				entry = new java.util.WeakHashMap.Entry<K, V>(key, value, referenceQueue);
				entry.next = elementData[index];
				elementData[index] = entry;
				return default(V);
			}
			V result = entry.value;
			entry.value = value;
			return result;
		}

		private void rehash()
		{
			int length = elementData.Length * 2;
			if (length == 0)
			{
				length = 1;
			}
			java.util.WeakHashMap.Entry<K, V>[] newData = newEntryArray(length);
			{
				for (int i = 0; i < elementData.Length; i++)
				{
					java.util.WeakHashMap.Entry<K, V> entry = elementData[i];
					while (entry != null)
					{
						int index = entry.isNull ? 0 : (entry.hash & unchecked((int)(0x7FFFFFFF))) % length;
						java.util.WeakHashMap.Entry<K, V> next = entry.next;
						entry.next = newData[index];
						newData[index] = entry;
						entry = next;
					}
				}
			}
			elementData = newData;
			computeMaxSize();
		}

		/// <summary>Copies all the mappings in the given map to this map.</summary>
		/// <remarks>
		/// Copies all the mappings in the given map to this map. These mappings will
		/// replace all mappings that this map had for any of the keys currently in
		/// the given map.
		/// </remarks>
		/// <param name="map">the map to copy mappings from.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>map</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override void putAll<_T0, _T1>(java.util.Map<_T0, _T1> map)
		{
			putAllImpl(map);
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
			poll();
			int index = 0;
			java.util.WeakHashMap.Entry<K, V> entry;
			java.util.WeakHashMap.Entry<K, V> last = null;
			if (key != null)
			{
				index = (key.GetHashCode() & unchecked((int)(0x7FFFFFFF))) % elementData.Length;
				entry = elementData[index];
				while (entry != null && !key.Equals(entry.get()))
				{
					last = entry;
					entry = entry.next;
				}
			}
			else
			{
				entry = elementData[0];
				while (entry != null && !entry.isNull)
				{
					last = entry;
					entry = entry.next;
				}
			}
			if (entry != null)
			{
				modCount++;
				if (last == null)
				{
					elementData[index] = entry.next;
				}
				else
				{
					last.next = entry.next;
				}
				elementCount--;
				return entry.value;
			}
			return default(V);
		}

		/// <summary>Returns the number of elements in this map.</summary>
		/// <remarks>Returns the number of elements in this map.</remarks>
		/// <returns>the number of elements in this map.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override int size()
		{
			poll();
			return elementCount;
		}

		private void putAllImpl<_T0, _T1>(java.util.Map<_T0, _T1> map) where _T0:K where 
			_T1:V
		{
			if (map.entrySet() != null)
			{
				base.putAll(map);
			}
		}
	}
}
