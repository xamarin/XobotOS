using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncManager : android.accounts.OnAccountsUpdateListener
	{
		static SyncManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class _BroadcastReceiver_163 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_163(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private sealed class _BroadcastReceiver_182 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_182(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private sealed class _BroadcastReceiver_188 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_188(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		public virtual void onAccountsUpdated(android.accounts.Account[] accounts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class _BroadcastReceiver_243 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_243(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private sealed class _BroadcastReceiver_289 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_289(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		public SyncManager(android.content.Context context, bool factoryTest)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class _RegisteredServicesCacheListener_328 : android.content.pm.RegisteredServicesCacheListener
			<android.content.SyncAdapterType>
		{
			public _RegisteredServicesCacheListener_328(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			public void onServiceChanged(android.content.SyncAdapterType type, bool removed)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class _Stub_380 : android.content.ISyncStatusObserverClass.Stub
		{
			public _Stub_380(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.ImplementsInterface(@"android.content.ISyncStatusObserver")]
			public override void onStatusChanged(int which)
			{
				throw new System.NotImplementedException();
			}
		}

		public virtual android.content.SyncStorageEngine getSyncStorageEngine()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class InitializerServiceConnection : android.content.ServiceConnection
		{
			public InitializerServiceConnection(android.accounts.Account account, string authority
				, android.content.Context context, android.os.Handler handler)
			{
				throw new System.NotImplementedException();
			}

			public virtual void onServiceConnected(android.content.ComponentName name, android.os.IBinder
				 service)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private sealed class _IRunnable_474 : java.lang.Runnable
			{
				public _IRunnable_474(InitializerServiceConnection _enclosing)
				{
					throw new System.NotImplementedException();
				}

				public void run()
				{
					throw new System.NotImplementedException();
				}
			}

			public virtual void onServiceDisconnected(android.content.ComponentName name)
			{
				throw new System.NotImplementedException();
			}
		}

		public virtual void scheduleSync(android.accounts.Account requestedAccount, string
			 requestedAuthority, android.os.Bundle extras, long delay, bool onlyThoseWithUnkownSyncableState
			)
		{
			throw new System.NotImplementedException();
		}

		public virtual void scheduleLocalSync(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		public virtual android.content.SyncAdapterType[] getSyncAdapterTypes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class SyncHandlerMessagePayload
		{
			internal SyncHandlerMessagePayload(SyncManager _enclosing, android.content.SyncManager.ActiveSyncContext
				 syncContext, android.content.SyncResult syncResult)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class SyncAlarmIntentReceiver : android.content.BroadcastReceiver
		{
			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}

			internal SyncAlarmIntentReceiver(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}
		}

		public virtual void cancelActiveSync(android.accounts.Account account, string authority
			)
		{
			throw new System.NotImplementedException();
		}

		public virtual void scheduleSyncOperation(android.content.SyncOperation syncOperation
			)
		{
			throw new System.NotImplementedException();
		}

		public virtual void clearScheduledSyncOperations(android.accounts.Account account
			, string authority)
		{
			throw new System.NotImplementedException();
		}

		internal virtual void maybeRescheduleSync(android.content.SyncResult syncResult, 
			android.content.SyncOperation operation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class ActiveSyncContext : android.content.ISyncContextClass.Stub, android.content.ServiceConnection
		{
			public ActiveSyncContext(SyncManager _enclosing, android.content.SyncOperation syncOperation
				, long historyRowId) : base()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.ImplementsInterface(@"android.content.ISyncContext")]
			public override void sendHeartbeat()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.ImplementsInterface(@"android.content.ISyncContext")]
			public override void onFinished(android.content.SyncResult result)
			{
				throw new System.NotImplementedException();
			}

			public virtual void toString(System.Text.StringBuilder sb)
			{
				throw new System.NotImplementedException();
			}

			public virtual void onServiceConnected(android.content.ComponentName name, android.os.IBinder
				 service)
			{
				throw new System.NotImplementedException();
			}

			public virtual void onServiceDisconnected(android.content.ComponentName name)
			{
				throw new System.NotImplementedException();
			}

			internal virtual bool bindToSyncAdapter(android.content.pm.RegisteredServicesCache<
				android.content.SyncAdapterType>.ServiceInfo info)
			{
				throw new System.NotImplementedException();
			}

			protected internal virtual void close()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		protected internal virtual void dump(java.io.FileDescriptor fd, java.io.PrintWriter
			 pw)
		{
			throw new System.NotImplementedException();
		}

		internal static string formatTime(long time)
		{
			throw new System.NotImplementedException();
		}

		protected internal virtual void dumpSyncState(java.io.PrintWriter pw, System.Text.StringBuilder
			 sb)
		{
			throw new System.NotImplementedException();
		}

		protected internal virtual void dumpSyncHistory(java.io.PrintWriter pw, System.Text.StringBuilder
			 sb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class SyncTimeTracker
		{
			public virtual void update()
			{
				throw new System.NotImplementedException();
			}

			public virtual long timeSpentSyncing()
			{
				throw new System.NotImplementedException();
			}

			internal SyncTimeTracker(SyncManager _enclosing)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class ServiceConnectionData
		{
			internal ServiceConnectionData(SyncManager _enclosing, android.content.SyncManager.ActiveSyncContext
				 activeSyncContext, android.content.ISyncAdapter syncAdapter)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class SyncHandler : android.os.Handler
		{
			public virtual void onBootCompleted()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal class SyncNotificationInfo
			{
				public virtual void toString(System.Text.StringBuilder sb)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.OverridesMethod(@"java.lang.Object")]
				public override string ToString()
				{
					throw new System.NotImplementedException();
				}

				internal SyncNotificationInfo(SyncHandler _enclosing)
				{
					throw new System.NotImplementedException();
				}
			}

			public SyncHandler(SyncManager _enclosing, android.os.Looper looper) : base(looper
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			public virtual long insertStartSyncEvent(android.content.SyncOperation syncOperation
				)
			{
				throw new System.NotImplementedException();
			}

			public virtual void stopSyncEvent(long rowId, android.content.SyncOperation syncOperation
				, string resultMessage, int upstreamActivity, int downstreamActivity, long elapsedTime
				)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
