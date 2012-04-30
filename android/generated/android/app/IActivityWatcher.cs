using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IActivityWatcher : android.os.IInterface
	{
		[Sharpen.Stub]
		void activityResuming(int activityId);

		[Sharpen.Stub]
		void closingSystemDialogs(string reason);
	}

	[Sharpen.Stub]
	public static class IActivityWatcherClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IActivityWatcher
		{
			internal const string DESCRIPTOR = "android.app.IActivityWatcher";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IActivityWatcher asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IActivityWatcher
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
				[Sharpen.ImplementsInterface(@"android.app.IActivityWatcher")]
				public virtual void activityResuming(int activityId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IActivityWatcher")]
				public virtual void closingSystemDialogs(string reason)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_activityResuming = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_closingSystemDialogs = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void activityResuming(int arg1);

			public abstract void closingSystemDialogs(string arg1);
		}
	}
}
