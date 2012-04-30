using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class QueuedWork
	{
		private static readonly java.util.concurrent.ConcurrentLinkedQueue<java.lang.Runnable
			> sPendingWorkFinishers = new java.util.concurrent.ConcurrentLinkedQueue<java.lang.Runnable
			>();

		private static java.util.concurrent.ExecutorService sSingleThreadExecutor = null;

		[Sharpen.Stub]
		public static java.util.concurrent.ExecutorService singleThreadExecutor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void add(java.lang.Runnable finisher)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void remove(java.lang.Runnable finisher)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void waitToFinish()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool hasPendingWork()
		{
			throw new System.NotImplementedException();
		}
	}
}
