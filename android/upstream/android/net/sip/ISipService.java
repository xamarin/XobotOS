/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/voip/java/android/net/sip/ISipService.aidl
 */
package android.net.sip;
/**
 * {@hide}
 */
public interface ISipService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.net.sip.ISipService
{
private static final java.lang.String DESCRIPTOR = "android.net.sip.ISipService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.net.sip.ISipService interface,
 * generating a proxy if needed.
 */
public static android.net.sip.ISipService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.net.sip.ISipService))) {
return ((android.net.sip.ISipService)iin);
}
return new android.net.sip.ISipService.Stub.Proxy(obj);
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
case TRANSACTION_open:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.SipProfile _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.sip.SipProfile.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.open(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_open3:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.SipProfile _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.sip.SipProfile.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.app.PendingIntent _arg1;
if ((0!=data.readInt())) {
_arg1 = android.app.PendingIntent.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
android.net.sip.ISipSessionListener _arg2;
_arg2 = android.net.sip.ISipSessionListener.Stub.asInterface(data.readStrongBinder());
this.open3(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_close:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.close(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_isOpened:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _result = this.isOpened(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_isRegistered:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _result = this.isRegistered(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setRegistrationListener:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.sip.ISipSessionListener _arg1;
_arg1 = android.net.sip.ISipSessionListener.Stub.asInterface(data.readStrongBinder());
this.setRegistrationListener(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_createSession:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.SipProfile _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.sip.SipProfile.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.net.sip.ISipSessionListener _arg1;
_arg1 = android.net.sip.ISipSessionListener.Stub.asInterface(data.readStrongBinder());
android.net.sip.ISipSession _result = this.createSession(_arg0, _arg1);
reply.writeNoException();
reply.writeStrongBinder((((_result!=null))?(_result.asBinder()):(null)));
return true;
}
case TRANSACTION_getPendingSession:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.sip.ISipSession _result = this.getPendingSession(_arg0);
reply.writeNoException();
reply.writeStrongBinder((((_result!=null))?(_result.asBinder()):(null)));
return true;
}
case TRANSACTION_getListOfProfiles:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.SipProfile[] _result = this.getListOfProfiles();
reply.writeNoException();
reply.writeTypedArray(_result, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.net.sip.ISipService
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
public void open(android.net.sip.SipProfile localProfile) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((localProfile!=null)) {
_data.writeInt(1);
localProfile.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_open, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void open3(android.net.sip.SipProfile localProfile, android.app.PendingIntent incomingCallPendingIntent, android.net.sip.ISipSessionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((localProfile!=null)) {
_data.writeInt(1);
localProfile.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((incomingCallPendingIntent!=null)) {
_data.writeInt(1);
incomingCallPendingIntent.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_open3, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void close(java.lang.String localProfileUri) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(localProfileUri);
mRemote.transact(Stub.TRANSACTION_close, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean isOpened(java.lang.String localProfileUri) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(localProfileUri);
mRemote.transact(Stub.TRANSACTION_isOpened, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean isRegistered(java.lang.String localProfileUri) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(localProfileUri);
mRemote.transact(Stub.TRANSACTION_isRegistered, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setRegistrationListener(java.lang.String localProfileUri, android.net.sip.ISipSessionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(localProfileUri);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_setRegistrationListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public android.net.sip.ISipSession createSession(android.net.sip.SipProfile localProfile, android.net.sip.ISipSessionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.sip.ISipSession _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((localProfile!=null)) {
_data.writeInt(1);
localProfile.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_createSession, _data, _reply, 0);
_reply.readException();
_result = android.net.sip.ISipSession.Stub.asInterface(_reply.readStrongBinder());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.net.sip.ISipSession getPendingSession(java.lang.String callId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.sip.ISipSession _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(callId);
mRemote.transact(Stub.TRANSACTION_getPendingSession, _data, _reply, 0);
_reply.readException();
_result = android.net.sip.ISipSession.Stub.asInterface(_reply.readStrongBinder());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.net.sip.SipProfile[] getListOfProfiles() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.sip.SipProfile[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getListOfProfiles, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArray(android.net.sip.SipProfile.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_open = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_open3 = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_close = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_isOpened = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_isRegistered = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_setRegistrationListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_createSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_getPendingSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_getListOfProfiles = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
}
public void open(android.net.sip.SipProfile localProfile) throws android.os.RemoteException;
public void open3(android.net.sip.SipProfile localProfile, android.app.PendingIntent incomingCallPendingIntent, android.net.sip.ISipSessionListener listener) throws android.os.RemoteException;
public void close(java.lang.String localProfileUri) throws android.os.RemoteException;
public boolean isOpened(java.lang.String localProfileUri) throws android.os.RemoteException;
public boolean isRegistered(java.lang.String localProfileUri) throws android.os.RemoteException;
public void setRegistrationListener(java.lang.String localProfileUri, android.net.sip.ISipSessionListener listener) throws android.os.RemoteException;
public android.net.sip.ISipSession createSession(android.net.sip.SipProfile localProfile, android.net.sip.ISipSessionListener listener) throws android.os.RemoteException;
public android.net.sip.ISipSession getPendingSession(java.lang.String callId) throws android.os.RemoteException;
public android.net.sip.SipProfile[] getListOfProfiles() throws android.os.RemoteException;
}
