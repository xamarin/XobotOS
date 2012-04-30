using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// A Drawable that changes the size of another Drawable based on its current
	/// level value.
	/// </summary>
	/// <remarks>
	/// A Drawable that changes the size of another Drawable based on its current
	/// level value.  You can control how much the child Drawable changes in width
	/// and height based on the level, as well as a gravity to control where it is
	/// placed in its overall container.  Most often used to implement things like
	/// progress bars.
	/// <p>It can be defined in an XML file with the <code>&lt;scale&gt;</code> element. For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#ScaleDrawable_scaleWidth</attr>
	/// <attr>ref android.R.styleable#ScaleDrawable_scaleHeight</attr>
	/// <attr>ref android.R.styleable#ScaleDrawable_scaleGravity</attr>
	/// <attr>ref android.R.styleable#ScaleDrawable_drawable</attr>
	[Sharpen.Sharpened]
	public class ScaleDrawable : android.graphics.drawable.Drawable, android.graphics.drawable.Drawable
		.Callback
	{
		private android.graphics.drawable.ScaleDrawable.ScaleState mScaleState;

		private bool mMutated;

		private readonly android.graphics.Rect mTmpRect = new android.graphics.Rect();

		internal ScaleDrawable() : this(null, null)
		{
		}

		public ScaleDrawable(android.graphics.drawable.Drawable drawable, int gravity, float
			 scaleWidth, float scaleHeight) : this(null, null)
		{
			mScaleState.mDrawable = drawable;
			mScaleState.mGravity = gravity;
			mScaleState.mScaleWidth = scaleWidth;
			mScaleState.mScaleHeight = scaleHeight;
			if (drawable != null)
			{
				drawable.setCallback(this);
			}
		}

		/// <summary>Returns the drawable scaled by this ScaleDrawable.</summary>
		/// <remarks>Returns the drawable scaled by this ScaleDrawable.</remarks>
		public virtual android.graphics.drawable.Drawable getDrawable()
		{
			return mScaleState.mDrawable;
		}

		private static float getPercent(android.content.res.TypedArray a, int name)
		{
			string s = a.getString(name);
			if (s != null)
			{
				if (s.EndsWith("%"))
				{
					string f = Sharpen.StringHelper.Substring(s, 0, s.Length - 1);
					return float.Parse(f) / 100.0f;
				}
			}
			return -1;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
			int type;
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.ScaleDrawable);
			float sw = getPercent(a, android.@internal.R.styleable.ScaleDrawable_scaleWidth);
			float sh = getPercent(a, android.@internal.R.styleable.ScaleDrawable_scaleHeight);
			int g = a.getInt(android.@internal.R.styleable.ScaleDrawable_scaleGravity, android.view.Gravity
				.LEFT);
			bool min = a.getBoolean(android.@internal.R.styleable.ScaleDrawable_useIntrinsicSizeAsMinimum
				, false);
			android.graphics.drawable.Drawable dr = a.getDrawable(android.@internal.R.styleable
				.ScaleDrawable_drawable);
			a.recycle();
			int outerDepth = parser.getDepth();
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				dr = android.graphics.drawable.Drawable.createFromXmlInner(r, parser, attrs);
			}
			if (dr == null)
			{
				throw new System.ArgumentException("No drawable specified for <scale>");
			}
			mScaleState.mDrawable = dr;
			mScaleState.mScaleWidth = sw;
			mScaleState.mScaleHeight = sh;
			mScaleState.mGravity = g;
			mScaleState.mUseIntrinsicSizeAsMin = min;
			if (dr != null)
			{
				dr.setCallback(this);
			}
		}

		// overrides from Drawable.Callback
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void invalidateDrawable(android.graphics.drawable.Drawable who)
		{
			if (getCallback() != null)
			{
				getCallback().invalidateDrawable(this);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void scheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what, long when)
		{
			if (getCallback() != null)
			{
				getCallback().scheduleDrawable(this, what, when);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void unscheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what)
		{
			if (getCallback() != null)
			{
				getCallback().unscheduleDrawable(this, what);
			}
		}

		// overrides from Drawable
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			if (mScaleState.mDrawable.getLevel() != 0)
			{
				mScaleState.mDrawable.draw(canvas);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mScaleState.mChangingConfigurations | mScaleState
				.mDrawable.getChangingConfigurations();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			// XXX need to adjust padding!
			return mScaleState.mDrawable.getPadding(padding);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool setVisible(bool visible, bool restart)
		{
			mScaleState.mDrawable.setVisible(visible, restart);
			return base.setVisible(visible, restart);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			mScaleState.mDrawable.setAlpha(alpha);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			mScaleState.mDrawable.setColorFilter(cf);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			return mScaleState.mDrawable.getOpacity();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return mScaleState.mDrawable.isStateful();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onStateChange(int[] state)
		{
			bool changed = mScaleState.mDrawable.setState(state);
			onBoundsChange(getBounds());
			return changed;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onLevelChange(int level)
		{
			mScaleState.mDrawable.setLevel(level);
			onBoundsChange(getBounds());
			invalidateSelf();
			return true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			android.graphics.Rect r = mTmpRect;
			bool min = mScaleState.mUseIntrinsicSizeAsMin;
			int level = getLevel();
			int w = bounds.width();
			if (mScaleState.mScaleWidth > 0)
			{
				int iw = min ? mScaleState.mDrawable.getIntrinsicWidth() : 0;
				w -= (int)((w - iw) * (10000 - level) * mScaleState.mScaleWidth / 10000);
			}
			int h = bounds.height();
			if (mScaleState.mScaleHeight > 0)
			{
				int ih = min ? mScaleState.mDrawable.getIntrinsicHeight() : 0;
				h -= (int)((h - ih) * (10000 - level) * mScaleState.mScaleHeight / 10000);
			}
			int layoutDirection = getResolvedLayoutDirectionSelf();
			android.view.Gravity.apply(mScaleState.mGravity, w, h, bounds, r, layoutDirection
				);
			if (w > 0 && h > 0)
			{
				mScaleState.mDrawable.setBounds(r.left, r.top, r.right, r.bottom);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mScaleState.mDrawable.getIntrinsicWidth();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mScaleState.mDrawable.getIntrinsicHeight();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			if (mScaleState.canConstantState())
			{
				mScaleState.mChangingConfigurations = getChangingConfigurations();
				return mScaleState;
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mScaleState.mDrawable.mutate();
				mMutated = true;
			}
			return this;
		}

		internal sealed class ScaleState : android.graphics.drawable.Drawable.ConstantState
		{
			internal android.graphics.drawable.Drawable mDrawable;

			internal int mChangingConfigurations;

			internal float mScaleWidth;

			internal float mScaleHeight;

			internal int mGravity;

			internal bool mUseIntrinsicSizeAsMin;

			private bool mCheckedConstantState;

			private bool mCanConstantState;

			internal ScaleState(android.graphics.drawable.ScaleDrawable.ScaleState orig, android.graphics.drawable.ScaleDrawable
				 owner, android.content.res.Resources res)
			{
				if (orig != null)
				{
					if (res != null)
					{
						mDrawable = orig.mDrawable.getConstantState().newDrawable(res);
					}
					else
					{
						mDrawable = orig.mDrawable.getConstantState().newDrawable();
					}
					mDrawable.setCallback(owner);
					mScaleWidth = orig.mScaleWidth;
					mScaleHeight = orig.mScaleHeight;
					mGravity = orig.mGravity;
					mUseIntrinsicSizeAsMin = orig.mUseIntrinsicSizeAsMin;
					mCheckedConstantState = mCanConstantState = true;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.ScaleDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.ScaleDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}

			internal bool canConstantState()
			{
				if (!mCheckedConstantState)
				{
					mCanConstantState = mDrawable.getConstantState() != null;
					mCheckedConstantState = true;
				}
				return mCanConstantState;
			}
		}

		internal ScaleDrawable(android.graphics.drawable.ScaleDrawable.ScaleState state, 
			android.content.res.Resources res)
		{
			mScaleState = new android.graphics.drawable.ScaleDrawable.ScaleState(state, this, 
				res);
		}
	}
}
