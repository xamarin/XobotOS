using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public abstract class ClickableSpan : android.text.style.CharacterStyle, android.text.style.UpdateAppearance
	{
		[Sharpen.Stub]
		public abstract void onClick(android.view.View widget);

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
		public override void updateDrawState(android.text.TextPaint ds)
		{
			throw new System.NotImplementedException();
		}
	}
}
