using Sharpen;

namespace android.os.storage
{
	[Sharpen.Stub]
	public interface IMountShutdownObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void onShutDownComplete(int statusCode);
	}

	[Sharpen.Stub]
	public static class IMountShutdownObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.os.storage.IMountShutdownObserver
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.os.storage.IMountShutdownObserver asInterface(android.os.IBinder
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

			public abstract void onShutDownComplete(int arg1);
		}
	}
}
