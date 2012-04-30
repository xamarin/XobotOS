using Sharpen;

namespace android.text
{
	/// <summary>
	/// A BoringLayout is a very simple Layout implementation for text that
	/// fits on a single line and is all left-to-right characters.
	/// </summary>
	/// <remarks>
	/// A BoringLayout is a very simple Layout implementation for text that
	/// fits on a single line and is all left-to-right characters.
	/// You will probably never want to make one of these yourself;
	/// if you do, be sure to call
	/// <see cref="isBoring(java.lang.CharSequence, TextPaint)">isBoring(java.lang.CharSequence, TextPaint)
	/// 	</see>
	/// first to make sure
	/// the text meets the criteria.
	/// <p>This class is used by widgets to control text layout. You should not need
	/// to use this class directly unless you are implementing your own widget
	/// or custom display object, in which case
	/// you are encouraged to use a Layout instead of calling
	/// <see cref="android.graphics.Canvas.drawText(java.lang.CharSequence, int, int, float, float, android.graphics.Paint)
	/// 	">Canvas.drawText()</see>
	/// directly.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class BoringLayout : android.text.Layout, android.text.TextUtils.EllipsizeCallback
	{
		public static android.text.BoringLayout make(java.lang.CharSequence source, android.text.TextPaint
			 paint, int outerwidth, android.text.Layout.Alignment? align, float spacingmult, 
			float spacingadd, android.text.BoringLayout.Metrics metrics, bool includepad)
		{
			return new android.text.BoringLayout(source, paint, outerwidth, align, spacingmult
				, spacingadd, metrics, includepad);
		}

		public static android.text.BoringLayout make(java.lang.CharSequence source, android.text.TextPaint
			 paint, int outerwidth, android.text.Layout.Alignment? align, float spacingmult, 
			float spacingadd, android.text.BoringLayout.Metrics metrics, bool includepad, android.text.TextUtils.TruncateAt
			? ellipsize_1, int ellipsizedWidth)
		{
			return new android.text.BoringLayout(source, paint, outerwidth, align, spacingmult
				, spacingadd, metrics, includepad, ellipsize_1, ellipsizedWidth);
		}

		/// <summary>
		/// Returns a BoringLayout for the specified text, potentially reusing
		/// this one if it is already suitable.
		/// </summary>
		/// <remarks>
		/// Returns a BoringLayout for the specified text, potentially reusing
		/// this one if it is already suitable.  The caller must make sure that
		/// no one is still using this Layout.
		/// </remarks>
		public virtual android.text.BoringLayout replaceOrMake(java.lang.CharSequence source
			, android.text.TextPaint paint, int outerwidth, android.text.Layout.Alignment? align
			, float spacingmult, float spacingadd, android.text.BoringLayout.Metrics metrics
			, bool includepad)
		{
			replaceWith(source, paint, outerwidth, align, spacingmult, spacingadd);
			mEllipsizedWidth = outerwidth;
			mEllipsizedStart = 0;
			mEllipsizedCount = 0;
			init(source, paint, outerwidth, align, spacingmult, spacingadd, metrics, includepad
				, true);
			return this;
		}

		/// <summary>
		/// Returns a BoringLayout for the specified text, potentially reusing
		/// this one if it is already suitable.
		/// </summary>
		/// <remarks>
		/// Returns a BoringLayout for the specified text, potentially reusing
		/// this one if it is already suitable.  The caller must make sure that
		/// no one is still using this Layout.
		/// </remarks>
		public virtual android.text.BoringLayout replaceOrMake(java.lang.CharSequence source
			, android.text.TextPaint paint, int outerwidth, android.text.Layout.Alignment? align
			, float spacingmult, float spacingadd, android.text.BoringLayout.Metrics metrics
			, bool includepad, android.text.TextUtils.TruncateAt? ellipsize_1, int ellipsizedWidth
			)
		{
			bool trust;
			if (ellipsize_1 == null || ellipsize_1 == android.text.TextUtils.TruncateAt.MARQUEE)
			{
				replaceWith(source, paint, outerwidth, align, spacingmult, spacingadd);
				mEllipsizedWidth = outerwidth;
				mEllipsizedStart = 0;
				mEllipsizedCount = 0;
				trust = true;
			}
			else
			{
				replaceWith(android.text.TextUtils.ellipsize(source, paint, ellipsizedWidth, ellipsize_1
					, true, this), paint, outerwidth, align, spacingmult, spacingadd);
				mEllipsizedWidth = ellipsizedWidth;
				trust = false;
			}
			init(getText(), paint, outerwidth, align, spacingmult, spacingadd, metrics, includepad
				, trust);
			return this;
		}

		public BoringLayout(java.lang.CharSequence source, android.text.TextPaint paint, 
			int outerwidth, android.text.Layout.Alignment? align, float spacingmult, float spacingadd
			, android.text.BoringLayout.Metrics metrics, bool includepad) : base(source, paint
			, outerwidth, align, spacingmult, spacingadd)
		{
			mEllipsizedWidth = outerwidth;
			mEllipsizedStart = 0;
			mEllipsizedCount = 0;
			init(source, paint, outerwidth, align, spacingmult, spacingadd, metrics, includepad
				, true);
		}

		public BoringLayout(java.lang.CharSequence source, android.text.TextPaint paint, 
			int outerwidth, android.text.Layout.Alignment? align, float spacingmult, float spacingadd
			, android.text.BoringLayout.Metrics metrics, bool includepad, android.text.TextUtils.TruncateAt
			? ellipsize_1, int ellipsizedWidth) : base(source, paint, outerwidth, align, spacingmult
			, spacingadd)
		{
			bool trust;
			if (ellipsize_1 == null || ellipsize_1 == android.text.TextUtils.TruncateAt.MARQUEE)
			{
				mEllipsizedWidth = outerwidth;
				mEllipsizedStart = 0;
				mEllipsizedCount = 0;
				trust = true;
			}
			else
			{
				replaceWith(android.text.TextUtils.ellipsize(source, paint, ellipsizedWidth, ellipsize_1
					, true, this), paint, outerwidth, align, spacingmult, spacingadd);
				mEllipsizedWidth = ellipsizedWidth;
				trust = false;
			}
			init(getText(), paint, outerwidth, align, spacingmult, spacingadd, metrics, includepad
				, trust);
		}

		internal virtual void init(java.lang.CharSequence source, android.text.TextPaint 
			paint, int outerwidth, android.text.Layout.Alignment? align, float spacingmult, 
			float spacingadd, android.text.BoringLayout.Metrics metrics, bool includepad, bool
			 trustWidth)
		{
			int spacing;
			if (java.lang.CharSequenceProxy.IsStringProxy(source) && align == android.text.Layout.Alignment
				.ALIGN_NORMAL)
			{
				mDirect = source.ToString();
			}
			else
			{
				mDirect = null;
			}
			mPaint = paint;
			if (includepad)
			{
				spacing = metrics.bottom - metrics.top;
			}
			else
			{
				spacing = metrics.descent - metrics.ascent;
			}
			if (spacingmult != 1 || spacingadd != 0)
			{
				spacing = (int)(spacing * spacingmult + spacingadd + 0.5f);
			}
			mBottom = spacing;
			if (includepad)
			{
				mDesc = spacing + metrics.top;
			}
			else
			{
				mDesc = spacing + metrics.ascent;
			}
			if (trustWidth)
			{
				mMax = metrics.width;
			}
			else
			{
				android.text.TextLine line = android.text.TextLine.obtain();
				line.set(paint, source, 0, source.Length, android.text.Layout.DIR_LEFT_TO_RIGHT, 
					android.text.Layout.DIRS_ALL_LEFT_TO_RIGHT, false, null);
				mMax = (int)android.util.FloatMath.ceil(line.metrics(null));
				android.text.TextLine.recycle(line);
			}
			if (includepad)
			{
				mTopPadding = metrics.top - metrics.ascent;
				mBottomPadding = metrics.bottom - metrics.descent;
			}
		}

		/// <summary>Returns null if not boring; the width, ascent, and descent if boring.</summary>
		/// <remarks>Returns null if not boring; the width, ascent, and descent if boring.</remarks>
		public static android.text.BoringLayout.Metrics isBoring(java.lang.CharSequence text
			, android.text.TextPaint paint)
		{
			return isBoring(text, paint, android.text.TextDirectionHeuristics.FIRSTSTRONG_LTR
				, null);
		}

		/// <summary>Returns null if not boring; the width, ascent, and descent if boring.</summary>
		/// <remarks>Returns null if not boring; the width, ascent, and descent if boring.</remarks>
		/// <hide></hide>
		public static android.text.BoringLayout.Metrics isBoring(java.lang.CharSequence text
			, android.text.TextPaint paint, android.text.TextDirectionHeuristic textDir)
		{
			return isBoring(text, paint, textDir, null);
		}

		/// <summary>
		/// Returns null if not boring; the width, ascent, and descent in the
		/// provided Metrics object (or a new one if the provided one was null)
		/// if boring.
		/// </summary>
		/// <remarks>
		/// Returns null if not boring; the width, ascent, and descent in the
		/// provided Metrics object (or a new one if the provided one was null)
		/// if boring.
		/// </remarks>
		public static android.text.BoringLayout.Metrics isBoring(java.lang.CharSequence text
			, android.text.TextPaint paint, android.text.BoringLayout.Metrics metrics)
		{
			return isBoring(text, paint, android.text.TextDirectionHeuristics.FIRSTSTRONG_LTR
				, metrics);
		}

		/// <summary>
		/// Returns null if not boring; the width, ascent, and descent in the
		/// provided Metrics object (or a new one if the provided one was null)
		/// if boring.
		/// </summary>
		/// <remarks>
		/// Returns null if not boring; the width, ascent, and descent in the
		/// provided Metrics object (or a new one if the provided one was null)
		/// if boring.
		/// </remarks>
		/// <hide></hide>
		public static android.text.BoringLayout.Metrics isBoring(java.lang.CharSequence text
			, android.text.TextPaint paint, android.text.TextDirectionHeuristic textDir, android.text.BoringLayout
			.Metrics metrics)
		{
			char[] temp = android.text.TextUtils.obtain(500);
			int length = text.Length;
			bool boring = true;
			{
				for (int i = 0; i < length; i += 500)
				{
					int j = i + 500;
					if (j > length)
					{
						j = length;
					}
					android.text.TextUtils.getChars(text, i, j, temp, 0);
					int n = j - i;
					{
						for (int a = 0; a < n; a++)
						{
							char c = temp[a];
							if (c == '\n' || c == '\t' || c >= FIRST_RIGHT_TO_LEFT)
							{
								boring = false;
								goto outer_break;
							}
						}
					}
					if (textDir != null && textDir.isRtl(temp, 0, n))
					{
						boring = false;
						goto outer_break;
					}
				}
outer_continue: ;
			}
outer_break: ;
			android.text.TextUtils.recycle(temp);
			if (boring && text is android.text.Spanned)
			{
				android.text.Spanned sp = (android.text.Spanned)text;
				object[] styles = sp.getSpans<android.text.style.ParagraphStyle>(0, length);
				if (styles.Length > 0)
				{
					boring = false;
				}
			}
			if (boring)
			{
				android.text.BoringLayout.Metrics fm = metrics;
				if (fm == null)
				{
					fm = new android.text.BoringLayout.Metrics();
				}
				android.text.TextLine line = android.text.TextLine.obtain();
				line.set(paint, text, 0, length, android.text.Layout.DIR_LEFT_TO_RIGHT, android.text.Layout
					.DIRS_ALL_LEFT_TO_RIGHT, false, null);
				fm.width = (int)android.util.FloatMath.ceil(line.metrics(fm));
				android.text.TextLine.recycle(line);
				return fm;
			}
			else
			{
				return null;
			}
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getHeight()
		{
			return mBottom;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineCount()
		{
			return 1;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineTop(int line)
		{
			if (line == 0)
			{
				return 0;
			}
			else
			{
				return mBottom;
			}
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineDescent(int line)
		{
			return mDesc;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineStart(int line)
		{
			if (line == 0)
			{
				return 0;
			}
			else
			{
				return getText().Length;
			}
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getParagraphDirection(int line)
		{
			return DIR_LEFT_TO_RIGHT;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override bool getLineContainsTab(int line)
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override float getLineMax(int line)
		{
			return mMax;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public sealed override android.text.Layout.Directions getLineDirections(int line)
		{
			return android.text.Layout.DIRS_ALL_LEFT_TO_RIGHT;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getTopPadding()
		{
			return mTopPadding;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getBottomPadding()
		{
			return mBottomPadding;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getEllipsisCount(int line)
		{
			return mEllipsizedCount;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getEllipsisStart(int line)
		{
			return mEllipsizedStart;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getEllipsizedWidth()
		{
			return mEllipsizedWidth;
		}

		// Override draw so it will be faster.
		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override void draw(android.graphics.Canvas c, android.graphics.Path highlight
			, android.graphics.Paint highlightpaint, int cursorOffset)
		{
			if (mDirect != null && highlight == null)
			{
				c.drawText(mDirect, 0, mBottom - mDesc, mPaint);
			}
			else
			{
				base.draw(c, highlight, highlightpaint, cursorOffset);
			}
		}

		/// <summary>Callback for the ellipsizer to report what region it ellipsized.</summary>
		/// <remarks>Callback for the ellipsizer to report what region it ellipsized.</remarks>
		[Sharpen.ImplementsInterface(@"android.text.TextUtils.EllipsizeCallback")]
		public virtual void ellipsized(int start, int end)
		{
			mEllipsizedStart = start;
			mEllipsizedCount = end - start;
		}

		internal const char FIRST_RIGHT_TO_LEFT = '\u0590';

		private string mDirect;

		private android.graphics.Paint mPaint;

		internal int mBottom;

		internal int mDesc;

		private int mTopPadding;

		private int mBottomPadding;

		private float mMax;

		private int mEllipsizedWidth;

		private int mEllipsizedStart;

		private int mEllipsizedCount;

		private static readonly android.text.TextPaint sTemp = new android.text.TextPaint
			();

		public class Metrics : android.graphics.Paint.FontMetricsInt
		{
			public int width;

			// for Direct
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return base.ToString() + " width=" + width;
			}
		}
	}
}
