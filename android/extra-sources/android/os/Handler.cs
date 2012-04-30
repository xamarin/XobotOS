using Sharpen;
using System;
using XobotOS.Runtime;

namespace android.os
{
	/// <summary>
	/// A Handler allows you to send and process
	/// <see cref="Message">Message</see>
	/// and Runnable
	/// objects associated with a thread's
	/// <see cref="MessageQueue">MessageQueue</see>
	/// .  Each Handler
	/// instance is associated with a single thread and that thread's message
	/// queue.  When you create a new Handler, it is bound to the thread /
	/// message queue of the thread that is creating it -- from that point on,
	/// it will deliver messages and runnables to that message queue and execute
	/// them as they come out of the message queue.
	/// <p>There are two main uses for a Handler: (1) to schedule messages and
	/// runnables to be executed as some point in the future; and (2) to enqueue
	/// an action to be performed on a different thread than your own.
	/// <p>Scheduling messages is accomplished with the
	/// <see cref="post(java.lang.Runnable)">post(java.lang.Runnable)</see>
	/// ,
	/// <see cref="postAtTime(java.lang.Runnable, long)">postAtTime(java.lang.Runnable, long)
	/// 	</see>
	/// ,
	/// <see cref="postDelayed(java.lang.Runnable, long)">postDelayed(java.lang.Runnable, long)
	/// 	</see>
	/// ,
	/// <see cref="sendEmptyMessage(int)">sendEmptyMessage(int)</see>
	/// ,
	/// <see cref="sendMessage(Message)">sendMessage(Message)</see>
	/// ,
	/// <see cref="sendMessageAtTime(Message, long)">sendMessageAtTime(Message, long)</see>
	/// , and
	/// <see cref="sendMessageDelayed(Message, long)">sendMessageDelayed(Message, long)</see>
	/// methods.  The <em>post</em> versions allow
	/// you to enqueue Runnable objects to be called by the message queue when
	/// they are received; the <em>sendMessage</em> versions allow you to enqueue
	/// a
	/// <see cref="Message">Message</see>
	/// object containing a bundle of data that will be
	/// processed by the Handler's
	/// <see cref="handleMessage(Message)">handleMessage(Message)</see>
	/// method (requiring that
	/// you implement a subclass of Handler).
	/// <p>When posting or sending to a Handler, you can either
	/// allow the item to be processed as soon as the message queue is ready
	/// to do so, or specify a delay before it gets processed or absolute time for
	/// it to be processed.  The latter two allow you to implement timeouts,
	/// ticks, and other timing-based behavior.
	/// <p>When a
	/// process is created for your application, its main thread is dedicated to
	/// running a message queue that takes care of managing the top-level
	/// application objects (activities, broadcast receivers, etc) and any windows
	/// they create.  You can create your own threads, and communicate back with
	/// the main application thread through a Handler.  This is done by calling
	/// the same <em>post</em> or <em>sendMessage</em> methods as before, but from
	/// your new thread.  The given Runnable or Message will then be scheduled
	/// in the Handler's message queue and processed when appropriate.
	/// </summary>
	[Sharpen.Sharpened]
	public class Handler
	{
		private const bool FIND_POTENTIAL_LEAKS = false;
		private static readonly string TAG = "Handler";

		/// <summary>
		/// Callback interface you can use when instantiating a Handler to avoid
		/// having to implement your own subclass of Handler.
		/// </summary>
		/// <remarks>
		/// Callback interface you can use when instantiating a Handler to avoid
		/// having to implement your own subclass of Handler.
		/// </remarks>
		public interface Callback
		{
			bool handleMessage (Message msg);
		}

		/// <summary>Subclasses must implement this to receive messages.</summary>
		/// <remarks>Subclasses must implement this to receive messages.</remarks>
		public virtual void handleMessage (Message msg)
		{
		}

		/// <summary>Handle system messages here.</summary>
		/// <remarks>Handle system messages here.</remarks>
		public virtual void dispatchMessage (Message msg)
		{
			if (msg.callback != null) {
				handleCallback (msg);
			} else {
				if (mCallback != null) {
					if (mCallback.handleMessage (msg)) {
						return;
					}
				}
				handleMessage (msg);
			}
		}

