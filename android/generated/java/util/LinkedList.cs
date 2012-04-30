using Sharpen;

namespace java.util
{
	/// <summary>
	/// LinkedList is an implementation of
	/// <see cref="List{E}">List&lt;E&gt;</see>
	/// , backed by a doubly-linked list.
	/// All optional operations including adding, removing, and replacing elements are supported.
	/// <p>All elements are permitted, including null.
	/// <p>This class is primarily useful if you need queue-like behavior. It may also be useful
	/// as a list if you expect your lists to contain zero or one element, but still require the
	/// ability to scale to slightly larger numbers of elements. In general, though, you should
	/// probably use
	/// <see cref="ArrayList{E}">ArrayList&lt;E&gt;</see>
	/// if you don't need the queue-like behavior.
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public static partial class LinkedList
	{
		internal const long serialVersionUID = 876323262645176354L;

		internal sealed class Link<ET>
		{
			internal ET data;

			internal java.util.LinkedList.Link<ET> previous;

			internal java.util.LinkedList.Link<ET> next;

			internal Link(ET o, java.util.LinkedList.Link<ET> p, java.util.LinkedList.Link<ET
				> n)
			{
				data = o;
				previous = p;
				next = n;
			}
		}

		internal sealed class LinkIterator<ET> : java.util.ListIterator<ET>
		{
			internal int pos;

			internal int expectedModCount;

			internal readonly java.util.LinkedList<ET> list;

			internal java.util.LinkedList.Link<ET> link;

			internal java.util.LinkedList.Link<ET> lastLink;

			internal LinkIterator(java.util.LinkedList<ET> @object, int location)
			{
				list = @object;
				expectedModCount = list.modCount;
				if (location >= 0 && location <= list._size)
				{
					// pos ends up as -1 if list is empty, it ranges from -1 to
					// list.size - 1
					// if link == voidLink then pos must == -1
					link = list.voidLink;
					if (location < list._size / 2)
					{
						for (pos = -1; pos + 1 < location; pos++)
						{
							link = link.next;
						}
					}
					else
					{
						for (pos = list._size; pos >= location; pos--)
						{
							link = link.previous;
						}
					}
				}
				else
				{
					throw new System.IndexOutOfRangeException();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public void add(ET @object)
			{
				if (expectedModCount == list.modCount)
				{
					java.util.LinkedList.Link<ET> next_1 = link.next;
					java.util.LinkedList.Link<ET> newLink = new java.util.LinkedList.Link<ET>(@object
						, link, next_1);
					link.next = newLink;
					next_1.previous = newLink;
					link = newLink;
					lastLink = null;
					pos++;
					expectedModCount++;
					list._size++;
					list.modCount++;
				}
				else
				{
					throw new java.util.ConcurrentModificationException();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public bool hasNext()
			{
				return link.next != list.voidLink;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public bool hasPrevious()
			{
				return link != list.voidLink;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public ET next()
			{
				if (expectedModCount == list.modCount)
				{
					java.util.LinkedList.Link<ET> next_1 = link.next;
					if (next_1 != list.voidLink)
					{
						lastLink = link = next_1;
						pos++;
						return link.data;
					}
					throw new java.util.NoSuchElementException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public int nextIndex()
			{
				return pos + 1;
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public ET previous()
			{
				if (expectedModCount == list.modCount)
				{
					if (link != list.voidLink)
					{
						lastLink = link;
						link = link.previous;
						pos--;
						return lastLink.data;
					}
					throw new java.util.NoSuchElementException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public int previousIndex()
			{
				return pos;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public void remove()
			{
				if (expectedModCount == list.modCount)
				{
					if (lastLink != null)
					{
						java.util.LinkedList.Link<ET> next_1 = lastLink.next;
						java.util.LinkedList.Link<ET> previous_1 = lastLink.previous;
						next_1.previous = previous_1;
						previous_1.next = next_1;
						if (lastLink == link)
						{
							pos--;
						}
						link = previous_1;
						lastLink = null;
						expectedModCount++;
						list._size--;
						list.modCount++;
					}
					else
					{
						throw new System.InvalidOperationException();
					}
				}
				else
				{
					throw new java.util.ConcurrentModificationException();
				}
			}

			[Sharpen.ImplementsInterface(@"java.util.ListIterator")]
			public void set(ET @object)
			{
				if (expectedModCount == list.modCount)
				{
					if (lastLink != null)
					{
						lastLink.data = @object;
					}
					else
					{
						throw new System.InvalidOperationException();
					}
				}
				else
				{
					throw new java.util.ConcurrentModificationException();
				}
			}
		}
	}

	/// <summary>
	/// LinkedList is an implementation of
	/// <see cref="List{E}">List&lt;E&gt;</see>
	/// , backed by a doubly-linked list.
	/// All optional operations including adding, removing, and replacing elements are supported.
	/// <p>All elements are permitted, including null.
	/// <p>This class is primarily useful if you need queue-like behavior. It may also be useful
	/// as a list if you expect your lists to contain zero or one element, but still require the
	/// ability to scale to slightly larger numbers of elements. In general, though, you should
	/// probably use
	/// <see cref="ArrayList{E}">ArrayList&lt;E&gt;</see>
	/// if you don't need the queue-like behavior.
	/// </summary>
	/// <since>1.2</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public partial class LinkedList<E> : java.util.AbstractSequentialList<E>, java.util.List
		<E>, java.util.Deque<E>, java.util.Queue<E>, System.ICloneable
	{
		[System.NonSerialized]
		internal int _size = 0;

		[System.NonSerialized]
		internal java.util.LinkedList.Link<E> voidLink;

		private class ReverseLinkIterator<ET> : java.util.Iterator<ET>
		{
			internal int expectedModCount;

			internal readonly java.util.LinkedList<ET> list;

			internal java.util.LinkedList.Link<ET> link;

			internal bool canRemove;

			internal ReverseLinkIterator(LinkedList<E> _enclosing, java.util.LinkedList<ET> linkedList
				)
			{
				this._enclosing = _enclosing;
				this.list = linkedList;
				this.expectedModCount = this.list.modCount;
				this.link = this.list.voidLink;
				this.canRemove = false;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				return this.link.previous != this.list.voidLink;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual ET next()
			{
				if (this.expectedModCount == this.list.modCount)
				{
					if (this.hasNext())
					{
						this.link = this.link.previous;
						this.canRemove = true;
						return this.link.data;
					}
					throw new java.util.NoSuchElementException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				if (this.expectedModCount == this.list.modCount)
				{
					if (this.canRemove)
					{
						java.util.LinkedList.Link<ET> next_1 = this.link.previous;
						java.util.LinkedList.Link<ET> previous = this.link.next;
						next_1.next = previous;
						previous.previous = next_1;
						this.link = previous;
						this.list._size--;
						this.list.modCount++;
						this.expectedModCount++;
						this.canRemove = false;
						return;
					}
					throw new System.InvalidOperationException();
				}
				throw new java.util.ConcurrentModificationException();
			}

			private readonly LinkedList<E> _enclosing;
		}

		/// <summary>
		/// Constructs a new empty instance of
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		public LinkedList()
		{
			voidLink = new java.util.LinkedList.Link<E>(default(E), null, null);
			voidLink.previous = voidLink;
			voidLink.next = voidLink;
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>LinkedList</code>
		/// that holds all of the
		/// elements contained in the specified
		/// <code>collection</code>
		/// . The order of the
		/// elements in this new
		/// <code>LinkedList</code>
		/// will be determined by the
		/// iteration order of
		/// <code>collection</code>
		/// .
		/// </summary>
		/// <param name="collection">the collection of elements to add.</param>
		public LinkedList(java.util.Collection<E> collection) : this()
		{
			addAll(collection);
		}

		/// <summary>
		/// Inserts the specified object into this
		/// <code>LinkedList</code>
		/// at the
		/// specified location. The object is inserted before any previous element at
		/// the specified location. If the location is equal to the size of this
		/// <code>LinkedList</code>
		/// , the object is added at the end.
		/// </summary>
		/// <param name="location">the index at which to insert.</param>
		/// <param name="object">the object to add.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override void add(int location, E @object)
		{
			if (location >= 0 && location <= _size)
			{
				java.util.LinkedList.Link<E> link = voidLink;
				if (location < (_size / 2))
				{
					{
						for (int i = 0; i <= location; i++)
						{
							link = link.next;
						}
					}
				}
				else
				{
					{
						for (int i = _size; i > location; i--)
						{
							link = link.previous;
						}
					}
				}
				java.util.LinkedList.Link<E> previous = link.previous;
				java.util.LinkedList.Link<E> newLink = new java.util.LinkedList.Link<E>(@object, 
					previous, link);
				previous.next = newLink;
				link.previous = newLink;
				_size++;
				modCount++;
			}
			else
			{
				throw new System.IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Adds the specified object at the end of this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <param name="object">the object to add.</param>
		/// <returns>always true</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool add(E @object)
		{
			return addLastImpl(@object);
		}

		private bool addLastImpl(E @object)
		{
			java.util.LinkedList.Link<E> oldLast = voidLink.previous;
			java.util.LinkedList.Link<E> newLink = new java.util.LinkedList.Link<E>(@object, 
				oldLast, voidLink);
			voidLink.previous = newLink;
			oldLast.next = newLink;
			_size++;
			modCount++;
			return true;
		}

		/// <summary>
		/// Adds the specified object at the beginning of this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <param name="object">the object to add.</param>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual void addFirst(E @object)
		{
			addFirstImpl(@object);
		}

		private bool addFirstImpl(E @object)
		{
			java.util.LinkedList.Link<E> oldFirst = voidLink.next;
			java.util.LinkedList.Link<E> newLink = new java.util.LinkedList.Link<E>(@object, 
				voidLink, oldFirst);
			voidLink.next = newLink;
			oldFirst.previous = newLink;
			_size++;
			modCount++;
			return true;
		}

		/// <summary>
		/// Adds the specified object at the end of this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <param name="object">the object to add.</param>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual void addLast(E @object)
		{
			addLastImpl(@object);
		}

		/// <summary>
		/// Removes all elements from this
		/// <code>LinkedList</code>
		/// , leaving it empty.
		/// </summary>
		/// <seealso cref="List{E}.isEmpty()">List&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="LinkedList{E}._size">LinkedList&lt;E&gt;._size</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override void clear()
		{
			if (_size > 0)
			{
				_size = 0;
				voidLink.next = voidLink;
				voidLink.previous = voidLink;
				modCount++;
			}
		}

		/// <summary>
		/// Returns a new
		/// <code>LinkedList</code>
		/// with the same elements and size as this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <returns>
		/// a shallow copy of this
		/// <code>LinkedList</code>
		/// .
		/// </returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		public virtual object clone()
		{
			java.util.LinkedList<E> l = (java.util.LinkedList<E>)base.MemberwiseClone();
			l._size = 0;
			l.voidLink = new java.util.LinkedList.Link<E>(default(E), null, null);
			l.voidLink.previous = l.voidLink;
			l.voidLink.next = l.voidLink;
			l.addAll(this);
			return l;
		}

		/// <summary>
		/// Searches this
		/// <code>LinkedList</code>
		/// for the specified object.
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>object</code>
		/// is an element of this
		/// <code>LinkedList</code>
		/// ,
		/// <code>false</code>
		/// otherwise
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool contains(object @object)
		{
			java.util.LinkedList.Link<E> link = voidLink.next;
			if (@object != null)
			{
				while (link != voidLink)
				{
					if (@object.Equals(link.data))
					{
						return true;
					}
					link = link.next;
				}
			}
			else
			{
				while (link != voidLink)
				{
					if ((object)link.data == null)
					{
						return true;
					}
					link = link.next;
				}
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E get(int location)
		{
			if (location >= 0 && location < _size)
			{
				java.util.LinkedList.Link<E> link = voidLink;
				if (location < (_size / 2))
				{
					{
						for (int i = 0; i <= location; i++)
						{
							link = link.next;
						}
					}
				}
				else
				{
					{
						for (int i = _size; i > location; i--)
						{
							link = link.previous;
						}
					}
				}
				return link.data;
			}
			throw new System.IndexOutOfRangeException();
		}

		/// <summary>
		/// Returns the first element in this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <returns>the first element.</returns>
		/// <exception cref="NoSuchElementException">
		/// if this
		/// <code>LinkedList</code>
		/// is empty.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E getFirst()
		{
			return getFirstImpl();
		}

		private E getFirstImpl()
		{
			java.util.LinkedList.Link<E> first = voidLink.next;
			if (first != voidLink)
			{
				return first.data;
			}
			throw new java.util.NoSuchElementException();
		}

		/// <summary>
		/// Returns the last element in this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <returns>the last element</returns>
		/// <exception cref="NoSuchElementException">
		/// if this
		/// <code>LinkedList</code>
		/// is empty
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E getLast()
		{
			java.util.LinkedList.Link<E> last = voidLink.previous;
			if (last != voidLink)
			{
				return last.data;
			}
			throw new java.util.NoSuchElementException();
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override int indexOf(object @object)
		{
			int pos = 0;
			java.util.LinkedList.Link<E> link = voidLink.next;
			if (@object != null)
			{
				while (link != voidLink)
				{
					if (@object.Equals(link.data))
					{
						return pos;
					}
					link = link.next;
					pos++;
				}
			}
			else
			{
				while (link != voidLink)
				{
					if ((object)link.data == null)
					{
						return pos;
					}
					link = link.next;
					pos++;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches this
		/// <code>LinkedList</code>
		/// for the specified object and returns the
		/// index of the last occurrence.
		/// </summary>
		/// <param name="object">the object to search for</param>
		/// <returns>
		/// the index of the last occurrence of the object, or -1 if it was
		/// not found.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override int lastIndexOf(object @object)
		{
			int pos = _size;
			java.util.LinkedList.Link<E> link = voidLink.previous;
			if (@object != null)
			{
				while (link != voidLink)
				{
					pos--;
					if (@object.Equals(link.data))
					{
						return pos;
					}
					link = link.previous;
				}
			}
			else
			{
				while (link != voidLink)
				{
					pos--;
					if ((object)link.data == null)
					{
						return pos;
					}
					link = link.previous;
				}
			}
			return -1;
		}

		/// <summary>
		/// Returns a ListIterator on the elements of this
		/// <code>LinkedList</code>
		/// . The
		/// elements are iterated in the same order that they occur in the
		/// <code>LinkedList</code>
		/// . The iteration starts at the specified location.
		/// </summary>
		/// <param name="location">the index at which to start the iteration</param>
		/// <returns>
		/// a ListIterator on the elements of this
		/// <code>LinkedList</code>
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		/// <seealso cref="ListIterator{E}">ListIterator&lt;E&gt;</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override java.util.ListIterator<E> listIterator(int location)
		{
			return new java.util.LinkedList.LinkIterator<E>(this, location);
		}

		/// <summary>
		/// Removes the object at the specified location from this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <param name="location">the index of the object to remove</param>
		/// <returns>the removed object</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E remove(int location)
		{
			if (location >= 0 && location < _size)
			{
				java.util.LinkedList.Link<E> link = voidLink;
				if (location < (_size / 2))
				{
					{
						for (int i = 0; i <= location; i++)
						{
							link = link.next;
						}
					}
				}
				else
				{
					{
						for (int i = _size; i > location; i--)
						{
							link = link.previous;
						}
					}
				}
				java.util.LinkedList.Link<E> previous = link.previous;
				java.util.LinkedList.Link<E> next = link.next;
				previous.next = next;
				next.previous = previous;
				_size--;
				modCount++;
				return link.data;
			}
			throw new System.IndexOutOfRangeException();
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool remove(object @object)
		{
			return removeFirstOccurrenceImpl(@object);
		}

		/// <summary>
		/// Removes the first object from this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <returns>the removed object.</returns>
		/// <exception cref="NoSuchElementException">
		/// if this
		/// <code>LinkedList</code>
		/// is empty.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E removeFirst()
		{
			return removeFirstImpl();
		}

		private E removeFirstImpl()
		{
			java.util.LinkedList.Link<E> first = voidLink.next;
			if (first != voidLink)
			{
				java.util.LinkedList.Link<E> next = first.next;
				voidLink.next = next;
				next.previous = voidLink;
				_size--;
				modCount++;
				return first.data;
			}
			throw new java.util.NoSuchElementException();
		}

		/// <summary>
		/// Removes the last object from this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <returns>the removed object.</returns>
		/// <exception cref="NoSuchElementException">
		/// if this
		/// <code>LinkedList</code>
		/// is empty.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E removeLast()
		{
			return removeLastImpl();
		}

		private E removeLastImpl()
		{
			java.util.LinkedList.Link<E> last = voidLink.previous;
			if (last != voidLink)
			{
				java.util.LinkedList.Link<E> previous = last.previous;
				voidLink.previous = previous;
				previous.next = voidLink;
				_size--;
				modCount++;
				return last.data;
			}
			throw new java.util.NoSuchElementException();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.descendingIterator()">Deque&lt;E&gt;.descendingIterator()
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual java.util.Iterator<E> descendingIterator()
		{
			return new java.util.LinkedList<E>.ReverseLinkIterator<E>(this, this);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.offerFirst(object)">Deque&lt;E&gt;.offerFirst(object)</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual bool offerFirst(E e)
		{
			return addFirstImpl(e);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.offerLast(object)">Deque&lt;E&gt;.offerLast(object)</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual bool offerLast(E e)
		{
			return addLastImpl(e);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.peekFirst()">Deque&lt;E&gt;.peekFirst()</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E peekFirst()
		{
			return peekFirstImpl();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.peekLast()">Deque&lt;E&gt;.peekLast()</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E peekLast()
		{
			java.util.LinkedList.Link<E> last = voidLink.previous;
			return (last == voidLink) ? default(E) : last.data;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.pollFirst()">Deque&lt;E&gt;.pollFirst()</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E pollFirst()
		{
			return (_size == 0) ? default(E) : removeFirstImpl();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.pollLast()">Deque&lt;E&gt;.pollLast()</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E pollLast()
		{
			return (_size == 0) ? default(E) : removeLastImpl();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.pop()">Deque&lt;E&gt;.pop()</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual E pop()
		{
			return removeFirstImpl();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.push(object)">Deque&lt;E&gt;.push(object)</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual void push(E e)
		{
			addFirstImpl(e);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.removeFirstOccurrence(object)">Deque&lt;E&gt;.removeFirstOccurrence(object)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual bool removeFirstOccurrence(object o)
		{
			return removeFirstOccurrenceImpl(o);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="Deque{E}.removeLastOccurrence(object)">Deque&lt;E&gt;.removeLastOccurrence(object)
		/// 	</seealso>
		/// <since>1.6</since>
		[Sharpen.ImplementsInterface(@"java.util.Deque")]
		public virtual bool removeLastOccurrence(object o)
		{
			java.util.Iterator<E> iter = new java.util.LinkedList<E>.ReverseLinkIterator<E>(this
				, this);
			return removeOneOccurrence(o, iter);
		}

		private bool removeFirstOccurrenceImpl(object o)
		{
			java.util.Iterator<E> iter = new java.util.LinkedList.LinkIterator<E>(this, 0);
			return removeOneOccurrence(o, iter);
		}

		private bool removeOneOccurrence(object o, java.util.Iterator<E> iter)
		{
			while (iter.hasNext())
			{
				E element_1 = iter.next();
				if (o == null ? (object)element_1 == null : o.Equals(element_1))
				{
					iter.remove();
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Replaces the element at the specified location in this
		/// <code>LinkedList</code>
		/// with the specified object.
		/// </summary>
		/// <param name="location">the index at which to put the specified object.</param>
		/// <param name="object">the object to add.</param>
		/// <returns>the previous element at the index.</returns>
		/// <exception cref="System.InvalidCastException">if the class of an object is inappropriate for this list.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">if an object cannot be added to this list.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E set(int location, E @object)
		{
			if (location >= 0 && location < _size)
			{
				java.util.LinkedList.Link<E> link = voidLink;
				if (location < (_size / 2))
				{
					{
						for (int i = 0; i <= location; i++)
						{
							link = link.next;
						}
					}
				}
				else
				{
					{
						for (int i = _size; i > location; i--)
						{
							link = link.previous;
						}
					}
				}
				E result = link.data;
				link.data = @object;
				return result;
			}
			throw new System.IndexOutOfRangeException();
		}

		/// <summary>
		/// Returns the number of elements in this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <returns>
		/// the number of elements in this
		/// <code>LinkedList</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override int size()
		{
			return _size;
		}

		[Sharpen.ImplementsInterface(@"java.util.Queue")]
		public virtual bool offer(E o)
		{
			return addLastImpl(o);
		}

		[Sharpen.ImplementsInterface(@"java.util.Queue")]
		public virtual E poll()
		{
			return _size == 0 ? default(E) : removeFirst();
		}

		[Sharpen.ImplementsInterface(@"java.util.Queue")]
		public virtual E remove()
		{
			return removeFirstImpl();
		}

		[Sharpen.ImplementsInterface(@"java.util.Queue")]
		public virtual E peek()
		{
			return peekFirstImpl();
		}

		private E peekFirstImpl()
		{
			java.util.LinkedList.Link<E> first = voidLink.next;
			return first == voidLink ? default(E) : first.data;
		}

		[Sharpen.ImplementsInterface(@"java.util.Queue")]
		public virtual E element()
		{
			return getFirstImpl();
		}

		/// <summary>
		/// Returns a new array containing all elements contained in this
		/// <code>LinkedList</code>
		/// .
		/// </summary>
		/// <returns>
		/// an array of the elements from this
		/// <code>LinkedList</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override object[] toArray()
		{
			int index = 0;
			object[] contents = new object[_size];
			java.util.LinkedList.Link<E> link = voidLink.next;
			while (link != voidLink)
			{
				contents[index++] = link.data;
				link = link.next;
			}
			return contents;
		}

		[Sharpen.Proxy]
		T[] java.util.Collection<E>.toArray<T>(T[] contents)
		{
			return toArray<T>(contents);
		}

		[Sharpen.Proxy]
		T[] java.util.List<E>.toArray<T>(T[] contents)
		{
			return toArray<T>(contents);
		}

		/// <summary>
		/// Returns an array containing all elements contained in this
		/// <code>LinkedList</code>
		/// . If the specified array is large enough to hold the
		/// elements, the specified array is used, otherwise an array of the same
		/// type is created. If the specified array is used and is larger than this
		/// <code>LinkedList</code>
		/// , the array element following the collection elements
		/// is set to null.
		/// </summary>
		/// <param name="contents">the array.</param>
		/// <returns>
		/// an array of the elements from this
		/// <code>LinkedList</code>
		/// .
		/// </returns>
		/// <exception cref="java.lang.ArrayStoreException">
		/// if the type of an element in this
		/// <code>LinkedList</code>
		/// cannot
		/// be stored in the type of the specified array.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override T[] toArray<T>(T[] contents)
		{
			int index = 0;
			if (_size > contents.Length)
			{
				System.Type ct = contents.GetType().GetElementType();
				contents = (T[])System.Array.CreateInstance(ct, _size);
			}
			java.util.LinkedList.Link<E> link = voidLink.next;
			while (link != voidLink)
			{
				contents[index++] = (T)(object)link.data;
				link = link.next;
			}
			if (index < contents.Length)
			{
				contents[index] = default(T);
			}
			return contents;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			stream.defaultWriteObject();
			stream.writeInt(_size);
			java.util.Iterator<E> it = iterator();
			while (it.hasNext())
			{
				stream.writeObject(it.next());
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream stream)
		{
			stream.defaultReadObject();
			_size = stream.readInt();
			voidLink = new java.util.LinkedList.Link<E>(default(E), null, null);
			java.util.LinkedList.Link<E> link = voidLink;
			{
				for (int i = _size; --i >= 0; )
				{
					java.util.LinkedList.Link<E> nextLink = new java.util.LinkedList.Link<E>((E)stream
						.readObject(), link, null);
					link.next = nextLink;
					link = nextLink;
				}
			}
			link.next = voidLink;
			voidLink.previous = link;
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
