using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public abstract class MetricAffectingSpan : android.text.style.CharacterStyle, android.text.style.UpdateLayout
	{
		[Sharpen.Stub]
		public abstract void updateMeasureState(android.text.TextPaint p);

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
		public override android.text.style.CharacterStyle getUnderlying()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class Passthrough : android.text.style.MetricAffectingSpan
		{
			private android.text.style.MetricAffectingSpan mStyle;

			[Sharpen.Stub]
			public Passthrough(android.text.style.MetricAffectingSpan cs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
			public override void updateDrawState(android.text.TextPaint tp)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.text.style.MetricAffectingSpan")]
			public override void updateMeasureState(android.text.TextPaint tp)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
			public override android.text.style.CharacterStyle getUnderlying()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
