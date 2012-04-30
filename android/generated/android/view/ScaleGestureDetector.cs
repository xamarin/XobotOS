using Sharpen;

namespace android.view
{
	/// <summary>
	/// Detects transformation gestures involving more than one pointer ("multitouch")
	/// using the supplied
	/// <see cref="MotionEvent">MotionEvent</see>
	/// s. The
	/// <see cref="OnScaleGestureListener">OnScaleGestureListener</see>
	/// callback will notify users when a particular gesture event has occurred.
	/// This class should only be used with
	/// <see cref="MotionEvent">MotionEvent</see>
	/// s reported via touch.
	/// To use this class:
	/// <ul>
	/// <li>Create an instance of the
	/// <code>ScaleGestureDetector</code>
	/// for your
	/// <see cref="View">View</see>
	/// <li>In the
	/// <see cref="View.onTouchEvent(MotionEvent)">View.onTouchEvent(MotionEvent)</see>
	/// method ensure you call
	/// <see cref="onTouchEvent(MotionEvent)">onTouchEvent(MotionEvent)</see>
	/// . The methods defined in your
	/// callback will be executed when the events occur.
	/// </ul>
	/// </summary>
	[Sharpen.Sharpened]
	public class ScaleGestureDetector
	{
		internal const string TAG = "ScaleGestureDetector";

		/// <summary>The listener for receiving notifications when gestures occur.</summary>
		/// <remarks>
		/// The listener for receiving notifications when gestures occur.
		/// If you want to listen for all the different gestures then implement
		/// this interface. If you only want to listen for a subset it might
		/// be easier to extend
		/// <see cref="SimpleOnScaleGestureListener">SimpleOnScaleGestureListener</see>
		/// .
		/// An application will receive events in the following order:
		/// <ul>
		/// <li>One
		/// <see cref="onScaleBegin(ScaleGestureDetector)">onScaleBegin(ScaleGestureDetector)
		/// 	</see>
		/// <li>Zero or more
		/// <see cref="onScale(ScaleGestureDetector)">onScale(ScaleGestureDetector)</see>
		/// <li>One
		/// <see cref="onScaleEnd(ScaleGestureDetector)">onScaleEnd(ScaleGestureDetector)</see>
		/// </ul>
		/// </remarks>
		public interface OnScaleGestureListener
		{
			/// <summary>Responds to scaling events for a gesture in progress.</summary>
			/// <remarks>
			/// Responds to scaling events for a gesture in progress.
			/// Reported by pointer motion.
			/// </remarks>
			/// <param name="detector">
			/// The detector reporting the event - use this to
			/// retrieve extended info about event state.
			/// </param>
			/// <returns>
			/// Whether or not the detector should consider this event
			/// as handled. If an event was not handled, the detector
			/// will continue to accumulate movement until an event is
			/// handled. This can be useful if an application, for example,
			/// only wants to update scaling factors if the change is
			/// greater than 0.01.
			/// </returns>
			bool onScale(android.view.ScaleGestureDetector detector);

			/// <summary>Responds to the beginning of a scaling gesture.</summary>
			/// <remarks>
			/// Responds to the beginning of a scaling gesture. Reported by
			/// new pointers going down.
			/// </remarks>
			/// <param name="detector">
			/// The detector reporting the event - use this to
			/// retrieve extended info about event state.
			/// </param>
			/// <returns>
			/// Whether or not the detector should continue recognizing
			/// this gesture. For example, if a gesture is beginning
			/// with a focal point outside of a region where it makes
			/// sense, onScaleBegin() may return false to ignore the
			/// rest of the gesture.
			/// </returns>
			bool onScaleBegin(android.view.ScaleGestureDetector detector);

			/// <summary>Responds to the end of a scale gesture.</summary>
			/// <remarks>
			/// Responds to the end of a scale gesture. Reported by existing
			/// pointers going up.
			/// Once a scale has ended,
			/// <see cref="ScaleGestureDetector.getFocusX()">ScaleGestureDetector.getFocusX()</see>
			/// and
			/// <see cref="ScaleGestureDetector.getFocusY()">ScaleGestureDetector.getFocusY()</see>
			/// will return the location
			/// of the pointer remaining on the screen.
			/// </remarks>
			/// <param name="detector">
			/// The detector reporting the event - use this to
			/// retrieve extended info about event state.
			/// </param>
			void onScaleEnd(android.view.ScaleGestureDetector detector);
		}

