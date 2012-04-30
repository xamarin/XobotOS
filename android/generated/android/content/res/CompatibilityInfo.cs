using Sharpen;

namespace android.content.res
{
	/// <summary>
	/// CompatibilityInfo class keeps the information about compatibility mode that the application is
	/// running under.
	/// </summary>
	/// <remarks>
	/// CompatibilityInfo class keeps the information about compatibility mode that the application is
	/// running under.
	/// <hide></hide>
	/// 
	/// </remarks>
	[Sharpen.Sharpened]
	public class CompatibilityInfo : android.os.Parcelable
	{
		private sealed class _CompatibilityInfo_39 : android.content.res.CompatibilityInfo
		{
			public _CompatibilityInfo_39()
			{
			}
		}

		/// <summary>default compatibility info object for compatible applications</summary>
		public static readonly android.content.res.CompatibilityInfo DEFAULT_COMPATIBILITY_INFO
			 = new _CompatibilityInfo_39();

		/// <summary>
		/// This is the number of pixels we would like to have along the
		/// short axis of an app that needs to run on a normal size screen.
		/// </summary>
		/// <remarks>
		/// This is the number of pixels we would like to have along the
		/// short axis of an app that needs to run on a normal size screen.
		/// </remarks>
		public const int DEFAULT_NORMAL_SHORT_DIMENSION = 320;

		/// <summary>
		/// This is the maximum aspect ratio we will allow while keeping
		/// applications in a compatible screen size.
		/// </summary>
		/// <remarks>
		/// This is the maximum aspect ratio we will allow while keeping
		/// applications in a compatible screen size.
		/// </remarks>
		public const float MAXIMUM_ASPECT_RATIO = (854f / 480f);

		/// <summary>A compatibility flags</summary>
		private readonly int mCompatibilityFlags;

		/// <summary>
		/// A flag mask to tell if the application needs scaling (when mApplicationScale != 1.0f)
		/// <seealso>compatibilityFlag</seealso>
		/// </summary>
		internal const int SCALING_REQUIRED = 1;

		/// <summary>Application must always run in compatibility mode?</summary>
		internal const int ALWAYS_NEEDS_COMPAT = 2;

		/// <summary>Application never should run in compatibility mode?</summary>
		internal const int NEVER_NEEDS_COMPAT = 4;

		/// <summary>Set if the application needs to run in screen size compatibility mode.</summary>
		/// <remarks>Set if the application needs to run in screen size compatibility mode.</remarks>
		internal const int NEEDS_SCREEN_COMPAT = 8;

		/// <summary>The effective screen density we have selected for this application.</summary>
		/// <remarks>The effective screen density we have selected for this application.</remarks>
		public readonly int applicationDensity;

		/// <summary>Application's scale.</summary>
		/// <remarks>Application's scale.</remarks>
		public readonly float applicationScale;

		/// <summary>Application's inverted scale.</summary>
		/// <remarks>Application's inverted scale.</remarks>
		public readonly float applicationInvertedScale;

