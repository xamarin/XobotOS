using System;
using SCG = System.Collections.Generic;

namespace java.util
{
	public class _HashMap<K,V> : SCG.Dictionary<K,V>
	{
		bool has_null_key;
		V null_value;

		public V remove (K key)
		{
			V item;
			if (key == null) {
				has_null_key = false;
				item = null_value;
				null_value = default (V);
			} else {
				item = this [key];
				base.Remove (key);
			}
			return item;
		}

		public V get (K key)
		{
			if (key == null)
				return null_value;
			if (!ContainsKey (key))
				return default (V);
			return this [key];
		}

		public void put (K key, V item)
		{
			if (key == null) {
				has_null_key = true;
				null_value = item;
				return;
			}
			this [key] = item;
		}

		public int size ()
		{
			return Count;
		}

		public KeyCollection keys ()
		{
			return Keys;
		}

		public ValueCollection values ()
		{
			return Values;
		}

		public void clear ()
		{
			Clear ();
		}
	}
}

