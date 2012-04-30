/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/os/IPowerManager.aidl
 */
package android.os;
/** @hide */
public interface IPowerManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.os.IPowerManager
{
private static final java.lang.String DESCRIPTOR = "android.os.IPowerManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.os.IPowerManager interface,
 * generating a proxy if needed.
 */
public static android.os.IPowerManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.os.IPowerManager))) {
return ((android.os.IPowerManager)iin);
}
return new android.os.IPowerManager.Stub.Proxy(obj);
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
case TRANSACTION_acquireWakeLock:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.os.IBinder _arg1;
_arg1 = data.readStrongBinder();
java.lang.String _arg2;
_arg2 = data.readString();
android.os.WorkSource _arg3;
if ((0!=data.readInt())) {
_arg3 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg3 = null;
}
this.acquireWakeLock(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_updateWakeLockWorkSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
android.os.WorkSource _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.updateWakeLockWorkSource(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_goToSleep:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
this.goToSleep(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_goToSleepWithReason:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
int _arg1;
_arg1 = data.readInt();
this.goToSleepWithReason(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_releaseWakeLock:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
this.releaseWakeLock(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_userActivity:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.userActivity(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_userActivityWithForce:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
boolean _arg1;
_arg1 = (0!=data.readInt());
boolean _arg2;
_arg2 = (0!=data.readInt());
this.userActivityWithForce(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_clearUserActivityTimeout:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
long _arg1;
_arg1 = data.readLong();
this.clearUserActivityTimeout(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setPokeLock:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.os.IBinder _arg1;
_arg1 = data.readStrongBinder();
java.lang.String _arg2;
_arg2 = data.readString();
this.setPokeLock(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_getSupportedWakeLockFlags:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getSupportedWakeLockFlags();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setStayOnSetting:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.setStayOnSetting(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setMaximumScreenOffTimeount:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.setMaximumScreenOffTimeount(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_preventScreenOn:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.preventScreenOn(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_isScreenOn:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isScreenOn();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_reboot:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.reboot(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_crash:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.crash(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setBacklightBrightness:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.setBacklightBrightness(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setAttentionLight:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
int _arg1;
_arg1 = data.readInt();
this.setAttentionLight(_arg0, _arg1);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.os.IPowerManager
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
// WARNING: changes in acquireWakeLock() signature must be reflected in IPowerManager.cpp/h

public void acquireWakeLock(int flags, android.os.IBinder lock, java.lang.String tag, android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(flags);
_data.writeStrongBinder(lock);
_data.writeString(tag);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_acquireWakeLock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void updateWakeLockWorkSource(android.os.IBinder lock, android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(lock);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_updateWakeLockWorkSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void goToSleep(long time) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(time);
mRemote.transact(Stub.TRANSACTION_goToSleep, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void goToSleepWithReason(long time, int reason) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(time);
_data.writeInt(reason);
mRemote.transact(Stub.TRANSACTION_goToSleepWithReason, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// WARNING: changes in releaseWakeLock() signature must be reflected in IPowerManager.cpp/h

public void releaseWakeLock(android.os.IBinder lock, int flags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(lock);
_data.writeInt(flags);
mRemote.transact(Stub.TRANSACTION_releaseWakeLock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void userActivity(long when, boolean noChangeLights) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(when);
_data.writeInt(((noChangeLights)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_userActivity, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void userActivityWithForce(long when, boolean noChangeLights, boolean force) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(when);
_data.writeInt(((noChangeLights)?(1):(0)));
_data.writeInt(((force)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_userActivityWithForce, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void clearUserActivityTimeout(long now, long timeout) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(now);
_data.writeLong(timeout);
mRemote.transact(Stub.TRANSACTION_clearUserActivityTimeout, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setPokeLock(int pokey, android.os.IBinder lock, java.lang.String tag) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(pokey);
_data.writeStrongBinder(lock);
_data.writeString(tag);
mRemote.transact(Stub.TRANSACTION_setPokeLock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getSupportedWakeLockFlags() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getSupportedWakeLockFlags, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setStayOnSetting(int val) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(val);
mRemote.transact(Stub.TRANSACTION_setStayOnSetting, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setMaximumScreenOffTimeount(int timeMs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(timeMs);
mRemote.transact(Stub.TRANSACTION_setMaximumScreenOffTimeount, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void preventScreenOn(boolean prevent) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((prevent)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_preventScreenOn, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean isScreenOn() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isScreenOn, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void reboot(java.lang.String reason) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(reason);
mRemote.transact(Stub.TRANSACTION_reboot, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void crash(java.lang.String message) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(message);
mRemote.transact(Stub.TRANSACTION_crash, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
// sets the brightness of the backlights (screen, keyboard, button) 0-255

public void setBacklightBrightness(int brightness) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(brightness);
mRemote.transact(Stub.TRANSACTION_setBacklightBrightness, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setAttentionLight(boolean on, int color) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((on)?(1):(0)));
_data.writeInt(color);
mRemote.transact(Stub.TRANSACTION_setAttentionLight, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_acquireWakeLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_updateWakeLockWorkSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_goToSleep = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_goToSleepWithReason = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_releaseWakeLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_userActivity = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_userActivityWithForce = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_clearUserActivityTimeout = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_setPokeLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_getSupportedWakeLockFlags = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_setStayOnSetting = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_setMaximumScreenOffTimeount = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_preventScreenOn = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_isScreenOn = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_reboot = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_crash = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_setBacklightBrightness = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_setAttentionLight = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
}
// WARNING: changes in acquireWakeLock() signature must be reflected in IPowerManager.cpp/h

public void acquireWakeLock(int flags, android.os.IBinder lock, java.lang.String tag, android.os.WorkSource ws) throws android.os.RemoteException;
public void updateWakeLockWorkSource(android.os.IBinder lock, android.os.WorkSource ws) throws android.os.RemoteException;
public void goToSleep(long time) throws android.os.RemoteException;
public void goToSleepWithReason(long time, int reason) throws android.os.RemoteException;
// WARNING: changes in releaseWakeLock() signature must be reflected in IPowerManager.cpp/h

public void releaseWakeLock(android.os.IBinder lock, int flags) throws android.os.RemoteException;
public void userActivity(long when, boolean noChangeLights) throws android.os.RemoteException;
public void userActivityWithForce(long when, boolean noChangeLights, boolean force) throws android.os.RemoteException;
public void clearUserActivityTimeout(long now, long timeout) throws android.os.RemoteException;
public void setPokeLock(int pokey, android.os.IBinder lock, java.lang.String tag) throws android.os.RemoteException;
public int getSupportedWakeLockFlags() throws android.os.RemoteException;
public void setStayOnSetting(int val) throws android.os.RemoteException;
public void setMaximumScreenOffTimeount(int timeMs) throws android.os.RemoteException;
public void preventScreenOn(boolean prevent) throws android.os.RemoteException;
public boolean isScreenOn() throws android.os.RemoteException;
public void reboot(java.lang.String reason) throws android.os.RemoteException;
public void crash(java.lang.String message) throws android.os.RemoteException;
// sets the brightness of the backlights (screen, keyboard, button) 0-255

public void setBacklightBrightness(int brightness) throws android.os.RemoteException;
public void setAttentionLight(boolean on, int color) throws android.os.RemoteException;
}
