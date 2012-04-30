using Sharpen;

namespace android.util
{
	[Sharpen.Stub]
	public interface Pool<T> where T:android.util.Poolable<T>
	{
		[Sharpen.Stub]
		T acquire();

		[Sharpen.Stub]
		void release(T element);
	}
}
