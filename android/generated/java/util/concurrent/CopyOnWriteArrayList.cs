using Sharpen;

namespace java.util.concurrent
{
	/// <summary>A thread-safe random-access list.</summary>
	/// <remarks>
	/// A thread-safe random-access list.
	/// <p>Read operations (including
	/// <see cref="CopyOnWriteArrayList{E}.get(int)">CopyOnWriteArrayList&lt;E&gt;.get(int)
	/// 	</see>
	/// ) do not block and may overlap with
	/// update operations. Reads reflect the results of the most recently completed
	/// operations. Aggregate operations like
	/// <see cref="CopyOnWriteArrayList{E}.addAll(java.util.Collection{E})">CopyOnWriteArrayList&lt;E&gt;.addAll(java.util.Collection&lt;E&gt;)
	/// 	</see>
	/// and
	/// <see cref="CopyOnWriteArrayList{E}.clear()">CopyOnWriteArrayList&lt;E&gt;.clear()
	/// 	</see>
	/// are
	/// atomic; they never expose an intermediate state.
	/// <p>Iterators of this list never throw
	/// <see cref="java.util.ConcurrentModificationException">java.util.ConcurrentModificationException
	/// 	</see>
	/// . When an iterator is created, it keeps a
	/// copy of the list's contents. It is always safe to iterate this list, but
	/// iterations may not reflect the latest state of the list.
	/// <p>Iterators returned by this list and its sub lists cannot modify the
	/// underlying list. In particular,
	/// <see cref="java.util.Iterator{E}.remove()">java.util.Iterator&lt;E&gt;.remove()</see>
	/// ,
	/// <see cref="java.util.ListIterator{E}.add(object)">java.util.ListIterator&lt;E&gt;.add(object)
	/// 	</see>
	/// and
	/// <see cref="java.util.ListIterator{E}.set(object)">java.util.ListIterator&lt;E&gt;.set(object)
	/// 	</see>
	/// all throw
	/// <see cref="System.NotSupportedException">System.NotSupportedException</see>
	/// .
	/// <p>This class offers extended API beyond the
	/// <see cref="java.util.List{E}">java.util.List&lt;E&gt;</see>
	/// interface. It
	/// includes additional overloads for indexed search (
	/// <see cref="CopyOnWriteArrayList{E}.indexOf(object)">CopyOnWriteArrayList&lt;E&gt;.indexOf(object)
	/// 	</see>
	/// and
	/// <see cref="CopyOnWriteArrayList{E}.lastIndexOf(object)">CopyOnWriteArrayList&lt;E&gt;.lastIndexOf(object)
	/// 	</see>
	/// ) and methods for conditional adds (
	/// <see cref="CopyOnWriteArrayList{E}.addIfAbsent(object)">CopyOnWriteArrayList&lt;E&gt;.addIfAbsent(object)
	/// 	</see>
	/// and
	/// <see cref="CopyOnWriteArrayList{E}.addAllAbsent(java.util.Collection{E})">CopyOnWriteArrayList&lt;E&gt;.addAllAbsent(java.util.Collection&lt;E&gt;)
	/// 	</see>
	/// ).
	/// </remarks>
	[Sharpen.Sharpened]
	public static partial class CopyOnWriteArrayList
	{
		internal const long serialVersionUID = 8673264195747942595L;

		internal class Slice
		{
			internal readonly object[] expectedElements;

			internal readonly int from;

			internal readonly int to;

			internal Slice(object[] expectedElements, int from, int to)
			{
				// trim to size
				// trim to size
				// we made it all the way through the loop without making any changes
				// CopyOnWriteArraySet needs this.
				this.expectedElements = expectedElements;
				this.from = from;
				this.to = to;
			}

			/// <summary>
			/// Throws if
			/// <code>index</code>
			/// doesn't identify an element in the array.
			/// </summary>
			internal virtual void checkElementIndex(int index)
			{
				if (index < 0 || index >= to - from)
				{
					throw new System.IndexOutOfRangeException("index=" + index + ", size=" + (to - from
						));
				}
			}

