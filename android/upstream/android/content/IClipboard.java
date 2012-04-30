/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/content/IClipboard.aidl
 */
package android.content;
/**
 * Programming interface to the clipboard, which allows copying and pasting
 * between applications.
 * {@hide}
 */
public interface IClipboard extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.content.IClipboard
{
private static final java.lang.String DESCRIPTOR = "android.content.IClipboard";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.content.IClipboard interface,
 * generating a proxy if needed.
 */
public static android.content.IClipboard asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.content.IClipboard))) {
return ((android.content.IClipboard)iin);
}
return new android.content.IClipboard.Stub.Proxy(obj);
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
case TRANSACTION_setPrimaryClip:
{
data.enforceInterface(DESCRIPTOR);
android.content.ClipData _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ClipData.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.setPrimaryClip(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getPrimaryClip:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.content.ClipData _result = this.getPrimaryClip(_arg0);
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
case TRANSACTION_getPrimaryClipDescription:
{
data.enforceInterface(DESCRIPTOR);
android.content.ClipDescription _result = this.getPrimaryClipDescription();
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
case TRANSACTION_hasPrimaryClip:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.hasPrimaryClip();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_addPrimaryClipChangedListener:
{
data.enforceInterface(DESCRIPTOR);
android.content.IOnPrimaryClipChangedListener _arg0;
_arg0 = android.content.IOnPrimaryClipChangedListener.Stub.asInterface(data.readStrongBinder());
this.addPrimaryClipChangedListener(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_removePrimaryClipChangedListener:
{
data.enforceInterface(DESCRIPTOR);
android.content.IOnPrimaryClipChangedListener _arg0;
_arg0 = android.content.IOnPrimaryClipChangedListener.Stub.asInterface(data.readStrongBinder());
this.removePrimaryClipChangedListener(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_hasClipboardText:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.hasClipboardText();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.content.IClipboard
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
public void setPrimaryClip(android.content.ClipData clip) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((clip!=null)) {
_data.writeInt(1);
clip.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setPrimaryClip, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public android.content.ClipData getPrimaryClip(java.lang.String pkg) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.ClipData _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(pkg);
mRemote.transact(Stub.TRANSACTION_getPrimaryClip, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.ClipData.CREATOR.createFromParcel(_reply);
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
public android.content.ClipDescription getPrimaryClipDescription() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.ClipDescription _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getPrimaryClipDescription, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.ClipDescription.CREATOR.createFromParcel(_reply);
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
public boolean hasPrimaryClip() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_hasPrimaryClip, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void addPrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_addPrimaryClipChangedListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removePrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_removePrimaryClipChangedListener, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Returns true if the clipboard contains text; false otherwise.
     */
public boolean hasClipboardText() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_hasClipboardText, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_setPrimaryClip = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getPrimaryClip = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getPrimaryClipDescription = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_hasPrimaryClip = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_addPrimaryClipChangedListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_removePrimaryClipChangedListener = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_hasClipboardText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
}
public void setPrimaryClip(android.content.ClipData clip) throws android.os.RemoteException;
public android.content.ClipData getPrimaryClip(java.lang.String pkg) throws android.os.RemoteException;
public android.content.ClipDescription getPrimaryClipDescription() throws android.os.RemoteException;
public boolean hasPrimaryClip() throws android.os.RemoteException;
public void addPrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener listener) throws android.os.RemoteException;
public void removePrimaryClipChangedListener(android.content.IOnPrimaryClipChangedListener listener) throws android.os.RemoteException;
/**
     * Returns true if the clipboard contains text; false otherwise.
     */
public boolean hasClipboardText() throws android.os.RemoteException;
}
