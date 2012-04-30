using Sharpen;

namespace android.view
{
	/// <summary><p>A TextureView can be used to display a content stream.</summary>
	/// <remarks>
	/// <p>A TextureView can be used to display a content stream. Such a content
	/// stream can for instance be a video or an OpenGL scene. The content stream
	/// can come from the application's process as well as a remote process.</p>
	/// <p>TextureView can only be used in a hardware accelerated window. When
	/// rendered in software, TextureView will draw nothing.</p>
	/// <p>Unlike
	/// <see cref="SurfaceView">SurfaceView</see>
	/// , TextureView does not create a separate
	/// window but behaves as a regular View. This key difference allows a
	/// TextureView to be moved, transformed, animated, etc. For instance, you
	/// can make a TextureView semi-translucent by calling
	/// <code>myView.setAlpha(0.5f)</code>.</p>
	/// <p>Using a TextureView is simple: all you need to do is get its
	/// <see cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</see>
	/// . The
	/// <see cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</see>
	/// can then be used to
	/// render content. The following example demonstrates how to render the
	/// camera preview into a TextureView:</p>
	/// <pre>
	/// public class LiveCameraActivity extends Activity implements TextureView.SurfaceTextureListener {
	/// private Camera mCamera;
	/// private TextureView mTextureView;
	/// protected void onCreate(Bundle savedInstanceState) {
	/// super.onCreate(savedInstanceState);
	/// mTextureView = new TextureView(this);
	/// mTextureView.setSurfaceTextureListener(this);
	/// setContentView(mTextureView);
	/// }
	/// public void onSurfaceTextureAvailable(SurfaceTexture surface, int width, int height) {
	/// mCamera = Camera.open();
	/// try {
	/// mCamera.setPreviewTexture(surface);
	/// mCamera.startPreview();
	/// } catch (IOException ioe) {
	/// // Something bad happened
	/// }
	/// }
	/// public void onSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height) {
	/// // Ignored, Camera does all the work for us
	/// }
	/// public boolean onSurfaceTextureDestroyed(SurfaceTexture surface) {
	/// mCamera.stopPreview();
	/// mCamera.release();
	/// return true;
	/// }
	/// public void onSurfaceTextureUpdated(SurfaceTexture surface) {
	/// // Invoked every time there's a new Camera preview frame
	/// }
	/// }
	/// </pre>
	/// <p>A TextureView's SurfaceTexture can be obtained either by invoking
	/// <see cref="getSurfaceTexture()">getSurfaceTexture()</see>
	/// or by using a
	/// <see cref="SurfaceTextureListener">SurfaceTextureListener</see>
	/// .
	/// It is important to know that a SurfaceTexture is available only after the
	/// TextureView is attached to a window (and
	/// <see cref="onAttachedToWindow()">onAttachedToWindow()</see>
	/// has
	/// been invoked.) It is therefore highly recommended you use a listener to
	/// be notified when the SurfaceTexture becomes available.</p>
	/// <p>It is important to note that only one producer can use the TextureView.
	/// For instance, if you use a TextureView to display the camera preview, you
	/// cannot use
	/// <see cref="lockCanvas()">lockCanvas()</see>
	/// to draw onto the TextureView at the same
	/// time.</p>
	/// </remarks>
	/// <seealso cref="SurfaceView">SurfaceView</seealso>
	/// <seealso cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</seealso>
	[Sharpen.Sharpened]
	public class TextureView : android.view.View
	{
		internal const string LOG_TAG = "TextureView";

		private android.view.HardwareLayer mLayer;

		private android.graphics.SurfaceTexture mSurface;

		private android.view.TextureView.SurfaceTextureListener mListener;

		private bool mOpaque = true;

		private readonly android.graphics.Matrix mMatrix = new android.graphics.Matrix();

		private bool mMatrixChanged;

		private readonly object[] mLock = new object[0];

		private bool mUpdateLayer;

		private android.graphics.SurfaceTexture.OnFrameAvailableListener mUpdateListener;

		private android.graphics.Canvas mCanvas;

		private int mSaveCount;

		private readonly object[] mNativeWindowLock = new object[0];

		private int mNativeWindow;

		/// <summary>Creates a new TextureView.</summary>
		/// <remarks>Creates a new TextureView.</remarks>
		/// <param name="context">The context to associate this view with.</param>
		public TextureView(android.content.Context context) : base(context)
		{
			// Used from native code, do not write!
			init();
		}

