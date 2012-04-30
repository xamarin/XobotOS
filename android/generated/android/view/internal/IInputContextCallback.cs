using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface IInputContextCallback : android.os.IInterface
	{
		[Sharpen.Stub]
		void setTextBeforeCursor(java.lang.CharSequence textBeforeCursor, int seq);

		[Sharpen.Stub]
		void setTextAfterCursor(java.lang.CharSequence textAfterCursor, int seq);

		[Sharpen.Stub]
		void setCursorCapsMode(int capsMode, int seq);

		[Sharpen.Stub]
		void setExtractedText(android.view.inputmethod.ExtractedText extractedText, int seq
			);

		[Sharpen.Stub]
		void setSelectedText(java.lang.CharSequence selectedText, int seq);
	}

	[Sharpen.Stub]
	public static class IInputContextCallbackClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.@internal.IInputContextCallback
		{
			internal const string DESCRIPTOR = "com.android.internal.view.IInputContextCallback";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.@internal.IInputContextCallback asInterface(android.os.IBinder
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
			private class Proxy : android.view.@internal.IInputContextCallback
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
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
				public virtual void setTextBeforeCursor(java.lang.CharSequence textBeforeCursor, 
					int seq)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
				public virtual void setTextAfterCursor(java.lang.CharSequence textAfterCursor, int
					 seq)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
				public virtual void setCursorCapsMode(int capsMode, int seq)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
				public virtual void setExtractedText(android.view.inputmethod.ExtractedText extractedText
					, int seq)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
				public virtual void setSelectedText(java.lang.CharSequence selectedText, int seq)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_setTextBeforeCursor = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_setTextAfterCursor = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_setCursorCapsMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_setExtractedText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_setSelectedText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			public abstract void setCursorCapsMode(int arg1, int arg2);

			public abstract void setExtractedText(android.view.inputmethod.ExtractedText arg1
				, int arg2);

			public abstract void setSelectedText(java.lang.CharSequence arg1, int arg2);

			public abstract void setTextAfterCursor(java.lang.CharSequence arg1, int arg2);

			public abstract void setTextBeforeCursor(java.lang.CharSequence arg1, int arg2);
		}
	}
}
