using Sharpen;

namespace android.widget
{
	/// <summary><p>A layout that arranges its children into rows and columns.</summary>
	/// <remarks>
	/// <p>A layout that arranges its children into rows and columns.
	/// A TableLayout consists of a number of
	/// <see cref="TableRow">TableRow</see>
	/// objects,
	/// each defining a row (actually, you can have other children, which will be
	/// explained below). TableLayout containers do not display border lines for
	/// their rows, columns, or cells. Each row has zero or more cells; each cell can
	/// hold one
	/// <see cref="android.view.View">View</see>
	/// object. The table has as many columns
	/// as the row with the most cells. A table can leave cells empty. Cells can span
	/// columns, as they can in HTML.</p>
	/// <p>The width of a column is defined by the row with the widest cell in that
	/// column. However, a TableLayout can specify certain columns as shrinkable or
	/// stretchable by calling
	/// <see cref="setColumnShrinkable(int, bool)">setColumnShrinkable()</see>
	/// or
	/// <see cref="setColumnStretchable(int, bool)">setColumnStretchable()</see>
	/// . If
	/// marked as shrinkable, the column width can be shrunk to fit the table into
	/// its parent object. If marked as stretchable, it can expand in width to fit
	/// any extra space. The total width of the table is defined by its parent
	/// container. It is important to remember that a column can be both shrinkable
	/// and stretchable. In such a situation, the column will change its size to
	/// always use up the available space, but never more. Finally, you can hide a
	/// column by calling
	/// <see cref="setColumnCollapsed(int, bool)">setColumnCollapsed()</see>
	/// .</p>
	/// <p>The children of a TableLayout cannot specify the <code>layout_width</code>
	/// attribute. Width is always <code>MATCH_PARENT</code>. However, the
	/// <code>layout_height</code> attribute can be defined by a child; default value
	/// is
	/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
	/// 	</see>
	/// . If the child
	/// is a
	/// <see cref="TableRow">TableRow</see>
	/// , then the height is always
	/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
	/// 	</see>
	/// .</p>
	/// <p> Cells must be added to a row in increasing column order, both in code and
	/// XML. Column numbers are zero-based. If you don't specify a column number for
	/// a child cell, it will autoincrement to the next available column. If you skip
	/// a column number, it will be considered an empty cell in that row. See the
	/// TableLayout examples in ApiDemos for examples of creating tables in XML.</p>
	/// <p>Although the typical child of a TableLayout is a TableRow, you can
	/// actually use any View subclass as a direct child of TableLayout. The View
	/// will be displayed as a single row that spans all the table columns.</p>
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-tablelayout.html"&gt;Table
	/// Layout tutorial</a>.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class TableLayout : android.widget.LinearLayout
	{
		private int[] mMaxWidths;

		private android.util.SparseBooleanArray mStretchableColumns;

		private android.util.SparseBooleanArray mShrinkableColumns;

		private android.util.SparseBooleanArray mCollapsedColumns;

		private bool mShrinkAllColumns;

		private bool mStretchAllColumns;

		private android.widget.TableLayout.PassThroughHierarchyChangeListener mPassThroughListener;

		private bool mInitialized;

		/// <summary><p>Creates a new TableLayout for the given context.</p></summary>
		/// <param name="context">the application environment</param>
		public TableLayout(android.content.Context context) : base(context)
		{
			initTableLayout();
		}

		/// <summary>
		/// <p>Creates a new TableLayout for the given context and with the
		/// specified set attributes.</p>
		/// </summary>
		/// <param name="context">the application environment</param>
		/// <param name="attrs">a collection of attributes</param>
		public TableLayout(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.TableLayout);
			string stretchedColumns = a.getString(android.@internal.R.styleable.TableLayout_stretchColumns
				);
			if (stretchedColumns != null)
			{
				if (stretchedColumns[0] == '*')
				{
					mStretchAllColumns = true;
				}
				else
				{
					mStretchableColumns = parseColumns(stretchedColumns);
				}
			}
			string shrinkedColumns = a.getString(android.@internal.R.styleable.TableLayout_shrinkColumns
				);
			if (shrinkedColumns != null)
			{
				if (shrinkedColumns[0] == '*')
				{
					mShrinkAllColumns = true;
				}
				else
				{
					mShrinkableColumns = parseColumns(shrinkedColumns);
				}
			}
			string collapsedColumns = a.getString(android.@internal.R.styleable.TableLayout_collapseColumns
				);
			if (collapsedColumns != null)
			{
				mCollapsedColumns = parseColumns(collapsedColumns);
			}
			a.recycle();
			initTableLayout();
		}

