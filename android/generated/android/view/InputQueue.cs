using Sharpen;

namespace android.view
{
	/// <summary>
	/// An input queue provides a mechanism for an application to receive incoming
	/// input events.
	/// </summary>
	/// <remarks>
	/// An input queue provides a mechanism for an application to receive incoming
	/// input events.  Currently only usable from native code.
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed class InputQueue
	{
		internal const string TAG = "InputQueue";

		internal const bool DEBUG = false;

		/// <summary>
		/// Interface to receive notification of when an InputQueue is associated
		/// and dissociated with a thread.
		/// </summary>
		/// <remarks>
		/// Interface to receive notification of when an InputQueue is associated
		/// and dissociated with a thread.
		/// </remarks>
		public interface Callback
		{
			/// <summary>
			/// Called when the given InputQueue is now associated with the
			/// thread making this call, so it can start receiving events from it.
			/// </summary>
			/// <remarks>
			/// Called when the given InputQueue is now associated with the
			/// thread making this call, so it can start receiving events from it.
			/// </remarks>
			void onInputQueueCreated(android.view.InputQueue queue);

			/// <summary>
			/// Called when the given InputQueue is no longer associated with
			/// the thread and thus not dispatching events.
			/// </summary>
			/// <remarks>
			/// Called when the given InputQueue is no longer associated with
			/// the thread and thus not dispatching events.
			/// </remarks>
			void onInputQueueDestroyed(android.view.InputQueue queue);
		}

		internal readonly android.view.InputChannel mChannel;

		private static readonly object sLock = new object();

		[Sharpen.NativeStub]
		private static void nativeRegisterInputChannel(android.view.InputChannel inputChannel
			, android.view.InputHandler inputHandler, android.os.MessageQueue messageQueue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static void nativeUnregisterInputChannel(android.view.InputChannel inputChannel
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static void nativeFinished(long finishedToken, bool handled)
		{
			throw new System.NotImplementedException();
		}

		/// <hide></hide>
		public InputQueue(android.view.InputChannel channel)
		{
			mChannel = channel;
		}

		/// <hide></hide>
		public android.view.InputChannel getInputChannel()
		{
			return mChannel;
		}

		/// <summary>Registers an input channel and handler.</summary>
		/// <remarks>Registers an input channel and handler.</remarks>
		/// <param name="inputChannel">The input channel to register.</param>
		/// <param name="inputHandler">The input handler to input events send to the target.</param>
		/// <param name="messageQueue">The message queue on whose thread the handler should be invoked.
		/// 	</param>
		/// <hide></hide>
		public static void registerInputChannel(android.view.InputChannel inputChannel, android.view.InputHandler
			 inputHandler, android.os.MessageQueue messageQueue)
		{
			if (inputChannel == null)
			{
				throw new System.ArgumentException("inputChannel must not be null");
			}
			if (inputHandler == null)
			{
				throw new System.ArgumentException("inputHandler must not be null");
			}
			if (messageQueue == null)
			{
				throw new System.ArgumentException("messageQueue must not be null");
			}
			lock (sLock)
			{
				nativeRegisterInputChannel(inputChannel, inputHandler, messageQueue);
			}
		}

		/// <summary>Unregisters an input channel.</summary>
		/// <remarks>
		/// Unregisters an input channel.
		/// Does nothing if the channel is not currently registered.
		/// </remarks>
		/// <param name="inputChannel">The input channel to unregister.</param>
		/// <hide></hide>
		public static void unregisterInputChannel(android.view.InputChannel inputChannel)
		{
			if (inputChannel == null)
			{
				throw new System.ArgumentException("inputChannel must not be null");
			}
			lock (sLock)
			{
				nativeUnregisterInputChannel(inputChannel);
			}
		}

		private static void dispatchKeyEvent(android.view.InputHandler inputHandler, android.view.KeyEvent
			 @event, long finishedToken)
		{
			android.view.InputQueue.FinishedCallback finishedCallback = android.view.InputQueue
				.FinishedCallback.obtain(finishedToken);
			inputHandler.handleKey(@event, finishedCallback);
		}

		private static void dispatchMotionEvent(android.view.InputHandler inputHandler, android.view.MotionEvent
			 @event, long finishedToken)
		{
			android.view.InputQueue.FinishedCallback finishedCallback = android.view.InputQueue
				.FinishedCallback.obtain(finishedToken);
			inputHandler.handleMotion(@event, finishedCallback);
		}

		/// <summary>A callback that must be invoked to when finished processing an event.</summary>
		/// <remarks>A callback that must be invoked to when finished processing an event.</remarks>
		/// <hide></hide>
		public sealed class FinishedCallback
		{
			internal const bool DEBUG_RECYCLING = false;

			internal const int RECYCLE_MAX_COUNT = 4;

			private static android.view.InputQueue.FinishedCallback sRecycleHead;

			private static int sRecycleCount;

			private android.view.InputQueue.FinishedCallback mRecycleNext;

			private long mFinishedToken;

			private FinishedCallback()
			{
			}

			public static android.view.InputQueue.FinishedCallback obtain(long finishedToken)
			{
				lock (sLock)
				{
					android.view.InputQueue.FinishedCallback callback = sRecycleHead;
					if (callback != null)
					{
						sRecycleHead = callback.mRecycleNext;
						sRecycleCount -= 1;
						callback.mRecycleNext = null;
					}
					else
					{
						callback = new android.view.InputQueue.FinishedCallback();
					}
					callback.mFinishedToken = finishedToken;
					return callback;
				}
			}

			public void finished(bool handled)
			{
				lock (sLock)
				{
					if (mFinishedToken == -1)
					{
						throw new System.InvalidOperationException("Event finished callback already invoked."
							);
					}
					nativeFinished(mFinishedToken, handled);
					mFinishedToken = -1;
					if (sRecycleCount < RECYCLE_MAX_COUNT)
					{
						mRecycleNext = sRecycleHead;
						sRecycleHead = this;
						sRecycleCount += 1;
					}
				}
			}
		}
	}
}
