using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public class DialerKeyListener : android.text.method.NumberKeyListener
	{
		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.NumberKeyListener")]
		protected internal override char[] getAcceptedChars()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.method.DialerKeyListener getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
		public override int getInputType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.NumberKeyListener")]
		protected internal override int lookup(android.view.KeyEvent @event, android.text.Spannable
			 content)
		{
			throw new System.NotImplementedException();
		}

		public static readonly char[] CHARACTERS = new char[] { '0', '1', '2', '3', '4', 
			'5', '6', '7', '8', '9', '#', '*', '+', '-', '(', ')', ',', '/', 'N', '.', ' ', 
			';' };

		private static android.text.method.DialerKeyListener sInstance;
	}
}
