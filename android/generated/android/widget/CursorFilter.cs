using Sharpen;

namespace android.widget
{
	/// <summary><p>The CursorFilter delegates most of the work to the CursorAdapter.</summary>
	/// <remarks>
	/// <p>The CursorFilter delegates most of the work to the CursorAdapter.
	/// Subclasses should override these delegate methods to run the queries
	/// and convert the results into String that can be used by auto-completion
	/// widgets.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal class CursorFilter : android.widget.Filter
	{
		internal android.widget.CursorFilter.CursorFilterClient mClient;

		internal interface CursorFilterClient
		{
			java.lang.CharSequence convertToString(android.database.Cursor cursor);

			android.database.Cursor runQueryOnBackgroundThread(java.lang.CharSequence constraint
				);

			android.database.Cursor getCursor();

			void changeCursor(android.database.Cursor cursor);
		}

		internal CursorFilter(android.widget.CursorFilter.CursorFilterClient client)
		{
			mClient = client;
		}

		[Sharpen.OverridesMethod(@"android.widget.Filter")]
		public override java.lang.CharSequence convertResultToString(object resultValue)
		{
			return mClient.convertToString((android.database.Cursor)resultValue);
		}

		[Sharpen.OverridesMethod(@"android.widget.Filter")]
		internal override android.widget.Filter.FilterResults performFiltering(java.lang.CharSequence
			 constraint)
		{
			android.database.Cursor cursor = mClient.runQueryOnBackgroundThread(constraint);
			android.widget.Filter.FilterResults results = new android.widget.Filter.FilterResults
				();
			if (cursor != null)
			{
				results.count = cursor.getCount();
				results.values = cursor;
			}
			else
			{
				results.count = 0;
				results.values = null;
			}
			return results;
		}

		[Sharpen.OverridesMethod(@"android.widget.Filter")]
		internal override void publishResults(java.lang.CharSequence constraint, android.widget.Filter
			.FilterResults results)
		{
			android.database.Cursor oldCursor = mClient.getCursor();
			if (results.values != null && results.values != oldCursor)
			{
				mClient.changeCursor((android.database.Cursor)results.values);
			}
		}
	}
}
