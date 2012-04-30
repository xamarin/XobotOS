using Sharpen;

namespace java.io
{
	/// <summary>A specialization of IdentityHashMap<Object, int> for use when serializing objects.
	/// 	</summary>
	/// <remarks>
	/// A specialization of IdentityHashMap<Object, int> for use when serializing objects.
	/// We need to assign each object we write an int 'handle' (densely packed but not starting
	/// at zero), and use the same handle any time we write the same object again.
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class SerializationHandleMap
	{
		internal const int LOAD_FACTOR = 7500;

		private object[] keys;

		private int[] values;

		private int size;

		private int threshold;

		public SerializationHandleMap()
		{
			this.size = 0;
			this.threshold = 21;
			// Copied from IdentityHashMap.
			int arraySize = (int)(((long)threshold * 10000) / LOAD_FACTOR);
			resizeArrays(arraySize);
		}

		private void resizeArrays(int newSize)
		{
			object[] oldKeys = keys;
			int[] oldValues = values;
			this.keys = new object[newSize];
			this.values = new int[newSize];
			if (oldKeys != null)
			{
				{
					for (int i = 0; i < oldKeys.Length; ++i)
					{
						object key = oldKeys[i];
						int value = oldValues[i];
						int index = findIndex(key, keys);
						keys[index] = key;
						values[index] = value;
					}
				}
			}
		}

		public int get(object key)
		{
			int index = findIndex(key, keys);
			if (keys[index] == key)
			{
				return values[index];
			}
			return -1;
		}

		/// <summary>
		/// Returns the index where the key is found at, or the index of the next
		/// empty spot if the key is not found in this table.
		/// </summary>
		/// <remarks>
		/// Returns the index where the key is found at, or the index of the next
		/// empty spot if the key is not found in this table.
		/// </remarks>
		private int findIndex(object key, object[] array)
		{
			int length = array.Length;
			int index = getModuloHash(key, length);
			int last = (index + length - 1) % length;
			while (index != last)
			{
				if (array[index] == key || array[index] == null)
				{
					break;
				}
				index = (index + 1) % length;
			}
			return index;
		}

		private int getModuloHash(object key, int length)
		{
			return (Sharpen.Util.IdentityHashCode(key) & unchecked((int)(0x7FFFFFFF))) % length;
		}

		public int put(object key, int value)
		{
			object _key = key;
			int _value = value;
			int index = findIndex(_key, keys);
			// if the key doesn't exist in the table
			if (keys[index] != _key)
			{
				if (++size > threshold)
				{
					rehash();
					index = findIndex(_key, keys);
				}
				// insert the key and assign the value to -1 initially
				keys[index] = _key;
				values[index] = -1;
			}
			// insert value to where it needs to go, return the old value
			int result = values[index];
			values[index] = _value;
			return result;
		}

		private void rehash()
		{
			int newSize = keys.Length * 2;
			resizeArrays(newSize);
			threshold = (int)((long)(keys.Length) * LOAD_FACTOR / 10000);
		}

		public int remove(object key)
		{
			bool hashedOk;
			int index;
			int next;
			int hash;
			int result;
			object @object;
			index = next = findIndex(key, keys);
			if (keys[index] != key)
			{
				return -1;
			}
			// store the value for this key
			result = values[index];
			// shift the following elements up if needed
			// until we reach an empty spot
			int length = keys.Length;
			while (true)
			{
				next = (next + 2) % length;
				@object = keys[next];
				if (@object == null)
				{
					break;
				}
				hash = getModuloHash(@object, length);
				hashedOk = hash > index;
				if (next < index)
				{
					hashedOk = hashedOk || (hash <= next);
				}
				else
				{
					hashedOk = hashedOk && (hash <= next);
				}
				if (!hashedOk)
				{
					keys[index] = @object;
					values[index] = values[next];
					index = next;
				}
			}
			size--;
			// clear both the key and the value
			keys[index] = null;
			values[index] = -1;
			return result;
		}

		public bool isEmpty()
		{
			return size == 0;
		}
	}
}
