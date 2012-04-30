namespace java.util
{
	partial class TreeSet<E>
	{
		/// <summary>
		/// Returns a new
		/// <code>TreeSet</code>
		/// with the same elements, size and comparator
		/// as this
		/// <code>TreeSet</code>
		/// .
		/// </summary>
		/// <returns>
		/// a shallow copy of this
		/// <code>TreeSet</code>
		/// .
		/// </returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		public virtual object clone()
		{
			java.util.TreeSet<E> clone_1 = (java.util.TreeSet<E>)base.MemberwiseClone();
			if (backingMap is java.util.TreeMap<E, object>)
			{
				clone_1.backingMap = (java.util.NavigableMap<E, object>)((java.util.TreeMap<E, object
					>)backingMap).clone();
			}
			else
			{
				clone_1.backingMap = new java.util.TreeMap<E, object>(backingMap);
			}
			return clone_1;
		}
	}
}

