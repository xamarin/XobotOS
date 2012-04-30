using Sharpen;

namespace android.view
{
	/// <summary><hide></hide></summary>
	[Sharpen.Sharpened]
	public interface IRotationWatcher : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void onRotationChanged(int rotation);
	}

	/// <summary><hide></hide></summary>
	[Sharpen.Sharpened]
	public static class IRotationWatcherClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.view.IRotationWatcher
		{
			internal const string DESCRIPTOR = "android.view.IRotationWatcher";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an android.view.IRotationWatcher interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an android.view.IRotationWatcher interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.view.IRotationWatcher asInterface(android.os.IBinder obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.view.IRotationWatcher)))
				{
					return ((android.view.IRotationWatcher)iin);
				}
				return new android.view.IRotationWatcherClass.Stub.Proxy(obj);
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

					case TRANSACTION_onRotationChanged:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.onRotationChanged(_arg0);
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.view.IRotationWatcher
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
				[Sharpen.ImplementsInterface(@"android.view.IRotationWatcher")]
				public virtual void onRotationChanged(int rotation)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(rotation);
						mRemote.transact(android.view.IRotationWatcherClass.Stub.TRANSACTION_onRotationChanged
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}
			}

			internal const int TRANSACTION_onRotationChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onRotationChanged(int arg1);
		}
	}
}
