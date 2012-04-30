using Sharpen;

namespace java.util
{
	/// <summary>An ListIterator is used to sequence over a List of objects.</summary>
	/// <remarks>
	/// An ListIterator is used to sequence over a List of objects. ListIterator can
	/// move backwards or forwards through the list.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface ListIterator<E> : java.util.Iterator<E>
	{
		/// <summary>
		/// Inserts the specified object into the list between
		/// <code>next</code>
		/// and
		/// <code>previous</code>
		/// . The object inserted will be the previous object.
		/// </summary>
		/// <param name="object">the object to insert.</param>
		/// <exception cref="System.NotSupportedException">if adding is not supported by the list being iterated.
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">if the class of the object is inappropriate for the list.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">if the object cannot be added to the list.
		/// 	</exception>
		void add(E @object);

		/// <summary>Returns whether there are more elements to iterate.</summary>
		/// <remarks>Returns whether there are more elements to iterate.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if there are more elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="ListIterator{E}.next()">ListIterator&lt;E&gt;.next()</seealso>
		bool hasNext();

		/// <summary>Returns whether there are previous elements to iterate.</summary>
		/// <remarks>Returns whether there are previous elements to iterate.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if there are previous elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="ListIterator{E}.previous()">ListIterator&lt;E&gt;.previous()</seealso>
		bool hasPrevious();

		/// <summary>Returns the next object in the iteration.</summary>
		/// <remarks>Returns the next object in the iteration.</remarks>
		/// <returns>the next object.</returns>
		/// <exception cref="NoSuchElementException">if there are no more elements.</exception>
		/// <seealso cref="ListIterator{E}.hasNext()">ListIterator&lt;E&gt;.hasNext()</seealso>
		E next();

		/// <summary>Returns the index of the next object in the iteration.</summary>
		/// <remarks>Returns the index of the next object in the iteration.</remarks>
		/// <returns>
		/// the index of the next object, or the size of the list if the
		/// iterator is at the end.
		/// </returns>
		/// <exception cref="NoSuchElementException">if there are no more elements.</exception>
		/// <seealso cref="ListIterator{E}.next()">ListIterator&lt;E&gt;.next()</seealso>
		int nextIndex();

		/// <summary>Returns the previous object in the iteration.</summary>
		/// <remarks>Returns the previous object in the iteration.</remarks>
		/// <returns>the previous object.</returns>
		/// <exception cref="NoSuchElementException">if there are no previous elements.</exception>
		/// <seealso cref="ListIterator{E}.hasPrevious()">ListIterator&lt;E&gt;.hasPrevious()
		/// 	</seealso>
		E previous();

		/// <summary>Returns the index of the previous object in the iteration.</summary>
		/// <remarks>Returns the index of the previous object in the iteration.</remarks>
		/// <returns>
		/// the index of the previous object, or -1 if the iterator is at the
		/// beginning.
		/// </returns>
		/// <exception cref="NoSuchElementException">if there are no previous elements.</exception>
		/// <seealso cref="ListIterator{E}.previous()">ListIterator&lt;E&gt;.previous()</seealso>
		int previousIndex();

		/// <summary>
		/// Removes the last object returned by
		/// <code>next</code>
		/// or
		/// <code>previous</code>
		/// from
		/// the list.
		/// </summary>
		/// <exception cref="System.NotSupportedException">if removing is not supported by the list being iterated.
		/// 	</exception>
		/// <exception cref="System.InvalidOperationException">
		/// if
		/// <code>next</code>
		/// or
		/// <code>previous</code>
		/// have not been called, or
		/// <code>remove</code>
		/// or
		/// <code>add</code>
		/// have already been called after
		/// the last call to
		/// <code>next</code>
		/// or
		/// <code>previous</code>
		/// .
		/// </exception>
		void remove();

		/// <summary>
		/// Replaces the last object returned by
		/// <code>next</code>
		/// or
		/// <code>previous</code>
		/// with the specified object.
		/// </summary>
		/// <param name="object">the object to set.</param>
		/// <exception cref="System.NotSupportedException">if setting is not supported by the list being iterated
		/// 	</exception>
		/// <exception cref="System.InvalidCastException">if the class of the object is inappropriate for the list.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">if the object cannot be added to the list.
		/// 	</exception>
		/// <exception cref="System.InvalidOperationException">
		/// if
		/// <code>next</code>
		/// or
		/// <code>previous</code>
		/// have not been called, or
		/// <code>remove</code>
		/// or
		/// <code>add</code>
		/// have already been called after
		/// the last call to
		/// <code>next</code>
		/// or
		/// <code>previous</code>
		/// .
		/// </exception>
		void set(E @object);
	}
}
