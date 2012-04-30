/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/media/java/android/media/IRemoteControlClient.aidl
 */
package android.media;
/**
 * @hide
 * Interface registered by AudioManager to notify a source of remote control information
 * that information is requested to be displayed on the remote control (through
 * IRemoteControlDisplay).
 * {@see AudioManager#registerRemoteControlClient(RemoteControlClient)}.
 */
public interface IRemoteControlClient extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.media.IRemoteControlClient
{
private static final java.lang.String DESCRIPTOR = "android.media.IRemoteControlClient";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.media.IRemoteControlClient interface,
 * generating a proxy if needed.
 */
public static android.media.IRemoteControlClient asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.media.IRemoteControlClient))) {
return ((android.media.IRemoteControlClient)iin);
}
return new android.media.IRemoteControlClient.Stub.Proxy(obj);
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
case TRANSACTION_onInformationRequested:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
this.onInformationRequested(_arg0, _arg1, _arg2, _arg3);
return true;
}
case TRANSACTION_setCurrentClientGenerationId:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.setCurrentClientGenerationId(_arg0);
return true;
}
case TRANSACTION_plugRemoteControlDisplay:
{
data.enforceInterface(DESCRIPTOR);
android.media.IRemoteControlDisplay _arg0;
_arg0 = android.media.IRemoteControlDisplay.Stub.asInterface(data.readStrongBinder());
this.plugRemoteControlDisplay(_arg0);
return true;
}
case TRANSACTION_unplugRemoteControlDisplay:
{
data.enforceInterface(DESCRIPTOR);
android.media.IRemoteControlDisplay _arg0;
_arg0 = android.media.IRemoteControlDisplay.Stub.asInterface(data.readStrongBinder());
this.unplugRemoteControlDisplay(_arg0);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.media.IRemoteControlClient
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
     * Notifies a remote control client that information for the given generation ID is
     * requested. If the flags contains
     * {@link RemoteControlClient#FLAG_INFORMATION_REQUESTED_ALBUM_ART} then the width and height
     *   parameters are valid.
     * @param generationId
     * @param infoFlags
     * @param artWidth if > 0, artHeight must be > 0 too.
     * @param artHeight
     * FIXME: is infoFlags required? since the RCC pushes info, this might always be called
     *        with RC_INFO_ALL
     */
public void onInformationRequested(int generationId, int infoFlags, int artWidth, int artHeight) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(generationId);
_data.writeInt(infoFlags);
_data.writeInt(artWidth);
_data.writeInt(artHeight);
mRemote.transact(Stub.TRANSACTION_onInformationRequested, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Sets the generation counter of the current client that is displayed on the remote control.
     */
public void setCurrentClientGenerationId(int clientGeneration) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(clientGeneration);
mRemote.transact(Stub.TRANSACTION_setCurrentClientGenerationId, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void plugRemoteControlDisplay(android.media.IRemoteControlDisplay rcd) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((rcd!=null))?(rcd.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_plugRemoteControlDisplay, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void unplugRemoteControlDisplay(android.media.IRemoteControlDisplay rcd) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((rcd!=null))?(rcd.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_unplugRemoteControlDisplay, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_onInformationRequested = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_setCurrentClientGenerationId = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_plugRemoteControlDisplay = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_unplugRemoteControlDisplay = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
}
/**
     * Notifies a remote control client that information for the given generation ID is
     * requested. If the flags contains
     * {@link RemoteControlClient#FLAG_INFORMATION_REQUESTED_ALBUM_ART} then the width and height
     *   parameters are valid.
     * @param generationId
     * @param infoFlags
     * @param artWidth if > 0, artHeight must be > 0 too.
     * @param artHeight
     * FIXME: is infoFlags required? since the RCC pushes info, this might always be called
     *        with RC_INFO_ALL
     */
public void onInformationRequested(int generationId, int infoFlags, int artWidth, int artHeight) throws android.os.RemoteException;
/**
     * Sets the generation counter of the current client that is displayed on the remote control.
     */
public void setCurrentClientGenerationId(int clientGeneration) throws android.os.RemoteException;
public void plugRemoteControlDisplay(android.media.IRemoteControlDisplay rcd) throws android.os.RemoteException;
public void unplugRemoteControlDisplay(android.media.IRemoteControlDisplay rcd) throws android.os.RemoteException;
}
