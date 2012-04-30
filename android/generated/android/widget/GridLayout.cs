using Sharpen;

namespace android.widget
{
	/// <summary>A layout that places its children in a rectangular <em>grid</em>.</summary>
	/// <remarks>
	/// A layout that places its children in a rectangular <em>grid</em>.
	/// <p>
	/// The grid is composed of a set of infinitely thin lines that separate the
	/// viewing area into <em>cells</em>. Throughout the API, grid lines are referenced
	/// by grid <em>indices</em>. A grid with
	/// <code>N</code>
	/// columns
	/// has
	/// <code>N + 1</code>
	/// grid indices that run from
	/// <code>0</code>
	/// through
	/// <code>N</code>
	/// inclusive. Regardless of how GridLayout is
	/// configured, grid index
	/// <code>0</code>
	/// is fixed to the leading edge of the
	/// container and grid index
	/// <code>N</code>
	/// is fixed to its trailing edge
	/// (after padding is taken into account).
	/// <h4>Row and Column Specs</h4>
	/// Children occupy one or more contiguous cells, as defined
	/// by their
	/// <see cref="LayoutParams.rowSpec">rowSpec</see>
	/// and
	/// <see cref="LayoutParams.columnSpec">columnSpec</see>
	/// layout parameters.
	/// Each spec defines the set of rows or columns that are to be
	/// occupied; and how children should be aligned within the resulting group of cells.
	/// Although cells do not normally overlap in a GridLayout, GridLayout does
	/// not prevent children being defined to occupy the same cell or group of cells.
	/// In this case however, there is no guarantee that children will not themselves
	/// overlap after the layout operation completes.
	/// <h4>Default Cell Assignment</h4>
	/// If a child does not specify the row and column indices of the cell it
	/// wishes to occupy, GridLayout assigns cell locations automatically using its:
	/// <see cref="setOrientation(int)">orientation</see>
	/// ,
	/// <see cref="setRowCount(int)">rowCount</see>
	/// and
	/// <see cref="setColumnCount(int)">columnCount</see>
	/// properties.
	/// <h4>Space</h4>
	/// Space between children may be specified either by using instances of the
	/// dedicated
	/// <see cref="Space">Space</see>
	/// view or by setting the
	/// <see cref="android.view.ViewGroup.MarginLayoutParams.leftMargin">leftMargin</see>
	/// ,
	/// <see cref="android.view.ViewGroup.MarginLayoutParams.topMargin">topMargin</see>
	/// ,
	/// <see cref="android.view.ViewGroup.MarginLayoutParams.rightMargin">rightMargin</see>
	/// and
	/// <see cref="android.view.ViewGroup.MarginLayoutParams.bottomMargin">bottomMargin</see>
	/// layout parameters. When the
	/// <see cref="setUseDefaultMargins(bool)">useDefaultMargins</see>
	/// property is set, default margins around children are automatically
	/// allocated based on the prevailing UI style guide for the platform.
	/// Each of the margins so defined may be independently overridden by an assignment
	/// to the appropriate layout parameter.
	/// Default values will generally produce a reasonable spacing between components
	/// but values may change between different releases of the platform.
	/// <h4>Excess Space Distribution</h4>
	/// GridLayout's distribution of excess space is based on <em>priority</em>
	/// rather than <em>weight</em>.
	/// <p>
	/// A child's ability to stretch is inferred from the alignment properties of
	/// its row and column groups (which are typically set by setting the
	/// <see cref="LayoutParams.setGravity(int)">gravity</see>
	/// property of the child's layout parameters).
	/// If alignment was defined along a given axis then the component
	/// is taken as <em>flexible</em> in that direction. If no alignment was set,
	/// the component is instead assumed to be <em>inflexible</em>.
	/// <p>
	/// Multiple components in the same row or column group are
	/// considered to act in <em>parallel</em>. Such a
	/// group is flexible only if <em>all</em> of the components
	/// within it are flexible. Row and column groups that sit either side of a common boundary
	/// are instead considered to act in <em>series</em>. The composite group made of these two
	/// elements is flexible if <em>one</em> of its elements is flexible.
	/// <p>
	/// To make a column stretch, make sure all of the components inside it define a
	/// gravity. To prevent a column from stretching, ensure that one of the components
	/// in the column does not define a gravity.
	/// <p>
	/// When the principle of flexibility does not provide complete disambiguation,
	/// GridLayout's algorithms favour rows and columns that are closer to its <em>right</em>
	/// and <em>bottom</em> edges.
	/// <h5>Limitations</h5>
	/// GridLayout does not provide support for the principle of <em>weight</em>, as defined in
	/// <see cref="LayoutParams.weight">LayoutParams.weight</see>
	/// . In general, it is not therefore possible
	/// to configure a GridLayout to distribute excess space in non-trivial proportions between
	/// multiple rows or columns.
	/// <p>
	/// Some common use-cases may nevertheless be accommodated as follows.
	/// To place equal amounts of space around a component in a cell group;
	/// use
	/// <see cref="CENTER">CENTER</see>
	/// alignment (or
	/// <see cref="LayoutParams.setGravity(int)">gravity</see>
	/// ).
	/// For complete control over excess space distribution in a row or column;
	/// use a
	/// <see cref="LinearLayout">LinearLayout</see>
	/// subview to hold the components in the associated cell group.
	/// When using either of these techniques, bear in mind that cell groups may be defined to overlap.
	/// <p>
	/// See
	/// <see cref="LayoutParams">LayoutParams</see>
	/// for a full description of the
	/// layout parameters used by GridLayout.
	/// </remarks>
	/// <attr>ref android.R.styleable#GridLayout_orientation</attr>
	/// <attr>ref android.R.styleable#GridLayout_rowCount</attr>
	/// <attr>ref android.R.styleable#GridLayout_columnCount</attr>
	/// <attr>ref android.R.styleable#GridLayout_useDefaultMargins</attr>
	/// <attr>ref android.R.styleable#GridLayout_rowOrderPreserved</attr>
	/// <attr>ref android.R.styleable#GridLayout_columnOrderPreserved</attr>
	[Sharpen.Sharpened]
	public class GridLayout : android.view.ViewGroup
	{
		/// <summary>The horizontal orientation.</summary>
		/// <remarks>The horizontal orientation.</remarks>
		public const int HORIZONTAL = android.widget.LinearLayout.HORIZONTAL;

		/// <summary>The vertical orientation.</summary>
		/// <remarks>The vertical orientation.</remarks>
		public const int VERTICAL = android.widget.LinearLayout.VERTICAL;

		/// <summary>The constant used to indicate that a value is undefined.</summary>
		/// <remarks>
		/// The constant used to indicate that a value is undefined.
		/// Fields can use this value to indicate that their values
		/// have not yet been set. Similarly, methods can return this value
		/// to indicate that there is no suitable value that the implementation
		/// can return.
		/// The value used for the constant (currently
		/// <see cref="int.MinValue">int.MinValue</see>
		/// ) is
		/// intended to avoid confusion between valid values whose sign may not be known.
		/// </remarks>
		public const int UNDEFINED = int.MinValue;

		/// <summary>
		/// This constant is an
		/// <see cref="setAlignmentMode(int)">alignmentMode</see>
		/// .
		/// When the
		/// <code>alignmentMode</code>
		/// is set to
		/// <see cref="ALIGN_BOUNDS">ALIGN_BOUNDS</see>
		/// , alignment
		/// is made between the edges of each component's raw
		/// view boundary: i.e. the area delimited by the component's:
		/// <see cref="android.view.View.getTop()">top</see>
		/// ,
		/// <see cref="android.view.View.getLeft()">left</see>
		/// ,
		/// <see cref="android.view.View.getBottom()">bottom</see>
		/// and
		/// <see cref="android.view.View.getRight()">right</see>
		/// properties.
		/// <p>
		/// For example, when
		/// <code>GridLayout</code>
		/// is in
		/// <see cref="ALIGN_BOUNDS">ALIGN_BOUNDS</see>
		/// mode,
		/// children that belong to a row group that uses
		/// <see cref="TOP">TOP</see>
		/// alignment will
		/// all return the same value when their
		/// <see cref="android.view.View.getTop()">android.view.View.getTop()</see>
		/// method is called.
		/// </summary>
		/// <seealso cref="setAlignmentMode(int)">setAlignmentMode(int)</seealso>
		public const int ALIGN_BOUNDS = 0;

		/// <summary>
		/// This constant is an
		/// <see cref="setAlignmentMode(int)">alignmentMode</see>
		/// .
		/// When the
		/// <code>alignmentMode</code>
		/// is set to
		/// <see cref="ALIGN_MARGINS">ALIGN_MARGINS</see>
		/// ,
		/// the bounds of each view are extended outwards, according
		/// to their margins, before the edges of the resulting rectangle are aligned.
		/// <p>
		/// For example, when
		/// <code>GridLayout</code>
		/// is in
		/// <see cref="ALIGN_MARGINS">ALIGN_MARGINS</see>
		/// mode,
		/// the quantity
		/// <code>top - layoutParams.topMargin</code>
		/// is the same for all children that
		/// belong to a row group that uses
		/// <see cref="TOP">TOP</see>
		/// alignment.
		/// </summary>
		/// <seealso cref="setAlignmentMode(int)">setAlignmentMode(int)</seealso>
		public const int ALIGN_MARGINS = 1;

		internal static readonly string TAG = typeof(android.widget.GridLayout).FullName;

		internal const bool DEBUG = false;

		internal const int PRF = 1;

		internal const int MAX_SIZE = 100000;

		internal const int DEFAULT_CONTAINER_MARGIN = 0;

		internal const int DEFAULT_ORIENTATION = HORIZONTAL;

		internal const int DEFAULT_COUNT = UNDEFINED;

		internal const bool DEFAULT_USE_DEFAULT_MARGINS = false;

		internal const bool DEFAULT_ORDER_PRESERVED = true;

		internal const int DEFAULT_ALIGNMENT_MODE = ALIGN_MARGINS;

		internal const int ORIENTATION = android.@internal.R.styleable.GridLayout_orientation;

		internal const int ROW_COUNT = android.@internal.R.styleable.GridLayout_rowCount;

		internal const int COLUMN_COUNT = android.@internal.R.styleable.GridLayout_columnCount;

		internal const int USE_DEFAULT_MARGINS = android.@internal.R.styleable.GridLayout_useDefaultMargins;

		internal const int ALIGNMENT_MODE = android.@internal.R.styleable.GridLayout_alignmentMode;

		internal const int ROW_ORDER_PRESERVED = android.@internal.R.styleable.GridLayout_rowOrderPreserved;

		internal const int COLUMN_ORDER_PRESERVED = android.@internal.R.styleable.GridLayout_columnOrderPreserved;

		internal readonly android.widget.GridLayout.Axis horizontalAxis;

		internal readonly android.widget.GridLayout.Axis verticalAxis;

		internal bool layoutParamsValid = false;

		internal int orientation = DEFAULT_ORIENTATION;

		internal bool useDefaultMargins = DEFAULT_USE_DEFAULT_MARGINS;

		internal int alignmentMode = DEFAULT_ALIGNMENT_MODE;

		internal int defaultGap;

