using Sharpen;

namespace android.util.@internal
{
	/// <summary>
	/// ArrayUtils contains some methods that you can call to find out
	/// the most efficient increments by which to grow arrays.
	/// </summary>
	/// <remarks>
	/// ArrayUtils contains some methods that you can call to find out
	/// the most efficient increments by which to grow arrays.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ArrayUtils
	{
		private static object[] EMPTY = new object[0];

		internal const int CACHE_SIZE = 73;

		private static object[] sCache = new object[CACHE_SIZE];

		private ArrayUtils()
		{
		}

		// XXX these should be changed to reflect the actual memory allocator we use.
		// it looks like right now objects want to be powers of 2 minus 8
		// and the array size eats another 4 bytes
		public static int idealByteArraySize(int need)
		{
			{
				for (int i = 4; i < 32; i++)
				{
					if (need <= (1 << i) - 12)
					{
						return (1 << i) - 12;
					}
				}
			}
			return need;
		}

		public static int idealBooleanArraySize(int need)
		{
			return idealByteArraySize(need);
		}

		public static int idealShortArraySize(int need)
		{
			return idealByteArraySize(need * 2) / 2;
		}

		public static int idealCharArraySize(int need)
		{
			return idealByteArraySize(need * 2) / 2;
		}

		public static int idealIntArraySize(int need)
		{
			return idealByteArraySize(need * 4) / 4;
		}

		public static int idealFloatArraySize(int need)
		{
			return idealByteArraySize(need * 4) / 4;
		}

		public static int idealObjectArraySize(int need)
		{
			return idealByteArraySize(need * 4) / 4;
		}

		public static int idealLongArraySize(int need)
		{
			return idealByteArraySize(need * 8) / 8;
		}

		/// <summary>Checks if the beginnings of two byte arrays are equal.</summary>
		/// <remarks>Checks if the beginnings of two byte arrays are equal.</remarks>
		/// <param name="array1">the first byte array</param>
		/// <param name="array2">the second byte array</param>
		/// <param name="length">the number of bytes to check</param>
		/// <returns>true if they're equal, false otherwise</returns>
		public static bool equals(byte[] array1, byte[] array2, int length)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length < length || array2.Length <
				 length)
			{
				return false;
			}
			{
				for (int i = 0; i < length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		[Sharpen.Stub]
		public static T[] emptyArray<T>()
		{
			throw new System.NotImplementedException();
		}

		// Log.e("cache", "new empty " + kind.getName() + " at " + bucket);
		/// <summary>Checks that value is present as at least one of the elements of the array.
		/// 	</summary>
		/// <remarks>Checks that value is present as at least one of the elements of the array.
		/// 	</remarks>
		/// <param name="array">the array to check in</param>
		/// <param name="value">the value to check for</param>
		/// <returns>true if the value is present in the array</returns>
		public static bool contains<T>(T[] array, T value)
		{
			foreach (T element in array)
			{
				if ((object)element == null)
				{
					if ((object)value == null)
					{
						return true;
					}
				}
				else
				{
					if ((object)value != null && element.Equals(value))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool contains(int[] array, int value)
		{
			foreach (int element in array)
			{
				if (element == value)
				{
					return true;
				}
			}
			return false;
		}
	}
}
