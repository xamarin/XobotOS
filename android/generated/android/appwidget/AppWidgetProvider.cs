using Sharpen;

namespace android.appwidget
{
	/// <summary>A convenience class to aid in implementing an AppWidget provider.</summary>
	/// <remarks>
	/// A convenience class to aid in implementing an AppWidget provider.
	/// Everything you can do with AppWidgetProvider, you can do with a regular
	/// <see cref="android.content.BroadcastReceiver">android.content.BroadcastReceiver</see>
	/// .
	/// AppWidgetProvider merely parses the relevant fields out of the Intent that is received in
	/// <see cref="onReceive(android.content.Context, android.content.Intent)">onReceive(Context,Intent)
	/// 	</see>
	/// , and calls hook methods
	/// with the received extras.
	/// <p>Extend this class and override one or more of the
	/// <see cref="onUpdate(android.content.Context, AppWidgetManager, int[])">onUpdate(android.content.Context, AppWidgetManager, int[])
	/// 	</see>
	/// ,
	/// <see cref="onDeleted(android.content.Context, int[])">onDeleted(android.content.Context, int[])
	/// 	</see>
	/// ,
	/// <see cref="onEnabled(android.content.Context)">onEnabled(android.content.Context)
	/// 	</see>
	/// or
	/// <see cref="onDisabled(android.content.Context)">onDisabled(android.content.Context)
	/// 	</see>
	/// methods to implement your own AppWidget functionality.
	/// </p>
	/// <p>For an example of how to write a AppWidget provider, see the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/appwidgets/index.html#Providers"&gt;AppWidgets</a> documentation.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class AppWidgetProvider : android.content.BroadcastReceiver
	{
		/// <summary>Constructor to initialize AppWidgetProvider.</summary>
		/// <remarks>Constructor to initialize AppWidgetProvider.</remarks>
		public AppWidgetProvider()
		{
		}

		/// <summary>
		/// Implements
		/// <see cref="android.content.BroadcastReceiver.onReceive(android.content.Context, android.content.Intent)
		/// 	">android.content.BroadcastReceiver.onReceive(android.content.Context, android.content.Intent)
		/// 	</see>
		/// to dispatch calls to the various
		/// other methods on AppWidgetProvider.
		/// </summary>
		/// <param name="context">The Context in which the receiver is running.</param>
		/// <param name="intent">The Intent being received.</param>
		[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
		public override void onReceive(android.content.Context context, android.content.Intent
			 intent)
		{
			// BEGIN_INCLUDE(onReceive)
			// Protect against rogue update broadcasts (not really a security issue,
			// just filter bad broacasts out so subclasses are less likely to crash).
			string action = intent.getAction();
			if (android.appwidget.AppWidgetManager.ACTION_APPWIDGET_UPDATE.Equals(action))
			{
				android.os.Bundle extras = intent.getExtras();
				if (extras != null)
				{
					int[] appWidgetIds = extras.getIntArray(android.appwidget.AppWidgetManager.EXTRA_APPWIDGET_IDS
						);
					if (appWidgetIds != null && appWidgetIds.Length > 0)
					{
						this.onUpdate(context, android.appwidget.AppWidgetManager.getInstance(context), appWidgetIds
							);
					}
				}
			}
			else
			{
				if (android.appwidget.AppWidgetManager.ACTION_APPWIDGET_DELETED.Equals(action))
				{
					android.os.Bundle extras = intent.getExtras();
					if (extras != null && extras.containsKey(android.appwidget.AppWidgetManager.EXTRA_APPWIDGET_ID
						))
					{
						int appWidgetId = extras.getInt(android.appwidget.AppWidgetManager.EXTRA_APPWIDGET_ID
							);
						this.onDeleted(context, new int[] { appWidgetId });
					}
				}
				else
				{
					if (android.appwidget.AppWidgetManager.ACTION_APPWIDGET_ENABLED.Equals(action))
					{
						this.onEnabled(context);
					}
					else
					{
						if (android.appwidget.AppWidgetManager.ACTION_APPWIDGET_DISABLED.Equals(action))
						{
							this.onDisabled(context);
						}
					}
				}
			}
		}

		// END_INCLUDE(onReceive)
		/// <summary>
		/// Called in response to the
		/// <see cref="AppWidgetManager.ACTION_APPWIDGET_UPDATE">AppWidgetManager.ACTION_APPWIDGET_UPDATE
		/// 	</see>
		/// broadcast when
		/// this AppWidget provider is being asked to provide
		/// <see cref="android.widget.RemoteViews">RemoteViews</see>
		/// for a set of AppWidgets.  Override this method to implement your own AppWidget functionality.
		/// <more></more>
		/// </summary>
		/// <param name="context">
		/// The
		/// <see cref="android.content.Context">Context</see>
		/// in which this receiver is
		/// running.
		/// </param>
		/// <param name="appWidgetManager">
		/// A
		/// <see cref="AppWidgetManager">AppWidgetManager</see>
		/// object you can call
		/// <see cref="AppWidgetManager.updateAppWidget(int[], android.widget.RemoteViews)">AppWidgetManager.updateAppWidget(int[], android.widget.RemoteViews)
		/// 	</see>
		/// on.
		/// </param>
		/// <param name="appWidgetIds">
		/// The appWidgetIds for which an update is needed.  Note that this
		/// may be all of the AppWidget instances for this provider, or just
		/// a subset of them.
		/// </param>
		/// <seealso cref="AppWidgetManager.ACTION_APPWIDGET_UPDATE">AppWidgetManager.ACTION_APPWIDGET_UPDATE
		/// 	</seealso>
		public virtual void onUpdate(android.content.Context context, android.appwidget.AppWidgetManager
			 appWidgetManager, int[] appWidgetIds)
		{
		}

		/// <summary>
		/// Called in response to the
		/// <see cref="AppWidgetManager.ACTION_APPWIDGET_DELETED">AppWidgetManager.ACTION_APPWIDGET_DELETED
		/// 	</see>
		/// broadcast when
		/// one or more AppWidget instances have been deleted.  Override this method to implement
		/// your own AppWidget functionality.
		/// <more></more>
		/// </summary>
		/// <param name="context">
		/// The
		/// <see cref="android.content.Context">Context</see>
		/// in which this receiver is
		/// running.
		/// </param>
		/// <param name="appWidgetIds">The appWidgetIds that have been deleted from their host.
		/// 	</param>
		/// <seealso cref="AppWidgetManager.ACTION_APPWIDGET_DELETED">AppWidgetManager.ACTION_APPWIDGET_DELETED
		/// 	</seealso>
		public virtual void onDeleted(android.content.Context context, int[] appWidgetIds
			)
		{
		}

		/// <summary>
		/// Called in response to the
		/// <see cref="AppWidgetManager.ACTION_APPWIDGET_ENABLED">AppWidgetManager.ACTION_APPWIDGET_ENABLED
		/// 	</see>
		/// broadcast when
		/// the a AppWidget for this provider is instantiated.  Override this method to implement your
		/// own AppWidget functionality.
		/// <more></more>
		/// When the last AppWidget for this provider is deleted,
		/// <see cref="AppWidgetManager.ACTION_APPWIDGET_DISABLED">AppWidgetManager.ACTION_APPWIDGET_DISABLED
		/// 	</see>
		/// is sent by the AppWidget manager, and
		/// <see cref="onDisabled(android.content.Context)">onDisabled(android.content.Context)
		/// 	</see>
		/// is called.  If after that, an AppWidget for this provider is created
		/// again, onEnabled() will be called again.
		/// </summary>
		/// <param name="context">
		/// The
		/// <see cref="android.content.Context">Context</see>
		/// in which this receiver is
		/// running.
		/// </param>
		/// <seealso cref="AppWidgetManager.ACTION_APPWIDGET_ENABLED">AppWidgetManager.ACTION_APPWIDGET_ENABLED
		/// 	</seealso>
		public virtual void onEnabled(android.content.Context context)
		{
		}

		/// <summary>
		/// Called in response to the
		/// <see cref="AppWidgetManager.ACTION_APPWIDGET_DISABLED">AppWidgetManager.ACTION_APPWIDGET_DISABLED
		/// 	</see>
		/// broadcast, which
		/// is sent when the last AppWidget instance for this provider is deleted.  Override this method
		/// to implement your own AppWidget functionality.
		/// <more></more>
		/// </summary>
		/// <param name="context">
		/// The
		/// <see cref="android.content.Context">Context</see>
		/// in which this receiver is
		/// running.
		/// </param>
		/// <seealso cref="AppWidgetManager.ACTION_APPWIDGET_DISABLED">AppWidgetManager.ACTION_APPWIDGET_DISABLED
		/// 	</seealso>
		public virtual void onDisabled(android.content.Context context)
		{
		}
	}
}
