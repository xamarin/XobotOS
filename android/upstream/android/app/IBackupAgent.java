/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/app/IBackupAgent.aidl
 */
package android.app;
/**
 * Interface presented by applications being asked to participate in the
 * backup & restore mechanism.  End user code will not typically implement
 * this interface directly; they subclass BackupAgent instead.
 *
 * {@hide}
 */
public interface IBackupAgent extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.app.IBackupAgent
{
private static final java.lang.String DESCRIPTOR = "android.app.IBackupAgent";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.app.IBackupAgent interface,
 * generating a proxy if needed.
 */
public static android.app.IBackupAgent asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.app.IBackupAgent))) {
return ((android.app.IBackupAgent)iin);
}
return new android.app.IBackupAgent.Stub.Proxy(obj);
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
case TRANSACTION_doBackup:
{
data.enforceInterface(DESCRIPTOR);
android.os.ParcelFileDescriptor _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
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
android.os.ParcelFileDescriptor _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
int _arg3;
_arg3 = data.readInt();
android.app.backup.IBackupManager _arg4;
_arg4 = android.app.backup.IBackupManager.Stub.asInterface(data.readStrongBinder());
this.doBackup(_arg0, _arg1, _arg2, _arg3, _arg4);
return true;
}
case TRANSACTION_doRestore:
{
data.enforceInterface(DESCRIPTOR);
android.os.ParcelFileDescriptor _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
android.os.ParcelFileDescriptor _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
int _arg3;
_arg3 = data.readInt();
android.app.backup.IBackupManager _arg4;
_arg4 = android.app.backup.IBackupManager.Stub.asInterface(data.readStrongBinder());
this.doRestore(_arg0, _arg1, _arg2, _arg3, _arg4);
return true;
}
case TRANSACTION_doFullBackup:
{
data.enforceInterface(DESCRIPTOR);
android.os.ParcelFileDescriptor _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
android.app.backup.IBackupManager _arg2;
_arg2 = android.app.backup.IBackupManager.Stub.asInterface(data.readStrongBinder());
this.doFullBackup(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_doRestoreFile:
{
data.enforceInterface(DESCRIPTOR);
android.os.ParcelFileDescriptor _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _arg1;
_arg1 = data.readLong();
int _arg2;
_arg2 = data.readInt();
java.lang.String _arg3;
_arg3 = data.readString();
java.lang.String _arg4;
_arg4 = data.readString();
long _arg5;
_arg5 = data.readLong();
long _arg6;
_arg6 = data.readLong();
int _arg7;
_arg7 = data.readInt();
android.app.backup.IBackupManager _arg8;
_arg8 = android.app.backup.IBackupManager.Stub.asInterface(data.readStrongBinder());
this.doRestoreFile(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.app.IBackupAgent
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
     * Request that the app perform an incremental backup.
     *
     * @param oldState Read-only file containing the description blob of the
     *        app's data state as of the last backup operation's completion.
     *        This file is empty or invalid when a full backup is being
     *        requested.
     *
     * @param data Read-write file, empty when onBackup() is called, that
     *        is the data destination for this backup pass's incrementals.
     *
     * @param newState Read-write file, empty when onBackup() is called,
     *        where the new state blob is to be recorded.
     *
     * @param token Opaque token identifying this transaction.  This must
     *        be echoed back to the backup service binder once the new
     *        data has been written to the data and newState files.
     *
     * @param callbackBinder Binder on which to indicate operation completion,
     *        passed here as a convenience to the agent.
     */
public void doBackup(android.os.ParcelFileDescriptor oldState, android.os.ParcelFileDescriptor data, android.os.ParcelFileDescriptor newState, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((oldState!=null)) {
_data.writeInt(1);
oldState.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((data!=null)) {
_data.writeInt(1);
data.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((newState!=null)) {
_data.writeInt(1);
newState.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(token);
_data.writeStrongBinder((((callbackBinder!=null))?(callbackBinder.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_doBackup, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Restore an entire data snapshot to the application.
     *
     * @param data Read-only file containing the full data snapshot of the
     *        app's backup.  This is to be a <i>replacement</i> of the app's
     *        current data, not to be merged into it.
     *
     * @param appVersionCode The android:versionCode attribute of the application
     *        that created this data set.  This can help the agent distinguish among
     *        various historical backup content possibilities.
     *
     * @param newState Read-write file, empty when onRestore() is called,
     *        that is to be written with the state description that holds after
     *        the restore has been completed.
     *
     * @param token Opaque token identifying this transaction.  This must
     *        be echoed back to the backup service binder once the agent is
     *        finished restoring the application based on the restore data
     *        contents.
     *
     * @param callbackBinder Binder on which to indicate operation completion,
     *        passed here as a convenience to the agent.
     */
public void doRestore(android.os.ParcelFileDescriptor data, int appVersionCode, android.os.ParcelFileDescriptor newState, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((data!=null)) {
_data.writeInt(1);
data.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(appVersionCode);
if ((newState!=null)) {
_data.writeInt(1);
newState.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(token);
_data.writeStrongBinder((((callbackBinder!=null))?(callbackBinder.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_doRestore, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Perform a "full" backup to the given file descriptor.  The output file is presumed
     * to be a socket or other non-seekable, write-only data sink.  When this method is
     * called, the app should write all of its files to the output.
     *
     * @param data Write-only file to receive the backed-up file content stream.
     *        The data must be formatted correctly for the resulting archive to be
     *        legitimate, so that will be tightly controlled by the available API.
     *
     * @param token Opaque token identifying this transaction.  This must
     *        be echoed back to the backup service binder once the agent is
     *        finished restoring the application based on the restore data
     *        contents.
     *
     * @param callbackBinder Binder on which to indicate operation completion,
     *        passed here as a convenience to the agent.
     */
public void doFullBackup(android.os.ParcelFileDescriptor data, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((data!=null)) {
_data.writeInt(1);
data.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(token);
_data.writeStrongBinder((((callbackBinder!=null))?(callbackBinder.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_doFullBackup, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Restore a single "file" to the application.  The file was typically obtained from
     * a full-backup dataset.  The agent reads 'size' bytes of file content
     * from the provided file descriptor.
     *
     * @param data Read-only pipe delivering the file content itself.
     *
     * @param size Size of the file being restored.
     * @param type Type of file system entity, e.g. FullBackup.TYPE_DIRECTORY.
     * @param domain Name of the file's semantic domain to which the 'path' argument is a
     *        relative path.  e.g. FullBackup.DATABASE_TREE_TOKEN.
     * @param path Relative path of the file within its semantic domain.
     * @param mode Access mode of the file system entity, e.g. 0660.
     * @param mtime Last modification time of the file system entity.
     */
public void doRestoreFile(android.os.ParcelFileDescriptor data, long size, int type, java.lang.String domain, java.lang.String path, long mode, long mtime, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((data!=null)) {
_data.writeInt(1);
data.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeLong(size);
_data.writeInt(type);
_data.writeString(domain);
_data.writeString(path);
_data.writeLong(mode);
_data.writeLong(mtime);
_data.writeInt(token);
_data.writeStrongBinder((((callbackBinder!=null))?(callbackBinder.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_doRestoreFile, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_doBackup = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_doRestore = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_doFullBackup = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_doRestoreFile = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
}
/**
     * Request that the app perform an incremental backup.
     *
     * @param oldState Read-only file containing the description blob of the
     *        app's data state as of the last backup operation's completion.
     *        This file is empty or invalid when a full backup is being
     *        requested.
     *
     * @param data Read-write file, empty when onBackup() is called, that
     *        is the data destination for this backup pass's incrementals.
     *
     * @param newState Read-write file, empty when onBackup() is called,
     *        where the new state blob is to be recorded.
     *
     * @param token Opaque token identifying this transaction.  This must
     *        be echoed back to the backup service binder once the new
     *        data has been written to the data and newState files.
     *
     * @param callbackBinder Binder on which to indicate operation completion,
     *        passed here as a convenience to the agent.
     */
public void doBackup(android.os.ParcelFileDescriptor oldState, android.os.ParcelFileDescriptor data, android.os.ParcelFileDescriptor newState, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException;
/**
     * Restore an entire data snapshot to the application.
     *
     * @param data Read-only file containing the full data snapshot of the
     *        app's backup.  This is to be a <i>replacement</i> of the app's
     *        current data, not to be merged into it.
     *
     * @param appVersionCode The android:versionCode attribute of the application
     *        that created this data set.  This can help the agent distinguish among
     *        various historical backup content possibilities.
     *
     * @param newState Read-write file, empty when onRestore() is called,
     *        that is to be written with the state description that holds after
     *        the restore has been completed.
     *
     * @param token Opaque token identifying this transaction.  This must
     *        be echoed back to the backup service binder once the agent is
     *        finished restoring the application based on the restore data
     *        contents.
     *
     * @param callbackBinder Binder on which to indicate operation completion,
     *        passed here as a convenience to the agent.
     */
public void doRestore(android.os.ParcelFileDescriptor data, int appVersionCode, android.os.ParcelFileDescriptor newState, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException;
/**
     * Perform a "full" backup to the given file descriptor.  The output file is presumed
     * to be a socket or other non-seekable, write-only data sink.  When this method is
     * called, the app should write all of its files to the output.
     *
     * @param data Write-only file to receive the backed-up file content stream.
     *        The data must be formatted correctly for the resulting archive to be
     *        legitimate, so that will be tightly controlled by the available API.
     *
     * @param token Opaque token identifying this transaction.  This must
     *        be echoed back to the backup service binder once the agent is
     *        finished restoring the application based on the restore data
     *        contents.
     *
     * @param callbackBinder Binder on which to indicate operation completion,
     *        passed here as a convenience to the agent.
     */
public void doFullBackup(android.os.ParcelFileDescriptor data, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException;
/**
     * Restore a single "file" to the application.  The file was typically obtained from
     * a full-backup dataset.  The agent reads 'size' bytes of file content
     * from the provided file descriptor.
     *
     * @param data Read-only pipe delivering the file content itself.
     *
     * @param size Size of the file being restored.
     * @param type Type of file system entity, e.g. FullBackup.TYPE_DIRECTORY.
     * @param domain Name of the file's semantic domain to which the 'path' argument is a
     *        relative path.  e.g. FullBackup.DATABASE_TREE_TOKEN.
     * @param path Relative path of the file within its semantic domain.
     * @param mode Access mode of the file system entity, e.g. 0660.
     * @param mtime Last modification time of the file system entity.
     */
public void doRestoreFile(android.os.ParcelFileDescriptor data, long size, int type, java.lang.String domain, java.lang.String path, long mode, long mtime, int token, android.app.backup.IBackupManager callbackBinder) throws android.os.RemoteException;
}