		public CompatibilityInfo(android.content.pm.ApplicationInfo appInfo, int screenLayout
			, int sw, bool forceCompat)
		{
			int compatFlags = 0;
			if (appInfo.requiresSmallestWidthDp != 0 || appInfo.compatibleWidthLimitDp != 0 ||
				 appInfo.largestWidthLimitDp != 0)
			{
				// New style screen requirements spec.
				int required = appInfo.requiresSmallestWidthDp != 0 ? appInfo.requiresSmallestWidthDp
					 : appInfo.compatibleWidthLimitDp;
				if (required == 0)
				{
					required = appInfo.largestWidthLimitDp;
				}
				int compat = appInfo.compatibleWidthLimitDp != 0 ? appInfo.compatibleWidthLimitDp
					 : required;
				if (compat < required)
				{
					compat = required;
				}
				int largest = appInfo.largestWidthLimitDp;
				if (required > DEFAULT_NORMAL_SHORT_DIMENSION)
				{
					// For now -- if they require a size larger than the only
					// size we can do in compatibility mode, then don't ever
					// allow the app to go in to compat mode.  Trying to run
					// it at a smaller size it can handle will make it far more
					// broken than running at a larger size than it wants or
					// thinks it can handle.
					compatFlags |= NEVER_NEEDS_COMPAT;
				}
				else
				{
					if (largest != 0 && sw > largest)
					{
						// If the screen size is larger than the largest size the
						// app thinks it can work with, then always force it in to
						// compatibility mode.
						compatFlags |= NEEDS_SCREEN_COMPAT | ALWAYS_NEEDS_COMPAT;
					}
					else
					{
						if (compat >= sw)
						{
							// The screen size is something the app says it was designed
							// for, so never do compatibility mode.
							compatFlags |= NEVER_NEEDS_COMPAT;
						}
						else
						{
							if (forceCompat)
							{
								// The app may work better with or without compatibility mode.
								// Let the user decide.
								compatFlags |= NEEDS_SCREEN_COMPAT;
							}
						}
					}
				}
				// Modern apps always support densities.
				applicationDensity = android.util.DisplayMetrics.DENSITY_DEVICE;
				applicationScale = 1.0f;
				applicationInvertedScale = 1.0f;
			}
			else
			{
				int EXPANDABLE = 2;
				int LARGE_SCREENS = 8;
				int XLARGE_SCREENS = 32;
				int sizeInfo = 0;
				// We can't rely on the application always setting
				// FLAG_RESIZEABLE_FOR_SCREENS so will compute it based on various input.
				bool anyResizeable = false;
				if ((appInfo.flags & android.content.pm.ApplicationInfo.FLAG_SUPPORTS_LARGE_SCREENS
					) != 0)
				{
					sizeInfo |= LARGE_SCREENS;
					anyResizeable = true;
					if (!forceCompat)
					{
						// If we aren't forcing the app into compatibility mode, then
						// assume if it supports large screens that we should allow it
						// to use the full space of an xlarge screen as well.
						sizeInfo |= XLARGE_SCREENS | EXPANDABLE;
					}
				}
				if ((appInfo.flags & android.content.pm.ApplicationInfo.FLAG_SUPPORTS_XLARGE_SCREENS
					) != 0)
				{
					anyResizeable = true;
					if (!forceCompat)
					{
						sizeInfo |= XLARGE_SCREENS | EXPANDABLE;
					}
				}
				if ((appInfo.flags & android.content.pm.ApplicationInfo.FLAG_RESIZEABLE_FOR_SCREENS
					) != 0)
				{
					anyResizeable = true;
					sizeInfo |= EXPANDABLE;
				}
				if (forceCompat)
				{
					// If we are forcing compatibility mode, then ignore an app that
					// just says it is resizable for screens.  We'll only have it fill
					// the screen if it explicitly says it supports the screen size we
					// are running in.
					sizeInfo &= ~EXPANDABLE;
				}
				compatFlags |= NEEDS_SCREEN_COMPAT;
				switch (screenLayout & android.content.res.Configuration.SCREENLAYOUT_SIZE_MASK)
				{
					case android.content.res.Configuration.SCREENLAYOUT_SIZE_XLARGE:
					{
						if ((sizeInfo & XLARGE_SCREENS) != 0)
						{
							compatFlags &= ~NEEDS_SCREEN_COMPAT;
						}
						if ((appInfo.flags & android.content.pm.ApplicationInfo.FLAG_SUPPORTS_XLARGE_SCREENS
							) != 0)
						{
							compatFlags |= NEVER_NEEDS_COMPAT;
						}
						break;
					}

					case android.content.res.Configuration.SCREENLAYOUT_SIZE_LARGE:
					{
						if ((sizeInfo & LARGE_SCREENS) != 0)
						{
							compatFlags &= ~NEEDS_SCREEN_COMPAT;
						}
						if ((appInfo.flags & android.content.pm.ApplicationInfo.FLAG_SUPPORTS_LARGE_SCREENS
							) != 0)
						{
							compatFlags |= NEVER_NEEDS_COMPAT;
						}
						break;
					}
				}
				if ((screenLayout & android.content.res.Configuration.SCREENLAYOUT_COMPAT_NEEDED)
					 != 0)
				{
					if ((sizeInfo & EXPANDABLE) != 0)
					{
						compatFlags &= ~NEEDS_SCREEN_COMPAT;
					}
					else
					{
						if (!anyResizeable)
						{
							compatFlags |= ALWAYS_NEEDS_COMPAT;
						}
					}
				}
				else
				{
					compatFlags &= ~NEEDS_SCREEN_COMPAT;
					compatFlags |= NEVER_NEEDS_COMPAT;
				}
				if ((appInfo.flags & android.content.pm.ApplicationInfo.FLAG_SUPPORTS_SCREEN_DENSITIES
					) != 0)
				{
					applicationDensity = android.util.DisplayMetrics.DENSITY_DEVICE;
					applicationScale = 1.0f;
					applicationInvertedScale = 1.0f;
				}
				else
				{
					applicationDensity = android.util.DisplayMetrics.DENSITY_DEFAULT;
					applicationScale = android.util.DisplayMetrics.DENSITY_DEVICE / (float)android.util.DisplayMetrics
						.DENSITY_DEFAULT;
					applicationInvertedScale = 1.0f / applicationScale;
					compatFlags |= SCALING_REQUIRED;
				}
			}
			mCompatibilityFlags = compatFlags;
		}

