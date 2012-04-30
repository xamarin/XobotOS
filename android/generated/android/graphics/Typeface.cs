using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>The Typeface class specifies the typeface and intrinsic style of a font.
	/// 	</summary>
	/// <remarks>
	/// The Typeface class specifies the typeface and intrinsic style of a font.
	/// This is used in the paint, along with optionally Paint settings like
	/// textSize, textSkewX, textScaleX to specify
	/// how text appears when drawn (and measured).
	/// </remarks>
	[Sharpen.Sharpened]
	public class Typeface : System.IDisposable
	{
		/// <summary>The default NORMAL typeface object</summary>
		public static readonly android.graphics.Typeface DEFAULT;

		/// <summary>The default BOLD typeface object.</summary>
		/// <remarks>
		/// The default BOLD typeface object. Note: this may be not actually be
		/// bold, depending on what fonts are installed. Call getStyle() to know
		/// for sure.
		/// </remarks>
		public static readonly android.graphics.Typeface DEFAULT_BOLD;

		/// <summary>The NORMAL style of the default sans serif typeface.</summary>
		/// <remarks>The NORMAL style of the default sans serif typeface.</remarks>
		public static readonly android.graphics.Typeface SANS_SERIF;

		/// <summary>The NORMAL style of the default serif typeface.</summary>
		/// <remarks>The NORMAL style of the default serif typeface.</remarks>
		public static readonly android.graphics.Typeface SERIF;

		/// <summary>The NORMAL style of the default monospace typeface.</summary>
		/// <remarks>The NORMAL style of the default monospace typeface.</remarks>
		public static readonly android.graphics.Typeface MONOSPACE;

		internal static android.graphics.Typeface[] sDefaults;

		internal android.graphics.Typeface.NativeTypeface native_instance;

		public const int NORMAL = 0;

		public const int BOLD = 1;

		public const int ITALIC = 2;

		public const int BOLD_ITALIC = 3;

		// Style
		/// <summary>Returns the typeface's intrinsic style attributes</summary>
		public virtual int getStyle()
		{
			return nativeGetStyle(native_instance);
		}

		/// <summary>Returns true if getStyle() has the BOLD bit set.</summary>
		/// <remarks>Returns true if getStyle() has the BOLD bit set.</remarks>
		public bool isBold()
		{
			return (getStyle() & BOLD) != 0;
		}

		/// <summary>Returns true if getStyle() has the ITALIC bit set.</summary>
		/// <remarks>Returns true if getStyle() has the ITALIC bit set.</remarks>
		public bool isItalic()
		{
			return (getStyle() & ITALIC) != 0;
		}

		/// <summary>Create a typeface object given a family name, and option style information.
		/// 	</summary>
		/// <remarks>
		/// Create a typeface object given a family name, and option style information.
		/// If null is passed for the name, then the "default" font will be chosen.
		/// The resulting typeface object can be queried (getStyle()) to discover what
		/// its "real" style characteristics are.
		/// </remarks>
		/// <param name="familyName">May be null. The name of the font family.</param>
		/// <param name="style">
		/// The style (normal, bold, italic) of the typeface.
		/// e.g. NORMAL, BOLD, ITALIC, BOLD_ITALIC
		/// </param>
		/// <returns>The best matching typeface.</returns>
		public static android.graphics.Typeface create(string familyName, int style)
		{
			return new android.graphics.Typeface(nativeCreate(familyName, style));
		}

		/// <summary>
		/// Create a typeface object that best matches the specified existing
		/// typeface and the specified Style.
		/// </summary>
		/// <remarks>
		/// Create a typeface object that best matches the specified existing
		/// typeface and the specified Style. Use this call if you want to pick a new
		/// style from the same family of an existing typeface object. If family is
		/// null, this selects from the default font's family.
		/// </remarks>
		/// <param name="family">May be null. The name of the existing type face.</param>
		/// <param name="style">
		/// The style (normal, bold, italic) of the typeface.
		/// e.g. NORMAL, BOLD, ITALIC, BOLD_ITALIC
		/// </param>
		/// <returns>The best matching typeface.</returns>
		public static android.graphics.Typeface create(android.graphics.Typeface family, 
			int style)
		{
			android.graphics.Typeface.NativeTypeface ni = null;
			if (family != null)
			{
				ni = family.native_instance;
			}
			return new android.graphics.Typeface(nativeCreateFromTypeface(ni, style));
		}

		/// <summary>Returns one of the default typeface objects, based on the specified style
		/// 	</summary>
		/// <returns>the default typeface that corresponds to the style</returns>
		public static android.graphics.Typeface defaultFromStyle(int style)
		{
			return sDefaults[style];
		}

		[Sharpen.Stub]
		public static android.graphics.Typeface createFromAsset(android.content.res.AssetManager
			 mgr, string path)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Create a new typeface from the specified font file.</summary>
		/// <remarks>Create a new typeface from the specified font file.</remarks>
		/// <param name="path">The path to the font data.</param>
		/// <returns>The new typeface.</returns>
		public static android.graphics.Typeface createFromFile(java.io.File path)
		{
			return new android.graphics.Typeface(nativeCreateFromFile(path.getAbsolutePath())
				);
		}

		/// <summary>Create a new typeface from the specified font file.</summary>
		/// <remarks>Create a new typeface from the specified font file.</remarks>
		/// <param name="path">The full path to the font data.</param>
		/// <returns>The new typeface.</returns>
		public static android.graphics.Typeface createFromFile(string path)
		{
			return new android.graphics.Typeface(nativeCreateFromFile(path));
		}

		private Typeface(android.graphics.Typeface.NativeTypeface ni)
		{
			// don't allow clients to call this directly
			if (null == ni)
			{
				throw new java.lang.RuntimeException("native typeface cannot be made");
			}
			native_instance = ni;
		}

		static Typeface()
		{
			DEFAULT = create((string)null, 0);
			DEFAULT_BOLD = create((string)null, android.graphics.Typeface.BOLD);
			SANS_SERIF = create("sans-serif", 0);
			SERIF = create("serif", 0);
			MONOSPACE = create("monospace", 0);
			sDefaults = new android.graphics.Typeface[] { DEFAULT, DEFAULT_BOLD, create((string
				)null, android.graphics.Typeface.ITALIC), create((string)null, android.graphics.Typeface
				.BOLD_ITALIC) };
		}

		~Typeface()
		{
			;
			nativeUnref(native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Typeface.NativeTypeface libxobotos_Typeface_createFromName
			(System.IntPtr familyName, int style);

		private static android.graphics.Typeface.NativeTypeface nativeCreate(string familyName
			, int style)
		{
			System.IntPtr familyName_ptr = System.IntPtr.Zero;
			try
			{
				familyName_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(familyName
					);
				return libxobotos_Typeface_createFromName(familyName_ptr, style);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(familyName_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Typeface.NativeTypeface libxobotos_Typeface_createFromTypeface
			(android.graphics.Typeface.NativeTypeface native_instance, int style);

		private static android.graphics.Typeface.NativeTypeface nativeCreateFromTypeface(
			android.graphics.Typeface.NativeTypeface native_instance, int style)
		{
			return libxobotos_Typeface_createFromTypeface(native_instance != null ? native_instance
				 : android.graphics.Typeface.NativeTypeface.Zero, style);
		}

		private static void nativeUnref(android.graphics.Typeface.NativeTypeface native_instance
			)
		{
			native_instance.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Typeface_style(android.graphics.Typeface.NativeTypeface
			 native_instance);

		private static int nativeGetStyle(android.graphics.Typeface.NativeTypeface native_instance
			)
		{
			return libxobotos_Typeface_style(native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Typeface.NativeTypeface libxobotos_Typeface_createFromFile
			(System.IntPtr path);

		private static android.graphics.Typeface.NativeTypeface nativeCreateFromFile(string
			 path)
		{
			System.IntPtr path_ptr = System.IntPtr.Zero;
			try
			{
				path_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(path);
				return libxobotos_Typeface_createFromFile(path_ptr);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(path_ptr);
			}
		}

		[Sharpen.Stub]
		public static void setGammaForText(float blackGamma, float whiteGamma)
		{
			throw new System.NotImplementedException();
		}

		internal NativeTypeface nativeInstance
		{
			get
			{
				return native_instance;
			}
		}

		public void Dispose()
		{
			native_instance.Dispose();
		}

		internal class NativeTypeface : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeTypeface() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeTypeface(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Typeface_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeTypeface Zero = new NativeTypeface();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Typeface_destructor(handle);
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
