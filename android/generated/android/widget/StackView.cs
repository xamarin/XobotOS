using Sharpen;

namespace android.widget
{
	[Sharpen.Sharpened]
	public class StackView : android.widget.AdapterViewAnimator
	{
		private readonly string TAG = "StackView";

		/// <summary>Default animation parameters</summary>
		internal const int DEFAULT_ANIMATION_DURATION = 400;

		internal const int MINIMUM_ANIMATION_DURATION = 50;

		internal const int STACK_RELAYOUT_DURATION = 100;

		/// <summary>Parameters effecting the perspective visuals</summary>
		internal const float PERSPECTIVE_SHIFT_FACTOR_Y = 0.1f;

		internal const float PERSPECTIVE_SHIFT_FACTOR_X = 0.1f;

		private float mPerspectiveShiftX;

		private float mPerspectiveShiftY;

		private float mNewPerspectiveShiftX;

		private float mNewPerspectiveShiftY;

		internal const float PERSPECTIVE_SCALE_FACTOR = 0f;

		/// <summary>
		/// Represent the two possible stack modes, one where items slide up, and the other
		/// where items slide down.
		/// </summary>
		/// <remarks>
		/// Represent the two possible stack modes, one where items slide up, and the other
		/// where items slide down. The perspective is also inverted between these two modes.
		/// </remarks>
		internal const int ITEMS_SLIDE_UP = 0;

		internal const int ITEMS_SLIDE_DOWN = 1;

		/// <summary>These specify the different gesture states</summary>
		internal const int GESTURE_NONE = 0;

		internal const int GESTURE_SLIDE_UP = 1;

		internal const int GESTURE_SLIDE_DOWN = 2;

		/// <summary>
		/// Specifies how far you need to swipe (up or down) before it
		/// will be consider a completed gesture when you lift your finger
		/// </summary>
		internal const float SWIPE_THRESHOLD_RATIO = 0.2f;

		/// <summary>
		/// Specifies the total distance, relative to the size of the stack,
		/// that views will be slid, either up or down
		/// </summary>
		internal const float SLIDE_UP_RATIO = 0.7f;

		/// <summary>Sentinel value for no current active pointer.</summary>
		/// <remarks>
		/// Sentinel value for no current active pointer.
		/// Used by
		/// <see cref="mActivePointerId">mActivePointerId</see>
		/// .
		/// </remarks>
		internal const int INVALID_POINTER = -1;

		/// <summary>Number of active views in the stack.</summary>
		/// <remarks>Number of active views in the stack. One fewer view is actually visible, as one is hidden.
		/// 	</remarks>
		internal const int NUM_ACTIVE_VIEWS = 5;

		internal const int FRAME_PADDING = 4;

		private readonly android.graphics.Rect mTouchRect = new android.graphics.Rect();

		internal const int MIN_TIME_BETWEEN_INTERACTION_AND_AUTOADVANCE = 5000;

		internal const long MIN_TIME_BETWEEN_SCROLLS = 100;

		/// <summary>
		/// These variables are all related to the current state of touch interaction
		/// with the stack
		/// </summary>
		private float mInitialY;

		private float mInitialX;

		private int mActivePointerId;

		private int mYVelocity = 0;

		private int mSwipeGestureType = GESTURE_NONE;

		private int mSlideAmount;

		private int mSwipeThreshold;

		private int mTouchSlop;

		private int mMaximumVelocity;

		private android.view.VelocityTracker mVelocityTracker;

		private bool mTransitionIsSetup = false;

		private int mResOutColor;

		private int mClickColor;

		private static android.widget.StackView.HolographicHelper sHolographicHelper;

		private android.widget.ImageView mHighlight;

		private android.widget.ImageView mClickFeedback;

		private bool mClickFeedbackIsValid = false;

		private android.widget.StackView.StackSlider mStackSlider;

		private bool mFirstLayoutHappened = false;

		private long mLastInteractionTime = 0;

		private long mLastScrollTime;

		private int mStackMode;

		private int mFramePadding;

		private readonly android.graphics.Rect stackInvalidateRect = new android.graphics.Rect
			();

