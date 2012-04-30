using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IThumbnailRetriever : android.os.IInterface
	{
		[Sharpen.Stub]
		android.graphics.Bitmap getThumbnail(int index);
	}

	[Sharpen.Stub]
	public static class IThumbnailRetrieverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IThumbnailRetriever
		{
			internal const string DESCRIPTOR = "android.app.IThumbnailRetriever";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IThumbnailRetriever asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IThumbnailRetriever
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
				[Sharpen.ImplementsInterface(@"android.app.IThumbnailRetriever")]
				public virtual android.graphics.Bitmap getThumbnail(int index)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_getThumbnail = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract android.graphics.Bitmap getThumbnail(int arg1);
		}
	}
}
