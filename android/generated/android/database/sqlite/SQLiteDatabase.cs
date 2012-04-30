using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public class SQLiteDatabase : android.database.sqlite.SQLiteClosable
	{
		internal const string TAG = "SQLiteDatabase";

		internal const bool ENABLE_DB_SAMPLE = false;

		internal const int EVENT_DB_OPERATION = 52000;

		internal const int EVENT_DB_CORRUPT = 75004;

		public const int CONFLICT_ROLLBACK = 1;

		public const int CONFLICT_ABORT = 2;

		public const int CONFLICT_FAIL = 3;

		public const int CONFLICT_IGNORE = 4;

		public const int CONFLICT_REPLACE = 5;

		public const int CONFLICT_NONE = 0;

		private static readonly string[] CONFLICT_VALUES = new string[] { string.Empty, " OR ROLLBACK "
			, " OR ABORT ", " OR FAIL ", " OR IGNORE ", " OR REPLACE " };

		public const int SQLITE_MAX_LIKE_PATTERN_LENGTH = 50000;

		public const int OPEN_READWRITE = unchecked((int)(0x00000000));

		public const int OPEN_READONLY = unchecked((int)(0x00000001));

		internal const int OPEN_READ_MASK = unchecked((int)(0x00000001));

		public const int NO_LOCALIZED_COLLATORS = unchecked((int)(0x00000010));

		public const int CREATE_IF_NECESSARY = unchecked((int)(0x10000000));

		private bool mInnerTransactionIsSuccessful;

		private bool mTransactionIsSuccessful;

		private android.database.sqlite.SQLiteTransactionListener mTransactionListener;

		private bool mTransactionUsingExecSql;

		private readonly android.database.sqlite.SQLiteDatabase.DatabaseReentrantLock mLock
			 = new android.database.sqlite.SQLiteDatabase.DatabaseReentrantLock(true);

		private long mLockAcquiredWallTime = 0L;

		private long mLockAcquiredThreadTime = 0L;

		internal const int LOCK_WARNING_WINDOW_IN_MS = 20000;

		internal const int LOCK_ACQUIRED_WARNING_TIME_IN_MS = 300;

		internal const int LOCK_ACQUIRED_WARNING_THREAD_TIME_IN_MS = 100;

		internal const int LOCK_ACQUIRED_WARNING_TIME_IN_MS_ALWAYS_PRINT = 2000;

		internal const int SLEEP_AFTER_YIELD_QUANTUM = 1000;

		private static readonly java.util.regex.Pattern EMAIL_IN_DB_PATTERN = java.util.regex.Pattern
			.compile("[\\w\\.\\-]+@[\\w\\.\\-]+");

		private long mLastLockMessageTime = 0L;

		private static int sQueryLogTimeInMillis = 0;

		internal const int QUERY_LOG_SQL_LENGTH = 64;

		internal const string COMMIT_SQL = "COMMIT;";

		internal const string BEGIN_SQL = "BEGIN;";

		private readonly System.Random mRandom = new System.Random();

		private string mLastSqlStatement = null;

		[Sharpen.Stub]
		internal virtual string getLastSqlStatement()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setLastSqlStatement(string sql)
		{
			throw new System.NotImplementedException();
		}

		private long mTransStartTime;

		internal const string GET_LOCK_LOG_PREFIX = "GETLOCK:";

		internal volatile int mNativeHandle = 0;

		private static int sBlockSize = 0;

		private readonly string mPath;

		private string mPathForLogs = null;

		private readonly int mFlags;

		private readonly android.database.sqlite.SQLiteDatabase.CursorFactory mFactory;

		private readonly java.util.WeakHashMap<android.database.sqlite.SQLiteClosable, object
			> mPrograms;

		internal const int DEFAULT_SQL_CACHE_SIZE = 25;

		private android.util.LruCache<string, android.database.sqlite.SQLiteCompiledSql> 
			mCompiledQueries;

		public const int MAX_SQL_CACHE_SIZE = 100;

		private bool mCacheFullWarning;

		private readonly System.Exception mStackTrace;

		internal const string LOG_SLOW_QUERIES_PROPERTY = "db.log.slow_query_threshold";

		private readonly int mSlowQueryThreshold;

		private readonly java.util.ArrayList<int> mClosedStatementIds = new java.util.ArrayList
			<int>();

		private readonly android.database.DatabaseErrorHandler mErrorHandler;

		internal volatile android.database.sqlite.DatabaseConnectionPool mConnectionPool = 
			null;

		internal readonly short mConnectionNum;

		internal android.database.sqlite.SQLiteDatabase mParentConnObj = null;

		internal const string MEMORY_DB_PATH = ":memory:";

		private volatile bool mHasAttachedDbs = false;

		private static java.util.ArrayList<java.lang.@ref.WeakReference<android.database.sqlite.SQLiteDatabase
			>> mActiveDatabases = new java.util.ArrayList<java.lang.@ref.WeakReference<android.database.sqlite.SQLiteDatabase
			>>();

		[Sharpen.Stub]
		internal virtual void addSQLiteClosable(android.database.sqlite.SQLiteClosable closable
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void removeSQLiteClosable(android.database.sqlite.SQLiteClosable
			 closable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.sqlite.SQLiteClosable")]
		protected internal override void onAllReferencesReleased()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int releaseMemory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLockingEnabled(bool lockingEnabled)
		{
			throw new System.NotImplementedException();
		}

		private bool mLockingEnabled = true;

		[Sharpen.Stub]
		internal virtual void onCorruption()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void @lock(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void @lock()
		{
			throw new System.NotImplementedException();
		}

		internal const long LOCK_WAIT_PERIOD = 30L;

		[Sharpen.Stub]
		private void @lock(string sql, bool forced)
		{
			throw new System.NotImplementedException();
		}

		[System.Serializable]
		[Sharpen.Stub]
		private class DatabaseReentrantLock : java.util.concurrent.locks.ReentrantLock
		{
			[Sharpen.Stub]
			internal DatabaseReentrantLock(bool fair) : base(fair)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.util.concurrent.locks.ReentrantLock")]
			protected internal override java.lang.Thread getOwner()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual string getOwnerDescription()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private void lockForced()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void lockForced(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void unlock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void unlockForced()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void checkLockHoldTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void beginTransaction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void beginTransactionNonExclusive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void beginTransactionWithListener(android.database.sqlite.SQLiteTransactionListener
			 transactionListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void beginTransactionWithListenerNonExclusive(android.database.sqlite.SQLiteTransactionListener
			 transactionListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void beginTransaction(android.database.sqlite.SQLiteTransactionListener transactionListener
			, bool exclusive)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void endTransaction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTransactionSuccessful()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool inTransaction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setTransactionUsingExecSqlFlag()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void resetTransactionUsingExecSqlFlag()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool amIInTransaction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isDbLockedByCurrentThread()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isDbLockedByOtherThreads()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"if the db is locked more than once (becuase of nested transactions) then the lock will not be yielded. Use yieldIfContendedSafely instead."
			)]
		public virtual bool yieldIfContended()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool yieldIfContendedSafely()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool yieldIfContendedSafely(long sleepAfterYieldDelay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool yieldIfContendedHelper(bool checkFullyYielded, long sleepAfterYieldDelay
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method no longer serves any useful purpose and has been deprecated."
			)]
		public virtual java.util.Map<string, string> getSyncedTables()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface CursorFactory
		{
			[Sharpen.Stub]
			android.database.Cursor newCursor(android.database.sqlite.SQLiteDatabase db, android.database.sqlite.SQLiteCursorDriver
				 masterQuery, string editTable, android.database.sqlite.SQLiteQuery query);
		}

		[Sharpen.Stub]
		public static android.database.sqlite.SQLiteDatabase openDatabase(string path, android.database.sqlite.SQLiteDatabase
			.CursorFactory factory, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.sqlite.SQLiteDatabase openDatabase(string path, android.database.sqlite.SQLiteDatabase
			.CursorFactory factory, int flags, android.database.DatabaseErrorHandler errorHandler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.database.sqlite.SQLiteDatabase openDatabase(string path, android.database.sqlite.SQLiteDatabase
			.CursorFactory factory, int flags, android.database.DatabaseErrorHandler errorHandler
			, short connectionNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.sqlite.SQLiteDatabase openOrCreateDatabase(java.io.File
			 file, android.database.sqlite.SQLiteDatabase.CursorFactory factory)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string 
			path, android.database.sqlite.SQLiteDatabase.CursorFactory factory)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string 
			path, android.database.sqlite.SQLiteDatabase.CursorFactory factory, android.database.DatabaseErrorHandler
			 errorHandler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setJournalMode(string dbPath, string mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.sqlite.SQLiteDatabase create(android.database.sqlite.SQLiteDatabase
			.CursorFactory factory)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void closeClosable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void closeDatabase()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dbclose()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface CustomFunction
		{
			[Sharpen.Stub]
			void callback(string[] args);
		}

		[Sharpen.Stub]
		public virtual void addCustomFunction(string name, int numArgs, android.database.sqlite.SQLiteDatabase
			.CustomFunction function)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void releaseCustomFunctions()
		{
			throw new System.NotImplementedException();
		}

		private readonly java.util.ArrayList<int> mCustomFunctions = new java.util.ArrayList
			<int>();

		[Sharpen.Stub]
		private int native_addCustomFunction(string name, int numArgs, android.database.sqlite.SQLiteDatabase
			.CustomFunction function)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void native_releaseCustomFunction(int function)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getVersion()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVersion(int version)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getMaximumSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long setMaximumSize(long numBytes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getPageSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPageSize(long numBytes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method no longer serves any useful purpose and has been deprecated."
			)]
		public virtual void markTableSyncable(string table, string deletedTable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method no longer serves any useful purpose and has been deprecated."
			)]
		public virtual void markTableSyncable(string table, string foreignKey, string updateTable
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string findEditTable(string tables)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.sqlite.SQLiteStatement compileStatement(string sql
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor query(bool distinct, string table, string[]
			 columns, string selection, string[] selectionArgs, string groupBy, string having
			, string orderBy, string limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor queryWithFactory(android.database.sqlite.SQLiteDatabase
			.CursorFactory cursorFactory, bool distinct, string table, string[] columns, string
			 selection, string[] selectionArgs, string groupBy, string having, string orderBy
			, string limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor query(string table, string[] columns, string
			 selection, string[] selectionArgs, string groupBy, string having, string orderBy
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor query(string table, string[] columns, string
			 selection, string[] selectionArgs, string groupBy, string having, string orderBy
			, string limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor rawQuery(string sql, string[] selectionArgs
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor rawQueryWithFactory(android.database.sqlite.SQLiteDatabase
			.CursorFactory cursorFactory, string sql, string[] selectionArgs, string editTable
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long insert(string table, string nullColumnHack, android.content.ContentValues
			 values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long insertOrThrow(string table, string nullColumnHack, android.content.ContentValues
			 values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long replace(string table, string nullColumnHack, android.content.ContentValues
			 initialValues)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long replaceOrThrow(string table, string nullColumnHack, android.content.ContentValues
			 initialValues)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long insertWithOnConflict(string table, string nullColumnHack, android.content.ContentValues
			 initialValues, int conflictAlgorithm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int delete(string table, string whereClause, string[] whereArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int update(string table, android.content.ContentValues values, string
			 whereClause, string[] whereArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int updateWithOnConflict(string table, android.content.ContentValues
			 values, string whereClause, string[] whereArgs, int conflictAlgorithm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void execSQL(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void execSQL(string sql, object[] bindArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int executeSql(string sql, object[] bindArgs)
		{
			throw new System.NotImplementedException();
		}

		~SQLiteDatabase()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private SQLiteDatabase(string path, android.database.sqlite.SQLiteDatabase.CursorFactory
			 factory, int flags, android.database.DatabaseErrorHandler errorHandler, short connectionNum
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isReadOnly()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isOpen()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool needUpgrade(int newVersion)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getPath()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void logTimeStat(string sql, long beginMillis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void logTimeStat(string sql, long beginMillis, string prefix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string getPathForLogs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLocale(System.Globalization.CultureInfo locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void verifyDbIsOpen()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void verifyLockOwner()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void addToCompiledQueries(string sql, android.database.sqlite.SQLiteCompiledSql
			 compiledStatement)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void deallocCachedSqlStatements()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.database.sqlite.SQLiteCompiledSql getCompiledStatementForSql
			(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMaxSqlCacheSize(int cacheSize)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool isInStatementCache(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void releaseCompiledSqlObj(string sql, android.database.sqlite.SQLiteCompiledSql
			 compiledSql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getCacheHitNum()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getCacheMissNum()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getCachesize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void finalizeStatementLater(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool isInQueueOfStatementsToBeFinalized(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void closePendingStatements()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual java.util.ArrayList<int> getQueuedUpStmtList()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool enableWriteAheadLogging()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disableWriteAheadLogging()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.database.sqlite.SQLiteDatabase getDatabaseHandle(string 
			sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.database.sqlite.SQLiteDatabase createPoolConnection(short
			 connectionNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.database.sqlite.SQLiteDatabase getParentDbConnObj()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isPooledConnection()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.database.sqlite.SQLiteDatabase getDbConnection(string sql
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void releaseDbConnection(android.database.sqlite.SQLiteDatabase db)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static java.util.ArrayList<android.database.sqlite.SQLiteDebug.DbStats> 
			getDbStats()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.util.Pair<string, string>> getAttachedDbs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isDatabaseIntegrityOk()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dbopen(string path, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void enableSqlTracing(string path, short connectionNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void enableSqlProfiling(string path, short connectionNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void native_setLocale(string loc, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int native_getDbLookaside()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void native_finalize(int statementId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void native_setSqliteSoftHeapLimit(int softHeapLimit)
		{
			throw new System.NotImplementedException();
		}
	}
}
