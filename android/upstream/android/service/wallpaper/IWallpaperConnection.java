/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/service/wallpaper/IWallpaperConnection.aidl
 */
package android.service.wallpaper;
/**
 * @hide
 */
public interface IWallpaperConnection extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.service.wallpaper.IWallpaperConnection
{
private static final java.lang.String DESCRIPTOR = "android.service.wallpaper.IWallpaperConnection";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.service.wallpaper.IWallpaperConnection interface,
 * generating a proxy if needed.
 */
public static android.service.wallpaper.IWallpaperConnection asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.service.wallpaper.IWallpaperConnection))) {
return ((android.service.wallpaper.IWallpaperConnection)iin);
}
return new android.service.wallpaper.IWallpaperConnection.Stub.Proxy(obj);
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
case TRANSACTION_attachEngine:
{
data.enforceInterface(DESCRIPTOR);
android.service.wallpaper.IWallpaperEngine _arg0;
_arg0 = android.service.wallpaper.IWallpaperEngine.Stub.asInterface(data.readStrongBinder());
this.attachEngine(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setWallpaper:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.os.ParcelFileDescriptor _result = this.setWallpaper(_arg0);
reply.writeNoException();
if ((_result!=null)) {
reply.writeInt(1);
_result.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.service.wallpaper.IWallpaperConnection
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
public void attachEngine(android.service.wallpaper.IWallpaperEngine engine) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((engine!=null))?(engine.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_attachEngine, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public android.os.ParcelFileDescriptor setWallpaper(java.lang.String name) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.ParcelFileDescriptor _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(name);
mRemote.transact(Stub.TRANSACTION_setWallpaper, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(_reply);
}
else {
_result = null;
}
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_attachEngine = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_setWallpaper = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
}
public void attachEngine(android.service.wallpaper.IWallpaperEngine engine) throws android.os.RemoteException;
public android.os.ParcelFileDescriptor setWallpaper(java.lang.String name) throws android.os.RemoteException;
}
