/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/wifi/java/android/net/wifi/IWifiManager.aidl
 */
package android.net.wifi;
/**
 * Interface that allows controlling and querying Wi-Fi connectivity.
 *
 * {@hide}
 */
public interface IWifiManager extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.net.wifi.IWifiManager
{
private static final java.lang.String DESCRIPTOR = "android.net.wifi.IWifiManager";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.net.wifi.IWifiManager interface,
 * generating a proxy if needed.
 */
public static android.net.wifi.IWifiManager asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.net.wifi.IWifiManager))) {
return ((android.net.wifi.IWifiManager)iin);
}
return new android.net.wifi.IWifiManager.Stub.Proxy(obj);
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
case TRANSACTION_getConfiguredNetworks:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.net.wifi.WifiConfiguration> _result = this.getConfiguredNetworks();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_addOrUpdateNetwork:
{
data.enforceInterface(DESCRIPTOR);
android.net.wifi.WifiConfiguration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.wifi.WifiConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _result = this.addOrUpdateNetwork(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_removeNetwork:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _result = this.removeNetwork(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_enableNetwork:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
boolean _result = this.enableNetwork(_arg0, _arg1);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_disableNetwork:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _result = this.disableNetwork(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_pingSupplicant:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.pingSupplicant();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_startScan:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.startScan(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getScanResults:
{
data.enforceInterface(DESCRIPTOR);
java.util.List<android.net.wifi.ScanResult> _result = this.getScanResults();
reply.writeNoException();
reply.writeTypedList(_result);
return true;
}
case TRANSACTION_disconnect:
{
data.enforceInterface(DESCRIPTOR);
this.disconnect();
reply.writeNoException();
return true;
}
case TRANSACTION_reconnect:
{
data.enforceInterface(DESCRIPTOR);
this.reconnect();
reply.writeNoException();
return true;
}
case TRANSACTION_reassociate:
{
data.enforceInterface(DESCRIPTOR);
this.reassociate();
reply.writeNoException();
return true;
}
case TRANSACTION_getConnectionInfo:
{
data.enforceInterface(DESCRIPTOR);
android.net.wifi.WifiInfo _result = this.getConnectionInfo();
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
case TRANSACTION_setWifiEnabled:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
boolean _result = this.setWifiEnabled(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getWifiEnabledState:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getWifiEnabledState();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setCountryCode:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setCountryCode(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_setFrequencyBand:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setFrequencyBand(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getFrequencyBand:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getFrequencyBand();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_isDualBandSupported:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isDualBandSupported();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_saveConfiguration:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.saveConfiguration();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_getDhcpInfo:
{
data.enforceInterface(DESCRIPTOR);
android.net.DhcpInfo _result = this.getDhcpInfo();
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
case TRANSACTION_acquireWifiLock:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
int _arg1;
_arg1 = data.readInt();
java.lang.String _arg2;
_arg2 = data.readString();
android.os.WorkSource _arg3;
if ((0!=data.readInt())) {
_arg3 = android.os.WorkSource.CREATOR.createFromParcel(data);
}
else {
_arg3 = null;
}
boolean _result = this.acquireWifiLock(_arg0, _arg1, _arg2, _arg3);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_updateWifiLockWorkSource:
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
this.updateWifiLockWorkSource(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_releaseWifiLock:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
boolean _result = this.releaseWifiLock(_arg0);
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_initializeMulticastFiltering:
{
data.enforceInterface(DESCRIPTOR);
this.initializeMulticastFiltering();
reply.writeNoException();
return true;
}
case TRANSACTION_isMulticastEnabled:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isMulticastEnabled();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_acquireMulticastLock:
{
data.enforceInterface(DESCRIPTOR);
android.os.IBinder _arg0;
_arg0 = data.readStrongBinder();
java.lang.String _arg1;
_arg1 = data.readString();
this.acquireMulticastLock(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_releaseMulticastLock:
{
data.enforceInterface(DESCRIPTOR);
this.releaseMulticastLock();
reply.writeNoException();
return true;
}
case TRANSACTION_setWifiApEnabled:
{
data.enforceInterface(DESCRIPTOR);
android.net.wifi.WifiConfiguration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.wifi.WifiConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setWifiApEnabled(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_getWifiApEnabledState:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getWifiApEnabledState();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getWifiApConfiguration:
{
data.enforceInterface(DESCRIPTOR);
android.net.wifi.WifiConfiguration _result = this.getWifiApConfiguration();
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
case TRANSACTION_setWifiApConfiguration:
{
data.enforceInterface(DESCRIPTOR);
android.net.wifi.WifiConfiguration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.wifi.WifiConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
this.setWifiApConfiguration(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_startWifi:
{
data.enforceInterface(DESCRIPTOR);
this.startWifi();
reply.writeNoException();
return true;
}
case TRANSACTION_stopWifi:
{
data.enforceInterface(DESCRIPTOR);
this.stopWifi();
reply.writeNoException();
return true;
}
case TRANSACTION_addToBlacklist:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.addToBlacklist(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_clearBlacklist:
{
data.enforceInterface(DESCRIPTOR);
this.clearBlacklist();
reply.writeNoException();
return true;
}
case TRANSACTION_getMessenger:
{
data.enforceInterface(DESCRIPTOR);
android.os.Messenger _result = this.getMessenger();
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
case TRANSACTION_getConfigFile:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _result = this.getConfigFile();
reply.writeNoException();
reply.writeString(_result);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.net.wifi.IWifiManager
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
public java.util.List<android.net.wifi.WifiConfiguration> getConfiguredNetworks() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.net.wifi.WifiConfiguration> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getConfiguredNetworks, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.net.wifi.WifiConfiguration.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int addOrUpdateNetwork(android.net.wifi.WifiConfiguration config) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((config!=null)) {
_data.writeInt(1);
config.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_addOrUpdateNetwork, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean removeNetwork(int netId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(netId);
mRemote.transact(Stub.TRANSACTION_removeNetwork, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean enableNetwork(int netId, boolean disableOthers) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(netId);
_data.writeInt(((disableOthers)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_enableNetwork, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean disableNetwork(int netId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(netId);
mRemote.transact(Stub.TRANSACTION_disableNetwork, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean pingSupplicant() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_pingSupplicant, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void startScan(boolean forceActive) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((forceActive)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_startScan, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public java.util.List<android.net.wifi.ScanResult> getScanResults() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.util.List<android.net.wifi.ScanResult> _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getScanResults, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArrayList(android.net.wifi.ScanResult.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void disconnect() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_disconnect, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void reconnect() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_reconnect, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void reassociate() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_reassociate, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public android.net.wifi.WifiInfo getConnectionInfo() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.wifi.WifiInfo _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getConnectionInfo, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.wifi.WifiInfo.CREATOR.createFromParcel(_reply);
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
public boolean setWifiEnabled(boolean enable) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((enable)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setWifiEnabled, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public int getWifiEnabledState() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getWifiEnabledState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void setCountryCode(java.lang.String country, boolean persist) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(country);
_data.writeInt(((persist)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setCountryCode, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setFrequencyBand(int band, boolean persist) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(band);
_data.writeInt(((persist)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setFrequencyBand, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getFrequencyBand() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getFrequencyBand, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean isDualBandSupported() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isDualBandSupported, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public boolean saveConfiguration() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_saveConfiguration, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.net.DhcpInfo getDhcpInfo() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.DhcpInfo _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getDhcpInfo, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.DhcpInfo.CREATOR.createFromParcel(_reply);
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
public boolean acquireWifiLock(android.os.IBinder lock, int lockType, java.lang.String tag, android.os.WorkSource ws) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(lock);
_data.writeInt(lockType);
_data.writeString(tag);
if ((ws!=null)) {
_data.writeInt(1);
ws.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_acquireWifiLock, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void updateWifiLockWorkSource(android.os.IBinder lock, android.os.WorkSource ws) throws android.os.RemoteException
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
mRemote.transact(Stub.TRANSACTION_updateWifiLockWorkSource, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean releaseWifiLock(android.os.IBinder lock) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(lock);
mRemote.transact(Stub.TRANSACTION_releaseWifiLock, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void initializeMulticastFiltering() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_initializeMulticastFiltering, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public boolean isMulticastEnabled() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isMulticastEnabled, _data, _reply, 0);
_reply.readException();
_result = (0!=_reply.readInt());
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public void acquireMulticastLock(android.os.IBinder binder, java.lang.String tag) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder(binder);
_data.writeString(tag);
mRemote.transact(Stub.TRANSACTION_acquireMulticastLock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void releaseMulticastLock() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_releaseMulticastLock, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void setWifiApEnabled(android.net.wifi.WifiConfiguration wifiConfig, boolean enable) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((wifiConfig!=null)) {
_data.writeInt(1);
wifiConfig.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(((enable)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setWifiApEnabled, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public int getWifiApEnabledState() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getWifiApEnabledState, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
public android.net.wifi.WifiConfiguration getWifiApConfiguration() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.wifi.WifiConfiguration _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getWifiApConfiguration, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.wifi.WifiConfiguration.CREATOR.createFromParcel(_reply);
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
public void setWifiApConfiguration(android.net.wifi.WifiConfiguration wifiConfig) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((wifiConfig!=null)) {
_data.writeInt(1);
wifiConfig.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setWifiApConfiguration, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void startWifi() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_startWifi, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void stopWifi() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_stopWifi, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void addToBlacklist(java.lang.String bssid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(bssid);
mRemote.transact(Stub.TRANSACTION_addToBlacklist, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public void clearBlacklist() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_clearBlacklist, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
public android.os.Messenger getMessenger() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.os.Messenger _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getMessenger, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.os.Messenger.CREATOR.createFromParcel(_reply);
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
public java.lang.String getConfigFile() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getConfigFile, _data, _reply, 0);
_reply.readException();
_result = _reply.readString();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_getConfiguredNetworks = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_addOrUpdateNetwork = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_removeNetwork = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_enableNetwork = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_disableNetwork = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_pingSupplicant = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_startScan = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_getScanResults = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_disconnect = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_reconnect = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_reassociate = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_getConnectionInfo = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_setWifiEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_getWifiEnabledState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_setCountryCode = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_setFrequencyBand = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_getFrequencyBand = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_isDualBandSupported = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_saveConfiguration = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_getDhcpInfo = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_acquireWifiLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
static final int TRANSACTION_updateWifiLockWorkSource = (android.os.IBinder.FIRST_CALL_TRANSACTION + 21);
static final int TRANSACTION_releaseWifiLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 22);
static final int TRANSACTION_initializeMulticastFiltering = (android.os.IBinder.FIRST_CALL_TRANSACTION + 23);
static final int TRANSACTION_isMulticastEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 24);
static final int TRANSACTION_acquireMulticastLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 25);
static final int TRANSACTION_releaseMulticastLock = (android.os.IBinder.FIRST_CALL_TRANSACTION + 26);
static final int TRANSACTION_setWifiApEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 27);
static final int TRANSACTION_getWifiApEnabledState = (android.os.IBinder.FIRST_CALL_TRANSACTION + 28);
static final int TRANSACTION_getWifiApConfiguration = (android.os.IBinder.FIRST_CALL_TRANSACTION + 29);
static final int TRANSACTION_setWifiApConfiguration = (android.os.IBinder.FIRST_CALL_TRANSACTION + 30);
static final int TRANSACTION_startWifi = (android.os.IBinder.FIRST_CALL_TRANSACTION + 31);
static final int TRANSACTION_stopWifi = (android.os.IBinder.FIRST_CALL_TRANSACTION + 32);
static final int TRANSACTION_addToBlacklist = (android.os.IBinder.FIRST_CALL_TRANSACTION + 33);
static final int TRANSACTION_clearBlacklist = (android.os.IBinder.FIRST_CALL_TRANSACTION + 34);
static final int TRANSACTION_getMessenger = (android.os.IBinder.FIRST_CALL_TRANSACTION + 35);
static final int TRANSACTION_getConfigFile = (android.os.IBinder.FIRST_CALL_TRANSACTION + 36);
}
public java.util.List<android.net.wifi.WifiConfiguration> getConfiguredNetworks() throws android.os.RemoteException;
public int addOrUpdateNetwork(android.net.wifi.WifiConfiguration config) throws android.os.RemoteException;
public boolean removeNetwork(int netId) throws android.os.RemoteException;
public boolean enableNetwork(int netId, boolean disableOthers) throws android.os.RemoteException;
public boolean disableNetwork(int netId) throws android.os.RemoteException;
public boolean pingSupplicant() throws android.os.RemoteException;
public void startScan(boolean forceActive) throws android.os.RemoteException;
public java.util.List<android.net.wifi.ScanResult> getScanResults() throws android.os.RemoteException;
public void disconnect() throws android.os.RemoteException;
public void reconnect() throws android.os.RemoteException;
public void reassociate() throws android.os.RemoteException;
public android.net.wifi.WifiInfo getConnectionInfo() throws android.os.RemoteException;
public boolean setWifiEnabled(boolean enable) throws android.os.RemoteException;
public int getWifiEnabledState() throws android.os.RemoteException;
public void setCountryCode(java.lang.String country, boolean persist) throws android.os.RemoteException;
public void setFrequencyBand(int band, boolean persist) throws android.os.RemoteException;
public int getFrequencyBand() throws android.os.RemoteException;
public boolean isDualBandSupported() throws android.os.RemoteException;
public boolean saveConfiguration() throws android.os.RemoteException;
public android.net.DhcpInfo getDhcpInfo() throws android.os.RemoteException;
public boolean acquireWifiLock(android.os.IBinder lock, int lockType, java.lang.String tag, android.os.WorkSource ws) throws android.os.RemoteException;
public void updateWifiLockWorkSource(android.os.IBinder lock, android.os.WorkSource ws) throws android.os.RemoteException;
public boolean releaseWifiLock(android.os.IBinder lock) throws android.os.RemoteException;
public void initializeMulticastFiltering() throws android.os.RemoteException;
public boolean isMulticastEnabled() throws android.os.RemoteException;
public void acquireMulticastLock(android.os.IBinder binder, java.lang.String tag) throws android.os.RemoteException;
public void releaseMulticastLock() throws android.os.RemoteException;
public void setWifiApEnabled(android.net.wifi.WifiConfiguration wifiConfig, boolean enable) throws android.os.RemoteException;
public int getWifiApEnabledState() throws android.os.RemoteException;
public android.net.wifi.WifiConfiguration getWifiApConfiguration() throws android.os.RemoteException;
public void setWifiApConfiguration(android.net.wifi.WifiConfiguration wifiConfig) throws android.os.RemoteException;
public void startWifi() throws android.os.RemoteException;
public void stopWifi() throws android.os.RemoteException;
public void addToBlacklist(java.lang.String bssid) throws android.os.RemoteException;
public void clearBlacklist() throws android.os.RemoteException;
public android.os.Messenger getMessenger() throws android.os.RemoteException;
public java.lang.String getConfigFile() throws android.os.RemoteException;
}
