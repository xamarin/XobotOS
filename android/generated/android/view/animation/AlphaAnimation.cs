using Sharpen;

namespace android.view.animation
{
	/// <summary>An animation that controls the alpha level of an object.</summary>
	/// <remarks>
	/// An animation that controls the alpha level of an object.
	/// Useful for fading things in and out. This animation ends up
	/// changing the alpha property of a
	/// <see cref="Transformation">Transformation</see>
	/// </remarks>
	[Sharpen.Sharpened]
	public class AlphaAnimation : android.view.animation.Animation
	{
		private float mFromAlpha;

		private float mToAlpha;

		/// <summary>Constructor used when an AlphaAnimation is loaded from a resource.</summary>
		/// <remarks>Constructor used when an AlphaAnimation is loaded from a resource.</remarks>
		/// <param name="context">Application context to use</param>
		/// <param name="attrs">Attribute set from which to read values</param>
		public AlphaAnimation(android.content.Context context, android.util.AttributeSet 
			attrs) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AlphaAnimation);
			mFromAlpha = a.getFloat(android.@internal.R.styleable.AlphaAnimation_fromAlpha, 1.0f
				);
			mToAlpha = a.getFloat(android.@internal.R.styleable.AlphaAnimation_toAlpha, 1.0f);
			a.recycle();
		}

		/// <summary>Constructor to use when building an AlphaAnimation from code</summary>
		/// <param name="fromAlpha">
		/// Starting alpha value for the animation, where 1.0 means
		/// fully opaque and 0.0 means fully transparent.
		/// </param>
		/// <param name="toAlpha">Ending alpha value for the animation.</param>
		public AlphaAnimation(float fromAlpha, float toAlpha)
		{
			mFromAlpha = fromAlpha;
			mToAlpha = toAlpha;
		}

		/// <summary>
		/// Changes the alpha property of the supplied
		/// <see cref="Transformation">Transformation</see>
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		protected internal override void applyTransformation(float interpolatedTime, android.view.animation.Transformation
			 t)
		{
			float alpha = mFromAlpha;
			t.setAlpha(alpha + ((mToAlpha - alpha) * interpolatedTime));
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override bool willChangeTransformationMatrix()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override bool willChangeBounds()
		{
			return false;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override bool hasAlpha()
		{
			return true;
		}
	}
}
