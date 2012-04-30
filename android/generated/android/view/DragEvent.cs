using Sharpen;

namespace android.view
{
	/// <summary>
	/// Represents an event that is sent out by the system at various times during a drag and drop
	/// operation.
	/// </summary>
	/// <remarks>
	/// Represents an event that is sent out by the system at various times during a drag and drop
	/// operation. It is a complex data structure that contains several important pieces of data about
	/// the operation and the underlying data.
	/// <p>
	/// View objects that receive a DragEvent call
	/// <see cref="getAction()">getAction()</see>
	/// , which returns
	/// an action type that indicates the state of the drag and drop operation. This allows a View
	/// object to react to a change in state by changing its appearance or performing other actions.
	/// For example, a View can react to the
	/// <see cref="ACTION_DRAG_ENTERED">ACTION_DRAG_ENTERED</see>
	/// action type by
	/// by changing one or more colors in its displayed image.
	/// </p>
	/// <p>
	/// During a drag and drop operation, the system displays an image that the user drags. This image
	/// is called a drag shadow. Several action types reflect the position of the drag shadow relative
	/// to the View receiving the event.
	/// </p>
	/// <p>
	/// Most methods return valid data only for certain event actions. This is summarized in the
	/// following table. Each possible
	/// <see cref="getAction()">getAction()</see>
	/// value is listed in the first column. The
	/// other columns indicate which method or methods return valid data for that getAction() value:
	/// </p>
	/// <table>
	/// <tr>
	/// <th scope="col">getAction() Value</th>
	/// <th scope="col">getClipDescription()</th>
	/// <th scope="col">getLocalState()</th>
	/// <th scope="col">getX()</th>
	/// <th scope="col">getY()</th>
	/// <th scope="col">getClipData()</th>
	/// <th scope="col">getResult()</th>
	/// </tr>
	/// <tr>
	/// <td>ACTION_DRAG_STARTED</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// </tr>
	/// <tr>
	/// <td>ACTION_DRAG_ENTERED</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// </tr>
	/// <tr>
	/// <td>ACTION_DRAG_LOCATION</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// </tr>
	/// <tr>
	/// <td>ACTION_DRAG_EXITED</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// </tr>
	/// <tr>
	/// <td>ACTION_DROP</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// </tr>
	/// <tr>
	/// <td>ACTION_DRAG_ENDED</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">X</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">&nbsp;</td>
	/// <td style="text-align: center;">X</td>
	/// </tr>
	/// </table>
	/// <p>
	/// The
	/// <see cref="getAction()">getAction()</see>
	/// ,
	/// <see cref="describeContents()">describeContents()</see>
	/// ,
	/// <see cref="writeToParcel(android.os.Parcel, int)">writeToParcel(android.os.Parcel, int)
	/// 	</see>
	/// , and
	/// <see cref="ToString()">ToString()</see>
	/// methods always return valid data.
	/// </p>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For a guide to implementing drag and drop features, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/drag-drop.html"&gt;Drag and Drop</a> developer guide.</p>
	/// </div>
	/// </remarks>
	[Sharpen.Sharpened]
	public class DragEvent : android.os.Parcelable
	{
		internal const bool TRACK_RECYCLED_LOCATION = false;

		internal int mAction;

		internal float mX;

		internal float mY;

		internal android.content.ClipDescription mClipDescription;

		internal android.content.ClipData mClipData;

		internal object mLocalState;

		internal bool mDragResult;

		private android.view.DragEvent mNext;

		private java.lang.RuntimeException mRecycledLocation;

		private bool mRecycled;

		internal const int MAX_RECYCLED = 10;

		private static readonly object gRecyclerLock = new object();

		private static int gRecyclerUsed = 0;

		private static android.view.DragEvent gRecyclerTop = null;