		/// <summary>
		/// Default constructor associates this handler with the queue for the
		/// current thread.
		/// </summary>
		/// <remarks>
		/// Default constructor associates this handler with the queue for the
		/// current thread.
		/// If there isn't one, this handler won't be able to receive messages.
		/// </remarks>
		public Handler ()
		{
			mCallback = null;
		}

		/// <summary>
		/// Constructor associates this handler with the queue for the
		/// current thread and takes a callback interface in which you can handle
		/// messages.
		/// </summary>
		/// <remarks>
		/// Constructor associates this handler with the queue for the
		/// current thread and takes a callback interface in which you can handle
		/// messages.
		/// </remarks>
		public Handler (Handler.Callback callback)
		{
			mCallback = callback;
		}

		/// <summary>Use the provided queue instead of the default one.</summary>
		/// <remarks>Use the provided queue instead of the default one.</remarks>
		public Handler (Looper looper)
		{
			throw new NotSupportedException ();
		}

		/// <summary>
		/// Use the provided queue instead of the default one and take a callback
		/// interface in which to handle messages.
		/// </summary>
		/// <remarks>
		/// Use the provided queue instead of the default one and take a callback
		/// interface in which to handle messages.
		/// </remarks>
		public Handler (Looper looper, Handler.Callback callback)
		{
			throw new NotSupportedException ();
		}

		/// <summary>Returns a string representing the name of the specified message.</summary>
		/// <remarks>
		/// Returns a string representing the name of the specified message.
		/// The default implementation will either return the class name of the
		/// message callback if any, or the hexadecimal representation of the
		/// message "what" field.
		/// </remarks>
		/// <param name="message">The message whose name is being queried</param>
		public virtual string getMessageName (Message message)
		{
			if (message.callback != null) {
				return message.callback.GetType ().FullName;
			}
			return "0x" + Sharpen.Util.IntToHexString (message.what);
		}

		/// <summary>
		/// Returns a new
		/// <see cref="Message">Message</see>
		/// from the global message pool. More efficient than
		/// creating and allocating new instances. The retrieved message has its handler set to this instance (Message.target == this).
		/// If you don't want that facility, just call Message.obtain() instead.
		/// </summary>
		public Message obtainMessage ()
		{
			return Message.obtain (this);
		}

		/// <summary>
		/// Same as
		/// <see cref="obtainMessage()">obtainMessage()</see>
		/// , except that it also sets the what member of the returned Message.
		/// </summary>
		/// <param name="what">Value to assign to the returned Message.what field.</param>
		/// <returns>A Message from the global message pool.</returns>
		public Message obtainMessage (int what)
		{
			return Message.obtain (this, what);
		}

		/// <summary>
		/// Same as
		/// <see cref="obtainMessage()">obtainMessage()</see>
		/// , except that it also sets the what and obj members
		/// of the returned Message.
		/// </summary>
		/// <param name="what">Value to assign to the returned Message.what field.</param>
		/// <param name="obj">Value to assign to the returned Message.obj field.</param>
		/// <returns>A Message from the global message pool.</returns>
		public Message obtainMessage (int what, object obj)
		{
			return Message.obtain (this, what, obj);
		}

		/// <summary>
		/// Same as
		/// <see cref="obtainMessage()">obtainMessage()</see>
		/// , except that it also sets the what, arg1 and arg2 members of the returned
		/// Message.
		/// </summary>
		/// <param name="what">Value to assign to the returned Message.what field.</param>
		/// <param name="arg1">Value to assign to the returned Message.arg1 field.</param>
		/// <param name="arg2">Value to assign to the returned Message.arg2 field.</param>
		/// <returns>A Message from the global message pool.</returns>
		public Message obtainMessage (int what, int arg1, int arg2)
		{
			return Message.obtain (this, what, arg1, arg2);
		}

		/// <summary>
		/// Same as
		/// <see cref="obtainMessage()">obtainMessage()</see>
		/// , except that it also sets the what, obj, arg1,and arg2 values on the
		/// returned Message.
		/// </summary>
		/// <param name="what">Value to assign to the returned Message.what field.</param>
		/// <param name="arg1">Value to assign to the returned Message.arg1 field.</param>
		/// <param name="arg2">Value to assign to the returned Message.arg2 field.</param>
		/// <param name="obj">Value to assign to the returned Message.obj field.</param>
		/// <returns>A Message from the global message pool.</returns>
		public Message obtainMessage (int what, int arg1, int arg2, object obj)
		{
			return Message.obtain (this, what, arg1, arg2, obj);
		}

