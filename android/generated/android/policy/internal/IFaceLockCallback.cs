using Sharpen;

namespace android.policy.@internal
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public interface IFaceLockCallback : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void unlock();

		/// <exception cref="android.os.RemoteException"></exception>
		void cancel();

		/// <exception cref="android.os.RemoteException"></exception>
		void reportFailedAttempt();

		/// <exception cref="android.os.RemoteException"></exception>
		void exposeFallback();

		/// <exception cref="android.os.RemoteException"></exception>
		void pokeWakelock();
	}

	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public static class IFaceLockCallbackClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.policy.@internal.IFaceLockCallback
		{
			internal const string DESCRIPTOR = "com.android.internal.policy.IFaceLockCallback";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.policy.IFaceLockCallback interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.policy.IFaceLockCallback interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.policy.@internal.IFaceLockCallback asInterface(android.os.IBinder
				 obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.policy.@internal.IFaceLockCallback)))
				{
					return ((android.policy.@internal.IFaceLockCallback)iin);
				}
				return new android.policy.@internal.IFaceLockCallbackClass.Stub.Proxy(obj);
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

					case TRANSACTION_unlock:
					{
						data.enforceInterface(DESCRIPTOR);
						this.unlock();
						return true;
					}

					case TRANSACTION_cancel:
					{
						data.enforceInterface(DESCRIPTOR);
						this.cancel();
						return true;
					}

					case TRANSACTION_reportFailedAttempt:
					{
						data.enforceInterface(DESCRIPTOR);
						this.reportFailedAttempt();
						return true;
					}

					case TRANSACTION_exposeFallback:
					{
						data.enforceInterface(DESCRIPTOR);
						this.exposeFallback();
						return true;
					}

					case TRANSACTION_pokeWakelock:
					{
						data.enforceInterface(DESCRIPTOR);
						this.pokeWakelock();
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.policy.@internal.IFaceLockCallback
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
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockCallback")]
				public virtual void unlock()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.policy.@internal.IFaceLockCallbackClass.Stub.TRANSACTION_unlock
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockCallback")]
				public virtual void cancel()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.policy.@internal.IFaceLockCallbackClass.Stub.TRANSACTION_cancel
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockCallback")]
				public virtual void reportFailedAttempt()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.policy.@internal.IFaceLockCallbackClass.Stub.TRANSACTION_reportFailedAttempt
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockCallback")]
				public virtual void exposeFallback()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.policy.@internal.IFaceLockCallbackClass.Stub.TRANSACTION_exposeFallback
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.policy.IFaceLockCallback")]
				public virtual void pokeWakelock()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.policy.@internal.IFaceLockCallbackClass.Stub.TRANSACTION_pokeWakelock
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}
			}

			internal const int TRANSACTION_unlock = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_cancel = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_reportFailedAttempt = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_exposeFallback = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_pokeWakelock = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			public abstract void cancel();

			public abstract void exposeFallback();

			public abstract void pokeWakelock();

			public abstract void reportFailedAttempt();

			public abstract void unlock();
		}
	}
}
