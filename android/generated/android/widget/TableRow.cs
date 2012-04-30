using Sharpen;

namespace android.widget
{
	/// <summary><p>A layout that arranges its children horizontally.</summary>
	/// <remarks>
	/// <p>A layout that arranges its children horizontally. A TableRow should
	/// always be used as a child of a
	/// <see cref="TableLayout">TableLayout</see>
	/// . If a
	/// TableRow's parent is not a TableLayout, the TableRow will behave as
	/// an horizontal
	/// <see cref="LinearLayout">LinearLayout</see>
	/// .</p>
	/// <p>The children of a TableRow do not need to specify the
	/// <code>layout_width</code> and <code>layout_height</code> attributes in the
	/// XML file. TableRow always enforces those values to be respectively
	/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
	/// 	</see>
	/// and
	/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
	/// 	</see>
	/// .</p>
	/// <p>
	/// Also see
	/// <see cref="LayoutParams">android.widget.TableRow.LayoutParams</see>
	/// for layout attributes </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class TableRow : android.widget.LinearLayout
	{
		private int mNumColumns = 0;

		private int[] mColumnWidths;

		private int[] mConstrainedColumnWidths;

		private android.util.SparseIntArray mColumnToChildIndex;

		private android.widget.TableRow.ChildrenTracker mChildrenTracker;

		/// <summary><p>Creates a new TableRow for the given context.</p></summary>
		/// <param name="context">the application environment</param>
		public TableRow(android.content.Context context) : base(context)
		{
			initTableRow();
		}

		/// <summary>
		/// <p>Creates a new TableRow for the given context and with the
		/// specified set attributes.</p>
		/// </summary>
		/// <param name="context">the application environment</param>
		/// <param name="attrs">a collection of attributes</param>
		public TableRow(android.content.Context context, android.util.AttributeSet attrs)
			 : base(context, attrs)
		{
			initTableRow();
		}

		private void initTableRow()
		{
			android.view.ViewGroup.OnHierarchyChangeListener oldListener = mOnHierarchyChangeListener;
			mChildrenTracker = new android.widget.TableRow.ChildrenTracker(this);
			if (oldListener != null)
			{
				mChildrenTracker.setOnHierarchyChangeListener(oldListener);
			}
			base.setOnHierarchyChangeListener(mChildrenTracker);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void setOnHierarchyChangeListener(android.view.ViewGroup.OnHierarchyChangeListener
			 listener)
		{
			mChildrenTracker.setOnHierarchyChangeListener(listener);
		}

		/// <summary><p>Collapses or restores a given column.</p></summary>
		/// <param name="columnIndex">the index of the column</param>
		/// <param name="collapsed">
		/// true if the column must be collapsed, false otherwise
		/// <hide></hide>
		/// </param>
		internal virtual void setColumnCollapsed(int columnIndex, bool collapsed)
		{
			android.view.View child = getVirtualChildAt(columnIndex);
			if (child != null)
			{
				child.setVisibility(collapsed ? GONE : VISIBLE);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			// enforce horizontal layout
			measureHorizontal(widthMeasureSpec, heightMeasureSpec);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			// enforce horizontal layout
			layoutHorizontal();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override android.view.View getVirtualChildAt(int i)
		{
			if (mColumnToChildIndex == null)
			{
				mapIndexAndColumns();
			}
			int deflectedIndex = mColumnToChildIndex.get(i, -1);
			if (deflectedIndex != -1)
			{
				return getChildAt(deflectedIndex);
			}
			return null;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override int getVirtualChildCount()
		{
			if (mColumnToChildIndex == null)
			{
				mapIndexAndColumns();
			}
			return mNumColumns;
		}

		private void mapIndexAndColumns()
		{
			if (mColumnToChildIndex == null)
			{
				int virtualCount = 0;
				int count = getChildCount();
				mColumnToChildIndex = new android.util.SparseIntArray();
				android.util.SparseIntArray columnToChild = mColumnToChildIndex;
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = getChildAt(i);
						android.widget.TableRow.LayoutParams layoutParams = (android.widget.TableRow.LayoutParams
							)child.getLayoutParams();
						if (layoutParams.column >= virtualCount)
						{
							virtualCount = layoutParams.column;
						}
						{
							for (int j = 0; j < layoutParams.span; j++)
							{
								columnToChild.put(virtualCount++, i);
							}
						}
					}
				}
				mNumColumns = virtualCount;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override int measureNullChild(int childIndex)
		{
			return mConstrainedColumnWidths[childIndex];
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override void measureChildBeforeLayout(android.view.View child, int childIndex
			, int widthMeasureSpec, int totalWidth, int heightMeasureSpec, int totalHeight)
		{
			if (mConstrainedColumnWidths != null)
			{
				android.widget.TableRow.LayoutParams lp = (android.widget.TableRow.LayoutParams)child
					.getLayoutParams();
				int measureMode = android.view.View.MeasureSpec.EXACTLY;
				int columnWidth = 0;
				int span = lp.span;
				int[] constrainedColumnWidths = mConstrainedColumnWidths;
				{
					for (int i = 0; i < span; i++)
					{
						columnWidth += constrainedColumnWidths[childIndex + i];
					}
				}
				int gravity = lp.gravity;
				bool isHorizontalGravity = android.view.Gravity.isHorizontal(gravity);
				if (isHorizontalGravity)
				{
					measureMode = android.view.View.MeasureSpec.AT_MOST;
				}
				// no need to care about padding here,
				// ViewGroup.getChildMeasureSpec() would get rid of it anyway
				// because of the EXACTLY measure spec we use
				int childWidthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(System.Math.Max
					(0, columnWidth - lp.leftMargin - lp.rightMargin), measureMode);
				int childHeightMeasureSpec = getChildMeasureSpec(heightMeasureSpec, mPaddingTop +
					 mPaddingBottom + lp.topMargin + lp.bottomMargin + totalHeight, lp.height);
				child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
				if (isHorizontalGravity)
				{
					int childWidth = child.getMeasuredWidth();
					lp.mOffset[android.widget.TableRow.LayoutParams.LOCATION_NEXT] = columnWidth - childWidth;
					int layoutDirection = getResolvedLayoutDirection();
					int absoluteGravity = android.view.Gravity.getAbsoluteGravity(gravity, layoutDirection
						);
					switch (absoluteGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK)
					{
						case android.view.Gravity.LEFT:
						{
							// don't offset on X axis
							break;
						}

						case android.view.Gravity.RIGHT:
						{
							lp.mOffset[android.widget.TableRow.LayoutParams.LOCATION] = lp.mOffset[android.widget.TableRow
								.LayoutParams.LOCATION_NEXT];
							break;
						}

						case android.view.Gravity.CENTER_HORIZONTAL:
						{
							lp.mOffset[android.widget.TableRow.LayoutParams.LOCATION] = lp.mOffset[android.widget.TableRow
								.LayoutParams.LOCATION_NEXT] / 2;
							break;
						}
					}
				}
				else
				{
					lp.mOffset[android.widget.TableRow.LayoutParams.LOCATION] = lp.mOffset[android.widget.TableRow
						.LayoutParams.LOCATION_NEXT] = 0;
				}
			}
			else
			{
				// fail silently when column widths are not available
				base.measureChildBeforeLayout(child, childIndex, widthMeasureSpec, totalWidth, heightMeasureSpec
					, totalHeight);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override int getChildrenSkipCount(android.view.View child, int index)
		{
			android.widget.TableRow.LayoutParams layoutParams = (android.widget.TableRow.LayoutParams
				)child.getLayoutParams();
			// when the span is 1 (default), we need to skip 0 child
			return layoutParams.span - 1;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override int getLocationOffset(android.view.View child)
		{
			return ((android.widget.TableRow.LayoutParams)child.getLayoutParams()).mOffset[android.widget.TableRow
				.LayoutParams.LOCATION];
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override int getNextLocationOffset(android.view.View child)
		{
			return ((android.widget.TableRow.LayoutParams)child.getLayoutParams()).mOffset[android.widget.TableRow
				.LayoutParams.LOCATION_NEXT];
		}

		/// <summary><p>Measures the preferred width of each child, including its margins.</p>
		/// 	</summary>
		/// <param name="widthMeasureSpec">the width constraint imposed by our parent</param>
		/// <returns>
		/// an array of integers corresponding to the width of each cell, or
		/// column, in this row
		/// <hide></hide>
		/// </returns>
		internal virtual int[] getColumnsWidths(int widthMeasureSpec)
		{
			int numColumns = getVirtualChildCount();
			if (mColumnWidths == null || numColumns != mColumnWidths.Length)
			{
				mColumnWidths = new int[numColumns];
			}
			int[] columnWidths = mColumnWidths;
			{
				for (int i = 0; i < numColumns; i++)
				{
					android.view.View child = getVirtualChildAt(i);
					if (child != null && child.getVisibility() != GONE)
					{
						android.widget.TableRow.LayoutParams layoutParams = (android.widget.TableRow.LayoutParams
							)child.getLayoutParams();
						if (layoutParams.span == 1)
						{
							int spec;
							switch (layoutParams.width)
							{
								case android.view.ViewGroup.LayoutParams.WRAP_CONTENT:
								{
									spec = getChildMeasureSpec(widthMeasureSpec, 0, android.view.ViewGroup.LayoutParams
										.WRAP_CONTENT);
									break;
								}

								case android.view.ViewGroup.LayoutParams.MATCH_PARENT:
								{
									spec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View.MeasureSpec
										.UNSPECIFIED);
									break;
								}

								default:
								{
									spec = android.view.View.MeasureSpec.makeMeasureSpec(layoutParams.width, android.view.View
										.MeasureSpec.EXACTLY);
									break;
								}
							}
							child.measure(spec, spec);
							int width = child.getMeasuredWidth() + layoutParams.leftMargin + layoutParams.rightMargin;
							columnWidths[i] = width;
						}
						else
						{
							columnWidths[i] = 0;
						}
					}
					else
					{
						columnWidths[i] = 0;
					}
				}
			}
			return columnWidths;
		}

		/// <summary><p>Sets the width of all of the columns in this row.</summary>
		/// <remarks>
		/// <p>Sets the width of all of the columns in this row. At layout time,
		/// this row sets a fixed width, as defined by <code>columnWidths</code>,
		/// on each child (or cell, or column.)</p>
		/// </remarks>
		/// <param name="columnWidths">
		/// the fixed width of each column that this row must
		/// honor
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// when columnWidths' length is smaller
		/// than the number of children in this row
		/// <hide></hide>
		/// </exception>
		internal virtual void setColumnsWidthConstraints(int[] columnWidths)
		{
			if (columnWidths == null || columnWidths.Length < getVirtualChildCount())
			{
				throw new System.ArgumentException("columnWidths should be >= getVirtualChildCount()"
					);
			}
			mConstrainedColumnWidths = columnWidths;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.TableRow.LayoutParams(getContext(), attrs);
		}

		/// <summary>
		/// Returns a set of layout parameters with a width of
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
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
			return new android.widget.TableRow.LayoutParams();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.TableRow.LayoutParams;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.TableRow.LayoutParams(p);
		}

		/// <summary><p>Set of layout parameters used in table rows.</p></summary>
		/// <seealso cref="LayoutParams">LayoutParams</seealso>
		/// <attr>ref android.R.styleable#TableRow_Cell_layout_column</attr>
		/// <attr>ref android.R.styleable#TableRow_Cell_layout_span</attr>
		public class LayoutParams : android.widget.LinearLayout.LayoutParams
		{
			/// <summary><p>The column index of the cell represented by the widget.</p></summary>
			internal int column;

			/// <summary><p>The number of columns the widgets spans over.</p></summary>
			internal int span;

			internal const int LOCATION = 0;

			internal const int LOCATION_NEXT = 1;

			internal int[] mOffset = new int[2];

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
				android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.TableRow_Cell);
				column = a.getInt(android.@internal.R.styleable.TableRow_Cell_layout_column, -1);
				span = a.getInt(android.@internal.R.styleable.TableRow_Cell_layout_span, 1);
				if (span <= 1)
				{
					span = 1;
				}
				a.recycle();
			}

			/// <summary><p>Sets the child width and the child height.</p></summary>
			/// <param name="w">the desired width</param>
			/// <param name="h">the desired height</param>
			public LayoutParams(int w, int h) : base(w, h)
			{
				column = -1;
				span = 1;
			}

			/// <summary><p>Sets the child width, height and weight.</p></summary>
			/// <param name="w">the desired width</param>
			/// <param name="h">the desired height</param>
			/// <param name="initWeight">the desired weight</param>
			public LayoutParams(int w, int h, float initWeight) : base(w, h, initWeight)
			{
				column = -1;
				span = 1;
			}

			/// <summary>
			/// <p>Sets the child width to
			/// <see cref="android.view.ViewGroup.LayoutParams">android.view.ViewGroup.LayoutParams
			/// 	</see>
			/// and the child height to
			/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
			/// 	</see>
			/// .</p>
			/// </summary>
			internal LayoutParams() : base(MATCH_PARENT, WRAP_CONTENT)
			{
				column = -1;
				span = 1;
			}

			/// <summary>
			/// <p>Puts the view in the specified column.</p>
			/// <p>Sets the child width to
			/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
			/// 	</see>
			/// and the child height to
			/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
			/// 	</see>
			/// .</p>
			/// </summary>
			/// <param name="column">the column index for the view</param>
			public LayoutParams(int column) : this()
			{
				this.column = column;
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
			protected internal override void setBaseAttributes(android.content.res.TypedArray
				 a, int widthAttr, int heightAttr)
			{
				// We don't want to force users to specify a layout_width
				if (a.hasValue(widthAttr))
				{
					width = a.getLayoutDimension(widthAttr, "layout_width");
				}
				else
				{
					width = MATCH_PARENT;
				}
				// We don't want to force users to specify a layout_height
				if (a.hasValue(heightAttr))
				{
					height = a.getLayoutDimension(heightAttr, "layout_height");
				}
				else
				{
					height = WRAP_CONTENT;
				}
			}
		}

		private class ChildrenTracker : android.view.ViewGroup.OnHierarchyChangeListener
		{
			internal android.view.ViewGroup.OnHierarchyChangeListener listener;

			// special transparent hierarchy change listener
			internal void setOnHierarchyChangeListener(android.view.ViewGroup.OnHierarchyChangeListener
				 listener)
			{
				this.listener = listener;
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewGroup.OnHierarchyChangeListener")]
			public virtual void onChildViewAdded(android.view.View parent, android.view.View 
				child)
			{
				// dirties the index to column map
				this._enclosing.mColumnToChildIndex = null;
				if (this.listener != null)
				{
					this.listener.onChildViewAdded(parent, child);
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewGroup.OnHierarchyChangeListener")]
			public virtual void onChildViewRemoved(android.view.View parent, android.view.View
				 child)
			{
				// dirties the index to column map
				this._enclosing.mColumnToChildIndex = null;
				if (this.listener != null)
				{
					this.listener.onChildViewRemoved(parent, child);
				}
			}

			internal ChildrenTracker(TableRow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TableRow _enclosing;
		}
	}
}
