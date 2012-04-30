using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public class HideReturnsTransformationMethod : android.text.method.ReplacementTransformationMethod
	{
		private static char[] ORIGINAL = new char[] { '\r' };

		private static char[] REPLACEMENT = new char[] { '\uFEFF' };

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.ReplacementTransformationMethod")]
		protected internal override char[] getOriginal()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.ReplacementTransformationMethod")]
		protected internal override char[] getReplacement()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.method.HideReturnsTransformationMethod getInstance()
		{
			throw new System.NotImplementedException();
		}

		private static android.text.method.HideReturnsTransformationMethod sInstance;
	}
}