		/// <summary><inheritDoc></inheritDoc></summary>
		public GridLayout(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			horizontalAxis = new android.widget.GridLayout.Axis(this, true);
			verticalAxis = new android.widget.GridLayout.Axis(this, false);
			// Public constants
			// Misc constants
			// Defaults
			// TypedArray indices
			// Instance variables
			// Constructors
			defaultGap = context.getResources().getDimensionPixelOffset(android.@internal.R.dimen
				.default_gap);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.GridLayout);
			try
			{
				setRowCount(a.getInt(ROW_COUNT, DEFAULT_COUNT));
				setColumnCount(a.getInt(COLUMN_COUNT, DEFAULT_COUNT));
				setOrientation(a.getInt(ORIENTATION, DEFAULT_ORIENTATION));
				setUseDefaultMargins(a.getBoolean(USE_DEFAULT_MARGINS, DEFAULT_USE_DEFAULT_MARGINS
					));
				setAlignmentMode(a.getInt(ALIGNMENT_MODE, DEFAULT_ALIGNMENT_MODE));
				setRowOrderPreserved(a.getBoolean(ROW_ORDER_PRESERVED, DEFAULT_ORDER_PRESERVED));
				setColumnOrderPreserved(a.getBoolean(COLUMN_ORDER_PRESERVED, DEFAULT_ORDER_PRESERVED
					));
			}
			finally
			{
				a.recycle();
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public GridLayout(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			horizontalAxis = new android.widget.GridLayout.Axis(this, true);
			verticalAxis = new android.widget.GridLayout.Axis(this, false);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public GridLayout(android.content.Context context) : this(context, null)
		{
			horizontalAxis = new android.widget.GridLayout.Axis(this, true);
			verticalAxis = new android.widget.GridLayout.Axis(this, false);
		}

		//noinspection NullableProblems
		// Implementation
		/// <summary>Returns the current orientation.</summary>
		/// <remarks>Returns the current orientation.</remarks>
		/// <returns>
		/// either
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// or
		/// <see cref="VERTICAL">VERTICAL</see>
		/// </returns>
		/// <seealso cref="setOrientation(int)">setOrientation(int)</seealso>
		/// <attr>ref android.R.styleable#GridLayout_orientation</attr>
		public virtual int getOrientation()
		{
			return orientation;
		}

		/// <summary>
		/// Orientation is used only to generate default row/column indices when
		/// they are not specified by a component's layout parameters.
		/// </summary>
		/// <remarks>
		/// Orientation is used only to generate default row/column indices when
		/// they are not specified by a component's layout parameters.
		/// <p>
		/// The default value of this property is
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// .
		/// </remarks>
		/// <param name="orientation">
		/// either
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// or
		/// <see cref="VERTICAL">VERTICAL</see>
		/// </param>
		/// <seealso cref="getOrientation()">getOrientation()</seealso>
		/// <attr>ref android.R.styleable#GridLayout_orientation</attr>
		public virtual void setOrientation(int orientation)
		{
			if (this.orientation != orientation)
			{
				this.orientation = orientation;
				invalidateStructure();
				requestLayout();
			}
		}

		/// <summary>Returns the current number of rows.</summary>
		/// <remarks>
		/// Returns the current number of rows. This is either the last value that was set
		/// with
		/// <see cref="setRowCount(int)">setRowCount(int)</see>
		/// or, if no such value was set, the maximum
		/// value of each the upper bounds defined in
		/// <see cref="LayoutParams.rowSpec">LayoutParams.rowSpec</see>
		/// .
		/// </remarks>
		/// <returns>the current number of rows</returns>
		/// <seealso cref="setRowCount(int)">setRowCount(int)</seealso>
		/// <seealso cref="LayoutParams.rowSpec">LayoutParams.rowSpec</seealso>
		/// <attr>ref android.R.styleable#GridLayout_rowCount</attr>
		public virtual int getRowCount()
		{
			return verticalAxis.getCount();
		}

		/// <summary>
		/// RowCount is used only to generate default row/column indices when
		/// they are not specified by a component's layout parameters.
		/// </summary>
		/// <remarks>
		/// RowCount is used only to generate default row/column indices when
		/// they are not specified by a component's layout parameters.
		/// </remarks>
		/// <param name="rowCount">the number of rows</param>
		/// <seealso cref="getRowCount()">getRowCount()</seealso>
		/// <seealso cref="LayoutParams.rowSpec">LayoutParams.rowSpec</seealso>
		/// <attr>ref android.R.styleable#GridLayout_rowCount</attr>
		public virtual void setRowCount(int rowCount)
		{
			verticalAxis.setCount(rowCount);
			invalidateStructure();
			requestLayout();
		}

		/// <summary>Returns the current number of columns.</summary>
		/// <remarks>
		/// Returns the current number of columns. This is either the last value that was set
		/// with
		/// <see cref="setColumnCount(int)">setColumnCount(int)</see>
		/// or, if no such value was set, the maximum
		/// value of each the upper bounds defined in
		/// <see cref="LayoutParams.columnSpec">LayoutParams.columnSpec</see>
		/// .
		/// </remarks>
		/// <returns>the current number of columns</returns>
		/// <seealso cref="setColumnCount(int)">setColumnCount(int)</seealso>
		/// <seealso cref="LayoutParams.columnSpec">LayoutParams.columnSpec</seealso>
		/// <attr>ref android.R.styleable#GridLayout_columnCount</attr>
		public virtual int getColumnCount()
		{
			return horizontalAxis.getCount();
		}

		/// <summary>
		/// ColumnCount is used only to generate default column/column indices when
		/// they are not specified by a component's layout parameters.
		/// </summary>
		/// <remarks>
		/// ColumnCount is used only to generate default column/column indices when
		/// they are not specified by a component's layout parameters.
		/// </remarks>
		/// <param name="columnCount">the number of columns.</param>
		/// <seealso cref="getColumnCount()">getColumnCount()</seealso>
		/// <seealso cref="LayoutParams.columnSpec">LayoutParams.columnSpec</seealso>
		/// <attr>ref android.R.styleable#GridLayout_columnCount</attr>
		public virtual void setColumnCount(int columnCount)
		{
			horizontalAxis.setCount(columnCount);
			invalidateStructure();
			requestLayout();
		}

		/// <summary>
		/// Returns whether or not this GridLayout will allocate default margins when no
		/// corresponding layout parameters are defined.
		/// </summary>
		/// <remarks>
		/// Returns whether or not this GridLayout will allocate default margins when no
		/// corresponding layout parameters are defined.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if default margins should be allocated
		/// </returns>
		/// <seealso cref="setUseDefaultMargins(bool)">setUseDefaultMargins(bool)</seealso>
		/// <attr>ref android.R.styleable#GridLayout_useDefaultMargins</attr>
		public virtual bool getUseDefaultMargins()
		{
			return useDefaultMargins;
		}

		/// <summary>
		/// When
		/// <code>true</code>
		/// , GridLayout allocates default margins around children
		/// based on the child's visual characteristics. Each of the
		/// margins so defined may be independently overridden by an assignment
		/// to the appropriate layout parameter.
		/// <p>
		/// When
		/// <code>false</code>
		/// , the default value of all margins is zero.
		/// <p>
		/// When setting to
		/// <code>true</code>
		/// , consider setting the value of the
		/// <see cref="setAlignmentMode(int)">alignmentMode</see>
		/// property to
		/// <see cref="ALIGN_BOUNDS">ALIGN_BOUNDS</see>
		/// .
		/// <p>
		/// The default value of this property is
		/// <code>false</code>
		/// .
		/// </summary>
		/// <param name="useDefaultMargins">
		/// use
		/// <code>true</code>
		/// to make GridLayout allocate default margins
		/// </param>
		/// <seealso cref="getUseDefaultMargins()">getUseDefaultMargins()</seealso>
		/// <seealso cref="setAlignmentMode(int)">setAlignmentMode(int)</seealso>
		/// <seealso cref="android.view.ViewGroup.MarginLayoutParams.leftMargin">android.view.ViewGroup.MarginLayoutParams.leftMargin
		/// 	</seealso>
		/// <seealso cref="android.view.ViewGroup.MarginLayoutParams.topMargin">android.view.ViewGroup.MarginLayoutParams.topMargin
		/// 	</seealso>
		/// <seealso cref="android.view.ViewGroup.MarginLayoutParams.rightMargin">android.view.ViewGroup.MarginLayoutParams.rightMargin
		/// 	</seealso>
		/// <seealso cref="android.view.ViewGroup.MarginLayoutParams.bottomMargin">android.view.ViewGroup.MarginLayoutParams.bottomMargin
		/// 	</seealso>
		/// <attr>ref android.R.styleable#GridLayout_useDefaultMargins</attr>
		public virtual void setUseDefaultMargins(bool useDefaultMargins)
		{
			this.useDefaultMargins = useDefaultMargins;
			requestLayout();
		}

		/// <summary>Returns the alignment mode.</summary>
		/// <remarks>Returns the alignment mode.</remarks>
		/// <returns>
		/// the alignment mode; either
		/// <see cref="ALIGN_BOUNDS">ALIGN_BOUNDS</see>
		/// or
		/// <see cref="ALIGN_MARGINS">ALIGN_MARGINS</see>
		/// </returns>
		/// <seealso cref="ALIGN_BOUNDS">ALIGN_BOUNDS</seealso>
		/// <seealso cref="ALIGN_MARGINS">ALIGN_MARGINS</seealso>
		/// <seealso cref="setAlignmentMode(int)">setAlignmentMode(int)</seealso>
		/// <attr>ref android.R.styleable#GridLayout_alignmentMode</attr>
		public virtual int getAlignmentMode()
		{
			return alignmentMode;
		}

		/// <summary>
		/// Sets the alignment mode to be used for all of the alignments between the
		/// children of this container.
		/// </summary>
		/// <remarks>
		/// Sets the alignment mode to be used for all of the alignments between the
		/// children of this container.
		/// <p>
		/// The default value of this property is
		/// <see cref="ALIGN_MARGINS">ALIGN_MARGINS</see>
		/// .
		/// </remarks>
		/// <param name="alignmentMode">
		/// either
		/// <see cref="ALIGN_BOUNDS">ALIGN_BOUNDS</see>
		/// or
		/// <see cref="ALIGN_MARGINS">ALIGN_MARGINS</see>
		/// </param>
		/// <seealso cref="ALIGN_BOUNDS">ALIGN_BOUNDS</seealso>
		/// <seealso cref="ALIGN_MARGINS">ALIGN_MARGINS</seealso>
		/// <seealso cref="getAlignmentMode()">getAlignmentMode()</seealso>
		/// <attr>ref android.R.styleable#GridLayout_alignmentMode</attr>
		public virtual void setAlignmentMode(int alignmentMode)
		{
			this.alignmentMode = alignmentMode;
			requestLayout();
		}

		/// <summary>Returns whether or not row boundaries are ordered by their grid indices.
		/// 	</summary>
		/// <remarks>Returns whether or not row boundaries are ordered by their grid indices.
		/// 	</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if row boundaries must appear in the order of their indices,
		/// <code>false</code>
		/// otherwise
		/// </returns>
		/// <seealso cref="setRowOrderPreserved(bool)">setRowOrderPreserved(bool)</seealso>
		/// <attr>ref android.R.styleable#GridLayout_rowOrderPreserved</attr>
		public virtual bool isRowOrderPreserved()
		{
			return verticalAxis.isOrderPreserved();
		}

		/// <summary>
		/// When this property is
		/// <code>true</code>
		/// , GridLayout is forced to place the row boundaries
		/// so that their associated grid indices are in ascending order in the view.
		/// <p>
		/// When this property is
		/// <code>false</code>
		/// GridLayout is at liberty to place the vertical row
		/// boundaries in whatever order best fits the given constraints.
		/// <p>
		/// The default value of this property is
		/// <code>true</code>
		/// .
		/// </summary>
		/// <param name="rowOrderPreserved">
		/// 
		/// <code>true</code>
		/// to force GridLayout to respect the order
		/// of row boundaries
		/// </param>
		/// <seealso cref="isRowOrderPreserved()">isRowOrderPreserved()</seealso>
		/// <attr>ref android.R.styleable#GridLayout_rowOrderPreserved</attr>
		public virtual void setRowOrderPreserved(bool rowOrderPreserved)
		{
			verticalAxis.setOrderPreserved(rowOrderPreserved);
			invalidateStructure();
			requestLayout();
		}

		/// <summary>Returns whether or not column boundaries are ordered by their grid indices.
		/// 	</summary>
		/// <remarks>Returns whether or not column boundaries are ordered by their grid indices.
		/// 	</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if column boundaries must appear in the order of their indices,
		/// <code>false</code>
		/// otherwise
		/// </returns>
		/// <seealso cref="setColumnOrderPreserved(bool)">setColumnOrderPreserved(bool)</seealso>
		/// <attr>ref android.R.styleable#GridLayout_columnOrderPreserved</attr>
		public virtual bool isColumnOrderPreserved()
		{
			return horizontalAxis.isOrderPreserved();
		}

		/// <summary>
		/// When this property is
		/// <code>true</code>
		/// , GridLayout is forced to place the column boundaries
		/// so that their associated grid indices are in ascending order in the view.
		/// <p>
		/// When this property is
		/// <code>false</code>
		/// GridLayout is at liberty to place the horizontal column
		/// boundaries in whatever order best fits the given constraints.
		/// <p>
		/// The default value of this property is
		/// <code>true</code>
		/// .
		/// </summary>
		/// <param name="columnOrderPreserved">
		/// use
		/// <code>true</code>
		/// to force GridLayout to respect the order
		/// of column boundaries.
		/// </param>
		/// <seealso cref="isColumnOrderPreserved()">isColumnOrderPreserved()</seealso>
		/// <attr>ref android.R.styleable#GridLayout_columnOrderPreserved</attr>
		public virtual void setColumnOrderPreserved(bool columnOrderPreserved)
		{
			horizontalAxis.setOrderPreserved(columnOrderPreserved);
			invalidateStructure();
			requestLayout();
		}

		// Static utility methods
		internal static int max2(int[] a, int valueIfEmpty)
		{
			int result = valueIfEmpty;
			{
				int i = 0;
				int N = a.Length;
				for (; i < N; i++)
				{
					result = System.Math.Max(result, a[i]);
				}
			}
			return result;
		}

		internal static T[] append<T>(T[] a, T[] b)
		{
			T[] result = (T[])System.Array.CreateInstance(a.GetType().GetElementType(), a.Length
				 + b.Length);
			System.Array.Copy(a, 0, result, 0, a.Length);
			System.Array.Copy(b, 0, result, a.Length, b.Length);
			return result;
		}

		internal static android.widget.GridLayout.Alignment getAlignment(int gravity, bool
			 horizontal)
		{
			int mask = horizontal ? android.view.Gravity.HORIZONTAL_GRAVITY_MASK : android.view.Gravity
				.VERTICAL_GRAVITY_MASK;
			int shift = horizontal ? android.view.Gravity.AXIS_X_SHIFT : android.view.Gravity
				.AXIS_Y_SHIFT;
			int flags = (gravity & mask) >> shift;
			switch (flags)
			{
				case (android.view.Gravity.AXIS_SPECIFIED | android.view.Gravity.AXIS_PULL_BEFORE
					):
				{
					return LEADING;
				}

				case (android.view.Gravity.AXIS_SPECIFIED | android.view.Gravity.AXIS_PULL_AFTER)
					:
				{
					return TRAILING;
				}

				case (android.view.Gravity.AXIS_SPECIFIED | android.view.Gravity.AXIS_PULL_BEFORE
					 | android.view.Gravity.AXIS_PULL_AFTER):
				{
					return FILL;
				}

				case android.view.Gravity.AXIS_SPECIFIED:
				{
					return CENTER;
				}

				default:
				{
					return UNDEFINED_ALIGNMENT;
				}
			}
		}

		/// <noinspection>UnusedParameters</noinspection>
		private int getDefaultMargin(android.view.View c, bool horizontal, bool leading)
		{
			if (c.GetType() == typeof(android.widget.Space))
			{
				return 0;
			}
			return defaultGap / 2;
		}

		private int getDefaultMargin(android.view.View c, bool isAtEdge, bool horizontal, 
			bool leading)
		{
			return isAtEdge ? DEFAULT_CONTAINER_MARGIN : getDefaultMargin(c, horizontal, leading
				);
		}

		private int getDefaultMarginValue(android.view.View c, android.widget.GridLayout.
			LayoutParams p, bool horizontal, bool leading)
		{
			if (!useDefaultMargins)
			{
				return 0;
			}
			android.widget.GridLayout.Spec spec_1 = horizontal ? p.columnSpec : p.rowSpec;
			android.widget.GridLayout.Axis axis = horizontal ? horizontalAxis : verticalAxis;
			android.widget.GridLayout.Interval span = spec_1.span;
			bool isAtEdge = leading ? (span.min == 0) : (span.max == axis.getCount());
			return getDefaultMargin(c, isAtEdge, horizontal, leading);
		}

		internal virtual int getMargin1(android.view.View view, bool horizontal, bool leading
			)
		{
			android.widget.GridLayout.LayoutParams lp = getLayoutParams(view);
			int margin = horizontal ? (leading ? lp.leftMargin : lp.rightMargin) : (leading ? 
				lp.topMargin : lp.bottomMargin);
			return margin == UNDEFINED ? getDefaultMarginValue(view, lp, horizontal, leading)
				 : margin;
		}

		private int getMargin(android.view.View view, bool horizontal, bool leading)
		{
			if (alignmentMode == ALIGN_MARGINS)
			{
				return getMargin1(view, horizontal, leading);
			}
			else
			{
				android.widget.GridLayout.Axis axis = horizontal ? horizontalAxis : verticalAxis;
				int[] margins = leading ? axis.getLeadingMargins() : axis.getTrailingMargins();
				android.widget.GridLayout.LayoutParams lp = getLayoutParams(view);
				android.widget.GridLayout.Spec spec_1 = horizontal ? lp.columnSpec : lp.rowSpec;
				int index = leading ? spec_1.span.min : spec_1.span.max;
				return margins[index];
			}
		}

		private int getTotalMargin(android.view.View child, bool horizontal)
		{
			return getMargin(child, horizontal, true) + getMargin(child, horizontal, false);
		}

		private static bool fits(int[] a, int value, int start, int end)
		{
			if (end > a.Length)
			{
				return false;
			}
			{
				for (int i = start; i < end; i++)
				{
					if (a[i] > value)
					{
						return false;
					}
				}
			}
			return true;
		}

		private static void procrusteanFill(int[] a, int start, int end, int value)
		{
			int length = a.Length;
			java.util.Arrays.fill(a, System.Math.Min(start, length), System.Math.Min(end, length
				), value);
		}

		private static void setCellGroup(android.widget.GridLayout.LayoutParams lp, int row
			, int rowSpan, int col, int colSpan)
		{
			lp.setRowSpecSpan(new android.widget.GridLayout.Interval(row, row + rowSpan));
			lp.setColumnSpecSpan(new android.widget.GridLayout.Interval(col, col + colSpan));
		}

		// Logic to avert infinite loops by ensuring that the cells can be placed somewhere.
		internal static int clip(android.widget.GridLayout.Interval minorRange, bool minorWasDefined
			, int count)
		{
			int size = minorRange.size();
			if (count == 0)
			{
				return size;
			}
			int min = minorWasDefined ? System.Math.Min(minorRange.min, count) : 0;
			return System.Math.Min(size, count - min);
		}

		// install default indices for cells that don't define them
		private void validateLayoutParams()
		{
			bool horizontal = (orientation == HORIZONTAL);
			android.widget.GridLayout.Axis axis = horizontal ? horizontalAxis : verticalAxis;
			int count = (axis.definedCount != UNDEFINED) ? axis.definedCount : 0;
			int major = 0;
			int minor = 0;
			int[] maxSizes = new int[count];
			{
				int i = 0;
				int N = getChildCount();
				for (; i < N; i++)
				{
					android.widget.GridLayout.LayoutParams lp = getLayoutParams1(getChildAt(i));
					android.widget.GridLayout.Spec majorSpec = horizontal ? lp.rowSpec : lp.columnSpec;
					android.widget.GridLayout.Interval majorRange = majorSpec.span;
					bool majorWasDefined = majorSpec.startDefined;
					int majorSpan = majorRange.size();
					if (majorWasDefined)
					{
						major = majorRange.min;
					}
					android.widget.GridLayout.Spec minorSpec = horizontal ? lp.columnSpec : lp.rowSpec;
					android.widget.GridLayout.Interval minorRange = minorSpec.span;
					bool minorWasDefined = minorSpec.startDefined;
					int minorSpan = clip(minorRange, minorWasDefined, count);
					if (minorWasDefined)
					{
						minor = minorRange.min;
					}
					if (count != 0)
					{
						// Find suitable row/col values when at least one is undefined.
						if (!majorWasDefined || !minorWasDefined)
						{
							while (!fits(maxSizes, major, minor, minor + minorSpan))
							{
								if (minorWasDefined)
								{
									major++;
								}
								else
								{
									if (minor + minorSpan <= count)
									{
										minor++;
									}
									else
									{
										minor = 0;
										major++;
									}
								}
							}
						}
						procrusteanFill(maxSizes, minor, minor + minorSpan, major + majorSpan);
					}
					if (horizontal)
					{
						setCellGroup(lp, major, majorSpan, minor, minorSpan);
					}
					else
					{
						setCellGroup(lp, minor, minorSpan, major, majorSpan);
					}
					minor = minor + minorSpan;
				}
			}
			invalidateStructure();
		}

		private void invalidateStructure()
		{
			layoutParamsValid = false;
			horizontalAxis.invalidateStructure();
			verticalAxis.invalidateStructure();
			// This can end up being done twice. Better twice than not at all.
			invalidateValues();
		}

		private void invalidateValues()
		{
			// Need null check because requestLayout() is called in View's initializer,
			// before we are set up.
			if (horizontalAxis != null && verticalAxis != null)
			{
				horizontalAxis.invalidateValues();
				verticalAxis.invalidateValues();
			}
		}

		private android.widget.GridLayout.LayoutParams getLayoutParams1(android.view.View
			 c)
		{
			return (android.widget.GridLayout.LayoutParams)c.getLayoutParams();
		}

		internal android.widget.GridLayout.LayoutParams getLayoutParams(android.view.View
			 c)
		{
			if (!layoutParamsValid)
			{
				validateLayoutParams();
				layoutParamsValid = true;
			}
			return getLayoutParams1(c);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.widget.GridLayout.LayoutParams();
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.GridLayout.LayoutParams(getContext(), attrs);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.GridLayout.LayoutParams(p);
		}

		// Draw grid
		private void drawLine(android.graphics.Canvas graphics, int x1, int y1, int x2, int
			 y2, android.graphics.Paint paint)
		{
			int dx = getPaddingLeft();
			int dy = getPaddingTop();
			graphics.drawLine(dx + x1, dy + y1, dx + x2, dy + y2, paint);
		}

		private static void drawRect(android.graphics.Canvas canvas, int x1, int y1, int 
			x2, int y2, android.graphics.Paint paint)
		{
			canvas.drawRect(x1, y1, x2 - 1, y2 - 1, paint);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			base.onDraw(canvas);
		}

		// Draw bounds
		// Draw margins
		// Add/remove
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override void onViewAdded(android.view.View child)
		{
			base.onViewAdded(child);
			invalidateStructure();
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override void onViewRemoved(android.view.View child)
		{
			base.onViewRemoved(child);
			invalidateStructure();
		}

		/// <summary>We need to call invalidateStructure() when a child's GONE flag changes state.
		/// 	</summary>
		/// <remarks>
		/// We need to call invalidateStructure() when a child's GONE flag changes state.
		/// This implementation is a catch-all, invalidating on any change in the visibility flags.
		/// </remarks>
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override void onChildVisibilityChanged(android.view.View child
			, int visibility)
		{
			base.onChildVisibilityChanged(child, visibility);
			invalidateStructure();
		}

		// Measurement
		internal bool isGone(android.view.View c)
		{
			return c.getVisibility() == android.view.View.GONE;
		}

		private void measureChildWithMargins2(android.view.View child, int parentWidthSpec
			, int parentHeightSpec, int childWidth, int childHeight)
		{
			int childWidthSpec = getChildMeasureSpec(parentWidthSpec, mPaddingLeft + mPaddingRight
				 + getTotalMargin(child, true), childWidth);
			int childHeightSpec = getChildMeasureSpec(parentHeightSpec, mPaddingTop + mPaddingBottom
				 + getTotalMargin(child, false), childHeight);
			child.measure(childWidthSpec, childHeightSpec);
		}

		private void measureChildrenWithMargins(int widthSpec, int heightSpec, bool firstPass
			)
		{
			{
				int i = 0;
				int N = getChildCount();
				for (; i < N; i++)
				{
					android.view.View c = getChildAt(i);
					if (isGone(c))
					{
						continue;
					}
					android.widget.GridLayout.LayoutParams lp = getLayoutParams(c);
					if (firstPass)
					{
						measureChildWithMargins2(c, widthSpec, heightSpec, lp.width, lp.height);
					}
					else
					{
						android.widget.GridLayout.Spec spec_1 = (orientation == HORIZONTAL) ? lp.columnSpec
							 : lp.rowSpec;
						if (spec_1.alignment == FILL)
						{
							android.widget.GridLayout.Interval span = spec_1.span;
							android.widget.GridLayout.Axis axis = (orientation == HORIZONTAL) ? horizontalAxis
								 : verticalAxis;
							int[] locations = axis.getLocations();
							int size = locations[span.max] - locations[span.min];
							if (orientation == HORIZONTAL)
							{
								measureChildWithMargins2(c, widthSpec, heightSpec, size, lp.height);
							}
							else
							{
								measureChildWithMargins2(c, widthSpec, heightSpec, lp.width, size);
							}
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthSpec, int heightSpec)
		{
			invalidateValues();
			measureChildrenWithMargins(widthSpec, heightSpec, true);
			int width;
			int height;
			// Use the orientation property to decide which axis should be laid out first.
			if (orientation == HORIZONTAL)
			{
				width = horizontalAxis.getMeasure(widthSpec);
				measureChildrenWithMargins(widthSpec, heightSpec, false);
				height = verticalAxis.getMeasure(heightSpec);
			}
			else
			{
				height = verticalAxis.getMeasure(heightSpec);
				measureChildrenWithMargins(widthSpec, heightSpec, false);
				width = horizontalAxis.getMeasure(widthSpec);
			}
			int hPadding = getPaddingLeft() + getPaddingRight();
			int vPadding = getPaddingTop() + getPaddingBottom();
			int measuredWidth = System.Math.Max(hPadding + width, getSuggestedMinimumWidth());
			int measuredHeight = System.Math.Max(vPadding + height, getSuggestedMinimumHeight
				());
			setMeasuredDimension(resolveSizeAndState(measuredWidth, widthSpec, 0), resolveSizeAndState
				(measuredHeight, heightSpec, 0));
		}

		private int protect(int alignment)
		{
			return (alignment == UNDEFINED) ? 0 : alignment;
		}

		private int getMeasurement(android.view.View c, bool horizontal)
		{
			return horizontal ? c.getMeasuredWidth() : c.getMeasuredHeight();
		}

		internal int getMeasurementIncludingMargin(android.view.View c, bool horizontal)
		{
			if (isGone(c))
			{
				return 0;
			}
			return getMeasurement(c, horizontal) + getTotalMargin(c, horizontal);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void requestLayout()
		{
			base.requestLayout();
			invalidateValues();
		}

		internal android.widget.GridLayout.Alignment getAlignment(android.widget.GridLayout
			.Alignment alignment, bool horizontal)
		{
			return (alignment != UNDEFINED_ALIGNMENT) ? alignment : (horizontal ? LEFT : BASELINE
				);
		}

		// Layout container
		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			int targetWidth = right - left;
			int targetHeight = bottom - top;
			int paddingLeft = getPaddingLeft();
			int paddingTop = getPaddingTop();
			int paddingRight = getPaddingRight();
			int paddingBottom = getPaddingBottom();
			horizontalAxis.layout(targetWidth - paddingLeft - paddingRight);
			verticalAxis.layout(targetHeight - paddingTop - paddingBottom);
			int[] hLocations = horizontalAxis.getLocations();
			int[] vLocations = verticalAxis.getLocations();
			{
				int i = 0;
				int N = getChildCount();
				for (; i < N; i++)
				{
					android.view.View c = getChildAt(i);
					if (isGone(c))
					{
						continue;
					}
					android.widget.GridLayout.LayoutParams lp = getLayoutParams(c);
					android.widget.GridLayout.Spec columnSpec = lp.columnSpec;
					android.widget.GridLayout.Spec rowSpec = lp.rowSpec;
					android.widget.GridLayout.Interval colSpan = columnSpec.span;
					android.widget.GridLayout.Interval rowSpan = rowSpec.span;
					int x1 = hLocations[colSpan.min];
					int y1 = vLocations[rowSpan.min];
					int x2 = hLocations[colSpan.max];
					int y2 = vLocations[rowSpan.max];
					int cellWidth = x2 - x1;
					int cellHeight = y2 - y1;
					int pWidth = getMeasurement(c, true);
					int pHeight = getMeasurement(c, false);
					android.widget.GridLayout.Alignment hAlign = getAlignment(columnSpec.alignment, true
						);
					android.widget.GridLayout.Alignment vAlign = getAlignment(rowSpec.alignment, false
						);
					int dx;
					int dy;
					android.widget.GridLayout.Bounds colBounds = horizontalAxis.getGroupBounds().getValue
						(i);
					android.widget.GridLayout.Bounds rowBounds = verticalAxis.getGroupBounds().getValue
						(i);
					// Gravity offsets: the location of the alignment group relative to its cell group.
					//noinspection NullableProblems
					int c2ax = protect(hAlign.getAlignmentValue(null, cellWidth - colBounds.size(true
						)));
					//noinspection NullableProblems
					int c2ay = protect(vAlign.getAlignmentValue(null, cellHeight - rowBounds.size(true
						)));
					int leftMargin = getMargin(c, true, true);
					int topMargin = getMargin(c, false, true);
					int rightMargin = getMargin(c, true, false);
					int bottomMargin = getMargin(c, false, false);
					// Same calculation as getMeasurementIncludingMargin()
					int mWidth = leftMargin + pWidth + rightMargin;
					int mHeight = topMargin + pHeight + bottomMargin;
					// Alignment offsets: the location of the view relative to its alignment group.
					int a2vx = colBounds.getOffset(c, hAlign, mWidth);
					int a2vy = rowBounds.getOffset(c, vAlign, mHeight);
					dx = c2ax + a2vx + leftMargin;
					dy = c2ay + a2vy + topMargin;
					cellWidth -= leftMargin + rightMargin;
					cellHeight -= topMargin + bottomMargin;
					int type = PRF;
					int width = hAlign.getSizeInCell(c, pWidth, cellWidth, type);
					int height = vAlign.getSizeInCell(c, pHeight, cellHeight, type);
					int cx = paddingLeft + x1 + dx;
					int cy = paddingTop + y1 + dy;
					if (width != c.getMeasuredWidth() || height != c.getMeasuredHeight())
					{
						c.measure(android.view.View.MeasureSpec.makeMeasureSpec(width, android.view.View.
							MeasureSpec.EXACTLY), android.view.View.MeasureSpec.makeMeasureSpec(height, android.view.View
							.MeasureSpec.EXACTLY));
					}
					c.layout(cx, cy, cx + width, cy + height);
				}
			}
		}

		internal sealed class Axis
		{
			internal const int NEW = 0;

			internal const int PENDING = 1;

			internal const int COMPLETE = 2;

			public readonly bool horizontal;

			public int definedCount;

			private int maxIndex;

			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Spec, android.widget.GridLayout
				.Bounds> groupBounds;

			public bool groupBoundsValid;

			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Interval, 
				android.widget.GridLayout.MutableInt> forwardLinks;

			public bool forwardLinksValid;

			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Interval, 
				android.widget.GridLayout.MutableInt> backwardLinks;

			public bool backwardLinksValid;

			public int[] leadingMargins;

			public bool leadingMarginsValid;

			public int[] trailingMargins;

			public bool trailingMarginsValid;

			internal android.widget.GridLayout.Arc[] arcs;

			public bool arcsValid;

			public int[] locations;

			public bool locationsValid;

			internal bool orderPreserved;

			private android.widget.GridLayout.MutableInt parentMin;

			private android.widget.GridLayout.MutableInt parentMax;

			internal Axis(GridLayout _enclosing, bool horizontal)
			{
				this._enclosing = _enclosing;
				definedCount = android.widget.GridLayout.UNDEFINED;
				maxIndex = android.widget.GridLayout.UNDEFINED;
				groupBoundsValid = false;
				forwardLinksValid = false;
				backwardLinksValid = false;
				leadingMarginsValid = false;
				trailingMarginsValid = false;
				arcsValid = false;
				locationsValid = false;
				orderPreserved = android.widget.GridLayout.DEFAULT_ORDER_PRESERVED;
				parentMin = new android.widget.GridLayout.MutableInt(0);
				parentMax = new android.widget.GridLayout.MutableInt(-android.widget.GridLayout.MAX_SIZE
					);
				// Inner classes
				this.horizontal = horizontal;
			}

			private int calculateMaxIndex()
			{
				// the number Integer.MIN_VALUE + 1 comes up in undefined cells
				int result = -1;
				{
					int i = 0;
					int N = this._enclosing.getChildCount();
					for (; i < N; i++)
					{
						android.view.View c = this._enclosing.getChildAt(i);
						android.widget.GridLayout.LayoutParams @params = this._enclosing.getLayoutParams(
							c);
						android.widget.GridLayout.Spec spec = this.horizontal ? @params.columnSpec : @params
							.rowSpec;
						android.widget.GridLayout.Interval span = spec.span;
						result = System.Math.Max(result, span.min);
						result = System.Math.Max(result, span.max);
					}
				}
				return result == -1 ? android.widget.GridLayout.UNDEFINED : result;
			}

			private int getMaxIndex()
			{
				if (this.maxIndex == android.widget.GridLayout.UNDEFINED)
				{
					this.maxIndex = System.Math.Max(0, this.calculateMaxIndex());
				}
				// use zero when there are no children
				return this.maxIndex;
			}

			public int getCount()
			{
				return System.Math.Max(this.definedCount, this.getMaxIndex());
			}

			public void setCount(int count)
			{
				this.definedCount = count;
			}

			public bool isOrderPreserved()
			{
				return this.orderPreserved;
			}

			public void setOrderPreserved(bool orderPreserved)
			{
				this.orderPreserved = orderPreserved;
				this.invalidateStructure();
			}

			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Spec, android.widget.GridLayout
				.Bounds> createGroupBounds()
			{
				android.widget.GridLayout.Assoc<android.widget.GridLayout.Spec, android.widget.GridLayout
					.Bounds> assoc = android.widget.GridLayout.Assoc<android.widget.GridLayout.Spec, 
					android.widget.GridLayout.Bounds>.of<android.widget.GridLayout.Spec, android.widget.GridLayout
					.Bounds>();
				{
					int i = 0;
					int N = this._enclosing.getChildCount();
					for (; i < N; i++)
					{
						android.view.View c = this._enclosing.getChildAt(i);
						android.widget.GridLayout.LayoutParams lp = this._enclosing.getLayoutParams(c);
						android.widget.GridLayout.Spec spec = this.horizontal ? lp.columnSpec : lp.rowSpec;
						android.widget.GridLayout.Bounds bounds = this._enclosing.getAlignment(spec.alignment
							, this.horizontal).getBounds();
						assoc.put(spec, bounds);
					}
				}
				return assoc.pack();
			}

			private void computeGroupBounds()
			{
				android.widget.GridLayout.Bounds[] values = this.groupBounds.values;
				{
					for (int i = 0; i < values.Length; i++)
					{
						values[i].reset();
					}
				}
				{
					int i_1 = 0;
					int N = this._enclosing.getChildCount();
					for (; i_1 < N; i_1++)
					{
						android.view.View c = this._enclosing.getChildAt(i_1);
						android.widget.GridLayout.LayoutParams lp = this._enclosing.getLayoutParams(c);
						android.widget.GridLayout.Spec spec = this.horizontal ? lp.columnSpec : lp.rowSpec;
						this.groupBounds.getValue(i_1).include(c, spec, this._enclosing, this);
					}
				}
			}

			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Spec, android.widget.GridLayout
				.Bounds> getGroupBounds()
			{
				if (this.groupBounds == null)
				{
					this.groupBounds = this.createGroupBounds();
				}
				if (!this.groupBoundsValid)
				{
					this.computeGroupBounds();
					this.groupBoundsValid = true;
				}
				return this.groupBounds;
			}

			// Add values computed by alignment - taking the max of all alignments in each span
			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Interval, 
				android.widget.GridLayout.MutableInt> createLinks(bool min)
			{
				android.widget.GridLayout.Assoc<android.widget.GridLayout.Interval, android.widget.GridLayout
					.MutableInt> result = android.widget.GridLayout.Assoc<android.widget.GridLayout.
					Interval, android.widget.GridLayout.MutableInt>.of<android.widget.GridLayout.Interval
					, android.widget.GridLayout.MutableInt>();
				android.widget.GridLayout.Spec[] keys = this.getGroupBounds().keys;
				{
					int i = 0;
					int N = keys.Length;
					for (; i < N; i++)
					{
						android.widget.GridLayout.Interval span = min ? keys[i].span : keys[i].span.inverse
							();
						result.put(span, new android.widget.GridLayout.MutableInt());
					}
				}
				return result.pack();
			}

			internal void computeLinks(android.widget.GridLayout.PackedMap<android.widget.GridLayout
				.Interval, android.widget.GridLayout.MutableInt> links, bool min)
			{
				android.widget.GridLayout.MutableInt[] spans = links.values;
				{
					for (int i = 0; i < spans.Length; i++)
					{
						spans[i].reset();
					}
				}
				// Use getter to trigger a re-evaluation
				android.widget.GridLayout.Bounds[] bounds = this.getGroupBounds().values;
				{
					for (int i_1 = 0; i_1 < bounds.Length; i_1++)
					{
						int size_1 = bounds[i_1].size(min);
						android.widget.GridLayout.MutableInt valueHolder = links.getValue(i_1);
						// this effectively takes the max() of the minima and the min() of the maxima
						valueHolder.value = System.Math.Max(valueHolder.value, min ? size_1 : -size_1);
					}
				}
			}

			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Interval, 
				android.widget.GridLayout.MutableInt> getForwardLinks()
			{
				if (this.forwardLinks == null)
				{
					this.forwardLinks = this.createLinks(true);
				}
				if (!this.forwardLinksValid)
				{
					this.computeLinks(this.forwardLinks, true);
					this.forwardLinksValid = true;
				}
				return this.forwardLinks;
			}

			internal android.widget.GridLayout.PackedMap<android.widget.GridLayout.Interval, 
				android.widget.GridLayout.MutableInt> getBackwardLinks()
			{
				if (this.backwardLinks == null)
				{
					this.backwardLinks = this.createLinks(false);
				}
				if (!this.backwardLinksValid)
				{
					this.computeLinks(this.backwardLinks, false);
					this.backwardLinksValid = true;
				}
				return this.backwardLinks;
			}

			internal void include(java.util.List<android.widget.GridLayout.Arc> arcs, android.widget.GridLayout
				.Interval key, android.widget.GridLayout.MutableInt size_1, bool ignoreIfAlreadyPresent
				)
			{
				if (key.size() == 0)
				{
					return;
				}
				// this bit below should really be computed outside here -
				// its just to stop default (row/col > 0) constraints obliterating valid entries
				if (ignoreIfAlreadyPresent)
				{
					foreach (android.widget.GridLayout.Arc arc in Sharpen.IterableProxy.Create(arcs))
					{
						android.widget.GridLayout.Interval span = arc.span;
						if (span.Equals(key))
						{
							return;
						}
					}
				}
				arcs.add(new android.widget.GridLayout.Arc(key, size_1));
			}

			internal void include(java.util.List<android.widget.GridLayout.Arc> arcs, android.widget.GridLayout
				.Interval key, android.widget.GridLayout.MutableInt size_1)
			{
				this.include(arcs, key, size_1, true);
			}

			// Group arcs by their first vertex, returning an array of arrays.
			// This is linear in the number of arcs.
			internal android.widget.GridLayout.Arc[][] groupArcsByFirstVertex(android.widget.GridLayout
				.Arc[] arcs)
			{
				int N = this.getCount() + 1;
				// the number of vertices
				android.widget.GridLayout.Arc[][] result = new android.widget.GridLayout.Arc[N][];
				int[] sizes = new int[N];
				foreach (android.widget.GridLayout.Arc arc in arcs)
				{
					sizes[arc.span.min]++;
				}
				{
					for (int i = 0; i < sizes.Length; i++)
					{
						result[i] = new android.widget.GridLayout.Arc[sizes[i]];
					}
				}
				// reuse the sizes array to hold the current last elements as we insert each arc
				java.util.Arrays.fill(sizes, 0);
				foreach (android.widget.GridLayout.Arc arc in arcs)
				{
					int i_1 = arc.span.min;
					result[i_1][sizes[i_1]++] = arc;
				}
				return result;
			}

			private sealed class _object_1264 : object
			{
				public _object_1264(Axis _enclosing, android.widget.GridLayout.Arc[] arcs)
				{
					this.result = new android.widget.GridLayout.Arc[arcs.Length];
					this.cursor = this.result.Length - 1;
					this.arcsByVertex = this._enclosing.groupArcsByFirstVertex(arcs);
					this.visited = new int[this._enclosing.getCount() + 1];
					this._enclosing = _enclosing;
					this.arcs = arcs;
				}

				internal android.widget.GridLayout.Arc[] result;

				internal int cursor;

				internal android.widget.GridLayout.Arc[][] arcsByVertex;

				internal int[] visited;

				internal void walk(int loc)
				{
					switch (this.visited[loc])
					{
						case android.widget.GridLayout.Axis.NEW:
						{
							this.visited[loc] = android.widget.GridLayout.Axis.PENDING;
							foreach (android.widget.GridLayout.Arc arc in this.arcsByVertex[loc])
							{
								this.walk(arc.span.max);
								this.result[this.cursor--] = arc;
							}
							this.visited[loc] = android.widget.GridLayout.Axis.COMPLETE;
							break;
						}

						case android.widget.GridLayout.Axis.PENDING:
						{
							break;
						}

						case android.widget.GridLayout.Axis.COMPLETE:
						{
							break;
						}
					}
				}

				internal android.widget.GridLayout.Arc[] sort()
				{
					{
						int loc = 0;
						int N = this.arcsByVertex.Length;
						for (; loc < N; loc++)
						{
							this.walk(loc);
						}
					}
					return this.result;
				}

				private readonly Axis _enclosing;

				private readonly android.widget.GridLayout.Arc[] arcs;
			}

			internal android.widget.GridLayout.Arc[] topologicalSort(android.widget.GridLayout
				.Arc[] arcs)
			{
				return new _object_1264(this, arcs).sort();
			}

			internal android.widget.GridLayout.Arc[] topologicalSort(java.util.List<android.widget.GridLayout
				.Arc> arcs)
			{
				return this.topologicalSort(arcs.toArray(new android.widget.GridLayout.Arc[arcs.size
					()]));
			}

			internal void addComponentSizes(java.util.List<android.widget.GridLayout.Arc> result
				, android.widget.GridLayout.PackedMap<android.widget.GridLayout.Interval, android.widget.GridLayout
				.MutableInt> links)
			{
				{
					for (int i = 0; i < links.keys.Length; i++)
					{
						android.widget.GridLayout.Interval key = links.keys[i];
						this.include(result, key, links.values[i], false);
					}
				}
			}

			internal android.widget.GridLayout.Arc[] createArcs()
			{
				java.util.List<android.widget.GridLayout.Arc> mins = new java.util.ArrayList<android.widget.GridLayout
					.Arc>();
				java.util.List<android.widget.GridLayout.Arc> maxs = new java.util.ArrayList<android.widget.GridLayout
					.Arc>();
				// Add the minimum values from the components.
				this.addComponentSizes(mins, this.getForwardLinks());
				// Add the maximum values from the components.
				this.addComponentSizes(maxs, this.getBackwardLinks());
				// Add ordering constraints to prevent row/col sizes from going negative
				if (this.orderPreserved)
				{
					{
						// Add a constraint for every row/col
						for (int i = 0; i < this.getCount(); i++)
						{
							this.include(mins, new android.widget.GridLayout.Interval(i, i + 1), new android.widget.GridLayout
								.MutableInt(0));
						}
					}
				}
				// Add the container constraints. Use the version of include that allows
				// duplicate entries in case a child spans the entire grid.
				int N = this.getCount();
				this.include(mins, new android.widget.GridLayout.Interval(0, N), this.parentMin, 
					false);
				this.include(maxs, new android.widget.GridLayout.Interval(N, 0), this.parentMax, 
					false);
				// Sort
				android.widget.GridLayout.Arc[] sMins = this.topologicalSort(mins);
				android.widget.GridLayout.Arc[] sMaxs = this.topologicalSort(maxs);
				return android.widget.GridLayout.append(sMins, sMaxs);
			}

			private void computeArcs()
			{
				// getting the links validates the values that are shared by the arc list
				this.getForwardLinks();
				this.getBackwardLinks();
			}

			internal android.widget.GridLayout.Arc[] getArcs()
			{
				if (this.arcs == null)
				{
					this.arcs = this.createArcs();
				}
				if (!this.arcsValid)
				{
					this.computeArcs();
					this.arcsValid = true;
				}
				return this.arcs;
			}

			internal bool relax(int[] locations, android.widget.GridLayout.Arc entry)
			{
				if (!entry.valid)
				{
					return false;
				}
				android.widget.GridLayout.Interval span = entry.span;
				int u = span.min;
				int v = span.max;
				int value = entry.value.value;
				int candidate = locations[u] + value;
				if (candidate > locations[v])
				{
					locations[v] = candidate;
					return true;
				}
				return false;
			}

			private void init(int[] locations)
			{
				java.util.Arrays.fill(locations, 0);
			}

			internal string arcsToString(java.util.List<android.widget.GridLayout.Arc> arcs)
			{
				string var = this.horizontal ? "x" : "y";
				java.lang.StringBuilder result = new java.lang.StringBuilder();
				bool first = true;
				foreach (android.widget.GridLayout.Arc arc in Sharpen.IterableProxy.Create(arcs))
				{
					if (first)
					{
						first = false;
					}
					else
					{
						result = result.append(", ");
					}
					int src = arc.span.min;
					int dst = arc.span.max;
					int value = arc.value.value;
					result.append((src < dst) ? var + dst + " - " + var + src + " > " + value : var +
						 src + " - " + var + dst + " < " + -value);
				}
				return result.ToString();
			}

			internal void logError(string axisName, android.widget.GridLayout.Arc[] arcs, bool
				[] culprits0)
			{
				java.util.List<android.widget.GridLayout.Arc> culprits = new java.util.ArrayList<
					android.widget.GridLayout.Arc>();
				java.util.List<android.widget.GridLayout.Arc> removed = new java.util.ArrayList<android.widget.GridLayout
					.Arc>();
				{
					for (int c = 0; c < arcs.Length; c++)
					{
						android.widget.GridLayout.Arc arc = arcs[c];
						if (culprits0[c])
						{
							culprits.add(arc);
						}
						if (!arc.valid)
						{
							removed.add(arc);
						}
					}
				}
				android.util.Log.d(android.widget.GridLayout.TAG, axisName + " constraints: " + this
					.arcsToString(culprits) + " are inconsistent; " + "permanently removing: " + this
					.arcsToString(removed) + ". ");
			}

			internal void solve(android.widget.GridLayout.Arc[] arcs, int[] locations)
			{
				string axisName = this.horizontal ? "horizontal" : "vertical";
				int N = this.getCount() + 1;
				// The number of vertices is the number of columns/rows + 1.
				bool[] originalCulprits = null;
				{
					for (int p = 0; p < arcs.Length; p++)
					{
						this.init(locations);
						{
							// We take one extra pass over traditional Bellman-Ford (and omit their final step)
							for (int i = 0; i < N; i++)
							{
								bool changed = false;
								{
									int j = 0;
									int length = arcs.Length;
									for (; j < length; j++)
									{
										changed |= this.relax(locations, arcs[j]);
									}
								}
								if (!changed)
								{
									if (originalCulprits != null)
									{
										this.logError(axisName, arcs, originalCulprits);
									}
									return;
								}
							}
						}
						bool[] culprits = new bool[arcs.Length];
						{
							for (int i_1 = 0; i_1 < N; i_1++)
							{
								{
									int j = 0;
									int length = arcs.Length;
									for (; j < length; j++)
									{
										culprits[j] |= this.relax(locations, arcs[j]);
									}
								}
							}
						}
						if (p == 0)
						{
							originalCulprits = culprits;
						}
						{
							for (int i_2 = 0; i_2 < arcs.Length; i_2++)
							{
								if (culprits[i_2])
								{
									android.widget.GridLayout.Arc arc = arcs[i_2];
									// Only remove max values, min values alone cannot be inconsistent
									if (arc.span.min < arc.span.max)
									{
										continue;
									}
									arc.valid = false;
									break;
								}
							}
						}
					}
				}
			}

			private void computeMargins(bool leading)
			{
				int[] margins = leading ? this.leadingMargins : this.trailingMargins;
				{
					int i = 0;
					int N = this._enclosing.getChildCount();
					for (; i < N; i++)
					{
						android.view.View c = this._enclosing.getChildAt(i);
						if (this._enclosing.isGone(c))
						{
							continue;
						}
						android.widget.GridLayout.LayoutParams lp = this._enclosing.getLayoutParams(c);
						android.widget.GridLayout.Spec spec = this.horizontal ? lp.columnSpec : lp.rowSpec;
						android.widget.GridLayout.Interval span = spec.span;
						int index = leading ? span.min : span.max;
						margins[index] = System.Math.Max(margins[index], this._enclosing.getMargin1(c, this
							.horizontal, leading));
					}
				}
			}

			// External entry points
			public int[] getLeadingMargins()
			{
				if (this.leadingMargins == null)
				{
					this.leadingMargins = new int[this.getCount() + 1];
				}
				if (!this.leadingMarginsValid)
				{
					this.computeMargins(true);
					this.leadingMarginsValid = true;
				}
				return this.leadingMargins;
			}

			public int[] getTrailingMargins()
			{
				if (this.trailingMargins == null)
				{
					this.trailingMargins = new int[this.getCount() + 1];
				}
				if (!this.trailingMarginsValid)
				{
					this.computeMargins(false);
					this.trailingMarginsValid = true;
				}
				return this.trailingMargins;
			}

			private void computeLocations(int[] a)
			{
				this.solve(this.getArcs(), a);
				if (!this.orderPreserved)
				{
					// Solve returns the smallest solution to the constraint system for which all
					// values are positive. One value is therefore zero - though if the row/col
					// order is not preserved this may not be the first vertex. For consistency,
					// translate all the values so that they measure the distance from a[0]; the
					// leading edge of the parent. After this transformation some values may be
					// negative.
					int a0 = a[0];
					{
						int i = 0;
						int N = a.Length;
						for (; i < N; i++)
						{
							a[i] = a[i] - a0;
						}
					}
				}
			}

			public int[] getLocations()
			{
				if (this.locations == null)
				{
					int N = this.getCount() + 1;
					this.locations = new int[N];
				}
				if (!this.locationsValid)
				{
					this.computeLocations(this.locations);
					this.locationsValid = true;
				}
				return this.locations;
			}

			private int size(int[] locations)
			{
				// The parental edges are attached to vertices 0 and N - even when order is not
				// being preserved and other vertices fall outside this range. Measure the distance
				// between vertices 0 and N, assuming that locations[0] = 0.
				return locations[this.getCount()];
			}

			private void setParentConstraints(int min, int max)
			{
				this.parentMin.value = min;
				this.parentMax.value = -max;
				this.locationsValid = false;
			}

			private int getMeasure(int min, int max)
			{
				this.setParentConstraints(min, max);
				return this.size(this.getLocations());
			}

			public int getMeasure(int measureSpec)
			{
				int mode = android.view.View.MeasureSpec.getMode(measureSpec);
				int size_1 = android.view.View.MeasureSpec.getSize(measureSpec);
				switch (mode)
				{
					case android.view.View.MeasureSpec.UNSPECIFIED:
					{
						return this.getMeasure(0, android.widget.GridLayout.MAX_SIZE);
					}

					case android.view.View.MeasureSpec.EXACTLY:
					{
						return this.getMeasure(size_1, size_1);
					}

					case android.view.View.MeasureSpec.AT_MOST:
					{
						return this.getMeasure(0, size_1);
					}

					default:
					{
						return 0;
					}
				}
			}

			public void layout(int size_1)
			{
				this.setParentConstraints(size_1, size_1);
				this.getLocations();
			}

			public void invalidateStructure()
			{
				this.maxIndex = android.widget.GridLayout.UNDEFINED;
				this.groupBounds = null;
				this.forwardLinks = null;
				this.backwardLinks = null;
				this.leadingMargins = null;
				this.trailingMargins = null;
				this.arcs = null;
				this.locations = null;
				this.invalidateValues();
			}

			public void invalidateValues()
			{
				this.groupBoundsValid = false;
				this.forwardLinksValid = false;
				this.backwardLinksValid = false;
				this.leadingMarginsValid = false;
				this.trailingMarginsValid = false;
				this.arcsValid = false;
				this.locationsValid = false;
			}

			private readonly GridLayout _enclosing;
		}

		/// <summary>Layout information associated with each of the children of a GridLayout.
		/// 	</summary>
		/// <remarks>
		/// Layout information associated with each of the children of a GridLayout.
		/// <p>
		/// GridLayout supports both row and column spanning and arbitrary forms of alignment within
		/// each cell group. The fundamental parameters associated with each cell group are
		/// gathered into their vertical and horizontal components and stored
		/// in the
		/// <see cref="rowSpec">rowSpec</see>
		/// and
		/// <see cref="columnSpec">columnSpec</see>
		/// layout parameters.
		/// <see cref="Spec">Specs</see>
		/// are immutable structures
		/// and may be shared between the layout parameters of different children.
		/// <p>
		/// The row and column specs contain the leading and trailing indices along each axis
		/// and together specify the four grid indices that delimit the cells of this cell group.
		/// <p>
		/// The  alignment properties of the row and column specs together specify
		/// both aspects of alignment within the cell group. It is also possible to specify a child's
		/// alignment within its cell group by using the
		/// <see cref="setGravity(int)">setGravity(int)</see>
		/// method.
		/// <h4>WRAP_CONTENT and MATCH_PARENT</h4>
		/// Because the default values of the
		/// <see cref="android.view.ViewGroup.LayoutParams.width">android.view.ViewGroup.LayoutParams.width
		/// 	</see>
		/// and
		/// <see cref="android.view.ViewGroup.LayoutParams.height">android.view.ViewGroup.LayoutParams.height
		/// 	</see>
		/// properties are both
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// , this value never needs to be explicitly
		/// declared in the layout parameters of GridLayout's children. In addition,
		/// GridLayout does not distinguish the special size value
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// from
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// . A component's ability to expand to the size of the parent is
		/// instead controlled by the principle of <em>flexibility</em>,
		/// as discussed in
		/// <see cref="GridLayout">GridLayout</see>
		/// .
		/// <h4>Summary</h4>
		/// You should not need to use either of the special size values:
		/// <code>WRAP_CONTENT</code>
		/// or
		/// <code>MATCH_PARENT</code>
		/// when configuring the children of
		/// a GridLayout.
		/// <h4>Default values</h4>
		/// <ul>
		/// <li>
		/// <see cref="android.view.ViewGroup.LayoutParams.width">android.view.ViewGroup.LayoutParams.width
		/// 	</see>
		/// =
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// </li>
		/// <li>
		/// <see cref="android.view.ViewGroup.LayoutParams.height">android.view.ViewGroup.LayoutParams.height
		/// 	</see>
		/// =
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// </li>
		/// <li>
		/// <see cref="android.view.ViewGroup.MarginLayoutParams.topMargin">android.view.ViewGroup.MarginLayoutParams.topMargin
		/// 	</see>
		/// = 0 when
		/// <see cref="GridLayout.setUseDefaultMargins(bool)">useDefaultMargins</see>
		/// is
		/// <code>false</code>
		/// ; otherwise
		/// <see cref="GridLayout.UNDEFINED">GridLayout.UNDEFINED</see>
		/// , to
		/// indicate that a default value should be computed on demand. </li>
		/// <li>
		/// <see cref="android.view.ViewGroup.MarginLayoutParams.leftMargin">android.view.ViewGroup.MarginLayoutParams.leftMargin
		/// 	</see>
		/// = 0 when
		/// <see cref="GridLayout.setUseDefaultMargins(bool)">useDefaultMargins</see>
		/// is
		/// <code>false</code>
		/// ; otherwise
		/// <see cref="GridLayout.UNDEFINED">GridLayout.UNDEFINED</see>
		/// , to
		/// indicate that a default value should be computed on demand. </li>
		/// <li>
		/// <see cref="android.view.ViewGroup.MarginLayoutParams.bottomMargin">android.view.ViewGroup.MarginLayoutParams.bottomMargin
		/// 	</see>
		/// = 0 when
		/// <see cref="GridLayout.setUseDefaultMargins(bool)">useDefaultMargins</see>
		/// is
		/// <code>false</code>
		/// ; otherwise
		/// <see cref="GridLayout.UNDEFINED">GridLayout.UNDEFINED</see>
		/// , to
		/// indicate that a default value should be computed on demand. </li>
		/// <li>
		/// <see cref="android.view.ViewGroup.MarginLayoutParams.rightMargin">android.view.ViewGroup.MarginLayoutParams.rightMargin
		/// 	</see>
		/// = 0 when
		/// <see cref="GridLayout.setUseDefaultMargins(bool)">useDefaultMargins</see>
		/// is
		/// <code>false</code>
		/// ; otherwise
		/// <see cref="GridLayout.UNDEFINED">GridLayout.UNDEFINED</see>
		/// , to
		/// indicate that a default value should be computed on demand. </li>
		/// <li>
		/// <see cref="rowSpec">rowSpec</see>
		/// <code>.row</code> =
		/// <see cref="GridLayout.UNDEFINED">GridLayout.UNDEFINED</see>
		/// </li>
		/// <li>
		/// <see cref="rowSpec">rowSpec</see>
		/// <code>.rowSpan</code> = 1 </li>
		/// <li>
		/// <see cref="rowSpec">rowSpec</see>
		/// <code>.alignment</code> =
		/// <see cref="GridLayout.BASELINE">GridLayout.BASELINE</see>
		/// </li>
		/// <li>
		/// <see cref="columnSpec">columnSpec</see>
		/// <code>.column</code> =
		/// <see cref="GridLayout.UNDEFINED">GridLayout.UNDEFINED</see>
		/// </li>
		/// <li>
		/// <see cref="columnSpec">columnSpec</see>
		/// <code>.columnSpan</code> = 1 </li>
		/// <li>
		/// <see cref="columnSpec">columnSpec</see>
		/// <code>.alignment</code> =
		/// <see cref="GridLayout.LEFT">GridLayout.LEFT</see>
		/// </li>
		/// </ul>
		/// See
		/// <see cref="GridLayout">GridLayout</see>
		/// for a more complete description of the conventions
		/// used by GridLayout in the interpretation of the properties of this class.
		/// </remarks>
		/// <attr>ref android.R.styleable#GridLayout_Layout_layout_row</attr>
		/// <attr>ref android.R.styleable#GridLayout_Layout_layout_rowSpan</attr>
		/// <attr>ref android.R.styleable#GridLayout_Layout_layout_column</attr>
		/// <attr>ref android.R.styleable#GridLayout_Layout_layout_columnSpan</attr>
		/// <attr>ref android.R.styleable#GridLayout_Layout_layout_gravity</attr>
		public class LayoutParams : android.view.ViewGroup.MarginLayoutParams
		{
			internal const int DEFAULT_WIDTH = WRAP_CONTENT;

			internal const int DEFAULT_HEIGHT = WRAP_CONTENT;

			internal const int DEFAULT_MARGIN = UNDEFINED;

			internal const int DEFAULT_ROW = UNDEFINED;

			internal const int DEFAULT_COLUMN = UNDEFINED;

			private static readonly android.widget.GridLayout.Interval DEFAULT_SPAN = new android.widget.GridLayout
				.Interval(UNDEFINED, UNDEFINED + 1);

			private static readonly int DEFAULT_SPAN_SIZE = DEFAULT_SPAN.size();

			internal const int MARGIN = android.@internal.R.styleable.ViewGroup_MarginLayout_layout_margin;

			internal const int LEFT_MARGIN = android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginLeft;

			internal const int TOP_MARGIN = android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginTop;

			internal const int RIGHT_MARGIN = android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginRight;

			internal const int BOTTOM_MARGIN = android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginBottom;

			internal const int COLUMN = android.@internal.R.styleable.GridLayout_Layout_layout_column;

			internal const int COLUMN_SPAN = android.@internal.R.styleable.GridLayout_Layout_layout_columnSpan;

			internal const int ROW = android.@internal.R.styleable.GridLayout_Layout_layout_row;

			internal const int ROW_SPAN = android.@internal.R.styleable.GridLayout_Layout_layout_rowSpan;

			internal const int GRAVITY = android.@internal.R.styleable.GridLayout_Layout_layout_gravity;

			/// <summary>
			/// The spec that defines the vertical characteristics of the cell group
			/// described by these layout parameters.
			/// </summary>
			/// <remarks>
			/// The spec that defines the vertical characteristics of the cell group
			/// described by these layout parameters.
			/// </remarks>
			public android.widget.GridLayout.Spec rowSpec = android.widget.GridLayout.Spec.UNDEFINED;

			/// <summary>
			/// The spec that defines the horizontal characteristics of the cell group
			/// described by these layout parameters.
			/// </summary>
			/// <remarks>
			/// The spec that defines the horizontal characteristics of the cell group
			/// described by these layout parameters.
			/// </remarks>
			public android.widget.GridLayout.Spec columnSpec = android.widget.GridLayout.Spec
				.UNDEFINED;

			internal LayoutParams(int width, int height, int left, int top, int right, int bottom
				, android.widget.GridLayout.Spec rowSpec, android.widget.GridLayout.Spec columnSpec
				) : base(width, height)
			{
				// Default values
				// TypedArray indices
				// Instance variables
				// Constructors
				setMargins(left, top, right, bottom);
				this.rowSpec = rowSpec;
				this.columnSpec = columnSpec;
			}

			/// <summary>
			/// Constructs a new LayoutParams instance for this <code>rowSpec</code>
			/// and <code>columnSpec</code>.
			/// </summary>
			/// <remarks>
			/// Constructs a new LayoutParams instance for this <code>rowSpec</code>
			/// and <code>columnSpec</code>. All other fields are initialized with
			/// default values as defined in
			/// <see cref="LayoutParams">LayoutParams</see>
			/// .
			/// </remarks>
			/// <param name="rowSpec">the rowSpec</param>
			/// <param name="columnSpec">the columnSpec</param>
			internal LayoutParams(android.widget.GridLayout.Spec rowSpec, android.widget.GridLayout
				.Spec columnSpec) : this(DEFAULT_WIDTH, DEFAULT_HEIGHT, DEFAULT_MARGIN, DEFAULT_MARGIN
				, DEFAULT_MARGIN, DEFAULT_MARGIN, rowSpec, columnSpec)
			{
			}

			/// <summary>
			/// Constructs a new LayoutParams with default values as defined in
			/// <see cref="LayoutParams">LayoutParams</see>
			/// .
			/// </summary>
			internal LayoutParams() : this(android.widget.GridLayout.Spec.UNDEFINED, android.widget.GridLayout
				.Spec.UNDEFINED)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			internal LayoutParams(android.view.ViewGroup.LayoutParams @params) : base(@params
				)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			internal LayoutParams(android.view.ViewGroup.MarginLayoutParams @params) : base(@params
				)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			internal LayoutParams(android.widget.GridLayout.LayoutParams that) : base(that)
			{
				// Copying constructors
				this.rowSpec = that.rowSpec;
				this.columnSpec = that.columnSpec;
			}

			/// <summary>
			/// <inheritDoc></inheritDoc>
			/// Values not defined in the attribute set take the default values
			/// defined in
			/// <see cref="LayoutParams">LayoutParams</see>
			/// .
			/// </summary>
			internal LayoutParams(android.content.Context context, android.util.AttributeSet 
				attrs) : base(context, attrs)
			{
				// AttributeSet constructors
				reInitSuper(context, attrs);
				init(context, attrs);
			}

			// Implementation
			// Reinitialise the margins using a different default policy than MarginLayoutParams.
			// Here we use the value UNDEFINED (as distinct from zero) to represent the undefined state
			// so that a layout manager default can be accessed post set up. We need this as, at the
			// point of installation, we do not know how many rows/cols there are and therefore
			// which elements are positioned next to the container's trailing edges. We need to
			// know this as margins around the container's boundary should have different
			// defaults to those between peers.
			// This method could be parametrized and moved into MarginLayout.
			private void reInitSuper(android.content.Context context, android.util.AttributeSet
				 attrs)
			{
				android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.ViewGroup_MarginLayout);
				try
				{
					int margin = a.getDimensionPixelSize(MARGIN, DEFAULT_MARGIN);
					this.leftMargin = a.getDimensionPixelSize(LEFT_MARGIN, margin);
					this.topMargin = a.getDimensionPixelSize(TOP_MARGIN, margin);
					this.rightMargin = a.getDimensionPixelSize(RIGHT_MARGIN, margin);
					this.bottomMargin = a.getDimensionPixelSize(BOTTOM_MARGIN, margin);
				}
				finally
				{
					a.recycle();
				}
			}

			private void init(android.content.Context context, android.util.AttributeSet attrs
				)
			{
				android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.GridLayout_Layout);
				try
				{
					int gravity = a.getInt(GRAVITY, android.view.Gravity.NO_GRAVITY);
					int column = a.getInt(COLUMN, DEFAULT_COLUMN);
					int colSpan = a.getInt(COLUMN_SPAN, DEFAULT_SPAN_SIZE);
					this.columnSpec = spec(column, colSpan, getAlignment(gravity, true));
					int row = a.getInt(ROW, DEFAULT_ROW);
					int rowSpan = a.getInt(ROW_SPAN, DEFAULT_SPAN_SIZE);
					this.rowSpec = spec(row, rowSpan, getAlignment(gravity, false));
				}
				finally
				{
					a.recycle();
				}
			}

			/// <summary>Describes how the child views are positioned.</summary>
			/// <remarks>
			/// Describes how the child views are positioned. Default is
			/// <code>LEFT | BASELINE</code>
			/// .
			/// See
			/// <see cref="android.view.Gravity">android.view.Gravity</see>
			/// .
			/// </remarks>
			/// <param name="gravity">the new gravity value</param>
			/// <attr>ref android.R.styleable#GridLayout_Layout_layout_gravity</attr>
			public virtual void setGravity(int gravity)
			{
				rowSpec = rowSpec.copyWriteAlignment(getAlignment(gravity, false));
				columnSpec = columnSpec.copyWriteAlignment(getAlignment(gravity, true));
			}

			[Sharpen.OverridesMethod(@"android.view.ViewGroup.LayoutParams")]
			protected internal override void setBaseAttributes(android.content.res.TypedArray
				 attributes, int widthAttr, int heightAttr)
			{
				this.width = attributes.getLayoutDimension(widthAttr, DEFAULT_WIDTH);
				this.height = attributes.getLayoutDimension(heightAttr, DEFAULT_HEIGHT);
			}

			internal void setRowSpecSpan(android.widget.GridLayout.Interval span)
			{
				rowSpec = rowSpec.copyWriteSpan(span);
			}

			internal void setColumnSpecSpan(android.widget.GridLayout.Interval span)
			{
				columnSpec = columnSpec.copyWriteSpan(span);
			}
		}

		internal sealed class Arc
		{
			internal readonly android.widget.GridLayout.Interval span;

			internal readonly android.widget.GridLayout.MutableInt value;

			public bool valid = true;

			internal Arc(android.widget.GridLayout.Interval span, android.widget.GridLayout.MutableInt
				 value)
			{
				this.span = span;
				this.value = value;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return span + " " + (!valid ? "+>" : "->") + " " + value;
			}
		}

		internal sealed class MutableInt
		{
			public int value;

			internal MutableInt()
			{
				// A mutable Integer - used to avoid heap allocation during the layout operation
				reset();
			}

			internal MutableInt(int value)
			{
				this.value = value;
			}

			public void reset()
			{
				value = int.MinValue;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return System.Convert.ToString(value);
			}
		}

		[System.Serializable]
		internal sealed class Assoc<K, V> : java.util.ArrayList<android.util.Pair<K, V>>
		{
			private readonly System.Type keyType;

			private readonly System.Type valueType;

			internal Assoc(System.Type keyType, System.Type valueType)
			{
				this.keyType = keyType;
				this.valueType = valueType;
			}

			internal static android.widget.GridLayout.Assoc<K, V> of<K, V>()
			{
				System.Type keyType = typeof(K);
				System.Type valueType = typeof(V);
				return new android.widget.GridLayout.Assoc<K, V>(keyType, valueType);
			}

			public void put(K key, V value)
			{
				add(android.util.Pair<K, V>.create<K, V>(key, value));
			}

			internal android.widget.GridLayout.PackedMap<K, V> pack()
			{
				int N = size();
				K[] keys = (K[])System.Array.CreateInstance(keyType, N);
				V[] values = (V[])System.Array.CreateInstance(valueType, N);
				{
					for (int i = 0; i < N; i++)
					{
						keys[i] = get(i).first;
						values[i] = get(i).second;
					}
				}
				return new android.widget.GridLayout.PackedMap<K, V>(keys, values);
			}
		}

		internal sealed class PackedMap<K, V>
		{
			public readonly int[] index;

			internal readonly K[] keys;

			internal readonly V[] values;

			internal PackedMap(K[] keys, V[] values)
			{
				this.index = createIndex(keys);
				this.keys = compact(keys, index);
				this.values = compact(values, index);
			}

			public V getValue(int i)
			{
				return values[index[i]];
			}

			private static int[] createIndex<K>(K[] keys)
			{
				int size = keys.Length;
				int[] result = new int[size];
				java.util.Map<K, int> keyToIndex = new java.util.HashMap<K, int>();
				{
					for (int i = 0; i < size; i++)
					{
						K key = keys[i];
						int index = keyToIndex.get(key);
						if (index == null)
						{
							index = keyToIndex.size();
							keyToIndex.put(key, index);
						}
						result[i] = index;
					}
				}
				return result;
			}

			private static K[] compact<K>(K[] a, int[] index)
			{
				int size = a.Length;
				System.Type componentType = a.GetType().GetElementType();
				K[] result = (K[])System.Array.CreateInstance(componentType, max2(index, -1) + 1);
				{
					// this overwrite duplicates, retaining the last equivalent entry
					for (int i = 0; i < size; i++)
					{
						result[index[i]] = a[i];
					}
				}
				return result;
			}
		}

		internal class Bounds
		{
			public int before;

			public int after;

			public int flexibility;

			internal Bounds()
			{
				// we're flexible iff all included specs are flexible
				reset();
			}

			protected internal virtual void reset()
			{
				before = int.MinValue;
				after = int.MinValue;
				flexibility = CAN_STRETCH;
			}

			// from the above, we're flexible when empty
			protected internal virtual void include(int before, int after)
			{
				this.before = System.Math.Max(this.before, before);
				this.after = System.Math.Max(this.after, after);
			}

			protected internal virtual int size(bool min)
			{
				if (!min)
				{
					if (canStretch(flexibility))
					{
						return MAX_SIZE;
					}
				}
				return before + after;
			}

			protected internal virtual int getOffset(android.view.View c, android.widget.GridLayout
				.Alignment alignment, int size_1)
			{
				return before - alignment.getAlignmentValue(c, size_1);
			}

			internal void include(android.view.View c, android.widget.GridLayout.Spec spec, android.widget.GridLayout
				 gridLayout, android.widget.GridLayout.Axis axis)
			{
				this.flexibility &= spec.getFlexibility();
				int size_1 = gridLayout.getMeasurementIncludingMargin(c, axis.horizontal);
				android.widget.GridLayout.Alignment alignment = gridLayout.getAlignment(spec.alignment
					, axis.horizontal);
				// todo test this works correctly when the returned value is UNDEFINED
				int before = alignment.getAlignmentValue(c, size_1);
				include(before, size_1 - before);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "Bounds{" + "before=" + before + ", after=" + after + '}';
			}
		}

		/// <summary>
		/// An Interval represents a contiguous range of values that lie between
		/// the interval's
		/// <see cref="min">min</see>
		/// and
		/// <see cref="max">max</see>
		/// values.
		/// <p>
		/// Intervals are immutable so may be passed as values and used as keys in hash tables.
		/// It is not necessary to have multiple instances of Intervals which have the same
		/// <see cref="min">min</see>
		/// and
		/// <see cref="max">max</see>
		/// values.
		/// <p>
		/// Intervals are often written as
		/// <code>[min, max]</code>
		/// and represent the set of values
		/// <code>x</code>
		/// such that
		/// <code>min &lt;= x &lt; max</code>
		/// .
		/// </summary>
		internal sealed class Interval
		{
			/// <summary>The minimum value.</summary>
			/// <remarks>The minimum value.</remarks>
			public readonly int min;

			/// <summary>The maximum value.</summary>
			/// <remarks>The maximum value.</remarks>
			public readonly int max;

			/// <summary>
			/// Construct a new Interval,
			/// <code>interval</code>
			/// , where:
			/// <ul>
			/// <li>
			/// <code>interval.min = min</code>
			/// </li>
			/// <li>
			/// <code>interval.max = max</code>
			/// </li>
			/// </ul>
			/// </summary>
			/// <param name="min">the minimum value.</param>
			/// <param name="max">the maximum value.</param>
			internal Interval(int min, int max)
			{
				this.min = min;
				this.max = max;
			}

			internal int size()
			{
				return max - min;
			}

			internal android.widget.GridLayout.Interval inverse()
			{
				return new android.widget.GridLayout.Interval(max, min);
			}

			/// <summary>
			/// Returns
			/// <code>true</code>
			/// if the
			/// <see cref="object.GetType()">class</see>
			/// ,
			/// <see cref="min">min</see>
			/// and
			/// <see cref="max">max</see>
			/// properties of this Interval and the
			/// supplied parameter are pairwise equal;
			/// <code>false</code>
			/// otherwise.
			/// </summary>
			/// <param name="that">the object to compare this interval with</param>
			/// <returns>
			/// 
			/// <code>true</code>
			/// if the specified object is equal to this
			/// <code>Interval</code>
			/// ,
			/// <code>false</code>
			/// otherwise.
			/// </returns>
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object that)
			{
				if (this == that)
				{
					return true;
				}
				if (that == null || GetType() != that.GetType())
				{
					return false;
				}
				android.widget.GridLayout.Interval interval = (android.widget.GridLayout.Interval
					)that;
				if (max != interval.max)
				{
					return false;
				}
				//noinspection RedundantIfStatement
				if (min != interval.min)
				{
					return false;
				}
				return true;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				int result = min;
				result = 31 * result + max;
				return result;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "[" + min + ", " + max + "]";
			}
		}

		/// <summary>
		/// A Spec defines the horizontal or vertical characteristics of a group of
		/// cells.
		/// </summary>
		/// <remarks>
		/// A Spec defines the horizontal or vertical characteristics of a group of
		/// cells. Each spec. defines the <em>grid indices</em> and <em>alignment</em>
		/// along the appropriate axis.
		/// <p>
		/// The <em>grid indices</em> are the leading and trailing edges of this cell group.
		/// See
		/// <see cref="GridLayout">GridLayout</see>
		/// for a description of the conventions used by GridLayout
		/// for grid indices.
		/// <p>
		/// The <em>alignment</em> property specifies how cells should be aligned in this group.
		/// For row groups, this specifies the vertical alignment.
		/// For column groups, this specifies the horizontal alignment.
		/// <p>
		/// Use the following static methods to create specs:
		/// <ul>
		/// <li>
		/// <see cref="GridLayout.spec(int)">GridLayout.spec(int)</see>
		/// </li>
		/// <li>
		/// <see cref="GridLayout.spec(int, int)">GridLayout.spec(int, int)</see>
		/// </li>
		/// <li>
		/// <see cref="GridLayout.spec(int, Alignment)">GridLayout.spec(int, Alignment)</see>
		/// </li>
		/// <li>
		/// <see cref="GridLayout.spec(int, int, Alignment)">GridLayout.spec(int, int, Alignment)
		/// 	</see>
		/// </li>
		/// </ul>
		/// </remarks>
		public class Spec
		{
			internal static readonly android.widget.GridLayout.Spec UNDEFINED = spec(android.widget.GridLayout
				.UNDEFINED);

			internal readonly bool startDefined;

			internal readonly android.widget.GridLayout.Interval span;

			internal readonly android.widget.GridLayout.Alignment alignment;

			internal Spec(bool startDefined, android.widget.GridLayout.Interval span, android.widget.GridLayout
				.Alignment alignment)
			{
				this.startDefined = startDefined;
				this.span = span;
				this.alignment = alignment;
			}

			internal Spec(bool startDefined, int start, int size, android.widget.GridLayout.Alignment
				 alignment) : this(startDefined, new android.widget.GridLayout.Interval(start, start
				 + size), alignment)
			{
			}

			internal android.widget.GridLayout.Spec copyWriteSpan(android.widget.GridLayout.Interval
				 span)
			{
				return new android.widget.GridLayout.Spec(startDefined, span, alignment);
			}

			internal android.widget.GridLayout.Spec copyWriteAlignment(android.widget.GridLayout
				.Alignment alignment)
			{
				return new android.widget.GridLayout.Spec(startDefined, span, alignment);
			}

			internal int getFlexibility()
			{
				return (alignment == UNDEFINED_ALIGNMENT) ? INFLEXIBLE : CAN_STRETCH;
			}

			/// <summary>
			/// Returns
			/// <code>true</code>
			/// if the
			/// <code>class</code>
			/// ,
			/// <code>alignment</code>
			/// and
			/// <code>span</code>
			/// properties of this Spec and the supplied parameter are pairwise equal,
			/// <code>false</code>
			/// otherwise.
			/// </summary>
			/// <param name="that">the object to compare this spec with</param>
			/// <returns>
			/// 
			/// <code>true</code>
			/// if the specified object is equal to this
			/// <code>Spec</code>
			/// ;
			/// <code>false</code>
			/// otherwise
			/// </returns>
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object that)
			{
				if (this == that)
				{
					return true;
				}
				if (that == null || GetType() != that.GetType())
				{
					return false;
				}
				android.widget.GridLayout.Spec spec = (android.widget.GridLayout.Spec)that;
				if (!alignment.Equals(spec.alignment))
				{
					return false;
				}
				//noinspection RedundantIfStatement
				if (!span.Equals(spec.span))
				{
					return false;
				}
				return true;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				int result = span.GetHashCode();
				result = 31 * result + alignment.GetHashCode();
				return result;
			}
		}

		/// <summary>
		/// Return a Spec,
		/// <code>spec</code>
		/// , where:
		/// <ul>
		/// <li>
		/// <code>spec.span = [start, start + size]</code>
		/// </li>
		/// <li>
		/// <code>spec.alignment = alignment</code>
		/// </li>
		/// </ul>
		/// </summary>
		/// <param name="start">the start</param>
		/// <param name="size">the size</param>
		/// <param name="alignment">the alignment</param>
		public static android.widget.GridLayout.Spec spec(int start, int size, android.widget.GridLayout
			.Alignment alignment)
		{
			return new android.widget.GridLayout.Spec(start != UNDEFINED, start, size, alignment
				);
		}

		/// <summary>
		/// Return a Spec,
		/// <code>spec</code>
		/// , where:
		/// <ul>
		/// <li>
		/// <code>spec.span = [start, start + 1]</code>
		/// </li>
		/// <li>
		/// <code>spec.alignment = alignment</code>
		/// </li>
		/// </ul>
		/// </summary>
		/// <param name="start">the start index</param>
		/// <param name="alignment">the alignment</param>
		public static android.widget.GridLayout.Spec spec(int start, android.widget.GridLayout
			.Alignment alignment)
		{
			return spec(start, 1, alignment);
		}

		/// <summary>
		/// Return a Spec,
		/// <code>spec</code>
		/// , where:
		/// <ul>
		/// <li>
		/// <code>spec.span = [start, start + size]</code>
		/// </li>
		/// </ul>
		/// </summary>
		/// <param name="start">the start</param>
		/// <param name="size">the size</param>
		public static android.widget.GridLayout.Spec spec(int start, int size)
		{
			return spec(start, size, UNDEFINED_ALIGNMENT);
		}

		/// <summary>
		/// Return a Spec,
		/// <code>spec</code>
		/// , where:
		/// <ul>
		/// <li>
		/// <code>spec.span = [start, start + 1]</code>
		/// </li>
		/// </ul>
		/// </summary>
		/// <param name="start">the start index</param>
		public static android.widget.GridLayout.Spec spec(int start)
		{
			return spec(start, 1);
		}

		/// <summary>
		/// Alignments specify where a view should be placed within a cell group and
		/// what size it should be.
		/// </summary>
		/// <remarks>
		/// Alignments specify where a view should be placed within a cell group and
		/// what size it should be.
		/// <p>
		/// The
		/// <see cref="LayoutParams">LayoutParams</see>
		/// class contains a
		/// <see cref="LayoutParams.rowSpec">rowSpec</see>
		/// and a
		/// <see cref="LayoutParams.columnSpec">columnSpec</see>
		/// each of which contains an
		/// <code>alignment</code>
		/// . Overall placement of the view in the cell
		/// group is specified by the two alignments which act along each axis independently.
		/// <p>
		/// The GridLayout class defines the most common alignments used in general layout:
		/// <see cref="GridLayout.TOP">GridLayout.TOP</see>
		/// ,
		/// <see cref="GridLayout.LEFT">GridLayout.LEFT</see>
		/// ,
		/// <see cref="GridLayout.BOTTOM">GridLayout.BOTTOM</see>
		/// ,
		/// <see cref="GridLayout.RIGHT">GridLayout.RIGHT</see>
		/// ,
		/// <see cref="GridLayout.CENTER">GridLayout.CENTER</see>
		/// ,
		/// <see cref="GridLayout.BASELINE">GridLayout.BASELINE</see>
		/// and
		/// <see cref="GridLayout.FILL">GridLayout.FILL</see>
		/// .
		/// </remarks>
		public abstract class Alignment
		{
			internal Alignment()
			{
			}

			/// <summary>Returns an alignment value.</summary>
			/// <remarks>
			/// Returns an alignment value. In the case of vertical alignments the value
			/// returned should indicate the distance from the top of the view to the
			/// alignment location.
			/// For horizontal alignments measurement is made from the left edge of the component.
			/// </remarks>
			/// <param name="view">the view to which this alignment should be applied</param>
			/// <param name="viewSize">the measured size of the view</param>
			/// <returns>the alignment value</returns>
			internal abstract int getAlignmentValue(android.view.View view, int viewSize);

			/// <summary>Returns the size of the view specified by this alignment.</summary>
			/// <remarks>
			/// Returns the size of the view specified by this alignment.
			/// In the case of vertical alignments this method should return a height; for
			/// horizontal alignments this method should return the width.
			/// <p>
			/// The default implementation returns
			/// <code>viewSize</code>
			/// .
			/// </remarks>
			/// <param name="view">the view to which this alignment should be applied</param>
			/// <param name="viewSize">the measured size of the view</param>
			/// <param name="cellSize">the size of the cell into which this view will be placed</param>
			/// <param name="measurementType">
			/// This parameter is currently unused as GridLayout only supports
			/// one type of measurement:
			/// <see cref="android.view.View.measure(int, int)">android.view.View.measure(int, int)
			/// 	</see>
			/// .
			/// </param>
			/// <returns>the aligned size</returns>
			internal virtual int getSizeInCell(android.view.View view, int viewSize, int cellSize
				, int measurementType)
			{
				return viewSize;
			}

			internal virtual android.widget.GridLayout.Bounds getBounds()
			{
				return new android.widget.GridLayout.Bounds();
			}
		}

		private sealed class _Alignment_2388 : android.widget.GridLayout.Alignment
		{
			public _Alignment_2388()
			{
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override int getAlignmentValue(android.view.View view, int viewSize)
			{
				return android.widget.GridLayout.UNDEFINED;
			}
		}

		internal static readonly android.widget.GridLayout.Alignment UNDEFINED_ALIGNMENT = 
			new _Alignment_2388();

		private sealed class _Alignment_2394 : android.widget.GridLayout.Alignment
		{
			public _Alignment_2394()
			{
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override int getAlignmentValue(android.view.View view, int viewSize)
			{
				return 0;
			}
		}

		private static readonly android.widget.GridLayout.Alignment LEADING = new _Alignment_2394
			();

		private sealed class _Alignment_2400 : android.widget.GridLayout.Alignment
		{
			public _Alignment_2400()
			{
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override int getAlignmentValue(android.view.View view, int viewSize)
			{
				return viewSize;
			}
		}

		private static readonly android.widget.GridLayout.Alignment TRAILING = new _Alignment_2400
			();

		/// <summary>
		/// Indicates that a view should be aligned with the <em>top</em>
		/// edges of the other views in its cell group.
		/// </summary>
		/// <remarks>
		/// Indicates that a view should be aligned with the <em>top</em>
		/// edges of the other views in its cell group.
		/// </remarks>
		public static readonly android.widget.GridLayout.Alignment TOP = LEADING;

		/// <summary>
		/// Indicates that a view should be aligned with the <em>bottom</em>
		/// edges of the other views in its cell group.
		/// </summary>
		/// <remarks>
		/// Indicates that a view should be aligned with the <em>bottom</em>
		/// edges of the other views in its cell group.
		/// </remarks>
		public static readonly android.widget.GridLayout.Alignment BOTTOM = TRAILING;

		/// <summary>
		/// Indicates that a view should be aligned with the <em>right</em>
		/// edges of the other views in its cell group.
		/// </summary>
		/// <remarks>
		/// Indicates that a view should be aligned with the <em>right</em>
		/// edges of the other views in its cell group.
		/// </remarks>
		public static readonly android.widget.GridLayout.Alignment RIGHT = TRAILING;

		/// <summary>
		/// Indicates that a view should be aligned with the <em>left</em>
		/// edges of the other views in its cell group.
		/// </summary>
		/// <remarks>
		/// Indicates that a view should be aligned with the <em>left</em>
		/// edges of the other views in its cell group.
		/// </remarks>
		public static readonly android.widget.GridLayout.Alignment LEFT = LEADING;

		private sealed class _Alignment_2435 : android.widget.GridLayout.Alignment
		{
			public _Alignment_2435()
			{
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override int getAlignmentValue(android.view.View view, int viewSize)
			{
				return viewSize >> 1;
			}
		}

		/// <summary>Indicates that a view should be <em>centered</em> with the other views in its cell group.
		/// 	</summary>
		/// <remarks>
		/// Indicates that a view should be <em>centered</em> with the other views in its cell group.
		/// This constant may be used in both
		/// <see cref="LayoutParams.rowSpec">rowSpecs</see>
		/// and
		/// <see cref="LayoutParams.columnSpec">columnSpecs</see>
		/// .
		/// </remarks>
		public static readonly android.widget.GridLayout.Alignment CENTER = new _Alignment_2435
			();

		private sealed class _Alignment_2448 : android.widget.GridLayout.Alignment
		{
			public _Alignment_2448()
			{
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override int getAlignmentValue(android.view.View view, int viewSize)
			{
				if (view == null)
				{
					return android.widget.GridLayout.UNDEFINED;
				}
				int baseline = view.getBaseline();
				return (baseline == -1) ? android.widget.GridLayout.UNDEFINED : baseline;
			}

			private sealed class _Bounds_2459 : android.widget.GridLayout.Bounds
			{
				public _Bounds_2459()
				{
				}

				private int _size;

				[Sharpen.OverridesMethod(@"android.widget.GridLayout.Bounds")]
				protected internal override void reset()
				{
					base.reset();
					this._size = int.MinValue;
				}

				[Sharpen.OverridesMethod(@"android.widget.GridLayout.Bounds")]
				protected internal override void include(int before, int after)
				{
					base.include(before, after);
					this._size = System.Math.Max(this._size, before + after);
				}

				[Sharpen.OverridesMethod(@"android.widget.GridLayout.Bounds")]
				protected internal override int size(bool min)
				{
					return System.Math.Max(base.size(min), this._size);
				}

				[Sharpen.OverridesMethod(@"android.widget.GridLayout.Bounds")]
				protected internal override int getOffset(android.view.View c, android.widget.GridLayout
					.Alignment alignment, int size_1)
				{
					return System.Math.Max(0, base.getOffset(c, alignment, size_1));
				}
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override android.widget.GridLayout.Bounds getBounds()
			{
				return new _Bounds_2459();
			}
		}

		/// <summary>
		/// Indicates that a view should be aligned with the <em>baselines</em>
		/// of the other views in its cell group.
		/// </summary>
		/// <remarks>
		/// Indicates that a view should be aligned with the <em>baselines</em>
		/// of the other views in its cell group.
		/// This constant may only be used as an alignment in
		/// <see cref="LayoutParams.rowSpec">rowSpecs</see>
		/// .
		/// </remarks>
		/// <seealso cref="android.view.View.getBaseline()">android.view.View.getBaseline()</seealso>
		public static readonly android.widget.GridLayout.Alignment BASELINE = new _Alignment_2448
			();

		private sealed class _Alignment_2498 : android.widget.GridLayout.Alignment
		{
			public _Alignment_2498()
			{
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override int getAlignmentValue(android.view.View view, int viewSize)
			{
				return android.widget.GridLayout.UNDEFINED;
			}

			[Sharpen.OverridesMethod(@"android.widget.GridLayout.Alignment")]
			internal override int getSizeInCell(android.view.View view, int viewSize, int cellSize
				, int measurementType)
			{
				return cellSize;
			}
		}

		/// <summary>Indicates that a view should expanded to fit the boundaries of its cell group.
		/// 	</summary>
		/// <remarks>
		/// Indicates that a view should expanded to fit the boundaries of its cell group.
		/// This constant may be used in both
		/// <see cref="LayoutParams.rowSpec">rowSpecs</see>
		/// and
		/// <see cref="LayoutParams.columnSpec">columnSpecs</see>
		/// .
		/// </remarks>
		public static readonly android.widget.GridLayout.Alignment FILL = new _Alignment_2498
			();

		internal static bool canStretch(int flexibility)
		{
			return (flexibility & CAN_STRETCH) != 0;
		}

		internal const int INFLEXIBLE = 0;

		internal const int CAN_STRETCH = 2;
	}
}
