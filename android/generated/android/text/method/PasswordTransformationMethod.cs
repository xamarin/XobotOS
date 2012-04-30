using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public class PasswordTransformationMethod : android.text.method.TransformationMethod
		, android.text.TextWatcher
	{
		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.method.TransformationMethod")]
		public virtual java.lang.CharSequence getTransformation(java.lang.CharSequence source
			, android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.method.PasswordTransformationMethod getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
		public virtual void beforeTextChanged(java.lang.CharSequence s, int start, int count
			, int after)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
		public virtual void onTextChanged(java.lang.CharSequence s, int start, int before
			, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
		public virtual void afterTextChanged(android.text.Editable s)
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
		private static void removeVisibleSpans(android.text.Spannable sp)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class PasswordCharSequence : java.lang.CharSequence, android.text.GetChars
		{
			[Sharpen.Stub]
			public PasswordCharSequence(java.lang.CharSequence source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int Length
			{
				get
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public virtual char this[int i]
			{
				get
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
			public virtual java.lang.CharSequence SubSequence(int start, int end)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.GetChars")]
			public virtual void getChars(int start, int end, char[] dest, int off)
			{
				throw new System.NotImplementedException();
			}

			internal java.lang.CharSequence mSource;
		}

		[Sharpen.Stub]
		private class Visible : android.os.Handler, android.text.style.UpdateLayout, java.lang.Runnable
		{
			[Sharpen.Stub]
			public Visible(android.text.Spannable sp, android.text.method.PasswordTransformationMethod
				 ptm)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				throw new System.NotImplementedException();
			}

			internal android.text.Spannable mText;

			internal android.text.method.PasswordTransformationMethod mTransformer;
		}

		[Sharpen.Stub]
		private class ViewReference : java.lang.@ref.WeakReference<android.view.View>, android.text.NoCopySpan
		{
			[Sharpen.Stub]
			public ViewReference(android.view.View v) : base(v)
			{
				throw new System.NotImplementedException();
			}
		}

		private static android.text.method.PasswordTransformationMethod sInstance;

		private static char DOT = '\u2022';
	}
}
