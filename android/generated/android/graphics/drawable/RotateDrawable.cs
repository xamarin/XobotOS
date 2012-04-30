using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// <p>A Drawable that can rotate another Drawable based on the current level
	/// value.
	/// </summary>
	/// <remarks>
	/// <p>A Drawable that can rotate another Drawable based on the current level
	/// value. The start and end angles of rotation can be controlled to map any
	/// circular arc to the level values range.</p>
	/// <p>It can be defined in an XML file with the <code>&lt;rotate&gt;</code> element. For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/animation-resource.html"&gt;Animation Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#RotateDrawable_visible</attr>
	/// <attr>ref android.R.styleable#RotateDrawable_fromDegrees</attr>
	/// <attr>ref android.R.styleable#RotateDrawable_toDegrees</attr>
	/// <attr>ref android.R.styleable#RotateDrawable_pivotX</attr>
	/// <attr>ref android.R.styleable#RotateDrawable_pivotY</attr>
	/// <attr>ref android.R.styleable#RotateDrawable_drawable</attr>
	[Sharpen.Sharpened]
	public class RotateDrawable : android.graphics.drawable.Drawable, android.graphics.drawable.Drawable
		.Callback
	{
		internal const float MAX_LEVEL = 10000.0f;

		private android.graphics.drawable.RotateDrawable.RotateState mState;

		private bool mMutated;

		/// <summary><p>Create a new rotating drawable with an empty state.</p></summary>
		public RotateDrawable() : this(null, null)
		{
		}

		/// <summary><p>Create a new rotating drawable with the specified state.</summary>
		/// <remarks>
		/// <p>Create a new rotating drawable with the specified state. A copy of
		/// this state is used as the internal state for the newly created
		/// drawable.</p>
		/// </remarks>
		/// <param name="rotateState">the state for this drawable</param>
		internal RotateDrawable(android.graphics.drawable.RotateDrawable.RotateState rotateState
			, android.content.res.Resources res)
		{
			mState = new android.graphics.drawable.RotateDrawable.RotateState(rotateState, this
				, res);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			int saveCount = canvas.save();
			android.graphics.Rect bounds = mState.mDrawable.getBounds();
			int w = bounds.right - bounds.left;
			int h = bounds.bottom - bounds.top;
			android.graphics.drawable.RotateDrawable.RotateState st = mState;
			float px = st.mPivotXRel ? (w * st.mPivotX) : st.mPivotX;
			float py = st.mPivotYRel ? (h * st.mPivotY) : st.mPivotY;
			canvas.rotate(st.mCurrentDegrees, px + bounds.left, py + bounds.top);
			st.mDrawable.draw(canvas);
			canvas.restoreToCount(saveCount);
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
		public override bool setVisible(bool visible, bool restart)
		{
			mState.mDrawable.setVisible(visible, restart);
			return base.setVisible(visible, restart);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return mState.mDrawable.isStateful();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onStateChange(int[] state)
		{
			bool changed = mState.mDrawable.setState(state);
			onBoundsChange(getBounds());
			return changed;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onLevelChange(int level)
		{
			mState.mDrawable.setLevel(level);
			onBoundsChange(getBounds());
			mState.mCurrentDegrees = mState.mFromDegrees + (mState.mToDegrees - mState.mFromDegrees
				) * ((float)level / MAX_LEVEL);
			invalidateSelf();
			return true;
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
				styleable.RotateDrawable);
			base.inflateWithAttributes(r, parser, a, android.@internal.R.styleable.RotateDrawable_visible
				);
			android.util.TypedValue tv = a.peekValue(android.@internal.R.styleable.RotateDrawable_pivotX
				);
			bool pivotXRel;
			float pivotX;
			if (tv == null)
			{
				pivotXRel = true;
				pivotX = 0.5f;
			}
			else
			{
				pivotXRel = tv.type == android.util.TypedValue.TYPE_FRACTION;
				pivotX = pivotXRel ? tv.getFraction(1.0f, 1.0f) : tv.getFloat();
			}
			tv = a.peekValue(android.@internal.R.styleable.RotateDrawable_pivotY);
			bool pivotYRel;
			float pivotY;
			if (tv == null)
			{
				pivotYRel = true;
				pivotY = 0.5f;
			}
			else
			{
				pivotYRel = tv.type == android.util.TypedValue.TYPE_FRACTION;
				pivotY = pivotYRel ? tv.getFraction(1.0f, 1.0f) : tv.getFloat();
			}
			float fromDegrees = a.getFloat(android.@internal.R.styleable.RotateDrawable_fromDegrees
				, 0.0f);
			float toDegrees = a.getFloat(android.@internal.R.styleable.RotateDrawable_toDegrees
				, 360.0f);
			int res = a.getResourceId(android.@internal.R.styleable.RotateDrawable_drawable, 
				0);
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
					android.util.Log.w("drawable", "Bad element under <rotate>: " + parser.getName());
				}
			}
			if (drawable == null)
			{
				android.util.Log.w("drawable", "No drawable specified for <rotate>");
			}
			mState.mDrawable = drawable;
			mState.mPivotXRel = pivotXRel;
			mState.mPivotX = pivotX;
			mState.mPivotYRel = pivotYRel;
			mState.mPivotY = pivotY;
			mState.mFromDegrees = mState.mCurrentDegrees = fromDegrees;
			mState.mToDegrees = toDegrees;
			if (drawable != null)
			{
				drawable.setCallback(this);
			}
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

		/// <summary><p>Represents the state of a rotation for a given drawable.</summary>
		/// <remarks>
		/// <p>Represents the state of a rotation for a given drawable. The same
		/// rotate drawable can be invoked with different states to drive several
		/// rotations at the same time.</p>
		/// </remarks>
		internal sealed class RotateState : android.graphics.drawable.Drawable.ConstantState
		{
			internal android.graphics.drawable.Drawable mDrawable;

			internal int mChangingConfigurations;

			internal bool mPivotXRel;

			internal float mPivotX;

			internal bool mPivotYRel;

			internal float mPivotY;

			internal float mFromDegrees;

			internal float mToDegrees;

			internal float mCurrentDegrees;

			private bool mCanConstantState;

			private bool mCheckedConstantState;

			internal RotateState(android.graphics.drawable.RotateDrawable.RotateState source, 
				android.graphics.drawable.RotateDrawable owner, android.content.res.Resources res
				)
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
					mFromDegrees = mCurrentDegrees = source.mFromDegrees;
					mToDegrees = source.mToDegrees;
					mCanConstantState = mCheckedConstantState = true;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.RotateDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.RotateDrawable(this, res);
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
