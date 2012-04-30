using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncStorageEngine : android.os.Handler
	{
		internal const string TAG = "SyncManager";

		internal const bool DEBUG_FILE = false;

		internal const long DEFAULT_POLL_FREQUENCY_SECONDS = 60 * 60 * 24;

		internal const long MILLIS_IN_4WEEKS = 1000L * 60 * 60 * 24 * 7 * 4;

		public const int EVENT_START = 0;

		public const int EVENT_STOP = 1;

		public static readonly string[] EVENTS = new string[] { "START", "STOP" };

		public const int SOURCE_SERVER = 0;

		public const int SOURCE_LOCAL = 1;

		public const int SOURCE_POLL = 2;

		public const int SOURCE_USER = 3;

		public const int SOURCE_PERIODIC = 4;

		public const long NOT_IN_BACKOFF_MODE = -1;

		public static readonly android.content.Intent SYNC_CONNECTION_SETTING_CHANGED_INTENT
			 = new android.content.Intent("com.android.sync.SYNC_CONN_STATUS_CHANGED");

		public static readonly string[] SOURCES = new string[] { "SERVER", "LOCAL", "POLL"
			, "USER", "PERIODIC" };

		public const string MESG_SUCCESS = "success";

		public const string MESG_CANCELED = "canceled";

		public const int MAX_HISTORY = 100;

		internal const int MSG_WRITE_STATUS = 1;

		internal const long WRITE_STATUS_DELAY = 1000 * 60 * 10;

		internal const int MSG_WRITE_STATISTICS = 2;

		internal const long WRITE_STATISTICS_DELAY = 1000 * 60 * 30;

		internal const bool SYNC_ENABLED_DEFAULT = false;

		internal const int ACCOUNTS_VERSION = 2;

		private static java.util.HashMap<string, string> sAuthorityRenames;

		static SyncStorageEngine()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class PendingOperation
		{
			internal readonly android.accounts.Account account;

			internal readonly int syncSource;

			internal readonly string authority;

			internal readonly android.os.Bundle extras;

			internal readonly bool expedited;

			internal int authorityId;

			internal byte[] flatExtras;

			[Sharpen.Stub]
			internal PendingOperation(android.accounts.Account account, int source, string authority
				, android.os.Bundle extras, bool expedited)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal PendingOperation(android.content.SyncStorageEngine.PendingOperation other
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class AccountInfo
		{
			internal readonly android.accounts.Account account;

			internal readonly java.util.HashMap<string, android.content.SyncStorageEngine.AuthorityInfo
				> authorities = new java.util.HashMap<string, android.content.SyncStorageEngine.
				AuthorityInfo>();

			[Sharpen.Stub]
			internal AccountInfo(android.accounts.Account account)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class AuthorityInfo
		{
			internal readonly android.accounts.Account account;

			internal readonly string authority;

			internal readonly int ident;

			internal bool enabled;

			internal int syncable;

			internal long backoffTime;

			internal long backoffDelay;

			internal long delayUntil;

			internal readonly java.util.ArrayList<android.util.Pair<android.os.Bundle, long>>
				 periodicSyncs;

			[Sharpen.Stub]
			internal AuthorityInfo(android.accounts.Account account, string authority, int ident
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class SyncHistoryItem
		{
			internal int authorityId;

			internal int historyId;

			internal long eventTime;

			internal long elapsedTime;

			internal int source;

			internal int @event;

			internal long upstreamActivity;

			internal long downstreamActivity;

			internal string mesg;
		}

		[Sharpen.Stub]
		public class DayStats
		{
			public readonly int day;

			public int successCount;

			public long successTime;

			public int failureCount;

			public long failureTime;

			[Sharpen.Stub]
			public DayStats(int day)
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.util.SparseArray<android.content.SyncStorageEngine.AuthorityInfo
			> mAuthorities = new android.util.SparseArray<android.content.SyncStorageEngine.
			AuthorityInfo>();

		private readonly java.util.HashMap<android.accounts.Account, android.content.SyncStorageEngine
			.AccountInfo> mAccounts = new java.util.HashMap<android.accounts.Account, android.content.SyncStorageEngine
			.AccountInfo>();

		private readonly java.util.ArrayList<android.content.SyncStorageEngine.PendingOperation
			> mPendingOperations = new java.util.ArrayList<android.content.SyncStorageEngine
			.PendingOperation>();

		private readonly java.util.ArrayList<android.content.SyncInfo> mCurrentSyncs = new 
			java.util.ArrayList<android.content.SyncInfo>();

		private readonly android.util.SparseArray<android.content.SyncStatusInfo> mSyncStatus
			 = new android.util.SparseArray<android.content.SyncStatusInfo>();

		private readonly java.util.ArrayList<android.content.SyncStorageEngine.SyncHistoryItem
			> mSyncHistory = new java.util.ArrayList<android.content.SyncStorageEngine.SyncHistoryItem
			>();

		private readonly android.os.RemoteCallbackList<android.content.ISyncStatusObserver
			> mChangeListeners = new android.os.RemoteCallbackList<android.content.ISyncStatusObserver
			>();

		private int mNextAuthorityId = 0;

		private readonly android.content.SyncStorageEngine.DayStats[] mDayStats = new android.content.SyncStorageEngine
			.DayStats[7 * 4];

		private readonly java.util.Calendar mCal;

		private int mYear;

		private int mYearInDays;

		private readonly android.content.Context mContext;

		private static volatile android.content.SyncStorageEngine sSyncStorageEngine = null;

		private readonly android.os.@internal.AtomicFile mAccountInfoFile;

		private readonly android.os.@internal.AtomicFile mStatusFile;

		private readonly android.os.@internal.AtomicFile mStatisticsFile;

		private readonly android.os.@internal.AtomicFile mPendingFile;

		internal const int PENDING_FINISH_TO_WRITE = 4;

		private int mNumPendingFinished = 0;

		private int mNextHistoryId = 0;

		private bool mMasterSyncAutomatically = true;

		[Sharpen.Stub]
		private SyncStorageEngine(android.content.Context context, java.io.File dataDir)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.SyncStorageEngine newTestInstance(android.content.Context
			 context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void init(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.SyncStorageEngine getSingleton()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Handler")]
		public override void handleMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addStatusChangeListener(int mask, android.content.ISyncStatusObserver
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeStatusChangeListener(android.content.ISyncStatusObserver
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void reportChange(int which)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getSyncAutomatically(android.accounts.Account account, string
			 providerName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSyncAutomatically(android.accounts.Account account, string
			 providerName, bool sync)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getIsSyncable(android.accounts.Account account, string providerName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIsSyncable(android.accounts.Account account, string providerName
			, int syncable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.util.Pair<long, long> getBackoff(android.accounts.Account 
			account, string providerName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBackoff(android.accounts.Account account, string providerName
			, long nextSyncTime, long nextDelay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearAllBackoffs(android.content.SyncQueue syncQueue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDelayUntilTime(android.accounts.Account account, string providerName
			, long delayUntil)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getDelayUntilTime(android.accounts.Account account, string providerName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateOrRemovePeriodicSync(android.accounts.Account account, string 
			providerName, android.os.Bundle extras, long period, bool add)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addPeriodicSync(android.accounts.Account account, string providerName
			, android.os.Bundle extras, long pollFrequency)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removePeriodicSync(android.accounts.Account account, string providerName
			, android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account
			 account, string providerName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMasterSyncAutomatically(bool flag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getMasterSyncAutomatically()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.SyncStorageEngine.AuthorityInfo getOrCreateAuthority
			(android.accounts.Account account, string authority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeAuthority(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.SyncStorageEngine.AuthorityInfo getAuthority(int authorityId
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSyncActive(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.SyncStorageEngine.PendingOperation insertIntoPending
			(android.content.SyncStorageEngine.PendingOperation op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool deleteFromPending(android.content.SyncStorageEngine.PendingOperation
			 op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int clearPending()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.ArrayList<android.content.SyncStorageEngine.PendingOperation
			> getPendingOperations()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPendingOperationCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void doDatabaseCleanup(android.accounts.Account[] accounts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.content.SyncInfo addActiveSync(android.content.SyncManager
			.ActiveSyncContext activeSyncContext)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeActiveSync(android.content.SyncInfo syncInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reportActiveChange()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long insertStartSyncEvent(android.accounts.Account accountName, string
			 authorityName, long now, int source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool equals(android.os.Bundle b1, android.os.Bundle b2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopSyncEvent(long historyId, long elapsedTime, string resultMessage
			, long downstreamActivity, long upstreamActivity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.content.SyncInfo> getCurrentSyncs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.ArrayList<android.content.SyncStatusInfo> getSyncStatus(
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.ArrayList<android.content.SyncStorageEngine.AuthorityInfo
			> getAuthorities()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.SyncStatusInfo getStatusByAccountAndAuthority(android.accounts.Account
			 account, string authority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSyncPending(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.ArrayList<android.content.SyncStorageEngine.SyncHistoryItem
			> getSyncHistory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.SyncStorageEngine.DayStats[] getDayStatistics()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getInitialSyncFailureTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getCurrentDayLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.SyncStorageEngine.AuthorityInfo getAuthorityLocked(android.accounts.Account
			 accountName, string authorityName, string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.SyncStorageEngine.AuthorityInfo getOrCreateAuthorityLocked
			(android.accounts.Account accountName, string authorityName, int ident, bool doWrite
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void removeAuthorityLocked(android.accounts.Account account, string authorityName
			, bool doWrite)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.SyncStatusInfo getOrCreateSyncStatus(android.content.SyncStorageEngine
			.AuthorityInfo authority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.SyncStatusInfo getOrCreateSyncStatusLocked(int authorityId
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void writeAllState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearAndReadState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readAccountInfoLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool maybeMigrateSettingsForRenamedAuthorities()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.SyncStorageEngine.AuthorityInfo parseAuthority(org.xmlpull.v1.XmlPullParser
			 parser, int version)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.util.Pair<android.os.Bundle, long> parsePeriodicSync(org.xmlpull.v1.XmlPullParser
			 parser, android.content.SyncStorageEngine.AuthorityInfo authority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void parseExtra(org.xmlpull.v1.XmlPullParser parser, android.util.Pair<android.os.Bundle
			, long> periodicSync)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writeAccountInfoLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static int getIntColumn(android.database.Cursor c, string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static long getLongColumn(android.database.Cursor c, string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readAndDeleteLegacyAccountInfoLocked()
		{
			throw new System.NotImplementedException();
		}

		public const int STATUS_FILE_END = 0;

		public const int STATUS_FILE_ITEM = 100;

		[Sharpen.Stub]
		private void readStatusLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writeStatusLocked()
		{
			throw new System.NotImplementedException();
		}

		public const int PENDING_OPERATION_VERSION = 2;

		[Sharpen.Stub]
		private void readPendingOperationsLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writePendingOperationLocked(android.content.SyncStorageEngine.PendingOperation
			 op, android.os.Parcel @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writePendingOperationsLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void appendPendingOperationLocked(android.content.SyncStorageEngine.PendingOperation
			 op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static byte[] flattenBundle(android.os.Bundle bundle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.os.Bundle unflattenBundle(byte[] flatData)
		{
			throw new System.NotImplementedException();
		}

		public const int STATISTICS_FILE_END = 0;

		public const int STATISTICS_FILE_ITEM_OLD = 100;

		public const int STATISTICS_FILE_ITEM = 101;

		[Sharpen.Stub]
		private void readStatisticsLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writeStatisticsLocked()
		{
			throw new System.NotImplementedException();
		}
	}
}
