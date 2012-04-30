using Sharpen;

namespace android.widget
{
	/// <summary>
	/// This class encapsulates scrolling with the ability to overshoot the bounds
	/// of a scrolling operation.
	/// </summary>
	/// <remarks>
	/// This class encapsulates scrolling with the ability to overshoot the bounds
	/// of a scrolling operation. This class is a drop-in replacement for
	/// <see cref="Scroller">Scroller</see>
	/// in most cases.
	/// </remarks>
	[Sharpen.Sharpened]
	public class OverScroller
	{
		private int mMode;

		private readonly android.widget.OverScroller.SplineOverScroller mScrollerX;

		private readonly android.widget.OverScroller.SplineOverScroller mScrollerY;

		private readonly android.view.animation.Interpolator mInterpolator;

		private readonly bool mFlywheel;

		internal const int DEFAULT_DURATION = 250;

		internal const int SCROLL_MODE = 0;

		internal const int FLING_MODE = 1;

		/// <summary>Creates an OverScroller with a viscous fluid scroll interpolator and flywheel.
		/// 	</summary>
		/// <remarks>Creates an OverScroller with a viscous fluid scroll interpolator and flywheel.
		/// 	</remarks>
		/// <param name="context"></param>
		public OverScroller(android.content.Context context) : this(context, null)
		{
		}

		/// <summary>Creates an OverScroller with flywheel enabled.</summary>
		/// <remarks>Creates an OverScroller with flywheel enabled.</remarks>
		/// <param name="context">The context of this application.</param>
		/// <param name="interpolator">
		/// The scroll interpolator. If null, a default (viscous) interpolator will
		/// be used.
		/// </param>
		public OverScroller(android.content.Context context, android.view.animation.Interpolator
			 interpolator) : this(context, interpolator, true)
		{
		}

		/// <summary>Creates an OverScroller.</summary>
		/// <remarks>Creates an OverScroller.</remarks>
		/// <param name="context">The context of this application.</param>
		/// <param name="interpolator">
		/// The scroll interpolator. If null, a default (viscous) interpolator will
		/// be used.
		/// </param>
		/// <param name="flywheel">If true, successive fling motions will keep on increasing scroll speed.
		/// 	</param>
		/// <hide></hide>
		public OverScroller(android.content.Context context, android.view.animation.Interpolator
			 interpolator, bool flywheel)
		{
			mInterpolator = interpolator;
			mFlywheel = flywheel;
			mScrollerX = new android.widget.OverScroller.SplineOverScroller();
			mScrollerY = new android.widget.OverScroller.SplineOverScroller();
			android.widget.OverScroller.SplineOverScroller.initFromContext(context);
		}

		/// <summary>Creates an OverScroller with flywheel enabled.</summary>
		/// <remarks>Creates an OverScroller with flywheel enabled.</remarks>
		/// <param name="context">The context of this application.</param>
		/// <param name="interpolator">
		/// The scroll interpolator. If null, a default (viscous) interpolator will
		/// be used.
		/// </param>
		/// <param name="bounceCoefficientX">
		/// A value between 0 and 1 that will determine the proportion of the
		/// velocity which is preserved in the bounce when the horizontal edge is reached. A null value
		/// means no bounce. This behavior is no longer supported and this coefficient has no effect.
		/// </param>
		/// <param name="bounceCoefficientY">
		/// Same as bounceCoefficientX but for the vertical direction. This
		/// behavior is no longer supported and this coefficient has no effect.
		/// !deprecated Use {!link #OverScroller(Context, Interpolator, boolean)} instead.
		/// </param>
		public OverScroller(android.content.Context context, android.view.animation.Interpolator
			 interpolator, float bounceCoefficientX, float bounceCoefficientY) : this(context
			, interpolator, true)
		{
		}

