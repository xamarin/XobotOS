using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>Rect holds four integer coordinates for a rectangle.</summary>
	/// <remarks>
	/// Rect holds four integer coordinates for a rectangle. The rectangle is
	/// represented by the coordinates of its 4 edges (left, top, right bottom).
	/// These fields can be accessed directly. Use width() and height() to retrieve
	/// the rectangle's width and height. Note: most methods do not check to see that
	/// the coordinates are sorted correctly (i.e. left &lt;= right and top &lt;= bottom).
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed class Rect : android.os.Parcelable
	{
		public int left;

		public int top;

		public int right;

		public int bottom;

		/// <summary>Create a new empty Rect.</summary>
		/// <remarks>Create a new empty Rect. All coordinates are initialized to 0.</remarks>
		public Rect()
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
		public Rect(int left, int top, int right, int bottom)
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
		public Rect(android.graphics.Rect r)
		{
			left = r.left;
			top = r.top;
			right = r.right;
			bottom = r.bottom;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object obj)
		{
			android.graphics.Rect r = (android.graphics.Rect)obj;
			if (r != null)
			{
				return left == r.left && top == r.top && right == r.right && bottom == r.bottom;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(32);
			sb.append("Rect(");
			sb.append(left);
			sb.append(", ");
			sb.append(top);
			sb.append(" - ");
			sb.append(right);
			sb.append(", ");
			sb.append(bottom);
			sb.append(")");
			return sb.ToString();
		}

		/// <summary>Return a string representation of the rectangle in a compact form.</summary>
		/// <remarks>Return a string representation of the rectangle in a compact form.</remarks>
		public string toShortString()
		{
			return toShortString(new java.lang.StringBuilder(32));
		}

		/// <summary>Return a string representation of the rectangle in a compact form.</summary>
		/// <remarks>Return a string representation of the rectangle in a compact form.</remarks>
		/// <hide></hide>
		public string toShortString(java.lang.StringBuilder sb)
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

		/// <summary>Return a string representation of the rectangle in a well-defined format.
		/// 	</summary>
		/// <remarks>
		/// Return a string representation of the rectangle in a well-defined format.
		/// <p>You can later recover the Rect from this string through
		/// <see cref="unflattenFromString(string)">unflattenFromString(string)</see>
		/// .
		/// </remarks>
		/// <returns>Returns a new String of the form "left top right bottom"</returns>
		public string flattenToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(32);
			// WARNING: Do not change the format of this string, it must be
			// preserved because Rects are saved in this flattened format.
			sb.append(left);
			sb.append(' ');
			sb.append(top);
			sb.append(' ');
			sb.append(right);
			sb.append(' ');
			sb.append(bottom);
			return sb.ToString();
		}

		/// <summary>Print short representation to given writer.</summary>
		/// <remarks>Print short representation to given writer.</remarks>
		/// <hide></hide>
		public void printShortString(java.io.PrintWriter pw)
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
		public int width()
		{
			return right - left;
		}

		/// <returns>
		/// the rectangle's height. This does not check for a valid rectangle
		/// (i.e. top &lt;= bottom) so the result may be negative.
		/// </returns>
		public int height()
		{
			return bottom - top;
		}

		/// <returns>
		/// the horizontal center of the rectangle. If the computed value
		/// is fractional, this method returns the largest integer that is
		/// less than the computed value.
		/// </returns>
		public int centerX()
		{
			return (left + right) >> 1;
		}

		/// <returns>
		/// the vertical center of the rectangle. If the computed value
		/// is fractional, this method returns the largest integer that is
		/// less than the computed value.
		/// </returns>
		public int centerY()
		{
			return (top + bottom) >> 1;
		}

		/// <returns>the exact horizontal center of the rectangle as a float.</returns>
		public float exactCenterX()
		{
			return (left + right) * 0.5f;
		}

		/// <returns>the exact vertical center of the rectangle as a float.</returns>
		public float exactCenterY()
		{
			return (top + bottom) * 0.5f;
		}

		/// <summary>Set the rectangle to (0,0,0,0)</summary>
		public void setEmpty()
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
		public void set(int left, int top, int right, int bottom)
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
		public void set(android.graphics.Rect src)
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
		public void offset(int dx, int dy)
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
		public void offsetTo(int newLeft, int newTop)
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
		public void inset(int dx, int dy)
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
		public bool contains(int x, int y)
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
		public bool contains(int left, int top, int right, int bottom)
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
		public bool contains(android.graphics.Rect r)
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
		/// intersection, use
		/// <see cref="intersects(Rect, Rect)">intersects(Rect, Rect)</see>
		/// .
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
		public bool intersect(int left, int top, int right, int bottom)
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
		public bool intersect(android.graphics.Rect r)
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
		public bool setIntersect(android.graphics.Rect a, android.graphics.Rect b)
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
		public bool intersects(int left, int top, int right, int bottom)
		{
			return this.left < right && left < this.right && this.top < bottom && top < this.
				bottom;
		}

		/// <summary>Returns true iff the two specified rectangles intersect.</summary>
		/// <remarks>
		/// Returns true iff the two specified rectangles intersect. In no event are
		/// either of the rectangles modified. To record the intersection,
		/// use
		/// <see cref="intersect(Rect)">intersect(Rect)</see>
		/// or
		/// <see cref="setIntersect(Rect, Rect)">setIntersect(Rect, Rect)</see>
		/// .
		/// </remarks>
		/// <param name="a">The first rectangle being tested for intersection</param>
		/// <param name="b">The second rectangle being tested for intersection</param>
		/// <returns>
		/// true iff the two specified rectangles intersect. In no event are
		/// either of the rectangles modified.
		/// </returns>
		public static bool intersects(android.graphics.Rect a, android.graphics.Rect b)
		{
			return a.left < b.right && b.left < a.right && a.top < b.bottom && b.top < a.bottom;
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
		public void union(int left, int top, int right, int bottom)
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
		public void union(android.graphics.Rect r)
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
		public void union(int x, int y)
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
		public void sort()
		{
			if (left > right)
			{
				int temp = left;
				left = right;
				right = temp;
			}
			if (top > bottom)
			{
				int temp = top;
				top = bottom;
				bottom = temp;
			}
		}

		/// <summary>Parcelable interface methods</summary>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
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
		public void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeInt(left);
			@out.writeInt(top);
			@out.writeInt(right);
			@out.writeInt(bottom);
		}

		private sealed class _Creator_562 : android.os.ParcelableClass.Creator<android.graphics.Rect
			>
		{
			public _Creator_562()
			{
			}

			/// <summary>Return a new rectangle from the data in the specified parcel.</summary>
			/// <remarks>Return a new rectangle from the data in the specified parcel.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.Rect createFromParcel(android.os.Parcel @in)
			{
				android.graphics.Rect r = new android.graphics.Rect();
				r.readFromParcel(@in);
				return r;
			}

			/// <summary>Return an array of rectangles of the specified size.</summary>
			/// <remarks>Return an array of rectangles of the specified size.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.Rect[] newArray(int size)
			{
				return new android.graphics.Rect[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.graphics.Rect> 
			CREATOR = new _Creator_562();

		/// <summary>
		/// Set the rectangle's coordinates from the data stored in the specified
		/// parcel.
		/// </summary>
		/// <remarks>
		/// Set the rectangle's coordinates from the data stored in the specified
		/// parcel. To write a rectangle to a parcel, call writeToParcel().
		/// </remarks>
		/// <param name="in">The parcel to read the rectangle's coordinates from</param>
		public void readFromParcel(android.os.Parcel @in)
		{
			left = @in.readInt();
			top = @in.readInt();
			right = @in.readInt();
			bottom = @in.readInt();
		}

		/// <summary>Scales up the rect by the given scale.</summary>
		/// <remarks>Scales up the rect by the given scale.</remarks>
		/// <hide></hide>
		public void scale(float scale_1)
		{
			if (scale_1 != 1.0f)
			{
				left = (int)(left * scale_1 + 0.5f);
				top = (int)(top * scale_1 + 0.5f);
				right = (int)(right * scale_1 + 0.5f);
				bottom = (int)(bottom * scale_1 + 0.5f);
			}
		}

		[Sharpen.MarshalHelper(@"SkIRect")]
		internal static class Rect_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Rect_Struct
			{
				public uint _owner;

				public int left;

				public int top;

				public int right;

				public int bottom;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Rect_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, android.graphics.Rect arg)
			{
				Rect_Struct obj = new Rect_Struct();
				obj._owner = 0x972f3813;
				obj.left = arg.left;
				obj.top = arg.top;
				obj.right = arg.right;
				obj.bottom = arg.bottom;
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, android.graphics.Rect arg)
			{
				Rect_Struct obj = (Rect_Struct)Marshal.PtrToStructure(ptr, typeof(Rect_Struct));
				arg.left = obj.left;
				arg.top = obj.top;
				arg.right = obj.right;
				arg.bottom = obj.bottom;
			}

			public static System.IntPtr ManagedToNative(android.graphics.Rect arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Rect_Struct)));
				android.graphics.Rect.Rect_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static android.graphics.Rect NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Rect_Struct obj = (Rect_Struct)Marshal.PtrToStructure(ptr, typeof(Rect_Struct));
				android.graphics.Rect arg = new android.graphics.Rect();
				arg.left = obj.left;
				arg.top = obj.top;
				arg.right = obj.right;
				arg.bottom = obj.bottom;
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_android_graphics_Rect_Rect_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Rect_Rect_destructor(System.IntPtr
				 ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Rect_Struct obj = (Rect_Struct)Marshal.PtrToStructure(ptr, typeof(Rect_Struct));
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
				android.graphics.Rect.Rect_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}
	}
}
