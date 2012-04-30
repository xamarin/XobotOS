using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class ActivityChooserModel : android.database.DataSetObservable
	{
		[Sharpen.Stub]
		public interface ActivityChooserModelClient
		{
			[Sharpen.Stub]
			void setActivityChooserModel(android.widget.ActivityChooserModel dataModel);
		}

		[Sharpen.Stub]
		public interface ActivitySorter
		{
			[Sharpen.Stub]
			void sort(android.content.Intent intent, java.util.List<android.widget.ActivityChooserModel
				.ActivityResolveInfo> activities, java.util.List<android.widget.ActivityChooserModel
				.HistoricalRecord> historicalRecords);
		}

		[Sharpen.Stub]
		public interface OnChooseActivityListener
		{
			[Sharpen.Stub]
			bool onChooseActivity(android.widget.ActivityChooserModel host, android.content.Intent
				 intent);
		}

		internal const bool DEBUG = false;

		private static readonly string LOG_TAG = typeof(android.widget.ActivityChooserModel
			).Name;

		internal const string TAG_HISTORICAL_RECORDS = "historical-records";

		internal const string TAG_HISTORICAL_RECORD = "historical-record";

		internal const string ATTRIBUTE_ACTIVITY = "activity";

		internal const string ATTRIBUTE_TIME = "time";

		internal const string ATTRIBUTE_WEIGHT = "weight";

		public const string DEFAULT_HISTORY_FILE_NAME = "activity_choser_model_history.xml";

		public const int DEFAULT_HISTORY_MAX_LENGTH = 50;

		internal const int DEFAULT_ACTIVITY_INFLATION = 5;

		internal const float DEFAULT_HISTORICAL_RECORD_WEIGHT = 1.0f;

		internal const string HISTORY_FILE_EXTENSION = ".xml";

		internal const int INVALID_INDEX = -1;

		private static readonly object sRegistryLock = new object();

		private static readonly java.util.Map<string, android.widget.ActivityChooserModel
			> sDataModelRegistry = new java.util.HashMap<string, android.widget.ActivityChooserModel
			>();

		private readonly object mInstanceLock = new object();

		private readonly java.util.List<android.widget.ActivityChooserModel.ActivityResolveInfo
			> mActivites = new java.util.ArrayList<android.widget.ActivityChooserModel.ActivityResolveInfo
			>();

		private readonly java.util.List<android.widget.ActivityChooserModel.HistoricalRecord
			> mHistoricalRecords = new java.util.ArrayList<android.widget.ActivityChooserModel
			.HistoricalRecord>();

		private readonly android.content.@internal.PackageMonitor mPackageMonitor;

		private readonly android.content.Context mContext;

		private readonly string mHistoryFileName;

		private android.content.Intent mIntent;

		private android.widget.ActivityChooserModel.ActivitySorter mActivitySorter;

		private int mHistoryMaxSize = DEFAULT_HISTORY_MAX_LENGTH;

		private bool mCanReadHistoricalData = true;

		private bool mReadShareHistoryCalled = false;

		private bool mHistoricalRecordsChanged = true;

		private readonly android.os.Handler mHandler = new android.os.Handler();

		private android.widget.ActivityChooserModel.OnChooseActivityListener mActivityChoserModelPolicy;

		[Sharpen.Stub]
		public static android.widget.ActivityChooserModel get(android.content.Context context
			, string historyFileName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private ActivityChooserModel(android.content.Context context, string historyFileName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIntent(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Intent getIntent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getActivityCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.pm.ResolveInfo getActivity(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getActivityIndex(android.content.pm.ResolveInfo activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Intent chooseActivity(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnChooseActivityListener(android.widget.ActivityChooserModel
			.OnChooseActivityListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.pm.ResolveInfo getDefaultActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDefaultActivity(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readHistoricalData()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void persistHistoricalData()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setActivitySorter(android.widget.ActivityChooserModel.ActivitySorter
			 activitySorter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sortActivities()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setHistoryMaxSize(int historyMaxSize)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getHistoryMaxSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getHistorySize()
		{
			throw new System.NotImplementedException();
		}

		~ActivityChooserModel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool addHisoricalRecord(android.widget.ActivityChooserModel.HistoricalRecord
			 historicalRecord)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void pruneExcessiveHistoricalRecordsLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void loadActivitiesLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void pruneHistoricalRecordsForPackageLocked(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class HistoricalRecord
		{
			public readonly android.content.ComponentName activity;

			public readonly long time;

			public readonly float weight;

			[Sharpen.Stub]
			public HistoricalRecord(string activityName, long time, float weight) : this(android.content.ComponentName
				.unflattenFromString(activityName), time, weight)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public HistoricalRecord(android.content.ComponentName activityName, long time, float
				 weight)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object obj)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class ActivityResolveInfo : java.lang.Comparable<android.widget.ActivityChooserModel
			.ActivityResolveInfo>
		{
			public readonly android.content.pm.ResolveInfo resolveInfo;

			public float weight;

			[Sharpen.Stub]
			public ActivityResolveInfo(ActivityChooserModel _enclosing, android.content.pm.ResolveInfo
				 resolveInfo)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object obj)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
			public int compareTo(android.widget.ActivityChooserModel.ActivityResolveInfo another
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			private readonly ActivityChooserModel _enclosing;
		}

		[Sharpen.Stub]
		private sealed class DefaultSorter : android.widget.ActivityChooserModel.ActivitySorter
		{
			internal const float WEIGHT_DECAY_COEFFICIENT = 0.95f;

			internal readonly java.util.Map<string, android.widget.ActivityChooserModel.ActivityResolveInfo
				> mPackageNameToActivityMap;

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.ActivityChooserModel.ActivitySorter"
				)]
			public void sort(android.content.Intent intent, java.util.List<android.widget.ActivityChooserModel
				.ActivityResolveInfo> activities, java.util.List<android.widget.ActivityChooserModel
				.HistoricalRecord> historicalRecords)
			{
				throw new System.NotImplementedException();
			}

			public DefaultSorter(ActivityChooserModel _enclosing)
			{
				this._enclosing = _enclosing;
				mPackageNameToActivityMap = new java.util.HashMap<string, android.widget.ActivityChooserModel
					.ActivityResolveInfo>();
			}

			private readonly ActivityChooserModel _enclosing;
		}

		[Sharpen.Stub]
		private sealed class HistoryLoader : java.lang.Runnable
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}

			internal HistoryLoader(ActivityChooserModel _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityChooserModel _enclosing;
		}

		[Sharpen.Stub]
		private sealed class HistoryPersister : java.lang.Runnable
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}

			internal HistoryPersister(ActivityChooserModel _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityChooserModel _enclosing;
		}

		[Sharpen.Stub]
		private sealed class DataModelPackageMonitor : android.content.@internal.PackageMonitor
		{
			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.content.PackageMonitor")]
			public override void onPackageAdded(string packageName, int uid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.content.PackageMonitor")]
			public override void onPackageAppeared(string packageName, int reason)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.content.PackageMonitor")]
			public override void onPackageRemoved(string packageName, int uid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.content.PackageMonitor")]
			public override void onPackageDisappeared(string packageName, int reason)
			{
				throw new System.NotImplementedException();
			}

			internal DataModelPackageMonitor(ActivityChooserModel _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityChooserModel _enclosing;
		}
	}
}
