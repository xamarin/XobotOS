using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface ITransientNotification : android.os.IInterface
	{
		[Sharpen.Stub]
		void show();

		[Sharpen.Stub]
		void hide();
	}

	[Sharpen.Stub]
	public static class ITransientNotificationClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.ITransientNotification
		{
			internal const string DESCRIPTOR = "android.app.ITransientNotification";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.ITransientNotification asInterface(android.os.IBinder obj
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
			private class Proxy : android.app.ITransientNotification
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
				[Sharpen.ImplementsInterface(@"android.app.ITransientNotification")]
				public virtual void show()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.ITransientNotification")]
				public virtual void hide()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_show = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_hide = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void hide();

			public abstract void show();
		}
	}
}
