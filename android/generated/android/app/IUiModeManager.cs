using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IUiModeManager : android.os.IInterface
	{
		[Sharpen.Stub]
		void enableCarMode(int flags);

		[Sharpen.Stub]
		void disableCarMode(int flags);

		[Sharpen.Stub]
		int getCurrentModeType();

		[Sharpen.Stub]
		void setNightMode(int mode);

		[Sharpen.Stub]
		int getNightMode();
	}

	[Sharpen.Stub]
	public static class IUiModeManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IUiModeManager
		{
			internal const string DESCRIPTOR = "android.app.IUiModeManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IUiModeManager asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IUiModeManager
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
				[Sharpen.ImplementsInterface(@"android.app.IUiModeManager")]
				public virtual void enableCarMode(int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IUiModeManager")]
				public virtual void disableCarMode(int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IUiModeManager")]
				public virtual int getCurrentModeType()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IUiModeManager")]
				public virtual void setNightMode(int mode)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IUiModeManager")]
				public virtual int getNightMode()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_enableCarMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_disableCarMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getCurrentModeType = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_setNightMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_getNightMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			public abstract void disableCarMode(int arg1);

			public abstract void enableCarMode(int arg1);

			public abstract int getCurrentModeType();

			public abstract int getNightMode();

			public abstract void setNightMode(int arg1);
		}
	}
}
