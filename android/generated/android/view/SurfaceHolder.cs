using Sharpen;

namespace android.view
{
	/// <summary>Abstract interface to someone holding a display surface.</summary>
	/// <remarks>
	/// Abstract interface to someone holding a display surface.  Allows you to
	/// control the surface size and format, edit the pixels in the surface, and
	/// monitor changes to the surface.  This interface is typically available
	/// through the
	/// <see cref="SurfaceView">SurfaceView</see>
	/// class.
	/// <p>When using this interface from a thread other than the one running
	/// its
	/// <see cref="SurfaceView">SurfaceView</see>
	/// , you will want to carefully read the
	/// methods
	/// <see cref="lockCanvas()">lockCanvas()</see>
	/// and
	/// <see cref="Callback.surfaceCreated(SurfaceHolder)">Callback.surfaceCreated()</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public interface SurfaceHolder
	{
		/// <summary>Add a Callback interface for this holder.</summary>
		/// <remarks>
		/// Add a Callback interface for this holder.  There can several Callback
		/// interfaces associated with a holder.
		/// </remarks>
		/// <param name="callback">The new Callback interface.</param>
		void addCallback(android.view.SurfaceHolderClass.Callback callback);

		/// <summary>Removes a previously added Callback interface from this holder.</summary>
		/// <remarks>Removes a previously added Callback interface from this holder.</remarks>
		/// <param name="callback">The Callback interface to remove.</param>
		void removeCallback(android.view.SurfaceHolderClass.Callback callback);

		/// <summary>
		/// Use this method to find out if the surface is in the process of being
		/// created from Callback methods.
		/// </summary>
		/// <remarks>
		/// Use this method to find out if the surface is in the process of being
		/// created from Callback methods. This is intended to be used with
		/// <see cref="Callback.surfaceChanged(SurfaceHolder, int, int, int)">Callback.surfaceChanged(SurfaceHolder, int, int, int)
		/// 	</see>
		/// .
		/// </remarks>
		/// <returns>true if the surface is in the process of being created.</returns>
		bool isCreating();

		/// <summary>Sets the surface's type.</summary>
		/// <remarks>Sets the surface's type.</remarks>
		[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
			)]
		void setType(int type);

		/// <summary>Make the surface a fixed size.</summary>
		/// <remarks>
		/// Make the surface a fixed size.  It will never change from this size.
		/// When working with a {link SurfaceView}, this must be called from the
		/// same thread running the SurfaceView's window.
		/// </remarks>
		/// <param name="width">The surface's width.</param>
		/// <param name="height">The surface's height.</param>
		void setFixedSize(int width, int height);

		/// <summary>
		/// Allow the surface to resized based on layout of its container (this is
		/// the default).
		/// </summary>
		/// <remarks>
		/// Allow the surface to resized based on layout of its container (this is
		/// the default).  When this is enabled, you should monitor
		/// <see cref="Callback.surfaceChanged(SurfaceHolder, int, int, int)">Callback.surfaceChanged(SurfaceHolder, int, int, int)
		/// 	</see>
		/// for changes to the size of the surface.
		/// When working with a {link SurfaceView}, this must be called from the
		/// same thread running the SurfaceView's window.
		/// </remarks>
		void setSizeFromLayout();

		/// <summary>Set the desired PixelFormat of the surface.</summary>
		/// <remarks>
		/// Set the desired PixelFormat of the surface.  The default is OPAQUE.
		/// When working with a {link SurfaceView}, this must be called from the
		/// same thread running the SurfaceView's window.
		/// </remarks>
		/// <param name="format">A constant from PixelFormat.</param>
		/// <seealso cref="android.graphics.PixelFormat">android.graphics.PixelFormat</seealso>
		void setFormat(int format);

		/// <summary>
		/// Enable or disable option to keep the screen turned on while this
		/// surface is displayed.
		/// </summary>
		/// <remarks>
		/// Enable or disable option to keep the screen turned on while this
		/// surface is displayed.  The default is false, allowing it to turn off.
		/// This is safe to call from any thread.
		/// </remarks>
		/// <param name="screenOn">
		/// Set to true to force the screen to stay on, false
		/// to allow it to turn off.
		/// </param>
		void setKeepScreenOn(bool screenOn);

