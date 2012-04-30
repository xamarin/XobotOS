using Sharpen;

namespace android.view
{
	/// <summary>
	/// A view tree observer is used to register listeners that can be notified of global
	/// changes in the view tree.
	/// </summary>
	/// <remarks>
	/// A view tree observer is used to register listeners that can be notified of global
	/// changes in the view tree. Such global events include, but are not limited to,
	/// layout of the whole tree, beginning of the drawing pass, touch mode change....
	/// A ViewTreeObserver should never be instantiated by applications as it is provided
	/// by the views hierarchy. Refer to
	/// <see cref="View.getViewTreeObserver()">View.getViewTreeObserver()</see>
	/// for more information.
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed class ViewTreeObserver
	{
		private java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnGlobalFocusChangeListener
			> mOnGlobalFocusListeners;

		private java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnGlobalLayoutListener
			> mOnGlobalLayoutListeners;

		private java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnTouchModeChangeListener
			> mOnTouchModeChangeListeners;

		private java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnComputeInternalInsetsListener
			> mOnComputeInternalInsetsListeners;

		private java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnScrollChangedListener
			> mOnScrollChangedListeners;

		private java.util.ArrayList<android.view.ViewTreeObserver.OnPreDrawListener> mOnPreDrawListeners;

		private bool mAlive = true;

		/// <summary>
		/// Interface definition for a callback to be invoked when the focus state within
		/// the view tree changes.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the focus state within
		/// the view tree changes.
		/// </remarks>
		public interface OnGlobalFocusChangeListener
		{
			/// <summary>Callback method to be invoked when the focus changes in the view tree.</summary>
			/// <remarks>
			/// Callback method to be invoked when the focus changes in the view tree. When
			/// the view tree transitions from touch mode to non-touch mode, oldFocus is null.
			/// When the view tree transitions from non-touch mode to touch mode, newFocus is
			/// null. When focus changes in non-touch mode (without transition from or to
			/// touch mode) either oldFocus or newFocus can be null.
			/// </remarks>
			/// <param name="oldFocus">The previously focused view, if any.</param>
			/// <param name="newFocus">The newly focused View, if any.</param>
			void onGlobalFocusChanged(android.view.View oldFocus, android.view.View newFocus);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the global layout state
		/// or the visibility of views within the view tree changes.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the global layout state
		/// or the visibility of views within the view tree changes.
		/// </remarks>
		public interface OnGlobalLayoutListener
		{
			/// <summary>
			/// Callback method to be invoked when the global layout state or the visibility of views
			/// within the view tree changes
			/// </summary>
			void onGlobalLayout();
		}

		/// <summary>Interface definition for a callback to be invoked when the view tree is about to be drawn.
		/// 	</summary>
		/// <remarks>Interface definition for a callback to be invoked when the view tree is about to be drawn.
		/// 	</remarks>
		public interface OnPreDrawListener
		{
			/// <summary>Callback method to be invoked when the view tree is about to be drawn.</summary>
			/// <remarks>
			/// Callback method to be invoked when the view tree is about to be drawn. At this point, all
			/// views in the tree have been measured and given a frame. Clients can use this to adjust
			/// their scroll bounds or even to request a new layout before drawing occurs.
			/// </remarks>
			/// <returns>Return true to proceed with the current drawing pass, or false to cancel.
			/// 	</returns>
			/// <seealso cref="View.onMeasure(int, int)">View.onMeasure(int, int)</seealso>
			/// <seealso cref="View.onLayout(bool, int, int, int, int)">View.onLayout(bool, int, int, int, int)
			/// 	</seealso>
			/// <seealso cref="View.onDraw(android.graphics.Canvas)">View.onDraw(android.graphics.Canvas)
			/// 	</seealso>
			bool onPreDraw();
		}

		/// <summary>Interface definition for a callback to be invoked when the touch mode changes.
		/// 	</summary>
		/// <remarks>Interface definition for a callback to be invoked when the touch mode changes.
		/// 	</remarks>
		public interface OnTouchModeChangeListener
		{
			/// <summary>Callback method to be invoked when the touch mode changes.</summary>
			/// <remarks>Callback method to be invoked when the touch mode changes.</remarks>
			/// <param name="isInTouchMode">True if the view hierarchy is now in touch mode, false  otherwise.
			/// 	</param>
			void onTouchModeChanged(bool isInTouchMode);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when
		/// something in the view tree has been scrolled.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when
		/// something in the view tree has been scrolled.
		/// </remarks>
		public interface OnScrollChangedListener
		{
			/// <summary>
			/// Callback method to be invoked when something in the view tree
			/// has been scrolled.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when something in the view tree
			/// has been scrolled.
			/// </remarks>
			void onScrollChanged();
		}

		/// <summary>Parameters used with OnComputeInternalInsetsListener.</summary>
		/// <remarks>
		/// Parameters used with OnComputeInternalInsetsListener.
		/// We are not yet ready to commit to this API and support it, so
		/// </remarks>
		/// <hide></hide>
		public sealed class InternalInsetsInfo
		{
			/// <summary>
			/// Offsets from the frame of the window at which the content of
			/// windows behind it should be placed.
			/// </summary>
			/// <remarks>
			/// Offsets from the frame of the window at which the content of
			/// windows behind it should be placed.
			/// </remarks>
			public readonly android.graphics.Rect contentInsets = new android.graphics.Rect();

			/// <summary>
			/// Offsets from the frame of the window at which windows behind it
			/// are visible.
			/// </summary>
			/// <remarks>
			/// Offsets from the frame of the window at which windows behind it
			/// are visible.
			/// </remarks>
			public readonly android.graphics.Rect visibleInsets = new android.graphics.Rect();

			/// <summary>Touchable region defined relative to the origin of the frame of the window.
			/// 	</summary>
			/// <remarks>
			/// Touchable region defined relative to the origin of the frame of the window.
			/// Only used when
			/// <see cref="setTouchableInsets(int)">setTouchableInsets(int)</see>
			/// is called with
			/// the option
			/// <see cref="TOUCHABLE_INSETS_REGION">TOUCHABLE_INSETS_REGION</see>
			/// .
			/// </remarks>
			public readonly android.graphics.Region touchableRegion = new android.graphics.Region
				();

			/// <summary>
			/// Option for
			/// <see cref="setTouchableInsets(int)">setTouchableInsets(int)</see>
			/// : the entire window frame
			/// can be touched.
			/// </summary>
			public const int TOUCHABLE_INSETS_FRAME = 0;

			/// <summary>
			/// Option for
			/// <see cref="setTouchableInsets(int)">setTouchableInsets(int)</see>
			/// : the area inside of
			/// the content insets can be touched.
			/// </summary>
			public const int TOUCHABLE_INSETS_CONTENT = 1;

			/// <summary>
			/// Option for
			/// <see cref="setTouchableInsets(int)">setTouchableInsets(int)</see>
			/// : the area inside of
			/// the visible insets can be touched.
			/// </summary>
			public const int TOUCHABLE_INSETS_VISIBLE = 2;

			/// <summary>
			/// Option for
			/// <see cref="setTouchableInsets(int)">setTouchableInsets(int)</see>
			/// : the area inside of
			/// the provided touchable region in
			/// <see cref="touchableRegion">touchableRegion</see>
			/// can be touched.
			/// </summary>
			public const int TOUCHABLE_INSETS_REGION = 3;

			/// <summary>
			/// Set which parts of the window can be touched: either
			/// <see cref="TOUCHABLE_INSETS_FRAME">TOUCHABLE_INSETS_FRAME</see>
			/// ,
			/// <see cref="TOUCHABLE_INSETS_CONTENT">TOUCHABLE_INSETS_CONTENT</see>
			/// ,
			/// <see cref="TOUCHABLE_INSETS_VISIBLE">TOUCHABLE_INSETS_VISIBLE</see>
			/// , or
			/// <see cref="TOUCHABLE_INSETS_REGION">TOUCHABLE_INSETS_REGION</see>
			/// .
			/// </summary>
			public void setTouchableInsets(int val)
			{
				mTouchableInsets = val;
			}

			public int getTouchableInsets()
			{
				return mTouchableInsets;
			}

			internal int mTouchableInsets;

			internal void reset()
			{
				contentInsets.setEmpty();
				visibleInsets.setEmpty();
				touchableRegion.setEmpty();
				mTouchableInsets = TOUCHABLE_INSETS_FRAME;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object o)
			{
				try
				{
					if (o == null)
					{
						return false;
					}
					android.view.ViewTreeObserver.InternalInsetsInfo other = (android.view.ViewTreeObserver
						.InternalInsetsInfo)o;
					if (mTouchableInsets != other.mTouchableInsets)
					{
						return false;
					}
					if (!contentInsets.Equals(other.contentInsets))
					{
						return false;
					}
					if (!visibleInsets.Equals(other.visibleInsets))
					{
						return false;
					}
					return touchableRegion.Equals(other.touchableRegion);
				}
				catch (System.InvalidCastException)
				{
					return false;
				}
			}

			internal void set(android.view.ViewTreeObserver.InternalInsetsInfo other)
			{
				contentInsets.set(other.contentInsets);
				visibleInsets.set(other.visibleInsets);
				touchableRegion.set(other.touchableRegion);
				mTouchableInsets = other.mTouchableInsets;
			}
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when layout has
		/// completed and the client can compute its interior insets.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when layout has
		/// completed and the client can compute its interior insets.
		/// We are not yet ready to commit to this API and support it, so
		/// </remarks>
		/// <hide></hide>
		public interface OnComputeInternalInsetsListener
		{
			/// <summary>
			/// Callback method to be invoked when layout has completed and the
			/// client can compute its interior insets.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when layout has completed and the
			/// client can compute its interior insets.
			/// </remarks>
			/// <param name="inoutInfo">
			/// Should be filled in by the implementation with
			/// the information about the insets of the window.  This is called
			/// with whatever values the previous OnComputeInternalInsetsListener
			/// returned, if there are multiple such listeners in the window.
			/// </param>
			void onComputeInternalInsets(android.view.ViewTreeObserver.InternalInsetsInfo inoutInfo
				);
		}

		/// <summary>Creates a new ViewTreeObserver.</summary>
		/// <remarks>Creates a new ViewTreeObserver. This constructor should not be called</remarks>
		internal ViewTreeObserver()
		{
		}

		/// <summary>
		/// Merges all the listeners registered on the specified observer with the listeners
		/// registered on this object.
		/// </summary>
		/// <remarks>
		/// Merges all the listeners registered on the specified observer with the listeners
		/// registered on this object. After this method is invoked, the specified observer
		/// will return false in
		/// <see cref="isAlive()">isAlive()</see>
		/// and should not be used anymore.
		/// </remarks>
		/// <param name="observer">The ViewTreeObserver whose listeners must be added to this observer
		/// 	</param>
		internal void merge(android.view.ViewTreeObserver observer)
		{
			if (observer.mOnGlobalFocusListeners != null)
			{
				if (mOnGlobalFocusListeners != null)
				{
					mOnGlobalFocusListeners.addAll(observer.mOnGlobalFocusListeners);
				}
				else
				{
					mOnGlobalFocusListeners = observer.mOnGlobalFocusListeners;
				}
			}
			if (observer.mOnGlobalLayoutListeners != null)
			{
				if (mOnGlobalLayoutListeners != null)
				{
					mOnGlobalLayoutListeners.addAll(observer.mOnGlobalLayoutListeners);
				}
				else
				{
					mOnGlobalLayoutListeners = observer.mOnGlobalLayoutListeners;
				}
			}
			if (observer.mOnPreDrawListeners != null)
			{
				if (mOnPreDrawListeners != null)
				{
					mOnPreDrawListeners.addAll(observer.mOnPreDrawListeners);
				}
				else
				{
					mOnPreDrawListeners = observer.mOnPreDrawListeners;
				}
			}
			if (observer.mOnTouchModeChangeListeners != null)
			{
				if (mOnTouchModeChangeListeners != null)
				{
					mOnTouchModeChangeListeners.addAll(observer.mOnTouchModeChangeListeners);
				}
				else
				{
					mOnTouchModeChangeListeners = observer.mOnTouchModeChangeListeners;
				}
			}
			if (observer.mOnComputeInternalInsetsListeners != null)
			{
				if (mOnComputeInternalInsetsListeners != null)
				{
					mOnComputeInternalInsetsListeners.addAll(observer.mOnComputeInternalInsetsListeners
						);
				}
				else
				{
					mOnComputeInternalInsetsListeners = observer.mOnComputeInternalInsetsListeners;
				}
			}
			observer.kill();
		}

		/// <summary>Register a callback to be invoked when the focus state within the view tree changes.
		/// 	</summary>
		/// <remarks>Register a callback to be invoked when the focus state within the view tree changes.
		/// 	</remarks>
		/// <param name="listener">The callback to add</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		public void addOnGlobalFocusChangeListener(android.view.ViewTreeObserver.OnGlobalFocusChangeListener
			 listener)
		{
			checkIsAlive();
			if (mOnGlobalFocusListeners == null)
			{
				mOnGlobalFocusListeners = new java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver
					.OnGlobalFocusChangeListener>();
			}
			mOnGlobalFocusListeners.add(listener);
		}

		/// <summary>Remove a previously installed focus change callback.</summary>
		/// <remarks>Remove a previously installed focus change callback.</remarks>
		/// <param name="victim">The callback to remove</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		/// <seealso cref="addOnGlobalFocusChangeListener(OnGlobalFocusChangeListener)">addOnGlobalFocusChangeListener(OnGlobalFocusChangeListener)
		/// 	</seealso>
		public void removeOnGlobalFocusChangeListener(android.view.ViewTreeObserver.OnGlobalFocusChangeListener
			 victim)
		{
			checkIsAlive();
			if (mOnGlobalFocusListeners == null)
			{
				return;
			}
			mOnGlobalFocusListeners.remove(victim);
		}

		/// <summary>
		/// Register a callback to be invoked when the global layout state or the visibility of views
		/// within the view tree changes
		/// </summary>
		/// <param name="listener">The callback to add</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		public void addOnGlobalLayoutListener(android.view.ViewTreeObserver.OnGlobalLayoutListener
			 listener)
		{
			checkIsAlive();
			if (mOnGlobalLayoutListeners == null)
			{
				mOnGlobalLayoutListeners = new java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver
					.OnGlobalLayoutListener>();
			}
			mOnGlobalLayoutListeners.add(listener);
		}

		/// <summary>Remove a previously installed global layout callback</summary>
		/// <param name="victim">The callback to remove</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		/// <seealso cref="addOnGlobalLayoutListener(OnGlobalLayoutListener)">addOnGlobalLayoutListener(OnGlobalLayoutListener)
		/// 	</seealso>
		public void removeGlobalOnLayoutListener(android.view.ViewTreeObserver.OnGlobalLayoutListener
			 victim)
		{
			checkIsAlive();
			if (mOnGlobalLayoutListeners == null)
			{
				return;
			}
			mOnGlobalLayoutListeners.remove(victim);
		}

		/// <summary>Register a callback to be invoked when the view tree is about to be drawn
		/// 	</summary>
		/// <param name="listener">The callback to add</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		public void addOnPreDrawListener(android.view.ViewTreeObserver.OnPreDrawListener 
			listener)
		{
			checkIsAlive();
			if (mOnPreDrawListeners == null)
			{
				mOnPreDrawListeners = new java.util.ArrayList<android.view.ViewTreeObserver.OnPreDrawListener
					>();
			}
			mOnPreDrawListeners.add(listener);
		}

		/// <summary>Remove a previously installed pre-draw callback</summary>
		/// <param name="victim">The callback to remove</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		/// <seealso cref="addOnPreDrawListener(OnPreDrawListener)">addOnPreDrawListener(OnPreDrawListener)
		/// 	</seealso>
		public void removeOnPreDrawListener(android.view.ViewTreeObserver.OnPreDrawListener
			 victim)
		{
			checkIsAlive();
			if (mOnPreDrawListeners == null)
			{
				return;
			}
			mOnPreDrawListeners.remove(victim);
		}

		/// <summary>Register a callback to be invoked when a view has been scrolled.</summary>
		/// <remarks>Register a callback to be invoked when a view has been scrolled.</remarks>
		/// <param name="listener">The callback to add</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		public void addOnScrollChangedListener(android.view.ViewTreeObserver.OnScrollChangedListener
			 listener)
		{
			checkIsAlive();
			if (mOnScrollChangedListeners == null)
			{
				mOnScrollChangedListeners = new java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver
					.OnScrollChangedListener>();
			}
			mOnScrollChangedListeners.add(listener);
		}

