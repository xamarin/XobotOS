using Sharpen;

namespace android.widget
{
	/// <summary>A view that shows items in a center-locked, horizontally scrolling list.
	/// 	</summary>
	/// <remarks>
	/// A view that shows items in a center-locked, horizontally scrolling list.
	/// <p>
	/// The default values for the Gallery assume you will be using
	/// <see cref="android.R.styleable.Theme_galleryItemBackground">android.R.styleable.Theme_galleryItemBackground
	/// 	</see>
	/// as the background for
	/// each View given to the Gallery from the Adapter. If you are not doing this,
	/// you may need to adjust some Gallery properties, such as the spacing.
	/// <p>
	/// Views given to the Gallery should use
	/// <see cref="LayoutParams">LayoutParams</see>
	/// as their
	/// layout parameters type.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-gallery.html"&gt;Gallery
	/// tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#Gallery_animationDuration</attr>
	/// <attr>ref android.R.styleable#Gallery_spacing</attr>
	/// <attr>ref android.R.styleable#Gallery_gravity</attr>
	[Sharpen.Sharpened]
	public class Gallery : android.widget.AbsSpinner, android.view.GestureDetector.OnGestureListener
	{
		internal const string TAG = "Gallery";

		internal const bool localLOGV = false;

		/// <summary>
		/// Duration in milliseconds from the start of a scroll during which we're
		/// unsure whether the user is scrolling or flinging.
		/// </summary>
		/// <remarks>
		/// Duration in milliseconds from the start of a scroll during which we're
		/// unsure whether the user is scrolling or flinging.
		/// </remarks>
		internal const int SCROLL_TO_FLING_UNCERTAINTY_TIMEOUT = 250;

		/// <summary>Horizontal spacing between items.</summary>
		/// <remarks>Horizontal spacing between items.</remarks>
		private int mSpacing = 0;

		/// <summary>
		/// How long the transition animation should run when a child view changes
		/// position, measured in milliseconds.
		/// </summary>
		/// <remarks>
		/// How long the transition animation should run when a child view changes
		/// position, measured in milliseconds.
		/// </remarks>
		private int mAnimationDuration = 400;

		/// <summary>The alpha of items that are not selected.</summary>
		/// <remarks>The alpha of items that are not selected.</remarks>
		private float mUnselectedAlpha;

		/// <summary>Left most edge of a child seen so far during layout.</summary>
		/// <remarks>Left most edge of a child seen so far during layout.</remarks>
		private int mLeftMost;

		/// <summary>Right most edge of a child seen so far during layout.</summary>
		/// <remarks>Right most edge of a child seen so far during layout.</remarks>
		private int mRightMost;

		private int mGravity;

		/// <summary>Helper for detecting touch gestures.</summary>
		/// <remarks>Helper for detecting touch gestures.</remarks>
		private android.view.GestureDetector mGestureDetector;

		/// <summary>The position of the item that received the user's down touch.</summary>
		/// <remarks>The position of the item that received the user's down touch.</remarks>
		private int mDownTouchPosition;

		/// <summary>The view of the item that received the user's down touch.</summary>
		/// <remarks>The view of the item that received the user's down touch.</remarks>
		private android.view.View mDownTouchView;

		/// <summary>Executes the delta scrolls from a fling or scroll movement.</summary>
		/// <remarks>Executes the delta scrolls from a fling or scroll movement.</remarks>
		private android.widget.Gallery.FlingRunnable mFlingRunnable;

		private sealed class _Runnable_122 : java.lang.Runnable
		{
			public _Runnable_122(Gallery _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.mSuppressSelectionChanged = false;
				this._enclosing.selectionChanged();
			}

			private readonly Gallery _enclosing;
		}

		/// <summary>Sets mSuppressSelectionChanged = false.</summary>
		/// <remarks>
		/// Sets mSuppressSelectionChanged = false. This is used to set it to false
		/// in the future. It will also trigger a selection changed.
		/// </remarks>
		private java.lang.Runnable mDisableSuppressSelectionChangedRunnable;

		/// <summary>When fling runnable runs, it resets this to false.</summary>
		/// <remarks>
		/// When fling runnable runs, it resets this to false. Any method along the
		/// path until the end of its run() can set this to true to abort any
		/// remaining fling. For example, if we've reached either the leftmost or
		/// rightmost item, we will set this to true.
		/// </remarks>
		private bool mShouldStopFling;

		/// <summary>The currently selected item's child.</summary>
		/// <remarks>The currently selected item's child.</remarks>
		private android.view.View mSelectedChild;

		/// <summary>
		/// Whether to continuously callback on the item selected listener during a
		/// fling.
		/// </summary>
		/// <remarks>
		/// Whether to continuously callback on the item selected listener during a
		/// fling.
		/// </remarks>
		private bool mShouldCallbackDuringFling = true;

		/// <summary>Whether to callback when an item that is not selected is clicked.</summary>
		/// <remarks>Whether to callback when an item that is not selected is clicked.</remarks>
		private bool mShouldCallbackOnUnselectedItemClick = true;

		/// <summary>If true, do not callback to item selected listener.</summary>
		/// <remarks>If true, do not callback to item selected listener.</remarks>
		private bool mSuppressSelectionChanged;

		/// <summary>
		/// If true, we have received the "invoke" (center or enter buttons) key
		/// down.
		/// </summary>
		/// <remarks>
		/// If true, we have received the "invoke" (center or enter buttons) key
		/// down. This is checked before we action on the "invoke" key up, and is
		/// subsequently cleared.
		/// </remarks>
		private bool mReceivedInvokeKeyDown;

		private android.widget.AdapterView.AdapterContextMenuInfo mContextMenuInfo;

