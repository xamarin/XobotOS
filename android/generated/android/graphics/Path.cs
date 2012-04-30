using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// The Path class encapsulates compound (multiple contour) geometric paths
	/// consisting of straight line segments, quadratic curves, and cubic curves.
	/// </summary>
	/// <remarks>
	/// The Path class encapsulates compound (multiple contour) geometric paths
	/// consisting of straight line segments, quadratic curves, and cubic curves.
	/// It can be drawn with canvas.drawPath(path, paint), either filled or stroked
	/// (based on the paint's Style), or it can be used for clipping or to draw
	/// text on a path.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Path : System.IDisposable
	{
		/// <hide></hide>
		internal readonly android.graphics.Path.NativePath mNativePath;

		/// <hide></hide>
		public bool isSimplePath = true;

		/// <hide></hide>
		public android.graphics.Region rects;

		private bool mDetectSimplePaths;

		private android.graphics.Path.Direction? mLastDirection = null;

		/// <summary>Create an empty path</summary>
		public Path()
		{
			mNativePath = init1();
			mDetectSimplePaths = android.view.HardwareRenderer.isAvailable();
		}

		/// <summary>Create a new path, copying the contents from the src path.</summary>
		/// <remarks>Create a new path, copying the contents from the src path.</remarks>
		/// <param name="src">The path to copy from when initializing the new path</param>
		public Path(android.graphics.Path src)
		{
			android.graphics.Path.NativePath valNative = null;
			if (src != null)
			{
				valNative = src.mNativePath;
			}
			mNativePath = init2(valNative);
			mDetectSimplePaths = android.view.HardwareRenderer.isAvailable();
		}

		/// <summary>Clear any lines and curves from the path, making it empty.</summary>
		/// <remarks>
		/// Clear any lines and curves from the path, making it empty.
		/// This does NOT change the fill-type setting.
		/// </remarks>
		public virtual void reset()
		{
			isSimplePath = true;
			if (mDetectSimplePaths)
			{
				mLastDirection = null;
				if (rects != null)
				{
					rects.setEmpty();
				}
			}
			native_reset(mNativePath);
		}

		/// <summary>
		/// Rewinds the path: clears any lines and curves from the path but
		/// keeps the internal data structure for faster reuse.
		/// </summary>
		/// <remarks>
		/// Rewinds the path: clears any lines and curves from the path but
		/// keeps the internal data structure for faster reuse.
		/// </remarks>
		public virtual void rewind()
		{
			isSimplePath = true;
			if (mDetectSimplePaths)
			{
				mLastDirection = null;
				if (rects != null)
				{
					rects.setEmpty();
				}
			}
			native_rewind(mNativePath);
		}

		/// <summary>Replace the contents of this with the contents of src.</summary>
		/// <remarks>Replace the contents of this with the contents of src.</remarks>
		public virtual void set(android.graphics.Path src)
		{
			if (this != src)
			{
				isSimplePath = src.isSimplePath;
				native_set(mNativePath, src.mNativePath);
			}
		}

		/// <summary>Enum for the ways a path may be filled</summary>
		public enum FillType : int
		{
			WINDING = 0,
			EVEN_ODD = 1,
			INVERSE_WINDING = 2,
			INVERSE_EVEN_ODD = 3
		}

		internal static readonly android.graphics.Path.FillType[] sFillTypeArray = new android.graphics.Path
			.FillType[] { android.graphics.Path.FillType.WINDING, android.graphics.Path.FillType
			.EVEN_ODD, android.graphics.Path.FillType.INVERSE_WINDING, android.graphics.Path.FillType
			.INVERSE_EVEN_ODD };

		// these must match the values in SkPath.h
		// these must be in the same order as their native values
		/// <summary>Return the path's fill type.</summary>
		/// <remarks>
		/// Return the path's fill type. This defines how "inside" is
		/// computed. The default value is WINDING.
		/// </remarks>
		/// <returns>the path's fill type</returns>
		public virtual android.graphics.Path.FillType getFillType()
		{
			return sFillTypeArray[native_getFillType(mNativePath)];
		}

		/// <summary>Set the path's fill type.</summary>
		/// <remarks>Set the path's fill type. This defines how "inside" is computed.</remarks>
		/// <param name="ft">The new fill type for this path</param>
		public virtual void setFillType(android.graphics.Path.FillType ft)
		{
			native_setFillType(mNativePath, (int)ft);
		}

		/// <summary>Returns true if the filltype is one of the INVERSE variants</summary>
		/// <returns>true if the filltype is one of the INVERSE variants</returns>
		public virtual bool isInverseFillType()
		{
			int ft = native_getFillType(mNativePath);
			return (ft & 2) != 0;
		}

		/// <summary>Toggles the INVERSE state of the filltype</summary>
		public virtual void toggleInverseFillType()
		{
			int ft = native_getFillType(mNativePath);
			ft ^= 2;
			native_setFillType(mNativePath, ft);
		}

		/// <summary>Returns true if the path is empty (contains no lines or curves)</summary>
		/// <returns>true if the path is empty (contains no lines or curves)</returns>
		public virtual bool isEmpty()
		{
			return native_isEmpty(mNativePath);
		}

		/// <summary>Returns true if the path specifies a rectangle.</summary>
		/// <remarks>
		/// Returns true if the path specifies a rectangle. If so, and if rect is
		/// not null, set rect to the bounds of the path. If the path does not
		/// specify a rectangle, return false and ignore rect.
		/// </remarks>
		/// <param name="rect">
		/// If not null, returns the bounds of the path if it specifies
		/// a rectangle
		/// </param>
		/// <returns>true if the path specifies a rectangle</returns>
		public virtual bool isRect(android.graphics.RectF rect)
		{
			return native_isRect(mNativePath, rect);
		}

		/// <summary>
		/// Compute the bounds of the control points of the path, and write the
		/// answer into bounds.
		/// </summary>
		/// <remarks>
		/// Compute the bounds of the control points of the path, and write the
		/// answer into bounds. If the path contains 0 or 1 points, the bounds is
		/// set to (0,0,0,0)
		/// </remarks>
		/// <param name="bounds">Returns the computed bounds of the path's control points.</param>
		/// <param name="exact">This parameter is no longer used.</param>
		public virtual void computeBounds(android.graphics.RectF bounds, bool exact)
		{
			native_computeBounds(mNativePath, bounds);
		}

		/// <summary>Hint to the path to prepare for adding more points.</summary>
		/// <remarks>
		/// Hint to the path to prepare for adding more points. This can allow the
		/// path to more efficiently allocate its storage.
		/// </remarks>
		/// <param name="extraPtCount">
		/// The number of extra points that may be added to this
		/// path
		/// </param>
		public virtual void incReserve(int extraPtCount)
		{
			native_incReserve(mNativePath, extraPtCount);
		}

		/// <summary>Set the beginning of the next contour to the point (x,y).</summary>
		/// <remarks>Set the beginning of the next contour to the point (x,y).</remarks>
		/// <param name="x">The x-coordinate of the start of a new contour</param>
		/// <param name="y">The y-coordinate of the start of a new contour</param>
		public virtual void moveTo(float x, float y)
		{
			native_moveTo(mNativePath, x, y);
		}

		/// <summary>
		/// Set the beginning of the next contour relative to the last point on the
		/// previous contour.
		/// </summary>
		/// <remarks>
		/// Set the beginning of the next contour relative to the last point on the
		/// previous contour. If there is no previous contour, this is treated the
		/// same as moveTo().
		/// </remarks>
		/// <param name="dx">
		/// The amount to add to the x-coordinate of the end of the
		/// previous contour, to specify the start of a new contour
		/// </param>
		/// <param name="dy">
		/// The amount to add to the y-coordinate of the end of the
		/// previous contour, to specify the start of a new contour
		/// </param>
		public virtual void rMoveTo(float dx, float dy)
		{
			native_rMoveTo(mNativePath, dx, dy);
		}

		/// <summary>Add a line from the last point to the specified point (x,y).</summary>
		/// <remarks>
		/// Add a line from the last point to the specified point (x,y).
		/// If no moveTo() call has been made for this contour, the first point is
		/// automatically set to (0,0).
		/// </remarks>
		/// <param name="x">The x-coordinate of the end of a line</param>
		/// <param name="y">The y-coordinate of the end of a line</param>
		public virtual void lineTo(float x, float y)
		{
			isSimplePath = false;
			native_lineTo(mNativePath, x, y);
		}

		/// <summary>
		/// Same as lineTo, but the coordinates are considered relative to the last
		/// point on this contour.
		/// </summary>
		/// <remarks>
		/// Same as lineTo, but the coordinates are considered relative to the last
		/// point on this contour. If there is no previous point, then a moveTo(0,0)
		/// is inserted automatically.
		/// </remarks>
		/// <param name="dx">
		/// The amount to add to the x-coordinate of the previous point on
		/// this contour, to specify a line
		/// </param>
		/// <param name="dy">
		/// The amount to add to the y-coordinate of the previous point on
		/// this contour, to specify a line
		/// </param>
		public virtual void rLineTo(float dx, float dy)
		{
			isSimplePath = false;
			native_rLineTo(mNativePath, dx, dy);
		}

		/// <summary>
		/// Add a quadratic bezier from the last point, approaching control point
		/// (x1,y1), and ending at (x2,y2).
		/// </summary>
		/// <remarks>
		/// Add a quadratic bezier from the last point, approaching control point
		/// (x1,y1), and ending at (x2,y2). If no moveTo() call has been made for
		/// this contour, the first point is automatically set to (0,0).
		/// </remarks>
		/// <param name="x1">The x-coordinate of the control point on a quadratic curve</param>
		/// <param name="y1">The y-coordinate of the control point on a quadratic curve</param>
		/// <param name="x2">The x-coordinate of the end point on a quadratic curve</param>
		/// <param name="y2">The y-coordinate of the end point on a quadratic curve</param>
		public virtual void quadTo(float x1, float y1, float x2, float y2)
		{
			isSimplePath = false;
			native_quadTo(mNativePath, x1, y1, x2, y2);
		}

		/// <summary>
		/// Same as quadTo, but the coordinates are considered relative to the last
		/// point on this contour.
		/// </summary>
		/// <remarks>
		/// Same as quadTo, but the coordinates are considered relative to the last
		/// point on this contour. If there is no previous point, then a moveTo(0,0)
		/// is inserted automatically.
		/// </remarks>
		/// <param name="dx1">
		/// The amount to add to the x-coordinate of the last point on
		/// this contour, for the control point of a quadratic curve
		/// </param>
		/// <param name="dy1">
		/// The amount to add to the y-coordinate of the last point on
		/// this contour, for the control point of a quadratic curve
		/// </param>
		/// <param name="dx2">
		/// The amount to add to the x-coordinate of the last point on
		/// this contour, for the end point of a quadratic curve
		/// </param>
		/// <param name="dy2">
		/// The amount to add to the y-coordinate of the last point on
		/// this contour, for the end point of a quadratic curve
		/// </param>
		public virtual void rQuadTo(float dx1, float dy1, float dx2, float dy2)
		{
			isSimplePath = false;
			native_rQuadTo(mNativePath, dx1, dy1, dx2, dy2);
		}

		/// <summary>
		/// Add a cubic bezier from the last point, approaching control points
		/// (x1,y1) and (x2,y2), and ending at (x3,y3).
		/// </summary>
		/// <remarks>
		/// Add a cubic bezier from the last point, approaching control points
		/// (x1,y1) and (x2,y2), and ending at (x3,y3). If no moveTo() call has been
		/// made for this contour, the first point is automatically set to (0,0).
		/// </remarks>
		/// <param name="x1">The x-coordinate of the 1st control point on a cubic curve</param>
		/// <param name="y1">The y-coordinate of the 1st control point on a cubic curve</param>
		/// <param name="x2">The x-coordinate of the 2nd control point on a cubic curve</param>
		/// <param name="y2">The y-coordinate of the 2nd control point on a cubic curve</param>
		/// <param name="x3">The x-coordinate of the end point on a cubic curve</param>
		/// <param name="y3">The y-coordinate of the end point on a cubic curve</param>
		public virtual void cubicTo(float x1, float y1, float x2, float y2, float x3, float
			 y3)
		{
			isSimplePath = false;
			native_cubicTo(mNativePath, x1, y1, x2, y2, x3, y3);
		}

		/// <summary>
		/// Same as cubicTo, but the coordinates are considered relative to the
		/// current point on this contour.
		/// </summary>
		/// <remarks>
		/// Same as cubicTo, but the coordinates are considered relative to the
		/// current point on this contour. If there is no previous point, then a
		/// moveTo(0,0) is inserted automatically.
		/// </remarks>
		public virtual void rCubicTo(float x1, float y1, float x2, float y2, float x3, float
			 y3)
		{
			isSimplePath = false;
			native_rCubicTo(mNativePath, x1, y1, x2, y2, x3, y3);
		}

		/// <summary>Append the specified arc to the path as a new contour.</summary>
		/// <remarks>
		/// Append the specified arc to the path as a new contour. If the start of
		/// the path is different from the path's current last point, then an
		/// automatic lineTo() is added to connect the current contour to the
		/// start of the arc. However, if the path is empty, then we call moveTo()
		/// with the first point of the arc. The sweep angle is tread mod 360.
		/// </remarks>
		/// <param name="oval">The bounds of oval defining shape and size of the arc</param>
		/// <param name="startAngle">Starting angle (in degrees) where the arc begins</param>
		/// <param name="sweepAngle">
		/// Sweep angle (in degrees) measured clockwise, treated
		/// mod 360.
		/// </param>
		/// <param name="forceMoveTo">If true, always begin a new contour with the arc</param>
		public virtual void arcTo(android.graphics.RectF oval, float startAngle, float sweepAngle
			, bool forceMoveTo)
		{
			isSimplePath = false;
			native_arcTo(mNativePath, oval, startAngle, sweepAngle, forceMoveTo);
		}

		/// <summary>Append the specified arc to the path as a new contour.</summary>
		/// <remarks>
		/// Append the specified arc to the path as a new contour. If the start of
		/// the path is different from the path's current last point, then an
		/// automatic lineTo() is added to connect the current contour to the
		/// start of the arc. However, if the path is empty, then we call moveTo()
		/// with the first point of the arc.
		/// </remarks>
		/// <param name="oval">The bounds of oval defining shape and size of the arc</param>
		/// <param name="startAngle">Starting angle (in degrees) where the arc begins</param>
		/// <param name="sweepAngle">Sweep angle (in degrees) measured clockwise</param>
		public virtual void arcTo(android.graphics.RectF oval, float startAngle, float sweepAngle
			)
		{
			isSimplePath = false;
			native_arcTo(mNativePath, oval, startAngle, sweepAngle, false);
		}

		/// <summary>Close the current contour.</summary>
		/// <remarks>
		/// Close the current contour. If the current point is not equal to the
		/// first point of the contour, a line segment is automatically added.
		/// </remarks>
		public virtual void close()
		{
			isSimplePath = false;
			native_close(mNativePath);
		}

		/// <summary>Specifies how closed shapes (e.g.</summary>
		/// <remarks>
		/// Specifies how closed shapes (e.g. rects, ovals) are oriented when they
		/// are added to a path.
		/// </remarks>
		public enum Direction : int
		{
			/// <summary>clockwise</summary>
			CW = 0,
			/// <summary>counter-clockwise</summary>
			CCW = 1
		}

		// must match enum in SkPath.h
		// must match enum in SkPath.h
		private void detectSimplePath(float left, float top, float right, float bottom, android.graphics.Path.Direction
			? dir)
		{
			if (mDetectSimplePaths)
			{
				if (mLastDirection == null)
				{
					mLastDirection = dir;
				}
				if (mLastDirection != dir)
				{
					isSimplePath = false;
				}
				else
				{
					if (rects == null)
					{
						rects = new android.graphics.Region();
					}
					rects.op((int)left, (int)top, (int)right, (int)bottom, android.graphics.Region.Op
						.UNION);
				}
			}
		}

		/// <summary>Add a closed rectangle contour to the path</summary>
		/// <param name="rect">The rectangle to add as a closed contour to the path</param>
		/// <param name="dir">The direction to wind the rectangle's contour</param>
		public virtual void addRect(android.graphics.RectF rect, android.graphics.Path.Direction
			? dir)
		{
			if (rect == null)
			{
				throw new System.ArgumentNullException("need rect parameter");
			}
			detectSimplePath(rect.left, rect.top, rect.right, rect.bottom, dir);
			native_addRect(mNativePath, rect, (int)dir);
		}

		/// <summary>Add a closed rectangle contour to the path</summary>
		/// <param name="left">The left side of a rectangle to add to the path</param>
		/// <param name="top">The top of a rectangle to add to the path</param>
		/// <param name="right">The right side of a rectangle to add to the path</param>
		/// <param name="bottom">The bottom of a rectangle to add to the path</param>
		/// <param name="dir">The direction to wind the rectangle's contour</param>
		public virtual void addRect(float left, float top, float right, float bottom, android.graphics.Path.Direction
			? dir)
		{
			detectSimplePath(left, top, right, bottom, dir);
			native_addRect(mNativePath, left, top, right, bottom, (int)dir);
		}

		/// <summary>Add a closed oval contour to the path</summary>
		/// <param name="oval">The bounds of the oval to add as a closed contour to the path</param>
		/// <param name="dir">The direction to wind the oval's contour</param>
		public virtual void addOval(android.graphics.RectF oval, android.graphics.Path.Direction
			? dir)
		{
			if (oval == null)
			{
				throw new System.ArgumentNullException("need oval parameter");
			}
			isSimplePath = false;
			native_addOval(mNativePath, oval, (int)dir);
		}

		/// <summary>Add a closed circle contour to the path</summary>
		/// <param name="x">The x-coordinate of the center of a circle to add to the path</param>
		/// <param name="y">The y-coordinate of the center of a circle to add to the path</param>
		/// <param name="radius">The radius of a circle to add to the path</param>
		/// <param name="dir">The direction to wind the circle's contour</param>
		public virtual void addCircle(float x, float y, float radius, android.graphics.Path.Direction
			? dir)
		{
			isSimplePath = false;
			native_addCircle(mNativePath, x, y, radius, (int)dir);
		}

		/// <summary>Add the specified arc to the path as a new contour.</summary>
		/// <remarks>Add the specified arc to the path as a new contour.</remarks>
		/// <param name="oval">The bounds of oval defining the shape and size of the arc</param>
		/// <param name="startAngle">Starting angle (in degrees) where the arc begins</param>
		/// <param name="sweepAngle">Sweep angle (in degrees) measured clockwise</param>
		public virtual void addArc(android.graphics.RectF oval, float startAngle, float sweepAngle
			)
		{
			if (oval == null)
			{
				throw new System.ArgumentNullException("need oval parameter");
			}
			isSimplePath = false;
			native_addArc(mNativePath, oval, startAngle, sweepAngle);
		}

		/// <summary>Add a closed round-rectangle contour to the path</summary>
		/// <param name="rect">The bounds of a round-rectangle to add to the path</param>
		/// <param name="rx">The x-radius of the rounded corners on the round-rectangle</param>
		/// <param name="ry">The y-radius of the rounded corners on the round-rectangle</param>
		/// <param name="dir">The direction to wind the round-rectangle's contour</param>
		public virtual void addRoundRect(android.graphics.RectF rect, float rx, float ry, 
			android.graphics.Path.Direction? dir)
		{
			if (rect == null)
			{
				throw new System.ArgumentNullException("need rect parameter");
			}
			isSimplePath = false;
			native_addRoundRect(mNativePath, rect, rx, ry, (int)dir);
		}

		/// <summary>Add a closed round-rectangle contour to the path.</summary>
		/// <remarks>
		/// Add a closed round-rectangle contour to the path. Each corner receives
		/// two radius values [X, Y]. The corners are ordered top-left, top-right,
		/// bottom-right, bottom-left
		/// </remarks>
		/// <param name="rect">The bounds of a round-rectangle to add to the path</param>
		/// <param name="radii">Array of 8 values, 4 pairs of [X,Y] radii</param>
		/// <param name="dir">The direction to wind the round-rectangle's contour</param>
		public virtual void addRoundRect(android.graphics.RectF rect, float[] radii, android.graphics.Path.Direction
			? dir)
		{
			if (rect == null)
			{
				throw new System.ArgumentNullException("need rect parameter");
			}
			if (radii.Length < 8)
			{
				throw new System.IndexOutOfRangeException("radii[] needs 8 values");
			}
			isSimplePath = false;
			native_addRoundRect(mNativePath, rect, radii, (int)dir);
		}

		/// <summary>Add a copy of src to the path, offset by (dx,dy)</summary>
		/// <param name="src">The path to add as a new contour</param>
		/// <param name="dx">The amount to translate the path in X as it is added</param>
		public virtual void addPath(android.graphics.Path src, float dx, float dy)
		{
			isSimplePath = false;
			native_addPath(mNativePath, src.mNativePath, dx, dy);
		}

		/// <summary>Add a copy of src to the path</summary>
		/// <param name="src">The path that is appended to the current path</param>
		public virtual void addPath(android.graphics.Path src)
		{
			isSimplePath = false;
			native_addPath(mNativePath, src.mNativePath);
		}

		/// <summary>Add a copy of src to the path, transformed by matrix</summary>
		/// <param name="src">The path to add as a new contour</param>
		public virtual void addPath(android.graphics.Path src, android.graphics.Matrix matrix
			)
		{
			if (!src.isSimplePath)
			{
				isSimplePath = false;
			}
			native_addPath(mNativePath, src.mNativePath, matrix.native_instance);
		}

		/// <summary>Offset the path by (dx,dy), returning true on success</summary>
		/// <param name="dx">The amount in the X direction to offset the entire path</param>
		/// <param name="dy">The amount in the Y direction to offset the entire path</param>
		/// <param name="dst">
		/// The translated path is written here. If this is null, then
		/// the original path is modified.
		/// </param>
		public virtual void offset(float dx, float dy, android.graphics.Path dst)
		{
			android.graphics.Path.NativePath dstNative = null;
			if (dst != null)
			{
				dstNative = dst.mNativePath;
			}
			native_offset(mNativePath, dx, dy, dstNative);
		}

		/// <summary>Offset the path by (dx,dy), returning true on success</summary>
		/// <param name="dx">The amount in the X direction to offset the entire path</param>
		/// <param name="dy">The amount in the Y direction to offset the entire path</param>
		public virtual void offset(float dx, float dy)
		{
			native_offset(mNativePath, dx, dy);
		}

		/// <summary>Sets the last point of the path.</summary>
		/// <remarks>Sets the last point of the path.</remarks>
		/// <param name="dx">The new X coordinate for the last point</param>
		/// <param name="dy">The new Y coordinate for the last point</param>
		public virtual void setLastPoint(float dx, float dy)
		{
			isSimplePath = false;
			native_setLastPoint(mNativePath, dx, dy);
		}

		/// <summary>
		/// Transform the points in this path by matrix, and write the answer
		/// into dst.
		/// </summary>
		/// <remarks>
		/// Transform the points in this path by matrix, and write the answer
		/// into dst. If dst is null, then the the original path is modified.
		/// </remarks>
		/// <param name="matrix">The matrix to apply to the path</param>
		/// <param name="dst">
		/// The transformed path is written here. If dst is null,
		/// then the the original path is modified
		/// </param>
		public virtual void transform(android.graphics.Matrix matrix, android.graphics.Path
			 dst)
		{
			android.graphics.Path.NativePath dstNative = null;
			if (dst != null)
			{
				dstNative = dst.mNativePath;
			}
			native_transform(mNativePath, matrix.native_instance, dstNative);
		}

		/// <summary>Transform the points in this path by matrix.</summary>
		/// <remarks>Transform the points in this path by matrix.</remarks>
		/// <param name="matrix">The matrix to apply to the path</param>
		public virtual void transform(android.graphics.Matrix matrix)
		{
			native_transform(mNativePath, matrix.native_instance);
		}

		~Path()
		{
			try
			{
				finalizer(mNativePath);
			}
			finally
			{
				;
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Path.NativePath libxobotos_Path_init1();

		private static android.graphics.Path.NativePath init1()
		{
			return libxobotos_Path_init1();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Path.NativePath libxobotos_Path_init2(android.graphics.Path.NativePath
			 nPath);

		private static android.graphics.Path.NativePath init2(android.graphics.Path.NativePath
			 nPath)
		{
			return libxobotos_Path_init2(nPath);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_reset(android.graphics.Path.NativePath
			 nPath);

		private static void native_reset(android.graphics.Path.NativePath nPath)
		{
			libxobotos_Path_reset(nPath);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_rewind(android.graphics.Path.NativePath
			 nPath);

		private static void native_rewind(android.graphics.Path.NativePath nPath)
		{
			libxobotos_Path_rewind(nPath);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_set(android.graphics.Path.NativePath native_dst
			, android.graphics.Path.NativePath native_src);

		private static void native_set(android.graphics.Path.NativePath native_dst, android.graphics.Path.NativePath
			 native_src)
		{
			libxobotos_Path_set(native_dst, native_src);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Path_getFillType(android.graphics.Path.NativePath
			 nPath);

		private static int native_getFillType(android.graphics.Path.NativePath nPath)
		{
			return libxobotos_Path_getFillType(nPath);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_setFillType(android.graphics.Path.NativePath
			 nPath, int ft);

		private static void native_setFillType(android.graphics.Path.NativePath nPath, int
			 ft)
		{
			libxobotos_Path_setFillType(nPath, ft);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Path_isEmpty(android.graphics.Path.NativePath
			 nPath);

		private static bool native_isEmpty(android.graphics.Path.NativePath nPath)
		{
			return libxobotos_Path_isEmpty(nPath);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Path_isRect(android.graphics.Path.NativePath
			 nPath, System.IntPtr rect);

		private static bool native_isRect(android.graphics.Path.NativePath nPath, android.graphics.RectF
			 rect)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(rect);
				bool _retval = libxobotos_Path_isRect(nPath, rect_ptr);
				android.graphics.RectF.RectF_Helper.MarshalOut(rect_ptr, rect);
				return _retval;
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_getBounds(android.graphics.Path.NativePath
			 nPath, out System.IntPtr bounds);

		private static void native_computeBounds(android.graphics.Path.NativePath nPath, 
			android.graphics.RectF bounds)
		{
			System.IntPtr bounds_ptr = System.IntPtr.Zero;
			try
			{
				libxobotos_Path_getBounds(nPath, out bounds_ptr);
				android.graphics.RectF.RectF_Helper.MarshalOut(bounds_ptr, bounds);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeNativePtr(bounds_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_incReserve(android.graphics.Path.NativePath
			 nPath, int extraPtCount);

		private static void native_incReserve(android.graphics.Path.NativePath nPath, int
			 extraPtCount)
		{
			libxobotos_Path_incReserve(nPath, extraPtCount);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_moveTo(android.graphics.Path.NativePath
			 nPath, float x, float y);

		private static void native_moveTo(android.graphics.Path.NativePath nPath, float x
			, float y)
		{
			libxobotos_Path_moveTo(nPath, x, y);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_rMoveTo(android.graphics.Path.NativePath
			 nPath, float dx, float dy);

		private static void native_rMoveTo(android.graphics.Path.NativePath nPath, float 
			dx, float dy)
		{
			libxobotos_Path_rMoveTo(nPath, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_lineTo(android.graphics.Path.NativePath
			 nPath, float x, float y);

		private static void native_lineTo(android.graphics.Path.NativePath nPath, float x
			, float y)
		{
			libxobotos_Path_lineTo(nPath, x, y);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_rLineTo(android.graphics.Path.NativePath
			 nPath, float dx, float dy);

		private static void native_rLineTo(android.graphics.Path.NativePath nPath, float 
			dx, float dy)
		{
			libxobotos_Path_rLineTo(nPath, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_quadTo(android.graphics.Path.NativePath
			 nPath, float x1, float y1, float x2, float y2);

		private static void native_quadTo(android.graphics.Path.NativePath nPath, float x1
			, float y1, float x2, float y2)
		{
			libxobotos_Path_quadTo(nPath, x1, y1, x2, y2);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_rQuadTo(android.graphics.Path.NativePath
			 nPath, float dx1, float dy1, float dx2, float dy2);

		private static void native_rQuadTo(android.graphics.Path.NativePath nPath, float 
			dx1, float dy1, float dx2, float dy2)
		{
			libxobotos_Path_rQuadTo(nPath, dx1, dy1, dx2, dy2);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_cubicTo(android.graphics.Path.NativePath
			 nPath, float x1, float y1, float x2, float y2, float x3, float y3);

		private static void native_cubicTo(android.graphics.Path.NativePath nPath, float 
			x1, float y1, float x2, float y2, float x3, float y3)
		{
			libxobotos_Path_cubicTo(nPath, x1, y1, x2, y2, x3, y3);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_rCubicTo(android.graphics.Path.NativePath
			 nPath, float x1, float y1, float x2, float y2, float x3, float y3);

		private static void native_rCubicTo(android.graphics.Path.NativePath nPath, float
			 x1, float y1, float x2, float y2, float x3, float y3)
		{
			libxobotos_Path_rCubicTo(nPath, x1, y1, x2, y2, x3, y3);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_arcTo(android.graphics.Path.NativePath
			 nPath, System.IntPtr oval, float startAngle, float sweepAngle, bool forceMoveTo
			);

		private static void native_arcTo(android.graphics.Path.NativePath nPath, android.graphics.RectF
			 oval, float startAngle, float sweepAngle, bool forceMoveTo)
		{
			System.IntPtr oval_ptr = System.IntPtr.Zero;
			try
			{
				oval_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(oval);
				libxobotos_Path_arcTo(nPath, oval_ptr, startAngle, sweepAngle, forceMoveTo);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(oval_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_close(android.graphics.Path.NativePath
			 nPath);

		private static void native_close(android.graphics.Path.NativePath nPath)
		{
			libxobotos_Path_close(nPath);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addRect(android.graphics.Path.NativePath
			 nPath, System.IntPtr rect, int dir);

		private static void native_addRect(android.graphics.Path.NativePath nPath, android.graphics.RectF
			 rect, int dir)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(rect);
				libxobotos_Path_addRect(nPath, rect_ptr, dir);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addRect_0(android.graphics.Path.NativePath
			 nPath, float left, float top, float right, float bottom, int dir);

		private static void native_addRect(android.graphics.Path.NativePath nPath, float 
			left, float top, float right, float bottom, int dir)
		{
			libxobotos_Path_addRect_0(nPath, left, top, right, bottom, dir);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addOval(android.graphics.Path.NativePath
			 nPath, System.IntPtr oval, int dir);

		private static void native_addOval(android.graphics.Path.NativePath nPath, android.graphics.RectF
			 oval, int dir)
		{
			System.IntPtr oval_ptr = System.IntPtr.Zero;
			try
			{
				oval_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(oval);
				libxobotos_Path_addOval(nPath, oval_ptr, dir);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(oval_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addCircle(android.graphics.Path.NativePath
			 nPath, float x, float y, float radius, int dir);

		private static void native_addCircle(android.graphics.Path.NativePath nPath, float
			 x, float y, float radius, int dir)
		{
			libxobotos_Path_addCircle(nPath, x, y, radius, dir);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addArc(android.graphics.Path.NativePath
			 nPath, System.IntPtr oval, float startAngle, float sweepAngle);

		private static void native_addArc(android.graphics.Path.NativePath nPath, android.graphics.RectF
			 oval, float startAngle, float sweepAngle)
		{
			System.IntPtr oval_ptr = System.IntPtr.Zero;
			try
			{
				oval_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(oval);
				libxobotos_Path_addArc(nPath, oval_ptr, startAngle, sweepAngle);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(oval_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addRoundRect(android.graphics.Path.NativePath
			 nPath, System.IntPtr rect, float rx, float ry, int dir);

		private static void native_addRoundRect(android.graphics.Path.NativePath nPath, android.graphics.RectF
			 rect, float rx, float ry, int dir)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(rect);
				libxobotos_Path_addRoundRect(nPath, rect_ptr, rx, ry, dir);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addRoundRect_0(android.graphics.Path.NativePath
			 nPath, System.IntPtr r, System.IntPtr radii, int dir);

		private static void native_addRoundRect(android.graphics.Path.NativePath nPath, android.graphics.RectF
			 r, float[] radii, int dir)
		{
			System.IntPtr r_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle radii_handle = null;
			try
			{
				r_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(r);
				radii_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(radii);
				libxobotos_Path_addRoundRect_0(nPath, r_ptr, radii_handle.Address, dir);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(r_ptr);
				if (radii_handle != null)
				{
					radii_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addPath(android.graphics.Path.NativePath
			 nPath, android.graphics.Path.NativePath src, float dx, float dy);

		private static void native_addPath(android.graphics.Path.NativePath nPath, android.graphics.Path.NativePath
			 src, float dx, float dy)
		{
			libxobotos_Path_addPath(nPath, src, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addPath_0(android.graphics.Path.NativePath
			 nPath, android.graphics.Path.NativePath src);

		private static void native_addPath(android.graphics.Path.NativePath nPath, android.graphics.Path.NativePath
			 src)
		{
			libxobotos_Path_addPath_0(nPath, src);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_addPath_1(android.graphics.Path.NativePath
			 nPath, android.graphics.Path.NativePath src, android.graphics.Matrix.NativeMatrix
			 matrix);

		private static void native_addPath(android.graphics.Path.NativePath nPath, android.graphics.Path.NativePath
			 src, android.graphics.Matrix.NativeMatrix matrix)
		{
			libxobotos_Path_addPath_1(nPath, src, matrix);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_offset(android.graphics.Path.NativePath
			 nPath, float dx, float dy, android.graphics.Path.NativePath dst_path);

		private static void native_offset(android.graphics.Path.NativePath nPath, float dx
			, float dy, android.graphics.Path.NativePath dst_path)
		{
			libxobotos_Path_offset(nPath, dx, dy, dst_path);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_offset_0(android.graphics.Path.NativePath
			 nPath, float dx, float dy);

		private static void native_offset(android.graphics.Path.NativePath nPath, float dx
			, float dy)
		{
			libxobotos_Path_offset_0(nPath, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_setLastPt(android.graphics.Path.NativePath
			 nPath, float dx, float dy);

		private static void native_setLastPoint(android.graphics.Path.NativePath nPath, float
			 dx, float dy)
		{
			libxobotos_Path_setLastPt(nPath, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_transform(android.graphics.Path.NativePath
			 nPath, android.graphics.Matrix.NativeMatrix matrix, android.graphics.Path.NativePath
			 dst_path);

		private static void native_transform(android.graphics.Path.NativePath nPath, android.graphics.Matrix.NativeMatrix
			 matrix, android.graphics.Path.NativePath dst_path)
		{
			libxobotos_Path_transform(nPath, matrix, dst_path);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Path_transform_0(android.graphics.Path.NativePath
			 nPath, android.graphics.Matrix.NativeMatrix matrix);

		private static void native_transform(android.graphics.Path.NativePath nPath, android.graphics.Matrix.NativeMatrix
			 matrix)
		{
			libxobotos_Path_transform_0(nPath, matrix);
		}

		private static void finalizer(android.graphics.Path.NativePath nPath)
		{
			nPath.Dispose();
		}

		internal NativePath nativeInstance
		{
			get
			{
				return mNativePath;
			}
		}

		public void Dispose()
		{
			mNativePath.Dispose();
		}

		internal class NativePath : System.Runtime.InteropServices.SafeHandle
		{
			internal NativePath() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativePath(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Path_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativePath Zero = new NativePath();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Path_destructor(handle);
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
