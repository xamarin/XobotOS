/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/content/IContentService.aidl
 */
package android.content;
/**
 * @hide
 */
public interface IContentService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.content.IContentService
{
private static final java.lang.String DESCRIPTOR = "android.content.IContentService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.content.IContentService interface,
 * generating a proxy if needed.
 */
public static android.content.IContentService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.content.IContentService))) {
return ((android.content.IContentService)iin);
}
return new android.content.IContentService.Stub.Proxy(obj);
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
case TRANSACTION_registerContentObserver:
{
data.enforceInterface(DESCRIPTOR);
android.net.Uri _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.Uri.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
android.database.IContentObserver _arg2;
_arg2 = android.database.IContentObserver.Stub.asInterface(data.readStrongBinder());
this.registerContentObserver(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_unregisterContentObserver:
{
data.enforceInterface(DESCRIPTOR);
android.database.IContentObserver _arg0;
_arg0 = android.database.IContentObserver.Stub.asInterface(data.readStrongBinder());
this.unregisterContentObserver(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifyChange:
{
data.enforceInterface(DESCRIPTOR);
android.net.Uri _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.Uri.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.database.IContentObserver _arg1;
_arg1 = android.database.IContentObserver.Stub.asInterface(data.readStrongBinder());
boolean _arg2;
_arg2 = (0!=data.readInt());
boolean _arg3;
_arg3 = (0!=data.readInt());
this.notifyChange(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_requestSync:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
android.os.Bundle _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
this.requestSync(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_cancelSync:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
this.cancelSync(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getSyncAutomatically:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
boolean _result = this.getSyncAutomatically(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setSyncAutomatically:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
boolean _arg2;
_arg2 = (0!=data.readInt());
this.setSyncAutomatically(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_getPeriodicSyncs:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
java.util.List<android.content.PeriodicSync> _result = this.getPeriodicSyncs(_arg0, _arg1);
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_addPeriodicSync:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
android.os.Bundle _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
long _arg3;
_arg3 = data.readLong();
this.addPeriodicSync(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_removePeriodicSync:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
android.os.Bundle _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
this.removePeriodicSync(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_getIsSyncable:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
int _result = this.getIsSyncable(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setIsSyncable:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
this.setIsSyncable(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_setMasterSyncAutomatically:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.setMasterSyncAutomatically(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getMasterSyncAutomatically:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.getMasterSyncAutomatically();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_isSyncActive:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
boolean _result = this.isSyncActive(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getCurrentSyncs:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.content.SyncInfo> _result = this.getCurrentSyncs();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_getSyncAdapterTypes:
{
data.enforceInterface(DESCRIPTOR);
android.content.SyncAdapterType[] _result = this.getSyncAdapterTypes();
reply.writeNoException();
reply.writeTypedArray(_result, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
return true;
}
case TRANSACTION_getSyncStatus:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
android.content.SyncStatusInfo _result = this.getSyncStatus(_arg0, _arg1);
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
case TRANSACTION_isSyncPending:
{
data.enforceInterface(DESCRIPTOR);
android.accounts.Account _arg0;
if ((0!=data.readInt())) {
_arg0 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
boolean _result = this.isSyncPending(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_addStatusChangeListener:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.content.ISyncStatusObserver _arg1;
_arg1 = android.content.ISyncStatusObserver.Stub.asInterface(data.readStrongBinder());
this.addStatusChangeListener(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeStatusChangeListener:
{
data.enforceInterface(DESCRIPTOR);
android.content.ISyncStatusObserver _arg0;
_arg0 = android.content.ISyncStatusObserver.Stub.asInterface(data.readStrongBinder());
this.removeStatusChangeListener(_arg0);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.content.IContentService
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
public void registerContentObserver(android.net.Uri uri, boolean notifyForDescendentsn, android.database.IContentObserver observer) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((uri!=null)) {
_data.writeInt(1);
uri.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((notifyForDescendentsn)?(1):(0)));
_data.writeStrongBinder((((observer!=null))?(observer.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_registerContentObserver, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void unregisterContentObserver(android.database.IContentObserver observer) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((observer!=null))?(observer.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_unregisterContentObserver, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notifyChange(android.net.Uri uri, android.database.IContentObserver observer, boolean observerWantsSelfNotifications, boolean syncToNetwork) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((uri!=null)) {
_data.writeInt(1);
uri.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeStrongBinder((((observer!=null))?(observer.asBinder()):(null)));
_data.writeInt(((observerWantsSelfNotifications)?(1):(0)));
_data.writeInt(((syncToNetwork)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_notifyChange, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void requestSync(android.accounts.Account account, java.lang.String authority, android.os.Bundle extras) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(authority);
if ((extras!=null)) {
_data.writeInt(1);
extras.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_requestSync, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void cancelSync(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(authority);
mRemote.transact(Stub.TRANSACTION_cancelSync, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Check if the provider should be synced when a network tickle is received
     * @param providerName the provider whose setting we are querying
     * @return true if the provider should be synced when a network tickle is received
     */
public boolean getSyncAutomatically(android.accounts.Account account, java.lang.String providerName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(providerName);
mRemote.transact(Stub.TRANSACTION_getSyncAutomatically, _data, _reply, 0);
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
     * Set whether or not the provider is synced when it receives a network tickle.
     *
     * @param providerName the provider whose behavior is being controlled
     * @param sync true if the provider should be synced when tickles are received for it
     */
public void setSyncAutomatically(android.accounts.Account account, java.lang.String providerName, boolean sync) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(providerName);
_data.writeInt(((sync)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setSyncAutomatically, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Get the frequency of the periodic poll, if any.
     * @param providerName the provider whose setting we are querying
     * @return the frequency of the periodic sync in seconds. If 0 then no periodic syncs
     * will take place.
     */
public java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account account, java.lang.String providerName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.content.PeriodicSync> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(providerName);
mRemote.transact(Stub.TRANSACTION_getPeriodicSyncs, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.content.PeriodicSync.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Set whether or not the provider is to be synced on a periodic basis.
     *
     * @param providerName the provider whose behavior is being controlled
     * @param pollFrequency the period that a sync should be performed, in seconds. If this is
     * zero or less then no periodic syncs will be performed.
     */
public void addPeriodicSync(android.accounts.Account account, java.lang.String providerName, android.os.Bundle extras, long pollFrequency) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(providerName);
if ((extras!=null)) {
_data.writeInt(1);
extras.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeLong(pollFrequency);
mRemote.transact(Stub.TRANSACTION_addPeriodicSync, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Set whether or not the provider is to be synced on a periodic basis.
     *
     * @param providerName the provider whose behavior is being controlled
     * @param pollFrequency the period that a sync should be performed, in seconds. If this is
     * zero or less then no periodic syncs will be performed.
     */
public void removePeriodicSync(android.accounts.Account account, java.lang.String providerName, android.os.Bundle extras) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(providerName);
if ((extras!=null)) {
_data.writeInt(1);
extras.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_removePeriodicSync, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Check if this account/provider is syncable.
     * @return >0 if it is syncable, 0 if not, and <0 if the state isn't known yet.
     */
public int getIsSyncable(android.accounts.Account account, java.lang.String providerName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(providerName);
mRemote.transact(Stub.TRANSACTION_getIsSyncable, _data, _reply, 0);
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
     * Set whether this account/provider is syncable.
     * @param syncable, >0 denotes syncable, 0 means not syncable, <0 means unknown
     */
public void setIsSyncable(android.accounts.Account account, java.lang.String providerName, int syncable) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(providerName);
_data.writeInt(syncable);
mRemote.transact(Stub.TRANSACTION_setIsSyncable, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setMasterSyncAutomatically(boolean flag) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((flag)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setMasterSyncAutomatically, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean getMasterSyncAutomatically() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getMasterSyncAutomatically, _data, _reply, 0);
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
     * Returns true if there is currently a sync operation for the given
     * account or authority in the pending list, or actively being processed.
     */
public boolean isSyncActive(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(authority);
mRemote.transact(Stub.TRANSACTION_isSyncActive, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public java.util.List<android.content.SyncInfo> getCurrentSyncs() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.content.SyncInfo> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getCurrentSyncs, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.content.SyncInfo.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Returns the types of the SyncAdapters that are registered with the system.
     * @return Returns the types of the SyncAdapters that are registered with the system.
     */
public android.content.SyncAdapterType[] getSyncAdapterTypes() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.SyncAdapterType[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getSyncAdapterTypes, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArray(android.content.SyncAdapterType.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Returns the status that matches the authority. If there are multiples accounts for
     * the authority, the one with the latest "lastSuccessTime" status is returned.
     * @param authority the authority whose row should be selected
     * @return the SyncStatusInfo for the authority, or null if none exists
     */
public android.content.SyncStatusInfo getSyncStatus(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.SyncStatusInfo _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(authority);
mRemote.transact(Stub.TRANSACTION_getSyncStatus, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.SyncStatusInfo.CREATOR.createFromParcel(_reply);
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
     * Return true if the pending status is true of any matching authorities.
     */
public boolean isSyncPending(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(authority);
mRemote.transact(Stub.TRANSACTION_isSyncPending, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void addStatusChangeListener(int mask, android.content.ISyncStatusObserver callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(mask);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_addStatusChangeListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removeStatusChangeListener(android.content.ISyncStatusObserver callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_removeStatusChangeListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_registerContentObserver = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_unregisterContentObserver = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_notifyChange = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_requestSync = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_cancelSync = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_getSyncAutomatically = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setSyncAutomatically = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_getPeriodicSyncs = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_addPeriodicSync = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_removePeriodicSync = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_getIsSyncable = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_setIsSyncable = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_setMasterSyncAutomatically = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_getMasterSyncAutomatically = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_isSyncActive = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_getCurrentSyncs = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_getSyncAdapterTypes = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_getSyncStatus = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_isSyncPending = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_addStatusChangeListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_removeStatusChangeListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
}
public void registerContentObserver(android.net.Uri uri, boolean notifyForDescendentsn, android.database.IContentObserver observer) throws android.os.RemoteException;
public void unregisterContentObserver(android.database.IContentObserver observer) throws android.os.RemoteException;
public void notifyChange(android.net.Uri uri, android.database.IContentObserver observer, boolean observerWantsSelfNotifications, boolean syncToNetwork) throws android.os.RemoteException;
public void requestSync(android.accounts.Account account, java.lang.String authority, android.os.Bundle extras) throws android.os.RemoteException;
public void cancelSync(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException;
/**
     * Check if the provider should be synced when a network tickle is received
     * @param providerName the provider whose setting we are querying
     * @return true if the provider should be synced when a network tickle is received
     */
public boolean getSyncAutomatically(android.accounts.Account account, java.lang.String providerName) throws android.os.RemoteException;
/**
     * Set whether or not the provider is synced when it receives a network tickle.
     *
     * @param providerName the provider whose behavior is being controlled
     * @param sync true if the provider should be synced when tickles are received for it
     */
public void setSyncAutomatically(android.accounts.Account account, java.lang.String providerName, boolean sync) throws android.os.RemoteException;
/**
     * Get the frequency of the periodic poll, if any.
     * @param providerName the provider whose setting we are querying
     * @return the frequency of the periodic sync in seconds. If 0 then no periodic syncs
     * will take place.
     */
public java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account account, java.lang.String providerName) throws android.os.RemoteException;
/**
     * Set whether or not the provider is to be synced on a periodic basis.
     *
     * @param providerName the provider whose behavior is being controlled
     * @param pollFrequency the period that a sync should be performed, in seconds. If this is
     * zero or less then no periodic syncs will be performed.
     */
public void addPeriodicSync(android.accounts.Account account, java.lang.String providerName, android.os.Bundle extras, long pollFrequency) throws android.os.RemoteException;
/**
     * Set whether or not the provider is to be synced on a periodic basis.
     *
     * @param providerName the provider whose behavior is being controlled
     * @param pollFrequency the period that a sync should be performed, in seconds. If this is
     * zero or less then no periodic syncs will be performed.
     */
public void removePeriodicSync(android.accounts.Account account, java.lang.String providerName, android.os.Bundle extras) throws android.os.RemoteException;
/**
     * Check if this account/provider is syncable.
     * @return >0 if it is syncable, 0 if not, and <0 if the state isn't known yet.
     */
public int getIsSyncable(android.accounts.Account account, java.lang.String providerName) throws android.os.RemoteException;
/**
     * Set whether this account/provider is syncable.
     * @param syncable, >0 denotes syncable, 0 means not syncable, <0 means unknown
     */
public void setIsSyncable(android.accounts.Account account, java.lang.String providerName, int syncable) throws android.os.RemoteException;
public void setMasterSyncAutomatically(boolean flag) throws android.os.RemoteException;
public boolean getMasterSyncAutomatically() throws android.os.RemoteException;
/**
     * Returns true if there is currently a sync operation for the given
     * account or authority in the pending list, or actively being processed.
     */
public boolean isSyncActive(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException;
public java.util.List<android.content.SyncInfo> getCurrentSyncs() throws android.os.RemoteException;
/**
     * Returns the types of the SyncAdapters that are registered with the system.
     * @return Returns the types of the SyncAdapters that are registered with the system.
     */
public android.content.SyncAdapterType[] getSyncAdapterTypes() throws android.os.RemoteException;
/**
     * Returns the status that matches the authority. If there are multiples accounts for
     * the authority, the one with the latest "lastSuccessTime" status is returned.
     * @param authority the authority whose row should be selected
     * @return the SyncStatusInfo for the authority, or null if none exists
     */
public android.content.SyncStatusInfo getSyncStatus(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException;
/**
     * Return true if the pending status is true of any matching authorities.
     */
public boolean isSyncPending(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException;
public void addStatusChangeListener(int mask, android.content.ISyncStatusObserver callback) throws android.os.RemoteException;
public void removeStatusChangeListener(android.content.ISyncStatusObserver callback) throws android.os.RemoteException;
}
