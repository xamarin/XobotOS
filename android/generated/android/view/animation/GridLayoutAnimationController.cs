using Sharpen;

namespace android.view.animation
{
	/// <summary>A layout animation controller is used to animated a grid layout's children.
	/// 	</summary>
	/// <remarks>
	/// A layout animation controller is used to animated a grid layout's children.
	/// While
	/// <see cref="LayoutAnimationController">LayoutAnimationController</see>
	/// relies only on the index of the child
	/// in the view group to compute the animation delay, this class uses both the
	/// X and Y coordinates of the child within a grid.
	/// In addition, the animation direction can be controlled. The default direction
	/// is <code>DIRECTION_LEFT_TO_RIGHT | DIRECTION_TOP_TO_BOTTOM</code>. You can
	/// also set the animation priority to columns or rows. The default priority is
	/// none.
	/// Information used to compute the animation delay of each child are stored
	/// in an instance of
	/// <see cref="AnimationParameters">AnimationParameters</see>
	/// ,
	/// itself stored in the
	/// <see cref="android.view.ViewGroup.LayoutParams">android.view.ViewGroup.LayoutParams
	/// 	</see>
	/// of the view.
	/// </remarks>
	/// <seealso cref="LayoutAnimationController">LayoutAnimationController</seealso>
	/// <seealso cref="android.widget.GridView">android.widget.GridView</seealso>
	/// <attr>ref android.R.styleable#GridLayoutAnimation_columnDelay</attr>
	/// <attr>ref android.R.styleable#GridLayoutAnimation_rowDelay</attr>
	/// <attr>ref android.R.styleable#GridLayoutAnimation_direction</attr>
	/// <attr>ref android.R.styleable#GridLayoutAnimation_directionPriority</attr>
	[Sharpen.Sharpened]
	public class GridLayoutAnimationController : android.view.animation.LayoutAnimationController
	{
		/// <summary>Animates the children starting from the left of the grid to the right.</summary>
		/// <remarks>Animates the children starting from the left of the grid to the right.</remarks>
		public const int DIRECTION_LEFT_TO_RIGHT = unchecked((int)(0x0));

		/// <summary>Animates the children starting from the right of the grid to the left.</summary>
		/// <remarks>Animates the children starting from the right of the grid to the left.</remarks>
		public const int DIRECTION_RIGHT_TO_LEFT = unchecked((int)(0x1));

		/// <summary>Animates the children starting from the top of the grid to the bottom.</summary>
		/// <remarks>Animates the children starting from the top of the grid to the bottom.</remarks>
		public const int DIRECTION_TOP_TO_BOTTOM = unchecked((int)(0x0));

		/// <summary>Animates the children starting from the bottom of the grid to the top.</summary>
		/// <remarks>Animates the children starting from the bottom of the grid to the top.</remarks>
		public const int DIRECTION_BOTTOM_TO_TOP = unchecked((int)(0x2));

		/// <summary>Bitmask used to retrieve the horizontal component of the direction.</summary>
		/// <remarks>Bitmask used to retrieve the horizontal component of the direction.</remarks>
		public const int DIRECTION_HORIZONTAL_MASK = unchecked((int)(0x1));

		/// <summary>Bitmask used to retrieve the vertical component of the direction.</summary>
		/// <remarks>Bitmask used to retrieve the vertical component of the direction.</remarks>
		public const int DIRECTION_VERTICAL_MASK = unchecked((int)(0x2));

		/// <summary>Rows and columns are animated at the same time.</summary>
		/// <remarks>Rows and columns are animated at the same time.</remarks>
		public const int PRIORITY_NONE = 0;

		/// <summary>Columns are animated first.</summary>
		/// <remarks>Columns are animated first.</remarks>
		public const int PRIORITY_COLUMN = 1;

		/// <summary>Rows are animated first.</summary>
		/// <remarks>Rows are animated first.</remarks>
		public const int PRIORITY_ROW = 2;

		private float mColumnDelay;

		private float mRowDelay;

		private int mDirection;

		private int mDirectionPriority;

		/// <summary>Creates a new grid layout animation controller from external resources.</summary>
		/// <remarks>Creates a new grid layout animation controller from external resources.</remarks>
		/// <param name="context">
		/// the Context the view  group is running in, through which
		/// it can access the resources
		/// </param>
		/// <param name="attrs">
		/// the attributes of the XML tag that is inflating the
		/// layout animation controller
		/// </param>
		public GridLayoutAnimationController(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.GridLayoutAnimation);
			android.view.animation.Animation.Description d = android.view.animation.Animation
				.Description.parseValue(a.peekValue(android.@internal.R.styleable.GridLayoutAnimation_columnDelay
				));
			mColumnDelay = d.value;
			d = android.view.animation.Animation.Description.parseValue(a.peekValue(android.@internal.R
				.styleable.GridLayoutAnimation_rowDelay));
			mRowDelay = d.value;
			//noinspection PointlessBitwiseExpression
			mDirection = a.getInt(android.@internal.R.styleable.GridLayoutAnimation_direction
				, DIRECTION_LEFT_TO_RIGHT | DIRECTION_TOP_TO_BOTTOM);
			mDirectionPriority = a.getInt(android.@internal.R.styleable.GridLayoutAnimation_directionPriority
				, PRIORITY_NONE);
			a.recycle();
		}

