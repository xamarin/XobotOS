using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IWallpaperManagerCallback : android.os.IInterface
	{
		[Sharpen.Stub]
		void onWallpaperChanged();
	}

	[Sharpen.Stub]
	public static class IWallpaperManagerCallbackClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IWallpaperManagerCallback
		{
			internal const string DESCRIPTOR = "android.app.IWallpaperManagerCallback";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IWallpaperManagerCallback asInterface(android.os.IBinder
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
			private class Proxy : android.app.IWallpaperManagerCallback
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
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManagerCallback")]
				public virtual void onWallpaperChanged()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onWallpaperChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onWallpaperChanged();
		}
	}
}
