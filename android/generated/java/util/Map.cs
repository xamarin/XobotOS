using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>Map</code>
	/// is a data structure consisting of a set of keys and values
	/// in which each key is mapped to a single value.  The class of the objects
	/// used as keys is declared when the
	/// <code>Map</code>
	/// is declared, as is the
	/// class of the corresponding values.
	/// <p>
	/// A
	/// <code>Map</code>
	/// provides helper methods to iterate through all of the
	/// keys contained in it, as well as various methods to access and update
	/// the key/value pairs.
	/// </summary>
	[Sharpen.Sharpened]
	public interface Map<K, V>
	{
		/// <summary>
		/// Removes all elements from this
		/// <code>Map</code>
		/// , leaving it empty.
		/// </summary>
		/// <exception cref="System.NotSupportedException">
		/// if removing elements from this
		/// <code>Map</code>
		/// is not supported.
		/// </exception>
		/// <seealso cref="Map{K, V}.isEmpty()">Map&lt;K, V&gt;.isEmpty()</seealso>
		/// <seealso cref="Map{K, V}.size()">Map&lt;K, V&gt;.size()</seealso>
		void clear();

		/// <summary>
		/// Returns whether this
		/// <code>Map</code>
		/// contains the specified key.
		/// </summary>
		/// <param name="key">the key to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this map contains the specified key,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		bool containsKey(object key);

		/// <summary>
		/// Returns whether this
		/// <code>Map</code>
		/// contains the specified value.
		/// </summary>
		/// <param name="value">the value to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this map contains the specified value,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		bool containsValue(object value);

		/// <summary>
		/// Returns a
		/// <code>Set</code>
		/// containing all of the mappings in this
		/// <code>Map</code>
		/// . Each mapping is
		/// an instance of
		/// <see cref="Entry{K, V}">Entry&lt;K, V&gt;</see>
		/// . As the
		/// <code>Set</code>
		/// is backed by this
		/// <code>Map</code>
		/// ,
		/// changes in one will be reflected in the other.
		/// </summary>
		/// <returns>a set of the mappings</returns>
		java.util.Set<java.util.MapClass.Entry<K, V>> entrySet();

		/// <summary>
		/// Compares the argument to the receiver, and returns
		/// <code>true</code>
		/// if the
		/// specified object is a
		/// <code>Map</code>
		/// and both
		/// <code>Map</code>
		/// s contain the same mappings.
		/// </summary>
		/// <param name="object">
		/// the
		/// <code>Object</code>
		/// to compare with this
		/// <code>Object</code>
		/// .
		/// </param>
		/// <returns>
		/// boolean
		/// <code>true</code>
		/// if the
		/// <code>Object</code>
		/// is the same as this
		/// <code>Object</code>
		/// <code>false</code>
		/// if it is different from this
		/// <code>Object</code>
		/// .
		/// </returns>
		/// <seealso cref="Map{K, V}.GetHashCode()">Map&lt;K, V&gt;.GetHashCode()</seealso>
		/// <seealso cref="Map{K, V}.entrySet()">Map&lt;K, V&gt;.entrySet()</seealso>
		bool Equals(object @object);

		/// <summary>Returns the value of the mapping with the specified key.</summary>
		/// <remarks>Returns the value of the mapping with the specified key.</remarks>
		/// <param name="key">the key.</param>
		/// <returns>
		/// the value of the mapping with the specified key, or
		/// <code>null</code>
		/// if no mapping for the specified key is found.
		/// </returns>
		V get(object key);

		/// <summary>Returns an integer hash code for the receiver.</summary>
		/// <remarks>
		/// Returns an integer hash code for the receiver.
		/// <code>Object</code>
		/// s which are equal
		/// return the same value for this method.
		/// </remarks>
		/// <returns>the receiver's hash.</returns>
		/// <seealso cref="Map{K, V}.Equals(object)">Map&lt;K, V&gt;.Equals(object)</seealso>
		int GetHashCode();

		/// <summary>Returns whether this map is empty.</summary>
		/// <remarks>Returns whether this map is empty.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this map has no elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Map{K, V}.size()">Map&lt;K, V&gt;.size()</seealso>
		bool isEmpty();

		/// <summary>
		/// Returns a set of the keys contained in this
		/// <code>Map</code>
		/// . The
		/// <code>Set</code>
		/// is backed by
		/// this
		/// <code>Map</code>
		/// so changes to one are reflected by the other. The
		/// <code>Set</code>
		/// does not
		/// support adding.
		/// </summary>
		/// <returns>a set of the keys.</returns>
		java.util.Set<K> keySet();

		/// <summary>Maps the specified key to the specified value.</summary>
		/// <remarks>Maps the specified key to the specified value.</remarks>
		/// <param name="key">the key.</param>
		/// <param name="value">the value.</param>
		/// <returns>
		/// the value of any previous mapping with the specified key or
		/// <code>null</code>
		/// if there was no mapping.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if adding to this
		/// <code>Map</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the key or value is inappropriate for
		/// this
		/// <code>Map</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if the key or value cannot be added to this
		/// <code>Map</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the key or value is
		/// <code>null</code>
		/// and this
		/// <code>Map</code>
		/// does
		/// not support
		/// <code>null</code>
		/// keys or values.
		/// </exception>
		V put(K key, V value);

		/// <summary>
		/// Copies every mapping in the specified
		/// <code>Map</code>
		/// to this
		/// <code>Map</code>
		/// .
		/// </summary>
		/// <param name="map">
		/// the
		/// <code>Map</code>
		/// to copy mappings from.
		/// </param>
		/// <exception cref="System.NotSupportedException">
		/// if adding to this
		/// <code>Map</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of a key or a value of the specified
		/// <code>Map</code>
		/// is
		/// inappropriate for this
		/// <code>Map</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if a key or value cannot be added to this
		/// <code>Map</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if a key or value is
		/// <code>null</code>
		/// and this
		/// <code>Map</code>
		/// does not
		/// support
		/// <code>null</code>
		/// keys or values.
		/// </exception>
		void putAll<_T0, _T1>(java.util.Map<_T0, _T1> map) where _T0:K where _T1:V;

		/// <summary>
		/// Removes a mapping with the specified key from this
		/// <code>Map</code>
		/// .
		/// </summary>
		/// <param name="key">the key of the mapping to remove.</param>
		/// <returns>
		/// the value of the removed mapping or
		/// <code>null</code>
		/// if no mapping
		/// for the specified key was found.
		/// </returns>
		/// <exception cref="System.NotSupportedException">
		/// if removing from this
		/// <code>Map</code>
		/// is not supported.
		/// </exception>
		V remove(object key);

		/// <summary>
		/// Returns the number of mappings in this
		/// <code>Map</code>
		/// .
		/// </summary>
		/// <returns>
		/// the number of mappings in this
		/// <code>Map</code>
		/// .
		/// </returns>
		int size();

		/// <summary>
		/// Returns a
		/// <code>Collection</code>
		/// of the values contained in this
		/// <code>Map</code>
		/// . The
		/// <code>Collection</code>
		/// is backed by this
		/// <code>Map</code>
		/// so changes to one are reflected by the other. The
		/// <code>Collection</code>
		/// supports
		/// <see cref="Collection{E}.remove(object)">Collection&lt;E&gt;.remove(object)</see>
		/// ,
		/// <see cref="Collection{E}.removeAll(Collection{E})">Collection&lt;E&gt;.removeAll(Collection&lt;E&gt;)
		/// 	</see>
		/// ,
		/// <see cref="Collection{E}.retainAll(Collection{E})">Collection&lt;E&gt;.retainAll(Collection&lt;E&gt;)
		/// 	</see>
		/// , and
		/// <see cref="Collection{E}.clear()">Collection&lt;E&gt;.clear()</see>
		/// operations,
		/// and it does not support
		/// <see cref="Collection{E}.add(object)">Collection&lt;E&gt;.add(object)</see>
		/// or
		/// <see cref="Collection{E}.addAll(Collection{E})">Collection&lt;E&gt;.addAll(Collection&lt;E&gt;)
		/// 	</see>
		/// operations.
		/// <p>
		/// This method returns a
		/// <code>Collection</code>
		/// which is the subclass of
		/// <see cref="AbstractCollection{E}">AbstractCollection&lt;E&gt;</see>
		/// . The
		/// <see cref="AbstractCollection{E}.iterator()">AbstractCollection&lt;E&gt;.iterator()
		/// 	</see>
		/// method of this subclass returns a
		/// "wrapper object" over the iterator of this
		/// <code>Map</code>
		/// 's
		/// <see cref="Map{K, V}.entrySet()">Map&lt;K, V&gt;.entrySet()</see>
		/// . The
		/// <see cref="AbstractCollection{E}.size()">AbstractCollection&lt;E&gt;.size()</see>
		/// method
		/// wraps this
		/// <code>Map</code>
		/// 's
		/// <see cref="Map{K, V}.size()">Map&lt;K, V&gt;.size()</see>
		/// method and the
		/// <see cref="AbstractCollection{E}.contains(object)">AbstractCollection&lt;E&gt;.contains(object)
		/// 	</see>
		/// method wraps this
		/// <code>Map</code>
		/// 's
		/// <see cref="Map{K, V}.containsValue(object)">Map&lt;K, V&gt;.containsValue(object)
		/// 	</see>
		/// method.
		/// <p>
		/// The collection is created when this method is called at first time and
		/// returned in response to all subsequent calls. This method may return
		/// different Collection when multiple calls to this method, since it has no
		/// synchronization performed.
		/// </summary>
		/// <returns>a collection of the values contained in this map.</returns>
		java.util.Collection<V> values();
	}

	/// <summary>
	/// A
	/// <code>Map</code>
	/// is a data structure consisting of a set of keys and values
	/// in which each key is mapped to a single value.  The class of the objects
	/// used as keys is declared when the
	/// <code>Map</code>
	/// is declared, as is the
	/// class of the corresponding values.
	/// <p>
	/// A
	/// <code>Map</code>
	/// provides helper methods to iterate through all of the
	/// keys contained in it, as well as various methods to access and update
	/// the key/value pairs.
	/// </summary>
	[Sharpen.Sharpened]
	public static class MapClass
	{
		/// <summary>
		/// <code>Map.Entry</code>
		/// is a key/value mapping contained in a
		/// <code>Map</code>
		/// .
		/// </summary>
		public interface Entry<K, V>
		{
			/// <summary>
			/// Compares the specified object to this
			/// <code>Map.Entry</code>
			/// and returns if they
			/// are equal. To be equal, the object must be an instance of
			/// <code>Map.Entry</code>
			/// and have the
			/// same key and value.
			/// </summary>
			/// <param name="object">
			/// the
			/// <code>Object</code>
			/// to compare with this
			/// <code>Object</code>
			/// .
			/// </param>
			/// <returns>
			/// 
			/// <code>true</code>
			/// if the specified
			/// <code>Object</code>
			/// is equal to this
			/// <code>Map.Entry</code>
			/// ,
			/// <code>false</code>
			/// otherwise.
			/// </returns>
			/// <seealso cref="Entry{K, V}.GetHashCode()">Entry&lt;K, V&gt;.GetHashCode()</seealso>
			bool Equals(object @object);

			/// <summary>Returns the key.</summary>
			/// <remarks>Returns the key.</remarks>
			/// <returns>the key</returns>
			K getKey();

			/// <summary>Returns the value.</summary>
			/// <remarks>Returns the value.</remarks>
			/// <returns>the value</returns>
			V getValue();

			/// <summary>Returns an integer hash code for the receiver.</summary>
			/// <remarks>
			/// Returns an integer hash code for the receiver.
			/// <code>Object</code>
			/// which are
			/// equal return the same value for this method.
			/// </remarks>
			/// <returns>the receiver's hash code.</returns>
			/// <seealso cref="Entry{K, V}.Equals(object)">Entry&lt;K, V&gt;.Equals(object)</seealso>
			int GetHashCode();

			/// <summary>
			/// Sets the value of this entry to the specified value, replacing any
			/// existing value.
			/// </summary>
			/// <remarks>
			/// Sets the value of this entry to the specified value, replacing any
			/// existing value.
			/// </remarks>
			/// <param name="object">the new value to set.</param>
			/// <returns>object the replaced value of this entry.</returns>
			V setValue(V @object);
		}
	}
}
