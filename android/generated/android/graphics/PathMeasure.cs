using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class PathMeasure : System.IDisposable
	{
		/// <summary>Create an empty PathMeasure object.</summary>
		/// <remarks>
		/// Create an empty PathMeasure object. To uses this to measure the length
		/// of a path, and/or to find the position and tangent along it, call
		/// setPath.
		/// Note that once a path is associated with the measure object, it is
		/// undefined if the path is subsequently modified and the the measure object
		/// is used. If the path is modified, you must call setPath with the path.
		/// </remarks>
		public PathMeasure()
		{
			native_instance = native_create(null, false);
		}

		/// <summary>
		/// Create a PathMeasure object associated with the specified path object
		/// (already created and specified).
		/// </summary>
		/// <remarks>
		/// Create a PathMeasure object associated with the specified path object
		/// (already created and specified). The meansure object can now return the
		/// path's length, and the position and tangent of any position along the
		/// path.
		/// Note that once a path is associated with the measure object, it is
		/// undefined if the path is subsequently modified and the the measure object
		/// is used. If the path is modified, you must call setPath with the path.
		/// </remarks>
		/// <param name="path">The path that will be measured by this object</param>
		/// <param name="forceClosed">
		/// If true, then the path will be considered as "closed"
		/// even if its contour was not explicitly closed.
		/// </param>
		public PathMeasure(android.graphics.Path path, bool forceClosed)
		{
			// note: the native side makes a copy of path, so we don't need a java
			// reference to it here, since it's fine if it gets GC'd
			native_instance = native_create(path != null ? path.nativeInstance : null, forceClosed
				);
		}

		/// <summary>Assign a new path, or null to have none.</summary>
		/// <remarks>Assign a new path, or null to have none.</remarks>
		public virtual void setPath(android.graphics.Path path, bool forceClosed)
		{
			// note: the native side makes a copy of path, so we don't need a java
			// reference to it here, since it's fine if it gets GC'd
			native_setPath(native_instance, path != null ? path.nativeInstance : null, forceClosed
				);
		}

		/// <summary>
		/// Return the total length of the current contour, or 0 if no path is
		/// associated with this measure object.
		/// </summary>
		/// <remarks>
		/// Return the total length of the current contour, or 0 if no path is
		/// associated with this measure object.
		/// </remarks>
		public virtual float getLength()
		{
			return native_getLength(native_instance);
		}

		/// <summary>
		/// Pins distance to 0 &lt;= distance &lt;= getLength(), and then computes the
		/// corresponding position and tangent.
		/// </summary>
		/// <remarks>
		/// Pins distance to 0 &lt;= distance &lt;= getLength(), and then computes the
		/// corresponding position and tangent. Returns false if there is no path,
		/// or a zero-length path was specified, in which case position and tangent
		/// are unchanged.
		/// </remarks>
		/// <param name="distance">The distance along the current contour to sample</param>
		/// <param name="pos">If not null, eturns the sampled position (x==[0], y==[1])</param>
		/// <param name="tan">If not null, returns the sampled tangent (x==[0], y==[1])</param>
		/// <returns>false if there was no path associated with this measure object</returns>
		public virtual bool getPosTan(float distance, float[] pos, float[] tan)
		{
			if (pos != null && pos.Length < 2 || tan != null && tan.Length < 2)
			{
				throw new System.IndexOutOfRangeException();
			}
			return native_getPosTan(native_instance, distance, pos, tan);
		}

		public const int POSITION_MATRIX_FLAG = unchecked((int)(0x01));

		public const int TANGENT_MATRIX_FLAG = unchecked((int)(0x02));

		// must match flags in SkPathMeasure.h
		// must match flags in SkPathMeasure.h
		/// <summary>
		/// Pins distance to 0 &lt;= distance &lt;= getLength(), and then computes the
		/// corresponding matrix.
		/// </summary>
		/// <remarks>
		/// Pins distance to 0 &lt;= distance &lt;= getLength(), and then computes the
		/// corresponding matrix. Returns false if there is no path, or a zero-length
		/// path was specified, in which case matrix is unchanged.
		/// </remarks>
		/// <param name="distance">The distance along the associated path</param>
		/// <param name="matrix">
		/// Allocated by the caller, this is set to the transformation
		/// associated with the position and tangent at the specified distance
		/// </param>
		/// <param name="flags">Specified what aspects should be returned in the matrix.</param>
		public virtual bool getMatrix(float distance, android.graphics.Matrix matrix, int
			 flags)
		{
			return native_getMatrix(native_instance, distance, matrix.native_instance, flags);
		}

		/// <summary>
		/// Given a start and stop distance, return in dst the intervening
		/// segment(s).
		/// </summary>
		/// <remarks>
		/// Given a start and stop distance, return in dst the intervening
		/// segment(s). If the segment is zero-length, return false, else return
		/// true. startD and stopD are pinned to legal values (0..getLength()).
		/// If startD &lt;= stopD then return false (and leave dst untouched).
		/// Begin the segment with a moveTo if startWithMoveTo is true
		/// </remarks>
		public virtual bool getSegment(float startD, float stopD, android.graphics.Path dst
			, bool startWithMoveTo)
		{
			return native_getSegment(native_instance, startD, stopD, dst.nativeInstance, startWithMoveTo
				);
		}

		/// <summary>Return true if the current contour is closed()</summary>
		public virtual bool isClosed()
		{
			return native_isClosed(native_instance);
		}

		/// <summary>Move to the next contour in the path.</summary>
		/// <remarks>
		/// Move to the next contour in the path. Return true if one exists, or
		/// false if we're done with the path.
		/// </remarks>
		public virtual bool nextContour()
		{
			return native_nextContour(native_instance);
		}

		~PathMeasure()
		{
			native_destroy(native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.PathMeasure.NativePathMeasure libxobotos_PathMeasure_create
			(android.graphics.Path.NativePath native_path, bool forceClosed);

		private static android.graphics.PathMeasure.NativePathMeasure native_create(android.graphics.Path.NativePath
			 native_path, bool forceClosed)
		{
			return libxobotos_PathMeasure_create(native_path != null ? native_path : android.graphics.Path.NativePath
				.Zero, forceClosed);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_PathMeasure_setPath(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, android.graphics.Path.NativePath native_path, bool forceClosed
			);

		private static void native_setPath(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, android.graphics.Path.NativePath native_path, bool forceClosed
			)
		{
			libxobotos_PathMeasure_setPath(native_instance, native_path != null ? native_path
				 : android.graphics.Path.NativePath.Zero, forceClosed);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_PathMeasure_getLength(android.graphics.PathMeasure.NativePathMeasure
			 native_instance);

		private static float native_getLength(android.graphics.PathMeasure.NativePathMeasure
			 native_instance)
		{
			return libxobotos_PathMeasure_getLength(native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_PathMeasure_getPosTan(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, float distance, System.IntPtr pos, System.IntPtr tan);

		private static bool native_getPosTan(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, float distance, float[] pos, float[] tan)
		{
			Sharpen.INativeHandle pos_handle = null;
			Sharpen.INativeHandle tan_handle = null;
			try
			{
				pos_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(pos);
				tan_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(tan);
				return libxobotos_PathMeasure_getPosTan(native_instance, distance, pos_handle != 
					null ? pos_handle.Address : System.IntPtr.Zero, tan_handle != null ? tan_handle.
					Address : System.IntPtr.Zero);
			}
			finally
			{
				if (pos_handle != null)
				{
					pos_handle.Free();
				}
				if (tan_handle != null)
				{
					tan_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_PathMeasure_getMatrix(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, float distance, android.graphics.Matrix.NativeMatrix native_matrix
			, int flags);

		private static bool native_getMatrix(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, float distance, android.graphics.Matrix.NativeMatrix native_matrix
			, int flags)
		{
			return libxobotos_PathMeasure_getMatrix(native_instance, distance, native_matrix, 
				flags);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_PathMeasure_getSegment(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, float startD, float stopD, android.graphics.Path.NativePath native_path
			, bool startWithMoveTo);

		private static bool native_getSegment(android.graphics.PathMeasure.NativePathMeasure
			 native_instance, float startD, float stopD, android.graphics.Path.NativePath native_path
			, bool startWithMoveTo)
		{
			return libxobotos_PathMeasure_getSegment(native_instance, startD, stopD, native_path
				, startWithMoveTo);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_PathMeasure_isClosed(android.graphics.PathMeasure.NativePathMeasure
			 native_instance);

		private static bool native_isClosed(android.graphics.PathMeasure.NativePathMeasure
			 native_instance)
		{
			return libxobotos_PathMeasure_isClosed(native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_PathMeasure_isClosed_0(android.graphics.PathMeasure.NativePathMeasure
			 native_instance);

		private static bool native_nextContour(android.graphics.PathMeasure.NativePathMeasure
			 native_instance)
		{
			return libxobotos_PathMeasure_isClosed_0(native_instance);
		}

		private static void native_destroy(android.graphics.PathMeasure.NativePathMeasure
			 native_instance)
		{
			native_instance.Dispose();
		}

		internal readonly android.graphics.PathMeasure.NativePathMeasure native_instance;

		internal NativePathMeasure nativeInstance
		{
			get
			{
				return native_instance;
			}
		}

		public void Dispose()
		{
			native_instance.Dispose();
		}

		internal class NativePathMeasure : System.Runtime.InteropServices.SafeHandle
		{
			internal NativePathMeasure() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativePathMeasure(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_PathMeasure_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativePathMeasure Zero = new NativePathMeasure();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_PathMeasure_destructor(handle);
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
