using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public abstract class NumberKeyListener : android.text.method.BaseKeyListener, android.text.InputFilter
	{
		[Sharpen.Stub]
		protected internal abstract char[] getAcceptedChars();

		[Sharpen.Stub]
		protected internal virtual int lookup(android.view.KeyEvent @event, android.text.Spannable
			 content)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.InputFilter")]
		public virtual java.lang.CharSequence filter(java.lang.CharSequence source, int start
			, int end, android.text.Spanned dest, int dstart, int dend)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal static bool ok(char[] accept, char c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.MetaKeyKeyListener")]
		public override bool onKeyDown(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}
	}
}
