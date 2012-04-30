using Sharpen;

namespace android.os
{
	/// <summary>A mapping from String values to various Parcelable types.</summary>
	/// <remarks>A mapping from String values to various Parcelable types.</remarks>
	[Sharpen.Sharpened]
	public sealed partial class Bundle : android.os.Parcelable, System.ICloneable
	{
		internal const string LOG_TAG = "Bundle";

		public static readonly android.os.Bundle EMPTY;

		static Bundle()
		{
			EMPTY = new android.os.Bundle();
			EMPTY.mMap = java.util.Collections.unmodifiableMap<string, object>(new java.util.HashMap
				<string, object>());
		}

		internal java.util.Map<string, object> mMap = null;

		internal android.os.Parcel mParcelledData = null;

		private bool mHasFds = false;

		private bool mFdsKnown = true;

		private bool mAllowFds = true;

		/// <summary>The ClassLoader used when unparcelling data from mParcelledData.</summary>
		/// <remarks>The ClassLoader used when unparcelling data from mParcelledData.</remarks>
		private java.lang.ClassLoader mClassLoader;

		/// <summary>Constructs a new, empty Bundle.</summary>
		/// <remarks>Constructs a new, empty Bundle.</remarks>
		public Bundle()
		{
			// Invariant - exactly one of mMap / mParcelledData will be null
			// (except inside a call to unparcel)
			mMap = new java.util.HashMap<string, object>();
			mClassLoader = XobotOS.Runtime.Reflection.GetClassLoader(GetType());
		}

		/// <summary>Constructs a Bundle whose data is stored as a Parcel.</summary>
		/// <remarks>
		/// Constructs a Bundle whose data is stored as a Parcel.  The data
		/// will be unparcelled on first contact, using the assigned ClassLoader.
		/// </remarks>
		/// <param name="parcelledData">a Parcel containing a Bundle</param>
		internal Bundle(android.os.Parcel parcelledData)
		{
			readFromParcel(parcelledData);
		}

		internal Bundle(android.os.Parcel parcelledData, int length)
		{
			readFromParcelInner(parcelledData, length);
		}

		/// <summary>
		/// Constructs a new, empty Bundle that uses a specific ClassLoader for
		/// instantiating Parcelable and Serializable objects.
		/// </summary>
		/// <remarks>
		/// Constructs a new, empty Bundle that uses a specific ClassLoader for
		/// instantiating Parcelable and Serializable objects.
		/// </remarks>
		/// <param name="loader">
		/// An explicit ClassLoader to use when instantiating objects
		/// inside of the Bundle.
		/// </param>
		public Bundle(java.lang.ClassLoader loader)
		{
			mMap = new java.util.HashMap<string, object>();
			mClassLoader = loader;
		}

		/// <summary>
		/// Constructs a new, empty Bundle sized to hold the given number of
		/// elements.
		/// </summary>
		/// <remarks>
		/// Constructs a new, empty Bundle sized to hold the given number of
		/// elements. The Bundle will grow as needed.
		/// </remarks>
		/// <param name="capacity">the initial capacity of the Bundle</param>
		public Bundle(int capacity)
		{
			mMap = new java.util.HashMap<string, object>(capacity);
			mClassLoader = XobotOS.Runtime.Reflection.GetClassLoader(GetType());
		}

		/// <summary>
		/// Constructs a Bundle containing a copy of the mappings from the given
		/// Bundle.
		/// </summary>
		/// <remarks>
		/// Constructs a Bundle containing a copy of the mappings from the given
		/// Bundle.
		/// </remarks>
		/// <param name="b">a Bundle to be copied.</param>
		public Bundle(android.os.Bundle b)
		{
			if (b.mParcelledData != null)
			{
				mParcelledData = android.os.Parcel.obtain();
				mParcelledData.appendFrom(b.mParcelledData, 0, b.mParcelledData.dataSize());
				mParcelledData.setDataPosition(0);
			}
			else
			{
				mParcelledData = null;
			}
			if (b.mMap != null)
			{
				mMap = new java.util.HashMap<string, object>(b.mMap);
			}
			else
			{
				mMap = null;
			}
			mHasFds = b.mHasFds;
			mFdsKnown = b.mFdsKnown;
			mClassLoader = b.mClassLoader;
		}

