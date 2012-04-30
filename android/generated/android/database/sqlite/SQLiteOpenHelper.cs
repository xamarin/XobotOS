using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public abstract class SQLiteOpenHelper
	{
		private static readonly string TAG = typeof(android.database.sqlite.SQLiteOpenHelper
			).Name;

		private readonly android.content.Context mContext;

		private readonly string mName;

		private readonly android.database.sqlite.SQLiteDatabase.CursorFactory mFactory;

		private readonly int mNewVersion;

		private android.database.sqlite.SQLiteDatabase mDatabase = null;

		private bool mIsInitializing = false;

		private readonly android.database.DatabaseErrorHandler mErrorHandler;

		[Sharpen.Stub]
		public SQLiteOpenHelper(android.content.Context context, string name, android.database.sqlite.SQLiteDatabase
			.CursorFactory factory, int version) : this(context, name, factory, version, new 
			android.database.DefaultDatabaseErrorHandler())
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SQLiteOpenHelper(android.content.Context context, string name, android.database.sqlite.SQLiteDatabase
			.CursorFactory factory, int version, android.database.DatabaseErrorHandler errorHandler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getDatabaseName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.sqlite.SQLiteDatabase getWritableDatabase()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.sqlite.SQLiteDatabase getReadableDatabase()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void onCreate(android.database.sqlite.SQLiteDatabase db);

		[Sharpen.Stub]
		public abstract void onUpgrade(android.database.sqlite.SQLiteDatabase db, int oldVersion
			, int newVersion);

		[Sharpen.Stub]
		public virtual void onDowngrade(android.database.sqlite.SQLiteDatabase db, int oldVersion
			, int newVersion)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onOpen(android.database.sqlite.SQLiteDatabase db)
		{
			throw new System.NotImplementedException();
		}
	}
}
