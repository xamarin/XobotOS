using Sharpen;

namespace android.widget.@internal.multiwaveview
{
	[Sharpen.Sharpened]
	public class TargetDrawable
	{
		internal const string TAG = "TargetDrawable";

		internal const bool DEBUG = false;

		public static readonly int[] STATE_ACTIVE = new int[] { android.R.attr.state_enabled
			, android.R.attr.state_active };

		public static readonly int[] STATE_INACTIVE = new int[] { android.R.attr.state_enabled
			, -android.R.attr.state_active };

		public static readonly int[] STATE_FOCUSED = new int[] { android.R.attr.state_enabled
			, android.R.attr.state_focused };

		private float mTranslationX = 0.0f;

		private float mTranslationY = 0.0f;

		private float mScaleX = 1.0f;

		private float mScaleY = 1.0f;

		private float mAlpha = 1.0f;

		private android.graphics.drawable.Drawable mDrawable;

		internal class DrawableWithAlpha : android.graphics.drawable.Drawable
		{
			private float mAlpha = 1.0f;

			private android.graphics.drawable.Drawable mRealDrawable;

			public DrawableWithAlpha(android.graphics.drawable.Drawable realDrawable)
			{
				mRealDrawable = realDrawable;
			}

			public virtual void setAlpha(float alpha)
			{
				mAlpha = alpha;
			}

			public virtual float getAlpha()
			{
				return mAlpha;
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void draw(android.graphics.Canvas canvas)
			{
				mRealDrawable.setAlpha((int)Sharpen.Util.Round(mAlpha * 255f));
				mRealDrawable.draw(canvas);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void setAlpha(int alpha)
			{
				mRealDrawable.setAlpha(alpha);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void setColorFilter(android.graphics.ColorFilter cf)
			{
				mRealDrawable.setColorFilter(cf);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override int getOpacity()
			{
				return mRealDrawable.getOpacity();
			}
		}

		public TargetDrawable(android.content.res.Resources res, int resId) : this(res, resId
			 == 0 ? null : res.getDrawable(resId))
		{
		}

		public TargetDrawable(android.content.res.Resources res, android.graphics.drawable.Drawable
			 drawable)
		{
			// Mutate the drawable so we can animate shared drawable properties.
			mDrawable = drawable != null ? drawable.mutate() : null;
			resizeDrawables();
			setState(STATE_INACTIVE);
		}

		public virtual void setState(int[] state)
		{
			if (mDrawable is android.graphics.drawable.StateListDrawable)
			{
				android.graphics.drawable.StateListDrawable d = (android.graphics.drawable.StateListDrawable
					)mDrawable;
				d.setState(state);
			}
		}

		public virtual bool hasState(int[] state)
		{
			if (mDrawable is android.graphics.drawable.StateListDrawable)
			{
				android.graphics.drawable.StateListDrawable d = (android.graphics.drawable.StateListDrawable
					)mDrawable;
				// TODO: this doesn't seem to work
				return d.getStateDrawableIndex(state) != -1;
			}
			return false;
		}

		/// <summary>Returns true if the drawable is a StateListDrawable and is in the focused state.
		/// 	</summary>
		/// <remarks>Returns true if the drawable is a StateListDrawable and is in the focused state.
		/// 	</remarks>
		/// <returns></returns>
		public virtual bool isActive()
		{
			if (mDrawable is android.graphics.drawable.StateListDrawable)
			{
				android.graphics.drawable.StateListDrawable d = (android.graphics.drawable.StateListDrawable
					)mDrawable;
				int[] states = d.getState();
				{
					for (int i = 0; i < states.Length; i++)
					{
						if (states[i] == android.R.attr.state_focused)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		/// <summary>Returns true if this target is enabled.</summary>
		/// <remarks>
		/// Returns true if this target is enabled. Typically an enabled target contains a valid
		/// drawable in a valid state. Currently all targets with valid drawables are valid.
		/// </remarks>
		/// <returns></returns>
		public virtual bool isValid()
		{
			return mDrawable != null;
		}

		/// <summary>Makes drawables in a StateListDrawable all the same dimensions.</summary>
		/// <remarks>
		/// Makes drawables in a StateListDrawable all the same dimensions.
		/// If not a StateListDrawable, then justs sets the bounds to the intrinsic size of the
		/// drawable.
		/// </remarks>
		private void resizeDrawables()
		{
			if (mDrawable is android.graphics.drawable.StateListDrawable)
			{
				android.graphics.drawable.StateListDrawable d = (android.graphics.drawable.StateListDrawable
					)mDrawable;
				int maxWidth = 0;
				int maxHeight = 0;
				{
					for (int i = 0; i < d.getStateCount(); i++)
					{
						android.graphics.drawable.Drawable childDrawable = d.getStateDrawable(i);
						maxWidth = System.Math.Max(maxWidth, childDrawable.getIntrinsicWidth());
						maxHeight = System.Math.Max(maxHeight, childDrawable.getIntrinsicHeight());
					}
				}
				d.setBounds(0, 0, maxWidth, maxHeight);
				{
					for (int i_1 = 0; i_1 < d.getStateCount(); i_1++)
					{
						android.graphics.drawable.Drawable childDrawable = d.getStateDrawable(i_1);
						childDrawable.setBounds(0, 0, maxWidth, maxHeight);
					}
				}
			}
			else
			{
				if (mDrawable != null)
				{
					mDrawable.setBounds(0, 0, mDrawable.getIntrinsicWidth(), mDrawable.getIntrinsicHeight
						());
				}
			}
		}

		public virtual void setX(float x)
		{
			mTranslationX = x;
		}

		public virtual void setY(float y)
		{
			mTranslationY = y;
		}

		public virtual void setScaleX(float x)
		{
			mScaleX = x;
		}

		public virtual void setScaleY(float y)
		{
			mScaleY = y;
		}

		public virtual void setAlpha(float alpha)
		{
			mAlpha = alpha;
		}

		public virtual float getX()
		{
			return mTranslationX;
		}

		public virtual float getY()
		{
			return mTranslationY;
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

		public virtual int getWidth()
		{
			return mDrawable != null ? mDrawable.getIntrinsicWidth() : 0;
		}

		public virtual int getHeight()
		{
			return mDrawable != null ? mDrawable.getIntrinsicHeight() : 0;
		}

		public virtual void draw(android.graphics.Canvas canvas)
		{
			if (mDrawable == null)
			{
				return;
			}
			canvas.save(android.graphics.Canvas.MATRIX_SAVE_FLAG);
			canvas.translate(mTranslationX, mTranslationY);
			canvas.scale(mScaleX, mScaleY);
			canvas.translate(-0.5f * getWidth(), -0.5f * getHeight());
			mDrawable.setAlpha((int)Sharpen.Util.Round(mAlpha * 255f));
			mDrawable.draw(canvas);
			canvas.restore();
		}
	}
}
