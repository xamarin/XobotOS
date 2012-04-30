/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/service/wallpaper/IWallpaperService.aidl
 */
package android.service.wallpaper;
/**
 * @hide
 */
public interface IWallpaperService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.service.wallpaper.IWallpaperService
{
private static final java.lang.String DESCRIPTOR = "android.service.wallpaper.IWallpaperService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.service.wallpaper.IWallpaperService interface,
 * generating a proxy if needed.
 */
public static android.service.wallpaper.IWallpaperService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.service.wallpaper.IWallpaperService))) {
return ((android.service.wallpaper.IWallpaperService)iin);
}
return new android.service.wallpaper.IWallpaperService.Stub.Proxy(obj);
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
case TRANSACTION_attach:
{
data.enforceInterface(DESCRIPTOR);
android.service.wallpaper.IWallpaperConnection _arg0;
_arg0 = android.service.wallpaper.IWallpaperConnection.Stub.asInterface(data.readStrongBinder());
android.os.IBinder _arg1;
_arg1 = data.readStrongBinder();
int _arg2;
_arg2 = data.readInt();
boolean _arg3;
_arg3 = (0!=data.readInt());
int _arg4;
_arg4 = data.readInt();
int _arg5;
_arg5 = data.readInt();
this.attach(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.service.wallpaper.IWallpaperService
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
public void attach(android.service.wallpaper.IWallpaperConnection connection, android.os.IBinder windowToken, int windowType, boolean isPreview, int reqWidth, int reqHeight) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((connection!=null))?(connection.asBinder()):(null)));
_data.writeStrongBinder(windowToken);
_data.writeInt(windowType);
_data.writeInt(((isPreview)?(1):(0)));
_data.writeInt(reqWidth);
_data.writeInt(reqHeight);
mRemote.transact(Stub.TRANSACTION_attach, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_attach = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
}
public void attach(android.service.wallpaper.IWallpaperConnection connection, android.os.IBinder windowToken, int windowType, boolean isPreview, int reqWidth, int reqHeight) throws android.os.RemoteException;
}
