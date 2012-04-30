using Sharpen;

namespace java.util
{
	/// <summary>
	/// Class
	/// <code>AbstractCollection</code>
	/// is an abstract implementation of the
	/// <code>Collection</code>
	/// interface. A subclass must implement the abstract methods
	/// <code>iterator()</code>
	/// and
	/// <code>size()</code>
	/// to create an immutable collection. To create a
	/// modifiable collection it's necessary to override the
	/// <code>add()</code>
	/// method that
	/// currently throws an
	/// <code>UnsupportedOperationException</code>
	/// .
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public abstract class AbstractCollection<E> : java.util.Collection<E>
	{
		/// <summary>Constructs a new instance of this AbstractCollection.</summary>
		/// <remarks>Constructs a new instance of this AbstractCollection.</remarks>
		protected internal AbstractCollection()
		{
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool add(E @object)
		{
			throw new System.NotSupportedException();
		}

		/// <summary>
		/// Attempts to add all of the objects contained in
		/// <code>collection</code>
		/// to the contents of this
		/// <code>Collection</code>
		/// (optional). This implementation
		/// iterates over the given
		/// <code>Collection</code>
		/// and calls
		/// <code>add</code>
		/// for each
		/// element. If any of these calls return
		/// <code>true</code>
		/// , then
		/// <code>true</code>
		/// is
		/// returned as result of this method call,
		/// <code>false</code>
		/// otherwise. If this
		/// <code>Collection</code>
		/// does not support adding elements, an
		/// <code>UnsupportedOperationException</code>
		/// is thrown.
		/// <p>
		/// If the passed
		/// <code>Collection</code>
		/// is changed during the process of adding elements
		/// to this
		/// <code>Collection</code>
		/// , the behavior depends on the behavior of the passed
		/// <code>Collection</code>
		/// .
		/// </summary>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>Collection</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if adding to this
		/// <code>Collection</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of an object is inappropriate for this
		/// <code>Collection</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if an object cannot be added to this
		/// <code>Collection</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>collection</code>
		/// is
		/// <code>null</code>
		/// , or if it contains
		/// <code>null</code>
		/// elements and this
		/// <code>Collection</code>
		/// does not support
		/// such elements.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool addAll<_T0>(java.util.Collection<_T0> collection) where _T0:E
		{
			bool result = false;
			java.util.Iterator<_T0> it = collection.iterator();
			while (it.hasNext())
			{
				if (add(it.next()))
				{
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		/// Removes all elements from this
		/// <code>Collection</code>
		/// , leaving it empty (optional).
		/// This implementation iterates over this
		/// <code>Collection</code>
		/// and calls the
		/// <code>remove</code>
		/// method on each element. If the iterator does not support removal
		/// of elements, an
		/// <code>UnsupportedOperationException</code>
		/// is thrown.
		/// <p>
		/// Concrete implementations usually can clear a
		/// <code>Collection</code>
		/// more efficiently
		/// and should therefore overwrite this method.
		/// </summary>
		/// <exception cref="System.NotSupportedException">
		/// it the iterator does not support removing elements from
		/// this
		/// <code>Collection</code>
		/// </exception>
		/// <seealso cref="AbstractCollection{E}.iterator()">AbstractCollection&lt;E&gt;.iterator()
		/// 	</seealso>
		/// <seealso cref="AbstractCollection{E}.isEmpty()">AbstractCollection&lt;E&gt;.isEmpty()
		/// 	</seealso>
		/// <seealso cref="AbstractCollection{E}.size()">AbstractCollection&lt;E&gt;.size()</seealso>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual void clear()
		{
			java.util.Iterator<E> it = iterator();
			while (it.hasNext())
			{
				it.next();
				it.remove();
			}
		}

		/// <summary>
		/// Tests whether this
		/// <code>Collection</code>
		/// contains the specified object. This
		/// implementation iterates over this
		/// <code>Collection</code>
		/// and tests, whether any
		/// element is equal to the given object. If
		/// <code>object != null</code>
		/// then
		/// <code>object.equals(e)</code>
		/// is called for each element
		/// <code>e</code>
		/// returned by
		/// the iterator until the element is found. If
		/// <code>object == null</code>
		/// then
		/// each element
		/// <code>e</code>
		/// returned by the iterator is compared with the test
		/// <code>e == null</code>
		/// .
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if object is an element of this
		/// <code>Collection</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.InvalidCastException">if the object to look for isn't of the correct type.
		/// 	</exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the object to look for is
		/// <code>null</code>
		/// and this
		/// <code>Collection</code>
		/// doesn't support
		/// <code>null</code>
		/// elements.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool contains(object @object)
		{
			java.util.Iterator<E> it = iterator();
			if (@object != null)
			{
				while (it.hasNext())
				{
					if (@object.Equals(it.next()))
					{
						return true;
					}
				}
			}
			else
			{
				while (it.hasNext())
				{
					if ((object)it.next() == null)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Tests whether this
		/// <code>Collection</code>
		/// contains all objects contained in the
		/// specified
		/// <code>Collection</code>
		/// . This implementation iterates over the specified
		/// <code>Collection</code>
		/// . If one element returned by the iterator is not contained in
		/// this
		/// <code>Collection</code>
		/// , then
		/// <code>false</code>
		/// is returned;
		/// <code>true</code>
		/// otherwise.
		/// </summary>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if all objects in the specified
		/// <code>Collection</code>
		/// are
		/// elements of this
		/// <code>Collection</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if one or more elements of
		/// <code>collection</code>
		/// isn't of the
		/// correct type.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>collection</code>
		/// contains at least one
		/// <code>null</code>
		/// element and this
		/// <code>Collection</code>
		/// doesn't support
		/// <code>null</code>
		/// elements.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>collection</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool containsAll<_T0>(java.util.Collection<_T0> collection)
		{
			java.util.Iterator<_T0> it = collection.iterator();
			while (it.hasNext())
			{
				if (!contains(it.next()))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Returns if this
		/// <code>Collection</code>
		/// contains no elements. This implementation
		/// tests, whether
		/// <code>size</code>
		/// returns 0.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>Collection</code>
		/// has no elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="AbstractCollection{E}.size()">AbstractCollection&lt;E&gt;.size()</seealso>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool isEmpty()
		{
			return size() == 0;
		}

		/// <summary>
		/// Returns an instance of
		/// <see cref="Iterator{E}">Iterator&lt;E&gt;</see>
		/// that may be used to access the
		/// objects contained by this
		/// <code>Collection</code>
		/// . The order in which the elements are
		/// returned by the
		/// <see cref="Iterator{E}">Iterator&lt;E&gt;</see>
		/// is not defined unless the instance of the
		/// <code>Collection</code>
		/// has a defined order.  In that case, the elements are returned in that order.
		/// <p>
		/// In this class this method is declared abstract and has to be implemented
		/// by concrete
		/// <code>Collection</code>
		/// implementations.
		/// </summary>
		/// <returns>
		/// an iterator for accessing the
		/// <code>Collection</code>
		/// contents.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.lang.Iterable")]
		public abstract java.util.Iterator<E> iterator();

		/// <summary>
		/// Removes one instance of the specified object from this
		/// <code>Collection</code>
		/// if one
		/// is contained (optional). This implementation iterates over this
		/// <code>Collection</code>
		/// and tests for each element
		/// <code>e</code>
		/// returned by the iterator,
		/// whether
		/// <code>e</code>
		/// is equal to the given object. If
		/// <code>object != null</code>
		/// then this test is performed using
		/// <code>object.equals(e)</code>
		/// , otherwise
		/// using
		/// <code>object == null</code>
		/// . If an element equal to the given object is
		/// found, then the
		/// <code>remove</code>
		/// method is called on the iterator and
		/// <code>true</code>
		/// is returned,
		/// <code>false</code>
		/// otherwise. If the iterator does
		/// not support removing elements, an
		/// <code>UnsupportedOperationException</code>
		/// is thrown.
		/// </summary>
		/// <param name="object">the object to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>Collection</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>Collection</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">if the object passed is not of the correct type.
		/// 	</exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>object</code>
		/// is
		/// <code>null</code>
		/// and this
		/// <code>Collection</code>
		/// doesn't support
		/// <code>null</code>
		/// elements.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool remove(object @object)
		{
			java.util.Iterator<E> it = iterator();
			if (@object != null)
			{
				while (it.hasNext())
				{
					if (@object.Equals(it.next()))
					{
						it.remove();
						return true;
					}
				}
			}
			else
			{
				while (it.hasNext())
				{
					if (it.next() == null)
					{
						it.remove();
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Removes all occurrences in this
		/// <code>Collection</code>
		/// of each object in the
		/// specified
		/// <code>Collection</code>
		/// (optional). After this method returns none of the
		/// elements in the passed
		/// <code>Collection</code>
		/// can be found in this
		/// <code>Collection</code>
		/// anymore.
		/// <p>
		/// This implementation iterates over this
		/// <code>Collection</code>
		/// and tests for each
		/// element
		/// <code>e</code>
		/// returned by the iterator, whether it is contained in
		/// the specified
		/// <code>Collection</code>
		/// . If this test is positive, then the
		/// <code>remove</code>
		/// method is called on the iterator. If the iterator does not
		/// support removing elements, an
		/// <code>UnsupportedOperationException</code>
		/// is
		/// thrown.
		/// </summary>
		/// <param name="collection">the collection of objects to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>Collection</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>Collection</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if one or more elements of
		/// <code>collection</code>
		/// isn't of the
		/// correct type.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>collection</code>
		/// contains at least one
		/// <code>null</code>
		/// element and this
		/// <code>Collection</code>
		/// doesn't support
		/// <code>null</code>
		/// elements.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>collection</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool removeAll<_T0>(java.util.Collection<_T0> collection)
		{
			bool result = false;
			java.util.Iterator<E> it = iterator();
			while (it.hasNext())
			{
				if (collection.contains(it.next()))
				{
					it.remove();
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		/// Removes all objects from this
		/// <code>Collection</code>
		/// that are not also found in the
		/// <code>Collection</code>
		/// passed (optional). After this method returns this
		/// <code>Collection</code>
		/// will only contain elements that also can be found in the
		/// <code>Collection</code>
		/// passed to this method.
		/// <p>
		/// This implementation iterates over this
		/// <code>Collection</code>
		/// and tests for each
		/// element
		/// <code>e</code>
		/// returned by the iterator, whether it is contained in
		/// the specified
		/// <code>Collection</code>
		/// . If this test is negative, then the
		/// <code>remove</code>
		/// method is called on the iterator. If the iterator does not
		/// support removing elements, an
		/// <code>UnsupportedOperationException</code>
		/// is
		/// thrown.
		/// </summary>
		/// <param name="collection">the collection of objects to retain.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>Collection</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>Collection</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if one or more elements of
		/// <code>collection</code>
		/// isn't of the correct type.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>collection</code>
		/// contains at least one
		/// <code>null</code>
		/// element and this
		/// <code>Collection</code>
		/// doesn't support
		/// <code>null</code>
		/// elements.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>collection</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual bool retainAll<_T0>(java.util.Collection<_T0> collection)
		{
			bool result = false;
			java.util.Iterator<E> it = iterator();
			while (it.hasNext())
			{
				if (!collection.contains(it.next()))
				{
					it.remove();
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		/// Returns a count of how many objects this
		/// <code>Collection</code>
		/// contains.
		/// <p>
		/// In this class this method is declared abstract and has to be implemented
		/// by concrete
		/// <code>Collection</code>
		/// implementations.
		/// </summary>
		/// <returns>
		/// how many objects this
		/// <code>Collection</code>
		/// contains, or
		/// <code>Integer.MAX_VALUE</code>
		/// if there are more than
		/// <code>Integer.MAX_VALUE</code>
		/// elements in this
		/// <code>Collection</code>
		/// .
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public abstract int size();

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual object[] toArray()
		{
			int size_1 = size();
			int index = 0;
			java.util.Iterator<E> it = iterator();
			object[] array = new object[size_1];
			while (index < size_1)
			{
				array[index++] = it.next();
			}
			return array;
		}

		[Sharpen.Proxy]
		T[] java.util.Collection<E>.toArray<T>(T[] contents)
		{
			return toArray<T>(contents);
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual T[] toArray<T>(T[] contents)
		{
			int size_1 = size();
			int index = 0;
			if (size_1 > contents.Length)
			{
				System.Type ct = contents.GetType().GetElementType();
				contents = (T[])System.Array.CreateInstance(ct, size_1);
			}
			foreach (E entry in Sharpen.IterableProxy.Create(this))
			{
				contents[index++] = (T)(object)entry;
			}
			if (index < contents.Length)
			{
				contents[index] = default(T);
			}
			return contents;
		}

		/// <summary>
		/// Returns the string representation of this
		/// <code>Collection</code>
		/// . The presentation
		/// has a specific format. It is enclosed by square brackets ("[]"). Elements
		/// are separated by ', ' (comma and space).
		/// </summary>
		/// <returns>
		/// the string representation of this
		/// <code>Collection</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			if (isEmpty())
			{
				return "[]";
			}
			java.lang.StringBuilder buffer = new java.lang.StringBuilder(size() * 16);
			buffer.append('[');
			java.util.Iterator<E> it = iterator();
			while (it.hasNext())
			{
				object next = it.next();
				if (next != this)
				{
					buffer.append(next);
				}
				else
				{
					buffer.append("(this Collection)");
				}
				if (it.hasNext())
				{
					buffer.append(", ");
				}
			}
			buffer.append(']');
			return buffer.ToString();
		}
	}
}
