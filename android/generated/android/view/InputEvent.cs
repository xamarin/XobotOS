using Sharpen;

namespace android.view
{
	/// <summary>Common base class for input events.</summary>
	/// <remarks>Common base class for input events.</remarks>
	[Sharpen.Sharpened]
	public abstract class InputEvent : android.os.Parcelable
	{
		/// <hide></hide>
		internal const int PARCEL_TOKEN_MOTION_EVENT = 1;

		/// <hide></hide>
		internal const int PARCEL_TOKEN_KEY_EVENT = 2;

		internal InputEvent()
		{
		}

		/// <summary>Gets the id for the device that this event came from.</summary>
		/// <remarks>
		/// Gets the id for the device that this event came from.  An id of
		/// zero indicates that the event didn't come from a physical device
		/// and maps to the default keymap.  The other numbers are arbitrary and
		/// you shouldn't depend on the values.
		/// </remarks>
		/// <returns>The device id.</returns>
		/// <seealso cref="InputDevice.getDevice(int)">InputDevice.getDevice(int)</seealso>
		public abstract int getDeviceId();

		/// <summary>Gets the device that this event came from.</summary>
		/// <remarks>Gets the device that this event came from.</remarks>
		/// <returns>The device, or null if unknown.</returns>
		public android.view.InputDevice getDevice()
		{
			return android.view.InputDevice.getDevice(getDeviceId());
		}

		/// <summary>Gets the source of the event.</summary>
		/// <remarks>Gets the source of the event.</remarks>
		/// <returns>
		/// The event source or
		/// <see cref="InputDevice.SOURCE_UNKNOWN">InputDevice.SOURCE_UNKNOWN</see>
		/// if unknown.
		/// </returns>
		/// <seealso cref="InputDevice#getSourceInfo">InputDevice#getSourceInfo</seealso>
		public abstract int getSource();

		/// <summary>Modifies the source of the event.</summary>
		/// <remarks>Modifies the source of the event.</remarks>
		/// <param name="source">The new source.</param>
		/// <hide></hide>
		public abstract void setSource(int source);

		/// <summary>Copies the event.</summary>
		/// <remarks>Copies the event.</remarks>
		/// <returns>A deep copy of the event.</returns>
		/// <hide></hide>
		public abstract android.view.InputEvent copy();

		/// <summary>Recycles the event.</summary>
		/// <remarks>
		/// Recycles the event.
		/// This method should only be used by the system since applications do not
		/// expect
		/// <see cref="KeyEvent">KeyEvent</see>
		/// objects to be recycled, although
		/// <see cref="MotionEvent">MotionEvent</see>
		/// objects are fine.  See
		/// <see cref="KeyEvent.recycle()">KeyEvent.recycle()</see>
		/// for details.
		/// </remarks>
		/// <hide></hide>
		public abstract void recycle();

		/// <summary>
		/// Gets a private flag that indicates when the system has detected that this input event
		/// may be inconsistent with respect to the sequence of previously delivered input events,
		/// such as when a key up event is sent but the key was not down or when a pointer
		/// move event is sent but the pointer is not down.
		/// </summary>
		/// <remarks>
		/// Gets a private flag that indicates when the system has detected that this input event
		/// may be inconsistent with respect to the sequence of previously delivered input events,
		/// such as when a key up event is sent but the key was not down or when a pointer
		/// move event is sent but the pointer is not down.
		/// </remarks>
		/// <returns>True if this event is tainted.</returns>
		/// <hide></hide>
		public abstract bool isTainted();

		/// <summary>
		/// Sets a private flag that indicates when the system has detected that this input event
		/// may be inconsistent with respect to the sequence of previously delivered input events,
		/// such as when a key up event is sent but the key was not down or when a pointer
		/// move event is sent but the pointer is not down.
		/// </summary>
		/// <remarks>
		/// Sets a private flag that indicates when the system has detected that this input event
		/// may be inconsistent with respect to the sequence of previously delivered input events,
		/// such as when a key up event is sent but the key was not down or when a pointer
		/// move event is sent but the pointer is not down.
		/// </remarks>
		/// <param name="tainted">True if this event is tainted.</param>
		/// <hide></hide>
		public abstract void setTainted(bool tainted);

		/// <summary>Returns the time (in ns) when this specific event was generated.</summary>
		/// <remarks>
		/// Returns the time (in ns) when this specific event was generated.
		/// The value is in nanosecond precision but it may not have nanosecond accuracy.
		/// </remarks>
		/// <hide></hide>
		public abstract long getEventTimeNano();

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		private sealed class _Creator_121 : android.os.ParcelableClass.Creator<android.view.InputEvent
			>
		{
			public _Creator_121()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.InputEvent createFromParcel(android.os.Parcel @in)
			{
				int token = @in.readInt();
				if (token == android.view.InputEvent.PARCEL_TOKEN_KEY_EVENT)
				{
					return android.view.KeyEvent.createFromParcelBody(@in);
				}
				else
				{
					if (token == android.view.InputEvent.PARCEL_TOKEN_MOTION_EVENT)
					{
						return android.view.MotionEvent.createFromParcelBody(@in);
					}
					else
					{
						throw new System.InvalidOperationException("Unexpected input event type token in parcel."
							);
					}
				}
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.InputEvent[] newArray(int size)
			{
				return new android.view.InputEvent[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.InputEvent
			> CREATOR = new _Creator_121();

		public abstract void writeToParcel(android.os.Parcel arg1, int arg2);
	}
}
