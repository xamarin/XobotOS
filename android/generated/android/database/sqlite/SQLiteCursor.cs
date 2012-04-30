using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public class SQLiteCursor : android.database.AbstractWindowedCursor
	{
		internal const string TAG = "SQLiteCursor";

		internal const int NO_COUNT = -1;

		private readonly string mEditTable;

		private readonly string[] mColumns;

		private android.database.sqlite.SQLiteQuery mQuery;

		private readonly android.database.sqlite.SQLiteCursorDriver mDriver;

		private volatile int mCount = NO_COUNT;

		private java.util.Map<string, int> mColumnNameMap;

		private readonly System.Exception mStackTrace;

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use SQLiteCursor(SQLiteCursorDriver, string, SQLiteQuery) instead"
			)]
		public SQLiteCursor(android.database.sqlite.SQLiteDatabase db, android.database.sqlite.SQLiteCursorDriver
			 driver, string editTable, android.database.sqlite.SQLiteQuery query) : this(driver
			, editTable, query)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SQLiteCursor(android.database.sqlite.SQLiteCursorDriver driver, string editTable
			, android.database.sqlite.SQLiteQuery query)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.sqlite.SQLiteDatabase getDatabase()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override bool onMove(int oldPosition, int newPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void fillWindow(int startPos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.database.sqlite.SQLiteQuery getQuery()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getColumnIndex(string columnName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override string[] getColumnNames()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override void deactivate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override bool requery()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractWindowedCursor")]
		public override void setWindow(android.database.CursorWindow window)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSelectionArguments(string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		~SQLiteCursor()
		{
			throw new System.NotImplementedException();
		}
	}
}
