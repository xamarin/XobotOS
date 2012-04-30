using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Sharpened]
	public abstract class AbsActionBarView : android.view.ViewGroup
	{
		protected internal android.view.@internal.menu.ActionMenuView mMenuView;

		protected internal android.view.@internal.menu.ActionMenuPresenter mActionMenuPresenter;

		protected internal android.widget.@internal.ActionBarContainer mSplitView;

		protected internal bool mSplitActionBar;

		protected internal bool mSplitWhenNarrow;

		protected internal int mContentHeight;

		protected internal android.animation.Animator mVisibilityAnim;

		protected internal readonly android.widget.@internal.AbsActionBarView.VisibilityAnimListener
			 mVisAnimListener;

		private static readonly android.animation.TimeInterpolator sAlphaInterpolator = new 
			android.view.animation.DecelerateInterpolator();

		internal const int FADE_DURATION = 200;

		public AbsActionBarView(android.content.Context context) : base(context)
		{
			mVisAnimListener = new android.widget.@internal.AbsActionBarView.VisibilityAnimListener
				(this);
		}

		public AbsActionBarView(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			mVisAnimListener = new android.widget.@internal.AbsActionBarView.VisibilityAnimListener
				(this);
		}

		public AbsActionBarView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			mVisAnimListener = new android.widget.@internal.AbsActionBarView.VisibilityAnimListener
				(this);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			base.onConfigurationChanged(newConfig);
			// Action bar can change size on configuration changes.
			// Reread the desired height from the theme-specified style.
			android.content.res.TypedArray a = getContext().obtainStyledAttributes(null, android.@internal.R
				.styleable.ActionBar, android.@internal.R.attr.actionBarStyle, 0);
			setContentHeight(a.getLayoutDimension(android.@internal.R.styleable.ActionBar_height
				, 0));
			a.recycle();
			if (mSplitWhenNarrow)
			{
				setSplitActionBar(getContext().getResources().getBoolean(android.@internal.R.@bool
					.split_action_bar_is_narrow));
			}
			if (mActionMenuPresenter != null)
			{
				mActionMenuPresenter.onConfigurationChanged(newConfig);
			}
		}

		/// <summary>Sets whether the bar should be split right now, no questions asked.</summary>
		/// <remarks>Sets whether the bar should be split right now, no questions asked.</remarks>
		/// <param name="split">true if the bar should split</param>
		public virtual void setSplitActionBar(bool split)
		{
			mSplitActionBar = split;
		}

		/// <summary>Sets whether the bar should split if we enter a narrow screen configuration.
		/// 	</summary>
		/// <remarks>Sets whether the bar should split if we enter a narrow screen configuration.
		/// 	</remarks>
		/// <param name="splitWhenNarrow">true if the bar should check to split after a config change
		/// 	</param>
		public virtual void setSplitWhenNarrow(bool splitWhenNarrow)
		{
			mSplitWhenNarrow = splitWhenNarrow;
		}

		public virtual void setContentHeight(int height)
		{
			mContentHeight = height;
			requestLayout();
		}

		public virtual int getContentHeight()
		{
			return mContentHeight;
		}

		public virtual void setSplitView(android.widget.@internal.ActionBarContainer splitView
			)
		{
			mSplitView = splitView;
		}

		/// <returns>Current visibility or if animating, the visibility being animated to.</returns>
		public virtual int getAnimatedVisibility()
		{
			if (mVisibilityAnim != null)
			{
				return mVisAnimListener.mFinalVisibility;
			}
			return getVisibility();
		}

		public virtual void animateToVisibility(int visibility)
		{
			if (mVisibilityAnim != null)
			{
				mVisibilityAnim.cancel();
			}
			if (visibility == VISIBLE)
			{
				if (getVisibility() != VISIBLE)
				{
					setAlpha(0);
					if (mSplitView != null && mMenuView != null)
					{
						mMenuView.setAlpha(0);
					}
				}
				android.animation.ObjectAnimator anim = android.animation.ObjectAnimator.ofFloat(
					this, "alpha", 1);
				anim.setDuration(FADE_DURATION);
				anim.setInterpolator(sAlphaInterpolator);
				if (mSplitView != null && mMenuView != null)
				{
					android.animation.AnimatorSet set = new android.animation.AnimatorSet();
					android.animation.ObjectAnimator splitAnim = android.animation.ObjectAnimator.ofFloat
						(mMenuView, "alpha", 1);
					splitAnim.setDuration(FADE_DURATION);
					set.addListener(mVisAnimListener.withFinalVisibility(visibility));
					set.play(anim).with(splitAnim);
					set.start();
				}
				else
				{
					anim.addListener(mVisAnimListener.withFinalVisibility(visibility));
					anim.start();
				}
			}
			else
			{
				android.animation.ObjectAnimator anim = android.animation.ObjectAnimator.ofFloat(
					this, "alpha", 0);
				anim.setDuration(FADE_DURATION);
				anim.setInterpolator(sAlphaInterpolator);
				if (mSplitView != null && mMenuView != null)
				{
					android.animation.AnimatorSet set = new android.animation.AnimatorSet();
					android.animation.ObjectAnimator splitAnim = android.animation.ObjectAnimator.ofFloat
						(mMenuView, "alpha", 0);
					splitAnim.setDuration(FADE_DURATION);
					set.addListener(mVisAnimListener.withFinalVisibility(visibility));
					set.play(anim).with(splitAnim);
					set.start();
				}
				else
				{
					anim.addListener(mVisAnimListener.withFinalVisibility(visibility));
					anim.start();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setVisibility(int visibility)
		{
			if (mVisibilityAnim != null)
			{
				mVisibilityAnim.end();
			}
			base.setVisibility(visibility);
		}

		public virtual bool showOverflowMenu()
		{
			if (mActionMenuPresenter != null)
			{
				return mActionMenuPresenter.showOverflowMenu();
			}
			return false;
		}

		private sealed class _Runnable_178 : java.lang.Runnable
		{
			public _Runnable_178(AbsActionBarView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.showOverflowMenu();
			}

			private readonly AbsActionBarView _enclosing;
		}

		public virtual void postShowOverflowMenu()
		{
			post(new _Runnable_178(this));
		}

		public virtual bool hideOverflowMenu()
		{
			if (mActionMenuPresenter != null)
			{
				return mActionMenuPresenter.hideOverflowMenu();
			}
			return false;
		}

		public virtual bool isOverflowMenuShowing()
		{
			if (mActionMenuPresenter != null)
			{
				return mActionMenuPresenter.isOverflowMenuShowing();
			}
			return false;
		}

		public virtual bool isOverflowReserved()
		{
			return mActionMenuPresenter != null && mActionMenuPresenter.isOverflowReserved();
		}

		public virtual void dismissPopupMenus()
		{
			if (mActionMenuPresenter != null)
			{
				mActionMenuPresenter.dismissPopupMenus();
			}
		}

		protected internal virtual int measureChildView(android.view.View child, int availableWidth
			, int childSpecHeight, int spacing)
		{
			child.measure(android.view.View.MeasureSpec.makeMeasureSpec(availableWidth, android.view.View
				.MeasureSpec.AT_MOST), childSpecHeight);
			availableWidth -= child.getMeasuredWidth();
			availableWidth -= spacing;
			return System.Math.Max(0, availableWidth);
		}

		protected internal virtual int positionChild(android.view.View child, int x, int 
			y, int contentHeight)
		{
			int childWidth = child.getMeasuredWidth();
			int childHeight = child.getMeasuredHeight();
			int childTop = y + (contentHeight - childHeight) / 2;
			child.layout(x, childTop, x + childWidth, childTop + childHeight);
			return childWidth;
		}

		protected internal virtual int positionChildInverse(android.view.View child, int 
			x, int y, int contentHeight)
		{
			int childWidth = child.getMeasuredWidth();
			int childHeight = child.getMeasuredHeight();
			int childTop = y + (contentHeight - childHeight) / 2;
			child.layout(x - childWidth, childTop, x, childTop + childHeight);
			return childWidth;
		}

		protected internal class VisibilityAnimListener : android.animation.Animator.AnimatorListener
		{
			private bool mCanceled;

			internal int mFinalVisibility;

			internal virtual android.widget.@internal.AbsActionBarView.VisibilityAnimListener
				 withFinalVisibility(int visibility)
			{
				this.mFinalVisibility = visibility;
				return this;
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationStart(android.animation.Animator animation)
			{
				this._enclosing.setVisibility(android.view.View.VISIBLE);
				this._enclosing.mVisibilityAnim = animation;
				this.mCanceled = false;
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationEnd(android.animation.Animator animation)
			{
				if (this.mCanceled)
				{
					return;
				}
				this._enclosing.mVisibilityAnim = null;
				this._enclosing.setVisibility(this.mFinalVisibility);
				if (this._enclosing.mSplitView != null && this._enclosing.mMenuView != null)
				{
					this._enclosing.mMenuView.setVisibility(this.mFinalVisibility);
				}
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationCancel(android.animation.Animator animation)
			{
				this.mCanceled = true;
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationRepeat(android.animation.Animator animation)
			{
			}

			public VisibilityAnimListener(AbsActionBarView _enclosing)
			{
				this._enclosing = _enclosing;
				mCanceled = false;
			}

			private readonly AbsActionBarView _enclosing;
		}
	}
}
