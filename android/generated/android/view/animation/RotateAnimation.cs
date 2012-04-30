using Sharpen;

namespace android.view.animation
{
	/// <summary>An animation that controls the rotation of an object.</summary>
	/// <remarks>
	/// An animation that controls the rotation of an object. This rotation takes
	/// place int the X-Y plane. You can specify the point to use for the center of
	/// the rotation, where (0,0) is the top left point. If not specified, (0,0) is
	/// the default rotation point.
	/// </remarks>
	[Sharpen.Sharpened]
	public class RotateAnimation : android.view.animation.Animation
	{
		private float mFromDegrees;

		private float mToDegrees;

		private int mPivotXType = ABSOLUTE;

		private int mPivotYType = ABSOLUTE;

		private float mPivotXValue = 0.0f;

		private float mPivotYValue = 0.0f;

		private float mPivotX;

		private float mPivotY;

		/// <summary>Constructor used when a RotateAnimation is loaded from a resource.</summary>
		/// <remarks>Constructor used when a RotateAnimation is loaded from a resource.</remarks>
		/// <param name="context">Application context to use</param>
		/// <param name="attrs">Attribute set from which to read values</param>
		public RotateAnimation(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.RotateAnimation);
			mFromDegrees = a.getFloat(android.@internal.R.styleable.RotateAnimation_fromDegrees
				, 0.0f);
			mToDegrees = a.getFloat(android.@internal.R.styleable.RotateAnimation_toDegrees, 
				0.0f);
			android.view.animation.Animation.Description d = android.view.animation.Animation
				.Description.parseValue(a.peekValue(android.@internal.R.styleable.RotateAnimation_pivotX
				));
			mPivotXType = d.type;
			mPivotXValue = d.value;
			d = android.view.animation.Animation.Description.parseValue(a.peekValue(android.@internal.R
				.styleable.RotateAnimation_pivotY));
			mPivotYType = d.type;
			mPivotYValue = d.value;
			a.recycle();
		}

		/// <summary>Constructor to use when building a RotateAnimation from code.</summary>
		/// <remarks>
		/// Constructor to use when building a RotateAnimation from code.
		/// Default pivotX/pivotY point is (0,0).
		/// </remarks>
		/// <param name="fromDegrees">
		/// Rotation offset to apply at the start of the
		/// animation.
		/// </param>
		/// <param name="toDegrees">Rotation offset to apply at the end of the animation.</param>
		public RotateAnimation(float fromDegrees, float toDegrees)
		{
			mFromDegrees = fromDegrees;
			mToDegrees = toDegrees;
			mPivotX = 0.0f;
			mPivotY = 0.0f;
		}

		/// <summary>Constructor to use when building a RotateAnimation from code</summary>
		/// <param name="fromDegrees">
		/// Rotation offset to apply at the start of the
		/// animation.
		/// </param>
		/// <param name="toDegrees">Rotation offset to apply at the end of the animation.</param>
		/// <param name="pivotX">
		/// The X coordinate of the point about which the object is
		/// being rotated, specified as an absolute number where 0 is the left
		/// edge.
		/// </param>
		/// <param name="pivotY">
		/// The Y coordinate of the point about which the object is
		/// being rotated, specified as an absolute number where 0 is the top
		/// edge.
		/// </param>
		public RotateAnimation(float fromDegrees, float toDegrees, float pivotX, float pivotY
			)
		{
			mFromDegrees = fromDegrees;
			mToDegrees = toDegrees;
			mPivotXType = ABSOLUTE;
			mPivotYType = ABSOLUTE;
			mPivotXValue = pivotX;
			mPivotYValue = pivotY;
		}

		/// <summary>Constructor to use when building a RotateAnimation from code</summary>
		/// <param name="fromDegrees">
		/// Rotation offset to apply at the start of the
		/// animation.
		/// </param>
		/// <param name="toDegrees">Rotation offset to apply at the end of the animation.</param>
		/// <param name="pivotXType">
		/// Specifies how pivotXValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="pivotXValue">
		/// The X coordinate of the point about which the object
		/// is being rotated, specified as an absolute number where 0 is the
		/// left edge. This value can either be an absolute number if
		/// pivotXType is ABSOLUTE, or a percentage (where 1.0 is 100%)
		/// otherwise.
		/// </param>
		/// <param name="pivotYType">
		/// Specifies how pivotYValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="pivotYValue">
		/// The Y coordinate of the point about which the object
		/// is being rotated, specified as an absolute number where 0 is the
		/// top edge. This value can either be an absolute number if
		/// pivotYType is ABSOLUTE, or a percentage (where 1.0 is 100%)
		/// otherwise.
		/// </param>
		public RotateAnimation(float fromDegrees, float toDegrees, int pivotXType, float 
			pivotXValue, int pivotYType, float pivotYValue)
		{
			mFromDegrees = fromDegrees;
			mToDegrees = toDegrees;
			mPivotXValue = pivotXValue;
			mPivotXType = pivotXType;
			mPivotYValue = pivotYValue;
			mPivotYType = pivotYType;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		protected internal override void applyTransformation(float interpolatedTime, android.view.animation.Transformation
			 t)
		{
			float degrees = mFromDegrees + ((mToDegrees - mFromDegrees) * interpolatedTime);
			float scale = getScaleFactor();
			if (mPivotX == 0.0f && mPivotY == 0.0f)
			{
				t.getMatrix().setRotate(degrees);
			}
			else
			{
				t.getMatrix().setRotate(degrees, mPivotX * scale, mPivotY * scale);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void initialize(int width, int height, int parentWidth, int parentHeight
			)
		{
			base.initialize(width, height, parentWidth, parentHeight);
			mPivotX = resolveSize(mPivotXType, mPivotXValue, width, parentWidth);
			mPivotY = resolveSize(mPivotYType, mPivotYValue, height, parentHeight);
		}
	}
}
