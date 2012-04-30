using Sharpen;

namespace java.util
{
	[Sharpen.Stub]
	public class Collections
	{
		/// <summary>This class is a singleton so that equals() and hashCode() work properly.
		/// 	</summary>
		/// <remarks>This class is a singleton so that equals() and hashCode() work properly.
		/// 	</remarks>
		private static class ReverseComparator
		{
			internal const long serialVersionUID = 7207038068494060240L;
		}

		/// <summary>This class is a singleton so that equals() and hashCode() work properly.
		/// 	</summary>
		/// <remarks>This class is a singleton so that equals() and hashCode() work properly.
		/// 	</remarks>
		[System.Serializable]
		private sealed class ReverseComparator<T> : java.util.Comparator<T>
		{
			internal static readonly ReverseComparator<T> INSTANCE = new ReverseComparator<T>();

			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public int compare(T o1, T o2)
			{
				java.lang.Comparable<T> c2 = (java.lang.Comparable<T>)o2;
				return c2.compareTo(o1);
			}

			/// <exception cref="java.io.ObjectStreamException"></exception>
			internal object readResolve()
			{
				return INSTANCE;
			}
		}

		private static class ReverseComparator2
		{
			internal const long serialVersionUID = 4374092139857L;
		}

		[System.Serializable]
		private sealed class ReverseComparator2<T> : java.util.Comparator<T>
		{
			internal readonly java.util.Comparator<T> cmp;

			internal ReverseComparator2(java.util.Comparator<T> comparator)
			{
				this.cmp = comparator;
			}

			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public int compare(T o1, T o2)
			{
				return cmp.compare(o2, o1);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object o)
			{
				return o is java.util.Collections.ReverseComparator2<T> && ((java.util.Collections
					.ReverseComparator2<T>)o).cmp.Equals(cmp);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return ~cmp.GetHashCode();
			}
		}

		internal static class SynchronizedCollection
		{
			internal const long serialVersionUID = 3053995032091335093L;
		}

		[System.Serializable]
		internal class SynchronizedCollection<E> : java.util.Collection<E>
		{
			internal readonly java.util.Collection<E> c;

			internal readonly object mutex;

			internal SynchronizedCollection(java.util.Collection<E> collection)
			{
				c = collection;
				mutex = this;
			}

