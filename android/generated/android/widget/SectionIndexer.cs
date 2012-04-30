using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Interface that should be implemented on Adapters to enable fast scrolling
	/// in an
	/// <see cref="AbsListView">AbsListView</see>
	/// between sections of the list. A section is a group of list items
	/// to jump to that have something in common. For example, they may begin with the
	/// same letter or they may be songs from the same artist.
	/// </summary>
	[Sharpen.Sharpened]
	public interface SectionIndexer
	{
		/// <summary>This provides the list view with an array of section objects.</summary>
		/// <remarks>
		/// This provides the list view with an array of section objects. In the simplest
		/// case these are Strings, each containing one letter of the alphabet.
		/// They could be more complex objects that indicate the grouping for the adapter's
		/// consumption. The list view will call toString() on the objects to get the
		/// preview letter to display while scrolling.
		/// </remarks>
		/// <returns>the array of objects that indicate the different sections of the list.</returns>
		object[] getSections();

		/// <summary>Provides the starting index in the list for a given section.</summary>
		/// <remarks>Provides the starting index in the list for a given section.</remarks>
		/// <param name="section">the index of the section to jump to.</param>
		/// <returns>
		/// the starting position of that section. If the section is out of bounds, the
		/// position must be clipped to fall within the size of the list.
		/// </returns>
		int getPositionForSection(int section);

		/// <summary>
		/// This is a reverse mapping to fetch the section index for a given position
		/// in the list.
		/// </summary>
		/// <remarks>
		/// This is a reverse mapping to fetch the section index for a given position
		/// in the list.
		/// </remarks>
		/// <param name="position">the position for which to return the section</param>
		/// <returns>
		/// the section index. If the position is out of bounds, the section index
		/// must be clipped to fall within the size of the section array.
		/// </returns>
		int getSectionForPosition(int position);
	}
}
