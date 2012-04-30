using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncContext
	{
		private android.content.ISyncContext mSyncContext;

		private long mLastHeartbeatSendTime;

		internal const long HEARTBEAT_SEND_INTERVAL_IN_MS = 1000;

		[Sharpen.Stub]
		public SyncContext(android.content.ISyncContext syncContextInterface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStatusText(string message)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateHeartbeat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onFinished(android.content.SyncResult result)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.IBinder getSyncContextBinder()
		{
			throw new System.NotImplementedException();
		}
	}
}
