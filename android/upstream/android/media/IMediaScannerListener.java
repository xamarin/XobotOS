/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/media/java/android/media/IMediaScannerListener.aidl
 */
package android.media;
/**
 * {@hide}
 */
public interface IMediaScannerListener extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.media.IMediaScannerListener
{
private static final java.lang.String DESCRIPTOR = "android.media.IMediaScannerListener";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.media.IMediaScannerListener interface,
 * generating a proxy if needed.
 */
public static android.media.IMediaScannerListener asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.media.IMediaScannerListener))) {
return ((android.media.IMediaScannerListener)iin);
}
return new android.media.IMediaScannerListener.Stub.Proxy(obj);
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
case TRANSACTION_scanCompleted:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.Uri _arg1;
if ((0!=data.readInt())) {
_arg1 = android.net.Uri.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.scanCompleted(_arg0, _arg1);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.media.IMediaScannerListener
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
/**
     * Called when a IMediaScannerService.scanFile() call has completed.
     * @param path the path to the file that has been scanned.
     * @param uri the Uri for the file if the scanning operation succeeded 
     * and the file was added to the media database, or null if scanning failed. 
     */
public void scanCompleted(java.lang.String path, android.net.Uri uri) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(path);
if ((uri!=null)) {
_data.writeInt(1);
uri.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_scanCompleted, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_scanCompleted = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
}
/**
     * Called when a IMediaScannerService.scanFile() call has completed.
     * @param path the path to the file that has been scanned.
     * @param uri the Uri for the file if the scanning operation succeeded 
     * and the file was added to the media database, or null if scanning failed. 
     */
public void scanCompleted(java.lang.String path, android.net.Uri uri) throws android.os.RemoteException;
}
