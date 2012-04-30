using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// A Drawable is a general abstraction for "something that can be drawn."  Most
	/// often you will deal with Drawable as the type of resource retrieved for
	/// drawing things to the screen; the Drawable class provides a generic API for
	/// dealing with an underlying visual resource that may take a variety of forms.
	/// </summary>
	/// <remarks>
	/// A Drawable is a general abstraction for "something that can be drawn."  Most
	/// often you will deal with Drawable as the type of resource retrieved for
	/// drawing things to the screen; the Drawable class provides a generic API for
	/// dealing with an underlying visual resource that may take a variety of forms.
	/// Unlike a
	/// <see cref="android.view.View">android.view.View</see>
	/// , a Drawable does not have any facility to
	/// receive events or otherwise interact with the user.
	/// <p>In addition to simple drawing, Drawable provides a number of generic
	/// mechanisms for its client to interact with what is being drawn:
	/// <ul>
	/// <li> The
	/// <see cref="setBounds(android.graphics.Rect)">setBounds(android.graphics.Rect)</see>
	/// method <var>must</var> be called to tell the
	/// Drawable where it is drawn and how large it should be.  All Drawables
	/// should respect the requested size, often simply by scaling their
	/// imagery.  A client can find the preferred size for some Drawables with
	/// the
	/// <see cref="getIntrinsicHeight()">getIntrinsicHeight()</see>
	/// and
	/// <see cref="getIntrinsicWidth()">getIntrinsicWidth()</see>
	/// methods.
	/// <li> The
	/// <see cref="getPadding(android.graphics.Rect)">getPadding(android.graphics.Rect)</see>
	/// method can return from some Drawables
	/// information about how to frame content that is placed inside of them.
	/// For example, a Drawable that is intended to be the frame for a button
	/// widget would need to return padding that correctly places the label
	/// inside of itself.
	/// <li> The
	/// <see cref="setState(int[])">setState(int[])</see>
	/// method allows the client to tell the Drawable
	/// in which state it is to be drawn, such as "focused", "selected", etc.
	/// Some drawables may modify their imagery based on the selected state.
	/// <li> The
	/// <see cref="setLevel(int)">setLevel(int)</see>
	/// method allows the client to supply a single
	/// continuous controller that can modify the Drawable is displayed, such as
	/// a battery level or progress level.  Some drawables may modify their
	/// imagery based on the current level.
	/// <li> A Drawable can perform animations by calling back to its client
	/// through the
	/// <see cref="Callback">Callback</see>
	/// interface.  All clients should support this
	/// interface (via
	/// <see cref="setCallback(Callback)">setCallback(Callback)</see>
	/// ) so that animations will work.  A
	/// simple way to do this is through the system facilities such as
	/// <see cref="android.view.View.setBackgroundDrawable(Drawable)">android.view.View.setBackgroundDrawable(Drawable)
	/// 	</see>
	/// and
	/// <see cref="android.widget.ImageView">android.widget.ImageView</see>
	/// .
	/// </ul>
	/// Though usually not visible to the application, Drawables may take a variety
	/// of forms:
	/// <ul>
	/// <li> <b>Bitmap</b>: the simplest Drawable, a PNG or JPEG image.
	/// <li> <b>Nine Patch</b>: an extension to the PNG format allows it to
	/// specify information about how to stretch it and place things inside of
	/// it.
	/// <li> <b>Shape</b>: contains simple drawing commands instead of a raw
	/// bitmap, allowing it to resize better in some cases.
	/// <li> <b>Layers</b>: a compound drawable, which draws multiple underlying
	/// drawables on top of each other.
	/// <li> <b>States</b>: a compound drawable that selects one of a set of
	/// drawables based on its state.
	/// <li> <b>Levels</b>: a compound drawable that selects one of a set of
	/// drawables based on its level.
	/// <li> <b>Scale</b>: a compound drawable with a single child drawable,
	/// whose overall size is modified based on the current level.
	/// </ul>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about how to use drawables, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/graphics/2d-graphics.html"&gt;Canvas and Drawables</a> developer
	/// guide. For information and examples of creating drawable resources (XML or bitmap files that
	/// can be loaded in code), read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>
	/// document.</p></div>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Drawable
	{
		private static readonly android.graphics.Rect ZERO_BOUNDS_RECT = new android.graphics.Rect
			();

		private int[] mStateSet = android.util.StateSet.WILD_CARD;

		private int mLevel = 0;

		private int mChangingConfigurations = 0;

		private android.graphics.Rect mBounds = ZERO_BOUNDS_RECT;

		private java.lang.@ref.WeakReference<android.graphics.drawable.Drawable.Callback>
			 mCallback = null;

		private bool mVisible = true;

		// lazily becomes a new Rect()
		/// <summary>
		/// Draw in its bounds (set via setBounds) respecting optional effects such
		/// as alpha (set via setAlpha) and color filter (set via setColorFilter).
		/// </summary>
		/// <remarks>
		/// Draw in its bounds (set via setBounds) respecting optional effects such
		/// as alpha (set via setAlpha) and color filter (set via setColorFilter).
		/// </remarks>
		/// <param name="canvas">The canvas to draw into</param>
		public abstract void draw(android.graphics.Canvas canvas);

		/// <summary>Specify a bounding rectangle for the Drawable.</summary>
		/// <remarks>
		/// Specify a bounding rectangle for the Drawable. This is where the drawable
		/// will draw when its draw() method is called.
		/// </remarks>
		public virtual void setBounds(int left, int top, int right, int bottom)
		{
			android.graphics.Rect oldBounds = mBounds;
			if (oldBounds == ZERO_BOUNDS_RECT)
			{
				oldBounds = mBounds = new android.graphics.Rect();
			}
			if (oldBounds.left != left || oldBounds.top != top || oldBounds.right != right ||
				 oldBounds.bottom != bottom)
			{
				mBounds.set(left, top, right, bottom);
				onBoundsChange(mBounds);
			}
		}

		/// <summary>Specify a bounding rectangle for the Drawable.</summary>
		/// <remarks>
		/// Specify a bounding rectangle for the Drawable. This is where the drawable
		/// will draw when its draw() method is called.
		/// </remarks>
		public virtual void setBounds(android.graphics.Rect bounds)
		{
			setBounds(bounds.left, bounds.top, bounds.right, bounds.bottom);
		}

		/// <summary>
		/// Return a copy of the drawable's bounds in the specified Rect (allocated
		/// by the caller).
		/// </summary>
		/// <remarks>
		/// Return a copy of the drawable's bounds in the specified Rect (allocated
		/// by the caller). The bounds specify where this will draw when its draw()
		/// method is called.
		/// </remarks>
		/// <param name="bounds">
		/// Rect to receive the drawable's bounds (allocated by the
		/// caller).
		/// </param>
		public void copyBounds(android.graphics.Rect bounds)
		{
			bounds.set(mBounds);
		}

		/// <summary>Return a copy of the drawable's bounds in a new Rect.</summary>
		/// <remarks>
		/// Return a copy of the drawable's bounds in a new Rect. This returns the
		/// same values as getBounds(), but the returned object is guaranteed to not
		/// be changed later by the drawable (i.e. it retains no reference to this
		/// rect). If the caller already has a Rect allocated, call copyBounds(rect).
		/// </remarks>
		/// <returns>A copy of the drawable's bounds</returns>
		public android.graphics.Rect copyBounds()
		{
			return new android.graphics.Rect(mBounds);
		}

		/// <summary>Return the drawable's bounds Rect.</summary>
		/// <remarks>
		/// Return the drawable's bounds Rect. Note: for efficiency, the returned
		/// object may be the same object stored in the drawable (though this is not
		/// guaranteed), so if a persistent copy of the bounds is needed, call
		/// copyBounds(rect) instead.
		/// You should also not change the object returned by this method as it may
		/// be the same object stored in the drawable.
		/// </remarks>
		/// <returns>
		/// The bounds of the drawable (which may change later, so caller
		/// beware). DO NOT ALTER the returned object as it may change the
		/// stored bounds of this drawable.
		/// </returns>
		/// <seealso cref="copyBounds()">copyBounds()</seealso>
		/// <seealso cref="copyBounds(android.graphics.Rect)"></seealso>
		public android.graphics.Rect getBounds()
		{
			if (mBounds == ZERO_BOUNDS_RECT)
			{
				mBounds = new android.graphics.Rect();
			}
			return mBounds;
		}

		/// <summary>
		/// Set a mask of the configuration parameters for which this drawable
		/// may change, requiring that it be re-created.
		/// </summary>
		/// <remarks>
		/// Set a mask of the configuration parameters for which this drawable
		/// may change, requiring that it be re-created.
		/// </remarks>
		/// <param name="configs">
		/// A mask of the changing configuration parameters, as
		/// defined by
		/// <see cref="android.content.res.Configuration">android.content.res.Configuration</see>
		/// .
		/// </param>
		/// <seealso cref="android.content.res.Configuration">android.content.res.Configuration
		/// 	</seealso>
		public virtual void setChangingConfigurations(int configs)
		{
			mChangingConfigurations = configs;
		}

		/// <summary>
		/// Return a mask of the configuration parameters for which this drawable
		/// may change, requiring that it be re-created.
		/// </summary>
		/// <remarks>
		/// Return a mask of the configuration parameters for which this drawable
		/// may change, requiring that it be re-created.  The default implementation
		/// returns whatever was provided through
		/// <see cref="setChangingConfigurations(int)">setChangingConfigurations(int)</see>
		/// or 0 by default.  Subclasses
		/// may extend this to or in the changing configurations of any other
		/// drawables they hold.
		/// </remarks>
		/// <returns>
		/// Returns a mask of the changing configuration parameters, as
		/// defined by
		/// <see cref="android.content.res.Configuration">android.content.res.Configuration</see>
		/// .
		/// </returns>
		/// <seealso cref="android.content.res.Configuration">android.content.res.Configuration
		/// 	</seealso>
		public virtual int getChangingConfigurations()
		{
			return mChangingConfigurations;
		}

		/// <summary>
		/// Set to true to have the drawable dither its colors when drawn to a device
		/// with fewer than 8-bits per color component.
		/// </summary>
		/// <remarks>
		/// Set to true to have the drawable dither its colors when drawn to a device
		/// with fewer than 8-bits per color component. This can improve the look on
		/// those devices, but can also slow down the drawing a little.
		/// </remarks>
		public virtual void setDither(bool dither)
		{
		}

		/// <summary>
		/// Set to true to have the drawable filter its bitmap when scaled or rotated
		/// (for drawables that use bitmaps).
		/// </summary>
		/// <remarks>
		/// Set to true to have the drawable filter its bitmap when scaled or rotated
		/// (for drawables that use bitmaps). If the drawable does not use bitmaps,
		/// this call is ignored. This can improve the look when scaled or rotated,
		/// but also slows down the drawing.
		/// </remarks>
		public virtual void setFilterBitmap(bool filter)
		{
		}

		/// <summary>
		/// Implement this interface if you want to create an animated drawable that
		/// extends
		/// <see cref="Drawable">Drawable</see>
		/// .
		/// Upon retrieving a drawable, use
		/// <see cref="Drawable.setCallback(Callback)">Drawable.setCallback(Callback)</see>
		/// to supply your implementation of the interface to the drawable; it uses
		/// this interface to schedule and execute animation changes.
		/// </summary>
		public interface Callback
		{
			/// <summary>Called when the drawable needs to be redrawn.</summary>
			/// <remarks>
			/// Called when the drawable needs to be redrawn.  A view at this point
			/// should invalidate itself (or at least the part of itself where the
			/// drawable appears).
			/// </remarks>
			/// <param name="who">The drawable that is requesting the update.</param>
			void invalidateDrawable(android.graphics.drawable.Drawable who);

			/// <summary>
			/// A Drawable can call this to schedule the next frame of its
			/// animation.
			/// </summary>
			/// <remarks>
			/// A Drawable can call this to schedule the next frame of its
			/// animation.  An implementation can generally simply call
			/// <see cref="android.os.Handler.postAtTime(java.lang.Runnable, object, long)">android.os.Handler.postAtTime(java.lang.Runnable, object, long)
			/// 	</see>
			/// with
			/// the parameters <var>(what, who, when)</var> to perform the
			/// scheduling.
			/// </remarks>
			/// <param name="who">The drawable being scheduled.</param>
			/// <param name="what">The action to execute.</param>
			/// <param name="when">
			/// The time (in milliseconds) to run.  The timebase is
			/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
			/// 	</see>
			/// </param>
			void scheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable 
				what, long when);

			/// <summary>
			/// A Drawable can call this to unschedule an action previously
			/// scheduled with
			/// <see cref="scheduleDrawable(Drawable, java.lang.Runnable, long)">scheduleDrawable(Drawable, java.lang.Runnable, long)
			/// 	</see>
			/// .  An implementation can
			/// generally simply call
			/// <see cref="android.os.Handler.removeCallbacks(java.lang.Runnable, object)">android.os.Handler.removeCallbacks(java.lang.Runnable, object)
			/// 	</see>
			/// with
			/// the parameters <var>(what, who)</var> to unschedule the drawable.
			/// </summary>
			/// <param name="who">The drawable being unscheduled.</param>
			/// <param name="what">The action being unscheduled.</param>
			void unscheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
				 what);
		}

		/// <summary>Implement this interface if you want to create an drawable that is RTL aware
		/// 	</summary>
		/// <hide></hide>
		public interface Callback2 : android.graphics.drawable.Drawable.Callback
		{
			/// <summary>A Drawable can call this to get the resolved layout direction of the <var>who</var>.
			/// 	</summary>
			/// <remarks>A Drawable can call this to get the resolved layout direction of the <var>who</var>.
			/// 	</remarks>
			/// <param name="who">The drawable being queried.</param>
			int getResolvedLayoutDirection(android.graphics.drawable.Drawable who);
		}

		/// <summary>
		/// Bind a
		/// <see cref="Callback">Callback</see>
		/// object to this Drawable.  Required for clients
		/// that want to support animated drawables.
		/// </summary>
		/// <param name="cb">The client's Callback implementation.</param>
		/// <seealso cref="getCallback()"></seealso>
		public void setCallback(android.graphics.drawable.Drawable.Callback cb)
		{
			mCallback = new java.lang.@ref.WeakReference<android.graphics.drawable.Drawable.Callback
				>(cb);
		}

		/// <summary>
		/// Return the current
		/// <see cref="Callback">Callback</see>
		/// implementation attached to this
		/// Drawable.
		/// </summary>
		/// <returns>
		/// A
		/// <see cref="Callback">Callback</see>
		/// instance or null if no callback was set.
		/// </returns>
		/// <seealso cref="setCallback(Callback)"></seealso>
		public virtual android.graphics.drawable.Drawable.Callback getCallback()
		{
			if (mCallback != null)
			{
				return mCallback.get();
			}
			return null;
		}

		/// <summary>
		/// Use the current
		/// <see cref="Callback">Callback</see>
		/// implementation to have this Drawable
		/// redrawn.  Does nothing if there is no Callback attached to the
		/// Drawable.
		/// </summary>
		/// <seealso cref="Callback.invalidateDrawable(Drawable)">Callback.invalidateDrawable(Drawable)
		/// 	</seealso>
		/// <seealso cref="getCallback()"></seealso>
		/// <seealso cref="setCallback(Callback)"></seealso>
		public virtual void invalidateSelf()
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.invalidateDrawable(this);
			}
		}

		/// <summary>
		/// Use the current
		/// <see cref="Callback">Callback</see>
		/// implementation to have this Drawable
		/// scheduled.  Does nothing if there is no Callback attached to the
		/// Drawable.
		/// </summary>
		/// <param name="what">The action being scheduled.</param>
		/// <param name="when">The time (in milliseconds) to run.</param>
		/// <seealso cref="Callback.scheduleDrawable(Drawable, java.lang.Runnable, long)">Callback.scheduleDrawable(Drawable, java.lang.Runnable, long)
		/// 	</seealso>
		public virtual void scheduleSelf(java.lang.Runnable what, long when)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.scheduleDrawable(this, what, when);
			}
		}

		/// <summary>
		/// Use the current
		/// <see cref="Callback">Callback</see>
		/// implementation to have this Drawable
		/// unscheduled.  Does nothing if there is no Callback attached to the
		/// Drawable.
		/// </summary>
		/// <param name="what">The runnable that you no longer want called.</param>
		/// <seealso cref="Callback.unscheduleDrawable(Drawable, java.lang.Runnable)">Callback.unscheduleDrawable(Drawable, java.lang.Runnable)
		/// 	</seealso>
		public virtual void unscheduleSelf(java.lang.Runnable what)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.unscheduleDrawable(this, what);
			}
		}

		/// <summary>
		/// Use the current
		/// <see cref="Callback2">Callback2</see>
		/// implementation to get
		/// the resolved layout direction of this Drawable.
		/// </summary>
		/// <hide></hide>
		public virtual int getResolvedLayoutDirectionSelf()
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback == null || !(callback is android.graphics.drawable.Drawable.Callback2
				))
			{
				return android.view.View.LAYOUT_DIRECTION_LTR;
			}
			return ((android.graphics.drawable.Drawable.Callback2)callback).getResolvedLayoutDirection
				(this);
		}

		/// <summary>Specify an alpha value for the drawable.</summary>
		/// <remarks>
		/// Specify an alpha value for the drawable. 0 means fully transparent, and
		/// 255 means fully opaque.
		/// </remarks>
		public abstract void setAlpha(int alpha);

		/// <summary>Specify an optional colorFilter for the drawable.</summary>
		/// <remarks>
		/// Specify an optional colorFilter for the drawable. Pass null to remove
		/// any filters.
		/// </remarks>
		public abstract void setColorFilter(android.graphics.ColorFilter cf);

		/// <summary>
		/// Specify a color and porterduff mode to be the colorfilter for this
		/// drawable.
		/// </summary>
		/// <remarks>
		/// Specify a color and porterduff mode to be the colorfilter for this
		/// drawable.
		/// </remarks>
		public virtual void setColorFilter(int color, android.graphics.PorterDuff.Mode mode
			)
		{
			setColorFilter(new android.graphics.PorterDuffColorFilter(color, mode));
		}

		public virtual void clearColorFilter()
		{
			setColorFilter(null);
		}

		/// <summary>Indicates whether this view will change its appearance based on state.</summary>
		/// <remarks>
		/// Indicates whether this view will change its appearance based on state.
		/// Clients can use this to determine whether it is necessary to calculate
		/// their state and call setState.
		/// </remarks>
		/// <returns>
		/// True if this view changes its appearance based on state, false
		/// otherwise.
		/// </returns>
		/// <seealso cref="setState(int[])">setState(int[])</seealso>
		public virtual bool isStateful()
		{
			return false;
		}

		/// <summary>Specify a set of states for the drawable.</summary>
		/// <remarks>
		/// Specify a set of states for the drawable. These are use-case specific,
		/// so see the relevant documentation. As an example, the background for
		/// widgets like Button understand the following states:
		/// [
		/// <see cref="android.R.attr.state_focused">android.R.attr.state_focused</see>
		/// ,
		/// <see cref="android.R.attr.state_pressed">android.R.attr.state_pressed</see>
		/// ].
		/// <p>If the new state you are supplying causes the appearance of the
		/// Drawable to change, then it is responsible for calling
		/// <see cref="invalidateSelf()">invalidateSelf()</see>
		/// in order to have itself redrawn, <em>and</em>
		/// true will be returned from this function.
		/// <p>Note: The Drawable holds a reference on to <var>stateSet</var>
		/// until a new state array is given to it, so you must not modify this
		/// array during that time.</p>
		/// </remarks>
		/// <param name="stateSet">The new set of states to be displayed.</param>
		/// <returns>
		/// Returns true if this change in state has caused the appearance
		/// of the Drawable to change (hence requiring an invalidate), otherwise
		/// returns false.
		/// </returns>
		public virtual bool setState(int[] stateSet)
		{
			if (!java.util.Arrays.equals(mStateSet, stateSet))
			{
				mStateSet = stateSet;
				return onStateChange(stateSet);
			}
			return false;
		}

		/// <summary>
		/// Describes the current state, as a union of primitve states, such as
		/// <see cref="android.R.attr.state_focused">android.R.attr.state_focused</see>
		/// ,
		/// <see cref="android.R.attr.state_selected">android.R.attr.state_selected</see>
		/// , etc.
		/// Some drawables may modify their imagery based on the selected state.
		/// </summary>
		/// <returns>An array of resource Ids describing the current state.</returns>
		public virtual int[] getState()
		{
			return mStateSet;
		}

		/// <summary>
		/// If this Drawable does transition animations between states, ask that
		/// it immediately jump to the current state and skip any active animations.
		/// </summary>
		/// <remarks>
		/// If this Drawable does transition animations between states, ask that
		/// it immediately jump to the current state and skip any active animations.
		/// </remarks>
		public virtual void jumpToCurrentState()
		{
		}

		/// <returns>
		/// The current drawable that will be used by this drawable. For simple drawables, this
		/// is just the drawable itself. For drawables that change state like
		/// <see cref="StateListDrawable">StateListDrawable</see>
		/// and
		/// <see cref="LevelListDrawable">LevelListDrawable</see>
		/// this will be the child drawable
		/// currently in use.
		/// </returns>
		public virtual android.graphics.drawable.Drawable getCurrent()
		{
			return this;
		}

		/// <summary>Specify the level for the drawable.</summary>
		/// <remarks>
		/// Specify the level for the drawable.  This allows a drawable to vary its
		/// imagery based on a continuous controller, for example to show progress
		/// or volume level.
		/// <p>If the new level you are supplying causes the appearance of the
		/// Drawable to change, then it is responsible for calling
		/// <see cref="invalidateSelf()">invalidateSelf()</see>
		/// in order to have itself redrawn, <em>and</em>
		/// true will be returned from this function.
		/// </remarks>
		/// <param name="level">The new level, from 0 (minimum) to 10000 (maximum).</param>
		/// <returns>
		/// Returns true if this change in level has caused the appearance
		/// of the Drawable to change (hence requiring an invalidate), otherwise
		/// returns false.
		/// </returns>
		public bool setLevel(int level)
		{
			if (mLevel != level)
			{
				mLevel = level;
				return onLevelChange(level);
			}
			return false;
		}

		/// <summary>Retrieve the current level.</summary>
		/// <remarks>Retrieve the current level.</remarks>
		/// <returns>int Current level, from 0 (minimum) to 10000 (maximum).</returns>
		public int getLevel()
		{
			return mLevel;
		}

		/// <summary>Set whether this Drawable is visible.</summary>
		/// <remarks>
		/// Set whether this Drawable is visible.  This generally does not impact
		/// the Drawable's behavior, but is a hint that can be used by some
		/// Drawables, for example, to decide whether run animations.
		/// </remarks>
		/// <param name="visible">Set to true if visible, false if not.</param>
		/// <param name="restart">
		/// You can supply true here to force the drawable to behave
		/// as if it has just become visible, even if it had last
		/// been set visible.  Used for example to force animations
		/// to restart.
		/// </param>
		/// <returns>
		/// boolean Returns true if the new visibility is different than
		/// its previous state.
		/// </returns>
		public virtual bool setVisible(bool visible, bool restart)
		{
			bool changed = mVisible != visible;
			if (changed)
			{
				mVisible = visible;
				invalidateSelf();
			}
			return changed;
		}

		public bool isVisible()
		{
			return mVisible;
		}

		/// <summary>Return the opacity/transparency of this Drawable.</summary>
		/// <remarks>
		/// Return the opacity/transparency of this Drawable.  The returned value is
		/// one of the abstract format constants in
		/// <see cref="android.graphics.PixelFormat">android.graphics.PixelFormat</see>
		/// :
		/// <see cref="android.graphics.PixelFormat.UNKNOWN">android.graphics.PixelFormat.UNKNOWN
		/// 	</see>
		/// ,
		/// <see cref="android.graphics.PixelFormat.TRANSLUCENT">android.graphics.PixelFormat.TRANSLUCENT
		/// 	</see>
		/// ,
		/// <see cref="android.graphics.PixelFormat.TRANSPARENT">android.graphics.PixelFormat.TRANSPARENT
		/// 	</see>
		/// , or
		/// <see cref="android.graphics.PixelFormat.OPAQUE">android.graphics.PixelFormat.OPAQUE
		/// 	</see>
		/// .
		/// <p>Generally a Drawable should be as conservative as possible with the
		/// value it returns.  For example, if it contains multiple child drawables
		/// and only shows one of them at a time, if only one of the children is
		/// TRANSLUCENT and the others are OPAQUE then TRANSLUCENT should be
		/// returned.  You can use the method
		/// <see cref="resolveOpacity(int, int)">resolveOpacity(int, int)</see>
		/// to perform a
		/// standard reduction of two opacities to the appropriate single output.
		/// <p>Note that the returned value does <em>not</em> take into account a
		/// custom alpha or color filter that has been applied by the client through
		/// the
		/// <see cref="setAlpha(int)">setAlpha(int)</see>
		/// or
		/// <see cref="setColorFilter(android.graphics.ColorFilter)">setColorFilter(android.graphics.ColorFilter)
		/// 	</see>
		/// methods.
		/// </remarks>
		/// <returns>int The opacity class of the Drawable.</returns>
		/// <seealso cref="android.graphics.PixelFormat">android.graphics.PixelFormat</seealso>
		public abstract int getOpacity();

		/// <summary>Return the appropriate opacity value for two source opacities.</summary>
		/// <remarks>
		/// Return the appropriate opacity value for two source opacities.  If
		/// either is UNKNOWN, that is returned; else, if either is TRANSLUCENT,
		/// that is returned; else, if either is TRANSPARENT, that is returned;
		/// else, OPAQUE is returned.
		/// <p>This is to help in implementing
		/// <see cref="getOpacity()">getOpacity()</see>
		/// .
		/// </remarks>
		/// <param name="op1">One opacity value.</param>
		/// <param name="op2">Another opacity value.</param>
		/// <returns>int The combined opacity value.</returns>
		/// <seealso cref="getOpacity()">getOpacity()</seealso>
		public static int resolveOpacity(int op1, int op2)
		{
			if (op1 == op2)
			{
				return op1;
			}
			if (op1 == android.graphics.PixelFormat.UNKNOWN || op2 == android.graphics.PixelFormat
				.UNKNOWN)
			{
				return android.graphics.PixelFormat.UNKNOWN;
			}
			if (op1 == android.graphics.PixelFormat.TRANSLUCENT || op2 == android.graphics.PixelFormat
				.TRANSLUCENT)
			{
				return android.graphics.PixelFormat.TRANSLUCENT;
			}
			if (op1 == android.graphics.PixelFormat.TRANSPARENT || op2 == android.graphics.PixelFormat
				.TRANSPARENT)
			{
				return android.graphics.PixelFormat.TRANSPARENT;
			}
			return android.graphics.PixelFormat.OPAQUE;
		}

		/// <summary>
		/// Returns a Region representing the part of the Drawable that is completely
		/// transparent.
		/// </summary>
		/// <remarks>
		/// Returns a Region representing the part of the Drawable that is completely
		/// transparent.  This can be used to perform drawing operations, identifying
		/// which parts of the target will not change when rendering the Drawable.
		/// The default implementation returns null, indicating no transparent
		/// region; subclasses can optionally override this to return an actual
		/// Region if they want to supply this optimization information, but it is
		/// not required that they do so.
		/// </remarks>
		/// <returns>
		/// Returns null if the Drawables has no transparent region to
		/// report, else a Region holding the parts of the Drawable's bounds that
		/// are transparent.
		/// </returns>
		public virtual android.graphics.Region getTransparentRegion()
		{
			return null;
		}

		/// <summary>
		/// Override this in your subclass to change appearance if you recognize the
		/// specified state.
		/// </summary>
		/// <remarks>
		/// Override this in your subclass to change appearance if you recognize the
		/// specified state.
		/// </remarks>
		/// <returns>
		/// Returns true if the state change has caused the appearance of
		/// the Drawable to change (that is, it needs to be drawn), else false
		/// if it looks the same and there is no need to redraw it since its
		/// last state.
		/// </returns>
		protected internal virtual bool onStateChange(int[] state)
		{
			return false;
		}

		/// <summary>
		/// Override this in your subclass to change appearance if you vary based
		/// on level.
		/// </summary>
		/// <remarks>
		/// Override this in your subclass to change appearance if you vary based
		/// on level.
		/// </remarks>
		/// <returns>
		/// Returns true if the level change has caused the appearance of
		/// the Drawable to change (that is, it needs to be drawn), else false
		/// if it looks the same and there is no need to redraw it since its
		/// last level.
		/// </returns>
		protected internal virtual bool onLevelChange(int level)
		{
			return false;
		}

		/// <summary>
		/// Override this in your subclass to change appearance if you recognize the
		/// specified state.
		/// </summary>
		/// <remarks>
		/// Override this in your subclass to change appearance if you recognize the
		/// specified state.
		/// </remarks>
		protected internal virtual void onBoundsChange(android.graphics.Rect bounds)
		{
		}

		/// <summary>Return the intrinsic width of the underlying drawable object.</summary>
		/// <remarks>
		/// Return the intrinsic width of the underlying drawable object.  Returns
		/// -1 if it has no intrinsic width, such as with a solid color.
		/// </remarks>
		public virtual int getIntrinsicWidth()
		{
			return -1;
		}

		/// <summary>Return the intrinsic height of the underlying drawable object.</summary>
		/// <remarks>
		/// Return the intrinsic height of the underlying drawable object. Returns
		/// -1 if it has no intrinsic height, such as with a solid color.
		/// </remarks>
		public virtual int getIntrinsicHeight()
		{
			return -1;
		}

		/// <summary>Returns the minimum width suggested by this Drawable.</summary>
		/// <remarks>
		/// Returns the minimum width suggested by this Drawable. If a View uses this
		/// Drawable as a background, it is suggested that the View use at least this
		/// value for its width. (There will be some scenarios where this will not be
		/// possible.) This value should INCLUDE any padding.
		/// </remarks>
		/// <returns>
		/// The minimum width suggested by this Drawable. If this Drawable
		/// doesn't have a suggested minimum width, 0 is returned.
		/// </returns>
		public virtual int getMinimumWidth()
		{
			int intrinsicWidth = getIntrinsicWidth();
			return intrinsicWidth > 0 ? intrinsicWidth : 0;
		}

		/// <summary>Returns the minimum height suggested by this Drawable.</summary>
		/// <remarks>
		/// Returns the minimum height suggested by this Drawable. If a View uses this
		/// Drawable as a background, it is suggested that the View use at least this
		/// value for its height. (There will be some scenarios where this will not be
		/// possible.) This value should INCLUDE any padding.
		/// </remarks>
		/// <returns>
		/// The minimum height suggested by this Drawable. If this Drawable
		/// doesn't have a suggested minimum height, 0 is returned.
		/// </returns>
		public virtual int getMinimumHeight()
		{
			int intrinsicHeight = getIntrinsicHeight();
			return intrinsicHeight > 0 ? intrinsicHeight : 0;
		}

		/// <summary>
		/// Return in padding the insets suggested by this Drawable for placing
		/// content inside the drawable's bounds.
		/// </summary>
		/// <remarks>
		/// Return in padding the insets suggested by this Drawable for placing
		/// content inside the drawable's bounds. Positive values move toward the
		/// center of the Drawable (set Rect.inset). Returns true if this drawable
		/// actually has a padding, else false. When false is returned, the padding
		/// is always set to 0.
		/// </remarks>
		public virtual bool getPadding(android.graphics.Rect padding)
		{
			padding.set(0, 0, 0, 0);
			return false;
		}

		/// <summary>Make this drawable mutable.</summary>
		/// <remarks>
		/// Make this drawable mutable. This operation cannot be reversed. A mutable
		/// drawable is guaranteed to not share its state with any other drawable.
		/// This is especially useful when you need to modify properties of drawables
		/// loaded from resources. By default, all drawables instances loaded from
		/// the same resource share a common state; if you modify the state of one
		/// instance, all the other instances will receive the same modification.
		/// Calling this method on a mutable Drawable will have no effect.
		/// </remarks>
		/// <returns>This drawable.</returns>
		/// <seealso cref="ConstantState">ConstantState</seealso>
		/// <seealso cref="getConstantState()">getConstantState()</seealso>
		public virtual android.graphics.drawable.Drawable mutate()
		{
			return this;
		}

		/// <summary>Create a drawable from an inputstream</summary>
		public static android.graphics.drawable.Drawable createFromStream(java.io.InputStream
			 @is, string srcName)
		{
			return createFromResourceStream(null, null, @is, srcName, null);
		}

		/// <summary>
		/// Create a drawable from an inputstream, using the given resources and
		/// value to determine density information.
		/// </summary>
		/// <remarks>
		/// Create a drawable from an inputstream, using the given resources and
		/// value to determine density information.
		/// </remarks>
		public static android.graphics.drawable.Drawable createFromResourceStream(android.content.res.Resources
			 res, android.util.TypedValue value, java.io.InputStream @is, string srcName)
		{
			return createFromResourceStream(res, value, @is, srcName, null);
		}

		/// <summary>
		/// Create a drawable from an inputstream, using the given resources and
		/// value to determine density information.
		/// </summary>
		/// <remarks>
		/// Create a drawable from an inputstream, using the given resources and
		/// value to determine density information.
		/// </remarks>
		public static android.graphics.drawable.Drawable createFromResourceStream(android.content.res.Resources
			 res, android.util.TypedValue value, java.io.InputStream @is, string srcName, android.graphics.BitmapFactory
			.Options opts)
		{
			if (@is == null)
			{
				return null;
			}
			android.graphics.Rect pad = new android.graphics.Rect();
			// Special stuff for compatibility mode: if the target density is not
			// the same as the display density, but the resource -is- the same as
			// the display density, then don't scale it down to the target density.
			// This allows us to load the system's density-correct resources into
			// an application in compatibility mode, without scaling those down
			// to the compatibility density only to have them scaled back up when
			// drawn to the screen.
			if (opts == null)
			{
				opts = new android.graphics.BitmapFactory.Options();
			}
			opts.inScreenDensity = android.util.DisplayMetrics.DENSITY_DEVICE;
			android.graphics.Bitmap bm = android.graphics.BitmapFactory.decodeResourceStream(
				res, value, @is, pad, opts);
			if (bm != null)
			{
				byte[] np = bm.getNinePatchChunk();
				if (np == null || !android.graphics.NinePatch.isNinePatchChunk(np))
				{
					np = null;
					pad = null;
				}
				return drawableFromBitmap(res, bm, np, pad, srcName);
			}
			return null;
		}

		/// <summary>Create a drawable from an XML document.</summary>
		/// <remarks>
		/// Create a drawable from an XML document. For more information on how to
		/// create resources in XML, see
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static android.graphics.drawable.Drawable createFromXml(android.content.res.Resources
			 r, org.xmlpull.v1.XmlPullParser parser)
		{
			android.util.AttributeSet attrs = android.util.Xml.asAttributeSet(parser);
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG && type
				 != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
			}
			// Empty loop
			if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
			{
				throw new org.xmlpull.v1.XmlPullParserException("No start tag found");
			}
			android.graphics.drawable.Drawable drawable = createFromXmlInner(r, parser, attrs
				);
			if (drawable == null)
			{
				throw new java.lang.RuntimeException("Unknown initial tag: " + parser.getName());
			}
			return drawable;
		}

		/// <summary>Create from inside an XML document.</summary>
		/// <remarks>
		/// Create from inside an XML document.  Called on a parser positioned at
		/// a tag in an XML document, tries to create a Drawable from that tag.
		/// Returns null if the tag is not a valid drawable.
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static android.graphics.drawable.Drawable createFromXmlInner(android.content.res.Resources
			 r, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs)
		{
			android.graphics.drawable.Drawable drawable;
			string name = parser.getName();
			if (name.Equals("selector"))
			{
				drawable = new android.graphics.drawable.StateListDrawable();
			}
			else
			{
				if (name.Equals("level-list"))
				{
					drawable = new android.graphics.drawable.LevelListDrawable();
				}
				else
				{
					if (name.Equals("layer-list"))
					{
						drawable = new android.graphics.drawable.LayerDrawable();
					}
					else
					{
						if (name.Equals("transition"))
						{
							drawable = new android.graphics.drawable.TransitionDrawable();
						}
						else
						{
							if (name.Equals("color"))
							{
								drawable = new android.graphics.drawable.ColorDrawable();
							}
							else
							{
								if (name.Equals("shape"))
								{
									drawable = new android.graphics.drawable.GradientDrawable();
								}
								else
								{
									if (name.Equals("scale"))
									{
										drawable = new android.graphics.drawable.ScaleDrawable();
									}
									else
									{
										if (name.Equals("clip"))
										{
											drawable = new android.graphics.drawable.ClipDrawable();
										}
										else
										{
											if (name.Equals("rotate"))
											{
												drawable = new android.graphics.drawable.RotateDrawable();
											}
											else
											{
												if (name.Equals("animated-rotate"))
												{
													drawable = new android.graphics.drawable.AnimatedRotateDrawable();
												}
												else
												{
													if (name.Equals("animation-list"))
													{
														drawable = new android.graphics.drawable.AnimationDrawable();
													}
													else
													{
														if (name.Equals("inset"))
														{
															drawable = new android.graphics.drawable.InsetDrawable();
														}
														else
														{
															if (name.Equals("bitmap"))
															{
																drawable = new android.graphics.drawable.BitmapDrawable(r);
																if (r != null)
																{
																	((android.graphics.drawable.BitmapDrawable)drawable).setTargetDensity(r.getDisplayMetrics
																		());
																}
															}
															else
															{
																if (name.Equals("nine-patch"))
																{
																	drawable = new android.graphics.drawable.NinePatchDrawable();
																	if (r != null)
																	{
																		((android.graphics.drawable.NinePatchDrawable)drawable).setTargetDensity(r.getDisplayMetrics
																			());
																	}
																}
																else
																{
																	throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
																		 ": invalid drawable tag " + name);
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			drawable.inflate(r, parser, attrs);
			return drawable;
		}

		/// <summary>Create a drawable from file path name.</summary>
		/// <remarks>Create a drawable from file path name.</remarks>
		public static android.graphics.drawable.Drawable createFromPath(string pathName)
		{
			if (pathName == null)
			{
				return null;
			}
			android.graphics.Bitmap bm = android.graphics.BitmapFactory.decodeFile(pathName);
			if (bm != null)
			{
				return drawableFromBitmap(null, bm, null, null, pathName);
			}
			return null;
		}

		/// <summary>Inflate this Drawable from an XML resource.</summary>
		/// <remarks>Inflate this Drawable from an XML resource.</remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.Drawable);
			inflateWithAttributes(r, parser, a, android.@internal.R.styleable.Drawable_visible
				);
			a.recycle();
		}

		/// <summary>Inflate a Drawable from an XML resource.</summary>
		/// <remarks>Inflate a Drawable from an XML resource.</remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException">org.xmlpull.v1.XmlPullParserException
		/// 	</exception>
		/// <exception cref="System.IO.IOException">System.IO.IOException</exception>
		internal virtual void inflateWithAttributes(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.content.res.TypedArray attrs, int visibleAttr)
		{
			mVisible = attrs.getBoolean(visibleAttr, mVisible);
		}

		/// <summary>
		/// This abstract class is used by
		/// <see cref="Drawable">Drawable</see>
		/// s to store shared constant state and data
		/// between Drawables.
		/// <see cref="BitmapDrawable">BitmapDrawable</see>
		/// s created from the same resource will for instance
		/// share a unique bitmap stored in their ConstantState.
		/// <p>
		/// <see cref="newDrawable(android.content.res.Resources)">newDrawable(android.content.res.Resources)
		/// 	</see>
		/// can be used as a factory to create new Drawable instances
		/// from this ConstantState.
		/// </p>
		/// Use
		/// <see cref="Drawable.getConstantState()">Drawable.getConstantState()</see>
		/// to retrieve the ConstantState of a Drawable. Calling
		/// <see cref="Drawable.mutate()">Drawable.mutate()</see>
		/// on a Drawable should typically create a new ConstantState for that
		/// Drawable.
		/// </summary>
		public abstract class ConstantState
		{
			/// <summary>
			/// Create a new drawable without supplying resources the caller
			/// is running in.
			/// </summary>
			/// <remarks>
			/// Create a new drawable without supplying resources the caller
			/// is running in.  Note that using this means the density-dependent
			/// drawables (like bitmaps) will not be able to update their target
			/// density correctly. One should use
			/// <see cref="newDrawable(android.content.res.Resources)">newDrawable(android.content.res.Resources)
			/// 	</see>
			/// instead to provide a resource.
			/// </remarks>
			public abstract android.graphics.drawable.Drawable newDrawable();

			/// <summary>Create a new Drawable instance from its constant state.</summary>
			/// <remarks>
			/// Create a new Drawable instance from its constant state.  This
			/// must be implemented for drawables that change based on the target
			/// density of their caller (that is depending on whether it is
			/// in compatibility mode).
			/// </remarks>
			public virtual android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return newDrawable();
			}

			/// <summary>
			/// Return a bit mask of configuration changes that will impact
			/// this drawable (and thus require completely reloading it).
			/// </summary>
			/// <remarks>
			/// Return a bit mask of configuration changes that will impact
			/// this drawable (and thus require completely reloading it).
			/// </remarks>
			public abstract int getChangingConfigurations();
		}

		/// <summary>
		/// Return a
		/// <see cref="ConstantState">ConstantState</see>
		/// instance that holds the shared state of this Drawable.
		/// q
		/// </summary>
		/// <returns>The ConstantState associated to that Drawable.</returns>
		/// <seealso cref="ConstantState">ConstantState</seealso>
		/// <seealso cref="mutate()">mutate()</seealso>
		public virtual android.graphics.drawable.Drawable.ConstantState getConstantState(
			)
		{
			return null;
		}

		private static android.graphics.drawable.Drawable drawableFromBitmap(android.content.res.Resources
			 res, android.graphics.Bitmap bm, byte[] np, android.graphics.Rect pad, string srcName
			)
		{
			if (np != null)
			{
				return new android.graphics.drawable.NinePatchDrawable(res, bm, np, pad, srcName);
			}
			return new android.graphics.drawable.BitmapDrawable(res, bm);
		}
	}
}
