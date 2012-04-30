using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class WallpaperManager
	{
		private static string TAG = "WallpaperManager";

		private static bool DEBUG = false;

		private float mWallpaperXStep = -1;

		private float mWallpaperYStep = -1;

		public const string ACTION_LIVE_WALLPAPER_CHOOSER = "android.service.wallpaper.LIVE_WALLPAPER_CHOOSER";

		public const string WALLPAPER_PREVIEW_META_DATA = "android.wallpaper.preview";

		public const string COMMAND_TAP = "android.wallpaper.tap";

		public const string COMMAND_SECONDARY_TAP = "android.wallpaper.secondaryTap";

		public const string COMMAND_DROP = "android.home.drop";

		private readonly android.content.Context mContext;

		[Sharpen.Stub]
		internal class FastBitmapDrawable : android.graphics.drawable.Drawable
		{
			private readonly android.graphics.Bitmap mBitmap;

			private readonly int mWidth;

			private readonly int mHeight;

			private int mDrawLeft;

			private int mDrawTop;

			private readonly android.graphics.Paint mPaint;

			[Sharpen.Stub]
			private FastBitmapDrawable(android.graphics.Bitmap bitmap)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void draw(android.graphics.Canvas canvas)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override int getOpacity()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void setBounds(int left, int top, int right, int bottom)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void setAlpha(int alpha)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void setColorFilter(android.graphics.ColorFilter cf)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void setDither(bool dither)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override void setFilterBitmap(bool filter)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override int getIntrinsicWidth()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override int getIntrinsicHeight()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override int getMinimumWidth()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
			public override int getMinimumHeight()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class Globals : android.app.IWallpaperManagerCallbackClass.Stub
		{
			private android.app.IWallpaperManager mService;

			private android.graphics.Bitmap mWallpaper;

			private android.graphics.Bitmap mDefaultWallpaper;

			internal const int MSG_CLEAR_WALLPAPER = 1;

			private readonly android.os.Handler mHandler;

			[Sharpen.Stub]
			internal Globals(android.os.Looper looper)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.app.IWallpaperManagerCallback")]
			public override void onWallpaperChanged()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.graphics.Bitmap peekWallpaperBitmap(android.content.Context
				 context, bool returnDefault)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void forgetLoadedWallpaper()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.graphics.Bitmap getCurrentWallpaperLocked()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.graphics.Bitmap getDefaultWallpaperLocked(android.content.Context
				 context)
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly object sSync = new object[0];

		private static android.app.WallpaperManager.Globals sGlobals;

		[Sharpen.Stub]
		internal static void initGlobals(android.os.Looper looper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal WallpaperManager(android.content.Context context, android.os.Handler handler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.WallpaperManager getInstance(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.IWallpaperManager getIWallpaperManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.drawable.Drawable getDrawable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.drawable.Drawable peekDrawable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.drawable.Drawable getFastDrawable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.drawable.Drawable peekFastDrawable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.Bitmap getBitmap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void forgetLoadedWallpaper()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.WallpaperInfo getWallpaperInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setResource(int resid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBitmap(android.graphics.Bitmap bitmap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStream(java.io.InputStream data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setWallpaper(java.io.InputStream data, java.io.FileOutputStream fos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDesiredMinimumWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDesiredMinimumHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void suggestDesiredDimensions(int minimumWidth, int minimumHeight)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setWallpaperOffsets(android.os.IBinder windowToken, float xOffset
			, float yOffset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setWallpaperOffsetSteps(float xStep, float yStep)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendWallpaperCommand(android.os.IBinder windowToken, string action
			, int x, int y, int z, android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearWallpaperOffsets(android.os.IBinder windowToken)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.graphics.Bitmap generateBitmap(android.graphics.Bitmap bm
			, int width, int height)
		{
			throw new System.NotImplementedException();
		}
	}
}