		/// <summary>
		/// Creates a new layout animation controller with a delay of 50%
		/// for both rows and columns and the specified animation.
		/// </summary>
		/// <remarks>
		/// Creates a new layout animation controller with a delay of 50%
		/// for both rows and columns and the specified animation.
		/// </remarks>
		/// <param name="animation">the animation to use on each child of the view group</param>
		public GridLayoutAnimationController(android.view.animation.Animation animation) : 
			this(animation, 0.5f, 0.5f)
		{
		}

		/// <summary>
		/// Creates a new layout animation controller with the specified delays
		/// and the specified animation.
		/// </summary>
		/// <remarks>
		/// Creates a new layout animation controller with the specified delays
		/// and the specified animation.
		/// </remarks>
		/// <param name="animation">the animation to use on each child of the view group</param>
		/// <param name="columnDelay">the delay by which each column animation must be offset
		/// 	</param>
		/// <param name="rowDelay">the delay by which each row animation must be offset</param>
		public GridLayoutAnimationController(android.view.animation.Animation animation, 
			float columnDelay, float rowDelay) : base(animation)
		{
			mColumnDelay = columnDelay;
			mRowDelay = rowDelay;
		}

		/// <summary>
		/// Returns the delay by which the children's animation are offset from one
		/// column to the other.
		/// </summary>
		/// <remarks>
		/// Returns the delay by which the children's animation are offset from one
		/// column to the other. The delay is expressed as a fraction of the
		/// animation duration.
		/// </remarks>
		/// <returns>a fraction of the animation duration</returns>
		/// <seealso cref="setColumnDelay(float)">setColumnDelay(float)</seealso>
		/// <seealso cref="getRowDelay()">getRowDelay()</seealso>
		/// <seealso cref="setRowDelay(float)">setRowDelay(float)</seealso>
		public virtual float getColumnDelay()
		{
			return mColumnDelay;
		}

		/// <summary>
		/// Sets the delay, as a fraction of the animation duration, by which the
		/// children's animations are offset from one column to the other.
		/// </summary>
		/// <remarks>
		/// Sets the delay, as a fraction of the animation duration, by which the
		/// children's animations are offset from one column to the other.
		/// </remarks>
		/// <param name="columnDelay">a fraction of the animation duration</param>
		/// <seealso cref="getColumnDelay()">getColumnDelay()</seealso>
		/// <seealso cref="getRowDelay()">getRowDelay()</seealso>
		/// <seealso cref="setRowDelay(float)">setRowDelay(float)</seealso>
		public virtual void setColumnDelay(float columnDelay)
		{
			mColumnDelay = columnDelay;
		}

		/// <summary>
		/// Returns the delay by which the children's animation are offset from one
		/// row to the other.
		/// </summary>
		/// <remarks>
		/// Returns the delay by which the children's animation are offset from one
		/// row to the other. The delay is expressed as a fraction of the
		/// animation duration.
		/// </remarks>
		/// <returns>a fraction of the animation duration</returns>
		/// <seealso cref="setRowDelay(float)">setRowDelay(float)</seealso>
		/// <seealso cref="getColumnDelay()">getColumnDelay()</seealso>
		/// <seealso cref="setColumnDelay(float)">setColumnDelay(float)</seealso>
		public virtual float getRowDelay()
		{
			return mRowDelay;
		}

		/// <summary>
		/// Sets the delay, as a fraction of the animation duration, by which the
		/// children's animations are offset from one row to the other.
		/// </summary>
		/// <remarks>
		/// Sets the delay, as a fraction of the animation duration, by which the
		/// children's animations are offset from one row to the other.
		/// </remarks>
		/// <param name="rowDelay">a fraction of the animation duration</param>
		/// <seealso cref="getRowDelay()">getRowDelay()</seealso>
		/// <seealso cref="getColumnDelay()">getColumnDelay()</seealso>
		/// <seealso cref="setColumnDelay(float)"></seealso>
		public virtual void setRowDelay(float rowDelay)
		{
			mRowDelay = rowDelay;
		}

