using System.Runtime.InteropServices;

namespace XobotOS.Runtime
{
	internal static class MarshalGlue
	{
		[Sharpen.MarshalHelper(@"NativeString")]
		internal static class String_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct String_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(String_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, string arg)
			{
				String_Struct obj = new String_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				obj.ptr = Marshal.StringToHGlobalUni(arg);
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, string arg)
			{
				String_Struct obj = (String_Struct)Marshal.PtrToStructure(ptr, typeof(String_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
			}

			public static System.IntPtr ManagedToNative(string arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(String_Struct)));
				XobotOS.Runtime.MarshalGlue.String_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static string NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				String_Struct obj = (String_Struct)Marshal.PtrToStructure(ptr, typeof(String_Struct
					));
				string arg = Marshal.PtrToStringUni(obj.ptr, obj.length);
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_XobotOS_MarshalGlue_String_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_XobotOS_MarshalGlue_String_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				String_Struct obj = (String_Struct)Marshal.PtrToStructure(ptr, typeof(String_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
				Marshal.FreeHGlobal(obj.ptr);
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<long>")]
		internal static class Array_long_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_long_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_long_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, long[] arg)
			{
				Array_long_Struct obj = new Array_long_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + XobotOS.Runtime.MarshalGlue.Array_long_Helper.NativeSize;
					Marshal.Copy(arg, 0, obj.ptr, arg.Length);
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, long[] arg)
			{
				Array_long_Struct obj = (Array_long_Struct)Marshal.PtrToStructure(ptr, typeof(Array_long_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				throw new System.InvalidOperationException();
			}

			public static System.IntPtr ManagedToNative(long[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(XobotOS.Runtime.MarshalGlue.Array_long_Helper
					.NativeSize + Marshal.SizeOf(typeof(long)) * arg.Length);
				XobotOS.Runtime.MarshalGlue.Array_long_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static long[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_long_Struct obj = (Array_long_Struct)Marshal.PtrToStructure(ptr, typeof(Array_long_Struct
					));
				long[] arg = new long[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				Marshal.Copy(obj.ptr, arg, 0, obj.length);
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_XobotOS_MarshalGlue_Array_long_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_XobotOS_MarshalGlue_Array_long_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_long_Struct obj = (Array_long_Struct)Marshal.PtrToStructure(ptr, typeof(Array_long_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				XobotOS.Runtime.MarshalGlue.Array_long_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}

			internal struct PinnedHandle : Sharpen.INativeHandle
			{
				public GCHandle handle;

				public System.IntPtr ptr;

				public System.IntPtr Address
				{
					get
					{
						return ptr;
					}
				}

				public void Free()
				{
					handle.Free();
					handle_array_ptr.Free();
				}

				public GCHandle handle_array_ptr;
			}

			public static Sharpen.INativeHandle GetPinnedPtr(long[] arg)
			{
				if (arg == null)
				{
					return null;
				}
				PinnedHandle pinned = new PinnedHandle();
				Array_long_Struct obj = new Array_long_Struct();
				obj._owner = 0x337b4904;
				obj.length = arg.Length;
				{
					pinned.handle_array_ptr = GCHandle.Alloc(arg, GCHandleType.Pinned);
					obj.ptr = pinned.handle_array_ptr.AddrOfPinnedObject();
				}
				pinned.handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
				pinned.ptr = pinned.handle.AddrOfPinnedObject();
				return pinned;
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<float>")]
		internal static class Array_float_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_float_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_float_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, float[] arg)
			{
				Array_float_Struct obj = new Array_float_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + XobotOS.Runtime.MarshalGlue.Array_float_Helper.NativeSize;
					Marshal.Copy(arg, 0, obj.ptr, arg.Length);
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, float[] arg)
			{
				Array_float_Struct obj = (Array_float_Struct)Marshal.PtrToStructure(ptr, typeof(Array_float_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				throw new System.InvalidOperationException();
			}

			public static System.IntPtr ManagedToNative(float[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(XobotOS.Runtime.MarshalGlue.Array_float_Helper
					.NativeSize + Marshal.SizeOf(typeof(float)) * arg.Length);
				XobotOS.Runtime.MarshalGlue.Array_float_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static float[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_float_Struct obj = (Array_float_Struct)Marshal.PtrToStructure(ptr, typeof(Array_float_Struct
					));
				float[] arg = new float[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				Marshal.Copy(obj.ptr, arg, 0, obj.length);
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_XobotOS_MarshalGlue_Array_float_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_XobotOS_MarshalGlue_Array_float_destructor(
				System.IntPtr ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_float_Struct obj = (Array_float_Struct)Marshal.PtrToStructure(ptr, typeof(Array_float_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				XobotOS.Runtime.MarshalGlue.Array_float_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}

			internal struct PinnedHandle : Sharpen.INativeHandle
			{
				public GCHandle handle;

				public System.IntPtr ptr;

				public System.IntPtr Address
				{
					get
					{
						return ptr;
					}
				}

				public void Free()
				{
					handle.Free();
					handle_array_ptr.Free();
				}

				public GCHandle handle_array_ptr;
			}

			public static Sharpen.INativeHandle GetPinnedPtr(float[] arg)
			{
				if (arg == null)
				{
					return null;
				}
				PinnedHandle pinned = new PinnedHandle();
				Array_float_Struct obj = new Array_float_Struct();
				obj._owner = 0x337b4904;
				obj.length = arg.Length;
				{
					pinned.handle_array_ptr = GCHandle.Alloc(arg, GCHandleType.Pinned);
					obj.ptr = pinned.handle_array_ptr.AddrOfPinnedObject();
				}
				pinned.handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
				pinned.ptr = pinned.handle.AddrOfPinnedObject();
				return pinned;
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<int>")]
		internal static class Array_int_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_int_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_int_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, int[] arg)
			{
				Array_int_Struct obj = new Array_int_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + XobotOS.Runtime.MarshalGlue.Array_int_Helper.NativeSize;
					Marshal.Copy(arg, 0, obj.ptr, arg.Length);
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, int[] arg)
			{
				Array_int_Struct obj = (Array_int_Struct)Marshal.PtrToStructure(ptr, typeof(Array_int_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				throw new System.InvalidOperationException();
			}

			public static System.IntPtr ManagedToNative(int[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(XobotOS.Runtime.MarshalGlue.Array_int_Helper
					.NativeSize + Marshal.SizeOf(typeof(int)) * arg.Length);
				XobotOS.Runtime.MarshalGlue.Array_int_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static int[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_int_Struct obj = (Array_int_Struct)Marshal.PtrToStructure(ptr, typeof(Array_int_Struct
					));
				int[] arg = new int[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				Marshal.Copy(obj.ptr, arg, 0, obj.length);
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_XobotOS_MarshalGlue_Array_int_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_XobotOS_MarshalGlue_Array_int_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_int_Struct obj = (Array_int_Struct)Marshal.PtrToStructure(ptr, typeof(Array_int_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				XobotOS.Runtime.MarshalGlue.Array_int_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}

			internal struct PinnedHandle : Sharpen.INativeHandle
			{
				public GCHandle handle;

				public System.IntPtr ptr;

				public System.IntPtr Address
				{
					get
					{
						return ptr;
					}
				}

				public void Free()
				{
					handle.Free();
					handle_array_ptr.Free();
				}

				public GCHandle handle_array_ptr;
			}

			public static Sharpen.INativeHandle GetPinnedPtr(int[] arg)
			{
				if (arg == null)
				{
					return null;
				}
				PinnedHandle pinned = new PinnedHandle();
				Array_int_Struct obj = new Array_int_Struct();
				obj._owner = 0x337b4904;
				obj.length = arg.Length;
				{
					pinned.handle_array_ptr = GCHandle.Alloc(arg, GCHandleType.Pinned);
					obj.ptr = pinned.handle_array_ptr.AddrOfPinnedObject();
				}
				pinned.handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
				pinned.ptr = pinned.handle.AddrOfPinnedObject();
				return pinned;
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<uint8_t>")]
		internal static class Array_byte_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_byte_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_byte_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, byte[] arg)
			{
				Array_byte_Struct obj = new Array_byte_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + XobotOS.Runtime.MarshalGlue.Array_byte_Helper.NativeSize;
					Marshal.Copy(arg, 0, obj.ptr, arg.Length);
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, byte[] arg)
			{
				Array_byte_Struct obj = (Array_byte_Struct)Marshal.PtrToStructure(ptr, typeof(Array_byte_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				throw new System.InvalidOperationException();
			}

			public static System.IntPtr ManagedToNative(byte[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(XobotOS.Runtime.MarshalGlue.Array_byte_Helper
					.NativeSize + Marshal.SizeOf(typeof(byte)) * arg.Length);
				XobotOS.Runtime.MarshalGlue.Array_byte_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static byte[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_byte_Struct obj = (Array_byte_Struct)Marshal.PtrToStructure(ptr, typeof(Array_byte_Struct
					));
				byte[] arg = new byte[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				Marshal.Copy(obj.ptr, arg, 0, obj.length);
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_XobotOS_MarshalGlue_Array_byte_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_XobotOS_MarshalGlue_Array_byte_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_byte_Struct obj = (Array_byte_Struct)Marshal.PtrToStructure(ptr, typeof(Array_byte_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				XobotOS.Runtime.MarshalGlue.Array_byte_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}

			internal struct PinnedHandle : Sharpen.INativeHandle
			{
				public GCHandle handle;

				public System.IntPtr ptr;

				public System.IntPtr Address
				{
					get
					{
						return ptr;
					}
				}

				public void Free()
				{
					handle.Free();
					handle_array_ptr.Free();
				}

				public GCHandle handle_array_ptr;
			}

			public static Sharpen.INativeHandle GetPinnedPtr(byte[] arg)
			{
				if (arg == null)
				{
					return null;
				}
				PinnedHandle pinned = new PinnedHandle();
				Array_byte_Struct obj = new Array_byte_Struct();
				obj._owner = 0x337b4904;
				obj.length = arg.Length;
				{
					pinned.handle_array_ptr = GCHandle.Alloc(arg, GCHandleType.Pinned);
					obj.ptr = pinned.handle_array_ptr.AddrOfPinnedObject();
				}
				pinned.handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
				pinned.ptr = pinned.handle.AddrOfPinnedObject();
				return pinned;
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<char16_t>")]
		internal static class Array_char_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_char_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_char_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, char[] arg)
			{
				Array_char_Struct obj = new Array_char_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + XobotOS.Runtime.MarshalGlue.Array_char_Helper.NativeSize;
					Marshal.Copy(arg, 0, obj.ptr, arg.Length);
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, char[] arg)
			{
				Array_char_Struct obj = (Array_char_Struct)Marshal.PtrToStructure(ptr, typeof(Array_char_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				throw new System.InvalidOperationException();
			}

			public static System.IntPtr ManagedToNative(char[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(XobotOS.Runtime.MarshalGlue.Array_char_Helper
					.NativeSize + Marshal.SizeOf(typeof(char)) * arg.Length);
				XobotOS.Runtime.MarshalGlue.Array_char_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static char[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_char_Struct obj = (Array_char_Struct)Marshal.PtrToStructure(ptr, typeof(Array_char_Struct
					));
				char[] arg = new char[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				Marshal.Copy(obj.ptr, arg, 0, obj.length);
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_XobotOS_MarshalGlue_Array_char_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_XobotOS_MarshalGlue_Array_char_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_char_Struct obj = (Array_char_Struct)Marshal.PtrToStructure(ptr, typeof(Array_char_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				XobotOS.Runtime.MarshalGlue.Array_char_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}

			internal struct PinnedHandle : Sharpen.INativeHandle
			{
				public GCHandle handle;

				public System.IntPtr ptr;

				public System.IntPtr Address
				{
					get
					{
						return ptr;
					}
				}

				public void Free()
				{
					handle.Free();
					handle_array_ptr.Free();
				}

				public GCHandle handle_array_ptr;
			}

			public static Sharpen.INativeHandle GetPinnedPtr(char[] arg)
			{
				if (arg == null)
				{
					return null;
				}
				PinnedHandle pinned = new PinnedHandle();
				Array_char_Struct obj = new Array_char_Struct();
				obj._owner = 0x337b4904;
				obj.length = arg.Length;
				{
					pinned.handle_array_ptr = GCHandle.Alloc(arg, GCHandleType.Pinned);
					obj.ptr = pinned.handle_array_ptr.AddrOfPinnedObject();
				}
				pinned.handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
				pinned.ptr = pinned.handle.AddrOfPinnedObject();
				return pinned;
			}
		}
	}
}
