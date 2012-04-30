/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/view/IWindowManager.aidl
 */
package android.view;
/**
 * System private interface to the window manager.
 *
 * {@hide}
 */
public interface IWindowManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.view.IWindowManager
{
private static final java.lang.String DESCRIPTOR = "android.view.IWindowManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.view.IWindowManager interface,
 * generating a proxy if needed.
 */
public static android.view.IWindowManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.view.IWindowManager))) {
return ((android.view.IWindowManager)iin);
}
return new android.view.IWindowManager.Stub.Proxy(obj);
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
case TRANSACTION_startViewServer:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _result = this.startViewServer(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_stopViewServer:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.stopViewServer();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_isViewServerRunning:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isViewServerRunning();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_openSession:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
com.android.internal.view.IInputContext _arg1;
_arg1 = com.android.internal.view.IInputContext.Stub.asInterface(data.readStrongBinder());
android.view.IWindowSession _result = this.openSession(_arg0, _arg1);
reply.writeNoException();
reply.writeStrongBinder((((_result!=null))?(_result.asBinder()):(null)));
return true;
}
case TRANSACTION_inputMethodClientHasFocus:
{
data.enforceInterface(DESCRIPTOR);
com.android.internal.view.IInputMethodClient _arg0;
_arg0 = com.android.internal.view.IInputMethodClient.Stub.asInterface(data.readStrongBinder());
boolean _result = this.inputMethodClientHasFocus(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getDisplaySize:
{
data.enforceInterface(DESCRIPTOR);
android.graphics.Point _arg0;
_arg0 = new android.graphics.Point();
this.getDisplaySize(_arg0);
reply.writeNoException();
if ((_arg0!=null)) {
reply.writeInt(1);
_arg0.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_getRealDisplaySize:
{
data.enforceInterface(DESCRIPTOR);
android.graphics.Point _arg0;
_arg0 = new android.graphics.Point();
this.getRealDisplaySize(_arg0);
reply.writeNoException();
if ((_arg0!=null)) {
reply.writeInt(1);
_arg0.writeToParcel(reply, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
}
else {
reply.writeInt(0);
}
return true;
}
case TRANSACTION_getMaximumSizeDimension:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getMaximumSizeDimension();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setForcedDisplaySize:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.setForcedDisplaySize(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_clearForcedDisplaySize:
{
data.enforceInterface(DESCRIPTOR);
this.clearForcedDisplaySize();
reply.writeNoException();
return true;
}
case TRANSACTION_canStatusBarHide:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.canStatusBarHide();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_injectKeyEvent:
{
data.enforceInterface(DESCRIPTOR);
android.view.KeyEvent _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.KeyEvent.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
boolean _result = this.injectKeyEvent(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_injectPointerEvent:
{
data.enforceInterface(DESCRIPTOR);
android.view.MotionEvent _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.MotionEvent.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
boolean _result = this.injectPointerEvent(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_injectTrackballEvent:
{
data.enforceInterface(DESCRIPTOR);
android.view.MotionEvent _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.MotionEvent.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
boolean _result = this.injectTrackballEvent(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_injectInputEventNoWait:
{
data.enforceInterface(DESCRIPTOR);
android.view.InputEvent _arg0;
if ((0!=data.readInt())) {
_arg0 = android.view.InputEvent.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _result = this.injectInputEventNoWait(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_pauseKeyDispatching:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.pauseKeyDispatching(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_resumeKeyDispatching:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.resumeKeyDispatching(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setEventDispatching:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.setEventDispatching(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_addWindowToken:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
this.addWindowToken(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeWindowToken:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.removeWindowToken(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_addAppToken:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.view.IApplicationToken _arg1;
_arg1 = android.view.IApplicationToken.Stub.asInterface(data.readStrongBinder());
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
boolean _arg4;
_arg4 = (0!=data.readInt());
this.addAppToken(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
return true;
}
case TRANSACTION_setAppGroupId:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
this.setAppGroupId(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setAppOrientation:
{
data.enforceInterface(DESCRIPTOR);
android.view.IApplicationToken _arg0;
_arg0 = android.view.IApplicationToken.Stub.asInterface(data.readStrongBinder());
int _arg1;
_arg1 = data.readInt();
this.setAppOrientation(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getAppOrientation:
{
data.enforceInterface(DESCRIPTOR);
android.view.IApplicationToken _arg0;
_arg0 = android.view.IApplicationToken.Stub.asInterface(data.readStrongBinder());
int _result = this.getAppOrientation(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setFocusedApp:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setFocusedApp(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_prepareAppTransition:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.prepareAppTransition(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getPendingAppTransition:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getPendingAppTransition();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_overridePendingAppTransition:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
this.overridePendingAppTransition(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_executeAppTransition:
{
data.enforceInterface(DESCRIPTOR);
this.executeAppTransition();
reply.writeNoException();
return true;
}
case TRANSACTION_setAppStartingWindow:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
java.lang.String _arg1;
_arg1 = data.readString();
int _arg2;
_arg2 = data.readInt();
android.content.res.CompatibilityInfo _arg3;
if ((0!=data.readInt())) {
_arg3 = android.content.res.CompatibilityInfo.CREATOR.createFromParcel(data);
}
else {
_arg3 = null;
}
java.lang.CharSequence _arg4;
if ((0!=data.readInt())) {
_arg4 = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(data);
}
else {
_arg4 = null;
}
int _arg5;
_arg5 = data.readInt();
int _arg6;
_arg6 = data.readInt();
int _arg7;
_arg7 = data.readInt();
android.os.IBinder _arg8;
_arg8 = data.readStrongBinder();
boolean _arg9;
_arg9 = (0!=data.readInt());
this.setAppStartingWindow(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8, _arg9);
reply.writeNoException();
return true;
}
case TRANSACTION_setAppWillBeHidden:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.setAppWillBeHidden(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setAppVisibility:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setAppVisibility(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_startAppFreezingScreen:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
this.startAppFreezingScreen(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_stopAppFreezingScreen:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.stopAppFreezingScreen(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeAppToken:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.removeAppToken(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_moveAppToken:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.os.IBinder _arg1;
_arg1 = data.readStrongBinder();
this.moveAppToken(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_moveAppTokensToTop:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.os.IBinder> _arg0;
_arg0 = data.createBinderArrayList();
this.moveAppTokensToTop(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_moveAppTokensToBottom:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.os.IBinder> _arg0;
_arg0 = data.createBinderArrayList();
this.moveAppTokensToBottom(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_updateOrientationFromAppTokens:
{
data.enforceInterface(DESCRIPTOR);
android.content.res.Configuration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.res.Configuration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.os.IBinder _arg1;
_arg1 = data.readStrongBinder();
android.content.res.Configuration _result = this.updateOrientationFromAppTokens(_arg0, _arg1);
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
case TRANSACTION_setNewConfiguration:
{
data.enforceInterface(DESCRIPTOR);
android.content.res.Configuration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.res.Configuration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.setNewConfiguration(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_disableKeyguard:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
java.lang.String _arg1;
_arg1 = data.readString();
this.disableKeyguard(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_reenableKeyguard:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
this.reenableKeyguard(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_exitKeyguardSecurely:
{
data.enforceInterface(DESCRIPTOR);
android.view.IOnKeyguardExitResult _arg0;
_arg0 = android.view.IOnKeyguardExitResult.Stub.asInterface(data.readStrongBinder());
this.exitKeyguardSecurely(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_isKeyguardLocked:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isKeyguardLocked();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_isKeyguardSecure:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isKeyguardSecure();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_inKeyguardRestrictedInputMode:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.inKeyguardRestrictedInputMode();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_dismissKeyguard:
{
data.enforceInterface(DESCRIPTOR);
this.dismissKeyguard();
reply.writeNoException();
return true;
}
case TRANSACTION_closeSystemDialogs:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.closeSystemDialogs(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getAnimationScale:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
float _result = this.getAnimationScale(_arg0);
reply.writeNoException();
reply.writeFloat(_result);
return true;
}
case TRANSACTION_getAnimationScales:
{
data.enforceInterface(DESCRIPTOR);
float[] _result = this.getAnimationScales();
reply.writeNoException();
reply.writeFloatArray(_result);
return true;
}
case TRANSACTION_setAnimationScale:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
float _arg1;
_arg1 = data.readFloat();
this.setAnimationScale(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setAnimationScales:
{
data.enforceInterface(DESCRIPTOR);
float[] _arg0;
_arg0 = data.createFloatArray();
this.setAnimationScales(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getSwitchState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _result = this.getSwitchState(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getSwitchStateForDevice:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _result = this.getSwitchStateForDevice(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getScancodeState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _result = this.getScancodeState(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getScancodeStateForDevice:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _result = this.getScancodeStateForDevice(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getTrackballScancodeState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _result = this.getTrackballScancodeState(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getDPadScancodeState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _result = this.getDPadScancodeState(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getKeycodeState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _result = this.getKeycodeState(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getKeycodeStateForDevice:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _result = this.getKeycodeStateForDevice(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getTrackballKeycodeState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _result = this.getTrackballKeycodeState(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getDPadKeycodeState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _result = this.getDPadKeycodeState(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_monitorInput:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.view.InputChannel _result = this.monitorInput(_arg0);
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
case TRANSACTION_hasKeys:
{
data.enforceInterface(DESCRIPTOR);
int[] _arg0;
_arg0 = data.createIntArray();
boolean[] _arg1;
_arg1 = data.createBooleanArray();
boolean _result = this.hasKeys(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
reply.writeBooleanArray(_arg1);
return true;
}
case TRANSACTION_getInputDevice:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.view.InputDevice _result = this.getInputDevice(_arg0);
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
case TRANSACTION_getInputDeviceIds:
{
data.enforceInterface(DESCRIPTOR);
int[] _result = this.getInputDeviceIds();
reply.writeNoException();
reply.writeIntArray(_result);
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
case TRANSACTION_showStrictModeViolation:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.showStrictModeViolation(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setStrictModeVisualIndicatorPreference:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.setStrictModeVisualIndicatorPreference(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_updateRotation:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.updateRotation(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getRotation:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getRotation();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_watchRotation:
{
data.enforceInterface(DESCRIPTOR);
android.view.IRotationWatcher _arg0;
_arg0 = android.view.IRotationWatcher.Stub.asInterface(data.readStrongBinder());
int _result = this.watchRotation(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getPreferredOptionsPanelGravity:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getPreferredOptionsPanelGravity();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_freezeRotation:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.freezeRotation(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_thawRotation:
{
data.enforceInterface(DESCRIPTOR);
this.thawRotation();
reply.writeNoException();
return true;
}
case TRANSACTION_screenshotApplications:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
android.graphics.Bitmap _result = this.screenshotApplications(_arg0, _arg1, _arg2);
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
case TRANSACTION_statusBarVisibilityChanged:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.statusBarVisibilityChanged(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setPointerSpeed:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.setPointerSpeed(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_waitForWindowDrawn:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
android.os.IRemoteCallback _arg1;
_arg1 = android.os.IRemoteCallback.Stub.asInterface(data.readStrongBinder());
this.waitForWindowDrawn(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_hasNavigationBar:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.hasNavigationBar();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.view.IWindowManager
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
     * ===== NOTICE =====
     * The first three methods must remain the first three methods. Scripts
     * and tools rely on their transaction number to work properly.
     */// This is used for debugging

public boolean startViewServer(int port) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(port);
mRemote.transact(Stub.TRANSACTION_startViewServer, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
// Transaction #1

public boolean stopViewServer() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_stopViewServer, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
// Transaction #2

public boolean isViewServerRunning() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isViewServerRunning, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
// Transaction #3

public android.view.IWindowSession openSession(com.android.internal.view.IInputMethodClient client, com.android.internal.view.IInputContext inputContext) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.IWindowSession _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
_data.writeStrongBinder((((inputContext!=null))?(inputContext.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_openSession, _data, _reply, 0);
_reply.readException();
_result = android.view.IWindowSession.Stub.asInterface(_reply.readStrongBinder());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean inputMethodClientHasFocus(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((client!=null))?(client.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_inputMethodClientHasFocus, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void getDisplaySize(android.graphics.Point size) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getDisplaySize, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
size.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void getRealDisplaySize(android.graphics.Point size) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getRealDisplaySize, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
size.readFromParcel(_reply);
}
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getMaximumSizeDimension() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getMaximumSizeDimension, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setForcedDisplaySize(int longDimen, int shortDimen) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(longDimen);
_data.writeInt(shortDimen);
mRemote.transact(Stub.TRANSACTION_setForcedDisplaySize, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void clearForcedDisplaySize() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_clearForcedDisplaySize, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// Is device configured with a hideable status bar or a tablet system bar?

public boolean canStatusBarHide() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_canStatusBarHide, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
// These can only be called when injecting events to your own window,
// or by holding the INJECT_EVENTS permission.  These methods may block
// until pending input events are finished being dispatched even when 'sync' is false.
// Avoid calling these methods on your UI thread or use the 'NoWait' version instead.

public boolean injectKeyEvent(android.view.KeyEvent ev, boolean sync) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ev!=null)) {
_data.writeInt(1);
ev.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((sync)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_injectKeyEvent, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean injectPointerEvent(android.view.MotionEvent ev, boolean sync) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ev!=null)) {
_data.writeInt(1);
ev.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((sync)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_injectPointerEvent, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean injectTrackballEvent(android.view.MotionEvent ev, boolean sync) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ev!=null)) {
_data.writeInt(1);
ev.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((sync)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_injectTrackballEvent, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean injectInputEventNoWait(android.view.InputEvent ev) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ev!=null)) {
_data.writeInt(1);
ev.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_injectInputEventNoWait, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
// These can only be called when holding the MANAGE_APP_TOKENS permission.

public void pauseKeyDispatching(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_pauseKeyDispatching, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void resumeKeyDispatching(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_resumeKeyDispatching, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setEventDispatching(boolean enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((enabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setEventDispatching, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void addWindowToken(android.os.IBinder token, int type) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(type);
mRemote.transact(Stub.TRANSACTION_addWindowToken, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removeWindowToken(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_removeWindowToken, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void addAppToken(int addPos, android.view.IApplicationToken token, int groupId, int requestedOrientation, boolean fullscreen) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(addPos);
_data.writeStrongBinder((((token!=null))?(token.asBinder()):(null)));
_data.writeInt(groupId);
_data.writeInt(requestedOrientation);
_data.writeInt(((fullscreen)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_addAppToken, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setAppGroupId(android.os.IBinder token, int groupId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(groupId);
mRemote.transact(Stub.TRANSACTION_setAppGroupId, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setAppOrientation(android.view.IApplicationToken token, int requestedOrientation) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((token!=null))?(token.asBinder()):(null)));
_data.writeInt(requestedOrientation);
mRemote.transact(Stub.TRANSACTION_setAppOrientation, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getAppOrientation(android.view.IApplicationToken token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((token!=null))?(token.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_getAppOrientation, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setFocusedApp(android.os.IBinder token, boolean moveFocusNow) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(((moveFocusNow)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setFocusedApp, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void prepareAppTransition(int transit, boolean alwaysKeepCurrent) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(transit);
_data.writeInt(((alwaysKeepCurrent)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_prepareAppTransition, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getPendingAppTransition() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getPendingAppTransition, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void overridePendingAppTransition(java.lang.String packageName, int enterAnim, int exitAnim) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(packageName);
_data.writeInt(enterAnim);
_data.writeInt(exitAnim);
mRemote.transact(Stub.TRANSACTION_overridePendingAppTransition, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void executeAppTransition() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_executeAppTransition, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setAppStartingWindow(android.os.IBinder token, java.lang.String pkg, int theme, android.content.res.CompatibilityInfo compatInfo, java.lang.CharSequence nonLocalizedLabel, int labelRes, int icon, int windowFlags, android.os.IBinder transferFrom, boolean createIfNeeded) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeString(pkg);
_data.writeInt(theme);
if ((compatInfo!=null)) {
_data.writeInt(1);
compatInfo.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((nonLocalizedLabel!=null)) {
_data.writeInt(1);
android.text.TextUtils.writeToParcel(nonLocalizedLabel, _data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(labelRes);
_data.writeInt(icon);
_data.writeInt(windowFlags);
_data.writeStrongBinder(transferFrom);
_data.writeInt(((createIfNeeded)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setAppStartingWindow, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setAppWillBeHidden(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_setAppWillBeHidden, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setAppVisibility(android.os.IBinder token, boolean visible) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(((visible)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setAppVisibility, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void startAppFreezingScreen(android.os.IBinder token, int configChanges) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(configChanges);
mRemote.transact(Stub.TRANSACTION_startAppFreezingScreen, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void stopAppFreezingScreen(android.os.IBinder token, boolean force) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeInt(((force)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_stopAppFreezingScreen, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void removeAppToken(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_removeAppToken, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void moveAppToken(int index, android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(index);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_moveAppToken, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void moveAppTokensToTop(java.util.List<android.os.IBinder> tokens) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeBinderList(tokens);
mRemote.transact(Stub.TRANSACTION_moveAppTokensToTop, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void moveAppTokensToBottom(java.util.List<android.os.IBinder> tokens) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeBinderList(tokens);
mRemote.transact(Stub.TRANSACTION_moveAppTokensToBottom, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// Re-evaluate the current orientation from the caller's state.
// If there is a change, the new Configuration is returned and the
// caller must call setNewConfiguration() sometime later.

public android.content.res.Configuration updateOrientationFromAppTokens(android.content.res.Configuration currentConfig, android.os.IBinder freezeThisOneIfNeeded) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.content.res.Configuration _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((currentConfig!=null)) {
_data.writeInt(1);
currentConfig.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeStrongBinder(freezeThisOneIfNeeded);
mRemote.transact(Stub.TRANSACTION_updateOrientationFromAppTokens, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.content.res.Configuration.CREATOR.createFromParcel(_reply);
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
public void setNewConfiguration(android.content.res.Configuration config) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((config!=null)) {
_data.writeInt(1);
config.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setNewConfiguration, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// these require DISABLE_KEYGUARD permission

public void disableKeyguard(android.os.IBinder token, java.lang.String tag) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeString(tag);
mRemote.transact(Stub.TRANSACTION_disableKeyguard, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void reenableKeyguard(android.os.IBinder token) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
mRemote.transact(Stub.TRANSACTION_reenableKeyguard, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void exitKeyguardSecurely(android.view.IOnKeyguardExitResult callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_exitKeyguardSecurely, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean isKeyguardLocked() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isKeyguardLocked, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean isKeyguardSecure() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isKeyguardSecure, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean inKeyguardRestrictedInputMode() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_inKeyguardRestrictedInputMode, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void dismissKeyguard() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_dismissKeyguard, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void closeSystemDialogs(java.lang.String reason) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(reason);
mRemote.transact(Stub.TRANSACTION_closeSystemDialogs, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// These can only be called with the SET_ANIMATON_SCALE permission.

public float getAnimationScale(int which) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
float _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(which);
mRemote.transact(Stub.TRANSACTION_getAnimationScale, _data, _reply, 0);
_reply.readException();
_result = _reply.readFloat();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public float[] getAnimationScales() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
float[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getAnimationScales, _data, _reply, 0);
_reply.readException();
_result = _reply.createFloatArray();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setAnimationScale(int which, float scale) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(which);
_data.writeFloat(scale);
mRemote.transact(Stub.TRANSACTION_setAnimationScale, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setAnimationScales(float[] scales) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeFloatArray(scales);
mRemote.transact(Stub.TRANSACTION_setAnimationScales, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// These require the READ_INPUT_STATE permission.

public int getSwitchState(int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getSwitchState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getSwitchStateForDevice(int devid, int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(devid);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getSwitchStateForDevice, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getScancodeState(int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getScancodeState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getScancodeStateForDevice(int devid, int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(devid);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getScancodeStateForDevice, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getTrackballScancodeState(int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getTrackballScancodeState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getDPadScancodeState(int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getDPadScancodeState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getKeycodeState(int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getKeycodeState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getKeycodeStateForDevice(int devid, int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(devid);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getKeycodeStateForDevice, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getTrackballKeycodeState(int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getTrackballKeycodeState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getDPadKeycodeState(int sw) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(sw);
mRemote.transact(Stub.TRANSACTION_getDPadKeycodeState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.view.InputChannel monitorInput(java.lang.String inputChannelName) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.InputChannel _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(inputChannelName);
mRemote.transact(Stub.TRANSACTION_monitorInput, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.view.InputChannel.CREATOR.createFromParcel(_reply);
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
// Report whether the hardware supports the given keys; returns true if successful

public boolean hasKeys(int[] keycodes, boolean[] keyExists) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeIntArray(keycodes);
_data.writeBooleanArray(keyExists);
mRemote.transact(Stub.TRANSACTION_hasKeys, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
_reply.readBooleanArray(keyExists);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
// Get input device information.

public android.view.InputDevice getInputDevice(int deviceId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.view.InputDevice _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(deviceId);
mRemote.transact(Stub.TRANSACTION_getInputDevice, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.view.InputDevice.CREATOR.createFromParcel(_reply);
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
public int[] getInputDeviceIds() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getInputDeviceIds, _data, _reply, 0);
_reply.readException();
_result = _reply.createIntArray();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
// For testing

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
// For StrictMode flashing a red border on violations from the UI
// thread.  The uid/pid is implicit from the Binder call, and the Window
// Manager uses that to determine whether or not the red border should
// actually be shown.  (it will be ignored that pid doesn't have windows
// on screen)

public void showStrictModeViolation(boolean on) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((on)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_showStrictModeViolation, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// Proxy to set the system property for whether the flashing
// should be enabled.  The 'enabled' value is null or blank for
// the system default (differs per build variant) or any valid
// boolean string as parsed by SystemProperties.getBoolean().

public void setStrictModeVisualIndicatorPreference(java.lang.String enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(enabled);
mRemote.transact(Stub.TRANSACTION_setStrictModeVisualIndicatorPreference, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// These can only be called with the SET_ORIENTATION permission.
/**
     * Update the current screen rotation based on the current state of
     * the world.
     * @param alwaysSendConfiguration Flag to force a new configuration to
     * be evaluated.  This can be used when there are other parameters in
     * configuration that are changing.
     */
public void updateRotation(boolean alwaysSendConfiguration) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((alwaysSendConfiguration)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_updateRotation, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Retrieve the current screen orientation, constants as per
     * {@link android.view.Surface}.
     */
public int getRotation() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getRotation, _data, _reply, 0);
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
     * Watch the rotation of the screen.  Returns the current rotation,
     * calls back when it changes.
     */
public int watchRotation(android.view.IRotationWatcher watcher) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((watcher!=null))?(watcher.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_watchRotation, _data, _reply, 0);
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
     * Determine the preferred edge of the screen to pin the compact options menu against.
     * @return a Gravity value for the options menu panel
     * @hide
     */
public int getPreferredOptionsPanelGravity() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getPreferredOptionsPanelGravity, _data, _reply, 0);
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
	 * Lock the device orientation to the specified rotation, or to the
	 * current rotation if -1.  Sensor input will be ignored until
	 * thawRotation() is called.
	 * @hide
	 */
public void freezeRotation(int rotation) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(rotation);
mRemote.transact(Stub.TRANSACTION_freezeRotation, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
	 * Release the orientation lock imposed by freezeRotation().
	 * @hide
	 */
public void thawRotation() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_thawRotation, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
	 * Create a screenshot of the applications currently displayed.
	 */
public android.graphics.Bitmap screenshotApplications(android.os.IBinder appToken, int maxWidth, int maxHeight) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.graphics.Bitmap _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(appToken);
_data.writeInt(maxWidth);
_data.writeInt(maxHeight);
mRemote.transact(Stub.TRANSACTION_screenshotApplications, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.graphics.Bitmap.CREATOR.createFromParcel(_reply);
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
     * Called by the status bar to notify Views of changes to System UI visiblity.
     */
public void statusBarVisibilityChanged(int visibility) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(visibility);
mRemote.transact(Stub.TRANSACTION_statusBarVisibilityChanged, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Called by the settings application to temporarily set the pointer speed.
     */
public void setPointerSpeed(int speed) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(speed);
mRemote.transact(Stub.TRANSACTION_setPointerSpeed, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Block until the given window has been drawn to the screen.
     */
public void waitForWindowDrawn(android.os.IBinder token, android.os.IRemoteCallback callback) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(token);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_waitForWindowDrawn, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Device has a software navigation bar (separate from the status bar).
     */
public boolean hasNavigationBar() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_hasNavigationBar, _data, _reply, 0);
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
static final int TRANSACTION_startViewServer = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_stopViewServer = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_isViewServerRunning = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_openSession = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_inputMethodClientHasFocus = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_getDisplaySize = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_getRealDisplaySize = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_getMaximumSizeDimension = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_setForcedDisplaySize = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_clearForcedDisplaySize = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_canStatusBarHide = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_injectKeyEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_injectPointerEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_injectTrackballEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_injectInputEventNoWait = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_pauseKeyDispatching = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_resumeKeyDispatching = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_setEventDispatching = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_addWindowToken = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_removeWindowToken = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_addAppToken = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
static final int TRANSACTION_setAppGroupId = (android.os.IBinder.FIRST_CALL_TRANSACTION + 21);
static final int TRANSACTION_setAppOrientation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 22);
static final int TRANSACTION_getAppOrientation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 23);
static final int TRANSACTION_setFocusedApp = (android.os.IBinder.FIRST_CALL_TRANSACTION + 24);
static final int TRANSACTION_prepareAppTransition = (android.os.IBinder.FIRST_CALL_TRANSACTION + 25);
static final int TRANSACTION_getPendingAppTransition = (android.os.IBinder.FIRST_CALL_TRANSACTION + 26);
static final int TRANSACTION_overridePendingAppTransition = (android.os.IBinder.FIRST_CALL_TRANSACTION + 27);
static final int TRANSACTION_executeAppTransition = (android.os.IBinder.FIRST_CALL_TRANSACTION + 28);
static final int TRANSACTION_setAppStartingWindow = (android.os.IBinder.FIRST_CALL_TRANSACTION + 29);
static final int TRANSACTION_setAppWillBeHidden = (android.os.IBinder.FIRST_CALL_TRANSACTION + 30);
static final int TRANSACTION_setAppVisibility = (android.os.IBinder.FIRST_CALL_TRANSACTION + 31);
static final int TRANSACTION_startAppFreezingScreen = (android.os.IBinder.FIRST_CALL_TRANSACTION + 32);
static final int TRANSACTION_stopAppFreezingScreen = (android.os.IBinder.FIRST_CALL_TRANSACTION + 33);
static final int TRANSACTION_removeAppToken = (android.os.IBinder.FIRST_CALL_TRANSACTION + 34);
static final int TRANSACTION_moveAppToken = (android.os.IBinder.FIRST_CALL_TRANSACTION + 35);
static final int TRANSACTION_moveAppTokensToTop = (android.os.IBinder.FIRST_CALL_TRANSACTION + 36);
static final int TRANSACTION_moveAppTokensToBottom = (android.os.IBinder.FIRST_CALL_TRANSACTION + 37);
static final int TRANSACTION_updateOrientationFromAppTokens = (android.os.IBinder.FIRST_CALL_TRANSACTION + 38);
static final int TRANSACTION_setNewConfiguration = (android.os.IBinder.FIRST_CALL_TRANSACTION + 39);
static final int TRANSACTION_disableKeyguard = (android.os.IBinder.FIRST_CALL_TRANSACTION + 40);
static final int TRANSACTION_reenableKeyguard = (android.os.IBinder.FIRST_CALL_TRANSACTION + 41);
static final int TRANSACTION_exitKeyguardSecurely = (android.os.IBinder.FIRST_CALL_TRANSACTION + 42);
static final int TRANSACTION_isKeyguardLocked = (android.os.IBinder.FIRST_CALL_TRANSACTION + 43);
static final int TRANSACTION_isKeyguardSecure = (android.os.IBinder.FIRST_CALL_TRANSACTION + 44);
static final int TRANSACTION_inKeyguardRestrictedInputMode = (android.os.IBinder.FIRST_CALL_TRANSACTION + 45);
static final int TRANSACTION_dismissKeyguard = (android.os.IBinder.FIRST_CALL_TRANSACTION + 46);
static final int TRANSACTION_closeSystemDialogs = (android.os.IBinder.FIRST_CALL_TRANSACTION + 47);
static final int TRANSACTION_getAnimationScale = (android.os.IBinder.FIRST_CALL_TRANSACTION + 48);
static final int TRANSACTION_getAnimationScales = (android.os.IBinder.FIRST_CALL_TRANSACTION + 49);
static final int TRANSACTION_setAnimationScale = (android.os.IBinder.FIRST_CALL_TRANSACTION + 50);
static final int TRANSACTION_setAnimationScales = (android.os.IBinder.FIRST_CALL_TRANSACTION + 51);
static final int TRANSACTION_getSwitchState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 52);
static final int TRANSACTION_getSwitchStateForDevice = (android.os.IBinder.FIRST_CALL_TRANSACTION + 53);
static final int TRANSACTION_getScancodeState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 54);
static final int TRANSACTION_getScancodeStateForDevice = (android.os.IBinder.FIRST_CALL_TRANSACTION + 55);
static final int TRANSACTION_getTrackballScancodeState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 56);
static final int TRANSACTION_getDPadScancodeState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 57);
static final int TRANSACTION_getKeycodeState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 58);
static final int TRANSACTION_getKeycodeStateForDevice = (android.os.IBinder.FIRST_CALL_TRANSACTION + 59);
static final int TRANSACTION_getTrackballKeycodeState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 60);
static final int TRANSACTION_getDPadKeycodeState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 61);
static final int TRANSACTION_monitorInput = (android.os.IBinder.FIRST_CALL_TRANSACTION + 62);
static final int TRANSACTION_hasKeys = (android.os.IBinder.FIRST_CALL_TRANSACTION + 63);
static final int TRANSACTION_getInputDevice = (android.os.IBinder.FIRST_CALL_TRANSACTION + 64);
static final int TRANSACTION_getInputDeviceIds = (android.os.IBinder.FIRST_CALL_TRANSACTION + 65);
static final int TRANSACTION_setInTouchMode = (android.os.IBinder.FIRST_CALL_TRANSACTION + 66);
static final int TRANSACTION_showStrictModeViolation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 67);
static final int TRANSACTION_setStrictModeVisualIndicatorPreference = (android.os.IBinder.FIRST_CALL_TRANSACTION + 68);
static final int TRANSACTION_updateRotation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 69);
static final int TRANSACTION_getRotation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 70);
static final int TRANSACTION_watchRotation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 71);
static final int TRANSACTION_getPreferredOptionsPanelGravity = (android.os.IBinder.FIRST_CALL_TRANSACTION + 72);
static final int TRANSACTION_freezeRotation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 73);
static final int TRANSACTION_thawRotation = (android.os.IBinder.FIRST_CALL_TRANSACTION + 74);
static final int TRANSACTION_screenshotApplications = (android.os.IBinder.FIRST_CALL_TRANSACTION + 75);
static final int TRANSACTION_statusBarVisibilityChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 76);
static final int TRANSACTION_setPointerSpeed = (android.os.IBinder.FIRST_CALL_TRANSACTION + 77);
static final int TRANSACTION_waitForWindowDrawn = (android.os.IBinder.FIRST_CALL_TRANSACTION + 78);
static final int TRANSACTION_hasNavigationBar = (android.os.IBinder.FIRST_CALL_TRANSACTION + 79);
}
/**
     * ===== NOTICE =====
     * The first three methods must remain the first three methods. Scripts
     * and tools rely on their transaction number to work properly.
     */// This is used for debugging

public boolean startViewServer(int port) throws android.os.RemoteException;
// Transaction #1

public boolean stopViewServer() throws android.os.RemoteException;
// Transaction #2

public boolean isViewServerRunning() throws android.os.RemoteException;
// Transaction #3

public android.view.IWindowSession openSession(com.android.internal.view.IInputMethodClient client, com.android.internal.view.IInputContext inputContext) throws android.os.RemoteException;
public boolean inputMethodClientHasFocus(com.android.internal.view.IInputMethodClient client) throws android.os.RemoteException;
public void getDisplaySize(android.graphics.Point size) throws android.os.RemoteException;
public void getRealDisplaySize(android.graphics.Point size) throws android.os.RemoteException;
public int getMaximumSizeDimension() throws android.os.RemoteException;
public void setForcedDisplaySize(int longDimen, int shortDimen) throws android.os.RemoteException;
public void clearForcedDisplaySize() throws android.os.RemoteException;
// Is device configured with a hideable status bar or a tablet system bar?

public boolean canStatusBarHide() throws android.os.RemoteException;
// These can only be called when injecting events to your own window,
// or by holding the INJECT_EVENTS permission.  These methods may block
// until pending input events are finished being dispatched even when 'sync' is false.
// Avoid calling these methods on your UI thread or use the 'NoWait' version instead.

public boolean injectKeyEvent(android.view.KeyEvent ev, boolean sync) throws android.os.RemoteException;
public boolean injectPointerEvent(android.view.MotionEvent ev, boolean sync) throws android.os.RemoteException;
public boolean injectTrackballEvent(android.view.MotionEvent ev, boolean sync) throws android.os.RemoteException;
public boolean injectInputEventNoWait(android.view.InputEvent ev) throws android.os.RemoteException;
// These can only be called when holding the MANAGE_APP_TOKENS permission.

public void pauseKeyDispatching(android.os.IBinder token) throws android.os.RemoteException;
public void resumeKeyDispatching(android.os.IBinder token) throws android.os.RemoteException;
public void setEventDispatching(boolean enabled) throws android.os.RemoteException;
public void addWindowToken(android.os.IBinder token, int type) throws android.os.RemoteException;
public void removeWindowToken(android.os.IBinder token) throws android.os.RemoteException;
public void addAppToken(int addPos, android.view.IApplicationToken token, int groupId, int requestedOrientation, boolean fullscreen) throws android.os.RemoteException;
public void setAppGroupId(android.os.IBinder token, int groupId) throws android.os.RemoteException;
public void setAppOrientation(android.view.IApplicationToken token, int requestedOrientation) throws android.os.RemoteException;
public int getAppOrientation(android.view.IApplicationToken token) throws android.os.RemoteException;
public void setFocusedApp(android.os.IBinder token, boolean moveFocusNow) throws android.os.RemoteException;
public void prepareAppTransition(int transit, boolean alwaysKeepCurrent) throws android.os.RemoteException;
public int getPendingAppTransition() throws android.os.RemoteException;
public void overridePendingAppTransition(java.lang.String packageName, int enterAnim, int exitAnim) throws android.os.RemoteException;
public void executeAppTransition() throws android.os.RemoteException;
public void setAppStartingWindow(android.os.IBinder token, java.lang.String pkg, int theme, android.content.res.CompatibilityInfo compatInfo, java.lang.CharSequence nonLocalizedLabel, int labelRes, int icon, int windowFlags, android.os.IBinder transferFrom, boolean createIfNeeded) throws android.os.RemoteException;
public void setAppWillBeHidden(android.os.IBinder token) throws android.os.RemoteException;
public void setAppVisibility(android.os.IBinder token, boolean visible) throws android.os.RemoteException;
public void startAppFreezingScreen(android.os.IBinder token, int configChanges) throws android.os.RemoteException;
public void stopAppFreezingScreen(android.os.IBinder token, boolean force) throws android.os.RemoteException;
public void removeAppToken(android.os.IBinder token) throws android.os.RemoteException;
public void moveAppToken(int index, android.os.IBinder token) throws android.os.RemoteException;
public void moveAppTokensToTop(java.util.List<android.os.IBinder> tokens) throws android.os.RemoteException;
public void moveAppTokensToBottom(java.util.List<android.os.IBinder> tokens) throws android.os.RemoteException;
// Re-evaluate the current orientation from the caller's state.
// If there is a change, the new Configuration is returned and the
// caller must call setNewConfiguration() sometime later.

public android.content.res.Configuration updateOrientationFromAppTokens(android.content.res.Configuration currentConfig, android.os.IBinder freezeThisOneIfNeeded) throws android.os.RemoteException;
public void setNewConfiguration(android.content.res.Configuration config) throws android.os.RemoteException;
// these require DISABLE_KEYGUARD permission

public void disableKeyguard(android.os.IBinder token, java.lang.String tag) throws android.os.RemoteException;
public void reenableKeyguard(android.os.IBinder token) throws android.os.RemoteException;
public void exitKeyguardSecurely(android.view.IOnKeyguardExitResult callback) throws android.os.RemoteException;
public boolean isKeyguardLocked() throws android.os.RemoteException;
public boolean isKeyguardSecure() throws android.os.RemoteException;
public boolean inKeyguardRestrictedInputMode() throws android.os.RemoteException;
public void dismissKeyguard() throws android.os.RemoteException;
public void closeSystemDialogs(java.lang.String reason) throws android.os.RemoteException;
// These can only be called with the SET_ANIMATON_SCALE permission.

public float getAnimationScale(int which) throws android.os.RemoteException;
public float[] getAnimationScales() throws android.os.RemoteException;
public void setAnimationScale(int which, float scale) throws android.os.RemoteException;
public void setAnimationScales(float[] scales) throws android.os.RemoteException;
// These require the READ_INPUT_STATE permission.

public int getSwitchState(int sw) throws android.os.RemoteException;
public int getSwitchStateForDevice(int devid, int sw) throws android.os.RemoteException;
public int getScancodeState(int sw) throws android.os.RemoteException;
public int getScancodeStateForDevice(int devid, int sw) throws android.os.RemoteException;
public int getTrackballScancodeState(int sw) throws android.os.RemoteException;
public int getDPadScancodeState(int sw) throws android.os.RemoteException;
public int getKeycodeState(int sw) throws android.os.RemoteException;
public int getKeycodeStateForDevice(int devid, int sw) throws android.os.RemoteException;
public int getTrackballKeycodeState(int sw) throws android.os.RemoteException;
public int getDPadKeycodeState(int sw) throws android.os.RemoteException;
public android.view.InputChannel monitorInput(java.lang.String inputChannelName) throws android.os.RemoteException;
// Report whether the hardware supports the given keys; returns true if successful

public boolean hasKeys(int[] keycodes, boolean[] keyExists) throws android.os.RemoteException;
// Get input device information.

public android.view.InputDevice getInputDevice(int deviceId) throws android.os.RemoteException;
public int[] getInputDeviceIds() throws android.os.RemoteException;
// For testing

public void setInTouchMode(boolean showFocus) throws android.os.RemoteException;
// For StrictMode flashing a red border on violations from the UI
// thread.  The uid/pid is implicit from the Binder call, and the Window
// Manager uses that to determine whether or not the red border should
// actually be shown.  (it will be ignored that pid doesn't have windows
// on screen)

public void showStrictModeViolation(boolean on) throws android.os.RemoteException;
// Proxy to set the system property for whether the flashing
// should be enabled.  The 'enabled' value is null or blank for
// the system default (differs per build variant) or any valid
// boolean string as parsed by SystemProperties.getBoolean().

public void setStrictModeVisualIndicatorPreference(java.lang.String enabled) throws android.os.RemoteException;
// These can only be called with the SET_ORIENTATION permission.
/**
     * Update the current screen rotation based on the current state of
     * the world.
     * @param alwaysSendConfiguration Flag to force a new configuration to
     * be evaluated.  This can be used when there are other parameters in
     * configuration that are changing.
     */
public void updateRotation(boolean alwaysSendConfiguration) throws android.os.RemoteException;
/**
     * Retrieve the current screen orientation, constants as per
     * {@link android.view.Surface}.
     */
public int getRotation() throws android.os.RemoteException;
/**
     * Watch the rotation of the screen.  Returns the current rotation,
     * calls back when it changes.
     */
public int watchRotation(android.view.IRotationWatcher watcher) throws android.os.RemoteException;
/**
     * Determine the preferred edge of the screen to pin the compact options menu against.
     * @return a Gravity value for the options menu panel
     * @hide
     */
public int getPreferredOptionsPanelGravity() throws android.os.RemoteException;
/**
	 * Lock the device orientation to the specified rotation, or to the
	 * current rotation if -1.  Sensor input will be ignored until
	 * thawRotation() is called.
	 * @hide
	 */
public void freezeRotation(int rotation) throws android.os.RemoteException;
/**
	 * Release the orientation lock imposed by freezeRotation().
	 * @hide
	 */
public void thawRotation() throws android.os.RemoteException;
/**
	 * Create a screenshot of the applications currently displayed.
	 */
public android.graphics.Bitmap screenshotApplications(android.os.IBinder appToken, int maxWidth, int maxHeight) throws android.os.RemoteException;
/**
     * Called by the status bar to notify Views of changes to System UI visiblity.
     */
public void statusBarVisibilityChanged(int visibility) throws android.os.RemoteException;
/**
     * Called by the settings application to temporarily set the pointer speed.
     */
public void setPointerSpeed(int speed) throws android.os.RemoteException;
/**
     * Block until the given window has been drawn to the screen.
     */
public void waitForWindowDrawn(android.os.IBinder token, android.os.IRemoteCallback callback) throws android.os.RemoteException;
/**
     * Device has a software navigation bar (separate from the status bar).
     */
public boolean hasNavigationBar() throws android.os.RemoteException;
}
