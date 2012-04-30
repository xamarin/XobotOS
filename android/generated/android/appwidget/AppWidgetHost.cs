using Sharpen;

namespace android.appwidget
{
	[Sharpen.Stub]
	public class AppWidgetHost
	{
		internal const int HANDLE_UPDATE = 1;

		internal const int HANDLE_PROVIDER_CHANGED = 2;

		internal const int HANDLE_VIEW_DATA_CHANGED = 3;

		internal static readonly object sServiceLock = new object();

		internal static android.appwidget.@internal.IAppWidgetService sService;

		private android.util.DisplayMetrics mDisplayMetrics;

		internal android.content.Context mContext;

		internal string mPackageName;

		[Sharpen.Stub]
		internal class Callbacks : android.appwidget.@internal.IAppWidgetHostClass.Stub
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetHost")]
			public override void updateAppWidget(int appWidgetId, android.widget.RemoteViews 
				views)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetHost")]
			public override void providerChanged(int appWidgetId, android.appwidget.AppWidgetProviderInfo
				 info)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetHost")]
			public override void viewDataChanged(int appWidgetId, int viewId)
			{
				throw new System.NotImplementedException();
			}

			internal Callbacks(AppWidgetHost _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AppWidgetHost _enclosing;
		}

		[Sharpen.Stub]
		internal class UpdateHandler : android.os.Handler
		{
			[Sharpen.Stub]
			public UpdateHandler(AppWidgetHost _enclosing, android.os.Looper looper) : base(looper
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			private readonly AppWidgetHost _enclosing;
		}

		internal android.os.Handler mHandler;

		internal int mHostId;

		internal android.appwidget.AppWidgetHost.Callbacks mCallbacks;

		internal readonly java.util.HashMap<int, android.appwidget.AppWidgetHostView> mViews
			 = new java.util.HashMap<int, android.appwidget.AppWidgetHostView>();

		[Sharpen.Stub]
		public AppWidgetHost(android.content.Context context, int hostId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startListening()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopListening()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int allocateAppWidgetId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void deleteAppWidgetId(int appWidgetId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void deleteHost()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void deleteAllHosts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.appwidget.AppWidgetHostView createView(android.content.Context context
			, int appWidgetId, android.appwidget.AppWidgetProviderInfo appWidget)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.appwidget.AppWidgetHostView onCreateView(android.content.Context
			 context, int appWidgetId, android.appwidget.AppWidgetProviderInfo appWidget)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onProviderChanged(int appWidgetId, android.appwidget.AppWidgetProviderInfo
			 appWidget)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void updateAppWidgetView(int appWidgetId, android.widget.RemoteViews
			 views)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void viewDataChanged(int appWidgetId, int viewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void clearViews()
		{
			throw new System.NotImplementedException();
		}
	}
}
