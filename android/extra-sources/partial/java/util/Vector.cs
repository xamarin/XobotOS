using System;

namespace java.util
{
	partial class Vector<E>
	{
		/// <summary>
		/// Constructs a new vector using the specified capacity and capacity
		/// increment.
		/// </summary>
		/// <remarks>
		/// Constructs a new vector using the specified capacity and capacity
		/// increment.
		/// </remarks>
		/// <param name="capacity">the initial capacity of the new vector.</param>
		/// <param name="capacityIncrement">the amount to increase the capacity when this vector is full.
		/// 	</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity</code>
		/// is negative.
		/// </exception>
		public Vector(int capacity_1, int capacityIncrement)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			elementData = new object[capacity_1];
			elementCount = 0;
			this.capacityIncrement = capacityIncrement;
		}

		private object[] newElementArray(int size_1)
		{
			return new object[size_1];
		}
	}
}