		/// <summary>Returns the direction of the animation.</summary>
		/// <remarks>
		/// Returns the direction of the animation.
		/// <see cref="DIRECTION_HORIZONTAL_MASK">DIRECTION_HORIZONTAL_MASK</see>
		/// and
		/// <see cref="DIRECTION_VERTICAL_MASK">DIRECTION_VERTICAL_MASK</see>
		/// can be used to retrieve the
		/// horizontal and vertical components of the direction.
		/// </remarks>
		/// <returns>the direction of the animation</returns>
		/// <seealso cref="setDirection(int)">setDirection(int)</seealso>
		/// <seealso cref="DIRECTION_BOTTOM_TO_TOP">DIRECTION_BOTTOM_TO_TOP</seealso>
		/// <seealso cref="DIRECTION_TOP_TO_BOTTOM">DIRECTION_TOP_TO_BOTTOM</seealso>
		/// <seealso cref="DIRECTION_LEFT_TO_RIGHT">DIRECTION_LEFT_TO_RIGHT</seealso>
		/// <seealso cref="DIRECTION_RIGHT_TO_LEFT">DIRECTION_RIGHT_TO_LEFT</seealso>
		/// <seealso cref="DIRECTION_HORIZONTAL_MASK">DIRECTION_HORIZONTAL_MASK</seealso>
		/// <seealso cref="DIRECTION_VERTICAL_MASK">DIRECTION_VERTICAL_MASK</seealso>
		public virtual int getDirection()
		{
			return mDirection;
		}

		/// <summary>Sets the direction of the animation.</summary>
		/// <remarks>
		/// Sets the direction of the animation. The direction is expressed as an
		/// integer containing a horizontal and vertical component. For instance,
		/// <code>DIRECTION_BOTTOM_TO_TOP | DIRECTION_RIGHT_TO_LEFT</code>.
		/// </remarks>
		/// <param name="direction">the direction of the animation</param>
		/// <seealso cref="getDirection()">getDirection()</seealso>
		/// <seealso cref="DIRECTION_BOTTOM_TO_TOP">DIRECTION_BOTTOM_TO_TOP</seealso>
		/// <seealso cref="DIRECTION_TOP_TO_BOTTOM">DIRECTION_TOP_TO_BOTTOM</seealso>
		/// <seealso cref="DIRECTION_LEFT_TO_RIGHT">DIRECTION_LEFT_TO_RIGHT</seealso>
		/// <seealso cref="DIRECTION_RIGHT_TO_LEFT">DIRECTION_RIGHT_TO_LEFT</seealso>
		/// <seealso cref="DIRECTION_HORIZONTAL_MASK">DIRECTION_HORIZONTAL_MASK</seealso>
		/// <seealso cref="DIRECTION_VERTICAL_MASK">DIRECTION_VERTICAL_MASK</seealso>
		public virtual void setDirection(int direction)
		{
			mDirection = direction;
		}

		/// <summary>Returns the direction priority for the animation.</summary>
		/// <remarks>
		/// Returns the direction priority for the animation. The priority can
		/// be either
		/// <see cref="PRIORITY_NONE">PRIORITY_NONE</see>
		/// ,
		/// <see cref="PRIORITY_COLUMN">PRIORITY_COLUMN</see>
		/// or
		/// <see cref="PRIORITY_ROW">PRIORITY_ROW</see>
		/// .
		/// </remarks>
		/// <returns>the priority of the animation direction</returns>
		/// <seealso cref="setDirectionPriority(int)">setDirectionPriority(int)</seealso>
		/// <seealso cref="PRIORITY_COLUMN">PRIORITY_COLUMN</seealso>
		/// <seealso cref="PRIORITY_NONE">PRIORITY_NONE</seealso>
		/// <seealso cref="PRIORITY_ROW">PRIORITY_ROW</seealso>
		public virtual int getDirectionPriority()
		{
			return mDirectionPriority;
		}

