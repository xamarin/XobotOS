using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// Defines the transformation to be applied at
	/// one point in time of an Animation.
	/// </summary>
	/// <remarks>
	/// Defines the transformation to be applied at
	/// one point in time of an Animation.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Transformation
	{
		/// <summary>Indicates a transformation that has no effect (alpha = 1 and identity matrix.)
		/// 	</summary>
		public static int TYPE_IDENTITY = unchecked((int)(0x0));

		/// <summary>Indicates a transformation that applies an alpha only (uses an identity matrix.)
		/// 	</summary>
		public static int TYPE_ALPHA = unchecked((int)(0x1));

		/// <summary>Indicates a transformation that applies a matrix only (alpha = 1.)</summary>
		public static int TYPE_MATRIX = unchecked((int)(0x2));

		/// <summary>Indicates a transformation that applies an alpha and a matrix.</summary>
		/// <remarks>Indicates a transformation that applies an alpha and a matrix.</remarks>
		public static int TYPE_BOTH = TYPE_ALPHA | TYPE_MATRIX;

		protected internal android.graphics.Matrix mMatrix;

		protected internal float mAlpha;

		protected internal int mTransformationType;

		/// <summary>Creates a new transformation with alpha = 1 and the identity matrix.</summary>
		/// <remarks>Creates a new transformation with alpha = 1 and the identity matrix.</remarks>
		public Transformation()
		{
			clear();
		}

		/// <summary>
		/// Reset the transformation to a state that leaves the object
		/// being animated in an unmodified state.
		/// </summary>
		/// <remarks>
		/// Reset the transformation to a state that leaves the object
		/// being animated in an unmodified state. The transformation type is
		/// <see cref="TYPE_BOTH">TYPE_BOTH</see>
		/// by default.
		/// </remarks>
		public virtual void clear()
		{
			if (mMatrix == null)
			{
				mMatrix = new android.graphics.Matrix();
			}
			else
			{
				mMatrix.reset();
			}
			mAlpha = 1.0f;
			mTransformationType = TYPE_BOTH;
		}

		/// <summary>Indicates the nature of this transformation.</summary>
		/// <remarks>Indicates the nature of this transformation.</remarks>
		/// <returns>
		/// 
		/// <see cref="TYPE_ALPHA">TYPE_ALPHA</see>
		/// ,
		/// <see cref="TYPE_MATRIX">TYPE_MATRIX</see>
		/// ,
		/// <see cref="TYPE_BOTH">TYPE_BOTH</see>
		/// or
		/// <see cref="TYPE_IDENTITY">TYPE_IDENTITY</see>
		/// .
		/// </returns>
		public virtual int getTransformationType()
		{
			return mTransformationType;
		}

		/// <summary>Sets the transformation type.</summary>
		/// <remarks>Sets the transformation type.</remarks>
		/// <param name="transformationType">
		/// One of
		/// <see cref="TYPE_ALPHA">TYPE_ALPHA</see>
		/// ,
		/// <see cref="TYPE_MATRIX">TYPE_MATRIX</see>
		/// ,
		/// <see cref="TYPE_BOTH">TYPE_BOTH</see>
		/// or
		/// <see cref="TYPE_IDENTITY">TYPE_IDENTITY</see>
		/// .
		/// </param>
		public virtual void setTransformationType(int transformationType)
		{
			mTransformationType = transformationType;
		}

		/// <summary>Clones the specified transformation.</summary>
		/// <remarks>Clones the specified transformation.</remarks>
		/// <param name="t">The transformation to clone.</param>
		public virtual void set(android.view.animation.Transformation t)
		{
			mAlpha = t.getAlpha();
			mMatrix.set(t.getMatrix());
			mTransformationType = t.getTransformationType();
		}

		/// <summary>Apply this Transformation to an existing Transformation, e.g.</summary>
		/// <remarks>
		/// Apply this Transformation to an existing Transformation, e.g. apply
		/// a scale effect to something that has already been rotated.
		/// </remarks>
		/// <param name="t"></param>
		public virtual void compose(android.view.animation.Transformation t)
		{
			mAlpha *= t.getAlpha();
			mMatrix.preConcat(t.getMatrix());
		}

		/// <returns>
		/// The 3x3 Matrix representing the trnasformation to apply to the
		/// coordinates of the object being animated
		/// </returns>
		public virtual android.graphics.Matrix getMatrix()
		{
			return mMatrix;
		}

		/// <summary>Sets the degree of transparency</summary>
		/// <param name="alpha">1.0 means fully opaqe and 0.0 means fully transparent</param>
		public virtual void setAlpha(float alpha)
		{
			mAlpha = alpha;
		}

		/// <returns>The degree of transparency</returns>
		public virtual float getAlpha()
		{
			return mAlpha;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(64);
			sb.append("Transformation");
			toShortString(sb);
			return sb.ToString();
		}

		/// <summary>Return a string representation of the transformation in a compact form.</summary>
		/// <remarks>Return a string representation of the transformation in a compact form.</remarks>
		public virtual string toShortString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(64);
			toShortString(sb);
			return sb.ToString();
		}

		/// <hide></hide>
		public virtual void toShortString(java.lang.StringBuilder sb)
		{
			sb.append("{alpha=");
			sb.append(mAlpha);
			sb.append(" matrix=");
			mMatrix.toShortString(sb);
			sb.append('}');
		}

		/// <summary>Print short string, to optimize dumping.</summary>
		/// <remarks>Print short string, to optimize dumping.</remarks>
		/// <hide></hide>
		public virtual void printShortString(java.io.PrintWriter pw)
		{
			pw.print("{alpha=");
			pw.print(mAlpha);
			pw.print(" matrix=");
			mMatrix.printShortString(pw);
			pw.print('}');
		}
	}
}
