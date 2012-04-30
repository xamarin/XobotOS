using Sharpen;

namespace android.appwidget
{
	/// <summary>
	/// Updates AppWidget state; gets information about installed AppWidget providers and other
	/// AppWidget related state.
	/// </summary>
	/// <remarks>
	/// Updates AppWidget state; gets information about installed AppWidget providers and other
	/// AppWidget related state.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AppWidgetManager
	{
		internal const string TAG = "AppWidgetManager";

		/// <summary>
		/// Send this from your
		/// <see cref="AppWidgetHost">AppWidgetHost</see>
		/// activity when you want to pick an AppWidget to display.
		/// The AppWidget picker activity will be launched.
		/// <p>
		/// You must supply the following extras:
		/// <table>
		/// <tr>
		/// <td>
		/// <see cref="EXTRA_APPWIDGET_ID">EXTRA_APPWIDGET_ID</see>
		/// </td>
		/// <td>A newly allocated appWidgetId, which will be bound to the AppWidget provider
		/// once the user has selected one.</td>
		/// </tr>
		/// </table>
		/// <p>
		/// The system will respond with an onActivityResult call with the following extras in
		/// the intent:
		/// <table>
		/// <tr>
		/// <td>
		/// <see cref="EXTRA_APPWIDGET_ID">EXTRA_APPWIDGET_ID</see>
		/// </td>
		/// <td>The appWidgetId that you supplied in the original intent.</td>
		/// </tr>
		/// </table>
		/// <p>
		/// When you receive the result from the AppWidget pick activity, if the resultCode is
		/// <see cref="android.app.Activity.RESULT_OK">android.app.Activity.RESULT_OK</see>
		/// , an AppWidget has been selected.  You should then
		/// check the AppWidgetProviderInfo for the returned AppWidget, and if it has one, launch its configuration
		/// activity.  If
		/// <see cref="android.app.Activity.RESULT_CANCELED">android.app.Activity.RESULT_CANCELED
		/// 	</see>
		/// is returned, you should delete
		/// the appWidgetId.
		/// </summary>
		/// <seealso cref="ACTION_APPWIDGET_CONFIGURE">ACTION_APPWIDGET_CONFIGURE</seealso>
		public const string ACTION_APPWIDGET_PICK = "android.appwidget.action.APPWIDGET_PICK";

		/// <summary>Sent when it is time to configure your AppWidget while it is being added to a host.
		/// 	</summary>
		/// <remarks>
		/// Sent when it is time to configure your AppWidget while it is being added to a host.
		/// This action is not sent as a broadcast to the AppWidget provider, but as a startActivity
		/// to the activity specified in the
		/// <see cref="AppWidgetProviderInfo">AppWidgetProviderInfo meta-data</see>
		/// .
		/// <p>
		/// The intent will contain the following extras:
		/// <table>
		/// <tr>
		/// <td>
		/// <see cref="EXTRA_APPWIDGET_ID">EXTRA_APPWIDGET_ID</see>
		/// </td>
		/// <td>The appWidgetId to configure.</td>
		/// </tr>
		/// </table>
		/// <p>If you return
		/// <see cref="android.app.Activity.RESULT_OK">android.app.Activity.RESULT_OK</see>
		/// using
		/// <see cref="android.app.Activity.setResult(int)">Activity.setResult()</see>
		/// , the AppWidget will be added,
		/// and you will receive an
		/// <see cref="ACTION_APPWIDGET_UPDATE">ACTION_APPWIDGET_UPDATE</see>
		/// broadcast for this AppWidget.
		/// If you return
		/// <see cref="android.app.Activity.RESULT_CANCELED">android.app.Activity.RESULT_CANCELED
		/// 	</see>
		/// , the host will cancel the add
		/// and not display this AppWidget, and you will receive a
		/// <see cref="ACTION_APPWIDGET_DELETED">ACTION_APPWIDGET_DELETED</see>
		/// broadcast.
		/// </remarks>
		public const string ACTION_APPWIDGET_CONFIGURE = "android.appwidget.action.APPWIDGET_CONFIGURE";

		/// <summary>An intent extra that contains one appWidgetId.</summary>
		/// <remarks>
		/// An intent extra that contains one appWidgetId.
		/// <p>
		/// The value will be an int that can be retrieved like this:
		/// <sample>frameworks/base/tests/appwidgets/AppWidgetHostTest/src/com/android/tests/appwidgethost/AppWidgetHostActivity.java getExtra_EXTRA_APPWIDGET_ID
		/// 	</sample>
		/// </remarks>
		public const string EXTRA_APPWIDGET_ID = "appWidgetId";

		/// <summary>An intent extra that contains multiple appWidgetIds.</summary>
		/// <remarks>
		/// An intent extra that contains multiple appWidgetIds.
		/// <p>
		/// The value will be an int array that can be retrieved like this:
		/// <sample>frameworks/base/tests/appwidgets/AppWidgetHostTest/src/com/android/tests/appwidgethost/TestAppWidgetProvider.java getExtra_EXTRA_APPWIDGET_IDS
		/// 	</sample>
		/// </remarks>
		public const string EXTRA_APPWIDGET_IDS = "appWidgetIds";

		/// <summary>
		/// An intent extra to pass to the AppWidget picker containing a
		/// <see cref="java.util.List{E}">java.util.List&lt;E&gt;</see>
		/// of
		/// <see cref="AppWidgetProviderInfo">AppWidgetProviderInfo</see>
		/// objects to mix in to the list of AppWidgets that are
		/// installed.  (This is how the launcher shows the search widget).
		/// </summary>
		public const string EXTRA_CUSTOM_INFO = "customInfo";

		/// <summary>
		/// An intent extra to pass to the AppWidget picker containing a
		/// <see cref="java.util.List{E}">java.util.List&lt;E&gt;</see>
		/// of
		/// <see cref="android.os.Bundle">android.os.Bundle</see>
		/// objects to mix in to the list of AppWidgets that are
		/// installed.  It will be added to the extras object on the
		/// <see cref="android.content.Intent">android.content.Intent</see>
		/// that is returned from the picker activity.
		/// <more></more>
		/// </summary>
		public const string EXTRA_CUSTOM_EXTRAS = "customExtras";

		/// <summary>A sentiel value that the AppWidget manager will never return as a appWidgetId.
		/// 	</summary>
		/// <remarks>A sentiel value that the AppWidget manager will never return as a appWidgetId.
		/// 	</remarks>
		public const int INVALID_APPWIDGET_ID = 0;

		/// <summary>Sent when it is time to update your AppWidget.</summary>
		/// <remarks>
		/// Sent when it is time to update your AppWidget.
		/// <p>This may be sent in response to a new instance for this AppWidget provider having
		/// been instantiated, the requested
		/// <see cref="AppWidgetProviderInfo.updatePeriodMillis">update interval</see>
		/// having lapsed, or the system booting.
		/// <p>
		/// The intent will contain the following extras:
		/// <table>
		/// <tr>
		/// <td>
		/// <see cref="EXTRA_APPWIDGET_IDS">EXTRA_APPWIDGET_IDS</see>
		/// </td>
		/// <td>The appWidgetIds to update.  This may be all of the AppWidgets created for this
		/// provider, or just a subset.  The system tries to send updates for as few AppWidget
		/// instances as possible.</td>
		/// </tr>
		/// </table>
		/// </remarks>
		/// <seealso cref="AppWidgetProvider.onUpdate(android.content.Context, AppWidgetManager, int[])
		/// 	">AppWidgetProvider.onUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
		/// 	</seealso>
		public const string ACTION_APPWIDGET_UPDATE = "android.appwidget.action.APPWIDGET_UPDATE";

		/// <summary>Sent when an instance of an AppWidget is deleted from its host.</summary>
		/// <remarks>Sent when an instance of an AppWidget is deleted from its host.</remarks>
		/// <seealso cref="AppWidgetProvider.onDeleted(android.content.Context, int[])">AppWidgetProvider.onDeleted(Context context, int[] appWidgetIds)
		/// 	</seealso>
		public const string ACTION_APPWIDGET_DELETED = "android.appwidget.action.APPWIDGET_DELETED";

		/// <summary>Sent when an instance of an AppWidget is removed from the last host.</summary>
		/// <remarks>Sent when an instance of an AppWidget is removed from the last host.</remarks>
		/// <seealso cref="AppWidgetProvider.onEnabled(android.content.Context)">AppWidgetProvider.onEnabled(Context context)
		/// 	</seealso>
		public const string ACTION_APPWIDGET_DISABLED = "android.appwidget.action.APPWIDGET_DISABLED";

		/// <summary>Sent when an instance of an AppWidget is added to a host for the first time.
		/// 	</summary>
		/// <remarks>
		/// Sent when an instance of an AppWidget is added to a host for the first time.
		/// This broadcast is sent at boot time if there is a AppWidgetHost installed with
		/// an instance for this provider.
		/// </remarks>
		/// <seealso cref="AppWidgetProvider.onEnabled(android.content.Context)">AppWidgetProvider.onEnabled(Context context)
		/// 	</seealso>
		public const string ACTION_APPWIDGET_ENABLED = "android.appwidget.action.APPWIDGET_ENABLED";

		/// <summary>Field for the manifest meta-data tag.</summary>
		/// <remarks>Field for the manifest meta-data tag.</remarks>
		/// <seealso cref="AppWidgetProviderInfo">AppWidgetProviderInfo</seealso>
		public const string META_DATA_APPWIDGET_PROVIDER = "android.appwidget.provider";

		internal static java.util.WeakHashMap<android.content.Context, java.lang.@ref.WeakReference
			<android.appwidget.AppWidgetManager>> sManagerCache = new java.util.WeakHashMap<
			android.content.Context, java.lang.@ref.WeakReference<android.appwidget.AppWidgetManager
			>>();

		internal static android.appwidget.@internal.IAppWidgetService sService;

		internal android.content.Context mContext;

		private android.util.DisplayMetrics mDisplayMetrics;

		/// <summary>
		/// Get the AppWidgetManager instance to use for the supplied
		/// <see cref="android.content.Context">Context</see>
		/// object.
		/// </summary>
		public static android.appwidget.AppWidgetManager getInstance(android.content.Context
			 context)
		{
			lock (sManagerCache)
			{
				if (sService == null)
				{
					android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
						.APPWIDGET_SERVICE);
					sService = android.appwidget.@internal.IAppWidgetServiceClass.Stub.asInterface(b);
				}
				java.lang.@ref.WeakReference<android.appwidget.AppWidgetManager> @ref = sManagerCache
					.get(context);
				android.appwidget.AppWidgetManager result = null;
				if (@ref != null)
				{
					result = @ref.get();
				}
				if (result == null)
				{
					result = new android.appwidget.AppWidgetManager(context);
					sManagerCache.put(context, new java.lang.@ref.WeakReference<android.appwidget.AppWidgetManager
						>(result));
				}
				return result;
			}
		}

