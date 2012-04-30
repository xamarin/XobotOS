using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public class Surface : android.os.Parcelable
	{
		internal const string LOG_TAG = "Surface";

		internal const bool DEBUG_RELEASE = false;

		public const int ROTATION_0 = 0;

		public const int ROTATION_90 = 1;

		public const int ROTATION_180 = 2;

		public const int ROTATION_270 = 3;

		[Sharpen.Stub]
		public Surface(android.graphics.SurfaceTexture surfaceTexture)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isValid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void release()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.Canvas lockCanvas(android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unlockCanvasAndPost(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unlockCanvas(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void readFromParcel(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[System.Serializable]
		[Sharpen.Stub]
		public class OutOfResourcesException : System.Exception
		{
			[Sharpen.Stub]
			public OutOfResourcesException()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public OutOfResourcesException(string name) : base(name)
			{
				throw new System.NotImplementedException();
			}
		}

		public const int HIDDEN = unchecked((int)(0x00000004));

		public const int SECURE = unchecked((int)(0x00000080));

		public const int NON_PREMULTIPLIED = unchecked((int)(0x00000100));

		public const int OPAQUE = unchecked((int)(0x00000400));

		public const int PROTECTED_APP = unchecked((int)(0x00000800));

		public const int FX_SURFACE_NORMAL = unchecked((int)(0x00000000));

		[System.ObsoleteAttribute]
		public const int FX_SURFACE_BLUR = unchecked((int)(0x00010000));

		public const int FX_SURFACE_DIM = unchecked((int)(0x00020000));

		public const int FX_SURFACE_SCREENSHOT = unchecked((int)(0x00030000));

		public const int FX_SURFACE_MASK = unchecked((int)(0x000F0000));

		public const int SURFACE_HIDDEN = unchecked((int)(0x01));

		public const int SURFACE_FROZEN = unchecked((int)(0x02));

		public const int SURFACE_DITHER = unchecked((int)(0x04));

		private int mSurfaceControl;

		private int mSaveCount;

		private android.graphics.Canvas mCanvas;

		private int mNativeSurface;

		private int mSurfaceGenerationId;

		private string mName;

		private android.content.res.CompatibilityInfo.Translator mCompatibilityTranslator;

		private android.graphics.Matrix mCompatibleMatrix;

		private System.Exception mCreationStack;

		[Sharpen.Stub]
		private static void nativeClassInit()
		{
			throw new System.NotImplementedException();
		}

		static Surface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Surface(android.view.SurfaceSession s, int pid, int display, int w, int h, 
			int format, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Surface(android.view.SurfaceSession s, int pid, string name, int display, 
			int w, int h, int format, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Surface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private Surface(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void copyFrom(android.view.Surface o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getGenerationId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class CompatibleCanvas : android.graphics.Canvas
		{
			internal android.graphics.Matrix mOrigMatrix;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
			public override int getWidth()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
			public override int getHeight()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
			public override void setMatrix(android.graphics.Matrix matrix)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
			public override void getMatrix(android.graphics.Matrix m)
			{
				throw new System.NotImplementedException();
			}

			public CompatibleCanvas(Surface _enclosing)
			{
				this._enclosing = _enclosing;
				mOrigMatrix = null;
			}

			private readonly Surface _enclosing;
		}

		[Sharpen.Stub]
		internal virtual void setCompatibilityTranslator(android.content.res.CompatibilityInfo
			.Translator translator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void destroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.graphics.Canvas lockCanvasNative(android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void freezeDisplay(int display)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void unfreezeDisplay(int display)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setOrientation(int display, int orientation, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setOrientation(int display, int orientation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.Bitmap screenshot(int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.Bitmap screenshot(int width, int height, int minLayer
			, int maxLayer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void openTransaction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void closeTransaction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLayer(int zorder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPosition(int x, int y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPosition(float x, float y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSize(int w, int h)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void hide()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void show()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTransparentRegionHint(android.graphics.Region region)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAlpha(float alpha)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMatrix(float dsdx, float dtdx, float dsdy, float dtdy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void freeze()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unfreeze()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFreezeTint(int tint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFlags(int flags, int mask)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_477 : android.os.ParcelableClass.Creator<android.view.Surface
			>
		{
			public _Creator_477()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.Surface createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.Surface[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.Surface> CREATOR
			 = new _Creator_477();

		~Surface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void init(android.view.SurfaceSession s, int pid, string name, int display
			, int w, int h, int format, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void init(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initFromSurfaceTexture(android.graphics.SurfaceTexture surfaceTexture
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getIdentity()
		{
			throw new System.NotImplementedException();
		}
	}
}
