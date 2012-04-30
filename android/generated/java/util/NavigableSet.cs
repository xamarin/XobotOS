using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <see cref="SortedSet{E}">SortedSet&lt;E&gt;</see>
	/// extended with navigation methods reporting
	/// closest matches for given search targets. Methods
	/// <code>lower</code>
	/// ,
	/// <code>floor</code>
	/// ,
	/// <code>ceiling</code>
	/// , and
	/// <code>higher</code>
	/// return elements
	/// respectively less than, less than or equal, greater than or equal,
	/// and greater than a given element, returning
	/// <code>null</code>
	/// if there
	/// is no such element.  A
	/// <code>NavigableSet</code>
	/// may be accessed and
	/// traversed in either ascending or descending order.  The
	/// <code>descendingSet</code>
	/// method returns a view of the set with the senses of
	/// all relational and directional methods inverted. The performance of
	/// ascending operations and views is likely to be faster than that of
	/// descending ones.  This interface additionally defines methods
	/// <code>pollFirst</code>
	/// and
	/// <code>pollLast</code>
	/// that return and remove the
	/// lowest and highest element, if one exists, else returning
	/// <code>null</code>
	/// .  Methods
	/// <code>subSet</code>
	/// ,
	/// <code>headSet</code>
	/// ,
	/// and
	/// <code>tailSet</code>
	/// differ from the like-named
	/// <code>SortedSet</code>
	/// methods in accepting additional arguments describing
	/// whether lower and upper bounds are inclusive versus exclusive.
	/// Subsets of any
	/// <code>NavigableSet</code>
	/// must implement the
	/// <code>NavigableSet</code>
	/// interface.
	/// <p> The return values of navigation methods may be ambiguous in
	/// implementations that permit
	/// <code>null</code>
	/// elements. However, even
	/// in this case the result can be disambiguated by checking
	/// <code>contains(null)</code>
	/// . To avoid such issues, implementations of
	/// this interface are encouraged to <em>not</em> permit insertion of
	/// <code>null</code>
	/// elements. (Note that sorted sets of
	/// <see cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</see>
	/// elements intrinsically do not permit
	/// <code>null</code>
	/// .)
	/// <p>Methods
	/// <see cref="NavigableSet{E}.subSet(object, object)">subSet(E, E)</see>
	/// ,
	/// <see cref="NavigableSet{E}.headSet(object)">headSet(E)</see>
	/// , and
	/// <see cref="NavigableSet{E}.tailSet(object)">tailSet(E)</see>
	/// are specified to return
	/// <code>SortedSet</code>
	/// to allow existing
	/// implementations of
	/// <code>SortedSet</code>
	/// to be compatibly retrofitted to
	/// implement
	/// <code>NavigableSet</code>
	/// , but extensions and implementations
	/// of this interface are encouraged to override these methods to return
	/// <code>NavigableSet</code>
	/// .
	/// </summary>
	/// <author>Doug Lea</author>
	/// <author>Josh Bloch</author>
	/// <?></?>
	/// <since>1.6</since>
	[Sharpen.Sharpened]
	public interface NavigableSet<E> : java.util.SortedSet<E>
	{
		// BEGIN android-note
		// removed link to collections framework docs
		// changed {@link #subSet(Object)} to {@link #subSet} to satisfy DroidDoc
		// END android-note
		/// <summary>
		/// Returns the greatest element in this set strictly less than the
		/// given element, or
		/// <code>null</code>
		/// if there is no such element.
		/// </summary>
		/// <param name="e">the value to match</param>
		/// <returns>
		/// the greatest element less than
		/// <code>e</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such element
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified element cannot be
		/// compared with the elements currently in the set
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified element is null
		/// and this set does not permit null elements
		/// </exception>
		E lower(E e);

		/// <summary>
		/// Returns the greatest element in this set less than or equal to
		/// the given element, or
		/// <code>null</code>
		/// if there is no such element.
		/// </summary>
		/// <param name="e">the value to match</param>
		/// <returns>
		/// the greatest element less than or equal to
		/// <code>e</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such element
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified element cannot be
		/// compared with the elements currently in the set
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified element is null
		/// and this set does not permit null elements
		/// </exception>
		E floor(E e);

		/// <summary>
		/// Returns the least element in this set greater than or equal to
		/// the given element, or
		/// <code>null</code>
		/// if there is no such element.
		/// </summary>
		/// <param name="e">the value to match</param>
		/// <returns>
		/// the least element greater than or equal to
		/// <code>e</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such element
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified element cannot be
		/// compared with the elements currently in the set
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified element is null
		/// and this set does not permit null elements
		/// </exception>
		E ceiling(E e);

		/// <summary>
		/// Returns the least element in this set strictly greater than the
		/// given element, or
		/// <code>null</code>
		/// if there is no such element.
		/// </summary>
		/// <param name="e">the value to match</param>
		/// <returns>
		/// the least element greater than
		/// <code>e</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such element
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified element cannot be
		/// compared with the elements currently in the set
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified element is null
		/// and this set does not permit null elements
		/// </exception>
		E higher(E e);

		/// <summary>
		/// Retrieves and removes the first (lowest) element,
		/// or returns
		/// <code>null</code>
		/// if this set is empty.
		/// </summary>
		/// <returns>
		/// the first element, or
		/// <code>null</code>
		/// if this set is empty
		/// </returns>
		E pollFirst();

		/// <summary>
		/// Retrieves and removes the last (highest) element,
		/// or returns
		/// <code>null</code>
		/// if this set is empty.
		/// </summary>
		/// <returns>
		/// the last element, or
		/// <code>null</code>
		/// if this set is empty
		/// </returns>
		E pollLast();

		/// <summary>Returns an iterator over the elements in this set, in ascending order.</summary>
		/// <remarks>Returns an iterator over the elements in this set, in ascending order.</remarks>
		/// <returns>an iterator over the elements in this set, in ascending order</returns>
		java.util.Iterator<E> iterator();

		/// <summary>Returns a reverse order view of the elements contained in this set.</summary>
		/// <remarks>
		/// Returns a reverse order view of the elements contained in this set.
		/// The descending set is backed by this set, so changes to the set are
		/// reflected in the descending set, and vice-versa.  If either set is
		/// modified while an iteration over either set is in progress (except
		/// through the iterator's own
		/// <code>remove</code>
		/// operation), the results of
		/// the iteration are undefined.
		/// <p>The returned set has an ordering equivalent to
		/// <tt>
		/// <see cref="Collections.reverseOrder{T}(Comparator{T})">Collections.reverseOrder</see>
		/// (comparator())</tt>.
		/// The expression
		/// <code>s.descendingSet().descendingSet()</code>
		/// returns a
		/// view of
		/// <code>s</code>
		/// essentially equivalent to
		/// <code>s</code>
		/// .
		/// </remarks>
		/// <returns>a reverse order view of this set</returns>
		java.util.NavigableSet<E> descendingSet();

		/// <summary>Returns an iterator over the elements in this set, in descending order.</summary>
		/// <remarks>
		/// Returns an iterator over the elements in this set, in descending order.
		/// Equivalent in effect to
		/// <code>descendingSet().iterator()</code>
		/// .
		/// </remarks>
		/// <returns>an iterator over the elements in this set, in descending order</returns>
		java.util.Iterator<E> descendingIterator();

		/// <summary>
		/// Returns a view of the portion of this set whose elements range from
		/// <code>fromElement</code>
		/// to
		/// <code>toElement</code>
		/// .  If
		/// <code>fromElement</code>
		/// and
		/// <code>toElement</code>
		/// are equal, the returned set is empty unless
		/// <code>fromExclusive</code>
		/// and
		/// <code>toExclusive</code>
		/// are both true.  The returned set
		/// is backed by this set, so changes in the returned set are reflected in
		/// this set, and vice-versa.  The returned set supports all optional set
		/// operations that this set supports.
		/// <p>The returned set will throw an
		/// <code>IllegalArgumentException</code>
		/// on an attempt to insert an element outside its range.
		/// </summary>
		/// <param name="fromElement">low endpoint of the returned set</param>
		/// <param name="fromInclusive">
		/// 
		/// <code>true</code>
		/// if the low endpoint
		/// is to be included in the returned view
		/// </param>
		/// <param name="toElement">high endpoint of the returned set</param>
		/// <param name="toInclusive">
		/// 
		/// <code>true</code>
		/// if the high endpoint
		/// is to be included in the returned view
		/// </param>
		/// <returns>
		/// a view of the portion of this set whose elements range from
		/// <code>fromElement</code>
		/// , inclusive, to
		/// <code>toElement</code>
		/// , exclusive
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if
		/// <code>fromElement</code>
		/// and
		/// <code>toElement</code>
		/// cannot be compared to one another using this
		/// set's comparator (or, if the set has no comparator, using
		/// natural ordering).  Implementations may, but are not required
		/// to, throw this exception if
		/// <code>fromElement</code>
		/// or
		/// <code>toElement</code>
		/// cannot be compared to elements currently in
		/// the set.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>fromElement</code>
		/// or
		/// <code>toElement</code>
		/// is null and this set does
		/// not permit null elements
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>fromElement</code>
		/// is
		/// greater than
		/// <code>toElement</code>
		/// ; or if this set itself
		/// has a restricted range, and
		/// <code>fromElement</code>
		/// or
		/// <code>toElement</code>
		/// lies outside the bounds of the range.
		/// </exception>
		java.util.NavigableSet<E> subSet(E fromElement, bool fromInclusive, E toElement, 
			bool toInclusive);

		/// <summary>
		/// Returns a view of the portion of this set whose elements are less than
		/// (or equal to, if
		/// <code>inclusive</code>
		/// is true)
		/// <code>toElement</code>
		/// .  The
		/// returned set is backed by this set, so changes in the returned set are
		/// reflected in this set, and vice-versa.  The returned set supports all
		/// optional set operations that this set supports.
		/// <p>The returned set will throw an
		/// <code>IllegalArgumentException</code>
		/// on an attempt to insert an element outside its range.
		/// </summary>
		/// <param name="toElement">high endpoint of the returned set</param>
		/// <param name="inclusive">
		/// 
		/// <code>true</code>
		/// if the high endpoint
		/// is to be included in the returned view
		/// </param>
		/// <returns>
		/// a view of the portion of this set whose elements are less than
		/// (or equal to, if
		/// <code>inclusive</code>
		/// is true)
		/// <code>toElement</code>
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if
		/// <code>toElement</code>
		/// is not compatible
		/// with this set's comparator (or, if the set has no comparator,
		/// if
		/// <code>toElement</code>
		/// does not implement
		/// <see cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</see>
		/// ).
		/// Implementations may, but are not required to, throw this
		/// exception if
		/// <code>toElement</code>
		/// cannot be compared to elements
		/// currently in the set.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>toElement</code>
		/// is null and
		/// this set does not permit null elements
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if this set itself has a
		/// restricted range, and
		/// <code>toElement</code>
		/// lies outside the
		/// bounds of the range
		/// </exception>
		java.util.NavigableSet<E> headSet(E toElement, bool inclusive);

		/// <summary>
		/// Returns a view of the portion of this set whose elements are greater
		/// than (or equal to, if
		/// <code>inclusive</code>
		/// is true)
		/// <code>fromElement</code>
		/// .
		/// The returned set is backed by this set, so changes in the returned set
		/// are reflected in this set, and vice-versa.  The returned set supports
		/// all optional set operations that this set supports.
		/// <p>The returned set will throw an
		/// <code>IllegalArgumentException</code>
		/// on an attempt to insert an element outside its range.
		/// </summary>
		/// <param name="fromElement">low endpoint of the returned set</param>
		/// <param name="inclusive">
		/// 
		/// <code>true</code>
		/// if the low endpoint
		/// is to be included in the returned view
		/// </param>
		/// <returns>
		/// a view of the portion of this set whose elements are greater
		/// than or equal to
		/// <code>fromElement</code>
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if
		/// <code>fromElement</code>
		/// is not compatible
		/// with this set's comparator (or, if the set has no comparator,
		/// if
		/// <code>fromElement</code>
		/// does not implement
		/// <see cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</see>
		/// ).
		/// Implementations may, but are not required to, throw this
		/// exception if
		/// <code>fromElement</code>
		/// cannot be compared to elements
		/// currently in the set.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>fromElement</code>
		/// is null
		/// and this set does not permit null elements
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if this set itself has a
		/// restricted range, and
		/// <code>fromElement</code>
		/// lies outside the
		/// bounds of the range
		/// </exception>
		java.util.NavigableSet<E> tailSet(E fromElement, bool inclusive);

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>Equivalent to
		/// <code>subSet(fromElement, true, toElement, false)</code>
		/// .
		/// </summary>
		/// <exception cref="System.InvalidCastException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		java.util.SortedSet<E> subSet(E fromElement, E toElement);

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>Equivalent to
		/// <code>headSet(toElement, false)</code>
		/// .
		/// </summary>
		/// <exception cref="System.InvalidCastException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// na
		/// </exception>
		java.util.SortedSet<E> headSet(E toElement);

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>Equivalent to
		/// <code>tailSet(fromElement, true)</code>
		/// .
		/// </summary>
		/// <exception cref="System.InvalidCastException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// 
		/// <inheritDoc></inheritDoc>
		/// </exception>
		java.util.SortedSet<E> tailSet(E fromElement);
	}
}
