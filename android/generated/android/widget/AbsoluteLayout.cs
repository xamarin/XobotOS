using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A layout that lets you specify exact locations (x/y coordinates) of its
	/// children.
	/// </summary>
	/// <remarks>
	/// A layout that lets you specify exact locations (x/y coordinates) of its
	/// children. Absolute layouts are less flexible and harder to maintain than
	/// other types of layouts without absolute positioning.
	/// <p><strong>XML attributes</strong></p> <p> See
	/// <see cref="android.R.styleable.ViewGroup">ViewGroup Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	[System.ObsoleteAttribute(@"Use FrameLayout , RelativeLayout or a custom layout instead."
		)]
	public class AbsoluteLayout : android.view.ViewGroup
	{
		public AbsoluteLayout(android.content.Context context) : base(context)
		{
		}

		public AbsoluteLayout(android.content.Context context, android.util.AttributeSet 
			attrs) : base(context, attrs)
		{
		}

		public AbsoluteLayout(android.content.Context context, android.util.AttributeSet 
			attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int count = getChildCount();
			int maxHeight = 0;
			int maxWidth = 0;
			// Find out how big everyone wants to be
			measureChildren(widthMeasureSpec, heightMeasureSpec);
			{
				// Find rightmost and bottom-most child
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() != GONE)
					{
						int childRight;
						int childBottom;
						android.widget.AbsoluteLayout.LayoutParams lp = (android.widget.AbsoluteLayout.LayoutParams
							)child.getLayoutParams();
						childRight = lp.x + child.getMeasuredWidth();
						childBottom = lp.y + child.getMeasuredHeight();
						maxWidth = System.Math.Max(maxWidth, childRight);
						maxHeight = System.Math.Max(maxHeight, childBottom);
					}
				}
			}
			// Account for padding too
			maxWidth += mPaddingLeft + mPaddingRight;
			maxHeight += mPaddingTop + mPaddingBottom;
			// Check against minimum height and width
			maxHeight = System.Math.Max(maxHeight, getSuggestedMinimumHeight());
			maxWidth = System.Math.Max(maxWidth, getSuggestedMinimumWidth());
			setMeasuredDimension(resolveSizeAndState(maxWidth, widthMeasureSpec, 0), resolveSizeAndState
				(maxHeight, heightMeasureSpec, 0));
		}

		/// <summary>
		/// Returns a set of layout parameters with a width of
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// ,
		/// a height of
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// and with the coordinates (0, 0).
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.widget.AbsoluteLayout.LayoutParams(android.view.ViewGroup.LayoutParams
				.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT, 0, 0);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			int count = getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() != GONE)
					{
						android.widget.AbsoluteLayout.LayoutParams lp = (android.widget.AbsoluteLayout.LayoutParams
							)child.getLayoutParams();
						int childLeft = mPaddingLeft + lp.x;
						int childTop = mPaddingTop + lp.y;
						child.layout(childLeft, childTop, childLeft + child.getMeasuredWidth(), childTop 
							+ child.getMeasuredHeight());
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.AbsoluteLayout.LayoutParams(getContext(), attrs);
		}

		// Override to allow type-checking of LayoutParams. 
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.AbsoluteLayout.LayoutParams;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.AbsoluteLayout.LayoutParams(p);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool shouldDelayChildPressedState()
		{
			return false;
		}

		/// <summary>Per-child layout information associated with AbsoluteLayout.</summary>
		/// <remarks>
		/// Per-child layout information associated with AbsoluteLayout.
		/// See
		/// <see cref="android.R.styleable.AbsoluteLayout_Layout">Absolute Layout Attributes</see>
		/// for a list of all child view attributes that this class supports.
		/// </remarks>
		public class LayoutParams : android.view.ViewGroup.LayoutParams
		{
			/// <summary>The horizontal, or X, location of the child within the view group.</summary>
			/// <remarks>The horizontal, or X, location of the child within the view group.</remarks>
			public int x;

			/// <summary>The vertical, or Y, location of the child within the view group.</summary>
			/// <remarks>The vertical, or Y, location of the child within the view group.</remarks>
			public int y;

			/// <summary>
			/// Creates a new set of layout parameters with the specified width,
			/// height and location.
			/// </summary>
			/// <remarks>
			/// Creates a new set of layout parameters with the specified width,
			/// height and location.
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
			/// <param name="x">the X location of the child</param>
			/// <param name="y">the Y location of the child</param>
			public LayoutParams(int width, int height, int x, int y) : base(width, height)
			{
				this.x = x;
				this.y = y;
			}

			/// <summary>Creates a new set of layout parameters.</summary>
			/// <remarks>
			/// Creates a new set of layout parameters. The values are extracted from
			/// the supplied attributes set and context. The XML attributes mapped
			/// to this set of layout parameters are:
			/// <ul>
			/// <li><code>layout_x</code>: the X location of the child</li>
			/// <li><code>layout_y</code>: the Y location of the child</li>
			/// <li>All the XML attributes from
			/// <see cref="android.view.ViewGroup.LayoutParams">android.view.ViewGroup.LayoutParams
			/// 	</see>
			/// </li>
			/// </ul>
			/// </remarks>
			/// <param name="c">the application environment</param>
			/// <param name="attrs">
			/// the set of attributes from which to extract the layout
			/// parameters values
			/// </param>
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
				android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.AbsoluteLayout_Layout);
				x = a.getDimensionPixelOffset(android.@internal.R.styleable.AbsoluteLayout_Layout_layout_x
					, 0);
				y = a.getDimensionPixelOffset(android.@internal.R.styleable.AbsoluteLayout_Layout_layout_y
					, 0);
				a.recycle();
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.view.ViewGroup.LayoutParams source) : base(source)
			{
			}

			[Sharpen.OverridesMethod(@"android.view.ViewGroup.LayoutParams")]
			public override string debug(string output)
			{
				return output + "Absolute.LayoutParams={width=" + sizeToString(width) + ", height="
					 + sizeToString(height) + " x=" + x + " y=" + y + "}";
			}
		}
	}
}
