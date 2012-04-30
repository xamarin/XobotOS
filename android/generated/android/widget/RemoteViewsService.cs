using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public abstract class RemoteViewsService : android.app.Service
	{
		internal const string LOG_TAG = "RemoteViewsService";

		private static readonly java.util.HashMap<android.content.Intent.FilterComparison
			, android.widget.RemoteViewsService.RemoteViewsFactory> sRemoteViewFactories = new 
			java.util.HashMap<android.content.Intent.FilterComparison, android.widget.RemoteViewsService
			.RemoteViewsFactory>();

		private static readonly object sLock = new object();

		[Sharpen.Stub]
		public interface RemoteViewsFactory
		{
			[Sharpen.Stub]
			void onCreate();

			[Sharpen.Stub]
			void onDataSetChanged();

			[Sharpen.Stub]
			void onDestroy();

			[Sharpen.Stub]
			int getCount();

			[Sharpen.Stub]
			android.widget.RemoteViews getViewAt(int position);

			[Sharpen.Stub]
			android.widget.RemoteViews getLoadingView();

			[Sharpen.Stub]
			int getViewTypeCount();

			[Sharpen.Stub]
			long getItemId(int position);

			[Sharpen.Stub]
			bool hasStableIds();
		}

		[Sharpen.Stub]
		private class RemoteViewsFactoryAdapter : android.widget.@internal.IRemoteViewsFactoryClass
			.Stub
		{
			[Sharpen.Stub]
			public RemoteViewsFactoryAdapter(android.widget.RemoteViewsService.RemoteViewsFactory
				 factory, bool isCreated_1)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override bool isCreated()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override void onDataSetChanged()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override int getCount()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override android.widget.RemoteViews getViewAt(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override android.widget.RemoteViews getLoadingView()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override int getViewTypeCount()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override long getItemId(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override bool hasStableIds()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
			public override void onDestroy(android.content.Intent intent)
			{
				throw new System.NotImplementedException();
			}

			internal android.widget.RemoteViewsService.RemoteViewsFactory mFactory;

			internal bool mIsCreated;
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override android.os.IBinder onBind(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.widget.RemoteViewsService.RemoteViewsFactory onGetViewFactory
			(android.content.Intent intent);
	}
}