		/// <summary>Make a Bundle for a single key/value pair.</summary>
		/// <remarks>Make a Bundle for a single key/value pair.</remarks>
		/// <hide></hide>
		public static android.os.Bundle forPair(string key, string value)
		{
			// TODO: optimize this case.
			android.os.Bundle b = new android.os.Bundle(1);
			b.putString(key, value);
			return b;
		}

		/// <summary>
		/// TODO: optimize this later (getting just the value part of a Bundle
		/// with a single pair) once Bundle.forPair() above is implemented
		/// with a special single-value Map implementation/serialization.
		/// </summary>
		/// <remarks>
		/// TODO: optimize this later (getting just the value part of a Bundle
		/// with a single pair) once Bundle.forPair() above is implemented
		/// with a special single-value Map implementation/serialization.
		/// Note: value in single-pair Bundle may be null.
		/// </remarks>
		/// <hide></hide>
		public string getPairValue()
		{
			unparcel();
			int size_1 = mMap.size();
			if (size_1 > 1)
			{
				android.util.Log.w(LOG_TAG, "getPairValue() used on Bundle with multiple pairs.");
			}
			if (size_1 == 0)
			{
				return null;
			}
			object o = mMap.values().iterator().next();
			try
			{
				return (string)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning("getPairValue()", o, "String", e);
				return null;
			}
		}

		/// <summary>Changes the ClassLoader this Bundle uses when instantiating objects.</summary>
		/// <remarks>Changes the ClassLoader this Bundle uses when instantiating objects.</remarks>
		/// <param name="loader">
		/// An explicit ClassLoader to use when instantiating objects
		/// inside of the Bundle.
		/// </param>
		public void setClassLoader(java.lang.ClassLoader loader)
		{
			mClassLoader = loader;
		}

		/// <summary>Return the ClassLoader currently associated with this Bundle.</summary>
		/// <remarks>Return the ClassLoader currently associated with this Bundle.</remarks>
		public java.lang.ClassLoader getClassLoader()
		{
			return mClassLoader;
		}

		/// <hide></hide>
		public bool setAllowFds(bool allowFds)
		{
			bool orig = mAllowFds;
			mAllowFds = allowFds;
			return orig;
		}

		/// <summary>Clones the current Bundle.</summary>
		/// <remarks>
		/// Clones the current Bundle. The internal map is cloned, but the keys and
		/// values to which it refers are copied by reference.
		/// </remarks>
		public object clone()
		{
			return new android.os.Bundle(this);
		}

		/// <summary>Returns the number of mappings contained in this Bundle.</summary>
		/// <remarks>Returns the number of mappings contained in this Bundle.</remarks>
		/// <returns>the number of mappings as an int.</returns>
		public int size()
		{
			unparcel();
			return mMap.size();
		}

		/// <summary>Returns true if the mapping of this Bundle is empty, false otherwise.</summary>
		/// <remarks>Returns true if the mapping of this Bundle is empty, false otherwise.</remarks>
		public bool isEmpty()
		{
			unparcel();
			return mMap.isEmpty();
		}

		/// <summary>Removes all elements from the mapping of this Bundle.</summary>
		/// <remarks>Removes all elements from the mapping of this Bundle.</remarks>
		public void clear()
		{
			unparcel();
			mMap.clear();
			mHasFds = false;
			mFdsKnown = true;
		}

