using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A Drawable that wraps a bitmap and can be tiled, stretched, or aligned.</summary>
	/// <remarks>
	/// A Drawable that wraps a bitmap and can be tiled, stretched, or aligned. You can create a
	/// BitmapDrawable from a file path, an input stream, through XML inflation, or from
	/// a
	/// <see cref="android.graphics.Bitmap">android.graphics.Bitmap</see>
	/// object.
	/// <p>It can be defined in an XML file with the <code>&lt;bitmap&gt;</code> element.  For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// <p>
	/// Also see the
	/// <see cref="android.graphics.Bitmap">android.graphics.Bitmap</see>
	/// class, which handles the management and
	/// transformation of raw bitmap graphics, and should be used when drawing to a
	/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
	/// .
	/// </p>
	/// </remarks>
	/// <attr>ref android.R.styleable#BitmapDrawable_src</attr>
	/// <attr>ref android.R.styleable#BitmapDrawable_antialias</attr>
	/// <attr>ref android.R.styleable#BitmapDrawable_filter</attr>
	/// <attr>ref android.R.styleable#BitmapDrawable_dither</attr>
	/// <attr>ref android.R.styleable#BitmapDrawable_gravity</attr>
	/// <attr>ref android.R.styleable#BitmapDrawable_tileMode</attr>
	[Sharpen.Sharpened]
	public class BitmapDrawable : android.graphics.drawable.Drawable
	{
		internal const int DEFAULT_PAINT_FLAGS = android.graphics.Paint.FILTER_BITMAP_FLAG
			 | android.graphics.Paint.DITHER_FLAG;

		private android.graphics.drawable.BitmapDrawable.BitmapState mBitmapState;

		private android.graphics.Bitmap mBitmap;

		private int mTargetDensity;

		private readonly android.graphics.Rect mDstRect = new android.graphics.Rect();

		private bool mApplyGravity;

		private bool mMutated;

		private int mBitmapWidth;

		private int mBitmapHeight;

		/// <summary>Create an empty drawable, not dealing with density.</summary>
		/// <remarks>Create an empty drawable, not dealing with density.</remarks>
		[System.ObsoleteAttribute(@"Use BitmapDrawable(android.content.res.Resources) to ensure that the drawable has correctly set its target density."
			)]
		public BitmapDrawable()
		{
			// Gravity.apply() sets this
			// These are scaled to match the target density.
			mBitmapState = new android.graphics.drawable.BitmapDrawable.BitmapState((android.graphics.Bitmap
				)null);
		}

		/// <summary>
		/// Create an empty drawable, setting initial target density based on
		/// the display metrics of the resources.
		/// </summary>
		/// <remarks>
		/// Create an empty drawable, setting initial target density based on
		/// the display metrics of the resources.
		/// </remarks>
		public BitmapDrawable(android.content.res.Resources res)
		{
			mBitmapState = new android.graphics.drawable.BitmapDrawable.BitmapState((android.graphics.Bitmap
				)null);
			mBitmapState.mTargetDensity = mTargetDensity;
		}

		/// <summary>Create drawable from a bitmap, not dealing with density.</summary>
		/// <remarks>Create drawable from a bitmap, not dealing with density.</remarks>
		[System.ObsoleteAttribute(@"Use BitmapDrawable(android.content.res.Resources, android.graphics.Bitmap) to ensure that the drawable has correctly set its target density."
			)]
		public BitmapDrawable(android.graphics.Bitmap bitmap) : this(new android.graphics.drawable.BitmapDrawable
			.BitmapState(bitmap), null)
		{
		}

		/// <summary>
		/// Create drawable from a bitmap, setting initial target density based on
		/// the display metrics of the resources.
		/// </summary>
		/// <remarks>
		/// Create drawable from a bitmap, setting initial target density based on
		/// the display metrics of the resources.
		/// </remarks>
		public BitmapDrawable(android.content.res.Resources res, android.graphics.Bitmap 
			bitmap) : this(new android.graphics.drawable.BitmapDrawable.BitmapState(bitmap), 
			res)
		{
			mBitmapState.mTargetDensity = mTargetDensity;
		}

		/// <summary>Create a drawable by opening a given file path and decoding the bitmap.</summary>
		/// <remarks>Create a drawable by opening a given file path and decoding the bitmap.</remarks>
		[System.ObsoleteAttribute(@"Use BitmapDrawable(android.content.res.Resources, string) to ensure that the drawable has correctly set its target density."
			)]
		public BitmapDrawable(string filepath) : this(new android.graphics.drawable.BitmapDrawable
			.BitmapState(android.graphics.BitmapFactory.decodeFile(filepath)), null)
		{
			if (mBitmap == null)
			{
				android.util.Log.w("BitmapDrawable", "BitmapDrawable cannot decode " + filepath);
			}
		}

		/// <summary>Create a drawable by opening a given file path and decoding the bitmap.</summary>
		/// <remarks>Create a drawable by opening a given file path and decoding the bitmap.</remarks>
		public BitmapDrawable(android.content.res.Resources res, string filepath) : this(
			new android.graphics.drawable.BitmapDrawable.BitmapState(android.graphics.BitmapFactory
			.decodeFile(filepath)), null)
		{
			mBitmapState.mTargetDensity = mTargetDensity;
			if (mBitmap == null)
			{
				android.util.Log.w("BitmapDrawable", "BitmapDrawable cannot decode " + filepath);
			}
		}

		/// <summary>Create a drawable by decoding a bitmap from the given input stream.</summary>
		/// <remarks>Create a drawable by decoding a bitmap from the given input stream.</remarks>
		[System.ObsoleteAttribute(@"Use BitmapDrawable(android.content.res.Resources, java.io.InputStream) to ensure that the drawable has correctly set its target density."
			)]
		public BitmapDrawable(java.io.InputStream @is) : this(new android.graphics.drawable.BitmapDrawable
			.BitmapState(android.graphics.BitmapFactory.decodeStream(@is)), null)
		{
			if (mBitmap == null)
			{
				android.util.Log.w("BitmapDrawable", "BitmapDrawable cannot decode " + @is);
			}
		}

		/// <summary>Create a drawable by decoding a bitmap from the given input stream.</summary>
		/// <remarks>Create a drawable by decoding a bitmap from the given input stream.</remarks>
		public BitmapDrawable(android.content.res.Resources res, java.io.InputStream @is)
			 : this(new android.graphics.drawable.BitmapDrawable.BitmapState(android.graphics.BitmapFactory
			.decodeStream(@is)), null)
		{
			mBitmapState.mTargetDensity = mTargetDensity;
			if (mBitmap == null)
			{
				android.util.Log.w("BitmapDrawable", "BitmapDrawable cannot decode " + @is);
			}
		}

		/// <summary>Returns the paint used to render this drawable.</summary>
		/// <remarks>Returns the paint used to render this drawable.</remarks>
		public android.graphics.Paint getPaint()
		{
			return mBitmapState.mPaint;
		}

		/// <summary>Returns the bitmap used by this drawable to render.</summary>
		/// <remarks>Returns the bitmap used by this drawable to render. May be null.</remarks>
		public android.graphics.Bitmap getBitmap()
		{
			return mBitmap;
		}

		private void computeBitmapSize()
		{
			mBitmapWidth = mBitmap.getScaledWidth(mTargetDensity);
			mBitmapHeight = mBitmap.getScaledHeight(mTargetDensity);
		}

		private void setBitmap(android.graphics.Bitmap bitmap)
		{
			if (bitmap != mBitmap)
			{
				mBitmap = bitmap;
				if (bitmap != null)
				{
					computeBitmapSize();
				}
				else
				{
					mBitmapWidth = mBitmapHeight = -1;
				}
				invalidateSelf();
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
			if (mTargetDensity != density)
			{
				mTargetDensity = density == 0 ? android.util.DisplayMetrics.DENSITY_DEFAULT : density;
				if (mBitmap != null)
				{
					computeBitmapSize();
				}
				invalidateSelf();
			}
		}

		/// <summary>Get the gravity used to position/stretch the bitmap within its bounds.</summary>
		/// <remarks>
		/// Get the gravity used to position/stretch the bitmap within its bounds.
		/// See android.view.Gravity
		/// </remarks>
		/// <returns>the gravity applied to the bitmap</returns>
		public virtual int getGravity()
		{
			return mBitmapState.mGravity;
		}

		/// <summary>Set the gravity used to position/stretch the bitmap within its bounds.</summary>
		/// <remarks>
		/// Set the gravity used to position/stretch the bitmap within its bounds.
		/// See android.view.Gravity
		/// </remarks>
		/// <param name="gravity">the gravity</param>
		public virtual void setGravity(int gravity)
		{
			if (mBitmapState.mGravity != gravity)
			{
				mBitmapState.mGravity = gravity;
				mApplyGravity = true;
				invalidateSelf();
			}
		}

		/// <summary>Enables or disables anti-aliasing for this drawable.</summary>
		/// <remarks>
		/// Enables or disables anti-aliasing for this drawable. Anti-aliasing affects
		/// the edges of the bitmap only so it applies only when the drawable is rotated.
		/// </remarks>
		/// <param name="aa">True if the bitmap should be anti-aliased, false otherwise.</param>
		public virtual void setAntiAlias(bool aa)
		{
			mBitmapState.mPaint.setAntiAlias(aa);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setFilterBitmap(bool filter)
		{
			mBitmapState.mPaint.setFilterBitmap(filter);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setDither(bool dither)
		{
			mBitmapState.mPaint.setDither(dither);
			invalidateSelf();
		}

		/// <summary>Indicates the repeat behavior of this drawable on the X axis.</summary>
		/// <remarks>Indicates the repeat behavior of this drawable on the X axis.</remarks>
		/// <returns>
		/// 
		/// <see cref="android.graphics.Shader.TileMode.CLAMP">android.graphics.Shader.TileMode.CLAMP
		/// 	</see>
		/// if the bitmap does not repeat,
		/// <see cref="android.graphics.Shader.TileMode.REPEAT">android.graphics.Shader.TileMode.REPEAT
		/// 	</see>
		/// or
		/// <see cref="android.graphics.Shader.TileMode.MIRROR">android.graphics.Shader.TileMode.MIRROR
		/// 	</see>
		/// otherwise.
		/// </returns>
		public virtual android.graphics.Shader.TileMode? getTileModeX()
		{
			return mBitmapState.mTileModeX;
		}

		/// <summary>Indicates the repeat behavior of this drawable on the Y axis.</summary>
		/// <remarks>Indicates the repeat behavior of this drawable on the Y axis.</remarks>
		/// <returns>
		/// 
		/// <see cref="android.graphics.Shader.TileMode.CLAMP">android.graphics.Shader.TileMode.CLAMP
		/// 	</see>
		/// if the bitmap does not repeat,
		/// <see cref="android.graphics.Shader.TileMode.REPEAT">android.graphics.Shader.TileMode.REPEAT
		/// 	</see>
		/// or
		/// <see cref="android.graphics.Shader.TileMode.MIRROR">android.graphics.Shader.TileMode.MIRROR
		/// 	</see>
		/// otherwise.
		/// </returns>
		public virtual android.graphics.Shader.TileMode? getTileModeY()
		{
			return mBitmapState.mTileModeY;
		}

		/// <summary>Sets the repeat behavior of this drawable on the X axis.</summary>
		/// <remarks>
		/// Sets the repeat behavior of this drawable on the X axis. By default, the drawable
		/// does not repeat its bitmap. Using
		/// <see cref="android.graphics.Shader.TileMode.REPEAT">android.graphics.Shader.TileMode.REPEAT
		/// 	</see>
		/// or
		/// <see cref="android.graphics.Shader.TileMode.MIRROR">android.graphics.Shader.TileMode.MIRROR
		/// 	</see>
		/// the bitmap can be repeated (or tiled) if the bitmap
		/// is smaller than this drawable.
		/// </remarks>
		/// <param name="mode">The repeat mode for this drawable.</param>
		/// <seealso cref="setTileModeY(android.graphics.Shader.TileMode)"></seealso>
		/// <seealso cref="setTileModeXY(android.graphics.Shader.TileMode, android.graphics.Shader.TileMode)
		/// 	"></seealso>
		public virtual void setTileModeX(android.graphics.Shader.TileMode? mode)
		{
			setTileModeXY(mode, mBitmapState.mTileModeY);
		}

		/// <summary>Sets the repeat behavior of this drawable on the Y axis.</summary>
		/// <remarks>
		/// Sets the repeat behavior of this drawable on the Y axis. By default, the drawable
		/// does not repeat its bitmap. Using
		/// <see cref="android.graphics.Shader.TileMode.REPEAT">android.graphics.Shader.TileMode.REPEAT
		/// 	</see>
		/// or
		/// <see cref="android.graphics.Shader.TileMode.MIRROR">android.graphics.Shader.TileMode.MIRROR
		/// 	</see>
		/// the bitmap can be repeated (or tiled) if the bitmap
		/// is smaller than this drawable.
		/// </remarks>
		/// <param name="mode">The repeat mode for this drawable.</param>
		/// <seealso cref="setTileModeX(android.graphics.Shader.TileMode)"></seealso>
		/// <seealso cref="setTileModeXY(android.graphics.Shader.TileMode, android.graphics.Shader.TileMode)
		/// 	"></seealso>
		public void setTileModeY(android.graphics.Shader.TileMode? mode)
		{
			setTileModeXY(mBitmapState.mTileModeX, mode);
		}

		/// <summary>Sets the repeat behavior of this drawable on both axis.</summary>
		/// <remarks>
		/// Sets the repeat behavior of this drawable on both axis. By default, the drawable
		/// does not repeat its bitmap. Using
		/// <see cref="android.graphics.Shader.TileMode.REPEAT">android.graphics.Shader.TileMode.REPEAT
		/// 	</see>
		/// or
		/// <see cref="android.graphics.Shader.TileMode.MIRROR">android.graphics.Shader.TileMode.MIRROR
		/// 	</see>
		/// the bitmap can be repeated (or tiled) if the bitmap
		/// is smaller than this drawable.
		/// </remarks>
		/// <param name="xmode">The X repeat mode for this drawable.</param>
		/// <param name="ymode">The Y repeat mode for this drawable.</param>
		/// <seealso cref="setTileModeX(android.graphics.Shader.TileMode)">setTileModeX(android.graphics.Shader.TileMode)
		/// 	</seealso>
		/// <seealso cref="setTileModeY(android.graphics.Shader.TileMode)"></seealso>
		public virtual void setTileModeXY(android.graphics.Shader.TileMode? xmode, android.graphics.Shader.TileMode
			? ymode)
		{
			android.graphics.drawable.BitmapDrawable.BitmapState state = mBitmapState;
			if (state.mTileModeX != xmode || state.mTileModeY != ymode)
			{
				state.mTileModeX = xmode;
				state.mTileModeY = ymode;
				state.mRebuildShader = true;
				invalidateSelf();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mBitmapState.mChangingConfigurations;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			base.onBoundsChange(bounds);
			mApplyGravity = true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			android.graphics.Bitmap bitmap = mBitmap;
			if (bitmap != null)
			{
				android.graphics.drawable.BitmapDrawable.BitmapState state = mBitmapState;
				if (state.mRebuildShader)
				{
					android.graphics.Shader.TileMode? tmx = state.mTileModeX;
					android.graphics.Shader.TileMode? tmy = state.mTileModeY;
					if (tmx == null && tmy == null)
					{
						state.mPaint.setShader(null);
					}
					else
					{
						state.mPaint.setShader(new android.graphics.BitmapShader(bitmap, tmx == null ? android.graphics.Shader.TileMode
							.CLAMP : tmx, tmy == null ? android.graphics.Shader.TileMode.CLAMP : tmy));
					}
					state.mRebuildShader = false;
					copyBounds(mDstRect);
				}
				android.graphics.Shader shader = state.mPaint.getShader();
				if (shader == null)
				{
					if (mApplyGravity)
					{
						int layoutDirection = getResolvedLayoutDirectionSelf();
						android.view.Gravity.apply(state.mGravity, mBitmapWidth, mBitmapHeight, getBounds
							(), mDstRect, layoutDirection);
						mApplyGravity = false;
					}
					canvas.drawBitmap(bitmap, null, mDstRect, state.mPaint);
				}
				else
				{
					if (mApplyGravity)
					{
						copyBounds(mDstRect);
						mApplyGravity = false;
					}
					canvas.drawRect(mDstRect, state.mPaint);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			int oldAlpha = mBitmapState.mPaint.getAlpha();
			if (alpha != oldAlpha)
			{
				mBitmapState.mPaint.setAlpha(alpha);
				invalidateSelf();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			mBitmapState.mPaint.setColorFilter(cf);
			invalidateSelf();
		}

		/// <summary>
		/// A mutable BitmapDrawable still shares its Bitmap with any other Drawable
		/// that comes from the same resource.
		/// </summary>
		/// <remarks>
		/// A mutable BitmapDrawable still shares its Bitmap with any other Drawable
		/// that comes from the same resource.
		/// </remarks>
		/// <returns>This drawable.</returns>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mBitmapState = new android.graphics.drawable.BitmapDrawable.BitmapState(mBitmapState
					);
				mMutated = true;
			}
			return this;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.BitmapDrawable);
			int id = a.getResourceId(android.@internal.R.styleable.BitmapDrawable_src, 0);
			if (id == 0)
			{
				throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
					 ": <bitmap> requires a valid src attribute");
			}
			android.graphics.Bitmap bitmap = android.graphics.BitmapFactory.decodeResource(r, 
				id);
			if (bitmap == null)
			{
				throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
					 ": <bitmap> requires a valid src attribute");
			}
			mBitmapState.mBitmap = bitmap;
			setBitmap(bitmap);
			setTargetDensity(r.getDisplayMetrics());
			android.graphics.Paint paint = mBitmapState.mPaint;
			paint.setAntiAlias(a.getBoolean(android.@internal.R.styleable.BitmapDrawable_antialias
				, paint.isAntiAlias()));
			paint.setFilterBitmap(a.getBoolean(android.@internal.R.styleable.BitmapDrawable_filter
				, paint.isFilterBitmap()));
			paint.setDither(a.getBoolean(android.@internal.R.styleable.BitmapDrawable_dither, 
				paint.isDither()));
			setGravity(a.getInt(android.@internal.R.styleable.BitmapDrawable_gravity, android.view.Gravity
				.FILL));
			int tileMode = a.getInt(android.@internal.R.styleable.BitmapDrawable_tileMode, -1
				);
			if (tileMode != -1)
			{
				switch (tileMode)
				{
					case 0:
					{
						setTileModeXY(android.graphics.Shader.TileMode.CLAMP, android.graphics.Shader.TileMode
							.CLAMP);
						break;
					}

					case 1:
					{
						setTileModeXY(android.graphics.Shader.TileMode.REPEAT, android.graphics.Shader.TileMode
							.REPEAT);
						break;
					}

					case 2:
					{
						setTileModeXY(android.graphics.Shader.TileMode.MIRROR, android.graphics.Shader.TileMode
							.MIRROR);
						break;
					}
				}
			}
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mBitmapWidth;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mBitmapHeight;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			if (mBitmapState.mGravity != android.view.Gravity.FILL)
			{
				return android.graphics.PixelFormat.TRANSLUCENT;
			}
			android.graphics.Bitmap bm = mBitmap;
			return (bm == null || bm.hasAlpha() || mBitmapState.mPaint.getAlpha() < 255) ? android.graphics.PixelFormat
				.TRANSLUCENT : android.graphics.PixelFormat.OPAQUE;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public sealed override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			mBitmapState.mChangingConfigurations = getChangingConfigurations();
			return mBitmapState;
		}

		internal sealed class BitmapState : android.graphics.drawable.Drawable.ConstantState
		{
			internal android.graphics.Bitmap mBitmap;

			internal int mChangingConfigurations;

			internal int mGravity = android.view.Gravity.FILL;

			internal android.graphics.Paint mPaint = new android.graphics.Paint(DEFAULT_PAINT_FLAGS
				);

			internal android.graphics.Shader.TileMode? mTileModeX = null;

			internal android.graphics.Shader.TileMode? mTileModeY = null;

			internal int mTargetDensity = android.util.DisplayMetrics.DENSITY_DEFAULT;

			internal bool mRebuildShader;

			internal BitmapState(android.graphics.Bitmap bitmap)
			{
				mBitmap = bitmap;
			}

			internal BitmapState(android.graphics.drawable.BitmapDrawable.BitmapState bitmapState
				) : this(bitmapState.mBitmap)
			{
				mChangingConfigurations = bitmapState.mChangingConfigurations;
				mGravity = bitmapState.mGravity;
				mTileModeX = bitmapState.mTileModeX;
				mTileModeY = bitmapState.mTileModeY;
				mTargetDensity = bitmapState.mTargetDensity;
				mPaint = new android.graphics.Paint(bitmapState.mPaint);
				mRebuildShader = bitmapState.mRebuildShader;
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.BitmapDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.BitmapDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}
		}

		internal BitmapDrawable(android.graphics.drawable.BitmapDrawable.BitmapState state
			, android.content.res.Resources res)
		{
			mBitmapState = state;
			if (res != null)
			{
				mTargetDensity = res.getDisplayMetrics().densityDpi;
			}
			else
			{
				mTargetDensity = state.mTargetDensity;
			}
			setBitmap(state != null ? state.mBitmap : null);
		}
	}
}