		/// <summary>Creates a new TextureView.</summary>
		/// <remarks>Creates a new TextureView.</remarks>
		/// <param name="context">The context to associate this view with.</param>
		/// <param name="attrs">The attributes of the XML tag that is inflating the view.</param>
		public TextureView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			init();
		}

		/// <summary>Creates a new TextureView.</summary>
		/// <remarks>Creates a new TextureView.</remarks>
		/// <param name="context">The context to associate this view with.</param>
		/// <param name="attrs">The attributes of the XML tag that is inflating the view.</param>
		/// <param name="defStyle">
		/// The default style to apply to this view. If 0, no style
		/// will be applied (beyond what is included in the theme). This may
		/// either be an attribute resource, whose value will be retrieved
		/// from the current theme, or an explicit style resource.
		/// </param>
		public TextureView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			init();
		}

		private void init()
		{
			mLayerPaint = new android.graphics.Paint();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool isOpaque()
		{
			return mOpaque;
		}

		/// <summary>Indicates whether the content of this TextureView is opaque.</summary>
		/// <remarks>
		/// Indicates whether the content of this TextureView is opaque. The
		/// content is assumed to be opaque by default.
		/// </remarks>
		/// <param name="opaque">
		/// True if the content of this TextureView is opaque,
		/// false otherwise
		/// </param>
		public virtual void setOpaque(bool opaque)
		{
			if (opaque != mOpaque)
			{
				mOpaque = opaque;
				updateLayer();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			if (!isHardwareAccelerated())
			{
				android.util.Log.w(LOG_TAG, "A TextureView or a subclass can only be " + "used with hardware acceleration enabled."
					);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			if (mLayer != null)
			{
				bool shouldRelease = true;
				if (mListener != null)
				{
					shouldRelease = mListener.onSurfaceTextureDestroyed(mSurface);
				}
				lock (mNativeWindowLock)
				{
					nDestroyNativeWindow();
				}
				mLayer.destroy();
				if (shouldRelease)
				{
					mSurface.release();
				}
				mSurface = null;
				mLayer = null;
			}
		}

		/// <summary>
		/// The layer type of a TextureView is ignored since a TextureView is always
		/// considered to act as a hardware layer.
		/// </summary>
		/// <remarks>
		/// The layer type of a TextureView is ignored since a TextureView is always
		/// considered to act as a hardware layer. The optional paint supplied to this
		/// method will however be taken into account when rendering the content of
		/// this TextureView.
		/// </remarks>
		/// <param name="layerType">
		/// The ype of layer to use with this view, must be one of
		/// <see cref="View.LAYER_TYPE_NONE">View.LAYER_TYPE_NONE</see>
		/// ,
		/// <see cref="View.LAYER_TYPE_SOFTWARE">View.LAYER_TYPE_SOFTWARE</see>
		/// or
		/// <see cref="View.LAYER_TYPE_HARDWARE">View.LAYER_TYPE_HARDWARE</see>
		/// </param>
		/// <param name="paint">
		/// The paint used to compose the layer. This argument is optional
		/// and can be null. It is ignored when the layer type is
		/// <see cref="View.LAYER_TYPE_NONE">View.LAYER_TYPE_NONE</see>
		/// </param>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setLayerType(int layerType, android.graphics.Paint paint)
		{
			if (paint != mLayerPaint)
			{
				mLayerPaint = paint;
				invalidate();
			}
		}

		/// <summary>
		/// Always returns
		/// <see cref="View.LAYER_TYPE_HARDWARE">View.LAYER_TYPE_HARDWARE</see>
		/// .
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getLayerType()
		{
			return LAYER_TYPE_HARDWARE;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override bool hasStaticLayer()
		{
			return true;
		}

		/// <summary>Calling this method has no effect.</summary>
		/// <remarks>Calling this method has no effect.</remarks>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void buildLayer()
		{
		}

		/// <summary>
		/// Subclasses of TextureView cannot do their own rendering
		/// with the
		/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
		/// object.
		/// </summary>
		/// <param name="canvas">The Canvas to which the View is rendered.</param>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public sealed override void draw(android.graphics.Canvas canvas)
		{
			applyUpdate();
			applyTransformMatrix();
		}

		/// <summary>
		/// Subclasses of TextureView cannot do their own rendering
		/// with the
		/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
		/// object.
		/// </summary>
		/// <param name="canvas">The Canvas to which the View is rendered.</param>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal sealed override void onDraw(android.graphics.Canvas canvas)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.onSizeChanged(w, h, oldw, oldh);
			if (mSurface != null)
			{
				nSetDefaultBufferSize(mSurface, getWidth(), getHeight());
				if (mListener != null)
				{
					mListener.onSurfaceTextureSizeChanged(mSurface, getWidth(), getHeight());
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override bool destroyLayer()
		{
			return false;
		}

		private sealed class _OnFrameAvailableListener_315 : android.graphics.SurfaceTexture
			.OnFrameAvailableListener
		{
			public _OnFrameAvailableListener_315(TextureView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.graphics.SurfaceTexture.OnFrameAvailableListener"
				)]
			public void onFrameAvailable(android.graphics.SurfaceTexture surfaceTexture)
			{
				// Per SurfaceTexture's documentation, the callback may be invoked
				// from an arbitrary thread
				lock (this._enclosing.mLock)
				{
					this._enclosing.mUpdateLayer = true;
				}
				this._enclosing.postInvalidateDelayed(0);
			}

			private readonly TextureView _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override android.view.HardwareLayer getHardwareLayer()
		{
			if (mLayer == null)
			{
				if (mAttachInfo == null || mAttachInfo.mHardwareRenderer == null)
				{
					return null;
				}
				mLayer = mAttachInfo.mHardwareRenderer.createHardwareLayer(mOpaque);
				mSurface = mAttachInfo.mHardwareRenderer.createSurfaceTexture(mLayer);
				nSetDefaultBufferSize(mSurface, getWidth(), getHeight());
				nCreateNativeWindow(mSurface);
				mUpdateListener = new _OnFrameAvailableListener_315(this);
				mSurface.setOnFrameAvailableListener(mUpdateListener);
				if (mListener != null)
				{
					mListener.onSurfaceTextureAvailable(mSurface, getWidth(), getHeight());
				}
			}
			applyUpdate();
			applyTransformMatrix();
			return mLayer;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onVisibilityChanged(android.view.View changedView
			, int visibility)
		{
			base.onVisibilityChanged(changedView, visibility);
			if (mSurface != null)
			{
				// When the view becomes invisible, stop updating it, it's a waste of CPU
				// To cancel updates, the easiest thing to do is simply to remove the
				// updates listener
				if (visibility == VISIBLE)
				{
					mSurface.setOnFrameAvailableListener(mUpdateListener);
					updateLayer();
				}
				else
				{
					mSurface.setOnFrameAvailableListener(null);
				}
			}
		}

		private void updateLayer()
		{
			mUpdateLayer = true;
			invalidate();
		}

		private void applyUpdate()
		{
			if (mLayer == null)
			{
				return;
			}
			lock (mLock)
			{
				if (mUpdateLayer)
				{
					mUpdateLayer = false;
				}
				else
				{
					return;
				}
			}
			mLayer.update(getWidth(), getHeight(), mOpaque);
			if (mListener != null)
			{
				mListener.onSurfaceTextureUpdated(mSurface);
			}
		}

		/// <summary><p>Sets the transform to associate with this texture view.</summary>
		/// <remarks>
		/// <p>Sets the transform to associate with this texture view.
		/// The specified transform applies to the underlying surface
		/// texture and does not affect the size or position of the view
		/// itself, only of its content.</p>
		/// <p>Some transforms might prevent the content from drawing
		/// all the pixels contained within this view's bounds. In such
		/// situations, make sure this texture view is not marked opaque.</p>
		/// </remarks>
		/// <param name="transform">
		/// The transform to apply to the content of
		/// this view.
		/// </param>
		/// <seealso cref="getTransform(android.graphics.Matrix)"></seealso>
		/// <seealso cref="isOpaque()"></seealso>
		/// <seealso cref="setOpaque(bool)"></seealso>
		public virtual void setTransform(android.graphics.Matrix transform)
		{
			mMatrix.set(transform);
			mMatrixChanged = true;
			invalidateParentIfNeeded();
		}

		/// <summary>Returns the transform associated with this texture view.</summary>
		/// <remarks>Returns the transform associated with this texture view.</remarks>
		/// <param name="transform">
		/// The
		/// <see cref="android.graphics.Matrix">android.graphics.Matrix</see>
		/// in which to copy the current
		/// transform. Can be null.
		/// </param>
		/// <returns>
		/// The specified matrix if not null or a new
		/// <see cref="android.graphics.Matrix">android.graphics.Matrix</see>
		/// instance otherwise.
		/// </returns>
		/// <seealso cref="setTransform(android.graphics.Matrix)"></seealso>
		public virtual android.graphics.Matrix getTransform(android.graphics.Matrix transform
			)
		{
			if (transform == null)
			{
				transform = new android.graphics.Matrix();
			}
			transform.set(mMatrix);
			return transform;
		}

		private void applyTransformMatrix()
		{
			if (mMatrixChanged)
			{
				mLayer.setTransform(mMatrix);
				mMatrixChanged = false;
			}
		}

		/// <summary>
		/// <p>Returns a
		/// <see cref="android.graphics.Bitmap">android.graphics.Bitmap</see>
		/// representation of the content
		/// of the associated surface texture. If the surface texture is not available,
		/// this method returns null.</p>
		/// <p>The bitmap returned by this method uses the
		/// <see cref="android.graphics.Bitmap.Config.ARGB_8888">android.graphics.Bitmap.Config.ARGB_8888
		/// 	</see>
		/// pixel format and its dimensions are the same as this view's.</p>
		/// <p><strong>Do not</strong> invoke this method from a drawing method
		/// (
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// for instance).</p>
		/// <p>If an error occurs during the copy, an empty bitmap will be returned.</p>
		/// </summary>
		/// <returns>
		/// A valid
		/// <see cref="android.graphics.Bitmap.Config.ARGB_8888">android.graphics.Bitmap.Config.ARGB_8888
		/// 	</see>
		/// bitmap, or null if the surface
		/// texture is not available or the width &lt;= 0 or the height &lt;= 0
		/// </returns>
		/// <seealso cref="isAvailable()"></seealso>
		/// <seealso cref="getBitmap(android.graphics.Bitmap)"></seealso>
		/// <seealso cref="getBitmap(int, int)"></seealso>
		public virtual android.graphics.Bitmap getBitmap()
		{
			return getBitmap(getWidth(), getHeight());
		}

		/// <summary>
		/// <p>Returns a
		/// <see cref="android.graphics.Bitmap">android.graphics.Bitmap</see>
		/// representation of the content
		/// of the associated surface texture. If the surface texture is not available,
		/// this method returns null.</p>
		/// <p>The bitmap returned by this method uses the
		/// <see cref="android.graphics.Bitmap.Config.ARGB_8888">android.graphics.Bitmap.Config.ARGB_8888
		/// 	</see>
		/// pixel format.</p>
		/// <p><strong>Do not</strong> invoke this method from a drawing method
		/// (
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// for instance).</p>
		/// <p>If an error occurs during the copy, an empty bitmap will be returned.</p>
		/// </summary>
		/// <param name="width">The width of the bitmap to create</param>
		/// <param name="height">The height of the bitmap to create</param>
		/// <returns>
		/// A valid
		/// <see cref="android.graphics.Bitmap.Config.ARGB_8888">android.graphics.Bitmap.Config.ARGB_8888
		/// 	</see>
		/// bitmap, or null if the surface
		/// texture is not available or width is &lt;= 0 or height is &lt;= 0
		/// </returns>
		/// <seealso cref="isAvailable()"></seealso>
		/// <seealso cref="getBitmap(android.graphics.Bitmap)"></seealso>
		/// <seealso cref="getBitmap()"></seealso>
		public virtual android.graphics.Bitmap getBitmap(int width, int height)
		{
			if (isAvailable() && width > 0 && height > 0)
			{
				return getBitmap(android.graphics.Bitmap.createBitmap(width, height, android.graphics.Bitmap.Config
					.ARGB_8888));
			}
			return null;
		}

		/// <summary>
		/// <p>Copies the content of this view's surface texture into the specified
		/// bitmap.
		/// </summary>
		/// <remarks>
		/// <p>Copies the content of this view's surface texture into the specified
		/// bitmap. If the surface texture is not available, the copy is not executed.
		/// The content of the surface texture will be scaled to fit exactly inside
		/// the specified bitmap.</p>
		/// <p><strong>Do not</strong> invoke this method from a drawing method
		/// (
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// for instance).</p>
		/// <p>If an error occurs, the bitmap is left unchanged.</p>
		/// </remarks>
		/// <param name="bitmap">
		/// The bitmap to copy the content of the surface texture into,
		/// cannot be null, all configurations are supported
		/// </param>
		/// <returns>The bitmap specified as a parameter</returns>
		/// <seealso cref="isAvailable()"></seealso>
		/// <seealso cref="getBitmap(int, int)"></seealso>
		/// <seealso cref="getBitmap()"></seealso>
		/// <exception cref="System.InvalidOperationException">
		/// if the hardware rendering context cannot be
		/// acquired to capture the bitmap
		/// </exception>
		public virtual android.graphics.Bitmap getBitmap(android.graphics.Bitmap bitmap)
		{
			if (bitmap != null && isAvailable())
			{
				android.view.View.AttachInfo info = mAttachInfo;
				if (info != null && info.mHardwareRenderer != null && info.mHardwareRenderer.isEnabled
					())
				{
					if (!info.mHardwareRenderer.validate())
					{
						throw new System.InvalidOperationException("Could not acquire hardware rendering context"
							);
					}
				}
				applyUpdate();
				applyTransformMatrix();
				mLayer.copyInto(bitmap);
			}
			return bitmap;
		}

		/// <summary>
		/// Returns true if the
		/// <see cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</see>
		/// associated with this
		/// TextureView is available for rendering. When this method returns
		/// true,
		/// <see cref="getSurfaceTexture()">getSurfaceTexture()</see>
		/// returns a valid surface texture.
		/// </summary>
		public virtual bool isAvailable()
		{
			return mSurface != null;
		}

		/// <summary><p>Start editing the pixels in the surface.</summary>
		/// <remarks>
		/// <p>Start editing the pixels in the surface.  The returned Canvas can be used
		/// to draw into the surface's bitmap.  A null is returned if the surface has
		/// not been created or otherwise cannot be edited. You will usually need
		/// to implement
		/// <see cref="SurfaceTextureListener.onSurfaceTextureAvailable(android.graphics.SurfaceTexture, int, int)
		/// 	">SurfaceTextureListener.onSurfaceTextureAvailable(android.graphics.SurfaceTexture, int, int)
		/// 	</see>
		/// to find out when the Surface is available for use.</p>
		/// <p>The content of the Surface is never preserved between unlockCanvas()
		/// and lockCanvas(), for this reason, every pixel within the Surface area
		/// must be written. The only exception to this rule is when a dirty
		/// rectangle is specified, in which case, non-dirty pixels will be
		/// preserved.</p>
		/// <p>This method can only be used if the underlying surface is not already
		/// owned by another producer. For instance, if the TextureView is being used
		/// to render the camera's preview you cannot invoke this method.</p>
		/// </remarks>
		/// <returns>A Canvas used to draw into the surface.</returns>
		/// <seealso cref="lockCanvas(android.graphics.Rect)"></seealso>
		/// <seealso cref="unlockCanvasAndPost(android.graphics.Canvas)"></seealso>
		public virtual android.graphics.Canvas lockCanvas()
		{
			return lockCanvas(null);
		}

		/// <summary>
		/// Just like
		/// <see cref="lockCanvas()">lockCanvas()</see>
		/// but allows specification of a dirty
		/// rectangle. Every pixel within that rectangle must be written; however
		/// pixels outside the dirty rectangle will be preserved by the next call
		/// to lockCanvas().
		/// </summary>
		/// <param name="dirty">Area of the surface that will be modified.</param>
		/// <returns>A Canvas used to draw into the surface.</returns>
		/// <seealso cref="lockCanvas()"></seealso>
		/// <seealso cref="unlockCanvasAndPost(android.graphics.Canvas)"></seealso>
		public virtual android.graphics.Canvas lockCanvas(android.graphics.Rect dirty)
		{
			if (!isAvailable())
			{
				return null;
			}
			if (mCanvas == null)
			{
				mCanvas = new android.graphics.Canvas();
			}
			lock (mNativeWindowLock)
			{
				nLockCanvas(mNativeWindow, mCanvas, dirty);
			}
			mSaveCount = mCanvas.save();
			return mCanvas;
		}

		/// <summary>Finish editing pixels in the surface.</summary>
		/// <remarks>
		/// Finish editing pixels in the surface. After this call, the surface's
		/// current pixels will be shown on the screen, but its content is lost,
		/// in particular there is no guarantee that the content of the Surface
		/// will remain unchanged when lockCanvas() is called again.
		/// </remarks>
		/// <param name="canvas">The Canvas previously returned by lockCanvas()</param>
		/// <seealso cref="lockCanvas()">lockCanvas()</seealso>
		/// <seealso cref="lockCanvas(android.graphics.Rect)"></seealso>
		public virtual void unlockCanvasAndPost(android.graphics.Canvas canvas)
		{
			if (mCanvas != null && canvas == mCanvas)
			{
				canvas.restoreToCount(mSaveCount);
				mSaveCount = 0;
				lock (mNativeWindowLock)
				{
					nUnlockCanvasAndPost(mNativeWindow, mCanvas);
				}
			}
		}

		/// <summary>
		/// Returns the
		/// <see cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</see>
		/// used by this view. This method
		/// may return null if the view is not attached to a window or if the surface
		/// texture has not been initialized yet.
		/// </summary>
		/// <seealso cref="isAvailable()"></seealso>
		public virtual android.graphics.SurfaceTexture getSurfaceTexture()
		{
			return mSurface;
		}

		/// <summary>
		/// Returns the
		/// <see cref="SurfaceTextureListener">SurfaceTextureListener</see>
		/// currently associated with this
		/// texture view.
		/// </summary>
		/// <seealso cref="setSurfaceTextureListener(SurfaceTextureListener)"></seealso>
		/// <seealso cref="SurfaceTextureListener">SurfaceTextureListener</seealso>
		public virtual android.view.TextureView.SurfaceTextureListener getSurfaceTextureListener
			()
		{
			return mListener;
		}

		/// <summary>
		/// Sets the
		/// <see cref="SurfaceTextureListener">SurfaceTextureListener</see>
		/// used to listen to surface
		/// texture events.
		/// </summary>
		/// <seealso cref="getSurfaceTextureListener()"></seealso>
		/// <seealso cref="SurfaceTextureListener">SurfaceTextureListener</seealso>
		public virtual void setSurfaceTextureListener(android.view.TextureView.SurfaceTextureListener
			 listener)
		{
			mListener = listener;
		}

		/// <summary>
		/// This listener can be used to be notified when the surface texture
		/// associated with this texture view is available.
		/// </summary>
		/// <remarks>
		/// This listener can be used to be notified when the surface texture
		/// associated with this texture view is available.
		/// </remarks>
		public interface SurfaceTextureListener
		{
			/// <summary>
			/// Invoked when a
			/// <see cref="TextureView">TextureView</see>
			/// 's SurfaceTexture is ready for use.
			/// </summary>
			/// <param name="surface">
			/// The surface returned by
			/// <see cref="TextureView.getSurfaceTexture()">TextureView.getSurfaceTexture()</see>
			/// </param>
			/// <param name="width">The width of the surface</param>
			/// <param name="height">The height of the surface</param>
			void onSurfaceTextureAvailable(android.graphics.SurfaceTexture surface, int width
				, int height);

			/// <summary>
			/// Invoked when the
			/// <see cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</see>
			/// 's buffers size changed.
			/// </summary>
			/// <param name="surface">
			/// The surface returned by
			/// <see cref="TextureView.getSurfaceTexture()">TextureView.getSurfaceTexture()</see>
			/// </param>
			/// <param name="width">The new width of the surface</param>
			/// <param name="height">The new height of the surface</param>
			void onSurfaceTextureSizeChanged(android.graphics.SurfaceTexture surface, int width
				, int height);

			/// <summary>
			/// Invoked when the specified
			/// <see cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</see>
			/// is about to be destroyed.
			/// If returns true, no rendering should happen inside the surface texture after this method
			/// is invoked. If returns false, the client needs to call
			/// <see cref="android.graphics.SurfaceTexture.release()">android.graphics.SurfaceTexture.release()
			/// 	</see>
			/// .
			/// </summary>
			/// <param name="surface">The surface about to be destroyed</param>
			bool onSurfaceTextureDestroyed(android.graphics.SurfaceTexture surface);

			/// <summary>
			/// Invoked when the specified
			/// <see cref="android.graphics.SurfaceTexture">android.graphics.SurfaceTexture</see>
			/// is updated through
			/// <see cref="android.graphics.SurfaceTexture.updateTexImage()">android.graphics.SurfaceTexture.updateTexImage()
			/// 	</see>
			/// .
			/// </summary>
			/// <param name="surface">The surface just updated</param>
			void onSurfaceTextureUpdated(android.graphics.SurfaceTexture surface);
		}

		[Sharpen.NativeStub]
		private void nCreateNativeWindow(android.graphics.SurfaceTexture surface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private void nDestroyNativeWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static void nSetDefaultBufferSize(android.graphics.SurfaceTexture surfaceTexture
			, int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static void nLockCanvas(int nativeWindow, android.graphics.Canvas canvas, 
			android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static void nUnlockCanvasAndPost(int nativeWindow, android.graphics.Canvas
			 canvas)
		{
			throw new System.NotImplementedException();
		}
	}
}