		/// <summary>Creates an OverScroller.</summary>
		/// <remarks>Creates an OverScroller.</remarks>
		/// <param name="context">The context of this application.</param>
		/// <param name="interpolator">
		/// The scroll interpolator. If null, a default (viscous) interpolator will
		/// be used.
		/// </param>
		/// <param name="bounceCoefficientX">
		/// A value between 0 and 1 that will determine the proportion of the
		/// velocity which is preserved in the bounce when the horizontal edge is reached. A null value
		/// means no bounce. This behavior is no longer supported and this coefficient has no effect.
		/// </param>
		/// <param name="bounceCoefficientY">
		/// Same as bounceCoefficientX but for the vertical direction. This
		/// behavior is no longer supported and this coefficient has no effect.
		/// </param>
		/// <param name="flywheel">
		/// If true, successive fling motions will keep on increasing scroll speed.
		/// !deprecated Use {!link OverScroller(Context, Interpolator, boolean)} instead.
		/// </param>
		public OverScroller(android.content.Context context, android.view.animation.Interpolator
			 interpolator, float bounceCoefficientX, float bounceCoefficientY, bool flywheel
			) : this(context, interpolator, flywheel)
		{
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
			mScrollerX.setFriction(friction);
			mScrollerY.setFriction(friction);
		}

		/// <summary>Returns whether the scroller has finished scrolling.</summary>
		/// <remarks>Returns whether the scroller has finished scrolling.</remarks>
		/// <returns>True if the scroller has finished scrolling, false otherwise.</returns>
		public bool isFinished()
		{
			return mScrollerX.mFinished && mScrollerY.mFinished;
		}

		/// <summary>Force the finished field to a particular value.</summary>
		/// <remarks>
		/// Force the finished field to a particular value. Contrary to
		/// <see cref="abortAnimation()">abortAnimation()</see>
		/// , forcing the animation to finished
		/// does NOT cause the scroller to move to the final x and y
		/// position.
		/// </remarks>
		/// <param name="finished">The new finished value.</param>
		public void forceFinished(bool finished)
		{
			mScrollerX.mFinished = mScrollerY.mFinished = finished;
		}

		/// <summary>Returns the current X offset in the scroll.</summary>
		/// <remarks>Returns the current X offset in the scroll.</remarks>
		/// <returns>The new X offset as an absolute distance from the origin.</returns>
		public int getCurrX()
		{
			return mScrollerX.mCurrentPosition;
		}

		/// <summary>Returns the current Y offset in the scroll.</summary>
		/// <remarks>Returns the current Y offset in the scroll.</remarks>
		/// <returns>The new Y offset as an absolute distance from the origin.</returns>
		public int getCurrY()
		{
			return mScrollerY.mCurrentPosition;
		}

		/// <summary>Returns the absolute value of the current velocity.</summary>
		/// <remarks>Returns the absolute value of the current velocity.</remarks>
		/// <returns>The original velocity less the deceleration, norm of the X and Y velocity vector.
		/// 	</returns>
		public virtual float getCurrVelocity()
		{
			float squaredNorm = mScrollerX.mCurrVelocity * mScrollerX.mCurrVelocity;
			squaredNorm += mScrollerY.mCurrVelocity * mScrollerY.mCurrVelocity;
			return android.util.FloatMath.sqrt(squaredNorm);
		}

		/// <summary>Returns the start X offset in the scroll.</summary>
		/// <remarks>Returns the start X offset in the scroll.</remarks>
		/// <returns>The start X offset as an absolute distance from the origin.</returns>
		public int getStartX()
		{
			return mScrollerX.mStart;
		}

		/// <summary>Returns the start Y offset in the scroll.</summary>
		/// <remarks>Returns the start Y offset in the scroll.</remarks>
		/// <returns>The start Y offset as an absolute distance from the origin.</returns>
		public int getStartY()
		{
			return mScrollerY.mStart;
		}

		/// <summary>Returns where the scroll will end.</summary>
		/// <remarks>Returns where the scroll will end. Valid only for "fling" scrolls.</remarks>
		/// <returns>The final X offset as an absolute distance from the origin.</returns>
		public int getFinalX()
		{
			return mScrollerX.mFinal;
		}

		/// <summary>Returns where the scroll will end.</summary>
		/// <remarks>Returns where the scroll will end. Valid only for "fling" scrolls.</remarks>
		/// <returns>The final Y offset as an absolute distance from the origin.</returns>
		public int getFinalY()
		{
			return mScrollerY.mFinal;
		}