		/// <summary>Specifies the direction priority of the animation.</summary>
		/// <remarks>
		/// Specifies the direction priority of the animation. For instance,
		/// <see cref="PRIORITY_COLUMN">PRIORITY_COLUMN</see>
		/// will give priority to columns: the animation
		/// will first play on the column, then on the rows.Z
		/// </remarks>
		/// <param name="directionPriority">the direction priority of the animation</param>
		/// <seealso cref="getDirectionPriority()">getDirectionPriority()</seealso>
		/// <seealso cref="PRIORITY_COLUMN">PRIORITY_COLUMN</seealso>
		/// <seealso cref="PRIORITY_NONE">PRIORITY_NONE</seealso>
		/// <seealso cref="PRIORITY_ROW">PRIORITY_ROW</seealso>
		public virtual void setDirectionPriority(int directionPriority)
		{
			mDirectionPriority = directionPriority;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.animation.LayoutAnimationController")]
		public override bool willOverlap()
		{
			return mColumnDelay < 1.0f || mRowDelay < 1.0f;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.animation.LayoutAnimationController")]
		protected internal override long getDelayForView(android.view.View view)
		{
			android.view.ViewGroup.LayoutParams lp = view.getLayoutParams();
			android.view.animation.GridLayoutAnimationController.AnimationParameters @params = 
				(android.view.animation.GridLayoutAnimationController.AnimationParameters)lp.layoutAnimationParameters;
			if (@params == null)
			{
				return 0;
			}
			int column = getTransformedColumnIndex(@params);
			int row = getTransformedRowIndex(@params);
			int rowsCount = @params.rowsCount;
			int columnsCount = @params.columnsCount;
			long duration = mAnimation.getDuration();
			float columnDelay = mColumnDelay * duration;
			float rowDelay = mRowDelay * duration;
			float totalDelay;
			long viewDelay;
			if (mInterpolator == null)
			{
				mInterpolator = new android.view.animation.LinearInterpolator();
			}
			switch (mDirectionPriority)
			{
				case PRIORITY_COLUMN:
				{
					viewDelay = (long)(row * rowDelay + column * rowsCount * rowDelay);
					totalDelay = rowsCount * rowDelay + columnsCount * rowsCount * rowDelay;
					break;
				}

				case PRIORITY_ROW:
				{
					viewDelay = (long)(column * columnDelay + row * columnsCount * columnDelay);
					totalDelay = columnsCount * columnDelay + rowsCount * columnsCount * columnDelay;
					break;
				}

				case PRIORITY_NONE:
				default:
				{
					viewDelay = (long)(column * columnDelay + row * rowDelay);
					totalDelay = columnsCount * columnDelay + rowsCount * rowDelay;
					break;
				}
			}
			float normalizedDelay = viewDelay / totalDelay;
			normalizedDelay = mInterpolator.getInterpolation(normalizedDelay);
			return (long)(normalizedDelay * totalDelay);
		}

		private int getTransformedColumnIndex(android.view.animation.GridLayoutAnimationController
			.AnimationParameters @params)
		{
			int index;
			switch (getOrder())
			{
				case ORDER_REVERSE:
				{
					index = @params.columnsCount - 1 - @params.column;
					break;
				}

				case ORDER_RANDOM:
				{
					if (mRandomizer == null)
					{
						mRandomizer = new System.Random();
					}
					index = (int)(@params.columnsCount * Sharpen.Util.Random_NextFloat(mRandomizer));
					break;
				}

				case ORDER_NORMAL:
				default:
				{
					index = @params.column;
					break;
				}
			}
			int direction = mDirection & DIRECTION_HORIZONTAL_MASK;
			if (direction == DIRECTION_RIGHT_TO_LEFT)
			{
				index = @params.columnsCount - 1 - index;
			}
			return index;
		}

		private int getTransformedRowIndex(android.view.animation.GridLayoutAnimationController
			.AnimationParameters @params)
		{
			int index;
			switch (getOrder())
			{
				case ORDER_REVERSE:
				{
					index = @params.rowsCount - 1 - @params.row;
					break;
				}

				case ORDER_RANDOM:
				{
					if (mRandomizer == null)
					{
						mRandomizer = new System.Random();
					}
					index = (int)(@params.rowsCount * Sharpen.Util.Random_NextFloat(mRandomizer));
					break;
				}

				case ORDER_NORMAL:
				default:
				{
					index = @params.row;
					break;
				}
			}
			int direction = mDirection & DIRECTION_VERTICAL_MASK;
			if (direction == DIRECTION_BOTTOM_TO_TOP)
			{
				index = @params.rowsCount - 1 - index;
			}
			return index;
		}

		/// <summary>
		/// The set of parameters that has to be attached to each view contained in
		/// the view group animated by the grid layout animation controller.
		/// </summary>
		/// <remarks>
		/// The set of parameters that has to be attached to each view contained in
		/// the view group animated by the grid layout animation controller. These
		/// parameters are used to compute the start time of each individual view's
		/// animation.
		/// </remarks>
		public class AnimationParameters : android.view.animation.LayoutAnimationController
			.AnimationParameters
		{
			/// <summary>The view group's column to which the view belongs.</summary>
			/// <remarks>The view group's column to which the view belongs.</remarks>
			public int column;

			/// <summary>The view group's row to which the view belongs.</summary>
			/// <remarks>The view group's row to which the view belongs.</remarks>
			public int row;

			/// <summary>The number of columns in the view's enclosing grid layout.</summary>
			/// <remarks>The number of columns in the view's enclosing grid layout.</remarks>
			public int columnsCount;

			/// <summary>The number of rows in the view's enclosing grid layout.</summary>
			/// <remarks>The number of rows in the view's enclosing grid layout.</remarks>
			public int rowsCount;
		}
	}
}
