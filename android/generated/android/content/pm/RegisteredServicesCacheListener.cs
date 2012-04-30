using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface RegisteredServicesCacheListener<V>
	{
		[Sharpen.Stub]
		void onServiceChanged(V type, bool removed);
	}
}
