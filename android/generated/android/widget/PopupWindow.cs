using Sharpen;

namespace android.widget
{
	/// <summary><p>A popup window that can be used to display an arbitrary view.</summary>
	/// <remarks>
	/// <p>A popup window that can be used to display an arbitrary view. The popup
	/// windows is a floating container that appears on top of the current
	/// activity.</p>
	/// </remarks>
	/// <seealso cref="AutoCompleteTextView">AutoCompleteTextView</seealso>
	/// <seealso cref="Spinner">Spinner</seealso>
	[Sharpen.Sharpened]
	public class PopupWindow
	{
		/// <summary>
		/// Mode for
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// : the requirements for the
		/// input method should be based on the focusability of the popup.  That is
		/// if it is focusable than it needs to work with the input method, else
		/// it doesn't.
		/// </summary>
		public const int INPUT_METHOD_FROM_FOCUSABLE = 0;

		/// <summary>
		/// Mode for
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// : this popup always needs to
		/// work with an input method, regardless of whether it is focusable.  This
		/// means that it will always be displayed so that the user can also operate
		/// the input method while it is shown.
		/// </summary>
		public const int INPUT_METHOD_NEEDED = 1;

		/// <summary>
		/// Mode for
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// : this popup never needs to
		/// work with an input method, regardless of whether it is focusable.  This
		/// means that it will always be displayed to use as much space on the
		/// screen as needed, regardless of whether this covers the input method.
		/// </summary>
		public const int INPUT_METHOD_NOT_NEEDED = 2;

		private android.content.Context mContext;

		private android.view.WindowManager mWindowManager;

		private bool mIsShowing;

		private bool mIsDropdown;

		private android.view.View mContentView;

		private android.view.View mPopupView;

		private bool mFocusable;

		private int mInputMethodMode = INPUT_METHOD_FROM_FOCUSABLE;

		private int mSoftInputMode = android.view.WindowManagerClass.LayoutParams.SOFT_INPUT_STATE_UNCHANGED;

		private bool mTouchable = true;

		private bool mOutsideTouchable = false;

		private bool mClippingEnabled = true;

		private int mSplitTouchEnabled = -1;

		private bool mLayoutInScreen;

		private bool mClipToScreen;

		private bool mAllowScrollingAnchorParent = true;

		private bool mLayoutInsetDecor = false;

		private bool mNotTouchModal;

		private android.view.View.OnTouchListener mTouchInterceptor;

		private int mWidthMode;

		private int mWidth;

		private int mLastWidth;

		private int mHeightMode;

		private int mHeight;

		private int mLastHeight;

		private int mPopupWidth;

		private int mPopupHeight;

		private int[] mDrawingLocation = new int[2];

		private int[] mScreenLocation = new int[2];

		private android.graphics.Rect mTempRect = new android.graphics.Rect();

		private android.graphics.drawable.Drawable mBackground;

		private android.graphics.drawable.Drawable mAboveAnchorBackgroundDrawable;

		private android.graphics.drawable.Drawable mBelowAnchorBackgroundDrawable;

		private bool mAboveAnchor;

		private int mWindowLayoutType = android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_PANEL;

		private android.widget.PopupWindow.OnDismissListener mOnDismissListener;

		private bool mIgnoreCheekPress = false;

		private int mAnimationStyle = -1;

		private static readonly int[] ABOVE_ANCHOR_STATE_SET = new int[] { android.@internal.R
			.attr.state_above_anchor };

		private java.lang.@ref.WeakReference<android.view.View> mAnchor;

		private sealed class _OnScrollChangedListener_131 : android.view.ViewTreeObserver
			.OnScrollChangedListener
		{
			public _OnScrollChangedListener_131(PopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnScrollChangedListener"
				)]
			public void onScrollChanged()
			{
				android.view.View anchor = this._enclosing.mAnchor != null ? this._enclosing.mAnchor
					.get() : null;
				if (anchor != null && this._enclosing.mPopupView != null)
				{
					android.view.WindowManagerClass.LayoutParams p = (android.view.WindowManagerClass
						.LayoutParams)this._enclosing.mPopupView.getLayoutParams();
					this._enclosing.updateAboveAnchor(this._enclosing.findDropDownPosition(anchor, p, 
						this._enclosing.mAnchorXoff, this._enclosing.mAnchorYoff));
					this._enclosing.update(p.x, p.y, -1, -1, true);
				}
			}

			private readonly PopupWindow _enclosing;
		}

		private android.view.ViewTreeObserver.OnScrollChangedListener mOnScrollChangedListener;

		private int mAnchorXoff;

		private int mAnchorYoff;

