/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/net/INetworkStatsService.aidl
 */
package android.net;
/** {@hide} */
public interface INetworkStatsService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.net.INetworkStatsService
{
private static final java.lang.String DESCRIPTOR = "android.net.INetworkStatsService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.net.INetworkStatsService interface,
 * generating a proxy if needed.
 */
public static android.net.INetworkStatsService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.net.INetworkStatsService))) {
return ((android.net.INetworkStatsService)iin);
}
return new android.net.INetworkStatsService.Stub.Proxy(obj);
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
case TRANSACTION_getHistoryForNetwork:
{
data.enforceInterface(DESCRIPTOR);
android.net.NetworkTemplate _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.NetworkTemplate.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
android.net.NetworkStatsHistory _result = this.getHistoryForNetwork(_arg0, _arg1);
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
case TRANSACTION_getHistoryForUid:
{
data.enforceInterface(DESCRIPTOR);
android.net.NetworkTemplate _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.NetworkTemplate.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
int _arg3;
_arg3 = data.readInt();
int _arg4;
_arg4 = data.readInt();
android.net.NetworkStatsHistory _result = this.getHistoryForUid(_arg0, _arg1, _arg2, _arg3, _arg4);
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
case TRANSACTION_getSummaryForNetwork:
{
data.enforceInterface(DESCRIPTOR);
android.net.NetworkTemplate _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.NetworkTemplate.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _arg1;
_arg1 = data.readLong();
long _arg2;
_arg2 = data.readLong();
android.net.NetworkStats _result = this.getSummaryForNetwork(_arg0, _arg1, _arg2);
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
case TRANSACTION_getSummaryForAllUid:
{
data.enforceInterface(DESCRIPTOR);
android.net.NetworkTemplate _arg0;
if ((0!=data.readInt())) {
_arg0 = android.net.NetworkTemplate.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
long _arg1;
_arg1 = data.readLong();
long _arg2;
_arg2 = data.readLong();
boolean _arg3;
_arg3 = (0!=data.readInt());
android.net.NetworkStats _result = this.getSummaryForAllUid(_arg0, _arg1, _arg2, _arg3);
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
case TRANSACTION_getDataLayerSnapshotForUid:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.net.NetworkStats _result = this.getDataLayerSnapshotForUid(_arg0);
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
case TRANSACTION_incrementOperationCount:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
this.incrementOperationCount(_arg0, _arg1, _arg2);
reply.writeNoException();
return true;
}
case TRANSACTION_setUidForeground:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
boolean _arg1;
_arg1 = (0!=data.readInt());
this.setUidForeground(_arg0, _arg1);
reply.writeNoException();
return true;
}
case TRANSACTION_forceUpdate:
{
data.enforceInterface(DESCRIPTOR);
this.forceUpdate();
reply.writeNoException();
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.net.INetworkStatsService
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
/** Return historical network layer stats for traffic that matches template. */
public android.net.NetworkStatsHistory getHistoryForNetwork(android.net.NetworkTemplate template, int fields) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStatsHistory _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((template!=null)) {
_data.writeInt(1);
template.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(fields);
mRemote.transact(Stub.TRANSACTION_getHistoryForNetwork, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.NetworkStatsHistory.CREATOR.createFromParcel(_reply);
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
/** Return historical network layer stats for specific UID traffic that matches template. */
public android.net.NetworkStatsHistory getHistoryForUid(android.net.NetworkTemplate template, int uid, int set, int tag, int fields) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStatsHistory _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((template!=null)) {
_data.writeInt(1);
template.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeInt(uid);
_data.writeInt(set);
_data.writeInt(tag);
_data.writeInt(fields);
mRemote.transact(Stub.TRANSACTION_getHistoryForUid, _data, _reply, 0);
_reply.readException();
if ((0!=_reply.readInt())) {
_result = android.net.NetworkStatsHistory.CREATOR.createFromParcel(_reply);
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
/** Return network layer usage summary for traffic that matches template. */
public android.net.NetworkStats getSummaryForNetwork(android.net.NetworkTemplate template, long start, long end) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStats _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((template!=null)) {
_data.writeInt(1);
template.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeLong(start);
_data.writeLong(end);
mRemote.transact(Stub.TRANSACTION_getSummaryForNetwork, _data, _reply, 0);
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
/** Return network layer usage summary per UID for traffic that matches template. */
public android.net.NetworkStats getSummaryForAllUid(android.net.NetworkTemplate template, long start, long end, boolean includeTags) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStats _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((template!=null)) {
_data.writeInt(1);
template.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeLong(start);
_data.writeLong(end);
_data.writeInt(((includeTags)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_getSummaryForAllUid, _data, _reply, 0);
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
/** Return data layer snapshot of UID network usage. */
public android.net.NetworkStats getDataLayerSnapshotForUid(int uid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
android.net.NetworkStats _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
mRemote.transact(Stub.TRANSACTION_getDataLayerSnapshotForUid, _data, _reply, 0);
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
/** Increment data layer count of operations performed for UID and tag. */
public void incrementOperationCount(int uid, int tag, int operationCount) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(tag);
_data.writeInt(operationCount);
mRemote.transact(Stub.TRANSACTION_incrementOperationCount, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/** Mark given UID as being in foreground for stats purposes. */
public void setUidForeground(int uid, boolean uidForeground) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(uid);
_data.writeInt(((uidForeground)?(1):(0)));
mRemote.transact(Stub.TRANSACTION_setUidForeground, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
/** Force update of statistics. */
public void forceUpdate() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_forceUpdate, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
}
static final int TRANSACTION_getHistoryForNetwork = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_getHistoryForUid = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getSummaryForNetwork = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getSummaryForAllUid = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
static final int TRANSACTION_getDataLayerSnapshotForUid = (android.os.IBinder.FIRST_CALL_TRANSACTION + 4);
static final int TRANSACTION_incrementOperationCount = (android.os.IBinder.FIRST_CALL_TRANSACTION + 5);
static final int TRANSACTION_setUidForeground = (android.os.IBinder.FIRST_CALL_TRANSACTION + 6);
static final int TRANSACTION_forceUpdate = (android.os.IBinder.FIRST_CALL_TRANSACTION + 7);
}
/** Return historical network layer stats for traffic that matches template. */
public android.net.NetworkStatsHistory getHistoryForNetwork(android.net.NetworkTemplate template, int fields) throws android.os.RemoteException;
/** Return historical network layer stats for specific UID traffic that matches template. */
public android.net.NetworkStatsHistory getHistoryForUid(android.net.NetworkTemplate template, int uid, int set, int tag, int fields) throws android.os.RemoteException;
/** Return network layer usage summary for traffic that matches template. */
public android.net.NetworkStats getSummaryForNetwork(android.net.NetworkTemplate template, long start, long end) throws android.os.RemoteException;
/** Return network layer usage summary per UID for traffic that matches template. */
public android.net.NetworkStats getSummaryForAllUid(android.net.NetworkTemplate template, long start, long end, boolean includeTags) throws android.os.RemoteException;
/** Return data layer snapshot of UID network usage. */
public android.net.NetworkStats getDataLayerSnapshotForUid(int uid) throws android.os.RemoteException;
/** Increment data layer count of operations performed for UID and tag. */
public void incrementOperationCount(int uid, int tag, int operationCount) throws android.os.RemoteException;
/** Mark given UID as being in foreground for stats purposes. */
public void setUidForeground(int uid, boolean uidForeground) throws android.os.RemoteException;
/** Force update of statistics. */
public void forceUpdate() throws android.os.RemoteException;
}
