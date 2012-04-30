using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface ISyncContext : android.os.IInterface
	{
		[Sharpen.Stub]
		void sendHeartbeat();

		[Sharpen.Stub]
		void onFinished(android.content.SyncResult result);
	}

	[Sharpen.Stub]
	public static class ISyncContextClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.ISyncContext
		{
			internal const string DESCRIPTOR = "android.content.ISyncContext";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ISyncContext asInterface(android.os.IBinder obj)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
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
			private class Proxy : android.content.ISyncContext
			{
				internal android.os.IBinder mRemote;

				[Sharpen.Stub]
				internal Proxy(android.os.IBinder remote)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.IInterface")]
				public virtual android.os.IBinder asBinder()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public virtual string getInterfaceDescriptor()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.ISyncContext")]
				public virtual void sendHeartbeat()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.ISyncContext")]
				public virtual void onFinished(android.content.SyncResult result)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_sendHeartbeat = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_onFinished = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void onFinished(android.content.SyncResult arg1);

			public abstract void sendHeartbeat();
		}
	}
}
