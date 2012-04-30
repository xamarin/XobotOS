using Sharpen;

namespace android.graphics
{
	/// <summary>PointF holds two float coordinates</summary>
	[Sharpen.Sharpened]
	public class PointF : android.os.Parcelable
	{
		public float x;

		public float y;

		public PointF()
		{
		}

		public PointF(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public PointF(android.graphics.Point p)
		{
			this.x = p.x;
			this.y = p.y;
		}

		/// <summary>Set the point's x and y coordinates</summary>
		public void set(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>Set the point's x and y coordinates to the coordinates of p</summary>
		public void set(android.graphics.PointF p)
		{
			this.x = p.x;
			this.y = p.y;
		}

		public void negate()
		{
			x = -x;
			y = -y;
		}

		public void offset(float dx, float dy)
		{
			x += dx;
			y += dy;
		}

		/// <summary>Returns true if the point's coordinates equal (x,y)</summary>
		public bool equals(float x, float y)
		{
			return this.x == x && this.y == y;
		}

		/// <summary>Return the euclidian distance from (0,0) to the point</summary>
		public float length()
		{
			return length(x, y);
		}

		/// <summary>Returns the euclidian distance from (0,0) to (x,y)</summary>
		public static float length(float x, float y)
		{
			return android.util.FloatMath.sqrt(x * x + y * y);
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
			@out.writeFloat(x);
			@out.writeFloat(y);
		}

		private sealed class _Creator_109 : android.os.ParcelableClass.Creator<android.graphics.PointF
			>
		{
			public _Creator_109()
			{
			}

			/// <summary>Return a new point from the data in the specified parcel.</summary>
			/// <remarks>Return a new point from the data in the specified parcel.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.PointF createFromParcel(android.os.Parcel @in)
			{
				android.graphics.PointF r = new android.graphics.PointF();
				r.readFromParcel(@in);
				return r;
			}

			/// <summary>Return an array of rectangles of the specified size.</summary>
			/// <remarks>Return an array of rectangles of the specified size.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.graphics.PointF[] newArray(int size)
			{
				return new android.graphics.PointF[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.graphics.PointF
			> CREATOR = new _Creator_109();

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
			x = @in.readFloat();
			y = @in.readFloat();
		}
	}
}