		/// <summary>Causes the Runnable r to be added to the message queue.</summary>
		/// <remarks>
		/// Causes the Runnable r to be added to the message queue.
		/// The runnable will be run on the thread to which this handler is
		/// attached.
		/// </remarks>
		/// <param name="r">The Runnable that will be executed.</param>
		/// <returns>
		/// Returns true if the Runnable was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public bool post (java.lang.Runnable r)
		{
			return sendMessageDelayed (getPostMessage (r), 0);
		}

		/// <summary>
		/// Causes the Runnable r to be added to the message queue, to be run
		/// at a specific time given by <var>uptimeMillis</var>.
		/// </summary>
		/// <remarks>
		/// Causes the Runnable r to be added to the message queue, to be run
		/// at a specific time given by <var>uptimeMillis</var>.
		/// <b>The time-base is
		/// <see cref="SystemClock.uptimeMillis()">SystemClock.uptimeMillis()</see>
		/// .</b>
		/// The runnable will be run on the thread to which this handler is attached.
		/// </remarks>
		/// <param name="r">The Runnable that will be executed.</param>
		/// <param name="uptimeMillis">
		/// The absolute time at which the callback should run,
		/// using the
		/// <see cref="SystemClock.uptimeMillis()">SystemClock.uptimeMillis()</see>
		/// time-base.
		/// </param>
		/// <returns>
		/// Returns true if the Runnable was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.  Note that a
		/// result of true does not mean the Runnable will be processed -- if
		/// the looper is quit before the delivery time of the message
		/// occurs then the message will be dropped.
		/// </returns>
		public bool postAtTime (java.lang.Runnable r, long uptimeMillis)
		{
			return sendMessageAtTime (getPostMessage (r), uptimeMillis);
		}

		/// <summary>
		/// Causes the Runnable r to be added to the message queue, to be run
		/// at a specific time given by <var>uptimeMillis</var>.
		/// </summary>
		/// <remarks>
		/// Causes the Runnable r to be added to the message queue, to be run
		/// at a specific time given by <var>uptimeMillis</var>.
		/// <b>The time-base is
		/// <see cref="SystemClock.uptimeMillis()">SystemClock.uptimeMillis()</see>
		/// .</b>
		/// The runnable will be run on the thread to which this handler is attached.
		/// </remarks>
		/// <param name="r">The Runnable that will be executed.</param>
		/// <param name="uptimeMillis">
		/// The absolute time at which the callback should run,
		/// using the
		/// <see cref="SystemClock.uptimeMillis()">SystemClock.uptimeMillis()</see>
		/// time-base.
		/// </param>
		/// <returns>
		/// Returns true if the Runnable was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.  Note that a
		/// result of true does not mean the Runnable will be processed -- if
		/// the looper is quit before the delivery time of the message
		/// occurs then the message will be dropped.
		/// </returns>
		/// <seealso cref="SystemClock.uptimeMillis()">SystemClock.uptimeMillis()</seealso>
		public bool postAtTime (java.lang.Runnable r, object token, long uptimeMillis)
		{
			return sendMessageAtTime (getPostMessage (r, token), uptimeMillis);
		}

		/// <summary>
		/// Causes the Runnable r to be added to the message queue, to be run
		/// after the specified amount of time elapses.
		/// </summary>
		/// <remarks>
		/// Causes the Runnable r to be added to the message queue, to be run
		/// after the specified amount of time elapses.
		/// The runnable will be run on the thread to which this handler
		/// is attached.
		/// </remarks>
		/// <param name="r">The Runnable that will be executed.</param>
		/// <param name="delayMillis">
		/// The delay (in milliseconds) until the Runnable
		/// will be executed.
		/// </param>
		/// <returns>
		/// Returns true if the Runnable was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.  Note that a
		/// result of true does not mean the Runnable will be processed --
		/// if the looper is quit before the delivery time of the message
		/// occurs then the message will be dropped.
		/// </returns>
		public bool postDelayed (java.lang.Runnable r, long delayMillis)
		{
			return sendMessageDelayed (getPostMessage (r), delayMillis);
		}

