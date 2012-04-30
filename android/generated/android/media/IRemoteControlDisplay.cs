using Sharpen;

namespace android.media
{
	[Sharpen.Stub]
	public interface IRemoteControlDisplay : android.os.IInterface
	{
		[Sharpen.Stub]
		void setCurrentClientId(int clientGeneration, android.app.PendingIntent clientMediaIntent
			, bool clearing);

		[Sharpen.Stub]
		void setPlaybackState(int generationId, int state, long stateChangeTimeMs);

		[Sharpen.Stub]
		void setTransportControlFlags(int generationId, int transportControlFlags);

		[Sharpen.Stub]
		void setMetadata(int generationId, android.os.Bundle metadata);

		[Sharpen.Stub]
		void setArtwork(int generationId, android.graphics.Bitmap artwork);

		[Sharpen.Stub]
		void setAllMetadata(int generationId, android.os.Bundle metadata, android.graphics.Bitmap
			 artwork);
	}

	[Sharpen.Stub]
	public static class IRemoteControlDisplayClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.media.IRemoteControlDisplay
		{
			internal const string DESCRIPTOR = "android.media.IRemoteControlDisplay";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.media.IRemoteControlDisplay asInterface(android.os.IBinder 
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
			private class Proxy : android.media.IRemoteControlDisplay
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
				[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
				public virtual void setCurrentClientId(int clientGeneration, android.app.PendingIntent
					 clientMediaIntent, bool clearing)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
				public virtual void setPlaybackState(int generationId, int state, long stateChangeTimeMs
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
				public virtual void setTransportControlFlags(int generationId, int transportControlFlags
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
				public virtual void setMetadata(int generationId, android.os.Bundle metadata)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
				public virtual void setArtwork(int generationId, android.graphics.Bitmap artwork)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
				public virtual void setAllMetadata(int generationId, android.os.Bundle metadata, 
					android.graphics.Bitmap artwork)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_setCurrentClientId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_setPlaybackState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_setTransportControlFlags = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_setMetadata = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_setArtwork = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_setAllMetadata = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			public abstract void setAllMetadata(int arg1, android.os.Bundle arg2, android.graphics.Bitmap
				 arg3);

			public abstract void setArtwork(int arg1, android.graphics.Bitmap arg2);

			public abstract void setCurrentClientId(int arg1, android.app.PendingIntent arg2, 
				bool arg3);

			public abstract void setMetadata(int arg1, android.os.Bundle arg2);

			public abstract void setPlaybackState(int arg1, int arg2, long arg3);

			public abstract void setTransportControlFlags(int arg1, int arg2);
		}
	}
}
