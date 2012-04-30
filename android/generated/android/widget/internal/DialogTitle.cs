using Sharpen;

namespace android.widget.@internal
{
	/// <summary>
	/// Used by dialogs to change the font size and number of lines to try to fit
	/// the text to the available space.
	/// </summary>
	/// <remarks>
	/// Used by dialogs to change the font size and number of lines to try to fit
	/// the text to the available space.
	/// </remarks>
	[Sharpen.Sharpened]
	public class DialogTitle : android.widget.TextView
	{
		public DialogTitle(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
		}

		public DialogTitle(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
		}

		public DialogTitle(android.content.Context context) : base(context)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			android.text.Layout layout_1 = getLayout();
			if (layout_1 != null)
			{
				int lineCount = layout_1.getLineCount();
				if (lineCount > 0)
				{
					int ellipsisCount = layout_1.getEllipsisCount(lineCount - 1);
					if (ellipsisCount > 0)
					{
						setSingleLine(false);
						setMaxLines(2);
						android.content.res.TypedArray a = mContext.obtainStyledAttributes(null, android.R
							.styleable.TextAppearance, android.R.attr.textAppearanceMedium, android.R.style.
							TextAppearance_Medium);
						int textSize = a.getDimensionPixelSize(android.R.styleable.TextAppearance_textSize
							, 0);
						if (textSize != 0)
						{
							// textSize is already expressed in pixels
							setTextSize(android.util.TypedValue.COMPLEX_UNIT_PX, textSize);
						}
						a.recycle();
						base.onMeasure(widthMeasureSpec, heightMeasureSpec);
					}
				}
			}
		}
	}
}