		/// <summary>Posts a message to an object that implements Runnable.</summary>
		/// <remarks>
		/// Posts a message to an object that implements Runnable.
		/// Causes the Runnable r to executed on the next iteration through the
		/// message queue. The runnable will be run on the thread to which this
		/// handler is attached.
		/// <b>This method is only for use in very special circumstances -- it
		/// can easily starve the message queue, cause ordering problems, or have
		/// other unexpected side-effects.</b>
		/// </remarks>
		/// <param name="r">The Runnable that will be executed.</param>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public bool postAtFrontOfQueue (java.lang.Runnable r)
		{
			return sendMessageAtFrontOfQueue (getPostMessage (r));
		}

		/// <summary>Remove any pending posts of Runnable r that are in the message queue.</summary>
		/// <remarks>Remove any pending posts of Runnable r that are in the message queue.</remarks>
		public void removeCallbacks (java.lang.Runnable r)
		{
			; // FIXME
		}

		/// <summary>
		/// Remove any pending posts of Runnable <var>r</var> with Object
		/// <var>token</var> that are in the message queue.
		/// </summary>
		/// <remarks>
		/// Remove any pending posts of Runnable <var>r</var> with Object
		/// <var>token</var> that are in the message queue.  If <var>token</var> is null,
		/// all callbacks will be removed.
		/// </remarks>
		public void removeCallbacks (java.lang.Runnable r, object token)
		{
			; // FIXME
		}

		/// <summary>
		/// Pushes a message onto the end of the message queue after all pending messages
		/// before the current time.
		/// </summary>
		/// <remarks>
		/// Pushes a message onto the end of the message queue after all pending messages
		/// before the current time. It will be received in
		/// <see cref="handleMessage(Message)">handleMessage(Message)</see>
		/// ,
		/// in the thread attached to this handler.
		/// </remarks>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public bool sendMessage (Message msg)
		{
			return sendMessageDelayed (msg, 0);
		}

		/// <summary>Sends a Message containing only the what value.</summary>
		/// <remarks>Sends a Message containing only the what value.</remarks>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public bool sendEmptyMessage (int what)
		{
			return sendEmptyMessageDelayed (what, 0);
		}

		/// <summary>
		/// Sends a Message containing only the what value, to be delivered
		/// after the specified amount of time elapses.
		/// </summary>
		/// <remarks>
		/// Sends a Message containing only the what value, to be delivered
		/// after the specified amount of time elapses.
		/// </remarks>
		/// <seealso cref="sendMessageDelayed(Message, long)"></seealso>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public bool sendEmptyMessageDelayed (int what, long delayMillis)
		{
			Message msg = Message.obtain ();
			msg.what = what;
			return sendMessageDelayed (msg, delayMillis);
		}

		/// <summary>
		/// Sends a Message containing only the what value, to be delivered
		/// at a specific time.
		/// </summary>
		/// <remarks>
		/// Sends a Message containing only the what value, to be delivered
		/// at a specific time.
		/// </remarks>
		/// <seealso cref="sendMessageAtTime(Message, long)">sendMessageAtTime(Message, long)
		/// 	</seealso>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public bool sendEmptyMessageAtTime (int what, long uptimeMillis)
		{
			Message msg = Message.obtain ();
			msg.what = what;
			return sendMessageAtTime (msg, uptimeMillis);
		}

		/// <summary>
		/// Enqueue a message into the message queue after all pending messages
		/// before (current time + delayMillis).
		/// </summary>
		/// <remarks>
		/// Enqueue a message into the message queue after all pending messages
		/// before (current time + delayMillis). You will receive it in
		/// <see cref="handleMessage(Message)">handleMessage(Message)</see>
		/// , in the thread attached to this handler.
		/// </remarks>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.  Note that a
		/// result of true does not mean the message will be processed -- if
		/// the looper is quit before the delivery time of the message
		/// occurs then the message will be dropped.
		/// </returns>
		public bool sendMessageDelayed (Message msg, long delayMillis)
		{
			if (delayMillis < 0) {
				delayMillis = 0;
			}
			return sendMessageAtTime (msg, SystemClock.uptimeMillis () + delayMillis);
		}

