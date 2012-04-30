using Sharpen;

namespace android.graphics.drawable.shapes
{
	/// <summary>Defines an oval shape.</summary>
	/// <remarks>
	/// Defines an oval shape.
	/// The oval can be drawn to a Canvas with its own draw() method,
	/// but more graphical control is available if you instead pass
	/// the OvalShape to a
	/// <see cref="android.graphics.drawable.ShapeDrawable">android.graphics.drawable.ShapeDrawable
	/// 	</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public class OvalShape : android.graphics.drawable.shapes.RectShape
	{
		/// <summary>OvalShape constructor.</summary>
		/// <remarks>OvalShape constructor.</remarks>
		public OvalShape()
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override void draw(android.graphics.Canvas canvas, android.graphics.Paint 
			paint)
		{
			canvas.drawOval(rect(), paint);
		}
	}
}
