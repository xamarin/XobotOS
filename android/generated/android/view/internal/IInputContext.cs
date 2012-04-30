using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface IInputContext : android.os.IInterface
	{
		[Sharpen.Stub]
		void getTextBeforeCursor(int length, int flags, int seq, android.view.@internal.IInputContextCallback
			 callback);

		[Sharpen.Stub]
		void getTextAfterCursor(int length, int flags, int seq, android.view.@internal.IInputContextCallback
			 callback);

		[Sharpen.Stub]
		void getCursorCapsMode(int reqModes, int seq, android.view.@internal.IInputContextCallback
			 callback);

		[Sharpen.Stub]
		void getExtractedText(android.view.inputmethod.ExtractedTextRequest request, int 
			flags, int seq, android.view.@internal.IInputContextCallback callback);

		[Sharpen.Stub]
		void deleteSurroundingText(int leftLength, int rightLength);

		[Sharpen.Stub]
		void setComposingText(java.lang.CharSequence text, int newCursorPosition);

		[Sharpen.Stub]
		void finishComposingText();

		[Sharpen.Stub]
		void commitText(java.lang.CharSequence text, int newCursorPosition);

		[Sharpen.Stub]
		void commitCompletion(android.view.inputmethod.CompletionInfo completion);

		[Sharpen.Stub]
		void commitCorrection(android.view.inputmethod.CorrectionInfo correction);

		[Sharpen.Stub]
		void setSelection(int start, int end);

		[Sharpen.Stub]
		void performEditorAction(int actionCode);

		[Sharpen.Stub]
		void performContextMenuAction(int id);

		[Sharpen.Stub]
		void beginBatchEdit();

		[Sharpen.Stub]
		void endBatchEdit();

		[Sharpen.Stub]
		void reportFullscreenMode(bool enabled);

		[Sharpen.Stub]
		void sendKeyEvent(android.view.KeyEvent @event);

		[Sharpen.Stub]
		void clearMetaKeyStates(int states);

		[Sharpen.Stub]
		void performPrivateCommand(string action, android.os.Bundle data);

		[Sharpen.Stub]
		void setComposingRegion(int start, int end);

		[Sharpen.Stub]
		void getSelectedText(int flags, int seq, android.view.@internal.IInputContextCallback
			 callback);
	}

	[Sharpen.Stub]
	public static class IInputContextClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.@internal.IInputContext
		{
			internal const string DESCRIPTOR = "com.android.internal.view.IInputContext";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.@internal.IInputContext asInterface(android.os.IBinder
				 obj)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private class Proxy : android.view.@internal.IInputContext
			{
				internal android.os.IBinder mRemote;

				[Sharpen.Stub]
				internal Proxy(android.os.IBinder remote)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.IInterface")]
				public virtual android.os.IBinder asBinder()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public virtual string getInterfaceDescriptor()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void getTextBeforeCursor(int length, int flags, int seq, android.view.@internal.IInputContextCallback
					 callback)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void getTextAfterCursor(int length, int flags, int seq, android.view.@internal.IInputContextCallback
					 callback)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void getCursorCapsMode(int reqModes, int seq, android.view.@internal.IInputContextCallback
					 callback)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void getExtractedText(android.view.inputmethod.ExtractedTextRequest
					 request, int flags, int seq, android.view.@internal.IInputContextCallback callback
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void deleteSurroundingText(int leftLength, int rightLength)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void setComposingText(java.lang.CharSequence text, int newCursorPosition
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void finishComposingText()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void commitText(java.lang.CharSequence text, int newCursorPosition
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void commitCompletion(android.view.inputmethod.CompletionInfo completion
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void commitCorrection(android.view.inputmethod.CorrectionInfo correction
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void setSelection(int start, int end)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void performEditorAction(int actionCode)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void performContextMenuAction(int id)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void beginBatchEdit()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void endBatchEdit()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void reportFullscreenMode(bool enabled)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void sendKeyEvent(android.view.KeyEvent @event)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void clearMetaKeyStates(int states)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void performPrivateCommand(string action, android.os.Bundle data)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void setComposingRegion(int start, int end)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
				public virtual void getSelectedText(int flags, int seq, android.view.@internal.IInputContextCallback
					 callback)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_getTextBeforeCursor = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_getTextAfterCursor = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getCursorCapsMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_getExtractedText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_deleteSurroundingText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_setComposingText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_finishComposingText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_commitText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_commitCompletion = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_commitCorrection = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_setSelection = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_performEditorAction = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_performContextMenuAction = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_beginBatchEdit = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_endBatchEdit = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_reportFullscreenMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_sendKeyEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			internal const int TRANSACTION_clearMetaKeyStates = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 17);

			internal const int TRANSACTION_performPrivateCommand = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 18);

			internal const int TRANSACTION_setComposingRegion = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 19);

			internal const int TRANSACTION_getSelectedText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 20);

			public abstract void beginBatchEdit();

			public abstract void clearMetaKeyStates(int arg1);

			public abstract void commitCompletion(android.view.inputmethod.CompletionInfo arg1
				);

			public abstract void commitCorrection(android.view.inputmethod.CorrectionInfo arg1
				);

			public abstract void commitText(java.lang.CharSequence arg1, int arg2);

			public abstract void deleteSurroundingText(int arg1, int arg2);

			public abstract void endBatchEdit();

			public abstract void finishComposingText();

			public abstract void getCursorCapsMode(int arg1, int arg2, android.view.@internal.IInputContextCallback
				 arg3);

			public abstract void getExtractedText(android.view.inputmethod.ExtractedTextRequest
				 arg1, int arg2, int arg3, android.view.@internal.IInputContextCallback arg4);

			public abstract void getSelectedText(int arg1, int arg2, android.view.@internal.IInputContextCallback
				 arg3);

			public abstract void getTextAfterCursor(int arg1, int arg2, int arg3, android.view.@internal.IInputContextCallback
				 arg4);

			public abstract void getTextBeforeCursor(int arg1, int arg2, int arg3, android.view.@internal.IInputContextCallback
				 arg4);

			public abstract void performContextMenuAction(int arg1);

			public abstract void performEditorAction(int arg1);

			public abstract void performPrivateCommand(string arg1, android.os.Bundle arg2);

			public abstract void reportFullscreenMode(bool arg1);

			public abstract void sendKeyEvent(android.view.KeyEvent arg1);

			public abstract void setComposingRegion(int arg1, int arg2);

			public abstract void setComposingText(java.lang.CharSequence arg1, int arg2);

			public abstract void setSelection(int arg1, int arg2);
		}
	}
}
