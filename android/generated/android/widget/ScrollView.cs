using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Layout container for a view hierarchy that can be scrolled by the user,
	/// allowing it to be larger than the physical display.
	/// </summary>
	/// <remarks>
	/// Layout container for a view hierarchy that can be scrolled by the user,
	/// allowing it to be larger than the physical display.  A ScrollView
	/// is a
	/// <see cref="FrameLayout">FrameLayout</see>
	/// , meaning you should place one child in it
	/// containing the entire contents to scroll; this child may itself be a layout
	/// manager with a complex hierarchy of objects.  A child that is often used
	/// is a
	/// <see cref="LinearLayout">LinearLayout</see>
	/// in a vertical orientation, presenting a vertical
	/// array of top-level items that the user can scroll through.
	/// <p>The
	/// <see cref="TextView">TextView</see>
	/// class also
	/// takes care of its own scrolling, so does not require a ScrollView, but
	/// using the two together is possible to achieve the effect of a text view
	/// within a larger container.
	/// <p>ScrollView only supports vertical scrolling.
	/// </remarks>
	/// <attr>ref android.R.styleable#ScrollView_fillViewport</attr>
	[Sharpen.Sharpened]
	public class ScrollView : android.widget.FrameLayout
	{
		internal const int ANIMATED_SCROLL_GAP = 250;

		internal const float MAX_SCROLL_FACTOR = 0.5f;

		private long mLastScroll;

		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		private android.widget.OverScroller mScroller;

		private android.widget.EdgeEffect mEdgeGlowTop;

		private android.widget.EdgeEffect mEdgeGlowBottom;

		/// <summary>Position of the last motion event.</summary>
		/// <remarks>Position of the last motion event.</remarks>
		private float mLastMotionY;

		/// <summary>True when the layout has changed but the traversal has not come through yet.
		/// 	</summary>
		/// <remarks>
		/// True when the layout has changed but the traversal has not come through yet.
		/// Ideally the view hierarchy would keep track of this for us.
		/// </remarks>
		private bool mIsLayoutDirty = true;

		/// <summary>
		/// The child to give focus to in the event that a child has requested focus while the
		/// layout is dirty.
		/// </summary>
		/// <remarks>
		/// The child to give focus to in the event that a child has requested focus while the
		/// layout is dirty. This prevents the scroll from being wrong if the child has not been
		/// laid out before requesting focus.
		/// </remarks>
		private android.view.View mChildToScrollTo = null;

		/// <summary>True if the user is currently dragging this ScrollView around.</summary>
		/// <remarks>
		/// True if the user is currently dragging this ScrollView around. This is
		/// not the same as 'is being flinged', which can be checked by
		/// mScroller.isFinished() (flinging begins when the user lifts his finger).
		/// </remarks>
		private bool mIsBeingDragged = false;

		/// <summary>Determines speed during touch scrolling</summary>
		private android.view.VelocityTracker mVelocityTracker;

		/// <summary>
		/// When set to true, the scroll view measure its child to make it fill the currently
		/// visible area.
		/// </summary>
		/// <remarks>
		/// When set to true, the scroll view measure its child to make it fill the currently
		/// visible area.
		/// </remarks>
		private bool mFillViewport;

		/// <summary>Whether arrow scrolling is animated.</summary>
		/// <remarks>Whether arrow scrolling is animated.</remarks>
		private bool mSmoothScrollingEnabled = true;

		private int mTouchSlop;

		private int mMinimumVelocity;

		private int mMaximumVelocity;

		private int mOverscrollDistance;

		private int mOverflingDistance;

		/// <summary>ID of the active pointer.</summary>
		/// <remarks>
		/// ID of the active pointer. This is used to retain consistency during
		/// drags/flings if multiple pointers are used.
		/// </remarks>
		private int mActivePointerId = INVALID_POINTER;

		/// <summary>
		/// The StrictMode "critical time span" objects to catch animation
		/// stutters.
		/// </summary>
		/// <remarks>
		/// The StrictMode "critical time span" objects to catch animation
		/// stutters.  Non-null when a time-sensitive animation is
		/// in-flight.  Must call finish() on them when done animating.
		/// These are no-ops on user builds.
		/// </remarks>
		private android.os.StrictMode.Span mScrollStrictSpan = null;

		private android.os.StrictMode.Span mFlingStrictSpan = null;

		/// <summary>Sentinel value for no current active pointer.</summary>
		/// <remarks>
		/// Sentinel value for no current active pointer.
		/// Used by
		/// <see cref="mActivePointerId">mActivePointerId</see>
		/// .
		/// </remarks>
		internal const int INVALID_POINTER = -1;

		public ScrollView(android.content.Context context) : this(context, null)
		{
		}

		public ScrollView(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.scrollViewStyle)
		{
		}

		public ScrollView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			// aka "drag"
			initScrollView();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ScrollView, defStyle, 0);
			setFillViewport(a.getBoolean(android.@internal.R.styleable.ScrollView_fillViewport
				, false));
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool shouldDelayChildPressedState()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getTopFadingEdgeStrength()
		{
			if (getChildCount() == 0)
			{
				return 0.0f;
			}
			int length = getVerticalFadingEdgeLength();
			if (mScrollY < length)
			{
				return mScrollY / (float)length;
			}
			return 1.0f;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getBottomFadingEdgeStrength()
		{
			if (getChildCount() == 0)
			{
				return 0.0f;
			}
			int length = getVerticalFadingEdgeLength();
			int bottomEdge = getHeight() - mPaddingBottom;
			int span = getChildAt(0).getBottom() - mScrollY - bottomEdge;
			if (span < length)
			{
				return span / (float)length;
			}
			return 1.0f;
		}

		/// <returns>
		/// The maximum amount this scroll view will scroll in response to
		/// an arrow event.
		/// </returns>
		public virtual int getMaxScrollAmount()
		{
			return (int)(MAX_SCROLL_FACTOR * (mBottom - mTop));
		}

		private void initScrollView()
		{
			mScroller = new android.widget.OverScroller(getContext());
			setFocusable(true);
			setDescendantFocusability(FOCUS_AFTER_DESCENDANTS);
			setWillNotDraw(false);
			android.view.ViewConfiguration configuration = android.view.ViewConfiguration.get
				(mContext);
			mTouchSlop = configuration.getScaledTouchSlop();
			mMinimumVelocity = configuration.getScaledMinimumFlingVelocity();
			mMaximumVelocity = configuration.getScaledMaximumFlingVelocity();
			mOverscrollDistance = configuration.getScaledOverscrollDistance();
			mOverflingDistance = configuration.getScaledOverflingDistance();
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child)
		{
			if (getChildCount() > 0)
			{
				throw new System.InvalidOperationException("ScrollView can host only one direct child"
					);
			}
			base.addView(child);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index)
		{
			if (getChildCount() > 0)
			{
				throw new System.InvalidOperationException("ScrollView can host only one direct child"
					);
			}
			base.addView(child, index);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, android.view.ViewGroup.LayoutParams
			 @params)
		{
			if (getChildCount() > 0)
			{
				throw new System.InvalidOperationException("ScrollView can host only one direct child"
					);
			}
			base.addView(child, @params);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			if (getChildCount() > 0)
			{
				throw new System.InvalidOperationException("ScrollView can host only one direct child"
					);
			}
			base.addView(child, index, @params);
		}

		/// <returns>Returns true this ScrollView can be scrolled</returns>
		private bool canScroll()
		{
			android.view.View child = getChildAt(0);
			if (child != null)
			{
				int childHeight = child.getHeight();
				return getHeight() < childHeight + mPaddingTop + mPaddingBottom;
			}
			return false;
		}

		/// <summary>Indicates whether this ScrollView's content is stretched to fill the viewport.
		/// 	</summary>
		/// <remarks>Indicates whether this ScrollView's content is stretched to fill the viewport.
		/// 	</remarks>
		/// <returns>True if the content fills the viewport, false otherwise.</returns>
		/// <attr>ref android.R.styleable#ScrollView_fillViewport</attr>
		public virtual bool isFillViewport()
		{
			return mFillViewport;
		}

		/// <summary>
		/// Indicates this ScrollView whether it should stretch its content height to fill
		/// the viewport or not.
		/// </summary>
		/// <remarks>
		/// Indicates this ScrollView whether it should stretch its content height to fill
		/// the viewport or not.
		/// </remarks>
		/// <param name="fillViewport">
		/// True to stretch the content's height to the viewport's
		/// boundaries, false otherwise.
		/// </param>
		/// <attr>ref android.R.styleable#ScrollView_fillViewport</attr>
		public virtual void setFillViewport(bool fillViewport)
		{
			if (fillViewport != mFillViewport)
			{
				mFillViewport = fillViewport;
				requestLayout();
			}
		}

		/// <returns>Whether arrow scrolling will animate its transition.</returns>
		public virtual bool isSmoothScrollingEnabled()
		{
			return mSmoothScrollingEnabled;
		}

		/// <summary>Set whether arrow scrolling will animate its transition.</summary>
		/// <remarks>Set whether arrow scrolling will animate its transition.</remarks>
		/// <param name="smoothScrollingEnabled">whether arrow scrolling will animate its transition
		/// 	</param>
		public virtual void setSmoothScrollingEnabled(bool smoothScrollingEnabled)
		{
			mSmoothScrollingEnabled = smoothScrollingEnabled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			if (!mFillViewport)
			{
				return;
			}
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			if (heightMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				return;
			}
			if (getChildCount() > 0)
			{
				android.view.View child = getChildAt(0);
				int height = getMeasuredHeight();
				if (child.getMeasuredHeight() < height)
				{
					android.widget.FrameLayout.LayoutParams lp = (android.widget.FrameLayout.LayoutParams
						)child.getLayoutParams();
					int childWidthMeasureSpec = getChildMeasureSpec(widthMeasureSpec, mPaddingLeft + 
						mPaddingRight, lp.width);
					height -= mPaddingTop;
					height -= mPaddingBottom;
					int childHeightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(height
						, android.view.View.MeasureSpec.EXACTLY);
					child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			// Let the focused view and/or our descendants get the key first
			return base.dispatchKeyEvent(@event) || executeKeyEvent(@event);
		}

		/// <summary>
		/// You can call this function yourself to have the scroll view perform
		/// scrolling from a key event, just as if the event had been dispatched to
		/// it by the view hierarchy.
		/// </summary>
		/// <remarks>
		/// You can call this function yourself to have the scroll view perform
		/// scrolling from a key event, just as if the event had been dispatched to
		/// it by the view hierarchy.
		/// </remarks>
		/// <param name="event">The key event to execute.</param>
		/// <returns>Return true if the event was handled, else false.</returns>
		public virtual bool executeKeyEvent(android.view.KeyEvent @event)
		{
			mTempRect.setEmpty();
			if (!canScroll())
			{
				if (isFocused() && @event.getKeyCode() != android.view.KeyEvent.KEYCODE_BACK)
				{
					android.view.View currentFocused = findFocus();
					if (currentFocused == this)
					{
						currentFocused = null;
					}
					android.view.View nextFocused = android.view.FocusFinder.getInstance().findNextFocus
						(this, currentFocused, android.view.View.FOCUS_DOWN);
					return nextFocused != null && nextFocused != this && nextFocused.requestFocus(android.view.View
						.FOCUS_DOWN);
				}
				return false;
			}
			bool handled = false;
			if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN)
			{
				switch (@event.getKeyCode())
				{
					case android.view.KeyEvent.KEYCODE_DPAD_UP:
					{
						if (!@event.isAltPressed())
						{
							handled = arrowScroll(android.view.View.FOCUS_UP);
						}
						else
						{
							handled = fullScroll(android.view.View.FOCUS_UP);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
					{
						if (!@event.isAltPressed())
						{
							handled = arrowScroll(android.view.View.FOCUS_DOWN);
						}
						else
						{
							handled = fullScroll(android.view.View.FOCUS_DOWN);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_SPACE:
					{
						pageScroll(@event.isShiftPressed() ? android.view.View.FOCUS_UP : android.view.View
							.FOCUS_DOWN);
						break;
					}
				}
			}
			return handled;
		}

		private bool inChild(int x, int y)
		{
			if (getChildCount() > 0)
			{
				int scrollY = mScrollY;
				android.view.View child = getChildAt(0);
				return !(y < child.getTop() - scrollY || y >= child.getBottom() - scrollY || x < 
					child.getLeft() || x >= child.getRight());
			}
			return false;
		}

		private void initOrResetVelocityTracker()
		{
			if (mVelocityTracker == null)
			{
				mVelocityTracker = android.view.VelocityTracker.obtain();
			}
			else
			{
				mVelocityTracker.clear();
			}
		}

		private void initVelocityTrackerIfNotExists()
		{
			if (mVelocityTracker == null)
			{
				mVelocityTracker = android.view.VelocityTracker.obtain();
			}
		}

		private void recycleVelocityTracker()
		{
			if (mVelocityTracker != null)
			{
				mVelocityTracker.recycle();
				mVelocityTracker = null;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void requestDisallowInterceptTouchEvent(bool disallowIntercept)
		{
			if (disallowIntercept)
			{
				recycleVelocityTracker();
			}
			base.requestDisallowInterceptTouchEvent(disallowIntercept);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onInterceptTouchEvent(android.view.MotionEvent ev)
		{
			int action = ev.getAction();
			if ((action == android.view.MotionEvent.ACTION_MOVE) && (mIsBeingDragged))
			{
				return true;
			}
			switch (action & android.view.MotionEvent.ACTION_MASK)
			{
				case android.view.MotionEvent.ACTION_MOVE:
				{
					int activePointerId = mActivePointerId;
					if (activePointerId == INVALID_POINTER)
					{
						// If we don't have a valid id, the touch down wasn't on content.
						break;
					}
					int pointerIndex = ev.findPointerIndex(activePointerId);
					float y = ev.getY(pointerIndex);
					int yDiff = (int)System.Math.Abs(y - mLastMotionY);
					if (yDiff > mTouchSlop)
					{
						mIsBeingDragged = true;
						mLastMotionY = y;
						initVelocityTrackerIfNotExists();
						mVelocityTracker.addMovement(ev);
						if (mScrollStrictSpan == null)
						{
							mScrollStrictSpan = android.os.StrictMode.enterCriticalSpan("ScrollView-scroll");
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_DOWN:
				{
					float y = ev.getY();
					if (!inChild((int)ev.getX(), (int)y))
					{
						mIsBeingDragged = false;
						recycleVelocityTracker();
						break;
					}
					mLastMotionY = y;
					mActivePointerId = ev.getPointerId(0);
					initOrResetVelocityTracker();
					mVelocityTracker.addMovement(ev);
					mIsBeingDragged = !mScroller.isFinished();
					if (mIsBeingDragged && mScrollStrictSpan == null)
					{
						mScrollStrictSpan = android.os.StrictMode.enterCriticalSpan("ScrollView-scroll");
					}
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				case android.view.MotionEvent.ACTION_UP:
				{
					mIsBeingDragged = false;
					mActivePointerId = INVALID_POINTER;
					recycleVelocityTracker();
					if (mScroller.springBack(mScrollX, mScrollY, 0, 0, 0, getScrollRange()))
					{
						invalidate();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
					break;
				}
			}
			return mIsBeingDragged;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
		{
			initVelocityTrackerIfNotExists();
			mVelocityTracker.addMovement(ev);
			int action = ev.getAction();
			switch (action & android.view.MotionEvent.ACTION_MASK)
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					mIsBeingDragged = getChildCount() != 0;
					if (!mIsBeingDragged)
					{
						return false;
					}
					if (!mScroller.isFinished())
					{
						mScroller.abortAnimation();
						if (mFlingStrictSpan != null)
						{
							mFlingStrictSpan.finish();
							mFlingStrictSpan = null;
						}
					}
					// Remember where the motion event started
					mLastMotionY = ev.getY();
					mActivePointerId = ev.getPointerId(0);
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					if (mIsBeingDragged)
					{
						// Scroll to follow the motion event
						int activePointerIndex = ev.findPointerIndex(mActivePointerId);
						float y = ev.getY(activePointerIndex);
						int deltaY = (int)(mLastMotionY - y);
						mLastMotionY = y;
						int oldX = mScrollX;
						int oldY = mScrollY;
						int range = getScrollRange();
						int overscrollMode = getOverScrollMode();
						bool canOverscroll = overscrollMode == OVER_SCROLL_ALWAYS || (overscrollMode == OVER_SCROLL_IF_CONTENT_SCROLLS
							 && range > 0);
						if (overScrollBy(0, deltaY, 0, mScrollY, 0, range, 0, mOverscrollDistance, true))
						{
							// Break our velocity if we hit a scroll barrier.
							mVelocityTracker.clear();
						}
						onScrollChanged(mScrollX, mScrollY, oldX, oldY);
						if (canOverscroll)
						{
							int pulledToY = oldY + deltaY;
							if (pulledToY < 0)
							{
								mEdgeGlowTop.onPull((float)deltaY / getHeight());
								if (!mEdgeGlowBottom.isFinished())
								{
									mEdgeGlowBottom.onRelease();
								}
							}
							else
							{
								if (pulledToY > range)
								{
									mEdgeGlowBottom.onPull((float)deltaY / getHeight());
									if (!mEdgeGlowTop.isFinished())
									{
										mEdgeGlowTop.onRelease();
									}
								}
							}
							if (mEdgeGlowTop != null && (!mEdgeGlowTop.isFinished() || !mEdgeGlowBottom.isFinished
								()))
							{
								invalidate();
							}
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				{
					if (mIsBeingDragged)
					{
						android.view.VelocityTracker velocityTracker = mVelocityTracker;
						velocityTracker.computeCurrentVelocity(1000, mMaximumVelocity);
						int initialVelocity = (int)velocityTracker.getYVelocity(mActivePointerId);
						if (getChildCount() > 0)
						{
							if ((System.Math.Abs(initialVelocity) > mMinimumVelocity))
							{
								fling(-initialVelocity);
							}
							else
							{
								if (mScroller.springBack(mScrollX, mScrollY, 0, 0, 0, getScrollRange()))
								{
									invalidate();
								}
							}
						}
						mActivePointerId = INVALID_POINTER;
						endDrag();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				{
					if (mIsBeingDragged && getChildCount() > 0)
					{
						if (mScroller.springBack(mScrollX, mScrollY, 0, 0, 0, getScrollRange()))
						{
							invalidate();
						}
						mActivePointerId = INVALID_POINTER;
						endDrag();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_DOWN:
				{
					int index = ev.getActionIndex();
					float y = ev.getY(index);
					mLastMotionY = y;
					mActivePointerId = ev.getPointerId(index);
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
					mLastMotionY = ev.getY(ev.findPointerIndex(mActivePointerId));
					break;
				}
			}
			return true;
		}

		private void onSecondaryPointerUp(android.view.MotionEvent ev)
		{
			int pointerIndex = (ev.getAction() & android.view.MotionEvent.ACTION_POINTER_INDEX_MASK
				) >> android.view.MotionEvent.ACTION_POINTER_INDEX_SHIFT;
			int pointerId = ev.getPointerId(pointerIndex);
			if (pointerId == mActivePointerId)
			{
				// This was our active pointer going up. Choose a new
				// active pointer and adjust accordingly.
				// TODO: Make this decision more intelligent.
				int newPointerIndex = pointerIndex == 0 ? 1 : 0;
				mLastMotionY = ev.getY(newPointerIndex);
				mActivePointerId = ev.getPointerId(newPointerIndex);
				if (mVelocityTracker != null)
				{
					mVelocityTracker.clear();
				}
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
						if (!mIsBeingDragged)
						{
							float vscroll = @event.getAxisValue(android.view.MotionEvent.AXIS_VSCROLL);
							if (vscroll != 0)
							{
								int delta = (int)(vscroll * getVerticalScrollFactor());
								int range = getScrollRange();
								int oldScrollY = mScrollY;
								int newScrollY = oldScrollY - delta;
								if (newScrollY < 0)
								{
									newScrollY = 0;
								}
								else
								{
									if (newScrollY > range)
									{
										newScrollY = range;
									}
								}
								if (newScrollY != oldScrollY)
								{
									base.scrollTo(mScrollX, newScrollY);
									return true;
								}
							}
						}
						break;
					}
				}
			}
			return base.onGenericMotionEvent(@event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onOverScrolled(int scrollX, int scrollY, bool clampedX
			, bool clampedY)
		{
			// Treat animating scrolls differently; see #computeScroll() for why.
			if (!mScroller.isFinished())
			{
				mScrollX = scrollX;
				mScrollY = scrollY;
				invalidateParentIfNeeded();
				if (clampedY)
				{
					mScroller.springBack(mScrollX, mScrollY, 0, 0, 0, getScrollRange());
				}
			}
			else
			{
				base.scrollTo(scrollX, scrollY);
			}
			awakenScrollBars();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			base.onInitializeAccessibilityNodeInfo(info);
			info.setScrollable(getScrollRange() > 0);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onInitializeAccessibilityEvent(@event);
			bool scrollable = getScrollRange() > 0;
			@event.setScrollable(scrollable);
			@event.setScrollX(mScrollX);
			@event.setScrollY(mScrollY);
			@event.setMaxScrollX(mScrollX);
			@event.setMaxScrollY(getScrollRange());
		}

		private int getScrollRange()
		{
			int scrollRange = 0;
			if (getChildCount() > 0)
			{
				android.view.View child = getChildAt(0);
				scrollRange = System.Math.Max(0, child.getHeight() - (getHeight() - mPaddingBottom
					 - mPaddingTop));
			}
			return scrollRange;
		}

		/// <summary>
		/// <p>
		/// Finds the next focusable component that fits in this View's bounds
		/// (excluding fading edges) pretending that this View's top is located at
		/// the parameter top.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Finds the next focusable component that fits in this View's bounds
		/// (excluding fading edges) pretending that this View's top is located at
		/// the parameter top.
		/// </p>
		/// </remarks>
		/// <param name="topFocus">
		/// look for a candidate at the top of the bounds if topFocus is true,
		/// or at the bottom of the bounds if topFocus is false
		/// </param>
		/// <param name="top">
		/// the top offset of the bounds in which a focusable must be
		/// found (the fading edge is assumed to start at this position)
		/// </param>
		/// <param name="preferredFocusable">
		/// the View that has highest priority and will be
		/// returned if it is within my bounds (null is valid)
		/// </param>
		/// <returns>the next focusable component in the bounds or null if none can be found</returns>
		private android.view.View findFocusableViewInMyBounds(bool topFocus, int top, android.view.View
			 preferredFocusable)
		{
			int fadingEdgeLength = getVerticalFadingEdgeLength() / 2;
			int topWithoutFadingEdge = top + fadingEdgeLength;
			int bottomWithoutFadingEdge = top + getHeight() - fadingEdgeLength;
			if ((preferredFocusable != null) && (preferredFocusable.getTop() < bottomWithoutFadingEdge
				) && (preferredFocusable.getBottom() > topWithoutFadingEdge))
			{
				return preferredFocusable;
			}
			return findFocusableViewInBounds(topFocus, topWithoutFadingEdge, bottomWithoutFadingEdge
				);
		}

		/// <summary>
		/// <p>
		/// Finds the next focusable component that fits in the specified bounds.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Finds the next focusable component that fits in the specified bounds.
		/// </p>
		/// </remarks>
		/// <param name="topFocus">
		/// look for a candidate is the one at the top of the bounds
		/// if topFocus is true, or at the bottom of the bounds if topFocus is
		/// false
		/// </param>
		/// <param name="top">
		/// the top offset of the bounds in which a focusable must be
		/// found
		/// </param>
		/// <param name="bottom">
		/// the bottom offset of the bounds in which a focusable must
		/// be found
		/// </param>
		/// <returns>
		/// the next focusable component in the bounds or null if none can
		/// be found
		/// </returns>
		private android.view.View findFocusableViewInBounds(bool topFocus, int top, int bottom
			)
		{
			java.util.List<android.view.View> focusables = getFocusables(android.view.View.FOCUS_FORWARD
				);
			android.view.View focusCandidate = null;
			bool foundFullyContainedFocusable = false;
			int count = focusables.size();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View view = focusables.get(i);
					int viewTop = view.getTop();
					int viewBottom = view.getBottom();
					if (top < viewBottom && viewTop < bottom)
					{
						bool viewIsFullyContained = (top < viewTop) && (viewBottom < bottom);
						if (focusCandidate == null)
						{
							focusCandidate = view;
							foundFullyContainedFocusable = viewIsFullyContained;
						}
						else
						{
							bool viewIsCloserToBoundary = (topFocus && viewTop < focusCandidate.getTop()) || 
								(!topFocus && viewBottom > focusCandidate.getBottom());
							if (foundFullyContainedFocusable)
							{
								if (viewIsFullyContained && viewIsCloserToBoundary)
								{
									focusCandidate = view;
								}
							}
							else
							{
								if (viewIsFullyContained)
								{
									focusCandidate = view;
									foundFullyContainedFocusable = true;
								}
								else
								{
									if (viewIsCloserToBoundary)
									{
										focusCandidate = view;
									}
								}
							}
						}
					}
				}
			}
			return focusCandidate;
		}

		/// <summary><p>Handles scrolling in response to a "page up/down" shortcut press.</summary>
		/// <remarks>
		/// <p>Handles scrolling in response to a "page up/down" shortcut press. This
		/// method will scroll the view by one page up or down and give the focus
		/// to the topmost/bottommost component in the new visible area. If no
		/// component is a good candidate for focus, this scrollview reclaims the
		/// focus.</p>
		/// </remarks>
		/// <param name="direction">
		/// the scroll direction:
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// to go one page up or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// to go one page down
		/// </param>
		/// <returns>true if the key event is consumed by this method, false otherwise</returns>
		public virtual bool pageScroll(int direction)
		{
			bool down = direction == android.view.View.FOCUS_DOWN;
			int height = getHeight();
			if (down)
			{
				mTempRect.top = getScrollY() + height;
				int count = getChildCount();
				if (count > 0)
				{
					android.view.View view = getChildAt(count - 1);
					if (mTempRect.top + height > view.getBottom())
					{
						mTempRect.top = view.getBottom() - height;
					}
				}
			}
			else
			{
				mTempRect.top = getScrollY() - height;
				if (mTempRect.top < 0)
				{
					mTempRect.top = 0;
				}
			}
			mTempRect.bottom = mTempRect.top + height;
			return scrollAndFocus(direction, mTempRect.top, mTempRect.bottom);
		}

		/// <summary><p>Handles scrolling in response to a "home/end" shortcut press.</summary>
		/// <remarks>
		/// <p>Handles scrolling in response to a "home/end" shortcut press. This
		/// method will scroll the view to the top or bottom and give the focus
		/// to the topmost/bottommost component in the new visible area. If no
		/// component is a good candidate for focus, this scrollview reclaims the
		/// focus.</p>
		/// </remarks>
		/// <param name="direction">
		/// the scroll direction:
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// to go the top of the view or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// to go the bottom
		/// </param>
		/// <returns>true if the key event is consumed by this method, false otherwise</returns>
		public virtual bool fullScroll(int direction)
		{
			bool down = direction == android.view.View.FOCUS_DOWN;
			int height = getHeight();
			mTempRect.top = 0;
			mTempRect.bottom = height;
			if (down)
			{
				int count = getChildCount();
				if (count > 0)
				{
					android.view.View view = getChildAt(count - 1);
					mTempRect.bottom = view.getBottom() + mPaddingBottom;
					mTempRect.top = mTempRect.bottom - height;
				}
			}
			return scrollAndFocus(direction, mTempRect.top, mTempRect.bottom);
		}

		/// <summary>
		/// <p>Scrolls the view to make the area defined by <code>top</code> and
		/// <code>bottom</code> visible.
		/// </summary>
		/// <remarks>
		/// <p>Scrolls the view to make the area defined by <code>top</code> and
		/// <code>bottom</code> visible. This method attempts to give the focus
		/// to a component visible in this area. If no component can be focused in
		/// the new visible area, the focus is reclaimed by this ScrollView.</p>
		/// </remarks>
		/// <param name="direction">
		/// the scroll direction:
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// to go upward,
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// to downward
		/// </param>
		/// <param name="top">the top offset of the new area to be made visible</param>
		/// <param name="bottom">the bottom offset of the new area to be made visible</param>
		/// <returns>true if the key event is consumed by this method, false otherwise</returns>
		private bool scrollAndFocus(int direction, int top, int bottom)
		{
			bool handled = true;
			int height = getHeight();
			int containerTop = getScrollY();
			int containerBottom = containerTop + height;
			bool up = direction == android.view.View.FOCUS_UP;
			android.view.View newFocused = findFocusableViewInBounds(up, top, bottom);
			if (newFocused == null)
			{
				newFocused = this;
			}
			if (top >= containerTop && bottom <= containerBottom)
			{
				handled = false;
			}
			else
			{
				int delta = up ? (top - containerTop) : (bottom - containerBottom);
				doScrollY(delta);
			}
			if (newFocused != findFocus())
			{
				newFocused.requestFocus(direction);
			}
			return handled;
		}

		/// <summary>Handle scrolling in response to an up or down arrow click.</summary>
		/// <remarks>Handle scrolling in response to an up or down arrow click.</remarks>
		/// <param name="direction">
		/// The direction corresponding to the arrow key that was
		/// pressed
		/// </param>
		/// <returns>True if we consumed the event, false otherwise</returns>
		public virtual bool arrowScroll(int direction)
		{
			android.view.View currentFocused = findFocus();
			if (currentFocused == this)
			{
				currentFocused = null;
			}
			android.view.View nextFocused = android.view.FocusFinder.getInstance().findNextFocus
				(this, currentFocused, direction);
			int maxJump = getMaxScrollAmount();
			if (nextFocused != null && isWithinDeltaOfScreen(nextFocused, maxJump, getHeight(
				)))
			{
				nextFocused.getDrawingRect(mTempRect);
				offsetDescendantRectToMyCoords(nextFocused, mTempRect);
				int scrollDelta = computeScrollDeltaToGetChildRectOnScreen(mTempRect);
				doScrollY(scrollDelta);
				nextFocused.requestFocus(direction);
			}
			else
			{
				// no new focus
				int scrollDelta = maxJump;
				if (direction == android.view.View.FOCUS_UP && getScrollY() < scrollDelta)
				{
					scrollDelta = getScrollY();
				}
				else
				{
					if (direction == android.view.View.FOCUS_DOWN)
					{
						if (getChildCount() > 0)
						{
							int daBottom = getChildAt(0).getBottom();
							int screenBottom = getScrollY() + getHeight() - mPaddingBottom;
							if (daBottom - screenBottom < maxJump)
							{
								scrollDelta = daBottom - screenBottom;
							}
						}
					}
				}
				if (scrollDelta == 0)
				{
					return false;
				}
				doScrollY(direction == android.view.View.FOCUS_DOWN ? scrollDelta : -scrollDelta);
			}
			if (currentFocused != null && currentFocused.isFocused() && isOffScreen(currentFocused
				))
			{
				// previously focused item still has focus and is off screen, give
				// it up (take it back to ourselves)
				// (also, need to temporarily force FOCUS_BEFORE_DESCENDANTS so we are
				// sure to
				// get it)
				int descendantFocusability = getDescendantFocusability();
				// save
				setDescendantFocusability(android.view.ViewGroup.FOCUS_BEFORE_DESCENDANTS);
				requestFocus();
				setDescendantFocusability(descendantFocusability);
			}
			// restore
			return true;
		}

		/// <returns>
		/// whether the descendant of this scroll view is scrolled off
		/// screen.
		/// </returns>
		private bool isOffScreen(android.view.View descendant)
		{
			return !isWithinDeltaOfScreen(descendant, 0, getHeight());
		}

		/// <returns>
		/// whether the descendant of this scroll view is within delta
		/// pixels of being on the screen.
		/// </returns>
		private bool isWithinDeltaOfScreen(android.view.View descendant, int delta, int height
			)
		{
			descendant.getDrawingRect(mTempRect);
			offsetDescendantRectToMyCoords(descendant, mTempRect);
			return (mTempRect.bottom + delta) >= getScrollY() && (mTempRect.top - delta) <= (
				getScrollY() + height);
		}

		/// <summary>Smooth scroll by a Y delta</summary>
		/// <param name="delta">the number of pixels to scroll by on the Y axis</param>
		private void doScrollY(int delta)
		{
			if (delta != 0)
			{
				if (mSmoothScrollingEnabled)
				{
					smoothScrollBy(0, delta);
				}
				else
				{
					scrollBy(0, delta);
				}
			}
		}

		/// <summary>
		/// Like
		/// <see cref="android.view.View.scrollBy(int, int)">android.view.View.scrollBy(int, int)
		/// 	</see>
		/// , but scroll smoothly instead of immediately.
		/// </summary>
		/// <param name="dx">the number of pixels to scroll by on the X axis</param>
		/// <param name="dy">the number of pixels to scroll by on the Y axis</param>
		public void smoothScrollBy(int dx, int dy)
		{
			if (getChildCount() == 0)
			{
				// Nothing to do.
				return;
			}
			long duration = android.view.animation.AnimationUtils.currentAnimationTimeMillis(
				) - mLastScroll;
			if (duration > ANIMATED_SCROLL_GAP)
			{
				int height = getHeight() - mPaddingBottom - mPaddingTop;
				int bottom = getChildAt(0).getHeight();
				int maxY = System.Math.Max(0, bottom - height);
				int scrollY = mScrollY;
				dy = System.Math.Max(0, System.Math.Min(scrollY + dy, maxY)) - scrollY;
				mScroller.startScroll(mScrollX, scrollY, 0, dy);
				invalidate();
			}
			else
			{
				if (!mScroller.isFinished())
				{
					mScroller.abortAnimation();
					if (mFlingStrictSpan != null)
					{
						mFlingStrictSpan.finish();
						mFlingStrictSpan = null;
					}
				}
				scrollBy(dx, dy);
			}
			mLastScroll = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
		}

		/// <summary>
		/// Like
		/// <see cref="scrollTo(int, int)">scrollTo(int, int)</see>
		/// , but scroll smoothly instead of immediately.
		/// </summary>
		/// <param name="x">the position where to scroll on the X axis</param>
		/// <param name="y">the position where to scroll on the Y axis</param>
		public void smoothScrollTo(int x, int y)
		{
			smoothScrollBy(x - mScrollX, y - mScrollY);
		}

		/// <summary>
		/// <p>The scroll range of a scroll view is the overall height of all of its
		/// children.</p>
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollRange()
		{
			int count = getChildCount();
			int contentHeight = getHeight() - mPaddingBottom - mPaddingTop;
			if (count == 0)
			{
				return contentHeight;
			}
			int scrollRange = getChildAt(0).getBottom();
			int scrollY = mScrollY;
			int overscrollBottom = System.Math.Max(0, scrollRange - contentHeight);
			if (scrollY < 0)
			{
				scrollRange -= scrollY;
			}
			else
			{
				if (scrollY > overscrollBottom)
				{
					scrollRange += scrollY - overscrollBottom;
				}
			}
			return scrollRange;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollOffset()
		{
			return System.Math.Max(0, base.computeVerticalScrollOffset());
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override void measureChild(android.view.View child, int parentWidthMeasureSpec
			, int parentHeightMeasureSpec)
		{
			android.view.ViewGroup.LayoutParams lp = child.getLayoutParams();
			int childWidthMeasureSpec;
			int childHeightMeasureSpec;
			childWidthMeasureSpec = getChildMeasureSpec(parentWidthMeasureSpec, mPaddingLeft 
				+ mPaddingRight, lp.width);
			childHeightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
				.MeasureSpec.UNSPECIFIED);
			child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override void measureChildWithMargins(android.view.View child, 
			int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed
			)
		{
			android.view.ViewGroup.MarginLayoutParams lp = (android.view.ViewGroup.MarginLayoutParams
				)child.getLayoutParams();
			int childWidthMeasureSpec = getChildMeasureSpec(parentWidthMeasureSpec, mPaddingLeft
				 + mPaddingRight + lp.leftMargin + lp.rightMargin + widthUsed, lp.width);
			int childHeightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(lp.topMargin
				 + lp.bottomMargin, android.view.View.MeasureSpec.UNSPECIFIED);
			child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void computeScroll()
		{
			if (mScroller.computeScrollOffset())
			{
				// This is called at drawing time by ViewGroup.  We don't want to
				// re-show the scrollbars at this point, which scrollTo will do,
				// so we replicate most of scrollTo here.
				//
				//         It's a little odd to call onScrollChanged from inside the drawing.
				//
				//         It is, except when you remember that computeScroll() is used to
				//         animate scrolling. So unless we want to defer the onScrollChanged()
				//         until the end of the animated scrolling, we don't really have a
				//         choice here.
				//
				//         I agree.  The alternative, which I think would be worse, is to post
				//         something and tell the subclasses later.  This is bad because there
				//         will be a window where mScrollX/Y is different from what the app
				//         thinks it is.
				//
				int oldX = mScrollX;
				int oldY = mScrollY;
				int x = mScroller.getCurrX();
				int y = mScroller.getCurrY();
				if (oldX != x || oldY != y)
				{
					int range = getScrollRange();
					int overscrollMode = getOverScrollMode();
					bool canOverscroll = overscrollMode == OVER_SCROLL_ALWAYS || (overscrollMode == OVER_SCROLL_IF_CONTENT_SCROLLS
						 && range > 0);
					overScrollBy(x - oldX, y - oldY, oldX, oldY, 0, range, 0, mOverflingDistance, false
						);
					onScrollChanged(mScrollX, mScrollY, oldX, oldY);
					if (canOverscroll)
					{
						if (y < 0 && oldY >= 0)
						{
							mEdgeGlowTop.onAbsorb((int)mScroller.getCurrVelocity());
						}
						else
						{
							if (y > range && oldY <= range)
							{
								mEdgeGlowBottom.onAbsorb((int)mScroller.getCurrVelocity());
							}
						}
					}
				}
				awakenScrollBars();
				// Keep on drawing until the animation has finished.
				postInvalidate();
			}
			else
			{
				if (mFlingStrictSpan != null)
				{
					mFlingStrictSpan.finish();
					mFlingStrictSpan = null;
				}
			}
		}

		/// <summary>Scrolls the view to the given child.</summary>
		/// <remarks>Scrolls the view to the given child.</remarks>
		/// <param name="child">the View to scroll to</param>
		private void scrollToChild(android.view.View child)
		{
			child.getDrawingRect(mTempRect);
			offsetDescendantRectToMyCoords(child, mTempRect);
			int scrollDelta = computeScrollDeltaToGetChildRectOnScreen(mTempRect);
			if (scrollDelta != 0)
			{
				scrollBy(0, scrollDelta);
			}
		}

		/// <summary>
		/// If rect is off screen, scroll just enough to get it (or at least the
		/// first screen size chunk of it) on screen.
		/// </summary>
		/// <remarks>
		/// If rect is off screen, scroll just enough to get it (or at least the
		/// first screen size chunk of it) on screen.
		/// </remarks>
		/// <param name="rect">The rectangle.</param>
		/// <param name="immediate">True to scroll immediately without animation</param>
		/// <returns>true if scrolling was performed</returns>
		private bool scrollToChildRect(android.graphics.Rect rect, bool immediate)
		{
			int delta = computeScrollDeltaToGetChildRectOnScreen(rect);
			bool scroll = delta != 0;
			if (scroll)
			{
				if (immediate)
				{
					scrollBy(0, delta);
				}
				else
				{
					smoothScrollBy(0, delta);
				}
			}
			return scroll;
		}

		/// <summary>
		/// Compute the amount to scroll in the Y direction in order to get
		/// a rectangle completely on the screen (or, if taller than the screen,
		/// at least the first screen size chunk of it).
		/// </summary>
		/// <remarks>
		/// Compute the amount to scroll in the Y direction in order to get
		/// a rectangle completely on the screen (or, if taller than the screen,
		/// at least the first screen size chunk of it).
		/// </remarks>
		/// <param name="rect">The rect.</param>
		/// <returns>The scroll delta.</returns>
		protected internal virtual int computeScrollDeltaToGetChildRectOnScreen(android.graphics.Rect
			 rect)
		{
			if (getChildCount() == 0)
			{
				return 0;
			}
			int height = getHeight();
			int screenTop = getScrollY();
			int screenBottom = screenTop + height;
			int fadingEdge = getVerticalFadingEdgeLength();
			// leave room for top fading edge as long as rect isn't at very top
			if (rect.top > 0)
			{
				screenTop += fadingEdge;
			}
			// leave room for bottom fading edge as long as rect isn't at very bottom
			if (rect.bottom < getChildAt(0).getHeight())
			{
				screenBottom -= fadingEdge;
			}
			int scrollYDelta = 0;
			if (rect.bottom > screenBottom && rect.top > screenTop)
			{
				// need to move down to get it in view: move down just enough so
				// that the entire rectangle is in view (or at least the first
				// screen size chunk).
				if (rect.height() > height)
				{
					// just enough to get screen size chunk on
					scrollYDelta += (rect.top - screenTop);
				}
				else
				{
					// get entire rect at bottom of screen
					scrollYDelta += (rect.bottom - screenBottom);
				}
				// make sure we aren't scrolling beyond the end of our content
				int bottom = getChildAt(0).getBottom();
				int distanceToBottom = bottom - screenBottom;
				scrollYDelta = System.Math.Min(scrollYDelta, distanceToBottom);
			}
			else
			{
				if (rect.top < screenTop && rect.bottom < screenBottom)
				{
					// need to move up to get it in view: move up just enough so that
					// entire rectangle is in view (or at least the first screen
					// size chunk of it).
					if (rect.height() > height)
					{
						// screen size chunk
						scrollYDelta -= (screenBottom - rect.bottom);
					}
					else
					{
						// entire rect at top
						scrollYDelta -= (screenTop - rect.top);
					}
					// make sure we aren't scrolling any further than the top our content
					scrollYDelta = System.Math.Max(scrollYDelta, -getScrollY());
				}
			}
			return scrollYDelta;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void requestChildFocus(android.view.View child, android.view.View
			 focused)
		{
			if (!mIsLayoutDirty)
			{
				scrollToChild(focused);
			}
			else
			{
				// The child may not be laid out yet, we can't compute the scroll yet
				mChildToScrollTo = focused;
			}
			base.requestChildFocus(child, focused);
		}

		/// <summary>
		/// When looking for focus in children of a scroll view, need to be a little
		/// more careful not to give focus to something that is scrolled off screen.
		/// </summary>
		/// <remarks>
		/// When looking for focus in children of a scroll view, need to be a little
		/// more careful not to give focus to something that is scrolled off screen.
		/// This is more expensive than the default
		/// <see cref="android.view.ViewGroup">android.view.ViewGroup</see>
		/// implementation, otherwise this behavior might have been made the default.
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool onRequestFocusInDescendants(int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			// convert from forward / backward notation to up / down / left / right
			// (ugh).
			if (direction == android.view.View.FOCUS_FORWARD)
			{
				direction = android.view.View.FOCUS_DOWN;
			}
			else
			{
				if (direction == android.view.View.FOCUS_BACKWARD)
				{
					direction = android.view.View.FOCUS_UP;
				}
			}
			android.view.View nextFocus = previouslyFocusedRect == null ? android.view.FocusFinder
				.getInstance().findNextFocus(this, null, direction) : android.view.FocusFinder.getInstance
				().findNextFocusFromRect(this, previouslyFocusedRect, direction);
			if (nextFocus == null)
			{
				return false;
			}
			if (isOffScreen(nextFocus))
			{
				return false;
			}
			return nextFocus.requestFocus(direction, previouslyFocusedRect);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool requestChildRectangleOnScreen(android.view.View child, android.graphics.Rect
			 rectangle, bool immediate)
		{
			// offset into coordinate space of this scroll view
			rectangle.offset(child.getLeft() - child.getScrollX(), child.getTop() - child.getScrollY
				());
			return scrollToChildRect(rectangle, immediate);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void requestLayout()
		{
			mIsLayoutDirty = true;
			base.requestLayout();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			if (mScrollStrictSpan != null)
			{
				mScrollStrictSpan.finish();
				mScrollStrictSpan = null;
			}
			if (mFlingStrictSpan != null)
			{
				mFlingStrictSpan.finish();
				mFlingStrictSpan = null;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			base.onLayout(changed, l, t, r, b);
			mIsLayoutDirty = false;
			// Give a child focus if it needs it
			if (mChildToScrollTo != null && isViewDescendantOf(mChildToScrollTo, this))
			{
				scrollToChild(mChildToScrollTo);
			}
			mChildToScrollTo = null;
			// Calling this with the present values causes it to re-clam them
			scrollTo(mScrollX, mScrollY);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.onSizeChanged(w, h, oldw, oldh);
			android.view.View currentFocused = findFocus();
			if (null == currentFocused || this == currentFocused)
			{
				return;
			}
			// If the currently-focused view was visible on the screen when the
			// screen was at the old height, then scroll the screen to make that
			// view visible with the new screen height.
			if (isWithinDeltaOfScreen(currentFocused, 0, oldh))
			{
				currentFocused.getDrawingRect(mTempRect);
				offsetDescendantRectToMyCoords(currentFocused, mTempRect);
				int scrollDelta = computeScrollDeltaToGetChildRectOnScreen(mTempRect);
				doScrollY(scrollDelta);
			}
		}

		/// <summary>Return true if child is an descendant of parent, (or equal to the parent).
		/// 	</summary>
		/// <remarks>Return true if child is an descendant of parent, (or equal to the parent).
		/// 	</remarks>
		private bool isViewDescendantOf(android.view.View child, android.view.View parent
			)
		{
			if (child == parent)
			{
				return true;
			}
			android.view.ViewParent theParent = child.getParent();
			return (theParent is android.view.ViewGroup) && isViewDescendantOf((android.view.View
				)theParent, parent);
		}

		/// <summary>Fling the scroll view</summary>
		/// <param name="velocityY">
		/// The initial velocity in the Y direction. Positive
		/// numbers mean that the finger/cursor is moving down the screen,
		/// which means we want to scroll towards the top.
		/// </param>
		public virtual void fling(int velocityY)
		{
			if (getChildCount() > 0)
			{
				int height = getHeight() - mPaddingBottom - mPaddingTop;
				int bottom = getChildAt(0).getHeight();
				mScroller.fling(mScrollX, mScrollY, 0, velocityY, 0, 0, 0, System.Math.Max(0, bottom
					 - height), 0, height / 2);
				bool movingDown = velocityY > 0;
				if (mFlingStrictSpan == null)
				{
					mFlingStrictSpan = android.os.StrictMode.enterCriticalSpan("ScrollView-fling");
				}
				invalidate();
			}
		}

		private void endDrag()
		{
			mIsBeingDragged = false;
			recycleVelocityTracker();
			if (mEdgeGlowTop != null)
			{
				mEdgeGlowTop.onRelease();
				mEdgeGlowBottom.onRelease();
			}
			if (mScrollStrictSpan != null)
			{
				mScrollStrictSpan.finish();
				mScrollStrictSpan = null;
			}
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>This version also clamps the scrolling to the bounds of our child.
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void scrollTo(int x, int y)
		{
			// we rely on the fact the View.scrollBy calls scrollTo.
			if (getChildCount() > 0)
			{
				android.view.View child = getChildAt(0);
				x = clamp(x, getWidth() - mPaddingRight - mPaddingLeft, child.getWidth());
				y = clamp(y, getHeight() - mPaddingBottom - mPaddingTop, child.getHeight());
				if (x != mScrollX || y != mScrollY)
				{
					base.scrollTo(x, y);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setOverScrollMode(int mode)
		{
			if (mode != OVER_SCROLL_NEVER)
			{
				if (mEdgeGlowTop == null)
				{
					android.content.Context context = getContext();
					mEdgeGlowTop = new android.widget.EdgeEffect(context);
					mEdgeGlowBottom = new android.widget.EdgeEffect(context);
				}
			}
			else
			{
				mEdgeGlowTop = null;
				mEdgeGlowBottom = null;
			}
			base.setOverScrollMode(mode);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
			base.draw(canvas);
			if (mEdgeGlowTop != null)
			{
				int scrollY = mScrollY;
				if (!mEdgeGlowTop.isFinished())
				{
					int restoreCount = canvas.save();
					int width = getWidth() - mPaddingLeft - mPaddingRight;
					canvas.translate(mPaddingLeft, System.Math.Min(0, scrollY));
					mEdgeGlowTop.setSize(width, getHeight());
					if (mEdgeGlowTop.draw(canvas))
					{
						invalidate();
					}
					canvas.restoreToCount(restoreCount);
				}
				if (!mEdgeGlowBottom.isFinished())
				{
					int restoreCount = canvas.save();
					int width = getWidth() - mPaddingLeft - mPaddingRight;
					int height = getHeight();
					canvas.translate(-width + mPaddingLeft, System.Math.Max(getScrollRange(), scrollY
						) + height);
					canvas.rotate(180, width, 0);
					mEdgeGlowBottom.setSize(width, height);
					if (mEdgeGlowBottom.draw(canvas))
					{
						invalidate();
					}
					canvas.restoreToCount(restoreCount);
				}
			}
		}

		private int clamp(int n, int my, int child)
		{
			if (my >= child || n < 0)
			{
				return 0;
			}
			if ((my + n) > child)
			{
				return child - my;
			}
			return n;
		}
	}
}
