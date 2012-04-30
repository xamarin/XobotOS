using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public interface LineHeightSpan : android.text.style.ParagraphStyle, android.text.style.WrapTogetherSpan
	{
		[Sharpen.Stub]
		void chooseHeight(java.lang.CharSequence text, int start, int end, int spanstartv
			, int v, android.graphics.Paint.FontMetricsInt fm);
	}

	[Sharpen.Stub]
	public static class LineHeightSpanClass
	{
		[Sharpen.Stub]
		public interface WithDensity : android.text.style.LineHeightSpan
		{
			[Sharpen.Stub]
			void chooseHeight(java.lang.CharSequence text, int start, int end, int spanstartv
				, int v, android.graphics.Paint.FontMetricsInt fm, android.text.TextPaint paint);
		}
	}
}
