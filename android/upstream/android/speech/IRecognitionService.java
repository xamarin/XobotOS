/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: frameworks/base/core/java/android/speech/IRecognitionService.aidl
 */
package android.speech;
/**
* A Service interface to speech recognition. Call startListening when
* you want to begin capturing audio; RecognitionService will automatically
* determine when the user has finished speaking, stream the audio to the
* recognition servers, and notify you when results are ready. In most of the cases, 
* this class should not be used directly, instead use {@link SpeechRecognizer} for
* accessing recognition service. 
* {@hide}
*/
public interface IRecognitionService extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements android.speech.IRecognitionService
{
private static final java.lang.String DESCRIPTOR = "android.speech.IRecognitionService";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an android.speech.IRecognitionService interface,
 * generating a proxy if needed.
 */
public static android.speech.IRecognitionService asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = (android.os.IInterface)obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof android.speech.IRecognitionService))) {
return ((android.speech.IRecognitionService)iin);
}
return new android.speech.IRecognitionService.Stub.Proxy(obj);
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
case TRANSACTION_startListening:
{
data.enforceInterface(DESCRIPTOR);
android.content.Intent _arg0;
if ((0!=data.readInt())) {
_arg0 = android.content.Intent.CREATOR.createFromParcel(data);
}
else {
_arg0 = null;
}
android.speech.IRecognitionListener _arg1;
_arg1 = android.speech.IRecognitionListener.Stub.asInterface(data.readStrongBinder());
this.startListening(_arg0, _arg1);
return true;
}
case TRANSACTION_stopListening:
{
data.enforceInterface(DESCRIPTOR);
android.speech.IRecognitionListener _arg0;
_arg0 = android.speech.IRecognitionListener.Stub.asInterface(data.readStrongBinder());
this.stopListening(_arg0);
return true;
}
case TRANSACTION_cancel:
{
data.enforceInterface(DESCRIPTOR);
android.speech.IRecognitionListener _arg0;
_arg0 = android.speech.IRecognitionListener.Stub.asInterface(data.readStrongBinder());
this.cancel(_arg0);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements android.speech.IRecognitionService
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
     * Starts listening for speech. Please note that the recognition service supports
     * one listener only, therefore, if this function is called from two different threads,
     * only the latest one will get the notifications
     *
     * @param recognizerIntent the intent from which the invocation occurred. Additionally,
     *        this intent can contain extra parameters to manipulate the behavior of the recognition
     *        client. For more information see {@link RecognizerIntent}.
     * @param listener to receive callbacks, note that this must be non-null
     */
public void startListening(android.content.Intent recognizerIntent, android.speech.IRecognitionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
if ((recognizerIntent!=null)) {
_data.writeInt(1);
recognizerIntent.writeToParcel(_data, 0);
}
else {
_data.writeInt(0);
}
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_startListening, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Stops listening for speech. Speech captured so far will be recognized as
     * if the user had stopped speaking at this point. The function has no effect unless it
     * is called during the speech capturing.
     *
     * @param listener to receive callbacks, note that this must be non-null
     */
public void stopListening(android.speech.IRecognitionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_stopListening, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
/**
     * Cancels the speech recognition.
     *
     * @param listener to receive callbacks, note that this must be non-null
     */
public void cancel(android.speech.IRecognitionListener listener) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeStrongBinder((((listener!=null))?(listener.asBinder()):(null)));
mRemote.transact(Stub.TRANSACTION_cancel, _data, null, android.os.IBinder.FLAG_ONEWAY);
}
finally {
_data.recycle();
}
}
}
static final int TRANSACTION_startListening = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_stopListening = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_cancel = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
}
/**
     * Starts listening for speech. Please note that the recognition service supports
     * one listener only, therefore, if this function is called from two different threads,
     * only the latest one will get the notifications
     *
     * @param recognizerIntent the intent from which the invocation occurred. Additionally,
     *        this intent can contain extra parameters to manipulate the behavior of the recognition
     *        client. For more information see {@link RecognizerIntent}.
     * @param listener to receive callbacks, note that this must be non-null
     */
public void startListening(android.content.Intent recognizerIntent, android.speech.IRecognitionListener listener) throws android.os.RemoteException;
/**
     * Stops listening for speech. Speech captured so far will be recognized as
     * if the user had stopped speaking at this point. The function has no effect unless it
     * is called during the speech capturing.
     *
     * @param listener to receive callbacks, note that this must be non-null
     */
public void stopListening(android.speech.IRecognitionListener listener) throws android.os.RemoteException;
/**
     * Cancels the speech recognition.
     *
     * @param listener to receive callbacks, note that this must be non-null
     */
public void cancel(android.speech.IRecognitionListener listener) throws android.os.RemoteException;
}
