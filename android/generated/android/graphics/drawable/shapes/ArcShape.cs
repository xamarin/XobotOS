using Sharpen;

namespace android.graphics.drawable.shapes
{
	/// <summary>Creates an arc shape.</summary>
	/// <remarks>
	/// Creates an arc shape. The arc shape starts at a specified
	/// angle and sweeps clockwise, drawing slices of pie.
	/// The arc can be drawn to a Canvas with its own draw() method,
	/// but more graphical control is available if you instead pass
	/// the ArcShape to a
	/// <see cref="android.graphics.drawable.ShapeDrawable">android.graphics.drawable.ShapeDrawable
	/// 	</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public class ArcShape : android.graphics.drawable.shapes.RectShape
	{
		private float mStart;

		private float mSweep;

		/// <summary>ArcShape constructor.</summary>
		/// <remarks>ArcShape constructor.</remarks>
		/// <param name="startAngle">the angle (in degrees) where the arc begins</param>
		/// <param name="sweepAngle">
		/// the sweep angle (in degrees). Anything equal to or
		/// greater than 360 results in a complete circle/oval.
		/// </param>
		public ArcShape(float startAngle, float sweepAngle)
		{
			mStart = startAngle;
			mSweep = sweepAngle;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override void draw(android.graphics.Canvas canvas, android.graphics.Paint 
			paint)
		{
			canvas.drawArc(rect(), mStart, mSweep, true, paint);
		}
	}
}
