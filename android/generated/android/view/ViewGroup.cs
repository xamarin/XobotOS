using Sharpen;

namespace android.view
{
	/// <summary>
	/// <p>
	/// A <code>ViewGroup</code> is a special view that can contain other views
	/// (called children.) The view group is the base class for layouts and views
	/// containers.
	/// </summary>
	/// <remarks>
	/// <p>
	/// A <code>ViewGroup</code> is a special view that can contain other views
	/// (called children.) The view group is the base class for layouts and views
	/// containers. This class also defines the
	/// <see cref="LayoutParams">LayoutParams</see>
	/// class which serves as the base
	/// class for layouts parameters.
	/// </p>
	/// <p>
	/// Also see
	/// <see cref="LayoutParams">LayoutParams</see>
	/// for layout attributes.
	/// </p>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about creating user interface layouts, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/declaring-layout.html"&gt;XML Layouts</a> developer
	/// guide.</p></div>
	/// </remarks>
	/// <attr>ref android.R.styleable#ViewGroup_clipChildren</attr>
	/// <attr>ref android.R.styleable#ViewGroup_clipToPadding</attr>
	/// <attr>ref android.R.styleable#ViewGroup_layoutAnimation</attr>
	/// <attr>ref android.R.styleable#ViewGroup_animationCache</attr>
	/// <attr>ref android.R.styleable#ViewGroup_persistentDrawingCache</attr>
	/// <attr>ref android.R.styleable#ViewGroup_alwaysDrawnWithCache</attr>
	/// <attr>ref android.R.styleable#ViewGroup_addStatesFromChildren</attr>
	/// <attr>ref android.R.styleable#ViewGroup_descendantFocusability</attr>
	/// <attr>ref android.R.styleable#ViewGroup_animateLayoutChanges</attr>
	[Sharpen.Sharpened]
	public abstract class ViewGroup : android.view.View, android.view.ViewParent, android.view.ViewManager
	{
		internal const bool DBG = false;

		/// <summary>
		/// Views which have been hidden or removed which need to be animated on
		/// their way out.
		/// </summary>
		/// <remarks>
		/// Views which have been hidden or removed which need to be animated on
		/// their way out.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal java.util.ArrayList<android.view.View> mDisappearingChildren;

		/// <summary>
		/// Listener used to propagate events indicating when children are added
		/// and/or removed from a view group.
		/// </summary>
		/// <remarks>
		/// Listener used to propagate events indicating when children are added
		/// and/or removed from a view group.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.view.ViewGroup.OnHierarchyChangeListener mOnHierarchyChangeListener;

		private android.view.View mFocused;

		/// <summary>
		/// A Transformation used when drawing children, to
		/// apply on the child being drawn.
		/// </summary>
		/// <remarks>
		/// A Transformation used when drawing children, to
		/// apply on the child being drawn.
		/// </remarks>
		private readonly android.view.animation.Transformation mChildTransformation = new 
			android.view.animation.Transformation();

		/// <summary>Used to track the current invalidation region.</summary>
		/// <remarks>Used to track the current invalidation region.</remarks>
		private android.graphics.RectF mInvalidateRegion;

		/// <summary>
		/// A Transformation used to calculate a correct
		/// invalidation area when the application is autoscaled.
		/// </summary>
		/// <remarks>
		/// A Transformation used to calculate a correct
		/// invalidation area when the application is autoscaled.
		/// </remarks>
		private android.view.animation.Transformation mInvalidationTransformation;

		private android.view.View mCurrentDragView;

		private android.view.DragEvent mCurrentDrag;

		private java.util.HashSet<android.view.View> mDragNotifiedChildren;

		private bool mChildAcceptsDrag;

		private readonly android.graphics.PointF mLocalPoint = new android.graphics.PointF
			();

		private android.view.animation.LayoutAnimationController mLayoutAnimationController;

		private android.view.animation.Animation.AnimationListener mAnimationListener;

		private android.view.ViewGroup.TouchTarget mFirstTouchTarget;

		private long mLastTouchDownTime;

		private int mLastTouchDownIndex = -1;

		private float mLastTouchDownX;

		private float mLastTouchDownY;

		private android.view.ViewGroup.HoverTarget mFirstHoverTarget;

		private bool mHoveredSelf;

		/// <summary>Internal flags.</summary>
		/// <remarks>
		/// Internal flags.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal int mGroupFlags;

		internal const int FLAG_CLIP_CHILDREN = unchecked((int)(0x1));

		internal const int FLAG_CLIP_TO_PADDING = unchecked((int)(0x2));

		internal const int FLAG_INVALIDATE_REQUIRED = unchecked((int)(0x4));

		internal const int FLAG_RUN_ANIMATION = unchecked((int)(0x8));

		internal const int FLAG_ANIMATION_DONE = unchecked((int)(0x10));

		internal const int FLAG_PADDING_NOT_NULL = unchecked((int)(0x20));

		internal const int FLAG_ANIMATION_CACHE = unchecked((int)(0x40));

		internal const int FLAG_OPTIMIZE_INVALIDATE = unchecked((int)(0x80));

		internal const int FLAG_CLEAR_TRANSFORMATION = unchecked((int)(0x100));

		internal const int FLAG_NOTIFY_ANIMATION_LISTENER = unchecked((int)(0x200));

		/// <summary>
		/// When set, the drawing method will call
		/// <see cref="getChildDrawingOrder(int, int)">getChildDrawingOrder(int, int)</see>
		/// to get the index of the child to draw for that iteration.
		/// </summary>
		/// <hide></hide>
		internal const int FLAG_USE_CHILD_DRAWING_ORDER = unchecked((int)(0x400));

		/// <summary>
		/// When set, this ViewGroup supports static transformations on children; this causes
		/// <see cref="getChildStaticTransformation(View, android.view.animation.Transformation)
		/// 	">getChildStaticTransformation(View, android.view.animation.Transformation)</see>
		/// to be
		/// invoked when a child is drawn.
		/// Any subclass overriding
		/// <see cref="getChildStaticTransformation(View, android.view.animation.Transformation)
		/// 	">getChildStaticTransformation(View, android.view.animation.Transformation)</see>
		/// should
		/// set this flags in
		/// <see cref="mGroupFlags">mGroupFlags</see>
		/// .
		/// <hide></hide>
		/// </summary>
		internal const int FLAG_SUPPORT_STATIC_TRANSFORMATIONS = unchecked((int)(0x800));

		internal const int FLAG_ALPHA_LOWER_THAN_ONE = unchecked((int)(0x1000));

		/// <summary>
		/// When set, this ViewGroup's drawable states also include those
		/// of its children.
		/// </summary>
		/// <remarks>
		/// When set, this ViewGroup's drawable states also include those
		/// of its children.
		/// </remarks>
		internal const int FLAG_ADD_STATES_FROM_CHILDREN = unchecked((int)(0x2000));

		/// <summary>When set, this ViewGroup tries to always draw its children using their drawing cache.
		/// 	</summary>
		/// <remarks>When set, this ViewGroup tries to always draw its children using their drawing cache.
		/// 	</remarks>
		internal const int FLAG_ALWAYS_DRAWN_WITH_CACHE = unchecked((int)(0x4000));

		/// <summary>
		/// When set, and if FLAG_ALWAYS_DRAWN_WITH_CACHE is not set, this ViewGroup will try to
		/// draw its children with their drawing cache.
		/// </summary>
		/// <remarks>
		/// When set, and if FLAG_ALWAYS_DRAWN_WITH_CACHE is not set, this ViewGroup will try to
		/// draw its children with their drawing cache.
		/// </remarks>
		internal const int FLAG_CHILDREN_DRAWN_WITH_CACHE = unchecked((int)(0x8000));

		/// <summary>
		/// When set, this group will go through its list of children to notify them of
		/// any drawable state change.
		/// </summary>
		/// <remarks>
		/// When set, this group will go through its list of children to notify them of
		/// any drawable state change.
		/// </remarks>
		internal const int FLAG_NOTIFY_CHILDREN_ON_DRAWABLE_STATE_CHANGE = unchecked((int
			)(0x10000));

		internal const int FLAG_MASK_FOCUSABILITY = unchecked((int)(0x60000));

		/// <summary>This view will get focus before any of its descendants.</summary>
		/// <remarks>This view will get focus before any of its descendants.</remarks>
		public const int FOCUS_BEFORE_DESCENDANTS = unchecked((int)(0x20000));

		/// <summary>This view will get focus only if none of its descendants want it.</summary>
		/// <remarks>This view will get focus only if none of its descendants want it.</remarks>
		public const int FOCUS_AFTER_DESCENDANTS = unchecked((int)(0x40000));

		/// <summary>
		/// This view will block any of its descendants from getting focus, even
		/// if they are focusable.
		/// </summary>
		/// <remarks>
		/// This view will block any of its descendants from getting focus, even
		/// if they are focusable.
		/// </remarks>
		public const int FOCUS_BLOCK_DESCENDANTS = unchecked((int)(0x60000));

		/// <summary>Used to map between enum in attrubutes and flag values.</summary>
		/// <remarks>Used to map between enum in attrubutes and flag values.</remarks>
		private static readonly int[] DESCENDANT_FOCUSABILITY_FLAGS = new int[] { FOCUS_BEFORE_DESCENDANTS
			, FOCUS_AFTER_DESCENDANTS, FOCUS_BLOCK_DESCENDANTS };

		/// <summary>When set, this ViewGroup should not intercept touch events.</summary>
		/// <remarks>
		/// When set, this ViewGroup should not intercept touch events.
		/// <hide></hide>
		/// </remarks>
		internal const int FLAG_DISALLOW_INTERCEPT = unchecked((int)(0x80000));

		/// <summary>When set, this ViewGroup will split MotionEvents to multiple child Views when appropriate.
		/// 	</summary>
		/// <remarks>When set, this ViewGroup will split MotionEvents to multiple child Views when appropriate.
		/// 	</remarks>
		internal const int FLAG_SPLIT_MOTION_EVENTS = unchecked((int)(0x200000));

		/// <summary>
		/// When set, this ViewGroup will not dispatch onAttachedToWindow calls
		/// to children when adding new views.
		/// </summary>
		/// <remarks>
		/// When set, this ViewGroup will not dispatch onAttachedToWindow calls
		/// to children when adding new views. This is used to prevent multiple
		/// onAttached calls when a ViewGroup adds children in its own onAttached method.
		/// </remarks>
		internal const int FLAG_PREVENT_DISPATCH_ATTACHED_TO_WINDOW = unchecked((int)(0x400000
			));

		/// <summary>Indicates which types of drawing caches are to be kept in memory.</summary>
		/// <remarks>
		/// Indicates which types of drawing caches are to be kept in memory.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal int mPersistentDrawingCache;

		/// <summary>Used to indicate that no drawing cache should be kept in memory.</summary>
		/// <remarks>Used to indicate that no drawing cache should be kept in memory.</remarks>
		public const int PERSISTENT_NO_CACHE = unchecked((int)(0x0));

		/// <summary>Used to indicate that the animation drawing cache should be kept in memory.
		/// 	</summary>
		/// <remarks>Used to indicate that the animation drawing cache should be kept in memory.
		/// 	</remarks>
		public const int PERSISTENT_ANIMATION_CACHE = unchecked((int)(0x1));

		/// <summary>Used to indicate that the scrolling drawing cache should be kept in memory.
		/// 	</summary>
		/// <remarks>Used to indicate that the scrolling drawing cache should be kept in memory.
		/// 	</remarks>
		public const int PERSISTENT_SCROLLING_CACHE = unchecked((int)(0x2));

		/// <summary>Used to indicate that all drawing caches should be kept in memory.</summary>
		/// <remarks>Used to indicate that all drawing caches should be kept in memory.</remarks>
		public const int PERSISTENT_ALL_CACHES = unchecked((int)(0x3));

		/// <summary>
		/// We clip to padding when FLAG_CLIP_TO_PADDING and FLAG_PADDING_NOT_NULL
		/// are set at the same time.
		/// </summary>
		/// <remarks>
		/// We clip to padding when FLAG_CLIP_TO_PADDING and FLAG_PADDING_NOT_NULL
		/// are set at the same time.
		/// </remarks>
		internal const int CLIP_TO_PADDING_MASK = FLAG_CLIP_TO_PADDING | FLAG_PADDING_NOT_NULL;

		internal const int CHILD_LEFT_INDEX = 0;

		internal const int CHILD_TOP_INDEX = 1;

		private android.view.View[] mChildren;

		private bool mLayoutSuppressed = false;

		private int mChildrenCount;

		internal const int ARRAY_INITIAL_CAPACITY = 12;

		internal const int ARRAY_CAPACITY_INCREMENT = 12;

		private readonly android.graphics.Paint mCachePaint = new android.graphics.Paint(
			);

		private android.animation.LayoutTransition mTransition;

		private java.util.ArrayList<android.view.View> mTransitioningViews;

		private java.util.ArrayList<android.view.View> mVisibilityChangingChildren;

		private bool mDrawLayers = true;

		public ViewGroup(android.content.Context context) : base(context)
		{
			mLayoutTransitionListener = new _TransitionListener_4892(this);
			// The view contained within this ViewGroup that has or contains focus.
			// View currently under an ongoing drag
			// Metadata about the ongoing drag
			// Does this group have a child that can accept the current drag payload?
			// Used during drag dispatch
			// Layout animation
			// First touch target in the linked list of touch targets.
			// For debugging only.  You can see these in hierarchyviewer.
			// First hover target in the linked list of hover targets.
			// The hover targets are children which have received ACTION_HOVER_ENTER.
			// They might not have actually handled the hover event, but we will
			// continue sending hover events to them as long as the pointer remains over
			// their bounds and the view group does not intercept hover.
			// True if the view group itself received a hover event.
			// It might not have actually handled the hover event.
			// When set, ViewGroup invalidates only the child's rectangle
			// Set by default
			// When set, ViewGroup excludes the padding area from the invalidate rectangle
			// Set by default
			// When set, dispatchDraw() will invoke invalidate(); this is set by drawChild() when
			// a child needs to be invalidated and FLAG_OPTIMIZE_INVALIDATE is set
			// When set, dispatchDraw() will run the layout animation and unset the flag
			// When set, there is either no layout animation on the ViewGroup or the layout
			// animation is over
			// Set by default
			// If set, this ViewGroup has padding; if unset there is no padding and we don't need
			// to clip it, even if FLAG_CLIP_TO_PADDING is set
			// When set, this ViewGroup caches its children in a Bitmap before starting a layout animation
			// Set by default
			// When set, this ViewGroup converts calls to invalidate(Rect) to invalidate() during a
			// layout animation; this avoid clobbering the hierarchy
			// Automatically set when the layout animation starts, depending on the animation's
			// characteristics
			// When set, the next call to drawChild() will clear mChildTransformation's matrix
			// When set, this ViewGroup invokes mAnimationListener.onAnimationEnd() and removes
			// the children's Bitmap caches if necessary
			// This flag is set when the layout animation is over (after FLAG_ANIMATION_DONE is set)
			// When the previous drawChild() invocation used an alpha value that was lower than
			// 1.0 and set it in mCachePaint
			// Index of the child's left position in the mLocation array
			// Index of the child's top position in the mLocation array
			// Child views of this ViewGroup
			// Number of valid children in the mChildren array, the rest should be null or not
			// considered as children
			// Used to draw cached views
			// Used to animate add/remove changes in layout
			// The set of views that are currently being transitioned. This list is used to track views
			// being removed that should not actually be removed from the parent yet because they are
			// being animated.
			// List of children changing visibility. This is used to potentially keep rendering
			// views during a transition when they otherwise would have become gone/invisible
			// Indicates whether this container will use its children layers to draw
			initViewGroup();
		}

		public ViewGroup(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			mLayoutTransitionListener = new _TransitionListener_4892(this);
			initViewGroup();
			initFromAttributes(context, attrs);
		}

		public ViewGroup(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			mLayoutTransitionListener = new _TransitionListener_4892(this);
			initViewGroup();
			initFromAttributes(context, attrs);
		}

		private void initViewGroup()
		{
			// ViewGroup doesn't draw by default
			setFlags(WILL_NOT_DRAW, DRAW_MASK);
			mGroupFlags |= FLAG_CLIP_CHILDREN;
			mGroupFlags |= FLAG_CLIP_TO_PADDING;
			mGroupFlags |= FLAG_ANIMATION_DONE;
			mGroupFlags |= FLAG_ANIMATION_CACHE;
			mGroupFlags |= FLAG_ALWAYS_DRAWN_WITH_CACHE;
			if (mContext.getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES
				.HONEYCOMB)
			{
				mGroupFlags |= FLAG_SPLIT_MOTION_EVENTS;
			}
			setDescendantFocusability(FOCUS_BEFORE_DESCENDANTS);
			mChildren = new android.view.View[ARRAY_INITIAL_CAPACITY];
			mChildrenCount = 0;
			mCachePaint.setDither(false);
			mPersistentDrawingCache = PERSISTENT_SCROLLING_CACHE;
		}

		private void initFromAttributes(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ViewGroup);
			int N = a.getIndexCount();
			{
				for (int i = 0; i < N; i++)
				{
					int attr = a.getIndex(i);
					switch (attr)
					{
						case android.@internal.R.styleable.ViewGroup_clipChildren:
						{
							setClipChildren(a.getBoolean(attr, true));
							break;
						}

						case android.@internal.R.styleable.ViewGroup_clipToPadding:
						{
							setClipToPadding(a.getBoolean(attr, true));
							break;
						}

						case android.@internal.R.styleable.ViewGroup_animationCache:
						{
							setAnimationCacheEnabled(a.getBoolean(attr, true));
							break;
						}

						case android.@internal.R.styleable.ViewGroup_persistentDrawingCache:
						{
							setPersistentDrawingCache(a.getInt(attr, PERSISTENT_SCROLLING_CACHE));
							break;
						}

						case android.@internal.R.styleable.ViewGroup_addStatesFromChildren:
						{
							setAddStatesFromChildren(a.getBoolean(attr, false));
							break;
						}

						case android.@internal.R.styleable.ViewGroup_alwaysDrawnWithCache:
						{
							setAlwaysDrawnWithCacheEnabled(a.getBoolean(attr, true));
							break;
						}

						case android.@internal.R.styleable.ViewGroup_layoutAnimation:
						{
							int id = a.getResourceId(attr, -1);
							if (id > 0)
							{
								setLayoutAnimation(android.view.animation.AnimationUtils.loadLayoutAnimation(mContext
									, id));
							}
							break;
						}

						case android.@internal.R.styleable.ViewGroup_descendantFocusability:
						{
							setDescendantFocusability(DESCENDANT_FOCUSABILITY_FLAGS[a.getInt(attr, 0)]);
							break;
						}

						case android.@internal.R.styleable.ViewGroup_splitMotionEvents:
						{
							setMotionEventSplittingEnabled(a.getBoolean(attr, false));
							break;
						}

						case android.@internal.R.styleable.ViewGroup_animateLayoutChanges:
						{
							bool animateLayoutChanges = a.getBoolean(attr, false);
							if (animateLayoutChanges)
							{
								setLayoutTransition(new android.animation.LayoutTransition());
							}
							break;
						}
					}
				}
			}
			a.recycle();
		}

		/// <summary>Gets the descendant focusability of this view group.</summary>
		/// <remarks>
		/// Gets the descendant focusability of this view group.  The descendant
		/// focusability defines the relationship between this view group and its
		/// descendants when looking for a view to take focus in
		/// <see cref="requestFocus(int, android.graphics.Rect)">requestFocus(int, android.graphics.Rect)
		/// 	</see>
		/// .
		/// </remarks>
		/// <returns>
		/// one of
		/// <see cref="FOCUS_BEFORE_DESCENDANTS">FOCUS_BEFORE_DESCENDANTS</see>
		/// ,
		/// <see cref="FOCUS_AFTER_DESCENDANTS">FOCUS_AFTER_DESCENDANTS</see>
		/// ,
		/// <see cref="FOCUS_BLOCK_DESCENDANTS">FOCUS_BLOCK_DESCENDANTS</see>
		/// .
		/// </returns>
		public virtual int getDescendantFocusability()
		{
			return mGroupFlags & FLAG_MASK_FOCUSABILITY;
		}

