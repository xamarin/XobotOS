using Sharpen;
using java.lang;

namespace java.util
{
	partial class Hashtable<K, V>
	{
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode ()
		{
			lock (this) {
				int result = 0;
				foreach (MapClass.Entry<K, V> e in IterableProxy.Create(entrySet())) {
					K key = e.getKey ();
					V value = e.getValue ();
					// FIXME
//					if (key == this || value == this)
//					{
//						continue;
//					}
					result += (key != null ? key.GetHashCode () : 0) ^ (value != null ? value.GetHashCode () : 0);
				}
				return result;
			}
		}

		/// <summary>
		/// Returns the string representation of this
		/// <code>Hashtable</code>
		/// .
		/// </summary>
		/// <returns>
		/// the string representation of this
		/// <code>Hashtable</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString ()
		{
			lock (this) {
				StringBuilder result = new StringBuilder (Hashtable.CHARS_PER_ENTRY * _size);
				result.append ('{');
				Iterator<MapClass.Entry<K, V>> i = entrySet ().iterator ();
				bool hasMore = i.hasNext ();
				while (hasMore) {
					MapClass.Entry<K, V> entry = i.next ();
					K key = entry.getKey ();
					// FIXME
//					result.append(key == this ? "(this Map)" : key.ToString());
					result.append (key.ToString ());
					result.append ('=');
					V value = entry.getValue ();
					// FIXME
//					result.append(value == this ? "(this Map)" : value.ToString());
					result.append (value.ToString ());
					if (hasMore = i.hasNext ()) {
						result.append (", ");
					}
				}
				result.append ('}');
				return result.ToString ();
			}
		}
	}
}

