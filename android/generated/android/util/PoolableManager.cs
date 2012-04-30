using Sharpen;

namespace android.util
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface PoolableManager<T> where T:android.util.Poolable<T>
	{
		T newInstance();

		void onAcquired(T element);

		void onReleased(T element);
	}
}
