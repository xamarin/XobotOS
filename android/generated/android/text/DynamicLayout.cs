using Sharpen;

namespace android.text
{
	/// <summary>DynamicLayout is a text layout that updates itself as the text is edited.
	/// 	</summary>
	/// <remarks>
	/// DynamicLayout is a text layout that updates itself as the text is edited.
	/// <p>This is used by widgets to control text layout. You should not need
	/// to use this class directly unless you are implementing your own widget
	/// or custom display object, or need to call
	/// <see cref="android.graphics.Canvas.drawText(java.lang.CharSequence, int, int, float, float, android.graphics.Paint)
	/// 	">Canvas.drawText()</see>
	/// directly.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class DynamicLayout : android.text.Layout
	{
		internal const int PRIORITY = 128;

		/// <summary>
		/// Make a layout for the specified text that will be updated as
		/// the text is changed.
		/// </summary>
		/// <remarks>
		/// Make a layout for the specified text that will be updated as
		/// the text is changed.
		/// </remarks>
		public DynamicLayout(java.lang.CharSequence @base, android.text.TextPaint paint, 
			int width, android.text.Layout.Alignment? align, float spacingmult, float spacingadd
			, bool includepad) : this(@base, @base, paint, width, align, spacingmult, spacingadd
			, includepad)
		{
		}

		/// <summary>
		/// Make a layout for the transformed text (password transformation
		/// being the primary example of a transformation)
		/// that will be updated as the base text is changed.
		/// </summary>
		/// <remarks>
		/// Make a layout for the transformed text (password transformation
		/// being the primary example of a transformation)
		/// that will be updated as the base text is changed.
		/// </remarks>
		public DynamicLayout(java.lang.CharSequence @base, java.lang.CharSequence display
			, android.text.TextPaint paint, int width, android.text.Layout.Alignment? align, 
			float spacingmult, float spacingadd, bool includepad) : this(@base, display, paint
			, width, align, spacingmult, spacingadd, includepad, null, 0)
		{
		}

		/// <summary>
		/// Make a layout for the transformed text (password transformation
		/// being the primary example of a transformation)
		/// that will be updated as the base text is changed.
		/// </summary>
		/// <remarks>
		/// Make a layout for the transformed text (password transformation
		/// being the primary example of a transformation)
		/// that will be updated as the base text is changed.
		/// If ellipsize is non-null, the Layout will ellipsize the text
		/// down to ellipsizedWidth.
		/// </remarks>
		public DynamicLayout(java.lang.CharSequence @base, java.lang.CharSequence display
			, android.text.TextPaint paint, int width, android.text.Layout.Alignment? align, 
			float spacingmult, float spacingadd, bool includepad, android.text.TextUtils.TruncateAt
			? ellipsize_1, int ellipsizedWidth) : this(@base, display, paint, width, align, 
			android.text.TextDirectionHeuristics.FIRSTSTRONG_LTR, spacingmult, spacingadd, includepad
			, ellipsize_1, ellipsizedWidth)
		{
		}

		/// <summary>
		/// Make a layout for the transformed text (password transformation
		/// being the primary example of a transformation)
		/// that will be updated as the base text is changed.
		/// </summary>
		/// <remarks>
		/// Make a layout for the transformed text (password transformation
		/// being the primary example of a transformation)
		/// that will be updated as the base text is changed.
		/// If ellipsize is non-null, the Layout will ellipsize the text
		/// down to ellipsizedWidth.
		/// *
		/// *@hide
		/// </remarks>
		public DynamicLayout(java.lang.CharSequence @base, java.lang.CharSequence display
			, android.text.TextPaint paint, int width, android.text.Layout.Alignment? align, 
			android.text.TextDirectionHeuristic textDir, float spacingmult, float spacingadd
			, bool includepad, android.text.TextUtils.TruncateAt? ellipsize_1, int ellipsizedWidth
			) : base((ellipsize_1 == null) ? display : (display is android.text.Spanned) ? new 
			android.text.Layout.SpannedEllipsizer(display) : new android.text.Layout.Ellipsizer
			(display), paint, width, align, textDir, spacingmult, spacingadd)
		{
			mBase = @base;
			mDisplay = display;
			if (ellipsize_1 != null)
			{
				mInts = new android.text.PackedIntVector(COLUMNS_ELLIPSIZE);
				mEllipsizedWidth = ellipsizedWidth;
				mEllipsizeAt = ellipsize_1;
			}
			else
			{
				mInts = new android.text.PackedIntVector(COLUMNS_NORMAL);
				mEllipsizedWidth = width;
				mEllipsizeAt = null;
			}
			mObjects = new android.text.PackedObjectVector<android.text.Layout.Directions>(1);
			mIncludePad = includepad;
			if (ellipsize_1 != null)
			{
				android.text.Layout.Ellipsizer e = (android.text.Layout.Ellipsizer)getText();
				e.mLayout = this;
				e.mWidth = ellipsizedWidth;
				e.mMethod = ellipsize_1;
				mEllipsize = true;
			}
			// Initial state is a single line with 0 characters (0 to 0),
			// with top at 0 and bottom at whatever is natural, and
			// undefined ellipsis.
			int[] start;
			if (ellipsize_1 != null)
			{
				start = new int[COLUMNS_ELLIPSIZE];
				start[ELLIPSIS_START] = ELLIPSIS_UNDEFINED;
			}
			else
			{
				start = new int[COLUMNS_NORMAL];
			}
			android.text.Layout.Directions[] dirs = new android.text.Layout.Directions[] { DIRS_ALL_LEFT_TO_RIGHT
				 };
			android.graphics.Paint.FontMetricsInt fm = paint.getFontMetricsInt();
			int asc = fm.ascent;
			int desc = fm.descent;
			start[DIR] = DIR_LEFT_TO_RIGHT << DIR_SHIFT;
			start[TOP] = 0;
			start[DESCENT] = desc;
			mInts.insertAt(0, start);
			start[TOP] = desc - asc;
			mInts.insertAt(1, start);
			mObjects.insertAt(0, dirs);
			// Update from 0 characters to whatever the real text is
			reflow(@base, 0, 0, @base.Length);
			if (@base is android.text.Spannable)
			{
				if (mWatcher == null)
				{
					mWatcher = new android.text.DynamicLayout.ChangeWatcher(this);
				}
				// Strip out any watchers for other DynamicLayouts.
				android.text.Spannable sp = (android.text.Spannable)@base;
				android.text.DynamicLayout.ChangeWatcher[] spans = sp.getSpans<android.text.DynamicLayout
					.ChangeWatcher>(0, sp.Length);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						sp.removeSpan(spans[i]);
					}
				}
				sp.setSpan(mWatcher, 0, @base.Length, android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE
					 | (PRIORITY << android.text.SpannedClass.SPAN_PRIORITY_SHIFT));
			}
		}

		private void reflow(java.lang.CharSequence s, int where, int before, int after)
		{
			if (s != mBase)
			{
				return;
			}
			java.lang.CharSequence text = mDisplay;
			int len = text.Length;
			// seek back to the start of the paragraph
			int find = android.text.TextUtils.lastIndexOf(text, '\n', where - 1);
			if (find < 0)
			{
				find = 0;
			}
			else
			{
				find = find + 1;
			}
			{
				int diff = where - find;
				before += diff;
				after += diff;
				where -= diff;
			}
			// seek forward to the end of the paragraph
			int look = android.text.TextUtils.indexOf(text, '\n', where + after);
			if (look < 0)
			{
				look = len;
			}
			else
			{
				look++;
			}
			// we want the index after the \n
			int change = look - (where + after);
			before += change;
			after += change;
			// seek further out to cover anything that is forced to wrap together
			if (text is android.text.Spanned)
			{
				android.text.Spanned sp = (android.text.Spanned)text;
				bool again;
				do
				{
					again = false;
					object[] force = sp.getSpans<android.text.style.WrapTogetherSpan>(where, where + 
						after);
					{
						for (int i = 0; i < force.Length; i++)
						{
							int st = sp.getSpanStart(force[i]);
							int en = sp.getSpanEnd(force[i]);
							if (st < where)
							{
								again = true;
								int diff = where - st;
								before += diff;
								after += diff;
								where -= diff;
							}
							if (en > where + after)
							{
								again = true;
								int diff = en - (where + after);
								before += diff;
								after += diff;
							}
						}
					}
				}
				while (again);
			}
			// find affected region of old layout
			int startline = getLineForOffset(where);
			int startv = getLineTop(startline);
			int endline = getLineForOffset(where + before);
			if (where + after == len)
			{
				endline = getLineCount();
			}
			int endv = getLineTop(endline);
			bool islast = (endline == getLineCount());
			// generate new layout for affected text
			android.text.StaticLayout reflowed;
			lock (sLock)
			{
				reflowed = sStaticLayout;
				sStaticLayout = null;
			}
			if (reflowed == null)
			{
				reflowed = new android.text.StaticLayout(null);
			}
			else
			{
				reflowed.prepare();
			}
			reflowed.generate(text, where, where + after, getPaint(), getWidth(), getAlignment
				(), getTextDirectionHeuristic(), getSpacingMultiplier(), getSpacingAdd(), false, 
				true, mEllipsizedWidth, mEllipsizeAt);
			int n = reflowed.getLineCount();
			// If the new layout has a blank line at the end, but it is not
			// the very end of the buffer, then we already have a line that
			// starts there, so disregard the blank line.
			if (where + after != len && reflowed.getLineStart(n - 1) == where + after)
			{
				n--;
			}
			// remove affected lines from old layout
			mInts.deleteAt(startline, endline - startline);
			mObjects.deleteAt(startline, endline - startline);
			// adjust offsets in layout for new height and offsets
			int ht = reflowed.getLineTop(n);
			int toppad = 0;
			int botpad = 0;
			if (mIncludePad && startline == 0)
			{
				toppad = reflowed.getTopPadding();
				mTopPadding = toppad;
				ht -= toppad;
			}
			if (mIncludePad && islast)
			{
				botpad = reflowed.getBottomPadding();
				mBottomPadding = botpad;
				ht += botpad;
			}
			mInts.adjustValuesBelow(startline, START, after - before);
			mInts.adjustValuesBelow(startline, TOP, startv - endv + ht);
			// insert new layout
			int[] ints;
			if (mEllipsize)
			{
				ints = new int[COLUMNS_ELLIPSIZE];
				ints[ELLIPSIS_START] = ELLIPSIS_UNDEFINED;
			}
			else
			{
				ints = new int[COLUMNS_NORMAL];
			}
			android.text.Layout.Directions[] objects = new android.text.Layout.Directions[1];
			{
				for (int i_1 = 0; i_1 < n; i_1++)
				{
					ints[START] = reflowed.getLineStart(i_1) | (reflowed.getParagraphDirection(i_1) <<
						 DIR_SHIFT) | (reflowed.getLineContainsTab(i_1) ? TAB_MASK : 0);
					int top = reflowed.getLineTop(i_1) + startv;
					if (i_1 > 0)
					{
						top -= toppad;
					}
					ints[TOP] = top;
					int desc = reflowed.getLineDescent(i_1);
					if (i_1 == n - 1)
					{
						desc += botpad;
					}
					ints[DESCENT] = desc;
					objects[0] = reflowed.getLineDirections(i_1);
					if (mEllipsize)
					{
						ints[ELLIPSIS_START] = reflowed.getEllipsisStart(i_1);
						ints[ELLIPSIS_COUNT] = reflowed.getEllipsisCount(i_1);
					}
					mInts.insertAt(startline + i_1, ints);
					mObjects.insertAt(startline + i_1, objects);
				}
			}
			lock (sLock)
			{
				sStaticLayout = reflowed;
				reflowed.finish();
			}
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineCount()
		{
			return mInts.size() - 1;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineTop(int line)
		{
			return mInts.getValue(line, TOP);
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineDescent(int line)
		{
			return mInts.getValue(line, DESCENT);
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getLineStart(int line)
		{
			return mInts.getValue(line, START) & START_MASK;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override bool getLineContainsTab(int line)
		{
			return (mInts.getValue(line, TAB) & TAB_MASK) != 0;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getParagraphDirection(int line)
		{
			return mInts.getValue(line, DIR) >> DIR_SHIFT;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public sealed override android.text.Layout.Directions getLineDirections(int line)
		{
			return mObjects.getValue(line, 0);
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
		public override int getEllipsizedWidth()
		{
			return mEllipsizedWidth;
		}

		private class ChangeWatcher : android.text.TextWatcher, android.text.SpanWatcher
		{
			public ChangeWatcher(android.text.DynamicLayout layout)
			{
				mLayout = new java.lang.@ref.WeakReference<android.text.DynamicLayout>(layout);
			}

			internal void reflow(java.lang.CharSequence s, int where, int before, int after)
			{
				android.text.DynamicLayout ml = mLayout.get();
				if (ml != null)
				{
					ml.reflow(s, where, before, after);
				}
				else
				{
					if (s is android.text.Spannable)
					{
						((android.text.Spannable)s).removeSpan(this);
					}
				}
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void beforeTextChanged(java.lang.CharSequence s, int where, int before
				, int after)
			{
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void onTextChanged(java.lang.CharSequence s, int where, int before
				, int after)
			{
				reflow(s, where, before, after);
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void afterTextChanged(android.text.Editable s)
			{
			}

			[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
			public virtual void onSpanAdded(android.text.Spannable s, object o, int start, int
				 end)
			{
				if (o is android.text.style.UpdateLayout)
				{
					reflow(s, start, end - start, end - start);
				}
			}

			[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
			public virtual void onSpanRemoved(android.text.Spannable s, object o, int start, 
				int end)
			{
				if (o is android.text.style.UpdateLayout)
				{
					reflow(s, start, end - start, end - start);
				}
			}

			[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
			public virtual void onSpanChanged(android.text.Spannable s, object o, int start, 
				int end, int nstart, int nend)
			{
				if (o is android.text.style.UpdateLayout)
				{
					reflow(s, start, end - start, end - start);
					reflow(s, nstart, nend - nstart, nend - nstart);
				}
			}

			internal java.lang.@ref.WeakReference<android.text.DynamicLayout> mLayout;
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getEllipsisStart(int line)
		{
			if (mEllipsizeAt == null)
			{
				return 0;
			}
			return mInts.getValue(line, ELLIPSIS_START);
		}

		[Sharpen.OverridesMethod(@"android.text.Layout")]
		public override int getEllipsisCount(int line)
		{
			if (mEllipsizeAt == null)
			{
				return 0;
			}
			return mInts.getValue(line, ELLIPSIS_COUNT);
		}

		private java.lang.CharSequence mBase;

		private java.lang.CharSequence mDisplay;

		private android.text.DynamicLayout.ChangeWatcher mWatcher;

		private bool mIncludePad;

		private bool mEllipsize;

		private int mEllipsizedWidth;

		private android.text.TextUtils.TruncateAt? mEllipsizeAt;

		private android.text.PackedIntVector mInts;

		private android.text.PackedObjectVector<android.text.Layout.Directions> mObjects;

		private int mTopPadding;

		private int mBottomPadding;

		private static android.text.StaticLayout sStaticLayout = new android.text.StaticLayout
			(null);

		private static readonly object[] sLock = new object[0];

		internal const int START = 0;

		internal const int DIR = START;

		internal const int TAB = START;

		internal const int TOP = 1;

		internal const int DESCENT = 2;

		internal const int COLUMNS_NORMAL = 3;

		internal const int ELLIPSIS_START = 3;

		internal const int ELLIPSIS_COUNT = 4;

		internal const int COLUMNS_ELLIPSIZE = 5;

		internal const int START_MASK = unchecked((int)(0x1FFFFFFF));

		internal const int DIR_SHIFT = 30;

		internal const int TAB_MASK = unchecked((int)(0x20000000));

		internal const int ELLIPSIS_UNDEFINED = unchecked((int)(0x80000000));
	}
}