		/// <summary>
		/// <p>Parses a sequence of columns ids defined in a CharSequence with the
		/// following pattern (regex): \d+(\s*,\s*\d+)*</p>
		/// <p>Examples: "1" or "13, 7, 6" or "".</p>
		/// <p>The result of the parsing is stored in a sparse boolean array.
		/// </summary>
		/// <remarks>
		/// <p>Parses a sequence of columns ids defined in a CharSequence with the
		/// following pattern (regex): \d+(\s*,\s*\d+)*</p>
		/// <p>Examples: "1" or "13, 7, 6" or "".</p>
		/// <p>The result of the parsing is stored in a sparse boolean array. The
		/// parsed column ids are used as the keys of the sparse array. The values
		/// are always true.</p>
		/// </remarks>
		/// <param name="sequence">a sequence of column ids, can be empty but not null</param>
		/// <returns>
		/// a sparse array of boolean mapping column indexes to the columns
		/// collapse state
		/// </returns>
		private static android.util.SparseBooleanArray parseColumns(string sequence)
		{
			android.util.SparseBooleanArray columns = new android.util.SparseBooleanArray();
			java.util.regex.Pattern pattern = java.util.regex.Pattern.compile("\\s*,\\s*");
			string[] columnDefs = pattern.split(java.lang.CharSequenceProxy.Wrap(sequence));
			foreach (string columnIdentifier in columnDefs)
			{
				try
				{
					int columnIndex = System.Convert.ToInt32(columnIdentifier);
					// only valid, i.e. positive, columns indexes are handled
					if (columnIndex >= 0)
					{
						// putting true in this sparse array indicates that the
						// column index was defined in the XML file
						columns.put(columnIndex, true);
					}
				}
				catch (System.ArgumentException)
				{
				}
			}
			// we just ignore columns that don't exist
			return columns;
		}

