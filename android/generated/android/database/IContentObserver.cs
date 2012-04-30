using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public interface IContentObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void onChange(bool selfUpdate);
	}

	[Sharpen.Stub]
	public static class IContentObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.database.IContentObserver
		{
			internal const string DESCRIPTOR = "android.database.IContentObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.IContentObserver asInterface(android.os.IBinder obj
				)
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
			private class Proxy : android.database.IContentObserver
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
				[Sharpen.ImplementsInterface(@"android.database.IContentObserver")]
				public virtual void onChange(bool selfUpdate)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onChange = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onChange(bool arg1);
		}
	}
}
