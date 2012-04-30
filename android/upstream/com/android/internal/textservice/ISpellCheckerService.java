/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/textservice/ISpellCheckerService.aidl
 */
package com.android.internal.textservice;
/**
 * Public interface to the global spell checker.
 * @hide
 */
public interface ISpellCheckerService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.textservice.ISpellCheckerService
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.textservice.ISpellCheckerService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.textservice.ISpellCheckerService interface,
 * generating a proxy if needed.
 */
public static com.android.internal.textservice.ISpellCheckerService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.textservice.ISpellCheckerService))) {
return ((com.android.internal.textservice.ISpellCheckerService)iin);
}
return new com.android.internal.textservice.ISpellCheckerService.Stub.Proxy(obj);
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
case TRANSACTION_getISpellCheckerSession:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
com.android.internal.textservice.ISpellCheckerSessionListener _arg1;
_arg1 = com.android.internal.textservice.ISpellCheckerSessionListener.Stub.asInterface(data.readStrongBinder());
android.os.Bundle _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
com.android.internal.textservice.ISpellCheckerSession _result = this.getISpellCheckerSession(_arg0, _arg1, _arg2);
reply.writeNoException();
reply.writeStrongBinder((((_result!=null))?(_result.asBinder()):(null)));
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.textservice.ISpellCheckerService
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
public com.android.internal.textservice.ISpellCheckerSession getISpellCheckerSession(java.lang.String locale, com.android.internal.textservice.ISpellCheckerSessionListener listener, android.os.Bundle bundle) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
com.android.internal.textservice.ISpellCheckerSession _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(locale);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
if ((bundle!=null)) {
_data.writeInt(1);
bundle.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getISpellCheckerSession, _data, _reply, 0);
_reply.readException();
_result = com.android.internal.textservice.ISpellCheckerSession.Stub.asInterface(_reply.readStrongBinder());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_getISpellCheckerSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
}
public com.android.internal.textservice.ISpellCheckerSession getISpellCheckerSession(java.lang.String locale, com.android.internal.textservice.ISpellCheckerSessionListener listener, android.os.Bundle bundle) throws android.os.RemoteException;
}