		/// <summary>
		/// Action constant returned by
		/// <see cref="getAction()">getAction()</see>
		/// : Signals the start of a
		/// drag and drop operation. The View should return
		/// <code>true</code>
		/// from its
		/// <see cref="View.onDragEvent(DragEvent)">onDragEvent()</see>
		/// handler method or
		/// <see cref="View.View.OnDragListener#onDrag(View,DragEvent)">OnDragListener.onDrag()
		/// 	</see>
		/// listener
		/// if it can accept a drop. The onDragEvent() or onDrag() methods usually inspect the metadata
		/// from
		/// <see cref="getClipDescription()">getClipDescription()</see>
		/// to determine if they can accept the data contained in
		/// this drag. For an operation that doesn't represent data transfer, these methods may
		/// perform other actions to determine whether or not the View should accept the drag.
		/// If the View wants to indicate that it is a valid drop target, it can also react by
		/// changing its appearance.
		/// <p>
		/// A View only receives further drag events if it returns
		/// <code>true</code>
		/// in response to
		/// ACTION_DRAG_STARTED.
		/// </p>
		/// </summary>
		/// <seealso cref="ACTION_DRAG_ENDED">ACTION_DRAG_ENDED</seealso>
		public const int ACTION_DRAG_STARTED = 1;

		/// <summary>
		/// Action constant returned by
		/// <see cref="getAction()">getAction()</see>
		/// : Sent to a View after
		/// <see cref="ACTION_DRAG_ENTERED">ACTION_DRAG_ENTERED</see>
		/// if the drag shadow is still within the View object's bounding
		/// box. The
		/// <see cref="getX()">getX()</see>
		/// and
		/// <see cref="getY()">getY()</see>
		/// methods supply
		/// the X and Y position of of the drag point within the View object's bounding box.
		/// <p>
		/// A View receives an
		/// <see cref="ACTION_DRAG_ENTERED">ACTION_DRAG_ENTERED</see>
		/// event before receiving any
		/// ACTION_DRAG_LOCATION events.
		/// </p>
		/// <p>
		/// The system stops sending ACTION_DRAG_LOCATION events to a View once the user moves the
		/// drag shadow out of the View object's bounding box. If the user moves the drag shadow back
		/// into the View object's bounding box, the View receives an ACTION_DRAG_ENTERED again before
		/// receiving any more ACTION_DRAG_LOCATION events.
		/// </p>
		/// </summary>
		/// <seealso cref="ACTION_DRAG_ENTERED">ACTION_DRAG_ENTERED</seealso>
		/// <seealso cref="getX()">getX()</seealso>
		/// <seealso cref="getY()">getY()</seealso>
		public const int ACTION_DRAG_LOCATION = 2;

		/// <summary>
		/// Action constant returned by
		/// <see cref="getAction()">getAction()</see>
		/// : Signals to a View that the user
		/// has released the drag shadow, and the drag point is within the bounding box of the View.
		/// The View should retrieve the data from the DragEvent by calling
		/// <see cref="getClipData()">getClipData()</see>
		/// .
		/// The methods
		/// <see cref="getX()">getX()</see>
		/// and
		/// <see cref="getY()">getY()</see>
		/// return the X and Y position of the drop point
		/// within the View object's bounding box.
		/// <p>
		/// The View should return
		/// <code>true</code>
		/// from its
		/// <see cref="View.onDragEvent(DragEvent)">View.onDragEvent(DragEvent)</see>
		/// handler or
		/// <see cref="View.View.OnDragListener#onDrag(View,DragEvent)">OnDragListener.onDrag()
		/// 	</see>
		/// listener if it accepted the drop, and
		/// <code>false</code>
		/// if it ignored the drop.
		/// </p>
		/// <p>
		/// The View can also react to this action by changing its appearance.
		/// </p>
		/// </summary>
		/// <seealso cref="getClipData()">getClipData()</seealso>
		/// <seealso cref="getX()">getX()</seealso>
		/// <seealso cref="getY()">getY()</seealso>
		public const int ACTION_DROP = 3;

		/// <summary>
		/// Action constant returned by
		/// <see cref="getAction()">getAction()</see>
		/// :  Signals to a View that the drag and drop
		/// operation has concluded.  A View that changed its appearance during the operation should
		/// return to its usual drawing state in response to this event.
		/// <p>
		/// All views that received an ACTION_DRAG_STARTED event will receive the
		/// ACTION_DRAG_ENDED event even if they are not currently visible when the drag ends.
		/// </p>
		/// <p>
		/// The View object can call
		/// <see cref="getResult()">getResult()</see>
		/// to see the result of the operation.
		/// If a View returned
		/// <code>true</code>
		/// in response to
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// , then
		/// getResult() returns
		/// <code>true</code>
		/// , otherwise it returns
		/// <code>false</code>
		/// .
		/// </p>
		/// </summary>
		/// <seealso cref="ACTION_DRAG_STARTED">ACTION_DRAG_STARTED</seealso>
		/// <seealso cref="getResult()">getResult()</seealso>
		public const int ACTION_DRAG_ENDED = 4;

