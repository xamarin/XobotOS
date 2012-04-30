using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class AlarmManager
	{
		public const int RTC_WAKEUP = 0;

		public const int RTC = 1;

		public const int ELAPSED_REALTIME_WAKEUP = 2;

		public const int ELAPSED_REALTIME = 3;

		private readonly android.app.IAlarmManager mService;

		[Sharpen.Stub]
		internal AlarmManager(android.app.IAlarmManager service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void set(int type, long triggerAtTime, android.app.PendingIntent operation
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRepeating(int type, long triggerAtTime, long interval, android.app.PendingIntent
			 operation)
		{
			throw new System.NotImplementedException();
		}

		public const long INTERVAL_FIFTEEN_MINUTES = 15 * 60 * 1000;

		public const long INTERVAL_HALF_HOUR = 2 * INTERVAL_FIFTEEN_MINUTES;

		public const long INTERVAL_HOUR = 2 * INTERVAL_HALF_HOUR;

		public const long INTERVAL_HALF_DAY = 12 * INTERVAL_HOUR;

		public const long INTERVAL_DAY = 2 * INTERVAL_HALF_DAY;

		[Sharpen.Stub]
		public virtual void setInexactRepeating(int type, long triggerAtTime, long interval
			, android.app.PendingIntent operation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancel(android.app.PendingIntent operation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTime(long millis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTimeZone(string timeZone)
		{
			throw new System.NotImplementedException();
		}
	}
}
