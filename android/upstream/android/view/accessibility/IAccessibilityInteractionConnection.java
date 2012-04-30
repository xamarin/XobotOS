/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/view/accessibility/IAccessibilityInteractionConnection.aidl
 */
package android.view.accessibility;
/**
 * Interface for interaction between the AccessibilityManagerService
 * and the ViewRoot in a given window.
 *
 * @hide
 */
public interface IAccessibilityInteractionConnection extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.view.accessibility.IAccessibilityInteractionConnection
{
private static final java.lang.String DESCRIPTOR = "android.view.accessibility.IAccessibilityInteractionConnection";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.view.accessibility.IAccessibilityInteractionConnection interface,
 * generating a proxy if needed.
 */
public static android.view.accessibility.IAccessibilityInteractionConnection asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.view.accessibility.IAccessibilityInteractionConnection))) {
return ((android.view.accessibility.IAccessibilityInteractionConnection)iin);
}
return new android.view.accessibility.IAccessibilityInteractionConnection.Stub.Proxy(obj);
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
case TRANSACTION_findAccessibilityNodeInfoByAccessibilityId:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
android.view.accessibility.IAccessibilityInteractionConnectionCallback _arg2;
_arg2 = android.view.accessibility.IAccessibilityInteractionConnectionCallback.Stub.asInterface(data.readStrongBinder());
int _arg3;
_arg3 = data.readInt();
long _arg4;
_arg4 = data.readLong();
this.findAccessibilityNodeInfoByAccessibilityId(_arg0, _arg1, _arg2, _arg3, _arg4);
return true;
}
case TRANSACTION_findAccessibilityNodeInfoByViewId:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
android.view.accessibility.IAccessibilityInteractionConnectionCallback _arg2;
_arg2 = android.view.accessibility.IAccessibilityInteractionConnectionCallback.Stub.asInterface(data.readStrongBinder());
int _arg3;
_arg3 = data.readInt();
long _arg4;
_arg4 = data.readLong();
this.findAccessibilityNodeInfoByViewId(_arg0, _arg1, _arg2, _arg3, _arg4);
return true;
}
case TRANSACTION_findAccessibilityNodeInfosByViewText:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
android.view.accessibility.IAccessibilityInteractionConnectionCallback _arg3;
_arg3 = android.view.accessibility.IAccessibilityInteractionConnectionCallback.Stub.asInterface(data.readStrongBinder());
int _arg4;
_arg4 = data.readInt();
long _arg5;
_arg5 = data.readLong();
this.findAccessibilityNodeInfosByViewText(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
return true;
}
case TRANSACTION_performAccessibilityAction:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
int _arg2;
_arg2 = data.readInt();
android.view.accessibility.IAccessibilityInteractionConnectionCallback _arg3;
_arg3 = android.view.accessibility.IAccessibilityInteractionConnectionCallback.Stub.asInterface(data.readStrongBinder());
int _arg4;
_arg4 = data.readInt();
long _arg5;
_arg5 = data.readLong();
this.performAccessibilityAction(_arg0, _arg1, _arg2, _arg3, _arg4, _arg5);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.view.accessibility.IAccessibilityInteractionConnection
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
public void findAccessibilityNodeInfoByAccessibilityId(int accessibilityViewId, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(accessibilityViewId);
_data.writeInt(interactionId);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
_data.writeInt(interrogatingPid);
_data.writeLong(interrogatingTid);
mRemote.transact(Stub.TRANSACTION_findAccessibilityNodeInfoByAccessibilityId, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void findAccessibilityNodeInfoByViewId(int id, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(id);
_data.writeInt(interactionId);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
_data.writeInt(interrogatingPid);
_data.writeLong(interrogatingTid);
mRemote.transact(Stub.TRANSACTION_findAccessibilityNodeInfoByViewId, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void findAccessibilityNodeInfosByViewText(java.lang.String text, int accessibilityViewId, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(text);
_data.writeInt(accessibilityViewId);
_data.writeInt(interactionId);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
_data.writeInt(interrogatingPid);
_data.writeLong(interrogatingTid);
mRemote.transact(Stub.TRANSACTION_findAccessibilityNodeInfosByViewText, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void performAccessibilityAction(int accessibilityId, int action, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(accessibilityId);
_data.writeInt(action);
_data.writeInt(interactionId);
_data.writeStrongBinder((((callback!=null))?(callback.asBinder()):(null)));
_data.writeInt(interrogatingPid);
_data.writeLong(interrogatingTid);
mRemote.transact(Stub.TRANSACTION_performAccessibilityAction, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_findAccessibilityNodeInfoByAccessibilityId = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_findAccessibilityNodeInfoByViewId = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_findAccessibilityNodeInfosByViewText = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_performAccessibilityAction = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
}
public void findAccessibilityNodeInfoByAccessibilityId(int accessibilityViewId, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException;
public void findAccessibilityNodeInfoByViewId(int id, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException;
public void findAccessibilityNodeInfosByViewText(java.lang.String text, int accessibilityViewId, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException;
public void performAccessibilityAction(int accessibilityId, int action, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, int interrogatingPid, long interrogatingTid) throws android.os.RemoteException;
}
