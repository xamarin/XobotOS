/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/app/admin/IDevicePolicyManager.aidl
 */
package android.app.admin;
/**
 * Internal IPC interface to the device policy service.
 * {@hide}
 */
public interface IDevicePolicyManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.app.admin.IDevicePolicyManager
{
private static final java.lang.String DESCRIPTOR = "android.app.admin.IDevicePolicyManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.app.admin.IDevicePolicyManager interface,
 * generating a proxy if needed.
 */
public static android.app.admin.IDevicePolicyManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.app.admin.IDevicePolicyManager))) {
return ((android.app.admin.IDevicePolicyManager)iin);
}
return new android.app.admin.IDevicePolicyManager.Stub.Proxy(obj);
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
case TRANSACTION_setPasswordQuality:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordQuality(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordQuality:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordQuality(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordMinimumLength:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordMinimumLength(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordMinimumLength:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordMinimumLength(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordMinimumUpperCase:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordMinimumUpperCase(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordMinimumUpperCase:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordMinimumUpperCase(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordMinimumLowerCase:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordMinimumLowerCase(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordMinimumLowerCase:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordMinimumLowerCase(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordMinimumLetters:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordMinimumLetters(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordMinimumLetters:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordMinimumLetters(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordMinimumNumeric:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordMinimumNumeric(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordMinimumNumeric:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordMinimumNumeric(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordMinimumSymbols:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordMinimumSymbols(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordMinimumSymbols:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordMinimumSymbols(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordMinimumNonLetter:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordMinimumNonLetter(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordMinimumNonLetter:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordMinimumNonLetter(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordHistoryLength:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setPasswordHistoryLength(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordHistoryLength:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getPasswordHistoryLength(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setPasswordExpirationTimeout:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _arg1;
_arg1 = data.readLong();
this.setPasswordExpirationTimeout(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPasswordExpirationTimeout:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _result = this.getPasswordExpirationTimeout(_arg0);
reply.writeNoException();
reply.writeLong(_result);
return true;
}
case TRANSACTION_getPasswordExpiration:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _result = this.getPasswordExpiration(_arg0);
reply.writeNoException();
reply.writeLong(_result);
return true;
}
case TRANSACTION_isActivePasswordSufficient:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isActivePasswordSufficient();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getCurrentFailedPasswordAttempts:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getCurrentFailedPasswordAttempts();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setMaximumFailedPasswordsForWipe:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setMaximumFailedPasswordsForWipe(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getMaximumFailedPasswordsForWipe:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getMaximumFailedPasswordsForWipe(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_resetPassword:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
boolean _result = this.resetPassword(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setMaximumTimeToLock:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _arg1;
_arg1 = data.readLong();
this.setMaximumTimeToLock(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getMaximumTimeToLock:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _result = this.getMaximumTimeToLock(_arg0);
reply.writeNoException();
reply.writeLong(_result);
return true;
}
case TRANSACTION_lockNow:
{
data.enforceInterface(DESCRIPTOR);
this.lockNow();
reply.writeNoException();
return true;
}
case TRANSACTION_wipeData:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.wipeData(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setGlobalProxy:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
java.lang.String _arg2;
_arg2 = data.readString();
android.content.ComponentName _result = this.setGlobalProxy(_arg0, _arg1, _arg2);
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
case TRANSACTION_getGlobalProxyAdmin:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _result = this.getGlobalProxyAdmin();
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
case TRANSACTION_setStorageEncryption:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
int _result = this.setStorageEncryption(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getStorageEncryption:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _result = this.getStorageEncryption(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getStorageEncryptionStatus:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getStorageEncryptionStatus();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setCameraDisabled:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setCameraDisabled(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getCameraDisabled:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _result = this.getCameraDisabled(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setActiveAdmin:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setActiveAdmin(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_isAdminActive:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _result = this.isAdminActive(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getActiveAdmins:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.content.ComponentName> _result = this.getActiveAdmins();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_packageHasActiveAdmins:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _result = this.packageHasActiveAdmins(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getRemoveWarning:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.os.RemoteCallback _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.RemoteCallback.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.getRemoveWarning(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeActiveAdmin:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.removeActiveAdmin(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_hasGrantedPolicy:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
boolean _result = this.hasGrantedPolicy(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setActivePasswordState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
int _arg4;
_arg4 = data.readInt();
int _arg5;
_arg5 = data.readInt();
int _arg6;
_arg6 = data.readInt();
int _arg7;
_arg7 = data.readInt();
this.setActivePasswordState(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7);
reply.writeNoException();
return true;
}
case TRANSACTION_reportFailedPasswordAttempt:
{
data.enforceInterface(DESCRIPTOR);
this.reportFailedPasswordAttempt();
reply.writeNoException();
return true;
}
case TRANSACTION_reportSuccessfulPasswordAttempt:
{
data.enforceInterface(DESCRIPTOR);
this.reportSuccessfulPasswordAttempt();
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.app.admin.IDevicePolicyManager
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
public void setPasswordQuality(android.content.ComponentName who, int quality) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(quality);
mRemote.transact(Stub.TRANSACTION_setPasswordQuality, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordQuality(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordQuality, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordMinimumLength(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordMinimumLength, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordMinimumLength(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordMinimumLength, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordMinimumUpperCase(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordMinimumUpperCase, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordMinimumUpperCase(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordMinimumUpperCase, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordMinimumLowerCase(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordMinimumLowerCase, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordMinimumLowerCase(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordMinimumLowerCase, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordMinimumLetters(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordMinimumLetters, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordMinimumLetters(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordMinimumLetters, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordMinimumNumeric(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordMinimumNumeric, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordMinimumNumeric(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordMinimumNumeric, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordMinimumSymbols(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordMinimumSymbols, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordMinimumSymbols(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordMinimumSymbols, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordMinimumNonLetter(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordMinimumNonLetter, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordMinimumNonLetter(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordMinimumNonLetter, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordHistoryLength(android.content.ComponentName who, int length) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(length);
mRemote.transact(Stub.TRANSACTION_setPasswordHistoryLength, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPasswordHistoryLength(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordHistoryLength, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setPasswordExpirationTimeout(android.content.ComponentName who, long expiration) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeLong(expiration);
mRemote.transact(Stub.TRANSACTION_setPasswordExpirationTimeout, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public long getPasswordExpirationTimeout(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
long _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordExpirationTimeout, _data, _reply, 0);
_reply.readException();
_result = _reply.readLong();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public long getPasswordExpiration(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
long _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getPasswordExpiration, _data, _reply, 0);
_reply.readException();
_result = _reply.readLong();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean isActivePasswordSufficient() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isActivePasswordSufficient, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getCurrentFailedPasswordAttempts() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getCurrentFailedPasswordAttempts, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setMaximumFailedPasswordsForWipe(android.content.ComponentName admin, int num) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((admin!=null)) {
_data.writeInt(1);
admin.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(num);
mRemote.transact(Stub.TRANSACTION_setMaximumFailedPasswordsForWipe, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getMaximumFailedPasswordsForWipe(android.content.ComponentName admin) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((admin!=null)) {
_data.writeInt(1);
admin.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getMaximumFailedPasswordsForWipe, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean resetPassword(java.lang.String password, int flags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(password);
_data.writeInt(flags);
mRemote.transact(Stub.TRANSACTION_resetPassword, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setMaximumTimeToLock(android.content.ComponentName who, long timeMs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeLong(timeMs);
mRemote.transact(Stub.TRANSACTION_setMaximumTimeToLock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public long getMaximumTimeToLock(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
long _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getMaximumTimeToLock, _data, _reply, 0);
_reply.readException();
_result = _reply.readLong();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void lockNow() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_lockNow, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void wipeData(int flags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(flags);
mRemote.transact(Stub.TRANSACTION_wipeData, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public android.content.ComponentName setGlobalProxy(android.content.ComponentName admin, java.lang.String proxySpec, java.lang.String exclusionList) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.ComponentName _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((admin!=null)) {
_data.writeInt(1);
admin.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(proxySpec);
_data.writeString(exclusionList);
mRemote.transact(Stub.TRANSACTION_setGlobalProxy, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.ComponentName.CREATOR.createFromParcel(_reply);
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
public android.content.ComponentName getGlobalProxyAdmin() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.ComponentName _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getGlobalProxyAdmin, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.ComponentName.CREATOR.createFromParcel(_reply);
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
public int setStorageEncryption(android.content.ComponentName who, boolean encrypt) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((encrypt)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setStorageEncryption, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean getStorageEncryption(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getStorageEncryption, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getStorageEncryptionStatus() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getStorageEncryptionStatus, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setCameraDisabled(android.content.ComponentName who, boolean disabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((disabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setCameraDisabled, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean getCameraDisabled(android.content.ComponentName who) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((who!=null)) {
_data.writeInt(1);
who.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getCameraDisabled, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setActiveAdmin(android.content.ComponentName policyReceiver, boolean refreshing) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((policyReceiver!=null)) {
_data.writeInt(1);
policyReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((refreshing)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setActiveAdmin, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean isAdminActive(android.content.ComponentName policyReceiver) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((policyReceiver!=null)) {
_data.writeInt(1);
policyReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_isAdminActive, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public java.util.List<android.content.ComponentName> getActiveAdmins() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.content.ComponentName> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getActiveAdmins, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.content.ComponentName.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean packageHasActiveAdmins(java.lang.String packageName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(packageName);
mRemote.transact(Stub.TRANSACTION_packageHasActiveAdmins, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void getRemoveWarning(android.content.ComponentName policyReceiver, android.os.RemoteCallback result) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((policyReceiver!=null)) {
_data.writeInt(1);
policyReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((result!=null)) {
_data.writeInt(1);
result.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getRemoveWarning, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removeActiveAdmin(android.content.ComponentName policyReceiver) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((policyReceiver!=null)) {
_data.writeInt(1);
policyReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_removeActiveAdmin, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean hasGrantedPolicy(android.content.ComponentName policyReceiver, int usesPolicy) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((policyReceiver!=null)) {
_data.writeInt(1);
policyReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(usesPolicy);
mRemote.transact(Stub.TRANSACTION_hasGrantedPolicy, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setActivePasswordState(int quality, int length, int letters, int uppercase, int lowercase, int numbers, int symbols, int nonletter) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(quality);
_data.writeInt(length);
_data.writeInt(letters);
_data.writeInt(uppercase);
_data.writeInt(lowercase);
_data.writeInt(numbers);
_data.writeInt(symbols);
_data.writeInt(nonletter);
mRemote.transact(Stub.TRANSACTION_setActivePasswordState, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void reportFailedPasswordAttempt() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_reportFailedPasswordAttempt, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void reportSuccessfulPasswordAttempt() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_reportSuccessfulPasswordAttempt, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_setPasswordQuality = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getPasswordQuality = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_setPasswordMinimumLength = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getPasswordMinimumLength = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_setPasswordMinimumUpperCase = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_getPasswordMinimumUpperCase = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setPasswordMinimumLowerCase = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_getPasswordMinimumLowerCase = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_setPasswordMinimumLetters = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_getPasswordMinimumLetters = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_setPasswordMinimumNumeric = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_getPasswordMinimumNumeric = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_setPasswordMinimumSymbols = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_getPasswordMinimumSymbols = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_setPasswordMinimumNonLetter = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_getPasswordMinimumNonLetter = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_setPasswordHistoryLength = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_getPasswordHistoryLength = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_setPasswordExpirationTimeout = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_getPasswordExpirationTimeout = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_getPasswordExpiration = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
static final int TRANSACTION_isActivePasswordSufficient = (android.os.IBinder.FIRST_CALL_TRANSACTION + 21);
static final int TRANSACTION_getCurrentFailedPasswordAttempts = (android.os.IBinder.FIRST_CALL_TRANSACTION + 22);
static final int TRANSACTION_setMaximumFailedPasswordsForWipe = (android.os.IBinder.FIRST_CALL_TRANSACTION + 23);
static final int TRANSACTION_getMaximumFailedPasswordsForWipe = (android.os.IBinder.FIRST_CALL_TRANSACTION + 24);
static final int TRANSACTION_resetPassword = (android.os.IBinder.FIRST_CALL_TRANSACTION + 25);
static final int TRANSACTION_setMaximumTimeToLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 26);
static final int TRANSACTION_getMaximumTimeToLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 27);
static final int TRANSACTION_lockNow = (android.os.IBinder.FIRST_CALL_TRANSACTION + 28);
static final int TRANSACTION_wipeData = (android.os.IBinder.FIRST_CALL_TRANSACTION + 29);
static final int TRANSACTION_setGlobalProxy = (android.os.IBinder.FIRST_CALL_TRANSACTION + 30);
static final int TRANSACTION_getGlobalProxyAdmin = (android.os.IBinder.FIRST_CALL_TRANSACTION + 31);
static final int TRANSACTION_setStorageEncryption = (android.os.IBinder.FIRST_CALL_TRANSACTION + 32);
static final int TRANSACTION_getStorageEncryption = (android.os.IBinder.FIRST_CALL_TRANSACTION + 33);
static final int TRANSACTION_getStorageEncryptionStatus = (android.os.IBinder.FIRST_CALL_TRANSACTION + 34);
static final int TRANSACTION_setCameraDisabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 35);
static final int TRANSACTION_getCameraDisabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 36);
static final int TRANSACTION_setActiveAdmin = (android.os.IBinder.FIRST_CALL_TRANSACTION + 37);
static final int TRANSACTION_isAdminActive = (android.os.IBinder.FIRST_CALL_TRANSACTION + 38);
static final int TRANSACTION_getActiveAdmins = (android.os.IBinder.FIRST_CALL_TRANSACTION + 39);
static final int TRANSACTION_packageHasActiveAdmins = (android.os.IBinder.FIRST_CALL_TRANSACTION + 40);
static final int TRANSACTION_getRemoveWarning = (android.os.IBinder.FIRST_CALL_TRANSACTION + 41);
static final int TRANSACTION_removeActiveAdmin = (android.os.IBinder.FIRST_CALL_TRANSACTION + 42);
static final int TRANSACTION_hasGrantedPolicy = (android.os.IBinder.FIRST_CALL_TRANSACTION + 43);
static final int TRANSACTION_setActivePasswordState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 44);
static final int TRANSACTION_reportFailedPasswordAttempt = (android.os.IBinder.FIRST_CALL_TRANSACTION + 45);
static final int TRANSACTION_reportSuccessfulPasswordAttempt = (android.os.IBinder.FIRST_CALL_TRANSACTION + 46);
}
public void setPasswordQuality(android.content.ComponentName who, int quality) throws android.os.RemoteException;
public int getPasswordQuality(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordMinimumLength(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordMinimumLength(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordMinimumUpperCase(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordMinimumUpperCase(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordMinimumLowerCase(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordMinimumLowerCase(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordMinimumLetters(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordMinimumLetters(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordMinimumNumeric(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordMinimumNumeric(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordMinimumSymbols(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordMinimumSymbols(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordMinimumNonLetter(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordMinimumNonLetter(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordHistoryLength(android.content.ComponentName who, int length) throws android.os.RemoteException;
public int getPasswordHistoryLength(android.content.ComponentName who) throws android.os.RemoteException;
public void setPasswordExpirationTimeout(android.content.ComponentName who, long expiration) throws android.os.RemoteException;
public long getPasswordExpirationTimeout(android.content.ComponentName who) throws android.os.RemoteException;
public long getPasswordExpiration(android.content.ComponentName who) throws android.os.RemoteException;
public boolean isActivePasswordSufficient() throws android.os.RemoteException;
public int getCurrentFailedPasswordAttempts() throws android.os.RemoteException;
public void setMaximumFailedPasswordsForWipe(android.content.ComponentName admin, int num) throws android.os.RemoteException;
public int getMaximumFailedPasswordsForWipe(android.content.ComponentName admin) throws android.os.RemoteException;
public boolean resetPassword(java.lang.String password, int flags) throws android.os.RemoteException;
public void setMaximumTimeToLock(android.content.ComponentName who, long timeMs) throws android.os.RemoteException;
public long getMaximumTimeToLock(android.content.ComponentName who) throws android.os.RemoteException;
public void lockNow() throws android.os.RemoteException;
public void wipeData(int flags) throws android.os.RemoteException;
public android.content.ComponentName setGlobalProxy(android.content.ComponentName admin, java.lang.String proxySpec, java.lang.String exclusionList) throws android.os.RemoteException;
public android.content.ComponentName getGlobalProxyAdmin() throws android.os.RemoteException;
public int setStorageEncryption(android.content.ComponentName who, boolean encrypt) throws android.os.RemoteException;
public boolean getStorageEncryption(android.content.ComponentName who) throws android.os.RemoteException;
public int getStorageEncryptionStatus() throws android.os.RemoteException;
public void setCameraDisabled(android.content.ComponentName who, boolean disabled) throws android.os.RemoteException;
public boolean getCameraDisabled(android.content.ComponentName who) throws android.os.RemoteException;
public void setActiveAdmin(android.content.ComponentName policyReceiver, boolean refreshing) throws android.os.RemoteException;
public boolean isAdminActive(android.content.ComponentName policyReceiver) throws android.os.RemoteException;
public java.util.List<android.content.ComponentName> getActiveAdmins() throws android.os.RemoteException;
public boolean packageHasActiveAdmins(java.lang.String packageName) throws android.os.RemoteException;
public void getRemoveWarning(android.content.ComponentName policyReceiver, android.os.RemoteCallback result) throws android.os.RemoteException;
public void removeActiveAdmin(android.content.ComponentName policyReceiver) throws android.os.RemoteException;
public boolean hasGrantedPolicy(android.content.ComponentName policyReceiver, int usesPolicy) throws android.os.RemoteException;
public void setActivePasswordState(int quality, int length, int letters, int uppercase, int lowercase, int numbers, int symbols, int nonletter) throws android.os.RemoteException;
public void reportFailedPasswordAttempt() throws android.os.RemoteException;
public void reportSuccessfulPasswordAttempt() throws android.os.RemoteException;
}
