using Sharpen;

namespace android.widget
{
	/// <summary>Displays an arbitrary image, such as an icon.</summary>
	/// <remarks>
	/// Displays an arbitrary image, such as an icon.  The ImageView class
	/// can load images from various sources (such as resources or content
	/// providers), takes care of computing its measurement from the image so that
	/// it can be used in any layout manager, and provides various display options
	/// such as scaling and tinting.
	/// </remarks>
	/// <attr>ref android.R.styleable#ImageView_adjustViewBounds</attr>
	/// <attr>ref android.R.styleable#ImageView_src</attr>
	/// <attr>ref android.R.styleable#ImageView_maxWidth</attr>
	/// <attr>ref android.R.styleable#ImageView_maxHeight</attr>
	/// <attr>ref android.R.styleable#ImageView_tint</attr>
	/// <attr>ref android.R.styleable#ImageView_scaleType</attr>
	/// <attr>ref android.R.styleable#ImageView_cropToPadding</attr>
	[Sharpen.Sharpened]
	public class ImageView : android.view.View
	{
		private System.Uri mUri;

		private int mResource = 0;

		private android.graphics.Matrix mMatrix;

		private android.widget.ImageView.ScaleType mScaleType;

		private bool mHaveFrame = false;

		private bool mAdjustViewBounds = false;

		private int mMaxWidth = int.MaxValue;

		private int mMaxHeight = int.MaxValue;

		private android.graphics.ColorFilter mColorFilter;

		private int mAlpha = 255;

		private int mViewAlphaScale = 256;

		private bool mColorMod = false;

		private android.graphics.drawable.Drawable mDrawable = null;

		private int[] mState = null;

		private bool mMergeState = false;

		private int mLevel = 0;

		private int mDrawableWidth;

		private int mDrawableHeight;

		private android.graphics.Matrix mDrawMatrix = null;

		private android.graphics.RectF mTempSrc = new android.graphics.RectF();

		private android.graphics.RectF mTempDst = new android.graphics.RectF();

		private bool mCropToPadding;

		private int mBaseline = -1;

		private bool mBaselineAlignBottom = false;

		private static readonly android.widget.ImageView.ScaleType[] sScaleTypeArray = new 
			android.widget.ImageView.ScaleType[] { android.widget.ImageView.ScaleType.MATRIX
			, android.widget.ImageView.ScaleType.FIT_XY, android.widget.ImageView.ScaleType.
			FIT_START, android.widget.ImageView.ScaleType.FIT_CENTER, android.widget.ImageView.ScaleType
			.FIT_END, android.widget.ImageView.ScaleType.CENTER, android.widget.ImageView.ScaleType
			.CENTER_CROP, android.widget.ImageView.ScaleType.CENTER_INSIDE };

		public ImageView(android.content.Context context) : base(context)
		{
			// settable by the client
			// these are applied to the drawable
			// Avoid allocations...
			initImageView();
		}

		public ImageView(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
		}

