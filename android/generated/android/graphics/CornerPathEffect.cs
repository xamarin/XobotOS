using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class CornerPathEffect : android.graphics.PathEffect
	{
		/// <summary>
		/// Transforms geometries that are drawn (either STROKE or FILL styles) by
		/// replacing any sharp angles between line segments into rounded angles of
		/// the specified radius.
		/// </summary>
		/// <remarks>
		/// Transforms geometries that are drawn (either STROKE or FILL styles) by
		/// replacing any sharp angles between line segments into rounded angles of
		/// the specified radius.
		/// </remarks>
		/// <param name="radius">Amount to round sharp angles between line segments.</param>
		public CornerPathEffect(float radius)
		{
			native_instance = nativeCreate(radius);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.CornerPathEffect.NativePathEffect libxobotos_CornerPathEffect_create
			(float radius);

		private static android.graphics.CornerPathEffect.NativePathEffect nativeCreate(float
			 radius)
		{
			return libxobotos_CornerPathEffect_create(radius);
		}

		internal class NativePathEffect : android.graphics.PathEffect.NativePathEffect
		{
			internal NativePathEffect()
			{
			}

			internal NativePathEffect(System.IntPtr handle)
			{
				this.handle = handle;
			}
		}
	}
}
