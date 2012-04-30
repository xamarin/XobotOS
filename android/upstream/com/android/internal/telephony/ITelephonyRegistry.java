/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/telephony/java/com/android/internal/telephony/ITelephonyRegistry.aidl
 */
package com.android.internal.telephony;
public interface ITelephonyRegistry extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.telephony.ITelephonyRegistry
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.telephony.ITelephonyRegistry";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.telephony.ITelephonyRegistry interface,
 * generating a proxy if needed.
 */
public static com.android.internal.telephony.ITelephonyRegistry asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.telephony.ITelephonyRegistry))) {
return ((com.android.internal.telephony.ITelephonyRegistry)iin);
}
return new com.android.internal.telephony.ITelephonyRegistry.Stub.Proxy(obj);
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
case TRANSACTION_listen:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
com.android.internal.telephony.IPhoneStateListener _arg1;
_arg1 = com.android.internal.telephony.IPhoneStateListener.Stub.asInterface(data.readStrongBinder());
int _arg2;
_arg2 = data.readInt();
boolean _arg3;
_arg3 = (0!=data.readInt());
this.listen(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyCallState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
java.lang.String _arg1;
_arg1 = data.readString();
this.notifyCallState(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyServiceState:
{
data.enforceInterface(DESCRIPTOR);
android.telephony.ServiceState _arg0;
if ((0!=data.readInt())) {
_arg0 = android.telephony.ServiceState.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.notifyServiceState(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifySignalStrength:
{
data.enforceInterface(DESCRIPTOR);
android.telephony.SignalStrength _arg0;
if ((0!=data.readInt())) {
_arg0 = android.telephony.SignalStrength.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.notifySignalStrength(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyMessageWaitingChanged:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.notifyMessageWaitingChanged(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyCallForwardingChanged:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.notifyCallForwardingChanged(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyDataActivity:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.notifyDataActivity(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyDataConnection:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
java.lang.String _arg2;
_arg2 = data.readString();
java.lang.String _arg3;
_arg3 = data.readString();
java.lang.String _arg4;
_arg4 = data.readString();
android.net.LinkProperties _arg5;
if ((0!=data.readInt())) {
_arg5 = android.net.LinkProperties.CREATOR.createFromParcel(data);
}
else {
_arg5 = null;
}
android.net.LinkCapabilities _arg6;
if ((0!=data.readInt())) {
_arg6 = android.net.LinkCapabilities.CREATOR.createFromParcel(data);
}
else {
_arg6 = null;
}
int _arg7;
_arg7 = data.readInt();
boolean _arg8;
_arg8 = (0!=data.readInt());
this.notifyDataConnection(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyDataConnectionFailed:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
this.notifyDataConnectionFailed(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyCellLocation:
{
data.enforceInterface(DESCRIPTOR);
android.os.Bundle _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.notifyCellLocation(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyOtaspChanged:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.notifyOtaspChanged(_arg0);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.telephony.ITelephonyRegistry
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
public void listen(java.lang.String pkg, com.android.internal.telephony.IPhoneStateListener callback, int events, boolean notifyNow) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
_data.writeInt(events);
_data.writeInt(((notifyNow)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_listen, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyCallState(int state, java.lang.String incomingNumber) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(state);
_data.writeString(incomingNumber);
mRemote.transact(Stub.TRANSACTION_notifyCallState, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyServiceState(android.telephony.ServiceState state) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((state!=null)) {
_data.writeInt(1);
state.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_notifyServiceState, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifySignalStrength(android.telephony.SignalStrength signalStrength) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((signalStrength!=null)) {
_data.writeInt(1);
signalStrength.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_notifySignalStrength, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyMessageWaitingChanged(boolean mwi) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((mwi)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_notifyMessageWaitingChanged, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyCallForwardingChanged(boolean cfi) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((cfi)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_notifyCallForwardingChanged, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyDataActivity(int state) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(state);
mRemote.transact(Stub.TRANSACTION_notifyDataActivity, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyDataConnection(int state, boolean isDataConnectivityPossible, java.lang.String reason, java.lang.String apn, java.lang.String apnType, android.net.LinkProperties linkProperties, android.net.LinkCapabilities linkCapabilities, int networkType, boolean roaming) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(state);
_data.writeInt(((isDataConnectivityPossible)?(1):(0)));
_data.writeString(reason);
_data.writeString(apn);
_data.writeString(apnType);
if ((linkProperties!=null)) {
_data.writeInt(1);
linkProperties.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((linkCapabilities!=null)) {
_data.writeInt(1);
linkCapabilities.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(networkType);
_data.writeInt(((roaming)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_notifyDataConnection, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyDataConnectionFailed(java.lang.String reason, java.lang.String apnType) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(reason);
_data.writeString(apnType);
mRemote.transact(Stub.TRANSACTION_notifyDataConnectionFailed, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyCellLocation(android.os.Bundle cellLocation) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((cellLocation!=null)) {
_data.writeInt(1);
cellLocation.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_notifyCellLocation, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyOtaspChanged(int otaspMode) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(otaspMode);
mRemote.transact(Stub.TRANSACTION_notifyOtaspChanged, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_listen = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_notifyCallState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_notifyServiceState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_notifySignalStrength = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_notifyMessageWaitingChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_notifyCallForwardingChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_notifyDataActivity = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_notifyDataConnection = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_notifyDataConnectionFailed = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_notifyCellLocation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_notifyOtaspChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
}
public void listen(java.lang.String pkg, com.android.internal.telephony.IPhoneStateListener callback, int events, boolean notifyNow) throws android.os.RemoteException;
public void notifyCallState(int state, java.lang.String incomingNumber) throws android.os.RemoteException;
public void notifyServiceState(android.telephony.ServiceState state) throws android.os.RemoteException;
public void notifySignalStrength(android.telephony.SignalStrength signalStrength) throws android.os.RemoteException;
public void notifyMessageWaitingChanged(boolean mwi) throws android.os.RemoteException;
public void notifyCallForwardingChanged(boolean cfi) throws android.os.RemoteException;
public void notifyDataActivity(int state) throws android.os.RemoteException;
public void notifyDataConnection(int state, boolean isDataConnectivityPossible, java.lang.String reason, java.lang.String apn, java.lang.String apnType, android.net.LinkProperties linkProperties, android.net.LinkCapabilities linkCapabilities, int networkType, boolean roaming) throws android.os.RemoteException;
public void notifyDataConnectionFailed(java.lang.String reason, java.lang.String apnType) throws android.os.RemoteException;
public void notifyCellLocation(android.os.Bundle cellLocation) throws android.os.RemoteException;
public void notifyOtaspChanged(int otaspMode) throws android.os.RemoteException;
}
