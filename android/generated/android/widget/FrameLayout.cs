using Sharpen;

namespace android.widget
{
	/// <summary>
	/// FrameLayout is designed to block out an area on the screen to display
	/// a single item.
	/// </summary>
	/// <remarks>
	/// FrameLayout is designed to block out an area on the screen to display
	/// a single item. Generally, FrameLayout should be used to hold a single child view, because it can
	/// be difficult to organize child views in a way that's scalable to different screen sizes without
	/// the children overlapping each other. You can, however, add multiple children to a FrameLayout
	/// and control their position within the FrameLayout by assigning gravity to each child, using the
	/// <a href="FrameLayout.LayoutParams.html#attr_android:layout_gravity">
	/// <code>android:layout_gravity</code>
	/// </a> attribute.
	/// <p>Child views are drawn in a stack, with the most recently added child on top.
	/// The size of the FrameLayout is the size of its largest child (plus padding), visible
	/// or not (if the FrameLayout's parent permits). Views that are
	/// <see cref="android.view.View.GONE">android.view.View.GONE</see>
	/// are
	/// used for sizing
	/// only if
	/// <see cref="setMeasureAllChildren(bool)">setConsiderGoneChildrenWhenMeasuring()</see>
	/// is set to true.
	/// </remarks>
	/// <attr>ref android.R.styleable#FrameLayout_foreground</attr>
	/// <attr>ref android.R.styleable#FrameLayout_foregroundGravity</attr>
	/// <attr>ref android.R.styleable#FrameLayout_measureAllChildren</attr>
	[Sharpen.Sharpened]
	public class FrameLayout : android.view.ViewGroup
	{
		internal const int DEFAULT_CHILD_GRAVITY = android.view.Gravity.TOP | android.view.Gravity
			.LEFT;

		internal bool mMeasureAllChildren = false;

		private android.graphics.drawable.Drawable mForeground;

		private int mForegroundPaddingLeft = 0;

		private int mForegroundPaddingTop = 0;

		private int mForegroundPaddingRight = 0;

		private int mForegroundPaddingBottom = 0;

		private readonly android.graphics.Rect mSelfBounds = new android.graphics.Rect();

		private readonly android.graphics.Rect mOverlayBounds = new android.graphics.Rect
			();

		private int mForegroundGravity = android.view.Gravity.FILL;

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		protected internal bool mForegroundInPadding = true;

		internal bool mForegroundBoundsChanged = false;

		private readonly java.util.ArrayList<android.view.View> mMatchParentChildren = new 
			java.util.ArrayList<android.view.View>(1);

		public FrameLayout(android.content.Context context) : base(context)
		{
		}

		public FrameLayout(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
		}

		public FrameLayout(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.FrameLayout, defStyle, 0);
			mForegroundGravity = a.getInt(android.@internal.R.styleable.FrameLayout_foregroundGravity
				, mForegroundGravity);
			android.graphics.drawable.Drawable d = a.getDrawable(android.@internal.R.styleable
				.FrameLayout_foreground);
			if (d != null)
			{
				setForeground(d);
			}
			if (a.getBoolean(android.@internal.R.styleable.FrameLayout_measureAllChildren, false
				))
			{
				setMeasureAllChildren(true);
			}
			mForegroundInPadding = a.getBoolean(android.@internal.R.styleable.FrameLayout_foregroundInsidePadding
				, true);
			a.recycle();
		}

