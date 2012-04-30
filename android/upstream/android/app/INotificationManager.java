/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/app/INotificationManager.aidl
 */
package android.app;
/** {@hide} */
public interface INotificationManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.app.INotificationManager
{
private static final java.lang.String DESCRIPTOR = "android.app.INotificationManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.app.INotificationManager interface,
 * generating a proxy if needed.
 */
public static android.app.INotificationManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.app.INotificationManager))) {
return ((android.app.INotificationManager)iin);
}
return new android.app.INotificationManager.Stub.Proxy(obj);
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
case TRANSACTION_enqueueNotification:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
android.app.Notification _arg2;
if ((0!=data.readInt())) {
_arg2 = android.app.Notification.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
int[] _arg3;
_arg3 = data.createIntArray();
this.enqueueNotification(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
reply.writeIntArray(_arg3);
return true;
}
case TRANSACTION_cancelNotification:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
this.cancelNotification(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_cancelAllNotifications:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.cancelAllNotifications(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_enqueueToast:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.app.ITransientNotification _arg1;
_arg1 = android.app.ITransientNotification.Stub.asInterface(data.readStrongBinder());
int _arg2;
_arg2 = data.readInt();
this.enqueueToast(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_cancelToast:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.app.ITransientNotification _arg1;
_arg1 = android.app.ITransientNotification.Stub.asInterface(data.readStrongBinder());
this.cancelToast(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_enqueueNotificationWithTag:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
android.app.Notification _arg3;
if ((0!=data.readInt())) {
_arg3 = android.app.Notification.CREATOR.createFromParcel(data);
}
else {
_arg3 = null;
}
int[] _arg4;
_arg4 = data.createIntArray();
this.enqueueNotificationWithTag(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
reply.writeIntArray(_arg4);
return true;
}
case TRANSACTION_enqueueNotificationWithTagPriority:
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
android.app.Notification _arg4;
if ((0!=data.readInt())) {
_arg4 = android.app.Notification.CREATOR.createFromParcel(data);
}
else {
_arg4 = null;
}
int[] _arg5;
_arg5 = data.createIntArray();
this.enqueueNotificationWithTagPriority(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
reply.writeNoException();
reply.writeIntArray(_arg5);
return true;
}
case TRANSACTION_cancelNotificationWithTag:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
this.cancelNotificationWithTag(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.app.INotificationManager
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
/** @deprecated use {@link #enqueueNotificationWithTag} instead */
public void enqueueNotification(java.lang.String pkg, int id, android.app.Notification notification, int[] idReceived) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeInt(id);
if ((notification!=null)) {
_data.writeInt(1);
notification.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeIntArray(idReceived);
mRemote.transact(Stub.TRANSACTION_enqueueNotification, _data, _reply, 0);
_reply.readException();
_reply.readIntArray(idReceived);
}
finally {
_reply.recycle();
_data.recycle();
}
}
/** @deprecated use {@link #cancelNotificationWithTag} instead */
public void cancelNotification(java.lang.String pkg, int id) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeInt(id);
mRemote.transact(Stub.TRANSACTION_cancelNotification, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void cancelAllNotifications(java.lang.String pkg) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
mRemote.transact(Stub.TRANSACTION_cancelAllNotifications, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void enqueueToast(java.lang.String pkg, android.app.ITransientNotification callback, int duration) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
_data.writeInt(duration);
mRemote.transact(Stub.TRANSACTION_enqueueToast, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void cancelToast(java.lang.String pkg, android.app.ITransientNotification callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_cancelToast, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void enqueueNotificationWithTag(java.lang.String pkg, java.lang.String tag, int id, android.app.Notification notification, int[] idReceived) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeString(tag);
_data.writeInt(id);
if ((notification!=null)) {
_data.writeInt(1);
notification.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeIntArray(idReceived);
mRemote.transact(Stub.TRANSACTION_enqueueNotificationWithTag, _data, _reply, 0);
_reply.readException();
_reply.readIntArray(idReceived);
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void enqueueNotificationWithTagPriority(java.lang.String pkg, java.lang.String tag, int id, int priority, android.app.Notification notification, int[] idReceived) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeString(tag);
_data.writeInt(id);
_data.writeInt(priority);
if ((notification!=null)) {
_data.writeInt(1);
notification.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeIntArray(idReceived);
mRemote.transact(Stub.TRANSACTION_enqueueNotificationWithTagPriority, _data, _reply, 0);
_reply.readException();
_reply.readIntArray(idReceived);
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void cancelNotificationWithTag(java.lang.String pkg, java.lang.String tag, int id) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeString(tag);
_data.writeInt(id);
mRemote.transact(Stub.TRANSACTION_cancelNotificationWithTag, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_enqueueNotification = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_cancelNotification = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_cancelAllNotifications = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_enqueueToast = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_cancelToast = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_enqueueNotificationWithTag = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_enqueueNotificationWithTagPriority = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_cancelNotificationWithTag = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
}
/** @deprecated use {@link #enqueueNotificationWithTag} instead */
public void enqueueNotification(java.lang.String pkg, int id, android.app.Notification notification, int[] idReceived) throws android.os.RemoteException;
/** @deprecated use {@link #cancelNotificationWithTag} instead */
public void cancelNotification(java.lang.String pkg, int id) throws android.os.RemoteException;
public void cancelAllNotifications(java.lang.String pkg) throws android.os.RemoteException;
public void enqueueToast(java.lang.String pkg, android.app.ITransientNotification callback, int duration) throws android.os.RemoteException;
public void cancelToast(java.lang.String pkg, android.app.ITransientNotification callback) throws android.os.RemoteException;
public void enqueueNotificationWithTag(java.lang.String pkg, java.lang.String tag, int id, android.app.Notification notification, int[] idReceived) throws android.os.RemoteException;
public void enqueueNotificationWithTagPriority(java.lang.String pkg, java.lang.String tag, int id, int priority, android.app.Notification notification, int[] idReceived) throws android.os.RemoteException;
public void cancelNotificationWithTag(java.lang.String pkg, java.lang.String tag, int id) throws android.os.RemoteException;
}