		private CompatibilityInfo(int compFlags, int dens, float scale, float invertedScale
			)
		{
			mCompatibilityFlags = compFlags;
			applicationDensity = dens;
			applicationScale = scale;
			applicationInvertedScale = invertedScale;
		}

		private CompatibilityInfo() : this(NEVER_NEEDS_COMPAT, android.util.DisplayMetrics
			.DENSITY_DEVICE, 1.0f, 1.0f)
		{
		}

		/// <returns>true if the scaling is required</returns>
		public virtual bool isScalingRequired()
		{
			return (mCompatibilityFlags & SCALING_REQUIRED) != 0;
		}

		public virtual bool supportsScreen()
		{
			return (mCompatibilityFlags & NEEDS_SCREEN_COMPAT) == 0;
		}

		public virtual bool neverSupportsScreen()
		{
			return (mCompatibilityFlags & ALWAYS_NEEDS_COMPAT) != 0;
		}

		public virtual bool alwaysSupportsScreen()
		{
			return (mCompatibilityFlags & NEVER_NEEDS_COMPAT) != 0;
		}

		/// <summary>Returns the translator which translates the coordinates in compatibility mode.
		/// 	</summary>
		/// <remarks>Returns the translator which translates the coordinates in compatibility mode.
		/// 	</remarks>
		/// <param name="params">the window's parameter</param>
		public virtual android.content.res.CompatibilityInfo.Translator getTranslator()
		{
			return isScalingRequired() ? new android.content.res.CompatibilityInfo.Translator
				(this) : null;
		}

		/// <summary>A helper object to translate the screen and window coordinates back and forth.
		/// 	</summary>
		/// <remarks>A helper object to translate the screen and window coordinates back and forth.
		/// 	</remarks>
		/// <hide></hide>
		public class Translator
		{
			public readonly float applicationScale;

			public readonly float applicationInvertedScale;

			private android.graphics.Rect mContentInsetsBuffer;

			private android.graphics.Rect mVisibleInsetsBuffer;

			private android.graphics.Region mTouchableAreaBuffer;

			internal Translator(CompatibilityInfo _enclosing, float applicationScale, float applicationInvertedScale
				)
			{
				this._enclosing = _enclosing;
				mContentInsetsBuffer = null;
				mVisibleInsetsBuffer = null;
				mTouchableAreaBuffer = null;
				this.applicationScale = applicationScale;
				this.applicationInvertedScale = applicationInvertedScale;
			}

