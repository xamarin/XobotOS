using Sharpen;

namespace android.graphics
{
	/// <summary>5x4 matrix for transforming the color+alpha components of a Bitmap.</summary>
	/// <remarks>
	/// 5x4 matrix for transforming the color+alpha components of a Bitmap.
	/// The matrix is stored in a single array, and its treated as follows:
	/// [ a, b, c, d, e,
	/// f, g, h, i, j,
	/// k, l, m, n, o,
	/// p, q, r, s, t ]
	/// When applied to a color [r, g, b, a], the resulting color is computed as
	/// (after clamping)
	/// R' = a*R + b*G + c*B + d*A + e;
	/// G' = f*R + g*G + h*B + i*A + j;
	/// B' = k*R + l*G + m*B + n*A + o;
	/// A' = p*R + q*G + r*B + s*A + t;
	/// </remarks>
	[Sharpen.Sharpened]
	public class ColorMatrix
	{
		private readonly float[] mArray = new float[20];

		/// <summary>
		/// Create a new colormatrix initialized to identity (as if reset() had
		/// been called).
		/// </summary>
		/// <remarks>
		/// Create a new colormatrix initialized to identity (as if reset() had
		/// been called).
		/// </remarks>
		public ColorMatrix()
		{
			reset();
		}

		/// <summary>Create a new colormatrix initialized with the specified array of values.
		/// 	</summary>
		/// <remarks>Create a new colormatrix initialized with the specified array of values.
		/// 	</remarks>
		public ColorMatrix(float[] src)
		{
			System.Array.Copy(src, 0, mArray, 0, 20);
		}

		/// <summary>Create a new colormatrix initialized with the specified colormatrix.</summary>
		/// <remarks>Create a new colormatrix initialized with the specified colormatrix.</remarks>
		public ColorMatrix(android.graphics.ColorMatrix src)
		{
			System.Array.Copy(src.mArray, 0, mArray, 0, 20);
		}

		/// <summary>Return the array of floats representing this colormatrix.</summary>
		/// <remarks>Return the array of floats representing this colormatrix.</remarks>
		public float[] getArray()
		{
			return mArray;
		}

		/// <summary>
		/// Set this colormatrix to identity:
		/// [ 1 0 0 0 0   - red vector
		/// 0 1 0 0 0   - green vector
		/// 0 0 1 0 0   - blue vector
		/// 0 0 0 1 0 ] - alpha vector
		/// </summary>
		public virtual void reset()
		{
			float[] a = mArray;
			{
				for (int i = 19; i > 0; --i)
				{
					a[i] = 0;
				}
			}
			a[0] = a[6] = a[12] = a[18] = 1;
		}

		/// <summary>Assign the src colormatrix into this matrix, copying all of its values.</summary>
		/// <remarks>Assign the src colormatrix into this matrix, copying all of its values.</remarks>
		public virtual void set(android.graphics.ColorMatrix src)
		{
			System.Array.Copy(src.mArray, 0, mArray, 0, 20);
		}

		/// <summary>Assign the array of floats into this matrix, copying all of its values.</summary>
		/// <remarks>Assign the array of floats into this matrix, copying all of its values.</remarks>
		public virtual void set(float[] src)
		{
			System.Array.Copy(src, 0, mArray, 0, 20);
		}

		/// <summary>Set this colormatrix to scale by the specified values.</summary>
		/// <remarks>Set this colormatrix to scale by the specified values.</remarks>
		public virtual void setScale(float rScale, float gScale, float bScale, float aScale
			)
		{
			float[] a = mArray;
			{
				for (int i = 19; i > 0; --i)
				{
					a[i] = 0;
				}
			}
			a[0] = rScale;
			a[6] = gScale;
			a[12] = bScale;
			a[18] = aScale;
		}

		/// <summary>Set the rotation on a color axis by the specified values.</summary>
		/// <remarks>
		/// Set the rotation on a color axis by the specified values.
		/// axis=0 correspond to a rotation around the RED color
		/// axis=1 correspond to a rotation around the GREEN color
		/// axis=2 correspond to a rotation around the BLUE color
		/// </remarks>
		public virtual void setRotate(int axis, float degrees)
		{
			reset();
			float radians = degrees * (float)System.Math.PI / 180;
			float cosine = android.util.FloatMath.cos(radians);
			float sine = android.util.FloatMath.sin(radians);
			switch (axis)
			{
				case 0:
				{
					// Rotation around the red color
					mArray[6] = mArray[12] = cosine;
					mArray[7] = sine;
					mArray[11] = -sine;
					break;
				}

				case 1:
				{
					// Rotation around the green color
					mArray[0] = mArray[12] = cosine;
					mArray[2] = -sine;
					mArray[10] = sine;
					break;
				}

				case 2:
				{
					// Rotation around the blue color
					mArray[0] = mArray[6] = cosine;
					mArray[1] = sine;
					mArray[5] = -sine;
					break;
				}

				default:
				{
					throw new java.lang.RuntimeException();
				}
			}
		}

