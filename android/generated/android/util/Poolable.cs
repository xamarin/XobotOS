using Sharpen;

namespace android.util
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface Poolable<T>
	{
		void setNextPoolable(T element);

		T getNextPoolable();

		bool isPooled();

		void setPooled(bool isPooled_1);
	}
}
