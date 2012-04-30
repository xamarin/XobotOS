using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public sealed class CursorJoiner : java.util.Iterator<android.database.CursorJoiner
		.Result>, java.lang.Iterable<android.database.CursorJoiner.Result>
	{
		private android.database.Cursor mCursorLeft;

		private android.database.Cursor mCursorRight;

		private bool mCompareResultIsValid;

		private android.database.CursorJoiner.Result mCompareResult;

		private int[] mColumnsLeft;

		private int[] mColumnsRight;

		private string[] mValues;

		public enum Result
		{
			/// <summary>The row currently pointed to by the left cursor is unique</summary>
			RIGHT,
			/// <summary>The row currently pointed to by the right cursor is unique</summary>
			LEFT,
			/// <summary>The rows pointed to by both cursors are the same</summary>
			BOTH
		}

		[Sharpen.Stub]
		public CursorJoiner(android.database.Cursor cursorLeft, string[] columnNamesLeft, 
			android.database.Cursor cursorRight, string[] columnNamesRight)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.lang.Iterable")]
		public java.util.Iterator<android.database.CursorJoiner.Result> iterator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int[] buildColumnIndiciesArray(android.database.Cursor cursor, string[] columnNames
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.Iterator")]
		public bool hasNext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.Iterator")]
		public android.database.CursorJoiner.Result next()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.Iterator")]
		public void remove()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void populateValues(string[] values, android.database.Cursor cursor
			, int[] columnIndicies, int startingIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void incrementCursors()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int compareStrings(params string[] values)
		{
			throw new System.NotImplementedException();
		}
	}
}
