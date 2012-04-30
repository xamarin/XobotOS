using Sharpen;

namespace android.view
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public interface IApplicationToken : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void windowsVisible();

		/// <exception cref="android.os.RemoteException"></exception>
		void windowsGone();

		/// <exception cref="android.os.RemoteException"></exception>
		bool keyDispatchingTimedOut();

		/// <exception cref="android.os.RemoteException"></exception>
		long getKeyDispatchingTimeout();
	}

	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public static class IApplicationTokenClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.view.IApplicationToken
		{
			internal const string DESCRIPTOR = "android.view.IApplicationToken";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an android.view.IApplicationToken interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an android.view.IApplicationToken interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.view.IApplicationToken asInterface(android.os.IBinder obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.view.IApplicationToken)))
				{
					return ((android.view.IApplicationToken)iin);
				}
				return new android.view.IApplicationTokenClass.Stub.Proxy(obj);
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

					case TRANSACTION_windowsVisible:
					{
						data.enforceInterface(DESCRIPTOR);
						this.windowsVisible();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_windowsGone:
					{
						data.enforceInterface(DESCRIPTOR);
						this.windowsGone();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_keyDispatchingTimedOut:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _result = this.keyDispatchingTimedOut();
						reply.writeNoException();
						reply.writeInt(((_result) ? (1) : (0)));
						return true;
					}

					case TRANSACTION_getKeyDispatchingTimeout:
					{
						data.enforceInterface(DESCRIPTOR);
						long _result = this.getKeyDispatchingTimeout();
						reply.writeNoException();
						reply.writeLong(_result);
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.view.IApplicationToken
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
				[Sharpen.ImplementsInterface(@"android.view.IApplicationToken")]
				public virtual void windowsVisible()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.view.IApplicationTokenClass.Stub.TRANSACTION_windowsVisible
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
				[Sharpen.ImplementsInterface(@"android.view.IApplicationToken")]
				public virtual void windowsGone()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.view.IApplicationTokenClass.Stub.TRANSACTION_windowsGone
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
				[Sharpen.ImplementsInterface(@"android.view.IApplicationToken")]
				public virtual bool keyDispatchingTimedOut()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					bool _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.view.IApplicationTokenClass.Stub.TRANSACTION_keyDispatchingTimedOut
							, _data, _reply, 0);
						_reply.readException();
						_result = (0 != _reply.readInt());
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"android.view.IApplicationToken")]
				public virtual long getKeyDispatchingTimeout()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					long _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.view.IApplicationTokenClass.Stub.TRANSACTION_getKeyDispatchingTimeout
							, _data, _reply, 0);
						_reply.readException();
						_result = _reply.readLong();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}
			}

			internal const int TRANSACTION_windowsVisible = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_windowsGone = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_keyDispatchingTimedOut = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_getKeyDispatchingTimeout = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			public abstract long getKeyDispatchingTimeout();

			public abstract bool keyDispatchingTimedOut();

			public abstract void windowsGone();

			public abstract void windowsVisible();
		}
	}
}
