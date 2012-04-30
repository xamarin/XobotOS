/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/view/IInputMethod.aidl
 */
package com.android.internal.view;
/**
 * Top-level interface to an input method component (implemented in a
 * Service).
 * {@hide}
 */
public interface IInputMethod extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.view.IInputMethod
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.view.IInputMethod";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.view.IInputMethod interface,
 * generating a proxy if needed.
 */
public static com.android.internal.view.IInputMethod asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.view.IInputMethod))) {
return ((com.android.internal.view.IInputMethod)iin);
}
return new com.android.internal.view.IInputMethod.Stub.Proxy(obj);
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
case TRANSACTION_attachToken:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.attachToken(_arg0);
return true;
}
case TRANSACTION_bindInput:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.InputBinding _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.inputmethod.InputBinding.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.bindInput(_arg0);
return true;
}
case TRANSACTION_unbindInput:
{
data.enforceInterface(DESCRIPTOR);
this.unbindInput();
return true;
}
case TRANSACTION_startInput:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputContext _arg0;
_arg0 = com.android.internal.view.IInputContext.Stub.asInterface(data.readStrongBinder());
android.view.inputmethod.EditorInfo _arg1;
if ((0!=data.readInt())) {
_arg1 = android.view.inputmethod.EditorInfo.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.startInput(_arg0, _arg1);
return true;
}
case TRANSACTION_restartInput:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputContext _arg0;
_arg0 = com.android.internal.view.IInputContext.Stub.asInterface(data.readStrongBinder());
android.view.inputmethod.EditorInfo _arg1;
if ((0!=data.readInt())) {
_arg1 = android.view.inputmethod.EditorInfo.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.restartInput(_arg0, _arg1);
return true;
}
case TRANSACTION_createSession:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodCallback _arg0;
_arg0 = com.android.internal.view.IInputMethodCallback.Stub.asInterface(data.readStrongBinder());
this.createSession(_arg0);
return true;
}
case TRANSACTION_setSessionEnabled:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodSession _arg0;
_arg0 = com.android.internal.view.IInputMethodSession.Stub.asInterface(data.readStrongBinder());
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setSessionEnabled(_arg0, _arg1);
return true;
}
case TRANSACTION_revokeSession:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodSession _arg0;
_arg0 = com.android.internal.view.IInputMethodSession.Stub.asInterface(data.readStrongBinder());
this.revokeSession(_arg0);
return true;
}
case TRANSACTION_showSoftInput:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.os.ResultReceiver _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.ResultReceiver.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.showSoftInput(_arg0, _arg1);
return true;
}
case TRANSACTION_hideSoftInput:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.os.ResultReceiver _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.ResultReceiver.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.hideSoftInput(_arg0, _arg1);
return true;
}
case TRANSACTION_changeInputMethodSubtype:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.InputMethodSubtype _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.inputmethod.InputMethodSubtype.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.changeInputMethodSubtype(_arg0);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.view.IInputMethod
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
public void attachToken(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_attachToken, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void bindInput(android.view.inputmethod.InputBinding binding) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((binding!=null)) {
_data.writeInt(1);
binding.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_bindInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void unbindInput() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_unbindInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void startInput(com.android.internal.view.IInputContext inputContext, android.view.inputmethod.EditorInfo attribute) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((inputContext!=null))?(inputContext.asBinder()):(null)));
if ((attribute!=null)) {
_data.writeInt(1);
attribute.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_startInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void restartInput(com.android.internal.view.IInputContext inputContext, android.view.inputmethod.EditorInfo attribute) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((inputContext!=null))?(inputContext.asBinder()):(null)));
if ((attribute!=null)) {
_data.writeInt(1);
attribute.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_restartInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void createSession(com.android.internal.view.IInputMethodCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_createSession, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void setSessionEnabled(com.android.internal.view.IInputMethodSession session, boolean enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
_data.writeInt(((enabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setSessionEnabled, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void revokeSession(com.android.internal.view.IInputMethodSession session) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((session!=null))?(session.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_revokeSession, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void showSoftInput(int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(flags);
if ((resultReceiver!=null)) {
_data.writeInt(1);
resultReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_showSoftInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void hideSoftInput(int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(flags);
if ((resultReceiver!=null)) {
_data.writeInt(1);
resultReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_hideSoftInput, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype subtype) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((subtype!=null)) {
_data.writeInt(1);
subtype.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_changeInputMethodSubtype, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_attachToken = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_bindInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_unbindInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_startInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_restartInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_createSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setSessionEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_revokeSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_showSoftInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_hideSoftInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_changeInputMethodSubtype = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
}
public void attachToken(android.os.IBinder token) throws android.os.RemoteException;
public void bindInput(android.view.inputmethod.InputBinding binding) throws android.os.RemoteException;
public void unbindInput() throws android.os.RemoteException;
public void startInput(com.android.internal.view.IInputContext inputContext, android.view.inputmethod.EditorInfo attribute) throws android.os.RemoteException;
public void restartInput(com.android.internal.view.IInputContext inputContext, android.view.inputmethod.EditorInfo attribute) throws android.os.RemoteException;
public void createSession(com.android.internal.view.IInputMethodCallback callback) throws android.os.RemoteException;
public void setSessionEnabled(com.android.internal.view.IInputMethodSession session, boolean enabled) throws android.os.RemoteException;
public void revokeSession(com.android.internal.view.IInputMethodSession session) throws android.os.RemoteException;
public void showSoftInput(int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException;
public void hideSoftInput(int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException;
public void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype subtype) throws android.os.RemoteException;
}
