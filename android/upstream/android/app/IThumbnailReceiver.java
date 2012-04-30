/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/app/IThumbnailReceiver.aidl
 */
package android.app;
/**
 * System private API for receiving updated thumbnails from a checkpoint.
 *
 * {@hide}
 */
public interface IThumbnailReceiver extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.app.IThumbnailReceiver
{
private static final java.lang.String DESCRIPTOR = "android.app.IThumbnailReceiver";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.app.IThumbnailReceiver interface,
 * generating a proxy if needed.
 */
public static android.app.IThumbnailReceiver asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.app.IThumbnailReceiver))) {
return ((android.app.IThumbnailReceiver)iin);
}
return new android.app.IThumbnailReceiver.Stub.Proxy(obj);
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
case TRANSACTION_newThumbnail:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.graphics.Bitmap _arg1;
if ((0!=data.readInt())) {
_arg1 = android.graphics.Bitmap.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
java.lang.CharSequence _arg2;
if ((0!=data.readInt())) {
_arg2 = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
this.newThumbnail(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_finished:
{
data.enforceInterface(DESCRIPTOR);
this.finished();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.app.IThumbnailReceiver
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
public void newThumbnail(int id, android.graphics.Bitmap thumbnail, java.lang.CharSequence description) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(id);
if ((thumbnail!=null)) {
_data.writeInt(1);
thumbnail.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((description!=null)) {
_data.writeInt(1);
android.text.TextUtils.writeToParcel(description, _data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_newThumbnail, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void finished() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_finished, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_newThumbnail = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_finished = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
}
public void newThumbnail(int id, android.graphics.Bitmap thumbnail, java.lang.CharSequence description) throws android.os.RemoteException;
public void finished() throws android.os.RemoteException;
}
