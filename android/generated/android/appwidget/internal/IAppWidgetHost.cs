using Sharpen;

namespace android.appwidget.@internal
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public interface IAppWidgetHost : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void updateAppWidget(int appWidgetId, android.widget.RemoteViews views);

		/// <exception cref="android.os.RemoteException"></exception>
		void providerChanged(int appWidgetId, android.appwidget.AppWidgetProviderInfo info
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void viewDataChanged(int appWidgetId, int viewId);
	}

	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public static class IAppWidgetHostClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.appwidget.@internal.IAppWidgetHost
		{
			internal const string DESCRIPTOR = "com.android.internal.appwidget.IAppWidgetHost";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.appwidget.IAppWidgetHost interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.appwidget.IAppWidgetHost interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.appwidget.@internal.IAppWidgetHost asInterface(android.os.IBinder
				 obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.appwidget.@internal.IAppWidgetHost)))
				{
					return ((android.appwidget.@internal.IAppWidgetHost)iin);
				}
				return new android.appwidget.@internal.IAppWidgetHostClass.Stub.Proxy(obj);
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

					case TRANSACTION_updateAppWidget:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.widget.RemoteViews _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.widget.RemoteViews.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.updateAppWidget(_arg0, _arg1);
						return true;
					}

					case TRANSACTION_providerChanged:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.appwidget.AppWidgetProviderInfo _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.appwidget.AppWidgetProviderInfo.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.providerChanged(_arg0, _arg1);
						return true;
					}

					case TRANSACTION_viewDataChanged:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						int _arg1;
						_arg1 = data.readInt();
						this.viewDataChanged(_arg0, _arg1);
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.appwidget.@internal.IAppWidgetHost
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
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetHost")]
				public virtual void updateAppWidget(int appWidgetId, android.widget.RemoteViews views
					)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						if ((views != null))
						{
							_data.writeInt(1);
							views.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetHostClass.Stub.TRANSACTION_updateAppWidget
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetHost")]
				public virtual void providerChanged(int appWidgetId, android.appwidget.AppWidgetProviderInfo
					 info)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						if ((info != null))
						{
							_data.writeInt(1);
							info.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.appwidget.@internal.IAppWidgetHostClass.Stub.TRANSACTION_providerChanged
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.appwidget.IAppWidgetHost")]
				public virtual void viewDataChanged(int appWidgetId, int viewId)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(appWidgetId);
						_data.writeInt(viewId);
						mRemote.transact(android.appwidget.@internal.IAppWidgetHostClass.Stub.TRANSACTION_viewDataChanged
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}
			}

			internal const int TRANSACTION_updateAppWidget = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_providerChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_viewDataChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			public abstract void providerChanged(int arg1, android.appwidget.AppWidgetProviderInfo
				 arg2);

			public abstract void updateAppWidget(int arg1, android.widget.RemoteViews arg2);

			public abstract void viewDataChanged(int arg1, int arg2);
		}
	}
}
