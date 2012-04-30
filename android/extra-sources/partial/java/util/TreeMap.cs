namespace java.util
{
	partial class TreeMap<K, V>
	{
		partial class BoundedMap
		{
			/// <exception cref="java.io.ObjectStreamException"></exception>
			internal object writeReplace ()
			{
				return ascending ? (object)new TreeMap.AscendingSubMap<K, V> (_enclosing, @from, fromBound, to, toBound)
					: (object)new TreeMap.DescendingSubMap<K, V> (_enclosing, @from, fromBound, to, toBound);
			}
		}
	}
}
