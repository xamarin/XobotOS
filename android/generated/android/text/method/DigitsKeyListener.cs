using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public class DigitsKeyListener : android.text.method.NumberKeyListener
	{
		private char[] mAccepted;

		private bool mSign;

		private bool mDecimal;

		internal const int SIGN = 1;

		internal const int DECIMAL = 2;

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.NumberKeyListener")]
		protected internal override char[] getAcceptedChars()
		{
			throw new System.NotImplementedException();
		}

		private static readonly char[][] CHARACTERS = new char[][] { new char[] { '0', '1'
			, '2', '3', '4', '5', '6', '7', '8', '9' }, new char[] { '0', '1', '2', '3', '4'
			, '5', '6', '7', '8', '9', '-' }, new char[] { '0', '1', '2', '3', '4', '5', '6'
			, '7', '8', '9', '.' }, new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8'
			, '9', '-', '.' } };

		[Sharpen.Stub]
		public DigitsKeyListener() : this(false, false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DigitsKeyListener(bool sign, bool @decimal)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.method.DigitsKeyListener getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.method.DigitsKeyListener getInstance(bool sign, bool @decimal
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.method.DigitsKeyListener getInstance(string accepted)
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
		public override java.lang.CharSequence filter(java.lang.CharSequence source, int 
			start, int end, android.text.Spanned dest, int dstart, int dend)
		{
			throw new System.NotImplementedException();
		}

		private static android.text.method.DigitsKeyListener[] sInstance = new android.text.method.DigitsKeyListener
			[4];
	}
}
