using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IThumbnailReceiver : android.os.IInterface
	{
		[Sharpen.Stub]
		void newThumbnail(int id, android.graphics.Bitmap thumbnail, java.lang.CharSequence
			 description);

		[Sharpen.Stub]
		void finished();
	}

	[Sharpen.Stub]
	public static class IThumbnailReceiverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IThumbnailReceiver
		{
			internal const string DESCRIPTOR = "android.app.IThumbnailReceiver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IThumbnailReceiver asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IThumbnailReceiver
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
				[Sharpen.ImplementsInterface(@"android.app.IThumbnailReceiver")]
				public virtual void newThumbnail(int id, android.graphics.Bitmap thumbnail, java.lang.CharSequence
					 description)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IThumbnailReceiver")]
				public virtual void finished()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_newThumbnail = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_finished = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void finished();

			public abstract void newThumbnail(int arg1, android.graphics.Bitmap arg2, java.lang.CharSequence
				 arg3);
		}
	}
}
