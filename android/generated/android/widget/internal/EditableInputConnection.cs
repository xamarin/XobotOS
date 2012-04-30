using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Sharpened]
	public class EditableInputConnection : android.view.inputmethod.BaseInputConnection
	{
		internal const bool DEBUG = false;

		internal const string TAG = "EditableInputConnection";

		private readonly android.widget.TextView mTextView;

		public EditableInputConnection(android.widget.TextView textview) : base(textview, 
			true)
		{
			mTextView = textview;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override android.text.Editable getEditable()
		{
			android.widget.TextView tv = mTextView;
			if (tv != null)
			{
				return tv.getEditableText();
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool beginBatchEdit()
		{
			mTextView.beginBatchEdit();
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool endBatchEdit()
		{
			mTextView.endBatchEdit();
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool clearMetaKeyStates(int states)
		{
			android.text.Editable content = getEditable();
			if (content == null)
			{
				return false;
			}
			android.text.method.KeyListener kl = mTextView.getKeyListener();
			if (kl != null)
			{
				try
				{
					kl.clearMetaKeyState(mTextView, content, states);
				}
				catch (java.lang.AbstractMethodError)
				{
				}
			}
			// This is an old listener that doesn't implement the
			// new method.
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool commitCompletion(android.view.inputmethod.CompletionInfo text
			)
		{
			mTextView.beginBatchEdit();
			mTextView.onCommitCompletion(text);
			mTextView.endBatchEdit();
			return true;
		}

		/// <summary>
		/// Calls the
		/// <see cref="android.widget.TextView.onCommitCorrection(android.view.inputmethod.CorrectionInfo)
		/// 	">android.widget.TextView.onCommitCorrection(android.view.inputmethod.CorrectionInfo)
		/// 	</see>
		/// method of the associated TextView.
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool commitCorrection(android.view.inputmethod.CorrectionInfo correctionInfo
			)
		{
			mTextView.beginBatchEdit();
			mTextView.onCommitCorrection(correctionInfo);
			mTextView.endBatchEdit();
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool performEditorAction(int actionCode)
		{
			mTextView.onEditorAction(actionCode);
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool performContextMenuAction(int id)
		{
			mTextView.beginBatchEdit();
			mTextView.onTextContextMenuItem(id);
			mTextView.endBatchEdit();
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override android.view.inputmethod.ExtractedText getExtractedText(android.view.inputmethod.ExtractedTextRequest
			 request, int flags)
		{
			if (mTextView != null)
			{
				android.view.inputmethod.ExtractedText et = new android.view.inputmethod.ExtractedText
					();
				if (mTextView.extractText(request, et))
				{
					if ((flags & android.view.inputmethod.InputConnectionClass.GET_EXTRACTED_TEXT_MONITOR
						) != 0)
					{
						mTextView.setExtracting(request);
					}
					return et;
				}
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool performPrivateCommand(string action, android.os.Bundle data)
		{
			mTextView.onPrivateIMECommand(action, data);
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.inputmethod.BaseInputConnection")]
		public override bool commitText(java.lang.CharSequence text, int newCursorPosition
			)
		{
			if (mTextView == null)
			{
				return base.commitText(text, newCursorPosition);
			}
			if (text is android.text.Spanned)
			{
				android.text.Spanned spanned = ((android.text.Spanned)text);
				android.text.style.SuggestionSpan[] spans = spanned.getSpans<android.text.style.SuggestionSpan
					>(0, text.Length);
				mIMM.registerSuggestionSpansForNotification(spans);
			}
			mTextView.resetErrorChangedFlag();
			bool success = base.commitText(text, newCursorPosition);
			mTextView.hideErrorIfUnchanged();
			return success;
		}
	}
}
