using Sharpen;

namespace android.util
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class Pools
	{
		private Pools()
		{
		}

		public static android.util.Pool<T> simplePool<T>(android.util.PoolableManager<T> 
			manager) where T:android.util.Poolable<T>
		{
			return new android.util.FinitePool<T>(manager);
		}

		public static android.util.Pool<T> finitePool<T>(android.util.PoolableManager<T> 
			manager, int limit) where T:android.util.Poolable<T>
		{
			return new android.util.FinitePool<T>(manager, limit);
		}

		public static android.util.Pool<T> synchronizedPool<T>(android.util.Pool<T> pool)
			 where T:android.util.Poolable<T>
		{
			return new android.util.SynchronizedPool<T>(pool);
		}

		public static android.util.Pool<T> synchronizedPool<T>(android.util.Pool<T> pool, 
			object @lock) where T:android.util.Poolable<T>
		{
			return new android.util.SynchronizedPool<T>(pool, @lock);
		}
	}
}