		/// <summary>
		/// Action constant returned by
		/// <see cref="getAction()">getAction()</see>
		/// : Signals to a View that the drag point has
		/// entered the bounding box of the View.
		/// <p>
		/// If the View can accept a drop, it can react to ACTION_DRAG_ENTERED
		/// by changing its appearance in a way that tells the user that the View is the current
		/// drop target.
		/// </p>
		/// The system stops sending ACTION_DRAG_LOCATION events to a View once the user moves the
		/// drag shadow out of the View object's bounding box. If the user moves the drag shadow back
		/// into the View object's bounding box, the View receives an ACTION_DRAG_ENTERED again before
		/// receiving any more ACTION_DRAG_LOCATION events.
		/// </p>
		/// </summary>
		/// <seealso cref="ACTION_DRAG_ENTERED">ACTION_DRAG_ENTERED</seealso>
		/// <seealso cref="ACTION_DRAG_LOCATION">ACTION_DRAG_LOCATION</seealso>
		public const int ACTION_DRAG_ENTERED = 5;

		/// <summary>
		/// Action constant returned by
		/// <see cref="getAction()">getAction()</see>
		/// : Signals that the user has moved the
		/// drag shadow outside the bounding box of the View.
		/// The View can react by changing its appearance in a way that tells the user that
		/// View is no longer the immediate drop target.
		/// <p>
		/// After the system sends an ACTION_DRAG_EXITED event to the View, the View receives no more
		/// ACTION_DRAG_LOCATION events until the user drags the drag shadow back over the View.
		/// </p>
		/// </summary>
		public const int ACTION_DRAG_EXITED = 6;

		private DragEvent()
		{
		}

		//TODO: Improve Javadoc
		private void init(int action, float x, float y, android.content.ClipDescription description
			, android.content.ClipData data, object localState, bool result)
		{
			mAction = action;
			mX = x;
			mY = y;
			mClipDescription = description;
			mClipData = data;
			mLocalState = localState;
			mDragResult = result;
		}

		internal static android.view.DragEvent obtain()
		{
			return android.view.DragEvent.obtain(0, 0f, 0f, null, null, null, false);
		}

		/// <hide></hide>
		public static android.view.DragEvent obtain(int action, float x, float y, object 
			localState, android.content.ClipDescription description, android.content.ClipData
			 data, bool result)
		{
			android.view.DragEvent ev;
			lock (gRecyclerLock)
			{
				if (gRecyclerTop == null)
				{
					ev = new android.view.DragEvent();
					ev.init(action, x, y, description, data, localState, result);
					return ev;
				}
				ev = gRecyclerTop;
				gRecyclerTop = ev.mNext;
				gRecyclerUsed -= 1;
			}
			ev.mRecycledLocation = null;
			ev.mRecycled = false;
			ev.mNext = null;
			ev.init(action, x, y, description, data, localState, result);
			return ev;
		}

		/// <hide></hide>
		public static android.view.DragEvent obtain(android.view.DragEvent source)
		{
			return obtain(source.mAction, source.mX, source.mY, source.mLocalState, source.mClipDescription
				, source.mClipData, source.mDragResult);
		}

		/// <summary>Inspect the action value of this event.</summary>
		/// <remarks>Inspect the action value of this event.</remarks>
		/// <returns>
		/// One of the following action constants, in the order in which they usually occur
		/// during a drag and drop operation:
		/// <ul>
		/// <li>
		/// <see cref="ACTION_DRAG_STARTED">ACTION_DRAG_STARTED</see>
		/// </li>
		/// <li>
		/// <see cref="ACTION_DRAG_ENTERED">ACTION_DRAG_ENTERED</see>
		/// </li>
		/// <li>
		/// <see cref="ACTION_DRAG_LOCATION">ACTION_DRAG_LOCATION</see>
		/// </li>
		/// <li>
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// </li>
		/// <li>
		/// <see cref="ACTION_DRAG_EXITED">ACTION_DRAG_EXITED</see>
		/// </li>
		/// <li>
		/// <see cref="ACTION_DRAG_ENDED">ACTION_DRAG_ENDED</see>
		/// </li>
		/// </ul>
		/// </returns>
		public virtual int getAction()
		{
			return mAction;
		}

