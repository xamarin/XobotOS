using Sharpen;

namespace android.widget
{
	/// <summary>
	/// This class can be used by external clients of CursorAdapter and
	/// CursorTreeAdapter to define how the content of the adapter should be
	/// filtered.
	/// </summary>
	/// <remarks>
	/// This class can be used by external clients of CursorAdapter and
	/// CursorTreeAdapter to define how the content of the adapter should be
	/// filtered.
	/// </remarks>
	/// <seealso cref="runQuery(java.lang.CharSequence)">runQuery(java.lang.CharSequence)
	/// 	</seealso>
	[Sharpen.Sharpened]
	public interface FilterQueryProvider
	{
		/// <summary>Runs a query with the specified constraint.</summary>
		/// <remarks>
		/// Runs a query with the specified constraint. This query is requested
		/// by the filter attached to this adapter.
		/// Contract: when constraint is null or empty, the original results,
		/// prior to any filtering, must be returned.
		/// </remarks>
		/// <param name="constraint">
		/// the constraint with which the query must
		/// be filtered
		/// </param>
		/// <returns>a Cursor representing the results of the new query</returns>
		android.database.Cursor runQuery(java.lang.CharSequence constraint);
	}
}
