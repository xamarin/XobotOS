using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public sealed class ContentService : android.content.IContentServiceClass.Stub
	{
		internal const string TAG = "ContentService";

		private android.content.Context mContext;

		private bool mFactoryTest;

		private readonly android.content.ContentService.ObserverNode mRootNode = new android.content.ContentService
			.ObserverNode(string.Empty);

		private android.content.SyncManager mSyncManager = null;

		private readonly object mSyncManagerLock = new object();

		[Sharpen.Stub]
		private android.content.SyncManager getSyncManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Binder")]
		protected internal override void dump(java.io.FileDescriptor fd, java.io.PrintWriter
			 pw, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Binder")]
		protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
			 reply, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ContentService(android.content.Context context, bool factoryTest)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void registerContentObserver(System.Uri uri, bool notifyForDescendents
			, android.database.IContentObserver observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void unregisterContentObserver(android.database.IContentObserver 
			observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void notifyChange(System.Uri uri, android.database.IContentObserver
			 observer, bool observerWantsSelfNotifications, bool syncToNetwork)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class ObserverCall
		{
			internal readonly android.content.ContentService.ObserverNode mNode;

			internal readonly android.database.IContentObserver mObserver;

			internal readonly bool mSelfNotify;

			[Sharpen.Stub]
			internal ObserverCall(android.content.ContentService.ObserverNode node, android.database.IContentObserver
				 observer, bool selfNotify)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void requestSync(android.accounts.Account account, string authority
			, android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void cancelSync(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override android.content.SyncAdapterType[] getSyncAdapterTypes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override bool getSyncAutomatically(android.accounts.Account account, string
			 providerName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void setSyncAutomatically(android.accounts.Account account, string
			 providerName, bool sync)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void addPeriodicSync(android.accounts.Account account, string authority
			, android.os.Bundle extras, long pollFrequency)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void removePeriodicSync(android.accounts.Account account, string 
			authority, android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account
			 account, string providerName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override int getIsSyncable(android.accounts.Account account, string providerName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void setIsSyncable(android.accounts.Account account, string providerName
			, int syncable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override bool getMasterSyncAutomatically()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void setMasterSyncAutomatically(bool flag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override bool isSyncActive(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override java.util.List<android.content.SyncInfo> getCurrentSyncs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override android.content.SyncStatusInfo getSyncStatus(android.accounts.Account
			 account, string authority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override bool isSyncPending(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void addStatusChangeListener(int mask, android.content.ISyncStatusObserver
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentService")]
		public override void removeStatusChangeListener(android.content.ISyncStatusObserver
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.IContentService Main(android.content.Context context
			, bool factoryTest)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class ObserverNode
		{
			[Sharpen.Stub]
			private class ObserverEntry : android.os.IBinderClass.DeathRecipient
			{
				public readonly android.database.IContentObserver observer;

				public readonly int uid;

				public readonly int pid;

				public readonly bool notifyForDescendents;

				internal readonly object observersLock;

				[Sharpen.Stub]
				public ObserverEntry(ObserverNode _enclosing, android.database.IContentObserver o
					, bool n, object observersLock, int _uid, int _pid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.IBinder.DeathRecipient")]
				public virtual void binderDied()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public virtual void dumpLocked(java.io.FileDescriptor fd, java.io.PrintWriter pw, 
					string[] args, string name, string prefix, android.util.SparseIntArray pidCounts
					)
				{
					throw new System.NotImplementedException();
				}

				private readonly ObserverNode _enclosing;
			}

			public const int INSERT_TYPE = 0;

			public const int UPDATE_TYPE = 1;

			public const int DELETE_TYPE = 2;

			private string mName;

			private java.util.ArrayList<android.content.ContentService.ObserverNode> mChildren
				 = new java.util.ArrayList<android.content.ContentService.ObserverNode>();

			private java.util.ArrayList<android.content.ContentService.ObserverNode.ObserverEntry
				> mObservers = new java.util.ArrayList<android.content.ContentService.ObserverNode
				.ObserverEntry>();

			[Sharpen.Stub]
			public ObserverNode(string name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void dumpLocked(java.io.FileDescriptor fd, java.io.PrintWriter pw, string[]
				 args, string name, string prefix, int[] counts, android.util.SparseIntArray pidCounts
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private string getUriSegment(System.Uri uri, int index)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private int countUriSegments(System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void addObserverLocked(System.Uri uri, android.database.IContentObserver observer
				, bool notifyForDescendents, object observersLock, int uid, int pid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void addObserverLocked(System.Uri uri, int index, android.database.IContentObserver
				 observer, bool notifyForDescendents, object observersLock, int uid, int pid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public bool removeObserverLocked(android.database.IContentObserver observer)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void collectMyObserversLocked(bool leaf, android.database.IContentObserver
				 observer, bool selfNotify, java.util.ArrayList<android.content.ContentService.ObserverCall
				> calls)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void collectObserversLocked(System.Uri uri, int index, android.database.IContentObserver
				 observer, bool selfNotify, java.util.ArrayList<android.content.ContentService.ObserverCall
				> calls)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
