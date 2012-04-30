using Sharpen;

namespace android.graphics.drawable.shapes
{
	/// <summary>Creates a rounded-corner rectangle.</summary>
	/// <remarks>
	/// Creates a rounded-corner rectangle. Optionally, an inset (rounded) rectangle
	/// can be included (to make a sort of "O" shape).
	/// The rounded rectangle can be drawn to a Canvas with its own draw() method,
	/// but more graphical control is available if you instead pass
	/// the RoundRectShape to a
	/// <see cref="android.graphics.drawable.ShapeDrawable">android.graphics.drawable.ShapeDrawable
	/// 	</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public class RoundRectShape : android.graphics.drawable.shapes.RectShape
	{
		private float[] mOuterRadii;

		private android.graphics.RectF mInset;

		private float[] mInnerRadii;

		private android.graphics.RectF mInnerRect;

		private android.graphics.Path mPath;

		/// <summary>RoundRectShape constructor.</summary>
		/// <remarks>
		/// RoundRectShape constructor.
		/// Specifies an outer (round)rect and an optional inner (round)rect.
		/// </remarks>
		/// <param name="outerRadii">
		/// An array of 8 radius values, for the outer roundrect.
		/// The first two floats are for the
		/// top-left corner (remaining pairs correspond clockwise).
		/// For no rounded corners on the outer rectangle,
		/// pass null.
		/// </param>
		/// <param name="inset">
		/// A RectF that specifies the distance from the inner
		/// rect to each side of the outer rect.
		/// For no inner, pass null.
		/// </param>
		/// <param name="innerRadii">
		/// An array of 8 radius values, for the inner roundrect.
		/// The first two floats are for the
		/// top-left corner (remaining pairs correspond clockwise).
		/// For no rounded corners on the inner rectangle,
		/// pass null.
		/// If inset parameter is null, this parameter is ignored.
		/// </param>
		public RoundRectShape(float[] outerRadii, android.graphics.RectF inset, float[] innerRadii
			)
		{
			// this is what we actually draw
			if (outerRadii != null && outerRadii.Length < 8)
			{
				throw new System.IndexOutOfRangeException("outer radii must have >= 8 values");
			}
			if (innerRadii != null && innerRadii.Length < 8)
			{
				throw new System.IndexOutOfRangeException("inner radii must have >= 8 values");
			}
			mOuterRadii = outerRadii;
			mInset = inset;
			mInnerRadii = innerRadii;
			if (inset != null)
			{
				mInnerRect = new android.graphics.RectF();
			}
			mPath = new android.graphics.Path();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override void draw(android.graphics.Canvas canvas, android.graphics.Paint 
			paint)
		{
			canvas.drawPath(mPath, paint);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		protected internal override void onResize(float w, float h)
		{
			base.onResize(w, h);
			android.graphics.RectF r = rect();
			mPath.reset();
			if (mOuterRadii != null)
			{
				mPath.addRoundRect(r, mOuterRadii, android.graphics.Path.Direction.CW);
			}
			else
			{
				mPath.addRect(r, android.graphics.Path.Direction.CW);
			}
			if (mInnerRect != null)
			{
				mInnerRect.set(r.left + mInset.left, r.top + mInset.top, r.right - mInset.right, 
					r.bottom - mInset.bottom);
				if (mInnerRect.width() < w && mInnerRect.height() < h)
				{
					if (mInnerRadii != null)
					{
						mPath.addRoundRect(mInnerRect, mInnerRadii, android.graphics.Path.Direction.CCW);
					}
					else
					{
						mPath.addRect(mInnerRect, android.graphics.Path.Direction.CCW);
					}
				}
			}
		}

		/// <exception cref="java.lang.CloneNotSupportedException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override android.graphics.drawable.shapes.Shape Clone()
		{
			android.graphics.drawable.shapes.RoundRectShape shape = (android.graphics.drawable.shapes.RoundRectShape
				)base.Clone();
			shape.mOuterRadii = mOuterRadii != null ? (float[])mOuterRadii.Clone() : null;
			shape.mInnerRadii = mInnerRadii != null ? (float[])mInnerRadii.Clone() : null;
			shape.mInset = new android.graphics.RectF(mInset);
			shape.mInnerRect = new android.graphics.RectF(mInnerRect);
			shape.mPath = new android.graphics.Path(mPath);
			return shape;
		}
	}
}
