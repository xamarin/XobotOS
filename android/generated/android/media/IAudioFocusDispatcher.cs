using Sharpen;

namespace android.media
{
	[Sharpen.Stub]
	public interface IAudioFocusDispatcher : android.os.IInterface
	{
		[Sharpen.Stub]
		void dispatchAudioFocusChange(int focusChange, string clientId);
	}

	[Sharpen.Stub]
	public static class IAudioFocusDispatcherClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.media.IAudioFocusDispatcher
		{
			internal const string DESCRIPTOR = "android.media.IAudioFocusDispatcher";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.media.IAudioFocusDispatcher asInterface(android.os.IBinder 
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
			private class Proxy : android.media.IAudioFocusDispatcher
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
				[Sharpen.ImplementsInterface(@"android.media.IAudioFocusDispatcher")]
				public virtual void dispatchAudioFocusChange(int focusChange, string clientId)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_dispatchAudioFocusChange = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void dispatchAudioFocusChange(int arg1, string arg2);
		}
	}
}
