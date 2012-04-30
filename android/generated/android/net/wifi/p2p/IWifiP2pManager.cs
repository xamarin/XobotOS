using Sharpen;

namespace android.net.wifi.p2p
{
	[Sharpen.Stub]
	public interface IWifiP2pManager : android.os.IInterface
	{
		[Sharpen.Stub]
		android.os.Messenger getMessenger();
	}

	[Sharpen.Stub]
	public static class IWifiP2pManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.net.wifi.p2p.IWifiP2pManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.net.wifi.p2p.IWifiP2pManager asInterface(android.os.IBinder
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

			public abstract android.os.Messenger getMessenger();
		}
	}
}
