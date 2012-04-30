using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>Comparator</code>
	/// is used to compare two objects to determine their ordering with
	/// respect to each other. On a given
	/// <code>Collection</code>
	/// , a
	/// <code>Comparator</code>
	/// can be used to
	/// obtain a sorted
	/// <code>Collection</code>
	/// which is <i>totally ordered</i>. For a
	/// <code>Comparator</code>
	/// to be <i>consistent with equals</i>, its {code #compare(Object, Object)}
	/// method has to return zero for each pair of elements (a,b) where a.equals(b)
	/// holds true. It is recommended that a
	/// <code>Comparator</code>
	/// implements
	/// <see cref="java.io.Serializable">java.io.Serializable</see>
	/// .
	/// </summary>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public interface Comparator<T>
	{
		/// <summary>Compares the two specified objects to determine their relative ordering.
		/// 	</summary>
		/// <remarks>
		/// Compares the two specified objects to determine their relative ordering. The ordering
		/// implied by the return value of this method for all possible pairs of
		/// <code>(lhs, rhs)</code>
		/// should form an <i>equivalence relation</i>.
		/// This means that
		/// <ul>
		/// <li>
		/// <code>compare(a,a)</code>
		/// returns zero for all
		/// <code>a</code>
		/// </li>
		/// <li>the sign of
		/// <code>compare(a,b)</code>
		/// must be the opposite of the sign of
		/// <code>compare(b,a)</code>
		/// for all pairs of (a,b)</li>
		/// <li>From
		/// <code>compare(a,b) &gt; 0</code>
		/// and
		/// <code>compare(b,c) &gt; 0</code>
		/// it must
		/// follow
		/// <code>compare(a,c) &gt; 0</code>
		/// for all possible combinations of
		/// <code>(a,b,c)</code>
		/// </li>
		/// </ul>
		/// </remarks>
		/// <param name="lhs">
		/// an
		/// <code>Object</code>
		/// .
		/// </param>
		/// <param name="rhs">
		/// a second
		/// <code>Object</code>
		/// to compare with
		/// <code>lhs</code>
		/// .
		/// </param>
		/// <returns>
		/// an integer &lt; 0 if
		/// <code>lhs</code>
		/// is less than
		/// <code>rhs</code>
		/// , 0 if they are
		/// equal, and &gt; 0 if
		/// <code>lhs</code>
		/// is greater than
		/// <code>rhs</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidCastException">if objects are not of the correct type.
		/// 	</exception>
		int compare(T lhs, T rhs);

		/// <summary>
		/// Compares this
		/// <code>Comparator</code>
		/// with the specified
		/// <code>Object</code>
		/// and indicates whether they
		/// are equal. In order to be equal,
		/// <code>object</code>
		/// must represent the same object
		/// as this instance using a class-specific comparison.
		/// <p>
		/// A
		/// <code>Comparator</code>
		/// never needs to override this method, but may choose so for
		/// performance reasons.
		/// </summary>
		/// <param name="object">
		/// the
		/// <code>Object</code>
		/// to compare with this comparator.
		/// </param>
		/// <returns>
		/// boolean
		/// <code>true</code>
		/// if specified
		/// <code>Object</code>
		/// is the same as this
		/// <code>Object</code>
		/// , and
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="object.GetHashCode()">object.GetHashCode()</seealso>
		/// <seealso cref="object.Equals(object)">object.Equals(object)</seealso>
		bool Equals(object @object);
	}
}
