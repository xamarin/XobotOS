using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Instances of classes that implement this interface can be used with
	/// the enhanced for loop.
	/// </summary>
	/// <remarks>
	/// Instances of classes that implement this interface can be used with
	/// the enhanced for loop.
	/// </remarks>
	/// <since>1.5</since>
	[Sharpen.Sharpened]
	public interface Iterable<T>
	{
		/// <summary>
		/// Returns an
		/// <see cref="java.util.Iterator{E}">java.util.Iterator&lt;E&gt;</see>
		/// for the elements in this object.
		/// </summary>
		/// <returns>
		/// An
		/// <code>Iterator</code>
		/// instance.
		/// </returns>
		java.util.Iterator<T> iterator();
	}
}
