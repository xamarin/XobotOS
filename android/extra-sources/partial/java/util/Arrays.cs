using System;
using java.lang;

namespace java.util
{
	partial class Arrays
	{
		/// <summary>
		/// Checks that the range described by
		/// <code>offset</code>
		/// and
		/// <code>count</code>
		/// doesn't exceed
		/// <code>arrayLength</code>
		/// .
		/// </summary>
		/// <hide></hide>
		public static void checkOffsetAndCount (int arrayLength, int offset, int count)
		{
			if ((offset | count) < 0 || offset > arrayLength || arrayLength - offset < count) {
				throw new IndexOutOfRangeException ();
			}
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
		/// <param name="newType">the class of the new array</param>
		/// <returns>the new array</returns>
		/// <exception cref="java.lang.NegativeArraySizeException">
		/// if
		/// <code>newLength &lt; 0</code>
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
		internal static T[] copyOf<T, U> (U[] original, int newLength)
		{
			Type newType = typeof(T[]);
			if (newLength < 0) {
				throw new NegativeArraySizeException ();
			}
			return copyOfRange<T, U> (original, 0, newLength);
		}


	}
}

