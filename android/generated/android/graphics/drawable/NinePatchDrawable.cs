using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A resizeable bitmap, with stretchable areas that you define.</summary>
	/// <remarks>
	/// A resizeable bitmap, with stretchable areas that you define. This type of image
	/// is defined in a .png file with a special format.
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about how to use a NinePatchDrawable, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/graphics/2d-graphics.html#nine-patch"&gt;
	/// Canvas and Drawables</a> developer guide. For information about creating a NinePatch image
	/// file using the draw9patch tool, see the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/developing/tools/draw9patch.html"&gt;Draw 9-patch</a> tool guide.</p></div>
	/// </remarks>
	[Sharpen.Sharpened]
	public class NinePatchDrawable : android.graphics.drawable.Drawable
	{
		internal const bool DEFAULT_DITHER = true;

		private android.graphics.drawable.NinePatchDrawable.NinePatchState mNinePatchState;

		private android.graphics.NinePatch mNinePatch;

		private android.graphics.Rect mPadding;

		private android.graphics.Paint mPaint;

		private bool mMutated;

		private int mTargetDensity = android.util.DisplayMetrics.DENSITY_DEFAULT;

		private int mBitmapWidth;

		private int mBitmapHeight;

		internal NinePatchDrawable()
		{
		}

		/// <summary>Create drawable from raw nine-patch data, not dealing with density.</summary>
		/// <remarks>Create drawable from raw nine-patch data, not dealing with density.</remarks>
		[System.ObsoleteAttribute(@"Use NinePatchDrawable(android.content.res.Resources, android.graphics.Bitmap, byte[], android.graphics.Rect, string) to ensure that the drawable has correctly set its target density."
			)]
		public NinePatchDrawable(android.graphics.Bitmap bitmap, byte[] chunk, android.graphics.Rect
			 padding, string srcName) : this(new android.graphics.drawable.NinePatchDrawable
			.NinePatchState(new android.graphics.NinePatch(bitmap, chunk, srcName), padding)
			, null)
		{
		}

		/// <summary>
		/// Create drawable from raw nine-patch data, setting initial target density
		/// based on the display metrics of the resources.
		/// </summary>
		/// <remarks>
		/// Create drawable from raw nine-patch data, setting initial target density
		/// based on the display metrics of the resources.
		/// </remarks>
		public NinePatchDrawable(android.content.res.Resources res, android.graphics.Bitmap
			 bitmap, byte[] chunk, android.graphics.Rect padding, string srcName) : this(new 
			android.graphics.drawable.NinePatchDrawable.NinePatchState(new android.graphics.NinePatch
			(bitmap, chunk, srcName), padding), res)
		{
			// dithering helps a lot, and is pretty cheap, so default is true
			// These are scaled to match the target density.
			mNinePatchState.mTargetDensity = mTargetDensity;
		}

		/// <summary>Create drawable from existing nine-patch, not dealing with density.</summary>
		/// <remarks>Create drawable from existing nine-patch, not dealing with density.</remarks>
		[System.ObsoleteAttribute(@"Use NinePatchDrawable(android.content.res.Resources, android.graphics.NinePatch) to ensure that the drawable has correctly set its target density."
			)]
		public NinePatchDrawable(android.graphics.NinePatch patch) : this(new android.graphics.drawable.NinePatchDrawable
			.NinePatchState(patch, new android.graphics.Rect()), null)
		{
		}

		/// <summary>
		/// Create drawable from existing nine-patch, setting initial target density
		/// based on the display metrics of the resources.
		/// </summary>
		/// <remarks>
		/// Create drawable from existing nine-patch, setting initial target density
		/// based on the display metrics of the resources.
		/// </remarks>
		public NinePatchDrawable(android.content.res.Resources res, android.graphics.NinePatch
			 patch) : this(new android.graphics.drawable.NinePatchDrawable.NinePatchState(patch
			, new android.graphics.Rect()), res)
		{
			mNinePatchState.mTargetDensity = mTargetDensity;
		}

		internal void setNinePatchState(android.graphics.drawable.NinePatchDrawable.NinePatchState
			 state, android.content.res.Resources res)
		{
			mNinePatchState = state;
			mNinePatch = state.mNinePatch;
			mPadding = state.mPadding;
			mTargetDensity = res != null ? res.getDisplayMetrics().densityDpi : state.mTargetDensity;
			//noinspection PointlessBooleanExpression
			if (state.mDither != DEFAULT_DITHER)
			{
				// avoid calling the setter unless we need to, since it does a
				// lazy allocation of a paint
				setDither(state.mDither);
			}
			if (mNinePatch != null)
			{
				computeBitmapSize();
			}
		}

		/// <summary>Set the density scale at which this drawable will be rendered.</summary>
		/// <remarks>
		/// Set the density scale at which this drawable will be rendered. This
		/// method assumes the drawable will be rendered at the same density as the
		/// specified canvas.
		/// </remarks>
		/// <param name="canvas">The Canvas from which the density scale must be obtained.</param>
		/// <seealso cref="android.graphics.Bitmap.setDensity(int)">android.graphics.Bitmap.setDensity(int)
		/// 	</seealso>
		/// <seealso cref="android.graphics.Bitmap.getDensity()">android.graphics.Bitmap.getDensity()
		/// 	</seealso>
		public virtual void setTargetDensity(android.graphics.Canvas canvas)
		{
			setTargetDensity(canvas.getDensity());
		}

		/// <summary>Set the density scale at which this drawable will be rendered.</summary>
		/// <remarks>Set the density scale at which this drawable will be rendered.</remarks>
		/// <param name="metrics">The DisplayMetrics indicating the density scale for this drawable.
		/// 	</param>
		/// <seealso cref="android.graphics.Bitmap.setDensity(int)">android.graphics.Bitmap.setDensity(int)
		/// 	</seealso>
		/// <seealso cref="android.graphics.Bitmap.getDensity()">android.graphics.Bitmap.getDensity()
		/// 	</seealso>
		public virtual void setTargetDensity(android.util.DisplayMetrics metrics)
		{
			setTargetDensity(metrics.densityDpi);
		}

		/// <summary>Set the density at which this drawable will be rendered.</summary>
		/// <remarks>Set the density at which this drawable will be rendered.</remarks>
		/// <param name="density">The density scale for this drawable.</param>
		/// <seealso cref="android.graphics.Bitmap.setDensity(int)">android.graphics.Bitmap.setDensity(int)
		/// 	</seealso>
		/// <seealso cref="android.graphics.Bitmap.getDensity()">android.graphics.Bitmap.getDensity()
		/// 	</seealso>
		public virtual void setTargetDensity(int density)
		{
			if (density != mTargetDensity)
			{
				mTargetDensity = density == 0 ? android.util.DisplayMetrics.DENSITY_DEFAULT : density;
				if (mNinePatch != null)
				{
					computeBitmapSize();
				}
				invalidateSelf();
			}
		}

		private void computeBitmapSize()
		{
			int sdensity = mNinePatch.getDensity();
			int tdensity = mTargetDensity;
			if (sdensity == tdensity)
			{
				mBitmapWidth = mNinePatch.getWidth();
				mBitmapHeight = mNinePatch.getHeight();
			}
			else
			{
				mBitmapWidth = android.graphics.Bitmap.scaleFromDensity(mNinePatch.getWidth(), sdensity
					, tdensity);
				mBitmapHeight = android.graphics.Bitmap.scaleFromDensity(mNinePatch.getHeight(), 
					sdensity, tdensity);
				if (mNinePatchState.mPadding != null && mPadding != null)
				{
					android.graphics.Rect dest = mPadding;
					android.graphics.Rect src = mNinePatchState.mPadding;
					if (dest == src)
					{
						mPadding = dest = new android.graphics.Rect(src);
					}
					dest.left = android.graphics.Bitmap.scaleFromDensity(src.left, sdensity, tdensity
						);
					dest.top = android.graphics.Bitmap.scaleFromDensity(src.top, sdensity, tdensity);
					dest.right = android.graphics.Bitmap.scaleFromDensity(src.right, sdensity, tdensity
						);
					dest.bottom = android.graphics.Bitmap.scaleFromDensity(src.bottom, sdensity, tdensity
						);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			mNinePatch.draw(canvas, getBounds(), mPaint);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mNinePatchState.mChangingConfigurations;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			padding.set(mPadding);
			return true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			getPaint().setAlpha(alpha);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			getPaint().setColorFilter(cf);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setDither(bool dither)
		{
			getPaint().setDither(dither);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setFilterBitmap(bool filter)
		{
			getPaint().setFilterBitmap(filter);
			invalidateSelf();
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.NinePatchDrawable);
			int id = a.getResourceId(android.@internal.R.styleable.NinePatchDrawable_src, 0);
			if (id == 0)
			{
				throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
					 ": <nine-patch> requires a valid src attribute");
			}
			bool dither = a.getBoolean(android.@internal.R.styleable.NinePatchDrawable_dither
				, DEFAULT_DITHER);
			android.graphics.BitmapFactory.Options options = new android.graphics.BitmapFactory
				.Options();
			if (dither)
			{
				options.inDither = false;
			}
			options.inScreenDensity = android.util.DisplayMetrics.DENSITY_DEVICE;
			android.graphics.Rect padding = new android.graphics.Rect();
			android.graphics.Bitmap bitmap = null;
			try
			{
				android.util.TypedValue value = new android.util.TypedValue();
				java.io.InputStream @is = r.openRawResource(id, value);
				bitmap = android.graphics.BitmapFactory.decodeResourceStream(r, value, @is, padding
					, options);
				@is.close();
			}
			catch (System.IO.IOException)
			{
			}
			// Ignore
			if (bitmap == null)
			{
				throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
					 ": <nine-patch> requires a valid src attribute");
			}
			else
			{
				if (bitmap.getNinePatchChunk() == null)
				{
					throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
						 ": <nine-patch> requires a valid 9-patch source image");
				}
			}
			setNinePatchState(new android.graphics.drawable.NinePatchDrawable.NinePatchState(
				new android.graphics.NinePatch(bitmap, bitmap.getNinePatchChunk(), "XML 9-patch"
				), padding, dither), r);
			mNinePatchState.mTargetDensity = mTargetDensity;
			a.recycle();
		}

		public virtual android.graphics.Paint getPaint()
		{
			if (mPaint == null)
			{
				mPaint = new android.graphics.Paint();
				mPaint.setDither(DEFAULT_DITHER);
			}
			return mPaint;
		}

		/// <summary>Retrieves the width of the source .png file (before resizing).</summary>
		/// <remarks>Retrieves the width of the source .png file (before resizing).</remarks>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mBitmapWidth;
		}

		/// <summary>Retrieves the height of the source .png file (before resizing).</summary>
		/// <remarks>Retrieves the height of the source .png file (before resizing).</remarks>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mBitmapHeight;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getMinimumWidth()
		{
			return mBitmapWidth;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getMinimumHeight()
		{
			return mBitmapHeight;
		}

		/// <summary>
		/// Returns a
		/// <see cref="android.graphics.PixelFormat">graphics.PixelFormat</see>
		/// value of OPAQUE or TRANSLUCENT.
		/// </summary>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			return mNinePatch.hasAlpha() || (mPaint != null && mPaint.getAlpha() < 255) ? android.graphics.PixelFormat
				.TRANSLUCENT : android.graphics.PixelFormat.OPAQUE;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.Region getTransparentRegion()
		{
			return mNinePatch.getTransparentRegion(getBounds());
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			mNinePatchState.mChangingConfigurations = getChangingConfigurations();
			return mNinePatchState;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mNinePatchState = new android.graphics.drawable.NinePatchDrawable.NinePatchState(
					mNinePatchState);
				mNinePatch = mNinePatchState.mNinePatch;
				mMutated = true;
			}
			return this;
		}

		internal sealed class NinePatchState : android.graphics.drawable.Drawable.ConstantState
		{
			internal readonly android.graphics.NinePatch mNinePatch;

			internal readonly android.graphics.Rect mPadding;

			internal readonly bool mDither;

			internal int mChangingConfigurations;

			internal int mTargetDensity = android.util.DisplayMetrics.DENSITY_DEFAULT;

			internal NinePatchState(android.graphics.NinePatch ninePatch, android.graphics.Rect
				 padding) : this(ninePatch, padding, DEFAULT_DITHER)
			{
			}

			internal NinePatchState(android.graphics.NinePatch ninePatch, android.graphics.Rect
				 rect, bool dither)
			{
				mNinePatch = ninePatch;
				mPadding = rect;
				mDither = dither;
			}

			internal NinePatchState(android.graphics.drawable.NinePatchDrawable.NinePatchState
				 state)
			{
				mNinePatch = new android.graphics.NinePatch(state.mNinePatch);
				// Note we don't copy the padding because it is immutable.
				mPadding = state.mPadding;
				mDither = state.mDither;
				mChangingConfigurations = state.mChangingConfigurations;
				mTargetDensity = state.mTargetDensity;
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.NinePatchDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.NinePatchDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}
		}

		internal NinePatchDrawable(android.graphics.drawable.NinePatchDrawable.NinePatchState
			 state, android.content.res.Resources res)
		{
			setNinePatchState(state, res);
		}
	}
}
