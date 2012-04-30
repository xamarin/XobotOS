using Sharpen;
using System;
using System.Threading;

namespace android.os
{
	/// <summary>Core timekeeping facilities.</summary>
	/// <remarks>
	/// Core timekeeping facilities.
	/// <p> Three different clocks are available, and they should not be confused:
	/// <ul>
	/// <li> <p>
	/// <see cref="java.lang.System.currentTimeMillis()">System.currentTimeMillis()</see>
	/// is the standard "wall" clock (time and date) expressing milliseconds
	/// since the epoch.  The wall clock can be set by the user or the phone
	/// network (see
	/// <see cref="setCurrentTimeMillis(long)">setCurrentTimeMillis(long)</see>
	/// ), so the time may jump
	/// backwards or forwards unpredictably.  This clock should only be used
	/// when correspondence with real-world dates and times is important, such
	/// as in a calendar or alarm clock application.  Interval or elapsed
	/// time measurements should use a different clock.  If you are using
	/// System.currentTimeMillis(), consider listening to the
	/// <see cref="android.content.Intent.ACTION_TIME_TICK">ACTION_TIME_TICK</see>
	/// ,
	/// <see cref="android.content.Intent.ACTION_TIME_CHANGED">ACTION_TIME_CHANGED</see>
	/// and
	/// <see cref="android.content.Intent.ACTION_TIMEZONE_CHANGED">ACTION_TIMEZONE_CHANGED
	/// 	</see>
	/// 
	/// <see cref="android.content.Intent">Intent</see>
	/// broadcasts to find out when the time changes.
	/// <li> <p>
	/// <see cref="uptimeMillis()">uptimeMillis()</see>
	/// is counted in milliseconds since the
	/// system was booted.  This clock stops when the system enters deep
	/// sleep (CPU off, display dark, device waiting for external input),
	/// but is not affected by clock scaling, idle, or other power saving
	/// mechanisms.  This is the basis for most interval timing
	/// such as
	/// <see cref="java.lang.Thread.sleep(long)">Thread.sleep(millls)</see>
	/// ,
	/// <see cref="System.Threading.Monitor.Wait(long)">Object.wait(millis)</see>
	/// , and
	/// <see cref="java.lang.System.nanoTime()">System.nanoTime()</see>
	/// .  This clock is guaranteed
	/// to be monotonic, and is the recommended basis for the general purpose
	/// interval timing of user interface events, performance measurements,
	/// and anything else that does not need to measure elapsed time during
	/// device sleep.  Most methods that accept a timestamp value expect the
	/// <see cref="uptimeMillis()">uptimeMillis()</see>
	/// clock.
	/// <li> <p>
	/// <see cref="elapsedRealtime()">elapsedRealtime()</see>
	/// is counted in milliseconds since the
	/// system was booted, including deep sleep.  This clock should be used
	/// when measuring time intervals that may span periods of system sleep.
	/// </ul>
	/// There are several mechanisms for controlling the timing of events:
	/// <ul>
	/// <li> <p> Standard functions like
	/// <see cref="java.lang.Thread.sleep(long)">Thread.sleep(millis)</see>
	/// and
	/// <see cref="System.Threading.Monitor.Wait(long)">Object.wait(millis)</see>
	/// are always available.  These functions use the
	/// <see cref="uptimeMillis()">uptimeMillis()</see>
	/// clock; if the device enters sleep, the remainder of the time will be
	/// postponed until the device wakes up.  These synchronous functions may
	/// be interrupted with
	/// <see cref="java.lang.Thread.interrupt()">Thread.interrupt()</see>
	/// , and
	/// you must handle
	/// <see cref="System.Exception">System.Exception</see>
	/// .
	/// <li> <p>
	/// <see cref="sleep(long)">SystemClock.sleep(millis)</see>
	/// is a utility function
	/// very similar to
	/// <see cref="java.lang.Thread.sleep(long)">Thread.sleep(millis)</see>
	/// , but it
	/// ignores
	/// <see cref="System.Exception">System.Exception</see>
	/// .  Use this function for delays if
	/// you do not use
	/// <see cref="java.lang.Thread.interrupt()">Thread.interrupt()</see>
	/// , as it will
	/// preserve the interrupted state of the thread.
	/// <li> <p> The
	/// <see cref="Handler">Handler</see>
	/// class can schedule asynchronous
	/// callbacks at an absolute or relative time.  Handler objects also use the
	/// <see cref="uptimeMillis()">uptimeMillis()</see>
	/// clock, and require an
	/// <see cref="Looper">event loop</see>
	/// (normally present in any GUI application).
	/// <li> <p> The
	/// <see cref="android.app.AlarmManager">android.app.AlarmManager</see>
	/// can trigger one-time or
	/// recurring events which occur even when the device is in deep sleep
	/// or your application is not running.  Events may be scheduled with your
	/// choice of
	/// <see cref="java.lang.System.currentTimeMillis()">java.lang.System.currentTimeMillis()
	/// 	</see>
	/// (RTC) or
	/// <see cref="elapsedRealtime()">elapsedRealtime()</see>
	/// (ELAPSED_REALTIME), and cause an
	/// <see cref="android.content.Intent">android.content.Intent</see>
	/// broadcast when they occur.
	/// </ul>
	/// </remarks>
	public static class SystemClock
	{
		// This space intentionally left blank.
		/// <summary>Waits a given number of milliseconds (of uptimeMillis) before returning.
		/// 	</summary>
		/// <remarks>
		/// Waits a given number of milliseconds (of uptimeMillis) before returning.
		/// Similar to
		/// <see cref="java.lang.Thread.sleep(long)">java.lang.Thread.sleep(long)</see>
		/// , but does not throw
		/// <see cref="System.Exception">System.Exception</see>
		/// ;
		/// <see cref="java.lang.Thread.interrupt()">java.lang.Thread.interrupt()</see>
		/// events are
		/// deferred until the next interruptible operation.  Does not return until
		/// at least the specified number of milliseconds has elapsed.
		/// </remarks>
		/// <param name="ms">to sleep before returning, in milliseconds of uptime.</param>
		public static void sleep (long ms)
		{
			Thread.Sleep ((int)ms);
		}

