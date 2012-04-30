using System;

namespace java.util
{
	partial class WeakHashMap
	{
		partial class Entry<K,V>
		{
			internal Entry (K key, V @object, java.lang.@ref.ReferenceQueue<K> queue)
				: base(key)
			{
				isNull = (object)key == null;
				hash = isNull ? 0 : key.GetHashCode ();
				value = @object;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals (object other)
			{
				if (!(other is java.util.MapClass.Entry<K, V>)) {
					return false;
				}
				java.util.MapClass.Entry<object, object> entry = (java.util.MapClass.Entry<object
					, object>)other;
				object key = base.get ();
				return (key == null ? key == entry.getKey () : key.Equals (entry.getKey ())) && ((object)value == null ? (object)entry.getValue () == null : value.Equals (entry.getValue ()));
			}
		}
	}

	partial class WeakHashMap<K,V>
	{
		private static java.util.WeakHashMap.Entry<K, V>[] newEntryArray (int size_1)
		{
			return new java.util.WeakHashMap.Entry<K, V>[size_1];
		}

		internal virtual void poll()
		{
			; // FIXME
		}
	}
}

