using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// The Paint class holds the style and color information about how to draw
	/// geometries, text and bitmaps.
	/// </summary>
	/// <remarks>
	/// The Paint class holds the style and color information about how to draw
	/// geometries, text and bitmaps.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Paint : System.IDisposable
	{
		/// <hide></hide>
		internal android.graphics.Paint.NativePaint mNativePaint;

		private android.graphics.ColorFilter mColorFilter;

		private android.graphics.MaskFilter mMaskFilter;

		private android.graphics.PathEffect mPathEffect;

		private android.graphics.Rasterizer mRasterizer;

		private android.graphics.Shader mShader;

		private android.graphics.Typeface mTypeface;

		private android.graphics.Xfermode mXfermode;

		private bool mHasCompatScaling;

		private float mCompatScaling;

		private float mInvCompatScaling;

		/// <hide></hide>
		public bool hasShadow;

		/// <hide></hide>
		public float shadowDx;

		/// <hide></hide>
		public float shadowDy;

		/// <hide></hide>
		public float shadowRadius;

		/// <hide></hide>
		public int shadowColor;

		/// <hide></hide>
		public int mBidiFlags = BIDI_DEFAULT_LTR;

		internal static readonly android.graphics.Paint.Style[] sStyleArray = new android.graphics.Paint
			.Style[] { android.graphics.Paint.Style.FILL, android.graphics.Paint.Style.STROKE
			, android.graphics.Paint.Style.FILL_AND_STROKE };

		internal static readonly android.graphics.Paint.Cap[] sCapArray = new android.graphics.Paint
			.Cap[] { android.graphics.Paint.Cap.BUTT, android.graphics.Paint.Cap.ROUND, android.graphics.Paint.Cap
			.SQUARE };

		internal static readonly android.graphics.Paint.Join[] sJoinArray = new android.graphics.Paint
			.Join[] { android.graphics.Paint.Join.MITER, android.graphics.Paint.Join.ROUND, 
			android.graphics.Paint.Join.BEVEL };

		internal static readonly android.graphics.Paint.Align[] sAlignArray = new android.graphics.Paint
			.Align[] { android.graphics.Paint.Align.LEFT, android.graphics.Paint.Align.CENTER
			, android.graphics.Paint.Align.RIGHT };

		/// <summary>bit mask for the flag enabling antialiasing</summary>
		public const int ANTI_ALIAS_FLAG = unchecked((int)(0x01));

		/// <summary>bit mask for the flag enabling bitmap filtering</summary>
		public const int FILTER_BITMAP_FLAG = unchecked((int)(0x02));

		/// <summary>bit mask for the flag enabling dithering</summary>
		public const int DITHER_FLAG = unchecked((int)(0x04));

		/// <summary>bit mask for the flag enabling underline text</summary>
		public const int UNDERLINE_TEXT_FLAG = unchecked((int)(0x08));

		/// <summary>bit mask for the flag enabling strike-thru text</summary>
		public const int STRIKE_THRU_TEXT_FLAG = unchecked((int)(0x10));

		/// <summary>bit mask for the flag enabling fake-bold text</summary>
		public const int FAKE_BOLD_TEXT_FLAG = unchecked((int)(0x20));

		/// <summary>bit mask for the flag enabling linear-text (no caching)</summary>
		public const int LINEAR_TEXT_FLAG = unchecked((int)(0x40));

		/// <summary>bit mask for the flag enabling subpixel-text</summary>
		public const int SUBPIXEL_TEXT_FLAG = unchecked((int)(0x80));

		/// <summary>bit mask for the flag enabling device kerning for text</summary>
		public const int DEV_KERN_TEXT_FLAG = unchecked((int)(0x100));

		internal const int DEFAULT_PAINT_FLAGS = DEV_KERN_TEXT_FLAG;

		/// <summary>
		/// Option for
		/// <see cref="setHinting(int)">setHinting(int)</see>
		/// : disable hinting.
		/// </summary>
		public const int HINTING_OFF = unchecked((int)(0x0));

		/// <summary>
		/// Option for
		/// <see cref="setHinting(int)">setHinting(int)</see>
		/// : enable hinting.
		/// </summary>
		public const int HINTING_ON = unchecked((int)(0x1));

		/// <summary>Bidi flag to set LTR paragraph direction.</summary>
		/// <remarks>Bidi flag to set LTR paragraph direction.</remarks>
		/// <hide></hide>
		public const int BIDI_LTR = unchecked((int)(0x0));

		/// <summary>Bidi flag to set RTL paragraph direction.</summary>
		/// <remarks>Bidi flag to set RTL paragraph direction.</remarks>
		/// <hide></hide>
		public const int BIDI_RTL = unchecked((int)(0x1));

		/// <summary>
		/// Bidi flag to detect paragraph direction via heuristics, defaulting to
		/// LTR.
		/// </summary>
		/// <remarks>
		/// Bidi flag to detect paragraph direction via heuristics, defaulting to
		/// LTR.
		/// </remarks>
		/// <hide></hide>
		public const int BIDI_DEFAULT_LTR = unchecked((int)(0x2));

		/// <summary>
		/// Bidi flag to detect paragraph direction via heuristics, defaulting to
		/// RTL.
		/// </summary>
		/// <remarks>
		/// Bidi flag to detect paragraph direction via heuristics, defaulting to
		/// RTL.
		/// </remarks>
		/// <hide></hide>
		public const int BIDI_DEFAULT_RTL = unchecked((int)(0x3));

		/// <summary>Bidi flag to override direction to all LTR (ignore bidi).</summary>
		/// <remarks>Bidi flag to override direction to all LTR (ignore bidi).</remarks>
		/// <hide></hide>
		public const int BIDI_FORCE_LTR = unchecked((int)(0x4));

		/// <summary>Bidi flag to override direction to all RTL (ignore bidi).</summary>
		/// <remarks>Bidi flag to override direction to all RTL (ignore bidi).</remarks>
		/// <hide></hide>
		public const int BIDI_FORCE_RTL = unchecked((int)(0x5));

		/// <summary>Maximum Bidi flag value.</summary>
		/// <remarks>Maximum Bidi flag value.</remarks>
		/// <hide></hide>
		internal const int BIDI_MAX_FLAG_VALUE = BIDI_FORCE_RTL;

		/// <summary>Mask for bidi flags.</summary>
		/// <remarks>Mask for bidi flags.</remarks>
		/// <hide></hide>
		internal const int BIDI_FLAG_MASK = unchecked((int)(0x7));

		/// <summary>Flag for getTextRunAdvances indicating left-to-right run direction.</summary>
		/// <remarks>Flag for getTextRunAdvances indicating left-to-right run direction.</remarks>
		/// <hide></hide>
		public const int DIRECTION_LTR = 0;

		/// <summary>Flag for getTextRunAdvances indicating right-to-left run direction.</summary>
		/// <remarks>Flag for getTextRunAdvances indicating right-to-left run direction.</remarks>
		/// <hide></hide>
		public const int DIRECTION_RTL = 1;

		/// <summary>
		/// Option for getTextRunCursor to compute the valid cursor after
		/// offset or the limit of the context, whichever is less.
		/// </summary>
		/// <remarks>
		/// Option for getTextRunCursor to compute the valid cursor after
		/// offset or the limit of the context, whichever is less.
		/// </remarks>
		/// <hide></hide>
		public const int CURSOR_AFTER = 0;

		/// <summary>
		/// Option for getTextRunCursor to compute the valid cursor at or after
		/// the offset or the limit of the context, whichever is less.
		/// </summary>
		/// <remarks>
		/// Option for getTextRunCursor to compute the valid cursor at or after
		/// the offset or the limit of the context, whichever is less.
		/// </remarks>
		/// <hide></hide>
		public const int CURSOR_AT_OR_AFTER = 1;

		/// <summary>
		/// Option for getTextRunCursor to compute the valid cursor before
		/// offset or the start of the context, whichever is greater.
		/// </summary>
		/// <remarks>
		/// Option for getTextRunCursor to compute the valid cursor before
		/// offset or the start of the context, whichever is greater.
		/// </remarks>
		/// <hide></hide>
		public const int CURSOR_BEFORE = 2;

		/// <summary>
		/// Option for getTextRunCursor to compute the valid cursor at or before
		/// offset or the start of the context, whichever is greater.
		/// </summary>
		/// <remarks>
		/// Option for getTextRunCursor to compute the valid cursor at or before
		/// offset or the start of the context, whichever is greater.
		/// </remarks>
		/// <hide></hide>
		public const int CURSOR_AT_OR_BEFORE = 3;

		/// <summary>
		/// Option for getTextRunCursor to return offset if the cursor at offset
		/// is valid, or -1 if it isn't.
		/// </summary>
		/// <remarks>
		/// Option for getTextRunCursor to return offset if the cursor at offset
		/// is valid, or -1 if it isn't.
		/// </remarks>
		/// <hide></hide>
		public const int CURSOR_AT = 4;

		/// <summary>Maximum cursor option value.</summary>
		/// <remarks>Maximum cursor option value.</remarks>
		internal const int CURSOR_OPT_MAX_VALUE = CURSOR_AT;

		/// <summary>
		/// The Style specifies if the primitive being drawn is filled, stroked, or
		/// both (in the same color).
		/// </summary>
		/// <remarks>
		/// The Style specifies if the primitive being drawn is filled, stroked, or
		/// both (in the same color). The default is FILL.
		/// </remarks>
		public enum Style : int
		{
			/// <summary>
			/// Geometry and text drawn with this style will be filled, ignoring all
			/// stroke-related settings in the paint.
			/// </summary>
			/// <remarks>
			/// Geometry and text drawn with this style will be filled, ignoring all
			/// stroke-related settings in the paint.
			/// </remarks>
			FILL = 0,
			/// <summary>
			/// Geometry and text drawn with this style will be stroked, respecting
			/// the stroke-related fields on the paint.
			/// </summary>
			/// <remarks>
			/// Geometry and text drawn with this style will be stroked, respecting
			/// the stroke-related fields on the paint.
			/// </remarks>
			STROKE = 1,
			/// <summary>
			/// Geometry and text drawn with this style will be both filled and
			/// stroked at the same time, respecting the stroke-related fields on
			/// the paint.
			/// </summary>
			/// <remarks>
			/// Geometry and text drawn with this style will be both filled and
			/// stroked at the same time, respecting the stroke-related fields on
			/// the paint. This mode can give unexpected results if the geometry
			/// is oriented counter-clockwise. This restriction does not apply to
			/// either FILL or STROKE.
			/// </remarks>
			FILL_AND_STROKE = 2
		}

		/// <summary>
		/// The Cap specifies the treatment for the beginning and ending of
		/// stroked lines and paths.
		/// </summary>
		/// <remarks>
		/// The Cap specifies the treatment for the beginning and ending of
		/// stroked lines and paths. The default is BUTT.
		/// </remarks>
		public enum Cap : int
		{
			/// <summary>The stroke ends with the path, and does not project beyond it.</summary>
			/// <remarks>The stroke ends with the path, and does not project beyond it.</remarks>
			BUTT = 0,
			/// <summary>
			/// The stroke projects out as a semicircle, with the center at the
			/// end of the path.
			/// </summary>
			/// <remarks>
			/// The stroke projects out as a semicircle, with the center at the
			/// end of the path.
			/// </remarks>
			ROUND = 1,
			/// <summary>
			/// The stroke projects out as a square, with the center at the end
			/// of the path.
			/// </summary>
			/// <remarks>
			/// The stroke projects out as a square, with the center at the end
			/// of the path.
			/// </remarks>
			SQUARE = 2
		}

		/// <summary>
		/// The Join specifies the treatment where lines and curve segments
		/// join on a stroked path.
		/// </summary>
		/// <remarks>
		/// The Join specifies the treatment where lines and curve segments
		/// join on a stroked path. The default is MITER.
		/// </remarks>
		public enum Join : int
		{
			/// <summary>The outer edges of a join meet at a sharp angle</summary>
			MITER = 0,
			/// <summary>The outer edges of a join meet in a circular arc.</summary>
			/// <remarks>The outer edges of a join meet in a circular arc.</remarks>
			ROUND = 1,
			/// <summary>The outer edges of a join meet with a straight line</summary>
			BEVEL = 2
		}

		/// <summary>
		/// Align specifies how drawText aligns its text relative to the
		/// [x,y] coordinates.
		/// </summary>
		/// <remarks>
		/// Align specifies how drawText aligns its text relative to the
		/// [x,y] coordinates. The default is LEFT.
		/// </remarks>
		public enum Align : int
		{
			/// <summary>The text is drawn to the right of the x,y origin</summary>
			LEFT = 0,
			/// <summary>The text is drawn centered horizontally on the x,y origin</summary>
			CENTER = 1,
			/// <summary>The text is drawn to the left of the x,y origin</summary>
			RIGHT = 2
		}

		/// <summary>Create a new paint with default settings.</summary>
		/// <remarks>Create a new paint with default settings.</remarks>
		public Paint() : this(0)
		{
		}

		/// <summary>Create a new paint with the specified flags.</summary>
		/// <remarks>
		/// Create a new paint with the specified flags. Use setFlags() to change
		/// these after the paint is created.
		/// </remarks>
		/// <param name="flags">initial flag bits, as if they were passed via setFlags().</param>
		public Paint(int flags)
		{
			// we use this when we first create a paint
			mNativePaint = native_init();
			setFlags(flags | DEFAULT_PAINT_FLAGS);
			// TODO: Turning off hinting has undesirable side effects, we need to
			//       revisit hinting once we add support for subpixel positioning
			// setHinting(DisplayMetrics.DENSITY_DEVICE >= DisplayMetrics.DENSITY_TV
			//        ? HINTING_OFF : HINTING_ON);
			mCompatScaling = mInvCompatScaling = 1;
		}

		/// <summary>
		/// Create a new paint, initialized with the attributes in the specified
		/// paint parameter.
		/// </summary>
		/// <remarks>
		/// Create a new paint, initialized with the attributes in the specified
		/// paint parameter.
		/// </remarks>
		/// <param name="paint">
		/// Existing paint used to initialized the attributes of the
		/// new paint.
		/// </param>
		public Paint(android.graphics.Paint paint)
		{
			mNativePaint = native_initWithPaint(paint.mNativePaint);
			setClassVariablesFrom(paint);
		}

		/// <summary>Restores the paint to its default settings.</summary>
		/// <remarks>Restores the paint to its default settings.</remarks>
		public virtual void reset()
		{
			native_reset(mNativePaint);
			setFlags(DEFAULT_PAINT_FLAGS);
			// TODO: Turning off hinting has undesirable side effects, we need to
			//       revisit hinting once we add support for subpixel positioning
			// setHinting(DisplayMetrics.DENSITY_DEVICE >= DisplayMetrics.DENSITY_TV
			//        ? HINTING_OFF : HINTING_ON);
			mHasCompatScaling = false;
			mCompatScaling = mInvCompatScaling = 1;
			mBidiFlags = BIDI_DEFAULT_LTR;
		}

		/// <summary>Copy the fields from src into this paint.</summary>
		/// <remarks>
		/// Copy the fields from src into this paint. This is equivalent to calling
		/// get() on all of the src fields, and calling the corresponding set()
		/// methods on this.
		/// </remarks>
		public virtual void set(android.graphics.Paint src)
		{
			if (this != src)
			{
				// copy over the native settings
				native_set(mNativePaint, src.mNativePaint);
				setClassVariablesFrom(src);
			}
		}

		/// <summary>
		/// Set all class variables using current values from the given
		/// <see cref="Paint">Paint</see>
		/// .
		/// </summary>
		private void setClassVariablesFrom(android.graphics.Paint paint)
		{
			mColorFilter = paint.mColorFilter;
			mMaskFilter = paint.mMaskFilter;
			mPathEffect = paint.mPathEffect;
			mRasterizer = paint.mRasterizer;
			mShader = paint.mShader;
			mTypeface = paint.mTypeface;
			mXfermode = paint.mXfermode;
			mHasCompatScaling = paint.mHasCompatScaling;
			mCompatScaling = paint.mCompatScaling;
			mInvCompatScaling = paint.mInvCompatScaling;
			hasShadow = paint.hasShadow;
			shadowDx = paint.shadowDx;
			shadowDy = paint.shadowDy;
			shadowRadius = paint.shadowRadius;
			shadowColor = paint.shadowColor;
			mBidiFlags = paint.mBidiFlags;
		}

		/// <hide></hide>
		public virtual void setCompatibilityScaling(float factor)
		{
			if (factor == 1.0)
			{
				mHasCompatScaling = false;
				mCompatScaling = mInvCompatScaling = 1.0f;
			}
			else
			{
				mHasCompatScaling = true;
				mCompatScaling = factor;
				mInvCompatScaling = 1.0f / factor;
			}
		}

		/// <summary>Return the bidi flags on the paint.</summary>
		/// <remarks>Return the bidi flags on the paint.</remarks>
		/// <returns>the bidi flags on the paint</returns>
		/// <hide></hide>
		public virtual int getBidiFlags()
		{
			return mBidiFlags;
		}

		/// <summary>Set the bidi flags on the paint.</summary>
		/// <remarks>Set the bidi flags on the paint.</remarks>
		/// <hide></hide>
		public virtual void setBidiFlags(int flags)
		{
			// only flag value is the 3-bit BIDI control setting
			flags &= BIDI_FLAG_MASK;
			if (flags > BIDI_MAX_FLAG_VALUE)
			{
				throw new System.ArgumentException("unknown bidi flag: " + flags);
			}
			mBidiFlags = flags;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getFlags(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the paint's flags.</summary>
		/// <remarks>Return the paint's flags. Use the Flag enum to test flag values.</remarks>
		/// <returns>the paint's flags (see enums ending in _Flag for bit masks)</returns>
		public virtual int getFlags()
		{
			return libxobotos_Paint_getFlags(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setFlags(android.graphics.Paint.NativePaint
			 _instance, int flags);

		/// <summary>Set the paint's flags.</summary>
		/// <remarks>Set the paint's flags. Use the Flag enum to specific flag values.</remarks>
		/// <param name="flags">The new flag bits for the paint</param>
		public virtual void setFlags(int flags)
		{
			libxobotos_Paint_setFlags(mNativePaint, flags);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getHinting(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the paint's hinting mode.</summary>
		/// <remarks>
		/// Return the paint's hinting mode.  Returns either
		/// <see cref="HINTING_OFF">HINTING_OFF</see>
		/// or
		/// <see cref="HINTING_ON">HINTING_ON</see>
		/// .
		/// </remarks>
		public virtual int getHinting()
		{
			return libxobotos_Paint_getHinting(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setHinting(android.graphics.Paint.NativePaint
			 _instance, int mode);

		/// <summary>Set the paint's hinting mode.</summary>
		/// <remarks>
		/// Set the paint's hinting mode.  May be either
		/// <see cref="HINTING_OFF">HINTING_OFF</see>
		/// or
		/// <see cref="HINTING_ON">HINTING_ON</see>
		/// .
		/// </remarks>
		public virtual void setHinting(int mode)
		{
			libxobotos_Paint_setHinting(mNativePaint, mode);
		}

		/// <summary>
		/// Helper for getFlags(), returning true if ANTI_ALIAS_FLAG bit is set
		/// AntiAliasing smooths out the edges of what is being drawn, but is has
		/// no impact on the interior of the shape.
		/// </summary>
		/// <remarks>
		/// Helper for getFlags(), returning true if ANTI_ALIAS_FLAG bit is set
		/// AntiAliasing smooths out the edges of what is being drawn, but is has
		/// no impact on the interior of the shape. See setDither() and
		/// setFilterBitmap() to affect how colors are treated.
		/// </remarks>
		/// <returns>true if the antialias bit is set in the paint's flags.</returns>
		public bool isAntiAlias()
		{
			return (getFlags() & ANTI_ALIAS_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setAntiAlias(android.graphics.Paint.NativePaint
			 _instance, bool aa);

		/// <summary>
		/// Helper for setFlags(), setting or clearing the ANTI_ALIAS_FLAG bit
		/// AntiAliasing smooths out the edges of what is being drawn, but is has
		/// no impact on the interior of the shape.
		/// </summary>
		/// <remarks>
		/// Helper for setFlags(), setting or clearing the ANTI_ALIAS_FLAG bit
		/// AntiAliasing smooths out the edges of what is being drawn, but is has
		/// no impact on the interior of the shape. See setDither() and
		/// setFilterBitmap() to affect how colors are treated.
		/// </remarks>
		/// <param name="aa">true to set the antialias bit in the flags, false to clear it</param>
		public virtual void setAntiAlias(bool aa)
		{
			libxobotos_Paint_setAntiAlias(mNativePaint, aa);
		}

		/// <summary>
		/// Helper for getFlags(), returning true if DITHER_FLAG bit is set
		/// Dithering affects how colors that are higher precision than the device
		/// are down-sampled.
		/// </summary>
		/// <remarks>
		/// Helper for getFlags(), returning true if DITHER_FLAG bit is set
		/// Dithering affects how colors that are higher precision than the device
		/// are down-sampled. No dithering is generally faster, but higher precision
		/// colors are just truncated down (e.g. 8888 -&gt; 565). Dithering tries to
		/// distribute the error inherent in this process, to reduce the visual
		/// artifacts.
		/// </remarks>
		/// <returns>true if the dithering bit is set in the paint's flags.</returns>
		public bool isDither()
		{
			return (getFlags() & DITHER_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setDither(android.graphics.Paint.NativePaint
			 _instance, bool dither);

		/// <summary>
		/// Helper for setFlags(), setting or clearing the DITHER_FLAG bit
		/// Dithering affects how colors that are higher precision than the device
		/// are down-sampled.
		/// </summary>
		/// <remarks>
		/// Helper for setFlags(), setting or clearing the DITHER_FLAG bit
		/// Dithering affects how colors that are higher precision than the device
		/// are down-sampled. No dithering is generally faster, but higher precision
		/// colors are just truncated down (e.g. 8888 -&gt; 565). Dithering tries to
		/// distribute the error inherent in this process, to reduce the visual
		/// artifacts.
		/// </remarks>
		/// <param name="dither">true to set the dithering bit in flags, false to clear it</param>
		public virtual void setDither(bool dither)
		{
			libxobotos_Paint_setDither(mNativePaint, dither);
		}

		/// <summary>Helper for getFlags(), returning true if LINEAR_TEXT_FLAG bit is set</summary>
		/// <returns>true if the lineartext bit is set in the paint's flags</returns>
		public bool isLinearText()
		{
			return (getFlags() & LINEAR_TEXT_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setLinearText(android.graphics.Paint.NativePaint
			 _instance, bool linearText);

		/// <summary>Helper for setFlags(), setting or clearing the LINEAR_TEXT_FLAG bit</summary>
		/// <param name="linearText">
		/// true to set the linearText bit in the paint's flags,
		/// false to clear it.
		/// </param>
		public virtual void setLinearText(bool linearText)
		{
			libxobotos_Paint_setLinearText(mNativePaint, linearText);
		}

		/// <summary>Helper for getFlags(), returning true if SUBPIXEL_TEXT_FLAG bit is set</summary>
		/// <returns>true if the subpixel bit is set in the paint's flags</returns>
		public bool isSubpixelText()
		{
			return (getFlags() & SUBPIXEL_TEXT_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setSubpixelText(android.graphics.Paint.NativePaint
			 _instance, bool subpixelText);

		/// <summary>Helper for setFlags(), setting or clearing the SUBPIXEL_TEXT_FLAG bit</summary>
		/// <param name="subpixelText">
		/// true to set the subpixelText bit in the paint's
		/// flags, false to clear it.
		/// </param>
		public virtual void setSubpixelText(bool subpixelText)
		{
			libxobotos_Paint_setSubpixelText(mNativePaint, subpixelText);
		}

		/// <summary>Helper for getFlags(), returning true if UNDERLINE_TEXT_FLAG bit is set</summary>
		/// <returns>true if the underlineText bit is set in the paint's flags.</returns>
		public bool isUnderlineText()
		{
			return (getFlags() & UNDERLINE_TEXT_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setUnderlineText(android.graphics.Paint.NativePaint
			 _instance, bool underlineText);

		/// <summary>Helper for setFlags(), setting or clearing the UNDERLINE_TEXT_FLAG bit</summary>
		/// <param name="underlineText">
		/// true to set the underlineText bit in the paint's
		/// flags, false to clear it.
		/// </param>
		public virtual void setUnderlineText(bool underlineText)
		{
			libxobotos_Paint_setUnderlineText(mNativePaint, underlineText);
		}

		/// <summary>Helper for getFlags(), returning true if STRIKE_THRU_TEXT_FLAG bit is set
		/// 	</summary>
		/// <returns>true if the strikeThruText bit is set in the paint's flags.</returns>
		public bool isStrikeThruText()
		{
			return (getFlags() & STRIKE_THRU_TEXT_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setStrikeThruText(android.graphics.Paint.NativePaint
			 _instance, bool strikeThruText);

		/// <summary>Helper for setFlags(), setting or clearing the STRIKE_THRU_TEXT_FLAG bit
		/// 	</summary>
		/// <param name="strikeThruText">
		/// true to set the strikeThruText bit in the paint's
		/// flags, false to clear it.
		/// </param>
		public virtual void setStrikeThruText(bool strikeThruText)
		{
			libxobotos_Paint_setStrikeThruText(mNativePaint, strikeThruText);
		}

		/// <summary>Helper for getFlags(), returning true if FAKE_BOLD_TEXT_FLAG bit is set</summary>
		/// <returns>true if the fakeBoldText bit is set in the paint's flags.</returns>
		public bool isFakeBoldText()
		{
			return (getFlags() & FAKE_BOLD_TEXT_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setFakeBoldText(android.graphics.Paint.NativePaint
			 _instance, bool fakeBoldText);

		/// <summary>Helper for setFlags(), setting or clearing the FAKE_BOLD_TEXT_FLAG bit</summary>
		/// <param name="fakeBoldText">
		/// true to set the fakeBoldText bit in the paint's
		/// flags, false to clear it.
		/// </param>
		public virtual void setFakeBoldText(bool fakeBoldText)
		{
			libxobotos_Paint_setFakeBoldText(mNativePaint, fakeBoldText);
		}

		/// <summary>Whether or not the bitmap filter is activated.</summary>
		/// <remarks>
		/// Whether or not the bitmap filter is activated.
		/// Filtering affects the sampling of bitmaps when they are transformed.
		/// Filtering does not affect how the colors in the bitmap are converted into
		/// device pixels. That is dependent on dithering and xfermodes.
		/// </remarks>
		/// <seealso cref="setFilterBitmap(bool)">setFilterBitmap()</seealso>
		public bool isFilterBitmap()
		{
			return (getFlags() & FILTER_BITMAP_FLAG) != 0;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setFilterBitmap(android.graphics.Paint.NativePaint
			 _instance, bool filter);

		/// <summary>Helper for setFlags(), setting or clearing the FILTER_BITMAP_FLAG bit.</summary>
		/// <remarks>
		/// Helper for setFlags(), setting or clearing the FILTER_BITMAP_FLAG bit.
		/// Filtering affects the sampling of bitmaps when they are transformed.
		/// Filtering does not affect how the colors in the bitmap are converted into
		/// device pixels. That is dependent on dithering and xfermodes.
		/// </remarks>
		/// <param name="filter">
		/// true to set the FILTER_BITMAP_FLAG bit in the paint's
		/// flags, false to clear it.
		/// </param>
		public virtual void setFilterBitmap(bool filter)
		{
			libxobotos_Paint_setFilterBitmap(mNativePaint, filter);
		}

		/// <summary>
		/// Return the paint's style, used for controlling how primitives'
		/// geometries are interpreted (except for drawBitmap, which always assumes
		/// FILL_STYLE).
		/// </summary>
		/// <remarks>
		/// Return the paint's style, used for controlling how primitives'
		/// geometries are interpreted (except for drawBitmap, which always assumes
		/// FILL_STYLE).
		/// </remarks>
		/// <returns>the paint's style setting (Fill, Stroke, StrokeAndFill)</returns>
		public virtual android.graphics.Paint.Style getStyle()
		{
			return sStyleArray[native_getStyle(mNativePaint)];
		}

		/// <summary>
		/// Set the paint's style, used for controlling how primitives'
		/// geometries are interpreted (except for drawBitmap, which always assumes
		/// Fill).
		/// </summary>
		/// <remarks>
		/// Set the paint's style, used for controlling how primitives'
		/// geometries are interpreted (except for drawBitmap, which always assumes
		/// Fill).
		/// </remarks>
		/// <param name="style">The new style to set in the paint</param>
		public virtual void setStyle(android.graphics.Paint.Style style)
		{
			native_setStyle(mNativePaint, (int)style);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getColor(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the paint's color.</summary>
		/// <remarks>
		/// Return the paint's color. Note that the color is a 32bit value
		/// containing alpha as well as r,g,b. This 32bit value is not premultiplied,
		/// meaning that its alpha can be any value, regardless of the values of
		/// r,g,b. See the Color class for more details.
		/// </remarks>
		/// <returns>the paint's color (and alpha).</returns>
		public virtual int getColor()
		{
			return libxobotos_Paint_getColor(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setColor(android.graphics.Paint.NativePaint
			 _instance, int color);

		/// <summary>Set the paint's color.</summary>
		/// <remarks>
		/// Set the paint's color. Note that the color is an int containing alpha
		/// as well as r,g,b. This 32bit value is not premultiplied, meaning that
		/// its alpha can be any value, regardless of the values of r,g,b.
		/// See the Color class for more details.
		/// </remarks>
		/// <param name="color">The new color (including alpha) to set in the paint.</param>
		public virtual void setColor(int color)
		{
			libxobotos_Paint_setColor(mNativePaint, color);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getAlpha(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Helper to getColor() that just returns the color's alpha value.</summary>
		/// <remarks>
		/// Helper to getColor() that just returns the color's alpha value. This is
		/// the same as calling getColor() &gt;&gt;&gt; 24. It always returns a value between
		/// 0 (completely transparent) and 255 (completely opaque).
		/// </remarks>
		/// <returns>the alpha component of the paint's color.</returns>
		public virtual int getAlpha()
		{
			return libxobotos_Paint_getAlpha(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setAlpha(android.graphics.Paint.NativePaint
			 _instance, int a);

		/// <summary>
		/// Helper to setColor(), that only assigns the color's alpha value,
		/// leaving its r,g,b values unchanged.
		/// </summary>
		/// <remarks>
		/// Helper to setColor(), that only assigns the color's alpha value,
		/// leaving its r,g,b values unchanged. Results are undefined if the alpha
		/// value is outside of the range [0..255]
		/// </remarks>
		/// <param name="a">set the alpha component [0..255] of the paint's color.</param>
		public virtual void setAlpha(int a)
		{
			libxobotos_Paint_setAlpha(mNativePaint, a);
		}

		/// <summary>Helper to setColor(), that takes a,r,g,b and constructs the color int</summary>
		/// <param name="a">The new alpha component (0..255) of the paint's color.</param>
		/// <param name="r">The new red component (0..255) of the paint's color.</param>
		/// <param name="g">The new green component (0..255) of the paint's color.</param>
		/// <param name="b">The new blue component (0..255) of the paint's color.</param>
		public virtual void setARGB(int a, int r, int g, int b)
		{
			setColor((a << 24) | (r << 16) | (g << 8) | b);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getStrokeWidth(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the width for stroking.</summary>
		/// <remarks>
		/// Return the width for stroking.
		/// <p />
		/// A value of 0 strokes in hairline mode.
		/// Hairlines always draws a single pixel independent of the canva's matrix.
		/// </remarks>
		/// <returns>
		/// the paint's stroke width, used whenever the paint's style is
		/// Stroke or StrokeAndFill.
		/// </returns>
		public virtual float getStrokeWidth()
		{
			return libxobotos_Paint_getStrokeWidth(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setStrokeWidth(android.graphics.Paint.NativePaint
			 _instance, float width);

		/// <summary>Set the width for stroking.</summary>
		/// <remarks>
		/// Set the width for stroking.
		/// Pass 0 to stroke in hairline mode.
		/// Hairlines always draws a single pixel independent of the canva's matrix.
		/// </remarks>
		/// <param name="width">
		/// set the paint's stroke width, used whenever the paint's
		/// style is Stroke or StrokeAndFill.
		/// </param>
		public virtual void setStrokeWidth(float width)
		{
			libxobotos_Paint_setStrokeWidth(mNativePaint, width);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getStrokeMiter(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the paint's stroke miter value.</summary>
		/// <remarks>
		/// Return the paint's stroke miter value. Used to control the behavior
		/// of miter joins when the joins angle is sharp.
		/// </remarks>
		/// <returns>
		/// the paint's miter limit, used whenever the paint's style is
		/// Stroke or StrokeAndFill.
		/// </returns>
		public virtual float getStrokeMiter()
		{
			return libxobotos_Paint_getStrokeMiter(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setStrokeMiter(android.graphics.Paint.NativePaint
			 _instance, float miter);

		/// <summary>Set the paint's stroke miter value.</summary>
		/// <remarks>
		/// Set the paint's stroke miter value. This is used to control the behavior
		/// of miter joins when the joins angle is sharp. This value must be &gt;= 0.
		/// </remarks>
		/// <param name="miter">
		/// set the miter limit on the paint, used whenever the paint's
		/// style is Stroke or StrokeAndFill.
		/// </param>
		public virtual void setStrokeMiter(float miter)
		{
			libxobotos_Paint_setStrokeMiter(mNativePaint, miter);
		}

		/// <summary>
		/// Return the paint's Cap, controlling how the start and end of stroked
		/// lines and paths are treated.
		/// </summary>
		/// <remarks>
		/// Return the paint's Cap, controlling how the start and end of stroked
		/// lines and paths are treated.
		/// </remarks>
		/// <returns>
		/// the line cap style for the paint, used whenever the paint's
		/// style is Stroke or StrokeAndFill.
		/// </returns>
		public virtual android.graphics.Paint.Cap getStrokeCap()
		{
			return sCapArray[native_getStrokeCap(mNativePaint)];
		}

		/// <summary>Set the paint's Cap.</summary>
		/// <remarks>Set the paint's Cap.</remarks>
		/// <param name="cap">
		/// set the paint's line cap style, used whenever the paint's
		/// style is Stroke or StrokeAndFill.
		/// </param>
		public virtual void setStrokeCap(android.graphics.Paint.Cap cap)
		{
			native_setStrokeCap(mNativePaint, (int)cap);
		}

		/// <summary>Return the paint's stroke join type.</summary>
		/// <remarks>Return the paint's stroke join type.</remarks>
		/// <returns>the paint's Join.</returns>
		public virtual android.graphics.Paint.Join getStrokeJoin()
		{
			return sJoinArray[native_getStrokeJoin(mNativePaint)];
		}

		/// <summary>Set the paint's Join.</summary>
		/// <remarks>Set the paint's Join.</remarks>
		/// <param name="join">
		/// set the paint's Join, used whenever the paint's style is
		/// Stroke or StrokeAndFill.
		/// </param>
		public virtual void setStrokeJoin(android.graphics.Paint.Join join)
		{
			native_setStrokeJoin(mNativePaint, (int)join);
		}

		/// <summary>
		/// Applies any/all effects (patheffect, stroking) to src, returning the
		/// result in dst.
		/// </summary>
		/// <remarks>
		/// Applies any/all effects (patheffect, stroking) to src, returning the
		/// result in dst. The result is that drawing src with this paint will be
		/// the same as drawing dst with a default paint (at least from the
		/// geometric perspective).
		/// </remarks>
		/// <param name="src">input path</param>
		/// <param name="dst">output path (may be the same as src)</param>
		/// <returns>
		/// true if the path should be filled, or false if it should be
		/// drawn with a hairline (width == 0)
		/// </returns>
		public virtual bool getFillPath(android.graphics.Path src, android.graphics.Path 
			dst)
		{
			return native_getFillPath(mNativePaint, src.nativeInstance, dst.nativeInstance);
		}

		/// <summary>Get the paint's shader object.</summary>
		/// <remarks>Get the paint's shader object.</remarks>
		/// <returns>the paint's shader (or null)</returns>
		public virtual android.graphics.Shader getShader()
		{
			return mShader;
		}

		/// <summary>Set or clear the shader object.</summary>
		/// <remarks>
		/// Set or clear the shader object.
		/// <p />
		/// Pass null to clear any previous shader.
		/// As a convenience, the parameter passed is also returned.
		/// </remarks>
		/// <param name="shader">May be null. the new shader to be installed in the paint</param>
		/// <returns>shader</returns>
		public virtual android.graphics.Shader setShader(android.graphics.Shader shader)
		{
			android.graphics.Shader.NativeShader shaderNative = null;
			if (shader != null)
			{
				shaderNative = shader.native_instance;
			}
			native_setShader(mNativePaint, shaderNative);
			mShader = shader;
			return shader;
		}

		/// <summary>Get the paint's colorfilter (maybe be null).</summary>
		/// <remarks>Get the paint's colorfilter (maybe be null).</remarks>
		/// <returns>the paint's colorfilter (maybe be null)</returns>
		public virtual android.graphics.ColorFilter getColorFilter()
		{
			return mColorFilter;
		}

		/// <summary>Set or clear the paint's colorfilter, returning the parameter.</summary>
		/// <remarks>Set or clear the paint's colorfilter, returning the parameter.</remarks>
		/// <param name="filter">May be null. The new filter to be installed in the paint</param>
		/// <returns>filter</returns>
		public virtual android.graphics.ColorFilter setColorFilter(android.graphics.ColorFilter
			 filter)
		{
			android.graphics.ColorFilter.NativeFilter filterNative = null;
			if (filter != null)
			{
				filterNative = filter.native_instance;
			}
			native_setColorFilter(mNativePaint, filterNative);
			mColorFilter = filter;
			return filter;
		}

		/// <summary>Get the paint's xfermode object.</summary>
		/// <remarks>Get the paint's xfermode object.</remarks>
		/// <returns>the paint's xfermode (or null)</returns>
		public virtual android.graphics.Xfermode getXfermode()
		{
			return mXfermode;
		}

		/// <summary>Set or clear the xfermode object.</summary>
		/// <remarks>
		/// Set or clear the xfermode object.
		/// <p />
		/// Pass null to clear any previous xfermode.
		/// As a convenience, the parameter passed is also returned.
		/// </remarks>
		/// <param name="xfermode">May be null. The xfermode to be installed in the paint</param>
		/// <returns>xfermode</returns>
		public virtual android.graphics.Xfermode setXfermode(android.graphics.Xfermode xfermode
			)
		{
			android.graphics.Xfermode.NativeXfermode xfermodeNative = null;
			if (xfermode != null)
			{
				xfermodeNative = xfermode.native_instance;
			}
			native_setXfermode(mNativePaint, xfermodeNative);
			mXfermode = xfermode;
			return xfermode;
		}

		/// <summary>Get the paint's patheffect object.</summary>
		/// <remarks>Get the paint's patheffect object.</remarks>
		/// <returns>the paint's patheffect (or null)</returns>
		public virtual android.graphics.PathEffect getPathEffect()
		{
			return mPathEffect;
		}

		/// <summary>Set or clear the patheffect object.</summary>
		/// <remarks>
		/// Set or clear the patheffect object.
		/// <p />
		/// Pass null to clear any previous patheffect.
		/// As a convenience, the parameter passed is also returned.
		/// </remarks>
		/// <param name="effect">May be null. The patheffect to be installed in the paint</param>
		/// <returns>effect</returns>
		public virtual android.graphics.PathEffect setPathEffect(android.graphics.PathEffect
			 effect)
		{
			android.graphics.PathEffect.NativePathEffect effectNative = null;
			if (effect != null)
			{
				effectNative = effect.native_instance;
			}
			native_setPathEffect(mNativePaint, effectNative);
			mPathEffect = effect;
			return effect;
		}

		/// <summary>Get the paint's maskfilter object.</summary>
		/// <remarks>Get the paint's maskfilter object.</remarks>
		/// <returns>the paint's maskfilter (or null)</returns>
		public virtual android.graphics.MaskFilter getMaskFilter()
		{
			return mMaskFilter;
		}

		/// <summary>Set or clear the maskfilter object.</summary>
		/// <remarks>
		/// Set or clear the maskfilter object.
		/// <p />
		/// Pass null to clear any previous maskfilter.
		/// As a convenience, the parameter passed is also returned.
		/// </remarks>
		/// <param name="maskfilter">
		/// May be null. The maskfilter to be installed in the
		/// paint
		/// </param>
		/// <returns>maskfilter</returns>
		public virtual android.graphics.MaskFilter setMaskFilter(android.graphics.MaskFilter
			 maskfilter)
		{
			android.graphics.MaskFilter.NativeFilter maskfilterNative = null;
			if (maskfilter != null)
			{
				maskfilterNative = maskfilter.native_instance;
			}
			native_setMaskFilter(mNativePaint, maskfilterNative);
			mMaskFilter = maskfilter;
			return maskfilter;
		}

		/// <summary>Get the paint's typeface object.</summary>
		/// <remarks>
		/// Get the paint's typeface object.
		/// <p />
		/// The typeface object identifies which font to use when drawing or
		/// measuring text.
		/// </remarks>
		/// <returns>the paint's typeface (or null)</returns>
		public virtual android.graphics.Typeface getTypeface()
		{
			return mTypeface;
		}

		/// <summary>Set or clear the typeface object.</summary>
		/// <remarks>
		/// Set or clear the typeface object.
		/// <p />
		/// Pass null to clear any previous typeface.
		/// As a convenience, the parameter passed is also returned.
		/// </remarks>
		/// <param name="typeface">May be null. The typeface to be installed in the paint</param>
		/// <returns>typeface</returns>
		public virtual android.graphics.Typeface setTypeface(android.graphics.Typeface typeface
			)
		{
			android.graphics.Typeface.NativeTypeface typefaceNative = null;
			if (typeface != null)
			{
				typefaceNative = typeface.native_instance;
			}
			native_setTypeface(mNativePaint, typefaceNative);
			mTypeface = typeface;
			return typeface;
		}

		/// <summary>Get the paint's rasterizer (or null).</summary>
		/// <remarks>
		/// Get the paint's rasterizer (or null).
		/// <p />
		/// The raster controls/modifies how paths/text are turned into alpha masks.
		/// </remarks>
		/// <returns>the paint's rasterizer (or null)</returns>
		public virtual android.graphics.Rasterizer getRasterizer()
		{
			return mRasterizer;
		}

		/// <summary>Set or clear the rasterizer object.</summary>
		/// <remarks>
		/// Set or clear the rasterizer object.
		/// <p />
		/// Pass null to clear any previous rasterizer.
		/// As a convenience, the parameter passed is also returned.
		/// </remarks>
		/// <param name="rasterizer">
		/// May be null. The new rasterizer to be installed in
		/// the paint.
		/// </param>
		/// <returns>rasterizer</returns>
		public virtual android.graphics.Rasterizer setRasterizer(android.graphics.Rasterizer
			 rasterizer)
		{
			android.graphics.Rasterizer.NativeRasterizer rasterizerNative = null;
			if (rasterizer != null)
			{
				rasterizerNative = rasterizer.native_instance;
			}
			native_setRasterizer(mNativePaint, rasterizerNative);
			mRasterizer = rasterizer;
			return rasterizer;
		}

		/// <summary>
		/// This draws a shadow layer below the main layer, with the specified
		/// offset and color, and blur radius.
		/// </summary>
		/// <remarks>
		/// This draws a shadow layer below the main layer, with the specified
		/// offset and color, and blur radius. If radius is 0, then the shadow
		/// layer is removed.
		/// </remarks>
		public virtual void setShadowLayer(float radius, float dx, float dy, int color)
		{
			hasShadow = radius > 0.0f;
			shadowRadius = radius;
			shadowDx = dx;
			shadowDy = dy;
			shadowColor = color;
			nSetShadowLayer(radius, dx, dy, color);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setShadowLayer(android.graphics.Paint.NativePaint
			 _instance, float radius, float dx, float dy, int color);

		private void nSetShadowLayer(float radius, float dx, float dy, int color)
		{
			libxobotos_Paint_setShadowLayer(mNativePaint, radius, dx, dy, color);
		}

		/// <summary>Clear the shadow layer.</summary>
		/// <remarks>Clear the shadow layer.</remarks>
		public virtual void clearShadowLayer()
		{
			hasShadow = false;
			nSetShadowLayer(0, 0, 0, 0);
		}

		/// <summary>Return the paint's Align value for drawing text.</summary>
		/// <remarks>
		/// Return the paint's Align value for drawing text. This controls how the
		/// text is positioned relative to its origin. LEFT align means that all of
		/// the text will be drawn to the right of its origin (i.e. the origin
		/// specifieds the LEFT edge of the text) and so on.
		/// </remarks>
		/// <returns>the paint's Align value for drawing text.</returns>
		public virtual android.graphics.Paint.Align getTextAlign()
		{
			return sAlignArray[native_getTextAlign(mNativePaint)];
		}

		/// <summary>Set the paint's text alignment.</summary>
		/// <remarks>
		/// Set the paint's text alignment. This controls how the
		/// text is positioned relative to its origin. LEFT align means that all of
		/// the text will be drawn to the right of its origin (i.e. the origin
		/// specifieds the LEFT edge of the text) and so on.
		/// </remarks>
		/// <param name="align">set the paint's Align value for drawing text.</param>
		public virtual void setTextAlign(android.graphics.Paint.Align align)
		{
			native_setTextAlign(mNativePaint, (int)align);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getTextSize(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the paint's text size.</summary>
		/// <remarks>Return the paint's text size.</remarks>
		/// <returns>the paint's text size.</returns>
		public virtual float getTextSize()
		{
			return libxobotos_Paint_getTextSize(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setTextSize(android.graphics.Paint.NativePaint
			 _instance, float textSize);

		/// <summary>Set the paint's text size.</summary>
		/// <remarks>Set the paint's text size. This value must be &gt; 0</remarks>
		/// <param name="textSize">set the paint's text size.</param>
		public virtual void setTextSize(float textSize)
		{
			libxobotos_Paint_setTextSize(mNativePaint, textSize);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getTextScaleX(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the paint's horizontal scale factor for text.</summary>
		/// <remarks>
		/// Return the paint's horizontal scale factor for text. The default value
		/// is 1.0.
		/// </remarks>
		/// <returns>the paint's scale factor in X for drawing/measuring text</returns>
		public virtual float getTextScaleX()
		{
			return libxobotos_Paint_getTextScaleX(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setTextScaleX(android.graphics.Paint.NativePaint
			 _instance, float scaleX);

		/// <summary>Set the paint's horizontal scale factor for text.</summary>
		/// <remarks>
		/// Set the paint's horizontal scale factor for text. The default value
		/// is 1.0. Values &gt; 1.0 will stretch the text wider. Values &lt; 1.0 will
		/// stretch the text narrower.
		/// </remarks>
		/// <param name="scaleX">set the paint's scale in X for drawing/measuring text.</param>
		public virtual void setTextScaleX(float scaleX)
		{
			libxobotos_Paint_setTextScaleX(mNativePaint, scaleX);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getTextSkewX(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>Return the paint's horizontal skew factor for text.</summary>
		/// <remarks>
		/// Return the paint's horizontal skew factor for text. The default value
		/// is 0.
		/// </remarks>
		/// <returns>the paint's skew factor in X for drawing text.</returns>
		public virtual float getTextSkewX()
		{
			return libxobotos_Paint_getTextSkewX(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setTextSkewX(android.graphics.Paint.NativePaint
			 _instance, float skewX);

		/// <summary>Set the paint's horizontal skew factor for text.</summary>
		/// <remarks>
		/// Set the paint's horizontal skew factor for text. The default value
		/// is 0. For approximating oblique text, use values around -0.25.
		/// </remarks>
		/// <param name="skewX">set the paint's skew factor in X for drawing text.</param>
		public virtual void setTextSkewX(float skewX)
		{
			libxobotos_Paint_setTextSkewX(mNativePaint, skewX);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_ascent(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>
		/// Return the distance above (negative) the baseline (ascent) based on the
		/// current typeface and text size.
		/// </summary>
		/// <remarks>
		/// Return the distance above (negative) the baseline (ascent) based on the
		/// current typeface and text size.
		/// </remarks>
		/// <returns>
		/// the distance above (negative) the baseline (ascent) based on the
		/// current typeface and text size.
		/// </returns>
		public virtual float ascent()
		{
			return libxobotos_Paint_ascent(mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_descent(android.graphics.Paint.NativePaint
			 _instance);

		/// <summary>
		/// Return the distance below (positive) the baseline (descent) based on the
		/// current typeface and text size.
		/// </summary>
		/// <remarks>
		/// Return the distance below (positive) the baseline (descent) based on the
		/// current typeface and text size.
		/// </remarks>
		/// <returns>
		/// the distance below (positive) the baseline (descent) based on
		/// the current typeface and text size.
		/// </returns>
		public virtual float descent()
		{
			return libxobotos_Paint_descent(mNativePaint);
		}

		/// <summary>Class that describes the various metrics for a font at a given text size.
		/// 	</summary>
		/// <remarks>
		/// Class that describes the various metrics for a font at a given text size.
		/// Remember, Y values increase going down, so those values will be positive,
		/// and values that measure distances going up will be negative. This class
		/// is returned by getFontMetrics().
		/// </remarks>
		public class FontMetrics
		{
			/// <summary>
			/// The maximum distance above the baseline for the tallest glyph in
			/// the font at a given text size.
			/// </summary>
			/// <remarks>
			/// The maximum distance above the baseline for the tallest glyph in
			/// the font at a given text size.
			/// </remarks>
			public float top;

			/// <summary>The recommended distance above the baseline for singled spaced text.</summary>
			/// <remarks>The recommended distance above the baseline for singled spaced text.</remarks>
			public float ascent;

			/// <summary>The recommended distance below the baseline for singled spaced text.</summary>
			/// <remarks>The recommended distance below the baseline for singled spaced text.</remarks>
			public float descent;

			/// <summary>
			/// The maximum distance below the baseline for the lowest glyph in
			/// the font at a given text size.
			/// </summary>
			/// <remarks>
			/// The maximum distance below the baseline for the lowest glyph in
			/// the font at a given text size.
			/// </remarks>
			public float bottom;

			/// <summary>The recommended additional space to add between lines of text.</summary>
			/// <remarks>The recommended additional space to add between lines of text.</remarks>
			public float leading;

			[Sharpen.MarshalHelper(@"SkPaint::FontMetrics")]
			internal static class FontMetrics_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct FontMetrics_Struct
				{
					public uint _owner;

					public float top;

					public float ascent;

					public float descent;

					public float bottom;

					public float leading;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(FontMetrics_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, android.graphics.Paint.FontMetrics
					 arg)
				{
					FontMetrics_Struct obj = new FontMetrics_Struct();
					obj._owner = 0x972f3813;
					obj.top = arg.top;
					obj.ascent = arg.ascent;
					obj.descent = arg.descent;
					obj.bottom = arg.bottom;
					obj.leading = arg.leading;
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, android.graphics.Paint.FontMetrics
					 arg)
				{
					FontMetrics_Struct obj = (FontMetrics_Struct)Marshal.PtrToStructure(ptr, typeof(FontMetrics_Struct
						));
					arg.top = obj.top;
					arg.ascent = obj.ascent;
					arg.descent = obj.descent;
					arg.bottom = obj.bottom;
					arg.leading = obj.leading;
				}

				public static System.IntPtr ManagedToNative(android.graphics.Paint.FontMetrics arg
					)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FontMetrics_Struct
						)));
					android.graphics.Paint.FontMetrics.FontMetrics_Helper.MarshalIn(ptr, arg);
					return ptr;
				}

				public static android.graphics.Paint.FontMetrics NativeToManaged(System.IntPtr ptr
					)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					FontMetrics_Struct obj = (FontMetrics_Struct)Marshal.PtrToStructure(ptr, typeof(FontMetrics_Struct
						));
					android.graphics.Paint.FontMetrics arg = new android.graphics.Paint.FontMetrics();
					arg.top = obj.top;
					arg.ascent = obj.ascent;
					arg.descent = obj.descent;
					arg.bottom = obj.bottom;
					arg.leading = obj.leading;
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_android_graphics_Paint_FontMetrics_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_graphics_Paint_FontMetrics_destructor
					(System.IntPtr ptr);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					FontMetrics_Struct obj = (FontMetrics_Struct)Marshal.PtrToStructure(ptr, typeof(FontMetrics_Struct
						));
					if (obj._owner != 0x972f3813)
					{
						throw new System.InvalidOperationException();
					}
				}

				public static void FreeManagedPtr(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return;
					}
					android.graphics.Paint.FontMetrics.FontMetrics_Helper.FreeManagedPtr_inner(ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getFontMetrics(android.graphics.Paint.NativePaint
			 _instance, out System.IntPtr metrics);

		/// <summary>
		/// Return the font's recommended interline spacing, given the Paint's
		/// settings for typeface, textSize, etc.
		/// </summary>
		/// <remarks>
		/// Return the font's recommended interline spacing, given the Paint's
		/// settings for typeface, textSize, etc. If metrics is not null, return the
		/// fontmetric values in it.
		/// </remarks>
		/// <param name="metrics">
		/// If this object is not null, its fields are filled with
		/// the appropriate values given the paint's text attributes.
		/// </param>
		/// <returns>the font's recommended interline spacing.</returns>
		public virtual float getFontMetrics(android.graphics.Paint.FontMetrics metrics)
		{
			System.IntPtr metrics_ptr = System.IntPtr.Zero;
			try
			{
				float _retval = libxobotos_Paint_getFontMetrics(mNativePaint, out metrics_ptr);
				android.graphics.Paint.FontMetrics.FontMetrics_Helper.MarshalOut(metrics_ptr, metrics
					);
				return _retval;
			}
			finally
			{
				android.graphics.Paint.FontMetrics.FontMetrics_Helper.FreeNativePtr(metrics_ptr);
			}
		}

		/// <summary>
		/// Allocates a new FontMetrics object, and then calls getFontMetrics(fm)
		/// with it, returning the object.
		/// </summary>
		/// <remarks>
		/// Allocates a new FontMetrics object, and then calls getFontMetrics(fm)
		/// with it, returning the object.
		/// </remarks>
		public virtual android.graphics.Paint.FontMetrics getFontMetrics()
		{
			android.graphics.Paint.FontMetrics fm = new android.graphics.Paint.FontMetrics();
			getFontMetrics(fm);
			return fm;
		}

		/// <summary>
		/// Convenience method for callers that want to have FontMetrics values as
		/// integers.
		/// </summary>
		/// <remarks>
		/// Convenience method for callers that want to have FontMetrics values as
		/// integers.
		/// </remarks>
		public class FontMetricsInt
		{
			public int top;

			public int ascent;

			public int descent;

			public int bottom;

			public int leading;

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "FontMetricsInt: top=" + top + " ascent=" + ascent + " descent=" + descent
					 + " bottom=" + bottom + " leading=" + leading;
			}

			[Sharpen.MarshalHelper(@"PaintGlue::FontMetricsInt")]
			internal static class FontMetricsInt_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct FontMetricsInt_Struct
				{
					public uint _owner;

					public int top;

					public int ascent;

					public int descent;

					public int bottom;

					public int leading;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(FontMetricsInt_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, android.graphics.Paint.FontMetricsInt
					 arg)
				{
					FontMetricsInt_Struct obj = new FontMetricsInt_Struct();
					obj._owner = 0x972f3813;
					obj.top = arg.top;
					obj.ascent = arg.ascent;
					obj.descent = arg.descent;
					obj.bottom = arg.bottom;
					obj.leading = arg.leading;
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, android.graphics.Paint.FontMetricsInt
					 arg)
				{
					FontMetricsInt_Struct obj = (FontMetricsInt_Struct)Marshal.PtrToStructure(ptr, typeof(
						FontMetricsInt_Struct));
					arg.top = obj.top;
					arg.ascent = obj.ascent;
					arg.descent = obj.descent;
					arg.bottom = obj.bottom;
					arg.leading = obj.leading;
				}

				public static System.IntPtr ManagedToNative(android.graphics.Paint.FontMetricsInt
					 arg)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FontMetricsInt_Struct
						)));
					android.graphics.Paint.FontMetricsInt.FontMetricsInt_Helper.MarshalIn(ptr, arg);
					return ptr;
				}

				public static android.graphics.Paint.FontMetricsInt NativeToManaged(System.IntPtr
					 ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					FontMetricsInt_Struct obj = (FontMetricsInt_Struct)Marshal.PtrToStructure(ptr, typeof(
						FontMetricsInt_Struct));
					android.graphics.Paint.FontMetricsInt arg = new android.graphics.Paint.FontMetricsInt
						();
					arg.top = obj.top;
					arg.ascent = obj.ascent;
					arg.descent = obj.descent;
					arg.bottom = obj.bottom;
					arg.leading = obj.leading;
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_android_graphics_Paint_FontMetricsInt_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_graphics_Paint_FontMetricsInt_destructor
					(System.IntPtr ptr);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					FontMetricsInt_Struct obj = (FontMetricsInt_Struct)Marshal.PtrToStructure(ptr, typeof(
						FontMetricsInt_Struct));
					if (obj._owner != 0x972f3813)
					{
						throw new System.InvalidOperationException();
					}
				}

				public static void FreeManagedPtr(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return;
					}
					android.graphics.Paint.FontMetricsInt.FontMetricsInt_Helper.FreeManagedPtr_inner(
						ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getFontMetricsInt(android.graphics.Paint.NativePaint
			 _instance, out System.IntPtr fmi);

		/// <summary>
		/// Return the font's interline spacing, given the Paint's settings for
		/// typeface, textSize, etc.
		/// </summary>
		/// <remarks>
		/// Return the font's interline spacing, given the Paint's settings for
		/// typeface, textSize, etc. If metrics is not null, return the fontmetric
		/// values in it. Note: all values have been converted to integers from
		/// floats, in such a way has to make the answers useful for both spacing
		/// and clipping. If you want more control over the rounding, call
		/// getFontMetrics().
		/// </remarks>
		/// <returns>the font's interline spacing.</returns>
		public virtual int getFontMetricsInt(android.graphics.Paint.FontMetricsInt fmi)
		{
			System.IntPtr fmi_ptr = System.IntPtr.Zero;
			try
			{
				int _retval = libxobotos_Paint_getFontMetricsInt(mNativePaint, out fmi_ptr);
				android.graphics.Paint.FontMetricsInt.FontMetricsInt_Helper.MarshalOut(fmi_ptr, fmi
					);
				return _retval;
			}
			finally
			{
				android.graphics.Paint.FontMetricsInt.FontMetricsInt_Helper.FreeNativePtr(fmi_ptr
					);
			}
		}

		public virtual android.graphics.Paint.FontMetricsInt getFontMetricsInt()
		{
			android.graphics.Paint.FontMetricsInt fm = new android.graphics.Paint.FontMetricsInt
				();
			getFontMetricsInt(fm);
			return fm;
		}

		/// <summary>
		/// Return the recommend line spacing based on the current typeface and
		/// text size.
		/// </summary>
		/// <remarks>
		/// Return the recommend line spacing based on the current typeface and
		/// text size.
		/// </remarks>
		/// <returns>
		/// recommend line spacing based on the current typeface and
		/// text size.
		/// </returns>
		public virtual float getFontSpacing()
		{
			return getFontMetrics(null);
		}

		/// <summary>Return the width of the text.</summary>
		/// <remarks>Return the width of the text.</remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="index">The index of the first character to start measuring</param>
		/// <param name="count">THe number of characters to measure, beginning with start</param>
		/// <returns>The width of the text</returns>
		public virtual float measureText(char[] text, int index, int count)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((index | count) < 0 || index + count > text.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || count == 0)
			{
				return 0f;
			}
			if (!mHasCompatScaling)
			{
				return native_measureText(text, index, count);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			float w = native_measureText(text, index, count);
			setTextSize(oldSize);
			return w * mInvCompatScaling;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_measureTextC(android.graphics.Paint.NativePaint
			 _instance, System.IntPtr text, int index, int count);

		private float native_measureText(char[] text, int index, int count)
		{
			Sharpen.INativeHandle text_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				return libxobotos_Paint_measureTextC(mNativePaint, text_handle.Address, index, count
					);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
			}
		}

		/// <summary>Return the width of the text.</summary>
		/// <remarks>Return the width of the text.</remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="start">The index of the first character to start measuring</param>
		/// <param name="end">1 beyond the index of the last character to measure</param>
		/// <returns>The width of the text</returns>
		public virtual float measureText(string text, int start, int end)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || start == end)
			{
				return 0f;
			}
			if (!mHasCompatScaling)
			{
				return native_measureText(text, start, end);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			float w = native_measureText(text, start, end);
			setTextSize(oldSize);
			return w * mInvCompatScaling;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_measureTextS(android.graphics.Paint.NativePaint
			 _instance, System.IntPtr text, int start, int end);

		private float native_measureText(string text, int start, int end)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				return libxobotos_Paint_measureTextS(mNativePaint, text_ptr, start, end);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
			}
		}

		/// <summary>Return the width of the text.</summary>
		/// <remarks>Return the width of the text.</remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <returns>The width of the text</returns>
		public virtual float measureText(string text)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if (text.Length == 0)
			{
				return 0f;
			}
			if (!mHasCompatScaling)
			{
				return native_measureText(text);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			float w = native_measureText(text);
			setTextSize(oldSize);
			return w * mInvCompatScaling;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_measureTextS2(android.graphics.Paint.NativePaint
			 _instance, System.IntPtr text);

		private float native_measureText(string text)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				return libxobotos_Paint_measureTextS2(mNativePaint, text_ptr);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
			}
		}

		/// <summary>Return the width of the text.</summary>
		/// <remarks>Return the width of the text.</remarks>
		/// <param name="text">The text to measure</param>
		/// <param name="start">The index of the first character to start measuring</param>
		/// <param name="end">1 beyond the index of the last character to measure</param>
		/// <returns>The width of the text</returns>
		public virtual float measureText(java.lang.CharSequence text, int start, int end)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || start == end)
			{
				return 0f;
			}
			if (java.lang.CharSequenceProxy.IsStringProxy(text))
			{
				return measureText(java.lang.CharSequenceProxy.UnWrap(text), start, end);
			}
			if (text is android.text.SpannedString || text is android.text.SpannableString)
			{
				return measureText(text.ToString(), start, end);
			}
			if (text is android.text.GraphicsOperations)
			{
				return ((android.text.GraphicsOperations)text).measureText(start, end, this);
			}
			char[] buf = android.graphics.TemporaryBuffer.obtain(end - start);
			android.text.TextUtils.getChars(text, start, end, buf, 0);
			float result = measureText(buf, 0, end - start);
			android.graphics.TemporaryBuffer.recycle(buf);
			return result;
		}

		/// <summary>Measure the text, stopping early if the measured width exceeds maxWidth.
		/// 	</summary>
		/// <remarks>
		/// Measure the text, stopping early if the measured width exceeds maxWidth.
		/// Return the number of chars that were measured, and if measuredWidth is
		/// not null, return in it the actual width measured.
		/// </remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="index">The offset into text to begin measuring at</param>
		/// <param name="count">
		/// The number of maximum number of entries to measure. If count
		/// is negative, then the characters are measured in reverse order.
		/// </param>
		/// <param name="maxWidth">The maximum width to accumulate.</param>
		/// <param name="measuredWidth">
		/// Optional. If not null, returns the actual width
		/// measured.
		/// </param>
		/// <returns>
		/// The number of chars that were measured. Will always be &lt;=
		/// abs(count).
		/// </returns>
		public virtual int breakText(char[] text, int index, int count, float maxWidth, float
			[] measuredWidth)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if (index < 0 || text.Length - index < System.Math.Abs(count))
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || count == 0)
			{
				return 0;
			}
			if (!mHasCompatScaling)
			{
				return native_breakText(text, index, count, maxWidth, measuredWidth);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			int res = native_breakText(text, index, count, maxWidth * mCompatScaling, measuredWidth
				);
			setTextSize(oldSize);
			if (measuredWidth != null)
			{
				measuredWidth[0] *= mInvCompatScaling;
			}
			return res;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_breakTextC(android.graphics.Paint.NativePaint
			 _instance, System.IntPtr text, int index, int count, float maxWidth, System.IntPtr
			 measuredWidth);

		private int native_breakText(char[] text, int index, int count, float maxWidth, float
			[] measuredWidth)
		{
			Sharpen.INativeHandle text_handle = null;
			Sharpen.INativeHandle measuredWidth_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				measuredWidth_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr
					(measuredWidth);
				return libxobotos_Paint_breakTextC(mNativePaint, text_handle.Address, index, count
					, maxWidth, measuredWidth_handle != null ? measuredWidth_handle.Address : System.IntPtr.Zero
					);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
				if (measuredWidth_handle != null)
				{
					measuredWidth_handle.Free();
				}
			}
		}

		/// <summary>Measure the text, stopping early if the measured width exceeds maxWidth.
		/// 	</summary>
		/// <remarks>
		/// Measure the text, stopping early if the measured width exceeds maxWidth.
		/// Return the number of chars that were measured, and if measuredWidth is
		/// not null, return in it the actual width measured.
		/// </remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="start">The offset into text to begin measuring at</param>
		/// <param name="end">The end of the text slice to measure.</param>
		/// <param name="measureForwards">
		/// If true, measure forwards, starting at start.
		/// Otherwise, measure backwards, starting with end.
		/// </param>
		/// <param name="maxWidth">The maximum width to accumulate.</param>
		/// <param name="measuredWidth">
		/// Optional. If not null, returns the actual width
		/// measured.
		/// </param>
		/// <returns>
		/// The number of chars that were measured. Will always be &lt;=
		/// abs(end - start).
		/// </returns>
		public virtual int breakText(java.lang.CharSequence text, int start, int end, bool
			 measureForwards, float maxWidth, float[] measuredWidth)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || start == end)
			{
				return 0;
			}
			if (start == 0 && java.lang.CharSequenceProxy.IsStringProxy(text) && end == text.
				Length)
			{
				return breakText(java.lang.CharSequenceProxy.UnWrap(text), measureForwards, maxWidth
					, measuredWidth);
			}
			char[] buf = android.graphics.TemporaryBuffer.obtain(end - start);
			int result;
			android.text.TextUtils.getChars(text, start, end, buf, 0);
			if (measureForwards)
			{
				result = breakText(buf, 0, end - start, maxWidth, measuredWidth);
			}
			else
			{
				result = breakText(buf, 0, -(end - start), maxWidth, measuredWidth);
			}
			android.graphics.TemporaryBuffer.recycle(buf);
			return result;
		}

		/// <summary>Measure the text, stopping early if the measured width exceeds maxWidth.
		/// 	</summary>
		/// <remarks>
		/// Measure the text, stopping early if the measured width exceeds maxWidth.
		/// Return the number of chars that were measured, and if measuredWidth is
		/// not null, return in it the actual width measured.
		/// </remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="measureForwards">
		/// If true, measure forwards, starting with the
		/// first character in the string. Otherwise,
		/// measure backwards, starting with the
		/// last character in the string.
		/// </param>
		/// <param name="maxWidth">The maximum width to accumulate.</param>
		/// <param name="measuredWidth">
		/// Optional. If not null, returns the actual width
		/// measured.
		/// </param>
		/// <returns>
		/// The number of chars that were measured. Will always be &lt;=
		/// abs(count).
		/// </returns>
		public virtual int breakText(string text, bool measureForwards, float maxWidth, float
			[] measuredWidth)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if (text.Length == 0)
			{
				return 0;
			}
			if (!mHasCompatScaling)
			{
				return native_breakText(text, measureForwards, maxWidth, measuredWidth);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			int res = native_breakText(text, measureForwards, maxWidth * mCompatScaling, measuredWidth
				);
			setTextSize(oldSize);
			if (measuredWidth != null)
			{
				measuredWidth[0] *= mInvCompatScaling;
			}
			return res;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_breakTextS(android.graphics.Paint.NativePaint
			 _instance, System.IntPtr text, bool measureForwards, float maxWidth, System.IntPtr
			 measuredWidth);

		private int native_breakText(string text, bool measureForwards, float maxWidth, float
			[] measuredWidth)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle measuredWidth_handle = null;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				measuredWidth_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr
					(measuredWidth);
				return libxobotos_Paint_breakTextS(mNativePaint, text_ptr, measureForwards, maxWidth
					, measuredWidth_handle != null ? measuredWidth_handle.Address : System.IntPtr.Zero
					);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
				if (measuredWidth_handle != null)
				{
					measuredWidth_handle.Free();
				}
			}
		}

		/// <summary>Return the advance widths for the characters in the string.</summary>
		/// <remarks>Return the advance widths for the characters in the string.</remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="index">The index of the first char to to measure</param>
		/// <param name="count">The number of chars starting with index to measure</param>
		/// <param name="widths">
		/// array to receive the advance widths of the characters.
		/// Must be at least a large as count.
		/// </param>
		/// <returns>the actual number of widths returned.</returns>
		public virtual int getTextWidths(char[] text, int index, int count, float[] widths
			)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((index | count) < 0 || index + count > text.Length || count > widths.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || count == 0)
			{
				return 0;
			}
			if (!mHasCompatScaling)
			{
				return native_getTextWidths(mNativePaint, text, index, count, widths);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			int res = native_getTextWidths(mNativePaint, text, index, count, widths);
			setTextSize(oldSize);
			{
				for (int i = 0; i < res; i++)
				{
					widths[i] *= mInvCompatScaling;
				}
			}
			return res;
		}

		/// <summary>Return the advance widths for the characters in the string.</summary>
		/// <remarks>Return the advance widths for the characters in the string.</remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="start">The index of the first char to to measure</param>
		/// <param name="end">The end of the text slice to measure</param>
		/// <param name="widths">
		/// array to receive the advance widths of the characters.
		/// Must be at least a large as (end - start).
		/// </param>
		/// <returns>the actual number of widths returned.</returns>
		public virtual int getTextWidths(java.lang.CharSequence text, int start, int end, 
			float[] widths)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (end - start > widths.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || start == end)
			{
				return 0;
			}
			if (java.lang.CharSequenceProxy.IsStringProxy(text))
			{
				return getTextWidths(java.lang.CharSequenceProxy.UnWrap(text), start, end, widths
					);
			}
			if (text is android.text.SpannedString || text is android.text.SpannableString)
			{
				return getTextWidths(text.ToString(), start, end, widths);
			}
			if (text is android.text.GraphicsOperations)
			{
				return ((android.text.GraphicsOperations)text).getTextWidths(start, end, widths, 
					this);
			}
			char[] buf = android.graphics.TemporaryBuffer.obtain(end - start);
			android.text.TextUtils.getChars(text, start, end, buf, 0);
			int result = getTextWidths(buf, 0, end - start, widths);
			android.graphics.TemporaryBuffer.recycle(buf);
			return result;
		}

		/// <summary>Return the advance widths for the characters in the string.</summary>
		/// <remarks>Return the advance widths for the characters in the string.</remarks>
		/// <param name="text">The text to measure. Cannot be null.</param>
		/// <param name="start">The index of the first char to to measure</param>
		/// <param name="end">The end of the text slice to measure</param>
		/// <param name="widths">
		/// array to receive the advance widths of the characters.
		/// Must be at least a large as the text.
		/// </param>
		/// <returns>the number of unichars in the specified text.</returns>
		public virtual int getTextWidths(string text, int start, int end, float[] widths)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (end - start > widths.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || start == end)
			{
				return 0;
			}
			if (!mHasCompatScaling)
			{
				return native_getTextWidths(mNativePaint, text, start, end, widths);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			int res = native_getTextWidths(mNativePaint, text, start, end, widths);
			setTextSize(oldSize);
			{
				for (int i = 0; i < res; i++)
				{
					widths[i] *= mInvCompatScaling;
				}
			}
			return res;
		}

		/// <summary>Return the advance widths for the characters in the string.</summary>
		/// <remarks>Return the advance widths for the characters in the string.</remarks>
		/// <param name="text">The text to measure</param>
		/// <param name="widths">
		/// array to receive the advance widths of the characters.
		/// Must be at least a large as the text.
		/// </param>
		/// <returns>the number of unichars in the specified text.</returns>
		public virtual int getTextWidths(string text, float[] widths)
		{
			return getTextWidths(text, 0, text.Length, widths);
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"This requires frameworks/base/core/jni/android/graphics/TextLayout.cpp."
			)]
		public virtual int getTextGlyphs(string text, int start, int end, int contextStart
			, int contextEnd, int flags, char[] glyphs)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Convenience overload that takes a char array instead of a
		/// String.
		/// </summary>
		/// <remarks>
		/// Convenience overload that takes a char array instead of a
		/// String.
		/// </remarks>
		/// <seealso cref="getTextRunAdvances(string, int, int, int, int, int, float[], int)"
		/// 	>getTextRunAdvances(string, int, int, int, int, int, float[], int)</seealso>
		/// <hide></hide>
		public virtual float getTextRunAdvances(char[] chars, int index, int count, int contextIndex
			, int contextCount, int flags, float[] advances, int advancesIndex)
		{
			return getTextRunAdvances(chars, index, count, contextIndex, contextCount, flags, 
				advances, advancesIndex, 0);
		}

		/// <summary>
		/// Convenience overload that takes a char array instead of a
		/// String.
		/// </summary>
		/// <remarks>
		/// Convenience overload that takes a char array instead of a
		/// String.
		/// </remarks>
		/// <seealso cref="getTextRunAdvances(string, int, int, int, int, int, float[], int, int)
		/// 	">getTextRunAdvances(string, int, int, int, int, int, float[], int, int)</seealso>
		/// <hide></hide>
		public virtual float getTextRunAdvances(char[] chars, int index, int count, int contextIndex
			, int contextCount, int flags, float[] advances, int advancesIndex, int reserved
			)
		{
			if (chars == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if (flags != DIRECTION_LTR && flags != DIRECTION_RTL)
			{
				throw new System.ArgumentException("unknown flags value: " + flags);
			}
			if ((index | count | contextIndex | contextCount | advancesIndex | (index - contextIndex
				) | (contextCount - count) | ((contextIndex + contextCount) - (index + count)) |
				 (chars.Length - (contextIndex + contextCount)) | (advances == null ? 0 : (advances
				.Length - (advancesIndex + count)))) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (chars.Length == 0 || count == 0)
			{
				return 0f;
			}
			if (!mHasCompatScaling)
			{
				return native_getTextRunAdvances(mNativePaint, chars, index, count, contextIndex, 
					contextCount, flags, advances, advancesIndex, reserved);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			float res = native_getTextRunAdvances(mNativePaint, chars, index, count, contextIndex
				, contextCount, flags, advances, advancesIndex, reserved);
			setTextSize(oldSize);
			if (advances != null)
			{
				{
					int i = advancesIndex;
					int e = i + count;
					for (; i < e; i++)
					{
						advances[i] *= mInvCompatScaling;
					}
				}
			}
			return res * mInvCompatScaling;
		}

		// assume errors are not significant
		/// <summary>
		/// Convenience overload that takes a CharSequence instead of a
		/// String.
		/// </summary>
		/// <remarks>
		/// Convenience overload that takes a CharSequence instead of a
		/// String.
		/// </remarks>
		/// <seealso cref="getTextRunAdvances(string, int, int, int, int, int, float[], int)"
		/// 	>getTextRunAdvances(string, int, int, int, int, int, float[], int)</seealso>
		/// <hide></hide>
		public virtual float getTextRunAdvances(java.lang.CharSequence text, int start, int
			 end, int contextStart, int contextEnd, int flags, float[] advances, int advancesIndex
			)
		{
			return getTextRunAdvances(text, start, end, contextStart, contextEnd, flags, advances
				, advancesIndex, 0);
		}

		/// <summary>
		/// Convenience overload that takes a CharSequence instead of a
		/// String.
		/// </summary>
		/// <remarks>
		/// Convenience overload that takes a CharSequence instead of a
		/// String.
		/// </remarks>
		/// <seealso cref="getTextRunAdvances(string, int, int, int, int, int, float[], int)"
		/// 	>getTextRunAdvances(string, int, int, int, int, int, float[], int)</seealso>
		/// <hide></hide>
		public virtual float getTextRunAdvances(java.lang.CharSequence text, int start, int
			 end, int contextStart, int contextEnd, int flags, float[] advances, int advancesIndex
			, int reserved)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if ((start | end | contextStart | contextEnd | advancesIndex | (end - start) | (start
				 - contextStart) | (contextEnd - end) | (text.Length - contextEnd) | (advances ==
				 null ? 0 : (advances.Length - advancesIndex - (end - start)))) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (java.lang.CharSequenceProxy.IsStringProxy(text))
			{
				return getTextRunAdvances(java.lang.CharSequenceProxy.UnWrap(text), start, end, contextStart
					, contextEnd, flags, advances, advancesIndex, reserved);
			}
			if (text is android.text.SpannedString || text is android.text.SpannableString)
			{
				return getTextRunAdvances(text.ToString(), start, end, contextStart, contextEnd, 
					flags, advances, advancesIndex, reserved);
			}
			if (text is android.text.GraphicsOperations)
			{
				return ((android.text.GraphicsOperations)text).getTextRunAdvances(start, end, contextStart
					, contextEnd, flags, advances, advancesIndex, this);
			}
			if (text.Length == 0 || end == start)
			{
				return 0f;
			}
			int contextLen = contextEnd - contextStart;
			int len = end - start;
			char[] buf = android.graphics.TemporaryBuffer.obtain(contextLen);
			android.text.TextUtils.getChars(text, contextStart, contextEnd, buf, 0);
			float result = getTextRunAdvances(buf, start - contextStart, len, 0, contextLen, 
				flags, advances, advancesIndex, reserved);
			android.graphics.TemporaryBuffer.recycle(buf);
			return result;
		}

		/// <summary>
		/// Returns the total advance width for the characters in the run
		/// between start and end, and if advances is not null, the advance
		/// assigned to each of these characters (java chars).
		/// </summary>
		/// <remarks>
		/// Returns the total advance width for the characters in the run
		/// between start and end, and if advances is not null, the advance
		/// assigned to each of these characters (java chars).
		/// <p>The trailing surrogate in a valid surrogate pair is assigned
		/// an advance of 0.  Thus the number of returned advances is
		/// always equal to count, not to the number of unicode codepoints
		/// represented by the run.
		/// <p>In the case of conjuncts or combining marks, the total
		/// advance is assigned to the first logical character, and the
		/// following characters are assigned an advance of 0.
		/// <p>This generates the sum of the advances of glyphs for
		/// characters in a reordered cluster as the width of the first
		/// logical character in the cluster, and 0 for the widths of all
		/// other characters in the cluster.  In effect, such clusters are
		/// treated like conjuncts.
		/// <p>The shaping bounds limit the amount of context available
		/// outside start and end that can be used for shaping analysis.
		/// These bounds typically reflect changes in bidi level or font
		/// metrics across which shaping does not occur.
		/// </remarks>
		/// <param name="text">the text to measure. Cannot be null.</param>
		/// <param name="start">the index of the first character to measure</param>
		/// <param name="end">the index past the last character to measure</param>
		/// <param name="contextStart">
		/// the index of the first character to use for shaping context,
		/// must be &lt;= start
		/// </param>
		/// <param name="contextEnd">
		/// the index past the last character to use for shaping context,
		/// must be &gt;= end
		/// </param>
		/// <param name="flags">
		/// the flags to control the advances, either
		/// <see cref="DIRECTION_LTR">DIRECTION_LTR</see>
		/// or
		/// <see cref="DIRECTION_RTL">DIRECTION_RTL</see>
		/// </param>
		/// <param name="advances">
		/// array to receive the advances, must have room for all advances,
		/// can be null if only total advance is needed
		/// </param>
		/// <param name="advancesIndex">
		/// the position in advances at which to put the
		/// advance corresponding to the character at start
		/// </param>
		/// <returns>the total advance</returns>
		/// <hide></hide>
		public virtual float getTextRunAdvances(string text, int start, int end, int contextStart
			, int contextEnd, int flags, float[] advances, int advancesIndex)
		{
			return getTextRunAdvances(text, start, end, contextStart, contextEnd, flags, advances
				, advancesIndex, 0);
		}

		/// <summary>
		/// Returns the total advance width for the characters in the run
		/// between start and end, and if advances is not null, the advance
		/// assigned to each of these characters (java chars).
		/// </summary>
		/// <remarks>
		/// Returns the total advance width for the characters in the run
		/// between start and end, and if advances is not null, the advance
		/// assigned to each of these characters (java chars).
		/// <p>The trailing surrogate in a valid surrogate pair is assigned
		/// an advance of 0.  Thus the number of returned advances is
		/// always equal to count, not to the number of unicode codepoints
		/// represented by the run.
		/// <p>In the case of conjuncts or combining marks, the total
		/// advance is assigned to the first logical character, and the
		/// following characters are assigned an advance of 0.
		/// <p>This generates the sum of the advances of glyphs for
		/// characters in a reordered cluster as the width of the first
		/// logical character in the cluster, and 0 for the widths of all
		/// other characters in the cluster.  In effect, such clusters are
		/// treated like conjuncts.
		/// <p>The shaping bounds limit the amount of context available
		/// outside start and end that can be used for shaping analysis.
		/// These bounds typically reflect changes in bidi level or font
		/// metrics across which shaping does not occur.
		/// </remarks>
		/// <param name="text">the text to measure. Cannot be null.</param>
		/// <param name="start">the index of the first character to measure</param>
		/// <param name="end">the index past the last character to measure</param>
		/// <param name="contextStart">
		/// the index of the first character to use for shaping context,
		/// must be &lt;= start
		/// </param>
		/// <param name="contextEnd">
		/// the index past the last character to use for shaping context,
		/// must be &gt;= end
		/// </param>
		/// <param name="flags">
		/// the flags to control the advances, either
		/// <see cref="DIRECTION_LTR">DIRECTION_LTR</see>
		/// or
		/// <see cref="DIRECTION_RTL">DIRECTION_RTL</see>
		/// </param>
		/// <param name="advances">
		/// array to receive the advances, must have room for all advances,
		/// can be null if only total advance is needed
		/// </param>
		/// <param name="advancesIndex">
		/// the position in advances at which to put the
		/// advance corresponding to the character at start
		/// </param>
		/// <param name="reserved">int reserved value</param>
		/// <returns>the total advance</returns>
		/// <hide></hide>
		public virtual float getTextRunAdvances(string text, int start, int end, int contextStart
			, int contextEnd, int flags, float[] advances, int advancesIndex, int reserved)
		{
			if (text == null)
			{
				throw new System.ArgumentException("text cannot be null");
			}
			if (flags != DIRECTION_LTR && flags != DIRECTION_RTL)
			{
				throw new System.ArgumentException("unknown flags value: " + flags);
			}
			if ((start | end | contextStart | contextEnd | advancesIndex | (end - start) | (start
				 - contextStart) | (contextEnd - end) | (text.Length - contextEnd) | (advances ==
				 null ? 0 : (advances.Length - advancesIndex - (end - start)))) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (text.Length == 0 || start == end)
			{
				return 0f;
			}
			if (!mHasCompatScaling)
			{
				return native_getTextRunAdvances(mNativePaint, text, start, end, contextStart, contextEnd
					, flags, advances, advancesIndex, reserved);
			}
			float oldSize = getTextSize();
			setTextSize(oldSize * mCompatScaling);
			float totalAdvance = native_getTextRunAdvances(mNativePaint, text, start, end, contextStart
				, contextEnd, flags, advances, advancesIndex, reserved);
			setTextSize(oldSize);
			if (advances != null)
			{
				{
					int i = advancesIndex;
					int e = i + (end - start);
					for (; i < e; i++)
					{
						advances[i] *= mInvCompatScaling;
					}
				}
			}
			return totalAdvance * mInvCompatScaling;
		}

		// assume errors are insignificant
		/// <summary>Returns the next cursor position in the run.</summary>
		/// <remarks>
		/// Returns the next cursor position in the run.  This avoids placing the
		/// cursor between surrogates, between characters that form conjuncts,
		/// between base characters and combining marks, or within a reordering
		/// cluster.
		/// <p>ContextStart and offset are relative to the start of text.
		/// The context is the shaping context for cursor movement, generally
		/// the bounds of the metric span enclosing the cursor in the direction of
		/// movement.
		/// <p>If cursorOpt is
		/// <see cref="CURSOR_AT">CURSOR_AT</see>
		/// and the offset is not a valid
		/// cursor position, this returns -1.  Otherwise this will never return a
		/// value before contextStart or after contextStart + contextLength.
		/// </remarks>
		/// <param name="text">the text</param>
		/// <param name="contextStart">the start of the context</param>
		/// <param name="contextLength">the length of the context</param>
		/// <param name="flags">
		/// either
		/// <see cref="DIRECTION_RTL">DIRECTION_RTL</see>
		/// or
		/// <see cref="DIRECTION_LTR">DIRECTION_LTR</see>
		/// </param>
		/// <param name="offset">the cursor position to move from</param>
		/// <param name="cursorOpt">
		/// how to move the cursor, one of
		/// <see cref="CURSOR_AFTER">CURSOR_AFTER</see>
		/// ,
		/// <see cref="CURSOR_AT_OR_AFTER">CURSOR_AT_OR_AFTER</see>
		/// ,
		/// <see cref="CURSOR_BEFORE">CURSOR_BEFORE</see>
		/// ,
		/// <see cref="CURSOR_AT_OR_BEFORE">CURSOR_AT_OR_BEFORE</see>
		/// , or
		/// <see cref="CURSOR_AT">CURSOR_AT</see>
		/// </param>
		/// <returns>the offset of the next position, or -1</returns>
		/// <hide></hide>
		public virtual int getTextRunCursor(char[] text, int contextStart, int contextLength
			, int flags, int offset, int cursorOpt)
		{
			int contextEnd = contextStart + contextLength;
			if (((contextStart | contextEnd | offset | (contextEnd - contextStart) | (offset 
				- contextStart) | (contextEnd - offset) | (text.Length - contextEnd) | cursorOpt
				) < 0) || cursorOpt > CURSOR_OPT_MAX_VALUE)
			{
				throw new System.IndexOutOfRangeException();
			}
			return native_getTextRunCursor(mNativePaint, text, contextStart, contextLength, flags
				, offset, cursorOpt);
		}

		/// <summary>Returns the next cursor position in the run.</summary>
		/// <remarks>
		/// Returns the next cursor position in the run.  This avoids placing the
		/// cursor between surrogates, between characters that form conjuncts,
		/// between base characters and combining marks, or within a reordering
		/// cluster.
		/// <p>ContextStart, contextEnd, and offset are relative to the start of
		/// text.  The context is the shaping context for cursor movement, generally
		/// the bounds of the metric span enclosing the cursor in the direction of
		/// movement.
		/// <p>If cursorOpt is
		/// <see cref="CURSOR_AT">CURSOR_AT</see>
		/// and the offset is not a valid
		/// cursor position, this returns -1.  Otherwise this will never return a
		/// value before contextStart or after contextEnd.
		/// </remarks>
		/// <param name="text">the text</param>
		/// <param name="contextStart">the start of the context</param>
		/// <param name="contextEnd">the end of the context</param>
		/// <param name="flags">
		/// either
		/// <see cref="DIRECTION_RTL">DIRECTION_RTL</see>
		/// or
		/// <see cref="DIRECTION_LTR">DIRECTION_LTR</see>
		/// </param>
		/// <param name="offset">the cursor position to move from</param>
		/// <param name="cursorOpt">
		/// how to move the cursor, one of
		/// <see cref="CURSOR_AFTER">CURSOR_AFTER</see>
		/// ,
		/// <see cref="CURSOR_AT_OR_AFTER">CURSOR_AT_OR_AFTER</see>
		/// ,
		/// <see cref="CURSOR_BEFORE">CURSOR_BEFORE</see>
		/// ,
		/// <see cref="CURSOR_AT_OR_BEFORE">CURSOR_AT_OR_BEFORE</see>
		/// , or
		/// <see cref="CURSOR_AT">CURSOR_AT</see>
		/// </param>
		/// <returns>the offset of the next position, or -1</returns>
		/// <hide></hide>
		public virtual int getTextRunCursor(java.lang.CharSequence text, int contextStart
			, int contextEnd, int flags, int offset, int cursorOpt)
		{
			if (java.lang.CharSequenceProxy.IsStringProxy(text) || text is android.text.SpannedString
				 || text is android.text.SpannableString)
			{
				return getTextRunCursor(text.ToString(), contextStart, contextEnd, flags, offset, 
					cursorOpt);
			}
			if (text is android.text.GraphicsOperations)
			{
				return ((android.text.GraphicsOperations)text).getTextRunCursor(contextStart, contextEnd
					, flags, offset, cursorOpt, this);
			}
			int contextLen = contextEnd - contextStart;
			char[] buf = android.graphics.TemporaryBuffer.obtain(contextLen);
			android.text.TextUtils.getChars(text, contextStart, contextEnd, buf, 0);
			int result = getTextRunCursor(buf, 0, contextLen, flags, offset - contextStart, cursorOpt
				);
			android.graphics.TemporaryBuffer.recycle(buf);
			return result;
		}

		/// <summary>Returns the next cursor position in the run.</summary>
		/// <remarks>
		/// Returns the next cursor position in the run.  This avoids placing the
		/// cursor between surrogates, between characters that form conjuncts,
		/// between base characters and combining marks, or within a reordering
		/// cluster.
		/// <p>ContextStart, contextEnd, and offset are relative to the start of
		/// text.  The context is the shaping context for cursor movement, generally
		/// the bounds of the metric span enclosing the cursor in the direction of
		/// movement.
		/// <p>If cursorOpt is
		/// <see cref="CURSOR_AT">CURSOR_AT</see>
		/// and the offset is not a valid
		/// cursor position, this returns -1.  Otherwise this will never return a
		/// value before contextStart or after contextEnd.
		/// </remarks>
		/// <param name="text">the text</param>
		/// <param name="contextStart">the start of the context</param>
		/// <param name="contextEnd">the end of the context</param>
		/// <param name="flags">
		/// either
		/// <see cref="DIRECTION_RTL">DIRECTION_RTL</see>
		/// or
		/// <see cref="DIRECTION_LTR">DIRECTION_LTR</see>
		/// </param>
		/// <param name="offset">the cursor position to move from</param>
		/// <param name="cursorOpt">
		/// how to move the cursor, one of
		/// <see cref="CURSOR_AFTER">CURSOR_AFTER</see>
		/// ,
		/// <see cref="CURSOR_AT_OR_AFTER">CURSOR_AT_OR_AFTER</see>
		/// ,
		/// <see cref="CURSOR_BEFORE">CURSOR_BEFORE</see>
		/// ,
		/// <see cref="CURSOR_AT_OR_BEFORE">CURSOR_AT_OR_BEFORE</see>
		/// , or
		/// <see cref="CURSOR_AT">CURSOR_AT</see>
		/// </param>
		/// <returns>the offset of the next position, or -1</returns>
		/// <hide></hide>
		public virtual int getTextRunCursor(string text, int contextStart, int contextEnd
			, int flags, int offset, int cursorOpt)
		{
			if (((contextStart | contextEnd | offset | (contextEnd - contextStart) | (offset 
				- contextStart) | (contextEnd - offset) | (text.Length - contextEnd) | cursorOpt
				) < 0) || cursorOpt > CURSOR_OPT_MAX_VALUE)
			{
				throw new System.IndexOutOfRangeException();
			}
			return native_getTextRunCursor(mNativePaint, text, contextStart, contextEnd, flags
				, offset, cursorOpt);
		}

		/// <summary>Return the path (outline) for the specified text.</summary>
		/// <remarks>
		/// Return the path (outline) for the specified text.
		/// Note: just like Canvas.drawText, this will respect the Align setting in
		/// the paint.
		/// </remarks>
		/// <param name="text">The text to retrieve the path from</param>
		/// <param name="index">The index of the first character in text</param>
		/// <param name="count">The number of characterss starting with index</param>
		/// <param name="x">The x coordinate of the text's origin</param>
		/// <param name="y">The y coordinate of the text's origin</param>
		/// <param name="path">
		/// The path to receive the data describing the text. Must
		/// be allocated by the caller.
		/// </param>
		public virtual void getTextPath(char[] text, int index, int count, float x, float
			 y, android.graphics.Path path)
		{
			if ((index | count) < 0 || index + count > text.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_getTextPath(mNativePaint, mBidiFlags, text, index, count, x, y, path.nativeInstance
				);
		}

		/// <summary>Return the path (outline) for the specified text.</summary>
		/// <remarks>
		/// Return the path (outline) for the specified text.
		/// Note: just like Canvas.drawText, this will respect the Align setting
		/// in the paint.
		/// </remarks>
		/// <param name="text">The text to retrieve the path from</param>
		/// <param name="start">The first character in the text</param>
		/// <param name="end">1 past the last charcter in the text</param>
		/// <param name="x">The x coordinate of the text's origin</param>
		/// <param name="y">The y coordinate of the text's origin</param>
		/// <param name="path">
		/// The path to receive the data describing the text. Must
		/// be allocated by the caller.
		/// </param>
		public virtual void getTextPath(string text, int start, int end, float x, float y
			, android.graphics.Path path)
		{
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_getTextPath(mNativePaint, mBidiFlags, text, start, end, x, y, path.nativeInstance
				);
		}

		/// <summary>
		/// Return in bounds (allocated by the caller) the smallest rectangle that
		/// encloses all of the characters, with an implied origin at (0,0).
		/// </summary>
		/// <remarks>
		/// Return in bounds (allocated by the caller) the smallest rectangle that
		/// encloses all of the characters, with an implied origin at (0,0).
		/// </remarks>
		/// <param name="text">String to measure and return its bounds</param>
		/// <param name="start">Index of the first char in the string to measure</param>
		/// <param name="end">1 past the last char in the string measure</param>
		/// <param name="bounds">
		/// Returns the unioned bounds of all the text. Must be
		/// allocated by the caller.
		/// </param>
		public virtual void getTextBounds(string text, int start, int end, android.graphics.Rect
			 bounds)
		{
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (bounds == null)
			{
				throw new System.ArgumentNullException("need bounds Rect");
			}
			nativeGetStringBounds(mNativePaint, text, start, end, bounds);
		}

		/// <summary>
		/// Return in bounds (allocated by the caller) the smallest rectangle that
		/// encloses all of the characters, with an implied origin at (0,0).
		/// </summary>
		/// <remarks>
		/// Return in bounds (allocated by the caller) the smallest rectangle that
		/// encloses all of the characters, with an implied origin at (0,0).
		/// </remarks>
		/// <param name="text">Array of chars to measure and return their unioned bounds</param>
		/// <param name="index">Index of the first char in the array to measure</param>
		/// <param name="count">The number of chars, beginning at index, to measure</param>
		/// <param name="bounds">
		/// Returns the unioned bounds of all the text. Must be
		/// allocated by the caller.
		/// </param>
		public virtual void getTextBounds(char[] text, int index, int count, android.graphics.Rect
			 bounds)
		{
			if ((index | count) < 0 || index + count > text.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (bounds == null)
			{
				throw new System.ArgumentNullException("need bounds Rect");
			}
			nativeGetCharArrayBounds(mNativePaint, text, index, count, bounds);
		}

		~Paint()
		{
			try
			{
				finalizer(mNativePaint);
			}
			finally
			{
				;
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Paint.NativePaint libxobotos_Paint_init();

		private static android.graphics.Paint.NativePaint native_init()
		{
			return libxobotos_Paint_init();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Paint.NativePaint libxobotos_Paint_initWithPaint
			(android.graphics.Paint.NativePaint paint);

		private static android.graphics.Paint.NativePaint native_initWithPaint(android.graphics.Paint.NativePaint
			 paint)
		{
			return libxobotos_Paint_initWithPaint(paint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_reset(android.graphics.Paint.NativePaint
			 native_object);

		private static void native_reset(android.graphics.Paint.NativePaint native_object
			)
		{
			libxobotos_Paint_reset(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_set(android.graphics.Paint.NativePaint
			 native_dst, android.graphics.Paint.NativePaint native_src);

		private static void native_set(android.graphics.Paint.NativePaint native_dst, android.graphics.Paint.NativePaint
			 native_src)
		{
			libxobotos_Paint_set(native_dst, native_src);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getStyle(android.graphics.Paint.NativePaint
			 native_object);

		private static int native_getStyle(android.graphics.Paint.NativePaint native_object
			)
		{
			return libxobotos_Paint_getStyle(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setStyle(android.graphics.Paint.NativePaint
			 native_object, int style);

		private static void native_setStyle(android.graphics.Paint.NativePaint native_object
			, int style)
		{
			libxobotos_Paint_setStyle(native_object, style);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getStrokeCap(android.graphics.Paint.NativePaint
			 native_object);

		private static int native_getStrokeCap(android.graphics.Paint.NativePaint native_object
			)
		{
			return libxobotos_Paint_getStrokeCap(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setStrokeCap(android.graphics.Paint.NativePaint
			 native_object, int cap);

		private static void native_setStrokeCap(android.graphics.Paint.NativePaint native_object
			, int cap)
		{
			libxobotos_Paint_setStrokeCap(native_object, cap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getStrokeJoin(android.graphics.Paint.NativePaint
			 native_object);

		private static int native_getStrokeJoin(android.graphics.Paint.NativePaint native_object
			)
		{
			return libxobotos_Paint_getStrokeJoin(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setStrokeJoin(android.graphics.Paint.NativePaint
			 native_object, int join);

		private static void native_setStrokeJoin(android.graphics.Paint.NativePaint native_object
			, int join)
		{
			libxobotos_Paint_setStrokeJoin(native_object, join);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Paint_getFillPath(android.graphics.Paint.NativePaint
			 native_object, android.graphics.Path.NativePath src, android.graphics.Path.NativePath
			 dst);

		private static bool native_getFillPath(android.graphics.Paint.NativePaint native_object
			, android.graphics.Path.NativePath src, android.graphics.Path.NativePath dst)
		{
			return libxobotos_Paint_getFillPath(native_object, src, dst);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setShader(android.graphics.Paint.NativePaint
			 native_object, android.graphics.Shader.NativeShader shader);

		private static void native_setShader(android.graphics.Paint.NativePaint native_object
			, android.graphics.Shader.NativeShader shader)
		{
			libxobotos_Paint_setShader(native_object, shader != null ? shader : android.graphics.Shader.NativeShader
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setColorFilter(android.graphics.Paint.NativePaint
			 native_object, android.graphics.ColorFilter.NativeFilter filter);

		private static void native_setColorFilter(android.graphics.Paint.NativePaint native_object
			, android.graphics.ColorFilter.NativeFilter filter)
		{
			libxobotos_Paint_setColorFilter(native_object, filter != null ? filter : android.graphics.ColorFilter.NativeFilter
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setXfermode(android.graphics.Paint.NativePaint
			 native_object, android.graphics.Xfermode.NativeXfermode xfermode);

		private static void native_setXfermode(android.graphics.Paint.NativePaint native_object
			, android.graphics.Xfermode.NativeXfermode xfermode)
		{
			libxobotos_Paint_setXfermode(native_object, xfermode != null ? xfermode : android.graphics.Xfermode.NativeXfermode
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setPathEffect(android.graphics.Paint.NativePaint
			 native_object, android.graphics.PathEffect.NativePathEffect effect);

		private static void native_setPathEffect(android.graphics.Paint.NativePaint native_object
			, android.graphics.PathEffect.NativePathEffect effect)
		{
			libxobotos_Paint_setPathEffect(native_object, effect != null ? effect : android.graphics.PathEffect.NativePathEffect
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setMaskFilter(android.graphics.Paint.NativePaint
			 native_object, android.graphics.MaskFilter.NativeFilter maskfilter);

		private static void native_setMaskFilter(android.graphics.Paint.NativePaint native_object
			, android.graphics.MaskFilter.NativeFilter maskfilter)
		{
			libxobotos_Paint_setMaskFilter(native_object, maskfilter != null ? maskfilter : android.graphics.MaskFilter.NativeFilter
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setTypeface(android.graphics.Paint.NativePaint
			 native_object, android.graphics.Typeface.NativeTypeface typeface);

		private static void native_setTypeface(android.graphics.Paint.NativePaint native_object
			, android.graphics.Typeface.NativeTypeface typeface)
		{
			libxobotos_Paint_setTypeface(native_object, typeface != null ? typeface : android.graphics.Typeface.NativeTypeface
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setRasterizer(android.graphics.Paint.NativePaint
			 native_object, android.graphics.Rasterizer.NativeRasterizer rasterizer);

		private static void native_setRasterizer(android.graphics.Paint.NativePaint native_object
			, android.graphics.Rasterizer.NativeRasterizer rasterizer)
		{
			libxobotos_Paint_setRasterizer(native_object, rasterizer != null ? rasterizer : android.graphics.Rasterizer.NativeRasterizer
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getTextAlign(android.graphics.Paint.NativePaint
			 native_object);

		private static int native_getTextAlign(android.graphics.Paint.NativePaint native_object
			)
		{
			return libxobotos_Paint_getTextAlign(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_setTextAlign(android.graphics.Paint.NativePaint
			 native_object, int align);

		private static void native_setTextAlign(android.graphics.Paint.NativePaint native_object
			, int align)
		{
			libxobotos_Paint_setTextAlign(native_object, align);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getFontMetrics_0(android.graphics.Paint.NativePaint
			 native_paint, out System.IntPtr metrics);

		private static float native_getFontMetrics(android.graphics.Paint.NativePaint native_paint
			, android.graphics.Paint.FontMetrics metrics)
		{
			System.IntPtr metrics_ptr = System.IntPtr.Zero;
			try
			{
				float _retval = libxobotos_Paint_getFontMetrics_0(native_paint, out metrics_ptr);
				android.graphics.Paint.FontMetrics.FontMetrics_Helper.MarshalOut(metrics_ptr, metrics
					);
				return _retval;
			}
			finally
			{
				android.graphics.Paint.FontMetrics.FontMetrics_Helper.FreeNativePtr(metrics_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getTextWidthsC(android.graphics.Paint.NativePaint
			 native_object, System.IntPtr text, int index, int count, System.IntPtr widths);

		private static int native_getTextWidths(android.graphics.Paint.NativePaint native_object
			, char[] text, int index, int count, float[] widths)
		{
			Sharpen.INativeHandle text_handle = null;
			Sharpen.INativeHandle widths_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				widths_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(widths
					);
				return libxobotos_Paint_getTextWidthsC(native_object, text_handle.Address, index, 
					count, widths_handle.Address);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
				if (widths_handle != null)
				{
					widths_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getTextWidthsS(android.graphics.Paint.NativePaint
			 native_object, System.IntPtr text, int start, int end, System.IntPtr widths);

		private static int native_getTextWidths(android.graphics.Paint.NativePaint native_object
			, string text, int start, int end, float[] widths)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle widths_handle = null;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				widths_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(widths
					);
				return libxobotos_Paint_getTextWidthsS(native_object, text_ptr, start, end, widths_handle
					.Address);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
				if (widths_handle != null)
				{
					widths_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getTextRunAdvancesC(android.graphics.Paint.NativePaint
			 native_object, System.IntPtr text, int index, int count, int contextIndex, int 
			contextCount, int flags, System.IntPtr advances, int advancesIndex, int reserved
			);

		private static float native_getTextRunAdvances(android.graphics.Paint.NativePaint
			 native_object, char[] text, int index, int count, int contextIndex, int contextCount
			, int flags, float[] advances, int advancesIndex, int reserved)
		{
			Sharpen.INativeHandle text_handle = null;
			Sharpen.INativeHandle advances_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				advances_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(advances
					);
				return libxobotos_Paint_getTextRunAdvancesC(native_object, text_handle.Address, index
					, count, contextIndex, contextCount, flags, advances_handle != null ? advances_handle
					.Address : System.IntPtr.Zero, advancesIndex, reserved);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
				if (advances_handle != null)
				{
					advances_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Paint_getTextRunAdvancesS(android.graphics.Paint.NativePaint
			 native_object, System.IntPtr text, int start, int end, int contextStart, int contextEnd
			, int flags, System.IntPtr advances, int advancesIndex, int reserved);

		private static float native_getTextRunAdvances(android.graphics.Paint.NativePaint
			 native_object, string text, int start, int end, int contextStart, int contextEnd
			, int flags, float[] advances, int advancesIndex, int reserved)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle advances_handle = null;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				advances_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(advances
					);
				return libxobotos_Paint_getTextRunAdvancesS(native_object, text_ptr, start, end, 
					contextStart, contextEnd, flags, advances_handle != null ? advances_handle.Address
					 : System.IntPtr.Zero, advancesIndex, reserved);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
				if (advances_handle != null)
				{
					advances_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getTextRunCursorC(android.graphics.Paint.NativePaint
			 native_object, System.IntPtr text, int contextStart, int contextLength, int flags
			, int offset, int cursorOpt);

		private int native_getTextRunCursor(android.graphics.Paint.NativePaint native_object
			, char[] text, int contextStart, int contextLength, int flags, int offset, int cursorOpt
			)
		{
			Sharpen.INativeHandle text_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				return libxobotos_Paint_getTextRunCursorC(native_object, text_handle.Address, contextStart
					, contextLength, flags, offset, cursorOpt);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Paint_getTextRunCursorS(android.graphics.Paint.NativePaint
			 native_object, System.IntPtr text, int contextStart, int contextEnd, int flags, 
			int offset, int cursorOpt);

		private int native_getTextRunCursor(android.graphics.Paint.NativePaint native_object
			, string text, int contextStart, int contextEnd, int flags, int offset, int cursorOpt
			)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				return libxobotos_Paint_getTextRunCursorS(native_object, text_ptr, contextStart, 
					contextEnd, flags, offset, cursorOpt);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_getTextPathC(android.graphics.Paint.NativePaint
			 native_object, int bidiFlags, System.IntPtr text, int index, int count, float x
			, float y, android.graphics.Path.NativePath path);

		private static void native_getTextPath(android.graphics.Paint.NativePaint native_object
			, int bidiFlags, char[] text, int index, int count, float x, float y, android.graphics.Path.NativePath
			 path)
		{
			Sharpen.INativeHandle text_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				libxobotos_Paint_getTextPathC(native_object, bidiFlags, text_handle.Address, index
					, count, x, y, path);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_getTextPathS(android.graphics.Paint.NativePaint
			 native_object, int bidiFlags, System.IntPtr text, int start, int end, float x, 
			float y, android.graphics.Path.NativePath path);

		private static void native_getTextPath(android.graphics.Paint.NativePaint native_object
			, int bidiFlags, string text, int start, int end, float x, float y, android.graphics.Path.NativePath
			 path)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				libxobotos_Paint_getTextPathS(native_object, bidiFlags, text_ptr, start, end, x, 
					y, path);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_getStringBounds(android.graphics.Paint.NativePaint
			 nativePaint, System.IntPtr text, int start, int end, out System.IntPtr bounds);

		private static void nativeGetStringBounds(android.graphics.Paint.NativePaint nativePaint
			, string text, int start, int end, android.graphics.Rect bounds)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			System.IntPtr bounds_ptr = System.IntPtr.Zero;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				libxobotos_Paint_getStringBounds(nativePaint, text_ptr, start, end, out bounds_ptr
					);
				android.graphics.Rect.Rect_Helper.MarshalOut(bounds_ptr, bounds);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
				android.graphics.Rect.Rect_Helper.FreeNativePtr(bounds_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Paint_getCharArrayBounds(android.graphics.Paint.NativePaint
			 nativePaint, System.IntPtr text, int index, int count, out System.IntPtr bounds
			);

		private static void nativeGetCharArrayBounds(android.graphics.Paint.NativePaint nativePaint
			, char[] text, int index, int count, android.graphics.Rect bounds)
		{
			Sharpen.INativeHandle text_handle = null;
			System.IntPtr bounds_ptr = System.IntPtr.Zero;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				libxobotos_Paint_getCharArrayBounds(nativePaint, text_handle.Address, index, count
					, out bounds_ptr);
				android.graphics.Rect.Rect_Helper.MarshalOut(bounds_ptr, bounds);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
				android.graphics.Rect.Rect_Helper.FreeNativePtr(bounds_ptr);
			}
		}

		private static void finalizer(android.graphics.Paint.NativePaint nativePaint)
		{
			nativePaint.Dispose();
		}

		internal NativePaint nativeInstance
		{
			get
			{
				return mNativePaint;
			}
		}

		public void Dispose()
		{
			mNativePaint.Dispose();
		}

		internal class NativePaint : System.Runtime.InteropServices.SafeHandle
		{
			internal NativePaint() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativePaint(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Paint_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativePaint Zero = new NativePaint();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Paint_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
