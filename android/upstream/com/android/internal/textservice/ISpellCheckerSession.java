/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/textservice/ISpellCheckerSession.aidl
 */
package com.android.internal.textservice;
/**
 * @hide
 */
public interface ISpellCheckerSession extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.textservice.ISpellCheckerSession
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.textservice.ISpellCheckerSession";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.textservice.ISpellCheckerSession interface,
 * generating a proxy if needed.
 */
public static com.android.internal.textservice.ISpellCheckerSession asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.textservice.ISpellCheckerSession))) {
return ((com.android.internal.textservice.ISpellCheckerSession)iin);
}
return new com.android.internal.textservice.ISpellCheckerSession.Stub.Proxy(obj);
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
case TRANSACTION_onGetSuggestionsMultiple:
{
data.enforceInterface(DESCRIPTOR);
android.view.textservice.TextInfo[] _arg0;
_arg0 = data.createTypedArray(android.view.textservice.TextInfo.CREATOR);
int _arg1;
_arg1 = data.readInt();
boolean _arg2;
_arg2 = (0!=data.readInt());
this.onGetSuggestionsMultiple(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_onCancel:
{
data.enforceInterface(DESCRIPTOR);
this.onCancel();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.textservice.ISpellCheckerSession
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
public void onGetSuggestionsMultiple(android.view.textservice.TextInfo[] textInfos, int suggestionsLimit, boolean multipleWords) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeTypedArray(textInfos, 0);
_data.writeInt(suggestionsLimit);
_data.writeInt(((multipleWords)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_onGetSuggestionsMultiple, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void onCancel() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_onCancel, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_onGetSuggestionsMultiple = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_onCancel = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
}
public void onGetSuggestionsMultiple(android.view.textservice.TextInfo[] textInfos, int suggestionsLimit, boolean multipleWords) throws android.os.RemoteException;
public void onCancel() throws android.os.RemoteException;
}
