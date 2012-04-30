using Sharpen;

namespace java.util
{
	/// <summary>
	/// <code>AbstractList</code>
	/// is an abstract implementation of the
	/// <code>List</code>
	/// interface, optimized
	/// for a backing store which supports random access. This implementation does
	/// not support adding or replacing. A subclass must implement the abstract
	/// methods
	/// <code>get()</code>
	/// and
	/// <code>size()</code>
	/// , and to create a
	/// modifiable
	/// <code>List</code>
	/// it's necessary to override the
	/// <code>add()</code>
	/// method that
	/// currently throws an
	/// <code>UnsupportedOperationException</code>
	/// .
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public static class AbstractList
	{
		internal sealed class SubAbstractListRandomAccess<E> : java.util.AbstractList.SubAbstractList
			<E>, java.util.RandomAccess
		{
			internal SubAbstractListRandomAccess(java.util.AbstractList<E> list, int start, int
				 end) : base(list, start, end)
			{
			}
		}

		internal static class SubAbstractList
		{
			internal sealed class SubAbstractListIterator<E> : java.util.ListIterator<E>
			{
				internal readonly java.util.AbstractList.SubAbstractList<E> subList;

				internal readonly java.util.ListIterator<E> iterator;

				internal int start;

				internal int end;

				internal SubAbstractListIterator(java.util.ListIterator<E> it, java.util.AbstractList
					.SubAbstractList<E> list, int offset, int length)
				{
					iterator = it;
					subList = list;
					start = offset;
					end = start + length;
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public void add(E @object)
				{
					iterator.add(@object);
					subList.sizeChanged(true);
					end++;
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public bool hasNext()
				{
					return iterator.nextIndex() < end;
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public bool hasPrevious()
				{
					return iterator.previousIndex() >= start;
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public E next()
				{
					if (iterator.nextIndex() < end)
					{
						return iterator.next();
					}
					throw new java.util.NoSuchElementException();
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public int nextIndex()
				{
					return iterator.nextIndex() - start;
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public E previous()
				{
					if (iterator.previousIndex() >= start)
					{
						return iterator.previous();
					}
					throw new java.util.NoSuchElementException();
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public int previousIndex()
				{
					int previous_1 = iterator.previousIndex();
					if (previous_1 >= start)
					{
						return previous_1 - start;
					}
					return -1;
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public void remove()
				{
					iterator.remove();
					subList.sizeChanged(false);
					end--;
				}

				[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
				public void set(E @object)
				{
					iterator.set(@object);
				}
			}
		}

		internal class SubAbstractList<E> : java.util.AbstractList<E>
		{
			internal readonly java.util.AbstractList<E> fullList;

			internal int offset;

			internal int _size;

			internal SubAbstractList(java.util.AbstractList<E> list, int start, int end)
			{
				fullList = list;
				modCount = fullList.modCount;
				offset = start;
				_size = end - start;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override void add(int location, E @object)
			{
				if (modCount == fullList.modCount)
				{
					if (location >= 0 && location <= _size)
					{
						fullList.add(location + offset, @object);
						_size++;
						modCount = fullList.modCount;
					}
					else
					{
						throw new System.IndexOutOfRangeException();
					}
				}
				else
				{
					throw new java.util.ConcurrentModificationException();
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override bool addAll<_T0>(int location, java.util.Collection<_T0> collection
				)
			{
				if (modCount == fullList.modCount)
				{
					if (location >= 0 && location <= _size)
					{
						bool result = fullList.addAll(location + offset, collection);
						if (result)
						{
							_size += collection.size();
							modCount = fullList.modCount;
						}
						return result;
					}
					throw new System.IndexOutOfRangeException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool addAll<_T0>(java.util.Collection<_T0> collection)
			{
				if (modCount == fullList.modCount)
				{
					bool result = fullList.addAll(offset + _size, collection);
					if (result)
					{
						_size += collection.size();
						modCount = fullList.modCount;
					}
					return result;
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E get(int location)
			{
				if (modCount == fullList.modCount)
				{
					if (location >= 0 && location < _size)
					{
						return fullList.get(location + offset);
					}
					throw new System.IndexOutOfRangeException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<E> iterator()
			{
				return listIterator(0);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override java.util.ListIterator<E> listIterator(int location)
			{
				if (modCount == fullList.modCount)
				{
					if (location >= 0 && location <= _size)
					{
						return new java.util.AbstractList.SubAbstractList.SubAbstractListIterator<E>(fullList
							.listIterator(location + offset), this, offset, _size);
					}
					throw new System.IndexOutOfRangeException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E remove(int location)
			{
				if (modCount == fullList.modCount)
				{
					if (location >= 0 && location < _size)
					{
						E result = fullList.remove(location + offset);
						_size--;
						modCount = fullList.modCount;
						return result;
					}
					throw new System.IndexOutOfRangeException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			protected internal override void removeRange(int start, int end)
			{
				if (start != end)
				{
					if (modCount == fullList.modCount)
					{
						fullList.removeRange(start + offset, end + offset);
						_size -= end - start;
						modCount = fullList.modCount;
					}
					else
					{
						throw new java.util.ConcurrentModificationException();
					}
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E set(int location, E @object)
			{
				if (modCount == fullList.modCount)
				{
					if (location >= 0 && location < _size)
					{
						return fullList.set(location + offset, @object);
					}
					throw new System.IndexOutOfRangeException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				if (modCount == fullList.modCount)
				{
					return _size;
				}
				throw new java.util.ConcurrentModificationException();
			}

			internal virtual void sizeChanged(bool increment)
			{
				if (increment)
				{
					_size++;
				}
				else
				{
					_size--;
				}
				modCount = fullList.modCount;
			}
		}
	}

	/// <summary>
	/// <code>AbstractList</code>
	/// is an abstract implementation of the
	/// <code>List</code>
	/// interface, optimized
	/// for a backing store which supports random access. This implementation does
	/// not support adding or replacing. A subclass must implement the abstract
	/// methods
	/// <code>get()</code>
	/// and
	/// <code>size()</code>
	/// , and to create a
	/// modifiable
	/// <code>List</code>
	/// it's necessary to override the
	/// <code>add()</code>
	/// method that
	/// currently throws an
	/// <code>UnsupportedOperationException</code>
	/// .
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public abstract class AbstractList<E> : java.util.AbstractCollection<E>, java.util.List
		<E>
	{
		/// <summary>A counter for changes to the list.</summary>
		/// <remarks>A counter for changes to the list.</remarks>
		[System.NonSerialized]
		protected internal int modCount;

		internal class SimpleListIterator : java.util.Iterator<E>
		{
			internal int pos;

			internal int expectedModCount;

			internal int lastPosition;

			internal SimpleListIterator(AbstractList<E> _enclosing)
			{
				this._enclosing = _enclosing;
				pos = -1;
				lastPosition = -1;
				this.expectedModCount = this._enclosing.modCount;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				return this.pos + 1 < this._enclosing.size();
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual E next()
			{
				if (this.expectedModCount == this._enclosing.modCount)
				{
					try
					{
						E result = this._enclosing.get(this.pos + 1);
						this.lastPosition = ++this.pos;
						return result;
					}
					catch (System.IndexOutOfRangeException)
					{
						throw new java.util.NoSuchElementException();
					}
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				if (this.lastPosition == -1)
				{
					throw new System.InvalidOperationException();
				}
				if (this.expectedModCount != this._enclosing.modCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				try
				{
					this._enclosing.remove(this.lastPosition);
				}
				catch (System.IndexOutOfRangeException)
				{
					throw new java.util.ConcurrentModificationException();
				}
				this.expectedModCount = this._enclosing.modCount;
				if (this.pos == this.lastPosition)
				{
					this.pos--;
				}
				this.lastPosition = -1;
			}

			private readonly AbstractList<E> _enclosing;
		}

		internal sealed class FullListIterator : java.util.AbstractList<E>.SimpleListIterator
			, java.util.ListIterator<E>
		{
			internal FullListIterator(AbstractList<E> _enclosing, int start) : base(_enclosing
				)
			{
				this._enclosing = _enclosing;
				if (start >= 0 && start <= this._enclosing.size())
				{
					this.pos = start - 1;
				}
				else
				{
					throw new System.IndexOutOfRangeException();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public void add(E @object)
			{
				if (this.expectedModCount == this._enclosing.modCount)
				{
					try
					{
						this._enclosing.add(this.pos + 1, @object);
					}
					catch (System.IndexOutOfRangeException)
					{
						throw new java.util.NoSuchElementException();
					}
					this.pos++;
					this.lastPosition = -1;
					if (this._enclosing.modCount != this.expectedModCount)
					{
						this.expectedModCount = this._enclosing.modCount;
					}
				}
				else
				{
					throw new java.util.ConcurrentModificationException();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public bool hasPrevious()
			{
				return this.pos >= 0;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public int nextIndex()
			{
				return this.pos + 1;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public E previous()
			{
				if (this.expectedModCount == this._enclosing.modCount)
				{
					try
					{
						E result = this._enclosing.get(this.pos);
						this.lastPosition = this.pos;
						this.pos--;
						return result;
					}
					catch (System.IndexOutOfRangeException)
					{
						throw new java.util.NoSuchElementException();
					}
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public int previousIndex()
			{
				return this.pos;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public void set(E @object)
			{
				if (this.expectedModCount == this._enclosing.modCount)
				{
					try
					{
						this._enclosing.set(this.lastPosition, @object);
					}
					catch (System.IndexOutOfRangeException)
					{
						throw new System.InvalidOperationException();
					}
				}
				else
				{
					throw new java.util.ConcurrentModificationException();
				}
			}

			private readonly AbstractList<E> _enclosing;
		}

		/// <summary>Constructs a new instance of this AbstractList.</summary>
		/// <remarks>Constructs a new instance of this AbstractList.</remarks>
		protected internal AbstractList()
		{
		}

		/// <summary>Inserts the specified object into this List at the specified location.</summary>
		/// <remarks>
		/// Inserts the specified object into this List at the specified location.
		/// The object is inserted before any previous element at the specified
		/// location. If the location is equal to the size of this List, the object
		/// is added at the end.
		/// <p>
		/// Concrete implementations that would like to support the add functionality
		/// must override this method.
		/// </remarks>
		/// <param name="location">the index at which to insert.</param>
		/// <param name="object">the object to add.</param>
		/// <exception cref="System.NotSupportedException">if adding to this List is not supported.
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the object is inappropriate for this
		/// List
		/// </exception>
		/// <exception cref="System.ArgumentException">if the object cannot be added to this List
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual void add(int location, E @object)
		{
			throw new System.NotSupportedException();
		}

		/// <summary>Adds the specified object at the end of this List.</summary>
		/// <remarks>Adds the specified object at the end of this List.</remarks>
		/// <param name="object">the object to add</param>
		/// <returns>true</returns>
		/// <exception cref="System.NotSupportedException">if adding to this List is not supported
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the object is inappropriate for this
		/// List
		/// </exception>
		/// <exception cref="System.ArgumentException">if the object cannot be added to this List
		/// 	</exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool add(E @object)
		{
			add(size(), @object);
			return true;
		}

		/// <summary>
		/// Inserts the objects in the specified Collection at the specified location
		/// in this List.
		/// </summary>
		/// <remarks>
		/// Inserts the objects in the specified Collection at the specified location
		/// in this List. The objects are added in the order they are returned from
		/// the collection's iterator.
		/// </remarks>
		/// <param name="location">the index at which to insert.</param>
		/// <param name="collection">the Collection of objects</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this List is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">if adding to this list is not supported.
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">if the class of an object is inappropriate for this list.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">if an object cannot be added to this list.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt; size()</code>
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual bool addAll<_T0>(int location, java.util.Collection<_T0> collection
			) where _T0:E
		{
			java.util.Iterator<_T0> it = collection.iterator();
			while (it.hasNext())
			{
				add(location++, it.next());
			}
			return !collection.isEmpty();
		}

		/// <summary>Removes all elements from this list, leaving it empty.</summary>
		/// <remarks>Removes all elements from this list, leaving it empty.</remarks>
		/// <exception cref="System.NotSupportedException">if removing from this list is not supported.
		/// 	</exception>
		/// <seealso cref="List{E}.isEmpty()">List&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="List{E}.size()">List&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override void clear()
		{
			removeRange(0, size());
		}

		/// <summary>
		/// Compares the specified object to this list and return true if they are
		/// equal.
		/// </summary>
		/// <remarks>
		/// Compares the specified object to this list and return true if they are
		/// equal. Two lists are equal when they both contain the same objects in the
		/// same order.
		/// </remarks>
		/// <param name="object">the object to compare to this object.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the specified object is equal to this list,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="AbstractList{E}.GetHashCode()">AbstractList&lt;E&gt;.GetHashCode()
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			if (this == @object)
			{
				return true;
			}
			if (@object is java.util.List<E>)
			{
				java.util.List<E> list = (java.util.List<E>)@object;
				if (list.size() != size())
				{
					return false;
				}
				java.util.Iterator<E> it1 = iterator();
				java.util.Iterator<E> it2 = list.iterator();
				while (it1.hasNext())
				{
					object e1 = it1.next();
					object e2 = it2.next();
					if (!(e1 == null ? e2 == null : e1.Equals(e2)))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>Returns the element at the specified location in this list.</summary>
		/// <remarks>Returns the element at the specified location in this list.</remarks>
		/// <param name="location">the index of the element to return.</param>
		/// <returns>the element at the specified index.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public abstract E get(int location);

		/// <summary>Returns the hash code of this list.</summary>
		/// <remarks>
		/// Returns the hash code of this list. The hash code is calculated by taking
		/// each element's hashcode into account.
		/// </remarks>
		/// <returns>the hash code.</returns>
		/// <seealso cref="AbstractList{E}.Equals(object)">AbstractList&lt;E&gt;.Equals(object)
		/// 	</seealso>
		/// <seealso cref="List{E}.GetHashCode()">List&lt;E&gt;.GetHashCode()</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int result = 1;
			java.util.Iterator<E> it = iterator();
			while (it.hasNext())
			{
				object @object = it.next();
				result = (31 * result) + (@object == null ? 0 : @object.GetHashCode());
			}
			return result;
		}

		/// <summary>
		/// Searches this list for the specified object and returns the index of the
		/// first occurrence.
		/// </summary>
		/// <remarks>
		/// Searches this list for the specified object and returns the index of the
		/// first occurrence.
		/// </remarks>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// the index of the first occurrence of the object, or -1 if it was
		/// not found.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual int indexOf(object @object)
		{
			java.util.ListIterator<E> it = listIterator();
			if (@object != null)
			{
				while (it.hasNext())
				{
					if (@object.Equals(it.next()))
					{
						return it.previousIndex();
					}
				}
			}
			else
			{
				while (it.hasNext())
				{
					if (it.next() == null)
					{
						return it.previousIndex();
					}
				}
			}
			return -1;
		}

		/// <summary>Returns an iterator on the elements of this list.</summary>
		/// <remarks>
		/// Returns an iterator on the elements of this list. The elements are
		/// iterated in the same order as they occur in the list.
		/// </remarks>
		/// <returns>an iterator on the elements of this list.</returns>
		/// <seealso cref="Iterator{E}">Iterator&lt;E&gt;</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override java.util.Iterator<E> iterator()
		{
			return new java.util.AbstractList<E>.SimpleListIterator(this);
		}

		/// <summary>
		/// Searches this list for the specified object and returns the index of the
		/// last occurrence.
		/// </summary>
		/// <remarks>
		/// Searches this list for the specified object and returns the index of the
		/// last occurrence.
		/// </remarks>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// the index of the last occurrence of the object, or -1 if the
		/// object was not found.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual int lastIndexOf(object @object)
		{
			java.util.ListIterator<E> it = listIterator(size());
			if (@object != null)
			{
				while (it.hasPrevious())
				{
					if (@object.Equals(it.previous()))
					{
						return it.nextIndex();
					}
				}
			}
			else
			{
				while (it.hasPrevious())
				{
					if (it.previous() == null)
					{
						return it.nextIndex();
					}
				}
			}
			return -1;
		}

		/// <summary>Returns a ListIterator on the elements of this list.</summary>
		/// <remarks>
		/// Returns a ListIterator on the elements of this list. The elements are
		/// iterated in the same order that they occur in the list.
		/// </remarks>
		/// <returns>a ListIterator on the elements of this list</returns>
		/// <seealso cref="ListIterator{E}">ListIterator&lt;E&gt;</seealso>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual java.util.ListIterator<E> listIterator()
		{
			return listIterator(0);
		}

		/// <summary>Returns a list iterator on the elements of this list.</summary>
		/// <remarks>
		/// Returns a list iterator on the elements of this list. The elements are
		/// iterated in the same order as they occur in the list. The iteration
		/// starts at the specified location.
		/// </remarks>
		/// <param name="location">the index at which to start the iteration.</param>
		/// <returns>a ListIterator on the elements of this list.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt; size()</code>
		/// </exception>
		/// <seealso cref="ListIterator{E}">ListIterator&lt;E&gt;</seealso>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual java.util.ListIterator<E> listIterator(int location)
		{
			return new java.util.AbstractList<E>.FullListIterator(this, location);
		}

		/// <summary>Removes the object at the specified location from this list.</summary>
		/// <remarks>Removes the object at the specified location from this list.</remarks>
		/// <param name="location">the index of the object to remove.</param>
		/// <returns>the removed object.</returns>
		/// <exception cref="System.NotSupportedException">if removing from this list is not supported.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual E remove(int location)
		{
			throw new System.NotSupportedException();
		}

		/// <summary>
		/// Removes the objects in the specified range from the start to the end
		/// index minus one.
		/// </summary>
		/// <remarks>
		/// Removes the objects in the specified range from the start to the end
		/// index minus one.
		/// </remarks>
		/// <param name="start">the index at which to start removing.</param>
		/// <param name="end">the index after the last element to remove.</param>
		/// <exception cref="System.NotSupportedException">if removing from this list is not supported.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>start &gt;= size()</code>
		/// .
		/// </exception>
		protected internal virtual void removeRange(int start, int end)
		{
			java.util.Iterator<E> it = listIterator(start);
			{
				for (int i = start; i < end; i++)
				{
					it.next();
					it.remove();
				}
			}
		}

		/// <summary>
		/// Replaces the element at the specified location in this list with the
		/// specified object.
		/// </summary>
		/// <remarks>
		/// Replaces the element at the specified location in this list with the
		/// specified object.
		/// </remarks>
		/// <param name="location">the index at which to put the specified object.</param>
		/// <param name="object">the object to add.</param>
		/// <returns>the previous element at the index.</returns>
		/// <exception cref="System.NotSupportedException">if replacing elements in this list is not supported.
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">if the class of an object is inappropriate for this list.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">if an object cannot be added to this list.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual E set(int location, E @object)
		{
			throw new System.NotSupportedException();
		}

		/// <summary>Returns a part of consecutive elements of this list as a view.</summary>
		/// <remarks>
		/// Returns a part of consecutive elements of this list as a view. The
		/// returned view will be of zero length if start equals end. Any change that
		/// occurs in the returned subList will be reflected to the original list,
		/// and vice-versa. All the supported optional operations by the original
		/// list will also be supported by this subList.
		/// <p>
		/// This method can be used as a handy method to do some operations on a sub
		/// range of the original list, for example
		/// <code>list.subList(from, to).clear();</code>
		/// <p>
		/// If the original list is modified in other ways than through the returned
		/// subList, the behavior of the returned subList becomes undefined.
		/// <p>
		/// The returned subList is a subclass of AbstractList. The subclass stores
		/// offset, size of itself, and modCount of the original list. If the
		/// original list implements RandomAccess interface, the returned subList
		/// also implements RandomAccess interface.
		/// <p>
		/// The subList's set(int, Object), get(int), add(int, Object), remove(int),
		/// addAll(int, Collection) and removeRange(int, int) methods first check the
		/// bounds, adjust offsets and then call the corresponding methods of the
		/// original AbstractList. addAll(Collection c) method of the returned
		/// subList calls the original addAll(offset + size, c).
		/// <p>
		/// The listIterator(int) method of the subList wraps the original list
		/// iterator. The iterator() method of the subList invokes the original
		/// listIterator() method, and the size() method merely returns the size of
		/// the subList.
		/// <p>
		/// All methods will throw a ConcurrentModificationException if the modCount
		/// of the original list is not equal to the expected value.
		/// </remarks>
		/// <param name="start">start index of the subList (inclusive).</param>
		/// <param name="end">end index of the subList, (exclusive).</param>
		/// <returns>
		/// a subList view of this list starting from
		/// <code>start</code>
		/// (inclusive), and ending with
		/// <code>end</code>
		/// (exclusive)
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">if (start &lt; 0 || end &gt; size())
		/// 	</exception>
		/// <exception cref="System.ArgumentException">if (start &gt; end)</exception>
		[Sharpen.ImplementsInterface(@"java.util.List")]
		public virtual java.util.List<E> subList(int start, int end)
		{
			if (start >= 0 && end <= size())
			{
				if (start <= end)
				{
					if (this is java.util.RandomAccess)
					{
						return new java.util.AbstractList.SubAbstractListRandomAccess<E>(this, start, end
							);
					}
					return new java.util.AbstractList.SubAbstractList<E>(this, start, end);
				}
				throw new System.ArgumentException();
			}
			throw new System.IndexOutOfRangeException();
		}
	}
}
