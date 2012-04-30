/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/app/backup/IRestoreSession.aidl
 */
package android.app.backup;
/**
 * Binder interface used by clients who wish to manage a restore operation.  Every
 * method in this interface requires the android.permission.BACKUP permission.
 *
 * {@hide}
 */
public interface IRestoreSession extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.app.backup.IRestoreSession
{
private static final java.lang.String DESCRIPTOR = "android.app.backup.IRestoreSession";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.app.backup.IRestoreSession interface,
 * generating a proxy if needed.
 */
public static android.app.backup.IRestoreSession asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.app.backup.IRestoreSession))) {
return ((android.app.backup.IRestoreSession)iin);
}
return new android.app.backup.IRestoreSession.Stub.Proxy(obj);
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
case TRANSACTION_getAvailableRestoreSets:
{
data.enforceInterface(DESCRIPTOR);
android.app.backup.IRestoreObserver _arg0;
_arg0 = android.app.backup.IRestoreObserver.Stub.asInterface(data.readStrongBinder());
int _result = this.getAvailableRestoreSets(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_restoreAll:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
android.app.backup.IRestoreObserver _arg1;
_arg1 = android.app.backup.IRestoreObserver.Stub.asInterface(data.readStrongBinder());
int _result = this.restoreAll(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_restoreSome:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
android.app.backup.IRestoreObserver _arg1;
_arg1 = android.app.backup.IRestoreObserver.Stub.asInterface(data.readStrongBinder());
java.lang.String[] _arg2;
_arg2 = data.createStringArray();
int _result = this.restoreSome(_arg0, _arg1, _arg2);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_restorePackage:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.app.backup.IRestoreObserver _arg1;
_arg1 = android.app.backup.IRestoreObserver.Stub.asInterface(data.readStrongBinder());
int _result = this.restorePackage(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_endRestoreSession:
{
data.enforceInterface(DESCRIPTOR);
this.endRestoreSession();
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.app.backup.IRestoreSession
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
     * Ask the current transport what the available restore sets are.
     *
     * @param observer This binder points to an object whose onRestoreSetsAvailable()
     *   method will be called to supply the results of the transport's lookup.
     * @return Zero on success; nonzero on error.  The observer will only receive a
     *   result callback if this method returned zero.
     */
public int getAvailableRestoreSets(android.app.backup.IRestoreObserver observer) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((observer!=null))?(observer.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getAvailableRestoreSets, _data, _reply, 0);
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
     * Restore the given set onto the device, replacing the current data of any app
     * contained in the restore set with the data previously backed up.
     *
     * <p>Callers must hold the android.permission.BACKUP permission to use this method.
     *
     * @return Zero on success; nonzero on error.  The observer will only receive
     *   progress callbacks if this method returned zero.
     * @param token The token from {@link getAvailableRestoreSets()} corresponding to
     *   the restore set that should be used.
     * @param observer If non-null, this binder points to an object that will receive
     *   progress callbacks during the restore operation.
     */
public int restoreAll(long token, android.app.backup.IRestoreObserver observer) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(token);
_data.writeStrongBinder((((observer!=null))?(observer.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_restoreAll, _data, _reply, 0);
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
     * Restore select packages from the given set onto the device, replacing the
     * current data of any app contained in the set with the data previously
     * backed up.
     *
     * <p>Callers must hold the android.permission.BACKUP permission to use this method.
     *
     * @return Zero on success, nonzero on error. The observer will only receive
     *   progress callbacks if this method returned zero.
     * @param token The token from {@link getAvailableRestoreSets()} corresponding to
     *   the restore set that should be used.
     * @param observer If non-null, this binder points to an object that will receive
     *   progress callbacks during the restore operation.
     * @param packages The set of packages for which to attempt a restore.  Regardless of
     *   the contents of the actual back-end dataset named by {@code token}, only
     *   applications mentioned in this list will have their data restored.
     */
public int restoreSome(long token, android.app.backup.IRestoreObserver observer, java.lang.String[] packages) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(token);
_data.writeStrongBinder((((observer!=null))?(observer.asBinder()):(null)));
_data.writeStringArray(packages);
mRemote.transact(Stub.TRANSACTION_restoreSome, _data, _reply, 0);
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
     * Restore a single application from backup.  The data will be restored from the
     * current backup dataset if the given package has stored data there, or from
     * the dataset used during the last full device setup operation if the current
     * backup dataset has no matching data.  If no backup data exists for this package
     * in either source, a nonzero value will be returned.
     *
     * @return Zero on success; nonzero on error.  The observer will only receive
     *   progress callbacks if this method returned zero.
     * @param packageName The name of the package whose data to restore.  If this is
     *   not the name of the caller's own package, then the android.permission.BACKUP
     *   permission must be held.
     * @param observer If non-null, this binder points to an object that will receive
     *   progress callbacks during the restore operation.
     */
public int restorePackage(java.lang.String packageName, android.app.backup.IRestoreObserver observer) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(packageName);
_data.writeStrongBinder((((observer!=null))?(observer.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_restorePackage, _data, _reply, 0);
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
     * End this restore session.  After this method is called, the IRestoreSession binder
     * is no longer valid.
     *
     * <p><b>Note:</b> The caller <i>must</i> invoke this method to end the restore session,
     *   even if {@link getAvailableRestoreSets} or {@link performRestore} failed.
     */
public void endRestoreSession() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_endRestoreSession, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_getAvailableRestoreSets = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_restoreAll = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_restoreSome = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_restorePackage = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_endRestoreSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
}
/**
     * Ask the current transport what the available restore sets are.
     *
     * @param observer This binder points to an object whose onRestoreSetsAvailable()
     *   method will be called to supply the results of the transport's lookup.
     * @return Zero on success; nonzero on error.  The observer will only receive a
     *   result callback if this method returned zero.
     */
public int getAvailableRestoreSets(android.app.backup.IRestoreObserver observer) throws android.os.RemoteException;
/**
     * Restore the given set onto the device, replacing the current data of any app
     * contained in the restore set with the data previously backed up.
     *
     * <p>Callers must hold the android.permission.BACKUP permission to use this method.
     *
     * @return Zero on success; nonzero on error.  The observer will only receive
     *   progress callbacks if this method returned zero.
     * @param token The token from {@link getAvailableRestoreSets()} corresponding to
     *   the restore set that should be used.
     * @param observer If non-null, this binder points to an object that will receive
     *   progress callbacks during the restore operation.
     */
public int restoreAll(long token, android.app.backup.IRestoreObserver observer) throws android.os.RemoteException;
/**
     * Restore select packages from the given set onto the device, replacing the
     * current data of any app contained in the set with the data previously
     * backed up.
     *
     * <p>Callers must hold the android.permission.BACKUP permission to use this method.
     *
     * @return Zero on success, nonzero on error. The observer will only receive
     *   progress callbacks if this method returned zero.
     * @param token The token from {@link getAvailableRestoreSets()} corresponding to
     *   the restore set that should be used.
     * @param observer If non-null, this binder points to an object that will receive
     *   progress callbacks during the restore operation.
     * @param packages The set of packages for which to attempt a restore.  Regardless of
     *   the contents of the actual back-end dataset named by {@code token}, only
     *   applications mentioned in this list will have their data restored.
     */
public int restoreSome(long token, android.app.backup.IRestoreObserver observer, java.lang.String[] packages) throws android.os.RemoteException;
/**
     * Restore a single application from backup.  The data will be restored from the
     * current backup dataset if the given package has stored data there, or from
     * the dataset used during the last full device setup operation if the current
     * backup dataset has no matching data.  If no backup data exists for this package
     * in either source, a nonzero value will be returned.
     *
     * @return Zero on success; nonzero on error.  The observer will only receive
     *   progress callbacks if this method returned zero.
     * @param packageName The name of the package whose data to restore.  If this is
     *   not the name of the caller's own package, then the android.permission.BACKUP
     *   permission must be held.
     * @param observer If non-null, this binder points to an object that will receive
     *   progress callbacks during the restore operation.
     */
public int restorePackage(java.lang.String packageName, android.app.backup.IRestoreObserver observer) throws android.os.RemoteException;
/**
     * End this restore session.  After this method is called, the IRestoreSession binder
     * is no longer valid.
     *
     * <p><b>Note:</b> The caller <i>must</i> invoke this method to end the restore session,
     *   even if {@link getAvailableRestoreSets} or {@link performRestore} failed.
     */
public void endRestoreSession() throws android.os.RemoteException;
}
