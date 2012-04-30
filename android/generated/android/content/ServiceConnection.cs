using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface ServiceConnection
	{
		[Sharpen.Stub]
		void onServiceConnected(android.content.ComponentName name, android.os.IBinder service
			);

		[Sharpen.Stub]
		void onServiceDisconnected(android.content.ComponentName name);
	}
}
