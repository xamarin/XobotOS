/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/view/IInputMethodManager.aidl
 */
package com.android.internal.view;
/**
 * Public interface to the global input method manager, used by all client
 * applications.
 */
public interface IInputMethodManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.view.IInputMethodManager
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.view.IInputMethodManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.view.IInputMethodManager interface,
 * generating a proxy if needed.
 */
public static com.android.internal.view.IInputMethodManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.view.IInputMethodManager))) {
return ((com.android.internal.view.IInputMethodManager)iin);
}
return new com.android.internal.view.IInputMethodManager.Stub.Proxy(obj);
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
case TRANSACTION_getInputMethodList:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.view.inputmethod.InputMethodInfo> _result = this.getInputMethodList();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_getEnabledInputMethodList:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.view.inputmethod.InputMethodInfo> _result = this.getEnabledInputMethodList();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_getEnabledInputMethodSubtypeList:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.InputMethodInfo _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.inputmethod.InputMethodInfo.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
java.util.List<android.view.inputmethod.InputMethodSubtype> _result = this.getEnabledInputMethodSubtypeList(_arg0, _arg1);
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_getLastInputMethodSubtype:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.InputMethodSubtype _result = this.getLastInputMethodSubtype();
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
case TRANSACTION_getShortcutInputMethodsAndSubtypes:
{
data.enforceInterface(DESCRIPTOR);
java.util.List _result = this.getShortcutInputMethodsAndSubtypes();
reply.writeNoException();
reply.writeList(_result);
return true;
}
case TRANSACTION_addClient:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
com.android.internal.view.IInputContext _arg1;
_arg1 = com.android.internal.view.IInputContext.Stub.asInterface(data.readStrongBinder());
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
this.addClient(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_removeClient:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
this.removeClient(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_startInput:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
com.android.internal.view.IInputContext _arg1;
_arg1 = com.android.internal.view.IInputContext.Stub.asInterface(data.readStrongBinder());
android.view.inputmethod.EditorInfo _arg2;
if ((0!=data.readInt())) {
_arg2 = android.view.inputmethod.EditorInfo.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
boolean _arg3;
_arg3 = (0!=data.readInt());
boolean _arg4;
_arg4 = (0!=data.readInt());
com.android.internal.view.InputBindResult _result = this.startInput(_arg0, _arg1, _arg2, _arg3, _arg4);
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
case TRANSACTION_finishInput:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
this.finishInput(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_showSoftInput:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
android.os.ResultReceiver _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.ResultReceiver.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
boolean _result = this.showSoftInput(_arg0, _arg1, _arg2);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_hideSoftInput:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
android.os.ResultReceiver _arg2;
if ((0!=data.readInt())) {
_arg2 = android.os.ResultReceiver.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
boolean _result = this.hideSoftInput(_arg0, _arg1, _arg2);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_windowGainedFocus:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
android.os.IBinder _arg1;
_arg1 = data.readStrongBinder();
boolean _arg2;
_arg2 = (0!=data.readInt());
boolean _arg3;
_arg3 = (0!=data.readInt());
int _arg4;
_arg4 = data.readInt();
boolean _arg5;
_arg5 = (0!=data.readInt());
int _arg6;
_arg6 = data.readInt();
this.windowGainedFocus(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6);
reply.writeNoException();
return true;
}
case TRANSACTION_showInputMethodPickerFromClient:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
this.showInputMethodPickerFromClient(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_showInputMethodAndSubtypeEnablerFromClient:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
java.lang.String _arg1;
_arg1 = data.readString();
this.showInputMethodAndSubtypeEnablerFromClient(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setInputMethod:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
java.lang.String _arg1;
_arg1 = data.readString();
this.setInputMethod(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setInputMethodAndSubtype:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
java.lang.String _arg1;
_arg1 = data.readString();
android.view.inputmethod.InputMethodSubtype _arg2;
if ((0!=data.readInt())) {
_arg2 = android.view.inputmethod.InputMethodSubtype.CREATOR.createFromParcel(data);
}
else {
_arg2 = null;
}
this.setInputMethodAndSubtype(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_hideMySoftInput:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
this.hideMySoftInput(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_showMySoftInput:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
this.showMySoftInput(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_updateStatusIcon:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
this.updateStatusIcon(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_setImeWindowStatus:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
this.setImeWindowStatus(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_registerSuggestionSpansForNotification:
{
data.enforceInterface(DESCRIPTOR);
android.text.style.SuggestionSpan[] _arg0;
_arg0 = data.createTypedArray(android.text.style.SuggestionSpan.CREATOR);
this.registerSuggestionSpansForNotification(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notifySuggestionPicked:
{
data.enforceInterface(DESCRIPTOR);
android.text.style.SuggestionSpan _arg0;
if ((0!=data.readInt())) {
_arg0 = android.text.style.SuggestionSpan.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
boolean _result = this.notifySuggestionPicked(_arg0, _arg1, _arg2);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getCurrentInputMethodSubtype:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.InputMethodSubtype _result = this.getCurrentInputMethodSubtype();
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
case TRANSACTION_setCurrentInputMethodSubtype:
{
data.enforceInterface(DESCRIPTOR);
android.view.inputmethod.InputMethodSubtype _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.inputmethod.InputMethodSubtype.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _result = this.setCurrentInputMethodSubtype(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_switchToLastInputMethod:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
boolean _result = this.switchToLastInputMethod(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setInputMethodEnabled:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _arg1;
_arg1 = (0!=data.readInt());
boolean _result = this.setInputMethodEnabled(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setAdditionalInputMethodSubtypes:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.view.inputmethod.InputMethodSubtype[] _arg1;
_arg1 = data.createTypedArray(android.view.inputmethod.InputMethodSubtype.CREATOR);
this.setAdditionalInputMethodSubtypes(_arg0, _arg1);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.view.IInputMethodManager
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
public java.util.List<android.view.inputmethod.InputMethodInfo> getInputMethodList() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.view.inputmethod.InputMethodInfo> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getInputMethodList, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.view.inputmethod.InputMethodInfo.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public java.util.List<android.view.inputmethod.InputMethodInfo> getEnabledInputMethodList() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.view.inputmethod.InputMethodInfo> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getEnabledInputMethodList, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.view.inputmethod.InputMethodInfo.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public java.util.List<android.view.inputmethod.InputMethodSubtype> getEnabledInputMethodSubtypeList(android.view.inputmethod.InputMethodInfo imi, boolean allowsImplicitlySelectedSubtypes) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.view.inputmethod.InputMethodSubtype> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((imi!=null)) {
_data.writeInt(1);
imi.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((allowsImplicitlySelectedSubtypes)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_getEnabledInputMethodSubtypeList, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.view.inputmethod.InputMethodSubtype.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.view.inputmethod.InputMethodSubtype getLastInputMethodSubtype() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.inputmethod.InputMethodSubtype _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getLastInputMethodSubtype, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.view.inputmethod.InputMethodSubtype.CREATOR.createFromParcel(_reply);
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
// TODO: We should change the return type from List to List<Parcelable>
// Currently there is a bug that aidl doesn't accept List<Parcelable>

public java.util.List getShortcutInputMethodsAndSubtypes() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getShortcutInputMethodsAndSubtypes, _data, _reply, 0);
_reply.readException();
java.lang.ClassLoader cl = (java.lang.ClassLoader)this.getClass().getClassLoader();
_result = _reply.readArrayList(cl);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void addClient(com.android.internal.view.IInputMethodClient client, com.android.internal.view.IInputContext inputContext, int uid, int pid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
_data.writeStrongBinder((((inputContext!=null))?(inputContext.asBinder()):(null)));
_data.writeInt(uid);
_data.writeInt(pid);
mRemote.transact(Stub.TRANSACTION_addClient, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removeClient(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_removeClient, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public com.android.internal.view.InputBindResult startInput(com.android.internal.view.IInputMethodClient client, com.android.internal.view.IInputContext inputContext, android.view.inputmethod.EditorInfo attribute, boolean initial, boolean needResult) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
com.android.internal.view.InputBindResult _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
_data.writeStrongBinder((((inputContext!=null))?(inputContext.asBinder()):(null)));
if ((attribute!=null)) {
_data.writeInt(1);
attribute.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((initial)?(1):(0)));
_data.writeInt(((needResult)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_startInput, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = com.android.internal.view.InputBindResult.CREATOR.createFromParcel(_reply);
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
public void finishInput(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_finishInput, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean showSoftInput(com.android.internal.view.IInputMethodClient client, int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
_data.writeInt(flags);
if ((resultReceiver!=null)) {
_data.writeInt(1);
resultReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_showSoftInput, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean hideSoftInput(com.android.internal.view.IInputMethodClient client, int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
_data.writeInt(flags);
if ((resultReceiver!=null)) {
_data.writeInt(1);
resultReceiver.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_hideSoftInput, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void windowGainedFocus(com.android.internal.view.IInputMethodClient client, android.os.IBinder windowToken, boolean viewHasFocus, boolean isTextEditor, int softInputMode, boolean first, int windowFlags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
_data.writeStrongBinder(windowToken);
_data.writeInt(((viewHasFocus)?(1):(0)));
_data.writeInt(((isTextEditor)?(1):(0)));
_data.writeInt(softInputMode);
_data.writeInt(((first)?(1):(0)));
_data.writeInt(windowFlags);
mRemote.transact(Stub.TRANSACTION_windowGainedFocus, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void showInputMethodPickerFromClient(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_showInputMethodPickerFromClient, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void showInputMethodAndSubtypeEnablerFromClient(com.android.internal.view.IInputMethodClient client, java.lang.String topId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
_data.writeString(topId);
mRemote.transact(Stub.TRANSACTION_showInputMethodAndSubtypeEnablerFromClient, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setInputMethod(android.os.IBinder token, java.lang.String id) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeString(id);
mRemote.transact(Stub.TRANSACTION_setInputMethod, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setInputMethodAndSubtype(android.os.IBinder token, java.lang.String id, android.view.inputmethod.InputMethodSubtype subtype) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeString(id);
if ((subtype!=null)) {
_data.writeInt(1);
subtype.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setInputMethodAndSubtype, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void hideMySoftInput(android.os.IBinder token, int flags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(flags);
mRemote.transact(Stub.TRANSACTION_hideMySoftInput, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void showMySoftInput(android.os.IBinder token, int flags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(flags);
mRemote.transact(Stub.TRANSACTION_showMySoftInput, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void updateStatusIcon(android.os.IBinder token, java.lang.String packageName, int iconId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeString(packageName);
_data.writeInt(iconId);
mRemote.transact(Stub.TRANSACTION_updateStatusIcon, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(vis);
_data.writeInt(backDisposition);
mRemote.transact(Stub.TRANSACTION_setImeWindowStatus, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void registerSuggestionSpansForNotification(android.text.style.SuggestionSpan[] spans) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeTypedArray(spans, 0);
mRemote.transact(Stub.TRANSACTION_registerSuggestionSpansForNotification, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean notifySuggestionPicked(android.text.style.SuggestionSpan span, java.lang.String originalString, int index) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((span!=null)) {
_data.writeInt(1);
span.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeString(originalString);
_data.writeInt(index);
mRemote.transact(Stub.TRANSACTION_notifySuggestionPicked, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.view.inputmethod.InputMethodSubtype getCurrentInputMethodSubtype() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.inputmethod.InputMethodSubtype _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getCurrentInputMethodSubtype, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.view.inputmethod.InputMethodSubtype.CREATOR.createFromParcel(_reply);
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
public boolean setCurrentInputMethodSubtype(android.view.inputmethod.InputMethodSubtype subtype) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((subtype!=null)) {
_data.writeInt(1);
subtype.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setCurrentInputMethodSubtype, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean switchToLastInputMethod(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_switchToLastInputMethod, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean setInputMethodEnabled(java.lang.String id, boolean enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(id);
_data.writeInt(((enabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setInputMethodEnabled, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setAdditionalInputMethodSubtypes(java.lang.String id, android.view.inputmethod.InputMethodSubtype[] subtypes) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(id);
_data.writeTypedArray(subtypes, 0);
mRemote.transact(Stub.TRANSACTION_setAdditionalInputMethodSubtypes, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_getInputMethodList = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getEnabledInputMethodList = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getEnabledInputMethodSubtypeList = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getLastInputMethodSubtype = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_getShortcutInputMethodsAndSubtypes = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_addClient = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_removeClient = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_startInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_finishInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_showSoftInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_hideSoftInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_windowGainedFocus = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_showInputMethodPickerFromClient = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_showInputMethodAndSubtypeEnablerFromClient = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_setInputMethod = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_setInputMethodAndSubtype = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_hideMySoftInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_showMySoftInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_updateStatusIcon = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_setImeWindowStatus = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_registerSuggestionSpansForNotification = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
static final int TRANSACTION_notifySuggestionPicked = (android.os.IBinder.FIRST_CALL_TRANSACTION + 21);
static final int TRANSACTION_getCurrentInputMethodSubtype = (android.os.IBinder.FIRST_CALL_TRANSACTION + 22);
static final int TRANSACTION_setCurrentInputMethodSubtype = (android.os.IBinder.FIRST_CALL_TRANSACTION + 23);
static final int TRANSACTION_switchToLastInputMethod = (android.os.IBinder.FIRST_CALL_TRANSACTION + 24);
static final int TRANSACTION_setInputMethodEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 25);
static final int TRANSACTION_setAdditionalInputMethodSubtypes = (android.os.IBinder.FIRST_CALL_TRANSACTION + 26);
}
public java.util.List<android.view.inputmethod.InputMethodInfo> getInputMethodList() throws android.os.RemoteException;
public java.util.List<android.view.inputmethod.InputMethodInfo> getEnabledInputMethodList() throws android.os.RemoteException;
public java.util.List<android.view.inputmethod.InputMethodSubtype> getEnabledInputMethodSubtypeList(android.view.inputmethod.InputMethodInfo imi, boolean allowsImplicitlySelectedSubtypes) throws android.os.RemoteException;
public android.view.inputmethod.InputMethodSubtype getLastInputMethodSubtype() throws android.os.RemoteException;
// TODO: We should change the return type from List to List<Parcelable>
// Currently there is a bug that aidl doesn't accept List<Parcelable>

public java.util.List getShortcutInputMethodsAndSubtypes() throws android.os.RemoteException;
public void addClient(com.android.internal.view.IInputMethodClient client, com.android.internal.view.IInputContext inputContext, int uid, int pid) throws android.os.RemoteException;
public void removeClient(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException;
public com.android.internal.view.InputBindResult startInput(com.android.internal.view.IInputMethodClient client, com.android.internal.view.IInputContext inputContext, android.view.inputmethod.EditorInfo attribute, boolean initial, boolean needResult) throws android.os.RemoteException;
public void finishInput(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException;
public boolean showSoftInput(com.android.internal.view.IInputMethodClient client, int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException;
public boolean hideSoftInput(com.android.internal.view.IInputMethodClient client, int flags, android.os.ResultReceiver resultReceiver) throws android.os.RemoteException;
public void windowGainedFocus(com.android.internal.view.IInputMethodClient client, android.os.IBinder windowToken, boolean viewHasFocus, boolean isTextEditor, int softInputMode, boolean first, int windowFlags) throws android.os.RemoteException;
public void showInputMethodPickerFromClient(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException;
public void showInputMethodAndSubtypeEnablerFromClient(com.android.internal.view.IInputMethodClient client, java.lang.String topId) throws android.os.RemoteException;
public void setInputMethod(android.os.IBinder token, java.lang.String id) throws android.os.RemoteException;
public void setInputMethodAndSubtype(android.os.IBinder token, java.lang.String id, android.view.inputmethod.InputMethodSubtype subtype) throws android.os.RemoteException;
public void hideMySoftInput(android.os.IBinder token, int flags) throws android.os.RemoteException;
public void showMySoftInput(android.os.IBinder token, int flags) throws android.os.RemoteException;
public void updateStatusIcon(android.os.IBinder token, java.lang.String packageName, int iconId) throws android.os.RemoteException;
public void setImeWindowStatus(android.os.IBinder token, int vis, int backDisposition) throws android.os.RemoteException;
public void registerSuggestionSpansForNotification(android.text.style.SuggestionSpan[] spans) throws android.os.RemoteException;
public boolean notifySuggestionPicked(android.text.style.SuggestionSpan span, java.lang.String originalString, int index) throws android.os.RemoteException;
public android.view.inputmethod.InputMethodSubtype getCurrentInputMethodSubtype() throws android.os.RemoteException;
public boolean setCurrentInputMethodSubtype(android.view.inputmethod.InputMethodSubtype subtype) throws android.os.RemoteException;
public boolean switchToLastInputMethod(android.os.IBinder token) throws android.os.RemoteException;
public boolean setInputMethodEnabled(java.lang.String id, boolean enabled) throws android.os.RemoteException;
public void setAdditionalInputMethodSubtypes(java.lang.String id, android.view.inputmethod.InputMethodSubtype[] subtypes) throws android.os.RemoteException;
}
