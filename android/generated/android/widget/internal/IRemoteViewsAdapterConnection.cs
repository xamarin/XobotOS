using Sharpen;

namespace android.widget.@internal
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public interface IRemoteViewsAdapterConnection : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void onServiceConnected(android.os.IBinder service);

		/// <exception cref="android.os.RemoteException"></exception>
		void onServiceDisconnected();
	}

	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public static class IRemoteViewsAdapterConnectionClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.widget.@internal.IRemoteViewsAdapterConnection
		{
			internal const string DESCRIPTOR = "com.android.internal.widget.IRemoteViewsAdapterConnection";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.widget.IRemoteViewsAdapterConnection interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.widget.IRemoteViewsAdapterConnection interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.widget.@internal.IRemoteViewsAdapterConnection asInterface(
				android.os.IBinder obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.widget.@internal.IRemoteViewsAdapterConnection
					)))
				{
					return ((android.widget.@internal.IRemoteViewsAdapterConnection)iin);
				}
				return new android.widget.@internal.IRemoteViewsAdapterConnectionClass.Stub.Proxy
					(obj);
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

					case TRANSACTION_onServiceConnected:
					{
						data.enforceInterface(DESCRIPTOR);
						android.os.IBinder _arg0;
						_arg0 = data.readStrongBinder();
						this.onServiceConnected(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_onServiceDisconnected:
					{
						data.enforceInterface(DESCRIPTOR);
						this.onServiceDisconnected();
						reply.writeNoException();
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.widget.@internal.IRemoteViewsAdapterConnection
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
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsAdapterConnection"
					)]
				public virtual void onServiceConnected(android.os.IBinder service)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder(service);
						mRemote.transact(android.widget.@internal.IRemoteViewsAdapterConnectionClass.Stub
							.TRANSACTION_onServiceConnected, _data, _reply, 0);
						_reply.readException();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsAdapterConnection"
					)]
				public virtual void onServiceDisconnected()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.widget.@internal.IRemoteViewsAdapterConnectionClass.Stub
							.TRANSACTION_onServiceDisconnected, _data, _reply, 0);
						_reply.readException();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
				}
			}

			internal const int TRANSACTION_onServiceConnected = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_onServiceDisconnected = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void onServiceConnected(android.os.IBinder arg1);

			public abstract void onServiceDisconnected();
		}
	}
}
