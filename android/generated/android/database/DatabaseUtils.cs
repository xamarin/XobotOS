using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public class DatabaseUtils
	{
		internal const string TAG = "DatabaseUtils";

		internal const bool DEBUG = false;

		internal const bool LOCAL_LOGV = false;

		private static readonly string[] countProjection = new string[] { "count(*)" };

		public const int STATEMENT_SELECT = 1;

		public const int STATEMENT_UPDATE = 2;

		public const int STATEMENT_ATTACH = 3;

		public const int STATEMENT_BEGIN = 4;

		public const int STATEMENT_COMMIT = 5;

		public const int STATEMENT_ABORT = 6;

		public const int STATEMENT_PRAGMA = 7;

		public const int STATEMENT_DDL = 8;

		public const int STATEMENT_UNPREPARED = 9;

		public const int STATEMENT_OTHER = 99;

		[Sharpen.Stub]
		public static void writeExceptionToParcel(android.os.Parcel reply, System.Exception
			 e)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void readExceptionFromParcel(android.os.Parcel reply)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void readExceptionWithFileNotFoundExceptionFromParcel(android.os.Parcel
			 reply)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void readExceptionWithOperationApplicationExceptionFromParcel(android.os.Parcel
			 reply)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void readExceptionFromParcel(android.os.Parcel reply, string msg, 
			int code)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void bindObjectToProgram(android.database.sqlite.SQLiteProgram prog
			, int index, object value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getTypeOfObject(object obj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void appendEscapedSQLString(java.lang.StringBuilder sb, string sqlString
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string sqlEscapeString(string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void appendValueToSql(java.lang.StringBuilder sql, object value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string concatenateWhere(string a, string b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getCollationKey(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getHexCollationKey(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int getKeyLen(byte[] arr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static byte[] getCollationKeyInBytes(string name)
		{
			throw new System.NotImplementedException();
		}

		private static java.text.Collator mColl = null;

		[Sharpen.Stub]
		public static void dumpCursor(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void dumpCursor(android.database.Cursor cursor, java.io.PrintStream
			 stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void dumpCursor(android.database.Cursor cursor, java.lang.StringBuilder
			 sb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string dumpCursorToString(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void dumpCurrentRow(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void dumpCurrentRow(android.database.Cursor cursor, java.io.PrintStream
			 stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void dumpCurrentRow(android.database.Cursor cursor, java.lang.StringBuilder
			 sb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string dumpCurrentRowToString(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorStringToContentValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorStringToInsertHelper(android.database.Cursor cursor, string
			 field, android.database.DatabaseUtils.InsertHelper inserter, int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorStringToContentValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values, string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorIntToContentValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorIntToContentValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values, string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorLongToContentValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorLongToContentValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values, string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorDoubleToCursorValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorDoubleToContentValues(android.database.Cursor cursor, string
			 field, android.content.ContentValues values, string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorRowToContentValues(android.database.Cursor cursor, android.content.ContentValues
			 values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long queryNumEntries(android.database.sqlite.SQLiteDatabase db, string
			 table)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long queryNumEntries(android.database.sqlite.SQLiteDatabase db, string
			 table, string selection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long queryNumEntries(android.database.sqlite.SQLiteDatabase db, string
			 table, string selection, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long longForQuery(android.database.sqlite.SQLiteDatabase db, string
			 query, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long longForQuery(android.database.sqlite.SQLiteStatement prog, string
			[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string stringForQuery(android.database.sqlite.SQLiteDatabase db, string
			 query, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string stringForQuery(android.database.sqlite.SQLiteStatement prog, 
			string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor blobFileDescriptorForQuery(android.database.sqlite.SQLiteDatabase
			 db, string query, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor blobFileDescriptorForQuery(android.database.sqlite.SQLiteStatement
			 prog, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorStringToContentValuesIfPresent(android.database.Cursor cursor
			, android.content.ContentValues values, string column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorLongToContentValuesIfPresent(android.database.Cursor cursor
			, android.content.ContentValues values, string column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorShortToContentValuesIfPresent(android.database.Cursor cursor
			, android.content.ContentValues values, string column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorIntToContentValuesIfPresent(android.database.Cursor cursor
			, android.content.ContentValues values, string column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorFloatToContentValuesIfPresent(android.database.Cursor cursor
			, android.content.ContentValues values, string column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cursorDoubleToContentValuesIfPresent(android.database.Cursor cursor
			, android.content.ContentValues values, string column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class InsertHelper
		{
			private readonly android.database.sqlite.SQLiteDatabase mDb;

			private readonly string mTableName;

			private java.util.HashMap<string, int> mColumns;

			private string mInsertSQL = null;

			private android.database.sqlite.SQLiteStatement mInsertStatement = null;

			private android.database.sqlite.SQLiteStatement mReplaceStatement = null;

			private android.database.sqlite.SQLiteStatement mPreparedStatement = null;

			public const int TABLE_INFO_PRAGMA_COLUMNNAME_INDEX = 1;

			public const int TABLE_INFO_PRAGMA_DEFAULT_INDEX = 4;

			[Sharpen.Stub]
			public InsertHelper(android.database.sqlite.SQLiteDatabase db, string tableName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void buildSQL()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.database.sqlite.SQLiteStatement getStatement(bool allowReplace)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private long insertInternal(android.content.ContentValues values, bool allowReplace
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getColumnIndex(string key)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(int index, double value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(int index, float value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(int index, long value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(int index, int value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(int index, bool value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bindNull(int index)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(int index, byte[] value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(int index, string value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual long insert(android.content.ContentValues values)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual long execute()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void prepareForInsert()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void prepareForReplace()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual long replace(android.content.ContentValues values)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void close()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public static void createDbFromSqlStatements(android.content.Context context, string
			 dbName, int dbVersion, string sqlStatements)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getSqlStatementType(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string[] appendSelectionArgs(string[] originalValues, string[] newValues
			)
		{
			throw new System.NotImplementedException();
		}
	}
}
