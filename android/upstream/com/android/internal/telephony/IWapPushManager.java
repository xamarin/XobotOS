/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/telephony/java/com/android/internal/telephony/IWapPushManager.aidl
 */
package com.android.internal.telephony;
public interface IWapPushManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.telephony.IWapPushManager
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.telephony.IWapPushManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.telephony.IWapPushManager interface,
 * generating a proxy if needed.
 */
public static com.android.internal.telephony.IWapPushManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.telephony.IWapPushManager))) {
return ((com.android.internal.telephony.IWapPushManager)iin);
}
return new com.android.internal.telephony.IWapPushManager.Stub.Proxy(obj);
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
case TRANSACTION_processMessage:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
android.content.Intent _arg2;
if ((0!=data.readInt())) {
_arg2 = android.content.Intent.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
int _result = this.processMessage(_arg0, _arg1, _arg2);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_addPackage:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
java.lang.String _arg2;
_arg2 = data.readString();
java.lang.String _arg3;
_arg3 = data.readString();
int _arg4;
_arg4 = data.readInt();
boolean _arg5;
_arg5 = (0!=data.readInt());
boolean _arg6;
_arg6 = (0!=data.readInt());
boolean _result = this.addPackage(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_updatePackage:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
java.lang.String _arg2;
_arg2 = data.readString();
java.lang.String _arg3;
_arg3 = data.readString();
int _arg4;
_arg4 = data.readInt();
boolean _arg5;
_arg5 = (0!=data.readInt());
boolean _arg6;
_arg6 = (0!=data.readInt());
boolean _result = this.updatePackage(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_deletePackage:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
java.lang.String _arg2;
_arg2 = data.readString();
java.lang.String _arg3;
_arg3 = data.readString();
boolean _result = this.deletePackage(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.telephony.IWapPushManager
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
     * Processes WAP push message and triggers the receiver application registered
     * in the application ID table.
     */
public int processMessage(java.lang.String app_id, java.lang.String content_type, android.content.Intent intent) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(app_id);
_data.writeString(content_type);
if ((intent!=null)) {
_data.writeInt(1);
intent.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_processMessage, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Add receiver application into the application ID table.
     * Returns true if inserting the information is successfull. Inserting the duplicated
     * record in the application ID table is not allowed. Use update/delete method.
     */
public boolean addPackage(java.lang.String x_app_id, java.lang.String content_type, java.lang.String package_name, java.lang.String class_name, int app_type, boolean need_signature, boolean further_processing) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(x_app_id);
_data.writeString(content_type);
_data.writeString(package_name);
_data.writeString(class_name);
_data.writeInt(app_type);
_data.writeInt(((need_signature)?(1):(0)));
_data.writeInt(((further_processing)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_addPackage, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Updates receiver application that is last added.
     * Returns true if updating the information is successfull.
     */
public boolean updatePackage(java.lang.String x_app_id, java.lang.String content_type, java.lang.String package_name, java.lang.String class_name, int app_type, boolean need_signature, boolean further_processing) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(x_app_id);
_data.writeString(content_type);
_data.writeString(package_name);
_data.writeString(class_name);
_data.writeInt(app_type);
_data.writeInt(((need_signature)?(1):(0)));
_data.writeInt(((further_processing)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_updatePackage, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Delites receiver application information.
     * Returns true if deleting is successfull.
     */
public boolean deletePackage(java.lang.String x_app_id, java.lang.String content_type, java.lang.String package_name, java.lang.String class_name) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(x_app_id);
_data.writeString(content_type);
_data.writeString(package_name);
_data.writeString(class_name);
mRemote.transact(Stub.TRANSACTION_deletePackage, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_processMessage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_addPackage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_updatePackage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_deletePackage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
}
/**
     * Processes WAP push message and triggers the receiver application registered
     * in the application ID table.
     */
public int processMessage(java.lang.String app_id, java.lang.String content_type, android.content.Intent intent) throws android.os.RemoteException;
/**
     * Add receiver application into the application ID table.
     * Returns true if inserting the information is successfull. Inserting the duplicated
     * record in the application ID table is not allowed. Use update/delete method.
     */
public boolean addPackage(java.lang.String x_app_id, java.lang.String content_type, java.lang.String package_name, java.lang.String class_name, int app_type, boolean need_signature, boolean further_processing) throws android.os.RemoteException;
/**
     * Updates receiver application that is last added.
     * Returns true if updating the information is successfull.
     */
public boolean updatePackage(java.lang.String x_app_id, java.lang.String content_type, java.lang.String package_name, java.lang.String class_name, int app_type, boolean need_signature, boolean further_processing) throws android.os.RemoteException;
/**
     * Delites receiver application information.
     * Returns true if deleting is successfull.
     */
public boolean deletePackage(java.lang.String x_app_id, java.lang.String content_type, java.lang.String package_name, java.lang.String class_name) throws android.os.RemoteException;
}
