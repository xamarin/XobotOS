using System.Runtime.InteropServices;
using Sharpen;

namespace martin
{
	[Sharpen.Sharpened]
	public class Test : System.IDisposable
	{
		public static void run()
		{
			martin.Test.Foo foo_1 = new martin.Test.Foo();
			foo_1.hello = 128;
			foo_1.a = new int[] { 3, 5, 11, 28 };
			hello(foo_1.a);
			if (foo_1.a[0] != 999)
			{
				throw new System.InvalidOperationException();
			}
			foo(foo_1);
			martin.Test.Foo[] bar_1 = new martin.Test.Foo[] { foo_1 };
			bar(bar_1);
			outFunc(foo_1);
			java.io.Console.Out.printf("%x\n", foo_1.hello);
			if (foo_1.hello != unchecked((int)(0x87654321)))
			{
				throw new System.InvalidOperationException();
			}
			martin.Test.Foo ret = retFunc();
			java.io.Console.Out.printf("%x\n", ret.hello);
			if (ret.hello != unchecked((int)(0xdeadbeaf)))
			{
				throw new System.InvalidOperationException();
			}
			martin.Test.Blittable blittable = new martin.Test.Blittable();
			blittable.hello = unchecked((int)(0x12345678));
			java.io.Console.Out.println("Blittable test!");
			blittableFunc(blittable);
			java.io.Console.Out.printf("%x\n", blittable.hello);
			blittableRef(blittable);
			java.io.Console.Out.printf("%x\n", blittable.hello);
			if (blittable.hello != unchecked((int)(0xdeadbeaf)))
			{
				throw new System.InvalidOperationException();
			}
			martin.Test.Complex c = complexRet();
			complex(c);
			stringFunc("Hello World!");
			java.io.Console.Out.println("Calling stringArray()");
			dumpMemoryUsage();
			stringArray(new string[] { "Hello", "World" });
			java.io.Console.Out.println("Done calling stringArray()");
			dumpMemoryUsage();
			string testStr = returnString();
			java.io.Console.Out.printf("Got string: |%s|\n", testStr);
			dumpMemoryUsage();
			string[] strArray = returnStringArray();
			java.io.Console.Out.printf("Got string array: %d\n", strArray.Length);
			foreach (string str in strArray)
			{
				java.io.Console.Out.println(str);
			}
			dumpMemoryUsage();
			int[] intArray = returnIntArray();
			java.io.Console.Out.printf("Got int array: %d (%d,%d)\n", intArray.Length, intArray
				[0], intArray[1]);
			dumpMemoryUsage();
		}

		internal Test.NativeTest mObject;

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_dumpMemoryUsage();

