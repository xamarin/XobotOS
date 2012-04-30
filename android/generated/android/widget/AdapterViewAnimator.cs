using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public abstract class AdapterViewAnimator : android.widget.AdapterView<android.widget.Adapter
		>, android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback, android.widget.Advanceable
	{
		internal const string TAG = "RemoteViewAnimator";

		internal int mWhichChild = 0;

		private int mRestoreWhichChild = -1;

		internal bool mAnimateFirstTime = true;

		internal int mActiveOffset = 0;

		internal int mMaxNumActiveViews = 1;

		internal java.util.HashMap<int, android.widget.AdapterViewAnimator.ViewAndMetaData
			> mViewsMap = new java.util.HashMap<int, android.widget.AdapterViewAnimator.ViewAndMetaData
			>();

		internal java.util.ArrayList<int> mPreviousViews;

		internal int mCurrentWindowStart = 0;

		internal int mCurrentWindowEnd = -1;

		internal int mCurrentWindowStartUnbounded = 0;

		internal android.widget.AdapterView<android.widget.Adapter>.AdapterDataSetObserver
			 mDataSetObserver;

		internal android.widget.Adapter mAdapter;

		internal android.widget.RemoteViewsAdapter mRemoteViewsAdapter;

		internal bool mDeferNotifyDataSetChanged = false;

		internal bool mFirstTime = true;

		internal bool mLoopViews = true;

		internal int mReferenceChildWidth = -1;

		internal int mReferenceChildHeight = -1;

		internal android.animation.ObjectAnimator mInAnimation;

		internal android.animation.ObjectAnimator mOutAnimation;

		private int mTouchMode = TOUCH_MODE_NONE;

		internal const int TOUCH_MODE_NONE = 0;

		internal const int TOUCH_MODE_DOWN_IN_CURRENT_VIEW = 1;

		internal const int TOUCH_MODE_HANDLED = 2;

		private java.lang.Runnable mPendingCheckForTap;

		internal const int DEFAULT_ANIMATION_DURATION = 200;

		[Sharpen.Stub]
		public AdapterViewAnimator(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public AdapterViewAnimator(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public AdapterViewAnimator(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initViewAnimator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class ViewAndMetaData
		{
			internal android.view.View view;

			internal int relativeIndex;

			internal int adapterPosition;

			internal long itemId;

			[Sharpen.Stub]
			internal ViewAndMetaData(AdapterViewAnimator _enclosing, android.view.View view, 
				int relativeIndex, int adapterPosition, long itemId)
			{
				throw new System.NotImplementedException();
			}

			private readonly AdapterViewAnimator _enclosing;
		}

		[Sharpen.Stub]
		internal virtual void configureViewAnimator(int numVisibleViews, int activeOffset
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void transformViewForTransition(int fromIndex, int toIndex, android.view.View
			 view, bool animate_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.animation.ObjectAnimator getDefaultInAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.animation.ObjectAnimator getDefaultOutAnimation()
		{
			throw new System.NotImplementedException();
		}

		[android.view.RemotableViewMethod]
		[Sharpen.Stub]
		public virtual void setDisplayedChild(int whichChild)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setDisplayedChild(int whichChild, bool animate_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void applyTransformForChildAtIndex(android.view.View child, int 
			relativeIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDisplayedChild()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void showNext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void showPrevious()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int modulo(int pos, int size)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.view.View getViewAtRelativeIndex(int relativeIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int getNumActiveViews()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int getWindowSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal android.widget.AdapterViewAnimator.ViewAndMetaData getMetaDataForChild(android.view.View
			 child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.view.ViewGroup.LayoutParams createOrReuseLayoutParams(android.view.View
			 v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void refreshChildren()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.widget.FrameLayout getFrameForChild()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void showOnly(int childIndex, bool animate_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addChild(android.view.View child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void showTapFeedback(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void hideTapFeedback(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void cancelHandleClick()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal sealed class CheckForTap : java.lang.Runnable
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}

			internal CheckForTap(AdapterViewAnimator _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AdapterViewAnimator _enclosing;
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void measureChildren()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void checkForAndHandleDataChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class SavedState : android.view.View.BaseSavedState
		{
			internal int whichChild;

			[Sharpen.Stub]
			internal SavedState(android.os.Parcelable superState, int whichChild) : base(superState
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private SavedState(android.os.Parcel @in) : base(@in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_791 : android.os.ParcelableClass.Creator<android.widget.AdapterViewAnimator
				.SavedState>
			{
				public _Creator_791()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.AdapterViewAnimator.SavedState createFromParcel(android.os.Parcel
					 @in)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.AdapterViewAnimator.SavedState[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.AdapterViewAnimator
				.SavedState> CREATOR = new _Creator_791();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View getCurrentView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.ObjectAnimator getInAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInAnimation(android.animation.ObjectAnimator inAnimation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.ObjectAnimator getOutAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOutAnimation(android.animation.ObjectAnimator outAnimation
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInAnimation(android.content.Context context, int resourceID
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOutAnimation(android.content.Context context, int resourceID
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAnimateFirstView(bool animate_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override android.widget.Adapter getAdapter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.Adapter adapter)
		{
			throw new System.NotImplementedException();
		}

		[android.view.RemotableViewMethod]
		[Sharpen.Stub]
		public virtual void setRemoteViewsAdapter(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setSelection(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override android.view.View getSelectedView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback"
			)]
		public virtual void deferNotifyDataSetChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback"
			)]
		public virtual bool onRemoteAdapterConnected()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback"
			)]
		public virtual void onRemoteAdapterDisconnected()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.Advanceable")]
		public virtual void advance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.Advanceable")]
		public virtual void fyiWillBeAdvancedByHostKThx()
		{
			throw new System.NotImplementedException();
		}
	}
}
