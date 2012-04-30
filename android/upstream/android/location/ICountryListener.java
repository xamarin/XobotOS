/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/location/java/android/location/ICountryListener.aidl
 */
package android.location;
/**
 * {@hide}
 */
public interface ICountryListener extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.location.ICountryListener
{
private static final java.lang.String DESCRIPTOR = "android.location.ICountryListener";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.location.ICountryListener interface,
 * generating a proxy if needed.
 */
public static android.location.ICountryListener asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.location.ICountryListener))) {
return ((android.location.ICountryListener)iin);
}
return new android.location.ICountryListener.Stub.Proxy(obj);
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
case TRANSACTION_onCountryDetected:
{
data.enforceInterface(DESCRIPTOR);
android.location.Country _arg0;
if ((0!=data.readInt())) {
_arg0 = android.location.Country.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.onCountryDetected(_arg0);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.location.ICountryListener
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
public void onCountryDetected(android.location.Country country) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((country!=null)) {
_data.writeInt(1);
country.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_onCountryDetected, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_onCountryDetected = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
}
public void onCountryDetected(android.location.Country country) throws android.os.RemoteException;
}
