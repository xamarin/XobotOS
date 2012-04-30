using System;
using System.Collections.Generic;

namespace Sharpen
{
	public static class Collections
	{
		public static string ArrayToString<T> (T[] array)
		{
			throw new NotImplementedException ();
		}

		public static bool Remove<T> (List<T> list, T item)
		{
			return list.Remove (item);
		}

		public static T Remove<T> (List<T> list, int index)
		{
			T item = list [index];
			list.RemoveAt (index);
			return item;
		}

		public static bool Remove<T> (IList<T> list, T item)
		{
			return list.Remove (item);
		}

		public static T Remove<T> (IList<T> list, int index)
		{
			T item = list [index];
			list.RemoveAt (index);
			return item;
		}

		public static V Remove<K, V> (Dictionary<K,V> dictionary, K key)
		{
			V item = dictionary [key];
			dictionary.Remove (key);
			return item;
		}

		public static List<T> clone<T> (this List<T> list)
		{
			throw new NotImplementedException ();
		}

		public static T[] ToArray<T> (this List<T> list, T[] dummy)
		{
			return list.ToArray ();
		}

		public static T[] ToArray<T> (this List<T> list)
		{
			return list.ToArray ();
		}

		public static T[] ToArray<T> (this IList<T> list, T[] dummy)
		{
			return list.ToArray ();
		}

		public static T[] ToArray<T> (this IList<T> list)
		{
			return list.ToArray ();
		}

		public static void AddRange<T> (this ICollection<T> collection, ICollection<T> items)
		{
			foreach (T item in items)
				collection.Add (item);
		}

		public static V Get<K, V> (Dictionary<K,V> dict, K key)
		{
			if (!dict.ContainsKey (key))
				return default (V);
			return dict [key];
		}

		public static void Put<K, V> (Dictionary<K,V> dict, K key, V item)
		{
			dict [key] = item;
		}

		public static V Get<K, V> (IDictionary<K,V> dict, K key)
		{
			if (!dict.ContainsKey (key))
				return default (V);
			return dict [key];
		}

		public static void Put<K, V> (IDictionary<K,V> dict, K key, V item)
		{
			dict [key] = item;
		}

	}
}