		/// <summary>
		/// Set this colormatrix to the concatenation of the two specified
		/// colormatrices, such that the resulting colormatrix has the same effect
		/// as applying matB and then applying matA.
		/// </summary>
		/// <remarks>
		/// Set this colormatrix to the concatenation of the two specified
		/// colormatrices, such that the resulting colormatrix has the same effect
		/// as applying matB and then applying matA. It is legal for either matA or
		/// matB to be the same colormatrix as this.
		/// </remarks>
		public virtual void setConcat(android.graphics.ColorMatrix matA, android.graphics.ColorMatrix
			 matB)
		{
			float[] tmp = null;
			if (matA == this || matB == this)
			{
				tmp = new float[20];
			}
			else
			{
				tmp = mArray;
			}
			float[] a = matA.mArray;
			float[] b = matB.mArray;
			int index = 0;
			{
				for (int j = 0; j < 20; j += 5)
				{
					{
						for (int i = 0; i < 4; i++)
						{
							tmp[index++] = a[j + 0] * b[i + 0] + a[j + 1] * b[i + 5] + a[j + 2] * b[i + 10] +
								 a[j + 3] * b[i + 15];
						}
					}
					tmp[index++] = a[j + 0] * b[4] + a[j + 1] * b[9] + a[j + 2] * b[14] + a[j + 3] * 
						b[19] + a[j + 4];
				}
			}
			if (tmp != mArray)
			{
				System.Array.Copy(tmp, 0, mArray, 0, 20);
			}
		}

		/// <summary>Concat this colormatrix with the specified prematrix.</summary>
		/// <remarks>
		/// Concat this colormatrix with the specified prematrix. This is logically
		/// the same as calling setConcat(this, prematrix);
		/// </remarks>
		public virtual void preConcat(android.graphics.ColorMatrix prematrix)
		{
			setConcat(this, prematrix);
		}

		/// <summary>Concat this colormatrix with the specified postmatrix.</summary>
		/// <remarks>
		/// Concat this colormatrix with the specified postmatrix. This is logically
		/// the same as calling setConcat(postmatrix, this);
		/// </remarks>
		public virtual void postConcat(android.graphics.ColorMatrix postmatrix)
		{
			setConcat(postmatrix, this);
		}

		///////////////////////////////////////////////////////////////////////////
		/// <summary>Set the matrix to affect the saturation of colors.</summary>
		/// <remarks>
		/// Set the matrix to affect the saturation of colors. A value of 0 maps the
		/// color to gray-scale. 1 is identity.
		/// </remarks>
		public virtual void setSaturation(float sat)
		{
			reset();
			float[] m = mArray;
			float invSat = 1 - sat;
			float R = 0.213f * invSat;
			float G = 0.715f * invSat;
			float B = 0.072f * invSat;
			m[0] = R + sat;
			m[1] = G;
			m[2] = B;
			m[5] = R;
			m[6] = G + sat;
			m[7] = B;
			m[10] = R;
			m[11] = G;
			m[12] = B + sat;
		}

		/// <summary>Set the matrix to convert RGB to YUV</summary>
		public virtual void setRGB2YUV()
		{
			reset();
			float[] m = mArray;
			// these coefficients match those in libjpeg
			m[0] = 0.299f;
			m[1] = 0.587f;
			m[2] = 0.114f;
			m[5] = -0.16874f;
			m[6] = -0.33126f;
			m[7] = 0.5f;
			m[10] = 0.5f;
			m[11] = -0.41869f;
			m[12] = -0.08131f;
		}

		/// <summary>Set the matrix to convert from YUV to RGB</summary>
		public virtual void setYUV2RGB()
		{
			reset();
			float[] m = mArray;
			// these coefficients match those in libjpeg
			m[2] = 1.402f;
			m[5] = 1;
			m[6] = -0.34414f;
			m[7] = -0.71414f;
			m[10] = 1;
			m[11] = 1.772f;
			m[12] = 0;
		}
	}
}
