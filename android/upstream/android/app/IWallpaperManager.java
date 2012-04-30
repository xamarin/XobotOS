/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/app/IWallpaperManager.aidl
 */
package android.app;
/** @hide */
public interface IWallpaperManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.app.IWallpaperManager
{
private static final java.lang.String DESCRIPTOR = "android.app.IWallpaperManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.app.IWallpaperManager interface,
 * generating a proxy if needed.
 */
public static android.app.IWallpaperManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.app.IWallpaperManager))) {
return ((android.app.IWallpaperManager)iin);
}
return new android.app.IWallpaperManager.Stub.Proxy(obj);
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
case TRANSACTION_setWallpaper:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.os.ParcelFileDescriptor _result = this.setWallpaper(_arg0);
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
case TRANSACTION_setWallpaperComponent:
{
data.enforceInterface(DESCRIPTOR);
android.content.ComponentName _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.ComponentName.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.setWallpaperComponent(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getWallpaper:
{
data.enforceInterface(DESCRIPTOR);
android.app.IWallpaperManagerCallback _arg0;
_arg0 = android.app.IWallpaperManagerCallback.Stub.asInterface(data.readStrongBinder());
android.os.Bundle _arg1;
_arg1 = new android.os.Bundle();
android.os.ParcelFileDescriptor _result = this.getWallpaper(_arg0, _arg1);
reply.writeNoException();
if ((_result!=null)) {
reply.writeInt(1);
_result.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
if ((_arg1!=null)) {
reply.writeInt(1);
_arg1.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_getWallpaperInfo:
{
data.enforceInterface(DESCRIPTOR);
android.app.WallpaperInfo _result = this.getWallpaperInfo();
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
case TRANSACTION_clearWallpaper:
{
data.enforceInterface(DESCRIPTOR);
this.clearWallpaper();
reply.writeNoException();
return true;
}
case TRANSACTION_setDimensionHints:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.setDimensionHints(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getWidthHint:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getWidthHint();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getHeightHint:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getHeightHint();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.app.IWallpaperManager
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
     * Set the wallpaper.
     */
public android.os.ParcelFileDescriptor setWallpaper(java.lang.String name) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.ParcelFileDescriptor _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(name);
mRemote.transact(Stub.TRANSACTION_setWallpaper, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(_reply);
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
     * Set the live wallpaper.
     */
public void setWallpaperComponent(android.content.ComponentName name) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((name!=null)) {
_data.writeInt(1);
name.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setWallpaperComponent, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Get the wallpaper.
     */
public android.os.ParcelFileDescriptor getWallpaper(android.app.IWallpaperManagerCallback cb, android.os.Bundle outParams) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.ParcelFileDescriptor _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((cb!=null))?(cb.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getWallpaper, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.os.ParcelFileDescriptor.CREATOR.createFromParcel(_reply);
}
else {
_result = null;
}
if ((0!=_reply.readInt())) {
outParams.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Get information about a live wallpaper.
     */
public android.app.WallpaperInfo getWallpaperInfo() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.app.WallpaperInfo _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getWallpaperInfo, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.app.WallpaperInfo.CREATOR.createFromParcel(_reply);
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
     * Clear the wallpaper.
     */
public void clearWallpaper() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_clearWallpaper, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Sets the dimension hint for the wallpaper. These hints indicate the desired
     * minimum width and height for the wallpaper.
     */
public void setDimensionHints(int width, int height) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(width);
_data.writeInt(height);
mRemote.transact(Stub.TRANSACTION_setDimensionHints, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Returns the desired minimum width for the wallpaper.
     */
public int getWidthHint() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getWidthHint, _data, _reply, 0);
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
     * Returns the desired minimum height for the wallpaper.
     */
public int getHeightHint() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getHeightHint, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_setWallpaper = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_setWallpaperComponent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getWallpaper = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getWallpaperInfo = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_clearWallpaper = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_setDimensionHints = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_getWidthHint = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_getHeightHint = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
}
/**
     * Set the wallpaper.
     */
public android.os.ParcelFileDescriptor setWallpaper(java.lang.String name) throws android.os.RemoteException;
/**
     * Set the live wallpaper.
     */
public void setWallpaperComponent(android.content.ComponentName name) throws android.os.RemoteException;
/**
     * Get the wallpaper.
     */
public android.os.ParcelFileDescriptor getWallpaper(android.app.IWallpaperManagerCallback cb, android.os.Bundle outParams) throws android.os.RemoteException;
/**
     * Get information about a live wallpaper.
     */
public android.app.WallpaperInfo getWallpaperInfo() throws android.os.RemoteException;
/**
     * Clear the wallpaper.
     */
public void clearWallpaper() throws android.os.RemoteException;
/**
     * Sets the dimension hint for the wallpaper. These hints indicate the desired
     * minimum width and height for the wallpaper.
     */
public void setDimensionHints(int width, int height) throws android.os.RemoteException;
/**
     * Returns the desired minimum width for the wallpaper.
     */
public int getWidthHint() throws android.os.RemoteException;
/**
     * Returns the desired minimum height for the wallpaper.
     */
public int getHeightHint() throws android.os.RemoteException;
}
