using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class ProgressDialog : android.app.AlertDialog
	{
		public const int STYLE_SPINNER = 0;

		public const int STYLE_HORIZONTAL = 1;

		private android.widget.ProgressBar mProgress;

		private android.widget.TextView mMessageView;

		private int mProgressStyle = STYLE_SPINNER;

		private android.widget.TextView mProgressNumber;

		private string mProgressNumberFormat;

		private android.widget.TextView mProgressPercent;

		private java.text.NumberFormat mProgressPercentFormat;

		private int mMax;

		private int mProgressVal;

		private int mSecondaryProgressVal;

		private int mIncrementBy;

		private int mIncrementSecondaryBy;

		private android.graphics.drawable.Drawable mProgressDrawable;

		private android.graphics.drawable.Drawable mIndeterminateDrawable;

		private java.lang.CharSequence mMessage;

		private bool mIndeterminate;

		private bool mHasStarted;

		private android.os.Handler mViewUpdateHandler;

		[Sharpen.Stub]
		public ProgressDialog(android.content.Context context) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ProgressDialog(android.content.Context context, int theme) : base(context, 
			theme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initFormats()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.ProgressDialog show(android.content.Context context, java.lang.CharSequence
			 title, java.lang.CharSequence message)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.ProgressDialog show(android.content.Context context, java.lang.CharSequence
			 title, java.lang.CharSequence message, bool indeterminate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.ProgressDialog show(android.content.Context context, java.lang.CharSequence
			 title, java.lang.CharSequence message, bool indeterminate, bool cancelable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.ProgressDialog show(android.content.Context context, java.lang.CharSequence
			 title, java.lang.CharSequence message, bool indeterminate, bool cancelable, android.content.DialogInterfaceClass
			.OnCancelListener cancelListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onStop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProgress(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSecondaryProgress(int secondaryProgress)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getProgress()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getSecondaryProgress()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMax()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMax(int max)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void incrementProgressBy(int diff)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void incrementSecondaryProgressBy(int diff)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProgressDrawable(android.graphics.drawable.Drawable d)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIndeterminateDrawable(android.graphics.drawable.Drawable d
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIndeterminate(bool indeterminate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isIndeterminate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.AlertDialog")]
		public override void setMessage(java.lang.CharSequence message)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProgressStyle(int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProgressNumberFormat(string format)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProgressPercentFormat(java.text.NumberFormat format)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onProgressChanged()
		{
			throw new System.NotImplementedException();
		}
	}
}