		/// <summary>
		/// If true, this onScroll is the first for this user's drag (remember, a
		/// drag sends many onScrolls).
		/// </summary>
		/// <remarks>
		/// If true, this onScroll is the first for this user's drag (remember, a
		/// drag sends many onScrolls).
		/// </remarks>
		private bool mIsFirstScroll;

		/// <summary>
		/// If true, mFirstPosition is the position of the rightmost child, and
		/// the children are ordered right to left.
		/// </summary>
		/// <remarks>
		/// If true, mFirstPosition is the position of the rightmost child, and
		/// the children are ordered right to left.
		/// </remarks>
		private bool mIsRtl = true;

		public Gallery(android.content.Context context) : this(context, null)
		{
			mFlingRunnable = new android.widget.Gallery.FlingRunnable(this);
			mDisableSuppressSelectionChangedRunnable = new _Runnable_122(this);
		}

		public Gallery(android.content.Context context, android.util.AttributeSet attrs) : 
			this(context, attrs, android.@internal.R.attr.galleryStyle)
		{
			mFlingRunnable = new android.widget.Gallery.FlingRunnable(this);
			mDisableSuppressSelectionChangedRunnable = new _Runnable_122(this);
		}

		public Gallery(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : base(context, attrs, defStyle)
		{
			mFlingRunnable = new android.widget.Gallery.FlingRunnable(this);
			mDisableSuppressSelectionChangedRunnable = new _Runnable_122(this);
			mGestureDetector = new android.view.GestureDetector(context, this);
			mGestureDetector.setIsLongpressEnabled(true);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.Gallery, defStyle, 0);
			int index = a.getInt(android.@internal.R.styleable.Gallery_gravity, -1);
			if (index >= 0)
			{
				setGravity(index);
			}
			int animationDuration = a.getInt(android.@internal.R.styleable.Gallery_animationDuration
				, -1);
			if (animationDuration > 0)
			{
				setAnimationDuration(animationDuration);
			}
			int spacing = a.getDimensionPixelOffset(android.@internal.R.styleable.Gallery_spacing
				, 0);
			setSpacing(spacing);
			float unselectedAlpha = a.getFloat(android.@internal.R.styleable.Gallery_unselectedAlpha
				, 0.5f);
			setUnselectedAlpha(unselectedAlpha);
			a.recycle();
			// We draw the selected item last (because otherwise the item to the
			// right overlaps it)
			mGroupFlags |= FLAG_USE_CHILD_DRAWING_ORDER;
			mGroupFlags |= FLAG_SUPPORT_STATIC_TRANSFORMATIONS;
		}

		/// <summary>
		/// Whether or not to callback on any
		/// <see cref="AdapterView{T}.getOnItemSelectedListener()">AdapterView&lt;T&gt;.getOnItemSelectedListener()
		/// 	</see>
		/// while the items are being flinged. If false, only the final selected item
		/// will cause the callback. If true, all items between the first and the
		/// final will cause callbacks.
		/// </summary>
		/// <param name="shouldCallback">
		/// Whether or not to callback on the listener while
		/// the items are being flinged.
		/// </param>
		public virtual void setCallbackDuringFling(bool shouldCallback)
		{
			mShouldCallbackDuringFling = shouldCallback;
		}

		/// <summary>Whether or not to callback when an item that is not selected is clicked.
		/// 	</summary>
		/// <remarks>
		/// Whether or not to callback when an item that is not selected is clicked.
		/// If false, the item will become selected (and re-centered). If true, the
		/// <see cref="AdapterView{T}.getOnItemClickListener()">AdapterView&lt;T&gt;.getOnItemClickListener()
		/// 	</see>
		/// will get the callback.
		/// </remarks>
		/// <param name="shouldCallback">
		/// Whether or not to callback on the listener when a
		/// item that is not selected is clicked.
		/// </param>
		/// <hide></hide>
		public virtual void setCallbackOnUnselectedItemClick(bool shouldCallback)
		{
			mShouldCallbackOnUnselectedItemClick = shouldCallback;
		}

		/// <summary>
		/// Sets how long the transition animation should run when a child view
		/// changes position.
		/// </summary>
		/// <remarks>
		/// Sets how long the transition animation should run when a child view
		/// changes position. Only relevant if animation is turned on.
		/// </remarks>
		/// <param name="animationDurationMillis">
		/// The duration of the transition, in
		/// milliseconds.
		/// </param>
		/// <attr>ref android.R.styleable#Gallery_animationDuration</attr>
		public virtual void setAnimationDuration(int animationDurationMillis)
		{
			mAnimationDuration = animationDurationMillis;
		}

		/// <summary>Sets the spacing between items in a Gallery</summary>
		/// <param name="spacing">The spacing in pixels between items in the Gallery</param>
		/// <attr>ref android.R.styleable#Gallery_spacing</attr>
		public virtual void setSpacing(int spacing)
		{
			mSpacing = spacing;
		}