		/// <summary>Returns how long the scroll event will take, in milliseconds.</summary>
		/// <remarks>Returns how long the scroll event will take, in milliseconds.</remarks>
		/// <returns>The duration of the scroll in milliseconds.</returns>
		/// <hide>Pending removal once nothing depends on it</hide>
		[System.ObsoleteAttribute(@"OverScrollers don't necessarily have a fixed duration. This function will lie to the best of its ability."
			)]
		public int getDuration()
		{
			return System.Math.Max(mScrollerX.mDuration, mScrollerY.mDuration);
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
		/// <hide>Pending removal once nothing depends on it</hide>
		[System.ObsoleteAttribute(@"OverScrollers don't necessarily have a fixed duration. Instead of setting a new final position and extending the duration of an existing scroll, use startScroll to begin a new animation."
			)]
		public virtual void extendDuration(int extend)
		{
			mScrollerX.extendDuration(extend);
			mScrollerY.extendDuration(extend);
		}

		/// <summary>Sets the final position (X) for this scroller.</summary>
		/// <remarks>Sets the final position (X) for this scroller.</remarks>
		/// <param name="newX">The new X offset as an absolute distance from the origin.</param>
		/// <seealso cref="extendDuration(int)">extendDuration(int)</seealso>
		/// <seealso cref="setFinalY(int)">setFinalY(int)</seealso>
		/// <hide>Pending removal once nothing depends on it</hide>
		[System.ObsoleteAttribute(@"OverScroller's final position may change during an animation. Instead of setting a new final position and extending the duration of an existing scroll, use startScroll to begin a new animation."
			)]
		public virtual void setFinalX(int newX)
		{
			mScrollerX.setFinalPosition(newX);
		}

		/// <summary>Sets the final position (Y) for this scroller.</summary>
		/// <remarks>Sets the final position (Y) for this scroller.</remarks>
		/// <param name="newY">The new Y offset as an absolute distance from the origin.</param>
		/// <seealso cref="extendDuration(int)">extendDuration(int)</seealso>
		/// <seealso cref="setFinalX(int)">setFinalX(int)</seealso>
		/// <hide>Pending removal once nothing depends on it</hide>
		[System.ObsoleteAttribute(@"OverScroller's final position may change during an animation. Instead of setting a new final position and extending the duration of an existing scroll, use startScroll to begin a new animation."
			)]
		public virtual void setFinalY(int newY)
		{
			mScrollerY.setFinalPosition(newY);
		}

		/// <summary>Call this when you want to know the new location.</summary>
		/// <remarks>
		/// Call this when you want to know the new location. If it returns true, the
		/// animation is not yet finished.
		/// </remarks>
		public virtual bool computeScrollOffset()
		{
			if (isFinished())
			{
				return false;
			}
			switch (mMode)
			{
				case SCROLL_MODE:
				{
					long time = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
					// Any scroller can be used for time, since they were started
					// together in scroll mode. We use X here.
					long elapsedTime = time - mScrollerX.mStartTime;
					int duration = mScrollerX.mDuration;
					if (elapsedTime < duration)
					{
						float q = (float)(elapsedTime) / duration;
						if (mInterpolator == null)
						{
							q = android.widget.Scroller.viscousFluid(q);
						}
						else
						{
							q = mInterpolator.getInterpolation(q);
						}
						mScrollerX.updateScroll(q);
						mScrollerY.updateScroll(q);
					}
					else
					{
						abortAnimation();
					}
					break;
				}

				case FLING_MODE:
				{
					if (!mScrollerX.mFinished)
					{
						if (!mScrollerX.update())
						{
							if (!mScrollerX.continueWhenFinished())
							{
								mScrollerX.finish();
							}
						}
					}
					if (!mScrollerY.mFinished)
					{
						if (!mScrollerY.update())
						{
							if (!mScrollerY.continueWhenFinished())
							{
								mScrollerY.finish();
							}
						}
					}
					break;
				}
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
			mScrollerX.startScroll(startX, dx, duration);
			mScrollerY.startScroll(startY, dy, duration);
		}

		/// <summary>Call this when you want to 'spring back' into a valid coordinate range.</summary>
		/// <remarks>Call this when you want to 'spring back' into a valid coordinate range.</remarks>
		/// <param name="startX">Starting X coordinate</param>
		/// <param name="startY">Starting Y coordinate</param>
		/// <param name="minX">Minimum valid X value</param>
		/// <param name="maxX">Maximum valid X value</param>
		/// <param name="minY">Minimum valid Y value</param>
		/// <param name="maxY">Minimum valid Y value</param>
		/// <returns>
		/// true if a springback was initiated, false if startX and startY were
		/// already within the valid range.
		/// </returns>
		public virtual bool springBack(int startX, int startY, int minX, int maxX, int minY
			, int maxY)
		{
			mMode = FLING_MODE;
			// Make sure both methods are called.
			bool spingbackX = mScrollerX.springback(startX, minX, maxX);
			bool spingbackY = mScrollerY.springback(startY, minY, maxY);
			return spingbackX || spingbackY;
		}

		public virtual void fling(int startX, int startY, int velocityX, int velocityY, int
			 minX, int maxX, int minY, int maxY)
		{
			fling(startX, startY, velocityX, velocityY, minX, maxX, minY, maxY, 0, 0);
		}

		/// <summary>Start scrolling based on a fling gesture.</summary>
		/// <remarks>
		/// Start scrolling based on a fling gesture. The distance traveled will
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
		/// Minimum X value. The scroller will not scroll past this point
		/// unless overX &gt; 0. If overfling is allowed, it will use minX as
		/// a springback boundary.
		/// </param>
		/// <param name="maxX">
		/// Maximum X value. The scroller will not scroll past this point
		/// unless overX &gt; 0. If overfling is allowed, it will use maxX as
		/// a springback boundary.
		/// </param>
		/// <param name="minY">
		/// Minimum Y value. The scroller will not scroll past this point
		/// unless overY &gt; 0. If overfling is allowed, it will use minY as
		/// a springback boundary.
		/// </param>
		/// <param name="maxY">
		/// Maximum Y value. The scroller will not scroll past this point
		/// unless overY &gt; 0. If overfling is allowed, it will use maxY as
		/// a springback boundary.
		/// </param>
		/// <param name="overX">
		/// Overfling range. If &gt; 0, horizontal overfling in either
		/// direction will be possible.
		/// </param>
		/// <param name="overY">
		/// Overfling range. If &gt; 0, vertical overfling in either
		/// direction will be possible.
		/// </param>
		public virtual void fling(int startX, int startY, int velocityX, int velocityY, int
			 minX, int maxX, int minY, int maxY, int overX, int overY)
		{
			// Continue a scroll or fling in progress
			if (mFlywheel && !isFinished())
			{
				float oldVelocityX = mScrollerX.mCurrVelocity;
				float oldVelocityY = mScrollerY.mCurrVelocity;
				if (System.Math.Sign(velocityX) == System.Math.Sign(oldVelocityX) && System.Math.Sign
					(velocityY) == System.Math.Sign(oldVelocityY))
				{
					velocityX += (int)(oldVelocityX);
					velocityY += (int)(oldVelocityY);
				}
			}
			mMode = FLING_MODE;
			mScrollerX.fling(startX, velocityX, minX, maxX, overX);
			mScrollerY.fling(startY, velocityY, minY, maxY, overY);
		}

		/// <summary>Notify the scroller that we've reached a horizontal boundary.</summary>
		/// <remarks>
		/// Notify the scroller that we've reached a horizontal boundary.
		/// Normally the information to handle this will already be known
		/// when the animation is started, such as in a call to one of the
		/// fling functions. However there are cases where this cannot be known
		/// in advance. This function will transition the current motion and
		/// animate from startX to finalX as appropriate.
		/// </remarks>
		/// <param name="startX">Starting/current X position</param>
		/// <param name="finalX">Desired final X position</param>
		/// <param name="overX">
		/// Magnitude of overscroll allowed. This should be the maximum
		/// desired distance from finalX. Absolute value - must be positive.
		/// </param>
		public virtual void notifyHorizontalEdgeReached(int startX, int finalX, int overX
			)
		{
			mScrollerX.notifyEdgeReached(startX, finalX, overX);
		}

		/// <summary>Notify the scroller that we've reached a vertical boundary.</summary>
		/// <remarks>
		/// Notify the scroller that we've reached a vertical boundary.
		/// Normally the information to handle this will already be known
		/// when the animation is started, such as in a call to one of the
		/// fling functions. However there are cases where this cannot be known
		/// in advance. This function will animate a parabolic motion from
		/// startY to finalY.
		/// </remarks>
		/// <param name="startY">Starting/current Y position</param>
		/// <param name="finalY">Desired final Y position</param>
		/// <param name="overY">
		/// Magnitude of overscroll allowed. This should be the maximum
		/// desired distance from finalY. Absolute value - must be positive.
		/// </param>
		public virtual void notifyVerticalEdgeReached(int startY, int finalY, int overY)
		{
			mScrollerY.notifyEdgeReached(startY, finalY, overY);
		}

		/// <summary>Returns whether the current Scroller is currently returning to a valid position.
		/// 	</summary>
		/// <remarks>
		/// Returns whether the current Scroller is currently returning to a valid position.
		/// Valid bounds were provided by the
		/// <see cref="fling(int, int, int, int, int, int, int, int, int, int)">fling(int, int, int, int, int, int, int, int, int, int)
		/// 	</see>
		/// method.
		/// One should check this value before calling
		/// <see cref="startScroll(int, int, int, int)">startScroll(int, int, int, int)</see>
		/// as the interpolation currently in progress
		/// to restore a valid position will then be stopped. The caller has to take into account
		/// the fact that the started scroll will start from an overscrolled position.
		/// </remarks>
		/// <returns>
		/// true when the current position is overscrolled and in the process of
		/// interpolating back to a valid value.
		/// </returns>
		public virtual bool isOverScrolled()
		{
			return ((!mScrollerX.mFinished && mScrollerX.mState != android.widget.OverScroller
				.SplineOverScroller.SPLINE) || (!mScrollerY.mFinished && mScrollerY.mState != android.widget.OverScroller
				.SplineOverScroller.SPLINE));
		}

		/// <summary>Stops the animation.</summary>
		/// <remarks>
		/// Stops the animation. Contrary to
		/// <see cref="forceFinished(bool)">forceFinished(bool)</see>
		/// ,
		/// aborting the animating causes the scroller to move to the final x and y
		/// positions.
		/// </remarks>
		/// <seealso cref="forceFinished(bool)">forceFinished(bool)</seealso>
		public virtual void abortAnimation()
		{
			mScrollerX.finish();
			mScrollerY.finish();
		}

		/// <summary>Returns the time elapsed since the beginning of the scrolling.</summary>
		/// <remarks>Returns the time elapsed since the beginning of the scrolling.</remarks>
		/// <returns>The elapsed time in milliseconds.</returns>
		/// <hide></hide>
		public virtual int timePassed()
		{
			long time = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
			long startTime = System.Math.Min(mScrollerX.mStartTime, mScrollerY.mStartTime);
			return (int)(time - startTime);
		}

		/// <hide></hide>
		public virtual bool isScrollingInDirection(float xvel, float yvel)
		{
			int dx = mScrollerX.mFinal - mScrollerX.mStart;
			int dy = mScrollerY.mFinal - mScrollerY.mStart;
			return !isFinished() && System.Math.Sign(xvel) == System.Math.Sign(dx) && System.Math.Sign
				(yvel) == System.Math.Sign(dy);
		}

		internal class SplineOverScroller
		{
			internal int mStart;

			internal int mCurrentPosition;

			internal int mFinal;

			internal int mVelocity;

			internal float mCurrVelocity;

			internal float mDeceleration;

			internal long mStartTime;

			internal int mDuration;

			internal int mSplineDuration;

			internal int mSplineDistance;

			internal bool mFinished;

			internal int mOver;

			internal float mFlingFriction = android.view.ViewConfiguration.getScrollFriction(
				);

			internal int mState = SPLINE;

			internal const float GRAVITY = 2000.0f;

			internal static float PHYSICAL_COEF;

			internal static float DECELERATION_RATE = (float)(System.Math.Log(0.78) / System.Math.Log
				(0.9));

			internal const float INFLEXION = 0.35f;

			internal const float START_TENSION = 0.5f;

			internal const float END_TENSION = 1.0f;

			internal const float P1 = START_TENSION * INFLEXION;

			internal const float P2 = 1.0f - END_TENSION * (1.0f - INFLEXION);

			internal const int NB_SAMPLES = 100;

			internal static readonly float[] SPLINE_POSITION = new float[NB_SAMPLES + 1];

			internal static readonly float[] SPLINE_TIME = new float[NB_SAMPLES + 1];

			internal const int SPLINE = 0;

			internal const int CUBIC = 1;

			internal const int BALLISTIC = 2;

			static SplineOverScroller()
			{
				// Initial position
				// Current position
				// Final position
				// Initial velocity
				// Current velocity
				// Constant current deceleration
				// Animation starting time, in system milliseconds
				// Animation duration, in milliseconds
				// Duration to complete spline component of animation
				// Distance to travel along spline animation
				// Whether the animation is currently in progress
				// The allowed overshot distance before boundary is reached.
				// Fling friction
				// Current state of the animation.
				// Constant gravity value, used in the deceleration phase.
				// A device specific coefficient adjusted to physical values.
				// Tension lines cross at (INFLEXION, 1)
				float x_min = 0.0f;
				float y_min = 0.0f;
				{
					for (int i = 0; i < NB_SAMPLES; i++)
					{
						float alpha = (float)i / NB_SAMPLES;
						float x_max = 1.0f;
						float x;
						float tx;
						float coef;
						while (true)
						{
							x = x_min + (x_max - x_min) / 2.0f;
							coef = 3.0f * x * (1.0f - x);
							tx = coef * ((1.0f - x) * P1 + x * P2) + x * x * x;
							if (System.Math.Abs(tx - alpha) < 1E-5)
							{
								break;
							}
							if (tx > alpha)
							{
								x_max = x;
							}
							else
							{
								x_min = x;
							}
						}
						SPLINE_POSITION[i] = coef * ((1.0f - x) * START_TENSION + x) + x * x * x;
						float y_max = 1.0f;
						float y;
						float dy;
						while (true)
						{
							y = y_min + (y_max - y_min) / 2.0f;
							coef = 3.0f * y * (1.0f - y);
							dy = coef * ((1.0f - y) * START_TENSION + y) + y * y * y;
							if (System.Math.Abs(dy - alpha) < 1E-5)
							{
								break;
							}
							if (dy > alpha)
							{
								y_max = y;
							}
							else
							{
								y_min = y;
							}
						}
						SPLINE_TIME[i] = coef * ((1.0f - y) * P1 + y * P2) + y * y * y;
					}
				}
				SPLINE_POSITION[NB_SAMPLES] = SPLINE_TIME[NB_SAMPLES] = 1.0f;
			}

			internal static void initFromContext(android.content.Context context)
			{
				float ppi = context.getResources().getDisplayMetrics().density * 160.0f;
				PHYSICAL_COEF = android.hardware.SensorManager.GRAVITY_EARTH * 39.37f * ppi * 0.84f;
			}

			// g (m/s^2)
			// inch/meter
			// look and feel tuning
			internal virtual void setFriction(float friction)
			{
				mFlingFriction = friction;
			}

			internal SplineOverScroller()
			{
				mFinished = true;
			}

			internal virtual void updateScroll(float q)
			{
				mCurrentPosition = mStart + Sharpen.Util.Round(q * (mFinal - mStart));
			}

			private static float getDeceleration(int velocity)
			{
				return velocity > 0 ? -GRAVITY : GRAVITY;
			}

			private void adjustDuration(int start, int oldFinal, int newFinal)
			{
				int oldDistance = oldFinal - start;
				int newDistance = newFinal - start;
				float x = System.Math.Abs((float)newDistance / oldDistance);
				int index = (int)(NB_SAMPLES * x);
				if (index < NB_SAMPLES)
				{
					float x_inf = (float)index / NB_SAMPLES;
					float x_sup = (float)(index + 1) / NB_SAMPLES;
					float t_inf = SPLINE_TIME[index];
					float t_sup = SPLINE_TIME[index + 1];
					float timeCoef = t_inf + (x - x_inf) / (x_sup - x_inf) * (t_sup - t_inf);
					mDuration *= (int)(timeCoef);
				}
			}

			internal virtual void startScroll(int start, int distance, int duration)
			{
				mFinished = false;
				mStart = start;
				mFinal = start + distance;
				mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
				mDuration = duration;
				// Unused
				mDeceleration = 0.0f;
				mVelocity = 0;
			}

			internal virtual void finish()
			{
				mCurrentPosition = mFinal;
				// Not reset since WebView relies on this value for fast fling.
				// TODO: restore when WebView uses the fast fling implemented in this class.
				// mCurrVelocity = 0.0f;
				mFinished = true;
			}

			internal virtual void setFinalPosition(int position)
			{
				mFinal = position;
				mFinished = false;
			}

			internal virtual void extendDuration(int extend)
			{
				long time = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
				int elapsedTime = (int)(time - mStartTime);
				mDuration = elapsedTime + extend;
				mFinished = false;
			}

			internal virtual bool springback(int start, int min, int max)
			{
				mFinished = true;
				mStart = mFinal = start;
				mVelocity = 0;
				mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
				mDuration = 0;
				if (start < min)
				{
					startSpringback(start, min, 0);
				}
				else
				{
					if (start > max)
					{
						startSpringback(start, max, 0);
					}
				}
				return !mFinished;
			}

			private void startSpringback(int start, int end, int velocity)
			{
				// mStartTime has been set
				mFinished = false;
				mState = CUBIC;
				mStart = start;
				mFinal = end;
				int delta = start - end;
				mDeceleration = getDeceleration(delta);
				// TODO take velocity into account
				mVelocity = -delta;
				// only sign is used
				mOver = System.Math.Abs(delta);
				mDuration = (int)(1000.0 * System.Math.Sqrt(-2.0 * delta / mDeceleration));
			}

			internal virtual void fling(int start, int velocity, int min, int max, int over)
			{
				mOver = over;
				mFinished = false;
				mCurrVelocity = mVelocity = velocity;
				mDuration = mSplineDuration = 0;
				mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
				mCurrentPosition = mStart = start;
				if (start > max || start < min)
				{
					startAfterEdge(start, min, max, velocity);
					return;
				}
				mState = SPLINE;
				double totalDistance = 0.0;
				if (velocity != 0)
				{
					mDuration = mSplineDuration = getSplineFlingDuration(velocity);
					totalDistance = getSplineFlingDistance(velocity);
				}
				mSplineDistance = (int)(totalDistance * System.Math.Sign(velocity));
				mFinal = start + mSplineDistance;
				// Clamp to a valid final position
				if (mFinal < min)
				{
					adjustDuration(mStart, mFinal, min);
					mFinal = min;
				}
				if (mFinal > max)
				{
					adjustDuration(mStart, mFinal, max);
					mFinal = max;
				}
			}

			private double getSplineDeceleration(int velocity)
			{
				return System.Math.Log(INFLEXION * System.Math.Abs(velocity) / (mFlingFriction * 
					PHYSICAL_COEF));
			}

			private double getSplineFlingDistance(int velocity)
			{
				double l = getSplineDeceleration(velocity);
				double decelMinusOne = DECELERATION_RATE - 1.0;
				return mFlingFriction * PHYSICAL_COEF * System.Math.Exp(DECELERATION_RATE / decelMinusOne
					 * l);
			}

			private int getSplineFlingDuration(int velocity)
			{
				double l = getSplineDeceleration(velocity);
				double decelMinusOne = DECELERATION_RATE - 1.0;
				return (int)(1000.0 * System.Math.Exp(l / decelMinusOne));
			}

			private void fitOnBounceCurve(int start, int end, int velocity)
			{
				// Simulate a bounce that started from edge
				float durationToApex = -velocity / mDeceleration;
				float distanceToApex = velocity * velocity / 2.0f / System.Math.Abs(mDeceleration
					);
				float distanceToEdge = System.Math.Abs(end - start);
				float totalDuration = (float)System.Math.Sqrt(2.0 * (distanceToApex + distanceToEdge
					) / System.Math.Abs(mDeceleration));
				mStartTime -= (int)(1000.0f * (totalDuration - durationToApex));
				mStart = end;
				mVelocity = (int)(-mDeceleration * totalDuration);
			}

			private void startBounceAfterEdge(int start, int end, int velocity)
			{
				mDeceleration = getDeceleration(velocity == 0 ? start - end : velocity);
				fitOnBounceCurve(start, end, velocity);
				onEdgeReached();
			}

			private void startAfterEdge(int start, int min, int max, int velocity)
			{
				if (start > min && start < max)
				{
					android.util.Log.e("OverScroller", "startAfterEdge called from a valid position");
					mFinished = true;
					return;
				}
				bool positive = start > max;
				int edge = positive ? max : min;
				int overDistance = start - edge;
				bool keepIncreasing = overDistance * velocity >= 0;
				if (keepIncreasing)
				{
					// Will result in a bounce or a to_boundary depending on velocity.
					startBounceAfterEdge(start, edge, velocity);
				}
				else
				{
					double totalDistance = getSplineFlingDistance(velocity);
					if (totalDistance > System.Math.Abs(overDistance))
					{
						fling(start, velocity, positive ? min : start, positive ? start : max, mOver);
					}
					else
					{
						startSpringback(start, edge, velocity);
					}
				}
			}

			internal virtual void notifyEdgeReached(int start, int end, int over)
			{
				// mState is used to detect successive notifications 
				if (mState == SPLINE)
				{
					mOver = over;
					mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
					// We were in fling/scroll mode before: current velocity is such that distance to
					// edge is increasing. This ensures that startAfterEdge will not start a new fling.
					startAfterEdge(start, end, end, (int)mCurrVelocity);
				}
			}

			private void onEdgeReached()
			{
				// mStart, mVelocity and mStartTime were adjusted to their values when edge was reached.
				float distance = mVelocity * mVelocity / (2.0f * System.Math.Abs(mDeceleration));
				float sign = System.Math.Sign(mVelocity);
				if (distance > mOver)
				{
					// Default deceleration is not sufficient to slow us down before boundary
					mDeceleration = -sign * mVelocity * mVelocity / (2.0f * mOver);
					distance = mOver;
				}
				mOver = (int)distance;
				mState = BALLISTIC;
				mFinal = mStart + (int)(mVelocity > 0 ? distance : -distance);
				mDuration = -(int)(1000.0f * mVelocity / mDeceleration);
			}

			internal virtual bool continueWhenFinished()
			{
				switch (mState)
				{
					case SPLINE:
					{
						// Duration from start to null velocity
						if (mDuration < mSplineDuration)
						{
							// If the animation was clamped, we reached the edge
							mStart = mFinal;
							// TODO Better compute speed when edge was reached
							mVelocity = (int)mCurrVelocity;
							mDeceleration = getDeceleration(mVelocity);
							mStartTime += mDuration;
							onEdgeReached();
						}
						else
						{
							// Normal stop, no need to continue
							return false;
						}
						break;
					}

					case BALLISTIC:
					{
						mStartTime += mDuration;
						startSpringback(mFinal, mStart, 0);
						break;
					}

					case CUBIC:
					{
						return false;
					}
				}
				update();
				return true;
			}

			internal virtual bool update()
			{
				long time = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
				long currentTime = time - mStartTime;
				if (currentTime > mDuration)
				{
					return false;
				}
				double distance = 0.0;
				switch (mState)
				{
					case SPLINE:
					{
						float t = (float)currentTime / mSplineDuration;
						int index = (int)(NB_SAMPLES * t);
						float distanceCoef = 1.0f;
						float velocityCoef = 0.0f;
						if (index < NB_SAMPLES)
						{
							float t_inf = (float)index / NB_SAMPLES;
							float t_sup = (float)(index + 1) / NB_SAMPLES;
							float d_inf = SPLINE_POSITION[index];
							float d_sup = SPLINE_POSITION[index + 1];
							velocityCoef = (d_sup - d_inf) / (t_sup - t_inf);
							distanceCoef = d_inf + (t - t_inf) * velocityCoef;
						}
						distance = distanceCoef * mSplineDistance;
						mCurrVelocity = velocityCoef * mSplineDistance / mSplineDuration * 1000.0f;
						break;
					}

					case BALLISTIC:
					{
						float t = currentTime / 1000.0f;
						mCurrVelocity = mVelocity + mDeceleration * t;
						distance = mVelocity * t + mDeceleration * t * t / 2.0f;
						break;
					}

					case CUBIC:
					{
						float t = (float)(currentTime) / mDuration;
						float t2 = t * t;
						float sign = System.Math.Sign(mVelocity);
						distance = sign * mOver * (3.0f * t2 - 2.0f * t * t2);
						mCurrVelocity = sign * mOver * 6.0f * (-t + t2);
						break;
					}
				}
				mCurrentPosition = mStart + (int)System.Math.Round(distance);
				return true;
			}
		}
	}
}
