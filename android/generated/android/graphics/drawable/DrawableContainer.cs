using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// A helper class that contains several
	/// <see cref="Drawable">Drawable</see>
	/// s and selects which one to use.
	/// You can subclass it to create your own DrawableContainers or directly use one its child classes.
	/// </summary>
	[Sharpen.Sharpened]
	public class DrawableContainer : android.graphics.drawable.Drawable, android.graphics.drawable.Drawable
		.Callback
	{
		internal const bool DEBUG = false;

		internal const string TAG = "DrawableContainer";

		/// <summary>
		/// To be proper, we should have a getter for dither (and alpha, etc.)
		/// so that proxy classes like this can save/restore their delegates'
		/// values, but we don't have getters.
		/// </summary>
		/// <remarks>
		/// To be proper, we should have a getter for dither (and alpha, etc.)
		/// so that proxy classes like this can save/restore their delegates'
		/// values, but we don't have getters. Since we do have setters
		/// (e.g. setDither), which this proxy forwards on, we have to have some
		/// default/initial setting.
		/// The initial setting for dither is now true, since it almost always seems
		/// to improve the quality at negligible cost.
		/// </remarks>
		internal const bool DEFAULT_DITHER = true;

		private android.graphics.drawable.DrawableContainer.DrawableContainerState mDrawableContainerState;

		private android.graphics.drawable.Drawable mCurrDrawable;

		private int mAlpha = unchecked((int)(0xFF));

		private android.graphics.ColorFilter mColorFilter;

		private int mCurIndex = -1;

		private bool mMutated;

		private java.lang.Runnable mAnimationRunnable;

		private long mEnterAnimationEnd;

		private long mExitAnimationEnd;

		private android.graphics.drawable.Drawable mLastDrawable;

		// Animations.
		// overrides from Drawable
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			if (mCurrDrawable != null)
			{
				mCurrDrawable.draw(canvas);
			}
			if (mLastDrawable != null)
			{
				mLastDrawable.draw(canvas);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mDrawableContainerState.mChangingConfigurations
				 | mDrawableContainerState.mChildrenChangingConfigurations;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			android.graphics.Rect r = mDrawableContainerState.getConstantPadding();
			if (r != null)
			{
				padding.set(r);
				return true;
			}
			if (mCurrDrawable != null)
			{
				return mCurrDrawable.getPadding(padding);
			}
			else
			{
				return base.getPadding(padding);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			if (mAlpha != alpha)
			{
				mAlpha = alpha;
				if (mCurrDrawable != null)
				{
					if (mEnterAnimationEnd == 0)
					{
						mCurrDrawable.setAlpha(alpha);
					}
					else
					{
						animate(false);
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setDither(bool dither)
		{
			if (mDrawableContainerState.mDither != dither)
			{
				mDrawableContainerState.mDither = dither;
				if (mCurrDrawable != null)
				{
					mCurrDrawable.setDither(mDrawableContainerState.mDither);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			if (mColorFilter != cf)
			{
				mColorFilter = cf;
				if (mCurrDrawable != null)
				{
					mCurrDrawable.setColorFilter(cf);
				}
			}
		}

		/// <summary>
		/// Change the global fade duration when a new drawable is entering
		/// the scene.
		/// </summary>
		/// <remarks>
		/// Change the global fade duration when a new drawable is entering
		/// the scene.
		/// </remarks>
		/// <param name="ms">The amount of time to fade in milliseconds.</param>
		public virtual void setEnterFadeDuration(int ms)
		{
			mDrawableContainerState.mEnterFadeDuration = ms;
		}

		/// <summary>
		/// Change the global fade duration when a new drawable is leaving
		/// the scene.
		/// </summary>
		/// <remarks>
		/// Change the global fade duration when a new drawable is leaving
		/// the scene.
		/// </remarks>
		/// <param name="ms">The amount of time to fade in milliseconds.</param>
		public virtual void setExitFadeDuration(int ms)
		{
			mDrawableContainerState.mExitFadeDuration = ms;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			if (mLastDrawable != null)
			{
				mLastDrawable.setBounds(bounds);
			}
			if (mCurrDrawable != null)
			{
				mCurrDrawable.setBounds(bounds);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return mDrawableContainerState.isStateful();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void jumpToCurrentState()
		{
			bool changed = false;
			if (mLastDrawable != null)
			{
				mLastDrawable.jumpToCurrentState();
				mLastDrawable = null;
				changed = true;
			}
			if (mCurrDrawable != null)
			{
				mCurrDrawable.jumpToCurrentState();
				mCurrDrawable.setAlpha(mAlpha);
			}
			if (mExitAnimationEnd != 0)
			{
				mExitAnimationEnd = 0;
				changed = true;
			}
			if (mEnterAnimationEnd != 0)
			{
				mEnterAnimationEnd = 0;
				changed = true;
			}
			if (changed)
			{
				invalidateSelf();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onStateChange(int[] state)
		{
			if (mLastDrawable != null)
			{
				return mLastDrawable.setState(state);
			}
			if (mCurrDrawable != null)
			{
				return mCurrDrawable.setState(state);
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onLevelChange(int level)
		{
			if (mLastDrawable != null)
			{
				return mLastDrawable.setLevel(level);
			}
			if (mCurrDrawable != null)
			{
				return mCurrDrawable.setLevel(level);
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			if (mDrawableContainerState.isConstantSize())
			{
				return mDrawableContainerState.getConstantWidth();
			}
			return mCurrDrawable != null ? mCurrDrawable.getIntrinsicWidth() : -1;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			if (mDrawableContainerState.isConstantSize())
			{
				return mDrawableContainerState.getConstantHeight();
			}
			return mCurrDrawable != null ? mCurrDrawable.getIntrinsicHeight() : -1;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getMinimumWidth()
		{
			if (mDrawableContainerState.isConstantSize())
			{
				return mDrawableContainerState.getConstantMinimumWidth();
			}
			return mCurrDrawable != null ? mCurrDrawable.getMinimumWidth() : 0;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getMinimumHeight()
		{
			if (mDrawableContainerState.isConstantSize())
			{
				return mDrawableContainerState.getConstantMinimumHeight();
			}
			return mCurrDrawable != null ? mCurrDrawable.getMinimumHeight() : 0;
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void invalidateDrawable(android.graphics.drawable.Drawable who)
		{
			if (who == mCurrDrawable && getCallback() != null)
			{
				getCallback().invalidateDrawable(this);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void scheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what, long when)
		{
			if (who == mCurrDrawable && getCallback() != null)
			{
				getCallback().scheduleDrawable(this, what, when);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void unscheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what)
		{
			if (who == mCurrDrawable && getCallback() != null)
			{
				getCallback().unscheduleDrawable(this, what);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool setVisible(bool visible, bool restart)
		{
			bool changed = base.setVisible(visible, restart);
			if (mLastDrawable != null)
			{
				mLastDrawable.setVisible(visible, restart);
			}
			if (mCurrDrawable != null)
			{
				mCurrDrawable.setVisible(visible, restart);
			}
			return changed;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			return mCurrDrawable == null || !mCurrDrawable.isVisible() ? android.graphics.PixelFormat
				.TRANSPARENT : mDrawableContainerState.getOpacity();
		}

		private sealed class _Runnable_325 : java.lang.Runnable
		{
			public _Runnable_325(DrawableContainer _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.animate(true);
				this._enclosing.invalidateSelf();
			}

			private readonly DrawableContainer _enclosing;
		}

		public virtual bool selectDrawable(int idx)
		{
			if (idx == mCurIndex)
			{
				return false;
			}
			long now = android.os.SystemClock.uptimeMillis();
			if (mDrawableContainerState.mExitFadeDuration > 0)
			{
				if (mLastDrawable != null)
				{
					mLastDrawable.setVisible(false, false);
				}
				if (mCurrDrawable != null)
				{
					mLastDrawable = mCurrDrawable;
					mExitAnimationEnd = now + mDrawableContainerState.mExitFadeDuration;
				}
				else
				{
					mLastDrawable = null;
					mExitAnimationEnd = 0;
				}
			}
			else
			{
				if (mCurrDrawable != null)
				{
					mCurrDrawable.setVisible(false, false);
				}
			}
			if (idx >= 0 && idx < mDrawableContainerState.mNumChildren)
			{
				android.graphics.drawable.Drawable d = mDrawableContainerState.mDrawables[idx];
				mCurrDrawable = d;
				mCurIndex = idx;
				if (d != null)
				{
					if (mDrawableContainerState.mEnterFadeDuration > 0)
					{
						mEnterAnimationEnd = now + mDrawableContainerState.mEnterFadeDuration;
					}
					else
					{
						d.setAlpha(mAlpha);
					}
					d.setVisible(isVisible(), true);
					d.setDither(mDrawableContainerState.mDither);
					d.setColorFilter(mColorFilter);
					d.setState(getState());
					d.setLevel(getLevel());
					d.setBounds(getBounds());
				}
			}
			else
			{
				mCurrDrawable = null;
				mCurIndex = -1;
			}
			if (mEnterAnimationEnd != 0 || mExitAnimationEnd != 0)
			{
				if (mAnimationRunnable == null)
				{
					mAnimationRunnable = new _Runnable_325(this);
				}
				else
				{
					unscheduleSelf(mAnimationRunnable);
				}
				// Compute first frame and schedule next animation.
				animate(true);
			}
			invalidateSelf();
			return true;
		}

		internal virtual void animate(bool schedule)
		{
			long now = android.os.SystemClock.uptimeMillis();
			bool animating = false;
			if (mCurrDrawable != null)
			{
				if (mEnterAnimationEnd != 0)
				{
					if (mEnterAnimationEnd <= now)
					{
						mCurrDrawable.setAlpha(mAlpha);
						mEnterAnimationEnd = 0;
					}
					else
					{
						int animAlpha = (int)((mEnterAnimationEnd - now) * 255) / mDrawableContainerState
							.mEnterFadeDuration;
						mCurrDrawable.setAlpha(((255 - animAlpha) * mAlpha) / 255);
						animating = true;
					}
				}
			}
			else
			{
				mEnterAnimationEnd = 0;
			}
			if (mLastDrawable != null)
			{
				if (mExitAnimationEnd != 0)
				{
					if (mExitAnimationEnd <= now)
					{
						mLastDrawable.setVisible(false, false);
						mLastDrawable = null;
						mExitAnimationEnd = 0;
					}
					else
					{
						int animAlpha = (int)((mExitAnimationEnd - now) * 255) / mDrawableContainerState.
							mExitFadeDuration;
						mLastDrawable.setAlpha((animAlpha * mAlpha) / 255);
						animating = true;
					}
				}
			}
			else
			{
				mExitAnimationEnd = 0;
			}
			if (schedule && animating)
			{
				scheduleSelf(mAnimationRunnable, now + 1000 / 60);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable getCurrent()
		{
			return mCurrDrawable;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			if (mDrawableContainerState.canConstantState())
			{
				mDrawableContainerState.mChangingConfigurations = getChangingConfigurations();
				return mDrawableContainerState;
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				int N = mDrawableContainerState.getChildCount();
				android.graphics.drawable.Drawable[] drawables = mDrawableContainerState.getChildren
					();
				{
					for (int i = 0; i < N; i++)
					{
						if (drawables[i] != null)
						{
							drawables[i].mutate();
						}
					}
				}
				mMutated = true;
			}
			return this;
		}

		/// <summary>
		/// A ConstantState that can contain several
		/// <see cref="Drawable">Drawable</see>
		/// s.
		/// This class was made public to enable testing, and its visibility may change in a future
		/// release.
		/// </summary>
		public abstract class DrawableContainerState : android.graphics.drawable.Drawable
			.ConstantState
		{
			internal readonly android.graphics.drawable.DrawableContainer mOwner;

			internal int mChangingConfigurations;

			internal int mChildrenChangingConfigurations;

			internal android.graphics.drawable.Drawable[] mDrawables;

			internal int mNumChildren;

			internal bool mVariablePadding = false;

			internal android.graphics.Rect mConstantPadding = null;

			internal bool mConstantSize = false;

			internal bool mComputedConstantSize = false;

			internal int mConstantWidth;

			internal int mConstantHeight;

			internal int mConstantMinimumWidth;

			internal int mConstantMinimumHeight;

			internal bool mHaveOpacity = false;

			internal int mOpacity;

			internal bool mHaveStateful = false;

			internal bool mStateful;

			internal bool mCheckedConstantState;

			internal bool mCanConstantState;

			internal bool mPaddingChecked = false;

			internal bool mDither = DEFAULT_DITHER;

			internal int mEnterFadeDuration;

			internal int mExitFadeDuration;

			internal DrawableContainerState(android.graphics.drawable.DrawableContainer.DrawableContainerState
				 orig, android.graphics.drawable.DrawableContainer owner, android.content.res.Resources
				 res)
			{
				mOwner = owner;
				if (orig != null)
				{
					mChangingConfigurations = orig.mChangingConfigurations;
					mChildrenChangingConfigurations = orig.mChildrenChangingConfigurations;
					android.graphics.drawable.Drawable[] origDr = orig.mDrawables;
					mDrawables = new android.graphics.drawable.Drawable[origDr.Length];
					mNumChildren = orig.mNumChildren;
					int N = mNumChildren;
					{
						for (int i = 0; i < N; i++)
						{
							if (res != null)
							{
								mDrawables[i] = origDr[i].getConstantState().newDrawable(res);
							}
							else
							{
								mDrawables[i] = origDr[i].getConstantState().newDrawable();
							}
							mDrawables[i].setCallback(owner);
						}
					}
					mCheckedConstantState = mCanConstantState = true;
					mVariablePadding = orig.mVariablePadding;
					if (orig.mConstantPadding != null)
					{
						mConstantPadding = new android.graphics.Rect(orig.mConstantPadding);
					}
					mConstantSize = orig.mConstantSize;
					mComputedConstantSize = orig.mComputedConstantSize;
					mConstantWidth = orig.mConstantWidth;
					mConstantHeight = orig.mConstantHeight;
					mHaveOpacity = orig.mHaveOpacity;
					mOpacity = orig.mOpacity;
					mHaveStateful = orig.mHaveStateful;
					mStateful = orig.mStateful;
					mDither = orig.mDither;
					mEnterFadeDuration = orig.mEnterFadeDuration;
					mExitFadeDuration = orig.mExitFadeDuration;
				}
				else
				{
					mDrawables = new android.graphics.drawable.Drawable[10];
					mNumChildren = 0;
					mCheckedConstantState = mCanConstantState = false;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}

			public int addChild(android.graphics.drawable.Drawable dr)
			{
				int pos = mNumChildren;
				if (pos >= mDrawables.Length)
				{
					growArray(pos, pos + 10);
				}
				dr.setVisible(false, true);
				dr.setCallback(mOwner);
				mDrawables[pos] = dr;
				mNumChildren++;
				mChildrenChangingConfigurations |= dr.getChangingConfigurations();
				mHaveOpacity = false;
				mHaveStateful = false;
				mConstantPadding = null;
				mPaddingChecked = false;
				mComputedConstantSize = false;
				return pos;
			}

			public int getChildCount()
			{
				return mNumChildren;
			}

			public android.graphics.drawable.Drawable[] getChildren()
			{
				return mDrawables;
			}

			/// <summary>
			/// A boolean value indicating whether to use the maximum padding value of
			/// all frames in the set (false), or to use the padding value of the frame
			/// being shown (true).
			/// </summary>
			/// <remarks>
			/// A boolean value indicating whether to use the maximum padding value of
			/// all frames in the set (false), or to use the padding value of the frame
			/// being shown (true). Default value is false.
			/// </remarks>
			public void setVariablePadding(bool variable)
			{
				mVariablePadding = variable;
			}

			public android.graphics.Rect getConstantPadding()
			{
				if (mVariablePadding)
				{
					return null;
				}
				if (mConstantPadding != null || mPaddingChecked)
				{
					return mConstantPadding;
				}
				android.graphics.Rect r = null;
				android.graphics.Rect t = new android.graphics.Rect();
				int N = getChildCount();
				android.graphics.drawable.Drawable[] drawables = mDrawables;
				{
					for (int i = 0; i < N; i++)
					{
						if (drawables[i].getPadding(t))
						{
							if (r == null)
							{
								r = new android.graphics.Rect(0, 0, 0, 0);
							}
							if (t.left > r.left)
							{
								r.left = t.left;
							}
							if (t.top > r.top)
							{
								r.top = t.top;
							}
							if (t.right > r.right)
							{
								r.right = t.right;
							}
							if (t.bottom > r.bottom)
							{
								r.bottom = t.bottom;
							}
						}
					}
				}
				mPaddingChecked = true;
				return (mConstantPadding = r);
			}

			public void setConstantSize(bool constant)
			{
				mConstantSize = constant;
			}

			public bool isConstantSize()
			{
				return mConstantSize;
			}

			public int getConstantWidth()
			{
				if (!mComputedConstantSize)
				{
					computeConstantSize();
				}
				return mConstantWidth;
			}

			public int getConstantHeight()
			{
				if (!mComputedConstantSize)
				{
					computeConstantSize();
				}
				return mConstantHeight;
			}

			public int getConstantMinimumWidth()
			{
				if (!mComputedConstantSize)
				{
					computeConstantSize();
				}
				return mConstantMinimumWidth;
			}

			public int getConstantMinimumHeight()
			{
				if (!mComputedConstantSize)
				{
					computeConstantSize();
				}
				return mConstantMinimumHeight;
			}

			protected internal virtual void computeConstantSize()
			{
				mComputedConstantSize = true;
				int N = getChildCount();
				android.graphics.drawable.Drawable[] drawables = mDrawables;
				mConstantWidth = mConstantHeight = -1;
				mConstantMinimumWidth = mConstantMinimumHeight = 0;
				{
					for (int i = 0; i < N; i++)
					{
						android.graphics.drawable.Drawable dr = drawables[i];
						int s = dr.getIntrinsicWidth();
						if (s > mConstantWidth)
						{
							mConstantWidth = s;
						}
						s = dr.getIntrinsicHeight();
						if (s > mConstantHeight)
						{
							mConstantHeight = s;
						}
						s = dr.getMinimumWidth();
						if (s > mConstantMinimumWidth)
						{
							mConstantMinimumWidth = s;
						}
						s = dr.getMinimumHeight();
						if (s > mConstantMinimumHeight)
						{
							mConstantMinimumHeight = s;
						}
					}
				}
			}

			public void setEnterFadeDuration(int duration)
			{
				mEnterFadeDuration = duration;
			}

			public int getEnterFadeDuration()
			{
				return mEnterFadeDuration;
			}

			public void setExitFadeDuration(int duration)
			{
				mExitFadeDuration = duration;
			}

			public int getExitFadeDuration()
			{
				return mExitFadeDuration;
			}

			public int getOpacity()
			{
				if (mHaveOpacity)
				{
					return mOpacity;
				}
				int N = getChildCount();
				android.graphics.drawable.Drawable[] drawables = mDrawables;
				int op = N > 0 ? drawables[0].getOpacity() : android.graphics.PixelFormat.TRANSPARENT;
				{
					for (int i = 1; i < N; i++)
					{
						op = android.graphics.drawable.Drawable.resolveOpacity(op, drawables[i].getOpacity
							());
					}
				}
				mOpacity = op;
				mHaveOpacity = true;
				return op;
			}

			public bool isStateful()
			{
				if (mHaveStateful)
				{
					return mStateful;
				}
				bool stateful = false;
				int N = getChildCount();
				{
					for (int i = 0; i < N; i++)
					{
						if (mDrawables[i].isStateful())
						{
							stateful = true;
							break;
						}
					}
				}
				mStateful = stateful;
				mHaveStateful = true;
				return stateful;
			}

			public virtual void growArray(int oldSize, int newSize)
			{
				android.graphics.drawable.Drawable[] newDrawables = new android.graphics.drawable.Drawable
					[newSize];
				System.Array.Copy(mDrawables, 0, newDrawables, 0, oldSize);
				mDrawables = newDrawables;
			}

			public virtual bool canConstantState()
			{
				lock (this)
				{
					if (!mCheckedConstantState)
					{
						mCanConstantState = true;
						int N = mNumChildren;
						{
							for (int i = 0; i < N; i++)
							{
								if (mDrawables[i].getConstantState() == null)
								{
									mCanConstantState = false;
									break;
								}
							}
						}
						mCheckedConstantState = true;
					}
					return mCanConstantState;
				}
			}
		}

		protected internal virtual void setConstantState(android.graphics.drawable.DrawableContainer
			.DrawableContainerState state)
		{
			mDrawableContainerState = state;
		}
	}
}
