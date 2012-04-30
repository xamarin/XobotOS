using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public interface LineBackgroundSpan : android.text.style.ParagraphStyle
	{
		[Sharpen.Stub]
		void drawBackground(android.graphics.Canvas c, android.graphics.Paint p, int left
			, int right, int top, int baseline, int bottom, java.lang.CharSequence text, int
			 start, int end, int lnum);
	}
}
