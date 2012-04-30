using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public abstract partial class HardwareRenderer
	{
		internal const string LOG_TAG = "HardwareRenderer";

		public const bool RENDER_DIRTY_REGIONS = true;

		internal const string RENDER_DIRTY_REGIONS_PROPERTY = "hwui.render_dirty_regions";

		internal const string DISABLE_VSYNC_PROPERTY = "hwui.disable_vsync";

		internal const string PRINT_CONFIG_PROPERTY = "hwui.print_config";

		internal const bool DEBUG_DIRTY_REGION = false;

		public static bool sRendererDisabled = false;

		public static bool sSystemRendererDisabled = false;

		private bool mEnabled;

		private bool mRequested = true;

		[Sharpen.Stub]
		public static void disable(bool system)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal abstract void destroy(bool full);

		[Sharpen.Stub]
		internal abstract bool initialize(android.view.SurfaceHolder holder);

		[Sharpen.Stub]
		internal abstract void updateSurface(android.view.SurfaceHolder holder);

		[Sharpen.Stub]
		internal abstract void destroyLayers(android.view.View view);

		[Sharpen.Stub]
		internal abstract void invalidate(android.view.SurfaceHolder holder);

		[Sharpen.Stub]
		internal abstract bool validate();

		[Sharpen.Stub]
		internal abstract void setup(int width, int height);

		[Sharpen.Stub]
		internal abstract int getWidth();

		[Sharpen.Stub]
		internal abstract int getHeight();

		[Sharpen.Stub]
		internal interface HardwareDrawCallbacks
		{
			[Sharpen.Stub]
			void onHardwarePreDraw(android.view.HardwareCanvas canvas);

			[Sharpen.Stub]
			void onHardwarePostDraw(android.view.HardwareCanvas canvas);
		}

		[Sharpen.Stub]
		internal abstract bool draw(android.view.View view, android.view.View.AttachInfo 
			attachInfo, android.view.HardwareRenderer.HardwareDrawCallbacks callbacks, android.graphics.Rect
			 dirty);

		[Sharpen.Stub]
		internal abstract android.view.DisplayList createDisplayList();

		[Sharpen.Stub]
		internal abstract android.view.HardwareLayer createHardwareLayer(bool isOpaque);

		[Sharpen.Stub]
		internal abstract android.view.HardwareLayer createHardwareLayer(int width, int height
			, bool isOpaque);

		[Sharpen.Stub]
		internal abstract android.graphics.SurfaceTexture createSurfaceTexture(android.view.HardwareLayer
			 layer);

		[Sharpen.Stub]
		internal virtual void initializeIfNeeded(int width, int height, android.view.View
			.AttachInfo attachInfo, android.view.SurfaceHolder holder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.view.HardwareRenderer createGlRenderer(int glVersion, bool
			 translucent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void trimMemory(int level)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool isEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool isRequested()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setRequested(bool requested)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal abstract class GlRenderer : android.view.HardwareRenderer
		{
			internal const int EGL_CONTEXT_CLIENT_VERSION = unchecked((int)(0x3098));

			internal const int EGL_OPENGL_ES2_BIT = 4;

			internal const int EGL_SURFACE_TYPE = unchecked((int)(0x3033));

			internal const int EGL_SWAP_BEHAVIOR_PRESERVED_BIT = unchecked((int)(0x0400));

			internal const int SURFACE_STATE_ERROR = 0;

			internal const int SURFACE_STATE_SUCCESS = 1;

			internal const int SURFACE_STATE_UPDATED = 2;

			internal static javax.microedition.khronos.egl.EGL10 sEgl;

			internal static javax.microedition.khronos.egl.EGLDisplay sEglDisplay;

			internal static javax.microedition.khronos.egl.EGLConfig sEglConfig;

			internal static readonly object[] sEglLock = new object[0];

			internal int mWidth = -1;

			internal int mHeight = -1;

			internal static readonly java.lang.ThreadLocal<javax.microedition.khronos.egl.EGLContext
				> sEglContextStorage = new java.lang.ThreadLocal<javax.microedition.khronos.egl.EGLContext
				>();

			internal javax.microedition.khronos.egl.EGLContext mEglContext;

			internal java.lang.Thread mEglThread;

			internal javax.microedition.khronos.egl.EGLSurface mEglSurface;

			internal javax.microedition.khronos.opengles.GL mGl;

			internal android.view.HardwareCanvas mCanvas;

			internal int mFrameCount;

			internal android.graphics.Paint mDebugPaint;

			internal static bool sDirtyRegions;

			internal static readonly bool sDirtyRegionsRequested;

			static GlRenderer()
			{
				throw new System.NotImplementedException();
			}

			internal bool mDirtyRegionsEnabled;

			internal readonly bool mVsyncDisabled;

			internal readonly int mGlVersion;

			internal readonly bool mTranslucent;

			private bool mDestroyed;

			private readonly android.graphics.Rect mRedrawClip = new android.graphics.Rect();

			[Sharpen.Stub]
			internal GlRenderer(int glVersion, bool translucent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual bool hasDirtyRegions()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void checkEglErrors()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void fallback(bool fallback_1)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override bool initialize(android.view.SurfaceHolder holder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override void updateSurface(android.view.SurfaceHolder holder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal abstract android.view.GLES20Canvas createCanvas();

			[Sharpen.Stub]
			internal abstract int[] getConfig(bool dirtyRegions);

			[Sharpen.Stub]
			internal virtual void initializeEgl()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private javax.microedition.khronos.egl.EGLConfig chooseEglConfig()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void printConfig(javax.microedition.khronos.egl.EGLConfig config)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual javax.microedition.khronos.opengles.GL createEglSurface(android.view.SurfaceHolder
				 holder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual javax.microedition.khronos.egl.EGLContext createContext(javax.microedition.khronos.egl.EGL10
				 egl, javax.microedition.khronos.egl.EGLDisplay eglDisplay, javax.microedition.khronos.egl.EGLConfig
				 eglConfig)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override void destroy(bool full)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void destroySurface()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override void invalidate(android.view.SurfaceHolder holder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool createSurface(android.view.SurfaceHolder holder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override bool validate()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override void setup(int width, int height)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override int getWidth()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override int getHeight()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual bool canDraw()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void onPreDraw(android.graphics.Rect dirty)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void onPostDraw()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override bool draw(android.view.View view, android.view.View.AttachInfo 
				attachInfo, android.view.HardwareRenderer.HardwareDrawCallbacks callbacks, android.graphics.Rect
				 dirty)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual int checkCurrent()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class Gl20Renderer : android.view.HardwareRenderer.GlRenderer
		{
			private android.view.GLES20Canvas mGlCanvas;

			private static javax.microedition.khronos.egl.EGLSurface sPbuffer;

			private static readonly object[] sPbufferLock = new object[0];

			[Sharpen.Stub]
			internal Gl20Renderer(bool translucent) : base(2, translucent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer.GlRenderer")]
			internal override android.view.GLES20Canvas createCanvas()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer.GlRenderer")]
			internal override int[] getConfig(bool dirtyRegions)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer.GlRenderer")]
			internal override bool canDraw()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer.GlRenderer")]
			internal override void onPreDraw(android.graphics.Rect dirty)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer.GlRenderer")]
			internal override void onPostDraw()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override void destroy(bool full)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override void setup(int width, int height)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override android.view.DisplayList createDisplayList()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override android.view.HardwareLayer createHardwareLayer(bool isOpaque)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override android.view.HardwareLayer createHardwareLayer(int width, int height
				, bool isOpaque)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override android.graphics.SurfaceTexture createSurfaceTexture(android.view.HardwareLayer
				 layer)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.HardwareRenderer")]
			internal override void destroyLayers(android.view.View view)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void destroyHardwareLayer(android.view.View view)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal static android.view.HardwareRenderer create(bool translucent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			new internal static void trimMemory(int level)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
