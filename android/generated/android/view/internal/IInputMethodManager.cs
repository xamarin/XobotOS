using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface IInputMethodManager : android.os.IInterface
	{
		[Sharpen.Stub]
		java.util.List<android.view.inputmethod.InputMethodInfo> getInputMethodList();

		[Sharpen.Stub]
		java.util.List<android.view.inputmethod.InputMethodInfo> getEnabledInputMethodList
			();

		[Sharpen.Stub]
		java.util.List<android.view.inputmethod.InputMethodSubtype> getEnabledInputMethodSubtypeList
			(android.view.inputmethod.InputMethodInfo imi, bool allowsImplicitlySelectedSubtypes
			);

		[Sharpen.Stub]
		android.view.inputmethod.InputMethodSubtype getLastInputMethodSubtype();

		[Sharpen.Stub]
		java.util.List<object> getShortcutInputMethodsAndSubtypes();

		[Sharpen.Stub]
		void addClient(android.view.@internal.IInputMethodClient client, android.view.@internal.IInputContext
			 inputContext, int uid, int pid);

		[Sharpen.Stub]
		void removeClient(android.view.@internal.IInputMethodClient client);

		[Sharpen.Stub]
		android.view.@internal.InputBindResult startInput(android.view.@internal.IInputMethodClient
			 client, android.view.@internal.IInputContext inputContext, android.view.inputmethod.EditorInfo
			 attribute, bool initial, bool needResult);

		[Sharpen.Stub]
		void finishInput(android.view.@internal.IInputMethodClient client);

		[Sharpen.Stub]
		bool showSoftInput(android.view.@internal.IInputMethodClient client, int flags, android.os.ResultReceiver
			 resultReceiver);

		[Sharpen.Stub]
		bool hideSoftInput(android.view.@internal.IInputMethodClient client, int flags, android.os.ResultReceiver
			 resultReceiver);

		[Sharpen.Stub]
		void windowGainedFocus(android.view.@internal.IInputMethodClient client, android.os.IBinder
			 windowToken, bool viewHasFocus, bool isTextEditor, int softInputMode, bool first
			, int windowFlags);

		[Sharpen.Stub]
		void showInputMethodPickerFromClient(android.view.@internal.IInputMethodClient client
			);

		[Sharpen.Stub]
		void showInputMethodAndSubtypeEnablerFromClient(android.view.@internal.IInputMethodClient
			 client, string topId);

		[Sharpen.Stub]
		void setInputMethod(android.os.IBinder token, string id);

		[Sharpen.Stub]
		void setInputMethodAndSubtype(android.os.IBinder token, string id, android.view.inputmethod.InputMethodSubtype
			 subtype);

		[Sharpen.Stub]
		void hideMySoftInput(android.os.IBinder token, int flags);

		[Sharpen.Stub]
		void showMySoftInput(android.os.IBinder token, int flags);

		[Sharpen.Stub]
		void updateStatusIcon(android.os.IBinder token, string packageName, int iconId);

		[Sharpen.Stub]
		void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition);

		[Sharpen.Stub]
		void registerSuggestionSpansForNotification(android.text.style.SuggestionSpan[] spans
			);

		[Sharpen.Stub]
		bool notifySuggestionPicked(android.text.style.SuggestionSpan span, string originalString
			, int index);

		[Sharpen.Stub]
		android.view.inputmethod.InputMethodSubtype getCurrentInputMethodSubtype();

		[Sharpen.Stub]
		bool setCurrentInputMethodSubtype(android.view.inputmethod.InputMethodSubtype subtype
			);

		[Sharpen.Stub]
		bool switchToLastInputMethod(android.os.IBinder token);

		[Sharpen.Stub]
		bool setInputMethodEnabled(string id, bool enabled);

		[Sharpen.Stub]
		void setAdditionalInputMethodSubtypes(string id, android.view.inputmethod.InputMethodSubtype
			[] subtypes);
	}

	[Sharpen.Stub]
	public static class IInputMethodManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.@internal.IInputMethodManager
		{
			internal const string DESCRIPTOR = "com.android.internal.view.IInputMethodManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.@internal.IInputMethodManager asInterface(android.os.IBinder
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
			private class Proxy : android.view.@internal.IInputMethodManager
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
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual java.util.List<android.view.inputmethod.InputMethodInfo> getInputMethodList
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual java.util.List<android.view.inputmethod.InputMethodInfo> getEnabledInputMethodList
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual java.util.List<android.view.inputmethod.InputMethodSubtype> getEnabledInputMethodSubtypeList
					(android.view.inputmethod.InputMethodInfo imi, bool allowsImplicitlySelectedSubtypes
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual android.view.inputmethod.InputMethodSubtype getLastInputMethodSubtype
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual java.util.List<object> getShortcutInputMethodsAndSubtypes()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void addClient(android.view.@internal.IInputMethodClient client, android.view.@internal.IInputContext
					 inputContext, int uid, int pid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void removeClient(android.view.@internal.IInputMethodClient client
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual android.view.@internal.InputBindResult startInput(android.view.@internal.IInputMethodClient
					 client, android.view.@internal.IInputContext inputContext, android.view.inputmethod.EditorInfo
					 attribute, bool initial, bool needResult)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void finishInput(android.view.@internal.IInputMethodClient client)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual bool showSoftInput(android.view.@internal.IInputMethodClient client
					, int flags, android.os.ResultReceiver resultReceiver)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual bool hideSoftInput(android.view.@internal.IInputMethodClient client
					, int flags, android.os.ResultReceiver resultReceiver)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void windowGainedFocus(android.view.@internal.IInputMethodClient client
					, android.os.IBinder windowToken, bool viewHasFocus, bool isTextEditor, int softInputMode
					, bool first, int windowFlags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void showInputMethodPickerFromClient(android.view.@internal.IInputMethodClient
					 client)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void showInputMethodAndSubtypeEnablerFromClient(android.view.@internal.IInputMethodClient
					 client, string topId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void setInputMethod(android.os.IBinder token, string id)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void setInputMethodAndSubtype(android.os.IBinder token, string id, 
					android.view.inputmethod.InputMethodSubtype subtype)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void hideMySoftInput(android.os.IBinder token, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void showMySoftInput(android.os.IBinder token, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void updateStatusIcon(android.os.IBinder token, string packageName
					, int iconId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void registerSuggestionSpansForNotification(android.text.style.SuggestionSpan
					[] spans)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual bool notifySuggestionPicked(android.text.style.SuggestionSpan span
					, string originalString, int index)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual android.view.inputmethod.InputMethodSubtype getCurrentInputMethodSubtype
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual bool setCurrentInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
					 subtype)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual bool switchToLastInputMethod(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual bool setInputMethodEnabled(string id, bool enabled)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodManager")]
				public virtual void setAdditionalInputMethodSubtypes(string id, android.view.inputmethod.InputMethodSubtype
					[] subtypes)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_getInputMethodList = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_getEnabledInputMethodList = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getEnabledInputMethodSubtypeList = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_getLastInputMethodSubtype = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_getShortcutInputMethodsAndSubtypes = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_addClient = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_removeClient = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_startInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_finishInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_showSoftInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_hideSoftInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_windowGainedFocus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_showInputMethodPickerFromClient = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_showInputMethodAndSubtypeEnablerFromClient = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_setInputMethod = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_setInputMethodAndSubtype = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_hideMySoftInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			internal const int TRANSACTION_showMySoftInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 17);

			internal const int TRANSACTION_updateStatusIcon = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 18);

			internal const int TRANSACTION_setImeWindowStatus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 19);

			internal const int TRANSACTION_registerSuggestionSpansForNotification = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 20);

			internal const int TRANSACTION_notifySuggestionPicked = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 21);

			internal const int TRANSACTION_getCurrentInputMethodSubtype = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 22);

			internal const int TRANSACTION_setCurrentInputMethodSubtype = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 23);

			internal const int TRANSACTION_switchToLastInputMethod = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 24);

			internal const int TRANSACTION_setInputMethodEnabled = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 25);

			internal const int TRANSACTION_setAdditionalInputMethodSubtypes = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 26);

			public abstract void addClient(android.view.@internal.IInputMethodClient arg1, android.view.@internal.IInputContext
				 arg2, int arg3, int arg4);

			public abstract void finishInput(android.view.@internal.IInputMethodClient arg1);

			public abstract android.view.inputmethod.InputMethodSubtype getCurrentInputMethodSubtype
				();

			public abstract java.util.List<android.view.inputmethod.InputMethodInfo> getEnabledInputMethodList
				();

			public abstract java.util.List<android.view.inputmethod.InputMethodSubtype> getEnabledInputMethodSubtypeList
				(android.view.inputmethod.InputMethodInfo arg1, bool arg2);

			public abstract java.util.List<android.view.inputmethod.InputMethodInfo> getInputMethodList
				();

			public abstract android.view.inputmethod.InputMethodSubtype getLastInputMethodSubtype
				();

			public abstract java.util.List<object> getShortcutInputMethodsAndSubtypes();

			public abstract void hideMySoftInput(android.os.IBinder arg1, int arg2);

			public abstract bool hideSoftInput(android.view.@internal.IInputMethodClient arg1
				, int arg2, android.os.ResultReceiver arg3);

			public abstract bool notifySuggestionPicked(android.text.style.SuggestionSpan arg1
				, string arg2, int arg3);

			public abstract void registerSuggestionSpansForNotification(android.text.style.SuggestionSpan
				[] arg1);

			public abstract void removeClient(android.view.@internal.IInputMethodClient arg1);

			public abstract void setAdditionalInputMethodSubtypes(string arg1, android.view.inputmethod.InputMethodSubtype
				[] arg2);

			public abstract bool setCurrentInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
				 arg1);

			public abstract void setImeWindowStatus(android.os.IBinder arg1, int arg2, int arg3
				);

			public abstract void setInputMethod(android.os.IBinder arg1, string arg2);

			public abstract void setInputMethodAndSubtype(android.os.IBinder arg1, string arg2
				, android.view.inputmethod.InputMethodSubtype arg3);

			public abstract bool setInputMethodEnabled(string arg1, bool arg2);

			public abstract void showInputMethodAndSubtypeEnablerFromClient(android.view.@internal.IInputMethodClient
				 arg1, string arg2);

			public abstract void showInputMethodPickerFromClient(android.view.@internal.IInputMethodClient
				 arg1);

			public abstract void showMySoftInput(android.os.IBinder arg1, int arg2);

			public abstract bool showSoftInput(android.view.@internal.IInputMethodClient arg1
				, int arg2, android.os.ResultReceiver arg3);

			public abstract android.view.@internal.InputBindResult startInput(android.view.@internal.IInputMethodClient
				 arg1, android.view.@internal.IInputContext arg2, android.view.inputmethod.EditorInfo
				 arg3, bool arg4, bool arg5);

			public abstract bool switchToLastInputMethod(android.os.IBinder arg1);

			public abstract void updateStatusIcon(android.os.IBinder arg1, string arg2, int arg3
				);

			public abstract void windowGainedFocus(android.view.@internal.IInputMethodClient 
				arg1, android.os.IBinder arg2, bool arg3, bool arg4, int arg5, bool arg6, int arg7
				);
		}
	}
}
