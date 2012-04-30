using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class LayerRasterizer : android.graphics.Rasterizer
	{
		public LayerRasterizer()
		{
			native_instance = nativeConstructor();
		}

		/// <summary>Add a new layer (above any previous layers) to the rasterizer.</summary>
		/// <remarks>
		/// Add a new layer (above any previous layers) to the rasterizer.
		/// The layer will extract those fields that affect the mask from
		/// the specified paint, but will not retain a reference to the paint
		/// object itself, so it may be reused without danger of side-effects.
		/// </remarks>
		public virtual void addLayer(android.graphics.Paint paint, float dx, float dy)
		{
			nativeAddLayer(native_instance, paint.mNativePaint, dx, dy);
		}

		public virtual void addLayer(android.graphics.Paint paint)
		{
			nativeAddLayer(native_instance, paint.mNativePaint, 0, 0);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Rasterizer.NativeRasterizer libxobotos_LayerRasterizer_LayerRasterizer_create
			();

		private static android.graphics.Rasterizer.NativeRasterizer nativeConstructor()
		{
			return libxobotos_LayerRasterizer_LayerRasterizer_create();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_LayerRasterizer_LayerRasterizer_addLayer(android.graphics.Rasterizer.NativeRasterizer
			 native_layer, android.graphics.Paint.NativePaint native_paint, float dx, float 
			dy);

		private static void nativeAddLayer(android.graphics.Rasterizer.NativeRasterizer native_layer
			, android.graphics.Paint.NativePaint native_paint, float dx, float dy)
		{
			libxobotos_LayerRasterizer_LayerRasterizer_addLayer(native_layer, native_paint, dx
				, dy);
		}
	}
}
