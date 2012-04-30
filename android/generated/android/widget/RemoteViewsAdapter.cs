using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class RemoteViewsAdapter : android.widget.BaseAdapter, android.os.Handler.
		Callback
	{
		internal const string TAG = "RemoteViewsAdapter";

		internal const int sDefaultCacheSize = 40;

		internal const int sUnbindServiceDelay = 5000;

		internal const int sDefaultLoadingViewHeight = 50;

		internal const int sDefaultMessageType = 0;

		internal const int sUnbindServiceMessageType = 1;

		private readonly android.content.Context mContext;

		private readonly android.content.Intent mIntent;

		private readonly int mAppWidgetId;

		private android.view.LayoutInflater mLayoutInflater;

		private android.widget.RemoteViewsAdapter.RemoteViewsAdapterServiceConnection mServiceConnection;

		private java.lang.@ref.WeakReference<android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback
			> mCallback;

		private android.widget.RemoteViewsAdapter.FixedSizeRemoteViewsCache mCache;

		private bool mNotifyDataSetChangedAfterOnServiceConnected = false;

		private android.widget.RemoteViewsAdapter.RemoteViewsFrameLayoutRefSet mRequestedViews;

		private android.os.HandlerThread mWorkerThread;

		private android.os.Handler mWorkerQueue;

		private android.os.Handler mMainQueue;

		[Sharpen.Stub]
		public interface RemoteAdapterConnectionCallback
		{
			[Sharpen.Stub]
			bool onRemoteAdapterConnected();

			[Sharpen.Stub]
			void onRemoteAdapterDisconnected();

			[Sharpen.Stub]
			void deferNotifyDataSetChanged();
		}

		[Sharpen.Stub]
		private class RemoteViewsAdapterServiceConnection : android.widget.@internal.IRemoteViewsAdapterConnectionClass
			.Stub
		{
			internal bool mIsConnected;

			internal bool mIsConnecting;

			internal java.lang.@ref.WeakReference<android.widget.RemoteViewsAdapter> mAdapter;

			internal android.widget.@internal.IRemoteViewsFactory mRemoteViewsFactory;

			[Sharpen.Stub]
			public RemoteViewsAdapterServiceConnection(android.widget.RemoteViewsAdapter adapter
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bind(android.content.Context context, int appWidgetId, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void unbind(android.content.Context context, int appWidgetId, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsAdapterConnection"
				)]
			public override void onServiceConnected(android.os.IBinder service)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsAdapterConnection"
				)]
			public override void onServiceDisconnected()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.widget.@internal.IRemoteViewsFactory getRemoteViewsFactory
				()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isConnected()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class RemoteViewsFrameLayout : android.widget.FrameLayout
		{
			[Sharpen.Stub]
			public RemoteViewsFrameLayout(RemoteViewsAdapter _enclosing, android.content.Context
				 context) : base(context)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void onRemoteViewsLoaded(android.widget.RemoteViews view)
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViewsAdapter _enclosing;
		}

		[Sharpen.Stub]
		private class RemoteViewsFrameLayoutRefSet
		{
			internal java.util.HashMap<int, java.util.LinkedList<android.widget.RemoteViewsAdapter
				.RemoteViewsFrameLayout>> mReferences;

			[Sharpen.Stub]
			public RemoteViewsFrameLayoutRefSet(RemoteViewsAdapter _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void add(int position, android.widget.RemoteViewsAdapter.RemoteViewsFrameLayout
				 layout)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void notifyOnRemoteViewsLoaded(int position, android.widget.RemoteViews
				 view, int typeId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void clear()
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViewsAdapter _enclosing;
		}

		[Sharpen.Stub]
		private class RemoteViewsMetaData
		{
			internal int count;

			internal int viewTypeCount;

			internal bool hasStableIds;

			internal android.widget.RemoteViews mUserLoadingView;

			internal android.widget.RemoteViews mFirstView;

			internal int mFirstViewHeight;

			internal readonly java.util.HashMap<int, int> mTypeIdIndexMap;

			[Sharpen.Stub]
			public RemoteViewsMetaData(RemoteViewsAdapter _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void set(android.widget.RemoteViewsAdapter.RemoteViewsMetaData d)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void reset()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setLoadingViewTemplates(android.widget.RemoteViews loadingView
				, android.widget.RemoteViews firstView)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getMappedViewType(int typeId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal android.widget.RemoteViewsAdapter.RemoteViewsFrameLayout createLoadingView
				(int position, android.view.View convertView, android.view.ViewGroup parent)
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViewsAdapter _enclosing;
		}

		[Sharpen.Stub]
		private class RemoteViewsIndexMetaData
		{
			internal int typeId;

			internal long itemId;

			internal bool isRequested;

			[Sharpen.Stub]
			public RemoteViewsIndexMetaData(RemoteViewsAdapter _enclosing, android.widget.RemoteViews
				 v, long itemId, bool requested)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void set(android.widget.RemoteViews v, long id, bool requested)
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViewsAdapter _enclosing;
		}

		[Sharpen.Stub]
		private class FixedSizeRemoteViewsCache
		{
			internal const string TAG = "FixedSizeRemoteViewsCache";

			internal android.widget.RemoteViewsAdapter.RemoteViewsMetaData mMetaData;

			internal android.widget.RemoteViewsAdapter.RemoteViewsMetaData mTemporaryMetaData;

			internal java.util.HashMap<int, android.widget.RemoteViewsAdapter.RemoteViewsIndexMetaData
				> mIndexMetaData;

			internal java.util.HashMap<int, android.widget.RemoteViews> mIndexRemoteViews;

			internal java.util.HashSet<int> mRequestedIndices;

			internal int mLastRequestedIndex;

			internal java.util.HashSet<int> mLoadIndices;

			internal int mPreloadLowerBound;

			internal int mPreloadUpperBound;

			internal int mMaxCount;

			internal int mMaxCountSlack;

			internal const float sMaxCountSlackPercent = 0.75f;

			internal const int sMaxMemoryLimitInBytes = 2 * 1024 * 1024;

			[Sharpen.Stub]
			public FixedSizeRemoteViewsCache(RemoteViewsAdapter _enclosing, int maxCacheSize)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void insert(int position, android.widget.RemoteViews v, long itemId
				, bool isRequested)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.widget.RemoteViewsAdapter.RemoteViewsMetaData getMetaData(
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.widget.RemoteViewsAdapter.RemoteViewsMetaData getTemporaryMetaData
				()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.widget.RemoteViews getRemoteViewsAt(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.widget.RemoteViewsAdapter.RemoteViewsIndexMetaData getMetaDataAt
				(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void commitTemporaryMetaData()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal int getRemoteViewsBitmapMemoryUsage()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal int getFarthestPositionFrom(int pos)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void queueRequestedPositionToLoad(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool queuePositionsToBePreloadedFromRequestedPosition(int position
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int[] getNextIndexToLoad()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool containsRemoteViewAt(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool containsMetaDataAt(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void reset()
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViewsAdapter _enclosing;
		}

		[Sharpen.Stub]
		public RemoteViewsAdapter(android.content.Context context, android.content.Intent
			 intent, android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback callback
			)
		{
			throw new System.NotImplementedException();
		}

		~RemoteViewsAdapter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void loadNextIndexInBackground()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void processException(string method, System.Exception e)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateTemporaryMetaData()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateRemoteViews(int position, bool isRequested)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Intent getRemoteViewsServiceIntent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override int getCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override object getItem(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override long getItemId(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override int getItemViewType(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getConvertViewTypeId(android.view.View convertView)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override android.view.View getView(int position, android.view.View convertView
			, android.view.ViewGroup parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override int getViewTypeCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool hasStableIds()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool isEmpty()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onNotifyDataSetChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override void notifyDataSetChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void superNotifyDataSetChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Handler.Callback")]
		public virtual bool handleMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void enqueueDeferredUnbindServiceMessage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool requestBindService()
		{
			throw new System.NotImplementedException();
		}
	}
}
