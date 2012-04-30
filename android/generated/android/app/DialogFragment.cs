using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class DialogFragment : android.app.Fragment, android.content.DialogInterfaceClass
		.OnCancelListener, android.content.DialogInterfaceClass.OnDismissListener
	{
		public const int STYLE_NORMAL = 0;

		public const int STYLE_NO_TITLE = 1;

		public const int STYLE_NO_FRAME = 2;

		public const int STYLE_NO_INPUT = 3;

		internal const string SAVED_DIALOG_STATE_TAG = "android:savedDialogState";

		internal const string SAVED_STYLE = "android:style";

		internal const string SAVED_THEME = "android:theme";

		internal const string SAVED_CANCELABLE = "android:cancelable";

		internal const string SAVED_SHOWS_DIALOG = "android:showsDialog";

		internal const string SAVED_BACK_STACK_ID = "android:backStackId";

		internal int mStyle = STYLE_NORMAL;

		internal int mTheme = 0;

		internal bool mCancelable = true;

		internal bool mShowsDialog = true;

		internal int mBackStackId = -1;

		internal android.app.Dialog mDialog;

		internal bool mViewDestroyed;

		internal bool mDismissed;

		internal bool mShownByMe;

		[Sharpen.Stub]
		public DialogFragment()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStyle(int style, int theme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void show(android.app.FragmentManager manager, string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int show(android.app.FragmentTransaction transaction, string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dismiss()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dismissAllowingStateLoss()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void dismissInternal(bool allowStateLoss)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Dialog getDialog()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getTheme()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCancelable(bool cancelable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isCancelable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setShowsDialog(bool showsDialog)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getShowsDialog()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onAttach(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onDetach()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override android.view.LayoutInflater getLayoutInflater(android.os.Bundle savedInstanceState
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Dialog onCreateDialog(android.os.Bundle savedInstanceState
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnCancelListener")]
		public virtual void onCancel(android.content.DialogInterface dialog)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnDismissListener"
			)]
		public virtual void onDismiss(android.content.DialogInterface dialog)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onActivityCreated(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onSaveInstanceState(android.os.Bundle outState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onStop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onDestroyView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}