		/// <summary>Gets the X coordinate of the drag point.</summary>
		/// <remarks>
		/// Gets the X coordinate of the drag point. The value is only valid if the event action is
		/// <see cref="ACTION_DRAG_LOCATION">ACTION_DRAG_LOCATION</see>
		/// or
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// .
		/// </remarks>
		/// <returns>The current drag point's Y coordinate</returns>
		public virtual float getX()
		{
			return mX;
		}

		/// <summary>Gets the Y coordinate of the drag point.</summary>
		/// <remarks>
		/// Gets the Y coordinate of the drag point. The value is valid if the
		/// event action is
		/// <see cref="ACTION_DRAG_ENTERED">ACTION_DRAG_ENTERED</see>
		/// ,
		/// <see cref="ACTION_DRAG_LOCATION">ACTION_DRAG_LOCATION</see>
		/// ,
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// , or
		/// <see cref="ACTION_DRAG_EXITED">ACTION_DRAG_EXITED</see>
		/// .
		/// </remarks>
		/// <returns>The current drag point's Y coordinate</returns>
		public virtual float getY()
		{
			return mY;
		}

		/// <summary>
		/// Returns the
		/// <see cref="android.content.ClipData">android.content.ClipData</see>
		/// object sent to the system as part of the call
		/// to
		/// <see cref="View.startDrag(android.content.ClipData, DragShadowBuilder, object, int)
		/// 	">startDrag()</see>
		/// .
		/// This method only returns valid data if the event action is
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// .
		/// </summary>
		/// <returns>The ClipData sent to the system by startDrag().</returns>
		public virtual android.content.ClipData getClipData()
		{
			return mClipData;
		}

		/// <summary>
		/// Returns the
		/// <see cref="android.content.ClipDescription">android.content.ClipDescription</see>
		/// object contained in the
		/// <see cref="android.content.ClipData">android.content.ClipData</see>
		/// object sent to the system as part of the call to
		/// <see cref="View.startDrag(android.content.ClipData, DragShadowBuilder, object, int)
		/// 	">startDrag()</see>
		/// .
		/// The drag handler or listener for a View can use the metadata in this object to decide if the
		/// View can accept the dragged View object's data.
		/// <p>
		/// This method returns valid data for all event actions.
		/// </summary>
		/// <returns>The ClipDescription that was part of the ClipData sent to the system by startDrag().
		/// 	</returns>
		public virtual android.content.ClipDescription getClipDescription()
		{
			return mClipDescription;
		}

		/// <summary>
		/// Returns the local state object sent to the system as part of the call to
		/// <see cref="View.startDrag(android.content.ClipData, DragShadowBuilder, object, int)
		/// 	">startDrag()</see>
		/// .
		/// The object is intended to provide local information about the drag and drop operation. For
		/// example, it can indicate whether the drag and drop operation is a copy or a move.
		/// <p>
		/// This method returns valid data for all event actions.
		/// </p>
		/// </summary>
		/// <returns>The local state object sent to the system by startDrag().</returns>
		public virtual object getLocalState()
		{
			return mLocalState;
		}

		/// <summary>
		/// <p>
		/// Returns an indication of the result of the drag and drop operation.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Returns an indication of the result of the drag and drop operation.
		/// This method only returns valid data if the action type is
		/// <see cref="ACTION_DRAG_ENDED">ACTION_DRAG_ENDED</see>
		/// .
		/// The return value depends on what happens after the user releases the drag shadow.
		/// </p>
		/// <p>
		/// If the user releases the drag shadow on a View that can accept a drop, the system sends an
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// event to the View object's drag event listener. If the listener
		/// returns
		/// <code>true</code>
		/// , then getResult() will return
		/// <code>true</code>
		/// .
		/// If the listener returns
		/// <code>false</code>
		/// , then getResult() returns
		/// <code>false</code>
		/// .
		/// </p>
		/// <p>
		/// Notice that getResult() also returns
		/// <code>false</code>
		/// if no
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// is sent. This
		/// happens, for example, when the user releases the drag shadow over an area outside of the
		/// application. In this case, the system sends out
		/// <see cref="ACTION_DRAG_ENDED">ACTION_DRAG_ENDED</see>
		/// for the current
		/// operation, but never sends out
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// .
		/// </p>
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if a drag event listener returned
		/// <code>true</code>
		/// in response to
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// . If the system did not send
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// before
		/// <see cref="ACTION_DRAG_ENDED">ACTION_DRAG_ENDED</see>
		/// , or if the listener returned
		/// <code>false</code>
		/// in response to
		/// <see cref="ACTION_DROP">ACTION_DROP</see>
		/// , then
		/// <code>false</code>
		/// is returned.
		/// </returns>
		public virtual bool getResult()
		{
			return mDragResult;
		}

