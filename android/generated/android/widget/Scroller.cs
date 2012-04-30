using Sharpen;

namespace android.widget
{
	/// <summary>This class encapsulates scrolling.</summary>
	/// <remarks>
	/// This class encapsulates scrolling.  The duration of the scroll
	/// can be passed in the constructor and specifies the maximum time that
	/// the scrolling animation should take.  Past this time, the scrolling is
	/// automatically moved to its final stage and computeScrollOffset()
	/// will always return false to indicate that scrolling is over.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Scroller
	{
		private int mMode;

		private int mStartX;

		private int mStartY;

		private int mFinalX;

		private int mFinalY;

		private int mMinX;

		private int mMaxX;

		private int mMinY;

		private int mMaxY;

		private int mCurrX;

		private int mCurrY;

		private long mStartTime;

		private int mDuration;

		private float mDurationReciprocal;

		private float mDeltaX;

		private float mDeltaY;

		private bool mFinished;

		private android.view.animation.Interpolator mInterpolator;

		private bool mFlywheel;

		private float mVelocity;

		internal const int DEFAULT_DURATION = 250;

		internal const int SCROLL_MODE = 0;

		internal const int FLING_MODE = 1;

		private static float DECELERATION_RATE = (float)(System.Math.Log(0.75) / System.Math.Log
			(0.9));

		private static float ALPHA = 800;

		private static float START_TENSION = 0.4f;

		private static float END_TENSION = 1.0f - START_TENSION;

		internal const int NB_SAMPLES = 100;

		private static readonly float[] SPLINE = new float[NB_SAMPLES + 1];

		private float mDeceleration;

		private readonly float mPpi;

		static Scroller()
		{
			// pixels / seconds
			// Tension at start: (0.4 * total T, 1.0 * Distance)
			float x_min = 0.0f;
			{
				for (int i = 0; i <= NB_SAMPLES; i++)
				{
					float t = (float)i / NB_SAMPLES;
					float x_max = 1.0f;
					float x;
					float tx;
					float coef;
					while (true)
					{
						x = x_min + (x_max - x_min) / 2.0f;
						coef = 3.0f * x * (1.0f - x);
						tx = coef * ((1.0f - x) * START_TENSION + x * END_TENSION) + x * x * x;
						if (System.Math.Abs(tx - t) < 1E-5)
						{
							break;
						}
						if (tx > t)
						{
							x_max = x;
						}
						else
						{
							x_min = x;
						}
					}
					float d = coef + x * x * x;
					SPLINE[i] = d;
				}
			}
			SPLINE[NB_SAMPLES] = 1.0f;
			// This controls the viscous fluid effect (how much of it)
			sViscousFluidScale = 8.0f;
			// must be set to 1.0 (used in viscousFluid())
			sViscousFluidNormalize = 1.0f;
			sViscousFluidNormalize = 1.0f / viscousFluid(1.0f);
		}

		private static float sViscousFluidScale;

		private static float sViscousFluidNormalize;

		/// <summary>Create a Scroller with the default duration and interpolator.</summary>
		/// <remarks>Create a Scroller with the default duration and interpolator.</remarks>
		public Scroller(android.content.Context context) : this(context, null)
		{
		}

		/// <summary>Create a Scroller with the specified interpolator.</summary>
		/// <remarks>
		/// Create a Scroller with the specified interpolator. If the interpolator is
		/// null, the default (viscous) interpolator will be used. "Flywheel" behavior will
		/// be in effect for apps targeting Honeycomb or newer.
		/// </remarks>
		public Scroller(android.content.Context context, android.view.animation.Interpolator
			 interpolator) : this(context, interpolator, context.getApplicationInfo().targetSdkVersion
			 >= android.os.Build.VERSION_CODES.HONEYCOMB)
		{
		}

		/// <summary>Create a Scroller with the specified interpolator.</summary>
		/// <remarks>
		/// Create a Scroller with the specified interpolator. If the interpolator is
		/// null, the default (viscous) interpolator will be used. Specify whether or
		/// not to support progressive "flywheel" behavior in flinging.
		/// </remarks>
		public Scroller(android.content.Context context, android.view.animation.Interpolator
			 interpolator, bool flywheel)
		{
			mFinished = true;
			mInterpolator = interpolator;
			mPpi = context.getResources().getDisplayMetrics().density * 160.0f;
			mDeceleration = computeDeceleration(android.view.ViewConfiguration.getScrollFriction
				());
			mFlywheel = flywheel;
		}

		/// <summary>The amount of friction applied to flings.</summary>
		/// <remarks>
		/// The amount of friction applied to flings. The default value
		/// is
		/// <see cref="android.view.ViewConfiguration.getScrollFriction()">android.view.ViewConfiguration.getScrollFriction()
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="friction">
		/// A scalar dimension-less value representing the coefficient of
		/// friction.
		/// </param>
		public void setFriction(float friction)
		{
			mDeceleration = computeDeceleration(friction);
		}

		private float computeDeceleration(float friction)
		{
			return android.hardware.SensorManager.GRAVITY_EARTH * 39.37f * mPpi * friction;
		}

		// g (m/s^2)
		// inch/meter
		// pixels per inch
		/// <summary>Returns whether the scroller has finished scrolling.</summary>
		/// <remarks>Returns whether the scroller has finished scrolling.</remarks>
		/// <returns>True if the scroller has finished scrolling, false otherwise.</returns>
		public bool isFinished()
		{
			return mFinished;
		}

		/// <summary>Force the finished field to a particular value.</summary>
		/// <remarks>Force the finished field to a particular value.</remarks>
		/// <param name="finished">The new finished value.</param>
		public void forceFinished(bool finished)
		{
			mFinished = finished;
		}

		/// <summary>Returns how long the scroll event will take, in milliseconds.</summary>
		/// <remarks>Returns how long the scroll event will take, in milliseconds.</remarks>
		/// <returns>The duration of the scroll in milliseconds.</returns>
		public int getDuration()
		{
			return mDuration;
		}

		/// <summary>Returns the current X offset in the scroll.</summary>
		/// <remarks>Returns the current X offset in the scroll.</remarks>
		/// <returns>The new X offset as an absolute distance from the origin.</returns>
		public int getCurrX()
		{
			return mCurrX;
		}

		/// <summary>Returns the current Y offset in the scroll.</summary>
		/// <remarks>Returns the current Y offset in the scroll.</remarks>
		/// <returns>The new Y offset as an absolute distance from the origin.</returns>
		public int getCurrY()
		{
			return mCurrY;
		}

		/// <summary>Returns the current velocity.</summary>
		/// <remarks>Returns the current velocity.</remarks>
		/// <returns>
		/// The original velocity less the deceleration. Result may be
		/// negative.
		/// </returns>
		public virtual float getCurrVelocity()
		{
			return mVelocity - mDeceleration * timePassed() / 2000.0f;
		}

		/// <summary>Returns the start X offset in the scroll.</summary>
		/// <remarks>Returns the start X offset in the scroll.</remarks>
		/// <returns>The start X offset as an absolute distance from the origin.</returns>
		public int getStartX()
		{
			return mStartX;
		}

		/// <summary>Returns the start Y offset in the scroll.</summary>
		/// <remarks>Returns the start Y offset in the scroll.</remarks>
		/// <returns>The start Y offset as an absolute distance from the origin.</returns>
		public int getStartY()
		{
			return mStartY;
		}

		/// <summary>Returns where the scroll will end.</summary>
		/// <remarks>Returns where the scroll will end. Valid only for "fling" scrolls.</remarks>
		/// <returns>The final X offset as an absolute distance from the origin.</returns>
		public int getFinalX()
		{
			return mFinalX;
		}

		/// <summary>Returns where the scroll will end.</summary>
		/// <remarks>Returns where the scroll will end. Valid only for "fling" scrolls.</remarks>
		/// <returns>The final Y offset as an absolute distance from the origin.</returns>
		public int getFinalY()
		{
			return mFinalY;
		}

		/// <summary>Call this when you want to know the new location.</summary>
		/// <remarks>
		/// Call this when you want to know the new location.  If it returns true,
		/// the animation is not yet finished.  loc will be altered to provide the
		/// new location.
		/// </remarks>
		public virtual bool computeScrollOffset()
		{
			if (mFinished)
			{
				return false;
			}
			int timePassed_1 = (int)(android.view.animation.AnimationUtils.currentAnimationTimeMillis
				() - mStartTime);
			if (timePassed_1 < mDuration)
			{
				switch (mMode)
				{
					case SCROLL_MODE:
					{
						float x = timePassed_1 * mDurationReciprocal;
						if (mInterpolator == null)
						{
							x = viscousFluid(x);
						}
						else
						{
							x = mInterpolator.getInterpolation(x);
						}
						mCurrX = mStartX + Sharpen.Util.Round(x * mDeltaX);
						mCurrY = mStartY + Sharpen.Util.Round(x * mDeltaY);
						break;
					}

					case FLING_MODE:
					{
						float t = (float)timePassed_1 / mDuration;
						int index = (int)(NB_SAMPLES * t);
						float t_inf = (float)index / NB_SAMPLES;
						float t_sup = (float)(index + 1) / NB_SAMPLES;
						float d_inf = SPLINE[index];
						float d_sup = SPLINE[index + 1];
						float distanceCoef = d_inf + (t - t_inf) / (t_sup - t_inf) * (d_sup - d_inf);
						mCurrX = mStartX + Sharpen.Util.Round(distanceCoef * (mFinalX - mStartX));
						// Pin to mMinX <= mCurrX <= mMaxX
						mCurrX = System.Math.Min(mCurrX, mMaxX);
						mCurrX = System.Math.Max(mCurrX, mMinX);
						mCurrY = mStartY + Sharpen.Util.Round(distanceCoef * (mFinalY - mStartY));
						// Pin to mMinY <= mCurrY <= mMaxY
						mCurrY = System.Math.Min(mCurrY, mMaxY);
						mCurrY = System.Math.Max(mCurrY, mMinY);
						if (mCurrX == mFinalX && mCurrY == mFinalY)
						{
							mFinished = true;
						}
						break;
					}
				}
			}
			else
			{
				mCurrX = mFinalX;
				mCurrY = mFinalY;
				mFinished = true;
			}
			return true;
		}

		/// <summary>Start scrolling by providing a starting point and the distance to travel.
		/// 	</summary>
		/// <remarks>
		/// Start scrolling by providing a starting point and the distance to travel.
		/// The scroll will use the default value of 250 milliseconds for the
		/// duration.
		/// </remarks>
		/// <param name="startX">
		/// Starting horizontal scroll offset in pixels. Positive
		/// numbers will scroll the content to the left.
		/// </param>
		/// <param name="startY">
		/// Starting vertical scroll offset in pixels. Positive numbers
		/// will scroll the content up.
		/// </param>
		/// <param name="dx">
		/// Horizontal distance to travel. Positive numbers will scroll the
		/// content to the left.
		/// </param>
		/// <param name="dy">
		/// Vertical distance to travel. Positive numbers will scroll the
		/// content up.
		/// </param>
		public virtual void startScroll(int startX, int startY, int dx, int dy)
		{
			startScroll(startX, startY, dx, dy, DEFAULT_DURATION);
		}

		/// <summary>Start scrolling by providing a starting point and the distance to travel.
		/// 	</summary>
		/// <remarks>Start scrolling by providing a starting point and the distance to travel.
		/// 	</remarks>
		/// <param name="startX">
		/// Starting horizontal scroll offset in pixels. Positive
		/// numbers will scroll the content to the left.
		/// </param>
		/// <param name="startY">
		/// Starting vertical scroll offset in pixels. Positive numbers
		/// will scroll the content up.
		/// </param>
		/// <param name="dx">
		/// Horizontal distance to travel. Positive numbers will scroll the
		/// content to the left.
		/// </param>
		/// <param name="dy">
		/// Vertical distance to travel. Positive numbers will scroll the
		/// content up.
		/// </param>
		/// <param name="duration">Duration of the scroll in milliseconds.</param>
		public virtual void startScroll(int startX, int startY, int dx, int dy, int duration
			)
		{
			mMode = SCROLL_MODE;
			mFinished = false;
			mDuration = duration;
			mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
			mStartX = startX;
			mStartY = startY;
			mFinalX = startX + dx;
			mFinalY = startY + dy;
			mDeltaX = dx;
			mDeltaY = dy;
			mDurationReciprocal = 1.0f / (float)mDuration;
		}

		/// <summary>Start scrolling based on a fling gesture.</summary>
		/// <remarks>
		/// Start scrolling based on a fling gesture. The distance travelled will
		/// depend on the initial velocity of the fling.
		/// </remarks>
		/// <param name="startX">Starting point of the scroll (X)</param>
		/// <param name="startY">Starting point of the scroll (Y)</param>
		/// <param name="velocityX">
		/// Initial velocity of the fling (X) measured in pixels per
		/// second.
		/// </param>
		/// <param name="velocityY">
		/// Initial velocity of the fling (Y) measured in pixels per
		/// second
		/// </param>
		/// <param name="minX">
		/// Minimum X value. The scroller will not scroll past this
		/// point.
		/// </param>
		/// <param name="maxX">
		/// Maximum X value. The scroller will not scroll past this
		/// point.
		/// </param>
		/// <param name="minY">
		/// Minimum Y value. The scroller will not scroll past this
		/// point.
		/// </param>
		/// <param name="maxY">
		/// Maximum Y value. The scroller will not scroll past this
		/// point.
		/// </param>
		public virtual void fling(int startX, int startY, int velocityX, int velocityY, int
			 minX, int maxX, int minY, int maxY)
		{
			// Continue a scroll or fling in progress
			if (mFlywheel && !mFinished)
			{
				float oldVel = getCurrVelocity();
				float dx = (float)(mFinalX - mStartX);
				float dy = (float)(mFinalY - mStartY);
				float hyp = android.util.FloatMath.sqrt(dx * dx + dy * dy);
				float ndx = dx / hyp;
				float ndy = dy / hyp;
				float oldVelocityX = ndx * oldVel;
				float oldVelocityY = ndy * oldVel;
				if (System.Math.Sign(velocityX) == System.Math.Sign(oldVelocityX) && System.Math.Sign
					(velocityY) == System.Math.Sign(oldVelocityY))
				{
					velocityX += (int)(oldVelocityX);
					velocityY += (int)(oldVelocityY);
				}
			}
			mMode = FLING_MODE;
			mFinished = false;
			float velocity = android.util.FloatMath.sqrt(velocityX * velocityX + velocityY * 
				velocityY);
			mVelocity = velocity;
			double l = System.Math.Log(START_TENSION * velocity / ALPHA);
			mDuration = (int)(1000.0 * System.Math.Exp(l / (DECELERATION_RATE - 1.0)));
			mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
			mStartX = startX;
			mStartY = startY;
			float coeffX = velocity == 0 ? 1.0f : velocityX / velocity;
			float coeffY = velocity == 0 ? 1.0f : velocityY / velocity;
			int totalDistance = (int)(ALPHA * System.Math.Exp(DECELERATION_RATE / (DECELERATION_RATE
				 - 1.0) * l));
			mMinX = minX;
			mMaxX = maxX;
			mMinY = minY;
			mMaxY = maxY;
			mFinalX = startX + Sharpen.Util.Round(totalDistance * coeffX);
			// Pin to mMinX <= mFinalX <= mMaxX
			mFinalX = System.Math.Min(mFinalX, mMaxX);
			mFinalX = System.Math.Max(mFinalX, mMinX);
			mFinalY = startY + Sharpen.Util.Round(totalDistance * coeffY);
			// Pin to mMinY <= mFinalY <= mMaxY
			mFinalY = System.Math.Min(mFinalY, mMaxY);
			mFinalY = System.Math.Max(mFinalY, mMinY);
		}

		internal static float viscousFluid(float x)
		{
			x *= sViscousFluidScale;
			if (x < 1.0f)
			{
				x -= (1.0f - (float)System.Math.Exp(-x));
			}
			else
			{
				float start = 0.36787944117f;
				// 1/e == exp(-1)
				x = 1.0f - (float)System.Math.Exp(1.0f - x);
				x = start + x * (1.0f - start);
			}
			x *= sViscousFluidNormalize;
			return x;
		}

		/// <summary>Stops the animation.</summary>
		/// <remarks>
		/// Stops the animation. Contrary to
		/// <see cref="forceFinished(bool)">forceFinished(bool)</see>
		/// ,
		/// aborting the animating cause the scroller to move to the final x and y
		/// position
		/// </remarks>
		/// <seealso cref="forceFinished(bool)">forceFinished(bool)</seealso>
		public virtual void abortAnimation()
		{
			mCurrX = mFinalX;
			mCurrY = mFinalY;
			mFinished = true;
		}

		/// <summary>Extend the scroll animation.</summary>
		/// <remarks>
		/// Extend the scroll animation. This allows a running animation to scroll
		/// further and longer, when used with
		/// <see cref="setFinalX(int)">setFinalX(int)</see>
		/// or
		/// <see cref="setFinalY(int)">setFinalY(int)</see>
		/// .
		/// </remarks>
		/// <param name="extend">Additional time to scroll in milliseconds.</param>
		/// <seealso cref="setFinalX(int)">setFinalX(int)</seealso>
		/// <seealso cref="setFinalY(int)">setFinalY(int)</seealso>
		public virtual void extendDuration(int extend)
		{
			int passed = timePassed();
			mDuration = passed + extend;
			mDurationReciprocal = 1.0f / mDuration;
			mFinished = false;
		}

		/// <summary>Returns the time elapsed since the beginning of the scrolling.</summary>
		/// <remarks>Returns the time elapsed since the beginning of the scrolling.</remarks>
		/// <returns>The elapsed time in milliseconds.</returns>
		public virtual int timePassed()
		{
			return (int)(android.view.animation.AnimationUtils.currentAnimationTimeMillis() -
				 mStartTime);
		}

		/// <summary>Sets the final position (X) for this scroller.</summary>
		/// <remarks>Sets the final position (X) for this scroller.</remarks>
		/// <param name="newX">The new X offset as an absolute distance from the origin.</param>
		/// <seealso cref="extendDuration(int)">extendDuration(int)</seealso>
		/// <seealso cref="setFinalY(int)">setFinalY(int)</seealso>
		public virtual void setFinalX(int newX)
		{
			mFinalX = newX;
			mDeltaX = mFinalX - mStartX;
			mFinished = false;
		}

		/// <summary>Sets the final position (Y) for this scroller.</summary>
		/// <remarks>Sets the final position (Y) for this scroller.</remarks>
		/// <param name="newY">The new Y offset as an absolute distance from the origin.</param>
		/// <seealso cref="extendDuration(int)">extendDuration(int)</seealso>
		/// <seealso cref="setFinalX(int)">setFinalX(int)</seealso>
		public virtual void setFinalY(int newY)
		{
			mFinalY = newY;
			mDeltaY = mFinalY - mStartY;
			mFinished = false;
		}

		/// <hide></hide>
		public virtual bool isScrollingInDirection(float xvel, float yvel)
		{
			return !mFinished && System.Math.Sign(xvel) == System.Math.Sign(mFinalX - mStartX
				) && System.Math.Sign(yvel) == System.Math.Sign(mFinalY - mStartY);
		}
	}
}
