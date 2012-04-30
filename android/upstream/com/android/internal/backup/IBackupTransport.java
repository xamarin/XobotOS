/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/backup/IBackupTransport.aidl
 */
package com.android.internal.backup;
/** {@hide} */
public interface IBackupTransport extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.backup.IBackupTransport
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.backup.IBackupTransport";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.backup.IBackupTransport interface,
 * generating a proxy if needed.
 */
public static com.android.internal.backup.IBackupTransport asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.backup.IBackupTransport))) {
return ((com.android.internal.backup.IBackupTransport)iin);
}
return new com.android.internal.backup.IBackupTransport.Stub.Proxy(obj);
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
case TRANSACTION_configurationIntent:
{
data.enforceInterface(DESCRIPTOR);
android.content.Intent _result = this.configurationIntent();
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
case TRANSACTION_currentDestinationString:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _result = this.currentDestinationString();
reply.writeNoException();
reply.writeString(_result);
return true;
}
case TRANSACTION_transportDirName:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _result = this.transportDirName();
reply.writeNoException();
reply.writeString(_result);
return true;
}
case TRANSACTION_requestBackupTime:
{
data.enforceInterface(DESCRIPTOR);
long _result = this.requestBackupTime();
reply.writeNoException();
reply.writeLong(_result);
return true;
}
case TRANSACTION_initializeDevice:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.initializeDevice();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_performBackup:
{
data.enforceInterface(DESCRIPTOR);
android.content.pm.PackageInfo _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.pm.PackageInfo.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.os.ParcelFileDescriptor _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
int _result = this.performBackup(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_clearBackupData:
{
data.enforceInterface(DESCRIPTOR);
android.content.pm.PackageInfo _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.pm.PackageInfo.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.clearBackupData(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_finishBackup:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.finishBackup();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getAvailableRestoreSets:
{
data.enforceInterface(DESCRIPTOR);
android.app.backup.RestoreSet[] _result = this.getAvailableRestoreSets();
reply.writeNoException();
reply.writeTypedArray(_result, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
return true;
}
case TRANSACTION_getCurrentRestoreSet:
{
data.enforceInterface(DESCRIPTOR);
long _result = this.getCurrentRestoreSet();
reply.writeNoException();
reply.writeLong(_result);
return true;
}
case TRANSACTION_startRestore:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
android.content.pm.PackageInfo[] _arg1;
_arg1 = data.createTypedArray(android.content.pm.PackageInfo.CREATOR);
int _result = this.startRestore(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_nextRestorePackage:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _result = this.nextRestorePackage();
reply.writeNoException();
reply.writeString(_result);
return true;
}
case TRANSACTION_getRestoreData:
{
data.enforceInterface(DESCRIPTOR);
android.os.ParcelFileDescriptor _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.getRestoreData(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_finishRestore:
{
data.enforceInterface(DESCRIPTOR);
this.finishRestore();
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.backup.IBackupTransport
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
	 * Ask the transport for an Intent that can be used to launch any internal
	 * configuration Activity that it wishes to present.  For example, the transport
	 * may offer a UI for allowing the user to supply login credentials for the
	 * transport's off-device backend.
	 *
	 * If the transport does not supply any user-facing configuration UI, it should
	 * return null from this method.
	 *
	 * @return An Intent that can be passed to Context.startActivity() in order to
	 *         launch the transport's configuration UI.  This method will return null
	 *         if the transport does not offer any user-facing configuration UI.
	 */
public android.content.Intent configurationIntent() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.Intent _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_configurationIntent, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.Intent.CREATOR.createFromParcel(_reply);
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
	 * On demand, supply a one-line string that can be shown to the user that
	 * describes the current backend destination.  For example, a transport that
	 * can potentially associate backup data with arbitrary user accounts should
	 * include the name of the currently-active account here.
	 *
	 * @return A string describing the destination to which the transport is currently
	 *         sending data.  This method should not return null.
	 */
public java.lang.String currentDestinationString() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_currentDestinationString, _data, _reply, 0);
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
     * Ask the transport where, on local device storage, to keep backup state blobs.
     * This is per-transport so that mock transports used for testing can coexist with
     * "live" backup services without interfering with the live bookkeeping.  The
     * returned string should be a name that is expected to be unambiguous among all
     * available backup transports; the name of the class implementing the transport
     * is a good choice.
     *
     * @return A unique name, suitable for use as a file or directory name, that the
     *         Backup Manager could use to disambiguate state files associated with
     *         different backup transports.
     */
public java.lang.String transportDirName() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_transportDirName, _data, _reply, 0);
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
     * Verify that this is a suitable time for a backup pass.  This should return zero
     * if a backup is reasonable right now, some positive value otherwise.  This method
     * will be called outside of the {@link #startSession}/{@link #endSession} pair.
     *
     * <p>If this is not a suitable time for a backup, the transport should return a
     * backoff delay, in milliseconds, after which the Backup Manager should try again.
     *
     * @return Zero if this is a suitable time for a backup pass, or a positive time delay
     *   in milliseconds to suggest deferring the backup pass for a while.
     */
public long requestBackupTime() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
long _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_requestBackupTime, _data, _reply, 0);
_reply.readException();
_result = _reply.readLong();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Initialize the server side storage for this device, erasing all stored data.
     * The transport may send the request immediately, or may buffer it.  After
     * this is called, {@link #finishBackup} must be called to ensure the request
     * is sent and received successfully.
     *
     * @return One of {@link BackupConstants#TRANSPORT_OK} (OK so far) or
     *   {@link BackupConstants#TRANSPORT_ERROR} (on network error or other failure).
     */
public int initializeDevice() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_initializeDevice, _data, _reply, 0);
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
     * Send one application's data to the backup destination.  The transport may send
     * the data immediately, or may buffer it.  After this is called, {@link #finishBackup}
     * must be called to ensure the data is sent and recorded successfully.
     *
     * @param packageInfo The identity of the application whose data is being backed up.
     *   This specifically includes the signature list for the package.
     * @param data The data stream that resulted from invoking the application's
     *   BackupService.doBackup() method.  This may be a pipe rather than a file on
     *   persistent media, so it may not be seekable.
     * @param wipeAllFirst When true, <i>all</i> backed-up data for the current device/account
     *   will be erased prior to the storage of the data provided here.  The purpose of this
     *   is to provide a guarantee that no stale data exists in the restore set when the
     *   device begins providing backups.
     * @return one of {@link BackupConstants#TRANSPORT_OK} (OK so far),
     *  {@link BackupConstants#TRANSPORT_ERROR} (on network error or other failure), or
     *  {@link BackupConstants#TRANSPORT_NOT_INITIALIZED} (if the backend dataset has
     *  become lost due to inactive expiry or some other reason and needs re-initializing)
     */
public int performBackup(android.content.pm.PackageInfo packageInfo, android.os.ParcelFileDescriptor inFd) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((packageInfo!=null)) {
_data.writeInt(1);
packageInfo.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((inFd!=null)) {
_data.writeInt(1);
inFd.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_performBackup, _data, _reply, 0);
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
     * Erase the give application's data from the backup destination.  This clears
     * out the given package's data from the current backup set, making it as though
     * the app had never yet been backed up.  After this is called, {@link finishBackup}
     * must be called to ensure that the operation is recorded successfully.
     *
     * @return the same error codes as {@link #performBackup}.
     */
public int clearBackupData(android.content.pm.PackageInfo packageInfo) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((packageInfo!=null)) {
_data.writeInt(1);
packageInfo.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_clearBackupData, _data, _reply, 0);
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
     * Finish sending application data to the backup destination.  This must be
     * called after {@link #performBackup} or {@link clearBackupData} to ensure that
     * all data is sent.  Only when this method returns true can a backup be assumed
     * to have succeeded.
     *
     * @return the same error codes as {@link #performBackup}.
     */
public int finishBackup() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_finishBackup, _data, _reply, 0);
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
     * Get the set of all backups currently available over this transport.
     *
     * @return Descriptions of the set of restore images available for this device,
     *   or null if an error occurred (the attempt should be rescheduled).
     */
public android.app.backup.RestoreSet[] getAvailableRestoreSets() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.app.backup.RestoreSet[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getAvailableRestoreSets, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArray(android.app.backup.RestoreSet.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Get the identifying token of the backup set currently being stored from
     * this device.  This is used in the case of applications wishing to restore
     * their last-known-good data.
     *
     * @return A token that can be passed to {@link #startRestore}, or 0 if there
     *   is no backup set available corresponding to the current device state.
     */
public long getCurrentRestoreSet() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
long _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getCurrentRestoreSet, _data, _reply, 0);
_reply.readException();
_result = _reply.readLong();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Start restoring application data from backup.  After calling this function,
     * alternate calls to {@link #nextRestorePackage} and {@link #nextRestoreData}
     * to walk through the actual application data.
     *
     * @param token A backup token as returned by {@link #getAvailableRestoreSets}
     *   or {@link #getCurrentRestoreSet}.
     * @param packages List of applications to restore (if data is available).
     *   Application data will be restored in the order given.
     * @return One of {@link BackupConstants#TRANSPORT_OK} (OK so far, call
     *   {@link #nextRestorePackage}) or {@link BackupConstants#TRANSPORT_ERROR}
     *   (an error occurred, the restore should be aborted and rescheduled).
     */
public int startRestore(long token, android.content.pm.PackageInfo[] packages) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(token);
_data.writeTypedArray(packages, 0);
mRemote.transact(Stub.TRANSACTION_startRestore, _data, _reply, 0);
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
     * Get the package name of the next application with data in the backup store.
     * @return The name of one of the packages supplied to {@link #startRestore},
     *   or "" (the empty string) if no more backup data is available,
     *   or null if an error occurred (the restore should be aborted and rescheduled).
     */
public java.lang.String nextRestorePackage() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_nextRestorePackage, _data, _reply, 0);
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
     * Get the data for the application returned by {@link #nextRestorePackage}.
     * @param data An open, writable file into which the backup data should be stored.
     * @return the same error codes as {@link #nextRestorePackage}.
     */
public int getRestoreData(android.os.ParcelFileDescriptor outFd) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((outFd!=null)) {
_data.writeInt(1);
outFd.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_getRestoreData, _data, _reply, 0);
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
     * End a restore session (aborting any in-process data transfer as necessary),
     * freeing any resources and connections used during the restore process.
     */
public void finishRestore() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_finishRestore, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_configurationIntent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_currentDestinationString = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_transportDirName = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_requestBackupTime = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_initializeDevice = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_performBackup = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_clearBackupData = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_finishBackup = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_getAvailableRestoreSets = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_getCurrentRestoreSet = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_startRestore = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_nextRestorePackage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_getRestoreData = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_finishRestore = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
}
/**
	 * Ask the transport for an Intent that can be used to launch any internal
	 * configuration Activity that it wishes to present.  For example, the transport
	 * may offer a UI for allowing the user to supply login credentials for the
	 * transport's off-device backend.
	 *
	 * If the transport does not supply any user-facing configuration UI, it should
	 * return null from this method.
	 *
	 * @return An Intent that can be passed to Context.startActivity() in order to
	 *         launch the transport's configuration UI.  This method will return null
	 *         if the transport does not offer any user-facing configuration UI.
	 */
public android.content.Intent configurationIntent() throws android.os.RemoteException;
/**
	 * On demand, supply a one-line string that can be shown to the user that
	 * describes the current backend destination.  For example, a transport that
	 * can potentially associate backup data with arbitrary user accounts should
	 * include the name of the currently-active account here.
	 *
	 * @return A string describing the destination to which the transport is currently
	 *         sending data.  This method should not return null.
	 */
public java.lang.String currentDestinationString() throws android.os.RemoteException;
/**
     * Ask the transport where, on local device storage, to keep backup state blobs.
     * This is per-transport so that mock transports used for testing can coexist with
     * "live" backup services without interfering with the live bookkeeping.  The
     * returned string should be a name that is expected to be unambiguous among all
     * available backup transports; the name of the class implementing the transport
     * is a good choice.
     *
     * @return A unique name, suitable for use as a file or directory name, that the
     *         Backup Manager could use to disambiguate state files associated with
     *         different backup transports.
     */
public java.lang.String transportDirName() throws android.os.RemoteException;
/**
     * Verify that this is a suitable time for a backup pass.  This should return zero
     * if a backup is reasonable right now, some positive value otherwise.  This method
     * will be called outside of the {@link #startSession}/{@link #endSession} pair.
     *
     * <p>If this is not a suitable time for a backup, the transport should return a
     * backoff delay, in milliseconds, after which the Backup Manager should try again.
     *
     * @return Zero if this is a suitable time for a backup pass, or a positive time delay
     *   in milliseconds to suggest deferring the backup pass for a while.
     */
public long requestBackupTime() throws android.os.RemoteException;
/**
     * Initialize the server side storage for this device, erasing all stored data.
     * The transport may send the request immediately, or may buffer it.  After
     * this is called, {@link #finishBackup} must be called to ensure the request
     * is sent and received successfully.
     *
     * @return One of {@link BackupConstants#TRANSPORT_OK} (OK so far) or
     *   {@link BackupConstants#TRANSPORT_ERROR} (on network error or other failure).
     */
public int initializeDevice() throws android.os.RemoteException;
/**
     * Send one application's data to the backup destination.  The transport may send
     * the data immediately, or may buffer it.  After this is called, {@link #finishBackup}
     * must be called to ensure the data is sent and recorded successfully.
     *
     * @param packageInfo The identity of the application whose data is being backed up.
     *   This specifically includes the signature list for the package.
     * @param data The data stream that resulted from invoking the application's
     *   BackupService.doBackup() method.  This may be a pipe rather than a file on
     *   persistent media, so it may not be seekable.
     * @param wipeAllFirst When true, <i>all</i> backed-up data for the current device/account
     *   will be erased prior to the storage of the data provided here.  The purpose of this
     *   is to provide a guarantee that no stale data exists in the restore set when the
     *   device begins providing backups.
     * @return one of {@link BackupConstants#TRANSPORT_OK} (OK so far),
     *  {@link BackupConstants#TRANSPORT_ERROR} (on network error or other failure), or
     *  {@link BackupConstants#TRANSPORT_NOT_INITIALIZED} (if the backend dataset has
     *  become lost due to inactive expiry or some other reason and needs re-initializing)
     */
public int performBackup(android.content.pm.PackageInfo packageInfo, android.os.ParcelFileDescriptor inFd) throws android.os.RemoteException;
/**
     * Erase the give application's data from the backup destination.  This clears
     * out the given package's data from the current backup set, making it as though
     * the app had never yet been backed up.  After this is called, {@link finishBackup}
     * must be called to ensure that the operation is recorded successfully.
     *
     * @return the same error codes as {@link #performBackup}.
     */
public int clearBackupData(android.content.pm.PackageInfo packageInfo) throws android.os.RemoteException;
/**
     * Finish sending application data to the backup destination.  This must be
     * called after {@link #performBackup} or {@link clearBackupData} to ensure that
     * all data is sent.  Only when this method returns true can a backup be assumed
     * to have succeeded.
     *
     * @return the same error codes as {@link #performBackup}.
     */
public int finishBackup() throws android.os.RemoteException;
/**
     * Get the set of all backups currently available over this transport.
     *
     * @return Descriptions of the set of restore images available for this device,
     *   or null if an error occurred (the attempt should be rescheduled).
     */
public android.app.backup.RestoreSet[] getAvailableRestoreSets() throws android.os.RemoteException;
/**
     * Get the identifying token of the backup set currently being stored from
     * this device.  This is used in the case of applications wishing to restore
     * their last-known-good data.
     *
     * @return A token that can be passed to {@link #startRestore}, or 0 if there
     *   is no backup set available corresponding to the current device state.
     */
public long getCurrentRestoreSet() throws android.os.RemoteException;
/**
     * Start restoring application data from backup.  After calling this function,
     * alternate calls to {@link #nextRestorePackage} and {@link #nextRestoreData}
     * to walk through the actual application data.
     *
     * @param token A backup token as returned by {@link #getAvailableRestoreSets}
     *   or {@link #getCurrentRestoreSet}.
     * @param packages List of applications to restore (if data is available).
     *   Application data will be restored in the order given.
     * @return One of {@link BackupConstants#TRANSPORT_OK} (OK so far, call
     *   {@link #nextRestorePackage}) or {@link BackupConstants#TRANSPORT_ERROR}
     *   (an error occurred, the restore should be aborted and rescheduled).
     */
public int startRestore(long token, android.content.pm.PackageInfo[] packages) throws android.os.RemoteException;
/**
     * Get the package name of the next application with data in the backup store.
     * @return The name of one of the packages supplied to {@link #startRestore},
     *   or "" (the empty string) if no more backup data is available,
     *   or null if an error occurred (the restore should be aborted and rescheduled).
     */
public java.lang.String nextRestorePackage() throws android.os.RemoteException;
/**
     * Get the data for the application returned by {@link #nextRestorePackage}.
     * @param data An open, writable file into which the backup data should be stored.
     * @return the same error codes as {@link #nextRestorePackage}.
     */
public int getRestoreData(android.os.ParcelFileDescriptor outFd) throws android.os.RemoteException;
/**
     * End a restore session (aborting any in-process data transfer as necessary),
     * freeing any resources and connections used during the restore process.
     */
public void finishRestore() throws android.os.RemoteException;
}