		/// <summary>
		/// A convenience class to extend when you only want to listen for a subset
		/// of scaling-related events.
		/// </summary>
		/// <remarks>
		/// A convenience class to extend when you only want to listen for a subset
		/// of scaling-related events. This implements all methods in
		/// <see cref="OnScaleGestureListener">OnScaleGestureListener</see>
		/// but does nothing.
		/// <see cref="OnScaleGestureListener.onScale(ScaleGestureDetector)">OnScaleGestureListener.onScale(ScaleGestureDetector)
		/// 	</see>
		/// returns
		/// <code>false</code>
		/// so that a subclass can retrieve the accumulated scale
		/// factor in an overridden onScaleEnd.
		/// <see cref="OnScaleGestureListener.onScaleBegin(ScaleGestureDetector)">OnScaleGestureListener.onScaleBegin(ScaleGestureDetector)
		/// 	</see>
		/// returns
		/// <code>true</code>
		/// .
		/// </remarks>
		public class SimpleOnScaleGestureListener : android.view.ScaleGestureDetector.OnScaleGestureListener
		{
			[Sharpen.ImplementsInterface(@"android.view.ScaleGestureDetector.OnScaleGestureListener"
				)]
			public virtual bool onScale(android.view.ScaleGestureDetector detector)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.ScaleGestureDetector.OnScaleGestureListener"
				)]
			public virtual bool onScaleBegin(android.view.ScaleGestureDetector detector)
			{
				return true;
			}

