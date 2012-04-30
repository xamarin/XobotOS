using Sharpen;

namespace android.widget.@internal
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActionBarContextView : android.widget.@internal.AbsActionBarView, android.animation.Animator
		.AnimatorListener
	{
		internal const string TAG = "ActionBarContextView";

		private java.lang.CharSequence mTitle;

		private java.lang.CharSequence mSubtitle;

		private android.view.View mClose;

		private android.view.View mCustomView;

		private android.widget.LinearLayout mTitleLayout;

		private android.widget.TextView mTitleView;

		private android.widget.TextView mSubtitleView;

		private int mTitleStyleRes;

		private int mSubtitleStyleRes;

		private android.graphics.drawable.Drawable mSplitBackground;

		private android.animation.Animator mCurrentAnimation;

		private bool mAnimateInOnLayout;

		private int mAnimationMode;

		internal const int ANIMATE_IDLE = 0;

		internal const int ANIMATE_IN = 1;

		internal const int ANIMATE_OUT = 2;

		public ActionBarContextView(android.content.Context context) : this(context, null
			)
		{
		}

		public ActionBarContextView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, android.@internal.R.attr.actionModeStyle)
		{
		}

		public ActionBarContextView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ActionMode, defStyle, 0);
			setBackgroundDrawable(a.getDrawable(android.@internal.R.styleable.ActionMode_background
				));
			mTitleStyleRes = a.getResourceId(android.@internal.R.styleable.ActionMode_titleTextStyle
				, 0);
			mSubtitleStyleRes = a.getResourceId(android.@internal.R.styleable.ActionMode_subtitleTextStyle
				, 0);
			mContentHeight = a.getLayoutDimension(android.@internal.R.styleable.ActionMode_height
				, 0);
			mSplitBackground = a.getDrawable(android.@internal.R.styleable.ActionMode_backgroundSplit
				);
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			if (mActionMenuPresenter != null)
			{
				mActionMenuPresenter.hideOverflowMenu();
				mActionMenuPresenter.hideSubMenus();
			}
		}

		[Sharpen.OverridesMethod(@"com.android.internal.widget.AbsActionBarView")]
		public override void setSplitActionBar(bool split)
		{
			if (mSplitActionBar != split)
			{
				if (mActionMenuPresenter != null)
				{
					// Mode is already active; move everything over and adjust the menu itself.
					android.view.ViewGroup.LayoutParams layoutParams = new android.view.ViewGroup.LayoutParams
						(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
						.MATCH_PARENT);
					if (!split)
					{
						mMenuView = (android.view.@internal.menu.ActionMenuView)mActionMenuPresenter.getMenuView
							(this);
						mMenuView.setBackgroundDrawable(null);
						android.view.ViewGroup oldParent = (android.view.ViewGroup)mMenuView.getParent();
						if (oldParent != null)
						{
							oldParent.removeView(mMenuView);
						}
						addView(mMenuView, layoutParams);
					}
					else
					{
						// Allow full screen width in split mode.
						mActionMenuPresenter.setWidthLimit(getContext().getResources().getDisplayMetrics(
							).widthPixels, true);
						// No limit to the item count; use whatever will fit.
						mActionMenuPresenter.setItemLimit(int.MaxValue);
						// Span the whole width
						layoutParams.width = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
						layoutParams.height = mContentHeight;
						mMenuView = (android.view.@internal.menu.ActionMenuView)mActionMenuPresenter.getMenuView
							(this);
						mMenuView.setBackgroundDrawable(mSplitBackground);
						android.view.ViewGroup oldParent = (android.view.ViewGroup)mMenuView.getParent();
						if (oldParent != null)
						{
							oldParent.removeView(mMenuView);
						}
						mSplitView.addView(mMenuView, layoutParams);
					}
				}
				base.setSplitActionBar(split);
			}
		}

		[Sharpen.OverridesMethod(@"com.android.internal.widget.AbsActionBarView")]
		public override void setContentHeight(int height)
		{
			mContentHeight = height;
		}

		public virtual void setCustomView(android.view.View view)
		{
			if (mCustomView != null)
			{
				removeView(mCustomView);
			}
			mCustomView = view;
			if (mTitleLayout != null)
			{
				removeView(mTitleLayout);
				mTitleLayout = null;
			}
			if (view != null)
			{
				addView(view);
			}
			requestLayout();
		}

		public virtual void setTitle(java.lang.CharSequence title)
		{
			mTitle = title;
			initTitle();
		}

		public virtual void setSubtitle(java.lang.CharSequence subtitle)
		{
			mSubtitle = subtitle;
			initTitle();
		}

		public virtual java.lang.CharSequence getTitle()
		{
			return mTitle;
		}

		public virtual java.lang.CharSequence getSubtitle()
		{
			return mSubtitle;
		}

		private void initTitle()
		{
			if (mTitleLayout == null)
			{
				android.view.LayoutInflater inflater = android.view.LayoutInflater.from(getContext
					());
				inflater.inflate(android.@internal.R.layout.action_bar_title_item, this);
				mTitleLayout = (android.widget.LinearLayout)getChildAt(getChildCount() - 1);
				mTitleView = (android.widget.TextView)mTitleLayout.findViewById(android.@internal.R
					.id.action_bar_title);
				mSubtitleView = (android.widget.TextView)mTitleLayout.findViewById(android.@internal.R
					.id.action_bar_subtitle);
				if (mTitleStyleRes != 0)
				{
					mTitleView.setTextAppearance(mContext, mTitleStyleRes);
				}
				if (mSubtitleStyleRes != 0)
				{
					mSubtitleView.setTextAppearance(mContext, mSubtitleStyleRes);
				}
			}
			mTitleView.setText(mTitle);
			mSubtitleView.setText(mSubtitle);
			bool hasTitle = !android.text.TextUtils.isEmpty(mTitle);
			bool hasSubtitle = !android.text.TextUtils.isEmpty(mSubtitle);
			mSubtitleView.setVisibility(hasSubtitle ? VISIBLE : GONE);
			mTitleLayout.setVisibility(hasTitle || hasSubtitle ? VISIBLE : GONE);
			if (mTitleLayout.getParent() == null)
			{
				addView(mTitleLayout);
			}
		}

		private sealed class _OnClickListener_212 : android.view.View.OnClickListener
		{
			public _OnClickListener_212(android.view.ActionMode mode)
			{
				this.mode = mode;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				mode.finish();
			}

			private readonly android.view.ActionMode mode;
		}

		public virtual void initForMode(android.view.ActionMode mode)
		{
			if (mClose == null)
			{
				android.view.LayoutInflater inflater = android.view.LayoutInflater.from(mContext);
				mClose = inflater.inflate(android.@internal.R.layout.action_mode_close_item, this
					, false);
				addView(mClose);
			}
			else
			{
				if (mClose.getParent() == null)
				{
					addView(mClose);
				}
			}
			android.view.View closeButton = mClose.findViewById(android.@internal.R.id.action_mode_close_button
				);
			closeButton.setOnClickListener(new _OnClickListener_212(mode));
			android.view.@internal.menu.MenuBuilder menu = (android.view.@internal.menu.MenuBuilder
				)mode.getMenu();
			mActionMenuPresenter = new android.view.@internal.menu.ActionMenuPresenter(mContext
				);
			mActionMenuPresenter.setReserveOverflow(true);
			android.view.ViewGroup.LayoutParams layoutParams = new android.view.ViewGroup.LayoutParams
				(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
				.MATCH_PARENT);
			if (!mSplitActionBar)
			{
				menu.addMenuPresenter(mActionMenuPresenter);
				mMenuView = (android.view.@internal.menu.ActionMenuView)mActionMenuPresenter.getMenuView
					(this);
				mMenuView.setBackgroundDrawable(null);
				addView(mMenuView, layoutParams);
			}
			else
			{
				// Allow full screen width in split mode.
				mActionMenuPresenter.setWidthLimit(getContext().getResources().getDisplayMetrics(
					).widthPixels, true);
				// No limit to the item count; use whatever will fit.
				mActionMenuPresenter.setItemLimit(int.MaxValue);
				// Span the whole width
				layoutParams.width = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				layoutParams.height = mContentHeight;
				menu.addMenuPresenter(mActionMenuPresenter);
				mMenuView = (android.view.@internal.menu.ActionMenuView)mActionMenuPresenter.getMenuView
					(this);
				mMenuView.setBackgroundDrawable(mSplitBackground);
				mSplitView.addView(mMenuView, layoutParams);
			}
			mAnimateInOnLayout = true;
		}

		public virtual void closeMode()
		{
			if (mAnimationMode == ANIMATE_OUT)
			{
				// Called again during close; just finish what we were doing.
				return;
			}
			if (mClose == null)
			{
				killMode();
				return;
			}
			finishAnimation();
			mAnimationMode = ANIMATE_OUT;
			mCurrentAnimation = makeOutAnimation();
			mCurrentAnimation.start();
		}

		private void finishAnimation()
		{
			android.animation.Animator a = mCurrentAnimation;
			if (a != null)
			{
				mCurrentAnimation = null;
				a.end();
			}
		}

		public virtual void killMode()
		{
			finishAnimation();
			removeAllViews();
			if (mSplitView != null)
			{
				mSplitView.removeView(mMenuView);
			}
			mCustomView = null;
			mMenuView = null;
			mAnimateInOnLayout = false;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.widget.AbsActionBarView")]
		public override bool showOverflowMenu()
		{
			if (mActionMenuPresenter != null)
			{
				return mActionMenuPresenter.showOverflowMenu();
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.widget.AbsActionBarView")]
		public override bool hideOverflowMenu()
		{
			if (mActionMenuPresenter != null)
			{
				return mActionMenuPresenter.hideOverflowMenu();
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.widget.AbsActionBarView")]
		public override bool isOverflowMenuShowing()
		{
			if (mActionMenuPresenter != null)
			{
				return mActionMenuPresenter.isOverflowMenuShowing();
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			// Used by custom views if they don't supply layout params. Everything else
			// added to an ActionBarContextView should have them already.
			return new android.view.ViewGroup.MarginLayoutParams(android.view.ViewGroup.LayoutParams
				.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.view.ViewGroup.MarginLayoutParams(getContext(), attrs);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			if (widthMode != android.view.View.MeasureSpec.EXACTLY)
			{
				throw new System.InvalidOperationException(GetType().Name + " can only be used " 
					+ "with android:layout_width=\"match_parent\" (or fill_parent)");
			}
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			if (heightMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				throw new System.InvalidOperationException(GetType().Name + " can only be used " 
					+ "with android:layout_height=\"wrap_content\"");
			}
			int contentWidth = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int maxHeight = mContentHeight > 0 ? mContentHeight : android.view.View.MeasureSpec
				.getSize(heightMeasureSpec);
			int verticalPadding = getPaddingTop() + getPaddingBottom();
			int availableWidth = contentWidth - getPaddingLeft() - getPaddingRight();
			int height = maxHeight - verticalPadding;
			int childSpecHeight = android.view.View.MeasureSpec.makeMeasureSpec(height, android.view.View
				.MeasureSpec.AT_MOST);
			if (mClose != null)
			{
				availableWidth = measureChildView(mClose, availableWidth, childSpecHeight, 0);
				android.view.ViewGroup.MarginLayoutParams lp = (android.view.ViewGroup.MarginLayoutParams
					)mClose.getLayoutParams();
				availableWidth -= lp.leftMargin + lp.rightMargin;
			}
			if (mMenuView != null && mMenuView.getParent() == this)
			{
				availableWidth = measureChildView(mMenuView, availableWidth, childSpecHeight, 0);
			}
			if (mTitleLayout != null && mCustomView == null)
			{
				availableWidth = measureChildView(mTitleLayout, availableWidth, childSpecHeight, 
					0);
			}
			if (mCustomView != null)
			{
				android.view.ViewGroup.LayoutParams lp = mCustomView.getLayoutParams();
				int customWidthMode = lp.width != android.view.ViewGroup.LayoutParams.WRAP_CONTENT
					 ? android.view.View.MeasureSpec.EXACTLY : android.view.View.MeasureSpec.AT_MOST;
				int customWidth = lp.width >= 0 ? System.Math.Min(lp.width, availableWidth) : availableWidth;
				int customHeightMode = lp.height != android.view.ViewGroup.LayoutParams.WRAP_CONTENT
					 ? android.view.View.MeasureSpec.EXACTLY : android.view.View.MeasureSpec.AT_MOST;
				int customHeight = lp.height >= 0 ? System.Math.Min(lp.height, height) : height;
				mCustomView.measure(android.view.View.MeasureSpec.makeMeasureSpec(customWidth, customWidthMode
					), android.view.View.MeasureSpec.makeMeasureSpec(customHeight, customHeightMode)
					);
			}
			if (mContentHeight <= 0)
			{
				int measuredHeight = 0;
				int count = getChildCount();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View v = getChildAt(i);
						int paddedViewHeight = v.getMeasuredHeight() + verticalPadding;
						if (paddedViewHeight > measuredHeight)
						{
							measuredHeight = paddedViewHeight;
						}
					}
				}
				setMeasuredDimension(contentWidth, measuredHeight);
			}
			else
			{
				setMeasuredDimension(contentWidth, maxHeight);
			}
		}

		private android.animation.Animator makeInAnimation()
		{
			mClose.setTranslationX(-mClose.getWidth() - ((android.view.ViewGroup.MarginLayoutParams
				)mClose.getLayoutParams()).leftMargin);
			android.animation.ObjectAnimator buttonAnimator = android.animation.ObjectAnimator
				.ofFloat(mClose, "translationX", 0);
			buttonAnimator.setDuration(200);
			buttonAnimator.addListener(this);
			buttonAnimator.setInterpolator(new android.view.animation.DecelerateInterpolator(
				));
			android.animation.AnimatorSet set = new android.animation.AnimatorSet();
			android.animation.AnimatorSet.Builder b = set.play(buttonAnimator);
			if (mMenuView != null)
			{
				int count = mMenuView.getChildCount();
				if (count > 0)
				{
					{
						int i = count - 1;
						int j = 0;
						for (; i >= 0; i--, j++)
						{
							android.view.View child = mMenuView.getChildAt(i);
							child.setScaleY(0);
							android.animation.ObjectAnimator a = android.animation.ObjectAnimator.ofFloat(child
								, "scaleY", 0, 1);
							a.setDuration(100);
							a.setStartDelay(j * 70);
							b.with(a);
						}
					}
				}
			}
			return set;
		}

		private android.animation.Animator makeOutAnimation()
		{
			android.animation.ObjectAnimator buttonAnimator = android.animation.ObjectAnimator
				.ofFloat(mClose, "translationX", -mClose.getWidth() - ((android.view.ViewGroup.MarginLayoutParams
				)mClose.getLayoutParams()).leftMargin);
			buttonAnimator.setDuration(200);
			buttonAnimator.addListener(this);
			buttonAnimator.setInterpolator(new android.view.animation.DecelerateInterpolator(
				));
			android.animation.AnimatorSet set = new android.animation.AnimatorSet();
			android.animation.AnimatorSet.Builder b = set.play(buttonAnimator);
			if (mMenuView != null)
			{
				int count = mMenuView.getChildCount();
				if (count > 0)
				{
					{
						for (int i = 0; i < 0; i++)
						{
							android.view.View child = mMenuView.getChildAt(i);
							child.setScaleY(0);
							android.animation.ObjectAnimator a = android.animation.ObjectAnimator.ofFloat(child
								, "scaleY", 0);
							a.setDuration(100);
							a.setStartDelay(i * 70);
							b.with(a);
						}
					}
				}
			}
			return set;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			int x = getPaddingLeft();
			int y = getPaddingTop();
			int contentHeight = b - t - getPaddingTop() - getPaddingBottom();
			if (mClose != null && mClose.getVisibility() != GONE)
			{
				android.view.ViewGroup.MarginLayoutParams lp = (android.view.ViewGroup.MarginLayoutParams
					)mClose.getLayoutParams();
				x += lp.leftMargin;
				x += positionChild(mClose, x, y, contentHeight);
				x += lp.rightMargin;
				if (mAnimateInOnLayout)
				{
					mAnimationMode = ANIMATE_IN;
					mCurrentAnimation = makeInAnimation();
					mCurrentAnimation.start();
					mAnimateInOnLayout = false;
				}
			}
			if (mTitleLayout != null && mCustomView == null)
			{
				x += positionChild(mTitleLayout, x, y, contentHeight);
			}
			if (mCustomView != null)
			{
				x += positionChild(mCustomView, x, y, contentHeight);
			}
			x = r - l - getPaddingRight();
			if (mMenuView != null)
			{
				x -= positionChildInverse(mMenuView, x, y, contentHeight);
			}
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationStart(android.animation.Animator animation)
		{
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationEnd(android.animation.Animator animation)
		{
			if (mAnimationMode == ANIMATE_OUT)
			{
				killMode();
			}
			mAnimationMode = ANIMATE_IDLE;
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationCancel(android.animation.Animator animation)
		{
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationRepeat(android.animation.Animator animation)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool shouldDelayChildPressedState()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (@event.getEventType() == android.view.accessibility.AccessibilityEvent.TYPE_WINDOW_STATE_CHANGED)
			{
				// Action mode started
				@event.setSource(this);
				@event.setClassName(java.lang.CharSequenceProxy.Wrap(GetType().FullName));
				@event.setPackageName(java.lang.CharSequenceProxy.Wrap(getContext().getPackageName
					()));
				@event.setContentDescription(mTitle);
			}
			else
			{
				base.onInitializeAccessibilityEvent(@event);
			}
		}
	}
}
