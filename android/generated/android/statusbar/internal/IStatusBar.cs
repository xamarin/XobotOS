using Sharpen;

namespace android.statusbar.@internal
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface IStatusBar : android.os.IInterface
	{
		/// <exception cref="android.os.RemoteException"></exception>
		void setIcon(int index, android.statusbar.@internal.StatusBarIcon icon);

		/// <exception cref="android.os.RemoteException"></exception>
		void removeIcon(int index);

		/// <exception cref="android.os.RemoteException"></exception>
		void addNotification(android.os.IBinder key, android.statusbar.@internal.StatusBarNotification
			 notification);

		/// <exception cref="android.os.RemoteException"></exception>
		void updateNotification(android.os.IBinder key, android.statusbar.@internal.StatusBarNotification
			 notification);

		/// <exception cref="android.os.RemoteException"></exception>
		void removeNotification(android.os.IBinder key);

		/// <exception cref="android.os.RemoteException"></exception>
		void disable(int state);

		/// <exception cref="android.os.RemoteException"></exception>
		void animateExpand();

		/// <exception cref="android.os.RemoteException"></exception>
		void animateCollapse();

		/// <exception cref="android.os.RemoteException"></exception>
		void setSystemUiVisibility(int vis);

		/// <exception cref="android.os.RemoteException"></exception>
		void topAppWindowChanged(bool menuVisible);

		/// <exception cref="android.os.RemoteException"></exception>
		void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition);

		/// <exception cref="android.os.RemoteException"></exception>
		void setHardKeyboardStatus(bool available, bool enabled);

		/// <exception cref="android.os.RemoteException"></exception>
		void toggleRecentApps();
	}

	/// <hide></hide>
	[Sharpen.Sharpened]
	public static class IStatusBarClass
	{
		/// <summary>Local-side IPC implementation stub class.</summary>
		/// <remarks>Local-side IPC implementation stub class.</remarks>
		public abstract class Stub : android.os.Binder, android.statusbar.@internal.IStatusBar
		{
			internal const string DESCRIPTOR = "com.android.internal.statusbar.IStatusBar";

			/// <summary>Construct the stub at attach it to the interface.</summary>
			/// <remarks>Construct the stub at attach it to the interface.</remarks>
			public Stub()
			{
				this.attachInterface(this, DESCRIPTOR);
			}

			/// <summary>
			/// Cast an IBinder object into an com.android.internal.statusbar.IStatusBar interface,
			/// generating a proxy if needed.
			/// </summary>
			/// <remarks>
			/// Cast an IBinder object into an com.android.internal.statusbar.IStatusBar interface,
			/// generating a proxy if needed.
			/// </remarks>
			public static android.statusbar.@internal.IStatusBar asInterface(android.os.IBinder
				 obj)
			{
				if ((obj == null))
				{
					return null;
				}
				android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR
					);
				if (((iin != null) && (iin is android.statusbar.@internal.IStatusBar)))
				{
					return ((android.statusbar.@internal.IStatusBar)iin);
				}
				return new android.statusbar.@internal.IStatusBarClass.Stub.Proxy(obj);
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

					case TRANSACTION_setIcon:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						android.statusbar.@internal.StatusBarIcon _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.statusbar.@internal.StatusBarIcon.CREATOR.createFromParcel(data);
						}
						else
						{
							_arg1 = null;
						}
						this.setIcon(_arg0, _arg1);
						return true;
					}

					case TRANSACTION_removeIcon:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.removeIcon(_arg0);
						return true;
					}

					case TRANSACTION_addNotification:
					{
						data.enforceInterface(DESCRIPTOR);
						android.os.IBinder _arg0;
						_arg0 = data.readStrongBinder();
						android.statusbar.@internal.StatusBarNotification _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.statusbar.@internal.StatusBarNotification.CREATOR.createFromParcel
								(data);
						}
						else
						{
							_arg1 = null;
						}
						this.addNotification(_arg0, _arg1);
						return true;
					}

					case TRANSACTION_updateNotification:
					{
						data.enforceInterface(DESCRIPTOR);
						android.os.IBinder _arg0;
						_arg0 = data.readStrongBinder();
						android.statusbar.@internal.StatusBarNotification _arg1;
						if ((0 != data.readInt()))
						{
							_arg1 = android.statusbar.@internal.StatusBarNotification.CREATOR.createFromParcel
								(data);
						}
						else
						{
							_arg1 = null;
						}
						this.updateNotification(_arg0, _arg1);
						return true;
					}

					case TRANSACTION_removeNotification:
					{
						data.enforceInterface(DESCRIPTOR);
						android.os.IBinder _arg0;
						_arg0 = data.readStrongBinder();
						this.removeNotification(_arg0);
						return true;
					}

					case TRANSACTION_disable:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.disable(_arg0);
						return true;
					}

					case TRANSACTION_animateExpand:
					{
						data.enforceInterface(DESCRIPTOR);
						this.animateExpand();
						return true;
					}

					case TRANSACTION_animateCollapse:
					{
						data.enforceInterface(DESCRIPTOR);
						this.animateCollapse();
						return true;
					}

					case TRANSACTION_setSystemUiVisibility:
					{
						data.enforceInterface(DESCRIPTOR);
						int _arg0;
						_arg0 = data.readInt();
						this.setSystemUiVisibility(_arg0);
						return true;
					}

					case TRANSACTION_topAppWindowChanged:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _arg0;
						_arg0 = (0 != data.readInt());
						this.topAppWindowChanged(_arg0);
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
						return true;
					}

					case TRANSACTION_setHardKeyboardStatus:
					{
						data.enforceInterface(DESCRIPTOR);
						bool _arg0;
						_arg0 = (0 != data.readInt());
						bool _arg1;
						_arg1 = (0 != data.readInt());
						this.setHardKeyboardStatus(_arg0, _arg1);
						return true;
					}

					case TRANSACTION_toggleRecentApps:
					{
						data.enforceInterface(DESCRIPTOR);
						this.toggleRecentApps();
						return true;
					}
				}
				return base.onTransact(code, data, reply, flags);
			}

			private class Proxy : android.statusbar.@internal.IStatusBar
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
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void setIcon(int index, android.statusbar.@internal.StatusBarIcon 
					icon)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(index);
						if ((icon != null))
						{
							_data.writeInt(1);
							icon.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_setIcon
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void removeIcon(int index)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(index);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_removeIcon
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void addNotification(android.os.IBinder key, android.statusbar.@internal.StatusBarNotification
					 notification)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder(key);
						if ((notification != null))
						{
							_data.writeInt(1);
							notification.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_addNotification
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void updateNotification(android.os.IBinder key, android.statusbar.@internal.StatusBarNotification
					 notification)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder(key);
						if ((notification != null))
						{
							_data.writeInt(1);
							notification.writeToParcel(_data, 0);
						}
						else
						{
							_data.writeInt(0);
						}
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_updateNotification
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void removeNotification(android.os.IBinder key)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder(key);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_removeNotification
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void disable(int state)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(state);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_disable
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void animateExpand()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_animateExpand
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void animateCollapse()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_animateCollapse
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void setSystemUiVisibility(int vis)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(vis);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_setSystemUiVisibility
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void topAppWindowChanged(bool menuVisible)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(((menuVisible) ? (1) : (0)));
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_topAppWindowChanged
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition
					)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeStrongBinder(token);
						_data.writeInt(vis);
						_data.writeInt(backDisposition);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_setImeWindowStatus
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void setHardKeyboardStatus(bool available, bool enabled)
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						_data.writeInt(((available) ? (1) : (0)));
						_data.writeInt(((enabled) ? (1) : (0)));
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_setHardKeyboardStatus
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"com.android.internal.statusbar.IStatusBar")]
				public virtual void toggleRecentApps()
				{
					android.os.Parcel _data = android.os.Parcel.obtain();
					try
					{
						_data.writeInterfaceToken(DESCRIPTOR);
						mRemote.transact(android.statusbar.@internal.IStatusBarClass.Stub.TRANSACTION_toggleRecentApps
							, _data, null, android.os.IBinderClass.FLAG_ONEWAY);
					}
					finally
					{
						_data.recycle();
					}
				}
			}

			internal const int TRANSACTION_setIcon = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_removeIcon = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_addNotification = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_updateNotification = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_removeNotification = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_disable = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_animateExpand = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_animateCollapse = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_setSystemUiVisibility = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_topAppWindowChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_setImeWindowStatus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_setHardKeyboardStatus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_toggleRecentApps = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			public abstract void addNotification(android.os.IBinder arg1, android.statusbar.@internal.StatusBarNotification
				 arg2);

			public abstract void animateCollapse();

			public abstract void animateExpand();

			public abstract void disable(int arg1);

			public abstract void removeIcon(int arg1);

			public abstract void removeNotification(android.os.IBinder arg1);

			public abstract void setHardKeyboardStatus(bool arg1, bool arg2);

			public abstract void setIcon(int arg1, android.statusbar.@internal.StatusBarIcon 
				arg2);

			public abstract void setImeWindowStatus(android.os.IBinder arg1, int arg2, int arg3
				);

			public abstract void setSystemUiVisibility(int arg1);

			public abstract void toggleRecentApps();

			public abstract void topAppWindowChanged(bool arg1);

			public abstract void updateNotification(android.os.IBinder arg1, android.statusbar.@internal.StatusBarNotification
				 arg2);
		}
	}
}
