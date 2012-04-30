/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/content/ISyncAdapter.aidl
 */
package android.content;
/**
 * Interface used to control the sync activity on a SyncAdapter
 * @hide
 */
public interface ISyncAdapter extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.content.ISyncAdapter
{
private static final java.lang.String DESCRIPTOR = "android.content.ISyncAdapter";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.content.ISyncAdapter interface,
 * generating a proxy if needed.
 */
public static android.content.ISyncAdapter asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.content.ISyncAdapter))) {
return ((android.content.ISyncAdapter)iin);
}
return new android.content.ISyncAdapter.Stub.Proxy(obj);
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
case TRANSACTION_startSync:
{
data.enforceInterface(DESCRIPTOR);
android.content.ISyncContext _arg0;
_arg0 = android.content.ISyncContext.Stub.asInterface(data.readStrongBinder());
java.lang.String _arg1;
_arg1 = data.readString();
android.accounts.Account _arg2;
if ((0!=data.readInt())) {
_arg2 = android.accounts.Account.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
android.os.Bundle _arg3;
if ((0!=data.readInt())) {
_arg3 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg3 = null;
}
this.startSync(_arg0, _arg1, _arg2, _arg3);
return true;
}
case TRANSACTION_cancelSync:
{
data.enforceInterface(DESCRIPTOR);
android.content.ISyncContext _arg0;
_arg0 = android.content.ISyncContext.Stub.asInterface(data.readStrongBinder());
this.cancelSync(_arg0);
return true;
}
case TRANSACTION_initialize:
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
this.initialize(_arg0, _arg1);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.content.ISyncAdapter
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
     * Initiate a sync for this account. SyncAdapter-specific parameters may
     * be specified in extras, which is guaranteed to not be null.
     *
     * @param syncContext the ISyncContext used to indicate the progress of the sync. When
     *   the sync is finished (successfully or not) ISyncContext.onFinished() must be called.
     * @param authority the authority that should be synced
     * @param account the account that should be synced
     * @param extras SyncAdapter-specific parameters
     */
public void startSync(android.content.ISyncContext syncContext, java.lang.String authority, android.accounts.Account account, android.os.Bundle extras) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((syncContext!=null))?(syncContext.asBinder()):(null)));
_data.writeString(authority);
if ((account!=null)) {
_data.writeInt(1);
account.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((extras!=null)) {
_data.writeInt(1);
extras.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_startSync, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Cancel the most recently initiated sync. Due to race conditions, this may arrive
     * after the ISyncContext.onFinished() for that sync was called.
     * @param syncContext the ISyncContext that was passed to {@link #startSync}
     */
public void cancelSync(android.content.ISyncContext syncContext) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((syncContext!=null))?(syncContext.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_cancelSync, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Initialize the SyncAdapter for this account and authority.
     *
     * @param account the account that should be synced
     * @param authority the authority that should be synced
     */
public void initialize(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
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
mRemote.transact(Stub.TRANSACTION_initialize, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_startSync = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_cancelSync = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_initialize = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
}
/**
     * Initiate a sync for this account. SyncAdapter-specific parameters may
     * be specified in extras, which is guaranteed to not be null.
     *
     * @param syncContext the ISyncContext used to indicate the progress of the sync. When
     *   the sync is finished (successfully or not) ISyncContext.onFinished() must be called.
     * @param authority the authority that should be synced
     * @param account the account that should be synced
     * @param extras SyncAdapter-specific parameters
     */
public void startSync(android.content.ISyncContext syncContext, java.lang.String authority, android.accounts.Account account, android.os.Bundle extras) throws android.os.RemoteException;
/**
     * Cancel the most recently initiated sync. Due to race conditions, this may arrive
     * after the ISyncContext.onFinished() for that sync was called.
     * @param syncContext the ISyncContext that was passed to {@link #startSync}
     */
public void cancelSync(android.content.ISyncContext syncContext) throws android.os.RemoteException;
/**
     * Initialize the SyncAdapter for this account and authority.
     *
     * @param account the account that should be synced
     * @param authority the authority that should be synced
     */
public void initialize(android.accounts.Account account, java.lang.String authority) throws android.os.RemoteException;
}
