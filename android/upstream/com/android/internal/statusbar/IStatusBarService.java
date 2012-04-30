/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/statusbar/IStatusBarService.aidl
 */
package com.android.internal.statusbar;
/** @hide */
public interface IStatusBarService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.statusbar.IStatusBarService
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.statusbar.IStatusBarService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.statusbar.IStatusBarService interface,
 * generating a proxy if needed.
 */
public static com.android.internal.statusbar.IStatusBarService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.statusbar.IStatusBarService))) {
return ((com.android.internal.statusbar.IStatusBarService)iin);
}
return new com.android.internal.statusbar.IStatusBarService.Stub.Proxy(obj);
}
public android.os.IBinder asBinder()
{
return this;
}
@Override public boolean onTransact(int code, android.os.Parcel data, android.os.Parcel reply, int flags) throws android.os.RemoteException
{
switch (code)
{
case INTERFACE_TRANSACTION:
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
java.lang.String _arg2;
_arg2 = data.readString();
this.disable(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_setIcon:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
java.lang.String _arg4;
_arg4 = data.readString();
this.setIcon(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
return true;
}
case TRANSACTION_setIconVisibility:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setIconVisibility(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeIcon:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.removeIcon(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_topAppWindowChanged:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
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
com.android.internal.statusbar.IStatusBar _arg0;
_arg0 = com.android.internal.statusbar.IStatusBar.Stub.asInterface(data.readStrongBinder());
com.android.internal.statusbar.StatusBarIconList _arg1;
_arg1 = new com.android.internal.statusbar.StatusBarIconList();
java.util.List<android.os.IBinder> _arg2;
_arg2 = new java.util.ArrayList<android.os.IBinder>();
java.util.List<com.android.internal.statusbar.StatusBarNotification> _arg3;
_arg3 = new java.util.ArrayList<com.android.internal.statusbar.StatusBarNotification>();
int[] _arg4;
int _arg4_length = data.readInt();
if ((_arg4_length<0)) {
_arg4 = null;
}
else {
_arg4 = new int[_arg4_length];
}
java.util.List<android.os.IBinder> _arg5;
_arg5 = new java.util.ArrayList<android.os.IBinder>();
this.registerStatusBar(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
reply.writeNoException();
if ((_arg1!=null)) {
reply.writeInt(1);
_arg1.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
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
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
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
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
int _arg4;
_arg4 = data.readInt();
java.lang.String _arg5;
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
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
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
boolean _arg0;
_arg0 = (0!=data.readInt());
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
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.statusbar.IStatusBarService
{
private android.os.IBinder mRemote;
Proxy(android.os.IBinder remote)
{
mRemote = remote;
}
public android.os.IBinder asBinder()
{
return mRemote;
}
public java.lang.String getInterfaceDescriptor()
{
return DESCRIPTOR;
}
public void expand() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_expand, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void collapse() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_collapse, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void disable(int what, android.os.IBinder token, java.lang.String pkg) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(what);
_data.writeStrongBinder(token);
_data.writeString(pkg);
mRemote.transact(Stub.TRANSACTION_disable, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setIcon(java.lang.String slot, java.lang.String iconPackage, int iconId, int iconLevel, java.lang.String contentDescription) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(slot);
_data.writeString(iconPackage);
_data.writeInt(iconId);
_data.writeInt(iconLevel);
_data.writeString(contentDescription);
mRemote.transact(Stub.TRANSACTION_setIcon, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setIconVisibility(java.lang.String slot, boolean visible) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(slot);
_data.writeInt(((visible)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setIconVisibility, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removeIcon(java.lang.String slot) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(slot);
mRemote.transact(Stub.TRANSACTION_removeIcon, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void topAppWindowChanged(boolean menuVisible) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((menuVisible)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_topAppWindowChanged, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(vis);
_data.writeInt(backDisposition);
mRemote.transact(Stub.TRANSACTION_setImeWindowStatus, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// ---- Methods below are for use by the status bar policy services ----
// You need the STATUS_BAR_SERVICE permission

public void registerStatusBar(com.android.internal.statusbar.IStatusBar callbacks, com.android.internal.statusbar.StatusBarIconList iconList, java.util.List<android.os.IBinder> notificationKeys, java.util.List<com.android.internal.statusbar.StatusBarNotification> notifications, int[] switches, java.util.List<android.os.IBinder> binders) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((callbacks!=null))?(callbacks.asBinder()):(null)));
if ((switches==null)) {
_data.writeInt(-1);
}
else {
_data.writeInt(switches.length);
}
mRemote.transact(Stub.TRANSACTION_registerStatusBar, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
iconList.readFromParcel(_reply);
}
_reply.readBinderList(notificationKeys);
_reply.readTypedList(notifications, com.android.internal.statusbar.StatusBarNotification.CREATOR);
_reply.readIntArray(switches);
_reply.readBinderList(binders);
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void onPanelRevealed() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_onPanelRevealed, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void onNotificationClick(java.lang.String pkg, java.lang.String tag, int id) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeString(tag);
_data.writeInt(id);
mRemote.transact(Stub.TRANSACTION_onNotificationClick, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void onNotificationError(java.lang.String pkg, java.lang.String tag, int id, int uid, int initialPid, java.lang.String message) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeString(tag);
_data.writeInt(id);
_data.writeInt(uid);
_data.writeInt(initialPid);
_data.writeString(message);
mRemote.transact(Stub.TRANSACTION_onNotificationError, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void onClearAllNotifications() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_onClearAllNotifications, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void onNotificationClear(java.lang.String pkg, java.lang.String tag, int id) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeString(tag);
_data.writeInt(id);
mRemote.transact(Stub.TRANSACTION_onNotificationClear, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setSystemUiVisibility(int vis) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(vis);
mRemote.transact(Stub.TRANSACTION_setSystemUiVisibility, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setHardKeyboardEnabled(boolean enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((enabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setHardKeyboardEnabled, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void toggleRecentApps() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_toggleRecentApps, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_expand = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_collapse = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_disable = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_setIcon = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_setIconVisibility = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_removeIcon = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_topAppWindowChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_setImeWindowStatus = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_registerStatusBar = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_onPanelRevealed = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_onNotificationClick = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_onNotificationError = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_onClearAllNotifications = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_onNotificationClear = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_setSystemUiVisibility = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_setHardKeyboardEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_toggleRecentApps = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
}
public void expand() throws android.os.RemoteException;
public void collapse() throws android.os.RemoteException;
public void disable(int what, android.os.IBinder token, java.lang.String pkg) throws android.os.RemoteException;
public void setIcon(java.lang.String slot, java.lang.String iconPackage, int iconId, int iconLevel, java.lang.String contentDescription) throws android.os.RemoteException;
public void setIconVisibility(java.lang.String slot, boolean visible) throws android.os.RemoteException;
public void removeIcon(java.lang.String slot) throws android.os.RemoteException;
public void topAppWindowChanged(boolean menuVisible) throws android.os.RemoteException;
public void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition) throws android.os.RemoteException;
// ---- Methods below are for use by the status bar policy services ----
// You need the STATUS_BAR_SERVICE permission

public void registerStatusBar(com.android.internal.statusbar.IStatusBar callbacks, com.android.internal.statusbar.StatusBarIconList iconList, java.util.List<android.os.IBinder> notificationKeys, java.util.List<com.android.internal.statusbar.StatusBarNotification> notifications, int[] switches, java.util.List<android.os.IBinder> binders) throws android.os.RemoteException;
public void onPanelRevealed() throws android.os.RemoteException;
public void onNotificationClick(java.lang.String pkg, java.lang.String tag, int id) throws android.os.RemoteException;
public void onNotificationError(java.lang.String pkg, java.lang.String tag, int id, int uid, int initialPid, java.lang.String message) throws android.os.RemoteException;
public void onClearAllNotifications() throws android.os.RemoteException;
public void onNotificationClear(java.lang.String pkg, java.lang.String tag, int id) throws android.os.RemoteException;
public void setSystemUiVisibility(int vis) throws android.os.RemoteException;
public void setHardKeyboardEnabled(boolean enabled) throws android.os.RemoteException;
public void toggleRecentApps() throws android.os.RemoteException;
}
