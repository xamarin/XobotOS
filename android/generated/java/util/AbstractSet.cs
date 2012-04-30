using Sharpen;

namespace java.util
{
	/// <summary>An AbstractSet is an abstract implementation of the Set interface.</summary>
	/// <remarks>
	/// An AbstractSet is an abstract implementation of the Set interface. This
	/// implementation does not support adding. A subclass must implement the
	/// abstract methods iterator() and size().
	/// </remarks>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public abstract class AbstractSet<E> : java.util.AbstractCollection<E>, java.util.Set
		<E>
	{
		/// <summary>Constructs a new instance of this AbstractSet.</summary>
		/// <remarks>Constructs a new instance of this AbstractSet.</remarks>
		protected internal AbstractSet()
		{
		}

		/// <summary>
		/// Compares the specified object to this Set and returns true if they are
		/// equal.
		/// </summary>
		/// <remarks>
		/// Compares the specified object to this Set and returns true if they are
		/// equal. The object must be an instance of Set and contain the same
		/// objects.
		/// </remarks>
		/// <param name="object">the object to compare with this set.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the specified object is equal to this set,
		/// <code>false</code>
		/// otherwise
		/// </returns>
		/// <seealso cref="AbstractSet{E}.GetHashCode()">AbstractSet&lt;E&gt;.GetHashCode()</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			if (this == @object)
			{
				return true;
			}
			if (@object is java.util.Set<E>)
			{
				java.util.Set<E> s = (java.util.Set<E>)@object;
				try
				{
					return size() == s.size() && containsAll(s);
				}
				catch (System.ArgumentNullException)
				{
					return false;
				}
				catch (System.InvalidCastException)
				{
					return false;
				}
			}
			return false;
		}

		/// <summary>Returns the hash code for this set.</summary>
		/// <remarks>
		/// Returns the hash code for this set. Two set which are equal must return
		/// the same value. This implementation calculates the hash code by adding
		/// each element's hash code.
		/// </remarks>
		/// <returns>the hash code of this set.</returns>
		/// <seealso cref="AbstractSet{E}.Equals(object)">AbstractSet&lt;E&gt;.Equals(object)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int result = 0;
			java.util.Iterator<E> it = iterator();
			while (it.hasNext())
			{
				object next = it.next();
				result += next == null ? 0 : next.GetHashCode();
			}
			return result;
		}

		/// <summary>
		/// Removes all occurrences in this collection which are contained in the
		/// specified collection.
		/// </summary>
		/// <remarks>
		/// Removes all occurrences in this collection which are contained in the
		/// specified collection.
		/// </remarks>
		/// <param name="collection">the collection of objects to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this collection was modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.NotSupportedException">if removing from this collection is not supported.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool removeAll<_T0>(java.util.Collection<_T0> collection)
		{
			bool result = false;
			if (size() <= collection.size())
			{
				java.util.Iterator<E> it = iterator();
				while (it.hasNext())
				{
					if (collection.contains(it.next()))
					{
						it.remove();
						result = true;
					}
				}
			}
			else
			{
				java.util.Iterator<_T0> it = collection.iterator();
				while (it.hasNext())
				{
					result = remove(it.next()) || result;
				}
			}
			return result;
		}
	}
}
