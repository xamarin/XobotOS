using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	public class ExtractEditText : android.widget.EditText
	{
		private android.inputmethodservice.InputMethodService mIME;

		private int mSettingExtractedText;

		[Sharpen.Stub]
		public ExtractEditText(android.content.Context context) : base(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ExtractEditText(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs, android.@internal.R.attr.editTextStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ExtractEditText(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setIME(android.inputmethodservice.InputMethodService ime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startInternalChanges()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void finishInternalChanges()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		public override void setExtractedText(android.view.inputmethod.ExtractedText text
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		protected internal override void onSelectionChanged(int selStart, int selEnd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool performClick()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		public override bool onTextContextMenuItem(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		public override bool isInputMethodTarget()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasVerticalScrollBar()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool hasWindowFocus()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool isFocused()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool hasFocus()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		protected internal override void viewClicked(android.view.inputmethod.InputMethodManager
			 imm)
		{
			throw new System.NotImplementedException();
		}
	}
}
