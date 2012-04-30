using Sharpen;

namespace java.util.concurrent
{
	[Sharpen.Stub]
	public class FutureTask<V> : java.util.concurrent.RunnableFuture<V>
	{
		private readonly java.util.concurrent.FutureTask<V>.Sync sync;

		[Sharpen.Stub]
		public FutureTask(java.util.concurrent.Callable<V> callable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FutureTask(java.lang.Runnable runnable, V result)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.concurrent.Future")]
		public virtual bool isCancelled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.concurrent.Future")]
		public virtual bool isDone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.concurrent.Future")]
		public virtual bool cancel(bool mayInterruptIfRunning)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.concurrent.Future")]
		public virtual V get()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.concurrent.Future")]
		public virtual V get(long timeout, java.util.concurrent.TimeUnit unit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void done()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void set(V v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void setException(System.Exception t)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
		public virtual void run()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool runAndReset()
		{
			throw new System.NotImplementedException();
		}

		[System.Serializable]
		[Sharpen.Stub]
		private sealed class Sync : java.util.concurrent.locks.AbstractQueuedSynchronizer
		{
			internal const long serialVersionUID = -7828117401763700385L;

			internal const int READY = 0;

			internal const int RUNNING = 1;

			internal const int RAN = 2;

			internal const int CANCELLED = 4;

			internal readonly java.util.concurrent.Callable<V> callable;

			internal V result;

			internal System.Exception exception;

			internal volatile java.lang.Thread runner;

			[Sharpen.Stub]
			internal Sync(FutureTask<V> _enclosing, java.util.concurrent.Callable<V> callable
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool ranOrCancelled(int state)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.util.concurrent.locks.AbstractQueuedSynchronizer"
				)]
			protected internal override int tryAcquireShared(int ignore)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.util.concurrent.locks.AbstractQueuedSynchronizer"
				)]
			protected internal override bool tryReleaseShared(int ignore)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool innerIsCancelled()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool innerIsDone()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal V innerGet()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal V innerGet(long nanosTimeout)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void innerSet(V v)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void innerSetException(System.Exception t)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool innerCancel(bool mayInterruptIfRunning)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void innerRun()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool innerRunAndReset()
			{
				throw new System.NotImplementedException();
			}

			private readonly FutureTask<V> _enclosing;
		}
	}
}
