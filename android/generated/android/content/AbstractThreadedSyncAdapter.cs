using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public abstract class AbstractThreadedSyncAdapter
	{
		[System.ObsoleteAttribute(@"Private constant.  May go away in the next release.")]
		public const int LOG_SYNC_DETAILS = 2743;

		private readonly android.content.Context mContext;

		private readonly java.util.concurrent.atomic.AtomicInteger mNumSyncStarts;

		private readonly android.content.AbstractThreadedSyncAdapter.ISyncAdapterImpl mISyncAdapterImpl;

		private readonly java.util.HashMap<android.accounts.Account, android.content.AbstractThreadedSyncAdapter
			.SyncThread> mSyncThreads = new java.util.HashMap<android.accounts.Account, android.content.AbstractThreadedSyncAdapter
			.SyncThread>();

		private readonly object mSyncThreadLock = new object();

		private readonly bool mAutoInitialize;

		private bool mAllowParallelSyncs;

		[Sharpen.Stub]
		public AbstractThreadedSyncAdapter(android.content.Context context, bool autoInitialize
			) : this(context, autoInitialize, false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public AbstractThreadedSyncAdapter(android.content.Context context, bool autoInitialize
			, bool allowParallelSyncs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Context getContext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.accounts.Account toSyncKey(android.accounts.Account account)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class ISyncAdapterImpl : android.content.ISyncAdapterClass.Stub
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.ISyncAdapter")]
			public override void startSync(android.content.ISyncContext syncContext, string authority
				, android.accounts.Account account, android.os.Bundle extras)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.ISyncAdapter")]
			public override void cancelSync(android.content.ISyncContext syncContext)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.ISyncAdapter")]
			public override void initialize(android.accounts.Account account, string authority
				)
			{
				throw new System.NotImplementedException();
			}

			internal ISyncAdapterImpl(AbstractThreadedSyncAdapter _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbstractThreadedSyncAdapter _enclosing;
		}

		[Sharpen.Stub]
		private class SyncThread : java.lang.Thread
		{
			internal readonly android.content.SyncContext mSyncContext;

			internal readonly string mAuthority;

			internal readonly android.accounts.Account mAccount;

			internal readonly android.os.Bundle mExtras;

			internal readonly android.accounts.Account mThreadsKey;

			[Sharpen.Stub]
			internal SyncThread(AbstractThreadedSyncAdapter _enclosing, string name, android.content.SyncContext
				 syncContext, string authority, android.accounts.Account account, android.os.Bundle
				 extras) : base(name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Thread")]
			public override void run()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool isCanceled()
			{
				throw new System.NotImplementedException();
			}

			private readonly AbstractThreadedSyncAdapter _enclosing;
		}

		[Sharpen.Stub]
		public android.os.IBinder getSyncAdapterBinder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void onPerformSync(android.accounts.Account account, android.os.Bundle
			 extras, string authority, android.content.ContentProviderClient provider, android.content.SyncResult
			 syncResult);

		[Sharpen.Stub]
		public virtual void onSyncCanceled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onSyncCanceled(java.lang.Thread thread)
		{
			throw new System.NotImplementedException();
		}
	}
}
