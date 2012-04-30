using Sharpen;

namespace android.appwidget.@internal
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public interface IAppWidgetService : android.os.IInterface
	{
		//
		// for AppWidgetHost
		//
		//
		// for AppWidgetManager
		//
		//
		// for AppWidgetHost
		//
		/// <exception cref="android.os.RemoteException"></exception>
		int[] startListening(android.appwidget.@internal.IAppWidgetHost host, string packageName
			, int hostId, java.util.List<android.widget.RemoteViews> updatedViews);

		/// <exception cref="android.os.RemoteException"></exception>
		void stopListening(int hostId);

		/// <exception cref="android.os.RemoteException"></exception>
		int allocateAppWidgetId(string packageName, int hostId);

		/// <exception cref="android.os.RemoteException"></exception>
		void deleteAppWidgetId(int appWidgetId);

		/// <exception cref="android.os.RemoteException"></exception>
		void deleteHost(int hostId);

		/// <exception cref="android.os.RemoteException"></exception>
		void deleteAllHosts();

		/// <exception cref="android.os.RemoteException"></exception>
		android.widget.RemoteViews getAppWidgetViews(int appWidgetId);

		//
		// for AppWidgetManager
		//
		/// <exception cref="android.os.RemoteException"></exception>
		void updateAppWidgetIds(int[] appWidgetIds, android.widget.RemoteViews views);

		/// <exception cref="android.os.RemoteException"></exception>
		void partiallyUpdateAppWidgetIds(int[] appWidgetIds, android.widget.RemoteViews views
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void updateAppWidgetProvider(android.content.ComponentName provider, android.widget.RemoteViews
			 views);

		/// <exception cref="android.os.RemoteException"></exception>
		void notifyAppWidgetViewDataChanged(int[] appWidgetIds, int viewId);

		/// <exception cref="android.os.RemoteException"></exception>
		java.util.List<android.appwidget.AppWidgetProviderInfo> getInstalledProviders();

		/// <exception cref="android.os.RemoteException"></exception>
		android.appwidget.AppWidgetProviderInfo getAppWidgetInfo(int appWidgetId);

		/// <exception cref="android.os.RemoteException"></exception>
		void bindAppWidgetId(int appWidgetId, android.content.ComponentName provider);

		/// <exception cref="android.os.RemoteException"></exception>
		void bindRemoteViewsService(int appWidgetId, android.content.Intent intent, android.os.IBinder
			 connection);

		/// <exception cref="android.os.RemoteException"></exception>
		void unbindRemoteViewsService(int appWidgetId, android.content.Intent intent);

		/// <exception cref="android.os.RemoteException"></exception>
		int[] getAppWidgetIds(android.content.ComponentName provider);
	}

	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public static class IAppWidgetServiceClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.appwidget.@internal.IAppWidgetService
		{
			internal const string DESCRIPTOR = "com.android.internal.appwidget.IAppWidgetService";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.appwidget.IAppWidgetService interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.appwidget.IAppWidgetService interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.appwidget.@internal.IAppWidgetService asInterface(android.os.IBinder
				 obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.appwidget.@internal.IAppWidgetService)))
				{
					return ((android.appwidget.@internal.IAppWidgetService)iin);
				}
				return new android.appwidget.@internal.IAppWidgetServiceClass.Stub.Proxy(obj);
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

					case TRANSACTION_startListening:
					{
						data.enforceInterface(DESCRIPTOR);
						android.appwidget.@internal.IAppWidgetHost _arg0;
						_arg0 = android.appwidget.@internal.IAppWidgetHostClass.Stub.asInterface(data.readStrongBinder
							());
						string _arg1;
						_arg1 = data.readString();
						int _arg2;
						_arg2 = data.readInt();
						java.util.List<android.widget.RemoteViews> _arg3;
						_arg3 = new java.util.ArrayList<android.widget.RemoteViews>();
						int[] _result = this.startListening(_arg0, _arg1, _arg2, _arg3);
						reply.writeNoException();
						reply.writeIntArray(_result);
						reply.writeTypedList(_arg3);
						return true;
					}

					case TRANSACTION_stopListening:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.stopListening(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_allocateAppWidgetId:
					{
						data.enforceInterface(DESCRIPTOR);
						string _arg0;
						_arg0 = data.readString();
						int _arg1;
						_arg1 = data.readInt();
						int _result = this.allocateAppWidgetId(_arg0, _arg1);
						reply.writeNoException();
						reply.writeInt(_result);
						return true;
					}

					case TRANSACTION_deleteAppWidgetId:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.deleteAppWidgetId(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_deleteHost:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.deleteHost(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_deleteAllHosts:
					{
						data.enforceInterface(DESCRIPTOR);
						this.deleteAllHosts();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_getAppWidgetViews:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.widget.RemoteViews _result = this.getAppWidgetViews(_arg0);
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

					case TRANSACTION_updateAppWidgetIds:
					{
						data.enforceInterface(DESCRIPTOR);
						int[] _arg0;
						_arg0 = data.createIntArray();
						android.widget.RemoteViews _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.widget.RemoteViews.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.updateAppWidgetIds(_arg0, _arg1);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_partiallyUpdateAppWidgetIds:
					{
						data.enforceInterface(DESCRIPTOR);
						int[] _arg0;
						_arg0 = data.createIntArray();
						android.widget.RemoteViews _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.widget.RemoteViews.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.partiallyUpdateAppWidgetIds(_arg0, _arg1);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_updateAppWidgetProvider:
					{
						data.enforceInterface(DESCRIPTOR);
						android.content.ComponentName _arg0;
						if ((0 != data.readInt()))
						{
							_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg0 = null;
						}
						android.widget.RemoteViews _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.widget.RemoteViews.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.updateAppWidgetProvider(_arg0, _arg1);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_notifyAppWidgetViewDataChanged:
					{
						data.enforceInterface(DESCRIPTOR);
						int[] _arg0;
						_arg0 = data.createIntArray();
						int _arg1;
						_arg1 = data.readInt();
						this.notifyAppWidgetViewDataChanged(_arg0, _arg1);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_getInstalledProviders:
					{
						data.enforceInterface(DESCRIPTOR);
						java.util.List<android.appwidget.AppWidgetProviderInfo> _result = this.getInstalledProviders
							();
						reply.writeNoException();
						reply.writeTypedList(_result);
						return true;
					}

					case TRANSACTION_getAppWidgetInfo:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.appwidget.AppWidgetProviderInfo _result = this.getAppWidgetInfo(_arg0);
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

					case TRANSACTION_bindAppWidgetId:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.content.ComponentName _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.content.ComponentName.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.bindAppWidgetId(_arg0, _arg1);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_bindRemoteViewsService:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.content.Intent _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.content.Intent.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						android.os.IBinder _arg2;
						_arg2 = data.readStrongBinder();
						this.bindRemoteViewsService(_arg0, _arg1, _arg2);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_unbindRemoteViewsService:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.content.Intent _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.content.Intent.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.unbindRemoteViewsService(_arg0, _arg1);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_getAppWidgetIds:
					{
						data.enforceInterface(DESCRIPTOR);
						android.content.ComponentName _arg0;
						if ((0 != data.readInt()))
						{
							_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg0 = null;
						}
						int[] _result = this.getAppWidgetIds(_arg0);
						reply.writeNoException();
						reply.writeIntArray(_result);
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.appwidget.@internal.IAppWidgetService
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual int[] startListening(android.appwidget.@internal.IAppWidgetHost host
					, string packageName, int hostId, java.util.List<android.widget.RemoteViews> updatedViews
					)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					int[] _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder((((host != null)) ? (host.asBinder()) : (null)));
						_data.writeString(packageName);
						_data.writeInt(hostId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_startListening
							, _data, _reply, 0);
						_reply.readException();
						_result = _reply.createIntArray();
						_reply.readTypedList(updatedViews, android.widget.RemoteViews.CREATOR);
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void stopListening(int hostId)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(hostId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_stopListening
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual int allocateAppWidgetId(string packageName, int hostId)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					int _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeString(packageName);
						_data.writeInt(hostId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_allocateAppWidgetId
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void deleteAppWidgetId(int appWidgetId)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_deleteAppWidgetId
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void deleteHost(int hostId)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(hostId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_deleteHost
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void deleteAllHosts()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_deleteAllHosts
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual android.widget.RemoteViews getAppWidgetViews(int appWidgetId)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					android.widget.RemoteViews _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_getAppWidgetViews
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void updateAppWidgetIds(int[] appWidgetIds, android.widget.RemoteViews
					 views)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeIntArray(appWidgetIds);
						if ((views != null))
						{
							_data.writeInt(1);
							views.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_updateAppWidgetIds
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void partiallyUpdateAppWidgetIds(int[] appWidgetIds, android.widget.RemoteViews
					 views)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeIntArray(appWidgetIds);
						if ((views != null))
						{
							_data.writeInt(1);
							views.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_partiallyUpdateAppWidgetIds
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void updateAppWidgetProvider(android.content.ComponentName provider
					, android.widget.RemoteViews views)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						if ((provider != null))
						{
							_data.writeInt(1);
							provider.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						if ((views != null))
						{
							_data.writeInt(1);
							views.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_updateAppWidgetProvider
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void notifyAppWidgetViewDataChanged(int[] appWidgetIds, int viewId
					)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeIntArray(appWidgetIds);
						_data.writeInt(viewId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_notifyAppWidgetViewDataChanged
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual java.util.List<android.appwidget.AppWidgetProviderInfo> getInstalledProviders
					()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					java.util.List<android.appwidget.AppWidgetProviderInfo> _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_getInstalledProviders
							, _data, _reply, 0);
						_reply.readException();
						_result = _reply.createTypedArrayList(android.appwidget.AppWidgetProviderInfo.CREATOR
							);
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual android.appwidget.AppWidgetProviderInfo getAppWidgetInfo(int appWidgetId
					)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					android.appwidget.AppWidgetProviderInfo _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_getAppWidgetInfo
							, _data, _reply, 0);
						_reply.readException();
						if ((0 != _reply.readInt()))
						{
							_result = android.appwidget.AppWidgetProviderInfo.CREATOR.createFromParcel(_reply
								);
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void bindAppWidgetId(int appWidgetId, android.content.ComponentName
					 provider)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						if ((provider != null))
						{
							_data.writeInt(1);
							provider.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_bindAppWidgetId
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void bindRemoteViewsService(int appWidgetId, android.content.Intent
					 intent, android.os.IBinder connection)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						if ((intent != null))
						{
							_data.writeInt(1);
							intent.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						_data.writeStrongBinder(connection);
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_bindRemoteViewsService
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual void unbindRemoteViewsService(int appWidgetId, android.content.Intent
					 intent)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						if ((intent != null))
						{
							_data.writeInt(1);
							intent.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_unbindRemoteViewsService
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetService")]
				public virtual int[] getAppWidgetIds(android.content.ComponentName provider)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					int[] _result;
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						if ((provider != null))
						{
							_data.writeInt(1);
							provider.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetServiceClass.Stub.TRANSACTION_getAppWidgetIds
							, _data, _reply, 0);
						_reply.readException();
						_result = _reply.createIntArray();
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
					return _result;
				}
			}

			internal const int TRANSACTION_startListening = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_stopListening = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_allocateAppWidgetId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_deleteAppWidgetId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_deleteHost = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_deleteAllHosts = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_getAppWidgetViews = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_updateAppWidgetIds = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_partiallyUpdateAppWidgetIds = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_updateAppWidgetProvider = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_notifyAppWidgetViewDataChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_getInstalledProviders = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_getAppWidgetInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_bindAppWidgetId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_bindRemoteViewsService = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_unbindRemoteViewsService = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_getAppWidgetIds = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			public abstract int allocateAppWidgetId(string arg1, int arg2);

			public abstract void bindAppWidgetId(int arg1, android.content.ComponentName arg2
				);

			public abstract void bindRemoteViewsService(int arg1, android.content.Intent arg2
				, android.os.IBinder arg3);

			public abstract void deleteAllHosts();

			public abstract void deleteAppWidgetId(int arg1);

			public abstract void deleteHost(int arg1);

			public abstract int[] getAppWidgetIds(android.content.ComponentName arg1);

			public abstract android.appwidget.AppWidgetProviderInfo getAppWidgetInfo(int arg1
				);

			public abstract android.widget.RemoteViews getAppWidgetViews(int arg1);

			public abstract java.util.List<android.appwidget.AppWidgetProviderInfo> getInstalledProviders
				();

			public abstract void notifyAppWidgetViewDataChanged(int[] arg1, int arg2);

			public abstract void partiallyUpdateAppWidgetIds(int[] arg1, android.widget.RemoteViews
				 arg2);

			public abstract int[] startListening(android.appwidget.@internal.IAppWidgetHost arg1
				, string arg2, int arg3, java.util.List<android.widget.RemoteViews> arg4);

			public abstract void stopListening(int arg1);

			public abstract void unbindRemoteViewsService(int arg1, android.content.Intent arg2
				);

			public abstract void updateAppWidgetIds(int[] arg1, android.widget.RemoteViews arg2
				);

			public abstract void updateAppWidgetProvider(android.content.ComponentName arg1, 
				android.widget.RemoteViews arg2);
		}
	}
}
