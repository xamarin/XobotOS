/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/voip/java/android/net/sip/ISipSession.aidl
 */
package android.net.sip;
/**
 * A SIP session that is associated with a SIP dialog or a transaction that is
 * not within a dialog.
 * @hide
 */
public interface ISipSession extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.net.sip.ISipSession
{
private static final java.lang.String DESCRIPTOR = "android.net.sip.ISipSession";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.net.sip.ISipSession interface,
 * generating a proxy if needed.
 */
public static android.net.sip.ISipSession asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.net.sip.ISipSession))) {
return ((android.net.sip.ISipSession)iin);
}
return new android.net.sip.ISipSession.Stub.Proxy(obj);
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
case TRANSACTION_getLocalIp:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _result = this.getLocalIp();
reply.writeNoException();
reply.writeString(_result);
return true;
}
case TRANSACTION_getLocalProfile:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.SipProfile _result = this.getLocalProfile();
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
case TRANSACTION_getPeerProfile:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.SipProfile _result = this.getPeerProfile();
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
case TRANSACTION_getState:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getState();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_isInCall:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isInCall();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getCallId:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _result = this.getCallId();
reply.writeNoException();
reply.writeString(_result);
return true;
}
case TRANSACTION_setListener:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.ISipSessionListener _arg0;
_arg0 = android.net.sip.ISipSessionListener.Stub.asInterface(data.readStrongBinder());
this.setListener(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_register:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.register(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_unregister:
{
data.enforceInterface(DESCRIPTOR);
this.unregister();
reply.writeNoException();
return true;
}
case TRANSACTION_makeCall:
{
data.enforceInterface(DESCRIPTOR);
android.net.sip.SipProfile _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.sip.SipProfile.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
this.makeCall(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_answerCall:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
this.answerCall(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_endCall:
{
data.enforceInterface(DESCRIPTOR);
this.endCall();
reply.writeNoException();
return true;
}
case TRANSACTION_changeCall:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
this.changeCall(_arg0, _arg1);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.net.sip.ISipSession
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
     * Gets the IP address of the local host on which this SIP session runs.
     *
     * @return the IP address of the local host
     */
public java.lang.String getLocalIp() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getLocalIp, _data, _reply, 0);
_reply.readException();
_result = _reply.readString();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Gets the SIP profile that this session is associated with.
     *
     * @return the SIP profile that this session is associated with
     */
public android.net.sip.SipProfile getLocalProfile() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.sip.SipProfile _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getLocalProfile, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.sip.SipProfile.CREATOR.createFromParcel(_reply);
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
     * Gets the SIP profile that this session is connected to. Only available
     * when the session is associated with a SIP dialog.
     *
     * @return the SIP profile that this session is connected to
     */
public android.net.sip.SipProfile getPeerProfile() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.sip.SipProfile _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getPeerProfile, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.sip.SipProfile.CREATOR.createFromParcel(_reply);
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
     * Gets the session state. The value returned must be one of the states in
     * {@link SipSessionState}.
     *
     * @return the session state
     */
public int getState() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getState, _data, _reply, 0);
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
     * Checks if the session is in a call.
     *
     * @return true if the session is in a call
     */
public boolean isInCall() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isInCall, _data, _reply, 0);
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
     * Gets the call ID of the session.
     *
     * @return the call ID
     */
public java.lang.String getCallId() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getCallId, _data, _reply, 0);
_reply.readException();
_result = _reply.readString();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Sets the listener to listen to the session events. A {@link ISipSession}
     * can only hold one listener at a time. Subsequent calls to this method
     * override the previous listener.
     *
     * @param listener to listen to the session events of this object
     */
public void setListener(android.net.sip.ISipSessionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_setListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Performs registration to the server specified by the associated local
     * profile. The session listener is called back upon success or failure of
     * registration. The method is only valid to call when the session state is
     * in {@link SipSessionState#READY_TO_CALL}.
     *
     * @param duration duration in second before the registration expires
     * @see ISipSessionListener
     */
public void register(int duration) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(duration);
mRemote.transact(Stub.TRANSACTION_register, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Performs unregistration to the server specified by the associated local
     * profile. Unregistration is technically the same as registration with zero
     * expiration duration. The session listener is called back upon success or
     * failure of unregistration. The method is only valid to call when the
     * session state is in {@link SipSessionState#READY_TO_CALL}.
     *
     * @see ISipSessionListener
     */
public void unregister() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_unregister, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Initiates a call to the specified profile. The session listener is called
     * back upon defined session events. The method is only valid to call when
     * the session state is in {@link SipSessionState#READY_TO_CALL}.
     *
     * @param callee the SIP profile to make the call to
     * @param sessionDescription the session description of this call
     * @param timeout the session will be timed out if the call is not
     *        established within {@code timeout} seconds
     * @see ISipSessionListener
     */
public void makeCall(android.net.sip.SipProfile callee, java.lang.String sessionDescription, int timeout) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((callee!=null)) {
_data.writeInt(1);
callee.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(sessionDescription);
_data.writeInt(timeout);
mRemote.transact(Stub.TRANSACTION_makeCall, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Answers an incoming call with the specified session description. The
     * method is only valid to call when the session state is in
     * {@link SipSessionState#INCOMING_CALL}.
     *
     * @param sessionDescription the session description to answer this call
     * @param timeout the session will be timed out if the call is not
     *        established within {@code timeout} seconds
     */
public void answerCall(java.lang.String sessionDescription, int timeout) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(sessionDescription);
_data.writeInt(timeout);
mRemote.transact(Stub.TRANSACTION_answerCall, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Ends an established call, terminates an outgoing call or rejects an
     * incoming call. The method is only valid to call when the session state is
     * in {@link SipSessionState#IN_CALL},
     * {@link SipSessionState#INCOMING_CALL},
     * {@link SipSessionState#OUTGOING_CALL} or
     * {@link SipSessionState#OUTGOING_CALL_RING_BACK}.
     */
public void endCall() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_endCall, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Changes the session description during a call. The method is only valid
     * to call when the session state is in {@link SipSessionState#IN_CALL}.
     *
     * @param sessionDescription the new session description
     * @param timeout the session will be timed out if the call is not
     *        established within {@code timeout} seconds
     */
public void changeCall(java.lang.String sessionDescription, int timeout) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(sessionDescription);
_data.writeInt(timeout);
mRemote.transact(Stub.TRANSACTION_changeCall, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_getLocalIp = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getLocalProfile = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getPeerProfile = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_isInCall = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_getCallId = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_register = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_unregister = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_makeCall = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_answerCall = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_endCall = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_changeCall = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
}
/**
     * Gets the IP address of the local host on which this SIP session runs.
     *
     * @return the IP address of the local host
     */
public java.lang.String getLocalIp() throws android.os.RemoteException;
/**
     * Gets the SIP profile that this session is associated with.
     *
     * @return the SIP profile that this session is associated with
     */
public android.net.sip.SipProfile getLocalProfile() throws android.os.RemoteException;
/**
     * Gets the SIP profile that this session is connected to. Only available
     * when the session is associated with a SIP dialog.
     *
     * @return the SIP profile that this session is connected to
     */
public android.net.sip.SipProfile getPeerProfile() throws android.os.RemoteException;
/**
     * Gets the session state. The value returned must be one of the states in
     * {@link SipSessionState}.
     *
     * @return the session state
     */
public int getState() throws android.os.RemoteException;
/**
     * Checks if the session is in a call.
     *
     * @return true if the session is in a call
     */
public boolean isInCall() throws android.os.RemoteException;
/**
     * Gets the call ID of the session.
     *
     * @return the call ID
     */
public java.lang.String getCallId() throws android.os.RemoteException;
/**
     * Sets the listener to listen to the session events. A {@link ISipSession}
     * can only hold one listener at a time. Subsequent calls to this method
     * override the previous listener.
     *
     * @param listener to listen to the session events of this object
     */
public void setListener(android.net.sip.ISipSessionListener listener) throws android.os.RemoteException;
/**
     * Performs registration to the server specified by the associated local
     * profile. The session listener is called back upon success or failure of
     * registration. The method is only valid to call when the session state is
     * in {@link SipSessionState#READY_TO_CALL}.
     *
     * @param duration duration in second before the registration expires
     * @see ISipSessionListener
     */
public void register(int duration) throws android.os.RemoteException;
/**
     * Performs unregistration to the server specified by the associated local
     * profile. Unregistration is technically the same as registration with zero
     * expiration duration. The session listener is called back upon success or
     * failure of unregistration. The method is only valid to call when the
     * session state is in {@link SipSessionState#READY_TO_CALL}.
     *
     * @see ISipSessionListener
     */
public void unregister() throws android.os.RemoteException;
/**
     * Initiates a call to the specified profile. The session listener is called
     * back upon defined session events. The method is only valid to call when
     * the session state is in {@link SipSessionState#READY_TO_CALL}.
     *
     * @param callee the SIP profile to make the call to
     * @param sessionDescription the session description of this call
     * @param timeout the session will be timed out if the call is not
     *        established within {@code timeout} seconds
     * @see ISipSessionListener
     */
public void makeCall(android.net.sip.SipProfile callee, java.lang.String sessionDescription, int timeout) throws android.os.RemoteException;
/**
     * Answers an incoming call with the specified session description. The
     * method is only valid to call when the session state is in
     * {@link SipSessionState#INCOMING_CALL}.
     *
     * @param sessionDescription the session description to answer this call
     * @param timeout the session will be timed out if the call is not
     *        established within {@code timeout} seconds
     */
public void answerCall(java.lang.String sessionDescription, int timeout) throws android.os.RemoteException;
/**
     * Ends an established call, terminates an outgoing call or rejects an
     * incoming call. The method is only valid to call when the session state is
     * in {@link SipSessionState#IN_CALL},
     * {@link SipSessionState#INCOMING_CALL},
     * {@link SipSessionState#OUTGOING_CALL} or
     * {@link SipSessionState#OUTGOING_CALL_RING_BACK}.
     */
public void endCall() throws android.os.RemoteException;
/**
     * Changes the session description during a call. The method is only valid
     * to call when the session state is in {@link SipSessionState#IN_CALL}.
     *
     * @param sessionDescription the new session description
     * @param timeout the session will be timed out if the call is not
     *        established within {@code timeout} seconds
     */
public void changeCall(java.lang.String sessionDescription, int timeout) throws android.os.RemoteException;
}
