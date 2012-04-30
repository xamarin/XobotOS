using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class PowerManager
	{
		[Sharpen.Stub]
		public class WakeLock
		{
			[Sharpen.Stub]
			internal WakeLock(PowerManager _enclosing, int flags, string tag)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setReferenceCounted(bool value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void acquire()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void acquire(long timeout)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void release()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void release(int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isHeld()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setWorkSource(android.os.WorkSource ws)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			~WakeLock()
			{
				throw new System.NotImplementedException();
			}

			private readonly PowerManager _enclosing;
		}

		[Sharpen.Stub]
		public virtual android.os.PowerManager.WakeLock newWakeLock(int flags, string tag
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void userActivity(long when, bool noChangeLights)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void goToSleep(long time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBacklightBrightness(int brightness)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getSupportedWakeLockFlags()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isScreenOn()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reboot(string reason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PowerManager(android.os.IPowerManager service, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}
	}
}
