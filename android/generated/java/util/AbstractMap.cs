using Sharpen;

namespace java.util
{
	/// <summary>
	/// A base class for
	/// <code>Map</code>
	/// implementations.
	/// <p>Subclasses that permit new mappings to be added must override
	/// <see cref="AbstractMap{K, V}.put(object, object)">AbstractMap&lt;K, V&gt;.put(object, object)
	/// 	</see>
	/// .
	/// <p>The default implementations of many methods are inefficient for large
	/// maps. For example in the default implementation, each call to
	/// <see cref="AbstractMap{K, V}.get(object)">AbstractMap&lt;K, V&gt;.get(object)</see>
	/// performs a linear iteration of the entry set. Subclasses should override such
	/// methods to improve their performance.
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public static class AbstractMap
	{
		/// <summary>An immutable key-value mapping.</summary>
		/// <remarks>
		/// An immutable key-value mapping. Despite the name, this class is non-final
		/// and its subclasses may be mutable.
		/// </remarks>
		/// <since>1.6</since>
		public static class SimpleImmutableEntry
		{
			internal const long serialVersionUID = 7138329143949025153L;
		}

		/// <summary>An immutable key-value mapping.</summary>
		/// <remarks>
		/// An immutable key-value mapping. Despite the name, this class is non-final
		/// and its subclasses may be mutable.
		/// </remarks>
		/// <since>1.6</since>
		[System.Serializable]
		public class SimpleImmutableEntry<K, V> : java.util.MapClass.Entry<K, V>
		{
			private readonly K key;

			private readonly V value;

			public SimpleImmutableEntry(K theKey, V theValue)
			{
				// Lazily initialized key set.
				key = theKey;
				value = theValue;
			}

			/// <summary>
			/// Constructs an instance with the key and value of
			/// <code>copyFrom</code>
			/// .
			/// </summary>
			public SimpleImmutableEntry(java.util.MapClass.Entry<K, V> copyFrom)
			{
				key = copyFrom.getKey();
				value = copyFrom.getValue();
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

			/// <summary>
			/// This base implementation throws
			/// <code>UnsupportedOperationException</code>
			/// always.
			/// </summary>
			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public virtual V setValue(V @object)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				if (this == @object)
				{
					return true;
				}
				if (@object is java.util.MapClass.Entry<K, V>)
				{
					java.util.MapClass.Entry<object, object> entry = (java.util.MapClass.Entry<object
						, object>)@object;
					return ((object)key == null ? entry.getKey() == null : key.Equals(entry.getKey())
						) && ((object)value == null ? entry.getValue() == null : value.Equals(entry.getValue
						()));
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return ((object)key == null ? 0 : key.GetHashCode()) ^ ((object)value == null ? 0
					 : value.GetHashCode());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return key + "=" + value;
			}
		}

		/// <summary>A key-value mapping with mutable values.</summary>
		/// <remarks>A key-value mapping with mutable values.</remarks>
		/// <since>1.6</since>
		public static class SimpleEntry
		{
			internal const long serialVersionUID = -8499721149061103585L;
		}

		/// <summary>A key-value mapping with mutable values.</summary>
		/// <remarks>A key-value mapping with mutable values.</remarks>
		/// <since>1.6</since>
		[System.Serializable]
		public class SimpleEntry<K, V> : java.util.MapClass.Entry<K, V>
		{
			private readonly K key;

			private V value;

			public SimpleEntry(K theKey, V theValue)
			{
				key = theKey;
				value = theValue;
			}

			/// <summary>
			/// Constructs an instance with the key and value of
			/// <code>copyFrom</code>
			/// .
			/// </summary>
			public SimpleEntry(java.util.MapClass.Entry<K, V> copyFrom)
			{
				key = copyFrom.getKey();
				value = copyFrom.getValue();
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
			public virtual V setValue(V @object)
			{
				V result = value;
				value = @object;
				return result;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				if (this == @object)
				{
					return true;
				}
				if (@object is java.util.MapClass.Entry<K, V>)
				{
					java.util.MapClass.Entry<object, object> entry = (java.util.MapClass.Entry<object
						, object>)@object;
					return ((object)key == null ? entry.getKey() == null : key.Equals(entry.getKey())
						) && ((object)value == null ? entry.getValue() == null : value.Equals(entry.getValue
						()));
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return ((object)key == null ? 0 : key.GetHashCode()) ^ ((object)value == null ? 0
					 : value.GetHashCode());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return key + "=" + value;
			}
		}
	}

	/// <summary>
	/// A base class for
	/// <code>Map</code>
	/// implementations.
	/// <p>Subclasses that permit new mappings to be added must override
	/// <see cref="AbstractMap{K, V}.put(object, object)">AbstractMap&lt;K, V&gt;.put(object, object)
	/// 	</see>
	/// .
	/// <p>The default implementations of many methods are inefficient for large
	/// maps. For example in the default implementation, each call to
	/// <see cref="AbstractMap{K, V}.get(object)">AbstractMap&lt;K, V&gt;.get(object)</see>
	/// performs a linear iteration of the entry set. Subclasses should override such
	/// methods to improve their performance.
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public abstract class AbstractMap<K, V> : java.util.Map<K, V>
	{
		internal java.util.Set<K> _keySet;

		internal java.util.Collection<V> valuesCollection;

		protected internal AbstractMap()
		{
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation calls
		/// <code>entrySet().clear()</code>
		/// .
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual void clear()
		{
			entrySet().clear();
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation iterates its key set, looking for a key that
		/// <code>key</code>
		/// equals.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual bool containsKey(object key)
		{
			java.util.Iterator<java.util.MapClass.Entry<K, V>> it = entrySet().iterator();
			if (key != null)
			{
				while (it.hasNext())
				{
					if (key.Equals(it.next().getKey()))
					{
						return true;
					}
				}
			}
			else
			{
				while (it.hasNext())
				{
					if ((object)it.next().getKey() == null)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation iterates its entry set, looking for an entry with
		/// a value that
		/// <code>value</code>
		/// equals.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual bool containsValue(object value)
		{
			java.util.Iterator<java.util.MapClass.Entry<K, V>> it = entrySet().iterator();
			if (value != null)
			{
				while (it.hasNext())
				{
					if (value.Equals(it.next().getValue()))
					{
						return true;
					}
				}
			}
			else
			{
				while (it.hasNext())
				{
					if ((object)it.next().getValue() == null)
					{
						return true;
					}
				}
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public abstract java.util.Set<java.util.MapClass.Entry<K, V>> entrySet();

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation first checks the structure of
		/// <code>object</code>
		/// . If
		/// it is not a map or of a different size, this returns false. Otherwise it
		/// iterates its own entry set, looking up each entry's key in
		/// <code>object</code>
		/// . If any value does not equal the other map's value for the same
		/// key, this returns false. Otherwise it returns true.
		/// </summary>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			if (this == @object)
			{
				return true;
			}
			if (@object is java.util.Map<K, V>)
			{
				java.util.Map<object, object> map = (java.util.Map<object, object>)@object;
				if (size() != map.size())
				{
					return false;
				}
				try
				{
					foreach (java.util.MapClass.Entry<K, V> entry in Sharpen.IterableProxy.Create(entrySet
						()))
					{
						K key = entry.getKey();
						V mine = entry.getValue();
						object theirs = map.get(key);
						if ((object)mine == null)
						{
							if (theirs != null || !map.containsKey(key))
							{
								return false;
							}
						}
						else
						{
							if (!mine.Equals(theirs))
							{
								return false;
							}
						}
					}
				}
				catch (System.ArgumentNullException)
				{
					return false;
				}
				catch (System.InvalidCastException)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation iterates its entry set, looking for an entry with
		/// a key that
		/// <code>key</code>
		/// equals.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual V get(object key)
		{
			java.util.Iterator<java.util.MapClass.Entry<K, V>> it = entrySet().iterator();
			if (key != null)
			{
				while (it.hasNext())
				{
					java.util.MapClass.Entry<K, V> entry = it.next();
					if (key.Equals(entry.getKey()))
					{
						return entry.getValue();
					}
				}
			}
			else
			{
				while (it.hasNext())
				{
					java.util.MapClass.Entry<K, V> entry = it.next();
					if ((object)entry.getKey() == null)
					{
						return entry.getValue();
					}
				}
			}
			return default(V);
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation iterates its entry set, summing the hashcodes of
		/// its entries.
		/// </summary>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int result = 0;
			java.util.Iterator<java.util.MapClass.Entry<K, V>> it = entrySet().iterator();
			while (it.hasNext())
			{
				result += it.next().GetHashCode();
			}
			return result;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation compares
		/// <code>size()</code>
		/// to 0.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual bool isEmpty()
		{
			return size() == 0;
		}

		private sealed class _AbstractSet_333 : java.util.AbstractSet<K>
		{
			public _AbstractSet_333(AbstractMap<K, V> _enclosing)
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

			private sealed class _Iterator_343 : java.util.Iterator<K>
			{
				public _Iterator_343(_AbstractSet_333 _enclosing)
				{
					this.setIterator = this._enclosing._enclosing.entrySet().iterator();
					this._enclosing = _enclosing;
				}

				internal java.util.Iterator<java.util.MapClass.Entry<K, V>> setIterator;

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public bool hasNext()
				{
					return this.setIterator.hasNext();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public K next()
				{
					return this.setIterator.next().getKey();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public void remove()
				{
					this.setIterator.remove();
				}

				private readonly _AbstractSet_333 _enclosing;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<K> iterator()
			{
				return new _Iterator_343(this);
			}

			private readonly AbstractMap<K, V> _enclosing;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation returns a view that calls through this to map. Its
		/// iterator transforms this map's entry set iterator to return keys.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual java.util.Set<K> keySet()
		{
			if (_keySet == null)
			{
				_keySet = new _AbstractSet_333(this);
			}
			return _keySet;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This base implementation throws
		/// <code>UnsupportedOperationException</code>
		/// .
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual V put(K key, V value)
		{
			throw new System.NotSupportedException();
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation iterates through
		/// <code>map</code>
		/// 's entry set, calling
		/// <code>put()</code>
		/// for each.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual void putAll<_T0, _T1>(java.util.Map<_T0, _T1> map) where _T0:K where 
			_T1:V
		{
			foreach (java.util.MapClass.Entry<K, V> entry in Sharpen.IterableProxy.Create(map
				.entrySet()))
			{
				put(entry.getKey(), entry.getValue());
			}
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation iterates its entry set, removing the entry with
		/// a key that
		/// <code>key</code>
		/// equals.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual V remove(object key)
		{
			java.util.Iterator<java.util.MapClass.Entry<K, V>> it = entrySet().iterator();
			if (key != null)
			{
				while (it.hasNext())
				{
					java.util.MapClass.Entry<K, V> entry = it.next();
					if (key.Equals(entry.getKey()))
					{
						it.remove();
						return entry.getValue();
					}
				}
			}
			else
			{
				while (it.hasNext())
				{
					java.util.MapClass.Entry<K, V> entry = it.next();
					if ((object)entry.getKey() == null)
					{
						it.remove();
						return entry.getValue();
					}
				}
			}
			return default(V);
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation returns its entry set's size.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual int size()
		{
			return entrySet().size();
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation composes a string by iterating its entry set. If
		/// this map contains itself as a key or a value, the string "(this Map)"
		/// will appear in its place.
		/// </summary>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			if (isEmpty())
			{
				return "{}";
			}
			java.lang.StringBuilder buffer = new java.lang.StringBuilder(size() * 28);
			buffer.append('{');
			java.util.Iterator<java.util.MapClass.Entry<K, V>> it = entrySet().iterator();
			while (it.hasNext())
			{
				java.util.MapClass.Entry<K, V> entry = it.next();
				object key = entry.getKey();
				if (key != this)
				{
					buffer.append(key);
				}
				else
				{
					buffer.append("(this Map)");
				}
				buffer.append('=');
				object value = entry.getValue();
				if (value != this)
				{
					buffer.append(value);
				}
				else
				{
					buffer.append("(this Map)");
				}
				if (it.hasNext())
				{
					buffer.append(", ");
				}
			}
			buffer.append('}');
			return buffer.ToString();
		}

		private sealed class _AbstractCollection_468 : java.util.AbstractCollection<V>
		{
			public _AbstractCollection_468(AbstractMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing.size();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object @object)
			{
				return this._enclosing.containsValue(@object);
			}

			private sealed class _Iterator_478 : java.util.Iterator<V>
			{
				public _Iterator_478(_AbstractCollection_468 _enclosing)
				{
					this.setIterator = this._enclosing._enclosing.entrySet().iterator();
					this._enclosing = _enclosing;
				}

				internal java.util.Iterator<java.util.MapClass.Entry<K, V>> setIterator;

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public bool hasNext()
				{
					return this.setIterator.hasNext();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public V next()
				{
					return this.setIterator.next().getValue();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public void remove()
				{
					this.setIterator.remove();
				}

				private readonly _AbstractCollection_468 _enclosing;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<V> iterator()
			{
				return new _Iterator_478(this);
			}

			private readonly AbstractMap<K, V> _enclosing;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This implementation returns a view that calls through this to map. Its
		/// iterator transforms this map's entry set iterator to return values.
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.Map")]
		public virtual java.util.Collection<V> values()
		{
			if (valuesCollection == null)
			{
				valuesCollection = new _AbstractCollection_468(this);
			}
			return valuesCollection;
		}

		/// <exception cref="java.lang.CloneNotSupportedException"></exception>
		protected internal virtual object clone()
		{
			java.util.AbstractMap<K, V> result = (java.util.AbstractMap<K, V>)base.MemberwiseClone
				();
			result._keySet = null;
			result.valuesCollection = null;
			return result;
		}
	}
}