		/// <summary>Start editing the pixels in the surface.</summary>
		/// <remarks>
		/// Start editing the pixels in the surface.  The returned Canvas can be used
		/// to draw into the surface's bitmap.  A null is returned if the surface has
		/// not been created or otherwise cannot be edited.  You will usually need
		/// to implement
		/// <see cref="Callback.surfaceCreated(SurfaceHolder)">Callback.surfaceCreated</see>
		/// to find out when the Surface is available for use.
		/// <p>The content of the Surface is never preserved between unlockCanvas() and
		/// lockCanvas(), for this reason, every pixel within the Surface area
		/// must be written. The only exception to this rule is when a dirty
		/// rectangle is specified, in which case, non-dirty pixels will be
		/// preserved.
		/// <p>If you call this repeatedly when the Surface is not ready (before
		/// <see cref="Callback.surfaceCreated(SurfaceHolder)">Callback.surfaceCreated</see>
		/// or after
		/// <see cref="Callback.surfaceDestroyed(SurfaceHolder)">Callback.surfaceDestroyed</see>
		/// ), your calls
		/// will be throttled to a slow rate in order to avoid consuming CPU.
		/// <p>If null is not returned, this function internally holds a lock until
		/// the corresponding
		/// <see cref="unlockCanvasAndPost(android.graphics.Canvas)">unlockCanvasAndPost(android.graphics.Canvas)
		/// 	</see>
		/// call, preventing
		/// <see cref="SurfaceView">SurfaceView</see>
		/// from creating, destroying, or modifying the surface
		/// while it is being drawn.  This can be more convenient than accessing
		/// the Surface directly, as you do not need to do special synchronization
		/// with a drawing thread in
		/// <see cref="Callback.surfaceDestroyed(SurfaceHolder)">Callback.surfaceDestroyed</see>
		/// .
		/// </remarks>
		/// <returns>Canvas Use to draw into the surface.</returns>
		android.graphics.Canvas lockCanvas();

		/// <summary>
		/// Just like
		/// <see cref="lockCanvas()">lockCanvas()</see>
		/// but allows specification of a dirty rectangle.
		/// Every
		/// pixel within that rectangle must be written; however pixels outside
		/// the dirty rectangle will be preserved by the next call to lockCanvas().
		/// </summary>
		/// <seealso cref="lockCanvas()">lockCanvas()</seealso>
		/// <param name="dirty">Area of the Surface that will be modified.</param>
		/// <returns>Canvas Use to draw into the surface.</returns>
		android.graphics.Canvas lockCanvas(android.graphics.Rect dirty);

		/// <summary>Finish editing pixels in the surface.</summary>
		/// <remarks>
		/// Finish editing pixels in the surface.  After this call, the surface's
		/// current pixels will be shown on the screen, but its content is lost,
		/// in particular there is no guarantee that the content of the Surface
		/// will remain unchanged when lockCanvas() is called again.
		/// </remarks>
		/// <seealso cref="lockCanvas()">lockCanvas()</seealso>
		/// <param name="canvas">The Canvas previously returned by lockCanvas().</param>
		void unlockCanvasAndPost(android.graphics.Canvas canvas);

		/// <summary>Retrieve the current size of the surface.</summary>
		/// <remarks>
		/// Retrieve the current size of the surface.  Note: do not modify the
		/// returned Rect.  This is only safe to call from the thread of
		/// <see cref="SurfaceView">SurfaceView</see>
		/// 's window, or while inside of
		/// <see cref="lockCanvas()">lockCanvas()</see>
		/// .
		/// </remarks>
		/// <returns>Rect The surface's dimensions.  The left and top are always 0.</returns>
		android.graphics.Rect getSurfaceFrame();

