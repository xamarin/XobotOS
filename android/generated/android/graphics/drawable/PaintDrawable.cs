using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// Drawable that draws its bounds in the given paint, with optional
	/// rounded corners.
	/// </summary>
	/// <remarks>
	/// Drawable that draws its bounds in the given paint, with optional
	/// rounded corners.
	/// </remarks>
	[Sharpen.Sharpened]
	public class PaintDrawable : android.graphics.drawable.ShapeDrawable
	{
		public PaintDrawable()
		{
		}

		public PaintDrawable(int color)
		{
			getPaint().setColor(color);
		}

		/// <summary>Specify radius for the corners of the rectangle.</summary>
		/// <remarks>
		/// Specify radius for the corners of the rectangle. If this is &gt; 0, then the
		/// drawable is drawn in a round-rectangle, rather than a rectangle.
		/// </remarks>
		/// <param name="radius">the radius for the corners of the rectangle</param>
		public virtual void setCornerRadius(float radius)
		{
			float[] radii = null;
			if (radius > 0)
			{
				radii = new float[8];
				{
					for (int i = 0; i < 8; i++)
					{
						radii[i] = radius;
					}
				}
			}
			setCornerRadii(radii);
		}

		/// <summary>Specify radii for each of the 4 corners.</summary>
		/// <remarks>
		/// Specify radii for each of the 4 corners. For each corner, the array
		/// contains 2 values, [X_radius, Y_radius]. The corners are ordered
		/// top-left, top-right, bottom-right, bottom-left
		/// </remarks>
		/// <param name="radii">the x and y radii of the corners</param>
		public virtual void setCornerRadii(float[] radii)
		{
			if (radii == null)
			{
				if (getShape() != null)
				{
					setShape(null);
				}
			}
			else
			{
				setShape(new android.graphics.drawable.shapes.RoundRectShape(radii, null, null));
			}
			invalidateSelf();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.ShapeDrawable")]
		protected internal override bool inflateTag(string name, android.content.res.Resources
			 r, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs)
		{
			if (name.Equals("corners"))
			{
				android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
					styleable.DrawableCorners);
				int radius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_radius
					, 0);
				setCornerRadius(radius);
				// now check of they have any per-corner radii
				int topLeftRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_topLeftRadius
					, radius);
				int topRightRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_topRightRadius
					, radius);
				int bottomLeftRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_bottomLeftRadius
					, radius);
				int bottomRightRadius = a.getDimensionPixelSize(android.@internal.R.styleable.DrawableCorners_bottomRightRadius
					, radius);
				if (topLeftRadius != radius || topRightRadius != radius || bottomLeftRadius != radius
					 || bottomRightRadius != radius)
				{
					setCornerRadii(new float[] { topLeftRadius, topLeftRadius, topRightRadius, topRightRadius
						, bottomLeftRadius, bottomLeftRadius, bottomRightRadius, bottomRightRadius });
				}
				a.recycle();
				return true;
			}
			return base.inflateTag(name, r, parser, attrs);
		}
	}
}
