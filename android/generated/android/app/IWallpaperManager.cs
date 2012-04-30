using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IWallpaperManager : android.os.IInterface
	{
		[Sharpen.Stub]
		android.os.ParcelFileDescriptor setWallpaper(string name);

		[Sharpen.Stub]
		void setWallpaperComponent(android.content.ComponentName name);

		[Sharpen.Stub]
		android.os.ParcelFileDescriptor getWallpaper(android.app.IWallpaperManagerCallback
			 cb, android.os.Bundle outParams);

		[Sharpen.Stub]
		android.app.WallpaperInfo getWallpaperInfo();

		[Sharpen.Stub]
		void clearWallpaper();

		[Sharpen.Stub]
		void setDimensionHints(int width, int height);

		[Sharpen.Stub]
		int getWidthHint();

		[Sharpen.Stub]
		int getHeightHint();
	}

	[Sharpen.Stub]
	public static class IWallpaperManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IWallpaperManager
		{
			internal const string DESCRIPTOR = "android.app.IWallpaperManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IWallpaperManager asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IWallpaperManager
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
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual android.os.ParcelFileDescriptor setWallpaper(string name)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual void setWallpaperComponent(android.content.ComponentName name)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual android.os.ParcelFileDescriptor getWallpaper(android.app.IWallpaperManagerCallback
					 cb, android.os.Bundle outParams)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual android.app.WallpaperInfo getWallpaperInfo()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual void clearWallpaper()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual void setDimensionHints(int width, int height)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual int getWidthHint()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IWallpaperManager")]
				public virtual int getHeightHint()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_setWallpaper = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_setWallpaperComponent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getWallpaper = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_getWallpaperInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_clearWallpaper = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_setDimensionHints = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_getWidthHint = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_getHeightHint = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			public abstract void clearWallpaper();

			public abstract int getHeightHint();

			public abstract android.os.ParcelFileDescriptor getWallpaper(android.app.IWallpaperManagerCallback
				 arg1, android.os.Bundle arg2);

			public abstract android.app.WallpaperInfo getWallpaperInfo();

			public abstract int getWidthHint();

			public abstract void setDimensionHints(int arg1, int arg2);

			public abstract android.os.ParcelFileDescriptor setWallpaper(string arg1);

			public abstract void setWallpaperComponent(android.content.ComponentName arg1);
		}
	}
}
