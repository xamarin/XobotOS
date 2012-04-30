/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/view/IInputMethodClient.aidl
 */
package com.android.internal.view;
/**
 * Interface a client of the IInputMethodManager implements, to identify
 * itself and receive information about changes to the global manager state.
 */
public interface IInputMethodClient extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.view.IInputMethodClient
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.view.IInputMethodClient";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.view.IInputMethodClient interface,
 * generating a proxy if needed.
 */
public static com.android.internal.view.IInputMethodClient asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.view.IInputMethodClient))) {
return ((com.android.internal.view.IInputMethodClient)iin);
}
return new com.android.internal.view.IInputMethodClient.Stub.Proxy(obj);
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
case TRANSACTION_setUsingInputMethod:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.setUsingInputMethod(_arg0);
return true;
}
case TRANSACTION_onBindMethod:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.InputBindResult _arg0;
if ((0!=data.readInt())) {
_arg0 = com.android.internal.view.InputBindResult.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.onBindMethod(_arg0);
return true;
}
case TRANSACTION_onUnbindMethod:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.onUnbindMethod(_arg0);
return true;
}
case TRANSACTION_setActive:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.setActive(_arg0);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.view.IInputMethodClient
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
public void setUsingInputMethod(boolean state) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((state)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setUsingInputMethod, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void onBindMethod(com.android.internal.view.InputBindResult res) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((res!=null)) {
_data.writeInt(1);
res.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_onBindMethod, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void onUnbindMethod(int sequence) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sequence);
mRemote.transact(Stub.TRANSACTION_onUnbindMethod, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setActive(boolean active) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((active)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setActive, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_setUsingInputMethod = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_onBindMethod = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_onUnbindMethod = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_setActive = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
}
public void setUsingInputMethod(boolean state) throws android.os.RemoteException;
public void onBindMethod(com.android.internal.view.InputBindResult res) throws android.os.RemoteException;
public void onUnbindMethod(int sequence) throws android.os.RemoteException;
public void setActive(boolean active) throws android.os.RemoteException;
}
