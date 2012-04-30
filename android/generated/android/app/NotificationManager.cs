using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class NotificationManager
	{
		private static string TAG = "NotificationManager";

		private static bool localLOGV = false;

		private static android.app.INotificationManager sService;

		[Sharpen.Stub]
		public static android.app.INotificationManager getService()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal NotificationManager(android.content.Context context, android.os.Handler 
			handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void notify(int id, android.app.Notification notification)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void notify(string tag, int id, android.app.Notification notification
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancel(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancel(string tag, int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancelAll()
		{
			throw new System.NotImplementedException();
		}

		private android.content.Context mContext;
	}
}