		public ImageView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			initImageView();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ImageView, defStyle, 0);
			android.graphics.drawable.Drawable d = a.getDrawable(android.@internal.R.styleable
				.ImageView_src);
			if (d != null)
			{
				setImageDrawable(d);
			}
			mBaselineAlignBottom = a.getBoolean(android.@internal.R.styleable.ImageView_baselineAlignBottom
				, false);
			mBaseline = a.getDimensionPixelSize(android.@internal.R.styleable.ImageView_baseline
				, -1);
			setAdjustViewBounds(a.getBoolean(android.@internal.R.styleable.ImageView_adjustViewBounds
				, false));
			setMaxWidth(a.getDimensionPixelSize(android.@internal.R.styleable.ImageView_maxWidth
				, int.MaxValue));
			setMaxHeight(a.getDimensionPixelSize(android.@internal.R.styleable.ImageView_maxHeight
				, int.MaxValue));
			int index = a.getInt(android.@internal.R.styleable.ImageView_scaleType, -1);
			if (index >= 0)
			{
				setScaleType(sScaleTypeArray[index]);
			}
			int tint = a.getInt(android.@internal.R.styleable.ImageView_tint, 0);
			if (tint != 0)
			{
				setColorFilter(tint);
			}
			int alpha = a.getInt(android.@internal.R.styleable.ImageView_drawableAlpha, 255);
			if (alpha != 255)
			{
				setAlpha(alpha);
			}
			mCropToPadding = a.getBoolean(android.@internal.R.styleable.ImageView_cropToPadding
				, false);
			a.recycle();
		}

		//need inflate syntax/reader for matrix
		private void initImageView()
		{
			mMatrix = new android.graphics.Matrix();
			mScaleType = android.widget.ImageView.ScaleType.FIT_CENTER;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 dr)
		{
			return mDrawable == dr || base.verifyDrawable(dr);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			if (mDrawable != null)
			{
				mDrawable.jumpToCurrentState();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void invalidateDrawable(android.graphics.drawable.Drawable dr)
		{
			if (dr == mDrawable)
			{
				invalidate();
			}
			else
			{
				base.invalidateDrawable(dr);
			}
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getResolvedLayoutDirection(android.graphics.drawable.Drawable
			 dr)
		{
			return (dr == mDrawable) ? getResolvedLayoutDirection() : base.getResolvedLayoutDirection
				(dr);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool onSetAlpha(int alpha)
		{
			if (getBackground() == null)
			{
				int scale = alpha + (alpha >> 7);
				if (mViewAlphaScale != scale)
				{
					mViewAlphaScale = scale;
					mColorMod = true;
					applyColorMod();
				}
				return true;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onPopulateAccessibilityEvent(@event);
			java.lang.CharSequence contentDescription = getContentDescription();
			if (!android.text.TextUtils.isEmpty(contentDescription))
			{
				@event.getText().add(contentDescription);
			}
		}

		/// <summary>
		/// Set this to true if you want the ImageView to adjust its bounds
		/// to preserve the aspect ratio of its drawable.
		/// </summary>
		/// <remarks>
		/// Set this to true if you want the ImageView to adjust its bounds
		/// to preserve the aspect ratio of its drawable.
		/// </remarks>
		/// <param name="adjustViewBounds">
		/// Whether to adjust the bounds of this view
		/// to presrve the original aspect ratio of the drawable
		/// </param>
		/// <attr>ref android.R.styleable#ImageView_adjustViewBounds</attr>
		[android.view.RemotableViewMethod]
		public virtual void setAdjustViewBounds(bool adjustViewBounds)
		{
			mAdjustViewBounds = adjustViewBounds;
			if (adjustViewBounds)
			{
				setScaleType(android.widget.ImageView.ScaleType.FIT_CENTER);
			}
		}

		/// <summary>An optional argument to supply a maximum width for this view.</summary>
		/// <remarks>
		/// An optional argument to supply a maximum width for this view. Only valid if
		/// <see cref="setAdjustViewBounds(bool)">setAdjustViewBounds(bool)</see>
		/// has been set to true. To set an image to be a maximum
		/// of 100 x 100 while preserving the original aspect ratio, do the following: 1) set
		/// adjustViewBounds to true 2) set maxWidth and maxHeight to 100 3) set the height and width
		/// layout params to WRAP_CONTENT.
		/// <p>
		/// Note that this view could be still smaller than 100 x 100 using this approach if the original
		/// image is small. To set an image to a fixed size, specify that size in the layout params and
		/// then use
		/// <see cref="setScaleType(ScaleType)">setScaleType(ScaleType)</see>
		/// to determine how to fit
		/// the image within the bounds.
		/// </p>
		/// </remarks>
		/// <param name="maxWidth">maximum width for this view</param>
		/// <attr>ref android.R.styleable#ImageView_maxWidth</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMaxWidth(int maxWidth)
		{
			mMaxWidth = maxWidth;
		}

		/// <summary>An optional argument to supply a maximum height for this view.</summary>
		/// <remarks>
		/// An optional argument to supply a maximum height for this view. Only valid if
		/// <see cref="setAdjustViewBounds(bool)">setAdjustViewBounds(bool)</see>
		/// has been set to true. To set an image to be a
		/// maximum of 100 x 100 while preserving the original aspect ratio, do the following: 1) set
		/// adjustViewBounds to true 2) set maxWidth and maxHeight to 100 3) set the height and width
		/// layout params to WRAP_CONTENT.
		/// <p>
		/// Note that this view could be still smaller than 100 x 100 using this approach if the original
		/// image is small. To set an image to a fixed size, specify that size in the layout params and
		/// then use
		/// <see cref="setScaleType(ScaleType)">setScaleType(ScaleType)</see>
		/// to determine how to fit
		/// the image within the bounds.
		/// </p>
		/// </remarks>
		/// <param name="maxHeight">maximum height for this view</param>
		/// <attr>ref android.R.styleable#ImageView_maxHeight</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMaxHeight(int maxHeight)
		{
			mMaxHeight = maxHeight;
		}

		/// <summary>
		/// Return the view's drawable, or null if no drawable has been
		/// assigned.
		/// </summary>
		/// <remarks>
		/// Return the view's drawable, or null if no drawable has been
		/// assigned.
		/// </remarks>
		public virtual android.graphics.drawable.Drawable getDrawable()
		{
			return mDrawable;
		}

		/// <summary>Sets a drawable as the content of this ImageView.</summary>
		/// <remarks>
		/// Sets a drawable as the content of this ImageView.
		/// <p class="note">This does Bitmap reading and decoding on the UI
		/// thread, which can cause a latency hiccup.  If that's a concern,
		/// consider using
		/// <see cref="setImageDrawable(android.graphics.drawable.Drawable)">setImageDrawable(android.graphics.drawable.Drawable)
		/// 	</see>
		/// or
		/// <see cref="setImageBitmap(android.graphics.Bitmap)">setImageBitmap(android.graphics.Bitmap)
		/// 	</see>
		/// and
		/// <see cref="android.graphics.BitmapFactory">android.graphics.BitmapFactory</see>
		/// instead.</p>
		/// </remarks>
		/// <param name="resId">the resource identifier of the the drawable</param>
		/// <attr>ref android.R.styleable#ImageView_src</attr>
		[android.view.RemotableViewMethod]
		public virtual void setImageResource(int resId)
		{
			if (mUri != null || mResource != resId)
			{
				updateDrawable(null);
				mResource = resId;
				mUri = null;
				resolveUri();
				requestLayout();
				invalidate();
			}
		}

		/// <summary>Sets the content of this ImageView to the specified Uri.</summary>
		/// <remarks>
		/// Sets the content of this ImageView to the specified Uri.
		/// <p class="note">This does Bitmap reading and decoding on the UI
		/// thread, which can cause a latency hiccup.  If that's a concern,
		/// consider using
		/// <see cref="setImageDrawable(android.graphics.drawable.Drawable)">setImageDrawable(android.graphics.drawable.Drawable)
		/// 	</see>
		/// or
		/// <see cref="setImageBitmap(android.graphics.Bitmap)">setImageBitmap(android.graphics.Bitmap)
		/// 	</see>
		/// and
		/// <see cref="android.graphics.BitmapFactory">android.graphics.BitmapFactory</see>
		/// instead.</p>
		/// </remarks>
		/// <param name="uri">The Uri of an image</param>
		[android.view.RemotableViewMethod]
		public virtual void setImageURI(System.Uri uri)
		{
			if (mResource != 0 || (mUri != uri && (uri == null || mUri == null || !uri.Equals
				(mUri))))
			{
				updateDrawable(null);
				mResource = 0;
				mUri = uri;
				resolveUri();
				requestLayout();
				invalidate();
			}
		}

		/// <summary>Sets a drawable as the content of this ImageView.</summary>
		/// <remarks>Sets a drawable as the content of this ImageView.</remarks>
		/// <param name="drawable">The drawable to set</param>
		public virtual void setImageDrawable(android.graphics.drawable.Drawable drawable)
		{
			if (mDrawable != drawable)
			{
				mResource = 0;
				mUri = null;
				int oldWidth = mDrawableWidth;
				int oldHeight = mDrawableHeight;
				updateDrawable(drawable);
				if (oldWidth != mDrawableWidth || oldHeight != mDrawableHeight)
				{
					requestLayout();
				}
				invalidate();
			}
		}

		/// <summary>Sets a Bitmap as the content of this ImageView.</summary>
		/// <remarks>Sets a Bitmap as the content of this ImageView.</remarks>
		/// <param name="bm">The bitmap to set</param>
		[android.view.RemotableViewMethod]
		public virtual void setImageBitmap(android.graphics.Bitmap bm)
		{
			// if this is used frequently, may handle bitmaps explicitly
			// to reduce the intermediate drawable object
			setImageDrawable(new android.graphics.drawable.BitmapDrawable(mContext.getResources
				(), bm));
		}

		public virtual void setImageState(int[] state, bool merge)
		{
			mState = state;
			mMergeState = merge;
			if (mDrawable != null)
			{
				refreshDrawableState();
				resizeFromDrawable();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setSelected(bool selected)
		{
			base.setSelected(selected);
			resizeFromDrawable();
		}

		/// <summary>
		/// Sets the image level, when it is constructed from a
		/// <see cref="android.graphics.drawable.LevelListDrawable">android.graphics.drawable.LevelListDrawable
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="level">The new level for the image.</param>
		[android.view.RemotableViewMethod]
		public virtual void setImageLevel(int level)
		{
			mLevel = level;
			if (mDrawable != null)
			{
				mDrawable.setLevel(level);
				resizeFromDrawable();
			}
		}

		/// <summary>Options for scaling the bounds of an image to the bounds of this view.</summary>
		/// <remarks>Options for scaling the bounds of an image to the bounds of this view.</remarks>
		public enum ScaleType : int
		{
			/// <summary>Scale using the image matrix when drawing.</summary>
			/// <remarks>
			/// Scale using the image matrix when drawing. The image matrix can be set using
			/// <see cref="setImageMatrix(android.graphics.Matrix)">setImageMatrix(android.graphics.Matrix)
			/// 	</see>
			/// . From XML, use this syntax:
			/// <code>android:scaleType="matrix"</code>.
			/// </remarks>
			MATRIX = 0,
			/// <summary>
			/// Scale the image using
			/// <see cref="android.graphics.Matrix.ScaleToFit.FILL">android.graphics.Matrix.ScaleToFit.FILL
			/// 	</see>
			/// .
			/// From XML, use this syntax: <code>android:scaleType="fitXY"</code>.
			/// </summary>
			FIT_XY = 1,
			/// <summary>
			/// Scale the image using
			/// <see cref="android.graphics.Matrix.ScaleToFit.START">android.graphics.Matrix.ScaleToFit.START
			/// 	</see>
			/// .
			/// From XML, use this syntax: <code>android:scaleType="fitStart"</code>.
			/// </summary>
			FIT_START = 2,
			/// <summary>
			/// Scale the image using
			/// <see cref="android.graphics.Matrix.ScaleToFit.CENTER">android.graphics.Matrix.ScaleToFit.CENTER
			/// 	</see>
			/// .
			/// From XML, use this syntax:
			/// <code>android:scaleType="fitCenter"</code>.
			/// </summary>
			FIT_CENTER = 3,
			/// <summary>
			/// Scale the image using
			/// <see cref="android.graphics.Matrix.ScaleToFit.END">android.graphics.Matrix.ScaleToFit.END
			/// 	</see>
			/// .
			/// From XML, use this syntax: <code>android:scaleType="fitEnd"</code>.
			/// </summary>
			FIT_END = 4,
			/// <summary>Center the image in the view, but perform no scaling.</summary>
			/// <remarks>
			/// Center the image in the view, but perform no scaling.
			/// From XML, use this syntax: <code>android:scaleType="center"</code>.
			/// </remarks>
			CENTER = 5,
			/// <summary>
			/// Scale the image uniformly (maintain the image's aspect ratio) so
			/// that both dimensions (width and height) of the image will be equal
			/// to or larger than the corresponding dimension of the view
			/// (minus padding).
			/// </summary>
			/// <remarks>
			/// Scale the image uniformly (maintain the image's aspect ratio) so
			/// that both dimensions (width and height) of the image will be equal
			/// to or larger than the corresponding dimension of the view
			/// (minus padding). The image is then centered in the view.
			/// From XML, use this syntax: <code>android:scaleType="centerCrop"</code>.
			/// </remarks>
			CENTER_CROP = 6,
			/// <summary>
			/// Scale the image uniformly (maintain the image's aspect ratio) so
			/// that both dimensions (width and height) of the image will be equal
			/// to or less than the corresponding dimension of the view
			/// (minus padding).
			/// </summary>
			/// <remarks>
			/// Scale the image uniformly (maintain the image's aspect ratio) so
			/// that both dimensions (width and height) of the image will be equal
			/// to or less than the corresponding dimension of the view
			/// (minus padding). The image is then centered in the view.
			/// From XML, use this syntax: <code>android:scaleType="centerInside"</code>.
			/// </remarks>
			CENTER_INSIDE = 7
		}

		/// <summary>
		/// Controls how the image should be resized or moved to match the size
		/// of this ImageView.
		/// </summary>
		/// <remarks>
		/// Controls how the image should be resized or moved to match the size
		/// of this ImageView.
		/// </remarks>
		/// <param name="scaleType">The desired scaling mode.</param>
		/// <attr>ref android.R.styleable#ImageView_scaleType</attr>
		public virtual void setScaleType(android.widget.ImageView.ScaleType scaleType)
		{
			if (scaleType == null)
			{
				throw new System.ArgumentNullException();
			}
			if (mScaleType != scaleType)
			{
				mScaleType = scaleType;
				setWillNotCacheDrawing(mScaleType == android.widget.ImageView.ScaleType.CENTER);
				requestLayout();
				invalidate();
			}
		}

		/// <summary>Return the current scale type in use by this ImageView.</summary>
		/// <remarks>Return the current scale type in use by this ImageView.</remarks>
		/// <seealso cref="ScaleType">ScaleType</seealso>
		/// <attr>ref android.R.styleable#ImageView_scaleType</attr>
		public virtual android.widget.ImageView.ScaleType getScaleType()
		{
			return mScaleType;
		}

		/// <summary>Return the view's optional matrix.</summary>
		/// <remarks>
		/// Return the view's optional matrix. This is applied to the
		/// view's drawable when it is drawn. If there is not matrix,
		/// this method will return null.
		/// Do not change this matrix in place. If you want a different matrix
		/// applied to the drawable, be sure to call setImageMatrix().
		/// </remarks>
		public virtual android.graphics.Matrix getImageMatrix()
		{
			return mMatrix;
		}

		public virtual void setImageMatrix(android.graphics.Matrix matrix)
		{
			// collaps null and identity to just null
			if (matrix != null && matrix.isIdentity())
			{
				matrix = null;
			}
			// don't invalidate unless we're actually changing our matrix
			if (matrix == null && !mMatrix.isIdentity() || matrix != null && !mMatrix.Equals(
				matrix))
			{
				mMatrix.set(matrix);
				configureBounds();
				invalidate();
			}
		}

		private void resolveUri()
		{
			if (mDrawable != null)
			{
				return;
			}
			android.content.res.Resources rsrc = getResources();
			if (rsrc == null)
			{
				return;
			}
			android.graphics.drawable.Drawable d = null;
			if (mResource != 0)
			{
				try
				{
					d = rsrc.getDrawable(mResource);
				}
				catch (System.Exception e)
				{
					android.util.Log.w("ImageView", "Unable to find resource: " + mResource, e);
					// Don't try again.
					mUri = null;
				}
			}
			else
			{
				if (mUri != null)
				{
					string scheme = mUri.Scheme;
					if (android.content.ContentResolver.SCHEME_ANDROID_RESOURCE.Equals(scheme))
					{
						try
						{
							// Load drawable through Resources, to get the source density information
							android.content.ContentResolver.OpenResourceIdResult r = mContext.getContentResolver
								().getResourceId(mUri);
							d = r.r.getDrawable(r.id);
						}
						catch (System.Exception e)
						{
							android.util.Log.w("ImageView", "Unable to open content: " + mUri, e);
						}
					}
					else
					{
						if (android.content.ContentResolver.SCHEME_CONTENT.Equals(scheme) || android.content.ContentResolver
							.SCHEME_FILE.Equals(scheme))
						{
							try
							{
								d = android.graphics.drawable.Drawable.createFromStream(mContext.getContentResolver
									().openInputStream(mUri), null);
							}
							catch (System.Exception e)
							{
								android.util.Log.w("ImageView", "Unable to open content: " + mUri, e);
							}
						}
						else
						{
							d = android.graphics.drawable.Drawable.createFromPath(mUri.ToString());
						}
					}
					if (d == null)
					{
						java.io.Console.Out.println("resolveUri failed on bad bitmap uri: " + mUri);
						// Don't try again.
						mUri = null;
					}
				}
				else
				{
					return;
				}
			}
			updateDrawable(d);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int[] onCreateDrawableState(int extraSpace)
		{
			if (mState == null)
			{
				return base.onCreateDrawableState(extraSpace);
			}
			else
			{
				if (!mMergeState)
				{
					return mState;
				}
				else
				{
					return mergeDrawableStates(base.onCreateDrawableState(extraSpace + mState.Length)
						, mState);
				}
			}
		}

		private void updateDrawable(android.graphics.drawable.Drawable d)
		{
			if (mDrawable != null)
			{
				mDrawable.setCallback(null);
				unscheduleDrawable(mDrawable);
			}
			mDrawable = d;
			if (d != null)
			{
				d.setCallback(this);
				if (d.isStateful())
				{
					d.setState(getDrawableState());
				}
				d.setLevel(mLevel);
				mDrawableWidth = d.getIntrinsicWidth();
				mDrawableHeight = d.getIntrinsicHeight();
				applyColorMod();
				configureBounds();
			}
			else
			{
				mDrawableWidth = mDrawableHeight = -1;
			}
		}

		private void resizeFromDrawable()
		{
			android.graphics.drawable.Drawable d = mDrawable;
			if (d != null)
			{
				int w = d.getIntrinsicWidth();
				if (w < 0)
				{
					w = mDrawableWidth;
				}
				int h = d.getIntrinsicHeight();
				if (h < 0)
				{
					h = mDrawableHeight;
				}
				if (w != mDrawableWidth || h != mDrawableHeight)
				{
					mDrawableWidth = w;
					mDrawableHeight = h;
					requestLayout();
				}
			}
		}

		private static readonly android.graphics.Matrix.ScaleToFit[] sS2FArray = new android.graphics.Matrix
			.ScaleToFit[] { android.graphics.Matrix.ScaleToFit.FILL, android.graphics.Matrix.ScaleToFit
			.START, android.graphics.Matrix.ScaleToFit.CENTER, android.graphics.Matrix.ScaleToFit
			.END };

		private static android.graphics.Matrix.ScaleToFit scaleTypeToScaleToFit(android.widget.ImageView
			.ScaleType st)
		{
			// ScaleToFit enum to their corresponding Matrix.ScaleToFit values
			return sS2FArray[(int)st - 1];
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			resolveUri();
			int w;
			int h;
			// Desired aspect ratio of the view's contents (not including padding)
			float desiredAspect = 0.0f;
			// We are allowed to change the view's width
			bool resizeWidth = false;
			// We are allowed to change the view's height
			bool resizeHeight = false;
			int widthSpecMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightSpecMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			if (mDrawable == null)
			{
				// If no drawable, its intrinsic size is 0.
				mDrawableWidth = -1;
				mDrawableHeight = -1;
				w = h = 0;
			}
			else
			{
				w = mDrawableWidth;
				h = mDrawableHeight;
				if (w <= 0)
				{
					w = 1;
				}
				if (h <= 0)
				{
					h = 1;
				}
				// We are supposed to adjust view bounds to match the aspect
				// ratio of our drawable. See if that is possible.
				if (mAdjustViewBounds)
				{
					resizeWidth = widthSpecMode != android.view.View.MeasureSpec.EXACTLY;
					resizeHeight = heightSpecMode != android.view.View.MeasureSpec.EXACTLY;
					desiredAspect = (float)w / (float)h;
				}
			}
			int pleft = mPaddingLeft;
			int pright = mPaddingRight;
			int ptop = mPaddingTop;
			int pbottom = mPaddingBottom;
			int widthSize;
			int heightSize;
			if (resizeWidth || resizeHeight)
			{
				// Get the max possible width given our constraints
				widthSize = resolveAdjustedSize(w + pleft + pright, mMaxWidth, widthMeasureSpec);
				// Get the max possible height given our constraints
				heightSize = resolveAdjustedSize(h + ptop + pbottom, mMaxHeight, heightMeasureSpec
					);
				if (desiredAspect != 0.0f)
				{
					// See what our actual aspect ratio is
					float actualAspect = (float)(widthSize - pleft - pright) / (heightSize - ptop - pbottom
						);
					if (System.Math.Abs(actualAspect - desiredAspect) > 0.0000001)
					{
						bool done = false;
						// Try adjusting width to be proportional to height
						if (resizeWidth)
						{
							int newWidth = (int)(desiredAspect * (heightSize - ptop - pbottom)) + pleft + pright;
							if (newWidth <= widthSize)
							{
								widthSize = newWidth;
								done = true;
							}
						}
						// Try adjusting height to be proportional to width
						if (!done && resizeHeight)
						{
							int newHeight = (int)((widthSize - pleft - pright) / desiredAspect) + ptop + pbottom;
							if (newHeight <= heightSize)
							{
								heightSize = newHeight;
							}
						}
					}
				}
			}
			else
			{
				w += pleft + pright;
				h += ptop + pbottom;
				w = System.Math.Max(w, getSuggestedMinimumWidth());
				h = System.Math.Max(h, getSuggestedMinimumHeight());
				widthSize = resolveSizeAndState(w, widthMeasureSpec, 0);
				heightSize = resolveSizeAndState(h, heightMeasureSpec, 0);
			}
			setMeasuredDimension(widthSize, heightSize);
		}

		private int resolveAdjustedSize(int desiredSize, int maxSize, int measureSpec)
		{
			int result = desiredSize;
			int specMode = android.view.View.MeasureSpec.getMode(measureSpec);
			int specSize = android.view.View.MeasureSpec.getSize(measureSpec);
			switch (specMode)
			{
				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					result = System.Math.Min(desiredSize, maxSize);
					break;
				}

				case android.view.View.MeasureSpec.AT_MOST:
				{
					// Parent says we can be as big as we want, up to specSize. 
					// Don't be larger than specSize, and don't be larger than 
					// the max size imposed on ourselves.
					result = System.Math.Min(System.Math.Min(desiredSize, specSize), maxSize);
					break;
				}

				case android.view.View.MeasureSpec.EXACTLY:
				{
					// No choice. Do what we are told.
					result = specSize;
					break;
				}
			}
			return result;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool setFrame(int l, int t, int r, int b)
		{
			bool changed = base.setFrame(l, t, r, b);
			mHaveFrame = true;
			configureBounds();
			return changed;
		}

		private void configureBounds()
		{
			if (mDrawable == null || !mHaveFrame)
			{
				return;
			}
			int dwidth = mDrawableWidth;
			int dheight = mDrawableHeight;
			int vwidth = getWidth() - mPaddingLeft - mPaddingRight;
			int vheight = getHeight() - mPaddingTop - mPaddingBottom;
			bool fits = (dwidth < 0 || vwidth == dwidth) && (dheight < 0 || vheight == dheight
				);
			if (dwidth <= 0 || dheight <= 0 || android.widget.ImageView.ScaleType.FIT_XY == mScaleType)
			{
				mDrawable.setBounds(0, 0, vwidth, vheight);
				mDrawMatrix = null;
			}
			else
			{
				// We need to do the scaling ourself, so have the drawable
				// use its native size.
				mDrawable.setBounds(0, 0, dwidth, dheight);
				if (android.widget.ImageView.ScaleType.MATRIX == mScaleType)
				{
					// Use the specified matrix as-is.
					if (mMatrix.isIdentity())
					{
						mDrawMatrix = null;
					}
					else
					{
						mDrawMatrix = mMatrix;
					}
				}
				else
				{
					if (fits)
					{
						// The bitmap fits exactly, no transform needed.
						mDrawMatrix = null;
					}
					else
					{
						if (android.widget.ImageView.ScaleType.CENTER == mScaleType)
						{
							// Center bitmap in view, no scaling.
							mDrawMatrix = mMatrix;
							mDrawMatrix.setTranslate((int)((vwidth - dwidth) * 0.5f + 0.5f), (int)((vheight -
								 dheight) * 0.5f + 0.5f));
						}
						else
						{
							if (android.widget.ImageView.ScaleType.CENTER_CROP == mScaleType)
							{
								mDrawMatrix = mMatrix;
								float scale;
								float dx = 0;
								float dy = 0;
								if (dwidth * vheight > vwidth * dheight)
								{
									scale = (float)vheight / (float)dheight;
									dx = (vwidth - dwidth * scale) * 0.5f;
								}
								else
								{
									scale = (float)vwidth / (float)dwidth;
									dy = (vheight - dheight * scale) * 0.5f;
								}
								mDrawMatrix.setScale(scale, scale);
								mDrawMatrix.postTranslate((int)(dx + 0.5f), (int)(dy + 0.5f));
							}
							else
							{
								if (android.widget.ImageView.ScaleType.CENTER_INSIDE == mScaleType)
								{
									mDrawMatrix = mMatrix;
									float scale;
									float dx;
									float dy;
									if (dwidth <= vwidth && dheight <= vheight)
									{
										scale = 1.0f;
									}
									else
									{
										scale = System.Math.Min((float)vwidth / (float)dwidth, (float)vheight / (float)dheight
											);
									}
									dx = (int)((vwidth - dwidth * scale) * 0.5f + 0.5f);
									dy = (int)((vheight - dheight * scale) * 0.5f + 0.5f);
									mDrawMatrix.setScale(scale, scale);
									mDrawMatrix.postTranslate(dx, dy);
								}
								else
								{
									// Generate the required transform.
									mTempSrc.set(0, 0, dwidth, dheight);
									mTempDst.set(0, 0, vwidth, vheight);
									mDrawMatrix = mMatrix;
									mDrawMatrix.setRectToRect(mTempSrc, mTempDst, scaleTypeToScaleToFit(mScaleType));
								}
							}
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			android.graphics.drawable.Drawable d = mDrawable;
			if (d != null && d.isStateful())
			{
				d.setState(getDrawableState());
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			base.onDraw(canvas);
			if (mDrawable == null)
			{
				return;
			}
			// couldn't resolve the URI
			if (mDrawableWidth == 0 || mDrawableHeight == 0)
			{
				return;
			}
			// nothing to draw (empty bounds)
			if (mDrawMatrix == null && mPaddingTop == 0 && mPaddingLeft == 0)
			{
				mDrawable.draw(canvas);
			}
			else
			{
				int saveCount = canvas.getSaveCount();
				canvas.save();
				if (mCropToPadding)
				{
					int scrollX = mScrollX;
					int scrollY = mScrollY;
					canvas.clipRect(scrollX + mPaddingLeft, scrollY + mPaddingTop, scrollX + mRight -
						 mLeft - mPaddingRight, scrollY + mBottom - mTop - mPaddingBottom);
				}
				canvas.translate(mPaddingLeft, mPaddingTop);
				if (mDrawMatrix != null)
				{
					canvas.concat(mDrawMatrix);
				}
				mDrawable.draw(canvas);
				canvas.restoreToCount(saveCount);
			}
		}

		/// <summary>
		/// <p>Return the offset of the widget's text baseline from the widget's top
		/// boundary.
		/// </summary>
		/// <remarks>
		/// <p>Return the offset of the widget's text baseline from the widget's top
		/// boundary. </p>
		/// </remarks>
		/// <returns>
		/// the offset of the baseline within the widget's bounds or -1
		/// if baseline alignment is not supported.
		/// </returns>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			if (mBaselineAlignBottom)
			{
				return getMeasuredHeight();
			}
			else
			{
				return mBaseline;
			}
		}

		/// <summary>
		/// <p>Set the offset of the widget's text baseline from the widget's top
		/// boundary.
		/// </summary>
		/// <remarks>
		/// <p>Set the offset of the widget's text baseline from the widget's top
		/// boundary.  This value is overridden by the
		/// <see cref="setBaselineAlignBottom(bool)">setBaselineAlignBottom(bool)</see>
		/// property.</p>
		/// </remarks>
		/// <param name="baseline">The baseline to use, or -1 if none is to be provided.</param>
		/// <seealso cref="setBaseline(int)"></seealso>
		/// <attr>ref android.R.styleable#ImageView_baseline</attr>
		public virtual void setBaseline(int baseline)
		{
			if (mBaseline != baseline)
			{
				mBaseline = baseline;
				requestLayout();
			}
		}

		/// <summary>Set whether to set the baseline of this view to the bottom of the view.</summary>
		/// <remarks>
		/// Set whether to set the baseline of this view to the bottom of the view.
		/// Setting this value overrides any calls to setBaseline.
		/// </remarks>
		/// <param name="aligned">
		/// If true, the image view will be baseline aligned with
		/// based on its bottom edge.
		/// </param>
		/// <attr>ref android.R.styleable#ImageView_baselineAlignBottom</attr>
		public virtual void setBaselineAlignBottom(bool aligned)
		{
			if (mBaselineAlignBottom != aligned)
			{
				mBaselineAlignBottom = aligned;
				requestLayout();
			}
		}

		/// <summary>Return whether this view's baseline will be considered the bottom of the view.
		/// 	</summary>
		/// <remarks>Return whether this view's baseline will be considered the bottom of the view.
		/// 	</remarks>
		/// <seealso cref="setBaselineAlignBottom(bool)">setBaselineAlignBottom(bool)</seealso>
		public virtual bool getBaselineAlignBottom()
		{
			return mBaselineAlignBottom;
		}

		/// <summary>Set a tinting option for the image.</summary>
		/// <remarks>Set a tinting option for the image.</remarks>
		/// <param name="color">Color tint to apply.</param>
		/// <param name="mode">
		/// How to apply the color.  The standard mode is
		/// <see cref="android.graphics.PorterDuff.Mode.SRC_ATOP">android.graphics.PorterDuff.Mode.SRC_ATOP
		/// 	</see>
		/// </param>
		/// <attr>ref android.R.styleable#ImageView_tint</attr>
		public void setColorFilter(int color, android.graphics.PorterDuff.Mode mode)
		{
			setColorFilter(new android.graphics.PorterDuffColorFilter(color, mode));
		}

		/// <summary>Set a tinting option for the image.</summary>
		/// <remarks>
		/// Set a tinting option for the image. Assumes
		/// <see cref="android.graphics.PorterDuff.Mode.SRC_ATOP">android.graphics.PorterDuff.Mode.SRC_ATOP
		/// 	</see>
		/// blending mode.
		/// </remarks>
		/// <param name="color">Color tint to apply.</param>
		/// <attr>ref android.R.styleable#ImageView_tint</attr>
		[android.view.RemotableViewMethod]
		public void setColorFilter(int color)
		{
			setColorFilter(color, android.graphics.PorterDuff.Mode.SRC_ATOP);
		}

		public void clearColorFilter()
		{
			setColorFilter(null);
		}

		/// <summary>Apply an arbitrary colorfilter to the image.</summary>
		/// <remarks>Apply an arbitrary colorfilter to the image.</remarks>
		/// <param name="cf">the colorfilter to apply (may be null)</param>
		public virtual void setColorFilter(android.graphics.ColorFilter cf)
		{
			if (mColorFilter != cf)
			{
				mColorFilter = cf;
				mColorMod = true;
				applyColorMod();
				invalidate();
			}
		}

		[android.view.RemotableViewMethod]
		public virtual void setAlpha(int alpha)
		{
			alpha &= unchecked((int)(0xFF));
			// keep it legal
			if (mAlpha != alpha)
			{
				mAlpha = alpha;
				mColorMod = true;
				applyColorMod();
				invalidate();
			}
		}

		private void applyColorMod()
		{
			// Only mutate and apply when modifications have occurred. This should
			// not reset the mColorMod flag, since these filters need to be
			// re-applied if the Drawable is changed.
			if (mDrawable != null && mColorMod)
			{
				mDrawable = mDrawable.mutate();
				mDrawable.setColorFilter(mColorFilter);
				mDrawable.setAlpha(mAlpha * mViewAlphaScale >> 8);
			}
		}
	}
}
