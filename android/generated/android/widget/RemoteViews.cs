using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class RemoteViews : android.os.Parcelable, android.view.LayoutInflater.Filter
	{
		internal const string LOG_TAG = "RemoteViews";

		internal const string EXTRA_REMOTEADAPTER_APPWIDGET_ID = "remoteAdapterAppWidgetId";

		private readonly string mPackage;

		private readonly int mLayoutId;

		private java.util.ArrayList<android.widget.RemoteViews.Action> mActions;

		private android.widget.RemoteViews.MemoryUsageCounter mMemoryUsageCounter;

		private bool mIsWidgetCollectionChild = false;

		[System.Serializable]
		[Sharpen.Stub]
		public class ActionException : java.lang.RuntimeException
		{
			[Sharpen.Stub]
			public ActionException(System.Exception ex) : base(ex)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public ActionException(string message) : base(message)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private abstract class Action : android.os.Parcelable
		{
			[Sharpen.Stub]
			public abstract void apply(android.view.View root, android.view.ViewGroup rootParent
				);

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void updateMemoryUsageEstimate(android.widget.RemoteViews.MemoryUsageCounter
				 counter)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			protected internal virtual bool startIntentSafely(android.content.Context context
				, android.app.PendingIntent pendingIntent, android.content.Intent fillInIntent)
			{
				throw new System.NotImplementedException();
			}

			public abstract void writeToParcel(android.os.Parcel arg1, int arg2);
		}

		[Sharpen.Stub]
		private class SetEmptyView : android.widget.RemoteViews.Action
		{
			internal int viewId;

			internal int emptyViewId;

			public const int TAG = 6;

			[Sharpen.Stub]
			internal SetEmptyView(RemoteViews _enclosing, int viewId, int emptyViewId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal SetEmptyView(RemoteViews _enclosing, android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class SetOnClickFillInIntent : android.widget.RemoteViews.Action
		{
			[Sharpen.Stub]
			public SetOnClickFillInIntent(RemoteViews _enclosing, int id, android.content.Intent
				 fillInIntent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SetOnClickFillInIntent(RemoteViews _enclosing, android.os.Parcel parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			internal int viewId;

			internal android.content.Intent fillInIntent;

			public const int TAG = 9;

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class SetPendingIntentTemplate : android.widget.RemoteViews.Action
		{
			[Sharpen.Stub]
			public SetPendingIntentTemplate(RemoteViews _enclosing, int id, android.app.PendingIntent
				 pendingIntentTemplate)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SetPendingIntentTemplate(RemoteViews _enclosing, android.os.Parcel parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			internal int viewId;

			internal android.app.PendingIntent pendingIntentTemplate;

			public const int TAG = 8;

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class SetRemoteViewsAdapterIntent : android.widget.RemoteViews.Action
		{
			[Sharpen.Stub]
			public SetRemoteViewsAdapterIntent(RemoteViews _enclosing, int id, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SetRemoteViewsAdapterIntent(RemoteViews _enclosing, android.os.Parcel parcel
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			internal int viewId;

			internal android.content.Intent intent;

			public const int TAG = 10;

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class SetOnClickPendingIntent : android.widget.RemoteViews.Action
		{
			[Sharpen.Stub]
			public SetOnClickPendingIntent(RemoteViews _enclosing, int id, android.app.PendingIntent
				 pendingIntent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SetOnClickPendingIntent(RemoteViews _enclosing, android.os.Parcel parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			internal int viewId;

			internal android.app.PendingIntent pendingIntent;

			public const int TAG = 1;

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class SetDrawableParameters : android.widget.RemoteViews.Action
		{
			[Sharpen.Stub]
			public SetDrawableParameters(RemoteViews _enclosing, int id, bool targetBackground
				, int alpha, int colorFilter, android.graphics.PorterDuff.Mode mode, int level)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SetDrawableParameters(RemoteViews _enclosing, android.os.Parcel parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			internal int viewId;

			internal bool targetBackground;

			internal int alpha;

			internal int colorFilter;

			internal android.graphics.PorterDuff.Mode filterMode;

			internal int level;

			public const int TAG = 3;

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class ReflectionActionWithoutParams : android.widget.RemoteViews.Action
		{
			internal int viewId;

			internal string methodName;

			public const int TAG = 5;

			[Sharpen.Stub]
			internal ReflectionActionWithoutParams(RemoteViews _enclosing, int viewId, string
				 methodName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal ReflectionActionWithoutParams(RemoteViews _enclosing, android.os.Parcel 
				@in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class ReflectionAction : android.widget.RemoteViews.Action
		{
			internal const int TAG = 2;

			internal const int BOOLEAN = 1;

			internal const int BYTE = 2;

			internal const int SHORT = 3;

			internal const int INT = 4;

			internal const int LONG = 5;

			internal const int FLOAT = 6;

			internal const int DOUBLE = 7;

			internal const int CHAR = 8;

			internal const int STRING = 9;

			internal const int CHAR_SEQUENCE = 10;

			internal const int URI = 11;

			internal const int BITMAP = 12;

			internal const int BUNDLE = 13;

			internal const int INTENT = 14;

			internal int viewId;

			internal string methodName;

			internal int type;

			internal object value;

			[Sharpen.Stub]
			internal ReflectionAction(RemoteViews _enclosing, int viewId, string methodName, 
				int type, object value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal ReflectionAction(RemoteViews _enclosing, android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal System.Type getParameterType()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void updateMemoryUsageEstimate(android.widget.RemoteViews.MemoryUsageCounter
				 counter)
			{
				throw new System.NotImplementedException();
			}

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class ViewGroupAction : android.widget.RemoteViews.Action
		{
			[Sharpen.Stub]
			public ViewGroupAction(RemoteViews _enclosing, int viewId, android.widget.RemoteViews
				 nestedViews)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public ViewGroupAction(RemoteViews _enclosing, android.os.Parcel parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void apply(android.view.View root, android.view.ViewGroup rootParent
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.widget.RemoteViews.Action")]
			public override void updateMemoryUsageEstimate(android.widget.RemoteViews.MemoryUsageCounter
				 counter)
			{
				throw new System.NotImplementedException();
			}

			internal int viewId;

			internal android.widget.RemoteViews nestedViews;

			public const int TAG = 4;

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		private class MemoryUsageCounter
		{
			[Sharpen.Stub]
			public virtual void clear()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void bitmapIncrement(int numBytes)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getBitmapHeapMemoryUsage()
			{
				throw new System.NotImplementedException();
			}

			internal int mBitmapHeapMemoryUsage;

			internal MemoryUsageCounter(RemoteViews _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly RemoteViews _enclosing;
		}

		[Sharpen.Stub]
		public RemoteViews(string packageName, int layoutId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public RemoteViews(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.RemoteViews clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getPackage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLayoutId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setIsWidgetCollectionChild(bool isWidgetCollectionChild)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void recalculateMemoryUsage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int estimateBitmapMemoryUsage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addAction(android.widget.RemoteViews.Action a)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addView(int viewId, android.widget.RemoteViews nestedView)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeAllViews(int viewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void showNext(int viewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void showPrevious(int viewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDisplayedChild(int viewId, int childIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setViewVisibility(int viewId, int visibility)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTextViewText(int viewId, java.lang.CharSequence text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setImageViewResource(int viewId, int srcId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setImageViewUri(int viewId, System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setImageViewBitmap(int viewId, android.graphics.Bitmap bitmap
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEmptyView(int viewId, int emptyViewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setChronometer(int viewId, long @base, string format, bool started
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProgressBar(int viewId, int max, int progress, bool indeterminate
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnClickPendingIntent(int viewId, android.app.PendingIntent
			 pendingIntent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPendingIntentTemplate(int viewId, android.app.PendingIntent
			 pendingIntentTemplate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnClickFillInIntent(int viewId, android.content.Intent fillInIntent
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDrawableParameters(int viewId, bool targetBackground, int 
			alpha, int colorFilter, android.graphics.PorterDuff.Mode mode, int level)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTextColor(int viewId, int color)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method has been deprecated. SeesetRemoteAdapter(int, android.content.Intent)"
			)]
		public virtual void setRemoteAdapter(int appWidgetId, int viewId, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRemoteAdapter(int viewId, android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setScrollPosition(int viewId, int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRelativeScrollPosition(int viewId, int offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBoolean(int viewId, string methodName, bool value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setByte(int viewId, string methodName, byte value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setShort(int viewId, string methodName, short value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInt(int viewId, string methodName, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLong(int viewId, string methodName, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFloat(int viewId, string methodName, float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDouble(int viewId, string methodName, double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setChar(int viewId, string methodName, char value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setString(int viewId, string methodName, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCharSequence(int viewId, string methodName, java.lang.CharSequence
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setUri(int viewId, string methodName, System.Uri value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBitmap(int viewId, string methodName, android.graphics.Bitmap
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBundle(int viewId, string methodName, android.os.Bundle value
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIntent(int viewId, string methodName, android.content.Intent
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View apply(android.content.Context context, android.view.ViewGroup
			 parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reapply(android.content.Context context, android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void performApply(android.view.View v, android.view.ViewGroup parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.Context prepareContext(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.LayoutInflater.Filter")]
		public virtual bool onLoadClass(System.Type clazz)
		{
			throw new System.NotImplementedException();
		}

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

		private sealed class _Creator_1651 : android.os.ParcelableClass.Creator<android.widget.RemoteViews
			>
		{
			public _Creator_1651()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.widget.RemoteViews createFromParcel(android.os.Parcel parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.widget.RemoteViews[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.widget.RemoteViews
			> CREATOR = new _Creator_1651();
	}
}