			internal Translator(CompatibilityInfo _enclosing)
			{
				this._enclosing = _enclosing;
				mContentInsetsBuffer = null;
				mVisibleInsetsBuffer = null;
				mTouchableAreaBuffer = null;
			}

			/// <summary>Translate the screen rect to the application frame.</summary>
			/// <remarks>Translate the screen rect to the application frame.</remarks>
			public virtual void translateRectInScreenToAppWinFrame(android.graphics.Rect rect
				)
			{
				rect.scale(this.applicationInvertedScale);
			}

			/// <summary>Translate the region in window to screen.</summary>
			/// <remarks>Translate the region in window to screen.</remarks>
			public virtual void translateRegionInWindowToScreen(android.graphics.Region transparentRegion
				)
			{
				transparentRegion.scale(this.applicationScale);
			}

			/// <summary>Apply translation to the canvas that is necessary to draw the content.</summary>
			/// <remarks>Apply translation to the canvas that is necessary to draw the content.</remarks>
			public virtual void translateCanvas(android.graphics.Canvas canvas)
			{
				if (this.applicationScale == 1.5f)
				{
					float tinyOffset = 2.0f / (3 * 255);
					canvas.translate(tinyOffset, tinyOffset);
				}
				canvas.scale(this.applicationScale, this.applicationScale);
			}

			/// <summary>Translate the motion event captured on screen to the application's window.
			/// 	</summary>
			/// <remarks>Translate the motion event captured on screen to the application's window.
			/// 	</remarks>
			public virtual void translateEventInScreenToAppWindow(android.view.MotionEvent @event
				)
			{
				@event.scale(this.applicationInvertedScale);
			}

			/// <summary>
			/// Translate the window's layout parameter, from application's view to
			/// Screen's view.
			/// </summary>
			/// <remarks>
			/// Translate the window's layout parameter, from application's view to
			/// Screen's view.
			/// </remarks>
			public virtual void translateWindowLayout(android.view.WindowManagerClass.LayoutParams
				 @params)
			{
				@params.scale(this.applicationScale);
			}

			/// <summary>Translate a Rect in application's window to screen.</summary>
			/// <remarks>Translate a Rect in application's window to screen.</remarks>
			public virtual void translateRectInAppWindowToScreen(android.graphics.Rect rect)
			{
				rect.scale(this.applicationScale);
			}

			/// <summary>Translate a Rect in screen coordinates into the app window's coordinates.
			/// 	</summary>
			/// <remarks>Translate a Rect in screen coordinates into the app window's coordinates.
			/// 	</remarks>
			public virtual void translateRectInScreenToAppWindow(android.graphics.Rect rect)
			{
				rect.scale(this.applicationInvertedScale);
			}

			/// <summary>Translate a Point in screen coordinates into the app window's coordinates.
			/// 	</summary>
			/// <remarks>Translate a Point in screen coordinates into the app window's coordinates.
			/// 	</remarks>
			public virtual void translatePointInScreenToAppWindow(android.graphics.PointF point
				)
			{
				float scale = this.applicationInvertedScale;
				if (scale != 1.0f)
				{
					point.x *= scale;
					point.y *= scale;
				}
			}

			/// <summary>Translate the location of the sub window.</summary>
			/// <remarks>Translate the location of the sub window.</remarks>
			/// <param name="params"></param>
			public virtual void translateLayoutParamsInAppWindowToScreen(android.view.WindowManagerClass
				.LayoutParams @params)
			{
				@params.scale(this.applicationScale);
			}

			/// <summary>Translate the content insets in application window to Screen.</summary>
			/// <remarks>
			/// Translate the content insets in application window to Screen. This uses
			/// the internal buffer for content insets to avoid extra object allocation.
			/// </remarks>
			public virtual android.graphics.Rect getTranslatedContentInsets(android.graphics.Rect
				 contentInsets)
			{
				if (this.mContentInsetsBuffer == null)
				{
					this.mContentInsetsBuffer = new android.graphics.Rect();
				}
				this.mContentInsetsBuffer.set(contentInsets);
				this.translateRectInAppWindowToScreen(this.mContentInsetsBuffer);
				return this.mContentInsetsBuffer;
			}

