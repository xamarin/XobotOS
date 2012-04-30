using Sharpen;

namespace android.util
{
	/// <summary>SparseArrays map integers to Objects.</summary>
	/// <remarks>
	/// SparseArrays map integers to Objects.  Unlike a normal array of Objects,
	/// there can be gaps in the indices.  It is intended to be more efficient
	/// than using a HashMap to map Integers to Objects.
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class SparseArray<E> : System.ICloneable
	{
		private static readonly object DELETED = new object();

		private bool mGarbage = false;

		private int[] mKeys;

		private object[] mValues;

		private int mSize;

		/// <summary>Creates a new SparseArray containing no mappings.</summary>
		/// <remarks>Creates a new SparseArray containing no mappings.</remarks>
		public SparseArray() : this(10)
		{
		}

		/// <summary>
		/// Creates a new SparseArray containing no mappings that will not
		/// require any additional memory allocation to store the specified
		/// number of mappings.
		/// </summary>
		/// <remarks>
		/// Creates a new SparseArray containing no mappings that will not
		/// require any additional memory allocation to store the specified
		/// number of mappings.
		/// </remarks>
		public SparseArray(int initialCapacity)
		{
			initialCapacity = android.util.@internal.ArrayUtils.idealIntArraySize(initialCapacity
				);
			mKeys = new int[initialCapacity];
			mValues = new object[initialCapacity];
			mSize = 0;
		}

		public virtual android.util.SparseArray<E> clone()
		{
			android.util.SparseArray<E> clone_1 = null;
			clone_1 = (android.util.SparseArray<E>)base.MemberwiseClone();
			clone_1.mKeys = (int[])mKeys.Clone();
			clone_1.mValues = (object[])mValues.Clone();
			return clone_1;
		}

		/// <summary>
		/// Gets the Object mapped from the specified key, or <code>null</code>
		/// if no such mapping has been made.
		/// </summary>
		/// <remarks>
		/// Gets the Object mapped from the specified key, or <code>null</code>
		/// if no such mapping has been made.
		/// </remarks>
		public virtual E get(int key)
		{
			return get(key, default(E));
		}

		/// <summary>
		/// Gets the Object mapped from the specified key, or the specified Object
		/// if no such mapping has been made.
		/// </summary>
		/// <remarks>
		/// Gets the Object mapped from the specified key, or the specified Object
		/// if no such mapping has been made.
		/// </remarks>
		public virtual E get(int key, E valueIfKeyNotFound)
		{
			int i = binarySearch(mKeys, 0, mSize, key);
			if (i < 0 || mValues[i] == DELETED)
			{
				return valueIfKeyNotFound;
			}
			else
			{
				return (E)mValues[i];
			}
		}

		/// <summary>Removes the mapping from the specified key, if there was any.</summary>
		/// <remarks>Removes the mapping from the specified key, if there was any.</remarks>
		public virtual void delete(int key)
		{
			int i = binarySearch(mKeys, 0, mSize, key);
			if (i >= 0)
			{
				if (mValues[i] != DELETED)
				{
					mValues[i] = DELETED;
					mGarbage = true;
				}
			}
		}

		/// <summary>
		/// Alias for
		/// <see cref="SparseArray{E}.delete(int)">SparseArray&lt;E&gt;.delete(int)</see>
		/// .
		/// </summary>
		public virtual void remove(int key)
		{
			delete(key);
		}

		/// <summary>Removes the mapping at the specified index.</summary>
		/// <remarks>Removes the mapping at the specified index.</remarks>
		public virtual void removeAt(int index)
		{
			if (mValues[index] != DELETED)
			{
				mValues[index] = DELETED;
				mGarbage = true;
			}
		}

		private void gc()
		{
			// Log.e("SparseArray", "gc start with " + mSize);
			int n = mSize;
			int o = 0;
			int[] keys = mKeys;
			object[] values = mValues;
			{
				for (int i = 0; i < n; i++)
				{
					object val = values[i];
					if (val != DELETED)
					{
						if (i != o)
						{
							keys[o] = keys[i];
							values[o] = val;
						}
						o++;
					}
				}
			}
			mGarbage = false;
			mSize = o;
		}

		// Log.e("SparseArray", "gc end with " + mSize);
		/// <summary>
		/// Adds a mapping from the specified key to the specified value,
		/// replacing the previous mapping from the specified key if there
		/// was one.
		/// </summary>
		/// <remarks>
		/// Adds a mapping from the specified key to the specified value,
		/// replacing the previous mapping from the specified key if there
		/// was one.
		/// </remarks>
		public virtual void put(int key, E value)
		{
			int i = binarySearch(mKeys, 0, mSize, key);
			if (i >= 0)
			{
				mValues[i] = value;
			}
			else
			{
				i = ~i;
				if (i < mSize && mValues[i] == DELETED)
				{
					mKeys[i] = key;
					mValues[i] = value;
					return;
				}
				if (mGarbage && mSize >= mKeys.Length)
				{
					gc();
					// Search again because indices may have changed.
					i = ~binarySearch(mKeys, 0, mSize, key);
				}
				if (mSize >= mKeys.Length)
				{
					int n = android.util.@internal.ArrayUtils.idealIntArraySize(mSize + 1);
					int[] nkeys = new int[n];
					object[] nvalues = new object[n];
					// Log.e("SparseArray", "grow " + mKeys.length + " to " + n);
					System.Array.Copy(mKeys, 0, nkeys, 0, mKeys.Length);
					System.Array.Copy(mValues, 0, nvalues, 0, mValues.Length);
					mKeys = nkeys;
					mValues = nvalues;
				}
				if (mSize - i != 0)
				{
					// Log.e("SparseArray", "move " + (mSize - i));
					System.Array.Copy(mKeys, i, mKeys, i + 1, mSize - i);
					System.Array.Copy(mValues, i, mValues, i + 1, mSize - i);
				}
				mKeys[i] = key;
				mValues[i] = value;
				mSize++;
			}
		}

		/// <summary>
		/// Returns the number of key-value mappings that this SparseArray
		/// currently stores.
		/// </summary>
		/// <remarks>
		/// Returns the number of key-value mappings that this SparseArray
		/// currently stores.
		/// </remarks>
		public virtual int size()
		{
			if (mGarbage)
			{
				gc();
			}
			return mSize;
		}

		/// <summary>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the key from the <code>index</code>th key-value mapping that this
		/// SparseArray stores.
		/// </summary>
		/// <remarks>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the key from the <code>index</code>th key-value mapping that this
		/// SparseArray stores.
		/// </remarks>
		public virtual int keyAt(int index)
		{
			if (mGarbage)
			{
				gc();
			}
			return mKeys[index];
		}

		/// <summary>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the value from the <code>index</code>th key-value mapping that this
		/// SparseArray stores.
		/// </summary>
		/// <remarks>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the value from the <code>index</code>th key-value mapping that this
		/// SparseArray stores.
		/// </remarks>
		public virtual E valueAt(int index)
		{
			if (mGarbage)
			{
				gc();
			}
			return (E)mValues[index];
		}

		/// <summary>
		/// Given an index in the range <code>0...size()-1</code>, sets a new
		/// value for the <code>index</code>th key-value mapping that this
		/// SparseArray stores.
		/// </summary>
		/// <remarks>
		/// Given an index in the range <code>0...size()-1</code>, sets a new
		/// value for the <code>index</code>th key-value mapping that this
		/// SparseArray stores.
		/// </remarks>
		public virtual void setValueAt(int index, E value)
		{
			if (mGarbage)
			{
				gc();
			}
			mValues[index] = value;
		}

		/// <summary>
		/// Returns the index for which
		/// <see cref="SparseArray{E}.keyAt(int)">SparseArray&lt;E&gt;.keyAt(int)</see>
		/// would return the
		/// specified key, or a negative number if the specified
		/// key is not mapped.
		/// </summary>
		public virtual int indexOfKey(int key)
		{
			if (mGarbage)
			{
				gc();
			}
			return binarySearch(mKeys, 0, mSize, key);
		}

		/// <summary>
		/// Returns an index for which
		/// <see cref="SparseArray{E}.valueAt(int)">SparseArray&lt;E&gt;.valueAt(int)</see>
		/// would return the
		/// specified key, or a negative number if no keys map to the
		/// specified value.
		/// Beware that this is a linear search, unlike lookups by key,
		/// and that multiple keys can map to the same value and this will
		/// find only one of them.
		/// </summary>
		public virtual int indexOfValue(E value)
		{
			if (mGarbage)
			{
				gc();
			}
			{
				for (int i = 0; i < mSize; i++)
				{
					if (Sharpen.Util.Equals(value, mValues[i]))
					{
						return i;
					}
				}
			}
			return -1;
		}

		/// <summary>Removes all key-value mappings from this SparseArray.</summary>
		/// <remarks>Removes all key-value mappings from this SparseArray.</remarks>
		public virtual void clear()
		{
			int n = mSize;
			object[] values = mValues;
			{
				for (int i = 0; i < n; i++)
				{
					values[i] = null;
				}
			}
			mSize = 0;
			mGarbage = false;
		}

		/// <summary>
		/// Puts a key/value pair into the array, optimizing for the case where
		/// the key is greater than all existing keys in the array.
		/// </summary>
		/// <remarks>
		/// Puts a key/value pair into the array, optimizing for the case where
		/// the key is greater than all existing keys in the array.
		/// </remarks>
		public virtual void append(int key, E value)
		{
			if (mSize != 0 && key <= mKeys[mSize - 1])
			{
				put(key, value);
				return;
			}
			if (mGarbage && mSize >= mKeys.Length)
			{
				gc();
			}
			int pos = mSize;
			if (pos >= mKeys.Length)
			{
				int n = android.util.@internal.ArrayUtils.idealIntArraySize(pos + 1);
				int[] nkeys = new int[n];
				object[] nvalues = new object[n];
				// Log.e("SparseArray", "grow " + mKeys.length + " to " + n);
				System.Array.Copy(mKeys, 0, nkeys, 0, mKeys.Length);
				System.Array.Copy(mValues, 0, nvalues, 0, mValues.Length);
				mKeys = nkeys;
				mValues = nvalues;
			}
			mKeys[pos] = key;
			mValues[pos] = value;
			mSize = pos + 1;
		}

		private static int binarySearch(int[] a, int start, int len, int key)
		{
			int high = start + len;
			int low = start - 1;
			int guess;
			while (high - low > 1)
			{
				guess = (high + low) / 2;
				if (a[guess] < key)
				{
					low = guess;
				}
				else
				{
					high = guess;
				}
			}
			if (high == start + len)
			{
				return ~(start + len);
			}
			else
			{
				if (a[high] == key)
				{
					return high;
				}
				else
				{
					return ~high;
				}
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
