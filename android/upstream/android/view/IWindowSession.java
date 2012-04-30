/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/view/IWindowSession.aidl
 */
package android.view;
/**
 * System private per-application interface to the window manager.
 *
 * {@hide}
 */
public interface IWindowSession extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.view.IWindowSession
{
private static final java.lang.String DESCRIPTOR = "android.view.IWindowSession";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.view.IWindowSession interface,
 * generating a proxy if needed.
 */
public static android.view.IWindowSession asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.view.IWindowSession))) {
return ((android.view.IWindowSession)iin);
}
return new android.view.IWindowSession.Stub.Proxy(obj);
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
case TRANSACTION_add:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
android.view.WindowManager.LayoutParams _arg2;
if ((0!=data.readInt())) {
_arg2 = android.view.WindowManager.LayoutParams.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
int _arg3;
_arg3 = data.readInt();
android.graphics.Rect _arg4;
_arg4 = new android.graphics.Rect();
android.view.InputChannel _arg5;
_arg5 = new android.view.InputChannel();
int _result = this.add(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
reply.writeNoException();
reply.writeInt(_result);
if ((_arg4!=null)) {
reply.writeInt(1);
_arg4.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
if ((_arg5!=null)) {
reply.writeInt(1);
_arg5.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_addWithoutInputChannel:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
android.view.WindowManager.LayoutParams _arg2;
if ((0!=data.readInt())) {
_arg2 = android.view.WindowManager.LayoutParams.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
int _arg3;
_arg3 = data.readInt();
android.graphics.Rect _arg4;
_arg4 = new android.graphics.Rect();
int _result = this.addWithoutInputChannel(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
reply.writeInt(_result);
if ((_arg4!=null)) {
reply.writeInt(1);
_arg4.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_remove:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
this.remove(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_relayout:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
android.view.WindowManager.LayoutParams _arg2;
if ((0!=data.readInt())) {
_arg2 = android.view.WindowManager.LayoutParams.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
int _arg3;
_arg3 = data.readInt();
int _arg4;
_arg4 = data.readInt();
int _arg5;
_arg5 = data.readInt();
boolean _arg6;
_arg6 = (0!=data.readInt());
android.graphics.Rect _arg7;
_arg7 = new android.graphics.Rect();
android.graphics.Rect _arg8;
_arg8 = new android.graphics.Rect();
android.graphics.Rect _arg9;
_arg9 = new android.graphics.Rect();
android.content.res.Configuration _arg10;
_arg10 = new android.content.res.Configuration();
android.view.Surface _arg11;
_arg11 = new android.view.Surface();
int _result = this.relayout(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9, _arg10, _arg11);
reply.writeNoException();
reply.writeInt(_result);
if ((_arg7!=null)) {
reply.writeInt(1);
_arg7.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
if ((_arg8!=null)) {
reply.writeInt(1);
_arg8.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
if ((_arg9!=null)) {
reply.writeInt(1);
_arg9.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
if ((_arg10!=null)) {
reply.writeInt(1);
_arg10.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
if ((_arg11!=null)) {
reply.writeInt(1);
_arg11.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_outOfMemory:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
boolean _result = this.outOfMemory(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setTransparentRegion:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
android.graphics.Region _arg1;
if ((0!=data.readInt())) {
_arg1 = android.graphics.Region.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.setTransparentRegion(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setInsets:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
android.graphics.Rect _arg2;
if ((0!=data.readInt())) {
_arg2 = android.graphics.Rect.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
android.graphics.Rect _arg3;
if ((0!=data.readInt())) {
_arg3 = android.graphics.Rect.CREATOR.createFromParcel(data);
}
else {
_arg3 = null;
}
android.graphics.Region _arg4;
if ((0!=data.readInt())) {
_arg4 = android.graphics.Region.CREATOR.createFromParcel(data);
}
else {
_arg4 = null;
}
this.setInsets(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
return true;
}
case TRANSACTION_getDisplayFrame:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
android.graphics.Rect _arg1;
_arg1 = new android.graphics.Rect();
this.getDisplayFrame(_arg0, _arg1);
reply.writeNoException();
if ((_arg1!=null)) {
reply.writeInt(1);
_arg1.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_finishDrawing:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
this.finishDrawing(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setInTouchMode:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.setInTouchMode(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getInTouchMode:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.getInTouchMode();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_performHapticFeedback:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
boolean _arg2;
_arg2 = (0!=data.readInt());
boolean _result = this.performHapticFeedback(_arg0, _arg1, _arg2);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_prepareDrag:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
android.view.Surface _arg4;
_arg4 = new android.view.Surface();
android.os.IBinder _result = this.prepareDrag(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
reply.writeStrongBinder(_result);
if ((_arg4!=null)) {
reply.writeInt(1);
_arg4.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_performDrag:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
android.os.IBinder _arg1;
_arg1 = data.readStrongBinder();
float _arg2;
_arg2 = data.readFloat();
float _arg3;
_arg3 = data.readFloat();
float _arg4;
_arg4 = data.readFloat();
float _arg5;
_arg5 = data.readFloat();
android.content.ClipData _arg6;
if ((0!=data.readInt())) {
_arg6 = android.content.ClipData.CREATOR.createFromParcel(data);
}
else {
_arg6 = null;
}
boolean _result = this.performDrag(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_reportDropResult:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
boolean _arg1;
_arg1 = (0!=data.readInt());
this.reportDropResult(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_dragRecipientEntered:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
this.dragRecipientEntered(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_dragRecipientExited:
{
data.enforceInterface(DESCRIPTOR);
android.view.IWindow _arg0;
_arg0 = android.view.IWindow.Stub.asInterface(data.readStrongBinder());
this.dragRecipientExited(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setWallpaperPosition:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
float _arg1;
_arg1 = data.readFloat();
float _arg2;
_arg2 = data.readFloat();
float _arg3;
_arg3 = data.readFloat();
float _arg4;
_arg4 = data.readFloat();
this.setWallpaperPosition(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
return true;
}
case TRANSACTION_wallpaperOffsetsComplete:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.wallpaperOffsetsComplete(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_sendWallpaperCommand:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
int _arg4;
_arg4 = data.readInt();
android.os.Bundle _arg5;
if ((0!=data.readInt())) {
_arg5 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg5 = null;
}
boolean _arg6;
_arg6 = (0!=data.readInt());
android.os.Bundle _result = this.sendWallpaperCommand(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6);
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
case TRANSACTION_wallpaperCommandComplete:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
android.os.Bundle _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.wallpaperCommandComplete(_arg0, _arg1);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.view.IWindowSession
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
public int add(android.view.IWindow window, int seq, android.view.WindowManager.LayoutParams attrs, int viewVisibility, android.graphics.Rect outContentInsets, android.view.InputChannel outInputChannel) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeInt(seq);
if ((attrs!=null)) {
_data.writeInt(1);
attrs.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(viewVisibility);
mRemote.transact(Stub.TRANSACTION_add, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
if ((0!=_reply.readInt())) {
outContentInsets.readFromParcel(_reply);
}
if ((0!=_reply.readInt())) {
outInputChannel.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int addWithoutInputChannel(android.view.IWindow window, int seq, android.view.WindowManager.LayoutParams attrs, int viewVisibility, android.graphics.Rect outContentInsets) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeInt(seq);
if ((attrs!=null)) {
_data.writeInt(1);
attrs.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(viewVisibility);
mRemote.transact(Stub.TRANSACTION_addWithoutInputChannel, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
if ((0!=_reply.readInt())) {
outContentInsets.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void remove(android.view.IWindow window) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_remove, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Change the parameters of a window.  You supply the
     * new parameters, it returns the new frame of the window on screen (the
     * position should be ignored) and surface of the window.  The surface
     * will be invalid if the window is currently hidden, else you can use it
     * to draw the window's contents.
     * 
     * @param window The window being modified.
     * @param seq Ordering sequence number.
     * @param attrs If non-null, new attributes to apply to the window.
     * @param requestedWidth The width the window wants to be.
     * @param requestedHeight The height the window wants to be.
     * @param viewVisibility Window root view's visibility.
     * @param insetsPending Set to true if the client will be later giving
     * internal insets; as a result, the window will not impact other window
     * layouts until the insets are given.
     * @param outFrame Rect in which is placed the new position/size on
     * screen.
     * @param outContentInsets Rect in which is placed the offsets from
     * <var>outFrame</var> in which the content of the window should be
     * placed.  This can be used to modify the window layout to ensure its
     * contents are visible to the user, taking into account system windows
     * like the status bar or a soft keyboard.
     * @param outVisibleInsets Rect in which is placed the offsets from
     * <var>outFrame</var> in which the window is actually completely visible
     * to the user.  This can be used to temporarily scroll the window's
     * contents to make sure the user can see it.  This is different than
     * <var>outContentInsets</var> in that these insets change transiently,
     * so complex relayout of the window should not happen based on them.
     * @param outConfiguration New configuration of window, if it is now
     * becoming visible and the global configuration has changed since it
     * was last displayed.
     * @param outSurface Object in which is placed the new display surface.
     * 
     * @return int Result flags: {@link WindowManagerImpl#RELAYOUT_SHOW_FOCUS},
     * {@link WindowManagerImpl#RELAYOUT_FIRST_TIME}.
     */
public int relayout(android.view.IWindow window, int seq, android.view.WindowManager.LayoutParams attrs, int requestedWidth, int requestedHeight, int viewVisibility, boolean insetsPending, android.graphics.Rect outFrame, android.graphics.Rect outContentInsets, android.graphics.Rect outVisibleInsets, android.content.res.Configuration outConfig, android.view.Surface outSurface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeInt(seq);
if ((attrs!=null)) {
_data.writeInt(1);
attrs.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(requestedWidth);
_data.writeInt(requestedHeight);
_data.writeInt(viewVisibility);
_data.writeInt(((insetsPending)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_relayout, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
if ((0!=_reply.readInt())) {
outFrame.readFromParcel(_reply);
}
if ((0!=_reply.readInt())) {
outContentInsets.readFromParcel(_reply);
}
if ((0!=_reply.readInt())) {
outVisibleInsets.readFromParcel(_reply);
}
if ((0!=_reply.readInt())) {
outConfig.readFromParcel(_reply);
}
if ((0!=_reply.readInt())) {
outSurface.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Called by a client to report that it ran out of graphics memory.
     */
public boolean outOfMemory(android.view.IWindow window) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_outOfMemory, _data, _reply, 0);
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
     * Give the window manager a hint of the part of the window that is
     * completely transparent, allowing it to work with the surface flinger
     * to optimize compositing of this part of the window.
     */
public void setTransparentRegion(android.view.IWindow window, android.graphics.Region region) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
if ((region!=null)) {
_data.writeInt(1);
region.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setTransparentRegion, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Tell the window manager about the content and visible insets of the
     * given window, which can be used to adjust the <var>outContentInsets</var>
     * and <var>outVisibleInsets</var> values returned by
     * {@link #relayout relayout()} for windows behind this one.
     *
     * @param touchableInsets Controls which part of the window inside of its
     * frame can receive pointer events, as defined by
     * {@link android.view.ViewTreeObserver.InternalInsetsInfo}.
     */
public void setInsets(android.view.IWindow window, int touchableInsets, android.graphics.Rect contentInsets, android.graphics.Rect visibleInsets, android.graphics.Region touchableRegion) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeInt(touchableInsets);
if ((contentInsets!=null)) {
_data.writeInt(1);
contentInsets.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((visibleInsets!=null)) {
_data.writeInt(1);
visibleInsets.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((touchableRegion!=null)) {
_data.writeInt(1);
touchableRegion.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setInsets, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Return the current display size in which the window is being laid out,
     * accounting for screen decorations around it.
     */
public void getDisplayFrame(android.view.IWindow window, android.graphics.Rect outDisplayFrame) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getDisplayFrame, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
outDisplayFrame.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void finishDrawing(android.view.IWindow window) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_finishDrawing, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setInTouchMode(boolean showFocus) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((showFocus)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setInTouchMode, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean getInTouchMode() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getInTouchMode, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean performHapticFeedback(android.view.IWindow window, int effectId, boolean always) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeInt(effectId);
_data.writeInt(((always)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_performHapticFeedback, _data, _reply, 0);
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
     * Allocate the drag's thumbnail surface.  Also assigns a token that identifies
     * the drag to the OS and passes that as the return value.  A return value of
     * null indicates failure.
     */
public android.os.IBinder prepareDrag(android.view.IWindow window, int flags, int thumbnailWidth, int thumbnailHeight, android.view.Surface outSurface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.IBinder _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeInt(flags);
_data.writeInt(thumbnailWidth);
_data.writeInt(thumbnailHeight);
mRemote.transact(Stub.TRANSACTION_prepareDrag, _data, _reply, 0);
_reply.readException();
_result = _reply.readStrongBinder();
if ((0!=_reply.readInt())) {
outSurface.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Initiate the drag operation itself
     */
public boolean performDrag(android.view.IWindow window, android.os.IBinder dragToken, float touchX, float touchY, float thumbCenterX, float thumbCenterY, android.content.ClipData data) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeStrongBinder(dragToken);
_data.writeFloat(touchX);
_data.writeFloat(touchY);
_data.writeFloat(thumbCenterX);
_data.writeFloat(thumbCenterY);
if ((data!=null)) {
_data.writeInt(1);
data.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_performDrag, _data, _reply, 0);
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
	 * Report the result of a drop action targeted to the given window.
	 * consumed is 'true' when the drop was accepted by a valid recipient,
	 * 'false' otherwise.
	 */
public void reportDropResult(android.view.IWindow window, boolean consumed) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
_data.writeInt(((consumed)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_reportDropResult, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Tell the OS that we've just dragged into a View that is willing to accept the drop
     */
public void dragRecipientEntered(android.view.IWindow window) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_dragRecipientEntered, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Tell the OS that we've just dragged *off* of a View that was willing to accept the drop
     */
public void dragRecipientExited(android.view.IWindow window) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((window!=null))?(window.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_dragRecipientExited, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * For windows with the wallpaper behind them, and the wallpaper is
     * larger than the screen, set the offset within the screen.
     * For multi screen launcher type applications, xstep and ystep indicate
     * how big the increment is from one screen to another.
     */
public void setWallpaperPosition(android.os.IBinder windowToken, float x, float y, float xstep, float ystep) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(windowToken);
_data.writeFloat(x);
_data.writeFloat(y);
_data.writeFloat(xstep);
_data.writeFloat(ystep);
mRemote.transact(Stub.TRANSACTION_setWallpaperPosition, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void wallpaperOffsetsComplete(android.os.IBinder window) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(window);
mRemote.transact(Stub.TRANSACTION_wallpaperOffsetsComplete, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public android.os.Bundle sendWallpaperCommand(android.os.IBinder window, java.lang.String action, int x, int y, int z, android.os.Bundle extras, boolean sync) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.Bundle _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(window);
_data.writeString(action);
_data.writeInt(x);
_data.writeInt(y);
_data.writeInt(z);
if ((extras!=null)) {
_data.writeInt(1);
extras.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((sync)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_sendWallpaperCommand, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.os.Bundle.CREATOR.createFromParcel(_reply);
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
public void wallpaperCommandComplete(android.os.IBinder window, android.os.Bundle result) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(window);
if ((result!=null)) {
_data.writeInt(1);
result.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_wallpaperCommandComplete, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_add = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_addWithoutInputChannel = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_remove = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_relayout = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_outOfMemory = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_setTransparentRegion = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setInsets = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_getDisplayFrame = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_finishDrawing = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_setInTouchMode = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_getInTouchMode = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_performHapticFeedback = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_prepareDrag = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_performDrag = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_reportDropResult = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_dragRecipientEntered = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_dragRecipientExited = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_setWallpaperPosition = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_wallpaperOffsetsComplete = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_sendWallpaperCommand = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_wallpaperCommandComplete = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
}
public int add(android.view.IWindow window, int seq, android.view.WindowManager.LayoutParams attrs, int viewVisibility, android.graphics.Rect outContentInsets, android.view.InputChannel outInputChannel) throws android.os.RemoteException;
public int addWithoutInputChannel(android.view.IWindow window, int seq, android.view.WindowManager.LayoutParams attrs, int viewVisibility, android.graphics.Rect outContentInsets) throws android.os.RemoteException;
public void remove(android.view.IWindow window) throws android.os.RemoteException;
/**
     * Change the parameters of a window.  You supply the
     * new parameters, it returns the new frame of the window on screen (the
     * position should be ignored) and surface of the window.  The surface
     * will be invalid if the window is currently hidden, else you can use it
     * to draw the window's contents.
     * 
     * @param window The window being modified.
     * @param seq Ordering sequence number.
     * @param attrs If non-null, new attributes to apply to the window.
     * @param requestedWidth The width the window wants to be.
     * @param requestedHeight The height the window wants to be.
     * @param viewVisibility Window root view's visibility.
     * @param insetsPending Set to true if the client will be later giving
     * internal insets; as a result, the window will not impact other window
     * layouts until the insets are given.
     * @param outFrame Rect in which is placed the new position/size on
     * screen.
     * @param outContentInsets Rect in which is placed the offsets from
     * <var>outFrame</var> in which the content of the window should be
     * placed.  This can be used to modify the window layout to ensure its
     * contents are visible to the user, taking into account system windows
     * like the status bar or a soft keyboard.
     * @param outVisibleInsets Rect in which is placed the offsets from
     * <var>outFrame</var> in which the window is actually completely visible
     * to the user.  This can be used to temporarily scroll the window's
     * contents to make sure the user can see it.  This is different than
     * <var>outContentInsets</var> in that these insets change transiently,
     * so complex relayout of the window should not happen based on them.
     * @param outConfiguration New configuration of window, if it is now
     * becoming visible and the global configuration has changed since it
     * was last displayed.
     * @param outSurface Object in which is placed the new display surface.
     * 
     * @return int Result flags: {@link WindowManagerImpl#RELAYOUT_SHOW_FOCUS},
     * {@link WindowManagerImpl#RELAYOUT_FIRST_TIME}.
     */
public int relayout(android.view.IWindow window, int seq, android.view.WindowManager.LayoutParams attrs, int requestedWidth, int requestedHeight, int viewVisibility, boolean insetsPending, android.graphics.Rect outFrame, android.graphics.Rect outContentInsets, android.graphics.Rect outVisibleInsets, android.content.res.Configuration outConfig, android.view.Surface outSurface) throws android.os.RemoteException;
/**
     * Called by a client to report that it ran out of graphics memory.
     */
public boolean outOfMemory(android.view.IWindow window) throws android.os.RemoteException;
/**
     * Give the window manager a hint of the part of the window that is
     * completely transparent, allowing it to work with the surface flinger
     * to optimize compositing of this part of the window.
     */
public void setTransparentRegion(android.view.IWindow window, android.graphics.Region region) throws android.os.RemoteException;
/**
     * Tell the window manager about the content and visible insets of the
     * given window, which can be used to adjust the <var>outContentInsets</var>
     * and <var>outVisibleInsets</var> values returned by
     * {@link #relayout relayout()} for windows behind this one.
     *
     * @param touchableInsets Controls which part of the window inside of its
     * frame can receive pointer events, as defined by
     * {@link android.view.ViewTreeObserver.InternalInsetsInfo}.
     */
public void setInsets(android.view.IWindow window, int touchableInsets, android.graphics.Rect contentInsets, android.graphics.Rect visibleInsets, android.graphics.Region touchableRegion) throws android.os.RemoteException;
/**
     * Return the current display size in which the window is being laid out,
     * accounting for screen decorations around it.
     */
public void getDisplayFrame(android.view.IWindow window, android.graphics.Rect outDisplayFrame) throws android.os.RemoteException;
public void finishDrawing(android.view.IWindow window) throws android.os.RemoteException;
public void setInTouchMode(boolean showFocus) throws android.os.RemoteException;
public boolean getInTouchMode() throws android.os.RemoteException;
public boolean performHapticFeedback(android.view.IWindow window, int effectId, boolean always) throws android.os.RemoteException;
/**
     * Allocate the drag's thumbnail surface.  Also assigns a token that identifies
     * the drag to the OS and passes that as the return value.  A return value of
     * null indicates failure.
     */
public android.os.IBinder prepareDrag(android.view.IWindow window, int flags, int thumbnailWidth, int thumbnailHeight, android.view.Surface outSurface) throws android.os.RemoteException;
/**
     * Initiate the drag operation itself
     */
public boolean performDrag(android.view.IWindow window, android.os.IBinder dragToken, float touchX, float touchY, float thumbCenterX, float thumbCenterY, android.content.ClipData data) throws android.os.RemoteException;
/**
	 * Report the result of a drop action targeted to the given window.
	 * consumed is 'true' when the drop was accepted by a valid recipient,
	 * 'false' otherwise.
	 */
public void reportDropResult(android.view.IWindow window, boolean consumed) throws android.os.RemoteException;
/**
     * Tell the OS that we've just dragged into a View that is willing to accept the drop
     */
public void dragRecipientEntered(android.view.IWindow window) throws android.os.RemoteException;
/**
     * Tell the OS that we've just dragged *off* of a View that was willing to accept the drop
     */
public void dragRecipientExited(android.view.IWindow window) throws android.os.RemoteException;
/**
     * For windows with the wallpaper behind them, and the wallpaper is
     * larger than the screen, set the offset within the screen.
     * For multi screen launcher type applications, xstep and ystep indicate
     * how big the increment is from one screen to another.
     */
public void setWallpaperPosition(android.os.IBinder windowToken, float x, float y, float xstep, float ystep) throws android.os.RemoteException;
public void wallpaperOffsetsComplete(android.os.IBinder window) throws android.os.RemoteException;
public android.os.Bundle sendWallpaperCommand(android.os.IBinder window, java.lang.String action, int x, int y, int z, android.os.Bundle extras, boolean sync) throws android.os.RemoteException;
public void wallpaperCommandComplete(android.os.IBinder window, android.os.Bundle result) throws android.os.RemoteException;
}
