using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class IntentService : android.app.Service
	{
		private volatile android.os.Looper mServiceLooper;

		private volatile android.app.IntentService.ServiceHandler mServiceHandler;

		private string mName;

		private bool mRedelivery;

		[Sharpen.Stub]
		private sealed class ServiceHandler : android.os.Handler
		{
			[Sharpen.Stub]
			public ServiceHandler(IntentService _enclosing, android.os.Looper looper) : base(
				looper)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			private readonly IntentService _enclosing;
		}

		[Sharpen.Stub]
		public IntentService(string name) : base()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIntentRedelivery(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override void onCreate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override void onStart(android.content.Intent intent, int startId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override int onStartCommand(android.content.Intent intent, int flags, int 
			startId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override void onDestroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override android.os.IBinder onBind(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal abstract void onHandleIntent(android.content.Intent intent);
	}
}
