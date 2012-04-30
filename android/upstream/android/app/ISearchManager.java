/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/app/ISearchManager.aidl
 */
package android.app;
/** @hide */
public interface ISearchManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.app.ISearchManager
{
private static final java.lang.String DESCRIPTOR = "android.app.ISearchManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.app.ISearchManager interface,
 * generating a proxy if needed.
 */
public static android.app.ISearchManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.app.ISearchManager))) {
return ((android.app.ISearchManager)iin);
}
return new android.app.ISearchManager.Stub.Proxy(obj);
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
case TRANSACTION_getSearchableInfo:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.app.SearchableInfo _result = this.getSearchableInfo(_arg0);
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
case TRANSACTION_getSearchablesInGlobalSearch:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.app.SearchableInfo> _result = this.getSearchablesInGlobalSearch();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_getGlobalSearchActivities:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.content.pm.ResolveInfo> _result = this.getGlobalSearchActivities();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_getGlobalSearchActivity:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _result = this.getGlobalSearchActivity();
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
case TRANSACTION_getWebSearchActivity:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _result = this.getWebSearchActivity();
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
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.app.ISearchManager
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
public android.app.SearchableInfo getSearchableInfo(android.content.ComponentName launchActivity) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.app.SearchableInfo _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((launchActivity!=null)) {
_data.writeInt(1);
launchActivity.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getSearchableInfo, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.app.SearchableInfo.CREATOR.createFromParcel(_reply);
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
public java.util.List<android.app.SearchableInfo> getSearchablesInGlobalSearch() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.app.SearchableInfo> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getSearchablesInGlobalSearch, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.app.SearchableInfo.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public java.util.List<android.content.pm.ResolveInfo> getGlobalSearchActivities() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.content.pm.ResolveInfo> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getGlobalSearchActivities, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.content.pm.ResolveInfo.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.content.ComponentName getGlobalSearchActivity() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.ComponentName _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getGlobalSearchActivity, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.ComponentName.CREATOR.createFromParcel(_reply);
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
public android.content.ComponentName getWebSearchActivity() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.ComponentName _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getWebSearchActivity, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.ComponentName.CREATOR.createFromParcel(_reply);
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
}
static final int TRANSACTION_getSearchableInfo = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getSearchablesInGlobalSearch = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getGlobalSearchActivities = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getGlobalSearchActivity = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_getWebSearchActivity = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
}
public android.app.SearchableInfo getSearchableInfo(android.content.ComponentName launchActivity) throws android.os.RemoteException;
public java.util.List<android.app.SearchableInfo> getSearchablesInGlobalSearch() throws android.os.RemoteException;
public java.util.List<android.content.pm.ResolveInfo> getGlobalSearchActivities() throws android.os.RemoteException;
public android.content.ComponentName getGlobalSearchActivity() throws android.os.RemoteException;
public android.content.ComponentName getWebSearchActivity() throws android.os.RemoteException;
}
