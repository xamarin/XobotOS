using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>List</code>
	/// is a collection which maintains an ordering for its elements. Every
	/// element in the
	/// <code>List</code>
	/// has an index. Each element can thus be accessed by its
	/// index, with the first index being zero. Normally,
	/// <code>List</code>
	/// s allow duplicate
	/// elements, as compared to Sets, where elements have to be unique.
	/// </summary>
	[Sharpen.Sharpened]
	public interface List<E> : java.util.Collection<E>
	{
		/// <summary>
		/// Inserts the specified object into this
		/// <code>List</code>
		/// at the specified location.
		/// The object is inserted before the current element at the specified
		/// location. If the location is equal to the size of this
		/// <code>List</code>
		/// , the object
		/// is added at the end. If the location is smaller than the size of this
		/// <code>List</code>
		/// , then all elements beyond the specified location are moved by one
		/// position towards the end of the
		/// <code>List</code>
		/// .
		/// </summary>
		/// <param name="location">the index at which to insert.</param>
		/// <param name="object">the object to add.</param>
		/// <exception cref="System.NotSupportedException">
		/// if adding to this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the object is inappropriate for this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if the object cannot be added to this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt; size()</code>
		/// </exception>
		void add(int location, E @object);

		/// <summary>
		/// Adds the specified object at the end of this
		/// <code>List</code>
		/// .
		/// </summary>
		/// <param name="object">the object to add.</param>
		/// <returns>always true.</returns>
		/// <exception cref="System.NotSupportedException">
		/// if adding to this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the object is inappropriate for this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if the object cannot be added to this
		/// <code>List</code>
		/// .
		/// </exception>
		bool add(E @object);

		/// <summary>
		/// Inserts the objects in the specified collection at the specified location
		/// in this
		/// <code>List</code>
		/// . The objects are added in the order they are returned from
		/// the collection's iterator.
		/// </summary>
		/// <param name="location">the index at which to insert.</param>
		/// <param name="collection">the collection of objects to be inserted.</param>
		/// <returns>
		/// true if this
		/// <code>List</code>
		/// has been modified through the insertion, false
		/// otherwise (i.e. if the passed collection was empty).
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if adding to this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of an object is inappropriate for this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if an object cannot be added to this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt; size()</code>
		/// </exception>
		bool addAll<_T0>(int location, java.util.Collection<_T0> collection) where _T0:E;

		/// <summary>
		/// Adds the objects in the specified collection to the end of this
		/// <code>List</code>
		/// . The
		/// objects are added in the order in which they are returned from the
		/// collection's iterator.
		/// </summary>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>List</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise
		/// (i.e. if the passed collection was empty).
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if adding to this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of an object is inappropriate for this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if an object cannot be added to this
		/// <code>List</code>
		/// .
		/// </exception>
		bool addAll<_T0>(java.util.Collection<_T0> collection) where _T0:E;

		/// <summary>
		/// Removes all elements from this
		/// <code>List</code>
		/// , leaving it empty.
		/// </summary>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		/// <seealso cref="List{E}.isEmpty()">List&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="List{E}.size()">List&lt;E&gt;.size()</seealso>
		void clear();

		/// <summary>
		/// Tests whether this
		/// <code>List</code>
		/// contains the specified object.
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if object is an element of this
		/// <code>List</code>
		/// ,
		/// <code>false</code>
		/// otherwise
		/// </returns>
		bool contains(object @object);

		/// <summary>
		/// Tests whether this
		/// <code>List</code>
		/// contains all objects contained in the
		/// specified collection.
		/// </summary>
		/// <param name="collection">the collection of objects</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if all objects in the specified collection are
		/// elements of this
		/// <code>List</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		bool containsAll<_T0>(java.util.Collection<_T0> collection);

		/// <summary>
		/// Compares the given object with the
		/// <code>List</code>
		/// , and returns true if they
		/// represent the <em>same</em> object using a class specific comparison. For
		/// <code>List</code>
		/// s, this means that they contain the same elements in exactly the same
		/// order.
		/// </summary>
		/// <param name="object">the object to compare with this object.</param>
		/// <returns>
		/// boolean
		/// <code>true</code>
		/// if the object is the same as this object,
		/// and
		/// <code>false</code>
		/// if it is different from this object.
		/// </returns>
		/// <seealso cref="List{E}.GetHashCode()">List&lt;E&gt;.GetHashCode()</seealso>
		bool Equals(object @object);

		/// <summary>
		/// Returns the element at the specified location in this
		/// <code>List</code>
		/// .
		/// </summary>
		/// <param name="location">the index of the element to return.</param>
		/// <returns>the element at the specified location.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		E get(int location);

		/// <summary>
		/// Returns the hash code for this
		/// <code>List</code>
		/// . It is calculated by taking each
		/// element' hashcode and its position in the
		/// <code>List</code>
		/// into account.
		/// </summary>
		/// <returns>
		/// the hash code of the
		/// <code>List</code>
		/// .
		/// </returns>
		int GetHashCode();

		/// <summary>
		/// Searches this
		/// <code>List</code>
		/// for the specified object and returns the index of the
		/// first occurrence.
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// the index of the first occurrence of the object or -1 if the
		/// object was not found.
		/// </returns>
		int indexOf(object @object);

		/// <summary>
		/// Returns whether this
		/// <code>List</code>
		/// contains no elements.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>List</code>
		/// has no elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="List{E}.size()">List&lt;E&gt;.size()</seealso>
		bool isEmpty();

		/// <summary>
		/// Returns an iterator on the elements of this
		/// <code>List</code>
		/// . The elements are
		/// iterated in the same order as they occur in the
		/// <code>List</code>
		/// .
		/// </summary>
		/// <returns>
		/// an iterator on the elements of this
		/// <code>List</code>
		/// .
		/// </returns>
		/// <seealso cref="Iterator{E}">Iterator&lt;E&gt;</seealso>
		java.util.Iterator<E> iterator();

		/// <summary>
		/// Searches this
		/// <code>List</code>
		/// for the specified object and returns the index of the
		/// last occurrence.
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// the index of the last occurrence of the object, or -1 if the
		/// object was not found.
		/// </returns>
		int lastIndexOf(object @object);

		/// <summary>
		/// Returns a
		/// <code>List</code>
		/// iterator on the elements of this
		/// <code>List</code>
		/// . The elements are
		/// iterated in the same order that they occur in the
		/// <code>List</code>
		/// .
		/// </summary>
		/// <returns>
		/// a
		/// <code>List</code>
		/// iterator on the elements of this
		/// <code>List</code>
		/// </returns>
		/// <seealso cref="ListIterator{E}">ListIterator&lt;E&gt;</seealso>
		java.util.ListIterator<E> listIterator();

		/// <summary>
		/// Returns a list iterator on the elements of this
		/// <code>List</code>
		/// . The elements are
		/// iterated in the same order as they occur in the
		/// <code>List</code>
		/// . The iteration
		/// starts at the specified location.
		/// </summary>
		/// <param name="location">the index at which to start the iteration.</param>
		/// <returns>
		/// a list iterator on the elements of this
		/// <code>List</code>
		/// .
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt; size()</code>
		/// </exception>
		/// <seealso cref="ListIterator{E}">ListIterator&lt;E&gt;</seealso>
		java.util.ListIterator<E> listIterator(int location);

		/// <summary>
		/// Removes the object at the specified location from this
		/// <code>List</code>
		/// .
		/// </summary>
		/// <param name="location">the index of the object to remove.</param>
		/// <returns>the removed object.</returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		E remove(int location);

		/// <summary>
		/// Removes the first occurrence of the specified object from this
		/// <code>List</code>
		/// .
		/// </summary>
		/// <param name="object">the object to remove.</param>
		/// <returns>
		/// true if this
		/// <code>List</code>
		/// was modified by this operation, false
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		bool remove(object @object);

		/// <summary>
		/// Removes all occurrences in this
		/// <code>List</code>
		/// of each object in the specified
		/// collection.
		/// </summary>
		/// <param name="collection">the collection of objects to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>List</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		bool removeAll<_T0>(java.util.Collection<_T0> collection);

		/// <summary>
		/// Removes all objects from this
		/// <code>List</code>
		/// that are not contained in the
		/// specified collection.
		/// </summary>
		/// <param name="collection">the collection of objects to retain.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>List</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		bool retainAll<_T0>(java.util.Collection<_T0> collection);

		/// <summary>
		/// Replaces the element at the specified location in this
		/// <code>List</code>
		/// with the
		/// specified object. This operation does not change the size of the
		/// <code>List</code>
		/// .
		/// </summary>
		/// <param name="location">the index at which to put the specified object.</param>
		/// <param name="object">the object to insert.</param>
		/// <returns>the previous element at the index.</returns>
		/// <exception cref="System.NotSupportedException">
		/// if replacing elements in this
		/// <code>List</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of an object is inappropriate for this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if an object cannot be added to this
		/// <code>List</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		E set(int location, E @object);

		/// <summary>
		/// Returns the number of elements in this
		/// <code>List</code>
		/// .
		/// </summary>
		/// <returns>
		/// the number of elements in this
		/// <code>List</code>
		/// .
		/// </returns>
		int size();

		/// <summary>
		/// Returns a
		/// <code>List</code>
		/// of the specified portion of this
		/// <code>List</code>
		/// from the given start
		/// index to the end index minus one. The returned
		/// <code>List</code>
		/// is backed by this
		/// <code>List</code>
		/// so changes to it are reflected by the other.
		/// </summary>
		/// <param name="start">the index at which to start the sublist.</param>
		/// <param name="end">the index one past the end of the sublist.</param>
		/// <returns>
		/// a list of a portion of this
		/// <code>List</code>
		/// .
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0, start &gt; end</code>
		/// or
		/// <code>
		/// end &gt;
		/// size()
		/// </code>
		/// </exception>
		java.util.List<E> subList(int start, int end);

		/// <summary>
		/// Returns an array containing all elements contained in this
		/// <code>List</code>
		/// .
		/// </summary>
		/// <returns>
		/// an array of the elements from this
		/// <code>List</code>
		/// .
		/// </returns>
		object[] toArray();

		/// <summary>
		/// Returns an array containing all elements contained in this
		/// <code>List</code>
		/// . If the
		/// specified array is large enough to hold the elements, the specified array
		/// is used, otherwise an array of the same type is created. If the specified
		/// array is used and is larger than this
		/// <code>List</code>
		/// , the array element following
		/// the collection elements is set to null.
		/// </summary>
		/// <param name="array">the array.</param>
		/// <returns>
		/// an array of the elements from this
		/// <code>List</code>
		/// .
		/// </returns>
		/// <exception cref="java.lang.ArrayStoreException">
		/// if the type of an element in this
		/// <code>List</code>
		/// cannot be stored
		/// in the type of the specified array.
		/// </exception>
		T[] toArray<T>(T[] array);
	}
}
