using Sharpen;

namespace android.appwidget
{
	[Sharpen.Stub]
	public class AppWidgetHostView : android.widget.FrameLayout
	{
		internal const string TAG = "AppWidgetHostView";

		internal const bool LOGD = false;

		internal const bool CROSSFADE = false;

		internal const int VIEW_MODE_NOINIT = 0;

		internal const int VIEW_MODE_CONTENT = 1;

		internal const int VIEW_MODE_ERROR = 2;

		internal const int VIEW_MODE_DEFAULT = 3;

		internal const int FADE_DURATION = 1000;

		private sealed class _Filter_66 : android.view.LayoutInflater.Filter
		{
			public _Filter_66()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.LayoutInflater.Filter")]
			public bool onLoadClass(System.Type clazz)
			{
				throw new System.NotImplementedException();
			}
		}

		internal static readonly android.view.LayoutInflater.Filter sInflaterFilter = new 
			_Filter_66();

		internal android.content.Context mContext;

		internal android.content.Context mRemoteContext;

		internal int mAppWidgetId;

		internal android.appwidget.AppWidgetProviderInfo mInfo;

		internal android.view.View mView;

		internal int mViewMode = VIEW_MODE_NOINIT;

		internal int mLayoutId = -1;

		internal long mFadeStartTime = -1;

		internal android.graphics.Bitmap mOld;

		internal android.graphics.Paint mOldPaint = new android.graphics.Paint();

		[Sharpen.Stub]
		public AppWidgetHostView(android.content.Context context) : this(context, android.R
			.anim.fade_in, android.R.anim.fade_out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public AppWidgetHostView(android.content.Context context, int animationIn, int animationOut
			) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAppWidget(int appWidgetId, android.appwidget.AppWidgetProviderInfo
			 info)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class Padding
		{
			internal int left = 0;

			internal int right = 0;

			internal int top = 0;

			internal int bottom = 0;
		}

		[Sharpen.Stub]
		private android.appwidget.AppWidgetHostView.Padding getPaddingForWidget(android.content.ComponentName
			 component)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getAppWidgetId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.appwidget.AppWidgetProviderInfo getAppWidgetInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSaveInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int generateId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchRestoreInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void resetAppWidget(android.appwidget.AppWidgetProviderInfo info
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateAppWidget(android.widget.RemoteViews remoteViews)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void viewDataChanged(int viewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.Context getRemoteContext(android.widget.RemoteViews views
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool drawChild(android.graphics.Canvas canvas, android.view.View
			 child, long drawingTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void prepareView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.view.View getDefaultView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.view.View getErrorView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class ParcelableSparseArray : android.util.SparseArray<android.os.Parcelable
			>, android.os.Parcelable
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			internal sealed class _Creator_481 : android.os.ParcelableClass.Creator<android.appwidget.AppWidgetHostView
				.ParcelableSparseArray>
			{
				public _Creator_481()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.appwidget.AppWidgetHostView.ParcelableSparseArray createFromParcel
					(android.os.Parcel source)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.appwidget.AppWidgetHostView.ParcelableSparseArray[] newArray(int size
					)
				{
					throw new System.NotImplementedException();
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.appwidget.AppWidgetHostView
				.ParcelableSparseArray> CREATOR = new _Creator_481();
		}
	}
}