			[Sharpen.ImplementsInterface(@"android.view.ScaleGestureDetector.OnScaleGestureListener"
				)]
			public virtual void onScaleEnd(android.view.ScaleGestureDetector detector)
			{
			}
			// Intentionally empty
		}

		/// <summary>
		/// This value is the threshold ratio between our previous combined pressure
		/// and the current combined pressure.
		/// </summary>
		/// <remarks>
		/// This value is the threshold ratio between our previous combined pressure
		/// and the current combined pressure. We will only fire an onScale event if
		/// the computed ratio between the current and previous event pressures is
		/// greater than this value. When pressure decreases rapidly between events
		/// the position values can often be imprecise, as it usually indicates
		/// that the user is in the process of lifting a pointer off of the device.
		/// Its value was tuned experimentally.
		/// </remarks>
		internal const float PRESSURE_THRESHOLD = 0.67f;

		private readonly android.content.Context mContext;

		private readonly android.view.ScaleGestureDetector.OnScaleGestureListener mListener;

		private bool mGestureInProgress;

		private android.view.MotionEvent mPrevEvent;

		private android.view.MotionEvent mCurrEvent;

		private float mFocusX;

		private float mFocusY;

		private float mPrevFingerDiffX;

		private float mPrevFingerDiffY;

		private float mCurrFingerDiffX;

		private float mCurrFingerDiffY;

		private float mCurrLen;

		private float mPrevLen;

		private float mScaleFactor;

		private float mCurrPressure;

		private float mPrevPressure;

		private long mTimeDelta;

		private readonly float mEdgeSlop;

		private float mRightSlopEdge;

		private float mBottomSlopEdge;

		private bool mSloppyGesture;

		private bool mInvalidGesture;

		private int mActiveId0;

		private int mActiveId1;

		private bool mActive0MostRecent;

		/// <summary>Consistency verifier for debugging purposes.</summary>
		/// <remarks>Consistency verifier for debugging purposes.</remarks>
		private readonly android.view.InputEventConsistencyVerifier mInputEventConsistencyVerifier;

		public ScaleGestureDetector(android.content.Context context, android.view.ScaleGestureDetector
			.OnScaleGestureListener listener)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
			// Pointer IDs currently responsible for the two fingers controlling the gesture
			android.view.ViewConfiguration config = android.view.ViewConfiguration.get(context
				);
			mContext = context;
			mListener = listener;
			mEdgeSlop = config.getScaledEdgeSlop();
		}

		public virtual bool onTouchEvent(android.view.MotionEvent @event)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onTouchEvent(@event, 0);
			}
			int action = @event.getActionMasked();
			if (action == android.view.MotionEvent.ACTION_DOWN)
			{
				reset();
			}
			// Start fresh
			bool handled = true;
			if (mInvalidGesture)
			{
				handled = false;
			}
			else
			{
				if (!mGestureInProgress)
				{
					switch (action)
					{
						case android.view.MotionEvent.ACTION_DOWN:
						{
							mActiveId0 = @event.getPointerId(0);
							mActive0MostRecent = true;
							break;
						}

						case android.view.MotionEvent.ACTION_UP:
						{
							reset();
							break;
						}

						case android.view.MotionEvent.ACTION_POINTER_DOWN:
						{
							// We have a new multi-finger gesture
							// as orientation can change, query the metrics in touch down
							android.util.DisplayMetrics metrics = mContext.getResources().getDisplayMetrics();
							mRightSlopEdge = metrics.widthPixels - mEdgeSlop;
							mBottomSlopEdge = metrics.heightPixels - mEdgeSlop;
							if (mPrevEvent != null)
							{
								mPrevEvent.recycle();
							}
							mPrevEvent = android.view.MotionEvent.obtain(@event);
							mTimeDelta = 0;
							int index1 = @event.getActionIndex();
							int index0 = @event.findPointerIndex(mActiveId0);
							mActiveId1 = @event.getPointerId(index1);
							if (index0 < 0 || index0 == index1)
							{
								// Probably someone sending us a broken event stream.
								index0 = findNewActiveIndex(@event, index0 == index1 ? -1 : mActiveId1, index0);
								mActiveId0 = @event.getPointerId(index0);
							}
							mActive0MostRecent = false;
							setContext(@event);
							// Check if we have a sloppy gesture. If so, delay
							// the beginning of the gesture until we're sure that's
							// what the user wanted. Sloppy gestures can happen if the
							// edge of the user's hand is touching the screen, for example.
							float edgeSlop = mEdgeSlop;
							float rightSlop = mRightSlopEdge;
							float bottomSlop = mBottomSlopEdge;
							float x0 = getRawX(@event, index0);
							float y0 = getRawY(@event, index0);
							float x1 = getRawX(@event, index1);
							float y1 = getRawY(@event, index1);
							bool p0sloppy = x0 < edgeSlop || y0 < edgeSlop || x0 > rightSlop || y0 > bottomSlop;
							bool p1sloppy = x1 < edgeSlop || y1 < edgeSlop || x1 > rightSlop || y1 > bottomSlop;
							if (p0sloppy && p1sloppy)
							{
								mFocusX = -1;
								mFocusY = -1;
								mSloppyGesture = true;
							}
							else
							{
								if (p0sloppy)
								{
									mFocusX = @event.getX(index1);
									mFocusY = @event.getY(index1);
									mSloppyGesture = true;
								}
								else
								{
									if (p1sloppy)
									{
										mFocusX = @event.getX(index0);
										mFocusY = @event.getY(index0);
										mSloppyGesture = true;
									}
									else
									{
										mSloppyGesture = false;
										mGestureInProgress = mListener.onScaleBegin(this);
									}
								}
							}
							break;
						}

						case android.view.MotionEvent.ACTION_MOVE:
						{
							if (mSloppyGesture)
							{
								// Initiate sloppy gestures if we've moved outside of the slop area.
								float edgeSlop = mEdgeSlop;
								float rightSlop = mRightSlopEdge;
								float bottomSlop = mBottomSlopEdge;
								int index0 = @event.findPointerIndex(mActiveId0);
								int index1 = @event.findPointerIndex(mActiveId1);
								float x0 = getRawX(@event, index0);
								float y0 = getRawY(@event, index0);
								float x1 = getRawX(@event, index1);
								float y1 = getRawY(@event, index1);
								bool p0sloppy = x0 < edgeSlop || y0 < edgeSlop || x0 > rightSlop || y0 > bottomSlop;
								bool p1sloppy = x1 < edgeSlop || y1 < edgeSlop || x1 > rightSlop || y1 > bottomSlop;
								if (p0sloppy)
								{
									// Do we have a different pointer that isn't sloppy?
									int index = findNewActiveIndex(@event, mActiveId1, index0);
									if (index >= 0)
									{
										index0 = index;
										mActiveId0 = @event.getPointerId(index);
										x0 = getRawX(@event, index);
										y0 = getRawY(@event, index);
										p0sloppy = false;
									}
								}
								if (p1sloppy)
								{
									// Do we have a different pointer that isn't sloppy?
									int index = findNewActiveIndex(@event, mActiveId0, index1);
									if (index >= 0)
									{
										index1 = index;
										mActiveId1 = @event.getPointerId(index);
										x1 = getRawX(@event, index);
										y1 = getRawY(@event, index);
										p1sloppy = false;
									}
								}
								if (p0sloppy && p1sloppy)
								{
									mFocusX = -1;
									mFocusY = -1;
								}
								else
								{
									if (p0sloppy)
									{
										mFocusX = @event.getX(index1);
										mFocusY = @event.getY(index1);
									}
									else
									{
										if (p1sloppy)
										{
											mFocusX = @event.getX(index0);
											mFocusY = @event.getY(index0);
										}
										else
										{
											mSloppyGesture = false;
											mGestureInProgress = mListener.onScaleBegin(this);
										}
									}
								}
							}
							break;
						}

						case android.view.MotionEvent.ACTION_POINTER_UP:
						{
							if (mSloppyGesture)
							{
								int pointerCount = @event.getPointerCount();
								int actionIndex = @event.getActionIndex();
								int actionId = @event.getPointerId(actionIndex);
								if (pointerCount > 2)
								{
									if (actionId == mActiveId0)
									{
										int newIndex = findNewActiveIndex(@event, mActiveId1, actionIndex);
										if (newIndex >= 0)
										{
											mActiveId0 = @event.getPointerId(newIndex);
										}
									}
									else
									{
										if (actionId == mActiveId1)
										{
											int newIndex = findNewActiveIndex(@event, mActiveId0, actionIndex);
											if (newIndex >= 0)
											{
												mActiveId1 = @event.getPointerId(newIndex);
											}
										}
									}
								}
								else
								{
									// Set focus point to the remaining finger
									int index = @event.findPointerIndex(actionId == mActiveId0 ? mActiveId1 : mActiveId0
										);
									if (index < 0)
									{
										mInvalidGesture = true;
										android.util.Log.e(TAG, "Invalid MotionEvent stream detected.", new System.Exception
											());
										if (mGestureInProgress)
										{
											mListener.onScaleEnd(this);
										}
										return false;
									}
									mActiveId0 = @event.getPointerId(index);
									mActive0MostRecent = true;
									mActiveId1 = -1;
									mFocusX = @event.getX(index);
									mFocusY = @event.getY(index);
								}
							}
							break;
						}
					}
				}
				else
				{
					switch (action)
					{
						case android.view.MotionEvent.ACTION_POINTER_DOWN:
						{
							// Transform gesture in progress - attempt to handle it
							// End the old gesture and begin a new one with the most recent two fingers.
							mListener.onScaleEnd(this);
							int oldActive0 = mActiveId0;
							int oldActive1 = mActiveId1;
							reset();
							mPrevEvent = android.view.MotionEvent.obtain(@event);
							mActiveId0 = mActive0MostRecent ? oldActive0 : oldActive1;
							mActiveId1 = @event.getPointerId(@event.getActionIndex());
							mActive0MostRecent = false;
							int index0 = @event.findPointerIndex(mActiveId0);
							if (index0 < 0 || mActiveId0 == mActiveId1)
							{
								// Probably someone sending us a broken event stream.
								android.util.Log.e(TAG, "Got " + android.view.MotionEvent.actionToString(action) 
									+ " with bad state while a gesture was in progress. " + "Did you forget to pass an event to "
									 + "ScaleGestureDetector#onTouchEvent?");
								index0 = findNewActiveIndex(@event, mActiveId0 == mActiveId1 ? -1 : mActiveId1, index0
									);
								mActiveId0 = @event.getPointerId(index0);
							}
							setContext(@event);
							mGestureInProgress = mListener.onScaleBegin(this);
							break;
						}

						case android.view.MotionEvent.ACTION_POINTER_UP:
						{
							int pointerCount = @event.getPointerCount();
							int actionIndex = @event.getActionIndex();
							int actionId = @event.getPointerId(actionIndex);
							bool gestureEnded = false;
							if (pointerCount > 2)
							{
								if (actionId == mActiveId0)
								{
									int newIndex = findNewActiveIndex(@event, mActiveId1, actionIndex);
									if (newIndex >= 0)
									{
										mListener.onScaleEnd(this);
										mActiveId0 = @event.getPointerId(newIndex);
										mActive0MostRecent = true;
										mPrevEvent = android.view.MotionEvent.obtain(@event);
										setContext(@event);
										mGestureInProgress = mListener.onScaleBegin(this);
									}
									else
									{
										gestureEnded = true;
									}
								}
								else
								{
									if (actionId == mActiveId1)
									{
										int newIndex = findNewActiveIndex(@event, mActiveId0, actionIndex);
										if (newIndex >= 0)
										{
											mListener.onScaleEnd(this);
											mActiveId1 = @event.getPointerId(newIndex);
											mActive0MostRecent = false;
											mPrevEvent = android.view.MotionEvent.obtain(@event);
											setContext(@event);
											mGestureInProgress = mListener.onScaleBegin(this);
										}
										else
										{
											gestureEnded = true;
										}
									}
								}
								mPrevEvent.recycle();
								mPrevEvent = android.view.MotionEvent.obtain(@event);
								setContext(@event);
							}
							else
							{
								gestureEnded = true;
							}
							if (gestureEnded)
							{
								// Gesture ended
								setContext(@event);
								// Set focus point to the remaining finger
								int activeId = actionId == mActiveId0 ? mActiveId1 : mActiveId0;
								int index = @event.findPointerIndex(activeId);
								mFocusX = @event.getX(index);
								mFocusY = @event.getY(index);
								mListener.onScaleEnd(this);
								reset();
								mActiveId0 = activeId;
								mActive0MostRecent = true;
							}
							break;
						}

						case android.view.MotionEvent.ACTION_CANCEL:
						{
							mListener.onScaleEnd(this);
							reset();
							break;
						}

						case android.view.MotionEvent.ACTION_UP:
						{
							reset();
							break;
						}

						case android.view.MotionEvent.ACTION_MOVE:
						{
							setContext(@event);
							// Only accept the event if our relative pressure is within
							// a certain limit - this can help filter shaky data as a
							// finger is lifted.
							if (mCurrPressure / mPrevPressure > PRESSURE_THRESHOLD)
							{
								bool updatePrevious = mListener.onScale(this);
								if (updatePrevious)
								{
									mPrevEvent.recycle();
									mPrevEvent = android.view.MotionEvent.obtain(@event);
								}
							}
							break;
						}
					}
				}
			}
			if (!handled && mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(@event, 0);
			}
			return handled;
		}

		private int findNewActiveIndex(android.view.MotionEvent ev, int otherActiveId, int
			 oldIndex)
		{
			int pointerCount = ev.getPointerCount();
			// It's ok if this isn't found and returns -1, it simply won't match.
			int otherActiveIndex = ev.findPointerIndex(otherActiveId);
			int newActiveIndex = -1;
			{
				// Pick a new id and update tracking state. Only pick pointers not on the slop edges.
				for (int i = 0; i < pointerCount; i++)
				{
					if (i != oldIndex && i != otherActiveIndex)
					{
						float edgeSlop = mEdgeSlop;
						float rightSlop = mRightSlopEdge;
						float bottomSlop = mBottomSlopEdge;
						float x = getRawX(ev, i);
						float y = getRawY(ev, i);
						if (x >= edgeSlop && y >= edgeSlop && x <= rightSlop && y <= bottomSlop)
						{
							newActiveIndex = i;
							break;
						}
					}
				}
			}
			return newActiveIndex;
		}

		/// <summary>MotionEvent has no getRawX(int) method; simulate it pending future API approval.
		/// 	</summary>
		/// <remarks>MotionEvent has no getRawX(int) method; simulate it pending future API approval.
		/// 	</remarks>
		private static float getRawX(android.view.MotionEvent @event, int pointerIndex)
		{
			if (pointerIndex < 0)
			{
				return float.MinValue;
			}
			if (pointerIndex == 0)
			{
				return @event.getRawX();
			}
			float offset = @event.getRawX() - @event.getX();
			return @event.getX(pointerIndex) + offset;
		}

		/// <summary>MotionEvent has no getRawY(int) method; simulate it pending future API approval.
		/// 	</summary>
		/// <remarks>MotionEvent has no getRawY(int) method; simulate it pending future API approval.
		/// 	</remarks>
		private static float getRawY(android.view.MotionEvent @event, int pointerIndex)
		{
			if (pointerIndex < 0)
			{
				return float.MinValue;
			}
			if (pointerIndex == 0)
			{
				return @event.getRawY();
			}
			float offset = @event.getRawY() - @event.getY();
			return @event.getY(pointerIndex) + offset;
		}

		private void setContext(android.view.MotionEvent curr)
		{
			if (mCurrEvent != null)
			{
				mCurrEvent.recycle();
			}
			mCurrEvent = android.view.MotionEvent.obtain(curr);
			mCurrLen = -1;
			mPrevLen = -1;
			mScaleFactor = -1;
			android.view.MotionEvent prev = mPrevEvent;
			int prevIndex0 = prev.findPointerIndex(mActiveId0);
			int prevIndex1 = prev.findPointerIndex(mActiveId1);
			int currIndex0 = curr.findPointerIndex(mActiveId0);
			int currIndex1 = curr.findPointerIndex(mActiveId1);
			if (prevIndex0 < 0 || prevIndex1 < 0 || currIndex0 < 0 || currIndex1 < 0)
			{
				mInvalidGesture = true;
				android.util.Log.e(TAG, "Invalid MotionEvent stream detected.", new System.Exception
					());
				if (mGestureInProgress)
				{
					mListener.onScaleEnd(this);
				}
				return;
			}
			float px0 = prev.getX(prevIndex0);
			float py0 = prev.getY(prevIndex0);
			float px1 = prev.getX(prevIndex1);
			float py1 = prev.getY(prevIndex1);
			float cx0 = curr.getX(currIndex0);
			float cy0 = curr.getY(currIndex0);
			float cx1 = curr.getX(currIndex1);
			float cy1 = curr.getY(currIndex1);
			float pvx = px1 - px0;
			float pvy = py1 - py0;
			float cvx = cx1 - cx0;
			float cvy = cy1 - cy0;
			mPrevFingerDiffX = pvx;
			mPrevFingerDiffY = pvy;
			mCurrFingerDiffX = cvx;
			mCurrFingerDiffY = cvy;
			mFocusX = cx0 + cvx * 0.5f;
			mFocusY = cy0 + cvy * 0.5f;
			mTimeDelta = curr.getEventTime() - prev.getEventTime();
			mCurrPressure = curr.getPressure(currIndex0) + curr.getPressure(currIndex1);
			mPrevPressure = prev.getPressure(prevIndex0) + prev.getPressure(prevIndex1);
		}

		private void reset()
		{
			if (mPrevEvent != null)
			{
				mPrevEvent.recycle();
				mPrevEvent = null;
			}
			if (mCurrEvent != null)
			{
				mCurrEvent.recycle();
				mCurrEvent = null;
			}
			mSloppyGesture = false;
			mGestureInProgress = false;
			mActiveId0 = -1;
			mActiveId1 = -1;
			mInvalidGesture = false;
		}

		/// <summary>
		/// Returns
		/// <code>true</code>
		/// if a two-finger scale gesture is in progress.
		/// </summary>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if a scale gesture is in progress,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool isInProgress()
		{
			return mGestureInProgress;
		}

		/// <summary>Get the X coordinate of the current gesture's focal point.</summary>
		/// <remarks>
		/// Get the X coordinate of the current gesture's focal point.
		/// If a gesture is in progress, the focal point is directly between
		/// the two pointers forming the gesture.
		/// If a gesture is ending, the focal point is the location of the
		/// remaining pointer on the screen.
		/// If
		/// <see cref="isInProgress()">isInProgress()</see>
		/// would return false, the result of this
		/// function is undefined.
		/// </remarks>
		/// <returns>X coordinate of the focal point in pixels.</returns>
		public virtual float getFocusX()
		{
			return mFocusX;
		}

		/// <summary>Get the Y coordinate of the current gesture's focal point.</summary>
		/// <remarks>
		/// Get the Y coordinate of the current gesture's focal point.
		/// If a gesture is in progress, the focal point is directly between
		/// the two pointers forming the gesture.
		/// If a gesture is ending, the focal point is the location of the
		/// remaining pointer on the screen.
		/// If
		/// <see cref="isInProgress()">isInProgress()</see>
		/// would return false, the result of this
		/// function is undefined.
		/// </remarks>
		/// <returns>Y coordinate of the focal point in pixels.</returns>
		public virtual float getFocusY()
		{
			return mFocusY;
		}

		/// <summary>
		/// Return the current distance between the two pointers forming the
		/// gesture in progress.
		/// </summary>
		/// <remarks>
		/// Return the current distance between the two pointers forming the
		/// gesture in progress.
		/// </remarks>
		/// <returns>Distance between pointers in pixels.</returns>
		public virtual float getCurrentSpan()
		{
			if (mCurrLen == -1)
			{
				float cvx = mCurrFingerDiffX;
				float cvy = mCurrFingerDiffY;
				mCurrLen = android.util.FloatMath.sqrt(cvx * cvx + cvy * cvy);
			}
			return mCurrLen;
		}

		/// <summary>
		/// Return the current x distance between the two pointers forming the
		/// gesture in progress.
		/// </summary>
		/// <remarks>
		/// Return the current x distance between the two pointers forming the
		/// gesture in progress.
		/// </remarks>
		/// <returns>Distance between pointers in pixels.</returns>
		public virtual float getCurrentSpanX()
		{
			return mCurrFingerDiffX;
		}

		/// <summary>
		/// Return the current y distance between the two pointers forming the
		/// gesture in progress.
		/// </summary>
		/// <remarks>
		/// Return the current y distance between the two pointers forming the
		/// gesture in progress.
		/// </remarks>
		/// <returns>Distance between pointers in pixels.</returns>
		public virtual float getCurrentSpanY()
		{
			return mCurrFingerDiffY;
		}

		/// <summary>
		/// Return the previous distance between the two pointers forming the
		/// gesture in progress.
		/// </summary>
		/// <remarks>
		/// Return the previous distance between the two pointers forming the
		/// gesture in progress.
		/// </remarks>
		/// <returns>Previous distance between pointers in pixels.</returns>
		public virtual float getPreviousSpan()
		{
			if (mPrevLen == -1)
			{
				float pvx = mPrevFingerDiffX;
				float pvy = mPrevFingerDiffY;
				mPrevLen = android.util.FloatMath.sqrt(pvx * pvx + pvy * pvy);
			}
			return mPrevLen;
		}

		/// <summary>
		/// Return the previous x distance between the two pointers forming the
		/// gesture in progress.
		/// </summary>
		/// <remarks>
		/// Return the previous x distance between the two pointers forming the
		/// gesture in progress.
		/// </remarks>
		/// <returns>Previous distance between pointers in pixels.</returns>
		public virtual float getPreviousSpanX()
		{
			return mPrevFingerDiffX;
		}

		/// <summary>
		/// Return the previous y distance between the two pointers forming the
		/// gesture in progress.
		/// </summary>
		/// <remarks>
		/// Return the previous y distance between the two pointers forming the
		/// gesture in progress.
		/// </remarks>
		/// <returns>Previous distance between pointers in pixels.</returns>
		public virtual float getPreviousSpanY()
		{
			return mPrevFingerDiffY;
		}

		/// <summary>
		/// Return the scaling factor from the previous scale event to the current
		/// event.
		/// </summary>
		/// <remarks>
		/// Return the scaling factor from the previous scale event to the current
		/// event. This value is defined as
		/// (
		/// <see cref="getCurrentSpan()">getCurrentSpan()</see>
		/// /
		/// <see cref="getPreviousSpan()">getPreviousSpan()</see>
		/// ).
		/// </remarks>
		/// <returns>The current scaling factor.</returns>
		public virtual float getScaleFactor()
		{
			if (mScaleFactor == -1)
			{
				mScaleFactor = getCurrentSpan() / getPreviousSpan();
			}
			return mScaleFactor;
		}

		/// <summary>
		/// Return the time difference in milliseconds between the previous
		/// accepted scaling event and the current scaling event.
		/// </summary>
		/// <remarks>
		/// Return the time difference in milliseconds between the previous
		/// accepted scaling event and the current scaling event.
		/// </remarks>
		/// <returns>Time difference since the last scaling event in milliseconds.</returns>
		public virtual long getTimeDelta()
		{
			return mTimeDelta;
		}

		/// <summary>Return the event time of the current event being processed.</summary>
		/// <remarks>Return the event time of the current event being processed.</remarks>
		/// <returns>Current event time in milliseconds.</returns>
		public virtual long getEventTime()
		{
			return mCurrEvent.getEventTime();
		}
	}
}
