using Sharpen;

namespace java.util
{
	/// <summary>SortedSet is a Set which iterates over its elements in a sorted order.</summary>
	/// <remarks>
	/// SortedSet is a Set which iterates over its elements in a sorted order. The
	/// order is determined either by the elements natural ordering, or by a
	/// <see cref="Comparator{T}">Comparator&lt;T&gt;</see>
	/// which is passed into a concrete implementation at
	/// construction time. All elements in this set must be mutually comparable. The
	/// ordering in this set must be consistent with
	/// <code>equals</code>
	/// of its elements.
	/// </remarks>
	/// <seealso cref="Comparator{T}">Comparator&lt;T&gt;</seealso>
	/// <seealso cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</seealso>
	[Sharpen.Sharpened]
	public interface SortedSet<E> : java.util.Set<E>
	{
		/// <summary>
		/// Returns the comparator used to compare elements in this
		/// <code>SortedSet</code>
		/// .
		/// </summary>
		/// <returns>a comparator or null if the natural ordering is used.</returns>
		java.util.Comparator<E> comparator();

		/// <summary>
		/// Returns the first element in this
		/// <code>SortedSet</code>
		/// . The first element
		/// is the lowest element.
		/// </summary>
		/// <returns>the first element.</returns>
		/// <exception cref="NoSuchElementException">
		/// when this
		/// <code>SortedSet</code>
		/// is empty.
		/// </exception>
		E first();

		/// <summary>
		/// Returns a
		/// <code>SortedSet</code>
		/// of the specified portion of this
		/// <code>SortedSet</code>
		/// which contains elements less than the end element. The
		/// returned
		/// <code>SortedSet</code>
		/// is backed by this
		/// <code>SortedSet</code>
		/// so changes
		/// to one set are reflected by the other.
		/// </summary>
		/// <param name="end">the end element.</param>
		/// <returns>
		/// a subset where the elements are less than
		/// <code>end</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// when the class of the end element is inappropriate for this
		/// SubSet.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// when the end element is null and this
		/// <code>SortedSet</code>
		/// does
		/// not support null elements.
		/// </exception>
		java.util.SortedSet<E> headSet(E end);

		/// <summary>
		/// Returns the last element in this
		/// <code>SortedSet</code>
		/// . The last element is
		/// the highest element.
		/// </summary>
		/// <returns>the last element.</returns>
		/// <exception cref="NoSuchElementException">
		/// when this
		/// <code>SortedSet</code>
		/// is empty.
		/// </exception>
		E last();

		/// <summary>
		/// Returns a
		/// <code>SortedSet</code>
		/// of the specified portion of this
		/// <code>SortedSet</code>
		/// which contains elements greater or equal to the start
		/// element but less than the end element. The returned
		/// <code>SortedSet</code>
		/// is
		/// backed by this SortedMap so changes to one set are reflected by the
		/// other.
		/// </summary>
		/// <param name="start">the start element.</param>
		/// <param name="end">the end element.</param>
		/// <returns>
		/// a subset where the elements are greater or equal to
		/// <code>start</code>
		/// and less than
		/// <code>end</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// when the class of the start or end element is inappropriate
		/// for this SubSet.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// when the start or end element is null and this
		/// <code>SortedSet</code>
		/// does not support null elements.
		/// </exception>
		/// <exception cref="System.ArgumentException">when the start element is greater than the end element.
		/// 	</exception>
		java.util.SortedSet<E> subSet(E start, E end);

		/// <summary>
		/// Returns a
		/// <code>SortedSet</code>
		/// of the specified portion of this
		/// <code>SortedSet</code>
		/// which contains elements greater or equal to the start
		/// element. The returned
		/// <code>SortedSet</code>
		/// is backed by this
		/// <code>SortedSet</code>
		/// so changes to one set are reflected by the other.
		/// </summary>
		/// <param name="start">the start element.</param>
		/// <returns>
		/// a subset where the elements are greater or equal to
		/// <code>start</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// when the class of the start element is inappropriate for this
		/// SubSet.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// when the start element is null and this
		/// <code>SortedSet</code>
		/// does not support null elements.
		/// </exception>
		java.util.SortedSet<E> tailSet(E start);
	}
}
