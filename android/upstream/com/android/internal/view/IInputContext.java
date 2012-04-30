/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/view/IInputContext.aidl
 */
package com.android.internal.view;
/**
 * Interface from an input method to the application, allowing it to perform
 * edits on the current input field and other interactions with the application.
 * {@hide}
 */
public interface IInputContext extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.view.IInputContext
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.view.IInputContext";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.view.IInputContext interface,
 * generating a proxy if needed.
 */
public static com.android.internal.view.IInputContext asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.view.IInputContext))) {
return ((com.android.internal.view.IInputContext)iin);
}
return new com.android.internal.view.IInputContext.Stub.Proxy(obj);
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
case TRANSACTION_getTextBeforeCursor:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
com.android.internal.view.IInputContextCallback _arg3;
_arg3 = com.android.internal.view.IInputContextCallback.Stub.asInterface(data.readStrongBinder());
this.getTextBeforeCursor(_arg0, _arg1, _arg2, _arg3);
return true;
}
case TRANSACTION_getTextAfterCursor:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
com.android.internal.view.IInputContextCallback _arg3;
_arg3 = com.android.internal.view.IInputContextCallback.Stub.asInterface(data.readStrongBinder());
this.getTextAfterCursor(_arg0, _arg1, _arg2, _arg3);
return true;
}
case TRANSACTION_getCursorCapsMode:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
com.android.internal.view.IInputContextCallback _arg2;
_arg2 = com.android.internal.view.IInputContextCallback.Stub.asInterface(data.readStrongBinder());
this.getCursorCapsMode(_arg0, _arg1, _arg2);
return true;
}
case TRANSACTION_getExtractedText:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.ExtractedTextRequest _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.inputmethod.ExtractedTextRequest.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
com.android.internal.view.IInputContextCallback _arg3;
_arg3 = com.android.internal.view.IInputContextCallback.Stub.asInterface(data.readStrongBinder());
this.getExtractedText(_arg0, _arg1, _arg2, _arg3);
return true;
}
case TRANSACTION_deleteSurroundingText:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.deleteSurroundingText(_arg0, _arg1);
return true;
}
case TRANSACTION_setComposingText:
{
data.enforceInterface(DESCRIPTOR);
java.lang.CharSequence _arg0;
if ((0!=data.readInt())) {
_arg0 = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.setComposingText(_arg0, _arg1);
return true;
}
case TRANSACTION_finishComposingText:
{
data.enforceInterface(DESCRIPTOR);
this.finishComposingText();
return true;
}
case TRANSACTION_commitText:
{
data.enforceInterface(DESCRIPTOR);
java.lang.CharSequence _arg0;
if ((0!=data.readInt())) {
_arg0 = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
this.commitText(_arg0, _arg1);
return true;
}
case TRANSACTION_commitCompletion:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.CompletionInfo _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.inputmethod.CompletionInfo.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.commitCompletion(_arg0);
return true;
}
case TRANSACTION_commitCorrection:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.CorrectionInfo _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.inputmethod.CorrectionInfo.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.commitCorrection(_arg0);
return true;
}
case TRANSACTION_setSelection:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.setSelection(_arg0, _arg1);
return true;
}
case TRANSACTION_performEditorAction:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.performEditorAction(_arg0);
return true;
}
case TRANSACTION_performContextMenuAction:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.performContextMenuAction(_arg0);
return true;
}
case TRANSACTION_beginBatchEdit:
{
data.enforceInterface(DESCRIPTOR);
this.beginBatchEdit();
return true;
}
case TRANSACTION_endBatchEdit:
{
data.enforceInterface(DESCRIPTOR);
this.endBatchEdit();
return true;
}
case TRANSACTION_reportFullscreenMode:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.reportFullscreenMode(_arg0);
return true;
}
case TRANSACTION_sendKeyEvent:
{
data.enforceInterface(DESCRIPTOR);
android.view.KeyEvent _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.KeyEvent.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.sendKeyEvent(_arg0);
return true;
}
case TRANSACTION_clearMetaKeyStates:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.clearMetaKeyStates(_arg0);
return true;
}
case TRANSACTION_performPrivateCommand:
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
this.performPrivateCommand(_arg0, _arg1);
return true;
}
case TRANSACTION_setComposingRegion:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.setComposingRegion(_arg0, _arg1);
return true;
}
case TRANSACTION_getSelectedText:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
com.android.internal.view.IInputContextCallback _arg2;
_arg2 = com.android.internal.view.IInputContextCallback.Stub.asInterface(data.readStrongBinder());
this.getSelectedText(_arg0, _arg1, _arg2);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.view.IInputContext
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
public void getTextBeforeCursor(int length, int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(length);
_data.writeInt(flags);
_data.writeInt(seq);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getTextBeforeCursor, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void getTextAfterCursor(int length, int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(length);
_data.writeInt(flags);
_data.writeInt(seq);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getTextAfterCursor, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void getCursorCapsMode(int reqModes, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(reqModes);
_data.writeInt(seq);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getCursorCapsMode, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void getExtractedText(android.view.inputmethod.ExtractedTextRequest request, int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((request!=null)) {
_data.writeInt(1);
request.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(flags);
_data.writeInt(seq);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getExtractedText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void deleteSurroundingText(int leftLength, int rightLength) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(leftLength);
_data.writeInt(rightLength);
mRemote.transact(Stub.TRANSACTION_deleteSurroundingText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setComposingText(java.lang.CharSequence text, int newCursorPosition) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((text!=null)) {
_data.writeInt(1);
android.text.TextUtils.writeToParcel(text, _data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(newCursorPosition);
mRemote.transact(Stub.TRANSACTION_setComposingText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void finishComposingText() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_finishComposingText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void commitText(java.lang.CharSequence text, int newCursorPosition) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((text!=null)) {
_data.writeInt(1);
android.text.TextUtils.writeToParcel(text, _data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(newCursorPosition);
mRemote.transact(Stub.TRANSACTION_commitText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void commitCompletion(android.view.inputmethod.CompletionInfo completion) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((completion!=null)) {
_data.writeInt(1);
completion.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_commitCompletion, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void commitCorrection(android.view.inputmethod.CorrectionInfo correction) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((correction!=null)) {
_data.writeInt(1);
correction.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_commitCorrection, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setSelection(int start, int end) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(start);
_data.writeInt(end);
mRemote.transact(Stub.TRANSACTION_setSelection, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void performEditorAction(int actionCode) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(actionCode);
mRemote.transact(Stub.TRANSACTION_performEditorAction, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void performContextMenuAction(int id) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(id);
mRemote.transact(Stub.TRANSACTION_performContextMenuAction, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void beginBatchEdit() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_beginBatchEdit, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void endBatchEdit() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_endBatchEdit, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void reportFullscreenMode(boolean enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((enabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_reportFullscreenMode, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void sendKeyEvent(android.view.KeyEvent event) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((event!=null)) {
_data.writeInt(1);
event.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_sendKeyEvent, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void clearMetaKeyStates(int states) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(states);
mRemote.transact(Stub.TRANSACTION_clearMetaKeyStates, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void performPrivateCommand(java.lang.String action, android.os.Bundle data) throws android.os.RemoteException
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
mRemote.transact(Stub.TRANSACTION_performPrivateCommand, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setComposingRegion(int start, int end) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(start);
_data.writeInt(end);
mRemote.transact(Stub.TRANSACTION_setComposingRegion, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void getSelectedText(int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(flags);
_data.writeInt(seq);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getSelectedText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_getTextBeforeCursor = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getTextAfterCursor = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getCursorCapsMode = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getExtractedText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_deleteSurroundingText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_setComposingText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_finishComposingText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_commitText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_commitCompletion = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_commitCorrection = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_setSelection = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_performEditorAction = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_performContextMenuAction = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_beginBatchEdit = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_endBatchEdit = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_reportFullscreenMode = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_sendKeyEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_clearMetaKeyStates = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_performPrivateCommand = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_setComposingRegion = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_getSelectedText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
}
public void getTextBeforeCursor(int length, int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException;
public void getTextAfterCursor(int length, int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException;
public void getCursorCapsMode(int reqModes, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException;
public void getExtractedText(android.view.inputmethod.ExtractedTextRequest request, int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException;
public void deleteSurroundingText(int leftLength, int rightLength) throws android.os.RemoteException;
public void setComposingText(java.lang.CharSequence text, int newCursorPosition) throws android.os.RemoteException;
public void finishComposingText() throws android.os.RemoteException;
public void commitText(java.lang.CharSequence text, int newCursorPosition) throws android.os.RemoteException;
public void commitCompletion(android.view.inputmethod.CompletionInfo completion) throws android.os.RemoteException;
public void commitCorrection(android.view.inputmethod.CorrectionInfo correction) throws android.os.RemoteException;
public void setSelection(int start, int end) throws android.os.RemoteException;
public void performEditorAction(int actionCode) throws android.os.RemoteException;
public void performContextMenuAction(int id) throws android.os.RemoteException;
public void beginBatchEdit() throws android.os.RemoteException;
public void endBatchEdit() throws android.os.RemoteException;
public void reportFullscreenMode(boolean enabled) throws android.os.RemoteException;
public void sendKeyEvent(android.view.KeyEvent event) throws android.os.RemoteException;
public void clearMetaKeyStates(int states) throws android.os.RemoteException;
public void performPrivateCommand(java.lang.String action, android.os.Bundle data) throws android.os.RemoteException;
public void setComposingRegion(int start, int end) throws android.os.RemoteException;
public void getSelectedText(int flags, int seq, com.android.internal.view.IInputContextCallback callback) throws android.os.RemoteException;
}
