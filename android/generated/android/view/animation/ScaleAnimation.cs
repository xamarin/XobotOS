using Sharpen;

namespace android.view.animation
{
	/// <summary>An animation that controls the scale of an object.</summary>
	/// <remarks>
	/// An animation that controls the scale of an object. You can specify the point
	/// to use for the center of scaling.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ScaleAnimation : android.view.animation.Animation
	{
		private readonly android.content.res.Resources mResources;

		private float mFromX;

		private float mToX;

		private float mFromY;

		private float mToY;

		private int mFromXType = android.util.TypedValue.TYPE_NULL;

		private int mToXType = android.util.TypedValue.TYPE_NULL;

		private int mFromYType = android.util.TypedValue.TYPE_NULL;

		private int mToYType = android.util.TypedValue.TYPE_NULL;

		private int mFromXData = 0;

		private int mToXData = 0;

		private int mFromYData = 0;

		private int mToYData = 0;

		private int mPivotXType = ABSOLUTE;

		private int mPivotYType = ABSOLUTE;

		private float mPivotXValue = 0.0f;

		private float mPivotYValue = 0.0f;

		private float mPivotX;

		private float mPivotY;

		/// <summary>Constructor used when a ScaleAnimation is loaded from a resource.</summary>
		/// <remarks>Constructor used when a ScaleAnimation is loaded from a resource.</remarks>
		/// <param name="context">Application context to use</param>
		/// <param name="attrs">Attribute set from which to read values</param>
		public ScaleAnimation(android.content.Context context, android.util.AttributeSet 
			attrs) : base(context, attrs)
		{
			mResources = context.getResources();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ScaleAnimation);
			android.util.TypedValue tv = a.peekValue(android.@internal.R.styleable.ScaleAnimation_fromXScale
				);
			mFromX = 0.0f;
			if (tv != null)
			{
				if (tv.type == android.util.TypedValue.TYPE_FLOAT)
				{
					// This is a scaling factor.
					mFromX = tv.getFloat();
				}
				else
				{
					mFromXType = tv.type;
					mFromXData = tv.data;
				}
			}
			tv = a.peekValue(android.@internal.R.styleable.ScaleAnimation_toXScale);
			mToX = 0.0f;
			if (tv != null)
			{
				if (tv.type == android.util.TypedValue.TYPE_FLOAT)
				{
					// This is a scaling factor.
					mToX = tv.getFloat();
				}
				else
				{
					mToXType = tv.type;
					mToXData = tv.data;
				}
			}
			tv = a.peekValue(android.@internal.R.styleable.ScaleAnimation_fromYScale);
			mFromY = 0.0f;
			if (tv != null)
			{
				if (tv.type == android.util.TypedValue.TYPE_FLOAT)
				{
					// This is a scaling factor.
					mFromY = tv.getFloat();
				}
				else
				{
					mFromYType = tv.type;
					mFromYData = tv.data;
				}
			}
			tv = a.peekValue(android.@internal.R.styleable.ScaleAnimation_toYScale);
			mToY = 0.0f;
			if (tv != null)
			{
				if (tv.type == android.util.TypedValue.TYPE_FLOAT)
				{
					// This is a scaling factor.
					mToY = tv.getFloat();
				}
				else
				{
					mToYType = tv.type;
					mToYData = tv.data;
				}
			}
			android.view.animation.Animation.Description d = android.view.animation.Animation
				.Description.parseValue(a.peekValue(android.@internal.R.styleable.ScaleAnimation_pivotX
				));
			mPivotXType = d.type;
			mPivotXValue = d.value;
			d = android.view.animation.Animation.Description.parseValue(a.peekValue(android.@internal.R
				.styleable.ScaleAnimation_pivotY));
			mPivotYType = d.type;
			mPivotYValue = d.value;
			a.recycle();
		}

		/// <summary>Constructor to use when building a ScaleAnimation from code</summary>
		/// <param name="fromX">
		/// Horizontal scaling factor to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toX">Horizontal scaling factor to apply at the end of the animation</param>
		/// <param name="fromY">
		/// Vertical scaling factor to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toY">Vertical scaling factor to apply at the end of the animation</param>
		public ScaleAnimation(float fromX, float toX, float fromY, float toY)
		{
			mResources = null;
			mFromX = fromX;
			mToX = toX;
			mFromY = fromY;
			mToY = toY;
			mPivotX = 0;
			mPivotY = 0;
		}

