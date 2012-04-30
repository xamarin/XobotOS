using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A Drawable with a color gradient for buttons, backgrounds, etc.</summary>
	/// <remarks>
	/// A Drawable with a color gradient for buttons, backgrounds, etc.
	/// <p>It can be defined in an XML file with the <code>&lt;shape&gt;</code> element. For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#GradientDrawable_visible</attr>
	/// <attr>ref android.R.styleable#GradientDrawable_shape</attr>
	/// <attr>ref android.R.styleable#GradientDrawable_innerRadiusRatio</attr>
	/// <attr>ref android.R.styleable#GradientDrawable_innerRadius</attr>
	/// <attr>ref android.R.styleable#GradientDrawable_thicknessRatio</attr>
	/// <attr>ref android.R.styleable#GradientDrawable_thickness</attr>
	/// <attr>ref android.R.styleable#GradientDrawable_useLevel</attr>
	/// <attr>ref android.R.styleable#GradientDrawableSize_width</attr>
	/// <attr>ref android.R.styleable#GradientDrawableSize_height</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_startColor</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_centerColor</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_endColor</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_useLevel</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_angle</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_type</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_centerX</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_centerY</attr>
	/// <attr>ref android.R.styleable#GradientDrawableGradient_gradientRadius</attr>
	/// <attr>ref android.R.styleable#GradientDrawableSolid_color</attr>
	/// <attr>ref android.R.styleable#GradientDrawableStroke_width</attr>
	/// <attr>ref android.R.styleable#GradientDrawableStroke_color</attr>
	/// <attr>ref android.R.styleable#GradientDrawableStroke_dashWidth</attr>
	/// <attr>ref android.R.styleable#GradientDrawableStroke_dashGap</attr>
	/// <attr>ref android.R.styleable#GradientDrawablePadding_left</attr>
	/// <attr>ref android.R.styleable#GradientDrawablePadding_top</attr>
	/// <attr>ref android.R.styleable#GradientDrawablePadding_right</attr>
	/// <attr>ref android.R.styleable#GradientDrawablePadding_bottom</attr>
	[Sharpen.Sharpened]
	public class GradientDrawable : android.graphics.drawable.Drawable
	{
		/// <summary>Shape is a rectangle, possibly with rounded corners</summary>
		public const int RECTANGLE = 0;

		/// <summary>Shape is an ellipse</summary>
		public const int OVAL = 1;

		/// <summary>Shape is a line</summary>
		public const int LINE = 2;

		/// <summary>Shape is a ring.</summary>
		/// <remarks>Shape is a ring.</remarks>
		public const int RING = 3;

		/// <summary>Gradient is linear (default.)</summary>
		public const int LINEAR_GRADIENT = 0;

		/// <summary>Gradient is circular.</summary>
		/// <remarks>Gradient is circular.</remarks>
		public const int RADIAL_GRADIENT = 1;

		/// <summary>Gradient is a sweep.</summary>
		/// <remarks>Gradient is a sweep.</remarks>
		public const int SWEEP_GRADIENT = 2;

		private android.graphics.drawable.GradientDrawable.GradientState mGradientState;

		private readonly android.graphics.Paint mFillPaint = new android.graphics.Paint(android.graphics.Paint
			.ANTI_ALIAS_FLAG);

		private android.graphics.Rect mPadding;

		private android.graphics.Paint mStrokePaint;

		private android.graphics.ColorFilter mColorFilter;

		private int mAlpha = unchecked((int)(0xFF));

		private bool mDither;

		private readonly android.graphics.Path mPath = new android.graphics.Path();

		private readonly android.graphics.RectF mRect = new android.graphics.RectF();

		private android.graphics.Paint mLayerPaint;

		private bool mRectIsDirty;

		private bool mMutated;

		private android.graphics.Path mRingPath;

		private bool mPathIsDirty = true;

		/// <summary>Controls how the gradient is oriented relative to the drawable's bounds</summary>
		public enum Orientation
		{
			/// <summary>draw the gradient from the top to the bottom</summary>
			TOP_BOTTOM,
			/// <summary>draw the gradient from the top-right to the bottom-left</summary>
			TR_BL,
			/// <summary>draw the gradient from the right to the left</summary>
			RIGHT_LEFT,
			/// <summary>draw the gradient from the bottom-right to the top-left</summary>
			BR_TL,
			/// <summary>draw the gradient from the bottom to the top</summary>
			BOTTOM_TOP,
			/// <summary>draw the gradient from the bottom-left to the top-right</summary>
			BL_TR,
			/// <summary>draw the gradient from the left to the right</summary>
			LEFT_RIGHT,
			/// <summary>draw the gradient from the top-left to the bottom-right</summary>
			TL_BR
		}

		public GradientDrawable() : this(new android.graphics.drawable.GradientDrawable.GradientState
			(android.graphics.drawable.GradientDrawable.Orientation.TOP_BOTTOM, null))
		{
		}

		/// <summary>
		/// Create a new gradient drawable given an orientation and an array
		/// of colors for the gradient.
		/// </summary>
		/// <remarks>
		/// Create a new gradient drawable given an orientation and an array
		/// of colors for the gradient.
		/// </remarks>
		public GradientDrawable(android.graphics.drawable.GradientDrawable.Orientation orientation
			, int[] colors) : this(new android.graphics.drawable.GradientDrawable.GradientState
			(orientation, colors))
		{
		}

		// optional, set by the caller
		// optional, set by the caller
		// modified by the caller
		// internal, used if we use saveLayer()
		// internal state
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			if (mPadding != null)
			{
				padding.set(mPadding);
				return true;
			}
			else
			{
				return base.getPadding(padding);
			}
		}

		/// <summary>Specify radii for each of the 4 corners.</summary>
		/// <remarks>
		/// Specify radii for each of the 4 corners. For each corner, the array
		/// contains 2 values, [X_radius, Y_radius]. The corners are ordered
		/// top-left, top-right, bottom-right, bottom-left
		/// </remarks>
		public virtual void setCornerRadii(float[] radii)
		{
			mGradientState.setCornerRadii(radii);
			mPathIsDirty = true;
			invalidateSelf();
		}

		/// <summary>Specify radius for the corners of the gradient.</summary>
		/// <remarks>
		/// Specify radius for the corners of the gradient. If this is &gt; 0, then the
		/// drawable is drawn in a round-rectangle, rather than a rectangle.
		/// </remarks>
		public virtual void setCornerRadius(float radius)
		{
			mGradientState.setCornerRadius(radius);
			mPathIsDirty = true;
			invalidateSelf();
		}

		/// <summary>Set the stroke width and color for the drawable.</summary>
		/// <remarks>
		/// Set the stroke width and color for the drawable. If width is zero,
		/// then no stroke is drawn.
		/// </remarks>
		public virtual void setStroke(int width, int color)
		{
			setStroke(width, color, 0, 0);
		}

		public virtual void setStroke(int width, int color, float dashWidth, float dashGap
			)
		{
			mGradientState.setStroke(width, color, dashWidth, dashGap);
			if (mStrokePaint == null)
			{
				mStrokePaint = new android.graphics.Paint(android.graphics.Paint.ANTI_ALIAS_FLAG);
				mStrokePaint.setStyle(android.graphics.Paint.Style.STROKE);
			}
			mStrokePaint.setStrokeWidth(width);
			mStrokePaint.setColor(color);
			android.graphics.DashPathEffect e = null;
			if (dashWidth > 0)
			{
				e = new android.graphics.DashPathEffect(new float[] { dashWidth, dashGap }, 0);
			}
			mStrokePaint.setPathEffect(e);
			invalidateSelf();
		}

		public virtual void setSize(int width, int height)
		{
			mGradientState.setSize(width, height);
			mPathIsDirty = true;
			invalidateSelf();
		}

		public virtual void setShape(int shape)
		{
			mRingPath = null;
			mPathIsDirty = true;
			mGradientState.setShape(shape);
			invalidateSelf();
		}

		public virtual void setGradientType(int gradient)
		{
			mGradientState.setGradientType(gradient);
			mRectIsDirty = true;
			invalidateSelf();
		}

		public virtual void setGradientCenter(float x, float y)
		{
			mGradientState.setGradientCenter(x, y);
			mRectIsDirty = true;
			invalidateSelf();
		}

		public virtual void setGradientRadius(float gradientRadius)
		{
			mGradientState.setGradientRadius(gradientRadius);
			mRectIsDirty = true;
			invalidateSelf();
		}

		public virtual void setUseLevel(bool useLevel)
		{
			mGradientState.mUseLevel = useLevel;
			mRectIsDirty = true;
			invalidateSelf();
		}

		private int modulateAlpha(int alpha)
		{
			int scale = mAlpha + (mAlpha >> 7);
			return alpha * scale >> 8;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			if (!ensureValidRect())
			{
				// nothing to draw
				return;
			}
			// remember the alpha values, in case we temporarily overwrite them
			// when we modulate them with mAlpha
			int prevFillAlpha = mFillPaint.getAlpha();
			int prevStrokeAlpha = mStrokePaint != null ? mStrokePaint.getAlpha() : 0;
			// compute the modulate alpha values
			int currFillAlpha = modulateAlpha(prevFillAlpha);
			int currStrokeAlpha = modulateAlpha(prevStrokeAlpha);
			bool haveStroke = currStrokeAlpha > 0 && mStrokePaint.getStrokeWidth() > 0;
			bool haveFill = currFillAlpha > 0;
			android.graphics.drawable.GradientDrawable.GradientState st = mGradientState;
			bool useLayer = haveStroke && haveFill && st.mShape != LINE && currStrokeAlpha < 
				255 && (mAlpha < 255 || mColorFilter != null);
			if (useLayer)
			{
				if (mLayerPaint == null)
				{
					mLayerPaint = new android.graphics.Paint();
				}
				mLayerPaint.setDither(mDither);
				mLayerPaint.setAlpha(mAlpha);
				mLayerPaint.setColorFilter(mColorFilter);
				float rad = mStrokePaint.getStrokeWidth();
				canvas.saveLayer(mRect.left - rad, mRect.top - rad, mRect.right + rad, mRect.bottom
					 + rad, mLayerPaint, android.graphics.Canvas.HAS_ALPHA_LAYER_SAVE_FLAG);
				// don't perform the filter in our individual paints
				// since the layer will do it for us
				mFillPaint.setColorFilter(null);
				mStrokePaint.setColorFilter(null);
			}
			else
			{
				mFillPaint.setAlpha(currFillAlpha);
				mFillPaint.setDither(mDither);
				mFillPaint.setColorFilter(mColorFilter);
				if (haveStroke)
				{
					mStrokePaint.setAlpha(currStrokeAlpha);
					mStrokePaint.setDither(mDither);
					mStrokePaint.setColorFilter(mColorFilter);
				}
			}
			switch (st.mShape)
			{
				case RECTANGLE:
				{
					if (st.mRadiusArray != null)
					{
						if (mPathIsDirty || mRectIsDirty)
						{
							mPath.reset();
							mPath.addRoundRect(mRect, st.mRadiusArray, android.graphics.Path.Direction.CW);
							mPathIsDirty = mRectIsDirty = false;
						}
						canvas.drawPath(mPath, mFillPaint);
						if (haveStroke)
						{
							canvas.drawPath(mPath, mStrokePaint);
						}
					}
					else
					{
						if (st.mRadius > 0.0f)
						{
							// since the caller is only giving us 1 value, we will force
							// it to be square if the rect is too small in one dimension
							// to show it. If we did nothing, Skia would clamp the rad
							// independently along each axis, giving us a thin ellipse
							// if the rect were very wide but not very tall
							float rad = st.mRadius;
							float r = System.Math.Min(mRect.width(), mRect.height()) * 0.5f;
							if (rad > r)
							{
								rad = r;
							}
							canvas.drawRoundRect(mRect, rad, rad, mFillPaint);
							if (haveStroke)
							{
								canvas.drawRoundRect(mRect, rad, rad, mStrokePaint);
							}
						}
						else
						{
							canvas.drawRect(mRect, mFillPaint);
							if (haveStroke)
							{
								canvas.drawRect(mRect, mStrokePaint);
							}
						}
					}
					break;
				}

				case OVAL:
				{
					canvas.drawOval(mRect, mFillPaint);
					if (haveStroke)
					{
						canvas.drawOval(mRect, mStrokePaint);
					}
					break;
				}

				case LINE:
				{
					android.graphics.RectF r = mRect;
					float y = r.centerY();
					canvas.drawLine(r.left, y, r.right, y, mStrokePaint);
					break;
				}

				case RING:
				{
					android.graphics.Path path = buildRing(st);
					canvas.drawPath(path, mFillPaint);
					if (haveStroke)
					{
						canvas.drawPath(path, mStrokePaint);
					}
					break;
				}
			}
			if (useLayer)
			{
				canvas.restore();
			}
			else
			{
				mFillPaint.setAlpha(prevFillAlpha);
				if (haveStroke)
				{
					mStrokePaint.setAlpha(prevStrokeAlpha);
				}
			}
		}

		internal android.graphics.Path buildRing(android.graphics.drawable.GradientDrawable
			.GradientState st)
		{
			if (mRingPath != null && (!st.mUseLevelForShape || !mPathIsDirty))
			{
				return mRingPath;
			}
			mPathIsDirty = false;
			float sweep = st.mUseLevelForShape ? (360.0f * getLevel() / 10000.0f) : 360f;
			android.graphics.RectF bounds = new android.graphics.RectF(mRect);
			float x = bounds.width() / 2.0f;
			float y = bounds.height() / 2.0f;
			float thickness = st.mThickness != -1 ? st.mThickness : bounds.width() / st.mThicknessRatio;
			// inner radius
			float radius = st.mInnerRadius != -1 ? st.mInnerRadius : bounds.width() / st.mInnerRadiusRatio;
			android.graphics.RectF innerBounds = new android.graphics.RectF(bounds);
			innerBounds.inset(x - radius, y - radius);
			bounds = new android.graphics.RectF(innerBounds);
			bounds.inset(-thickness, -thickness);
			if (mRingPath == null)
			{
				mRingPath = new android.graphics.Path();
			}
			else
			{
				mRingPath.reset();
			}
			android.graphics.Path ringPath = mRingPath;
			// arcTo treats the sweep angle mod 360, so check for that, since we
			// think 360 means draw the entire oval
			if (sweep < 360 && sweep > -360)
			{
				ringPath.setFillType(android.graphics.Path.FillType.EVEN_ODD);
				// inner top
				ringPath.moveTo(x + radius, y);
				// outer top
				ringPath.lineTo(x + radius + thickness, y);
				// outer arc
				ringPath.arcTo(bounds, 0.0f, sweep, false);
				// inner arc
				ringPath.arcTo(innerBounds, sweep, -sweep, false);
				ringPath.close();
			}
			else
			{
				// add the entire ovals
				ringPath.addOval(bounds, android.graphics.Path.Direction.CW);
				ringPath.addOval(innerBounds, android.graphics.Path.Direction.CCW);
			}
			return ringPath;
		}

		public virtual void setColor(int argb)
		{
			mGradientState.setSolidColor(argb);
			mFillPaint.setColor(argb);
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mGradientState.mChangingConfigurations;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			if (alpha != mAlpha)
			{
				mAlpha = alpha;
				invalidateSelf();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setDither(bool dither)
		{
			if (dither != mDither)
			{
				mDither = dither;
				invalidateSelf();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			if (cf != mColorFilter)
			{
				mColorFilter = cf;
				invalidateSelf();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			// XXX need to figure out the actual opacity...
			return android.graphics.PixelFormat.TRANSLUCENT;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect r)
		{
			base.onBoundsChange(r);
			mRingPath = null;
			mPathIsDirty = true;
			mRectIsDirty = true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onLevelChange(int level)
		{
			base.onLevelChange(level);
			mRectIsDirty = true;
			mPathIsDirty = true;
			invalidateSelf();
			return true;
		}

		/// <summary>
		/// This checks mRectIsDirty, and if it is true, recomputes both our drawing
		/// rectangle (mRect) and the gradient itself, since it depends on our
		/// rectangle too.
		/// </summary>
		/// <remarks>
		/// This checks mRectIsDirty, and if it is true, recomputes both our drawing
		/// rectangle (mRect) and the gradient itself, since it depends on our
		/// rectangle too.
		/// </remarks>
		/// <returns>true if the resulting rectangle is not empty, false otherwise</returns>
		private bool ensureValidRect()
		{
			if (mRectIsDirty)
			{
				mRectIsDirty = false;
				android.graphics.Rect bounds = getBounds();
				float inset = 0;
				if (mStrokePaint != null)
				{
					inset = mStrokePaint.getStrokeWidth() * 0.5f;
				}
				android.graphics.drawable.GradientDrawable.GradientState st = mGradientState;
				mRect.set(bounds.left + inset, bounds.top + inset, bounds.right - inset, bounds.bottom
					 - inset);
				int[] colors = st.mColors;
				if (colors != null)
				{
					android.graphics.RectF r = mRect;
					float x0;
					float x1;
					float y0;
					float y1;
					if (st.mGradient == LINEAR_GRADIENT)
					{
						float level = st.mUseLevel ? (float)getLevel() / 10000.0f : 1.0f;
						switch (st.mOrientation)
						{
							case android.graphics.drawable.GradientDrawable.Orientation.TOP_BOTTOM:
							{
								x0 = r.left;
								y0 = r.top;
								x1 = x0;
								y1 = level * r.bottom;
								break;
							}

							case android.graphics.drawable.GradientDrawable.Orientation.TR_BL:
							{
								x0 = r.right;
								y0 = r.top;
								x1 = level * r.left;
								y1 = level * r.bottom;
								break;
							}

							case android.graphics.drawable.GradientDrawable.Orientation.RIGHT_LEFT:
							{
								x0 = r.right;
								y0 = r.top;
								x1 = level * r.left;
								y1 = y0;
								break;
							}

							case android.graphics.drawable.GradientDrawable.Orientation.BR_TL:
							{
								x0 = r.right;
								y0 = r.bottom;
								x1 = level * r.left;
								y1 = level * r.top;
								break;
							}

							case android.graphics.drawable.GradientDrawable.Orientation.BOTTOM_TOP:
							{
								x0 = r.left;
								y0 = r.bottom;
								x1 = x0;
								y1 = level * r.top;
								break;
							}

							case android.graphics.drawable.GradientDrawable.Orientation.BL_TR:
							{
								x0 = r.left;
								y0 = r.bottom;
								x1 = level * r.right;
								y1 = level * r.top;
								break;
							}

							case android.graphics.drawable.GradientDrawable.Orientation.LEFT_RIGHT:
							{
								x0 = r.left;
								y0 = r.top;
								x1 = level * r.right;
								y1 = y0;
								break;
							}

							default:
							{
								x0 = r.left;
								y0 = r.top;
								x1 = level * r.right;
								y1 = level * r.bottom;
								break;
							}
						}
						mFillPaint.setShader(new android.graphics.LinearGradient(x0, y0, x1, y1, colors, 
							st.mPositions, android.graphics.Shader.TileMode.CLAMP));
					}
					else
					{
						if (st.mGradient == RADIAL_GRADIENT)
						{
							x0 = r.left + (r.right - r.left) * st.mCenterX;
							y0 = r.top + (r.bottom - r.top) * st.mCenterY;
							float level = st.mUseLevel ? (float)getLevel() / 10000.0f : 1.0f;
							mFillPaint.setShader(new android.graphics.RadialGradient(x0, y0, level * st.mGradientRadius
								, colors, null, android.graphics.Shader.TileMode.CLAMP));
						}
						else
						{
							if (st.mGradient == SWEEP_GRADIENT)
							{
								x0 = r.left + (r.right - r.left) * st.mCenterX;
								y0 = r.top + (r.bottom - r.top) * st.mCenterY;
								int[] tempColors = colors;
								float[] tempPositions = null;
								if (st.mUseLevel)
								{
									tempColors = st.mTempColors;
									int length = colors.Length;
									if (tempColors == null || tempColors.Length != length + 1)
									{
										tempColors = st.mTempColors = new int[length + 1];
									}
									System.Array.Copy(colors, 0, tempColors, 0, length);
									tempColors[length] = colors[length - 1];
									tempPositions = st.mTempPositions;
									float fraction = 1.0f / (float)(length - 1);
									if (tempPositions == null || tempPositions.Length != length + 1)
									{
										tempPositions = st.mTempPositions = new float[length + 1];
									}
									float level = (float)getLevel() / 10000.0f;
									{
										for (int i = 0; i < length; i++)
										{
											tempPositions[i] = i * fraction * level;
										}
									}
									tempPositions[length] = 1.0f;
								}
								mFillPaint.setShader(new android.graphics.SweepGradient(x0, y0, tempColors, tempPositions
									));
							}
						}
					}
				}
			}
			return !mRect.isEmpty();
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			android.graphics.drawable.GradientDrawable.GradientState st = mGradientState;
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.GradientDrawable);
			base.inflateWithAttributes(r, parser, a, android.@internal.R.styleable.GradientDrawable_visible
				);
			int shapeType = a.getInt(android.@internal.R.styleable.GradientDrawable_shape, RECTANGLE
				);
			bool dither = a.getBoolean(android.@internal.R.styleable.GradientDrawable_dither, 
				false);
			if (shapeType == RING)
			{
				st.mInnerRadius = a.getDimensionPixelSize(android.@internal.R.styleable.GradientDrawable_innerRadius
					, -1);
				if (st.mInnerRadius == -1)
				{
					st.mInnerRadiusRatio = a.getFloat(android.@internal.R.styleable.GradientDrawable_innerRadiusRatio
						, 3.0f);
				}
				st.mThickness = a.getDimensionPixelSize(android.@internal.R.styleable.GradientDrawable_thickness
					, -1);
				if (st.mThickness == -1)
				{
					st.mThicknessRatio = a.getFloat(android.@internal.R.styleable.GradientDrawable_thicknessRatio
						, 9.0f);
				}
				st.mUseLevelForShape = a.getBoolean(android.@internal.R.styleable.GradientDrawable_useLevel
					, true);
			}
			a.recycle();
			setShape(shapeType);
			setDither(dither);
			int type;
			int innerDepth = parser.getDepth() + 1;
			int depth;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 ((depth = parser.getDepth()) >= innerDepth || type != org.xmlpull.v1.XmlPullParserClass.END_TAG
				))
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				if (depth > innerDepth)
				{
					continue;
				}
				string name = parser.getName();
				if (name.Equals("size"))
				{
					a = r.obtainAttributes(attrs, android.@internal.R.styleable.GradientDrawableSize);
					int width = a.getDimensionPixelSize(android.@internal.R.styleable.GradientDrawableSize_width
						, -1);
					int height = a.getDimensionPixelSize(android.@internal.R.styleable.GradientDrawableSize_height
						, -1);
					a.recycle();
					setSize(width, height);
				}
				else
				{
					if (name.Equals("gradient"))
					{
						a = r.obtainAttributes(attrs, android.@internal.R.styleable.GradientDrawableGradient
							);
						int startColor = a.getColor(android.@internal.R.styleable.GradientDrawableGradient_startColor
							, 0);
						bool hasCenterColor = a.hasValue(android.@internal.R.styleable.GradientDrawableGradient_centerColor
							);
						int centerColor = a.getColor(android.@internal.R.styleable.GradientDrawableGradient_centerColor
							, 0);
						int endColor = a.getColor(android.@internal.R.styleable.GradientDrawableGradient_endColor
							, 0);
						int gradientType = a.getInt(android.@internal.R.styleable.GradientDrawableGradient_type
							, LINEAR_GRADIENT);
						st.mCenterX = getFloatOrFraction(a, android.@internal.R.styleable.GradientDrawableGradient_centerX
							, 0.5f);
						st.mCenterY = getFloatOrFraction(a, android.@internal.R.styleable.GradientDrawableGradient_centerY
							, 0.5f);
						st.mUseLevel = a.getBoolean(android.@internal.R.styleable.GradientDrawableGradient_useLevel
							, false);
						st.mGradient = gradientType;
						if (gradientType == LINEAR_GRADIENT)
						{
							int angle = (int)a.getFloat(android.@internal.R.styleable.GradientDrawableGradient_angle
								, 0);
							angle %= 360;
							if (angle % 45 != 0)
							{
								throw new org.xmlpull.v1.XmlPullParserException(a.getPositionDescription() + "<gradient> tag requires 'angle' attribute to "
									 + "be a multiple of 45");
							}
							switch (angle)
							{
								case 0:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.LEFT_RIGHT;
									break;
								}

								case 45:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.BL_TR;
									break;
								}

								case 90:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.BOTTOM_TOP;
									break;
								}

								case 135:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.BR_TL;
									break;
								}

								case 180:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.RIGHT_LEFT;
									break;
								}

								case 225:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.TR_BL;
									break;
								}

								case 270:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.TOP_BOTTOM;
									break;
								}

								case 315:
								{
									st.mOrientation = android.graphics.drawable.GradientDrawable.Orientation.TL_BR;
									break;
								}
							}
						}
						else
						{
							android.util.TypedValue tv = a.peekValue(android.@internal.R.styleable.GradientDrawableGradient_gradientRadius
								);
							if (tv != null)
							{
								bool radiusRel = tv.type == android.util.TypedValue.TYPE_FRACTION;
								st.mGradientRadius = radiusRel ? tv.getFraction(1.0f, 1.0f) : tv.getFloat();
							}
							else
							{
								if (gradientType == RADIAL_GRADIENT)
								{
									throw new org.xmlpull.v1.XmlPullParserException(a.getPositionDescription() + "<gradient> tag requires 'gradientRadius' "
										 + "attribute with radial type");
								}
							}
						}
						a.recycle();
						if (hasCenterColor)
						{
							st.mColors = new int[3];
							st.mColors[0] = startColor;
							st.mColors[1] = centerColor;
							st.mColors[2] = endColor;
							st.mPositions = new float[3];
							st.mPositions[0] = 0.0f;
							// Since 0.5f is default value, try to take the one that isn't 0.5f
							st.mPositions[1] = st.mCenterX != 0.5f ? st.mCenterX : st.mCenterY;
							st.mPositions[2] = 1f;
						}
						else
						{
							st.mColors = new int[2];
							st.mColors[0] = startColor;
							st.mColors[1] = endColor;
						}
					}
					else
					{
						if (name.Equals("solid"))
						{
							a = r.obtainAttributes(attrs, android.@internal.R.styleable.GradientDrawableSolid
								);
							int argb = a.getColor(android.@internal.R.styleable.GradientDrawableSolid_color, 
								0);
							a.recycle();
							setColor(argb);
						}
						else
						{
							if (name.Equals("stroke"))
							{
								a = r.obtainAttributes(attrs, android.@internal.R.styleable.GradientDrawableStroke
									);
								int width = a.getDimensionPixelSize(android.@internal.R.styleable.GradientDrawableStroke_width
									, 0);
								int color = a.getColor(android.@internal.R.styleable.GradientDrawableStroke_color
									, 0);
								float dashWidth = a.getDimension(android.@internal.R.styleable.GradientDrawableStroke_dashWidth
									, 0);
								if (dashWidth != 0.0f)
								{
									float dashGap = a.getDimension(android.@internal.R.styleable.GradientDrawableStroke_dashGap
										, 0);
									setStroke(width, color, dashWidth, dashGap);
								}
								else
								{
									setStroke(width, color);
								}
								a.recycle();
							}
							else
							{
								if (name.Equals("corners"))
								{
									a = r.obtainAttributes(attrs, android.@internal.R.styleable.DrawableCorners);
									int radius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_radius
										, 0);
									setCornerRadius(radius);
									int topLeftRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_topLeftRadius
										, radius);
									int topRightRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_topRightRadius
										, radius);
									int bottomLeftRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_bottomLeftRadius
										, radius);
									int bottomRightRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_bottomRightRadius
										, radius);
									if (topLeftRadius != radius || topRightRadius != radius || bottomLeftRadius != radius
										 || bottomRightRadius != radius)
									{
										// The corner radii are specified in clockwise order (see Path.addRoundRect())
										setCornerRadii(new float[] { topLeftRadius, topLeftRadius, topRightRadius, topRightRadius
											, bottomRightRadius, bottomRightRadius, bottomLeftRadius, bottomLeftRadius });
									}
									a.recycle();
								}
								else
								{
									if (name.Equals("padding"))
									{
										a = r.obtainAttributes(attrs, android.@internal.R.styleable.GradientDrawablePadding
											);
										mPadding = new android.graphics.Rect(a.getDimensionPixelOffset(android.@internal.R
											.styleable.GradientDrawablePadding_left, 0), a.getDimensionPixelOffset(android.@internal.R
											.styleable.GradientDrawablePadding_top, 0), a.getDimensionPixelOffset(android.@internal.R
											.styleable.GradientDrawablePadding_right, 0), a.getDimensionPixelOffset(android.@internal.R
											.styleable.GradientDrawablePadding_bottom, 0));
										a.recycle();
										mGradientState.mPadding = mPadding;
									}
									else
									{
										android.util.Log.w("drawable", "Bad element under <shape>: " + name);
									}
								}
							}
						}
					}
				}
			}
		}

		private static float getFloatOrFraction(android.content.res.TypedArray a, int index
			, float defaultValue)
		{
			android.util.TypedValue tv = a.peekValue(index);
			float v = defaultValue;
			if (tv != null)
			{
				bool vIsFraction = tv.type == android.util.TypedValue.TYPE_FRACTION;
				v = vIsFraction ? tv.getFraction(1.0f, 1.0f) : tv.getFloat();
			}
			return v;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mGradientState.mWidth;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mGradientState.mHeight;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			mGradientState.mChangingConfigurations = getChangingConfigurations();
			return mGradientState;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mGradientState = new android.graphics.drawable.GradientDrawable.GradientState(mGradientState
					);
				initializeWithState(mGradientState);
				mMutated = true;
			}
			return this;
		}

		internal sealed class GradientState : android.graphics.drawable.Drawable.ConstantState
		{
			public int mChangingConfigurations;

			public int mShape = RECTANGLE;

			public int mGradient = LINEAR_GRADIENT;

			public android.graphics.drawable.GradientDrawable.Orientation mOrientation;

			public int[] mColors;

			public int[] mTempColors;

			public float[] mTempPositions;

			public float[] mPositions;

			public bool mHasSolidColor;

			public int mSolidColor;

			public int mStrokeWidth = -1;

			public int mStrokeColor;

			public float mStrokeDashWidth;

			public float mStrokeDashGap;

			public float mRadius;

			public float[] mRadiusArray;

			public android.graphics.Rect mPadding;

			public int mWidth = -1;

			public int mHeight = -1;

			public float mInnerRadiusRatio;

			public float mThicknessRatio;

			public int mInnerRadius;

			public int mThickness;

			internal float mCenterX = 0.5f;

			internal float mCenterY = 0.5f;

			internal float mGradientRadius = 0.5f;

			internal bool mUseLevel;

			internal bool mUseLevelForShape;

			internal GradientState()
			{
				// no need to copy
				// no need to copy
				// if >= 0 use stroking.
				// use this if mRadiusArray is null
				mOrientation = android.graphics.drawable.GradientDrawable.Orientation.TOP_BOTTOM;
			}

			internal GradientState(android.graphics.drawable.GradientDrawable.Orientation orientation
				, int[] colors)
			{
				mOrientation = orientation;
				mColors = colors;
			}

			internal GradientState(android.graphics.drawable.GradientDrawable.GradientState state
				)
			{
				mChangingConfigurations = state.mChangingConfigurations;
				mShape = state.mShape;
				mGradient = state.mGradient;
				mOrientation = state.mOrientation;
				if (state.mColors != null)
				{
					mColors = (int[])state.mColors.Clone();
				}
				if (state.mPositions != null)
				{
					mPositions = (float[])state.mPositions.Clone();
				}
				mHasSolidColor = state.mHasSolidColor;
				mSolidColor = state.mSolidColor;
				mStrokeWidth = state.mStrokeWidth;
				mStrokeColor = state.mStrokeColor;
				mStrokeDashWidth = state.mStrokeDashWidth;
				mStrokeDashGap = state.mStrokeDashGap;
				mRadius = state.mRadius;
				if (state.mRadiusArray != null)
				{
					mRadiusArray = (float[])state.mRadiusArray.Clone();
				}
				if (state.mPadding != null)
				{
					mPadding = new android.graphics.Rect(state.mPadding);
				}
				mWidth = state.mWidth;
				mHeight = state.mHeight;
				mInnerRadiusRatio = state.mInnerRadiusRatio;
				mThicknessRatio = state.mThicknessRatio;
				mInnerRadius = state.mInnerRadius;
				mThickness = state.mThickness;
				mCenterX = state.mCenterX;
				mCenterY = state.mCenterY;
				mGradientRadius = state.mGradientRadius;
				mUseLevel = state.mUseLevel;
				mUseLevelForShape = state.mUseLevelForShape;
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.GradientDrawable(this);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.GradientDrawable(this);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}

			public void setShape(int shape)
			{
				mShape = shape;
			}

			public void setGradientType(int gradient)
			{
				mGradient = gradient;
			}

			public void setGradientCenter(float x, float y)
			{
				mCenterX = x;
				mCenterY = y;
			}

			public void setSolidColor(int argb)
			{
				mHasSolidColor = true;
				mSolidColor = argb;
				mColors = null;
			}

			public void setStroke(int width, int color)
			{
				mStrokeWidth = width;
				mStrokeColor = color;
			}

			public void setStroke(int width, int color, float dashWidth, float dashGap)
			{
				mStrokeWidth = width;
				mStrokeColor = color;
				mStrokeDashWidth = dashWidth;
				mStrokeDashGap = dashGap;
			}

			public void setCornerRadius(float radius)
			{
				if (radius < 0)
				{
					radius = 0;
				}
				mRadius = radius;
				mRadiusArray = null;
			}

			public void setCornerRadii(float[] radii)
			{
				mRadiusArray = radii;
				if (radii == null)
				{
					mRadius = 0;
				}
			}

			public void setSize(int width, int height)
			{
				mWidth = width;
				mHeight = height;
			}

			public void setGradientRadius(float gradientRadius)
			{
				mGradientRadius = gradientRadius;
			}
		}

		internal GradientDrawable(android.graphics.drawable.GradientDrawable.GradientState
			 state)
		{
			mGradientState = state;
			initializeWithState(state);
			mRectIsDirty = true;
		}

		internal void initializeWithState(android.graphics.drawable.GradientDrawable.GradientState
			 state)
		{
			if (state.mHasSolidColor)
			{
				mFillPaint.setColor(state.mSolidColor);
			}
			mPadding = state.mPadding;
			if (state.mStrokeWidth >= 0)
			{
				mStrokePaint = new android.graphics.Paint(android.graphics.Paint.ANTI_ALIAS_FLAG);
				mStrokePaint.setStyle(android.graphics.Paint.Style.STROKE);
				mStrokePaint.setStrokeWidth(state.mStrokeWidth);
				mStrokePaint.setColor(state.mStrokeColor);
				if (state.mStrokeDashWidth != 0.0f)
				{
					android.graphics.DashPathEffect e = new android.graphics.DashPathEffect(new float
						[] { state.mStrokeDashWidth, state.mStrokeDashGap }, 0);
					mStrokePaint.setPathEffect(e);
				}
			}
		}
	}
}