		private AppWidgetManager(android.content.Context context)
		{
			mContext = context;
			mDisplayMetrics = context.getResources().getDisplayMetrics();
		}

		/// <summary>Set the RemoteViews to use for the specified appWidgetIds.</summary>
		/// <remarks>
		/// Set the RemoteViews to use for the specified appWidgetIds.
		/// Note that the RemoteViews parameter will be cached by the AppWidgetService, and hence should
		/// contain a complete representation of the widget. For performing partial widget updates, see
		/// <see cref="partiallyUpdateAppWidget(int[], android.widget.RemoteViews)">partiallyUpdateAppWidget(int[], android.widget.RemoteViews)
		/// 	</see>
		/// .
		/// <p>
		/// It is okay to call this method both inside an
		/// <see cref="ACTION_APPWIDGET_UPDATE">ACTION_APPWIDGET_UPDATE</see>
		/// broadcast,
		/// and outside of the handler.
		/// This method will only work when called from the uid that owns the AppWidget provider.
		/// </remarks>
		/// <param name="appWidgetIds">The AppWidget instances for which to set the RemoteViews.
		/// 	</param>
		/// <param name="views">The RemoteViews object to show.</param>
		public virtual void updateAppWidget(int[] appWidgetIds, android.widget.RemoteViews
			 views)
		{
			try
			{
				sService.updateAppWidgetIds(appWidgetIds, views);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>Set the RemoteViews to use for the specified appWidgetId.</summary>
		/// <remarks>
		/// Set the RemoteViews to use for the specified appWidgetId.
		/// Note that the RemoteViews parameter will be cached by the AppWidgetService, and hence should
		/// contain a complete representation of the widget. For performing partial widget updates, see
		/// <see cref="partiallyUpdateAppWidget(int, android.widget.RemoteViews)">partiallyUpdateAppWidget(int, android.widget.RemoteViews)
		/// 	</see>
		/// .
		/// <p>
		/// It is okay to call this method both inside an
		/// <see cref="ACTION_APPWIDGET_UPDATE">ACTION_APPWIDGET_UPDATE</see>
		/// broadcast,
		/// and outside of the handler.
		/// This method will only work when called from the uid that owns the AppWidget provider.
		/// </remarks>
		/// <param name="appWidgetId">The AppWidget instance for which to set the RemoteViews.
		/// 	</param>
		/// <param name="views">The RemoteViews object to show.</param>
		public virtual void updateAppWidget(int appWidgetId, android.widget.RemoteViews views
			)
		{
			updateAppWidget(new int[] { appWidgetId }, views);
		}

		/// <summary>Perform an incremental update or command on the widget(s) specified by appWidgetIds.
		/// 	</summary>
		/// <remarks>
		/// Perform an incremental update or command on the widget(s) specified by appWidgetIds.
		/// This update  differs from
		/// <see cref="updateAppWidget(int[], android.widget.RemoteViews)">updateAppWidget(int[], android.widget.RemoteViews)
		/// 	</see>
		/// in that the
		/// RemoteViews object which is passed is understood to be an incomplete representation of the
		/// widget, and hence is not cached by the AppWidgetService. Note that because these updates are
		/// not cached, any state that they modify that is not restored by restoreInstanceState will not
		/// persist in the case that the widgets are restored using the cached version in
		/// AppWidgetService.
		/// Use with
		/// <see cref="android.widget.RemoteViews.showNext(int)">android.widget.RemoteViews.showNext(int)
		/// 	</see>
		/// ,
		/// <see cref="android.widget.RemoteViews.showPrevious(int)">android.widget.RemoteViews.showPrevious(int)
		/// 	</see>
		/// ,
		/// <see cref="android.widget.RemoteViews.setScrollPosition(int, int)">android.widget.RemoteViews.setScrollPosition(int, int)
		/// 	</see>
		/// and similar commands.
		/// <p>
		/// It is okay to call this method both inside an
		/// <see cref="ACTION_APPWIDGET_UPDATE">ACTION_APPWIDGET_UPDATE</see>
		/// broadcast,
		/// and outside of the handler.
		/// This method will only work when called from the uid that owns the AppWidget provider.
		/// </remarks>
		/// <param name="appWidgetIds">The AppWidget instances for which to set the RemoteViews.
		/// 	</param>
		/// <param name="views">The RemoteViews object containing the incremental update / command.
		/// 	</param>
		public virtual void partiallyUpdateAppWidget(int[] appWidgetIds, android.widget.RemoteViews
			 views)
		{
			try
			{
				sService.partiallyUpdateAppWidgetIds(appWidgetIds, views);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>Perform an incremental update or command on the widget specified by appWidgetId.
		/// 	</summary>
		/// <remarks>
		/// Perform an incremental update or command on the widget specified by appWidgetId.
		/// This update  differs from
		/// <see cref="updateAppWidget(int, android.widget.RemoteViews)">updateAppWidget(int, android.widget.RemoteViews)
		/// 	</see>
		/// in that the RemoteViews
		/// object which is passed is understood to be an incomplete representation of the widget, and
		/// hence is not cached by the AppWidgetService. Note that because these updates are not cached,
		/// any state that they modify that is not restored by restoreInstanceState will not persist in
		/// the case that the widgets are restored using the cached version in AppWidgetService.
		/// Use with
		/// <see cref="android.widget.RemoteViews.showNext(int)">android.widget.RemoteViews.showNext(int)
		/// 	</see>
		/// ,
		/// <see cref="android.widget.RemoteViews.showPrevious(int)">android.widget.RemoteViews.showPrevious(int)
		/// 	</see>
		/// ,
		/// <see cref="android.widget.RemoteViews.setScrollPosition(int, int)">android.widget.RemoteViews.setScrollPosition(int, int)
		/// 	</see>
		/// and similar commands.
		/// <p>
		/// It is okay to call this method both inside an
		/// <see cref="ACTION_APPWIDGET_UPDATE">ACTION_APPWIDGET_UPDATE</see>
		/// broadcast,
		/// and outside of the handler.
		/// This method will only work when called from the uid that owns the AppWidget provider.
		/// </remarks>
		/// <param name="appWidgetId">The AppWidget instance for which to set the RemoteViews.
		/// 	</param>
		/// <param name="views">The RemoteViews object containing the incremental update / command.
		/// 	</param>
		public virtual void partiallyUpdateAppWidget(int appWidgetId, android.widget.RemoteViews
			 views)
		{
			partiallyUpdateAppWidget(new int[] { appWidgetId }, views);
		}

		/// <summary>Set the RemoteViews to use for all AppWidget instances for the supplied AppWidget provider.
		/// 	</summary>
		/// <remarks>
		/// Set the RemoteViews to use for all AppWidget instances for the supplied AppWidget provider.
		/// <p>
		/// It is okay to call this method both inside an
		/// <see cref="ACTION_APPWIDGET_UPDATE">ACTION_APPWIDGET_UPDATE</see>
		/// broadcast,
		/// and outside of the handler.
		/// This method will only work when called from the uid that owns the AppWidget provider.
		/// </remarks>
		/// <param name="provider">
		/// The
		/// <see cref="android.content.ComponentName">android.content.ComponentName</see>
		/// for the
		/// <see cref="android.content.BroadcastReceiver">BroadcastReceiver</see>
		/// provider
		/// for your AppWidget.
		/// </param>
		/// <param name="views">The RemoteViews object to show.</param>
		public virtual void updateAppWidget(android.content.ComponentName provider, android.widget.RemoteViews
			 views)
		{
			try
			{
				sService.updateAppWidgetProvider(provider, views);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>
		/// Notifies the specified collection view in all the specified AppWidget instances
		/// to invalidate their currently data.
		/// </summary>
		/// <remarks>
		/// Notifies the specified collection view in all the specified AppWidget instances
		/// to invalidate their currently data.
		/// </remarks>
		/// <param name="appWidgetIds">The AppWidget instances for which to notify of view data changes.
		/// 	</param>
		/// <param name="viewId">The collection view id.</param>
		public virtual void notifyAppWidgetViewDataChanged(int[] appWidgetIds, int viewId
			)
		{
			try
			{
				sService.notifyAppWidgetViewDataChanged(appWidgetIds, viewId);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>
		/// Notifies the specified collection view in all the specified AppWidget instance
		/// to invalidate it's currently data.
		/// </summary>
		/// <remarks>
		/// Notifies the specified collection view in all the specified AppWidget instance
		/// to invalidate it's currently data.
		/// </remarks>
		/// <param name="appWidgetId">The AppWidget instance for which to notify of view data changes.
		/// 	</param>
		/// <param name="viewId">The collection view id.</param>
		public virtual void notifyAppWidgetViewDataChanged(int appWidgetId, int viewId)
		{
			notifyAppWidgetViewDataChanged(new int[] { appWidgetId }, viewId);
		}

		/// <summary>Return a list of the AppWidget providers that are currently installed.</summary>
		/// <remarks>Return a list of the AppWidget providers that are currently installed.</remarks>
		public virtual java.util.List<android.appwidget.AppWidgetProviderInfo> getInstalledProviders
			()
		{
			try
			{
				java.util.List<android.appwidget.AppWidgetProviderInfo> providers = sService.getInstalledProviders
					();
				foreach (android.appwidget.AppWidgetProviderInfo info in Sharpen.IterableProxy.Create
					(providers))
				{
					// Converting complex to dp.
					info.minWidth = android.util.TypedValue.complexToDimensionPixelSize(info.minWidth
						, mDisplayMetrics);
					info.minHeight = android.util.TypedValue.complexToDimensionPixelSize(info.minHeight
						, mDisplayMetrics);
					info.minResizeWidth = android.util.TypedValue.complexToDimensionPixelSize(info.minResizeWidth
						, mDisplayMetrics);
					info.minResizeHeight = android.util.TypedValue.complexToDimensionPixelSize(info.minResizeHeight
						, mDisplayMetrics);
				}
				return providers;
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>Get the available info about the AppWidget.</summary>
		/// <remarks>Get the available info about the AppWidget.</remarks>
		/// <returns>
		/// A appWidgetId.  If the appWidgetId has not been bound to a provider yet, or
		/// you don't have access to that appWidgetId, null is returned.
		/// </returns>
		public virtual android.appwidget.AppWidgetProviderInfo getAppWidgetInfo(int appWidgetId
			)
		{
			try
			{
				android.appwidget.AppWidgetProviderInfo info = sService.getAppWidgetInfo(appWidgetId
					);
				if (info != null)
				{
					// Converting complex to dp.
					info.minWidth = android.util.TypedValue.complexToDimensionPixelSize(info.minWidth
						, mDisplayMetrics);
					info.minHeight = android.util.TypedValue.complexToDimensionPixelSize(info.minHeight
						, mDisplayMetrics);
					info.minResizeWidth = android.util.TypedValue.complexToDimensionPixelSize(info.minResizeWidth
						, mDisplayMetrics);
					info.minResizeHeight = android.util.TypedValue.complexToDimensionPixelSize(info.minResizeHeight
						, mDisplayMetrics);
				}
				return info;
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>Set the component for a given appWidgetId.</summary>
		/// <remarks>
		/// Set the component for a given appWidgetId.
		/// <p class="note">You need the APPWIDGET_LIST permission.  This method is to be used by the
		/// AppWidget picker.
		/// </remarks>
		/// <param name="appWidgetId">The AppWidget instance for which to set the RemoteViews.
		/// 	</param>
		/// <param name="provider">
		/// The
		/// <see cref="android.content.BroadcastReceiver">android.content.BroadcastReceiver</see>
		/// that will be the AppWidget
		/// provider for this AppWidget.
		/// </param>
		public virtual void bindAppWidgetId(int appWidgetId, android.content.ComponentName
			 provider)
		{
			try
			{
				sService.bindAppWidgetId(appWidgetId, provider);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>Binds the RemoteViewsService for a given appWidgetId and intent.</summary>
		/// <remarks>
		/// Binds the RemoteViewsService for a given appWidgetId and intent.
		/// The appWidgetId specified must already be bound to the calling AppWidgetHost via
		/// <see cref="bindAppWidgetId(int, android.content.ComponentName)">AppWidgetManager.bindAppWidgetId()
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="appWidgetId">The AppWidget instance for which to bind the RemoteViewsService.
		/// 	</param>
		/// <param name="intent">
		/// The intent of the service which will be providing the data to the
		/// RemoteViewsAdapter.
		/// </param>
		/// <param name="connection">The callback interface to be notified when a connection is made or lost.
		/// 	</param>
		/// <hide></hide>
		public virtual void bindRemoteViewsService(int appWidgetId, android.content.Intent
			 intent, android.os.IBinder connection)
		{
			try
			{
				sService.bindRemoteViewsService(appWidgetId, intent, connection);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>Unbinds the RemoteViewsService for a given appWidgetId and intent.</summary>
		/// <remarks>
		/// Unbinds the RemoteViewsService for a given appWidgetId and intent.
		/// The appWidgetId specified muse already be bound to the calling AppWidgetHost via
		/// <see cref="bindAppWidgetId(int, android.content.ComponentName)">AppWidgetManager.bindAppWidgetId()
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="appWidgetId">The AppWidget instance for which to bind the RemoteViewsService.
		/// 	</param>
		/// <param name="intent">
		/// The intent of the service which will be providing the data to the
		/// RemoteViewsAdapter.
		/// </param>
		/// <hide></hide>
		public virtual void unbindRemoteViewsService(int appWidgetId, android.content.Intent
			 intent)
		{
			try
			{
				sService.unbindRemoteViewsService(appWidgetId, intent);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}

		/// <summary>
		/// Get the list of appWidgetIds that have been bound to the given AppWidget
		/// provider.
		/// </summary>
		/// <remarks>
		/// Get the list of appWidgetIds that have been bound to the given AppWidget
		/// provider.
		/// </remarks>
		/// <param name="provider">
		/// The
		/// <see cref="android.content.BroadcastReceiver">android.content.BroadcastReceiver</see>
		/// that is the
		/// AppWidget provider to find appWidgetIds for.
		/// </param>
		public virtual int[] getAppWidgetIds(android.content.ComponentName provider)
		{
			try
			{
				return sService.getAppWidgetIds(provider);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("system server dead?", e);
			}
		}
	}
}
