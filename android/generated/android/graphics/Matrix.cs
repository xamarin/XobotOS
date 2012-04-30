using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>The Matrix class holds a 3x3 matrix for transforming coordinates.</summary>
	/// <remarks>
	/// The Matrix class holds a 3x3 matrix for transforming coordinates.
	/// Matrix does not have a constructor, so it must be explicitly initialized
	/// using either reset() - to construct an identity matrix, or one of the set..()
	/// functions (e.g. setTranslate, setRotate, etc.).
	/// </remarks>
	[Sharpen.Sharpened]
	public class Matrix : System.IDisposable
	{
		public const int MSCALE_X = 0;

		public const int MSKEW_X = 1;

		public const int MTRANS_X = 2;

		public const int MSKEW_Y = 3;

		public const int MSCALE_Y = 4;

		public const int MTRANS_Y = 5;

		public const int MPERSP_0 = 6;

		public const int MPERSP_1 = 7;

		public const int MPERSP_2 = 8;

		private sealed class _Matrix_41 : android.graphics.Matrix
		{
			public _Matrix_41()
			{
			}

			//!< use with getValues/setValues
			//!< use with getValues/setValues
			//!< use with getValues/setValues
			//!< use with getValues/setValues
			//!< use with getValues/setValues
			//!< use with getValues/setValues
			//!< use with getValues/setValues
			//!< use with getValues/setValues
			//!< use with getValues/setValues
			internal void oops()
			{
				throw new System.InvalidOperationException("Matrix can not be modified");
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void set(android.graphics.Matrix src)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void reset()
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setTranslate(float dx, float dy)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setScale(float sx, float sy, float px, float py)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setScale(float sx, float sy)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setRotate(float degrees, float px, float py)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setRotate(float degrees)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setSinCos(float sinValue, float cosValue, float px, float py
				)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setSinCos(float sinValue, float cosValue)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setSkew(float kx, float ky, float px, float py)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setSkew(float kx, float ky)
			{
				this.oops();
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool setConcat(android.graphics.Matrix a, android.graphics.Matrix
				 b)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preTranslate(float dx, float dy)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preScale(float sx, float sy, float px, float py)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preScale(float sx, float sy)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preRotate(float degrees, float px, float py)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preRotate(float degrees)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preSkew(float kx, float ky, float px, float py)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preSkew(float kx, float ky)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool preConcat(android.graphics.Matrix other)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postTranslate(float dx, float dy)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postScale(float sx, float sy, float px, float py)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postScale(float sx, float sy)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postRotate(float degrees, float px, float py)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postRotate(float degrees)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postSkew(float kx, float ky, float px, float py)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postSkew(float kx, float ky)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool postConcat(android.graphics.Matrix other)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool setRectToRect(android.graphics.RectF src, android.graphics.RectF
				 dst, android.graphics.Matrix.ScaleToFit stf)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override bool setPolyToPoly(float[] src, int srcIndex, float[] dst, int dstIndex
				, int pointCount)
			{
				this.oops();
				return false;
			}

			[Sharpen.OverridesMethod(@"android.graphics.Matrix")]
			public override void setValues(float[] values)
			{
				this.oops();
			}
		}

		/// <hide></hide>
		public static android.graphics.Matrix IDENTITY_MATRIX = new _Matrix_41();

		/// <hide></hide>
		internal android.graphics.Matrix.NativeMatrix native_instance;

		/// <summary>Create an identity matrix</summary>
		public Matrix()
		{
			native_instance = native_create(null);
		}

		/// <summary>Create a matrix that is a (deep) copy of src</summary>
		/// <param name="src">The matrix to copy into this matrix</param>
		public Matrix(android.graphics.Matrix src)
		{
			native_instance = native_create(src != null ? src.native_instance : null);
		}

		/// <summary>Returns true if the matrix is identity.</summary>
		/// <remarks>
		/// Returns true if the matrix is identity.
		/// This maybe faster than testing if (getType() == 0)
		/// </remarks>
		public virtual bool isIdentity()
		{
			return native_isIdentity(native_instance);
		}

		/// <summary>Returns true if will map a rectangle to another rectangle.</summary>
		/// <remarks>
		/// Returns true if will map a rectangle to another rectangle. This can be
		/// true if the matrix is identity, scale-only, or rotates a multiple of 90
		/// degrees.
		/// </remarks>
		public virtual bool rectStaysRect()
		{
			return native_rectStaysRect(native_instance);
		}

		/// <summary>(deep) copy the src matrix into this matrix.</summary>
		/// <remarks>
		/// (deep) copy the src matrix into this matrix. If src is null, reset this
		/// matrix to the identity matrix.
		/// </remarks>
		public virtual void set(android.graphics.Matrix src)
		{
			if (src == null)
			{
				reset();
			}
			else
			{
				native_set(native_instance, src.native_instance);
			}
		}

		/// <summary>Returns true iff obj is a Matrix and its values equal our values.</summary>
		/// <remarks>Returns true iff obj is a Matrix and its values equal our values.</remarks>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object obj)
		{
			return obj != null && obj is android.graphics.Matrix && native_equals(native_instance
				, ((android.graphics.Matrix)obj).native_instance);
		}

		/// <summary>Set the matrix to identity</summary>
		public virtual void reset()
		{
			native_reset(native_instance);
		}

		/// <summary>Set the matrix to translate by (dx, dy).</summary>
		/// <remarks>Set the matrix to translate by (dx, dy).</remarks>
		public virtual void setTranslate(float dx, float dy)
		{
			native_setTranslate(native_instance, dx, dy);
		}

		/// <summary>Set the matrix to scale by sx and sy, with a pivot point at (px, py).</summary>
		/// <remarks>
		/// Set the matrix to scale by sx and sy, with a pivot point at (px, py).
		/// The pivot point is the coordinate that should remain unchanged by the
		/// specified transformation.
		/// </remarks>
		public virtual void setScale(float sx, float sy, float px, float py)
		{
			native_setScale(native_instance, sx, sy, px, py);
		}

		/// <summary>Set the matrix to scale by sx and sy.</summary>
		/// <remarks>Set the matrix to scale by sx and sy.</remarks>
		public virtual void setScale(float sx, float sy)
		{
			native_setScale(native_instance, sx, sy);
		}

		/// <summary>
		/// Set the matrix to rotate by the specified number of degrees, with a pivot
		/// point at (px, py).
		/// </summary>
		/// <remarks>
		/// Set the matrix to rotate by the specified number of degrees, with a pivot
		/// point at (px, py). The pivot point is the coordinate that should remain
		/// unchanged by the specified transformation.
		/// </remarks>
		public virtual void setRotate(float degrees, float px, float py)
		{
			native_setRotate(native_instance, degrees, px, py);
		}

		/// <summary>Set the matrix to rotate about (0,0) by the specified number of degrees.
		/// 	</summary>
		/// <remarks>Set the matrix to rotate about (0,0) by the specified number of degrees.
		/// 	</remarks>
		public virtual void setRotate(float degrees)
		{
			native_setRotate(native_instance, degrees);
		}

		/// <summary>
		/// Set the matrix to rotate by the specified sine and cosine values, with a
		/// pivot point at (px, py).
		/// </summary>
		/// <remarks>
		/// Set the matrix to rotate by the specified sine and cosine values, with a
		/// pivot point at (px, py). The pivot point is the coordinate that should
		/// remain unchanged by the specified transformation.
		/// </remarks>
		public virtual void setSinCos(float sinValue, float cosValue, float px, float py)
		{
			native_setSinCos(native_instance, sinValue, cosValue, px, py);
		}

		/// <summary>Set the matrix to rotate by the specified sine and cosine values.</summary>
		/// <remarks>Set the matrix to rotate by the specified sine and cosine values.</remarks>
		public virtual void setSinCos(float sinValue, float cosValue)
		{
			native_setSinCos(native_instance, sinValue, cosValue);
		}

		/// <summary>Set the matrix to skew by sx and sy, with a pivot point at (px, py).</summary>
		/// <remarks>
		/// Set the matrix to skew by sx and sy, with a pivot point at (px, py).
		/// The pivot point is the coordinate that should remain unchanged by the
		/// specified transformation.
		/// </remarks>
		public virtual void setSkew(float kx, float ky, float px, float py)
		{
			native_setSkew(native_instance, kx, ky, px, py);
		}

		/// <summary>Set the matrix to skew by sx and sy.</summary>
		/// <remarks>Set the matrix to skew by sx and sy.</remarks>
		public virtual void setSkew(float kx, float ky)
		{
			native_setSkew(native_instance, kx, ky);
		}

		/// <summary>
		/// Set the matrix to the concatenation of the two specified matrices,
		/// returning true if the the result can be represented.
		/// </summary>
		/// <remarks>
		/// Set the matrix to the concatenation of the two specified matrices,
		/// returning true if the the result can be represented. Either of the two
		/// matrices may also be the target matrix. this = a * b
		/// </remarks>
		public virtual bool setConcat(android.graphics.Matrix a, android.graphics.Matrix 
			b)
		{
			return native_setConcat(native_instance, a.native_instance, b.native_instance);
		}

		/// <summary>Preconcats the matrix with the specified translation.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified translation.
		/// M' = M * T(dx, dy)
		/// </remarks>
		public virtual bool preTranslate(float dx, float dy)
		{
			return native_preTranslate(native_instance, dx, dy);
		}

		/// <summary>Preconcats the matrix with the specified scale.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified scale.
		/// M' = M * S(sx, sy, px, py)
		/// </remarks>
		public virtual bool preScale(float sx, float sy, float px, float py)
		{
			return native_preScale(native_instance, sx, sy, px, py);
		}

		/// <summary>Preconcats the matrix with the specified scale.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified scale.
		/// M' = M * S(sx, sy)
		/// </remarks>
		public virtual bool preScale(float sx, float sy)
		{
			return native_preScale(native_instance, sx, sy);
		}

		/// <summary>Preconcats the matrix with the specified rotation.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified rotation.
		/// M' = M * R(degrees, px, py)
		/// </remarks>
		public virtual bool preRotate(float degrees, float px, float py)
		{
			return native_preRotate(native_instance, degrees, px, py);
		}

		/// <summary>Preconcats the matrix with the specified rotation.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified rotation.
		/// M' = M * R(degrees)
		/// </remarks>
		public virtual bool preRotate(float degrees)
		{
			return native_preRotate(native_instance, degrees);
		}

		/// <summary>Preconcats the matrix with the specified skew.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified skew.
		/// M' = M * K(kx, ky, px, py)
		/// </remarks>
		public virtual bool preSkew(float kx, float ky, float px, float py)
		{
			return native_preSkew(native_instance, kx, ky, px, py);
		}

		/// <summary>Preconcats the matrix with the specified skew.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified skew.
		/// M' = M * K(kx, ky)
		/// </remarks>
		public virtual bool preSkew(float kx, float ky)
		{
			return native_preSkew(native_instance, kx, ky);
		}

		/// <summary>Preconcats the matrix with the specified matrix.</summary>
		/// <remarks>
		/// Preconcats the matrix with the specified matrix.
		/// M' = M * other
		/// </remarks>
		public virtual bool preConcat(android.graphics.Matrix other)
		{
			return native_preConcat(native_instance, other.native_instance);
		}

		/// <summary>Postconcats the matrix with the specified translation.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified translation.
		/// M' = T(dx, dy) * M
		/// </remarks>
		public virtual bool postTranslate(float dx, float dy)
		{
			return native_postTranslate(native_instance, dx, dy);
		}

		/// <summary>Postconcats the matrix with the specified scale.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified scale.
		/// M' = S(sx, sy, px, py) * M
		/// </remarks>
		public virtual bool postScale(float sx, float sy, float px, float py)
		{
			return native_postScale(native_instance, sx, sy, px, py);
		}

		/// <summary>Postconcats the matrix with the specified scale.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified scale.
		/// M' = S(sx, sy) * M
		/// </remarks>
		public virtual bool postScale(float sx, float sy)
		{
			return native_postScale(native_instance, sx, sy);
		}

		/// <summary>Postconcats the matrix with the specified rotation.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified rotation.
		/// M' = R(degrees, px, py) * M
		/// </remarks>
		public virtual bool postRotate(float degrees, float px, float py)
		{
			return native_postRotate(native_instance, degrees, px, py);
		}

		/// <summary>Postconcats the matrix with the specified rotation.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified rotation.
		/// M' = R(degrees) * M
		/// </remarks>
		public virtual bool postRotate(float degrees)
		{
			return native_postRotate(native_instance, degrees);
		}

		/// <summary>Postconcats the matrix with the specified skew.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified skew.
		/// M' = K(kx, ky, px, py) * M
		/// </remarks>
		public virtual bool postSkew(float kx, float ky, float px, float py)
		{
			return native_postSkew(native_instance, kx, ky, px, py);
		}

		/// <summary>Postconcats the matrix with the specified skew.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified skew.
		/// M' = K(kx, ky) * M
		/// </remarks>
		public virtual bool postSkew(float kx, float ky)
		{
			return native_postSkew(native_instance, kx, ky);
		}

		/// <summary>Postconcats the matrix with the specified matrix.</summary>
		/// <remarks>
		/// Postconcats the matrix with the specified matrix.
		/// M' = other * M
		/// </remarks>
		public virtual bool postConcat(android.graphics.Matrix other)
		{
			return native_postConcat(native_instance, other.native_instance);
		}

		/// <summary>
		/// Controlls how the src rect should align into the dst rect for
		/// setRectToRect().
		/// </summary>
		/// <remarks>
		/// Controlls how the src rect should align into the dst rect for
		/// setRectToRect().
		/// </remarks>
		public enum ScaleToFit : int
		{
			/// <summary>Scale in X and Y independently, so that src matches dst exactly.</summary>
			/// <remarks>
			/// Scale in X and Y independently, so that src matches dst exactly.
			/// This may change the aspect ratio of the src.
			/// </remarks>
			FILL = 0,
			/// <summary>
			/// Compute a scale that will maintain the original src aspect ratio,
			/// but will also ensure that src fits entirely inside dst.
			/// </summary>
			/// <remarks>
			/// Compute a scale that will maintain the original src aspect ratio,
			/// but will also ensure that src fits entirely inside dst. At least one
			/// axis (X or Y) will fit exactly. START aligns the result to the
			/// left and top edges of dst.
			/// </remarks>
			START = 1,
			/// <summary>
			/// Compute a scale that will maintain the original src aspect ratio,
			/// but will also ensure that src fits entirely inside dst.
			/// </summary>
			/// <remarks>
			/// Compute a scale that will maintain the original src aspect ratio,
			/// but will also ensure that src fits entirely inside dst. At least one
			/// axis (X or Y) will fit exactly. The result is centered inside dst.
			/// </remarks>
			CENTER = 2,
			/// <summary>
			/// Compute a scale that will maintain the original src aspect ratio,
			/// but will also ensure that src fits entirely inside dst.
			/// </summary>
			/// <remarks>
			/// Compute a scale that will maintain the original src aspect ratio,
			/// but will also ensure that src fits entirely inside dst. At least one
			/// axis (X or Y) will fit exactly. END aligns the result to the
			/// right and bottom edges of dst.
			/// </remarks>
			END = 3
		}

		// the native values must match those in SkMatrix.h 
		/// <summary>
		/// Set the matrix to the scale and translate values that map the source
		/// rectangle to the destination rectangle, returning true if the the result
		/// can be represented.
		/// </summary>
		/// <remarks>
		/// Set the matrix to the scale and translate values that map the source
		/// rectangle to the destination rectangle, returning true if the the result
		/// can be represented.
		/// </remarks>
		/// <param name="src">the source rectangle to map from.</param>
		/// <param name="dst">the destination rectangle to map to.</param>
		/// <param name="stf">the ScaleToFit option</param>
		/// <returns>true if the matrix can be represented by the rectangle mapping.</returns>
		public virtual bool setRectToRect(android.graphics.RectF src, android.graphics.RectF
			 dst, android.graphics.Matrix.ScaleToFit stf)
		{
			if (dst == null || src == null)
			{
				throw new System.ArgumentNullException();
			}
			return native_setRectToRect(native_instance, src, dst, (int)stf);
		}

		// private helper to perform range checks on arrays of "points"
		private static void checkPointArrays(float[] src, int srcIndex, float[] dst, int 
			dstIndex, int pointCount)
		{
			// check for too-small and too-big indices
			int srcStop = srcIndex + (pointCount << 1);
			int dstStop = dstIndex + (pointCount << 1);
			if ((pointCount | srcIndex | dstIndex | srcStop | dstStop) < 0 || srcStop > src.Length
				 || dstStop > dst.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Set the matrix such that the specified src points would map to the
		/// specified dst points.
		/// </summary>
		/// <remarks>
		/// Set the matrix such that the specified src points would map to the
		/// specified dst points. The "points" are represented as an array of floats,
		/// order [x0, y0, x1, y1, ...], where each "point" is 2 float values.
		/// </remarks>
		/// <param name="src">The array of src [x,y] pairs (points)</param>
		/// <param name="srcIndex">Index of the first pair of src values</param>
		/// <param name="dst">The array of dst [x,y] pairs (points)</param>
		/// <param name="dstIndex">Index of the first pair of dst values</param>
		/// <param name="pointCount">The number of pairs/points to be used. Must be [0..4]</param>
		/// <returns>true if the matrix was set to the specified transformation</returns>
		public virtual bool setPolyToPoly(float[] src, int srcIndex, float[] dst, int dstIndex
			, int pointCount)
		{
			if (pointCount > 4)
			{
				throw new System.ArgumentException();
			}
			checkPointArrays(src, srcIndex, dst, dstIndex, pointCount);
			return native_setPolyToPoly(native_instance, src, srcIndex, dst, dstIndex, pointCount
				);
		}

		/// <summary>
		/// If this matrix can be inverted, return true and if inverse is not null,
		/// set inverse to be the inverse of this matrix.
		/// </summary>
		/// <remarks>
		/// If this matrix can be inverted, return true and if inverse is not null,
		/// set inverse to be the inverse of this matrix. If this matrix cannot be
		/// inverted, ignore inverse and return false.
		/// </remarks>
		public virtual bool invert(android.graphics.Matrix inverse)
		{
			return native_invert(native_instance, inverse.native_instance);
		}

		/// <summary>
		/// Apply this matrix to the array of 2D points specified by src, and write
		/// the transformed points into the array of points specified by dst.
		/// </summary>
		/// <remarks>
		/// Apply this matrix to the array of 2D points specified by src, and write
		/// the transformed points into the array of points specified by dst. The
		/// two arrays represent their "points" as pairs of floats [x, y].
		/// </remarks>
		/// <param name="dst">The array of dst points (x,y pairs)</param>
		/// <param name="dstIndex">The index of the first [x,y] pair of dst floats</param>
		/// <param name="src">The array of src points (x,y pairs)</param>
		/// <param name="srcIndex">The index of the first [x,y] pair of src floats</param>
		/// <param name="pointCount">The number of points (x,y pairs) to transform</param>
		public virtual void mapPoints(float[] dst, int dstIndex, float[] src, int srcIndex
			, int pointCount)
		{
			checkPointArrays(src, srcIndex, dst, dstIndex, pointCount);
			native_mapPoints(native_instance, dst, dstIndex, src, srcIndex, pointCount, true);
		}

		/// <summary>
		/// Apply this matrix to the array of 2D vectors specified by src, and write
		/// the transformed vectors into the array of vectors specified by dst.
		/// </summary>
		/// <remarks>
		/// Apply this matrix to the array of 2D vectors specified by src, and write
		/// the transformed vectors into the array of vectors specified by dst. The
		/// two arrays represent their "vectors" as pairs of floats [x, y].
		/// Note: this method does not apply the translation associated with the matrix. Use
		/// <see cref="mapPoints(float[], int, float[], int, int)">mapPoints(float[], int, float[], int, int)
		/// 	</see>
		/// if you want the translation
		/// to be applied.
		/// </remarks>
		/// <param name="dst">The array of dst vectors (x,y pairs)</param>
		/// <param name="dstIndex">The index of the first [x,y] pair of dst floats</param>
		/// <param name="src">The array of src vectors (x,y pairs)</param>
		/// <param name="srcIndex">The index of the first [x,y] pair of src floats</param>
		/// <param name="vectorCount">The number of vectors (x,y pairs) to transform</param>
		public virtual void mapVectors(float[] dst, int dstIndex, float[] src, int srcIndex
			, int vectorCount)
		{
			checkPointArrays(src, srcIndex, dst, dstIndex, vectorCount);
			native_mapPoints(native_instance, dst, dstIndex, src, srcIndex, vectorCount, false
				);
		}

		/// <summary>
		/// Apply this matrix to the array of 2D points specified by src, and write
		/// the transformed points into the array of points specified by dst.
		/// </summary>
		/// <remarks>
		/// Apply this matrix to the array of 2D points specified by src, and write
		/// the transformed points into the array of points specified by dst. The
		/// two arrays represent their "points" as pairs of floats [x, y].
		/// </remarks>
		/// <param name="dst">The array of dst points (x,y pairs)</param>
		/// <param name="src">The array of src points (x,y pairs)</param>
		public virtual void mapPoints(float[] dst, float[] src)
		{
			if (dst.Length != src.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			mapPoints(dst, 0, src, 0, dst.Length >> 1);
		}

		/// <summary>
		/// Apply this matrix to the array of 2D vectors specified by src, and write
		/// the transformed vectors into the array of vectors specified by dst.
		/// </summary>
		/// <remarks>
		/// Apply this matrix to the array of 2D vectors specified by src, and write
		/// the transformed vectors into the array of vectors specified by dst. The
		/// two arrays represent their "vectors" as pairs of floats [x, y].
		/// Note: this method does not apply the translation associated with the matrix. Use
		/// <see cref="mapPoints(float[], float[])">mapPoints(float[], float[])</see>
		/// if you want the translation to be applied.
		/// </remarks>
		/// <param name="dst">The array of dst vectors (x,y pairs)</param>
		/// <param name="src">The array of src vectors (x,y pairs)</param>
		public virtual void mapVectors(float[] dst, float[] src)
		{
			if (dst.Length != src.Length)
			{
				throw new System.IndexOutOfRangeException();
			}
			mapVectors(dst, 0, src, 0, dst.Length >> 1);
		}

		/// <summary>
		/// Apply this matrix to the array of 2D points, and write the transformed
		/// points back into the array
		/// </summary>
		/// <param name="pts">The array [x0, y0, x1, y1, ...] of points to transform.</param>
		public virtual void mapPoints(float[] pts)
		{
			mapPoints(pts, 0, pts, 0, pts.Length >> 1);
		}

		/// <summary>
		/// Apply this matrix to the array of 2D vectors, and write the transformed
		/// vectors back into the array.
		/// </summary>
		/// <remarks>
		/// Apply this matrix to the array of 2D vectors, and write the transformed
		/// vectors back into the array.
		/// Note: this method does not apply the translation associated with the matrix. Use
		/// <see cref="mapPoints(float[])">mapPoints(float[])</see>
		/// if you want the translation to be applied.
		/// </remarks>
		/// <param name="vecs">The array [x0, y0, x1, y1, ...] of vectors to transform.</param>
		public virtual void mapVectors(float[] vecs)
		{
			mapVectors(vecs, 0, vecs, 0, vecs.Length >> 1);
		}

		/// <summary>
		/// Apply this matrix to the src rectangle, and write the transformed
		/// rectangle into dst.
		/// </summary>
		/// <remarks>
		/// Apply this matrix to the src rectangle, and write the transformed
		/// rectangle into dst. This is accomplished by transforming the 4 corners of
		/// src, and then setting dst to the bounds of those points.
		/// </remarks>
		/// <param name="dst">Where the transformed rectangle is written.</param>
		/// <param name="src">The original rectangle to be transformed.</param>
		/// <returns>the result of calling rectStaysRect()</returns>
		public virtual bool mapRect(android.graphics.RectF dst, android.graphics.RectF src
			)
		{
			if (dst == null || src == null)
			{
				throw new System.ArgumentNullException();
			}
			return native_mapRect(native_instance, dst, src);
		}

		/// <summary>
		/// Apply this matrix to the rectangle, and write the transformed rectangle
		/// back into it.
		/// </summary>
		/// <remarks>
		/// Apply this matrix to the rectangle, and write the transformed rectangle
		/// back into it. This is accomplished by transforming the 4 corners of rect,
		/// and then setting it to the bounds of those points
		/// </remarks>
		/// <param name="rect">The rectangle to transform.</param>
		/// <returns>the result of calling rectStaysRect()</returns>
		public virtual bool mapRect(android.graphics.RectF rect)
		{
			return mapRect(rect, rect);
		}

		/// <summary>
		/// Return the mean radius of a circle after it has been mapped by
		/// this matrix.
		/// </summary>
		/// <remarks>
		/// Return the mean radius of a circle after it has been mapped by
		/// this matrix. NOTE: in perspective this value assumes the circle
		/// has its center at the origin.
		/// </remarks>
		public virtual float mapRadius(float radius)
		{
			return native_mapRadius(native_instance, radius);
		}

		/// <summary>Copy 9 values from the matrix into the array.</summary>
		/// <remarks>Copy 9 values from the matrix into the array.</remarks>
		public virtual void getValues(float[] values)
		{
			if (values.Length < 9)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_getValues(native_instance, values);
		}

		/// <summary>Copy 9 values from the array into the matrix.</summary>
		/// <remarks>
		/// Copy 9 values from the array into the matrix.
		/// Depending on the implementation of Matrix, these may be
		/// transformed into 16.16 integers in the Matrix, such that
		/// a subsequent call to getValues() will not yield exactly
		/// the same values.
		/// </remarks>
		public virtual void setValues(float[] values)
		{
			if (values.Length < 9)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_setValues(native_instance, values);
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(64);
			sb.append("Matrix{");
			toShortString(sb);
			sb.append('}');
			return sb.ToString();
		}

		public virtual string toShortString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(64);
			toShortString(sb);
			return sb.ToString();
		}

		/// <hide></hide>
		public virtual void toShortString(java.lang.StringBuilder sb)
		{
			float[] values = new float[9];
			getValues(values);
			sb.append('[');
			sb.append(values[0]);
			sb.append(", ");
			sb.append(values[1]);
			sb.append(", ");
			sb.append(values[2]);
			sb.append("][");
			sb.append(values[3]);
			sb.append(", ");
			sb.append(values[4]);
			sb.append(", ");
			sb.append(values[5]);
			sb.append("][");
			sb.append(values[6]);
			sb.append(", ");
			sb.append(values[7]);
			sb.append(", ");
			sb.append(values[8]);
			sb.append(']');
		}

		/// <summary>Print short string, to optimize dumping.</summary>
		/// <remarks>Print short string, to optimize dumping.</remarks>
		/// <hide></hide>
		public virtual void printShortString(java.io.PrintWriter pw)
		{
			float[] values = new float[9];
			getValues(values);
			pw.print('[');
			pw.print(values[0]);
			pw.print(", ");
			pw.print(values[1]);
			pw.print(", ");
			pw.print(values[2]);
			pw.print("][");
			pw.print(values[3]);
			pw.print(", ");
			pw.print(values[4]);
			pw.print(", ");
			pw.print(values[5]);
			pw.print("][");
			pw.print(values[6]);
			pw.print(", ");
			pw.print(values[7]);
			pw.print(", ");
			pw.print(values[8]);
			pw.print(']');
		}

		~Matrix()
		{
			finalizer(native_instance);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Matrix.NativeMatrix libxobotos_Matrix_constructor
			(android.graphics.Matrix.NativeMatrix native_src_or_zero);

		private static android.graphics.Matrix.NativeMatrix native_create(android.graphics.Matrix.NativeMatrix
			 native_src_or_zero)
		{
			return libxobotos_Matrix_constructor(native_src_or_zero != null ? native_src_or_zero
				 : android.graphics.Matrix.NativeMatrix.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_isIdentity(android.graphics.Matrix.NativeMatrix
			 native_object);

		private static bool native_isIdentity(android.graphics.Matrix.NativeMatrix native_object
			)
		{
			return libxobotos_Matrix_isIdentity(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_rectStaysRect(android.graphics.Matrix.NativeMatrix
			 native_object);

		private static bool native_rectStaysRect(android.graphics.Matrix.NativeMatrix native_object
			)
		{
			return libxobotos_Matrix_rectStaysRect(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_reset(android.graphics.Matrix.NativeMatrix
			 native_object);

		private static void native_reset(android.graphics.Matrix.NativeMatrix native_object
			)
		{
			libxobotos_Matrix_reset(native_object);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_set(android.graphics.Matrix.NativeMatrix
			 native_object, android.graphics.Matrix.NativeMatrix other);

		private static void native_set(android.graphics.Matrix.NativeMatrix native_object
			, android.graphics.Matrix.NativeMatrix other)
		{
			libxobotos_Matrix_set(native_object, other);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setTranslate(android.graphics.Matrix.NativeMatrix
			 native_object, float dx, float dy);

		private static void native_setTranslate(android.graphics.Matrix.NativeMatrix native_object
			, float dx, float dy)
		{
			libxobotos_Matrix_setTranslate(native_object, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setScale(android.graphics.Matrix.NativeMatrix
			 native_object, float sx, float sy, float px, float py);

		private static void native_setScale(android.graphics.Matrix.NativeMatrix native_object
			, float sx, float sy, float px, float py)
		{
			libxobotos_Matrix_setScale(native_object, sx, sy, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setScale_0(android.graphics.Matrix.NativeMatrix
			 native_object, float sx, float sy);

		private static void native_setScale(android.graphics.Matrix.NativeMatrix native_object
			, float sx, float sy)
		{
			libxobotos_Matrix_setScale_0(native_object, sx, sy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setRotate(android.graphics.Matrix.NativeMatrix
			 native_object, float degrees, float px, float py);

		private static void native_setRotate(android.graphics.Matrix.NativeMatrix native_object
			, float degrees, float px, float py)
		{
			libxobotos_Matrix_setRotate(native_object, degrees, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setRotate_0(android.graphics.Matrix.NativeMatrix
			 native_object, float degrees);

		private static void native_setRotate(android.graphics.Matrix.NativeMatrix native_object
			, float degrees)
		{
			libxobotos_Matrix_setRotate_0(native_object, degrees);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setSinCos(android.graphics.Matrix.NativeMatrix
			 native_object, float sinValue, float cosValue, float px, float py);

		private static void native_setSinCos(android.graphics.Matrix.NativeMatrix native_object
			, float sinValue, float cosValue, float px, float py)
		{
			libxobotos_Matrix_setSinCos(native_object, sinValue, cosValue, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setSinCos_0(android.graphics.Matrix.NativeMatrix
			 native_object, float sinValue, float cosValue);

		private static void native_setSinCos(android.graphics.Matrix.NativeMatrix native_object
			, float sinValue, float cosValue)
		{
			libxobotos_Matrix_setSinCos_0(native_object, sinValue, cosValue);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setSkew(android.graphics.Matrix.NativeMatrix
			 native_object, float kx, float ky, float px, float py);

		private static void native_setSkew(android.graphics.Matrix.NativeMatrix native_object
			, float kx, float ky, float px, float py)
		{
			libxobotos_Matrix_setSkew(native_object, kx, ky, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setSkew_0(android.graphics.Matrix.NativeMatrix
			 native_object, float kx, float ky);

		private static void native_setSkew(android.graphics.Matrix.NativeMatrix native_object
			, float kx, float ky)
		{
			libxobotos_Matrix_setSkew_0(native_object, kx, ky);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_setConcat(android.graphics.Matrix.NativeMatrix
			 native_object, android.graphics.Matrix.NativeMatrix a, android.graphics.Matrix.NativeMatrix
			 b);

		private static bool native_setConcat(android.graphics.Matrix.NativeMatrix native_object
			, android.graphics.Matrix.NativeMatrix a, android.graphics.Matrix.NativeMatrix b
			)
		{
			return libxobotos_Matrix_setConcat(native_object, a, b);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preTranslate(android.graphics.Matrix.NativeMatrix
			 native_object, float dx, float dy);

		private static bool native_preTranslate(android.graphics.Matrix.NativeMatrix native_object
			, float dx, float dy)
		{
			return libxobotos_Matrix_preTranslate(native_object, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preScale(android.graphics.Matrix.NativeMatrix
			 native_object, float sx, float sy, float px, float py);

		private static bool native_preScale(android.graphics.Matrix.NativeMatrix native_object
			, float sx, float sy, float px, float py)
		{
			return libxobotos_Matrix_preScale(native_object, sx, sy, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preScale_0(android.graphics.Matrix.NativeMatrix
			 native_object, float sx, float sy);

		private static bool native_preScale(android.graphics.Matrix.NativeMatrix native_object
			, float sx, float sy)
		{
			return libxobotos_Matrix_preScale_0(native_object, sx, sy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preRotate(android.graphics.Matrix.NativeMatrix
			 native_object, float degrees, float px, float py);

		private static bool native_preRotate(android.graphics.Matrix.NativeMatrix native_object
			, float degrees, float px, float py)
		{
			return libxobotos_Matrix_preRotate(native_object, degrees, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preRotate_0(android.graphics.Matrix.NativeMatrix
			 native_object, float degrees);

		private static bool native_preRotate(android.graphics.Matrix.NativeMatrix native_object
			, float degrees)
		{
			return libxobotos_Matrix_preRotate_0(native_object, degrees);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preSkew(android.graphics.Matrix.NativeMatrix
			 native_object, float kx, float ky, float px, float py);

		private static bool native_preSkew(android.graphics.Matrix.NativeMatrix native_object
			, float kx, float ky, float px, float py)
		{
			return libxobotos_Matrix_preSkew(native_object, kx, ky, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preSkew_0(android.graphics.Matrix.NativeMatrix
			 native_object, float kx, float ky);

		private static bool native_preSkew(android.graphics.Matrix.NativeMatrix native_object
			, float kx, float ky)
		{
			return libxobotos_Matrix_preSkew_0(native_object, kx, ky);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_preConcat(android.graphics.Matrix.NativeMatrix
			 native_object, android.graphics.Matrix.NativeMatrix other_matrix);

		private static bool native_preConcat(android.graphics.Matrix.NativeMatrix native_object
			, android.graphics.Matrix.NativeMatrix other_matrix)
		{
			return libxobotos_Matrix_preConcat(native_object, other_matrix);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postTranslate(android.graphics.Matrix.NativeMatrix
			 native_object, float dx, float dy);

		private static bool native_postTranslate(android.graphics.Matrix.NativeMatrix native_object
			, float dx, float dy)
		{
			return libxobotos_Matrix_postTranslate(native_object, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postScale(android.graphics.Matrix.NativeMatrix
			 native_object, float sx, float sy, float px, float py);

		private static bool native_postScale(android.graphics.Matrix.NativeMatrix native_object
			, float sx, float sy, float px, float py)
		{
			return libxobotos_Matrix_postScale(native_object, sx, sy, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postScale_0(android.graphics.Matrix.NativeMatrix
			 native_object, float sx, float sy);

		private static bool native_postScale(android.graphics.Matrix.NativeMatrix native_object
			, float sx, float sy)
		{
			return libxobotos_Matrix_postScale_0(native_object, sx, sy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postRotate(android.graphics.Matrix.NativeMatrix
			 native_object, float degrees, float px, float py);

		private static bool native_postRotate(android.graphics.Matrix.NativeMatrix native_object
			, float degrees, float px, float py)
		{
			return libxobotos_Matrix_postRotate(native_object, degrees, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postRotate_0(android.graphics.Matrix.NativeMatrix
			 native_object, float degrees);

		private static bool native_postRotate(android.graphics.Matrix.NativeMatrix native_object
			, float degrees)
		{
			return libxobotos_Matrix_postRotate_0(native_object, degrees);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postSkew(android.graphics.Matrix.NativeMatrix
			 native_object, float kx, float ky, float px, float py);

		private static bool native_postSkew(android.graphics.Matrix.NativeMatrix native_object
			, float kx, float ky, float px, float py)
		{
			return libxobotos_Matrix_postSkew(native_object, kx, ky, px, py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postSkew_0(android.graphics.Matrix.NativeMatrix
			 native_object, float kx, float ky);

		private static bool native_postSkew(android.graphics.Matrix.NativeMatrix native_object
			, float kx, float ky)
		{
			return libxobotos_Matrix_postSkew_0(native_object, kx, ky);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_postConcat(android.graphics.Matrix.NativeMatrix
			 native_object, android.graphics.Matrix.NativeMatrix other_matrix);

		private static bool native_postConcat(android.graphics.Matrix.NativeMatrix native_object
			, android.graphics.Matrix.NativeMatrix other_matrix)
		{
			return libxobotos_Matrix_postConcat(native_object, other_matrix);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_setRectToRect(android.graphics.Matrix.NativeMatrix
			 native_object, System.IntPtr src, System.IntPtr dst, int stf);

		private static bool native_setRectToRect(android.graphics.Matrix.NativeMatrix native_object
			, android.graphics.RectF src, android.graphics.RectF dst, int stf)
		{
			System.IntPtr src_ptr = System.IntPtr.Zero;
			System.IntPtr dst_ptr = System.IntPtr.Zero;
			try
			{
				src_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(src);
				dst_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(dst);
				return libxobotos_Matrix_setRectToRect(native_object, src_ptr, dst_ptr, stf);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(src_ptr);
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(dst_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_setPolyToPoly(android.graphics.Matrix.NativeMatrix
			 native_object, System.IntPtr src, int srcIndex, System.IntPtr dst, int dstIndex
			, int pointCount);

		private static bool native_setPolyToPoly(android.graphics.Matrix.NativeMatrix native_object
			, float[] src, int srcIndex, float[] dst, int dstIndex, int pointCount)
		{
			Sharpen.INativeHandle src_handle = null;
			Sharpen.INativeHandle dst_handle = null;
			try
			{
				src_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(src);
				dst_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(dst);
				return libxobotos_Matrix_setPolyToPoly(native_object, src_handle.Address, srcIndex
					, dst_handle.Address, dstIndex, pointCount);
			}
			finally
			{
				if (src_handle != null)
				{
					src_handle.Free();
				}
				if (dst_handle != null)
				{
					dst_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_invert(android.graphics.Matrix.NativeMatrix
			 native_object, android.graphics.Matrix.NativeMatrix inverse);

		private static bool native_invert(android.graphics.Matrix.NativeMatrix native_object
			, android.graphics.Matrix.NativeMatrix inverse)
		{
			return libxobotos_Matrix_invert(native_object, inverse);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_mapPoints(android.graphics.Matrix.NativeMatrix
			 native_object, System.IntPtr dst, int dstIndex, System.IntPtr src, int srcIndex
			, int ptCount, bool isPts);

		private static void native_mapPoints(android.graphics.Matrix.NativeMatrix native_object
			, float[] dst, int dstIndex, float[] src, int srcIndex, int ptCount, bool isPts)
		{
			Sharpen.INativeHandle dst_handle = null;
			Sharpen.INativeHandle src_handle = null;
			try
			{
				dst_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(dst);
				src_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(src);
				libxobotos_Matrix_mapPoints(native_object, dst_handle.Address, dstIndex, src_handle
					.Address, srcIndex, ptCount, isPts);
			}
			finally
			{
				if (dst_handle != null)
				{
					dst_handle.Free();
				}
				if (src_handle != null)
				{
					src_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_mapRect(android.graphics.Matrix.NativeMatrix
			 native_object, System.IntPtr dst, System.IntPtr src);

		private static bool native_mapRect(android.graphics.Matrix.NativeMatrix native_object
			, android.graphics.RectF dst, android.graphics.RectF src)
		{
			System.IntPtr dst_ptr = System.IntPtr.Zero;
			System.IntPtr src_ptr = System.IntPtr.Zero;
			try
			{
				dst_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(dst);
				src_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(src);
				bool _retval = libxobotos_Matrix_mapRect(native_object, dst_ptr, src_ptr);
				android.graphics.RectF.RectF_Helper.MarshalOut(dst_ptr, dst);
				return _retval;
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(dst_ptr);
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(src_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_Matrix_mapRadius(android.graphics.Matrix.NativeMatrix
			 native_object, float radius);

		private static float native_mapRadius(android.graphics.Matrix.NativeMatrix native_object
			, float radius)
		{
			return libxobotos_Matrix_mapRadius(native_object, radius);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_getValues(android.graphics.Matrix.NativeMatrix
			 native_object, System.IntPtr values);

		private static void native_getValues(android.graphics.Matrix.NativeMatrix native_object
			, float[] values)
		{
			Sharpen.INativeHandle values_handle = null;
			try
			{
				values_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(values
					);
				libxobotos_Matrix_getValues(native_object, values_handle.Address);
			}
			finally
			{
				if (values_handle != null)
				{
					values_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matrix_setValues(android.graphics.Matrix.NativeMatrix
			 native_object, System.IntPtr values);

		private static void native_setValues(android.graphics.Matrix.NativeMatrix native_object
			, float[] values)
		{
			Sharpen.INativeHandle values_handle = null;
			try
			{
				values_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(values
					);
				libxobotos_Matrix_setValues(native_object, values_handle.Address);
			}
			finally
			{
				if (values_handle != null)
				{
					values_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matrix_equals(android.graphics.Matrix.NativeMatrix
			 native_a, android.graphics.Matrix.NativeMatrix native_b);

		private static bool native_equals(android.graphics.Matrix.NativeMatrix native_a, 
			android.graphics.Matrix.NativeMatrix native_b)
		{
			return libxobotos_Matrix_equals(native_a, native_b);
		}

		private static void finalizer(android.graphics.Matrix.NativeMatrix native_instance
			)
		{
			native_instance.Dispose();
		}

		internal NativeMatrix nativeInstance
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

		internal class NativeMatrix : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeMatrix() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeMatrix(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Matrix_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeMatrix Zero = new NativeMatrix();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Matrix_destructor(handle);
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
