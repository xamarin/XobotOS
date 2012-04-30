using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IServiceConnection : android.os.IInterface
	{
		[Sharpen.Stub]
		void connected(android.content.ComponentName name, android.os.IBinder service);
	}

	[Sharpen.Stub]
	public static class IServiceConnectionClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IServiceConnection
		{
			internal const string DESCRIPTOR = "android.app.IServiceConnection";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IServiceConnection asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IServiceConnection
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
				[Sharpen.ImplementsInterface(@"android.app.IServiceConnection")]
				public virtual void connected(android.content.ComponentName name, android.os.IBinder
					 service)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_connected = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void connected(android.content.ComponentName arg1, android.os.IBinder
				 arg2);
		}
	}
}
