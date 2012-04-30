using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>Set</code>
	/// is a data structure which does not allow duplicate elements.
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public interface Set<E> : java.util.Collection<E>
	{
		/// <summary>Adds the specified object to this set.</summary>
		/// <remarks>
		/// Adds the specified object to this set. The set is not modified if it
		/// already contains the object.
		/// </remarks>
		/// <param name="object">the object to add.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this set is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">when adding to this set is not supported.
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">when the class of the object is inappropriate for this set.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">when the object cannot be added to this set.
		/// 	</exception>
		bool add(E @object);

		/// <summary>
		/// Adds the objects in the specified collection which do not exist yet in
		/// this set.
		/// </summary>
		/// <remarks>
		/// Adds the objects in the specified collection which do not exist yet in
		/// this set.
		/// </remarks>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this set is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">when adding to this set is not supported.
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">when the class of an object is inappropriate for this set.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">when an object cannot be added to this set.
		/// 	</exception>
		bool addAll<_T0>(java.util.Collection<_T0> collection) where _T0:E;

		/// <summary>Removes all elements from this set, leaving it empty.</summary>
		/// <remarks>Removes all elements from this set, leaving it empty.</remarks>
		/// <exception cref="System.NotSupportedException">when removing from this set is not supported.
		/// 	</exception>
		/// <seealso cref="Set{E}.isEmpty()">Set&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="Set{E}.size()">Set&lt;E&gt;.size()</seealso>
		void clear();

		/// <summary>Searches this set for the specified object.</summary>
		/// <remarks>Searches this set for the specified object.</remarks>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if object is an element of this set,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		bool contains(object @object);

		/// <summary>Searches this set for all objects in the specified collection.</summary>
		/// <remarks>Searches this set for all objects in the specified collection.</remarks>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if all objects in the specified collection are
		/// elements of this set,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		bool containsAll<_T0>(java.util.Collection<_T0> collection);

		/// <summary>
		/// Compares the specified object to this set, and returns true if they
		/// represent the <em>same</em> object using a class specific comparison.
		/// </summary>
		/// <remarks>
		/// Compares the specified object to this set, and returns true if they
		/// represent the <em>same</em> object using a class specific comparison.
		/// Equality for a set means that both sets have the same size and the same
		/// elements.
		/// </remarks>
		/// <param name="object">the object to compare with this object.</param>
		/// <returns>
		/// boolean
		/// <code>true</code>
		/// if the object is the same as this object,
		/// and
		/// <code>false</code>
		/// if it is different from this object.
		/// </returns>
		/// <seealso cref="Set{E}.GetHashCode()">Set&lt;E&gt;.GetHashCode()</seealso>
		bool Equals(object @object);

		/// <summary>Returns the hash code for this set.</summary>
		/// <remarks>
		/// Returns the hash code for this set. Two set which are equal must return
		/// the same value.
		/// </remarks>
		/// <returns>the hash code of this set.</returns>
		/// <seealso cref="Set{E}.Equals(object)">Set&lt;E&gt;.Equals(object)</seealso>
		int GetHashCode();

		/// <summary>Returns true if this set has no elements.</summary>
		/// <remarks>Returns true if this set has no elements.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this set has no elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Set{E}.size()">Set&lt;E&gt;.size()</seealso>
		bool isEmpty();

		/// <summary>Returns an iterator on the elements of this set.</summary>
		/// <remarks>
		/// Returns an iterator on the elements of this set. The elements are
		/// unordered.
		/// </remarks>
		/// <returns>an iterator on the elements of this set.</returns>
		/// <seealso cref="Iterator{E}">Iterator&lt;E&gt;</seealso>
		java.util.Iterator<E> iterator();

		/// <summary>Removes the specified object from this set.</summary>
		/// <remarks>Removes the specified object from this set.</remarks>
		/// <param name="object">the object to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this set was modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">when removing from this set is not supported.
		/// 	</exception>
		bool remove(object @object);

		/// <summary>Removes all objects in the specified collection from this set.</summary>
		/// <remarks>Removes all objects in the specified collection from this set.</remarks>
		/// <param name="collection">the collection of objects to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this set was modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">when removing from this set is not supported.
		/// 	</exception>
		bool removeAll<_T0>(java.util.Collection<_T0> collection);

		/// <summary>
		/// Removes all objects from this set that are not contained in the specified
		/// collection.
		/// </summary>
		/// <remarks>
		/// Removes all objects from this set that are not contained in the specified
		/// collection.
		/// </remarks>
		/// <param name="collection">the collection of objects to retain.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this set was modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">when removing from this set is not supported.
		/// 	</exception>
		bool retainAll<_T0>(java.util.Collection<_T0> collection);

		/// <summary>Returns the number of elements in this set.</summary>
		/// <remarks>Returns the number of elements in this set.</remarks>
		/// <returns>the number of elements in this set.</returns>
		int size();

		/// <summary>Returns an array containing all elements contained in this set.</summary>
		/// <remarks>Returns an array containing all elements contained in this set.</remarks>
		/// <returns>an array of the elements from this set.</returns>
		object[] toArray();

		/// <summary>Returns an array containing all elements contained in this set.</summary>
		/// <remarks>
		/// Returns an array containing all elements contained in this set. If the
		/// specified array is large enough to hold the elements, the specified array
		/// is used, otherwise an array of the same type is created. If the specified
		/// array is used and is larger than this set, the array element following
		/// the collection elements is set to null.
		/// </remarks>
		/// <param name="array">the array.</param>
		/// <returns>an array of the elements from this set.</returns>
		/// <exception cref="java.lang.ArrayStoreException">
		/// when the type of an element in this set cannot be stored in
		/// the type of the specified array.
		/// </exception>
		/// <seealso cref="Collection{E}.toArray{T}(object[])">Collection&lt;E&gt;.toArray&lt;T&gt;(object[])
		/// 	</seealso>
		T[] toArray<T>(T[] array);
	}
}
