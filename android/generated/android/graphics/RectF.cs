using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>RectF holds four float coordinates for a rectangle.</summary>
	/// <remarks>
	/// RectF holds four float coordinates for a rectangle. The rectangle is
	/// represented by the coordinates of its 4 edges (left, top, right bottom).
	/// These fields can be accessed directly. Use width() and height() to retrieve
	/// the rectangle's width and height. Note: most methods do not check to see that
	/// the coordinates are sorted correctly (i.e. left &lt;= right and top &lt;= bottom).
	/// </remarks>
	[Sharpen.Sharpened]
	public class RectF : android.os.Parcelable
	{
		public float left;

		public float top;

		public float right;

		public float bottom;

		/// <summary>Create a new empty RectF.</summary>
		/// <remarks>Create a new empty RectF. All coordinates are initialized to 0.</remarks>
		public RectF()
		{
		}

		/// <summary>Create a new rectangle with the specified coordinates.</summary>
		/// <remarks>
		/// Create a new rectangle with the specified coordinates. Note: no range
		/// checking is performed, so the caller must ensure that left &lt;= right and
		/// top &lt;= bottom.
		/// </remarks>
		/// <param name="left">The X coordinate of the left side of the rectagle</param>
		/// <param name="top">The Y coordinate of the top of the rectangle</param>
		/// <param name="right">The X coordinate of the right side of the rectagle</param>
		/// <param name="bottom">The Y coordinate of the bottom of the rectangle</param>
		public RectF(float left, float top, float right, float bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		/// <summary>
		/// Create a new rectangle, initialized with the values in the specified
		/// rectangle (which is left unmodified).
		/// </summary>
		/// <remarks>
		/// Create a new rectangle, initialized with the values in the specified
		/// rectangle (which is left unmodified).
		/// </remarks>
		/// <param name="r">
		/// The rectangle whose coordinates are copied into the new
		/// rectangle.
		/// </param>
		public RectF(android.graphics.RectF r)
		{
			left = r.left;
			top = r.top;
			right = r.right;
			bottom = r.bottom;
		}

		public RectF(android.graphics.Rect r)
		{
			left = r.left;
			top = r.top;
			right = r.right;
			bottom = r.bottom;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "RectF(" + left + ", " + top + ", " + right + ", " + bottom + ")";
		}

		/// <summary>Return a string representation of the rectangle in a compact form.</summary>
		/// <remarks>Return a string representation of the rectangle in a compact form.</remarks>
		public virtual string toShortString()
		{
			return toShortString(new java.lang.StringBuilder(32));
		}

		/// <summary>Return a string representation of the rectangle in a compact form.</summary>
		/// <remarks>Return a string representation of the rectangle in a compact form.</remarks>
		/// <hide></hide>
		public virtual string toShortString(java.lang.StringBuilder sb)
		{
			sb.setLength(0);
			sb.append('[');
			sb.append(left);
			sb.append(',');
			sb.append(top);
			sb.append("][");
			sb.append(right);
			sb.append(',');
			sb.append(bottom);
			sb.append(']');
			return sb.ToString();
		}

		/// <summary>Print short representation to given writer.</summary>
		/// <remarks>Print short representation to given writer.</remarks>
		/// <hide></hide>
		public virtual void printShortString(java.io.PrintWriter pw)
		{
			pw.print('[');
			pw.print(left);
			pw.print(',');
			pw.print(top);
			pw.print("][");
			pw.print(right);
			pw.print(',');
			pw.print(bottom);
			pw.print(']');
		}

		/// <summary>Returns true if the rectangle is empty (left &gt;= right or top &gt;= bottom)
		/// 	</summary>
		public bool isEmpty()
		{
			return left >= right || top >= bottom;
		}

		/// <returns>
		/// the rectangle's width. This does not check for a valid rectangle
		/// (i.e. left &lt;= right) so the result may be negative.
		/// </returns>
		public float width()
		{
			return right - left;
		}

		/// <returns>
		/// the rectangle's height. This does not check for a valid rectangle
		/// (i.e. top &lt;= bottom) so the result may be negative.
		/// </returns>
		public float height()
		{
			return bottom - top;
		}

		/// <returns>
		/// the horizontal center of the rectangle. This does not check for
		/// a valid rectangle (i.e. left &lt;= right)
		/// </returns>
		public float centerX()
		{
			return (left + right) * 0.5f;
		}

		/// <returns>
		/// the vertical center of the rectangle. This does not check for
		/// a valid rectangle (i.e. top &lt;= bottom)
		/// </returns>
		public float centerY()
		{
			return (top + bottom) * 0.5f;
		}

		/// <summary>Set the rectangle to (0,0,0,0)</summary>
		public virtual void setEmpty()
		{
			left = right = top = bottom = 0;
		}

		/// <summary>Set the rectangle's coordinates to the specified values.</summary>
		/// <remarks>
		/// Set the rectangle's coordinates to the specified values. Note: no range
		/// checking is performed, so it is up to the caller to ensure that
		/// left &lt;= right and top &lt;= bottom.
		/// </remarks>
		/// <param name="left">The X coordinate of the left side of the rectagle</param>
		/// <param name="top">The Y coordinate of the top of the rectangle</param>
		/// <param name="right">The X coordinate of the right side of the rectagle</param>
		/// <param name="bottom">The Y coordinate of the bottom of the rectangle</param>
		public virtual void set(float left, float top, float right, float bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		/// <summary>Copy the coordinates from src into this rectangle.</summary>
		/// <remarks>Copy the coordinates from src into this rectangle.</remarks>
		/// <param name="src">
		/// The rectangle whose coordinates are copied into this
		/// rectangle.
		/// </param>
		public virtual void set(android.graphics.RectF src)
		{
			this.left = src.left;
			this.top = src.top;
			this.right = src.right;
			this.bottom = src.bottom;
		}

		/// <summary>Copy the coordinates from src into this rectangle.</summary>
		/// <remarks>Copy the coordinates from src into this rectangle.</remarks>
		/// <param name="src">
		/// The rectangle whose coordinates are copied into this
		/// rectangle.
		/// </param>
		public virtual void set(android.graphics.Rect src)
		{
			this.left = src.left;
			this.top = src.top;
			this.right = src.right;
			this.bottom = src.bottom;
		}

		/// <summary>
		/// Offset the rectangle by adding dx to its left and right coordinates, and
		/// adding dy to its top and bottom coordinates.
		/// </summary>
		/// <remarks>
		/// Offset the rectangle by adding dx to its left and right coordinates, and
		/// adding dy to its top and bottom coordinates.
		/// </remarks>
		/// <param name="dx">The amount to add to the rectangle's left and right coordinates</param>
		/// <param name="dy">The amount to add to the rectangle's top and bottom coordinates</param>
		public virtual void offset(float dx, float dy)
		{
			left += dx;
			top += dy;
			right += dx;
			bottom += dy;
		}

		/// <summary>
		/// Offset the rectangle to a specific (left, top) position,
		/// keeping its width and height the same.
		/// </summary>
		/// <remarks>
		/// Offset the rectangle to a specific (left, top) position,
		/// keeping its width and height the same.
		/// </remarks>
		/// <param name="newLeft">The new "left" coordinate for the rectangle</param>
		/// <param name="newTop">The new "top" coordinate for the rectangle</param>
		public virtual void offsetTo(float newLeft, float newTop)
		{
			right += newLeft - left;
			bottom += newTop - top;
			left = newLeft;
			top = newTop;
		}

		/// <summary>Inset the rectangle by (dx,dy).</summary>
		/// <remarks>
		/// Inset the rectangle by (dx,dy). If dx is positive, then the sides are
		/// moved inwards, making the rectangle narrower. If dx is negative, then the
		/// sides are moved outwards, making the rectangle wider. The same holds true
		/// for dy and the top and bottom.
		/// </remarks>
		/// <param name="dx">The amount to add(subtract) from the rectangle's left(right)</param>
		/// <param name="dy">The amount to add(subtract) from the rectangle's top(bottom)</param>
		public virtual void inset(float dx, float dy)
		{
			left += dx;
			top += dy;
			right -= dx;
			bottom -= dy;
		}

		/// <summary>Returns true if (x,y) is inside the rectangle.</summary>
		/// <remarks>
		/// Returns true if (x,y) is inside the rectangle. The left and top are
		/// considered to be inside, while the right and bottom are not. This means
		/// that for a x,y to be contained: left &lt;= x &lt; right and top &lt;= y &lt; bottom.
		/// An empty rectangle never contains any point.
		/// </remarks>
		/// <param name="x">The X coordinate of the point being tested for containment</param>
		/// <param name="y">The Y coordinate of the point being tested for containment</param>
		/// <returns>
		/// true iff (x,y) are contained by the rectangle, where containment
		/// means left &lt;= x &lt; right and top &lt;= y &lt; bottom
		/// </returns>
		public virtual bool contains(float x, float y)
		{
			return left < right && top < bottom && x >= left && x < right && y >= top && y < 
				bottom;
		}

		// check for empty first
		/// <summary>
		/// Returns true iff the 4 specified sides of a rectangle are inside or equal
		/// to this rectangle.
		/// </summary>
		/// <remarks>
		/// Returns true iff the 4 specified sides of a rectangle are inside or equal
		/// to this rectangle. i.e. is this rectangle a superset of the specified
		/// rectangle. An empty rectangle never contains another rectangle.
		/// </remarks>
		/// <param name="left">The left side of the rectangle being tested for containment</param>
		/// <param name="top">The top of the rectangle being tested for containment</param>
		/// <param name="right">The right side of the rectangle being tested for containment</param>
		/// <param name="bottom">The bottom of the rectangle being tested for containment</param>
		/// <returns>
		/// true iff the the 4 specified sides of a rectangle are inside or
		/// equal to this rectangle
		/// </returns>
		public virtual bool contains(float left, float top, float right, float bottom)
		{
			// check for empty first
			return this.left < this.right && this.top < this.bottom && this.left <= left && this
				.top <= top && this.right >= right && this.bottom >= bottom;
		}

		// now check for containment
		/// <summary>
		/// Returns true iff the specified rectangle r is inside or equal to this
		/// rectangle.
		/// </summary>
		/// <remarks>
		/// Returns true iff the specified rectangle r is inside or equal to this
		/// rectangle. An empty rectangle never contains another rectangle.
		/// </remarks>
		/// <param name="r">The rectangle being tested for containment.</param>
		/// <returns>
		/// true iff the specified rectangle r is inside or equal to this
		/// rectangle
		/// </returns>
		public virtual bool contains(android.graphics.RectF r)
		{
			// check for empty first
			return this.left < this.right && this.top < this.bottom && left <= r.left && top 
				<= r.top && right >= r.right && bottom >= r.bottom;
		}

		// now check for containment
		/// <summary>
		/// If the rectangle specified by left,top,right,bottom intersects this
		/// rectangle, return true and set this rectangle to that intersection,
		/// otherwise return false and do not change this rectangle.
		/// </summary>
		/// <remarks>
		/// If the rectangle specified by left,top,right,bottom intersects this
		/// rectangle, return true and set this rectangle to that intersection,
		/// otherwise return false and do not change this rectangle. No check is
		/// performed to see if either rectangle is empty. Note: To just test for
		/// intersection, use intersects()
		/// </remarks>
		/// <param name="left">
		/// The left side of the rectangle being intersected with this
		/// rectangle
		/// </param>
		/// <param name="top">The top of the rectangle being intersected with this rectangle</param>
		/// <param name="right">
		/// The right side of the rectangle being intersected with this
		/// rectangle.
		/// </param>
		/// <param name="bottom">
		/// The bottom of the rectangle being intersected with this
		/// rectangle.
		/// </param>
		/// <returns>
		/// true if the specified rectangle and this rectangle intersect
		/// (and this rectangle is then set to that intersection) else
		/// return false and do not change this rectangle.
		/// </returns>
		public virtual bool intersect(float left, float top, float right, float bottom)
		{
			if (this.left < right && left < this.right && this.top < bottom && top < this.bottom)
			{
				if (this.left < left)
				{
					this.left = left;
				}
				if (this.top < top)
				{
					this.top = top;
				}
				if (this.right > right)
				{
					this.right = right;
				}
				if (this.bottom > bottom)
				{
					this.bottom = bottom;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// If the specified rectangle intersects this rectangle, return true and set
		/// this rectangle to that intersection, otherwise return false and do not
		/// change this rectangle.
		/// </summary>
		/// <remarks>
		/// If the specified rectangle intersects this rectangle, return true and set
		/// this rectangle to that intersection, otherwise return false and do not
		/// change this rectangle. No check is performed to see if either rectangle
		/// is empty. To just test for intersection, use intersects()
		/// </remarks>
		/// <param name="r">The rectangle being intersected with this rectangle.</param>
		/// <returns>
		/// true if the specified rectangle and this rectangle intersect
		/// (and this rectangle is then set to that intersection) else
		/// return false and do not change this rectangle.
		/// </returns>
		public virtual bool intersect(android.graphics.RectF r)
		{
			return intersect(r.left, r.top, r.right, r.bottom);
		}

		/// <summary>
		/// If rectangles a and b intersect, return true and set this rectangle to
		/// that intersection, otherwise return false and do not change this
		/// rectangle.
		/// </summary>
		/// <remarks>
		/// If rectangles a and b intersect, return true and set this rectangle to
		/// that intersection, otherwise return false and do not change this
		/// rectangle. No check is performed to see if either rectangle is empty.
		/// To just test for intersection, use intersects()
		/// </remarks>
		/// <param name="a">The first rectangle being intersected with</param>
		/// <param name="b">The second rectangle being intersected with</param>
		/// <returns>
		/// true iff the two specified rectangles intersect. If they do, set
		/// this rectangle to that intersection. If they do not, return
		/// false and do not change this rectangle.
		/// </returns>
		public virtual bool setIntersect(android.graphics.RectF a, android.graphics.RectF
			 b)
		{
			if (a.left < b.right && b.left < a.right && a.top < b.bottom && b.top < a.bottom)
			{
				left = System.Math.Max(a.left, b.left);
				top = System.Math.Max(a.top, b.top);
				right = System.Math.Min(a.right, b.right);
				bottom = System.Math.Min(a.bottom, b.bottom);
				return true;
			}
			return false;
		}

		/// <summary>Returns true if this rectangle intersects the specified rectangle.</summary>
		/// <remarks>
		/// Returns true if this rectangle intersects the specified rectangle.
		/// In no event is this rectangle modified. No check is performed to see
		/// if either rectangle is empty. To record the intersection, use intersect()
		/// or setIntersect().
		/// </remarks>
		/// <param name="left">The left side of the rectangle being tested for intersection</param>
		/// <param name="top">The top of the rectangle being tested for intersection</param>
		/// <param name="right">
		/// The right side of the rectangle being tested for
		/// intersection
		/// </param>
		/// <param name="bottom">The bottom of the rectangle being tested for intersection</param>
		/// <returns>
		/// true iff the specified rectangle intersects this rectangle. In
		/// no event is this rectangle modified.
		/// </returns>
		public virtual bool intersects(float left, float top, float right, float bottom)
		{
			return this.left < right && left < this.right && this.top < bottom && top < this.
				bottom;
		}

		/// <summary>Returns true iff the two specified rectangles intersect.</summary>
		/// <remarks>
		/// Returns true iff the two specified rectangles intersect. In no event are
		/// either of the rectangles modified. To record the intersection,
		/// use intersect() or setIntersect().
		/// </remarks>
		/// <param name="a">The first rectangle being tested for intersection</param>
		/// <param name="b">The second rectangle being tested for intersection</param>
		/// <returns>
		/// true iff the two specified rectangles intersect. In no event are
		/// either of the rectangles modified.
		/// </returns>
		public static bool intersects(android.graphics.RectF a, android.graphics.RectF b)
		{
			return a.left < b.right && b.left < a.right && a.top < b.bottom && b.top < a.bottom;
		}

		/// <summary>
		/// Set the dst integer Rect by rounding this rectangle's coordinates
		/// to their nearest integer values.
		/// </summary>
		/// <remarks>
		/// Set the dst integer Rect by rounding this rectangle's coordinates
		/// to their nearest integer values.
		/// </remarks>
		public virtual void round(android.graphics.Rect dst)
		{
			dst.set(android.util.@internal.FastMath.round(left), android.util.@internal.FastMath
				.round(top), android.util.@internal.FastMath.round(right), android.util.@internal.FastMath
				.round(bottom));
		}

		/// <summary>
		/// Set the dst integer Rect by rounding "out" this rectangle, choosing the
		/// floor of top and left, and the ceiling of right and bottom.
		/// </summary>
		/// <remarks>
		/// Set the dst integer Rect by rounding "out" this rectangle, choosing the
		/// floor of top and left, and the ceiling of right and bottom.
		/// </remarks>
		public virtual void roundOut(android.graphics.Rect dst)
		{
			dst.set((int)android.util.FloatMath.floor(left), (int)android.util.FloatMath.floor
				(top), (int)android.util.FloatMath.ceil(right), (int)android.util.FloatMath.ceil
				(bottom));
		}

		/// <summary>Update this Rect to enclose itself and the specified rectangle.</summary>
		/// <remarks>
		/// Update this Rect to enclose itself and the specified rectangle. If the
		/// specified rectangle is empty, nothing is done. If this rectangle is empty
		/// it is set to the specified rectangle.
		/// </remarks>
		/// <param name="left">The left edge being unioned with this rectangle</param>
		/// <param name="top">The top edge being unioned with this rectangle</param>
		/// <param name="right">The right edge being unioned with this rectangle</param>
		/// <param name="bottom">The bottom edge being unioned with this rectangle</param>
		public virtual void union(float left, float top, float right, float bottom)
		{
			if ((left < right) && (top < bottom))
			{
				if ((this.left < this.right) && (this.top < this.bottom))
				{
					if (this.left > left)
					{
						this.left = left;
					}
					if (this.top > top)
					{
						this.top = top;
					}
					if (this.right < right)
					{
						this.right = right;
					}
					if (this.bottom < bottom)
					{
						this.bottom = bottom;
					}
				}
				else
				{
					this.left = left;
					this.top = top;
					this.right = right;
					this.bottom = bottom;
				}
			}
		}

		/// <summary>Update this Rect to enclose itself and the specified rectangle.</summary>
		/// <remarks>
		/// Update this Rect to enclose itself and the specified rectangle. If the
		/// specified rectangle is empty, nothing is done. If this rectangle is empty
		/// it is set to the specified rectangle.
		/// </remarks>
		/// <param name="r">The rectangle being unioned with this rectangle</param>
		public virtual void union(android.graphics.RectF r)
		{
			union(r.left, r.top, r.right, r.bottom);
		}

		/// <summary>Update this Rect to enclose itself and the [x,y] coordinate.</summary>
		/// <remarks>
		/// Update this Rect to enclose itself and the [x,y] coordinate. There is no
		/// check to see that this rectangle is non-empty.
		/// </remarks>
		/// <param name="x">The x coordinate of the point to add to the rectangle</param>
		/// <param name="y">The y coordinate of the point to add to the rectangle</param>
		public virtual void union(float x, float y)
		{
			if (x < left)
			{
				left = x;
			}
			else
			{
				if (x > right)
				{
					right = x;
				}
			}
			if (y < top)
			{
				top = y;
			}
			else
			{
				if (y > bottom)
				{
					bottom = y;
				}
			}
		}

		/// <summary>Swap top/bottom or left/right if there are flipped (i.e.</summary>
		/// <remarks>
		/// Swap top/bottom or left/right if there are flipped (i.e. left &gt; right
		/// and/or top &gt; bottom). This can be called if
		/// the edges are computed separately, and may have crossed over each other.
		/// If the edges are already correct (i.e. left &lt;= right and top &lt;= bottom)
		/// then nothing is done.
		/// </remarks>
		public virtual void sort()
		{
			if (left > right)
			{
				float temp = left;
				left = right;
				right = temp;
			}
			if (top > bottom)
			{
				float temp = top;
				top = bottom;
				bottom = temp;
			}
		}

		/// <summary>Parcelable interface methods</summary>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		/// <summary>Write this rectangle to the specified parcel.</summary>
		/// <remarks>
		/// Write this rectangle to the specified parcel. To restore a rectangle from
		/// a parcel, use readFromParcel()
		/// </remarks>
		/// <param name="out">The parcel to write the rectangle's coordinates into</param>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeFloat(left);
			@out.writeFloat(top);
			@out.writeFloat(right);
			@out.writeFloat(bottom);
		}

		private sealed class _Creator_531 : android.os.ParcelableClass.Creator<android.graphics.RectF
			>
		{
			public _Creator_531()
			{
			}

			/// <summary>Return a new rectangle from the data in the specified parcel.</summary>
			/// <remarks>Return a new rectangle from the data in the specified parcel.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.RectF createFromParcel(android.os.Parcel @in)
			{
				android.graphics.RectF r = new android.graphics.RectF();
				r.readFromParcel(@in);
				return r;
			}

			/// <summary>Return an array of rectangles of the specified size.</summary>
			/// <remarks>Return an array of rectangles of the specified size.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.RectF[] newArray(int size)
			{
				return new android.graphics.RectF[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.graphics.RectF>
			 CREATOR = new _Creator_531();

		/// <summary>
		/// Set the rectangle's coordinates from the data stored in the specified
		/// parcel.
		/// </summary>
		/// <remarks>
		/// Set the rectangle's coordinates from the data stored in the specified
		/// parcel. To write a rectangle to a parcel, call writeToParcel().
		/// </remarks>
		/// <param name="in">The parcel to read the rectangle's coordinates from</param>
		public virtual void readFromParcel(android.os.Parcel @in)
		{
			left = @in.readFloat();
			top = @in.readFloat();
			right = @in.readFloat();
			bottom = @in.readFloat();
		}

		[Sharpen.MarshalHelper(@"SkRect")]
		internal static class RectF_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct RectF_Struct
			{
				public uint _owner;

				public float left;

				public float top;

				public float right;

				public float bottom;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(RectF_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, android.graphics.RectF arg)
			{
				RectF_Struct obj = new RectF_Struct();
				obj._owner = 0x972f3813;
				obj.left = arg.left;
				obj.top = arg.top;
				obj.right = arg.right;
				obj.bottom = arg.bottom;
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, android.graphics.RectF arg)
			{
				RectF_Struct obj = (RectF_Struct)Marshal.PtrToStructure(ptr, typeof(RectF_Struct)
					);
				arg.left = obj.left;
				arg.top = obj.top;
				arg.right = obj.right;
				arg.bottom = obj.bottom;
			}

			public static System.IntPtr ManagedToNative(android.graphics.RectF arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(RectF_Struct)));
				android.graphics.RectF.RectF_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static android.graphics.RectF NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				RectF_Struct obj = (RectF_Struct)Marshal.PtrToStructure(ptr, typeof(RectF_Struct)
					);
				android.graphics.RectF arg = new android.graphics.RectF();
				arg.left = obj.left;
				arg.top = obj.top;
				arg.right = obj.right;
				arg.bottom = obj.bottom;
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_android_graphics_RectF_RectF_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_RectF_RectF_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				RectF_Struct obj = (RectF_Struct)Marshal.PtrToStructure(ptr, typeof(RectF_Struct)
					);
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
				android.graphics.RectF.RectF_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}
	}
}
