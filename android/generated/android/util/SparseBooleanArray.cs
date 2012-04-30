using Sharpen;

namespace android.util
{
	/// <summary>SparseBooleanArrays map integers to booleans.</summary>
	/// <remarks>
	/// SparseBooleanArrays map integers to booleans.
	/// Unlike a normal array of booleans
	/// there can be gaps in the indices.  It is intended to be more efficient
	/// than using a HashMap to map Integers to Booleans.
	/// </remarks>
	[Sharpen.Sharpened]
	public class SparseBooleanArray : System.ICloneable
	{
		/// <summary>Creates a new SparseBooleanArray containing no mappings.</summary>
		/// <remarks>Creates a new SparseBooleanArray containing no mappings.</remarks>
		public SparseBooleanArray() : this(10)
		{
		}

		/// <summary>
		/// Creates a new SparseBooleanArray containing no mappings that will not
		/// require any additional memory allocation to store the specified
		/// number of mappings.
		/// </summary>
		/// <remarks>
		/// Creates a new SparseBooleanArray containing no mappings that will not
		/// require any additional memory allocation to store the specified
		/// number of mappings.
		/// </remarks>
		public SparseBooleanArray(int initialCapacity)
		{
			initialCapacity = android.util.@internal.ArrayUtils.idealIntArraySize(initialCapacity
				);
			mKeys = new int[initialCapacity];
			mValues = new bool[initialCapacity];
			mSize = 0;
		}

		public virtual android.util.SparseBooleanArray clone()
		{
			android.util.SparseBooleanArray clone_1 = null;
			clone_1 = (android.util.SparseBooleanArray)base.MemberwiseClone();
			clone_1.mKeys = (int[])mKeys.Clone();
			clone_1.mValues = (bool[])mValues.Clone();
			return clone_1;
		}

		/// <summary>
		/// Gets the boolean mapped from the specified key, or <code>false</code>
		/// if no such mapping has been made.
		/// </summary>
		/// <remarks>
		/// Gets the boolean mapped from the specified key, or <code>false</code>
		/// if no such mapping has been made.
		/// </remarks>
		public virtual bool get(int key)
		{
			return get(key, false);
		}

		/// <summary>
		/// Gets the boolean mapped from the specified key, or the specified value
		/// if no such mapping has been made.
		/// </summary>
		/// <remarks>
		/// Gets the boolean mapped from the specified key, or the specified value
		/// if no such mapping has been made.
		/// </remarks>
		public virtual bool get(int key, bool valueIfKeyNotFound)
		{
			int i = binarySearch(mKeys, 0, mSize, key);
			if (i < 0)
			{
				return valueIfKeyNotFound;
			}
			else
			{
				return mValues[i];
			}
		}

		/// <summary>Removes the mapping from the specified key, if there was any.</summary>
		/// <remarks>Removes the mapping from the specified key, if there was any.</remarks>
		public virtual void delete(int key)
		{
			int i = binarySearch(mKeys, 0, mSize, key);
			if (i >= 0)
			{
				System.Array.Copy(mKeys, i + 1, mKeys, i, mSize - (i + 1));
				System.Array.Copy(mValues, i + 1, mValues, i, mSize - (i + 1));
				mSize--;
			}
		}

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
		public virtual void put(int key, bool value)
		{
			int i = binarySearch(mKeys, 0, mSize, key);
			if (i >= 0)
			{
				mValues[i] = value;
			}
			else
			{
				i = ~i;
				if (mSize >= mKeys.Length)
				{
					int n = android.util.@internal.ArrayUtils.idealIntArraySize(mSize + 1);
					int[] nkeys = new int[n];
					bool[] nvalues = new bool[n];
					// Log.e("SparseBooleanArray", "grow " + mKeys.length + " to " + n);
					System.Array.Copy(mKeys, 0, nkeys, 0, mKeys.Length);
					System.Array.Copy(mValues, 0, nvalues, 0, mValues.Length);
					mKeys = nkeys;
					mValues = nvalues;
				}
				if (mSize - i != 0)
				{
					// Log.e("SparseBooleanArray", "move " + (mSize - i));
					System.Array.Copy(mKeys, i, mKeys, i + 1, mSize - i);
					System.Array.Copy(mValues, i, mValues, i + 1, mSize - i);
				}
				mKeys[i] = key;
				mValues[i] = value;
				mSize++;
			}
		}

		/// <summary>
		/// Returns the number of key-value mappings that this SparseBooleanArray
		/// currently stores.
		/// </summary>
		/// <remarks>
		/// Returns the number of key-value mappings that this SparseBooleanArray
		/// currently stores.
		/// </remarks>
		public virtual int size()
		{
			return mSize;
		}

		/// <summary>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the key from the <code>index</code>th key-value mapping that this
		/// SparseBooleanArray stores.
		/// </summary>
		/// <remarks>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the key from the <code>index</code>th key-value mapping that this
		/// SparseBooleanArray stores.
		/// </remarks>
		public virtual int keyAt(int index)
		{
			return mKeys[index];
		}

		/// <summary>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the value from the <code>index</code>th key-value mapping that this
		/// SparseBooleanArray stores.
		/// </summary>
		/// <remarks>
		/// Given an index in the range <code>0...size()-1</code>, returns
		/// the value from the <code>index</code>th key-value mapping that this
		/// SparseBooleanArray stores.
		/// </remarks>
		public virtual bool valueAt(int index)
		{
			return mValues[index];
		}

		/// <summary>
		/// Returns the index for which
		/// <see cref="keyAt(int)">keyAt(int)</see>
		/// would return the
		/// specified key, or a negative number if the specified
		/// key is not mapped.
		/// </summary>
		public virtual int indexOfKey(int key)
		{
			return binarySearch(mKeys, 0, mSize, key);
		}

		/// <summary>
		/// Returns an index for which
		/// <see cref="valueAt(int)">valueAt(int)</see>
		/// would return the
		/// specified key, or a negative number if no keys map to the
		/// specified value.
		/// Beware that this is a linear search, unlike lookups by key,
		/// and that multiple keys can map to the same value and this will
		/// find only one of them.
		/// </summary>
		public virtual int indexOfValue(bool value)
		{
			{
				for (int i = 0; i < mSize; i++)
				{
					if (mValues[i] == value)
					{
						return i;
					}
				}
			}
			return -1;
		}

		/// <summary>Removes all key-value mappings from this SparseBooleanArray.</summary>
		/// <remarks>Removes all key-value mappings from this SparseBooleanArray.</remarks>
		public virtual void clear()
		{
			mSize = 0;
		}

		/// <summary>
		/// Puts a key/value pair into the array, optimizing for the case where
		/// the key is greater than all existing keys in the array.
		/// </summary>
		/// <remarks>
		/// Puts a key/value pair into the array, optimizing for the case where
		/// the key is greater than all existing keys in the array.
		/// </remarks>
		public virtual void append(int key, bool value)
		{
			if (mSize != 0 && key <= mKeys[mSize - 1])
			{
				put(key, value);
				return;
			}
			int pos = mSize;
			if (pos >= mKeys.Length)
			{
				int n = android.util.@internal.ArrayUtils.idealIntArraySize(pos + 1);
				int[] nkeys = new int[n];
				bool[] nvalues = new bool[n];
				// Log.e("SparseBooleanArray", "grow " + mKeys.length + " to " + n);
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

		private int[] mKeys;

		private bool[] mValues;

		private int mSize;

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
