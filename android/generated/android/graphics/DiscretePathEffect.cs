using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class DiscretePathEffect : android.graphics.PathEffect
	{
		/// <summary>
		/// Chop the path into lines of segmentLength, randomly deviating from the
		/// original path by deviation.
		/// </summary>
		/// <remarks>
		/// Chop the path into lines of segmentLength, randomly deviating from the
		/// original path by deviation.
		/// </remarks>
		public DiscretePathEffect(float segmentLength, float deviation)
		{
			native_instance = nativeCreate(segmentLength, deviation);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.DiscretePathEffect.NativePathEffect libxobotos_DiscretePathEffect_create
			(float length, float deviation);

		private static android.graphics.DiscretePathEffect.NativePathEffect nativeCreate(
			float length, float deviation)
		{
			return libxobotos_DiscretePathEffect_create(length, deviation);
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
