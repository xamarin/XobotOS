using Sharpen;

namespace android.util
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	internal class SynchronizedPool<T> : android.util.Pool<T> where T:android.util.Poolable
		<T>
	{
		private readonly android.util.Pool<T> mPool;

		private readonly object mLock;

		public SynchronizedPool(android.util.Pool<T> pool)
		{
			mPool = pool;
			mLock = this;
		}

		public SynchronizedPool(android.util.Pool<T> pool, object @lock)
		{
			mPool = pool;
			mLock = @lock;
		}

		[Sharpen.ImplementsInterface(@"android.util.Pool")]
		public virtual T acquire()
		{
			lock (mLock)
			{
				return mPool.acquire();
			}
		}

		[Sharpen.ImplementsInterface(@"android.util.Pool")]
		public virtual void release(T element)
		{
			lock (mLock)
			{
				mPool.release(element);
			}
		}
	}
}
