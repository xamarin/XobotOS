using Sharpen;

namespace java.util
{
	[Sharpen.Stub]
	public partial class Arrays
	{
		private static class ArrayList
		{
			internal const long serialVersionUID = -2764017481108945198L;
		}

		[System.Serializable]
		private class ArrayList<E> : java.util.AbstractList<E>, java.util.List<E>, java.util.RandomAccess
		{
			internal readonly E[] a;

			internal ArrayList(E[] storage)
			{
				if (storage == null)
				{
					throw new System.ArgumentNullException();
				}
				a = storage;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object @object)
			{
				if (@object != null)
				{
					foreach (E element in a)
					{
						if (@object.Equals(element))
						{
							return true;
						}
					}
				}
				else
				{
					foreach (E element in a)
					{
						if ((object)element == null)
						{
							return true;
						}
					}
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E get(int location)
			{
				try
				{
					return a[location];
				}
				catch (System.IndexOutOfRangeException)
				{
					throw java.util.ArrayList<E>.throwIndexOutOfBoundsException(location, a.Length);
				}
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override int indexOf(object @object)
			{
				if (@object != null)
				{
					{
						for (int i = 0; i < a.Length; i++)
						{
							if (@object.Equals(a[i]))
							{
								return i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = 0; i < a.Length; i++)
						{
							if ((object)a[i] == null)
							{
								return i;
							}
						}
					}
				}
				return -1;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override int lastIndexOf(object @object)
			{
				if (@object != null)
				{
					{
						for (int i = a.Length - 1; i >= 0; i--)
						{
							if (@object.Equals(a[i]))
							{
								return i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = a.Length - 1; i >= 0; i--)
						{
							if ((object)a[i] == null)
							{
								return i;
							}
						}
					}
				}
				return -1;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractList")]
			public override E set(int location, E @object)
			{
				E result = a[location];
				a[location] = @object;
				return result;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return a.Length;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override object[] toArray()
			{
				return (object[])a.Clone();
			}

			[Sharpen.Proxy]
			T[] java.util.Collection<E>.toArray<T>(T[] contents)
			{
				return toArray<T>(contents);
			}

			[Sharpen.Proxy]
			T[] java.util.List<E>.toArray<T>(T[] contents)
			{
				return toArray<T>(contents);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override T[] toArray<T>(T[] contents)
			{
				int size_1 = size();
				if (size_1 > contents.Length)
				{
					System.Type ct = contents.GetType().GetElementType();
					contents = (T[])System.Array.CreateInstance(ct, size_1);
				}
				System.Array.Copy(a, 0, contents, 0, size_1);
				if (size_1 < contents.Length)
				{
					contents[size_1] = default(T);
				}
				return contents;
			}
		}

		[Sharpen.Stub]
		private Arrays()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns a
		/// <code>List</code>
		/// of the objects in the specified array. The size of the
		/// <code>List</code>
		/// cannot be modified, i.e. adding and removing are unsupported, but
		/// the elements can be set. Setting an element modifies the underlying
		/// array.
		/// </summary>
		/// <param name="array">the array.</param>
		/// <returns>
		/// a
		/// <code>List</code>
		/// of the elements of the specified array.
		/// </returns>
		public static java.util.List<T> asList<T>(params T[] array)
		{
			return new java.util.Arrays.ArrayList<T>(array);
		}

		[Sharpen.Stub]
		public static int binarySearch(byte[] array, byte value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(byte[] array, int startIndex, int endIndex, byte value
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(char[] array, char value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(char[] array, int startIndex, int endIndex, char value
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(double[] array, double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(double[] array, int startIndex, int endIndex, double
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(float[] array, float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(float[] array, int startIndex, int endIndex, float
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(int[] array, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(int[] array, int startIndex, int endIndex, int value
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(long[] array, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(long[] array, int startIndex, int endIndex, long value
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(object[] array, object value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(object[] array, int startIndex, int endIndex, object
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch<T>(T[] array, T value, java.util.Comparator<T> comparator
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch<T>(T[] array, int startIndex, int endIndex, T value
			, java.util.Comparator<T> comparator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(short[] array, short value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int binarySearch(short[] array, int startIndex, int endIndex, short
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void checkBinarySearchBounds(int startIndex, int endIndex, int length
			)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>byte</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>byte</code>
		/// element.
		/// </param>
		public static void fill(byte[] array, byte value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>byte</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>byte</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(byte[] array, int start, int end, byte value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>short</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>short</code>
		/// element.
		/// </param>
		public static void fill(short[] array, short value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>short</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>short</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(short[] array, int start, int end, short value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>char</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>char</code>
		/// element.
		/// </param>
		public static void fill(char[] array, char value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>char</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>char</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(char[] array, int start, int end, char value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>int</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>int</code>
		/// element.
		/// </param>
		public static void fill(int[] array, int value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>int</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>int</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(int[] array, int start, int end, int value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>long</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>long</code>
		/// element.
		/// </param>
		public static void fill(long[] array, long value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>long</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>long</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(long[] array, int start, int end, long value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>float</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>float</code>
		/// element.
		/// </param>
		public static void fill(float[] array, float value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>float</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>float</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(float[] array, int start, int end, float value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>double</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>double</code>
		/// element.
		/// </param>
		public static void fill(double[] array, double value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>double</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>double</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(double[] array, int start, int end, double value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>boolean</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>boolean</code>
		/// element.
		/// </param>
		public static void fill(bool[] array, bool value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>boolean</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>boolean</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(bool[] array, int start, int end, bool value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified array with the specified element.</summary>
		/// <remarks>Fills the specified array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>Object</code>
		/// array to fill.
		/// </param>
		/// <param name="value">
		/// the
		/// <code>Object</code>
		/// element.
		/// </param>
		public static void fill(object[] array, object value)
		{
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		/// <summary>Fills the specified range in the array with the specified element.</summary>
		/// <remarks>Fills the specified range in the array with the specified element.</remarks>
		/// <param name="array">
		/// the
		/// <code>Object</code>
		/// array to fill.
		/// </param>
		/// <param name="start">the first index to fill.</param>
		/// <param name="end">the last + 1 index to fill.</param>
		/// <param name="value">
		/// the
		/// <code>Object</code>
		/// element.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; array.length</code>
		/// .
		/// </exception>
		public static void fill(object[] array, int start, int end, object value)
		{
			java.util.Arrays.checkStartAndEnd(array.Length, start, end);
			{
				for (int i = start; i < end; i++)
				{
					array[i] = value;
				}
			}
		}

		[Sharpen.Stub]
		public static int hashCode(bool[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(int[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(short[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(char[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(byte[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(long[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(float[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(double[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int hashCode(object[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int deepHashCode(object[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int deepHashCodeElement(object element)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>Compares the two arrays.</remarks>
		/// <param name="array1">
		/// the first
		/// <code>byte</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>byte</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public static bool equals(byte[] array1, byte[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>Compares the two arrays.</remarks>
		/// <param name="array1">
		/// the first
		/// <code>short</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>short</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public static bool equals(short[] array1, short[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>Compares the two arrays.</remarks>
		/// <param name="array1">
		/// the first
		/// <code>char</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>char</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public static bool equals(char[] array1, char[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>Compares the two arrays.</remarks>
		/// <param name="array1">
		/// the first
		/// <code>int</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>int</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public static bool equals(int[] array1, int[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>Compares the two arrays.</remarks>
		/// <param name="array1">
		/// the first
		/// <code>long</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>long</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public static bool equals(long[] array1, long[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>
		/// Compares the two arrays. The values are compared in the same manner as
		/// <code>Float.equals()</code>
		/// .
		/// </remarks>
		/// <param name="array1">
		/// the first
		/// <code>float</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>float</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="float.Equals(object)">float.Equals(object)</seealso>
		public static bool equals(float[] array1, float[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (Sharpen.Util.FloatToIntBits(array1[i]) != Sharpen.Util.FloatToIntBits(array2[
						i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>
		/// Compares the two arrays. The values are compared in the same manner as
		/// <code>Double.equals()</code>
		/// .
		/// </remarks>
		/// <param name="array1">
		/// the first
		/// <code>double</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>double</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="double.Equals(object)">double.Equals(object)</seealso>
		public static bool equals(double[] array1, double[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (Sharpen.Util.DoubleToLongBits(array1[i]) != Sharpen.Util.DoubleToLongBits(array2
						[i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>Compares the two arrays.</remarks>
		/// <param name="array1">
		/// the first
		/// <code>boolean</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>boolean</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public static bool equals(bool[] array1, bool[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Compares the two arrays.</summary>
		/// <remarks>Compares the two arrays.</remarks>
		/// <param name="array1">
		/// the first
		/// <code>Object</code>
		/// array.
		/// </param>
		/// <param name="array2">
		/// the second
		/// <code>Object</code>
		/// array.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if both arrays are
		/// <code>null</code>
		/// or if the arrays have the
		/// same length and the elements at each index in the two arrays are
		/// equal according to
		/// <code>equals()</code>
		/// ,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public static bool equals(object[] array1, object[] array2)
		{
			if (array1 == array2)
			{
				return true;
			}
			if (array1 == null || array2 == null || array1.Length != array2.Length)
			{
				return false;
			}
			{
				for (int i = 0; i < array1.Length; i++)
				{
					object e1 = array1[i];
					object e2 = array2[i];
					if (!(e1 == null ? e2 == null : e1.Equals(e2)))
					{
						return false;
					}
				}
			}
			return true;
		}

		[Sharpen.Stub]
		public static bool deepEquals(object[] array1, object[] array2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool deepEqualsElements(object e1, object e2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(byte[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(byte[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Checks that the range described by
		/// <code>start</code>
		/// and
		/// <code>end</code>
		/// doesn't exceed
		/// <code>len</code>
		/// .
		/// </summary>
		/// <hide></hide>
		public static void checkStartAndEnd(int len, int start, int end)
		{
			if (start < 0 || end > len)
			{
				throw new System.IndexOutOfRangeException("start < 0 || end > len." + " start=" +
					 start + ", end=" + end + ", len=" + len);
			}
			if (start > end)
			{
				throw new System.ArgumentException("start > end: " + start + " > " + end);
			}
		}

		[Sharpen.Stub]
		public static void sort(char[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(char[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(double[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(double[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(float[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(float[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(int[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(int[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(long[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(long[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(short[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(short[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(object[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort(object[] array, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort<T>(T[] array, int start, int end, java.util.Comparator<T>
			 comparator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void sort<T>(T[] array, java.util.Comparator<T> comparator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(bool[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(byte[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(char[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(double[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(float[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(int[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(long[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(short[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toString(object[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string deepToString(object[] array)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void deepToStringImpl(object[] array, object[] origArrays, java.lang.StringBuilder
			 sb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool deepToStringImplContains(object[] origArrays, object array)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>false</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static bool[] copyOf(bool[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>(byte) 0</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static byte[] copyOf(byte[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>'\\u0000'</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static char[] copyOf(char[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0.0d</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static double[] copyOf(double[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0.0f</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static float[] copyOf(float[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static int[] copyOf(int[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0L</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static long[] copyOf(long[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>(short) 0</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static short[] copyOf(short[] original, int newLength)
		{
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange(original, 0, newLength);
		}

		/// <summary>
		/// Copies
		/// <code>newLength</code>
		/// elements from
		/// <code>original</code>
		/// into a new array.
		/// If
		/// <code>newLength</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>null</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="newLength">the length of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static T[] copyOf<T>(T[] original, int newLength)
		{
			if (original == null)
			{
				throw new System.ArgumentNullException();
			}
			if (newLength < 0)
			{
				throw new java.lang.NegativeArraySizeException();
			}
			return copyOfRange<T>(original, 0, newLength);
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>false</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static bool[] copyOfRange(bool[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			bool[] result = new bool[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>(byte) 0</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static byte[] copyOfRange(byte[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			byte[] result = new byte[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>'\\u0000'</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static char[] copyOfRange(char[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			char[] result = new char[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0.0d</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static double[] copyOfRange(double[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			double[] result = new double[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0.0f</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static float[] copyOfRange(float[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			float[] result = new float[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static int[] copyOfRange(int[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			int[] result = new int[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>0L</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static long[] copyOfRange(long[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			long[] result = new long[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>(short) 0</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static short[] copyOfRange(short[] original, int start, int end)
		{
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			short[] result = new short[resultLength];
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>null</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <since>1.6</since>
		public static T[] copyOfRange<T>(T[] original, int start, int end)
		{
			int originalLength = original.Length;
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			T[] result = (T[])System.Array.CreateInstance(original.GetType().GetElementType()
				, resultLength);
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}

		/// <summary>
		/// Copies elements from
		/// <code>original</code>
		/// into a new array, from indexes start (inclusive) to
		/// end (exclusive). The original order of elements is preserved.
		/// If
		/// <code>end</code>
		/// is greater than
		/// <code>original.length</code>
		/// , the result is padded
		/// with the value
		/// <code>null</code>
		/// .
		/// </summary>
		/// <param name="original">the original array</param>
		/// <param name="start">the start index, inclusive</param>
		/// <param name="end">the end index, exclusive</param>
		/// <returns>the new array</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0 || start &gt; original.length</code>
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>original == null</code>
		/// </exception>
		/// <exception cref="java.lang.ArrayStoreException">
		/// if a value in
		/// <code>original</code>
		/// is incompatible with T
		/// </exception>
		/// <since>1.6</since>
		public static T[] copyOfRange<T, U>(U[] original, int start, int end)
		{
			System.Type newType = typeof(T[]);
			if (start > end)
			{
				throw new System.ArgumentException();
			}
			int originalLength = original.Length;
			if (start < 0 || start > originalLength)
			{
				throw new System.IndexOutOfRangeException();
			}
			int resultLength = end - start;
			int copyLength = System.Math.Min(resultLength, originalLength - start);
			T[] result = (T[])System.Array.CreateInstance(newType.GetElementType(), resultLength
				);
			System.Array.Copy(original, start, result, 0, copyLength);
			return result;
		}
	}
}
