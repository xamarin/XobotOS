using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class TableMaskFilter : android.graphics.MaskFilter
	{
		public TableMaskFilter(byte[] table)
		{
			if (table.Length < 256)
			{
				throw new java.lang.RuntimeException("table.length must be >= 256");
			}
			native_instance = nativeNewTable(table);
		}

		private TableMaskFilter(android.graphics.MaskFilter.NativeFilter ni)
		{
			native_instance = ni;
		}

		public static android.graphics.TableMaskFilter CreateClipTable(int min, int max)
		{
			return new android.graphics.TableMaskFilter(nativeNewClip(min, max));
		}

		public static android.graphics.TableMaskFilter CreateGammaTable(float gamma)
		{
			return new android.graphics.TableMaskFilter(nativeNewGamma(gamma));
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.MaskFilter.NativeFilter libxobotos_TableMaskFilter_newTable
			(System.IntPtr table);

		private static android.graphics.MaskFilter.NativeFilter nativeNewTable(byte[] table
			)
		{
			Sharpen.INativeHandle table_handle = null;
			try
			{
				table_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(table);
				return libxobotos_TableMaskFilter_newTable(table_handle.Address);
			}
			finally
			{
				if (table_handle != null)
				{
					table_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.MaskFilter.NativeFilter libxobotos_TableMaskFilter_newClip
			(int min, int max);

		private static android.graphics.MaskFilter.NativeFilter nativeNewClip(int min, int
			 max)
		{
			return libxobotos_TableMaskFilter_newClip(min, max);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.MaskFilter.NativeFilter libxobotos_TableMaskFilter_newGamma
			(float gamma);

		private static android.graphics.MaskFilter.NativeFilter nativeNewGamma(float gamma
			)
		{
			return libxobotos_TableMaskFilter_newGamma(gamma);
		}
	}
}
