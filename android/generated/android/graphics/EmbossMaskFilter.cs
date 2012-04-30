using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class EmbossMaskFilter : android.graphics.MaskFilter
	{
		/// <summary>Create an emboss maskfilter</summary>
		/// <param name="direction">array of 3 scalars [x, y, z] specifying the direction of the light source
		/// 	</param>
		/// <param name="ambient">0...1 amount of ambient light</param>
		/// <param name="specular">coefficient for specular highlights (e.g. 8)</param>
		/// <param name="blurRadius">amount to blur before applying lighting (e.g. 3)</param>
		/// <returns>the emboss maskfilter</returns>
		public EmbossMaskFilter(float[] direction, float ambient, float specular, float blurRadius
			)
		{
			if (direction.Length < 3)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_instance = nativeConstructor(direction, ambient, specular, blurRadius);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.MaskFilter.NativeFilter libxobotos_EmbossMaskFilter_constructor
			(System.IntPtr direction, float ambient, float specular, float blurRadius);

		private static android.graphics.MaskFilter.NativeFilter nativeConstructor(float[]
			 direction, float ambient, float specular, float blurRadius)
		{
			Sharpen.INativeHandle direction_handle = null;
			try
			{
				direction_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(direction
					);
				return libxobotos_EmbossMaskFilter_constructor(direction_handle.Address, ambient, 
					specular, blurRadius);
			}
			finally
			{
				if (direction_handle != null)
				{
					direction_handle.Free();
				}
			}
		}
	}
}
