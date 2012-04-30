using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// A picture records drawing calls (via the canvas returned by beginRecording)
	/// and can then play them back (via picture.draw(canvas) or canvas.drawPicture).
	/// </summary>
	/// <remarks>
	/// A picture records drawing calls (via the canvas returned by beginRecording)
	/// and can then play them back (via picture.draw(canvas) or canvas.drawPicture).
	/// The picture's contents can also be written to a stream, and then later
	/// restored to a new picture (via writeToStream / createFromStream). For most
	/// content (esp. text, lines, rectangles), drawing a sequence from a picture can
	/// be faster than the equivalent API calls, since the picture performs its
	/// playback without incurring any java-call overhead.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Picture : System.IDisposable
	{
		private android.graphics.Canvas mRecordingCanvas;

		internal readonly android.graphics.Picture.NativePicture mNativePicture;

		internal const int WORKING_STREAM_STORAGE = 16 * 1024;

		public Picture() : this(nativeConstructor(null))
		{
		}

		/// <summary>
		/// Create a picture by making a copy of what has already been recorded in
		/// src.
		/// </summary>
		/// <remarks>
		/// Create a picture by making a copy of what has already been recorded in
		/// src. The contents of src are unchanged, and if src changes later, those
		/// changes will not be reflected in this picture.
		/// </remarks>
		public Picture(android.graphics.Picture src) : this(nativeConstructor(src != null
			 ? src.mNativePicture : null))
		{
		}

		/// <summary>
		/// To record a picture, call beginRecording() and then draw into the Canvas
		/// that is returned.
		/// </summary>
		/// <remarks>
		/// To record a picture, call beginRecording() and then draw into the Canvas
		/// that is returned. Nothing we appear on screen, but all of the draw
		/// commands (e.g. drawRect(...)) will be recorded. To stop recording, call
		/// endRecording(). At this point the Canvas that was returned must no longer
		/// be referenced, and nothing should be drawn into it.
		/// </remarks>
		public virtual android.graphics.Canvas beginRecording(int width, int height)
		{
			android.graphics.Canvas.NativeCanvas ni_1 = nativeBeginRecording(mNativePicture, 
				width, height);
			mRecordingCanvas = new android.graphics.Picture.RecordingCanvas(this, ni_1);
			return mRecordingCanvas;
		}

		/// <summary>Call endRecording when the picture is built.</summary>
		/// <remarks>
		/// Call endRecording when the picture is built. After this call, the picture
		/// may be drawn, but the canvas that was returned by beginRecording must not
		/// be referenced anymore. This is automatically called if Picture.draw() or
		/// Canvas.drawPicture() is called.
		/// </remarks>
		public virtual void endRecording()
		{
			if (mRecordingCanvas != null)
			{
				mRecordingCanvas = null;
				nativeEndRecording(mNativePicture);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Picture_width(android.graphics.Picture.NativePicture
			 _instance);

		/// <summary>Get the width of the picture as passed to beginRecording.</summary>
		/// <remarks>
		/// Get the width of the picture as passed to beginRecording. This
		/// does not reflect (per se) the content of the picture.
		/// </remarks>
		public virtual int getWidth()
		{
			return libxobotos_Picture_width(mNativePicture);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Picture_height(android.graphics.Picture.NativePicture
			 _instance);

		/// <summary>Get the height of the picture as passed to beginRecording.</summary>
		/// <remarks>
		/// Get the height of the picture as passed to beginRecording. This
		/// does not reflect (per se) the content of the picture.
		/// </remarks>
		public virtual int getHeight()
		{
			return libxobotos_Picture_height(mNativePicture);
		}

		/// <summary>Draw this picture on the canvas.</summary>
		/// <remarks>
		/// Draw this picture on the canvas. The picture may have the side effect
		/// of changing the matrix and clip of the canvas.
		/// </remarks>
		/// <param name="canvas">The picture is drawn to this canvas</param>
		public virtual void draw(android.graphics.Canvas canvas)
		{
			if (mRecordingCanvas != null)
			{
				endRecording();
			}
			nativeDraw(canvas.mNativeCanvas, mNativePicture);
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"java.io has not yet been ported.")]
		public static android.graphics.Picture createFromStream(java.io.InputStream stream
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"java.io has not yet been ported.")]
		public virtual void writeToStream(java.io.OutputStream stream)
		{
			throw new System.NotImplementedException();
		}

		~Picture()
		{
			// do explicit check before calling the native method
			nativeDestructor(mNativePicture);
		}

		private Picture(android.graphics.Picture.NativePicture nativePicture)
		{
			if (nativePicture == null)
			{
				throw new java.lang.RuntimeException();
			}
			mNativePicture = nativePicture;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Picture.NativePicture libxobotos_Picture_create
			(android.graphics.Picture.NativePicture nativeSrcOr0);

		// return empty picture if src is 0, or a copy of the native src
		private static android.graphics.Picture.NativePicture nativeConstructor(android.graphics.Picture.NativePicture
			 nativeSrcOr0)
		{
			return libxobotos_Picture_create(nativeSrcOr0 != null ? nativeSrcOr0 : android.graphics.Picture.NativePicture
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Canvas.NativeCanvas libxobotos_Picture_beginRecording
			(android.graphics.Picture.NativePicture nativeCanvas, int w, int h);

		private static android.graphics.Canvas.NativeCanvas nativeBeginRecording(android.graphics.Picture.NativePicture
			 nativeCanvas, int w, int h)
		{
			return libxobotos_Picture_beginRecording(nativeCanvas, w, h);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Picture_endRecording(android.graphics.Picture.NativePicture
			 nativeCanvas);

		private static void nativeEndRecording(android.graphics.Picture.NativePicture nativeCanvas
			)
		{
			libxobotos_Picture_endRecording(nativeCanvas);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Picture_draw(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Picture.NativePicture nativePicture);

		private static void nativeDraw(android.graphics.Canvas.NativeCanvas nativeCanvas, 
			android.graphics.Picture.NativePicture nativePicture)
		{
			libxobotos_Picture_draw(nativeCanvas, nativePicture);
		}

		private static void nativeDestructor(android.graphics.Picture.NativePicture nativePicture
			)
		{
			nativePicture.Dispose();
		}

		private class RecordingCanvas : android.graphics.Canvas
		{
			internal readonly android.graphics.Picture mPicture;

			public RecordingCanvas(android.graphics.Picture pict, android.graphics.Canvas.NativeCanvas
				 nativeCanvas) : base(nativeCanvas)
			{
				mPicture = pict;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
			public override void setBitmap(android.graphics.Bitmap bitmap)
			{
				throw new java.lang.RuntimeException("Cannot call setBitmap on a picture canvas");
			}

			[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
			public override void drawPicture(android.graphics.Picture picture)
			{
				if (mPicture == picture)
				{
					throw new java.lang.RuntimeException("Cannot draw a picture into its recording canvas"
						);
				}
				base.drawPicture(picture);
			}
		}

		internal NativePicture nativeInstance
		{
			get
			{
				return mNativePicture;
			}
		}

		public void Dispose()
		{
			mNativePicture.Dispose();
		}

		internal class NativePicture : System.Runtime.InteropServices.SafeHandle
		{
			internal NativePicture() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativePicture(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Picture_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativePicture Zero = new NativePicture();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Picture_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
