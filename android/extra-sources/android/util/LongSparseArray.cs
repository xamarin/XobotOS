using System;
using Sharpen;

namespace android.util
{
	/// <summary>SparseArrays map longs to Objects.</summary>
	/// <remarks>
	/// SparseArrays map longs to Objects.  Unlike a normal array of Objects,
	/// there can be gaps in the indices.  It is intended to be more efficient
	/// than using a HashMap to map Longs to Objects.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class LongSparseArray<E>
	{
		private struct Entry
		{
			public bool IsDeleted;
			public E Value;

			public Entry (E value)
			{
				this.Value = value;
				this.IsDeleted = false;
			}
		}

		private bool mGarbage = false;

		/// <summary>Creates a new SparseArray containing no mappings.</summary>
		/// <remarks>Creates a new SparseArray containing no mappings.</remarks>
		public LongSparseArray () : this(10)
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
		public LongSparseArray (int initialCapacity)
		{
			initialCapacity = android.util.@internal.ArrayUtils.idealIntArraySize (initialCapacity
				);
			mKeys = new long[initialCapacity];
			mValues = new Entry[initialCapacity];
			mSize = 0;
		}

		/// <returns>A copy of all keys contained in the sparse array.</returns>
		public virtual long[] getKeys ()
		{
			int length = mKeys.Length;
			long[] result = new long[length];
			System.Array.Copy (mKeys, 0, result, 0, length);
			return result;
		}

		/// <summary>Sets all supplied keys to the given unique value.</summary>
		/// <remarks>Sets all supplied keys to the given unique value.</remarks>
		/// <param name="keys">Keys to set</param>
		/// <param name="uniqueValue">Value to set all supplied keys to</param>
		public virtual void setValues (long[] keys, E uniqueValue)
		{
			int length = keys.Length;
			{
				for (int i = 0; i < length; i++) {
					put (keys [i], uniqueValue);
				}
			}
		}

		/// <summary>
		/// Gets the Object mapped from the specified key, or <code>null</code>
		/// if no such mapping has been made.
		/// </summary>
		/// <remarks>
		/// Gets the Object mapped from the specified key, or <code>null</code>
		/// if no such mapping has been made.
		/// </remarks>
		public virtual E get (long key)
		{
			return get (key, default (E));
		}

		/// <summary>
		/// Gets the Object mapped from the specified key, or the specified Object
		/// if no such mapping has been made.
		/// </summary>
		/// <remarks>
		/// Gets the Object mapped from the specified key, or the specified Object
		/// if no such mapping has been made.
		/// </remarks>
		public virtual E get (long key, E valueIfKeyNotFound)
		{
			int i = binarySearch (mKeys, 0, mSize, key);
			if (i < 0 || mValues [i].IsDeleted) {
				return valueIfKeyNotFound;
			} else {
				return mValues [i].Value;
			}
		}

		/// <summary>Removes the mapping from the specified key, if there was any.</summary>
		/// <remarks>Removes the mapping from the specified key, if there was any.</remarks>
		public virtual void delete (long key)
		{
			int i = binarySearch (mKeys, 0, mSize, key);
			if (i >= 0) {
				if (!mValues [i].IsDeleted) {
					mValues [i].IsDeleted = true;
					mGarbage = true;
				}
			}
		}

		/// <summary>
		/// Alias for
		/// <see cref="LongSparseArray{E}.delete(long)">LongSparseArray&lt;E&gt;.delete(long)
		/// 	</see>
		/// .
		/// </summary>
		public virtual void remove (long key)
		{
			delete (key);
		}

		private void gc ()
		{
			// Log.e("SparseArray", "gc start with " + mSize);
			int n = mSize;
			int o = 0;
			long[] keys = mKeys;
			Entry[] values = mValues;
			{
				for (int i = 0; i < n; i++) {
					Entry val = values [i];
					if (!val.IsDeleted) {
						if (i != o) {
							keys [o] = keys [i];
							values [o] = val;
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
		public virtual void put (long key, E value)
		{
			int i = binarySearch (mKeys, 0, mSize, key);
			if (i >= 0) {
				mValues [i] = new Entry (value);
			} else {
				i = ~i;
				if (i < mSize && mValues [i].IsDeleted) {
					mKeys [i] = key;
					mValues [i] = new Entry (value);
					return;
				}
				if (mGarbage && mSize >= mKeys.Length) {
					gc ();
					// Search again because indices may have changed.
					i = ~binarySearch (mKeys, 0, mSize, key);
				}
				if (mSize >= mKeys.Length) {
					int n = android.util.@internal.ArrayUtils.idealIntArraySize (mSize + 1);
					long[] nkeys = new long[n];
					Entry[] nvalues = new Entry[n];
					// Log.e("SparseArray", "grow " + mKeys.length + " to " + n);
					System.Array.Copy (mKeys, 0, nkeys, 0, mKeys.Length);
					System.Array.Copy (mValues, 0, nvalues, 0, mValues.Length);
					mKeys = nkeys;
					mValues = nvalues;
				}
				if (mSize - i != 0) {
					// Log.e("SparseArray", "move " + (mSize - i));
					System.Array.Copy (mKeys, i, mKeys, i + 1, mSize - i);
					System.Array.Copy (mValues, i, mValues, i + 1, mSize - i);
				}
				mKeys [i] = key;
				mValues [i] = new Entry (value);
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
		public virtual int size ()
		{
			if (mGarbage) {
				gc ();
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
		public virtual long keyAt (int index)
		{
			if (mGarbage) {
				gc ();
			}
			return mKeys [index];
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
		public virtual E valueAt (int index)
		{
			if (mGarbage) {
				gc ();
			}
			return mValues [index].Value;
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
		public virtual void setValueAt (int index, E value)
		{
			if (mGarbage) {
				gc ();
			}
			mValues [index].Value = value;
		}

		/// <summary>
		/// Returns the index for which
		/// <see cref="LongSparseArray{E}.keyAt(int)">LongSparseArray&lt;E&gt;.keyAt(int)</see>
		/// would return the
		/// specified key, or a negative number if the specified
		/// key is not mapped.
		/// </summary>
		public virtual int indexOfKey (long key)
		{
			if (mGarbage) {
				gc ();
			}
			return binarySearch (mKeys, 0, mSize, key);
		}

		/// <summary>
		/// Returns an index for which
		/// <see cref="LongSparseArray{E}.valueAt(int)">LongSparseArray&lt;E&gt;.valueAt(int)
		/// 	</see>
		/// would return the
		/// specified key, or a negative number if no keys map to the
		/// specified value.
		/// Beware that this is a linear search, unlike lookups by key,
		/// and that multiple keys can map to the same value and this will
		/// find only one of them.
		/// </summary>
		public virtual int indexOfValue (E value)
		{
			if (mGarbage) {
				gc ();
			}
			{
				for (int i = 0; i < mSize; i++) {
					if (mValues [i].Value.Equals (value)) {
						return i;
					}
				}
			}
			return -1;
		}

		/// <summary>Removes all key-value mappings from this SparseArray.</summary>
		/// <remarks>Removes all key-value mappings from this SparseArray.</remarks>
		public virtual void clear ()
		{
			int n = mSize;
			for (int i = 0; i < n; i++)
				mValues [i] = new Entry (default (E));
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
		public virtual void append (long key, E value)
		{
			if (mSize != 0 && key <= mKeys [mSize - 1]) {
				put (key, value);
				return;
			}
			if (mGarbage && mSize >= mKeys.Length) {
				gc ();
			}
			int pos = mSize;
			if (pos >= mKeys.Length) {
				int n = android.util.@internal.ArrayUtils.idealIntArraySize (pos + 1);
				long[] nkeys = new long[n];
				Entry[] nvalues = new Entry[n];
				// Log.e("SparseArray", "grow " + mKeys.length + " to " + n);
				System.Array.Copy (mKeys, 0, nkeys, 0, mKeys.Length);
				System.Array.Copy (mValues, 0, nvalues, 0, mValues.Length);
				mKeys = nkeys;
				mValues = nvalues;
			}
			mKeys [pos] = key;
			mValues [pos] = new Entry (value);
			mSize = pos + 1;
		}

		private static int binarySearch (long[] a, int start, int len, long key)
		{
			int high = start + len;
			int low = start - 1;
			int guess;
			while (high - low > 1) {
				guess = (high + low) / 2;
				if (a [guess] < key) {
					low = guess;
				} else {
					high = guess;
				}
			}
			if (high == start + len) {
				return ~(start + len);
			} else {
				if (a [high] == key) {
					return high;
				} else {
					return ~high;
				}
			}
		}

		private void checkIntegrity ()
		{
			{
				for (int i = 1; i < mSize; i++) {
					if (mKeys [i] <= mKeys [i - 1]) {
						{
							for (int j = 0; j < mSize; j++) {
								android.util.Log.e ("FAIL", j + ": " + mKeys [j] + " -> " + mValues [j]);
							}
						}
						throw new java.lang.RuntimeException ();
					}
				}
			}
		}

		private long[] mKeys;
		private Entry[] mValues;
		private int mSize;
	}
}
