using Sharpen;

namespace android.view
{
	/// <summary>Handles input messages that arrive on an input channel.</summary>
	/// <remarks>Handles input messages that arrive on an input channel.</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface InputHandler
	{
		/// <summary>Handle a key event.</summary>
		/// <remarks>
		/// Handle a key event.
		/// It is the responsibility of the callee to ensure that the finished callback is
		/// eventually invoked when the event processing is finished and the input system
		/// can send the next event.
		/// </remarks>
		/// <param name="event">The key event data.</param>
		/// <param name="finishedCallback">The callback to invoke when event processing is finished.
		/// 	</param>
		void handleKey(android.view.KeyEvent @event, android.view.InputQueue.FinishedCallback
			 finishedCallback);

		/// <summary>Handle a motion event.</summary>
		/// <remarks>
		/// Handle a motion event.
		/// It is the responsibility of the callee to ensure that the finished callback is
		/// eventually invoked when the event processing is finished and the input system
		/// can send the next event.
		/// </remarks>
		/// <param name="event">The motion event data.</param>
		/// <param name="finishedCallback">The callback to invoke when event processing is finished.
		/// 	</param>
		void handleMotion(android.view.MotionEvent @event, android.view.InputQueue.FinishedCallback
			 finishedCallback);
	}
}
