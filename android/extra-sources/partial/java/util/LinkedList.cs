namespace java.util
{
	partial class LinkedList<E>
	{
		/// <summary>
		/// Inserts the objects in the specified collection at the specified location
		/// in this
		/// <code>LinkedList</code>
		/// . The objects are added in the order they are
		/// returned from the collection's iterator.
		/// </summary>
		/// <param name="location">the index at which to insert.</param>
		/// <param name="collection">the collection of objects</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>LinkedList</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.InvalidCastException">if the class of an object is inappropriate for this list.
		/// 	</exception>
		/// <exception cref="System.ArgumentException">if an object cannot be added to this list.
		/// 	</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || &gt; size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override bool addAll<_T0> (int location, Collection<_T0> collection)
		{
			if (location < 0 || location > _size) {
				throw new System.IndexOutOfRangeException ();
			}
			int adding = collection.size ();
			if (adding == 0) {
				return false;
			}
			Collection<_T0> elements = (collection == this) ? new ArrayList<_T0> (collection)
				: (java.util.Collection<_T0>)collection;
			java.util.LinkedList.Link<E> previous = voidLink;
			if (location < (_size / 2)) {
				{
					for (int i = 0; i < location; i++) {
						previous = previous.next;
					}
				}
			} else {
				{
					for (int i = _size; i >= location; i--) {
						previous = previous.previous;
					}
				}
			}
			LinkedList.Link<E> next = previous.next;
			foreach (E e in Sharpen.IterableProxy.Create(elements)) {
				LinkedList.Link<E> newLink = new LinkedList.Link<E> (e, previous, null);
				previous.next = newLink;
				previous = newLink;
			}
			previous.next = next;
			next.previous = previous;
			_size += adding;
			modCount++;
			return true;
		}
	}
}