		/// <summary>
		/// Enqueue a message into the message queue after all pending messages
		/// before the absolute time (in milliseconds) <var>uptimeMillis</var>.
		/// </summary>
		/// <remarks>
		/// Enqueue a message into the message queue after all pending messages
		/// before the absolute time (in milliseconds) <var>uptimeMillis</var>.
		/// <b>The time-base is
		/// <see cref="SystemClock.uptimeMillis()">SystemClock.uptimeMillis()</see>
		/// .</b>
		/// You will receive it in
		/// <see cref="handleMessage(Message)">handleMessage(Message)</see>
		/// , in the thread attached
		/// to this handler.
		/// </remarks>
		/// <param name="uptimeMillis">
		/// The absolute time at which the message should be
		/// delivered, using the
		/// <see cref="SystemClock.uptimeMillis()">SystemClock.uptimeMillis()</see>
		/// time-base.
		/// </param>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.  Note that a
		/// result of true does not mean the message will be processed -- if
		/// the looper is quit before the delivery time of the message
		/// occurs then the message will be dropped.
		/// </returns>
		public virtual bool sendMessageAtTime (Message msg, long uptimeMillis)
		{
			XobotActivityManager.SendMessage (this, msg, uptimeMillis);
			return true;
		}

		/// <summary>
		/// Enqueue a message at the front of the message queue, to be processed on
		/// the next iteration of the message loop.
		/// </summary>
		/// <remarks>
		/// Enqueue a message at the front of the message queue, to be processed on
		/// the next iteration of the message loop.  You will receive it in
		/// <see cref="handleMessage(Message)">handleMessage(Message)</see>
		/// , in the thread attached to this handler.
		/// <b>This method is only for use in very special circumstances -- it
		/// can easily starve the message queue, cause ordering problems, or have
		/// other unexpected side-effects.</b>
		/// </remarks>
		/// <returns>
		/// Returns true if the message was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public bool sendMessageAtFrontOfQueue (Message msg)
		{
			throw new NotSupportedException ();
		}

		/// <summary>
		/// Remove any pending posts of messages with code 'what' that are in the
		/// message queue.
		/// </summary>
		/// <remarks>
		/// Remove any pending posts of messages with code 'what' that are in the
		/// message queue.
		/// </remarks>
		public void removeMessages (int what)
		{
			; // FIXME
		}

		/// <summary>
		/// Remove any pending posts of messages with code 'what' and whose obj is
		/// 'object' that are in the message queue.
		/// </summary>
		/// <remarks>
		/// Remove any pending posts of messages with code 'what' and whose obj is
		/// 'object' that are in the message queue.  If <var>token</var> is null,
		/// all messages will be removed.
		/// </remarks>
		public void removeMessages (int what, object @object)
		{
			; // FIXME
		}

		/// <summary>
		/// Remove any pending posts of callbacks and sent messages whose
		/// <var>obj</var> is <var>token</var>.
		/// </summary>
		/// <remarks>
		/// Remove any pending posts of callbacks and sent messages whose
		/// <var>obj</var> is <var>token</var>.  If <var>token</var> is null,
		/// all callbacks and messages will be removed.
		/// </remarks>
		public void removeCallbacksAndMessages (object token)
		{
			; // FIXME
		}

		/// <summary>
		/// Check if there are any pending posts of messages with code 'what' in
		/// the message queue.
		/// </summary>
		/// <remarks>
		/// Check if there are any pending posts of messages with code 'what' in
		/// the message queue.
		/// </remarks>
		public bool hasMessages (int what)
		{
			return false;
		}

		/// <summary>
		/// Check if there are any pending posts of messages with code 'what' and
		/// whose obj is 'object' in the message queue.
		/// </summary>
		/// <remarks>
		/// Check if there are any pending posts of messages with code 'what' and
		/// whose obj is 'object' in the message queue.
		/// </remarks>
		public bool hasMessages (int what, object @object)
		{
			return false;
		}

		// if we can get rid of this method, the handler need not remember its loop
		// we could instead export a getMessageQueue() method...
		public Looper getLooper ()
		{
			throw new NotSupportedException ();
		}

		public void dump (android.util.Printer pw, string prefix)
		{
			pw.println (prefix + this + " @ " + SystemClock.uptimeMillis ());
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString ()
		{
			return String.Format ("Handler ({0}) {{{0:x}}}", GetType().FullName, GetHashCode ());
		}

		private Message getPostMessage (java.lang.Runnable r)
		{
			Message m = Message.obtain ();
			m.callback = r;
			return m;
		}

		private Message getPostMessage (java.lang.Runnable r, object token)
		{
			Message m = Message.obtain ();
			m.obj = token;
			m.callback = r;
			return m;
		}

		private void handleCallback (Message message)
		{
			message.callback.run ();
		}

		protected readonly Handler.Callback mCallback;
	}
}
