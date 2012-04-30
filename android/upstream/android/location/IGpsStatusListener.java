/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/location/java/android/location/IGpsStatusListener.aidl
 */
package android.location;
/**
 * {@hide}
 */
public interface IGpsStatusListener extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.location.IGpsStatusListener
{
private static final java.lang.String DESCRIPTOR = "android.location.IGpsStatusListener";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.location.IGpsStatusListener interface,
 * generating a proxy if needed.
 */
public static android.location.IGpsStatusListener asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.location.IGpsStatusListener))) {
return ((android.location.IGpsStatusListener)iin);
}
return new android.location.IGpsStatusListener.Stub.Proxy(obj);
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
case TRANSACTION_onGpsStarted:
{
data.enforceInterface(DESCRIPTOR);
this.onGpsStarted();
return true;
}
case TRANSACTION_onGpsStopped:
{
data.enforceInterface(DESCRIPTOR);
this.onGpsStopped();
return true;
}
case TRANSACTION_onFirstFix:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.onFirstFix(_arg0);
return true;
}
case TRANSACTION_onSvStatusChanged:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int[] _arg1;
_arg1 = data.createIntArray();
float[] _arg2;
_arg2 = data.createFloatArray();
float[] _arg3;
_arg3 = data.createFloatArray();
float[] _arg4;
_arg4 = data.createFloatArray();
int _arg5;
_arg5 = data.readInt();
int _arg6;
_arg6 = data.readInt();
int _arg7;
_arg7 = data.readInt();
this.onSvStatusChanged(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7);
return true;
}
case TRANSACTION_onNmeaReceived:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
java.lang.String _arg1;
_arg1 = data.readString();
this.onNmeaReceived(_arg0, _arg1);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.location.IGpsStatusListener
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
public void onGpsStarted() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_onGpsStarted, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void onGpsStopped() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_onGpsStopped, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void onFirstFix(int ttff) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(ttff);
mRemote.transact(Stub.TRANSACTION_onFirstFix, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void onSvStatusChanged(int svCount, int[] prns, float[] snrs, float[] elevations, float[] azimuths, int ephemerisMask, int almanacMask, int usedInFixMask) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(svCount);
_data.writeIntArray(prns);
_data.writeFloatArray(snrs);
_data.writeFloatArray(elevations);
_data.writeFloatArray(azimuths);
_data.writeInt(ephemerisMask);
_data.writeInt(almanacMask);
_data.writeInt(usedInFixMask);
mRemote.transact(Stub.TRANSACTION_onSvStatusChanged, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void onNmeaReceived(long timestamp, java.lang.String nmea) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(timestamp);
_data.writeString(nmea);
mRemote.transact(Stub.TRANSACTION_onNmeaReceived, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_onGpsStarted = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_onGpsStopped = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_onFirstFix = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_onSvStatusChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_onNmeaReceived = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
}
public void onGpsStarted() throws android.os.RemoteException;
public void onGpsStopped() throws android.os.RemoteException;
public void onFirstFix(int ttff) throws android.os.RemoteException;
public void onSvStatusChanged(int svCount, int[] prns, float[] snrs, float[] elevations, float[] azimuths, int ephemerisMask, int almanacMask, int usedInFixMask) throws android.os.RemoteException;
public void onNmeaReceived(long timestamp, java.lang.String nmea) throws android.os.RemoteException;
}
