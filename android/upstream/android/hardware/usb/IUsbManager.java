/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/hardware/usb/IUsbManager.aidl
 */
package android.hardware.usb;
/** @hide */
public interface IUsbManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.hardware.usb.IUsbManager
{
private static final java.lang.String DESCRIPTOR = "android.hardware.usb.IUsbManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.hardware.usb.IUsbManager interface,
 * generating a proxy if needed.
 */
public static android.hardware.usb.IUsbManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.hardware.usb.IUsbManager))) {
return ((android.hardware.usb.IUsbManager)iin);
}
return new android.hardware.usb.IUsbManager.Stub.Proxy(obj);
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
case TRANSACTION_getDeviceList:
{
data.enforceInterface(DESCRIPTOR);
android.os.Bundle _arg0;
_arg0 = new android.os.Bundle();
this.getDeviceList(_arg0);
reply.writeNoException();
if ((_arg0!=null)) {
reply.writeInt(1);
_arg0.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_openDevice:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.os.ParcelFileDescriptor _result = this.openDevice(_arg0);
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
case TRANSACTION_getCurrentAccessory:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbAccessory _result = this.getCurrentAccessory();
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
case TRANSACTION_openAccessory:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbAccessory _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbAccessory.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.os.ParcelFileDescriptor _result = this.openAccessory(_arg0);
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
case TRANSACTION_setDevicePackage:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbDevice _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbDevice.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
this.setDevicePackage(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setAccessoryPackage:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbAccessory _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbAccessory.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
this.setAccessoryPackage(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_hasDevicePermission:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbDevice _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbDevice.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _result = this.hasDevicePermission(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_hasAccessoryPermission:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbAccessory _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbAccessory.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _result = this.hasAccessoryPermission(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_requestDevicePermission:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbDevice _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbDevice.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
android.app.PendingIntent _arg2;
if ((0!=data.readInt())) {
_arg2 = android.app.PendingIntent.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
this.requestDevicePermission(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_requestAccessoryPermission:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbAccessory _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbAccessory.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
android.app.PendingIntent _arg2;
if ((0!=data.readInt())) {
_arg2 = android.app.PendingIntent.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
this.requestAccessoryPermission(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_grantDevicePermission:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbDevice _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbDevice.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.grantDevicePermission(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_grantAccessoryPermission:
{
data.enforceInterface(DESCRIPTOR);
android.hardware.usb.UsbAccessory _arg0;
if ((0!=data.readInt())) {
_arg0 = android.hardware.usb.UsbAccessory.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.grantAccessoryPermission(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_hasDefaults:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _result = this.hasDefaults(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_clearDefaults:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.clearDefaults(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setCurrentFunction:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setCurrentFunction(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setMassStorageBackingFile:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.setMassStorageBackingFile(_arg0);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.hardware.usb.IUsbManager
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
/* Returns a list of all currently attached USB devices */
public void getDeviceList(android.os.Bundle devices) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getDeviceList, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
devices.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Returns a file descriptor for communicating with the USB device.
     * The native fd can be passed to usb_device_new() in libusbhost.
     */
public android.os.ParcelFileDescriptor openDevice(java.lang.String deviceName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.ParcelFileDescriptor _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(deviceName);
mRemote.transact(Stub.TRANSACTION_openDevice, _data, _reply, 0);
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
/* Returns the currently attached USB accessory */
public android.hardware.usb.UsbAccessory getCurrentAccessory() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.hardware.usb.UsbAccessory _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getCurrentAccessory, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.hardware.usb.UsbAccessory.CREATOR.createFromParcel(_reply);
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
/* Returns a file descriptor for communicating with the USB accessory.
     * This file descriptor can be used with standard Java file operations.
     */
public android.os.ParcelFileDescriptor openAccessory(android.hardware.usb.UsbAccessory accessory) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.ParcelFileDescriptor _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((accessory!=null)) {
_data.writeInt(1);
accessory.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_openAccessory, _data, _reply, 0);
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
/* Sets the default package for a USB device
     * (or clears it if the package name is null)
     */
public void setDevicePackage(android.hardware.usb.UsbDevice device, java.lang.String packageName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((device!=null)) {
_data.writeInt(1);
device.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(packageName);
mRemote.transact(Stub.TRANSACTION_setDevicePackage, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Sets the default package for a USB accessory
     * (or clears it if the package name is null)
     */
public void setAccessoryPackage(android.hardware.usb.UsbAccessory accessory, java.lang.String packageName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((accessory!=null)) {
_data.writeInt(1);
accessory.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(packageName);
mRemote.transact(Stub.TRANSACTION_setAccessoryPackage, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Returns true if the caller has permission to access the device. */
public boolean hasDevicePermission(android.hardware.usb.UsbDevice device) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((device!=null)) {
_data.writeInt(1);
device.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_hasDevicePermission, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/* Returns true if the caller has permission to access the accessory. */
public boolean hasAccessoryPermission(android.hardware.usb.UsbAccessory accessory) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((accessory!=null)) {
_data.writeInt(1);
accessory.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_hasAccessoryPermission, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/* Requests permission for the given package to access the device.
     * Will display a system dialog to query the user if permission
     * had not already been given.
     */
public void requestDevicePermission(android.hardware.usb.UsbDevice device, java.lang.String packageName, android.app.PendingIntent pi) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((device!=null)) {
_data.writeInt(1);
device.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(packageName);
if ((pi!=null)) {
_data.writeInt(1);
pi.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_requestDevicePermission, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Requests permission for the given package to access the accessory.
     * Will display a system dialog to query the user if permission
     * had not already been given. Result is returned via pi.
     */
public void requestAccessoryPermission(android.hardware.usb.UsbAccessory accessory, java.lang.String packageName, android.app.PendingIntent pi) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((accessory!=null)) {
_data.writeInt(1);
accessory.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(packageName);
if ((pi!=null)) {
_data.writeInt(1);
pi.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_requestAccessoryPermission, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Grants permission for the given UID to access the device */
public void grantDevicePermission(android.hardware.usb.UsbDevice device, int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((device!=null)) {
_data.writeInt(1);
device.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_grantDevicePermission, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Grants permission for the given UID to access the accessory */
public void grantAccessoryPermission(android.hardware.usb.UsbAccessory accessory, int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((accessory!=null)) {
_data.writeInt(1);
accessory.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_grantAccessoryPermission, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Returns true if the USB manager has default preferences or permissions for the package */
public boolean hasDefaults(java.lang.String packageName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(packageName);
mRemote.transact(Stub.TRANSACTION_hasDefaults, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/* Clears default preferences and permissions for the package */
public void clearDefaults(java.lang.String packageName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(packageName);
mRemote.transact(Stub.TRANSACTION_clearDefaults, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Sets the current USB function. */
public void setCurrentFunction(java.lang.String function, boolean makeDefault) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(function);
_data.writeInt(((makeDefault)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setCurrentFunction, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* Sets the file path for USB mass storage backing file. */
public void setMassStorageBackingFile(java.lang.String path) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(path);
mRemote.transact(Stub.TRANSACTION_setMassStorageBackingFile, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_getDeviceList = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_openDevice = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getCurrentAccessory = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_openAccessory = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_setDevicePackage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_setAccessoryPackage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_hasDevicePermission = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_hasAccessoryPermission = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_requestDevicePermission = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_requestAccessoryPermission = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_grantDevicePermission = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_grantAccessoryPermission = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_hasDefaults = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_clearDefaults = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_setCurrentFunction = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_setMassStorageBackingFile = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
}
/* Returns a list of all currently attached USB devices */
public void getDeviceList(android.os.Bundle devices) throws android.os.RemoteException;
/* Returns a file descriptor for communicating with the USB device.
     * The native fd can be passed to usb_device_new() in libusbhost.
     */
public android.os.ParcelFileDescriptor openDevice(java.lang.String deviceName) throws android.os.RemoteException;
/* Returns the currently attached USB accessory */
public android.hardware.usb.UsbAccessory getCurrentAccessory() throws android.os.RemoteException;
/* Returns a file descriptor for communicating with the USB accessory.
     * This file descriptor can be used with standard Java file operations.
     */
public android.os.ParcelFileDescriptor openAccessory(android.hardware.usb.UsbAccessory accessory) throws android.os.RemoteException;
/* Sets the default package for a USB device
     * (or clears it if the package name is null)
     */
public void setDevicePackage(android.hardware.usb.UsbDevice device, java.lang.String packageName) throws android.os.RemoteException;
/* Sets the default package for a USB accessory
     * (or clears it if the package name is null)
     */
public void setAccessoryPackage(android.hardware.usb.UsbAccessory accessory, java.lang.String packageName) throws android.os.RemoteException;
/* Returns true if the caller has permission to access the device. */
public boolean hasDevicePermission(android.hardware.usb.UsbDevice device) throws android.os.RemoteException;
/* Returns true if the caller has permission to access the accessory. */
public boolean hasAccessoryPermission(android.hardware.usb.UsbAccessory accessory) throws android.os.RemoteException;
/* Requests permission for the given package to access the device.
     * Will display a system dialog to query the user if permission
     * had not already been given.
     */
public void requestDevicePermission(android.hardware.usb.UsbDevice device, java.lang.String packageName, android.app.PendingIntent pi) throws android.os.RemoteException;
/* Requests permission for the given package to access the accessory.
     * Will display a system dialog to query the user if permission
     * had not already been given. Result is returned via pi.
     */
public void requestAccessoryPermission(android.hardware.usb.UsbAccessory accessory, java.lang.String packageName, android.app.PendingIntent pi) throws android.os.RemoteException;
/* Grants permission for the given UID to access the device */
public void grantDevicePermission(android.hardware.usb.UsbDevice device, int uid) throws android.os.RemoteException;
/* Grants permission for the given UID to access the accessory */
public void grantAccessoryPermission(android.hardware.usb.UsbAccessory accessory, int uid) throws android.os.RemoteException;
/* Returns true if the USB manager has default preferences or permissions for the package */
public boolean hasDefaults(java.lang.String packageName) throws android.os.RemoteException;
/* Clears default preferences and permissions for the package */
public void clearDefaults(java.lang.String packageName) throws android.os.RemoteException;
/* Sets the current USB function. */
public void setCurrentFunction(java.lang.String function, boolean makeDefault) throws android.os.RemoteException;
/* Sets the file path for USB mass storage backing file. */
public void setMassStorageBackingFile(java.lang.String path) throws android.os.RemoteException;
}
