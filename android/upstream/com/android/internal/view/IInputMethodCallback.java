/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/view/IInputMethodCallback.aidl
 */
package com.android.internal.view;
/**
 * Helper interface for IInputMethod to allow the input method to call back
 * to its client with results from incoming calls.
 * {@hide}
 */
public interface IInputMethodCallback extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.view.IInputMethodCallback
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.view.IInputMethodCallback";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.view.IInputMethodCallback interface,
 * generating a proxy if needed.
 */
public static com.android.internal.view.IInputMethodCallback asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.view.IInputMethodCallback))) {
return ((com.android.internal.view.IInputMethodCallback)iin);
}
return new com.android.internal.view.IInputMethodCallback.Stub.Proxy(obj);
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
case TRANSACTION_finishedEvent:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.finishedEvent(_arg0, _arg1);
return true;
}
case TRANSACTION_sessionCreated:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodSession _arg0;
_arg0 = com.android.internal.view.IInputMethodSession.Stub.asInterface(data.readStrongBinder());
this.sessionCreated(_arg0);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.view.IInputMethodCallback
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
public void finishedEvent(int seq, boolean handled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(seq);
_data.writeInt(((handled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_finishedEvent, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void sessionCreated(com.android.internal.view.IInputMethodSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_sessionCreated, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_finishedEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_sessionCreated = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
}
public void finishedEvent(int seq, boolean handled) throws android.os.RemoteException;
public void sessionCreated(com.android.internal.view.IInputMethodSession session) throws android.os.RemoteException;
}
