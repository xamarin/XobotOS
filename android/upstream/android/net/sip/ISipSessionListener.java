/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/voip/java/android/net/sip/ISipSessionListener.aidl
 */
package android.net.sip;
/**
 * Listener class to listen to SIP session events.
 * @hide
 */
public interface ISipSessionListener extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.net.sip.ISipSessionListener
{
private static final java.lang.String DESCRIPTOR = "android.net.sip.ISipSessionListener";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.net.sip.ISipSessionListener interface,
 * generating a proxy if needed.
 */
public static android.net.sip.ISipSessionListener asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.net.sip.ISipSessionListener))) {
return ((android.net.sip.ISipSessionListener)iin);
}
return new android.net.sip.ISipSessionListener.Stub.Proxy(obj);
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
case TRANSACTION_onCalling:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
this.onCalling(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_onRinging:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
android.net.sip.SipProfile _arg1;
if ((0!=data.readInt())) {
_arg1 = android.net.sip.SipProfile.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
java.lang.String _arg2;
_arg2 = data.readString();
this.onRinging(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_onRingingBack:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
this.onRingingBack(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_onCallEstablished:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
java.lang.String _arg1;
_arg1 = data.readString();
this.onCallEstablished(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_onCallEnded:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
this.onCallEnded(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_onCallBusy:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
this.onCallBusy(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_onCallTransferring:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
java.lang.String _arg1;
_arg1 = data.readString();
this.onCallTransferring(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_onError:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
this.onError(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_onCallChangeFailed:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
this.onCallChangeFailed(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_onRegistering:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
this.onRegistering(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_onRegistrationDone:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
this.onRegistrationDone(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_onRegistrationFailed:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
this.onRegistrationFailed(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_onRegistrationTimeout:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSession _arg0;
_arg0 = android.net.sip.ISipSession.Stub.asInterface(data.readStrongBinder());
this.onRegistrationTimeout(_arg0);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.net.sip.ISipSessionListener
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
     * Called when an INVITE request is sent to initiate a new call.
     *
     * @param session the session object that carries out the transaction
     */
public void onCalling(android.net.sip.ISipSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_onCalling, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when an INVITE request is received.
     *
     * @param session the session object that carries out the transaction
     * @param caller the SIP profile of the caller
     * @param sessionDescription the caller's session description
     */
public void onRinging(android.net.sip.ISipSession session, android.net.sip.SipProfile caller, java.lang.String sessionDescription) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
if ((caller!=null)) {
_data.writeInt(1);
caller.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(sessionDescription);
mRemote.transact(Stub.TRANSACTION_onRinging, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when a RINGING response is received for the INVITE request sent
     *
     * @param session the session object that carries out the transaction
     */
public void onRingingBack(android.net.sip.ISipSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_onRingingBack, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when the session is established.
     *
     * @param session the session object that is associated with the dialog
     * @param sessionDescription the peer's session description
     */
public void onCallEstablished(android.net.sip.ISipSession session, java.lang.String sessionDescription) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
_data.writeString(sessionDescription);
mRemote.transact(Stub.TRANSACTION_onCallEstablished, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when the session is terminated.
     *
     * @param session the session object that is associated with the dialog
     */
public void onCallEnded(android.net.sip.ISipSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_onCallEnded, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when the peer is busy during session initialization.
     *
     * @param session the session object that carries out the transaction
     */
public void onCallBusy(android.net.sip.ISipSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_onCallBusy, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when the call is being transferred to a new one.
     *
     * @param newSession the new session that the call will be transferred to
     * @param sessionDescription the new peer's session description
     */
public void onCallTransferring(android.net.sip.ISipSession newSession, java.lang.String sessionDescription) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((newSession!=null))?(newSession.asBinder()):(null)));
_data.writeString(sessionDescription);
mRemote.transact(Stub.TRANSACTION_onCallTransferring, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when an error occurs during session initialization and
     * termination.
     *
     * @param session the session object that carries out the transaction
     * @param errorCode error code defined in {@link SipErrorCode}
     * @param errorMessage error message
     */
public void onError(android.net.sip.ISipSession session, int errorCode, java.lang.String errorMessage) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
_data.writeInt(errorCode);
_data.writeString(errorMessage);
mRemote.transact(Stub.TRANSACTION_onError, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when an error occurs during session modification negotiation.
     *
     * @param session the session object that carries out the transaction
     * @param errorCode error code defined in {@link SipErrorCode}
     * @param errorMessage error message
     */
public void onCallChangeFailed(android.net.sip.ISipSession session, int errorCode, java.lang.String errorMessage) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
_data.writeInt(errorCode);
_data.writeString(errorMessage);
mRemote.transact(Stub.TRANSACTION_onCallChangeFailed, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when a registration request is sent.
     *
     * @param session the session object that carries out the transaction
     */
public void onRegistering(android.net.sip.ISipSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_onRegistering, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when registration is successfully done.
     *
     * @param session the session object that carries out the transaction
     * @param duration duration in second before the registration expires
     */
public void onRegistrationDone(android.net.sip.ISipSession session, int duration) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
_data.writeInt(duration);
mRemote.transact(Stub.TRANSACTION_onRegistrationDone, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when the registration fails.
     *
     * @param session the session object that carries out the transaction
     * @param errorCode error code defined in {@link SipErrorCode}
     * @param errorMessage error message
     */
public void onRegistrationFailed(android.net.sip.ISipSession session, int errorCode, java.lang.String errorMessage) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
_data.writeInt(errorCode);
_data.writeString(errorMessage);
mRemote.transact(Stub.TRANSACTION_onRegistrationFailed, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called when the registration gets timed out.
     *
     * @param session the session object that carries out the transaction
     */
public void onRegistrationTimeout(android.net.sip.ISipSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_onRegistrationTimeout, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_onCalling = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_onRinging = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_onRingingBack = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_onCallEstablished = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_onCallEnded = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_onCallBusy = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_onCallTransferring = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_onError = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_onCallChangeFailed = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_onRegistering = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_onRegistrationDone = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_onRegistrationFailed = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_onRegistrationTimeout = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
}
/**
     * Called when an INVITE request is sent to initiate a new call.
     *
     * @param session the session object that carries out the transaction
     */
public void onCalling(android.net.sip.ISipSession session) throws android.os.RemoteException;
/**
     * Called when an INVITE request is received.
     *
     * @param session the session object that carries out the transaction
     * @param caller the SIP profile of the caller
     * @param sessionDescription the caller's session description
     */
public void onRinging(android.net.sip.ISipSession session, android.net.sip.SipProfile caller, java.lang.String sessionDescription) throws android.os.RemoteException;
/**
     * Called when a RINGING response is received for the INVITE request sent
     *
     * @param session the session object that carries out the transaction
     */
public void onRingingBack(android.net.sip.ISipSession session) throws android.os.RemoteException;
/**
     * Called when the session is established.
     *
     * @param session the session object that is associated with the dialog
     * @param sessionDescription the peer's session description
     */
public void onCallEstablished(android.net.sip.ISipSession session, java.lang.String sessionDescription) throws android.os.RemoteException;
/**
     * Called when the session is terminated.
     *
     * @param session the session object that is associated with the dialog
     */
public void onCallEnded(android.net.sip.ISipSession session) throws android.os.RemoteException;
/**
     * Called when the peer is busy during session initialization.
     *
     * @param session the session object that carries out the transaction
     */
public void onCallBusy(android.net.sip.ISipSession session) throws android.os.RemoteException;
/**
     * Called when the call is being transferred to a new one.
     *
     * @param newSession the new session that the call will be transferred to
     * @param sessionDescription the new peer's session description
     */
public void onCallTransferring(android.net.sip.ISipSession newSession, java.lang.String sessionDescription) throws android.os.RemoteException;
/**
     * Called when an error occurs during session initialization and
     * termination.
     *
     * @param session the session object that carries out the transaction
     * @param errorCode error code defined in {@link SipErrorCode}
     * @param errorMessage error message
     */
public void onError(android.net.sip.ISipSession session, int errorCode, java.lang.String errorMessage) throws android.os.RemoteException;
/**
     * Called when an error occurs during session modification negotiation.
     *
     * @param session the session object that carries out the transaction
     * @param errorCode error code defined in {@link SipErrorCode}
     * @param errorMessage error message
     */
public void onCallChangeFailed(android.net.sip.ISipSession session, int errorCode, java.lang.String errorMessage) throws android.os.RemoteException;
/**
     * Called when a registration request is sent.
     *
     * @param session the session object that carries out the transaction
     */
public void onRegistering(android.net.sip.ISipSession session) throws android.os.RemoteException;
/**
     * Called when registration is successfully done.
     *
     * @param session the session object that carries out the transaction
     * @param duration duration in second before the registration expires
     */
public void onRegistrationDone(android.net.sip.ISipSession session, int duration) throws android.os.RemoteException;
/**
     * Called when the registration fails.
     *
     * @param session the session object that carries out the transaction
     * @param errorCode error code defined in {@link SipErrorCode}
     * @param errorMessage error message
     */
public void onRegistrationFailed(android.net.sip.ISipSession session, int errorCode, java.lang.String errorMessage) throws android.os.RemoteException;
/**
     * Called when the registration gets timed out.
     *
     * @param session the session object that carries out the transaction
     */
public void onRegistrationTimeout(android.net.sip.ISipSession session) throws android.os.RemoteException;
}
