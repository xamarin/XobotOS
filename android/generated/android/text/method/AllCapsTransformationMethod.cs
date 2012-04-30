using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public class AllCapsTransformationMethod : android.text.method.TransformationMethod2
	{
		internal const string TAG = "AllCapsTransformationMethod";

		private bool mEnabled;

		private System.Globalization.CultureInfo mLocale;

		[Sharpen.Stub]
		public AllCapsTransformationMethod(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.method.TransformationMethod")]
		public virtual java.lang.CharSequence getTransformation(java.lang.CharSequence source
			, android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.method.TransformationMethod")]
		public virtual void onFocusChanged(android.view.View view, java.lang.CharSequence
			 sourceText, bool focused, int direction, android.graphics.Rect previouslyFocusedRect
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.method.TransformationMethod2")]
		public virtual void setLengthChangesAllowed(bool allowLengthChanges)
		{
			throw new System.NotImplementedException();
		}
	}
}
