using Sharpen;

namespace android.widget
{
	/// <summary>
	/// This class performs the graphical effect used at the edges of scrollable widgets
	/// when the user scrolls beyond the content bounds in 2D space.
	/// </summary>
	/// <remarks>
	/// This class performs the graphical effect used at the edges of scrollable widgets
	/// when the user scrolls beyond the content bounds in 2D space.
	/// <p>EdgeEffect is stateful. Custom widgets using EdgeEffect should create an
	/// instance for each edge that should show the effect, feed it input data using
	/// the methods
	/// <see cref="onAbsorb(int)">onAbsorb(int)</see>
	/// ,
	/// <see cref="onPull(float)">onPull(float)</see>
	/// , and
	/// <see cref="onRelease()">onRelease()</see>
	/// ,
	/// and draw the effect using
	/// <see cref="draw(android.graphics.Canvas)">draw(android.graphics.Canvas)</see>
	/// in the widget's overridden
	/// <see cref="android.view.View.draw(android.graphics.Canvas)">android.view.View.draw(android.graphics.Canvas)
	/// 	</see>
	/// method. If
	/// <see cref="isFinished()">isFinished()</see>
	/// returns
	/// false after drawing, the edge effect's animation is not yet complete and the widget
	/// should schedule another drawing pass to continue the animation.</p>
	/// <p>When drawing, widgets should draw their main content and child views first,
	/// usually by invoking <code>super.draw(canvas)</code> from an overridden <code>draw</code>
	/// method. (This will invoke onDraw and dispatch drawing to child views as needed.)
	/// The edge effect may then be drawn on top of the view's content using the
	/// <see cref="draw(android.graphics.Canvas)">draw(android.graphics.Canvas)</see>
	/// method.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class EdgeEffect
	{
		internal const string TAG = "EdgeEffect";

		internal const int RECEDE_TIME = 1000;

		internal const int PULL_TIME = 167;

		internal const int PULL_DECAY_TIME = 1000;

		internal const float MAX_ALPHA = 0.8f;

		internal const float HELD_EDGE_ALPHA = 0.7f;

		internal const float HELD_EDGE_SCALE_Y = 0.5f;

		internal const float HELD_GLOW_ALPHA = 0.5f;

		internal const float HELD_GLOW_SCALE_Y = 0.5f;

		internal const float MAX_GLOW_HEIGHT = 4.0f;

		internal const float PULL_GLOW_BEGIN = 1.0f;

		internal const float PULL_EDGE_BEGIN = 0.6f;

		internal const int MIN_VELOCITY = 100;

		internal const float EPSILON = 0.001f;

		private readonly android.graphics.drawable.Drawable mEdge;

		private readonly android.graphics.drawable.Drawable mGlow;

		private int mWidth;

		private int mHeight;

		private readonly int MIN_WIDTH = 300;

		private readonly int mMinWidth;

		private float mEdgeAlpha;

		private float mEdgeScaleY;

		private float mGlowAlpha;

		private float mGlowScaleY;

		private float mEdgeAlphaStart;

		private float mEdgeAlphaFinish;

		private float mEdgeScaleYStart;

		private float mEdgeScaleYFinish;

		private float mGlowAlphaStart;

		private float mGlowAlphaFinish;

		private float mGlowScaleYStart;

		private float mGlowScaleYFinish;

		private long mStartTime;

		private float mDuration;

		private readonly android.view.animation.Interpolator mInterpolator;

		internal const int STATE_IDLE = 0;

		internal const int STATE_PULL = 1;

		internal const int STATE_ABSORB = 2;

		internal const int STATE_RECEDE = 3;

		internal const int STATE_PULL_DECAY = 4;

		internal const int PULL_DISTANCE_EDGE_FACTOR = 7;

		internal const int PULL_DISTANCE_GLOW_FACTOR = 7;

		internal const float PULL_DISTANCE_ALPHA_GLOW_FACTOR = 1.1f;

		internal const int VELOCITY_EDGE_FACTOR = 8;

		internal const int VELOCITY_GLOW_FACTOR = 16;

		private int mState = STATE_IDLE;

		private float mPullDistance;

		/// <summary>Construct a new EdgeEffect with a theme appropriate for the provided context.
		/// 	</summary>
		/// <remarks>Construct a new EdgeEffect with a theme appropriate for the provided context.
		/// 	</remarks>
		/// <param name="context">Context used to provide theming and resource information for the EdgeEffect
		/// 	</param>
		public EdgeEffect(android.content.Context context)
		{
			// Time it will take the effect to fully recede in ms
			// Time it will take before a pulled glow begins receding in ms
			// Time it will take in ms for a pulled glow to decay to partial strength before release
			// Minimum velocity that will be absorbed
			// How much dragging should effect the height of the edge image.
			// Number determined by user testing.
			// How much dragging should effect the height of the glow image.
			// Number determined by user testing.
			android.content.res.Resources res = context.getResources();
			mEdge = res.getDrawable(android.@internal.R.drawable.overscroll_edge);
			mGlow = res.getDrawable(android.@internal.R.drawable.overscroll_glow);
			mMinWidth = (int)(context.getResources().getDisplayMetrics().density * MIN_WIDTH 
				+ 0.5f);
			mInterpolator = new android.view.animation.DecelerateInterpolator();
		}

		/// <summary>Set the size of this edge effect in pixels.</summary>
		/// <remarks>Set the size of this edge effect in pixels.</remarks>
		/// <param name="width">Effect width in pixels</param>
		/// <param name="height">Effect height in pixels</param>
		public virtual void setSize(int width, int height)
		{
			mWidth = width;
			mHeight = height;
		}

		/// <summary>Reports if this EdgeEffect's animation is finished.</summary>
		/// <remarks>
		/// Reports if this EdgeEffect's animation is finished. If this method returns false
		/// after a call to
		/// <see cref="draw(android.graphics.Canvas)">draw(android.graphics.Canvas)</see>
		/// the host widget should schedule another
		/// drawing pass to continue the animation.
		/// </remarks>
		/// <returns>true if animation is finished, false if drawing should continue on the next frame.
		/// 	</returns>
		public virtual bool isFinished()
		{
			return mState == STATE_IDLE;
		}

		/// <summary>Immediately finish the current animation.</summary>
		/// <remarks>
		/// Immediately finish the current animation.
		/// After this call
		/// <see cref="isFinished()">isFinished()</see>
		/// will return true.
		/// </remarks>
		public virtual void finish()
		{
			mState = STATE_IDLE;
		}

		/// <summary>A view should call this when content is pulled away from an edge by the user.
		/// 	</summary>
		/// <remarks>
		/// A view should call this when content is pulled away from an edge by the user.
		/// This will update the state of the current visual effect and its associated animation.
		/// The host view should always
		/// <see cref="android.view.View.invalidate()">android.view.View.invalidate()</see>
		/// after this
		/// and draw the results accordingly.
		/// </remarks>
		/// <param name="deltaDistance">
		/// Change in distance since the last call. Values may be 0 (no change) to
		/// 1.f (full length of the view) or negative values to express change
		/// back toward the edge reached to initiate the effect.
		/// </param>
		public virtual void onPull(float deltaDistance)
		{
			long now = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
			if (mState == STATE_PULL_DECAY && now - mStartTime < mDuration)
			{
				return;
			}
			if (mState != STATE_PULL)
			{
				mGlowScaleY = PULL_GLOW_BEGIN;
			}
			mState = STATE_PULL;
			mStartTime = now;
			mDuration = PULL_TIME;
			mPullDistance += deltaDistance;
			float distance = System.Math.Abs(mPullDistance);
			mEdgeAlpha = mEdgeAlphaStart = System.Math.Max(PULL_EDGE_BEGIN, System.Math.Min(distance
				, MAX_ALPHA));
			mEdgeScaleY = mEdgeScaleYStart = System.Math.Max(HELD_EDGE_SCALE_Y, System.Math.Min
				(distance * PULL_DISTANCE_EDGE_FACTOR, 1.0f));
			mGlowAlpha = mGlowAlphaStart = System.Math.Min(MAX_ALPHA, mGlowAlpha + (System.Math.Abs
				(deltaDistance) * PULL_DISTANCE_ALPHA_GLOW_FACTOR));
			float glowChange = System.Math.Abs(deltaDistance);
			if (deltaDistance > 0 && mPullDistance < 0)
			{
				glowChange = -glowChange;
			}
			if (mPullDistance == 0)
			{
				mGlowScaleY = 0;
			}
			// Do not allow glow to get larger than MAX_GLOW_HEIGHT.
			mGlowScaleY = mGlowScaleYStart = System.Math.Min(MAX_GLOW_HEIGHT, System.Math.Max
				(0, mGlowScaleY + glowChange * PULL_DISTANCE_GLOW_FACTOR));
			mEdgeAlphaFinish = mEdgeAlpha;
			mEdgeScaleYFinish = mEdgeScaleY;
			mGlowAlphaFinish = mGlowAlpha;
			mGlowScaleYFinish = mGlowScaleY;
		}

		/// <summary>Call when the object is released after being pulled.</summary>
		/// <remarks>
		/// Call when the object is released after being pulled.
		/// This will begin the "decay" phase of the effect. After calling this method
		/// the host view should
		/// <see cref="android.view.View.invalidate()">android.view.View.invalidate()</see>
		/// and thereby
		/// draw the results accordingly.
		/// </remarks>
		public virtual void onRelease()
		{
			mPullDistance = 0;
			if (mState != STATE_PULL && mState != STATE_PULL_DECAY)
			{
				return;
			}
			mState = STATE_RECEDE;
			mEdgeAlphaStart = mEdgeAlpha;
			mEdgeScaleYStart = mEdgeScaleY;
			mGlowAlphaStart = mGlowAlpha;
			mGlowScaleYStart = mGlowScaleY;
			mEdgeAlphaFinish = 0.0f;
			mEdgeScaleYFinish = 0.0f;
			mGlowAlphaFinish = 0.0f;
			mGlowScaleYFinish = 0.0f;
			mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
			mDuration = RECEDE_TIME;
		}

		/// <summary>Call when the effect absorbs an impact at the given velocity.</summary>
		/// <remarks>
		/// Call when the effect absorbs an impact at the given velocity.
		/// Used when a fling reaches the scroll boundary.
		/// <p>When using a
		/// <see cref="Scroller">Scroller</see>
		/// or
		/// <see cref="OverScroller">OverScroller</see>
		/// ,
		/// the method <code>getCurrVelocity</code> will provide a reasonable approximation
		/// to use here.</p>
		/// </remarks>
		/// <param name="velocity">Velocity at impact in pixels per second.</param>
		public virtual void onAbsorb(int velocity)
		{
			mState = STATE_ABSORB;
			velocity = System.Math.Max(MIN_VELOCITY, System.Math.Abs(velocity));
			mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
			mDuration = 0.1f + (velocity * 0.03f);
			// The edge should always be at least partially visible, regardless
			// of velocity.
			mEdgeAlphaStart = 0.0f;
			mEdgeScaleY = mEdgeScaleYStart = 0.0f;
			// The glow depends more on the velocity, and therefore starts out
			// nearly invisible.
			mGlowAlphaStart = 0.5f;
			mGlowScaleYStart = 0.0f;
			// Factor the velocity by 8. Testing on device shows this works best to
			// reflect the strength of the user's scrolling.
			mEdgeAlphaFinish = System.Math.Max(0, System.Math.Min(velocity * VELOCITY_EDGE_FACTOR
				, 1));
			// Edge should never get larger than the size of its asset.
			mEdgeScaleYFinish = System.Math.Max(HELD_EDGE_SCALE_Y, System.Math.Min(velocity *
				 VELOCITY_EDGE_FACTOR, 1.0f));
			// Growth for the size of the glow should be quadratic to properly
			// respond
			// to a user's scrolling speed. The faster the scrolling speed, the more
			// intense the effect should be for both the size and the saturation.
			mGlowScaleYFinish = System.Math.Min(0.025f + (velocity * (velocity / 100) * 0.00015f
				), 1.75f);
			// Alpha should change for the glow as well as size.
			mGlowAlphaFinish = System.Math.Max(mGlowAlphaStart, System.Math.Min(velocity * VELOCITY_GLOW_FACTOR
				 * .00001f, MAX_ALPHA));
		}

		/// <summary>Draw into the provided canvas.</summary>
		/// <remarks>
		/// Draw into the provided canvas. Assumes that the canvas has been rotated
		/// accordingly and the size has been set. The effect will be drawn the full
		/// width of X=0 to X=width, beginning from Y=0 and extending to some factor &lt;
		/// 1.f of height.
		/// </remarks>
		/// <param name="canvas">Canvas to draw into</param>
		/// <returns>
		/// true if drawing should continue beyond this frame to continue the
		/// animation
		/// </returns>
		public virtual bool draw(android.graphics.Canvas canvas)
		{
			update();
			int edgeHeight = mEdge.getIntrinsicHeight();
			int edgeWidth = mEdge.getIntrinsicWidth();
			int glowHeight = mGlow.getIntrinsicHeight();
			int glowWidth = mGlow.getIntrinsicWidth();
			mGlow.setAlpha((int)(System.Math.Max(0, System.Math.Min(mGlowAlpha, 1)) * 255));
			int glowBottom = (int)System.Math.Min(glowHeight * mGlowScaleY * glowHeight / glowWidth
				 * 0.6f, glowHeight * MAX_GLOW_HEIGHT);
			if (mWidth < mMinWidth)
			{
				// Center the glow and clip it.
				int glowLeft = (mWidth - mMinWidth) / 2;
				mGlow.setBounds(glowLeft, 0, mWidth - glowLeft, glowBottom);
			}
			else
			{
				// Stretch the glow to fit.
				mGlow.setBounds(0, 0, mWidth, glowBottom);
			}
			mGlow.draw(canvas);
			mEdge.setAlpha((int)(System.Math.Max(0, System.Math.Min(mEdgeAlpha, 1)) * 255));
			int edgeBottom = (int)(edgeHeight * mEdgeScaleY);
			if (mWidth < mMinWidth)
			{
				// Center the edge and clip it.
				int edgeLeft = (mWidth - mMinWidth) / 2;
				mEdge.setBounds(edgeLeft, 0, mWidth - edgeLeft, edgeBottom);
			}
			else
			{
				// Stretch the edge to fit.
				mEdge.setBounds(0, 0, mWidth, edgeBottom);
			}
			mEdge.draw(canvas);
			return mState != STATE_IDLE;
		}

		private void update()
		{
			long time = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
			float t = System.Math.Min((time - mStartTime) / mDuration, 1.0f);
			float interp = mInterpolator.getInterpolation(t);
			mEdgeAlpha = mEdgeAlphaStart + (mEdgeAlphaFinish - mEdgeAlphaStart) * interp;
			mEdgeScaleY = mEdgeScaleYStart + (mEdgeScaleYFinish - mEdgeScaleYStart) * interp;
			mGlowAlpha = mGlowAlphaStart + (mGlowAlphaFinish - mGlowAlphaStart) * interp;
			mGlowScaleY = mGlowScaleYStart + (mGlowScaleYFinish - mGlowScaleYStart) * interp;
			if (t >= 1.0f - EPSILON)
			{
				switch (mState)
				{
					case STATE_ABSORB:
					{
						mState = STATE_RECEDE;
						mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
						mDuration = RECEDE_TIME;
						mEdgeAlphaStart = mEdgeAlpha;
						mEdgeScaleYStart = mEdgeScaleY;
						mGlowAlphaStart = mGlowAlpha;
						mGlowScaleYStart = mGlowScaleY;
						// After absorb, the glow and edge should fade to nothing.
						mEdgeAlphaFinish = 0.0f;
						mEdgeScaleYFinish = 0.0f;
						mGlowAlphaFinish = 0.0f;
						mGlowScaleYFinish = 0.0f;
						break;
					}

					case STATE_PULL:
					{
						mState = STATE_PULL_DECAY;
						mStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
						mDuration = PULL_DECAY_TIME;
						mEdgeAlphaStart = mEdgeAlpha;
						mEdgeScaleYStart = mEdgeScaleY;
						mGlowAlphaStart = mGlowAlpha;
						mGlowScaleYStart = mGlowScaleY;
						// After pull, the glow and edge should fade to nothing.
						mEdgeAlphaFinish = 0.0f;
						mEdgeScaleYFinish = 0.0f;
						mGlowAlphaFinish = 0.0f;
						mGlowScaleYFinish = 0.0f;
						break;
					}

					case STATE_PULL_DECAY:
					{
						// When receding, we want edge to decrease more slowly
						// than the glow.
						float factor = mGlowScaleYFinish != 0 ? 1 / (mGlowScaleYFinish * mGlowScaleYFinish
							) : float.MaxValue;
						mEdgeScaleY = mEdgeScaleYStart + (mEdgeScaleYFinish - mEdgeScaleYStart) * interp 
							* factor;
						mState = STATE_RECEDE;
						break;
					}

					case STATE_RECEDE:
					{
						mState = STATE_IDLE;
						break;
					}
				}
			}
		}
	}
}
