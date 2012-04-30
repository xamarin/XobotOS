using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class ComposePathEffect : android.graphics.PathEffect
	{
		/// <summary>
		/// Construct a PathEffect whose effect is to apply first the inner effect
		/// and the the outer pathEffect (e.g.
		/// </summary>
		/// <remarks>
		/// Construct a PathEffect whose effect is to apply first the inner effect
		/// and the the outer pathEffect (e.g. outer(inner(path))).
		/// </remarks>
		public ComposePathEffect(android.graphics.PathEffect outerpe, android.graphics.PathEffect
			 innerpe)
		{
			native_instance = nativeCreate(outerpe.native_instance, innerpe.native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.ComposePathEffect.NativePathEffect libxobotos_ComposePathEffect_create
			(android.graphics.PathEffect.NativePathEffect outerpe, android.graphics.PathEffect.NativePathEffect
			 innerpe);

		private static android.graphics.ComposePathEffect.NativePathEffect nativeCreate(android.graphics.PathEffect.NativePathEffect
			 outerpe, android.graphics.PathEffect.NativePathEffect innerpe)
		{
			return libxobotos_ComposePathEffect_create(outerpe, innerpe);
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
