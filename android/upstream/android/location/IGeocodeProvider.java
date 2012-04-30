/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/location/java/android/location/IGeocodeProvider.aidl
 */
package android.location;
/**
 * An interface for location providers implementing the Geocoder services.
 *
 * {@hide}
 */
public interface IGeocodeProvider extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.location.IGeocodeProvider
{
private static final java.lang.String DESCRIPTOR = "android.location.IGeocodeProvider";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.location.IGeocodeProvider interface,
 * generating a proxy if needed.
 */
public static android.location.IGeocodeProvider asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.location.IGeocodeProvider))) {
return ((android.location.IGeocodeProvider)iin);
}
return new android.location.IGeocodeProvider.Stub.Proxy(obj);
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
case TRANSACTION_getFromLocation:
{
data.enforceInterface(DESCRIPTOR);
double _arg0;
_arg0 = data.readDouble();
double _arg1;
_arg1 = data.readDouble();
int _arg2;
_arg2 = data.readInt();
android.location.GeocoderParams _arg3;
if ((0!=data.readInt())) {
_arg3 = android.location.GeocoderParams.CREATOR.createFromParcel(data);
}
else {
_arg3 = null;
}
java.util.List<android.location.Address> _arg4;
_arg4 = new java.util.ArrayList<android.location.Address>();
java.lang.String _result = this.getFromLocation(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
reply.writeString(_result);
reply.writeTypedList(_arg4);
return true;
}
case TRANSACTION_getFromLocationName:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
double _arg1;
_arg1 = data.readDouble();
double _arg2;
_arg2 = data.readDouble();
double _arg3;
_arg3 = data.readDouble();
double _arg4;
_arg4 = data.readDouble();
int _arg5;
_arg5 = data.readInt();
android.location.GeocoderParams _arg6;
if ((0!=data.readInt())) {
_arg6 = android.location.GeocoderParams.CREATOR.createFromParcel(data);
}
else {
_arg6 = null;
}
java.util.List<android.location.Address> _arg7;
_arg7 = new java.util.ArrayList<android.location.Address>();
java.lang.String _result = this.getFromLocationName(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7);
reply.writeNoException();
reply.writeString(_result);
reply.writeTypedList(_arg7);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.location.IGeocodeProvider
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
public java.lang.String getFromLocation(double latitude, double longitude, int maxResults, android.location.GeocoderParams params, java.util.List<android.location.Address> addrs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeDouble(latitude);
_data.writeDouble(longitude);
_data.writeInt(maxResults);
if ((params!=null)) {
_data.writeInt(1);
params.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getFromLocation, _data, _reply, 0);
_reply.readException();
_result = _reply.readString();
_reply.readTypedList(addrs, android.location.Address.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public java.lang.String getFromLocationName(java.lang.String locationName, double lowerLeftLatitude, double lowerLeftLongitude, double upperRightLatitude, double upperRightLongitude, int maxResults, android.location.GeocoderParams params, java.util.List<android.location.Address> addrs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(locationName);
_data.writeDouble(lowerLeftLatitude);
_data.writeDouble(lowerLeftLongitude);
_data.writeDouble(upperRightLatitude);
_data.writeDouble(upperRightLongitude);
_data.writeInt(maxResults);
if ((params!=null)) {
_data.writeInt(1);
params.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getFromLocationName, _data, _reply, 0);
_reply.readException();
_result = _reply.readString();
_reply.readTypedList(addrs, android.location.Address.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_getFromLocation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getFromLocationName = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
}
public java.lang.String getFromLocation(double latitude, double longitude, int maxResults, android.location.GeocoderParams params, java.util.List<android.location.Address> addrs) throws android.os.RemoteException;
public java.lang.String getFromLocationName(java.lang.String locationName, double lowerLeftLatitude, double lowerLeftLongitude, double upperRightLatitude, double upperRightLongitude, int maxResults, android.location.GeocoderParams params, java.util.List<android.location.Address> addrs) throws android.os.RemoteException;
}
