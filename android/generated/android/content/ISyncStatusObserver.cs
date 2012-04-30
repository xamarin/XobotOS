using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface ISyncStatusObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void onStatusChanged(int which);
	}

	[Sharpen.Stub]
	public static class ISyncStatusObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.ISyncStatusObserver
		{
			internal const string DESCRIPTOR = "android.content.ISyncStatusObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ISyncStatusObserver asInterface(android.os.IBinder 
				obj)
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
			private class Proxy : android.content.ISyncStatusObserver
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
				[Sharpen.ImplementsInterface(@"android.content.ISyncStatusObserver")]
				public virtual void onStatusChanged(int which)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onStatusChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onStatusChanged(int arg1);
		}
	}
}
