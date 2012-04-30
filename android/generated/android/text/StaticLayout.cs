using Sharpen;

namespace android.text
{
	/// <summary>
	/// StaticLayout is a Layout for text that will not be edited after it
	/// is laid out.
	/// </summary>
	/// <remarks>
	/// StaticLayout is a Layout for text that will not be edited after it
	/// is laid out.  Use
	/// <see cref="DynamicLayout">DynamicLayout</see>
	/// for text that may change.
	/// <p>This is used by widgets to control text layout. You should not need
	/// to use this class directly unless you are implementing your own widget
	/// or custom display object, or would be tempted to call
	/// <see cref="android.graphics.Canvas.drawText(java.lang.CharSequence, int, int, float, float, android.graphics.Paint)
	/// 	">Canvas.drawText()</see>
	/// directly.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class StaticLayout : android.text.Layout
	{
		internal const string TAG = "StaticLayout";

		public StaticLayout(java.lang.CharSequence source, android.text.TextPaint paint, 
			int width, android.text.Layout.Alignment? align, float spacingmult, float spacingadd
			, bool includepad) : this(source, 0, source.Length, paint, width, align, spacingmult
			, spacingadd, includepad)
		{
		}

		/// <hide></hide>
		public StaticLayout(java.lang.CharSequence source, android.text.TextPaint paint, 
			int width, android.text.Layout.Alignment? align, android.text.TextDirectionHeuristic
			 textDir, float spacingmult, float spacingadd, bool includepad) : this(source, 0
			, source.Length, paint, width, align, textDir, spacingmult, spacingadd, includepad
			)
		{
		}

		public StaticLayout(java.lang.CharSequence source, int bufstart, int bufend, android.text.TextPaint
			 paint, int outerwidth, android.text.Layout.Alignment? align, float spacingmult, 
			float spacingadd, bool includepad) : this(source, bufstart, bufend, paint, outerwidth
			, align, spacingmult, spacingadd, includepad, null, 0)
		{
		}

		/// <hide></hide>
		public StaticLayout(java.lang.CharSequence source, int bufstart, int bufend, android.text.TextPaint
			 paint, int outerwidth, android.text.Layout.Alignment? align, android.text.TextDirectionHeuristic
			 textDir, float spacingmult, float spacingadd, bool includepad) : this(source, bufstart
			, bufend, paint, outerwidth, align, textDir, spacingmult, spacingadd, includepad
			, null, 0, int.MaxValue)
		{
		}

		public StaticLayout(java.lang.CharSequence source, int bufstart, int bufend, android.text.TextPaint
			 paint, int outerwidth, android.text.Layout.Alignment? align, float spacingmult, 
			float spacingadd, bool includepad, android.text.TextUtils.TruncateAt? ellipsize_1
			, int ellipsizedWidth) : this(source, bufstart, bufend, paint, outerwidth, align
			, android.text.TextDirectionHeuristics.FIRSTSTRONG_LTR, spacingmult, spacingadd, 
			includepad, ellipsize_1, ellipsizedWidth, int.MaxValue)
		{
		}

		/// <hide></hide>
		public StaticLayout(java.lang.CharSequence source, int bufstart, int bufend, android.text.TextPaint
			 paint, int outerwidth, android.text.Layout.Alignment? align, android.text.TextDirectionHeuristic
			 textDir, float spacingmult, float spacingadd, bool includepad, android.text.TextUtils.TruncateAt
			? ellipsize_1, int ellipsizedWidth, int maxLines) : base((ellipsize_1 == null) ? 
			source : (source is android.text.Spanned) ? new android.text.Layout.SpannedEllipsizer
			(source) : new android.text.Layout.Ellipsizer(source), paint, outerwidth, align, 
			textDir, spacingmult, spacingadd)
		{
			if (ellipsize_1 != null)
			{
				android.text.Layout.Ellipsizer e = (android.text.Layout.Ellipsizer)getText();
				e.mLayout = this;
				e.mWidth = ellipsizedWidth;
				e.mMethod = ellipsize_1;
				mEllipsizedWidth = ellipsizedWidth;
				mColumns = COLUMNS_ELLIPSIZE;
			}
			else
			{
				mColumns = COLUMNS_NORMAL;
				mEllipsizedWidth = outerwidth;
			}
			mLines = new int[android.util.@internal.ArrayUtils.idealIntArraySize(2 * mColumns
				)];
			mLineDirections = new android.text.Layout.Directions[android.util.@internal.ArrayUtils
				.idealIntArraySize(2 * mColumns)];
			mMaximumVisibleLineCount = maxLines;
			mMeasured = android.text.MeasuredText.obtain();
			generate(source, bufstart, bufend, paint, outerwidth, align, textDir, spacingmult
				, spacingadd, includepad, includepad, ellipsizedWidth, ellipsize_1);
			mMeasured = android.text.MeasuredText.recycle(mMeasured);
			mFontMetricsInt = null;
		}

		internal StaticLayout(java.lang.CharSequence text) : base(text, null, 0, null, 0, 
			0)
		{
			mColumns = COLUMNS_ELLIPSIZE;
			mLines = new int[android.util.@internal.ArrayUtils.idealIntArraySize(2 * mColumns
				)];
			mLineDirections = new android.text.Layout.Directions[android.util.@internal.ArrayUtils
				.idealIntArraySize(2 * mColumns)];
			mMeasured = android.text.MeasuredText.obtain();
		}

		internal virtual void generate(java.lang.CharSequence source, int bufStart, int bufEnd
			, android.text.TextPaint paint, int outerWidth, android.text.Layout.Alignment? align
			, android.text.TextDirectionHeuristic textDir, float spacingmult, float spacingadd
			, bool includepad, bool trackpad, float ellipsizedWidth, android.text.TextUtils.TruncateAt
			? ellipsize_1)
		{
			mLineCount = 0;
			int v = 0;
			bool needMultiply = (spacingmult != 1 || spacingadd != 0);
			android.graphics.Paint.FontMetricsInt fm = mFontMetricsInt;
			int[] chooseHtv = null;
			android.text.MeasuredText measured = mMeasured;
			android.text.Spanned spanned = null;
			if (source is android.text.Spanned)
			{
				spanned = (android.text.Spanned)source;
			}
			int DEFAULT_DIR = DIR_LEFT_TO_RIGHT;
			// XXX
			int paraEnd;
			{
				for (int paraStart = bufStart; paraStart <= bufEnd; paraStart = paraEnd)
				{
					paraEnd = android.text.TextUtils.indexOf(source, CHAR_NEW_LINE, paraStart, bufEnd
						);
					if (paraEnd < 0)
					{
						paraEnd = bufEnd;
					}
					else
					{
						paraEnd++;
					}
					int firstWidthLineLimit = mLineCount + 1;
					int firstWidth = outerWidth;
					int restWidth = outerWidth;
					android.text.style.LineHeightSpan[] chooseHt = null;
					if (spanned != null)
					{
						android.text.style.LeadingMarginSpan[] sp = getParagraphSpans<android.text.style.LeadingMarginSpan
							>(spanned, paraStart, paraEnd);
						{
							for (int i = 0; i < sp.Length; i++)
							{
								android.text.style.LeadingMarginSpan lms = sp[i];
								firstWidth -= sp[i].getLeadingMargin(true);
								restWidth -= sp[i].getLeadingMargin(false);
								// LeadingMarginSpan2 is odd.  The count affects all
								// leading margin spans, not just this particular one,
								// and start from the top of the span, not the top of the
								// paragraph.
								if (lms is android.text.style.LeadingMarginSpanClass.LeadingMarginSpan2)
								{
									android.text.style.LeadingMarginSpanClass.LeadingMarginSpan2 lms2 = (android.text.style.LeadingMarginSpanClass
										.LeadingMarginSpan2)lms;
									int lmsFirstLine = getLineForOffset(spanned.getSpanStart(lms2));
									firstWidthLineLimit = lmsFirstLine + lms2.getLeadingMarginLineCount();
								}
							}
						}
						chooseHt = getParagraphSpans<android.text.style.LineHeightSpan>(spanned, paraStart
							, paraEnd);
						if (chooseHt.Length != 0)
						{
							if (chooseHtv == null || chooseHtv.Length < chooseHt.Length)
							{
								chooseHtv = new int[android.util.@internal.ArrayUtils.idealIntArraySize(chooseHt.
									Length)];
							}
							{
								for (int i_1 = 0; i_1 < chooseHt.Length; i_1++)
								{
									int o = spanned.getSpanStart(chooseHt[i_1]);
									if (o < paraStart)
									{
										// starts in this layout, before the
										// current paragraph
										chooseHtv[i_1] = getLineTop(getLineForOffset(o));
									}
									else
									{
										// starts in this paragraph
										chooseHtv[i_1] = v;
									}
								}
							}
						}
					}
					measured.setPara(source, paraStart, paraEnd, textDir);
					char[] chs = measured.mChars;
					float[] widths = measured.mWidths;
					byte[] chdirs = measured.mLevels;
					int dir = measured.mDir;
					bool easy = measured.mEasy;
					int width = firstWidth;
					float w = 0;
					int here = paraStart;
					int ok = paraStart;
					float okWidth = w;
					int okAscent = 0;
					int okDescent = 0;
					int okTop = 0;
					int okBottom = 0;
					int fit = paraStart;
					float fitWidth = w;
					int fitAscent = 0;
					int fitDescent = 0;
					int fitTop = 0;
					int fitBottom = 0;
					bool hasTabOrEmoji = false;
					bool hasTab = false;
					android.text.Layout.TabStops tabStops = null;
					{
						int spanStart = paraStart;
						int spanEnd = spanStart;
						int nextSpanStart;
						for (; spanStart < paraEnd; spanStart = nextSpanStart)
						{
							if (spanStart == spanEnd)
							{
								if (spanned == null)
								{
									spanEnd = paraEnd;
								}
								else
								{
									spanEnd = spanned.nextSpanTransition(spanStart, paraEnd, typeof(android.text.style.MetricAffectingSpan
										));
								}
								int spanLen = spanEnd - spanStart;
								if (spanned == null)
								{
									measured.addStyleRun(paint, spanLen, fm);
								}
								else
								{
									android.text.style.MetricAffectingSpan[] spans = spanned.getSpans<android.text.style.MetricAffectingSpan
										>(spanStart, spanEnd);
									spans = android.text.TextUtils.removeEmptySpans<android.text.style.MetricAffectingSpan
										>(spans, spanned);
									measured.addStyleRun(paint, spans, spanLen, fm);
								}
							}
							nextSpanStart = spanEnd;
							int fmTop = fm.top;
							int fmBottom = fm.bottom;
							int fmAscent = fm.ascent;
							int fmDescent = fm.descent;
							{
								for (int j = spanStart; j < spanEnd; j++)
								{
									char c = chs[j - paraStart];
									if (c == CHAR_NEW_LINE)
									{
									}
									else
									{
										// intentionally left empty
										if (c == CHAR_TAB)
										{
											if (hasTab == false)
											{
												hasTab = true;
												hasTabOrEmoji = true;
												if (spanned != null)
												{
													// First tab this para, check for tabstops
													android.text.style.TabStopSpan[] spans = getParagraphSpans<android.text.style.TabStopSpan
														>(spanned, paraStart, paraEnd);
													if (spans.Length > 0)
													{
														tabStops = new android.text.Layout.TabStops(TAB_INCREMENT, spans);
													}
												}
											}
											if (tabStops != null)
											{
												w = tabStops.nextTab(w);
											}
											else
											{
												w = android.text.Layout.TabStops.nextDefaultStop(w, TAB_INCREMENT);
											}
										}
										else
										{
											if (c >= CHAR_FIRST_HIGH_SURROGATE && c <= CHAR_LAST_LOW_SURROGATE && j + 1 < spanEnd)
											{
												int emoji = Sharpen.CharHelper.CodePointAt(chs, j - paraStart);
												if (emoji >= MIN_EMOJI && emoji <= MAX_EMOJI)
												{
													android.graphics.Bitmap bm = EMOJI_FACTORY.getBitmapFromAndroidPua(emoji);
													if (bm != null)
													{
														android.graphics.Paint whichPaint;
														if (spanned == null)
														{
															whichPaint = paint;
														}
														else
														{
															whichPaint = mWorkPaint;
														}
														float wid = bm.getWidth() * -whichPaint.ascent() / bm.getHeight();
														w += wid;
														hasTabOrEmoji = true;
														j++;
													}
													else
													{
														w += widths[j - paraStart];
													}
												}
												else
												{
													w += widths[j - paraStart];
												}
											}
											else
											{
												w += widths[j - paraStart];
											}
										}
									}
									// Log.e("text", "was " + before + " now " + w + " after " + c + " within " + width);
									if (w <= width)
									{
										fitWidth = w;
										fit = j + 1;
										if (fmTop < fitTop)
										{
											fitTop = fmTop;
										}
										if (fmAscent < fitAscent)
										{
											fitAscent = fmAscent;
										}
										if (fmDescent > fitDescent)
										{
											fitDescent = fmDescent;
										}
										if (fmBottom > fitBottom)
										{
											fitBottom = fmBottom;
										}
										if (c == CHAR_SPACE || c == CHAR_TAB || ((c == CHAR_DOT || c == CHAR_COMMA || c ==
											 CHAR_COLON || c == CHAR_SEMICOLON) && (j - 1 < here || !System.Char.IsDigit(chs
											[j - 1 - paraStart])) && (j + 1 >= spanEnd || !System.Char.IsDigit(chs[j + 1 - paraStart
											]))) || ((c == CHAR_SLASH || c == CHAR_HYPHEN) && (j + 1 >= spanEnd || !System.Char.IsDigit
											(chs[j + 1 - paraStart]))) || (c >= CHAR_FIRST_CJK && isIdeographic(c, true) && 
											j + 1 < spanEnd && isIdeographic(chs[j + 1 - paraStart], false)))
										{
											okWidth = w;
											ok = j + 1;
											if (fitTop < okTop)
											{
												okTop = fitTop;
											}
											if (fitAscent < okAscent)
											{
												okAscent = fitAscent;
											}
											if (fitDescent > okDescent)
											{
												okDescent = fitDescent;
											}
											if (fitBottom > okBottom)
											{
												okBottom = fitBottom;
											}
										}
									}
									else
									{
										bool moreChars = (j + 1 < spanEnd);
										if (ok != here)
										{
											// Log.e("text", "output ok " + here + " to " +ok);
											while (ok < spanEnd && chs[ok - paraStart] == CHAR_SPACE)
											{
												ok++;
											}
											v = @out(source, here, ok, okAscent, okDescent, okTop, okBottom, v, spacingmult, 
												spacingadd, chooseHt, chooseHtv, fm, hasTabOrEmoji, needMultiply, paraStart, chdirs
												, dir, easy, ok == bufEnd, includepad, trackpad, chs, widths, paraStart, ellipsize_1
												, ellipsizedWidth, okWidth, paint, moreChars);
											here = ok;
										}
										else
										{
											if (fit != here)
											{
												// Log.e("text", "output fit " + here + " to " +fit);
												v = @out(source, here, fit, fitAscent, fitDescent, fitTop, fitBottom, v, spacingmult
													, spacingadd, chooseHt, chooseHtv, fm, hasTabOrEmoji, needMultiply, paraStart, chdirs
													, dir, easy, fit == bufEnd, includepad, trackpad, chs, widths, paraStart, ellipsize_1
													, ellipsizedWidth, fitWidth, paint, moreChars);
												here = fit;
											}
											else
											{
												// Log.e("text", "output one " + here + " to " +(here + 1));
												// XXX not sure why the existing fm wasn't ok.
												// measureText(paint, mWorkPaint,
												//             source, here, here + 1, fm, tab,
												//             null);
												v = @out(source, here, here + 1, fm.ascent, fm.descent, fm.top, fm.bottom, v, spacingmult
													, spacingadd, chooseHt, chooseHtv, fm, hasTabOrEmoji, needMultiply, paraStart, chdirs
													, dir, easy, here + 1 == bufEnd, includepad, trackpad, chs, widths, paraStart, ellipsize_1
													, ellipsizedWidth, widths[here - paraStart], paint, moreChars);
												here = here + 1;
											}
										}
										if (here < spanStart)
										{
											// didn't output all the text for this span
											// we've measured the raw widths, though, so
											// just reset the start point
											j = nextSpanStart = here;
										}
										else
										{
											j = here - 1;
										}
										// continue looping
										ok = fit = here;
										w = 0;
										fitAscent = fitDescent = fitTop = fitBottom = 0;
										okAscent = okDescent = okTop = okBottom = 0;
										if (--firstWidthLineLimit <= 0)
										{
											width = restWidth;
										}
									}
									if (mLineCount >= mMaximumVisibleLineCount)
									{
										break;
									}
								}
							}
						}
					}
					if (paraEnd != here && mLineCount < mMaximumVisibleLineCount)
					{
						if ((fitTop | fitBottom | fitDescent | fitAscent) == 0)
						{
							paint.getFontMetricsInt(fm);
							fitTop = fm.top;
							fitBottom = fm.bottom;
							fitAscent = fm.ascent;
							fitDescent = fm.descent;
						}
						// Log.e("text", "output rest " + here + " to " + end);
						v = @out(source, here, paraEnd, fitAscent, fitDescent, fitTop, fitBottom, v, spacingmult
							, spacingadd, chooseHt, chooseHtv, fm, hasTabOrEmoji, needMultiply, paraStart, chdirs
							, dir, easy, paraEnd == bufEnd, includepad, trackpad, chs, widths, paraStart, ellipsize_1
							, ellipsizedWidth, w, paint, paraEnd != bufEnd);
					}
					paraStart = paraEnd;
					if (paraEnd == bufEnd)
					{
						break;
					}
				}
			}
			if ((bufEnd == bufStart || source[bufEnd - 1] == CHAR_NEW_LINE) && mLineCount < mMaximumVisibleLineCount)
			{
				// Log.e("text", "output last " + bufEnd);
				paint.getFontMetricsInt(fm);
				v = @out(source, bufEnd, bufEnd, fm.ascent, fm.descent, fm.top, fm.bottom, v, spacingmult
					, spacingadd, null, null, fm, false, needMultiply, bufEnd, null, DEFAULT_DIR, true
					, true, includepad, trackpad, null, null, bufStart, ellipsize_1, ellipsizedWidth
					, 0, paint, false);
			}
		}

		/// <summary>
		/// Returns true if the specified character is one of those specified
		/// as being Ideographic (class ID) by the Unicode Line Breaking Algorithm
		/// (http://www.unicode.org/unicode/reports/tr14/), and is therefore OK
		/// to break between a pair of.
		/// </summary>
		/// <remarks>
		/// Returns true if the specified character is one of those specified
		/// as being Ideographic (class ID) by the Unicode Line Breaking Algorithm
		/// (http://www.unicode.org/unicode/reports/tr14/), and is therefore OK
		/// to break between a pair of.
		/// </remarks>
		/// <param name="includeNonStarters">
		/// also return true for category NS
		/// (non-starters), which can be broken
		/// after but not before.
		/// </param>
		private static bool isIdeographic(char c, bool includeNonStarters)
		{
			if (c >= '\u2E80' && c <= '\u2FFF')
			{
				return true;
			}
			// CJK, KANGXI RADICALS, DESCRIPTION SYMBOLS
			if (c == '\u3000')
			{
				return true;
			}
			// IDEOGRAPHIC SPACE
			if (c >= '\u3040' && c <= '\u309F')
			{
				if (!includeNonStarters)
				{
					switch (c)
					{
						case '\u3041':
						case '\u3043':
						case '\u3045':
						case '\u3047':
						case '\u3049':
						case '\u3063':
						case '\u3083':
						case '\u3085':
						case '\u3087':
						case '\u308E':
						case '\u3095':
						case '\u3096':
						case '\u309B':
						case '\u309C':
						case '\u309D':
						case '\u309E':
						{
							//  # HIRAGANA LETTER SMALL A
							//  # HIRAGANA LETTER SMALL I
							//  # HIRAGANA LETTER SMALL U
							//  # HIRAGANA LETTER SMALL E
							//  # HIRAGANA LETTER SMALL O
							//  # HIRAGANA LETTER SMALL TU
							//  # HIRAGANA LETTER SMALL YA
							//  # HIRAGANA LETTER SMALL YU
							//  # HIRAGANA LETTER SMALL YO
							//  # HIRAGANA LETTER SMALL WA
							//  # HIRAGANA LETTER SMALL KA
							//  # HIRAGANA LETTER SMALL KE
							//  # KATAKANA-HIRAGANA VOICED SOUND MARK
							//  # KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
							//  # HIRAGANA ITERATION MARK
							//  # HIRAGANA VOICED ITERATION MARK
							return false;
						}
					}
				}
				return true;
			}
			// Hiragana (except small characters)
			if (c >= '\u30A0' && c <= '\u30FF')
			{
				if (!includeNonStarters)
				{
					switch (c)
					{
						case '\u30A0':
						case '\u30A1':
						case '\u30A3':
						case '\u30A5':
						case '\u30A7':
						case '\u30A9':
						case '\u30C3':
						case '\u30E3':
						case '\u30E5':
						case '\u30E7':
						case '\u30EE':
						case '\u30F5':
						case '\u30F6':
						case '\u30FB':
						case '\u30FC':
						case '\u30FD':
						case '\u30FE':
						{
							//  # KATAKANA-HIRAGANA DOUBLE HYPHEN
							//  # KATAKANA LETTER SMALL A
							//  # KATAKANA LETTER SMALL I
							//  # KATAKANA LETTER SMALL U
							//  # KATAKANA LETTER SMALL E
							//  # KATAKANA LETTER SMALL O
							//  # KATAKANA LETTER SMALL TU
							//  # KATAKANA LETTER SMALL YA
							//  # KATAKANA LETTER SMALL YU
							//  # KATAKANA LETTER SMALL YO
							//  # KATAKANA LETTER SMALL WA
							//  # KATAKANA LETTER SMALL KA
							//  # KATAKANA LETTER SMALL KE
							//  # KATAKANA MIDDLE DOT
							//  # KATAKANA-HIRAGANA PROLONGED SOUND MARK
							//  # KATAKANA ITERATION MARK
							//  # KATAKANA VOICED ITERATION MARK
							return false;
						}
					}
				}
				return true;
			}
			// Katakana (except small characters)
			if (c >= '\u3400' && c <= '\u4DB5')
			{
				return true;
			}
			// CJK UNIFIED IDEOGRAPHS EXTENSION A
			if (c >= '\u4E00' && c <= '\u9FBB')
			{
				return true;
			}
			// CJK UNIFIED IDEOGRAPHS
			if (c >= '\uF900' && c <= '\uFAD9')
			{
				return true;
			}
			// CJK COMPATIBILITY IDEOGRAPHS
			if (c >= '\uA000' && c <= '\uA48F')
			{
				return true;
			}
			// YI SYLLABLES
			if (c >= '\uA490' && c <= '\uA4CF')
			{
				return true;
			}
			// YI RADICALS
			if (c >= '\uFE62' && c <= '\uFE66')
			{
				return true;
			}
			// SMALL PLUS SIGN to SMALL EQUALS SIGN
			if (c >= '\uFF10' && c <= '\uFF19')
			{
				return true;
			}
			// WIDE DIGITS
			return false;
		}

		private int @out(java.lang.CharSequence text, int start, int end, int above, int 
			below, int top, int bottom, int v, float spacingmult, float spacingadd, android.text.style.LineHeightSpan
			[] chooseHt, int[] chooseHtv, android.graphics.Paint.FontMetricsInt fm, bool hasTabOrEmoji
			, bool needMultiply, int pstart, byte[] chdirs, int dir, bool easy, bool last, bool
			 includePad, bool trackPad, char[] chs, float[] widths, int widthStart, android.text.TextUtils.TruncateAt
			? ellipsize_1, float ellipsisWidth, float textWidth, android.text.TextPaint paint
			, bool moreChars)
		{
			int j = mLineCount;
			int off = j * mColumns;
			int want = off + mColumns + TOP;
			int[] lines = mLines;
			if (want >= lines.Length)
			{
				int nlen = android.util.@internal.ArrayUtils.idealIntArraySize(want + 1);
				int[] grow = new int[nlen];
				System.Array.Copy(lines, 0, grow, 0, lines.Length);
				mLines = grow;
				lines = grow;
				android.text.Layout.Directions[] grow2 = new android.text.Layout.Directions[nlen]
					;
				System.Array.Copy(mLineDirections, 0, grow2, 0, mLineDirections.Length);
				mLineDirections = grow2;
			}
			if (chooseHt != null)
			{
				fm.ascent = above;
				fm.descent = below;
				fm.top = top;
				fm.bottom = bottom;
				{
					for (int i = 0; i < chooseHt.Length; i++)
					{
						if (chooseHt[i] is android.text.style.LineHeightSpanClass.WithDensity)
						{
							((android.text.style.LineHeightSpanClass.WithDensity)chooseHt[i]).chooseHeight(text
								, start, end, chooseHtv[i], v, fm, paint);
						}
						else
						{
							chooseHt[i].chooseHeight(text, start, end, chooseHtv[i], v, fm);
						}
					}
				}
				above = fm.ascent;
				below = fm.descent;
				top = fm.top;
				bottom = fm.bottom;
			}
			if (j == 0)
			{
				if (trackPad)
				{
					mTopPadding = top - above;
				}
				if (includePad)
				{
					above = top;
				}
			}
			if (last)
			{
				if (trackPad)
				{
					mBottomPadding = bottom - below;
				}
				if (includePad)
				{
					below = bottom;
				}
			}
			int extra;
			if (needMultiply)
			{
				double ex = (below - above) * (spacingmult - 1) + spacingadd;
				if (ex >= 0)
				{
					extra = (int)(ex + EXTRA_ROUNDING);
				}
				else
				{
					extra = -(int)(-ex + EXTRA_ROUNDING);
				}
			}
			else
			{
				extra = 0;
			}
			lines[off + START] = start;
			lines[off + TOP] = v;
			lines[off + DESCENT] = below + extra;
			v += (below - above) + extra;
			lines[off + mColumns + START] = end;
			lines[off + mColumns + TOP] = v;
			if (hasTabOrEmoji)
			{
				lines[off + TAB] |= TAB_MASK;
			}
			lines[off + DIR] |= dir << DIR_SHIFT;
			android.text.Layout.Directions linedirs = DIRS_ALL_LEFT_TO_RIGHT;
			// easy means all chars < the first RTL, so no emoji, no nothing
			// XXX a run with no text or all spaces is easy but might be an empty
			// RTL paragraph.  Make sure easy is false if this is the case.
			if (easy)
			{
				mLineDirections[j] = linedirs;
			}
			else
			{
				mLineDirections[j] = android.text.AndroidBidi.directions(dir, chdirs, start - widthStart
					, chs, start - widthStart, end - start);
			}
			if (ellipsize_1 != null)
			{
				// If there is only one line, then do any type of ellipsis except when it is MARQUEE
				// if there are multiple lines, just allow END ellipsis on the last line
				bool firstLine = (j == 0);
				bool currentLineIsTheLastVisibleOne = (j + 1 == mMaximumVisibleLineCount);
				bool forceEllipsis = moreChars && (mLineCount + 1 == mMaximumVisibleLineCount);
				bool doEllipsis = (firstLine && !moreChars && ellipsize_1 != android.text.TextUtils.TruncateAt
					.MARQUEE) || (!firstLine && (currentLineIsTheLastVisibleOne || !moreChars) && ellipsize_1
					 == android.text.TextUtils.TruncateAt.END);
				if (doEllipsis)
				{
					calculateEllipsis(start, end, widths, widthStart, ellipsisWidth, ellipsize_1, j, 
						textWidth, paint, forceEllipsis);
				}
			}
			mLineCount++;
			return v;
		}

		private void calculateEllipsis(int lineStart, int lineEnd, float[] widths, int widthStart
			, float avail, android.text.TextUtils.TruncateAt? where, int line, float textWidth
			, android.text.TextPaint paint, bool forceEllipsis)
		{
			if (textWidth <= avail && !forceEllipsis)
			{
				// Everything fits!
				mLines[mColumns * line + ELLIPSIS_START] = 0;
				mLines[mColumns * line + ELLIPSIS_COUNT] = 0;
				return;
			}
			float ellipsisWidth = paint.measureText((where == android.text.TextUtils.TruncateAt
				.END_SMALL) ? ELLIPSIS_TWO_DOTS : ELLIPSIS_NORMAL);
			int ellipsisStart = 0;
			int ellipsisCount = 0;
			int len = lineEnd - lineStart;
			// We only support start ellipsis on a single line
			if (where == android.text.TextUtils.TruncateAt.START)
			{
				if (mMaximumVisibleLineCount == 1)
				{
					float sum = 0;
					int i;
					for (i = len; i >= 0; i--)
					{
						float w = widths[i - 1 + lineStart - widthStart];
						if (w + sum + ellipsisWidth > avail)
						{
							break;
						}
						sum += w;
					}
					ellipsisStart = 0;
					ellipsisCount = i;
				}
				else
				{
					if (android.util.Log.isLoggable(TAG, android.util.Log.WARN))
					{
						android.util.Log.w(TAG, "Start Ellipsis only supported with one line");
					}
				}
			}
			else
			{
				if (where == android.text.TextUtils.TruncateAt.END || where == android.text.TextUtils.TruncateAt
					.MARQUEE || where == android.text.TextUtils.TruncateAt.END_SMALL)
				{
					float sum = 0;
					int i;
					for (i = 0; i < len; i++)
					{
						float w = widths[i + lineStart - widthStart];
						if (w + sum + ellipsisWidth > avail)
						{
							break;
						}
						sum += w;
					}
					ellipsisStart = i;
					ellipsisCount = len - i;
					if (forceEllipsis && ellipsisCount == 0 && len > 0)
					{
						ellipsisStart = len - 1;
						ellipsisCount = 1;
					}
				}
				else
				{
					// where = TextUtils.TruncateAt.MIDDLE We only support middle ellipsis on a single line
					if (mMaximumVisibleLineCount == 1)
					{
						float lsum = 0;
						float rsum = 0;
						int left = 0;
						int right = len;
						float ravail = (avail - ellipsisWidth) / 2;
						for (right = len; right >= 0; right--)
						{
							float w = widths[right - 1 + lineStart - widthStart];
							if (w + rsum > ravail)
							{
								break;
							}
							rsum += w;
						}
						float lavail = avail - ellipsisWidth - rsum;
						for (left = 0; left < right; left++)
						{
							float w = widths[left + lineStart - widthStart];
							if (w + lsum > lavail)
							{
								break;
							}
							lsum += w;
						}
						ellipsisStart = left;
						ellipsisCount = right - left;
					}
					else
					{
						if (android.util.Log.isLoggable(TAG, android.util.Log.WARN))
						{
							android.util.Log.w(TAG, "Middle Ellipsis only supported with one line");
						}
					}
				}
			}
			mLines[mColumns * line + ELLIPSIS_START] = ellipsisStart;
			mLines[mColumns * line + ELLIPSIS_COUNT] = ellipsisCount;
		}

		// Override the base class so we can directly access our members,
		// rather than relying on member functions.
		// The logic mirrors that of Layout.getLineForVertical
		// FIXME: It may be faster to do a linear search for layouts without many lines.
		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineForVertical(int vertical)
		{
			int high = mLineCount;
			int low = -1;
			int guess;
			int[] lines = mLines;
			while (high - low > 1)
			{
				guess = (high + low) >> 1;
				if (lines[mColumns * guess + TOP] > vertical)
				{
					high = guess;
				}
				else
				{
					low = guess;
				}
			}
			if (low < 0)
			{
				return 0;
			}
			else
			{
				return low;
			}
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineCount()
		{
			return mLineCount;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineTop(int line)
		{
			int top = mLines[mColumns * line + TOP];
			if (mMaximumVisibleLineCount > 0 && line >= mMaximumVisibleLineCount && line != mLineCount)
			{
				top += getBottomPadding();
			}
			return top;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineDescent(int line)
		{
			int descent = mLines[mColumns * line + DESCENT];
			if (mMaximumVisibleLineCount > 0 && line >= mMaximumVisibleLineCount - 1 && line 
				!= mLineCount)
			{
				// -1 intended
				descent += getBottomPadding();
			}
			return descent;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineStart(int line)
		{
			return mLines[mColumns * line + START] & START_MASK;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getParagraphDirection(int line)
		{
			return mLines[mColumns * line + DIR] >> DIR_SHIFT;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override bool getLineContainsTab(int line)
		{
			return (mLines[mColumns * line + TAB] & TAB_MASK) != 0;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public sealed override android.text.Layout.Directions getLineDirections(int line)
		{
			return mLineDirections[line];
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
			if (mColumns < COLUMNS_ELLIPSIZE)
			{
				return 0;
			}
			return mLines[mColumns * line + ELLIPSIS_COUNT];
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getEllipsisStart(int line)
		{
			if (mColumns < COLUMNS_ELLIPSIZE)
			{
				return 0;
			}
			return mLines[mColumns * line + ELLIPSIS_START];
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getEllipsizedWidth()
		{
			return mEllipsizedWidth;
		}

		internal virtual void prepare()
		{
			mMeasured = android.text.MeasuredText.obtain();
		}

		internal virtual void finish()
		{
			mMeasured = android.text.MeasuredText.recycle(mMeasured);
		}

		private int mLineCount;

		private int mTopPadding;

		private int mBottomPadding;

		private int mColumns;

		private int mEllipsizedWidth;

		internal const int COLUMNS_NORMAL = 3;

		internal const int COLUMNS_ELLIPSIZE = 5;

		internal const int START = 0;

		internal const int DIR = START;

		internal const int TAB = START;

		internal const int TOP = 1;

		internal const int DESCENT = 2;

		internal const int ELLIPSIS_START = 3;

		internal const int ELLIPSIS_COUNT = 4;

		private int[] mLines;

		private android.text.Layout.Directions[] mLineDirections;

		private int mMaximumVisibleLineCount = int.MaxValue;

		internal const int START_MASK = unchecked((int)(0x1FFFFFFF));

		internal const int DIR_SHIFT = 30;

		internal const int TAB_MASK = unchecked((int)(0x20000000));

		internal const int TAB_INCREMENT = 20;

		internal const char CHAR_FIRST_CJK = '\u2E80';

		internal const char CHAR_NEW_LINE = '\n';

		internal const char CHAR_TAB = '\t';

		internal const char CHAR_SPACE = ' ';

		internal const char CHAR_DOT = '.';

		internal const char CHAR_COMMA = ',';

		internal const char CHAR_COLON = ':';

		internal const char CHAR_SEMICOLON = ';';

		internal const char CHAR_SLASH = '/';

		internal const char CHAR_HYPHEN = '-';

		internal const double EXTRA_ROUNDING = 0.5;

		internal const string ELLIPSIS_NORMAL = "\u2026";

		internal const string ELLIPSIS_TWO_DOTS = "\u2025";

		internal const int CHAR_FIRST_HIGH_SURROGATE = unchecked((int)(0xD800));

		internal const int CHAR_LAST_LOW_SURROGATE = unchecked((int)(0xDFFF));

		private android.text.MeasuredText mMeasured;

		private android.graphics.Paint.FontMetricsInt mFontMetricsInt = new android.graphics.Paint
			.FontMetricsInt();
		// same as Layout, but that's private
		// this is "..."
		// this is ".."
	}
}
