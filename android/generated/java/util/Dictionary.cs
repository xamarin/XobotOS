using Sharpen;

namespace java.util
{
	/// <summary><strong>Note: Do not use this class since it is obsolete.</summary>
	/// <remarks>
	/// <strong>Note: Do not use this class since it is obsolete. Please use the
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// interface for new implementations.</strong>
	/// <p>
	/// Dictionary is an abstract class which is the superclass of all classes that
	/// associate keys with values, such as
	/// <code>Hashtable</code>
	/// .
	/// </remarks>
	/// <seealso cref="Hashtable{K, V}">Hashtable&lt;K, V&gt;</seealso>
	/// <since>1.0</since>
	[Sharpen.Sharpened]
	public abstract class Dictionary<K, V>
	{
		/// <summary>Constructs a new instance of this class.</summary>
		/// <remarks>Constructs a new instance of this class.</remarks>
		public Dictionary()
		{
		}

		/// <summary>Returns an enumeration on the elements of this dictionary.</summary>
		/// <remarks>Returns an enumeration on the elements of this dictionary.</remarks>
		/// <returns>an enumeration of the values of this dictionary.</returns>
		/// <seealso cref="Dictionary{K, V}.keys()">Dictionary&lt;K, V&gt;.keys()</seealso>
		/// <seealso cref="Dictionary{K, V}.size()">Dictionary&lt;K, V&gt;.size()</seealso>
		/// <seealso cref="Enumeration{E}">Enumeration&lt;E&gt;</seealso>
		public abstract java.util.Enumeration<V> elements();

		/// <summary>
		/// Returns the value which is associated with
		/// <code>key</code>
		/// .
		/// </summary>
		/// <param name="key">the key of the value returned.</param>
		/// <returns>
		/// the value associated with
		/// <code>key</code>
		/// , or
		/// <code>null</code>
		/// if the
		/// specified key does not exist.
		/// </returns>
		/// <seealso cref="Dictionary{K, V}.put(object, object)">Dictionary&lt;K, V&gt;.put(object, object)
		/// 	</seealso>
		public abstract V get(object key);

		/// <summary>Returns true if this dictionary has no key/value pairs.</summary>
		/// <remarks>Returns true if this dictionary has no key/value pairs.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this dictionary has no key/value pairs,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Dictionary{K, V}.size()">Dictionary&lt;K, V&gt;.size()</seealso>
		public abstract bool isEmpty();

		/// <summary>Returns an enumeration on the keys of this dictionary.</summary>
		/// <remarks>Returns an enumeration on the keys of this dictionary.</remarks>
		/// <returns>an enumeration of the keys of this dictionary.</returns>
		/// <seealso cref="Dictionary{K, V}.elements()">Dictionary&lt;K, V&gt;.elements()</seealso>
		/// <seealso cref="Dictionary{K, V}.size()">Dictionary&lt;K, V&gt;.size()</seealso>
		/// <seealso cref="Enumeration{E}">Enumeration&lt;E&gt;</seealso>
		public abstract java.util.Enumeration<K> keys();

		/// <summary>
		/// Associate
		/// <code>key</code>
		/// with
		/// <code>value</code>
		/// in this dictionary. If
		/// <code>key</code>
		/// exists in the dictionary before this call, the old value in the
		/// dictionary is replaced by
		/// <code>value</code>
		/// .
		/// </summary>
		/// <param name="key">the key to add.</param>
		/// <param name="value">the value to add.</param>
		/// <returns>
		/// the old value previously associated with
		/// <code>key</code>
		/// or
		/// <code>null</code>
		/// if
		/// <code>key</code>
		/// is new to the dictionary.
		/// </returns>
		/// <seealso cref="Dictionary{K, V}.elements()">Dictionary&lt;K, V&gt;.elements()</seealso>
		/// <seealso cref="Dictionary{K, V}.get(object)">Dictionary&lt;K, V&gt;.get(object)</seealso>
		/// <seealso cref="Dictionary{K, V}.keys()">Dictionary&lt;K, V&gt;.keys()</seealso>
		public abstract V put(K key, V value);

		/// <summary>
		/// Removes the key/value pair with the specified
		/// <code>key</code>
		/// from this
		/// dictionary.
		/// </summary>
		/// <param name="key">the key to remove.</param>
		/// <returns>
		/// the associated value before the deletion or
		/// <code>null</code>
		/// if
		/// <code>key</code>
		/// was not known to this dictionary.
		/// </returns>
		/// <seealso cref="Dictionary{K, V}.get(object)">Dictionary&lt;K, V&gt;.get(object)</seealso>
		/// <seealso cref="Dictionary{K, V}.put(object, object)">Dictionary&lt;K, V&gt;.put(object, object)
		/// 	</seealso>
		public abstract V remove(object key);

		/// <summary>Returns the number of key/value pairs in this dictionary.</summary>
		/// <remarks>Returns the number of key/value pairs in this dictionary.</remarks>
		/// <returns>the number of key/value pairs in this dictionary.</returns>
		/// <seealso cref="Dictionary{K, V}.elements()">Dictionary&lt;K, V&gt;.elements()</seealso>
		/// <seealso cref="Dictionary{K, V}.keys()">Dictionary&lt;K, V&gt;.keys()</seealso>
		public abstract int size();
	}
}
