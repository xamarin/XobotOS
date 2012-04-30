using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <see cref="SortedMap{K, V}">SortedMap&lt;K, V&gt;</see>
	/// extended with navigation methods returning the
	/// closest matches for given search targets. Methods
	/// <code>lowerEntry</code>
	/// ,
	/// <code>floorEntry</code>
	/// ,
	/// <code>ceilingEntry</code>
	/// ,
	/// and
	/// <code>higherEntry</code>
	/// return
	/// <code>Map.Entry</code>
	/// objects
	/// associated with keys respectively less than, less than or equal,
	/// greater than or equal, and greater than a given key, returning
	/// <code>null</code>
	/// if there is no such key.  Similarly, methods
	/// <code>lowerKey</code>
	/// ,
	/// <code>floorKey</code>
	/// ,
	/// <code>ceilingKey</code>
	/// , and
	/// <code>higherKey</code>
	/// return only the associated keys. All of these
	/// methods are designed for locating, not traversing entries.
	/// <p>A
	/// <code>NavigableMap</code>
	/// may be accessed and traversed in either
	/// ascending or descending key order.  The
	/// <code>descendingMap</code>
	/// method returns a view of the map with the senses of all relational
	/// and directional methods inverted. The performance of ascending
	/// operations and views is likely to be faster than that of descending
	/// ones.  Methods
	/// <code>subMap</code>
	/// ,
	/// <code>headMap</code>
	/// ,
	/// and
	/// <code>tailMap</code>
	/// differ from the like-named
	/// <code>SortedMap</code>
	/// methods in accepting additional arguments describing
	/// whether lower and upper bounds are inclusive versus exclusive.
	/// Submaps of any
	/// <code>NavigableMap</code>
	/// must implement the
	/// <code>NavigableMap</code>
	/// interface.
	/// <p>This interface additionally defines methods
	/// <code>firstEntry</code>
	/// ,
	/// <code>pollFirstEntry</code>
	/// ,
	/// <code>lastEntry</code>
	/// , and
	/// <code>pollLastEntry</code>
	/// that return and/or remove the least and
	/// greatest mappings, if any exist, else returning
	/// <code>null</code>
	/// .
	/// <p>Implementations of entry-returning methods are expected to
	/// return
	/// <code>Map.Entry</code>
	/// pairs representing snapshots of mappings
	/// at the time they were produced, and thus generally do <em>not</em>
	/// support the optional
	/// <code>Entry.setValue</code>
	/// method. Note however
	/// that it is possible to change mappings in the associated map using
	/// method
	/// <code>put</code>
	/// .
	/// <p>Methods
	/// <see cref="NavigableMap{K, V}.subMap(object, object)">subMap(K, K)</see>
	/// ,
	/// <see cref="NavigableMap{K, V}.headMap(object)">headMap(K)</see>
	/// , and
	/// <see cref="NavigableMap{K, V}.tailMap(object)">tailMap(K)</see>
	/// are specified to return
	/// <code>SortedMap</code>
	/// to allow existing
	/// implementations of
	/// <code>SortedMap</code>
	/// to be compatibly retrofitted to
	/// implement
	/// <code>NavigableMap</code>
	/// , but extensions and implementations
	/// of this interface are encouraged to override these methods to return
	/// <code>NavigableMap</code>
	/// .  Similarly,
	/// <see cref="Map{K, V}.keySet()">Map&lt;K, V&gt;.keySet()</see>
	/// can be overriden to return
	/// <code>NavigableSet</code>
	/// .
	/// </summary>
	/// <author>Doug Lea</author>
	/// <author>Josh Bloch</author>
	/// <?></?>
	/// <?></?>
	/// <since>1.6</since>
	[Sharpen.Sharpened]
	public interface NavigableMap<K, V> : java.util.SortedMap<K, V>
	{
		// BEGIN android-note
		// removed link to collections framework docs
		// changed {@link #subMap(Object)} to {@link #subMap} to satisfy DroidDoc
		// END android-note
		/// <summary>
		/// Returns a key-value mapping associated with the greatest key
		/// strictly less than the given key, or
		/// <code>null</code>
		/// if there is
		/// no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// an entry with the greatest key less than
		/// <code>key</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		java.util.MapClass.Entry<K, V> lowerEntry(K key);

		/// <summary>
		/// Returns the greatest key strictly less than the given key, or
		/// <code>null</code>
		/// if there is no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// the greatest key less than
		/// <code>key</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		K lowerKey(K key);

		/// <summary>
		/// Returns a key-value mapping associated with the greatest key
		/// less than or equal to the given key, or
		/// <code>null</code>
		/// if there
		/// is no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// an entry with the greatest key less than or equal to
		/// <code>key</code>
		/// , or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		java.util.MapClass.Entry<K, V> floorEntry(K key);

		/// <summary>
		/// Returns the greatest key less than or equal to the given key,
		/// or
		/// <code>null</code>
		/// if there is no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// the greatest key less than or equal to
		/// <code>key</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		K floorKey(K key);

		/// <summary>
		/// Returns a key-value mapping associated with the least key
		/// greater than or equal to the given key, or
		/// <code>null</code>
		/// if
		/// there is no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// an entry with the least key greater than or equal to
		/// <code>key</code>
		/// , or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		java.util.MapClass.Entry<K, V> ceilingEntry(K key);

		/// <summary>
		/// Returns the least key greater than or equal to the given key,
		/// or
		/// <code>null</code>
		/// if there is no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// the least key greater than or equal to
		/// <code>key</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		K ceilingKey(K key);

		/// <summary>
		/// Returns a key-value mapping associated with the least key
		/// strictly greater than the given key, or
		/// <code>null</code>
		/// if there
		/// is no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// an entry with the least key greater than
		/// <code>key</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		java.util.MapClass.Entry<K, V> higherEntry(K key);

		/// <summary>
		/// Returns the least key strictly greater than the given key, or
		/// <code>null</code>
		/// if there is no such key.
		/// </summary>
		/// <param name="key">the key</param>
		/// <returns>
		/// the least key greater than
		/// <code>key</code>
		/// ,
		/// or
		/// <code>null</code>
		/// if there is no such key
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the specified key cannot be compared
		/// with the keys currently in the map
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified key is null
		/// and this map does not permit null keys
		/// </exception>
		K higherKey(K key);

		/// <summary>
		/// Returns a key-value mapping associated with the least
		/// key in this map, or
		/// <code>null</code>
		/// if the map is empty.
		/// </summary>
		/// <returns>
		/// an entry with the least key,
		/// or
		/// <code>null</code>
		/// if this map is empty
		/// </returns>
		java.util.MapClass.Entry<K, V> firstEntry();

		/// <summary>
		/// Returns a key-value mapping associated with the greatest
		/// key in this map, or
		/// <code>null</code>
		/// if the map is empty.
		/// </summary>
		/// <returns>
		/// an entry with the greatest key,
		/// or
		/// <code>null</code>
		/// if this map is empty
		/// </returns>
		java.util.MapClass.Entry<K, V> lastEntry();

		/// <summary>
		/// Removes and returns a key-value mapping associated with
		/// the least key in this map, or
		/// <code>null</code>
		/// if the map is empty.
		/// </summary>
		/// <returns>
		/// the removed first entry of this map,
		/// or
		/// <code>null</code>
		/// if this map is empty
		/// </returns>
		java.util.MapClass.Entry<K, V> pollFirstEntry();

		/// <summary>
		/// Removes and returns a key-value mapping associated with
		/// the greatest key in this map, or
		/// <code>null</code>
		/// if the map is empty.
		/// </summary>
		/// <returns>
		/// the removed last entry of this map,
		/// or
		/// <code>null</code>
		/// if this map is empty
		/// </returns>
		java.util.MapClass.Entry<K, V> pollLastEntry();

		/// <summary>Returns a reverse order view of the mappings contained in this map.</summary>
		/// <remarks>
		/// Returns a reverse order view of the mappings contained in this map.
		/// The descending map is backed by this map, so changes to the map are
		/// reflected in the descending map, and vice-versa.  If either map is
		/// modified while an iteration over a collection view of either map
		/// is in progress (except through the iterator's own
		/// <code>remove</code>
		/// operation), the results of the iteration are undefined.
		/// <p>The returned map has an ordering equivalent to
		/// <tt>
		/// <see cref="Collections.reverseOrder{T}(Comparator{T})">Collections.reverseOrder</see>
		/// (comparator())</tt>.
		/// The expression
		/// <code>m.descendingMap().descendingMap()</code>
		/// returns a
		/// view of
		/// <code>m</code>
		/// essentially equivalent to
		/// <code>m</code>
		/// .
		/// </remarks>
		/// <returns>a reverse order view of this map</returns>
		java.util.NavigableMap<K, V> descendingMap();

		/// <summary>
		/// Returns a
		/// <see cref="NavigableSet{E}">NavigableSet&lt;E&gt;</see>
		/// view of the keys contained in this map.
		/// The set's iterator returns the keys in ascending order.
		/// The set is backed by the map, so changes to the map are reflected in
		/// the set, and vice-versa.  If the map is modified while an iteration
		/// over the set is in progress (except through the iterator's own
		/// <code>remove</code>
		/// operation), the results of the iteration are undefined.  The
		/// set supports element removal, which removes the corresponding mapping
		/// from the map, via the
		/// <code>Iterator.remove</code>
		/// ,
		/// <code>Set.remove</code>
		/// ,
		/// <code>removeAll</code>
		/// ,
		/// <code>retainAll</code>
		/// , and
		/// <code>clear</code>
		/// operations.
		/// It does not support the
		/// <code>add</code>
		/// or
		/// <code>addAll</code>
		/// operations.
		/// </summary>
		/// <returns>a navigable set view of the keys in this map</returns>
		java.util.NavigableSet<K> navigableKeySet();

		/// <summary>
		/// Returns a reverse order
		/// <see cref="NavigableSet{E}">NavigableSet&lt;E&gt;</see>
		/// view of the keys contained in this map.
		/// The set's iterator returns the keys in descending order.
		/// The set is backed by the map, so changes to the map are reflected in
		/// the set, and vice-versa.  If the map is modified while an iteration
		/// over the set is in progress (except through the iterator's own
		/// <code>remove</code>
		/// operation), the results of the iteration are undefined.  The
		/// set supports element removal, which removes the corresponding mapping
		/// from the map, via the
		/// <code>Iterator.remove</code>
		/// ,
		/// <code>Set.remove</code>
		/// ,
		/// <code>removeAll</code>
		/// ,
		/// <code>retainAll</code>
		/// , and
		/// <code>clear</code>
		/// operations.
		/// It does not support the
		/// <code>add</code>
		/// or
		/// <code>addAll</code>
		/// operations.
		/// </summary>
		/// <returns>a reverse order navigable set view of the keys in this map</returns>
		java.util.NavigableSet<K> descendingKeySet();

		/// <summary>
		/// Returns a view of the portion of this map whose keys range from
		/// <code>fromKey</code>
		/// to
		/// <code>toKey</code>
		/// .  If
		/// <code>fromKey</code>
		/// and
		/// <code>toKey</code>
		/// are equal, the returned map is empty unless
		/// <code>fromExclusive</code>
		/// and
		/// <code>toExclusive</code>
		/// are both true.  The
		/// returned map is backed by this map, so changes in the returned map are
		/// reflected in this map, and vice-versa.  The returned map supports all
		/// optional map operations that this map supports.
		/// <p>The returned map will throw an
		/// <code>IllegalArgumentException</code>
		/// on an attempt to insert a key outside of its range, or to construct a
		/// submap either of whose endpoints lie outside its range.
		/// </summary>
		/// <param name="fromKey">low endpoint of the keys in the returned map</param>
		/// <param name="fromInclusive">
		/// 
		/// <code>true</code>
		/// if the low endpoint
		/// is to be included in the returned view
		/// </param>
		/// <param name="toKey">high endpoint of the keys in the returned map</param>
		/// <param name="toInclusive">
		/// 
		/// <code>true</code>
		/// if the high endpoint
		/// is to be included in the returned view
		/// </param>
		/// <returns>
		/// a view of the portion of this map whose keys range from
		/// <code>fromKey</code>
		/// to
		/// <code>toKey</code>
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if
		/// <code>fromKey</code>
		/// and
		/// <code>toKey</code>
		/// cannot be compared to one another using this map's comparator
		/// (or, if the map has no comparator, using natural ordering).
		/// Implementations may, but are not required to, throw this
		/// exception if
		/// <code>fromKey</code>
		/// or
		/// <code>toKey</code>
		/// cannot be compared to keys currently in the map.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>fromKey</code>
		/// or
		/// <code>toKey</code>
		/// is null and this map does not permit null keys
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>fromKey</code>
		/// is greater than
		/// <code>toKey</code>
		/// ; or if this map itself has a restricted
		/// range, and
		/// <code>fromKey</code>
		/// or
		/// <code>toKey</code>
		/// lies
		/// outside the bounds of the range
		/// </exception>
		java.util.NavigableMap<K, V> subMap(K fromKey, bool fromInclusive, K toKey, bool 
			toInclusive);

		/// <summary>
		/// Returns a view of the portion of this map whose keys are less than (or
		/// equal to, if
		/// <code>inclusive</code>
		/// is true)
		/// <code>toKey</code>
		/// .  The returned
		/// map is backed by this map, so changes in the returned map are reflected
		/// in this map, and vice-versa.  The returned map supports all optional
		/// map operations that this map supports.
		/// <p>The returned map will throw an
		/// <code>IllegalArgumentException</code>
		/// on an attempt to insert a key outside its range.
		/// </summary>
		/// <param name="toKey">high endpoint of the keys in the returned map</param>
		/// <param name="inclusive">
		/// 
		/// <code>true</code>
		/// if the high endpoint
		/// is to be included in the returned view
		/// </param>
		/// <returns>
		/// a view of the portion of this map whose keys are less than
		/// (or equal to, if
		/// <code>inclusive</code>
		/// is true)
		/// <code>toKey</code>
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if
		/// <code>toKey</code>
		/// is not compatible
		/// with this map's comparator (or, if the map has no comparator,
		/// if
		/// <code>toKey</code>
		/// does not implement
		/// <see cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</see>
		/// ).
		/// Implementations may, but are not required to, throw this
		/// exception if
		/// <code>toKey</code>
		/// cannot be compared to keys
		/// currently in the map.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>toKey</code>
		/// is null
		/// and this map does not permit null keys
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if this map itself has a
		/// restricted range, and
		/// <code>toKey</code>
		/// lies outside the
		/// bounds of the range
		/// </exception>
		java.util.NavigableMap<K, V> headMap(K toKey, bool inclusive);

		/// <summary>
		/// Returns a view of the portion of this map whose keys are greater than (or
		/// equal to, if
		/// <code>inclusive</code>
		/// is true)
		/// <code>fromKey</code>
		/// .  The returned
		/// map is backed by this map, so changes in the returned map are reflected
		/// in this map, and vice-versa.  The returned map supports all optional
		/// map operations that this map supports.
		/// <p>The returned map will throw an
		/// <code>IllegalArgumentException</code>
		/// on an attempt to insert a key outside its range.
		/// </summary>
		/// <param name="fromKey">low endpoint of the keys in the returned map</param>
		/// <param name="inclusive">
		/// 
		/// <code>true</code>
		/// if the low endpoint
		/// is to be included in the returned view
		/// </param>
		/// <returns>
		/// a view of the portion of this map whose keys are greater than
		/// (or equal to, if
		/// <code>inclusive</code>
		/// is true)
		/// <code>fromKey</code>
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if
		/// <code>fromKey</code>
		/// is not compatible
		/// with this map's comparator (or, if the map has no comparator,
		/// if
		/// <code>fromKey</code>
		/// does not implement
		/// <see cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</see>
		/// ).
		/// Implementations may, but are not required to, throw this
		/// exception if
		/// <code>fromKey</code>
		/// cannot be compared to keys
		/// currently in the map.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>fromKey</code>
		/// is null
		/// and this map does not permit null keys
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if this map itself has a
		/// restricted range, and
		/// <code>fromKey</code>
		/// lies outside the
		/// bounds of the range
		/// </exception>
		java.util.NavigableMap<K, V> tailMap(K fromKey, bool inclusive);

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>Equivalent to
		/// <code>subMap(fromKey, true, toKey, false)</code>
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
		java.util.SortedMap<K, V> subMap(K fromKey, K toKey);

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>Equivalent to
		/// <code>headMap(toKey, false)</code>
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
		java.util.SortedMap<K, V> headMap(K toKey);

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>Equivalent to
		/// <code>tailMap(fromKey, true)</code>
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
		java.util.SortedMap<K, V> tailMap(K fromKey);
	}
}
