using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public abstract class ContentObserver
	{
		private android.database.ContentObserver.Transport mTransport;

		private object @lock = new object();

		internal android.os.Handler mHandler;

		[Sharpen.Stub]
		private sealed class NotificationRunnable : java.lang.Runnable
		{
			internal bool mSelf;

			[Sharpen.Stub]
			public NotificationRunnable(ContentObserver _enclosing, bool self)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}

			private readonly ContentObserver _enclosing;
		}

		[Sharpen.Stub]
		private sealed class Transport : android.database.IContentObserverClass.Stub
		{
			internal android.database.ContentObserver mContentObserver;

			[Sharpen.Stub]
			public Transport(android.database.ContentObserver contentObserver)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public bool deliverSelfNotifications()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.database.IContentObserver")]
			public override void onChange(bool selfChange)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void releaseContentObserver()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public ContentObserver(android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.IContentObserver getContentObserver()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.IContentObserver releaseContentObserver()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool deliverSelfNotifications()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onChange(bool selfChange)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchChange(bool selfChange)
		{
			throw new System.NotImplementedException();
		}
	}
}
