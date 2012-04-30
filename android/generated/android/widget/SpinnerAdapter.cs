using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Extended
	/// <see cref="Adapter">Adapter</see>
	/// that is the bridge between a
	/// <see cref="Spinner">Spinner</see>
	/// and its data. A spinner adapter allows to
	/// define two different views: one that shows the data in the spinner itself and
	/// one that shows the data in the drop down list when the spinner is pressed.</p>
	/// </summary>
	[Sharpen.Sharpened]
	public interface SpinnerAdapter : android.widget.Adapter
	{
		/// <summary>
		/// <p>Get a
		/// <see cref="android.view.View">android.view.View</see>
		/// that displays in the drop down popup
		/// the data at the specified position in the data set.</p>
		/// </summary>
		/// <param name="position">index of the item whose view we want.</param>
		/// <param name="convertView">
		/// the old view to reuse, if possible. Note: You should
		/// check that this view is non-null and of an appropriate type before
		/// using. If it is not possible to convert this view to display the
		/// correct data, this method can create a new view.
		/// </param>
		/// <param name="parent">the parent that this view will eventually be attached to</param>
		/// <returns>
		/// a
		/// <see cref="android.view.View">android.view.View</see>
		/// corresponding to the data at the
		/// specified position.
		/// </returns>
		android.view.View getDropDownView(int position, android.view.View convertView, android.view.ViewGroup
			 parent);
	}
}
