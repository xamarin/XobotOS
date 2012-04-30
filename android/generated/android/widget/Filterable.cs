using Sharpen;

namespace android.widget
{
	/// <summary><p>Defines a filterable behavior.</summary>
	/// <remarks>
	/// <p>Defines a filterable behavior. A filterable class can have its data
	/// constrained by a filter. Filterable classes are usually
	/// <see cref="Adapter">Adapter</see>
	/// implementations.</p>
	/// </remarks>
	/// <seealso cref="Filter">Filter</seealso>
	[Sharpen.Sharpened]
	public interface Filterable
	{
		/// <summary>
		/// <p>Returns a filter that can be used to constrain data with a filtering
		/// pattern.</p>
		/// <p>This method is usually implemented by
		/// <see cref="Adapter">Adapter</see>
		/// classes.</p>
		/// </summary>
		/// <returns>a filter used to constrain data</returns>
		android.widget.Filter getFilter();
	}
}
