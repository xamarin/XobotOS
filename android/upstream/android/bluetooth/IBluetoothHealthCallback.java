/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/bluetooth/IBluetoothHealthCallback.aidl
 */
package android.bluetooth;
/**
 *@hide
 */
public interface IBluetoothHealthCallback extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.bluetooth.IBluetoothHealthCallback
{
private static final java.lang.String DESCRIPTOR = "android.bluetooth.IBluetoothHealthCallback";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.bluetooth.IBluetoothHealthCallback interface,
 * generating a proxy if needed.
 */
public static android.bluetooth.IBluetoothHealthCallback asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.bluetooth.IBluetoothHealthCallback))) {
return ((android.bluetooth.IBluetoothHealthCallback)iin);
}
return new android.bluetooth.IBluetoothHealthCallback.Stub.Proxy(obj);
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
case TRANSACTION_onHealthAppConfigurationStatusChange:
{
data.enforceInterface(DESCRIPTOR);
android.bluetooth.BluetoothHealthAppConfiguration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.bluetooth.BluetoothHealthAppConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.onHealthAppConfigurationStatusChange(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_onHealthChannelStateChange:
{
data.enforceInterface(DESCRIPTOR);
android.bluetooth.BluetoothHealthAppConfiguration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.bluetooth.BluetoothHealthAppConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.bluetooth.BluetoothDevice _arg1;
if ((0!=data.readInt())) {
_arg1 = android.bluetooth.BluetoothDevice.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
android.os.ParcelFileDescriptor _arg4;
if ((0!=data.readInt())) {
_arg4 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg4 = null;
}
int _arg5;
_arg5 = data.readInt();
this.onHealthChannelStateChange(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.bluetooth.IBluetoothHealthCallback
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
public void onHealthAppConfigurationStatusChange(android.bluetooth.BluetoothHealthAppConfiguration config, int status) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((config!=null)) {
_data.writeInt(1);
config.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(status);
mRemote.transact(Stub.TRANSACTION_onHealthAppConfigurationStatusChange, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void onHealthChannelStateChange(android.bluetooth.BluetoothHealthAppConfiguration config, android.bluetooth.BluetoothDevice device, int prevState, int newState, android.os.ParcelFileDescriptor fd, int id) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((config!=null)) {
_data.writeInt(1);
config.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((device!=null)) {
_data.writeInt(1);
device.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(prevState);
_data.writeInt(newState);
if ((fd!=null)) {
_data.writeInt(1);
fd.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(id);
mRemote.transact(Stub.TRANSACTION_onHealthChannelStateChange, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_onHealthAppConfigurationStatusChange = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_onHealthChannelStateChange = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
}
public void onHealthAppConfigurationStatusChange(android.bluetooth.BluetoothHealthAppConfiguration config, int status) throws android.os.RemoteException;
public void onHealthChannelStateChange(android.bluetooth.BluetoothHealthAppConfiguration config, android.bluetooth.BluetoothDevice device, int prevState, int newState, android.os.ParcelFileDescriptor fd, int id) throws android.os.RemoteException;
}