		/// <summary>Constructor to use when building a ScaleAnimation from code</summary>
		/// <param name="fromX">
		/// Horizontal scaling factor to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toX">Horizontal scaling factor to apply at the end of the animation</param>
		/// <param name="fromY">
		/// Vertical scaling factor to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toY">Vertical scaling factor to apply at the end of the animation</param>
		/// <param name="pivotX">
		/// The X coordinate of the point about which the object is
		/// being scaled, specified as an absolute number where 0 is the left
		/// edge. (This point remains fixed while the object changes size.)
		/// </param>
		/// <param name="pivotY">
		/// The Y coordinate of the point about which the object is
		/// being scaled, specified as an absolute number where 0 is the top
		/// edge. (This point remains fixed while the object changes size.)
		/// </param>
		public ScaleAnimation(float fromX, float toX, float fromY, float toY, float pivotX
			, float pivotY)
		{
			mResources = null;
			mFromX = fromX;
			mToX = toX;
			mFromY = fromY;
			mToY = toY;
			mPivotXType = ABSOLUTE;
			mPivotYType = ABSOLUTE;
			mPivotXValue = pivotX;
			mPivotYValue = pivotY;
		}

		/// <summary>Constructor to use when building a ScaleAnimation from code</summary>
		/// <param name="fromX">
		/// Horizontal scaling factor to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toX">Horizontal scaling factor to apply at the end of the animation</param>
		/// <param name="fromY">
		/// Vertical scaling factor to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toY">Vertical scaling factor to apply at the end of the animation</param>
		/// <param name="pivotXType">
		/// Specifies how pivotXValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="pivotXValue">
		/// The X coordinate of the point about which the object
		/// is being scaled, specified as an absolute number where 0 is the
		/// left edge. (This point remains fixed while the object changes
		/// size.) This value can either be an absolute number if pivotXType
		/// is ABSOLUTE, or a percentage (where 1.0 is 100%) otherwise.
		/// </param>
		/// <param name="pivotYType">
		/// Specifies how pivotYValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="pivotYValue">
		/// The Y coordinate of the point about which the object
		/// is being scaled, specified as an absolute number where 0 is the
		/// top edge. (This point remains fixed while the object changes
		/// size.) This value can either be an absolute number if pivotYType
		/// is ABSOLUTE, or a percentage (where 1.0 is 100%) otherwise.
		/// </param>
		public ScaleAnimation(float fromX, float toX, float fromY, float toY, int pivotXType
			, float pivotXValue, int pivotYType, float pivotYValue)
		{
			mResources = null;
			mFromX = fromX;
			mToX = toX;
			mFromY = fromY;
			mToY = toY;
			mPivotXValue = pivotXValue;
			mPivotXType = pivotXType;
			mPivotYValue = pivotYValue;
			mPivotYType = pivotYType;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		protected internal override void applyTransformation(float interpolatedTime, android.view.animation.Transformation
			 t)
		{
			float sx = 1.0f;
			float sy = 1.0f;
			float scale = getScaleFactor();
			if (mFromX != 1.0f || mToX != 1.0f)
			{
				sx = mFromX + ((mToX - mFromX) * interpolatedTime);
			}
			if (mFromY != 1.0f || mToY != 1.0f)
			{
				sy = mFromY + ((mToY - mFromY) * interpolatedTime);
			}
			if (mPivotX == 0 && mPivotY == 0)
			{
				t.getMatrix().setScale(sx, sy);
			}
			else
			{
				t.getMatrix().setScale(sx, sy, scale * mPivotX, scale * mPivotY);
			}
		}

		internal virtual float resolveScale(float scale, int type, int data, int size, int
			 psize)
		{
			float targetSize;
			if (type == android.util.TypedValue.TYPE_FRACTION)
			{
				targetSize = android.util.TypedValue.complexToFraction(data, size, psize);
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_DIMENSION)
				{
					targetSize = android.util.TypedValue.complexToDimension(data, mResources.getDisplayMetrics
						());
				}
				else
				{
					return scale;
				}
			}
			if (size == 0)
			{
				return 1;
			}
			return targetSize / (float)size;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void initialize(int width, int height, int parentWidth, int parentHeight
			)
		{
			base.initialize(width, height, parentWidth, parentHeight);
			mFromX = resolveScale(mFromX, mFromXType, mFromXData, width, parentWidth);
			mToX = resolveScale(mToX, mToXType, mToXData, width, parentWidth);
			mFromY = resolveScale(mFromY, mFromYType, mFromYData, height, parentHeight);
			mToY = resolveScale(mToY, mToYType, mToYData, height, parentHeight);
			mPivotX = resolveSize(mPivotXType, mPivotXValue, width, parentWidth);
			mPivotY = resolveSize(mPivotYType, mPivotYValue, height, parentHeight);
		}
	}
}