		internal static void dumpMemoryUsage()
		{
			libxobotos_Test_dumpMemoryUsage();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_hello(System.IntPtr a);

		internal static void hello(int[] a)
		{
			Sharpen.INativeHandle a_handle = null;
			try
			{
				a_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(a);
				libxobotos_Test_hello(a_handle.Address);
			}
			finally
			{
				if (a_handle != null)
				{
					a_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_foo(System.IntPtr arg);

		internal static void foo(martin.Test.Foo arg)
		{
			System.IntPtr arg_ptr = System.IntPtr.Zero;
			try
			{
				arg_ptr = martin.Test.Foo.Foo_Helper.ManagedToNative(arg);
				libxobotos_Test_foo(arg_ptr);
			}
			finally
			{
				martin.Test.Foo.Foo_Helper.FreeManagedPtr(arg_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_bar(System.IntPtr arg);

		internal static void bar(martin.Test.Foo[] arg)
		{
			System.IntPtr arg_ptr = System.IntPtr.Zero;
			try
			{
				arg_ptr = Array_Foo_Helper.ManagedToNative(arg);
				libxobotos_Test_bar(arg_ptr);
			}
			finally
			{
				Array_Foo_Helper.FreeManagedPtr(arg_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_refFunc(System.IntPtr arg);

		internal static void refFunc(martin.Test.Foo arg)
		{
			System.IntPtr arg_ptr = System.IntPtr.Zero;
			try
			{
				arg_ptr = martin.Test.Foo.Foo_Helper.ManagedToNative(arg);
				libxobotos_Test_refFunc(arg_ptr);
				martin.Test.Foo.Foo_Helper.MarshalOut(arg_ptr, arg);
			}
			finally
			{
				martin.Test.Foo.Foo_Helper.FreeManagedPtr(arg_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_outFunc(out System.IntPtr arg);

		internal static void outFunc(martin.Test.Foo arg)
		{
			System.IntPtr arg_ptr = System.IntPtr.Zero;
			try
			{
				libxobotos_Test_outFunc(out arg_ptr);
				martin.Test.Foo.Foo_Helper.MarshalOut(arg_ptr, arg);
			}
			finally
			{
				martin.Test.Foo.Foo_Helper.FreeNativePtr(arg_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_Test_retFunc();

		internal static martin.Test.Foo retFunc()
		{
			System.IntPtr _retval_ptr = libxobotos_Test_retFunc();
			martin.Test.Foo _retval = martin.Test.Foo.Foo_Helper.NativeToManaged(_retval_ptr);
			martin.Test.Foo.Foo_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_blittableFunc(System.IntPtr arg);

		internal static void blittableFunc(martin.Test.Blittable arg)
		{
			System.IntPtr arg_ptr = System.IntPtr.Zero;
			try
			{
				arg_ptr = martin.Test.Blittable.Blittable_Helper.ManagedToNative(arg);
				libxobotos_Test_blittableFunc(arg_ptr);
			}
			finally
			{
				martin.Test.Blittable.Blittable_Helper.FreeManagedPtr(arg_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_blittableRef(System.IntPtr arg);

		internal static void blittableRef(martin.Test.Blittable arg)
		{
			System.IntPtr arg_ptr = System.IntPtr.Zero;
			try
			{
				arg_ptr = martin.Test.Blittable.Blittable_Helper.ManagedToNative(arg);
				libxobotos_Test_blittableRef(arg_ptr);
				martin.Test.Blittable.Blittable_Helper.MarshalOut(arg_ptr, arg);
			}
			finally
			{
				martin.Test.Blittable.Blittable_Helper.FreeManagedPtr(arg_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_complex(System.IntPtr arg);

		internal static void complex(martin.Test.Complex arg)
		{
			System.IntPtr arg_ptr = System.IntPtr.Zero;
			try
			{
				arg_ptr = martin.Test.Complex.Complex_Helper.ManagedToNative(arg);
				libxobotos_Test_complex(arg_ptr);
			}
			finally
			{
				martin.Test.Complex.Complex_Helper.FreeManagedPtr(arg_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_Test_complexRet();

		internal static martin.Test.Complex complexRet()
		{
			System.IntPtr _retval_ptr = libxobotos_Test_complexRet();
			martin.Test.Complex _retval = martin.Test.Complex.Complex_Helper.NativeToManaged(
				_retval_ptr);
			martin.Test.Complex.Complex_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_stringFunc(System.IntPtr str);

		internal static void stringFunc(string str)
		{
			System.IntPtr str_ptr = System.IntPtr.Zero;
			try
			{
				str_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(str);
				libxobotos_Test_stringFunc(str_ptr);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(str_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Test_stringArray(System.IntPtr array);

		internal static void stringArray(string[] array)
		{
			System.IntPtr array_ptr = System.IntPtr.Zero;
			try
			{
				array_ptr = Array_String_Helper.ManagedToNative(array);
				libxobotos_Test_stringArray(array_ptr);
			}
			finally
			{
				Array_String_Helper.FreeManagedPtr(array_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_Test_returnString();

		internal static string returnString()
		{
			System.IntPtr _retval_ptr = libxobotos_Test_returnString();
			string _retval = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_Test_returnStringArray();

		internal static string[] returnStringArray()
		{
			System.IntPtr _retval_ptr = libxobotos_Test_returnStringArray();
			string[] _retval = Array_String_Helper.NativeToManaged(_retval_ptr);
			Array_String_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_Test_returnIntArray();

		internal static int[] returnIntArray()
		{
			System.IntPtr _retval_ptr = libxobotos_Test_returnIntArray();
			int[] _retval = XobotOS.Runtime.MarshalGlue.Array_int_Helper.NativeToManaged(_retval_ptr
				);
			XobotOS.Runtime.MarshalGlue.Array_int_Helper.FreeNativePtr(_retval_ptr);
			return _retval;
		}

		internal class Foo
		{
			public int hello;

			public int[] a;

			[Sharpen.MarshalHelper(@"MartinTest::Foo")]
			internal static class Foo_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct Foo_Struct
				{
					public uint _owner;

					public int hello;

					public System.IntPtr a;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(Foo_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, martin.Test.Foo arg)
				{
					Foo_Struct obj = new Foo_Struct();
					obj._owner = 0x972f3813;
					obj.hello = arg.hello;
					obj.a = XobotOS.Runtime.MarshalGlue.Array_int_Helper.ManagedToNative(arg.a);
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, martin.Test.Foo arg)
				{
					Foo_Struct obj = (Foo_Struct)Marshal.PtrToStructure(ptr, typeof(Foo_Struct));
					arg.hello = obj.hello;
					arg.a = XobotOS.Runtime.MarshalGlue.Array_int_Helper.NativeToManaged(obj.a);
				}

				public static System.IntPtr ManagedToNative(martin.Test.Foo arg)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Foo_Struct)));
					martin.Test.Foo.Foo_Helper.MarshalIn(ptr, arg);
					return ptr;
				}

				public static martin.Test.Foo NativeToManaged(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					Foo_Struct obj = (Foo_Struct)Marshal.PtrToStructure(ptr, typeof(Foo_Struct));
					martin.Test.Foo arg = new martin.Test.Foo();
					arg.hello = obj.hello;
					arg.a = XobotOS.Runtime.MarshalGlue.Array_int_Helper.NativeToManaged(obj.a);
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_martin_Test_Foo_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_martin_Test_Foo_destructor(System.IntPtr ptr
					);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					Foo_Struct obj = (Foo_Struct)Marshal.PtrToStructure(ptr, typeof(Foo_Struct));
					if (obj._owner != 0x972f3813)
					{
						throw new System.InvalidOperationException();
					}
					XobotOS.Runtime.MarshalGlue.Array_int_Helper.FreeManagedPtr(obj.a);
				}

				public static void FreeManagedPtr(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return;
					}
					martin.Test.Foo.Foo_Helper.FreeManagedPtr_inner(ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		internal class Blittable
		{
			public int hello;

			[Sharpen.MarshalHelper(@"MartinTest::Blittable")]
			internal static class Blittable_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct Blittable_Struct
				{
					public uint _owner;

					public int hello;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(Blittable_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, martin.Test.Blittable arg)
				{
					Blittable_Struct obj = new Blittable_Struct();
					obj._owner = 0x972f3813;
					obj.hello = arg.hello;
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, martin.Test.Blittable arg)
				{
					Blittable_Struct obj = (Blittable_Struct)Marshal.PtrToStructure(ptr, typeof(Blittable_Struct
						));
					arg.hello = obj.hello;
				}

				public static System.IntPtr ManagedToNative(martin.Test.Blittable arg)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Blittable_Struct))
						);
					martin.Test.Blittable.Blittable_Helper.MarshalIn(ptr, arg);
					return ptr;
				}

				public static martin.Test.Blittable NativeToManaged(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					Blittable_Struct obj = (Blittable_Struct)Marshal.PtrToStructure(ptr, typeof(Blittable_Struct
						));
					martin.Test.Blittable arg = new martin.Test.Blittable();
					arg.hello = obj.hello;
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_martin_Test_Blittable_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_martin_Test_Blittable_destructor(System.IntPtr
					 ptr);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					Blittable_Struct obj = (Blittable_Struct)Marshal.PtrToStructure(ptr, typeof(Blittable_Struct
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
					martin.Test.Blittable.Blittable_Helper.FreeManagedPtr_inner(ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		internal class Complex
		{
			internal martin.Test.Foo[] foo;

			public string str;

			[Sharpen.MarshalHelper(@"MartinTest::Complex")]
			internal static class Complex_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct Complex_Struct
				{
					public uint _owner;

					public System.IntPtr foo;

					public System.IntPtr str;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(Complex_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, martin.Test.Complex arg)
				{
					Complex_Struct obj = new Complex_Struct();
					obj._owner = 0x972f3813;
					obj.foo = Array_Foo_Helper.ManagedToNative(arg.foo);
					obj.str = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(arg.str);
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, martin.Test.Complex arg)
				{
					Complex_Struct obj = (Complex_Struct)Marshal.PtrToStructure(ptr, typeof(Complex_Struct
						));
					arg.foo = Array_Foo_Helper.NativeToManaged(obj.foo);
					arg.str = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(obj.str);
				}

				public static System.IntPtr ManagedToNative(martin.Test.Complex arg)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Complex_Struct)));
					martin.Test.Complex.Complex_Helper.MarshalIn(ptr, arg);
					return ptr;
				}

				public static martin.Test.Complex NativeToManaged(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					Complex_Struct obj = (Complex_Struct)Marshal.PtrToStructure(ptr, typeof(Complex_Struct
						));
					martin.Test.Complex arg = new martin.Test.Complex();
					arg.foo = Array_Foo_Helper.NativeToManaged(obj.foo);
					arg.str = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(obj.str);
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_martin_Test_Complex_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_martin_Test_Complex_destructor(System.IntPtr
					 ptr);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					Complex_Struct obj = (Complex_Struct)Marshal.PtrToStructure(ptr, typeof(Complex_Struct
						));
					if (obj._owner != 0x972f3813)
					{
						throw new System.InvalidOperationException();
					}
					Array_Foo_Helper.FreeManagedPtr(obj.foo);
					XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(obj.str);
				}

				public static void FreeManagedPtr(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return;
					}
					martin.Test.Complex.Complex_Helper.FreeManagedPtr_inner(ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		[Sharpen.MarshalHelper(@"NativePtrArray<NativeString>")]
		internal static class Array_String_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_String_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_String_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, string[] arg)
			{
				Array_String_Struct obj = new Array_String_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + Array_String_Helper.NativeSize;
					System.IntPtr[] vector = new System.IntPtr[arg.Length];
					for (int i = 0; i < arg.Length; i++)
					{
						vector[i] = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(arg[i]);
					}
					Marshal.Copy(vector, 0, obj.ptr, arg.Length);
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, string[] arg)
			{
				Array_String_Struct obj = (Array_String_Struct)Marshal.PtrToStructure(ptr, typeof(
					Array_String_Struct));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += XobotOS.Runtime.MarshalGlue.String_Helper
						.NativeSize)
					{
						XobotOS.Runtime.MarshalGlue.String_Helper.MarshalOut(addr, arg[i]);
					}
				}
			}

			public static System.IntPtr ManagedToNative(string[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Array_String_Helper.NativeSize + Marshal.SizeOf
					(typeof(System.IntPtr)) * arg.Length);
				Array_String_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static string[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_String_Struct obj = (Array_String_Struct)Marshal.PtrToStructure(ptr, typeof(
					Array_String_Struct));
				string[] arg = new string[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr[] vector = new System.IntPtr[obj.length];
					Marshal.Copy(obj.ptr, vector, 0, obj.length);
					for (int i = 0; i < obj.length; i++)
					{
						arg[i] = XobotOS.Runtime.MarshalGlue.String_Helper.NativeToManaged(vector[i]);
					}
				}
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_martin_Test_Array_String_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_martin_Test_Array_String_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_String_Struct obj = (Array_String_Struct)Marshal.PtrToStructure(ptr, typeof(
					Array_String_Struct));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr[] vector = new System.IntPtr[obj.length];
					Marshal.Copy(obj.ptr, vector, 0, obj.length);
					for (int i = 0; i < obj.length; i++)
					{
						XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(vector[i]);
					}
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				Array_String_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<MartinTest::Foo>")]
		internal static class Array_Foo_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_Foo_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_Foo_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, martin.Test.Foo[] arg)
			{
				Array_Foo_Struct obj = new Array_Foo_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + Array_Foo_Helper.NativeSize;
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < arg.Length; i++, addr += martin.Test.Foo.Foo_Helper.NativeSize)
					{
						martin.Test.Foo.Foo_Helper.MarshalIn(addr, arg[i]);
					}
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, martin.Test.Foo[] arg)
			{
				Array_Foo_Struct obj = (Array_Foo_Struct)Marshal.PtrToStructure(ptr, typeof(Array_Foo_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += martin.Test.Foo.Foo_Helper.NativeSize)
					{
						martin.Test.Foo.Foo_Helper.MarshalOut(addr, arg[i]);
					}
				}
			}

			public static System.IntPtr ManagedToNative(martin.Test.Foo[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Array_Foo_Helper.NativeSize + martin.Test.Foo
					.Foo_Helper.NativeSize * arg.Length);
				Array_Foo_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static martin.Test.Foo[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_Foo_Struct obj = (Array_Foo_Struct)Marshal.PtrToStructure(ptr, typeof(Array_Foo_Struct
					));
				martin.Test.Foo[] arg = new martin.Test.Foo[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += martin.Test.Foo.Foo_Helper.NativeSize)
					{
						arg[i] = martin.Test.Foo.Foo_Helper.NativeToManaged(addr);
					}
				}
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_martin_Test_Array_Foo_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_martin_Test_Array_Foo_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_Foo_Struct obj = (Array_Foo_Struct)Marshal.PtrToStructure(ptr, typeof(Array_Foo_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += martin.Test.Foo.Foo_Helper.NativeSize)
					{
						martin.Test.Foo.Foo_Helper.FreeManagedPtr_inner(addr);
					}
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				Array_Foo_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}

		public void Dispose()
		{
			mObject.Dispose();
		}

		internal class NativeTest : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeTest() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeTest(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_martin_Test_destructor(System.IntPtr handle
				);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeTest Zero = new NativeTest();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_martin_Test_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