			/// <summary>
			/// Throws if
			/// <code>index</code>
			/// doesn't identify an insertion point in the
			/// array. Unlike element index, it's okay to add or iterate at size().
			/// </summary>
			internal virtual void checkPositionIndex(int index)
			{
				if (index < 0 || index > to - from)
				{
					throw new System.IndexOutOfRangeException("index=" + index + ", size=" + (to - from
						));
				}
			}

			internal virtual void checkConcurrentModification(object[] snapshot)
			{
				if (expectedElements != snapshot)
				{
					throw new java.util.ConcurrentModificationException();
				}
			}
		}

		/// <summary>Iterates an immutable snapshot of the list.</summary>
		/// <remarks>Iterates an immutable snapshot of the list.</remarks>
		internal class CowIterator<E> : java.util.ListIterator<E>
		{
			internal readonly object[] snapshot;

			internal readonly int from;

			internal readonly int to;

			internal int index = 0;

			internal CowIterator(object[] snapshot, int from, int to)
			{
				this.snapshot = snapshot;
				this.from = from;
				this.to = to;
				this.index = from;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public virtual void add(E @object)
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				return index < to;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public virtual bool hasPrevious()
			{
				return index > from;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual E next()
			{
				if (index < to)
				{
					return (E)snapshot[index++];
				}
				else
				{
					throw new java.util.NoSuchElementException();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public virtual int nextIndex()
			{
				return index;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public virtual E previous()
			{
				if (index > from)
				{
					return (E)snapshot[--index];
				}
				else
				{
					throw new java.util.NoSuchElementException();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public virtual int previousIndex()
			{
				return index - 1;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				throw new System.NotSupportedException();
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public virtual void set(E @object)
			{
				throw new System.NotSupportedException();
			}
		}
	}

	/// <summary>A thread-safe random-access list.</summary>
	/// <remarks>
	/// A thread-safe random-access list.
	/// <p>Read operations (including
	/// <see cref="CopyOnWriteArrayList{E}.get(int)">CopyOnWriteArrayList&lt;E&gt;.get(int)
	/// 	</see>
	/// ) do not block and may overlap with
	/// update operations. Reads reflect the results of the most recently completed
	/// operations. Aggregate operations like
	/// <see cref="CopyOnWriteArrayList{E}.addAll(java.util.Collection{E})">CopyOnWriteArrayList&lt;E&gt;.addAll(java.util.Collection&lt;E&gt;)
	/// 	</see>
	/// and
	/// <see cref="CopyOnWriteArrayList{E}.clear()">CopyOnWriteArrayList&lt;E&gt;.clear()
	/// 	</see>
	/// are
	/// atomic; they never expose an intermediate state.
	/// <p>Iterators of this list never throw
	/// <see cref="java.util.ConcurrentModificationException">java.util.ConcurrentModificationException
	/// 	</see>
	/// . When an iterator is created, it keeps a
	/// copy of the list's contents. It is always safe to iterate this list, but
	/// iterations may not reflect the latest state of the list.
	/// <p>Iterators returned by this list and its sub lists cannot modify the
	/// underlying list. In particular,
	/// <see cref="java.util.Iterator{E}.remove()">java.util.Iterator&lt;E&gt;.remove()</see>
	/// ,
	/// <see cref="java.util.ListIterator{E}.add(object)">java.util.ListIterator&lt;E&gt;.add(object)
	/// 	</see>
	/// and
	/// <see cref="java.util.ListIterator{E}.set(object)">java.util.ListIterator&lt;E&gt;.set(object)
	/// 	</see>
	/// all throw
	/// <see cref="System.NotSupportedException">System.NotSupportedException</see>
	/// .
	/// <p>This class offers extended API beyond the
	/// <see cref="java.util.List{E}">java.util.List&lt;E&gt;</see>
	/// interface. It
	/// includes additional overloads for indexed search (
	/// <see cref="CopyOnWriteArrayList{E}.indexOf(object)">CopyOnWriteArrayList&lt;E&gt;.indexOf(object)
	/// 	</see>
	/// and
	/// <see cref="CopyOnWriteArrayList{E}.lastIndexOf(object)">CopyOnWriteArrayList&lt;E&gt;.lastIndexOf(object)
	/// 	</see>
	/// ) and methods for conditional adds (
	/// <see cref="CopyOnWriteArrayList{E}.addIfAbsent(object)">CopyOnWriteArrayList&lt;E&gt;.addIfAbsent(object)
	/// 	</see>
	/// and
	/// <see cref="CopyOnWriteArrayList{E}.addAllAbsent(java.util.Collection{E})">CopyOnWriteArrayList&lt;E&gt;.addAllAbsent(java.util.Collection&lt;E&gt;)
	/// 	</see>
	/// ).
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public partial class CopyOnWriteArrayList<E> : java.util.List<E>, java.util.RandomAccess
		, System.ICloneable
	{
		/// <summary>Holds the latest snapshot of the list's data.</summary>
		/// <remarks>
		/// Holds the latest snapshot of the list's data. This field is volatile so
		/// that data can be read without synchronization. As a consequence, all
		/// writes to this field must be atomic; it is an error to modify the
		/// contents of an array after it has been assigned to this field.
		/// Synchronization is required by all update operations. This defends
		/// against one update clobbering the result of another operation. For
		/// example, 100 threads simultaneously calling add() will grow the list's
		/// size by 100 when they have completed. No update operations are lost!
		/// Maintainers should be careful to read this field only once in
		/// non-blocking read methods. Write methods must be synchronized to avoid
		/// clobbering concurrent writes.
		/// </remarks>
		[System.NonSerialized]
		private volatile object[] elements;

		/// <summary>Creates a new empty instance.</summary>
		/// <remarks>Creates a new empty instance.</remarks>
		public CopyOnWriteArrayList()
		{
			elements = libcore.util.EmptyArray.OBJECT;
		}

		public virtual object clone()
		{
			java.util.concurrent.CopyOnWriteArrayList<E> result = (java.util.concurrent.CopyOnWriteArrayList
				<E>)base.MemberwiseClone();
			result.elements = (object[])result.elements.Clone();
			return result;
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual int size()
		{
			return elements.Length;
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual E get(int index)
		{
			return (E)elements[index];
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool contains(object o)
		{
			return indexOf(o) != -1;
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool containsAll<_T0>(java.util.Collection<_T0> collection)
		{
			object[] snapshot = elements;
			return containsAll(collection, snapshot, 0, snapshot.Length);
		}

		internal static bool containsAll<_T0>(java.util.Collection<_T0> collection, object
			[] snapshot, int from, int to)
		{
			foreach (object o in Sharpen.IterableProxy.Create(collection))
			{
				if (indexOf(o, snapshot, from, to) == -1)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Searches this list for
		/// <code>object</code>
		/// and returns the index of the first
		/// occurrence that is at or after
		/// <code>from</code>
		/// .
		/// </summary>
		/// <returns>the index or -1 if the object was not found.</returns>
		public virtual int indexOf(E @object, int from)
		{
			object[] snapshot = elements;
			return indexOf(@object, snapshot, from, snapshot.Length);
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual int indexOf(object @object)
		{
			object[] snapshot = elements;
			return indexOf(@object, snapshot, 0, snapshot.Length);
		}

		/// <summary>
		/// Searches this list for
		/// <code>object</code>
		/// and returns the index of the last
		/// occurrence that is before
		/// <code>to</code>
		/// .
		/// </summary>
		/// <returns>the index or -1 if the object was not found.</returns>
		public virtual int lastIndexOf(E @object, int to)
		{
			object[] snapshot = elements;
			return lastIndexOf(@object, snapshot, 0, to);
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual int lastIndexOf(object @object)
		{
			object[] snapshot = elements;
			return lastIndexOf(@object, snapshot, 0, snapshot.Length);
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool isEmpty()
		{
			return elements.Length == 0;
		}

		/// <summary>
		/// Returns an
		/// <see cref="java.util.Iterator{E}">java.util.Iterator&lt;E&gt;</see>
		/// that iterates over the elements of this list
		/// as they were at the time of this method call. Changes to the list made
		/// after this method call will not be reflected by the iterator, nor will
		/// they trigger a
		/// <see cref="java.util.ConcurrentModificationException">java.util.ConcurrentModificationException
		/// 	</see>
		/// .
		/// <p>The returned iterator does not support
		/// <see cref="java.util.Iterator{E}.remove()">java.util.Iterator&lt;E&gt;.remove()</see>
		/// .
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.lang.Iterable")]
		public virtual java.util.Iterator<E> iterator()
		{
			object[] snapshot = elements;
			return new java.util.concurrent.CopyOnWriteArrayList.CowIterator<E>(snapshot, 0, 
				snapshot.Length);
		}

		/// <summary>
		/// Returns a
		/// <see cref="java.util.ListIterator{E}">java.util.ListIterator&lt;E&gt;</see>
		/// that iterates over the elements of this
		/// list as they were at the time of this method call. Changes to the list
		/// made after this method call will not be reflected by the iterator, nor
		/// will they trigger a
		/// <see cref="java.util.ConcurrentModificationException">java.util.ConcurrentModificationException
		/// 	</see>
		/// .
		/// <p>The returned iterator does not support
		/// <see cref="java.util.ListIterator{E}.add(object)">java.util.ListIterator&lt;E&gt;.add(object)
		/// 	</see>
		/// ,
		/// <see cref="java.util.ListIterator{E}.set(object)">java.util.ListIterator&lt;E&gt;.set(object)
		/// 	</see>
		/// or
		/// <see cref="java.util.Iterator{E}.remove()">java.util.Iterator&lt;E&gt;.remove()</see>
		/// ,
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual java.util.ListIterator<E> listIterator(int index)
		{
			object[] snapshot = elements;
			if (index < 0 || index > snapshot.Length)
			{
				throw new System.IndexOutOfRangeException("index=" + index + ", length=" + snapshot
					.Length);
			}
			java.util.concurrent.CopyOnWriteArrayList.CowIterator<E> result = new java.util.concurrent.CopyOnWriteArrayList
				.CowIterator<E>(snapshot, 0, snapshot.Length);
			result.index = index;
			return result;
		}

		/// <summary>
		/// Equivalent to
		/// <code>listIterator(0)</code>
		/// .
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual java.util.ListIterator<E> listIterator()
		{
			object[] snapshot = elements;
			return new java.util.concurrent.CopyOnWriteArrayList.CowIterator<E>(snapshot, 0, 
				snapshot.Length);
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual java.util.List<E> subList(int from, int to)
		{
			object[] snapshot = elements;
			if (from < 0 || from > to || to > snapshot.Length)
			{
				throw new System.IndexOutOfRangeException("from=" + from + ", to=" + to + ", list size="
					 + snapshot.Length);
			}
			return new java.util.concurrent.CopyOnWriteArrayList<E>.CowSubList(this, snapshot
				, from, to);
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual object[] toArray()
		{
			return (object[])elements.Clone();
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			if (other is java.util.concurrent.CopyOnWriteArrayList<E>)
			{
				return this == other || java.util.Arrays.equals(elements, ((java.util.concurrent.CopyOnWriteArrayList
					<E>)other).elements);
			}
			else
			{
				if (other is java.util.List<E>)
				{
					object[] snapshot = elements;
					java.util.Iterator<E> i = ((java.util.List<E>)other).iterator();
					foreach (object o in snapshot)
					{
						if (!i.hasNext() || !libcore.util.Objects.equal(o, i.next()))
						{
							return false;
						}
					}
					return !i.hasNext();
				}
				else
				{
					return false;
				}
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			return java.util.Arrays.hashCode(elements);
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return java.util.Arrays.toString(elements);
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool add(E e)
		{
			lock (this)
			{
				object[] newElements = new object[elements.Length + 1];
				System.Array.Copy(elements, 0, newElements, 0, elements.Length);
				newElements[elements.Length] = e;
				elements = newElements;
				return true;
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual void add(int index, E e)
		{
			lock (this)
			{
				object[] newElements = new object[elements.Length + 1];
				System.Array.Copy(elements, 0, newElements, 0, index);
				newElements[index] = e;
				System.Array.Copy(elements, index, newElements, index + 1, elements.Length - index
					);
				elements = newElements;
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool addAll<_T0>(java.util.Collection<_T0> collection) where _T0:E
		{
			lock (this)
			{
				return addAll(elements.Length, collection);
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual bool addAll<_T0>(int index, java.util.Collection<_T0> collection) where 
			_T0:E
		{
			lock (this)
			{
				object[] toAdd = collection.toArray();
				object[] newElements = new object[elements.Length + toAdd.Length];
				System.Array.Copy(elements, 0, newElements, 0, index);
				System.Array.Copy(toAdd, 0, newElements, index, toAdd.Length);
				System.Array.Copy(elements, index, newElements, index + toAdd.Length, elements.Length
					 - index);
				elements = newElements;
				return toAdd.Length > 0;
			}
		}

		/// <summary>
		/// Adds the elements of
		/// <code>collection</code>
		/// that are not already present in
		/// this list. If
		/// <code>collection</code>
		/// includes a repeated value, at most one
		/// occurrence of that value will be added to this list. Elements are added
		/// at the end of this list.
		/// <p>Callers of this method may prefer
		/// <see cref="CopyOnWriteArraySet{E}">CopyOnWriteArraySet&lt;E&gt;</see>
		/// , whose
		/// API is more appropriate for set operations.
		/// </summary>
		public virtual int addAllAbsent<_T0>(java.util.Collection<_T0> collection) where 
			_T0:E
		{
			lock (this)
			{
				object[] toAdd = collection.toArray();
				object[] newElements = new object[elements.Length + toAdd.Length];
				System.Array.Copy(elements, 0, newElements, 0, elements.Length);
				int addedCount = 0;
				foreach (object o in toAdd)
				{
					if (indexOf(o, newElements, 0, elements.Length + addedCount) == -1)
					{
						newElements[elements.Length + addedCount++] = o;
					}
				}
				if (addedCount < toAdd.Length)
				{
					newElements = java.util.Arrays.copyOfRange(newElements, 0, elements.Length + addedCount
						);
				}
				elements = newElements;
				return addedCount;
			}
		}

		/// <summary>
		/// Adds
		/// <code>object</code>
		/// to the end of this list if it is not already present.
		/// <p>Callers of this method may prefer
		/// <see cref="CopyOnWriteArraySet{E}">CopyOnWriteArraySet&lt;E&gt;</see>
		/// , whose
		/// API is more appropriate for set operations.
		/// </summary>
		public virtual bool addIfAbsent(E @object)
		{
			lock (this)
			{
				if (contains(@object))
				{
					return false;
				}
				add(@object);
				return true;
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual void clear()
		{
			lock (this)
			{
				elements = libcore.util.EmptyArray.OBJECT;
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual E remove(int index)
		{
			lock (this)
			{
				E removed = (E)elements[index];
				removeRange(index, index + 1);
				return removed;
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool remove(object o)
		{
			lock (this)
			{
				int index = indexOf(o);
				if (index == -1)
				{
					return false;
				}
				remove(index);
				return true;
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool removeAll<_T0>(java.util.Collection<_T0> collection)
		{
			lock (this)
			{
				return removeOrRetain(collection, false, 0, elements.Length) != 0;
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool retainAll<_T0>(java.util.Collection<_T0> collection)
		{
			lock (this)
			{
				return removeOrRetain(collection, true, 0, elements.Length) != 0;
			}
		}

		/// <summary>
		/// Removes or retains the elements in
		/// <code>collection</code>
		/// . Returns the number
		/// of elements removed.
		/// </summary>
		private int removeOrRetain<_T0>(java.util.Collection<_T0> collection, bool retain
			, int from, int to)
		{
			{
				for (int i = from; i < to; i++)
				{
					if (collection.contains(elements[i]) == retain)
					{
						continue;
					}
					object[] newElements = new object[elements.Length - 1];
					System.Array.Copy(elements, 0, newElements, 0, i);
					int newSize = i;
					{
						for (int j = i + 1; j < to; j++)
						{
							if (collection.contains(elements[j]) == retain)
							{
								newElements[newSize++] = elements[j];
							}
						}
					}
					System.Array.Copy(elements, to, newElements, newSize, elements.Length - to);
					newSize += (elements.Length - to);
					if (newSize < newElements.Length)
					{
						newElements = java.util.Arrays.copyOfRange(newElements, 0, newSize);
					}
					int removed = elements.Length - newElements.Length;
					elements = newElements;
					return removed;
				}
			}
			return 0;
		}

		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual E set(int index, E e)
		{
			lock (this)
			{
				object[] newElements = (object[])elements.Clone();
				E result = (E)newElements[index];
				newElements[index] = e;
				elements = newElements;
				return result;
			}
		}

		private void removeRange(int from, int to)
		{
			object[] newElements = new object[elements.Length - (to - from)];
			System.Array.Copy(elements, 0, newElements, 0, from);
			System.Array.Copy(elements, to, newElements, from, elements.Length - to);
			elements = newElements;
		}

		internal static int lastIndexOf(object o, object[] data, int from, int to)
		{
			if (o == null)
			{
				{
					for (int i = to - 1; i >= from; i--)
					{
						if (data[i] == null)
						{
							return i;
						}
					}
				}
			}
			else
			{
				{
					for (int i = to - 1; i >= from; i--)
					{
						if (o.Equals(data[i]))
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		internal static int indexOf(object o, object[] data, int from, int to)
		{
			if (o == null)
			{
				{
					for (int i = from; i < to; i++)
					{
						if (data[i] == null)
						{
							return i;
						}
					}
				}
			}
			else
			{
				{
					for (int i = from; i < to; i++)
					{
						if (o.Equals(data[i]))
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		internal object[] getArray()
		{
			return elements;
		}

		/// <summary>The sub list is thread safe and supports non-blocking reads.</summary>
		/// <remarks>
		/// The sub list is thread safe and supports non-blocking reads. Doing so is
		/// more difficult than in the full list, because each read needs to examine
		/// four fields worth of state:
		/// - the elements array of the full list
		/// - two integers for the bounds of this sub list
		/// - the expected elements array (to detect concurrent modification)
		/// This is accomplished by aggregating the sub list's three fields into a
		/// single snapshot object representing the current slice. This permits reads
		/// to be internally consistent without synchronization. This takes advantage
		/// of Java's concurrency semantics for final fields.
		/// </remarks>
		internal class CowSubList : java.util.AbstractList<E>
		{
			internal volatile java.util.concurrent.CopyOnWriteArrayList.Slice slice;

			public CowSubList(CopyOnWriteArrayList<E> _enclosing, object[] expectedElements, 
				int from, int to)
			{
				this._enclosing = _enclosing;
				this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(expectedElements
					, from, to);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				return slice.to - slice.from;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool isEmpty()
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				return slice.from == slice.to;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E get(int index)
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				object[] snapshot = this._enclosing.elements;
				slice.checkElementIndex(index);
				slice.checkConcurrentModification(snapshot);
				return (E)snapshot[index + slice.from];
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<E> iterator()
			{
				return this.listIterator(0);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override java.util.ListIterator<E> listIterator()
			{
				return this.listIterator(0);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override java.util.ListIterator<E> listIterator(int index)
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				object[] snapshot = this._enclosing.elements;
				slice.checkPositionIndex(index);
				slice.checkConcurrentModification(snapshot);
				java.util.concurrent.CopyOnWriteArrayList.CowIterator<E> result = new java.util.concurrent.CopyOnWriteArrayList
					.CowIterator<E>(snapshot, slice.from, slice.to);
				result.index = slice.from + index;
				return result;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override int indexOf(object @object)
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				object[] snapshot = this._enclosing.elements;
				slice.checkConcurrentModification(snapshot);
				int result = java.util.concurrent.CopyOnWriteArrayList<E>.indexOf(@object, snapshot
					, slice.from, slice.to);
				return (result != -1) ? (result - slice.from) : -1;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override int lastIndexOf(object @object)
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				object[] snapshot = this._enclosing.elements;
				slice.checkConcurrentModification(snapshot);
				int result = java.util.concurrent.CopyOnWriteArrayList<E>.lastIndexOf(@object, snapshot
					, slice.from, slice.to);
				return (result != -1) ? (result - slice.from) : -1;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object @object)
			{
				return this.indexOf(@object) != -1;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool containsAll<_T0>(java.util.Collection<_T0> collection)
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				object[] snapshot = this._enclosing.elements;
				slice.checkConcurrentModification(snapshot);
				return java.util.concurrent.CopyOnWriteArrayList<E>.containsAll(collection, snapshot
					, slice.from, slice.to);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override java.util.List<E> subList(int from, int to)
			{
				java.util.concurrent.CopyOnWriteArrayList.Slice slice = this.slice;
				if (from < 0 || from > to || to > this.size())
				{
					throw new System.IndexOutOfRangeException("from=" + from + ", to=" + to + ", list size="
						 + this.size());
				}
				return new java.util.concurrent.CopyOnWriteArrayList<E>.CowSubList(this._enclosing
					, slice.expectedElements, slice.from + from, slice.from + to);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E remove(int index)
			{
				lock (this._enclosing)
				{
					this.slice.checkElementIndex(index);
					this.slice.checkConcurrentModification(this._enclosing.elements);
					E removed = this._enclosing.remove(this.slice.from + index);
					this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(this._enclosing.
						elements, this.slice.from, this.slice.to - 1);
					return removed;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				lock (this._enclosing)
				{
					this.slice.checkConcurrentModification(this._enclosing.elements);
					this._enclosing.removeRange(this.slice.from, this.slice.to);
					this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(this._enclosing.
						elements, this.slice.from, this.slice.from);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override void add(int index, E @object)
			{
				lock (this._enclosing)
				{
					this.slice.checkPositionIndex(index);
					this.slice.checkConcurrentModification(this._enclosing.elements);
					this._enclosing.add(index + this.slice.from, @object);
					this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(this._enclosing.
						elements, this.slice.from, this.slice.to + 1);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool add(E @object)
			{
				lock (this._enclosing)
				{
					this.add(this.slice.to - this.slice.from, @object);
					return true;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override bool addAll<_T0>(int index, java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					this.slice.checkPositionIndex(index);
					this.slice.checkConcurrentModification(this._enclosing.elements);
					int oldSize = this._enclosing.elements.Length;
					bool result = this._enclosing.addAll(index + this.slice.from, collection);
					this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(this._enclosing.
						elements, this.slice.from, this.slice.to + (this._enclosing.elements.Length - oldSize
						));
					return result;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool addAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					return this.addAll(this.size(), collection);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E set(int index, E @object)
			{
				lock (this._enclosing)
				{
					this.slice.checkElementIndex(index);
					this.slice.checkConcurrentModification(this._enclosing.elements);
					E result = this._enclosing.set(index + this.slice.from, @object);
					this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(this._enclosing.
						elements, this.slice.from, this.slice.to);
					return result;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool remove(object @object)
			{
				lock (this._enclosing)
				{
					int index = this.indexOf(@object);
					if (index == -1)
					{
						return false;
					}
					this.remove(index);
					return true;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool removeAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					this.slice.checkConcurrentModification(this._enclosing.elements);
					int removed = this._enclosing.removeOrRetain(collection, false, this.slice.from, 
						this.slice.to);
					this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(this._enclosing.
						elements, this.slice.from, this.slice.to - removed);
					return removed != 0;
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool retainAll<_T0>(java.util.Collection<_T0> collection)
			{
				lock (this._enclosing)
				{
					this.slice.checkConcurrentModification(this._enclosing.elements);
					int removed = this._enclosing.removeOrRetain(collection, true, this.slice.from, this
						.slice.to);
					this.slice = new java.util.concurrent.CopyOnWriteArrayList.Slice(this._enclosing.
						elements, this.slice.from, this.slice.to - removed);
					return removed != 0;
				}
			}

			private readonly CopyOnWriteArrayList<E> _enclosing;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream @out)
		{
			object[] snapshot = elements;
			@out.defaultWriteObject();
			@out.writeInt(snapshot.Length);
			foreach (object o in snapshot)
			{
				@out.writeObject(o);
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream @in)
		{
			lock (this)
			{
				@in.defaultReadObject();
				object[] snapshot = new object[@in.readInt()];
				{
					for (int i = 0; i < snapshot.Length; i++)
					{
						snapshot[i] = @in.readObject();
					}
				}
				elements = snapshot;
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
