using Sharpen;

namespace android.widget.@internal
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public interface IRemoteViewsFactory : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void onDataSetChanged();

		/// <exception cref="android.os.RemoteException"></exception>
		void onDestroy(android.content.Intent intent);

		/// <exception cref="android.os.RemoteException"></exception>
		int getCount();

		/// <exception cref="android.os.RemoteException"></exception>
		android.widget.RemoteViews getViewAt(int position);

		/// <exception cref="android.os.RemoteException"></exception>
		android.widget.RemoteViews getLoadingView();

		/// <exception cref="android.os.RemoteException"></exception>
		int getViewTypeCount();

		/// <exception cref="android.os.RemoteException"></exception>
		long getItemId(int position);

		/// <exception cref="android.os.RemoteException"></exception>
		bool hasStableIds();

		/// <exception cref="android.os.RemoteException"></exception>
		bool isCreated();
	}

	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public static class IRemoteViewsFactoryClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.widget.@internal.IRemoteViewsFactory
		{
			internal const string DESCRIPTOR = "com.android.internal.widget.IRemoteViewsFactory";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.widget.IRemoteViewsFactory interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.widget.IRemoteViewsFactory interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.widget.@internal.IRemoteViewsFactory asInterface(android.os.IBinder
				 obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.widget.@internal.IRemoteViewsFactory)))
				{
					return ((android.widget.@internal.IRemoteViewsFactory)iin);
				}
				return new android.widget.@internal.IRemoteViewsFactoryClass.Stub.Proxy(obj);
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

					case TRANSACTION_onDataSetChanged:
					{
						data.enforceInterface(DESCRIPTOR);
						this.onDataSetChanged();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_onDestroy:
					{
						data.enforceInterface(DESCRIPTOR);
						android.content.Intent _arg0;
						if ((0 != data.readInt()))
						{
							_arg0 = android.content.Intent.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg0 = null;
						}
						this.onDestroy(_arg0);
						return true;
					}

					case TRANSACTION_getCount:
					{
						data.enforceInterface(DESCRIPTOR);
						int _result = this.getCount();
						reply.writeNoException();
						reply.writeInt(_result);
						return true;
					}

					case TRANSACTION_getViewAt:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.widget.RemoteViews _result = this.getViewAt(_arg0);
						reply.writeNoException();
						if ((_result != null))
						{
							reply.writeInt(1);
							_result.writeToParcel(reply, android.os.ParcelableClass.PARCELABLE_WRITE_RETURN_VALUE
								);
						}
						else
						{
							reply.writeInt(0);
						}
						return true;
					}

					case TRANSACTION_getLoadingView:
					{
						data.enforceInterface(DESCRIPTOR);
						android.widget.RemoteViews _result = this.getLoadingView();
						reply.writeNoException();
						if ((_result != null))
						{
							reply.writeInt(1);
							_result.writeToParcel(reply, android.os.ParcelableClass.PARCELABLE_WRITE_RETURN_VALUE
								);
						}
						else
						{
							reply.writeInt(0);
						}
						return true;
					}

					case TRANSACTION_getViewTypeCount:
					{
						data.enforceInterface(DESCRIPTOR);
						int _result = this.getViewTypeCount();
						reply.writeNoException();
						reply.writeInt(_result);
						return true;
					}

					case TRANSACTION_getItemId:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						long _result = this.getItemId(_arg0);
						reply.writeNoException();
						reply.writeLong(_result);
						return true;
					}

					case TRANSACTION_hasStableIds:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _result = this.hasStableIds();
						reply.writeNoException();
						reply.writeInt(((_result) ? (1) : (0)));
						return true;
					}

					case TRANSACTION_isCreated:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _result = this.isCreated();
						reply.writeNoException();
						reply.writeInt(((_result) ? (1) : (0)));
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.widget.@internal.IRemoteViewsFactory
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
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual void onDataSetChanged()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_onDataSetChanged
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
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual void onDestroy(android.content.Intent intent)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						if ((intent != null))
						{
							_data.writeInt(1);
							intent.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_onDestroy
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual int getCount()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					int _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_getCount
							, _data, _reply, 0);
						_reply.readException();
						_result = _reply.readInt();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual android.widget.RemoteViews getViewAt(int position)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					android.widget.RemoteViews _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(position);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_getViewAt
							, _data, _reply, 0);
						_reply.readException();
						if ((0 != _reply.readInt()))
						{
							_result = android.widget.RemoteViews.CREATOR.createFromParcel(_reply);
						}
						else
						{
							_result = null;
						}
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual android.widget.RemoteViews getLoadingView()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					android.widget.RemoteViews _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_getLoadingView
							, _data, _reply, 0);
						_reply.readException();
						if ((0 != _reply.readInt()))
						{
							_result = android.widget.RemoteViews.CREATOR.createFromParcel(_reply);
						}
						else
						{
							_result = null;
						}
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual int getViewTypeCount()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					int _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_getViewTypeCount
							, _data, _reply, 0);
						_reply.readException();
						_result = _reply.readInt();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual long getItemId(int position)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					long _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(position);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_getItemId
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

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual bool hasStableIds()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					bool _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_hasStableIds
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
				[Sharpen.ImplementsInterface(@"com.android.internal.widget.IRemoteViewsFactory")]
				public virtual bool isCreated()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					bool _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.widget.@internal.IRemoteViewsFactoryClass.Stub.TRANSACTION_isCreated
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
			}

			internal const int TRANSACTION_onDataSetChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_onDestroy = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getCount = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_getViewAt = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_getLoadingView = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_getViewTypeCount = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_getItemId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_hasStableIds = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_isCreated = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			public abstract int getCount();

			public abstract long getItemId(int arg1);

			public abstract android.widget.RemoteViews getLoadingView();

			public abstract android.widget.RemoteViews getViewAt(int arg1);

			public abstract int getViewTypeCount();

			public abstract bool hasStableIds();

			public abstract bool isCreated();

			public abstract void onDataSetChanged();

			public abstract void onDestroy(android.content.Intent arg1);
		}
	}
}
