using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface ISearchManagerCallback : android.os.IInterface
	{
		[Sharpen.Stub]
		void onDismiss();

		[Sharpen.Stub]
		void onCancel();
	}

	[Sharpen.Stub]
	public static class ISearchManagerCallbackClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.ISearchManagerCallback
		{
			internal const string DESCRIPTOR = "android.app.ISearchManagerCallback";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.ISearchManagerCallback asInterface(android.os.IBinder obj
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
			private class Proxy : android.app.ISearchManagerCallback
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
				[Sharpen.ImplementsInterface(@"android.app.ISearchManagerCallback")]
				public virtual void onDismiss()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.ISearchManagerCallback")]
				public virtual void onCancel()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onDismiss = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_onCancel = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void onCancel();

			public abstract void onDismiss();
		}
	}
}
