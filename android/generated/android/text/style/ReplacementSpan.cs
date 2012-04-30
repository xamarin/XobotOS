using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public abstract class ReplacementSpan : android.text.style.MetricAffectingSpan
	{
		[Sharpen.Stub]
		public abstract int getSize(android.graphics.Paint paint, java.lang.CharSequence 
			text, int start, int end, android.graphics.Paint.FontMetricsInt fm);

		[Sharpen.Stub]
		public abstract void draw(android.graphics.Canvas canvas, java.lang.CharSequence 
			text, int start, int end, float x, int top, int y, int bottom, android.graphics.Paint
			 paint);

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.MetricAffectingSpan")]
		public override void updateMeasureState(android.text.TextPaint p)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
		public override void updateDrawState(android.text.TextPaint ds)
		{
			throw new System.NotImplementedException();
		}
	}
}
