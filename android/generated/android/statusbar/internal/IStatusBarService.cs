using Sharpen;

namespace android.statusbar.@internal
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface IStatusBarService : android.os.IInterface
	{
		// ---- Methods below are for use by the status bar policy services ----
		// You need the STATUS_BAR_SERVICE permission
		/// <exception cref="android.os.RemoteException"></exception>
		void expand();

		/// <exception cref="android.os.RemoteException"></exception>
		void collapse();

		/// <exception cref="android.os.RemoteException"></exception>
		void disable(int what, android.os.IBinder token, string pkg);

		/// <exception cref="android.os.RemoteException"></exception>
		void setIcon(string slot, string iconPackage, int iconId, int iconLevel, string contentDescription
			);

		/// <exception cref="android.os.RemoteException"></exception>
		void setIconVisibility(string slot, bool visible);

		/// <exception cref="android.os.RemoteException"></exception>
		void removeIcon(string slot);

		/// <exception cref="android.os.RemoteException"></exception>
		void topAppWindowChanged(bool menuVisible);

		/// <exception cref="android.os.RemoteException"></exception>
		void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition);

		// ---- Methods below are for use by the status bar policy services ----
		// You need the STATUS_BAR_SERVICE permission
		/// <exception cref="android.os.RemoteException"></exception>
		void registerStatusBar(android.statusbar.@internal.IStatusBar callbacks, android.statusbar.@internal.StatusBarIconList
			 iconList, java.util.List<android.os.IBinder> notificationKeys, java.util.List<android.statusbar.@internal.StatusBarNotification
			> notifications, int[] switches, java.util.List<android.os.IBinder> binders);

		/// <exception cref="android.os.RemoteException"></exception>
		void onPanelRevealed();

		/// <exception cref="android.os.RemoteException"></exception>
		void onNotificationClick(string pkg, string tag, int id);

		/// <exception cref="android.os.RemoteException"></exception>
		void onNotificationError(string pkg, string tag, int id, int uid, int initialPid, 
			string message);

		/// <exception cref="android.os.RemoteException"></exception>
		void onClearAllNotifications();

		/// <exception cref="android.os.RemoteException"></exception>
		void onNotificationClear(string pkg, string tag, int id);

		/// <exception cref="android.os.RemoteException"></exception>
		void setSystemUiVisibility(int vis);

		/// <exception cref="android.os.RemoteException"></exception>
		void setHardKeyboardEnabled(bool enabled);

		/// <exception cref="android.os.RemoteException"></exception>
		void toggleRecentApps();
	}

	/// <hide></hide>
	[Sharpen.Sharpened]
	public static class IStatusBarServiceClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.statusbar.@internal.IStatusBarService
		{
			internal const string DESCRIPTOR = "com.android.internal.statusbar.IStatusBarService";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.statusbar.IStatusBarService interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.statusbar.IStatusBarService interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.statusbar.@internal.IStatusBarService asInterface(android.os.IBinder
				 obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.statusbar.@internal.IStatusBarService)))
				{
					return ((android.statusbar.@internal.IStatusBarService)iin);
				}
				return new android.statusbar.@internal.IStatusBarServiceClass.Stub.Proxy(obj);
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

					case TRANSACTION_expand:
					{
						data.enforceInterface(DESCRIPTOR);
						this.expand();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_collapse:
					{
						data.enforceInterface(DESCRIPTOR);
						this.collapse();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_disable:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.os.IBinder _arg1;
						_arg1 = data.readStrongBinder();
						string _arg2;
						_arg2 = data.readString();
						this.disable(_arg0, _arg1, _arg2);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_setIcon:
					{
						data.enforceInterface(DESCRIPTOR);
						string _arg0;
						_arg0 = data.readString();
						string _arg1;
						_arg1 = data.readString();
						int _arg2;
						_arg2 = data.readInt();
						int _arg3;
						_arg3 = data.readInt();
						string _arg4;
						_arg4 = data.readString();
						this.setIcon(_arg0, _arg1, _arg2, _arg3, _arg4);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_setIconVisibility:
					{
						data.enforceInterface(DESCRIPTOR);
						string _arg0;
						_arg0 = data.readString();
						bool _arg1;
						_arg1 = (0 != data.readInt());
						this.setIconVisibility(_arg0, _arg1);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_removeIcon:
					{
						data.enforceInterface(DESCRIPTOR);
						string _arg0;
						_arg0 = data.readString();
						this.removeIcon(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_topAppWindowChanged:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _arg0;
						_arg0 = (0 != data.readInt());
						this.topAppWindowChanged(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_setImeWindowStatus:
					{
						data.enforceInterface(DESCRIPTOR);
						android.os.IBinder _arg0;
						_arg0 = data.readStrongBinder();
						int _arg1;
						_arg1 = data.readInt();
						int _arg2;
						_arg2 = data.readInt();
						this.setImeWindowStatus(_arg0, _arg1, _arg2);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_registerStatusBar:
					{
						data.enforceInterface(DESCRIPTOR);
						android.statusbar.@internal.IStatusBar _arg0;
						_arg0 = android.statusbar.@internal.IStatusBarClass.Stub.asInterface(data.readStrongBinder
							());
						android.statusbar.@internal.StatusBarIconList _arg1;
						_arg1 = new android.statusbar.@internal.StatusBarIconList();
						java.util.List<android.os.IBinder> _arg2;
						_arg2 = new java.util.ArrayList<android.os.IBinder>();
						java.util.List<android.statusbar.@internal.StatusBarNotification> _arg3;
						_arg3 = new java.util.ArrayList<android.statusbar.@internal.StatusBarNotification
							>();
						int[] _arg4;
						int _arg4_length = data.readInt();
						if ((_arg4_length < 0))
						{
							_arg4 = null;
						}
						else
						{
							_arg4 = new int[_arg4_length];
						}
						java.util.List<android.os.IBinder> _arg5;
						_arg5 = new java.util.ArrayList<android.os.IBinder>();
						this.registerStatusBar(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
						reply.writeNoException();
						if ((_arg1 != null))
						{
							reply.writeInt(1);
							_arg1.writeToParcel(reply, android.os.ParcelableClass.PARCELABLE_WRITE_RETURN_VALUE
								);
						}
						else
						{
							reply.writeInt(0);
						}
						reply.writeBinderList(_arg2);
						reply.writeTypedList(_arg3);
						reply.writeIntArray(_arg4);
						reply.writeBinderList(_arg5);
						return true;
					}

					case TRANSACTION_onPanelRevealed:
					{
						data.enforceInterface(DESCRIPTOR);
						this.onPanelRevealed();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_onNotificationClick:
					{
						data.enforceInterface(DESCRIPTOR);
						string _arg0;
						_arg0 = data.readString();
						string _arg1;
						_arg1 = data.readString();
						int _arg2;
						_arg2 = data.readInt();
						this.onNotificationClick(_arg0, _arg1, _arg2);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_onNotificationError:
					{
						data.enforceInterface(DESCRIPTOR);
						string _arg0;
						_arg0 = data.readString();
						string _arg1;
						_arg1 = data.readString();
						int _arg2;
						_arg2 = data.readInt();
						int _arg3;
						_arg3 = data.readInt();
						int _arg4;
						_arg4 = data.readInt();
						string _arg5;
						_arg5 = data.readString();
						this.onNotificationError(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_onClearAllNotifications:
					{
						data.enforceInterface(DESCRIPTOR);
						this.onClearAllNotifications();
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_onNotificationClear:
					{
						data.enforceInterface(DESCRIPTOR);
						string _arg0;
						_arg0 = data.readString();
						string _arg1;
						_arg1 = data.readString();
						int _arg2;
						_arg2 = data.readInt();
						this.onNotificationClear(_arg0, _arg1, _arg2);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_setSystemUiVisibility:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.setSystemUiVisibility(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_setHardKeyboardEnabled:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _arg0;
						_arg0 = (0 != data.readInt());
						this.setHardKeyboardEnabled(_arg0);
						reply.writeNoException();
						return true;
					}

					case TRANSACTION_toggleRecentApps:
					{
						data.enforceInterface(DESCRIPTOR);
						this.toggleRecentApps();
						reply.writeNoException();
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.statusbar.@internal.IStatusBarService
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void expand()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_expand
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void collapse()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_collapse
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void disable(int what, android.os.IBinder token, string pkg)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(what);
						_data.writeStrongBinder(token);
						_data.writeString(pkg);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_disable
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void setIcon(string slot, string iconPackage, int iconId, int iconLevel
					, string contentDescription)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeString(slot);
						_data.writeString(iconPackage);
						_data.writeInt(iconId);
						_data.writeInt(iconLevel);
						_data.writeString(contentDescription);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_setIcon
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void setIconVisibility(string slot, bool visible)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeString(slot);
						_data.writeInt(((visible) ? (1) : (0)));
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_setIconVisibility
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void removeIcon(string slot)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeString(slot);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_removeIcon
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void topAppWindowChanged(bool menuVisible)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(((menuVisible) ? (1) : (0)));
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_topAppWindowChanged
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition
					)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder(token);
						_data.writeInt(vis);
						_data.writeInt(backDisposition);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_setImeWindowStatus
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void registerStatusBar(android.statusbar.@internal.IStatusBar callbacks
					, android.statusbar.@internal.StatusBarIconList iconList, java.util.List<android.os.IBinder
					> notificationKeys, java.util.List<android.statusbar.@internal.StatusBarNotification
					> notifications, int[] switches, java.util.List<android.os.IBinder> binders)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder((((callbacks != null)) ? (callbacks.asBinder()) : (null))
							);
						if ((switches == null))
						{
							_data.writeInt(-1);
						}
						else
						{
							_data.writeInt(switches.Length);
						}
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_registerStatusBar
							, _data, _reply, 0);
						_reply.readException();
						if ((0 != _reply.readInt()))
						{
							iconList.readFromParcel(_reply);
						}
						_reply.readBinderList(notificationKeys);
						_reply.readTypedList(notifications, android.statusbar.@internal.StatusBarNotification
							.CREATOR);
						_reply.readIntArray(switches);
						_reply.readBinderList(binders);
					}
					finally
					{
						_reply.recycle();
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void onPanelRevealed()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_onPanelRevealed
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void onNotificationClick(string pkg, string tag, int id)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeString(pkg);
						_data.writeString(tag);
						_data.writeInt(id);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_onNotificationClick
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void onNotificationError(string pkg, string tag, int id, int uid, 
					int initialPid, string message)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeString(pkg);
						_data.writeString(tag);
						_data.writeInt(id);
						_data.writeInt(uid);
						_data.writeInt(initialPid);
						_data.writeString(message);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_onNotificationError
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void onClearAllNotifications()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_onClearAllNotifications
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void onNotificationClear(string pkg, string tag, int id)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeString(pkg);
						_data.writeString(tag);
						_data.writeInt(id);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_onNotificationClear
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void setSystemUiVisibility(int vis)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(vis);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_setSystemUiVisibility
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void setHardKeyboardEnabled(bool enabled)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(((enabled) ? (1) : (0)));
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_setHardKeyboardEnabled
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBarService")]
				public virtual void toggleRecentApps()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					android.os.Parcel _reply = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarServiceClass.Stub.TRANSACTION_toggleRecentApps
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

			internal const int TRANSACTION_expand = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_collapse = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_disable = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_setIcon = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_setIconVisibility = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_removeIcon = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_topAppWindowChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_setImeWindowStatus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_registerStatusBar = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_onPanelRevealed = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_onNotificationClick = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_onNotificationError = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_onClearAllNotifications = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_onNotificationClear = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_setSystemUiVisibility = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_setHardKeyboardEnabled = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_toggleRecentApps = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			public abstract void collapse();

			public abstract void disable(int arg1, android.os.IBinder arg2, string arg3);

			public abstract void expand();

			public abstract void onClearAllNotifications();

			public abstract void onNotificationClear(string arg1, string arg2, int arg3);

			public abstract void onNotificationClick(string arg1, string arg2, int arg3);

			public abstract void onNotificationError(string arg1, string arg2, int arg3, int 
				arg4, int arg5, string arg6);

			public abstract void onPanelRevealed();

			public abstract void registerStatusBar(android.statusbar.@internal.IStatusBar arg1
				, android.statusbar.@internal.StatusBarIconList arg2, java.util.List<android.os.IBinder
				> arg3, java.util.List<android.statusbar.@internal.StatusBarNotification> arg4, 
				int[] arg5, java.util.List<android.os.IBinder> arg6);

			public abstract void removeIcon(string arg1);

			public abstract void setHardKeyboardEnabled(bool arg1);

			public abstract void setIcon(string arg1, string arg2, int arg3, int arg4, string
				 arg5);

			public abstract void setIconVisibility(string arg1, bool arg2);

			public abstract void setImeWindowStatus(android.os.IBinder arg1, int arg2, int arg3
				);

			public abstract void setSystemUiVisibility(int arg1);

			public abstract void toggleRecentApps();

			public abstract void topAppWindowChanged(bool arg1);
		}
	}
}
