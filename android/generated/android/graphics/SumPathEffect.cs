using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class SumPathEffect : android.graphics.PathEffect
	{
		/// <summary>Construct a PathEffect whose effect is to apply two effects, in sequence.
		/// 	</summary>
		/// <remarks>
		/// Construct a PathEffect whose effect is to apply two effects, in sequence.
		/// (e.g. first(path) + second(path))
		/// </remarks>
		public SumPathEffect(android.graphics.PathEffect first, android.graphics.PathEffect
			 second)
		{
			native_instance = nativeCreate(first.native_instance, second.native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.SumPathEffect.NativePathEffect libxobotos_SumPathEffect_create
			(android.graphics.PathEffect.NativePathEffect first, android.graphics.PathEffect.NativePathEffect
			 second);

		private static android.graphics.SumPathEffect.NativePathEffect nativeCreate(android.graphics.PathEffect.NativePathEffect
			 first, android.graphics.PathEffect.NativePathEffect second)
		{
			return libxobotos_SumPathEffect_create(first, second);
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