		/// <summary>Direct access to the surface object.</summary>
		/// <remarks>
		/// Direct access to the surface object.  The Surface may not always be
		/// available -- for example when using a
		/// <see cref="SurfaceView">SurfaceView</see>
		/// the holder's
		/// Surface is not created until the view has been attached to the window
		/// manager and performed a layout in order to determine the dimensions
		/// and screen position of the Surface.    You will thus usually need
		/// to implement
		/// <see cref="Callback.surfaceCreated(SurfaceHolder)">Callback.surfaceCreated</see>
		/// to find out when the Surface is available for use.
		/// <p>Note that if you directly access the Surface from another thread,
		/// it is critical that you correctly implement
		/// <see cref="Callback.surfaceCreated(SurfaceHolder)">Callback.surfaceCreated</see>
		/// and
		/// <see cref="Callback.surfaceDestroyed(SurfaceHolder)">Callback.surfaceDestroyed</see>
		/// to ensure
		/// that thread only accesses the Surface while it is valid, and that the
		/// Surface does not get destroyed while the thread is using it.
		/// <p>This method is intended to be used by frameworks which often need
		/// direct access to the Surface object (usually to pass it to native code).
		/// When designing APIs always use SurfaceHolder to pass surfaces around
		/// as opposed to the Surface object itself. A rule of thumb is that
		/// application code should never have to call this method.
		/// </remarks>
		/// <returns>Surface The surface.</returns>
		android.view.Surface getSurface();
	}

	/// <summary>Abstract interface to someone holding a display surface.</summary>
	/// <remarks>
	/// Abstract interface to someone holding a display surface.  Allows you to
	/// control the surface size and format, edit the pixels in the surface, and
	/// monitor changes to the surface.  This interface is typically available
	/// through the
	/// <see cref="SurfaceView">SurfaceView</see>
	/// class.
	/// <p>When using this interface from a thread other than the one running
	/// its
	/// <see cref="SurfaceView">SurfaceView</see>
	/// , you will want to carefully read the
	/// methods
	/// <see cref="lockCanvas()">lockCanvas()</see>
	/// and
	/// <see cref="Callback.surfaceCreated(SurfaceHolder)">Callback.surfaceCreated()</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public static class SurfaceHolderClass
	{
		[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
			)]
		public const int SURFACE_TYPE_NORMAL = 0;

		[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
			)]
		public const int SURFACE_TYPE_HARDWARE = 1;

		[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
			)]
		public const int SURFACE_TYPE_GPU = 2;

		[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
			)]
		public const int SURFACE_TYPE_PUSH_BUFFERS = 3;

		/// <summary>
		/// Exception that is thrown from
		/// <see cref="#lockCanvas">#lockCanvas</see>
		/// when called on a Surface
		/// whose type is SURFACE_TYPE_PUSH_BUFFERS.
		/// </summary>
		[System.Serializable]
		public class BadSurfaceTypeException : java.lang.RuntimeException
		{
			public BadSurfaceTypeException()
			{
			}

			public BadSurfaceTypeException(string name) : base(name)
			{
			}
		}

		/// <summary>
		/// A client may implement this interface to receive information about
		/// changes to the surface.
		/// </summary>
		/// <remarks>
		/// A client may implement this interface to receive information about
		/// changes to the surface.  When used with a
		/// <see cref="SurfaceView">SurfaceView</see>
		/// , the
		/// Surface being held is only available between calls to
		/// <see cref="surfaceCreated(SurfaceHolder)">surfaceCreated(SurfaceHolder)</see>
		/// and
		/// <see cref="surfaceDestroyed(SurfaceHolder)">surfaceDestroyed(SurfaceHolder)</see>
		/// .  The Callback is set with
		/// <see cref="SurfaceHolder.addCallback(Callback)">SurfaceHolder.addCallback</see>
		/// method.
		/// </remarks>
		public interface Callback
		{
			/// <summary>This is called immediately after the surface is first created.</summary>
			/// <remarks>
			/// This is called immediately after the surface is first created.
			/// Implementations of this should start up whatever rendering code
			/// they desire.  Note that only one thread can ever draw into
			/// a
			/// <see cref="Surface">Surface</see>
			/// , so you should not draw into the Surface here
			/// if your normal rendering will be in another thread.
			/// </remarks>
			/// <param name="holder">The SurfaceHolder whose surface is being created.</param>
			void surfaceCreated(android.view.SurfaceHolder holder);

			/// <summary>
			/// This is called immediately after any structural changes (format or
			/// size) have been made to the surface.
			/// </summary>
			/// <remarks>
			/// This is called immediately after any structural changes (format or
			/// size) have been made to the surface.  You should at this point update
			/// the imagery in the surface.  This method is always called at least
			/// once, after
			/// <see cref="surfaceCreated(SurfaceHolder)">surfaceCreated(SurfaceHolder)</see>
			/// .
			/// </remarks>
			/// <param name="holder">The SurfaceHolder whose surface has changed.</param>
			/// <param name="format">The new PixelFormat of the surface.</param>
			/// <param name="width">The new width of the surface.</param>
			/// <param name="height">The new height of the surface.</param>
			void surfaceChanged(android.view.SurfaceHolder holder, int format, int width, int
				 height);

			/// <summary>This is called immediately before a surface is being destroyed.</summary>
			/// <remarks>
			/// This is called immediately before a surface is being destroyed. After
			/// returning from this call, you should no longer try to access this
			/// surface.  If you have a rendering thread that directly accesses
			/// the surface, you must ensure that thread is no longer touching the
			/// Surface before returning from this function.
			/// </remarks>
			/// <param name="holder">The SurfaceHolder whose surface is being destroyed.</param>
			void surfaceDestroyed(android.view.SurfaceHolder holder);
		}

		/// <summary>
		/// Additional callbacks that can be received for
		/// <see cref="Callback">Callback</see>
		/// .
		/// </summary>
		public interface Callback2 : android.view.SurfaceHolderClass.Callback
		{
			/// <summary>
			/// Called when the application needs to redraw the content of its
			/// surface, after it is resized or for some other reason.
			/// </summary>
			/// <remarks>
			/// Called when the application needs to redraw the content of its
			/// surface, after it is resized or for some other reason.  By not
			/// returning from here until the redraw is complete, you can ensure that
			/// the user will not see your surface in a bad state (at its new
			/// size before it has been correctly drawn that way).  This will
			/// typically be preceeded by a call to
			/// <see cref="Callback.surfaceChanged(SurfaceHolder, int, int, int)">Callback.surfaceChanged(SurfaceHolder, int, int, int)
			/// 	</see>
			/// .
			/// </remarks>
			/// <param name="holder">The SurfaceHolder whose surface has changed.</param>
			void surfaceRedrawNeeded(android.view.SurfaceHolder holder);
		}
	}
}
