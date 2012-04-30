using Sharpen;

namespace android.view.animation
{
	/// <summary>An animation that controls the position of an object.</summary>
	/// <remarks>
	/// An animation that controls the position of an object. See the
	/// <see cref="android.view.animation">full package</see>
	/// description for details and
	/// sample code.
	/// </remarks>
	[Sharpen.Sharpened]
	public class TranslateAnimation : android.view.animation.Animation
	{
		private int mFromXType = ABSOLUTE;

		private int mToXType = ABSOLUTE;

		private int mFromYType = ABSOLUTE;

		private int mToYType = ABSOLUTE;

		private float mFromXValue = 0.0f;

		private float mToXValue = 0.0f;

		private float mFromYValue = 0.0f;

		private float mToYValue = 0.0f;

		private float mFromXDelta;

		private float mToXDelta;

		private float mFromYDelta;

		private float mToYDelta;

		/// <summary>Constructor used when a TranslateAnimation is loaded from a resource.</summary>
		/// <remarks>Constructor used when a TranslateAnimation is loaded from a resource.</remarks>
		/// <param name="context">Application context to use</param>
		/// <param name="attrs">Attribute set from which to read values</param>
		public TranslateAnimation(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.TranslateAnimation);
			android.view.animation.Animation.Description d = android.view.animation.Animation
				.Description.parseValue(a.peekValue(android.@internal.R.styleable.TranslateAnimation_fromXDelta
				));
			mFromXType = d.type;
			mFromXValue = d.value;
			d = android.view.animation.Animation.Description.parseValue(a.peekValue(android.@internal.R
				.styleable.TranslateAnimation_toXDelta));
			mToXType = d.type;
			mToXValue = d.value;
			d = android.view.animation.Animation.Description.parseValue(a.peekValue(android.@internal.R
				.styleable.TranslateAnimation_fromYDelta));
			mFromYType = d.type;
			mFromYValue = d.value;
			d = android.view.animation.Animation.Description.parseValue(a.peekValue(android.@internal.R
				.styleable.TranslateAnimation_toYDelta));
			mToYType = d.type;
			mToYValue = d.value;
			a.recycle();
		}

		/// <summary>Constructor to use when building a TranslateAnimation from code</summary>
		/// <param name="fromXDelta">
		/// Change in X coordinate to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toXDelta">
		/// Change in X coordinate to apply at the end of the
		/// animation
		/// </param>
		/// <param name="fromYDelta">
		/// Change in Y coordinate to apply at the start of the
		/// animation
		/// </param>
		/// <param name="toYDelta">
		/// Change in Y coordinate to apply at the end of the
		/// animation
		/// </param>
		public TranslateAnimation(float fromXDelta, float toXDelta, float fromYDelta, float
			 toYDelta)
		{
			mFromXValue = fromXDelta;
			mToXValue = toXDelta;
			mFromYValue = fromYDelta;
			mToYValue = toYDelta;
			mFromXType = ABSOLUTE;
			mToXType = ABSOLUTE;
			mFromYType = ABSOLUTE;
			mToYType = ABSOLUTE;
		}

		/// <summary>Constructor to use when building a TranslateAnimation from code</summary>
		/// <param name="fromXType">
		/// Specifies how fromXValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="fromXValue">
		/// Change in X coordinate to apply at the start of the
		/// animation. This value can either be an absolute number if fromXType
		/// is ABSOLUTE, or a percentage (where 1.0 is 100%) otherwise.
		/// </param>
		/// <param name="toXType">
		/// Specifies how toXValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="toXValue">
		/// Change in X coordinate to apply at the end of the
		/// animation. This value can either be an absolute number if toXType
		/// is ABSOLUTE, or a percentage (where 1.0 is 100%) otherwise.
		/// </param>
		/// <param name="fromYType">
		/// Specifies how fromYValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="fromYValue">
		/// Change in Y coordinate to apply at the start of the
		/// animation. This value can either be an absolute number if fromYType
		/// is ABSOLUTE, or a percentage (where 1.0 is 100%) otherwise.
		/// </param>
		/// <param name="toYType">
		/// Specifies how toYValue should be interpreted. One of
		/// Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="toYValue">
		/// Change in Y coordinate to apply at the end of the
		/// animation. This value can either be an absolute number if toYType
		/// is ABSOLUTE, or a percentage (where 1.0 is 100%) otherwise.
		/// </param>
		public TranslateAnimation(int fromXType, float fromXValue, int toXType, float toXValue
			, int fromYType, float fromYValue, int toYType, float toYValue)
		{
			mFromXValue = fromXValue;
			mToXValue = toXValue;
			mFromYValue = fromYValue;
			mToYValue = toYValue;
			mFromXType = fromXType;
			mToXType = toXType;
			mFromYType = fromYType;
			mToYType = toYType;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		protected internal override void applyTransformation(float interpolatedTime, android.view.animation.Transformation
			 t)
		{
			float dx = mFromXDelta;
			float dy = mFromYDelta;
			if (mFromXDelta != mToXDelta)
			{
				dx = mFromXDelta + ((mToXDelta - mFromXDelta) * interpolatedTime);
			}
			if (mFromYDelta != mToYDelta)
			{
				dy = mFromYDelta + ((mToYDelta - mFromYDelta) * interpolatedTime);
			}
			t.getMatrix().setTranslate(dx, dy);
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void initialize(int width, int height, int parentWidth, int parentHeight
			)
		{
			base.initialize(width, height, parentWidth, parentHeight);
			mFromXDelta = resolveSize(mFromXType, mFromXValue, width, parentWidth);
			mToXDelta = resolveSize(mToXType, mToXValue, width, parentWidth);
			mFromYDelta = resolveSize(mFromYType, mFromYValue, height, parentHeight);
			mToYDelta = resolveSize(mToYType, mToYValue, height, parentHeight);
		}
	}
}
