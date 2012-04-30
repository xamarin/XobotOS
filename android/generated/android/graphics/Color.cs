using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>The Color class defines methods for creating and converting color ints.</summary>
	/// <remarks>
	/// The Color class defines methods for creating and converting color ints.
	/// Colors are represented as packed ints, made up of 4 bytes: alpha, red,
	/// green, blue. The values are unpremultiplied, meaning any transparency is
	/// stored solely in the alpha component, and not in the color components. The
	/// components are stored as follows (alpha &lt;&lt; 24) | (red &lt;&lt; 16) |
	/// (green &lt;&lt; 8) | blue. Each component ranges between 0..255 with 0
	/// meaning no contribution for that component, and 255 meaning 100%
	/// contribution. Thus opaque-black would be 0xFF000000 (100% opaque but
	/// no contributions from red, green, or blue), and opaque-white would be
	/// 0xFFFFFFFF
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class Color
	{
		public const int BLACK = unchecked((int)(0xFF000000));

		public const int DKGRAY = unchecked((int)(0xFF444444));

		public const int GRAY = unchecked((int)(0xFF888888));

		public const int LTGRAY = unchecked((int)(0xFFCCCCCC));

		public const int WHITE = unchecked((int)(0xFFFFFFFF));

		public const int RED = unchecked((int)(0xFFFF0000));

		public const int GREEN = unchecked((int)(0xFF00FF00));

		public const int BLUE = unchecked((int)(0xFF0000FF));

		public const int YELLOW = unchecked((int)(0xFFFFFF00));

		public const int CYAN = unchecked((int)(0xFF00FFFF));

		public const int MAGENTA = unchecked((int)(0xFFFF00FF));

		public const int TRANSPARENT = 0;

		/// <summary>Return the alpha component of a color int.</summary>
		/// <remarks>
		/// Return the alpha component of a color int. This is the same as saying
		/// color &gt;&gt;&gt; 24
		/// </remarks>
		public static int alpha(int color)
		{
			return (int)(((uint)color) >> 24);
		}

		/// <summary>Return the red component of a color int.</summary>
		/// <remarks>
		/// Return the red component of a color int. This is the same as saying
		/// (color &gt;&gt; 16) & 0xFF
		/// </remarks>
		public static int red(int color)
		{
			return (color >> 16) & unchecked((int)(0xFF));
		}

		/// <summary>Return the green component of a color int.</summary>
		/// <remarks>
		/// Return the green component of a color int. This is the same as saying
		/// (color &gt;&gt; 8) & 0xFF
		/// </remarks>
		public static int green(int color)
		{
			return (color >> 8) & unchecked((int)(0xFF));
		}

		/// <summary>Return the blue component of a color int.</summary>
		/// <remarks>
		/// Return the blue component of a color int. This is the same as saying
		/// color & 0xFF
		/// </remarks>
		public static int blue(int color)
		{
			return color & unchecked((int)(0xFF));
		}

		/// <summary>Return a color-int from red, green, blue components.</summary>
		/// <remarks>
		/// Return a color-int from red, green, blue components.
		/// The alpha component is implicity 255 (fully opaque).
		/// These component values should be [0..255], but there is no
		/// range check performed, so if they are out of range, the
		/// returned color is undefined.
		/// </remarks>
		/// <param name="red">Red component [0..255] of the color</param>
		/// <param name="green">Green component [0..255] of the color</param>
		/// <param name="blue">Blue component [0..255] of the color</param>
		public static int rgb(int red_1, int green_1, int blue_1)
		{
			return (unchecked((int)(0xFF)) << 24) | (red_1 << 16) | (green_1 << 8) | blue_1;
		}

		/// <summary>Return a color-int from alpha, red, green, blue components.</summary>
		/// <remarks>
		/// Return a color-int from alpha, red, green, blue components.
		/// These component values should be [0..255], but there is no
		/// range check performed, so if they are out of range, the
		/// returned color is undefined.
		/// </remarks>
		/// <param name="alpha">Alpha component [0..255] of the color</param>
		/// <param name="red">Red component [0..255] of the color</param>
		/// <param name="green">Green component [0..255] of the color</param>
		/// <param name="blue">Blue component [0..255] of the color</param>
		public static int argb(int alpha_1, int red_1, int green_1, int blue_1)
		{
			return (alpha_1 << 24) | (red_1 << 16) | (green_1 << 8) | blue_1;
		}

		/// <summary>Returns the hue component of a color int.</summary>
		/// <remarks>Returns the hue component of a color int.</remarks>
		/// <returns>A value between 0.0f and 1.0f</returns>
		/// <hide>Pending API council</hide>
		public static float hue(int color)
		{
			int r = (color >> 16) & unchecked((int)(0xFF));
			int g = (color >> 8) & unchecked((int)(0xFF));
			int b = color & unchecked((int)(0xFF));
			int V = System.Math.Max(b, System.Math.Max(r, g));
			int temp = System.Math.Min(b, System.Math.Min(r, g));
			float H;
			if (V == temp)
			{
				H = 0;
			}
			else
			{
				float vtemp = (float)(V - temp);
				float cr = (V - r) / vtemp;
				float cg = (V - g) / vtemp;
				float cb = (V - b) / vtemp;
				if (r == V)
				{
					H = cb - cg;
				}
				else
				{
					if (g == V)
					{
						H = 2 + cr - cb;
					}
					else
					{
						H = 4 + cg - cr;
					}
				}
				H /= 6.0f;
				if (H < 0)
				{
					H++;
				}
			}
			return H;
		}

		/// <summary>Returns the saturation component of a color int.</summary>
		/// <remarks>Returns the saturation component of a color int.</remarks>
		/// <returns>A value between 0.0f and 1.0f</returns>
		/// <hide>Pending API council</hide>
		public static float saturation(int color)
		{
			int r = (color >> 16) & unchecked((int)(0xFF));
			int g = (color >> 8) & unchecked((int)(0xFF));
			int b = color & unchecked((int)(0xFF));
			int V = System.Math.Max(b, System.Math.Max(r, g));
			int temp = System.Math.Min(b, System.Math.Min(r, g));
			float S;
			if (V == temp)
			{
				S = 0;
			}
			else
			{
				S = (V - temp) / (float)V;
			}
			return S;
		}

		/// <summary>Returns the brightness component of a color int.</summary>
		/// <remarks>Returns the brightness component of a color int.</remarks>
		/// <returns>A value between 0.0f and 1.0f</returns>
		/// <hide>Pending API council</hide>
		public static float brightness(int color)
		{
			int r = (color >> 16) & unchecked((int)(0xFF));
			int g = (color >> 8) & unchecked((int)(0xFF));
			int b = color & unchecked((int)(0xFF));
			int V = System.Math.Max(b, System.Math.Max(r, g));
			return (V / 255.0f);
		}

		// Use a long to avoid rollovers on #ffXXXXXX
		// Set the alpha value
		/// <summary>Convert HSB components to an ARGB color.</summary>
		/// <remarks>
		/// Convert HSB components to an ARGB color. Alpha set to 0xFF.
		/// hsv[0] is Hue [0 .. 1)
		/// hsv[1] is Saturation [0...1]
		/// hsv[2] is Value [0...1]
		/// If hsv values are out of range, they are pinned.
		/// </remarks>
		/// <param name="hsb">3 element array which holds the input HSB components.</param>
		/// <returns>the resulting argb color</returns>
		/// <hide>Pending API council</hide>
		public static int HSBtoColor(float[] hsb)
		{
			return HSBtoColor(hsb[0], hsb[1], hsb[2]);
		}

		/// <summary>Convert HSB components to an ARGB color.</summary>
		/// <remarks>
		/// Convert HSB components to an ARGB color. Alpha set to 0xFF.
		/// hsv[0] is Hue [0 .. 1)
		/// hsv[1] is Saturation [0...1]
		/// hsv[2] is Value [0...1]
		/// If hsv values are out of range, they are pinned.
		/// </remarks>
		/// <param name="h">Hue component</param>
		/// <param name="s">Saturation component</param>
		/// <param name="b">Brightness component</param>
		/// <returns>the resulting argb color</returns>
		/// <hide>Pending API council</hide>
		public static int HSBtoColor(float h, float s, float b)
		{
			h = android.util.MathUtils.constrain(h, 0.0f, 1.0f);
			s = android.util.MathUtils.constrain(s, 0.0f, 1.0f);
			b = android.util.MathUtils.constrain(b, 0.0f, 1.0f);
			float red_1 = 0.0f;
			float green_1 = 0.0f;
			float blue_1 = 0.0f;
			float hf = (h - (int)h) * 6.0f;
			int ihf = (int)hf;
			float f = hf - ihf;
			float pv = b * (1.0f - s);
			float qv = b * (1.0f - s * f);
			float tv = b * (1.0f - s * (1.0f - f));
			switch (ihf)
			{
				case 0:
				{
					// Red is the dominant color
					red_1 = b;
					green_1 = tv;
					blue_1 = pv;
					break;
				}

				case 1:
				{
					// Green is the dominant color
					red_1 = qv;
					green_1 = b;
					blue_1 = pv;
					break;
				}

				case 2:
				{
					red_1 = pv;
					green_1 = b;
					blue_1 = tv;
					break;
				}

				case 3:
				{
					// Blue is the dominant color
					red_1 = pv;
					green_1 = qv;
					blue_1 = b;
					break;
				}

				case 4:
				{
					red_1 = tv;
					green_1 = pv;
					blue_1 = b;
					break;
				}

				case 5:
				{
					// Red is the dominant color
					red_1 = b;
					green_1 = pv;
					blue_1 = qv;
					break;
				}
			}
			return unchecked((int)(0xFF000000)) | (((int)(red_1 * 255.0f)) << 16) | (((int)(green_1
				 * 255.0f)) << 8) | ((int)(blue_1 * 255.0f));
		}

		/// <summary>Convert RGB components to HSV.</summary>
		/// <remarks>
		/// Convert RGB components to HSV.
		/// hsv[0] is Hue [0 .. 360)
		/// hsv[1] is Saturation [0...1]
		/// hsv[2] is Value [0...1]
		/// </remarks>
		/// <param name="red">red component value [0..255]</param>
		/// <param name="green">green component value [0..255]</param>
		/// <param name="blue">blue component value [0..255]</param>
		/// <param name="hsv">3 element array which holds the resulting HSV components.</param>
		public static void RGBToHSV(int red_1, int green_1, int blue_1, float[] hsv)
		{
			if (hsv.Length < 3)
			{
				throw new java.lang.RuntimeException("3 components required for hsv");
			}
			nativeRGBToHSV(red_1, green_1, blue_1, hsv);
		}

		/// <summary>Convert the argb color to its HSV components.</summary>
		/// <remarks>
		/// Convert the argb color to its HSV components.
		/// hsv[0] is Hue [0 .. 360)
		/// hsv[1] is Saturation [0...1]
		/// hsv[2] is Value [0...1]
		/// </remarks>
		/// <param name="color">the argb color to convert. The alpha component is ignored.</param>
		/// <param name="hsv">3 element array which holds the resulting HSV components.</param>
		public static void colorToHSV(int color, float[] hsv)
		{
			RGBToHSV((color >> 16) & unchecked((int)(0xFF)), (color >> 8) & unchecked((int)(0xFF
				)), color & unchecked((int)(0xFF)), hsv);
		}

		/// <summary>Convert HSV components to an ARGB color.</summary>
		/// <remarks>
		/// Convert HSV components to an ARGB color. Alpha set to 0xFF.
		/// hsv[0] is Hue [0 .. 360)
		/// hsv[1] is Saturation [0...1]
		/// hsv[2] is Value [0...1]
		/// If hsv values are out of range, they are pinned.
		/// </remarks>
		/// <param name="hsv">3 element array which holds the input HSV components.</param>
		/// <returns>the resulting argb color</returns>
		public static int HSVToColor(float[] hsv)
		{
			return HSVToColor(unchecked((int)(0xFF)), hsv);
		}

		/// <summary>Convert HSV components to an ARGB color.</summary>
		/// <remarks>
		/// Convert HSV components to an ARGB color. The alpha component is passed
		/// through unchanged.
		/// hsv[0] is Hue [0 .. 360)
		/// hsv[1] is Saturation [0...1]
		/// hsv[2] is Value [0...1]
		/// If hsv values are out of range, they are pinned.
		/// </remarks>
		/// <param name="alpha">the alpha component of the returned argb color.</param>
		/// <param name="hsv">3 element array which holds the input HSV components.</param>
		/// <returns>the resulting argb color</returns>
		public static int HSVToColor(int alpha_1, float[] hsv)
		{
			if (hsv.Length < 3)
			{
				throw new java.lang.RuntimeException("3 components required for hsv");
			}
			return nativeHSVToColor(alpha_1, hsv);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Color_Color_RGBToHSV(int red_1, int greed, 
			int blue_1, System.IntPtr hsv);

		private static void nativeRGBToHSV(int red_1, int greed, int blue_1, float[] hsv)
		{
			Sharpen.INativeHandle hsv_handle = null;
			try
			{
				hsv_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(hsv);
				libxobotos_Color_Color_RGBToHSV(red_1, greed, blue_1, hsv_handle.Address);
			}
			finally
			{
				if (hsv_handle != null)
				{
					hsv_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Color_Color_HSVToColor(int alpha_1, System.IntPtr
			 hsv);

		private static int nativeHSVToColor(int alpha_1, float[] hsv)
		{
			Sharpen.INativeHandle hsv_handle = null;
			try
			{
				hsv_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(hsv);
				return libxobotos_Color_Color_HSVToColor(alpha_1, hsv_handle.Address);
			}
			finally
			{
				if (hsv_handle != null)
				{
					hsv_handle.Free();
				}
			}
		}

		private static readonly java.util.HashMap<string, int> sColorNameMap;

		static Color()
		{
			sColorNameMap = new java.util.HashMap<string, int>();
			sColorNameMap.put("black", BLACK);
			sColorNameMap.put("darkgray", DKGRAY);
			sColorNameMap.put("gray", GRAY);
			sColorNameMap.put("lightgray", LTGRAY);
			sColorNameMap.put("white", WHITE);
			sColorNameMap.put("red", RED);
			sColorNameMap.put("green", GREEN);
			sColorNameMap.put("blue", BLUE);
			sColorNameMap.put("yellow", YELLOW);
			sColorNameMap.put("cyan", CYAN);
			sColorNameMap.put("magenta", MAGENTA);
		}
	}
}
