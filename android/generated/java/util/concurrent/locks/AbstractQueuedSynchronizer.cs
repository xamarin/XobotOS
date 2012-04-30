using Sharpen;

namespace java.util.concurrent.locks
{
	[System.Serializable]
	[Sharpen.Stub]
	public abstract class AbstractQueuedSynchronizer : java.util.concurrent.locks.AbstractOwnableSynchronizer
	{
		[Sharpen.Stub]
		protected internal AbstractQueuedSynchronizer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal sealed class Node
		{
			[Sharpen.Stub]
			internal bool isShared()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal java.util.concurrent.locks.AbstractQueuedSynchronizer.Node predecessor()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal Node()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal Node(java.lang.Thread thread, java.util.concurrent.locks.AbstractQueuedSynchronizer
				.Node mode)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal Node(java.lang.Thread thread, int waitStatus)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal int getState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void setState(int newState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal bool compareAndSetState(int expect, int update)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal bool acquireQueued(java.util.concurrent.locks.AbstractQueuedSynchronizer
			.Node node, int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool tryAcquire(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool tryRelease(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual int tryAcquireShared(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool tryReleaseShared(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool isHeldExclusively()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void acquire(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void acquireInterruptibly(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool tryAcquireNanos(int arg, long nanosTimeout)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool release(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void acquireShared(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void acquireSharedInterruptibly(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool tryAcquireSharedNanos(int arg, long nanosTimeout)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool releaseShared(int arg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasQueuedThreads()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasContended()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.Thread getFirstQueuedThread()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isQueued(java.lang.Thread thread)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal bool apparentlyFirstQueuedIsExclusive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasQueuedPredecessors()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getQueueLength()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Collection<java.lang.Thread> getQueuedThreads()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Collection<java.lang.Thread> getExclusiveQueuedThreads()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Collection<java.lang.Thread> getSharedQueuedThreads()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal bool isOnSyncQueue(java.util.concurrent.locks.AbstractQueuedSynchronizer
			.Node node)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal bool transferForSignal(java.util.concurrent.locks.AbstractQueuedSynchronizer
			.Node node)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal bool transferAfterCancelledWait(java.util.concurrent.locks.AbstractQueuedSynchronizer
			.Node node)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal int fullyRelease(java.util.concurrent.locks.AbstractQueuedSynchronizer.Node
			 node)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool owns(java.util.concurrent.locks.AbstractQueuedSynchronizer.ConditionObject
			 condition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasWaiters(java.util.concurrent.locks.AbstractQueuedSynchronizer.ConditionObject
			 condition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getWaitQueueLength(java.util.concurrent.locks.AbstractQueuedSynchronizer
			.ConditionObject condition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Collection<java.lang.Thread> getWaitingThreads(java.util.concurrent.locks.AbstractQueuedSynchronizer
			.ConditionObject condition)
		{
			throw new System.NotImplementedException();
		}

		[System.Serializable]
		[Sharpen.Stub]
		public class ConditionObject : java.util.concurrent.locks.Condition
		{
			[Sharpen.Stub]
			public ConditionObject(AbstractQueuedSynchronizer _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Condition")]
			public virtual void signal()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Condition")]
			public virtual void signalAll()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Condition")]
			public virtual void awaitUninterruptibly()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Condition")]
			public virtual void await()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Condition")]
			public virtual long awaitNanos(long nanosTimeout)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Condition")]
			public virtual bool awaitUntil(System.DateTime deadline)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Condition")]
			public virtual bool await(long time, java.util.concurrent.TimeUnit unit)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool isOwnedBy(java.util.concurrent.locks.AbstractQueuedSynchronizer sync
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			protected internal bool hasWaiters()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			protected internal int getWaitQueueLength()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			protected internal java.util.Collection<java.lang.Thread> getWaitingThreads()
			{
				throw new System.NotImplementedException();
			}

			private readonly AbstractQueuedSynchronizer _enclosing;
		}

		static AbstractQueuedSynchronizer()
		{
			throw new System.NotImplementedException();
		}
	}
}
