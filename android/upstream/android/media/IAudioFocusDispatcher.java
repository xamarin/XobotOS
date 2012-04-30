/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/media/java/android/media/IAudioFocusDispatcher.aidl
 */
package android.media;
/**
 * AIDL for the AudioService to signal audio focus listeners of focus updates.
 *
 * {@hide}
 */
public interface IAudioFocusDispatcher extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.media.IAudioFocusDispatcher
{
private static final java.lang.String DESCRIPTOR = "android.media.IAudioFocusDispatcher";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.media.IAudioFocusDispatcher interface,
 * generating a proxy if needed.
 */
public static android.media.IAudioFocusDispatcher asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.media.IAudioFocusDispatcher))) {
return ((android.media.IAudioFocusDispatcher)iin);
}
return new android.media.IAudioFocusDispatcher.Stub.Proxy(obj);
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
case TRANSACTION_dispatchAudioFocusChange:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
java.lang.String _arg1;
_arg1 = data.readString();
this.dispatchAudioFocusChange(_arg0, _arg1);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.media.IAudioFocusDispatcher
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
public void dispatchAudioFocusChange(int focusChange, java.lang.String clientId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(focusChange);
_data.writeString(clientId);
mRemote.transact(Stub.TRANSACTION_dispatchAudioFocusChange, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_dispatchAudioFocusChange = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
}
public void dispatchAudioFocusChange(int focusChange, java.lang.String clientId) throws android.os.RemoteException;
}