		/// <summary>
		/// <p>Performs initialization common to prorgrammatic use and XML use of
		/// this widget.</p>
		/// </summary>
		private void initTableLayout()
		{
			if (mCollapsedColumns == null)
			{
				mCollapsedColumns = new android.util.SparseBooleanArray();
			}
			if (mStretchableColumns == null)
			{
				mStretchableColumns = new android.util.SparseBooleanArray();
			}
			if (mShrinkableColumns == null)
			{
				mShrinkableColumns = new android.util.SparseBooleanArray();
			}
			mPassThroughListener = new android.widget.TableLayout.PassThroughHierarchyChangeListener
				(this);
			// make sure to call the parent class method to avoid potential
			// infinite loops
			base.setOnHierarchyChangeListener(mPassThroughListener);
			mInitialized = true;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void setOnHierarchyChangeListener(android.view.ViewGroup.OnHierarchyChangeListener
			 listener)
		{
			// the user listener is delegated to our pass-through listener
			mPassThroughListener.mOnHierarchyChangeListener = listener;
		}

		private void requestRowsLayout()
		{
			if (mInitialized)
			{
				int count = getChildCount();
				{
					for (int i = 0; i < count; i++)
					{
						getChildAt(i).requestLayout();
					}
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void requestLayout()
		{
			if (mInitialized)
			{
				int count = getChildCount();
				{
					for (int i = 0; i < count; i++)
					{
						getChildAt(i).forceLayout();
					}
				}
			}
			base.requestLayout();
		}

		/// <summary><p>Indicates whether all columns are shrinkable or not.</p></summary>
		/// <returns>true if all columns are shrinkable, false otherwise</returns>
		public virtual bool isShrinkAllColumns()
		{
			return mShrinkAllColumns;
		}

		/// <summary><p>Convenience method to mark all columns as shrinkable.</p></summary>
		/// <param name="shrinkAllColumns">true to mark all columns shrinkable</param>
		/// <attr>ref android.R.styleable#TableLayout_shrinkColumns</attr>
		public virtual void setShrinkAllColumns(bool shrinkAllColumns)
		{
			mShrinkAllColumns = shrinkAllColumns;
		}

		/// <summary><p>Indicates whether all columns are stretchable or not.</p></summary>
		/// <returns>true if all columns are stretchable, false otherwise</returns>
		public virtual bool isStretchAllColumns()
		{
			return mStretchAllColumns;
		}

		/// <summary><p>Convenience method to mark all columns as stretchable.</p></summary>
		/// <param name="stretchAllColumns">true to mark all columns stretchable</param>
		/// <attr>ref android.R.styleable#TableLayout_stretchColumns</attr>
		public virtual void setStretchAllColumns(bool stretchAllColumns)
		{
			mStretchAllColumns = stretchAllColumns;
		}

		/// <summary><p>Collapses or restores a given column.</summary>
		/// <remarks>
		/// <p>Collapses or restores a given column. When collapsed, a column
		/// does not appear on screen and the extra space is reclaimed by the
		/// other columns. A column is collapsed/restored only when it belongs to
		/// a
		/// <see cref="TableRow">TableRow</see>
		/// .</p>
		/// <p>Calling this method requests a layout operation.</p>
		/// </remarks>
		/// <param name="columnIndex">the index of the column</param>
		/// <param name="isCollapsed">true if the column must be collapsed, false otherwise</param>
		/// <attr>ref android.R.styleable#TableLayout_collapseColumns</attr>
		public virtual void setColumnCollapsed(int columnIndex, bool isCollapsed)
		{
			// update the collapse status of the column
			mCollapsedColumns.put(columnIndex, isCollapsed);
			int count = getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View view = getChildAt(i);
					if (view is android.widget.TableRow)
					{
						((android.widget.TableRow)view).setColumnCollapsed(columnIndex, isCollapsed);
					}
				}
			}
			requestRowsLayout();
		}

		/// <summary><p>Returns the collapsed state of the specified column.</p></summary>
		/// <param name="columnIndex">the index of the column</param>
		/// <returns>true if the column is collapsed, false otherwise</returns>
		public virtual bool isColumnCollapsed(int columnIndex)
		{
			return mCollapsedColumns.get(columnIndex);
		}

		/// <summary><p>Makes the given column stretchable or not.</summary>
		/// <remarks>
		/// <p>Makes the given column stretchable or not. When stretchable, a column
		/// takes up as much as available space as possible in its row.</p>
		/// <p>Calling this method requests a layout operation.</p>
		/// </remarks>
		/// <param name="columnIndex">the index of the column</param>
		/// <param name="isStretchable">
		/// true if the column must be stretchable,
		/// false otherwise. Default is false.
		/// </param>
		/// <attr>ref android.R.styleable#TableLayout_stretchColumns</attr>
		public virtual void setColumnStretchable(int columnIndex, bool isStretchable)
		{
			mStretchableColumns.put(columnIndex, isStretchable);
			requestRowsLayout();
		}

		/// <summary><p>Returns whether the specified column is stretchable or not.</p></summary>
		/// <param name="columnIndex">the index of the column</param>
		/// <returns>true if the column is stretchable, false otherwise</returns>
		public virtual bool isColumnStretchable(int columnIndex)
		{
			return mStretchAllColumns || mStretchableColumns.get(columnIndex);
		}

		/// <summary><p>Makes the given column shrinkable or not.</summary>
		/// <remarks>
		/// <p>Makes the given column shrinkable or not. When a row is too wide, the
		/// table can reclaim extra space from shrinkable columns.</p>
		/// <p>Calling this method requests a layout operation.</p>
		/// </remarks>
		/// <param name="columnIndex">the index of the column</param>
		/// <param name="isShrinkable">
		/// true if the column must be shrinkable,
		/// false otherwise. Default is false.
		/// </param>
		/// <attr>ref android.R.styleable#TableLayout_shrinkColumns</attr>
		public virtual void setColumnShrinkable(int columnIndex, bool isShrinkable)
		{
			mShrinkableColumns.put(columnIndex, isShrinkable);
			requestRowsLayout();
		}

		/// <summary><p>Returns whether the specified column is shrinkable or not.</p></summary>
		/// <param name="columnIndex">the index of the column</param>
		/// <returns>true if the column is shrinkable, false otherwise. Default is false.</returns>
		public virtual bool isColumnShrinkable(int columnIndex)
		{
			return mShrinkAllColumns || mShrinkableColumns.get(columnIndex);
		}

		/// <summary>
		/// <p>Applies the columns collapse status to a new row added to this
		/// table.
		/// </summary>
		/// <remarks>
		/// <p>Applies the columns collapse status to a new row added to this
		/// table. This method is invoked by PassThroughHierarchyChangeListener
		/// upon child insertion.</p>
		/// <p>This method only applies to
		/// <see cref="TableRow">TableRow</see>
		/// instances.</p>
		/// </remarks>
		/// <param name="child">the newly added child</param>
		private void trackCollapsedColumns(android.view.View child)
		{
			if (child is android.widget.TableRow)
			{
				android.widget.TableRow row = (android.widget.TableRow)child;
				android.util.SparseBooleanArray collapsedColumns = mCollapsedColumns;
				int count = collapsedColumns.size();
				{
					for (int i = 0; i < count; i++)
					{
						int columnIndex = collapsedColumns.keyAt(i);
						bool isCollapsed = collapsedColumns.valueAt(i);
						// the collapse status is set only when the column should be
						// collapsed; otherwise, this might affect the default
						// visibility of the row's children
						if (isCollapsed)
						{
							row.setColumnCollapsed(columnIndex, isCollapsed);
						}
					}
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child)
		{
			base.addView(child);
			requestRowsLayout();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index)
		{
			base.addView(child, index);
			requestRowsLayout();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, android.view.ViewGroup.LayoutParams
			 @params)
		{
			base.addView(child, @params);
			requestRowsLayout();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			base.addView(child, index, @params);
			requestRowsLayout();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			// enforce vertical layout
			measureVertical(widthMeasureSpec, heightMeasureSpec);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			// enforce vertical layout
			layoutVertical();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override void measureChildBeforeLayout(android.view.View child, int childIndex
			, int widthMeasureSpec, int totalWidth, int heightMeasureSpec, int totalHeight)
		{
			// when the measured child is a table row, we force the width of its
			// children with the widths computed in findLargestCells()
			if (child is android.widget.TableRow)
			{
				((android.widget.TableRow)child).setColumnsWidthConstraints(mMaxWidths);
			}
			base.measureChildBeforeLayout(child, childIndex, widthMeasureSpec, totalWidth, heightMeasureSpec
				, totalHeight);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override void measureVertical(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			findLargestCells(widthMeasureSpec);
			shrinkAndStretchColumns(widthMeasureSpec);
			base.measureVertical(widthMeasureSpec, heightMeasureSpec);
		}

		/// <summary><p>Finds the largest cell in each column.</summary>
		/// <remarks>
		/// <p>Finds the largest cell in each column. For each column, the width of
		/// the largest cell is applied to all the other cells.</p>
		/// </remarks>
		/// <param name="widthMeasureSpec">the measure constraint imposed by our parent</param>
		private void findLargestCells(int widthMeasureSpec)
		{
			bool firstRow = true;
			// find the maximum width for each column
			// the total number of columns is dynamically changed if we find
			// wider rows as we go through the children
			// the array is reused for each layout operation; the array can grow
			// but never shrinks. Unused extra cells in the array are just ignored
			// this behavior avoids to unnecessary grow the array after the first
			// layout operation
			int count = getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() == GONE)
					{
						continue;
					}
					if (child is android.widget.TableRow)
					{
						android.widget.TableRow row = (android.widget.TableRow)child;
						// forces the row's height
						android.view.ViewGroup.LayoutParams layoutParams = row.getLayoutParams();
						layoutParams.height = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
						int[] widths = row.getColumnsWidths(widthMeasureSpec);
						int newLength = widths.Length;
						// this is the first row, we just need to copy the values
						if (firstRow)
						{
							if (mMaxWidths == null || mMaxWidths.Length != newLength)
							{
								mMaxWidths = new int[newLength];
							}
							System.Array.Copy(widths, 0, mMaxWidths, 0, newLength);
							firstRow = false;
						}
						else
						{
							int length = mMaxWidths.Length;
							int difference = newLength - length;
							// the current row is wider than the previous rows, so
							// we just grow the array and copy the values
							if (difference > 0)
							{
								int[] oldMaxWidths = mMaxWidths;
								mMaxWidths = new int[newLength];
								System.Array.Copy(oldMaxWidths, 0, mMaxWidths, 0, oldMaxWidths.Length);
								System.Array.Copy(widths, oldMaxWidths.Length, mMaxWidths, oldMaxWidths.Length, difference
									);
							}
							// the row is narrower or of the same width as the previous
							// rows, so we find the maximum width for each column
							// if the row is narrower than the previous ones,
							// difference will be negative
							int[] maxWidths = mMaxWidths;
							length = System.Math.Min(length, newLength);
							{
								for (int j = 0; j < length; j++)
								{
									maxWidths[j] = System.Math.Max(maxWidths[j], widths[j]);
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// <p>Shrinks the columns if their total width is greater than the
		/// width allocated by widthMeasureSpec.
		/// </summary>
		/// <remarks>
		/// <p>Shrinks the columns if their total width is greater than the
		/// width allocated by widthMeasureSpec. When the total width is less
		/// than the allocated width, this method attempts to stretch columns
		/// to fill the remaining space.</p>
		/// </remarks>
		/// <param name="widthMeasureSpec">
		/// the width measure specification as indicated
		/// by this widget's parent
		/// </param>
		private void shrinkAndStretchColumns(int widthMeasureSpec)
		{
			// when we have no row, mMaxWidths is not initialized and the loop
			// below could cause a NPE
			if (mMaxWidths == null)
			{
				return;
			}
			// should we honor AT_MOST, EXACTLY and UNSPECIFIED?
			int totalWidth = 0;
			foreach (int width in mMaxWidths)
			{
				totalWidth += width;
			}
			int size = android.view.View.MeasureSpec.getSize(widthMeasureSpec) - mPaddingLeft
				 - mPaddingRight;
			if ((totalWidth > size) && (mShrinkAllColumns || mShrinkableColumns.size() > 0))
			{
				// oops, the largest columns are wider than the row itself
				// fairly redistribute the row's width among the columns
				mutateColumnsWidth(mShrinkableColumns, mShrinkAllColumns, size, totalWidth);
			}
			else
			{
				if ((totalWidth < size) && (mStretchAllColumns || mStretchableColumns.size() > 0))
				{
					// if we have some space left, we distribute it among the
					// expandable columns
					mutateColumnsWidth(mStretchableColumns, mStretchAllColumns, size, totalWidth);
				}
			}
		}

		private void mutateColumnsWidth(android.util.SparseBooleanArray columns, bool allColumns
			, int size, int totalWidth)
		{
			int skipped = 0;
			int[] maxWidths = mMaxWidths;
			int length = maxWidths.Length;
			int count = allColumns ? length : columns.size();
			int totalExtraSpace = size - totalWidth;
			int extraSpace = totalExtraSpace / count;
			// Column's widths are changed: force child table rows to re-measure.
			// (done by super.measureVertical after shrinkAndStretchColumns.)
			int nbChildren = getChildCount();
			{
				for (int i = 0; i < nbChildren; i++)
				{
					android.view.View child = getChildAt(i);
					if (child is android.widget.TableRow)
					{
						child.forceLayout();
					}
				}
			}
			if (!allColumns)
			{
				{
					for (int i_1 = 0; i_1 < count; i_1++)
					{
						int column = columns.keyAt(i_1);
						if (columns.valueAt(i_1))
						{
							if (column < length)
							{
								maxWidths[column] += extraSpace;
							}
							else
							{
								skipped++;
							}
						}
					}
				}
			}
			else
			{
				{
					for (int i_1 = 0; i_1 < count; i_1++)
					{
						maxWidths[i_1] += extraSpace;
					}
				}
				// we don't skip any column so we can return right away
				return;
			}
			if (skipped > 0 && skipped < count)
			{
				// reclaim any extra space we left to columns that don't exist
				extraSpace = skipped * extraSpace / (count - skipped);
				{
					for (int i_1 = 0; i_1 < count; i_1++)
					{
						int column = columns.keyAt(i_1);
						if (columns.valueAt(i_1) && column < length)
						{
							if (extraSpace > maxWidths[column])
							{
								maxWidths[column] = 0;
							}
							else
							{
								maxWidths[column] += extraSpace;
							}
						}
					}
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.TableLayout.LayoutParams(getContext(), attrs);
		}

		/// <summary>
		/// Returns a set of layout parameters with a width of
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// ,
		/// and a height of
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// .
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.widget.TableLayout.LayoutParams();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.TableLayout.LayoutParams;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.TableLayout.LayoutParams(p);
		}

		/// <summary>
		/// <p>This set of layout parameters enforces the width of each child to be
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// and the height of each child to be
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// , but only if the height is not specified.</p>
		/// </summary>
		public class LayoutParams : android.widget.LinearLayout.LayoutParams
		{
			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(int w, int h) : base(MATCH_PARENT, h)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(int w, int h, float initWeight) : base(MATCH_PARENT, h, initWeight
				)
			{
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

			/// <summary>
			/// <p>Fixes the row's width to
			/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
			/// 	</see>
			/// ; the row's
			/// height is fixed to
			/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
			/// 	</see>
			/// if no layout
			/// height is specified.</p>
			/// </summary>
			/// <param name="a">the styled attributes set</param>
			/// <param name="widthAttr">the width attribute to fetch</param>
			/// <param name="heightAttr">the height attribute to fetch</param>
			[Sharpen.OverridesMethod(@"android.view.ViewGroup.LayoutParams")]
			protected internal override void setBaseAttributes(android.content.res.TypedArray
				 a, int widthAttr, int heightAttr)
			{
				this.width = MATCH_PARENT;
				if (a.hasValue(heightAttr))
				{
					this.height = a.getLayoutDimension(heightAttr, "layout_height");
				}
				else
				{
					this.height = WRAP_CONTENT;
				}
			}
		}

		/// <summary>
		/// <p>A pass-through listener acts upon the events and dispatches them
		/// to another listener.
		/// </summary>
		/// <remarks>
		/// <p>A pass-through listener acts upon the events and dispatches them
		/// to another listener. This allows the table layout to set its own internal
		/// hierarchy change listener without preventing the user to setup his.</p>
		/// </remarks>
		private class PassThroughHierarchyChangeListener : android.view.ViewGroup.OnHierarchyChangeListener
		{
			internal android.view.ViewGroup.OnHierarchyChangeListener mOnHierarchyChangeListener;

			/// <summary><inheritDoc></inheritDoc></summary>
			[Sharpen.ImplementsInterface(@"android.view.ViewGroup.OnHierarchyChangeListener")]
			public virtual void onChildViewAdded(android.view.View parent, android.view.View 
				child)
			{
				this._enclosing.trackCollapsedColumns(child);
				if (this.mOnHierarchyChangeListener != null)
				{
					this.mOnHierarchyChangeListener.onChildViewAdded(parent, child);
				}
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			[Sharpen.ImplementsInterface(@"android.view.ViewGroup.OnHierarchyChangeListener")]
			public virtual void onChildViewRemoved(android.view.View parent, android.view.View
				 child)
			{
				if (this.mOnHierarchyChangeListener != null)
				{
					this.mOnHierarchyChangeListener.onChildViewRemoved(parent, child);
				}
			}

			internal PassThroughHierarchyChangeListener(TableLayout _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TableLayout _enclosing;
		}
	}
}