		/// <summary>Sets the alpha of items that are not selected in the Gallery.</summary>
		/// <remarks>Sets the alpha of items that are not selected in the Gallery.</remarks>
		/// <param name="unselectedAlpha">the alpha for the items that are not selected.</param>
		/// <attr>ref android.R.styleable#Gallery_unselectedAlpha</attr>
		public virtual void setUnselectedAlpha(float unselectedAlpha)
		{
			mUnselectedAlpha = unselectedAlpha;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool getChildStaticTransformation(android.view.View child
			, android.view.animation.Transformation t)
		{
			t.clear();
			t.setAlpha(child == mSelectedChild ? 1.0f : mUnselectedAlpha);
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeHorizontalScrollExtent()
		{
			// Only 1 item is considered to be selected
			return 1;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeHorizontalScrollOffset()
		{
			// Current scroll position is the same as the selected position
			return mSelectedPosition;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeHorizontalScrollRange()
		{
			// Scroll range is the same as the item count
			return mItemCount;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.Gallery.LayoutParams;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.Gallery.LayoutParams(p);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.Gallery.LayoutParams(getContext(), attrs);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.widget.Gallery.LayoutParams(android.view.ViewGroup.LayoutParams
				.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			base.onLayout(changed, l, t, r, b);
			mInLayout = true;
			layout(0, false);
			mInLayout = false;
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsSpinner")]
		internal override int getChildHeight(android.view.View child)
		{
			return child.getMeasuredHeight();
		}

		/// <summary>Tracks a motion scroll.</summary>
		/// <remarks>
		/// Tracks a motion scroll. In reality, this is used to do just about any
		/// movement to items (touch scroll, arrow-key scroll, set an item as selected).
		/// </remarks>
		/// <param name="deltaX">Change in X from the previous event.</param>
		internal virtual void trackMotionScroll(int deltaX)
		{
			if (getChildCount() == 0)
			{
				return;
			}
			bool toLeft = deltaX < 0;
			int limitedDeltaX = getLimitedMotionScrollAmount(toLeft, deltaX);
			if (limitedDeltaX != deltaX)
			{
				// The above call returned a limited amount, so stop any scrolls/flings
				mFlingRunnable.endFling(false);
				onFinishedMovement();
			}
			offsetChildrenLeftAndRight(limitedDeltaX);
			detachOffScreenChildren(toLeft);
			if (toLeft)
			{
				// If moved left, there will be empty space on the right
				fillToGalleryRight();
			}
			else
			{
				// Similarly, empty space on the left
				fillToGalleryLeft();
			}
			// Clear unused views
			mRecycler.clear();
			setSelectionToCenterChild();
			onScrollChanged(0, 0, 0, 0);
			// dummy values, View's implementation does not use these.
			invalidate();
		}

		internal virtual int getLimitedMotionScrollAmount(bool motionToLeft, int deltaX)
		{
			int extremeItemPosition = motionToLeft != mIsRtl ? mItemCount - 1 : 0;
			android.view.View extremeChild = getChildAt(extremeItemPosition - mFirstPosition);
			if (extremeChild == null)
			{
				return deltaX;
			}
			int extremeChildCenter = getCenterOfView(extremeChild);
			int galleryCenter = getCenterOfGallery();
			if (motionToLeft)
			{
				if (extremeChildCenter <= galleryCenter)
				{
					// The extreme child is past his boundary point!
					return 0;
				}
			}
			else
			{
				if (extremeChildCenter >= galleryCenter)
				{
					// The extreme child is past his boundary point!
					return 0;
				}
			}
			int centerDifference = galleryCenter - extremeChildCenter;
			return motionToLeft ? System.Math.Max(centerDifference, deltaX) : System.Math.Min
				(centerDifference, deltaX);
		}

		/// <summary>
		/// Offset the horizontal location of all children of this view by the
		/// specified number of pixels.
		/// </summary>
		/// <remarks>
		/// Offset the horizontal location of all children of this view by the
		/// specified number of pixels.
		/// </remarks>
		/// <param name="offset">the number of pixels to offset</param>
		private void offsetChildrenLeftAndRight(int offset)
		{
			{
				for (int i = getChildCount() - 1; i >= 0; i--)
				{
					getChildAt(i).offsetLeftAndRight(offset);
				}
			}
		}

		/// <returns>The center of this Gallery.</returns>
		private int getCenterOfGallery()
		{
			return (getWidth() - mPaddingLeft - mPaddingRight) / 2 + mPaddingLeft;
		}

		/// <returns>The center of the given view.</returns>
		private static int getCenterOfView(android.view.View view)
		{
			return view.getLeft() + view.getWidth() / 2;
		}

		/// <summary>Detaches children that are off the screen (i.e.: Gallery bounds).</summary>
		/// <remarks>Detaches children that are off the screen (i.e.: Gallery bounds).</remarks>
		/// <param name="toLeft">
		/// Whether to detach children to the left of the Gallery, or
		/// to the right.
		/// </param>
		private void detachOffScreenChildren(bool toLeft)
		{
			int numChildren = getChildCount();
			int firstPosition = mFirstPosition;
			int start = 0;
			int count = 0;
			if (toLeft)
			{
				int galleryLeft = mPaddingLeft;
				{
					for (int i = 0; i < numChildren; i++)
					{
						int n = mIsRtl ? (numChildren - 1 - i) : i;
						android.view.View child = getChildAt(n);
						if (child.getRight() >= galleryLeft)
						{
							break;
						}
						else
						{
							start = n;
							count++;
							mRecycler.put(firstPosition + n, child);
						}
					}
				}
				if (!mIsRtl)
				{
					start = 0;
				}
			}
			else
			{
				int galleryRight = getWidth() - mPaddingRight;
				{
					for (int i = numChildren - 1; i >= 0; i--)
					{
						int n = mIsRtl ? numChildren - 1 - i : i;
						android.view.View child = getChildAt(n);
						if (child.getLeft() <= galleryRight)
						{
							break;
						}
						else
						{
							start = n;
							count++;
							mRecycler.put(firstPosition + n, child);
						}
					}
				}
				if (mIsRtl)
				{
					start = 0;
				}
			}
			detachViewsFromParent(start, count);
			if (toLeft != mIsRtl)
			{
				mFirstPosition += count;
			}
		}

		/// <summary>
		/// Scrolls the items so that the selected item is in its 'slot' (its center
		/// is the gallery's center).
		/// </summary>
		/// <remarks>
		/// Scrolls the items so that the selected item is in its 'slot' (its center
		/// is the gallery's center).
		/// </remarks>
		private void scrollIntoSlots()
		{
			if (getChildCount() == 0 || mSelectedChild == null)
			{
				return;
			}
			int selectedCenter = getCenterOfView(mSelectedChild);
			int targetCenter = getCenterOfGallery();
			int scrollAmount = targetCenter - selectedCenter;
			if (scrollAmount != 0)
			{
				mFlingRunnable.startUsingDistance(scrollAmount);
			}
			else
			{
				onFinishedMovement();
			}
		}

		private void onFinishedMovement()
		{
			if (mSuppressSelectionChanged)
			{
				mSuppressSelectionChanged = false;
				// We haven't been callbacking during the fling, so do it now
				base.selectionChanged();
			}
			invalidate();
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		internal override void selectionChanged()
		{
			if (!mSuppressSelectionChanged)
			{
				base.selectionChanged();
			}
		}

		/// <summary>
		/// Looks for the child that is closest to the center and sets it as the
		/// selected child.
		/// </summary>
		/// <remarks>
		/// Looks for the child that is closest to the center and sets it as the
		/// selected child.
		/// </remarks>
		private void setSelectionToCenterChild()
		{
			android.view.View selView = mSelectedChild;
			if (mSelectedChild == null)
			{
				return;
			}
			int galleryCenter = getCenterOfGallery();
			// Common case where the current selected position is correct
			if (selView.getLeft() <= galleryCenter && selView.getRight() >= galleryCenter)
			{
				return;
			}
			// TODO better search
			int closestEdgeDistance = int.MaxValue;
			int newSelectedChildIndex = 0;
			{
				for (int i = getChildCount() - 1; i >= 0; i--)
				{
					android.view.View child = getChildAt(i);
					if (child.getLeft() <= galleryCenter && child.getRight() >= galleryCenter)
					{
						// This child is in the center
						newSelectedChildIndex = i;
						break;
					}
					int childClosestEdgeDistance = System.Math.Min(System.Math.Abs(child.getLeft() - 
						galleryCenter), System.Math.Abs(child.getRight() - galleryCenter));
					if (childClosestEdgeDistance < closestEdgeDistance)
					{
						closestEdgeDistance = childClosestEdgeDistance;
						newSelectedChildIndex = i;
					}
				}
			}
			int newPos = mFirstPosition + newSelectedChildIndex;
			if (newPos != mSelectedPosition)
			{
				setSelectedPositionInt(newPos);
				setNextSelectedPositionInt(newPos);
				checkSelectionChanged();
			}
		}

		/// <summary>Creates and positions all views for this Gallery.</summary>
		/// <remarks>
		/// Creates and positions all views for this Gallery.
		/// <p>
		/// We layout rarely, most of the time
		/// <see cref="trackMotionScroll(int)">trackMotionScroll(int)</see>
		/// takes
		/// care of repositioning, adding, and removing children.
		/// </remarks>
		/// <param name="delta">
		/// Change in the selected position. +1 means the selection is
		/// moving to the right, so views are scrolling to the left. -1
		/// means the selection is moving to the left.
		/// </param>
		[Sharpen.OverridesMethod(@"android.widget.AbsSpinner")]
		internal override void layout(int delta, bool animate_1)
		{
			mIsRtl = isLayoutRtl();
			int childrenLeft = mSpinnerPadding.left;
			int childrenWidth = mRight - mLeft - mSpinnerPadding.left - mSpinnerPadding.right;
			if (mDataChanged)
			{
				handleDataChanged();
			}
			// Handle an empty gallery by removing all views.
			if (mItemCount == 0)
			{
				resetList();
				return;
			}
			// Update to the new selected position.
			if (mNextSelectedPosition >= 0)
			{
				setSelectedPositionInt(mNextSelectedPosition);
			}
			// All views go in recycler while we are in layout
			recycleAllViews();
			// Clear out old views
			//removeAllViewsInLayout();
			detachAllViewsFromParent();
			mRightMost = 0;
			mLeftMost = 0;
			// Make selected view and center it
			mFirstPosition = mSelectedPosition;
			android.view.View sel = makeAndAddView(mSelectedPosition, 0, 0, true);
			// Put the selected child in the center
			int selectedOffset = childrenLeft + (childrenWidth / 2) - (sel.getWidth() / 2);
			sel.offsetLeftAndRight(selectedOffset);
			fillToGalleryRight();
			fillToGalleryLeft();
			// Flush any cached views that did not get reused above
			mRecycler.clear();
			invalidate();
			checkSelectionChanged();
			mDataChanged = false;
			mNeedSync = false;
			setNextSelectedPositionInt(mSelectedPosition);
			updateSelectedItemMetadata();
		}

		private void fillToGalleryLeft()
		{
			if (mIsRtl)
			{
				fillToGalleryLeftRtl();
			}
			else
			{
				fillToGalleryLeftLtr();
			}
		}

		private void fillToGalleryLeftRtl()
		{
			int itemSpacing = mSpacing;
			int galleryLeft = mPaddingLeft;
			int numChildren = getChildCount();
			int numItems = mItemCount;
			// Set state for initial iteration
			android.view.View prevIterationView = getChildAt(numChildren - 1);
			int curPosition;
			int curRightEdge;
			if (prevIterationView != null)
			{
				curPosition = mFirstPosition + numChildren;
				curRightEdge = prevIterationView.getLeft() - itemSpacing;
			}
			else
			{
				// No children available!
				mFirstPosition = curPosition = mItemCount - 1;
				curRightEdge = mRight - mLeft - mPaddingRight;
				mShouldStopFling = true;
			}
			while (curRightEdge > galleryLeft && curPosition < mItemCount)
			{
				prevIterationView = makeAndAddView(curPosition, curPosition - mSelectedPosition, 
					curRightEdge, false);
				// Set state for next iteration
				curRightEdge = prevIterationView.getLeft() - itemSpacing;
				curPosition++;
			}
		}

		private void fillToGalleryLeftLtr()
		{
			int itemSpacing = mSpacing;
			int galleryLeft = mPaddingLeft;
			// Set state for initial iteration
			android.view.View prevIterationView = getChildAt(0);
			int curPosition;
			int curRightEdge;
			if (prevIterationView != null)
			{
				curPosition = mFirstPosition - 1;
				curRightEdge = prevIterationView.getLeft() - itemSpacing;
			}
			else
			{
				// No children available!
				curPosition = 0;
				curRightEdge = mRight - mLeft - mPaddingRight;
				mShouldStopFling = true;
			}
			while (curRightEdge > galleryLeft && curPosition >= 0)
			{
				prevIterationView = makeAndAddView(curPosition, curPosition - mSelectedPosition, 
					curRightEdge, false);
				// Remember some state
				mFirstPosition = curPosition;
				// Set state for next iteration
				curRightEdge = prevIterationView.getLeft() - itemSpacing;
				curPosition--;
			}
		}

		private void fillToGalleryRight()
		{
			if (mIsRtl)
			{
				fillToGalleryRightRtl();
			}
			else
			{
				fillToGalleryRightLtr();
			}
		}

		private void fillToGalleryRightRtl()
		{
			int itemSpacing = mSpacing;
			int galleryRight = mRight - mLeft - mPaddingRight;
			// Set state for initial iteration
			android.view.View prevIterationView = getChildAt(0);
			int curPosition;
			int curLeftEdge;
			if (prevIterationView != null)
			{
				curPosition = mFirstPosition - 1;
				curLeftEdge = prevIterationView.getRight() + itemSpacing;
			}
			else
			{
				curPosition = 0;
				curLeftEdge = mPaddingLeft;
				mShouldStopFling = true;
			}
			while (curLeftEdge < galleryRight && curPosition >= 0)
			{
				prevIterationView = makeAndAddView(curPosition, curPosition - mSelectedPosition, 
					curLeftEdge, true);
				// Remember some state
				mFirstPosition = curPosition;
				// Set state for next iteration
				curLeftEdge = prevIterationView.getRight() + itemSpacing;
				curPosition--;
			}
		}

		private void fillToGalleryRightLtr()
		{
			int itemSpacing = mSpacing;
			int galleryRight = mRight - mLeft - mPaddingRight;
			int numChildren = getChildCount();
			int numItems = mItemCount;
			// Set state for initial iteration
			android.view.View prevIterationView = getChildAt(numChildren - 1);
			int curPosition;
			int curLeftEdge;
			if (prevIterationView != null)
			{
				curPosition = mFirstPosition + numChildren;
				curLeftEdge = prevIterationView.getRight() + itemSpacing;
			}
			else
			{
				mFirstPosition = curPosition = mItemCount - 1;
				curLeftEdge = mPaddingLeft;
				mShouldStopFling = true;
			}
			while (curLeftEdge < galleryRight && curPosition < numItems)
			{
				prevIterationView = makeAndAddView(curPosition, curPosition - mSelectedPosition, 
					curLeftEdge, true);
				// Set state for next iteration
				curLeftEdge = prevIterationView.getRight() + itemSpacing;
				curPosition++;
			}
		}

		/// <summary>
		/// Obtain a view, either by pulling an existing view from the recycler or by
		/// getting a new one from the adapter.
		/// </summary>
		/// <remarks>
		/// Obtain a view, either by pulling an existing view from the recycler or by
		/// getting a new one from the adapter. If we are animating, make sure there
		/// is enough information in the view's layout parameters to animate from the
		/// old to new positions.
		/// </remarks>
		/// <param name="position">Position in the gallery for the view to obtain</param>
		/// <param name="offset">Offset from the selected position</param>
		/// <param name="x">
		/// X-coordinate indicating where this view should be placed. This
		/// will either be the left or right edge of the view, depending on
		/// the fromLeft parameter
		/// </param>
		/// <param name="fromLeft">
		/// Are we positioning views based on the left edge? (i.e.,
		/// building from left to right)?
		/// </param>
		/// <returns>A view that has been added to the gallery</returns>
		private android.view.View makeAndAddView(int position, int offset, int x, bool fromLeft
			)
		{
			android.view.View child;
			if (!mDataChanged)
			{
				child = mRecycler.get(position);
				if (child != null)
				{
					// Can reuse an existing view
					int childLeft = child.getLeft();
					// Remember left and right edges of where views have been placed
					mRightMost = System.Math.Max(mRightMost, childLeft + child.getMeasuredWidth());
					mLeftMost = System.Math.Min(mLeftMost, childLeft);
					// Position the view
					setUpChild(child, offset, x, fromLeft);
					return child;
				}
			}
			// Nothing found in the recycler -- ask the adapter for a view
			child = mAdapter.getView(position, null, this);
			// Position the view
			setUpChild(child, offset, x, fromLeft);
			return child;
		}

		/// <summary>
		/// Helper for makeAndAddView to set the position of a view and fill out its
		/// layout parameters.
		/// </summary>
		/// <remarks>
		/// Helper for makeAndAddView to set the position of a view and fill out its
		/// layout parameters.
		/// </remarks>
		/// <param name="child">The view to position</param>
		/// <param name="offset">Offset from the selected position</param>
		/// <param name="x">
		/// X-coordinate indicating where this view should be placed. This
		/// will either be the left or right edge of the view, depending on
		/// the fromLeft parameter
		/// </param>
		/// <param name="fromLeft">
		/// Are we positioning views based on the left edge? (i.e.,
		/// building from left to right)?
		/// </param>
		private void setUpChild(android.view.View child, int offset, int x, bool fromLeft
			)
		{
			// Respect layout params that are already in the view. Otherwise
			// make some up...
			android.widget.Gallery.LayoutParams lp = (android.widget.Gallery.LayoutParams)child
				.getLayoutParams();
			if (lp == null)
			{
				lp = (android.widget.Gallery.LayoutParams)generateDefaultLayoutParams();
			}
			addViewInLayout(child, fromLeft != mIsRtl ? -1 : 0, lp);
			child.setSelected(offset == 0);
			// Get measure specs
			int childHeightSpec = android.view.ViewGroup.getChildMeasureSpec(mHeightMeasureSpec
				, mSpinnerPadding.top + mSpinnerPadding.bottom, lp.height);
			int childWidthSpec = android.view.ViewGroup.getChildMeasureSpec(mWidthMeasureSpec
				, mSpinnerPadding.left + mSpinnerPadding.right, lp.width);
			// Measure child
			child.measure(childWidthSpec, childHeightSpec);
			int childLeft;
			int childRight;
			// Position vertically based on gravity setting
			int childTop = calculateTop(child, true);
			int childBottom = childTop + child.getMeasuredHeight();
			int width = child.getMeasuredWidth();
			if (fromLeft)
			{
				childLeft = x;
				childRight = childLeft + width;
			}
			else
			{
				childLeft = x - width;
				childRight = x;
			}
			child.layout(childLeft, childTop, childRight, childBottom);
		}

		/// <summary>Figure out vertical placement based on mGravity</summary>
		/// <param name="child">Child to place</param>
		/// <returns>Where the top of the child should be</returns>
		private int calculateTop(android.view.View child, bool duringLayout)
		{
			int myHeight = duringLayout ? getMeasuredHeight() : getHeight();
			int childHeight = duringLayout ? child.getMeasuredHeight() : child.getHeight();
			int childTop = 0;
			switch (mGravity)
			{
				case android.view.Gravity.TOP:
				{
					childTop = mSpinnerPadding.top;
					break;
				}

				case android.view.Gravity.CENTER_VERTICAL:
				{
					int availableSpace = myHeight - mSpinnerPadding.bottom - mSpinnerPadding.top - childHeight;
					childTop = mSpinnerPadding.top + (availableSpace / 2);
					break;
				}

				case android.view.Gravity.BOTTOM:
				{
					childTop = myHeight - mSpinnerPadding.bottom - childHeight;
					break;
				}
			}
			return childTop;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			// Give everything to the gesture detector
			bool retValue = mGestureDetector.onTouchEvent(@event);
			int action = @event.getAction();
			if (action == android.view.MotionEvent.ACTION_UP)
			{
				// Helper method for lifted finger
				onUp();
			}
			else
			{
				if (action == android.view.MotionEvent.ACTION_CANCEL)
				{
					onCancel();
				}
			}
			return retValue;
		}

		[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
		public virtual bool onSingleTapUp(android.view.MotionEvent e)
		{
			if (mDownTouchPosition >= 0)
			{
				// An item tap should make it selected, so scroll to this child.
				scrollToChild(mDownTouchPosition - mFirstPosition);
				// Also pass the click so the client knows, if it wants to.
				if (mShouldCallbackOnUnselectedItemClick || mDownTouchPosition == mSelectedPosition)
				{
					performItemClick(mDownTouchView, mDownTouchPosition, mAdapter.getItemId(mDownTouchPosition
						));
				}
				return true;
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
		public virtual bool onFling(android.view.MotionEvent e1, android.view.MotionEvent
			 e2, float velocityX, float velocityY)
		{
			if (!mShouldCallbackDuringFling)
			{
				// We want to suppress selection changes
				// Remove any future code to set mSuppressSelectionChanged = false
				removeCallbacks(mDisableSuppressSelectionChangedRunnable);
				// This will get reset once we scroll into slots
				if (!mSuppressSelectionChanged)
				{
					mSuppressSelectionChanged = true;
				}
			}
			// Fling the gallery!
			mFlingRunnable.startUsingVelocity((int)-velocityX);
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
		public virtual bool onScroll(android.view.MotionEvent e1, android.view.MotionEvent
			 e2, float distanceX, float distanceY)
		{
			mParent.requestDisallowInterceptTouchEvent(true);
			// As the user scrolls, we want to callback selection changes so related-
			// info on the screen is up-to-date with the gallery's selection
			if (!mShouldCallbackDuringFling)
			{
				if (mIsFirstScroll)
				{
					if (!mSuppressSelectionChanged)
					{
						mSuppressSelectionChanged = true;
					}
					postDelayed(mDisableSuppressSelectionChangedRunnable, SCROLL_TO_FLING_UNCERTAINTY_TIMEOUT
						);
				}
			}
			else
			{
				if (mSuppressSelectionChanged)
				{
					mSuppressSelectionChanged = false;
				}
			}
			// Track the motion
			trackMotionScroll(-1 * (int)distanceX);
			mIsFirstScroll = false;
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
		public virtual bool onDown(android.view.MotionEvent e)
		{
			// Kill any existing fling/scroll
			mFlingRunnable.stop(false);
			// Get the item's view that was touched
			mDownTouchPosition = pointToPosition((int)e.getX(), (int)e.getY());
			if (mDownTouchPosition >= 0)
			{
				mDownTouchView = getChildAt(mDownTouchPosition - mFirstPosition);
				mDownTouchView.setPressed(true);
			}
			// Reset the multiple-scroll tracking state
			mIsFirstScroll = true;
			// Must return true to get matching events for this down event.
			return true;
		}

		/// <summary>Called when a touch event's action is MotionEvent.ACTION_UP.</summary>
		/// <remarks>Called when a touch event's action is MotionEvent.ACTION_UP.</remarks>
		internal virtual void onUp()
		{
			if (mFlingRunnable.mScroller.isFinished())
			{
				scrollIntoSlots();
			}
			dispatchUnpress();
		}

		/// <summary>Called when a touch event's action is MotionEvent.ACTION_CANCEL.</summary>
		/// <remarks>Called when a touch event's action is MotionEvent.ACTION_CANCEL.</remarks>
		internal virtual void onCancel()
		{
			onUp();
		}

		[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
		public virtual void onLongPress(android.view.MotionEvent e)
		{
			if (mDownTouchPosition < 0)
			{
				return;
			}
			performHapticFeedback(android.view.HapticFeedbackConstants.LONG_PRESS);
			long id = getItemIdAtPosition(mDownTouchPosition);
			dispatchLongPress(mDownTouchView, mDownTouchPosition, id);
		}

		// Unused methods from GestureDetector.OnGestureListener below
		[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
		public virtual void onShowPress(android.view.MotionEvent e)
		{
		}

		// Unused methods from GestureDetector.OnGestureListener above
		private void dispatchPress(android.view.View child)
		{
			if (child != null)
			{
				child.setPressed(true);
			}
			setPressed(true);
		}

		private void dispatchUnpress()
		{
			{
				for (int i = getChildCount() - 1; i >= 0; i--)
				{
					getChildAt(i).setPressed(false);
				}
			}
			setPressed(false);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSetSelected(bool selected)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSetPressed(bool pressed)
		{
			// Show the pressed state on the selected child
			if (mSelectedChild != null)
			{
				mSelectedChild.setPressed(pressed);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.ContextMenuClass.ContextMenuInfo getContextMenuInfo
			()
		{
			return mContextMenuInfo;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool showContextMenuForChild(android.view.View originalView)
		{
			int longPressPosition = getPositionForView(originalView);
			if (longPressPosition < 0)
			{
				return false;
			}
			long longPressId = mAdapter.getItemId(longPressPosition);
			return dispatchLongPress(originalView, longPressPosition, longPressId);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool showContextMenu()
		{
			if (isPressed() && mSelectedPosition >= 0)
			{
				int index = mSelectedPosition - mFirstPosition;
				android.view.View v = getChildAt(index);
				return dispatchLongPress(v, mSelectedPosition, mSelectedRowId);
			}
			return false;
		}

		private bool dispatchLongPress(android.view.View view, int position, long id)
		{
			bool handled = false;
			if (mOnItemLongClickListener != null)
			{
				handled = mOnItemLongClickListener.onItemLongClick(this, mDownTouchView, mDownTouchPosition
					, id);
			}
			if (!handled)
			{
				mContextMenuInfo = new android.widget.AdapterView.AdapterContextMenuInfo(view, position
					, id);
				handled = base.showContextMenuForChild(this);
			}
			if (handled)
			{
				performHapticFeedback(android.view.HapticFeedbackConstants.LONG_PRESS);
			}
			return handled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			// Gallery steals all key events
			return @event.dispatch(this, null, null);
		}

		/// <summary>Handles left, right, and clicking</summary>
		/// <seealso cref="android.view.View.onKeyDown(int, android.view.KeyEvent)">android.view.View.onKeyDown(int, android.view.KeyEvent)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
				{
					if (movePrevious())
					{
						playSoundEffect(android.view.SoundEffectConstants.NAVIGATION_LEFT);
					}
					return true;
				}

				case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
				{
					if (moveNext())
					{
						playSoundEffect(android.view.SoundEffectConstants.NAVIGATION_RIGHT);
					}
					return true;
				}

				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					mReceivedInvokeKeyDown = true;
					break;
				}
			}
			// fallthrough to default handling
			return base.onKeyDown(keyCode, @event);
		}

		private sealed class _Runnable_1218 : java.lang.Runnable
		{
			public _Runnable_1218(Gallery _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.dispatchUnpress();
			}

			private readonly Gallery _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					if (mReceivedInvokeKeyDown)
					{
						if (mItemCount > 0)
						{
							dispatchPress(mSelectedChild);
							postDelayed(new _Runnable_1218(this), android.view.ViewConfiguration.getPressedStateDuration
								());
							int selectedIndex = mSelectedPosition - mFirstPosition;
							performItemClick(getChildAt(selectedIndex), mSelectedPosition, mAdapter.getItemId
								(mSelectedPosition));
						}
					}
					// Clear the flag
					mReceivedInvokeKeyDown = false;
					return true;
				}
			}
			return base.onKeyUp(keyCode, @event);
		}

		internal virtual bool movePrevious()
		{
			if (mItemCount > 0 && mSelectedPosition > 0)
			{
				scrollToChild(mSelectedPosition - mFirstPosition - 1);
				return true;
			}
			else
			{
				return false;
			}
		}

		internal virtual bool moveNext()
		{
			if (mItemCount > 0 && mSelectedPosition < mItemCount - 1)
			{
				scrollToChild(mSelectedPosition - mFirstPosition + 1);
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool scrollToChild(int childPosition)
		{
			android.view.View child = getChildAt(childPosition);
			if (child != null)
			{
				int distance = getCenterOfGallery() - getCenterOfView(child);
				mFlingRunnable.startUsingDistance(distance);
				return true;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		internal override void setSelectedPositionInt(int position)
		{
			base.setSelectedPositionInt(position);
			// Updates any metadata we keep about the selected item.
			updateSelectedItemMetadata();
		}

		private void updateSelectedItemMetadata()
		{
			android.view.View oldSelectedChild = mSelectedChild;
			android.view.View child = mSelectedChild = getChildAt(mSelectedPosition - mFirstPosition
				);
			if (child == null)
			{
				return;
			}
			child.setSelected(true);
			child.setFocusable(true);
			if (hasFocus())
			{
				child.requestFocus();
			}
			// We unfocus the old child down here so the above hasFocus check
			// returns true
			if (oldSelectedChild != null && oldSelectedChild != child)
			{
				// Make sure its drawable state doesn't contain 'selected'
				oldSelectedChild.setSelected(false);
				// Make sure it is not focusable anymore, since otherwise arrow keys
				// can make this one be focused
				oldSelectedChild.setFocusable(false);
			}
		}

		/// <summary>Describes how the child views are aligned.</summary>
		/// <remarks>Describes how the child views are aligned.</remarks>
		/// <param name="gravity"></param>
		/// <attr>ref android.R.styleable#Gallery_gravity</attr>
		public virtual void setGravity(int gravity)
		{
			if (mGravity != gravity)
			{
				mGravity = gravity;
				requestLayout();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override int getChildDrawingOrder(int childCount, int i)
		{
			int selectedIndex = mSelectedPosition - mFirstPosition;
			// Just to be safe
			if (selectedIndex < 0)
			{
				return i;
			}
			if (i == childCount - 1)
			{
				// Draw the selected child last
				return selectedIndex;
			}
			else
			{
				if (i >= selectedIndex)
				{
					// Move the children after the selected child earlier one
					return i + 1;
				}
				else
				{
					// Keep the children before the selected child the same
					return i;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFocusChanged(bool gainFocus, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			base.onFocusChanged(gainFocus, direction, previouslyFocusedRect);
			if (gainFocus && mSelectedChild != null)
			{
				mSelectedChild.requestFocus(direction);
				mSelectedChild.setSelected(true);
			}
		}

		/// <summary>Responsible for fling behavior.</summary>
		/// <remarks>
		/// Responsible for fling behavior. Use
		/// <see cref="startUsingVelocity(int)">startUsingVelocity(int)</see>
		/// to
		/// initiate a fling. Each frame of the fling is handled in
		/// <see cref="run()">run()</see>
		/// .
		/// A FlingRunnable will keep re-posting itself until the fling is done.
		/// </remarks>
		private class FlingRunnable : java.lang.Runnable
		{
			/// <summary>Tracks the decay of a fling scroll</summary>
			internal android.widget.Scroller mScroller;

			/// <summary>X value reported by mScroller on the previous fling</summary>
			internal int mLastFlingX;

			public FlingRunnable(Gallery _enclosing)
			{
				this._enclosing = _enclosing;
				this.mScroller = new android.widget.Scroller(this._enclosing.getContext());
			}

			internal void startCommon()
			{
				// Remove any pending flings
				this._enclosing.removeCallbacks(this);
			}

			public virtual void startUsingVelocity(int initialVelocity)
			{
				if (initialVelocity == 0)
				{
					return;
				}
				this.startCommon();
				int initialX = initialVelocity < 0 ? int.MaxValue : 0;
				this.mLastFlingX = initialX;
				this.mScroller.fling(initialX, 0, initialVelocity, 0, 0, int.MaxValue, 0, int.MaxValue
					);
				this._enclosing.post(this);
			}

			public virtual void startUsingDistance(int distance)
			{
				if (distance == 0)
				{
					return;
				}
				this.startCommon();
				this.mLastFlingX = 0;
				this.mScroller.startScroll(0, 0, -distance, 0, this._enclosing.mAnimationDuration
					);
				this._enclosing.post(this);
			}

			public virtual void stop(bool scrollIntoSlots)
			{
				this._enclosing.removeCallbacks(this);
				this.endFling(scrollIntoSlots);
			}

			internal void endFling(bool scrollIntoSlots)
			{
				this.mScroller.forceFinished(true);
				if (scrollIntoSlots)
				{
					this._enclosing.scrollIntoSlots();
				}
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (this._enclosing.mItemCount == 0)
				{
					this.endFling(true);
					return;
				}
				this._enclosing.mShouldStopFling = false;
				android.widget.Scroller scroller = this.mScroller;
				bool more = scroller.computeScrollOffset();
				int x = scroller.getCurrX();
				// Flip sign to convert finger direction to list items direction
				// (e.g. finger moving down means list is moving towards the top)
				int delta = this.mLastFlingX - x;
				// Pretend that each frame of a fling scroll is a touch scroll
				if (delta > 0)
				{
					// Moving towards the left. Use leftmost view as mDownTouchPosition
					this._enclosing.mDownTouchPosition = this._enclosing.mIsRtl ? (this._enclosing.mFirstPosition
						 + this._enclosing.getChildCount() - 1) : this._enclosing.mFirstPosition;
					// Don't fling more than 1 screen
					delta = System.Math.Min(this._enclosing.getWidth() - this._enclosing.mPaddingLeft
						 - this._enclosing.mPaddingRight - 1, delta);
				}
				else
				{
					// Moving towards the right. Use rightmost view as mDownTouchPosition
					int offsetToLast = this._enclosing.getChildCount() - 1;
					this._enclosing.mDownTouchPosition = this._enclosing.mIsRtl ? this._enclosing.mFirstPosition
						 : (this._enclosing.mFirstPosition + this._enclosing.getChildCount() - 1);
					// Don't fling more than 1 screen
					delta = System.Math.Max(-(this._enclosing.getWidth() - this._enclosing.mPaddingRight
						 - this._enclosing.mPaddingLeft - 1), delta);
				}
				this._enclosing.trackMotionScroll(delta);
				if (more && !this._enclosing.mShouldStopFling)
				{
					this.mLastFlingX = x;
					this._enclosing.post(this);
				}
				else
				{
					this.endFling(true);
				}
			}

			private readonly Gallery _enclosing;
		}

		/// <summary>
		/// Gallery extends LayoutParams to provide a place to hold current
		/// Transformation information along with previous position/transformation
		/// info.
		/// </summary>
		/// <remarks>
		/// Gallery extends LayoutParams to provide a place to hold current
		/// Transformation information along with previous position/transformation
		/// info.
		/// </remarks>
		public class LayoutParams : android.view.ViewGroup.LayoutParams
		{
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
			}

			public LayoutParams(int w, int h) : base(w, h)
			{
			}

			public LayoutParams(android.view.ViewGroup.LayoutParams source) : base(source)
			{
			}
		}
	}
}
