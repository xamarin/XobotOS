/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/textservice/ITextServicesManager.aidl
 */
package com.android.internal.textservice;
/**
 * Interface to the text service manager.
 * @hide
 */
public interface ITextServicesManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.textservice.ITextServicesManager
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.textservice.ITextServicesManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.textservice.ITextServicesManager interface,
 * generating a proxy if needed.
 */
public static com.android.internal.textservice.ITextServicesManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.textservice.ITextServicesManager))) {
return ((com.android.internal.textservice.ITextServicesManager)iin);
}
return new com.android.internal.textservice.ITextServicesManager.Stub.Proxy(obj);
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
case TRANSACTION_getCurrentSpellChecker:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.view.textservice.SpellCheckerInfo _result = this.getCurrentSpellChecker(_arg0);
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
case TRANSACTION_getCurrentSpellCheckerSubtype:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _arg1;
_arg1 = (0!=data.readInt());
android.view.textservice.SpellCheckerSubtype _result = this.getCurrentSpellCheckerSubtype(_arg0, _arg1);
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
case TRANSACTION_getSpellCheckerService:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
com.android.internal.textservice.ITextServicesSessionListener _arg2;
_arg2 = com.android.internal.textservice.ITextServicesSessionListener.Stub.asInterface(data.readStrongBinder());
com.android.internal.textservice.ISpellCheckerSessionListener _arg3;
_arg3 = com.android.internal.textservice.ISpellCheckerSessionListener.Stub.asInterface(data.readStrongBinder());
android.os.Bundle _arg4;
if ((0!=data.readInt())) {
_arg4 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg4 = null;
}
this.getSpellCheckerService(_arg0, _arg1, _arg2, _arg3, _arg4);
return true;
}
case TRANSACTION_finishSpellCheckerService:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.textservice.ISpellCheckerSessionListener _arg0;
_arg0 = com.android.internal.textservice.ISpellCheckerSessionListener.Stub.asInterface(data.readStrongBinder());
this.finishSpellCheckerService(_arg0);
return true;
}
case TRANSACTION_setCurrentSpellChecker:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
this.setCurrentSpellChecker(_arg0, _arg1);
return true;
}
case TRANSACTION_setCurrentSpellCheckerSubtype:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
this.setCurrentSpellCheckerSubtype(_arg0, _arg1);
return true;
}
case TRANSACTION_setSpellCheckerEnabled:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.setSpellCheckerEnabled(_arg0);
return true;
}
case TRANSACTION_isSpellCheckerEnabled:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isSpellCheckerEnabled();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getEnabledSpellCheckers:
{
data.enforceInterface(DESCRIPTOR);
android.view.textservice.SpellCheckerInfo[] _result = this.getEnabledSpellCheckers();
reply.writeNoException();
reply.writeTypedArray(_result, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.textservice.ITextServicesManager
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
public android.view.textservice.SpellCheckerInfo getCurrentSpellChecker(java.lang.String locale) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.textservice.SpellCheckerInfo _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(locale);
mRemote.transact(Stub.TRANSACTION_getCurrentSpellChecker, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.view.textservice.SpellCheckerInfo.CREATOR.createFromParcel(_reply);
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
public android.view.textservice.SpellCheckerSubtype getCurrentSpellCheckerSubtype(java.lang.String locale, boolean allowImplicitlySelectedSubtype) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.textservice.SpellCheckerSubtype _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(locale);
_data.writeInt(((allowImplicitlySelectedSubtype)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_getCurrentSpellCheckerSubtype, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.view.textservice.SpellCheckerSubtype.CREATOR.createFromParcel(_reply);
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
public void getSpellCheckerService(java.lang.String sciId, java.lang.String locale, com.android.internal.textservice.ITextServicesSessionListener tsListener, com.android.internal.textservice.ISpellCheckerSessionListener scListener, android.os.Bundle bundle) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(sciId);
_data.writeString(locale);
_data.writeStrongBinder((((tsListener!=null))?(tsListener.asBinder()):(null)));
_data.writeStrongBinder((((scListener!=null))?(scListener.asBinder()):(null)));
if ((bundle!=null)) {
_data.writeInt(1);
bundle.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getSpellCheckerService, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void finishSpellCheckerService(com.android.internal.textservice.ISpellCheckerSessionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_finishSpellCheckerService, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setCurrentSpellChecker(java.lang.String locale, java.lang.String sciId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(locale);
_data.writeString(sciId);
mRemote.transact(Stub.TRANSACTION_setCurrentSpellChecker, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setCurrentSpellCheckerSubtype(java.lang.String locale, int hashCode) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(locale);
_data.writeInt(hashCode);
mRemote.transact(Stub.TRANSACTION_setCurrentSpellCheckerSubtype, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setSpellCheckerEnabled(boolean enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((enabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setSpellCheckerEnabled, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public boolean isSpellCheckerEnabled() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isSpellCheckerEnabled, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.view.textservice.SpellCheckerInfo[] getEnabledSpellCheckers() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.textservice.SpellCheckerInfo[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getEnabledSpellCheckers, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArray(android.view.textservice.SpellCheckerInfo.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_getCurrentSpellChecker = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getCurrentSpellCheckerSubtype = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getSpellCheckerService = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_finishSpellCheckerService = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_setCurrentSpellChecker = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_setCurrentSpellCheckerSubtype = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setSpellCheckerEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_isSpellCheckerEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_getEnabledSpellCheckers = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
}
public android.view.textservice.SpellCheckerInfo getCurrentSpellChecker(java.lang.String locale) throws android.os.RemoteException;
public android.view.textservice.SpellCheckerSubtype getCurrentSpellCheckerSubtype(java.lang.String locale, boolean allowImplicitlySelectedSubtype) throws android.os.RemoteException;
public void getSpellCheckerService(java.lang.String sciId, java.lang.String locale, com.android.internal.textservice.ITextServicesSessionListener tsListener, com.android.internal.textservice.ISpellCheckerSessionListener scListener, android.os.Bundle bundle) throws android.os.RemoteException;
public void finishSpellCheckerService(com.android.internal.textservice.ISpellCheckerSessionListener listener) throws android.os.RemoteException;
public void setCurrentSpellChecker(java.lang.String locale, java.lang.String sciId) throws android.os.RemoteException;
public void setCurrentSpellCheckerSubtype(java.lang.String locale, int hashCode) throws android.os.RemoteException;
public void setSpellCheckerEnabled(boolean enabled) throws android.os.RemoteException;
public boolean isSpellCheckerEnabled() throws android.os.RemoteException;
public android.view.textservice.SpellCheckerInfo[] getEnabledSpellCheckers() throws android.os.RemoteException;
}
