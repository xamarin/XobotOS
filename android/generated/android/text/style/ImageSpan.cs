using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class ImageSpan : android.text.style.DynamicDrawableSpan
	{
		private android.graphics.drawable.Drawable mDrawable;

		private System.Uri mContentUri;

		private int mResourceId;

		private android.content.Context mContext;

		private string mSource;

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use ImageSpan(android.content.Context, android.graphics.Bitmap) instead."
			)]
		public ImageSpan(android.graphics.Bitmap b) : this(null, b, ALIGN_BOTTOM)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use ImageSpan(android.content.Context, android.graphics.Bitmap, int) instead."
			)]
		public ImageSpan(android.graphics.Bitmap b, int verticalAlignment) : this(null, b
			, verticalAlignment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.content.Context context, android.graphics.Bitmap b) : this
			(context, b, ALIGN_BOTTOM)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.content.Context context, android.graphics.Bitmap b, int 
			verticalAlignment) : base(verticalAlignment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.graphics.drawable.Drawable d) : this(d, ALIGN_BOTTOM)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.graphics.drawable.Drawable d, int verticalAlignment) : base
			(verticalAlignment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.graphics.drawable.Drawable d, string source) : this(d, source
			, ALIGN_BOTTOM)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.graphics.drawable.Drawable d, string source, int verticalAlignment
			) : base(verticalAlignment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.content.Context context, System.Uri uri) : this(context, 
			uri, ALIGN_BOTTOM)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.content.Context context, System.Uri uri, int verticalAlignment
			) : base(verticalAlignment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.content.Context context, int resourceId) : this(context, 
			resourceId, ALIGN_BOTTOM)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ImageSpan(android.content.Context context, int resourceId, int verticalAlignment
			) : base(verticalAlignment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.DynamicDrawableSpan")]
		public override android.graphics.drawable.Drawable getDrawable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSource()
		{
			throw new System.NotImplementedException();
		}
	}
}