		/// <summary>
		/// Returns true if the given key is contained in the mapping
		/// of this Bundle.
		/// </summary>
		/// <remarks>
		/// Returns true if the given key is contained in the mapping
		/// of this Bundle.
		/// </remarks>
		/// <param name="key">a String key</param>
		/// <returns>true if the key is part of the mapping, false otherwise</returns>
		public bool containsKey(string key)
		{
			unparcel();
			return mMap.containsKey(key);
		}

		/// <summary>Returns the entry with the given key as an object.</summary>
		/// <remarks>Returns the entry with the given key as an object.</remarks>
		/// <param name="key">a String key</param>
		/// <returns>an Object, or null</returns>
		public object get(string key)
		{
			unparcel();
			return mMap.get(key);
		}

		/// <summary>Removes any entry with the given key from the mapping of this Bundle.</summary>
		/// <remarks>Removes any entry with the given key from the mapping of this Bundle.</remarks>
		/// <param name="key">a String key</param>
		public void remove(string key)
		{
			unparcel();
			mMap.remove(key);
		}

		/// <summary>Inserts all mappings from the given Bundle into this Bundle.</summary>
		/// <remarks>Inserts all mappings from the given Bundle into this Bundle.</remarks>
		/// <param name="map">a Bundle</param>
		public void putAll(android.os.Bundle map)
		{
			unparcel();
			map.unparcel();
			mMap.putAll(map.mMap);
			// fd state is now known if and only if both bundles already knew
			mHasFds |= map.mHasFds;
			mFdsKnown = mFdsKnown && map.mFdsKnown;
		}

		/// <summary>Returns a Set containing the Strings used as keys in this Bundle.</summary>
		/// <remarks>Returns a Set containing the Strings used as keys in this Bundle.</remarks>
		/// <returns>a Set of String keys</returns>
		public java.util.Set<string> keySet()
		{
			unparcel();
			return mMap.keySet();
		}