		/// <summary>Sets the current wall time, in milliseconds.</summary>
		/// <remarks>
		/// Sets the current wall time, in milliseconds.  Requires the calling
		/// process to have appropriate permissions.
		/// </remarks>
		/// <returns>if the clock was successfully set to the specified time.</returns>
		[Sharpen.Stub]
		public static bool setCurrentTimeMillis (long millis)
		{
			throw new System.NotImplementedException ();
		}

		/// <summary>Returns milliseconds since boot, not counting time spent in deep sleep.</summary>
		/// <remarks>
		/// Returns milliseconds since boot, not counting time spent in deep sleep.
		/// <b>Note:</b> This value may get reset occasionally (before it would
		/// otherwise wrap around).
		/// </remarks>
		/// <returns>milliseconds of non-sleep uptime since boot.</returns>
		public static long uptimeMillis ()
		{
			return unchecked ((uint) System.Environment.TickCount);
		}

		/// <summary>Returns milliseconds since boot, including time spent in sleep.</summary>
		/// <remarks>Returns milliseconds since boot, including time spent in sleep.</remarks>
		/// <returns>elapsed milliseconds since boot.</returns>
		public static long elapsedRealtime ()
		{
			return uptimeMillis ();
		}

		/// <summary>Returns milliseconds running in the current thread.</summary>
		/// <remarks>Returns milliseconds running in the current thread.</remarks>
		/// <returns>elapsed milliseconds in the thread</returns>
		[Sharpen.Stub]
		public static long currentThreadTimeMillis ()
		{
			throw new System.NotImplementedException ();
		}

		/// <summary>Returns microseconds running in the current thread.</summary>
		/// <remarks>Returns microseconds running in the current thread.</remarks>
		/// <returns>elapsed microseconds in the thread</returns>
		/// <hide></hide>
		[Sharpen.Stub]
		public static long currentThreadTimeMicro ()
		{
			throw new System.NotImplementedException ();
		}

		/// <summary>Returns current wall time in  microseconds.</summary>
		/// <remarks>Returns current wall time in  microseconds.</remarks>
		/// <returns>elapsed microseconds in wall time</returns>
		/// <hide></hide>
		public static long currentTimeMicro ()
		{
			return DateTime.Now.Ticks;
		}
	}
}