			internal SynchronizedCollection(java.util.Collection<E> collection, object mutex)
			{
				c = collection;
				this.mutex = mutex;
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool add(E @object)
			{
				lock (mutex)
				{
					return c.add(@object);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool addAll<_T0>(java.util.Collection<_T0> collection) where _T0:E
			{
				lock (mutex)
				{
					return c.addAll(collection);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual void clear()
			{
				lock (mutex)
				{
					c.clear();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool contains(object @object)
			{
				lock (mutex)
				{
					return c.contains(@object);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool containsAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (mutex)
				{
					return c.containsAll(collection);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool isEmpty()
			{
				lock (mutex)
				{
					return c.isEmpty();
				}
			}

			[Sharpen.ImplementsInterface(@"java.lang.Iterable")]
			public virtual java.util.Iterator<E> iterator()
			{
				lock (mutex)
				{
					return c.iterator();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool remove(object @object)
			{
				lock (mutex)
				{
					return c.remove(@object);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool removeAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (mutex)
				{
					return c.removeAll(collection);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool retainAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (mutex)
				{
					return c.retainAll(collection);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual int size()
			{
				lock (mutex)
				{
					return c.size();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual object[] toArray()
			{
				lock (mutex)
				{
					return c.toArray();
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				lock (mutex)
				{
					return c.ToString();
				}
			}

			[Sharpen.Proxy]
			T[] java.util.Collection<E>.toArray<T>(T[] array)
			{
				return toArray<T>(array);
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual T[] toArray<T>(T[] array)
			{
				lock (mutex)
				{
					return c.toArray<T>(array);
				}
			}

			/// <exception cref="System.IO.IOException"></exception>
			private void writeObject(java.io.ObjectOutputStream stream)
			{
				lock (mutex)
				{
					stream.defaultWriteObject();
				}
			}
		}

		internal static class SynchronizedRandomAccessList
		{
			internal const long serialVersionUID = 1530674583602358482L;
		}

		[System.Serializable]
		internal class SynchronizedRandomAccessList<E> : java.util.Collections.SynchronizedList
			<E>, java.util.RandomAccess
		{
			internal SynchronizedRandomAccessList(java.util.List<E> l) : base(l)
			{
			}

			internal SynchronizedRandomAccessList(java.util.List<E> l, object mutex) : base(l
				, mutex)
			{
			}

			[Sharpen.OverridesMethod(@"java.util.Collections.SynchronizedList")]
			public override java.util.List<E> subList(int start, int end)
			{
				lock (mutex)
				{
					return new java.util.Collections.SynchronizedRandomAccessList<E>(list.subList(start
						, end), mutex);
				}
			}

			/// <summary>
			/// Replaces this SynchronizedRandomAccessList with a SynchronizedList so
			/// that JREs before 1.4 can deserialize this object without any
			/// problems.
			/// </summary>
			/// <remarks>
			/// Replaces this SynchronizedRandomAccessList with a SynchronizedList so
			/// that JREs before 1.4 can deserialize this object without any
			/// problems. This is necessary since RandomAccess API was introduced
			/// only in 1.4.
			/// <p>
			/// </remarks>
			/// <returns>SynchronizedList</returns>
			/// <seealso cref="SynchronizedList{E}.readResolve()">SynchronizedList&lt;E&gt;.readResolve()
			/// 	</seealso>
			private object writeReplace()
			{
				return new java.util.Collections.SynchronizedList<E>(list);
			}
		}

		internal static class SynchronizedList
		{
			internal const long serialVersionUID = -7754090372962971524L;
		}

		[System.Serializable]
		internal class SynchronizedList<E> : java.util.Collections.SynchronizedCollection
			<E>, java.util.List<E>
		{
			internal readonly java.util.List<E> list;

			internal SynchronizedList(java.util.List<E> l) : base(l)
			{
				list = l;
			}

			internal SynchronizedList(java.util.List<E> l, object mutex) : base(l, mutex)
			{
				list = l;
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual void add(int location, E @object)
			{
				lock (mutex)
				{
					list.add(location, @object);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual bool addAll<_T0>(int location, java.util.Collection<_T0> collection
				) where _T0:E
			{
				lock (mutex)
				{
					return list.addAll(location, collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				lock (mutex)
				{
					return list.Equals(@object);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual E get(int location)
			{
				lock (mutex)
				{
					return list.get(location);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				lock (mutex)
				{
					return list.GetHashCode();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual int indexOf(object @object)
			{
				int size_1;
				object[] array;
				lock (mutex)
				{
					size_1 = list.size();
					array = new object[size_1];
					list.toArray(array);
				}
				if (@object != null)
				{
					{
						for (int i = 0; i < size_1; i++)
						{
							if (@object.Equals(array[i]))
							{
								return i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = 0; i < size_1; i++)
						{
							if (array[i] == null)
							{
								return i;
							}
						}
					}
				}
				return -1;
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual int lastIndexOf(object @object)
			{
				int size_1;
				object[] array;
				lock (mutex)
				{
					size_1 = list.size();
					array = new object[size_1];
					list.toArray(array);
				}
				if (@object != null)
				{
					{
						for (int i = size_1 - 1; i >= 0; i--)
						{
							if (@object.Equals(array[i]))
							{
								return i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = size_1 - 1; i >= 0; i--)
						{
							if (array[i] == null)
							{
								return i;
							}
						}
					}
				}
				return -1;
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual java.util.ListIterator<E> listIterator()
			{
				lock (mutex)
				{
					return list.listIterator();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual java.util.ListIterator<E> listIterator(int location)
			{
				lock (mutex)
				{
					return list.listIterator(location);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual E remove(int location)
			{
				lock (mutex)
				{
					return list.remove(location);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual E set(int location, E @object)
			{
				lock (mutex)
				{
					return list.set(location, @object);
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual java.util.List<E> subList(int start, int end)
			{
				lock (mutex)
				{
					return new java.util.Collections.SynchronizedList<E>(list.subList(start, end), mutex
						);
				}
			}

			/// <exception cref="System.IO.IOException"></exception>
			new private void writeObject(java.io.ObjectOutputStream stream)
			{
				lock (mutex)
				{
					stream.defaultWriteObject();
				}
			}

			/// <summary>
			/// Resolves SynchronizedList instances to SynchronizedRandomAccessList
			/// instances if the underlying list is a Random Access list.
			/// </summary>
			/// <remarks>
			/// Resolves SynchronizedList instances to SynchronizedRandomAccessList
			/// instances if the underlying list is a Random Access list.
			/// <p>
			/// This is necessary since SynchronizedRandomAccessList instances are
			/// replaced with SynchronizedList instances during serialization for
			/// compliance with JREs before 1.4.
			/// <p>
			/// </remarks>
			/// <returns>
			/// a SynchronizedList instance if the underlying list implements
			/// RandomAccess interface, or this same object if not.
			/// </returns>
			/// <seealso cref="SynchronizedRandomAccessList{E}.writeReplace()">SynchronizedRandomAccessList&lt;E&gt;.writeReplace()
			/// 	</seealso>
			private object readResolve()
			{
				if (list is java.util.RandomAccess)
				{
					return new java.util.Collections.SynchronizedRandomAccessList<E>(list, mutex);
				}
				return this;
			}
		}

		private static class UnmodifiableCollection
		{
			internal const long serialVersionUID = 1820017752578914078L;
		}

		[System.Serializable]
		private class UnmodifiableCollection<E> : java.util.Collection<E>
		{
			internal readonly java.util.Collection<E> c;

			internal UnmodifiableCollection(java.util.Collection<E> collection)
			{
				c = collection;
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool add(E @object)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool addAll<_T0>(java.util.Collection<_T0> collection) where _T0:E
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual void clear()
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool contains(object @object)
			{
				return c.contains(@object);
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool containsAll<_T0>(java.util.Collection<_T0> collection)
			{
				return c.containsAll(collection);
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool isEmpty()
			{
				return c.isEmpty();
			}

			internal sealed class _Iterator_952 : java.util.Iterator<E>
			{
				public _Iterator_952(UnmodifiableCollection<E> _enclosing)
				{
					this.iterator = this._enclosing.c.iterator();
					this._enclosing = _enclosing;
				}

				internal java.util.Iterator<E> iterator;

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public bool hasNext()
				{
					return this.iterator.hasNext();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public E next()
				{
					return this.iterator.next();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public void remove()
				{
					throw new System.NotSupportedException();
				}

				private readonly UnmodifiableCollection<E> _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Iterable")]
			public virtual java.util.Iterator<E> iterator()
			{
				return new _Iterator_952(this);
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool remove(object @object)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool removeAll<_T0>(java.util.Collection<_T0> collection)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual bool retainAll<_T0>(java.util.Collection<_T0> collection)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual int size()
			{
				return c.size();
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual object[] toArray()
			{
				return c.toArray();
			}

			[Sharpen.Proxy]
			T[] java.util.Collection<E>.toArray<T>(T[] array)
			{
				return toArray<T>(array);
			}

			[Sharpen.ImplementsInterface(@"java.util.Collection")]
			public virtual T[] toArray<T>(T[] array)
			{
				return c.toArray<T>(array);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return c.ToString();
			}
		}

		private static class UnmodifiableRandomAccessList
		{
			internal const long serialVersionUID = -2542308836966382001L;
		}

		[System.Serializable]
		private class UnmodifiableRandomAccessList<E> : java.util.Collections.UnmodifiableList
			<E>, java.util.RandomAccess
		{
			internal UnmodifiableRandomAccessList(java.util.List<E> l) : base(l)
			{
			}

			[Sharpen.OverridesMethod(@"java.util.Collections.UnmodifiableList")]
			public override java.util.List<E> subList(int start, int end)
			{
				return new java.util.Collections.UnmodifiableRandomAccessList<E>(list.subList(start
					, end));
			}

			/// <summary>
			/// Replaces this UnmodifiableRandomAccessList with an UnmodifiableList
			/// so that JREs before 1.4 can deserialize this object without any
			/// problems.
			/// </summary>
			/// <remarks>
			/// Replaces this UnmodifiableRandomAccessList with an UnmodifiableList
			/// so that JREs before 1.4 can deserialize this object without any
			/// problems. This is necessary since RandomAccess API was introduced
			/// only in 1.4.
			/// <p>
			/// </remarks>
			/// <returns>UnmodifiableList</returns>
			/// <seealso cref="UnmodifiableList{E}.readResolve()">UnmodifiableList&lt;E&gt;.readResolve()
			/// 	</seealso>
			internal object writeReplace()
			{
				return new java.util.Collections.UnmodifiableList<E>(list);
			}
		}

		private static class UnmodifiableList
		{
			internal const long serialVersionUID = -283967356065247728L;
		}

		[System.Serializable]
		private class UnmodifiableList<E> : java.util.Collections.UnmodifiableCollection<
			E>, java.util.List<E>
		{
			internal readonly java.util.List<E> list;

			internal UnmodifiableList(java.util.List<E> l) : base(l)
			{
				list = l;
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual void add(int location, E @object)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual bool addAll<_T0>(int location, java.util.Collection<_T0> collection
				) where _T0:E
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				return list.Equals(@object);
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual E get(int location)
			{
				return list.get(location);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return list.GetHashCode();
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual int indexOf(object @object)
			{
				return list.indexOf(@object);
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual int lastIndexOf(object @object)
			{
				return list.lastIndexOf(@object);
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual java.util.ListIterator<E> listIterator()
			{
				return listIterator(0);
			}

			internal sealed class _ListIterator_1070 : java.util.ListIterator<E>
			{
				public _ListIterator_1070(UnmodifiableList<E> _enclosing, int location)
				{
					this.iterator = this._enclosing.list.listIterator(location);
					this._enclosing = _enclosing;
					this.location = location;
				}

				internal java.util.ListIterator<E> iterator;

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public void add(E @object)
				{
					throw new System.NotSupportedException();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public bool hasNext()
				{
					return this.iterator.hasNext();
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public bool hasPrevious()
				{
					return this.iterator.hasPrevious();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public E next()
				{
					return this.iterator.next();
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public int nextIndex()
				{
					return this.iterator.nextIndex();
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public E previous()
				{
					return this.iterator.previous();
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public int previousIndex()
				{
					return this.iterator.previousIndex();
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public void remove()
				{
					throw new System.NotSupportedException();
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public void set(E @object)
				{
					throw new System.NotSupportedException();
				}

				private readonly UnmodifiableList<E> _enclosing;

				private readonly int location;
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual java.util.ListIterator<E> listIterator(int location)
			{
				return new _ListIterator_1070(this, location);
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual E remove(int location)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual E set(int location, E @object)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.List")]
			public virtual java.util.List<E> subList(int start, int end)
			{
				return new java.util.Collections.UnmodifiableList<E>(list.subList(start, end));
			}

			/// <summary>
			/// Resolves UnmodifiableList instances to UnmodifiableRandomAccessList
			/// instances if the underlying list is a Random Access list.
			/// </summary>
			/// <remarks>
			/// Resolves UnmodifiableList instances to UnmodifiableRandomAccessList
			/// instances if the underlying list is a Random Access list.
			/// <p>
			/// This is necessary since UnmodifiableRandomAccessList instances are
			/// replaced with UnmodifiableList instances during serialization for
			/// compliance with JREs before 1.4.
			/// <p>
			/// </remarks>
			/// <returns>
			/// an UnmodifiableList instance if the underlying list
			/// implements RandomAccess interface, or this same object if
			/// not.
			/// </returns>
			/// <seealso cref="UnmodifiableRandomAccessList{E}.writeReplace()">UnmodifiableRandomAccessList&lt;E&gt;.writeReplace()
			/// 	</seealso>
			internal object readResolve()
			{
				if (list is java.util.RandomAccess)
				{
					return new java.util.Collections.UnmodifiableRandomAccessList<E>(list);
				}
				return this;
			}
		}

		private static class UnmodifiableMap
		{
			internal const long serialVersionUID = -1034234728574286014L;

			internal static class UnmodifiableEntrySet
			{
				internal const long serialVersionUID = 7854390611657943733L;

				internal class UnmodifiableMapEntry<K, V> : java.util.MapClass.Entry<K, V>
				{
					internal java.util.MapClass.Entry<K, V> mapEntry;

					internal UnmodifiableMapEntry(java.util.MapClass.Entry<K, V> entry)
					{
						mapEntry = entry;
					}

					[Sharpen.OverridesMethod(@"java.lang.Object")]
					public override bool Equals(object @object)
					{
						return mapEntry.Equals(@object);
					}

					[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
					public virtual K getKey()
					{
						return mapEntry.getKey();
					}

					[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
					public virtual V getValue()
					{
						return mapEntry.getValue();
					}

					[Sharpen.OverridesMethod(@"java.lang.Object")]
					public override int GetHashCode()
					{
						return mapEntry.GetHashCode();
					}

					[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
					public virtual V setValue(V @object)
					{
						throw new System.NotSupportedException();
					}

					[Sharpen.OverridesMethod(@"java.lang.Object")]
					public override string ToString()
					{
						return mapEntry.ToString();
					}
				}
			}

			[System.Serializable]
			internal class UnmodifiableEntrySet<K, V> : java.util.Collections.UnmodifiableSet
				<java.util.MapClass.Entry<K, V>>
			{
				internal UnmodifiableEntrySet(java.util.Set<java.util.MapClass.Entry<K, V>> set) : 
					base(set)
				{
				}

				internal sealed class _Iterator_1194 : java.util.Iterator<java.util.MapClass.Entry
					<K, V>>
				{
					public _Iterator_1194(UnmodifiableEntrySet<K, V> _enclosing)
					{
						this.iterator = this._enclosing.c.iterator();
						this._enclosing = _enclosing;
					}

					internal java.util.Iterator<java.util.MapClass.Entry<K, V>> iterator;

					[Sharpen.ImplementsInterface(@"java.util.Iterator")]
					public bool hasNext()
					{
						return this.iterator.hasNext();
					}

					[Sharpen.ImplementsInterface(@"java.util.Iterator")]
					public java.util.MapClass.Entry<K, V> next()
					{
						return new java.util.Collections.UnmodifiableMap.UnmodifiableEntrySet.UnmodifiableMapEntry
							<K, V>(this.iterator.next());
					}

					[Sharpen.ImplementsInterface(@"java.util.Iterator")]
					public void remove()
					{
						throw new System.NotSupportedException();
					}

					private readonly UnmodifiableEntrySet<K, V> _enclosing;
				}

				[Sharpen.OverridesMethod(@"java.util.Collections.UnmodifiableCollection")]
				public override java.util.Iterator<java.util.MapClass.Entry<K, V>> iterator()
				{
					return new _Iterator_1194(this);
				}

				[Sharpen.OverridesMethod(@"java.util.Collections.UnmodifiableCollection")]
				public override object[] toArray()
				{
					int length = c.size();
					object[] result = new object[length];
					java.util.Iterator<java.util.MapClass.Entry<K, V>> it = iterator();
					{
						for (int i = length; --i >= 0; )
						{
							result[i] = it.next();
						}
					}
					return result;
				}

				[Sharpen.OverridesMethod(@"java.util.Collections.UnmodifiableCollection")]
				public override T[] toArray<T>(T[] contents)
				{
					int size_1 = c.size();
					int index = 0;
					java.util.Iterator<java.util.MapClass.Entry<K, V>> it = iterator();
					if (size_1 > contents.Length)
					{
						System.Type ct = contents.GetType().GetElementType();
						contents = (T[])System.Array.CreateInstance(ct, size_1);
					}
					while (index < size_1)
					{
						contents[index++] = (T)it.next();
					}
					if (index < contents.Length)
					{
						contents[index] = default(T);
					}
					return contents;
				}
			}
		}

		[System.Serializable]
		private class UnmodifiableMap<K, V> : java.util.Map<K, V>
		{
			internal readonly java.util.Map<K, V> m;

			internal UnmodifiableMap(java.util.Map<K, V> map)
			{
				m = map;
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual void clear()
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual bool containsKey(object key)
			{
				return m.containsKey(key);
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual bool containsValue(object value)
			{
				return m.containsValue(value);
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
			{
				return new java.util.Collections.UnmodifiableMap.UnmodifiableEntrySet<K, V>(m.entrySet
					());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				return m.Equals(@object);
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual V get(object key)
			{
				return m.get(key);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return m.GetHashCode();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual bool isEmpty()
			{
				return m.isEmpty();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual java.util.Set<K> keySet()
			{
				return new java.util.Collections.UnmodifiableSet<K>(m.keySet());
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual V put(K key, V value)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual void putAll<_T0, _T1>(java.util.Map<_T0, _T1> map) where _T0:K where 
				_T1:V
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual V remove(object key)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual int size()
			{
				return m.size();
			}

			[Sharpen.ImplementsInterface(@"java.util.Map")]
			public virtual java.util.Collection<V> values()
			{
				return new java.util.Collections.UnmodifiableCollection<V>(m.values());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return m.ToString();
			}
		}

		private static class UnmodifiableSet
		{
			internal const long serialVersionUID = -9215047833775013803L;
		}

		[System.Serializable]
		private class UnmodifiableSet<E> : java.util.Collections.UnmodifiableCollection<E
			>, java.util.Set<E>
		{
			internal UnmodifiableSet(java.util.Set<E> set) : base(set)
			{
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object @object)
			{
				return c.Equals(@object);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return c.GetHashCode();
			}
		}

		[Sharpen.Stub]
		private Collections()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch<T, _T1>(java.util.List<_T1> list_1, T @object) where 
			_T1:java.lang.Comparable<T>
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch<T>(java.util.List<T> list_1, T @object, java.util.Comparator
			<T> comparator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void copy<T>(java.util.List<T> destination, java.util.List<T> source
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Enumeration<T> enumeration<T>(java.util.Collection<T> collection
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void fill<T>(java.util.List<T> list_1, T @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static T max<T>(java.util.Collection<T> collection) where T:java.lang.Comparable
			<T>
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static T max<T>(java.util.Collection<T> collection, java.util.Comparator<T
			> comparator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static T min<T>(java.util.Collection<T> collection) where T:java.lang.Comparable
			<T>
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static T min<T>(java.util.Collection<T> collection, java.util.Comparator<T
			> comparator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<T> nCopies<T>(int length, T @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void reverse<_T0>(java.util.List<_T0> list_1)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>A comparator which reverses the natural order of the elements.</summary>
		/// <remarks>
		/// A comparator which reverses the natural order of the elements. The
		/// <code>Comparator</code>
		/// that's returned is
		/// <see cref="java.io.Serializable">java.io.Serializable</see>
		/// .
		/// </remarks>
		/// <returns>
		/// a
		/// <code>Comparator</code>
		/// instance.
		/// </returns>
		public static java.util.Comparator<T> reverseOrder<T>()
		{
			return (java.util.Comparator<T>)java.util.Collections.ReverseComparator<T>.INSTANCE;
		}

		/// <summary>
		/// Returns a
		/// <see cref="Comparator{T}">Comparator&lt;T&gt;</see>
		/// that reverses the order of the
		/// <code>Comparator</code>
		/// passed. If the
		/// <code>Comparator</code>
		/// passed is
		/// <code>null</code>
		/// , then this method is equivalent to
		/// <see cref="reverseOrder{T}()">reverseOrder&lt;T&gt;()</see>
		/// .
		/// <p>
		/// The
		/// <code>Comparator</code>
		/// that's returned is
		/// <see cref="java.io.Serializable">java.io.Serializable</see>
		/// if the
		/// <code>Comparator</code>
		/// passed is serializable or
		/// <code>null</code>
		/// .
		/// </summary>
		/// <param name="c">
		/// the
		/// <code>Comparator</code>
		/// to reverse or
		/// <code>null</code>
		/// .
		/// </param>
		/// <returns>
		/// a
		/// <code>Comparator</code>
		/// instance.
		/// </returns>
		/// <since>1.5</since>
		public static java.util.Comparator<T> reverseOrder<T>(java.util.Comparator<T> c)
		{
			if (c == null)
			{
				return reverseOrder<T>();
			}
			if (c is java.util.Collections.ReverseComparator2<T>)
			{
				return ((java.util.Collections.ReverseComparator2<T>)c).cmp;
			}
			return new java.util.Collections.ReverseComparator2<T>(c);
		}

		[Sharpen.Stub]
		public static void shuffle<_T0>(java.util.List<_T0> list_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void shuffle<_T0>(java.util.List<_T0> list_1, System.Random random)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Set<E> singleton<E>(E @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<E> singletonList<E>(E @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Map<K, V> singletonMap<K, V>(K key, V value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort<T>(java.util.List<T> list_1) where T:java.lang.Comparable
			<T>
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort<T>(java.util.List<T> list_1, java.util.Comparator<T> comparator
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void swap<_T0>(java.util.List<_T0> list_1, int index1, int index2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool replaceAll<T>(java.util.List<T> list_1, T obj, T obj2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void rotate<_T0>(java.util.List<_T0> lst, int dist)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int indexOfSubList<_T0, _T1>(java.util.List<_T0> list_1, java.util.List
			<_T1> sublist)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int lastIndexOfSubList<_T0, _T1>(java.util.List<_T0> list_1, java.util.List
			<_T1> sublist)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.ArrayList<T> list<T>(java.util.Enumeration<T> enumeration_1
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Collection<T> synchronizedCollection<T>(java.util.Collection
			<T> collection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<T> synchronizedList<T>(java.util.List<T> list_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Map<K, V> synchronizedMap<K, V>(java.util.Map<K, V> map)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Set<E> synchronizedSet<E>(java.util.Set<E> set)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.SortedMap<K, V> synchronizedSortedMap<K, V>(java.util.SortedMap
			<K, V> map)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.SortedSet<E> synchronizedSortedSet<E>(java.util.SortedSet
			<E> set)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns a wrapper on the specified collection which throws an
		/// <code>UnsupportedOperationException</code>
		/// whenever an attempt is made to
		/// modify the collection.
		/// </summary>
		/// <param name="collection">the collection to wrap in an unmodifiable collection.</param>
		/// <returns>an unmodifiable collection.</returns>
		public static java.util.Collection<E> unmodifiableCollection<E>(java.util.Collection
			<E> collection)
		{
			if (collection == null)
			{
				throw new System.ArgumentNullException();
			}
			return new java.util.Collections.UnmodifiableCollection<E>((java.util.Collection<
				E>)collection);
		}

		/// <summary>
		/// Returns a wrapper on the specified list which throws an
		/// <code>UnsupportedOperationException</code>
		/// whenever an attempt is made to
		/// modify the list.
		/// </summary>
		/// <param name="list">the list to wrap in an unmodifiable list.</param>
		/// <returns>an unmodifiable List.</returns>
		public static java.util.List<E> unmodifiableList<E>(java.util.List<E> list_1)
		{
			if (list_1 == null)
			{
				throw new System.ArgumentNullException();
			}
			if (list_1 is java.util.RandomAccess)
			{
				return new java.util.Collections.UnmodifiableRandomAccessList<E>((java.util.List<
					E>)list_1);
			}
			return new java.util.Collections.UnmodifiableList<E>((java.util.List<E>)list_1);
		}

		/// <summary>
		/// Returns a wrapper on the specified map which throws an
		/// <code>UnsupportedOperationException</code>
		/// whenever an attempt is made to
		/// modify the map.
		/// </summary>
		/// <param name="map">the map to wrap in an unmodifiable map.</param>
		/// <returns>a unmodifiable map.</returns>
		public static java.util.Map<K, V> unmodifiableMap<K, V>(java.util.Map<K, V> map)
		{
			if (map == null)
			{
				throw new System.ArgumentNullException();
			}
			return new java.util.Collections.UnmodifiableMap<K, V>((java.util.Map<K, V>)map);
		}

		/// <summary>
		/// Returns a wrapper on the specified set which throws an
		/// <code>UnsupportedOperationException</code>
		/// whenever an attempt is made to
		/// modify the set.
		/// </summary>
		/// <param name="set">the set to wrap in an unmodifiable set.</param>
		/// <returns>a unmodifiable set</returns>
		public static java.util.Set<E> unmodifiableSet<E>(java.util.Set<E> set)
		{
			if (set == null)
			{
				throw new System.ArgumentNullException();
			}
			return new java.util.Collections.UnmodifiableSet<E>((java.util.Set<E>)set);
		}

		[Sharpen.Stub]
		public static java.util.SortedMap<K, V> unmodifiableSortedMap<K, V>(java.util.SortedMap
			<K, V> map)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.SortedSet<E> unmodifiableSortedSet<E>(java.util.SortedSet
			<E> set)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int frequency<_T0>(java.util.Collection<_T0> c, object o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<T> emptyList<T>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Set<T> emptySet<T>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Map<K, V> emptyMap<K, V>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Enumeration<T> emptyEnumeration<T>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Iterator<T> emptyIterator<T>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.ListIterator<T> emptyListIterator<T>()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Collection<E> checkedCollection<E>(java.util.Collection<E
			> c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Map<K, V> checkedMap<K, V>(java.util.Map<K, V> m)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<E> checkedList<E>(java.util.List<E> list_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Set<E> checkedSet<E>(java.util.Set<E> s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.SortedMap<K, V> checkedSortedMap<K, V>(java.util.SortedMap
			<K, V> m)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.SortedSet<E> checkedSortedSet<E>(java.util.SortedSet<E> s
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool addAll<T>(java.util.Collection<T> c, params T[] a)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool disjoint<_T0, _T1>(java.util.Collection<_T0> c1, java.util.Collection
			<_T1> c2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static E checkType<E>(E obj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Set<E> newSetFromMap<E>(java.util.Map<E, bool> map)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Queue<T> asLifoQueue<T>(java.util.Deque<T> deque)
		{
			throw new System.NotImplementedException();
		}
	}
}
