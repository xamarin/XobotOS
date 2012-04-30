using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncOperation : java.lang.Comparable<object>
	{
		public readonly android.accounts.Account account;

		public int syncSource;

		public string authority;

		public readonly bool allowParallelSyncs;

		public android.os.Bundle extras;

		public readonly string key;

		public long earliestRunTime;

		public bool expedited;

		public android.content.SyncStorageEngine.PendingOperation pendingOperation;

		public long backoff;

		public long delayUntil;

		public long effectiveRunTime;

		[Sharpen.Stub]
		public SyncOperation(android.accounts.Account account, int source, string authority
			, android.os.Bundle extras, long delayInMs, long backoff, long delayUntil, bool 
			allowParallelSyncs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void removeFalseExtra(string extraName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal SyncOperation(android.content.SyncOperation other)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string dump(bool useOneLine)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isInitialization()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool ignoreBackoff()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string toKey()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void extrasToStringBuilder(android.os.Bundle bundle, java.lang.StringBuilder
			 sb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateEffectiveRunTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(object o)
		{
			throw new System.NotImplementedException();
		}
	}
}
