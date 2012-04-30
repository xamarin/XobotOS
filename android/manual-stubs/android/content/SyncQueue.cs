using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncQueue
	{
		private static readonly string TAG = "SyncManager";

		private android.content.SyncStorageEngine mSyncStorageEngine;

		private readonly System.Collections.Generic.Dictionary<string, android.content.SyncOperation> mOperationsMap
			= new System.Collections.Generic.Dictionary<string, android.content.SyncOperation>();

		public SyncQueue(android.content.SyncStorageEngine syncStorageEngine)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool add(android.content.SyncOperation operation)
		{
			throw new System.NotImplementedException();
		}

		private bool add(android.content.SyncOperation operation, android.content.SyncStorageEngine.PendingOperation
			 pop)
		{
			throw new System.NotImplementedException();
		}

		public virtual void remove(android.content.SyncOperation operation)
		{
			throw new System.NotImplementedException();
		}

		public virtual android.util.Pair<android.content.SyncOperation, long> nextOperation
			()
		{
			throw new System.NotImplementedException();
		}

		internal virtual long getOpTime(android.content.SyncOperation op)
		{
			throw new System.NotImplementedException();
		}

		internal virtual bool getIsInitial(android.content.SyncOperation op)
		{
			throw new System.NotImplementedException();
		}

		internal virtual bool isOpBetter(android.content.SyncOperation best, long bestRunTime
			, bool bestIsInitial, android.content.SyncOperation op, long opRunTime, bool opIsInitial
			)
		{
			throw new System.NotImplementedException();
		}

		public virtual android.util.Pair<android.content.SyncOperation, long> nextReadyToRun
			(long now)
		{
			throw new System.NotImplementedException();
		}

		public virtual void remove(android.accounts.Account account, string authority)
		{
			throw new System.NotImplementedException();
		}

		public virtual void dump(System.Text.StringBuilder sb)
		{
			throw new System.NotImplementedException();
		}
	}
}
