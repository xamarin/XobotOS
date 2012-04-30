using Sharpen;

namespace java.util
{
	/// <summary>An iterator over a sequence of objects, such as a collection.</summary>
	/// <remarks>
	/// An iterator over a sequence of objects, such as a collection.
	/// <p>If a collection has been changed since the iterator was created,
	/// methods
	/// <code>next</code>
	/// and
	/// <code>hasNext()</code>
	/// may throw a
	/// <code>ConcurrentModificationException</code>
	/// .
	/// It is not possible to guarantee that this mechanism works in all cases of unsynchronized
	/// concurrent modification. It should only be used for debugging purposes. Iterators with this
	/// behavior are called fail-fast iterators.
	/// <p>Implementing
	/// <see cref="java.lang.Iterable{T}">java.lang.Iterable&lt;T&gt;</see>
	/// and returning an
	/// <code>Iterator</code>
	/// allows your
	/// class to be used as a collection with the enhanced for loop.
	/// </remarks>
	/// <?></?>
	[Sharpen.Sharpened]
	public interface Iterator<E>
	{
		/// <summary>Returns true if there is at least one more element, false otherwise.</summary>
		/// <remarks>Returns true if there is at least one more element, false otherwise.</remarks>
		/// <seealso cref="Iterator{E}.next()">Iterator&lt;E&gt;.next()</seealso>
		bool hasNext();

		/// <summary>Returns the next object and advances the iterator.</summary>
		/// <remarks>Returns the next object and advances the iterator.</remarks>
		/// <returns>the next object.</returns>
		/// <exception cref="NoSuchElementException">if there are no more elements.</exception>
		/// <seealso cref="Iterator{E}.hasNext()">Iterator&lt;E&gt;.hasNext()</seealso>
		E next();

		/// <summary>
		/// Removes the last object returned by
		/// <code>next</code>
		/// from the collection.
		/// This method can only be called once between each call to
		/// <code>next</code>
		/// .
		/// </summary>
		/// <exception cref="System.NotSupportedException">
		/// if removing is not supported by the collection being
		/// iterated.
		/// </exception>
		/// <exception cref="System.InvalidOperationException">
		/// if
		/// <code>next</code>
		/// has not been called, or
		/// <code>remove</code>
		/// has
		/// already been called after the last call to
		/// <code>next</code>
		/// .
		/// </exception>
		void remove();
	}
}