		/// <summary><inheritDoc></inheritDoc></summary>
		public StackView(android.content.Context context) : this(context, null)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public StackView(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.stackViewStyle)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public StackView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyleAttr) : base(context, attrs, defStyleAttr)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.StackView, defStyleAttr, 0);
			mResOutColor = a.getColor(android.@internal.R.styleable.StackView_resOutColor, 0);
			mClickColor = a.getColor(android.@internal.R.styleable.StackView_clickColor, 0);
			a.recycle();
			initStackView();
		}

		private void initStackView()
		{
			configureViewAnimator(NUM_ACTIVE_VIEWS, 1);
			setStaticTransformationsEnabled(true);
			android.view.ViewConfiguration configuration = android.view.ViewConfiguration.get
				(getContext());
			mTouchSlop = configuration.getScaledTouchSlop();
			mMaximumVelocity = configuration.getScaledMaximumFlingVelocity();
			mActivePointerId = INVALID_POINTER;
			mHighlight = new android.widget.ImageView(getContext());
			mHighlight.setLayoutParams(new android.widget.StackView.LayoutParams(this, mHighlight
				));
			addViewInLayout(mHighlight, -1, new android.widget.StackView.LayoutParams(this, mHighlight
				));
			mClickFeedback = new android.widget.ImageView(getContext());
			mClickFeedback.setLayoutParams(new android.widget.StackView.LayoutParams(this, mClickFeedback
				));
			addViewInLayout(mClickFeedback, -1, new android.widget.StackView.LayoutParams(this
				, mClickFeedback));
			mClickFeedback.setVisibility(INVISIBLE);
			mStackSlider = new android.widget.StackView.StackSlider(this);
			if (sHolographicHelper == null)
			{
				sHolographicHelper = new android.widget.StackView.HolographicHelper(mContext);
			}
			setClipChildren(false);
			setClipToPadding(false);
			// This sets the form of the StackView, which is currently to have the perspective-shifted
			// views above the active view, and have items slide down when sliding out. The opposite is
			// available by using ITEMS_SLIDE_UP.
			mStackMode = ITEMS_SLIDE_DOWN;
			// This is a flag to indicate the the stack is loading for the first time
			mWhichChild = -1;
			// Adjust the frame padding based on the density, since the highlight changes based
			// on the density
			float density = mContext.getResources().getDisplayMetrics().density;
			mFramePadding = (int)System.Math.Ceiling(density * FRAME_PADDING);
		}

		private sealed class _Runnable_294 : java.lang.Runnable
		{
			public _Runnable_294(android.view.View view)
			{
				this.view = view;
			}

			// Slide item in
			// Slide item out
			// Make sure this view that is "waiting in the wings" is invisible
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				view.setAlpha(0);
			}

			private readonly android.view.View view;
		}

		/// <summary>
		/// Animate the views between different relative indexes within the
		/// <see cref="AdapterViewAnimator">AdapterViewAnimator</see>
		/// </summary>
		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		internal override void transformViewForTransition(int fromIndex, int toIndex, android.view.View
			 view, bool animate_1)
		{
			if (!animate_1)
			{
				((android.widget.StackView.StackFrame)view).cancelSliderAnimator();
				view.setRotationX(0f);
				android.widget.StackView.LayoutParams lp = (android.widget.StackView.LayoutParams
					)view.getLayoutParams();
				lp.setVerticalOffset(0);
				lp.setHorizontalOffset(0);
			}
			if (fromIndex == -1 && toIndex == getNumActiveViews() - 1)
			{
				transformViewAtIndex(toIndex, view, false);
				view.setVisibility(VISIBLE);
				view.setAlpha(1.0f);
			}
			else
			{
				if (fromIndex == 0 && toIndex == 1)
				{
					((android.widget.StackView.StackFrame)view).cancelSliderAnimator();
					view.setVisibility(VISIBLE);
					int duration = Sharpen.Util.Round(mStackSlider.getDurationForNeutralPosition(mYVelocity
						));
					android.widget.StackView.StackSlider animationSlider = new android.widget.StackView
						.StackSlider(this, mStackSlider);
					animationSlider.setView(view);
					if (animate_1)
					{
						android.animation.PropertyValuesHolder slideInY = android.animation.PropertyValuesHolder
							.ofFloat("YProgress", 0.0f);
						android.animation.PropertyValuesHolder slideInX = android.animation.PropertyValuesHolder
							.ofFloat("XProgress", 0.0f);
						android.animation.ObjectAnimator slideIn = android.animation.ObjectAnimator.ofPropertyValuesHolder
							(animationSlider, slideInX, slideInY);
						slideIn.setDuration(duration);
						slideIn.setInterpolator(new android.view.animation.LinearInterpolator());
						((android.widget.StackView.StackFrame)view).setSliderAnimator(slideIn);
						slideIn.start();
					}
					else
					{
						animationSlider.setYProgress(0f);
						animationSlider.setXProgress(0f);
					}
				}
				else
				{
					if (fromIndex == 1 && toIndex == 0)
					{
						((android.widget.StackView.StackFrame)view).cancelSliderAnimator();
						int duration = Sharpen.Util.Round(mStackSlider.getDurationForOffscreenPosition(mYVelocity
							));
						android.widget.StackView.StackSlider animationSlider = new android.widget.StackView
							.StackSlider(this, mStackSlider);
						animationSlider.setView(view);
						if (animate_1)
						{
							android.animation.PropertyValuesHolder slideOutY = android.animation.PropertyValuesHolder
								.ofFloat("YProgress", 1.0f);
							android.animation.PropertyValuesHolder slideOutX = android.animation.PropertyValuesHolder
								.ofFloat("XProgress", 0.0f);
							android.animation.ObjectAnimator slideOut = android.animation.ObjectAnimator.ofPropertyValuesHolder
								(animationSlider, slideOutX, slideOutY);
							slideOut.setDuration(duration);
							slideOut.setInterpolator(new android.view.animation.LinearInterpolator());
							((android.widget.StackView.StackFrame)view).setSliderAnimator(slideOut);
							slideOut.start();
						}
						else
						{
							animationSlider.setYProgress(1.0f);
							animationSlider.setXProgress(0f);
						}
					}
					else
					{
						if (toIndex == 0)
						{
							view.setAlpha(0.0f);
							view.setVisibility(INVISIBLE);
						}
						else
						{
							if ((fromIndex == 0 || fromIndex == 1) && toIndex > 1)
							{
								view.setVisibility(VISIBLE);
								view.setAlpha(1.0f);
								view.setRotationX(0f);
								android.widget.StackView.LayoutParams lp = (android.widget.StackView.LayoutParams
									)view.getLayoutParams();
								lp.setVerticalOffset(0);
								lp.setHorizontalOffset(0);
							}
							else
							{
								if (fromIndex == -1)
								{
									view.setAlpha(1.0f);
									view.setVisibility(VISIBLE);
								}
								else
								{
									if (toIndex == -1)
									{
										if (animate_1)
										{
											postDelayed(new _Runnable_294(view), STACK_RELAYOUT_DURATION);
										}
										else
										{
											view.setAlpha(0f);
										}
									}
								}
							}
						}
					}
				}
			}
			// Implement the faked perspective
			if (toIndex != -1)
			{
				transformViewAtIndex(toIndex, view, animate_1);
			}
		}

		private void transformViewAtIndex(int index, android.view.View view, bool animate_1
			)
		{
			float maxPerspectiveShiftY = mPerspectiveShiftY;
			float maxPerspectiveShiftX = mPerspectiveShiftX;
			if (mStackMode == ITEMS_SLIDE_DOWN)
			{
				index = mMaxNumActiveViews - index - 1;
				if (index == mMaxNumActiveViews - 1)
				{
					index--;
				}
			}
			else
			{
				index--;
				if (index < 0)
				{
					index++;
				}
			}
			float r = (index * 1.0f) / (mMaxNumActiveViews - 2);
			float scale = 1 - PERSPECTIVE_SCALE_FACTOR * (1 - r);
			float perspectiveTranslationY = r * maxPerspectiveShiftY;
			float scaleShiftCorrectionY = (scale - 1) * (getMeasuredHeight() * (1 - PERSPECTIVE_SHIFT_FACTOR_Y
				) / 2.0f);
			float transY = perspectiveTranslationY + scaleShiftCorrectionY;
			float perspectiveTranslationX = (1 - r) * maxPerspectiveShiftX;
			float scaleShiftCorrectionX = (1 - scale) * (getMeasuredWidth() * (1 - PERSPECTIVE_SHIFT_FACTOR_X
				) / 2.0f);
			float transX = perspectiveTranslationX + scaleShiftCorrectionX;
			// If this view is currently being animated for a certain position, we need to cancel
			// this animation so as not to interfere with the new transformation.
			if (view is android.widget.StackView.StackFrame)
			{
				((android.widget.StackView.StackFrame)view).cancelTransformAnimator();
			}
			if (animate_1)
			{
				android.animation.PropertyValuesHolder translationX = android.animation.PropertyValuesHolder
					.ofFloat("translationX", transX);
				android.animation.PropertyValuesHolder translationY = android.animation.PropertyValuesHolder
					.ofFloat("translationY", transY);
				android.animation.PropertyValuesHolder scalePropX = android.animation.PropertyValuesHolder
					.ofFloat("scaleX", scale);
				android.animation.PropertyValuesHolder scalePropY = android.animation.PropertyValuesHolder
					.ofFloat("scaleY", scale);
				android.animation.ObjectAnimator oa = android.animation.ObjectAnimator.ofPropertyValuesHolder
					(view, scalePropX, scalePropY, translationY, translationX);
				oa.setDuration(STACK_RELAYOUT_DURATION);
				if (view is android.widget.StackView.StackFrame)
				{
					((android.widget.StackView.StackFrame)view).setTransformAnimator(oa);
				}
				oa.start();
			}
			else
			{
				view.setTranslationX(transX);
				view.setTranslationY(transY);
				view.setScaleX(scale);
				view.setScaleY(scale);
			}
		}

		private void setupStackSlider(android.view.View v, int mode)
		{
			mStackSlider.setMode(mode);
			if (v != null)
			{
				mHighlight.setImageBitmap(sHolographicHelper.createResOutline(v, mResOutColor));
				mHighlight.setRotation(v.getRotation());
				mHighlight.setTranslationY(v.getTranslationY());
				mHighlight.setTranslationX(v.getTranslationX());
				mHighlight.bringToFront();
				v.bringToFront();
				mStackSlider.setView(v);
				v.setVisibility(VISIBLE);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		public override void showNext()
		{
			if (mSwipeGestureType != GESTURE_NONE)
			{
				return;
			}
			if (!mTransitionIsSetup)
			{
				android.view.View v = getViewAtRelativeIndex(1);
				if (v != null)
				{
					setupStackSlider(v, android.widget.StackView.StackSlider.NORMAL_MODE);
					mStackSlider.setYProgress(0);
					mStackSlider.setXProgress(0);
				}
			}
			base.showNext();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		public override void showPrevious()
		{
			if (mSwipeGestureType != GESTURE_NONE)
			{
				return;
			}
			if (!mTransitionIsSetup)
			{
				android.view.View v = getViewAtRelativeIndex(0);
				if (v != null)
				{
					setupStackSlider(v, android.widget.StackView.StackSlider.NORMAL_MODE);
					mStackSlider.setYProgress(1);
					mStackSlider.setXProgress(0);
				}
			}
			base.showPrevious();
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		internal override void showOnly(int childIndex, bool animate_1)
		{
			base.showOnly(childIndex, animate_1);
			{
				// Here we need to make sure that the z-order of the children is correct
				for (int i = mCurrentWindowEnd; i >= mCurrentWindowStart; i--)
				{
					int index = modulo(i, getWindowSize());
					android.widget.AdapterViewAnimator.ViewAndMetaData vm = mViewsMap.get(index);
					if (vm != null)
					{
						android.view.View v = mViewsMap.get(index).view;
						if (v != null)
						{
							v.bringToFront();
						}
					}
				}
			}
			if (mHighlight != null)
			{
				mHighlight.bringToFront();
			}
			mTransitionIsSetup = false;
			mClickFeedbackIsValid = false;
		}

		internal virtual void updateClickFeedback()
		{
			if (!mClickFeedbackIsValid)
			{
				android.view.View v = getViewAtRelativeIndex(1);
				if (v != null)
				{
					mClickFeedback.setImageBitmap(sHolographicHelper.createClickOutline(v, mClickColor
						));
					mClickFeedback.setTranslationX(v.getTranslationX());
					mClickFeedback.setTranslationY(v.getTranslationY());
				}
				mClickFeedbackIsValid = true;
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		internal override void showTapFeedback(android.view.View v)
		{
			updateClickFeedback();
			mClickFeedback.setVisibility(VISIBLE);
			mClickFeedback.bringToFront();
			invalidate();
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		internal override void hideTapFeedback(android.view.View v)
		{
			mClickFeedback.setVisibility(INVISIBLE);
			invalidate();
		}

		private void updateChildTransforms()
		{
			{
				for (int i = 0; i < getNumActiveViews(); i++)
				{
					android.view.View v = getViewAtRelativeIndex(i);
					if (v != null)
					{
						transformViewAtIndex(i, v, false);
					}
				}
			}
		}

		private class StackFrame : android.widget.FrameLayout
		{
			internal java.lang.@ref.WeakReference<android.animation.ObjectAnimator> transformAnimator;

			internal java.lang.@ref.WeakReference<android.animation.ObjectAnimator> sliderAnimator;

			public StackFrame(android.content.Context context) : base(context)
			{
			}

			internal virtual void setTransformAnimator(android.animation.ObjectAnimator oa)
			{
				transformAnimator = new java.lang.@ref.WeakReference<android.animation.ObjectAnimator
					>(oa);
			}

			internal virtual void setSliderAnimator(android.animation.ObjectAnimator oa)
			{
				sliderAnimator = new java.lang.@ref.WeakReference<android.animation.ObjectAnimator
					>(oa);
			}

			internal virtual bool cancelTransformAnimator()
			{
				if (transformAnimator != null)
				{
					android.animation.ObjectAnimator oa = transformAnimator.get();
					if (oa != null)
					{
						oa.cancel();
						return true;
					}
				}
				return false;
			}

			internal virtual bool cancelSliderAnimator()
			{
				if (sliderAnimator != null)
				{
					android.animation.ObjectAnimator oa = sliderAnimator.get();
					if (oa != null)
					{
						oa.cancel();
						return true;
					}
				}
				return false;
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		internal override android.widget.FrameLayout getFrameForChild()
		{
			android.widget.StackView.StackFrame fl = new android.widget.StackView.StackFrame(
				mContext);
			fl.setPadding(mFramePadding, mFramePadding, mFramePadding, mFramePadding);
			return fl;
		}

		/// <summary>Apply any necessary tranforms for the child that is being added.</summary>
		/// <remarks>Apply any necessary tranforms for the child that is being added.</remarks>
		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		internal override void applyTransformForChildAtIndex(android.view.View child, int
			 relativeIndex)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			bool expandClipRegion = false;
			canvas.getClipBounds(stackInvalidateRect);
			int childCount = getChildCount();
			{
				for (int i = 0; i < childCount; i++)
				{
					android.view.View child = getChildAt(i);
					android.widget.StackView.LayoutParams lp = (android.widget.StackView.LayoutParams
						)child.getLayoutParams();
					if ((lp.horizontalOffset == 0 && lp.verticalOffset == 0) || child.getAlpha() == 0f
						 || child.getVisibility() != VISIBLE)
					{
						lp.resetInvalidateRect();
					}
					android.graphics.Rect childInvalidateRect = lp.getInvalidateRect();
					if (!childInvalidateRect.isEmpty())
					{
						expandClipRegion = true;
						stackInvalidateRect.union(childInvalidateRect);
					}
				}
			}
			// We only expand the clip bounds if necessary.
			if (expandClipRegion)
			{
				canvas.save(android.graphics.Canvas.CLIP_SAVE_FLAG);
				canvas.clipRect(stackInvalidateRect, android.graphics.Region.Op.UNION);
				base.dispatchDraw(canvas);
				canvas.restore();
			}
			else
			{
				base.dispatchDraw(canvas);
			}
		}

		private void onLayout()
		{
			if (!mFirstLayoutHappened)
			{
				mFirstLayoutHappened = true;
				updateChildTransforms();
			}
			int newSlideAmount = Sharpen.Util.Round(SLIDE_UP_RATIO * getMeasuredHeight());
			if (mSlideAmount != newSlideAmount)
			{
				mSlideAmount = newSlideAmount;
				mSwipeThreshold = Sharpen.Util.Round(SWIPE_THRESHOLD_RATIO * newSlideAmount);
			}
			if (mPerspectiveShiftY.CompareTo(mNewPerspectiveShiftY) != 0 || mPerspectiveShiftX
				.CompareTo(mNewPerspectiveShiftX) != 0)
			{
				mPerspectiveShiftY = mNewPerspectiveShiftY;
				mPerspectiveShiftX = mNewPerspectiveShiftX;
				updateChildTransforms();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onGenericMotionEvent(android.view.MotionEvent @event)
		{
			if ((@event.getSource() & android.view.InputDevice.SOURCE_CLASS_POINTER) != 0)
			{
				switch (@event.getAction())
				{
					case android.view.MotionEvent.ACTION_SCROLL:
					{
						float vscroll = @event.getAxisValue(android.view.MotionEvent.AXIS_VSCROLL);
						if (vscroll < 0)
						{
							pacedScroll(false);
							return true;
						}
						else
						{
							if (vscroll > 0)
							{
								pacedScroll(true);
								return true;
							}
						}
						break;
					}
				}
			}
			return base.onGenericMotionEvent(@event);
		}

		// This ensures that the frequency of stack flips caused by scrolls is capped
		private void pacedScroll(bool up)
		{
			long timeSinceLastScroll = Sharpen.Util.CurrentTimeMillis - mLastScrollTime;
			if (timeSinceLastScroll > MIN_TIME_BETWEEN_SCROLLS)
			{
				if (up)
				{
					showPrevious();
				}
				else
				{
					showNext();
				}
				mLastScrollTime = Sharpen.Util.CurrentTimeMillis;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onInterceptTouchEvent(android.view.MotionEvent ev)
		{
			int action = ev.getAction();
			switch (action & android.view.MotionEvent.ACTION_MASK)
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					if (mActivePointerId == INVALID_POINTER)
					{
						mInitialX = ev.getX();
						mInitialY = ev.getY();
						mActivePointerId = ev.getPointerId(0);
					}
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					int pointerIndex = ev.findPointerIndex(mActivePointerId);
					if (pointerIndex == INVALID_POINTER)
					{
						// no data for our primary pointer, this shouldn't happen, log it
						android.util.Log.d(TAG, "Error: No data for our primary pointer.");
						return false;
					}
					float newY = ev.getY(pointerIndex);
					float deltaY = newY - mInitialY;
					beginGestureIfNeeded(deltaY);
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				case android.view.MotionEvent.ACTION_CANCEL:
				{
					mActivePointerId = INVALID_POINTER;
					mSwipeGestureType = GESTURE_NONE;
					break;
				}
			}
			return mSwipeGestureType != GESTURE_NONE;
		}

		private void beginGestureIfNeeded(float deltaY)
		{
			if ((int)System.Math.Abs(deltaY) > mTouchSlop && mSwipeGestureType == GESTURE_NONE)
			{
				int swipeGestureType = deltaY < 0 ? GESTURE_SLIDE_UP : GESTURE_SLIDE_DOWN;
				cancelLongPress();
				requestDisallowInterceptTouchEvent(true);
				if (mAdapter == null)
				{
					return;
				}
				int adapterCount = getCount();
				int activeIndex;
				if (mStackMode == ITEMS_SLIDE_UP)
				{
					activeIndex = (swipeGestureType == GESTURE_SLIDE_DOWN) ? 0 : 1;
				}
				else
				{
					activeIndex = (swipeGestureType == GESTURE_SLIDE_DOWN) ? 1 : 0;
				}
				bool endOfStack = mLoopViews && adapterCount == 1 && ((mStackMode == ITEMS_SLIDE_UP
					 && swipeGestureType == GESTURE_SLIDE_UP) || (mStackMode == ITEMS_SLIDE_DOWN && 
					swipeGestureType == GESTURE_SLIDE_DOWN));
				bool beginningOfStack = mLoopViews && adapterCount == 1 && ((mStackMode == ITEMS_SLIDE_DOWN
					 && swipeGestureType == GESTURE_SLIDE_UP) || (mStackMode == ITEMS_SLIDE_UP && swipeGestureType
					 == GESTURE_SLIDE_DOWN));
				int stackMode;
				if (mLoopViews && !beginningOfStack && !endOfStack)
				{
					stackMode = android.widget.StackView.StackSlider.NORMAL_MODE;
				}
				else
				{
					if (mCurrentWindowStartUnbounded + activeIndex == -1 || beginningOfStack)
					{
						activeIndex++;
						stackMode = android.widget.StackView.StackSlider.BEGINNING_OF_STACK_MODE;
					}
					else
					{
						if (mCurrentWindowStartUnbounded + activeIndex == adapterCount - 1 || endOfStack)
						{
							stackMode = android.widget.StackView.StackSlider.END_OF_STACK_MODE;
						}
						else
						{
							stackMode = android.widget.StackView.StackSlider.NORMAL_MODE;
						}
					}
				}
				mTransitionIsSetup = stackMode == android.widget.StackView.StackSlider.NORMAL_MODE;
				android.view.View v = getViewAtRelativeIndex(activeIndex);
				if (v == null)
				{
					return;
				}
				setupStackSlider(v, stackMode);
				// We only register this gesture if we've made it this far without a problem
				mSwipeGestureType = swipeGestureType;
				cancelHandleClick();
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
		{
			base.onTouchEvent(ev);
			int action = ev.getAction();
			int pointerIndex = ev.findPointerIndex(mActivePointerId);
			if (pointerIndex == INVALID_POINTER)
			{
				// no data for our primary pointer, this shouldn't happen, log it
				android.util.Log.d(TAG, "Error: No data for our primary pointer.");
				return false;
			}
			float newY = ev.getY(pointerIndex);
			float newX = ev.getX(pointerIndex);
			float deltaY = newY - mInitialY;
			float deltaX = newX - mInitialX;
			if (mVelocityTracker == null)
			{
				mVelocityTracker = android.view.VelocityTracker.obtain();
			}
			mVelocityTracker.addMovement(ev);
			switch (action & android.view.MotionEvent.ACTION_MASK)
			{
				case android.view.MotionEvent.ACTION_MOVE:
				{
					beginGestureIfNeeded(deltaY);
					float rx = deltaX / (mSlideAmount * 1.0f);
					if (mSwipeGestureType == GESTURE_SLIDE_DOWN)
					{
						float r = (deltaY - mTouchSlop * 1.0f) / mSlideAmount * 1.0f;
						if (mStackMode == ITEMS_SLIDE_DOWN)
						{
							r = 1 - r;
						}
						mStackSlider.setYProgress(1 - r);
						mStackSlider.setXProgress(rx);
						return true;
					}
					else
					{
						if (mSwipeGestureType == GESTURE_SLIDE_UP)
						{
							float r = -(deltaY + mTouchSlop * 1.0f) / mSlideAmount * 1.0f;
							if (mStackMode == ITEMS_SLIDE_DOWN)
							{
								r = 1 - r;
							}
							mStackSlider.setYProgress(r);
							mStackSlider.setXProgress(rx);
							return true;
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				{
					handlePointerUp(ev);
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				{
					mActivePointerId = INVALID_POINTER;
					mSwipeGestureType = GESTURE_NONE;
					break;
				}
			}
			return true;
		}

		private void onSecondaryPointerUp(android.view.MotionEvent ev)
		{
			int activePointerIndex = ev.getActionIndex();
			int pointerId = ev.getPointerId(activePointerIndex);
			if (pointerId == mActivePointerId)
			{
				int activeViewIndex = (mSwipeGestureType == GESTURE_SLIDE_DOWN) ? 0 : 1;
				android.view.View v = getViewAtRelativeIndex(activeViewIndex);
				if (v == null)
				{
					return;
				}
				{
					// Our primary pointer has gone up -- let's see if we can find
					// another pointer on the view. If so, then we should replace
					// our primary pointer with this new pointer and adjust things
					// so that the view doesn't jump
					for (int index = 0; index < ev.getPointerCount(); index++)
					{
						if (index != activePointerIndex)
						{
							float x = ev.getX(index);
							float y = ev.getY(index);
							mTouchRect.set(v.getLeft(), v.getTop(), v.getRight(), v.getBottom());
							if (mTouchRect.contains(Sharpen.Util.Round(x), Sharpen.Util.Round(y)))
							{
								float oldX = ev.getX(activePointerIndex);
								float oldY = ev.getY(activePointerIndex);
								// adjust our frame of reference to avoid a jump
								mInitialY += (y - oldY);
								mInitialX += (x - oldX);
								mActivePointerId = ev.getPointerId(index);
								if (mVelocityTracker != null)
								{
									mVelocityTracker.clear();
								}
								// ok, we're good, we found a new pointer which is touching the active view
								return;
							}
						}
					}
				}
				// if we made it this far, it means we didn't find a satisfactory new pointer :(,
				// so end the gesture
				handlePointerUp(ev);
			}
		}

		private void handlePointerUp(android.view.MotionEvent ev)
		{
			int pointerIndex = ev.findPointerIndex(mActivePointerId);
			float newY = ev.getY(pointerIndex);
			int deltaY = (int)(newY - mInitialY);
			mLastInteractionTime = Sharpen.Util.CurrentTimeMillis;
			if (mVelocityTracker != null)
			{
				mVelocityTracker.computeCurrentVelocity(1000, mMaximumVelocity);
				mYVelocity = (int)mVelocityTracker.getYVelocity(mActivePointerId);
			}
			if (mVelocityTracker != null)
			{
				mVelocityTracker.recycle();
				mVelocityTracker = null;
			}
			if (deltaY > mSwipeThreshold && mSwipeGestureType == GESTURE_SLIDE_DOWN && mStackSlider
				.mMode == android.widget.StackView.StackSlider.NORMAL_MODE)
			{
				// We reset the gesture variable, because otherwise we will ignore showPrevious() /
				// showNext();
				mSwipeGestureType = GESTURE_NONE;
				// Swipe threshold exceeded, swipe down
				if (mStackMode == ITEMS_SLIDE_UP)
				{
					showPrevious();
				}
				else
				{
					showNext();
				}
				mHighlight.bringToFront();
			}
			else
			{
				if (deltaY < -mSwipeThreshold && mSwipeGestureType == GESTURE_SLIDE_UP && mStackSlider
					.mMode == android.widget.StackView.StackSlider.NORMAL_MODE)
				{
					// We reset the gesture variable, because otherwise we will ignore showPrevious() /
					// showNext();
					mSwipeGestureType = GESTURE_NONE;
					// Swipe threshold exceeded, swipe up
					if (mStackMode == ITEMS_SLIDE_UP)
					{
						showNext();
					}
					else
					{
						showPrevious();
					}
					mHighlight.bringToFront();
				}
				else
				{
					if (mSwipeGestureType == GESTURE_SLIDE_UP)
					{
						// Didn't swipe up far enough, snap back down
						int duration;
						float finalYProgress = (mStackMode == ITEMS_SLIDE_DOWN) ? 1 : 0;
						if (mStackMode == ITEMS_SLIDE_UP || mStackSlider.mMode != android.widget.StackView
							.StackSlider.NORMAL_MODE)
						{
							duration = Sharpen.Util.Round(mStackSlider.getDurationForNeutralPosition());
						}
						else
						{
							duration = Sharpen.Util.Round(mStackSlider.getDurationForOffscreenPosition());
						}
						android.widget.StackView.StackSlider animationSlider = new android.widget.StackView
							.StackSlider(this, mStackSlider);
						android.animation.PropertyValuesHolder snapBackY = android.animation.PropertyValuesHolder
							.ofFloat("YProgress", finalYProgress);
						android.animation.PropertyValuesHolder snapBackX = android.animation.PropertyValuesHolder
							.ofFloat("XProgress", 0.0f);
						android.animation.ObjectAnimator pa = android.animation.ObjectAnimator.ofPropertyValuesHolder
							(animationSlider, snapBackX, snapBackY);
						pa.setDuration(duration);
						pa.setInterpolator(new android.view.animation.LinearInterpolator());
						pa.start();
					}
					else
					{
						if (mSwipeGestureType == GESTURE_SLIDE_DOWN)
						{
							// Didn't swipe down far enough, snap back up
							float finalYProgress = (mStackMode == ITEMS_SLIDE_DOWN) ? 0 : 1;
							int duration;
							if (mStackMode == ITEMS_SLIDE_DOWN || mStackSlider.mMode != android.widget.StackView
								.StackSlider.NORMAL_MODE)
							{
								duration = Sharpen.Util.Round(mStackSlider.getDurationForNeutralPosition());
							}
							else
							{
								duration = Sharpen.Util.Round(mStackSlider.getDurationForOffscreenPosition());
							}
							android.widget.StackView.StackSlider animationSlider = new android.widget.StackView
								.StackSlider(this, mStackSlider);
							android.animation.PropertyValuesHolder snapBackY = android.animation.PropertyValuesHolder
								.ofFloat("YProgress", finalYProgress);
							android.animation.PropertyValuesHolder snapBackX = android.animation.PropertyValuesHolder
								.ofFloat("XProgress", 0.0f);
							android.animation.ObjectAnimator pa = android.animation.ObjectAnimator.ofPropertyValuesHolder
								(animationSlider, snapBackX, snapBackY);
							pa.setDuration(duration);
							pa.start();
						}
					}
				}
			}
			mActivePointerId = INVALID_POINTER;
			mSwipeGestureType = GESTURE_NONE;
		}

		private class StackSlider
		{
			internal android.view.View mView;

			internal float mYProgress;

			internal float mXProgress;

			internal const int NORMAL_MODE = 0;

			internal const int BEGINNING_OF_STACK_MODE = 1;

			internal const int END_OF_STACK_MODE = 2;

			internal int mMode;

			public StackSlider(StackView _enclosing)
			{
				this._enclosing = _enclosing;
				mMode = NORMAL_MODE;
			}

			public StackSlider(StackView _enclosing, android.widget.StackView.StackSlider copy
				)
			{
				this._enclosing = _enclosing;
				mMode = NORMAL_MODE;
				this.mView = copy.mView;
				this.mYProgress = copy.mYProgress;
				this.mXProgress = copy.mXProgress;
				this.mMode = copy.mMode;
			}

			internal float cubic(float r)
			{
				return (float)(System.Math.Pow(2 * r - 1, 3) + 1) / 2.0f;
			}

			internal float highlightAlphaInterpolator(float r)
			{
				float pivot = 0.4f;
				if (r < pivot)
				{
					return 0.85f * this.cubic(r / pivot);
				}
				else
				{
					return 0.85f * this.cubic(1 - (r - pivot) / (1 - pivot));
				}
			}

			internal float viewAlphaInterpolator(float r)
			{
				float pivot = 0.3f;
				if (r > pivot)
				{
					return (r - pivot) / (1 - pivot);
				}
				else
				{
					return 0;
				}
			}

			internal float rotationInterpolator(float r)
			{
				float pivot = 0.2f;
				if (r < pivot)
				{
					return 0;
				}
				else
				{
					return (r - pivot) / (1 - pivot);
				}
			}

			internal virtual void setView(android.view.View v)
			{
				this.mView = v;
			}

			public virtual void setYProgress(float r)
			{
				// enforce r between 0 and 1
				r = System.Math.Min(1.0f, r);
				r = System.Math.Max(0, r);
				this.mYProgress = r;
				if (this.mView == null)
				{
					return;
				}
				android.widget.StackView.LayoutParams viewLp = (android.widget.StackView.LayoutParams
					)this.mView.getLayoutParams();
				android.widget.StackView.LayoutParams highlightLp = (android.widget.StackView.LayoutParams
					)this._enclosing.mHighlight.getLayoutParams();
				int stackDirection = (this._enclosing.mStackMode == android.widget.StackView.ITEMS_SLIDE_UP
					) ? 1 : -1;
				// We need to prevent any clipping issues which may arise by setting a layer type.
				// This doesn't come for free however, so we only want to enable it when required.
				if (0f.CompareTo(this.mYProgress) != 0 && 1.0f.CompareTo(this.mYProgress) != 0)
				{
					if (this.mView.getLayerType() == android.view.View.LAYER_TYPE_NONE)
					{
						this.mView.setLayerType(android.view.View.LAYER_TYPE_HARDWARE, null);
					}
				}
				else
				{
					if (this.mView.getLayerType() != android.view.View.LAYER_TYPE_NONE)
					{
						this.mView.setLayerType(android.view.View.LAYER_TYPE_NONE, null);
					}
				}
				switch (this.mMode)
				{
					case NORMAL_MODE:
					{
						viewLp.setVerticalOffset(Sharpen.Util.Round(-r * stackDirection * this._enclosing
							.mSlideAmount));
						highlightLp.setVerticalOffset(Sharpen.Util.Round(-r * stackDirection * this._enclosing
							.mSlideAmount));
						this._enclosing.mHighlight.setAlpha(this.highlightAlphaInterpolator(r));
						float alpha = this.viewAlphaInterpolator(1 - r);
						// We make sure that views which can't be seen (have 0 alpha) are also invisible
						// so that they don't interfere with click events.
						if (this.mView.getAlpha() == 0 && alpha != 0 && this.mView.getVisibility() != android.view.View
							.VISIBLE)
						{
							this.mView.setVisibility(android.view.View.VISIBLE);
						}
						else
						{
							if (alpha == 0 && this.mView.getAlpha() != 0 && this.mView.getVisibility() == android.view.View
								.VISIBLE)
							{
								this.mView.setVisibility(android.view.View.INVISIBLE);
							}
						}
						this.mView.setAlpha(alpha);
						this.mView.setRotationX(stackDirection * 90.0f * this.rotationInterpolator(r));
						this._enclosing.mHighlight.setRotationX(stackDirection * 90.0f * this.rotationInterpolator
							(r));
						break;
					}

					case END_OF_STACK_MODE:
					{
						r = r * 0.2f;
						viewLp.setVerticalOffset(Sharpen.Util.Round(-stackDirection * r * this._enclosing
							.mSlideAmount));
						highlightLp.setVerticalOffset(Sharpen.Util.Round(-stackDirection * r * this._enclosing
							.mSlideAmount));
						this._enclosing.mHighlight.setAlpha(this.highlightAlphaInterpolator(r));
						break;
					}

					case BEGINNING_OF_STACK_MODE:
					{
						r = (1 - r) * 0.2f;
						viewLp.setVerticalOffset(Sharpen.Util.Round(stackDirection * r * this._enclosing.
							mSlideAmount));
						highlightLp.setVerticalOffset(Sharpen.Util.Round(stackDirection * r * this._enclosing
							.mSlideAmount));
						this._enclosing.mHighlight.setAlpha(this.highlightAlphaInterpolator(r));
						break;
					}
				}
			}

			public virtual void setXProgress(float r)
			{
				// enforce r between 0 and 1
				r = System.Math.Min(2.0f, r);
				r = System.Math.Max(-2.0f, r);
				this.mXProgress = r;
				if (this.mView == null)
				{
					return;
				}
				android.widget.StackView.LayoutParams viewLp = (android.widget.StackView.LayoutParams
					)this.mView.getLayoutParams();
				android.widget.StackView.LayoutParams highlightLp = (android.widget.StackView.LayoutParams
					)this._enclosing.mHighlight.getLayoutParams();
				r *= 0.2f;
				viewLp.setHorizontalOffset(Sharpen.Util.Round(r * this._enclosing.mSlideAmount));
				highlightLp.setHorizontalOffset(Sharpen.Util.Round(r * this._enclosing.mSlideAmount
					));
			}

			internal virtual void setMode(int mode)
			{
				this.mMode = mode;
			}

			internal virtual float getDurationForNeutralPosition()
			{
				return this.getDuration(false, 0);
			}

			internal virtual float getDurationForOffscreenPosition()
			{
				return this.getDuration(true, 0);
			}

			internal virtual float getDurationForNeutralPosition(float velocity)
			{
				return this.getDuration(false, velocity);
			}

			internal virtual float getDurationForOffscreenPosition(float velocity)
			{
				return this.getDuration(true, velocity);
			}

			internal float getDuration(bool invert, float velocity)
			{
				if (this.mView != null)
				{
					android.widget.StackView.LayoutParams viewLp = (android.widget.StackView.LayoutParams
						)this.mView.getLayoutParams();
					float d = (float)System.Math.Sqrt(System.Math.Pow(viewLp.horizontalOffset, 2) + System.Math.Pow
						(viewLp.verticalOffset, 2));
					float maxd = (float)System.Math.Sqrt(System.Math.Pow(this._enclosing.mSlideAmount
						, 2) + System.Math.Pow(0.4f * this._enclosing.mSlideAmount, 2));
					if (velocity == 0)
					{
						return (invert ? (1 - d / maxd) : d / maxd) * android.widget.StackView.DEFAULT_ANIMATION_DURATION;
					}
					else
					{
						float duration = invert ? d / System.Math.Abs(velocity) : (maxd - d) / System.Math.Abs
							(velocity);
						if (duration < android.widget.StackView.MINIMUM_ANIMATION_DURATION || duration > 
							android.widget.StackView.DEFAULT_ANIMATION_DURATION)
						{
							return this.getDuration(invert, 0);
						}
						else
						{
							return duration;
						}
					}
				}
				return 0;
			}

			// Used for animations
			public virtual float getYProgress()
			{
				return this.mYProgress;
			}

			// Used for animations
			public virtual float getXProgress()
			{
				return this.mXProgress;
			}

			private readonly StackView _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		internal override android.view.ViewGroup.LayoutParams createOrReuseLayoutParams(android.view.View
			 v)
		{
			android.view.ViewGroup.LayoutParams currentLp = v.getLayoutParams();
			if (currentLp is android.widget.StackView.LayoutParams)
			{
				android.widget.StackView.LayoutParams lp = (android.widget.StackView.LayoutParams
					)currentLp;
				lp.setHorizontalOffset(0);
				lp.setVerticalOffset(0);
				lp.width = 0;
				lp.width = 0;
				return lp;
			}
			return new android.widget.StackView.LayoutParams(this, v);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			checkForAndHandleDataChanged();
			int childCount = getChildCount();
			{
				for (int i = 0; i < childCount; i++)
				{
					android.view.View child = getChildAt(i);
					int childRight = mPaddingLeft + child.getMeasuredWidth();
					int childBottom = mPaddingTop + child.getMeasuredHeight();
					android.widget.StackView.LayoutParams lp = (android.widget.StackView.LayoutParams
						)child.getLayoutParams();
					child.layout(mPaddingLeft + lp.horizontalOffset, mPaddingTop + lp.verticalOffset, 
						childRight + lp.horizontalOffset, childBottom + lp.verticalOffset);
				}
			}
			onLayout();
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		public override void advance()
		{
			long timeSinceLastInteraction = Sharpen.Util.CurrentTimeMillis - mLastInteractionTime;
			if (mAdapter == null)
			{
				return;
			}
			int adapterCount = getCount();
			if (adapterCount == 1 && mLoopViews)
			{
				return;
			}
			if (mSwipeGestureType == GESTURE_NONE && timeSinceLastInteraction > MIN_TIME_BETWEEN_INTERACTION_AND_AUTOADVANCE)
			{
				showNext();
			}
		}

		new private void measureChildren()
		{
			int count = getChildCount();
			int measuredWidth = getMeasuredWidth();
			int measuredHeight = getMeasuredHeight();
			int childWidth = Sharpen.Util.Round(measuredWidth * (1 - PERSPECTIVE_SHIFT_FACTOR_X
				)) - mPaddingLeft - mPaddingRight;
			int childHeight = Sharpen.Util.Round(measuredHeight * (1 - PERSPECTIVE_SHIFT_FACTOR_Y
				)) - mPaddingTop - mPaddingBottom;
			int maxWidth = 0;
			int maxHeight = 0;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					child.measure(android.view.View.MeasureSpec.makeMeasureSpec(childWidth, android.view.View
						.MeasureSpec.AT_MOST), android.view.View.MeasureSpec.makeMeasureSpec(childHeight
						, android.view.View.MeasureSpec.AT_MOST));
					if (child != mHighlight && child != mClickFeedback)
					{
						int childMeasuredWidth = child.getMeasuredWidth();
						int childMeasuredHeight = child.getMeasuredHeight();
						if (childMeasuredWidth > maxWidth)
						{
							maxWidth = childMeasuredWidth;
						}
						if (childMeasuredHeight > maxHeight)
						{
							maxHeight = childMeasuredHeight;
						}
					}
				}
			}
			mNewPerspectiveShiftX = PERSPECTIVE_SHIFT_FACTOR_X * measuredWidth;
			mNewPerspectiveShiftY = PERSPECTIVE_SHIFT_FACTOR_Y * measuredHeight;
			// If we have extra space, we try and spread the items out
			if (maxWidth > 0 && count > 0 && maxWidth < childWidth)
			{
				mNewPerspectiveShiftX = measuredWidth - maxWidth;
			}
			if (maxHeight > 0 && count > 0 && maxHeight < childHeight)
			{
				mNewPerspectiveShiftY = measuredHeight - maxHeight;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int widthSpecSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int heightSpecSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
			int widthSpecMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightSpecMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			bool haveChildRefSize = (mReferenceChildWidth != -1 && mReferenceChildHeight != -
				1);
			// We need to deal with the case where our parent hasn't told us how
			// big we should be. In this case we should
			float factorY = 1 / (1 - PERSPECTIVE_SHIFT_FACTOR_Y);
			if (heightSpecMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				heightSpecSize = haveChildRefSize ? Sharpen.Util.Round(mReferenceChildHeight * (1
					 + factorY)) + mPaddingTop + mPaddingBottom : 0;
			}
			else
			{
				if (heightSpecMode == android.view.View.MeasureSpec.AT_MOST)
				{
					if (haveChildRefSize)
					{
						int height = Sharpen.Util.Round(mReferenceChildHeight * (1 + factorY)) + mPaddingTop
							 + mPaddingBottom;
						if (height <= heightSpecSize)
						{
							heightSpecSize = height;
						}
						else
						{
							heightSpecSize |= MEASURED_STATE_TOO_SMALL;
						}
					}
					else
					{
						heightSpecSize = 0;
					}
				}
			}
			float factorX = 1 / (1 - PERSPECTIVE_SHIFT_FACTOR_X);
			if (widthSpecMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				widthSpecSize = haveChildRefSize ? Sharpen.Util.Round(mReferenceChildWidth * (1 +
					 factorX)) + mPaddingLeft + mPaddingRight : 0;
			}
			else
			{
				if (heightSpecMode == android.view.View.MeasureSpec.AT_MOST)
				{
					if (haveChildRefSize)
					{
						int width = mReferenceChildWidth + mPaddingLeft + mPaddingRight;
						if (width <= widthSpecSize)
						{
							widthSpecSize = width;
						}
						else
						{
							widthSpecSize |= MEASURED_STATE_TOO_SMALL;
						}
					}
					else
					{
						widthSpecSize = 0;
					}
				}
			}
			setMeasuredDimension(widthSpecSize, heightSpecSize);
			measureChildren();
		}

		internal class LayoutParams : android.view.ViewGroup.LayoutParams
		{
			internal int horizontalOffset;

			internal int verticalOffset;

			internal android.view.View mView;

			private readonly android.graphics.Rect parentRect;

			private readonly android.graphics.Rect invalidateRect;

			private readonly android.graphics.RectF invalidateRectf;

			private readonly android.graphics.Rect globalInvalidateRect;

			internal LayoutParams(StackView _enclosing, android.view.View view) : base(0, 0)
			{
				this._enclosing = _enclosing;
				parentRect = new android.graphics.Rect();
				invalidateRect = new android.graphics.Rect();
				invalidateRectf = new android.graphics.RectF();
				globalInvalidateRect = new android.graphics.Rect();
				this.width = 0;
				this.height = 0;
				this.horizontalOffset = 0;
				this.verticalOffset = 0;
				this.mView = view;
			}

			public LayoutParams(StackView _enclosing, android.content.Context c, android.util.AttributeSet
				 attrs) : base(c, attrs)
			{
				this._enclosing = _enclosing;
				parentRect = new android.graphics.Rect();
				invalidateRect = new android.graphics.Rect();
				invalidateRectf = new android.graphics.RectF();
				globalInvalidateRect = new android.graphics.Rect();
				this.horizontalOffset = 0;
				this.verticalOffset = 0;
				this.width = 0;
				this.height = 0;
			}

			internal virtual void invalidateGlobalRegion(android.view.View v, android.graphics.Rect
				 r)
			{
				// We need to make a new rect here, so as not to modify the one passed
				this.globalInvalidateRect.set(r);
				this.globalInvalidateRect.union(0, 0, this._enclosing.getWidth(), this._enclosing
					.getHeight());
				android.view.View p = v;
				if (!(v.getParent() != null && v.getParent() is android.view.View))
				{
					return;
				}
				bool firstPass = true;
				this.parentRect.set(0, 0, 0, 0);
				while (p.getParent() != null && p.getParent() is android.view.View && !this.parentRect
					.contains(this.globalInvalidateRect))
				{
					if (!firstPass)
					{
						this.globalInvalidateRect.offset(p.getLeft() - p.getScrollX(), p.getTop() - p.getScrollY
							());
					}
					firstPass = false;
					p = (android.view.View)p.getParent();
					this.parentRect.set(p.getScrollX(), p.getScrollY(), p.getWidth() + p.getScrollX()
						, p.getHeight() + p.getScrollY());
					p.invalidate(this.globalInvalidateRect.left, this.globalInvalidateRect.top, this.
						globalInvalidateRect.right, this.globalInvalidateRect.bottom);
				}
				p.invalidate(this.globalInvalidateRect.left, this.globalInvalidateRect.top, this.
					globalInvalidateRect.right, this.globalInvalidateRect.bottom);
			}

			internal virtual android.graphics.Rect getInvalidateRect()
			{
				return this.invalidateRect;
			}

			internal virtual void resetInvalidateRect()
			{
				this.invalidateRect.set(0, 0, 0, 0);
			}

			// This is public so that ObjectAnimator can access it
			public virtual void setVerticalOffset(int newVerticalOffset)
			{
				this.setOffsets(this.horizontalOffset, newVerticalOffset);
			}

			public virtual void setHorizontalOffset(int newHorizontalOffset)
			{
				this.setOffsets(newHorizontalOffset, this.verticalOffset);
			}

			public virtual void setOffsets(int newHorizontalOffset, int newVerticalOffset)
			{
				int horizontalOffsetDelta = newHorizontalOffset - this.horizontalOffset;
				this.horizontalOffset = newHorizontalOffset;
				int verticalOffsetDelta = newVerticalOffset - this.verticalOffset;
				this.verticalOffset = newVerticalOffset;
				if (this.mView != null)
				{
					this.mView.requestLayout();
					int left = System.Math.Min(this.mView.getLeft() + horizontalOffsetDelta, this.mView
						.getLeft());
					int right = System.Math.Max(this.mView.getRight() + horizontalOffsetDelta, this.mView
						.getRight());
					int top = System.Math.Min(this.mView.getTop() + verticalOffsetDelta, this.mView.getTop
						());
					int bottom = System.Math.Max(this.mView.getBottom() + verticalOffsetDelta, this.mView
						.getBottom());
					this.invalidateRectf.set(left, top, right, bottom);
					float xoffset = -this.invalidateRectf.left;
					float yoffset = -this.invalidateRectf.top;
					this.invalidateRectf.offset(xoffset, yoffset);
					this.mView.getMatrix().mapRect(this.invalidateRectf);
					this.invalidateRectf.offset(-xoffset, -yoffset);
					this.invalidateRect.set((int)Sharpen.Util.Floor(this.invalidateRectf.left), (int)
						Sharpen.Util.Floor(this.invalidateRectf.top), (int)System.Math.Ceiling(this.invalidateRectf
						.right), (int)System.Math.Ceiling(this.invalidateRectf.bottom));
					this.invalidateGlobalRegion(this.mView, this.invalidateRect);
				}
			}

			private readonly StackView _enclosing;
		}

		private class HolographicHelper
		{
			internal readonly android.graphics.Paint mHolographicPaint = new android.graphics.Paint
				();

			internal readonly android.graphics.Paint mErasePaint = new android.graphics.Paint
				();

			internal readonly android.graphics.Paint mBlurPaint = new android.graphics.Paint(
				);

			internal const int RES_OUT = 0;

			internal const int CLICK_FEEDBACK = 1;

			internal float mDensity;

			internal android.graphics.BlurMaskFilter mSmallBlurMaskFilter;

			internal android.graphics.BlurMaskFilter mLargeBlurMaskFilter;

			internal readonly android.graphics.Canvas mCanvas = new android.graphics.Canvas();

			internal readonly android.graphics.Canvas mMaskCanvas = new android.graphics.Canvas
				();

			internal readonly int[] mTmpXY = new int[2];

			internal readonly android.graphics.Matrix mIdentityMatrix = new android.graphics.Matrix
				();

			internal HolographicHelper(android.content.Context context)
			{
				mDensity = context.getResources().getDisplayMetrics().density;
				mHolographicPaint.setFilterBitmap(true);
				mHolographicPaint.setMaskFilter(android.graphics.TableMaskFilter.CreateClipTable(
					0, 30));
				mErasePaint.setXfermode(new android.graphics.PorterDuffXfermode(android.graphics.PorterDuff.Mode
					.DST_OUT));
				mErasePaint.setFilterBitmap(true);
				mSmallBlurMaskFilter = new android.graphics.BlurMaskFilter(2 * mDensity, android.graphics.BlurMaskFilter.Blur
					.NORMAL);
				mLargeBlurMaskFilter = new android.graphics.BlurMaskFilter(4 * mDensity, android.graphics.BlurMaskFilter.Blur
					.NORMAL);
			}

			internal virtual android.graphics.Bitmap createClickOutline(android.view.View v, 
				int color)
			{
				return createOutline(v, CLICK_FEEDBACK, color);
			}

			internal virtual android.graphics.Bitmap createResOutline(android.view.View v, int
				 color)
			{
				return createOutline(v, RES_OUT, color);
			}

			internal virtual android.graphics.Bitmap createOutline(android.view.View v, int type
				, int color)
			{
				mHolographicPaint.setColor(color);
				if (type == RES_OUT)
				{
					mBlurPaint.setMaskFilter(mSmallBlurMaskFilter);
				}
				else
				{
					if (type == CLICK_FEEDBACK)
					{
						mBlurPaint.setMaskFilter(mLargeBlurMaskFilter);
					}
				}
				if (v.getMeasuredWidth() == 0 || v.getMeasuredHeight() == 0)
				{
					return null;
				}
				android.graphics.Bitmap bitmap = android.graphics.Bitmap.createBitmap(v.getMeasuredWidth
					(), v.getMeasuredHeight(), android.graphics.Bitmap.Config.ARGB_8888);
				mCanvas.setBitmap(bitmap);
				float rotationX = v.getRotationX();
				float rotation = v.getRotation();
				float translationY = v.getTranslationY();
				float translationX = v.getTranslationX();
				v.setRotationX(0);
				v.setRotation(0);
				v.setTranslationY(0);
				v.setTranslationX(0);
				v.draw(mCanvas);
				v.setRotationX(rotationX);
				v.setRotation(rotation);
				v.setTranslationY(translationY);
				v.setTranslationX(translationX);
				drawOutline(mCanvas, bitmap);
				mCanvas.setBitmap(null);
				return bitmap;
			}

			internal virtual void drawOutline(android.graphics.Canvas dest, android.graphics.Bitmap
				 src)
			{
				int[] xy = mTmpXY;
				android.graphics.Bitmap mask = src.extractAlpha(mBlurPaint, xy);
				mMaskCanvas.setBitmap(mask);
				mMaskCanvas.drawBitmap(src, -xy[0], -xy[1], mErasePaint);
				dest.drawColor(0, android.graphics.PorterDuff.Mode.CLEAR);
				dest.setMatrix(mIdentityMatrix);
				dest.drawBitmap(mask, xy[0], xy[1], mHolographicPaint);
				mMaskCanvas.setBitmap(null);
				mask.recycle();
			}
		}
	}
}