		/// <summary>Reports whether the bundle contains any parcelled file descriptors.</summary>
		/// <remarks>Reports whether the bundle contains any parcelled file descriptors.</remarks>
		public bool hasFileDescriptors()
		{
			if (!mFdsKnown)
			{
				bool fdFound = false;
				// keep going until we find one or run out of data
				if (mParcelledData != null)
				{
					if (mParcelledData.hasFileDescriptors())
					{
						fdFound = true;
					}
				}
				else
				{
					// It's been unparcelled, so we need to walk the map
					java.util.Iterator<java.util.MapClass.Entry<string, object>> iter = mMap.entrySet
						().iterator();
					while (!fdFound && iter.hasNext())
					{
						object obj = iter.next().getValue();
						if (obj is android.os.Parcelable)
						{
							if ((((android.os.Parcelable)obj).describeContents() & android.os.ParcelableClass.CONTENTS_FILE_DESCRIPTOR
								) != 0)
							{
								fdFound = true;
								break;
							}
						}
						else
						{
							if (obj is android.os.Parcelable[])
							{
								android.os.Parcelable[] array = (android.os.Parcelable[])obj;
								{
									for (int n = array.Length - 1; n >= 0; n--)
									{
										if ((array[n].describeContents() & android.os.ParcelableClass.CONTENTS_FILE_DESCRIPTOR
											) != 0)
										{
											fdFound = true;
											break;
										}
									}
								}
							}
							else
							{
								if (obj is android.util.SparseArray<object>)
								{
									android.util.SparseArray<android.os.Parcelable> array = (android.util.SparseArray
										<android.os.Parcelable>)obj;
									{
										for (int n = array.size() - 1; n >= 0; n--)
										{
											if ((array.get(n).describeContents() & android.os.ParcelableClass.CONTENTS_FILE_DESCRIPTOR
												) != 0)
											{
												fdFound = true;
												break;
											}
										}
									}
								}
								else
								{
									if (obj is java.util.ArrayList<object>)
									{
										java.util.ArrayList<object> array = (java.util.ArrayList<object>)obj;
										// an ArrayList here might contain either Strings or
										// Parcelables; only look inside for Parcelables
										if ((array.size() > 0) && (array.get(0) is android.os.Parcelable))
										{
											{
												for (int n = array.size() - 1; n >= 0; n--)
												{
													android.os.Parcelable p = (android.os.Parcelable)array.get(n);
													if (p != null && ((p.describeContents() & android.os.ParcelableClass.CONTENTS_FILE_DESCRIPTOR
														) != 0))
													{
														fdFound = true;
														break;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				mHasFds = fdFound;
				mFdsKnown = true;
			}
			return mHasFds;
		}

		/// <summary>
		/// Inserts a Boolean value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a Boolean value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a Boolean, or null</param>
		public void putBoolean(string key, bool value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a byte value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a byte value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a byte</param>
		public void putByte(string key, byte value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a char value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a char value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a char, or null</param>
		public void putChar(string key, char value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a short value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a short value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a short</param>
		public void putShort(string key, short value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts an int value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts an int value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an int, or null</param>
		public void putInt(string key, int value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a long value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a long value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a long</param>
		public void putLong(string key, long value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a float value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a float value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a float</param>
		public void putFloat(string key, float value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a double value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a double value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a double</param>
		public void putDouble(string key, double value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a String value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a String value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a String, or null</param>
		public void putString(string key, string value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a CharSequence value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a CharSequence value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a CharSequence, or null</param>
		public void putCharSequence(string key, java.lang.CharSequence value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a Parcelable value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a Parcelable value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a Parcelable object, or null</param>
		public void putParcelable(string key, android.os.Parcelable value)
		{
			unparcel();
			mMap.put(key, value);
			mFdsKnown = false;
		}

		/// <summary>
		/// Inserts an array of Parcelable values into the mapping of this Bundle,
		/// replacing any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts an array of Parcelable values into the mapping of this Bundle,
		/// replacing any existing value for the given key.  Either key or value may
		/// be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an array of Parcelable objects, or null</param>
		public void putParcelableArray(string key, android.os.Parcelable[] value)
		{
			unparcel();
			mMap.put(key, value);
			mFdsKnown = false;
		}

		/// <summary>
		/// Inserts a List of Parcelable values into the mapping of this Bundle,
		/// replacing any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a List of Parcelable values into the mapping of this Bundle,
		/// replacing any existing value for the given key.  Either key or value may
		/// be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an ArrayList of Parcelable objects, or null</param>
		public void putParcelableArrayList<_T0>(string key, java.util.ArrayList<_T0> value
			) where _T0:android.os.Parcelable
		{
			unparcel();
			mMap.put(key, value);
			mFdsKnown = false;
		}

		/// <summary>
		/// Inserts an ArrayList<Integer> value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts an ArrayList<Integer> value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an ArrayList<Integer> object, or null</param>
		public void putIntegerArrayList(string key, java.util.ArrayList<int> value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts an ArrayList<String> value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts an ArrayList<String> value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an ArrayList<String> object, or null</param>
		public void putStringArrayList(string key, java.util.ArrayList<string> value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts an ArrayList<CharSequence> value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts an ArrayList<CharSequence> value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an ArrayList<CharSequence> object, or null</param>
		public void putCharSequenceArrayList(string key, java.util.ArrayList<java.lang.CharSequence
			> value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a Serializable value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a Serializable value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a Serializable object, or null</param>
		public void putSerializable(string key, java.io.Serializable value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a boolean array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a boolean array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a boolean array object, or null</param>
		public void putBooleanArray(string key, bool[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a byte array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a byte array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a byte array object, or null</param>
		public void putByteArray(string key, byte[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a short array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a short array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a short array object, or null</param>
		public void putShortArray(string key, short[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a char array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a char array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a char array object, or null</param>
		public void putCharArray(string key, char[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts an int array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts an int array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an int array object, or null</param>
		public void putIntArray(string key, int[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a long array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a long array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a long array object, or null</param>
		public void putLongArray(string key, long[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a float array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a float array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a float array object, or null</param>
		public void putFloatArray(string key, float[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a double array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a double array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a double array object, or null</param>
		public void putDoubleArray(string key, double[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a String array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a String array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a String array object, or null</param>
		public void putStringArray(string key, string[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a CharSequence array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a CharSequence array value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a CharSequence array object, or null</param>
		public void putCharSequenceArray(string key, java.lang.CharSequence[] value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts a Bundle value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts a Bundle value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">a Bundle object, or null</param>
		public void putBundle(string key, android.os.Bundle value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Inserts an IBinder value into the mapping of this Bundle, replacing
		/// any existing value for the given key.
		/// </summary>
		/// <remarks>
		/// Inserts an IBinder value into the mapping of this Bundle, replacing
		/// any existing value for the given key.  Either key or value may be null.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="value">an IBinder object, or null</param>
		/// <hide></hide>
		[System.ObsoleteAttribute]
		public void putIBinder(string key, android.os.IBinder value)
		{
			unparcel();
			mMap.put(key, value);
		}

		/// <summary>
		/// Returns the value associated with the given key, or false if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or false if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a boolean value</returns>
		public bool getBoolean(string key)
		{
			unparcel();
			return getBoolean(key, false);
		}

		// Log a message if the value was non-null but not of the expected type
		private void typeWarning(string key, object value, string className, object defaultValue
			, System.InvalidCastException e)
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			sb.append("Key ");
			sb.append(key);
			sb.append(" expected ");
			sb.append(className);
			sb.append(" but value was a ");
			sb.append(value.GetType().FullName);
			sb.append(".  The default value ");
			sb.append(defaultValue);
			sb.append(" was returned.");
			android.util.Log.w(LOG_TAG, sb.ToString());
			android.util.Log.w(LOG_TAG, "Attempt to cast generated internal exception:", e);
		}

		private void typeWarning(string key, object value, string className, System.InvalidCastException
			 e)
		{
			typeWarning(key, value, className, "<null>", e);
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a boolean value</returns>
		public bool getBoolean(string key, bool defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (bool)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Boolean", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or (byte) 0 if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or (byte) 0 if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a byte value</returns>
		public byte getByte(string key)
		{
			unparcel();
			return getByte(key, unchecked((byte)0));
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a byte value</returns>
		public byte getByte(string key, byte defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (byte)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Byte", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or false if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or false if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a char value</returns>
		public char getChar(string key)
		{
			unparcel();
			return getChar(key, (char)0);
		}

		/// <summary>
		/// Returns the value associated with the given key, or (char) 0 if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or (char) 0 if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a char value</returns>
		public char getChar(string key, char defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (char)(char)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Character", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or (short) 0 if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or (short) 0 if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a short value</returns>
		public short getShort(string key)
		{
			unparcel();
			return getShort(key, (short)0);
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a short value</returns>
		public short getShort(string key, short defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (short)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Short", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or 0 if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or 0 if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>an int value</returns>
		public int getInt(string key)
		{
			unparcel();
			return getInt(key, 0);
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>an int value</returns>
		public int getInt(string key, int defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (int)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Integer", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or 0L if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or 0L if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a long value</returns>
		public long getLong(string key)
		{
			unparcel();
			return getLong(key, 0L);
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a long value</returns>
		public long getLong(string key, long defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (long)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Long", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or 0.0f if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or 0.0f if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a float value</returns>
		public float getFloat(string key)
		{
			unparcel();
			return getFloat(key, 0.0f);
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a float value</returns>
		public float getFloat(string key, float defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (float)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Float", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or 0.0 if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or 0.0 if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a double value</returns>
		public double getDouble(string key)
		{
			unparcel();
			return getDouble(key, 0.0);
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String</param>
		/// <returns>a double value</returns>
		public double getDouble(string key, double defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (double)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Double", defaultValue, e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a String value, or null</returns>
		public string getString(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (string)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "String", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="defaultValue">Value to return if key does not exist</param>
		/// <returns>a String value, or null</returns>
		public string getString(string key, string defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (string)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "String", e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a CharSequence value, or null</returns>
		public java.lang.CharSequence getCharSequence(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (java.lang.CharSequence)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "CharSequence", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or defaultValue if
		/// no mapping of the desired type exists for the given key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <param name="defaultValue">Value to return if key does not exist</param>
		/// <returns>a CharSequence value, or null</returns>
		public java.lang.CharSequence getCharSequence(string key, java.lang.CharSequence 
			defaultValue)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return defaultValue;
			}
			try
			{
				return (java.lang.CharSequence)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "CharSequence", e);
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a Bundle value, or null</returns>
		public android.os.Bundle getBundle(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (android.os.Bundle)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Bundle", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a Parcelable value, or null</returns>
		public T getParcelable<T>(string key) where T:android.os.Parcelable
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return default(T);
			}
			try
			{
				return (T)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Parcelable", e);
				return default(T);
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a Parcelable[] value, or null</returns>
		public android.os.Parcelable[] getParcelableArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (android.os.Parcelable[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Parcelable[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>an ArrayList<T> value, or null</returns>
		public java.util.ArrayList<T> getParcelableArrayList<T>(string key) where T:android.os.Parcelable
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (java.util.ArrayList<T>)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "ArrayList", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a Serializable value, or null</returns>
		public java.io.Serializable getSerializable(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (java.io.Serializable)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "Serializable", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>an ArrayList<String> value, or null</returns>
		public java.util.ArrayList<int> getIntegerArrayList(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (java.util.ArrayList<int>)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "ArrayList<Integer>", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>an ArrayList<String> value, or null</returns>
		public java.util.ArrayList<string> getStringArrayList(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (java.util.ArrayList<string>)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "ArrayList<String>", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>an ArrayList<CharSequence> value, or null</returns>
		public java.util.ArrayList<java.lang.CharSequence> getCharSequenceArrayList(string
			 key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (java.util.ArrayList<java.lang.CharSequence>)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "ArrayList<CharSequence>", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a boolean[] value, or null</returns>
		public bool[] getBooleanArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (bool[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "byte[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a byte[] value, or null</returns>
		public byte[] getByteArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (byte[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "byte[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a short[] value, or null</returns>
		public short[] getShortArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (short[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "short[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a char[] value, or null</returns>
		public char[] getCharArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (char[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "char[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>an int[] value, or null</returns>
		public int[] getIntArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (int[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "int[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a long[] value, or null</returns>
		public long[] getLongArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (long[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "long[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a float[] value, or null</returns>
		public float[] getFloatArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (float[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "float[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a double[] value, or null</returns>
		public double[] getDoubleArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (double[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "double[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a String[] value, or null</returns>
		public string[] getStringArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (string[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "String[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>a CharSequence[] value, or null</returns>
		public java.lang.CharSequence[] getCharSequenceArray(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (java.lang.CharSequence[])o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "CharSequence[]", e);
				return null;
			}
		}

		/// <summary>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </summary>
		/// <remarks>
		/// Returns the value associated with the given key, or null if
		/// no mapping of the desired type exists for the given key or a null
		/// value is explicitly associated with the key.
		/// </remarks>
		/// <param name="key">a String, or null</param>
		/// <returns>an IBinder value, or null</returns>
		/// <hide></hide>
		[System.ObsoleteAttribute]
		public android.os.IBinder getIBinder(string key)
		{
			unparcel();
			object o = mMap.get(key);
			if (o == null)
			{
				return null;
			}
			try
			{
				return (android.os.IBinder)o;
			}
			catch (System.InvalidCastException e)
			{
				typeWarning(key, o, "IBinder", e);
				return null;
			}
		}

		private sealed class _Creator_1573 : android.os.ParcelableClass.Creator<android.os.Bundle
			>
		{
			public _Creator_1573()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.Bundle createFromParcel(android.os.Parcel @in)
			{
				return @in.readBundle();
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.Bundle[] newArray(int size)
			{
				return new android.os.Bundle[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.os.Bundle> CREATOR
			 = new _Creator_1573();

		/// <summary>Report the nature of this Parcelable's contents</summary>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			int mask = 0;
			if (hasFileDescriptors())
			{
				mask |= android.os.ParcelableClass.CONTENTS_FILE_DESCRIPTOR;
			}
			return mask;
		}

		/// <summary>
		/// Writes the Bundle contents to a Parcel, typically in order for
		/// it to be passed through an IBinder connection.
		/// </summary>
		/// <remarks>
		/// Writes the Bundle contents to a Parcel, typically in order for
		/// it to be passed through an IBinder connection.
		/// </remarks>
		/// <param name="parcel">The parcel to copy this bundle to.</param>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel parcel, int flags)
		{
			bool oldAllowFds = parcel.pushAllowFds(mAllowFds);
			try
			{
				if (mParcelledData != null)
				{
					int length = mParcelledData.dataSize();
					parcel.writeInt(length);
					parcel.writeInt(unchecked((int)(0x4C444E42)));
					// 'B' 'N' 'D' 'L'
					parcel.appendFrom(mParcelledData, 0, length);
				}
				else
				{
					parcel.writeInt(-1);
					// dummy, will hold length
					parcel.writeInt(unchecked((int)(0x4C444E42)));
					// 'B' 'N' 'D' 'L'
					int oldPos = parcel.dataPosition();
					parcel.writeMapInternal(mMap);
					int newPos = parcel.dataPosition();
					// Backpatch length
					parcel.setDataPosition(oldPos - 8);
					int length = newPos - oldPos;
					parcel.writeInt(length);
					parcel.setDataPosition(newPos);
				}
			}
			finally
			{
				parcel.restoreAllowFds(oldAllowFds);
			}
		}

		/// <summary>
		/// Reads the Parcel contents into this Bundle, typically in order for
		/// it to be passed through an IBinder connection.
		/// </summary>
		/// <remarks>
		/// Reads the Parcel contents into this Bundle, typically in order for
		/// it to be passed through an IBinder connection.
		/// </remarks>
		/// <param name="parcel">The parcel to overwrite this bundle from.</param>
		public void readFromParcel(android.os.Parcel parcel)
		{
			int length = parcel.readInt();
			if (length < 0)
			{
				throw new java.lang.RuntimeException("Bad length in parcel: " + length);
			}
			readFromParcelInner(parcel, length);
		}

		internal void readFromParcelInner(android.os.Parcel parcel, int length)
		{
			int magic = parcel.readInt();
			if (magic != unchecked((int)(0x4C444E42)))
			{
				//noinspection ThrowableInstanceNeverThrown
				string st = android.util.Log.getStackTraceString(new java.lang.RuntimeException()
					);
				android.util.Log.e("Bundle", "readBundle: bad magic number");
				android.util.Log.e("Bundle", "readBundle: trace = " + st);
			}
			// Advance within this Parcel
			int offset = parcel.dataPosition();
			parcel.setDataPosition(offset + length);
			android.os.Parcel p = android.os.Parcel.obtain();
			p.setDataPosition(0);
			p.appendFrom(parcel, offset, length);
			p.setDataPosition(0);
			mParcelledData = p;
			mHasFds = p.hasFileDescriptors();
			mFdsKnown = true;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			lock (this)
			{
				if (mParcelledData != null)
				{
					return "Bundle[mParcelledData.dataSize=" + mParcelledData.dataSize() + "]";
				}
				return "Bundle[" + mMap.ToString() + "]";
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
