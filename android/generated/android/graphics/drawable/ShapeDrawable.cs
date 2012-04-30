using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A Drawable object that draws primitive shapes.</summary>
	/// <remarks>
	/// A Drawable object that draws primitive shapes.
	/// A ShapeDrawable takes a
	/// <see cref="android.graphics.drawable.shapes.Shape">android.graphics.drawable.shapes.Shape
	/// 	</see>
	/// object and manages its presence on the screen. If no Shape is given, then
	/// the ShapeDrawable will default to a
	/// <see cref="android.graphics.drawable.shapes.RectShape">android.graphics.drawable.shapes.RectShape
	/// 	</see>
	/// .
	/// <p>This object can be defined in an XML file with the <code>&lt;shape&gt;</code> element.</p>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about how to use ShapeDrawable, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/graphics/2d-graphics.html#shape-drawable"&gt;
	/// Canvas and Drawables</a> document. For more information about defining a ShapeDrawable in
	/// XML, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html#Shape"&gt;Drawable Resources</a>
	/// document.</p></div>
	/// </remarks>
	/// <attr>ref android.R.styleable#ShapeDrawablePadding_left</attr>
	/// <attr>ref android.R.styleable#ShapeDrawablePadding_top</attr>
	/// <attr>ref android.R.styleable#ShapeDrawablePadding_right</attr>
	/// <attr>ref android.R.styleable#ShapeDrawablePadding_bottom</attr>
	/// <attr>ref android.R.styleable#ShapeDrawable_color</attr>
	/// <attr>ref android.R.styleable#ShapeDrawable_width</attr>
	/// <attr>ref android.R.styleable#ShapeDrawable_height</attr>
	[Sharpen.Sharpened]
	public class ShapeDrawable : android.graphics.drawable.Drawable
	{
		private android.graphics.drawable.ShapeDrawable.ShapeState mShapeState;

		private bool mMutated;

		/// <summary>ShapeDrawable constructor.</summary>
		/// <remarks>ShapeDrawable constructor.</remarks>
		public ShapeDrawable() : this((android.graphics.drawable.ShapeDrawable.ShapeState
			)null)
		{
		}

		/// <summary>Creates a ShapeDrawable with a specified Shape.</summary>
		/// <remarks>Creates a ShapeDrawable with a specified Shape.</remarks>
		/// <param name="s">the Shape that this ShapeDrawable should be</param>
		public ShapeDrawable(android.graphics.drawable.shapes.Shape s) : this((android.graphics.drawable.ShapeDrawable
			.ShapeState)null)
		{
			mShapeState.mShape = s;
		}

		internal ShapeDrawable(android.graphics.drawable.ShapeDrawable.ShapeState state)
		{
			mShapeState = new android.graphics.drawable.ShapeDrawable.ShapeState(state);
		}

		/// <summary>Returns the Shape of this ShapeDrawable.</summary>
		/// <remarks>Returns the Shape of this ShapeDrawable.</remarks>
		public virtual android.graphics.drawable.shapes.Shape getShape()
		{
			return mShapeState.mShape;
		}

		/// <summary>Sets the Shape of this ShapeDrawable.</summary>
		/// <remarks>Sets the Shape of this ShapeDrawable.</remarks>
		public virtual void setShape(android.graphics.drawable.shapes.Shape s)
		{
			mShapeState.mShape = s;
			updateShape();
		}

		/// <summary>
		/// Sets a ShaderFactory to which requests for a
		/// <see cref="android.graphics.Shader">android.graphics.Shader</see>
		/// object will be made.
		/// </summary>
		/// <param name="fact">an instance of your ShaderFactory implementation</param>
		public virtual void setShaderFactory(android.graphics.drawable.ShapeDrawable.ShaderFactory
			 fact)
		{
			mShapeState.mShaderFactory = fact;
		}

		/// <summary>
		/// Returns the ShaderFactory used by this ShapeDrawable for requesting a
		/// <see cref="android.graphics.Shader">android.graphics.Shader</see>
		/// .
		/// </summary>
		public virtual android.graphics.drawable.ShapeDrawable.ShaderFactory getShaderFactory
			()
		{
			return mShapeState.mShaderFactory;
		}

		/// <summary>Returns the Paint used to draw the shape.</summary>
		/// <remarks>Returns the Paint used to draw the shape.</remarks>
		public virtual android.graphics.Paint getPaint()
		{
			return mShapeState.mPaint;
		}

		/// <summary>Sets padding for the shape.</summary>
		/// <remarks>Sets padding for the shape.</remarks>
		/// <param name="left">padding for the left side (in pixels)</param>
		/// <param name="top">padding for the top (in pixels)</param>
		/// <param name="right">padding for the right side (in pixels)</param>
		/// <param name="bottom">padding for the bottom (in pixels)</param>
		public virtual void setPadding(int left, int top, int right, int bottom)
		{
			if ((left | top | right | bottom) == 0)
			{
				mShapeState.mPadding = null;
			}
			else
			{
				if (mShapeState.mPadding == null)
				{
					mShapeState.mPadding = new android.graphics.Rect();
				}
				mShapeState.mPadding.set(left, top, right, bottom);
			}
			invalidateSelf();
		}

		/// <summary>Sets padding for this shape, defined by a Rect object.</summary>
		/// <remarks>
		/// Sets padding for this shape, defined by a Rect object.
		/// Define the padding in the Rect object as: left, top, right, bottom.
		/// </remarks>
		public virtual void setPadding(android.graphics.Rect padding)
		{
			if (padding == null)
			{
				mShapeState.mPadding = null;
			}
			else
			{
				if (mShapeState.mPadding == null)
				{
					mShapeState.mPadding = new android.graphics.Rect();
				}
				mShapeState.mPadding.set(padding);
			}
			invalidateSelf();
		}

		/// <summary>Sets the intrinsic (default) width for this shape.</summary>
		/// <remarks>Sets the intrinsic (default) width for this shape.</remarks>
		/// <param name="width">the intrinsic width (in pixels)</param>
		public virtual void setIntrinsicWidth(int width)
		{
			mShapeState.mIntrinsicWidth = width;
			invalidateSelf();
		}

		/// <summary>Sets the intrinsic (default) height for this shape.</summary>
		/// <remarks>Sets the intrinsic (default) height for this shape.</remarks>
		/// <param name="height">the intrinsic height (in pixels)</param>
		public virtual void setIntrinsicHeight(int height)
		{
			mShapeState.mIntrinsicHeight = height;
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mShapeState.mIntrinsicWidth;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mShapeState.mIntrinsicHeight;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			if (mShapeState.mPadding != null)
			{
				padding.set(mShapeState.mPadding);
				return true;
			}
			else
			{
				return base.getPadding(padding);
			}
		}

		private static int modulateAlpha(int paintAlpha, int alpha)
		{
			int scale = alpha + ((int)(((uint)alpha) >> 7));
			// convert to 0..256
			return (int)(((uint)paintAlpha * scale) >> 8);
		}

		/// <summary>
		/// Called from the drawable's draw() method after the canvas has been set
		/// to draw the shape at (0,0).
		/// </summary>
		/// <remarks>
		/// Called from the drawable's draw() method after the canvas has been set
		/// to draw the shape at (0,0). Subclasses can override for special effects
		/// such as multiple layers, stroking, etc.
		/// </remarks>
		protected internal virtual void onDraw(android.graphics.drawable.shapes.Shape shape
			, android.graphics.Canvas canvas, android.graphics.Paint paint)
		{
			shape.draw(canvas, paint);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			android.graphics.Rect r = getBounds();
			android.graphics.Paint paint = mShapeState.mPaint;
			int prevAlpha = paint.getAlpha();
			paint.setAlpha(modulateAlpha(prevAlpha, mShapeState.mAlpha));
			if (mShapeState.mShape != null)
			{
				// need the save both for the translate, and for the (unknown) Shape
				int count = canvas.save();
				canvas.translate(r.left, r.top);
				onDraw(mShapeState.mShape, canvas, paint);
				canvas.restoreToCount(count);
			}
			else
			{
				canvas.drawRect(r, paint);
			}
			// restore
			paint.setAlpha(prevAlpha);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mShapeState.mChangingConfigurations;
		}

		/// <summary>Set the alpha level for this drawable [0..255].</summary>
		/// <remarks>
		/// Set the alpha level for this drawable [0..255]. Note that this drawable
		/// also has a color in its paint, which has an alpha as well. These two
		/// values are automatically combined during drawing. Thus if the color's
		/// alpha is 75% (i.e. 192) and the drawable's alpha is 50% (i.e. 128), then
		/// the combined alpha that will be used during drawing will be 37.5%
		/// (i.e. 96).
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			mShapeState.mAlpha = alpha;
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			mShapeState.mPaint.setColorFilter(cf);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			if (mShapeState.mShape == null)
			{
				android.graphics.Paint p = mShapeState.mPaint;
				if (p.getXfermode() == null)
				{
					int alpha = p.getAlpha();
					if (alpha == 0)
					{
						return android.graphics.PixelFormat.TRANSPARENT;
					}
					if (alpha == 255)
					{
						return android.graphics.PixelFormat.OPAQUE;
					}
				}
			}
			// not sure, so be safe
			return android.graphics.PixelFormat.TRANSLUCENT;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setDither(bool dither)
		{
			mShapeState.mPaint.setDither(dither);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			base.onBoundsChange(bounds);
			updateShape();
		}

		/// <summary>Subclasses override this to parse custom subelements.</summary>
		/// <remarks>
		/// Subclasses override this to parse custom subelements.
		/// If you handle it, return true, else return <em>super.inflateTag(...)</em>.
		/// </remarks>
		protected internal virtual bool inflateTag(string name, android.content.res.Resources
			 r, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs)
		{
			if ("padding".Equals(name))
			{
				android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
					styleable.ShapeDrawablePadding);
				setPadding(a.getDimensionPixelOffset(android.@internal.R.styleable.ShapeDrawablePadding_left
					, 0), a.getDimensionPixelOffset(android.@internal.R.styleable.ShapeDrawablePadding_top
					, 0), a.getDimensionPixelOffset(android.@internal.R.styleable.ShapeDrawablePadding_right
					, 0), a.getDimensionPixelOffset(android.@internal.R.styleable.ShapeDrawablePadding_bottom
					, 0));
				a.recycle();
				return true;
			}
			return false;
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.ShapeDrawable);
			int color = mShapeState.mPaint.getColor();
			color = a.getColor(android.@internal.R.styleable.ShapeDrawable_color, color);
			mShapeState.mPaint.setColor(color);
			bool dither = a.getBoolean(android.@internal.R.styleable.ShapeDrawable_dither, false
				);
			mShapeState.mPaint.setDither(dither);
			setIntrinsicWidth((int)a.getDimension(android.@internal.R.styleable.ShapeDrawable_width
				, 0f));
			setIntrinsicHeight((int)a.getDimension(android.@internal.R.styleable.ShapeDrawable_height
				, 0f));
			a.recycle();
			int type;
			int outerDepth = parser.getDepth();
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				string name = parser.getName();
				// call our subclass
				if (!inflateTag(name, r, parser, attrs))
				{
					android.util.Log.w("drawable", "Unknown element: " + name + " for ShapeDrawable "
						 + this);
				}
			}
		}

		private void updateShape()
		{
			if (mShapeState.mShape != null)
			{
				android.graphics.Rect r = getBounds();
				int w = r.width();
				int h = r.height();
				mShapeState.mShape.resize(w, h);
				if (mShapeState.mShaderFactory != null)
				{
					mShapeState.mPaint.setShader(mShapeState.mShaderFactory.resize(w, h));
				}
			}
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			mShapeState.mChangingConfigurations = getChangingConfigurations();
			return mShapeState;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mShapeState.mPaint = new android.graphics.Paint(mShapeState.mPaint);
				mShapeState.mPadding = new android.graphics.Rect(mShapeState.mPadding);
				mShapeState.mShape = mShapeState.mShape.Clone();
				mMutated = true;
			}
			return this;
		}

		/// <summary>Defines the intrinsic properties of this ShapeDrawable's Shape.</summary>
		/// <remarks>Defines the intrinsic properties of this ShapeDrawable's Shape.</remarks>
		internal sealed class ShapeState : android.graphics.drawable.Drawable.ConstantState
		{
			internal int mChangingConfigurations;

			internal android.graphics.Paint mPaint;

			internal android.graphics.drawable.shapes.Shape mShape;

			internal android.graphics.Rect mPadding;

			internal int mIntrinsicWidth;

			internal int mIntrinsicHeight;

			internal int mAlpha = 255;

			internal android.graphics.drawable.ShapeDrawable.ShaderFactory mShaderFactory;

			internal ShapeState(android.graphics.drawable.ShapeDrawable.ShapeState orig)
			{
				if (orig != null)
				{
					mPaint = orig.mPaint;
					mShape = orig.mShape;
					mPadding = orig.mPadding;
					mIntrinsicWidth = orig.mIntrinsicWidth;
					mIntrinsicHeight = orig.mIntrinsicHeight;
					mAlpha = orig.mAlpha;
					mShaderFactory = orig.mShaderFactory;
				}
				else
				{
					mPaint = new android.graphics.Paint(android.graphics.Paint.ANTI_ALIAS_FLAG);
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.ShapeDrawable(this);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.ShapeDrawable(this);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}
		}

		/// <summary>
		/// Base class defines a factory object that is called each time the drawable
		/// is resized (has a new width or height).
		/// </summary>
		/// <remarks>
		/// Base class defines a factory object that is called each time the drawable
		/// is resized (has a new width or height). Its resize() method returns a
		/// corresponding shader, or null.
		/// Implement this class if you'd like your ShapeDrawable to use a special
		/// <see cref="android.graphics.Shader">android.graphics.Shader</see>
		/// , such as a
		/// <see cref="android.graphics.LinearGradient">android.graphics.LinearGradient</see>
		/// .
		/// </remarks>
		public abstract class ShaderFactory
		{
			/// <summary>Returns the Shader to be drawn when a Drawable is drawn.</summary>
			/// <remarks>
			/// Returns the Shader to be drawn when a Drawable is drawn.
			/// The dimensions of the Drawable are passed because they may be needed
			/// to adjust how the Shader is configured for drawing.
			/// This is called by ShapeDrawable.setShape().
			/// </remarks>
			/// <param name="width">the width of the Drawable being drawn</param>
			/// <param name="height">the heigh of the Drawable being drawn</param>
			/// <returns>the Shader to be drawn</returns>
			public abstract android.graphics.Shader resize(int width, int height);
		}
		// other subclass could wack the Shader's localmatrix based on the
		// resize params (e.g. scaletofit, etc.). This could be used to scale
		// a bitmap to fill the bounds without needing any other special casing.
	}
}
