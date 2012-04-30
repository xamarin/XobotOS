using Sharpen;

namespace android.view
{
	/// <summary>
	/// A display lists records a series of graphics related operation and can replay
	/// them later.
	/// </summary>
	/// <remarks>
	/// A display lists records a series of graphics related operation and can replay
	/// them later. Display lists are usually built by recording operations on a
	/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
	/// . Replaying the operations from a display list
	/// avoids executing views drawing code on every frame, and is thus much more
	/// efficient.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public abstract class DisplayList
	{
		/// <summary>Starts recording the display list.</summary>
		/// <remarks>
		/// Starts recording the display list. All operations performed on the
		/// returned canvas are recorded and stored in this display list.
		/// </remarks>
		/// <returns>A canvas to record drawing operations.</returns>
		internal abstract android.view.HardwareCanvas start();

		/// <summary>Ends the recording for this display list.</summary>
		/// <remarks>
		/// Ends the recording for this display list. A display list cannot be
		/// replayed if recording is not finished.
		/// </remarks>
		internal abstract void end();

		/// <summary>
		/// Invalidates the display list, indicating that it should be repopulated
		/// with new drawing commands prior to being used again.
		/// </summary>
		/// <remarks>
		/// Invalidates the display list, indicating that it should be repopulated
		/// with new drawing commands prior to being used again. Calling this method
		/// causes calls to
		/// <see cref="isValid()">isValid()</see>
		/// to return <code>false</code>.
		/// </remarks>
		internal abstract void invalidate();

		/// <summary>Returns whether the display list is currently usable.</summary>
		/// <remarks>
		/// Returns whether the display list is currently usable. If this returns false,
		/// the display list should be re-recorded prior to replaying it.
		/// </remarks>
		/// <returns>boolean true if the display list is able to be replayed, false otherwise.
		/// 	</returns>
		internal abstract bool isValid();

		/// <summary>Return the amount of memory used by this display list.</summary>
		/// <remarks>Return the amount of memory used by this display list.</remarks>
		/// <returns>The size of this display list in bytes</returns>
		internal abstract int getSize();
	}
}
