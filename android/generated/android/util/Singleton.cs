using Sharpen;

namespace android.util
{
	[Sharpen.Stub]
	public abstract class Singleton<T>
	{
		private T mInstance;

		[Sharpen.Stub]
		protected internal abstract T create();

		[Sharpen.Stub]
		public T get()
		{
			throw new System.NotImplementedException();
		}
	}
}
