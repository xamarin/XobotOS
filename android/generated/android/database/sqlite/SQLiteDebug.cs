using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public sealed class SQLiteDebug
	{
		public static readonly bool DEBUG_SQL_STATEMENTS = android.util.Log.isLoggable("SQLiteStatements"
			, android.util.Log.VERBOSE);

		public static readonly bool DEBUG_SQL_TIME = android.util.Log.isLoggable("SQLiteTime"
			, android.util.Log.VERBOSE);

		public static readonly bool DEBUG_SQL_CACHE = android.util.Log.isLoggable("SQLiteCompiledSql"
			, android.util.Log.VERBOSE);

		public static readonly bool DEBUG_ACTIVE_CURSOR_FINALIZATION = android.util.Log.isLoggable
			("SQLiteCursorClosing", android.util.Log.VERBOSE);

		public static readonly bool DEBUG_LOCK_TIME_TRACKING = android.util.Log.isLoggable
			("SQLiteLockTime", android.util.Log.VERBOSE);

		public static readonly bool DEBUG_LOCK_TIME_TRACKING_STACK_TRACE = android.util.Log
			.isLoggable("SQLiteLockStackTrace", android.util.Log.VERBOSE);

		[Sharpen.Stub]
		public class PagerStats
		{
			[System.ObsoleteAttribute(@"not used any longer")]
			public long totalBytes;

			[System.ObsoleteAttribute(@"not used any longer")]
			public long referencedBytes;

			[System.ObsoleteAttribute(@"not used any longer")]
			public long databaseBytes;

			[System.ObsoleteAttribute(@"not used any longer")]
			public int numPagers;

			public int memoryUsed;

			public int pageCacheOverflo;

			public int largestMemAlloc;

			public java.util.ArrayList<android.database.sqlite.SQLiteDebug.DbStats> dbStats;
		}

		[Sharpen.Stub]
		public class DbStats
		{
			public string dbName;

			public long pageSize;

			public long dbSize;

			public int lookaside;

			public string cache;

			[Sharpen.Stub]
			public DbStats(string dbName, long pageCount, long pageSize, int lookaside, int hits
				, int misses, int cachesize)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public static android.database.sqlite.SQLiteDebug.PagerStats getDatabaseInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void getPagerStats(android.database.sqlite.SQLiteDebug.PagerStats stats
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getHeapSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getHeapAllocatedSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getHeapFreeSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void getHeapDirtyPages(int[] pages)
		{
			throw new System.NotImplementedException();
		}

		private static int sNumActiveCursorsFinalized = 0;

		[Sharpen.Stub]
		public static int getNumActiveCursorsFinalized()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void notifyActiveCursorFinalized()
		{
			throw new System.NotImplementedException();
		}
	}
}
