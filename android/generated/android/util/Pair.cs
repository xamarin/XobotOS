using Sharpen;

namespace android.util
{
	/// <summary>Container to ease passing around a tuple of two objects.</summary>
	/// <remarks>
	/// Container to ease passing around a tuple of two objects. This object provides a sensible
	/// implementation of equals(), returning true if equals() is true on each of the contained
	/// objects.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Pair<F, S>
	{
		internal readonly F first;

		internal readonly S second;

		/// <summary>Constructor for a Pair.</summary>
		/// <remarks>
		/// Constructor for a Pair. If either are null then equals() and hashCode() will throw
		/// a NullPointerException.
		/// </remarks>
		/// <param name="first">the first object in the Pair</param>
		/// <param name="second">the second object in the pair</param>
		public Pair(F first, S second)
		{
			this.first = first;
			this.second = second;
		}

		/// <summary>Checks the two objects for equality by delegating to their respective equals() methods.
		/// 	</summary>
		/// <remarks>Checks the two objects for equality by delegating to their respective equals() methods.
		/// 	</remarks>
		/// <param name="o">the Pair to which this one is to be checked for equality</param>
		/// <returns>true if the underlying objects of the Pair are both considered equals()</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			if (o == this)
			{
				return true;
			}
			if (!(o is android.util.Pair<F, S>))
			{
				return false;
			}
			android.util.Pair<F, S> other;
			try
			{
				other = (android.util.Pair<F, S>)o;
			}
			catch (System.InvalidCastException)
			{
				return false;
			}
			return first.Equals(other.first) && second.Equals(other.second);
		}

		/// <summary>Compute a hash code using the hash codes of the underlying objects</summary>
		/// <returns>a hashcode of the Pair</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int result = 17;
			result = 31 * result + first.GetHashCode();
			result = 31 * result + second.GetHashCode();
			return result;
		}

		/// <summary>Convenience method for creating an appropriately typed pair.</summary>
		/// <remarks>Convenience method for creating an appropriately typed pair.</remarks>
		/// <param name="a">the first object in the Pair</param>
		/// <param name="b">the second object in the pair</param>
		/// <returns>a Pair that is templatized with the types of a and b</returns>
		public static android.util.Pair<A, B> create<A, B>(A a, B b)
		{
			return new android.util.Pair<A, B>(a, b);
		}
	}
}