		/// <summary>Describes how the foreground is positioned.</summary>
		/// <remarks>Describes how the foreground is positioned. Defaults to START and TOP.</remarks>
		/// <param name="foregroundGravity">
		/// See
		/// <see cref="android.view.Gravity">android.view.Gravity</see>
		/// </param>
		/// <attr>ref android.R.styleable#FrameLayout_foregroundGravity</attr>
		[android.view.RemotableViewMethod]
		public virtual void setForegroundGravity(int foregroundGravity)
		{
			if (mForegroundGravity != foregroundGravity)
			{
				if ((foregroundGravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK) ==
					 0)
				{
					foregroundGravity |= android.view.Gravity.START;
				}
				if ((foregroundGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == 0)
				{
					foregroundGravity |= android.view.Gravity.TOP;
				}
				mForegroundGravity = foregroundGravity;
				if (mForegroundGravity == android.view.Gravity.FILL && mForeground != null)
				{
					android.graphics.Rect padding = new android.graphics.Rect();
					if (mForeground.getPadding(padding))
					{
						mForegroundPaddingLeft = padding.left;
						mForegroundPaddingTop = padding.top;
						mForegroundPaddingRight = padding.right;
						mForegroundPaddingBottom = padding.bottom;
					}
				}
				else
				{
					mForegroundPaddingLeft = 0;
					mForegroundPaddingTop = 0;
					mForegroundPaddingRight = 0;
					mForegroundPaddingBottom = 0;
				}
				requestLayout();
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 who)
		{
			return base.verifyDrawable(who) || (who == mForeground);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			if (mForeground != null)
			{
				mForeground.jumpToCurrentState();
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			if (mForeground != null && mForeground.isStateful())
			{
				mForeground.setState(getDrawableState());
			}
		}

		/// <summary>
		/// Returns a set of layout parameters with a width of
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// ,
		/// and a height of
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// .
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.widget.FrameLayout.LayoutParams(android.view.ViewGroup.LayoutParams
				.MATCH_PARENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT);
		}

		/// <summary>
		/// Supply a Drawable that is to be rendered on top of all of the child
		/// views in the frame layout.
		/// </summary>
		/// <remarks>
		/// Supply a Drawable that is to be rendered on top of all of the child
		/// views in the frame layout.  Any padding in the Drawable will be taken
		/// into account by ensuring that the children are inset to be placed
		/// inside of the padding area.
		/// </remarks>
		/// <param name="drawable">The Drawable to be drawn on top of the children.</param>
		/// <attr>ref android.R.styleable#FrameLayout_foreground</attr>
		public virtual void setForeground(android.graphics.drawable.Drawable drawable)
		{
			if (mForeground != drawable)
			{
				if (mForeground != null)
				{
					mForeground.setCallback(null);
					unscheduleDrawable(mForeground);
				}
				mForeground = drawable;
				mForegroundPaddingLeft = 0;
				mForegroundPaddingTop = 0;
				mForegroundPaddingRight = 0;
				mForegroundPaddingBottom = 0;
				if (drawable != null)
				{
					setWillNotDraw(false);
					drawable.setCallback(this);
					if (drawable.isStateful())
					{
						drawable.setState(getDrawableState());
					}
					if (mForegroundGravity == android.view.Gravity.FILL)
					{
						android.graphics.Rect padding = new android.graphics.Rect();
						if (drawable.getPadding(padding))
						{
							mForegroundPaddingLeft = padding.left;
							mForegroundPaddingTop = padding.top;
							mForegroundPaddingRight = padding.right;
							mForegroundPaddingBottom = padding.bottom;
						}
					}
				}
				else
				{
					setWillNotDraw(true);
				}
				requestLayout();
				invalidate();
			}
		}

		/// <summary>Returns the drawable used as the foreground of this FrameLayout.</summary>
		/// <remarks>
		/// Returns the drawable used as the foreground of this FrameLayout. The
		/// foreground drawable, if non-null, is always drawn on top of the children.
		/// </remarks>
		/// <returns>A Drawable or null if no foreground was set.</returns>
		public virtual android.graphics.drawable.Drawable getForeground()
		{
			return mForeground;
		}

		private int getPaddingLeftWithForeground()
		{
			return mForegroundInPadding ? System.Math.Max(mPaddingLeft, mForegroundPaddingLeft
				) : mPaddingLeft + mForegroundPaddingLeft;
		}

		private int getPaddingRightWithForeground()
		{
			return mForegroundInPadding ? System.Math.Max(mPaddingRight, mForegroundPaddingRight
				) : mPaddingRight + mForegroundPaddingRight;
		}

		private int getPaddingTopWithForeground()
		{
			return mForegroundInPadding ? System.Math.Max(mPaddingTop, mForegroundPaddingTop)
				 : mPaddingTop + mForegroundPaddingTop;
		}

		private int getPaddingBottomWithForeground()
		{
			return mForegroundInPadding ? System.Math.Max(mPaddingBottom, mForegroundPaddingBottom
				) : mPaddingBottom + mForegroundPaddingBottom;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int count = getChildCount();
			bool measureMatchParentChildren = android.view.View.MeasureSpec.getMode(widthMeasureSpec
				) != android.view.View.MeasureSpec.EXACTLY || android.view.View.MeasureSpec.getMode
				(heightMeasureSpec) != android.view.View.MeasureSpec.EXACTLY;
			mMatchParentChildren.clear();
			int maxHeight = 0;
			int maxWidth = 0;
			int childState = 0;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (mMeasureAllChildren || child.getVisibility() != GONE)
					{
						measureChildWithMargins(child, widthMeasureSpec, 0, heightMeasureSpec, 0);
						android.widget.FrameLayout.LayoutParams lp = (android.widget.FrameLayout.LayoutParams
							)child.getLayoutParams();
						maxWidth = System.Math.Max(maxWidth, child.getMeasuredWidth() + lp.leftMargin + lp
							.rightMargin);
						maxHeight = System.Math.Max(maxHeight, child.getMeasuredHeight() + lp.topMargin +
							 lp.bottomMargin);
						childState = combineMeasuredStates(childState, child.getMeasuredState());
						if (measureMatchParentChildren)
						{
							if (lp.width == android.view.ViewGroup.LayoutParams.MATCH_PARENT || lp.height == 
								android.view.ViewGroup.LayoutParams.MATCH_PARENT)
							{
								mMatchParentChildren.add(child);
							}
						}
					}
				}
			}
			// Account for padding too
			maxWidth += getPaddingLeftWithForeground() + getPaddingRightWithForeground();
			maxHeight += getPaddingTopWithForeground() + getPaddingBottomWithForeground();
			// Check against our minimum height and width
			maxHeight = System.Math.Max(maxHeight, getSuggestedMinimumHeight());
			maxWidth = System.Math.Max(maxWidth, getSuggestedMinimumWidth());
			// Check against our foreground's minimum height and width
			android.graphics.drawable.Drawable drawable = getForeground();
			if (drawable != null)
			{
				maxHeight = System.Math.Max(maxHeight, drawable.getMinimumHeight());
				maxWidth = System.Math.Max(maxWidth, drawable.getMinimumWidth());
			}
			setMeasuredDimension(resolveSizeAndState(maxWidth, widthMeasureSpec, childState), 
				resolveSizeAndState(maxHeight, heightMeasureSpec, childState << MEASURED_HEIGHT_STATE_SHIFT
				));
			count = mMatchParentChildren.size();
			if (count > 1)
			{
				{
					for (int i_1 = 0; i_1 < count; i_1++)
					{
						android.view.View child = mMatchParentChildren.get(i_1);
						android.view.ViewGroup.MarginLayoutParams lp = (android.view.ViewGroup.MarginLayoutParams
							)child.getLayoutParams();
						int childWidthMeasureSpec;
						int childHeightMeasureSpec;
						if (lp.width == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
						{
							childWidthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(getMeasuredWidth
								() - getPaddingLeftWithForeground() - getPaddingRightWithForeground() - lp.leftMargin
								 - lp.rightMargin, android.view.View.MeasureSpec.EXACTLY);
						}
						else
						{
							childWidthMeasureSpec = getChildMeasureSpec(widthMeasureSpec, getPaddingLeftWithForeground
								() + getPaddingRightWithForeground() + lp.leftMargin + lp.rightMargin, lp.width);
						}
						if (lp.height == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
						{
							childHeightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(getMeasuredHeight
								() - getPaddingTopWithForeground() - getPaddingBottomWithForeground() - lp.topMargin
								 - lp.bottomMargin, android.view.View.MeasureSpec.EXACTLY);
						}
						else
						{
							childHeightMeasureSpec = getChildMeasureSpec(heightMeasureSpec, getPaddingTopWithForeground
								() + getPaddingBottomWithForeground() + lp.topMargin + lp.bottomMargin, lp.height
								);
						}
						child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
					}
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			int count = getChildCount();
			int parentLeft = getPaddingLeftWithForeground();
			int parentRight = right - left - getPaddingRightWithForeground();
			int parentTop = getPaddingTopWithForeground();
			int parentBottom = bottom - top - getPaddingBottomWithForeground();
			mForegroundBoundsChanged = true;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() != GONE)
					{
						android.widget.FrameLayout.LayoutParams lp = (android.widget.FrameLayout.LayoutParams
							)child.getLayoutParams();
						int width = child.getMeasuredWidth();
						int height = child.getMeasuredHeight();
						int childLeft;
						int childTop;
						int gravity = lp.gravity;
						if (gravity == -1)
						{
							gravity = DEFAULT_CHILD_GRAVITY;
						}
						int layoutDirection = getResolvedLayoutDirection();
						int absoluteGravity = android.view.Gravity.getAbsoluteGravity(gravity, layoutDirection
							);
						int verticalGravity = gravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
						switch (absoluteGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK)
						{
							case android.view.Gravity.LEFT:
							{
								childLeft = parentLeft + lp.leftMargin;
								break;
							}

							case android.view.Gravity.CENTER_HORIZONTAL:
							{
								childLeft = parentLeft + (parentRight - parentLeft - width) / 2 + lp.leftMargin -
									 lp.rightMargin;
								break;
							}

							case android.view.Gravity.RIGHT:
							{
								childLeft = parentRight - width - lp.rightMargin;
								break;
							}

							default:
							{
								childLeft = parentLeft + lp.leftMargin;
								break;
							}
						}
						switch (verticalGravity)
						{
							case android.view.Gravity.TOP:
							{
								childTop = parentTop + lp.topMargin;
								break;
							}

							case android.view.Gravity.CENTER_VERTICAL:
							{
								childTop = parentTop + (parentBottom - parentTop - height) / 2 + lp.topMargin - lp
									.bottomMargin;
								break;
							}

							case android.view.Gravity.BOTTOM:
							{
								childTop = parentBottom - height - lp.bottomMargin;
								break;
							}

							default:
							{
								childTop = parentTop + lp.topMargin;
								break;
							}
						}
						child.layout(childLeft, childTop, childLeft + width, childTop + height);
					}
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.onSizeChanged(w, h, oldw, oldh);
			mForegroundBoundsChanged = true;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
			base.draw(canvas);
			if (mForeground != null)
			{
				android.graphics.drawable.Drawable foreground = mForeground;
				if (mForegroundBoundsChanged)
				{
					mForegroundBoundsChanged = false;
					android.graphics.Rect selfBounds = mSelfBounds;
					android.graphics.Rect overlayBounds = mOverlayBounds;
					int w = mRight - mLeft;
					int h = mBottom - mTop;
					if (mForegroundInPadding)
					{
						selfBounds.set(0, 0, w, h);
					}
					else
					{
						selfBounds.set(mPaddingLeft, mPaddingTop, w - mPaddingRight, h - mPaddingBottom);
					}
					int layoutDirection = getResolvedLayoutDirection();
					android.view.Gravity.apply(mForegroundGravity, foreground.getIntrinsicWidth(), foreground
						.getIntrinsicHeight(), selfBounds, overlayBounds, layoutDirection);
					foreground.setBounds(overlayBounds);
				}
				foreground.draw(canvas);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool gatherTransparentRegion(android.graphics.Region region)
		{
			bool opaque = base.gatherTransparentRegion(region);
			if (region != null && mForeground != null)
			{
				applyDrawableToTransparentRegion(mForeground, region);
			}
			return opaque;
		}

		/// <summary>
		/// Sets whether to consider all children, or just those in
		/// the VISIBLE or INVISIBLE state, when measuring.
		/// </summary>
		/// <remarks>
		/// Sets whether to consider all children, or just those in
		/// the VISIBLE or INVISIBLE state, when measuring. Defaults to false.
		/// </remarks>
		/// <param name="measureAll">
		/// true to consider children marked GONE, false otherwise.
		/// Default value is false.
		/// </param>
		/// <attr>ref android.R.styleable#FrameLayout_measureAllChildren</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMeasureAllChildren(bool measureAll)
		{
			mMeasureAllChildren = measureAll;
		}

		/// <summary>
		/// Determines whether all children, or just those in the VISIBLE or
		/// INVISIBLE state, are considered when measuring.
		/// </summary>
		/// <remarks>
		/// Determines whether all children, or just those in the VISIBLE or
		/// INVISIBLE state, are considered when measuring.
		/// </remarks>
		/// <returns>Whether all children are considered when measuring.</returns>
		[System.ObsoleteAttribute(@"This method is deprecated in favor ofgetMeasureAllChildren() getMeasureAllChildren() , which was renamed for consistency withsetMeasureAllChildren(bool) setMeasureAllChildren() ."
			)]
		public virtual bool getConsiderGoneChildrenWhenMeasuring()
		{
			return getMeasureAllChildren();
		}

		/// <summary>
		/// Determines whether all children, or just those in the VISIBLE or
		/// INVISIBLE state, are considered when measuring.
		/// </summary>
		/// <remarks>
		/// Determines whether all children, or just those in the VISIBLE or
		/// INVISIBLE state, are considered when measuring.
		/// </remarks>
		/// <returns>Whether all children are considered when measuring.</returns>
		public virtual bool getMeasureAllChildren()
		{
			return mMeasureAllChildren;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.FrameLayout.LayoutParams(getContext(), attrs);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool shouldDelayChildPressedState()
		{
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.FrameLayout.LayoutParams;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.FrameLayout.LayoutParams(p);
		}

		/// <summary>Per-child layout information for layouts that support margins.</summary>
		/// <remarks>
		/// Per-child layout information for layouts that support margins.
		/// See
		/// <see cref="android.R.styleable.FrameLayout_Layout">FrameLayout Layout Attributes</see>
		/// for a list of all child view attributes that this class supports.
		/// </remarks>
		/// <attr>ref android.R.styleable#FrameLayout_Layout_layout_gravity</attr>
		public class LayoutParams : android.view.ViewGroup.MarginLayoutParams
		{
			/// <summary>
			/// The gravity to apply with the View to which these layout parameters
			/// are associated.
			/// </summary>
			/// <remarks>
			/// The gravity to apply with the View to which these layout parameters
			/// are associated.
			/// </remarks>
			/// <seealso cref="android.view.Gravity">android.view.Gravity</seealso>
			/// <attr>ref android.R.styleable#FrameLayout_Layout_layout_gravity</attr>
			public int gravity = -1;

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
				android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.FrameLayout_Layout);
				gravity = a.getInt(android.@internal.R.styleable.FrameLayout_Layout_layout_gravity
					, -1);
				a.recycle();
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(int width, int height) : base(width, height)
			{
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
			/// <param name="gravity">the gravity</param>
			/// <seealso cref="android.view.Gravity">android.view.Gravity</seealso>
			public LayoutParams(int width, int height, int gravity) : base(width, height)
			{
				this.gravity = gravity;
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
		}
	}
}
