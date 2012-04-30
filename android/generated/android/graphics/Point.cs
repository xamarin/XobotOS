using Sharpen;

namespace android.graphics
{
	/// <summary>Point holds two integer coordinates</summary>
	[Sharpen.Sharpened]
	public class Point : android.os.Parcelable
	{
		public int x;

		public int y;

		public Point()
		{
		}

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Point(android.graphics.Point src)
		{
			this.x = src.x;
			this.y = src.y;
		}

		/// <summary>Set the point's x and y coordinates</summary>
		public virtual void set(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>Negate the point's coordinates</summary>
		public void negate()
		{
			x = -x;
			y = -y;
		}

		/// <summary>Offset the point's coordinates by dx, dy</summary>
		public void offset(int dx, int dy)
		{
			x += dx;
			y += dy;
		}

		/// <summary>Returns true if the point's coordinates equal (x,y)</summary>
		public bool equals(int x, int y)
		{
			return this.x == x && this.y == y;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			if (o is android.graphics.Point)
			{
				android.graphics.Point p = (android.graphics.Point)o;
				return this.x == p.x && this.y == p.y;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			return x * 32713 + y;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "Point(" + x + ", " + y + ")";
		}

		/// <summary>Parcelable interface methods</summary>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		/// <summary>Write this point to the specified parcel.</summary>
		/// <remarks>
		/// Write this point to the specified parcel. To restore a point from
		/// a parcel, use readFromParcel()
		/// </remarks>
		/// <param name="out">The parcel to write the point's coordinates into</param>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeInt(x);
			@out.writeInt(y);
		}

		private sealed class _Creator_108 : android.os.ParcelableClass.Creator<android.graphics.Point
			>
		{
			public _Creator_108()
			{
			}

			/// <summary>Return a new point from the data in the specified parcel.</summary>
			/// <remarks>Return a new point from the data in the specified parcel.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.Point createFromParcel(android.os.Parcel @in)
			{
				android.graphics.Point r = new android.graphics.Point();
				r.readFromParcel(@in);
				return r;
			}

			/// <summary>Return an array of rectangles of the specified size.</summary>
			/// <remarks>Return an array of rectangles of the specified size.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.Point[] newArray(int size)
			{
				return new android.graphics.Point[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.graphics.Point>
			 CREATOR = new _Creator_108();

		/// <summary>
		/// Set the point's coordinates from the data stored in the specified
		/// parcel.
		/// </summary>
		/// <remarks>
		/// Set the point's coordinates from the data stored in the specified
		/// parcel. To write a point to a parcel, call writeToParcel().
		/// </remarks>
		/// <param name="in">The parcel to read the point's coordinates from</param>
		public virtual void readFromParcel(android.os.Parcel @in)
		{
			x = @in.readInt();
			y = @in.readInt();
		}
	}
}
