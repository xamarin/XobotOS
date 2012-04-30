using Sharpen;

namespace android.view
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface IOnKeyguardExitResult : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void onKeyguardExitResult(bool success);
	}

	/// <hide></hide>
	[Sharpen.Sharpened]
	public static class IOnKeyguardExitResultClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.view.IOnKeyguardExitResult
		{
			internal const string DESCRIPTOR = "android.view.IOnKeyguardExitResult";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an android.view.IOnKeyguardExitResult interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an android.view.IOnKeyguardExitResult interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.view.IOnKeyguardExitResult asInterface(android.os.IBinder obj
				)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.view.IOnKeyguardExitResult)))
				{
					return ((android.view.IOnKeyguardExitResult)iin);
				}
				return new android.view.IOnKeyguardExitResultClass.Stub.Proxy(obj);
			}

			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				return this;
			}

			/// <exception cref="android.os.RemoteException"></exception>
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				switch (code)
				{
					case android.os.IBinderClass.INTERFACE_TRANSACTION:
					{
						reply.writeString(DESCRIPTOR);
						return true;
					}

					case TRANSACTION_onKeyguardExitResult:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _arg0;
						_arg0 = (0 != data.readInt());
						this.onKeyguardExitResult(_arg0);
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.view.IOnKeyguardExitResult
			{
				internal android.os.IBinder mRemote;

				internal Proxy(android.os.IBinder remote)
				{
					mRemote = remote;
				}

				[Sharpen.ImplementsInterface(@"android.os.IInterface")]
				public virtual android.os.IBinder asBinder()
				{
					return mRemote;
				}

				public virtual string getInterfaceDescriptor()
				{
					return DESCRIPTOR;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"android.view.IOnKeyguardExitResult")]
				public virtual void onKeyguardExitResult(bool success)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(((success) ? (1) : (0)));
						mRemote.transact(android.view.IOnKeyguardExitResultClass.Stub.TRANSACTION_onKeyguardExitResult
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}
			}

			internal const int TRANSACTION_onKeyguardExitResult = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onKeyguardExitResult(bool arg1);
		}
	}
}
