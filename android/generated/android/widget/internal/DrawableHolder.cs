using Sharpen;

namespace android.widget.@internal
{
	/// <summary>This class is a container for a Drawable with multiple animated properties.
	/// 	</summary>
	/// <remarks>This class is a container for a Drawable with multiple animated properties.
	/// 	</remarks>
	[Sharpen.Sharpened]
	public class DrawableHolder : android.animation.Animator.AnimatorListener
	{
		public static readonly android.view.animation.DecelerateInterpolator EASE_OUT_INTERPOLATOR
			 = new android.view.animation.DecelerateInterpolator();

		internal const string TAG = "DrawableHolder";

		internal const bool DBG = false;

		private float mX = 0.0f;

		private float mY = 0.0f;

		private float mScaleX = 1.0f;

		private float mScaleY = 1.0f;

		private android.graphics.drawable.BitmapDrawable mDrawable;

		private float mAlpha = 1f;

		private java.util.ArrayList<android.animation.ObjectAnimator> mAnimators = new java.util.ArrayList
			<android.animation.ObjectAnimator>();

		private java.util.ArrayList<android.animation.ObjectAnimator> mNeedToStart = new 
			java.util.ArrayList<android.animation.ObjectAnimator>();

		public DrawableHolder(android.graphics.drawable.BitmapDrawable drawable) : this(drawable
			, 0.0f, 0.0f)
		{
		}

		public DrawableHolder(android.graphics.drawable.BitmapDrawable drawable, float x, 
			float y)
		{
			mDrawable = drawable;
			mX = x;
			mY = y;
			mDrawable.getPaint().setAntiAlias(true);
			// Force AA
			mDrawable.setBounds(0, 0, mDrawable.getIntrinsicWidth(), mDrawable.getIntrinsicHeight
				());
		}

		/// <summary>
		/// Adds an animation that interpolates given property from its current value
		/// to the given value.
		/// </summary>
		/// <remarks>
		/// Adds an animation that interpolates given property from its current value
		/// to the given value.
		/// </remarks>
		/// <param name="duration">the duration, in ms.</param>
		/// <param name="delay">the delay to start the animation, in ms.</param>
		/// <param name="property">the property to animate</param>
		/// <param name="toValue">the target value</param>
		/// <param name="replace">if true, replace the current animation with this one.</param>
		public virtual android.animation.ObjectAnimator addAnimTo(long duration, long delay
			, string property, float toValue, bool replace)
		{
			if (replace)
			{
				removeAnimationFor(property);
			}
			android.animation.ObjectAnimator anim = android.animation.ObjectAnimator.ofFloat(
				this, property, toValue);
			anim.setDuration(duration);
			anim.setStartDelay(delay);
			anim.setInterpolator(EASE_OUT_INTERPOLATOR);
			this.addAnimation(anim, replace);
			return anim;
		}

		/// <summary>Stops all animations for the given property and removes it from the list.
		/// 	</summary>
		/// <remarks>Stops all animations for the given property and removes it from the list.
		/// 	</remarks>
		/// <param name="property"></param>
		public virtual void removeAnimationFor(string property)
		{
			java.util.ArrayList<android.animation.ObjectAnimator> removalList = (java.util.ArrayList
				<android.animation.ObjectAnimator>)mAnimators.clone();
			foreach (android.animation.ObjectAnimator currentAnim in Sharpen.IterableProxy.Create
				(removalList))
			{
				if (property.Equals(currentAnim.getPropertyName()))
				{
					currentAnim.cancel();
				}
			}
		}

		/// <summary>Stops all animations and removes them from the list.</summary>
		/// <remarks>Stops all animations and removes them from the list.</remarks>
		public virtual void clearAnimations()
		{
			foreach (android.animation.ObjectAnimator currentAnim in Sharpen.IterableProxy.Create
				(mAnimators))
			{
				currentAnim.cancel();
			}
			mAnimators.clear();
		}

		/// <summary>Adds the given animation to the list of animations for this object.</summary>
		/// <remarks>Adds the given animation to the list of animations for this object.</remarks>
		/// <param name="anim"></param>
		/// <param name="overwrite"></param>
		/// <returns></returns>
		private android.widget.@internal.DrawableHolder addAnimation(android.animation.ObjectAnimator
			 anim, bool overwrite)
		{
			if (anim != null)
			{
				mAnimators.add(anim);
			}
			mNeedToStart.add(anim);
			return this;
		}

		/// <summary>Draw this object to the canvas using the properties defined in this class.
		/// 	</summary>
		/// <remarks>Draw this object to the canvas using the properties defined in this class.
		/// 	</remarks>
		/// <param name="canvas">canvas to draw into</param>
		public virtual void draw(android.graphics.Canvas canvas)
		{
			float threshold = 1.0f / 256.0f;
			// contribution less than 1 LSB of RGB byte
			if (mAlpha <= threshold)
			{
				// don't bother if it won't show up
				return;
			}
			canvas.save(android.graphics.Canvas.MATRIX_SAVE_FLAG);
			canvas.translate(mX, mY);
			canvas.scale(mScaleX, mScaleY);
			canvas.translate(-0.5f * getWidth(), -0.5f * getHeight());
			mDrawable.setAlpha((int)Sharpen.Util.Round(mAlpha * 255f));
			mDrawable.draw(canvas);
			canvas.restore();
		}

		/// <summary>Starts all animations added since the last call to this function.</summary>
		/// <remarks>
		/// Starts all animations added since the last call to this function.  Used to synchronize
		/// animations.
		/// </remarks>
		/// <param name="listener">
		/// an optional listener to add to the animations. Typically used to know when
		/// to invalidate the surface these are being drawn to.
		/// </param>
		public virtual void startAnimations(android.animation.ValueAnimator.AnimatorUpdateListener
			 listener)
		{
			{
				for (int i = 0; i < mNeedToStart.size(); i++)
				{
					android.animation.ObjectAnimator anim = mNeedToStart.get(i);
					anim.addUpdateListener(listener);
					anim.addListener(this);
					anim.start();
				}
			}
			mNeedToStart.clear();
		}

		public virtual void setX(float value)
		{
			mX = value;
		}

		public virtual void setY(float value)
		{
			mY = value;
		}

		public virtual void setScaleX(float value)
		{
			mScaleX = value;
		}

		public virtual void setScaleY(float value)
		{
			mScaleY = value;
		}

		public virtual void setAlpha(float alpha)
		{
			mAlpha = alpha;
		}

		public virtual float getX()
		{
			return mX;
		}

		public virtual float getY()
		{
			return mY;
		}

		public virtual float getScaleX()
		{
			return mScaleX;
		}

		public virtual float getScaleY()
		{
			return mScaleY;
		}

		public virtual float getAlpha()
		{
			return mAlpha;
		}

		public virtual android.graphics.drawable.BitmapDrawable getDrawable()
		{
			return mDrawable;
		}

		public virtual int getWidth()
		{
			return mDrawable.getIntrinsicWidth();
		}

		public virtual int getHeight()
		{
			return mDrawable.getIntrinsicHeight();
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationCancel(android.animation.Animator animation)
		{
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationEnd(android.animation.Animator animation)
		{
			mAnimators.remove(animation);
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationRepeat(android.animation.Animator animation)
		{
		}

		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationStart(android.animation.Animator animation)
		{
		}
	}
}
