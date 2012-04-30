using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// Drawable subclass that wraps a Picture, allowing the picture to be used
	/// whereever a Drawable is supported.
	/// </summary>
	/// <remarks>
	/// Drawable subclass that wraps a Picture, allowing the picture to be used
	/// whereever a Drawable is supported.
	/// </remarks>
	[Sharpen.Sharpened]
	public class PictureDrawable : android.graphics.drawable.Drawable
	{
		private android.graphics.Picture mPicture;

		/// <summary>Construct a new drawable referencing the specified picture.</summary>
		/// <remarks>
		/// Construct a new drawable referencing the specified picture. The picture
		/// may be null.
		/// </remarks>
		/// <param name="picture">The picture to associate with the drawable. May be null.</param>
		public PictureDrawable(android.graphics.Picture picture)
		{
			mPicture = picture;
		}

		/// <summary>Return the picture associated with the drawable.</summary>
		/// <remarks>Return the picture associated with the drawable. May be null.</remarks>
		/// <returns>the picture associated with the drawable, or null.</returns>
		public virtual android.graphics.Picture getPicture()
		{
			return mPicture;
		}

		/// <summary>Associate a picture with this drawable.</summary>
		/// <remarks>Associate a picture with this drawable. The picture may be null.</remarks>
		/// <param name="picture">The picture to associate with the drawable. May be null.</param>
		public virtual void setPicture(android.graphics.Picture picture)
		{
			mPicture = picture;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			if (mPicture != null)
			{
				android.graphics.Rect bounds = getBounds();
				canvas.save();
				canvas.clipRect(bounds);
				canvas.translate(bounds.left, bounds.top);
				canvas.drawPicture(mPicture);
				canvas.restore();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			return mPicture != null ? mPicture.getWidth() : -1;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			return mPicture != null ? mPicture.getHeight() : -1;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			// not sure, so be safe
			return android.graphics.PixelFormat.TRANSLUCENT;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setFilterBitmap(bool filter)
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setDither(bool dither)
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter colorFilter)
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
		}
	}
}
