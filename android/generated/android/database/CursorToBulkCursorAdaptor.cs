using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public sealed class CursorToBulkCursorAdaptor : android.database.BulkCursorNative
		, android.os.IBinderClass.DeathRecipient
	{
		internal const string TAG = "Cursor";

		private readonly object mLock = new object();

		private readonly string mProviderName;

		private android.database.CursorToBulkCursorAdaptor.ContentObserverProxy mObserver;

		private android.database.CrossProcessCursor mCursor;

		private android.database.CursorWindow mWindowForNonWindowedCursor;

		private bool mWindowForNonWindowedCursorWasFilled;

		[Sharpen.Stub]
		private sealed class ContentObserverProxy : android.database.ContentObserver
		{
			protected internal android.database.IContentObserver mRemote;

			[Sharpen.Stub]
			public ContentObserverProxy(android.database.IContentObserver remoteObserver, android.os.IBinderClass
				.DeathRecipient recipient) : base(null)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public bool unlinkToDeath(android.os.IBinderClass.DeathRecipient recipient)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override bool deliverSelfNotifications()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override void onChange(bool selfChange)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public CursorToBulkCursorAdaptor(android.database.Cursor cursor, android.database.IContentObserver
			 observer, string providerName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void closeWindowForNonWindowedCursorLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void disposeLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void throwIfCursorIsClosed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder.DeathRecipient")]
		public void binderDied()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override android.database.CursorWindow getWindow(int startPos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override void onMove(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override int count()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override string[] getColumnNames()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override void deactivate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override int requery(android.database.IContentObserver observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override bool getWantsAllOnMoveCalls()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void createAndRegisterObserverProxyLocked(android.database.IContentObserver
			 observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void unregisterObserverProxyLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override android.os.Bundle getExtras()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public override android.os.Bundle respond(android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}
	}
}
