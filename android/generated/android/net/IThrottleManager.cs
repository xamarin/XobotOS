using Sharpen;

namespace android.net
{
	[Sharpen.Stub]
	public interface IThrottleManager : android.os.IInterface
	{
		[Sharpen.Stub]
		long getByteCount(string iface, int dir, int period, int ago);

		[Sharpen.Stub]
		int getThrottle(string iface);

		[Sharpen.Stub]
		long getResetTime(string iface);

		[Sharpen.Stub]
		long getPeriodStartTime(string iface);

		[Sharpen.Stub]
		long getCliffThreshold(string iface, int cliff);

		[Sharpen.Stub]
		int getCliffLevel(string iface, int cliff);

		[Sharpen.Stub]
		string getHelpUri();
	}

	[Sharpen.Stub]
	public static class IThrottleManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.net.IThrottleManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.net.IThrottleManager asInterface(android.os.IBinder obj)
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

			public abstract long getByteCount(string arg1, int arg2, int arg3, int arg4);

			public abstract int getCliffLevel(string arg1, int arg2);

			public abstract long getCliffThreshold(string arg1, int arg2);

			public abstract string getHelpUri();

			public abstract long getPeriodStartTime(string arg1);

			public abstract long getResetTime(string arg1);

			public abstract int getThrottle(string arg1);
		}
	}
}
