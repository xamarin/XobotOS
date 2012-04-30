/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/location/java/android/location/IGpsStatusProvider.aidl
 */
package android.location;
/**
 * An interface for location providers that provide GPS status information.
 *
 * {@hide}
 */
public interface IGpsStatusProvider extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.location.IGpsStatusProvider
{
private static final java.lang.String DESCRIPTOR = "android.location.IGpsStatusProvider";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.location.IGpsStatusProvider interface,
 * generating a proxy if needed.
 */
public static android.location.IGpsStatusProvider asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.location.IGpsStatusProvider))) {
return ((android.location.IGpsStatusProvider)iin);
}
return new android.location.IGpsStatusProvider.Stub.Proxy(obj);
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
case TRANSACTION_addGpsStatusListener:
{
data.enforceInterface(DESCRIPTOR);
android.location.IGpsStatusListener _arg0;
_arg0 = android.location.IGpsStatusListener.Stub.asInterface(data.readStrongBinder());
this.addGpsStatusListener(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_removeGpsStatusListener:
{
data.enforceInterface(DESCRIPTOR);
android.location.IGpsStatusListener _arg0;
_arg0 = android.location.IGpsStatusListener.Stub.asInterface(data.readStrongBinder());
this.removeGpsStatusListener(_arg0);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.location.IGpsStatusProvider
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
public void addGpsStatusListener(android.location.IGpsStatusListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_addGpsStatusListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removeGpsStatusListener(android.location.IGpsStatusListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_removeGpsStatusListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_addGpsStatusListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_removeGpsStatusListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
}
public void addGpsStatusListener(android.location.IGpsStatusListener listener) throws android.os.RemoteException;
public void removeGpsStatusListener(android.location.IGpsStatusListener listener) throws android.os.RemoteException;
}
