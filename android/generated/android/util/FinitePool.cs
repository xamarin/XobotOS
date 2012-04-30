using Sharpen;

namespace android.util
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	internal static class FinitePool
	{
		internal const string LOG_TAG = "FinitePool";
	}

	/// <hide></hide>
	[Sharpen.Sharpened]
	internal class FinitePool<T> : android.util.Pool<T> where T:android.util.Poolable
		<T>
	{
		/// <summary>Factory used to create new pool objects</summary>
		private readonly android.util.PoolableManager<T> mManager;

		/// <summary>Maximum number of objects in the pool</summary>
		private readonly int mLimit;

		/// <summary>If true, mLimit is ignored</summary>
		private readonly bool mInfinite;

		/// <summary>Next object to acquire</summary>
		private T mRoot;

		/// <summary>Number of objects in the pool</summary>
		private int mPoolCount;

		internal FinitePool(android.util.PoolableManager<T> manager)
		{
			mManager = manager;
			mLimit = 0;
			mInfinite = true;
		}

		internal FinitePool(android.util.PoolableManager<T> manager, int limit)
		{
			if (limit <= 0)
			{
				throw new System.ArgumentException("The pool limit must be > 0");
			}
			mManager = manager;
			mLimit = limit;
			mInfinite = false;
		}

		[Sharpen.ImplementsInterface(@"android.util.Pool")]
		public virtual T acquire()
		{
			T element;
			if ((object)mRoot != null)
			{
				element = mRoot;
				mRoot = element.getNextPoolable();
				mPoolCount--;
			}
			else
			{
				element = mManager.newInstance();
			}
			if ((object)element != null)
			{
				element.setNextPoolable(default(T));
				element.setPooled(false);
				mManager.onAcquired(element);
			}
			return element;
		}

		[Sharpen.ImplementsInterface(@"android.util.Pool")]
		public virtual void release(T element)
		{
			if (!element.isPooled())
			{
				if (mInfinite || mPoolCount < mLimit)
				{
					mPoolCount++;
					element.setNextPoolable(mRoot);
					element.setPooled(true);
					mRoot = element;
				}
				mManager.onReleased(element);
			}
			else
			{
				android.util.Log.w(android.util.FinitePool.LOG_TAG, "Element is already in pool: "
					 + element);
			}
		}
	}
}