		/// <summary>Remove a previously installed scroll-changed callback</summary>
		/// <param name="victim">The callback to remove</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		/// <seealso cref="addOnScrollChangedListener(OnScrollChangedListener)">addOnScrollChangedListener(OnScrollChangedListener)
		/// 	</seealso>
		public void removeOnScrollChangedListener(android.view.ViewTreeObserver.OnScrollChangedListener
			 victim)
		{
			checkIsAlive();
			if (mOnScrollChangedListeners == null)
			{
				return;
			}
			mOnScrollChangedListeners.remove(victim);
		}

		/// <summary>Register a callback to be invoked when the invoked when the touch mode changes.
		/// 	</summary>
		/// <remarks>Register a callback to be invoked when the invoked when the touch mode changes.
		/// 	</remarks>
		/// <param name="listener">The callback to add</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		public void addOnTouchModeChangeListener(android.view.ViewTreeObserver.OnTouchModeChangeListener
			 listener)
		{
			checkIsAlive();
			if (mOnTouchModeChangeListeners == null)
			{
				mOnTouchModeChangeListeners = new java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver
					.OnTouchModeChangeListener>();
			}
			mOnTouchModeChangeListeners.add(listener);
		}

		/// <summary>Remove a previously installed touch mode change callback</summary>
		/// <param name="victim">The callback to remove</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		/// <seealso cref="addOnTouchModeChangeListener(OnTouchModeChangeListener)">addOnTouchModeChangeListener(OnTouchModeChangeListener)
		/// 	</seealso>
		public void removeOnTouchModeChangeListener(android.view.ViewTreeObserver.OnTouchModeChangeListener
			 victim)
		{
			checkIsAlive();
			if (mOnTouchModeChangeListeners == null)
			{
				return;
			}
			mOnTouchModeChangeListeners.remove(victim);
		}

		/// <summary>
		/// Register a callback to be invoked when the invoked when it is time to
		/// compute the window's internal insets.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when the invoked when it is time to
		/// compute the window's internal insets.
		/// </remarks>
		/// <param name="listener">The callback to add</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// We are not yet ready to commit to this API and support it, so
		/// </exception>
		/// <hide></hide>
		public void addOnComputeInternalInsetsListener(android.view.ViewTreeObserver.OnComputeInternalInsetsListener
			 listener)
		{
			checkIsAlive();
			if (mOnComputeInternalInsetsListeners == null)
			{
				mOnComputeInternalInsetsListeners = new java.util.concurrent.CopyOnWriteArrayList
					<android.view.ViewTreeObserver.OnComputeInternalInsetsListener>();
			}
			mOnComputeInternalInsetsListeners.add(listener);
		}

		/// <summary>Remove a previously installed internal insets computation callback</summary>
		/// <param name="victim">The callback to remove</param>
		/// <exception cref="System.InvalidOperationException">
		/// If
		/// <see cref="isAlive()">isAlive()</see>
		/// returns false
		/// </exception>
		/// <seealso cref="addOnComputeInternalInsetsListener(OnComputeInternalInsetsListener)
		/// 	">We are not yet ready to commit to this API and support it, so</seealso>
		/// <hide></hide>
		public void removeOnComputeInternalInsetsListener(android.view.ViewTreeObserver.OnComputeInternalInsetsListener
			 victim)
		{
			checkIsAlive();
			if (mOnComputeInternalInsetsListeners == null)
			{
				return;
			}
			mOnComputeInternalInsetsListeners.remove(victim);
		}

		private void checkIsAlive()
		{
			if (!mAlive)
			{
				throw new System.InvalidOperationException("This ViewTreeObserver is not alive, call "
					 + "getViewTreeObserver() again");
			}
		}

		/// <summary>Indicates whether this ViewTreeObserver is alive.</summary>
		/// <remarks>
		/// Indicates whether this ViewTreeObserver is alive. When an observer is not alive,
		/// any call to a method (except this one) will throw an exception.
		/// If an application keeps a long-lived reference to this ViewTreeObserver, it should
		/// always check for the result of this method before calling any other method.
		/// </remarks>
		/// <returns>True if this object is alive and be used, false otherwise.</returns>
		public bool isAlive()
		{
			return mAlive;
		}

		/// <summary>Marks this ViewTreeObserver as not alive.</summary>
		/// <remarks>
		/// Marks this ViewTreeObserver as not alive. After invoking this method, invoking
		/// any other method but
		/// <see cref="isAlive()">isAlive()</see>
		/// and
		/// <see cref="kill()">kill()</see>
		/// will throw an Exception.
		/// </remarks>
		/// <hide></hide>
		private void kill()
		{
			mAlive = false;
		}

		/// <summary>Notifies registered listeners that focus has changed.</summary>
		/// <remarks>Notifies registered listeners that focus has changed.</remarks>
		internal void dispatchOnGlobalFocusChange(android.view.View oldFocus, android.view.View
			 newFocus)
		{
			// NOTE: because of the use of CopyOnWriteArrayList, we *must* use an iterator to
			// perform the dispatching. The iterator is a safe guard against listeners that
			// could mutate the list by calling the various add/remove methods. This prevents
			// the array from being modified while we iterate it.
			java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnGlobalFocusChangeListener
				> listeners = mOnGlobalFocusListeners;
			if (listeners != null && listeners.size() > 0)
			{
				foreach (android.view.ViewTreeObserver.OnGlobalFocusChangeListener listener in Sharpen.IterableProxy.Create
					(listeners))
				{
					listener.onGlobalFocusChanged(oldFocus, newFocus);
				}
			}
		}

		/// <summary>Notifies registered listeners that a global layout happened.</summary>
		/// <remarks>
		/// Notifies registered listeners that a global layout happened. This can be called
		/// manually if you are forcing a layout on a View or a hierarchy of Views that are
		/// not attached to a Window or in the GONE state.
		/// </remarks>
		public void dispatchOnGlobalLayout()
		{
			// NOTE: because of the use of CopyOnWriteArrayList, we *must* use an iterator to
			// perform the dispatching. The iterator is a safe guard against listeners that
			// could mutate the list by calling the various add/remove methods. This prevents
			// the array from being modified while we iterate it.
			java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnGlobalLayoutListener
				> listeners = mOnGlobalLayoutListeners;
			if (listeners != null && listeners.size() > 0)
			{
				foreach (android.view.ViewTreeObserver.OnGlobalLayoutListener listener in Sharpen.IterableProxy.Create
					(listeners))
				{
					listener.onGlobalLayout();
				}
			}
		}

		/// <summary>Notifies registered listeners that the drawing pass is about to start.</summary>
		/// <remarks>
		/// Notifies registered listeners that the drawing pass is about to start. If a
		/// listener returns true, then the drawing pass is canceled and rescheduled. This can
		/// be called manually if you are forcing the drawing on a View or a hierarchy of Views
		/// that are not attached to a Window or in the GONE state.
		/// </remarks>
		/// <returns>True if the current draw should be canceled and resceduled, false otherwise.
		/// 	</returns>
		public bool dispatchOnPreDraw()
		{
			// NOTE: we *must* clone the listener list to perform the dispatching.
			// The clone is a safe guard against listeners that
			// could mutate the list by calling the various add/remove methods. This prevents
			// the array from being modified while we process it.
			bool cancelDraw = false;
			if (mOnPreDrawListeners != null && mOnPreDrawListeners.size() > 0)
			{
				java.util.ArrayList<android.view.ViewTreeObserver.OnPreDrawListener> listeners = 
					(java.util.ArrayList<android.view.ViewTreeObserver.OnPreDrawListener>)mOnPreDrawListeners
					.clone();
				int numListeners = listeners.size();
				{
					for (int i = 0; i < numListeners; ++i)
					{
						cancelDraw |= !(listeners.get(i).onPreDraw());
					}
				}
			}
			return cancelDraw;
		}

		/// <summary>Notifies registered listeners that the touch mode has changed.</summary>
		/// <remarks>Notifies registered listeners that the touch mode has changed.</remarks>
		/// <param name="inTouchMode">True if the touch mode is now enabled, false otherwise.
		/// 	</param>
		internal void dispatchOnTouchModeChanged(bool inTouchMode)
		{
			java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnTouchModeChangeListener
				> listeners = mOnTouchModeChangeListeners;
			if (listeners != null && listeners.size() > 0)
			{
				foreach (android.view.ViewTreeObserver.OnTouchModeChangeListener listener in Sharpen.IterableProxy.Create
					(listeners))
				{
					listener.onTouchModeChanged(inTouchMode);
				}
			}
		}

		/// <summary>Notifies registered listeners that something has scrolled.</summary>
		/// <remarks>Notifies registered listeners that something has scrolled.</remarks>
		internal void dispatchOnScrollChanged()
		{
			// NOTE: because of the use of CopyOnWriteArrayList, we *must* use an iterator to
			// perform the dispatching. The iterator is a safe guard against listeners that
			// could mutate the list by calling the various add/remove methods. This prevents
			// the array from being modified while we iterate it.
			java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnScrollChangedListener
				> listeners = mOnScrollChangedListeners;
			if (listeners != null && listeners.size() > 0)
			{
				foreach (android.view.ViewTreeObserver.OnScrollChangedListener listener in Sharpen.IterableProxy.Create
					(listeners))
				{
					listener.onScrollChanged();
				}
			}
		}

		/// <summary>Returns whether there are listeners for computing internal insets.</summary>
		/// <remarks>Returns whether there are listeners for computing internal insets.</remarks>
		internal bool hasComputeInternalInsetsListeners()
		{
			java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnComputeInternalInsetsListener
				> listeners = mOnComputeInternalInsetsListeners;
			return (listeners != null && listeners.size() > 0);
		}

		/// <summary>Calls all listeners to compute the current insets.</summary>
		/// <remarks>Calls all listeners to compute the current insets.</remarks>
		internal void dispatchOnComputeInternalInsets(android.view.ViewTreeObserver.InternalInsetsInfo
			 inoutInfo)
		{
			// NOTE: because of the use of CopyOnWriteArrayList, we *must* use an iterator to
			// perform the dispatching. The iterator is a safe guard against listeners that
			// could mutate the list by calling the various add/remove methods. This prevents
			// the array from being modified while we iterate it.
			java.util.concurrent.CopyOnWriteArrayList<android.view.ViewTreeObserver.OnComputeInternalInsetsListener
				> listeners = mOnComputeInternalInsetsListeners;
			if (listeners != null && listeners.size() > 0)
			{
				foreach (android.view.ViewTreeObserver.OnComputeInternalInsetsListener listener in 
					Sharpen.IterableProxy.Create(listeners))
				{
					listener.onComputeInternalInsets(inoutInfo);
				}
			}
		}
	}
}
