using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public interface IPowerManager : android.os.IInterface
	{
		[Sharpen.Stub]
		void acquireWakeLock(int flags, android.os.IBinder @lock, string tag, android.os.WorkSource
			 ws);

		[Sharpen.Stub]
		void updateWakeLockWorkSource(android.os.IBinder @lock, android.os.WorkSource ws);

		[Sharpen.Stub]
		void goToSleep(long time);

		[Sharpen.Stub]
		void goToSleepWithReason(long time, int reason);

		[Sharpen.Stub]
		void releaseWakeLock(android.os.IBinder @lock, int flags);

		[Sharpen.Stub]
		void userActivity(long when, bool noChangeLights);

		[Sharpen.Stub]
		void userActivityWithForce(long when, bool noChangeLights, bool force);

		[Sharpen.Stub]
		void clearUserActivityTimeout(long now, long timeout);

		[Sharpen.Stub]
		void setPokeLock(int pokey, android.os.IBinder @lock, string tag);

		[Sharpen.Stub]
		int getSupportedWakeLockFlags();

		[Sharpen.Stub]
		void setStayOnSetting(int val);

		[Sharpen.Stub]
		void setMaximumScreenOffTimeount(int timeMs);

		[Sharpen.Stub]
		void preventScreenOn(bool prevent);

		[Sharpen.Stub]
		bool isScreenOn();

		[Sharpen.Stub]
		void reboot(string reason);

		[Sharpen.Stub]
		void crash(string message);

		[Sharpen.Stub]
		void setBacklightBrightness(int brightness);

		[Sharpen.Stub]
		void setAttentionLight(bool on, int color);
	}

	[Sharpen.Stub]
	public static class IPowerManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.os.IPowerManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.os.IPowerManager asInterface(android.os.IBinder obj)
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

			public abstract void acquireWakeLock(int arg1, android.os.IBinder arg2, string arg3
				, android.os.WorkSource arg4);

			public abstract void clearUserActivityTimeout(long arg1, long arg2);

			public abstract void crash(string arg1);

			public abstract int getSupportedWakeLockFlags();

			public abstract void goToSleep(long arg1);

			public abstract void goToSleepWithReason(long arg1, int arg2);

			public abstract bool isScreenOn();

			public abstract void preventScreenOn(bool arg1);

			public abstract void reboot(string arg1);

			public abstract void releaseWakeLock(android.os.IBinder arg1, int arg2);

			public abstract void setAttentionLight(bool arg1, int arg2);

			public abstract void setBacklightBrightness(int arg1);

			public abstract void setMaximumScreenOffTimeount(int arg1);

			public abstract void setPokeLock(int arg1, android.os.IBinder arg2, string arg3);

			public abstract void setStayOnSetting(int arg1);

			public abstract void updateWakeLockWorkSource(android.os.IBinder arg1, android.os.WorkSource
				 arg2);

			public abstract void userActivity(long arg1, bool arg2);

			public abstract void userActivityWithForce(long arg1, bool arg2, bool arg3);
		}
	}
}
