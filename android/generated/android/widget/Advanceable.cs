using Sharpen;

namespace android.widget
{
	/// <summary>
	/// This interface can be implemented by any collection-type view which has a notion of
	/// progressing through its set of children.
	/// </summary>
	/// <remarks>
	/// This interface can be implemented by any collection-type view which has a notion of
	/// progressing through its set of children. The interface exists to give AppWidgetHosts a way of
	/// taking responsibility for automatically advancing such collections.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface Advanceable
	{
		/// <summary>Advances this collection, eg.</summary>
		/// <remarks>Advances this collection, eg. shows the next view.</remarks>
		void advance();

		/// <summary>
		/// Called by the AppWidgetHost once before it begins to call advance(), allowing the
		/// collection to do any required setup.
		/// </summary>
		/// <remarks>
		/// Called by the AppWidgetHost once before it begins to call advance(), allowing the
		/// collection to do any required setup.
		/// </remarks>
		void fyiWillBeAdvancedByHostKThx();
	}
}
