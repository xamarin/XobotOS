using Sharpen;

namespace android.view
{
	/// <summary>
	/// A hardware layer can be used to render graphics operations into a hardware
	/// friendly buffer.
	/// </summary>
	/// <remarks>
	/// A hardware layer can be used to render graphics operations into a hardware
	/// friendly buffer. For instance, with an OpenGL backend, a hardware layer
	/// would use a Frame Buffer Object (FBO.) The hardware layer can be used as
	/// a drawing cache when a complex set of graphics operations needs to be
	/// drawn several times.
	/// </remarks>
	[Sharpen.Sharpened]
	internal abstract class HardwareLayer
	{
		/// <summary>Indicates an unknown dimension (width or height.)</summary>
		internal const int DIMENSION_UNDEFINED = -1;

		internal int mWidth;

		internal int mHeight;

		internal bool mOpaque;

		/// <summary>Creates a new hardware layer with undefined dimensions.</summary>
		/// <remarks>Creates a new hardware layer with undefined dimensions.</remarks>
		internal HardwareLayer() : this(DIMENSION_UNDEFINED, DIMENSION_UNDEFINED, false)
		{
		}

		/// <summary>
		/// Creates a new hardware layer at least as large as the supplied
		/// dimensions.
		/// </summary>
		/// <remarks>
		/// Creates a new hardware layer at least as large as the supplied
		/// dimensions.
		/// </remarks>
		/// <param name="width">The minimum width of the layer</param>
		/// <param name="height">The minimum height of the layer</param>
		/// <param name="isOpaque">Whether the layer should be opaque or not</param>
		internal HardwareLayer(int width, int height, bool isOpaque_1)
		{
			mWidth = width;
			mHeight = height;
			mOpaque = isOpaque_1;
		}

		/// <summary>Returns the minimum width of the layer.</summary>
		/// <remarks>Returns the minimum width of the layer.</remarks>
		/// <returns>The minimum desired width of the hardware layer</returns>
		internal virtual int getWidth()
		{
			return mWidth;
		}

		/// <summary>Returns the minimum height of the layer.</summary>
		/// <remarks>Returns the minimum height of the layer.</remarks>
		/// <returns>The minimum desired height of the hardware layer</returns>
		internal virtual int getHeight()
		{
			return mHeight;
		}

		/// <summary>Returns whether or not this layer is opaque.</summary>
		/// <remarks>Returns whether or not this layer is opaque.</remarks>
		/// <returns>True if the layer is opaque, false otherwise</returns>
		internal virtual bool isOpaque()
		{
			return mOpaque;
		}

		/// <summary>Indicates whether this layer can be rendered.</summary>
		/// <remarks>Indicates whether this layer can be rendered.</remarks>
		/// <returns>True if the layer can be rendered into, false otherwise</returns>
		internal abstract bool isValid();

		/// <summary>
		/// Resize the layer, if necessary, to be at least as large
		/// as the supplied dimensions.
		/// </summary>
		/// <remarks>
		/// Resize the layer, if necessary, to be at least as large
		/// as the supplied dimensions.
		/// </remarks>
		/// <param name="width">The new desired minimum width for this layer</param>
		/// <param name="height">The new desired minimum height for this layer</param>
		internal abstract void resize(int width, int height);

		/// <summary>
		/// Returns a hardware canvas that can be used to render onto
		/// this layer.
		/// </summary>
		/// <remarks>
		/// Returns a hardware canvas that can be used to render onto
		/// this layer.
		/// </remarks>
		/// <returns>A hardware canvas, or null if a canvas cannot be created</returns>
		internal abstract android.view.HardwareCanvas getCanvas();

		/// <summary>Destroys resources without waiting for a GC.</summary>
		/// <remarks>Destroys resources without waiting for a GC.</remarks>
		internal abstract void destroy();

		/// <summary>This must be invoked before drawing onto this layer.</summary>
		/// <remarks>This must be invoked before drawing onto this layer.</remarks>
		/// <param name="currentCanvas"></param>
		internal abstract android.view.HardwareCanvas start(android.graphics.Canvas currentCanvas
			);

		/// <summary>This must be invoked after drawing onto this layer.</summary>
		/// <remarks>This must be invoked after drawing onto this layer.</remarks>
		/// <param name="currentCanvas"></param>
		internal abstract void end(android.graphics.Canvas currentCanvas);

		/// <summary>Copies this layer into the specified bitmap.</summary>
		/// <remarks>Copies this layer into the specified bitmap.</remarks>
		/// <param name="bitmap">The bitmap to copy they layer into</param>
		/// <returns>True if the copy was successful, false otherwise</returns>
		internal abstract bool copyInto(android.graphics.Bitmap bitmap);

		/// <summary>Update the layer's properties.</summary>
		/// <remarks>
		/// Update the layer's properties. This method should be used
		/// when the underlying storage is modified by an external entity.
		/// To change the underlying storage, use the
		/// <see cref="resize(int, int)">resize(int, int)</see>
		/// method instead.
		/// </remarks>
		/// <param name="width">The new width of this layer</param>
		/// <param name="height">The new height of this layer</param>
		/// <param name="isOpaque">Whether this layer is opaque</param>
		internal virtual void update(int width, int height, bool isOpaque_1)
		{
			mWidth = width;
			mHeight = height;
			mOpaque = isOpaque_1;
		}

		/// <summary>Sets an optional transform on this layer.</summary>
		/// <remarks>Sets an optional transform on this layer.</remarks>
		/// <param name="matrix">The transform to apply to the layer.</param>
		internal abstract void setTransform(android.graphics.Matrix matrix);
	}
}