		/// <summary>
		/// <p>Create a new empty, non focusable popup window of dimension (0,0).</p>
		/// <p>The popup does provide a background.</p>
		/// </summary>
		public PopupWindow(android.content.Context context) : this(context, null)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
		}

		/// <summary>
		/// <p>Create a new empty, non focusable popup window of dimension (0,0).</p>
		/// <p>The popup does provide a background.</p>
		/// </summary>
		public PopupWindow(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.popupWindowStyle)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
		}

		/// <summary>
		/// <p>Create a new empty, non focusable popup window of dimension (0,0).</p>
		/// <p>The popup does provide a background.</p>
		/// </summary>
		public PopupWindow(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : this(context, attrs, defStyle, 0)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
		}

		/// <summary>
		/// <p>Create a new, empty, non focusable popup window of dimension (0,0).</p>
		/// <p>The popup does not provide a background.</p>
		/// </summary>
		public PopupWindow(android.content.Context context, android.util.AttributeSet attrs
			, int defStyleAttr, int defStyleRes)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
			mContext = context;
			mWindowManager = (android.view.WindowManager)context.getSystemService(android.content.Context
				.WINDOW_SERVICE);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.PopupWindow, defStyleAttr, defStyleRes);
			mBackground = a.getDrawable(android.@internal.R.styleable.PopupWindow_popupBackground
				);
			int animStyle = a.getResourceId(android.@internal.R.styleable.PopupWindow_popupAnimationStyle
				, -1);
			mAnimationStyle = animStyle == android.@internal.R.style.Animation_PopupWindow ? 
				-1 : animStyle;
			// If this is a StateListDrawable, try to find and store the drawable to be
			// used when the drop-down is placed above its anchor view, and the one to be
			// used when the drop-down is placed below its anchor view. We extract
			// the drawables ourselves to work around a problem with using refreshDrawableState
			// that it will take into account the padding of all drawables specified in a
			// StateListDrawable, thus adding superfluous padding to drop-down views.
			//
			// We assume a StateListDrawable will have a drawable for ABOVE_ANCHOR_STATE_SET and
			// at least one other drawable, intended for the 'below-anchor state'.
			if (mBackground is android.graphics.drawable.StateListDrawable)
			{
				android.graphics.drawable.StateListDrawable background = (android.graphics.drawable.StateListDrawable
					)mBackground;
				// Find the above-anchor view - this one's easy, it should be labeled as such.
				int aboveAnchorStateIndex = background.getStateDrawableIndex(ABOVE_ANCHOR_STATE_SET
					);
				// Now, for the below-anchor view, look for any other drawable specified in the
				// StateListDrawable which is not for the above-anchor state and use that.
				int count = background.getStateCount();
				int belowAnchorStateIndex = -1;
				{
					for (int i = 0; i < count; i++)
					{
						if (i != aboveAnchorStateIndex)
						{
							belowAnchorStateIndex = i;
							break;
						}
					}
				}
				// Store the drawables we found, if we found them. Otherwise, set them both
				// to null so that we'll just use refreshDrawableState.
				if (aboveAnchorStateIndex != -1 && belowAnchorStateIndex != -1)
				{
					mAboveAnchorBackgroundDrawable = background.getStateDrawable(aboveAnchorStateIndex
						);
					mBelowAnchorBackgroundDrawable = background.getStateDrawable(belowAnchorStateIndex
						);
				}
				else
				{
					mBelowAnchorBackgroundDrawable = null;
					mAboveAnchorBackgroundDrawable = null;
				}
			}
			a.recycle();
		}

		/// <summary>
		/// <p>Create a new empty, non focusable popup window of dimension (0,0).</p>
		/// <p>The popup does not provide any background.
		/// </summary>
		/// <remarks>
		/// <p>Create a new empty, non focusable popup window of dimension (0,0).</p>
		/// <p>The popup does not provide any background. This should be handled
		/// by the content view.</p>
		/// </remarks>
		public PopupWindow() : this(null, 0, 0)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
		}

		/// <summary>
		/// <p>Create a new non focusable popup window which can display the
		/// <tt>contentView</tt>.
		/// </summary>
		/// <remarks>
		/// <p>Create a new non focusable popup window which can display the
		/// <tt>contentView</tt>. The dimension of the window are (0,0).</p>
		/// <p>The popup does not provide any background. This should be handled
		/// by the content view.</p>
		/// </remarks>
		/// <param name="contentView">the popup's content</param>
		public PopupWindow(android.view.View contentView) : this(contentView, 0, 0)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
		}

		/// <summary><p>Create a new empty, non focusable popup window.</summary>
		/// <remarks>
		/// <p>Create a new empty, non focusable popup window. The dimension of the
		/// window must be passed to this constructor.</p>
		/// <p>The popup does not provide any background. This should be handled
		/// by the content view.</p>
		/// </remarks>
		/// <param name="width">the popup's width</param>
		/// <param name="height">the popup's height</param>
		public PopupWindow(int width, int height) : this(null, width, height)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
		}

		/// <summary>
		/// <p>Create a new non focusable popup window which can display the
		/// <tt>contentView</tt>.
		/// </summary>
		/// <remarks>
		/// <p>Create a new non focusable popup window which can display the
		/// <tt>contentView</tt>. The dimension of the window must be passed to
		/// this constructor.</p>
		/// <p>The popup does not provide any background. This should be handled
		/// by the content view.</p>
		/// </remarks>
		/// <param name="contentView">the popup's content</param>
		/// <param name="width">the popup's width</param>
		/// <param name="height">the popup's height</param>
		public PopupWindow(android.view.View contentView, int width, int height) : this(contentView
			, width, height, false)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
		}

		/// <summary><p>Create a new popup window which can display the <tt>contentView</tt>.
		/// 	</summary>
		/// <remarks>
		/// <p>Create a new popup window which can display the <tt>contentView</tt>.
		/// The dimension of the window must be passed to this constructor.</p>
		/// <p>The popup does not provide any background. This should be handled
		/// by the content view.</p>
		/// </remarks>
		/// <param name="contentView">the popup's content</param>
		/// <param name="width">the popup's width</param>
		/// <param name="height">the popup's height</param>
		/// <param name="focusable">true if the popup can be focused, false otherwise</param>
		public PopupWindow(android.view.View contentView, int width, int height, bool focusable
			)
		{
			mOnScrollChangedListener = new _OnScrollChangedListener_131(this);
			if (contentView != null)
			{
				mContext = contentView.getContext();
				mWindowManager = (android.view.WindowManager)mContext.getSystemService(android.content.Context
					.WINDOW_SERVICE);
			}
			setContentView(contentView);
			setWidth(width);
			setHeight(height);
			setFocusable(focusable);
		}

		/// <summary><p>Return the drawable used as the popup window's background.</p></summary>
		/// <returns>the background drawable or null</returns>
		public virtual android.graphics.drawable.Drawable getBackground()
		{
			return mBackground;
		}

		/// <summary><p>Change the background drawable for this popup window.</summary>
		/// <remarks>
		/// <p>Change the background drawable for this popup window. The background
		/// can be set to null.</p>
		/// </remarks>
		/// <param name="background">the popup's background</param>
		public virtual void setBackgroundDrawable(android.graphics.drawable.Drawable background
			)
		{
			mBackground = background;
		}

		/// <summary><p>Return the animation style to use the popup appears and disappears</p>
		/// 	</summary>
		/// <returns>the animation style to use the popup appears and disappears</returns>
		public virtual int getAnimationStyle()
		{
			return mAnimationStyle;
		}

		/// <summary>
		/// Set the flag on popup to ignore cheek press eventt; by default this flag
		/// is set to false
		/// which means the pop wont ignore cheek press dispatch events.
		/// </summary>
		/// <remarks>
		/// Set the flag on popup to ignore cheek press eventt; by default this flag
		/// is set to false
		/// which means the pop wont ignore cheek press dispatch events.
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to one of
		/// the
		/// <see cref="update()">update()</see>
		/// methods.</p>
		/// </remarks>
		/// <seealso cref="update()">update()</seealso>
		public virtual void setIgnoreCheekPress()
		{
			mIgnoreCheekPress = true;
		}

		/// <summary>
		/// <p>Change the animation style resource for this popup.</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to one of
		/// the
		/// <see cref="update()">update()</see>
		/// methods.</p>
		/// </summary>
		/// <param name="animationStyle">
		/// animation style to use when the popup appears
		/// and disappears.  Set to -1 for the default animation, 0 for no
		/// animation, or a resource identifier for an explicit animation.
		/// </param>
		/// <seealso cref="update()">update()</seealso>
		public virtual void setAnimationStyle(int animationStyle)
		{
			mAnimationStyle = animationStyle;
		}

		/// <summary><p>Return the view used as the content of the popup window.</p></summary>
		/// <returns>
		/// a
		/// <see cref="android.view.View">android.view.View</see>
		/// representing the popup's content
		/// </returns>
		/// <seealso cref="setContentView(android.view.View)">setContentView(android.view.View)
		/// 	</seealso>
		public virtual android.view.View getContentView()
		{
			return mContentView;
		}

		/// <summary><p>Change the popup's content.</summary>
		/// <remarks>
		/// <p>Change the popup's content. The content is represented by an instance
		/// of
		/// <see cref="android.view.View">android.view.View</see>
		/// .</p>
		/// <p>This method has no effect if called when the popup is showing.</p>
		/// </remarks>
		/// <param name="contentView">the new content for the popup</param>
		/// <seealso cref="getContentView()">getContentView()</seealso>
		/// <seealso cref="isShowing()">isShowing()</seealso>
		public virtual void setContentView(android.view.View contentView)
		{
			if (isShowing())
			{
				return;
			}
			mContentView = contentView;
			if (mContext == null && mContentView != null)
			{
				mContext = mContentView.getContext();
			}
			if (mWindowManager == null && mContentView != null)
			{
				mWindowManager = (android.view.WindowManager)mContext.getSystemService(android.content.Context
					.WINDOW_SERVICE);
			}
		}

		/// <summary>
		/// Set a callback for all touch events being dispatched to the popup
		/// window.
		/// </summary>
		/// <remarks>
		/// Set a callback for all touch events being dispatched to the popup
		/// window.
		/// </remarks>
		public virtual void setTouchInterceptor(android.view.View.OnTouchListener l)
		{
			mTouchInterceptor = l;
		}

		/// <summary><p>Indicate whether the popup window can grab the focus.</p></summary>
		/// <returns>true if the popup is focusable, false otherwise</returns>
		/// <seealso cref="setFocusable(bool)">setFocusable(bool)</seealso>
		public virtual bool isFocusable()
		{
			return mFocusable;
		}

		/// <summary><p>Changes the focusability of the popup window.</summary>
		/// <remarks>
		/// <p>Changes the focusability of the popup window. When focusable, the
		/// window will grab the focus from the current focused widget if the popup
		/// contains a focusable
		/// <see cref="android.view.View">android.view.View</see>
		/// .  By default a popup
		/// window is not focusable.</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to one of
		/// the
		/// <see cref="update()">update()</see>
		/// methods.</p>
		/// </remarks>
		/// <param name="focusable">true if the popup should grab focus, false otherwise.</param>
		/// <seealso cref="isFocusable()">isFocusable()</seealso>
		/// <seealso cref="isShowing()"></seealso>
		/// <seealso cref="update()">update()</seealso>
		public virtual void setFocusable(bool focusable)
		{
			mFocusable = focusable;
		}

		/// <summary>
		/// Return the current value in
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// .
		/// </summary>
		/// <seealso cref="setInputMethodMode(int)">setInputMethodMode(int)</seealso>
		public virtual int getInputMethodMode()
		{
			return mInputMethodMode;
		}

		/// <summary>
		/// Control how the popup operates with an input method: one of
		/// <see cref="INPUT_METHOD_FROM_FOCUSABLE">INPUT_METHOD_FROM_FOCUSABLE</see>
		/// ,
		/// <see cref="INPUT_METHOD_NEEDED">INPUT_METHOD_NEEDED</see>
		/// ,
		/// or
		/// <see cref="INPUT_METHOD_NOT_NEEDED">INPUT_METHOD_NOT_NEEDED</see>
		/// .
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to one of
		/// the
		/// <see cref="update()">update()</see>
		/// methods.</p>
		/// </summary>
		/// <seealso cref="getInputMethodMode()">getInputMethodMode()</seealso>
		/// <seealso cref="update()">update()</seealso>
		public virtual void setInputMethodMode(int mode)
		{
			mInputMethodMode = mode;
		}

		/// <summary>Sets the operating mode for the soft input area.</summary>
		/// <remarks>Sets the operating mode for the soft input area.</remarks>
		/// <param name="mode">
		/// The desired mode, see
		/// <see cref="android.view.WindowManagerClass.LayoutParams.softInputMode">android.view.WindowManagerClass.LayoutParams.softInputMode
		/// 	</see>
		/// for the full list
		/// </param>
		/// <seealso cref="android.view.WindowManagerClass.LayoutParams.softInputMode">android.view.WindowManagerClass.LayoutParams.softInputMode
		/// 	</seealso>
		/// <seealso cref="getSoftInputMode()">getSoftInputMode()</seealso>
		public virtual void setSoftInputMode(int mode)
		{
			mSoftInputMode = mode;
		}

		/// <summary>
		/// Returns the current value in
		/// <see cref="setSoftInputMode(int)">setSoftInputMode(int)</see>
		/// .
		/// </summary>
		/// <seealso cref="setSoftInputMode(int)">setSoftInputMode(int)</seealso>
		/// <seealso cref="android.view.WindowManagerClass.LayoutParams.softInputMode">android.view.WindowManagerClass.LayoutParams.softInputMode
		/// 	</seealso>
		public virtual int getSoftInputMode()
		{
			return mSoftInputMode;
		}

		/// <summary><p>Indicates whether the popup window receives touch events.</p></summary>
		/// <returns>true if the popup is touchable, false otherwise</returns>
		/// <seealso cref="setTouchable(bool)">setTouchable(bool)</seealso>
		public virtual bool isTouchable()
		{
			return mTouchable;
		}

		/// <summary><p>Changes the touchability of the popup window.</summary>
		/// <remarks>
		/// <p>Changes the touchability of the popup window. When touchable, the
		/// window will receive touch events, otherwise touch events will go to the
		/// window below it. By default the window is touchable.</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to one of
		/// the
		/// <see cref="update()">update()</see>
		/// methods.</p>
		/// </remarks>
		/// <param name="touchable">true if the popup should receive touch events, false otherwise
		/// 	</param>
		/// <seealso cref="isTouchable()">isTouchable()</seealso>
		/// <seealso cref="isShowing()"></seealso>
		/// <seealso cref="update()">update()</seealso>
		public virtual void setTouchable(bool touchable)
		{
			mTouchable = touchable;
		}

		/// <summary>
		/// <p>Indicates whether the popup window will be informed of touch events
		/// outside of its window.</p>
		/// </summary>
		/// <returns>true if the popup is outside touchable, false otherwise</returns>
		/// <seealso cref="setOutsideTouchable(bool)">setOutsideTouchable(bool)</seealso>
		public virtual bool isOutsideTouchable()
		{
			return mOutsideTouchable;
		}

		/// <summary>
		/// <p>Controls whether the pop-up will be informed of touch events outside
		/// of its window.
		/// </summary>
		/// <remarks>
		/// <p>Controls whether the pop-up will be informed of touch events outside
		/// of its window.  This only makes sense for pop-ups that are touchable
		/// but not focusable, which means touches outside of the window will
		/// be delivered to the window behind.  The default is false.</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to one of
		/// the
		/// <see cref="update()">update()</see>
		/// methods.</p>
		/// </remarks>
		/// <param name="touchable">
		/// true if the popup should receive outside
		/// touch events, false otherwise
		/// </param>
		/// <seealso cref="isOutsideTouchable()">isOutsideTouchable()</seealso>
		/// <seealso cref="isShowing()"></seealso>
		/// <seealso cref="update()">update()</seealso>
		public virtual void setOutsideTouchable(bool touchable)
		{
			mOutsideTouchable = touchable;
		}

		/// <summary><p>Indicates whether clipping of the popup window is enabled.</p></summary>
		/// <returns>true if the clipping is enabled, false otherwise</returns>
		/// <seealso cref="setClippingEnabled(bool)">setClippingEnabled(bool)</seealso>
		public virtual bool isClippingEnabled()
		{
			return mClippingEnabled;
		}

		/// <summary><p>Allows the popup window to extend beyond the bounds of the screen.</summary>
		/// <remarks>
		/// <p>Allows the popup window to extend beyond the bounds of the screen. By default the
		/// window is clipped to the screen boundaries. Setting this to false will allow windows to be
		/// accurately positioned.</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to one of
		/// the
		/// <see cref="update()">update()</see>
		/// methods.</p>
		/// </remarks>
		/// <param name="enabled">false if the window should be allowed to extend outside of the screen
		/// 	</param>
		/// <seealso cref="isShowing()"></seealso>
		/// <seealso cref="isClippingEnabled()">isClippingEnabled()</seealso>
		/// <seealso cref="update()">update()</seealso>
		public virtual void setClippingEnabled(bool enabled)
		{
			mClippingEnabled = enabled;
		}

		/// <summary>Clip this popup window to the screen, but not to the containing window.</summary>
		/// <remarks>Clip this popup window to the screen, but not to the containing window.</remarks>
		/// <param name="enabled">True to clip to the screen.</param>
		/// <hide></hide>
		public virtual void setClipToScreenEnabled(bool enabled)
		{
			mClipToScreen = enabled;
			setClippingEnabled(!enabled);
		}

		/// <summary>
		/// Allow PopupWindow to scroll the anchor's parent to provide more room
		/// for the popup.
		/// </summary>
		/// <remarks>
		/// Allow PopupWindow to scroll the anchor's parent to provide more room
		/// for the popup. Enabled by default.
		/// </remarks>
		/// <param name="enabled">True to scroll the anchor's parent when more room is desired by the popup.
		/// 	</param>
		internal virtual void setAllowScrollingAnchorParent(bool enabled)
		{
			mAllowScrollingAnchorParent = enabled;
		}

		/// <summary><p>Indicates whether the popup window supports splitting touches.</p></summary>
		/// <returns>true if the touch splitting is enabled, false otherwise</returns>
		/// <seealso cref="setSplitTouchEnabled(bool)">setSplitTouchEnabled(bool)</seealso>
		public virtual bool isSplitTouchEnabled()
		{
			if (mSplitTouchEnabled < 0 && mContext != null)
			{
				return mContext.getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES
					.HONEYCOMB;
			}
			return mSplitTouchEnabled == 1;
		}

		/// <summary>
		/// <p>Allows the popup window to split touches across other windows that also
		/// support split touch.
		/// </summary>
		/// <remarks>
		/// <p>Allows the popup window to split touches across other windows that also
		/// support split touch.  When this flag is false, the first pointer
		/// that goes down determines the window to which all subsequent touches
		/// go until all pointers go up.  When this flag is true, each pointer
		/// (not necessarily the first) that goes down determines the window
		/// to which all subsequent touches of that pointer will go until that
		/// pointer goes up thereby enabling touches with multiple pointers
		/// to be split across multiple windows.</p>
		/// </remarks>
		/// <param name="enabled">true if the split touches should be enabled, false otherwise
		/// 	</param>
		/// <seealso cref="isSplitTouchEnabled()">isSplitTouchEnabled()</seealso>
		public virtual void setSplitTouchEnabled(bool enabled)
		{
			mSplitTouchEnabled = enabled ? 1 : 0;
		}

		/// <summary>
		/// <p>Indicates whether the popup window will be forced into using absolute screen coordinates
		/// for positioning.</p>
		/// </summary>
		/// <returns>true if the window will always be positioned in screen coordinates.</returns>
		/// <hide></hide>
		public virtual bool isLayoutInScreenEnabled()
		{
			return mLayoutInScreen;
		}

		/// <summary>
		/// <p>Allows the popup window to force the flag
		/// <see cref="android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_IN_SCREEN">android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_IN_SCREEN
		/// 	</see>
		/// , overriding default behavior.
		/// This will cause the popup to be positioned in absolute screen coordinates.</p>
		/// </summary>
		/// <param name="enabled">true if the popup should always be positioned in screen coordinates
		/// 	</param>
		/// <hide></hide>
		public virtual void setLayoutInScreenEnabled(bool enabled)
		{
			mLayoutInScreen = enabled;
		}

		/// <summary>
		/// Allows the popup window to force the flag
		/// <see cref="android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_INSET_DECOR">android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_INSET_DECOR
		/// 	</see>
		/// , overriding default behavior.
		/// This will cause the popup to inset its content to account for system windows overlaying
		/// the screen, such as the status bar.
		/// <p>This will often be combined with
		/// <see cref="setLayoutInScreenEnabled(bool)">setLayoutInScreenEnabled(bool)</see>
		/// .
		/// </summary>
		/// <param name="enabled">
		/// true if the popup's views should inset content to account for system windows,
		/// the way that decor views behave for full-screen windows.
		/// </param>
		/// <hide></hide>
		public virtual void setLayoutInsetDecor(bool enabled)
		{
			mLayoutInsetDecor = enabled;
		}

		/// <summary>Set the layout type for this window.</summary>
		/// <remarks>
		/// Set the layout type for this window. Should be one of the TYPE constants defined in
		/// <see cref="android.view.WindowManagerClass.LayoutParams">android.view.WindowManagerClass.LayoutParams
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="layoutType">Layout type for this window.</param>
		/// <hide></hide>
		public virtual void setWindowLayoutType(int layoutType)
		{
			mWindowLayoutType = layoutType;
		}

		/// <returns>The layout type for this window.</returns>
		/// <hide></hide>
		public virtual int getWindowLayoutType()
		{
			return mWindowLayoutType;
		}

		/// <summary>
		/// Set whether this window is touch modal or if outside touches will be sent to
		/// other windows behind it.
		/// </summary>
		/// <remarks>
		/// Set whether this window is touch modal or if outside touches will be sent to
		/// other windows behind it.
		/// </remarks>
		/// <hide></hide>
		public virtual void setTouchModal(bool touchModal)
		{
			mNotTouchModal = !touchModal;
		}

		/// <summary>
		/// <p>Change the width and height measure specs that are given to the
		/// window manager by the popup.
		/// </summary>
		/// <remarks>
		/// <p>Change the width and height measure specs that are given to the
		/// window manager by the popup.  By default these are 0, meaning that
		/// the current width or height is requested as an explicit size from
		/// the window manager.  You can supply
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// or
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// to have that measure
		/// spec supplied instead, replacing the absolute width and height that
		/// has been set in the popup.</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown.</p>
		/// </remarks>
		/// <param name="widthSpec">
		/// an explicit width measure spec mode, either
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// ,
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// , or 0 to use the absolute
		/// width.
		/// </param>
		/// <param name="heightSpec">
		/// an explicit height measure spec mode, either
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// ,
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// , or 0 to use the absolute
		/// height.
		/// </param>
		public virtual void setWindowLayoutMode(int widthSpec, int heightSpec)
		{
			mWidthMode = widthSpec;
			mHeightMode = heightSpec;
		}

		/// <summary><p>Return this popup's height MeasureSpec</p></summary>
		/// <returns>the height MeasureSpec of the popup</returns>
		/// <seealso cref="setHeight(int)">setHeight(int)</seealso>
		public virtual int getHeight()
		{
			return mHeight;
		}

		/// <summary>
		/// <p>Change the popup's height MeasureSpec</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown.</p>
		/// </summary>
		/// <param name="height">the height MeasureSpec of the popup</param>
		/// <seealso cref="getHeight()">getHeight()</seealso>
		/// <seealso cref="isShowing()"></seealso>
		public virtual void setHeight(int height)
		{
			mHeight = height;
		}

		/// <summary><p>Return this popup's width MeasureSpec</p></summary>
		/// <returns>the width MeasureSpec of the popup</returns>
		/// <seealso cref="setWidth(int)"></seealso>
		public virtual int getWidth()
		{
			return mWidth;
		}

		/// <summary>
		/// <p>Change the popup's width MeasureSpec</p>
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown.</p>
		/// </summary>
		/// <param name="width">the width MeasureSpec of the popup</param>
		/// <seealso cref="getWidth()">getWidth()</seealso>
		/// <seealso cref="isShowing()">isShowing()</seealso>
		public virtual void setWidth(int width)
		{
			mWidth = width;
		}

		/// <summary><p>Indicate whether this popup window is showing on screen.</p></summary>
		/// <returns>true if the popup is showing, false otherwise</returns>
		public virtual bool isShowing()
		{
			return mIsShowing;
		}

		/// <summary>
		/// <p>
		/// Display the content view in a popup window at the specified location.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Display the content view in a popup window at the specified location. If the popup window
		/// cannot fit on screen, it will be clipped. See
		/// <see cref="android.view.WindowManagerClass.LayoutParams">android.view.WindowManagerClass.LayoutParams
		/// 	</see>
		/// for more information on how gravity and the x and y parameters are related. Specifying
		/// a gravity of
		/// <see cref="android.view.Gravity.NO_GRAVITY">android.view.Gravity.NO_GRAVITY</see>
		/// is similar to specifying
		/// <code>Gravity.LEFT | Gravity.TOP</code>.
		/// </p>
		/// </remarks>
		/// <param name="parent">
		/// a parent view to get the
		/// <see cref="android.view.View.getWindowToken()">android.view.View.getWindowToken()
		/// 	</see>
		/// token from
		/// </param>
		/// <param name="gravity">the gravity which controls the placement of the popup window
		/// 	</param>
		/// <param name="x">the popup's x location offset</param>
		/// <param name="y">the popup's y location offset</param>
		public virtual void showAtLocation(android.view.View parent, int gravity, int x, 
			int y)
		{
			showAtLocation(parent.getWindowToken(), gravity, x, y);
		}

		/// <summary>Display the content view in a popup window at the specified location.</summary>
		/// <remarks>Display the content view in a popup window at the specified location.</remarks>
		/// <param name="token">Window token to use for creating the new window</param>
		/// <param name="gravity">the gravity which controls the placement of the popup window
		/// 	</param>
		/// <param name="x">the popup's x location offset</param>
		/// <param name="y">the popup's y location offset</param>
		/// <hide>
		/// Internal use only. Applications should use
		/// <see cref="showAtLocation(android.view.View, int, int, int)">showAtLocation(android.view.View, int, int, int)
		/// 	</see>
		/// instead.
		/// </hide>
		public virtual void showAtLocation(android.os.IBinder token, int gravity, int x, 
			int y)
		{
			if (isShowing() || mContentView == null)
			{
				return;
			}
			unregisterForScrollChanged();
			mIsShowing = true;
			mIsDropdown = false;
			android.view.WindowManagerClass.LayoutParams p = createPopupLayout(token);
			p.windowAnimations = computeAnimationResource();
			preparePopup(p);
			if (gravity == android.view.Gravity.NO_GRAVITY)
			{
				gravity = android.view.Gravity.TOP | android.view.Gravity.LEFT;
			}
			p.gravity = gravity;
			p.x = x;
			p.y = y;
			if (mHeightMode < 0)
			{
				p.height = mLastHeight = mHeightMode;
			}
			if (mWidthMode < 0)
			{
				p.width = mLastWidth = mWidthMode;
			}
			invokePopup(p);
		}

		/// <summary>
		/// <p>Display the content view in a popup window anchored to the bottom-left
		/// corner of the anchor view.
		/// </summary>
		/// <remarks>
		/// <p>Display the content view in a popup window anchored to the bottom-left
		/// corner of the anchor view. If there is not enough room on screen to show
		/// the popup in its entirety, this method tries to find a parent scroll
		/// view to scroll. If no parent scroll view can be scrolled, the bottom-left
		/// corner of the popup is pinned at the top left corner of the anchor view.</p>
		/// </remarks>
		/// <param name="anchor">the view on which to pin the popup window</param>
		/// <seealso cref="dismiss()">dismiss()</seealso>
		public virtual void showAsDropDown(android.view.View anchor)
		{
			showAsDropDown(anchor, 0, 0);
		}

		/// <summary>
		/// <p>Display the content view in a popup window anchored to the bottom-left
		/// corner of the anchor view offset by the specified x and y coordinates.
		/// </summary>
		/// <remarks>
		/// <p>Display the content view in a popup window anchored to the bottom-left
		/// corner of the anchor view offset by the specified x and y coordinates.
		/// If there is not enough room on screen to show
		/// the popup in its entirety, this method tries to find a parent scroll
		/// view to scroll. If no parent scroll view can be scrolled, the bottom-left
		/// corner of the popup is pinned at the top left corner of the anchor view.</p>
		/// <p>If the view later scrolls to move <code>anchor</code> to a different
		/// location, the popup will be moved correspondingly.</p>
		/// </remarks>
		/// <param name="anchor">the view on which to pin the popup window</param>
		/// <seealso cref="dismiss()">dismiss()</seealso>
		public virtual void showAsDropDown(android.view.View anchor, int xoff, int yoff)
		{
			if (isShowing() || mContentView == null)
			{
				return;
			}
			registerForScrollChanged(anchor, xoff, yoff);
			mIsShowing = true;
			mIsDropdown = true;
			android.view.WindowManagerClass.LayoutParams p = createPopupLayout(anchor.getWindowToken
				());
			preparePopup(p);
			updateAboveAnchor(findDropDownPosition(anchor, p, xoff, yoff));
			if (mHeightMode < 0)
			{
				p.height = mLastHeight = mHeightMode;
			}
			if (mWidthMode < 0)
			{
				p.width = mLastWidth = mWidthMode;
			}
			p.windowAnimations = computeAnimationResource();
			invokePopup(p);
		}

		private void updateAboveAnchor(bool aboveAnchor)
		{
			if (aboveAnchor != mAboveAnchor)
			{
				mAboveAnchor = aboveAnchor;
				if (mBackground != null)
				{
					// If the background drawable provided was a StateListDrawable with above-anchor
					// and below-anchor states, use those. Otherwise rely on refreshDrawableState to
					// do the job.
					if (mAboveAnchorBackgroundDrawable != null)
					{
						if (mAboveAnchor)
						{
							mPopupView.setBackgroundDrawable(mAboveAnchorBackgroundDrawable);
						}
						else
						{
							mPopupView.setBackgroundDrawable(mBelowAnchorBackgroundDrawable);
						}
					}
					else
					{
						mPopupView.refreshDrawableState();
					}
				}
			}
		}

		/// <summary>
		/// Indicates whether the popup is showing above (the y coordinate of the popup's bottom
		/// is less than the y coordinate of the anchor) or below the anchor view (the y coordinate
		/// of the popup is greater than y coordinate of the anchor's bottom).
		/// </summary>
		/// <remarks>
		/// Indicates whether the popup is showing above (the y coordinate of the popup's bottom
		/// is less than the y coordinate of the anchor) or below the anchor view (the y coordinate
		/// of the popup is greater than y coordinate of the anchor's bottom).
		/// The value returned
		/// by this method is meaningful only after
		/// <see cref="showAsDropDown(android.view.View)">showAsDropDown(android.view.View)</see>
		/// or
		/// <see cref="showAsDropDown(android.view.View, int, int)">showAsDropDown(android.view.View, int, int)
		/// 	</see>
		/// was invoked.
		/// </remarks>
		/// <returns>True if this popup is showing above the anchor view, false otherwise.</returns>
		public virtual bool isAboveAnchor()
		{
			return mAboveAnchor;
		}

		/// <summary>
		/// <p>Prepare the popup by embedding in into a new ViewGroup if the
		/// background drawable is not null.
		/// </summary>
		/// <remarks>
		/// <p>Prepare the popup by embedding in into a new ViewGroup if the
		/// background drawable is not null. If embedding is required, the layout
		/// parameters' height is mnodified to take into account the background's
		/// padding.</p>
		/// </remarks>
		/// <param name="p">the layout parameters of the popup's content view</param>
		private void preparePopup(android.view.WindowManagerClass.LayoutParams p)
		{
			if (mContentView == null || mContext == null || mWindowManager == null)
			{
				throw new System.InvalidOperationException("You must specify a valid content view by "
					 + "calling setContentView() before attempting to show the popup.");
			}
			if (mBackground != null)
			{
				android.view.ViewGroup.LayoutParams layoutParams = mContentView.getLayoutParams();
				int height = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				if (layoutParams != null && layoutParams.height == android.view.ViewGroup.LayoutParams
					.WRAP_CONTENT)
				{
					height = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
				}
				// when a background is available, we embed the content view
				// within another view that owns the background drawable
				android.widget.PopupWindow.PopupViewContainer popupViewContainer = new android.widget.PopupWindow
					.PopupViewContainer(this, mContext);
				android.widget.FrameLayout.LayoutParams listParams = new android.widget.FrameLayout
					.LayoutParams(android.view.ViewGroup.LayoutParams.MATCH_PARENT, height);
				popupViewContainer.setBackgroundDrawable(mBackground);
				popupViewContainer.addView(mContentView, listParams);
				mPopupView = popupViewContainer;
			}
			else
			{
				mPopupView = mContentView;
			}
			mPopupWidth = p.width;
			mPopupHeight = p.height;
		}

		/// <summary>
		/// <p>Invoke the popup window by adding the content view to the window
		/// manager.</p>
		/// <p>The content view must be non-null when this method is invoked.</p>
		/// </summary>
		/// <param name="p">the layout parameters of the popup's content view</param>
		private void invokePopup(android.view.WindowManagerClass.LayoutParams p)
		{
			if (mContext != null)
			{
				p.packageName = mContext.getPackageName();
			}
			mPopupView.setFitsSystemWindows(mLayoutInsetDecor);
			mWindowManager.addView(mPopupView, p);
		}

		/// <summary><p>Generate the layout parameters for the popup window.</p></summary>
		/// <param name="token">the window token used to bind the popup's window</param>
		/// <returns>the layout parameters to pass to the window manager</returns>
		private android.view.WindowManagerClass.LayoutParams createPopupLayout(android.os.IBinder
			 token)
		{
			// generates the layout parameters for the drop down
			// we want a fixed size view located at the bottom left of the anchor
			android.view.WindowManagerClass.LayoutParams p = new android.view.WindowManagerClass
				.LayoutParams();
			// these gravity settings put the view at the top left corner of the
			// screen. The view is then positioned to the appropriate location
			// by setting the x and y offsets to match the anchor's bottom
			// left corner
			p.gravity = android.view.Gravity.LEFT | android.view.Gravity.TOP;
			p.width = mLastWidth = mWidth;
			p.height = mLastHeight = mHeight;
			if (mBackground != null)
			{
				p.format = mBackground.getOpacity();
			}
			else
			{
				p.format = android.graphics.PixelFormat.TRANSLUCENT;
			}
			p.flags = computeFlags(p.flags);
			p.type = mWindowLayoutType;
			p.token = token;
			p.softInputMode = mSoftInputMode;
			p.setTitle(java.lang.CharSequenceProxy.Wrap("PopupWindow:" + Sharpen.Util.IntToHexString
				(GetHashCode())));
			return p;
		}

		private int computeFlags(int curFlags)
		{
			curFlags &= ~(android.view.WindowManagerClass.LayoutParams.FLAG_IGNORE_CHEEK_PRESSES
				 | android.view.WindowManagerClass.LayoutParams.FLAG_NOT_FOCUSABLE | android.view.WindowManagerClass
				.LayoutParams.FLAG_NOT_TOUCHABLE | android.view.WindowManagerClass.LayoutParams.
				FLAG_WATCH_OUTSIDE_TOUCH | android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_NO_LIMITS
				 | android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM | android.view.WindowManagerClass
				.LayoutParams.FLAG_SPLIT_TOUCH);
			if (mIgnoreCheekPress)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_IGNORE_CHEEK_PRESSES;
			}
			if (!mFocusable)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_NOT_FOCUSABLE;
				if (mInputMethodMode == INPUT_METHOD_NEEDED)
				{
					curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM;
				}
			}
			else
			{
				if (mInputMethodMode == INPUT_METHOD_NOT_NEEDED)
				{
					curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM;
				}
			}
			if (!mTouchable)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_NOT_TOUCHABLE;
			}
			if (mOutsideTouchable)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_WATCH_OUTSIDE_TOUCH;
			}
			if (!mClippingEnabled)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_NO_LIMITS;
			}
			if (isSplitTouchEnabled())
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_SPLIT_TOUCH;
			}
			if (mLayoutInScreen)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_IN_SCREEN;
			}
			if (mLayoutInsetDecor)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_LAYOUT_INSET_DECOR;
			}
			if (mNotTouchModal)
			{
				curFlags |= android.view.WindowManagerClass.LayoutParams.FLAG_NOT_TOUCH_MODAL;
			}
			return curFlags;
		}

		private int computeAnimationResource()
		{
			if (mAnimationStyle == -1)
			{
				if (mIsDropdown)
				{
					return mAboveAnchor ? android.@internal.R.style.Animation_DropDownUp : android.@internal.R
						.style.Animation_DropDownDown;
				}
				return 0;
			}
			return mAnimationStyle;
		}

		/// <summary><p>Positions the popup window on screen.</summary>
		/// <remarks>
		/// <p>Positions the popup window on screen. When the popup window is too
		/// tall to fit under the anchor, a parent scroll view is seeked and scrolled
		/// up to reclaim space. If scrolling is not possible or not enough, the
		/// popup window gets moved on top of the anchor.</p>
		/// <p>The height must have been set on the layout parameters prior to
		/// calling this method.</p>
		/// </remarks>
		/// <param name="anchor">the view on which the popup window must be anchored</param>
		/// <param name="p">the layout parameters used to display the drop down</param>
		/// <returns>true if the popup is translated upwards to fit on screen</returns>
		private bool findDropDownPosition(android.view.View anchor, android.view.WindowManagerClass
			.LayoutParams p, int xoff, int yoff)
		{
			int anchorHeight = anchor.getHeight();
			anchor.getLocationInWindow(mDrawingLocation);
			p.x = mDrawingLocation[0] + xoff;
			p.y = mDrawingLocation[1] + anchorHeight + yoff;
			bool onTop = false;
			p.gravity = android.view.Gravity.LEFT | android.view.Gravity.TOP;
			anchor.getLocationOnScreen(mScreenLocation);
			android.graphics.Rect displayFrame = new android.graphics.Rect();
			anchor.getWindowVisibleDisplayFrame(displayFrame);
			int screenY = mScreenLocation[1] + anchorHeight + yoff;
			android.view.View root = anchor.getRootView();
			if (screenY + mPopupHeight > displayFrame.bottom || p.x + mPopupWidth - root.getWidth
				() > 0)
			{
				// if the drop down disappears at the bottom of the screen. we try to
				// scroll a parent scrollview or move the drop down back up on top of
				// the edit box
				if (mAllowScrollingAnchorParent)
				{
					int scrollX = anchor.getScrollX();
					int scrollY = anchor.getScrollY();
					android.graphics.Rect r = new android.graphics.Rect(scrollX, scrollY, scrollX + mPopupWidth
						 + xoff, scrollY + mPopupHeight + anchor.getHeight() + yoff);
					anchor.requestRectangleOnScreen(r, true);
				}
				// now we re-evaluate the space available, and decide from that
				// whether the pop-up will go above or below the anchor.
				anchor.getLocationInWindow(mDrawingLocation);
				p.x = mDrawingLocation[0] + xoff;
				p.y = mDrawingLocation[1] + anchor.getHeight() + yoff;
				// determine whether there is more space above or below the anchor
				anchor.getLocationOnScreen(mScreenLocation);
				onTop = (displayFrame.bottom - mScreenLocation[1] - anchor.getHeight() - yoff) < 
					(mScreenLocation[1] - yoff - displayFrame.top);
				if (onTop)
				{
					p.gravity = android.view.Gravity.LEFT | android.view.Gravity.BOTTOM;
					p.y = root.getHeight() - mDrawingLocation[1] + yoff;
				}
				else
				{
					p.y = mDrawingLocation[1] + anchor.getHeight() + yoff;
				}
			}
			if (mClipToScreen)
			{
				int displayFrameWidth = displayFrame.right - displayFrame.left;
				int right = p.x + p.width;
				if (right > displayFrameWidth)
				{
					p.x -= right - displayFrameWidth;
				}
				if (p.x < displayFrame.left)
				{
					p.x = displayFrame.left;
					p.width = System.Math.Min(p.width, displayFrameWidth);
				}
				if (onTop)
				{
					int popupTop = mScreenLocation[1] + yoff - mPopupHeight;
					if (popupTop < 0)
					{
						p.y += popupTop;
					}
				}
				else
				{
					p.y = System.Math.Max(p.y, displayFrame.top);
				}
			}
			p.gravity |= android.view.Gravity.DISPLAY_CLIP_VERTICAL;
			return onTop;
		}

		/// <summary>
		/// Returns the maximum height that is available for the popup to be
		/// completely shown.
		/// </summary>
		/// <remarks>
		/// Returns the maximum height that is available for the popup to be
		/// completely shown. It is recommended that this height be the maximum for
		/// the popup's height, otherwise it is possible that the popup will be
		/// clipped.
		/// </remarks>
		/// <param name="anchor">The view on which the popup window must be anchored.</param>
		/// <returns>
		/// The maximum available height for the popup to be completely
		/// shown.
		/// </returns>
		public virtual int getMaxAvailableHeight(android.view.View anchor)
		{
			return getMaxAvailableHeight(anchor, 0);
		}

		/// <summary>
		/// Returns the maximum height that is available for the popup to be
		/// completely shown.
		/// </summary>
		/// <remarks>
		/// Returns the maximum height that is available for the popup to be
		/// completely shown. It is recommended that this height be the maximum for
		/// the popup's height, otherwise it is possible that the popup will be
		/// clipped.
		/// </remarks>
		/// <param name="anchor">The view on which the popup window must be anchored.</param>
		/// <param name="yOffset">y offset from the view's bottom edge</param>
		/// <returns>
		/// The maximum available height for the popup to be completely
		/// shown.
		/// </returns>
		public virtual int getMaxAvailableHeight(android.view.View anchor, int yOffset)
		{
			return getMaxAvailableHeight(anchor, yOffset, false);
		}

		/// <summary>
		/// Returns the maximum height that is available for the popup to be
		/// completely shown, optionally ignoring any bottom decorations such as
		/// the input method.
		/// </summary>
		/// <remarks>
		/// Returns the maximum height that is available for the popup to be
		/// completely shown, optionally ignoring any bottom decorations such as
		/// the input method. It is recommended that this height be the maximum for
		/// the popup's height, otherwise it is possible that the popup will be
		/// clipped.
		/// </remarks>
		/// <param name="anchor">The view on which the popup window must be anchored.</param>
		/// <param name="yOffset">y offset from the view's bottom edge</param>
		/// <param name="ignoreBottomDecorations">
		/// if true, the height returned will be
		/// all the way to the bottom of the display, ignoring any
		/// bottom decorations
		/// </param>
		/// <returns>
		/// The maximum available height for the popup to be completely
		/// shown.
		/// </returns>
		/// <hide>Pending API council approval.</hide>
		public virtual int getMaxAvailableHeight(android.view.View anchor, int yOffset, bool
			 ignoreBottomDecorations)
		{
			android.graphics.Rect displayFrame = new android.graphics.Rect();
			anchor.getWindowVisibleDisplayFrame(displayFrame);
			int[] anchorPos = mDrawingLocation;
			anchor.getLocationOnScreen(anchorPos);
			int bottomEdge = displayFrame.bottom;
			if (ignoreBottomDecorations)
			{
				android.content.res.Resources res = anchor.getContext().getResources();
				bottomEdge = res.getDisplayMetrics().heightPixels;
			}
			int distanceToBottom = bottomEdge - (anchorPos[1] + anchor.getHeight()) - yOffset;
			int distanceToTop = anchorPos[1] - displayFrame.top + yOffset;
			// anchorPos[1] is distance from anchor to top of screen
			int returnedHeight = System.Math.Max(distanceToBottom, distanceToTop);
			if (mBackground != null)
			{
				mBackground.getPadding(mTempRect);
				returnedHeight -= mTempRect.top + mTempRect.bottom;
			}
			return returnedHeight;
		}

		/// <summary><p>Dispose of the popup window.</summary>
		/// <remarks>
		/// <p>Dispose of the popup window. This method can be invoked only after
		/// <see cref="showAsDropDown(android.view.View)">showAsDropDown(android.view.View)</see>
		/// has been executed. Failing that, calling
		/// this method will have no effect.</p>
		/// </remarks>
		/// <seealso cref="showAsDropDown(android.view.View)"></seealso>
		public virtual void dismiss()
		{
			if (isShowing() && mPopupView != null)
			{
				unregisterForScrollChanged();
				try
				{
					mWindowManager.removeView(mPopupView);
				}
				finally
				{
					if (mPopupView != mContentView && mPopupView is android.view.ViewGroup)
					{
						((android.view.ViewGroup)mPopupView).removeView(mContentView);
					}
					mPopupView = null;
					mIsShowing = false;
					if (mOnDismissListener != null)
					{
						mOnDismissListener.onDismiss();
					}
				}
			}
		}

		/// <summary>Sets the listener to be called when the window is dismissed.</summary>
		/// <remarks>Sets the listener to be called when the window is dismissed.</remarks>
		/// <param name="onDismissListener">The listener.</param>
		public virtual void setOnDismissListener(android.widget.PopupWindow.OnDismissListener
			 onDismissListener)
		{
			mOnDismissListener = onDismissListener;
		}

		/// <summary>
		/// Updates the state of the popup window, if it is currently being displayed,
		/// from the currently set state.
		/// </summary>
		/// <remarks>
		/// Updates the state of the popup window, if it is currently being displayed,
		/// from the currently set state.  This include:
		/// <see cref="setClippingEnabled(bool)">setClippingEnabled(bool)</see>
		/// ,
		/// <see cref="setFocusable(bool)">setFocusable(bool)</see>
		/// ,
		/// <see cref="setIgnoreCheekPress()">setIgnoreCheekPress()</see>
		/// ,
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// ,
		/// <see cref="setTouchable(bool)">setTouchable(bool)</see>
		/// , and
		/// <see cref="setAnimationStyle(int)">setAnimationStyle(int)</see>
		/// .
		/// </remarks>
		public virtual void update()
		{
			if (!isShowing() || mContentView == null)
			{
				return;
			}
			android.view.WindowManagerClass.LayoutParams p = (android.view.WindowManagerClass
				.LayoutParams)mPopupView.getLayoutParams();
			bool update_1 = false;
			int newAnim = computeAnimationResource();
			if (newAnim != p.windowAnimations)
			{
				p.windowAnimations = newAnim;
				update_1 = true;
			}
			int newFlags = computeFlags(p.flags);
			if (newFlags != p.flags)
			{
				p.flags = newFlags;
				update_1 = true;
			}
			if (update_1)
			{
				mWindowManager.updateViewLayout(mPopupView, p);
			}
		}

		/// <summary><p>Updates the dimension of the popup window.</summary>
		/// <remarks>
		/// <p>Updates the dimension of the popup window. Calling this function
		/// also updates the window with the current popup state as described
		/// for
		/// <see cref="update()">update()</see>
		/// .</p>
		/// </remarks>
		/// <param name="width">the new width</param>
		/// <param name="height">the new height</param>
		public virtual void update(int width, int height)
		{
			android.view.WindowManagerClass.LayoutParams p = (android.view.WindowManagerClass
				.LayoutParams)mPopupView.getLayoutParams();
			update(p.x, p.y, width, height, false);
		}

		/// <summary><p>Updates the position and the dimension of the popup window.</summary>
		/// <remarks>
		/// <p>Updates the position and the dimension of the popup window. Width and
		/// height can be set to -1 to update location only.  Calling this function
		/// also updates the window with the current popup state as
		/// described for
		/// <see cref="update()">update()</see>
		/// .</p>
		/// </remarks>
		/// <param name="x">the new x location</param>
		/// <param name="y">the new y location</param>
		/// <param name="width">the new width, can be -1 to ignore</param>
		/// <param name="height">the new height, can be -1 to ignore</param>
		public virtual void update(int x, int y, int width, int height)
		{
			update(x, y, width, height, false);
		}

		/// <summary><p>Updates the position and the dimension of the popup window.</summary>
		/// <remarks>
		/// <p>Updates the position and the dimension of the popup window. Width and
		/// height can be set to -1 to update location only.  Calling this function
		/// also updates the window with the current popup state as
		/// described for
		/// <see cref="update()">update()</see>
		/// .</p>
		/// </remarks>
		/// <param name="x">the new x location</param>
		/// <param name="y">the new y location</param>
		/// <param name="width">the new width, can be -1 to ignore</param>
		/// <param name="height">the new height, can be -1 to ignore</param>
		/// <param name="force">
		/// reposition the window even if the specified position
		/// already seems to correspond to the LayoutParams
		/// </param>
		public virtual void update(int x, int y, int width, int height, bool force)
		{
			if (width != -1)
			{
				mLastWidth = width;
				setWidth(width);
			}
			if (height != -1)
			{
				mLastHeight = height;
				setHeight(height);
			}
			if (!isShowing() || mContentView == null)
			{
				return;
			}
			android.view.WindowManagerClass.LayoutParams p = (android.view.WindowManagerClass
				.LayoutParams)mPopupView.getLayoutParams();
			bool update_1 = force;
			int finalWidth = mWidthMode < 0 ? mWidthMode : mLastWidth;
			if (width != -1 && p.width != finalWidth)
			{
				p.width = mLastWidth = finalWidth;
				update_1 = true;
			}
			int finalHeight = mHeightMode < 0 ? mHeightMode : mLastHeight;
			if (height != -1 && p.height != finalHeight)
			{
				p.height = mLastHeight = finalHeight;
				update_1 = true;
			}
			if (p.x != x)
			{
				p.x = x;
				update_1 = true;
			}
			if (p.y != y)
			{
				p.y = y;
				update_1 = true;
			}
			int newAnim = computeAnimationResource();
			if (newAnim != p.windowAnimations)
			{
				p.windowAnimations = newAnim;
				update_1 = true;
			}
			int newFlags = computeFlags(p.flags);
			if (newFlags != p.flags)
			{
				p.flags = newFlags;
				update_1 = true;
			}
			if (update_1)
			{
				mWindowManager.updateViewLayout(mPopupView, p);
			}
		}

		/// <summary><p>Updates the position and the dimension of the popup window.</summary>
		/// <remarks>
		/// <p>Updates the position and the dimension of the popup window. Calling this
		/// function also updates the window with the current popup state as described
		/// for
		/// <see cref="update()">update()</see>
		/// .</p>
		/// </remarks>
		/// <param name="anchor">the popup's anchor view</param>
		/// <param name="width">the new width, can be -1 to ignore</param>
		/// <param name="height">the new height, can be -1 to ignore</param>
		public virtual void update(android.view.View anchor, int width, int height)
		{
			update(anchor, false, 0, 0, true, width, height);
		}

		/// <summary><p>Updates the position and the dimension of the popup window.</summary>
		/// <remarks>
		/// <p>Updates the position and the dimension of the popup window. Width and
		/// height can be set to -1 to update location only.  Calling this function
		/// also updates the window with the current popup state as
		/// described for
		/// <see cref="update()">update()</see>
		/// .</p>
		/// <p>If the view later scrolls to move <code>anchor</code> to a different
		/// location, the popup will be moved correspondingly.</p>
		/// </remarks>
		/// <param name="anchor">the popup's anchor view</param>
		/// <param name="xoff">x offset from the view's left edge</param>
		/// <param name="yoff">y offset from the view's bottom edge</param>
		/// <param name="width">the new width, can be -1 to ignore</param>
		/// <param name="height">the new height, can be -1 to ignore</param>
		public virtual void update(android.view.View anchor, int xoff, int yoff, int width
			, int height)
		{
			update(anchor, true, xoff, yoff, true, width, height);
		}

		private void update(android.view.View anchor, bool updateLocation, int xoff, int 
			yoff, bool updateDimension, int width, int height)
		{
			if (!isShowing() || mContentView == null)
			{
				return;
			}
			java.lang.@ref.WeakReference<android.view.View> oldAnchor = mAnchor;
			bool needsUpdate = updateLocation && (mAnchorXoff != xoff || mAnchorYoff != yoff);
			if (oldAnchor == null || oldAnchor.get() != anchor || (needsUpdate && !mIsDropdown
				))
			{
				registerForScrollChanged(anchor, xoff, yoff);
			}
			else
			{
				if (needsUpdate)
				{
					// No need to register again if this is a DropDown, showAsDropDown already did.
					mAnchorXoff = xoff;
					mAnchorYoff = yoff;
				}
			}
			android.view.WindowManagerClass.LayoutParams p = (android.view.WindowManagerClass
				.LayoutParams)mPopupView.getLayoutParams();
			if (updateDimension)
			{
				if (width == -1)
				{
					width = mPopupWidth;
				}
				else
				{
					mPopupWidth = width;
				}
				if (height == -1)
				{
					height = mPopupHeight;
				}
				else
				{
					mPopupHeight = height;
				}
			}
			int x = p.x;
			int y = p.y;
			if (updateLocation)
			{
				updateAboveAnchor(findDropDownPosition(anchor, p, xoff, yoff));
			}
			else
			{
				updateAboveAnchor(findDropDownPosition(anchor, p, mAnchorXoff, mAnchorYoff));
			}
			update(p.x, p.y, width, height, x != p.x || y != p.y);
		}

		/// <summary>Listener that is called when this popup window is dismissed.</summary>
		/// <remarks>Listener that is called when this popup window is dismissed.</remarks>
		public interface OnDismissListener
		{
			/// <summary>Called when this popup window is dismissed.</summary>
			/// <remarks>Called when this popup window is dismissed.</remarks>
			void onDismiss();
		}

		private void unregisterForScrollChanged()
		{
			java.lang.@ref.WeakReference<android.view.View> anchorRef = mAnchor;
			android.view.View anchor = null;
			if (anchorRef != null)
			{
				anchor = anchorRef.get();
			}
			if (anchor != null)
			{
				android.view.ViewTreeObserver vto = anchor.getViewTreeObserver();
				vto.removeOnScrollChangedListener(mOnScrollChangedListener);
			}
			mAnchor = null;
		}

		private void registerForScrollChanged(android.view.View anchor, int xoff, int yoff
			)
		{
			unregisterForScrollChanged();
			mAnchor = new java.lang.@ref.WeakReference<android.view.View>(anchor);
			android.view.ViewTreeObserver vto = anchor.getViewTreeObserver();
			if (vto != null)
			{
				vto.addOnScrollChangedListener(mOnScrollChangedListener);
			}
			mAnchorXoff = xoff;
			mAnchorYoff = yoff;
		}

		private class PopupViewContainer : android.widget.FrameLayout
		{
			internal const string TAG = "PopupWindow.PopupViewContainer";

			public PopupViewContainer(PopupWindow _enclosing, android.content.Context context
				) : base(context)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override int[] onCreateDrawableState(int extraSpace)
			{
				if (this._enclosing.mAboveAnchor)
				{
					// 1 more needed for the above anchor state
					int[] drawableState = base.onCreateDrawableState(extraSpace + 1);
					android.view.View.mergeDrawableStates(drawableState, android.widget.PopupWindow.ABOVE_ANCHOR_STATE_SET
						);
					return drawableState;
				}
				else
				{
					return base.onCreateDrawableState(extraSpace);
				}
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool dispatchKeyEvent(android.view.KeyEvent @event)
			{
				if (@event.getKeyCode() == android.view.KeyEvent.KEYCODE_BACK)
				{
					if (this.getKeyDispatcherState() == null)
					{
						return base.dispatchKeyEvent(@event);
					}
					if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
						() == 0)
					{
						android.view.KeyEvent.DispatcherState state = this.getKeyDispatcherState();
						if (state != null)
						{
							state.startTracking(@event, this);
						}
						return true;
					}
					else
					{
						if (@event.getAction() == android.view.KeyEvent.ACTION_UP)
						{
							android.view.KeyEvent.DispatcherState state = this.getKeyDispatcherState();
							if (state != null && state.isTracking(@event) && !@event.isCanceled())
							{
								this._enclosing.dismiss();
								return true;
							}
						}
					}
					return base.dispatchKeyEvent(@event);
				}
				else
				{
					return base.dispatchKeyEvent(@event);
				}
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool dispatchTouchEvent(android.view.MotionEvent ev)
			{
				if (this._enclosing.mTouchInterceptor != null && this._enclosing.mTouchInterceptor
					.onTouch(this, ev))
				{
					return true;
				}
				return base.dispatchTouchEvent(ev);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool onTouchEvent(android.view.MotionEvent @event)
			{
				int x = (int)@event.getX();
				int y = (int)@event.getY();
				if ((@event.getAction() == android.view.MotionEvent.ACTION_DOWN) && ((x < 0) || (
					x >= this.getWidth()) || (y < 0) || (y >= this.getHeight())))
				{
					this._enclosing.dismiss();
					return true;
				}
				else
				{
					if (@event.getAction() == android.view.MotionEvent.ACTION_OUTSIDE)
					{
						this._enclosing.dismiss();
						return true;
					}
					else
					{
						return base.onTouchEvent(@event);
					}
				}
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override void sendAccessibilityEvent(int eventType)
			{
				// clinets are interested in the content not the container, make it event source
				if (this._enclosing.mContentView != null)
				{
					this._enclosing.mContentView.sendAccessibilityEvent(eventType);
				}
				else
				{
					base.sendAccessibilityEvent(eventType);
				}
			}

			private readonly PopupWindow _enclosing;
		}
	}
}
