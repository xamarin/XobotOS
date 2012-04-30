using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A specialized Drawable that fills the Canvas with a specified color.</summary>
	/// <remarks>
	/// A specialized Drawable that fills the Canvas with a specified color.
	/// Note that a ColorDrawable ignores the ColorFilter.
	/// <p>It can be defined in an XML file with the <code>&lt;color&gt;</code> element.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#ColorDrawable_color</attr>
	[Sharpen.Sharpened]
	public class ColorDrawable : android.graphics.drawable.Drawable
	{
		private android.graphics.drawable.ColorDrawable.ColorState mState;

		private readonly android.graphics.Paint mPaint = new android.graphics.Paint();

		/// <summary>Creates a new black ColorDrawable.</summary>
		/// <remarks>Creates a new black ColorDrawable.</remarks>
		public ColorDrawable() : this(null)
		{
		}

		/// <summary>Creates a new ColorDrawable with the specified color.</summary>
		/// <remarks>Creates a new ColorDrawable with the specified color.</remarks>
		/// <param name="color">The color to draw.</param>
		public ColorDrawable(int color) : this(null)
		{
			setColor(color);
		}

		internal ColorDrawable(android.graphics.drawable.ColorDrawable.ColorState state)
		{
			mState = new android.graphics.drawable.ColorDrawable.ColorState(state);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mState.mChangingConfigurations;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			if (((int)(((uint)mState.mUseColor) >> 24)) != 0)
			{
				mPaint.setColor(mState.mUseColor);
				canvas.drawRect(getBounds(), mPaint);
			}
		}

		/// <summary>Gets the drawable's color value.</summary>
		/// <remarks>Gets the drawable's color value.</remarks>
		/// <returns>int The color to draw.</returns>
		public virtual int getColor()
		{
			return mState.mUseColor;
		}

		/// <summary>Sets the drawable's color value.</summary>
		/// <remarks>
		/// Sets the drawable's color value. This action will clobber the results of prior calls to
		/// <see cref="setAlpha(int)">setAlpha(int)</see>
		/// on this object, which side-affected the underlying color.
		/// </remarks>
		/// <param name="color">The color to draw.</param>
		public virtual void setColor(int color)
		{
			if (mState.mBaseColor != color || mState.mUseColor != color)
			{
				invalidateSelf();
				mState.mBaseColor = mState.mUseColor = color;
			}
		}

		/// <summary>Returns the alpha value of this drawable's color.</summary>
		/// <remarks>Returns the alpha value of this drawable's color.</remarks>
		/// <returns>A value between 0 and 255.</returns>
		public virtual int getAlpha()
		{
			return (int)(((uint)mState.mUseColor) >> 24);
		}

		/// <summary>Sets the color's alpha value.</summary>
		/// <remarks>Sets the color's alpha value.</remarks>
		/// <param name="alpha">The alpha value to set, between 0 and 255.</param>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			alpha += alpha >> 7;
			// make it 0..256
			int baseAlpha = (int)(((uint)mState.mBaseColor) >> 24);
			int useAlpha = baseAlpha * alpha >> 8;
			int oldUseColor = mState.mUseColor;
			mState.mUseColor = ((int)(((uint)mState.mBaseColor << 8) >> 8)) | (useAlpha << 24
				);
			if (oldUseColor != mState.mUseColor)
			{
				invalidateSelf();
			}
		}

		/// <summary>Setting a color filter on a ColorDrawable has no effect.</summary>
		/// <remarks>Setting a color filter on a ColorDrawable has no effect.</remarks>
		/// <param name="colorFilter">Ignore.</param>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter colorFilter)
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			switch ((int)(((uint)mState.mUseColor) >> 24))
			{
				case 255:
				{
					return android.graphics.PixelFormat.OPAQUE;
				}

				case 0:
				{
					return android.graphics.PixelFormat.TRANSPARENT;
				}
			}
			return android.graphics.PixelFormat.TRANSLUCENT;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.ColorDrawable);
			int color = mState.mBaseColor;
			color = a.getColor(android.@internal.R.styleable.ColorDrawable_color, color);
			mState.mBaseColor = mState.mUseColor = color;
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			mState.mChangingConfigurations = getChangingConfigurations();
			return mState;
		}

		internal sealed class ColorState : android.graphics.drawable.Drawable.ConstantState
		{
			internal int mBaseColor;

			internal int mUseColor;

			internal int mChangingConfigurations;

			internal ColorState(android.graphics.drawable.ColorDrawable.ColorState state)
			{
				// base color, independent of setAlpha()
				// basecolor modulated by setAlpha()
				if (state != null)
				{
					mBaseColor = state.mBaseColor;
					mUseColor = state.mUseColor;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.ColorDrawable(this);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.ColorDrawable(this);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}
		}
	}
}
