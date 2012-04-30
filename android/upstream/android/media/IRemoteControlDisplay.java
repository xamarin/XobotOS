/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/media/java/android/media/IRemoteControlDisplay.aidl
 */
package android.media;
/**
 * @hide
 * Interface registered through AudioManager of an object that displays information
 * received from a remote control client.
 * {@see AudioManager#registerRemoteControlDisplay(IRemoteControlDisplay)}.
 */
public interface IRemoteControlDisplay extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.media.IRemoteControlDisplay
{
private static final java.lang.String DESCRIPTOR = "android.media.IRemoteControlDisplay";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.media.IRemoteControlDisplay interface,
 * generating a proxy if needed.
 */
public static android.media.IRemoteControlDisplay asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.media.IRemoteControlDisplay))) {
return ((android.media.IRemoteControlDisplay)iin);
}
return new android.media.IRemoteControlDisplay.Stub.Proxy(obj);
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
case TRANSACTION_setCurrentClientId:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.app.PendingIntent _arg1;
if ((0!=data.readInt())) {
_arg1 = android.app.PendingIntent.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
boolean _arg2;
_arg2 = (0!=data.readInt());
this.setCurrentClientId(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_setPlaybackState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
long _arg2;
_arg2 = data.readLong();
this.setPlaybackState(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_setTransportControlFlags:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.setTransportControlFlags(_arg0, _arg1);
return true;
}
case TRANSACTION_setMetadata:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.os.Bundle _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.setMetadata(_arg0, _arg1);
return true;
}
case TRANSACTION_setArtwork:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.graphics.Bitmap _arg1;
if ((0!=data.readInt())) {
_arg1 = android.graphics.Bitmap.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.setArtwork(_arg0, _arg1);
return true;
}
case TRANSACTION_setAllMetadata:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.os.Bundle _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
android.graphics.Bitmap _arg2;
if ((0!=data.readInt())) {
_arg2 = android.graphics.Bitmap.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
this.setAllMetadata(_arg0, _arg1, _arg2);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.media.IRemoteControlDisplay
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
     * Sets the generation counter of the current client that is displayed on the remote control.
     * @param clientGeneration the new RemoteControlClient generation
     * @param clientMediaIntent the PendingIntent associated with the client.
     *    May be null, which implies there is no registered media button event receiver.
     * @param clearing true if the new client generation value maps to a remote control update
     *    where the display should be cleared.
     */
public void setCurrentClientId(int clientGeneration, android.app.PendingIntent clientMediaIntent, boolean clearing) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(clientGeneration);
if ((clientMediaIntent!=null)) {
_data.writeInt(1);
clientMediaIntent.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((clearing)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setCurrentClientId, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setPlaybackState(int generationId, int state, long stateChangeTimeMs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(generationId);
_data.writeInt(state);
_data.writeLong(stateChangeTimeMs);
mRemote.transact(Stub.TRANSACTION_setPlaybackState, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setTransportControlFlags(int generationId, int transportControlFlags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(generationId);
_data.writeInt(transportControlFlags);
mRemote.transact(Stub.TRANSACTION_setTransportControlFlags, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setMetadata(int generationId, android.os.Bundle metadata) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(generationId);
if ((metadata!=null)) {
_data.writeInt(1);
metadata.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setMetadata, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setArtwork(int generationId, android.graphics.Bitmap artwork) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(generationId);
if ((artwork!=null)) {
_data.writeInt(1);
artwork.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setArtwork, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * To combine metadata text and artwork in one binder call
     */
public void setAllMetadata(int generationId, android.os.Bundle metadata, android.graphics.Bitmap artwork) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(generationId);
if ((metadata!=null)) {
_data.writeInt(1);
metadata.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((artwork!=null)) {
_data.writeInt(1);
artwork.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setAllMetadata, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_setCurrentClientId = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_setPlaybackState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_setTransportControlFlags = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_setMetadata = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_setArtwork = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_setAllMetadata = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
}
/**
     * Sets the generation counter of the current client that is displayed on the remote control.
     * @param clientGeneration the new RemoteControlClient generation
     * @param clientMediaIntent the PendingIntent associated with the client.
     *    May be null, which implies there is no registered media button event receiver.
     * @param clearing true if the new client generation value maps to a remote control update
     *    where the display should be cleared.
     */
public void setCurrentClientId(int clientGeneration, android.app.PendingIntent clientMediaIntent, boolean clearing) throws android.os.RemoteException;
public void setPlaybackState(int generationId, int state, long stateChangeTimeMs) throws android.os.RemoteException;
public void setTransportControlFlags(int generationId, int transportControlFlags) throws android.os.RemoteException;
public void setMetadata(int generationId, android.os.Bundle metadata) throws android.os.RemoteException;
public void setArtwork(int generationId, android.graphics.Bitmap artwork) throws android.os.RemoteException;
/**
     * To combine metadata text and artwork in one binder call
     */
public void setAllMetadata(int generationId, android.os.Bundle metadata, android.graphics.Bitmap artwork) throws android.os.RemoteException;
}