			/// <summary>Translate the visible insets in application window to Screen.</summary>
			/// <remarks>
			/// Translate the visible insets in application window to Screen. This uses
			/// the internal buffer for visible insets to avoid extra object allocation.
			/// </remarks>
			public virtual android.graphics.Rect getTranslatedVisibleInsets(android.graphics.Rect
				 visibleInsets)
			{
				if (this.mVisibleInsetsBuffer == null)
				{
					this.mVisibleInsetsBuffer = new android.graphics.Rect();
				}
				this.mVisibleInsetsBuffer.set(visibleInsets);
				this.translateRectInAppWindowToScreen(this.mVisibleInsetsBuffer);
				return this.mVisibleInsetsBuffer;
			}

			/// <summary>Translate the touchable area in application window to Screen.</summary>
			/// <remarks>
			/// Translate the touchable area in application window to Screen. This uses
			/// the internal buffer for touchable area to avoid extra object allocation.
			/// </remarks>
			public virtual android.graphics.Region getTranslatedTouchableArea(android.graphics.Region
				 touchableArea)
			{
				if (this.mTouchableAreaBuffer == null)
				{
					this.mTouchableAreaBuffer = new android.graphics.Region();
				}
				this.mTouchableAreaBuffer.set(touchableArea);
				this.mTouchableAreaBuffer.scale(this.applicationScale);
				return this.mTouchableAreaBuffer;
			}

			private readonly CompatibilityInfo _enclosing;
		}

		public virtual void applyToDisplayMetrics(android.util.DisplayMetrics inoutDm)
		{
			if (!supportsScreen())
			{
				// This is a larger screen device and the app is not
				// compatible with large screens, so diddle it.
				android.content.res.CompatibilityInfo.computeCompatibleScaling(inoutDm, inoutDm);
			}
			else
			{
				inoutDm.widthPixels = inoutDm.noncompatWidthPixels;
				inoutDm.heightPixels = inoutDm.noncompatHeightPixels;
			}
			if (isScalingRequired())
			{
				float invertedRatio = applicationInvertedScale;
				inoutDm.density = inoutDm.noncompatDensity * invertedRatio;
				inoutDm.densityDpi = (int)((inoutDm.density * android.util.DisplayMetrics.DENSITY_DEFAULT
					) + .5f);
				inoutDm.scaledDensity = inoutDm.noncompatScaledDensity * invertedRatio;
				inoutDm.xdpi = inoutDm.noncompatXdpi * invertedRatio;
				inoutDm.ydpi = inoutDm.noncompatYdpi * invertedRatio;
				inoutDm.widthPixels = (int)(inoutDm.widthPixels * invertedRatio + 0.5f);
				inoutDm.heightPixels = (int)(inoutDm.heightPixels * invertedRatio + 0.5f);
			}
		}

		public virtual void applyToConfiguration(android.content.res.Configuration inoutConfig
			)
		{
			if (!supportsScreen())
			{
				// This is a larger screen device and the app is not
				// compatible with large screens, so we are forcing it to
				// run as if the screen is normal size.
				inoutConfig.screenLayout = (inoutConfig.screenLayout & ~android.content.res.Configuration
					.SCREENLAYOUT_SIZE_MASK) | android.content.res.Configuration.SCREENLAYOUT_SIZE_NORMAL;
				inoutConfig.screenWidthDp = inoutConfig.compatScreenWidthDp;
				inoutConfig.screenHeightDp = inoutConfig.compatScreenHeightDp;
				inoutConfig.smallestScreenWidthDp = inoutConfig.compatSmallestScreenWidthDp;
			}
		}

