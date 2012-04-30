using System;
using System.Runtime.InteropServices;

namespace XobotOS.Runtime
{
	internal static class NativeHelper
	{
		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void libxobotos_free (IntPtr ptr);

		public static string MarshalPtrToStr (IntPtr ptr)
		{
			string str = Marshal.PtrToStringAnsi (ptr);
			libxobotos_free (ptr);
			return str;
		}

		public static string MarshalPtrToWStr (IntPtr ptr)
		{
			string str = Marshal.PtrToStringUni (ptr);
			libxobotos_free (ptr);
			return str;
		}
	}
}

