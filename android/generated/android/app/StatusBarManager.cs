using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class StatusBarManager
	{
		public const int DISABLE_EXPAND = android.view.View.STATUS_BAR_DISABLE_EXPAND;

		public const int DISABLE_NOTIFICATION_ICONS = android.view.View.STATUS_BAR_DISABLE_NOTIFICATION_ICONS;

		public const int DISABLE_NOTIFICATION_ALERTS = android.view.View.STATUS_BAR_DISABLE_NOTIFICATION_ALERTS;

		public const int DISABLE_NOTIFICATION_TICKER = android.view.View.STATUS_BAR_DISABLE_NOTIFICATION_TICKER;

		public const int DISABLE_SYSTEM_INFO = android.view.View.STATUS_BAR_DISABLE_SYSTEM_INFO;

		public const int DISABLE_HOME = android.view.View.STATUS_BAR_DISABLE_HOME;

		public const int DISABLE_RECENT = android.view.View.STATUS_BAR_DISABLE_RECENT;

		public const int DISABLE_BACK = android.view.View.STATUS_BAR_DISABLE_BACK;

		public const int DISABLE_CLOCK = android.view.View.STATUS_BAR_DISABLE_CLOCK;

		[System.Obsolete]
		public const int DISABLE_NAVIGATION = android.view.View.STATUS_BAR_DISABLE_HOME |
			 android.view.View.STATUS_BAR_DISABLE_RECENT;

		public const int DISABLE_NONE = unchecked((int)(0x00000000));

		public const int DISABLE_MASK = DISABLE_EXPAND | DISABLE_NOTIFICATION_ICONS | DISABLE_NOTIFICATION_ALERTS
			 | DISABLE_NOTIFICATION_TICKER | DISABLE_SYSTEM_INFO | DISABLE_RECENT | DISABLE_HOME
			 | DISABLE_BACK | DISABLE_CLOCK;

		private android.content.Context mContext;

		private android.statusbar.@internal.IStatusBarService mService;

		private android.os.IBinder mToken = new android.os.Binder();

		[Sharpen.Stub]
		internal StatusBarManager(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.statusbar.@internal.IStatusBarService getService()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disable(int what)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void expand()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void collapse()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIcon(string slot, int iconId, int iconLevel, string contentDescription
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeIcon(string slot)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIconVisibility(string slot, bool visible)
		{
			throw new System.NotImplementedException();
		}
	}
}
