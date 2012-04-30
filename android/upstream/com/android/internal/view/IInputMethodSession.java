/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/view/IInputMethodSession.aidl
 */
package com.android.internal.view;
/**
 * Sub-interface of IInputMethod which is safe to give to client applications.
 * {@hide}
 */
public interface IInputMethodSession extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.view.IInputMethodSession
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.view.IInputMethodSession";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.view.IInputMethodSession interface,
 * generating a proxy if needed.
 */
public static com.android.internal.view.IInputMethodSession asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.view.IInputMethodSession))) {
return ((com.android.internal.view.IInputMethodSession)iin);
}
return new com.android.internal.view.IInputMethodSession.Stub.Proxy(obj);
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
case TRANSACTION_finishInput:
{
data.enforceInterface(DESCRIPTOR);
this.finishInput();
return true;
}
case TRANSACTION_updateExtractedText:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.view.inputmethod.ExtractedText _arg1;
if ((0!=data.readInt())) {
_arg1 = android.view.inputmethod.ExtractedText.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.updateExtractedText(_arg0, _arg1);
return true;
}
case TRANSACTION_updateSelection:
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
int _arg4;
_arg4 = data.readInt();
int _arg5;
_arg5 = data.readInt();
this.updateSelection(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
return true;
}
case TRANSACTION_viewClicked:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.viewClicked(_arg0);
return true;
}
case TRANSACTION_updateCursor:
{
data.enforceInterface(DESCRIPTOR);
android.graphics.Rect _arg0;
if ((0!=data.readInt())) {
_arg0 = android.graphics.Rect.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.updateCursor(_arg0);
return true;
}
case TRANSACTION_displayCompletions:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.CompletionInfo[] _arg0;
_arg0 = data.createTypedArray(android.view.inputmethod.CompletionInfo.CREATOR);
this.displayCompletions(_arg0);
return true;
}
case TRANSACTION_dispatchKeyEvent:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.view.KeyEvent _arg1;
if ((0!=data.readInt())) {
_arg1 = android.view.KeyEvent.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
com.android.internal.view.IInputMethodCallback _arg2;
_arg2 = com.android.internal.view.IInputMethodCallback.Stub.asInterface(data.readStrongBinder());
this.dispatchKeyEvent(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_dispatchTrackballEvent:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.view.MotionEvent _arg1;
if ((0!=data.readInt())) {
_arg1 = android.view.MotionEvent.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
com.android.internal.view.IInputMethodCallback _arg2;
_arg2 = com.android.internal.view.IInputMethodCallback.Stub.asInterface(data.readStrongBinder());
this.dispatchTrackballEvent(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_appPrivateCommand:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.os.Bundle _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.Bundle.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.appPrivateCommand(_arg0, _arg1);
return true;
}
case TRANSACTION_toggleSoftInput:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.toggleSoftInput(_arg0, _arg1);
return true;
}
case TRANSACTION_finishSession:
{
data.enforceInterface(DESCRIPTOR);
this.finishSession();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.view.IInputMethodSession
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
public void finishInput() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_finishInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void updateExtractedText(int token, android.view.inputmethod.ExtractedText text) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(token);
if ((text!=null)) {
_data.writeInt(1);
text.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_updateExtractedText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void updateSelection(int oldSelStart, int oldSelEnd, int newSelStart, int newSelEnd, int candidatesStart, int candidatesEnd) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(oldSelStart);
_data.writeInt(oldSelEnd);
_data.writeInt(newSelStart);
_data.writeInt(newSelEnd);
_data.writeInt(candidatesStart);
_data.writeInt(candidatesEnd);
mRemote.transact(Stub.TRANSACTION_updateSelection, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void viewClicked(boolean focusChanged) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((focusChanged)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_viewClicked, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void updateCursor(android.graphics.Rect newCursor) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((newCursor!=null)) {
_data.writeInt(1);
newCursor.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_updateCursor, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void displayCompletions(android.view.inputmethod.CompletionInfo[] completions) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeTypedArray(completions, 0);
mRemote.transact(Stub.TRANSACTION_displayCompletions, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void dispatchKeyEvent(int seq, android.view.KeyEvent event, com.android.internal.view.IInputMethodCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(seq);
if ((event!=null)) {
_data.writeInt(1);
event.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_dispatchKeyEvent, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void dispatchTrackballEvent(int seq, android.view.MotionEvent event, com.android.internal.view.IInputMethodCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(seq);
if ((event!=null)) {
_data.writeInt(1);
event.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_dispatchTrackballEvent, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void appPrivateCommand(java.lang.String action, android.os.Bundle data) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(action);
if ((data!=null)) {
_data.writeInt(1);
data.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_appPrivateCommand, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void toggleSoftInput(int showFlags, int hideFlags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(showFlags);
_data.writeInt(hideFlags);
mRemote.transact(Stub.TRANSACTION_toggleSoftInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void finishSession() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_finishSession, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_finishInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_updateExtractedText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_updateSelection = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_viewClicked = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_updateCursor = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_displayCompletions = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_dispatchKeyEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_dispatchTrackballEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_appPrivateCommand = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_toggleSoftInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_finishSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
}
public void finishInput() throws android.os.RemoteException;
public void updateExtractedText(int token, android.view.inputmethod.ExtractedText text) throws android.os.RemoteException;
public void updateSelection(int oldSelStart, int oldSelEnd, int newSelStart, int newSelEnd, int candidatesStart, int candidatesEnd) throws android.os.RemoteException;
public void viewClicked(boolean focusChanged) throws android.os.RemoteException;
public void updateCursor(android.graphics.Rect newCursor) throws android.os.RemoteException;
public void displayCompletions(android.view.inputmethod.CompletionInfo[] completions) throws android.os.RemoteException;
public void dispatchKeyEvent(int seq, android.view.KeyEvent event, com.android.internal.view.IInputMethodCallback callback) throws android.os.RemoteException;
public void dispatchTrackballEvent(int seq, android.view.MotionEvent event, com.android.internal.view.IInputMethodCallback callback) throws android.os.RemoteException;
public void appPrivateCommand(java.lang.String action, android.os.Bundle data) throws android.os.RemoteException;
public void toggleSoftInput(int showFlags, int hideFlags) throws android.os.RemoteException;
public void finishSession() throws android.os.RemoteException;
}
