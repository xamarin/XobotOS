using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A Layout where the positions of the children can be described in relation to each other or to the
	/// parent.
	/// </summary>
	/// <remarks>
	/// A Layout where the positions of the children can be described in relation to each other or to the
	/// parent.
	/// <p>
	/// Note that you cannot have a circular dependency between the size of the RelativeLayout and the
	/// position of its children. For example, you cannot have a RelativeLayout whose height is set to
	/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">WRAP_CONTENT</see>
	/// and a child set to
	/// <see cref="ALIGN_PARENT_BOTTOM">ALIGN_PARENT_BOTTOM</see>
	/// .
	/// </p>
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-relativelayout.html"&gt;Relative
	/// Layout tutorial</a>.</p>
	/// <p>
	/// Also see
	/// <see cref="LayoutParams">RelativeLayout.LayoutParams</see>
	/// for
	/// layout attributes
	/// </p>
	/// </remarks>
	/// <attr>ref android.R.styleable#RelativeLayout_gravity</attr>
	/// <attr>ref android.R.styleable#RelativeLayout_ignoreGravity</attr>
	[Sharpen.Sharpened]
	public class RelativeLayout : android.view.ViewGroup
	{
		internal const string LOG_TAG = "RelativeLayout";

		internal const bool DEBUG_GRAPH = false;

		public const int TRUE = -1;

		/// <summary>Rule that aligns a child's right edge with another child's left edge.</summary>
		/// <remarks>Rule that aligns a child's right edge with another child's left edge.</remarks>
		public const int LEFT_OF = 0;

		/// <summary>Rule that aligns a child's left edge with another child's right edge.</summary>
		/// <remarks>Rule that aligns a child's left edge with another child's right edge.</remarks>
		public const int RIGHT_OF = 1;

		/// <summary>Rule that aligns a child's bottom edge with another child's top edge.</summary>
		/// <remarks>Rule that aligns a child's bottom edge with another child's top edge.</remarks>
		public const int ABOVE = 2;

		/// <summary>Rule that aligns a child's top edge with another child's bottom edge.</summary>
		/// <remarks>Rule that aligns a child's top edge with another child's bottom edge.</remarks>
		public const int BELOW = 3;

		/// <summary>Rule that aligns a child's baseline with another child's baseline.</summary>
		/// <remarks>Rule that aligns a child's baseline with another child's baseline.</remarks>
		public const int ALIGN_BASELINE = 4;

		/// <summary>Rule that aligns a child's left edge with another child's left edge.</summary>
		/// <remarks>Rule that aligns a child's left edge with another child's left edge.</remarks>
		public const int ALIGN_LEFT = 5;

		/// <summary>Rule that aligns a child's top edge with another child's top edge.</summary>
		/// <remarks>Rule that aligns a child's top edge with another child's top edge.</remarks>
		public const int ALIGN_TOP = 6;

		/// <summary>Rule that aligns a child's right edge with another child's right edge.</summary>
		/// <remarks>Rule that aligns a child's right edge with another child's right edge.</remarks>
		public const int ALIGN_RIGHT = 7;

		/// <summary>Rule that aligns a child's bottom edge with another child's bottom edge.
		/// 	</summary>
		/// <remarks>Rule that aligns a child's bottom edge with another child's bottom edge.
		/// 	</remarks>
		public const int ALIGN_BOTTOM = 8;

		/// <summary>
		/// Rule that aligns the child's left edge with its RelativeLayout
		/// parent's left edge.
		/// </summary>
		/// <remarks>
		/// Rule that aligns the child's left edge with its RelativeLayout
		/// parent's left edge.
		/// </remarks>
		public const int ALIGN_PARENT_LEFT = 9;

		/// <summary>
		/// Rule that aligns the child's top edge with its RelativeLayout
		/// parent's top edge.
		/// </summary>
		/// <remarks>
		/// Rule that aligns the child's top edge with its RelativeLayout
		/// parent's top edge.
		/// </remarks>
		public const int ALIGN_PARENT_TOP = 10;

		/// <summary>
		/// Rule that aligns the child's right edge with its RelativeLayout
		/// parent's right edge.
		/// </summary>
		/// <remarks>
		/// Rule that aligns the child's right edge with its RelativeLayout
		/// parent's right edge.
		/// </remarks>
		public const int ALIGN_PARENT_RIGHT = 11;

		/// <summary>
		/// Rule that aligns the child's bottom edge with its RelativeLayout
		/// parent's bottom edge.
		/// </summary>
		/// <remarks>
		/// Rule that aligns the child's bottom edge with its RelativeLayout
		/// parent's bottom edge.
		/// </remarks>
		public const int ALIGN_PARENT_BOTTOM = 12;

		/// <summary>
		/// Rule that centers the child with respect to the bounds of its
		/// RelativeLayout parent.
		/// </summary>
		/// <remarks>
		/// Rule that centers the child with respect to the bounds of its
		/// RelativeLayout parent.
		/// </remarks>
		public const int CENTER_IN_PARENT = 13;

		/// <summary>
		/// Rule that centers the child horizontally with respect to the
		/// bounds of its RelativeLayout parent.
		/// </summary>
		/// <remarks>
		/// Rule that centers the child horizontally with respect to the
		/// bounds of its RelativeLayout parent.
		/// </remarks>
		public const int CENTER_HORIZONTAL = 14;

		/// <summary>
		/// Rule that centers the child vertically with respect to the
		/// bounds of its RelativeLayout parent.
		/// </summary>
		/// <remarks>
		/// Rule that centers the child vertically with respect to the
		/// bounds of its RelativeLayout parent.
		/// </remarks>
		public const int CENTER_VERTICAL = 15;

		internal const int VERB_COUNT = 16;

		private android.view.View mBaselineView = null;

		private bool mHasBaselineAlignedChild;

		private int mGravity = android.view.Gravity.LEFT | android.view.Gravity.TOP;

		private readonly android.graphics.Rect mContentBounds = new android.graphics.Rect
			();

		private readonly android.graphics.Rect mSelfBounds = new android.graphics.Rect();

		private int mIgnoreGravity;

		private java.util.SortedSet<android.view.View> mTopToBottomLeftToRightSet = null;

		private bool mDirtyHierarchy;

		private android.view.View[] mSortedHorizontalChildren = new android.view.View[0];

		private android.view.View[] mSortedVerticalChildren = new android.view.View[0];

		private readonly android.widget.RelativeLayout.DependencyGraph mGraph = new android.widget.RelativeLayout
			.DependencyGraph();

		public RelativeLayout(android.content.Context context) : base(context)
		{
		}

		public RelativeLayout(android.content.Context context, android.util.AttributeSet 
			attrs) : base(context, attrs)
		{
			initFromAttributes(context, attrs);
		}

		public RelativeLayout(android.content.Context context, android.util.AttributeSet 
			attrs, int defStyle) : base(context, attrs, defStyle)
		{
			initFromAttributes(context, attrs);
		}

		new private void initFromAttributes(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.RelativeLayout);
			mIgnoreGravity = a.getResourceId(android.@internal.R.styleable.RelativeLayout_ignoreGravity
				, android.view.View.NO_ID);
			mGravity = a.getInt(android.@internal.R.styleable.RelativeLayout_gravity, mGravity
				);
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool shouldDelayChildPressedState()
		{
			return false;
		}

		/// <summary>Defines which View is ignored when the gravity is applied.</summary>
		/// <remarks>
		/// Defines which View is ignored when the gravity is applied. This setting has no
		/// effect if the gravity is <code>Gravity.LEFT | Gravity.TOP</code>.
		/// </remarks>
		/// <param name="viewId">
		/// The id of the View to be ignored by gravity, or 0 if no View
		/// should be ignored.
		/// </param>
		/// <seealso cref="setGravity(int)">setGravity(int)</seealso>
		/// <attr>ref android.R.styleable#RelativeLayout_ignoreGravity</attr>
		[android.view.RemotableViewMethod]
		public virtual void setIgnoreGravity(int viewId)
		{
			mIgnoreGravity = viewId;
		}

		/// <summary>Describes how the child views are positioned.</summary>
		/// <remarks>
		/// Describes how the child views are positioned. Defaults to
		/// <code>Gravity.LEFT | Gravity.TOP</code>.
		/// <p>Note that since RelativeLayout considers the positioning of each child
		/// relative to one another to be significant, setting gravity will affect
		/// the positioning of all children as a single unit within the parent.
		/// This happens after children have been relatively positioned.</p>
		/// </remarks>
		/// <param name="gravity">
		/// See
		/// <see cref="android.view.Gravity">android.view.Gravity</see>
		/// </param>
		/// <seealso cref="setHorizontalGravity(int)">setHorizontalGravity(int)</seealso>
		/// <seealso cref="setVerticalGravity(int)">setVerticalGravity(int)</seealso>
		/// <attr>ref android.R.styleable#RelativeLayout_gravity</attr>
		[android.view.RemotableViewMethod]
		public virtual void setGravity(int gravity)
		{
			if (mGravity != gravity)
			{
				if ((gravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK) == 0)
				{
					gravity |= android.view.Gravity.START;
				}
				if ((gravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == 0)
				{
					gravity |= android.view.Gravity.TOP;
				}
				mGravity = gravity;
				requestLayout();
			}
		}

		[android.view.RemotableViewMethod]
		public virtual void setHorizontalGravity(int horizontalGravity)
		{
			int gravity = horizontalGravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK;
			if ((mGravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK) != gravity)
			{
				mGravity = (mGravity & ~android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK) | 
					gravity;
				requestLayout();
			}
		}

		[android.view.RemotableViewMethod]
		public virtual void setVerticalGravity(int verticalGravity)
		{
			int gravity = verticalGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) != gravity)
			{
				mGravity = (mGravity & ~android.view.Gravity.VERTICAL_GRAVITY_MASK) | gravity;
				requestLayout();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			return mBaselineView != null ? mBaselineView.getBaseline() : base.getBaseline();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void requestLayout()
		{
			base.requestLayout();
			mDirtyHierarchy = true;
		}

		private void sortChildren()
		{
			int count = getChildCount();
			if (mSortedVerticalChildren.Length != count)
			{
				mSortedVerticalChildren = new android.view.View[count];
			}
			if (mSortedHorizontalChildren.Length != count)
			{
				mSortedHorizontalChildren = new android.view.View[count];
			}
			android.widget.RelativeLayout.DependencyGraph graph = mGraph;
			graph.clear();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					graph.add(child);
				}
			}
			graph.getSortedViews(mSortedVerticalChildren, ABOVE, BELOW, ALIGN_BASELINE, ALIGN_TOP
				, ALIGN_BOTTOM);
			graph.getSortedViews(mSortedHorizontalChildren, LEFT_OF, RIGHT_OF, ALIGN_LEFT, ALIGN_RIGHT
				);
		}

		// TODO: we need to find another way to implement RelativeLayout
		// This implementation cannot handle every case
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			if (mDirtyHierarchy)
			{
				mDirtyHierarchy = false;
				sortChildren();
			}
			int myWidth = -1;
			int myHeight = -1;
			int width = 0;
			int height = 0;
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			int widthSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int heightSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
			// Record our dimensions if they are known;
			if (widthMode != android.view.View.MeasureSpec.UNSPECIFIED)
			{
				myWidth = widthSize;
			}
			if (heightMode != android.view.View.MeasureSpec.UNSPECIFIED)
			{
				myHeight = heightSize;
			}
			if (widthMode == android.view.View.MeasureSpec.EXACTLY)
			{
				width = myWidth;
			}
			if (heightMode == android.view.View.MeasureSpec.EXACTLY)
			{
				height = myHeight;
			}
			mHasBaselineAlignedChild = false;
			android.view.View ignore = null;
			int gravity = mGravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK;
			bool horizontalGravity = gravity != android.view.Gravity.LEFT && gravity != 0;
			gravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			bool verticalGravity = gravity != android.view.Gravity.TOP && gravity != 0;
			int left = int.MaxValue;
			int top = int.MaxValue;
			int right = int.MinValue;
			int bottom = int.MinValue;
			bool offsetHorizontalAxis = false;
			bool offsetVerticalAxis = false;
			if ((horizontalGravity || verticalGravity) && mIgnoreGravity != android.view.View
				.NO_ID)
			{
				ignore = findViewById(mIgnoreGravity);
			}
			bool isWrapContentWidth = widthMode != android.view.View.MeasureSpec.EXACTLY;
			bool isWrapContentHeight = heightMode != android.view.View.MeasureSpec.EXACTLY;
			android.view.View[] views = mSortedHorizontalChildren;
			int count = views.Length;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = views[i];
					if (child.getVisibility() != GONE)
					{
						android.widget.RelativeLayout.LayoutParams @params = (android.widget.RelativeLayout
							.LayoutParams)child.getLayoutParams();
						applyHorizontalSizeRules(@params, myWidth);
						measureChildHorizontal(child, @params, myWidth, myHeight);
						if (positionChildHorizontal(child, @params, myWidth, isWrapContentWidth))
						{
							offsetHorizontalAxis = true;
						}
					}
				}
			}
			views = mSortedVerticalChildren;
			count = views.Length;
			{
				for (int i_1 = 0; i_1 < count; i_1++)
				{
					android.view.View child = views[i_1];
					if (child.getVisibility() != GONE)
					{
						android.widget.RelativeLayout.LayoutParams @params = (android.widget.RelativeLayout
							.LayoutParams)child.getLayoutParams();
						applyVerticalSizeRules(@params, myHeight);
						measureChild(child, @params, myWidth, myHeight);
						if (positionChildVertical(child, @params, myHeight, isWrapContentHeight))
						{
							offsetVerticalAxis = true;
						}
						if (isWrapContentWidth)
						{
							width = System.Math.Max(width, @params.mRight);
						}
						if (isWrapContentHeight)
						{
							height = System.Math.Max(height, @params.mBottom);
						}
						if (child != ignore || verticalGravity)
						{
							left = System.Math.Min(left, @params.mLeft - @params.leftMargin);
							top = System.Math.Min(top, @params.mTop - @params.topMargin);
						}
						if (child != ignore || horizontalGravity)
						{
							right = System.Math.Max(right, @params.mRight + @params.rightMargin);
							bottom = System.Math.Max(bottom, @params.mBottom + @params.bottomMargin);
						}
					}
				}
			}
			if (mHasBaselineAlignedChild)
			{
				{
					for (int i_2 = 0; i_2 < count; i_2++)
					{
						android.view.View child = getChildAt(i_2);
						if (child.getVisibility() != GONE)
						{
							android.widget.RelativeLayout.LayoutParams @params = (android.widget.RelativeLayout
								.LayoutParams)child.getLayoutParams();
							alignBaseline(child, @params);
							if (child != ignore || verticalGravity)
							{
								left = System.Math.Min(left, @params.mLeft - @params.leftMargin);
								top = System.Math.Min(top, @params.mTop - @params.topMargin);
							}
							if (child != ignore || horizontalGravity)
							{
								right = System.Math.Max(right, @params.mRight + @params.rightMargin);
								bottom = System.Math.Max(bottom, @params.mBottom + @params.bottomMargin);
							}
						}
					}
				}
			}
			if (isWrapContentWidth)
			{
				// Width already has left padding in it since it was calculated by looking at
				// the right of each child view
				width += mPaddingRight;
				if (mLayoutParams.width >= 0)
				{
					width = System.Math.Max(width, mLayoutParams.width);
				}
				width = System.Math.Max(width, getSuggestedMinimumWidth());
				width = resolveSize(width, widthMeasureSpec);
				if (offsetHorizontalAxis)
				{
					{
						for (int i_2 = 0; i_2 < count; i_2++)
						{
							android.view.View child = getChildAt(i_2);
							if (child.getVisibility() != GONE)
							{
								android.widget.RelativeLayout.LayoutParams @params = (android.widget.RelativeLayout
									.LayoutParams)child.getLayoutParams();
								int[] rules = @params.getRules();
								if (rules[CENTER_IN_PARENT] != 0 || rules[CENTER_HORIZONTAL] != 0)
								{
									centerHorizontal(child, @params, width);
								}
								else
								{
									if (rules[ALIGN_PARENT_RIGHT] != 0)
									{
										int childWidth = child.getMeasuredWidth();
										@params.mLeft = width - mPaddingRight - childWidth;
										@params.mRight = @params.mLeft + childWidth;
									}
								}
							}
						}
					}
				}
			}
			if (isWrapContentHeight)
			{
				// Height already has top padding in it since it was calculated by looking at
				// the bottom of each child view
				height += mPaddingBottom;
				if (mLayoutParams.height >= 0)
				{
					height = System.Math.Max(height, mLayoutParams.height);
				}
				height = System.Math.Max(height, getSuggestedMinimumHeight());
				height = resolveSize(height, heightMeasureSpec);
				if (offsetVerticalAxis)
				{
					{
						for (int i_2 = 0; i_2 < count; i_2++)
						{
							android.view.View child = getChildAt(i_2);
							if (child.getVisibility() != GONE)
							{
								android.widget.RelativeLayout.LayoutParams @params = (android.widget.RelativeLayout
									.LayoutParams)child.getLayoutParams();
								int[] rules = @params.getRules();
								if (rules[CENTER_IN_PARENT] != 0 || rules[CENTER_VERTICAL] != 0)
								{
									centerVertical(child, @params, height);
								}
								else
								{
									if (rules[ALIGN_PARENT_BOTTOM] != 0)
									{
										int childHeight = child.getMeasuredHeight();
										@params.mTop = height - mPaddingBottom - childHeight;
										@params.mBottom = @params.mTop + childHeight;
									}
								}
							}
						}
					}
				}
			}
			if (horizontalGravity || verticalGravity)
			{
				android.graphics.Rect selfBounds = mSelfBounds;
				selfBounds.set(mPaddingLeft, mPaddingTop, width - mPaddingRight, height - mPaddingBottom
					);
				android.graphics.Rect contentBounds = mContentBounds;
				int layoutDirection = getResolvedLayoutDirection();
				android.view.Gravity.apply(mGravity, right - left, bottom - top, selfBounds, contentBounds
					, layoutDirection);
				int horizontalOffset = contentBounds.left - left;
				int verticalOffset = contentBounds.top - top;
				if (horizontalOffset != 0 || verticalOffset != 0)
				{
					{
						for (int i_2 = 0; i_2 < count; i_2++)
						{
							android.view.View child = getChildAt(i_2);
							if (child.getVisibility() != GONE && child != ignore)
							{
								android.widget.RelativeLayout.LayoutParams @params = (android.widget.RelativeLayout
									.LayoutParams)child.getLayoutParams();
								if (horizontalGravity)
								{
									@params.mLeft += horizontalOffset;
									@params.mRight += horizontalOffset;
								}
								if (verticalGravity)
								{
									@params.mTop += verticalOffset;
									@params.mBottom += verticalOffset;
								}
							}
						}
					}
				}
			}
			setMeasuredDimension(width, height);
		}

		private void alignBaseline(android.view.View child, android.widget.RelativeLayout
			.LayoutParams @params)
		{
			int[] rules = @params.getRules();
			int anchorBaseline = getRelatedViewBaseline(rules, ALIGN_BASELINE);
			if (anchorBaseline != -1)
			{
				android.widget.RelativeLayout.LayoutParams anchorParams = getRelatedViewParams(rules
					, ALIGN_BASELINE);
				if (anchorParams != null)
				{
					int offset = anchorParams.mTop + anchorBaseline;
					int baseline = child.getBaseline();
					if (baseline != -1)
					{
						offset -= baseline;
					}
					int height = @params.mBottom - @params.mTop;
					@params.mTop = offset;
					@params.mBottom = @params.mTop + height;
				}
			}
			if (mBaselineView == null)
			{
				mBaselineView = child;
			}
			else
			{
				android.widget.RelativeLayout.LayoutParams lp = (android.widget.RelativeLayout.LayoutParams
					)mBaselineView.getLayoutParams();
				if (@params.mTop < lp.mTop || (@params.mTop == lp.mTop && @params.mLeft < lp.mLeft
					))
				{
					mBaselineView = child;
				}
			}
		}

		/// <summary>Measure a child.</summary>
		/// <remarks>
		/// Measure a child. The child should have left, top, right and bottom information
		/// stored in its LayoutParams. If any of these values is -1 it means that the view
		/// can extend up to the corresponding edge.
		/// </remarks>
		/// <param name="child">Child to measure</param>
		/// <param name="params">LayoutParams associated with child</param>
		/// <param name="myWidth">Width of the the RelativeLayout</param>
		/// <param name="myHeight">Height of the RelativeLayout</param>
		private void measureChild(android.view.View child, android.widget.RelativeLayout.
			LayoutParams @params, int myWidth, int myHeight)
		{
			int childWidthMeasureSpec = getChildMeasureSpec(@params.mLeft, @params.mRight, @params
				.width, @params.leftMargin, @params.rightMargin, mPaddingLeft, mPaddingRight, myWidth
				);
			int childHeightMeasureSpec = getChildMeasureSpec(@params.mTop, @params.mBottom, @params
				.height, @params.topMargin, @params.bottomMargin, mPaddingTop, mPaddingBottom, myHeight
				);
			child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
		}

		private void measureChildHorizontal(android.view.View child, android.widget.RelativeLayout
			.LayoutParams @params, int myWidth, int myHeight)
		{
			int childWidthMeasureSpec = getChildMeasureSpec(@params.mLeft, @params.mRight, @params
				.width, @params.leftMargin, @params.rightMargin, mPaddingLeft, mPaddingRight, myWidth
				);
			int childHeightMeasureSpec;
			if (@params.width == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
			{
				childHeightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(myHeight, 
					android.view.View.MeasureSpec.EXACTLY);
			}
			else
			{
				childHeightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(myHeight, 
					android.view.View.MeasureSpec.AT_MOST);
			}
			child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
		}

		/// <summary>Get a measure spec that accounts for all of the constraints on this view.
		/// 	</summary>
		/// <remarks>
		/// Get a measure spec that accounts for all of the constraints on this view.
		/// This includes size contstraints imposed by the RelativeLayout as well as
		/// the View's desired dimension.
		/// </remarks>
		/// <param name="childStart">The left or top field of the child's layout params</param>
		/// <param name="childEnd">The right or bottom field of the child's layout params</param>
		/// <param name="childSize">
		/// The child's desired size (the width or height field of
		/// the child's layout params)
		/// </param>
		/// <param name="startMargin">The left or top margin</param>
		/// <param name="endMargin">The right or bottom margin</param>
		/// <param name="startPadding">mPaddingLeft or mPaddingTop</param>
		/// <param name="endPadding">mPaddingRight or mPaddingBottom</param>
		/// <param name="mySize">The width or height of this view (the RelativeLayout)</param>
		/// <returns>MeasureSpec for the child</returns>
		private int getChildMeasureSpec(int childStart, int childEnd, int childSize, int 
			startMargin, int endMargin, int startPadding, int endPadding, int mySize)
		{
			int childSpecMode = 0;
			int childSpecSize = 0;
			// Figure out start and end bounds.
			int tempStart = childStart;
			int tempEnd = childEnd;
			// If the view did not express a layout constraint for an edge, use
			// view's margins and our padding
			if (tempStart < 0)
			{
				tempStart = startPadding + startMargin;
			}
			if (tempEnd < 0)
			{
				tempEnd = mySize - endPadding - endMargin;
			}
			// Figure out maximum size available to this view
			int maxAvailable = tempEnd - tempStart;
			if (childStart >= 0 && childEnd >= 0)
			{
				// Constraints fixed both edges, so child must be an exact size
				childSpecMode = android.view.View.MeasureSpec.EXACTLY;
				childSpecSize = maxAvailable;
			}
			else
			{
				if (childSize >= 0)
				{
					// Child wanted an exact size. Give as much as possible
					childSpecMode = android.view.View.MeasureSpec.EXACTLY;
					if (maxAvailable >= 0)
					{
						// We have a maxmum size in this dimension.
						childSpecSize = System.Math.Min(maxAvailable, childSize);
					}
					else
					{
						// We can grow in this dimension.
						childSpecSize = childSize;
					}
				}
				else
				{
					if (childSize == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
					{
						// Child wanted to be as big as possible. Give all availble
						// space
						childSpecMode = android.view.View.MeasureSpec.EXACTLY;
						childSpecSize = maxAvailable;
					}
					else
					{
						if (childSize == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
						{
							// Child wants to wrap content. Use AT_MOST
							// to communicate available space if we know
							// our max size
							if (maxAvailable >= 0)
							{
								// We have a maxmum size in this dimension.
								childSpecMode = android.view.View.MeasureSpec.AT_MOST;
								childSpecSize = maxAvailable;
							}
							else
							{
								// We can grow in this dimension. Child can be as big as it
								// wants
								childSpecMode = android.view.View.MeasureSpec.UNSPECIFIED;
								childSpecSize = 0;
							}
						}
					}
				}
			}
			return android.view.View.MeasureSpec.makeMeasureSpec(childSpecSize, childSpecMode
				);
		}

		private bool positionChildHorizontal(android.view.View child, android.widget.RelativeLayout
			.LayoutParams @params, int myWidth, bool wrapContent)
		{
			int[] rules = @params.getRules();
			if (@params.mLeft < 0 && @params.mRight >= 0)
			{
				// Right is fixed, but left varies
				@params.mLeft = @params.mRight - child.getMeasuredWidth();
			}
			else
			{
				if (@params.mLeft >= 0 && @params.mRight < 0)
				{
					// Left is fixed, but right varies
					@params.mRight = @params.mLeft + child.getMeasuredWidth();
				}
				else
				{
					if (@params.mLeft < 0 && @params.mRight < 0)
					{
						// Both left and right vary
						if (rules[CENTER_IN_PARENT] != 0 || rules[CENTER_HORIZONTAL] != 0)
						{
							if (!wrapContent)
							{
								centerHorizontal(child, @params, myWidth);
							}
							else
							{
								@params.mLeft = mPaddingLeft + @params.leftMargin;
								@params.mRight = @params.mLeft + child.getMeasuredWidth();
							}
							return true;
						}
						else
						{
							@params.mLeft = mPaddingLeft + @params.leftMargin;
							@params.mRight = @params.mLeft + child.getMeasuredWidth();
						}
					}
				}
			}
			return rules[ALIGN_PARENT_RIGHT] != 0;
		}

		private bool positionChildVertical(android.view.View child, android.widget.RelativeLayout
			.LayoutParams @params, int myHeight, bool wrapContent)
		{
			int[] rules = @params.getRules();
			if (@params.mTop < 0 && @params.mBottom >= 0)
			{
				// Bottom is fixed, but top varies
				@params.mTop = @params.mBottom - child.getMeasuredHeight();
			}
			else
			{
				if (@params.mTop >= 0 && @params.mBottom < 0)
				{
					// Top is fixed, but bottom varies
					@params.mBottom = @params.mTop + child.getMeasuredHeight();
				}
				else
				{
					if (@params.mTop < 0 && @params.mBottom < 0)
					{
						// Both top and bottom vary
						if (rules[CENTER_IN_PARENT] != 0 || rules[CENTER_VERTICAL] != 0)
						{
							if (!wrapContent)
							{
								centerVertical(child, @params, myHeight);
							}
							else
							{
								@params.mTop = mPaddingTop + @params.topMargin;
								@params.mBottom = @params.mTop + child.getMeasuredHeight();
							}
							return true;
						}
						else
						{
							@params.mTop = mPaddingTop + @params.topMargin;
							@params.mBottom = @params.mTop + child.getMeasuredHeight();
						}
					}
				}
			}
			return rules[ALIGN_PARENT_BOTTOM] != 0;
		}

		private void applyHorizontalSizeRules(android.widget.RelativeLayout.LayoutParams 
			childParams, int myWidth)
		{
			int[] rules = childParams.getRules();
			android.widget.RelativeLayout.LayoutParams anchorParams;
			// -1 indicated a "soft requirement" in that direction. For example:
			// left=10, right=-1 means the view must start at 10, but can go as far as it wants to the right
			// left =-1, right=10 means the view must end at 10, but can go as far as it wants to the left
			// left=10, right=20 means the left and right ends are both fixed
			childParams.mLeft = -1;
			childParams.mRight = -1;
			anchorParams = getRelatedViewParams(rules, LEFT_OF);
			if (anchorParams != null)
			{
				childParams.mRight = anchorParams.mLeft - (anchorParams.leftMargin + childParams.
					rightMargin);
			}
			else
			{
				if (childParams.alignWithParent && rules[LEFT_OF] != 0)
				{
					if (myWidth >= 0)
					{
						childParams.mRight = myWidth - mPaddingRight - childParams.rightMargin;
					}
				}
			}
			// FIXME uh oh...
			anchorParams = getRelatedViewParams(rules, RIGHT_OF);
			if (anchorParams != null)
			{
				childParams.mLeft = anchorParams.mRight + (anchorParams.rightMargin + childParams
					.leftMargin);
			}
			else
			{
				if (childParams.alignWithParent && rules[RIGHT_OF] != 0)
				{
					childParams.mLeft = mPaddingLeft + childParams.leftMargin;
				}
			}
			anchorParams = getRelatedViewParams(rules, ALIGN_LEFT);
			if (anchorParams != null)
			{
				childParams.mLeft = anchorParams.mLeft + childParams.leftMargin;
			}
			else
			{
				if (childParams.alignWithParent && rules[ALIGN_LEFT] != 0)
				{
					childParams.mLeft = mPaddingLeft + childParams.leftMargin;
				}
			}
			anchorParams = getRelatedViewParams(rules, ALIGN_RIGHT);
			if (anchorParams != null)
			{
				childParams.mRight = anchorParams.mRight - childParams.rightMargin;
			}
			else
			{
				if (childParams.alignWithParent && rules[ALIGN_RIGHT] != 0)
				{
					if (myWidth >= 0)
					{
						childParams.mRight = myWidth - mPaddingRight - childParams.rightMargin;
					}
				}
			}
			// FIXME uh oh...
			if (0 != rules[ALIGN_PARENT_LEFT])
			{
				childParams.mLeft = mPaddingLeft + childParams.leftMargin;
			}
			if (0 != rules[ALIGN_PARENT_RIGHT])
			{
				if (myWidth >= 0)
				{
					childParams.mRight = myWidth - mPaddingRight - childParams.rightMargin;
				}
			}
		}

		// FIXME uh oh...
		private void applyVerticalSizeRules(android.widget.RelativeLayout.LayoutParams childParams
			, int myHeight)
		{
			int[] rules = childParams.getRules();
			android.widget.RelativeLayout.LayoutParams anchorParams;
			childParams.mTop = -1;
			childParams.mBottom = -1;
			anchorParams = getRelatedViewParams(rules, ABOVE);
			if (anchorParams != null)
			{
				childParams.mBottom = anchorParams.mTop - (anchorParams.topMargin + childParams.bottomMargin
					);
			}
			else
			{
				if (childParams.alignWithParent && rules[ABOVE] != 0)
				{
					if (myHeight >= 0)
					{
						childParams.mBottom = myHeight - mPaddingBottom - childParams.bottomMargin;
					}
				}
			}
			// FIXME uh oh...
			anchorParams = getRelatedViewParams(rules, BELOW);
			if (anchorParams != null)
			{
				childParams.mTop = anchorParams.mBottom + (anchorParams.bottomMargin + childParams
					.topMargin);
			}
			else
			{
				if (childParams.alignWithParent && rules[BELOW] != 0)
				{
					childParams.mTop = mPaddingTop + childParams.topMargin;
				}
			}
			anchorParams = getRelatedViewParams(rules, ALIGN_TOP);
			if (anchorParams != null)
			{
				childParams.mTop = anchorParams.mTop + childParams.topMargin;
			}
			else
			{
				if (childParams.alignWithParent && rules[ALIGN_TOP] != 0)
				{
					childParams.mTop = mPaddingTop + childParams.topMargin;
				}
			}
			anchorParams = getRelatedViewParams(rules, ALIGN_BOTTOM);
			if (anchorParams != null)
			{
				childParams.mBottom = anchorParams.mBottom - childParams.bottomMargin;
			}
			else
			{
				if (childParams.alignWithParent && rules[ALIGN_BOTTOM] != 0)
				{
					if (myHeight >= 0)
					{
						childParams.mBottom = myHeight - mPaddingBottom - childParams.bottomMargin;
					}
				}
			}
			// FIXME uh oh...
			if (0 != rules[ALIGN_PARENT_TOP])
			{
				childParams.mTop = mPaddingTop + childParams.topMargin;
			}
			if (0 != rules[ALIGN_PARENT_BOTTOM])
			{
				if (myHeight >= 0)
				{
					childParams.mBottom = myHeight - mPaddingBottom - childParams.bottomMargin;
				}
			}
			// FIXME uh oh...
			if (rules[ALIGN_BASELINE] != 0)
			{
				mHasBaselineAlignedChild = true;
			}
		}

		private android.view.View getRelatedView(int[] rules, int relation)
		{
			int id = rules[relation];
			if (id != 0)
			{
				android.widget.RelativeLayout.DependencyGraph.Node node = mGraph.mKeyNodes.get(id
					);
				if (node == null)
				{
					return null;
				}
				android.view.View v = node.view;
				// Find the first non-GONE view up the chain
				while (v.getVisibility() == android.view.View.GONE)
				{
					rules = ((android.widget.RelativeLayout.LayoutParams)v.getLayoutParams()).getRules
						();
					node = mGraph.mKeyNodes.get((rules[relation]));
					if (node == null)
					{
						return null;
					}
					v = node.view;
				}
				return v;
			}
			return null;
		}

		private android.widget.RelativeLayout.LayoutParams getRelatedViewParams(int[] rules
			, int relation)
		{
			android.view.View v = getRelatedView(rules, relation);
			if (v != null)
			{
				android.view.ViewGroup.LayoutParams @params = v.getLayoutParams();
				if (@params is android.widget.RelativeLayout.LayoutParams)
				{
					return (android.widget.RelativeLayout.LayoutParams)v.getLayoutParams();
				}
			}
			return null;
		}

		private int getRelatedViewBaseline(int[] rules, int relation)
		{
			android.view.View v = getRelatedView(rules, relation);
			if (v != null)
			{
				return v.getBaseline();
			}
			return -1;
		}

		private void centerHorizontal(android.view.View child, android.widget.RelativeLayout
			.LayoutParams @params, int myWidth)
		{
			int childWidth = child.getMeasuredWidth();
			int left = (myWidth - childWidth) / 2;
			@params.mLeft = left;
			@params.mRight = left + childWidth;
		}

		private void centerVertical(android.view.View child, android.widget.RelativeLayout
			.LayoutParams @params, int myHeight)
		{
			int childHeight = child.getMeasuredHeight();
			int top = (myHeight - childHeight) / 2;
			@params.mTop = top;
			@params.mBottom = top + childHeight;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			//  The layout has actually already been performed and the positions
			//  cached.  Apply the cached values to the children.
			int count = getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() != GONE)
					{
						android.widget.RelativeLayout.LayoutParams st = (android.widget.RelativeLayout.LayoutParams
							)child.getLayoutParams();
						child.layout(st.mLeft, st.mTop, st.mRight, st.mBottom);
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.RelativeLayout.LayoutParams(getContext(), attrs);
		}

		/// <summary>
		/// Returns a set of layout parameters with a width of
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// ,
		/// a height of
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// and no spanning.
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.widget.RelativeLayout.LayoutParams(android.view.ViewGroup.LayoutParams
				.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
		}

		// Override to allow type-checking of LayoutParams.
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.RelativeLayout.LayoutParams;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.RelativeLayout.LayoutParams(p);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (mTopToBottomLeftToRightSet == null)
			{
				mTopToBottomLeftToRightSet = new java.util.TreeSet<android.view.View>(new android.widget.RelativeLayout
					.TopToBottomLeftToRightComparator(this));
			}
			{
				int i = 0;
				int count = getChildCount();
				// sort children top-to-bottom and left-to-right
				for (; i < count; i++)
				{
					mTopToBottomLeftToRightSet.add(getChildAt(i));
				}
			}
			foreach (android.view.View view in Sharpen.IterableProxy.Create(mTopToBottomLeftToRightSet
				))
			{
				if (view.getVisibility() == android.view.View.VISIBLE && view.dispatchPopulateAccessibilityEvent
					(@event))
				{
					mTopToBottomLeftToRightSet.clear();
					return true;
				}
			}
			mTopToBottomLeftToRightSet.clear();
			return false;
		}

		/// <summary>Compares two views in left-to-right and top-to-bottom fashion.</summary>
		/// <remarks>Compares two views in left-to-right and top-to-bottom fashion.</remarks>
		private class TopToBottomLeftToRightComparator : java.util.Comparator<android.view.View
			>
		{
			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public virtual int compare(android.view.View first, android.view.View second)
			{
				// top - bottom
				int topDifference = first.getTop() - second.getTop();
				if (topDifference != 0)
				{
					return topDifference;
				}
				// left - right
				int leftDifference = first.getLeft() - second.getLeft();
				if (leftDifference != 0)
				{
					return leftDifference;
				}
				// break tie by height
				int heightDiference = first.getHeight() - second.getHeight();
				if (heightDiference != 0)
				{
					return heightDiference;
				}
				// break tie by width
				int widthDiference = first.getWidth() - second.getWidth();
				if (widthDiference != 0)
				{
					return widthDiference;
				}
				return 0;
			}

			internal TopToBottomLeftToRightComparator(RelativeLayout _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly RelativeLayout _enclosing;
		}

		/// <summary>Per-child layout information associated with RelativeLayout.</summary>
		/// <remarks>Per-child layout information associated with RelativeLayout.</remarks>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignWithParentIfMissing
		/// 	</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_toLeftOf</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_toRightOf</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_above</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_below</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignBaseline</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignLeft</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignTop</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignRight</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignBottom</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignParentLeft</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignParentTop</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignParentRight</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_alignParentBottom</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_centerInParent</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_centerHorizontal</attr>
		/// <attr>ref android.R.styleable#RelativeLayout_Layout_layout_centerVertical</attr>
		public class LayoutParams : android.view.ViewGroup.MarginLayoutParams
		{
			internal int[] mRules = new int[VERB_COUNT];

			internal int mLeft;

			internal int mTop;

			internal int mRight;

			internal int mBottom;

			/// <summary>
			/// When true, uses the parent as the anchor if the anchor doesn't exist or if
			/// the anchor's visibility is GONE.
			/// </summary>
			/// <remarks>
			/// When true, uses the parent as the anchor if the anchor doesn't exist or if
			/// the anchor's visibility is GONE.
			/// </remarks>
			internal bool alignWithParent;

			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
				android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.RelativeLayout_Layout);
				int[] rules = mRules;
				int N = a.getIndexCount();
				{
					for (int i = 0; i < N; i++)
					{
						int attr = a.getIndex(i);
						switch (attr)
						{
							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignWithParentIfMissing
								:
							{
								alignWithParent = a.getBoolean(attr, false);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_toLeftOf:
							{
								rules[LEFT_OF] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_toRightOf:
							{
								rules[RIGHT_OF] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_above:
							{
								rules[ABOVE] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_below:
							{
								rules[BELOW] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignBaseline:
							{
								rules[ALIGN_BASELINE] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignLeft:
							{
								rules[ALIGN_LEFT] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignTop:
							{
								rules[ALIGN_TOP] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignRight:
							{
								rules[ALIGN_RIGHT] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignBottom:
							{
								rules[ALIGN_BOTTOM] = a.getResourceId(attr, 0);
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignParentLeft:
							{
								rules[ALIGN_PARENT_LEFT] = a.getBoolean(attr, false) ? TRUE : 0;
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignParentTop:
							{
								rules[ALIGN_PARENT_TOP] = a.getBoolean(attr, false) ? TRUE : 0;
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignParentRight:
							{
								rules[ALIGN_PARENT_RIGHT] = a.getBoolean(attr, false) ? TRUE : 0;
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_alignParentBottom
								:
							{
								rules[ALIGN_PARENT_BOTTOM] = a.getBoolean(attr, false) ? TRUE : 0;
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_centerInParent:
							{
								rules[CENTER_IN_PARENT] = a.getBoolean(attr, false) ? TRUE : 0;
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_centerHorizontal:
							{
								rules[CENTER_HORIZONTAL] = a.getBoolean(attr, false) ? TRUE : 0;
								break;
							}

							case android.@internal.R.styleable.RelativeLayout_Layout_layout_centerVertical:
							{
								rules[CENTER_VERTICAL] = a.getBoolean(attr, false) ? TRUE : 0;
								break;
							}
						}
					}
				}
				a.recycle();
			}

			public LayoutParams(int w, int h) : base(w, h)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.view.ViewGroup.LayoutParams source) : base(source)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.view.ViewGroup.MarginLayoutParams source) : base(source
				)
			{
			}

			[Sharpen.OverridesMethod(@"android.view.ViewGroup.LayoutParams")]
			public override string debug(string output)
			{
				return output + "ViewGroup.LayoutParams={ width=" + sizeToString(width) + ", height="
					 + sizeToString(height) + " }";
			}

			/// <summary>Adds a layout rule to be interpreted by the RelativeLayout.</summary>
			/// <remarks>
			/// Adds a layout rule to be interpreted by the RelativeLayout. This
			/// method should only be used for constraints that don't refer to another sibling
			/// (e.g., CENTER_IN_PARENT) or take a boolean value (
			/// <see cref="RelativeLayout.TRUE">RelativeLayout.TRUE</see>
			/// for true or - for false). To specify a verb that takes a subject, use
			/// <see cref="addRule(int, int)">addRule(int, int)</see>
			/// instead.
			/// </remarks>
			/// <param name="verb">
			/// One of the verbs defined by
			/// <see cref="RelativeLayout">RelativeLayout</see>
			/// , such as
			/// ALIGN_WITH_PARENT_LEFT.
			/// </param>
			/// <seealso cref="addRule(int, int)">addRule(int, int)</seealso>
			public virtual void addRule(int verb)
			{
				mRules[verb] = TRUE;
			}

			/// <summary>Adds a layout rule to be interpreted by the RelativeLayout.</summary>
			/// <remarks>
			/// Adds a layout rule to be interpreted by the RelativeLayout. Use this for
			/// verbs that take a target, such as a sibling (ALIGN_RIGHT) or a boolean
			/// value (VISIBLE).
			/// </remarks>
			/// <param name="verb">
			/// One of the verbs defined by
			/// <see cref="RelativeLayout">RelativeLayout</see>
			/// , such as
			/// ALIGN_WITH_PARENT_LEFT.
			/// </param>
			/// <param name="anchor">
			/// The id of another view to use as an anchor,
			/// or a boolean value(represented as
			/// <see cref="RelativeLayout.TRUE">RelativeLayout.TRUE</see>
			/// )
			/// for true or 0 for false).  For verbs that don't refer to another sibling
			/// (for example, ALIGN_WITH_PARENT_BOTTOM) just use -1.
			/// </param>
			/// <seealso cref="addRule(int)">addRule(int)</seealso>
			public virtual void addRule(int verb, int anchor)
			{
				mRules[verb] = anchor;
			}

			/// <summary>
			/// Retrieves a complete list of all supported rules, where the index is the rule
			/// verb, and the element value is the value specified, or "false" if it was never
			/// set.
			/// </summary>
			/// <remarks>
			/// Retrieves a complete list of all supported rules, where the index is the rule
			/// verb, and the element value is the value specified, or "false" if it was never
			/// set.
			/// </remarks>
			/// <returns>the supported rules</returns>
			/// <seealso cref="addRule(int, int)">addRule(int, int)</seealso>
			public virtual int[] getRules()
			{
				return mRules;
			}
		}

		private class DependencyGraph
		{
			/// <summary>List of all views in the graph.</summary>
			/// <remarks>List of all views in the graph.</remarks>
			internal java.util.ArrayList<android.widget.RelativeLayout.DependencyGraph.Node> 
				mNodes = new java.util.ArrayList<android.widget.RelativeLayout.DependencyGraph.Node
				>();

			/// <summary>List of nodes in the graph.</summary>
			/// <remarks>
			/// List of nodes in the graph. Each node is identified by its
			/// view id (see View#getId()).
			/// </remarks>
			internal android.util.SparseArray<android.widget.RelativeLayout.DependencyGraph.Node
				> mKeyNodes = new android.util.SparseArray<android.widget.RelativeLayout.DependencyGraph
				.Node>();

			/// <summary>
			/// Temporary data structure used to build the list of roots
			/// for this graph.
			/// </summary>
			/// <remarks>
			/// Temporary data structure used to build the list of roots
			/// for this graph.
			/// </remarks>
			internal java.util.LinkedList<android.widget.RelativeLayout.DependencyGraph.Node>
				 mRoots = new java.util.LinkedList<android.widget.RelativeLayout.DependencyGraph
				.Node>();

			/// <summary>Clears the graph.</summary>
			/// <remarks>Clears the graph.</remarks>
			internal virtual void clear()
			{
				java.util.ArrayList<android.widget.RelativeLayout.DependencyGraph.Node> nodes = mNodes;
				int count = nodes.size();
				{
					for (int i = 0; i < count; i++)
					{
						nodes.get(i).release();
					}
				}
				nodes.clear();
				mKeyNodes.clear();
				mRoots.clear();
			}

			/// <summary>Adds a view to the graph.</summary>
			/// <remarks>Adds a view to the graph.</remarks>
			/// <param name="view">The view to be added as a node to the graph.</param>
			internal virtual void add(android.view.View view)
			{
				int id = view.getId();
				android.widget.RelativeLayout.DependencyGraph.Node node = android.widget.RelativeLayout.DependencyGraph
					.Node.acquire(view);
				if (id != android.view.View.NO_ID)
				{
					mKeyNodes.put(id, node);
				}
				mNodes.add(node);
			}

			/// <summary>Builds a sorted list of views.</summary>
			/// <remarks>
			/// Builds a sorted list of views. The sorting order depends on the dependencies
			/// between the view. For instance, if view C needs view A to be processed first
			/// and view A needs view B to be processed first, the dependency graph
			/// is: B -&gt; A -&gt; C. The sorted array will contain views B, A and C in this order.
			/// </remarks>
			/// <param name="sorted">
			/// The sorted list of views. The length of this array must
			/// be equal to getChildCount().
			/// </param>
			/// <param name="rules">The list of rules to take into account.</param>
			internal virtual void getSortedViews(android.view.View[] sorted, params int[] rules
				)
			{
				java.util.LinkedList<android.widget.RelativeLayout.DependencyGraph.Node> roots = 
					findRoots(rules);
				int index = 0;
				while (roots.size() > 0)
				{
					android.widget.RelativeLayout.DependencyGraph.Node node = roots.removeFirst();
					android.view.View view = node.view;
					int key = view.getId();
					sorted[index++] = view;
					java.util.HashSet<android.widget.RelativeLayout.DependencyGraph.Node> dependents = 
						node.dependents;
					foreach (android.widget.RelativeLayout.DependencyGraph.Node dependent in Sharpen.IterableProxy.Create
						(dependents))
					{
						android.util.SparseArray<android.widget.RelativeLayout.DependencyGraph.Node> dependencies
							 = dependent.dependencies;
						dependencies.remove(key);
						if (dependencies.size() == 0)
						{
							roots.add(dependent);
						}
					}
				}
				if (index < sorted.Length)
				{
					throw new System.InvalidOperationException("Circular dependencies cannot exist" +
						 " in RelativeLayout");
				}
			}

			/// <summary>Finds the roots of the graph.</summary>
			/// <remarks>
			/// Finds the roots of the graph. A root is a node with no dependency and
			/// with [0..n] dependents.
			/// </remarks>
			/// <param name="rulesFilter">
			/// The list of rules to consider when building the
			/// dependencies
			/// </param>
			/// <returns>A list of node, each being a root of the graph</returns>
			internal java.util.LinkedList<android.widget.RelativeLayout.DependencyGraph.Node>
				 findRoots(int[] rulesFilter)
			{
				android.util.SparseArray<android.widget.RelativeLayout.DependencyGraph.Node> keyNodes
					 = mKeyNodes;
				java.util.ArrayList<android.widget.RelativeLayout.DependencyGraph.Node> nodes = mNodes;
				int count = nodes.size();
				{
					// Find roots can be invoked several times, so make sure to clear
					// all dependents and dependencies before running the algorithm
					for (int i = 0; i < count; i++)
					{
						android.widget.RelativeLayout.DependencyGraph.Node node = nodes.get(i);
						node.dependents.clear();
						node.dependencies.clear();
					}
				}
				{
					// Builds up the dependents and dependencies for each node of the graph
					for (int i_1 = 0; i_1 < count; i_1++)
					{
						android.widget.RelativeLayout.DependencyGraph.Node node = nodes.get(i_1);
						android.widget.RelativeLayout.LayoutParams layoutParams = (android.widget.RelativeLayout
							.LayoutParams)node.view.getLayoutParams();
						int[] rules = layoutParams.mRules;
						int rulesCount = rulesFilter.Length;
						{
							// Look only the the rules passed in parameter, this way we build only the
							// dependencies for a specific set of rules
							for (int j = 0; j < rulesCount; j++)
							{
								int rule = rules[rulesFilter[j]];
								if (rule > 0)
								{
									// The node this node depends on
									android.widget.RelativeLayout.DependencyGraph.Node dependency = keyNodes.get(rule
										);
									// Skip unknowns and self dependencies
									if (dependency == null || dependency == node)
									{
										continue;
									}
									// Add the current node as a dependent
									dependency.dependents.add(node);
									// Add a dependency to the current node
									node.dependencies.put(rule, dependency);
								}
							}
						}
					}
				}
				java.util.LinkedList<android.widget.RelativeLayout.DependencyGraph.Node> roots = 
					mRoots;
				roots.clear();
				{
					// Finds all the roots in the graph: all nodes with no dependencies
					for (int i_2 = 0; i_2 < count; i_2++)
					{
						android.widget.RelativeLayout.DependencyGraph.Node node = nodes.get(i_2);
						if (node.dependencies.size() == 0)
						{
							roots.add(node);
						}
					}
				}
				return roots;
			}

			/// <summary>Prints the dependency graph for the specified rules.</summary>
			/// <remarks>Prints the dependency graph for the specified rules.</remarks>
			/// <param name="resources">The context's resources to print the ids.</param>
			/// <param name="rules">The list of rules to take into account.</param>
			internal virtual void log(android.content.res.Resources resources, params int[] rules
				)
			{
				java.util.LinkedList<android.widget.RelativeLayout.DependencyGraph.Node> roots = 
					findRoots(rules);
				foreach (android.widget.RelativeLayout.DependencyGraph.Node node in Sharpen.IterableProxy.Create
					(roots))
				{
					printNode(resources, node);
				}
			}

			internal static void printViewId(android.content.res.Resources resources, android.view.View
				 view)
			{
				if (view.getId() != android.view.View.NO_ID)
				{
					android.util.Log.d(LOG_TAG, resources.getResourceEntryName(view.getId()));
				}
				else
				{
					android.util.Log.d(LOG_TAG, "NO_ID");
				}
			}

			internal static void appendViewId(android.content.res.Resources resources, android.widget.RelativeLayout.DependencyGraph
				.Node node, java.lang.StringBuilder buffer)
			{
				if (node.view.getId() != android.view.View.NO_ID)
				{
					buffer.append(resources.getResourceEntryName(node.view.getId()));
				}
				else
				{
					buffer.append("NO_ID");
				}
			}

			internal static void printNode(android.content.res.Resources resources, android.widget.RelativeLayout.DependencyGraph
				.Node node)
			{
				if (node.dependents.size() == 0)
				{
					printViewId(resources, node.view);
				}
				else
				{
					foreach (android.widget.RelativeLayout.DependencyGraph.Node dependent in Sharpen.IterableProxy.Create
						(node.dependents))
					{
						java.lang.StringBuilder buffer = new java.lang.StringBuilder();
						appendViewId(resources, node, buffer);
						printdependents(resources, dependent, buffer);
					}
				}
			}

			internal static void printdependents(android.content.res.Resources resources, android.widget.RelativeLayout.DependencyGraph
				.Node node, java.lang.StringBuilder buffer)
			{
				buffer.append(" -> ");
				appendViewId(resources, node, buffer);
				if (node.dependents.size() == 0)
				{
					android.util.Log.d(LOG_TAG, buffer.ToString());
				}
				else
				{
					foreach (android.widget.RelativeLayout.DependencyGraph.Node dependent in Sharpen.IterableProxy.Create
						(node.dependents))
					{
						java.lang.StringBuilder subBuffer = new java.lang.StringBuilder(buffer);
						printdependents(resources, dependent, subBuffer);
					}
				}
			}

			/// <summary>A node in the dependency graph.</summary>
			/// <remarks>
			/// A node in the dependency graph. A node is a view, its list of dependencies
			/// and its list of dependents.
			/// A node with no dependent is considered a root of the graph.
			/// </remarks>
			internal class Node : android.util.Poolable<android.widget.RelativeLayout.DependencyGraph
				.Node>
			{
				/// <summary>The view representing this node in the layout.</summary>
				/// <remarks>The view representing this node in the layout.</remarks>
				internal android.view.View view;

				/// <summary>
				/// The list of dependents for this node; a dependent is a node
				/// that needs this node to be processed first.
				/// </summary>
				/// <remarks>
				/// The list of dependents for this node; a dependent is a node
				/// that needs this node to be processed first.
				/// </remarks>
				internal readonly java.util.HashSet<android.widget.RelativeLayout.DependencyGraph
					.Node> dependents = new java.util.HashSet<android.widget.RelativeLayout.DependencyGraph
					.Node>();

				/// <summary>The list of dependencies for this node.</summary>
				/// <remarks>The list of dependencies for this node.</remarks>
				internal readonly android.util.SparseArray<android.widget.RelativeLayout.DependencyGraph
					.Node> dependencies = new android.util.SparseArray<android.widget.RelativeLayout.DependencyGraph
					.Node>();

				internal const int POOL_LIMIT = 100;

				private sealed class _PoolableManager_1437 : android.util.PoolableManager<android.widget.RelativeLayout.DependencyGraph
					.Node>
				{
					public _PoolableManager_1437()
					{
					}

					// The pool is static, so all nodes instances are shared across
					// activities, that's why we give it a rather high limit
					[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
					public android.widget.RelativeLayout.DependencyGraph.Node newInstance()
					{
						return new android.widget.RelativeLayout.DependencyGraph.Node();
					}

					[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
					public void onAcquired(android.widget.RelativeLayout.DependencyGraph.Node element
						)
					{
					}

					[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
					public void onReleased(android.widget.RelativeLayout.DependencyGraph.Node element
						)
					{
					}
				}

				private static readonly android.util.Pool<android.widget.RelativeLayout.DependencyGraph
					.Node> sPool = android.util.Pools.synchronizedPool<android.widget.RelativeLayout.DependencyGraph
					.Node>(android.util.Pools.finitePool<android.widget.RelativeLayout.DependencyGraph
					.Node>(new _PoolableManager_1437(), POOL_LIMIT));

				private android.widget.RelativeLayout.DependencyGraph.Node mNext;

				private bool mIsPooled;

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual void setNextPoolable(android.widget.RelativeLayout.DependencyGraph
					.Node element)
				{
					mNext = element;
				}

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual android.widget.RelativeLayout.DependencyGraph.Node getNextPoolable
					()
				{
					return mNext;
				}

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual bool isPooled()
				{
					return mIsPooled;
				}

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual void setPooled(bool isPooled_1)
				{
					mIsPooled = isPooled_1;
				}

				internal static android.widget.RelativeLayout.DependencyGraph.Node acquire(android.view.View
					 view)
				{
					android.widget.RelativeLayout.DependencyGraph.Node node = sPool.acquire();
					node.view = view;
					return node;
				}

				internal virtual void release()
				{
					view = null;
					dependents.clear();
					dependencies.clear();
					sPool.release(this);
				}
			}
		}
	}
}
