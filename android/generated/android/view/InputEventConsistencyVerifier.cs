using Sharpen;

namespace android.view
{
	/// <summary>Checks whether a sequence of input events is self-consistent.</summary>
	/// <remarks>
	/// Checks whether a sequence of input events is self-consistent.
	/// Logs a description of each problem detected.
	/// <p>
	/// When a problem is detected, the event is tainted.  This mechanism prevents the same
	/// error from being reported multiple times.
	/// </p>
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public sealed class InputEventConsistencyVerifier
	{
		private static readonly bool IS_ENG_BUILD = "eng".Equals(android.os.Build.TYPE);

		internal const string EVENT_TYPE_KEY = "KeyEvent";

		internal const string EVENT_TYPE_TRACKBALL = "TrackballEvent";

		internal const string EVENT_TYPE_TOUCH = "TouchEvent";

		internal const string EVENT_TYPE_GENERIC_MOTION = "GenericMotionEvent";

		internal const int RECENT_EVENTS_TO_LOG = 5;

		private readonly object mCaller;

		private readonly int mFlags;

		private readonly string mLogTag;

		private android.view.InputEvent mLastEvent;

		private string mLastEventType;

		private int mLastNestingLevel;

		private android.view.InputEvent[] mRecentEvents;

		private bool[] mRecentEventsUnhandled;

		private int mMostRecentEventIndex;

		private android.view.InputEvent mCurrentEvent;

		private string mCurrentEventType;

		private android.view.InputEventConsistencyVerifier.KeyState mKeyStateList;

		private bool mTrackballDown;

		private bool mTrackballUnhandled;

		private int mTouchEventStreamPointers;

		private int mTouchEventStreamDeviceId = -1;

		private int mTouchEventStreamSource;

		private bool mTouchEventStreamIsTainted;

		private bool mTouchEventStreamUnhandled;

		private bool mHoverEntered;

		private java.lang.StringBuilder mViolationMessage;

		/// <summary>Indicates that the verifier is intended to act on raw device input event streams.
		/// 	</summary>
		/// <remarks>
		/// Indicates that the verifier is intended to act on raw device input event streams.
		/// Disables certain checks for invariants that are established by the input dispatcher
		/// itself as it delivers input events, such as key repeating behavior.
		/// </remarks>
		public const int FLAG_RAW_DEVICE_INPUT = 1 << 0;

		/// <summary>Creates an input consistency verifier.</summary>
		/// <remarks>Creates an input consistency verifier.</remarks>
		/// <param name="caller">The object to which the verifier is attached.</param>
		/// <param name="flags">Flags to the verifier, or 0 if none.</param>
		public InputEventConsistencyVerifier(object caller, int flags) : this(caller, flags
			, typeof(android.view.InputEventConsistencyVerifier).Name)
		{
		}

		/// <summary>Creates an input consistency verifier.</summary>
		/// <remarks>Creates an input consistency verifier.</remarks>
		/// <param name="caller">The object to which the verifier is attached.</param>
		/// <param name="flags">Flags to the verifier, or 0 if none.</param>
		/// <param name="logTag">Tag for logging. If null defaults to the short class name.</param>
		public InputEventConsistencyVerifier(object caller, int flags, string logTag)
		{
			// The number of recent events to log when a problem is detected.
			// Can be set to 0 to disable logging recent events but the runtime overhead of
			// this feature is negligible on current hardware.
			// The object to which the verifier is attached.
			// Consistency verifier flags.
			// Tag for logging which a client can set to help distinguish the output
			// from different verifiers since several can be active at the same time.
			// If not provided defaults to the simple class name.
			// The most recently checked event and the nesting level at which it was checked.
			// This is only set when the verifier is called from a nesting level greater than 0
			// so that the verifier can detect when it has been asked to verify the same event twice.
			// It does not make sense to examine the contents of the last event since it may have
			// been recycled.
			// Copy of the most recent events.
			// Current event and its type.
			// Linked list of key state objects.
			// Current state of the trackball.
			// Bitfield of pointer ids that are currently down.
			// Assumes that the largest possible pointer id is 31, which is potentially subject to change.
			// (See MAX_POINTER_ID in frameworks/base/include/ui/Input.h)
			// The device id and source of the current stream of touch events.
			// Set to true when we discover that the touch event stream is inconsistent.
			// Reset on down or cancel.
			// Set to true if the touch event stream is partially unhandled.
			// Set to true if we received hover enter.
			// The current violation message.
			this.mCaller = caller;
			this.mFlags = flags;
			this.mLogTag = (logTag != null) ? logTag : "InputEventConsistencyVerifier";
		}

		/// <summary>Determines whether the instrumentation should be enabled.</summary>
		/// <remarks>Determines whether the instrumentation should be enabled.</remarks>
		/// <returns>True if it should be enabled.</returns>
		public static bool isInstrumentationEnabled()
		{
			return IS_ENG_BUILD;
		}

		/// <summary>Resets the state of the input event consistency verifier.</summary>
		/// <remarks>Resets the state of the input event consistency verifier.</remarks>
		public void reset()
		{
			mLastEvent = null;
			mLastNestingLevel = 0;
			mTrackballDown = false;
			mTrackballUnhandled = false;
			mTouchEventStreamPointers = 0;
			mTouchEventStreamIsTainted = false;
			mTouchEventStreamUnhandled = false;
			mHoverEntered = false;
			while (mKeyStateList != null)
			{
				android.view.InputEventConsistencyVerifier.KeyState state = mKeyStateList;
				mKeyStateList = state.next;
				state.recycle();
			}
		}

		/// <summary>Checks an arbitrary input event.</summary>
		/// <remarks>Checks an arbitrary input event.</remarks>
		/// <param name="event">The event.</param>
		/// <param name="nestingLevel">
		/// The nesting level: 0 if called from the base class,
		/// or 1 from a subclass.  If the event was already checked by this consistency verifier
		/// at a higher nesting level, it will not be checked again.  Used to handle the situation
		/// where a subclass dispatching method delegates to its superclass's dispatching method
		/// and both dispatching methods call into the consistency verifier.
		/// </param>
		public void onInputEvent(android.view.InputEvent @event, int nestingLevel)
		{
			if (@event is android.view.KeyEvent)
			{
				android.view.KeyEvent keyEvent = (android.view.KeyEvent)@event;
				onKeyEvent(keyEvent, nestingLevel);
			}
			else
			{
				android.view.MotionEvent motionEvent = (android.view.MotionEvent)@event;
				if (motionEvent.isTouchEvent())
				{
					onTouchEvent(motionEvent, nestingLevel);
				}
				else
				{
					if ((motionEvent.getSource() & android.view.InputDevice.SOURCE_CLASS_TRACKBALL) !=
						 0)
					{
						onTrackballEvent(motionEvent, nestingLevel);
					}
					else
					{
						onGenericMotionEvent(motionEvent, nestingLevel);
					}
				}
			}
		}

		/// <summary>Checks a key event.</summary>
		/// <remarks>Checks a key event.</remarks>
		/// <param name="event">The event.</param>
		/// <param name="nestingLevel">
		/// The nesting level: 0 if called from the base class,
		/// or 1 from a subclass.  If the event was already checked by this consistency verifier
		/// at a higher nesting level, it will not be checked again.  Used to handle the situation
		/// where a subclass dispatching method delegates to its superclass's dispatching method
		/// and both dispatching methods call into the consistency verifier.
		/// </param>
		public void onKeyEvent(android.view.KeyEvent @event, int nestingLevel)
		{
			if (!startEvent(@event, nestingLevel, EVENT_TYPE_KEY))
			{
				return;
			}
			try
			{
				ensureMetaStateIsNormalized(@event.getMetaState());
				int action = @event.getAction();
				int deviceId = @event.getDeviceId();
				int source = @event.getSource();
				int keyCode = @event.getKeyCode();
				switch (action)
				{
					case android.view.KeyEvent.ACTION_DOWN:
					{
						android.view.InputEventConsistencyVerifier.KeyState state = findKeyState(deviceId
							, source, keyCode, false);
						if (state != null)
						{
							// If the key is already down, ensure it is a repeat.
							// We don't perform this check when processing raw device input
							// because the input dispatcher itself is responsible for setting
							// the key repeat count before it delivers input events.
							if (state.unhandled)
							{
								state.unhandled = false;
							}
							else
							{
								if ((mFlags & FLAG_RAW_DEVICE_INPUT) == 0 && @event.getRepeatCount() == 0)
								{
									problem("ACTION_DOWN but key is already down and this event " + "is not a key repeat."
										);
								}
							}
						}
						else
						{
							addKeyState(deviceId, source, keyCode);
						}
						break;
					}

					case android.view.KeyEvent.ACTION_UP:
					{
						android.view.InputEventConsistencyVerifier.KeyState state = findKeyState(deviceId
							, source, keyCode, true);
						if (state == null)
						{
							problem("ACTION_UP but key was not down.");
						}
						else
						{
							state.recycle();
						}
						break;
					}

					case android.view.KeyEvent.ACTION_MULTIPLE:
					{
						break;
					}

					default:
					{
						problem("Invalid action " + android.view.KeyEvent.actionToString(action) + " for key event."
							);
						break;
					}
				}
			}
			finally
			{
				finishEvent();
			}
		}

		/// <summary>Checks a trackball event.</summary>
		/// <remarks>Checks a trackball event.</remarks>
		/// <param name="event">The event.</param>
		/// <param name="nestingLevel">
		/// The nesting level: 0 if called from the base class,
		/// or 1 from a subclass.  If the event was already checked by this consistency verifier
		/// at a higher nesting level, it will not be checked again.  Used to handle the situation
		/// where a subclass dispatching method delegates to its superclass's dispatching method
		/// and both dispatching methods call into the consistency verifier.
		/// </param>
		public void onTrackballEvent(android.view.MotionEvent @event, int nestingLevel)
		{
			if (!startEvent(@event, nestingLevel, EVENT_TYPE_TRACKBALL))
			{
				return;
			}
			try
			{
				ensureMetaStateIsNormalized(@event.getMetaState());
				int action = @event.getAction();
				int source = @event.getSource();
				if ((source & android.view.InputDevice.SOURCE_CLASS_TRACKBALL) != 0)
				{
					switch (action)
					{
						case android.view.MotionEvent.ACTION_DOWN:
						{
							if (mTrackballDown && !mTrackballUnhandled)
							{
								problem("ACTION_DOWN but trackball is already down.");
							}
							else
							{
								mTrackballDown = true;
								mTrackballUnhandled = false;
							}
							ensureHistorySizeIsZeroForThisAction(@event);
							ensurePointerCountIsOneForThisAction(@event);
							break;
						}

						case android.view.MotionEvent.ACTION_UP:
						{
							if (!mTrackballDown)
							{
								problem("ACTION_UP but trackball is not down.");
							}
							else
							{
								mTrackballDown = false;
								mTrackballUnhandled = false;
							}
							ensureHistorySizeIsZeroForThisAction(@event);
							ensurePointerCountIsOneForThisAction(@event);
							break;
						}

						case android.view.MotionEvent.ACTION_MOVE:
						{
							ensurePointerCountIsOneForThisAction(@event);
							break;
						}

						default:
						{
							problem("Invalid action " + android.view.MotionEvent.actionToString(action) + " for trackball event."
								);
							break;
						}
					}
					if (mTrackballDown && @event.getPressure() <= 0)
					{
						problem("Trackball is down but pressure is not greater than 0.");
					}
					else
					{
						if (!mTrackballDown && @event.getPressure() != 0)
						{
							problem("Trackball is up but pressure is not equal to 0.");
						}
					}
				}
				else
				{
					problem("Source was not SOURCE_CLASS_TRACKBALL.");
				}
			}
			finally
			{
				finishEvent();
			}
		}

		/// <summary>Checks a touch event.</summary>
		/// <remarks>Checks a touch event.</remarks>
		/// <param name="event">The event.</param>
		/// <param name="nestingLevel">
		/// The nesting level: 0 if called from the base class,
		/// or 1 from a subclass.  If the event was already checked by this consistency verifier
		/// at a higher nesting level, it will not be checked again.  Used to handle the situation
		/// where a subclass dispatching method delegates to its superclass's dispatching method
		/// and both dispatching methods call into the consistency verifier.
		/// </param>
		public void onTouchEvent(android.view.MotionEvent @event, int nestingLevel)
		{
			if (!startEvent(@event, nestingLevel, EVENT_TYPE_TOUCH))
			{
				return;
			}
			int action = @event.getAction();
			bool newStream = action == android.view.MotionEvent.ACTION_DOWN || action == android.view.MotionEvent
				.ACTION_CANCEL;
			if (newStream && (mTouchEventStreamIsTainted || mTouchEventStreamUnhandled))
			{
				mTouchEventStreamIsTainted = false;
				mTouchEventStreamUnhandled = false;
				mTouchEventStreamPointers = 0;
			}
			if (mTouchEventStreamIsTainted)
			{
				@event.setTainted(true);
			}
			try
			{
				ensureMetaStateIsNormalized(@event.getMetaState());
				int deviceId = @event.getDeviceId();
				int source = @event.getSource();
				if (!newStream && mTouchEventStreamDeviceId != -1 && (mTouchEventStreamDeviceId !=
					 deviceId || mTouchEventStreamSource != source))
				{
					problem("Touch event stream contains events from multiple sources: " + "previous device id "
						 + mTouchEventStreamDeviceId + ", previous source " + Sharpen.Util.IntToHexString
						(mTouchEventStreamSource) + ", new device id " + deviceId + ", new source " + Sharpen.Util.IntToHexString
						(source));
				}
				mTouchEventStreamDeviceId = deviceId;
				mTouchEventStreamSource = source;
				int pointerCount = @event.getPointerCount();
				if ((source & android.view.InputDevice.SOURCE_CLASS_POINTER) != 0)
				{
					switch (action)
					{
						case android.view.MotionEvent.ACTION_DOWN:
						{
							if (mTouchEventStreamPointers != 0)
							{
								problem("ACTION_DOWN but pointers are already down.  " + "Probably missing ACTION_UP from previous gesture."
									);
							}
							ensureHistorySizeIsZeroForThisAction(@event);
							ensurePointerCountIsOneForThisAction(@event);
							mTouchEventStreamPointers = 1 << @event.getPointerId(0);
							break;
						}

						case android.view.MotionEvent.ACTION_UP:
						{
							ensureHistorySizeIsZeroForThisAction(@event);
							ensurePointerCountIsOneForThisAction(@event);
							mTouchEventStreamPointers = 0;
							mTouchEventStreamIsTainted = false;
							break;
						}

						case android.view.MotionEvent.ACTION_MOVE:
						{
							int expectedPointerCount = Sharpen.Util.IntGetBitCount(mTouchEventStreamPointers);
							if (pointerCount != expectedPointerCount)
							{
								problem("ACTION_MOVE contained " + pointerCount + " pointers but there are currently "
									 + expectedPointerCount + " pointers down.");
								mTouchEventStreamIsTainted = true;
							}
							break;
						}

						case android.view.MotionEvent.ACTION_CANCEL:
						{
							mTouchEventStreamPointers = 0;
							mTouchEventStreamIsTainted = false;
							break;
						}

						case android.view.MotionEvent.ACTION_OUTSIDE:
						{
							if (mTouchEventStreamPointers != 0)
							{
								problem("ACTION_OUTSIDE but pointers are still down.");
							}
							ensureHistorySizeIsZeroForThisAction(@event);
							ensurePointerCountIsOneForThisAction(@event);
							mTouchEventStreamIsTainted = false;
							break;
						}

						default:
						{
							int actionMasked = @event.getActionMasked();
							int actionIndex = @event.getActionIndex();
							if (actionMasked == android.view.MotionEvent.ACTION_POINTER_DOWN)
							{
								if (mTouchEventStreamPointers == 0)
								{
									problem("ACTION_POINTER_DOWN but no other pointers were down.");
									mTouchEventStreamIsTainted = true;
								}
								if (actionIndex < 0 || actionIndex >= pointerCount)
								{
									problem("ACTION_POINTER_DOWN index is " + actionIndex + " but the pointer count is "
										 + pointerCount + ".");
									mTouchEventStreamIsTainted = true;
								}
								else
								{
									int id = @event.getPointerId(actionIndex);
									int idBit = 1 << id;
									if ((mTouchEventStreamPointers & idBit) != 0)
									{
										problem("ACTION_POINTER_DOWN specified pointer id " + id + " which is already down."
											);
										mTouchEventStreamIsTainted = true;
									}
									else
									{
										mTouchEventStreamPointers |= idBit;
									}
								}
								ensureHistorySizeIsZeroForThisAction(@event);
							}
							else
							{
								if (actionMasked == android.view.MotionEvent.ACTION_POINTER_UP)
								{
									if (actionIndex < 0 || actionIndex >= pointerCount)
									{
										problem("ACTION_POINTER_UP index is " + actionIndex + " but the pointer count is "
											 + pointerCount + ".");
										mTouchEventStreamIsTainted = true;
									}
									else
									{
										int id = @event.getPointerId(actionIndex);
										int idBit = 1 << id;
										if ((mTouchEventStreamPointers & idBit) == 0)
										{
											problem("ACTION_POINTER_UP specified pointer id " + id + " which is not currently down."
												);
											mTouchEventStreamIsTainted = true;
										}
										else
										{
											mTouchEventStreamPointers &= ~idBit;
										}
									}
									ensureHistorySizeIsZeroForThisAction(@event);
								}
								else
								{
									problem("Invalid action " + android.view.MotionEvent.actionToString(action) + " for touch event."
										);
								}
							}
							break;
						}
					}
				}
				else
				{
					problem("Source was not SOURCE_CLASS_POINTER.");
				}
			}
			finally
			{
				finishEvent();
			}
		}

		/// <summary>Checks a generic motion event.</summary>
		/// <remarks>Checks a generic motion event.</remarks>
		/// <param name="event">The event.</param>
		/// <param name="nestingLevel">
		/// The nesting level: 0 if called from the base class,
		/// or 1 from a subclass.  If the event was already checked by this consistency verifier
		/// at a higher nesting level, it will not be checked again.  Used to handle the situation
		/// where a subclass dispatching method delegates to its superclass's dispatching method
		/// and both dispatching methods call into the consistency verifier.
		/// </param>
		public void onGenericMotionEvent(android.view.MotionEvent @event, int nestingLevel
			)
		{
			if (!startEvent(@event, nestingLevel, EVENT_TYPE_GENERIC_MOTION))
			{
				return;
			}
			try
			{
				ensureMetaStateIsNormalized(@event.getMetaState());
				int action = @event.getAction();
				int source = @event.getSource();
				if ((source & android.view.InputDevice.SOURCE_CLASS_POINTER) != 0)
				{
					switch (action)
					{
						case android.view.MotionEvent.ACTION_HOVER_ENTER:
						{
							ensurePointerCountIsOneForThisAction(@event);
							mHoverEntered = true;
							break;
						}

						case android.view.MotionEvent.ACTION_HOVER_MOVE:
						{
							ensurePointerCountIsOneForThisAction(@event);
							break;
						}

						case android.view.MotionEvent.ACTION_HOVER_EXIT:
						{
							ensurePointerCountIsOneForThisAction(@event);
							if (!mHoverEntered)
							{
								problem("ACTION_HOVER_EXIT without prior ACTION_HOVER_ENTER");
							}
							mHoverEntered = false;
							break;
						}

						case android.view.MotionEvent.ACTION_SCROLL:
						{
							ensureHistorySizeIsZeroForThisAction(@event);
							ensurePointerCountIsOneForThisAction(@event);
							break;
						}

						default:
						{
							problem("Invalid action for generic pointer event.");
							break;
						}
					}
				}
				else
				{
					if ((source & android.view.InputDevice.SOURCE_CLASS_JOYSTICK) != 0)
					{
						switch (action)
						{
							case android.view.MotionEvent.ACTION_MOVE:
							{
								ensurePointerCountIsOneForThisAction(@event);
								break;
							}

							default:
							{
								problem("Invalid action for generic joystick event.");
								break;
							}
						}
					}
				}
			}
			finally
			{
				finishEvent();
			}
		}

		/// <summary>
		/// Notifies the verifier that a given event was unhandled and the rest of the
		/// trace for the event should be ignored.
		/// </summary>
		/// <remarks>
		/// Notifies the verifier that a given event was unhandled and the rest of the
		/// trace for the event should be ignored.
		/// This method should only be called if the event was previously checked by
		/// the consistency verifier using
		/// <see cref="onInputEvent(InputEvent, int)">onInputEvent(InputEvent, int)</see>
		/// and other methods.
		/// </remarks>
		/// <param name="event">The event.</param>
		/// <param name="nestingLevel">
		/// The nesting level: 0 if called from the base class,
		/// or 1 from a subclass.  If the event was already checked by this consistency verifier
		/// at a higher nesting level, it will not be checked again.  Used to handle the situation
		/// where a subclass dispatching method delegates to its superclass's dispatching method
		/// and both dispatching methods call into the consistency verifier.
		/// </param>
		public void onUnhandledEvent(android.view.InputEvent @event, int nestingLevel)
		{
			if (nestingLevel != mLastNestingLevel)
			{
				return;
			}
			if (mRecentEventsUnhandled != null)
			{
				mRecentEventsUnhandled[mMostRecentEventIndex] = true;
			}
			if (@event is android.view.KeyEvent)
			{
				android.view.KeyEvent keyEvent = (android.view.KeyEvent)@event;
				int deviceId = keyEvent.getDeviceId();
				int source = keyEvent.getSource();
				int keyCode = keyEvent.getKeyCode();
				android.view.InputEventConsistencyVerifier.KeyState state = findKeyState(deviceId
					, source, keyCode, false);
				if (state != null)
				{
					state.unhandled = true;
				}
			}
			else
			{
				android.view.MotionEvent motionEvent = (android.view.MotionEvent)@event;
				if (motionEvent.isTouchEvent())
				{
					mTouchEventStreamUnhandled = true;
				}
				else
				{
					if ((motionEvent.getSource() & android.view.InputDevice.SOURCE_CLASS_TRACKBALL) !=
						 0)
					{
						if (mTrackballDown)
						{
							mTrackballUnhandled = true;
						}
					}
				}
			}
		}

		private void ensureMetaStateIsNormalized(int metaState)
		{
			int normalizedMetaState = android.view.KeyEvent.normalizeMetaState(metaState);
			if (normalizedMetaState != metaState)
			{
				problem(string.Format("Metastate not normalized.  Was 0x%08x but expected 0x%08x."
					, metaState, normalizedMetaState));
			}
		}

		private void ensurePointerCountIsOneForThisAction(android.view.MotionEvent @event
			)
		{
			int pointerCount = @event.getPointerCount();
			if (pointerCount != 1)
			{
				problem("Pointer count is " + pointerCount + " but it should always be 1 for " + 
					android.view.MotionEvent.actionToString(@event.getAction()));
			}
		}

		private void ensureHistorySizeIsZeroForThisAction(android.view.MotionEvent @event
			)
		{
			int historySize = @event.getHistorySize();
			if (historySize != 0)
			{
				problem("History size is " + historySize + " but it should always be 0 for " + android.view.MotionEvent
					.actionToString(@event.getAction()));
			}
		}

		private bool startEvent(android.view.InputEvent @event, int nestingLevel, string 
			eventType)
		{
			// Ignore the event if we already checked it at a higher nesting level.
			if (@event == mLastEvent && nestingLevel < mLastNestingLevel && eventType == mLastEventType)
			{
				return false;
			}
			if (nestingLevel > 0)
			{
				mLastEvent = @event;
				mLastEventType = eventType;
				mLastNestingLevel = nestingLevel;
			}
			else
			{
				mLastEvent = null;
				mLastEventType = null;
				mLastNestingLevel = 0;
			}
			mCurrentEvent = @event;
			mCurrentEventType = eventType;
			return true;
		}

		private void finishEvent()
		{
			if (mViolationMessage != null && mViolationMessage.Length != 0)
			{
				if (!mCurrentEvent.isTainted())
				{
					// Write a log message only if the event was not already tainted.
					mViolationMessage.append("\n  in ").append(mCaller);
					mViolationMessage.append("\n  ");
					appendEvent(mViolationMessage, 0, mCurrentEvent, false);
					if (RECENT_EVENTS_TO_LOG != 0 && mRecentEvents != null)
					{
						mViolationMessage.append("\n  -- recent events --");
						{
							for (int i = 0; i < RECENT_EVENTS_TO_LOG; i++)
							{
								int index = (mMostRecentEventIndex + RECENT_EVENTS_TO_LOG - i) % RECENT_EVENTS_TO_LOG;
								android.view.InputEvent @event = mRecentEvents[index];
								if (@event == null)
								{
									break;
								}
								mViolationMessage.append("\n  ");
								appendEvent(mViolationMessage, i + 1, @event, mRecentEventsUnhandled[index]);
							}
						}
					}
					android.util.Log.d(mLogTag, mViolationMessage.ToString());
					// Taint the event so that we do not generate additional violations from it
					// further downstream.
					mCurrentEvent.setTainted(true);
				}
				mViolationMessage.setLength(0);
			}
			if (RECENT_EVENTS_TO_LOG != 0)
			{
				if (mRecentEvents == null)
				{
					mRecentEvents = new android.view.InputEvent[RECENT_EVENTS_TO_LOG];
					mRecentEventsUnhandled = new bool[RECENT_EVENTS_TO_LOG];
				}
				int index = (mMostRecentEventIndex + 1) % RECENT_EVENTS_TO_LOG;
				mMostRecentEventIndex = index;
				if (mRecentEvents[index] != null)
				{
					mRecentEvents[index].recycle();
				}
				mRecentEvents[index] = mCurrentEvent.copy();
				mRecentEventsUnhandled[index] = false;
			}
			mCurrentEvent = null;
			mCurrentEventType = null;
		}

		private static void appendEvent(java.lang.StringBuilder message, int index, android.view.InputEvent
			 @event, bool unhandled)
		{
			message.append(index).append(": sent at ").append(@event.getEventTimeNano());
			message.append(", ");
			if (unhandled)
			{
				message.append("(unhandled) ");
			}
			message.append(@event);
		}

		private void problem(string message)
		{
			if (mViolationMessage == null)
			{
				mViolationMessage = new java.lang.StringBuilder();
			}
			if (mViolationMessage.Length == 0)
			{
				mViolationMessage.append(mCurrentEventType).append(": ");
			}
			else
			{
				mViolationMessage.append("\n  ");
			}
			mViolationMessage.append(message);
		}

		private android.view.InputEventConsistencyVerifier.KeyState findKeyState(int deviceId
			, int source, int keyCode, bool remove)
		{
			android.view.InputEventConsistencyVerifier.KeyState last = null;
			android.view.InputEventConsistencyVerifier.KeyState state = mKeyStateList;
			while (state != null)
			{
				if (state.deviceId == deviceId && state.source == source && state.keyCode == keyCode)
				{
					if (remove)
					{
						if (last != null)
						{
							last.next = state.next;
						}
						else
						{
							mKeyStateList = state.next;
						}
						state.next = null;
					}
					return state;
				}
				last = state;
				state = state.next;
			}
			return null;
		}

		private void addKeyState(int deviceId, int source, int keyCode)
		{
			android.view.InputEventConsistencyVerifier.KeyState state = android.view.InputEventConsistencyVerifier
				.KeyState.obtain(deviceId, source, keyCode);
			state.next = mKeyStateList;
			mKeyStateList = state;
		}

		private sealed class KeyState
		{
			internal static object mRecycledListLock = new object();

			internal static android.view.InputEventConsistencyVerifier.KeyState mRecycledList;

			internal android.view.InputEventConsistencyVerifier.KeyState next;

			public int deviceId;

			public int source;

			public int keyCode;

			public bool unhandled;

			internal KeyState()
			{
			}

			public static android.view.InputEventConsistencyVerifier.KeyState obtain(int deviceId
				, int source, int keyCode)
			{
				android.view.InputEventConsistencyVerifier.KeyState state;
				lock (mRecycledListLock)
				{
					state = mRecycledList;
					if (state != null)
					{
						mRecycledList = state.next;
					}
					else
					{
						state = new android.view.InputEventConsistencyVerifier.KeyState();
					}
				}
				state.deviceId = deviceId;
				state.source = source;
				state.keyCode = keyCode;
				state.unhandled = false;
				return state;
			}

			public void recycle()
			{
				lock (mRecycledListLock)
				{
					next = mRecycledList;
					mRecycledList = next;
				}
			}
		}
	}
}
