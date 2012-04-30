using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class RegionIterator : System.IDisposable
	{
		/// <summary>Construct an iterator for all of the rectangles in a region.</summary>
		/// <remarks>
		/// Construct an iterator for all of the rectangles in a region. This
		/// effectively makes a private copy of the region, so any subsequent edits
		/// to region will not affect the iterator.
		/// </remarks>
		/// <param name="region">the region that will be iterated</param>
		public RegionIterator(android.graphics.Region region)
		{
			mNativeIter = nativeConstructor(region.nativeInstance);
		}

		/// <summary>Return the next rectangle in the region.</summary>
		/// <remarks>
		/// Return the next rectangle in the region. If there are no more rectangles
		/// this returns false and r is unchanged. If there is at least one more,
		/// this returns true and r is set to that rectangle.
		/// </remarks>
		public bool next(android.graphics.Rect r)
		{
			if (r == null)
			{
				throw new System.ArgumentNullException("The Rect must be provided");
			}
			return nativeNext(mNativeIter, r);
		}

		~RegionIterator()
		{
			nativeDestructor(mNativeIter);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.RegionIterator.NativeRegionIterator libxobotos_RegionIterator_constructor
			(android.graphics.Region.NativeRegion native_region);

		private static android.graphics.RegionIterator.NativeRegionIterator nativeConstructor
			(android.graphics.Region.NativeRegion native_region)
		{
			return libxobotos_RegionIterator_constructor(native_region);
		}

		private static void nativeDestructor(android.graphics.RegionIterator.NativeRegionIterator
			 native_iter)
		{
			native_iter.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_RegionIterator_next(android.graphics.RegionIterator.NativeRegionIterator
			 native_iter, out System.IntPtr r);

		private static bool nativeNext(android.graphics.RegionIterator.NativeRegionIterator
			 native_iter, android.graphics.Rect r)
		{
			System.IntPtr r_ptr = System.IntPtr.Zero;
			try
			{
				bool _retval = libxobotos_RegionIterator_next(native_iter, out r_ptr);
				android.graphics.Rect.Rect_Helper.MarshalOut(r_ptr, r);
				return _retval;
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeNativePtr(r_ptr);
			}
		}

		internal readonly android.graphics.RegionIterator.NativeRegionIterator mNativeIter;

		internal NativeRegionIterator nativeInstance
		{
			get
			{
				return mNativeIter;
			}
		}

		public void Dispose()
		{
			mNativeIter.Dispose();
		}

		internal class NativeRegionIterator : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeRegionIterator() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeRegionIterator(System.IntPtr handle) : base(System.IntPtr.Zero, true
				)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_RegionIterator_destructor(
				System.IntPtr handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeRegionIterator Zero = new NativeRegionIterator();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_RegionIterator_destructor(handle);
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
