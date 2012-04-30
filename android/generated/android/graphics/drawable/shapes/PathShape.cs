using Sharpen;

namespace android.graphics.drawable.shapes
{
	/// <summary>
	/// Creates geometric paths, utilizing the
	/// <see cref="android.graphics.Path">android.graphics.Path</see>
	/// class.
	/// The path can be drawn to a Canvas with its own draw() method,
	/// but more graphical control is available if you instead pass
	/// the PathShape to a
	/// <see cref="android.graphics.drawable.ShapeDrawable">android.graphics.drawable.ShapeDrawable
	/// 	</see>
	/// .
	/// </summary>
	[Sharpen.Sharpened]
	public class PathShape : android.graphics.drawable.shapes.Shape
	{
		private android.graphics.Path mPath;

		private float mStdWidth;

		private float mStdHeight;

		private float mScaleX;

		private float mScaleY;

		/// <summary>PathShape constructor.</summary>
		/// <remarks>PathShape constructor.</remarks>
		/// <param name="path">a Path that defines the geometric paths for this shape</param>
		/// <param name="stdWidth">
		/// the standard width for the shape. Any changes to the
		/// width with resize() will result in a width scaled based
		/// on the new width divided by this width.
		/// </param>
		/// <param name="stdHeight">
		/// the standard height for the shape. Any changes to the
		/// height with resize() will result in a height scaled based
		/// on the new height divided by this height.
		/// </param>
		public PathShape(android.graphics.Path path, float stdWidth, float stdHeight)
		{
			// cached from onResize
			// cached from onResize
			mPath = path;
			mStdWidth = stdWidth;
			mStdHeight = stdHeight;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override void draw(android.graphics.Canvas canvas, android.graphics.Paint 
			paint)
		{
			canvas.save();
			canvas.scale(mScaleX, mScaleY);
			canvas.drawPath(mPath, paint);
			canvas.restore();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		protected internal override void onResize(float width, float height)
		{
			mScaleX = width / mStdWidth;
			mScaleY = height / mStdHeight;
		}

		/// <exception cref="java.lang.CloneNotSupportedException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.shapes.Shape")]
		public override android.graphics.drawable.shapes.Shape Clone()
		{
			android.graphics.drawable.shapes.PathShape shape = (android.graphics.drawable.shapes.PathShape
				)base.Clone();
			shape.mPath = new android.graphics.Path(mPath);
			return shape;
		}
	}
}
