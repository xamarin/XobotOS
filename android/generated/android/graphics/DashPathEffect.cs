using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class DashPathEffect : android.graphics.PathEffect
	{
		/// <summary>
		/// The intervals array must contain an even number of entries (&gt;=2), with
		/// the even indices specifying the "on" intervals, and the odd indices
		/// specifying the "off" intervals.
		/// </summary>
		/// <remarks>
		/// The intervals array must contain an even number of entries (&gt;=2), with
		/// the even indices specifying the "on" intervals, and the odd indices
		/// specifying the "off" intervals. phase is an offset into the intervals
		/// array (mod the sum of all of the intervals). The intervals array
		/// controls the length of the dashes. The paint's strokeWidth controls the
		/// thickness of the dashes.
		/// Note: this patheffect only affects drawing with the paint's style is set
		/// to STROKE or STROKE_AND_FILL. It is ignored if the drawing is done with
		/// style == FILL.
		/// </remarks>
		/// <param name="intervals">array of ON and OFF distances</param>
		/// <param name="phase">offset into the intervals array</param>
		public DashPathEffect(float[] intervals, float phase)
		{
			if (intervals.Length < 2)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_instance = nativeCreate(intervals, phase);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.DashPathEffect.NativePathEffect libxobotos_DashPathEffect_Dash_constructor
			(System.IntPtr intervals, float phase);

		private static android.graphics.DashPathEffect.NativePathEffect nativeCreate(float
			[] intervals, float phase)
		{
			Sharpen.INativeHandle intervals_handle = null;
			try
			{
				intervals_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(intervals
					);
				return libxobotos_DashPathEffect_Dash_constructor(intervals_handle.Address, phase
					);
			}
			finally
			{
				if (intervals_handle != null)
				{
					intervals_handle.Free();
				}
			}
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
