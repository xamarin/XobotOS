using Sharpen;

namespace java.util
{
	/// <summary>A map that has its keys ordered.</summary>
	/// <remarks>
	/// A map that has its keys ordered. The sorting is according to either the
	/// natural ordering of its keys or the ordering given by a specified comparator.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface SortedMap<K, V> : java.util.Map<K, V>
	{
		/// <summary>Returns the comparator used to compare keys in this sorted map.</summary>
		/// <remarks>Returns the comparator used to compare keys in this sorted map.</remarks>
		/// <returns>
		/// the comparator or
		/// <code>null</code>
		/// if the natural order is used.
		/// </returns>
		java.util.Comparator<K> comparator();

		/// <summary>Returns the first key in this sorted map.</summary>
		/// <remarks>Returns the first key in this sorted map.</remarks>
		/// <returns>the first key in this sorted map.</returns>
		/// <exception cref="NoSuchElementException">if this sorted map is empty.</exception>
		K firstKey();

		/// <summary>
		/// Returns a sorted map over a range of this sorted map with all keys that
		/// are less than the specified
		/// <code>endKey</code>
		/// . Changes to the returned
		/// sorted map are reflected in this sorted map and vice versa.
		/// <p>
		/// Note: The returned map will not allow an insertion of a key outside the
		/// specified range.
		/// </summary>
		/// <param name="endKey">the high boundary of the range specified.</param>
		/// <returns>
		/// a sorted map where the keys are less than
		/// <code>endKey</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the end key is inappropriate for this sorted
		/// map.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the end key is
		/// <code>null</code>
		/// and this sorted map does not
		/// support
		/// <code>null</code>
		/// keys.
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if this map is itself a sorted map over a range of another
		/// map and the specified key is outside of its range.
		/// </exception>
		java.util.SortedMap<K, V> headMap(K endKey);

		/// <summary>Returns the last key in this sorted map.</summary>
		/// <remarks>Returns the last key in this sorted map.</remarks>
		/// <returns>the last key in this sorted map.</returns>
		/// <exception cref="NoSuchElementException">if this sorted map is empty.</exception>
		K lastKey();

		/// <summary>
		/// Returns a sorted map over a range of this sorted map with all keys
		/// greater than or equal to the specified
		/// <code>startKey</code>
		/// and less than the
		/// specified
		/// <code>endKey</code>
		/// . Changes to the returned sorted map are
		/// reflected in this sorted map and vice versa.
		/// <p>
		/// Note: The returned map will not allow an insertion of a key outside the
		/// specified range.
		/// </summary>
		/// <param name="startKey">the low boundary of the range (inclusive).</param>
		/// <param name="endKey">the high boundary of the range (exclusive),</param>
		/// <returns>a sorted map with the key from the specified range.</returns>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the start or end key is inappropriate for
		/// this sorted map.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the start or end key is
		/// <code>null</code>
		/// and this sorted map
		/// does not support
		/// <code>null</code>
		/// keys.
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if the start key is greater than the end key, or if this map
		/// is itself a sorted map over a range of another sorted map and
		/// the specified range is outside of its range.
		/// </exception>
		java.util.SortedMap<K, V> subMap(K startKey, K endKey);

		/// <summary>
		/// Returns a sorted map over a range of this sorted map with all keys that
		/// are greater than or equal to the specified
		/// <code>startKey</code>
		/// . Changes to
		/// the returned sorted map are reflected in this sorted map and vice versa.
		/// <p>
		/// Note: The returned map will not allow an insertion of a key outside the
		/// specified range.
		/// </summary>
		/// <param name="startKey">the low boundary of the range specified.</param>
		/// <returns>
		/// a sorted map where the keys are greater or equal to
		/// <code>startKey</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the start key is inappropriate for this
		/// sorted map.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the start key is
		/// <code>null</code>
		/// and this sorted map does not
		/// support
		/// <code>null</code>
		/// keys.
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if this map itself a sorted map over a range of another map
		/// and the specified key is outside of its range.
		/// </exception>
		java.util.SortedMap<K, V> tailMap(K startKey);
	}
}
