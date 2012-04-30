using Sharpen;

namespace android.graphics.drawable.shapes
{
	/// <summary>Defines a rectangle shape.</summary>
	/// <remarks>
	/// Defines a rectangle shape.
	/// The rectangle can be drawn to a Canvas with its own draw() method,
	/// but more graphical control is available if you instead pass
	/// the RectShape to a
	/// <see cref="android.graphics.drawable.ShapeDrawable">android.graphics.drawable.ShapeDrawable
	/// 	</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public class RectShape : android.graphics.drawable.shapes.Shape
	{
		private android.graphics.RectF mRect = new android.graphics.RectF();

		/// <summary>RectShape constructor.</summary>
		/// <remarks>RectShape constructor.</remarks>
		public RectShape()
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override void draw(android.graphics.Canvas canvas, android.graphics.Paint 
			paint)
		{
			canvas.drawRect(mRect, paint);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		protected internal override void onResize(float width, float height)
		{
			mRect.set(0, 0, width, height);
		}

		/// <summary>Returns the RectF that defines this rectangle's bounds.</summary>
		/// <remarks>Returns the RectF that defines this rectangle's bounds.</remarks>
		protected internal android.graphics.RectF rect()
		{
			return mRect;
		}

		/// <exception cref="java.lang.CloneNotSupportedException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override android.graphics.drawable.shapes.Shape Clone()
		{
			android.graphics.drawable.shapes.RectShape shape = (android.graphics.drawable.shapes.RectShape
				)base.Clone();
			shape.mRect = new android.graphics.RectF(mRect);
			return shape;
		}
	}
}
