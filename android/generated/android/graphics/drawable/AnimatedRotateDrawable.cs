using Sharpen;

namespace android.graphics.drawable
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class AnimatedRotateDrawable : android.graphics.drawable.Drawable, android.graphics.drawable.Drawable
		.Callback, java.lang.Runnable, android.graphics.drawable.Animatable
	{
		private android.graphics.drawable.AnimatedRotateDrawable.AnimatedRotateState mState;

		private bool mMutated;

		private float mCurrentDegrees;

		private float mIncrement;

		private bool mRunning;

		public AnimatedRotateDrawable() : this(null, null)
		{
		}

		internal AnimatedRotateDrawable(android.graphics.drawable.AnimatedRotateDrawable.
			AnimatedRotateState rotateState, android.content.res.Resources res)
		{
			mState = new android.graphics.drawable.AnimatedRotateDrawable.AnimatedRotateState
				(rotateState, this, res);
			init();
		}

		private void init()
		{
			android.graphics.drawable.AnimatedRotateDrawable.AnimatedRotateState state = mState;
			mIncrement = 360.0f / state.mFramesCount;
			android.graphics.drawable.Drawable drawable = state.mDrawable;
			if (drawable != null)
			{
				drawable.setFilterBitmap(true);
				if (drawable is android.graphics.drawable.BitmapDrawable)
				{
					((android.graphics.drawable.BitmapDrawable)drawable).setAntiAlias(true);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			int saveCount = canvas.save();
			android.graphics.drawable.AnimatedRotateDrawable.AnimatedRotateState st = mState;
			android.graphics.drawable.Drawable drawable = st.mDrawable;
			android.graphics.Rect bounds = drawable.getBounds();
			int w = bounds.right - bounds.left;
			int h = bounds.bottom - bounds.top;
			float px = st.mPivotXRel ? (w * st.mPivotX) : st.mPivotX;
			float py = st.mPivotYRel ? (h * st.mPivotY) : st.mPivotY;
			canvas.rotate(mCurrentDegrees, px + bounds.left, py + bounds.top);
			drawable.draw(canvas);
			canvas.restoreToCount(saveCount);
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Animatable")]
		public virtual void start()
		{
			if (!mRunning)
			{
				mRunning = true;
				nextFrame();
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Animatable")]
		public virtual void stop()
		{
			mRunning = false;
			unscheduleSelf(this);
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Animatable")]
		public virtual bool isRunning()
		{
			return mRunning;
		}

		private void nextFrame()
		{
			unscheduleSelf(this);
			scheduleSelf(this, android.os.SystemClock.uptimeMillis() + mState.mFrameDuration);
		}

		[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
		public virtual void run()
		{
			// TODO: This should be computed in draw(Canvas), based on the amount
			// of time since the last frame drawn 
			mCurrentDegrees += mIncrement;
			if (mCurrentDegrees > (360.0f - mIncrement))
			{
				mCurrentDegrees = 0.0f;
			}
			invalidateSelf();
			nextFrame();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool setVisible(bool visible, bool restart)
		{
			mState.mDrawable.setVisible(visible, restart);
			bool changed = base.setVisible(visible, restart);
			if (visible)
			{
				if (changed || restart)
				{
					mCurrentDegrees = 0.0f;
					nextFrame();
				}
			}
			else
			{
				unscheduleSelf(this);
			}
			return changed;
		}

		/// <summary>Returns the drawable rotated by this RotateDrawable.</summary>
		/// <remarks>Returns the drawable rotated by this RotateDrawable.</remarks>
		public virtual android.graphics.drawable.Drawable getDrawable()
		{
			return mState.mDrawable;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mState.mChangingConfigurations | mState
				.mDrawable.getChangingConfigurations();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			mState.mDrawable.setAlpha(alpha);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			mState.mDrawable.setColorFilter(cf);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			return mState.mDrawable.getOpacity();
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void invalidateDrawable(android.graphics.drawable.Drawable who)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.invalidateDrawable(this);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void scheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what, long when)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.scheduleDrawable(this, what, when);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void unscheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.unscheduleDrawable(this, what);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			return mState.mDrawable.getPadding(padding);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return mState.mDrawable.isStateful();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			mState.mDrawable.setBounds(bounds.left, bounds.top, bounds.right, bounds.bottom);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mState.mDrawable.getIntrinsicWidth();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mState.mDrawable.getIntrinsicHeight();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			if (mState.canConstantState())
			{
				mState.mChangingConfigurations = getChangingConfigurations();
				return mState;
			}
			return null;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.AnimatedRotateDrawable);
			base.inflateWithAttributes(r, parser, a, android.@internal.R.styleable.AnimatedRotateDrawable_visible
				);
			android.util.TypedValue tv = a.peekValue(android.@internal.R.styleable.AnimatedRotateDrawable_pivotX
				);
			bool pivotXRel = tv.type == android.util.TypedValue.TYPE_FRACTION;
			float pivotX = pivotXRel ? tv.getFraction(1.0f, 1.0f) : tv.getFloat();
			tv = a.peekValue(android.@internal.R.styleable.AnimatedRotateDrawable_pivotY);
			bool pivotYRel = tv.type == android.util.TypedValue.TYPE_FRACTION;
			float pivotY = pivotYRel ? tv.getFraction(1.0f, 1.0f) : tv.getFloat();
			setFramesCount(a.getInt(android.@internal.R.styleable.AnimatedRotateDrawable_framesCount
				, 12));
			setFramesDuration(a.getInt(android.@internal.R.styleable.AnimatedRotateDrawable_frameDuration
				, 150));
			int res = a.getResourceId(android.@internal.R.styleable.AnimatedRotateDrawable_drawable
				, 0);
			android.graphics.drawable.Drawable drawable = null;
			if (res > 0)
			{
				drawable = r.getDrawable(res);
			}
			a.recycle();
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				if ((drawable = android.graphics.drawable.Drawable.createFromXmlInner(r, parser, 
					attrs)) == null)
				{
					android.util.Log.w("drawable", "Bad element under <animated-rotate>: " + parser.getName
						());
				}
			}
			if (drawable == null)
			{
				android.util.Log.w("drawable", "No drawable specified for <animated-rotate>");
			}
			android.graphics.drawable.AnimatedRotateDrawable.AnimatedRotateState rotateState = 
				mState;
			rotateState.mDrawable = drawable;
			rotateState.mPivotXRel = pivotXRel;
			rotateState.mPivotX = pivotX;
			rotateState.mPivotYRel = pivotYRel;
			rotateState.mPivotY = pivotY;
			init();
			if (drawable != null)
			{
				drawable.setCallback(this);
			}
		}

		public virtual void setFramesCount(int framesCount)
		{
			mState.mFramesCount = framesCount;
			mIncrement = 360.0f / mState.mFramesCount;
		}

		public virtual void setFramesDuration(int framesDuration)
		{
			mState.mFrameDuration = framesDuration;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mState.mDrawable.mutate();
				mMutated = true;
			}
			return this;
		}

		internal sealed class AnimatedRotateState : android.graphics.drawable.Drawable.ConstantState
		{
			internal android.graphics.drawable.Drawable mDrawable;

			internal int mChangingConfigurations;

			internal bool mPivotXRel;

			internal float mPivotX;

			internal bool mPivotYRel;

			internal float mPivotY;

			internal int mFrameDuration;

			internal int mFramesCount;

			private bool mCanConstantState;

			private bool mCheckedConstantState;

			internal AnimatedRotateState(android.graphics.drawable.AnimatedRotateDrawable.AnimatedRotateState
				 source, android.graphics.drawable.AnimatedRotateDrawable owner, android.content.res.Resources
				 res)
			{
				if (source != null)
				{
					if (res != null)
					{
						mDrawable = source.mDrawable.getConstantState().newDrawable(res);
					}
					else
					{
						mDrawable = source.mDrawable.getConstantState().newDrawable();
					}
					mDrawable.setCallback(owner);
					mPivotXRel = source.mPivotXRel;
					mPivotX = source.mPivotX;
					mPivotYRel = source.mPivotYRel;
					mPivotY = source.mPivotY;
					mFramesCount = source.mFramesCount;
					mFrameDuration = source.mFrameDuration;
					mCanConstantState = mCheckedConstantState = true;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.AnimatedRotateDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.AnimatedRotateDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}

			public bool canConstantState()
			{
				if (!mCheckedConstantState)
				{
					mCanConstantState = mDrawable.getConstantState() != null;
					mCheckedConstantState = true;
				}
				return mCanConstantState;
			}
		}
	}
}
