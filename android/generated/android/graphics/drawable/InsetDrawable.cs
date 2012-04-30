using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A Drawable that insets another Drawable by a specified distance.</summary>
	/// <remarks>
	/// A Drawable that insets another Drawable by a specified distance.
	/// This is used when a View needs a background that is smaller than
	/// the View's actual bounds.
	/// <p>It can be defined in an XML file with the <code>&lt;inset&gt;</code> element. For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#InsetDrawable_visible</attr>
	/// <attr>ref android.R.styleable#InsetDrawable_drawable</attr>
	/// <attr>ref android.R.styleable#InsetDrawable_insetLeft</attr>
	/// <attr>ref android.R.styleable#InsetDrawable_insetRight</attr>
	/// <attr>ref android.R.styleable#InsetDrawable_insetTop</attr>
	/// <attr>ref android.R.styleable#InsetDrawable_insetBottom</attr>
	[Sharpen.Sharpened]
	public class InsetDrawable : android.graphics.drawable.Drawable, android.graphics.drawable.Drawable
		.Callback
	{
		private android.graphics.drawable.InsetDrawable.InsetState mInsetState;

		private readonly android.graphics.Rect mTmpRect = new android.graphics.Rect();

		private bool mMutated;

		internal InsetDrawable() : this(null, null)
		{
		}

		public InsetDrawable(android.graphics.drawable.Drawable drawable, int inset) : this
			(drawable, inset, inset, inset, inset)
		{
		}

		public InsetDrawable(android.graphics.drawable.Drawable drawable, int insetLeft, 
			int insetTop, int insetRight, int insetBottom) : this(null, null)
		{
			// Most of this is copied from ScaleDrawable.
			mInsetState.mDrawable = drawable;
			mInsetState.mInsetLeft = insetLeft;
			mInsetState.mInsetTop = insetTop;
			mInsetState.mInsetRight = insetRight;
			mInsetState.mInsetBottom = insetBottom;
			if (drawable != null)
			{
				drawable.setCallback(this);
			}
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			int type;
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.InsetDrawable);
			base.inflateWithAttributes(r, parser, a, android.@internal.R.styleable.InsetDrawable_visible
				);
			int drawableRes = a.getResourceId(android.@internal.R.styleable.InsetDrawable_drawable
				, 0);
			int inLeft = a.getDimensionPixelOffset(android.@internal.R.styleable.InsetDrawable_insetLeft
				, 0);
			int inTop = a.getDimensionPixelOffset(android.@internal.R.styleable.InsetDrawable_insetTop
				, 0);
			int inRight = a.getDimensionPixelOffset(android.@internal.R.styleable.InsetDrawable_insetRight
				, 0);
			int inBottom = a.getDimensionPixelOffset(android.@internal.R.styleable.InsetDrawable_insetBottom
				, 0);
			a.recycle();
			android.graphics.drawable.Drawable dr;
			if (drawableRes != 0)
			{
				dr = r.getDrawable(drawableRes);
			}
			else
			{
				while ((type = parser.next()) == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
				}
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
						 ": <inset> tag requires a 'drawable' attribute or " + "child tag defining a drawable"
						);
				}
				dr = android.graphics.drawable.Drawable.createFromXmlInner(r, parser, attrs);
			}
			if (dr == null)
			{
				android.util.Log.w("drawable", "No drawable specified for <inset>");
			}
			mInsetState.mDrawable = dr;
			mInsetState.mInsetLeft = inLeft;
			mInsetState.mInsetRight = inRight;
			mInsetState.mInsetTop = inTop;
			mInsetState.mInsetBottom = inBottom;
			if (dr != null)
			{
				dr.setCallback(this);
			}
		}

		// overrides from Drawable.Callback
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

		// overrides from Drawable
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			mInsetState.mDrawable.draw(canvas);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mInsetState.mChangingConfigurations | mInsetState
				.mDrawable.getChangingConfigurations();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			bool pad = mInsetState.mDrawable.getPadding(padding);
			padding.left += mInsetState.mInsetLeft;
			padding.right += mInsetState.mInsetRight;
			padding.top += mInsetState.mInsetTop;
			padding.bottom += mInsetState.mInsetBottom;
			if (pad || (mInsetState.mInsetLeft | mInsetState.mInsetRight | mInsetState.mInsetTop
				 | mInsetState.mInsetBottom) != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool setVisible(bool visible, bool restart)
		{
			mInsetState.mDrawable.setVisible(visible, restart);
			return base.setVisible(visible, restart);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			mInsetState.mDrawable.setAlpha(alpha);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			mInsetState.mDrawable.setColorFilter(cf);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			return mInsetState.mDrawable.getOpacity();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return mInsetState.mDrawable.isStateful();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onStateChange(int[] state)
		{
			bool changed = mInsetState.mDrawable.setState(state);
			onBoundsChange(getBounds());
			return changed;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			android.graphics.Rect r = mTmpRect;
			r.set(bounds);
			r.left += mInsetState.mInsetLeft;
			r.top += mInsetState.mInsetTop;
			r.right -= mInsetState.mInsetRight;
			r.bottom -= mInsetState.mInsetBottom;
			mInsetState.mDrawable.setBounds(r.left, r.top, r.right, r.bottom);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mInsetState.mDrawable.getIntrinsicWidth();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mInsetState.mDrawable.getIntrinsicHeight();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			if (mInsetState.canConstantState())
			{
				mInsetState.mChangingConfigurations = getChangingConfigurations();
				return mInsetState;
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mInsetState.mDrawable.mutate();
				mMutated = true;
			}
			return this;
		}

		internal sealed class InsetState : android.graphics.drawable.Drawable.ConstantState
		{
			internal android.graphics.drawable.Drawable mDrawable;

			internal int mChangingConfigurations;

			internal int mInsetLeft;

			internal int mInsetTop;

			internal int mInsetRight;

			internal int mInsetBottom;

			internal bool mCheckedConstantState;

			internal bool mCanConstantState;

			internal InsetState(android.graphics.drawable.InsetDrawable.InsetState orig, android.graphics.drawable.InsetDrawable
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
					mInsetLeft = orig.mInsetLeft;
					mInsetTop = orig.mInsetTop;
					mInsetRight = orig.mInsetRight;
					mInsetBottom = orig.mInsetBottom;
					mCheckedConstantState = mCanConstantState = true;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.InsetDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.InsetDrawable(this, res);
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

		internal InsetDrawable(android.graphics.drawable.InsetDrawable.InsetState state, 
			android.content.res.Resources res)
		{
			mInsetState = new android.graphics.drawable.InsetDrawable.InsetState(state, this, 
				res);
		}
	}
}