		/// <summary>Set the descendant focusability of this view group.</summary>
		/// <remarks>
		/// Set the descendant focusability of this view group. This defines the relationship
		/// between this view group and its descendants when looking for a view to
		/// take focus in
		/// <see cref="requestFocus(int, android.graphics.Rect)">requestFocus(int, android.graphics.Rect)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="focusability">
		/// one of
		/// <see cref="FOCUS_BEFORE_DESCENDANTS">FOCUS_BEFORE_DESCENDANTS</see>
		/// ,
		/// <see cref="FOCUS_AFTER_DESCENDANTS">FOCUS_AFTER_DESCENDANTS</see>
		/// ,
		/// <see cref="FOCUS_BLOCK_DESCENDANTS">FOCUS_BLOCK_DESCENDANTS</see>
		/// .
		/// </param>
		public virtual void setDescendantFocusability(int focusability)
		{
			switch (focusability)
			{
				case FOCUS_BEFORE_DESCENDANTS:
				case FOCUS_AFTER_DESCENDANTS:
				case FOCUS_BLOCK_DESCENDANTS:
				{
					break;
				}

				default:
				{
					throw new System.ArgumentException("must be one of FOCUS_BEFORE_DESCENDANTS, " + 
						"FOCUS_AFTER_DESCENDANTS, FOCUS_BLOCK_DESCENDANTS");
				}
			}
			mGroupFlags &= ~FLAG_MASK_FOCUSABILITY;
			mGroupFlags |= (focusability & FLAG_MASK_FOCUSABILITY);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override void handleFocusGainInternal(int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			if (mFocused != null)
			{
				mFocused.unFocus();
				mFocused = null;
			}
			base.handleFocusGainInternal(direction, previouslyFocusedRect);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void requestChildFocus(android.view.View child, android.view.View 
			focused)
		{
			if (getDescendantFocusability() == FOCUS_BLOCK_DESCENDANTS)
			{
				return;
			}
			// Unfocus us, if necessary
			base.unFocus();
			// We had a previous notion of who had focus. Clear it.
			if (mFocused != child)
			{
				if (mFocused != null)
				{
					mFocused.unFocus();
				}
				mFocused = child;
			}
			if (mParent != null)
			{
				mParent.requestChildFocus(this, focused);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void focusableViewAvailable(android.view.View v)
		{
			if (mParent != null && (getDescendantFocusability() != FOCUS_BLOCK_DESCENDANTS) &&
				 !(isFocused() && getDescendantFocusability() != FOCUS_AFTER_DESCENDANTS))
			{
				// shortcut: don't report a new focusable view if we block our descendants from
				// getting focus
				// shortcut: don't report a new focusable view if we already are focused
				// (and we don't prefer our descendants)
				//
				// note: knowing that mFocused is non-null is not a good enough reason
				// to break the traversal since in that case we'd actually have to find
				// the focused view and make sure it wasn't FOCUS_AFTER_DESCENDANTS and
				// an ancestor of v; this will get checked for at ViewAncestor
				mParent.focusableViewAvailable(v);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual bool showContextMenuForChild(android.view.View originalView)
		{
			return mParent != null && mParent.showContextMenuForChild(originalView);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual android.view.ActionMode startActionModeForChild(android.view.View 
			originalView, android.view.ActionMode.Callback callback)
		{
			return mParent != null ? mParent.startActionModeForChild(originalView, callback) : 
				null;
		}

		/// <summary>
		/// Find the nearest view in the specified direction that wants to take
		/// focus.
		/// </summary>
		/// <remarks>
		/// Find the nearest view in the specified direction that wants to take
		/// focus.
		/// </remarks>
		/// <param name="focused">The view that currently has focus</param>
		/// <param name="direction">
		/// One of FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, and
		/// FOCUS_RIGHT, or 0 for not applicable.
		/// </param>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual android.view.View focusSearch(android.view.View focused, int direction
			)
		{
			if (isRootNamespace())
			{
				// root namespace means we should consider ourselves the top of the
				// tree for focus searching; otherwise we could be focus searching
				// into other tabs.  see LocalActivityManager and TabHost for more info
				return android.view.FocusFinder.getInstance().findNextFocus(this, focused, direction
					);
			}
			else
			{
				if (mParent != null)
				{
					return mParent.focusSearch(focused, direction);
				}
			}
			return null;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual bool requestChildRectangleOnScreen(android.view.View child, android.graphics.Rect
			 rectangle, bool immediate)
		{
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual bool requestSendAccessibilityEvent(android.view.View child, android.view.accessibility.AccessibilityEvent
			 @event)
		{
			android.view.ViewParent parent = getParent();
			if (parent == null)
			{
				return false;
			}
			bool propagate = onRequestSendAccessibilityEvent(child, @event);
			//noinspection SimplifiableIfStatement
			if (!propagate)
			{
				return false;
			}
			return parent.requestSendAccessibilityEvent(this, @event);
		}

		/// <summary>
		/// Called when a child has requested sending an
		/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
		/// 	</see>
		/// and
		/// gives an opportunity to its parent to augment the event.
		/// <p>
		/// If an
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// has been specified via calling
		/// <see cref="View.setAccessibilityDelegate(AccessibilityDelegate)">View.setAccessibilityDelegate(AccessibilityDelegate)
		/// 	</see>
		/// its
		/// <see cref="AccessibilityDelegate.onRequestSendAccessibilityEvent(ViewGroup, View, android.view.accessibility.AccessibilityEvent)
		/// 	">AccessibilityDelegate.onRequestSendAccessibilityEvent(ViewGroup, View, android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// is responsible for handling this call.
		/// </p>
		/// </summary>
		/// <param name="child">The child which requests sending the event.</param>
		/// <param name="event">The event to be sent.</param>
		/// <returns>True if the event should be sent.</returns>
		/// <seealso cref="requestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	">requestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	</seealso>
		public virtual bool onRequestSendAccessibilityEvent(android.view.View child, android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (mAccessibilityDelegate != null)
			{
				return mAccessibilityDelegate.onRequestSendAccessibilityEvent(this, child, @event
					);
			}
			else
			{
				return onRequestSendAccessibilityEventInternal(child, @event);
			}
		}

		/// <seealso cref="onRequestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	">
		/// Note: Called from the default
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </seealso>
		internal virtual bool onRequestSendAccessibilityEventInternal(android.view.View child
			, android.view.accessibility.AccessibilityEvent @event)
		{
			return true;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchUnhandledMove(android.view.View focused, int direction
			)
		{
			return mFocused != null && mFocused.dispatchUnhandledMove(focused, direction);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void clearChildFocus(android.view.View child)
		{
			mFocused = null;
			if (mParent != null)
			{
				mParent.clearChildFocus(this);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void clearFocus()
		{
			base.clearFocus();
			// clear any child focus if it exists
			if (mFocused != null)
			{
				mFocused.clearFocus();
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override void unFocus()
		{
			base.unFocus();
			if (mFocused != null)
			{
				mFocused.unFocus();
			}
			mFocused = null;
		}

		/// <summary>Returns the focused child of this view, if any.</summary>
		/// <remarks>
		/// Returns the focused child of this view, if any. The child may have focus
		/// or contain focus.
		/// </remarks>
		/// <returns>the focused child or null.</returns>
		public virtual android.view.View getFocusedChild()
		{
			return mFocused;
		}

		/// <summary>Returns true if this view has or contains focus</summary>
		/// <returns>true if this view has or contains focus</returns>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool hasFocus()
		{
			return (mPrivateFlags & FOCUSED) != 0 || mFocused != null;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override android.view.View findFocus()
		{
			if (isFocused())
			{
				return this;
			}
			if (mFocused != null)
			{
				return mFocused.findFocus();
			}
			return null;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool hasFocusable()
		{
			if ((mViewFlags & VISIBILITY_MASK) != VISIBLE)
			{
				return false;
			}
			if (isFocusable())
			{
				return true;
			}
			int descendantFocusability = getDescendantFocusability();
			if (descendantFocusability != FOCUS_BLOCK_DESCENDANTS)
			{
				int count = mChildrenCount;
				android.view.View[] children = mChildren;
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = children[i];
						if (child.hasFocusable())
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void addFocusables(java.util.ArrayList<android.view.View> views, 
			int direction)
		{
			addFocusables(views, direction, FOCUSABLES_TOUCH_MODE);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void addFocusables(java.util.ArrayList<android.view.View> views, 
			int direction, int focusableMode)
		{
			int focusableCount = views.size();
			int descendantFocusability = getDescendantFocusability();
			if (descendantFocusability != FOCUS_BLOCK_DESCENDANTS)
			{
				int count = mChildrenCount;
				android.view.View[] children = mChildren;
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = children[i];
						if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE)
						{
							child.addFocusables(views, direction, focusableMode);
						}
					}
				}
			}
			// we add ourselves (if focusable) in all cases except for when we are
			// FOCUS_AFTER_DESCENDANTS and there are some descendants focusable.  this is
			// to avoid the focus search finding layouts when a more precise search
			// among the focusable children would be more interesting.
			if (descendantFocusability != FOCUS_AFTER_DESCENDANTS || (focusableCount == views
				.size()))
			{
				// No focusable descendants
				base.addFocusables(views, direction, focusableMode);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void findViewsWithText(java.util.ArrayList<android.view.View> outViews
			, java.lang.CharSequence text, int flags)
		{
			base.findViewsWithText(outViews, text, flags);
			int childrenCount = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < childrenCount; i++)
				{
					android.view.View child = children[i];
					if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE && (child.mPrivateFlags & IS_ROOT_NAMESPACE
						) == 0)
					{
						child.findViewsWithText(outViews, text, flags);
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override android.view.View findViewByAccessibilityIdTraversal(int accessibilityId
			)
		{
			android.view.View foundView = base.findViewByAccessibilityIdTraversal(accessibilityId
				);
			if (foundView != null)
			{
				return foundView;
			}
			int childrenCount = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < childrenCount; i++)
				{
					android.view.View child = children[i];
					foundView = child.findViewByAccessibilityIdTraversal(accessibilityId);
					if (foundView != null)
					{
						return foundView;
					}
				}
			}
			return null;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchWindowFocusChanged(bool hasFocus_1)
		{
			base.dispatchWindowFocusChanged(hasFocus_1);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchWindowFocusChanged(hasFocus_1);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void addTouchables(java.util.ArrayList<android.view.View> views)
		{
			base.addTouchables(views);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = children[i];
					if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE)
					{
						child.addTouchables(views);
					}
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchDisplayHint(int hint)
		{
			base.dispatchDisplayHint(hint);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchDisplayHint(hint);
				}
			}
		}

		/// <hide></hide>
		/// <param name="child"></param>
		/// <param name="visibility"></param>
		protected internal virtual void onChildVisibilityChanged(android.view.View child, 
			int visibility)
		{
			if (mTransition != null)
			{
				if (visibility == VISIBLE)
				{
					mTransition.showChild(this, child);
				}
				else
				{
					mTransition.hideChild(this, child);
				}
				if (visibility != VISIBLE)
				{
					// Only track this on disappearing views - appearing views are already visible
					// and don't need special handling during drawChild()
					if (mVisibilityChangingChildren == null)
					{
						mVisibilityChangingChildren = new java.util.ArrayList<android.view.View>();
					}
					mVisibilityChangingChildren.add(child);
					if (mTransitioningViews != null && mTransitioningViews.contains(child))
					{
						addDisappearingView(child);
					}
				}
			}
			// in all cases, for drags
			if (mCurrentDrag != null)
			{
				if (visibility == VISIBLE)
				{
					notifyChildOfDrag(child);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchVisibilityChanged(android.view.View changedView
			, int visibility)
		{
			base.dispatchVisibilityChanged(changedView, visibility);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchVisibilityChanged(changedView, visibility);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchWindowVisibilityChanged(int visibility)
		{
			base.dispatchWindowVisibilityChanged(visibility);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchWindowVisibilityChanged(visibility);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			base.dispatchConfigurationChanged(newConfig);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchConfigurationChanged(newConfig);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void recomputeViewAttributes(android.view.View child)
		{
			if (mAttachInfo != null && !mAttachInfo.mRecomputeGlobalAttributes)
			{
				android.view.ViewParent parent = mParent;
				if (parent != null)
				{
					parent.recomputeViewAttributes(this);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override void dispatchCollectViewAttributes(int visibility)
		{
			visibility |= mViewFlags & VISIBILITY_MASK;
			base.dispatchCollectViewAttributes(visibility);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchCollectViewAttributes(visibility);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void bringChildToFront(android.view.View child)
		{
			int index = indexOfChild(child);
			if (index >= 0)
			{
				removeFromArray(index);
				addInArray(child, mChildrenCount);
				child.mParent = this;
			}
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// !!! TODO: write real docs
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchDragEvent(android.view.DragEvent @event)
		{
			bool retval = false;
			float tx = @event.mX;
			float ty = @event.mY;
			android.view.ViewRootImpl root = getViewRootImpl();
			switch (@event.mAction)
			{
				case android.view.DragEvent.ACTION_DRAG_STARTED:
				{
					// Dispatch down the view hierarchy
					// clear state to recalculate which views we drag over
					mCurrentDragView = null;
					// Set up our tracking of drag-started notifications
					mCurrentDrag = android.view.DragEvent.obtain(@event);
					if (mDragNotifiedChildren == null)
					{
						mDragNotifiedChildren = new java.util.HashSet<android.view.View>();
					}
					else
					{
						mDragNotifiedChildren.clear();
					}
					// Now dispatch down to our children, caching the responses
					mChildAcceptsDrag = false;
					int count = mChildrenCount;
					android.view.View[] children = mChildren;
					{
						for (int i = 0; i < count; i++)
						{
							android.view.View child = children[i];
							child.mPrivateFlags2 &= ~android.view.View.DRAG_MASK;
							if (child.getVisibility() == VISIBLE)
							{
								bool handled = notifyChildOfDrag(children[i]);
								if (handled)
								{
									mChildAcceptsDrag = true;
								}
							}
						}
					}
					// Return HANDLED if one of our children can accept the drag
					if (mChildAcceptsDrag)
					{
						retval = true;
					}
					break;
				}

				case android.view.DragEvent.ACTION_DRAG_ENDED:
				{
					// Release the bookkeeping now that the drag lifecycle has ended
					if (mDragNotifiedChildren != null)
					{
						foreach (android.view.View child in Sharpen.IterableProxy.Create(mDragNotifiedChildren
							))
						{
							// If a child was notified about an ongoing drag, it's told that it's over
							child.dispatchDragEvent(@event);
							child.mPrivateFlags2 &= ~android.view.View.DRAG_MASK;
							child.refreshDrawableState();
						}
						mDragNotifiedChildren.clear();
						mCurrentDrag.recycle();
						mCurrentDrag = null;
					}
					// We consider drag-ended to have been handled if one of our children
					// had offered to handle the drag.
					if (mChildAcceptsDrag)
					{
						retval = true;
					}
					break;
				}

				case android.view.DragEvent.ACTION_DRAG_LOCATION:
				{
					// Find the [possibly new] drag target
					android.view.View target = findFrontmostDroppableChildAt(@event.mX, @event.mY, mLocalPoint
						);
					// If we've changed apparent drag target, tell the view root which view
					// we're over now [for purposes of the eventual drag-recipient-changed
					// notifications to the framework] and tell the new target that the drag
					// has entered its bounds.  The root will see setDragFocus() calls all
					// the way down to the final leaf view that is handling the LOCATION event
					// before reporting the new potential recipient to the framework.
					if (mCurrentDragView != target)
					{
						root.setDragFocus(target);
						int action = @event.mAction;
						// If we've dragged off of a child view, send it the EXITED message
						if (mCurrentDragView != null)
						{
							android.view.View view = mCurrentDragView;
							@event.mAction = android.view.DragEvent.ACTION_DRAG_EXITED;
							view.dispatchDragEvent(@event);
							view.mPrivateFlags2 &= ~android.view.View.DRAG_HOVERED;
							view.refreshDrawableState();
						}
						mCurrentDragView = target;
						// If we've dragged over a new child view, send it the ENTERED message
						if (target != null)
						{
							@event.mAction = android.view.DragEvent.ACTION_DRAG_ENTERED;
							target.dispatchDragEvent(@event);
							target.mPrivateFlags2 |= android.view.View.DRAG_HOVERED;
							target.refreshDrawableState();
						}
						@event.mAction = action;
					}
					// restore the event's original state
					// Dispatch the actual drag location notice, localized into its coordinates
					if (target != null)
					{
						@event.mX = mLocalPoint.x;
						@event.mY = mLocalPoint.y;
						retval = target.dispatchDragEvent(@event);
						@event.mX = tx;
						@event.mY = ty;
					}
					break;
				}

				case android.view.DragEvent.ACTION_DRAG_EXITED:
				{
					if (mCurrentDragView != null)
					{
						android.view.View view = mCurrentDragView;
						view.dispatchDragEvent(@event);
						view.mPrivateFlags2 &= ~android.view.View.DRAG_HOVERED;
						view.refreshDrawableState();
						mCurrentDragView = null;
					}
					break;
				}

				case android.view.DragEvent.ACTION_DROP:
				{
					android.view.View target = findFrontmostDroppableChildAt(@event.mX, @event.mY, mLocalPoint
						);
					if (target != null)
					{
						@event.mX = mLocalPoint.x;
						@event.mY = mLocalPoint.y;
						retval = target.dispatchDragEvent(@event);
						@event.mX = tx;
						@event.mY = ty;
					}
					break;
				}
			}
			// If none of our children could handle the event, try here
			if (!retval)
			{
				// Call up to the View implementation that dispatches to installed listeners
				retval = base.dispatchDragEvent(@event);
			}
			return retval;
		}

		// Find the frontmost child view that lies under the given point, and calculate
		// the position within its own local coordinate system.
		internal virtual android.view.View findFrontmostDroppableChildAt(float x, float y
			, android.graphics.PointF outLocalPoint)
		{
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					android.view.View child = children[i];
					if (!child.canAcceptDrag())
					{
						continue;
					}
					if (isTransformedTouchPointInView(x, y, child, outLocalPoint))
					{
						return child;
					}
				}
			}
			return null;
		}

		internal virtual bool notifyChildOfDrag(android.view.View child)
		{
			bool canAccept = false;
			if (!mDragNotifiedChildren.contains(child))
			{
				mDragNotifiedChildren.add(child);
				canAccept = child.dispatchDragEvent(mCurrentDrag);
				if (canAccept && !child.canAcceptDrag())
				{
					child.mPrivateFlags2 |= android.view.View.DRAG_CAN_ACCEPT;
					child.refreshDrawableState();
				}
			}
			return canAccept;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchSystemUiVisibilityChanged(int visible)
		{
			base.dispatchSystemUiVisibilityChanged(visible);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = children[i];
					child.dispatchSystemUiVisibilityChanged(visible);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override void updateLocalSystemUiVisibility(int localValue, int localChanges
			)
		{
			base.updateLocalSystemUiVisibility(localValue, localChanges);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = children[i];
					child.updateLocalSystemUiVisibility(localValue, localChanges);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEventPreIme(android.view.KeyEvent @event)
		{
			if ((mPrivateFlags & (FOCUSED | HAS_BOUNDS)) == (FOCUSED | HAS_BOUNDS))
			{
				return base.dispatchKeyEventPreIme(@event);
			}
			else
			{
				if (mFocused != null && (mFocused.mPrivateFlags & HAS_BOUNDS) == HAS_BOUNDS)
				{
					return mFocused.dispatchKeyEventPreIme(@event);
				}
			}
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onKeyEvent(@event, 1);
			}
			if ((mPrivateFlags & (FOCUSED | HAS_BOUNDS)) == (FOCUSED | HAS_BOUNDS))
			{
				if (base.dispatchKeyEvent(@event))
				{
					return true;
				}
			}
			else
			{
				if (mFocused != null && (mFocused.mPrivateFlags & HAS_BOUNDS) == HAS_BOUNDS)
				{
					if (mFocused.dispatchKeyEvent(@event))
					{
						return true;
					}
				}
			}
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(@event, 1);
			}
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyShortcutEvent(android.view.KeyEvent @event)
		{
			if ((mPrivateFlags & (FOCUSED | HAS_BOUNDS)) == (FOCUSED | HAS_BOUNDS))
			{
				return base.dispatchKeyShortcutEvent(@event);
			}
			else
			{
				if (mFocused != null && (mFocused.mPrivateFlags & HAS_BOUNDS) == HAS_BOUNDS)
				{
					return mFocused.dispatchKeyShortcutEvent(@event);
				}
			}
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchTrackballEvent(android.view.MotionEvent @event)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onTrackballEvent(@event, 1);
			}
			if ((mPrivateFlags & (FOCUSED | HAS_BOUNDS)) == (FOCUSED | HAS_BOUNDS))
			{
				if (base.dispatchTrackballEvent(@event))
				{
					return true;
				}
			}
			else
			{
				if (mFocused != null && (mFocused.mPrivateFlags & HAS_BOUNDS) == HAS_BOUNDS)
				{
					if (mFocused.dispatchTrackballEvent(@event))
					{
						return true;
					}
				}
			}
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(@event, 1);
			}
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool dispatchHoverEvent(android.view.MotionEvent @event
			)
		{
			int action = @event.getAction();
			// First check whether the view group wants to intercept the hover event.
			bool interceptHover = onInterceptHoverEvent(@event);
			@event.setAction(action);
			// restore action in case it was changed
			android.view.MotionEvent eventNoHistory = @event;
			bool handled = false;
			// Send events to the hovered children and build a new list of hover targets until
			// one is found that handles the event.
			android.view.ViewGroup.HoverTarget firstOldHoverTarget = mFirstHoverTarget;
			mFirstHoverTarget = null;
			if (!interceptHover && action != android.view.MotionEvent.ACTION_HOVER_EXIT)
			{
				float x = @event.getX();
				float y = @event.getY();
				int childrenCount = mChildrenCount;
				if (childrenCount != 0)
				{
					android.view.View[] children = mChildren;
					android.view.ViewGroup.HoverTarget lastHoverTarget = null;
					{
						for (int i = childrenCount - 1; i >= 0; i--)
						{
							android.view.View child = children[i];
							if (!canViewReceivePointerEvents(child) || !isTransformedTouchPointInView(x, y, child
								, null))
							{
								continue;
							}
							// Obtain a hover target for this child.  Dequeue it from the
							// old hover target list if the child was previously hovered.
							android.view.ViewGroup.HoverTarget hoverTarget = firstOldHoverTarget;
							bool wasHovered;
							{
								for (android.view.ViewGroup.HoverTarget predecessor = null; ; )
								{
									if (hoverTarget == null)
									{
										hoverTarget = android.view.ViewGroup.HoverTarget.obtain(child);
										wasHovered = false;
										break;
									}
									if (hoverTarget.child == child)
									{
										if (predecessor != null)
										{
											predecessor.next = hoverTarget.next;
										}
										else
										{
											firstOldHoverTarget = hoverTarget.next;
										}
										hoverTarget.next = null;
										wasHovered = true;
										break;
									}
									predecessor = hoverTarget;
									hoverTarget = hoverTarget.next;
								}
							}
							// Enqueue the hover target onto the new hover target list.
							if (lastHoverTarget != null)
							{
								lastHoverTarget.next = hoverTarget;
							}
							else
							{
								lastHoverTarget = hoverTarget;
								mFirstHoverTarget = hoverTarget;
							}
							// Dispatch the event to the child.
							if (action == android.view.MotionEvent.ACTION_HOVER_ENTER)
							{
								if (!wasHovered)
								{
									// Send the enter as is.
									handled |= dispatchTransformedGenericPointerEvent(@event, child);
								}
							}
							else
							{
								// enter
								if (action == android.view.MotionEvent.ACTION_HOVER_MOVE)
								{
									if (!wasHovered)
									{
										// Synthesize an enter from a move.
										eventNoHistory = obtainMotionEventNoHistoryOrSelf(eventNoHistory);
										eventNoHistory.setAction(android.view.MotionEvent.ACTION_HOVER_ENTER);
										handled |= dispatchTransformedGenericPointerEvent(eventNoHistory, child);
										// enter
										eventNoHistory.setAction(action);
										handled |= dispatchTransformedGenericPointerEvent(eventNoHistory, child);
									}
									else
									{
										// move
										// Send the move as is.
										handled |= dispatchTransformedGenericPointerEvent(@event, child);
									}
								}
							}
							if (handled)
							{
								break;
							}
						}
					}
				}
			}
			// Send exit events to all previously hovered children that are no longer hovered.
			while (firstOldHoverTarget != null)
			{
				android.view.View child = firstOldHoverTarget.child;
				// Exit the old hovered child.
				if (action == android.view.MotionEvent.ACTION_HOVER_EXIT)
				{
					// Send the exit as is.
					handled |= dispatchTransformedGenericPointerEvent(@event, child);
				}
				else
				{
					// exit
					// Synthesize an exit from a move or enter.
					// Ignore the result because hover focus has moved to a different view.
					if (action == android.view.MotionEvent.ACTION_HOVER_MOVE)
					{
						dispatchTransformedGenericPointerEvent(@event, child);
					}
					// move
					eventNoHistory = obtainMotionEventNoHistoryOrSelf(eventNoHistory);
					eventNoHistory.setAction(android.view.MotionEvent.ACTION_HOVER_EXIT);
					dispatchTransformedGenericPointerEvent(eventNoHistory, child);
					// exit
					eventNoHistory.setAction(action);
				}
				android.view.ViewGroup.HoverTarget nextOldHoverTarget = firstOldHoverTarget.next;
				firstOldHoverTarget.recycle();
				firstOldHoverTarget = nextOldHoverTarget;
			}
			// Send events to the view group itself if no children have handled it.
			bool newHoveredSelf = !handled;
			if (newHoveredSelf == mHoveredSelf)
			{
				if (newHoveredSelf)
				{
					// Send event to the view group as before.
					handled |= base.dispatchHoverEvent(@event);
				}
			}
			else
			{
				if (mHoveredSelf)
				{
					// Exit the view group.
					if (action == android.view.MotionEvent.ACTION_HOVER_EXIT)
					{
						// Send the exit as is.
						handled |= base.dispatchHoverEvent(@event);
					}
					else
					{
						// exit
						// Synthesize an exit from a move or enter.
						// Ignore the result because hover focus is moving to a different view.
						if (action == android.view.MotionEvent.ACTION_HOVER_MOVE)
						{
							base.dispatchHoverEvent(@event);
						}
						// move
						eventNoHistory = obtainMotionEventNoHistoryOrSelf(eventNoHistory);
						eventNoHistory.setAction(android.view.MotionEvent.ACTION_HOVER_EXIT);
						base.dispatchHoverEvent(eventNoHistory);
						// exit
						eventNoHistory.setAction(action);
					}
					mHoveredSelf = false;
				}
				if (newHoveredSelf)
				{
					// Enter the view group.
					if (action == android.view.MotionEvent.ACTION_HOVER_ENTER)
					{
						// Send the enter as is.
						handled |= base.dispatchHoverEvent(@event);
						// enter
						mHoveredSelf = true;
					}
					else
					{
						if (action == android.view.MotionEvent.ACTION_HOVER_MOVE)
						{
							// Synthesize an enter from a move.
							eventNoHistory = obtainMotionEventNoHistoryOrSelf(eventNoHistory);
							eventNoHistory.setAction(android.view.MotionEvent.ACTION_HOVER_ENTER);
							handled |= base.dispatchHoverEvent(eventNoHistory);
							// enter
							eventNoHistory.setAction(action);
							handled |= base.dispatchHoverEvent(eventNoHistory);
							// move
							mHoveredSelf = true;
						}
					}
				}
			}
			// Recycle the copy of the event that we made.
			if (eventNoHistory != @event)
			{
				eventNoHistory.recycle();
			}
			// Done.
			return handled;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool hasHoveredChild()
		{
			return mFirstHoverTarget != null;
		}

		/// <summary>
		/// Implement this method to intercept hover events before they are handled
		/// by child views.
		/// </summary>
		/// <remarks>
		/// Implement this method to intercept hover events before they are handled
		/// by child views.
		/// <p>
		/// This method is called before dispatching a hover event to a child of
		/// the view group or to the view group's own
		/// <see cref="View.onHoverEvent(MotionEvent)">View.onHoverEvent(MotionEvent)</see>
		/// to allow
		/// the view group a chance to intercept the hover event.
		/// This method can also be used to watch all pointer motions that occur within
		/// the bounds of the view group even when the pointer is hovering over
		/// a child of the view group rather than over the view group itself.
		/// </p><p>
		/// The view group can prevent its children from receiving hover events by
		/// implementing this method and returning <code>true</code> to indicate
		/// that it would like to intercept hover events.  The view group must
		/// continuously return <code>true</code> from
		/// <see cref="onInterceptHoverEvent(MotionEvent)">onInterceptHoverEvent(MotionEvent)
		/// 	</see>
		/// for as long as it wishes to continue intercepting hover events from
		/// its children.
		/// </p><p>
		/// Interception preserves the invariant that at most one view can be
		/// hovered at a time by transferring hover focus from the currently hovered
		/// child to the view group or vice-versa as needed.
		/// </p><p>
		/// If this method returns <code>true</code> and a child is already hovered, then the
		/// child view will first receive a hover exit event and then the view group
		/// itself will receive a hover enter event in
		/// <see cref="View.onHoverEvent(MotionEvent)">View.onHoverEvent(MotionEvent)</see>
		/// .
		/// Likewise, if this method had previously returned <code>true</code> to intercept hover
		/// events and instead returns <code>false</code> while the pointer is hovering
		/// within the bounds of one of a child, then the view group will first receive a
		/// hover exit event in
		/// <see cref="View.onHoverEvent(MotionEvent)">View.onHoverEvent(MotionEvent)</see>
		/// and then the hovered child will
		/// receive a hover enter event.
		/// </p><p>
		/// The default implementation always returns false.
		/// </p>
		/// </remarks>
		/// <param name="event">The motion event that describes the hover.</param>
		/// <returns>
		/// True if the view group would like to intercept the hover event
		/// and prevent its children from receiving it.
		/// </returns>
		public virtual bool onInterceptHoverEvent(android.view.MotionEvent @event)
		{
			return false;
		}

		private static android.view.MotionEvent obtainMotionEventNoHistoryOrSelf(android.view.MotionEvent
			 @event)
		{
			if (@event.getHistorySize() == 0)
			{
				return @event;
			}
			return android.view.MotionEvent.obtainNoHistory(@event);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool dispatchGenericPointerEvent(android.view.MotionEvent
			 @event)
		{
			// Send the event to the child under the pointer.
			int childrenCount = mChildrenCount;
			if (childrenCount != 0)
			{
				android.view.View[] children = mChildren;
				float x = @event.getX();
				float y = @event.getY();
				{
					for (int i = childrenCount - 1; i >= 0; i--)
					{
						android.view.View child = children[i];
						if (!canViewReceivePointerEvents(child) || !isTransformedTouchPointInView(x, y, child
							, null))
						{
							continue;
						}
						if (dispatchTransformedGenericPointerEvent(@event, child))
						{
							return true;
						}
					}
				}
			}
			// No child handled the event.  Send it to this view group.
			return base.dispatchGenericPointerEvent(@event);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool dispatchGenericFocusedEvent(android.view.MotionEvent
			 @event)
		{
			// Send the event to the focused child or to this view group if it has focus.
			if ((mPrivateFlags & (FOCUSED | HAS_BOUNDS)) == (FOCUSED | HAS_BOUNDS))
			{
				return base.dispatchGenericFocusedEvent(@event);
			}
			else
			{
				if (mFocused != null && (mFocused.mPrivateFlags & HAS_BOUNDS) == HAS_BOUNDS)
				{
					return mFocused.dispatchGenericMotionEvent(@event);
				}
			}
			return false;
		}

		/// <summary>
		/// Dispatches a generic pointer event to a child, taking into account
		/// transformations that apply to the child.
		/// </summary>
		/// <remarks>
		/// Dispatches a generic pointer event to a child, taking into account
		/// transformations that apply to the child.
		/// </remarks>
		/// <param name="event">The event to send.</param>
		/// <param name="child">The view to send the event to.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the child handled the event.
		/// </returns>
		private bool dispatchTransformedGenericPointerEvent(android.view.MotionEvent @event
			, android.view.View child)
		{
			float offsetX = mScrollX - child.mLeft;
			float offsetY = mScrollY - child.mTop;
			bool handled;
			if (!child.hasIdentityMatrix())
			{
				android.view.MotionEvent transformedEvent = android.view.MotionEvent.obtain(@event
					);
				transformedEvent.offsetLocation(offsetX, offsetY);
				transformedEvent.transform(child.getInverseMatrix());
				handled = child.dispatchGenericMotionEvent(transformedEvent);
				transformedEvent.recycle();
			}
			else
			{
				@event.offsetLocation(offsetX, offsetY);
				handled = child.dispatchGenericMotionEvent(@event);
				@event.offsetLocation(-offsetX, -offsetY);
			}
			return handled;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchTouchEvent(android.view.MotionEvent ev)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onTouchEvent(ev, 1);
			}
			bool handled = false;
			if (onFilterTouchEventForSecurity(ev))
			{
				int action = ev.getAction();
				int actionMasked = action & android.view.MotionEvent.ACTION_MASK;
				// Handle an initial down.
				if (actionMasked == android.view.MotionEvent.ACTION_DOWN)
				{
					// Throw away all previous state when starting a new touch gesture.
					// The framework may have dropped the up or cancel event for the previous gesture
					// due to an app switch, ANR, or some other state change.
					cancelAndClearTouchTargets(ev);
					resetTouchState();
				}
				// Check for interception.
				bool intercepted;
				if (actionMasked == android.view.MotionEvent.ACTION_DOWN || mFirstTouchTarget != 
					null)
				{
					bool disallowIntercept = (mGroupFlags & FLAG_DISALLOW_INTERCEPT) != 0;
					if (!disallowIntercept)
					{
						intercepted = onInterceptTouchEvent(ev);
						ev.setAction(action);
					}
					else
					{
						// restore action in case it was changed
						intercepted = false;
					}
				}
				else
				{
					// There are no touch targets and this action is not an initial down
					// so this view group continues to intercept touches.
					intercepted = true;
				}
				// Check for cancelation.
				bool canceled = resetCancelNextUpFlag(this) || actionMasked == android.view.MotionEvent
					.ACTION_CANCEL;
				// Update list of touch targets for pointer down, if needed.
				bool split = (mGroupFlags & FLAG_SPLIT_MOTION_EVENTS) != 0;
				android.view.ViewGroup.TouchTarget newTouchTarget = null;
				bool alreadyDispatchedToNewTouchTarget = false;
				if (!canceled && !intercepted)
				{
					if (actionMasked == android.view.MotionEvent.ACTION_DOWN || (split && actionMasked
						 == android.view.MotionEvent.ACTION_POINTER_DOWN) || actionMasked == android.view.MotionEvent
						.ACTION_HOVER_MOVE)
					{
						int actionIndex = ev.getActionIndex();
						// always 0 for down
						int idBitsToAssign = split ? 1 << ev.getPointerId(actionIndex) : android.view.ViewGroup
							.TouchTarget.ALL_POINTER_IDS;
						// Clean up earlier touch targets for this pointer id in case they
						// have become out of sync.
						removePointersFromTouchTargets(idBitsToAssign);
						int childrenCount = mChildrenCount;
						if (childrenCount != 0)
						{
							// Find a child that can receive the event.
							// Scan children from front to back.
							android.view.View[] children = mChildren;
							float x = ev.getX(actionIndex);
							float y = ev.getY(actionIndex);
							{
								for (int i = childrenCount - 1; i >= 0; i--)
								{
									android.view.View child = children[i];
									if (!canViewReceivePointerEvents(child) || !isTransformedTouchPointInView(x, y, child
										, null))
									{
										continue;
									}
									newTouchTarget = getTouchTarget(child);
									if (newTouchTarget != null)
									{
										// Child is already receiving touch within its bounds.
										// Give it the new pointer in addition to the ones it is handling.
										newTouchTarget.pointerIdBits |= idBitsToAssign;
										break;
									}
									resetCancelNextUpFlag(child);
									if (dispatchTransformedTouchEvent(ev, false, child, idBitsToAssign))
									{
										// Child wants to receive touch within its bounds.
										mLastTouchDownTime = ev.getDownTime();
										mLastTouchDownIndex = i;
										mLastTouchDownX = ev.getX();
										mLastTouchDownY = ev.getY();
										newTouchTarget = addTouchTarget(child, idBitsToAssign);
										alreadyDispatchedToNewTouchTarget = true;
										break;
									}
								}
							}
						}
						if (newTouchTarget == null && mFirstTouchTarget != null)
						{
							// Did not find a child to receive the event.
							// Assign the pointer to the least recently added target.
							newTouchTarget = mFirstTouchTarget;
							while (newTouchTarget.next != null)
							{
								newTouchTarget = newTouchTarget.next;
							}
							newTouchTarget.pointerIdBits |= idBitsToAssign;
						}
					}
				}
				// Dispatch to touch targets.
				if (mFirstTouchTarget == null)
				{
					// No touch targets so treat this as an ordinary view.
					handled = dispatchTransformedTouchEvent(ev, canceled, null, android.view.ViewGroup
						.TouchTarget.ALL_POINTER_IDS);
				}
				else
				{
					// Dispatch to touch targets, excluding the new touch target if we already
					// dispatched to it.  Cancel touch targets if necessary.
					android.view.ViewGroup.TouchTarget predecessor = null;
					android.view.ViewGroup.TouchTarget target = mFirstTouchTarget;
					while (target != null)
					{
						android.view.ViewGroup.TouchTarget next = target.next;
						if (alreadyDispatchedToNewTouchTarget && target == newTouchTarget)
						{
							handled = true;
						}
						else
						{
							bool cancelChild = resetCancelNextUpFlag(target.child) || intercepted;
							if (dispatchTransformedTouchEvent(ev, cancelChild, target.child, target.pointerIdBits
								))
							{
								handled = true;
							}
							if (cancelChild)
							{
								if (predecessor == null)
								{
									mFirstTouchTarget = next;
								}
								else
								{
									predecessor.next = next;
								}
								target.recycle();
								target = next;
								continue;
							}
						}
						predecessor = target;
						target = next;
					}
				}
				// Update list of touch targets for pointer up or cancel, if needed.
				if (canceled || actionMasked == android.view.MotionEvent.ACTION_UP || actionMasked
					 == android.view.MotionEvent.ACTION_HOVER_MOVE)
				{
					resetTouchState();
				}
				else
				{
					if (split && actionMasked == android.view.MotionEvent.ACTION_POINTER_UP)
					{
						int actionIndex = ev.getActionIndex();
						int idBitsToRemove = 1 << ev.getPointerId(actionIndex);
						removePointersFromTouchTargets(idBitsToRemove);
					}
				}
			}
			if (!handled && mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(ev, 1);
			}
			return handled;
		}

		/// <summary>Resets all touch state in preparation for a new cycle.</summary>
		/// <remarks>Resets all touch state in preparation for a new cycle.</remarks>
		private void resetTouchState()
		{
			clearTouchTargets();
			resetCancelNextUpFlag(this);
			mGroupFlags &= ~FLAG_DISALLOW_INTERCEPT;
		}

		/// <summary>Resets the cancel next up flag.</summary>
		/// <remarks>
		/// Resets the cancel next up flag.
		/// Returns true if the flag was previously set.
		/// </remarks>
		private bool resetCancelNextUpFlag(android.view.View view)
		{
			if ((view.mPrivateFlags & CANCEL_NEXT_UP_EVENT) != 0)
			{
				view.mPrivateFlags &= ~CANCEL_NEXT_UP_EVENT;
				return true;
			}
			return false;
		}

		/// <summary>Clears all touch targets.</summary>
		/// <remarks>Clears all touch targets.</remarks>
		private void clearTouchTargets()
		{
			android.view.ViewGroup.TouchTarget target = mFirstTouchTarget;
			if (target != null)
			{
				do
				{
					android.view.ViewGroup.TouchTarget next = target.next;
					target.recycle();
					target = next;
				}
				while (target != null);
				mFirstTouchTarget = null;
			}
		}

		/// <summary>Cancels and clears all touch targets.</summary>
		/// <remarks>Cancels and clears all touch targets.</remarks>
		private void cancelAndClearTouchTargets(android.view.MotionEvent @event)
		{
			if (mFirstTouchTarget != null)
			{
				bool syntheticEvent = false;
				if (@event == null)
				{
					long now = android.os.SystemClock.uptimeMillis();
					@event = android.view.MotionEvent.obtain(now, now, android.view.MotionEvent.ACTION_CANCEL
						, 0.0f, 0.0f, 0);
					@event.setSource(android.view.InputDevice.SOURCE_TOUCHSCREEN);
					syntheticEvent = true;
				}
				{
					for (android.view.ViewGroup.TouchTarget target = mFirstTouchTarget; target != null
						; target = target.next)
					{
						resetCancelNextUpFlag(target.child);
						dispatchTransformedTouchEvent(@event, true, target.child, target.pointerIdBits);
					}
				}
				clearTouchTargets();
				if (syntheticEvent)
				{
					@event.recycle();
				}
			}
		}

		/// <summary>Gets the touch target for specified child view.</summary>
		/// <remarks>
		/// Gets the touch target for specified child view.
		/// Returns null if not found.
		/// </remarks>
		private android.view.ViewGroup.TouchTarget getTouchTarget(android.view.View child
			)
		{
			{
				for (android.view.ViewGroup.TouchTarget target = mFirstTouchTarget; target != null
					; target = target.next)
				{
					if (target.child == child)
					{
						return target;
					}
				}
			}
			return null;
		}

		/// <summary>Adds a touch target for specified child to the beginning of the list.</summary>
		/// <remarks>
		/// Adds a touch target for specified child to the beginning of the list.
		/// Assumes the target child is not already present.
		/// </remarks>
		private android.view.ViewGroup.TouchTarget addTouchTarget(android.view.View child
			, int pointerIdBits)
		{
			android.view.ViewGroup.TouchTarget target = android.view.ViewGroup.TouchTarget.obtain
				(child, pointerIdBits);
			target.next = mFirstTouchTarget;
			mFirstTouchTarget = target;
			return target;
		}

		/// <summary>Removes the pointer ids from consideration.</summary>
		/// <remarks>Removes the pointer ids from consideration.</remarks>
		private void removePointersFromTouchTargets(int pointerIdBits)
		{
			android.view.ViewGroup.TouchTarget predecessor = null;
			android.view.ViewGroup.TouchTarget target = mFirstTouchTarget;
			while (target != null)
			{
				android.view.ViewGroup.TouchTarget next = target.next;
				if ((target.pointerIdBits & pointerIdBits) != 0)
				{
					target.pointerIdBits &= ~pointerIdBits;
					if (target.pointerIdBits == 0)
					{
						if (predecessor == null)
						{
							mFirstTouchTarget = next;
						}
						else
						{
							predecessor.next = next;
						}
						target.recycle();
						target = next;
						continue;
					}
				}
				predecessor = target;
				target = next;
			}
		}

		/// <summary>Returns true if a child view can receive pointer events.</summary>
		/// <remarks>Returns true if a child view can receive pointer events.</remarks>
		/// <hide></hide>
		private static bool canViewReceivePointerEvents(android.view.View child)
		{
			return (child.mViewFlags & VISIBILITY_MASK) == VISIBLE || child.getAnimation() !=
				 null;
		}

		/// <summary>
		/// Returns true if a child view contains the specified point when transformed
		/// into its coordinate space.
		/// </summary>
		/// <remarks>
		/// Returns true if a child view contains the specified point when transformed
		/// into its coordinate space.
		/// Child must not be null.
		/// </remarks>
		/// <hide></hide>
		protected internal virtual bool isTransformedTouchPointInView(float x, float y, android.view.View
			 child, android.graphics.PointF outLocalPoint)
		{
			float localX = x + mScrollX - child.mLeft;
			float localY = y + mScrollY - child.mTop;
			if (!child.hasIdentityMatrix() && mAttachInfo != null)
			{
				float[] localXY = mAttachInfo.mTmpTransformLocation;
				localXY[0] = localX;
				localXY[1] = localY;
				child.getInverseMatrix().mapPoints(localXY);
				localX = localXY[0];
				localY = localXY[1];
			}
			bool isInView = child.pointInView(localX, localY);
			if (isInView && outLocalPoint != null)
			{
				outLocalPoint.set(localX, localY);
			}
			return isInView;
		}

		/// <summary>
		/// Transforms a motion event into the coordinate space of a particular child view,
		/// filters out irrelevant pointer ids, and overrides its action if necessary.
		/// </summary>
		/// <remarks>
		/// Transforms a motion event into the coordinate space of a particular child view,
		/// filters out irrelevant pointer ids, and overrides its action if necessary.
		/// If child is null, assumes the MotionEvent will be sent to this ViewGroup instead.
		/// </remarks>
		private bool dispatchTransformedTouchEvent(android.view.MotionEvent @event, bool 
			cancel, android.view.View child, int desiredPointerIdBits)
		{
			bool handled;
			// Canceling motions is a special case.  We don't need to perform any transformations
			// or filtering.  The important part is the action, not the contents.
			int oldAction = @event.getAction();
			if (cancel || oldAction == android.view.MotionEvent.ACTION_CANCEL)
			{
				@event.setAction(android.view.MotionEvent.ACTION_CANCEL);
				if (child == null)
				{
					handled = base.dispatchTouchEvent(@event);
				}
				else
				{
					handled = child.dispatchTouchEvent(@event);
				}
				@event.setAction(oldAction);
				return handled;
			}
			// Calculate the number of pointers to deliver.
			int oldPointerIdBits = @event.getPointerIdBits();
			int newPointerIdBits = oldPointerIdBits & desiredPointerIdBits;
			// If for some reason we ended up in an inconsistent state where it looks like we
			// might produce a motion event with no pointers in it, then drop the event.
			if (newPointerIdBits == 0)
			{
				return false;
			}
			// If the number of pointers is the same and we don't need to perform any fancy
			// irreversible transformations, then we can reuse the motion event for this
			// dispatch as long as we are careful to revert any changes we make.
			// Otherwise we need to make a copy.
			android.view.MotionEvent transformedEvent;
			if (newPointerIdBits == oldPointerIdBits)
			{
				if (child == null || child.hasIdentityMatrix())
				{
					if (child == null)
					{
						handled = base.dispatchTouchEvent(@event);
					}
					else
					{
						float offsetX = mScrollX - child.mLeft;
						float offsetY = mScrollY - child.mTop;
						@event.offsetLocation(offsetX, offsetY);
						handled = child.dispatchTouchEvent(@event);
						@event.offsetLocation(-offsetX, -offsetY);
					}
					return handled;
				}
				transformedEvent = android.view.MotionEvent.obtain(@event);
			}
			else
			{
				transformedEvent = @event.split(newPointerIdBits);
			}
			// Perform any necessary transformations and dispatch.
			if (child == null)
			{
				handled = base.dispatchTouchEvent(transformedEvent);
			}
			else
			{
				float offsetX = mScrollX - child.mLeft;
				float offsetY = mScrollY - child.mTop;
				transformedEvent.offsetLocation(offsetX, offsetY);
				if (!child.hasIdentityMatrix())
				{
					transformedEvent.transform(child.getInverseMatrix());
				}
				handled = child.dispatchTouchEvent(transformedEvent);
			}
			// Done.
			transformedEvent.recycle();
			return handled;
		}

		/// <summary>
		/// Enable or disable the splitting of MotionEvents to multiple children during touch event
		/// dispatch.
		/// </summary>
		/// <remarks>
		/// Enable or disable the splitting of MotionEvents to multiple children during touch event
		/// dispatch. This behavior is enabled by default for applications that target an
		/// SDK version of
		/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB">android.os.Build.VERSION_CODES.HONEYCOMB
		/// 	</see>
		/// or newer.
		/// <p>When this option is enabled MotionEvents may be split and dispatched to different child
		/// views depending on where each pointer initially went down. This allows for user interactions
		/// such as scrolling two panes of content independently, chording of buttons, and performing
		/// independent gestures on different pieces of content.
		/// </remarks>
		/// <param name="split">
		/// <code>true</code> to allow MotionEvents to be split and dispatched to multiple
		/// child views. <code>false</code> to only allow one child view to be the target of
		/// any MotionEvent received by this ViewGroup.
		/// </param>
		public virtual void setMotionEventSplittingEnabled(bool split)
		{
			// TODO Applications really shouldn't change this setting mid-touch event,
			// but perhaps this should handle that case and send ACTION_CANCELs to any child views
			// with gestures in progress when this is changed.
			if (split)
			{
				mGroupFlags |= FLAG_SPLIT_MOTION_EVENTS;
			}
			else
			{
				mGroupFlags &= ~FLAG_SPLIT_MOTION_EVENTS;
			}
		}

		/// <summary>Returns true if MotionEvents dispatched to this ViewGroup can be split to multiple children.
		/// 	</summary>
		/// <remarks>Returns true if MotionEvents dispatched to this ViewGroup can be split to multiple children.
		/// 	</remarks>
		/// <returns>true if MotionEvents dispatched to this ViewGroup can be split to multiple children.
		/// 	</returns>
		public virtual bool isMotionEventSplittingEnabled()
		{
			return (mGroupFlags & FLAG_SPLIT_MOTION_EVENTS) == FLAG_SPLIT_MOTION_EVENTS;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void requestDisallowInterceptTouchEvent(bool disallowIntercept)
		{
			if (disallowIntercept == ((mGroupFlags & FLAG_DISALLOW_INTERCEPT) != 0))
			{
				// We're already in this state, assume our ancestors are too
				return;
			}
			if (disallowIntercept)
			{
				mGroupFlags |= FLAG_DISALLOW_INTERCEPT;
			}
			else
			{
				mGroupFlags &= ~FLAG_DISALLOW_INTERCEPT;
			}
			// Pass it up to our parent
			if (mParent != null)
			{
				mParent.requestDisallowInterceptTouchEvent(disallowIntercept);
			}
		}

		/// <summary>Implement this method to intercept all touch screen motion events.</summary>
		/// <remarks>
		/// Implement this method to intercept all touch screen motion events.  This
		/// allows you to watch events as they are dispatched to your children, and
		/// take ownership of the current gesture at any point.
		/// <p>Using this function takes some care, as it has a fairly complicated
		/// interaction with
		/// <see cref="View.onTouchEvent(MotionEvent)">View.onTouchEvent(MotionEvent)</see>
		/// , and using it requires implementing
		/// that method as well as this one in the correct way.  Events will be
		/// received in the following order:
		/// <ol>
		/// <li> You will receive the down event here.
		/// <li> The down event will be handled either by a child of this view
		/// group, or given to your own onTouchEvent() method to handle; this means
		/// you should implement onTouchEvent() to return true, so you will
		/// continue to see the rest of the gesture (instead of looking for
		/// a parent view to handle it).  Also, by returning true from
		/// onTouchEvent(), you will not receive any following
		/// events in onInterceptTouchEvent() and all touch processing must
		/// happen in onTouchEvent() like normal.
		/// <li> For as long as you return false from this function, each following
		/// event (up to and including the final up) will be delivered first here
		/// and then to the target's onTouchEvent().
		/// <li> If you return true from here, you will not receive any
		/// following events: the target view will receive the same event but
		/// with the action
		/// <see cref="MotionEvent.ACTION_CANCEL">MotionEvent.ACTION_CANCEL</see>
		/// , and all further
		/// events will be delivered to your onTouchEvent() method and no longer
		/// appear here.
		/// </ol>
		/// </remarks>
		/// <param name="ev">The motion event being dispatched down the hierarchy.</param>
		/// <returns>
		/// Return true to steal motion events from the children and have
		/// them dispatched to this ViewGroup through onTouchEvent().
		/// The current target will receive an ACTION_CANCEL event, and no further
		/// messages will be delivered here.
		/// </returns>
		public virtual bool onInterceptTouchEvent(android.view.MotionEvent ev)
		{
			return false;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// Looks for a view to give focus to respecting the setting specified by
		/// <see cref="getDescendantFocusability()">getDescendantFocusability()</see>
		/// .
		/// Uses
		/// <see cref="onRequestFocusInDescendants(int, android.graphics.Rect)">onRequestFocusInDescendants(int, android.graphics.Rect)
		/// 	</see>
		/// to
		/// find focus within the children of this group when appropriate.
		/// </summary>
		/// <seealso cref="FOCUS_BEFORE_DESCENDANTS">FOCUS_BEFORE_DESCENDANTS</seealso>
		/// <seealso cref="FOCUS_AFTER_DESCENDANTS">FOCUS_AFTER_DESCENDANTS</seealso>
		/// <seealso cref="FOCUS_BLOCK_DESCENDANTS">FOCUS_BLOCK_DESCENDANTS</seealso>
		/// <seealso cref="onRequestFocusInDescendants(int, android.graphics.Rect)"></seealso>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool requestFocus(int direction, android.graphics.Rect previouslyFocusedRect
			)
		{
			int descendantFocusability = getDescendantFocusability();
			switch (descendantFocusability)
			{
				case FOCUS_BLOCK_DESCENDANTS:
				{
					return base.requestFocus(direction, previouslyFocusedRect);
				}

				case FOCUS_BEFORE_DESCENDANTS:
				{
					bool took = base.requestFocus(direction, previouslyFocusedRect);
					return took ? took : onRequestFocusInDescendants(direction, previouslyFocusedRect
						);
				}

				case FOCUS_AFTER_DESCENDANTS:
				{
					bool took = onRequestFocusInDescendants(direction, previouslyFocusedRect);
					return took ? took : base.requestFocus(direction, previouslyFocusedRect);
				}

				default:
				{
					throw new System.InvalidOperationException("descendant focusability must be " + "one of FOCUS_BEFORE_DESCENDANTS, FOCUS_AFTER_DESCENDANTS, FOCUS_BLOCK_DESCENDANTS "
						 + "but is " + descendantFocusability);
				}
			}
		}

		/// <summary>
		/// Look for a descendant to call
		/// <see cref="View.requestFocus()">View.requestFocus()</see>
		/// on.
		/// Called by
		/// <see cref="requestFocus(int, android.graphics.Rect)">requestFocus(int, android.graphics.Rect)
		/// 	</see>
		/// when it wants to request focus within its children.  Override this to
		/// customize how your
		/// <see cref="ViewGroup">ViewGroup</see>
		/// requests focus within its children.
		/// </summary>
		/// <param name="direction">One of FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, and FOCUS_RIGHT</param>
		/// <param name="previouslyFocusedRect">
		/// The rectangle (in this View's coordinate system)
		/// to give a finer grained hint about where focus is coming from.  May be null
		/// if there is no hint.
		/// </param>
		/// <returns>Whether focus was taken.</returns>
		protected internal virtual bool onRequestFocusInDescendants(int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			int index;
			int increment;
			int end;
			int count = mChildrenCount;
			if ((direction & FOCUS_FORWARD) != 0)
			{
				index = 0;
				increment = 1;
				end = count;
			}
			else
			{
				index = count - 1;
				increment = -1;
				end = -1;
			}
			android.view.View[] children = mChildren;
			{
				for (int i = index; i != end; i += increment)
				{
					android.view.View child = children[i];
					if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE)
					{
						if (child.requestFocus(direction, previouslyFocusedRect))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchStartTemporaryDetach()
		{
			base.dispatchStartTemporaryDetach();
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchStartTemporaryDetach();
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchFinishTemporaryDetach()
		{
			base.dispatchFinishTemporaryDetach();
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchFinishTemporaryDetach();
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override void dispatchAttachedToWindow(android.view.View.AttachInfo info
			, int visibility)
		{
			mGroupFlags |= FLAG_PREVENT_DISPATCH_ATTACHED_TO_WINDOW;
			base.dispatchAttachedToWindow(info, visibility);
			mGroupFlags &= ~FLAG_PREVENT_DISPATCH_ATTACHED_TO_WINDOW;
			visibility |= mViewFlags & VISIBILITY_MASK;
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchAttachedToWindow(info, visibility);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override bool dispatchPopulateAccessibilityEventInternal(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			bool handled = base.dispatchPopulateAccessibilityEventInternal(@event);
			if (handled)
			{
				return handled;
			}
			{
				int i = 0;
				int count = getChildCount();
				// Let our children have a shot in populating the event.
				for (; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE)
					{
						handled = getChildAt(i).dispatchPopulateAccessibilityEvent(@event);
						if (handled)
						{
							return handled;
						}
					}
				}
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override void onInitializeAccessibilityNodeInfoInternal(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			base.onInitializeAccessibilityNodeInfoInternal(info);
			// If the view is not the topmost one in the view hierarchy and it is
			// marked as the logical root of a view hierarchy, do not go any deeper.
			if ((!(getParent() is android.view.ViewRootImpl)) && (mPrivateFlags & IS_ROOT_NAMESPACE
				) != 0)
			{
				return;
			}
			{
				int i = 0;
				int count = mChildrenCount;
				for (; i < count; i++)
				{
					android.view.View child = mChildren[i];
					if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE)
					{
						info.addChild(child);
					}
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override void dispatchDetachedFromWindow()
		{
			// If we still have a touch target, we are still in the process of
			// dispatching motion events to a child; we need to get rid of that
			// child to avoid dispatching events to it after the window is torn
			// down. To make sure we keep the child in a consistent state, we
			// first send it an ACTION_CANCEL motion event.
			cancelAndClearTouchTargets(null);
			// In case view is detached while transition is running
			mLayoutSuppressed = false;
			// Tear down our drag tracking
			mDragNotifiedChildren = null;
			if (mCurrentDrag != null)
			{
				mCurrentDrag.recycle();
				mCurrentDrag = null;
			}
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].dispatchDetachedFromWindow();
				}
			}
			base.dispatchDetachedFromWindow();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setPadding(int left, int top, int right, int bottom)
		{
			base.setPadding(left, top, right, bottom);
			if ((mPaddingLeft | mPaddingTop | mPaddingRight | mPaddingBottom) != 0)
			{
				mGroupFlags |= FLAG_PADDING_NOT_NULL;
			}
			else
			{
				mGroupFlags &= ~FLAG_PADDING_NOT_NULL;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSaveInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			base.dispatchSaveInstanceState(container);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View c = children[i];
					if ((c.mViewFlags & PARENT_SAVE_DISABLED_MASK) != PARENT_SAVE_DISABLED)
					{
						c.dispatchSaveInstanceState(container);
					}
				}
			}
		}

		/// <summary>
		/// Perform dispatching of a
		/// <see cref="View.saveHierarchyState(android.util.SparseArray{E})">View.saveHierarchyState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// freeze()}
		/// to only this view, not to its children.  For use when overriding
		/// <see cref="dispatchSaveInstanceState(android.util.SparseArray{E})">dispatchSaveInstanceState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// dispatchFreeze()} to allow
		/// subclasses to freeze their own state but not the state of their children.
		/// </summary>
		/// <param name="container">the container</param>
		protected internal virtual void dispatchFreezeSelfOnly(android.util.SparseArray<android.os.Parcelable
			> container)
		{
			base.dispatchSaveInstanceState(container);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchRestoreInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			base.dispatchRestoreInstanceState(container);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View c = children[i];
					if ((c.mViewFlags & PARENT_SAVE_DISABLED_MASK) != PARENT_SAVE_DISABLED)
					{
						c.dispatchRestoreInstanceState(container);
					}
				}
			}
		}

		/// <summary>
		/// Perform dispatching of a
		/// <see cref="View.restoreHierarchyState(android.util.SparseArray{E})">View.restoreHierarchyState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// to only this view, not to its children.  For use when overriding
		/// <see cref="dispatchRestoreInstanceState(android.util.SparseArray{E})">dispatchRestoreInstanceState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// to allow
		/// subclasses to thaw their own state but not the state of their children.
		/// </summary>
		/// <param name="container">the container</param>
		protected internal virtual void dispatchThawSelfOnly(android.util.SparseArray<android.os.Parcelable
			> container)
		{
			base.dispatchRestoreInstanceState(container);
		}

		/// <summary>Enables or disables the drawing cache for each child of this view group.
		/// 	</summary>
		/// <remarks>Enables or disables the drawing cache for each child of this view group.
		/// 	</remarks>
		/// <param name="enabled">true to enable the cache, false to dispose of it</param>
		protected internal virtual void setChildrenDrawingCacheEnabled(bool enabled)
		{
			if (enabled || (mPersistentDrawingCache & PERSISTENT_ALL_CACHES) != PERSISTENT_ALL_CACHES)
			{
				android.view.View[] children = mChildren;
				int count = mChildrenCount;
				{
					for (int i = 0; i < count; i++)
					{
						children[i].setDrawingCacheEnabled(enabled);
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAnimationStart()
		{
			base.onAnimationStart();
			// When this ViewGroup's animation starts, build the cache for the children
			if ((mGroupFlags & FLAG_ANIMATION_CACHE) == FLAG_ANIMATION_CACHE)
			{
				int count = mChildrenCount;
				android.view.View[] children = mChildren;
				bool buildCache = !isHardwareAccelerated();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = children[i];
						if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE)
						{
							child.setDrawingCacheEnabled(true);
							if (buildCache)
							{
								child.buildDrawingCache(true);
							}
						}
					}
				}
				mGroupFlags |= FLAG_CHILDREN_DRAWN_WITH_CACHE;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAnimationEnd()
		{
			base.onAnimationEnd();
			// When this ViewGroup's animation ends, destroy the cache of the children
			if ((mGroupFlags & FLAG_ANIMATION_CACHE) == FLAG_ANIMATION_CACHE)
			{
				mGroupFlags &= ~FLAG_CHILDREN_DRAWN_WITH_CACHE;
				if ((mPersistentDrawingCache & PERSISTENT_ANIMATION_CACHE) == 0)
				{
					setChildrenDrawingCacheEnabled(false);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		internal override android.graphics.Bitmap createSnapshot(android.graphics.Bitmap.
			Config quality, int backgroundColor, bool skipChildren)
		{
			int count = mChildrenCount;
			int[] visibilities = null;
			if (skipChildren)
			{
				visibilities = new int[count];
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = getChildAt(i);
						visibilities[i] = child.getVisibility();
						if (visibilities[i] == android.view.View.VISIBLE)
						{
							child.setVisibility(INVISIBLE);
						}
					}
				}
			}
			android.graphics.Bitmap b = base.createSnapshot(quality, backgroundColor, skipChildren
				);
			if (skipChildren)
			{
				{
					for (int i = 0; i < count; i++)
					{
						getChildAt(i).setVisibility(visibilities[i]);
					}
				}
			}
			return b;
		}

		private sealed class _Runnable_2535 : java.lang.Runnable
		{
			public _Runnable_2535(ViewGroup _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// We will draw our child's animation, let's reset the flag
			// Draw any disappearing views that have animations
			// Go backwards -- we may delete as animations finish
			// mGroupFlags might have been updated by drawChild()
			// We want to erase the drawing cache and notify the listener after the
			// next frame is drawn because one extra invalidate() is caused by
			// drawChild() after the animation is over
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.notifyAnimationListener();
			}

			private readonly ViewGroup _enclosing;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			int flags = mGroupFlags;
			if ((flags & FLAG_RUN_ANIMATION) != 0 && canAnimate())
			{
				bool cache = (mGroupFlags & FLAG_ANIMATION_CACHE) == FLAG_ANIMATION_CACHE;
				bool buildCache = !isHardwareAccelerated();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = children[i];
						if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE)
						{
							android.view.ViewGroup.LayoutParams @params = child.getLayoutParams();
							attachLayoutAnimationParameters(child, @params, i, count);
							bindLayoutAnimation(child);
							if (cache)
							{
								child.setDrawingCacheEnabled(true);
								if (buildCache)
								{
									child.buildDrawingCache(true);
								}
							}
						}
					}
				}
				android.view.animation.LayoutAnimationController controller = mLayoutAnimationController;
				if (controller.willOverlap())
				{
					mGroupFlags |= FLAG_OPTIMIZE_INVALIDATE;
				}
				controller.start();
				mGroupFlags &= ~FLAG_RUN_ANIMATION;
				mGroupFlags &= ~FLAG_ANIMATION_DONE;
				if (cache)
				{
					mGroupFlags |= FLAG_CHILDREN_DRAWN_WITH_CACHE;
				}
				if (mAnimationListener != null)
				{
					mAnimationListener.onAnimationStart(controller.getAnimation());
				}
			}
			int saveCount = 0;
			bool clipToPadding = (flags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK;
			if (clipToPadding)
			{
				saveCount = canvas.save();
				canvas.clipRect(mScrollX + mPaddingLeft, mScrollY + mPaddingTop, mScrollX + mRight
					 - mLeft - mPaddingRight, mScrollY + mBottom - mTop - mPaddingBottom);
			}
			mPrivateFlags &= ~DRAW_ANIMATION;
			mGroupFlags &= ~FLAG_INVALIDATE_REQUIRED;
			bool more = false;
			long drawingTime = getDrawingTime();
			if ((flags & FLAG_USE_CHILD_DRAWING_ORDER) == 0)
			{
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = children[i];
						if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE || child.getAnimation() != null)
						{
							more |= drawChild(canvas, child, drawingTime);
						}
					}
				}
			}
			else
			{
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = children[getChildDrawingOrder(count, i)];
						if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE || child.getAnimation() != null)
						{
							more |= drawChild(canvas, child, drawingTime);
						}
					}
				}
			}
			if (mDisappearingChildren != null)
			{
				java.util.ArrayList<android.view.View> disappearingChildren = mDisappearingChildren;
				int disappearingCount = disappearingChildren.size() - 1;
				{
					for (int i = disappearingCount; i >= 0; i--)
					{
						android.view.View child = disappearingChildren.get(i);
						more |= drawChild(canvas, child, drawingTime);
					}
				}
			}
			if (clipToPadding)
			{
				canvas.restoreToCount(saveCount);
			}
			flags = mGroupFlags;
			if ((flags & FLAG_INVALIDATE_REQUIRED) == FLAG_INVALIDATE_REQUIRED)
			{
				invalidate(true);
			}
			if ((flags & FLAG_ANIMATION_DONE) == 0 && (flags & FLAG_NOTIFY_ANIMATION_LISTENER
				) == 0 && mLayoutAnimationController.isDone() && !more)
			{
				mGroupFlags |= FLAG_NOTIFY_ANIMATION_LISTENER;
				java.lang.Runnable end = new _Runnable_2535(this);
				post(end);
			}
		}

		/// <summary>Returns the index of the child to draw for this iteration.</summary>
		/// <remarks>
		/// Returns the index of the child to draw for this iteration. Override this
		/// if you want to change the drawing order of children. By default, it
		/// returns i.
		/// <p>
		/// NOTE: In order for this method to be called, you must enable child ordering
		/// first by calling
		/// <see cref="setChildrenDrawingOrderEnabled(bool)">setChildrenDrawingOrderEnabled(bool)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="i">The current iteration.</param>
		/// <returns>The index of the child to draw this iteration.</returns>
		/// <seealso cref="setChildrenDrawingOrderEnabled(bool)">setChildrenDrawingOrderEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="isChildrenDrawingOrderEnabled()">isChildrenDrawingOrderEnabled()</seealso>
		protected internal virtual int getChildDrawingOrder(int childCount, int i)
		{
			return i;
		}

		private sealed class _Runnable_2567 : java.lang.Runnable
		{
			public _Runnable_2567(ViewGroup _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.mAnimationListener.onAnimationEnd(this._enclosing.mLayoutAnimationController
					.getAnimation());
			}

			private readonly ViewGroup _enclosing;
		}

		private void notifyAnimationListener()
		{
			mGroupFlags &= ~FLAG_NOTIFY_ANIMATION_LISTENER;
			mGroupFlags |= FLAG_ANIMATION_DONE;
			if (mAnimationListener != null)
			{
				java.lang.Runnable end = new _Runnable_2567(this);
				post(end);
			}
			if ((mGroupFlags & FLAG_ANIMATION_CACHE) == FLAG_ANIMATION_CACHE)
			{
				mGroupFlags &= ~FLAG_CHILDREN_DRAWN_WITH_CACHE;
				if ((mPersistentDrawingCache & PERSISTENT_ANIMATION_CACHE) == 0)
				{
					setChildrenDrawingCacheEnabled(false);
				}
			}
			invalidate(true);
		}

		/// <summary>
		/// This method is used to cause children of this ViewGroup to restore or recreate their
		/// display lists.
		/// </summary>
		/// <remarks>
		/// This method is used to cause children of this ViewGroup to restore or recreate their
		/// display lists. It is called by getDisplayList() when the parent ViewGroup does not need
		/// to recreate its own display list, which would happen if it went through the normal
		/// draw/dispatchDraw mechanisms.
		/// </remarks>
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchGetDisplayList()
		{
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = children[i];
					if (((child.mViewFlags & VISIBILITY_MASK) == VISIBLE || child.getAnimation() != null
						) && child.hasStaticLayer())
					{
						child.mRecreateDisplayList = (child.mPrivateFlags & INVALIDATED) == INVALIDATED;
						child.mPrivateFlags &= ~INVALIDATED;
						child.getDisplayList();
						child.mRecreateDisplayList = false;
					}
				}
			}
		}

		/// <summary>Draw one child of this View Group.</summary>
		/// <remarks>
		/// Draw one child of this View Group. This method is responsible for getting
		/// the canvas in the right state. This includes clipping, translating so
		/// that the child's scrolled origin is at 0, 0, and applying any animation
		/// transformations.
		/// </remarks>
		/// <param name="canvas">The canvas on which to draw the child</param>
		/// <param name="child">Who to draw</param>
		/// <param name="drawingTime">The time at which draw is occuring</param>
		/// <returns>True if an invalidate() was issued</returns>
		protected internal virtual bool drawChild(android.graphics.Canvas canvas, android.view.View
			 child, long drawingTime)
		{
			bool more = false;
			int cl = child.mLeft;
			int ct = child.mTop;
			int cr = child.mRight;
			int cb = child.mBottom;
			bool childHasIdentityMatrix = child.hasIdentityMatrix();
			int flags = mGroupFlags;
			if ((flags & FLAG_CLEAR_TRANSFORMATION) == FLAG_CLEAR_TRANSFORMATION)
			{
				mChildTransformation.clear();
				mGroupFlags &= ~FLAG_CLEAR_TRANSFORMATION;
			}
			android.view.animation.Transformation transformToApply = null;
			android.view.animation.Transformation invalidationTransform;
			android.view.animation.Animation a = child.getAnimation();
			bool concatMatrix = false;
			bool scalingRequired = false;
			bool caching;
			int layerType = mDrawLayers ? child.getLayerType() : LAYER_TYPE_NONE;
			bool hardwareAccelerated = canvas.isHardwareAccelerated();
			if ((flags & FLAG_CHILDREN_DRAWN_WITH_CACHE) == FLAG_CHILDREN_DRAWN_WITH_CACHE ||
				 (flags & FLAG_ALWAYS_DRAWN_WITH_CACHE) == FLAG_ALWAYS_DRAWN_WITH_CACHE)
			{
				caching = true;
				if (mAttachInfo != null)
				{
					scalingRequired = mAttachInfo.mScalingRequired;
				}
			}
			else
			{
				caching = (layerType != LAYER_TYPE_NONE) || hardwareAccelerated;
			}
			if (a != null)
			{
				bool initialized = a.isInitialized();
				if (!initialized)
				{
					a.initialize(cr - cl, cb - ct, getWidth(), getHeight());
					a.initializeInvalidateRegion(0, 0, cr - cl, cb - ct);
					child.onAnimationStart();
				}
				more = a.getTransformation(drawingTime, mChildTransformation, scalingRequired ? mAttachInfo
					.mApplicationScale : 1f);
				if (scalingRequired && mAttachInfo.mApplicationScale != 1f)
				{
					if (mInvalidationTransformation == null)
					{
						mInvalidationTransformation = new android.view.animation.Transformation();
					}
					invalidationTransform = mInvalidationTransformation;
					a.getTransformation(drawingTime, invalidationTransform, 1f);
				}
				else
				{
					invalidationTransform = mChildTransformation;
				}
				transformToApply = mChildTransformation;
				concatMatrix = a.willChangeTransformationMatrix();
				if (more)
				{
					if (!a.willChangeBounds())
					{
						if ((flags & (FLAG_OPTIMIZE_INVALIDATE | FLAG_ANIMATION_DONE)) == FLAG_OPTIMIZE_INVALIDATE)
						{
							mGroupFlags |= FLAG_INVALIDATE_REQUIRED;
						}
						else
						{
							if ((flags & FLAG_INVALIDATE_REQUIRED) == 0)
							{
								// The child need to draw an animation, potentially offscreen, so
								// make sure we do not cancel invalidate requests
								mPrivateFlags |= DRAW_ANIMATION;
								invalidate(cl, ct, cr, cb);
							}
						}
					}
					else
					{
						if (mInvalidateRegion == null)
						{
							mInvalidateRegion = new android.graphics.RectF();
						}
						android.graphics.RectF region = mInvalidateRegion;
						a.getInvalidateRegion(0, 0, cr - cl, cb - ct, region, invalidationTransform);
						// The child need to draw an animation, potentially offscreen, so
						// make sure we do not cancel invalidate requests
						mPrivateFlags |= DRAW_ANIMATION;
						int left = cl + (int)region.left;
						int top = ct + (int)region.top;
						invalidate(left, top, left + (int)(region.width() + .5f), top + (int)(region.height
							() + .5f));
					}
				}
			}
			else
			{
				if ((flags & FLAG_SUPPORT_STATIC_TRANSFORMATIONS) == FLAG_SUPPORT_STATIC_TRANSFORMATIONS)
				{
					bool hasTransform = getChildStaticTransformation(child, mChildTransformation);
					if (hasTransform)
					{
						int transformType = mChildTransformation.getTransformationType();
						transformToApply = transformType != android.view.animation.Transformation.TYPE_IDENTITY
							 ? mChildTransformation : null;
						concatMatrix = (transformType & android.view.animation.Transformation.TYPE_MATRIX
							) != 0;
					}
				}
			}
			concatMatrix |= !childHasIdentityMatrix;
			// Sets the flag as early as possible to allow draw() implementations
			// to call invalidate() successfully when doing animations
			child.mPrivateFlags |= DRAWN;
			if (!concatMatrix && canvas.quickReject(cl, ct, cr, cb, android.graphics.Canvas.EdgeType
				.BW) && (child.mPrivateFlags & DRAW_ANIMATION) == 0)
			{
				return more;
			}
			float alpha = child.getAlpha();
			// Bail out early if the view does not need to be drawn
			if (alpha <= android.view.ViewConfiguration.ALPHA_THRESHOLD && (child.mPrivateFlags
				 & ALPHA_SET) == 0 && !(child is android.view.SurfaceView))
			{
				return more;
			}
			if (hardwareAccelerated)
			{
				// Clear INVALIDATED flag to allow invalidation to occur during rendering, but
				// retain the flag's value temporarily in the mRecreateDisplayList flag
				child.mRecreateDisplayList = (child.mPrivateFlags & INVALIDATED) == INVALIDATED;
				child.mPrivateFlags &= ~INVALIDATED;
			}
			child.computeScroll();
			int sx = child.mScrollX;
			int sy = child.mScrollY;
			android.view.DisplayList displayList = null;
			android.graphics.Bitmap cache = null;
			bool hasDisplayList = false;
			if (caching)
			{
				if (!hardwareAccelerated)
				{
					if (layerType != LAYER_TYPE_NONE)
					{
						layerType = LAYER_TYPE_SOFTWARE;
						child.buildDrawingCache(true);
					}
					cache = child.getDrawingCache(true);
				}
				else
				{
					switch (layerType)
					{
						case LAYER_TYPE_SOFTWARE:
						{
							child.buildDrawingCache(true);
							cache = child.getDrawingCache(true);
							break;
						}

						case LAYER_TYPE_NONE:
						{
							// Delay getting the display list until animation-driven alpha values are
							// set up and possibly passed on to the view
							hasDisplayList = child.canHaveDisplayList();
							break;
						}
					}
				}
			}
			bool hasNoCache = cache == null || hasDisplayList;
			bool offsetForScroll = cache == null && !hasDisplayList && layerType != LAYER_TYPE_HARDWARE;
			int restoreTo = canvas.save();
			if (offsetForScroll)
			{
				canvas.translate(cl - sx, ct - sy);
			}
			else
			{
				canvas.translate(cl, ct);
				if (scalingRequired)
				{
					// mAttachInfo cannot be null, otherwise scalingRequired == false
					float scale = 1.0f / mAttachInfo.mApplicationScale;
					canvas.scale(scale, scale);
				}
			}
			if (transformToApply != null || alpha < 1.0f || !child.hasIdentityMatrix())
			{
				if (transformToApply != null || !childHasIdentityMatrix)
				{
					int transX = 0;
					int transY = 0;
					if (offsetForScroll)
					{
						transX = -sx;
						transY = -sy;
					}
					if (transformToApply != null)
					{
						if (concatMatrix)
						{
							// Undo the scroll translation, apply the transformation matrix,
							// then redo the scroll translate to get the correct result.
							canvas.translate(-transX, -transY);
							canvas.concat(transformToApply.getMatrix());
							canvas.translate(transX, transY);
							mGroupFlags |= FLAG_CLEAR_TRANSFORMATION;
						}
						float transformAlpha = transformToApply.getAlpha();
						if (transformAlpha < 1.0f)
						{
							alpha *= transformToApply.getAlpha();
							mGroupFlags |= FLAG_CLEAR_TRANSFORMATION;
						}
					}
					if (!childHasIdentityMatrix)
					{
						canvas.translate(-transX, -transY);
						canvas.concat(child.getMatrix());
						canvas.translate(transX, transY);
					}
				}
				if (alpha < 1.0f)
				{
					mGroupFlags |= FLAG_CLEAR_TRANSFORMATION;
					if (hasNoCache)
					{
						int multipliedAlpha = (int)(255 * alpha);
						if (!child.onSetAlpha(multipliedAlpha))
						{
							int layerFlags = android.graphics.Canvas.HAS_ALPHA_LAYER_SAVE_FLAG;
							if ((flags & FLAG_CLIP_CHILDREN) == FLAG_CLIP_CHILDREN || layerType != LAYER_TYPE_NONE)
							{
								layerFlags |= android.graphics.Canvas.CLIP_TO_LAYER_SAVE_FLAG;
							}
							if (layerType == LAYER_TYPE_NONE)
							{
								int scrollX = hasDisplayList ? 0 : sx;
								int scrollY = hasDisplayList ? 0 : sy;
								canvas.saveLayerAlpha(scrollX, scrollY, scrollX + cr - cl, scrollY + cb - ct, multipliedAlpha
									, layerFlags);
							}
						}
						else
						{
							// Alpha is handled by the child directly, clobber the layer's alpha
							child.mPrivateFlags |= ALPHA_SET;
						}
					}
				}
			}
			else
			{
				if ((child.mPrivateFlags & ALPHA_SET) == ALPHA_SET)
				{
					child.onSetAlpha(255);
					child.mPrivateFlags &= ~ALPHA_SET;
				}
			}
			if ((flags & FLAG_CLIP_CHILDREN) == FLAG_CLIP_CHILDREN)
			{
				if (offsetForScroll)
				{
					canvas.clipRect(sx, sy, sx + (cr - cl), sy + (cb - ct));
				}
				else
				{
					if (!scalingRequired || cache == null)
					{
						canvas.clipRect(0, 0, cr - cl, cb - ct);
					}
					else
					{
						canvas.clipRect(0, 0, cache.getWidth(), cache.getHeight());
					}
				}
			}
			if (hasDisplayList)
			{
				displayList = child.getDisplayList();
				if (!displayList.isValid())
				{
					// Uncommon, but possible. If a view is removed from the hierarchy during the call
					// to getDisplayList(), the display list will be marked invalid and we should not
					// try to use it again.
					displayList = null;
					hasDisplayList = false;
				}
			}
			if (hasNoCache)
			{
				bool layerRendered = false;
				if (layerType == LAYER_TYPE_HARDWARE)
				{
					android.view.HardwareLayer layer = child.getHardwareLayer();
					if (layer != null && layer.isValid())
					{
						child.mLayerPaint.setAlpha((int)(alpha * 255));
						((android.view.HardwareCanvas)canvas).drawHardwareLayer(layer, 0, 0, child.mLayerPaint
							);
						layerRendered = true;
					}
					else
					{
						int scrollX = hasDisplayList ? 0 : sx;
						int scrollY = hasDisplayList ? 0 : sy;
						canvas.saveLayer(scrollX, scrollY, scrollX + cr - cl, scrollY + cb - ct, child.mLayerPaint
							, android.graphics.Canvas.HAS_ALPHA_LAYER_SAVE_FLAG | android.graphics.Canvas.CLIP_TO_LAYER_SAVE_FLAG
							);
					}
				}
				if (!layerRendered)
				{
					if (!hasDisplayList)
					{
						// Fast path for layouts with no backgrounds
						if ((child.mPrivateFlags & SKIP_DRAW) == SKIP_DRAW)
						{
							child.mPrivateFlags &= ~DIRTY_MASK;
							child.dispatchDraw(canvas);
						}
						else
						{
							child.draw(canvas);
						}
					}
					else
					{
						child.mPrivateFlags &= ~DIRTY_MASK;
						((android.view.HardwareCanvas)canvas).drawDisplayList(displayList, cr - cl, cb - 
							ct, null);
					}
				}
			}
			else
			{
				if (cache != null)
				{
					child.mPrivateFlags &= ~DIRTY_MASK;
					android.graphics.Paint cachePaint;
					if (layerType == LAYER_TYPE_NONE)
					{
						cachePaint = mCachePaint;
						if (alpha < 1.0f)
						{
							cachePaint.setAlpha((int)(alpha * 255));
							mGroupFlags |= FLAG_ALPHA_LOWER_THAN_ONE;
						}
						else
						{
							if ((flags & FLAG_ALPHA_LOWER_THAN_ONE) == FLAG_ALPHA_LOWER_THAN_ONE)
							{
								cachePaint.setAlpha(255);
								mGroupFlags &= ~FLAG_ALPHA_LOWER_THAN_ONE;
							}
						}
					}
					else
					{
						cachePaint = child.mLayerPaint;
						cachePaint.setAlpha((int)(alpha * 255));
					}
					canvas.drawBitmap(cache, 0.0f, 0.0f, cachePaint);
				}
			}
			canvas.restoreToCount(restoreTo);
			if (a != null && !more)
			{
				if (!hardwareAccelerated && !a.getFillAfter())
				{
					child.onSetAlpha(255);
				}
				finishAnimatingView(child, a);
			}
			if (more && hardwareAccelerated)
			{
				// invalidation is the trigger to recreate display lists, so if we're using
				// display lists to render, force an invalidate to allow the animation to
				// continue drawing another frame
				invalidate(true);
				if (a.hasAlpha() && (child.mPrivateFlags & ALPHA_SET) == ALPHA_SET)
				{
					// alpha animations should cause the child to recreate its display list
					child.invalidate(true);
				}
			}
			child.mRecreateDisplayList = false;
			return more;
		}

		/// <param name="enabled">True if children should be drawn with layers, false otherwise.
		/// 	</param>
		/// <hide></hide>
		public virtual void setChildrenLayersEnabled(bool enabled)
		{
			if (enabled != mDrawLayers)
			{
				mDrawLayers = enabled;
				invalidate(true);
				{
					// We need to invalidate any child with a layer. For instance,
					// if a child is backed by a hardware layer and we disable layers
					// the child is marked as not dirty (flags cleared the last time
					// the child was drawn inside its layer.) However, that child might
					// never have created its own display list or have an obsolete
					// display list. By invalidating the child we ensure the display
					// list is in sync with the content of the hardware layer.
					for (int i = 0; i < mChildrenCount; i++)
					{
						android.view.View child = mChildren[i];
						if (child.mLayerType != LAYER_TYPE_NONE)
						{
							child.invalidate(true);
						}
					}
				}
			}
		}

		/// <summary>By default, children are clipped to their bounds before drawing.</summary>
		/// <remarks>
		/// By default, children are clipped to their bounds before drawing. This
		/// allows view groups to override this behavior for animations, etc.
		/// </remarks>
		/// <param name="clipChildren">
		/// true to clip children to their bounds,
		/// false otherwise
		/// </param>
		/// <attr>ref android.R.styleable#ViewGroup_clipChildren</attr>
		public virtual void setClipChildren(bool clipChildren)
		{
			setBooleanFlag(FLAG_CLIP_CHILDREN, clipChildren);
		}

		/// <summary>By default, children are clipped to the padding of the ViewGroup.</summary>
		/// <remarks>
		/// By default, children are clipped to the padding of the ViewGroup. This
		/// allows view groups to override this behavior
		/// </remarks>
		/// <param name="clipToPadding">
		/// true to clip children to the padding of the
		/// group, false otherwise
		/// </param>
		/// <attr>ref android.R.styleable#ViewGroup_clipToPadding</attr>
		public virtual void setClipToPadding(bool clipToPadding)
		{
			setBooleanFlag(FLAG_CLIP_TO_PADDING, clipToPadding);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSetSelected(bool selected)
		{
			android.view.View[] children = mChildren;
			int count = mChildrenCount;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].setSelected(selected);
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSetActivated(bool activated)
		{
			android.view.View[] children = mChildren;
			int count = mChildrenCount;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].setActivated(activated);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSetPressed(bool pressed)
		{
			android.view.View[] children = mChildren;
			int count = mChildrenCount;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].setPressed(pressed);
				}
			}
		}

		/// <summary>
		/// When this property is set to true, this ViewGroup supports static transformations on
		/// children; this causes
		/// <see cref="getChildStaticTransformation(View, android.view.animation.Transformation)
		/// 	">getChildStaticTransformation(View, android.view.animation.Transformation)</see>
		/// to be
		/// invoked when a child is drawn.
		/// Any subclass overriding
		/// <see cref="getChildStaticTransformation(View, android.view.animation.Transformation)
		/// 	">getChildStaticTransformation(View, android.view.animation.Transformation)</see>
		/// should
		/// set this property to true.
		/// </summary>
		/// <param name="enabled">True to enable static transformations on children, false otherwise.
		/// 	</param>
		/// <seealso cref="FLAG_SUPPORT_STATIC_TRANSFORMATIONS">FLAG_SUPPORT_STATIC_TRANSFORMATIONS
		/// 	</seealso>
		protected internal virtual void setStaticTransformationsEnabled(bool enabled)
		{
			setBooleanFlag(FLAG_SUPPORT_STATIC_TRANSFORMATIONS, enabled);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <seealso cref="setStaticTransformationsEnabled(bool)">setStaticTransformationsEnabled(bool)
		/// 	</seealso>
		protected internal virtual bool getChildStaticTransformation(android.view.View child
			, android.view.animation.Transformation t)
		{
			return false;
		}

		/// <summary><hide></hide></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.View findViewTraversal(int id)
		{
			if (id == mID)
			{
				return this;
			}
			android.view.View[] where = mChildren;
			int len = mChildrenCount;
			{
				for (int i = 0; i < len; i++)
				{
					android.view.View v = where[i];
					if ((v.mPrivateFlags & IS_ROOT_NAMESPACE) == 0)
					{
						v = v.findViewById(id);
						if (v != null)
						{
							return v;
						}
					}
				}
			}
			return null;
		}

		/// <summary><hide></hide></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.View findViewWithTagTraversal(object tag
			)
		{
			if (tag != null && tag.Equals(mTag))
			{
				return this;
			}
			android.view.View[] where = mChildren;
			int len = mChildrenCount;
			{
				for (int i = 0; i < len; i++)
				{
					android.view.View v = where[i];
					if ((v.mPrivateFlags & IS_ROOT_NAMESPACE) == 0)
					{
						v = v.findViewWithTag(tag);
						if (v != null)
						{
							return v;
						}
					}
				}
			}
			return null;
		}

		/// <summary><hide></hide></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.View findViewByPredicateTraversal(android.util.@internal.Predicate
			<android.view.View> predicate, android.view.View childToSkip)
		{
			if (predicate.apply(this))
			{
				return this;
			}
			android.view.View[] where = mChildren;
			int len = mChildrenCount;
			{
				for (int i = 0; i < len; i++)
				{
					android.view.View v = where[i];
					if (v != childToSkip && (v.mPrivateFlags & IS_ROOT_NAMESPACE) == 0)
					{
						v = v.findViewByPredicate(predicate);
						if (v != null)
						{
							return v;
						}
					}
				}
			}
			return null;
		}

		/// <summary>Adds a child view.</summary>
		/// <remarks>
		/// Adds a child view. If no layout parameters are already set on the child, the
		/// default parameters for this ViewGroup are set on the child.
		/// </remarks>
		/// <param name="child">the child view to add</param>
		/// <seealso cref="generateDefaultLayoutParams()">generateDefaultLayoutParams()</seealso>
		public virtual void addView(android.view.View child)
		{
			addView(child, -1);
		}

		/// <summary>Adds a child view.</summary>
		/// <remarks>
		/// Adds a child view. If no layout parameters are already set on the child, the
		/// default parameters for this ViewGroup are set on the child.
		/// </remarks>
		/// <param name="child">the child view to add</param>
		/// <param name="index">the position at which to add the child</param>
		/// <seealso cref="generateDefaultLayoutParams()">generateDefaultLayoutParams()</seealso>
		public virtual void addView(android.view.View child, int index)
		{
			android.view.ViewGroup.LayoutParams @params = child.getLayoutParams();
			if (@params == null)
			{
				@params = generateDefaultLayoutParams();
				if (@params == null)
				{
					throw new System.ArgumentException("generateDefaultLayoutParams() cannot return null"
						);
				}
			}
			addView(child, index, @params);
		}

		/// <summary>
		/// Adds a child view with this ViewGroup's default layout parameters and the
		/// specified width and height.
		/// </summary>
		/// <remarks>
		/// Adds a child view with this ViewGroup's default layout parameters and the
		/// specified width and height.
		/// </remarks>
		/// <param name="child">the child view to add</param>
		public virtual void addView(android.view.View child, int width, int height)
		{
			android.view.ViewGroup.LayoutParams @params = generateDefaultLayoutParams();
			@params.width = width;
			@params.height = height;
			addView(child, -1, @params);
		}

		/// <summary>Adds a child view with the specified layout parameters.</summary>
		/// <remarks>Adds a child view with the specified layout parameters.</remarks>
		/// <param name="child">the child view to add</param>
		/// <param name="params">the layout parameters to set on the child</param>
		[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
		public virtual void addView(android.view.View child, android.view.ViewGroup.LayoutParams
			 @params)
		{
			addView(child, -1, @params);
		}

		/// <summary>Adds a child view with the specified layout parameters.</summary>
		/// <remarks>Adds a child view with the specified layout parameters.</remarks>
		/// <param name="child">the child view to add</param>
		/// <param name="index">the position at which to add the child</param>
		/// <param name="params">the layout parameters to set on the child</param>
		public virtual void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			// addViewInner() will call child.requestLayout() when setting the new LayoutParams
			// therefore, we call requestLayout() on ourselves before, so that the child's request
			// will be blocked at our level
			requestLayout();
			invalidate(true);
			addViewInner(child, index, @params, false);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
		public virtual void updateViewLayout(android.view.View view, android.view.ViewGroup
			.LayoutParams @params)
		{
			if (!checkLayoutParams(@params))
			{
				throw new System.ArgumentException("Invalid LayoutParams supplied to " + this);
			}
			if (view.mParent != this)
			{
				throw new System.ArgumentException("Given view not a child of " + this);
			}
			view.setLayoutParams(@params);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		protected internal virtual bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p != null;
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the hierarchy
		/// within this view changed.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the hierarchy
		/// within this view changed. The hierarchy changes whenever a child is added
		/// to or removed from this view.
		/// </remarks>
		public interface OnHierarchyChangeListener
		{
			/// <summary>Called when a new child is added to a parent view.</summary>
			/// <remarks>Called when a new child is added to a parent view.</remarks>
			/// <param name="parent">the view in which a child was added</param>
			/// <param name="child">the new child view added in the hierarchy</param>
			void onChildViewAdded(android.view.View parent, android.view.View child);

			/// <summary>Called when a child is removed from a parent view.</summary>
			/// <remarks>Called when a child is removed from a parent view.</remarks>
			/// <param name="parent">the view from which the child was removed</param>
			/// <param name="child">the child removed from the hierarchy</param>
			void onChildViewRemoved(android.view.View parent, android.view.View child);
		}

		/// <summary>
		/// Register a callback to be invoked when a child is added to or removed
		/// from this view.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when a child is added to or removed
		/// from this view.
		/// </remarks>
		/// <param name="listener">the callback to invoke on hierarchy change</param>
		public virtual void setOnHierarchyChangeListener(android.view.ViewGroup.OnHierarchyChangeListener
			 listener)
		{
			mOnHierarchyChangeListener = listener;
		}

		/// <hide></hide>
		protected internal virtual void onViewAdded(android.view.View child)
		{
			if (mOnHierarchyChangeListener != null)
			{
				mOnHierarchyChangeListener.onChildViewAdded(this, child);
			}
		}

		/// <hide></hide>
		protected internal virtual void onViewRemoved(android.view.View child)
		{
			if (mOnHierarchyChangeListener != null)
			{
				mOnHierarchyChangeListener.onChildViewRemoved(this, child);
			}
		}

		/// <summary>Adds a view during layout.</summary>
		/// <remarks>
		/// Adds a view during layout. This is useful if in your onLayout() method,
		/// you need to add more views (as does the list view for example).
		/// If index is negative, it means put it at the end of the list.
		/// </remarks>
		/// <param name="child">the view to add to the group</param>
		/// <param name="index">the index at which the child must be added</param>
		/// <param name="params">the layout parameters to associate with the child</param>
		/// <returns>true if the child was added, false otherwise</returns>
		protected internal virtual bool addViewInLayout(android.view.View child, int index
			, android.view.ViewGroup.LayoutParams @params)
		{
			return addViewInLayout(child, index, @params, false);
		}

		/// <summary>Adds a view during layout.</summary>
		/// <remarks>
		/// Adds a view during layout. This is useful if in your onLayout() method,
		/// you need to add more views (as does the list view for example).
		/// If index is negative, it means put it at the end of the list.
		/// </remarks>
		/// <param name="child">the view to add to the group</param>
		/// <param name="index">the index at which the child must be added</param>
		/// <param name="params">the layout parameters to associate with the child</param>
		/// <param name="preventRequestLayout">
		/// if true, calling this method will not trigger a
		/// layout request on child
		/// </param>
		/// <returns>true if the child was added, false otherwise</returns>
		protected internal virtual bool addViewInLayout(android.view.View child, int index
			, android.view.ViewGroup.LayoutParams @params, bool preventRequestLayout)
		{
			child.mParent = null;
			addViewInner(child, index, @params, preventRequestLayout);
			child.mPrivateFlags = (child.mPrivateFlags & ~DIRTY_MASK) | DRAWN;
			return true;
		}

		/// <summary>Prevents the specified child to be laid out during the next layout pass.
		/// 	</summary>
		/// <remarks>Prevents the specified child to be laid out during the next layout pass.
		/// 	</remarks>
		/// <param name="child">the child on which to perform the cleanup</param>
		protected internal virtual void cleanupLayoutState(android.view.View child)
		{
			child.mPrivateFlags &= ~android.view.View.FORCE_LAYOUT;
		}

		private void addViewInner(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params, bool preventRequestLayout)
		{
			if (mTransition != null)
			{
				// Don't prevent other add transitions from completing, but cancel remove
				// transitions to let them complete the process before we add to the container
				mTransition.cancel(android.animation.LayoutTransition.DISAPPEARING);
			}
			if (child.getParent() != null)
			{
				throw new System.InvalidOperationException("The specified child already has a parent. "
					 + "You must call removeView() on the child's parent first.");
			}
			if (mTransition != null)
			{
				mTransition.addChild(this, child);
			}
			if (!checkLayoutParams(@params))
			{
				@params = generateLayoutParams(@params);
			}
			if (preventRequestLayout)
			{
				child.mLayoutParams = @params;
			}
			else
			{
				child.setLayoutParams(@params);
			}
			if (index < 0)
			{
				index = mChildrenCount;
			}
			addInArray(child, index);
			// tell our children
			if (preventRequestLayout)
			{
				child.assignParent(this);
			}
			else
			{
				child.mParent = this;
			}
			if (child.hasFocus())
			{
				requestChildFocus(child, child.findFocus());
			}
			android.view.View.AttachInfo ai = mAttachInfo;
			if (ai != null && (mGroupFlags & FLAG_PREVENT_DISPATCH_ATTACHED_TO_WINDOW) == 0)
			{
				bool lastKeepOn = ai.mKeepScreenOn;
				ai.mKeepScreenOn = false;
				child.dispatchAttachedToWindow(mAttachInfo, (mViewFlags & VISIBILITY_MASK));
				if (ai.mKeepScreenOn)
				{
					needGlobalAttributesUpdate(true);
				}
				ai.mKeepScreenOn = lastKeepOn;
			}
			onViewAdded(child);
			if ((child.mViewFlags & DUPLICATE_PARENT_STATE) == DUPLICATE_PARENT_STATE)
			{
				mGroupFlags |= FLAG_NOTIFY_CHILDREN_ON_DRAWABLE_STATE_CHANGE;
			}
		}

		private void addInArray(android.view.View child, int index)
		{
			android.view.View[] children = mChildren;
			int count = mChildrenCount;
			int size = children.Length;
			if (index == count)
			{
				if (size == count)
				{
					mChildren = new android.view.View[size + ARRAY_CAPACITY_INCREMENT];
					System.Array.Copy(children, 0, mChildren, 0, size);
					children = mChildren;
				}
				children[mChildrenCount++] = child;
			}
			else
			{
				if (index < count)
				{
					if (size == count)
					{
						mChildren = new android.view.View[size + ARRAY_CAPACITY_INCREMENT];
						System.Array.Copy(children, 0, mChildren, 0, index);
						System.Array.Copy(children, index, mChildren, index + 1, count - index);
						children = mChildren;
					}
					else
					{
						System.Array.Copy(children, index, children, index + 1, count - index);
					}
					children[index] = child;
					mChildrenCount++;
					if (mLastTouchDownIndex >= index)
					{
						mLastTouchDownIndex++;
					}
				}
				else
				{
					throw new System.IndexOutOfRangeException("index=" + index + " count=" + count);
				}
			}
		}

		// This method also sets the child's mParent to null
		private void removeFromArray(int index)
		{
			android.view.View[] children = mChildren;
			if (!(mTransitioningViews != null && mTransitioningViews.contains(children[index]
				)))
			{
				children[index].mParent = null;
			}
			int count = mChildrenCount;
			if (index == count - 1)
			{
				children[--mChildrenCount] = null;
			}
			else
			{
				if (index >= 0 && index < count)
				{
					System.Array.Copy(children, index + 1, children, index, count - index - 1);
					children[--mChildrenCount] = null;
				}
				else
				{
					throw new System.IndexOutOfRangeException();
				}
			}
			if (mLastTouchDownIndex == index)
			{
				mLastTouchDownTime = 0;
				mLastTouchDownIndex = -1;
			}
			else
			{
				if (mLastTouchDownIndex > index)
				{
					mLastTouchDownIndex--;
				}
			}
		}

		// This method also sets the children's mParent to null
		private void removeFromArray(int start, int count)
		{
			android.view.View[] children = mChildren;
			int childrenCount = mChildrenCount;
			start = System.Math.Max(0, start);
			int end = System.Math.Min(childrenCount, start + count);
			if (start == end)
			{
				return;
			}
			if (end == childrenCount)
			{
				{
					for (int i = start; i < end; i++)
					{
						children[i].mParent = null;
						children[i] = null;
					}
				}
			}
			else
			{
				{
					for (int i = start; i < end; i++)
					{
						children[i].mParent = null;
					}
				}
				// Since we're looping above, we might as well do the copy, but is arraycopy()
				// faster than the extra 2 bounds checks we would do in the loop?
				System.Array.Copy(children, end, children, start, childrenCount - end);
				{
					for (int i_1 = childrenCount - (end - start); i_1 < childrenCount; i_1++)
					{
						children[i_1] = null;
					}
				}
			}
			mChildrenCount -= (end - start);
		}

		private void bindLayoutAnimation(android.view.View child)
		{
			android.view.animation.Animation a = mLayoutAnimationController.getAnimationForView
				(child);
			child.setAnimation(a);
		}

		/// <summary>
		/// Subclasses should override this method to set layout animation
		/// parameters on the supplied child.
		/// </summary>
		/// <remarks>
		/// Subclasses should override this method to set layout animation
		/// parameters on the supplied child.
		/// </remarks>
		/// <param name="child">the child to associate with animation parameters</param>
		/// <param name="params">
		/// the child's layout parameters which hold the animation
		/// parameters
		/// </param>
		/// <param name="index">the index of the child in the view group</param>
		/// <param name="count">the number of children in the view group</param>
		protected internal virtual void attachLayoutAnimationParameters(android.view.View
			 child, android.view.ViewGroup.LayoutParams @params, int index, int count)
		{
			android.view.animation.LayoutAnimationController.AnimationParameters animationParams
				 = @params.layoutAnimationParameters;
			if (animationParams == null)
			{
				animationParams = new android.view.animation.LayoutAnimationController.AnimationParameters
					();
				@params.layoutAnimationParameters = animationParams;
			}
			animationParams.count = count;
			animationParams.index = index;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
		public virtual void removeView(android.view.View view)
		{
			removeViewInternal(view);
			requestLayout();
			invalidate(true);
		}

		/// <summary>Removes a view during layout.</summary>
		/// <remarks>
		/// Removes a view during layout. This is useful if in your onLayout() method,
		/// you need to remove more views.
		/// </remarks>
		/// <param name="view">the view to remove from the group</param>
		public virtual void removeViewInLayout(android.view.View view)
		{
			removeViewInternal(view);
		}

		/// <summary>Removes a range of views during layout.</summary>
		/// <remarks>
		/// Removes a range of views during layout. This is useful if in your onLayout() method,
		/// you need to remove more views.
		/// </remarks>
		/// <param name="start">the index of the first view to remove from the group</param>
		/// <param name="count">the number of views to remove from the group</param>
		public virtual void removeViewsInLayout(int start, int count)
		{
			removeViewsInternal(start, count);
		}

		/// <summary>Removes the view at the specified position in the group.</summary>
		/// <remarks>Removes the view at the specified position in the group.</remarks>
		/// <param name="index">the position in the group of the view to remove</param>
		public virtual void removeViewAt(int index)
		{
			removeViewInternal(index, getChildAt(index));
			requestLayout();
			invalidate(true);
		}

		/// <summary>Removes the specified range of views from the group.</summary>
		/// <remarks>Removes the specified range of views from the group.</remarks>
		/// <param name="start">the first position in the group of the range of views to remove
		/// 	</param>
		/// <param name="count">the number of views to remove</param>
		public virtual void removeViews(int start, int count)
		{
			removeViewsInternal(start, count);
			requestLayout();
			invalidate(true);
		}

		private void removeViewInternal(android.view.View view)
		{
			int index = indexOfChild(view);
			if (index >= 0)
			{
				removeViewInternal(index, view);
			}
		}

		private void removeViewInternal(int index, android.view.View view)
		{
			if (mTransition != null)
			{
				mTransition.removeChild(this, view);
			}
			bool clearChildFocus_1 = false;
			if (view == mFocused)
			{
				view.clearFocusForRemoval();
				clearChildFocus_1 = true;
			}
			if (view.getAnimation() != null || (mTransitioningViews != null && mTransitioningViews
				.contains(view)))
			{
				addDisappearingView(view);
			}
			else
			{
				if (view.mAttachInfo != null)
				{
					view.dispatchDetachedFromWindow();
				}
			}
			onViewRemoved(view);
			needGlobalAttributesUpdate(false);
			removeFromArray(index);
			if (clearChildFocus_1)
			{
				clearChildFocus(view);
			}
		}

		/// <summary>Sets the LayoutTransition object for this ViewGroup.</summary>
		/// <remarks>
		/// Sets the LayoutTransition object for this ViewGroup. If the LayoutTransition object is
		/// not null, changes in layout which occur because of children being added to or removed from
		/// the ViewGroup will be animated according to the animations defined in that LayoutTransition
		/// object. By default, the transition object is null (so layout changes are not animated).
		/// </remarks>
		/// <param name="transition">
		/// The LayoutTransition object that will animated changes in layout. A value
		/// of <code>null</code> means no transition will run on layout changes.
		/// </param>
		/// <attr>ref android.R.styleable#ViewGroup_animateLayoutChanges</attr>
		public virtual void setLayoutTransition(android.animation.LayoutTransition transition
			)
		{
			if (mTransition != null)
			{
				mTransition.removeTransitionListener(mLayoutTransitionListener);
			}
			mTransition = transition;
			if (mTransition != null)
			{
				mTransition.addTransitionListener(mLayoutTransitionListener);
			}
		}

		/// <summary>Gets the LayoutTransition object for this ViewGroup.</summary>
		/// <remarks>
		/// Gets the LayoutTransition object for this ViewGroup. If the LayoutTransition object is
		/// not null, changes in layout which occur because of children being added to or removed from
		/// the ViewGroup will be animated according to the animations defined in that LayoutTransition
		/// object. By default, the transition object is null (so layout changes are not animated).
		/// </remarks>
		/// <returns>
		/// LayoutTranstion The LayoutTransition object that will animated changes in layout.
		/// A value of <code>null</code> means no transition will run on layout changes.
		/// </returns>
		public virtual android.animation.LayoutTransition getLayoutTransition()
		{
			return mTransition;
		}

		private void removeViewsInternal(int start, int count)
		{
			android.view.View focused = mFocused;
			bool detach = mAttachInfo != null;
			android.view.View clearChildFocus_1 = null;
			android.view.View[] children = mChildren;
			int end = start + count;
			{
				for (int i = start; i < end; i++)
				{
					android.view.View view = children[i];
					if (mTransition != null)
					{
						mTransition.removeChild(this, view);
					}
					if (view == focused)
					{
						view.clearFocusForRemoval();
						clearChildFocus_1 = view;
					}
					if (view.getAnimation() != null || (mTransitioningViews != null && mTransitioningViews
						.contains(view)))
					{
						addDisappearingView(view);
					}
					else
					{
						if (detach)
						{
							view.dispatchDetachedFromWindow();
						}
					}
					needGlobalAttributesUpdate(false);
					onViewRemoved(view);
				}
			}
			removeFromArray(start, count);
			if (clearChildFocus_1 != null)
			{
				clearChildFocus(clearChildFocus_1);
			}
		}

		/// <summary>
		/// Call this method to remove all child views from the
		/// ViewGroup.
		/// </summary>
		/// <remarks>
		/// Call this method to remove all child views from the
		/// ViewGroup.
		/// </remarks>
		public virtual void removeAllViews()
		{
			removeAllViewsInLayout();
			requestLayout();
			invalidate(true);
		}

		/// <summary>
		/// Called by a ViewGroup subclass to remove child views from itself,
		/// when it must first know its size on screen before it can calculate how many
		/// child views it will render.
		/// </summary>
		/// <remarks>
		/// Called by a ViewGroup subclass to remove child views from itself,
		/// when it must first know its size on screen before it can calculate how many
		/// child views it will render. An example is a Gallery or a ListView, which
		/// may "have" 50 children, but actually only render the number of children
		/// that can currently fit inside the object on screen. Do not call
		/// this method unless you are extending ViewGroup and understand the
		/// view measuring and layout pipeline.
		/// </remarks>
		public virtual void removeAllViewsInLayout()
		{
			int count = mChildrenCount;
			if (count <= 0)
			{
				return;
			}
			android.view.View[] children = mChildren;
			mChildrenCount = 0;
			android.view.View focused = mFocused;
			bool detach = mAttachInfo != null;
			android.view.View clearChildFocus_1 = null;
			needGlobalAttributesUpdate(false);
			{
				for (int i = count - 1; i >= 0; i--)
				{
					android.view.View view = children[i];
					if (mTransition != null)
					{
						mTransition.removeChild(this, view);
					}
					if (view == focused)
					{
						view.clearFocusForRemoval();
						clearChildFocus_1 = view;
					}
					if (view.getAnimation() != null || (mTransitioningViews != null && mTransitioningViews
						.contains(view)))
					{
						addDisappearingView(view);
					}
					else
					{
						if (detach)
						{
							view.dispatchDetachedFromWindow();
						}
					}
					onViewRemoved(view);
					view.mParent = null;
					children[i] = null;
				}
			}
			if (clearChildFocus_1 != null)
			{
				clearChildFocus(clearChildFocus_1);
			}
		}

		/// <summary>Finishes the removal of a detached view.</summary>
		/// <remarks>
		/// Finishes the removal of a detached view. This method will dispatch the detached from
		/// window event and notify the hierarchy change listener.
		/// </remarks>
		/// <param name="child">the child to be definitely removed from the view hierarchy</param>
		/// <param name="animate">
		/// if true and the view has an animation, the view is placed in the
		/// disappearing views list, otherwise, it is detached from the window
		/// </param>
		/// <seealso cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</seealso>
		/// <seealso cref="detachAllViewsFromParent()">detachAllViewsFromParent()</seealso>
		/// <seealso cref="detachViewFromParent(View)">detachViewFromParent(View)</seealso>
		/// <seealso cref="detachViewFromParent(int)">detachViewFromParent(int)</seealso>
		protected internal virtual void removeDetachedView(android.view.View child, bool 
			animate_1)
		{
			if (mTransition != null)
			{
				mTransition.removeChild(this, child);
			}
			if (child == mFocused)
			{
				child.clearFocus();
			}
			if ((animate_1 && child.getAnimation() != null) || (mTransitioningViews != null &&
				 mTransitioningViews.contains(child)))
			{
				addDisappearingView(child);
			}
			else
			{
				if (child.mAttachInfo != null)
				{
					child.dispatchDetachedFromWindow();
				}
			}
			onViewRemoved(child);
		}

		/// <summary>Attaches a view to this view group.</summary>
		/// <remarks>
		/// Attaches a view to this view group. Attaching a view assigns this group as the parent,
		/// sets the layout parameters and puts the view in the list of children so it can be retrieved
		/// by calling
		/// <see cref="getChildAt(int)">getChildAt(int)</see>
		/// .
		/// This method should be called only for view which were detached from their parent.
		/// </remarks>
		/// <param name="child">the child to attach</param>
		/// <param name="index">the index at which the child should be attached</param>
		/// <param name="params">the layout parameters of the child</param>
		/// <seealso cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</seealso>
		/// <seealso cref="detachAllViewsFromParent()">detachAllViewsFromParent()</seealso>
		/// <seealso cref="detachViewFromParent(View)">detachViewFromParent(View)</seealso>
		/// <seealso cref="detachViewFromParent(int)">detachViewFromParent(int)</seealso>
		protected internal virtual void attachViewToParent(android.view.View child, int index
			, android.view.ViewGroup.LayoutParams @params)
		{
			child.mLayoutParams = @params;
			if (index < 0)
			{
				index = mChildrenCount;
			}
			addInArray(child, index);
			child.mParent = this;
			child.mPrivateFlags = (child.mPrivateFlags & ~DIRTY_MASK & ~DRAWING_CACHE_VALID) 
				| DRAWN | INVALIDATED;
			this.mPrivateFlags |= INVALIDATED;
			if (child.hasFocus())
			{
				requestChildFocus(child, child.findFocus());
			}
		}

		/// <summary>Detaches a view from its parent.</summary>
		/// <remarks>
		/// Detaches a view from its parent. Detaching a view should be temporary and followed
		/// either by a call to
		/// <see cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</see>
		/// or a call to
		/// <see cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</see>
		/// . When a view is detached,
		/// its parent is null and cannot be retrieved by a call to
		/// <see cref="getChildAt(int)">getChildAt(int)</see>
		/// .
		/// </remarks>
		/// <param name="child">the child to detach</param>
		/// <seealso cref="detachViewFromParent(int)">detachViewFromParent(int)</seealso>
		/// <seealso cref="detachViewsFromParent(int, int)">detachViewsFromParent(int, int)</seealso>
		/// <seealso cref="detachAllViewsFromParent()">detachAllViewsFromParent()</seealso>
		/// <seealso cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</seealso>
		/// <seealso cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</seealso>
		protected internal virtual void detachViewFromParent(android.view.View child)
		{
			removeFromArray(indexOfChild(child));
		}

		/// <summary>Detaches a view from its parent.</summary>
		/// <remarks>
		/// Detaches a view from its parent. Detaching a view should be temporary and followed
		/// either by a call to
		/// <see cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</see>
		/// or a call to
		/// <see cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</see>
		/// . When a view is detached,
		/// its parent is null and cannot be retrieved by a call to
		/// <see cref="getChildAt(int)">getChildAt(int)</see>
		/// .
		/// </remarks>
		/// <param name="index">the index of the child to detach</param>
		/// <seealso cref="detachViewFromParent(View)">detachViewFromParent(View)</seealso>
		/// <seealso cref="detachAllViewsFromParent()">detachAllViewsFromParent()</seealso>
		/// <seealso cref="detachViewsFromParent(int, int)">detachViewsFromParent(int, int)</seealso>
		/// <seealso cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</seealso>
		/// <seealso cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</seealso>
		protected internal virtual void detachViewFromParent(int index)
		{
			removeFromArray(index);
		}

		/// <summary>Detaches a range of view from their parent.</summary>
		/// <remarks>
		/// Detaches a range of view from their parent. Detaching a view should be temporary and followed
		/// either by a call to
		/// <see cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</see>
		/// or a call to
		/// <see cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</see>
		/// . When a view is detached, its
		/// parent is null and cannot be retrieved by a call to
		/// <see cref="getChildAt(int)">getChildAt(int)</see>
		/// .
		/// </remarks>
		/// <param name="start">the first index of the childrend range to detach</param>
		/// <param name="count">the number of children to detach</param>
		/// <seealso cref="detachViewFromParent(View)">detachViewFromParent(View)</seealso>
		/// <seealso cref="detachViewFromParent(int)">detachViewFromParent(int)</seealso>
		/// <seealso cref="detachAllViewsFromParent()">detachAllViewsFromParent()</seealso>
		/// <seealso cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</seealso>
		/// <seealso cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</seealso>
		protected internal virtual void detachViewsFromParent(int start, int count)
		{
			removeFromArray(start, count);
		}

		/// <summary>Detaches all views from the parent.</summary>
		/// <remarks>
		/// Detaches all views from the parent. Detaching a view should be temporary and followed
		/// either by a call to
		/// <see cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</see>
		/// or a call to
		/// <see cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</see>
		/// . When a view is detached,
		/// its parent is null and cannot be retrieved by a call to
		/// <see cref="getChildAt(int)">getChildAt(int)</see>
		/// .
		/// </remarks>
		/// <seealso cref="detachViewFromParent(View)">detachViewFromParent(View)</seealso>
		/// <seealso cref="detachViewFromParent(int)">detachViewFromParent(int)</seealso>
		/// <seealso cref="detachViewsFromParent(int, int)">detachViewsFromParent(int, int)</seealso>
		/// <seealso cref="attachViewToParent(View, int, LayoutParams)">attachViewToParent(View, int, LayoutParams)
		/// 	</seealso>
		/// <seealso cref="removeDetachedView(View, bool)">removeDetachedView(View, bool)</seealso>
		protected internal virtual void detachAllViewsFromParent()
		{
			int count = mChildrenCount;
			if (count <= 0)
			{
				return;
			}
			android.view.View[] children = mChildren;
			mChildrenCount = 0;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					children[i].mParent = null;
					children[i] = null;
				}
			}
		}

		/// <summary>Don't call or override this method.</summary>
		/// <remarks>
		/// Don't call or override this method. It is used for the implementation of
		/// the view hierarchy.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void invalidateChild(android.view.View child, android.graphics.Rect
			 dirty)
		{
			android.view.ViewParent parent = this;
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (attachInfo != null)
			{
				// If the child is drawing an animation, we want to copy this flag onto
				// ourselves and the parent to make sure the invalidate request goes
				// through
				bool drawAnimation = (child.mPrivateFlags & DRAW_ANIMATION) == DRAW_ANIMATION;
				if (dirty == null)
				{
					if (child.mLayerType != LAYER_TYPE_NONE)
					{
						mPrivateFlags |= INVALIDATED;
						mPrivateFlags &= ~DRAWING_CACHE_VALID;
						child.mLocalDirtyRect.setEmpty();
					}
					do
					{
						android.view.View view = null;
						if (parent is android.view.View)
						{
							view = (android.view.View)parent;
							if (view.mLayerType != LAYER_TYPE_NONE)
							{
								view.mLocalDirtyRect.setEmpty();
								if (view.getParent() is android.view.View)
								{
									android.view.View grandParent = (android.view.View)view.getParent();
									grandParent.mPrivateFlags |= INVALIDATED;
									grandParent.mPrivateFlags &= ~DRAWING_CACHE_VALID;
								}
							}
							if ((view.mPrivateFlags & DIRTY_MASK) != 0)
							{
								// already marked dirty - we're done
								break;
							}
						}
						if (drawAnimation)
						{
							if (view != null)
							{
								view.mPrivateFlags |= DRAW_ANIMATION;
							}
							else
							{
								if (parent is android.view.ViewRootImpl)
								{
									((android.view.ViewRootImpl)parent).mIsAnimating = true;
								}
							}
						}
						if (parent is android.view.ViewRootImpl)
						{
							((android.view.ViewRootImpl)parent).invalidate();
							parent = null;
						}
						else
						{
							if (view != null)
							{
								if ((view.mPrivateFlags & DRAWN) == DRAWN || (view.mPrivateFlags & DRAWING_CACHE_VALID
									) == DRAWING_CACHE_VALID)
								{
									view.mPrivateFlags &= ~DRAWING_CACHE_VALID;
									view.mPrivateFlags |= DIRTY;
									parent = view.mParent;
								}
								else
								{
									parent = null;
								}
							}
						}
					}
					while (parent != null);
				}
				else
				{
					// Check whether the child that requests the invalidate is fully opaque
					bool isOpaque_1 = child.isOpaque() && !drawAnimation && child.getAnimation() == null;
					// Mark the child as dirty, using the appropriate flag
					// Make sure we do not set both flags at the same time
					int opaqueFlag = isOpaque_1 ? DIRTY_OPAQUE : DIRTY;
					if (child.mLayerType != LAYER_TYPE_NONE)
					{
						mPrivateFlags |= INVALIDATED;
						mPrivateFlags &= ~DRAWING_CACHE_VALID;
						child.mLocalDirtyRect.union(dirty);
					}
					int[] location = attachInfo.mInvalidateChildLocation;
					location[CHILD_LEFT_INDEX] = child.mLeft;
					location[CHILD_TOP_INDEX] = child.mTop;
					android.graphics.Matrix childMatrix = child.getMatrix();
					if (!childMatrix.isIdentity())
					{
						android.graphics.RectF boundingRect = attachInfo.mTmpTransformRect;
						boundingRect.set(dirty);
						//boundingRect.inset(-0.5f, -0.5f);
						childMatrix.mapRect(boundingRect);
						dirty.set((int)(boundingRect.left - 0.5f), (int)(boundingRect.top - 0.5f), (int)(
							boundingRect.right + 0.5f), (int)(boundingRect.bottom + 0.5f));
					}
					do
					{
						android.view.View view = null;
						if (parent is android.view.View)
						{
							view = (android.view.View)parent;
							if (view.mLayerType != LAYER_TYPE_NONE && view.getParent() is android.view.View)
							{
								android.view.View grandParent = (android.view.View)view.getParent();
								grandParent.mPrivateFlags |= INVALIDATED;
								grandParent.mPrivateFlags &= ~DRAWING_CACHE_VALID;
							}
						}
						if (drawAnimation)
						{
							if (view != null)
							{
								view.mPrivateFlags |= DRAW_ANIMATION;
							}
							else
							{
								if (parent is android.view.ViewRootImpl)
								{
									((android.view.ViewRootImpl)parent).mIsAnimating = true;
								}
							}
						}
						// If the parent is dirty opaque or not dirty, mark it dirty with the opaque
						// flag coming from the child that initiated the invalidate
						if (view != null)
						{
							if ((view.mViewFlags & FADING_EDGE_MASK) != 0 && view.getSolidColor() == 0)
							{
								opaqueFlag = DIRTY;
							}
							if ((view.mPrivateFlags & DIRTY_MASK) != DIRTY)
							{
								view.mPrivateFlags = (view.mPrivateFlags & ~DIRTY_MASK) | opaqueFlag;
							}
						}
						parent = parent.invalidateChildInParent(location, dirty);
						if (view != null)
						{
							// Account for transform on current parent
							android.graphics.Matrix m = view.getMatrix();
							if (!m.isIdentity())
							{
								android.graphics.RectF boundingRect = attachInfo.mTmpTransformRect;
								boundingRect.set(dirty);
								m.mapRect(boundingRect);
								dirty.set((int)boundingRect.left, (int)boundingRect.top, (int)(boundingRect.right
									 + 0.5f), (int)(boundingRect.bottom + 0.5f));
							}
						}
					}
					while (parent != null);
				}
			}
		}

		/// <summary>Don't call or override this method.</summary>
		/// <remarks>
		/// Don't call or override this method. It is used for the implementation of
		/// the view hierarchy.
		/// This implementation returns null if this ViewGroup does not have a parent,
		/// if this ViewGroup is already fully invalidated or if the dirty rectangle
		/// does not intersect with this ViewGroup's bounds.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual android.view.ViewParent invalidateChildInParent(int[] location, android.graphics.Rect
			 dirty)
		{
			if ((mPrivateFlags & DRAWN) == DRAWN || (mPrivateFlags & DRAWING_CACHE_VALID) == 
				DRAWING_CACHE_VALID)
			{
				if ((mGroupFlags & (FLAG_OPTIMIZE_INVALIDATE | FLAG_ANIMATION_DONE)) != FLAG_OPTIMIZE_INVALIDATE)
				{
					dirty.offset(location[CHILD_LEFT_INDEX] - mScrollX, location[CHILD_TOP_INDEX] - mScrollY
						);
					int left = mLeft;
					int top = mTop;
					if ((mGroupFlags & FLAG_CLIP_CHILDREN) != FLAG_CLIP_CHILDREN || dirty.intersect(0
						, 0, mRight - left, mBottom - top) || (mPrivateFlags & DRAW_ANIMATION) == DRAW_ANIMATION)
					{
						mPrivateFlags &= ~DRAWING_CACHE_VALID;
						location[CHILD_LEFT_INDEX] = left;
						location[CHILD_TOP_INDEX] = top;
						if (mLayerType != LAYER_TYPE_NONE)
						{
							mLocalDirtyRect.union(dirty);
						}
						return mParent;
					}
				}
				else
				{
					mPrivateFlags &= ~DRAWN & ~DRAWING_CACHE_VALID;
					location[CHILD_LEFT_INDEX] = mLeft;
					location[CHILD_TOP_INDEX] = mTop;
					if ((mGroupFlags & FLAG_CLIP_CHILDREN) == FLAG_CLIP_CHILDREN)
					{
						dirty.set(0, 0, mRight - mLeft, mBottom - mTop);
					}
					else
					{
						// in case the dirty rect extends outside the bounds of this container
						dirty.union(0, 0, mRight - mLeft, mBottom - mTop);
					}
					if (mLayerType != LAYER_TYPE_NONE)
					{
						mLocalDirtyRect.union(dirty);
					}
					return mParent;
				}
			}
			return null;
		}

		/// <summary>
		/// Offset a rectangle that is in a descendant's coordinate
		/// space into our coordinate space.
		/// </summary>
		/// <remarks>
		/// Offset a rectangle that is in a descendant's coordinate
		/// space into our coordinate space.
		/// </remarks>
		/// <param name="descendant">A descendant of this view</param>
		/// <param name="rect">A rectangle defined in descendant's coordinate space.</param>
		public void offsetDescendantRectToMyCoords(android.view.View descendant, android.graphics.Rect
			 rect)
		{
			offsetRectBetweenParentAndChild(descendant, rect, true, false);
		}

		/// <summary>
		/// Offset a rectangle that is in our coordinate space into an ancestor's
		/// coordinate space.
		/// </summary>
		/// <remarks>
		/// Offset a rectangle that is in our coordinate space into an ancestor's
		/// coordinate space.
		/// </remarks>
		/// <param name="descendant">A descendant of this view</param>
		/// <param name="rect">A rectangle defined in descendant's coordinate space.</param>
		public void offsetRectIntoDescendantCoords(android.view.View descendant, android.graphics.Rect
			 rect)
		{
			offsetRectBetweenParentAndChild(descendant, rect, false, false);
		}

		/// <summary>
		/// Helper method that offsets a rect either from parent to descendant or
		/// descendant to parent.
		/// </summary>
		/// <remarks>
		/// Helper method that offsets a rect either from parent to descendant or
		/// descendant to parent.
		/// </remarks>
		internal virtual void offsetRectBetweenParentAndChild(android.view.View descendant
			, android.graphics.Rect rect, bool offsetFromChildToParent, bool clipToBounds)
		{
			// already in the same coord system :)
			if (descendant == this)
			{
				return;
			}
			android.view.ViewParent theParent = descendant.mParent;
			// search and offset up to the parent
			while ((theParent != null) && (theParent is android.view.View) && (theParent != this
				))
			{
				if (offsetFromChildToParent)
				{
					rect.offset(descendant.mLeft - descendant.mScrollX, descendant.mTop - descendant.
						mScrollY);
					if (clipToBounds)
					{
						android.view.View p = (android.view.View)theParent;
						rect.intersect(0, 0, p.mRight - p.mLeft, p.mBottom - p.mTop);
					}
				}
				else
				{
					if (clipToBounds)
					{
						android.view.View p = (android.view.View)theParent;
						rect.intersect(0, 0, p.mRight - p.mLeft, p.mBottom - p.mTop);
					}
					rect.offset(descendant.mScrollX - descendant.mLeft, descendant.mScrollY - descendant
						.mTop);
				}
				descendant = (android.view.View)theParent;
				theParent = descendant.mParent;
			}
			// now that we are up to this view, need to offset one more time
			// to get into our coordinate space
			if (theParent == this)
			{
				if (offsetFromChildToParent)
				{
					rect.offset(descendant.mLeft - descendant.mScrollX, descendant.mTop - descendant.
						mScrollY);
				}
				else
				{
					rect.offset(descendant.mScrollX - descendant.mLeft, descendant.mScrollY - descendant
						.mTop);
				}
			}
			else
			{
				throw new System.ArgumentException("parameter must be a descendant of this view");
			}
		}

		/// <summary>Offset the vertical location of all children of this view by the specified number of pixels.
		/// 	</summary>
		/// <remarks>Offset the vertical location of all children of this view by the specified number of pixels.
		/// 	</remarks>
		/// <param name="offset">the number of pixels to offset</param>
		/// <hide></hide>
		public virtual void offsetChildrenTopAndBottom(int offset)
		{
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View v = children[i];
					v.mTop += offset;
					v.mBottom += offset;
				}
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual bool getChildVisibleRect(android.view.View child, android.graphics.Rect
			 r, android.graphics.Point offset)
		{
			int dx = child.mLeft - mScrollX;
			int dy = child.mTop - mScrollY;
			if (offset != null)
			{
				offset.x += dx;
				offset.y += dy;
			}
			r.offset(dx, dy);
			return r.intersect(0, 0, mRight - mLeft, mBottom - mTop) && (mParent == null || mParent
				.getChildVisibleRect(this, r, offset));
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public sealed override void layout(int l, int t, int r, int b)
		{
			if (mTransition == null || !mTransition.isChangingLayout())
			{
				base.layout(l, t, r, b);
			}
			else
			{
				// record the fact that we noop'd it; request layout when transition finishes
				mLayoutSuppressed = true;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal abstract override void onLayout(bool changed, int l, int t, int
			 r, int b);

		/// <summary>
		/// Indicates whether the view group has the ability to animate its children
		/// after the first layout.
		/// </summary>
		/// <remarks>
		/// Indicates whether the view group has the ability to animate its children
		/// after the first layout.
		/// </remarks>
		/// <returns>true if the children can be animated, false otherwise</returns>
		protected internal virtual bool canAnimate()
		{
			return mLayoutAnimationController != null;
		}

		/// <summary>Runs the layout animation.</summary>
		/// <remarks>
		/// Runs the layout animation. Calling this method triggers a relayout of
		/// this view group.
		/// </remarks>
		public virtual void startLayoutAnimation()
		{
			if (mLayoutAnimationController != null)
			{
				mGroupFlags |= FLAG_RUN_ANIMATION;
				requestLayout();
			}
		}

		/// <summary>
		/// Schedules the layout animation to be played after the next layout pass
		/// of this view group.
		/// </summary>
		/// <remarks>
		/// Schedules the layout animation to be played after the next layout pass
		/// of this view group. This can be used to restart the layout animation
		/// when the content of the view group changes or when the activity is
		/// paused and resumed.
		/// </remarks>
		public virtual void scheduleLayoutAnimation()
		{
			mGroupFlags |= FLAG_RUN_ANIMATION;
		}

		/// <summary>
		/// Sets the layout animation controller used to animate the group's
		/// children after the first layout.
		/// </summary>
		/// <remarks>
		/// Sets the layout animation controller used to animate the group's
		/// children after the first layout.
		/// </remarks>
		/// <param name="controller">the animation controller</param>
		public virtual void setLayoutAnimation(android.view.animation.LayoutAnimationController
			 controller)
		{
			mLayoutAnimationController = controller;
			if (mLayoutAnimationController != null)
			{
				mGroupFlags |= FLAG_RUN_ANIMATION;
			}
		}

		/// <summary>
		/// Returns the layout animation controller used to animate the group's
		/// children.
		/// </summary>
		/// <remarks>
		/// Returns the layout animation controller used to animate the group's
		/// children.
		/// </remarks>
		/// <returns>the current animation controller</returns>
		public virtual android.view.animation.LayoutAnimationController getLayoutAnimation
			()
		{
			return mLayoutAnimationController;
		}

		/// <summary>
		/// Indicates whether the children's drawing cache is used during a layout
		/// animation.
		/// </summary>
		/// <remarks>
		/// Indicates whether the children's drawing cache is used during a layout
		/// animation. By default, the drawing cache is enabled but this will prevent
		/// nested layout animations from working. To nest animations, you must disable
		/// the cache.
		/// </remarks>
		/// <returns>true if the animation cache is enabled, false otherwise</returns>
		/// <seealso cref="setAnimationCacheEnabled(bool)">setAnimationCacheEnabled(bool)</seealso>
		/// <seealso cref="View.setDrawingCacheEnabled(bool)">View.setDrawingCacheEnabled(bool)
		/// 	</seealso>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isAnimationCacheEnabled()
		{
			return (mGroupFlags & FLAG_ANIMATION_CACHE) == FLAG_ANIMATION_CACHE;
		}

		/// <summary>Enables or disables the children's drawing cache during a layout animation.
		/// 	</summary>
		/// <remarks>
		/// Enables or disables the children's drawing cache during a layout animation.
		/// By default, the drawing cache is enabled but this will prevent nested
		/// layout animations from working. To nest animations, you must disable the
		/// cache.
		/// </remarks>
		/// <param name="enabled">true to enable the animation cache, false otherwise</param>
		/// <seealso cref="isAnimationCacheEnabled()">isAnimationCacheEnabled()</seealso>
		/// <seealso cref="View.setDrawingCacheEnabled(bool)">View.setDrawingCacheEnabled(bool)
		/// 	</seealso>
		public virtual void setAnimationCacheEnabled(bool enabled)
		{
			setBooleanFlag(FLAG_ANIMATION_CACHE, enabled);
		}

		/// <summary>
		/// Indicates whether this ViewGroup will always try to draw its children using their
		/// drawing cache.
		/// </summary>
		/// <remarks>
		/// Indicates whether this ViewGroup will always try to draw its children using their
		/// drawing cache. By default this property is enabled.
		/// </remarks>
		/// <returns>true if the animation cache is enabled, false otherwise</returns>
		/// <seealso cref="setAlwaysDrawnWithCacheEnabled(bool)">setAlwaysDrawnWithCacheEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="setChildrenDrawnWithCacheEnabled(bool)">setChildrenDrawnWithCacheEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="View.setDrawingCacheEnabled(bool)">View.setDrawingCacheEnabled(bool)
		/// 	</seealso>
		public virtual bool isAlwaysDrawnWithCacheEnabled()
		{
			return (mGroupFlags & FLAG_ALWAYS_DRAWN_WITH_CACHE) == FLAG_ALWAYS_DRAWN_WITH_CACHE;
		}

		/// <summary>
		/// Indicates whether this ViewGroup will always try to draw its children using their
		/// drawing cache.
		/// </summary>
		/// <remarks>
		/// Indicates whether this ViewGroup will always try to draw its children using their
		/// drawing cache. This property can be set to true when the cache rendering is
		/// slightly different from the children's normal rendering. Renderings can be different,
		/// for instance, when the cache's quality is set to low.
		/// When this property is disabled, the ViewGroup will use the drawing cache of its
		/// children only when asked to. It's usually the task of subclasses to tell ViewGroup
		/// when to start using the drawing cache and when to stop using it.
		/// </remarks>
		/// <param name="always">true to always draw with the drawing cache, false otherwise</param>
		/// <seealso cref="isAlwaysDrawnWithCacheEnabled()">isAlwaysDrawnWithCacheEnabled()</seealso>
		/// <seealso cref="setChildrenDrawnWithCacheEnabled(bool)">setChildrenDrawnWithCacheEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="View.setDrawingCacheEnabled(bool)">View.setDrawingCacheEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="View.setDrawingCacheQuality(int)">View.setDrawingCacheQuality(int)
		/// 	</seealso>
		public virtual void setAlwaysDrawnWithCacheEnabled(bool always)
		{
			setBooleanFlag(FLAG_ALWAYS_DRAWN_WITH_CACHE, always);
		}

		/// <summary>
		/// Indicates whether the ViewGroup is currently drawing its children using
		/// their drawing cache.
		/// </summary>
		/// <remarks>
		/// Indicates whether the ViewGroup is currently drawing its children using
		/// their drawing cache.
		/// </remarks>
		/// <returns>true if children should be drawn with their cache, false otherwise</returns>
		/// <seealso cref="setAlwaysDrawnWithCacheEnabled(bool)">setAlwaysDrawnWithCacheEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="setChildrenDrawnWithCacheEnabled(bool)">setChildrenDrawnWithCacheEnabled(bool)
		/// 	</seealso>
		protected internal virtual bool isChildrenDrawnWithCacheEnabled()
		{
			return (mGroupFlags & FLAG_CHILDREN_DRAWN_WITH_CACHE) == FLAG_CHILDREN_DRAWN_WITH_CACHE;
		}

		/// <summary>Tells the ViewGroup to draw its children using their drawing cache.</summary>
		/// <remarks>
		/// Tells the ViewGroup to draw its children using their drawing cache. This property
		/// is ignored when
		/// <see cref="isAlwaysDrawnWithCacheEnabled()">isAlwaysDrawnWithCacheEnabled()</see>
		/// is true. A child's drawing cache
		/// will be used only if it has been enabled.
		/// Subclasses should call this method to start and stop using the drawing cache when
		/// they perform performance sensitive operations, like scrolling or animating.
		/// </remarks>
		/// <param name="enabled">true if children should be drawn with their cache, false otherwise
		/// 	</param>
		/// <seealso cref="setAlwaysDrawnWithCacheEnabled(bool)">setAlwaysDrawnWithCacheEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="isChildrenDrawnWithCacheEnabled()">isChildrenDrawnWithCacheEnabled()
		/// 	</seealso>
		protected internal virtual void setChildrenDrawnWithCacheEnabled(bool enabled)
		{
			setBooleanFlag(FLAG_CHILDREN_DRAWN_WITH_CACHE, enabled);
		}

		/// <summary>
		/// Indicates whether the ViewGroup is drawing its children in the order defined by
		/// <see cref="getChildDrawingOrder(int, int)">getChildDrawingOrder(int, int)</see>
		/// .
		/// </summary>
		/// <returns>
		/// true if children drawing order is defined by
		/// <see cref="getChildDrawingOrder(int, int)">getChildDrawingOrder(int, int)</see>
		/// ,
		/// false otherwise
		/// </returns>
		/// <seealso cref="setChildrenDrawingOrderEnabled(bool)">setChildrenDrawingOrderEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="getChildDrawingOrder(int, int)">getChildDrawingOrder(int, int)</seealso>
		protected internal virtual bool isChildrenDrawingOrderEnabled()
		{
			return (mGroupFlags & FLAG_USE_CHILD_DRAWING_ORDER) == FLAG_USE_CHILD_DRAWING_ORDER;
		}

		/// <summary>
		/// Tells the ViewGroup whether to draw its children in the order defined by the method
		/// <see cref="getChildDrawingOrder(int, int)">getChildDrawingOrder(int, int)</see>
		/// .
		/// </summary>
		/// <param name="enabled">
		/// true if the order of the children when drawing is determined by
		/// <see cref="getChildDrawingOrder(int, int)">getChildDrawingOrder(int, int)</see>
		/// , false otherwise
		/// </param>
		/// <seealso cref="isChildrenDrawingOrderEnabled()">isChildrenDrawingOrderEnabled()</seealso>
		/// <seealso cref="getChildDrawingOrder(int, int)">getChildDrawingOrder(int, int)</seealso>
		protected internal virtual void setChildrenDrawingOrderEnabled(bool enabled)
		{
			setBooleanFlag(FLAG_USE_CHILD_DRAWING_ORDER, enabled);
		}

		private void setBooleanFlag(int flag, bool value)
		{
			if (value)
			{
				mGroupFlags |= flag;
			}
			else
			{
				mGroupFlags &= ~flag;
			}
		}

		/// <summary>Returns an integer indicating what types of drawing caches are kept in memory.
		/// 	</summary>
		/// <remarks>Returns an integer indicating what types of drawing caches are kept in memory.
		/// 	</remarks>
		/// <seealso cref="setPersistentDrawingCache(int)">setPersistentDrawingCache(int)</seealso>
		/// <seealso cref="setAnimationCacheEnabled(bool)">setAnimationCacheEnabled(bool)</seealso>
		/// <returns>
		/// one or a combination of
		/// <see cref="PERSISTENT_NO_CACHE">PERSISTENT_NO_CACHE</see>
		/// ,
		/// <see cref="PERSISTENT_ANIMATION_CACHE">PERSISTENT_ANIMATION_CACHE</see>
		/// ,
		/// <see cref="PERSISTENT_SCROLLING_CACHE">PERSISTENT_SCROLLING_CACHE</see>
		/// and
		/// <see cref="PERSISTENT_ALL_CACHES">PERSISTENT_ALL_CACHES</see>
		/// </returns>
		public virtual int getPersistentDrawingCache()
		{
			return mPersistentDrawingCache;
		}

		/// <summary>
		/// Indicates what types of drawing caches should be kept in memory after
		/// they have been created.
		/// </summary>
		/// <remarks>
		/// Indicates what types of drawing caches should be kept in memory after
		/// they have been created.
		/// </remarks>
		/// <seealso cref="getPersistentDrawingCache()">getPersistentDrawingCache()</seealso>
		/// <seealso cref="setAnimationCacheEnabled(bool)">setAnimationCacheEnabled(bool)</seealso>
		/// <param name="drawingCacheToKeep">
		/// one or a combination of
		/// <see cref="PERSISTENT_NO_CACHE">PERSISTENT_NO_CACHE</see>
		/// ,
		/// <see cref="PERSISTENT_ANIMATION_CACHE">PERSISTENT_ANIMATION_CACHE</see>
		/// ,
		/// <see cref="PERSISTENT_SCROLLING_CACHE">PERSISTENT_SCROLLING_CACHE</see>
		/// and
		/// <see cref="PERSISTENT_ALL_CACHES">PERSISTENT_ALL_CACHES</see>
		/// </param>
		public virtual void setPersistentDrawingCache(int drawingCacheToKeep)
		{
			mPersistentDrawingCache = drawingCacheToKeep & PERSISTENT_ALL_CACHES;
		}

		/// <summary>Returns a new set of layout parameters based on the supplied attributes set.
		/// 	</summary>
		/// <remarks>Returns a new set of layout parameters based on the supplied attributes set.
		/// 	</remarks>
		/// <param name="attrs">the attributes to build the layout parameters from</param>
		/// <returns>
		/// an instance of
		/// <see cref="LayoutParams">LayoutParams</see>
		/// or one
		/// of its descendants
		/// </returns>
		public virtual android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.view.ViewGroup.LayoutParams(getContext(), attrs);
		}

		/// <summary>Returns a safe set of layout parameters based on the supplied layout params.
		/// 	</summary>
		/// <remarks>
		/// Returns a safe set of layout parameters based on the supplied layout params.
		/// When a ViewGroup is passed a View whose layout params do not pass the test of
		/// <see cref="checkLayoutParams(LayoutParams)">checkLayoutParams(LayoutParams)</see>
		/// , this method
		/// is invoked. This method should return a new set of layout params suitable for
		/// this ViewGroup, possibly by copying the appropriate attributes from the
		/// specified set of layout params.
		/// </remarks>
		/// <param name="p">
		/// The layout parameters to convert into a suitable set of layout parameters
		/// for this ViewGroup.
		/// </param>
		/// <returns>
		/// an instance of
		/// <see cref="LayoutParams">LayoutParams</see>
		/// or one
		/// of its descendants
		/// </returns>
		protected internal virtual android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return p;
		}

		/// <summary>Returns a set of default layout parameters.</summary>
		/// <remarks>
		/// Returns a set of default layout parameters. These parameters are requested
		/// when the View passed to
		/// <see cref="addView(View)">addView(View)</see>
		/// has no layout parameters
		/// already set. If null is returned, an exception is thrown from addView.
		/// </remarks>
		/// <returns>a set of default layout parameters or null</returns>
		protected internal virtual android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.view.ViewGroup.LayoutParams(android.view.ViewGroup.LayoutParams
				.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool dispatchConsistencyCheck(int consistency)
		{
			bool result = base.dispatchConsistencyCheck(consistency);
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					if (!children[i].dispatchConsistencyCheck(consistency))
					{
						result = false;
					}
				}
			}
			return result;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool onConsistencyCheck(int consistency)
		{
			bool result = base.onConsistencyCheck(consistency);
			bool checkLayout = (consistency & android.view.ViewDebug.CONSISTENCY_LAYOUT) != 0;
			bool checkDrawing = (consistency & android.view.ViewDebug.CONSISTENCY_DRAWING) !=
				 0;
			if (checkLayout)
			{
				int count = mChildrenCount;
				android.view.View[] children = mChildren;
				{
					for (int i = 0; i < count; i++)
					{
						if (children[i].getParent() != this)
						{
							result = false;
							android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "View " + children
								[i] + " has no parent/a parent that is not " + this);
						}
					}
				}
			}
			if (checkDrawing)
			{
				// If this group is dirty, check that the parent is dirty as well
				if ((mPrivateFlags & DIRTY_MASK) != 0)
				{
					android.view.ViewParent parent = getParent();
					if (parent != null && !(parent is android.view.ViewRootImpl))
					{
						if ((((android.view.View)parent).mPrivateFlags & DIRTY_MASK) == 0)
						{
							result = false;
							android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "ViewGroup " + this
								 + " is dirty but its parent is not: " + this);
						}
					}
				}
			}
			return result;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void debug(int depth)
		{
			base.debug(depth);
			string output;
			if (mFocused != null)
			{
				output = debugIndent(depth);
				output += "mFocused";
				android.util.Log.d(VIEW_LOG_TAG, output);
			}
			if (mChildrenCount != 0)
			{
				output = debugIndent(depth);
				output += "{";
				android.util.Log.d(VIEW_LOG_TAG, output);
			}
			int count = mChildrenCount;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = mChildren[i];
					child.debug(depth + 1);
				}
			}
			if (mChildrenCount != 0)
			{
				output = debugIndent(depth);
				output += "}";
				android.util.Log.d(VIEW_LOG_TAG, output);
			}
		}

		/// <summary>Returns the position in the group of the specified child view.</summary>
		/// <remarks>Returns the position in the group of the specified child view.</remarks>
		/// <param name="child">the view for which to get the position</param>
		/// <returns>
		/// a positive integer representing the position of the view in the
		/// group, or -1 if the view does not exist in the group
		/// </returns>
		public virtual int indexOfChild(android.view.View child)
		{
			int count = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < count; i++)
				{
					if (children[i] == child)
					{
						return i;
					}
				}
			}
			return -1;
		}

		/// <summary>Returns the number of children in the group.</summary>
		/// <remarks>Returns the number of children in the group.</remarks>
		/// <returns>
		/// a positive integer representing the number of children in
		/// the group
		/// </returns>
		public virtual int getChildCount()
		{
			return mChildrenCount;
		}

		/// <summary>Returns the view at the specified position in the group.</summary>
		/// <remarks>Returns the view at the specified position in the group.</remarks>
		/// <param name="index">the position at which to get the view from</param>
		/// <returns>
		/// the view at the specified position or null if the position
		/// does not exist within the group
		/// </returns>
		public virtual android.view.View getChildAt(int index)
		{
			if (index < 0 || index >= mChildrenCount)
			{
				return null;
			}
			return mChildren[index];
		}

		/// <summary>
		/// Ask all of the children of this view to measure themselves, taking into
		/// account both the MeasureSpec requirements for this view and its padding.
		/// </summary>
		/// <remarks>
		/// Ask all of the children of this view to measure themselves, taking into
		/// account both the MeasureSpec requirements for this view and its padding.
		/// We skip children that are in the GONE state The heavy lifting is done in
		/// getChildMeasureSpec.
		/// </remarks>
		/// <param name="widthMeasureSpec">The width requirements for this view</param>
		/// <param name="heightMeasureSpec">The height requirements for this view</param>
		protected internal virtual void measureChildren(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int size = mChildrenCount;
			android.view.View[] children = mChildren;
			{
				for (int i = 0; i < size; ++i)
				{
					android.view.View child = children[i];
					if ((child.mViewFlags & VISIBILITY_MASK) != GONE)
					{
						measureChild(child, widthMeasureSpec, heightMeasureSpec);
					}
				}
			}
		}

		/// <summary>
		/// Ask one of the children of this view to measure itself, taking into
		/// account both the MeasureSpec requirements for this view and its padding.
		/// </summary>
		/// <remarks>
		/// Ask one of the children of this view to measure itself, taking into
		/// account both the MeasureSpec requirements for this view and its padding.
		/// The heavy lifting is done in getChildMeasureSpec.
		/// </remarks>
		/// <param name="child">The child to measure</param>
		/// <param name="parentWidthMeasureSpec">The width requirements for this view</param>
		/// <param name="parentHeightMeasureSpec">The height requirements for this view</param>
		protected internal virtual void measureChild(android.view.View child, int parentWidthMeasureSpec
			, int parentHeightMeasureSpec)
		{
			android.view.ViewGroup.LayoutParams lp = child.getLayoutParams();
			int childWidthMeasureSpec = getChildMeasureSpec(parentWidthMeasureSpec, mPaddingLeft
				 + mPaddingRight, lp.width);
			int childHeightMeasureSpec = getChildMeasureSpec(parentHeightMeasureSpec, mPaddingTop
				 + mPaddingBottom, lp.height);
			child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
		}

		/// <summary>
		/// Ask one of the children of this view to measure itself, taking into
		/// account both the MeasureSpec requirements for this view and its padding
		/// and margins.
		/// </summary>
		/// <remarks>
		/// Ask one of the children of this view to measure itself, taking into
		/// account both the MeasureSpec requirements for this view and its padding
		/// and margins. The child must have MarginLayoutParams The heavy lifting is
		/// done in getChildMeasureSpec.
		/// </remarks>
		/// <param name="child">The child to measure</param>
		/// <param name="parentWidthMeasureSpec">The width requirements for this view</param>
		/// <param name="widthUsed">
		/// Extra space that has been used up by the parent
		/// horizontally (possibly by other children of the parent)
		/// </param>
		/// <param name="parentHeightMeasureSpec">The height requirements for this view</param>
		/// <param name="heightUsed">
		/// Extra space that has been used up by the parent
		/// vertically (possibly by other children of the parent)
		/// </param>
		protected internal virtual void measureChildWithMargins(android.view.View child, 
			int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed
			)
		{
			android.view.ViewGroup.MarginLayoutParams lp = (android.view.ViewGroup.MarginLayoutParams
				)child.getLayoutParams();
			int childWidthMeasureSpec = getChildMeasureSpec(parentWidthMeasureSpec, mPaddingLeft
				 + mPaddingRight + lp.leftMargin + lp.rightMargin + widthUsed, lp.width);
			int childHeightMeasureSpec = getChildMeasureSpec(parentHeightMeasureSpec, mPaddingTop
				 + mPaddingBottom + lp.topMargin + lp.bottomMargin + heightUsed, lp.height);
			child.measure(childWidthMeasureSpec, childHeightMeasureSpec);
		}

		/// <summary>
		/// Does the hard part of measureChildren: figuring out the MeasureSpec to
		/// pass to a particular child.
		/// </summary>
		/// <remarks>
		/// Does the hard part of measureChildren: figuring out the MeasureSpec to
		/// pass to a particular child. This method figures out the right MeasureSpec
		/// for one dimension (height or width) of one child view.
		/// The goal is to combine information from our MeasureSpec with the
		/// LayoutParams of the child to get the best possible results. For example,
		/// if the this view knows its size (because its MeasureSpec has a mode of
		/// EXACTLY), and the child has indicated in its LayoutParams that it wants
		/// to be the same size as the parent, the parent should ask the child to
		/// layout given an exact size.
		/// </remarks>
		/// <param name="spec">The requirements for this view</param>
		/// <param name="padding">
		/// The padding of this view for the current dimension and
		/// margins, if applicable
		/// </param>
		/// <param name="childDimension">
		/// How big the child wants to be in the current
		/// dimension
		/// </param>
		/// <returns>a MeasureSpec integer for the child</returns>
		public static int getChildMeasureSpec(int spec, int padding, int childDimension)
		{
			int specMode = android.view.View.MeasureSpec.getMode(spec);
			int specSize = android.view.View.MeasureSpec.getSize(spec);
			int size = System.Math.Max(0, specSize - padding);
			int resultSize = 0;
			int resultMode = 0;
			switch (specMode)
			{
				case android.view.View.MeasureSpec.EXACTLY:
				{
					// Parent has imposed an exact size on us
					if (childDimension >= 0)
					{
						resultSize = childDimension;
						resultMode = android.view.View.MeasureSpec.EXACTLY;
					}
					else
					{
						if (childDimension == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
						{
							// Child wants to be our size. So be it.
							resultSize = size;
							resultMode = android.view.View.MeasureSpec.EXACTLY;
						}
						else
						{
							if (childDimension == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
							{
								// Child wants to determine its own size. It can't be
								// bigger than us.
								resultSize = size;
								resultMode = android.view.View.MeasureSpec.AT_MOST;
							}
						}
					}
					break;
				}

				case android.view.View.MeasureSpec.AT_MOST:
				{
					// Parent has imposed a maximum size on us
					if (childDimension >= 0)
					{
						// Child wants a specific size... so be it
						resultSize = childDimension;
						resultMode = android.view.View.MeasureSpec.EXACTLY;
					}
					else
					{
						if (childDimension == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
						{
							// Child wants to be our size, but our size is not fixed.
							// Constrain child to not be bigger than us.
							resultSize = size;
							resultMode = android.view.View.MeasureSpec.AT_MOST;
						}
						else
						{
							if (childDimension == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
							{
								// Child wants to determine its own size. It can't be
								// bigger than us.
								resultSize = size;
								resultMode = android.view.View.MeasureSpec.AT_MOST;
							}
						}
					}
					break;
				}

				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					// Parent asked to see how big we want to be
					if (childDimension >= 0)
					{
						// Child wants a specific size... let him have it
						resultSize = childDimension;
						resultMode = android.view.View.MeasureSpec.EXACTLY;
					}
					else
					{
						if (childDimension == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
						{
							// Child wants to be our size... find out how big it should
							// be
							resultSize = 0;
							resultMode = android.view.View.MeasureSpec.UNSPECIFIED;
						}
						else
						{
							if (childDimension == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
							{
								// Child wants to determine its own size.... find out how
								// big it should be
								resultSize = 0;
								resultMode = android.view.View.MeasureSpec.UNSPECIFIED;
							}
						}
					}
					break;
				}
			}
			return android.view.View.MeasureSpec.makeMeasureSpec(resultSize, resultMode);
		}

		/// <summary>Removes any pending animations for views that have been removed.</summary>
		/// <remarks>
		/// Removes any pending animations for views that have been removed. Call
		/// this if you don't want animations for exiting views to stack up.
		/// </remarks>
		public virtual void clearDisappearingChildren()
		{
			if (mDisappearingChildren != null)
			{
				mDisappearingChildren.clear();
			}
		}

		/// <summary>Add a view which is removed from mChildren but still needs animation</summary>
		/// <param name="v">View to add</param>
		private void addDisappearingView(android.view.View v)
		{
			java.util.ArrayList<android.view.View> disappearingChildren = mDisappearingChildren;
			if (disappearingChildren == null)
			{
				disappearingChildren = mDisappearingChildren = new java.util.ArrayList<android.view.View
					>();
			}
			disappearingChildren.add(v);
		}

		/// <summary>Cleanup a view when its animation is done.</summary>
		/// <remarks>
		/// Cleanup a view when its animation is done. This may mean removing it from
		/// the list of disappearing views.
		/// </remarks>
		/// <param name="view">The view whose animation has finished</param>
		/// <param name="animation">The animation, cannot be null</param>
		private void finishAnimatingView(android.view.View view, android.view.animation.Animation
			 animation)
		{
			java.util.ArrayList<android.view.View> disappearingChildren = mDisappearingChildren;
			if (disappearingChildren != null)
			{
				if (disappearingChildren.contains(view))
				{
					disappearingChildren.remove(view);
					if (view.mAttachInfo != null)
					{
						view.dispatchDetachedFromWindow();
					}
					view.clearAnimation();
					mGroupFlags |= FLAG_INVALIDATE_REQUIRED;
				}
			}
			if (animation != null && !animation.getFillAfter())
			{
				view.clearAnimation();
			}
			if ((view.mPrivateFlags & ANIMATION_STARTED) == ANIMATION_STARTED)
			{
				view.onAnimationEnd();
				// Should be performed by onAnimationEnd() but this avoid an infinite loop,
				// so we'd rather be safe than sorry
				view.mPrivateFlags &= ~ANIMATION_STARTED;
				// Draw one more frame after the animation is done
				mGroupFlags |= FLAG_INVALIDATE_REQUIRED;
			}
		}

		/// <summary>
		/// Utility function called by View during invalidation to determine whether a view that
		/// is invisible or gone should still be invalidated because it is being transitioned (and
		/// therefore still needs to be drawn).
		/// </summary>
		/// <remarks>
		/// Utility function called by View during invalidation to determine whether a view that
		/// is invisible or gone should still be invalidated because it is being transitioned (and
		/// therefore still needs to be drawn).
		/// </remarks>
		internal virtual bool isViewTransitioning(android.view.View view)
		{
			return (mTransitioningViews != null && mTransitioningViews.contains(view));
		}

		/// <summary>
		/// This method tells the ViewGroup that the given View object, which should have this
		/// ViewGroup as its parent,
		/// should be kept around  (re-displayed when the ViewGroup draws its children) even if it
		/// is removed from its parent.
		/// </summary>
		/// <remarks>
		/// This method tells the ViewGroup that the given View object, which should have this
		/// ViewGroup as its parent,
		/// should be kept around  (re-displayed when the ViewGroup draws its children) even if it
		/// is removed from its parent. This allows animations, such as those used by
		/// <see cref="android.app.Fragment">android.app.Fragment</see>
		/// and
		/// <see cref="android.animation.LayoutTransition">android.animation.LayoutTransition
		/// 	</see>
		/// to animate
		/// the removal of views. A call to this method should always be accompanied by a later call
		/// to
		/// <see cref="endViewTransition(View)">endViewTransition(View)</see>
		/// , such as after an animation on the View has finished,
		/// so that the View finally gets removed.
		/// </remarks>
		/// <param name="view">The View object to be kept visible even if it gets removed from its parent.
		/// 	</param>
		public virtual void startViewTransition(android.view.View view)
		{
			if (view.mParent == this)
			{
				if (mTransitioningViews == null)
				{
					mTransitioningViews = new java.util.ArrayList<android.view.View>();
				}
				mTransitioningViews.add(view);
			}
		}

		/// <summary>
		/// This method should always be called following an earlier call to
		/// <see cref="startViewTransition(View)">startViewTransition(View)</see>
		/// . The given View is finally removed from its parent
		/// and will no longer be displayed. Note that this method does not perform the functionality
		/// of removing a view from its parent; it just discontinues the display of a View that
		/// has previously been removed.
		/// </summary>
		/// <returns>
		/// view The View object that has been removed but is being kept around in the visible
		/// hierarchy by an earlier call to
		/// <see cref="startViewTransition(View)">startViewTransition(View)</see>
		/// .
		/// </returns>
		public virtual void endViewTransition(android.view.View view)
		{
			if (mTransitioningViews != null)
			{
				mTransitioningViews.remove(view);
				java.util.ArrayList<android.view.View> disappearingChildren = mDisappearingChildren;
				if (disappearingChildren != null && disappearingChildren.contains(view))
				{
					disappearingChildren.remove(view);
					if (mVisibilityChangingChildren != null && mVisibilityChangingChildren.contains(view
						))
					{
						mVisibilityChangingChildren.remove(view);
					}
					else
					{
						if (view.mAttachInfo != null)
						{
							view.dispatchDetachedFromWindow();
						}
						if (view.mParent != null)
						{
							view.mParent = null;
						}
					}
					mGroupFlags |= FLAG_INVALIDATE_REQUIRED;
				}
			}
		}

		private sealed class _TransitionListener_4892 : android.animation.LayoutTransition
			.TransitionListener
		{
			public _TransitionListener_4892(ViewGroup _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.animation.LayoutTransition.TransitionListener"
				)]
			public void startTransition(android.animation.LayoutTransition transition, android.view.ViewGroup
				 container, android.view.View view, int transitionType)
			{
				// We only care about disappearing items, since we need special logic to keep
				// those items visible after they've been 'removed'
				if (transitionType == android.animation.LayoutTransition.DISAPPEARING)
				{
					this._enclosing.startViewTransition(view);
				}
			}

			[Sharpen.ImplementsInterface(@"android.animation.LayoutTransition.TransitionListener"
				)]
			public void endTransition(android.animation.LayoutTransition transition, android.view.ViewGroup
				 container, android.view.View view, int transitionType)
			{
				if (this._enclosing.mLayoutSuppressed && !transition.isChangingLayout())
				{
					this._enclosing.requestLayout();
					this._enclosing.mLayoutSuppressed = false;
				}
				if (transitionType == android.animation.LayoutTransition.DISAPPEARING && this._enclosing
					.mTransitioningViews != null)
				{
					this._enclosing.endViewTransition(view);
				}
			}

			private readonly ViewGroup _enclosing;
		}

		private android.animation.LayoutTransition.TransitionListener mLayoutTransitionListener;

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool gatherTransparentRegion(android.graphics.Region region)
		{
			// If no transparent regions requested, we are always opaque.
			bool meOpaque = (mPrivateFlags & android.view.View.REQUEST_TRANSPARENT_REGIONS) ==
				 0;
			if (meOpaque && region == null)
			{
				// The caller doesn't care about the region, so stop now.
				return true;
			}
			base.gatherTransparentRegion(region);
			android.view.View[] children = mChildren;
			int count = mChildrenCount;
			bool noneOfTheChildrenAreTransparent = true;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = children[i];
					if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE || child.getAnimation() != null)
					{
						if (!child.gatherTransparentRegion(region))
						{
							noneOfTheChildrenAreTransparent = false;
						}
					}
				}
			}
			return meOpaque || noneOfTheChildrenAreTransparent;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void requestTransparentRegion(android.view.View child)
		{
			if (child != null)
			{
				child.mPrivateFlags |= android.view.View.REQUEST_TRANSPARENT_REGIONS;
				if (mParent != null)
				{
					mParent.requestTransparentRegion(this);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool fitSystemWindows(android.graphics.Rect insets)
		{
			bool done = base.fitSystemWindows(insets);
			if (!done)
			{
				int count = mChildrenCount;
				android.view.View[] children = mChildren;
				{
					for (int i = 0; i < count; i++)
					{
						done = children[i].fitSystemWindows(insets);
						if (done)
						{
							break;
						}
					}
				}
			}
			return done;
		}

		/// <summary>
		/// Returns the animation listener to which layout animation events are
		/// sent.
		/// </summary>
		/// <remarks>
		/// Returns the animation listener to which layout animation events are
		/// sent.
		/// </remarks>
		/// <returns>
		/// an
		/// <see cref="android.view.animation.Animation.AnimationListener">android.view.animation.Animation.AnimationListener
		/// 	</see>
		/// </returns>
		public virtual android.view.animation.Animation.AnimationListener getLayoutAnimationListener
			()
		{
			return mAnimationListener;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			if ((mGroupFlags & FLAG_NOTIFY_CHILDREN_ON_DRAWABLE_STATE_CHANGE) != 0)
			{
				if ((mGroupFlags & FLAG_ADD_STATES_FROM_CHILDREN) != 0)
				{
					throw new System.InvalidOperationException("addStateFromChildren cannot be enabled if a"
						 + " child has duplicateParentState set to true");
				}
				android.view.View[] children = mChildren;
				int count = mChildrenCount;
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = children[i];
						if ((child.mViewFlags & DUPLICATE_PARENT_STATE) != 0)
						{
							child.refreshDrawableState();
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			android.view.View[] children = mChildren;
			int count = mChildrenCount;
			{
				for (int i = 0; i < count; i++)
				{
					children[i].jumpDrawablesToCurrentState();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int[] onCreateDrawableState(int extraSpace)
		{
			if ((mGroupFlags & FLAG_ADD_STATES_FROM_CHILDREN) == 0)
			{
				return base.onCreateDrawableState(extraSpace);
			}
			int need = 0;
			int n = getChildCount();
			{
				for (int i = 0; i < n; i++)
				{
					int[] childState = getChildAt(i).getDrawableState();
					if (childState != null)
					{
						need += childState.Length;
					}
				}
			}
			int[] state = base.onCreateDrawableState(extraSpace + need);
			{
				for (int i_1 = 0; i_1 < n; i_1++)
				{
					int[] childState = getChildAt(i_1).getDrawableState();
					if (childState != null)
					{
						state = mergeDrawableStates(state, childState);
					}
				}
			}
			return state;
		}

		/// <summary>
		/// Sets whether this ViewGroup's drawable states also include
		/// its children's drawable states.
		/// </summary>
		/// <remarks>
		/// Sets whether this ViewGroup's drawable states also include
		/// its children's drawable states.  This is used, for example, to
		/// make a group appear to be focused when its child EditText or button
		/// is focused.
		/// </remarks>
		public virtual void setAddStatesFromChildren(bool addsStates)
		{
			if (addsStates)
			{
				mGroupFlags |= FLAG_ADD_STATES_FROM_CHILDREN;
			}
			else
			{
				mGroupFlags &= ~FLAG_ADD_STATES_FROM_CHILDREN;
			}
			refreshDrawableState();
		}

		/// <summary>
		/// Returns whether this ViewGroup's drawable states also include
		/// its children's drawable states.
		/// </summary>
		/// <remarks>
		/// Returns whether this ViewGroup's drawable states also include
		/// its children's drawable states.  This is used, for example, to
		/// make a group appear to be focused when its child EditText or button
		/// is focused.
		/// </remarks>
		public virtual bool addStatesFromChildren()
		{
			return (mGroupFlags & FLAG_ADD_STATES_FROM_CHILDREN) != 0;
		}

		/// <summary>
		/// If {link #addStatesFromChildren} is true, refreshes this group's
		/// drawable state (to include the states from its children).
		/// </summary>
		/// <remarks>
		/// If {link #addStatesFromChildren} is true, refreshes this group's
		/// drawable state (to include the states from its children).
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public virtual void childDrawableStateChanged(android.view.View child)
		{
			if ((mGroupFlags & FLAG_ADD_STATES_FROM_CHILDREN) != 0)
			{
				refreshDrawableState();
			}
		}

		/// <summary>
		/// Specifies the animation listener to which layout animation events must
		/// be sent.
		/// </summary>
		/// <remarks>
		/// Specifies the animation listener to which layout animation events must
		/// be sent. Only
		/// <see cref="android.view.animation.Animation.AnimationListener.onAnimationStart(android.view.animation.Animation)
		/// 	">android.view.animation.Animation.AnimationListener.onAnimationStart(android.view.animation.Animation)
		/// 	</see>
		/// and
		/// <see cref="android.view.animation.Animation.AnimationListener.onAnimationEnd(android.view.animation.Animation)
		/// 	">android.view.animation.Animation.AnimationListener.onAnimationEnd(android.view.animation.Animation)
		/// 	</see>
		/// are invoked.
		/// </remarks>
		/// <param name="animationListener">the layout animation listener</param>
		public virtual void setLayoutAnimationListener(android.view.animation.Animation.AnimationListener
			 animationListener)
		{
			mAnimationListener = animationListener;
		}

		/// <summary>
		/// This method is called by LayoutTransition when there are 'changing' animations that need
		/// to start after the layout/setup phase.
		/// </summary>
		/// <remarks>
		/// This method is called by LayoutTransition when there are 'changing' animations that need
		/// to start after the layout/setup phase. The request is forwarded to the ViewAncestor, who
		/// starts all pending transitions prior to the drawing phase in the current traversal.
		/// </remarks>
		/// <param name="transition">The LayoutTransition to be started on the next traversal.
		/// 	</param>
		/// <hide></hide>
		public virtual void requestTransitionStart(android.animation.LayoutTransition transition
			)
		{
			android.view.ViewRootImpl viewAncestor = getViewRootImpl();
			if (viewAncestor != null)
			{
				viewAncestor.requestTransitionStart(transition);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void resetResolvedLayoutDirection()
		{
			base.resetResolvedLayoutDirection();
			// Take care of resetting the children resolution too
			int count = getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getLayoutDirection() == LAYOUT_DIRECTION_INHERIT)
					{
						child.resetResolvedLayoutDirection();
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void resetResolvedTextDirection()
		{
			base.resetResolvedTextDirection();
			// Take care of resetting the children resolution too
			int count = getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getTextDirection() == TEXT_DIRECTION_INHERIT)
					{
						child.resetResolvedTextDirection();
					}
				}
			}
		}

		/// <summary>
		/// Return true if the pressed state should be delayed for children or descendants of this
		/// ViewGroup.
		/// </summary>
		/// <remarks>
		/// Return true if the pressed state should be delayed for children or descendants of this
		/// ViewGroup. Generally, this should be done for containers that can scroll, such as a List.
		/// This prevents the pressed state from appearing when the user is actually trying to scroll
		/// the content.
		/// The default implementation returns true for compatibility reasons. Subclasses that do
		/// not scroll should generally override this method and return false.
		/// </remarks>
		public virtual bool shouldDelayChildPressedState()
		{
			return true;
		}

		/// <summary>
		/// LayoutParams are used by views to tell their parents how they want to be
		/// laid out.
		/// </summary>
		/// <remarks>
		/// LayoutParams are used by views to tell their parents how they want to be
		/// laid out. See
		/// <see cref="android.R.styleable.ViewGroup_Layout">ViewGroup Layout Attributes</see>
		/// for a list of all child view attributes that this class supports.
		/// <p>
		/// The base LayoutParams class just describes how big the view wants to be
		/// for both width and height. For each dimension, it can specify one of:
		/// <ul>
		/// <li>FILL_PARENT (renamed MATCH_PARENT in API Level 8 and higher), which
		/// means that the view wants to be as big as its parent (minus padding)
		/// <li> WRAP_CONTENT, which means that the view wants to be just big enough
		/// to enclose its content (plus padding)
		/// <li> an exact number
		/// </ul>
		/// There are subclasses of LayoutParams for different subclasses of
		/// ViewGroup. For example, AbsoluteLayout has its own subclass of
		/// LayoutParams which adds an X and Y value.</p>
		/// <div class="special reference">
		/// <h3>Developer Guides</h3>
		/// <p>For more information about creating user interface layouts, read the
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/ui/declaring-layout.html"&gt;XML Layouts</a> developer
		/// guide.</p></div>
		/// </remarks>
		/// <attr>ref android.R.styleable#ViewGroup_Layout_layout_height</attr>
		/// <attr>ref android.R.styleable#ViewGroup_Layout_layout_width</attr>
		public class LayoutParams
		{
			/// <summary>Special value for the height or width requested by a View.</summary>
			/// <remarks>
			/// Special value for the height or width requested by a View.
			/// FILL_PARENT means that the view wants to be as big as its parent,
			/// minus the parent's padding, if any. This value is deprecated
			/// starting in API Level 8 and replaced by
			/// <see cref="MATCH_PARENT">MATCH_PARENT</see>
			/// .
			/// </remarks>
			[System.Obsolete]
			public const int FILL_PARENT = -1;

			/// <summary>Special value for the height or width requested by a View.</summary>
			/// <remarks>
			/// Special value for the height or width requested by a View.
			/// MATCH_PARENT means that the view wants to be as big as its parent,
			/// minus the parent's padding, if any. Introduced in API Level 8.
			/// </remarks>
			public const int MATCH_PARENT = -1;

			/// <summary>Special value for the height or width requested by a View.</summary>
			/// <remarks>
			/// Special value for the height or width requested by a View.
			/// WRAP_CONTENT means that the view wants to be just large enough to fit
			/// its own internal content, taking its own padding into account.
			/// </remarks>
			public const int WRAP_CONTENT = -2;

			/// <summary>Information about how wide the view wants to be.</summary>
			/// <remarks>
			/// Information about how wide the view wants to be. Can be one of the
			/// constants FILL_PARENT (replaced by MATCH_PARENT ,
			/// in API Level 8) or WRAP_CONTENT. or an exact size.
			/// </remarks>
			public int width;

			/// <summary>Information about how tall the view wants to be.</summary>
			/// <remarks>
			/// Information about how tall the view wants to be. Can be one of the
			/// constants FILL_PARENT (replaced by MATCH_PARENT ,
			/// in API Level 8) or WRAP_CONTENT. or an exact size.
			/// </remarks>
			public int height;

			/// <summary>Used to animate layouts.</summary>
			/// <remarks>Used to animate layouts.</remarks>
			public android.view.animation.LayoutAnimationController.AnimationParameters layoutAnimationParameters;

			/// <summary>Creates a new set of layout parameters.</summary>
			/// <remarks>
			/// Creates a new set of layout parameters. The values are extracted from
			/// the supplied attributes set and context. The XML attributes mapped
			/// to this set of layout parameters are:
			/// <ul>
			/// <li><code>layout_width</code>: the width, either an exact value,
			/// <see cref="WRAP_CONTENT">WRAP_CONTENT</see>
			/// , or
			/// <see cref="FILL_PARENT">FILL_PARENT</see>
			/// (replaced by
			/// <see cref="MATCH_PARENT">MATCH_PARENT</see>
			/// in API Level 8)</li>
			/// <li><code>layout_height</code>: the height, either an exact value,
			/// <see cref="WRAP_CONTENT">WRAP_CONTENT</see>
			/// , or
			/// <see cref="FILL_PARENT">FILL_PARENT</see>
			/// (replaced by
			/// <see cref="MATCH_PARENT">MATCH_PARENT</see>
			/// in API Level 8)</li>
			/// </ul>
			/// </remarks>
			/// <param name="c">the application environment</param>
			/// <param name="attrs">
			/// the set of attributes from which to extract the layout
			/// parameters' values
			/// </param>
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs)
			{
				android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.ViewGroup_Layout);
				setBaseAttributes(a, android.@internal.R.styleable.ViewGroup_Layout_layout_width, 
					android.@internal.R.styleable.ViewGroup_Layout_layout_height);
				a.recycle();
			}

			/// <summary>
			/// Creates a new set of layout parameters with the specified width
			/// and height.
			/// </summary>
			/// <remarks>
			/// Creates a new set of layout parameters with the specified width
			/// and height.
			/// </remarks>
			/// <param name="width">
			/// the width, either
			/// <see cref="WRAP_CONTENT">WRAP_CONTENT</see>
			/// ,
			/// <see cref="FILL_PARENT">FILL_PARENT</see>
			/// (replaced by
			/// <see cref="MATCH_PARENT">MATCH_PARENT</see>
			/// in
			/// API Level 8), or a fixed size in pixels
			/// </param>
			/// <param name="height">
			/// the height, either
			/// <see cref="WRAP_CONTENT">WRAP_CONTENT</see>
			/// ,
			/// <see cref="FILL_PARENT">FILL_PARENT</see>
			/// (replaced by
			/// <see cref="MATCH_PARENT">MATCH_PARENT</see>
			/// in
			/// API Level 8), or a fixed size in pixels
			/// </param>
			public LayoutParams(int width, int height)
			{
				this.width = width;
				this.height = height;
			}

			/// <summary>Copy constructor.</summary>
			/// <remarks>Copy constructor. Clones the width and height values of the source.</remarks>
			/// <param name="source">The layout params to copy from.</param>
			public LayoutParams(android.view.ViewGroup.LayoutParams source)
			{
				this.width = source.width;
				this.height = source.height;
			}

			/// <summary>Used internally by MarginLayoutParams.</summary>
			/// <remarks>Used internally by MarginLayoutParams.</remarks>
			/// <hide></hide>
			internal LayoutParams()
			{
			}

			/// <summary>Extracts the layout parameters from the supplied attributes.</summary>
			/// <remarks>Extracts the layout parameters from the supplied attributes.</remarks>
			/// <param name="a">the style attributes to extract the parameters from</param>
			/// <param name="widthAttr">the identifier of the width attribute</param>
			/// <param name="heightAttr">the identifier of the height attribute</param>
			protected internal virtual void setBaseAttributes(android.content.res.TypedArray 
				a, int widthAttr, int heightAttr)
			{
				width = a.getLayoutDimension(widthAttr, "layout_width");
				height = a.getLayoutDimension(heightAttr, "layout_height");
			}

			/// <summary>Resolve layout parameters depending on the layout direction.</summary>
			/// <remarks>
			/// Resolve layout parameters depending on the layout direction. Subclasses that care about
			/// layoutDirection changes should override this method. The default implementation does
			/// nothing.
			/// </remarks>
			/// <param name="layoutDirection">
			/// the direction of the layout
			/// <see cref="View.LAYOUT_DIRECTION_LTR">View.LAYOUT_DIRECTION_LTR</see>
			/// <see cref="View.LAYOUT_DIRECTION_RTL">View.LAYOUT_DIRECTION_RTL</see>
			/// </param>
			/// <hide></hide>
			protected internal virtual void resolveWithDirection(int layoutDirection)
			{
			}

			/// <summary>Returns a String representation of this set of layout parameters.</summary>
			/// <remarks>Returns a String representation of this set of layout parameters.</remarks>
			/// <param name="output">the String to prepend to the internal representation</param>
			/// <returns>
			/// a String with the following format: output +
			/// "ViewGroup.LayoutParams={ width=WIDTH, height=HEIGHT }"
			/// </returns>
			/// <hide></hide>
			public virtual string debug(string output)
			{
				return output + "ViewGroup.LayoutParams={ width=" + sizeToString(width) + ", height="
					 + sizeToString(height) + " }";
			}

			/// <summary>Converts the specified size to a readable String.</summary>
			/// <remarks>Converts the specified size to a readable String.</remarks>
			/// <param name="size">the size to convert</param>
			/// <returns>a String instance representing the supplied size</returns>
			/// <hide></hide>
			protected internal static string sizeToString(int size)
			{
				if (size == WRAP_CONTENT)
				{
					return "wrap-content";
				}
				if (size == MATCH_PARENT)
				{
					return "match-parent";
				}
				return size.ToString();
			}
		}

		/// <summary>Per-child layout information for layouts that support margins.</summary>
		/// <remarks>
		/// Per-child layout information for layouts that support margins.
		/// See
		/// <see cref="android.R.styleable.ViewGroup_MarginLayout">ViewGroup Margin Layout Attributes
		/// 	</see>
		/// for a list of all child view attributes that this class supports.
		/// </remarks>
		public class MarginLayoutParams : android.view.ViewGroup.LayoutParams
		{
			/// <summary>The left margin in pixels of the child.</summary>
			/// <remarks>
			/// The left margin in pixels of the child. Whenever this value is changed, a call to
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// needs to be done.
			/// </remarks>
			public int leftMargin;

			/// <summary>The top margin in pixels of the child.</summary>
			/// <remarks>
			/// The top margin in pixels of the child. Whenever this value is changed, a call to
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// needs to be done.
			/// </remarks>
			public int topMargin;

			/// <summary>The right margin in pixels of the child.</summary>
			/// <remarks>
			/// The right margin in pixels of the child. Whenever this value is changed, a call to
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// needs to be done.
			/// </remarks>
			public int rightMargin;

			/// <summary>The bottom margin in pixels of the child.</summary>
			/// <remarks>
			/// The bottom margin in pixels of the child. Whenever this value is changed, a call to
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// needs to be done.
			/// </remarks>
			public int bottomMargin;

			/// <summary>The start margin in pixels of the child.</summary>
			/// <remarks>The start margin in pixels of the child.</remarks>
			/// <hide></hide>
			protected internal int startMargin = DEFAULT_RELATIVE;

			/// <summary>The end margin in pixels of the child.</summary>
			/// <remarks>The end margin in pixels of the child.</remarks>
			/// <hide></hide>
			protected internal int endMargin = DEFAULT_RELATIVE;

			/// <summary>The default start and end margin.</summary>
			/// <remarks>The default start and end margin.</remarks>
			internal const int DEFAULT_RELATIVE = int.MinValue;

			/// <summary>Creates a new set of layout parameters.</summary>
			/// <remarks>
			/// Creates a new set of layout parameters. The values are extracted from
			/// the supplied attributes set and context.
			/// </remarks>
			/// <param name="c">the application environment</param>
			/// <param name="attrs">
			/// the set of attributes from which to extract the layout
			/// parameters' values
			/// </param>
			public MarginLayoutParams(android.content.Context c, android.util.AttributeSet attrs
				) : base()
			{
				android.content.res.TypedArray a = c.obtainStyledAttributes(attrs, android.@internal.R
					.styleable.ViewGroup_MarginLayout);
				setBaseAttributes(a, android.@internal.R.styleable.ViewGroup_MarginLayout_layout_width
					, android.@internal.R.styleable.ViewGroup_MarginLayout_layout_height);
				int margin = a.getDimensionPixelSize(android.@internal.R.styleable.ViewGroup_MarginLayout_layout_margin
					, -1);
				if (margin >= 0)
				{
					leftMargin = margin;
					topMargin = margin;
					rightMargin = margin;
					bottomMargin = margin;
				}
				else
				{
					leftMargin = a.getDimensionPixelSize(android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginLeft
						, 0);
					topMargin = a.getDimensionPixelSize(android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginTop
						, 0);
					rightMargin = a.getDimensionPixelSize(android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginRight
						, 0);
					bottomMargin = a.getDimensionPixelSize(android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginBottom
						, 0);
					startMargin = a.getDimensionPixelSize(android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginStart
						, DEFAULT_RELATIVE);
					endMargin = a.getDimensionPixelSize(android.@internal.R.styleable.ViewGroup_MarginLayout_layout_marginEnd
						, DEFAULT_RELATIVE);
				}
				a.recycle();
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public MarginLayoutParams(int width, int height) : base(width, height)
			{
			}

			/// <summary>Copy constructor.</summary>
			/// <remarks>Copy constructor. Clones the width, height and margin values of the source.
			/// 	</remarks>
			/// <param name="source">The layout params to copy from.</param>
			public MarginLayoutParams(android.view.ViewGroup.MarginLayoutParams source)
			{
				this.width = source.width;
				this.height = source.height;
				this.leftMargin = source.leftMargin;
				this.topMargin = source.topMargin;
				this.rightMargin = source.rightMargin;
				this.bottomMargin = source.bottomMargin;
				this.startMargin = source.startMargin;
				this.endMargin = source.endMargin;
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public MarginLayoutParams(android.view.ViewGroup.LayoutParams source) : base(source
				)
			{
			}

			/// <summary>Sets the margins, in pixels.</summary>
			/// <remarks>
			/// Sets the margins, in pixels. A call to
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// needs
			/// to be done so that the new margins are taken into account. Left and right margins may be
			/// overriden by
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// depending on layout direction.
			/// </remarks>
			/// <param name="left">the left margin size</param>
			/// <param name="top">the top margin size</param>
			/// <param name="right">the right margin size</param>
			/// <param name="bottom">the bottom margin size</param>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginLeft</attr>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginTop</attr>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginRight</attr>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginBottom</attr>
			public virtual void setMargins(int left, int top, int right, int bottom)
			{
				leftMargin = left;
				topMargin = top;
				rightMargin = right;
				bottomMargin = bottom;
			}

			/// <summary>Sets the relative margins, in pixels.</summary>
			/// <remarks>
			/// Sets the relative margins, in pixels. A call to
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// needs to be done so that the new relative margins are taken into account. Left and right
			/// margins may be overriden by
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// depending on layout
			/// direction.
			/// </remarks>
			/// <param name="start">the start margin size</param>
			/// <param name="top">the top margin size</param>
			/// <param name="end">the right margin size</param>
			/// <param name="bottom">the bottom margin size</param>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginStart</attr>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginTop</attr>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginEnd</attr>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginBottom</attr>
			/// <hide></hide>
			public virtual void setMarginsRelative(int start, int top, int end, int bottom)
			{
				startMargin = start;
				topMargin = top;
				endMargin = end;
				bottomMargin = bottom;
			}

			/// <summary>Returns the start margin in pixels.</summary>
			/// <remarks>Returns the start margin in pixels.</remarks>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginStart</attr>
			/// <returns>the start margin in pixels.</returns>
			/// <hide></hide>
			public virtual int getMarginStart()
			{
				return startMargin;
			}

			/// <summary>Returns the end margin in pixels.</summary>
			/// <remarks>Returns the end margin in pixels.</remarks>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginEnd</attr>
			/// <returns>the end margin in pixels.</returns>
			/// <hide></hide>
			public virtual int getMarginEnd()
			{
				return endMargin;
			}

			/// <summary>Check if margins are relative.</summary>
			/// <remarks>Check if margins are relative.</remarks>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginStart</attr>
			/// <attr>ref android.R.styleable#ViewGroup_MarginLayout_layout_marginEnd</attr>
			/// <returns>true if either marginStart or marginEnd has been set</returns>
			/// <hide></hide>
			public virtual bool isMarginRelative()
			{
				return (startMargin != DEFAULT_RELATIVE) || (endMargin != DEFAULT_RELATIVE);
			}

			/// <summary>
			/// This will be called by
			/// <see cref="View.requestLayout()">View.requestLayout()</see>
			/// . Left and Right margins
			/// maybe overriden depending on layout direction.
			/// </summary>
			/// <hide></hide>
			[Sharpen.OverridesMethod(@"android.view.ViewGroup.LayoutParams")]
			protected internal override void resolveWithDirection(int layoutDirection)
			{
				switch (layoutDirection)
				{
					case android.view.View.LAYOUT_DIRECTION_RTL:
					{
						leftMargin = (endMargin > DEFAULT_RELATIVE) ? endMargin : leftMargin;
						rightMargin = (startMargin > DEFAULT_RELATIVE) ? startMargin : rightMargin;
						break;
					}

					case android.view.View.LAYOUT_DIRECTION_LTR:
					default:
					{
						leftMargin = (startMargin > DEFAULT_RELATIVE) ? startMargin : leftMargin;
						rightMargin = (endMargin > DEFAULT_RELATIVE) ? endMargin : rightMargin;
						break;
					}
				}
			}
		}

		private sealed class TouchTarget
		{
			internal const int MAX_RECYCLED = 32;

			internal static readonly object sRecycleLock = new object();

			internal static android.view.ViewGroup.TouchTarget sRecycleBin;

			internal static int sRecycledCount;

			public const int ALL_POINTER_IDS = -1;

			public android.view.View child;

			public int pointerIdBits;

			internal android.view.ViewGroup.TouchTarget next;

			internal TouchTarget()
			{
			}

			// all ones
			// The touched child view.
			// The combined bit mask of pointer ids for all pointers captured by the target.
			// The next target in the target list.
			public static android.view.ViewGroup.TouchTarget obtain(android.view.View child, 
				int pointerIdBits)
			{
				android.view.ViewGroup.TouchTarget target;
				lock (sRecycleLock)
				{
					if (sRecycleBin == null)
					{
						target = new android.view.ViewGroup.TouchTarget();
					}
					else
					{
						target = sRecycleBin;
						sRecycleBin = target.next;
						sRecycledCount--;
						target.next = null;
					}
				}
				target.child = child;
				target.pointerIdBits = pointerIdBits;
				return target;
			}

			public void recycle()
			{
				lock (sRecycleLock)
				{
					if (sRecycledCount < MAX_RECYCLED)
					{
						next = sRecycleBin;
						sRecycleBin = this;
						sRecycledCount += 1;
					}
					else
					{
						next = null;
					}
					child = null;
				}
			}
		}

		private sealed class HoverTarget
		{
			internal const int MAX_RECYCLED = 32;

			internal static readonly object sRecycleLock = new object();

			internal static android.view.ViewGroup.HoverTarget sRecycleBin;

			internal static int sRecycledCount;

			public android.view.View child;

			internal android.view.ViewGroup.HoverTarget next;

			internal HoverTarget()
			{
			}

			// The hovered child view.
			// The next target in the target list.
			public static android.view.ViewGroup.HoverTarget obtain(android.view.View child)
			{
				android.view.ViewGroup.HoverTarget target;
				lock (sRecycleLock)
				{
					if (sRecycleBin == null)
					{
						target = new android.view.ViewGroup.HoverTarget();
					}
					else
					{
						target = sRecycleBin;
						sRecycleBin = target.next;
						sRecycledCount--;
						target.next = null;
					}
				}
				target.child = child;
				return target;
			}

			public void recycle()
			{
				lock (sRecycleLock)
				{
					if (sRecycledCount < MAX_RECYCLED)
					{
						next = sRecycleBin;
						sRecycleBin = this;
						sRecycledCount += 1;
					}
					else
					{
						next = null;
					}
					child = null;
				}
			}
		}
	}
}
