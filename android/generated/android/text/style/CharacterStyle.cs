using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public abstract class CharacterStyle
	{
		[Sharpen.Stub]
		public abstract void updateDrawState(android.text.TextPaint tp);

		[Sharpen.Stub]
		public static android.text.style.CharacterStyle wrap(android.text.style.CharacterStyle
			 cs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.text.style.CharacterStyle getUnderlying()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class Passthrough : android.text.style.CharacterStyle
		{
			internal android.text.style.CharacterStyle mStyle;

			[Sharpen.Stub]
			public Passthrough(android.text.style.CharacterStyle cs)
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
			[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
			public override android.text.style.CharacterStyle getUnderlying()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