		/// <summary>Compute the frame Rect for applications runs under compatibility mode.</summary>
		/// <remarks>Compute the frame Rect for applications runs under compatibility mode.</remarks>
		/// <param name="dm">the display metrics used to compute the frame size.</param>
		/// <param name="orientation">the orientation of the screen.</param>
		/// <param name="outRect">the output parameter which will contain the result.</param>
		/// <returns>Returns the scaling factor for the window.</returns>
		public static float computeCompatibleScaling(android.util.DisplayMetrics dm, android.util.DisplayMetrics
			 outDm)
		{
			int width = dm.noncompatWidthPixels;
			int height = dm.noncompatHeightPixels;
			int shortSize;
			int longSize;
			if (width < height)
			{
				shortSize = width;
				longSize = height;
			}
			else
			{
				shortSize = height;
				longSize = width;
			}
			int newShortSize = (int)(DEFAULT_NORMAL_SHORT_DIMENSION * dm.density + 0.5f);
			float aspect = ((float)longSize) / shortSize;
			if (aspect > MAXIMUM_ASPECT_RATIO)
			{
				aspect = MAXIMUM_ASPECT_RATIO;
			}
			int newLongSize = (int)(newShortSize * aspect + 0.5f);
			int newWidth;
			int newHeight;
			if (width < height)
			{
				newWidth = newShortSize;
				newHeight = newLongSize;
			}
			else
			{
				newWidth = newLongSize;
				newHeight = newShortSize;
			}
			float sw = width / (float)newWidth;
			float sh = height / (float)newHeight;
			float scale = sw < sh ? sw : sh;
			if (scale < 1)
			{
				scale = 1;
			}
			if (outDm != null)
			{
				outDm.widthPixels = newWidth;
				outDm.heightPixels = newHeight;
			}
			return scale;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			try
			{
				android.content.res.CompatibilityInfo oc = (android.content.res.CompatibilityInfo
					)o;
				if (mCompatibilityFlags != oc.mCompatibilityFlags)
				{
					return false;
				}
				if (applicationDensity != oc.applicationDensity)
				{
					return false;
				}
				if (applicationScale != oc.applicationScale)
				{
					return false;
				}
				if (applicationInvertedScale != oc.applicationInvertedScale)
				{
					return false;
				}
				return true;
			}
			catch (System.InvalidCastException)
			{
				return false;
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(128);
			sb.append("{");
			sb.append(applicationDensity);
			sb.append("dpi");
			if (isScalingRequired())
			{
				sb.append(" ");
				sb.append(applicationScale);
				sb.append("x");
			}
			if (!supportsScreen())
			{
				sb.append(" resizing");
			}
			if (neverSupportsScreen())
			{
				sb.append(" never-compat");
			}
			if (alwaysSupportsScreen())
			{
				sb.append(" always-compat");
			}
			sb.append("}");
			return sb.ToString();
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int result = 17;
			result = 31 * result + mCompatibilityFlags;
			result = 31 * result + applicationDensity;
			result = 31 * result + Sharpen.Util.FloatToIntBits(applicationScale);
			result = 31 * result + Sharpen.Util.FloatToIntBits(applicationInvertedScale);
			return result;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			dest.writeInt(mCompatibilityFlags);
			dest.writeInt(applicationDensity);
			dest.writeFloat(applicationScale);
			dest.writeFloat(applicationInvertedScale);
		}

		private sealed class _Creator_576 : android.os.ParcelableClass.Creator<android.content.res.CompatibilityInfo
			>
		{
			public _Creator_576()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.CompatibilityInfo createFromParcel(android.os.Parcel source
				)
			{
				return new android.content.res.CompatibilityInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.CompatibilityInfo[] newArray(int size)
			{
				return new android.content.res.CompatibilityInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.res.CompatibilityInfo
			> CREATOR = new _Creator_576();

		private CompatibilityInfo(android.os.Parcel source)
		{
			mCompatibilityFlags = source.readInt();
			applicationDensity = source.readInt();
			applicationScale = source.readFloat();
			applicationInvertedScale = source.readFloat();
		}
	}
}
