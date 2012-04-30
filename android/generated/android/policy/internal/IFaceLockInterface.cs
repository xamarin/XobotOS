using Sharpen;

namespace android.policy.@internal
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public interface IFaceLockInterface : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void startUi(android.os.IBinder containingWindowToken, int x, int y, int width, int
			 height);

		/// <exception cref="android.os.RemoteException"></exception>
		void stopUi();

		/// <exception cref="android.os.RemoteException"></exception>
		void registerCallback(android.policy.@internal.IFaceLockCallback cb);

		/// <exception cref="android.os.RemoteException"></exception>
		void unregisterCallback(android.policy.@internal.IFaceLockCallback cb);
	}

	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public static class IFaceLockInterfaceClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.policy.@internal.IFaceLockInterface
		{
			internal const string DESCRIPTOR = "com.android.internal.policy.IFaceLockInterface";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.policy.IFaceLockInterface interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.policy.IFaceLockInterface interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.policy.@internal.IFaceLockInterface asInterface(android.os.IBinder
				 obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.policy.@internal.IFaceLockInterface)))
				{
					return ((android.policy.@internal.IFaceLockInterface)iin);
				}
				return new android.policy.@internal.IFaceLockInterfaceClass.Stub.Proxy(obj);
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

					case TRANSACTION_startUi:
					{
						data.enforceInterface(DESCRIPTOR);
						android.os.IBinder _arg0;
						_arg0 = data.readStrongBinder();
						int _arg1;
						_arg1 = data.readInt();
						int _arg2;
						_arg2 = data.readInt();
						int _arg3;
						_arg3 = data.readInt();
						int _arg4;
						_arg4 = data.readInt();
						this.startUi(_arg0, _arg1, _arg2, _arg3, _arg4);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_stopUi:
					{
						data.enforceInterface(DESCRIPTOR);
						this.stopUi();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_registerCallback:
					{
						data.enforceInterface(DESCRIPTOR);
						android.policy.@internal.IFaceLockCallback _arg0;
						_arg0 = android.policy.@internal.IFaceLockCallbackClass.Stub.asInterface(data.readStrongBinder
							());
						this.registerCallback(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_unregisterCallback:
					{
						data.enforceInterface(DESCRIPTOR);
						android.policy.@internal.IFaceLockCallback _arg0;
						_arg0 = android.policy.@internal.IFaceLockCallbackClass.Stub.asInterface(data.readStrongBinder
							());
						this.unregisterCallback(_arg0);
						reply.writeNoException();
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.policy.@internal.IFaceLockInterface
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
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockInterface")]
				public virtual void startUi(android.os.IBinder containingWindowToken, int x, int 
					y, int width, int height)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder(containingWindowToken);
						_data.writeInt(x);
						_data.writeInt(y);
						_data.writeInt(width);
						_data.writeInt(height);
						mRemote.transact(android.policy.@internal.IFaceLockInterfaceClass.Stub.TRANSACTION_startUi
							, _data, _reply, 0);
						_reply.readException();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockInterface")]
				public virtual void stopUi()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.policy.@internal.IFaceLockInterfaceClass.Stub.TRANSACTION_stopUi
							, _data, _reply, 0);
						_reply.readException();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockInterface")]
				public virtual void registerCallback(android.policy.@internal.IFaceLockCallback cb
					)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder((((cb != null)) ? (cb.asBinder()) : (null)));
						mRemote.transact(android.policy.@internal.IFaceLockInterfaceClass.Stub.TRANSACTION_registerCallback
							, _data, _reply, 0);
						_reply.readException();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockInterface")]
				public virtual void unregisterCallback(android.policy.@internal.IFaceLockCallback
					 cb)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder((((cb != null)) ? (cb.asBinder()) : (null)));
						mRemote.transact(android.policy.@internal.IFaceLockInterfaceClass.Stub.TRANSACTION_unregisterCallback
							, _data, _reply, 0);
						_reply.readException();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
				}
			}

			internal const int TRANSACTION_startUi = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_stopUi = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_registerCallback = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_unregisterCallback = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			public abstract void registerCallback(android.policy.@internal.IFaceLockCallback 
				arg1);

			public abstract void startUi(android.os.IBinder arg1, int arg2, int arg3, int arg4
				, int arg5);

			public abstract void stopUi();

			public abstract void unregisterCallback(android.policy.@internal.IFaceLockCallback
				 arg1);
		}
	}
}
