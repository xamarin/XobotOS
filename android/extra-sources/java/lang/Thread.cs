using System;
using ST = System.Threading;

namespace java.lang
{
	public class Thread
	{
		readonly ST.Thread thread;
		static readonly ST.ThreadLocal<Thread> current_thread = new ST.ThreadLocal<Thread> ();
		Runnable target;

		private Thread (ST.Thread thread)
		{
			this.thread = thread;
		}

		public Thread (string name)
		{
			throw new NotImplementedException ();
		}

		public virtual void run ()
		{
			if (target != null)
				target.run ();
		}

		public long getId ()
		{
			return thread.ManagedThreadId;
		}

		public static void sleep (long time)
		{
			ST.Thread.Sleep ((int)time);
		}
		
		public static Thread currentThread ()
		{
			if (!current_thread.IsValueCreated)
				current_thread.Value = new Thread (ST.Thread.CurrentThread);
			return current_thread.Value;
		}
	}
}
