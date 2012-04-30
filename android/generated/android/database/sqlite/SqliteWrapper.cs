using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public sealed class SqliteWrapper
	{
		internal const string TAG = "SqliteWrapper";

		internal const string SQLITE_EXCEPTION_DETAIL_MESSAGE = "unable to open database file";

		[Sharpen.Stub]
		private SqliteWrapper()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool isLowMemory(android.database.sqlite.SQLiteException e)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void checkSQLiteException(android.content.Context context, android.database.sqlite.SQLiteException
			 e)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.Cursor query(android.content.Context context, android.content.ContentResolver
			 resolver, System.Uri uri, string[] projection, string selection, string[] selectionArgs
			, string sortOrder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool requery(android.content.Context context, android.database.Cursor
			 cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int update(android.content.Context context, android.content.ContentResolver
			 resolver, System.Uri uri, android.content.ContentValues values, string where, string
			[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int delete(android.content.Context context, android.content.ContentResolver
			 resolver, System.Uri uri, string where, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static System.Uri insert(android.content.Context context, android.content.ContentResolver
			 resolver, System.Uri uri, android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}
	}
}
