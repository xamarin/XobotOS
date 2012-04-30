using Sharpen;

namespace android.view
{
	/// <summary>Hardware accelerated canvas.</summary>
	/// <remarks>Hardware accelerated canvas.</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public abstract class HardwareCanvas : android.graphics.Canvas
	{
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool isHardwareAccelerated()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void setBitmap(android.graphics.Bitmap bitmap)
		{
			throw new System.NotSupportedException();
		}

		/// <summary>Invoked before any drawing operation is performed in this canvas.</summary>
		/// <remarks>Invoked before any drawing operation is performed in this canvas.</remarks>
		/// <param name="dirty">The dirty rectangle to update, can be null.</param>
		internal abstract void onPreDraw(android.graphics.Rect dirty);

		/// <summary>Invoked after all drawing operation have been performed.</summary>
		/// <remarks>Invoked after all drawing operation have been performed.</remarks>
		internal abstract void onPostDraw();

		/// <summary>Draws the specified display list onto this canvas.</summary>
		/// <remarks>Draws the specified display list onto this canvas.</remarks>
		/// <param name="displayList">The display list to replay.</param>
		/// <param name="width">The width of the display list.</param>
		/// <param name="height">The height of the display list.</param>
		/// <param name="dirty">
		/// The dirty region to redraw in the next pass, matters only
		/// if this method returns true, can be null.
		/// </param>
		/// <returns>
		/// True if the content of the display list requires another
		/// drawing pass (invalidate()), false otherwise
		/// </returns>
		internal abstract bool drawDisplayList(android.view.DisplayList displayList, int 
			width, int height, android.graphics.Rect dirty);

		/// <summary>Outputs the specified display list to the log.</summary>
		/// <remarks>
		/// Outputs the specified display list to the log. This method exists for use by
		/// tools to output display lists for selected nodes to the log.
		/// </remarks>
		/// <param name="displayList">The display list to be logged.</param>
		internal abstract void outputDisplayList(android.view.DisplayList displayList);

		/// <summary>Draws the specified layer onto this canvas.</summary>
		/// <remarks>Draws the specified layer onto this canvas.</remarks>
		/// <param name="layer">The layer to composite on this canvas</param>
		/// <param name="x">The left coordinate of the layer</param>
		/// <param name="y">The top coordinate of the layer</param>
		/// <param name="paint">The paint used to draw the layer</param>
		internal abstract void drawHardwareLayer(android.view.HardwareLayer layer, float 
			x, float y, android.graphics.Paint paint);

		/// <summary>Calls the function specified with the drawGLFunction function pointer.</summary>
		/// <remarks>
		/// Calls the function specified with the drawGLFunction function pointer. This is
		/// functionality used by webkit for calling into their renderer from our display lists.
		/// This function may return true if an invalidation is needed after the call.
		/// </remarks>
		/// <param name="drawGLFunction">A native function pointer</param>
		/// <returns>true if an invalidate is needed after the call, false otherwise</returns>
		public virtual bool callDrawGLFunction(int drawGLFunction)
		{
			// Noop - this is done in the display list recorder subclass
			return false;
		}
	}
}
