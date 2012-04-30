using Sharpen;

namespace android.view
{
	/// <summary>
	/// When a
	/// <see cref="View">View</see>
	/// implements this interface it will receive callbacks
	/// when expanded or collapsed as an action view alongside the optional,
	/// app-specified callbacks to
	/// <see cref="OnActionExpandListener">OnActionExpandListener</see>
	/// .
	/// <p>See
	/// <see cref="MenuItem">MenuItem</see>
	/// for more information about action views.
	/// See
	/// <see cref="android.app.ActionBar">android.app.ActionBar</see>
	/// for more information about the action bar.
	/// </summary>
	[Sharpen.Sharpened]
	public interface CollapsibleActionView
	{
		/// <summary>Called when this view is expanded as an action view.</summary>
		/// <remarks>
		/// Called when this view is expanded as an action view.
		/// See
		/// <see cref="MenuItem.expandActionView()">MenuItem.expandActionView()</see>
		/// .
		/// </remarks>
		void onActionViewExpanded();

		/// <summary>Called when this view is collapsed as an action view.</summary>
		/// <remarks>
		/// Called when this view is collapsed as an action view.
		/// See
		/// <see cref="MenuItem.collapseActionView()">MenuItem.collapseActionView()</see>
		/// .
		/// </remarks>
		void onActionViewCollapsed();
	}
}
