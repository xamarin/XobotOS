/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/os/INetworkManagementService.aidl
 */
package android.os;
/**
 * @hide
 */
public interface INetworkManagementService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.os.INetworkManagementService
{
private static final java.lang.String DESCRIPTOR = "android.os.INetworkManagementService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.os.INetworkManagementService interface,
 * generating a proxy if needed.
 */
public static android.os.INetworkManagementService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.os.INetworkManagementService))) {
return ((android.os.INetworkManagementService)iin);
}
return new android.os.INetworkManagementService.Stub.Proxy(obj);
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
case TRANSACTION_registerObserver:
{
data.enforceInterface(DESCRIPTOR);
android.net.INetworkManagementEventObserver _arg0;
_arg0 = android.net.INetworkManagementEventObserver.Stub.asInterface(data.readStrongBinder());
this.registerObserver(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_unregisterObserver:
{
data.enforceInterface(DESCRIPTOR);
android.net.INetworkManagementEventObserver _arg0;
_arg0 = android.net.INetworkManagementEventObserver.Stub.asInterface(data.readStrongBinder());
this.unregisterObserver(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_listInterfaces:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String[] _result = this.listInterfaces();
reply.writeNoException();
reply.writeStringArray(_result);
return true;
}
case TRANSACTION_getInterfaceConfig:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.InterfaceConfiguration _result = this.getInterfaceConfig(_arg0);
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
case TRANSACTION_setInterfaceConfig:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.InterfaceConfiguration _arg1;
if ((0!=data.readInt())) {
_arg1 = android.net.InterfaceConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.setInterfaceConfig(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_clearInterfaceAddresses:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.clearInterfaceAddresses(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setInterfaceDown:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.setInterfaceDown(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setInterfaceUp:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.setInterfaceUp(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setInterfaceIpv6PrivacyExtensions:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setInterfaceIpv6PrivacyExtensions(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_disableIpv6:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.disableIpv6(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_enableIpv6:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.enableIpv6(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getRoutes:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.RouteInfo[] _result = this.getRoutes(_arg0);
reply.writeNoException();
reply.writeTypedArray(_result, android.os.Parcelable.PARCELABLE_WRITE_RETURN_VALUE);
return true;
}
case TRANSACTION_addRoute:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.RouteInfo _arg1;
if ((0!=data.readInt())) {
_arg1 = android.net.RouteInfo.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.addRoute(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeRoute:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
android.net.RouteInfo _arg1;
if ((0!=data.readInt())) {
_arg1 = android.net.RouteInfo.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.removeRoute(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_shutdown:
{
data.enforceInterface(DESCRIPTOR);
this.shutdown();
reply.writeNoException();
return true;
}
case TRANSACTION_getIpForwardingEnabled:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.getIpForwardingEnabled();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setIpForwardingEnabled:
{
data.enforceInterface(DESCRIPTOR);
boolean _arg0;
_arg0 = (0!=data.readInt());
this.setIpForwardingEnabled(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_startTethering:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String[] _arg0;
_arg0 = data.createStringArray();
this.startTethering(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_stopTethering:
{
data.enforceInterface(DESCRIPTOR);
this.stopTethering();
reply.writeNoException();
return true;
}
case TRANSACTION_isTetheringStarted:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isTetheringStarted();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_tetherInterface:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.tetherInterface(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_untetherInterface:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.untetherInterface(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_listTetheredInterfaces:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String[] _result = this.listTetheredInterfaces();
reply.writeNoException();
reply.writeStringArray(_result);
return true;
}
case TRANSACTION_setDnsForwarders:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String[] _arg0;
_arg0 = data.createStringArray();
this.setDnsForwarders(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getDnsForwarders:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String[] _result = this.getDnsForwarders();
reply.writeNoException();
reply.writeStringArray(_result);
return true;
}
case TRANSACTION_enableNat:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
this.enableNat(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_disableNat:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
this.disableNat(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_listTtys:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String[] _result = this.listTtys();
reply.writeNoException();
reply.writeStringArray(_result);
return true;
}
case TRANSACTION_attachPppd:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
java.lang.String _arg2;
_arg2 = data.readString();
java.lang.String _arg3;
_arg3 = data.readString();
java.lang.String _arg4;
_arg4 = data.readString();
this.attachPppd(_arg0, _arg1, _arg2, _arg3, _arg4);
reply.writeNoException();
return true;
}
case TRANSACTION_detachPppd:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.detachPppd(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_wifiFirmwareReload:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String _arg1;
_arg1 = data.readString();
this.wifiFirmwareReload(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_startAccessPoint:
{
data.enforceInterface(DESCRIPTOR);
android.net.wifi.WifiConfiguration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.wifi.WifiConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
java.lang.String _arg2;
_arg2 = data.readString();
this.startAccessPoint(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_stopAccessPoint:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.stopAccessPoint(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setAccessPoint:
{
data.enforceInterface(DESCRIPTOR);
android.net.wifi.WifiConfiguration _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.wifi.WifiConfiguration.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
java.lang.String _arg1;
_arg1 = data.readString();
java.lang.String _arg2;
_arg2 = data.readString();
this.setAccessPoint(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_getNetworkStatsSummary:
{
data.enforceInterface(DESCRIPTOR);
android.net.NetworkStats _result = this.getNetworkStatsSummary();
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
case TRANSACTION_getNetworkStatsDetail:
{
data.enforceInterface(DESCRIPTOR);
android.net.NetworkStats _result = this.getNetworkStatsDetail();
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
case TRANSACTION_getNetworkStatsUidDetail:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.net.NetworkStats _result = this.getNetworkStatsUidDetail(_arg0);
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
case TRANSACTION_getNetworkStatsTethering:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String[] _arg0;
_arg0 = data.createStringArray();
android.net.NetworkStats _result = this.getNetworkStatsTethering(_arg0);
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
case TRANSACTION_setInterfaceQuota:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
long _arg1;
_arg1 = data.readLong();
this.setInterfaceQuota(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeInterfaceQuota:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.removeInterfaceQuota(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setInterfaceAlert:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
long _arg1;
_arg1 = data.readLong();
this.setInterfaceAlert(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_removeInterfaceAlert:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.removeInterfaceAlert(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setGlobalAlert:
{
data.enforceInterface(DESCRIPTOR);
long _arg0;
_arg0 = data.readLong();
this.setGlobalAlert(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setUidNetworkRules:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setUidNetworkRules(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_isBandwidthControlEnabled:
{
data.enforceInterface(DESCRIPTOR);
boolean _result = this.isBandwidthControlEnabled();
reply.writeNoException();
reply.writeInt(((_result)?(1):(0)));
return true;
}
case TRANSACTION_setInterfaceThrottle:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
this.setInterfaceThrottle(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_getInterfaceRxThrottle:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _result = this.getInterfaceRxThrottle(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_getInterfaceTxThrottle:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _result = this.getInterfaceTxThrottle(_arg0);
reply.writeNoException();
reply.writeInt(_result);
return true;
}
case TRANSACTION_setDefaultInterfaceForDns:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.setDefaultInterfaceForDns(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_setDnsServersForInterface:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
java.lang.String[] _arg1;
_arg1 = data.createStringArray();
this.setDnsServersForInterface(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_flushDefaultDnsCache:
{
data.enforceInterface(DESCRIPTOR);
this.flushDefaultDnsCache();
reply.writeNoException();
return true;
}
case TRANSACTION_flushInterfaceDnsCache:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.flushInterfaceDnsCache(_arg0);
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.os.INetworkManagementService
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
     ** GENERAL
     *//**
     * Register an observer to receive events
     */
public void registerObserver(android.net.INetworkManagementEventObserver obs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((obs!=null))?(obs.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_registerObserver, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Unregister an observer from receiving events.
     */
public void unregisterObserver(android.net.INetworkManagementEventObserver obs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((obs!=null))?(obs.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_unregisterObserver, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Returns a list of currently known network interfaces
     */
public java.lang.String[] listInterfaces() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_listInterfaces, _data, _reply, 0);
_reply.readException();
_result = _reply.createStringArray();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Retrieves the specified interface config
     *
     */
public android.net.InterfaceConfiguration getInterfaceConfig(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.InterfaceConfiguration _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_getInterfaceConfig, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.InterfaceConfiguration.CREATOR.createFromParcel(_reply);
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
     * Sets the configuration of the specified interface
     */
public void setInterfaceConfig(java.lang.String iface, android.net.InterfaceConfiguration cfg) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
if ((cfg!=null)) {
_data.writeInt(1);
cfg.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_setInterfaceConfig, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Clear all IP addresses on the specified interface
     */
public void clearInterfaceAddresses(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_clearInterfaceAddresses, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Set interface down
     */
public void setInterfaceDown(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_setInterfaceDown, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Set interface up
     */
public void setInterfaceUp(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_setInterfaceUp, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Set interface IPv6 privacy extensions
     */
public void setInterfaceIpv6PrivacyExtensions(java.lang.String iface, boolean enable) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
_data.writeInt(((enable)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setInterfaceIpv6PrivacyExtensions, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Disable IPv6 on an interface
     */
public void disableIpv6(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_disableIpv6, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Enable IPv6 on an interface
     */
public void enableIpv6(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_enableIpv6, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Retrieves the network routes currently configured on the specified
     * interface
     */
public android.net.RouteInfo[] getRoutes(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.RouteInfo[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_getRoutes, _data, _reply, 0);
_reply.readException();
_result = _reply.createTypedArray(android.net.RouteInfo.CREATOR);
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Add the specified route to the interface.
     */
public void addRoute(java.lang.String iface, android.net.RouteInfo route) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
if ((route!=null)) {
_data.writeInt(1);
route.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_addRoute, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Remove the specified route from the interface.
     */
public void removeRoute(java.lang.String iface, android.net.RouteInfo route) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
if ((route!=null)) {
_data.writeInt(1);
route.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_removeRoute, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Shuts down the service
     */
public void shutdown() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_shutdown, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     ** TETHERING RELATED
     *//**
     * Returns true if IP forwarding is enabled
     */
public boolean getIpForwardingEnabled() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getIpForwardingEnabled, _data, _reply, 0);
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
     * Enables/Disables IP Forwarding
     */
public void setIpForwardingEnabled(boolean enabled) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(((enabled)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setIpForwardingEnabled, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Start tethering services with the specified dhcp server range
     * arg is a set of start end pairs defining the ranges.
     */
public void startTethering(java.lang.String[] dhcpRanges) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStringArray(dhcpRanges);
mRemote.transact(Stub.TRANSACTION_startTethering, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Stop currently running tethering services
     */
public void stopTethering() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_stopTethering, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Returns true if tethering services are started
     */
public boolean isTetheringStarted() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isTetheringStarted, _data, _reply, 0);
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
     * Tethers the specified interface
     */
public void tetherInterface(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_tetherInterface, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Untethers the specified interface
     */
public void untetherInterface(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_untetherInterface, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Returns a list of currently tethered interfaces
     */
public java.lang.String[] listTetheredInterfaces() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_listTetheredInterfaces, _data, _reply, 0);
_reply.readException();
_result = _reply.createStringArray();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Sets the list of DNS forwarders (in order of priority)
     */
public void setDnsForwarders(java.lang.String[] dns) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStringArray(dns);
mRemote.transact(Stub.TRANSACTION_setDnsForwarders, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Returns the list of DNS fowarders (in order of priority)
     */
public java.lang.String[] getDnsForwarders() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getDnsForwarders, _data, _reply, 0);
_reply.readException();
_result = _reply.createStringArray();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     *  Enables Network Address Translation between two interfaces.
     *  The address and netmask of the external interface is used for
     *  the NAT'ed network.
     */
public void enableNat(java.lang.String internalInterface, java.lang.String externalInterface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(internalInterface);
_data.writeString(externalInterface);
mRemote.transact(Stub.TRANSACTION_enableNat, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     *  Disables Network Address Translation between two interfaces.
     */
public void disableNat(java.lang.String internalInterface, java.lang.String externalInterface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(internalInterface);
_data.writeString(externalInterface);
mRemote.transact(Stub.TRANSACTION_disableNat, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     ** PPPD
     *//**
     * Returns the list of currently known TTY devices on the system
     */
public java.lang.String[] listTtys() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String[] _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_listTtys, _data, _reply, 0);
_reply.readException();
_result = _reply.createStringArray();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
/**
     * Attaches a PPP server daemon to the specified TTY with the specified
     * local/remote addresses.
     */
public void attachPppd(java.lang.String tty, java.lang.String localAddr, java.lang.String remoteAddr, java.lang.String dns1Addr, java.lang.String dns2Addr) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(tty);
_data.writeString(localAddr);
_data.writeString(remoteAddr);
_data.writeString(dns1Addr);
_data.writeString(dns2Addr);
mRemote.transact(Stub.TRANSACTION_attachPppd, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Detaches a PPP server daemon from the specified TTY.
     */
public void detachPppd(java.lang.String tty) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(tty);
mRemote.transact(Stub.TRANSACTION_detachPppd, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Load firmware for operation in the given mode. Currently the three
     * modes supported are "AP", "STA" and "P2P".
     */
public void wifiFirmwareReload(java.lang.String wlanIface, java.lang.String mode) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(wlanIface);
_data.writeString(mode);
mRemote.transact(Stub.TRANSACTION_wifiFirmwareReload, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Start Wifi Access Point
     */
public void startAccessPoint(android.net.wifi.WifiConfiguration wifiConfig, java.lang.String wlanIface, java.lang.String softapIface) throws android.os.RemoteException
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
_data.writeString(wlanIface);
_data.writeString(softapIface);
mRemote.transact(Stub.TRANSACTION_startAccessPoint, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Stop Wifi Access Point
     */
public void stopAccessPoint(java.lang.String wlanIface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(wlanIface);
mRemote.transact(Stub.TRANSACTION_stopAccessPoint, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Set Access Point config
     */
public void setAccessPoint(android.net.wifi.WifiConfiguration wifiConfig, java.lang.String wlanIface, java.lang.String softapIface) throws android.os.RemoteException
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
_data.writeString(wlanIface);
_data.writeString(softapIface);
mRemote.transact(Stub.TRANSACTION_setAccessPoint, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     ** DATA USAGE RELATED
     *//**
     * Return global network statistics summarized at an interface level,
     * without any UID-level granularity.
     */
public android.net.NetworkStats getNetworkStatsSummary() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStats _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getNetworkStatsSummary, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.NetworkStats.CREATOR.createFromParcel(_reply);
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
     * Return detailed network statistics with UID-level granularity,
     * including interface and tag details.
     */
public android.net.NetworkStats getNetworkStatsDetail() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStats _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getNetworkStatsDetail, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.NetworkStats.CREATOR.createFromParcel(_reply);
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
     * Return detailed network statistics for the requested UID,
     * including interface and tag details.
     */
public android.net.NetworkStats getNetworkStatsUidDetail(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStats _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_getNetworkStatsUidDetail, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.NetworkStats.CREATOR.createFromParcel(_reply);
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
     * Return summary of network statistics for the requested pairs of
     * tethering interfaces.  Even indexes are remote interface, and odd
     * indexes are corresponding local interfaces.
     */
public android.net.NetworkStats getNetworkStatsTethering(java.lang.String[] ifacePairs) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStats _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStringArray(ifacePairs);
mRemote.transact(Stub.TRANSACTION_getNetworkStatsTethering, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.NetworkStats.CREATOR.createFromParcel(_reply);
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
     * Set quota for an interface.
     */
public void setInterfaceQuota(java.lang.String iface, long quotaBytes) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
_data.writeLong(quotaBytes);
mRemote.transact(Stub.TRANSACTION_setInterfaceQuota, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Remove quota for an interface.
     */
public void removeInterfaceQuota(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_removeInterfaceQuota, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Set alert for an interface; requires that iface already has quota.
     */
public void setInterfaceAlert(java.lang.String iface, long alertBytes) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
_data.writeLong(alertBytes);
mRemote.transact(Stub.TRANSACTION_setInterfaceAlert, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Remove alert for an interface.
     */
public void removeInterfaceAlert(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_removeInterfaceAlert, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Set alert across all interfaces.
     */
public void setGlobalAlert(long alertBytes) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeLong(alertBytes);
mRemote.transact(Stub.TRANSACTION_setGlobalAlert, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Control network activity of a UID over interfaces with a quota limit.
     */
public void setUidNetworkRules(int uid, boolean rejectOnQuotaInterfaces) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(((rejectOnQuotaInterfaces)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setUidNetworkRules, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Return status of bandwidth control module.
     */
public boolean isBandwidthControlEnabled() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
boolean _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_isBandwidthControlEnabled, _data, _reply, 0);
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
     * Configures bandwidth throttling on an interface.
     */
public void setInterfaceThrottle(java.lang.String iface, int rxKbps, int txKbps) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
_data.writeInt(rxKbps);
_data.writeInt(txKbps);
mRemote.transact(Stub.TRANSACTION_setInterfaceThrottle, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Returns the currently configured RX throttle values
     * for the specified interface
     */
public int getInterfaceRxThrottle(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_getInterfaceRxThrottle, _data, _reply, 0);
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
     * Returns the currently configured TX throttle values
     * for the specified interface
     */
public int getInterfaceTxThrottle(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_getInterfaceTxThrottle, _data, _reply, 0);
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
     * Sets the name of the default interface in the DNS resolver.
     */
public void setDefaultInterfaceForDns(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_setDefaultInterfaceForDns, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Bind name servers to an interface in the DNS resolver.
     */
public void setDnsServersForInterface(java.lang.String iface, java.lang.String[] servers) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
_data.writeStringArray(servers);
mRemote.transact(Stub.TRANSACTION_setDnsServersForInterface, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Flush the DNS cache associated with the default interface.
     */
public void flushDefaultDnsCache() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_flushDefaultDnsCache, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/**
     * Flush the DNS cache associated with the specified interface.
     */
public void flushInterfaceDnsCache(java.lang.String iface) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(iface);
mRemote.transact(Stub.TRANSACTION_flushInterfaceDnsCache, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_registerObserver = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_unregisterObserver = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_listInterfaces = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getInterfaceConfig = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_setInterfaceConfig = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_clearInterfaceAddresses = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setInterfaceDown = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_setInterfaceUp = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
static final int TRANSACTION_setInterfaceIpv6PrivacyExtensions = (android.os.IBinder.FIRST_CALL_TRANSACTION + 8);
static final int TRANSACTION_disableIpv6 = (android.os.IBinder.FIRST_CALL_TRANSACTION + 9);
static final int TRANSACTION_enableIpv6 = (android.os.IBinder.FIRST_CALL_TRANSACTION + 10);
static final int TRANSACTION_getRoutes = (android.os.IBinder.FIRST_CALL_TRANSACTION + 11);
static final int TRANSACTION_addRoute = (android.os.IBinder.FIRST_CALL_TRANSACTION + 12);
static final int TRANSACTION_removeRoute = (android.os.IBinder.FIRST_CALL_TRANSACTION + 13);
static final int TRANSACTION_shutdown = (android.os.IBinder.FIRST_CALL_TRANSACTION + 14);
static final int TRANSACTION_getIpForwardingEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 15);
static final int TRANSACTION_setIpForwardingEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 16);
static final int TRANSACTION_startTethering = (android.os.IBinder.FIRST_CALL_TRANSACTION + 17);
static final int TRANSACTION_stopTethering = (android.os.IBinder.FIRST_CALL_TRANSACTION + 18);
static final int TRANSACTION_isTetheringStarted = (android.os.IBinder.FIRST_CALL_TRANSACTION + 19);
static final int TRANSACTION_tetherInterface = (android.os.IBinder.FIRST_CALL_TRANSACTION + 20);
static final int TRANSACTION_untetherInterface = (android.os.IBinder.FIRST_CALL_TRANSACTION + 21);
static final int TRANSACTION_listTetheredInterfaces = (android.os.IBinder.FIRST_CALL_TRANSACTION + 22);
static final int TRANSACTION_setDnsForwarders = (android.os.IBinder.FIRST_CALL_TRANSACTION + 23);
static final int TRANSACTION_getDnsForwarders = (android.os.IBinder.FIRST_CALL_TRANSACTION + 24);
static final int TRANSACTION_enableNat = (android.os.IBinder.FIRST_CALL_TRANSACTION + 25);
static final int TRANSACTION_disableNat = (android.os.IBinder.FIRST_CALL_TRANSACTION + 26);
static final int TRANSACTION_listTtys = (android.os.IBinder.FIRST_CALL_TRANSACTION + 27);
static final int TRANSACTION_attachPppd = (android.os.IBinder.FIRST_CALL_TRANSACTION + 28);
static final int TRANSACTION_detachPppd = (android.os.IBinder.FIRST_CALL_TRANSACTION + 29);
static final int TRANSACTION_wifiFirmwareReload = (android.os.IBinder.FIRST_CALL_TRANSACTION + 30);
static final int TRANSACTION_startAccessPoint = (android.os.IBinder.FIRST_CALL_TRANSACTION + 31);
static final int TRANSACTION_stopAccessPoint = (android.os.IBinder.FIRST_CALL_TRANSACTION + 32);
static final int TRANSACTION_setAccessPoint = (android.os.IBinder.FIRST_CALL_TRANSACTION + 33);
static final int TRANSACTION_getNetworkStatsSummary = (android.os.IBinder.FIRST_CALL_TRANSACTION + 34);
static final int TRANSACTION_getNetworkStatsDetail = (android.os.IBinder.FIRST_CALL_TRANSACTION + 35);
static final int TRANSACTION_getNetworkStatsUidDetail = (android.os.IBinder.FIRST_CALL_TRANSACTION + 36);
static final int TRANSACTION_getNetworkStatsTethering = (android.os.IBinder.FIRST_CALL_TRANSACTION + 37);
static final int TRANSACTION_setInterfaceQuota = (android.os.IBinder.FIRST_CALL_TRANSACTION + 38);
static final int TRANSACTION_removeInterfaceQuota = (android.os.IBinder.FIRST_CALL_TRANSACTION + 39);
static final int TRANSACTION_setInterfaceAlert = (android.os.IBinder.FIRST_CALL_TRANSACTION + 40);
static final int TRANSACTION_removeInterfaceAlert = (android.os.IBinder.FIRST_CALL_TRANSACTION + 41);
static final int TRANSACTION_setGlobalAlert = (android.os.IBinder.FIRST_CALL_TRANSACTION + 42);
static final int TRANSACTION_setUidNetworkRules = (android.os.IBinder.FIRST_CALL_TRANSACTION + 43);
static final int TRANSACTION_isBandwidthControlEnabled = (android.os.IBinder.FIRST_CALL_TRANSACTION + 44);
static final int TRANSACTION_setInterfaceThrottle = (android.os.IBinder.FIRST_CALL_TRANSACTION + 45);
static final int TRANSACTION_getInterfaceRxThrottle = (android.os.IBinder.FIRST_CALL_TRANSACTION + 46);
static final int TRANSACTION_getInterfaceTxThrottle = (android.os.IBinder.FIRST_CALL_TRANSACTION + 47);
static final int TRANSACTION_setDefaultInterfaceForDns = (android.os.IBinder.FIRST_CALL_TRANSACTION + 48);
static final int TRANSACTION_setDnsServersForInterface = (android.os.IBinder.FIRST_CALL_TRANSACTION + 49);
static final int TRANSACTION_flushDefaultDnsCache = (android.os.IBinder.FIRST_CALL_TRANSACTION + 50);
static final int TRANSACTION_flushInterfaceDnsCache = (android.os.IBinder.FIRST_CALL_TRANSACTION + 51);
}
/**
     ** GENERAL
     *//**
     * Register an observer to receive events
     */
public void registerObserver(android.net.INetworkManagementEventObserver obs) throws android.os.RemoteException;
/**
     * Unregister an observer from receiving events.
     */
public void unregisterObserver(android.net.INetworkManagementEventObserver obs) throws android.os.RemoteException;
/**
     * Returns a list of currently known network interfaces
     */
public java.lang.String[] listInterfaces() throws android.os.RemoteException;
/**
     * Retrieves the specified interface config
     *
     */
public android.net.InterfaceConfiguration getInterfaceConfig(java.lang.String iface) throws android.os.RemoteException;
/**
     * Sets the configuration of the specified interface
     */
public void setInterfaceConfig(java.lang.String iface, android.net.InterfaceConfiguration cfg) throws android.os.RemoteException;
/**
     * Clear all IP addresses on the specified interface
     */
public void clearInterfaceAddresses(java.lang.String iface) throws android.os.RemoteException;
/**
     * Set interface down
     */
public void setInterfaceDown(java.lang.String iface) throws android.os.RemoteException;
/**
     * Set interface up
     */
public void setInterfaceUp(java.lang.String iface) throws android.os.RemoteException;
/**
     * Set interface IPv6 privacy extensions
     */
public void setInterfaceIpv6PrivacyExtensions(java.lang.String iface, boolean enable) throws android.os.RemoteException;
/**
     * Disable IPv6 on an interface
     */
public void disableIpv6(java.lang.String iface) throws android.os.RemoteException;
/**
     * Enable IPv6 on an interface
     */
public void enableIpv6(java.lang.String iface) throws android.os.RemoteException;
/**
     * Retrieves the network routes currently configured on the specified
     * interface
     */
public android.net.RouteInfo[] getRoutes(java.lang.String iface) throws android.os.RemoteException;
/**
     * Add the specified route to the interface.
     */
public void addRoute(java.lang.String iface, android.net.RouteInfo route) throws android.os.RemoteException;
/**
     * Remove the specified route from the interface.
     */
public void removeRoute(java.lang.String iface, android.net.RouteInfo route) throws android.os.RemoteException;
/**
     * Shuts down the service
     */
public void shutdown() throws android.os.RemoteException;
/**
     ** TETHERING RELATED
     *//**
     * Returns true if IP forwarding is enabled
     */
public boolean getIpForwardingEnabled() throws android.os.RemoteException;
/**
     * Enables/Disables IP Forwarding
     */
public void setIpForwardingEnabled(boolean enabled) throws android.os.RemoteException;
/**
     * Start tethering services with the specified dhcp server range
     * arg is a set of start end pairs defining the ranges.
     */
public void startTethering(java.lang.String[] dhcpRanges) throws android.os.RemoteException;
/**
     * Stop currently running tethering services
     */
public void stopTethering() throws android.os.RemoteException;
/**
     * Returns true if tethering services are started
     */
public boolean isTetheringStarted() throws android.os.RemoteException;
/**
     * Tethers the specified interface
     */
public void tetherInterface(java.lang.String iface) throws android.os.RemoteException;
/**
     * Untethers the specified interface
     */
public void untetherInterface(java.lang.String iface) throws android.os.RemoteException;
/**
     * Returns a list of currently tethered interfaces
     */
public java.lang.String[] listTetheredInterfaces() throws android.os.RemoteException;
/**
     * Sets the list of DNS forwarders (in order of priority)
     */
public void setDnsForwarders(java.lang.String[] dns) throws android.os.RemoteException;
/**
     * Returns the list of DNS fowarders (in order of priority)
     */
public java.lang.String[] getDnsForwarders() throws android.os.RemoteException;
/**
     *  Enables Network Address Translation between two interfaces.
     *  The address and netmask of the external interface is used for
     *  the NAT'ed network.
     */
public void enableNat(java.lang.String internalInterface, java.lang.String externalInterface) throws android.os.RemoteException;
/**
     *  Disables Network Address Translation between two interfaces.
     */
public void disableNat(java.lang.String internalInterface, java.lang.String externalInterface) throws android.os.RemoteException;
/**
     ** PPPD
     *//**
     * Returns the list of currently known TTY devices on the system
     */
public java.lang.String[] listTtys() throws android.os.RemoteException;
/**
     * Attaches a PPP server daemon to the specified TTY with the specified
     * local/remote addresses.
     */
public void attachPppd(java.lang.String tty, java.lang.String localAddr, java.lang.String remoteAddr, java.lang.String dns1Addr, java.lang.String dns2Addr) throws android.os.RemoteException;
/**
     * Detaches a PPP server daemon from the specified TTY.
     */
public void detachPppd(java.lang.String tty) throws android.os.RemoteException;
/**
     * Load firmware for operation in the given mode. Currently the three
     * modes supported are "AP", "STA" and "P2P".
     */
public void wifiFirmwareReload(java.lang.String wlanIface, java.lang.String mode) throws android.os.RemoteException;
/**
     * Start Wifi Access Point
     */
public void startAccessPoint(android.net.wifi.WifiConfiguration wifiConfig, java.lang.String wlanIface, java.lang.String softapIface) throws android.os.RemoteException;
/**
     * Stop Wifi Access Point
     */
public void stopAccessPoint(java.lang.String wlanIface) throws android.os.RemoteException;
/**
     * Set Access Point config
     */
public void setAccessPoint(android.net.wifi.WifiConfiguration wifiConfig, java.lang.String wlanIface, java.lang.String softapIface) throws android.os.RemoteException;
/**
     ** DATA USAGE RELATED
     *//**
     * Return global network statistics summarized at an interface level,
     * without any UID-level granularity.
     */
public android.net.NetworkStats getNetworkStatsSummary() throws android.os.RemoteException;
/**
     * Return detailed network statistics with UID-level granularity,
     * including interface and tag details.
     */
public android.net.NetworkStats getNetworkStatsDetail() throws android.os.RemoteException;
/**
     * Return detailed network statistics for the requested UID,
     * including interface and tag details.
     */
public android.net.NetworkStats getNetworkStatsUidDetail(int uid) throws android.os.RemoteException;
/**
     * Return summary of network statistics for the requested pairs of
     * tethering interfaces.  Even indexes are remote interface, and odd
     * indexes are corresponding local interfaces.
     */
public android.net.NetworkStats getNetworkStatsTethering(java.lang.String[] ifacePairs) throws android.os.RemoteException;
/**
     * Set quota for an interface.
     */
public void setInterfaceQuota(java.lang.String iface, long quotaBytes) throws android.os.RemoteException;
/**
     * Remove quota for an interface.
     */
public void removeInterfaceQuota(java.lang.String iface) throws android.os.RemoteException;
/**
     * Set alert for an interface; requires that iface already has quota.
     */
public void setInterfaceAlert(java.lang.String iface, long alertBytes) throws android.os.RemoteException;
/**
     * Remove alert for an interface.
     */
public void removeInterfaceAlert(java.lang.String iface) throws android.os.RemoteException;
/**
     * Set alert across all interfaces.
     */
public void setGlobalAlert(long alertBytes) throws android.os.RemoteException;
/**
     * Control network activity of a UID over interfaces with a quota limit.
     */
public void setUidNetworkRules(int uid, boolean rejectOnQuotaInterfaces) throws android.os.RemoteException;
/**
     * Return status of bandwidth control module.
     */
public boolean isBandwidthControlEnabled() throws android.os.RemoteException;
/**
     * Configures bandwidth throttling on an interface.
     */
public void setInterfaceThrottle(java.lang.String iface, int rxKbps, int txKbps) throws android.os.RemoteException;
/**
     * Returns the currently configured RX throttle values
     * for the specified interface
     */
public int getInterfaceRxThrottle(java.lang.String iface) throws android.os.RemoteException;
/**
     * Returns the currently configured TX throttle values
     * for the specified interface
     */
public int getInterfaceTxThrottle(java.lang.String iface) throws android.os.RemoteException;
/**
     * Sets the name of the default interface in the DNS resolver.
     */
public void setDefaultInterfaceForDns(java.lang.String iface) throws android.os.RemoteException;
/**
     * Bind name servers to an interface in the DNS resolver.
     */
public void setDnsServersForInterface(java.lang.String iface, java.lang.String[] servers) throws android.os.RemoteException;
/**
     * Flush the DNS cache associated with the default interface.
     */
public void flushDefaultDnsCache() throws android.os.RemoteException;
/**
     * Flush the DNS cache associated with the specified interface.
     */
public void flushInterfaceDnsCache(java.lang.String iface) throws android.os.RemoteException;
}
