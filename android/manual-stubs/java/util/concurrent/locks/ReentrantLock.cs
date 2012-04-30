using Sharpen;

namespace java.util.concurrent.locks
{
	[System.Serializable]
	[Sharpen.Stub]
	public class ReentrantLock : java.util.concurrent.locks.Lock
	{
		public ReentrantLock()
		{
			throw new System.NotImplementedException();
		}

		public ReentrantLock(bool fair)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Lock")]
		public virtual void @lock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Lock")]
		public virtual void lockInterruptibly()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Lock")]
		public virtual bool tryLock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Lock")]
		public virtual bool tryLock(long timeout, java.util.concurrent.TimeUnit unit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Lock")]
		public virtual void unlock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"java.util.concurrent.locks.Lock")]
		public virtual java.util.concurrent.locks.Condition newCondition()
		{
			throw new System.NotImplementedException();
		}

		public virtual int getHoldCount()
		{
			throw new System.NotImplementedException();
		}

		public virtual bool isHeldByCurrentThread()
		{
			throw new System.NotImplementedException();
		}

		public virtual bool isLocked()
		{
			throw new System.NotImplementedException();
		}

		public bool isFair()
		{
			throw new System.NotImplementedException();
		}

		protected internal virtual java.lang.Thread getOwner()
		{
			throw new System.NotImplementedException();
		}

		public bool hasQueuedThreads()
		{
			throw new System.NotImplementedException();
		}

		public bool hasQueuedThread(java.lang.Thread thread)
		{
			throw new System.NotImplementedException();
		}

		public int getQueueLength()
		{
			throw new System.NotImplementedException();
		}

		protected internal virtual System.Collections.Generic.ICollection<java.lang.Thread
			> getQueuedThreads()
		{
			throw new System.NotImplementedException();
		}

		public virtual bool hasWaiters(java.util.concurrent.locks.Condition condition)
		{
			throw new System.NotImplementedException();
		}

		public virtual int getWaitQueueLength(java.util.concurrent.locks.Condition condition
			)
		{
			throw new System.NotImplementedException();
		}

		protected internal virtual System.Collections.Generic.ICollection<java.lang.Thread
			> getWaitingThreads(java.util.concurrent.locks.Condition condition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
