using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface IClipboard : android.os.IInterface
	{
		[Sharpen.Stub]
		void setPrimaryClip(android.content.ClipData clip);

		[Sharpen.Stub]
		android.content.ClipData getPrimaryClip(string pkg);

		[Sharpen.Stub]
		android.content.ClipDescription getPrimaryClipDescription();

		[Sharpen.Stub]
		bool hasPrimaryClip();

		[Sharpen.Stub]
		void addPrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener 
			listener);

		[Sharpen.Stub]
		void removePrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener
			 listener);

		[Sharpen.Stub]
		bool hasClipboardText();
	}

	[Sharpen.Stub]
	public static class IClipboardClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.IClipboard
		{
			internal const string DESCRIPTOR = "android.content.IClipboard";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.IClipboard asInterface(android.os.IBinder obj)
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
			private class Proxy : android.content.IClipboard
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
				[Sharpen.ImplementsInterface(@"android.content.IClipboard")]
				public virtual void setPrimaryClip(android.content.ClipData clip)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IClipboard")]
				public virtual android.content.ClipData getPrimaryClip(string pkg)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IClipboard")]
				public virtual android.content.ClipDescription getPrimaryClipDescription()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IClipboard")]
				public virtual bool hasPrimaryClip()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IClipboard")]
				public virtual void addPrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener
					 listener)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IClipboard")]
				public virtual void removePrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener
					 listener)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IClipboard")]
				public virtual bool hasClipboardText()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_setPrimaryClip = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_getPrimaryClip = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getPrimaryClipDescription = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_hasPrimaryClip = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_addPrimaryClipChangedListener = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_removePrimaryClipChangedListener = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_hasClipboardText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			public abstract void addPrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener
				 arg1);

			public abstract android.content.ClipData getPrimaryClip(string arg1);

			public abstract android.content.ClipDescription getPrimaryClipDescription();

			public abstract bool hasClipboardText();

			public abstract bool hasPrimaryClip();

			public abstract void removePrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener
				 arg1);

			public abstract void setPrimaryClip(android.content.ClipData arg1);
		}
	}
}
