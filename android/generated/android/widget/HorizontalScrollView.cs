using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Layout container for a view hierarchy that can be scrolled by the user,
	/// allowing it to be larger than the physical display.
	/// </summary>
	/// <remarks>
	/// Layout container for a view hierarchy that can be scrolled by the user,
	/// allowing it to be larger than the physical display.  A HorizontalScrollView
	/// is a
	/// <see cref="FrameLayout">FrameLayout</see>
	/// , meaning you should place one child in it
	/// containing the entire contents to scroll; this child may itself be a layout
	/// manager with a complex hierarchy of objects.  A child that is often used
	/// is a
	/// <see cref="LinearLayout">LinearLayout</see>
	/// in a horizontal orientation, presenting a horizontal
	/// array of top-level items that the user can scroll through.
	/// <p>You should never use a HorizontalScrollView with a
	/// <see cref="ListView">ListView</see>
	/// , since
	/// ListView takes care of its own scrolling.  Most importantly, doing this
	/// defeats all of the important optimizations in ListView for dealing with
	/// large lists, since it effectively forces the ListView to display its entire
	/// list of items to fill up the infinite container supplied by HorizontalScrollView.
	/// <p>The
	/// <see cref="TextView">TextView</see>
	/// class also
	/// takes care of its own scrolling, so does not require a ScrollView, but
	/// using the two together is possible to achieve the effect of a text view
	/// within a larger container.
	/// <p>HorizontalScrollView only supports horizontal scrolling.
	/// </remarks>
	/// <attr>ref android.R.styleable#HorizontalScrollView_fillViewport</attr>
	[Sharpen.Sharpened]
	public class HorizontalScrollView : android.widget.FrameLayout
	{
		internal const int ANIMATED_SCROLL_GAP = android.widget.ScrollView.ANIMATED_SCROLL_GAP;

		internal const float MAX_SCROLL_FACTOR = android.widget.ScrollView.MAX_SCROLL_FACTOR;

		private long mLastScroll;

		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		private android.widget.OverScroller mScroller;

		private android.widget.EdgeEffect mEdgeGlowLeft;

		private android.widget.EdgeEffect mEdgeGlowRight;

		/// <summary>Position of the last motion event.</summary>
		/// <remarks>Position of the last motion event.</remarks>
		private float mLastMotionX;

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

		/// <summary>Sentinel value for no current active pointer.</summary>
		/// <remarks>
		/// Sentinel value for no current active pointer.
		/// Used by
		/// <see cref="mActivePointerId">mActivePointerId</see>
		/// .
		/// </remarks>
		internal const int INVALID_POINTER = -1;

		public HorizontalScrollView(android.content.Context context) : this(context, null
			)
		{
		}

		public HorizontalScrollView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, android.@internal.R.attr.horizontalScrollViewStyle
			)
		{
		}

		public HorizontalScrollView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			initScrollView();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.R
				.styleable.HorizontalScrollView, defStyle, 0);
			setFillViewport(a.getBoolean(android.R.styleable.HorizontalScrollView_fillViewport
				, false));
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getLeftFadingEdgeStrength()
		{
			if (getChildCount() == 0)
			{
				return 0.0f;
			}
			int length = getHorizontalFadingEdgeLength();
			if (mScrollX < length)
			{
				return mScrollX / (float)length;
			}
			return 1.0f;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getRightFadingEdgeStrength()
		{
			if (getChildCount() == 0)
			{
				return 0.0f;
			}
			int length = getHorizontalFadingEdgeLength();
			int rightEdge = getWidth() - mPaddingRight;
			int span = getChildAt(0).getRight() - mScrollX - rightEdge;
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
			return (int)(MAX_SCROLL_FACTOR * (mRight - mLeft));
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
				throw new System.InvalidOperationException("HorizontalScrollView can host only one direct child"
					);
			}
			base.addView(child);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index)
		{
			if (getChildCount() > 0)
			{
				throw new System.InvalidOperationException("HorizontalScrollView can host only one direct child"
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
				throw new System.InvalidOperationException("HorizontalScrollView can host only one direct child"
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
				throw new System.InvalidOperationException("HorizontalScrollView can host only one direct child"
					);
			}
			base.addView(child, index, @params);
		}

		/// <returns>Returns true this HorizontalScrollView can be scrolled</returns>
		private bool canScroll()
		{
			android.view.View child = getChildAt(0);
			if (child != null)
			{
				int childWidth = child.getWidth();
				return getWidth() < childWidth + mPaddingLeft + mPaddingRight;
			}
			return false;
		}

		/// <summary>
		/// Indicates whether this HorizontalScrollView's content is stretched to
		/// fill the viewport.
		/// </summary>
		/// <remarks>
		/// Indicates whether this HorizontalScrollView's content is stretched to
		/// fill the viewport.
		/// </remarks>
		/// <returns>True if the content fills the viewport, false otherwise.</returns>
		/// <attr>ref android.R.styleable#HorizontalScrollView_fillViewport</attr>
		public virtual bool isFillViewport()
		{
			return mFillViewport;
		}

		/// <summary>
		/// Indicates this HorizontalScrollView whether it should stretch its content width
		/// to fill the viewport or not.
		/// </summary>
		/// <remarks>
		/// Indicates this HorizontalScrollView whether it should stretch its content width
		/// to fill the viewport or not.
		/// </remarks>
		/// <param name="fillViewport">
		/// True to stretch the content's width to the viewport's
		/// boundaries, false otherwise.
		/// </param>
		/// <attr>ref android.R.styleable#HorizontalScrollView_fillViewport</attr>
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
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			if (widthMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				return;
			}
			if (getChildCount() > 0)
			{
				android.view.View child = getChildAt(0);
				int width = getMeasuredWidth();
				if (child.getMeasuredWidth() < width)
				{
					android.widget.FrameLayout.LayoutParams lp = (android.widget.FrameLayout.LayoutParams
						)child.getLayoutParams();
					int childHeightMeasureSpec = getChildMeasureSpec(heightMeasureSpec, mPaddingTop +
						 mPaddingBottom, lp.height);
					width -= mPaddingLeft;
					width -= mPaddingRight;
					int childWidthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(width, 
						android.view.View.MeasureSpec.EXACTLY);
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
				if (isFocused())
				{
					android.view.View currentFocused = findFocus();
					if (currentFocused == this)
					{
						currentFocused = null;
					}
					android.view.View nextFocused = android.view.FocusFinder.getInstance().findNextFocus
						(this, currentFocused, android.view.View.FOCUS_RIGHT);
					return nextFocused != null && nextFocused != this && nextFocused.requestFocus(android.view.View
						.FOCUS_RIGHT);
				}
				return false;
			}
			bool handled = false;
			if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN)
			{
				switch (@event.getKeyCode())
				{
					case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
					{
						if (!@event.isAltPressed())
						{
							handled = arrowScroll(android.view.View.FOCUS_LEFT);
						}
						else
						{
							handled = fullScroll(android.view.View.FOCUS_LEFT);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
					{
						if (!@event.isAltPressed())
						{
							handled = arrowScroll(android.view.View.FOCUS_RIGHT);
						}
						else
						{
							handled = fullScroll(android.view.View.FOCUS_RIGHT);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_SPACE:
					{
						pageScroll(@event.isShiftPressed() ? android.view.View.FOCUS_LEFT : android.view.View
							.FOCUS_RIGHT);
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
				int scrollX = mScrollX;
				android.view.View child = getChildAt(0);
				return !(y < child.getTop() || y >= child.getBottom() || x < child.getLeft() - scrollX
					 || x >= child.getRight() - scrollX);
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
					float x = ev.getX(pointerIndex);
					int xDiff = (int)System.Math.Abs(x - mLastMotionX);
					if (xDiff > mTouchSlop)
					{
						mIsBeingDragged = true;
						mLastMotionX = x;
						initVelocityTrackerIfNotExists();
						mVelocityTracker.addMovement(ev);
						if (mParent != null)
						{
							mParent.requestDisallowInterceptTouchEvent(true);
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_DOWN:
				{
					float x = ev.getX();
					if (!inChild((int)x, (int)ev.getY()))
					{
						mIsBeingDragged = false;
						recycleVelocityTracker();
						break;
					}
					mLastMotionX = x;
					mActivePointerId = ev.getPointerId(0);
					initOrResetVelocityTracker();
					mVelocityTracker.addMovement(ev);
					mIsBeingDragged = !mScroller.isFinished();
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				case android.view.MotionEvent.ACTION_UP:
				{
					mIsBeingDragged = false;
					mActivePointerId = INVALID_POINTER;
					if (mScroller.springBack(mScrollX, mScrollY, 0, getScrollRange(), 0, 0))
					{
						invalidate();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_DOWN:
				{
					int index = ev.getActionIndex();
					mLastMotionX = ev.getX(index);
					mActivePointerId = ev.getPointerId(index);
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
					mLastMotionX = ev.getX(ev.findPointerIndex(mActivePointerId));
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
					}
					// Remember where the motion event started
					mLastMotionX = ev.getX();
					mActivePointerId = ev.getPointerId(0);
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					if (mIsBeingDragged)
					{
						// Scroll to follow the motion event
						int activePointerIndex = ev.findPointerIndex(mActivePointerId);
						float x = ev.getX(activePointerIndex);
						int deltaX = (int)(mLastMotionX - x);
						mLastMotionX = x;
						int oldX = mScrollX;
						int oldY = mScrollY;
						int range = getScrollRange();
						int overscrollMode = getOverScrollMode();
						bool canOverscroll = overscrollMode == OVER_SCROLL_ALWAYS || (overscrollMode == OVER_SCROLL_IF_CONTENT_SCROLLS
							 && range > 0);
						if (overScrollBy(deltaX, 0, mScrollX, 0, range, 0, mOverscrollDistance, 0, true))
						{
							// Break our velocity if we hit a scroll barrier.
							mVelocityTracker.clear();
						}
						onScrollChanged(mScrollX, mScrollY, oldX, oldY);
						if (canOverscroll)
						{
							int pulledToX = oldX + deltaX;
							if (pulledToX < 0)
							{
								mEdgeGlowLeft.onPull((float)deltaX / getWidth());
								if (!mEdgeGlowRight.isFinished())
								{
									mEdgeGlowRight.onRelease();
								}
							}
							else
							{
								if (pulledToX > range)
								{
									mEdgeGlowRight.onPull((float)deltaX / getWidth());
									if (!mEdgeGlowLeft.isFinished())
									{
										mEdgeGlowLeft.onRelease();
									}
								}
							}
							if (mEdgeGlowLeft != null && (!mEdgeGlowLeft.isFinished() || !mEdgeGlowRight.isFinished
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
						int initialVelocity = (int)velocityTracker.getXVelocity(mActivePointerId);
						if (getChildCount() > 0)
						{
							if ((System.Math.Abs(initialVelocity) > mMinimumVelocity))
							{
								fling(-initialVelocity);
							}
							else
							{
								if (mScroller.springBack(mScrollX, mScrollY, 0, getScrollRange(), 0, 0))
								{
									invalidate();
								}
							}
						}
						mActivePointerId = INVALID_POINTER;
						mIsBeingDragged = false;
						recycleVelocityTracker();
						if (mEdgeGlowLeft != null)
						{
							mEdgeGlowLeft.onRelease();
							mEdgeGlowRight.onRelease();
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				{
					if (mIsBeingDragged && getChildCount() > 0)
					{
						if (mScroller.springBack(mScrollX, mScrollY, 0, getScrollRange(), 0, 0))
						{
							invalidate();
						}
						mActivePointerId = INVALID_POINTER;
						mIsBeingDragged = false;
						recycleVelocityTracker();
						if (mEdgeGlowLeft != null)
						{
							mEdgeGlowLeft.onRelease();
							mEdgeGlowRight.onRelease();
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
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
				mLastMotionX = ev.getX(newPointerIndex);
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
							float hscroll;
							if ((@event.getMetaState() & android.view.KeyEvent.META_SHIFT_ON) != 0)
							{
								hscroll = -@event.getAxisValue(android.view.MotionEvent.AXIS_VSCROLL);
							}
							else
							{
								hscroll = @event.getAxisValue(android.view.MotionEvent.AXIS_HSCROLL);
							}
							if (hscroll != 0)
							{
								int delta = (int)(hscroll * getHorizontalScrollFactor());
								int range = getScrollRange();
								int oldScrollX = mScrollX;
								int newScrollX = oldScrollX + delta;
								if (newScrollX < 0)
								{
									newScrollX = 0;
								}
								else
								{
									if (newScrollX > range)
									{
										newScrollX = range;
									}
								}
								if (newScrollX != oldScrollX)
								{
									base.scrollTo(newScrollX, mScrollY);
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
				if (clampedX)
				{
					mScroller.springBack(mScrollX, mScrollY, 0, getScrollRange(), 0, 0);
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
			@event.setScrollable(getScrollRange() > 0);
			@event.setScrollX(mScrollX);
			@event.setScrollY(mScrollY);
			@event.setMaxScrollX(getScrollRange());
			@event.setMaxScrollY(mScrollY);
		}

		private int getScrollRange()
		{
			int scrollRange = 0;
			if (getChildCount() > 0)
			{
				android.view.View child = getChildAt(0);
				scrollRange = System.Math.Max(0, child.getWidth() - (getWidth() - mPaddingLeft - 
					mPaddingRight));
			}
			return scrollRange;
		}

		/// <summary>
		/// <p>
		/// Finds the next focusable component that fits in this View's bounds
		/// (excluding fading edges) pretending that this View's left is located at
		/// the parameter left.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Finds the next focusable component that fits in this View's bounds
		/// (excluding fading edges) pretending that this View's left is located at
		/// the parameter left.
		/// </p>
		/// </remarks>
		/// <param name="leftFocus">
		/// look for a candidate is the one at the left of the bounds
		/// if leftFocus is true, or at the right of the bounds if leftFocus
		/// is false
		/// </param>
		/// <param name="left">
		/// the left offset of the bounds in which a focusable must be
		/// found (the fading edge is assumed to start at this position)
		/// </param>
		/// <param name="preferredFocusable">
		/// the View that has highest priority and will be
		/// returned if it is within my bounds (null is valid)
		/// </param>
		/// <returns>the next focusable component in the bounds or null if none can be found</returns>
		private android.view.View findFocusableViewInMyBounds(bool leftFocus, int left, android.view.View
			 preferredFocusable)
		{
			int fadingEdgeLength = getHorizontalFadingEdgeLength() / 2;
			int leftWithoutFadingEdge = left + fadingEdgeLength;
			int rightWithoutFadingEdge = left + getWidth() - fadingEdgeLength;
			if ((preferredFocusable != null) && (preferredFocusable.getLeft() < rightWithoutFadingEdge
				) && (preferredFocusable.getRight() > leftWithoutFadingEdge))
			{
				return preferredFocusable;
			}
			return findFocusableViewInBounds(leftFocus, leftWithoutFadingEdge, rightWithoutFadingEdge
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
		/// <param name="leftFocus">
		/// look for a candidate is the one at the left of the bounds
		/// if leftFocus is true, or at the right of the bounds if
		/// leftFocus is false
		/// </param>
		/// <param name="left">
		/// the left offset of the bounds in which a focusable must be
		/// found
		/// </param>
		/// <param name="right">
		/// the right offset of the bounds in which a focusable must
		/// be found
		/// </param>
		/// <returns>
		/// the next focusable component in the bounds or null if none can
		/// be found
		/// </returns>
		private android.view.View findFocusableViewInBounds(bool leftFocus, int left, int
			 right)
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
					int viewLeft = view.getLeft();
					int viewRight = view.getRight();
					if (left < viewRight && viewLeft < right)
					{
						bool viewIsFullyContained = (left < viewLeft) && (viewRight < right);
						if (focusCandidate == null)
						{
							focusCandidate = view;
							foundFullyContainedFocusable = viewIsFullyContained;
						}
						else
						{
							bool viewIsCloserToBoundary = (leftFocus && viewLeft < focusCandidate.getLeft()) 
								|| (!leftFocus && viewRight > focusCandidate.getRight());
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
		/// method will scroll the view by one page left or right and give the focus
		/// to the leftmost/rightmost component in the new visible area. If no
		/// component is a good candidate for focus, this scrollview reclaims the
		/// focus.</p>
		/// </remarks>
		/// <param name="direction">
		/// the scroll direction:
		/// <see cref="android.view.View.FOCUS_LEFT">android.view.View.FOCUS_LEFT</see>
		/// to go one page left or
		/// <see cref="android.view.View.FOCUS_RIGHT">android.view.View.FOCUS_RIGHT</see>
		/// to go one page right
		/// </param>
		/// <returns>true if the key event is consumed by this method, false otherwise</returns>
		public virtual bool pageScroll(int direction)
		{
			bool right = direction == android.view.View.FOCUS_RIGHT;
			int width = getWidth();
			if (right)
			{
				mTempRect.left = getScrollX() + width;
				int count = getChildCount();
				if (count > 0)
				{
					android.view.View view = getChildAt(0);
					if (mTempRect.left + width > view.getRight())
					{
						mTempRect.left = view.getRight() - width;
					}
				}
			}
			else
			{
				mTempRect.left = getScrollX() - width;
				if (mTempRect.left < 0)
				{
					mTempRect.left = 0;
				}
			}
			mTempRect.right = mTempRect.left + width;
			return scrollAndFocus(direction, mTempRect.left, mTempRect.right);
		}

		/// <summary><p>Handles scrolling in response to a "home/end" shortcut press.</summary>
		/// <remarks>
		/// <p>Handles scrolling in response to a "home/end" shortcut press. This
		/// method will scroll the view to the left or right and give the focus
		/// to the leftmost/rightmost component in the new visible area. If no
		/// component is a good candidate for focus, this scrollview reclaims the
		/// focus.</p>
		/// </remarks>
		/// <param name="direction">
		/// the scroll direction:
		/// <see cref="android.view.View.FOCUS_LEFT">android.view.View.FOCUS_LEFT</see>
		/// to go the left of the view or
		/// <see cref="android.view.View.FOCUS_RIGHT">android.view.View.FOCUS_RIGHT</see>
		/// to go the right
		/// </param>
		/// <returns>true if the key event is consumed by this method, false otherwise</returns>
		public virtual bool fullScroll(int direction)
		{
			bool right = direction == android.view.View.FOCUS_RIGHT;
			int width = getWidth();
			mTempRect.left = 0;
			mTempRect.right = width;
			if (right)
			{
				int count = getChildCount();
				if (count > 0)
				{
					android.view.View view = getChildAt(0);
					mTempRect.right = view.getRight();
					mTempRect.left = mTempRect.right - width;
				}
			}
			return scrollAndFocus(direction, mTempRect.left, mTempRect.right);
		}

		/// <summary>
		/// <p>Scrolls the view to make the area defined by <code>left</code> and
		/// <code>right</code> visible.
		/// </summary>
		/// <remarks>
		/// <p>Scrolls the view to make the area defined by <code>left</code> and
		/// <code>right</code> visible. This method attempts to give the focus
		/// to a component visible in this area. If no component can be focused in
		/// the new visible area, the focus is reclaimed by this scrollview.</p>
		/// </remarks>
		/// <param name="direction">
		/// the scroll direction:
		/// <see cref="android.view.View.FOCUS_LEFT">android.view.View.FOCUS_LEFT</see>
		/// to go left
		/// <see cref="android.view.View.FOCUS_RIGHT">android.view.View.FOCUS_RIGHT</see>
		/// to right
		/// </param>
		/// <param name="left">the left offset of the new area to be made visible</param>
		/// <param name="right">the right offset of the new area to be made visible</param>
		/// <returns>true if the key event is consumed by this method, false otherwise</returns>
		private bool scrollAndFocus(int direction, int left, int right)
		{
			bool handled = true;
			int width = getWidth();
			int containerLeft = getScrollX();
			int containerRight = containerLeft + width;
			bool goLeft = direction == android.view.View.FOCUS_LEFT;
			android.view.View newFocused = findFocusableViewInBounds(goLeft, left, right);
			if (newFocused == null)
			{
				newFocused = this;
			}
			if (left >= containerLeft && right <= containerRight)
			{
				handled = false;
			}
			else
			{
				int delta = goLeft ? (left - containerLeft) : (right - containerRight);
				doScrollX(delta);
			}
			if (newFocused != findFocus())
			{
				newFocused.requestFocus(direction);
			}
			return handled;
		}

		/// <summary>Handle scrolling in response to a left or right arrow click.</summary>
		/// <remarks>Handle scrolling in response to a left or right arrow click.</remarks>
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
			if (nextFocused != null && isWithinDeltaOfScreen(nextFocused, maxJump))
			{
				nextFocused.getDrawingRect(mTempRect);
				offsetDescendantRectToMyCoords(nextFocused, mTempRect);
				int scrollDelta = computeScrollDeltaToGetChildRectOnScreen(mTempRect);
				doScrollX(scrollDelta);
				nextFocused.requestFocus(direction);
			}
			else
			{
				// no new focus
				int scrollDelta = maxJump;
				if (direction == android.view.View.FOCUS_LEFT && getScrollX() < scrollDelta)
				{
					scrollDelta = getScrollX();
				}
				else
				{
					if (direction == android.view.View.FOCUS_RIGHT && getChildCount() > 0)
					{
						int daRight = getChildAt(0).getRight();
						int screenRight = getScrollX() + getWidth();
						if (daRight - screenRight < maxJump)
						{
							scrollDelta = daRight - screenRight;
						}
					}
				}
				if (scrollDelta == 0)
				{
					return false;
				}
				doScrollX(direction == android.view.View.FOCUS_RIGHT ? scrollDelta : -scrollDelta
					);
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
			return !isWithinDeltaOfScreen(descendant, 0);
		}

		/// <returns>
		/// whether the descendant of this scroll view is within delta
		/// pixels of being on the screen.
		/// </returns>
		private bool isWithinDeltaOfScreen(android.view.View descendant, int delta)
		{
			descendant.getDrawingRect(mTempRect);
			offsetDescendantRectToMyCoords(descendant, mTempRect);
			return (mTempRect.right + delta) >= getScrollX() && (mTempRect.left - delta) <= (
				getScrollX() + getWidth());
		}

		/// <summary>Smooth scroll by a X delta</summary>
		/// <param name="delta">the number of pixels to scroll by on the X axis</param>
		private void doScrollX(int delta)
		{
			if (delta != 0)
			{
				if (mSmoothScrollingEnabled)
				{
					smoothScrollBy(delta, 0);
				}
				else
				{
					scrollBy(delta, 0);
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
				int width = getWidth() - mPaddingRight - mPaddingLeft;
				int right = getChildAt(0).getWidth();
				int maxX = System.Math.Max(0, right - width);
				int scrollX = mScrollX;
				dx = System.Math.Max(0, System.Math.Min(scrollX + dx, maxX)) - scrollX;
				mScroller.startScroll(scrollX, mScrollY, dx, 0);
				invalidate();
			}
			else
			{
				if (!mScroller.isFinished())
				{
					mScroller.abortAnimation();
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
		/// <p>The scroll range of a scroll view is the overall width of all of its
		/// children.</p>
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeHorizontalScrollRange()
		{
			int count = getChildCount();
			int contentWidth = getWidth() - mPaddingLeft - mPaddingRight;
			if (count == 0)
			{
				return contentWidth;
			}
			int scrollRange = getChildAt(0).getRight();
			int scrollX = mScrollX;
			int overscrollRight = System.Math.Max(0, scrollRange - contentWidth);
			if (scrollX < 0)
			{
				scrollRange -= scrollX;
			}
			else
			{
				if (scrollX > overscrollRight)
				{
					scrollRange += scrollX - overscrollRight;
				}
			}
			return scrollRange;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeHorizontalScrollOffset()
		{
			return System.Math.Max(0, base.computeHorizontalScrollOffset());
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override void measureChild(android.view.View child, int parentWidthMeasureSpec
			, int parentHeightMeasureSpec)
		{
			android.view.ViewGroup.LayoutParams lp = child.getLayoutParams();
			int childWidthMeasureSpec;
			int childHeightMeasureSpec;
			childHeightMeasureSpec = getChildMeasureSpec(parentHeightMeasureSpec, mPaddingTop
				 + mPaddingBottom, lp.height);
			childWidthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
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
			int childHeightMeasureSpec = getChildMeasureSpec(parentHeightMeasureSpec, mPaddingTop
				 + mPaddingBottom + lp.topMargin + lp.bottomMargin + heightUsed, lp.height);
			int childWidthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(lp.leftMargin
				 + lp.rightMargin, android.view.View.MeasureSpec.UNSPECIFIED);
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
					overScrollBy(x - oldX, y - oldY, oldX, oldY, range, 0, mOverflingDistance, 0, false
						);
					onScrollChanged(mScrollX, mScrollY, oldX, oldY);
					if (canOverscroll)
					{
						if (x < 0 && oldX >= 0)
						{
							mEdgeGlowLeft.onAbsorb((int)mScroller.getCurrVelocity());
						}
						else
						{
							if (x > range && oldX <= range)
							{
								mEdgeGlowRight.onAbsorb((int)mScroller.getCurrVelocity());
							}
						}
					}
				}
				awakenScrollBars();
				// Keep on drawing until the animation has finished.
				postInvalidate();
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
				scrollBy(scrollDelta, 0);
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
					scrollBy(delta, 0);
				}
				else
				{
					smoothScrollBy(delta, 0);
				}
			}
			return scroll;
		}

		/// <summary>
		/// Compute the amount to scroll in the X direction in order to get
		/// a rectangle completely on the screen (or, if taller than the screen,
		/// at least the first screen size chunk of it).
		/// </summary>
		/// <remarks>
		/// Compute the amount to scroll in the X direction in order to get
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
			int width = getWidth();
			int screenLeft = getScrollX();
			int screenRight = screenLeft + width;
			int fadingEdge = getHorizontalFadingEdgeLength();
			// leave room for left fading edge as long as rect isn't at very left
			if (rect.left > 0)
			{
				screenLeft += fadingEdge;
			}
			// leave room for right fading edge as long as rect isn't at very right
			if (rect.right < getChildAt(0).getWidth())
			{
				screenRight -= fadingEdge;
			}
			int scrollXDelta = 0;
			if (rect.right > screenRight && rect.left > screenLeft)
			{
				// need to move right to get it in view: move right just enough so
				// that the entire rectangle is in view (or at least the first
				// screen size chunk).
				if (rect.width() > width)
				{
					// just enough to get screen size chunk on
					scrollXDelta += (rect.left - screenLeft);
				}
				else
				{
					// get entire rect at right of screen
					scrollXDelta += (rect.right - screenRight);
				}
				// make sure we aren't scrolling beyond the end of our content
				int right = getChildAt(0).getRight();
				int distanceToRight = right - screenRight;
				scrollXDelta = System.Math.Min(scrollXDelta, distanceToRight);
			}
			else
			{
				if (rect.left < screenLeft && rect.right < screenRight)
				{
					// need to move right to get it in view: move right just enough so that
					// entire rectangle is in view (or at least the first screen
					// size chunk of it).
					if (rect.width() > width)
					{
						// screen size chunk
						scrollXDelta -= (screenRight - rect.right);
					}
					else
					{
						// entire rect at left
						scrollXDelta -= (screenLeft - rect.left);
					}
					// make sure we aren't scrolling any further than the left our content
					scrollXDelta = System.Math.Max(scrollXDelta, -getScrollX());
				}
			}
			return scrollXDelta;
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
				direction = android.view.View.FOCUS_RIGHT;
			}
			else
			{
				if (direction == android.view.View.FOCUS_BACKWARD)
				{
					direction = android.view.View.FOCUS_LEFT;
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
			int maxJump = mRight - mLeft;
			if (isWithinDeltaOfScreen(currentFocused, maxJump))
			{
				currentFocused.getDrawingRect(mTempRect);
				offsetDescendantRectToMyCoords(currentFocused, mTempRect);
				int scrollDelta = computeScrollDeltaToGetChildRectOnScreen(mTempRect);
				doScrollX(scrollDelta);
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
		/// <param name="velocityX">
		/// The initial velocity in the X direction. Positive
		/// numbers mean that the finger/curor is moving down the screen,
		/// which means we want to scroll towards the left.
		/// </param>
		public virtual void fling(int velocityX)
		{
			if (getChildCount() > 0)
			{
				int width = getWidth() - mPaddingRight - mPaddingLeft;
				int right = getChildAt(0).getWidth();
				mScroller.fling(mScrollX, mScrollY, velocityX, 0, 0, System.Math.Max(0, right - width
					), 0, 0, width / 2, 0);
				bool movingRight = velocityX > 0;
				android.view.View currentFocused = findFocus();
				android.view.View newFocused = findFocusableViewInMyBounds(movingRight, mScroller
					.getFinalX(), currentFocused);
				if (newFocused == null)
				{
					newFocused = this;
				}
				if (newFocused != currentFocused)
				{
					newFocused.requestFocus(movingRight ? android.view.View.FOCUS_RIGHT : android.view.View
						.FOCUS_LEFT);
				}
				invalidate();
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
				if (mEdgeGlowLeft == null)
				{
					android.content.Context context = getContext();
					mEdgeGlowLeft = new android.widget.EdgeEffect(context);
					mEdgeGlowRight = new android.widget.EdgeEffect(context);
				}
			}
			else
			{
				mEdgeGlowLeft = null;
				mEdgeGlowRight = null;
			}
			base.setOverScrollMode(mode);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
			base.draw(canvas);
			if (mEdgeGlowLeft != null)
			{
				int scrollX = mScrollX;
				if (!mEdgeGlowLeft.isFinished())
				{
					int restoreCount = canvas.save();
					int height = getHeight() - mPaddingTop - mPaddingBottom;
					canvas.rotate(270);
					canvas.translate(-height + mPaddingTop, System.Math.Min(0, scrollX));
					mEdgeGlowLeft.setSize(height, getWidth());
					if (mEdgeGlowLeft.draw(canvas))
					{
						invalidate();
					}
					canvas.restoreToCount(restoreCount);
				}
				if (!mEdgeGlowRight.isFinished())
				{
					int restoreCount = canvas.save();
					int width = getWidth();
					int height = getHeight() - mPaddingTop - mPaddingBottom;
					canvas.rotate(90);
					canvas.translate(-mPaddingTop, -(System.Math.Max(getScrollRange(), scrollX) + width
						));
					mEdgeGlowRight.setSize(height, width);
					if (mEdgeGlowRight.draw(canvas))
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