		/// <summary>Recycle the DragEvent, to be re-used by a later caller.</summary>
		/// <remarks>
		/// Recycle the DragEvent, to be re-used by a later caller.  After calling
		/// this function you must never touch the event again.
		/// </remarks>
		/// <hide></hide>
		public void recycle()
		{
			// Ensure recycle is only called once!
			if (mRecycled)
			{
				throw new java.lang.RuntimeException(ToString() + " recycled twice!");
			}
			mRecycled = true;
			mClipData = null;
			mClipDescription = null;
			mLocalState = null;
			lock (gRecyclerLock)
			{
				if (gRecyclerUsed < MAX_RECYCLED)
				{
					gRecyclerUsed++;
					mNext = gRecyclerTop;
					gRecyclerTop = this;
				}
			}
		}

		/// <summary>
		/// Returns a string containing a concise, human-readable representation of this DragEvent
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a string containing a concise, human-readable representation of this DragEvent
		/// object.
		/// </remarks>
		/// <returns>A string representation of the DragEvent object.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "DragEvent{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this
				)) + " action=" + mAction + " @ (" + mX + ", " + mY + ") desc=" + mClipDescription
				 + " data=" + mClipData + " local=" + mLocalState + " result=" + mDragResult + "}";
		}

		/// <summary>
		/// Returns information about the
		/// <see cref="android.os.Parcel">android.os.Parcel</see>
		/// representation of this DragEvent
		/// object.
		/// </summary>
		/// <returns>
		/// Information about the
		/// <see cref="android.os.Parcel">android.os.Parcel</see>
		/// representation.
		/// </returns>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		/// <summary>
		/// Creates a
		/// <see cref="android.os.Parcel">android.os.Parcel</see>
		/// object from this DragEvent object.
		/// </summary>
		/// <param name="dest">
		/// A
		/// <see cref="android.os.Parcel">android.os.Parcel</see>
		/// object in which to put the DragEvent object.
		/// </param>
		/// <param name="flags">Flags to store in the Parcel.</param>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			dest.writeInt(mAction);
			dest.writeFloat(mX);
			dest.writeFloat(mY);
			dest.writeInt(mDragResult ? 1 : 0);
			if (mClipData == null)
			{
				dest.writeInt(0);
			}
			else
			{
				dest.writeInt(1);
				mClipData.writeToParcel(dest, flags);
			}
			if (mClipDescription == null)
			{
				dest.writeInt(0);
			}
			else
			{
				dest.writeInt(1);
				mClipDescription.writeToParcel(dest, flags);
			}
		}

		private sealed class _Creator_486 : android.os.ParcelableClass.Creator<android.view.DragEvent
			>
		{
			public _Creator_486()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.DragEvent createFromParcel(android.os.Parcel @in)
			{
				android.view.DragEvent @event = android.view.DragEvent.obtain();
				@event.mAction = @in.readInt();
				@event.mX = @in.readFloat();
				@event.mY = @in.readFloat();
				@event.mDragResult = (@in.readInt() != 0);
				if (@in.readInt() != 0)
				{
					@event.mClipData = android.content.ClipData.CREATOR.createFromParcel(@in);
				}
				if (@in.readInt() != 0)
				{
					@event.mClipDescription = android.content.ClipDescription.CREATOR.createFromParcel
						(@in);
				}
				return @event;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.DragEvent[] newArray(int size)
			{
				return new android.view.DragEvent[size];
			}
		}

		/// <summary>A container for creating a DragEvent from a Parcel.</summary>
		/// <remarks>A container for creating a DragEvent from a Parcel.</remarks>
		public static readonly android.os.ParcelableClass.Creator<android.view.DragEvent>
			 CREATOR = new _Creator_486();
	}
}
