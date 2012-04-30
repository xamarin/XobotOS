using Sharpen;

namespace android.graphics.drawable.shapes
{
	/// <summary>
	/// Defines a generic graphical "shape."
	/// Any Shape can be drawn to a Canvas with its own draw() method,
	/// but more graphical control is available if you instead pass
	/// it to a
	/// <see cref="android.graphics.drawable.ShapeDrawable">android.graphics.drawable.ShapeDrawable
	/// 	</see>
	/// .
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class Shape : System.ICloneable
	{
		private float mWidth;

		private float mHeight;

		/// <summary>Returns the width of the Shape.</summary>
		/// <remarks>Returns the width of the Shape.</remarks>
		public float getWidth()
		{
			return mWidth;
		}

		/// <summary>Returns the height of the Shape.</summary>
		/// <remarks>Returns the height of the Shape.</remarks>
		public float getHeight()
		{
			return mHeight;
		}

		/// <summary>Draw this shape into the provided Canvas, with the provided Paint.</summary>
		/// <remarks>
		/// Draw this shape into the provided Canvas, with the provided Paint.
		/// Before calling this, you must call
		/// <see cref="resize(float, float)">resize(float, float)</see>
		/// .
		/// </remarks>
		/// <param name="canvas">the Canvas within which this shape should be drawn</param>
		/// <param name="paint">the Paint object that defines this shape's characteristics</param>
		public abstract void draw(android.graphics.Canvas canvas, android.graphics.Paint 
			paint);

		/// <summary>Resizes the dimensions of this shape.</summary>
		/// <remarks>
		/// Resizes the dimensions of this shape.
		/// Must be called before
		/// <see cref="draw(android.graphics.Canvas, android.graphics.Paint)">draw(android.graphics.Canvas, android.graphics.Paint)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="width">the width of the shape (in pixels)</param>
		/// <param name="height">the height of the shape (in pixels)</param>
		public void resize(float width, float height)
		{
			if (width < 0)
			{
				width = 0;
			}
			if (height < 0)
			{
				height = 0;
			}
			if (mWidth != width || mHeight != height)
			{
				mWidth = width;
				mHeight = height;
				onResize(width, height);
			}
		}

		/// <summary>Checks whether the Shape is opaque.</summary>
		/// <remarks>
		/// Checks whether the Shape is opaque.
		/// Default impl returns true. Override if your subclass can be opaque.
		/// </remarks>
		/// <returns>true if any part of the drawable is <em>not</em> opaque.</returns>
		public virtual bool hasAlpha()
		{
			return true;
		}

		/// <summary>
		/// Callback method called when
		/// <see cref="resize(float, float)">resize(float, float)</see>
		/// is executed.
		/// </summary>
		/// <param name="width">the new width of the Shape</param>
		/// <param name="height">the new height of the Shape</param>
		protected internal virtual void onResize(float width, float height)
		{
		}

		/// <exception cref="java.lang.CloneNotSupportedException"></exception>
		public virtual android.graphics.drawable.shapes.Shape Clone()
		{
			return (android.graphics.drawable.shapes.Shape)base.MemberwiseClone();
		}

		object System.ICloneable.Clone()
		{
			return Clone();
		}
	}
}
