using Sharpen;

namespace android.widget
{
	/// <summary>This is only used by View for displaying its scroll bars.</summary>
	/// <remarks>
	/// This is only used by View for displaying its scroll bars.  It should probably
	/// be moved in to the view package since it is used in that lower-level layer.
	/// For now, we'll hide it so it can be cleaned up later.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public class ScrollBarDrawable : android.graphics.drawable.Drawable
	{
		private android.graphics.drawable.Drawable mVerticalTrack;

		private android.graphics.drawable.Drawable mHorizontalTrack;

		private android.graphics.drawable.Drawable mVerticalThumb;

		private android.graphics.drawable.Drawable mHorizontalThumb;

		private int mRange;

		private int mOffset;

		private int mExtent;

		private bool mVertical;

		private bool mChanged;

		private bool mRangeChanged;

		private readonly android.graphics.Rect mTempBounds = new android.graphics.Rect();

		private bool mAlwaysDrawHorizontalTrack;

		private bool mAlwaysDrawVerticalTrack;

		public ScrollBarDrawable()
		{
		}

		/// <summary>
		/// Indicate whether the horizontal scrollbar track should always be drawn regardless of the
		/// extent.
		/// </summary>
		/// <remarks>
		/// Indicate whether the horizontal scrollbar track should always be drawn regardless of the
		/// extent. Defaults to false.
		/// </remarks>
		/// <param name="alwaysDrawTrack">Set to true if the track should always be drawn</param>
		public virtual void setAlwaysDrawHorizontalTrack(bool alwaysDrawTrack)
		{
			mAlwaysDrawHorizontalTrack = alwaysDrawTrack;
		}

		/// <summary>
		/// Indicate whether the vertical scrollbar track should always be drawn regardless of the
		/// extent.
		/// </summary>
		/// <remarks>
		/// Indicate whether the vertical scrollbar track should always be drawn regardless of the
		/// extent. Defaults to false.
		/// </remarks>
		/// <param name="alwaysDrawTrack">Set to true if the track should always be drawn</param>
		public virtual void setAlwaysDrawVerticalTrack(bool alwaysDrawTrack)
		{
			mAlwaysDrawVerticalTrack = alwaysDrawTrack;
		}

		/// <summary>
		/// Indicates whether the vertical scrollbar track should always be drawn regardless of the
		/// extent.
		/// </summary>
		/// <remarks>
		/// Indicates whether the vertical scrollbar track should always be drawn regardless of the
		/// extent.
		/// </remarks>
		public virtual bool getAlwaysDrawVerticalTrack()
		{
			return mAlwaysDrawVerticalTrack;
		}

		/// <summary>
		/// Indicates whether the horizontal scrollbar track should always be drawn regardless of the
		/// extent.
		/// </summary>
		/// <remarks>
		/// Indicates whether the horizontal scrollbar track should always be drawn regardless of the
		/// extent.
		/// </remarks>
		public virtual bool getAlwaysDrawHorizontalTrack()
		{
			return mAlwaysDrawHorizontalTrack;
		}

		public virtual void setParameters(int range, int offset, int extent, bool vertical
			)
		{
			if (mVertical != vertical)
			{
				mChanged = true;
			}
			if (mRange != range || mOffset != offset || mExtent != extent)
			{
				mRangeChanged = true;
			}
			mRange = range;
			mOffset = offset;
			mExtent = extent;
			mVertical = vertical;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			bool vertical = mVertical;
			int extent = mExtent;
			int range = mRange;
			bool drawTrack_1 = true;
			bool drawThumb_1 = true;
			if (extent <= 0 || range <= extent)
			{
				drawTrack_1 = vertical ? mAlwaysDrawVerticalTrack : mAlwaysDrawHorizontalTrack;
				drawThumb_1 = false;
			}
			android.graphics.Rect r = getBounds();
			if (canvas.quickReject(r.left, r.top, r.right, r.bottom, android.graphics.Canvas.EdgeType
				.AA))
			{
				return;
			}
			if (drawTrack_1)
			{
				drawTrack(canvas, r, vertical);
			}
			if (drawThumb_1)
			{
				int size = vertical ? r.height() : r.width();
				int thickness = vertical ? r.width() : r.height();
				int length = Sharpen.Util.Round((float)size * extent / range);
				int offset = Sharpen.Util.Round((float)(size - length) * mOffset / (range - extent
					));
				// avoid the tiny thumb
				int minLength = thickness * 2;
				if (length < minLength)
				{
					length = minLength;
				}
				// avoid the too-big thumb
				if (offset + length > size)
				{
					offset = size - length;
				}
				drawThumb(canvas, r, offset, length, vertical);
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			base.onBoundsChange(bounds);
			mChanged = true;
		}

		protected internal virtual void drawTrack(android.graphics.Canvas canvas, android.graphics.Rect
			 bounds, bool vertical)
		{
			android.graphics.drawable.Drawable track;
			if (vertical)
			{
				track = mVerticalTrack;
			}
			else
			{
				track = mHorizontalTrack;
			}
			if (track != null)
			{
				if (mChanged)
				{
					track.setBounds(bounds);
				}
				track.draw(canvas);
			}
		}

		protected internal virtual void drawThumb(android.graphics.Canvas canvas, android.graphics.Rect
			 bounds, int offset, int length, bool vertical)
		{
			android.graphics.Rect thumbRect = mTempBounds;
			bool changed = mRangeChanged || mChanged;
			if (changed)
			{
				if (vertical)
				{
					thumbRect.set(bounds.left, bounds.top + offset, bounds.right, bounds.top + offset
						 + length);
				}
				else
				{
					thumbRect.set(bounds.left + offset, bounds.top, bounds.left + offset + length, bounds
						.bottom);
				}
			}
			if (vertical)
			{
				android.graphics.drawable.Drawable thumb = mVerticalThumb;
				if (changed)
				{
					thumb.setBounds(thumbRect);
				}
				thumb.draw(canvas);
			}
			else
			{
				android.graphics.drawable.Drawable thumb = mHorizontalThumb;
				if (changed)
				{
					thumb.setBounds(thumbRect);
				}
				thumb.draw(canvas);
			}
		}

		public virtual void setVerticalThumbDrawable(android.graphics.drawable.Drawable thumb
			)
		{
			if (thumb != null)
			{
				mVerticalThumb = thumb;
			}
		}

		public virtual void setVerticalTrackDrawable(android.graphics.drawable.Drawable track
			)
		{
			mVerticalTrack = track;
		}

		public virtual void setHorizontalThumbDrawable(android.graphics.drawable.Drawable
			 thumb)
		{
			if (thumb != null)
			{
				mHorizontalThumb = thumb;
			}
		}

		public virtual void setHorizontalTrackDrawable(android.graphics.drawable.Drawable
			 track)
		{
			mHorizontalTrack = track;
		}

		public virtual int getSize(bool vertical)
		{
			if (vertical)
			{
				return (mVerticalTrack != null ? mVerticalTrack : mVerticalThumb).getIntrinsicWidth
					();
			}
			else
			{
				return (mHorizontalTrack != null ? mHorizontalTrack : mHorizontalThumb).getIntrinsicHeight
					();
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			if (mVerticalTrack != null)
			{
				mVerticalTrack.setAlpha(alpha);
			}
			mVerticalThumb.setAlpha(alpha);
			if (mHorizontalTrack != null)
			{
				mHorizontalTrack.setAlpha(alpha);
			}
			mHorizontalThumb.setAlpha(alpha);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			if (mVerticalTrack != null)
			{
				mVerticalTrack.setColorFilter(cf);
			}
			mVerticalThumb.setColorFilter(cf);
			if (mHorizontalTrack != null)
			{
				mHorizontalTrack.setColorFilter(cf);
			}
			mHorizontalThumb.setColorFilter(cf);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			return android.graphics.PixelFormat.TRANSLUCENT;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ScrollBarDrawable: range=" + mRange + " offset=" + mOffset + " extent=" +
				 mExtent + (mVertical ? " V" : " H");
		}
	}
}
