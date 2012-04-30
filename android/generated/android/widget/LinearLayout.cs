using Sharpen;

namespace android.widget
{
	/// <summary>A Layout that arranges its children in a single column or a single row.</summary>
	/// <remarks>
	/// A Layout that arranges its children in a single column or a single row. The direction of
	/// the row can be set by calling
	/// <see cref="setOrientation(int)">setOrientation()</see>
	/// .
	/// You can also specify gravity, which specifies the alignment of all the child elements by
	/// calling
	/// <see cref="setGravity(int)">setGravity()</see>
	/// or specify that specific children
	/// grow to fill up any remaining space in the layout by setting the <em>weight</em> member of
	/// <see cref="LayoutParams">LinearLayout.LayoutParams</see>
	/// .
	/// The default orientation is horizontal.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-linearlayout.html"&gt;Linear Layout
	/// tutorial</a>.</p>
	/// <p>
	/// Also see
	/// <see cref="LayoutParams">android.widget.LinearLayout.LayoutParams</see>
	/// for layout attributes </p>
	/// </remarks>
	/// <attr>ref android.R.styleable#LinearLayout_baselineAligned</attr>
	/// <attr>ref android.R.styleable#LinearLayout_baselineAlignedChildIndex</attr>
	/// <attr>ref android.R.styleable#LinearLayout_gravity</attr>
	/// <attr>ref android.R.styleable#LinearLayout_measureWithLargestChild</attr>
	/// <attr>ref android.R.styleable#LinearLayout_orientation</attr>
	/// <attr>ref android.R.styleable#LinearLayout_weightSum</attr>
	[Sharpen.Sharpened]
	public class LinearLayout : android.view.ViewGroup
	{
		public const int HORIZONTAL = 0;

		public const int VERTICAL = 1;

		/// <summary>Don't show any dividers.</summary>
		/// <remarks>Don't show any dividers.</remarks>
		public const int SHOW_DIVIDER_NONE = 0;

		/// <summary>Show a divider at the beginning of the group.</summary>
		/// <remarks>Show a divider at the beginning of the group.</remarks>
		public const int SHOW_DIVIDER_BEGINNING = 1;

		/// <summary>Show dividers between each item in the group.</summary>
		/// <remarks>Show dividers between each item in the group.</remarks>
		public const int SHOW_DIVIDER_MIDDLE = 2;

		/// <summary>Show a divider at the end of the group.</summary>
		/// <remarks>Show a divider at the end of the group.</remarks>
		public const int SHOW_DIVIDER_END = 4;

		/// <summary>Whether the children of this layout are baseline aligned.</summary>
		/// <remarks>
		/// Whether the children of this layout are baseline aligned.  Only applicable
		/// if
		/// <see cref="mOrientation">mOrientation</see>
		/// is horizontal.
		/// </remarks>
		private bool mBaselineAligned = true;

		/// <summary>
		/// If this layout is part of another layout that is baseline aligned,
		/// use the child at this index as the baseline.
		/// </summary>
		/// <remarks>
		/// If this layout is part of another layout that is baseline aligned,
		/// use the child at this index as the baseline.
		/// Note: this is orthogonal to
		/// <see cref="mBaselineAligned">mBaselineAligned</see>
		/// , which is concerned
		/// with whether the children of this layout are baseline aligned.
		/// </remarks>
		private int mBaselineAlignedChildIndex = -1;

		/// <summary>The additional offset to the child's baseline.</summary>
		/// <remarks>
		/// The additional offset to the child's baseline.
		/// We'll calculate the baseline of this layout as we measure vertically; for
		/// horizontal linear layouts, the offset of 0 is appropriate.
		/// </remarks>
		private int mBaselineChildTop = 0;

		private int mOrientation;

		private int mGravity = android.view.Gravity.START | android.view.Gravity.TOP;

		private int mTotalLength;

		private float mWeightSum;

		private bool mUseLargestChild;

		private int[] mMaxAscent;

		private int[] mMaxDescent;

		internal const int VERTICAL_GRAVITY_COUNT = 4;

		internal const int INDEX_CENTER_VERTICAL = 0;

		internal const int INDEX_TOP = 1;

		internal const int INDEX_BOTTOM = 2;

		internal const int INDEX_FILL = 3;

		private android.graphics.drawable.Drawable mDivider;

		private int mDividerWidth;

		private int mDividerHeight;

		private int mShowDividers;

		private int mDividerPadding;

		public LinearLayout(android.content.Context context) : base(context)
		{
		}

		public LinearLayout(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
		}

		public LinearLayout(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.LinearLayout, defStyle, 0);
			int index = a.getInt(android.@internal.R.styleable.LinearLayout_orientation, -1);
			if (index >= 0)
			{
				setOrientation(index);
			}
			index = a.getInt(android.@internal.R.styleable.LinearLayout_gravity, -1);
			if (index >= 0)
			{
				setGravity(index);
			}
			bool baselineAligned = a.getBoolean(android.@internal.R.styleable.LinearLayout_baselineAligned
				, true);
			if (!baselineAligned)
			{
				setBaselineAligned(baselineAligned);
			}
			mWeightSum = a.getFloat(android.@internal.R.styleable.LinearLayout_weightSum, -1.0f
				);
			mBaselineAlignedChildIndex = a.getInt(android.@internal.R.styleable.LinearLayout_baselineAlignedChildIndex
				, -1);
			mUseLargestChild = a.getBoolean(android.@internal.R.styleable.LinearLayout_measureWithLargestChild
				, false);
			setDividerDrawable(a.getDrawable(android.@internal.R.styleable.LinearLayout_divider
				));
			mShowDividers = a.getInt(android.@internal.R.styleable.LinearLayout_showDividers, 
				SHOW_DIVIDER_NONE);
			mDividerPadding = a.getDimensionPixelSize(android.@internal.R.styleable.LinearLayout_dividerPadding
				, 0);
			a.recycle();
		}

