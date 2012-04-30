/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/com/android/internal/appwidget/IAppWidgetHost.aidl
 */
package com.android.internal.appwidget;
/** {@hide} */
public interface IAppWidgetHost extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements com.android.internal.appwidget.IAppWidgetHost
{
private static final java.lang.String DESCRIPTOR = "com.android.internal.appwidget.IAppWidgetHost";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an com.android.internal.appwidget.IAppWidgetHost interface,
 * generating a proxy if needed.
 */
public static com.android.internal.appwidget.IAppWidgetHost asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof com.android.internal.appwidget.IAppWidgetHost))) {
return ((com.android.internal.appwidget.IAppWidgetHost)iin);
}
return new com.android.internal.appwidget.IAppWidgetHost.Stub.Proxy(obj);
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
case TRANSACTION_updateAppWidget:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.widget.RemoteViews _arg1;
if ((0!=data.readInt())) {
_arg1 = android.widget.RemoteViews.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.updateAppWidget(_arg0, _arg1);
return true;
}
case TRANSACTION_providerChanged:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
android.appwidget.AppWidgetProviderInfo _arg1;
if ((0!=data.readInt())) {
_arg1 = android.appwidget.AppWidgetProviderInfo.CREATOR.createFromParcel(data);
}
else {
_arg1 = null;
}
this.providerChanged(_arg0, _arg1);
return true;
}
case TRANSACTION_viewDataChanged:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
int _arg1;
_arg1 = data.readInt();
this.viewDataChanged(_arg0, _arg1);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements com.android.internal.appwidget.IAppWidgetHost
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
public void updateAppWidget(int appWidgetId, android.widget.RemoteViews views) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(appWidgetId);
if ((views!=null)) {
_data.writeInt(1);
views.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_updateAppWidget, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void providerChanged(int appWidgetId, android.appwidget.AppWidgetProviderInfo info) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(appWidgetId);
if ((info!=null)) {
_data.writeInt(1);
info.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
mRemote.transact(Stub.TRANSACTION_providerChanged, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
public void viewDataChanged(int appWidgetId, int viewId) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(appWidgetId);
_data.writeInt(viewId);
mRemote.transact(Stub.TRANSACTION_viewDataChanged, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_updateAppWidget = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_providerChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_viewDataChanged = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
}
public void updateAppWidget(int appWidgetId, android.widget.RemoteViews views) throws android.os.RemoteException;
public void providerChanged(int appWidgetId, android.appwidget.AppWidgetProviderInfo info) throws android.os.RemoteException;
public void viewDataChanged(int appWidgetId, int viewId) throws android.os.RemoteException;
}
