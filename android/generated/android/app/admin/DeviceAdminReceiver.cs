using Sharpen;

namespace android.app.admin
{
	[Sharpen.Stub]
	public class DeviceAdminReceiver : android.content.BroadcastReceiver
	{
		private static string TAG = "DevicePolicy";

		private static bool localLOGV = false;

		public const string ACTION_DEVICE_ADMIN_ENABLED = "android.app.action.DEVICE_ADMIN_ENABLED";

		public const string ACTION_DEVICE_ADMIN_DISABLE_REQUESTED = "android.app.action.DEVICE_ADMIN_DISABLE_REQUESTED";

		public const string EXTRA_DISABLE_WARNING = "android.app.extra.DISABLE_WARNING";

		public const string ACTION_DEVICE_ADMIN_DISABLED = "android.app.action.DEVICE_ADMIN_DISABLED";

		public const string ACTION_PASSWORD_CHANGED = "android.app.action.ACTION_PASSWORD_CHANGED";

		public const string ACTION_PASSWORD_FAILED = "android.app.action.ACTION_PASSWORD_FAILED";

		public const string ACTION_PASSWORD_SUCCEEDED = "android.app.action.ACTION_PASSWORD_SUCCEEDED";

		public const string ACTION_PASSWORD_EXPIRING = "android.app.action.ACTION_PASSWORD_EXPIRING";

		public const string DEVICE_ADMIN_META_DATA = "android.app.device_admin";

		private android.app.admin.DevicePolicyManager mManager;

		private android.content.ComponentName mWho;

		[Sharpen.Stub]
		public virtual android.app.admin.DevicePolicyManager getManager(android.content.Context
			 context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ComponentName getWho(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onEnabled(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence onDisableRequested(android.content.Context 
			context, android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onDisabled(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPasswordChanged(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPasswordFailed(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPasswordSucceeded(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPasswordExpiring(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
		public override void onReceive(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}
	}
}
