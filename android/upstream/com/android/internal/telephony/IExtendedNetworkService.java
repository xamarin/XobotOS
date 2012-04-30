/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/telephony/java/com/android/internal/telephony/IExtendedNetworkService.aidl
 */
package com.android.internal.telephony;
/**
 * Interface used to interact with extended MMI/USSD network service.
 */
public interface IExtendedNetworkService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.telephony.IExtendedNetworkService
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.telephony.IExtendedNetworkService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.telephony.IExtendedNetworkService interface,
 * generating a proxy if needed.
 */
public static com.android.internal.telephony.IExtendedNetworkService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.telephony.IExtendedNetworkService))) {
return ((com.android.internal.telephony.IExtendedNetworkService)iin);
}
return new com.android.internal.telephony.IExtendedNetworkService.Stub.Proxy(obj);
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
case TRANSACTION_setMmiString:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.setMmiString(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getMmiRunningText:
{
data.enforceInterface(DESCRIPTOR);
java.lang.CharSequence _result = this.getMmiRunningText();
reply.writeNoException();
if ((_result!=null)) {
reply.writeInt(1);
android.text.TextUtils.writeToParcel(_result, reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_getUserMessage:
{
data.enforceInterface(DESCRIPTOR);
java.lang.CharSequence _arg0;
if ((0!=data.readInt())) {
_arg0 = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.CharSequence _result = this.getUserMessage(_arg0);
reply.writeNoException();
if ((_result!=null)) {
reply.writeInt(1);
android.text.TextUtils.writeToParcel(_result, reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_clearMmiString:
{
data.enforceInterface(DESCRIPTOR);
this.clearMmiString();
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.telephony.IExtendedNetworkService
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
     * Set a MMI/USSD command to ExtendedNetworkService for further process.
     * This should be called when a MMI command is placed from panel.
     * @param number the dialed MMI/USSD number.
     */
public void setMmiString(java.lang.String number) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(number);
mRemote.transact(Stub.TRANSACTION_setMmiString, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * return the specific string which is used to prompt MMI/USSD is running
     */
public java.lang.CharSequence getMmiRunningText() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.CharSequence _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getMmiRunningText, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(_reply);
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
/**
     * Get specific message which should be displayed on pop-up dialog.
     * @param text original MMI/USSD message response from framework
     * @return specific user message correspond to text. null stands for no pop-up dialog need to show.
     */
public java.lang.CharSequence getUserMessage(java.lang.CharSequence text) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.CharSequence _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((text!=null)) {
_data.writeInt(1);
android.text.TextUtils.writeToParcel(text, _data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getUserMessage, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(_reply);
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
/**
     * Clear pre-set MMI/USSD command.
     * This should be called when user cancel a pre-dialed MMI command.
     */
public void clearMmiString() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_clearMmiString, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_setMmiString = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getMmiRunningText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getUserMessage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_clearMmiString = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
}
/**
     * Set a MMI/USSD command to ExtendedNetworkService for further process.
     * This should be called when a MMI command is placed from panel.
     * @param number the dialed MMI/USSD number.
     */
public void setMmiString(java.lang.String number) throws android.os.RemoteException;
/**
     * return the specific string which is used to prompt MMI/USSD is running
     */
public java.lang.CharSequence getMmiRunningText() throws android.os.RemoteException;
/**
     * Get specific message which should be displayed on pop-up dialog.
     * @param text original MMI/USSD message response from framework
     * @return specific user message correspond to text. null stands for no pop-up dialog need to show.
     */
public java.lang.CharSequence getUserMessage(java.lang.CharSequence text) throws android.os.RemoteException;
/**
     * Clear pre-set MMI/USSD command.
     * This should be called when user cancel a pre-dialed MMI command.
     */
public void clearMmiString() throws android.os.RemoteException;
}