		/// <summary>Set how dividers should be shown between items in this layout</summary>
		/// <param name="showDividers">
		/// One or more of
		/// <see cref="SHOW_DIVIDER_BEGINNING">SHOW_DIVIDER_BEGINNING</see>
		/// ,
		/// <see cref="SHOW_DIVIDER_MIDDLE">SHOW_DIVIDER_MIDDLE</see>
		/// , or
		/// <see cref="SHOW_DIVIDER_END">SHOW_DIVIDER_END</see>
		/// ,
		/// or
		/// <see cref="SHOW_DIVIDER_NONE">SHOW_DIVIDER_NONE</see>
		/// to show no dividers.
		/// </param>
		public virtual void setShowDividers(int showDividers)
		{
			if (showDividers != mShowDividers)
			{
				requestLayout();
			}
			mShowDividers = showDividers;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool shouldDelayChildPressedState()
		{
			return false;
		}

		/// <returns>A flag set indicating how dividers should be shown around items.</returns>
		/// <seealso cref="setShowDividers(int)">setShowDividers(int)</seealso>
		public virtual int getShowDividers()
		{
			return mShowDividers;
		}

		/// <summary>Set a drawable to be used as a divider between items.</summary>
		/// <remarks>Set a drawable to be used as a divider between items.</remarks>
		/// <param name="divider">Drawable that will divide each item.</param>
		/// <seealso cref="setShowDividers(int)">setShowDividers(int)</seealso>
		public virtual void setDividerDrawable(android.graphics.drawable.Drawable divider
			)
		{
			if (divider == mDivider)
			{
				return;
			}
			mDivider = divider;
			if (divider != null)
			{
				mDividerWidth = divider.getIntrinsicWidth();
				mDividerHeight = divider.getIntrinsicHeight();
			}
			else
			{
				mDividerWidth = 0;
				mDividerHeight = 0;
			}
			setWillNotDraw(divider == null);
			requestLayout();
		}

		/// <summary>Set padding displayed on both ends of dividers.</summary>
		/// <remarks>Set padding displayed on both ends of dividers.</remarks>
		/// <param name="padding">Padding value in pixels that will be applied to each end</param>
		/// <seealso cref="setShowDividers(int)">setShowDividers(int)</seealso>
		/// <seealso cref="setDividerDrawable(android.graphics.drawable.Drawable)">setDividerDrawable(android.graphics.drawable.Drawable)
		/// 	</seealso>
		/// <seealso cref="getDividerPadding()">getDividerPadding()</seealso>
		public virtual void setDividerPadding(int padding)
		{
			mDividerPadding = padding;
		}

		/// <summary>Get the padding size used to inset dividers in pixels</summary>
		/// <seealso cref="setShowDividers(int)">setShowDividers(int)</seealso>
		/// <seealso cref="setDividerDrawable(android.graphics.drawable.Drawable)">setDividerDrawable(android.graphics.drawable.Drawable)
		/// 	</seealso>
		/// <seealso cref="setDividerPadding(int)">setDividerPadding(int)</seealso>
		public virtual int getDividerPadding()
		{
			return mDividerPadding;
		}

		/// <summary>Get the width of the current divider drawable.</summary>
		/// <remarks>Get the width of the current divider drawable.</remarks>
		/// <hide>Used internally by framework.</hide>
		public virtual int getDividerWidth()
		{
			return mDividerWidth;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			if (mDivider == null)
			{
				return;
			}
			if (mOrientation == VERTICAL)
			{
				drawDividersVertical(canvas);
			}
			else
			{
				drawDividersHorizontal(canvas);
			}
		}

		internal virtual void drawDividersVertical(android.graphics.Canvas canvas)
		{
			int count = getVirtualChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child != null && child.getVisibility() != GONE)
					{
						if (hasDividerBeforeChildAt(i))
						{
							android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
								)child.getLayoutParams();
							int top = child.getTop() - lp.topMargin;
							drawHorizontalDivider(canvas, top);
						}
					}
				}
			}
			if (hasDividerBeforeChildAt(count))
			{
				android.view.View child = getVirtualChildAt(count - 1);
				int bottom = 0;
				if (child == null)
				{
					bottom = getHeight() - getPaddingBottom() - mDividerHeight;
				}
				else
				{
					android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
						)child.getLayoutParams();
					bottom = child.getBottom() + lp.bottomMargin;
				}
				drawHorizontalDivider(canvas, bottom);
			}
		}

		internal virtual void drawDividersHorizontal(android.graphics.Canvas canvas)
		{
			int count = getVirtualChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child != null && child.getVisibility() != GONE)
					{
						if (hasDividerBeforeChildAt(i))
						{
							android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
								)child.getLayoutParams();
							int left = child.getLeft() - lp.leftMargin;
							drawVerticalDivider(canvas, left);
						}
					}
				}
			}
			if (hasDividerBeforeChildAt(count))
			{
				android.view.View child = getVirtualChildAt(count - 1);
				int right = 0;
				if (child == null)
				{
					right = getWidth() - getPaddingRight() - mDividerWidth;
				}
				else
				{
					android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
						)child.getLayoutParams();
					right = child.getRight() + lp.rightMargin;
				}
				drawVerticalDivider(canvas, right);
			}
		}

		internal virtual void drawHorizontalDivider(android.graphics.Canvas canvas, int top
			)
		{
			mDivider.setBounds(getPaddingLeft() + mDividerPadding, top, getWidth() - getPaddingRight
				() - mDividerPadding, top + mDividerHeight);
			mDivider.draw(canvas);
		}

		internal virtual void drawVerticalDivider(android.graphics.Canvas canvas, int left
			)
		{
			mDivider.setBounds(left, getPaddingTop() + mDividerPadding, left + mDividerWidth, 
				getHeight() - getPaddingBottom() - mDividerPadding);
			mDivider.draw(canvas);
		}

		/// <summary>
		/// <p>Indicates whether widgets contained within this layout are aligned
		/// on their baseline or not.</p>
		/// </summary>
		/// <returns>true when widgets are baseline-aligned, false otherwise</returns>
		public virtual bool isBaselineAligned()
		{
			return mBaselineAligned;
		}

		/// <summary>
		/// <p>Defines whether widgets contained in this layout are
		/// baseline-aligned or not.</p>
		/// </summary>
		/// <param name="baselineAligned">
		/// true to align widgets on their baseline,
		/// false otherwise
		/// </param>
		/// <attr>ref android.R.styleable#LinearLayout_baselineAligned</attr>
		[android.view.RemotableViewMethod]
		public virtual void setBaselineAligned(bool baselineAligned)
		{
			mBaselineAligned = baselineAligned;
		}

		/// <summary>
		/// When true, all children with a weight will be considered having
		/// the minimum size of the largest child.
		/// </summary>
		/// <remarks>
		/// When true, all children with a weight will be considered having
		/// the minimum size of the largest child. If false, all children are
		/// measured normally.
		/// </remarks>
		/// <returns>
		/// True to measure children with a weight using the minimum
		/// size of the largest child, false otherwise.
		/// </returns>
		public virtual bool isMeasureWithLargestChildEnabled()
		{
			return mUseLargestChild;
		}

		/// <summary>
		/// When set to true, all children with a weight will be considered having
		/// the minimum size of the largest child.
		/// </summary>
		/// <remarks>
		/// When set to true, all children with a weight will be considered having
		/// the minimum size of the largest child. If false, all children are
		/// measured normally.
		/// Disabled by default.
		/// </remarks>
		/// <param name="enabled">
		/// True to measure children with a weight using the
		/// minimum size of the largest child, false otherwise.
		/// </param>
		[android.view.RemotableViewMethod]
		public virtual void setMeasureWithLargestChildEnabled(bool enabled)
		{
			mUseLargestChild = enabled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			if (mBaselineAlignedChildIndex < 0)
			{
				return base.getBaseline();
			}
			if (getChildCount() <= mBaselineAlignedChildIndex)
			{
				throw new java.lang.RuntimeException("mBaselineAlignedChildIndex of LinearLayout "
					 + "set to an index that is out of bounds.");
			}
			android.view.View child = getChildAt(mBaselineAlignedChildIndex);
			int childBaseline = child.getBaseline();
			if (childBaseline == -1)
			{
				if (mBaselineAlignedChildIndex == 0)
				{
					// this is just the default case, safe to return -1
					return -1;
				}
				// the user picked an index that points to something that doesn't
				// know how to calculate its baseline.
				throw new java.lang.RuntimeException("mBaselineAlignedChildIndex of LinearLayout "
					 + "points to a View that doesn't know how to get its baseline.");
			}
			// TODO: This should try to take into account the virtual offsets
			// (See getNextLocationOffset and getLocationOffset)
			// We should add to childTop:
			// sum([getNextLocationOffset(getChildAt(i)) / i < mBaselineAlignedChildIndex])
			// and also add:
			// getLocationOffset(child)
			int childTop = mBaselineChildTop;
			if (mOrientation == VERTICAL)
			{
				int majorGravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
				if (majorGravity != android.view.Gravity.TOP)
				{
					switch (majorGravity)
					{
						case android.view.Gravity.BOTTOM:
						{
							childTop = mBottom - mTop - mPaddingBottom - mTotalLength;
							break;
						}

						case android.view.Gravity.CENTER_VERTICAL:
						{
							childTop += ((mBottom - mTop - mPaddingTop - mPaddingBottom) - mTotalLength) / 2;
							break;
						}
					}
				}
			}
			android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
				)child.getLayoutParams();
			return childTop + lp.topMargin + childBaseline;
		}

		/// <returns>
		/// The index of the child that will be used if this layout is
		/// part of a larger layout that is baseline aligned, or -1 if none has
		/// been set.
		/// </returns>
		public virtual int getBaselineAlignedChildIndex()
		{
			return mBaselineAlignedChildIndex;
		}

		/// <param name="i">
		/// The index of the child that will be used if this layout is
		/// part of a larger layout that is baseline aligned.
		/// </param>
		/// <attr>ref android.R.styleable#LinearLayout_baselineAlignedChildIndex</attr>
		[android.view.RemotableViewMethod]
		public virtual void setBaselineAlignedChildIndex(int i)
		{
			if ((i < 0) || (i >= getChildCount()))
			{
				throw new System.ArgumentException("base aligned child index out " + "of range (0, "
					 + getChildCount() + ")");
			}
			mBaselineAlignedChildIndex = i;
		}

		/// <summary><p>Returns the view at the specified index.</summary>
		/// <remarks>
		/// <p>Returns the view at the specified index. This method can be overriden
		/// to take into account virtual children. Refer to
		/// <see cref="TableLayout">TableLayout</see>
		/// and
		/// <see cref="TableRow">TableRow</see>
		/// for an example.</p>
		/// </remarks>
		/// <param name="index">the child's index</param>
		/// <returns>the child at the specified index</returns>
		internal virtual android.view.View getVirtualChildAt(int index)
		{
			return getChildAt(index);
		}

		/// <summary><p>Returns the virtual number of children.</summary>
		/// <remarks>
		/// <p>Returns the virtual number of children. This number might be different
		/// than the actual number of children if the layout can hold virtual
		/// children. Refer to
		/// <see cref="TableLayout">TableLayout</see>
		/// and
		/// <see cref="TableRow">TableRow</see>
		/// for an example.</p>
		/// </remarks>
		/// <returns>the virtual number of children</returns>
		internal virtual int getVirtualChildCount()
		{
			return getChildCount();
		}

		/// <summary>Returns the desired weights sum.</summary>
		/// <remarks>Returns the desired weights sum.</remarks>
		/// <returns>
		/// A number greater than 0.0f if the weight sum is defined, or
		/// a number lower than or equals to 0.0f if not weight sum is
		/// to be used.
		/// </returns>
		public virtual float getWeightSum()
		{
			return mWeightSum;
		}

		/// <summary>Defines the desired weights sum.</summary>
		/// <remarks>
		/// Defines the desired weights sum. If unspecified the weights sum is computed
		/// at layout time by adding the layout_weight of each child.
		/// This can be used for instance to give a single child 50% of the total
		/// available space by giving it a layout_weight of 0.5 and setting the
		/// weightSum to 1.0.
		/// </remarks>
		/// <param name="weightSum">
		/// a number greater than 0.0f, or a number lower than or equals
		/// to 0.0f if the weight sum should be computed from the children's
		/// layout_weight
		/// </param>
		[android.view.RemotableViewMethod]
		public virtual void setWeightSum(float weightSum)
		{
			mWeightSum = System.Math.Max(0.0f, weightSum);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			if (mOrientation == VERTICAL)
			{
				measureVertical(widthMeasureSpec, heightMeasureSpec);
			}
			else
			{
				measureHorizontal(widthMeasureSpec, heightMeasureSpec);
			}
		}

		/// <summary>Determines where to position dividers between children.</summary>
		/// <remarks>Determines where to position dividers between children.</remarks>
		/// <param name="childIndex">Index of child to check for preceding divider</param>
		/// <returns>true if there should be a divider before the child at childIndex</returns>
		/// <hide>Pending API consideration. Currently only used internally by the system.</hide>
		protected internal virtual bool hasDividerBeforeChildAt(int childIndex)
		{
			if (childIndex == 0)
			{
				return (mShowDividers & SHOW_DIVIDER_BEGINNING) != 0;
			}
			else
			{
				if (childIndex == getChildCount())
				{
					return (mShowDividers & SHOW_DIVIDER_END) != 0;
				}
				else
				{
					if ((mShowDividers & SHOW_DIVIDER_MIDDLE) != 0)
					{
						bool hasVisibleViewBefore = false;
						{
							for (int i = childIndex - 1; i >= 0; i--)
							{
								if (getChildAt(i).getVisibility() != GONE)
								{
									hasVisibleViewBefore = true;
									break;
								}
							}
						}
						return hasVisibleViewBefore;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Measures the children when the orientation of this LinearLayout is set
		/// to
		/// <see cref="VERTICAL">VERTICAL</see>
		/// .
		/// </summary>
		/// <param name="widthMeasureSpec">Horizontal space requirements as imposed by the parent.
		/// 	</param>
		/// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.
		/// 	</param>
		/// <seealso cref="getOrientation()">getOrientation()</seealso>
		/// <seealso cref="setOrientation(int)">setOrientation(int)</seealso>
		/// <seealso cref="onMeasure(int, int)">onMeasure(int, int)</seealso>
		internal virtual void measureVertical(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			mTotalLength = 0;
			int maxWidth = 0;
			int childState = 0;
			int alternativeMaxWidth = 0;
			int weightedMaxWidth = 0;
			bool allFillParent = true;
			float totalWeight = 0;
			int count = getVirtualChildCount();
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			bool matchWidth = false;
			int baselineChildIndex = mBaselineAlignedChildIndex;
			bool useLargestChild = mUseLargestChild;
			int largestChildHeight = int.MinValue;
			{
				// See how tall everyone is. Also remember max width.
				for (int i = 0; i < count; ++i)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child == null)
					{
						mTotalLength += measureNullChild(i);
						continue;
					}
					if (child.getVisibility() == android.view.View.GONE)
					{
						i += getChildrenSkipCount(child, i);
						continue;
					}
					if (hasDividerBeforeChildAt(i))
					{
						mTotalLength += mDividerHeight;
					}
					android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
						)child.getLayoutParams();
					totalWeight += lp.weight;
					if (heightMode == android.view.View.MeasureSpec.EXACTLY && lp.height == 0 && lp.weight
						 > 0)
					{
						// Optimization: don't bother measuring children who are going to use
						// leftover space. These views will get measured again down below if
						// there is any leftover space.
						int totalLength = mTotalLength;
						mTotalLength = System.Math.Max(totalLength, totalLength + lp.topMargin + lp.bottomMargin
							);
					}
					else
					{
						int oldHeight = int.MinValue;
						if (lp.height == 0 && lp.weight > 0)
						{
							// heightMode is either UNSPECIFIED or AT_MOST, and this
							// child wanted to stretch to fill available space.
							// Translate that to WRAP_CONTENT so that it does not end up
							// with a height of 0
							oldHeight = 0;
							lp.height = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
						}
						// Determine how big this child would like to be. If this or
						// previous children have given a weight, then we allow it to
						// use all available space (and we will shrink things later
						// if needed).
						measureChildBeforeLayout(child, i, widthMeasureSpec, 0, heightMeasureSpec, totalWeight
							 == 0 ? mTotalLength : 0);
						if (oldHeight != int.MinValue)
						{
							lp.height = oldHeight;
						}
						int childHeight = child.getMeasuredHeight();
						int totalLength = mTotalLength;
						mTotalLength = System.Math.Max(totalLength, totalLength + childHeight + lp.topMargin
							 + lp.bottomMargin + getNextLocationOffset(child));
						if (useLargestChild)
						{
							largestChildHeight = System.Math.Max(childHeight, largestChildHeight);
						}
					}
					if ((baselineChildIndex >= 0) && (baselineChildIndex == i + 1))
					{
						mBaselineChildTop = mTotalLength;
					}
					// if we are trying to use a child index for our baseline, the above
					// book keeping only works if there are no children above it with
					// weight.  fail fast to aid the developer.
					if (i < baselineChildIndex && lp.weight > 0)
					{
						throw new java.lang.RuntimeException("A child of LinearLayout with index " + "less than mBaselineAlignedChildIndex has weight > 0, which "
							 + "won't work.  Either remove the weight, or don't set " + "mBaselineAlignedChildIndex."
							);
					}
					bool matchWidthLocally = false;
					if (widthMode != android.view.View.MeasureSpec.EXACTLY && lp.width == android.view.ViewGroup
						.LayoutParams.MATCH_PARENT)
					{
						// The width of the linear layout will scale, and at least one
						// child said it wanted to match our width. Set a flag
						// indicating that we need to remeasure at least that view when
						// we know our width.
						matchWidth = true;
						matchWidthLocally = true;
					}
					int margin = lp.leftMargin + lp.rightMargin;
					int measuredWidth = child.getMeasuredWidth() + margin;
					maxWidth = System.Math.Max(maxWidth, measuredWidth);
					childState = combineMeasuredStates(childState, child.getMeasuredState());
					allFillParent = allFillParent && lp.width == android.view.ViewGroup.LayoutParams.
						MATCH_PARENT;
					if (lp.weight > 0)
					{
						weightedMaxWidth = System.Math.Max(weightedMaxWidth, matchWidthLocally ? margin : 
							measuredWidth);
					}
					else
					{
						alternativeMaxWidth = System.Math.Max(alternativeMaxWidth, matchWidthLocally ? margin
							 : measuredWidth);
					}
					i += getChildrenSkipCount(child, i);
				}
			}
			if (mTotalLength > 0 && hasDividerBeforeChildAt(count))
			{
				mTotalLength += mDividerHeight;
			}
			if (useLargestChild && (heightMode == android.view.View.MeasureSpec.AT_MOST || heightMode
				 == android.view.View.MeasureSpec.UNSPECIFIED))
			{
				mTotalLength = 0;
				{
					for (int i_1 = 0; i_1 < count; ++i_1)
					{
						android.view.View child = getVirtualChildAt(i_1);
						if (child == null)
						{
							mTotalLength += measureNullChild(i_1);
							continue;
						}
						if (child.getVisibility() == GONE)
						{
							i_1 += getChildrenSkipCount(child, i_1);
							continue;
						}
						android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
							)child.getLayoutParams();
						// Account for negative margins
						int totalLength = mTotalLength;
						mTotalLength = System.Math.Max(totalLength, totalLength + largestChildHeight + lp
							.topMargin + lp.bottomMargin + getNextLocationOffset(child));
					}
				}
			}
			// Add in our padding
			mTotalLength += mPaddingTop + mPaddingBottom;
			int heightSize = mTotalLength;
			// Check against our minimum height
			heightSize = System.Math.Max(heightSize, getSuggestedMinimumHeight());
			// Reconcile our calculated size with the heightMeasureSpec
			int heightSizeAndState = resolveSizeAndState(heightSize, heightMeasureSpec, 0);
			heightSize = heightSizeAndState & MEASURED_SIZE_MASK;
			// Either expand children with weight to take up available space or
			// shrink them if they extend beyond our current bounds
			int delta = heightSize - mTotalLength;
			if (delta != 0 && totalWeight > 0.0f)
			{
				float weightSum = mWeightSum > 0.0f ? mWeightSum : totalWeight;
				mTotalLength = 0;
				{
					for (int i_1 = 0; i_1 < count; ++i_1)
					{
						android.view.View child = getVirtualChildAt(i_1);
						if (child.getVisibility() == android.view.View.GONE)
						{
							continue;
						}
						android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
							)child.getLayoutParams();
						float childExtra = lp.weight;
						if (childExtra > 0)
						{
							// Child said it could absorb extra space -- give him his share
							int share = (int)(childExtra * delta / weightSum);
							weightSum -= childExtra;
							delta -= share;
							int childWidthMeasureSpec = getChildMeasureSpec(widthMeasureSpec, mPaddingLeft + 
								mPaddingRight + lp.leftMargin + lp.rightMargin, lp.width);
							// TODO: Use a field like lp.isMeasured to figure out if this
							// child has been previously measured
							if ((lp.height != 0) || (heightMode != android.view.View.MeasureSpec.EXACTLY))
							{
								// child was measured once already above...
								// base new measurement on stored values
								int childHeight = child.getMeasuredHeight() + share;
								if (childHeight < 0)
								{
									childHeight = 0;
								}
								child.measure(childWidthMeasureSpec, android.view.View.MeasureSpec.makeMeasureSpec
									(childHeight, android.view.View.MeasureSpec.EXACTLY));
							}
							else
							{
								// child was skipped in the loop above.
								// Measure for this first time here      
								child.measure(childWidthMeasureSpec, android.view.View.MeasureSpec.makeMeasureSpec
									(share > 0 ? share : 0, android.view.View.MeasureSpec.EXACTLY));
							}
							// Child may now not fit in vertical dimension.
							childState = combineMeasuredStates(childState, child.getMeasuredState() & (MEASURED_STATE_MASK
								 >> MEASURED_HEIGHT_STATE_SHIFT));
						}
						int margin = lp.leftMargin + lp.rightMargin;
						int measuredWidth = child.getMeasuredWidth() + margin;
						maxWidth = System.Math.Max(maxWidth, measuredWidth);
						bool matchWidthLocally = widthMode != android.view.View.MeasureSpec.EXACTLY && lp
							.width == android.view.ViewGroup.LayoutParams.MATCH_PARENT;
						alternativeMaxWidth = System.Math.Max(alternativeMaxWidth, matchWidthLocally ? margin
							 : measuredWidth);
						allFillParent = allFillParent && lp.width == android.view.ViewGroup.LayoutParams.
							MATCH_PARENT;
						int totalLength = mTotalLength;
						mTotalLength = System.Math.Max(totalLength, totalLength + child.getMeasuredHeight
							() + lp.topMargin + lp.bottomMargin + getNextLocationOffset(child));
					}
				}
				// Add in our padding
				mTotalLength += mPaddingTop + mPaddingBottom;
			}
			else
			{
				// TODO: Should we recompute the heightSpec based on the new total length?
				alternativeMaxWidth = System.Math.Max(alternativeMaxWidth, weightedMaxWidth);
				// We have no limit, so make all weighted views as tall as the largest child.
				// Children will have already been measured once.
				if (useLargestChild && widthMode == android.view.View.MeasureSpec.UNSPECIFIED)
				{
					{
						for (int i_1 = 0; i_1 < count; i_1++)
						{
							android.view.View child = getVirtualChildAt(i_1);
							if (child == null || child.getVisibility() == android.view.View.GONE)
							{
								continue;
							}
							android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
								)child.getLayoutParams();
							float childExtra = lp.weight;
							if (childExtra > 0)
							{
								child.measure(android.view.View.MeasureSpec.makeMeasureSpec(child.getMeasuredWidth
									(), android.view.View.MeasureSpec.EXACTLY), android.view.View.MeasureSpec.makeMeasureSpec
									(largestChildHeight, android.view.View.MeasureSpec.EXACTLY));
							}
						}
					}
				}
			}
			if (!allFillParent && widthMode != android.view.View.MeasureSpec.EXACTLY)
			{
				maxWidth = alternativeMaxWidth;
			}
			maxWidth += mPaddingLeft + mPaddingRight;
			// Check against our minimum width
			maxWidth = System.Math.Max(maxWidth, getSuggestedMinimumWidth());
			setMeasuredDimension(resolveSizeAndState(maxWidth, widthMeasureSpec, childState), 
				heightSizeAndState);
			if (matchWidth)
			{
				forceUniformWidth(count, heightMeasureSpec);
			}
		}

		private void forceUniformWidth(int count, int heightMeasureSpec)
		{
			// Pretend that the linear layout has an exact size.
			int uniformMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(getMeasuredWidth
				(), android.view.View.MeasureSpec.EXACTLY);
			{
				for (int i = 0; i < count; ++i)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child.getVisibility() != GONE)
					{
						android.widget.LinearLayout.LayoutParams lp = ((android.widget.LinearLayout.LayoutParams
							)child.getLayoutParams());
						if (lp.width == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
						{
							// Temporarily force children to reuse their old measured height
							// FIXME: this may not be right for something like wrapping text?
							int oldHeight = lp.height;
							lp.height = child.getMeasuredHeight();
							// Remeasue with new dimensions
							measureChildWithMargins(child, uniformMeasureSpec, 0, heightMeasureSpec, 0);
							lp.height = oldHeight;
						}
					}
				}
			}
		}

		/// <summary>
		/// Measures the children when the orientation of this LinearLayout is set
		/// to
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// .
		/// </summary>
		/// <param name="widthMeasureSpec">Horizontal space requirements as imposed by the parent.
		/// 	</param>
		/// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.
		/// 	</param>
		/// <seealso cref="getOrientation()">getOrientation()</seealso>
		/// <seealso cref="setOrientation(int)">setOrientation(int)</seealso>
		/// <seealso cref="onMeasure(int, int)"></seealso>
		internal virtual void measureHorizontal(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			mTotalLength = 0;
			int maxHeight = 0;
			int childState = 0;
			int alternativeMaxHeight = 0;
			int weightedMaxHeight = 0;
			bool allFillParent = true;
			float totalWeight = 0;
			int count = getVirtualChildCount();
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			bool matchHeight = false;
			if (mMaxAscent == null || mMaxDescent == null)
			{
				mMaxAscent = new int[VERTICAL_GRAVITY_COUNT];
				mMaxDescent = new int[VERTICAL_GRAVITY_COUNT];
			}
			int[] maxAscent = mMaxAscent;
			int[] maxDescent = mMaxDescent;
			maxAscent[0] = maxAscent[1] = maxAscent[2] = maxAscent[3] = -1;
			maxDescent[0] = maxDescent[1] = maxDescent[2] = maxDescent[3] = -1;
			bool baselineAligned = mBaselineAligned;
			bool useLargestChild = mUseLargestChild;
			bool isExactly = widthMode == android.view.View.MeasureSpec.EXACTLY;
			int largestChildWidth = int.MinValue;
			{
				// See how wide everyone is. Also remember max height.
				for (int i = 0; i < count; ++i)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child == null)
					{
						mTotalLength += measureNullChild(i);
						continue;
					}
					if (child.getVisibility() == GONE)
					{
						i += getChildrenSkipCount(child, i);
						continue;
					}
					if (hasDividerBeforeChildAt(i))
					{
						mTotalLength += mDividerWidth;
					}
					android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
						)child.getLayoutParams();
					totalWeight += lp.weight;
					if (widthMode == android.view.View.MeasureSpec.EXACTLY && lp.width == 0 && lp.weight
						 > 0)
					{
						// Optimization: don't bother measuring children who are going to use
						// leftover space. These views will get measured again down below if
						// there is any leftover space.
						if (isExactly)
						{
							mTotalLength += lp.leftMargin + lp.rightMargin;
						}
						else
						{
							int totalLength = mTotalLength;
							mTotalLength = System.Math.Max(totalLength, totalLength + lp.leftMargin + lp.rightMargin
								);
						}
						// Baseline alignment requires to measure widgets to obtain the
						// baseline offset (in particular for TextViews). The following
						// defeats the optimization mentioned above. Allow the child to
						// use as much space as it wants because we can shrink things
						// later (and re-measure).
						if (baselineAligned)
						{
							int freeSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
								.MeasureSpec.UNSPECIFIED);
							child.measure(freeSpec, freeSpec);
						}
					}
					else
					{
						int oldWidth = int.MinValue;
						if (lp.width == 0 && lp.weight > 0)
						{
							// widthMode is either UNSPECIFIED or AT_MOST, and this
							// child
							// wanted to stretch to fill available space. Translate that to
							// WRAP_CONTENT so that it does not end up with a width of 0
							oldWidth = 0;
							lp.width = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
						}
						// Determine how big this child would like to be. If this or
						// previous children have given a weight, then we allow it to
						// use all available space (and we will shrink things later
						// if needed).
						measureChildBeforeLayout(child, i, widthMeasureSpec, totalWeight == 0 ? mTotalLength
							 : 0, heightMeasureSpec, 0);
						if (oldWidth != int.MinValue)
						{
							lp.width = oldWidth;
						}
						int childWidth = child.getMeasuredWidth();
						if (isExactly)
						{
							mTotalLength += childWidth + lp.leftMargin + lp.rightMargin + getNextLocationOffset
								(child);
						}
						else
						{
							int totalLength = mTotalLength;
							mTotalLength = System.Math.Max(totalLength, totalLength + childWidth + lp.leftMargin
								 + lp.rightMargin + getNextLocationOffset(child));
						}
						if (useLargestChild)
						{
							largestChildWidth = System.Math.Max(childWidth, largestChildWidth);
						}
					}
					bool matchHeightLocally = false;
					if (heightMode != android.view.View.MeasureSpec.EXACTLY && lp.height == android.view.ViewGroup
						.LayoutParams.MATCH_PARENT)
					{
						// The height of the linear layout will scale, and at least one
						// child said it wanted to match our height. Set a flag indicating that
						// we need to remeasure at least that view when we know our height.
						matchHeight = true;
						matchHeightLocally = true;
					}
					int margin = lp.topMargin + lp.bottomMargin;
					int childHeight = child.getMeasuredHeight() + margin;
					childState = combineMeasuredStates(childState, child.getMeasuredState());
					if (baselineAligned)
					{
						int childBaseline = child.getBaseline();
						if (childBaseline != -1)
						{
							// Translates the child's vertical gravity into an index
							// in the range 0..VERTICAL_GRAVITY_COUNT
							int gravity = (lp.gravity < 0 ? mGravity : lp.gravity) & android.view.Gravity.VERTICAL_GRAVITY_MASK;
							int index = ((gravity >> android.view.Gravity.AXIS_Y_SHIFT) & ~android.view.Gravity
								.AXIS_SPECIFIED) >> 1;
							maxAscent[index] = System.Math.Max(maxAscent[index], childBaseline);
							maxDescent[index] = System.Math.Max(maxDescent[index], childHeight - childBaseline
								);
						}
					}
					maxHeight = System.Math.Max(maxHeight, childHeight);
					allFillParent = allFillParent && lp.height == android.view.ViewGroup.LayoutParams
						.MATCH_PARENT;
					if (lp.weight > 0)
					{
						weightedMaxHeight = System.Math.Max(weightedMaxHeight, matchHeightLocally ? margin
							 : childHeight);
					}
					else
					{
						alternativeMaxHeight = System.Math.Max(alternativeMaxHeight, matchHeightLocally ? 
							margin : childHeight);
					}
					i += getChildrenSkipCount(child, i);
				}
			}
			if (mTotalLength > 0 && hasDividerBeforeChildAt(count))
			{
				mTotalLength += mDividerWidth;
			}
			// Check mMaxAscent[INDEX_TOP] first because it maps to Gravity.TOP,
			// the most common case
			if (maxAscent[INDEX_TOP] != -1 || maxAscent[INDEX_CENTER_VERTICAL] != -1 || maxAscent
				[INDEX_BOTTOM] != -1 || maxAscent[INDEX_FILL] != -1)
			{
				int ascent = System.Math.Max(maxAscent[INDEX_FILL], System.Math.Max(maxAscent[INDEX_CENTER_VERTICAL
					], System.Math.Max(maxAscent[INDEX_TOP], maxAscent[INDEX_BOTTOM])));
				int descent = System.Math.Max(maxDescent[INDEX_FILL], System.Math.Max(maxDescent[
					INDEX_CENTER_VERTICAL], System.Math.Max(maxDescent[INDEX_TOP], maxDescent[INDEX_BOTTOM
					])));
				maxHeight = System.Math.Max(maxHeight, ascent + descent);
			}
			if (useLargestChild && (widthMode == android.view.View.MeasureSpec.AT_MOST || widthMode
				 == android.view.View.MeasureSpec.UNSPECIFIED))
			{
				mTotalLength = 0;
				{
					for (int i_1 = 0; i_1 < count; ++i_1)
					{
						android.view.View child = getVirtualChildAt(i_1);
						if (child == null)
						{
							mTotalLength += measureNullChild(i_1);
							continue;
						}
						if (child.getVisibility() == GONE)
						{
							i_1 += getChildrenSkipCount(child, i_1);
							continue;
						}
						android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
							)child.getLayoutParams();
						if (isExactly)
						{
							mTotalLength += largestChildWidth + lp.leftMargin + lp.rightMargin + getNextLocationOffset
								(child);
						}
						else
						{
							int totalLength = mTotalLength;
							mTotalLength = System.Math.Max(totalLength, totalLength + largestChildWidth + lp.
								leftMargin + lp.rightMargin + getNextLocationOffset(child));
						}
					}
				}
			}
			// Add in our padding
			mTotalLength += mPaddingLeft + mPaddingRight;
			int widthSize = mTotalLength;
			// Check against our minimum width
			widthSize = System.Math.Max(widthSize, getSuggestedMinimumWidth());
			// Reconcile our calculated size with the widthMeasureSpec
			int widthSizeAndState = resolveSizeAndState(widthSize, widthMeasureSpec, 0);
			widthSize = widthSizeAndState & MEASURED_SIZE_MASK;
			// Either expand children with weight to take up available space or
			// shrink them if they extend beyond our current bounds
			int delta = widthSize - mTotalLength;
			if (delta != 0 && totalWeight > 0.0f)
			{
				float weightSum = mWeightSum > 0.0f ? mWeightSum : totalWeight;
				maxAscent[0] = maxAscent[1] = maxAscent[2] = maxAscent[3] = -1;
				maxDescent[0] = maxDescent[1] = maxDescent[2] = maxDescent[3] = -1;
				maxHeight = -1;
				mTotalLength = 0;
				{
					for (int i_1 = 0; i_1 < count; ++i_1)
					{
						android.view.View child = getVirtualChildAt(i_1);
						if (child == null || child.getVisibility() == android.view.View.GONE)
						{
							continue;
						}
						android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
							)child.getLayoutParams();
						float childExtra = lp.weight;
						if (childExtra > 0)
						{
							// Child said it could absorb extra space -- give him his share
							int share = (int)(childExtra * delta / weightSum);
							weightSum -= childExtra;
							delta -= share;
							int childHeightMeasureSpec = getChildMeasureSpec(heightMeasureSpec, mPaddingTop +
								 mPaddingBottom + lp.topMargin + lp.bottomMargin, lp.height);
							// TODO: Use a field like lp.isMeasured to figure out if this
							// child has been previously measured
							if ((lp.width != 0) || (widthMode != android.view.View.MeasureSpec.EXACTLY))
							{
								// child was measured once already above ... base new measurement
								// on stored values
								int childWidth = child.getMeasuredWidth() + share;
								if (childWidth < 0)
								{
									childWidth = 0;
								}
								child.measure(android.view.View.MeasureSpec.makeMeasureSpec(childWidth, android.view.View
									.MeasureSpec.EXACTLY), childHeightMeasureSpec);
							}
							else
							{
								// child was skipped in the loop above. Measure for this first time here
								child.measure(android.view.View.MeasureSpec.makeMeasureSpec(share > 0 ? share : 0
									, android.view.View.MeasureSpec.EXACTLY), childHeightMeasureSpec);
							}
							// Child may now not fit in horizontal dimension.
							childState = combineMeasuredStates(childState, child.getMeasuredState() & MEASURED_STATE_MASK
								);
						}
						if (isExactly)
						{
							mTotalLength += child.getMeasuredWidth() + lp.leftMargin + lp.rightMargin + getNextLocationOffset
								(child);
						}
						else
						{
							int totalLength = mTotalLength;
							mTotalLength = System.Math.Max(totalLength, totalLength + child.getMeasuredWidth(
								) + lp.leftMargin + lp.rightMargin + getNextLocationOffset(child));
						}
						bool matchHeightLocally = heightMode != android.view.View.MeasureSpec.EXACTLY && 
							lp.height == android.view.ViewGroup.LayoutParams.MATCH_PARENT;
						int margin = lp.topMargin + lp.bottomMargin;
						int childHeight = child.getMeasuredHeight() + margin;
						maxHeight = System.Math.Max(maxHeight, childHeight);
						alternativeMaxHeight = System.Math.Max(alternativeMaxHeight, matchHeightLocally ? 
							margin : childHeight);
						allFillParent = allFillParent && lp.height == android.view.ViewGroup.LayoutParams
							.MATCH_PARENT;
						if (baselineAligned)
						{
							int childBaseline = child.getBaseline();
							if (childBaseline != -1)
							{
								// Translates the child's vertical gravity into an index in the range 0..2
								int gravity = (lp.gravity < 0 ? mGravity : lp.gravity) & android.view.Gravity.VERTICAL_GRAVITY_MASK;
								int index = ((gravity >> android.view.Gravity.AXIS_Y_SHIFT) & ~android.view.Gravity
									.AXIS_SPECIFIED) >> 1;
								maxAscent[index] = System.Math.Max(maxAscent[index], childBaseline);
								maxDescent[index] = System.Math.Max(maxDescent[index], childHeight - childBaseline
									);
							}
						}
					}
				}
				// Add in our padding
				mTotalLength += mPaddingLeft + mPaddingRight;
				// TODO: Should we update widthSize with the new total length?
				// Check mMaxAscent[INDEX_TOP] first because it maps to Gravity.TOP,
				// the most common case
				if (maxAscent[INDEX_TOP] != -1 || maxAscent[INDEX_CENTER_VERTICAL] != -1 || maxAscent
					[INDEX_BOTTOM] != -1 || maxAscent[INDEX_FILL] != -1)
				{
					int ascent = System.Math.Max(maxAscent[INDEX_FILL], System.Math.Max(maxAscent[INDEX_CENTER_VERTICAL
						], System.Math.Max(maxAscent[INDEX_TOP], maxAscent[INDEX_BOTTOM])));
					int descent = System.Math.Max(maxDescent[INDEX_FILL], System.Math.Max(maxDescent[
						INDEX_CENTER_VERTICAL], System.Math.Max(maxDescent[INDEX_TOP], maxDescent[INDEX_BOTTOM
						])));
					maxHeight = System.Math.Max(maxHeight, ascent + descent);
				}
			}
			else
			{
				alternativeMaxHeight = System.Math.Max(alternativeMaxHeight, weightedMaxHeight);
				// We have no limit, so make all weighted views as wide as the largest child.
				// Children will have already been measured once.
				if (useLargestChild && widthMode == android.view.View.MeasureSpec.UNSPECIFIED)
				{
					{
						for (int i_1 = 0; i_1 < count; i_1++)
						{
							android.view.View child = getVirtualChildAt(i_1);
							if (child == null || child.getVisibility() == android.view.View.GONE)
							{
								continue;
							}
							android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
								)child.getLayoutParams();
							float childExtra = lp.weight;
							if (childExtra > 0)
							{
								child.measure(android.view.View.MeasureSpec.makeMeasureSpec(largestChildWidth, android.view.View
									.MeasureSpec.EXACTLY), android.view.View.MeasureSpec.makeMeasureSpec(child.getMeasuredHeight
									(), android.view.View.MeasureSpec.EXACTLY));
							}
						}
					}
				}
			}
			if (!allFillParent && heightMode != android.view.View.MeasureSpec.EXACTLY)
			{
				maxHeight = alternativeMaxHeight;
			}
			maxHeight += mPaddingTop + mPaddingBottom;
			// Check against our minimum height
			maxHeight = System.Math.Max(maxHeight, getSuggestedMinimumHeight());
			setMeasuredDimension(widthSizeAndState | (childState & MEASURED_STATE_MASK), resolveSizeAndState
				(maxHeight, heightMeasureSpec, (childState << MEASURED_HEIGHT_STATE_SHIFT)));
			if (matchHeight)
			{
				forceUniformHeight(count, widthMeasureSpec);
			}
		}

		private void forceUniformHeight(int count, int widthMeasureSpec)
		{
			// Pretend that the linear layout has an exact size. This is the measured height of
			// ourselves. The measured height should be the max height of the children, changed
			// to accomodate the heightMesureSpec from the parent
			int uniformMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(getMeasuredHeight
				(), android.view.View.MeasureSpec.EXACTLY);
			{
				for (int i = 0; i < count; ++i)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child.getVisibility() != GONE)
					{
						android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
							)child.getLayoutParams();
						if (lp.height == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
						{
							// Temporarily force children to reuse their old measured width
							// FIXME: this may not be right for something like wrapping text?
							int oldWidth = lp.width;
							lp.width = child.getMeasuredWidth();
							// Remeasure with new dimensions
							measureChildWithMargins(child, widthMeasureSpec, 0, uniformMeasureSpec, 0);
							lp.width = oldWidth;
						}
					}
				}
			}
		}

		/// <summary>
		/// <p>Returns the number of children to skip after measuring/laying out
		/// the specified child.</p>
		/// </summary>
		/// <param name="child">the child after which we want to skip children</param>
		/// <param name="index">the index of the child after which we want to skip children</param>
		/// <returns>the number of children to skip, 0 by default</returns>
		internal virtual int getChildrenSkipCount(android.view.View child, int index)
		{
			return 0;
		}

		/// <summary>
		/// <p>Returns the size (width or height) that should be occupied by a null
		/// child.</p>
		/// </summary>
		/// <param name="childIndex">the index of the null child</param>
		/// <returns>the width or height of the child depending on the orientation</returns>
		internal virtual int measureNullChild(int childIndex)
		{
			return 0;
		}

		/// <summary><p>Measure the child according to the parent's measure specs.</summary>
		/// <remarks>
		/// <p>Measure the child according to the parent's measure specs. This
		/// method should be overriden by subclasses to force the sizing of
		/// children. This method is called by
		/// <see cref="measureVertical(int, int)">measureVertical(int, int)</see>
		/// and
		/// <see cref="measureHorizontal(int, int)">measureHorizontal(int, int)</see>
		/// .</p>
		/// </remarks>
		/// <param name="child">the child to measure</param>
		/// <param name="childIndex">the index of the child in this view</param>
		/// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent
		/// 	</param>
		/// <param name="totalWidth">extra space that has been used up by the parent horizontally
		/// 	</param>
		/// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent
		/// 	</param>
		/// <param name="totalHeight">extra space that has been used up by the parent vertically
		/// 	</param>
		internal virtual void measureChildBeforeLayout(android.view.View child, int childIndex
			, int widthMeasureSpec, int totalWidth, int heightMeasureSpec, int totalHeight)
		{
			measureChildWithMargins(child, widthMeasureSpec, totalWidth, heightMeasureSpec, totalHeight
				);
		}

		/// <summary><p>Return the location offset of the specified child.</summary>
		/// <remarks>
		/// <p>Return the location offset of the specified child. This can be used
		/// by subclasses to change the location of a given widget.</p>
		/// </remarks>
		/// <param name="child">the child for which to obtain the location offset</param>
		/// <returns>the location offset in pixels</returns>
		internal virtual int getLocationOffset(android.view.View child)
		{
			return 0;
		}

		/// <summary><p>Return the size offset of the next sibling of the specified child.</summary>
		/// <remarks>
		/// <p>Return the size offset of the next sibling of the specified child.
		/// This can be used by subclasses to change the location of the widget
		/// following <code>child</code>.</p>
		/// </remarks>
		/// <param name="child">the child whose next sibling will be moved</param>
		/// <returns>the location offset of the next child in pixels</returns>
		internal virtual int getNextLocationOffset(android.view.View child)
		{
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			if (mOrientation == VERTICAL)
			{
				layoutVertical();
			}
			else
			{
				layoutHorizontal();
			}
		}

		/// <summary>
		/// Position the children during a layout pass if the orientation of this
		/// LinearLayout is set to
		/// <see cref="VERTICAL">VERTICAL</see>
		/// .
		/// </summary>
		/// <seealso cref="getOrientation()">getOrientation()</seealso>
		/// <seealso cref="setOrientation(int)">setOrientation(int)</seealso>
		/// <seealso cref="onLayout(bool, int, int, int, int)">onLayout(bool, int, int, int, int)
		/// 	</seealso>
		internal virtual void layoutVertical()
		{
			int paddingLeft = mPaddingLeft;
			int childTop;
			int childLeft;
			// Where right end of child should go
			int width = mRight - mLeft;
			int childRight = width - mPaddingRight;
			// Space available for child
			int childSpace = width - paddingLeft - mPaddingRight;
			int count = getVirtualChildCount();
			int majorGravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			int minorGravity = mGravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK;
			switch (majorGravity)
			{
				case android.view.Gravity.BOTTOM:
				{
					// mTotalLength contains the padding already
					childTop = mPaddingTop + mBottom - mTop - mTotalLength;
					break;
				}

				case android.view.Gravity.CENTER_VERTICAL:
				{
					// mTotalLength contains the padding already
					childTop = mPaddingTop + (mBottom - mTop - mTotalLength) / 2;
					break;
				}

				case android.view.Gravity.TOP:
				default:
				{
					childTop = mPaddingTop;
					break;
				}
			}
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child == null)
					{
						childTop += measureNullChild(i);
					}
					else
					{
						if (child.getVisibility() != GONE)
						{
							int childWidth = child.getMeasuredWidth();
							int childHeight = child.getMeasuredHeight();
							android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
								)child.getLayoutParams();
							int gravity = lp.gravity;
							if (gravity < 0)
							{
								gravity = minorGravity;
							}
							int layoutDirection = getResolvedLayoutDirection();
							int absoluteGravity = android.view.Gravity.getAbsoluteGravity(gravity, layoutDirection
								);
							switch (absoluteGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK)
							{
								case android.view.Gravity.CENTER_HORIZONTAL:
								{
									childLeft = paddingLeft + ((childSpace - childWidth) / 2) + lp.leftMargin - lp.rightMargin;
									break;
								}

								case android.view.Gravity.RIGHT:
								{
									childLeft = childRight - childWidth - lp.rightMargin;
									break;
								}

								case android.view.Gravity.LEFT:
								default:
								{
									childLeft = paddingLeft + lp.leftMargin;
									break;
								}
							}
							if (hasDividerBeforeChildAt(i))
							{
								childTop += mDividerHeight;
							}
							childTop += lp.topMargin;
							setChildFrame(child, childLeft, childTop + getLocationOffset(child), childWidth, 
								childHeight);
							childTop += childHeight + lp.bottomMargin + getNextLocationOffset(child);
							i += getChildrenSkipCount(child, i);
						}
					}
				}
			}
		}

		/// <summary>
		/// Position the children during a layout pass if the orientation of this
		/// LinearLayout is set to
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// .
		/// </summary>
		/// <seealso cref="getOrientation()">getOrientation()</seealso>
		/// <seealso cref="setOrientation(int)">setOrientation(int)</seealso>
		/// <seealso cref="onLayout(bool, int, int, int, int)">onLayout(bool, int, int, int, int)
		/// 	</seealso>
		internal virtual void layoutHorizontal()
		{
			bool isLayoutRtl_1 = isLayoutRtl();
			int paddingTop = mPaddingTop;
			int childTop;
			int childLeft;
			// Where bottom of child should go
			int height = mBottom - mTop;
			int childBottom = height - mPaddingBottom;
			// Space available for child
			int childSpace = height - paddingTop - mPaddingBottom;
			int count = getVirtualChildCount();
			int majorGravity = mGravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK;
			int minorGravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			bool baselineAligned = mBaselineAligned;
			int[] maxAscent = mMaxAscent;
			int[] maxDescent = mMaxDescent;
			int layoutDirection = getResolvedLayoutDirection();
			switch (android.view.Gravity.getAbsoluteGravity(majorGravity, layoutDirection))
			{
				case android.view.Gravity.RIGHT:
				{
					// mTotalLength contains the padding already
					childLeft = mPaddingLeft + mRight - mLeft - mTotalLength;
					break;
				}

				case android.view.Gravity.CENTER_HORIZONTAL:
				{
					// mTotalLength contains the padding already
					childLeft = mPaddingLeft + (mRight - mLeft - mTotalLength) / 2;
					break;
				}

				case android.view.Gravity.LEFT:
				default:
				{
					childLeft = mPaddingLeft;
					break;
				}
			}
			int start = 0;
			int dir = 1;
			//In case of RTL, start drawing from the last child.
			if (isLayoutRtl_1)
			{
				start = count - 1;
				dir = -1;
			}
			{
				for (int i = 0; i < count; i++)
				{
					int childIndex = start + dir * i;
					android.view.View child = getVirtualChildAt(childIndex);
					if (child == null)
					{
						childLeft += measureNullChild(childIndex);
					}
					else
					{
						if (child.getVisibility() != GONE)
						{
							int childWidth = child.getMeasuredWidth();
							int childHeight = child.getMeasuredHeight();
							int childBaseline = -1;
							android.widget.LinearLayout.LayoutParams lp = (android.widget.LinearLayout.LayoutParams
								)child.getLayoutParams();
							if (baselineAligned && lp.height != android.view.ViewGroup.LayoutParams.MATCH_PARENT)
							{
								childBaseline = child.getBaseline();
							}
							int gravity = lp.gravity;
							if (gravity < 0)
							{
								gravity = minorGravity;
							}
							switch (gravity & android.view.Gravity.VERTICAL_GRAVITY_MASK)
							{
								case android.view.Gravity.TOP:
								{
									childTop = paddingTop + lp.topMargin;
									if (childBaseline != -1)
									{
										childTop += maxAscent[INDEX_TOP] - childBaseline;
									}
									break;
								}

								case android.view.Gravity.CENTER_VERTICAL:
								{
									// Removed support for baseline alignment when layout_gravity or
									// gravity == center_vertical. See bug #1038483.
									// Keep the code around if we need to re-enable this feature
									// if (childBaseline != -1) {
									//     // Align baselines vertically only if the child is smaller than us
									//     if (childSpace - childHeight > 0) {
									//         childTop = paddingTop + (childSpace / 2) - childBaseline;
									//     } else {
									//         childTop = paddingTop + (childSpace - childHeight) / 2;
									//     }
									// } else {
									childTop = paddingTop + ((childSpace - childHeight) / 2) + lp.topMargin - lp.bottomMargin;
									break;
								}

								case android.view.Gravity.BOTTOM:
								{
									childTop = childBottom - childHeight - lp.bottomMargin;
									if (childBaseline != -1)
									{
										int descent = child.getMeasuredHeight() - childBaseline;
										childTop -= (maxDescent[INDEX_BOTTOM] - descent);
									}
									break;
								}

								default:
								{
									childTop = paddingTop;
									break;
								}
							}
							if (hasDividerBeforeChildAt(childIndex))
							{
								childLeft += mDividerWidth;
							}
							childLeft += lp.leftMargin;
							setChildFrame(child, childLeft + getLocationOffset(child), childTop, childWidth, 
								childHeight);
							childLeft += childWidth + lp.rightMargin + getNextLocationOffset(child);
							i += getChildrenSkipCount(child, childIndex);
						}
					}
				}
			}
		}

		private void setChildFrame(android.view.View child, int left, int top, int width, 
			int height)
		{
			child.layout(left, top, left + width, top + height);
		}

		/// <summary>Should the layout be a column or a row.</summary>
		/// <remarks>Should the layout be a column or a row.</remarks>
		/// <param name="orientation">
		/// Pass HORIZONTAL or VERTICAL. Default
		/// value is HORIZONTAL.
		/// </param>
		/// <attr>ref android.R.styleable#LinearLayout_orientation</attr>
		public virtual void setOrientation(int orientation)
		{
			if (mOrientation != orientation)
			{
				mOrientation = orientation;
				requestLayout();
			}
		}

		/// <summary>Returns the current orientation.</summary>
		/// <remarks>Returns the current orientation.</remarks>
		/// <returns>
		/// either
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// or
		/// <see cref="VERTICAL">VERTICAL</see>
		/// </returns>
		public virtual int getOrientation()
		{
			return mOrientation;
		}

		/// <summary>Describes how the child views are positioned.</summary>
		/// <remarks>
		/// Describes how the child views are positioned. Defaults to GRAVITY_TOP. If
		/// this layout has a VERTICAL orientation, this controls where all the child
		/// views are placed if there is extra vertical space. If this layout has a
		/// HORIZONTAL orientation, this controls the alignment of the children.
		/// </remarks>
		/// <param name="gravity">
		/// See
		/// <see cref="android.view.Gravity">android.view.Gravity</see>
		/// </param>
		/// <attr>ref android.R.styleable#LinearLayout_gravity</attr>
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

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.LinearLayout.LayoutParams(getContext(), attrs);
		}

		/// <summary>
		/// Returns a set of layout parameters with a width of
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// and a height of
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// when the layout's orientation is
		/// <see cref="VERTICAL">VERTICAL</see>
		/// . When the orientation is
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// , the width is set to
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// and the height to
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// .
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			if (mOrientation == HORIZONTAL)
			{
				return new android.widget.LinearLayout.LayoutParams(android.view.ViewGroup.LayoutParams
					.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
			}
			else
			{
				if (mOrientation == VERTICAL)
				{
					return new android.widget.LinearLayout.LayoutParams(android.view.ViewGroup.LayoutParams
						.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
				}
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.LinearLayout.LayoutParams(p);
		}

		// Override to allow type-checking of LayoutParams.
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.LinearLayout.LayoutParams;
		}

		/// <summary>Per-child layout information associated with ViewLinearLayout.</summary>
		/// <remarks>Per-child layout information associated with ViewLinearLayout.</remarks>
		/// <attr>ref android.R.styleable#LinearLayout_Layout_layout_weight</attr>
		/// <attr>ref android.R.styleable#LinearLayout_Layout_layout_gravity</attr>
		public class LayoutParams : android.view.ViewGroup.MarginLayoutParams
		{
			/// <summary>
			/// Indicates how much of the extra space in the LinearLayout will be
			/// allocated to the view associated with these LayoutParams.
			/// </summary>
			/// <remarks>
			/// Indicates how much of the extra space in the LinearLayout will be
			/// allocated to the view associated with these LayoutParams. Specify
			/// 0 if the view should not be stretched. Otherwise the extra pixels
			/// will be pro-rated among all views whose weight is greater than 0.
			/// </remarks>
			public float weight;

			/// <summary>Gravity for the view associated with these LayoutParams.</summary>
			/// <remarks>Gravity for the view associated with these LayoutParams.</remarks>
			/// <seealso cref="android.view.Gravity">android.view.Gravity</seealso>
			public int gravity = -1;

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
				android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.LinearLayout_Layout);
				weight = a.getFloat(android.@internal.R.styleable.LinearLayout_Layout_layout_weight
					, 0);
				gravity = a.getInt(android.@internal.R.styleable.LinearLayout_Layout_layout_gravity
					, -1);
				a.recycle();
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(int width, int height) : base(width, height)
			{
				weight = 0;
			}

			/// <summary>
			/// Creates a new set of layout parameters with the specified width, height
			/// and weight.
			/// </summary>
			/// <remarks>
			/// Creates a new set of layout parameters with the specified width, height
			/// and weight.
			/// </remarks>
			/// <param name="width">
			/// the width, either
			/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
			/// 	</see>
			/// ,
			/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
			/// 	</see>
			/// or a fixed size in pixels
			/// </param>
			/// <param name="height">
			/// the height, either
			/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
			/// 	</see>
			/// ,
			/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
			/// 	</see>
			/// or a fixed size in pixels
			/// </param>
			/// <param name="weight">the weight</param>
			public LayoutParams(int width, int height, float weight) : base(width, height)
			{
				this.weight = weight;
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.view.ViewGroup.LayoutParams p) : base(p)
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
				return output + "LinearLayout.LayoutParams={width=" + sizeToString(width) + ", height="
					 + sizeToString(height) + " weight=" + weight + "}";
			}
		}
	}
}
