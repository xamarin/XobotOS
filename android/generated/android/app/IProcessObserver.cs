using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IProcessObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void onForegroundActivitiesChanged(int pid, int uid, bool foregroundActivities);

		[Sharpen.Stub]
		void onProcessDied(int pid, int uid);
	}

	[Sharpen.Stub]
	public static class IProcessObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IProcessObserver
		{
			internal const string DESCRIPTOR = "android.app.IProcessObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IProcessObserver asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IProcessObserver
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
				[Sharpen.ImplementsInterface(@"android.app.IProcessObserver")]
				public virtual void onForegroundActivitiesChanged(int pid, int uid, bool foregroundActivities
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IProcessObserver")]
				public virtual void onProcessDied(int pid, int uid)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onForegroundActivitiesChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_onProcessDied = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void onForegroundActivitiesChanged(int arg1, int arg2, bool arg3);

			public abstract void onProcessDied(int arg1, int arg2);
		}
	}
}
