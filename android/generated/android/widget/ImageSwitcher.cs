using Sharpen;

namespace android.widget
{
	[Sharpen.Sharpened]
	public class ImageSwitcher : android.widget.ViewSwitcher
	{
		public ImageSwitcher(android.content.Context context) : base(context)
		{
		}

		public ImageSwitcher(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
		}

		public virtual void setImageResource(int resid)
		{
			android.widget.ImageView image = (android.widget.ImageView)this.getNextView();
			image.setImageResource(resid);
			showNext();
		}

		public virtual void setImageURI(System.Uri uri)
		{
			android.widget.ImageView image = (android.widget.ImageView)this.getNextView();
			image.setImageURI(uri);
			showNext();
		}

		public virtual void setImageDrawable(android.graphics.drawable.Drawable drawable)
		{
			android.widget.ImageView image = (android.widget.ImageView)this.getNextView();
			image.setImageDrawable(drawable);
			showNext();
		}
	}
}
