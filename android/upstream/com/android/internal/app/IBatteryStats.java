/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/app/IBatteryStats.aidl
 */
package com.android.internal.app;
public interface IBatteryStats extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.app.IBatteryStats
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.app.IBatteryStats";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.app.IBatteryStats interface,
 * generating a proxy if needed.
 */
public static com.android.internal.app.IBatteryStats asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.app.IBatteryStats))) {
return ((com.android.internal.app.IBatteryStats)iin);
}
return new com.android.internal.app.IBatteryStats.Stub.Proxy(obj);
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
case TRANSACTION_getStatistics:
{
data.enforceInterface(DESCRIPTOR);
byte[] _result = this.getStatistics();
reply.writeNoException();
reply.writeByteArray(_result);
return true;
}
case TRANSACTION_noteStartWakelock:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
int _arg3;
_arg3 = data.readInt();
this.noteStartWakelock(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_noteStopWakelock:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
int _arg3;
_arg3 = data.readInt();
this.noteStopWakelock(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_noteStartSensor:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.noteStartSensor(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_noteStopSensor:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.noteStopSensor(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_noteStartWakelockFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
int _arg3;
_arg3 = data.readInt();
this.noteStartWakelockFromSource(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_noteStopWakelockFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
int _arg3;
_arg3 = data.readInt();
this.noteStopWakelockFromSource(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
return true;
}
case TRANSACTION_noteStartGps:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteStartGps(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteStopGps:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteStopGps(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteScreenOn:
{
data.enforceInterface(DESCRIPTOR);
this.noteScreenOn();
reply.writeNoException();
return true;
}
case TRANSACTION_noteScreenBrightness:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteScreenBrightness(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteScreenOff:
{
data.enforceInterface(DESCRIPTOR);
this.noteScreenOff();
reply.writeNoException();
return true;
}
case TRANSACTION_noteInputEvent:
{
data.enforceInterface(DESCRIPTOR);
this.noteInputEvent();
reply.writeNoException();
return true;
}
case TRANSACTION_noteUserActivity:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.noteUserActivity(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_notePhoneOn:
{
data.enforceInterface(DESCRIPTOR);
this.notePhoneOn();
reply.writeNoException();
return true;
}
case TRANSACTION_notePhoneOff:
{
data.enforceInterface(DESCRIPTOR);
this.notePhoneOff();
reply.writeNoException();
return true;
}
case TRANSACTION_notePhoneSignalStrength:
{
data.enforceInterface(DESCRIPTOR);
android.telephony.SignalStrength _arg0;
if ((0!=data.readInt())) {
_arg0 = android.telephony.SignalStrength.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.notePhoneSignalStrength(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_notePhoneDataConnectionState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.notePhoneDataConnectionState(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_notePhoneState:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.notePhoneState(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiOn:
{
data.enforceInterface(DESCRIPTOR);
this.noteWifiOn();
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiOff:
{
data.enforceInterface(DESCRIPTOR);
this.noteWifiOff();
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiRunning:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteWifiRunning(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiRunningChanged:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.os.WorkSource _arg1;
if ((0!=data.readInt())) {
_arg1 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.noteWifiRunningChanged(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiStopped:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteWifiStopped(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteBluetoothOn:
{
data.enforceInterface(DESCRIPTOR);
this.noteBluetoothOn();
reply.writeNoException();
return true;
}
case TRANSACTION_noteBluetoothOff:
{
data.enforceInterface(DESCRIPTOR);
this.noteBluetoothOff();
reply.writeNoException();
return true;
}
case TRANSACTION_noteFullWifiLockAcquired:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteFullWifiLockAcquired(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteFullWifiLockReleased:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteFullWifiLockReleased(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteScanWifiLockAcquired:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteScanWifiLockAcquired(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteScanWifiLockReleased:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteScanWifiLockReleased(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiMulticastEnabled:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteWifiMulticastEnabled(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiMulticastDisabled:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
this.noteWifiMulticastDisabled(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteFullWifiLockAcquiredFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteFullWifiLockAcquiredFromSource(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteFullWifiLockReleasedFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteFullWifiLockReleasedFromSource(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteScanWifiLockAcquiredFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteScanWifiLockAcquiredFromSource(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteScanWifiLockReleasedFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteScanWifiLockReleasedFromSource(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiMulticastEnabledFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteWifiMulticastEnabledFromSource(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteWifiMulticastDisabledFromSource:
{
data.enforceInterface(DESCRIPTOR);
android.os.WorkSource _arg0;
if ((0!=data.readInt())) {
_arg0 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.noteWifiMulticastDisabledFromSource(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_noteNetworkInterfaceType:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
this.noteNetworkInterfaceType(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setBatteryState:
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
this.setBatteryState(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
reply.writeNoException();
return true;
}
case TRANSACTION_getAwakeTimeBattery:
{
data.enforceInterface(DESCRIPTOR);
long _result = this.getAwakeTimeBattery();
reply.writeNoException();
reply.writeLong(_result);
return true;
}
case TRANSACTION_getAwakeTimePlugged:
{
data.enforceInterface(DESCRIPTOR);
long _result = this.getAwakeTimePlugged();
reply.writeNoException();
reply.writeLong(_result);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.app.IBatteryStats
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
public byte[] getStatistics() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
byte[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getStatistics, _data, _reply, 0);
_reply.readException();
_result = _reply.createByteArray();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void noteStartWakelock(int uid, int pid, java.lang.String name, int type) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(pid);
_data.writeString(name);
_data.writeInt(type);
mRemote.transact(Stub.TRANSACTION_noteStartWakelock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteStopWakelock(int uid, int pid, java.lang.String name, int type) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(pid);
_data.writeString(name);
_data.writeInt(type);
mRemote.transact(Stub.TRANSACTION_noteStopWakelock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* DO NOT CHANGE the position of noteStartSensor without updating
       SensorService.cpp */
public void noteStartSensor(int uid, int sensor) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(sensor);
mRemote.transact(Stub.TRANSACTION_noteStartSensor, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/* DO NOT CHANGE the position of noteStopSensor without updating
       SensorService.cpp */
public void noteStopSensor(int uid, int sensor) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(sensor);
mRemote.transact(Stub.TRANSACTION_noteStopSensor, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteStartWakelockFromSource(android.os.WorkSource ws, int pid, java.lang.String name, int type) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(pid);
_data.writeString(name);
_data.writeInt(type);
mRemote.transact(Stub.TRANSACTION_noteStartWakelockFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteStopWakelockFromSource(android.os.WorkSource ws, int pid, java.lang.String name, int type) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(pid);
_data.writeString(name);
_data.writeInt(type);
mRemote.transact(Stub.TRANSACTION_noteStopWakelockFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteStartGps(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteStartGps, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteStopGps(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteStopGps, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteScreenOn() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_noteScreenOn, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteScreenBrightness(int brightness) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(brightness);
mRemote.transact(Stub.TRANSACTION_noteScreenBrightness, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteScreenOff() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_noteScreenOff, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteInputEvent() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_noteInputEvent, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteUserActivity(int uid, int event) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(event);
mRemote.transact(Stub.TRANSACTION_noteUserActivity, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notePhoneOn() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_notePhoneOn, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notePhoneOff() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_notePhoneOff, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notePhoneSignalStrength(android.telephony.SignalStrength signalStrength) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((signalStrength!=null)) {
_data.writeInt(1);
signalStrength.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_notePhoneSignalStrength, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notePhoneDataConnectionState(int dataType, boolean hasData) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(dataType);
_data.writeInt(((hasData)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_notePhoneDataConnectionState, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void notePhoneState(int phoneState) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(phoneState);
mRemote.transact(Stub.TRANSACTION_notePhoneState, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiOn() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_noteWifiOn, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiOff() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_noteWifiOff, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiRunning(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteWifiRunning, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiRunningChanged(android.os.WorkSource oldWs, android.os.WorkSource newWs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((oldWs!=null)) {
_data.writeInt(1);
oldWs.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
if ((newWs!=null)) {
_data.writeInt(1);
newWs.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteWifiRunningChanged, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiStopped(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteWifiStopped, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteBluetoothOn() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_noteBluetoothOn, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteBluetoothOff() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_noteBluetoothOff, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteFullWifiLockAcquired(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteFullWifiLockAcquired, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteFullWifiLockReleased(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteFullWifiLockReleased, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteScanWifiLockAcquired(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteScanWifiLockAcquired, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteScanWifiLockReleased(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteScanWifiLockReleased, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiMulticastEnabled(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteWifiMulticastEnabled, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiMulticastDisabled(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_noteWifiMulticastDisabled, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteFullWifiLockAcquiredFromSource(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteFullWifiLockAcquiredFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteFullWifiLockReleasedFromSource(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteFullWifiLockReleasedFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteScanWifiLockAcquiredFromSource(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteScanWifiLockAcquiredFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteScanWifiLockReleasedFromSource(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteScanWifiLockReleasedFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiMulticastEnabledFromSource(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteWifiMulticastEnabledFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteWifiMulticastDisabledFromSource(android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_noteWifiMulticastDisabledFromSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void noteNetworkInterfaceType(java.lang.String iface, int type) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
_data.writeInt(type);
mRemote.transact(Stub.TRANSACTION_noteNetworkInterfaceType, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setBatteryState(int status, int health, int plugType, int level, int temp, int volt) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(status);
_data.writeInt(health);
_data.writeInt(plugType);
_data.writeInt(level);
_data.writeInt(temp);
_data.writeInt(volt);
mRemote.transact(Stub.TRANSACTION_setBatteryState, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public long getAwakeTimeBattery() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
long _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getAwakeTimeBattery, _data, _reply, 0);
_reply.readException();
_result = _reply.readLong();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public long getAwakeTimePlugged() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
long _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getAwakeTimePlugged, _data, _reply, 0);
_reply.readException();
_result = _reply.readLong();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_getStatistics = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_noteStartWakelock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_noteStopWakelock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_noteStartSensor = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_noteStopSensor = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_noteStartWakelockFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_noteStopWakelockFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_noteStartGps = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_noteStopGps = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_noteScreenOn = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_noteScreenBrightness = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_noteScreenOff = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_noteInputEvent = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_noteUserActivity = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_notePhoneOn = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_notePhoneOff = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_notePhoneSignalStrength = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_notePhoneDataConnectionState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_notePhoneState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_noteWifiOn = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_noteWifiOff = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
static final int TRANSACTION_noteWifiRunning = (android.os.IBinder.FIRST_CALL_TRANSACTION + 21);
static final int TRANSACTION_noteWifiRunningChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 22);
static final int TRANSACTION_noteWifiStopped = (android.os.IBinder.FIRST_CALL_TRANSACTION + 23);
static final int TRANSACTION_noteBluetoothOn = (android.os.IBinder.FIRST_CALL_TRANSACTION + 24);
static final int TRANSACTION_noteBluetoothOff = (android.os.IBinder.FIRST_CALL_TRANSACTION + 25);
static final int TRANSACTION_noteFullWifiLockAcquired = (android.os.IBinder.FIRST_CALL_TRANSACTION + 26);
static final int TRANSACTION_noteFullWifiLockReleased = (android.os.IBinder.FIRST_CALL_TRANSACTION + 27);
static final int TRANSACTION_noteScanWifiLockAcquired = (android.os.IBinder.FIRST_CALL_TRANSACTION + 28);
static final int TRANSACTION_noteScanWifiLockReleased = (android.os.IBinder.FIRST_CALL_TRANSACTION + 29);
static final int TRANSACTION_noteWifiMulticastEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 30);
static final int TRANSACTION_noteWifiMulticastDisabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 31);
static final int TRANSACTION_noteFullWifiLockAcquiredFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 32);
static final int TRANSACTION_noteFullWifiLockReleasedFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 33);
static final int TRANSACTION_noteScanWifiLockAcquiredFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 34);
static final int TRANSACTION_noteScanWifiLockReleasedFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 35);
static final int TRANSACTION_noteWifiMulticastEnabledFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 36);
static final int TRANSACTION_noteWifiMulticastDisabledFromSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 37);
static final int TRANSACTION_noteNetworkInterfaceType = (android.os.IBinder.FIRST_CALL_TRANSACTION + 38);
static final int TRANSACTION_setBatteryState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 39);
static final int TRANSACTION_getAwakeTimeBattery = (android.os.IBinder.FIRST_CALL_TRANSACTION + 40);
static final int TRANSACTION_getAwakeTimePlugged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 41);
}
public byte[] getStatistics() throws android.os.RemoteException;
public void noteStartWakelock(int uid, int pid, java.lang.String name, int type) throws android.os.RemoteException;
public void noteStopWakelock(int uid, int pid, java.lang.String name, int type) throws android.os.RemoteException;
/* DO NOT CHANGE the position of noteStartSensor without updating
       SensorService.cpp */
public void noteStartSensor(int uid, int sensor) throws android.os.RemoteException;
/* DO NOT CHANGE the position of noteStopSensor without updating
       SensorService.cpp */
public void noteStopSensor(int uid, int sensor) throws android.os.RemoteException;
public void noteStartWakelockFromSource(android.os.WorkSource ws, int pid, java.lang.String name, int type) throws android.os.RemoteException;
public void noteStopWakelockFromSource(android.os.WorkSource ws, int pid, java.lang.String name, int type) throws android.os.RemoteException;
public void noteStartGps(int uid) throws android.os.RemoteException;
public void noteStopGps(int uid) throws android.os.RemoteException;
public void noteScreenOn() throws android.os.RemoteException;
public void noteScreenBrightness(int brightness) throws android.os.RemoteException;
public void noteScreenOff() throws android.os.RemoteException;
public void noteInputEvent() throws android.os.RemoteException;
public void noteUserActivity(int uid, int event) throws android.os.RemoteException;
public void notePhoneOn() throws android.os.RemoteException;
public void notePhoneOff() throws android.os.RemoteException;
public void notePhoneSignalStrength(android.telephony.SignalStrength signalStrength) throws android.os.RemoteException;
public void notePhoneDataConnectionState(int dataType, boolean hasData) throws android.os.RemoteException;
public void notePhoneState(int phoneState) throws android.os.RemoteException;
public void noteWifiOn() throws android.os.RemoteException;
public void noteWifiOff() throws android.os.RemoteException;
public void noteWifiRunning(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteWifiRunningChanged(android.os.WorkSource oldWs, android.os.WorkSource newWs) throws android.os.RemoteException;
public void noteWifiStopped(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteBluetoothOn() throws android.os.RemoteException;
public void noteBluetoothOff() throws android.os.RemoteException;
public void noteFullWifiLockAcquired(int uid) throws android.os.RemoteException;
public void noteFullWifiLockReleased(int uid) throws android.os.RemoteException;
public void noteScanWifiLockAcquired(int uid) throws android.os.RemoteException;
public void noteScanWifiLockReleased(int uid) throws android.os.RemoteException;
public void noteWifiMulticastEnabled(int uid) throws android.os.RemoteException;
public void noteWifiMulticastDisabled(int uid) throws android.os.RemoteException;
public void noteFullWifiLockAcquiredFromSource(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteFullWifiLockReleasedFromSource(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteScanWifiLockAcquiredFromSource(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteScanWifiLockReleasedFromSource(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteWifiMulticastEnabledFromSource(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteWifiMulticastDisabledFromSource(android.os.WorkSource ws) throws android.os.RemoteException;
public void noteNetworkInterfaceType(java.lang.String iface, int type) throws android.os.RemoteException;
public void setBatteryState(int status, int health, int plugType, int level, int temp, int volt) throws android.os.RemoteException;
public long getAwakeTimeBattery() throws android.os.RemoteException;
public long getAwakeTimePlugged() throws android.os.RemoteException;
}
