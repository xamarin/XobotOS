using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public partial class Region : android.os.Parcelable, System.IDisposable
	{
		/// <hide></hide>
		internal readonly android.graphics.Region.NativeRegion mNativeRegion;

		public enum Op : int
		{
			DIFFERENCE = 0,
			INTERSECT = 1,
			UNION = 2,
			XOR = 3,
			REVERSE_DIFFERENCE = 4,
			REPLACE = 5
		}

		/// <summary>Create an empty region</summary>
		public Region() : this(nativeConstructor())
		{
		}

		/// <summary>Return a copy of the specified region</summary>
		public Region(android.graphics.Region region) : this(nativeConstructor())
		{
			// the native values for these must match up with the enum in SkRegion.h
			nativeSetRegion(mNativeRegion, region.mNativeRegion);
		}

		/// <summary>Return a region set to the specified rectangle</summary>
		public Region(android.graphics.Rect r)
		{
			mNativeRegion = nativeConstructor();
			nativeSetRect(mNativeRegion, r.left, r.top, r.right, r.bottom);
		}

		/// <summary>Return a region set to the specified rectangle</summary>
		public Region(int left, int top, int right, int bottom)
		{
			mNativeRegion = nativeConstructor();
			nativeSetRect(mNativeRegion, left, top, right, bottom);
		}

		/// <summary>Set the region to the empty region</summary>
		public virtual void setEmpty()
		{
			nativeSetRect(mNativeRegion, 0, 0, 0, 0);
		}

		/// <summary>Set the region to the specified region.</summary>
		/// <remarks>Set the region to the specified region.</remarks>
		public virtual bool set(android.graphics.Region region)
		{
			return nativeSetRegion(mNativeRegion, region.mNativeRegion);
		}

		/// <summary>Set the region to the specified rectangle</summary>
		public virtual bool set(android.graphics.Rect r)
		{
			return nativeSetRect(mNativeRegion, r.left, r.top, r.right, r.bottom);
		}

		/// <summary>Set the region to the specified rectangle</summary>
		public virtual bool set(int left, int top, int right, int bottom)
		{
			return nativeSetRect(mNativeRegion, left, top, right, bottom);
		}

		/// <summary>Set the region to the area described by the path and clip.</summary>
		/// <remarks>
		/// Set the region to the area described by the path and clip.
		/// Return true if the resulting region is non-empty. This produces a region
		/// that is identical to the pixels that would be drawn by the path
		/// (with no antialiasing).
		/// </remarks>
		public virtual bool setPath(android.graphics.Path path, android.graphics.Region clip
			)
		{
			return nativeSetPath(mNativeRegion, path.nativeInstance, clip.mNativeRegion);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_isEmpty(android.graphics.Region.NativeRegion
			 _instance);

		/// <summary>Return true if this region is empty</summary>
		public virtual bool isEmpty()
		{
			return libxobotos_Region_isEmpty(mNativeRegion);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_isRect(android.graphics.Region.NativeRegion
			 _instance);

		/// <summary>Return true if the region contains a single rectangle</summary>
		public virtual bool isRect()
		{
			return libxobotos_Region_isRect(mNativeRegion);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_isComplex(android.graphics.Region.NativeRegion
			 _instance);

		/// <summary>Return true if the region contains more than one rectangle</summary>
		public virtual bool isComplex()
		{
			return libxobotos_Region_isComplex(mNativeRegion);
		}

		/// <summary>Return a new Rect set to the bounds of the region.</summary>
		/// <remarks>
		/// Return a new Rect set to the bounds of the region. If the region is
		/// empty, the Rect will be set to [0, 0, 0, 0]
		/// </remarks>
		public virtual android.graphics.Rect getBounds()
		{
			android.graphics.Rect r = new android.graphics.Rect();
			nativeGetBounds(mNativeRegion, r);
			return r;
		}

		/// <summary>Set the Rect to the bounds of the region.</summary>
		/// <remarks>
		/// Set the Rect to the bounds of the region. If the region is empty, the
		/// Rect will be set to [0, 0, 0, 0]
		/// </remarks>
		public virtual bool getBounds(android.graphics.Rect r)
		{
			if (r == null)
			{
				throw new System.ArgumentNullException();
			}
			return nativeGetBounds(mNativeRegion, r);
		}

		/// <summary>Return the boundary of the region as a new Path.</summary>
		/// <remarks>
		/// Return the boundary of the region as a new Path. If the region is empty,
		/// the path will also be empty.
		/// </remarks>
		public virtual android.graphics.Path getBoundaryPath()
		{
			android.graphics.Path path = new android.graphics.Path();
			nativeGetBoundaryPath(mNativeRegion, path.nativeInstance);
			return path;
		}

		/// <summary>Set the path to the boundary of the region.</summary>
		/// <remarks>
		/// Set the path to the boundary of the region. If the region is empty, the
		/// path will also be empty.
		/// </remarks>
		public virtual bool getBoundaryPath(android.graphics.Path path)
		{
			return nativeGetBoundaryPath(mNativeRegion, path.nativeInstance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_contains(android.graphics.Region.NativeRegion
			 _instance, int x, int y);

		/// <summary>Return true if the region contains the specified point</summary>
		public virtual bool contains(int x, int y)
		{
			return libxobotos_Region_contains(mNativeRegion, x, y);
		}

		/// <summary>
		/// Return true if the region is a single rectangle (not complex) and it
		/// contains the specified rectangle.
		/// </summary>
		/// <remarks>
		/// Return true if the region is a single rectangle (not complex) and it
		/// contains the specified rectangle. Returning false is not a guarantee
		/// that the rectangle is not contained by this region, but return true is a
		/// guarantee that the rectangle is contained by this region.
		/// </remarks>
		public virtual bool quickContains(android.graphics.Rect r)
		{
			return quickContains(r.left, r.top, r.right, r.bottom);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_quickContains(android.graphics.Region.NativeRegion
			 _instance, int left, int top, int right, int bottom);

		/// <summary>
		/// Return true if the region is a single rectangle (not complex) and it
		/// contains the specified rectangle.
		/// </summary>
		/// <remarks>
		/// Return true if the region is a single rectangle (not complex) and it
		/// contains the specified rectangle. Returning false is not a guarantee
		/// that the rectangle is not contained by this region, but return true is a
		/// guarantee that the rectangle is contained by this region.
		/// </remarks>
		public virtual bool quickContains(int left, int top, int right, int bottom)
		{
			return libxobotos_Region_quickContains(mNativeRegion, left, top, right, bottom);
		}

		/// <summary>
		/// Return true if the region is empty, or if the specified rectangle does
		/// not intersect the region.
		/// </summary>
		/// <remarks>
		/// Return true if the region is empty, or if the specified rectangle does
		/// not intersect the region. Returning false is not a guarantee that they
		/// intersect, but returning true is a guarantee that they do not.
		/// </remarks>
		public virtual bool quickReject(android.graphics.Rect r)
		{
			return quickReject(r.left, r.top, r.right, r.bottom);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_quickRejectRect(android.graphics.Region.NativeRegion
			 _instance, int left, int top, int right, int bottom);

		/// <summary>
		/// Return true if the region is empty, or if the specified rectangle does
		/// not intersect the region.
		/// </summary>
		/// <remarks>
		/// Return true if the region is empty, or if the specified rectangle does
		/// not intersect the region. Returning false is not a guarantee that they
		/// intersect, but returning true is a guarantee that they do not.
		/// </remarks>
		public virtual bool quickReject(int left, int top, int right, int bottom)
		{
			return libxobotos_Region_quickRejectRect(mNativeRegion, left, top, right, bottom);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_quickReject(android.graphics.Region.NativeRegion
			 _instance, android.graphics.Region.NativeRegion rgn);

		/// <summary>
		/// Return true if the region is empty, or if the specified region does not
		/// intersect the region.
		/// </summary>
		/// <remarks>
		/// Return true if the region is empty, or if the specified region does not
		/// intersect the region. Returning false is not a guarantee that they
		/// intersect, but returning true is a guarantee that they do not.
		/// </remarks>
		public virtual bool quickReject(android.graphics.Region rgn)
		{
			return libxobotos_Region_quickReject(mNativeRegion, rgn != null ? rgn.mNativeRegion
				 : android.graphics.Region.NativeRegion.Zero);
		}

		/// <summary>Translate the region by [dx, dy].</summary>
		/// <remarks>Translate the region by [dx, dy]. If the region is empty, do nothing.</remarks>
		public virtual void translate(int dx, int dy)
		{
			translate(dx, dy, null);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Region_translate(android.graphics.Region.NativeRegion
			 _instance, int dx, int dy, android.graphics.Region.NativeRegion dst);

		/// <summary>Set the dst region to the result of translating this region by [dx, dy].
		/// 	</summary>
		/// <remarks>
		/// Set the dst region to the result of translating this region by [dx, dy].
		/// If this region is empty, then dst will be set to empty.
		/// </remarks>
		public virtual void translate(int dx, int dy, android.graphics.Region dst)
		{
			libxobotos_Region_translate(mNativeRegion, dx, dy, dst != null ? dst.mNativeRegion
				 : android.graphics.Region.NativeRegion.Zero);
		}

		/// <summary>Scale the region by the given scale amount.</summary>
		/// <remarks>
		/// Scale the region by the given scale amount. This re-constructs new region by
		/// scaling the rects that this region consists of. New rectis are computed by scaling
		/// coordinates by float, then rounded by roundf() function to integers. This may results
		/// in less internal rects if 0 &lt; scale &lt; 1. Zero and Negative scale result in
		/// an empty region. If this region is empty, do nothing.
		/// </remarks>
		/// <hide></hide>
		public virtual void scale(float scale_1)
		{
			scale(scale_1, null);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Region_scale(android.graphics.Region.NativeRegion
			 _instance, float scale_1, android.graphics.Region.NativeRegion dst);

		/// <summary>Set the dst region to the result of scaling this region by the given scale amount.
		/// 	</summary>
		/// <remarks>
		/// Set the dst region to the result of scaling this region by the given scale amount.
		/// If this region is empty, then dst will be set to empty.
		/// </remarks>
		/// <hide></hide>
		public virtual void scale(float scale_1, android.graphics.Region dst)
		{
			libxobotos_Region_scale(mNativeRegion, scale_1, dst != null ? dst.mNativeRegion : 
				android.graphics.Region.NativeRegion.Zero);
		}

		public bool union(android.graphics.Rect r)
		{
			return op(r, android.graphics.Region.Op.UNION);
		}

		/// <summary>Perform the specified Op on this region and the specified rect.</summary>
		/// <remarks>
		/// Perform the specified Op on this region and the specified rect. Return
		/// true if the result of the op is not empty.
		/// </remarks>
		public virtual bool op(android.graphics.Rect r, android.graphics.Region.Op op_1)
		{
			return nativeOp(mNativeRegion, r.left, r.top, r.right, r.bottom, (int)op_1);
		}

		/// <summary>Perform the specified Op on this region and the specified rect.</summary>
		/// <remarks>
		/// Perform the specified Op on this region and the specified rect. Return
		/// true if the result of the op is not empty.
		/// </remarks>
		public virtual bool op(int left, int top, int right, int bottom, android.graphics.Region
			.Op op_1)
		{
			return nativeOp(mNativeRegion, left, top, right, bottom, (int)op_1);
		}

		/// <summary>Perform the specified Op on this region and the specified region.</summary>
		/// <remarks>
		/// Perform the specified Op on this region and the specified region. Return
		/// true if the result of the op is not empty.
		/// </remarks>
		public virtual bool op(android.graphics.Region region, android.graphics.Region.Op
			 op_1)
		{
			return op(this, region, op_1);
		}

		/// <summary>
		/// Set this region to the result of performing the Op on the specified rect
		/// and region.
		/// </summary>
		/// <remarks>
		/// Set this region to the result of performing the Op on the specified rect
		/// and region. Return true if the result is not empty.
		/// </remarks>
		public virtual bool op(android.graphics.Rect rect, android.graphics.Region region
			, android.graphics.Region.Op op_1)
		{
			return nativeOp(mNativeRegion, rect, region.mNativeRegion, (int)op_1);
		}

		/// <summary>
		/// Set this region to the result of performing the Op on the specified
		/// regions.
		/// </summary>
		/// <remarks>
		/// Set this region to the result of performing the Op on the specified
		/// regions. Return true if the result is not empty.
		/// </remarks>
		public virtual bool op(android.graphics.Region region1, android.graphics.Region region2
			, android.graphics.Region.Op op_1)
		{
			return nativeOp(mNativeRegion, region1.mNativeRegion, region2.mNativeRegion, (int
				)op_1);
		}

		public static readonly android.os.ParcelableClass.Creator<android.graphics.Region
			> CREATOR = null;

		//////////////////////////////////////////////////////////////////////////
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel p, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is android.graphics.Region))
			{
				return false;
			}
			android.graphics.Region peer = (android.graphics.Region)obj;
			return nativeEquals(mNativeRegion, peer.mNativeRegion);
		}

		~Region()
		{
			try
			{
				nativeDestructor(mNativeRegion);
			}
			finally
			{
				;
			}
		}

		internal Region(android.graphics.Region.NativeRegion ni_1)
		{
			if (ni_1 == null)
			{
				throw new java.lang.RuntimeException();
			}
			mNativeRegion = ni_1;
		}

		private Region(android.graphics.Region.NativeRegion ni_1, android.graphics.Region.NativeRegion
			 dummy) : this(ni_1)
		{
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_equals(android.graphics.Region.NativeRegion
			 native_r1, android.graphics.Region.NativeRegion native_r2);

		private static bool nativeEquals(android.graphics.Region.NativeRegion native_r1, 
			android.graphics.Region.NativeRegion native_r2)
		{
			return libxobotos_Region_equals(native_r1, native_r2);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Region.NativeRegion libxobotos_Region_constructor
			();

		private static android.graphics.Region.NativeRegion nativeConstructor()
		{
			return libxobotos_Region_constructor();
		}

		private static void nativeDestructor(android.graphics.Region.NativeRegion native_region
			)
		{
			native_region.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_setRegion(android.graphics.Region.NativeRegion
			 native_dst, android.graphics.Region.NativeRegion native_src);

		private static bool nativeSetRegion(android.graphics.Region.NativeRegion native_dst
			, android.graphics.Region.NativeRegion native_src)
		{
			return libxobotos_Region_setRegion(native_dst, native_src);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_setRect(android.graphics.Region.NativeRegion
			 native_dst, int left, int top, int right, int bottom);

		private static bool nativeSetRect(android.graphics.Region.NativeRegion native_dst
			, int left, int top, int right, int bottom)
		{
			return libxobotos_Region_setRect(native_dst, left, top, right, bottom);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_setPath(android.graphics.Region.NativeRegion
			 native_dst, android.graphics.Path.NativePath native_path, android.graphics.Region.NativeRegion
			 native_clip);

		private static bool nativeSetPath(android.graphics.Region.NativeRegion native_dst
			, android.graphics.Path.NativePath native_path, android.graphics.Region.NativeRegion
			 native_clip)
		{
			return libxobotos_Region_setPath(native_dst, native_path, native_clip);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_getBounds(android.graphics.Region.NativeRegion
			 native_region, System.IntPtr rect);

		private static bool nativeGetBounds(android.graphics.Region.NativeRegion native_region
			, android.graphics.Rect rect)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(rect);
				bool _retval = libxobotos_Region_getBounds(native_region, rect_ptr);
				android.graphics.Rect.Rect_Helper.MarshalOut(rect_ptr, rect);
				return _retval;
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_getBoundaryPath(android.graphics.Region.NativeRegion
			 native_region, android.graphics.Path.NativePath native_path);

		private static bool nativeGetBoundaryPath(android.graphics.Region.NativeRegion native_region
			, android.graphics.Path.NativePath native_path)
		{
			return libxobotos_Region_getBoundaryPath(native_region, native_path);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_recOp(android.graphics.Region.NativeRegion
			 native_dst, int left, int top, int right, int bottom, int op_1);

		private static bool nativeOp(android.graphics.Region.NativeRegion native_dst, int
			 left, int top, int right, int bottom, int op_1)
		{
			return libxobotos_Region_recOp(native_dst, left, top, right, bottom, op_1);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_rectOp(android.graphics.Region.NativeRegion
			 native_dst, System.IntPtr rect, android.graphics.Region.NativeRegion native_region
			, int op_1);

		private static bool nativeOp(android.graphics.Region.NativeRegion native_dst, android.graphics.Rect
			 rect, android.graphics.Region.NativeRegion native_region, int op_1)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(rect);
				return libxobotos_Region_rectOp(native_dst, rect_ptr, native_region, op_1);
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Region_op(android.graphics.Region.NativeRegion
			 native_dst, android.graphics.Region.NativeRegion native_region1, android.graphics.Region.NativeRegion
			 native_region2, int op_1);

		private static bool nativeOp(android.graphics.Region.NativeRegion native_dst, android.graphics.Region.NativeRegion
			 native_region1, android.graphics.Region.NativeRegion native_region2, int op_1)
		{
			return libxobotos_Region_op(native_dst, native_region1, native_region2, op_1);
		}

		internal NativeRegion nativeInstance
		{
			get
			{
				return mNativeRegion;
			}
		}

		public void Dispose()
		{
			mNativeRegion.Dispose();
		}

		internal class NativeRegion : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeRegion() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeRegion(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Region_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeRegion Zero = new NativeRegion();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Region_destructor(handle);
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
