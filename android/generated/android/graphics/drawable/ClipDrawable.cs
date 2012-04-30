using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// A Drawable that clips another Drawable based on this Drawable's current
	/// level value.
	/// </summary>
	/// <remarks>
	/// A Drawable that clips another Drawable based on this Drawable's current
	/// level value.  You can control how much the child Drawable gets clipped in width
	/// and height based on the level, as well as a gravity to control where it is
	/// placed in its overall container.  Most often used to implement things like
	/// progress bars, by increasing the drawable's level with
	/// <see cref="Drawable.setLevel(int)">setLevel()</see>
	/// .
	/// <p class="note"><strong>Note:</strong> The drawable is clipped completely and not visible when
	/// the level is 0 and fully revealed when the level is 10,000.</p>
	/// <p>It can be defined in an XML file with the <code>&lt;clip&gt;</code> element.  For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#ClipDrawable_clipOrientation</attr>
	/// <attr>ref android.R.styleable#ClipDrawable_gravity</attr>
	/// <attr>ref android.R.styleable#ClipDrawable_drawable</attr>
	[Sharpen.Sharpened]
	public class ClipDrawable : android.graphics.drawable.Drawable, android.graphics.drawable.Drawable
		.Callback
	{
		private android.graphics.drawable.ClipDrawable.ClipState mClipState;

		private readonly android.graphics.Rect mTmpRect = new android.graphics.Rect();

		public const int HORIZONTAL = 1;

		public const int VERTICAL = 2;

		internal ClipDrawable() : this(null, null)
		{
		}

		/// <param name="orientation">
		/// Bitwise-or of
		/// <see cref="HORIZONTAL">HORIZONTAL</see>
		/// and/or
		/// <see cref="VERTICAL">VERTICAL</see>
		/// </param>
		public ClipDrawable(android.graphics.drawable.Drawable drawable, int gravity, int
			 orientation) : this(null, null)
		{
			mClipState.mDrawable = drawable;
			mClipState.mGravity = gravity;
			mClipState.mOrientation = orientation;
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
			base.inflate(r, parser, attrs);
			int type;
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.ClipDrawable);
			int orientation = a.getInt(android.@internal.R.styleable.ClipDrawable_clipOrientation
				, HORIZONTAL);
			int g = a.getInt(android.@internal.R.styleable.ClipDrawable_gravity, android.view.Gravity
				.LEFT);
			android.graphics.drawable.Drawable dr = a.getDrawable(android.@internal.R.styleable
				.ClipDrawable_drawable);
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
				throw new System.ArgumentException("No drawable specified for <clip>");
			}
			mClipState.mDrawable = dr;
			mClipState.mOrientation = orientation;
			mClipState.mGravity = g;
			dr.setCallback(this);
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
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mClipState.mChangingConfigurations | mClipState
				.mDrawable.getChangingConfigurations();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			// XXX need to adjust padding!
			return mClipState.mDrawable.getPadding(padding);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool setVisible(bool visible, bool restart)
		{
			mClipState.mDrawable.setVisible(visible, restart);
			return base.setVisible(visible, restart);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			mClipState.mDrawable.setAlpha(alpha);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			mClipState.mDrawable.setColorFilter(cf);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			return mClipState.mDrawable.getOpacity();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return mClipState.mDrawable.isStateful();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onStateChange(int[] state)
		{
			return mClipState.mDrawable.setState(state);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onLevelChange(int level)
		{
			mClipState.mDrawable.setLevel(level);
			invalidateSelf();
			return true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			mClipState.mDrawable.setBounds(bounds);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			if (mClipState.mDrawable.getLevel() == 0)
			{
				return;
			}
			android.graphics.Rect r = mTmpRect;
			android.graphics.Rect bounds = getBounds();
			int level = getLevel();
			int w = bounds.width();
			int iw = 0;
			//mClipState.mDrawable.getIntrinsicWidth();
			if ((mClipState.mOrientation & HORIZONTAL) != 0)
			{
				w -= (w - iw) * (10000 - level) / 10000;
			}
			int h = bounds.height();
			int ih = 0;
			//mClipState.mDrawable.getIntrinsicHeight();
			if ((mClipState.mOrientation & VERTICAL) != 0)
			{
				h -= (h - ih) * (10000 - level) / 10000;
			}
			int layoutDirection = getResolvedLayoutDirectionSelf();
			android.view.Gravity.apply(mClipState.mGravity, w, h, bounds, r, layoutDirection);
			if (w > 0 && h > 0)
			{
				canvas.save();
				canvas.clipRect(r);
				mClipState.mDrawable.draw(canvas);
				canvas.restore();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mClipState.mDrawable.getIntrinsicWidth();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mClipState.mDrawable.getIntrinsicHeight();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			if (mClipState.canConstantState())
			{
				mClipState.mChangingConfigurations = getChangingConfigurations();
				return mClipState;
			}
			return null;
		}

		internal sealed class ClipState : android.graphics.drawable.Drawable.ConstantState
		{
			internal android.graphics.drawable.Drawable mDrawable;

			internal int mChangingConfigurations;

			internal int mOrientation;

			internal int mGravity;

			private bool mCheckedConstantState;

			private bool mCanConstantState;

			internal ClipState(android.graphics.drawable.ClipDrawable.ClipState orig, android.graphics.drawable.ClipDrawable
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
					mOrientation = orig.mOrientation;
					mGravity = orig.mGravity;
					mCheckedConstantState = mCanConstantState = true;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.ClipDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.ClipDrawable(this, res);
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

		internal ClipDrawable(android.graphics.drawable.ClipDrawable.ClipState state, android.content.res.Resources
			 res)
		{
			mClipState = new android.graphics.drawable.ClipDrawable.ClipState(state, this, res
				);
		}
	}
}
