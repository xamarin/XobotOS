using Sharpen;

namespace android.view
{
	/// <summary>
	/// <p>
	/// This class represents the basic building block for user interface components.
	/// </summary>
	/// <remarks>
	/// <p>
	/// This class represents the basic building block for user interface components. A View
	/// occupies a rectangular area on the screen and is responsible for drawing and
	/// event handling. View is the base class for <em>widgets</em>, which are
	/// used to create interactive UI components (buttons, text fields, etc.). The
	/// <see cref="ViewGroup">ViewGroup</see>
	/// subclass is the base class for <em>layouts</em>, which
	/// are invisible containers that hold other Views (or other ViewGroups) and define
	/// their layout properties.
	/// </p>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about using this class to develop your application's user interface,
	/// read the &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/index.html"&gt;User Interface</a> developer guide.
	/// </div>
	/// <a name="Using"></a>
	/// <h3>Using Views</h3>
	/// <p>
	/// All of the views in a window are arranged in a single tree. You can add views
	/// either from code or by specifying a tree of views in one or more XML layout
	/// files. There are many specialized subclasses of views that act as controls or
	/// are capable of displaying text, images, or other content.
	/// </p>
	/// <p>
	/// Once you have created a tree of views, there are typically a few types of
	/// common operations you may wish to perform:
	/// <ul>
	/// <li><strong>Set properties:</strong> for example setting the text of a
	/// <see cref="android.widget.TextView">android.widget.TextView</see>
	/// . The available properties and the methods
	/// that set them will vary among the different subclasses of views. Note that
	/// properties that are known at build time can be set in the XML layout
	/// files.</li>
	/// <li><strong>Set focus:</strong> The framework will handled moving focus in
	/// response to user input. To force focus to a specific view, call
	/// <see cref="requestFocus()">requestFocus()</see>
	/// .</li>
	/// <li><strong>Set up listeners:</strong> Views allow clients to set listeners
	/// that will be notified when something interesting happens to the view. For
	/// example, all views will let you set a listener to be notified when the view
	/// gains or loses focus. You can register such a listener using
	/// <see cref="setOnFocusChangeListener(OnFocusChangeListener)">setOnFocusChangeListener(OnFocusChangeListener)
	/// 	</see>
	/// .
	/// Other view subclasses offer more specialized listeners. For example, a Button
	/// exposes a listener to notify clients when the button is clicked.</li>
	/// <li><strong>Set visibility:</strong> You can hide or show views using
	/// <see cref="setVisibility(int)">setVisibility(int)</see>
	/// .</li>
	/// </ul>
	/// </p>
	/// <p><em>
	/// Note: The Android framework is responsible for measuring, laying out and
	/// drawing views. You should not call methods that perform these actions on
	/// views yourself unless you are actually implementing a
	/// <see cref="ViewGroup">ViewGroup</see>
	/// .
	/// </em></p>
	/// <a name="Lifecycle"></a>
	/// <h3>Implementing a Custom View</h3>
	/// <p>
	/// To implement a custom view, you will usually begin by providing overrides for
	/// some of the standard methods that the framework calls on all views. You do
	/// not need to override all of these methods. In fact, you can start by just
	/// overriding
	/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
	/// .
	/// <table border="2" width="85%" align="center" cellpadding="5">
	/// <thead>
	/// <tr><th>Category</th> <th>Methods</th> <th>Description</th></tr>
	/// </thead>
	/// <tbody>
	/// <tr>
	/// <td rowspan="2">Creation</td>
	/// <td>Constructors</td>
	/// <td>There is a form of the constructor that are called when the view
	/// is created from code and a form that is called when the view is
	/// inflated from a layout file. The second form should parse and apply
	/// any attributes defined in the layout file.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onFinishInflate()">onFinishInflate()</see>
	/// </code></td>
	/// <td>Called after a view and all of its children has been inflated
	/// from XML.</td>
	/// </tr>
	/// <tr>
	/// <td rowspan="3">Layout</td>
	/// <td><code>
	/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
	/// </code></td>
	/// <td>Called to determine the size requirements for this view and all
	/// of its children.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onLayout(bool, int, int, int, int)">onLayout(bool, int, int, int, int)
	/// 	</see>
	/// </code></td>
	/// <td>Called when this view should assign a size and position to all
	/// of its children.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onSizeChanged(int, int, int, int)">onSizeChanged(int, int, int, int)</see>
	/// </code></td>
	/// <td>Called when the size of this view has changed.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td>Drawing</td>
	/// <td><code>
	/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
	/// </code></td>
	/// <td>Called when the view should render its content.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td rowspan="4">Event processing</td>
	/// <td><code>
	/// <see cref="onKeyDown(int, KeyEvent)">onKeyDown(int, KeyEvent)</see>
	/// </code></td>
	/// <td>Called when a new key event occurs.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onKeyUp(int, KeyEvent)">onKeyUp(int, KeyEvent)</see>
	/// </code></td>
	/// <td>Called when a key up event occurs.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onTrackballEvent(MotionEvent)">onTrackballEvent(MotionEvent)</see>
	/// </code></td>
	/// <td>Called when a trackball motion event occurs.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onTouchEvent(MotionEvent)">onTouchEvent(MotionEvent)</see>
	/// </code></td>
	/// <td>Called when a touch screen motion event occurs.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td rowspan="2">Focus</td>
	/// <td><code>
	/// <see cref="onFocusChanged(bool, int, android.graphics.Rect)">onFocusChanged(bool, int, android.graphics.Rect)
	/// 	</see>
	/// </code></td>
	/// <td>Called when the view gains or loses focus.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onWindowFocusChanged(bool)">onWindowFocusChanged(bool)</see>
	/// </code></td>
	/// <td>Called when the window containing the view gains or loses focus.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td rowspan="3">Attaching</td>
	/// <td><code>
	/// <see cref="onAttachedToWindow()">onAttachedToWindow()</see>
	/// </code></td>
	/// <td>Called when the view is attached to a window.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onDetachedFromWindow()">onDetachedFromWindow()</see>
	/// </code></td>
	/// <td>Called when the view is detached from its window.
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><code>
	/// <see cref="onWindowVisibilityChanged(int)">onWindowVisibilityChanged(int)</see>
	/// </code></td>
	/// <td>Called when the visibility of the window containing the view
	/// has changed.
	/// </td>
	/// </tr>
	/// </tbody>
	/// </table>
	/// </p>
	/// <a name="IDs"></a>
	/// <h3>IDs</h3>
	/// Views may have an integer id associated with them. These ids are typically
	/// assigned in the layout XML files, and are used to find specific views within
	/// the view tree. A common pattern is to:
	/// <ul>
	/// <li>Define a Button in the layout file and assign it a unique ID.
	/// <pre>
	/// &lt;Button
	/// android:id="@+id/my_button"
	/// android:layout_width="wrap_content"
	/// android:layout_height="wrap_content"
	/// android:text="@string/my_button_text"/&gt;
	/// </pre></li>
	/// <li>From the onCreate method of an Activity, find the Button
	/// <pre class="prettyprint">
	/// Button myButton = (Button) findViewById(R.id.my_button);
	/// </pre></li>
	/// </ul>
	/// <p>
	/// View IDs need not be unique throughout the tree, but it is good practice to
	/// ensure that they are at least unique within the part of the tree you are
	/// searching.
	/// </p>
	/// <a name="Position"></a>
	/// <h3>Position</h3>
	/// <p>
	/// The geometry of a view is that of a rectangle. A view has a location,
	/// expressed as a pair of <em>left</em> and <em>top</em> coordinates, and
	/// two dimensions, expressed as a width and a height. The unit for location
	/// and dimensions is the pixel.
	/// </p>
	/// <p>
	/// It is possible to retrieve the location of a view by invoking the methods
	/// <see cref="getLeft()">getLeft()</see>
	/// and
	/// <see cref="getTop()">getTop()</see>
	/// . The former returns the left, or X,
	/// coordinate of the rectangle representing the view. The latter returns the
	/// top, or Y, coordinate of the rectangle representing the view. These methods
	/// both return the location of the view relative to its parent. For instance,
	/// when getLeft() returns 20, that means the view is located 20 pixels to the
	/// right of the left edge of its direct parent.
	/// </p>
	/// <p>
	/// In addition, several convenience methods are offered to avoid unnecessary
	/// computations, namely
	/// <see cref="getRight()">getRight()</see>
	/// and
	/// <see cref="getBottom()">getBottom()</see>
	/// .
	/// These methods return the coordinates of the right and bottom edges of the
	/// rectangle representing the view. For instance, calling
	/// <see cref="getRight()">getRight()</see>
	/// is similar to the following computation: <code>getLeft() + getWidth()</code>
	/// (see <a href="#SizePaddingMargins">Size</a> for more information about the width.)
	/// </p>
	/// <a name="SizePaddingMargins"></a>
	/// <h3>Size, padding and margins</h3>
	/// <p>
	/// The size of a view is expressed with a width and a height. A view actually
	/// possess two pairs of width and height values.
	/// </p>
	/// <p>
	/// The first pair is known as <em>measured width</em> and
	/// <em>measured height</em>. These dimensions define how big a view wants to be
	/// within its parent (see <a href="#Layout">Layout</a> for more details.) The
	/// measured dimensions can be obtained by calling
	/// <see cref="getMeasuredWidth()">getMeasuredWidth()</see>
	/// and
	/// <see cref="getMeasuredHeight()">getMeasuredHeight()</see>
	/// .
	/// </p>
	/// <p>
	/// The second pair is simply known as <em>width</em> and <em>height</em>, or
	/// sometimes <em>drawing width</em> and <em>drawing height</em>. These
	/// dimensions define the actual size of the view on screen, at drawing time and
	/// after layout. These values may, but do not have to, be different from the
	/// measured width and height. The width and height can be obtained by calling
	/// <see cref="getWidth()">getWidth()</see>
	/// and
	/// <see cref="getHeight()">getHeight()</see>
	/// .
	/// </p>
	/// <p>
	/// To measure its dimensions, a view takes into account its padding. The padding
	/// is expressed in pixels for the left, top, right and bottom parts of the view.
	/// Padding can be used to offset the content of the view by a specific amount of
	/// pixels. For instance, a left padding of 2 will push the view's content by
	/// 2 pixels to the right of the left edge. Padding can be set using the
	/// <see cref="setPadding(int, int, int, int)">setPadding(int, int, int, int)</see>
	/// method and queried by calling
	/// <see cref="getPaddingLeft()">getPaddingLeft()</see>
	/// ,
	/// <see cref="getPaddingTop()">getPaddingTop()</see>
	/// ,
	/// <see cref="getPaddingRight()">getPaddingRight()</see>
	/// ,
	/// <see cref="getPaddingBottom()">getPaddingBottom()</see>
	/// .
	/// </p>
	/// <p>
	/// Even though a view can define a padding, it does not provide any support for
	/// margins. However, view groups provide such a support. Refer to
	/// <see cref="ViewGroup">ViewGroup</see>
	/// and
	/// <see cref="MarginLayoutParams">MarginLayoutParams</see>
	/// for further information.
	/// </p>
	/// <a name="Layout"></a>
	/// <h3>Layout</h3>
	/// <p>
	/// Layout is a two pass process: a measure pass and a layout pass. The measuring
	/// pass is implemented in
	/// <see cref="measure(int, int)">measure(int, int)</see>
	/// and is a top-down traversal
	/// of the view tree. Each view pushes dimension specifications down the tree
	/// during the recursion. At the end of the measure pass, every view has stored
	/// its measurements. The second pass happens in
	/// <see cref="layout(int, int, int, int)">layout(int, int, int, int)</see>
	/// and is also top-down. During
	/// this pass each parent is responsible for positioning all of its children
	/// using the sizes computed in the measure pass.
	/// </p>
	/// <p>
	/// When a view's measure() method returns, its
	/// <see cref="getMeasuredWidth()">getMeasuredWidth()</see>
	/// and
	/// <see cref="getMeasuredHeight()">getMeasuredHeight()</see>
	/// values must be set, along with those for all of
	/// that view's descendants. A view's measured width and measured height values
	/// must respect the constraints imposed by the view's parents. This guarantees
	/// that at the end of the measure pass, all parents accept all of their
	/// children's measurements. A parent view may call measure() more than once on
	/// its children. For example, the parent may measure each child once with
	/// unspecified dimensions to find out how big they want to be, then call
	/// measure() on them again with actual numbers if the sum of all the children's
	/// unconstrained sizes is too big or too small.
	/// </p>
	/// <p>
	/// The measure pass uses two classes to communicate dimensions. The
	/// <see cref="MeasureSpec">MeasureSpec</see>
	/// class is used by views to tell their parents how they
	/// want to be measured and positioned. The base LayoutParams class just
	/// describes how big the view wants to be for both width and height. For each
	/// dimension, it can specify one of:
	/// <ul>
	/// <li> an exact number
	/// <li>MATCH_PARENT, which means the view wants to be as big as its parent
	/// (minus padding)
	/// <li> WRAP_CONTENT, which means that the view wants to be just big enough to
	/// enclose its content (plus padding).
	/// </ul>
	/// There are subclasses of LayoutParams for different subclasses of ViewGroup.
	/// For example, AbsoluteLayout has its own subclass of LayoutParams which adds
	/// an X and Y value.
	/// </p>
	/// <p>
	/// MeasureSpecs are used to push requirements down the tree from parent to
	/// child. A MeasureSpec can be in one of three modes:
	/// <ul>
	/// <li>UNSPECIFIED: This is used by a parent to determine the desired dimension
	/// of a child view. For example, a LinearLayout may call measure() on its child
	/// with the height set to UNSPECIFIED and a width of EXACTLY 240 to find out how
	/// tall the child view wants to be given a width of 240 pixels.
	/// <li>EXACTLY: This is used by the parent to impose an exact size on the
	/// child. The child must use this size, and guarantee that all of its
	/// descendants will fit within this size.
	/// <li>AT_MOST: This is used by the parent to impose a maximum size on the
	/// child. The child must gurantee that it and all of its descendants will fit
	/// within this size.
	/// </ul>
	/// </p>
	/// <p>
	/// To intiate a layout, call
	/// <see cref="requestLayout()">requestLayout()</see>
	/// . This method is typically
	/// called by a view on itself when it believes that is can no longer fit within
	/// its current bounds.
	/// </p>
	/// <a name="Drawing"></a>
	/// <h3>Drawing</h3>
	/// <p>
	/// Drawing is handled by walking the tree and rendering each view that
	/// intersects the invalid region. Because the tree is traversed in-order,
	/// this means that parents will draw before (i.e., behind) their children, with
	/// siblings drawn in the order they appear in the tree.
	/// If you set a background drawable for a View, then the View will draw it for you
	/// before calling back to its <code>onDraw()</code> method.
	/// </p>
	/// <p>
	/// Note that the framework will not draw views that are not in the invalid region.
	/// </p>
	/// <p>
	/// To force a view to draw, call
	/// <see cref="invalidate()">invalidate()</see>
	/// .
	/// </p>
	/// <a name="EventHandlingThreading"></a>
	/// <h3>Event Handling and Threading</h3>
	/// <p>
	/// The basic cycle of a view is as follows:
	/// <ol>
	/// <li>An event comes in and is dispatched to the appropriate view. The view
	/// handles the event and notifies any listeners.</li>
	/// <li>If in the course of processing the event, the view's bounds may need
	/// to be changed, the view will call
	/// <see cref="requestLayout()">requestLayout()</see>
	/// .</li>
	/// <li>Similarly, if in the course of processing the event the view's appearance
	/// may need to be changed, the view will call
	/// <see cref="invalidate()">invalidate()</see>
	/// .</li>
	/// <li>If either
	/// <see cref="requestLayout()">requestLayout()</see>
	/// or
	/// <see cref="invalidate()">invalidate()</see>
	/// were called,
	/// the framework will take care of measuring, laying out, and drawing the tree
	/// as appropriate.</li>
	/// </ol>
	/// </p>
	/// <p><em>Note: The entire view tree is single threaded. You must always be on
	/// the UI thread when calling any method on any view.</em>
	/// If you are doing work on other threads and want to update the state of a view
	/// from that thread, you should use a
	/// <see cref="android.os.Handler">android.os.Handler</see>
	/// .
	/// </p>
	/// <a name="FocusHandling"></a>
	/// <h3>Focus Handling</h3>
	/// <p>
	/// The framework will handle routine focus movement in response to user input.
	/// This includes changing the focus as views are removed or hidden, or as new
	/// views become available. Views indicate their willingness to take focus
	/// through the
	/// <see cref="isFocusable()">isFocusable()</see>
	/// method. To change whether a view can take
	/// focus, call
	/// <see cref="setFocusable(bool)">setFocusable(bool)</see>
	/// .  When in touch mode (see notes below)
	/// views indicate whether they still would like focus via
	/// <see cref="isFocusableInTouchMode()">isFocusableInTouchMode()</see>
	/// and can change this via
	/// <see cref="setFocusableInTouchMode(bool)">setFocusableInTouchMode(bool)</see>
	/// .
	/// </p>
	/// <p>
	/// Focus movement is based on an algorithm which finds the nearest neighbor in a
	/// given direction. In rare cases, the default algorithm may not match the
	/// intended behavior of the developer. In these situations, you can provide
	/// explicit overrides by using these XML attributes in the layout file:
	/// <pre>
	/// nextFocusDown
	/// nextFocusLeft
	/// nextFocusRight
	/// nextFocusUp
	/// </pre>
	/// </p>
	/// <p>
	/// To get a particular view to take focus, call
	/// <see cref="requestFocus()">requestFocus()</see>
	/// .
	/// </p>
	/// <a name="TouchMode"></a>
	/// <h3>Touch Mode</h3>
	/// <p>
	/// When a user is navigating a user interface via directional keys such as a D-pad, it is
	/// necessary to give focus to actionable items such as buttons so the user can see
	/// what will take input.  If the device has touch capabilities, however, and the user
	/// begins interacting with the interface by touching it, it is no longer necessary to
	/// always highlight, or give focus to, a particular view.  This motivates a mode
	/// for interaction named 'touch mode'.
	/// </p>
	/// <p>
	/// For a touch capable device, once the user touches the screen, the device
	/// will enter touch mode.  From this point onward, only views for which
	/// <see cref="isFocusableInTouchMode()">isFocusableInTouchMode()</see>
	/// is true will be focusable, such as text editing widgets.
	/// Other views that are touchable, like buttons, will not take focus when touched; they will
	/// only fire the on click listeners.
	/// </p>
	/// <p>
	/// Any time a user hits a directional key, such as a D-pad direction, the view device will
	/// exit touch mode, and find a view to take focus, so that the user may resume interacting
	/// with the user interface without touching the screen again.
	/// </p>
	/// <p>
	/// The touch mode state is maintained across
	/// <see cref="android.app.Activity">android.app.Activity</see>
	/// s.  Call
	/// <see cref="isInTouchMode()">isInTouchMode()</see>
	/// to see whether the device is currently in touch mode.
	/// </p>
	/// <a name="Scrolling"></a>
	/// <h3>Scrolling</h3>
	/// <p>
	/// The framework provides basic support for views that wish to internally
	/// scroll their content. This includes keeping track of the X and Y scroll
	/// offset as well as mechanisms for drawing scrollbars. See
	/// <see cref="scrollBy(int, int)">scrollBy(int, int)</see>
	/// ,
	/// <see cref="scrollTo(int, int)">scrollTo(int, int)</see>
	/// , and
	/// <see cref="awakenScrollBars()">awakenScrollBars()</see>
	/// for more details.
	/// </p>
	/// <a name="Tags"></a>
	/// <h3>Tags</h3>
	/// <p>
	/// Unlike IDs, tags are not used to identify views. Tags are essentially an
	/// extra piece of information that can be associated with a view. They are most
	/// often used as a convenience to store data related to views in the views
	/// themselves rather than by putting them in a separate structure.
	/// </p>
	/// <a name="Animation"></a>
	/// <h3>Animation</h3>
	/// <p>
	/// You can attach an
	/// <see cref="android.view.animation.Animation">android.view.animation.Animation</see>
	/// object to a view using
	/// <see cref="setAnimation(android.view.animation.Animation)">setAnimation(android.view.animation.Animation)
	/// 	</see>
	/// or
	/// <see cref="startAnimation(android.view.animation.Animation)">startAnimation(android.view.animation.Animation)
	/// 	</see>
	/// . The animation can alter the scale,
	/// rotation, translation and alpha of a view over time. If the animation is
	/// attached to a view that has children, the animation will affect the entire
	/// subtree rooted by that node. When an animation is started, the framework will
	/// take care of redrawing the appropriate views until the animation completes.
	/// </p>
	/// <p>
	/// Starting with Android 3.0, the preferred way of animating views is to use the
	/// <see cref="android.animation">android.animation</see>
	/// package APIs.
	/// </p>
	/// <a name="Security"></a>
	/// <h3>Security</h3>
	/// <p>
	/// Sometimes it is essential that an application be able to verify that an action
	/// is being performed with the full knowledge and consent of the user, such as
	/// granting a permission request, making a purchase or clicking on an advertisement.
	/// Unfortunately, a malicious application could try to spoof the user into
	/// performing these actions, unaware, by concealing the intended purpose of the view.
	/// As a remedy, the framework offers a touch filtering mechanism that can be used to
	/// improve the security of views that provide access to sensitive functionality.
	/// </p><p>
	/// To enable touch filtering, call
	/// <see cref="setFilterTouchesWhenObscured(bool)">setFilterTouchesWhenObscured(bool)
	/// 	</see>
	/// or set the
	/// android:filterTouchesWhenObscured layout attribute to true.  When enabled, the framework
	/// will discard touches that are received whenever the view's window is obscured by
	/// another visible window.  As a result, the view will not receive touches whenever a
	/// toast, dialog or other window appears above the view's window.
	/// </p><p>
	/// For more fine-grained control over security, consider overriding the
	/// <see cref="onFilterTouchEventForSecurity(MotionEvent)">onFilterTouchEventForSecurity(MotionEvent)
	/// 	</see>
	/// method to implement your own
	/// security policy. See also
	/// <see cref="MotionEvent.FLAG_WINDOW_IS_OBSCURED">MotionEvent.FLAG_WINDOW_IS_OBSCURED
	/// 	</see>
	/// .
	/// </p>
	/// </remarks>
	/// <attr>ref android.R.styleable#View_alpha</attr>
	/// <attr>ref android.R.styleable#View_background</attr>
	/// <attr>ref android.R.styleable#View_clickable</attr>
	/// <attr>ref android.R.styleable#View_contentDescription</attr>
	/// <attr>ref android.R.styleable#View_drawingCacheQuality</attr>
	/// <attr>ref android.R.styleable#View_duplicateParentState</attr>
	/// <attr>ref android.R.styleable#View_id</attr>
	/// <attr>ref android.R.styleable#View_requiresFadingEdge</attr>
	/// <attr>ref android.R.styleable#View_fadingEdgeLength</attr>
	/// <attr>ref android.R.styleable#View_filterTouchesWhenObscured</attr>
	/// <attr>ref android.R.styleable#View_fitsSystemWindows</attr>
	/// <attr>ref android.R.styleable#View_isScrollContainer</attr>
	/// <attr>ref android.R.styleable#View_focusable</attr>
	/// <attr>ref android.R.styleable#View_focusableInTouchMode</attr>
	/// <attr>ref android.R.styleable#View_hapticFeedbackEnabled</attr>
	/// <attr>ref android.R.styleable#View_keepScreenOn</attr>
	/// <attr>ref android.R.styleable#View_layerType</attr>
	/// <attr>ref android.R.styleable#View_longClickable</attr>
	/// <attr>ref android.R.styleable#View_minHeight</attr>
	/// <attr>ref android.R.styleable#View_minWidth</attr>
	/// <attr>ref android.R.styleable#View_nextFocusDown</attr>
	/// <attr>ref android.R.styleable#View_nextFocusLeft</attr>
	/// <attr>ref android.R.styleable#View_nextFocusRight</attr>
	/// <attr>ref android.R.styleable#View_nextFocusUp</attr>
	/// <attr>ref android.R.styleable#View_onClick</attr>
	/// <attr>ref android.R.styleable#View_padding</attr>
	/// <attr>ref android.R.styleable#View_paddingBottom</attr>
	/// <attr>ref android.R.styleable#View_paddingLeft</attr>
	/// <attr>ref android.R.styleable#View_paddingRight</attr>
	/// <attr>ref android.R.styleable#View_paddingTop</attr>
	/// <attr>ref android.R.styleable#View_saveEnabled</attr>
	/// <attr>ref android.R.styleable#View_rotation</attr>
	/// <attr>ref android.R.styleable#View_rotationX</attr>
	/// <attr>ref android.R.styleable#View_rotationY</attr>
	/// <attr>ref android.R.styleable#View_scaleX</attr>
	/// <attr>ref android.R.styleable#View_scaleY</attr>
	/// <attr>ref android.R.styleable#View_scrollX</attr>
	/// <attr>ref android.R.styleable#View_scrollY</attr>
	/// <attr>ref android.R.styleable#View_scrollbarSize</attr>
	/// <attr>ref android.R.styleable#View_scrollbarStyle</attr>
	/// <attr>ref android.R.styleable#View_scrollbars</attr>
	/// <attr>ref android.R.styleable#View_scrollbarDefaultDelayBeforeFade</attr>
	/// <attr>ref android.R.styleable#View_scrollbarFadeDuration</attr>
	/// <attr>ref android.R.styleable#View_scrollbarTrackHorizontal</attr>
	/// <attr>ref android.R.styleable#View_scrollbarThumbHorizontal</attr>
	/// <attr>ref android.R.styleable#View_scrollbarThumbVertical</attr>
	/// <attr>ref android.R.styleable#View_scrollbarTrackVertical</attr>
	/// <attr>ref android.R.styleable#View_scrollbarAlwaysDrawHorizontalTrack</attr>
	/// <attr>ref android.R.styleable#View_scrollbarAlwaysDrawVerticalTrack</attr>
	/// <attr>ref android.R.styleable#View_soundEffectsEnabled</attr>
	/// <attr>ref android.R.styleable#View_tag</attr>
	/// <attr>ref android.R.styleable#View_transformPivotX</attr>
	/// <attr>ref android.R.styleable#View_transformPivotY</attr>
	/// <attr>ref android.R.styleable#View_translationX</attr>
	/// <attr>ref android.R.styleable#View_translationY</attr>
	/// <attr>ref android.R.styleable#View_visibility</attr>
	/// <seealso cref="ViewGroup">ViewGroup</seealso>
	[Sharpen.Sharpened]
	public partial class View : android.graphics.drawable.Drawable.Callback, android.graphics.drawable.Drawable
		.Callback2, android.view.KeyEvent.Callback, android.view.accessibility.AccessibilityEventSource
	{
		internal const bool DBG = false;

		/// <summary>The logging tag used by this class with android.util.Log.</summary>
		/// <remarks>The logging tag used by this class with android.util.Log.</remarks>
		internal const string VIEW_LOG_TAG = "View";

		/// <summary>Used to mark a View that has no ID.</summary>
		/// <remarks>Used to mark a View that has no ID.</remarks>
		public const int NO_ID = -1;

		/// <summary>This view does not want keystrokes.</summary>
		/// <remarks>
		/// This view does not want keystrokes. Use with TAKES_FOCUS_MASK when
		/// calling setFlags.
		/// </remarks>
		internal const int NOT_FOCUSABLE = unchecked((int)(0x00000000));

		/// <summary>This view wants keystrokes.</summary>
		/// <remarks>
		/// This view wants keystrokes. Use with TAKES_FOCUS_MASK when calling
		/// setFlags.
		/// </remarks>
		internal const int FOCUSABLE = unchecked((int)(0x00000001));

		/// <summary>Mask for use with setFlags indicating bits used for focus.</summary>
		/// <remarks>Mask for use with setFlags indicating bits used for focus.</remarks>
		internal const int FOCUSABLE_MASK = unchecked((int)(0x00000001));

		/// <summary>This view will adjust its padding to fit sytem windows (e.g.</summary>
		/// <remarks>This view will adjust its padding to fit sytem windows (e.g. status bar)
		/// 	</remarks>
		internal const int FITS_SYSTEM_WINDOWS = unchecked((int)(0x00000002));

		/// <summary>This view is visible.</summary>
		/// <remarks>
		/// This view is visible.
		/// Use with
		/// <see cref="setVisibility(int)">setVisibility(int)</see>
		/// and <a href="#attr_android:visibility">
		/// <code>android:visibility</code>
		/// .
		/// </remarks>
		public const int VISIBLE = unchecked((int)(0x00000000));

		/// <summary>This view is invisible, but it still takes up space for layout purposes.
		/// 	</summary>
		/// <remarks>
		/// This view is invisible, but it still takes up space for layout purposes.
		/// Use with
		/// <see cref="setVisibility(int)">setVisibility(int)</see>
		/// and <a href="#attr_android:visibility">
		/// <code>android:visibility</code>
		/// .
		/// </remarks>
		public const int INVISIBLE = unchecked((int)(0x00000004));

		/// <summary>
		/// This view is invisible, and it doesn't take any space for layout
		/// purposes.
		/// </summary>
		/// <remarks>
		/// This view is invisible, and it doesn't take any space for layout
		/// purposes. Use with
		/// <see cref="setVisibility(int)">setVisibility(int)</see>
		/// and <a href="#attr_android:visibility">
		/// <code>android:visibility</code>
		/// .
		/// </remarks>
		public const int GONE = unchecked((int)(0x00000008));

		/// <summary>Mask for use with setFlags indicating bits used for visibility.</summary>
		/// <remarks>
		/// Mask for use with setFlags indicating bits used for visibility.
		/// <hide></hide>
		/// </remarks>
		internal const int VISIBILITY_MASK = unchecked((int)(0x0000000C));

		private static readonly int[] VISIBILITY_FLAGS = new int[] { VISIBLE, INVISIBLE, 
			GONE };

		/// <summary>This view is enabled.</summary>
		/// <remarks>
		/// This view is enabled. Intrepretation varies by subclass.
		/// Use with ENABLED_MASK when calling setFlags.
		/// <hide></hide>
		/// </remarks>
		internal const int ENABLED = unchecked((int)(0x00000000));

		/// <summary>This view is disabled.</summary>
		/// <remarks>
		/// This view is disabled. Intrepretation varies by subclass.
		/// Use with ENABLED_MASK when calling setFlags.
		/// <hide></hide>
		/// </remarks>
		internal const int DISABLED = unchecked((int)(0x00000020));

		/// <summary>
		/// Mask for use with setFlags indicating bits used for indicating whether
		/// this view is enabled
		/// <hide></hide>
		/// </summary>
		internal const int ENABLED_MASK = unchecked((int)(0x00000020));

		/// <summary>This view won't draw.</summary>
		/// <remarks>
		/// This view won't draw.
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// won't be
		/// called and further optimizations will be performed. It is okay to have
		/// this flag set and a background. Use with DRAW_MASK when calling setFlags.
		/// <hide></hide>
		/// </remarks>
		internal const int WILL_NOT_DRAW = unchecked((int)(0x00000080));

		/// <summary>
		/// Mask for use with setFlags indicating bits used for indicating whether
		/// this view is will draw
		/// <hide></hide>
		/// </summary>
		internal const int DRAW_MASK = unchecked((int)(0x00000080));

		/// <summary>
		/// <p>This view doesn't show scrollbars.</p>
		/// <hide></hide>
		/// </summary>
		internal const int SCROLLBARS_NONE = unchecked((int)(0x00000000));

		/// <summary>
		/// <p>This view shows horizontal scrollbars.</p>
		/// <hide></hide>
		/// </summary>
		internal const int SCROLLBARS_HORIZONTAL = unchecked((int)(0x00000100));

		/// <summary>
		/// <p>This view shows vertical scrollbars.</p>
		/// <hide></hide>
		/// </summary>
		internal const int SCROLLBARS_VERTICAL = unchecked((int)(0x00000200));

		/// <summary>
		/// <p>Mask for use with setFlags indicating bits used for indicating which
		/// scrollbars are enabled.</p>
		/// <hide></hide>
		/// </summary>
		internal const int SCROLLBARS_MASK = unchecked((int)(0x00000300));

		/// <summary>Indicates that the view should filter touches when its window is obscured.
		/// 	</summary>
		/// <remarks>
		/// Indicates that the view should filter touches when its window is obscured.
		/// Refer to the class comments for more information about this security feature.
		/// <hide></hide>
		/// </remarks>
		internal const int FILTER_TOUCHES_WHEN_OBSCURED = unchecked((int)(0x00000400));

		/// <summary>
		/// <p>This view doesn't show fading edges.</p>
		/// <hide></hide>
		/// </summary>
		internal const int FADING_EDGE_NONE = unchecked((int)(0x00000000));

		/// <summary>
		/// <p>This view shows horizontal fading edges.</p>
		/// <hide></hide>
		/// </summary>
		internal const int FADING_EDGE_HORIZONTAL = unchecked((int)(0x00001000));

		/// <summary>
		/// <p>This view shows vertical fading edges.</p>
		/// <hide></hide>
		/// </summary>
		internal const int FADING_EDGE_VERTICAL = unchecked((int)(0x00002000));

		/// <summary>
		/// <p>Mask for use with setFlags indicating bits used for indicating which
		/// fading edges are enabled.</p>
		/// <hide></hide>
		/// </summary>
		internal const int FADING_EDGE_MASK = unchecked((int)(0x00003000));

		/// <summary><p>Indicates this view can be clicked.</summary>
		/// <remarks>
		/// <p>Indicates this view can be clicked. When clickable, a View reacts
		/// to clicks by notifying the OnClickListener.<p>
		/// <hide></hide>
		/// </remarks>
		internal const int CLICKABLE = unchecked((int)(0x00004000));

		/// <summary>
		/// <p>Indicates this view is caching its drawing into a bitmap.</p>
		/// <hide></hide>
		/// </summary>
		internal const int DRAWING_CACHE_ENABLED = unchecked((int)(0x00008000));

		/// <summary>
		/// <p>Indicates that no icicle should be saved for this view.<p>
		/// <hide></hide>
		/// </summary>
		internal const int SAVE_DISABLED = unchecked((int)(0x000010000));

		/// <summary>
		/// <p>Mask for use with setFlags indicating bits used for the saveEnabled
		/// property.</p>
		/// <hide></hide>
		/// </summary>
		internal const int SAVE_DISABLED_MASK = unchecked((int)(0x000010000));

		/// <summary>
		/// <p>Indicates that no drawing cache should ever be created for this view.<p>
		/// <hide></hide>
		/// </summary>
		internal const int WILL_NOT_CACHE_DRAWING = unchecked((int)(0x000020000));

		/// <summary>
		/// <p>Indicates this view can take / keep focus when int touch mode.</p>
		/// <hide></hide>
		/// </summary>
		internal const int FOCUSABLE_IN_TOUCH_MODE = unchecked((int)(0x00040000));

		/// <summary><p>Enables low quality mode for the drawing cache.</p></summary>
		public const int DRAWING_CACHE_QUALITY_LOW = unchecked((int)(0x00080000));

		/// <summary><p>Enables high quality mode for the drawing cache.</p></summary>
		public const int DRAWING_CACHE_QUALITY_HIGH = unchecked((int)(0x00100000));

		/// <summary><p>Enables automatic quality mode for the drawing cache.</p></summary>
		public const int DRAWING_CACHE_QUALITY_AUTO = unchecked((int)(0x00000000));

		private static readonly int[] DRAWING_CACHE_QUALITY_FLAGS = new int[] { DRAWING_CACHE_QUALITY_AUTO
			, DRAWING_CACHE_QUALITY_LOW, DRAWING_CACHE_QUALITY_HIGH };

		/// <summary>
		/// <p>Mask for use with setFlags indicating bits used for the cache
		/// quality property.</p>
		/// <hide></hide>
		/// </summary>
		internal const int DRAWING_CACHE_QUALITY_MASK = unchecked((int)(0x00180000));

		/// <summary>
		/// <p>
		/// Indicates this view can be long clicked.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Indicates this view can be long clicked. When long clickable, a View
		/// reacts to long clicks by notifying the OnLongClickListener or showing a
		/// context menu.
		/// </p>
		/// <hide></hide>
		/// </remarks>
		internal const int LONG_CLICKABLE = unchecked((int)(0x00200000));

		/// <summary>
		/// <p>Indicates that this view gets its drawable states from its direct parent
		/// and ignores its original internal states.</p>
		/// </summary>
		/// <hide></hide>
		internal const int DUPLICATE_PARENT_STATE = unchecked((int)(0x00400000));

		/// <summary>
		/// The scrollbar style to display the scrollbars inside the content area,
		/// without increasing the padding.
		/// </summary>
		/// <remarks>
		/// The scrollbar style to display the scrollbars inside the content area,
		/// without increasing the padding. The scrollbars will be overlaid with
		/// translucency on the view's content.
		/// </remarks>
		public const int SCROLLBARS_INSIDE_OVERLAY = 0;

		/// <summary>
		/// The scrollbar style to display the scrollbars inside the padded area,
		/// increasing the padding of the view.
		/// </summary>
		/// <remarks>
		/// The scrollbar style to display the scrollbars inside the padded area,
		/// increasing the padding of the view. The scrollbars will not overlap the
		/// content area of the view.
		/// </remarks>
		public const int SCROLLBARS_INSIDE_INSET = unchecked((int)(0x01000000));

		/// <summary>
		/// The scrollbar style to display the scrollbars at the edge of the view,
		/// without increasing the padding.
		/// </summary>
		/// <remarks>
		/// The scrollbar style to display the scrollbars at the edge of the view,
		/// without increasing the padding. The scrollbars will be overlaid with
		/// translucency.
		/// </remarks>
		public const int SCROLLBARS_OUTSIDE_OVERLAY = unchecked((int)(0x02000000));

		/// <summary>
		/// The scrollbar style to display the scrollbars at the edge of the view,
		/// increasing the padding of the view.
		/// </summary>
		/// <remarks>
		/// The scrollbar style to display the scrollbars at the edge of the view,
		/// increasing the padding of the view. The scrollbars will only overlap the
		/// background, if any.
		/// </remarks>
		public const int SCROLLBARS_OUTSIDE_INSET = unchecked((int)(0x03000000));

		/// <summary>Mask to check if the scrollbar style is overlay or inset.</summary>
		/// <remarks>
		/// Mask to check if the scrollbar style is overlay or inset.
		/// <hide></hide>
		/// </remarks>
		internal const int SCROLLBARS_INSET_MASK = unchecked((int)(0x01000000));

		/// <summary>Mask to check if the scrollbar style is inside or outside.</summary>
		/// <remarks>
		/// Mask to check if the scrollbar style is inside or outside.
		/// <hide></hide>
		/// </remarks>
		internal const int SCROLLBARS_OUTSIDE_MASK = unchecked((int)(0x02000000));

		/// <summary>Mask for scrollbar style.</summary>
		/// <remarks>
		/// Mask for scrollbar style.
		/// <hide></hide>
		/// </remarks>
		internal const int SCROLLBARS_STYLE_MASK = unchecked((int)(0x03000000));

		/// <summary>
		/// View flag indicating that the screen should remain on while the
		/// window containing this view is visible to the user.
		/// </summary>
		/// <remarks>
		/// View flag indicating that the screen should remain on while the
		/// window containing this view is visible to the user.  This effectively
		/// takes care of automatically setting the WindowManager's
		/// <see cref="LayoutParams.FLAG_KEEP_SCREEN_ON">LayoutParams.FLAG_KEEP_SCREEN_ON</see>
		/// .
		/// </remarks>
		public const int KEEP_SCREEN_ON = unchecked((int)(0x04000000));

		/// <summary>
		/// View flag indicating whether this view should have sound effects enabled
		/// for events such as clicking and touching.
		/// </summary>
		/// <remarks>
		/// View flag indicating whether this view should have sound effects enabled
		/// for events such as clicking and touching.
		/// </remarks>
		public const int SOUND_EFFECTS_ENABLED = unchecked((int)(0x08000000));

		/// <summary>
		/// View flag indicating whether this view should have haptic feedback
		/// enabled for events such as long presses.
		/// </summary>
		/// <remarks>
		/// View flag indicating whether this view should have haptic feedback
		/// enabled for events such as long presses.
		/// </remarks>
		public const int HAPTIC_FEEDBACK_ENABLED = unchecked((int)(0x10000000));

		/// <summary>
		/// <p>Indicates that the view hierarchy should stop saving state when
		/// it reaches this view.
		/// </summary>
		/// <remarks>
		/// <p>Indicates that the view hierarchy should stop saving state when
		/// it reaches this view.  If state saving is initiated immediately at
		/// the view, it will be allowed.
		/// <hide></hide>
		/// </remarks>
		internal const int PARENT_SAVE_DISABLED = unchecked((int)(0x20000000));

		/// <summary>
		/// <p>Mask for use with setFlags indicating bits used for PARENT_SAVE_DISABLED.</p>
		/// <hide></hide>
		/// </summary>
		internal const int PARENT_SAVE_DISABLED_MASK = unchecked((int)(0x20000000));

		/// <summary>Horizontal direction of this view is from Left to Right.</summary>
		/// <remarks>
		/// Horizontal direction of this view is from Left to Right.
		/// Use with
		/// <see cref="setLayoutDirection(int)">setLayoutDirection(int)</see>
		/// .
		/// <hide></hide>
		/// </remarks>
		public const int LAYOUT_DIRECTION_LTR = unchecked((int)(0x00000000));

		/// <summary>Horizontal direction of this view is from Right to Left.</summary>
		/// <remarks>
		/// Horizontal direction of this view is from Right to Left.
		/// Use with
		/// <see cref="setLayoutDirection(int)">setLayoutDirection(int)</see>
		/// .
		/// <hide></hide>
		/// </remarks>
		public const int LAYOUT_DIRECTION_RTL = unchecked((int)(0x40000000));

		/// <summary>Horizontal direction of this view is inherited from its parent.</summary>
		/// <remarks>
		/// Horizontal direction of this view is inherited from its parent.
		/// Use with
		/// <see cref="setLayoutDirection(int)">setLayoutDirection(int)</see>
		/// .
		/// <hide></hide>
		/// </remarks>
		public const int LAYOUT_DIRECTION_INHERIT = unchecked((int)(0x80000000));

		/// <summary>
		/// Horizontal direction of this view is from deduced from the default language
		/// script for the locale.
		/// </summary>
		/// <remarks>
		/// Horizontal direction of this view is from deduced from the default language
		/// script for the locale. Use with
		/// <see cref="setLayoutDirection(int)">setLayoutDirection(int)</see>
		/// .
		/// <hide></hide>
		/// </remarks>
		public const int LAYOUT_DIRECTION_LOCALE = unchecked((int)(0xC0000000));

		/// <summary>Mask for use with setFlags indicating bits used for horizontalDirection.
		/// 	</summary>
		/// <remarks>
		/// Mask for use with setFlags indicating bits used for horizontalDirection.
		/// <hide></hide>
		/// </remarks>
		internal const int LAYOUT_DIRECTION_MASK = unchecked((int)(0xC0000000));

		private static readonly int[] LAYOUT_DIRECTION_FLAGS = new int[] { LAYOUT_DIRECTION_LTR
			, LAYOUT_DIRECTION_RTL, LAYOUT_DIRECTION_INHERIT, LAYOUT_DIRECTION_LOCALE };

		/// <summary>Default horizontalDirection.</summary>
		/// <remarks>
		/// Default horizontalDirection.
		/// <hide></hide>
		/// </remarks>
		internal const int LAYOUT_DIRECTION_DEFAULT = LAYOUT_DIRECTION_INHERIT;

		/// <summary>
		/// View flag indicating whether
		/// <see cref="addFocusables(java.util.ArrayList{E}, int, int)">addFocusables(java.util.ArrayList&lt;E&gt;, int, int)
		/// 	</see>
		/// should add all focusable Views regardless if they are focusable in touch mode.
		/// </summary>
		public const int FOCUSABLES_ALL = unchecked((int)(0x00000000));

		/// <summary>
		/// View flag indicating whether
		/// <see cref="addFocusables(java.util.ArrayList{E}, int, int)">addFocusables(java.util.ArrayList&lt;E&gt;, int, int)
		/// 	</see>
		/// should add only Views focusable in touch mode.
		/// </summary>
		public const int FOCUSABLES_TOUCH_MODE = unchecked((int)(0x00000001));

		/// <summary>
		/// Use with
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// . Move focus to the previous selectable
		/// item.
		/// </summary>
		public const int FOCUS_BACKWARD = unchecked((int)(0x00000001));

		/// <summary>
		/// Use with
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// . Move focus to the next selectable
		/// item.
		/// </summary>
		public const int FOCUS_FORWARD = unchecked((int)(0x00000002));

		/// <summary>
		/// Use with
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// . Move focus to the left.
		/// </summary>
		public const int FOCUS_LEFT = unchecked((int)(0x00000011));

		/// <summary>
		/// Use with
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// . Move focus up.
		/// </summary>
		public const int FOCUS_UP = unchecked((int)(0x00000021));

		/// <summary>
		/// Use with
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// . Move focus to the right.
		/// </summary>
		public const int FOCUS_RIGHT = unchecked((int)(0x00000042));

		/// <summary>
		/// Use with
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// . Move focus down.
		/// </summary>
		public const int FOCUS_DOWN = unchecked((int)(0x00000082));

		/// <summary>
		/// Bits of
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// and
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// that provide the actual measured size.
		/// </summary>
		public const int MEASURED_SIZE_MASK = unchecked((int)(0x00ffffff));

		/// <summary>
		/// Bits of
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// and
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// that provide the additional state bits.
		/// </summary>
		public const int MEASURED_STATE_MASK = unchecked((int)(0xff000000));

		/// <summary>
		/// Bit shift of
		/// <see cref="MEASURED_STATE_MASK">MEASURED_STATE_MASK</see>
		/// to get to the height bits
		/// for functions that combine both width and height into a single int,
		/// such as
		/// <see cref="getMeasuredState()">getMeasuredState()</see>
		/// and the childState argument of
		/// <see cref="resolveSizeAndState(int, int, int)">resolveSizeAndState(int, int, int)
		/// 	</see>
		/// .
		/// </summary>
		public const int MEASURED_HEIGHT_STATE_SHIFT = 16;

		/// <summary>
		/// Bit of
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// and
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// that indicates the measured size
		/// is smaller that the space the view would like to have.
		/// </summary>
		public const int MEASURED_STATE_TOO_SMALL = unchecked((int)(0x01000000));

		/// <summary>Indicates the view has no states set.</summary>
		/// <remarks>
		/// Indicates the view has no states set. States are used with
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// to change the drawing of the
		/// view depending on its state.
		/// </remarks>
		/// <seealso cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</seealso>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		protected internal static readonly int[] EMPTY_STATE_SET;

		/// <summary>Indicates the view is enabled.</summary>
		/// <remarks>
		/// Indicates the view is enabled. States are used with
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// to change the drawing of the
		/// view depending on its state.
		/// </remarks>
		/// <seealso cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</seealso>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		protected internal static readonly int[] ENABLED_STATE_SET;

		/// <summary>Indicates the view is focused.</summary>
		/// <remarks>
		/// Indicates the view is focused. States are used with
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// to change the drawing of the
		/// view depending on its state.
		/// </remarks>
		/// <seealso cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</seealso>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		protected internal static readonly int[] FOCUSED_STATE_SET;

		/// <summary>Indicates the view is selected.</summary>
		/// <remarks>
		/// Indicates the view is selected. States are used with
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// to change the drawing of the
		/// view depending on its state.
		/// </remarks>
		/// <seealso cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</seealso>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		protected internal static readonly int[] SELECTED_STATE_SET;

		/// <summary>Indicates the view is pressed.</summary>
		/// <remarks>
		/// Indicates the view is pressed. States are used with
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// to change the drawing of the
		/// view depending on its state.
		/// </remarks>
		/// <seealso cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</seealso>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		/// <hide></hide>
		protected internal static readonly int[] PRESSED_STATE_SET;

		/// <summary>Indicates the view's window has focus.</summary>
		/// <remarks>
		/// Indicates the view's window has focus. States are used with
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// to change the drawing of the
		/// view depending on its state.
		/// </remarks>
		/// <seealso cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</seealso>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		protected internal static readonly int[] WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is enabled and has the focus.</summary>
		/// <remarks>Indicates the view is enabled and has the focus.</remarks>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] ENABLED_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is enabled and selected.</summary>
		/// <remarks>Indicates the view is enabled and selected.</remarks>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		protected internal static readonly int[] ENABLED_SELECTED_STATE_SET;

		/// <summary>Indicates the view is enabled and that its window has focus.</summary>
		/// <remarks>Indicates the view is enabled and that its window has focus.</remarks>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] ENABLED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is focused and selected.</summary>
		/// <remarks>Indicates the view is focused and selected.</remarks>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		protected internal static readonly int[] FOCUSED_SELECTED_STATE_SET;

		/// <summary>Indicates the view has the focus and that its window has the focus.</summary>
		/// <remarks>Indicates the view has the focus and that its window has the focus.</remarks>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] FOCUSED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is selected and that its window has the focus.</summary>
		/// <remarks>Indicates the view is selected and that its window has the focus.</remarks>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is enabled, focused and selected.</summary>
		/// <remarks>Indicates the view is enabled, focused and selected.</remarks>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		protected internal static readonly int[] ENABLED_FOCUSED_SELECTED_STATE_SET;

		/// <summary>Indicates the view is enabled, focused and its window has the focus.</summary>
		/// <remarks>Indicates the view is enabled, focused and its window has the focus.</remarks>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] ENABLED_FOCUSED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is enabled, selected and its window has the focus.</summary>
		/// <remarks>Indicates the view is enabled, selected and its window has the focus.</remarks>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] ENABLED_SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is focused, selected and its window has the focus.</summary>
		/// <remarks>Indicates the view is focused, selected and its window has the focus.</remarks>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>
		/// Indicates the view is enabled, focused, selected and its window
		/// has the focus.
		/// </summary>
		/// <remarks>
		/// Indicates the view is enabled, focused, selected and its window
		/// has the focus.
		/// </remarks>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] ENABLED_FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed and its window has the focus.</summary>
		/// <remarks>Indicates the view is pressed and its window has the focus.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed and selected.</summary>
		/// <remarks>Indicates the view is pressed and selected.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_SELECTED_STATE_SET;

		/// <summary>Indicates the view is pressed, selected and its window has the focus.</summary>
		/// <remarks>Indicates the view is pressed, selected and its window has the focus.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed and focused.</summary>
		/// <remarks>Indicates the view is pressed and focused.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed, focused and its window has the focus.</summary>
		/// <remarks>Indicates the view is pressed, focused and its window has the focus.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_FOCUSED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed, focused and selected.</summary>
		/// <remarks>Indicates the view is pressed, focused and selected.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_FOCUSED_SELECTED_STATE_SET;

		/// <summary>Indicates the view is pressed, focused, selected and its window has the focus.
		/// 	</summary>
		/// <remarks>Indicates the view is pressed, focused, selected and its window has the focus.
		/// 	</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed and enabled.</summary>
		/// <remarks>Indicates the view is pressed and enabled.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_STATE_SET;

		/// <summary>Indicates the view is pressed, enabled and its window has the focus.</summary>
		/// <remarks>Indicates the view is pressed, enabled and its window has the focus.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed, enabled and selected.</summary>
		/// <remarks>Indicates the view is pressed, enabled and selected.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_SELECTED_STATE_SET;

		/// <summary>
		/// Indicates the view is pressed, enabled, selected and its window has the
		/// focus.
		/// </summary>
		/// <remarks>
		/// Indicates the view is pressed, enabled, selected and its window has the
		/// focus.
		/// </remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed, enabled and focused.</summary>
		/// <remarks>Indicates the view is pressed, enabled and focused.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_FOCUSED_STATE_SET;

		/// <summary>
		/// Indicates the view is pressed, enabled, focused and its window has the
		/// focus.
		/// </summary>
		/// <remarks>
		/// Indicates the view is pressed, enabled, focused and its window has the
		/// focus.
		/// </remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_FOCUSED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>Indicates the view is pressed, enabled, focused and selected.</summary>
		/// <remarks>Indicates the view is pressed, enabled, focused and selected.</remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_FOCUSED_SELECTED_STATE_SET;

		/// <summary>
		/// Indicates the view is pressed, enabled, focused, selected and its window
		/// has the focus.
		/// </summary>
		/// <remarks>
		/// Indicates the view is pressed, enabled, focused, selected and its window
		/// has the focus.
		/// </remarks>
		/// <seealso cref="PRESSED_STATE_SET">PRESSED_STATE_SET</seealso>
		/// <seealso cref="ENABLED_STATE_SET">ENABLED_STATE_SET</seealso>
		/// <seealso cref="SELECTED_STATE_SET">SELECTED_STATE_SET</seealso>
		/// <seealso cref="FOCUSED_STATE_SET">FOCUSED_STATE_SET</seealso>
		/// <seealso cref="WINDOW_FOCUSED_STATE_SET">WINDOW_FOCUSED_STATE_SET</seealso>
		protected internal static readonly int[] PRESSED_ENABLED_FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET;

		/// <summary>
		/// The order here is very important to
		/// <see cref="getDrawableState()">getDrawableState()</see>
		/// </summary>
		private static readonly int[][] VIEW_STATE_SETS;

		internal const int VIEW_STATE_WINDOW_FOCUSED = 1;

		internal const int VIEW_STATE_SELECTED = 1 << 1;

		internal const int VIEW_STATE_FOCUSED = 1 << 2;

		internal const int VIEW_STATE_ENABLED = 1 << 3;

		internal const int VIEW_STATE_PRESSED = 1 << 4;

		internal const int VIEW_STATE_ACTIVATED = 1 << 5;

		internal const int VIEW_STATE_ACCELERATED = 1 << 6;

		internal const int VIEW_STATE_HOVERED = 1 << 7;

		internal const int VIEW_STATE_DRAG_CAN_ACCEPT = 1 << 8;

		internal const int VIEW_STATE_DRAG_HOVERED = 1 << 9;

		internal static readonly int[] VIEW_STATE_IDS = new int[] { android.@internal.R.attr
			.state_window_focused, VIEW_STATE_WINDOW_FOCUSED, android.@internal.R.attr.state_selected
			, VIEW_STATE_SELECTED, android.@internal.R.attr.state_focused, VIEW_STATE_FOCUSED
			, android.@internal.R.attr.state_enabled, VIEW_STATE_ENABLED, android.@internal.R
			.attr.state_pressed, VIEW_STATE_PRESSED, android.@internal.R.attr.state_activated
			, VIEW_STATE_ACTIVATED, android.@internal.R.attr.state_accelerated, VIEW_STATE_ACCELERATED
			, android.@internal.R.attr.state_hovered, VIEW_STATE_HOVERED, android.@internal.R
			.attr.state_drag_can_accept, VIEW_STATE_DRAG_CAN_ACCEPT, android.@internal.R.attr
			.state_drag_hovered, VIEW_STATE_DRAG_HOVERED };

		static View()
		{
			// note flag value 0x00000800 is now available for next flags...
			// Singles
			// Doubles
			// Triples
			if ((VIEW_STATE_IDS.Length / 2) != android.@internal.R.styleable.ViewDrawableStates
				.Length)
			{
				throw new System.InvalidOperationException("VIEW_STATE_IDs array length does not match ViewDrawableStates style array"
					);
			}
			int[] orderedIds = new int[VIEW_STATE_IDS.Length];
			{
				for (int i = 0; i < android.@internal.R.styleable.ViewDrawableStates.Length; i++)
				{
					int viewState = android.@internal.R.styleable.ViewDrawableStates[i];
					{
						for (int j = 0; j < VIEW_STATE_IDS.Length; j += 2)
						{
							if (VIEW_STATE_IDS[j] == viewState)
							{
								orderedIds[i * 2] = viewState;
								orderedIds[i * 2 + 1] = VIEW_STATE_IDS[j + 1];
							}
						}
					}
				}
			}
			int NUM_BITS = VIEW_STATE_IDS.Length / 2;
			VIEW_STATE_SETS = new int[1 << NUM_BITS][];
			{
				for (int i_1 = 0; i_1 < VIEW_STATE_SETS.Length; i_1++)
				{
					int numBits = Sharpen.Util.IntGetBitCount(i_1);
					int[] set = new int[numBits];
					int pos = 0;
					{
						for (int j = 0; j < orderedIds.Length; j += 2)
						{
							if ((i_1 & orderedIds[j + 1]) != 0)
							{
								set[pos++] = orderedIds[j];
							}
						}
					}
					VIEW_STATE_SETS[i_1] = set;
				}
			}
			EMPTY_STATE_SET = VIEW_STATE_SETS[0];
			WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED];
			SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED];
			SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED | VIEW_STATE_SELECTED
				];
			FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_FOCUSED];
			FOCUSED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED | VIEW_STATE_FOCUSED
				];
			FOCUSED_SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED | VIEW_STATE_FOCUSED
				];
			FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_SELECTED | VIEW_STATE_FOCUSED];
			ENABLED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_ENABLED];
			ENABLED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED | VIEW_STATE_ENABLED
				];
			ENABLED_SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED | VIEW_STATE_ENABLED
				];
			ENABLED_SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_SELECTED | VIEW_STATE_ENABLED];
			ENABLED_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_FOCUSED | VIEW_STATE_ENABLED
				];
			ENABLED_FOCUSED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_FOCUSED | VIEW_STATE_ENABLED];
			ENABLED_FOCUSED_SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED | VIEW_STATE_FOCUSED
				 | VIEW_STATE_ENABLED];
			ENABLED_FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_SELECTED | VIEW_STATE_FOCUSED | VIEW_STATE_ENABLED];
			PRESSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_PRESSED];
			PRESSED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED | VIEW_STATE_PRESSED
				];
			PRESSED_SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED | VIEW_STATE_PRESSED
				];
			PRESSED_SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_SELECTED | VIEW_STATE_PRESSED];
			PRESSED_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_FOCUSED | VIEW_STATE_PRESSED
				];
			PRESSED_FOCUSED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_FOCUSED | VIEW_STATE_PRESSED];
			PRESSED_FOCUSED_SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED | VIEW_STATE_FOCUSED
				 | VIEW_STATE_PRESSED];
			PRESSED_FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_SELECTED | VIEW_STATE_FOCUSED | VIEW_STATE_PRESSED];
			PRESSED_ENABLED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_ENABLED | VIEW_STATE_PRESSED
				];
			PRESSED_ENABLED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_ENABLED | VIEW_STATE_PRESSED];
			PRESSED_ENABLED_SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED | VIEW_STATE_ENABLED
				 | VIEW_STATE_PRESSED];
			PRESSED_ENABLED_SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_SELECTED | VIEW_STATE_ENABLED | VIEW_STATE_PRESSED];
			PRESSED_ENABLED_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_FOCUSED | VIEW_STATE_ENABLED
				 | VIEW_STATE_PRESSED];
			PRESSED_ENABLED_FOCUSED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_FOCUSED | VIEW_STATE_ENABLED | VIEW_STATE_PRESSED];
			PRESSED_ENABLED_FOCUSED_SELECTED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_SELECTED 
				| VIEW_STATE_FOCUSED | VIEW_STATE_ENABLED | VIEW_STATE_PRESSED];
			PRESSED_ENABLED_FOCUSED_SELECTED_WINDOW_FOCUSED_STATE_SET = VIEW_STATE_SETS[VIEW_STATE_WINDOW_FOCUSED
				 | VIEW_STATE_SELECTED | VIEW_STATE_FOCUSED | VIEW_STATE_ENABLED | VIEW_STATE_PRESSED
				];
		}

		/// <summary>Accessibility event types that are dispatched for text population.</summary>
		/// <remarks>Accessibility event types that are dispatched for text population.</remarks>
		internal const int POPULATING_ACCESSIBILITY_EVENT_TYPES = android.view.accessibility.AccessibilityEvent
			.TYPE_VIEW_CLICKED | android.view.accessibility.AccessibilityEvent.TYPE_VIEW_LONG_CLICKED
			 | android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SELECTED | android.view.accessibility.AccessibilityEvent
			.TYPE_VIEW_FOCUSED | android.view.accessibility.AccessibilityEvent.TYPE_WINDOW_STATE_CHANGED
			 | android.view.accessibility.AccessibilityEvent.TYPE_VIEW_HOVER_ENTER | android.view.accessibility.AccessibilityEvent
			.TYPE_VIEW_HOVER_EXIT | android.view.accessibility.AccessibilityEvent.TYPE_VIEW_TEXT_CHANGED;

		/// <summary>Temporary Rect currently for use in setBackground().</summary>
		/// <remarks>
		/// Temporary Rect currently for use in setBackground().  This will probably
		/// be extended in the future to hold our own class with more than just
		/// a Rect. :)
		/// </remarks>
		internal static readonly java.lang.ThreadLocal<android.graphics.Rect> sThreadLocal
			 = new java.lang.ThreadLocal<android.graphics.Rect>();

		/// <summary>Map used to store views' tags.</summary>
		/// <remarks>Map used to store views' tags.</remarks>
		private android.util.SparseArray<object> mKeyedTags;

		/// <summary>The next available accessiiblity id.</summary>
		/// <remarks>The next available accessiiblity id.</remarks>
		private static int sNextAccessibilityViewId;

		/// <summary>The animation currently associated with this view.</summary>
		/// <remarks>The animation currently associated with this view.</remarks>
		/// <hide></hide>
		protected internal android.view.animation.Animation mCurrentAnimation = null;

		/// <summary>Width as measured during measure pass.</summary>
		/// <remarks>
		/// Width as measured during measure pass.
		/// <hide></hide>
		/// </remarks>
		internal int mMeasuredWidth;

		/// <summary>Height as measured during measure pass.</summary>
		/// <remarks>
		/// Height as measured during measure pass.
		/// <hide></hide>
		/// </remarks>
		internal int mMeasuredHeight;

		/// <summary>
		/// Flag to indicate that this view was marked INVALIDATED, or had its display list
		/// invalidated, prior to the current drawing iteration.
		/// </summary>
		/// <remarks>
		/// Flag to indicate that this view was marked INVALIDATED, or had its display list
		/// invalidated, prior to the current drawing iteration. If true, the view must re-draw
		/// its display list. This flag, used only when hw accelerated, allows us to clear the
		/// flag while retaining this information until it's needed (at getDisplayList() time and
		/// in drawChild(), when we decide to draw a view's children's display lists into our own).
		/// <hide></hide>
		/// </remarks>
		internal bool mRecreateDisplayList = false;

		/// <summary>The view's identifier.</summary>
		/// <remarks>
		/// The view's identifier.
		/// <hide></hide>
		/// </remarks>
		/// <seealso cref="setId(int)">setId(int)</seealso>
		/// <seealso cref="getId()">getId()</seealso>
		internal int mID = NO_ID;

		/// <summary>The stable ID of this view for accessibility porposes.</summary>
		/// <remarks>The stable ID of this view for accessibility porposes.</remarks>
		internal int mAccessibilityViewId = NO_ID;

		/// <summary>The view's tag.</summary>
		/// <remarks>
		/// The view's tag.
		/// <hide></hide>
		/// </remarks>
		/// <seealso cref="setTag(object)">setTag(object)</seealso>
		/// <seealso cref="getTag()">getTag()</seealso>
		protected internal object mTag;

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int WANTS_FOCUS = unchecked((int)(0x00000001));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int FOCUSED = unchecked((int)(0x00000002));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int SELECTED = unchecked((int)(0x00000004));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int IS_ROOT_NAMESPACE = unchecked((int)(0x00000008));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int HAS_BOUNDS = unchecked((int)(0x00000010));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int DRAWN = unchecked((int)(0x00000020));

		/// <summary>
		/// When this flag is set, this view is running an animation on behalf of its
		/// children and should therefore not cancel invalidate requests, even if they
		/// lie outside of this view's bounds.
		/// </summary>
		/// <remarks>
		/// When this flag is set, this view is running an animation on behalf of its
		/// children and should therefore not cancel invalidate requests, even if they
		/// lie outside of this view's bounds.
		/// <hide></hide>
		/// </remarks>
		internal const int DRAW_ANIMATION = unchecked((int)(0x00000040));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int SKIP_DRAW = unchecked((int)(0x00000080));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int ONLY_DRAWS_BACKGROUND = unchecked((int)(0x00000100));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int REQUEST_TRANSPARENT_REGIONS = unchecked((int)(0x00000200));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int DRAWABLE_STATE_DIRTY = unchecked((int)(0x00000400));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int MEASURED_DIMENSION_SET = unchecked((int)(0x00000800));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int FORCE_LAYOUT = unchecked((int)(0x00001000));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int LAYOUT_REQUIRED = unchecked((int)(0x00002000));

		internal const int PRESSED = unchecked((int)(0x00004000));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int DRAWING_CACHE_VALID = unchecked((int)(0x00008000));

		/// <summary>
		/// Flag used to indicate that this view should be drawn once more (and only once
		/// more) after its animation has completed.
		/// </summary>
		/// <remarks>
		/// Flag used to indicate that this view should be drawn once more (and only once
		/// more) after its animation has completed.
		/// <hide></hide>
		/// </remarks>
		internal const int ANIMATION_STARTED = unchecked((int)(0x00010000));

		internal const int SAVE_STATE_CALLED = unchecked((int)(0x00020000));

		/// <summary>
		/// Indicates that the View returned true when onSetAlpha() was called and that
		/// the alpha must be restored.
		/// </summary>
		/// <remarks>
		/// Indicates that the View returned true when onSetAlpha() was called and that
		/// the alpha must be restored.
		/// <hide></hide>
		/// </remarks>
		internal const int ALPHA_SET = unchecked((int)(0x00040000));

		/// <summary>
		/// Set by
		/// <see cref="setScrollContainer(bool)">setScrollContainer(bool)</see>
		/// .
		/// </summary>
		internal const int SCROLL_CONTAINER = unchecked((int)(0x00080000));

		/// <summary>
		/// Set by
		/// <see cref="setScrollContainer(bool)">setScrollContainer(bool)</see>
		/// .
		/// </summary>
		internal const int SCROLL_CONTAINER_ADDED = unchecked((int)(0x00100000));

		/// <summary>View flag indicating whether this view was invalidated (fully or partially.)
		/// 	</summary>
		/// <hide></hide>
		internal const int DIRTY = unchecked((int)(0x00200000));

		/// <summary>
		/// View flag indicating whether this view was invalidated by an opaque
		/// invalidate request.
		/// </summary>
		/// <remarks>
		/// View flag indicating whether this view was invalidated by an opaque
		/// invalidate request.
		/// </remarks>
		/// <hide></hide>
		internal const int DIRTY_OPAQUE = unchecked((int)(0x00400000));

		/// <summary>
		/// Mask for
		/// <see cref="DIRTY">DIRTY</see>
		/// and
		/// <see cref="DIRTY_OPAQUE">DIRTY_OPAQUE</see>
		/// .
		/// </summary>
		/// <hide></hide>
		internal const int DIRTY_MASK = unchecked((int)(0x00600000));

		/// <summary>Indicates whether the background is opaque.</summary>
		/// <remarks>Indicates whether the background is opaque.</remarks>
		/// <hide></hide>
		internal const int OPAQUE_BACKGROUND = unchecked((int)(0x00800000));

		/// <summary>Indicates whether the scrollbars are opaque.</summary>
		/// <remarks>Indicates whether the scrollbars are opaque.</remarks>
		/// <hide></hide>
		internal const int OPAQUE_SCROLLBARS = unchecked((int)(0x01000000));

		/// <summary>Indicates whether the view is opaque.</summary>
		/// <remarks>Indicates whether the view is opaque.</remarks>
		/// <hide></hide>
		internal const int OPAQUE_MASK = unchecked((int)(0x01800000));

		/// <summary>
		/// Indicates a prepressed state;
		/// the short time between ACTION_DOWN and recognizing
		/// a 'real' press.
		/// </summary>
		/// <remarks>
		/// Indicates a prepressed state;
		/// the short time between ACTION_DOWN and recognizing
		/// a 'real' press. Prepressed is used to recognize quick taps
		/// even when they are shorter than ViewConfiguration.getTapTimeout().
		/// </remarks>
		/// <hide></hide>
		internal const int PREPRESSED = unchecked((int)(0x02000000));

		/// <summary>Indicates whether the view is temporarily detached.</summary>
		/// <remarks>Indicates whether the view is temporarily detached.</remarks>
		/// <hide></hide>
		internal const int CANCEL_NEXT_UP_EVENT = unchecked((int)(0x04000000));

		/// <summary>Indicates that we should awaken scroll bars once attached</summary>
		/// <hide></hide>
		internal const int AWAKEN_SCROLL_BARS_ON_ATTACH = unchecked((int)(0x08000000));

		/// <summary>Indicates that the view has received HOVER_ENTER.</summary>
		/// <remarks>Indicates that the view has received HOVER_ENTER.  Cleared on HOVER_EXIT.
		/// 	</remarks>
		/// <hide></hide>
		internal const int HOVERED = unchecked((int)(0x10000000));

		/// <summary>
		/// Indicates that pivotX or pivotY were explicitly set and we should not assume the center
		/// for transform operations
		/// </summary>
		/// <hide></hide>
		internal const int PIVOT_EXPLICITLY_SET = unchecked((int)(0x20000000));

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		internal const int ACTIVATED = unchecked((int)(0x40000000));

		/// <summary>
		/// Indicates that this view was specifically invalidated, not just dirtied because some
		/// child view was invalidated.
		/// </summary>
		/// <remarks>
		/// Indicates that this view was specifically invalidated, not just dirtied because some
		/// child view was invalidated. The flag is used to determine when we need to recreate
		/// a view's display list (as opposed to just returning a reference to its existing
		/// display list).
		/// </remarks>
		/// <hide></hide>
		internal const int INVALIDATED = unchecked((int)(0x80000000));

		/// <summary>Indicates that this view has reported that it can accept the current drag's content.
		/// 	</summary>
		/// <remarks>
		/// Indicates that this view has reported that it can accept the current drag's content.
		/// Cleared when the drag operation concludes.
		/// </remarks>
		/// <hide></hide>
		internal const int DRAG_CAN_ACCEPT = unchecked((int)(0x00000001));

		/// <summary>
		/// Indicates that this view is currently directly under the drag location in a
		/// drag-and-drop operation involving content that it can accept.
		/// </summary>
		/// <remarks>
		/// Indicates that this view is currently directly under the drag location in a
		/// drag-and-drop operation involving content that it can accept.  Cleared when
		/// the drag exits the view, or when the drag operation concludes.
		/// </remarks>
		/// <hide></hide>
		internal const int DRAG_HOVERED = unchecked((int)(0x00000002));

		/// <summary>
		/// Indicates whether the view layout direction has been resolved and drawn to the
		/// right-to-left direction.
		/// </summary>
		/// <remarks>
		/// Indicates whether the view layout direction has been resolved and drawn to the
		/// right-to-left direction.
		/// </remarks>
		/// <hide></hide>
		internal const int LAYOUT_DIRECTION_RESOLVED_RTL = unchecked((int)(0x00000004));

		/// <summary>Indicates whether the view layout direction has been resolved.</summary>
		/// <remarks>Indicates whether the view layout direction has been resolved.</remarks>
		/// <hide></hide>
		internal const int LAYOUT_DIRECTION_RESOLVED = unchecked((int)(0x00000008));

		internal const int DRAG_MASK = DRAG_CAN_ACCEPT | DRAG_HOVERED;

		/// <summary>
		/// Always allow a user to over-scroll this view, provided it is a
		/// view that can scroll.
		/// </summary>
		/// <remarks>
		/// Always allow a user to over-scroll this view, provided it is a
		/// view that can scroll.
		/// </remarks>
		/// <seealso cref="getOverScrollMode()">getOverScrollMode()</seealso>
		/// <seealso cref="setOverScrollMode(int)">setOverScrollMode(int)</seealso>
		public const int OVER_SCROLL_ALWAYS = 0;

		/// <summary>
		/// Allow a user to over-scroll this view only if the content is large
		/// enough to meaningfully scroll, provided it is a view that can scroll.
		/// </summary>
		/// <remarks>
		/// Allow a user to over-scroll this view only if the content is large
		/// enough to meaningfully scroll, provided it is a view that can scroll.
		/// </remarks>
		/// <seealso cref="getOverScrollMode()">getOverScrollMode()</seealso>
		/// <seealso cref="setOverScrollMode(int)">setOverScrollMode(int)</seealso>
		public const int OVER_SCROLL_IF_CONTENT_SCROLLS = 1;

		/// <summary>Never allow a user to over-scroll this view.</summary>
		/// <remarks>Never allow a user to over-scroll this view.</remarks>
		/// <seealso cref="getOverScrollMode()">getOverScrollMode()</seealso>
		/// <seealso cref="setOverScrollMode(int)">setOverScrollMode(int)</seealso>
		public const int OVER_SCROLL_NEVER = 2;

		/// <summary>View has requested the system UI (status bar) to be visible (the default).
		/// 	</summary>
		/// <remarks>View has requested the system UI (status bar) to be visible (the default).
		/// 	</remarks>
		/// <seealso cref="setSystemUiVisibility(int)">setSystemUiVisibility(int)</seealso>
		public const int SYSTEM_UI_FLAG_VISIBLE = 0;

		/// <summary>View has requested the system UI to enter an unobtrusive "low profile" mode.
		/// 	</summary>
		/// <remarks>
		/// View has requested the system UI to enter an unobtrusive "low profile" mode.
		/// This is for use in games, book readers, video players, or any other "immersive" application
		/// where the usual system chrome is deemed too distracting.
		/// In low profile mode, the status bar and/or navigation icons may dim.
		/// </remarks>
		/// <seealso cref="setSystemUiVisibility(int)">setSystemUiVisibility(int)</seealso>
		public const int SYSTEM_UI_FLAG_LOW_PROFILE = unchecked((int)(0x00000001));

		/// <summary>View has requested that the system navigation be temporarily hidden.</summary>
		/// <remarks>
		/// View has requested that the system navigation be temporarily hidden.
		/// This is an even less obtrusive state than that called for by
		/// <see cref="SYSTEM_UI_FLAG_LOW_PROFILE">SYSTEM_UI_FLAG_LOW_PROFILE</see>
		/// ; on devices that draw essential navigation controls
		/// (Home, Back, and the like) on screen, <code>SYSTEM_UI_FLAG_HIDE_NAVIGATION</code> will cause
		/// those to disappear. This is useful (in conjunction with the
		/// <see cref="LayoutParams.FLAG_FULLSCREEN">FLAG_FULLSCREEN</see>
		/// and
		/// <see cref="LayoutParams.FLAG_LAYOUT_IN_SCREEN">FLAG_LAYOUT_IN_SCREEN</see>
		/// window flags) for displaying content using every last pixel on the display.
		/// There is a limitation: because navigation controls are so important, the least user
		/// interaction will cause them to reappear immediately.
		/// </remarks>
		/// <seealso cref="setSystemUiVisibility(int)">setSystemUiVisibility(int)</seealso>
		public const int SYSTEM_UI_FLAG_HIDE_NAVIGATION = unchecked((int)(0x00000002));

		[System.ObsoleteAttribute(@"Use SYSTEM_UI_FLAG_LOW_PROFILE instead.")]
		public const int STATUS_BAR_HIDDEN = SYSTEM_UI_FLAG_LOW_PROFILE;

		[System.ObsoleteAttribute(@"Use SYSTEM_UI_FLAG_VISIBLE instead.")]
		public const int STATUS_BAR_VISIBLE = SYSTEM_UI_FLAG_VISIBLE;

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to make the status bar not expandable.  Unless you also
		/// set
		/// <see cref="STATUS_BAR_DISABLE_NOTIFICATION_ICONS">STATUS_BAR_DISABLE_NOTIFICATION_ICONS
		/// 	</see>
		/// , new notifications will continue to show.
		/// </hide>
		public const int STATUS_BAR_DISABLE_EXPAND = unchecked((int)(0x00010000));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to hide notification icons and scrolling ticker text.
		/// </hide>
		public const int STATUS_BAR_DISABLE_NOTIFICATION_ICONS = unchecked((int)(0x00020000
			));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to disable incoming notification alerts.  This will not block
		/// icons, but it will block sound, vibrating and other visual or aural notifications.
		/// </hide>
		public const int STATUS_BAR_DISABLE_NOTIFICATION_ALERTS = unchecked((int)(0x00040000
			));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to hide only the scrolling ticker.  Note that
		/// <see cref="STATUS_BAR_DISABLE_NOTIFICATION_ICONS">STATUS_BAR_DISABLE_NOTIFICATION_ICONS
		/// 	</see>
		/// implies
		/// <see cref="STATUS_BAR_DISABLE_NOTIFICATION_TICKER">STATUS_BAR_DISABLE_NOTIFICATION_TICKER
		/// 	</see>
		/// .
		/// </hide>
		public const int STATUS_BAR_DISABLE_NOTIFICATION_TICKER = unchecked((int)(0x00080000
			));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to hide the center system info area.
		/// </hide>
		public const int STATUS_BAR_DISABLE_SYSTEM_INFO = unchecked((int)(0x00100000));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to hide only the home button.  Don't use this
		/// unless you're a special part of the system UI (i.e., setup wizard, keyguard).
		/// </hide>
		public const int STATUS_BAR_DISABLE_HOME = unchecked((int)(0x00200000));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to hide only the back button. Don't use this
		/// unless you're a special part of the system UI (i.e., setup wizard, keyguard).
		/// </hide>
		public const int STATUS_BAR_DISABLE_BACK = unchecked((int)(0x00400000));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to hide only the clock.  You might use this if your activity has
		/// its own clock making the status bar's clock redundant.
		/// </hide>
		public const int STATUS_BAR_DISABLE_CLOCK = unchecked((int)(0x00800000));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility. It is masked
		/// out of the public fields to keep the undefined bits out of the developer's way.
		/// Flag to hide only the recent apps button. Don't use this
		/// unless you're a special part of the system UI (i.e., setup wizard, keyguard).
		/// </hide>
		public const int STATUS_BAR_DISABLE_RECENT = unchecked((int)(0x01000000));

		/// <hide>
		/// NOTE: This flag may only be used in subtreeSystemUiVisibility, etc. etc.
		/// This hides HOME and RECENT and is provided for compatibility with interim implementations.
		/// </hide>
		[System.Obsolete]
		public const int STATUS_BAR_DISABLE_NAVIGATION = STATUS_BAR_DISABLE_HOME | STATUS_BAR_DISABLE_RECENT;

		/// <hide></hide>
		public const int PUBLIC_STATUS_BAR_VISIBILITY_MASK = unchecked((int)(0x0000FFFF));

		/// <summary>
		/// These are the system UI flags that can be cleared by events outside
		/// of an application.
		/// </summary>
		/// <remarks>
		/// These are the system UI flags that can be cleared by events outside
		/// of an application.  Currently this is just the ability to tap on the
		/// screen while hiding the navigation bar to have it return.
		/// </remarks>
		/// <hide></hide>
		public const int SYSTEM_UI_CLEARABLE_FLAGS = SYSTEM_UI_FLAG_LOW_PROFILE | SYSTEM_UI_FLAG_HIDE_NAVIGATION;

		/// <summary>Find views that render the specified text.</summary>
		/// <remarks>Find views that render the specified text.</remarks>
		/// <seealso cref="findViewsWithText(java.util.ArrayList{E}, java.lang.CharSequence, int)
		/// 	">findViewsWithText(java.util.ArrayList&lt;E&gt;, java.lang.CharSequence, int)</seealso>
		public const int FIND_VIEWS_WITH_TEXT = unchecked((int)(0x00000001));

		/// <summary>Find find views that contain the specified content description.</summary>
		/// <remarks>Find find views that contain the specified content description.</remarks>
		/// <seealso cref="findViewsWithText(java.util.ArrayList{E}, java.lang.CharSequence, int)
		/// 	">findViewsWithText(java.util.ArrayList&lt;E&gt;, java.lang.CharSequence, int)</seealso>
		public const int FIND_VIEWS_WITH_CONTENT_DESCRIPTION = unchecked((int)(0x00000002
			));

		/// <summary>Controls the over-scroll mode for this view.</summary>
		/// <remarks>
		/// Controls the over-scroll mode for this view.
		/// See
		/// <see cref="overScrollBy(int, int, int, int, int, int, int, int, bool)">overScrollBy(int, int, int, int, int, int, int, int, bool)
		/// 	</see>
		/// ,
		/// <see cref="OVER_SCROLL_ALWAYS">OVER_SCROLL_ALWAYS</see>
		/// ,
		/// <see cref="OVER_SCROLL_IF_CONTENT_SCROLLS">OVER_SCROLL_IF_CONTENT_SCROLLS</see>
		/// ,
		/// and
		/// <see cref="OVER_SCROLL_NEVER">OVER_SCROLL_NEVER</see>
		/// .
		/// </remarks>
		private int mOverScrollMode;

		/// <summary>The parent this view is attached to.</summary>
		/// <remarks>
		/// The parent this view is attached to.
		/// <hide></hide>
		/// </remarks>
		/// <seealso cref="getParent()">getParent()</seealso>
		protected internal android.view.ViewParent mParent;

		/// <summary><hide></hide></summary>
		internal android.view.View.AttachInfo mAttachInfo;

		/// <summary><hide></hide></summary>
		internal int mPrivateFlags;

		internal int mPrivateFlags2;

		/// <summary>This view's request for the visibility of the status bar.</summary>
		/// <remarks>This view's request for the visibility of the status bar.</remarks>
		/// <hide></hide>
		internal int mSystemUiVisibility;

		/// <summary>Count of how many windows this view has been attached to.</summary>
		/// <remarks>Count of how many windows this view has been attached to.</remarks>
		internal int mWindowAttachCount;

		/// <summary>
		/// The layout parameters associated with this view and used by the parent
		/// <see cref="ViewGroup">ViewGroup</see>
		/// to determine how this view should be
		/// laid out.
		/// <hide></hide>
		/// </summary>
		protected internal android.view.ViewGroup.LayoutParams mLayoutParams;

		/// <summary>The view flags hold various views states.</summary>
		/// <remarks>
		/// The view flags hold various views states.
		/// <hide></hide>
		/// </remarks>
		[android.view.ViewDebug.ExportedProperty]
		internal int mViewFlags;

		internal class TransformationInfo
		{
			/// <summary>The transform matrix for the View.</summary>
			/// <remarks>
			/// The transform matrix for the View. This transform is calculated internally
			/// based on the rotation, scaleX, and scaleY properties. The identity matrix
			/// is used by default. Do *not* use this variable directly; instead call
			/// getMatrix(), which will automatically recalculate the matrix if necessary
			/// to get the correct matrix based on the latest rotation and scale properties.
			/// </remarks>
			internal readonly android.graphics.Matrix mMatrix = new android.graphics.Matrix();

			/// <summary>The transform matrix for the View.</summary>
			/// <remarks>
			/// The transform matrix for the View. This transform is calculated internally
			/// based on the rotation, scaleX, and scaleY properties. The identity matrix
			/// is used by default. Do *not* use this variable directly; instead call
			/// getInverseMatrix(), which will automatically recalculate the matrix if necessary
			/// to get the correct matrix based on the latest rotation and scale properties.
			/// </remarks>
			internal android.graphics.Matrix mInverseMatrix;

			/// <summary>
			/// An internal variable that tracks whether we need to recalculate the
			/// transform matrix, based on whether the rotation or scaleX/Y properties
			/// have changed since the matrix was last calculated.
			/// </summary>
			/// <remarks>
			/// An internal variable that tracks whether we need to recalculate the
			/// transform matrix, based on whether the rotation or scaleX/Y properties
			/// have changed since the matrix was last calculated.
			/// </remarks>
			internal bool mMatrixDirty = false;

			/// <summary>
			/// An internal variable that tracks whether we need to recalculate the
			/// transform matrix, based on whether the rotation or scaleX/Y properties
			/// have changed since the matrix was last calculated.
			/// </summary>
			/// <remarks>
			/// An internal variable that tracks whether we need to recalculate the
			/// transform matrix, based on whether the rotation or scaleX/Y properties
			/// have changed since the matrix was last calculated.
			/// </remarks>
			internal bool mInverseMatrixDirty = true;

			/// <summary>
			/// A variable that tracks whether we need to recalculate the
			/// transform matrix, based on whether the rotation or scaleX/Y properties
			/// have changed since the matrix was last calculated.
			/// </summary>
			/// <remarks>
			/// A variable that tracks whether we need to recalculate the
			/// transform matrix, based on whether the rotation or scaleX/Y properties
			/// have changed since the matrix was last calculated. This variable
			/// is only valid after a call to updateMatrix() or to a function that
			/// calls it such as getMatrix(), hasIdentityMatrix() and getInverseMatrix().
			/// </remarks>
			internal bool mMatrixIsIdentity = true;

			/// <summary>The Camera object is used to compute a 3D matrix when rotationX or rotationY are set.
			/// 	</summary>
			/// <remarks>The Camera object is used to compute a 3D matrix when rotationX or rotationY are set.
			/// 	</remarks>
			internal android.graphics.Camera mCamera = null;

			/// <summary>This matrix is used when computing the matrix for 3D rotations.</summary>
			/// <remarks>This matrix is used when computing the matrix for 3D rotations.</remarks>
			internal android.graphics.Matrix matrix3D = null;

			/// <summary>These prev values are used to recalculate a centered pivot point when necessary.
			/// 	</summary>
			/// <remarks>
			/// These prev values are used to recalculate a centered pivot point when necessary. The
			/// pivot point is only used in matrix operations (when rotation, scale, or translation are
			/// set), so thes values are only used then as well.
			/// </remarks>
			internal int mPrevWidth = -1;

			internal int mPrevHeight = -1;

			/// <summary>The degrees rotation around the vertical axis through the pivot point.</summary>
			/// <remarks>The degrees rotation around the vertical axis through the pivot point.</remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mRotationY = 0f;

			/// <summary>The degrees rotation around the horizontal axis through the pivot point.
			/// 	</summary>
			/// <remarks>The degrees rotation around the horizontal axis through the pivot point.
			/// 	</remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mRotationX = 0f;

			/// <summary>The degrees rotation around the pivot point.</summary>
			/// <remarks>The degrees rotation around the pivot point.</remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mRotation = 0f;

			/// <summary>The amount of translation of the object away from its left property (post-layout).
			/// 	</summary>
			/// <remarks>The amount of translation of the object away from its left property (post-layout).
			/// 	</remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mTranslationX = 0f;

			/// <summary>The amount of translation of the object away from its top property (post-layout).
			/// 	</summary>
			/// <remarks>The amount of translation of the object away from its top property (post-layout).
			/// 	</remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mTranslationY = 0f;

			/// <summary>The amount of scale in the x direction around the pivot point.</summary>
			/// <remarks>
			/// The amount of scale in the x direction around the pivot point. A
			/// value of 1 means no scaling is applied.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mScaleX = 1f;

			/// <summary>The amount of scale in the y direction around the pivot point.</summary>
			/// <remarks>
			/// The amount of scale in the y direction around the pivot point. A
			/// value of 1 means no scaling is applied.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mScaleY = 1f;

			/// <summary>The amount of scale in the x direction around the pivot point.</summary>
			/// <remarks>
			/// The amount of scale in the x direction around the pivot point. A
			/// value of 1 means no scaling is applied.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mPivotX = 0f;

			/// <summary>The amount of scale in the y direction around the pivot point.</summary>
			/// <remarks>
			/// The amount of scale in the y direction around the pivot point. A
			/// value of 1 means no scaling is applied.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mPivotY = 0f;

			/// <summary>The opacity of the View.</summary>
			/// <remarks>
			/// The opacity of the View. This is a value from 0 to 1, where 0 means
			/// completely transparent and 1 means completely opaque.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			internal float mAlpha = 1f;
			// for mPrivateFlags:
		}

		internal android.view.View.TransformationInfo mTransformationInfo;

		private bool mLastIsOpaque;

		/// <summary>
		/// Convenience value to check for float values that are close enough to zero to be considered
		/// zero.
		/// </summary>
		/// <remarks>
		/// Convenience value to check for float values that are close enough to zero to be considered
		/// zero.
		/// </remarks>
		internal const float NONZERO_EPSILON = .001f;

		/// <summary>
		/// The distance in pixels from the left edge of this view's parent
		/// to the left edge of this view.
		/// </summary>
		/// <remarks>
		/// The distance in pixels from the left edge of this view's parent
		/// to the left edge of this view.
		/// <hide></hide>
		/// </remarks>
		protected internal int mLeft;

		/// <summary>
		/// The distance in pixels from the left edge of this view's parent
		/// to the right edge of this view.
		/// </summary>
		/// <remarks>
		/// The distance in pixels from the left edge of this view's parent
		/// to the right edge of this view.
		/// <hide></hide>
		/// </remarks>
		protected internal int mRight;

		/// <summary>
		/// The distance in pixels from the top edge of this view's parent
		/// to the top edge of this view.
		/// </summary>
		/// <remarks>
		/// The distance in pixels from the top edge of this view's parent
		/// to the top edge of this view.
		/// <hide></hide>
		/// </remarks>
		protected internal int mTop;

		/// <summary>
		/// The distance in pixels from the top edge of this view's parent
		/// to the bottom edge of this view.
		/// </summary>
		/// <remarks>
		/// The distance in pixels from the top edge of this view's parent
		/// to the bottom edge of this view.
		/// <hide></hide>
		/// </remarks>
		protected internal int mBottom;

		/// <summary>
		/// The offset, in pixels, by which the content of this view is scrolled
		/// horizontally.
		/// </summary>
		/// <remarks>
		/// The offset, in pixels, by which the content of this view is scrolled
		/// horizontally.
		/// <hide></hide>
		/// </remarks>
		protected internal int mScrollX;

		/// <summary>
		/// The offset, in pixels, by which the content of this view is scrolled
		/// vertically.
		/// </summary>
		/// <remarks>
		/// The offset, in pixels, by which the content of this view is scrolled
		/// vertically.
		/// <hide></hide>
		/// </remarks>
		protected internal int mScrollY;

		/// <summary>
		/// The left padding in pixels, that is the distance in pixels between the
		/// left edge of this view and the left edge of its content.
		/// </summary>
		/// <remarks>
		/// The left padding in pixels, that is the distance in pixels between the
		/// left edge of this view and the left edge of its content.
		/// <hide></hide>
		/// </remarks>
		protected internal int mPaddingLeft;

		/// <summary>
		/// The right padding in pixels, that is the distance in pixels between the
		/// right edge of this view and the right edge of its content.
		/// </summary>
		/// <remarks>
		/// The right padding in pixels, that is the distance in pixels between the
		/// right edge of this view and the right edge of its content.
		/// <hide></hide>
		/// </remarks>
		protected internal int mPaddingRight;

		/// <summary>
		/// The top padding in pixels, that is the distance in pixels between the
		/// top edge of this view and the top edge of its content.
		/// </summary>
		/// <remarks>
		/// The top padding in pixels, that is the distance in pixels between the
		/// top edge of this view and the top edge of its content.
		/// <hide></hide>
		/// </remarks>
		protected internal int mPaddingTop;

		/// <summary>
		/// The bottom padding in pixels, that is the distance in pixels between the
		/// bottom edge of this view and the bottom edge of its content.
		/// </summary>
		/// <remarks>
		/// The bottom padding in pixels, that is the distance in pixels between the
		/// bottom edge of this view and the bottom edge of its content.
		/// <hide></hide>
		/// </remarks>
		protected internal int mPaddingBottom;

		/// <summary>Briefly describes the view and is primarily used for accessibility support.
		/// 	</summary>
		/// <remarks>Briefly describes the view and is primarily used for accessibility support.
		/// 	</remarks>
		private java.lang.CharSequence mContentDescription;

		/// <summary>Cache the paddingRight set by the user to append to the scrollbar's size.
		/// 	</summary>
		/// <remarks>Cache the paddingRight set by the user to append to the scrollbar's size.
		/// 	</remarks>
		/// <hide></hide>
		protected internal int mUserPaddingRight;

		/// <summary>Cache the paddingBottom set by the user to append to the scrollbar's size.
		/// 	</summary>
		/// <remarks>Cache the paddingBottom set by the user to append to the scrollbar's size.
		/// 	</remarks>
		/// <hide></hide>
		protected internal int mUserPaddingBottom;

		/// <summary>Cache the paddingLeft set by the user to append to the scrollbar's size.
		/// 	</summary>
		/// <remarks>Cache the paddingLeft set by the user to append to the scrollbar's size.
		/// 	</remarks>
		/// <hide></hide>
		protected internal int mUserPaddingLeft;

		/// <summary>Cache if the user padding is relative.</summary>
		/// <remarks>Cache if the user padding is relative.</remarks>
		internal bool mUserPaddingRelative;

		/// <summary>Cache the paddingStart set by the user to append to the scrollbar's size.
		/// 	</summary>
		/// <remarks>Cache the paddingStart set by the user to append to the scrollbar's size.
		/// 	</remarks>
		internal int mUserPaddingStart;

		/// <summary>Cache the paddingEnd set by the user to append to the scrollbar's size.</summary>
		/// <remarks>Cache the paddingEnd set by the user to append to the scrollbar's size.</remarks>
		internal int mUserPaddingEnd;

		/// <hide></hide>
		internal int mOldWidthMeasureSpec = int.MinValue;

		/// <hide></hide>
		internal int mOldHeightMeasureSpec = int.MinValue;

		private android.graphics.drawable.Drawable mBGDrawable;

		private int mBackgroundResource;

		private bool mBackgroundSizeChanged;

		/// <summary>Listener used to dispatch focus change events.</summary>
		/// <remarks>
		/// Listener used to dispatch focus change events.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.view.View.OnFocusChangeListener mOnFocusChangeListener;

		/// <summary>Listeners for layout change events.</summary>
		/// <remarks>Listeners for layout change events.</remarks>
		private java.util.ArrayList<android.view.View.OnLayoutChangeListener> mOnLayoutChangeListeners;

		/// <summary>Listeners for attach events.</summary>
		/// <remarks>Listeners for attach events.</remarks>
		private java.util.concurrent.CopyOnWriteArrayList<android.view.View.OnAttachStateChangeListener
			> mOnAttachStateChangeListeners;

		/// <summary>Listener used to dispatch click events.</summary>
		/// <remarks>
		/// Listener used to dispatch click events.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.view.View.OnClickListener mOnClickListener;

		/// <summary>Listener used to dispatch long click events.</summary>
		/// <remarks>
		/// Listener used to dispatch long click events.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.view.View.OnLongClickListener mOnLongClickListener;

		/// <summary>Listener used to build the context menu.</summary>
		/// <remarks>
		/// Listener used to build the context menu.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.view.View.OnCreateContextMenuListener mOnCreateContextMenuListener;

		private android.view.View.OnKeyListener mOnKeyListener;

		private android.view.View.OnTouchListener mOnTouchListener;

		private android.view.View.OnHoverListener mOnHoverListener;

		private android.view.View.OnGenericMotionListener mOnGenericMotionListener;

		private android.view.View.OnDragListener mOnDragListener;

		private android.view.View.OnSystemUiVisibilityChangeListener mOnSystemUiVisibilityChangeListener;

		/// <summary>The application environment this view lives in.</summary>
		/// <remarks>
		/// The application environment this view lives in.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.content.Context mContext;

		private readonly android.content.res.Resources mResources;

		private android.view.View.ScrollabilityCache mScrollCache;

		private int[] mDrawableState = null;

		/// <summary>Set to true when drawing cache is enabled and cannot be created.</summary>
		/// <remarks>Set to true when drawing cache is enabled and cannot be created.</remarks>
		/// <hide></hide>
		public bool mCachingFailed;

		private android.graphics.Bitmap mDrawingCache;

		private android.graphics.Bitmap mUnscaledDrawingCache;

		private android.view.HardwareLayer mHardwareLayer;

		internal android.view.DisplayList mDisplayList;

		/// <summary>
		/// When this view has focus and the next focus is
		/// <see cref="FOCUS_LEFT">FOCUS_LEFT</see>
		/// ,
		/// the user may specify which view to go to next.
		/// </summary>
		private int mNextFocusLeftId = android.view.View.NO_ID;

		/// <summary>
		/// When this view has focus and the next focus is
		/// <see cref="FOCUS_RIGHT">FOCUS_RIGHT</see>
		/// ,
		/// the user may specify which view to go to next.
		/// </summary>
		private int mNextFocusRightId = android.view.View.NO_ID;

		/// <summary>
		/// When this view has focus and the next focus is
		/// <see cref="FOCUS_UP">FOCUS_UP</see>
		/// ,
		/// the user may specify which view to go to next.
		/// </summary>
		private int mNextFocusUpId = android.view.View.NO_ID;

		/// <summary>
		/// When this view has focus and the next focus is
		/// <see cref="FOCUS_DOWN">FOCUS_DOWN</see>
		/// ,
		/// the user may specify which view to go to next.
		/// </summary>
		private int mNextFocusDownId = android.view.View.NO_ID;

		/// <summary>
		/// When this view has focus and the next focus is
		/// <see cref="FOCUS_FORWARD">FOCUS_FORWARD</see>
		/// ,
		/// the user may specify which view to go to next.
		/// </summary>
		internal int mNextFocusForwardId = android.view.View.NO_ID;

		private android.view.View.CheckForLongPress mPendingCheckForLongPress;

		private android.view.View.CheckForTap mPendingCheckForTap = null;

		private android.view.View.PerformClick mPerformClick;

		private android.view.View.SendViewScrolledAccessibilityEvent mSendViewScrolledAccessibilityEvent;

		private android.view.View.UnsetPressedState mUnsetPressedState;

		/// <summary>Whether the long press's action has been invoked.</summary>
		/// <remarks>
		/// Whether the long press's action has been invoked.  The tap's action is invoked on the
		/// up event while a long press is invoked as soon as the long press duration is reached, so
		/// a long press could be performed before the tap is checked, in which case the tap's action
		/// should not be invoked.
		/// </remarks>
		private bool mHasPerformedLongPress;

		/// <summary>The minimum height of the view.</summary>
		/// <remarks>
		/// The minimum height of the view. We'll try our best to have the height
		/// of this view to at least this amount.
		/// </remarks>
		private int mMinHeight;

		/// <summary>The minimum width of the view.</summary>
		/// <remarks>
		/// The minimum width of the view. We'll try our best to have the width
		/// of this view to at least this amount.
		/// </remarks>
		private int mMinWidth;

		/// <summary>
		/// The delegate to handle touch events that are physically in this view
		/// but should be handled by another view.
		/// </summary>
		/// <remarks>
		/// The delegate to handle touch events that are physically in this view
		/// but should be handled by another view.
		/// </remarks>
		private android.view.TouchDelegate mTouchDelegate = null;

		/// <summary>Solid color to use as a background when creating the drawing cache.</summary>
		/// <remarks>
		/// Solid color to use as a background when creating the drawing cache. Enables
		/// the cache to use 16 bit bitmaps instead of 32 bit.
		/// </remarks>
		private int mDrawingCacheBackgroundColor = 0;

		/// <summary>Special tree observer used when mAttachInfo is null.</summary>
		/// <remarks>Special tree observer used when mAttachInfo is null.</remarks>
		private android.view.ViewTreeObserver mFloatingTreeObserver;

		/// <summary>Cache the touch slop from the context that created the view.</summary>
		/// <remarks>Cache the touch slop from the context that created the view.</remarks>
		private int mTouchSlop;

		/// <summary>Object that handles automatic animation of view properties.</summary>
		/// <remarks>Object that handles automatic animation of view properties.</remarks>
		private android.view.ViewPropertyAnimator mAnimator = null;

		/// <summary>Flag indicating that a drag can cross window boundaries.</summary>
		/// <remarks>
		/// Flag indicating that a drag can cross window boundaries.  When
		/// <see cref="startDrag(android.content.ClipData, DragShadowBuilder, object, int)">startDrag(android.content.ClipData, DragShadowBuilder, object, int)
		/// 	</see>
		/// is called
		/// with this flag set, all visible applications will be able to participate
		/// in the drag operation and receive the dragged content.
		/// </remarks>
		/// <hide></hide>
		public const int DRAG_FLAG_GLOBAL = 1;

		/// <summary>
		/// Vertical scroll factor cached by
		/// <see cref="getVerticalScrollFactor()">getVerticalScrollFactor()</see>
		/// .
		/// </summary>
		private float mVerticalScrollFactor;

		/// <summary>Position of the vertical scroll bar.</summary>
		/// <remarks>Position of the vertical scroll bar.</remarks>
		private int mVerticalScrollbarPosition;

		/// <summary>Position the scroll bar at the default position as determined by the system.
		/// 	</summary>
		/// <remarks>Position the scroll bar at the default position as determined by the system.
		/// 	</remarks>
		public const int SCROLLBAR_POSITION_DEFAULT = 0;

		/// <summary>Position the scroll bar along the left edge.</summary>
		/// <remarks>Position the scroll bar along the left edge.</remarks>
		public const int SCROLLBAR_POSITION_LEFT = 1;

		/// <summary>Position the scroll bar along the right edge.</summary>
		/// <remarks>Position the scroll bar along the right edge.</remarks>
		public const int SCROLLBAR_POSITION_RIGHT = 2;

		/// <summary>Indicates that the view does not have a layer.</summary>
		/// <remarks>Indicates that the view does not have a layer.</remarks>
		/// <seealso cref="getLayerType()">getLayerType()</seealso>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</seealso>
		/// <seealso cref="LAYER_TYPE_SOFTWARE">LAYER_TYPE_SOFTWARE</seealso>
		/// <seealso cref="LAYER_TYPE_HARDWARE">LAYER_TYPE_HARDWARE</seealso>
		public const int LAYER_TYPE_NONE = 0;

		/// <summary><p>Indicates that the view has a software layer.</summary>
		/// <remarks>
		/// <p>Indicates that the view has a software layer. A software layer is backed
		/// by a bitmap and causes the view to be rendered using Android's software
		/// rendering pipeline, even if hardware acceleration is enabled.</p>
		/// <p>Software layers have various usages:</p>
		/// <p>When the application is not using hardware acceleration, a software layer
		/// is useful to apply a specific color filter and/or blending mode and/or
		/// translucency to a view and all its children.</p>
		/// <p>When the application is using hardware acceleration, a software layer
		/// is useful to render drawing primitives not supported by the hardware
		/// accelerated pipeline. It can also be used to cache a complex view tree
		/// into a texture and reduce the complexity of drawing operations. For instance,
		/// when animating a complex view tree with a translation, a software layer can
		/// be used to render the view tree only once.</p>
		/// <p>Software layers should be avoided when the affected view tree updates
		/// often. Every update will require to re-render the software layer, which can
		/// potentially be slow (particularly when hardware acceleration is turned on
		/// since the layer will have to be uploaded into a hardware texture after every
		/// update.)</p>
		/// </remarks>
		/// <seealso cref="getLayerType()">getLayerType()</seealso>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</seealso>
		/// <seealso cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</seealso>
		/// <seealso cref="LAYER_TYPE_HARDWARE">LAYER_TYPE_HARDWARE</seealso>
		public const int LAYER_TYPE_SOFTWARE = 1;

		/// <summary><p>Indicates that the view has a hardware layer.</summary>
		/// <remarks>
		/// <p>Indicates that the view has a hardware layer. A hardware layer is backed
		/// by a hardware specific texture (generally Frame Buffer Objects or FBO on
		/// OpenGL hardware) and causes the view to be rendered using Android's hardware
		/// rendering pipeline, but only if hardware acceleration is turned on for the
		/// view hierarchy. When hardware acceleration is turned off, hardware layers
		/// behave exactly as
		/// <see cref="LAYER_TYPE_SOFTWARE">software layers</see>
		/// .</p>
		/// <p>A hardware layer is useful to apply a specific color filter and/or
		/// blending mode and/or translucency to a view and all its children.</p>
		/// <p>A hardware layer can be used to cache a complex view tree into a
		/// texture and reduce the complexity of drawing operations. For instance,
		/// when animating a complex view tree with a translation, a hardware layer can
		/// be used to render the view tree only once.</p>
		/// <p>A hardware layer can also be used to increase the rendering quality when
		/// rotation transformations are applied on a view. It can also be used to
		/// prevent potential clipping issues when applying 3D transforms on a view.</p>
		/// </remarks>
		/// <seealso cref="getLayerType()">getLayerType()</seealso>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</seealso>
		/// <seealso cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</seealso>
		/// <seealso cref="LAYER_TYPE_SOFTWARE">LAYER_TYPE_SOFTWARE</seealso>
		public const int LAYER_TYPE_HARDWARE = 2;

		internal int mLayerType = LAYER_TYPE_NONE;

		internal android.graphics.Paint mLayerPaint;

		internal android.graphics.Rect mLocalDirtyRect;

		/// <summary>
		/// Set to true when the view is sending hover accessibility events because it
		/// is the innermost hovered view.
		/// </summary>
		/// <remarks>
		/// Set to true when the view is sending hover accessibility events because it
		/// is the innermost hovered view.
		/// </remarks>
		private bool mSendingHoverAccessibilityEvents;

		/// <summary>Delegate for injecting accessiblity functionality.</summary>
		/// <remarks>Delegate for injecting accessiblity functionality.</remarks>
		internal android.view.View.AccessibilityDelegate mAccessibilityDelegate;

		/// <summary>
		/// Text direction is inherited thru
		/// <see cref="ViewGroup">ViewGroup</see>
		/// </summary>
		/// <hide></hide>
		public const int TEXT_DIRECTION_INHERIT = 0;

		/// <summary>Text direction is using "first strong algorithm".</summary>
		/// <remarks>
		/// Text direction is using "first strong algorithm". The first strong directional character
		/// determines the paragraph direction. If there is no strong directional character, the
		/// paragraph direction is the view's resolved ayout direction.
		/// </remarks>
		/// <hide></hide>
		public const int TEXT_DIRECTION_FIRST_STRONG = 1;

		/// <summary>Text direction is using "any-RTL" algorithm.</summary>
		/// <remarks>
		/// Text direction is using "any-RTL" algorithm. The paragraph direction is RTL if it contains
		/// any strong RTL character, otherwise it is LTR if it contains any strong LTR characters.
		/// If there are neither, the paragraph direction is the view's resolved layout direction.
		/// </remarks>
		/// <hide></hide>
		public const int TEXT_DIRECTION_ANY_RTL = 2;

		/// <summary>Text direction is forced to LTR.</summary>
		/// <remarks>Text direction is forced to LTR.</remarks>
		/// <hide></hide>
		public const int TEXT_DIRECTION_LTR = 3;

		/// <summary>Text direction is forced to RTL.</summary>
		/// <remarks>Text direction is forced to RTL.</remarks>
		/// <hide></hide>
		public const int TEXT_DIRECTION_RTL = 4;

		/// <summary>Default text direction is inherited</summary>
		/// <hide></hide>
		protected internal static int DEFAULT_TEXT_DIRECTION = TEXT_DIRECTION_INHERIT;

		/// <summary>
		/// The text direction that has been defined by
		/// <see cref="setTextDirection(int)">setTextDirection(int)</see>
		/// .
		/// <hide></hide>
		/// </summary>
		private int mTextDirection = DEFAULT_TEXT_DIRECTION;

		/// <summary>The resolved text direction.</summary>
		/// <remarks>
		/// The resolved text direction.  This needs resolution if the value is
		/// TEXT_DIRECTION_INHERIT.  The resolution matches mTextDirection if that is
		/// not TEXT_DIRECTION_INHERIT, otherwise resolution proceeds up the parent
		/// chain of the view.
		/// <hide></hide>
		/// </remarks>
		private int mResolvedTextDirection = TEXT_DIRECTION_INHERIT;

		/// <summary>Consistency verifier for debugging purposes.</summary>
		/// <remarks>Consistency verifier for debugging purposes.</remarks>
		/// <hide></hide>
		protected internal readonly android.view.InputEventConsistencyVerifier mInputEventConsistencyVerifier;

		/// <summary>Simple constructor to use when creating a view from code.</summary>
		/// <remarks>Simple constructor to use when creating a view from code.</remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		public View(android.content.Context context)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
			mContext = context;
			mResources = context != null ? context.getResources() : null;
			mViewFlags = SOUND_EFFECTS_ENABLED | HAPTIC_FEEDBACK_ENABLED | LAYOUT_DIRECTION_INHERIT;
			mTouchSlop = android.view.ViewConfiguration.get(context).getScaledTouchSlop();
			setOverScrollMode(OVER_SCROLL_IF_CONTENT_SCROLLS);
			mUserPaddingStart = -1;
			mUserPaddingEnd = -1;
			mUserPaddingRelative = false;
		}

		/// <summary>Constructor that is called when inflating a view from XML.</summary>
		/// <remarks>
		/// Constructor that is called when inflating a view from XML. This is called
		/// when a view is being constructed from an XML file, supplying attributes
		/// that were specified in the XML file. This version uses a default style of
		/// 0, so the only attribute values applied are those in the Context's Theme
		/// and the given AttributeSet.
		/// <p>
		/// The method onFinishInflate() will be called after all children have been
		/// added.
		/// </remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		/// <param name="attrs">The attributes of the XML tag that is inflating the view.</param>
		/// <seealso cref="View(android.content.Context, android.util.AttributeSet, int)">View(android.content.Context, android.util.AttributeSet, int)
		/// 	</seealso>
		public View(android.content.Context context, android.util.AttributeSet attrs) : this
			(context, attrs, 0)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
		}

		private sealed class _OnClickListener_3011 : android.view.View.OnClickListener
		{
			public _OnClickListener_3011(View _enclosing, string handlerName)
			{
				this._enclosing = _enclosing;
				this.handlerName = handlerName;
			}

			private System.Reflection.MethodInfo mHandler;

			// Clear any HORIZONTAL_DIRECTION flag already set
			// Set the HORIZONTAL_DIRECTION flags depending on the value of the attribute
			// Set to default (LAYOUT_DIRECTION_INHERIT)
			//noinspection deprecation
			// Ignore the attribute starting with ICS
			// With builds < ICS, fall through and apply fading edges
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				if (this.mHandler == null)
				{
					try
					{
						this.mHandler = XobotOS.Runtime.Reflection.GetMethod(this._enclosing.getContext()
							.GetType(), handlerName, typeof(android.view.View));
					}
					catch (java.lang.NoSuchMethodException e)
					{
						int id = this._enclosing.getId();
						string idText = id == android.view.View.NO_ID ? string.Empty : " with id '" + this
							._enclosing.getContext().getResources().getResourceEntryName(id) + "'";
						throw new System.InvalidOperationException("Could not find a method " + handlerName
							 + "(View) in the activity " + this._enclosing.getContext().GetType() + " for onClick handler"
							 + " on view " + this._enclosing.GetType() + idText, e);
					}
				}
				try
				{
					XobotOS.Runtime.Reflection.InvokeMethod(this.mHandler, this._enclosing.getContext
						(), this._enclosing);
				}
				catch (System.MemberAccessException e)
				{
					throw new System.InvalidOperationException("Could not execute non " + "public method of the activity"
						, e);
				}
				catch (System.Reflection.TargetInvocationException e)
				{
					throw new System.InvalidOperationException("Could not execute " + "method of the activity"
						, e);
				}
			}

			private readonly View _enclosing;

			private readonly string handlerName;
		}

		/// <summary>Perform inflation from XML and apply a class-specific base style.</summary>
		/// <remarks>
		/// Perform inflation from XML and apply a class-specific base style. This
		/// constructor of View allows subclasses to use their own base style when
		/// they are inflating. For example, a Button class's constructor would call
		/// this version of the super class constructor and supply
		/// <code>R.attr.buttonStyle</code> for <var>defStyle</var>; this allows
		/// the theme's button style to modify all of the base view attributes (in
		/// particular its background) as well as the Button class's attributes.
		/// </remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		/// <param name="attrs">The attributes of the XML tag that is inflating the view.</param>
		/// <param name="defStyle">
		/// The default style to apply to this view. If 0, no style
		/// will be applied (beyond what is included in the theme). This may
		/// either be an attribute resource, whose value will be retrieved
		/// from the current theme, or an explicit style resource.
		/// </param>
		/// <seealso cref="View(android.content.Context, android.util.AttributeSet)">View(android.content.Context, android.util.AttributeSet)
		/// 	</seealso>
		public View(android.content.Context context, android.util.AttributeSet attrs, int
			 defStyle) : this(context)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.View, defStyle, 0);
			android.graphics.drawable.Drawable background = null;
			int leftPadding = -1;
			int topPadding = -1;
			int rightPadding = -1;
			int bottomPadding = -1;
			int startPadding = -1;
			int endPadding = -1;
			int padding = -1;
			int viewFlagValues = 0;
			int viewFlagMasks = 0;
			bool setScrollContainer_1 = false;
			int x = 0;
			int y = 0;
			float tx = 0;
			float ty = 0;
			float rotation = 0;
			float rotationX = 0;
			float rotationY = 0;
			float sx = 1f;
			float sy = 1f;
			bool transformSet = false;
			int scrollbarStyle = SCROLLBARS_INSIDE_OVERLAY;
			int overScrollMode = mOverScrollMode;
			int N = a.getIndexCount();
			{
				for (int i = 0; i < N; i++)
				{
					int attr = a.getIndex(i);
					switch (attr)
					{
						case android.@internal.R.styleable.View_background:
						{
							background = a.getDrawable(attr);
							break;
						}

						case android.@internal.R.styleable.View_padding:
						{
							padding = a.getDimensionPixelSize(attr, -1);
							break;
						}

						case android.@internal.R.styleable.View_paddingLeft:
						{
							leftPadding = a.getDimensionPixelSize(attr, -1);
							break;
						}

						case android.@internal.R.styleable.View_paddingTop:
						{
							topPadding = a.getDimensionPixelSize(attr, -1);
							break;
						}

						case android.@internal.R.styleable.View_paddingRight:
						{
							rightPadding = a.getDimensionPixelSize(attr, -1);
							break;
						}

						case android.@internal.R.styleable.View_paddingBottom:
						{
							bottomPadding = a.getDimensionPixelSize(attr, -1);
							break;
						}

						case android.@internal.R.styleable.View_paddingStart:
						{
							startPadding = a.getDimensionPixelSize(attr, -1);
							break;
						}

						case android.@internal.R.styleable.View_paddingEnd:
						{
							endPadding = a.getDimensionPixelSize(attr, -1);
							break;
						}

						case android.@internal.R.styleable.View_scrollX:
						{
							x = a.getDimensionPixelOffset(attr, 0);
							break;
						}

						case android.@internal.R.styleable.View_scrollY:
						{
							y = a.getDimensionPixelOffset(attr, 0);
							break;
						}

						case android.@internal.R.styleable.View_alpha:
						{
							setAlpha(a.getFloat(attr, 1f));
							break;
						}

						case android.@internal.R.styleable.View_transformPivotX:
						{
							setPivotX(a.getDimensionPixelOffset(attr, 0));
							break;
						}

						case android.@internal.R.styleable.View_transformPivotY:
						{
							setPivotY(a.getDimensionPixelOffset(attr, 0));
							break;
						}

						case android.@internal.R.styleable.View_translationX:
						{
							tx = a.getDimensionPixelOffset(attr, 0);
							transformSet = true;
							break;
						}

						case android.@internal.R.styleable.View_translationY:
						{
							ty = a.getDimensionPixelOffset(attr, 0);
							transformSet = true;
							break;
						}

						case android.@internal.R.styleable.View_rotation:
						{
							rotation = a.getFloat(attr, 0);
							transformSet = true;
							break;
						}

						case android.@internal.R.styleable.View_rotationX:
						{
							rotationX = a.getFloat(attr, 0);
							transformSet = true;
							break;
						}

						case android.@internal.R.styleable.View_rotationY:
						{
							rotationY = a.getFloat(attr, 0);
							transformSet = true;
							break;
						}

						case android.@internal.R.styleable.View_scaleX:
						{
							sx = a.getFloat(attr, 1f);
							transformSet = true;
							break;
						}

						case android.@internal.R.styleable.View_scaleY:
						{
							sy = a.getFloat(attr, 1f);
							transformSet = true;
							break;
						}

						case android.@internal.R.styleable.View_id:
						{
							mID = a.getResourceId(attr, NO_ID);
							break;
						}

						case android.@internal.R.styleable.View_tag:
						{
							mTag = a.getText(attr);
							break;
						}

						case android.@internal.R.styleable.View_fitsSystemWindows:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= FITS_SYSTEM_WINDOWS;
								viewFlagMasks |= FITS_SYSTEM_WINDOWS;
							}
							break;
						}

						case android.@internal.R.styleable.View_focusable:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= FOCUSABLE;
								viewFlagMasks |= FOCUSABLE_MASK;
							}
							break;
						}

						case android.@internal.R.styleable.View_focusableInTouchMode:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= FOCUSABLE_IN_TOUCH_MODE | FOCUSABLE;
								viewFlagMasks |= FOCUSABLE_IN_TOUCH_MODE | FOCUSABLE_MASK;
							}
							break;
						}

						case android.@internal.R.styleable.View_clickable:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= CLICKABLE;
								viewFlagMasks |= CLICKABLE;
							}
							break;
						}

						case android.@internal.R.styleable.View_longClickable:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= LONG_CLICKABLE;
								viewFlagMasks |= LONG_CLICKABLE;
							}
							break;
						}

						case android.@internal.R.styleable.View_saveEnabled:
						{
							if (!a.getBoolean(attr, true))
							{
								viewFlagValues |= SAVE_DISABLED;
								viewFlagMasks |= SAVE_DISABLED_MASK;
							}
							break;
						}

						case android.@internal.R.styleable.View_duplicateParentState:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= DUPLICATE_PARENT_STATE;
								viewFlagMasks |= DUPLICATE_PARENT_STATE;
							}
							break;
						}

						case android.@internal.R.styleable.View_visibility:
						{
							int visibility = a.getInt(attr, 0);
							if (visibility != 0)
							{
								viewFlagValues |= VISIBILITY_FLAGS[visibility];
								viewFlagMasks |= VISIBILITY_MASK;
							}
							break;
						}

						case android.@internal.R.styleable.View_layoutDirection:
						{
							viewFlagValues &= ~LAYOUT_DIRECTION_MASK;
							int layoutDirection = a.getInt(attr, -1);
							if (layoutDirection != -1)
							{
								viewFlagValues |= LAYOUT_DIRECTION_FLAGS[layoutDirection];
							}
							else
							{
								viewFlagValues |= LAYOUT_DIRECTION_DEFAULT;
							}
							viewFlagMasks |= LAYOUT_DIRECTION_MASK;
							break;
						}

						case android.@internal.R.styleable.View_drawingCacheQuality:
						{
							int cacheQuality = a.getInt(attr, 0);
							if (cacheQuality != 0)
							{
								viewFlagValues |= DRAWING_CACHE_QUALITY_FLAGS[cacheQuality];
								viewFlagMasks |= DRAWING_CACHE_QUALITY_MASK;
							}
							break;
						}

						case android.@internal.R.styleable.View_contentDescription:
						{
							mContentDescription = java.lang.CharSequenceProxy.Wrap(a.getString(attr));
							break;
						}

						case android.@internal.R.styleable.View_soundEffectsEnabled:
						{
							if (!a.getBoolean(attr, true))
							{
								viewFlagValues &= ~SOUND_EFFECTS_ENABLED;
								viewFlagMasks |= SOUND_EFFECTS_ENABLED;
							}
							break;
						}

						case android.@internal.R.styleable.View_hapticFeedbackEnabled:
						{
							if (!a.getBoolean(attr, true))
							{
								viewFlagValues &= ~HAPTIC_FEEDBACK_ENABLED;
								viewFlagMasks |= HAPTIC_FEEDBACK_ENABLED;
							}
							break;
						}

						case android.@internal.R.styleable.View_scrollbars:
						{
							int scrollbars = a.getInt(attr, SCROLLBARS_NONE);
							if (scrollbars != SCROLLBARS_NONE)
							{
								viewFlagValues |= scrollbars;
								viewFlagMasks |= SCROLLBARS_MASK;
								initializeScrollbars(a);
							}
							break;
						}

						case android.@internal.R.styleable.View_fadingEdge:
						{
							if (context.getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES
								.ICE_CREAM_SANDWICH)
							{
								break;
							}
							goto case android.@internal.R.styleable.View_requiresFadingEdge;
						}

						case android.@internal.R.styleable.View_requiresFadingEdge:
						{
							int fadingEdge = a.getInt(attr, FADING_EDGE_NONE);
							if (fadingEdge != FADING_EDGE_NONE)
							{
								viewFlagValues |= fadingEdge;
								viewFlagMasks |= FADING_EDGE_MASK;
								initializeFadingEdge(a);
							}
							break;
						}

						case android.@internal.R.styleable.View_scrollbarStyle:
						{
							scrollbarStyle = a.getInt(attr, SCROLLBARS_INSIDE_OVERLAY);
							if (scrollbarStyle != SCROLLBARS_INSIDE_OVERLAY)
							{
								viewFlagValues |= scrollbarStyle & SCROLLBARS_STYLE_MASK;
								viewFlagMasks |= SCROLLBARS_STYLE_MASK;
							}
							break;
						}

						case android.@internal.R.styleable.View_isScrollContainer:
						{
							setScrollContainer_1 = true;
							if (a.getBoolean(attr, false))
							{
								setScrollContainer(true);
							}
							break;
						}

						case android.@internal.R.styleable.View_keepScreenOn:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= KEEP_SCREEN_ON;
								viewFlagMasks |= KEEP_SCREEN_ON;
							}
							break;
						}

						case android.@internal.R.styleable.View_filterTouchesWhenObscured:
						{
							if (a.getBoolean(attr, false))
							{
								viewFlagValues |= FILTER_TOUCHES_WHEN_OBSCURED;
								viewFlagMasks |= FILTER_TOUCHES_WHEN_OBSCURED;
							}
							break;
						}

						case android.@internal.R.styleable.View_nextFocusLeft:
						{
							mNextFocusLeftId = a.getResourceId(attr, android.view.View.NO_ID);
							break;
						}

						case android.@internal.R.styleable.View_nextFocusRight:
						{
							mNextFocusRightId = a.getResourceId(attr, android.view.View.NO_ID);
							break;
						}

						case android.@internal.R.styleable.View_nextFocusUp:
						{
							mNextFocusUpId = a.getResourceId(attr, android.view.View.NO_ID);
							break;
						}

						case android.@internal.R.styleable.View_nextFocusDown:
						{
							mNextFocusDownId = a.getResourceId(attr, android.view.View.NO_ID);
							break;
						}

						case android.@internal.R.styleable.View_nextFocusForward:
						{
							mNextFocusForwardId = a.getResourceId(attr, android.view.View.NO_ID);
							break;
						}

						case android.@internal.R.styleable.View_minWidth:
						{
							mMinWidth = a.getDimensionPixelSize(attr, 0);
							break;
						}

						case android.@internal.R.styleable.View_minHeight:
						{
							mMinHeight = a.getDimensionPixelSize(attr, 0);
							break;
						}

						case android.@internal.R.styleable.View_onClick:
						{
							if (context.isRestricted())
							{
								throw new System.InvalidOperationException("The android:onClick attribute cannot "
									 + "be used within a restricted context");
							}
							string handlerName = a.getString(attr);
							if (handlerName != null)
							{
								setOnClickListener(new _OnClickListener_3011(this, handlerName));
							}
							break;
						}

						case android.@internal.R.styleable.View_overScrollMode:
						{
							overScrollMode = a.getInt(attr, OVER_SCROLL_IF_CONTENT_SCROLLS);
							break;
						}

						case android.@internal.R.styleable.View_verticalScrollbarPosition:
						{
							mVerticalScrollbarPosition = a.getInt(attr, SCROLLBAR_POSITION_DEFAULT);
							break;
						}

						case android.@internal.R.styleable.View_layerType:
						{
							setLayerType(a.getInt(attr, LAYER_TYPE_NONE), null);
							break;
						}

						case android.@internal.R.styleable.View_textDirection:
						{
							mTextDirection = a.getInt(attr, DEFAULT_TEXT_DIRECTION);
							break;
						}
					}
				}
			}
			a.recycle();
			setOverScrollMode(overScrollMode);
			if (background != null)
			{
				setBackgroundDrawable(background);
			}
			mUserPaddingRelative = (startPadding >= 0 || endPadding >= 0);
			// Cache user padding as we cannot fully resolve padding here (we dont have yet the resolved
			// layout direction). Those cached values will be used later during padding resolution.
			mUserPaddingStart = startPadding;
			mUserPaddingEnd = endPadding;
			if (padding >= 0)
			{
				leftPadding = padding;
				topPadding = padding;
				rightPadding = padding;
				bottomPadding = padding;
			}
			// If the user specified the padding (either with android:padding or
			// android:paddingLeft/Top/Right/Bottom), use this padding, otherwise
			// use the default padding or the padding from the background drawable
			// (stored at this point in mPadding*)
			setPadding(leftPadding >= 0 ? leftPadding : mPaddingLeft, topPadding >= 0 ? topPadding
				 : mPaddingTop, rightPadding >= 0 ? rightPadding : mPaddingRight, bottomPadding 
				>= 0 ? bottomPadding : mPaddingBottom);
			if (viewFlagMasks != 0)
			{
				setFlags(viewFlagValues, viewFlagMasks);
			}
			// Needs to be called after mViewFlags is set
			if (scrollbarStyle != SCROLLBARS_INSIDE_OVERLAY)
			{
				recomputePadding();
			}
			if (x != 0 || y != 0)
			{
				scrollTo(x, y);
			}
			if (transformSet)
			{
				setTranslationX(tx);
				setTranslationY(ty);
				setRotation(rotation);
				setRotationX(rotationX);
				setRotationY(rotationY);
				setScaleX(sx);
				setScaleY(sy);
			}
			if (!setScrollContainer_1 && (viewFlagValues & SCROLLBARS_VERTICAL) != 0)
			{
				setScrollContainer(true);
			}
			computeOpaqueFlags();
		}

		/// <summary>Non-public constructor for use in testing</summary>
		internal View()
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
			mResources = null;
		}

		/// <summary>
		/// <p>
		/// Initializes the fading edges from a given set of styled attributes.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Initializes the fading edges from a given set of styled attributes. This
		/// method should be called by subclasses that need fading edges and when an
		/// instance of these subclasses is created programmatically rather than
		/// being inflated from XML. This method is automatically called when the XML
		/// is inflated.
		/// </p>
		/// </remarks>
		/// <param name="a">the styled attributes set to initialize the fading edges from</param>
		protected internal virtual void initializeFadingEdge(android.content.res.TypedArray
			 a)
		{
			initScrollCache();
			mScrollCache.fadingEdgeLength = a.getDimensionPixelSize(android.@internal.R.styleable
				.View_fadingEdgeLength, android.view.ViewConfiguration.get(mContext).getScaledFadingEdgeLength
				());
		}

		/// <summary>
		/// Returns the size of the vertical faded edges used to indicate that more
		/// content in this view is visible.
		/// </summary>
		/// <remarks>
		/// Returns the size of the vertical faded edges used to indicate that more
		/// content in this view is visible.
		/// </remarks>
		/// <returns>
		/// The size in pixels of the vertical faded edge or 0 if vertical
		/// faded edges are not enabled for this view.
		/// </returns>
		/// <attr>ref android.R.styleable#View_fadingEdgeLength</attr>
		public virtual int getVerticalFadingEdgeLength()
		{
			if (isVerticalFadingEdgeEnabled())
			{
				android.view.View.ScrollabilityCache cache = mScrollCache;
				if (cache != null)
				{
					return cache.fadingEdgeLength;
				}
			}
			return 0;
		}

		/// <summary>
		/// Set the size of the faded edge used to indicate that more content in this
		/// view is available.
		/// </summary>
		/// <remarks>
		/// Set the size of the faded edge used to indicate that more content in this
		/// view is available.  Will not change whether the fading edge is enabled; use
		/// <see cref="setVerticalFadingEdgeEnabled(bool)">setVerticalFadingEdgeEnabled(bool)
		/// 	</see>
		/// or
		/// <see cref="setHorizontalFadingEdgeEnabled(bool)">setHorizontalFadingEdgeEnabled(bool)
		/// 	</see>
		/// to enable the fading edge
		/// for the vertical or horizontal fading edges.
		/// </remarks>
		/// <param name="length">
		/// The size in pixels of the faded edge used to indicate that more
		/// content in this view is visible.
		/// </param>
		public virtual void setFadingEdgeLength(int length)
		{
			initScrollCache();
			mScrollCache.fadingEdgeLength = length;
		}

		/// <summary>
		/// Returns the size of the horizontal faded edges used to indicate that more
		/// content in this view is visible.
		/// </summary>
		/// <remarks>
		/// Returns the size of the horizontal faded edges used to indicate that more
		/// content in this view is visible.
		/// </remarks>
		/// <returns>
		/// The size in pixels of the horizontal faded edge or 0 if horizontal
		/// faded edges are not enabled for this view.
		/// </returns>
		/// <attr>ref android.R.styleable#View_fadingEdgeLength</attr>
		public virtual int getHorizontalFadingEdgeLength()
		{
			if (isHorizontalFadingEdgeEnabled())
			{
				android.view.View.ScrollabilityCache cache = mScrollCache;
				if (cache != null)
				{
					return cache.fadingEdgeLength;
				}
			}
			return 0;
		}

		/// <summary>Returns the width of the vertical scrollbar.</summary>
		/// <remarks>Returns the width of the vertical scrollbar.</remarks>
		/// <returns>
		/// The width in pixels of the vertical scrollbar or 0 if there
		/// is no vertical scrollbar.
		/// </returns>
		public virtual int getVerticalScrollbarWidth()
		{
			android.view.View.ScrollabilityCache cache = mScrollCache;
			if (cache != null)
			{
				android.widget.ScrollBarDrawable scrollBar = cache.scrollBar;
				if (scrollBar != null)
				{
					int size = scrollBar.getSize(true);
					if (size <= 0)
					{
						size = cache.scrollBarSize;
					}
					return size;
				}
				return 0;
			}
			return 0;
		}

		/// <summary>Returns the height of the horizontal scrollbar.</summary>
		/// <remarks>Returns the height of the horizontal scrollbar.</remarks>
		/// <returns>
		/// The height in pixels of the horizontal scrollbar or 0 if
		/// there is no horizontal scrollbar.
		/// </returns>
		protected internal virtual int getHorizontalScrollbarHeight()
		{
			android.view.View.ScrollabilityCache cache = mScrollCache;
			if (cache != null)
			{
				android.widget.ScrollBarDrawable scrollBar = cache.scrollBar;
				if (scrollBar != null)
				{
					int size = scrollBar.getSize(false);
					if (size <= 0)
					{
						size = cache.scrollBarSize;
					}
					return size;
				}
				return 0;
			}
			return 0;
		}

		/// <summary>
		/// <p>
		/// Initializes the scrollbars from a given set of styled attributes.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Initializes the scrollbars from a given set of styled attributes. This
		/// method should be called by subclasses that need scrollbars and when an
		/// instance of these subclasses is created programmatically rather than
		/// being inflated from XML. This method is automatically called when the XML
		/// is inflated.
		/// </p>
		/// </remarks>
		/// <param name="a">the styled attributes set to initialize the scrollbars from</param>
		protected internal virtual void initializeScrollbars(android.content.res.TypedArray
			 a)
		{
			initScrollCache();
			android.view.View.ScrollabilityCache scrollabilityCache = mScrollCache;
			if (scrollabilityCache.scrollBar == null)
			{
				scrollabilityCache.scrollBar = new android.widget.ScrollBarDrawable();
			}
			bool fadeScrollbars = a.getBoolean(android.@internal.R.styleable.View_fadeScrollbars
				, true);
			if (!fadeScrollbars)
			{
				scrollabilityCache.state = android.view.View.ScrollabilityCache.ON;
			}
			scrollabilityCache.fadeScrollBars = fadeScrollbars;
			scrollabilityCache.scrollBarFadeDuration = a.getInt(android.@internal.R.styleable
				.View_scrollbarFadeDuration, android.view.ViewConfiguration.getScrollBarFadeDuration
				());
			scrollabilityCache.scrollBarDefaultDelayBeforeFade = a.getInt(android.@internal.R
				.styleable.View_scrollbarDefaultDelayBeforeFade, android.view.ViewConfiguration.
				getScrollDefaultDelay());
			scrollabilityCache.scrollBarSize = a.getDimensionPixelSize(android.@internal.R.styleable
				.View_scrollbarSize, android.view.ViewConfiguration.get(mContext).getScaledScrollBarSize
				());
			android.graphics.drawable.Drawable track = a.getDrawable(android.@internal.R.styleable
				.View_scrollbarTrackHorizontal);
			scrollabilityCache.scrollBar.setHorizontalTrackDrawable(track);
			android.graphics.drawable.Drawable thumb = a.getDrawable(android.@internal.R.styleable
				.View_scrollbarThumbHorizontal);
			if (thumb != null)
			{
				scrollabilityCache.scrollBar.setHorizontalThumbDrawable(thumb);
			}
			bool alwaysDraw = a.getBoolean(android.@internal.R.styleable.View_scrollbarAlwaysDrawHorizontalTrack
				, false);
			if (alwaysDraw)
			{
				scrollabilityCache.scrollBar.setAlwaysDrawHorizontalTrack(true);
			}
			track = a.getDrawable(android.@internal.R.styleable.View_scrollbarTrackVertical);
			scrollabilityCache.scrollBar.setVerticalTrackDrawable(track);
			thumb = a.getDrawable(android.@internal.R.styleable.View_scrollbarThumbVertical);
			if (thumb != null)
			{
				scrollabilityCache.scrollBar.setVerticalThumbDrawable(thumb);
			}
			alwaysDraw = a.getBoolean(android.@internal.R.styleable.View_scrollbarAlwaysDrawVerticalTrack
				, false);
			if (alwaysDraw)
			{
				scrollabilityCache.scrollBar.setAlwaysDrawVerticalTrack(true);
			}
			// Re-apply user/background padding so that scrollbar(s) get added
			resolvePadding();
		}

		/// <summary>
		/// <p>
		/// Initalizes the scrollability cache if necessary.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Initalizes the scrollability cache if necessary.
		/// </p>
		/// </remarks>
		private void initScrollCache()
		{
			if (mScrollCache == null)
			{
				mScrollCache = new android.view.View.ScrollabilityCache(android.view.ViewConfiguration
					.get(mContext), this);
			}
		}

		/// <summary>Set the position of the vertical scroll bar.</summary>
		/// <remarks>
		/// Set the position of the vertical scroll bar. Should be one of
		/// <see cref="SCROLLBAR_POSITION_DEFAULT">SCROLLBAR_POSITION_DEFAULT</see>
		/// ,
		/// <see cref="SCROLLBAR_POSITION_LEFT">SCROLLBAR_POSITION_LEFT</see>
		/// or
		/// <see cref="SCROLLBAR_POSITION_RIGHT">SCROLLBAR_POSITION_RIGHT</see>
		/// .
		/// </remarks>
		/// <param name="position">Where the vertical scroll bar should be positioned.</param>
		public virtual void setVerticalScrollbarPosition(int position)
		{
			if (mVerticalScrollbarPosition != position)
			{
				mVerticalScrollbarPosition = position;
				computeOpaqueFlags();
				resolvePadding();
			}
		}

		/// <returns>The position where the vertical scroll bar will show, if applicable.</returns>
		/// <seealso cref="setVerticalScrollbarPosition(int)">setVerticalScrollbarPosition(int)
		/// 	</seealso>
		public virtual int getVerticalScrollbarPosition()
		{
			return mVerticalScrollbarPosition;
		}

		/// <summary>Register a callback to be invoked when focus of this view changed.</summary>
		/// <remarks>Register a callback to be invoked when focus of this view changed.</remarks>
		/// <param name="l">The callback that will run.</param>
		public virtual void setOnFocusChangeListener(android.view.View.OnFocusChangeListener
			 l)
		{
			mOnFocusChangeListener = l;
		}

		/// <summary>
		/// Add a listener that will be called when the bounds of the view change due to
		/// layout processing.
		/// </summary>
		/// <remarks>
		/// Add a listener that will be called when the bounds of the view change due to
		/// layout processing.
		/// </remarks>
		/// <param name="listener">The listener that will be called when layout bounds change.
		/// 	</param>
		public virtual void addOnLayoutChangeListener(android.view.View.OnLayoutChangeListener
			 listener)
		{
			if (mOnLayoutChangeListeners == null)
			{
				mOnLayoutChangeListeners = new java.util.ArrayList<android.view.View.OnLayoutChangeListener
					>();
			}
			if (!mOnLayoutChangeListeners.contains(listener))
			{
				mOnLayoutChangeListeners.add(listener);
			}
		}

		/// <summary>Remove a listener for layout changes.</summary>
		/// <remarks>Remove a listener for layout changes.</remarks>
		/// <param name="listener">The listener for layout bounds change.</param>
		public virtual void removeOnLayoutChangeListener(android.view.View.OnLayoutChangeListener
			 listener)
		{
			if (mOnLayoutChangeListeners == null)
			{
				return;
			}
			mOnLayoutChangeListeners.remove(listener);
		}

		/// <summary>Add a listener for attach state changes.</summary>
		/// <remarks>
		/// Add a listener for attach state changes.
		/// This listener will be called whenever this view is attached or detached
		/// from a window. Remove the listener using
		/// <see cref="removeOnAttachStateChangeListener(OnAttachStateChangeListener)">removeOnAttachStateChangeListener(OnAttachStateChangeListener)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="listener">Listener to attach</param>
		/// <seealso cref="removeOnAttachStateChangeListener(OnAttachStateChangeListener)">removeOnAttachStateChangeListener(OnAttachStateChangeListener)
		/// 	</seealso>
		public virtual void addOnAttachStateChangeListener(android.view.View.OnAttachStateChangeListener
			 listener)
		{
			if (mOnAttachStateChangeListeners == null)
			{
				mOnAttachStateChangeListeners = new java.util.concurrent.CopyOnWriteArrayList<android.view.View
					.OnAttachStateChangeListener>();
			}
			mOnAttachStateChangeListeners.add(listener);
		}

		/// <summary>Remove a listener for attach state changes.</summary>
		/// <remarks>
		/// Remove a listener for attach state changes. The listener will receive no further
		/// notification of window attach/detach events.
		/// </remarks>
		/// <param name="listener">Listener to remove</param>
		/// <seealso cref="addOnAttachStateChangeListener(OnAttachStateChangeListener)">addOnAttachStateChangeListener(OnAttachStateChangeListener)
		/// 	</seealso>
		public virtual void removeOnAttachStateChangeListener(android.view.View.OnAttachStateChangeListener
			 listener)
		{
			if (mOnAttachStateChangeListeners == null)
			{
				return;
			}
			mOnAttachStateChangeListeners.remove(listener);
		}

		/// <summary>Returns the focus-change callback registered for this view.</summary>
		/// <remarks>Returns the focus-change callback registered for this view.</remarks>
		/// <returns>The callback, or null if one is not registered.</returns>
		public virtual android.view.View.OnFocusChangeListener getOnFocusChangeListener()
		{
			return mOnFocusChangeListener;
		}

		/// <summary>Register a callback to be invoked when this view is clicked.</summary>
		/// <remarks>
		/// Register a callback to be invoked when this view is clicked. If this view is not
		/// clickable, it becomes clickable.
		/// </remarks>
		/// <param name="l">The callback that will run</param>
		/// <seealso cref="setClickable(bool)">setClickable(bool)</seealso>
		public virtual void setOnClickListener(android.view.View.OnClickListener l)
		{
			if (!isClickable())
			{
				setClickable(true);
			}
			mOnClickListener = l;
		}

		/// <summary>Register a callback to be invoked when this view is clicked and held.</summary>
		/// <remarks>
		/// Register a callback to be invoked when this view is clicked and held. If this view is not
		/// long clickable, it becomes long clickable.
		/// </remarks>
		/// <param name="l">The callback that will run</param>
		/// <seealso cref="setLongClickable(bool)">setLongClickable(bool)</seealso>
		public virtual void setOnLongClickListener(android.view.View.OnLongClickListener 
			l)
		{
			if (!isLongClickable())
			{
				setLongClickable(true);
			}
			mOnLongClickListener = l;
		}

		/// <summary>
		/// Register a callback to be invoked when the context menu for this view is
		/// being built.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when the context menu for this view is
		/// being built. If this view is not long clickable, it becomes long clickable.
		/// </remarks>
		/// <param name="l">The callback that will run</param>
		public virtual void setOnCreateContextMenuListener(android.view.View.OnCreateContextMenuListener
			 l)
		{
			if (!isLongClickable())
			{
				setLongClickable(true);
			}
			mOnCreateContextMenuListener = l;
		}

		/// <summary>Call this view's OnClickListener, if it is defined.</summary>
		/// <remarks>Call this view's OnClickListener, if it is defined.</remarks>
		/// <returns>
		/// True there was an assigned OnClickListener that was called, false
		/// otherwise is returned.
		/// </returns>
		public virtual bool performClick()
		{
			sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_CLICKED
				);
			if (mOnClickListener != null)
			{
				playSoundEffect(android.view.SoundEffectConstants.CLICK);
				mOnClickListener.onClick(this);
				return true;
			}
			return false;
		}

		/// <summary>Call this view's OnLongClickListener, if it is defined.</summary>
		/// <remarks>
		/// Call this view's OnLongClickListener, if it is defined. Invokes the context menu if the
		/// OnLongClickListener did not consume the event.
		/// </remarks>
		/// <returns>True if one of the above receivers consumed the event, false otherwise.</returns>
		public virtual bool performLongClick()
		{
			sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_LONG_CLICKED
				);
			bool handled = false;
			if (mOnLongClickListener != null)
			{
				handled = mOnLongClickListener.onLongClick(this);
			}
			if (!handled)
			{
				handled = showContextMenu();
			}
			if (handled)
			{
				performHapticFeedback(android.view.HapticFeedbackConstants.LONG_PRESS);
			}
			return handled;
		}

		/// <summary>Performs button-related actions during a touch down event.</summary>
		/// <remarks>Performs button-related actions during a touch down event.</remarks>
		/// <param name="event">The event.</param>
		/// <returns>True if the down was consumed.</returns>
		/// <hide></hide>
		protected internal virtual bool performButtonActionOnTouchDown(android.view.MotionEvent
			 @event)
		{
			if ((@event.getButtonState() & android.view.MotionEvent.BUTTON_SECONDARY) != 0)
			{
				if (showContextMenu(@event.getX(), @event.getY(), @event.getMetaState()))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Bring up the context menu for this view.</summary>
		/// <remarks>Bring up the context menu for this view.</remarks>
		/// <returns>Whether a context menu was displayed.</returns>
		public virtual bool showContextMenu()
		{
			return getParent().showContextMenuForChild(this);
		}

		/// <summary>Bring up the context menu for this view, referring to the item under the specified point.
		/// 	</summary>
		/// <remarks>Bring up the context menu for this view, referring to the item under the specified point.
		/// 	</remarks>
		/// <param name="x">The referenced x coordinate.</param>
		/// <param name="y">The referenced y coordinate.</param>
		/// <param name="metaState">The keyboard modifiers that were pressed.</param>
		/// <returns>Whether a context menu was displayed.</returns>
		/// <hide></hide>
		public virtual bool showContextMenu(float x, float y, int metaState)
		{
			return showContextMenu();
		}

		/// <summary>Start an action mode.</summary>
		/// <remarks>Start an action mode.</remarks>
		/// <param name="callback">Callback that will control the lifecycle of the action mode
		/// 	</param>
		/// <returns>The new action mode if it is started, null otherwise</returns>
		/// <seealso cref="ActionMode">ActionMode</seealso>
		public virtual android.view.ActionMode startActionMode(android.view.ActionMode.Callback
			 callback)
		{
			return getParent().startActionModeForChild(this, callback);
		}

		/// <summary>Register a callback to be invoked when a key is pressed in this view.</summary>
		/// <remarks>Register a callback to be invoked when a key is pressed in this view.</remarks>
		/// <param name="l">the key listener to attach to this view</param>
		public virtual void setOnKeyListener(android.view.View.OnKeyListener l)
		{
			mOnKeyListener = l;
		}

		/// <summary>Register a callback to be invoked when a touch event is sent to this view.
		/// 	</summary>
		/// <remarks>Register a callback to be invoked when a touch event is sent to this view.
		/// 	</remarks>
		/// <param name="l">the touch listener to attach to this view</param>
		public virtual void setOnTouchListener(android.view.View.OnTouchListener l)
		{
			mOnTouchListener = l;
		}

		/// <summary>Register a callback to be invoked when a generic motion event is sent to this view.
		/// 	</summary>
		/// <remarks>Register a callback to be invoked when a generic motion event is sent to this view.
		/// 	</remarks>
		/// <param name="l">the generic motion listener to attach to this view</param>
		public virtual void setOnGenericMotionListener(android.view.View.OnGenericMotionListener
			 l)
		{
			mOnGenericMotionListener = l;
		}

		/// <summary>Register a callback to be invoked when a hover event is sent to this view.
		/// 	</summary>
		/// <remarks>Register a callback to be invoked when a hover event is sent to this view.
		/// 	</remarks>
		/// <param name="l">the hover listener to attach to this view</param>
		public virtual void setOnHoverListener(android.view.View.OnHoverListener l)
		{
			mOnHoverListener = l;
		}

		/// <summary>Register a drag event listener callback object for this View.</summary>
		/// <remarks>
		/// Register a drag event listener callback object for this View. The parameter is
		/// an implementation of
		/// <see cref="OnDragListener">OnDragListener</see>
		/// . To send a drag event to a
		/// View, the system calls the
		/// <see cref="OnDragListener.onDrag(View, DragEvent)">OnDragListener.onDrag(View, DragEvent)
		/// 	</see>
		/// method.
		/// </remarks>
		/// <param name="l">
		/// An implementation of
		/// <see cref="OnDragListener">OnDragListener</see>
		/// .
		/// </param>
		public virtual void setOnDragListener(android.view.View.OnDragListener l)
		{
			mOnDragListener = l;
		}

		/// <summary>Give this view focus.</summary>
		/// <remarks>
		/// Give this view focus. This will cause
		/// <see cref="onFocusChanged(bool, int, android.graphics.Rect)">onFocusChanged(bool, int, android.graphics.Rect)
		/// 	</see>
		/// to be called.
		/// Note: this does not check whether this
		/// <see cref="View">View</see>
		/// should get focus, it just
		/// gives it focus no matter what.  It should only be called internally by framework
		/// code that knows what it is doing, namely
		/// <see cref="requestFocus(int, android.graphics.Rect)">requestFocus(int, android.graphics.Rect)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="direction">
		/// values are
		/// <see cref="FOCUS_UP">FOCUS_UP</see>
		/// ,
		/// <see cref="FOCUS_DOWN">FOCUS_DOWN</see>
		/// ,
		/// <see cref="FOCUS_LEFT">FOCUS_LEFT</see>
		/// or
		/// <see cref="FOCUS_RIGHT">FOCUS_RIGHT</see>
		/// . This is the direction which
		/// focus moved when requestFocus() is called. It may not always
		/// apply, in which case use the default View.FOCUS_DOWN.
		/// </param>
		/// <param name="previouslyFocusedRect">
		/// The rectangle of the view that had focus
		/// prior in this View's coordinate system.
		/// </param>
		internal virtual void handleFocusGainInternal(int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			if ((mPrivateFlags & FOCUSED) == 0)
			{
				mPrivateFlags |= FOCUSED;
				if (mParent != null)
				{
					mParent.requestChildFocus(this, this);
				}
				onFocusChanged(true, direction, previouslyFocusedRect);
				refreshDrawableState();
			}
		}

		/// <summary>
		/// Request that a rectangle of this view be visible on the screen,
		/// scrolling if necessary just enough.
		/// </summary>
		/// <remarks>
		/// Request that a rectangle of this view be visible on the screen,
		/// scrolling if necessary just enough.
		/// <p>A View should call this if it maintains some notion of which part
		/// of its content is interesting.  For example, a text editing view
		/// should call this when its cursor moves.
		/// </remarks>
		/// <param name="rectangle">The rectangle.</param>
		/// <returns>Whether any parent scrolled.</returns>
		public virtual bool requestRectangleOnScreen(android.graphics.Rect rectangle)
		{
			return requestRectangleOnScreen(rectangle, false);
		}

		/// <summary>
		/// Request that a rectangle of this view be visible on the screen,
		/// scrolling if necessary just enough.
		/// </summary>
		/// <remarks>
		/// Request that a rectangle of this view be visible on the screen,
		/// scrolling if necessary just enough.
		/// <p>A View should call this if it maintains some notion of which part
		/// of its content is interesting.  For example, a text editing view
		/// should call this when its cursor moves.
		/// <p>When <code>immediate</code> is set to true, scrolling will not be
		/// animated.
		/// </remarks>
		/// <param name="rectangle">The rectangle.</param>
		/// <param name="immediate">True to forbid animated scrolling, false otherwise</param>
		/// <returns>Whether any parent scrolled.</returns>
		public virtual bool requestRectangleOnScreen(android.graphics.Rect rectangle, bool
			 immediate)
		{
			android.view.View child = this;
			android.view.ViewParent parent = mParent;
			bool scrolled = false;
			while (parent != null)
			{
				scrolled |= parent.requestChildRectangleOnScreen(child, rectangle, immediate);
				// offset rect so next call has the rectangle in the
				// coordinate system of its direct child.
				rectangle.offset(child.getLeft(), child.getTop());
				rectangle.offset(-child.getScrollX(), -child.getScrollY());
				if (!(parent is android.view.View))
				{
					break;
				}
				child = (android.view.View)parent;
				parent = child.getParent();
			}
			return scrolled;
		}

		/// <summary>Called when this view wants to give up focus.</summary>
		/// <remarks>
		/// Called when this view wants to give up focus. This will cause
		/// <see cref="onFocusChanged(bool, int, android.graphics.Rect)">onFocusChanged(bool, int, android.graphics.Rect)
		/// 	</see>
		/// to be called.
		/// </remarks>
		public virtual void clearFocus()
		{
			if ((mPrivateFlags & FOCUSED) != 0)
			{
				mPrivateFlags &= ~FOCUSED;
				if (mParent != null)
				{
					mParent.clearChildFocus(this);
				}
				onFocusChanged(false, 0, null);
				refreshDrawableState();
			}
		}

		/// <summary>Called to clear the focus of a view that is about to be removed.</summary>
		/// <remarks>
		/// Called to clear the focus of a view that is about to be removed.
		/// Doesn't call clearChildFocus, which prevents this view from taking
		/// focus again before it has been removed from the parent
		/// </remarks>
		internal virtual void clearFocusForRemoval()
		{
			if ((mPrivateFlags & FOCUSED) != 0)
			{
				mPrivateFlags &= ~FOCUSED;
				onFocusChanged(false, 0, null);
				refreshDrawableState();
			}
		}

		/// <summary>Called internally by the view system when a new view is getting focus.</summary>
		/// <remarks>
		/// Called internally by the view system when a new view is getting focus.
		/// This is what clears the old focus.
		/// </remarks>
		internal virtual void unFocus()
		{
			if ((mPrivateFlags & FOCUSED) != 0)
			{
				mPrivateFlags &= ~FOCUSED;
				onFocusChanged(false, 0, null);
				refreshDrawableState();
			}
		}

		/// <summary>
		/// Returns true if this view has focus iteself, or is the ancestor of the
		/// view that has focus.
		/// </summary>
		/// <remarks>
		/// Returns true if this view has focus iteself, or is the ancestor of the
		/// view that has focus.
		/// </remarks>
		/// <returns>True if this view has or contains focus, false otherwise.</returns>
		public virtual bool hasFocus()
		{
			return (mPrivateFlags & FOCUSED) != 0;
		}

		/// <summary>
		/// Returns true if this view is focusable or if it contains a reachable View
		/// for which
		/// <see cref="hasFocusable()">hasFocusable()</see>
		/// returns true. A "reachable hasFocusable()"
		/// is a View whose parents do not block descendants focus.
		/// Only
		/// <see cref="VISIBLE">VISIBLE</see>
		/// views are considered focusable.
		/// </summary>
		/// <returns>
		/// True if the view is focusable or if the view contains a focusable
		/// View, false otherwise.
		/// </returns>
		/// <seealso cref="ViewGroup.FOCUS_BLOCK_DESCENDANTS">ViewGroup.FOCUS_BLOCK_DESCENDANTS
		/// 	</seealso>
		public virtual bool hasFocusable()
		{
			return (mViewFlags & VISIBILITY_MASK) == VISIBLE && isFocusable();
		}

		/// <summary>Called by the view system when the focus state of this view changes.</summary>
		/// <remarks>
		/// Called by the view system when the focus state of this view changes.
		/// When the focus change event is caused by directional navigation, direction
		/// and previouslyFocusedRect provide insight into where the focus is coming from.
		/// When overriding, be sure to call up through to the super class so that
		/// the standard focus handling will occur.
		/// </remarks>
		/// <param name="gainFocus">True if the View has focus; false otherwise.</param>
		/// <param name="direction">
		/// The direction focus has moved when requestFocus()
		/// is called to give this view focus. Values are
		/// <see cref="FOCUS_UP">FOCUS_UP</see>
		/// ,
		/// <see cref="FOCUS_DOWN">FOCUS_DOWN</see>
		/// ,
		/// <see cref="FOCUS_LEFT">FOCUS_LEFT</see>
		/// ,
		/// <see cref="FOCUS_RIGHT">FOCUS_RIGHT</see>
		/// ,
		/// <see cref="FOCUS_FORWARD">FOCUS_FORWARD</see>
		/// , or
		/// <see cref="FOCUS_BACKWARD">FOCUS_BACKWARD</see>
		/// .
		/// It may not always apply, in which case use the default.
		/// </param>
		/// <param name="previouslyFocusedRect">
		/// The rectangle, in this view's coordinate
		/// system, of the previously focused view.  If applicable, this will be
		/// passed in as finer grained information about where the focus is coming
		/// from (in addition to direction).  Will be <code>null</code> otherwise.
		/// </param>
		protected internal virtual void onFocusChanged(bool gainFocus, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			if (gainFocus)
			{
				sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_FOCUSED
					);
			}
			android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
				.peekInstance();
			if (!gainFocus)
			{
				if (isPressed())
				{
					setPressed(false);
				}
				if (imm != null && mAttachInfo != null && mAttachInfo.mHasWindowFocus)
				{
					imm.focusOut(this);
				}
				onFocusLost();
			}
			else
			{
				if (imm != null && mAttachInfo != null && mAttachInfo.mHasWindowFocus)
				{
					imm.focusIn(this);
				}
			}
			invalidate(true);
			if (mOnFocusChangeListener != null)
			{
				mOnFocusChangeListener.onFocusChange(this, gainFocus);
			}
			if (mAttachInfo != null)
			{
				mAttachInfo.mKeyDispatchState.reset(this);
			}
		}

		/// <summary>Sends an accessibility event of the given type.</summary>
		/// <remarks>
		/// Sends an accessibility event of the given type. If accessiiblity is
		/// not enabled this method has no effect. The default implementation calls
		/// <see cref="onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)</see>
		/// first
		/// to populate information about the event source (this View), then calls
		/// <see cref="dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// to
		/// populate the text content of the event source including its descendants,
		/// and last calls
		/// <see cref="ViewParent.requestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	">ViewParent.requestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// on its parent to resuest sending of the event to interested parties.
		/// <p>
		/// If an
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// has been specified via calling
		/// <see cref="setAccessibilityDelegate(AccessibilityDelegate)">setAccessibilityDelegate(AccessibilityDelegate)
		/// 	</see>
		/// its
		/// <see cref="AccessibilityDelegate.sendAccessibilityEvent(View, int)">AccessibilityDelegate.sendAccessibilityEvent(View, int)
		/// 	</see>
		/// is
		/// responsible for handling this call.
		/// </p>
		/// </remarks>
		/// <param name="eventType">
		/// The type of the event to send, as defined by several types from
		/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
		/// 	</see>
		/// , such as
		/// <see cref="android.view.accessibility.AccessibilityEvent.TYPE_VIEW_CLICKED">android.view.accessibility.AccessibilityEvent.TYPE_VIEW_CLICKED
		/// 	</see>
		/// or
		/// <see cref="android.view.accessibility.AccessibilityEvent.TYPE_VIEW_HOVER_ENTER">android.view.accessibility.AccessibilityEvent.TYPE_VIEW_HOVER_ENTER
		/// 	</see>
		/// .
		/// </param>
		/// <seealso cref="onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)</seealso>
		/// <seealso cref="dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	</seealso>
		/// <seealso cref="ViewParent.requestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	">ViewParent.requestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	</seealso>
		/// <seealso cref="AccessibilityDelegate">AccessibilityDelegate</seealso>
		[Sharpen.ImplementsInterface(@"android.view.accessibility.AccessibilityEventSource"
			)]
		public virtual void sendAccessibilityEvent(int eventType)
		{
			if (mAccessibilityDelegate != null)
			{
				mAccessibilityDelegate.sendAccessibilityEvent(this, eventType);
			}
			else
			{
				sendAccessibilityEventInternal(eventType);
			}
		}

		/// <seealso cref="sendAccessibilityEvent(int)">
		/// Note: Called from the default
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </seealso>
		internal virtual void sendAccessibilityEventInternal(int eventType)
		{
			if (android.view.accessibility.AccessibilityManager.getInstance(mContext).isEnabled
				())
			{
				sendAccessibilityEventUnchecked(android.view.accessibility.AccessibilityEvent.obtain
					(eventType));
			}
		}

		/// <summary>
		/// This method behaves exactly as
		/// <see cref="sendAccessibilityEvent(int)">sendAccessibilityEvent(int)</see>
		/// but
		/// takes as an argument an empty
		/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
		/// 	</see>
		/// and does not
		/// perform a check whether accessibility is enabled.
		/// <p>
		/// If an
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// has been specified via calling
		/// <see cref="setAccessibilityDelegate(AccessibilityDelegate)">setAccessibilityDelegate(AccessibilityDelegate)
		/// 	</see>
		/// its
		/// <see cref="AccessibilityDelegate.sendAccessibilityEventUnchecked(View, android.view.accessibility.AccessibilityEvent)
		/// 	">AccessibilityDelegate.sendAccessibilityEventUnchecked(View, android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// is responsible for handling this call.
		/// </p>
		/// </summary>
		/// <param name="event">The event to send.</param>
		/// <seealso cref="sendAccessibilityEvent(int)">sendAccessibilityEvent(int)</seealso>
		[Sharpen.ImplementsInterface(@"android.view.accessibility.AccessibilityEventSource"
			)]
		public virtual void sendAccessibilityEventUnchecked(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (mAccessibilityDelegate != null)
			{
				mAccessibilityDelegate.sendAccessibilityEventUnchecked(this, @event);
			}
			else
			{
				sendAccessibilityEventUncheckedInternal(@event);
			}
		}

		/// <seealso cref="sendAccessibilityEventUnchecked(android.view.accessibility.AccessibilityEvent)
		/// 	">
		/// Note: Called from the default
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </seealso>
		internal virtual void sendAccessibilityEventUncheckedInternal(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (!isShown())
			{
				return;
			}
			onInitializeAccessibilityEvent(@event);
			// Only a subset of accessibility events populates text content.
			if ((@event.getEventType() & POPULATING_ACCESSIBILITY_EVENT_TYPES) != 0)
			{
				dispatchPopulateAccessibilityEvent(@event);
			}
			// In the beginning we called #isShown(), so we know that getParent() is not null.
			getParent().requestSendAccessibilityEvent(this, @event);
		}

		/// <summary>
		/// Dispatches an
		/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
		/// 	</see>
		/// to the
		/// <see cref="View">View</see>
		/// first and then
		/// to its children for adding their text content to the event. Note that the
		/// event text is populated in a separate dispatch path since we add to the
		/// event not only the text of the source but also the text of all its descendants.
		/// A typical implementation will call
		/// <see cref="onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)</see>
		/// on the this view
		/// and then call the
		/// <see cref="dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// on each child. Override this method if custom population of the event text
		/// content is required.
		/// <p>
		/// If an
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// has been specified via calling
		/// <see cref="setAccessibilityDelegate(AccessibilityDelegate)">setAccessibilityDelegate(AccessibilityDelegate)
		/// 	</see>
		/// its
		/// <see cref="AccessibilityDelegate.dispatchPopulateAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	">AccessibilityDelegate.dispatchPopulateAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// is responsible for handling this call.
		/// </p>
		/// <p>
		/// <em>Note:</em> Accessibility events of certain types are not dispatched for
		/// populating the event text via this method. For details refer to
		/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
		/// 	</see>
		/// .
		/// </p>
		/// </summary>
		/// <param name="event">The event.</param>
		/// <returns>True if the event population was completed.</returns>
		public virtual bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (mAccessibilityDelegate != null)
			{
				return mAccessibilityDelegate.dispatchPopulateAccessibilityEvent(this, @event);
			}
			else
			{
				return dispatchPopulateAccessibilityEventInternal(@event);
			}
		}

		/// <seealso cref="dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">
		/// Note: Called from the default
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </seealso>
		internal virtual bool dispatchPopulateAccessibilityEventInternal(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			onPopulateAccessibilityEvent(@event);
			return false;
		}

		/// <summary>
		/// Called from
		/// <see cref="dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// giving a chance to this View to populate the accessibility event with its
		/// text content. While this method is free to modify event
		/// attributes other than text content, doing so should normally be performed in
		/// <see cref="onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)</see>
		/// .
		/// <p>
		/// Example: Adding formatted date string to an accessibility event in addition
		/// to the text added by the super implementation:
		/// <pre> public void onPopulateAccessibilityEvent(AccessibilityEvent event) {
		/// super.onPopulateAccessibilityEvent(event);
		/// final int flags = DateUtils.FORMAT_SHOW_DATE | DateUtils.FORMAT_SHOW_WEEKDAY;
		/// String selectedDateUtterance = DateUtils.formatDateTime(mContext,
		/// mCurrentDate.getTimeInMillis(), flags);
		/// event.getText().add(selectedDateUtterance);
		/// }</pre>
		/// <p>
		/// If an
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// has been specified via calling
		/// <see cref="setAccessibilityDelegate(AccessibilityDelegate)">setAccessibilityDelegate(AccessibilityDelegate)
		/// 	</see>
		/// its
		/// <see cref="AccessibilityDelegate.onPopulateAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	">AccessibilityDelegate.onPopulateAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// is responsible for handling this call.
		/// </p>
		/// <p class="note"><strong>Note:</strong> Always call the super implementation before adding
		/// information to the event, in case the default implementation has basic information to add.
		/// </p>
		/// </summary>
		/// <param name="event">The accessibility event which to populate.</param>
		/// <seealso cref="sendAccessibilityEvent(int)">sendAccessibilityEvent(int)</seealso>
		/// <seealso cref="dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	</seealso>
		public virtual void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (mAccessibilityDelegate != null)
			{
				mAccessibilityDelegate.onPopulateAccessibilityEvent(this, @event);
			}
			else
			{
				onPopulateAccessibilityEventInternal(@event);
			}
		}

		/// <seealso cref="onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">
		/// Note: Called from the default
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </seealso>
		internal virtual void onPopulateAccessibilityEventInternal(android.view.accessibility.AccessibilityEvent
			 @event)
		{
		}

		/// <summary>
		/// Initializes an
		/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
		/// 	</see>
		/// with information about
		/// this View which is the event source. In other words, the source of
		/// an accessibility event is the view whose state change triggered firing
		/// the event.
		/// <p>
		/// Example: Setting the password property of an event in addition
		/// to properties set by the super implementation:
		/// <pre> public void onInitializeAccessibilityEvent(AccessibilityEvent event) {
		/// super.onInitializeAccessibilityEvent(event);
		/// event.setPassword(true);
		/// }</pre>
		/// <p>
		/// If an
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// has been specified via calling
		/// <see cref="setAccessibilityDelegate(AccessibilityDelegate)">setAccessibilityDelegate(AccessibilityDelegate)
		/// 	</see>
		/// its
		/// <see cref="AccessibilityDelegate.onInitializeAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	">AccessibilityDelegate.onInitializeAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
		/// 	</see>
		/// is responsible for handling this call.
		/// </p>
		/// <p class="note"><strong>Note:</strong> Always call the super implementation before adding
		/// information to the event, in case the default implementation has basic information to add.
		/// </p>
		/// </summary>
		/// <param name="event">The event to initialize.</param>
		/// <seealso cref="sendAccessibilityEvent(int)">sendAccessibilityEvent(int)</seealso>
		/// <seealso cref="dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	</seealso>
		public virtual void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (mAccessibilityDelegate != null)
			{
				mAccessibilityDelegate.onInitializeAccessibilityEvent(this, @event);
			}
			else
			{
				onInitializeAccessibilityEventInternal(@event);
			}
		}

		/// <seealso cref="onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
		/// 	">
		/// Note: Called from the default
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </seealso>
		internal virtual void onInitializeAccessibilityEventInternal(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			@event.setSource(this);
			@event.setClassName(java.lang.CharSequenceProxy.Wrap(GetType().FullName));
			@event.setPackageName(java.lang.CharSequenceProxy.Wrap(getContext().getPackageName
				()));
			@event.setEnabled(isEnabled());
			@event.setContentDescription(mContentDescription);
			if (@event.getEventType() == android.view.accessibility.AccessibilityEvent.TYPE_VIEW_FOCUSED
				 && mAttachInfo != null)
			{
				java.util.ArrayList<android.view.View> focusablesTempList = mAttachInfo.mFocusablesTempList;
				getRootView().addFocusables(focusablesTempList, android.view.View.FOCUS_FORWARD, 
					FOCUSABLES_ALL);
				@event.setItemCount(focusablesTempList.size());
				@event.setCurrentItemIndex(focusablesTempList.indexOf(this));
				focusablesTempList.clear();
			}
		}

		/// <summary>
		/// Returns an
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo">android.view.accessibility.AccessibilityNodeInfo
		/// 	</see>
		/// representing this view from the
		/// point of view of an
		/// <see cref="android.accessibilityservice.AccessibilityService">android.accessibilityservice.AccessibilityService
		/// 	</see>
		/// .
		/// This method is responsible for obtaining an accessibility node info from a
		/// pool of reusable instances and calling
		/// <see cref="onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
		/// 	">onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
		/// 	</see>
		/// on this view to
		/// initialize the former.
		/// <p>
		/// Note: The client is responsible for recycling the obtained instance by calling
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.recycle()">android.view.accessibility.AccessibilityNodeInfo.recycle()
		/// 	</see>
		/// to minimize object creation.
		/// </p>
		/// </summary>
		/// <returns>
		/// A populated
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo">android.view.accessibility.AccessibilityNodeInfo
		/// 	</see>
		/// .
		/// </returns>
		/// <seealso cref="android.view.accessibility.AccessibilityNodeInfo">android.view.accessibility.AccessibilityNodeInfo
		/// 	</seealso>
		public virtual android.view.accessibility.AccessibilityNodeInfo createAccessibilityNodeInfo
			()
		{
			android.view.accessibility.AccessibilityNodeInfo info = android.view.accessibility.AccessibilityNodeInfo
				.obtain(this);
			onInitializeAccessibilityNodeInfo(info);
			return info;
		}

		/// <summary>
		/// Initializes an
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo">android.view.accessibility.AccessibilityNodeInfo
		/// 	</see>
		/// with information about this view.
		/// The base implementation sets:
		/// <ul>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setParent(View)">android.view.accessibility.AccessibilityNodeInfo.setParent(View)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setBoundsInParent(android.graphics.Rect)
		/// 	">android.view.accessibility.AccessibilityNodeInfo.setBoundsInParent(android.graphics.Rect)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setBoundsInScreen(android.graphics.Rect)
		/// 	">android.view.accessibility.AccessibilityNodeInfo.setBoundsInScreen(android.graphics.Rect)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setPackageName(java.lang.CharSequence)
		/// 	">android.view.accessibility.AccessibilityNodeInfo.setPackageName(java.lang.CharSequence)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setClassName(java.lang.CharSequence)
		/// 	">android.view.accessibility.AccessibilityNodeInfo.setClassName(java.lang.CharSequence)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setContentDescription(java.lang.CharSequence)
		/// 	">android.view.accessibility.AccessibilityNodeInfo.setContentDescription(java.lang.CharSequence)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setEnabled(bool)">android.view.accessibility.AccessibilityNodeInfo.setEnabled(bool)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setClickable(bool)">android.view.accessibility.AccessibilityNodeInfo.setClickable(bool)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setFocusable(bool)">android.view.accessibility.AccessibilityNodeInfo.setFocusable(bool)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setFocused(bool)">android.view.accessibility.AccessibilityNodeInfo.setFocused(bool)
		/// 	</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setLongClickable(bool)
		/// 	">android.view.accessibility.AccessibilityNodeInfo.setLongClickable(bool)</see>
		/// ,</li>
		/// <li>
		/// <see cref="android.view.accessibility.AccessibilityNodeInfo.setSelected(bool)">android.view.accessibility.AccessibilityNodeInfo.setSelected(bool)
		/// 	</see>
		/// ,</li>
		/// </ul>
		/// <p>
		/// Subclasses should override this method, call the super implementation,
		/// and set additional attributes.
		/// </p>
		/// <p>
		/// If an
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// has been specified via calling
		/// <see cref="setAccessibilityDelegate(AccessibilityDelegate)">setAccessibilityDelegate(AccessibilityDelegate)
		/// 	</see>
		/// its
		/// <see cref="AccessibilityDelegate.onInitializeAccessibilityNodeInfo(View, android.view.accessibility.AccessibilityNodeInfo)
		/// 	">AccessibilityDelegate.onInitializeAccessibilityNodeInfo(View, android.view.accessibility.AccessibilityNodeInfo)
		/// 	</see>
		/// is responsible for handling this call.
		/// </p>
		/// </summary>
		/// <param name="info">The instance to initialize.</param>
		public virtual void onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			if (mAccessibilityDelegate != null)
			{
				mAccessibilityDelegate.onInitializeAccessibilityNodeInfo(this, info);
			}
			else
			{
				onInitializeAccessibilityNodeInfoInternal(info);
			}
		}

		/// <seealso cref="onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
		/// 	">
		/// Note: Called from the default
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </seealso>
		internal virtual void onInitializeAccessibilityNodeInfoInternal(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			android.graphics.Rect bounds = mAttachInfo.mTmpInvalRect;
			getDrawingRect(bounds);
			info.setBoundsInParent(bounds);
			int[] locationOnScreen = mAttachInfo.mInvalidateChildLocation;
			getLocationOnScreen(locationOnScreen);
			bounds.offsetTo(0, 0);
			bounds.offset(locationOnScreen[0], locationOnScreen[1]);
			info.setBoundsInScreen(bounds);
			android.view.ViewParent parent = getParent();
			if (parent is android.view.View)
			{
				android.view.View parentView = (android.view.View)parent;
				info.setParent(parentView);
			}
			info.setPackageName(java.lang.CharSequenceProxy.Wrap(mContext.getPackageName()));
			info.setClassName(java.lang.CharSequenceProxy.Wrap(GetType().FullName));
			info.setContentDescription(getContentDescription());
			info.setEnabled(isEnabled());
			info.setClickable(isClickable());
			info.setFocusable(isFocusable());
			info.setFocused(isFocused());
			info.setSelected(isSelected());
			info.setLongClickable(isLongClickable());
			// TODO: These make sense only if we are in an AdapterView but all
			// views can be selected. Maybe from accessiiblity perspective
			// we should report as selectable view in an AdapterView.
			info.addAction(android.view.accessibility.AccessibilityNodeInfo.ACTION_SELECT);
			info.addAction(android.view.accessibility.AccessibilityNodeInfo.ACTION_CLEAR_SELECTION
				);
			if (isFocusable())
			{
				if (isFocused())
				{
					info.addAction(android.view.accessibility.AccessibilityNodeInfo.ACTION_CLEAR_FOCUS
						);
				}
				else
				{
					info.addAction(android.view.accessibility.AccessibilityNodeInfo.ACTION_FOCUS);
				}
			}
		}

		/// <summary>
		/// Sets a delegate for implementing accessibility support via compositon as
		/// opposed to inheritance.
		/// </summary>
		/// <remarks>
		/// Sets a delegate for implementing accessibility support via compositon as
		/// opposed to inheritance. The delegate's primary use is for implementing
		/// backwards compatible widgets. For more details see
		/// <see cref="AccessibilityDelegate">AccessibilityDelegate</see>
		/// .
		/// </remarks>
		/// <param name="delegate">The delegate instance.</param>
		/// <seealso cref="AccessibilityDelegate">AccessibilityDelegate</seealso>
		public virtual void setAccessibilityDelegate(android.view.View.AccessibilityDelegate
			 @delegate)
		{
			mAccessibilityDelegate = @delegate;
		}

		/// <summary>Gets the unique identifier of this view on the screen for accessibility purposes.
		/// 	</summary>
		/// <remarks>
		/// Gets the unique identifier of this view on the screen for accessibility purposes.
		/// If this
		/// <see cref="View">View</see>
		/// is not attached to any window,
		/// <value>#NO_ID</value>
		/// is returned.
		/// </remarks>
		/// <returns>The view accessibility id.</returns>
		/// <hide></hide>
		public virtual int getAccessibilityViewId()
		{
			if (mAccessibilityViewId == NO_ID)
			{
				mAccessibilityViewId = sNextAccessibilityViewId++;
			}
			return mAccessibilityViewId;
		}

		/// <summary>Gets the unique identifier of the window in which this View reseides.</summary>
		/// <remarks>Gets the unique identifier of the window in which this View reseides.</remarks>
		/// <returns>The window accessibility id.</returns>
		/// <hide></hide>
		public virtual int getAccessibilityWindowId()
		{
			return mAttachInfo != null ? mAttachInfo.mAccessibilityWindowId : NO_ID;
		}

		/// <summary>
		/// Gets the
		/// <see cref="View">View</see>
		/// description. It briefly describes the view and is
		/// primarily used for accessibility support. Set this property to enable
		/// better accessibility support for your application. This is especially
		/// true for views that do not have textual representation (For example,
		/// ImageButton).
		/// </summary>
		/// <returns>The content descriptiopn.</returns>
		/// <attr>ref android.R.styleable#View_contentDescription</attr>
		public virtual java.lang.CharSequence getContentDescription()
		{
			return mContentDescription;
		}

		/// <summary>
		/// Sets the
		/// <see cref="View">View</see>
		/// description. It briefly describes the view and is
		/// primarily used for accessibility support. Set this property to enable
		/// better accessibility support for your application. This is especially
		/// true for views that do not have textual representation (For example,
		/// ImageButton).
		/// </summary>
		/// <param name="contentDescription">The content description.</param>
		/// <attr>ref android.R.styleable#View_contentDescription</attr>
		public virtual void setContentDescription(java.lang.CharSequence contentDescription
			)
		{
			mContentDescription = contentDescription;
		}

		/// <summary>
		/// Invoked whenever this view loses focus, either by losing window focus or by losing
		/// focus within its window.
		/// </summary>
		/// <remarks>
		/// Invoked whenever this view loses focus, either by losing window focus or by losing
		/// focus within its window. This method can be used to clear any state tied to the
		/// focus. For instance, if a button is held pressed with the trackball and the window
		/// loses focus, this method can be used to cancel the press.
		/// Subclasses of View overriding this method should always call super.onFocusLost().
		/// </remarks>
		/// <seealso cref="onFocusChanged(bool, int, android.graphics.Rect)">onFocusChanged(bool, int, android.graphics.Rect)
		/// 	</seealso>
		/// <seealso cref="onWindowFocusChanged(bool)">onWindowFocusChanged(bool)</seealso>
		/// <hide>pending API council approval</hide>
		protected internal virtual void onFocusLost()
		{
			resetPressedState();
		}

		private void resetPressedState()
		{
			if ((mViewFlags & ENABLED_MASK) == DISABLED)
			{
				return;
			}
			if (isPressed())
			{
				setPressed(false);
				if (!mHasPerformedLongPress)
				{
					removeLongPressCallback();
				}
			}
		}

		/// <summary>Returns true if this view has focus</summary>
		/// <returns>True if this view has focus, false otherwise.</returns>
		public virtual bool isFocused()
		{
			return (mPrivateFlags & FOCUSED) != 0;
		}

		/// <summary>
		/// Find the view in the hierarchy rooted at this view that currently has
		/// focus.
		/// </summary>
		/// <remarks>
		/// Find the view in the hierarchy rooted at this view that currently has
		/// focus.
		/// </remarks>
		/// <returns>
		/// The view that currently has focus, or null if no focused view can
		/// be found.
		/// </returns>
		public virtual android.view.View findFocus()
		{
			return (mPrivateFlags & FOCUSED) != 0 ? this : null;
		}

		/// <summary>
		/// Change whether this view is one of the set of scrollable containers in
		/// its window.
		/// </summary>
		/// <remarks>
		/// Change whether this view is one of the set of scrollable containers in
		/// its window.  This will be used to determine whether the window can
		/// resize or must pan when a soft input area is open -- scrollable
		/// containers allow the window to use resize mode since the container
		/// will appropriately shrink.
		/// </remarks>
		public virtual void setScrollContainer(bool isScrollContainer)
		{
			if (isScrollContainer)
			{
				if (mAttachInfo != null && (mPrivateFlags & SCROLL_CONTAINER_ADDED) == 0)
				{
					mAttachInfo.mScrollContainers.add(this);
					mPrivateFlags |= SCROLL_CONTAINER_ADDED;
				}
				mPrivateFlags |= SCROLL_CONTAINER;
			}
			else
			{
				if ((mPrivateFlags & SCROLL_CONTAINER_ADDED) != 0)
				{
					mAttachInfo.mScrollContainers.remove(this);
				}
				mPrivateFlags &= ~(SCROLL_CONTAINER | SCROLL_CONTAINER_ADDED);
			}
		}

		/// <summary>Returns the quality of the drawing cache.</summary>
		/// <remarks>Returns the quality of the drawing cache.</remarks>
		/// <returns>
		/// One of
		/// <see cref="DRAWING_CACHE_QUALITY_AUTO">DRAWING_CACHE_QUALITY_AUTO</see>
		/// ,
		/// <see cref="DRAWING_CACHE_QUALITY_LOW">DRAWING_CACHE_QUALITY_LOW</see>
		/// , or
		/// <see cref="DRAWING_CACHE_QUALITY_HIGH">DRAWING_CACHE_QUALITY_HIGH</see>
		/// </returns>
		/// <seealso cref="setDrawingCacheQuality(int)">setDrawingCacheQuality(int)</seealso>
		/// <seealso cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(bool)</seealso>
		/// <seealso cref="isDrawingCacheEnabled()">isDrawingCacheEnabled()</seealso>
		/// <attr>ref android.R.styleable#View_drawingCacheQuality</attr>
		public virtual int getDrawingCacheQuality()
		{
			return mViewFlags & DRAWING_CACHE_QUALITY_MASK;
		}

		/// <summary>Set the drawing cache quality of this view.</summary>
		/// <remarks>
		/// Set the drawing cache quality of this view. This value is used only when the
		/// drawing cache is enabled
		/// </remarks>
		/// <param name="quality">
		/// One of
		/// <see cref="DRAWING_CACHE_QUALITY_AUTO">DRAWING_CACHE_QUALITY_AUTO</see>
		/// ,
		/// <see cref="DRAWING_CACHE_QUALITY_LOW">DRAWING_CACHE_QUALITY_LOW</see>
		/// , or
		/// <see cref="DRAWING_CACHE_QUALITY_HIGH">DRAWING_CACHE_QUALITY_HIGH</see>
		/// </param>
		/// <seealso cref="getDrawingCacheQuality()">getDrawingCacheQuality()</seealso>
		/// <seealso cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(bool)</seealso>
		/// <seealso cref="isDrawingCacheEnabled()">isDrawingCacheEnabled()</seealso>
		/// <attr>ref android.R.styleable#View_drawingCacheQuality</attr>
		public virtual void setDrawingCacheQuality(int quality)
		{
			setFlags(quality, DRAWING_CACHE_QUALITY_MASK);
		}

		/// <summary>
		/// Returns whether the screen should remain on, corresponding to the current
		/// value of
		/// <see cref="KEEP_SCREEN_ON">KEEP_SCREEN_ON</see>
		/// .
		/// </summary>
		/// <returns>
		/// Returns true if
		/// <see cref="KEEP_SCREEN_ON">KEEP_SCREEN_ON</see>
		/// is set.
		/// </returns>
		/// <seealso cref="setKeepScreenOn(bool)">setKeepScreenOn(bool)</seealso>
		/// <attr>ref android.R.styleable#View_keepScreenOn</attr>
		public virtual bool getKeepScreenOn()
		{
			return (mViewFlags & KEEP_SCREEN_ON) != 0;
		}

		/// <summary>
		/// Controls whether the screen should remain on, modifying the
		/// value of
		/// <see cref="KEEP_SCREEN_ON">KEEP_SCREEN_ON</see>
		/// .
		/// </summary>
		/// <param name="keepScreenOn">
		/// Supply true to set
		/// <see cref="KEEP_SCREEN_ON">KEEP_SCREEN_ON</see>
		/// .
		/// </param>
		/// <seealso cref="getKeepScreenOn()">getKeepScreenOn()</seealso>
		/// <attr>ref android.R.styleable#View_keepScreenOn</attr>
		public virtual void setKeepScreenOn(bool keepScreenOn)
		{
			setFlags(keepScreenOn ? KEEP_SCREEN_ON : 0, KEEP_SCREEN_ON);
		}

		/// <summary>
		/// Gets the id of the view to use when the next focus is
		/// <see cref="FOCUS_LEFT">FOCUS_LEFT</see>
		/// .
		/// </summary>
		/// <returns>
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should decide automatically.
		/// </returns>
		/// <attr>ref android.R.styleable#View_nextFocusLeft</attr>
		public virtual int getNextFocusLeftId()
		{
			return mNextFocusLeftId;
		}

		/// <summary>
		/// Sets the id of the view to use when the next focus is
		/// <see cref="FOCUS_LEFT">FOCUS_LEFT</see>
		/// .
		/// </summary>
		/// <param name="nextFocusLeftId">
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should
		/// decide automatically.
		/// </param>
		/// <attr>ref android.R.styleable#View_nextFocusLeft</attr>
		public virtual void setNextFocusLeftId(int nextFocusLeftId)
		{
			mNextFocusLeftId = nextFocusLeftId;
		}

		/// <summary>
		/// Gets the id of the view to use when the next focus is
		/// <see cref="FOCUS_RIGHT">FOCUS_RIGHT</see>
		/// .
		/// </summary>
		/// <returns>
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should decide automatically.
		/// </returns>
		/// <attr>ref android.R.styleable#View_nextFocusRight</attr>
		public virtual int getNextFocusRightId()
		{
			return mNextFocusRightId;
		}

		/// <summary>
		/// Sets the id of the view to use when the next focus is
		/// <see cref="FOCUS_RIGHT">FOCUS_RIGHT</see>
		/// .
		/// </summary>
		/// <param name="nextFocusRightId">
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should
		/// decide automatically.
		/// </param>
		/// <attr>ref android.R.styleable#View_nextFocusRight</attr>
		public virtual void setNextFocusRightId(int nextFocusRightId)
		{
			mNextFocusRightId = nextFocusRightId;
		}

		/// <summary>
		/// Gets the id of the view to use when the next focus is
		/// <see cref="FOCUS_UP">FOCUS_UP</see>
		/// .
		/// </summary>
		/// <returns>
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should decide automatically.
		/// </returns>
		/// <attr>ref android.R.styleable#View_nextFocusUp</attr>
		public virtual int getNextFocusUpId()
		{
			return mNextFocusUpId;
		}

		/// <summary>
		/// Sets the id of the view to use when the next focus is
		/// <see cref="FOCUS_UP">FOCUS_UP</see>
		/// .
		/// </summary>
		/// <param name="nextFocusUpId">
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should
		/// decide automatically.
		/// </param>
		/// <attr>ref android.R.styleable#View_nextFocusUp</attr>
		public virtual void setNextFocusUpId(int nextFocusUpId)
		{
			mNextFocusUpId = nextFocusUpId;
		}

		/// <summary>
		/// Gets the id of the view to use when the next focus is
		/// <see cref="FOCUS_DOWN">FOCUS_DOWN</see>
		/// .
		/// </summary>
		/// <returns>
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should decide automatically.
		/// </returns>
		/// <attr>ref android.R.styleable#View_nextFocusDown</attr>
		public virtual int getNextFocusDownId()
		{
			return mNextFocusDownId;
		}

		/// <summary>
		/// Sets the id of the view to use when the next focus is
		/// <see cref="FOCUS_DOWN">FOCUS_DOWN</see>
		/// .
		/// </summary>
		/// <param name="nextFocusDownId">
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should
		/// decide automatically.
		/// </param>
		/// <attr>ref android.R.styleable#View_nextFocusDown</attr>
		public virtual void setNextFocusDownId(int nextFocusDownId)
		{
			mNextFocusDownId = nextFocusDownId;
		}

		/// <summary>
		/// Gets the id of the view to use when the next focus is
		/// <see cref="FOCUS_FORWARD">FOCUS_FORWARD</see>
		/// .
		/// </summary>
		/// <returns>
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should decide automatically.
		/// </returns>
		/// <attr>ref android.R.styleable#View_nextFocusForward</attr>
		public virtual int getNextFocusForwardId()
		{
			return mNextFocusForwardId;
		}

		/// <summary>
		/// Sets the id of the view to use when the next focus is
		/// <see cref="FOCUS_FORWARD">FOCUS_FORWARD</see>
		/// .
		/// </summary>
		/// <param name="nextFocusForwardId">
		/// The next focus ID, or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the framework should
		/// decide automatically.
		/// </param>
		/// <attr>ref android.R.styleable#View_nextFocusForward</attr>
		public virtual void setNextFocusForwardId(int nextFocusForwardId)
		{
			mNextFocusForwardId = nextFocusForwardId;
		}

		/// <summary>Returns the visibility of this view and all of its ancestors</summary>
		/// <returns>
		/// True if this view and all of its ancestors are
		/// <see cref="VISIBLE">VISIBLE</see>
		/// </returns>
		public virtual bool isShown()
		{
			android.view.View current = this;
			do
			{
				//noinspection ConstantConditions
				if ((current.mViewFlags & VISIBILITY_MASK) != VISIBLE)
				{
					return false;
				}
				android.view.ViewParent parent = current.mParent;
				if (parent == null)
				{
					return false;
				}
				// We are not attached to the view root
				if (!(parent is android.view.View))
				{
					return true;
				}
				current = (android.view.View)parent;
			}
			while (current != null);
			return false;
		}

		/// <summary>
		/// Apply the insets for system windows to this view, if the FITS_SYSTEM_WINDOWS flag
		/// is set
		/// </summary>
		/// <param name="insets">Insets for system windows</param>
		/// <returns>True if this view applied the insets, false otherwise</returns>
		protected internal virtual bool fitSystemWindows(android.graphics.Rect insets)
		{
			if ((mViewFlags & FITS_SYSTEM_WINDOWS) == FITS_SYSTEM_WINDOWS)
			{
				mPaddingLeft = insets.left;
				mPaddingTop = insets.top;
				mPaddingRight = insets.right;
				mPaddingBottom = insets.bottom;
				requestLayout();
				return true;
			}
			return false;
		}

		/// <summary>
		/// Set whether or not this view should account for system screen decorations
		/// such as the status bar and inset its content.
		/// </summary>
		/// <remarks>
		/// Set whether or not this view should account for system screen decorations
		/// such as the status bar and inset its content. This allows this view to be
		/// positioned in absolute screen coordinates and remain visible to the user.
		/// <p>This should only be used by top-level window decor views.
		/// </remarks>
		/// <param name="fitSystemWindows">
		/// true to inset content for system screen decorations, false for
		/// default behavior.
		/// </param>
		/// <attr>ref android.R.styleable#View_fitsSystemWindows</attr>
		public virtual void setFitsSystemWindows(bool fitSystemWindows_1)
		{
			setFlags(fitSystemWindows_1 ? FITS_SYSTEM_WINDOWS : 0, FITS_SYSTEM_WINDOWS);
		}

		/// <summary>Check for the FITS_SYSTEM_WINDOWS flag.</summary>
		/// <remarks>
		/// Check for the FITS_SYSTEM_WINDOWS flag. If this method returns true, this view
		/// will account for system screen decorations such as the status bar and inset its
		/// content. This allows the view to be positioned in absolute screen coordinates
		/// and remain visible to the user.
		/// </remarks>
		/// <returns>true if this view will adjust its content bounds for system screen decorations.
		/// 	</returns>
		/// <attr>ref android.R.styleable#View_fitsSystemWindows</attr>
		public virtual bool fitsSystemWindows()
		{
			return (mViewFlags & FITS_SYSTEM_WINDOWS) == FITS_SYSTEM_WINDOWS;
		}

		/// <summary>Returns the visibility status for this view.</summary>
		/// <remarks>Returns the visibility status for this view.</remarks>
		/// <returns>
		/// One of
		/// <see cref="VISIBLE">VISIBLE</see>
		/// ,
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// , or
		/// <see cref="GONE">GONE</see>
		/// .
		/// </returns>
		/// <attr>ref android.R.styleable#View_visibility</attr>
		public virtual int getVisibility()
		{
			return mViewFlags & VISIBILITY_MASK;
		}

		/// <summary>Set the enabled state of this view.</summary>
		/// <remarks>Set the enabled state of this view.</remarks>
		/// <param name="visibility">
		/// One of
		/// <see cref="VISIBLE">VISIBLE</see>
		/// ,
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// , or
		/// <see cref="GONE">GONE</see>
		/// .
		/// </param>
		/// <attr>ref android.R.styleable#View_visibility</attr>
		[android.view.RemotableViewMethod]
		public virtual void setVisibility(int visibility)
		{
			setFlags(visibility, VISIBILITY_MASK);
			if (mBGDrawable != null)
			{
				mBGDrawable.setVisible(visibility == VISIBLE, false);
			}
		}

		/// <summary>Returns the enabled status for this view.</summary>
		/// <remarks>
		/// Returns the enabled status for this view. The interpretation of the
		/// enabled state varies by subclass.
		/// </remarks>
		/// <returns>True if this view is enabled, false otherwise.</returns>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isEnabled()
		{
			return (mViewFlags & ENABLED_MASK) == ENABLED;
		}

		/// <summary>Set the enabled state of this view.</summary>
		/// <remarks>
		/// Set the enabled state of this view. The interpretation of the enabled
		/// state varies by subclass.
		/// </remarks>
		/// <param name="enabled">True if this view is enabled, false otherwise.</param>
		[android.view.RemotableViewMethod]
		public virtual void setEnabled(bool enabled)
		{
			if (enabled == isEnabled())
			{
				return;
			}
			setFlags(enabled ? ENABLED : DISABLED, ENABLED_MASK);
			refreshDrawableState();
			// Invalidate too, since the default behavior for views is to be
			// be drawn at 50% alpha rather than to change the drawable.
			invalidate(true);
		}

		/// <summary>Set whether this view can receive the focus.</summary>
		/// <remarks>
		/// Set whether this view can receive the focus.
		/// Setting this to false will also ensure that this view is not focusable
		/// in touch mode.
		/// </remarks>
		/// <param name="focusable">If true, this view can receive the focus.</param>
		/// <seealso cref="setFocusableInTouchMode(bool)">setFocusableInTouchMode(bool)</seealso>
		/// <attr>ref android.R.styleable#View_focusable</attr>
		public virtual void setFocusable(bool focusable)
		{
			if (!focusable)
			{
				setFlags(0, FOCUSABLE_IN_TOUCH_MODE);
			}
			setFlags(focusable ? FOCUSABLE : NOT_FOCUSABLE, FOCUSABLE_MASK);
		}

		/// <summary>Set whether this view can receive focus while in touch mode.</summary>
		/// <remarks>
		/// Set whether this view can receive focus while in touch mode.
		/// Setting this to true will also ensure that this view is focusable.
		/// </remarks>
		/// <param name="focusableInTouchMode">
		/// If true, this view can receive the focus while
		/// in touch mode.
		/// </param>
		/// <seealso cref="setFocusable(bool)">setFocusable(bool)</seealso>
		/// <attr>ref android.R.styleable#View_focusableInTouchMode</attr>
		public virtual void setFocusableInTouchMode(bool focusableInTouchMode)
		{
			// Focusable in touch mode should always be set before the focusable flag
			// otherwise, setting the focusable flag will trigger a focusableViewAvailable()
			// which, in touch mode, will not successfully request focus on this view
			// because the focusable in touch mode flag is not set
			setFlags(focusableInTouchMode ? FOCUSABLE_IN_TOUCH_MODE : 0, FOCUSABLE_IN_TOUCH_MODE
				);
			if (focusableInTouchMode)
			{
				setFlags(FOCUSABLE, FOCUSABLE_MASK);
			}
		}

		/// <summary>
		/// Set whether this view should have sound effects enabled for events such as
		/// clicking and touching.
		/// </summary>
		/// <remarks>
		/// Set whether this view should have sound effects enabled for events such as
		/// clicking and touching.
		/// <p>You may wish to disable sound effects for a view if you already play sounds,
		/// for instance, a dial key that plays dtmf tones.
		/// </remarks>
		/// <param name="soundEffectsEnabled">whether sound effects are enabled for this view.
		/// 	</param>
		/// <seealso cref="isSoundEffectsEnabled()">isSoundEffectsEnabled()</seealso>
		/// <seealso cref="playSoundEffect(int)">playSoundEffect(int)</seealso>
		/// <attr>ref android.R.styleable#View_soundEffectsEnabled</attr>
		public virtual void setSoundEffectsEnabled(bool soundEffectsEnabled)
		{
			setFlags(soundEffectsEnabled ? SOUND_EFFECTS_ENABLED : 0, SOUND_EFFECTS_ENABLED);
		}

		/// <returns>
		/// whether this view should have sound effects enabled for events such as
		/// clicking and touching.
		/// </returns>
		/// <seealso cref="setSoundEffectsEnabled(bool)">setSoundEffectsEnabled(bool)</seealso>
		/// <seealso cref="playSoundEffect(int)">playSoundEffect(int)</seealso>
		/// <attr>ref android.R.styleable#View_soundEffectsEnabled</attr>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isSoundEffectsEnabled()
		{
			return SOUND_EFFECTS_ENABLED == (mViewFlags & SOUND_EFFECTS_ENABLED);
		}

		/// <summary>
		/// Set whether this view should have haptic feedback for events such as
		/// long presses.
		/// </summary>
		/// <remarks>
		/// Set whether this view should have haptic feedback for events such as
		/// long presses.
		/// <p>You may wish to disable haptic feedback if your view already controls
		/// its own haptic feedback.
		/// </remarks>
		/// <param name="hapticFeedbackEnabled">whether haptic feedback enabled for this view.
		/// 	</param>
		/// <seealso cref="isHapticFeedbackEnabled()">isHapticFeedbackEnabled()</seealso>
		/// <seealso cref="performHapticFeedback(int)">performHapticFeedback(int)</seealso>
		/// <attr>ref android.R.styleable#View_hapticFeedbackEnabled</attr>
		public virtual void setHapticFeedbackEnabled(bool hapticFeedbackEnabled)
		{
			setFlags(hapticFeedbackEnabled ? HAPTIC_FEEDBACK_ENABLED : 0, HAPTIC_FEEDBACK_ENABLED
				);
		}

		/// <returns>
		/// whether this view should have haptic feedback enabled for events
		/// long presses.
		/// </returns>
		/// <seealso cref="setHapticFeedbackEnabled(bool)">setHapticFeedbackEnabled(bool)</seealso>
		/// <seealso cref="performHapticFeedback(int)">performHapticFeedback(int)</seealso>
		/// <attr>ref android.R.styleable#View_hapticFeedbackEnabled</attr>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isHapticFeedbackEnabled()
		{
			return HAPTIC_FEEDBACK_ENABLED == (mViewFlags & HAPTIC_FEEDBACK_ENABLED);
		}

		/// <summary>Returns the layout direction for this view.</summary>
		/// <remarks>Returns the layout direction for this view.</remarks>
		/// <returns>
		/// One of
		/// <see cref="LAYOUT_DIRECTION_LTR">LAYOUT_DIRECTION_LTR</see>
		/// ,
		/// <see cref="LAYOUT_DIRECTION_RTL">LAYOUT_DIRECTION_RTL</see>
		/// ,
		/// <see cref="LAYOUT_DIRECTION_INHERIT">LAYOUT_DIRECTION_INHERIT</see>
		/// or
		/// <see cref="LAYOUT_DIRECTION_LOCALE">LAYOUT_DIRECTION_LOCALE</see>
		/// .
		/// </returns>
		/// <attr>ref android.R.styleable#View_layoutDirection</attr>
		/// <hide></hide>
		public virtual int getLayoutDirection()
		{
			return mViewFlags & LAYOUT_DIRECTION_MASK;
		}

		/// <summary>Set the layout direction for this view.</summary>
		/// <remarks>
		/// Set the layout direction for this view. This will propagate a reset of layout direction
		/// resolution to the view's children and resolve layout direction for this view.
		/// </remarks>
		/// <param name="layoutDirection">
		/// One of
		/// <see cref="LAYOUT_DIRECTION_LTR">LAYOUT_DIRECTION_LTR</see>
		/// ,
		/// <see cref="LAYOUT_DIRECTION_RTL">LAYOUT_DIRECTION_RTL</see>
		/// ,
		/// <see cref="LAYOUT_DIRECTION_INHERIT">LAYOUT_DIRECTION_INHERIT</see>
		/// or
		/// <see cref="LAYOUT_DIRECTION_LOCALE">LAYOUT_DIRECTION_LOCALE</see>
		/// .
		/// </param>
		/// <attr>ref android.R.styleable#View_layoutDirection</attr>
		/// <hide></hide>
		[android.view.RemotableViewMethod]
		public virtual void setLayoutDirection(int layoutDirection)
		{
			if (getLayoutDirection() != layoutDirection)
			{
				resetResolvedLayoutDirection();
				// Setting the flag will also request a layout.
				setFlags(layoutDirection, LAYOUT_DIRECTION_MASK);
			}
		}

		/// <summary>Returns the resolved layout direction for this view.</summary>
		/// <remarks>Returns the resolved layout direction for this view.</remarks>
		/// <returns>
		/// 
		/// <see cref="LAYOUT_DIRECTION_RTL">LAYOUT_DIRECTION_RTL</see>
		/// if the layout direction is RTL or returns
		/// <see cref="LAYOUT_DIRECTION_LTR">LAYOUT_DIRECTION_LTR</see>
		/// id the layout direction is not RTL.
		/// </returns>
		/// <hide></hide>
		public virtual int getResolvedLayoutDirection()
		{
			resolveLayoutDirectionIfNeeded();
			return ((mPrivateFlags2 & LAYOUT_DIRECTION_RESOLVED_RTL) == LAYOUT_DIRECTION_RESOLVED_RTL
				) ? LAYOUT_DIRECTION_RTL : LAYOUT_DIRECTION_LTR;
		}

		/// <summary><p>Indicates whether or not this view's layout is right-to-left.</summary>
		/// <remarks>
		/// <p>Indicates whether or not this view's layout is right-to-left. This is resolved from
		/// layout attribute and/or the inherited value from the parent.</p>
		/// </remarks>
		/// <returns>true if the layout is right-to-left.</returns>
		/// <hide></hide>
		public virtual bool isLayoutRtl()
		{
			return (getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL);
		}

		/// <summary>
		/// If this view doesn't do any drawing on its own, set this flag to
		/// allow further optimizations.
		/// </summary>
		/// <remarks>
		/// If this view doesn't do any drawing on its own, set this flag to
		/// allow further optimizations. By default, this flag is not set on
		/// View, but could be set on some View subclasses such as ViewGroup.
		/// Typically, if you override
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// you should clear this flag.
		/// </remarks>
		/// <param name="willNotDraw">whether or not this View draw on its own</param>
		public virtual void setWillNotDraw(bool willNotDraw_1)
		{
			setFlags(willNotDraw_1 ? WILL_NOT_DRAW : 0, DRAW_MASK);
		}

		/// <summary>Returns whether or not this View draws on its own.</summary>
		/// <remarks>Returns whether or not this View draws on its own.</remarks>
		/// <returns>true if this view has nothing to draw, false otherwise</returns>
		public virtual bool willNotDraw()
		{
			return (mViewFlags & DRAW_MASK) == WILL_NOT_DRAW;
		}

		/// <summary>
		/// When a View's drawing cache is enabled, drawing is redirected to an
		/// offscreen bitmap.
		/// </summary>
		/// <remarks>
		/// When a View's drawing cache is enabled, drawing is redirected to an
		/// offscreen bitmap. Some views, like an ImageView, must be able to
		/// bypass this mechanism if they already draw a single bitmap, to avoid
		/// unnecessary usage of the memory.
		/// </remarks>
		/// <param name="willNotCacheDrawing">
		/// true if this view does not cache its
		/// drawing, false otherwise
		/// </param>
		public virtual void setWillNotCacheDrawing(bool willNotCacheDrawing_1)
		{
			setFlags(willNotCacheDrawing_1 ? WILL_NOT_CACHE_DRAWING : 0, WILL_NOT_CACHE_DRAWING
				);
		}

		/// <summary>Returns whether or not this View can cache its drawing or not.</summary>
		/// <remarks>Returns whether or not this View can cache its drawing or not.</remarks>
		/// <returns>true if this view does not cache its drawing, false otherwise</returns>
		public virtual bool willNotCacheDrawing()
		{
			return (mViewFlags & WILL_NOT_CACHE_DRAWING) == WILL_NOT_CACHE_DRAWING;
		}

		/// <summary>Indicates whether this view reacts to click events or not.</summary>
		/// <remarks>Indicates whether this view reacts to click events or not.</remarks>
		/// <returns>true if the view is clickable, false otherwise</returns>
		/// <seealso cref="setClickable(bool)">setClickable(bool)</seealso>
		/// <attr>ref android.R.styleable#View_clickable</attr>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isClickable()
		{
			return (mViewFlags & CLICKABLE) == CLICKABLE;
		}

		/// <summary>Enables or disables click events for this view.</summary>
		/// <remarks>
		/// Enables or disables click events for this view. When a view
		/// is clickable it will change its state to "pressed" on every click.
		/// Subclasses should set the view clickable to visually react to
		/// user's clicks.
		/// </remarks>
		/// <param name="clickable">true to make the view clickable, false otherwise</param>
		/// <seealso cref="isClickable()">isClickable()</seealso>
		/// <attr>ref android.R.styleable#View_clickable</attr>
		public virtual void setClickable(bool clickable)
		{
			setFlags(clickable ? CLICKABLE : 0, CLICKABLE);
		}

		/// <summary>Indicates whether this view reacts to long click events or not.</summary>
		/// <remarks>Indicates whether this view reacts to long click events or not.</remarks>
		/// <returns>true if the view is long clickable, false otherwise</returns>
		/// <seealso cref="setLongClickable(bool)">setLongClickable(bool)</seealso>
		/// <attr>ref android.R.styleable#View_longClickable</attr>
		public virtual bool isLongClickable()
		{
			return (mViewFlags & LONG_CLICKABLE) == LONG_CLICKABLE;
		}

		/// <summary>Enables or disables long click events for this view.</summary>
		/// <remarks>
		/// Enables or disables long click events for this view. When a view is long
		/// clickable it reacts to the user holding down the button for a longer
		/// duration than a tap. This event can either launch the listener or a
		/// context menu.
		/// </remarks>
		/// <param name="longClickable">true to make the view long clickable, false otherwise
		/// 	</param>
		/// <seealso cref="isLongClickable()">isLongClickable()</seealso>
		/// <attr>ref android.R.styleable#View_longClickable</attr>
		public virtual void setLongClickable(bool longClickable)
		{
			setFlags(longClickable ? LONG_CLICKABLE : 0, LONG_CLICKABLE);
		}

		/// <summary>Sets the pressed state for this view.</summary>
		/// <remarks>Sets the pressed state for this view.</remarks>
		/// <seealso cref="isClickable()">isClickable()</seealso>
		/// <seealso cref="setClickable(bool)">setClickable(bool)</seealso>
		/// <param name="pressed">
		/// Pass true to set the View's internal state to "pressed", or false to reverts
		/// the View's internal state from a previously set "pressed" state.
		/// </param>
		public virtual void setPressed(bool pressed)
		{
			if (pressed)
			{
				mPrivateFlags |= PRESSED;
			}
			else
			{
				mPrivateFlags &= ~PRESSED;
			}
			refreshDrawableState();
			dispatchSetPressed(pressed);
		}

		/// <summary>Dispatch setPressed to all of this View's children.</summary>
		/// <remarks>Dispatch setPressed to all of this View's children.</remarks>
		/// <seealso cref="setPressed(bool)">setPressed(bool)</seealso>
		/// <param name="pressed">The new pressed state</param>
		protected internal virtual void dispatchSetPressed(bool pressed)
		{
		}

		/// <summary>Indicates whether the view is currently in pressed state.</summary>
		/// <remarks>
		/// Indicates whether the view is currently in pressed state. Unless
		/// <see cref="setPressed(bool)">setPressed(bool)</see>
		/// is explicitly called, only clickable views can enter
		/// the pressed state.
		/// </remarks>
		/// <seealso cref="setPressed(bool)"></seealso>
		/// <seealso cref="isClickable()">isClickable()</seealso>
		/// <seealso cref="setClickable(bool)">setClickable(bool)</seealso>
		/// <returns>true if the view is currently pressed, false otherwise</returns>
		public virtual bool isPressed()
		{
			return (mPrivateFlags & PRESSED) == PRESSED;
		}

		/// <summary>
		/// Indicates whether this view will save its state (that is,
		/// whether its
		/// <see cref="onSaveInstanceState()">onSaveInstanceState()</see>
		/// method will be called).
		/// </summary>
		/// <returns>Returns true if the view state saving is enabled, else false.</returns>
		/// <seealso cref="setSaveEnabled(bool)">setSaveEnabled(bool)</seealso>
		/// <attr>ref android.R.styleable#View_saveEnabled</attr>
		public virtual bool isSaveEnabled()
		{
			return (mViewFlags & SAVE_DISABLED_MASK) != SAVE_DISABLED;
		}

		/// <summary>
		/// Controls whether the saving of this view's state is
		/// enabled (that is, whether its
		/// <see cref="onSaveInstanceState()">onSaveInstanceState()</see>
		/// method
		/// will be called).  Note that even if freezing is enabled, the
		/// view still must have an id assigned to it (via
		/// <see cref="setId(int)">setId(int)</see>
		/// )
		/// for its state to be saved.  This flag can only disable the
		/// saving of this view; any child views may still have their state saved.
		/// </summary>
		/// <param name="enabled">
		/// Set to false to <em>disable</em> state saving, or true
		/// (the default) to allow it.
		/// </param>
		/// <seealso cref="isSaveEnabled()">isSaveEnabled()</seealso>
		/// <seealso cref="setId(int)">setId(int)</seealso>
		/// <seealso cref="onSaveInstanceState()">onSaveInstanceState()</seealso>
		/// <attr>ref android.R.styleable#View_saveEnabled</attr>
		public virtual void setSaveEnabled(bool enabled)
		{
			setFlags(enabled ? 0 : SAVE_DISABLED, SAVE_DISABLED_MASK);
		}

		/// <summary>
		/// Gets whether the framework should discard touches when the view's
		/// window is obscured by another visible window.
		/// </summary>
		/// <remarks>
		/// Gets whether the framework should discard touches when the view's
		/// window is obscured by another visible window.
		/// Refer to the
		/// <see cref="View">View</see>
		/// security documentation for more details.
		/// </remarks>
		/// <returns>True if touch filtering is enabled.</returns>
		/// <seealso cref="setFilterTouchesWhenObscured(bool)">setFilterTouchesWhenObscured(bool)
		/// 	</seealso>
		/// <attr>ref android.R.styleable#View_filterTouchesWhenObscured</attr>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool getFilterTouchesWhenObscured()
		{
			return (mViewFlags & FILTER_TOUCHES_WHEN_OBSCURED) != 0;
		}

		/// <summary>
		/// Sets whether the framework should discard touches when the view's
		/// window is obscured by another visible window.
		/// </summary>
		/// <remarks>
		/// Sets whether the framework should discard touches when the view's
		/// window is obscured by another visible window.
		/// Refer to the
		/// <see cref="View">View</see>
		/// security documentation for more details.
		/// </remarks>
		/// <param name="enabled">True if touch filtering should be enabled.</param>
		/// <seealso cref="getFilterTouchesWhenObscured()">getFilterTouchesWhenObscured()</seealso>
		/// <attr>ref android.R.styleable#View_filterTouchesWhenObscured</attr>
		public virtual void setFilterTouchesWhenObscured(bool enabled)
		{
			setFlags(enabled ? 0 : FILTER_TOUCHES_WHEN_OBSCURED, FILTER_TOUCHES_WHEN_OBSCURED
				);
		}

		/// <summary>
		/// Indicates whether the entire hierarchy under this view will save its
		/// state when a state saving traversal occurs from its parent.
		/// </summary>
		/// <remarks>
		/// Indicates whether the entire hierarchy under this view will save its
		/// state when a state saving traversal occurs from its parent.  The default
		/// is true; if false, these views will not be saved unless
		/// <see cref="saveHierarchyState(android.util.SparseArray{E})">saveHierarchyState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// is called directly on this view.
		/// </remarks>
		/// <returns>Returns true if the view state saving from parent is enabled, else false.
		/// 	</returns>
		/// <seealso cref="setSaveFromParentEnabled(bool)">setSaveFromParentEnabled(bool)</seealso>
		public virtual bool isSaveFromParentEnabled()
		{
			return (mViewFlags & PARENT_SAVE_DISABLED_MASK) != PARENT_SAVE_DISABLED;
		}

		/// <summary>
		/// Controls whether the entire hierarchy under this view will save its
		/// state when a state saving traversal occurs from its parent.
		/// </summary>
		/// <remarks>
		/// Controls whether the entire hierarchy under this view will save its
		/// state when a state saving traversal occurs from its parent.  The default
		/// is true; if false, these views will not be saved unless
		/// <see cref="saveHierarchyState(android.util.SparseArray{E})">saveHierarchyState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// is called directly on this view.
		/// </remarks>
		/// <param name="enabled">
		/// Set to false to <em>disable</em> state saving, or true
		/// (the default) to allow it.
		/// </param>
		/// <seealso cref="isSaveFromParentEnabled()">isSaveFromParentEnabled()</seealso>
		/// <seealso cref="setId(int)">setId(int)</seealso>
		/// <seealso cref="onSaveInstanceState()">onSaveInstanceState()</seealso>
		public virtual void setSaveFromParentEnabled(bool enabled)
		{
			setFlags(enabled ? 0 : PARENT_SAVE_DISABLED, PARENT_SAVE_DISABLED_MASK);
		}

		/// <summary>Returns whether this View is able to take focus.</summary>
		/// <remarks>Returns whether this View is able to take focus.</remarks>
		/// <returns>True if this view can take focus, or false otherwise.</returns>
		/// <attr>ref android.R.styleable#View_focusable</attr>
		public bool isFocusable()
		{
			return FOCUSABLE == (mViewFlags & FOCUSABLE_MASK);
		}

		/// <summary>When a view is focusable, it may not want to take focus when in touch mode.
		/// 	</summary>
		/// <remarks>
		/// When a view is focusable, it may not want to take focus when in touch mode.
		/// For example, a button would like focus when the user is navigating via a D-pad
		/// so that the user can click on it, but once the user starts touching the screen,
		/// the button shouldn't take focus
		/// </remarks>
		/// <returns>Whether the view is focusable in touch mode.</returns>
		/// <attr>ref android.R.styleable#View_focusableInTouchMode</attr>
		[android.view.ViewDebug.ExportedProperty]
		public bool isFocusableInTouchMode()
		{
			return FOCUSABLE_IN_TOUCH_MODE == (mViewFlags & FOCUSABLE_IN_TOUCH_MODE);
		}

		/// <summary>Find the nearest view in the specified direction that can take focus.</summary>
		/// <remarks>
		/// Find the nearest view in the specified direction that can take focus.
		/// This does not actually give focus to that view.
		/// </remarks>
		/// <param name="direction">One of FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, and FOCUS_RIGHT</param>
		/// <returns>
		/// The nearest focusable in the specified direction, or null if none
		/// can be found.
		/// </returns>
		public virtual android.view.View focusSearch(int direction)
		{
			if (mParent != null)
			{
				return mParent.focusSearch(this, direction);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// This method is the last chance for the focused view and its ancestors to
		/// respond to an arrow key.
		/// </summary>
		/// <remarks>
		/// This method is the last chance for the focused view and its ancestors to
		/// respond to an arrow key. This is called when the focused view did not
		/// consume the key internally, nor could the view system find a new view in
		/// the requested direction to give focus to.
		/// </remarks>
		/// <param name="focused">The currently focused view.</param>
		/// <param name="direction">
		/// The direction focus wants to move. One of FOCUS_UP,
		/// FOCUS_DOWN, FOCUS_LEFT, and FOCUS_RIGHT.
		/// </param>
		/// <returns>True if the this view consumed this unhandled move.</returns>
		public virtual bool dispatchUnhandledMove(android.view.View focused, int direction
			)
		{
			return false;
		}

		private sealed class _Predicate_5095 : android.util.@internal.Predicate<android.view.View
			>
		{
			public _Predicate_5095(int id)
			{
				this.id = id;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.util.Predicate")]
			public bool apply(android.view.View t)
			{
				return t.mNextFocusForwardId == id;
			}

			private readonly int id;
		}

		/// <summary>
		/// If a user manually specified the next view id for a particular direction,
		/// use the root to look up the view.
		/// </summary>
		/// <remarks>
		/// If a user manually specified the next view id for a particular direction,
		/// use the root to look up the view.
		/// </remarks>
		/// <param name="root">The root view of the hierarchy containing this view.</param>
		/// <param name="direction">
		/// One of FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT, FOCUS_FORWARD,
		/// or FOCUS_BACKWARD.
		/// </param>
		/// <returns>The user specified next view, or null if there is none.</returns>
		internal virtual android.view.View findUserSetNextFocus(android.view.View root, int
			 direction)
		{
			switch (direction)
			{
				case FOCUS_LEFT:
				{
					if (mNextFocusLeftId == android.view.View.NO_ID)
					{
						return null;
					}
					return findViewInsideOutShouldExist(root, mNextFocusLeftId);
				}

				case FOCUS_RIGHT:
				{
					if (mNextFocusRightId == android.view.View.NO_ID)
					{
						return null;
					}
					return findViewInsideOutShouldExist(root, mNextFocusRightId);
				}

				case FOCUS_UP:
				{
					if (mNextFocusUpId == android.view.View.NO_ID)
					{
						return null;
					}
					return findViewInsideOutShouldExist(root, mNextFocusUpId);
				}

				case FOCUS_DOWN:
				{
					if (mNextFocusDownId == android.view.View.NO_ID)
					{
						return null;
					}
					return findViewInsideOutShouldExist(root, mNextFocusDownId);
				}

				case FOCUS_FORWARD:
				{
					if (mNextFocusForwardId == android.view.View.NO_ID)
					{
						return null;
					}
					return findViewInsideOutShouldExist(root, mNextFocusForwardId);
				}

				case FOCUS_BACKWARD:
				{
					int id = mID;
					return root.findViewByPredicateInsideOut(this, new _Predicate_5095(id));
				}
			}
			return null;
		}

		private sealed class _Predicate_5107 : android.util.@internal.Predicate<android.view.View
			>
		{
			public _Predicate_5107(int childViewId)
			{
				this.childViewId = childViewId;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.util.Predicate")]
			public bool apply(android.view.View t)
			{
				return t.mID == childViewId;
			}

			private readonly int childViewId;
		}

		private android.view.View findViewInsideOutShouldExist(android.view.View root, int
			 childViewId)
		{
			android.view.View result = root.findViewByPredicateInsideOut(this, new _Predicate_5107
				(childViewId));
			if (result == null)
			{
				android.util.Log.w(VIEW_LOG_TAG, "couldn't find next focus view specified " + "by user for id "
					 + childViewId);
			}
			return result;
		}

		/// <summary>
		/// Find and return all focusable views that are descendants of this view,
		/// possibly including this view if it is focusable itself.
		/// </summary>
		/// <remarks>
		/// Find and return all focusable views that are descendants of this view,
		/// possibly including this view if it is focusable itself.
		/// </remarks>
		/// <param name="direction">The direction of the focus</param>
		/// <returns>A list of focusable views</returns>
		public virtual java.util.ArrayList<android.view.View> getFocusables(int direction
			)
		{
			java.util.ArrayList<android.view.View> result = new java.util.ArrayList<android.view.View
				>(24);
			addFocusables(result, direction);
			return result;
		}

		/// <summary>
		/// Add any focusable views that are descendants of this view (possibly
		/// including this view if it is focusable itself) to views.
		/// </summary>
		/// <remarks>
		/// Add any focusable views that are descendants of this view (possibly
		/// including this view if it is focusable itself) to views.  If we are in touch mode,
		/// only add views that are also focusable in touch mode.
		/// </remarks>
		/// <param name="views">Focusable views found so far</param>
		/// <param name="direction">The direction of the focus</param>
		public virtual void addFocusables(java.util.ArrayList<android.view.View> views, int
			 direction)
		{
			addFocusables(views, direction, FOCUSABLES_TOUCH_MODE);
		}

		/// <summary>
		/// Adds any focusable views that are descendants of this view (possibly
		/// including this view if it is focusable itself) to views.
		/// </summary>
		/// <remarks>
		/// Adds any focusable views that are descendants of this view (possibly
		/// including this view if it is focusable itself) to views. This method
		/// adds all focusable views regardless if we are in touch mode or
		/// only views focusable in touch mode if we are in touch mode depending on
		/// the focusable mode paramater.
		/// </remarks>
		/// <param name="views">
		/// Focusable views found so far or null if all we are interested is
		/// the number of focusables.
		/// </param>
		/// <param name="direction">The direction of the focus.</param>
		/// <param name="focusableMode">The type of focusables to be added.</param>
		/// <seealso cref="FOCUSABLES_ALL">FOCUSABLES_ALL</seealso>
		/// <seealso cref="FOCUSABLES_TOUCH_MODE">FOCUSABLES_TOUCH_MODE</seealso>
		public virtual void addFocusables(java.util.ArrayList<android.view.View> views, int
			 direction, int focusableMode)
		{
			if (!isFocusable())
			{
				return;
			}
			if ((focusableMode & FOCUSABLES_TOUCH_MODE) == FOCUSABLES_TOUCH_MODE && isInTouchMode
				() && !isFocusableInTouchMode())
			{
				return;
			}
			if (views != null)
			{
				views.add(this);
			}
		}

		/// <summary>Finds the Views that contain given text.</summary>
		/// <remarks>
		/// Finds the Views that contain given text. The containment is case insensitive.
		/// The search is performed by either the text that the View renders or the content
		/// description that describes the view for accessibility purposes and the view does
		/// not render or both. Clients can specify how the search is to be performed via
		/// passing the
		/// <see cref="FIND_VIEWS_WITH_TEXT">FIND_VIEWS_WITH_TEXT</see>
		/// and
		/// <see cref="FIND_VIEWS_WITH_CONTENT_DESCRIPTION">FIND_VIEWS_WITH_CONTENT_DESCRIPTION
		/// 	</see>
		/// flags.
		/// </remarks>
		/// <param name="outViews">The output list of matching Views.</param>
		/// <param name="searched">The text to match against.</param>
		/// <seealso cref="FIND_VIEWS_WITH_TEXT">FIND_VIEWS_WITH_TEXT</seealso>
		/// <seealso cref="FIND_VIEWS_WITH_CONTENT_DESCRIPTION">FIND_VIEWS_WITH_CONTENT_DESCRIPTION
		/// 	</seealso>
		/// <seealso cref="setContentDescription(java.lang.CharSequence)">setContentDescription(java.lang.CharSequence)
		/// 	</seealso>
		public virtual void findViewsWithText(java.util.ArrayList<android.view.View> outViews
			, java.lang.CharSequence searched, int flags)
		{
			if ((flags & FIND_VIEWS_WITH_CONTENT_DESCRIPTION) != 0 && !android.text.TextUtils
				.isEmpty(searched) && !android.text.TextUtils.isEmpty(mContentDescription))
			{
				string searchedLowerCase = searched.ToString().ToLower();
				string contentDescriptionLowerCase = mContentDescription.ToString().ToLower();
				if (contentDescriptionLowerCase.Contains(searchedLowerCase))
				{
					outViews.add(this);
				}
			}
		}

		/// <summary>
		/// Find and return all touchable views that are descendants of this view,
		/// possibly including this view if it is touchable itself.
		/// </summary>
		/// <remarks>
		/// Find and return all touchable views that are descendants of this view,
		/// possibly including this view if it is touchable itself.
		/// </remarks>
		/// <returns>A list of touchable views</returns>
		public virtual java.util.ArrayList<android.view.View> getTouchables()
		{
			java.util.ArrayList<android.view.View> result = new java.util.ArrayList<android.view.View
				>();
			addTouchables(result);
			return result;
		}

		/// <summary>
		/// Add any touchable views that are descendants of this view (possibly
		/// including this view if it is touchable itself) to views.
		/// </summary>
		/// <remarks>
		/// Add any touchable views that are descendants of this view (possibly
		/// including this view if it is touchable itself) to views.
		/// </remarks>
		/// <param name="views">Touchable views found so far</param>
		public virtual void addTouchables(java.util.ArrayList<android.view.View> views)
		{
			int viewFlags = mViewFlags;
			if (((viewFlags & CLICKABLE) == CLICKABLE || (viewFlags & LONG_CLICKABLE) == LONG_CLICKABLE
				) && (viewFlags & ENABLED_MASK) == ENABLED)
			{
				views.add(this);
			}
		}

		/// <summary>
		/// Call this to try to give focus to a specific view or to one of its
		/// descendants.
		/// </summary>
		/// <remarks>
		/// Call this to try to give focus to a specific view or to one of its
		/// descendants.
		/// A view will not actually take focus if it is not focusable (
		/// <see cref="isFocusable()">isFocusable()</see>
		/// returns
		/// false), or if it is focusable and it is not focusable in touch mode
		/// (
		/// <see cref="isFocusableInTouchMode()">isFocusableInTouchMode()</see>
		/// ) while the device is in touch mode.
		/// See also
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// , which is what you call to say that you
		/// have focus, and you want your parent to look for the next one.
		/// This is equivalent to calling
		/// <see cref="requestFocus(int, android.graphics.Rect)">requestFocus(int, android.graphics.Rect)
		/// 	</see>
		/// with arguments
		/// <see cref="FOCUS_DOWN">FOCUS_DOWN</see>
		/// and <code>null</code>.
		/// </remarks>
		/// <returns>Whether this view or one of its descendants actually took focus.</returns>
		public bool requestFocus()
		{
			return requestFocus(android.view.View.FOCUS_DOWN);
		}

		/// <summary>
		/// Call this to try to give focus to a specific view or to one of its
		/// descendants and give it a hint about what direction focus is heading.
		/// </summary>
		/// <remarks>
		/// Call this to try to give focus to a specific view or to one of its
		/// descendants and give it a hint about what direction focus is heading.
		/// A view will not actually take focus if it is not focusable (
		/// <see cref="isFocusable()">isFocusable()</see>
		/// returns
		/// false), or if it is focusable and it is not focusable in touch mode
		/// (
		/// <see cref="isFocusableInTouchMode()">isFocusableInTouchMode()</see>
		/// ) while the device is in touch mode.
		/// See also
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// , which is what you call to say that you
		/// have focus, and you want your parent to look for the next one.
		/// This is equivalent to calling
		/// <see cref="requestFocus(int, android.graphics.Rect)">requestFocus(int, android.graphics.Rect)
		/// 	</see>
		/// with
		/// <code>null</code> set for the previously focused rectangle.
		/// </remarks>
		/// <param name="direction">One of FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, and FOCUS_RIGHT</param>
		/// <returns>Whether this view or one of its descendants actually took focus.</returns>
		public bool requestFocus(int direction)
		{
			return requestFocus(direction, null);
		}

		/// <summary>
		/// Call this to try to give focus to a specific view or to one of its descendants
		/// and give it hints about the direction and a specific rectangle that the focus
		/// is coming from.
		/// </summary>
		/// <remarks>
		/// Call this to try to give focus to a specific view or to one of its descendants
		/// and give it hints about the direction and a specific rectangle that the focus
		/// is coming from.  The rectangle can help give larger views a finer grained hint
		/// about where focus is coming from, and therefore, where to show selection, or
		/// forward focus change internally.
		/// A view will not actually take focus if it is not focusable (
		/// <see cref="isFocusable()">isFocusable()</see>
		/// returns
		/// false), or if it is focusable and it is not focusable in touch mode
		/// (
		/// <see cref="isFocusableInTouchMode()">isFocusableInTouchMode()</see>
		/// ) while the device is in touch mode.
		/// A View will not take focus if it is not visible.
		/// A View will not take focus if one of its parents has
		/// <see cref="ViewGroup.getDescendantFocusability()">ViewGroup.getDescendantFocusability()
		/// 	</see>
		/// equal to
		/// <see cref="ViewGroup.FOCUS_BLOCK_DESCENDANTS">ViewGroup.FOCUS_BLOCK_DESCENDANTS</see>
		/// .
		/// See also
		/// <see cref="focusSearch(int)">focusSearch(int)</see>
		/// , which is what you call to say that you
		/// have focus, and you want your parent to look for the next one.
		/// You may wish to override this method if your custom
		/// <see cref="View">View</see>
		/// has an internal
		/// <see cref="View">View</see>
		/// that it wishes to forward the request to.
		/// </remarks>
		/// <param name="direction">One of FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, and FOCUS_RIGHT</param>
		/// <param name="previouslyFocusedRect">
		/// The rectangle (in this View's coordinate system)
		/// to give a finer grained hint about where focus is coming from.  May be null
		/// if there is no hint.
		/// </param>
		/// <returns>Whether this view or one of its descendants actually took focus.</returns>
		public virtual bool requestFocus(int direction, android.graphics.Rect previouslyFocusedRect
			)
		{
			// need to be focusable
			if ((mViewFlags & FOCUSABLE_MASK) != FOCUSABLE || (mViewFlags & VISIBILITY_MASK) 
				!= VISIBLE)
			{
				return false;
			}
			// need to be focusable in touch mode if in touch mode
			if (isInTouchMode() && (FOCUSABLE_IN_TOUCH_MODE != (mViewFlags & FOCUSABLE_IN_TOUCH_MODE
				)))
			{
				return false;
			}
			// need to not have any parents blocking us
			if (hasAncestorThatBlocksDescendantFocus())
			{
				return false;
			}
			handleFocusGainInternal(direction, previouslyFocusedRect);
			return true;
		}

		/// <summary>Gets the ViewAncestor, or null if not attached.</summary>
		/// <remarks>Gets the ViewAncestor, or null if not attached.</remarks>
		internal virtual android.view.ViewRootImpl getViewRootImpl()
		{
			android.view.View root = getRootView();
			return root != null ? (android.view.ViewRootImpl)root.getParent() : null;
		}

		/// <summary>Call this to try to give focus to a specific view or to one of its descendants.
		/// 	</summary>
		/// <remarks>
		/// Call this to try to give focus to a specific view or to one of its descendants. This is a
		/// special variant of
		/// <see cref="requestFocus()"></see>
		/// that will allow views that are not focuable in
		/// touch mode to request focus when they are touched.
		/// </remarks>
		/// <returns>Whether this view or one of its descendants actually took focus.</returns>
		/// <seealso cref="isInTouchMode()">isInTouchMode()</seealso>
		public bool requestFocusFromTouch()
		{
			// Leave touch mode if we need to
			if (isInTouchMode())
			{
				android.view.ViewRootImpl viewRoot = getViewRootImpl();
				if (viewRoot != null)
				{
					viewRoot.ensureTouchMode(false);
				}
			}
			return requestFocus(android.view.View.FOCUS_DOWN);
		}

		/// <returns>Whether any ancestor of this view blocks descendant focus.</returns>
		private bool hasAncestorThatBlocksDescendantFocus()
		{
			android.view.ViewParent ancestor = mParent;
			while (ancestor is android.view.ViewGroup)
			{
				android.view.ViewGroup vgAncestor = (android.view.ViewGroup)ancestor;
				if (vgAncestor.getDescendantFocusability() == android.view.ViewGroup.FOCUS_BLOCK_DESCENDANTS)
				{
					return true;
				}
				else
				{
					ancestor = vgAncestor.getParent();
				}
			}
			return false;
		}

		/// <hide></hide>
		public virtual void dispatchStartTemporaryDetach()
		{
			onStartTemporaryDetach();
		}

		/// <summary>
		/// This is called when a container is going to temporarily detach a child, with
		/// <see cref="ViewGroup.detachViewFromParent(View)">ViewGroup.detachViewFromParent</see>
		/// .
		/// It will either be followed by
		/// <see cref="onFinishTemporaryDetach()">onFinishTemporaryDetach()</see>
		/// or
		/// <see cref="onDetachedFromWindow()">onDetachedFromWindow()</see>
		/// when the container is done.
		/// </summary>
		public virtual void onStartTemporaryDetach()
		{
			removeUnsetPressCallback();
			mPrivateFlags |= CANCEL_NEXT_UP_EVENT;
		}

		/// <hide></hide>
		public virtual void dispatchFinishTemporaryDetach()
		{
			onFinishTemporaryDetach();
		}

		/// <summary>
		/// Called after
		/// <see cref="onStartTemporaryDetach()">onStartTemporaryDetach()</see>
		/// when the container is done
		/// changing the view.
		/// </summary>
		public virtual void onFinishTemporaryDetach()
		{
		}

		/// <summary>
		/// Return the global
		/// <see cref="DispatcherState">DispatcherState</see>
		/// for this view's window.  Returns null if the view is not currently attached
		/// to the window.  Normally you will not need to use this directly, but
		/// just use the standard high-level event callbacks like
		/// <see cref="onKeyDown(int, KeyEvent)">onKeyDown(int, KeyEvent)</see>
		/// .
		/// </summary>
		public virtual android.view.KeyEvent.DispatcherState getKeyDispatcherState()
		{
			return mAttachInfo != null ? mAttachInfo.mKeyDispatchState : null;
		}

		/// <summary>
		/// Dispatch a key event before it is processed by any input method
		/// associated with the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Dispatch a key event before it is processed by any input method
		/// associated with the view hierarchy.  This can be used to intercept
		/// key events in special situations before the IME consumes them; a
		/// typical example would be handling the BACK key to update the application's
		/// UI instead of allowing the IME to see it and close itself.
		/// </remarks>
		/// <param name="event">The key event to be dispatched.</param>
		/// <returns>True if the event was handled, false otherwise.</returns>
		public virtual bool dispatchKeyEventPreIme(android.view.KeyEvent @event)
		{
			return onKeyPreIme(@event.getKeyCode(), @event);
		}

		/// <summary>Dispatch a key event to the next view on the focus path.</summary>
		/// <remarks>
		/// Dispatch a key event to the next view on the focus path. This path runs
		/// from the top of the view tree down to the currently focused view. If this
		/// view has focus, it will dispatch to itself. Otherwise it will dispatch
		/// the next node down the focus path. This method also fires any key
		/// listeners.
		/// </remarks>
		/// <param name="event">The key event to be dispatched.</param>
		/// <returns>True if the event was handled, false otherwise.</returns>
		public virtual bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onKeyEvent(@event, 0);
			}
			// Give any attached key listener a first crack at the event.
			//noinspection SimplifiableIfStatement
			if (mOnKeyListener != null && (mViewFlags & ENABLED_MASK) == ENABLED && mOnKeyListener
				.onKey(this, @event.getKeyCode(), @event))
			{
				return true;
			}
			if (@event.dispatch(this, mAttachInfo != null ? mAttachInfo.mKeyDispatchState : null
				, this))
			{
				return true;
			}
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(@event, 0);
			}
			return false;
		}

		/// <summary>Dispatches a key shortcut event.</summary>
		/// <remarks>Dispatches a key shortcut event.</remarks>
		/// <param name="event">The key event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		public virtual bool dispatchKeyShortcutEvent(android.view.KeyEvent @event)
		{
			return onKeyShortcut(@event.getKeyCode(), @event);
		}

		/// <summary>
		/// Pass the touch screen motion event down to the target view, or this
		/// view if it is the target.
		/// </summary>
		/// <remarks>
		/// Pass the touch screen motion event down to the target view, or this
		/// view if it is the target.
		/// </remarks>
		/// <param name="event">The motion event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		public virtual bool dispatchTouchEvent(android.view.MotionEvent @event)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onTouchEvent(@event, 0);
			}
			if (onFilterTouchEventForSecurity(@event))
			{
				//noinspection SimplifiableIfStatement
				if (mOnTouchListener != null && (mViewFlags & ENABLED_MASK) == ENABLED && mOnTouchListener
					.onTouch(this, @event))
				{
					return true;
				}
				if (onTouchEvent(@event))
				{
					return true;
				}
			}
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(@event, 0);
			}
			return false;
		}

		/// <summary>Filter the touch event to apply security policies.</summary>
		/// <remarks>Filter the touch event to apply security policies.</remarks>
		/// <param name="event">The motion event to be filtered.</param>
		/// <returns>True if the event should be dispatched, false if the event should be dropped.
		/// 	</returns>
		/// <seealso cref="getFilterTouchesWhenObscured()">getFilterTouchesWhenObscured()</seealso>
		public virtual bool onFilterTouchEventForSecurity(android.view.MotionEvent @event
			)
		{
			//noinspection RedundantIfStatement
			if ((mViewFlags & FILTER_TOUCHES_WHEN_OBSCURED) != 0 && (@event.getFlags() & android.view.MotionEvent
				.FLAG_WINDOW_IS_OBSCURED) != 0)
			{
				// Window is obscured, drop this touch.
				return false;
			}
			return true;
		}

		/// <summary>Pass a trackball motion event down to the focused view.</summary>
		/// <remarks>Pass a trackball motion event down to the focused view.</remarks>
		/// <param name="event">The motion event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		public virtual bool dispatchTrackballEvent(android.view.MotionEvent @event)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onTrackballEvent(@event, 0);
			}
			return onTrackballEvent(@event);
		}

		/// <summary>Dispatch a generic motion event.</summary>
		/// <remarks>
		/// Dispatch a generic motion event.
		/// <p>
		/// Generic motion events with source class
		/// <see cref="InputDevice.SOURCE_CLASS_POINTER">InputDevice.SOURCE_CLASS_POINTER</see>
		/// are delivered to the view under the pointer.  All other generic motion events are
		/// delivered to the focused view.  Hover events are handled specially and are delivered
		/// to
		/// <see cref="onHoverEvent(MotionEvent)">onHoverEvent(MotionEvent)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="event">The motion event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		public virtual bool dispatchGenericMotionEvent(android.view.MotionEvent @event)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onGenericMotionEvent(@event, 0);
			}
			int source = @event.getSource();
			if ((source & android.view.InputDevice.SOURCE_CLASS_POINTER) != 0)
			{
				int action = @event.getAction();
				if (action == android.view.MotionEvent.ACTION_HOVER_ENTER || action == android.view.MotionEvent
					.ACTION_HOVER_MOVE || action == android.view.MotionEvent.ACTION_HOVER_EXIT)
				{
					if (dispatchHoverEvent(@event))
					{
						return true;
					}
				}
				else
				{
					if (dispatchGenericPointerEvent(@event))
					{
						return true;
					}
				}
			}
			else
			{
				if (dispatchGenericFocusedEvent(@event))
				{
					return true;
				}
			}
			if (dispatchGenericMotionEventInternal(@event))
			{
				return true;
			}
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(@event, 0);
			}
			return false;
		}

		private bool dispatchGenericMotionEventInternal(android.view.MotionEvent @event)
		{
			//noinspection SimplifiableIfStatement
			if (mOnGenericMotionListener != null && (mViewFlags & ENABLED_MASK) == ENABLED &&
				 mOnGenericMotionListener.onGenericMotion(this, @event))
			{
				return true;
			}
			if (onGenericMotionEvent(@event))
			{
				return true;
			}
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(@event, 0);
			}
			return false;
		}

		/// <summary>Dispatch a hover event.</summary>
		/// <remarks>
		/// Dispatch a hover event.
		/// <p>
		/// Do not call this method directly.
		/// Call
		/// <see cref="dispatchGenericMotionEvent(MotionEvent)">dispatchGenericMotionEvent(MotionEvent)
		/// 	</see>
		/// instead.
		/// </p>
		/// </remarks>
		/// <param name="event">The motion event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		protected internal virtual bool dispatchHoverEvent(android.view.MotionEvent @event
			)
		{
			//noinspection SimplifiableIfStatement
			if (mOnHoverListener != null && (mViewFlags & ENABLED_MASK) == ENABLED && mOnHoverListener
				.onHover(this, @event))
			{
				return true;
			}
			return onHoverEvent(@event);
		}

		/// <summary>
		/// Returns true if the view has a child to which it has recently sent
		/// <see cref="MotionEvent.ACTION_HOVER_ENTER">MotionEvent.ACTION_HOVER_ENTER</see>
		/// .  If this view is hovered and
		/// it does not have a hovered child, then it must be the innermost hovered view.
		/// </summary>
		/// <hide></hide>
		protected internal virtual bool hasHoveredChild()
		{
			return false;
		}

		/// <summary>Dispatch a generic motion event to the view under the first pointer.</summary>
		/// <remarks>
		/// Dispatch a generic motion event to the view under the first pointer.
		/// <p>
		/// Do not call this method directly.
		/// Call
		/// <see cref="dispatchGenericMotionEvent(MotionEvent)">dispatchGenericMotionEvent(MotionEvent)
		/// 	</see>
		/// instead.
		/// </p>
		/// </remarks>
		/// <param name="event">The motion event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		protected internal virtual bool dispatchGenericPointerEvent(android.view.MotionEvent
			 @event)
		{
			return false;
		}

		/// <summary>Dispatch a generic motion event to the currently focused view.</summary>
		/// <remarks>
		/// Dispatch a generic motion event to the currently focused view.
		/// <p>
		/// Do not call this method directly.
		/// Call
		/// <see cref="dispatchGenericMotionEvent(MotionEvent)">dispatchGenericMotionEvent(MotionEvent)
		/// 	</see>
		/// instead.
		/// </p>
		/// </remarks>
		/// <param name="event">The motion event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		protected internal virtual bool dispatchGenericFocusedEvent(android.view.MotionEvent
			 @event)
		{
			return false;
		}

		/// <summary>Dispatch a pointer event.</summary>
		/// <remarks>
		/// Dispatch a pointer event.
		/// <p>
		/// Dispatches touch related pointer events to
		/// <see cref="onTouchEvent(MotionEvent)">onTouchEvent(MotionEvent)</see>
		/// and all
		/// other events to
		/// <see cref="onGenericMotionEvent(MotionEvent)">onGenericMotionEvent(MotionEvent)</see>
		/// .  This separation of concerns
		/// reinforces the invariant that
		/// <see cref="onTouchEvent(MotionEvent)">onTouchEvent(MotionEvent)</see>
		/// is really about touches
		/// and should not be expected to handle other pointing device features.
		/// </p>
		/// </remarks>
		/// <param name="event">The motion event to be dispatched.</param>
		/// <returns>True if the event was handled by the view, false otherwise.</returns>
		/// <hide></hide>
		public bool dispatchPointerEvent(android.view.MotionEvent @event)
		{
			if (@event.isTouchEvent())
			{
				return dispatchTouchEvent(@event);
			}
			else
			{
				return dispatchGenericMotionEvent(@event);
			}
		}

		/// <summary>Called when the window containing this view gains or loses window focus.
		/// 	</summary>
		/// <remarks>
		/// Called when the window containing this view gains or loses window focus.
		/// ViewGroups should override to route to their children.
		/// </remarks>
		/// <param name="hasFocus">
		/// True if the window containing this view now has focus,
		/// false otherwise.
		/// </param>
		public virtual void dispatchWindowFocusChanged(bool hasFocus_1)
		{
			onWindowFocusChanged(hasFocus_1);
		}

		/// <summary>Called when the window containing this view gains or loses focus.</summary>
		/// <remarks>
		/// Called when the window containing this view gains or loses focus.  Note
		/// that this is separate from view focus: to receive key events, both
		/// your view and its window must have focus.  If a window is displayed
		/// on top of yours that takes input focus, then your own window will lose
		/// focus but the view focus will remain unchanged.
		/// </remarks>
		/// <param name="hasWindowFocus">
		/// True if the window containing this view now has
		/// focus, false otherwise.
		/// </param>
		public virtual void onWindowFocusChanged(bool hasWindowFocus_1)
		{
			android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
				.peekInstance();
			if (!hasWindowFocus_1)
			{
				if (isPressed())
				{
					setPressed(false);
				}
				if (imm != null && (mPrivateFlags & FOCUSED) != 0)
				{
					imm.focusOut(this);
				}
				removeLongPressCallback();
				removeTapCallback();
				onFocusLost();
			}
			else
			{
				if (imm != null && (mPrivateFlags & FOCUSED) != 0)
				{
					imm.focusIn(this);
				}
			}
			refreshDrawableState();
		}

		/// <summary>Returns true if this view is in a window that currently has window focus.
		/// 	</summary>
		/// <remarks>
		/// Returns true if this view is in a window that currently has window focus.
		/// Note that this is not the same as the view itself having focus.
		/// </remarks>
		/// <returns>True if this view is in a window that currently has window focus.</returns>
		public virtual bool hasWindowFocus()
		{
			return mAttachInfo != null && mAttachInfo.mHasWindowFocus;
		}

		/// <summary>Dispatch a view visibility change down the view hierarchy.</summary>
		/// <remarks>
		/// Dispatch a view visibility change down the view hierarchy.
		/// ViewGroups should override to route to their children.
		/// </remarks>
		/// <param name="changedView">
		/// The view whose visibility changed. Could be 'this' or
		/// an ancestor view.
		/// </param>
		/// <param name="visibility">
		/// The new visibility of changedView:
		/// <see cref="VISIBLE">VISIBLE</see>
		/// ,
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// or
		/// <see cref="GONE">GONE</see>
		/// .
		/// </param>
		protected internal virtual void dispatchVisibilityChanged(android.view.View changedView
			, int visibility)
		{
			onVisibilityChanged(changedView, visibility);
		}

		/// <summary>Called when the visibility of the view or an ancestor of the view is changed.
		/// 	</summary>
		/// <remarks>Called when the visibility of the view or an ancestor of the view is changed.
		/// 	</remarks>
		/// <param name="changedView">
		/// The view whose visibility changed. Could be 'this' or
		/// an ancestor view.
		/// </param>
		/// <param name="visibility">
		/// The new visibility of changedView:
		/// <see cref="VISIBLE">VISIBLE</see>
		/// ,
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// or
		/// <see cref="GONE">GONE</see>
		/// .
		/// </param>
		protected internal virtual void onVisibilityChanged(android.view.View changedView
			, int visibility)
		{
			if (visibility == VISIBLE)
			{
				if (mAttachInfo != null)
				{
					initialAwakenScrollBars();
				}
				else
				{
					mPrivateFlags |= AWAKEN_SCROLL_BARS_ON_ATTACH;
				}
			}
		}

		/// <summary>Dispatch a hint about whether this view is displayed.</summary>
		/// <remarks>
		/// Dispatch a hint about whether this view is displayed. For instance, when
		/// a View moves out of the screen, it might receives a display hint indicating
		/// the view is not displayed. Applications should not <em>rely</em> on this hint
		/// as there is no guarantee that they will receive one.
		/// </remarks>
		/// <param name="hint">
		/// A hint about whether or not this view is displayed:
		/// <see cref="VISIBLE">VISIBLE</see>
		/// or
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// .
		/// </param>
		public virtual void dispatchDisplayHint(int hint)
		{
			onDisplayHint(hint);
		}

		/// <summary>Gives this view a hint about whether is displayed or not.</summary>
		/// <remarks>
		/// Gives this view a hint about whether is displayed or not. For instance, when
		/// a View moves out of the screen, it might receives a display hint indicating
		/// the view is not displayed. Applications should not <em>rely</em> on this hint
		/// as there is no guarantee that they will receive one.
		/// </remarks>
		/// <param name="hint">
		/// A hint about whether or not this view is displayed:
		/// <see cref="VISIBLE">VISIBLE</see>
		/// or
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// .
		/// </param>
		protected internal virtual void onDisplayHint(int hint)
		{
		}

		/// <summary>Dispatch a window visibility change down the view hierarchy.</summary>
		/// <remarks>
		/// Dispatch a window visibility change down the view hierarchy.
		/// ViewGroups should override to route to their children.
		/// </remarks>
		/// <param name="visibility">The new visibility of the window.</param>
		/// <seealso cref="onWindowVisibilityChanged(int)"></seealso>
		public virtual void dispatchWindowVisibilityChanged(int visibility)
		{
			onWindowVisibilityChanged(visibility);
		}

		/// <summary>
		/// Called when the window containing has change its visibility
		/// (between
		/// <see cref="GONE">GONE</see>
		/// ,
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// , and
		/// <see cref="VISIBLE">VISIBLE</see>
		/// ).  Note
		/// that this tells you whether or not your window is being made visible
		/// to the window manager; this does <em>not</em> tell you whether or not
		/// your window is obscured by other windows on the screen, even if it
		/// is itself visible.
		/// </summary>
		/// <param name="visibility">The new visibility of the window.</param>
		protected internal virtual void onWindowVisibilityChanged(int visibility)
		{
			if (visibility == VISIBLE)
			{
				initialAwakenScrollBars();
			}
		}

		/// <summary>
		/// Returns the current visibility of the window this view is attached to
		/// (either
		/// <see cref="GONE">GONE</see>
		/// ,
		/// <see cref="INVISIBLE">INVISIBLE</see>
		/// , or
		/// <see cref="VISIBLE">VISIBLE</see>
		/// ).
		/// </summary>
		/// <returns>Returns the current visibility of the view's window.</returns>
		public virtual int getWindowVisibility()
		{
			return mAttachInfo != null ? mAttachInfo.mWindowVisibility : GONE;
		}

		/// <summary>
		/// Retrieve the overall visible display size in which the window this view is
		/// attached to has been positioned in.
		/// </summary>
		/// <remarks>
		/// Retrieve the overall visible display size in which the window this view is
		/// attached to has been positioned in.  This takes into account screen
		/// decorations above the window, for both cases where the window itself
		/// is being position inside of them or the window is being placed under
		/// then and covered insets are used for the window to position its content
		/// inside.  In effect, this tells you the available area where content can
		/// be placed and remain visible to users.
		/// <p>This function requires an IPC back to the window manager to retrieve
		/// the requested information, so should not be used in performance critical
		/// code like drawing.
		/// </remarks>
		/// <param name="outRect">
		/// Filled in with the visible display frame.  If the view
		/// is not attached to a window, this is simply the raw display size.
		/// </param>
		public virtual void getWindowVisibleDisplayFrame(android.graphics.Rect outRect)
		{
			if (mAttachInfo != null)
			{
				try
				{
					mAttachInfo.mSession.getDisplayFrame(mAttachInfo.mWindow, outRect);
				}
				catch (android.os.RemoteException)
				{
					return;
				}
				// XXX This is really broken, and probably all needs to be done
				// in the window manager, and we need to know more about whether
				// we want the area behind or in front of the IME.
				android.graphics.Rect insets = mAttachInfo.mVisibleInsets;
				outRect.left += insets.left;
				outRect.top += insets.top;
				outRect.right -= insets.right;
				outRect.bottom -= insets.bottom;
				return;
			}
			android.view.Display d = android.view.WindowManagerImpl.getDefault().getDefaultDisplay
				();
			d.getRectSize(outRect);
		}

		/// <summary>
		/// Dispatch a notification about a resource configuration change down
		/// the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Dispatch a notification about a resource configuration change down
		/// the view hierarchy.
		/// ViewGroups should override to route to their children.
		/// </remarks>
		/// <param name="newConfig">The new resource configuration.</param>
		/// <seealso cref="onConfigurationChanged(android.content.res.Configuration)"></seealso>
		public virtual void dispatchConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			onConfigurationChanged(newConfig);
		}

		/// <summary>
		/// Called when the current configuration of the resources being used
		/// by the application have changed.
		/// </summary>
		/// <remarks>
		/// Called when the current configuration of the resources being used
		/// by the application have changed.  You can use this to decide when
		/// to reload resources that can changed based on orientation and other
		/// configuration characterstics.  You only need to use this if you are
		/// not relying on the normal
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// mechanism of
		/// recreating the activity instance upon a configuration change.
		/// </remarks>
		/// <param name="newConfig">The new resource configuration.</param>
		protected internal virtual void onConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
		}

		/// <summary>
		/// Private function to aggregate all per-view attributes in to the view
		/// root.
		/// </summary>
		/// <remarks>
		/// Private function to aggregate all per-view attributes in to the view
		/// root.
		/// </remarks>
		internal virtual void dispatchCollectViewAttributes(int visibility)
		{
			performCollectViewAttributes(visibility);
		}

		internal virtual void performCollectViewAttributes(int visibility)
		{
			if ((visibility & VISIBILITY_MASK) == VISIBLE && mAttachInfo != null)
			{
				if ((mViewFlags & KEEP_SCREEN_ON) == KEEP_SCREEN_ON)
				{
					mAttachInfo.mKeepScreenOn = true;
				}
				mAttachInfo.mSystemUiVisibility |= mSystemUiVisibility;
				if (mOnSystemUiVisibilityChangeListener != null)
				{
					mAttachInfo.mHasSystemUiListeners = true;
				}
			}
		}

		internal virtual void needGlobalAttributesUpdate(bool force)
		{
			android.view.View.AttachInfo ai = mAttachInfo;
			if (ai != null)
			{
				if (force || ai.mKeepScreenOn || (ai.mSystemUiVisibility != 0) || ai.mHasSystemUiListeners)
				{
					ai.mRecomputeGlobalAttributes = true;
				}
			}
		}

		/// <summary>Returns whether the device is currently in touch mode.</summary>
		/// <remarks>
		/// Returns whether the device is currently in touch mode.  Touch mode is entered
		/// once the user begins interacting with the device by touch, and affects various
		/// things like whether focus is always visible to the user.
		/// </remarks>
		/// <returns>Whether the device is in touch mode.</returns>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isInTouchMode()
		{
			if (mAttachInfo != null)
			{
				return mAttachInfo.mInTouchMode;
			}
			else
			{
				return android.view.ViewRootImpl.isInTouchMode();
			}
		}

		/// <summary>
		/// Returns the context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </summary>
		/// <remarks>
		/// Returns the context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </remarks>
		/// <returns>The view's Context.</returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public android.content.Context getContext()
		{
			return mContext;
		}

		/// <summary>
		/// Handle a key event before it is processed by any input method
		/// associated with the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Handle a key event before it is processed by any input method
		/// associated with the view hierarchy.  This can be used to intercept
		/// key events in special situations before the IME consumes them; a
		/// typical example would be handling the BACK key to update the application's
		/// UI instead of allowing the IME to see it and close itself.
		/// </remarks>
		/// <param name="keyCode">The value in event.getKeyCode().</param>
		/// <param name="event">Description of the key event.</param>
		/// <returns>
		/// If you handled the event, return true. If you want to allow the
		/// event to be handled by the next receiver, return false.
		/// </returns>
		public virtual bool onKeyPreIme(int keyCode, android.view.KeyEvent @event)
		{
			return false;
		}

		/// <summary>
		/// Default implementation of
		/// <see cref="Callback.onKeyDown(int, KeyEvent)">KeyEvent.Callback.onKeyDown()</see>
		/// : perform press of the view
		/// when
		/// <see cref="KeyEvent.KEYCODE_DPAD_CENTER">KeyEvent.KEYCODE_DPAD_CENTER</see>
		/// or
		/// <see cref="KeyEvent.KEYCODE_ENTER">KeyEvent.KEYCODE_ENTER</see>
		/// is released, if the view is enabled and clickable.
		/// </summary>
		/// <param name="keyCode">
		/// A key code that represents the button pressed, from
		/// <see cref="KeyEvent">KeyEvent</see>
		/// .
		/// </param>
		/// <param name="event">The KeyEvent object that defines the button action.</param>
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			bool result = false;
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					if ((mViewFlags & ENABLED_MASK) == DISABLED)
					{
						return true;
					}
					// Long clickable items don't necessarily have to be clickable
					if (((mViewFlags & CLICKABLE) == CLICKABLE || (mViewFlags & LONG_CLICKABLE) == LONG_CLICKABLE
						) && (@event.getRepeatCount() == 0))
					{
						setPressed(true);
						checkForLongClick(0);
						return true;
					}
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Default implementation of
		/// <see cref="Callback.onKeyLongPress(int, KeyEvent)">KeyEvent.Callback.onKeyLongPress()
		/// 	</see>
		/// : always returns false (doesn't handle
		/// the event).
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyLongPress(int keyCode, android.view.KeyEvent @event)
		{
			return false;
		}

		/// <summary>
		/// Default implementation of
		/// <see cref="Callback.onKeyUp(int, KeyEvent)">KeyEvent.Callback.onKeyUp()</see>
		/// : perform clicking of the view
		/// when
		/// <see cref="KeyEvent.KEYCODE_DPAD_CENTER">KeyEvent.KEYCODE_DPAD_CENTER</see>
		/// or
		/// <see cref="KeyEvent.KEYCODE_ENTER">KeyEvent.KEYCODE_ENTER</see>
		/// is released.
		/// </summary>
		/// <param name="keyCode">
		/// A key code that represents the button pressed, from
		/// <see cref="KeyEvent">KeyEvent</see>
		/// .
		/// </param>
		/// <param name="event">The KeyEvent object that defines the button action.</param>
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			bool result = false;
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					if ((mViewFlags & ENABLED_MASK) == DISABLED)
					{
						return true;
					}
					if ((mViewFlags & CLICKABLE) == CLICKABLE && isPressed())
					{
						setPressed(false);
						if (!mHasPerformedLongPress)
						{
							// This is a tap, so remove the longpress check
							removeLongPressCallback();
							result = performClick();
						}
					}
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Default implementation of
		/// <see cref="Callback.onKeyMultiple(int, int, KeyEvent)">KeyEvent.Callback.onKeyMultiple()
		/// 	</see>
		/// : always returns false (doesn't handle
		/// the event).
		/// </summary>
		/// <param name="keyCode">
		/// A key code that represents the button pressed, from
		/// <see cref="KeyEvent">KeyEvent</see>
		/// .
		/// </param>
		/// <param name="repeatCount">The number of times the action was made.</param>
		/// <param name="event">The KeyEvent object that defines the button action.</param>
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyMultiple(int keyCode, int repeatCount, android.view.KeyEvent
			 @event)
		{
			return false;
		}

		/// <summary>Called on the focused view when a key shortcut event is not handled.</summary>
		/// <remarks>
		/// Called on the focused view when a key shortcut event is not handled.
		/// Override this method to implement local key shortcuts for the View.
		/// Key shortcuts can also be implemented by setting the
		/// <see cref="MenuItem.setShortcut(char, char)">shortcut</see>
		/// property of menu items.
		/// </remarks>
		/// <param name="keyCode">The value in event.getKeyCode().</param>
		/// <param name="event">Description of the key event.</param>
		/// <returns>
		/// If you handled the event, return true. If you want to allow the
		/// event to be handled by the next receiver, return false.
		/// </returns>
		public virtual bool onKeyShortcut(int keyCode, android.view.KeyEvent @event)
		{
			return false;
		}

		/// <summary>
		/// Check whether the called view is a text editor, in which case it
		/// would make sense to automatically display a soft input window for
		/// it.
		/// </summary>
		/// <remarks>
		/// Check whether the called view is a text editor, in which case it
		/// would make sense to automatically display a soft input window for
		/// it.  Subclasses should override this if they implement
		/// <see cref="onCreateInputConnection(android.view.inputmethod.EditorInfo)">onCreateInputConnection(android.view.inputmethod.EditorInfo)
		/// 	</see>
		/// to return true if
		/// a call on that method would return a non-null InputConnection, and
		/// they are really a first-class editor that the user would normally
		/// start typing on when the go into a window containing your view.
		/// <p>The default implementation always returns false.  This does
		/// <em>not</em> mean that its
		/// <see cref="onCreateInputConnection(android.view.inputmethod.EditorInfo)">onCreateInputConnection(android.view.inputmethod.EditorInfo)
		/// 	</see>
		/// will not be called or the user can not otherwise perform edits on your
		/// view; it is just a hint to the system that this is not the primary
		/// purpose of this view.
		/// </remarks>
		/// <returns>Returns true if this view is a text editor, else false.</returns>
		public virtual bool onCheckIsTextEditor()
		{
			return false;
		}

		/// <summary>
		/// Create a new InputConnection for an InputMethod to interact
		/// with the view.
		/// </summary>
		/// <remarks>
		/// Create a new InputConnection for an InputMethod to interact
		/// with the view.  The default implementation returns null, since it doesn't
		/// support input methods.  You can override this to implement such support.
		/// This is only needed for views that take focus and text input.
		/// <p>When implementing this, you probably also want to implement
		/// <see cref="onCheckIsTextEditor()">onCheckIsTextEditor()</see>
		/// to indicate you will return a
		/// non-null InputConnection.
		/// </remarks>
		/// <param name="outAttrs">Fill in with attribute information about the connection.</param>
		public virtual android.view.inputmethod.InputConnection onCreateInputConnection(android.view.inputmethod.EditorInfo
			 outAttrs)
		{
			return null;
		}

		/// <summary>
		/// Called by the
		/// <see cref="android.view.inputmethod.InputMethodManager">android.view.inputmethod.InputMethodManager
		/// 	</see>
		/// when a view who is not the current
		/// input connection target is trying to make a call on the manager.  The
		/// default implementation returns false; you can override this to return
		/// true for certain views if you are performing InputConnection proxying
		/// to them.
		/// </summary>
		/// <param name="view">The View that is making the InputMethodManager call.</param>
		/// <returns>Return true to allow the call, false to reject.</returns>
		public virtual bool checkInputConnectionProxy(android.view.View view)
		{
			return false;
		}

		/// <summary>Show the context menu for this view.</summary>
		/// <remarks>
		/// Show the context menu for this view. It is not safe to hold on to the
		/// menu after returning from this method.
		/// You should normally not overload this method. Overload
		/// <see cref="onCreateContextMenu(ContextMenu)">onCreateContextMenu(ContextMenu)</see>
		/// or define an
		/// <see cref="OnCreateContextMenuListener">OnCreateContextMenuListener</see>
		/// to add items to the context menu.
		/// </remarks>
		/// <param name="menu">The context menu to populate</param>
		public virtual void createContextMenu(android.view.ContextMenu menu)
		{
			android.view.ContextMenuClass.ContextMenuInfo menuInfo = getContextMenuInfo();
			// Sets the current menu info so all items added to menu will have
			// my extra info set.
			((android.view.@internal.menu.MenuBuilder)menu).setCurrentMenuInfo(menuInfo);
			onCreateContextMenu(menu);
			if (mOnCreateContextMenuListener != null)
			{
				mOnCreateContextMenuListener.onCreateContextMenu(menu, this, menuInfo);
			}
			// Clear the extra information so subsequent items that aren't mine don't
			// have my extra info.
			((android.view.@internal.menu.MenuBuilder)menu).setCurrentMenuInfo(null);
			if (mParent != null)
			{
				mParent.createContextMenu(menu);
			}
		}

		/// <summary>
		/// Views should implement this if they have extra information to associate
		/// with the context menu.
		/// </summary>
		/// <remarks>
		/// Views should implement this if they have extra information to associate
		/// with the context menu. The return result is supplied as a parameter to
		/// the
		/// <see cref="OnCreateContextMenuListener.onCreateContextMenu(ContextMenu, View, ContextMenuInfo)
		/// 	">OnCreateContextMenuListener.onCreateContextMenu(ContextMenu, View, ContextMenuInfo)
		/// 	</see>
		/// callback.
		/// </remarks>
		/// <returns>
		/// Extra information about the item for which the context menu
		/// should be shown. This information will vary across different
		/// subclasses of View.
		/// </returns>
		protected internal virtual android.view.ContextMenuClass.ContextMenuInfo getContextMenuInfo
			()
		{
			return null;
		}

		/// <summary>
		/// Views should implement this if the view itself is going to add items to
		/// the context menu.
		/// </summary>
		/// <remarks>
		/// Views should implement this if the view itself is going to add items to
		/// the context menu.
		/// </remarks>
		/// <param name="menu">the context menu to populate</param>
		protected internal virtual void onCreateContextMenu(android.view.ContextMenu menu
			)
		{
		}

		/// <summary>Implement this method to handle trackball motion events.</summary>
		/// <remarks>
		/// Implement this method to handle trackball motion events.  The
		/// <em>relative</em> movement of the trackball since the last event
		/// can be retrieve with
		/// <see cref="MotionEvent.getX()">MotionEvent.getX()</see>
		/// and
		/// <see cref="MotionEvent.getY()">MotionEvent.getY()</see>
		/// .  These are normalized so
		/// that a movement of 1 corresponds to the user pressing one DPAD key (so
		/// they will often be fractional values, representing the more fine-grained
		/// movement information available from a trackball).
		/// </remarks>
		/// <param name="event">The motion event.</param>
		/// <returns>True if the event was handled, false otherwise.</returns>
		public virtual bool onTrackballEvent(android.view.MotionEvent @event)
		{
			return false;
		}

		/// <summary>Implement this method to handle generic motion events.</summary>
		/// <remarks>
		/// Implement this method to handle generic motion events.
		/// <p>
		/// Generic motion events describe joystick movements, mouse hovers, track pad
		/// touches, scroll wheel movements and other input events.  The
		/// <see cref="MotionEvent.getSource()">source</see>
		/// of the motion event specifies
		/// the class of input that was received.  Implementations of this method
		/// must examine the bits in the source before processing the event.
		/// The following code example shows how this is done.
		/// </p><p>
		/// Generic motion events with source class
		/// <see cref="InputDevice.SOURCE_CLASS_POINTER">InputDevice.SOURCE_CLASS_POINTER</see>
		/// are delivered to the view under the pointer.  All other generic motion events are
		/// delivered to the focused view.
		/// </p>
		/// <pre> public boolean onGenericMotionEvent(MotionEvent event) {
		/// if ((event.getSource() &amp; InputDevice.SOURCE_CLASS_JOYSTICK) != 0) {
		/// if (event.getAction() == MotionEvent.ACTION_MOVE) {
		/// // process the joystick movement...
		/// return true;
		/// }
		/// }
		/// if ((event.getSource() &amp; InputDevice.SOURCE_CLASS_POINTER) != 0) {
		/// switch (event.getAction()) {
		/// case MotionEvent.ACTION_HOVER_MOVE:
		/// // process the mouse hover movement...
		/// return true;
		/// case MotionEvent.ACTION_SCROLL:
		/// // process the scroll wheel movement...
		/// return true;
		/// }
		/// }
		/// return super.onGenericMotionEvent(event);
		/// }</pre>
		/// </remarks>
		/// <param name="event">The generic motion event being processed.</param>
		/// <returns>True if the event was handled, false otherwise.</returns>
		public virtual bool onGenericMotionEvent(android.view.MotionEvent @event)
		{
			return false;
		}

		/// <summary>Implement this method to handle hover events.</summary>
		/// <remarks>
		/// Implement this method to handle hover events.
		/// <p>
		/// This method is called whenever a pointer is hovering into, over, or out of the
		/// bounds of a view and the view is not currently being touched.
		/// Hover events are represented as pointer events with action
		/// <see cref="MotionEvent.ACTION_HOVER_ENTER">MotionEvent.ACTION_HOVER_ENTER</see>
		/// ,
		/// <see cref="MotionEvent.ACTION_HOVER_MOVE">MotionEvent.ACTION_HOVER_MOVE</see>
		/// ,
		/// or
		/// <see cref="MotionEvent.ACTION_HOVER_EXIT">MotionEvent.ACTION_HOVER_EXIT</see>
		/// .
		/// </p>
		/// <ul>
		/// <li>The view receives a hover event with action
		/// <see cref="MotionEvent.ACTION_HOVER_ENTER">MotionEvent.ACTION_HOVER_ENTER</see>
		/// when the pointer enters the bounds of the view.</li>
		/// <li>The view receives a hover event with action
		/// <see cref="MotionEvent.ACTION_HOVER_MOVE">MotionEvent.ACTION_HOVER_MOVE</see>
		/// when the pointer has already entered the bounds of the view and has moved.</li>
		/// <li>The view receives a hover event with action
		/// <see cref="MotionEvent.ACTION_HOVER_EXIT">MotionEvent.ACTION_HOVER_EXIT</see>
		/// when the pointer has exited the bounds of the view or when the pointer is
		/// about to go down due to a button click, tap, or similar user action that
		/// causes the view to be touched.</li>
		/// </ul>
		/// <p>
		/// The view should implement this method to return true to indicate that it is
		/// handling the hover event, such as by changing its drawable state.
		/// </p><p>
		/// The default implementation calls
		/// <see cref="setHovered(bool)">setHovered(bool)</see>
		/// to update the hovered state
		/// of the view when a hover enter or hover exit event is received, if the view
		/// is enabled and is clickable.  The default implementation also sends hover
		/// accessibility events.
		/// </p>
		/// </remarks>
		/// <param name="event">The motion event that describes the hover.</param>
		/// <returns>True if the view handled the hover event.</returns>
		/// <seealso cref="isHovered()">isHovered()</seealso>
		/// <seealso cref="setHovered(bool)">setHovered(bool)</seealso>
		/// <seealso cref="onHoverChanged(bool)">onHoverChanged(bool)</seealso>
		public virtual bool onHoverEvent(android.view.MotionEvent @event)
		{
			// The root view may receive hover (or touch) events that are outside the bounds of
			// the window.  This code ensures that we only send accessibility events for
			// hovers that are actually within the bounds of the root view.
			int action = @event.getAction();
			if (!mSendingHoverAccessibilityEvents)
			{
				if ((action == android.view.MotionEvent.ACTION_HOVER_ENTER || action == android.view.MotionEvent
					.ACTION_HOVER_MOVE) && !hasHoveredChild() && pointInView(@event.getX(), @event.getY
					()))
				{
					mSendingHoverAccessibilityEvents = true;
					sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_HOVER_ENTER
						);
				}
			}
			else
			{
				if (action == android.view.MotionEvent.ACTION_HOVER_EXIT || (action == android.view.MotionEvent
					.ACTION_HOVER_MOVE && !pointInView(@event.getX(), @event.getY())))
				{
					mSendingHoverAccessibilityEvents = false;
					sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_HOVER_EXIT
						);
				}
			}
			if (isHoverable())
			{
				switch (action)
				{
					case android.view.MotionEvent.ACTION_HOVER_ENTER:
					{
						setHovered(true);
						break;
					}

					case android.view.MotionEvent.ACTION_HOVER_EXIT:
					{
						setHovered(false);
						break;
					}
				}
				// Dispatch the event to onGenericMotionEvent before returning true.
				// This is to provide compatibility with existing applications that
				// handled HOVER_MOVE events in onGenericMotionEvent and that would
				// break because of the new default handling for hoverable views
				// in onHoverEvent.
				// Note that onGenericMotionEvent will be called by default when
				// onHoverEvent returns false (refer to dispatchGenericMotionEvent).
				dispatchGenericMotionEventInternal(@event);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Returns true if the view should handle
		/// <see cref="onHoverEvent(MotionEvent)">onHoverEvent(MotionEvent)</see>
		/// by calling
		/// <see cref="setHovered(bool)">setHovered(bool)</see>
		/// to change its hovered state.
		/// </summary>
		/// <returns>True if the view is hoverable.</returns>
		private bool isHoverable()
		{
			int viewFlags = mViewFlags;
			//noinspection SimplifiableIfStatement
			if ((viewFlags & ENABLED_MASK) == DISABLED)
			{
				return false;
			}
			return (viewFlags & CLICKABLE) == CLICKABLE || (viewFlags & LONG_CLICKABLE) == LONG_CLICKABLE;
		}

		/// <summary>Returns true if the view is currently hovered.</summary>
		/// <remarks>Returns true if the view is currently hovered.</remarks>
		/// <returns>True if the view is currently hovered.</returns>
		/// <seealso cref="setHovered(bool)">setHovered(bool)</seealso>
		/// <seealso cref="onHoverChanged(bool)">onHoverChanged(bool)</seealso>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isHovered()
		{
			return (mPrivateFlags & HOVERED) != 0;
		}

		/// <summary>Sets whether the view is currently hovered.</summary>
		/// <remarks>
		/// Sets whether the view is currently hovered.
		/// <p>
		/// Calling this method also changes the drawable state of the view.  This
		/// enables the view to react to hover by using different drawable resources
		/// to change its appearance.
		/// </p><p>
		/// The
		/// <see cref="onHoverChanged(bool)">onHoverChanged(bool)</see>
		/// method is called when the hovered state changes.
		/// </p>
		/// </remarks>
		/// <param name="hovered">True if the view is hovered.</param>
		/// <seealso cref="isHovered()">isHovered()</seealso>
		/// <seealso cref="onHoverChanged(bool)">onHoverChanged(bool)</seealso>
		public virtual void setHovered(bool hovered)
		{
			if (hovered)
			{
				if ((mPrivateFlags & HOVERED) == 0)
				{
					mPrivateFlags |= HOVERED;
					refreshDrawableState();
					onHoverChanged(true);
				}
			}
			else
			{
				if ((mPrivateFlags & HOVERED) != 0)
				{
					mPrivateFlags &= ~HOVERED;
					refreshDrawableState();
					onHoverChanged(false);
				}
			}
		}

		/// <summary>Implement this method to handle hover state changes.</summary>
		/// <remarks>
		/// Implement this method to handle hover state changes.
		/// <p>
		/// This method is called whenever the hover state changes as a result of a
		/// call to
		/// <see cref="setHovered(bool)">setHovered(bool)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="hovered">
		/// The current hover state, as returned by
		/// <see cref="isHovered()">isHovered()</see>
		/// .
		/// </param>
		/// <seealso cref="isHovered()">isHovered()</seealso>
		/// <seealso cref="setHovered(bool)">setHovered(bool)</seealso>
		public virtual void onHoverChanged(bool hovered)
		{
		}

		/// <summary>Implement this method to handle touch screen motion events.</summary>
		/// <remarks>Implement this method to handle touch screen motion events.</remarks>
		/// <param name="event">The motion event.</param>
		/// <returns>True if the event was handled, false otherwise.</returns>
		public virtual bool onTouchEvent(android.view.MotionEvent @event)
		{
			int viewFlags = mViewFlags;
			if ((viewFlags & ENABLED_MASK) == DISABLED)
			{
				if (@event.getAction() == android.view.MotionEvent.ACTION_UP && (mPrivateFlags & 
					PRESSED) != 0)
				{
					mPrivateFlags &= ~PRESSED;
					refreshDrawableState();
				}
				// A disabled view that is clickable still consumes the touch
				// events, it just doesn't respond to them.
				return (((viewFlags & CLICKABLE) == CLICKABLE || (viewFlags & LONG_CLICKABLE) == 
					LONG_CLICKABLE));
			}
			if (mTouchDelegate != null)
			{
				if (mTouchDelegate.onTouchEvent(@event))
				{
					return true;
				}
			}
			if (((viewFlags & CLICKABLE) == CLICKABLE || (viewFlags & LONG_CLICKABLE) == LONG_CLICKABLE
				))
			{
				switch (@event.getAction())
				{
					case android.view.MotionEvent.ACTION_UP:
					{
						bool prepressed = (mPrivateFlags & PREPRESSED) != 0;
						if ((mPrivateFlags & PRESSED) != 0 || prepressed)
						{
							// take focus if we don't have it already and we should in
							// touch mode.
							bool focusTaken = false;
							if (isFocusable() && isFocusableInTouchMode() && !isFocused())
							{
								focusTaken = requestFocus();
							}
							if (prepressed)
							{
								// The button is being released before we actually
								// showed it as pressed.  Make it show the pressed
								// state now (before scheduling the click) to ensure
								// the user sees it.
								mPrivateFlags |= PRESSED;
								refreshDrawableState();
							}
							if (!mHasPerformedLongPress)
							{
								// This is a tap, so remove the longpress check
								removeLongPressCallback();
								// Only perform take click actions if we were in the pressed state
								if (!focusTaken)
								{
									// Use a Runnable and post this rather than calling
									// performClick directly. This lets other visual state
									// of the view update before click actions start.
									if (mPerformClick == null)
									{
										mPerformClick = new android.view.View.PerformClick(this);
									}
									if (!post(mPerformClick))
									{
										performClick();
									}
								}
							}
							if (mUnsetPressedState == null)
							{
								mUnsetPressedState = new android.view.View.UnsetPressedState(this);
							}
							if (prepressed)
							{
								postDelayed(mUnsetPressedState, android.view.ViewConfiguration.getPressedStateDuration
									());
							}
							else
							{
								if (!post(mUnsetPressedState))
								{
									// If the post failed, unpress right now
									mUnsetPressedState.run();
								}
							}
							removeTapCallback();
						}
						break;
					}

					case android.view.MotionEvent.ACTION_DOWN:
					{
						mHasPerformedLongPress = false;
						if (performButtonActionOnTouchDown(@event))
						{
							break;
						}
						// Walk up the hierarchy to determine if we're inside a scrolling container.
						bool isInScrollingContainer_1 = isInScrollingContainer();
						// For views inside a scrolling container, delay the pressed feedback for
						// a short period in case this is a scroll.
						if (isInScrollingContainer_1)
						{
							mPrivateFlags |= PREPRESSED;
							if (mPendingCheckForTap == null)
							{
								mPendingCheckForTap = new android.view.View.CheckForTap(this);
							}
							postDelayed(mPendingCheckForTap, android.view.ViewConfiguration.getTapTimeout());
						}
						else
						{
							// Not inside a scrolling container, so show the feedback right away
							mPrivateFlags |= PRESSED;
							refreshDrawableState();
							checkForLongClick(0);
						}
						break;
					}

					case android.view.MotionEvent.ACTION_CANCEL:
					{
						mPrivateFlags &= ~PRESSED;
						refreshDrawableState();
						removeTapCallback();
						break;
					}

					case android.view.MotionEvent.ACTION_MOVE:
					{
						int x = (int)@event.getX();
						int y = (int)@event.getY();
						// Be lenient about moving outside of buttons
						if (!pointInView(x, y, mTouchSlop))
						{
							// Outside button
							removeTapCallback();
							if ((mPrivateFlags & PRESSED) != 0)
							{
								// Remove any future long press/tap checks
								removeLongPressCallback();
								// Need to switch from pressed to not pressed
								mPrivateFlags &= ~PRESSED;
								refreshDrawableState();
							}
						}
						break;
					}
				}
				return true;
			}
			return false;
		}

		/// <hide></hide>
		public virtual bool isInScrollingContainer()
		{
			android.view.ViewParent p = getParent();
			while (p != null && p is android.view.ViewGroup)
			{
				if (((android.view.ViewGroup)p).shouldDelayChildPressedState())
				{
					return true;
				}
				p = p.getParent();
			}
			return false;
		}

		/// <summary>Remove the longpress detection timer.</summary>
		/// <remarks>Remove the longpress detection timer.</remarks>
		private void removeLongPressCallback()
		{
			if (mPendingCheckForLongPress != null)
			{
				removeCallbacks(mPendingCheckForLongPress);
			}
		}

		/// <summary>Remove the pending click action</summary>
		private void removePerformClickCallback()
		{
			if (mPerformClick != null)
			{
				removeCallbacks(mPerformClick);
			}
		}

		/// <summary>Remove the prepress detection timer.</summary>
		/// <remarks>Remove the prepress detection timer.</remarks>
		private void removeUnsetPressCallback()
		{
			if ((mPrivateFlags & PRESSED) != 0 && mUnsetPressedState != null)
			{
				setPressed(false);
				removeCallbacks(mUnsetPressedState);
			}
		}

		/// <summary>Remove the tap detection timer.</summary>
		/// <remarks>Remove the tap detection timer.</remarks>
		private void removeTapCallback()
		{
			if (mPendingCheckForTap != null)
			{
				mPrivateFlags &= ~PREPRESSED;
				removeCallbacks(mPendingCheckForTap);
			}
		}

		/// <summary>Cancels a pending long press.</summary>
		/// <remarks>
		/// Cancels a pending long press.  Your subclass can use this if you
		/// want the context menu to come up if the user presses and holds
		/// at the same place, but you don't want it to come up if they press
		/// and then move around enough to cause scrolling.
		/// </remarks>
		public virtual void cancelLongPress()
		{
			removeLongPressCallback();
			removeTapCallback();
		}

		/// <summary>
		/// Remove the pending callback for sending a
		/// <see cref="android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED">android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED
		/// 	</see>
		/// accessibility event.
		/// </summary>
		private void removeSendViewScrolledAccessibilityEventCallback()
		{
			if (mSendViewScrolledAccessibilityEvent != null)
			{
				removeCallbacks(mSendViewScrolledAccessibilityEvent);
			}
		}

		/// <summary>Sets the TouchDelegate for this View.</summary>
		/// <remarks>Sets the TouchDelegate for this View.</remarks>
		public virtual void setTouchDelegate(android.view.TouchDelegate @delegate)
		{
			mTouchDelegate = @delegate;
		}

		/// <summary>Gets the TouchDelegate for this View.</summary>
		/// <remarks>Gets the TouchDelegate for this View.</remarks>
		public virtual android.view.TouchDelegate getTouchDelegate()
		{
			return mTouchDelegate;
		}

		/// <summary>Set flags controlling behavior of this view.</summary>
		/// <remarks>Set flags controlling behavior of this view.</remarks>
		/// <param name="flags">Constant indicating the value which should be set</param>
		/// <param name="mask">Constant indicating the bit range that should be changed</param>
		internal virtual void setFlags(int flags, int mask)
		{
			int old = mViewFlags;
			mViewFlags = (mViewFlags & ~mask) | (flags & mask);
			int changed = mViewFlags ^ old;
			if (changed == 0)
			{
				return;
			}
			int privateFlags = mPrivateFlags;
			if (((changed & FOCUSABLE_MASK) != 0) && ((privateFlags & HAS_BOUNDS) != 0))
			{
				if (((old & FOCUSABLE_MASK) == FOCUSABLE) && ((privateFlags & FOCUSED) != 0))
				{
					clearFocus();
				}
				else
				{
					if (((old & FOCUSABLE_MASK) == NOT_FOCUSABLE) && ((privateFlags & FOCUSED) == 0))
					{
						if (mParent != null)
						{
							mParent.focusableViewAvailable(this);
						}
					}
				}
			}
			if ((flags & VISIBILITY_MASK) == VISIBLE)
			{
				if ((changed & VISIBILITY_MASK) != 0)
				{
					mPrivateFlags |= DRAWN;
					invalidate(true);
					needGlobalAttributesUpdate(true);
					// a view becoming visible is worth notifying the parent
					// about in case nothing has focus.  even if this specific view
					// isn't focusable, it may contain something that is, so let
					// the root view try to give this focus if nothing else does.
					if ((mParent != null) && (mBottom > mTop) && (mRight > mLeft))
					{
						mParent.focusableViewAvailable(this);
					}
				}
			}
			if ((changed & GONE) != 0)
			{
				needGlobalAttributesUpdate(false);
				requestLayout();
				if (((mViewFlags & VISIBILITY_MASK) == GONE))
				{
					if (hasFocus())
					{
						clearFocus();
					}
					destroyDrawingCache();
					if (mParent is android.view.View)
					{
						// GONE views noop invalidation, so invalidate the parent
						((android.view.View)mParent).invalidate(true);
					}
					// Mark the view drawn to ensure that it gets invalidated properly the next
					// time it is visible and gets invalidated
					mPrivateFlags |= DRAWN;
				}
				if (mAttachInfo != null)
				{
					mAttachInfo.mViewVisibilityChanged = true;
				}
			}
			if ((changed & INVISIBLE) != 0)
			{
				needGlobalAttributesUpdate(false);
				mPrivateFlags |= DRAWN;
				if (((mViewFlags & VISIBILITY_MASK) == INVISIBLE) && hasFocus())
				{
					// root view becoming invisible shouldn't clear focus
					if (getRootView() != this)
					{
						clearFocus();
					}
				}
				if (mAttachInfo != null)
				{
					mAttachInfo.mViewVisibilityChanged = true;
				}
			}
			if ((changed & VISIBILITY_MASK) != 0)
			{
				if (mParent is android.view.ViewGroup)
				{
					((android.view.ViewGroup)mParent).onChildVisibilityChanged(this, (flags & VISIBILITY_MASK
						));
					((android.view.View)mParent).invalidate(true);
				}
				else
				{
					if (mParent != null)
					{
						mParent.invalidateChild(this, null);
					}
				}
				dispatchVisibilityChanged(this, (flags & VISIBILITY_MASK));
			}
			if ((changed & WILL_NOT_CACHE_DRAWING) != 0)
			{
				destroyDrawingCache();
			}
			if ((changed & DRAWING_CACHE_ENABLED) != 0)
			{
				destroyDrawingCache();
				mPrivateFlags &= ~DRAWING_CACHE_VALID;
				invalidateParentCaches();
			}
			if ((changed & DRAWING_CACHE_QUALITY_MASK) != 0)
			{
				destroyDrawingCache();
				mPrivateFlags &= ~DRAWING_CACHE_VALID;
			}
			if ((changed & DRAW_MASK) != 0)
			{
				if ((mViewFlags & WILL_NOT_DRAW) != 0)
				{
					if (mBGDrawable != null)
					{
						mPrivateFlags &= ~SKIP_DRAW;
						mPrivateFlags |= ONLY_DRAWS_BACKGROUND;
					}
					else
					{
						mPrivateFlags |= SKIP_DRAW;
					}
				}
				else
				{
					mPrivateFlags &= ~SKIP_DRAW;
				}
				requestLayout();
				invalidate(true);
			}
			if ((changed & KEEP_SCREEN_ON) != 0)
			{
				if (mParent != null && mAttachInfo != null && !mAttachInfo.mRecomputeGlobalAttributes)
				{
					mParent.recomputeViewAttributes(this);
				}
			}
			if ((changed & LAYOUT_DIRECTION_MASK) != 0)
			{
				requestLayout();
			}
		}

		/// <summary>
		/// Change the view's z order in the tree, so it's on top of other sibling
		/// views
		/// </summary>
		public virtual void bringToFront()
		{
			if (mParent != null)
			{
				mParent.bringChildToFront(this);
			}
		}

		/// <summary>
		/// This is called in response to an internal scroll in this view (i.e., the
		/// view scrolled its own contents).
		/// </summary>
		/// <remarks>
		/// This is called in response to an internal scroll in this view (i.e., the
		/// view scrolled its own contents). This is typically as a result of
		/// <see cref="scrollBy(int, int)">scrollBy(int, int)</see>
		/// or
		/// <see cref="scrollTo(int, int)">scrollTo(int, int)</see>
		/// having been
		/// called.
		/// </remarks>
		/// <param name="l">Current horizontal scroll origin.</param>
		/// <param name="t">Current vertical scroll origin.</param>
		/// <param name="oldl">Previous horizontal scroll origin.</param>
		/// <param name="oldt">Previous vertical scroll origin.</param>
		protected internal virtual void onScrollChanged(int l, int t, int oldl, int oldt)
		{
			if (android.view.accessibility.AccessibilityManager.getInstance(mContext).isEnabled
				())
			{
				postSendViewScrolledAccessibilityEventCallback();
			}
			mBackgroundSizeChanged = true;
			android.view.View.AttachInfo ai = mAttachInfo;
			if (ai != null)
			{
				ai.mViewScrollChanged = true;
			}
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the layout bounds of a view
		/// changes due to layout processing.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the layout bounds of a view
		/// changes due to layout processing.
		/// </remarks>
		public interface OnLayoutChangeListener
		{
			/// <summary>Called when the focus state of a view has changed.</summary>
			/// <remarks>Called when the focus state of a view has changed.</remarks>
			/// <param name="v">The view whose state has changed.</param>
			/// <param name="left">The new value of the view's left property.</param>
			/// <param name="top">The new value of the view's top property.</param>
			/// <param name="right">The new value of the view's right property.</param>
			/// <param name="bottom">The new value of the view's bottom property.</param>
			/// <param name="oldLeft">The previous value of the view's left property.</param>
			/// <param name="oldTop">The previous value of the view's top property.</param>
			/// <param name="oldRight">The previous value of the view's right property.</param>
			/// <param name="oldBottom">The previous value of the view's bottom property.</param>
			void onLayoutChange(android.view.View v, int left, int top, int right, int bottom
				, int oldLeft, int oldTop, int oldRight, int oldBottom);
		}

		/// <summary>This is called during layout when the size of this view has changed.</summary>
		/// <remarks>
		/// This is called during layout when the size of this view has changed. If
		/// you were just added to the view hierarchy, you're called with the old
		/// values of 0.
		/// </remarks>
		/// <param name="w">Current width of this view.</param>
		/// <param name="h">Current height of this view.</param>
		/// <param name="oldw">Old width of this view.</param>
		/// <param name="oldh">Old height of this view.</param>
		protected internal virtual void onSizeChanged(int w, int h, int oldw, int oldh)
		{
		}

		/// <summary>Called by draw to draw the child views.</summary>
		/// <remarks>
		/// Called by draw to draw the child views. This may be overridden
		/// by derived classes to gain control just before its children are drawn
		/// (but after its own view has been drawn).
		/// </remarks>
		/// <param name="canvas">the canvas on which to draw the view</param>
		protected internal virtual void dispatchDraw(android.graphics.Canvas canvas)
		{
		}

		/// <summary>Gets the parent of this view.</summary>
		/// <remarks>
		/// Gets the parent of this view. Note that the parent is a
		/// ViewParent and not necessarily a View.
		/// </remarks>
		/// <returns>Parent of this view.</returns>
		public android.view.ViewParent getParent()
		{
			return mParent;
		}

		/// <summary>Set the horizontal scrolled position of your view.</summary>
		/// <remarks>
		/// Set the horizontal scrolled position of your view. This will cause a call to
		/// <see cref="onScrollChanged(int, int, int, int)">onScrollChanged(int, int, int, int)
		/// 	</see>
		/// and the view will be
		/// invalidated.
		/// </remarks>
		/// <param name="value">the x position to scroll to</param>
		public virtual void setScrollX(int value)
		{
			scrollTo(value, mScrollY);
		}

		/// <summary>Set the vertical scrolled position of your view.</summary>
		/// <remarks>
		/// Set the vertical scrolled position of your view. This will cause a call to
		/// <see cref="onScrollChanged(int, int, int, int)">onScrollChanged(int, int, int, int)
		/// 	</see>
		/// and the view will be
		/// invalidated.
		/// </remarks>
		/// <param name="value">the y position to scroll to</param>
		public virtual void setScrollY(int value)
		{
			scrollTo(mScrollX, value);
		}

		/// <summary>Return the scrolled left position of this view.</summary>
		/// <remarks>
		/// Return the scrolled left position of this view. This is the left edge of
		/// the displayed part of your view. You do not need to draw any pixels
		/// farther left, since those are outside of the frame of your view on
		/// screen.
		/// </remarks>
		/// <returns>The left edge of the displayed part of your view, in pixels.</returns>
		public int getScrollX()
		{
			return mScrollX;
		}

		/// <summary>Return the scrolled top position of this view.</summary>
		/// <remarks>
		/// Return the scrolled top position of this view. This is the top edge of
		/// the displayed part of your view. You do not need to draw any pixels above
		/// it, since those are outside of the frame of your view on screen.
		/// </remarks>
		/// <returns>The top edge of the displayed part of your view, in pixels.</returns>
		public int getScrollY()
		{
			return mScrollY;
		}

		/// <summary>Return the width of the your view.</summary>
		/// <remarks>Return the width of the your view.</remarks>
		/// <returns>The width of your view, in pixels.</returns>
		public int getWidth()
		{
			return mRight - mLeft;
		}

		/// <summary>Return the height of your view.</summary>
		/// <remarks>Return the height of your view.</remarks>
		/// <returns>The height of your view, in pixels.</returns>
		public int getHeight()
		{
			return mBottom - mTop;
		}

		/// <summary>Return the visible drawing bounds of your view.</summary>
		/// <remarks>
		/// Return the visible drawing bounds of your view. Fills in the output
		/// rectangle with the values from getScrollX(), getScrollY(),
		/// getWidth(), and getHeight().
		/// </remarks>
		/// <param name="outRect">The (scrolled) drawing bounds of the view.</param>
		public virtual void getDrawingRect(android.graphics.Rect outRect)
		{
			outRect.left = mScrollX;
			outRect.top = mScrollY;
			outRect.right = mScrollX + (mRight - mLeft);
			outRect.bottom = mScrollY + (mBottom - mTop);
		}

		/// <summary>
		/// Like
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// , but only returns the
		/// raw width component (that is the result is masked by
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// ).
		/// </summary>
		/// <returns>The raw measured width of this view.</returns>
		public int getMeasuredWidth()
		{
			return mMeasuredWidth & MEASURED_SIZE_MASK;
		}

		/// <summary>
		/// Return the full width measurement information for this view as computed
		/// by the most recent call to
		/// <see cref="measure(int, int)">measure(int, int)</see>
		/// .  This result is a bit mask
		/// as defined by
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// and
		/// <see cref="MEASURED_STATE_TOO_SMALL">MEASURED_STATE_TOO_SMALL</see>
		/// .
		/// This should be used during measurement and layout calculations only. Use
		/// <see cref="getWidth()">getWidth()</see>
		/// to see how wide a view is after layout.
		/// </summary>
		/// <returns>The measured width of this view as a bit mask.</returns>
		public int getMeasuredWidthAndState()
		{
			return mMeasuredWidth;
		}

		/// <summary>
		/// Like
		/// <see cref="getMeasuredHeightAndState()">getMeasuredHeightAndState()</see>
		/// , but only returns the
		/// raw width component (that is the result is masked by
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// ).
		/// </summary>
		/// <returns>The raw measured height of this view.</returns>
		public int getMeasuredHeight()
		{
			return mMeasuredHeight & MEASURED_SIZE_MASK;
		}

		/// <summary>
		/// Return the full height measurement information for this view as computed
		/// by the most recent call to
		/// <see cref="measure(int, int)">measure(int, int)</see>
		/// .  This result is a bit mask
		/// as defined by
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// and
		/// <see cref="MEASURED_STATE_TOO_SMALL">MEASURED_STATE_TOO_SMALL</see>
		/// .
		/// This should be used during measurement and layout calculations only. Use
		/// <see cref="getHeight()">getHeight()</see>
		/// to see how wide a view is after layout.
		/// </summary>
		/// <returns>The measured width of this view as a bit mask.</returns>
		public int getMeasuredHeightAndState()
		{
			return mMeasuredHeight;
		}

		/// <summary>
		/// Return only the state bits of
		/// <see cref="getMeasuredWidthAndState()">getMeasuredWidthAndState()</see>
		/// and
		/// <see cref="getMeasuredHeightAndState()">getMeasuredHeightAndState()</see>
		/// , combined into one integer.
		/// The width component is in the regular bits
		/// <see cref="MEASURED_STATE_MASK">MEASURED_STATE_MASK</see>
		/// and the height component is at the shifted bits
		/// <see cref="MEASURED_HEIGHT_STATE_SHIFT">MEASURED_HEIGHT_STATE_SHIFT</see>
		/// &gt;&gt;
		/// <see cref="MEASURED_STATE_MASK">MEASURED_STATE_MASK</see>
		/// .
		/// </summary>
		public int getMeasuredState()
		{
			return (mMeasuredWidth & MEASURED_STATE_MASK) | ((mMeasuredHeight >> MEASURED_HEIGHT_STATE_SHIFT
				) & (MEASURED_STATE_MASK >> MEASURED_HEIGHT_STATE_SHIFT));
		}

		/// <summary>
		/// The transform matrix of this view, which is calculated based on the current
		/// roation, scale, and pivot properties.
		/// </summary>
		/// <remarks>
		/// The transform matrix of this view, which is calculated based on the current
		/// roation, scale, and pivot properties.
		/// </remarks>
		/// <seealso cref="getRotation()">getRotation()</seealso>
		/// <seealso cref="getScaleX()">getScaleX()</seealso>
		/// <seealso cref="getScaleY()">getScaleY()</seealso>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <returns>The current transform matrix for the view</returns>
		public virtual android.graphics.Matrix getMatrix()
		{
			if (mTransformationInfo != null)
			{
				updateMatrix();
				return mTransformationInfo.mMatrix;
			}
			return android.graphics.Matrix.IDENTITY_MATRIX;
		}

		/// <summary>
		/// Utility function to determine if the value is far enough away from zero to be
		/// considered non-zero.
		/// </summary>
		/// <remarks>
		/// Utility function to determine if the value is far enough away from zero to be
		/// considered non-zero.
		/// </remarks>
		/// <param name="value">A floating point value to check for zero-ness</param>
		/// <returns>whether the passed-in value is far enough away from zero to be considered non-zero
		/// 	</returns>
		private static bool nonzero(float value)
		{
			return (value < -NONZERO_EPSILON || value > NONZERO_EPSILON);
		}

		/// <summary>Returns true if the transform matrix is the identity matrix.</summary>
		/// <remarks>
		/// Returns true if the transform matrix is the identity matrix.
		/// Recomputes the matrix if necessary.
		/// </remarks>
		/// <returns>True if the transform matrix is the identity matrix, false otherwise.</returns>
		internal bool hasIdentityMatrix()
		{
			if (mTransformationInfo != null)
			{
				updateMatrix();
				return mTransformationInfo.mMatrixIsIdentity;
			}
			return true;
		}

		internal virtual void ensureTransformationInfo()
		{
			if (mTransformationInfo == null)
			{
				mTransformationInfo = new android.view.View.TransformationInfo();
			}
		}

		/// <summary>Recomputes the transform matrix if necessary.</summary>
		/// <remarks>Recomputes the transform matrix if necessary.</remarks>
		private void updateMatrix()
		{
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info == null)
			{
				return;
			}
			if (info.mMatrixDirty)
			{
				// transform-related properties have changed since the last time someone
				// asked for the matrix; recalculate it with the current values
				// Figure out if we need to update the pivot point
				if ((mPrivateFlags & PIVOT_EXPLICITLY_SET) == 0)
				{
					if ((mRight - mLeft) != info.mPrevWidth || (mBottom - mTop) != info.mPrevHeight)
					{
						info.mPrevWidth = mRight - mLeft;
						info.mPrevHeight = mBottom - mTop;
						info.mPivotX = info.mPrevWidth / 2f;
						info.mPivotY = info.mPrevHeight / 2f;
					}
				}
				info.mMatrix.reset();
				if (!nonzero(info.mRotationX) && !nonzero(info.mRotationY))
				{
					info.mMatrix.setTranslate(info.mTranslationX, info.mTranslationY);
					info.mMatrix.preRotate(info.mRotation, info.mPivotX, info.mPivotY);
					info.mMatrix.preScale(info.mScaleX, info.mScaleY, info.mPivotX, info.mPivotY);
				}
				else
				{
					if (info.mCamera == null)
					{
						info.mCamera = new android.graphics.Camera();
						info.matrix3D = new android.graphics.Matrix();
					}
					info.mCamera.save();
					info.mMatrix.preScale(info.mScaleX, info.mScaleY, info.mPivotX, info.mPivotY);
					info.mCamera.rotate(info.mRotationX, info.mRotationY, -info.mRotation);
					info.mCamera.getMatrix(info.matrix3D);
					info.matrix3D.preTranslate(-info.mPivotX, -info.mPivotY);
					info.matrix3D.postTranslate(info.mPivotX + info.mTranslationX, info.mPivotY + info
						.mTranslationY);
					info.mMatrix.postConcat(info.matrix3D);
					info.mCamera.restore();
				}
				info.mMatrixDirty = false;
				info.mMatrixIsIdentity = info.mMatrix.isIdentity();
				info.mInverseMatrixDirty = true;
			}
		}

		/// <summary>Utility method to retrieve the inverse of the current mMatrix property.</summary>
		/// <remarks>
		/// Utility method to retrieve the inverse of the current mMatrix property.
		/// We cache the matrix to avoid recalculating it when transform properties
		/// have not changed.
		/// </remarks>
		/// <returns>The inverse of the current matrix of this view.</returns>
		internal android.graphics.Matrix getInverseMatrix()
		{
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info != null)
			{
				updateMatrix();
				if (info.mInverseMatrixDirty)
				{
					if (info.mInverseMatrix == null)
					{
						info.mInverseMatrix = new android.graphics.Matrix();
					}
					info.mMatrix.invert(info.mInverseMatrix);
					info.mInverseMatrixDirty = false;
				}
				return info.mInverseMatrix;
			}
			return android.graphics.Matrix.IDENTITY_MATRIX;
		}

		/// <summary>
		/// <p>Sets the distance along the Z axis (orthogonal to the X/Y plane on which
		/// views are drawn) from the camera to this view.
		/// </summary>
		/// <remarks>
		/// <p>Sets the distance along the Z axis (orthogonal to the X/Y plane on which
		/// views are drawn) from the camera to this view. The camera's distance
		/// affects 3D transformations, for instance rotations around the X and Y
		/// axis. If the rotationX or rotationY properties are changed and this view is
		/// large (more than half the size of the screen), it is recommended to always
		/// use a camera distance that's greater than the height (X axis rotation) or
		/// the width (Y axis rotation) of this view.</p>
		/// <p>The distance of the camera from the view plane can have an affect on the
		/// perspective distortion of the view when it is rotated around the x or y axis.
		/// For example, a large distance will result in a large viewing angle, and there
		/// will not be much perspective distortion of the view as it rotates. A short
		/// distance may cause much more perspective distortion upon rotation, and can
		/// also result in some drawing artifacts if the rotated view ends up partially
		/// behind the camera (which is why the recommendation is to use a distance at
		/// least as far as the size of the view, if the view is to be rotated.)</p>
		/// <p>The distance is expressed in "depth pixels." The default distance depends
		/// on the screen density. For instance, on a medium density display, the
		/// default distance is 1280. On a high density display, the default distance
		/// is 1920.</p>
		/// <p>If you want to specify a distance that leads to visually consistent
		/// results across various densities, use the following formula:</p>
		/// <pre>
		/// float scale = context.getResources().getDisplayMetrics().density;
		/// view.setCameraDistance(distance * scale);
		/// </pre>
		/// <p>The density scale factor of a high density display is 1.5,
		/// and 1920 = 1280 * 1.5.</p>
		/// </remarks>
		/// <param name="distance">
		/// The distance in "depth pixels", if negative the opposite
		/// value is used
		/// </param>
		/// <seealso cref="setRotationX(float)"></seealso>
		/// <seealso cref="setRotationY(float)"></seealso>
		public virtual void setCameraDistance(float distance)
		{
			invalidateParentCaches();
			invalidate(false);
			ensureTransformationInfo();
			float dpi = mResources.getDisplayMetrics().densityDpi;
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mCamera == null)
			{
				info.mCamera = new android.graphics.Camera();
				info.matrix3D = new android.graphics.Matrix();
			}
			info.mCamera.setLocation(0.0f, 0.0f, -System.Math.Abs(distance) / dpi);
			info.mMatrixDirty = true;
			invalidate(false);
		}

		/// <summary>The degrees that the view is rotated around the pivot point.</summary>
		/// <remarks>The degrees that the view is rotated around the pivot point.</remarks>
		/// <seealso cref="setRotation(float)"></seealso>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <returns>The degrees of rotation.</returns>
		public virtual float getRotation()
		{
			return mTransformationInfo != null ? mTransformationInfo.mRotation : 0;
		}

		/// <summary>Sets the degrees that the view is rotated around the pivot point.</summary>
		/// <remarks>
		/// Sets the degrees that the view is rotated around the pivot point. Increasing values
		/// result in clockwise rotation.
		/// </remarks>
		/// <param name="rotation">The degrees of rotation.</param>
		/// <seealso cref="getRotation()"></seealso>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <seealso cref="setRotationX(float)"></seealso>
		/// <seealso cref="setRotationY(float)"></seealso>
		/// <attr>ref android.R.styleable#View_rotation</attr>
		public virtual void setRotation(float rotation)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mRotation != rotation)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mRotation = rotation;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>The degrees that the view is rotated around the vertical axis through the pivot point.
		/// 	</summary>
		/// <remarks>The degrees that the view is rotated around the vertical axis through the pivot point.
		/// 	</remarks>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <seealso cref="setRotationY(float)"></seealso>
		/// <returns>The degrees of Y rotation.</returns>
		public virtual float getRotationY()
		{
			return mTransformationInfo != null ? mTransformationInfo.mRotationY : 0;
		}

		/// <summary>Sets the degrees that the view is rotated around the vertical axis through the pivot point.
		/// 	</summary>
		/// <remarks>
		/// Sets the degrees that the view is rotated around the vertical axis through the pivot point.
		/// Increasing values result in counter-clockwise rotation from the viewpoint of looking
		/// down the y axis.
		/// When rotating large views, it is recommended to adjust the camera distance
		/// accordingly. Refer to
		/// <see cref="setCameraDistance(float)">setCameraDistance(float)</see>
		/// for more information.
		/// </remarks>
		/// <param name="rotationY">The degrees of Y rotation.</param>
		/// <seealso cref="getRotationY()"></seealso>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <seealso cref="setRotation(float)">setRotation(float)</seealso>
		/// <seealso cref="setRotationX(float)"></seealso>
		/// <seealso cref="setCameraDistance(float)"></seealso>
		/// <attr>ref android.R.styleable#View_rotationY</attr>
		public virtual void setRotationY(float rotationY)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mRotationY != rotationY)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mRotationY = rotationY;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>The degrees that the view is rotated around the horizontal axis through the pivot point.
		/// 	</summary>
		/// <remarks>The degrees that the view is rotated around the horizontal axis through the pivot point.
		/// 	</remarks>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <seealso cref="setRotationX(float)"></seealso>
		/// <returns>The degrees of X rotation.</returns>
		public virtual float getRotationX()
		{
			return mTransformationInfo != null ? mTransformationInfo.mRotationX : 0;
		}

		/// <summary>Sets the degrees that the view is rotated around the horizontal axis through the pivot point.
		/// 	</summary>
		/// <remarks>
		/// Sets the degrees that the view is rotated around the horizontal axis through the pivot point.
		/// Increasing values result in clockwise rotation from the viewpoint of looking down the
		/// x axis.
		/// When rotating large views, it is recommended to adjust the camera distance
		/// accordingly. Refer to
		/// <see cref="setCameraDistance(float)">setCameraDistance(float)</see>
		/// for more information.
		/// </remarks>
		/// <param name="rotationX">The degrees of X rotation.</param>
		/// <seealso cref="getRotationX()"></seealso>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <seealso cref="setRotation(float)">setRotation(float)</seealso>
		/// <seealso cref="setRotationY(float)"></seealso>
		/// <seealso cref="setCameraDistance(float)"></seealso>
		/// <attr>ref android.R.styleable#View_rotationX</attr>
		public virtual void setRotationX(float rotationX)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mRotationX != rotationX)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mRotationX = rotationX;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>
		/// The amount that the view is scaled in x around the pivot point, as a proportion of
		/// the view's unscaled width.
		/// </summary>
		/// <remarks>
		/// The amount that the view is scaled in x around the pivot point, as a proportion of
		/// the view's unscaled width. A value of 1, the default, means that no scaling is applied.
		/// <p>By default, this is 1.0f.
		/// </remarks>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <returns>The scaling factor.</returns>
		public virtual float getScaleX()
		{
			return mTransformationInfo != null ? mTransformationInfo.mScaleX : 1;
		}

		/// <summary>
		/// Sets the amount that the view is scaled in x around the pivot point, as a proportion of
		/// the view's unscaled width.
		/// </summary>
		/// <remarks>
		/// Sets the amount that the view is scaled in x around the pivot point, as a proportion of
		/// the view's unscaled width. A value of 1 means that no scaling is applied.
		/// </remarks>
		/// <param name="scaleX">The scaling factor.</param>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <attr>ref android.R.styleable#View_scaleX</attr>
		public virtual void setScaleX(float scaleX)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mScaleX != scaleX)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mScaleX = scaleX;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>
		/// The amount that the view is scaled in y around the pivot point, as a proportion of
		/// the view's unscaled height.
		/// </summary>
		/// <remarks>
		/// The amount that the view is scaled in y around the pivot point, as a proportion of
		/// the view's unscaled height. A value of 1, the default, means that no scaling is applied.
		/// <p>By default, this is 1.0f.
		/// </remarks>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <returns>The scaling factor.</returns>
		public virtual float getScaleY()
		{
			return mTransformationInfo != null ? mTransformationInfo.mScaleY : 1;
		}

		/// <summary>
		/// Sets the amount that the view is scaled in Y around the pivot point, as a proportion of
		/// the view's unscaled width.
		/// </summary>
		/// <remarks>
		/// Sets the amount that the view is scaled in Y around the pivot point, as a proportion of
		/// the view's unscaled width. A value of 1 means that no scaling is applied.
		/// </remarks>
		/// <param name="scaleY">The scaling factor.</param>
		/// <seealso cref="getPivotX()">getPivotX()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <attr>ref android.R.styleable#View_scaleY</attr>
		public virtual void setScaleY(float scaleY)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mScaleY != scaleY)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mScaleY = scaleY;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>
		/// The x location of the point around which the view is
		/// <see cref="setRotation(float)">rotated</see>
		/// and
		/// <see cref="setScaleX(float)">scaled</see>
		/// .
		/// </summary>
		/// <seealso cref="getRotation()">getRotation()</seealso>
		/// <seealso cref="getScaleX()">getScaleX()</seealso>
		/// <seealso cref="getScaleY()">getScaleY()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <returns>The x location of the pivot point.</returns>
		public virtual float getPivotX()
		{
			return mTransformationInfo != null ? mTransformationInfo.mPivotX : 0;
		}

		/// <summary>
		/// Sets the x location of the point around which the view is
		/// <see cref="setRotation(float)">rotated</see>
		/// and
		/// <see cref="setScaleX(float)">scaled</see>
		/// .
		/// By default, the pivot point is centered on the object.
		/// Setting this property disables this behavior and causes the view to use only the
		/// explicitly set pivotX and pivotY values.
		/// </summary>
		/// <param name="pivotX">The x location of the pivot point.</param>
		/// <seealso cref="getRotation()">getRotation()</seealso>
		/// <seealso cref="getScaleX()">getScaleX()</seealso>
		/// <seealso cref="getScaleY()">getScaleY()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <attr>ref android.R.styleable#View_transformPivotX</attr>
		public virtual void setPivotX(float pivotX)
		{
			ensureTransformationInfo();
			mPrivateFlags |= PIVOT_EXPLICITLY_SET;
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mPivotX != pivotX)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mPivotX = pivotX;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>
		/// The y location of the point around which the view is
		/// <see cref="setRotation(float)">rotated</see>
		/// and
		/// <see cref="setScaleY(float)">scaled</see>
		/// .
		/// </summary>
		/// <seealso cref="getRotation()">getRotation()</seealso>
		/// <seealso cref="getScaleX()">getScaleX()</seealso>
		/// <seealso cref="getScaleY()">getScaleY()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <returns>The y location of the pivot point.</returns>
		public virtual float getPivotY()
		{
			return mTransformationInfo != null ? mTransformationInfo.mPivotY : 0;
		}

		/// <summary>
		/// Sets the y location of the point around which the view is
		/// <see cref="setRotation(float)">rotated</see>
		/// and
		/// <see cref="setScaleY(float)">scaled</see>
		/// . By default, the pivot point is centered on the object.
		/// Setting this property disables this behavior and causes the view to use only the
		/// explicitly set pivotX and pivotY values.
		/// </summary>
		/// <param name="pivotY">The y location of the pivot point.</param>
		/// <seealso cref="getRotation()">getRotation()</seealso>
		/// <seealso cref="getScaleX()">getScaleX()</seealso>
		/// <seealso cref="getScaleY()">getScaleY()</seealso>
		/// <seealso cref="getPivotY()">getPivotY()</seealso>
		/// <attr>ref android.R.styleable#View_transformPivotY</attr>
		public virtual void setPivotY(float pivotY)
		{
			ensureTransformationInfo();
			mPrivateFlags |= PIVOT_EXPLICITLY_SET;
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mPivotY != pivotY)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mPivotY = pivotY;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>The opacity of the view.</summary>
		/// <remarks>
		/// The opacity of the view. This is a value from 0 to 1, where 0 means the view is
		/// completely transparent and 1 means the view is completely opaque.
		/// <p>By default this is 1.0f.
		/// </remarks>
		/// <returns>The opacity of the view.</returns>
		public virtual float getAlpha()
		{
			return mTransformationInfo != null ? mTransformationInfo.mAlpha : 1;
		}

		/// <summary><p>Sets the opacity of the view.</summary>
		/// <remarks>
		/// <p>Sets the opacity of the view. This is a value from 0 to 1, where 0 means the view is
		/// completely transparent and 1 means the view is completely opaque.</p>
		/// <p>If this view overrides
		/// <see cref="onSetAlpha(int)">onSetAlpha(int)</see>
		/// to return true, then this view is
		/// responsible for applying the opacity itself. Otherwise, calling this method is
		/// equivalent to calling
		/// <see cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</see>
		/// and
		/// setting a hardware layer.</p>
		/// </remarks>
		/// <param name="alpha">The opacity of the view.</param>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</seealso>
		/// <attr>ref android.R.styleable#View_alpha</attr>
		public virtual void setAlpha(float alpha)
		{
			ensureTransformationInfo();
			mTransformationInfo.mAlpha = alpha;
			invalidateParentCaches();
			if (onSetAlpha((int)(alpha * 255)))
			{
				mPrivateFlags |= ALPHA_SET;
				// subclass is handling alpha - don't optimize rendering cache invalidation
				invalidate(true);
			}
			else
			{
				mPrivateFlags &= ~ALPHA_SET;
				invalidate(false);
			}
		}

		/// <summary>
		/// Faster version of setAlpha() which performs the same steps except there are
		/// no calls to invalidate().
		/// </summary>
		/// <remarks>
		/// Faster version of setAlpha() which performs the same steps except there are
		/// no calls to invalidate(). The caller of this function should perform proper invalidation
		/// on the parent and this object. The return value indicates whether the subclass handles
		/// alpha (the return value for onSetAlpha()).
		/// </remarks>
		/// <param name="alpha">The new value for the alpha property</param>
		/// <returns>true if the View subclass handles alpha (the return value for onSetAlpha())
		/// 	</returns>
		internal virtual bool setAlphaNoInvalidation(float alpha)
		{
			ensureTransformationInfo();
			mTransformationInfo.mAlpha = alpha;
			bool subclassHandlesAlpha = onSetAlpha((int)(alpha * 255));
			if (subclassHandlesAlpha)
			{
				mPrivateFlags |= ALPHA_SET;
			}
			else
			{
				mPrivateFlags &= ~ALPHA_SET;
			}
			return subclassHandlesAlpha;
		}

		/// <summary>Top position of this view relative to its parent.</summary>
		/// <remarks>Top position of this view relative to its parent.</remarks>
		/// <returns>The top of this view, in pixels.</returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public int getTop()
		{
			return mTop;
		}

		/// <summary>Sets the top position of this view relative to its parent.</summary>
		/// <remarks>
		/// Sets the top position of this view relative to its parent. This method is meant to be called
		/// by the layout system and should not generally be called otherwise, because the property
		/// may be changed at any time by the layout.
		/// </remarks>
		/// <param name="top">The top of this view, in pixels.</param>
		public void setTop(int top)
		{
			if (top != mTop)
			{
				updateMatrix();
				bool matrixIsIdentity = mTransformationInfo == null || mTransformationInfo.mMatrixIsIdentity;
				if (matrixIsIdentity)
				{
					if (mAttachInfo != null)
					{
						int minTop;
						int yLoc;
						if (top < mTop)
						{
							minTop = top;
							yLoc = top - mTop;
						}
						else
						{
							minTop = mTop;
							yLoc = 0;
						}
						invalidate(0, yLoc, mRight - mLeft, mBottom - minTop);
					}
				}
				else
				{
					// Double-invalidation is necessary to capture view's old and new areas
					invalidate(true);
				}
				int width = mRight - mLeft;
				int oldHeight = mBottom - mTop;
				mTop = top;
				onSizeChanged(width, mBottom - mTop, width, oldHeight);
				if (!matrixIsIdentity)
				{
					if ((mPrivateFlags & PIVOT_EXPLICITLY_SET) == 0)
					{
						// A change in dimension means an auto-centered pivot point changes, too
						mTransformationInfo.mMatrixDirty = true;
					}
					mPrivateFlags |= DRAWN;
					// force another invalidation with the new orientation
					invalidate(true);
				}
				mBackgroundSizeChanged = true;
				invalidateParentIfNeeded();
			}
		}

		/// <summary>Bottom position of this view relative to its parent.</summary>
		/// <remarks>Bottom position of this view relative to its parent.</remarks>
		/// <returns>The bottom of this view, in pixels.</returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public int getBottom()
		{
			return mBottom;
		}

		/// <summary>True if this view has changed since the last time being drawn.</summary>
		/// <remarks>True if this view has changed since the last time being drawn.</remarks>
		/// <returns>The dirty state of this view.</returns>
		public virtual bool isDirty()
		{
			return (mPrivateFlags & DIRTY_MASK) != 0;
		}

		/// <summary>Sets the bottom position of this view relative to its parent.</summary>
		/// <remarks>
		/// Sets the bottom position of this view relative to its parent. This method is meant to be
		/// called by the layout system and should not generally be called otherwise, because the
		/// property may be changed at any time by the layout.
		/// </remarks>
		/// <param name="bottom">The bottom of this view, in pixels.</param>
		public void setBottom(int bottom)
		{
			if (bottom != mBottom)
			{
				updateMatrix();
				bool matrixIsIdentity = mTransformationInfo == null || mTransformationInfo.mMatrixIsIdentity;
				if (matrixIsIdentity)
				{
					if (mAttachInfo != null)
					{
						int maxBottom;
						if (bottom < mBottom)
						{
							maxBottom = mBottom;
						}
						else
						{
							maxBottom = bottom;
						}
						invalidate(0, 0, mRight - mLeft, maxBottom - mTop);
					}
				}
				else
				{
					// Double-invalidation is necessary to capture view's old and new areas
					invalidate(true);
				}
				int width = mRight - mLeft;
				int oldHeight = mBottom - mTop;
				mBottom = bottom;
				onSizeChanged(width, mBottom - mTop, width, oldHeight);
				if (!matrixIsIdentity)
				{
					if ((mPrivateFlags & PIVOT_EXPLICITLY_SET) == 0)
					{
						// A change in dimension means an auto-centered pivot point changes, too
						mTransformationInfo.mMatrixDirty = true;
					}
					mPrivateFlags |= DRAWN;
					// force another invalidation with the new orientation
					invalidate(true);
				}
				mBackgroundSizeChanged = true;
				invalidateParentIfNeeded();
			}
		}

		/// <summary>Left position of this view relative to its parent.</summary>
		/// <remarks>Left position of this view relative to its parent.</remarks>
		/// <returns>The left edge of this view, in pixels.</returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public int getLeft()
		{
			return mLeft;
		}

		/// <summary>Sets the left position of this view relative to its parent.</summary>
		/// <remarks>
		/// Sets the left position of this view relative to its parent. This method is meant to be called
		/// by the layout system and should not generally be called otherwise, because the property
		/// may be changed at any time by the layout.
		/// </remarks>
		/// <param name="left">The bottom of this view, in pixels.</param>
		public void setLeft(int left)
		{
			if (left != mLeft)
			{
				updateMatrix();
				bool matrixIsIdentity = mTransformationInfo == null || mTransformationInfo.mMatrixIsIdentity;
				if (matrixIsIdentity)
				{
					if (mAttachInfo != null)
					{
						int minLeft;
						int xLoc;
						if (left < mLeft)
						{
							minLeft = left;
							xLoc = left - mLeft;
						}
						else
						{
							minLeft = mLeft;
							xLoc = 0;
						}
						invalidate(xLoc, 0, mRight - minLeft, mBottom - mTop);
					}
				}
				else
				{
					// Double-invalidation is necessary to capture view's old and new areas
					invalidate(true);
				}
				int oldWidth = mRight - mLeft;
				int height = mBottom - mTop;
				mLeft = left;
				onSizeChanged(mRight - mLeft, height, oldWidth, height);
				if (!matrixIsIdentity)
				{
					if ((mPrivateFlags & PIVOT_EXPLICITLY_SET) == 0)
					{
						// A change in dimension means an auto-centered pivot point changes, too
						mTransformationInfo.mMatrixDirty = true;
					}
					mPrivateFlags |= DRAWN;
					// force another invalidation with the new orientation
					invalidate(true);
				}
				mBackgroundSizeChanged = true;
				invalidateParentIfNeeded();
			}
		}

		/// <summary>Right position of this view relative to its parent.</summary>
		/// <remarks>Right position of this view relative to its parent.</remarks>
		/// <returns>The right edge of this view, in pixels.</returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public int getRight()
		{
			return mRight;
		}

		/// <summary>Sets the right position of this view relative to its parent.</summary>
		/// <remarks>
		/// Sets the right position of this view relative to its parent. This method is meant to be called
		/// by the layout system and should not generally be called otherwise, because the property
		/// may be changed at any time by the layout.
		/// </remarks>
		/// <param name="right">The bottom of this view, in pixels.</param>
		public void setRight(int right)
		{
			if (right != mRight)
			{
				updateMatrix();
				bool matrixIsIdentity = mTransformationInfo == null || mTransformationInfo.mMatrixIsIdentity;
				if (matrixIsIdentity)
				{
					if (mAttachInfo != null)
					{
						int maxRight;
						if (right < mRight)
						{
							maxRight = mRight;
						}
						else
						{
							maxRight = right;
						}
						invalidate(0, 0, maxRight - mLeft, mBottom - mTop);
					}
				}
				else
				{
					// Double-invalidation is necessary to capture view's old and new areas
					invalidate(true);
				}
				int oldWidth = mRight - mLeft;
				int height = mBottom - mTop;
				mRight = right;
				onSizeChanged(mRight - mLeft, height, oldWidth, height);
				if (!matrixIsIdentity)
				{
					if ((mPrivateFlags & PIVOT_EXPLICITLY_SET) == 0)
					{
						// A change in dimension means an auto-centered pivot point changes, too
						mTransformationInfo.mMatrixDirty = true;
					}
					mPrivateFlags |= DRAWN;
					// force another invalidation with the new orientation
					invalidate(true);
				}
				mBackgroundSizeChanged = true;
				invalidateParentIfNeeded();
			}
		}

		/// <summary>The visual x position of this view, in pixels.</summary>
		/// <remarks>
		/// The visual x position of this view, in pixels. This is equivalent to the
		/// <see cref="setTranslationX(float)">translationX</see>
		/// property plus the current
		/// <see cref="getLeft()">left</see>
		/// property.
		/// </remarks>
		/// <returns>The visual x position of this view, in pixels.</returns>
		public virtual float getX()
		{
			return mLeft + (mTransformationInfo != null ? mTransformationInfo.mTranslationX : 
				0);
		}

		/// <summary>Sets the visual x position of this view, in pixels.</summary>
		/// <remarks>
		/// Sets the visual x position of this view, in pixels. This is equivalent to setting the
		/// <see cref="setTranslationX(float)">translationX</see>
		/// property to be the difference between
		/// the x value passed in and the current
		/// <see cref="getLeft()">left</see>
		/// property.
		/// </remarks>
		/// <param name="x">The visual x position of this view, in pixels.</param>
		public virtual void setX(float x)
		{
			setTranslationX(x - mLeft);
		}

		/// <summary>The visual y position of this view, in pixels.</summary>
		/// <remarks>
		/// The visual y position of this view, in pixels. This is equivalent to the
		/// <see cref="setTranslationY(float)">translationY</see>
		/// property plus the current
		/// <see cref="getTop()">top</see>
		/// property.
		/// </remarks>
		/// <returns>The visual y position of this view, in pixels.</returns>
		public virtual float getY()
		{
			return mTop + (mTransformationInfo != null ? mTransformationInfo.mTranslationY : 
				0);
		}

		/// <summary>Sets the visual y position of this view, in pixels.</summary>
		/// <remarks>
		/// Sets the visual y position of this view, in pixels. This is equivalent to setting the
		/// <see cref="setTranslationY(float)">translationY</see>
		/// property to be the difference between
		/// the y value passed in and the current
		/// <see cref="getTop()">top</see>
		/// property.
		/// </remarks>
		/// <param name="y">The visual y position of this view, in pixels.</param>
		public virtual void setY(float y)
		{
			setTranslationY(y - mTop);
		}

		/// <summary>
		/// The horizontal location of this view relative to its
		/// <see cref="getLeft()">left</see>
		/// position.
		/// This position is post-layout, in addition to wherever the object's
		/// layout placed it.
		/// </summary>
		/// <returns>The horizontal position of this view relative to its left position, in pixels.
		/// 	</returns>
		public virtual float getTranslationX()
		{
			return mTransformationInfo != null ? mTransformationInfo.mTranslationX : 0;
		}

		/// <summary>
		/// Sets the horizontal location of this view relative to its
		/// <see cref="getLeft()">left</see>
		/// position.
		/// This effectively positions the object post-layout, in addition to wherever the object's
		/// layout placed it.
		/// </summary>
		/// <param name="translationX">
		/// The horizontal position of this view relative to its left position,
		/// in pixels.
		/// </param>
		/// <attr>ref android.R.styleable#View_translationX</attr>
		public virtual void setTranslationX(float translationX)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mTranslationX != translationX)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mTranslationX = translationX;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <summary>
		/// The horizontal location of this view relative to its
		/// <see cref="getTop()">top</see>
		/// position.
		/// This position is post-layout, in addition to wherever the object's
		/// layout placed it.
		/// </summary>
		/// <returns>
		/// The vertical position of this view relative to its top position,
		/// in pixels.
		/// </returns>
		public virtual float getTranslationY()
		{
			return mTransformationInfo != null ? mTransformationInfo.mTranslationY : 0;
		}

		/// <summary>
		/// Sets the vertical location of this view relative to its
		/// <see cref="getTop()">top</see>
		/// position.
		/// This effectively positions the object post-layout, in addition to wherever the object's
		/// layout placed it.
		/// </summary>
		/// <param name="translationY">
		/// The vertical position of this view relative to its top position,
		/// in pixels.
		/// </param>
		/// <attr>ref android.R.styleable#View_translationY</attr>
		public virtual void setTranslationY(float translationY)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info.mTranslationY != translationY)
			{
				invalidateParentCaches();
				// Double-invalidation is necessary to capture view's old and new areas
				invalidate(false);
				info.mTranslationY = translationY;
				info.mMatrixDirty = true;
				mPrivateFlags |= DRAWN;
				// force another invalidation with the new orientation
				invalidate(false);
			}
		}

		/// <hide></hide>
		public virtual void setFastTranslationX(float x)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			info.mTranslationX = x;
			info.mMatrixDirty = true;
		}

		/// <hide></hide>
		public virtual void setFastTranslationY(float y)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			info.mTranslationY = y;
			info.mMatrixDirty = true;
		}

		/// <hide></hide>
		public virtual void setFastX(float x)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			info.mTranslationX = x - mLeft;
			info.mMatrixDirty = true;
		}

		/// <hide></hide>
		public virtual void setFastY(float y)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			info.mTranslationY = y - mTop;
			info.mMatrixDirty = true;
		}

		/// <hide></hide>
		public virtual void setFastScaleX(float x)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			info.mScaleX = x;
			info.mMatrixDirty = true;
		}

		/// <hide></hide>
		public virtual void setFastScaleY(float y)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			info.mScaleY = y;
			info.mMatrixDirty = true;
		}

		/// <hide></hide>
		public virtual void setFastAlpha(float alpha)
		{
			ensureTransformationInfo();
			mTransformationInfo.mAlpha = alpha;
		}

		/// <hide></hide>
		public virtual void setFastRotationY(float y)
		{
			ensureTransformationInfo();
			android.view.View.TransformationInfo info = mTransformationInfo;
			info.mRotationY = y;
			info.mMatrixDirty = true;
		}

		/// <summary>Hit rectangle in parent's coordinates</summary>
		/// <param name="outRect">The hit rectangle of the view.</param>
		public virtual void getHitRect(android.graphics.Rect outRect)
		{
			updateMatrix();
			android.view.View.TransformationInfo info = mTransformationInfo;
			if (info == null || info.mMatrixIsIdentity || mAttachInfo == null)
			{
				outRect.set(mLeft, mTop, mRight, mBottom);
			}
			else
			{
				android.graphics.RectF tmpRect = mAttachInfo.mTmpTransformRect;
				tmpRect.set(-info.mPivotX, -info.mPivotY, getWidth() - info.mPivotX, getHeight() 
					- info.mPivotY);
				info.mMatrix.mapRect(tmpRect);
				outRect.set((int)tmpRect.left + mLeft, (int)tmpRect.top + mTop, (int)tmpRect.right
					 + mLeft, (int)tmpRect.bottom + mTop);
			}
		}

		/// <summary>Determines whether the given point, in local coordinates is inside the view.
		/// 	</summary>
		/// <remarks>Determines whether the given point, in local coordinates is inside the view.
		/// 	</remarks>
		internal bool pointInView(float localX, float localY)
		{
			return localX >= 0 && localX < (mRight - mLeft) && localY >= 0 && localY < (mBottom
				 - mTop);
		}

		/// <summary>
		/// Utility method to determine whether the given point, in local coordinates,
		/// is inside the view, where the area of the view is expanded by the slop factor.
		/// </summary>
		/// <remarks>
		/// Utility method to determine whether the given point, in local coordinates,
		/// is inside the view, where the area of the view is expanded by the slop factor.
		/// This method is called while processing touch-move events to determine if the event
		/// is still within the view.
		/// </remarks>
		private bool pointInView(float localX, float localY, float slop)
		{
			return localX >= -slop && localY >= -slop && localX < ((mRight - mLeft) + slop) &&
				 localY < ((mBottom - mTop) + slop);
		}

		/// <summary>
		/// When a view has focus and the user navigates away from it, the next view is searched for
		/// starting from the rectangle filled in by this method.
		/// </summary>
		/// <remarks>
		/// When a view has focus and the user navigates away from it, the next view is searched for
		/// starting from the rectangle filled in by this method.
		/// By default, the rectange is the
		/// <see cref="getDrawingRect(android.graphics.Rect)">getDrawingRect(android.graphics.Rect)
		/// 	</see>
		/// )
		/// of the view.  However, if your view maintains some idea of internal selection,
		/// such as a cursor, or a selected row or column, you should override this method and
		/// fill in a more specific rectangle.
		/// </remarks>
		/// <param name="r">The rectangle to fill in, in this view's coordinates.</param>
		public virtual void getFocusedRect(android.graphics.Rect r)
		{
			getDrawingRect(r);
		}

		/// <summary>
		/// If some part of this view is not clipped by any of its parents, then
		/// return that area in r in global (root) coordinates.
		/// </summary>
		/// <remarks>
		/// If some part of this view is not clipped by any of its parents, then
		/// return that area in r in global (root) coordinates. To convert r to local
		/// coordinates, offset it by -globalOffset (e.g. r.offset(-globalOffset.x,
		/// -globalOffset.y)) If the view is completely clipped or translated out,
		/// return false.
		/// </remarks>
		/// <param name="r">
		/// If true is returned, r holds the global coordinates of the
		/// visible portion of this view.
		/// </param>
		/// <param name="globalOffset">
		/// If true is returned, globalOffset holds the dx,dy
		/// between this view and its root. globalOffet may be null.
		/// </param>
		/// <returns>
		/// true if r is non-empty (i.e. part of the view is visible at the
		/// root level.
		/// </returns>
		public virtual bool getGlobalVisibleRect(android.graphics.Rect r, android.graphics.Point
			 globalOffset)
		{
			int width = mRight - mLeft;
			int height = mBottom - mTop;
			if (width > 0 && height > 0)
			{
				r.set(0, 0, width, height);
				if (globalOffset != null)
				{
					globalOffset.set(-mScrollX, -mScrollY);
				}
				return mParent == null || mParent.getChildVisibleRect(this, r, globalOffset);
			}
			return false;
		}

		public bool getGlobalVisibleRect(android.graphics.Rect r)
		{
			return getGlobalVisibleRect(r, null);
		}

		public bool getLocalVisibleRect(android.graphics.Rect r)
		{
			android.graphics.Point offset = new android.graphics.Point();
			if (getGlobalVisibleRect(r, offset))
			{
				r.offset(-offset.x, -offset.y);
				// make r local
				return true;
			}
			return false;
		}

		/// <summary>Offset this view's vertical location by the specified number of pixels.</summary>
		/// <remarks>Offset this view's vertical location by the specified number of pixels.</remarks>
		/// <param name="offset">the number of pixels to offset the view by</param>
		public virtual void offsetTopAndBottom(int offset)
		{
			if (offset != 0)
			{
				updateMatrix();
				bool matrixIsIdentity = mTransformationInfo == null || mTransformationInfo.mMatrixIsIdentity;
				if (matrixIsIdentity)
				{
					android.view.ViewParent p = mParent;
					if (p != null && mAttachInfo != null)
					{
						android.graphics.Rect r = mAttachInfo.mTmpInvalRect;
						int minTop;
						int maxBottom;
						int yLoc;
						if (offset < 0)
						{
							minTop = mTop + offset;
							maxBottom = mBottom;
							yLoc = offset;
						}
						else
						{
							minTop = mTop;
							maxBottom = mBottom + offset;
							yLoc = 0;
						}
						r.set(0, yLoc, mRight - mLeft, maxBottom - minTop);
						p.invalidateChild(this, r);
					}
				}
				else
				{
					invalidate(false);
				}
				mTop += offset;
				mBottom += offset;
				if (!matrixIsIdentity)
				{
					mPrivateFlags |= DRAWN;
					// force another invalidation with the new orientation
					invalidate(false);
				}
				invalidateParentIfNeeded();
			}
		}

		/// <summary>Offset this view's horizontal location by the specified amount of pixels.
		/// 	</summary>
		/// <remarks>Offset this view's horizontal location by the specified amount of pixels.
		/// 	</remarks>
		/// <param name="offset">the numer of pixels to offset the view by</param>
		public virtual void offsetLeftAndRight(int offset)
		{
			if (offset != 0)
			{
				updateMatrix();
				bool matrixIsIdentity = mTransformationInfo == null || mTransformationInfo.mMatrixIsIdentity;
				if (matrixIsIdentity)
				{
					android.view.ViewParent p = mParent;
					if (p != null && mAttachInfo != null)
					{
						android.graphics.Rect r = mAttachInfo.mTmpInvalRect;
						int minLeft;
						int maxRight;
						if (offset < 0)
						{
							minLeft = mLeft + offset;
							maxRight = mRight;
						}
						else
						{
							minLeft = mLeft;
							maxRight = mRight + offset;
						}
						r.set(0, 0, maxRight - minLeft, mBottom - mTop);
						p.invalidateChild(this, r);
					}
				}
				else
				{
					invalidate(false);
				}
				mLeft += offset;
				mRight += offset;
				if (!matrixIsIdentity)
				{
					mPrivateFlags |= DRAWN;
					// force another invalidation with the new orientation
					invalidate(false);
				}
				invalidateParentIfNeeded();
			}
		}

		/// <summary>Get the LayoutParams associated with this view.</summary>
		/// <remarks>
		/// Get the LayoutParams associated with this view. All views should have
		/// layout parameters. These supply parameters to the <i>parent</i> of this
		/// view specifying how it should be arranged. There are many subclasses of
		/// ViewGroup.LayoutParams, and these correspond to the different subclasses
		/// of ViewGroup that are responsible for arranging their children.
		/// This method may return null if this View is not attached to a parent
		/// ViewGroup or
		/// <see cref="setLayoutParams(LayoutParams)">setLayoutParams(LayoutParams)</see>
		/// was not invoked successfully. When a View is attached to a parent
		/// ViewGroup, this method must not return null.
		/// </remarks>
		/// <returns>
		/// The LayoutParams associated with this view, or null if no
		/// parameters have been set yet
		/// </returns>
		public virtual android.view.ViewGroup.LayoutParams getLayoutParams()
		{
			return mLayoutParams;
		}

		/// <summary>Set the layout parameters associated with this view.</summary>
		/// <remarks>
		/// Set the layout parameters associated with this view. These supply
		/// parameters to the <i>parent</i> of this view specifying how it should be
		/// arranged. There are many subclasses of ViewGroup.LayoutParams, and these
		/// correspond to the different subclasses of ViewGroup that are responsible
		/// for arranging their children.
		/// </remarks>
		/// <param name="params">The layout parameters for this view, cannot be null</param>
		public virtual void setLayoutParams(android.view.ViewGroup.LayoutParams @params)
		{
			if (@params == null)
			{
				throw new System.ArgumentNullException("Layout parameters cannot be null");
			}
			mLayoutParams = @params;
			requestLayout();
		}

		/// <summary>Set the scrolled position of your view.</summary>
		/// <remarks>
		/// Set the scrolled position of your view. This will cause a call to
		/// <see cref="onScrollChanged(int, int, int, int)">onScrollChanged(int, int, int, int)
		/// 	</see>
		/// and the view will be
		/// invalidated.
		/// </remarks>
		/// <param name="x">the x position to scroll to</param>
		/// <param name="y">the y position to scroll to</param>
		public virtual void scrollTo(int x, int y)
		{
			if (mScrollX != x || mScrollY != y)
			{
				int oldX = mScrollX;
				int oldY = mScrollY;
				mScrollX = x;
				mScrollY = y;
				invalidateParentCaches();
				onScrollChanged(mScrollX, mScrollY, oldX, oldY);
				if (!awakenScrollBars())
				{
					invalidate(true);
				}
			}
		}

		/// <summary>Move the scrolled position of your view.</summary>
		/// <remarks>
		/// Move the scrolled position of your view. This will cause a call to
		/// <see cref="onScrollChanged(int, int, int, int)">onScrollChanged(int, int, int, int)
		/// 	</see>
		/// and the view will be
		/// invalidated.
		/// </remarks>
		/// <param name="x">the amount of pixels to scroll by horizontally</param>
		/// <param name="y">the amount of pixels to scroll by vertically</param>
		public virtual void scrollBy(int x, int y)
		{
			scrollTo(mScrollX + x, mScrollY + y);
		}

		/// <summary><p>Trigger the scrollbars to draw.</summary>
		/// <remarks>
		/// <p>Trigger the scrollbars to draw. When invoked this method starts an
		/// animation to fade the scrollbars out after a default delay. If a subclass
		/// provides animated scrolling, the start delay should equal the duration
		/// of the scrolling animation.</p>
		/// <p>The animation starts only if at least one of the scrollbars is
		/// enabled, as specified by
		/// <see cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</see>
		/// and
		/// <see cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</see>
		/// . When the animation is started,
		/// this method returns true, and false otherwise. If the animation is
		/// started, this method calls
		/// <see cref="invalidate()">invalidate()</see>
		/// ; in that case the
		/// caller should not call
		/// <see cref="invalidate()">invalidate()</see>
		/// .</p>
		/// <p>This method should be invoked every time a subclass directly updates
		/// the scroll parameters.</p>
		/// <p>This method is automatically invoked by
		/// <see cref="scrollBy(int, int)">scrollBy(int, int)</see>
		/// and
		/// <see cref="scrollTo(int, int)">scrollTo(int, int)</see>
		/// .</p>
		/// </remarks>
		/// <returns>true if the animation is played, false otherwise</returns>
		/// <seealso cref="awakenScrollBars(int)">awakenScrollBars(int)</seealso>
		/// <seealso cref="scrollBy(int, int)">scrollBy(int, int)</seealso>
		/// <seealso cref="scrollTo(int, int)">scrollTo(int, int)</seealso>
		/// <seealso cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</seealso>
		/// <seealso cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</seealso>
		/// <seealso cref="setHorizontalScrollBarEnabled(bool)">setHorizontalScrollBarEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="setVerticalScrollBarEnabled(bool)">setVerticalScrollBarEnabled(bool)
		/// 	</seealso>
		protected internal virtual bool awakenScrollBars()
		{
			return mScrollCache != null && awakenScrollBars(mScrollCache.scrollBarDefaultDelayBeforeFade
				, true);
		}

		/// <summary>Trigger the scrollbars to draw.</summary>
		/// <remarks>
		/// Trigger the scrollbars to draw.
		/// This method differs from awakenScrollBars() only in its default duration.
		/// initialAwakenScrollBars() will show the scroll bars for longer than
		/// usual to give the user more of a chance to notice them.
		/// </remarks>
		/// <returns>true if the animation is played, false otherwise.</returns>
		private bool initialAwakenScrollBars()
		{
			return mScrollCache != null && awakenScrollBars(mScrollCache.scrollBarDefaultDelayBeforeFade
				 * 4, true);
		}

		/// <summary>
		/// <p>
		/// Trigger the scrollbars to draw.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Trigger the scrollbars to draw. When invoked this method starts an
		/// animation to fade the scrollbars out after a fixed delay. If a subclass
		/// provides animated scrolling, the start delay should equal the duration of
		/// the scrolling animation.
		/// </p>
		/// <p>
		/// The animation starts only if at least one of the scrollbars is enabled,
		/// as specified by
		/// <see cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</see>
		/// and
		/// <see cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</see>
		/// . When the animation is started,
		/// this method returns true, and false otherwise. If the animation is
		/// started, this method calls
		/// <see cref="invalidate()">invalidate()</see>
		/// ; in that case the caller
		/// should not call
		/// <see cref="invalidate()">invalidate()</see>
		/// .
		/// </p>
		/// <p>
		/// This method should be invoked everytime a subclass directly updates the
		/// scroll parameters.
		/// </p>
		/// </remarks>
		/// <param name="startDelay">
		/// the delay, in milliseconds, after which the animation
		/// should start; when the delay is 0, the animation starts
		/// immediately
		/// </param>
		/// <returns>true if the animation is played, false otherwise</returns>
		/// <seealso cref="scrollBy(int, int)">scrollBy(int, int)</seealso>
		/// <seealso cref="scrollTo(int, int)">scrollTo(int, int)</seealso>
		/// <seealso cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</seealso>
		/// <seealso cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</seealso>
		/// <seealso cref="setHorizontalScrollBarEnabled(bool)">setHorizontalScrollBarEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="setVerticalScrollBarEnabled(bool)">setVerticalScrollBarEnabled(bool)
		/// 	</seealso>
		protected internal virtual bool awakenScrollBars(int startDelay)
		{
			return awakenScrollBars(startDelay, true);
		}

		/// <summary>
		/// <p>
		/// Trigger the scrollbars to draw.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Trigger the scrollbars to draw. When invoked this method starts an
		/// animation to fade the scrollbars out after a fixed delay. If a subclass
		/// provides animated scrolling, the start delay should equal the duration of
		/// the scrolling animation.
		/// </p>
		/// <p>
		/// The animation starts only if at least one of the scrollbars is enabled,
		/// as specified by
		/// <see cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</see>
		/// and
		/// <see cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</see>
		/// . When the animation is started,
		/// this method returns true, and false otherwise. If the animation is
		/// started, this method calls
		/// <see cref="invalidate()">invalidate()</see>
		/// if the invalidate parameter
		/// is set to true; in that case the caller
		/// should not call
		/// <see cref="invalidate()">invalidate()</see>
		/// .
		/// </p>
		/// <p>
		/// This method should be invoked everytime a subclass directly updates the
		/// scroll parameters.
		/// </p>
		/// </remarks>
		/// <param name="startDelay">
		/// the delay, in milliseconds, after which the animation
		/// should start; when the delay is 0, the animation starts
		/// immediately
		/// </param>
		/// <param name="invalidate">Wheter this method should call invalidate</param>
		/// <returns>true if the animation is played, false otherwise</returns>
		/// <seealso cref="scrollBy(int, int)">scrollBy(int, int)</seealso>
		/// <seealso cref="scrollTo(int, int)">scrollTo(int, int)</seealso>
		/// <seealso cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</seealso>
		/// <seealso cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</seealso>
		/// <seealso cref="setHorizontalScrollBarEnabled(bool)">setHorizontalScrollBarEnabled(bool)
		/// 	</seealso>
		/// <seealso cref="setVerticalScrollBarEnabled(bool)">setVerticalScrollBarEnabled(bool)
		/// 	</seealso>
		protected internal virtual bool awakenScrollBars(int startDelay, bool invalidate_1
			)
		{
			android.view.View.ScrollabilityCache scrollCache = mScrollCache;
			if (scrollCache == null || !scrollCache.fadeScrollBars)
			{
				return false;
			}
			if (scrollCache.scrollBar == null)
			{
				scrollCache.scrollBar = new android.widget.ScrollBarDrawable();
			}
			if (isHorizontalScrollBarEnabled() || isVerticalScrollBarEnabled())
			{
				if (invalidate_1)
				{
					// Invalidate to show the scrollbars
					invalidate(true);
				}
				if (scrollCache.state == android.view.View.ScrollabilityCache.OFF)
				{
					// FIXME: this is copied from WindowManagerService.
					// We should get this value from the system when it
					// is possible to do so.
					int KEY_REPEAT_FIRST_DELAY = 750;
					startDelay = System.Math.Max(KEY_REPEAT_FIRST_DELAY, startDelay);
				}
				// Tell mScrollCache when we should start fading. This may
				// extend the fade start time if one was already scheduled
				long fadeStartTime = android.view.animation.AnimationUtils.currentAnimationTimeMillis
					() + startDelay;
				scrollCache.fadeStartTime = fadeStartTime;
				scrollCache.state = android.view.View.ScrollabilityCache.ON;
				// Schedule our fader to run, unscheduling any old ones first
				if (mAttachInfo != null)
				{
					mAttachInfo.mHandler.removeCallbacks(scrollCache);
					mAttachInfo.mHandler.postAtTime(scrollCache, fadeStartTime);
				}
				return true;
			}
			return false;
		}

		/// <summary>Do not invalidate views which are not visible and which are not running an animation.
		/// 	</summary>
		/// <remarks>
		/// Do not invalidate views which are not visible and which are not running an animation. They
		/// will not get drawn and they should not set dirty flags as if they will be drawn
		/// </remarks>
		private bool skipInvalidate()
		{
			return (mViewFlags & VISIBILITY_MASK) != VISIBLE && mCurrentAnimation == null && 
				(!(mParent is android.view.ViewGroup) || !((android.view.ViewGroup)mParent).isViewTransitioning
				(this));
		}

		/// <summary>Mark the area defined by dirty as needing to be drawn.</summary>
		/// <remarks>
		/// Mark the area defined by dirty as needing to be drawn. If the view is
		/// visible,
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// will be called at some point
		/// in the future. This must be called from a UI thread. To call from a non-UI
		/// thread, call
		/// <see cref="postInvalidate()">postInvalidate()</see>
		/// .
		/// WARNING: This method is destructive to dirty.
		/// </remarks>
		/// <param name="dirty">the rectangle representing the bounds of the dirty region</param>
		public virtual void invalidate(android.graphics.Rect dirty)
		{
			if (skipInvalidate())
			{
				return;
			}
			if ((mPrivateFlags & (DRAWN | HAS_BOUNDS)) == (DRAWN | HAS_BOUNDS) || (mPrivateFlags
				 & DRAWING_CACHE_VALID) == DRAWING_CACHE_VALID || (mPrivateFlags & INVALIDATED) 
				!= INVALIDATED)
			{
				mPrivateFlags &= ~DRAWING_CACHE_VALID;
				mPrivateFlags |= INVALIDATED;
				mPrivateFlags |= DIRTY;
				android.view.ViewParent p = mParent;
				android.view.View.AttachInfo ai = mAttachInfo;
				//noinspection PointlessBooleanExpression,ConstantConditions
				// fast-track for GL-enabled applications; just invalidate the whole hierarchy
				// with a null dirty rect, which tells the ViewAncestor to redraw everything
				if (p != null && ai != null)
				{
					int scrollX = mScrollX;
					int scrollY = mScrollY;
					android.graphics.Rect r = ai.mTmpInvalRect;
					r.set(dirty.left - scrollX, dirty.top - scrollY, dirty.right - scrollX, dirty.bottom
						 - scrollY);
					mParent.invalidateChild(this, r);
				}
			}
		}

		/// <summary>Mark the area defined by the rect (l,t,r,b) as needing to be drawn.</summary>
		/// <remarks>
		/// Mark the area defined by the rect (l,t,r,b) as needing to be drawn.
		/// The coordinates of the dirty rect are relative to the view.
		/// If the view is visible,
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// will be called at some point in the future. This must be called from
		/// a UI thread. To call from a non-UI thread, call
		/// <see cref="postInvalidate()">postInvalidate()</see>
		/// .
		/// </remarks>
		/// <param name="l">the left position of the dirty region</param>
		/// <param name="t">the top position of the dirty region</param>
		/// <param name="r">the right position of the dirty region</param>
		/// <param name="b">the bottom position of the dirty region</param>
		public virtual void invalidate(int l, int t, int r, int b)
		{
			if (skipInvalidate())
			{
				return;
			}
			if ((mPrivateFlags & (DRAWN | HAS_BOUNDS)) == (DRAWN | HAS_BOUNDS) || (mPrivateFlags
				 & DRAWING_CACHE_VALID) == DRAWING_CACHE_VALID || (mPrivateFlags & INVALIDATED) 
				!= INVALIDATED)
			{
				mPrivateFlags &= ~DRAWING_CACHE_VALID;
				mPrivateFlags |= INVALIDATED;
				mPrivateFlags |= DIRTY;
				android.view.ViewParent p = mParent;
				android.view.View.AttachInfo ai = mAttachInfo;
				//noinspection PointlessBooleanExpression,ConstantConditions
				// fast-track for GL-enabled applications; just invalidate the whole hierarchy
				// with a null dirty rect, which tells the ViewAncestor to redraw everything
				if (p != null && ai != null && l < r && t < b)
				{
					int scrollX = mScrollX;
					int scrollY = mScrollY;
					android.graphics.Rect tmpr = ai.mTmpInvalRect;
					tmpr.set(l - scrollX, t - scrollY, r - scrollX, b - scrollY);
					p.invalidateChild(this, tmpr);
				}
			}
		}

		/// <summary>Invalidate the whole view.</summary>
		/// <remarks>
		/// Invalidate the whole view. If the view is visible,
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// will be called at some point in
		/// the future. This must be called from a UI thread. To call from a non-UI thread,
		/// call
		/// <see cref="postInvalidate()">postInvalidate()</see>
		/// .
		/// </remarks>
		public virtual void invalidate()
		{
			invalidate(true);
		}

		/// <summary>This is where the invalidate() work actually happens.</summary>
		/// <remarks>
		/// This is where the invalidate() work actually happens. A full invalidate()
		/// causes the drawing cache to be invalidated, but this function can be called with
		/// invalidateCache set to false to skip that invalidation step for cases that do not
		/// need it (for example, a component that remains at the same dimensions with the same
		/// content).
		/// </remarks>
		/// <param name="invalidateCache">
		/// Whether the drawing cache for this view should be invalidated as
		/// well. This is usually true for a full invalidate, but may be set to false if the
		/// View's contents or dimensions have not changed.
		/// </param>
		internal virtual void invalidate(bool invalidateCache)
		{
			if (skipInvalidate())
			{
				return;
			}
			if ((mPrivateFlags & (DRAWN | HAS_BOUNDS)) == (DRAWN | HAS_BOUNDS) || (invalidateCache
				 && (mPrivateFlags & DRAWING_CACHE_VALID) == DRAWING_CACHE_VALID) || (mPrivateFlags
				 & INVALIDATED) != INVALIDATED || isOpaque() != mLastIsOpaque)
			{
				mLastIsOpaque = isOpaque();
				mPrivateFlags &= ~DRAWN;
				mPrivateFlags |= DIRTY;
				if (invalidateCache)
				{
					mPrivateFlags |= INVALIDATED;
					mPrivateFlags &= ~DRAWING_CACHE_VALID;
				}
				android.view.View.AttachInfo ai = mAttachInfo;
				android.view.ViewParent p = mParent;
				//noinspection PointlessBooleanExpression,ConstantConditions
				// fast-track for GL-enabled applications; just invalidate the whole hierarchy
				// with a null dirty rect, which tells the ViewAncestor to redraw everything
				if (p != null && ai != null)
				{
					android.graphics.Rect r = ai.mTmpInvalRect;
					r.set(0, 0, mRight - mLeft, mBottom - mTop);
					// Don't call invalidate -- we don't want to internally scroll
					// our own bounds
					p.invalidateChild(this, r);
				}
			}
		}

		/// <hide></hide>
		public virtual void fastInvalidate()
		{
			if (skipInvalidate())
			{
				return;
			}
			if ((mPrivateFlags & (DRAWN | HAS_BOUNDS)) == (DRAWN | HAS_BOUNDS) || (mPrivateFlags
				 & DRAWING_CACHE_VALID) == DRAWING_CACHE_VALID || (mPrivateFlags & INVALIDATED) 
				!= INVALIDATED)
			{
				if (mParent is android.view.View)
				{
					((android.view.View)mParent).mPrivateFlags |= INVALIDATED;
				}
				mPrivateFlags &= ~DRAWN;
				mPrivateFlags |= DIRTY;
				mPrivateFlags |= INVALIDATED;
				mPrivateFlags &= ~DRAWING_CACHE_VALID;
				if (mParent != null && mAttachInfo != null)
				{
					if (mAttachInfo.mHardwareAccelerated)
					{
						mParent.invalidateChild(this, null);
					}
					else
					{
						android.graphics.Rect r = mAttachInfo.mTmpInvalRect;
						r.set(0, 0, mRight - mLeft, mBottom - mTop);
						// Don't call invalidate -- we don't want to internally scroll
						// our own bounds
						mParent.invalidateChild(this, r);
					}
				}
			}
		}

		/// <summary>Used to indicate that the parent of this view should clear its caches.</summary>
		/// <remarks>
		/// Used to indicate that the parent of this view should clear its caches. This functionality
		/// is used to force the parent to rebuild its display list (when hardware-accelerated),
		/// which is necessary when various parent-managed properties of the view change, such as
		/// alpha, translationX/Y, scrollX/Y, scaleX/Y, and rotation/X/Y. This method only
		/// clears the parent caches and does not causes an invalidate event.
		/// </remarks>
		/// <hide></hide>
		protected internal virtual void invalidateParentCaches()
		{
			if (mParent is android.view.View)
			{
				((android.view.View)mParent).mPrivateFlags |= INVALIDATED;
			}
		}

		/// <summary>Used to indicate that the parent of this view should be invalidated.</summary>
		/// <remarks>
		/// Used to indicate that the parent of this view should be invalidated. This functionality
		/// is used to force the parent to rebuild its display list (when hardware-accelerated),
		/// which is necessary when various parent-managed properties of the view change, such as
		/// alpha, translationX/Y, scrollX/Y, scaleX/Y, and rotation/X/Y. This method will propagate
		/// an invalidation event to the parent.
		/// </remarks>
		/// <hide></hide>
		protected internal virtual void invalidateParentIfNeeded()
		{
			if (isHardwareAccelerated() && mParent is android.view.View)
			{
				((android.view.View)mParent).invalidate(true);
			}
		}

		/// <summary>Indicates whether this View is opaque.</summary>
		/// <remarks>
		/// Indicates whether this View is opaque. An opaque View guarantees that it will
		/// draw all the pixels overlapping its bounds using a fully opaque color.
		/// Subclasses of View should override this method whenever possible to indicate
		/// whether an instance is opaque. Opaque Views are treated in a special way by
		/// the View hierarchy, possibly allowing it to perform optimizations during
		/// invalidate/draw passes.
		/// </remarks>
		/// <returns>True if this View is guaranteed to be fully opaque, false otherwise.</returns>
		public virtual bool isOpaque()
		{
			return (mPrivateFlags & OPAQUE_MASK) == OPAQUE_MASK && ((mTransformationInfo != null
				 ? mTransformationInfo.mAlpha : 1) >= 1.0f - android.view.ViewConfiguration.ALPHA_THRESHOLD
				);
		}

		/// <hide></hide>
		protected internal virtual void computeOpaqueFlags()
		{
			// Opaque if:
			//   - Has a background
			//   - Background is opaque
			//   - Doesn't have scrollbars or scrollbars are inside overlay
			if (mBGDrawable != null && mBGDrawable.getOpacity() == android.graphics.PixelFormat
				.OPAQUE)
			{
				mPrivateFlags |= OPAQUE_BACKGROUND;
			}
			else
			{
				mPrivateFlags &= ~OPAQUE_BACKGROUND;
			}
			int flags = mViewFlags;
			if (((flags & SCROLLBARS_VERTICAL) == 0 && (flags & SCROLLBARS_HORIZONTAL) == 0) 
				|| (flags & SCROLLBARS_STYLE_MASK) == SCROLLBARS_INSIDE_OVERLAY)
			{
				mPrivateFlags |= OPAQUE_SCROLLBARS;
			}
			else
			{
				mPrivateFlags &= ~OPAQUE_SCROLLBARS;
			}
		}

		/// <hide></hide>
		protected internal virtual bool hasOpaqueScrollbars()
		{
			return (mPrivateFlags & OPAQUE_SCROLLBARS) == OPAQUE_SCROLLBARS;
		}

		/// <returns>
		/// A handler associated with the thread running the View. This
		/// handler can be used to pump events in the UI events queue.
		/// </returns>
		public virtual android.os.Handler getHandler()
		{
			if (mAttachInfo != null)
			{
				return mAttachInfo.mHandler;
			}
			return null;
		}

		/// <summary><p>Causes the Runnable to be added to the message queue.</summary>
		/// <remarks>
		/// <p>Causes the Runnable to be added to the message queue.
		/// The runnable will be run on the user interface thread.</p>
		/// <p>This method can be invoked from outside of the UI thread
		/// only when this View is attached to a window.</p>
		/// </remarks>
		/// <param name="action">The Runnable that will be executed.</param>
		/// <returns>
		/// Returns true if the Runnable was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.
		/// </returns>
		public virtual bool post(java.lang.Runnable action)
		{
			android.os.Handler handler;
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (attachInfo != null)
			{
				handler = attachInfo.mHandler;
			}
			else
			{
				// Assume that post will succeed later
				android.view.ViewRootImpl.getRunQueue().post(action);
				return true;
			}
			return handler.post(action);
		}

		/// <summary>
		/// <p>Causes the Runnable to be added to the message queue, to be run
		/// after the specified amount of time elapses.
		/// </summary>
		/// <remarks>
		/// <p>Causes the Runnable to be added to the message queue, to be run
		/// after the specified amount of time elapses.
		/// The runnable will be run on the user interface thread.</p>
		/// <p>This method can be invoked from outside of the UI thread
		/// only when this View is attached to a window.</p>
		/// </remarks>
		/// <param name="action">The Runnable that will be executed.</param>
		/// <param name="delayMillis">
		/// The delay (in milliseconds) until the Runnable
		/// will be executed.
		/// </param>
		/// <returns>
		/// true if the Runnable was successfully placed in to the
		/// message queue.  Returns false on failure, usually because the
		/// looper processing the message queue is exiting.  Note that a
		/// result of true does not mean the Runnable will be processed --
		/// if the looper is quit before the delivery time of the message
		/// occurs then the message will be dropped.
		/// </returns>
		public virtual bool postDelayed(java.lang.Runnable action, long delayMillis)
		{
			android.os.Handler handler;
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (attachInfo != null)
			{
				handler = attachInfo.mHandler;
			}
			else
			{
				// Assume that post will succeed later
				android.view.ViewRootImpl.getRunQueue().postDelayed(action, delayMillis);
				return true;
			}
			return handler.postDelayed(action, delayMillis);
		}

		/// <summary>
		/// <p>Removes the specified Runnable from the message queue.</p>
		/// <p>This method can be invoked from outside of the UI thread
		/// only when this View is attached to a window.</p>
		/// </summary>
		/// <param name="action">The Runnable to remove from the message handling queue</param>
		/// <returns>
		/// true if this view could ask the Handler to remove the Runnable,
		/// false otherwise. When the returned value is true, the Runnable
		/// may or may not have been actually removed from the message queue
		/// (for instance, if the Runnable was not in the queue already.)
		/// </returns>
		public virtual bool removeCallbacks(java.lang.Runnable action)
		{
			android.os.Handler handler;
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (attachInfo != null)
			{
				handler = attachInfo.mHandler;
			}
			else
			{
				// Assume that post will succeed later
				android.view.ViewRootImpl.getRunQueue().removeCallbacks(action);
				return true;
			}
			handler.removeCallbacks(action);
			return true;
		}

		/// <summary><p>Cause an invalidate to happen on a subsequent cycle through the event loop.
		/// 	</summary>
		/// <remarks>
		/// <p>Cause an invalidate to happen on a subsequent cycle through the event loop.
		/// Use this to invalidate the View from a non-UI thread.</p>
		/// <p>This method can be invoked from outside of the UI thread
		/// only when this View is attached to a window.</p>
		/// </remarks>
		/// <seealso cref="invalidate()">invalidate()</seealso>
		public virtual void postInvalidate()
		{
			postInvalidateDelayed(0);
		}

		/// <summary>
		/// <p>Cause an invalidate of the specified area to happen on a subsequent cycle
		/// through the event loop.
		/// </summary>
		/// <remarks>
		/// <p>Cause an invalidate of the specified area to happen on a subsequent cycle
		/// through the event loop. Use this to invalidate the View from a non-UI thread.</p>
		/// <p>This method can be invoked from outside of the UI thread
		/// only when this View is attached to a window.</p>
		/// </remarks>
		/// <param name="left">The left coordinate of the rectangle to invalidate.</param>
		/// <param name="top">The top coordinate of the rectangle to invalidate.</param>
		/// <param name="right">The right coordinate of the rectangle to invalidate.</param>
		/// <param name="bottom">The bottom coordinate of the rectangle to invalidate.</param>
		/// <seealso cref="invalidate(int, int, int, int)">invalidate(int, int, int, int)</seealso>
		/// <seealso cref="invalidate(android.graphics.Rect)">invalidate(android.graphics.Rect)
		/// 	</seealso>
		public virtual void postInvalidate(int left, int top, int right, int bottom)
		{
			postInvalidateDelayed(0, left, top, right, bottom);
		}

		/// <summary>
		/// <p>Cause an invalidate to happen on a subsequent cycle through the event
		/// loop.
		/// </summary>
		/// <remarks>
		/// <p>Cause an invalidate to happen on a subsequent cycle through the event
		/// loop. Waits for the specified amount of time.</p>
		/// <p>This method can be invoked from outside of the UI thread
		/// only when this View is attached to a window.</p>
		/// </remarks>
		/// <param name="delayMilliseconds">
		/// the duration in milliseconds to delay the
		/// invalidation by
		/// </param>
		public virtual void postInvalidateDelayed(long delayMilliseconds)
		{
			// We try only with the AttachInfo because there's no point in invalidating
			// if we are not attached to our window
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (attachInfo != null)
			{
				android.os.Message msg = android.os.Message.obtain();
				msg.what = android.view.View.AttachInfo.INVALIDATE_MSG;
				msg.obj = this;
				attachInfo.mHandler.sendMessageDelayed(msg, delayMilliseconds);
			}
		}

		/// <summary>
		/// <p>Cause an invalidate of the specified area to happen on a subsequent cycle
		/// through the event loop.
		/// </summary>
		/// <remarks>
		/// <p>Cause an invalidate of the specified area to happen on a subsequent cycle
		/// through the event loop. Waits for the specified amount of time.</p>
		/// <p>This method can be invoked from outside of the UI thread
		/// only when this View is attached to a window.</p>
		/// </remarks>
		/// <param name="delayMilliseconds">
		/// the duration in milliseconds to delay the
		/// invalidation by
		/// </param>
		/// <param name="left">The left coordinate of the rectangle to invalidate.</param>
		/// <param name="top">The top coordinate of the rectangle to invalidate.</param>
		/// <param name="right">The right coordinate of the rectangle to invalidate.</param>
		/// <param name="bottom">The bottom coordinate of the rectangle to invalidate.</param>
		public virtual void postInvalidateDelayed(long delayMilliseconds, int left, int top
			, int right, int bottom)
		{
			// We try only with the AttachInfo because there's no point in invalidating
			// if we are not attached to our window
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (attachInfo != null)
			{
				android.view.View.AttachInfo.InvalidateInfo info = android.view.View.AttachInfo.InvalidateInfo
					.acquire();
				info.target = this;
				info.left = left;
				info.top = top;
				info.right = right;
				info.bottom = bottom;
				android.os.Message msg = android.os.Message.obtain();
				msg.what = android.view.View.AttachInfo.INVALIDATE_RECT_MSG;
				msg.obj = info;
				attachInfo.mHandler.sendMessageDelayed(msg, delayMilliseconds);
			}
		}

		/// <summary>
		/// Post a callback to send a
		/// <see cref="android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED">android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED
		/// 	</see>
		/// event.
		/// This event is sent at most once every
		/// <see cref="ViewConfiguration.getSendRecurringAccessibilityEventsInterval()">ViewConfiguration.getSendRecurringAccessibilityEventsInterval()
		/// 	</see>
		/// .
		/// </summary>
		private void postSendViewScrolledAccessibilityEventCallback()
		{
			if (mSendViewScrolledAccessibilityEvent == null)
			{
				mSendViewScrolledAccessibilityEvent = new android.view.View.SendViewScrolledAccessibilityEvent
					(this);
			}
			if (!mSendViewScrolledAccessibilityEvent.mIsPending)
			{
				mSendViewScrolledAccessibilityEvent.mIsPending = true;
				postDelayed(mSendViewScrolledAccessibilityEvent, android.view.ViewConfiguration.getSendRecurringAccessibilityEventsInterval
					());
			}
		}

		/// <summary>
		/// Called by a parent to request that a child update its values for mScrollX
		/// and mScrollY if necessary.
		/// </summary>
		/// <remarks>
		/// Called by a parent to request that a child update its values for mScrollX
		/// and mScrollY if necessary. This will typically be done if the child is
		/// animating a scroll using a
		/// <see cref="android.widget.Scroller">Scroller</see>
		/// object.
		/// </remarks>
		public virtual void computeScroll()
		{
		}

		/// <summary>
		/// <p>Indicate whether the horizontal edges are faded when the view is
		/// scrolled horizontally.</p>
		/// </summary>
		/// <returns>
		/// true if the horizontal edges should are faded on scroll, false
		/// otherwise
		/// </returns>
		/// <seealso cref="setHorizontalFadingEdgeEnabled(bool)">setHorizontalFadingEdgeEnabled(bool)
		/// 	</seealso>
		/// <attr>ref android.R.styleable#View_requiresFadingEdge</attr>
		public virtual bool isHorizontalFadingEdgeEnabled()
		{
			return (mViewFlags & FADING_EDGE_HORIZONTAL) == FADING_EDGE_HORIZONTAL;
		}

		/// <summary>
		/// <p>Define whether the horizontal edges should be faded when this view
		/// is scrolled horizontally.</p>
		/// </summary>
		/// <param name="horizontalFadingEdgeEnabled">
		/// true if the horizontal edges should
		/// be faded when the view is scrolled
		/// horizontally
		/// </param>
		/// <seealso cref="isHorizontalFadingEdgeEnabled()">isHorizontalFadingEdgeEnabled()</seealso>
		/// <attr>ref android.R.styleable#View_requiresFadingEdge</attr>
		public virtual void setHorizontalFadingEdgeEnabled(bool horizontalFadingEdgeEnabled
			)
		{
			if (isHorizontalFadingEdgeEnabled() != horizontalFadingEdgeEnabled)
			{
				if (horizontalFadingEdgeEnabled)
				{
					initScrollCache();
				}
				mViewFlags ^= FADING_EDGE_HORIZONTAL;
			}
		}

		/// <summary>
		/// <p>Indicate whether the vertical edges are faded when the view is
		/// scrolled horizontally.</p>
		/// </summary>
		/// <returns>
		/// true if the vertical edges should are faded on scroll, false
		/// otherwise
		/// </returns>
		/// <seealso cref="setVerticalFadingEdgeEnabled(bool)">setVerticalFadingEdgeEnabled(bool)
		/// 	</seealso>
		/// <attr>ref android.R.styleable#View_requiresFadingEdge</attr>
		public virtual bool isVerticalFadingEdgeEnabled()
		{
			return (mViewFlags & FADING_EDGE_VERTICAL) == FADING_EDGE_VERTICAL;
		}

		/// <summary>
		/// <p>Define whether the vertical edges should be faded when this view
		/// is scrolled vertically.</p>
		/// </summary>
		/// <param name="verticalFadingEdgeEnabled">
		/// true if the vertical edges should
		/// be faded when the view is scrolled
		/// vertically
		/// </param>
		/// <seealso cref="isVerticalFadingEdgeEnabled()">isVerticalFadingEdgeEnabled()</seealso>
		/// <attr>ref android.R.styleable#View_requiresFadingEdge</attr>
		public virtual void setVerticalFadingEdgeEnabled(bool verticalFadingEdgeEnabled)
		{
			if (isVerticalFadingEdgeEnabled() != verticalFadingEdgeEnabled)
			{
				if (verticalFadingEdgeEnabled)
				{
					initScrollCache();
				}
				mViewFlags ^= FADING_EDGE_VERTICAL;
			}
		}

		/// <summary>Returns the strength, or intensity, of the top faded edge.</summary>
		/// <remarks>
		/// Returns the strength, or intensity, of the top faded edge. The strength is
		/// a value between 0.0 (no fade) and 1.0 (full fade). The default implementation
		/// returns 0.0 or 1.0 but no value in between.
		/// Subclasses should override this method to provide a smoother fade transition
		/// when scrolling occurs.
		/// </remarks>
		/// <returns>the intensity of the top fade as a float between 0.0f and 1.0f</returns>
		protected internal virtual float getTopFadingEdgeStrength()
		{
			return computeVerticalScrollOffset() > 0 ? 1.0f : 0.0f;
		}

		/// <summary>Returns the strength, or intensity, of the bottom faded edge.</summary>
		/// <remarks>
		/// Returns the strength, or intensity, of the bottom faded edge. The strength is
		/// a value between 0.0 (no fade) and 1.0 (full fade). The default implementation
		/// returns 0.0 or 1.0 but no value in between.
		/// Subclasses should override this method to provide a smoother fade transition
		/// when scrolling occurs.
		/// </remarks>
		/// <returns>the intensity of the bottom fade as a float between 0.0f and 1.0f</returns>
		protected internal virtual float getBottomFadingEdgeStrength()
		{
			return computeVerticalScrollOffset() + computeVerticalScrollExtent() < computeVerticalScrollRange
				() ? 1.0f : 0.0f;
		}

		/// <summary>Returns the strength, or intensity, of the left faded edge.</summary>
		/// <remarks>
		/// Returns the strength, or intensity, of the left faded edge. The strength is
		/// a value between 0.0 (no fade) and 1.0 (full fade). The default implementation
		/// returns 0.0 or 1.0 but no value in between.
		/// Subclasses should override this method to provide a smoother fade transition
		/// when scrolling occurs.
		/// </remarks>
		/// <returns>the intensity of the left fade as a float between 0.0f and 1.0f</returns>
		protected internal virtual float getLeftFadingEdgeStrength()
		{
			return computeHorizontalScrollOffset() > 0 ? 1.0f : 0.0f;
		}

		/// <summary>Returns the strength, or intensity, of the right faded edge.</summary>
		/// <remarks>
		/// Returns the strength, or intensity, of the right faded edge. The strength is
		/// a value between 0.0 (no fade) and 1.0 (full fade). The default implementation
		/// returns 0.0 or 1.0 but no value in between.
		/// Subclasses should override this method to provide a smoother fade transition
		/// when scrolling occurs.
		/// </remarks>
		/// <returns>the intensity of the right fade as a float between 0.0f and 1.0f</returns>
		protected internal virtual float getRightFadingEdgeStrength()
		{
			return computeHorizontalScrollOffset() + computeHorizontalScrollExtent() < computeHorizontalScrollRange
				() ? 1.0f : 0.0f;
		}

		/// <summary><p>Indicate whether the horizontal scrollbar should be drawn or not.</summary>
		/// <remarks>
		/// <p>Indicate whether the horizontal scrollbar should be drawn or not. The
		/// scrollbar is not drawn by default.</p>
		/// </remarks>
		/// <returns>
		/// true if the horizontal scrollbar should be painted, false
		/// otherwise
		/// </returns>
		/// <seealso cref="setHorizontalScrollBarEnabled(bool)">setHorizontalScrollBarEnabled(bool)
		/// 	</seealso>
		public virtual bool isHorizontalScrollBarEnabled()
		{
			return (mViewFlags & SCROLLBARS_HORIZONTAL) == SCROLLBARS_HORIZONTAL;
		}

		/// <summary><p>Define whether the horizontal scrollbar should be drawn or not.</summary>
		/// <remarks>
		/// <p>Define whether the horizontal scrollbar should be drawn or not. The
		/// scrollbar is not drawn by default.</p>
		/// </remarks>
		/// <param name="horizontalScrollBarEnabled">
		/// true if the horizontal scrollbar should
		/// be painted
		/// </param>
		/// <seealso cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</seealso>
		public virtual void setHorizontalScrollBarEnabled(bool horizontalScrollBarEnabled
			)
		{
			if (isHorizontalScrollBarEnabled() != horizontalScrollBarEnabled)
			{
				mViewFlags ^= SCROLLBARS_HORIZONTAL;
				computeOpaqueFlags();
				resolvePadding();
			}
		}

		/// <summary><p>Indicate whether the vertical scrollbar should be drawn or not.</summary>
		/// <remarks>
		/// <p>Indicate whether the vertical scrollbar should be drawn or not. The
		/// scrollbar is not drawn by default.</p>
		/// </remarks>
		/// <returns>
		/// true if the vertical scrollbar should be painted, false
		/// otherwise
		/// </returns>
		/// <seealso cref="setVerticalScrollBarEnabled(bool)">setVerticalScrollBarEnabled(bool)
		/// 	</seealso>
		public virtual bool isVerticalScrollBarEnabled()
		{
			return (mViewFlags & SCROLLBARS_VERTICAL) == SCROLLBARS_VERTICAL;
		}

		/// <summary><p>Define whether the vertical scrollbar should be drawn or not.</summary>
		/// <remarks>
		/// <p>Define whether the vertical scrollbar should be drawn or not. The
		/// scrollbar is not drawn by default.</p>
		/// </remarks>
		/// <param name="verticalScrollBarEnabled">
		/// true if the vertical scrollbar should
		/// be painted
		/// </param>
		/// <seealso cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</seealso>
		public virtual void setVerticalScrollBarEnabled(bool verticalScrollBarEnabled)
		{
			if (isVerticalScrollBarEnabled() != verticalScrollBarEnabled)
			{
				mViewFlags ^= SCROLLBARS_VERTICAL;
				computeOpaqueFlags();
				resolvePadding();
			}
		}

		/// <hide></hide>
		protected internal virtual void recomputePadding()
		{
			setPadding(mUserPaddingLeft, mPaddingTop, mUserPaddingRight, mUserPaddingBottom);
		}

		/// <summary>Define whether scrollbars will fade when the view is not scrolling.</summary>
		/// <remarks>Define whether scrollbars will fade when the view is not scrolling.</remarks>
		/// <param name="fadeScrollbars">wheter to enable fading</param>
		public virtual void setScrollbarFadingEnabled(bool fadeScrollbars)
		{
			initScrollCache();
			android.view.View.ScrollabilityCache scrollabilityCache = mScrollCache;
			scrollabilityCache.fadeScrollBars = fadeScrollbars;
			if (fadeScrollbars)
			{
				scrollabilityCache.state = android.view.View.ScrollabilityCache.OFF;
			}
			else
			{
				scrollabilityCache.state = android.view.View.ScrollabilityCache.ON;
			}
		}

		/// <summary>Returns true if scrollbars will fade when this view is not scrolling</summary>
		/// <returns>true if scrollbar fading is enabled</returns>
		public virtual bool isScrollbarFadingEnabled()
		{
			return mScrollCache != null && mScrollCache.fadeScrollBars;
		}

		/// <summary><p>Specify the style of the scrollbars.</summary>
		/// <remarks>
		/// <p>Specify the style of the scrollbars. The scrollbars can be overlaid or
		/// inset. When inset, they add to the padding of the view. And the scrollbars
		/// can be drawn inside the padding area or on the edge of the view. For example,
		/// if a view has a background drawable and you want to draw the scrollbars
		/// inside the padding specified by the drawable, you can use
		/// SCROLLBARS_INSIDE_OVERLAY or SCROLLBARS_INSIDE_INSET. If you want them to
		/// appear at the edge of the view, ignoring the padding, then you can use
		/// SCROLLBARS_OUTSIDE_OVERLAY or SCROLLBARS_OUTSIDE_INSET.</p>
		/// </remarks>
		/// <param name="style">
		/// the style of the scrollbars. Should be one of
		/// SCROLLBARS_INSIDE_OVERLAY, SCROLLBARS_INSIDE_INSET,
		/// SCROLLBARS_OUTSIDE_OVERLAY or SCROLLBARS_OUTSIDE_INSET.
		/// </param>
		/// <seealso cref="SCROLLBARS_INSIDE_OVERLAY">SCROLLBARS_INSIDE_OVERLAY</seealso>
		/// <seealso cref="SCROLLBARS_INSIDE_INSET">SCROLLBARS_INSIDE_INSET</seealso>
		/// <seealso cref="SCROLLBARS_OUTSIDE_OVERLAY">SCROLLBARS_OUTSIDE_OVERLAY</seealso>
		/// <seealso cref="SCROLLBARS_OUTSIDE_INSET">SCROLLBARS_OUTSIDE_INSET</seealso>
		public virtual void setScrollBarStyle(int style)
		{
			if (style != (mViewFlags & SCROLLBARS_STYLE_MASK))
			{
				mViewFlags = (mViewFlags & ~SCROLLBARS_STYLE_MASK) | (style & SCROLLBARS_STYLE_MASK
					);
				computeOpaqueFlags();
				resolvePadding();
			}
		}

		/// <summary><p>Returns the current scrollbar style.</p></summary>
		/// <returns>the current scrollbar style</returns>
		/// <seealso cref="SCROLLBARS_INSIDE_OVERLAY">SCROLLBARS_INSIDE_OVERLAY</seealso>
		/// <seealso cref="SCROLLBARS_INSIDE_INSET">SCROLLBARS_INSIDE_INSET</seealso>
		/// <seealso cref="SCROLLBARS_OUTSIDE_OVERLAY">SCROLLBARS_OUTSIDE_OVERLAY</seealso>
		/// <seealso cref="SCROLLBARS_OUTSIDE_INSET">SCROLLBARS_OUTSIDE_INSET</seealso>
		public virtual int getScrollBarStyle()
		{
			return mViewFlags & SCROLLBARS_STYLE_MASK;
		}

		/// <summary>
		/// <p>Compute the horizontal range that the horizontal scrollbar
		/// represents.</p>
		/// <p>The range is expressed in arbitrary units that must be the same as the
		/// units used by
		/// <see cref="computeHorizontalScrollExtent()">computeHorizontalScrollExtent()</see>
		/// and
		/// <see cref="computeHorizontalScrollOffset()">computeHorizontalScrollOffset()</see>
		/// .</p>
		/// <p>The default range is the drawing width of this view.</p>
		/// </summary>
		/// <returns>
		/// the total horizontal range represented by the horizontal
		/// scrollbar
		/// </returns>
		/// <seealso cref="computeHorizontalScrollExtent()">computeHorizontalScrollExtent()</seealso>
		/// <seealso cref="computeHorizontalScrollOffset()">computeHorizontalScrollOffset()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		protected internal virtual int computeHorizontalScrollRange()
		{
			return getWidth();
		}

		/// <summary>
		/// <p>Compute the horizontal offset of the horizontal scrollbar's thumb
		/// within the horizontal range.
		/// </summary>
		/// <remarks>
		/// <p>Compute the horizontal offset of the horizontal scrollbar's thumb
		/// within the horizontal range. This value is used to compute the position
		/// of the thumb within the scrollbar's track.</p>
		/// <p>The range is expressed in arbitrary units that must be the same as the
		/// units used by
		/// <see cref="computeHorizontalScrollRange()">computeHorizontalScrollRange()</see>
		/// and
		/// <see cref="computeHorizontalScrollExtent()">computeHorizontalScrollExtent()</see>
		/// .</p>
		/// <p>The default offset is the scroll offset of this view.</p>
		/// </remarks>
		/// <returns>the horizontal offset of the scrollbar's thumb</returns>
		/// <seealso cref="computeHorizontalScrollRange()">computeHorizontalScrollRange()</seealso>
		/// <seealso cref="computeHorizontalScrollExtent()">computeHorizontalScrollExtent()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		protected internal virtual int computeHorizontalScrollOffset()
		{
			return mScrollX;
		}

		/// <summary>
		/// <p>Compute the horizontal extent of the horizontal scrollbar's thumb
		/// within the horizontal range.
		/// </summary>
		/// <remarks>
		/// <p>Compute the horizontal extent of the horizontal scrollbar's thumb
		/// within the horizontal range. This value is used to compute the length
		/// of the thumb within the scrollbar's track.</p>
		/// <p>The range is expressed in arbitrary units that must be the same as the
		/// units used by
		/// <see cref="computeHorizontalScrollRange()">computeHorizontalScrollRange()</see>
		/// and
		/// <see cref="computeHorizontalScrollOffset()">computeHorizontalScrollOffset()</see>
		/// .</p>
		/// <p>The default extent is the drawing width of this view.</p>
		/// </remarks>
		/// <returns>the horizontal extent of the scrollbar's thumb</returns>
		/// <seealso cref="computeHorizontalScrollRange()">computeHorizontalScrollRange()</seealso>
		/// <seealso cref="computeHorizontalScrollOffset()">computeHorizontalScrollOffset()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		protected internal virtual int computeHorizontalScrollExtent()
		{
			return getWidth();
		}

		/// <summary>
		/// <p>Compute the vertical range that the vertical scrollbar represents.</p>
		/// <p>The range is expressed in arbitrary units that must be the same as the
		/// units used by
		/// <see cref="computeVerticalScrollExtent()">computeVerticalScrollExtent()</see>
		/// and
		/// <see cref="computeVerticalScrollOffset()">computeVerticalScrollOffset()</see>
		/// .</p>
		/// </summary>
		/// <returns>
		/// the total vertical range represented by the vertical scrollbar
		/// <p>The default range is the drawing height of this view.</p>
		/// </returns>
		/// <seealso cref="computeVerticalScrollExtent()">computeVerticalScrollExtent()</seealso>
		/// <seealso cref="computeVerticalScrollOffset()">computeVerticalScrollOffset()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		protected internal virtual int computeVerticalScrollRange()
		{
			return getHeight();
		}

		/// <summary>
		/// <p>Compute the vertical offset of the vertical scrollbar's thumb
		/// within the horizontal range.
		/// </summary>
		/// <remarks>
		/// <p>Compute the vertical offset of the vertical scrollbar's thumb
		/// within the horizontal range. This value is used to compute the position
		/// of the thumb within the scrollbar's track.</p>
		/// <p>The range is expressed in arbitrary units that must be the same as the
		/// units used by
		/// <see cref="computeVerticalScrollRange()">computeVerticalScrollRange()</see>
		/// and
		/// <see cref="computeVerticalScrollExtent()">computeVerticalScrollExtent()</see>
		/// .</p>
		/// <p>The default offset is the scroll offset of this view.</p>
		/// </remarks>
		/// <returns>the vertical offset of the scrollbar's thumb</returns>
		/// <seealso cref="computeVerticalScrollRange()">computeVerticalScrollRange()</seealso>
		/// <seealso cref="computeVerticalScrollExtent()">computeVerticalScrollExtent()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		protected internal virtual int computeVerticalScrollOffset()
		{
			return mScrollY;
		}

		/// <summary>
		/// <p>Compute the vertical extent of the horizontal scrollbar's thumb
		/// within the vertical range.
		/// </summary>
		/// <remarks>
		/// <p>Compute the vertical extent of the horizontal scrollbar's thumb
		/// within the vertical range. This value is used to compute the length
		/// of the thumb within the scrollbar's track.</p>
		/// <p>The range is expressed in arbitrary units that must be the same as the
		/// units used by
		/// <see cref="computeVerticalScrollRange()">computeVerticalScrollRange()</see>
		/// and
		/// <see cref="computeVerticalScrollOffset()">computeVerticalScrollOffset()</see>
		/// .</p>
		/// <p>The default extent is the drawing height of this view.</p>
		/// </remarks>
		/// <returns>the vertical extent of the scrollbar's thumb</returns>
		/// <seealso cref="computeVerticalScrollRange()">computeVerticalScrollRange()</seealso>
		/// <seealso cref="computeVerticalScrollOffset()">computeVerticalScrollOffset()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		protected internal virtual int computeVerticalScrollExtent()
		{
			return getHeight();
		}

		/// <summary>Check if this view can be scrolled horizontally in a certain direction.</summary>
		/// <remarks>Check if this view can be scrolled horizontally in a certain direction.</remarks>
		/// <param name="direction">Negative to check scrolling left, positive to check scrolling right.
		/// 	</param>
		/// <returns>true if this view can be scrolled in the specified direction, false otherwise.
		/// 	</returns>
		public virtual bool canScrollHorizontally(int direction)
		{
			int offset = computeHorizontalScrollOffset();
			int range = computeHorizontalScrollRange() - computeHorizontalScrollExtent();
			if (range == 0)
			{
				return false;
			}
			if (direction < 0)
			{
				return offset > 0;
			}
			else
			{
				return offset < range - 1;
			}
		}

		/// <summary>Check if this view can be scrolled vertically in a certain direction.</summary>
		/// <remarks>Check if this view can be scrolled vertically in a certain direction.</remarks>
		/// <param name="direction">Negative to check scrolling up, positive to check scrolling down.
		/// 	</param>
		/// <returns>true if this view can be scrolled in the specified direction, false otherwise.
		/// 	</returns>
		public virtual bool canScrollVertically(int direction)
		{
			int offset = computeVerticalScrollOffset();
			int range = computeVerticalScrollRange() - computeVerticalScrollExtent();
			if (range == 0)
			{
				return false;
			}
			if (direction < 0)
			{
				return offset > 0;
			}
			else
			{
				return offset < range - 1;
			}
		}

		/// <summary><p>Request the drawing of the horizontal and the vertical scrollbar.</summary>
		/// <remarks>
		/// <p>Request the drawing of the horizontal and the vertical scrollbar. The
		/// scrollbars are painted only if they have been awakened first.</p>
		/// </remarks>
		/// <param name="canvas">the canvas on which to draw the scrollbars</param>
		/// <seealso cref="awakenScrollBars(int)">awakenScrollBars(int)</seealso>
		protected internal void onDrawScrollBars(android.graphics.Canvas canvas)
		{
			// scrollbars are drawn only when the animation is running
			android.view.View.ScrollabilityCache cache = mScrollCache;
			if (cache != null)
			{
				int state = cache.state;
				if (state == android.view.View.ScrollabilityCache.OFF)
				{
					return;
				}
				bool invalidate_1 = false;
				if (state == android.view.View.ScrollabilityCache.FADING)
				{
					// We're fading -- get our fade interpolation
					if (cache.interpolatorValues == null)
					{
						cache.interpolatorValues = new float[1];
					}
					float[] values = cache.interpolatorValues;
					// Stops the animation if we're done
					if (cache.scrollBarInterpolator.timeToValues(values) == android.graphics.Interpolator
						.Result.FREEZE_END)
					{
						cache.state = android.view.View.ScrollabilityCache.OFF;
					}
					else
					{
						cache.scrollBar.setAlpha(Sharpen.Util.Round(values[0]));
					}
					// This will make the scroll bars inval themselves after
					// drawing. We only want this when we're fading so that
					// we prevent excessive redraws
					invalidate_1 = true;
				}
				else
				{
					// We're just on -- but we may have been fading before so
					// reset alpha
					cache.scrollBar.setAlpha(255);
				}
				int viewFlags = mViewFlags;
				bool drawHorizontalScrollBar = (viewFlags & SCROLLBARS_HORIZONTAL) == SCROLLBARS_HORIZONTAL;
				bool drawVerticalScrollBar = (viewFlags & SCROLLBARS_VERTICAL) == SCROLLBARS_VERTICAL
					 && !isVerticalScrollBarHidden();
				if (drawVerticalScrollBar || drawHorizontalScrollBar)
				{
					int width = mRight - mLeft;
					int height = mBottom - mTop;
					android.widget.ScrollBarDrawable scrollBar = cache.scrollBar;
					int scrollX = mScrollX;
					int scrollY = mScrollY;
					int inside = (viewFlags & SCROLLBARS_OUTSIDE_MASK) == 0 ? ~0 : 0;
					int left;
					int top;
					int right;
					int bottom;
					if (drawHorizontalScrollBar)
					{
						int size = scrollBar.getSize(false);
						if (size <= 0)
						{
							size = cache.scrollBarSize;
						}
						scrollBar.setParameters(computeHorizontalScrollRange(), computeHorizontalScrollOffset
							(), computeHorizontalScrollExtent(), false);
						int verticalScrollBarGap = drawVerticalScrollBar ? getVerticalScrollbarWidth() : 
							0;
						top = scrollY + height - size - (mUserPaddingBottom & inside);
						left = scrollX + (mPaddingLeft & inside);
						right = scrollX + width - (mUserPaddingRight & inside) - verticalScrollBarGap;
						bottom = top + size;
						onDrawHorizontalScrollBar(canvas, scrollBar, left, top, right, bottom);
						if (invalidate_1)
						{
							invalidate(left, top, right, bottom);
						}
					}
					if (drawVerticalScrollBar)
					{
						int size = scrollBar.getSize(true);
						if (size <= 0)
						{
							size = cache.scrollBarSize;
						}
						scrollBar.setParameters(computeVerticalScrollRange(), computeVerticalScrollOffset
							(), computeVerticalScrollExtent(), true);
						switch (mVerticalScrollbarPosition)
						{
							case SCROLLBAR_POSITION_DEFAULT:
							case SCROLLBAR_POSITION_RIGHT:
							default:
							{
								left = scrollX + width - size - (mUserPaddingRight & inside);
								break;
							}

							case SCROLLBAR_POSITION_LEFT:
							{
								left = scrollX + (mUserPaddingLeft & inside);
								break;
							}
						}
						top = scrollY + (mPaddingTop & inside);
						right = left + size;
						bottom = scrollY + height - (mUserPaddingBottom & inside);
						onDrawVerticalScrollBar(canvas, scrollBar, left, top, right, bottom);
						if (invalidate_1)
						{
							invalidate(left, top, right, bottom);
						}
					}
				}
			}
		}

		/// <summary>
		/// Override this if the vertical scrollbar needs to be hidden in a subclass, like when
		/// FastScroller is visible.
		/// </summary>
		/// <remarks>
		/// Override this if the vertical scrollbar needs to be hidden in a subclass, like when
		/// FastScroller is visible.
		/// </remarks>
		/// <returns>whether to temporarily hide the vertical scrollbar</returns>
		/// <hide></hide>
		protected internal virtual bool isVerticalScrollBarHidden()
		{
			return false;
		}

		/// <summary>
		/// <p>Draw the horizontal scrollbar if
		/// <see cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</see>
		/// returns true.</p>
		/// </summary>
		/// <param name="canvas">the canvas on which to draw the scrollbar</param>
		/// <param name="scrollBar">the scrollbar's drawable</param>
		/// <seealso cref="isHorizontalScrollBarEnabled()">isHorizontalScrollBarEnabled()</seealso>
		/// <seealso cref="computeHorizontalScrollRange()">computeHorizontalScrollRange()</seealso>
		/// <seealso cref="computeHorizontalScrollExtent()">computeHorizontalScrollExtent()</seealso>
		/// <seealso cref="computeHorizontalScrollOffset()">computeHorizontalScrollOffset()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		/// <hide></hide>
		protected internal virtual void onDrawHorizontalScrollBar(android.graphics.Canvas
			 canvas, android.graphics.drawable.Drawable scrollBar, int l, int t, int r, int 
			b)
		{
			scrollBar.setBounds(l, t, r, b);
			scrollBar.draw(canvas);
		}

		/// <summary>
		/// <p>Draw the vertical scrollbar if
		/// <see cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</see>
		/// returns true.</p>
		/// </summary>
		/// <param name="canvas">the canvas on which to draw the scrollbar</param>
		/// <param name="scrollBar">the scrollbar's drawable</param>
		/// <seealso cref="isVerticalScrollBarEnabled()">isVerticalScrollBarEnabled()</seealso>
		/// <seealso cref="computeVerticalScrollRange()">computeVerticalScrollRange()</seealso>
		/// <seealso cref="computeVerticalScrollExtent()">computeVerticalScrollExtent()</seealso>
		/// <seealso cref="computeVerticalScrollOffset()">computeVerticalScrollOffset()</seealso>
		/// <seealso cref="android.widget.ScrollBarDrawable">android.widget.ScrollBarDrawable
		/// 	</seealso>
		/// <hide></hide>
		protected internal virtual void onDrawVerticalScrollBar(android.graphics.Canvas canvas
			, android.graphics.drawable.Drawable scrollBar, int l, int t, int r, int b)
		{
			scrollBar.setBounds(l, t, r, b);
			scrollBar.draw(canvas);
		}

		/// <summary>Implement this to do your drawing.</summary>
		/// <remarks>Implement this to do your drawing.</remarks>
		/// <param name="canvas">the canvas on which the background will be drawn</param>
		protected internal virtual void onDraw(android.graphics.Canvas canvas)
		{
		}

		internal virtual void assignParent(android.view.ViewParent parent)
		{
			if (mParent == null)
			{
				mParent = parent;
			}
			else
			{
				if (parent == null)
				{
					mParent = null;
				}
				else
				{
					throw new java.lang.RuntimeException("view " + this + " being added, but" + " it already has a parent"
						);
				}
			}
		}

		/// <summary>This is called when the view is attached to a window.</summary>
		/// <remarks>
		/// This is called when the view is attached to a window.  At this point it
		/// has a Surface and will start drawing.  Note that this function is
		/// guaranteed to be called before
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// ,
		/// however it may be called any time before the first onDraw -- including
		/// before or after
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// .
		/// </remarks>
		/// <seealso cref="onDetachedFromWindow()">onDetachedFromWindow()</seealso>
		protected internal virtual void onAttachedToWindow()
		{
			if ((mPrivateFlags & REQUEST_TRANSPARENT_REGIONS) != 0)
			{
				mParent.requestTransparentRegion(this);
			}
			if ((mPrivateFlags & AWAKEN_SCROLL_BARS_ON_ATTACH) != 0)
			{
				initialAwakenScrollBars();
				mPrivateFlags &= ~AWAKEN_SCROLL_BARS_ON_ATTACH;
			}
			jumpDrawablesToCurrentState();
			// Order is important here: LayoutDirection MUST be resolved before Padding
			// and TextDirection
			resolveLayoutDirectionIfNeeded();
			resolvePadding();
			resolveTextDirection();
			if (isFocused())
			{
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.peekInstance();
				imm.focusIn(this);
			}
		}

		/// <summary>Resolve and cache the layout direction.</summary>
		/// <remarks>
		/// Resolve and cache the layout direction. LTR is set initially. This is implicitly supposing
		/// that the parent directionality can and will be resolved before its children.
		/// </remarks>
		private void resolveLayoutDirectionIfNeeded()
		{
			// Do not resolve if it is not needed
			if ((mPrivateFlags2 & LAYOUT_DIRECTION_RESOLVED) == LAYOUT_DIRECTION_RESOLVED)
			{
				return;
			}
			// Clear any previous layout direction resolution
			mPrivateFlags2 &= ~LAYOUT_DIRECTION_RESOLVED_RTL;
			// Reset also TextDirection as a change into LayoutDirection may impact the selected
			// TextDirectionHeuristic
			resetResolvedTextDirection();
			switch (getLayoutDirection())
			{
				case LAYOUT_DIRECTION_INHERIT:
				{
					// Set resolved depending on layout direction
					// We cannot do the resolution if there is no parent
					if (mParent == null)
					{
						return;
					}
					// If this is root view, no need to look at parent's layout dir.
					if (mParent is android.view.ViewGroup)
					{
						android.view.ViewGroup viewGroup = ((android.view.ViewGroup)mParent);
						// Check if the parent view group can resolve
						if (!viewGroup.canResolveLayoutDirection())
						{
							return;
						}
						if (viewGroup.getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL)
						{
							mPrivateFlags2 |= LAYOUT_DIRECTION_RESOLVED_RTL;
						}
					}
					break;
				}

				case LAYOUT_DIRECTION_RTL:
				{
					mPrivateFlags2 |= LAYOUT_DIRECTION_RESOLVED_RTL;
					break;
				}

				case LAYOUT_DIRECTION_LOCALE:
				{
					if (isLayoutDirectionRtl(System.Globalization.CultureInfo.CurrentCulture))
					{
						mPrivateFlags2 |= LAYOUT_DIRECTION_RESOLVED_RTL;
					}
					break;
				}

				default:
				{
					break;
				}
			}
			// Nothing to do, LTR by default
			// Set to resolved
			mPrivateFlags2 |= LAYOUT_DIRECTION_RESOLVED;
		}

		/// <hide></hide>
		protected internal virtual void resolvePadding()
		{
			switch (getResolvedLayoutDirection())
			{
				case LAYOUT_DIRECTION_RTL:
				{
					// If the user specified the absolute padding (either with android:padding or
					// android:paddingLeft/Top/Right/Bottom), use this padding, otherwise
					// use the default padding or the padding from the background drawable
					// (stored at this point in mPadding*)
					// Start user padding override Right user padding. Otherwise, if Right user
					// padding is not defined, use the default Right padding. If Right user padding
					// is defined, just use it.
					if (mUserPaddingStart >= 0)
					{
						mUserPaddingRight = mUserPaddingStart;
					}
					else
					{
						if (mUserPaddingRight < 0)
						{
							mUserPaddingRight = mPaddingRight;
						}
					}
					if (mUserPaddingEnd >= 0)
					{
						mUserPaddingLeft = mUserPaddingEnd;
					}
					else
					{
						if (mUserPaddingLeft < 0)
						{
							mUserPaddingLeft = mPaddingLeft;
						}
					}
					break;
				}

				case LAYOUT_DIRECTION_LTR:
				default:
				{
					// Start user padding override Left user padding. Otherwise, if Left user
					// padding is not defined, use the default left padding. If Left user padding
					// is defined, just use it.
					if (mUserPaddingStart >= 0)
					{
						mUserPaddingLeft = mUserPaddingStart;
					}
					else
					{
						if (mUserPaddingLeft < 0)
						{
							mUserPaddingLeft = mPaddingLeft;
						}
					}
					if (mUserPaddingEnd >= 0)
					{
						mUserPaddingRight = mUserPaddingEnd;
					}
					else
					{
						if (mUserPaddingRight < 0)
						{
							mUserPaddingRight = mPaddingRight;
						}
					}
					break;
				}
			}
			mUserPaddingBottom = (mUserPaddingBottom >= 0) ? mUserPaddingBottom : mPaddingBottom;
			recomputePadding();
		}

		/// <summary>Return true if layout direction resolution can be done</summary>
		/// <hide></hide>
		protected internal virtual bool canResolveLayoutDirection()
		{
			switch (getLayoutDirection())
			{
				case LAYOUT_DIRECTION_INHERIT:
				{
					return (mParent != null);
				}

				default:
				{
					return true;
				}
			}
		}

		/// <summary>Reset the resolved layout direction.</summary>
		/// <remarks>
		/// Reset the resolved layout direction.
		/// Subclasses need to override this method to clear cached information that depends on the
		/// resolved layout direction, or to inform child views that inherit their layout direction.
		/// Overrides must also call the superclass implementation at the start of their implementation.
		/// </remarks>
		/// <hide></hide>
		protected internal virtual void resetResolvedLayoutDirection()
		{
			// Reset the current View resolution
			mPrivateFlags2 &= ~LAYOUT_DIRECTION_RESOLVED;
		}

		/// <summary>Check if a Locale is corresponding to a RTL script.</summary>
		/// <remarks>Check if a Locale is corresponding to a RTL script.</remarks>
		/// <param name="locale">Locale to check</param>
		/// <returns>true if a Locale is corresponding to a RTL script.</returns>
		/// <hide></hide>
		protected internal static bool isLayoutDirectionRtl(System.Globalization.CultureInfo
			 locale)
		{
			return (android.util.LocaleUtil.TEXT_LAYOUT_DIRECTION_RTL_DO_NOT_USE == android.util.LocaleUtil
				.getLayoutDirectionFromLocale(locale));
		}

		/// <summary>This is called when the view is detached from a window.</summary>
		/// <remarks>
		/// This is called when the view is detached from a window.  At this point it
		/// no longer has a surface for drawing.
		/// </remarks>
		/// <seealso cref="onAttachedToWindow()">onAttachedToWindow()</seealso>
		protected internal virtual void onDetachedFromWindow()
		{
			mPrivateFlags &= ~CANCEL_NEXT_UP_EVENT;
			removeUnsetPressCallback();
			removeLongPressCallback();
			removePerformClickCallback();
			removeSendViewScrolledAccessibilityEventCallback();
			destroyDrawingCache();
			destroyLayer();
			if (mDisplayList != null)
			{
				mDisplayList.invalidate();
			}
			if (mAttachInfo != null)
			{
				mAttachInfo.mHandler.removeMessages(android.view.View.AttachInfo.INVALIDATE_MSG, 
					this);
			}
			mCurrentAnimation = null;
			resetResolvedLayoutDirection();
			resetResolvedTextDirection();
		}

		/// <returns>The number of times this view has been attached to a window</returns>
		protected internal virtual int getWindowAttachCount()
		{
			return mWindowAttachCount;
		}

		/// <summary>Retrieve a unique token identifying the window this view is attached to.
		/// 	</summary>
		/// <remarks>Retrieve a unique token identifying the window this view is attached to.
		/// 	</remarks>
		/// <returns>
		/// Return the window's token for use in
		/// <see cref="LayoutParams.token">WindowManager.LayoutParams.token</see>
		/// .
		/// </returns>
		public virtual android.os.IBinder getWindowToken()
		{
			return mAttachInfo != null ? mAttachInfo.mWindowToken : null;
		}

		/// <summary>
		/// Retrieve a unique token identifying the top-level "real" window of
		/// the window that this view is attached to.
		/// </summary>
		/// <remarks>
		/// Retrieve a unique token identifying the top-level "real" window of
		/// the window that this view is attached to.  That is, this is like
		/// <see cref="getWindowToken()">getWindowToken()</see>
		/// , except if the window this view in is a panel
		/// window (attached to another containing window), then the token of
		/// the containing window is returned instead.
		/// </remarks>
		/// <returns>
		/// Returns the associated window token, either
		/// <see cref="getWindowToken()">getWindowToken()</see>
		/// or the containing window's token.
		/// </returns>
		public virtual android.os.IBinder getApplicationWindowToken()
		{
			android.view.View.AttachInfo ai = mAttachInfo;
			if (ai != null)
			{
				android.os.IBinder appWindowToken = ai.mPanelParentWindowToken;
				if (appWindowToken == null)
				{
					appWindowToken = ai.mWindowToken;
				}
				return appWindowToken;
			}
			return null;
		}

		/// <summary>
		/// Retrieve private session object this view hierarchy is using to
		/// communicate with the window manager.
		/// </summary>
		/// <remarks>
		/// Retrieve private session object this view hierarchy is using to
		/// communicate with the window manager.
		/// </remarks>
		/// <returns>the session object to communicate with the window manager</returns>
		internal virtual android.view.IWindowSession getWindowSession()
		{
			return mAttachInfo != null ? mAttachInfo.mSession : null;
		}

		/// <param name="info">
		/// the
		/// <see cref="AttachInfo">AttachInfo</see>
		/// to associated with
		/// this view
		/// </param>
		internal virtual void dispatchAttachedToWindow(android.view.View.AttachInfo info, 
			int visibility)
		{
			//System.out.println("Attached! " + this);
			mAttachInfo = info;
			mWindowAttachCount++;
			// We will need to evaluate the drawable state at least once.
			mPrivateFlags |= DRAWABLE_STATE_DIRTY;
			if (mFloatingTreeObserver != null)
			{
				info.mTreeObserver.merge(mFloatingTreeObserver);
				mFloatingTreeObserver = null;
			}
			if ((mPrivateFlags & SCROLL_CONTAINER) != 0)
			{
				mAttachInfo.mScrollContainers.add(this);
				mPrivateFlags |= SCROLL_CONTAINER_ADDED;
			}
			performCollectViewAttributes(visibility);
			onAttachedToWindow();
			java.util.concurrent.CopyOnWriteArrayList<android.view.View.OnAttachStateChangeListener
				> listeners = mOnAttachStateChangeListeners;
			if (listeners != null && listeners.size() > 0)
			{
				// NOTE: because of the use of CopyOnWriteArrayList, we *must* use an iterator to
				// perform the dispatching. The iterator is a safe guard against listeners that
				// could mutate the list by calling the various add/remove methods. This prevents
				// the array from being modified while we iterate it.
				foreach (android.view.View.OnAttachStateChangeListener listener in Sharpen.IterableProxy.Create
					(listeners))
				{
					listener.onViewAttachedToWindow(this);
				}
			}
			int vis = info.mWindowVisibility;
			if (vis != GONE)
			{
				onWindowVisibilityChanged(vis);
			}
			if ((mPrivateFlags & DRAWABLE_STATE_DIRTY) != 0)
			{
				// If nobody has evaluated the drawable state yet, then do it now.
				refreshDrawableState();
			}
		}

		internal virtual void dispatchDetachedFromWindow()
		{
			android.view.View.AttachInfo info = mAttachInfo;
			if (info != null)
			{
				int vis = info.mWindowVisibility;
				if (vis != GONE)
				{
					onWindowVisibilityChanged(GONE);
				}
			}
			onDetachedFromWindow();
			java.util.concurrent.CopyOnWriteArrayList<android.view.View.OnAttachStateChangeListener
				> listeners = mOnAttachStateChangeListeners;
			if (listeners != null && listeners.size() > 0)
			{
				// NOTE: because of the use of CopyOnWriteArrayList, we *must* use an iterator to
				// perform the dispatching. The iterator is a safe guard against listeners that
				// could mutate the list by calling the various add/remove methods. This prevents
				// the array from being modified while we iterate it.
				foreach (android.view.View.OnAttachStateChangeListener listener in Sharpen.IterableProxy.Create
					(listeners))
				{
					listener.onViewDetachedFromWindow(this);
				}
			}
			if ((mPrivateFlags & SCROLL_CONTAINER_ADDED) != 0)
			{
				mAttachInfo.mScrollContainers.remove(this);
				mPrivateFlags &= ~SCROLL_CONTAINER_ADDED;
			}
			mAttachInfo = null;
		}

		/// <summary>Store this view hierarchy's frozen state into the given container.</summary>
		/// <remarks>Store this view hierarchy's frozen state into the given container.</remarks>
		/// <param name="container">The SparseArray in which to save the view's state.</param>
		/// <seealso cref="restoreHierarchyState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="dispatchSaveInstanceState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="onSaveInstanceState()"></seealso>
		public virtual void saveHierarchyState(android.util.SparseArray<android.os.Parcelable
			> container)
		{
			dispatchSaveInstanceState(container);
		}

		/// <summary>
		/// Called by
		/// <see cref="saveHierarchyState(android.util.SparseArray{E})">saveHierarchyState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// to store the state for
		/// this view and its children. May be overridden to modify how freezing happens to a
		/// view's children; for example, some views may want to not store state for their children.
		/// </summary>
		/// <param name="container">The SparseArray in which to save the view's state.</param>
		/// <seealso cref="dispatchRestoreInstanceState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="saveHierarchyState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="onSaveInstanceState()"></seealso>
		protected internal virtual void dispatchSaveInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			if (mID != NO_ID && (mViewFlags & SAVE_DISABLED_MASK) == 0)
			{
				mPrivateFlags &= ~SAVE_STATE_CALLED;
				android.os.Parcelable state = onSaveInstanceState();
				if ((mPrivateFlags & SAVE_STATE_CALLED) == 0)
				{
					throw new System.InvalidOperationException("Derived class did not call super.onSaveInstanceState()"
						);
				}
				if (state != null)
				{
					// Log.i("View", "Freezing #" + Integer.toHexString(mID)
					// + ": " + state);
					container.put(mID, state);
				}
			}
		}

		/// <summary>
		/// Hook allowing a view to generate a representation of its internal state
		/// that can later be used to create a new instance with that same state.
		/// </summary>
		/// <remarks>
		/// Hook allowing a view to generate a representation of its internal state
		/// that can later be used to create a new instance with that same state.
		/// This state should only contain information that is not persistent or can
		/// not be reconstructed later. For example, you will never store your
		/// current position on screen because that will be computed again when a
		/// new instance of the view is placed in its view hierarchy.
		/// <p>
		/// Some examples of things you may store here: the current cursor position
		/// in a text view (but usually not the text itself since that is stored in a
		/// content provider or other persistent storage), the currently selected
		/// item in a list view.
		/// </remarks>
		/// <returns>
		/// Returns a Parcelable object containing the view's current dynamic
		/// state, or null if there is nothing interesting to save. The
		/// default implementation returns null.
		/// </returns>
		/// <seealso cref="onRestoreInstanceState(android.os.Parcelable)"></seealso>
		/// <seealso cref="saveHierarchyState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="dispatchSaveInstanceState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="setSaveEnabled(bool)">setSaveEnabled(bool)</seealso>
		protected internal virtual android.os.Parcelable onSaveInstanceState()
		{
			mPrivateFlags |= SAVE_STATE_CALLED;
			return android.view.AbsSavedState.EMPTY_STATE;
		}

		/// <summary>Restore this view hierarchy's frozen state from the given container.</summary>
		/// <remarks>Restore this view hierarchy's frozen state from the given container.</remarks>
		/// <param name="container">The SparseArray which holds previously frozen states.</param>
		/// <seealso cref="saveHierarchyState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="dispatchRestoreInstanceState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="onRestoreInstanceState(android.os.Parcelable)"></seealso>
		public virtual void restoreHierarchyState(android.util.SparseArray<android.os.Parcelable
			> container)
		{
			dispatchRestoreInstanceState(container);
		}

		/// <summary>
		/// Called by
		/// <see cref="restoreHierarchyState(android.util.SparseArray{E})">restoreHierarchyState(android.util.SparseArray&lt;E&gt;)
		/// 	</see>
		/// to retrieve the
		/// state for this view and its children. May be overridden to modify how restoring
		/// happens to a view's children; for example, some views may want to not store state
		/// for their children.
		/// </summary>
		/// <param name="container">The SparseArray which holds previously saved state.</param>
		/// <seealso cref="dispatchSaveInstanceState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="restoreHierarchyState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="onRestoreInstanceState(android.os.Parcelable)"></seealso>
		protected internal virtual void dispatchRestoreInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			if (mID != NO_ID)
			{
				android.os.Parcelable state = container.get(mID);
				if (state != null)
				{
					// Log.i("View", "Restoreing #" + Integer.toHexString(mID)
					// + ": " + state);
					mPrivateFlags &= ~SAVE_STATE_CALLED;
					onRestoreInstanceState(state);
					if ((mPrivateFlags & SAVE_STATE_CALLED) == 0)
					{
						throw new System.InvalidOperationException("Derived class did not call super.onRestoreInstanceState()"
							);
					}
				}
			}
		}

		/// <summary>
		/// Hook allowing a view to re-apply a representation of its internal state that had previously
		/// been generated by
		/// <see cref="onSaveInstanceState()">onSaveInstanceState()</see>
		/// . This function will never be called with a
		/// null state.
		/// </summary>
		/// <param name="state">
		/// The frozen state that had previously been returned by
		/// <see cref="onSaveInstanceState()">onSaveInstanceState()</see>
		/// .
		/// </param>
		/// <seealso cref="onSaveInstanceState()"></seealso>
		/// <seealso cref="restoreHierarchyState(android.util.SparseArray{E})"></seealso>
		/// <seealso cref="dispatchRestoreInstanceState(android.util.SparseArray{E})"></seealso>
		protected internal virtual void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			mPrivateFlags |= SAVE_STATE_CALLED;
			if (state != android.view.AbsSavedState.EMPTY_STATE && state != null)
			{
				throw new System.ArgumentException("Wrong state class, expecting View State but "
					 + "received " + state.GetType().ToString() + " instead. This usually happens " 
					+ "when two views of different type have the same id in the same hierarchy. " + 
					"This view's id is " + android.view.ViewDebug.resolveId(mContext, getId()) + ". Make sure "
					 + "other views do not use the same id.");
			}
		}

		/// <summary><p>Return the time at which the drawing of the view hierarchy started.</p>
		/// 	</summary>
		/// <returns>the drawing start time in milliseconds</returns>
		public virtual long getDrawingTime()
		{
			return mAttachInfo != null ? mAttachInfo.mDrawingTime : 0;
		}

		/// <summary><p>Enables or disables the duplication of the parent's state into this view.
		/// 	</summary>
		/// <remarks>
		/// <p>Enables or disables the duplication of the parent's state into this view. When
		/// duplication is enabled, this view gets its drawable state from its parent rather
		/// than from its own internal properties.</p>
		/// <p>Note: in the current implementation, setting this property to true after the
		/// view was added to a ViewGroup might have no effect at all. This property should
		/// always be used from XML or set to true before adding this view to a ViewGroup.</p>
		/// <p>Note: if this view's parent addStateFromChildren property is enabled and this
		/// property is enabled, an exception will be thrown.</p>
		/// <p>Note: if the child view uses and updates additionnal states which are unknown to the
		/// parent, these states should not be affected by this method.</p>
		/// </remarks>
		/// <param name="enabled">
		/// True to enable duplication of the parent's drawable state, false
		/// to disable it.
		/// </param>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		/// <seealso cref="isDuplicateParentStateEnabled()">isDuplicateParentStateEnabled()</seealso>
		public virtual void setDuplicateParentStateEnabled(bool enabled)
		{
			setFlags(enabled ? DUPLICATE_PARENT_STATE : 0, DUPLICATE_PARENT_STATE);
		}

		/// <summary><p>Indicates whether this duplicates its drawable state from its parent.</p>
		/// 	</summary>
		/// <returns>
		/// True if this view's drawable state is duplicated from the parent,
		/// false otherwise
		/// </returns>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		/// <seealso cref="setDuplicateParentStateEnabled(bool)">setDuplicateParentStateEnabled(bool)
		/// 	</seealso>
		public virtual bool isDuplicateParentStateEnabled()
		{
			return (mViewFlags & DUPLICATE_PARENT_STATE) == DUPLICATE_PARENT_STATE;
		}

		/// <summary><p>Specifies the type of layer backing this view.</summary>
		/// <remarks>
		/// <p>Specifies the type of layer backing this view. The layer can be
		/// <see cref="LAYER_TYPE_NONE">disabled</see>
		/// ,
		/// <see cref="LAYER_TYPE_SOFTWARE">software</see>
		/// or
		/// <see cref="LAYER_TYPE_HARDWARE">hardware</see>
		/// .</p>
		/// <p>A layer is associated with an optional
		/// <see cref="android.graphics.Paint">android.graphics.Paint</see>
		/// instance that controls how the layer is composed on screen. The following
		/// properties of the paint are taken into account when composing the layer:</p>
		/// <ul>
		/// <li>
		/// <see cref="android.graphics.Paint.getAlpha()">Translucency (alpha)</see>
		/// </li>
		/// <li>
		/// <see cref="android.graphics.Paint.getXfermode()">Blending mode</see>
		/// </li>
		/// <li>
		/// <see cref="android.graphics.Paint.getColorFilter()">Color filter</see>
		/// </li>
		/// </ul>
		/// <p>If this view has an alpha value set to &lt; 1.0 by calling
		/// <see cref="setAlpha(float)">setAlpha(float)</see>
		/// , the alpha value of the layer's paint is replaced by
		/// this view's alpha value. Calling
		/// <see cref="setAlpha(float)">setAlpha(float)</see>
		/// is therefore
		/// equivalent to setting a hardware layer on this view and providing a paint with
		/// the desired alpha value.<p>
		/// <p>Refer to the documentation of
		/// <see cref="LAYER_TYPE_NONE">disabled</see>
		/// ,
		/// <see cref="LAYER_TYPE_SOFTWARE">software</see>
		/// and
		/// <see cref="LAYER_TYPE_HARDWARE">hardware</see>
		/// for more information on when and how to use layers.</p>
		/// </remarks>
		/// <param name="layerType">
		/// The ype of layer to use with this view, must be one of
		/// <see cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</see>
		/// ,
		/// <see cref="LAYER_TYPE_SOFTWARE">LAYER_TYPE_SOFTWARE</see>
		/// or
		/// <see cref="LAYER_TYPE_HARDWARE">LAYER_TYPE_HARDWARE</see>
		/// </param>
		/// <param name="paint">
		/// The paint used to compose the layer. This argument is optional
		/// and can be null. It is ignored when the layer type is
		/// <see cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</see>
		/// </param>
		/// <seealso cref="getLayerType()">getLayerType()</seealso>
		/// <seealso cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</seealso>
		/// <seealso cref="LAYER_TYPE_SOFTWARE">LAYER_TYPE_SOFTWARE</seealso>
		/// <seealso cref="LAYER_TYPE_HARDWARE">LAYER_TYPE_HARDWARE</seealso>
		/// <seealso cref="setAlpha(float)">setAlpha(float)</seealso>
		/// <attr>ref android.R.styleable#View_layerType</attr>
		public virtual void setLayerType(int layerType, android.graphics.Paint paint)
		{
			if (layerType < LAYER_TYPE_NONE || layerType > LAYER_TYPE_HARDWARE)
			{
				throw new System.ArgumentException("Layer type can only be one of: LAYER_TYPE_NONE, "
					 + "LAYER_TYPE_SOFTWARE or LAYER_TYPE_HARDWARE");
			}
			if (layerType == mLayerType)
			{
				if (layerType != LAYER_TYPE_NONE && paint != mLayerPaint)
				{
					mLayerPaint = paint == null ? new android.graphics.Paint() : paint;
					invalidateParentCaches();
					invalidate(true);
				}
				return;
			}
			switch (mLayerType)
			{
				case LAYER_TYPE_HARDWARE:
				{
					// Destroy any previous software drawing cache if needed
					destroyLayer();
					goto case LAYER_TYPE_SOFTWARE;
				}

				case LAYER_TYPE_SOFTWARE:
				{
					// fall through - unaccelerated views may use software layer mechanism instead
					destroyDrawingCache();
					break;
				}

				default:
				{
					break;
				}
			}
			mLayerType = layerType;
			bool layerDisabled = mLayerType == LAYER_TYPE_NONE;
			mLayerPaint = layerDisabled ? null : (paint == null ? new android.graphics.Paint(
				) : paint);
			mLocalDirtyRect = layerDisabled ? null : new android.graphics.Rect();
			invalidateParentCaches();
			invalidate(true);
		}

		/// <summary>Indicates whether this view has a static layer.</summary>
		/// <remarks>
		/// Indicates whether this view has a static layer. A view with layer type
		/// <see cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</see>
		/// is a static layer. Other types of layers are
		/// dynamic.
		/// </remarks>
		internal virtual bool hasStaticLayer()
		{
			return mLayerType == LAYER_TYPE_NONE;
		}

		/// <summary>Indicates what type of layer is currently associated with this view.</summary>
		/// <remarks>
		/// Indicates what type of layer is currently associated with this view. By default
		/// a view does not have a layer, and the layer type is
		/// <see cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</see>
		/// .
		/// Refer to the documentation of
		/// <see cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</see>
		/// for more information on the different types of layers.
		/// </remarks>
		/// <returns>
		/// 
		/// <see cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</see>
		/// ,
		/// <see cref="LAYER_TYPE_SOFTWARE">LAYER_TYPE_SOFTWARE</see>
		/// or
		/// <see cref="LAYER_TYPE_HARDWARE">LAYER_TYPE_HARDWARE</see>
		/// </returns>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</seealso>
		/// <seealso cref="buildLayer()"></seealso>
		/// <seealso cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</seealso>
		/// <seealso cref="LAYER_TYPE_SOFTWARE">LAYER_TYPE_SOFTWARE</seealso>
		/// <seealso cref="LAYER_TYPE_HARDWARE">LAYER_TYPE_HARDWARE</seealso>
		public virtual int getLayerType()
		{
			return mLayerType;
		}

		/// <summary>
		/// Forces this view's layer to be created and this view to be rendered
		/// into its layer.
		/// </summary>
		/// <remarks>
		/// Forces this view's layer to be created and this view to be rendered
		/// into its layer. If this view's layer type is set to
		/// <see cref="LAYER_TYPE_NONE">LAYER_TYPE_NONE</see>
		/// ,
		/// invoking this method will have no effect.
		/// This method can for instance be used to render a view into its layer before
		/// starting an animation. If this view is complex, rendering into the layer
		/// before starting the animation will avoid skipping frames.
		/// </remarks>
		/// <exception cref="System.InvalidOperationException">If this view is not attached to a window
		/// 	</exception>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)"></seealso>
		public virtual void buildLayer()
		{
			if (mLayerType == LAYER_TYPE_NONE)
			{
				return;
			}
			if (mAttachInfo == null)
			{
				throw new System.InvalidOperationException("This view must be attached to a window first"
					);
			}
			switch (mLayerType)
			{
				case LAYER_TYPE_HARDWARE:
				{
					getHardwareLayer();
					break;
				}

				case LAYER_TYPE_SOFTWARE:
				{
					buildDrawingCache(true);
					break;
				}
			}
		}

		/// <summary>
		/// <p>Returns a hardware layer that can be used to draw this view again
		/// without executing its draw method.</p>
		/// </summary>
		/// <returns>A HardwareLayer ready to render, or null if an error occurred.</returns>
		internal virtual android.view.HardwareLayer getHardwareLayer()
		{
			if (mAttachInfo == null || mAttachInfo.mHardwareRenderer == null || !mAttachInfo.
				mHardwareRenderer.isEnabled())
			{
				return null;
			}
			int width = mRight - mLeft;
			int height = mBottom - mTop;
			if (width == 0 || height == 0)
			{
				return null;
			}
			if ((mPrivateFlags & DRAWING_CACHE_VALID) == 0 || mHardwareLayer == null)
			{
				if (mHardwareLayer == null)
				{
					mHardwareLayer = mAttachInfo.mHardwareRenderer.createHardwareLayer(width, height, 
						isOpaque());
					mLocalDirtyRect.setEmpty();
				}
				else
				{
					if (mHardwareLayer.getWidth() != width || mHardwareLayer.getHeight() != height)
					{
						mHardwareLayer.resize(width, height);
						mLocalDirtyRect.setEmpty();
					}
				}
				android.view.HardwareCanvas currentCanvas = mAttachInfo.mHardwareCanvas;
				android.view.HardwareCanvas canvas = mHardwareLayer.start(currentCanvas);
				mAttachInfo.mHardwareCanvas = canvas;
				try
				{
					canvas.setViewport(width, height);
					canvas.onPreDraw(mLocalDirtyRect);
					mLocalDirtyRect.setEmpty();
					int restoreCount = canvas.save();
					computeScroll();
					canvas.translate(-mScrollX, -mScrollY);
					mPrivateFlags |= DRAWN | DRAWING_CACHE_VALID;
					// Fast path for layouts with no backgrounds
					if ((mPrivateFlags & SKIP_DRAW) == SKIP_DRAW)
					{
						mPrivateFlags &= ~DIRTY_MASK;
						dispatchDraw(canvas);
					}
					else
					{
						draw(canvas);
					}
					canvas.restoreToCount(restoreCount);
				}
				finally
				{
					canvas.onPostDraw();
					mHardwareLayer.end(currentCanvas);
					mAttachInfo.mHardwareCanvas = currentCanvas;
				}
			}
			return mHardwareLayer;
		}

		/// <summary>Destroys this View's hardware layer if possible.</summary>
		/// <remarks>Destroys this View's hardware layer if possible.</remarks>
		/// <returns>True if the layer was destroyed, false otherwise.</returns>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)"></seealso>
		/// <seealso cref="LAYER_TYPE_HARDWARE">LAYER_TYPE_HARDWARE</seealso>
		internal virtual bool destroyLayer()
		{
			if (mHardwareLayer != null)
			{
				mHardwareLayer.destroy();
				mHardwareLayer = null;
				return true;
			}
			return false;
		}

		/// <summary><p>Enables or disables the drawing cache.</summary>
		/// <remarks>
		/// <p>Enables or disables the drawing cache. When the drawing cache is enabled, the next call
		/// to
		/// <see cref="getDrawingCache()">getDrawingCache()</see>
		/// or
		/// <see cref="buildDrawingCache()">buildDrawingCache()</see>
		/// will draw the view in a
		/// bitmap. Calling
		/// <see cref="draw(android.graphics.Canvas)">draw(android.graphics.Canvas)</see>
		/// will not draw from the cache when
		/// the cache is enabled. To benefit from the cache, you must request the drawing cache by
		/// calling
		/// <see cref="getDrawingCache()">getDrawingCache()</see>
		/// and draw it on screen if the returned bitmap is not
		/// null.</p>
		/// <p>Enabling the drawing cache is similar to
		/// <see cref="setLayerType(int, android.graphics.Paint)">setting a layer</see>
		/// when hardware
		/// acceleration is turned off. When hardware acceleration is turned on, enabling the
		/// drawing cache has no effect on rendering because the system uses a different mechanism
		/// for acceleration which ignores the flag. If you want to use a Bitmap for the view, even
		/// when hardware acceleration is enabled, see
		/// <see cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</see>
		/// for information on how to enable software and hardware layers.</p>
		/// <p>This API can be used to manually generate
		/// a bitmap copy of this view, by setting the flag to <code>true</code> and calling
		/// <see cref="getDrawingCache()">getDrawingCache()</see>
		/// .</p>
		/// </remarks>
		/// <param name="enabled">true to enable the drawing cache, false otherwise</param>
		/// <seealso cref="isDrawingCacheEnabled()">isDrawingCacheEnabled()</seealso>
		/// <seealso cref="getDrawingCache()">getDrawingCache()</seealso>
		/// <seealso cref="buildDrawingCache()">buildDrawingCache()</seealso>
		/// <seealso cref="setLayerType(int, android.graphics.Paint)">setLayerType(int, android.graphics.Paint)
		/// 	</seealso>
		public virtual void setDrawingCacheEnabled(bool enabled)
		{
			mCachingFailed = false;
			setFlags(enabled ? DRAWING_CACHE_ENABLED : 0, DRAWING_CACHE_ENABLED);
		}

		/// <summary><p>Indicates whether the drawing cache is enabled for this view.</p></summary>
		/// <returns>true if the drawing cache is enabled</returns>
		/// <seealso cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(bool)</seealso>
		/// <seealso cref="getDrawingCache()">getDrawingCache()</seealso>
		public virtual bool isDrawingCacheEnabled()
		{
			return (mViewFlags & DRAWING_CACHE_ENABLED) == DRAWING_CACHE_ENABLED;
		}

		/// <summary>
		/// Debugging utility which recursively outputs the dirty state of a view and its
		/// descendants.
		/// </summary>
		/// <remarks>
		/// Debugging utility which recursively outputs the dirty state of a view and its
		/// descendants.
		/// </remarks>
		/// <hide></hide>
		public virtual void outputDirtyFlags(string indent, bool clear, int clearMask)
		{
			android.util.Log.d("View", indent + this + "             DIRTY(" + (mPrivateFlags
				 & android.view.View.DIRTY_MASK) + ") DRAWN(" + (mPrivateFlags & DRAWN) + ")" + 
				" CACHE_VALID(" + (mPrivateFlags & android.view.View.DRAWING_CACHE_VALID) + ") INVALIDATED("
				 + (mPrivateFlags & INVALIDATED) + ")");
			if (clear)
			{
				mPrivateFlags &= clearMask;
			}
			if (this is android.view.ViewGroup)
			{
				android.view.ViewGroup parent = (android.view.ViewGroup)this;
				int count = parent.getChildCount();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = parent.getChildAt(i);
						child.outputDirtyFlags(indent + "  ", clear, clearMask);
					}
				}
			}
		}

		/// <summary>
		/// This method is used by ViewGroup to cause its children to restore or recreate their
		/// display lists.
		/// </summary>
		/// <remarks>
		/// This method is used by ViewGroup to cause its children to restore or recreate their
		/// display lists. It is called by getDisplayList() when the parent ViewGroup does not need
		/// to recreate its own display list, which would happen if it went through the normal
		/// draw/dispatchDraw mechanisms.
		/// </remarks>
		/// <hide></hide>
		protected internal virtual void dispatchGetDisplayList()
		{
		}

		/// <summary>A view that is not attached or hardware accelerated cannot create a display list.
		/// 	</summary>
		/// <remarks>
		/// A view that is not attached or hardware accelerated cannot create a display list.
		/// This method checks these conditions and returns the appropriate result.
		/// </remarks>
		/// <returns>true if view has the ability to create a display list, false otherwise.</returns>
		/// <hide></hide>
		public virtual bool canHaveDisplayList()
		{
			return !(mAttachInfo == null || mAttachInfo.mHardwareRenderer == null);
		}

		/// <summary>
		/// <p>Returns a display list that can be used to draw this view again
		/// without executing its draw method.</p>
		/// </summary>
		/// <returns>A DisplayList ready to replay, or null if caching is not enabled.</returns>
		/// <hide></hide>
		public virtual android.view.DisplayList getDisplayList()
		{
			if (!canHaveDisplayList())
			{
				return null;
			}
			if (((mPrivateFlags & DRAWING_CACHE_VALID) == 0 || mDisplayList == null || !mDisplayList
				.isValid() || mRecreateDisplayList))
			{
				// Don't need to recreate the display list, just need to tell our
				// children to restore/recreate theirs
				if (mDisplayList != null && mDisplayList.isValid() && !mRecreateDisplayList)
				{
					mPrivateFlags |= DRAWN | DRAWING_CACHE_VALID;
					mPrivateFlags &= ~DIRTY_MASK;
					dispatchGetDisplayList();
					return mDisplayList;
				}
				// If we got here, we're recreating it. Mark it as such to ensure that
				// we copy in child display lists into ours in drawChild()
				mRecreateDisplayList = true;
				if (mDisplayList == null)
				{
					mDisplayList = mAttachInfo.mHardwareRenderer.createDisplayList();
					// If we're creating a new display list, make sure our parent gets invalidated
					// since they will need to recreate their display list to account for this
					// new child display list.
					invalidateParentCaches();
				}
				android.view.HardwareCanvas canvas = mDisplayList.start();
				int restoreCount = 0;
				try
				{
					int width = mRight - mLeft;
					int height = mBottom - mTop;
					canvas.setViewport(width, height);
					// The dirty rect should always be null for a display list
					canvas.onPreDraw(null);
					computeScroll();
					restoreCount = canvas.save();
					canvas.translate(-mScrollX, -mScrollY);
					mPrivateFlags |= DRAWN | DRAWING_CACHE_VALID;
					mPrivateFlags &= ~DIRTY_MASK;
					// Fast path for layouts with no backgrounds
					if ((mPrivateFlags & SKIP_DRAW) == SKIP_DRAW)
					{
						dispatchDraw(canvas);
					}
					else
					{
						draw(canvas);
					}
				}
				finally
				{
					canvas.restoreToCount(restoreCount);
					canvas.onPostDraw();
					mDisplayList.end();
				}
			}
			else
			{
				mPrivateFlags |= DRAWN | DRAWING_CACHE_VALID;
				mPrivateFlags &= ~DIRTY_MASK;
			}
			return mDisplayList;
		}

		/// <summary><p>Calling this method is equivalent to calling <code>getDrawingCache(false)</code>.</p>
		/// 	</summary>
		/// <returns>A non-scaled bitmap representing this view or null if cache is disabled.
		/// 	</returns>
		/// <seealso cref="getDrawingCache(bool)">getDrawingCache(bool)</seealso>
		public virtual android.graphics.Bitmap getDrawingCache()
		{
			return getDrawingCache(false);
		}

		/// <summary><p>Returns the bitmap in which this view drawing is cached.</summary>
		/// <remarks>
		/// <p>Returns the bitmap in which this view drawing is cached. The returned bitmap
		/// is null when caching is disabled. If caching is enabled and the cache is not ready,
		/// this method will create it. Calling
		/// <see cref="draw(android.graphics.Canvas)">draw(android.graphics.Canvas)</see>
		/// will not
		/// draw from the cache when the cache is enabled. To benefit from the cache, you must
		/// request the drawing cache by calling this method and draw it on screen if the
		/// returned bitmap is not null.</p>
		/// <p>Note about auto scaling in compatibility mode: When auto scaling is not enabled,
		/// this method will create a bitmap of the same size as this view. Because this bitmap
		/// will be drawn scaled by the parent ViewGroup, the result on screen might show
		/// scaling artifacts. To avoid such artifacts, you should call this method by setting
		/// the auto scaling to true. Doing so, however, will generate a bitmap of a different
		/// size than the view. This implies that your application must be able to handle this
		/// size.</p>
		/// </remarks>
		/// <param name="autoScale">
		/// Indicates whether the generated bitmap should be scaled based on
		/// the current density of the screen when the application is in compatibility
		/// mode.
		/// </param>
		/// <returns>A bitmap representing this view or null if cache is disabled.</returns>
		/// <seealso cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(bool)</seealso>
		/// <seealso cref="isDrawingCacheEnabled()">isDrawingCacheEnabled()</seealso>
		/// <seealso cref="buildDrawingCache(bool)">buildDrawingCache(bool)</seealso>
		/// <seealso cref="destroyDrawingCache()">destroyDrawingCache()</seealso>
		public virtual android.graphics.Bitmap getDrawingCache(bool autoScale)
		{
			if ((mViewFlags & WILL_NOT_CACHE_DRAWING) == WILL_NOT_CACHE_DRAWING)
			{
				return null;
			}
			if ((mViewFlags & DRAWING_CACHE_ENABLED) == DRAWING_CACHE_ENABLED)
			{
				buildDrawingCache(autoScale);
			}
			return autoScale ? mDrawingCache : mUnscaledDrawingCache;
		}

		/// <summary><p>Frees the resources used by the drawing cache.</summary>
		/// <remarks>
		/// <p>Frees the resources used by the drawing cache. If you call
		/// <see cref="buildDrawingCache()">buildDrawingCache()</see>
		/// manually without calling
		/// <see cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(true)</see>
		/// , you
		/// should cleanup the cache with this method afterwards.</p>
		/// </remarks>
		/// <seealso cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(bool)</seealso>
		/// <seealso cref="buildDrawingCache()">buildDrawingCache()</seealso>
		/// <seealso cref="getDrawingCache()">getDrawingCache()</seealso>
		public virtual void destroyDrawingCache()
		{
			if (mDrawingCache != null)
			{
				mDrawingCache.recycle();
				mDrawingCache = null;
			}
			if (mUnscaledDrawingCache != null)
			{
				mUnscaledDrawingCache.recycle();
				mUnscaledDrawingCache = null;
			}
		}

		/// <summary>
		/// Setting a solid background color for the drawing cache's bitmaps will improve
		/// performance and memory usage.
		/// </summary>
		/// <remarks>
		/// Setting a solid background color for the drawing cache's bitmaps will improve
		/// performance and memory usage. Note, though that this should only be used if this
		/// view will always be drawn on top of a solid color.
		/// </remarks>
		/// <param name="color">The background color to use for the drawing cache's bitmap</param>
		/// <seealso cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(bool)</seealso>
		/// <seealso cref="buildDrawingCache()">buildDrawingCache()</seealso>
		/// <seealso cref="getDrawingCache()">getDrawingCache()</seealso>
		public virtual void setDrawingCacheBackgroundColor(int color)
		{
			if (color != mDrawingCacheBackgroundColor)
			{
				mDrawingCacheBackgroundColor = color;
				mPrivateFlags &= ~DRAWING_CACHE_VALID;
			}
		}

		/// <seealso cref="setDrawingCacheBackgroundColor(int)">setDrawingCacheBackgroundColor(int)
		/// 	</seealso>
		/// <returns>The background color to used for the drawing cache's bitmap</returns>
		public virtual int getDrawingCacheBackgroundColor()
		{
			return mDrawingCacheBackgroundColor;
		}

		/// <summary><p>Calling this method is equivalent to calling <code>buildDrawingCache(false)</code>.</p>
		/// 	</summary>
		/// <seealso cref="buildDrawingCache(bool)">buildDrawingCache(bool)</seealso>
		public virtual void buildDrawingCache()
		{
			buildDrawingCache(false);
		}

		/// <summary>
		/// <p>Forces the drawing cache to be built if the drawing cache is invalid.</p>
		/// <p>If you call
		/// <see cref="buildDrawingCache()">buildDrawingCache()</see>
		/// manually without calling
		/// <see cref="setDrawingCacheEnabled(bool)">setDrawingCacheEnabled(true)</see>
		/// , you
		/// should cleanup the cache by calling
		/// <see cref="destroyDrawingCache()">destroyDrawingCache()</see>
		/// afterwards.</p>
		/// <p>Note about auto scaling in compatibility mode: When auto scaling is not enabled,
		/// this method will create a bitmap of the same size as this view. Because this bitmap
		/// will be drawn scaled by the parent ViewGroup, the result on screen might show
		/// scaling artifacts. To avoid such artifacts, you should call this method by setting
		/// the auto scaling to true. Doing so, however, will generate a bitmap of a different
		/// size than the view. This implies that your application must be able to handle this
		/// size.</p>
		/// <p>You should avoid calling this method when hardware acceleration is enabled. If
		/// you do not need the drawing cache bitmap, calling this method will increase memory
		/// usage and cause the view to be rendered in software once, thus negatively impacting
		/// performance.</p>
		/// </summary>
		/// <seealso cref="getDrawingCache()">getDrawingCache()</seealso>
		/// <seealso cref="destroyDrawingCache()">destroyDrawingCache()</seealso>
		public virtual void buildDrawingCache(bool autoScale)
		{
			if ((mPrivateFlags & DRAWING_CACHE_VALID) == 0 || (autoScale ? mDrawingCache == null
				 : mUnscaledDrawingCache == null))
			{
				mCachingFailed = false;
				int width = mRight - mLeft;
				int height = mBottom - mTop;
				android.view.View.AttachInfo attachInfo = mAttachInfo;
				bool scalingRequired = attachInfo != null && attachInfo.mScalingRequired;
				if (autoScale && scalingRequired)
				{
					width = (int)((width * attachInfo.mApplicationScale) + 0.5f);
					height = (int)((height * attachInfo.mApplicationScale) + 0.5f);
				}
				int drawingCacheBackgroundColor = mDrawingCacheBackgroundColor;
				bool opaque = drawingCacheBackgroundColor != 0 || isOpaque();
				bool use32BitCache = attachInfo != null && attachInfo.mUse32BitDrawingCache;
				if (width <= 0 || height <= 0 || (width * height * (opaque && !use32BitCache ? 2 : 
					4) > android.view.ViewConfiguration.get(mContext).getScaledMaximumDrawingCacheSize
					()))
				{
					// Projected bitmap size in bytes
					destroyDrawingCache();
					mCachingFailed = true;
					return;
				}
				bool clear = true;
				android.graphics.Bitmap bitmap = autoScale ? mDrawingCache : mUnscaledDrawingCache;
				if (bitmap == null || bitmap.getWidth() != width || bitmap.getHeight() != height)
				{
					android.graphics.Bitmap.Config quality;
					if (!opaque)
					{
						switch (mViewFlags & DRAWING_CACHE_QUALITY_MASK)
						{
							case DRAWING_CACHE_QUALITY_AUTO:
							{
								// Never pick ARGB_4444 because it looks awful
								// Keep the DRAWING_CACHE_QUALITY_LOW flag just in case
								quality = android.graphics.Bitmap.Config.ARGB_8888;
								break;
							}

							case DRAWING_CACHE_QUALITY_LOW:
							{
								quality = android.graphics.Bitmap.Config.ARGB_8888;
								break;
							}

							case DRAWING_CACHE_QUALITY_HIGH:
							{
								quality = android.graphics.Bitmap.Config.ARGB_8888;
								break;
							}

							default:
							{
								quality = android.graphics.Bitmap.Config.ARGB_8888;
								break;
							}
						}
					}
					else
					{
						// Optimization for translucent windows
						// If the window is translucent, use a 32 bits bitmap to benefit from memcpy()
						quality = use32BitCache ? android.graphics.Bitmap.Config.ARGB_8888 : android.graphics.Bitmap.Config
							.RGB_565;
					}
					// Try to cleanup memory
					if (bitmap != null)
					{
						bitmap.recycle();
					}
					try
					{
						bitmap = android.graphics.Bitmap.createBitmap(width, height, quality);
						bitmap.setDensity(getResources().getDisplayMetrics().densityDpi);
						if (autoScale)
						{
							mDrawingCache = bitmap;
						}
						else
						{
							mUnscaledDrawingCache = bitmap;
						}
						if (opaque && use32BitCache)
						{
							bitmap.setHasAlpha(false);
						}
					}
					catch (System.OutOfMemoryException)
					{
						// If there is not enough memory to create the bitmap cache, just
						// ignore the issue as bitmap caches are not required to draw the
						// view hierarchy
						if (autoScale)
						{
							mDrawingCache = null;
						}
						else
						{
							mUnscaledDrawingCache = null;
						}
						mCachingFailed = true;
						return;
					}
					clear = drawingCacheBackgroundColor != 0;
				}
				android.graphics.Canvas canvas;
				if (attachInfo != null)
				{
					canvas = attachInfo.mCanvas;
					if (canvas == null)
					{
						canvas = new android.graphics.Canvas();
					}
					canvas.setBitmap(bitmap);
					// Temporarily clobber the cached Canvas in case one of our children
					// is also using a drawing cache. Without this, the children would
					// steal the canvas by attaching their own bitmap to it and bad, bad
					// thing would happen (invisible views, corrupted drawings, etc.)
					attachInfo.mCanvas = null;
				}
				else
				{
					// This case should hopefully never or seldom happen
					canvas = new android.graphics.Canvas(bitmap);
				}
				if (clear)
				{
					bitmap.eraseColor(drawingCacheBackgroundColor);
				}
				computeScroll();
				int restoreCount = canvas.save();
				if (autoScale && scalingRequired)
				{
					float scale = attachInfo.mApplicationScale;
					canvas.scale(scale, scale);
				}
				canvas.translate(-mScrollX, -mScrollY);
				mPrivateFlags |= DRAWN;
				if (mAttachInfo == null || !mAttachInfo.mHardwareAccelerated || mLayerType != LAYER_TYPE_NONE)
				{
					mPrivateFlags |= DRAWING_CACHE_VALID;
				}
				// Fast path for layouts with no backgrounds
				if ((mPrivateFlags & SKIP_DRAW) == SKIP_DRAW)
				{
					mPrivateFlags &= ~DIRTY_MASK;
					dispatchDraw(canvas);
				}
				else
				{
					draw(canvas);
				}
				canvas.restoreToCount(restoreCount);
				canvas.setBitmap(null);
				if (attachInfo != null)
				{
					// Restore the cached Canvas for our siblings
					attachInfo.mCanvas = canvas;
				}
			}
		}

		/// <summary>Create a snapshot of the view into a bitmap.</summary>
		/// <remarks>
		/// Create a snapshot of the view into a bitmap.  We should probably make
		/// some form of this public, but should think about the API.
		/// </remarks>
		internal virtual android.graphics.Bitmap createSnapshot(android.graphics.Bitmap.Config
			 quality, int backgroundColor, bool skipChildren)
		{
			int width = mRight - mLeft;
			int height = mBottom - mTop;
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			float scale = attachInfo != null ? attachInfo.mApplicationScale : 1.0f;
			width = (int)((width * scale) + 0.5f);
			height = (int)((height * scale) + 0.5f);
			android.graphics.Bitmap bitmap = android.graphics.Bitmap.createBitmap(width > 0 ? 
				width : 1, height > 0 ? height : 1, quality);
			if (bitmap == null)
			{
				throw new System.OutOfMemoryException();
			}
			android.content.res.Resources resources = getResources();
			if (resources != null)
			{
				bitmap.setDensity(resources.getDisplayMetrics().densityDpi);
			}
			android.graphics.Canvas canvas;
			if (attachInfo != null)
			{
				canvas = attachInfo.mCanvas;
				if (canvas == null)
				{
					canvas = new android.graphics.Canvas();
				}
				canvas.setBitmap(bitmap);
				// Temporarily clobber the cached Canvas in case one of our children
				// is also using a drawing cache. Without this, the children would
				// steal the canvas by attaching their own bitmap to it and bad, bad
				// things would happen (invisible views, corrupted drawings, etc.)
				attachInfo.mCanvas = null;
			}
			else
			{
				// This case should hopefully never or seldom happen
				canvas = new android.graphics.Canvas(bitmap);
			}
			if ((backgroundColor & unchecked((int)(0xff000000))) != 0)
			{
				bitmap.eraseColor(backgroundColor);
			}
			computeScroll();
			int restoreCount = canvas.save();
			canvas.scale(scale, scale);
			canvas.translate(-mScrollX, -mScrollY);
			// Temporarily remove the dirty mask
			int flags = mPrivateFlags;
			mPrivateFlags &= ~DIRTY_MASK;
			// Fast path for layouts with no backgrounds
			if ((mPrivateFlags & SKIP_DRAW) == SKIP_DRAW)
			{
				dispatchDraw(canvas);
			}
			else
			{
				draw(canvas);
			}
			mPrivateFlags = flags;
			canvas.restoreToCount(restoreCount);
			canvas.setBitmap(null);
			if (attachInfo != null)
			{
				// Restore the cached Canvas for our siblings
				attachInfo.mCanvas = canvas;
			}
			return bitmap;
		}

		/// <summary>Indicates whether this View is currently in edit mode.</summary>
		/// <remarks>
		/// Indicates whether this View is currently in edit mode. A View is usually
		/// in edit mode when displayed within a developer tool. For instance, if
		/// this View is being drawn by a visual user interface builder, this method
		/// should return true.
		/// Subclasses should check the return value of this method to provide
		/// different behaviors if their normal behavior might interfere with the
		/// host environment. For instance: the class spawns a thread in its
		/// constructor, the drawing code relies on device-specific features, etc.
		/// This method is usually checked in the drawing code of custom widgets.
		/// </remarks>
		/// <returns>True if this View is in edit mode, false otherwise.</returns>
		public virtual bool isInEditMode()
		{
			return false;
		}

		/// <summary>
		/// If the View draws content inside its padding and enables fading edges,
		/// it needs to support padding offsets.
		/// </summary>
		/// <remarks>
		/// If the View draws content inside its padding and enables fading edges,
		/// it needs to support padding offsets. Padding offsets are added to the
		/// fading edges to extend the length of the fade so that it covers pixels
		/// drawn inside the padding.
		/// Subclasses of this class should override this method if they need
		/// to draw content inside the padding.
		/// </remarks>
		/// <returns>True if padding offset must be applied, false otherwise.</returns>
		/// <seealso cref="getLeftPaddingOffset()">getLeftPaddingOffset()</seealso>
		/// <seealso cref="getRightPaddingOffset()">getRightPaddingOffset()</seealso>
		/// <seealso cref="getTopPaddingOffset()">getTopPaddingOffset()</seealso>
		/// <seealso cref="getBottomPaddingOffset()">getBottomPaddingOffset()</seealso>
		/// <since>CURRENT</since>
		protected internal virtual bool isPaddingOffsetRequired()
		{
			return false;
		}

		/// <summary>Amount by which to extend the left fading region.</summary>
		/// <remarks>
		/// Amount by which to extend the left fading region. Called only when
		/// <see cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</see>
		/// returns true.
		/// </remarks>
		/// <returns>The left padding offset in pixels.</returns>
		/// <seealso cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</seealso>
		/// <since>CURRENT</since>
		protected internal virtual int getLeftPaddingOffset()
		{
			return 0;
		}

		/// <summary>Amount by which to extend the right fading region.</summary>
		/// <remarks>
		/// Amount by which to extend the right fading region. Called only when
		/// <see cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</see>
		/// returns true.
		/// </remarks>
		/// <returns>The right padding offset in pixels.</returns>
		/// <seealso cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</seealso>
		/// <since>CURRENT</since>
		protected internal virtual int getRightPaddingOffset()
		{
			return 0;
		}

		/// <summary>Amount by which to extend the top fading region.</summary>
		/// <remarks>
		/// Amount by which to extend the top fading region. Called only when
		/// <see cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</see>
		/// returns true.
		/// </remarks>
		/// <returns>The top padding offset in pixels.</returns>
		/// <seealso cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</seealso>
		/// <since>CURRENT</since>
		protected internal virtual int getTopPaddingOffset()
		{
			return 0;
		}

		/// <summary>Amount by which to extend the bottom fading region.</summary>
		/// <remarks>
		/// Amount by which to extend the bottom fading region. Called only when
		/// <see cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</see>
		/// returns true.
		/// </remarks>
		/// <returns>The bottom padding offset in pixels.</returns>
		/// <seealso cref="isPaddingOffsetRequired()">isPaddingOffsetRequired()</seealso>
		/// <since>CURRENT</since>
		protected internal virtual int getBottomPaddingOffset()
		{
			return 0;
		}

		/// <hide></hide>
		/// <param name="offsetRequired"></param>
		protected internal virtual int getFadeTop(bool offsetRequired)
		{
			int top = mPaddingTop;
			if (offsetRequired)
			{
				top += getTopPaddingOffset();
			}
			return top;
		}

		/// <hide></hide>
		/// <param name="offsetRequired"></param>
		protected internal virtual int getFadeHeight(bool offsetRequired)
		{
			int padding = mPaddingTop;
			if (offsetRequired)
			{
				padding += getTopPaddingOffset();
			}
			return mBottom - mTop - mPaddingBottom - padding;
		}

		/// <summary>
		/// <p>Indicates whether this view is attached to an hardware accelerated
		/// window or not.</p>
		/// <p>Even if this method returns true, it does not mean that every call
		/// to
		/// <see cref="draw(android.graphics.Canvas)">draw(android.graphics.Canvas)</see>
		/// will be made with an hardware
		/// accelerated
		/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
		/// . For instance, if this view
		/// is drawn onto an offscren
		/// <see cref="android.graphics.Bitmap">android.graphics.Bitmap</see>
		/// and its
		/// window is hardware accelerated,
		/// <see cref="android.graphics.Canvas.isHardwareAccelerated()">android.graphics.Canvas.isHardwareAccelerated()
		/// 	</see>
		/// will likely
		/// return false, and this method will return true.</p>
		/// </summary>
		/// <returns>
		/// True if the view is attached to a window and the window is
		/// hardware accelerated; false in any other case.
		/// </returns>
		public virtual bool isHardwareAccelerated()
		{
			return mAttachInfo != null && mAttachInfo.mHardwareAccelerated;
		}

		/// <summary>Manually render this view (and all of its children) to the given Canvas.
		/// 	</summary>
		/// <remarks>
		/// Manually render this view (and all of its children) to the given Canvas.
		/// The view must have already done a full layout before this function is
		/// called.  When implementing a view, implement
		/// <see cref="onDraw(android.graphics.Canvas)">onDraw(android.graphics.Canvas)</see>
		/// instead of overriding this method.
		/// If you do need to override this method, call the superclass version.
		/// </remarks>
		/// <param name="canvas">The Canvas to which the View is rendered.</param>
		public virtual void draw(android.graphics.Canvas canvas)
		{
			int privateFlags = mPrivateFlags;
			bool dirtyOpaque = (privateFlags & DIRTY_MASK) == DIRTY_OPAQUE && (mAttachInfo ==
				 null || !mAttachInfo.mIgnoreDirtyState);
			mPrivateFlags = (privateFlags & ~DIRTY_MASK) | DRAWN;
			// Step 1, draw the background, if needed
			int saveCount;
			if (!dirtyOpaque)
			{
				android.graphics.drawable.Drawable background = mBGDrawable;
				if (background != null)
				{
					int scrollX = mScrollX;
					int scrollY = mScrollY;
					if (mBackgroundSizeChanged)
					{
						background.setBounds(0, 0, mRight - mLeft, mBottom - mTop);
						mBackgroundSizeChanged = false;
					}
					if ((scrollX | scrollY) == 0)
					{
						background.draw(canvas);
					}
					else
					{
						canvas.translate(scrollX, scrollY);
						background.draw(canvas);
						canvas.translate(-scrollX, -scrollY);
					}
				}
			}
			// skip step 2 & 5 if possible (common case)
			int viewFlags = mViewFlags;
			bool horizontalEdges = (viewFlags & FADING_EDGE_HORIZONTAL) != 0;
			bool verticalEdges = (viewFlags & FADING_EDGE_VERTICAL) != 0;
			if (!verticalEdges && !horizontalEdges)
			{
				// Step 3, draw the content
				if (!dirtyOpaque)
				{
					onDraw(canvas);
				}
				// Step 4, draw the children
				dispatchDraw(canvas);
				// Step 6, draw decorations (scrollbars)
				onDrawScrollBars(canvas);
				// we're done...
				return;
			}
			bool drawTop = false;
			bool drawBottom = false;
			bool drawLeft = false;
			bool drawRight = false;
			float topFadeStrength = 0.0f;
			float bottomFadeStrength = 0.0f;
			float leftFadeStrength = 0.0f;
			float rightFadeStrength = 0.0f;
			// Step 2, save the canvas' layers
			int paddingLeft = mPaddingLeft;
			bool offsetRequired = isPaddingOffsetRequired();
			if (offsetRequired)
			{
				paddingLeft += getLeftPaddingOffset();
			}
			int left = mScrollX + paddingLeft;
			int right = left + mRight - mLeft - mPaddingRight - paddingLeft;
			int top = mScrollY + getFadeTop(offsetRequired);
			int bottom = top + getFadeHeight(offsetRequired);
			if (offsetRequired)
			{
				right += getRightPaddingOffset();
				bottom += getBottomPaddingOffset();
			}
			android.view.View.ScrollabilityCache scrollabilityCache = mScrollCache;
			float fadeHeight = scrollabilityCache.fadingEdgeLength;
			int length = (int)fadeHeight;
			// clip the fade length if top and bottom fades overlap
			// overlapping fades produce odd-looking artifacts
			if (verticalEdges && (top + length > bottom - length))
			{
				length = (bottom - top) / 2;
			}
			// also clip horizontal fades if necessary
			if (horizontalEdges && (left + length > right - length))
			{
				length = (right - left) / 2;
			}
			if (verticalEdges)
			{
				topFadeStrength = System.Math.Max(0.0f, System.Math.Min(1.0f, getTopFadingEdgeStrength
					()));
				drawTop = topFadeStrength * fadeHeight > 1.0f;
				bottomFadeStrength = System.Math.Max(0.0f, System.Math.Min(1.0f, getBottomFadingEdgeStrength
					()));
				drawBottom = bottomFadeStrength * fadeHeight > 1.0f;
			}
			if (horizontalEdges)
			{
				leftFadeStrength = System.Math.Max(0.0f, System.Math.Min(1.0f, getLeftFadingEdgeStrength
					()));
				drawLeft = leftFadeStrength * fadeHeight > 1.0f;
				rightFadeStrength = System.Math.Max(0.0f, System.Math.Min(1.0f, getRightFadingEdgeStrength
					()));
				drawRight = rightFadeStrength * fadeHeight > 1.0f;
			}
			saveCount = canvas.getSaveCount();
			int solidColor = getSolidColor();
			if (solidColor == 0)
			{
				int flags = android.graphics.Canvas.HAS_ALPHA_LAYER_SAVE_FLAG;
				if (drawTop)
				{
					canvas.saveLayer(left, top, right, top + length, null, flags);
				}
				if (drawBottom)
				{
					canvas.saveLayer(left, bottom - length, right, bottom, null, flags);
				}
				if (drawLeft)
				{
					canvas.saveLayer(left, top, left + length, bottom, null, flags);
				}
				if (drawRight)
				{
					canvas.saveLayer(right - length, top, right, bottom, null, flags);
				}
			}
			else
			{
				scrollabilityCache.setFadeColor(solidColor);
			}
			// Step 3, draw the content
			if (!dirtyOpaque)
			{
				onDraw(canvas);
			}
			// Step 4, draw the children
			dispatchDraw(canvas);
			// Step 5, draw the fade effect and restore layers
			android.graphics.Paint p = scrollabilityCache.paint;
			android.graphics.Matrix matrix = scrollabilityCache.matrix;
			android.graphics.Shader fade = scrollabilityCache.shader;
			if (drawTop)
			{
				matrix.setScale(1, fadeHeight * topFadeStrength);
				matrix.postTranslate(left, top);
				fade.setLocalMatrix(matrix);
				canvas.drawRect(left, top, right, top + length, p);
			}
			if (drawBottom)
			{
				matrix.setScale(1, fadeHeight * bottomFadeStrength);
				matrix.postRotate(180);
				matrix.postTranslate(left, bottom);
				fade.setLocalMatrix(matrix);
				canvas.drawRect(left, bottom - length, right, bottom, p);
			}
			if (drawLeft)
			{
				matrix.setScale(1, fadeHeight * leftFadeStrength);
				matrix.postRotate(-90);
				matrix.postTranslate(left, top);
				fade.setLocalMatrix(matrix);
				canvas.drawRect(left, top, left + length, bottom, p);
			}
			if (drawRight)
			{
				matrix.setScale(1, fadeHeight * rightFadeStrength);
				matrix.postRotate(90);
				matrix.postTranslate(right, top);
				fade.setLocalMatrix(matrix);
				canvas.drawRect(right - length, top, right, bottom, p);
			}
			canvas.restoreToCount(saveCount);
			// Step 6, draw decorations (scrollbars)
			onDrawScrollBars(canvas);
		}

		/// <summary>
		/// Override this if your view is known to always be drawn on top of a solid color background,
		/// and needs to draw fading edges.
		/// </summary>
		/// <remarks>
		/// Override this if your view is known to always be drawn on top of a solid color background,
		/// and needs to draw fading edges. Returning a non-zero color enables the view system to
		/// optimize the drawing of the fading edges. If you do return a non-zero color, the alpha
		/// should be set to 0xFF.
		/// </remarks>
		/// <seealso cref="setVerticalFadingEdgeEnabled(bool)"></seealso>
		/// <seealso cref="setHorizontalFadingEdgeEnabled(bool)"></seealso>
		/// <returns>The known solid color background for this view, or 0 if the color may vary
		/// 	</returns>
		public virtual int getSolidColor()
		{
			return 0;
		}

		/// <summary>Build a human readable string representation of the specified view flags.
		/// 	</summary>
		/// <remarks>Build a human readable string representation of the specified view flags.
		/// 	</remarks>
		/// <param name="flags">the view flags to convert to a string</param>
		/// <returns>a String representing the supplied flags</returns>
		private static string printFlags(int flags)
		{
			string output = string.Empty;
			int numFlags = 0;
			if ((flags & FOCUSABLE_MASK) == FOCUSABLE)
			{
				output += "TAKES_FOCUS";
				numFlags++;
			}
			switch (flags & VISIBILITY_MASK)
			{
				case INVISIBLE:
				{
					if (numFlags > 0)
					{
						output += " ";
					}
					output += "INVISIBLE";
					// USELESS HERE numFlags++;
					break;
				}

				case GONE:
				{
					if (numFlags > 0)
					{
						output += " ";
					}
					output += "GONE";
					// USELESS HERE numFlags++;
					break;
				}

				default:
				{
					break;
				}
			}
			return output;
		}

		/// <summary>
		/// Build a human readable string representation of the specified private
		/// view flags.
		/// </summary>
		/// <remarks>
		/// Build a human readable string representation of the specified private
		/// view flags.
		/// </remarks>
		/// <param name="privateFlags">the private view flags to convert to a string</param>
		/// <returns>a String representing the supplied flags</returns>
		private static string printPrivateFlags(int privateFlags)
		{
			string output = string.Empty;
			int numFlags = 0;
			if ((privateFlags & WANTS_FOCUS) == WANTS_FOCUS)
			{
				output += "WANTS_FOCUS";
				numFlags++;
			}
			if ((privateFlags & FOCUSED) == FOCUSED)
			{
				if (numFlags > 0)
				{
					output += " ";
				}
				output += "FOCUSED";
				numFlags++;
			}
			if ((privateFlags & SELECTED) == SELECTED)
			{
				if (numFlags > 0)
				{
					output += " ";
				}
				output += "SELECTED";
				numFlags++;
			}
			if ((privateFlags & IS_ROOT_NAMESPACE) == IS_ROOT_NAMESPACE)
			{
				if (numFlags > 0)
				{
					output += " ";
				}
				output += "IS_ROOT_NAMESPACE";
				numFlags++;
			}
			if ((privateFlags & HAS_BOUNDS) == HAS_BOUNDS)
			{
				if (numFlags > 0)
				{
					output += " ";
				}
				output += "HAS_BOUNDS";
				numFlags++;
			}
			if ((privateFlags & DRAWN) == DRAWN)
			{
				if (numFlags > 0)
				{
					output += " ";
				}
				output += "DRAWN";
			}
			// USELESS HERE numFlags++;
			return output;
		}

		/// <summary>
		/// <p>Indicates whether or not this view's layout will be requested during
		/// the next hierarchy layout pass.</p>
		/// </summary>
		/// <returns>true if the layout will be forced during next layout pass</returns>
		public virtual bool isLayoutRequested()
		{
			return (mPrivateFlags & FORCE_LAYOUT) == FORCE_LAYOUT;
		}

		/// <summary>
		/// Assign a size and position to a view and all of its
		/// descendants
		/// <p>This is the second phase of the layout mechanism.
		/// </summary>
		/// <remarks>
		/// Assign a size and position to a view and all of its
		/// descendants
		/// <p>This is the second phase of the layout mechanism.
		/// (The first is measuring). In this phase, each parent calls
		/// layout on all of its children to position them.
		/// This is typically done using the child measurements
		/// that were stored in the measure pass().</p>
		/// <p>Derived classes should not override this method.
		/// Derived classes with children should override
		/// onLayout. In that method, they should
		/// call layout on each of their children.</p>
		/// </remarks>
		/// <param name="l">Left position, relative to parent</param>
		/// <param name="t">Top position, relative to parent</param>
		/// <param name="r">Right position, relative to parent</param>
		/// <param name="b">Bottom position, relative to parent</param>
		public virtual void layout(int l, int t, int r, int b)
		{
			int oldL = mLeft;
			int oldT = mTop;
			int oldB = mBottom;
			int oldR = mRight;
			bool changed = setFrame(l, t, r, b);
			if (changed || (mPrivateFlags & LAYOUT_REQUIRED) == LAYOUT_REQUIRED)
			{
				onLayout(changed, l, t, r, b);
				mPrivateFlags &= ~LAYOUT_REQUIRED;
				if (mOnLayoutChangeListeners != null)
				{
					java.util.ArrayList<android.view.View.OnLayoutChangeListener> listenersCopy = (java.util.ArrayList
						<android.view.View.OnLayoutChangeListener>)mOnLayoutChangeListeners.clone();
					int numListeners = listenersCopy.size();
					{
						for (int i = 0; i < numListeners; ++i)
						{
							listenersCopy.get(i).onLayoutChange(this, l, t, r, b, oldL, oldT, oldR, oldB);
						}
					}
				}
			}
			mPrivateFlags &= ~FORCE_LAYOUT;
		}

		/// <summary>
		/// Called from layout when this view should
		/// assign a size and position to each of its children.
		/// </summary>
		/// <remarks>
		/// Called from layout when this view should
		/// assign a size and position to each of its children.
		/// Derived classes with children should override
		/// this method and call layout on each of
		/// their children.
		/// </remarks>
		/// <param name="changed">This is a new size or position for this view</param>
		/// <param name="left">Left position, relative to parent</param>
		/// <param name="top">Top position, relative to parent</param>
		/// <param name="right">Right position, relative to parent</param>
		/// <param name="bottom">Bottom position, relative to parent</param>
		protected internal virtual void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
		}

		/// <summary>Assign a size and position to this view.</summary>
		/// <remarks>
		/// Assign a size and position to this view.
		/// This is called from layout.
		/// </remarks>
		/// <param name="left">Left position, relative to parent</param>
		/// <param name="top">Top position, relative to parent</param>
		/// <param name="right">Right position, relative to parent</param>
		/// <param name="bottom">Bottom position, relative to parent</param>
		/// <returns>
		/// true if the new size and position are different than the
		/// previous ones
		/// <hide></hide>
		/// </returns>
		protected internal virtual bool setFrame(int left, int top, int right, int bottom
			)
		{
			bool changed = false;
			if (mLeft != left || mRight != right || mTop != top || mBottom != bottom)
			{
				changed = true;
				// Remember our drawn bit
				int drawn = mPrivateFlags & DRAWN;
				int oldWidth = mRight - mLeft;
				int oldHeight = mBottom - mTop;
				int newWidth = right - left;
				int newHeight = bottom - top;
				bool sizeChanged = (newWidth != oldWidth) || (newHeight != oldHeight);
				// Invalidate our old position
				invalidate(sizeChanged);
				mLeft = left;
				mTop = top;
				mRight = right;
				mBottom = bottom;
				mPrivateFlags |= HAS_BOUNDS;
				if (sizeChanged)
				{
					if ((mPrivateFlags & PIVOT_EXPLICITLY_SET) == 0)
					{
						// A change in dimension means an auto-centered pivot point changes, too
						if (mTransformationInfo != null)
						{
							mTransformationInfo.mMatrixDirty = true;
						}
					}
					onSizeChanged(newWidth, newHeight, oldWidth, oldHeight);
				}
				if ((mViewFlags & VISIBILITY_MASK) == VISIBLE)
				{
					// If we are visible, force the DRAWN bit to on so that
					// this invalidate will go through (at least to our parent).
					// This is because someone may have invalidated this view
					// before this call to setFrame came in, thereby clearing
					// the DRAWN bit.
					mPrivateFlags |= DRAWN;
					invalidate(sizeChanged);
					// parent display list may need to be recreated based on a change in the bounds
					// of any child
					invalidateParentCaches();
				}
				// Reset drawn bit to original value (invalidate turns it off)
				mPrivateFlags |= drawn;
				mBackgroundSizeChanged = true;
			}
			return changed;
		}

		/// <summary>Finalize inflating a view from XML.</summary>
		/// <remarks>
		/// Finalize inflating a view from XML.  This is called as the last phase
		/// of inflation, after all child views have been added.
		/// <p>Even if the subclass overrides onFinishInflate, they should always be
		/// sure to call the super method, so that we get called.
		/// </remarks>
		protected internal virtual void onFinishInflate()
		{
		}

		/// <summary>Returns the resources associated with this view.</summary>
		/// <remarks>Returns the resources associated with this view.</remarks>
		/// <returns>Resources object.</returns>
		public virtual android.content.res.Resources getResources()
		{
			return mResources;
		}

		/// <summary>Invalidates the specified Drawable.</summary>
		/// <remarks>Invalidates the specified Drawable.</remarks>
		/// <param name="drawable">the drawable to invalidate</param>
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void invalidateDrawable(android.graphics.drawable.Drawable drawable
			)
		{
			if (verifyDrawable(drawable))
			{
				android.graphics.Rect dirty = drawable.getBounds();
				int scrollX = mScrollX;
				int scrollY = mScrollY;
				invalidate(dirty.left + scrollX, dirty.top + scrollY, dirty.right + scrollX, dirty
					.bottom + scrollY);
			}
		}

		/// <summary>Schedules an action on a drawable to occur at a specified time.</summary>
		/// <remarks>Schedules an action on a drawable to occur at a specified time.</remarks>
		/// <param name="who">the recipient of the action</param>
		/// <param name="what">the action to run on the drawable</param>
		/// <param name="when">
		/// the time at which the action must occur. Uses the
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// timebase.
		/// </param>
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void scheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what, long when)
		{
			if (verifyDrawable(who) && what != null && mAttachInfo != null)
			{
				mAttachInfo.mHandler.postAtTime(what, who, when);
			}
		}

		/// <summary>Cancels a scheduled action on a drawable.</summary>
		/// <remarks>Cancels a scheduled action on a drawable.</remarks>
		/// <param name="who">the recipient of the action</param>
		/// <param name="what">the action to cancel</param>
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void unscheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what)
		{
			if (verifyDrawable(who) && what != null && mAttachInfo != null)
			{
				mAttachInfo.mHandler.removeCallbacks(what, who);
			}
		}

		/// <summary>Unschedule any events associated with the given Drawable.</summary>
		/// <remarks>
		/// Unschedule any events associated with the given Drawable.  This can be
		/// used when selecting a new Drawable into a view, so that the previous
		/// one is completely unscheduled.
		/// </remarks>
		/// <param name="who">The Drawable to unschedule.</param>
		/// <seealso cref="drawableStateChanged()">drawableStateChanged()</seealso>
		public virtual void unscheduleDrawable(android.graphics.drawable.Drawable who)
		{
			if (mAttachInfo != null)
			{
				mAttachInfo.mHandler.removeCallbacksAndMessages(who);
			}
		}

		/// <summary>Return the layout direction of a given Drawable.</summary>
		/// <remarks>Return the layout direction of a given Drawable.</remarks>
		/// <param name="who">the Drawable to query</param>
		/// <hide></hide>
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback2")]
		public virtual int getResolvedLayoutDirection(android.graphics.drawable.Drawable 
			who)
		{
			return (who == mBGDrawable) ? getResolvedLayoutDirection() : LAYOUT_DIRECTION_DEFAULT;
		}

		/// <summary>
		/// If your view subclass is displaying its own Drawable objects, it should
		/// override this function and return true for any Drawable it is
		/// displaying.
		/// </summary>
		/// <remarks>
		/// If your view subclass is displaying its own Drawable objects, it should
		/// override this function and return true for any Drawable it is
		/// displaying.  This allows animations for those drawables to be
		/// scheduled.
		/// <p>Be sure to call through to the super class when overriding this
		/// function.
		/// </remarks>
		/// <param name="who">
		/// The Drawable to verify.  Return true if it is one you are
		/// displaying, else return the result of calling through to the
		/// super class.
		/// </param>
		/// <returns>
		/// boolean If true than the Drawable is being displayed in the
		/// view; else false and it is not allowed to animate.
		/// </returns>
		/// <seealso cref="unscheduleDrawable(android.graphics.drawable.Drawable)"></seealso>
		/// <seealso cref="drawableStateChanged()"></seealso>
		protected internal virtual bool verifyDrawable(android.graphics.drawable.Drawable
			 who)
		{
			return who == mBGDrawable;
		}

		/// <summary>
		/// This function is called whenever the state of the view changes in such
		/// a way that it impacts the state of drawables being shown.
		/// </summary>
		/// <remarks>
		/// This function is called whenever the state of the view changes in such
		/// a way that it impacts the state of drawables being shown.
		/// <p>Be sure to call through to the superclass when overriding this
		/// function.
		/// </remarks>
		/// <seealso cref="android.graphics.drawable.Drawable.setState(int[])"></seealso>
		protected internal virtual void drawableStateChanged()
		{
			android.graphics.drawable.Drawable d = mBGDrawable;
			if (d != null && d.isStateful())
			{
				d.setState(getDrawableState());
			}
		}

		/// <summary>Call this to force a view to update its drawable state.</summary>
		/// <remarks>
		/// Call this to force a view to update its drawable state. This will cause
		/// drawableStateChanged to be called on this view. Views that are interested
		/// in the new state should call getDrawableState.
		/// </remarks>
		/// <seealso cref="drawableStateChanged()">drawableStateChanged()</seealso>
		/// <seealso cref="getDrawableState()">getDrawableState()</seealso>
		public virtual void refreshDrawableState()
		{
			mPrivateFlags |= DRAWABLE_STATE_DIRTY;
			drawableStateChanged();
			android.view.ViewParent parent = mParent;
			if (parent != null)
			{
				parent.childDrawableStateChanged(this);
			}
		}

		/// <summary>
		/// Return an array of resource IDs of the drawable states representing the
		/// current state of the view.
		/// </summary>
		/// <remarks>
		/// Return an array of resource IDs of the drawable states representing the
		/// current state of the view.
		/// </remarks>
		/// <returns>The current drawable state</returns>
		/// <seealso cref="android.graphics.drawable.Drawable.setState(int[])"></seealso>
		/// <seealso cref="drawableStateChanged()"></seealso>
		/// <seealso cref="onCreateDrawableState(int)"></seealso>
		public int[] getDrawableState()
		{
			if ((mDrawableState != null) && ((mPrivateFlags & DRAWABLE_STATE_DIRTY) == 0))
			{
				return mDrawableState;
			}
			else
			{
				mDrawableState = onCreateDrawableState(0);
				mPrivateFlags &= ~DRAWABLE_STATE_DIRTY;
				return mDrawableState;
			}
		}

		/// <summary>
		/// Generate the new
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// state for
		/// this view. This is called by the view
		/// system when the cached Drawable state is determined to be invalid.  To
		/// retrieve the current state, you should use
		/// <see cref="getDrawableState()">getDrawableState()</see>
		/// .
		/// </summary>
		/// <param name="extraSpace">
		/// if non-zero, this is the number of extra entries you
		/// would like in the returned array in which you can place your own
		/// states.
		/// </param>
		/// <returns>
		/// Returns an array holding the current
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// state of
		/// the view.
		/// </returns>
		/// <seealso cref="mergeDrawableStates(int[], int[])"></seealso>
		protected internal virtual int[] onCreateDrawableState(int extraSpace)
		{
			if ((mViewFlags & DUPLICATE_PARENT_STATE) == DUPLICATE_PARENT_STATE && mParent is
				 android.view.View)
			{
				return ((android.view.View)mParent).onCreateDrawableState(extraSpace);
			}
			int[] drawableState;
			int privateFlags = mPrivateFlags;
			int viewStateIndex = 0;
			if ((privateFlags & PRESSED) != 0)
			{
				viewStateIndex |= VIEW_STATE_PRESSED;
			}
			if ((mViewFlags & ENABLED_MASK) == ENABLED)
			{
				viewStateIndex |= VIEW_STATE_ENABLED;
			}
			if (isFocused())
			{
				viewStateIndex |= VIEW_STATE_FOCUSED;
			}
			if ((privateFlags & SELECTED) != 0)
			{
				viewStateIndex |= VIEW_STATE_SELECTED;
			}
			if (hasWindowFocus())
			{
				viewStateIndex |= VIEW_STATE_WINDOW_FOCUSED;
			}
			if ((privateFlags & ACTIVATED) != 0)
			{
				viewStateIndex |= VIEW_STATE_ACTIVATED;
			}
			if (mAttachInfo != null && mAttachInfo.mHardwareAccelerationRequested && android.view.HardwareRenderer
				.isAvailable())
			{
				// This is set if HW acceleration is requested, even if the current
				// process doesn't allow it.  This is just to allow app preview
				// windows to better match their app.
				viewStateIndex |= VIEW_STATE_ACCELERATED;
			}
			if ((privateFlags & HOVERED) != 0)
			{
				viewStateIndex |= VIEW_STATE_HOVERED;
			}
			int privateFlags2 = mPrivateFlags2;
			if ((privateFlags2 & DRAG_CAN_ACCEPT) != 0)
			{
				viewStateIndex |= VIEW_STATE_DRAG_CAN_ACCEPT;
			}
			if ((privateFlags2 & DRAG_HOVERED) != 0)
			{
				viewStateIndex |= VIEW_STATE_DRAG_HOVERED;
			}
			drawableState = VIEW_STATE_SETS[viewStateIndex];
			//noinspection ConstantIfStatement
			if (false)
			{
				android.util.Log.i("View", "drawableStateIndex=" + viewStateIndex);
				android.util.Log.i("View", ToString() + " pressed=" + ((privateFlags & PRESSED) !=
					 0) + " en=" + ((mViewFlags & ENABLED_MASK) == ENABLED) + " fo=" + hasFocus() + 
					" sl=" + ((privateFlags & SELECTED) != 0) + " wf=" + hasWindowFocus() + ": " + java.util.Arrays
					.toString(drawableState));
			}
			if (extraSpace == 0)
			{
				return drawableState;
			}
			int[] fullState;
			if (drawableState != null)
			{
				fullState = new int[drawableState.Length + extraSpace];
				System.Array.Copy(drawableState, 0, fullState, 0, drawableState.Length);
			}
			else
			{
				fullState = new int[extraSpace];
			}
			return fullState;
		}

		/// <summary>
		/// Merge your own state values in <var>additionalState</var> into the base
		/// state values <var>baseState</var> that were returned by
		/// <see cref="onCreateDrawableState(int)">onCreateDrawableState(int)</see>
		/// .
		/// </summary>
		/// <param name="baseState">
		/// The base state values returned by
		/// <see cref="onCreateDrawableState(int)">onCreateDrawableState(int)</see>
		/// , which will be modified to also hold your
		/// own additional state values.
		/// </param>
		/// <param name="additionalState">
		/// The additional state values you would like
		/// added to <var>baseState</var>; this array is not modified.
		/// </param>
		/// <returns>
		/// As a convenience, the <var>baseState</var> array you originally
		/// passed into the function is returned.
		/// </returns>
		/// <seealso cref="onCreateDrawableState(int)"></seealso>
		protected internal static int[] mergeDrawableStates(int[] baseState, int[] additionalState
			)
		{
			int N = baseState.Length;
			int i = N - 1;
			while (i >= 0 && baseState[i] == 0)
			{
				i--;
			}
			System.Array.Copy(additionalState, 0, baseState, i + 1, additionalState.Length);
			return baseState;
		}

		/// <summary>
		/// Call
		/// <see cref="android.graphics.drawable.Drawable.jumpToCurrentState()">Drawable.jumpToCurrentState()
		/// 	</see>
		/// on all Drawable objects associated with this view.
		/// </summary>
		public virtual void jumpDrawablesToCurrentState()
		{
			if (mBGDrawable != null)
			{
				mBGDrawable.jumpToCurrentState();
			}
		}

		/// <summary>Sets the background color for this view.</summary>
		/// <remarks>Sets the background color for this view.</remarks>
		/// <param name="color">the color of the background</param>
		[android.view.RemotableViewMethod]
		public virtual void setBackgroundColor(int color)
		{
			if (mBGDrawable is android.graphics.drawable.ColorDrawable)
			{
				((android.graphics.drawable.ColorDrawable)mBGDrawable).setColor(color);
			}
			else
			{
				setBackgroundDrawable(new android.graphics.drawable.ColorDrawable(color));
			}
		}

		/// <summary>Set the background to a given resource.</summary>
		/// <remarks>
		/// Set the background to a given resource. The resource should refer to
		/// a Drawable object or 0 to remove the background.
		/// </remarks>
		/// <param name="resid">The identifier of the resource.</param>
		/// <attr>ref android.R.styleable#View_background</attr>
		[android.view.RemotableViewMethod]
		public virtual void setBackgroundResource(int resid)
		{
			if (resid != 0 && resid == mBackgroundResource)
			{
				return;
			}
			android.graphics.drawable.Drawable d = null;
			if (resid != 0)
			{
				d = mResources.getDrawable(resid);
			}
			setBackgroundDrawable(d);
			mBackgroundResource = resid;
		}

		/// <summary>Set the background to a given Drawable, or remove the background.</summary>
		/// <remarks>
		/// Set the background to a given Drawable, or remove the background. If the
		/// background has padding, this View's padding is set to the background's
		/// padding. However, when a background is removed, this View's padding isn't
		/// touched. If setting the padding is desired, please use
		/// <see cref="setPadding(int, int, int, int)">setPadding(int, int, int, int)</see>
		/// .
		/// </remarks>
		/// <param name="d">
		/// The Drawable to use as the background, or null to remove the
		/// background
		/// </param>
		public virtual void setBackgroundDrawable(android.graphics.drawable.Drawable d)
		{
			if (d == mBGDrawable)
			{
				return;
			}
			bool requestLayout_1 = false;
			mBackgroundResource = 0;
			if (mBGDrawable != null)
			{
				mBGDrawable.setCallback(null);
				unscheduleDrawable(mBGDrawable);
			}
			if (d != null)
			{
				android.graphics.Rect padding = sThreadLocal.get();
				if (padding == null)
				{
					padding = new android.graphics.Rect();
					sThreadLocal.set(padding);
				}
				if (d.getPadding(padding))
				{
					switch (d.getResolvedLayoutDirectionSelf())
					{
						case LAYOUT_DIRECTION_RTL:
						{
							setPadding(padding.right, padding.top, padding.left, padding.bottom);
							break;
						}

						case LAYOUT_DIRECTION_LTR:
						default:
						{
							setPadding(padding.left, padding.top, padding.right, padding.bottom);
							break;
						}
					}
				}
				// Compare the minimum sizes of the old Drawable and the new.  If there isn't an old or
				// if it has a different minimum size, we should layout again
				if (mBGDrawable == null || mBGDrawable.getMinimumHeight() != d.getMinimumHeight()
					 || mBGDrawable.getMinimumWidth() != d.getMinimumWidth())
				{
					requestLayout_1 = true;
				}
				d.setCallback(this);
				if (d.isStateful())
				{
					d.setState(getDrawableState());
				}
				d.setVisible(getVisibility() == VISIBLE, false);
				mBGDrawable = d;
				if ((mPrivateFlags & SKIP_DRAW) != 0)
				{
					mPrivateFlags &= ~SKIP_DRAW;
					mPrivateFlags |= ONLY_DRAWS_BACKGROUND;
					requestLayout_1 = true;
				}
			}
			else
			{
				mBGDrawable = null;
				if ((mPrivateFlags & ONLY_DRAWS_BACKGROUND) != 0)
				{
					mPrivateFlags &= ~ONLY_DRAWS_BACKGROUND;
					mPrivateFlags |= SKIP_DRAW;
				}
				// The old background's minimum size could have affected this
				// View's layout, so let's requestLayout
				requestLayout_1 = true;
			}
			computeOpaqueFlags();
			if (requestLayout_1)
			{
				requestLayout();
			}
			mBackgroundSizeChanged = true;
			invalidate(true);
		}

		/// <summary>Gets the background drawable</summary>
		/// <returns>The drawable used as the background for this view, if any.</returns>
		public virtual android.graphics.drawable.Drawable getBackground()
		{
			return mBGDrawable;
		}

		/// <summary>Sets the padding.</summary>
		/// <remarks>
		/// Sets the padding. The view may add on the space required to display
		/// the scrollbars, depending on the style and visibility of the scrollbars.
		/// So the values returned from
		/// <see cref="getPaddingLeft()">getPaddingLeft()</see>
		/// ,
		/// <see cref="getPaddingTop()">getPaddingTop()</see>
		/// ,
		/// <see cref="getPaddingRight()">getPaddingRight()</see>
		/// and
		/// <see cref="getPaddingBottom()">getPaddingBottom()</see>
		/// may be different
		/// from the values set in this call.
		/// </remarks>
		/// <attr>ref android.R.styleable#View_padding</attr>
		/// <attr>ref android.R.styleable#View_paddingBottom</attr>
		/// <attr>ref android.R.styleable#View_paddingLeft</attr>
		/// <attr>ref android.R.styleable#View_paddingRight</attr>
		/// <attr>ref android.R.styleable#View_paddingTop</attr>
		/// <param name="left">the left padding in pixels</param>
		/// <param name="top">the top padding in pixels</param>
		/// <param name="right">the right padding in pixels</param>
		/// <param name="bottom">the bottom padding in pixels</param>
		public virtual void setPadding(int left, int top, int right, int bottom)
		{
			bool changed = false;
			mUserPaddingRelative = false;
			mUserPaddingLeft = left;
			mUserPaddingRight = right;
			mUserPaddingBottom = bottom;
			int viewFlags = mViewFlags;
			// Common case is there are no scroll bars.
			if ((viewFlags & (SCROLLBARS_VERTICAL | SCROLLBARS_HORIZONTAL)) != 0)
			{
				if ((viewFlags & SCROLLBARS_VERTICAL) != 0)
				{
					int offset = (viewFlags & SCROLLBARS_INSET_MASK) == 0 ? 0 : getVerticalScrollbarWidth
						();
					switch (mVerticalScrollbarPosition)
					{
						case SCROLLBAR_POSITION_DEFAULT:
						{
							if (getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL)
							{
								left += offset;
							}
							else
							{
								right += offset;
							}
							break;
						}

						case SCROLLBAR_POSITION_RIGHT:
						{
							right += offset;
							break;
						}

						case SCROLLBAR_POSITION_LEFT:
						{
							left += offset;
							break;
						}
					}
				}
				if ((viewFlags & SCROLLBARS_HORIZONTAL) != 0)
				{
					bottom += (viewFlags & SCROLLBARS_INSET_MASK) == 0 ? 0 : getHorizontalScrollbarHeight
						();
				}
			}
			if (mPaddingLeft != left)
			{
				changed = true;
				mPaddingLeft = left;
			}
			if (mPaddingTop != top)
			{
				changed = true;
				mPaddingTop = top;
			}
			if (mPaddingRight != right)
			{
				changed = true;
				mPaddingRight = right;
			}
			if (mPaddingBottom != bottom)
			{
				changed = true;
				mPaddingBottom = bottom;
			}
			if (changed)
			{
				requestLayout();
			}
		}

		/// <summary>Sets the relative padding.</summary>
		/// <remarks>
		/// Sets the relative padding. The view may add on the space required to display
		/// the scrollbars, depending on the style and visibility of the scrollbars.
		/// So the values returned from
		/// <see cref="getPaddingStart()">getPaddingStart()</see>
		/// ,
		/// <see cref="getPaddingTop()">getPaddingTop()</see>
		/// ,
		/// <see cref="getPaddingEnd()">getPaddingEnd()</see>
		/// and
		/// <see cref="getPaddingBottom()">getPaddingBottom()</see>
		/// may be different
		/// from the values set in this call.
		/// </remarks>
		/// <attr>ref android.R.styleable#View_padding</attr>
		/// <attr>ref android.R.styleable#View_paddingBottom</attr>
		/// <attr>ref android.R.styleable#View_paddingStart</attr>
		/// <attr>ref android.R.styleable#View_paddingEnd</attr>
		/// <attr>ref android.R.styleable#View_paddingTop</attr>
		/// <param name="start">the start padding in pixels</param>
		/// <param name="top">the top padding in pixels</param>
		/// <param name="end">the end padding in pixels</param>
		/// <param name="bottom">the bottom padding in pixels</param>
		/// <hide></hide>
		public virtual void setPaddingRelative(int start, int top, int end, int bottom)
		{
			mUserPaddingRelative = true;
			mUserPaddingStart = start;
			mUserPaddingEnd = end;
			switch (getResolvedLayoutDirection())
			{
				case LAYOUT_DIRECTION_RTL:
				{
					setPadding(end, top, start, bottom);
					break;
				}

				case LAYOUT_DIRECTION_LTR:
				default:
				{
					setPadding(start, top, end, bottom);
					break;
				}
			}
		}

		/// <summary>Returns the top padding of this view.</summary>
		/// <remarks>Returns the top padding of this view.</remarks>
		/// <returns>the top padding in pixels</returns>
		public virtual int getPaddingTop()
		{
			return mPaddingTop;
		}

		/// <summary>Returns the bottom padding of this view.</summary>
		/// <remarks>
		/// Returns the bottom padding of this view. If there are inset and enabled
		/// scrollbars, this value may include the space required to display the
		/// scrollbars as well.
		/// </remarks>
		/// <returns>the bottom padding in pixels</returns>
		public virtual int getPaddingBottom()
		{
			return mPaddingBottom;
		}

		/// <summary>Returns the left padding of this view.</summary>
		/// <remarks>
		/// Returns the left padding of this view. If there are inset and enabled
		/// scrollbars, this value may include the space required to display the
		/// scrollbars as well.
		/// </remarks>
		/// <returns>the left padding in pixels</returns>
		public virtual int getPaddingLeft()
		{
			return mPaddingLeft;
		}

		/// <summary>Returns the start padding of this view.</summary>
		/// <remarks>
		/// Returns the start padding of this view. If there are inset and enabled
		/// scrollbars, this value may include the space required to display the
		/// scrollbars as well.
		/// </remarks>
		/// <returns>the start padding in pixels</returns>
		/// <hide></hide>
		public virtual int getPaddingStart()
		{
			return (getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL) ? mPaddingRight : mPaddingLeft;
		}

		/// <summary>Returns the right padding of this view.</summary>
		/// <remarks>
		/// Returns the right padding of this view. If there are inset and enabled
		/// scrollbars, this value may include the space required to display the
		/// scrollbars as well.
		/// </remarks>
		/// <returns>the right padding in pixels</returns>
		public virtual int getPaddingRight()
		{
			return mPaddingRight;
		}

		/// <summary>Returns the end padding of this view.</summary>
		/// <remarks>
		/// Returns the end padding of this view. If there are inset and enabled
		/// scrollbars, this value may include the space required to display the
		/// scrollbars as well.
		/// </remarks>
		/// <returns>the end padding in pixels</returns>
		/// <hide></hide>
		public virtual int getPaddingEnd()
		{
			return (getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL) ? mPaddingLeft : mPaddingRight;
		}

		/// <summary>
		/// Return if the padding as been set thru relative values
		/// <see cref="setPaddingRelative(int, int, int, int)">setPaddingRelative(int, int, int, int)
		/// 	</see>
		/// or thru
		/// </summary>
		/// <attr>ref android.R.styleable#View_paddingStart or</attr>
		/// <attr>ref android.R.styleable#View_paddingEnd</attr>
		/// <returns>true if the padding is relative or false if it is not.</returns>
		/// <hide></hide>
		public virtual bool isPaddingRelative()
		{
			return mUserPaddingRelative;
		}

		/// <summary>Changes the selection state of this view.</summary>
		/// <remarks>
		/// Changes the selection state of this view. A view can be selected or not.
		/// Note that selection is not the same as focus. Views are typically
		/// selected in the context of an AdapterView like ListView or GridView;
		/// the selected view is the view that is highlighted.
		/// </remarks>
		/// <param name="selected">true if the view must be selected, false otherwise</param>
		public virtual void setSelected(bool selected)
		{
			if (((mPrivateFlags & SELECTED) != 0) != selected)
			{
				mPrivateFlags = (mPrivateFlags & ~SELECTED) | (selected ? SELECTED : 0);
				if (!selected)
				{
					resetPressedState();
				}
				invalidate(true);
				refreshDrawableState();
				dispatchSetSelected(selected);
			}
		}

		/// <summary>Dispatch setSelected to all of this View's children.</summary>
		/// <remarks>Dispatch setSelected to all of this View's children.</remarks>
		/// <seealso cref="setSelected(bool)">setSelected(bool)</seealso>
		/// <param name="selected">The new selected state</param>
		protected internal virtual void dispatchSetSelected(bool selected)
		{
		}

		/// <summary>Indicates the selection state of this view.</summary>
		/// <remarks>Indicates the selection state of this view.</remarks>
		/// <returns>true if the view is selected, false otherwise</returns>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isSelected()
		{
			return (mPrivateFlags & SELECTED) != 0;
		}

		/// <summary>Changes the activated state of this view.</summary>
		/// <remarks>
		/// Changes the activated state of this view. A view can be activated or not.
		/// Note that activation is not the same as selection.  Selection is
		/// a transient property, representing the view (hierarchy) the user is
		/// currently interacting with.  Activation is a longer-term state that the
		/// user can move views in and out of.  For example, in a list view with
		/// single or multiple selection enabled, the views in the current selection
		/// set are activated.  (Um, yeah, we are deeply sorry about the terminology
		/// here.)  The activated state is propagated down to children of the view it
		/// is set on.
		/// </remarks>
		/// <param name="activated">true if the view must be activated, false otherwise</param>
		public virtual void setActivated(bool activated)
		{
			if (((mPrivateFlags & ACTIVATED) != 0) != activated)
			{
				mPrivateFlags = (mPrivateFlags & ~ACTIVATED) | (activated ? ACTIVATED : 0);
				invalidate(true);
				refreshDrawableState();
				dispatchSetActivated(activated);
			}
		}

		/// <summary>Dispatch setActivated to all of this View's children.</summary>
		/// <remarks>Dispatch setActivated to all of this View's children.</remarks>
		/// <seealso cref="setActivated(bool)">setActivated(bool)</seealso>
		/// <param name="activated">The new activated state</param>
		protected internal virtual void dispatchSetActivated(bool activated)
		{
		}

		/// <summary>Indicates the activation state of this view.</summary>
		/// <remarks>Indicates the activation state of this view.</remarks>
		/// <returns>true if the view is activated, false otherwise</returns>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isActivated()
		{
			return (mPrivateFlags & ACTIVATED) != 0;
		}

		/// <summary>Returns the ViewTreeObserver for this view's hierarchy.</summary>
		/// <remarks>
		/// Returns the ViewTreeObserver for this view's hierarchy. The view tree
		/// observer can be used to get notifications when global events, like
		/// layout, happen.
		/// The returned ViewTreeObserver observer is not guaranteed to remain
		/// valid for the lifetime of this View. If the caller of this method keeps
		/// a long-lived reference to ViewTreeObserver, it should always check for
		/// the return value of
		/// <see cref="ViewTreeObserver.isAlive()">ViewTreeObserver.isAlive()</see>
		/// .
		/// </remarks>
		/// <returns>The ViewTreeObserver for this view's hierarchy.</returns>
		public virtual android.view.ViewTreeObserver getViewTreeObserver()
		{
			if (mAttachInfo != null)
			{
				return mAttachInfo.mTreeObserver;
			}
			if (mFloatingTreeObserver == null)
			{
				mFloatingTreeObserver = new android.view.ViewTreeObserver();
			}
			return mFloatingTreeObserver;
		}

		/// <summary><p>Finds the topmost view in the current view hierarchy.</p></summary>
		/// <returns>the topmost view containing this view</returns>
		public virtual android.view.View getRootView()
		{
			if (mAttachInfo != null)
			{
				android.view.View v = mAttachInfo.mRootView;
				if (v != null)
				{
					return v;
				}
			}
			android.view.View parent = this;
			while (parent.mParent != null && parent.mParent is android.view.View)
			{
				parent = (android.view.View)parent.mParent;
			}
			return parent;
		}

		/// <summary><p>Computes the coordinates of this view on the screen.</summary>
		/// <remarks>
		/// <p>Computes the coordinates of this view on the screen. The argument
		/// must be an array of two integers. After the method returns, the array
		/// contains the x and y location in that order.</p>
		/// </remarks>
		/// <param name="location">an array of two integers in which to hold the coordinates</param>
		public virtual void getLocationOnScreen(int[] location)
		{
			getLocationInWindow(location);
			android.view.View.AttachInfo info = mAttachInfo;
			if (info != null)
			{
				location[0] += info.mWindowLeft;
				location[1] += info.mWindowTop;
			}
		}

		/// <summary><p>Computes the coordinates of this view in its window.</summary>
		/// <remarks>
		/// <p>Computes the coordinates of this view in its window. The argument
		/// must be an array of two integers. After the method returns, the array
		/// contains the x and y location in that order.</p>
		/// </remarks>
		/// <param name="location">an array of two integers in which to hold the coordinates</param>
		public virtual void getLocationInWindow(int[] location)
		{
			if (location == null || location.Length < 2)
			{
				throw new System.ArgumentException("location must be an array of " + "two integers"
					);
			}
			location[0] = mLeft;
			location[1] = mTop;
			if (mTransformationInfo != null)
			{
				location[0] += (int)(mTransformationInfo.mTranslationX + 0.5f);
				location[1] += (int)(mTransformationInfo.mTranslationY + 0.5f);
			}
			android.view.ViewParent viewParent = mParent;
			while (viewParent is android.view.View)
			{
				android.view.View view = (android.view.View)viewParent;
				location[0] += view.mLeft - view.mScrollX;
				location[1] += view.mTop - view.mScrollY;
				if (view.mTransformationInfo != null)
				{
					location[0] += (int)(view.mTransformationInfo.mTranslationX + 0.5f);
					location[1] += (int)(view.mTransformationInfo.mTranslationY + 0.5f);
				}
				viewParent = view.mParent;
			}
			if (viewParent is android.view.ViewRootImpl)
			{
				// *cough*
				android.view.ViewRootImpl vr = (android.view.ViewRootImpl)viewParent;
				location[1] -= vr.mCurScrollY;
			}
		}

		/// <summary><hide></hide></summary>
		/// <param name="id">the id of the view to be found</param>
		/// <returns>the view of the specified id, null if cannot be found</returns>
		protected internal virtual android.view.View findViewTraversal(int id)
		{
			if (id == mID)
			{
				return this;
			}
			return null;
		}

		/// <summary><hide></hide></summary>
		/// <param name="tag">the tag of the view to be found</param>
		/// <returns>the view of specified tag, null if cannot be found</returns>
		protected internal virtual android.view.View findViewWithTagTraversal(object tag)
		{
			if (tag != null && tag.Equals(mTag))
			{
				return this;
			}
			return null;
		}

		/// <summary><hide></hide></summary>
		/// <param name="predicate">The predicate to evaluate.</param>
		/// <param name="childToSkip">If not null, ignores this child during the recursive traversal.
		/// 	</param>
		/// <returns>The first view that matches the predicate or null.</returns>
		protected internal virtual android.view.View findViewByPredicateTraversal(android.util.@internal.Predicate
			<android.view.View> predicate, android.view.View childToSkip)
		{
			if (predicate.apply(this))
			{
				return this;
			}
			return null;
		}

		/// <summary>Look for a child view with the given id.</summary>
		/// <remarks>
		/// Look for a child view with the given id.  If this view has the given
		/// id, return this view.
		/// </remarks>
		/// <param name="id">The id to search for.</param>
		/// <returns>The view that has the given id in the hierarchy or null</returns>
		public android.view.View findViewById(int id)
		{
			if (id < 0)
			{
				return null;
			}
			return findViewTraversal(id);
		}

		/// <summary>Finds a view by its unuque and stable accessibility id.</summary>
		/// <remarks>Finds a view by its unuque and stable accessibility id.</remarks>
		/// <param name="accessibilityId">The searched accessibility id.</param>
		/// <returns>The found view.</returns>
		internal android.view.View findViewByAccessibilityId(int accessibilityId)
		{
			if (accessibilityId < 0)
			{
				return null;
			}
			return findViewByAccessibilityIdTraversal(accessibilityId);
		}

		/// <summary>Performs the traversal to find a view by its unuque and stable accessibility id.
		/// 	</summary>
		/// <remarks>
		/// Performs the traversal to find a view by its unuque and stable accessibility id.
		/// <strong>Note:</strong>This method does not stop at the root namespace
		/// boundary since the user can touch the screen at an arbitrary location
		/// potentially crossing the root namespace bounday which will send an
		/// accessibility event to accessibility services and they should be able
		/// to obtain the event source. Also accessibility ids are guaranteed to be
		/// unique in the window.
		/// </remarks>
		/// <param name="accessibilityId">The accessibility id.</param>
		/// <returns>The found view.</returns>
		internal virtual android.view.View findViewByAccessibilityIdTraversal(int accessibilityId
			)
		{
			if (getAccessibilityViewId() == accessibilityId)
			{
				return this;
			}
			return null;
		}

		/// <summary>Look for a child view with the given tag.</summary>
		/// <remarks>
		/// Look for a child view with the given tag.  If this view has the given
		/// tag, return this view.
		/// </remarks>
		/// <param name="tag">The tag to search for, using "tag.equals(getTag())".</param>
		/// <returns>The View that has the given tag in the hierarchy or null</returns>
		public android.view.View findViewWithTag(object tag)
		{
			if (tag == null)
			{
				return null;
			}
			return findViewWithTagTraversal(tag);
		}

		/// <summary>
		/// <hide></hide>
		/// Look for a child view that matches the specified predicate.
		/// If this view matches the predicate, return this view.
		/// </summary>
		/// <param name="predicate">The predicate to evaluate.</param>
		/// <returns>The first view that matches the predicate or null.</returns>
		public android.view.View findViewByPredicate(android.util.@internal.Predicate<android.view.View
			> predicate)
		{
			return findViewByPredicateTraversal(predicate, null);
		}

		/// <summary>
		/// <hide></hide>
		/// Look for a child view that matches the specified predicate,
		/// starting with the specified view and its descendents and then
		/// recusively searching the ancestors and siblings of that view
		/// until this view is reached.
		/// This method is useful in cases where the predicate does not match
		/// a single unique view (perhaps multiple views use the same id)
		/// and we are trying to find the view that is "closest" in scope to the
		/// starting view.
		/// </summary>
		/// <param name="start">The view to start from.</param>
		/// <param name="predicate">The predicate to evaluate.</param>
		/// <returns>The first view that matches the predicate or null.</returns>
		public android.view.View findViewByPredicateInsideOut(android.view.View start, android.util.@internal.Predicate
			<android.view.View> predicate)
		{
			android.view.View childToSkip = null;
			for (; ; )
			{
				android.view.View view = start.findViewByPredicateTraversal(predicate, childToSkip
					);
				if (view != null || start == this)
				{
					return view;
				}
				android.view.ViewParent parent = start.getParent();
				if (parent == null || !(parent is android.view.View))
				{
					return null;
				}
				childToSkip = start;
				start = (android.view.View)parent;
			}
		}

		/// <summary>Sets the identifier for this view.</summary>
		/// <remarks>
		/// Sets the identifier for this view. The identifier does not have to be
		/// unique in this view's hierarchy. The identifier should be a positive
		/// number.
		/// </remarks>
		/// <seealso cref="NO_ID">NO_ID</seealso>
		/// <seealso cref="getId()"></seealso>
		/// <seealso cref="findViewById(int)"></seealso>
		/// <param name="id">a number used to identify the view</param>
		/// <attr>ref android.R.styleable#View_id</attr>
		public virtual void setId(int id)
		{
			mID = id;
		}

		/// <summary><hide></hide></summary>
		/// <param name="isRoot">
		/// true if the view belongs to the root namespace, false
		/// otherwise
		/// </param>
		public virtual void setIsRootNamespace(bool isRoot)
		{
			if (isRoot)
			{
				mPrivateFlags |= IS_ROOT_NAMESPACE;
			}
			else
			{
				mPrivateFlags &= ~IS_ROOT_NAMESPACE;
			}
		}

		/// <summary><hide></hide></summary>
		/// <returns>true if the view belongs to the root namespace, false otherwise</returns>
		public virtual bool isRootNamespace()
		{
			return (mPrivateFlags & IS_ROOT_NAMESPACE) != 0;
		}

		/// <summary>Returns this view's identifier.</summary>
		/// <remarks>Returns this view's identifier.</remarks>
		/// <returns>
		/// a positive integer used to identify the view or
		/// <see cref="NO_ID">NO_ID</see>
		/// if the view has no ID
		/// </returns>
		/// <seealso cref="setId(int)"></seealso>
		/// <seealso cref="findViewById(int)"></seealso>
		/// <attr>ref android.R.styleable#View_id</attr>
		[android.view.ViewDebug.CapturedViewProperty]
		public virtual int getId()
		{
			return mID;
		}

		/// <summary>Returns this view's tag.</summary>
		/// <remarks>Returns this view's tag.</remarks>
		/// <returns>the Object stored in this view as a tag</returns>
		/// <seealso cref="setTag(object)">setTag(object)</seealso>
		/// <seealso cref="getTag(int)">getTag(int)</seealso>
		[android.view.ViewDebug.ExportedProperty]
		public virtual object getTag()
		{
			return mTag;
		}

		/// <summary>Sets the tag associated with this view.</summary>
		/// <remarks>
		/// Sets the tag associated with this view. A tag can be used to mark
		/// a view in its hierarchy and does not have to be unique within the
		/// hierarchy. Tags can also be used to store data within a view without
		/// resorting to another data structure.
		/// </remarks>
		/// <param name="tag">an Object to tag the view with</param>
		/// <seealso cref="getTag()">getTag()</seealso>
		/// <seealso cref="setTag(int, object)">setTag(int, object)</seealso>
		public virtual void setTag(object tag)
		{
			mTag = tag;
		}

		/// <summary>Returns the tag associated with this view and the specified key.</summary>
		/// <remarks>Returns the tag associated with this view and the specified key.</remarks>
		/// <param name="key">The key identifying the tag</param>
		/// <returns>the Object stored in this view as a tag</returns>
		/// <seealso cref="setTag(int, object)">setTag(int, object)</seealso>
		/// <seealso cref="getTag()">getTag()</seealso>
		public virtual object getTag(int key)
		{
			if (mKeyedTags != null)
			{
				return mKeyedTags.get(key);
			}
			return null;
		}

		/// <summary>Sets a tag associated with this view and a key.</summary>
		/// <remarks>
		/// Sets a tag associated with this view and a key. A tag can be used
		/// to mark a view in its hierarchy and does not have to be unique within
		/// the hierarchy. Tags can also be used to store data within a view
		/// without resorting to another data structure.
		/// The specified key should be an id declared in the resources of the
		/// application to ensure it is unique (see the &lt;a
		/// href=
		/// <docRoot></docRoot>
		/// guide/topics/resources/more-resources.html#Id"&gt;ID resource type</a>).
		/// Keys identified as belonging to
		/// the Android framework or not associated with any package will cause
		/// an
		/// <see cref="System.ArgumentException">System.ArgumentException</see>
		/// to be thrown.
		/// </remarks>
		/// <param name="key">The key identifying the tag</param>
		/// <param name="tag">An Object to tag the view with</param>
		/// <exception cref="System.ArgumentException">If they specified key is not valid</exception>
		/// <seealso cref="setTag(object)">setTag(object)</seealso>
		/// <seealso cref="getTag(int)">getTag(int)</seealso>
		public virtual void setTag(int key, object tag)
		{
			// If the package id is 0x00 or 0x01, it's either an undefined package
			// or a framework id
			if (((int)(((uint)key) >> 24)) < 2)
			{
				throw new System.ArgumentException("The key must be an application-specific " + "resource id."
					);
			}
			setKeyedTag(key, tag);
		}

		/// <summary>
		/// Variation of
		/// <see cref="setTag(int, object)">setTag(int, object)</see>
		/// that enforces the key to be a
		/// framework id.
		/// </summary>
		/// <hide></hide>
		public virtual void setTagInternal(int key, object tag)
		{
			if (((int)(((uint)key) >> 24)) != unchecked((int)(0x1)))
			{
				throw new System.ArgumentException("The key must be a framework-specific " + "resource id."
					);
			}
			setKeyedTag(key, tag);
		}

		private void setKeyedTag(int key, object tag)
		{
			if (mKeyedTags == null)
			{
				mKeyedTags = new android.util.SparseArray<object>();
			}
			mKeyedTags.put(key, tag);
		}

		/// <param name="consistency">The type of consistency. See ViewDebug for more information.
		/// 	</param>
		/// <hide></hide>
		protected internal virtual bool dispatchConsistencyCheck(int consistency)
		{
			return onConsistencyCheck(consistency);
		}

		/// <summary>Method that subclasses should implement to check their consistency.</summary>
		/// <remarks>
		/// Method that subclasses should implement to check their consistency. The type of
		/// consistency check is indicated by the bit field passed as a parameter.
		/// </remarks>
		/// <param name="consistency">The type of consistency. See ViewDebug for more information.
		/// 	</param>
		/// <exception cref="System.InvalidOperationException">if the view is in an inconsistent state.
		/// 	</exception>
		/// <hide></hide>
		protected internal virtual bool onConsistencyCheck(int consistency)
		{
			bool result = true;
			bool checkLayout = (consistency & android.view.ViewDebug.CONSISTENCY_LAYOUT) != 0;
			bool checkDrawing = (consistency & android.view.ViewDebug.CONSISTENCY_DRAWING) !=
				 0;
			if (checkLayout)
			{
				if (getParent() == null)
				{
					result = false;
					android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "View " + this + " does not have a parent."
						);
				}
				if (mAttachInfo == null)
				{
					result = false;
					android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "View " + this + " is not attached to a window."
						);
				}
			}
			if (checkDrawing)
			{
				// Do not check the DIRTY/DRAWN flags because views can call invalidate()
				// from their draw() method
				if ((mPrivateFlags & DRAWN) != DRAWN && (mPrivateFlags & DRAWING_CACHE_VALID) == 
					DRAWING_CACHE_VALID)
				{
					result = false;
					android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "View " + this + " was invalidated but its drawing cache is valid."
						);
				}
			}
			return result;
		}

		/// <summary>
		/// Prints information about this view in the log output, with the tag
		/// <see cref="VIEW_LOG_TAG">VIEW_LOG_TAG</see>
		/// .
		/// </summary>
		/// <hide></hide>
		public virtual void debug()
		{
			debug(0);
		}

		/// <summary>
		/// Prints information about this view in the log output, with the tag
		/// <see cref="VIEW_LOG_TAG">VIEW_LOG_TAG</see>
		/// . Each line in the output is preceded with an
		/// indentation defined by the <code>depth</code>.
		/// </summary>
		/// <param name="depth">the indentation level</param>
		/// <hide></hide>
		protected internal virtual void debug(int depth)
		{
			string output = debugIndent(depth - 1);
			output += "+ " + this;
			int id = getId();
			if (id != -1)
			{
				output += " (id=" + id + ")";
			}
			object tag = getTag();
			if (tag != null)
			{
				output += " (tag=" + tag + ")";
			}
			android.util.Log.d(VIEW_LOG_TAG, output);
			if ((mPrivateFlags & FOCUSED) != 0)
			{
				output = debugIndent(depth) + " FOCUSED";
				android.util.Log.d(VIEW_LOG_TAG, output);
			}
			output = debugIndent(depth);
			output += "frame={" + mLeft + ", " + mTop + ", " + mRight + ", " + mBottom + "} scroll={"
				 + mScrollX + ", " + mScrollY + "} ";
			android.util.Log.d(VIEW_LOG_TAG, output);
			if (mPaddingLeft != 0 || mPaddingTop != 0 || mPaddingRight != 0 || mPaddingBottom
				 != 0)
			{
				output = debugIndent(depth);
				output += "padding={" + mPaddingLeft + ", " + mPaddingTop + ", " + mPaddingRight 
					+ ", " + mPaddingBottom + "}";
				android.util.Log.d(VIEW_LOG_TAG, output);
			}
			output = debugIndent(depth);
			output += "mMeasureWidth=" + mMeasuredWidth + " mMeasureHeight=" + mMeasuredHeight;
			android.util.Log.d(VIEW_LOG_TAG, output);
			output = debugIndent(depth);
			if (mLayoutParams == null)
			{
				output += "BAD! no layout params";
			}
			else
			{
				output = mLayoutParams.debug(output);
			}
			android.util.Log.d(VIEW_LOG_TAG, output);
			output = debugIndent(depth);
			output += "flags={";
			output += android.view.View.printFlags(mViewFlags);
			output += "}";
			android.util.Log.d(VIEW_LOG_TAG, output);
			output = debugIndent(depth);
			output += "privateFlags={";
			output += android.view.View.printPrivateFlags(mPrivateFlags);
			output += "}";
			android.util.Log.d(VIEW_LOG_TAG, output);
		}

		/// <summary>Creates an string of whitespaces used for indentation.</summary>
		/// <remarks>Creates an string of whitespaces used for indentation.</remarks>
		/// <param name="depth">the indentation level</param>
		/// <returns>a String containing (depth * 2 + 3) * 2 white spaces</returns>
		/// <hide></hide>
		protected internal static string debugIndent(int depth)
		{
			java.lang.StringBuilder spaces = new java.lang.StringBuilder((depth * 2 + 3) * 2);
			{
				for (int i = 0; i < (depth * 2) + 3; i++)
				{
					spaces.append(' ').append(' ');
				}
			}
			return spaces.ToString();
		}

		/// <summary>
		/// <p>Return the offset of the widget's text baseline from the widget's top
		/// boundary.
		/// </summary>
		/// <remarks>
		/// <p>Return the offset of the widget's text baseline from the widget's top
		/// boundary. If this widget does not support baseline alignment, this
		/// method returns -1. </p>
		/// </remarks>
		/// <returns>
		/// the offset of the baseline within the widget's bounds or -1
		/// if baseline alignment is not supported
		/// </returns>
		public virtual int getBaseline()
		{
			return -1;
		}

		/// <summary>
		/// Call this when something has changed which has invalidated the
		/// layout of this view.
		/// </summary>
		/// <remarks>
		/// Call this when something has changed which has invalidated the
		/// layout of this view. This will schedule a layout pass of the view
		/// tree.
		/// </remarks>
		public virtual void requestLayout()
		{
			mPrivateFlags |= FORCE_LAYOUT;
			mPrivateFlags |= INVALIDATED;
			if (mParent != null)
			{
				if (mLayoutParams != null)
				{
					mLayoutParams.resolveWithDirection(getResolvedLayoutDirection());
				}
				if (!mParent.isLayoutRequested())
				{
					mParent.requestLayout();
				}
			}
		}

		/// <summary>Forces this view to be laid out during the next layout pass.</summary>
		/// <remarks>
		/// Forces this view to be laid out during the next layout pass.
		/// This method does not call requestLayout() or forceLayout()
		/// on the parent.
		/// </remarks>
		public virtual void forceLayout()
		{
			mPrivateFlags |= FORCE_LAYOUT;
			mPrivateFlags |= INVALIDATED;
		}

		/// <summary>
		/// <p>
		/// This is called to find out how big a view should be.
		/// </summary>
		/// <remarks>
		/// <p>
		/// This is called to find out how big a view should be. The parent
		/// supplies constraint information in the width and height parameters.
		/// </p>
		/// <p>
		/// The actual mesurement work of a view is performed in
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// , called by this method. Therefore, only
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// can and must be overriden by subclasses.
		/// </p>
		/// </remarks>
		/// <param name="widthMeasureSpec">
		/// Horizontal space requirements as imposed by the
		/// parent
		/// </param>
		/// <param name="heightMeasureSpec">
		/// Vertical space requirements as imposed by the
		/// parent
		/// </param>
		/// <seealso cref="onMeasure(int, int)">onMeasure(int, int)</seealso>
		public void measure(int widthMeasureSpec, int heightMeasureSpec)
		{
			if ((mPrivateFlags & FORCE_LAYOUT) == FORCE_LAYOUT || widthMeasureSpec != mOldWidthMeasureSpec
				 || heightMeasureSpec != mOldHeightMeasureSpec)
			{
				// first clears the measured dimension flag
				mPrivateFlags &= ~MEASURED_DIMENSION_SET;
				// measure ourselves, this should set the measured dimension flag back
				onMeasure(widthMeasureSpec, heightMeasureSpec);
				// flag not set, setMeasuredDimension() was not invoked, we raise
				// an exception to warn the developer
				if ((mPrivateFlags & MEASURED_DIMENSION_SET) != MEASURED_DIMENSION_SET)
				{
					throw new System.InvalidOperationException("onMeasure() did not set the" + " measured dimension by calling"
						 + " setMeasuredDimension()");
				}
				mPrivateFlags |= LAYOUT_REQUIRED;
			}
			mOldWidthMeasureSpec = widthMeasureSpec;
			mOldHeightMeasureSpec = heightMeasureSpec;
		}

		/// <summary>
		/// <p>
		/// Measure the view and its content to determine the measured width and the
		/// measured height.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Measure the view and its content to determine the measured width and the
		/// measured height. This method is invoked by
		/// <see cref="measure(int, int)">measure(int, int)</see>
		/// and
		/// should be overriden by subclasses to provide accurate and efficient
		/// measurement of their contents.
		/// </p>
		/// <p>
		/// <strong>CONTRACT:</strong> When overriding this method, you
		/// <em>must</em> call
		/// <see cref="setMeasuredDimension(int, int)">setMeasuredDimension(int, int)</see>
		/// to store the
		/// measured width and height of this view. Failure to do so will trigger an
		/// <code>IllegalStateException</code>, thrown by
		/// <see cref="measure(int, int)">measure(int, int)</see>
		/// . Calling the superclass'
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// is a valid use.
		/// </p>
		/// <p>
		/// The base class implementation of measure defaults to the background size,
		/// unless a larger size is allowed by the MeasureSpec. Subclasses should
		/// override
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// to provide better measurements of
		/// their content.
		/// </p>
		/// <p>
		/// If this method is overridden, it is the subclass's responsibility to make
		/// sure the measured height and width are at least the view's minimum height
		/// and width (
		/// <see cref="getSuggestedMinimumHeight()">getSuggestedMinimumHeight()</see>
		/// and
		/// <see cref="getSuggestedMinimumWidth()">getSuggestedMinimumWidth()</see>
		/// ).
		/// </p>
		/// </remarks>
		/// <param name="widthMeasureSpec">
		/// horizontal space requirements as imposed by the parent.
		/// The requirements are encoded with
		/// <see cref="MeasureSpec">MeasureSpec</see>
		/// .
		/// </param>
		/// <param name="heightMeasureSpec">
		/// vertical space requirements as imposed by the parent.
		/// The requirements are encoded with
		/// <see cref="MeasureSpec">MeasureSpec</see>
		/// .
		/// </param>
		/// <seealso cref="getMeasuredWidth()">getMeasuredWidth()</seealso>
		/// <seealso cref="getMeasuredHeight()">getMeasuredHeight()</seealso>
		/// <seealso cref="setMeasuredDimension(int, int)">setMeasuredDimension(int, int)</seealso>
		/// <seealso cref="getSuggestedMinimumHeight()">getSuggestedMinimumHeight()</seealso>
		/// <seealso cref="getSuggestedMinimumWidth()">getSuggestedMinimumWidth()</seealso>
		/// <seealso cref="MeasureSpec.getMode(int)">MeasureSpec.getMode(int)</seealso>
		/// <seealso cref="MeasureSpec.getSize(int)">MeasureSpec.getSize(int)</seealso>
		protected internal virtual void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			setMeasuredDimension(getDefaultSize(getSuggestedMinimumWidth(), widthMeasureSpec)
				, getDefaultSize(getSuggestedMinimumHeight(), heightMeasureSpec));
		}

		/// <summary>
		/// <p>This mehod must be called by
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// to store the
		/// measured width and measured height. Failing to do so will trigger an
		/// exception at measurement time.</p>
		/// </summary>
		/// <param name="measuredWidth">
		/// The measured width of this view.  May be a complex
		/// bit mask as defined by
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// and
		/// <see cref="MEASURED_STATE_TOO_SMALL">MEASURED_STATE_TOO_SMALL</see>
		/// .
		/// </param>
		/// <param name="measuredHeight">
		/// The measured height of this view.  May be a complex
		/// bit mask as defined by
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// and
		/// <see cref="MEASURED_STATE_TOO_SMALL">MEASURED_STATE_TOO_SMALL</see>
		/// .
		/// </param>
		protected internal void setMeasuredDimension(int measuredWidth, int measuredHeight
			)
		{
			mMeasuredWidth = measuredWidth;
			mMeasuredHeight = measuredHeight;
			mPrivateFlags |= MEASURED_DIMENSION_SET;
		}

		/// <summary>
		/// Merge two states as returned by
		/// <see cref="getMeasuredState()">getMeasuredState()</see>
		/// .
		/// </summary>
		/// <param name="curState">
		/// The current state as returned from a view or the result
		/// of combining multiple views.
		/// </param>
		/// <param name="newState">The new view state to combine.</param>
		/// <returns>
		/// Returns a new integer reflecting the combination of the two
		/// states.
		/// </returns>
		public static int combineMeasuredStates(int curState, int newState)
		{
			return curState | newState;
		}

		/// <summary>
		/// Version of
		/// <see cref="resolveSizeAndState(int, int, int)">resolveSizeAndState(int, int, int)
		/// 	</see>
		/// returning only the
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// bits of the result.
		/// </summary>
		public static int resolveSize(int size, int measureSpec)
		{
			return resolveSizeAndState(size, measureSpec, 0) & MEASURED_SIZE_MASK;
		}

		/// <summary>
		/// Utility to reconcile a desired size and state, with constraints imposed
		/// by a MeasureSpec.
		/// </summary>
		/// <remarks>
		/// Utility to reconcile a desired size and state, with constraints imposed
		/// by a MeasureSpec.  Will take the desired size, unless a different size
		/// is imposed by the constraints.  The returned value is a compound integer,
		/// with the resolved size in the
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// bits and
		/// optionally the bit
		/// <see cref="MEASURED_STATE_TOO_SMALL">MEASURED_STATE_TOO_SMALL</see>
		/// set if the resulting
		/// size is smaller than the size the view wants to be.
		/// </remarks>
		/// <param name="size">How big the view wants to be</param>
		/// <param name="measureSpec">Constraints imposed by the parent</param>
		/// <returns>
		/// Size information bit mask as defined by
		/// <see cref="MEASURED_SIZE_MASK">MEASURED_SIZE_MASK</see>
		/// and
		/// <see cref="MEASURED_STATE_TOO_SMALL">MEASURED_STATE_TOO_SMALL</see>
		/// .
		/// </returns>
		public static int resolveSizeAndState(int size, int measureSpec, int childMeasuredState
			)
		{
			int result = size;
			int specMode = android.view.View.MeasureSpec.getMode(measureSpec);
			int specSize = android.view.View.MeasureSpec.getSize(measureSpec);
			switch (specMode)
			{
				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					result = size;
					break;
				}

				case android.view.View.MeasureSpec.AT_MOST:
				{
					if (specSize < size)
					{
						result = specSize | MEASURED_STATE_TOO_SMALL;
					}
					else
					{
						result = size;
					}
					break;
				}

				case android.view.View.MeasureSpec.EXACTLY:
				{
					result = specSize;
					break;
				}
			}
			return result | (childMeasuredState & MEASURED_STATE_MASK);
		}

		/// <summary>Utility to return a default size.</summary>
		/// <remarks>
		/// Utility to return a default size. Uses the supplied size if the
		/// MeasureSpec imposed no constraints. Will get larger if allowed
		/// by the MeasureSpec.
		/// </remarks>
		/// <param name="size">Default size for this view</param>
		/// <param name="measureSpec">Constraints imposed by the parent</param>
		/// <returns>The size this view should be.</returns>
		public static int getDefaultSize(int size, int measureSpec)
		{
			int result = size;
			int specMode = android.view.View.MeasureSpec.getMode(measureSpec);
			int specSize = android.view.View.MeasureSpec.getSize(measureSpec);
			switch (specMode)
			{
				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					result = size;
					break;
				}

				case android.view.View.MeasureSpec.AT_MOST:
				case android.view.View.MeasureSpec.EXACTLY:
				{
					result = specSize;
					break;
				}
			}
			return result;
		}

		/// <summary>Returns the suggested minimum height that the view should use.</summary>
		/// <remarks>
		/// Returns the suggested minimum height that the view should use. This
		/// returns the maximum of the view's minimum height
		/// and the background's minimum height
		/// (
		/// <see cref="android.graphics.drawable.Drawable.getMinimumHeight()">android.graphics.drawable.Drawable.getMinimumHeight()
		/// 	</see>
		/// ).
		/// <p>
		/// When being used in
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// , the caller should still
		/// ensure the returned height is within the requirements of the parent.
		/// </remarks>
		/// <returns>The suggested minimum height of the view.</returns>
		protected internal virtual int getSuggestedMinimumHeight()
		{
			int suggestedMinHeight = mMinHeight;
			if (mBGDrawable != null)
			{
				int bgMinHeight = mBGDrawable.getMinimumHeight();
				if (suggestedMinHeight < bgMinHeight)
				{
					suggestedMinHeight = bgMinHeight;
				}
			}
			return suggestedMinHeight;
		}

		/// <summary>Returns the suggested minimum width that the view should use.</summary>
		/// <remarks>
		/// Returns the suggested minimum width that the view should use. This
		/// returns the maximum of the view's minimum width)
		/// and the background's minimum width
		/// (
		/// <see cref="android.graphics.drawable.Drawable.getMinimumWidth()">android.graphics.drawable.Drawable.getMinimumWidth()
		/// 	</see>
		/// ).
		/// <p>
		/// When being used in
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// , the caller should still
		/// ensure the returned width is within the requirements of the parent.
		/// </remarks>
		/// <returns>The suggested minimum width of the view.</returns>
		protected internal virtual int getSuggestedMinimumWidth()
		{
			int suggestedMinWidth = mMinWidth;
			if (mBGDrawable != null)
			{
				int bgMinWidth = mBGDrawable.getMinimumWidth();
				if (suggestedMinWidth < bgMinWidth)
				{
					suggestedMinWidth = bgMinWidth;
				}
			}
			return suggestedMinWidth;
		}

		/// <summary>Sets the minimum height of the view.</summary>
		/// <remarks>
		/// Sets the minimum height of the view. It is not guaranteed the view will
		/// be able to achieve this minimum height (for example, if its parent layout
		/// constrains it with less available height).
		/// </remarks>
		/// <param name="minHeight">The minimum height the view will try to be.</param>
		public virtual void setMinimumHeight(int minHeight)
		{
			mMinHeight = minHeight;
		}

		/// <summary>Sets the minimum width of the view.</summary>
		/// <remarks>
		/// Sets the minimum width of the view. It is not guaranteed the view will
		/// be able to achieve this minimum width (for example, if its parent layout
		/// constrains it with less available width).
		/// </remarks>
		/// <param name="minWidth">The minimum width the view will try to be.</param>
		public virtual void setMinimumWidth(int minWidth)
		{
			mMinWidth = minWidth;
		}

		/// <summary>Get the animation currently associated with this view.</summary>
		/// <remarks>Get the animation currently associated with this view.</remarks>
		/// <returns>
		/// The animation that is currently playing or
		/// scheduled to play for this view.
		/// </returns>
		public virtual android.view.animation.Animation getAnimation()
		{
			return mCurrentAnimation;
		}

		/// <summary>Start the specified animation now.</summary>
		/// <remarks>Start the specified animation now.</remarks>
		/// <param name="animation">the animation to start now</param>
		public virtual void startAnimation(android.view.animation.Animation animation)
		{
			animation.setStartTime(android.view.animation.Animation.START_ON_FIRST_FRAME);
			setAnimation(animation);
			invalidateParentCaches();
			invalidate(true);
		}

		/// <summary>Cancels any animations for this view.</summary>
		/// <remarks>Cancels any animations for this view.</remarks>
		public virtual void clearAnimation()
		{
			if (mCurrentAnimation != null)
			{
				mCurrentAnimation.detach();
			}
			mCurrentAnimation = null;
			invalidateParentIfNeeded();
		}

		/// <summary>Sets the next animation to play for this view.</summary>
		/// <remarks>
		/// Sets the next animation to play for this view.
		/// If you want the animation to play immediately, use
		/// startAnimation. This method provides allows fine-grained
		/// control over the start time and invalidation, but you
		/// must make sure that 1) the animation has a start time set, and
		/// 2) the view will be invalidated when the animation is supposed to
		/// start.
		/// </remarks>
		/// <param name="animation">The next animation, or null.</param>
		public virtual void setAnimation(android.view.animation.Animation animation)
		{
			mCurrentAnimation = animation;
			if (animation != null)
			{
				animation.reset();
			}
		}

		/// <summary>
		/// Invoked by a parent ViewGroup to notify the start of the animation
		/// currently associated with this view.
		/// </summary>
		/// <remarks>
		/// Invoked by a parent ViewGroup to notify the start of the animation
		/// currently associated with this view. If you override this method,
		/// always call super.onAnimationStart();
		/// </remarks>
		/// <seealso cref="setAnimation(android.view.animation.Animation)">setAnimation(android.view.animation.Animation)
		/// 	</seealso>
		/// <seealso cref="getAnimation()">getAnimation()</seealso>
		protected internal virtual void onAnimationStart()
		{
			mPrivateFlags |= ANIMATION_STARTED;
		}

		/// <summary>
		/// Invoked by a parent ViewGroup to notify the end of the animation
		/// currently associated with this view.
		/// </summary>
		/// <remarks>
		/// Invoked by a parent ViewGroup to notify the end of the animation
		/// currently associated with this view. If you override this method,
		/// always call super.onAnimationEnd();
		/// </remarks>
		/// <seealso cref="setAnimation(android.view.animation.Animation)">setAnimation(android.view.animation.Animation)
		/// 	</seealso>
		/// <seealso cref="getAnimation()">getAnimation()</seealso>
		protected internal virtual void onAnimationEnd()
		{
			mPrivateFlags &= ~ANIMATION_STARTED;
		}

		/// <summary>Invoked if there is a Transform that involves alpha.</summary>
		/// <remarks>
		/// Invoked if there is a Transform that involves alpha. Subclass that can
		/// draw themselves with the specified alpha should return true, and then
		/// respect that alpha when their onDraw() is called. If this returns false
		/// then the view may be redirected to draw into an offscreen buffer to
		/// fulfill the request, which will look fine, but may be slower than if the
		/// subclass handles it internally. The default implementation returns false.
		/// </remarks>
		/// <param name="alpha">The alpha (0..255) to apply to the view's drawing</param>
		/// <returns>true if the view can draw with the specified alpha.</returns>
		protected internal virtual bool onSetAlpha(int alpha)
		{
			return false;
		}

		/// <summary>
		/// This is used by the RootView to perform an optimization when
		/// the view hierarchy contains one or several SurfaceView.
		/// </summary>
		/// <remarks>
		/// This is used by the RootView to perform an optimization when
		/// the view hierarchy contains one or several SurfaceView.
		/// SurfaceView is always considered transparent, but its children are not,
		/// therefore all View objects remove themselves from the global transparent
		/// region (passed as a parameter to this function).
		/// </remarks>
		/// <param name="region">The transparent region for this ViewAncestor (window).</param>
		/// <returns>
		/// Returns true if the effective visibility of the view at this
		/// point is opaque, regardless of the transparent region; returns false
		/// if it is possible for underlying windows to be seen behind the view.
		/// <hide></hide>
		/// </returns>
		public virtual bool gatherTransparentRegion(android.graphics.Region region)
		{
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (region != null && attachInfo != null)
			{
				int pflags = mPrivateFlags;
				if ((pflags & SKIP_DRAW) == 0)
				{
					// The SKIP_DRAW flag IS NOT set, so this view draws. We need to
					// remove it from the transparent region.
					int[] location = attachInfo.mTransparentLocation;
					getLocationInWindow(location);
					region.op(location[0], location[1], location[0] + mRight - mLeft, location[1] + mBottom
						 - mTop, android.graphics.Region.Op.DIFFERENCE);
				}
				else
				{
					if ((pflags & ONLY_DRAWS_BACKGROUND) != 0 && mBGDrawable != null)
					{
						// The ONLY_DRAWS_BACKGROUND flag IS set and the background drawable
						// exists, so we remove the background drawable's non-transparent
						// parts from this transparent region.
						applyDrawableToTransparentRegion(mBGDrawable, region);
					}
				}
			}
			return true;
		}

		/// <summary>Play a sound effect for this view.</summary>
		/// <remarks>
		/// Play a sound effect for this view.
		/// <p>The framework will play sound effects for some built in actions, such as
		/// clicking, but you may wish to play these effects in your widget,
		/// for instance, for internal navigation.
		/// <p>The sound effect will only be played if sound effects are enabled by the user, and
		/// <see cref="isSoundEffectsEnabled()">isSoundEffectsEnabled()</see>
		/// is true.
		/// </remarks>
		/// <param name="soundConstant">
		/// One of the constants defined in
		/// <see cref="SoundEffectConstants">SoundEffectConstants</see>
		/// </param>
		public virtual void playSoundEffect(int soundConstant)
		{
			if (mAttachInfo == null || mAttachInfo.mRootCallbacks == null || !isSoundEffectsEnabled
				())
			{
				return;
			}
			mAttachInfo.mRootCallbacks.playSoundEffect(soundConstant);
		}

		/// <summary>
		/// BZZZTT!!1!
		/// <p>Provide haptic feedback to the user for this view.
		/// </summary>
		/// <remarks>
		/// BZZZTT!!1!
		/// <p>Provide haptic feedback to the user for this view.
		/// <p>The framework will provide haptic feedback for some built in actions,
		/// such as long presses, but you may wish to provide feedback for your
		/// own widget.
		/// <p>The feedback will only be performed if
		/// <see cref="isHapticFeedbackEnabled()">isHapticFeedbackEnabled()</see>
		/// is true.
		/// </remarks>
		/// <param name="feedbackConstant">
		/// One of the constants defined in
		/// <see cref="HapticFeedbackConstants">HapticFeedbackConstants</see>
		/// </param>
		public virtual bool performHapticFeedback(int feedbackConstant)
		{
			return performHapticFeedback(feedbackConstant, 0);
		}

		/// <summary>
		/// BZZZTT!!1!
		/// <p>Like
		/// <see cref="performHapticFeedback(int)">performHapticFeedback(int)</see>
		/// , with additional options.
		/// </summary>
		/// <param name="feedbackConstant">
		/// One of the constants defined in
		/// <see cref="HapticFeedbackConstants">HapticFeedbackConstants</see>
		/// </param>
		/// <param name="flags">
		/// Additional flags as per
		/// <see cref="HapticFeedbackConstants">HapticFeedbackConstants</see>
		/// .
		/// </param>
		public virtual bool performHapticFeedback(int feedbackConstant, int flags)
		{
			if (mAttachInfo == null)
			{
				return false;
			}
			//noinspection SimplifiableIfStatement
			if ((flags & android.view.HapticFeedbackConstants.FLAG_IGNORE_VIEW_SETTING) == 0 
				&& !isHapticFeedbackEnabled())
			{
				return false;
			}
			return mAttachInfo.mRootCallbacks.performHapticFeedback(feedbackConstant, (flags 
				& android.view.HapticFeedbackConstants.FLAG_IGNORE_GLOBAL_SETTING) != 0);
		}

		/// <summary>Request that the visibility of the status bar be changed.</summary>
		/// <remarks>Request that the visibility of the status bar be changed.</remarks>
		/// <param name="visibility">
		/// Bitwise-or of flags
		/// <see cref="SYSTEM_UI_FLAG_LOW_PROFILE">SYSTEM_UI_FLAG_LOW_PROFILE</see>
		/// or
		/// <see cref="SYSTEM_UI_FLAG_HIDE_NAVIGATION">SYSTEM_UI_FLAG_HIDE_NAVIGATION</see>
		/// .
		/// </param>
		public virtual void setSystemUiVisibility(int visibility)
		{
			if (visibility != mSystemUiVisibility)
			{
				mSystemUiVisibility = visibility;
				if (mParent != null && mAttachInfo != null && !mAttachInfo.mRecomputeGlobalAttributes)
				{
					mParent.recomputeViewAttributes(this);
				}
			}
		}

		/// <summary>Returns the status bar visibility that this view has requested.</summary>
		/// <remarks>Returns the status bar visibility that this view has requested.</remarks>
		/// <returns>
		/// Bitwise-or of flags
		/// <see cref="SYSTEM_UI_FLAG_LOW_PROFILE">SYSTEM_UI_FLAG_LOW_PROFILE</see>
		/// or
		/// <see cref="SYSTEM_UI_FLAG_HIDE_NAVIGATION">SYSTEM_UI_FLAG_HIDE_NAVIGATION</see>
		/// .
		/// </returns>
		public virtual int getSystemUiVisibility()
		{
			return mSystemUiVisibility;
		}

		/// <summary>Set a listener to receive callbacks when the visibility of the system bar changes.
		/// 	</summary>
		/// <remarks>Set a listener to receive callbacks when the visibility of the system bar changes.
		/// 	</remarks>
		/// <param name="l">
		/// The
		/// <see cref="OnSystemUiVisibilityChangeListener">OnSystemUiVisibilityChangeListener
		/// 	</see>
		/// to receive callbacks.
		/// </param>
		public virtual void setOnSystemUiVisibilityChangeListener(android.view.View.OnSystemUiVisibilityChangeListener
			 l)
		{
			mOnSystemUiVisibilityChangeListener = l;
			if (mParent != null && mAttachInfo != null && !mAttachInfo.mRecomputeGlobalAttributes)
			{
				mParent.recomputeViewAttributes(this);
			}
		}

		/// <summary>
		/// Dispatch callbacks to
		/// <see cref="setOnSystemUiVisibilityChangeListener(OnSystemUiVisibilityChangeListener)
		/// 	">setOnSystemUiVisibilityChangeListener(OnSystemUiVisibilityChangeListener)</see>
		/// down
		/// the view hierarchy.
		/// </summary>
		public virtual void dispatchSystemUiVisibilityChanged(int visibility)
		{
			if (mOnSystemUiVisibilityChangeListener != null)
			{
				mOnSystemUiVisibilityChangeListener.onSystemUiVisibilityChange(visibility & PUBLIC_STATUS_BAR_VISIBILITY_MASK
					);
			}
		}

		internal virtual void updateLocalSystemUiVisibility(int localValue, int localChanges
			)
		{
			int val = (mSystemUiVisibility & ~localChanges) | (localValue & localChanges);
			if (val != mSystemUiVisibility)
			{
				setSystemUiVisibility(val);
			}
		}

		/// <summary>
		/// Creates an image that the system displays during the drag and drop
		/// operation.
		/// </summary>
		/// <remarks>
		/// Creates an image that the system displays during the drag and drop
		/// operation. This is called a &quot;drag shadow&quot;. The default implementation
		/// for a DragShadowBuilder based on a View returns an image that has exactly the same
		/// appearance as the given View. The default also positions the center of the drag shadow
		/// directly under the touch point. If no View is provided (the constructor with no parameters
		/// is used), and
		/// <see cref="onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)
		/// 	">onProvideShadowMetrics()</see>
		/// and
		/// <see cref="onDrawShadow(android.graphics.Canvas)">onDrawShadow()</see>
		/// are not overriden, then the
		/// default is an invisible drag shadow.
		/// <p>
		/// You are not required to use the View you provide to the constructor as the basis of the
		/// drag shadow. The
		/// <see cref="onDrawShadow(android.graphics.Canvas)">onDrawShadow()</see>
		/// method allows you to draw
		/// anything you want as the drag shadow.
		/// </p>
		/// <p>
		/// You pass a DragShadowBuilder object to the system when you start the drag. The system
		/// calls
		/// <see cref="onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)
		/// 	">onProvideShadowMetrics()</see>
		/// to get the
		/// size and position of the drag shadow. It uses this data to construct a
		/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
		/// object, then it calls
		/// <see cref="onDrawShadow(android.graphics.Canvas)">onDrawShadow()</see>
		/// so that your application can draw the shadow image in the Canvas.
		/// </p>
		/// <div class="special reference">
		/// <h3>Developer Guides</h3>
		/// <p>For a guide to implementing drag and drop features, read the
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/ui/drag-drop.html"&gt;Drag and Drop</a> developer guide.</p>
		/// </div>
		/// </remarks>
		public class DragShadowBuilder
		{
			private readonly java.lang.@ref.WeakReference<android.view.View> mView;

			/// <summary>Constructs a shadow image builder based on a View.</summary>
			/// <remarks>
			/// Constructs a shadow image builder based on a View. By default, the resulting drag
			/// shadow will have the same appearance and dimensions as the View, with the touch point
			/// over the center of the View.
			/// </remarks>
			/// <param name="view">A View. Any View in scope can be used.</param>
			public DragShadowBuilder(android.view.View view)
			{
				mView = new java.lang.@ref.WeakReference<android.view.View>(view);
			}

			/// <summary>Construct a shadow builder object with no associated View.</summary>
			/// <remarks>
			/// Construct a shadow builder object with no associated View.  This
			/// constructor variant is only useful when the
			/// <see cref="onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)
			/// 	">onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)</see>
			/// and
			/// <see cref="onDrawShadow(android.graphics.Canvas)">onDrawShadow(android.graphics.Canvas)
			/// 	</see>
			/// methods are also overridden in order
			/// to supply the drag shadow's dimensions and appearance without
			/// reference to any View object. If they are not overridden, then the result is an
			/// invisible drag shadow.
			/// </remarks>
			public DragShadowBuilder()
			{
				mView = new java.lang.@ref.WeakReference<android.view.View>(null);
			}

			/// <summary>
			/// Returns the View object that had been passed to the
			/// <see cref="DragShadowBuilder(View)">DragShadowBuilder(View)</see>
			/// constructor.  If that View parameter was
			/// <code>null</code>
			/// or if the
			/// <see cref="DragShadowBuilder()">DragShadowBuilder()</see>
			/// constructor was used to instantiate the builder object, this method will return
			/// null.
			/// </summary>
			/// <returns>The View object associate with this builder object.</returns>
			public android.view.View getView()
			{
				return mView.get();
			}

			/// <summary>Provides the metrics for the shadow image.</summary>
			/// <remarks>
			/// Provides the metrics for the shadow image. These include the dimensions of
			/// the shadow image, and the point within that shadow that should
			/// be centered under the touch location while dragging.
			/// <p>
			/// The default implementation sets the dimensions of the shadow to be the
			/// same as the dimensions of the View itself and centers the shadow under
			/// the touch point.
			/// </p>
			/// </remarks>
			/// <param name="shadowSize">
			/// A
			/// <see cref="android.graphics.Point">android.graphics.Point</see>
			/// containing the width and height
			/// of the shadow image. Your application must set
			/// <see cref="android.graphics.Point.x">android.graphics.Point.x</see>
			/// to the
			/// desired width and must set
			/// <see cref="android.graphics.Point.y">android.graphics.Point.y</see>
			/// to the desired height of the
			/// image.
			/// </param>
			/// <param name="shadowTouchPoint">
			/// A
			/// <see cref="android.graphics.Point">android.graphics.Point</see>
			/// for the position within the
			/// shadow image that should be underneath the touch point during the drag and drop
			/// operation. Your application must set
			/// <see cref="android.graphics.Point.x">android.graphics.Point.x</see>
			/// to the
			/// X coordinate and
			/// <see cref="android.graphics.Point.y">android.graphics.Point.y</see>
			/// to the Y coordinate of this position.
			/// </param>
			public virtual void onProvideShadowMetrics(android.graphics.Point shadowSize, android.graphics.Point
				 shadowTouchPoint)
			{
				android.view.View view = mView.get();
				if (view != null)
				{
					shadowSize.set(view.getWidth(), view.getHeight());
					shadowTouchPoint.set(shadowSize.x / 2, shadowSize.y / 2);
				}
				else
				{
					android.util.Log.e(android.view.View.VIEW_LOG_TAG, "Asked for drag thumb metrics but no view"
						);
				}
			}

			/// <summary>Draws the shadow image.</summary>
			/// <remarks>
			/// Draws the shadow image. The system creates the
			/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
			/// object
			/// based on the dimensions it received from the
			/// <see cref="onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)
			/// 	">onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)</see>
			/// callback.
			/// </remarks>
			/// <param name="canvas">
			/// A
			/// <see cref="android.graphics.Canvas">android.graphics.Canvas</see>
			/// object in which to draw the shadow image.
			/// </param>
			public virtual void onDrawShadow(android.graphics.Canvas canvas)
			{
				android.view.View view = mView.get();
				if (view != null)
				{
					view.draw(canvas);
				}
				else
				{
					android.util.Log.e(android.view.View.VIEW_LOG_TAG, "Asked to draw drag shadow but no view"
						);
				}
			}
		}

		/// <summary>Starts a drag and drop operation.</summary>
		/// <remarks>
		/// Starts a drag and drop operation. When your application calls this method, it passes a
		/// <see cref="DragShadowBuilder">DragShadowBuilder</see>
		/// object to the system. The
		/// system calls this object's
		/// <see cref="DragShadowBuilder.onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)
		/// 	">DragShadowBuilder.onProvideShadowMetrics(android.graphics.Point, android.graphics.Point)
		/// 	</see>
		/// to get metrics for the drag shadow, and then calls the object's
		/// <see cref="DragShadowBuilder.onDrawShadow(android.graphics.Canvas)">DragShadowBuilder.onDrawShadow(android.graphics.Canvas)
		/// 	</see>
		/// to draw the drag shadow itself.
		/// <p>
		/// Once the system has the drag shadow, it begins the drag and drop operation by sending
		/// drag events to all the View objects in your application that are currently visible. It does
		/// this either by calling the View object's drag listener (an implementation of
		/// <see cref="OnDragListener.onDrag(View, DragEvent)">onDrag()</see>
		/// or by calling the
		/// View object's
		/// <see cref="onDragEvent(DragEvent)">onDragEvent()</see>
		/// method.
		/// Both are passed a
		/// <see cref="DragEvent">DragEvent</see>
		/// object that has a
		/// <see cref="DragEvent.getAction()">DragEvent.getAction()</see>
		/// value of
		/// <see cref="DragEvent.ACTION_DRAG_STARTED">DragEvent.ACTION_DRAG_STARTED</see>
		/// .
		/// </p>
		/// <p>
		/// Your application can invoke startDrag() on any attached View object. The View object does not
		/// need to be the one used in
		/// <see cref="DragShadowBuilder">DragShadowBuilder</see>
		/// , nor does it need to
		/// be related to the View the user selected for dragging.
		/// </p>
		/// </remarks>
		/// <param name="data">
		/// A
		/// <see cref="android.content.ClipData">android.content.ClipData</see>
		/// object pointing to the data to be
		/// transferred by the drag and drop operation.
		/// </param>
		/// <param name="shadowBuilder">
		/// A
		/// <see cref="DragShadowBuilder">DragShadowBuilder</see>
		/// object for building the
		/// drag shadow.
		/// </param>
		/// <param name="myLocalState">
		/// An
		/// <see cref="object">object</see>
		/// containing local data about the drag and
		/// drop operation. This Object is put into every DragEvent object sent by the system during the
		/// current drag.
		/// <p>
		/// myLocalState is a lightweight mechanism for the sending information from the dragged View
		/// to the target Views. For example, it can contain flags that differentiate between a
		/// a copy operation and a move operation.
		/// </p>
		/// </param>
		/// <param name="flags">
		/// Flags that control the drag and drop operation. No flags are currently defined,
		/// so the parameter should be set to 0.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the method completes successfully, or
		/// <code>false</code>
		/// if it fails anywhere. Returning
		/// <code>false</code>
		/// means the system was unable to
		/// do a drag, and so no drag operation is in progress.
		/// </returns>
		public bool startDrag(android.content.ClipData data, android.view.View.DragShadowBuilder
			 shadowBuilder, object myLocalState, int flags)
		{
			bool okay = false;
			android.graphics.Point shadowSize = new android.graphics.Point();
			android.graphics.Point shadowTouchPoint = new android.graphics.Point();
			shadowBuilder.onProvideShadowMetrics(shadowSize, shadowTouchPoint);
			if ((shadowSize.x < 0) || (shadowSize.y < 0) || (shadowTouchPoint.x < 0) || (shadowTouchPoint
				.y < 0))
			{
				throw new System.InvalidOperationException("Drag shadow dimensions must not be negative"
					);
			}
			android.view.Surface surface = new android.view.Surface();
			try
			{
				android.os.IBinder token = mAttachInfo.mSession.prepareDrag(mAttachInfo.mWindow, 
					flags, shadowSize.x, shadowSize.y, surface);
				if (token != null)
				{
					android.graphics.Canvas canvas = surface.lockCanvas(null);
					try
					{
						canvas.drawColor(0, android.graphics.PorterDuff.Mode.CLEAR);
						shadowBuilder.onDrawShadow(canvas);
					}
					finally
					{
						surface.unlockCanvasAndPost(canvas);
					}
					android.view.ViewRootImpl root = getViewRootImpl();
					// Cache the local state object for delivery with DragEvents
					root.setLocalDragState(myLocalState);
					// repurpose 'shadowSize' for the last touch point
					root.getLastTouchPoint(shadowSize);
					okay = mAttachInfo.mSession.performDrag(mAttachInfo.mWindow, token, shadowSize.x, 
						shadowSize.y, shadowTouchPoint.x, shadowTouchPoint.y, data);
					// Off and running!  Release our local surface instance; the drag
					// shadow surface is now managed by the system process.
					surface.release();
				}
			}
			catch (System.Exception e)
			{
				android.util.Log.e(VIEW_LOG_TAG, "Unable to initiate drag", e);
				surface.destroy();
			}
			return okay;
		}

		/// <summary>
		/// Handles drag events sent by the system following a call to
		/// <see cref="startDrag(android.content.ClipData, DragShadowBuilder, object, int)">startDrag()
		/// 	</see>
		/// .
		/// <p>
		/// When the system calls this method, it passes a
		/// <see cref="DragEvent">DragEvent</see>
		/// object. A call to
		/// <see cref="DragEvent.getAction()">DragEvent.getAction()</see>
		/// returns one of the action type constants defined
		/// in DragEvent. The method uses these to determine what is happening in the drag and drop
		/// operation.
		/// </summary>
		/// <param name="event">
		/// The
		/// <see cref="DragEvent">DragEvent</see>
		/// sent by the system.
		/// The
		/// <see cref="DragEvent.getAction()">DragEvent.getAction()</see>
		/// method returns an action type constant defined
		/// in DragEvent, indicating the type of drag event represented by this object.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the method was successful, otherwise
		/// <code>false</code>
		/// .
		/// <p>
		/// The method should return
		/// <code>true</code>
		/// in response to an action type of
		/// <see cref="DragEvent.ACTION_DRAG_STARTED">DragEvent.ACTION_DRAG_STARTED</see>
		/// to receive drag events for the current
		/// operation.
		/// </p>
		/// <p>
		/// The method should also return
		/// <code>true</code>
		/// in response to an action type of
		/// <see cref="DragEvent.ACTION_DROP">DragEvent.ACTION_DROP</see>
		/// if it consumed the drop, or
		/// <code>false</code>
		/// if it didn't.
		/// </p>
		/// </returns>
		public virtual bool onDragEvent(android.view.DragEvent @event)
		{
			return false;
		}

		/// <summary>Detects if this View is enabled and has a drag event listener.</summary>
		/// <remarks>
		/// Detects if this View is enabled and has a drag event listener.
		/// If both are true, then it calls the drag event listener with the
		/// <see cref="DragEvent">DragEvent</see>
		/// it received. If the drag event listener returns
		/// <code>true</code>
		/// , then dispatchDragEvent() returns
		/// <code>true</code>
		/// .
		/// <p>
		/// For all other cases, the method calls the
		/// <see cref="onDragEvent(DragEvent)">onDragEvent()</see>
		/// drag event handler
		/// method and returns its result.
		/// </p>
		/// <p>
		/// This ensures that a drag event is always consumed, even if the View does not have a drag
		/// event listener. However, if the View has a listener and the listener returns true, then
		/// onDragEvent() is not called.
		/// </p>
		/// </remarks>
		public virtual bool dispatchDragEvent(android.view.DragEvent @event)
		{
			//noinspection SimplifiableIfStatement
			if (mOnDragListener != null && (mViewFlags & ENABLED_MASK) == ENABLED && mOnDragListener
				.onDrag(this, @event))
			{
				return true;
			}
			return onDragEvent(@event);
		}

		internal virtual bool canAcceptDrag()
		{
			return (mPrivateFlags2 & DRAG_CAN_ACCEPT) != 0;
		}

		/// <summary>This needs to be a better API (NOT ON VIEW) before it is exposed.</summary>
		/// <remarks>
		/// This needs to be a better API (NOT ON VIEW) before it is exposed.  If
		/// it is ever exposed at all.
		/// </remarks>
		/// <hide></hide>
		public virtual void onCloseSystemDialogs(string reason)
		{
		}

		/// <summary>
		/// Given a Drawable whose bounds have been set to draw into this view,
		/// update a Region being computed for
		/// <see cref="gatherTransparentRegion(android.graphics.Region)">gatherTransparentRegion(android.graphics.Region)
		/// 	</see>
		/// so
		/// that any non-transparent parts of the Drawable are removed from the
		/// given transparent region.
		/// </summary>
		/// <param name="dr">The Drawable whose transparency is to be applied to the region.</param>
		/// <param name="region">
		/// A Region holding the current transparency information,
		/// where any parts of the region that are set are considered to be
		/// transparent.  On return, this region will be modified to have the
		/// transparency information reduced by the corresponding parts of the
		/// Drawable that are not transparent.
		/// <hide></hide>
		/// </param>
		public virtual void applyDrawableToTransparentRegion(android.graphics.drawable.Drawable
			 dr, android.graphics.Region region)
		{
			android.graphics.Region r = dr.getTransparentRegion();
			android.graphics.Rect db = dr.getBounds();
			android.view.View.AttachInfo attachInfo = mAttachInfo;
			if (r != null && attachInfo != null)
			{
				int w = getRight() - getLeft();
				int h = getBottom() - getTop();
				if (db.left > 0)
				{
					//Log.i("VIEW", "Drawable left " + db.left + " > view 0");
					r.op(0, 0, db.left, h, android.graphics.Region.Op.UNION);
				}
				if (db.right < w)
				{
					//Log.i("VIEW", "Drawable right " + db.right + " < view " + w);
					r.op(db.right, 0, w, h, android.graphics.Region.Op.UNION);
				}
				if (db.top > 0)
				{
					//Log.i("VIEW", "Drawable top " + db.top + " > view 0");
					r.op(0, 0, w, db.top, android.graphics.Region.Op.UNION);
				}
				if (db.bottom < h)
				{
					//Log.i("VIEW", "Drawable bottom " + db.bottom + " < view " + h);
					r.op(0, db.bottom, w, h, android.graphics.Region.Op.UNION);
				}
				int[] location = attachInfo.mTransparentLocation;
				getLocationInWindow(location);
				r.translate(location[0], location[1]);
				region.op(r, android.graphics.Region.Op.INTERSECT);
			}
			else
			{
				region.op(db, android.graphics.Region.Op.DIFFERENCE);
			}
		}

		private void checkForLongClick(int delayOffset)
		{
			if ((mViewFlags & LONG_CLICKABLE) == LONG_CLICKABLE)
			{
				mHasPerformedLongPress = false;
				if (mPendingCheckForLongPress == null)
				{
					mPendingCheckForLongPress = new android.view.View.CheckForLongPress(this);
				}
				mPendingCheckForLongPress.rememberWindowAttachCount();
				postDelayed(mPendingCheckForLongPress, android.view.ViewConfiguration.getLongPressTimeout
					() - delayOffset);
			}
		}

		/// <summary>Inflate a view from an XML resource.</summary>
		/// <remarks>
		/// Inflate a view from an XML resource.  This convenience method wraps the
		/// <see cref="LayoutInflater">LayoutInflater</see>
		/// class, which provides a full range of options for view inflation.
		/// </remarks>
		/// <param name="context">The Context object for your activity or application.</param>
		/// <param name="resource">The resource ID to inflate</param>
		/// <param name="root">
		/// A view group that will be the parent.  Used to properly inflate the
		/// layout_* parameters.
		/// </param>
		/// <seealso cref="LayoutInflater">LayoutInflater</seealso>
		public static android.view.View inflate(android.content.Context context, int resource
			, android.view.ViewGroup root)
		{
			android.view.LayoutInflater factory = android.view.LayoutInflater.from(context);
			return factory.inflate(resource, root);
		}

		/// <summary>
		/// Scroll the view with standard behavior for scrolling beyond the normal
		/// content boundaries.
		/// </summary>
		/// <remarks>
		/// Scroll the view with standard behavior for scrolling beyond the normal
		/// content boundaries. Views that call this method should override
		/// <see cref="onOverScrolled(int, int, bool, bool)">onOverScrolled(int, int, bool, bool)
		/// 	</see>
		/// to respond to the
		/// results of an over-scroll operation.
		/// Views can use this method to handle any touch or fling-based scrolling.
		/// </remarks>
		/// <param name="deltaX">Change in X in pixels</param>
		/// <param name="deltaY">Change in Y in pixels</param>
		/// <param name="scrollX">Current X scroll value in pixels before applying deltaX</param>
		/// <param name="scrollY">Current Y scroll value in pixels before applying deltaY</param>
		/// <param name="scrollRangeX">Maximum content scroll range along the X axis</param>
		/// <param name="scrollRangeY">Maximum content scroll range along the Y axis</param>
		/// <param name="maxOverScrollX">
		/// Number of pixels to overscroll by in either direction
		/// along the X axis.
		/// </param>
		/// <param name="maxOverScrollY">
		/// Number of pixels to overscroll by in either direction
		/// along the Y axis.
		/// </param>
		/// <param name="isTouchEvent">true if this scroll operation is the result of a touch event.
		/// 	</param>
		/// <returns>
		/// true if scrolling was clamped to an over-scroll boundary along either
		/// axis, false otherwise.
		/// </returns>
		protected internal virtual bool overScrollBy(int deltaX, int deltaY, int scrollX, 
			int scrollY, int scrollRangeX, int scrollRangeY, int maxOverScrollX, int maxOverScrollY
			, bool isTouchEvent)
		{
			int overScrollMode = mOverScrollMode;
			bool canScrollHorizontal = computeHorizontalScrollRange() > computeHorizontalScrollExtent
				();
			bool canScrollVertical = computeVerticalScrollRange() > computeVerticalScrollExtent
				();
			bool overScrollHorizontal = overScrollMode == OVER_SCROLL_ALWAYS || (overScrollMode
				 == OVER_SCROLL_IF_CONTENT_SCROLLS && canScrollHorizontal);
			bool overScrollVertical = overScrollMode == OVER_SCROLL_ALWAYS || (overScrollMode
				 == OVER_SCROLL_IF_CONTENT_SCROLLS && canScrollVertical);
			int newScrollX = scrollX + deltaX;
			if (!overScrollHorizontal)
			{
				maxOverScrollX = 0;
			}
			int newScrollY = scrollY + deltaY;
			if (!overScrollVertical)
			{
				maxOverScrollY = 0;
			}
			// Clamp values if at the limits and record
			int left = -maxOverScrollX;
			int right = maxOverScrollX + scrollRangeX;
			int top = -maxOverScrollY;
			int bottom = maxOverScrollY + scrollRangeY;
			bool clampedX = false;
			if (newScrollX > right)
			{
				newScrollX = right;
				clampedX = true;
			}
			else
			{
				if (newScrollX < left)
				{
					newScrollX = left;
					clampedX = true;
				}
			}
			bool clampedY = false;
			if (newScrollY > bottom)
			{
				newScrollY = bottom;
				clampedY = true;
			}
			else
			{
				if (newScrollY < top)
				{
					newScrollY = top;
					clampedY = true;
				}
			}
			onOverScrolled(newScrollX, newScrollY, clampedX, clampedY);
			return clampedX || clampedY;
		}

		/// <summary>
		/// Called by
		/// <see cref="overScrollBy(int, int, int, int, int, int, int, int, bool)">overScrollBy(int, int, int, int, int, int, int, int, bool)
		/// 	</see>
		/// to
		/// respond to the results of an over-scroll operation.
		/// </summary>
		/// <param name="scrollX">New X scroll value in pixels</param>
		/// <param name="scrollY">New Y scroll value in pixels</param>
		/// <param name="clampedX">True if scrollX was clamped to an over-scroll boundary</param>
		/// <param name="clampedY">True if scrollY was clamped to an over-scroll boundary</param>
		protected internal virtual void onOverScrolled(int scrollX, int scrollY, bool clampedX
			, bool clampedY)
		{
		}

		// Intentionally empty.
		/// <summary>Returns the over-scroll mode for this view.</summary>
		/// <remarks>
		/// Returns the over-scroll mode for this view. The result will be
		/// one of
		/// <see cref="OVER_SCROLL_ALWAYS">OVER_SCROLL_ALWAYS</see>
		/// (default),
		/// <see cref="OVER_SCROLL_IF_CONTENT_SCROLLS">OVER_SCROLL_IF_CONTENT_SCROLLS</see>
		/// (allow over-scrolling only if the view content is larger than the container),
		/// or
		/// <see cref="OVER_SCROLL_NEVER">OVER_SCROLL_NEVER</see>
		/// .
		/// </remarks>
		/// <returns>This view's over-scroll mode.</returns>
		public virtual int getOverScrollMode()
		{
			return mOverScrollMode;
		}

		/// <summary>Set the over-scroll mode for this view.</summary>
		/// <remarks>
		/// Set the over-scroll mode for this view. Valid over-scroll modes are
		/// <see cref="OVER_SCROLL_ALWAYS">OVER_SCROLL_ALWAYS</see>
		/// (default),
		/// <see cref="OVER_SCROLL_IF_CONTENT_SCROLLS">OVER_SCROLL_IF_CONTENT_SCROLLS</see>
		/// (allow over-scrolling only if the view content is larger than the container),
		/// or
		/// <see cref="OVER_SCROLL_NEVER">OVER_SCROLL_NEVER</see>
		/// .
		/// Setting the over-scroll mode of a view will have an effect only if the
		/// view is capable of scrolling.
		/// </remarks>
		/// <param name="overScrollMode">The new over-scroll mode for this view.</param>
		public virtual void setOverScrollMode(int overScrollMode)
		{
			if (overScrollMode != OVER_SCROLL_ALWAYS && overScrollMode != OVER_SCROLL_IF_CONTENT_SCROLLS
				 && overScrollMode != OVER_SCROLL_NEVER)
			{
				throw new System.ArgumentException("Invalid overscroll mode " + overScrollMode);
			}
			mOverScrollMode = overScrollMode;
		}

		/// <summary>
		/// Gets a scale factor that determines the distance the view should scroll
		/// vertically in response to
		/// <see cref="MotionEvent.ACTION_SCROLL">MotionEvent.ACTION_SCROLL</see>
		/// .
		/// </summary>
		/// <returns>The vertical scroll scale factor.</returns>
		/// <hide></hide>
		protected internal virtual float getVerticalScrollFactor()
		{
			if (mVerticalScrollFactor == 0)
			{
				android.util.TypedValue outValue = new android.util.TypedValue();
				if (!mContext.getTheme().resolveAttribute(android.@internal.R.attr.listPreferredItemHeight
					, outValue, true))
				{
					throw new System.InvalidOperationException("Expected theme to define listPreferredItemHeight."
						);
				}
				mVerticalScrollFactor = outValue.getDimension(mContext.getResources().getDisplayMetrics
					());
			}
			return mVerticalScrollFactor;
		}

		/// <summary>
		/// Gets a scale factor that determines the distance the view should scroll
		/// horizontally in response to
		/// <see cref="MotionEvent.ACTION_SCROLL">MotionEvent.ACTION_SCROLL</see>
		/// .
		/// </summary>
		/// <returns>The horizontal scroll scale factor.</returns>
		/// <hide></hide>
		protected internal virtual float getHorizontalScrollFactor()
		{
			// TODO: Should use something else.
			return getVerticalScrollFactor();
		}

		/// <summary>
		/// Return the value specifying the text direction or policy that was set with
		/// <see cref="setTextDirection(int)">setTextDirection(int)</see>
		/// .
		/// </summary>
		/// <returns>
		/// the defined text direction. It can be one of:
		/// <see cref="TEXT_DIRECTION_INHERIT">TEXT_DIRECTION_INHERIT</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_FIRST_STRONG">TEXT_DIRECTION_FIRST_STRONG</see>
		/// <see cref="TEXT_DIRECTION_ANY_RTL">TEXT_DIRECTION_ANY_RTL</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_LTR">TEXT_DIRECTION_LTR</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_RTL">TEXT_DIRECTION_RTL</see>
		/// ,
		/// </returns>
		/// <hide></hide>
		public virtual int getTextDirection()
		{
			return mTextDirection;
		}

		/// <summary>Set the text direction.</summary>
		/// <remarks>Set the text direction.</remarks>
		/// <param name="textDirection">
		/// the direction to set. Should be one of:
		/// <see cref="TEXT_DIRECTION_INHERIT">TEXT_DIRECTION_INHERIT</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_FIRST_STRONG">TEXT_DIRECTION_FIRST_STRONG</see>
		/// <see cref="TEXT_DIRECTION_ANY_RTL">TEXT_DIRECTION_ANY_RTL</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_LTR">TEXT_DIRECTION_LTR</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_RTL">TEXT_DIRECTION_RTL</see>
		/// ,
		/// </param>
		/// <hide></hide>
		public virtual void setTextDirection(int textDirection)
		{
			if (textDirection != mTextDirection)
			{
				mTextDirection = textDirection;
				resetResolvedTextDirection();
				requestLayout();
			}
		}

		/// <summary>Return the resolved text direction.</summary>
		/// <remarks>Return the resolved text direction.</remarks>
		/// <returns>
		/// the resolved text direction. Return one of:
		/// <see cref="TEXT_DIRECTION_FIRST_STRONG">TEXT_DIRECTION_FIRST_STRONG</see>
		/// <see cref="TEXT_DIRECTION_ANY_RTL">TEXT_DIRECTION_ANY_RTL</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_LTR">TEXT_DIRECTION_LTR</see>
		/// ,
		/// <see cref="TEXT_DIRECTION_RTL">TEXT_DIRECTION_RTL</see>
		/// ,
		/// </returns>
		/// <hide></hide>
		public virtual int getResolvedTextDirection()
		{
			if (mResolvedTextDirection == TEXT_DIRECTION_INHERIT)
			{
				resolveTextDirection();
			}
			return mResolvedTextDirection;
		}

		/// <summary>Resolve the text direction.</summary>
		/// <remarks>Resolve the text direction.</remarks>
		/// <hide></hide>
		protected internal virtual void resolveTextDirection()
		{
			if (mTextDirection != TEXT_DIRECTION_INHERIT)
			{
				mResolvedTextDirection = mTextDirection;
				return;
			}
			if (mParent != null && mParent is android.view.ViewGroup)
			{
				mResolvedTextDirection = ((android.view.ViewGroup)mParent).getResolvedTextDirection
					();
				return;
			}
			mResolvedTextDirection = TEXT_DIRECTION_FIRST_STRONG;
		}

		/// <summary>Reset resolved text direction.</summary>
		/// <remarks>Reset resolved text direction. Will be resolved during a call to getResolvedTextDirection().
		/// 	</remarks>
		/// <hide></hide>
		protected internal virtual void resetResolvedTextDirection()
		{
			mResolvedTextDirection = TEXT_DIRECTION_INHERIT;
		}

		private sealed class _FloatProperty_13679 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13679(string baseArg1) : base(baseArg1)
			{
			}

			//
			// Properties
			//
			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setAlpha(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getAlpha();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>alpha</code> functionality handled by the
		/// <see cref="setAlpha(float)">setAlpha(float)</see>
		/// and
		/// <see cref="getAlpha()">getAlpha()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> ALPHA = new _FloatProperty_13679
			("alpha");

		private sealed class _FloatProperty_13695 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13695(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setTranslationX(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getTranslationX();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>translationX</code> functionality handled by the
		/// <see cref="setTranslationX(float)">setTranslationX(float)</see>
		/// and
		/// <see cref="getTranslationX()">getTranslationX()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> TRANSLATION_X = new 
			_FloatProperty_13695("translationX");

		private sealed class _FloatProperty_13711 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13711(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setTranslationY(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getTranslationY();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>translationY</code> functionality handled by the
		/// <see cref="setTranslationY(float)">setTranslationY(float)</see>
		/// and
		/// <see cref="getTranslationY()">getTranslationY()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> TRANSLATION_Y = new 
			_FloatProperty_13711("translationY");

		private sealed class _FloatProperty_13727 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13727(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setX(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getX();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>x</code> functionality handled by the
		/// <see cref="setX(float)">setX(float)</see>
		/// and
		/// <see cref="getX()">getX()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> X = new _FloatProperty_13727
			("x");

		private sealed class _FloatProperty_13743 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13743(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setY(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getY();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>y</code> functionality handled by the
		/// <see cref="setY(float)">setY(float)</see>
		/// and
		/// <see cref="getY()">getY()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> Y = new _FloatProperty_13743
			("y");

		private sealed class _FloatProperty_13759 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13759(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setRotation(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getRotation();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>rotation</code> functionality handled by the
		/// <see cref="setRotation(float)">setRotation(float)</see>
		/// and
		/// <see cref="getRotation()">getRotation()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> ROTATION = new _FloatProperty_13759
			("rotation");

		private sealed class _FloatProperty_13775 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13775(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setRotationX(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getRotationX();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>rotationX</code> functionality handled by the
		/// <see cref="setRotationX(float)">setRotationX(float)</see>
		/// and
		/// <see cref="getRotationX()">getRotationX()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> ROTATION_X = new _FloatProperty_13775
			("rotationX");

		private sealed class _FloatProperty_13791 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13791(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setRotationY(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getRotationY();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>rotationY</code> functionality handled by the
		/// <see cref="setRotationY(float)">setRotationY(float)</see>
		/// and
		/// <see cref="getRotationY()">getRotationY()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> ROTATION_Y = new _FloatProperty_13791
			("rotationY");

		private sealed class _FloatProperty_13807 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13807(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setScaleX(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getScaleX();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>scaleX</code> functionality handled by the
		/// <see cref="setScaleX(float)">setScaleX(float)</see>
		/// and
		/// <see cref="getScaleX()">getScaleX()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> SCALE_X = new _FloatProperty_13807
			("scaleX");

		private sealed class _FloatProperty_13823 : android.util.FloatProperty<android.view.View
			>
		{
			public _FloatProperty_13823(string baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.OverridesMethod(@"android.util.FloatProperty")]
			public override void setValue(android.view.View @object, float value)
			{
				@object.setScaleY(value);
			}

			[Sharpen.OverridesMethod(@"android.util.Property")]
			public override float get(android.view.View @object)
			{
				return @object.getScaleY();
			}
		}

		/// <summary>
		/// A Property wrapper around the <code>scaleY</code> functionality handled by the
		/// <see cref="setScaleY(float)">setScaleY(float)</see>
		/// and
		/// <see cref="getScaleY()">getScaleY()</see>
		/// methods.
		/// </summary>
		public static android.util.Property<android.view.View, float> SCALE_Y = new _FloatProperty_13823
			("scaleY");

		/// <summary>A MeasureSpec encapsulates the layout requirements passed from parent to child.
		/// 	</summary>
		/// <remarks>
		/// A MeasureSpec encapsulates the layout requirements passed from parent to child.
		/// Each MeasureSpec represents a requirement for either the width or the height.
		/// A MeasureSpec is comprised of a size and a mode. There are three possible
		/// modes:
		/// <dl>
		/// <dt>UNSPECIFIED</dt>
		/// <dd>
		/// The parent has not imposed any constraint on the child. It can be whatever size
		/// it wants.
		/// </dd>
		/// <dt>EXACTLY</dt>
		/// <dd>
		/// The parent has determined an exact size for the child. The child is going to be
		/// given those bounds regardless of how big it wants to be.
		/// </dd>
		/// <dt>AT_MOST</dt>
		/// <dd>
		/// The child can be as large as it wants up to the specified size.
		/// </dd>
		/// </dl>
		/// MeasureSpecs are implemented as ints to reduce object allocation. This class
		/// is provided to pack and unpack the &lt;size, mode&gt; tuple into the int.
		/// </remarks>
		public class MeasureSpec
		{
			internal const int MODE_SHIFT = 30;

			internal const int MODE_MASK = unchecked((int)(0x3)) << MODE_SHIFT;

			/// <summary>
			/// Measure specification mode: The parent has not imposed any constraint
			/// on the child.
			/// </summary>
			/// <remarks>
			/// Measure specification mode: The parent has not imposed any constraint
			/// on the child. It can be whatever size it wants.
			/// </remarks>
			public const int UNSPECIFIED = 0 << MODE_SHIFT;

			/// <summary>
			/// Measure specification mode: The parent has determined an exact size
			/// for the child.
			/// </summary>
			/// <remarks>
			/// Measure specification mode: The parent has determined an exact size
			/// for the child. The child is going to be given those bounds regardless
			/// of how big it wants to be.
			/// </remarks>
			public const int EXACTLY = 1 << MODE_SHIFT;

			/// <summary>
			/// Measure specification mode: The child can be as large as it wants up
			/// to the specified size.
			/// </summary>
			/// <remarks>
			/// Measure specification mode: The child can be as large as it wants up
			/// to the specified size.
			/// </remarks>
			public const int AT_MOST = 2 << MODE_SHIFT;

			/// <summary>Creates a measure specification based on the supplied size and mode.</summary>
			/// <remarks>
			/// Creates a measure specification based on the supplied size and mode.
			/// The mode must always be one of the following:
			/// <ul>
			/// <li>
			/// <see cref="UNSPECIFIED">UNSPECIFIED</see>
			/// </li>
			/// <li>
			/// <see cref="EXACTLY">EXACTLY</see>
			/// </li>
			/// <li>
			/// <see cref="AT_MOST">AT_MOST</see>
			/// </li>
			/// </ul>
			/// </remarks>
			/// <param name="size">the size of the measure specification</param>
			/// <param name="mode">the mode of the measure specification</param>
			/// <returns>the measure specification based on size and mode</returns>
			public static int makeMeasureSpec(int size, int mode)
			{
				return size + mode;
			}

			/// <summary>Extracts the mode from the supplied measure specification.</summary>
			/// <remarks>Extracts the mode from the supplied measure specification.</remarks>
			/// <param name="measureSpec">the measure specification to extract the mode from</param>
			/// <returns>
			/// 
			/// <see cref="UNSPECIFIED">UNSPECIFIED</see>
			/// ,
			/// <see cref="AT_MOST">AT_MOST</see>
			/// or
			/// <see cref="EXACTLY">EXACTLY</see>
			/// </returns>
			public static int getMode(int measureSpec)
			{
				return (measureSpec & MODE_MASK);
			}

			/// <summary>Extracts the size from the supplied measure specification.</summary>
			/// <remarks>Extracts the size from the supplied measure specification.</remarks>
			/// <param name="measureSpec">the measure specification to extract the size from</param>
			/// <returns>the size in pixels defined in the supplied measure specification</returns>
			public static int getSize(int measureSpec)
			{
				return (measureSpec & ~MODE_MASK);
			}

			/// <summary>
			/// Returns a String representation of the specified measure
			/// specification.
			/// </summary>
			/// <remarks>
			/// Returns a String representation of the specified measure
			/// specification.
			/// </remarks>
			/// <param name="measureSpec">the measure specification to convert to a String</param>
			/// <returns>a String with the following format: "MeasureSpec: MODE SIZE"</returns>
			public static string toString(int measureSpec)
			{
				int mode = getMode(measureSpec);
				int size = getSize(measureSpec);
				java.lang.StringBuilder sb = new java.lang.StringBuilder("MeasureSpec: ");
				if (mode == UNSPECIFIED)
				{
					sb.append("UNSPECIFIED ");
				}
				else
				{
					if (mode == EXACTLY)
					{
						sb.append("EXACTLY ");
					}
					else
					{
						if (mode == AT_MOST)
						{
							sb.append("AT_MOST ");
						}
						else
						{
							sb.append(mode).append(" ");
						}
					}
				}
				sb.append(size);
				return sb.ToString();
			}
		}

		internal class CheckForLongPress : java.lang.Runnable
		{
			private int mOriginalWindowAttachCount;

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (this._enclosing.isPressed() && (this._enclosing.mParent != null) && this.mOriginalWindowAttachCount
					 == this._enclosing.mWindowAttachCount)
				{
					if (this._enclosing.performLongClick())
					{
						this._enclosing.mHasPerformedLongPress = true;
					}
				}
			}

			public virtual void rememberWindowAttachCount()
			{
				this.mOriginalWindowAttachCount = this._enclosing.mWindowAttachCount;
			}

			internal CheckForLongPress(View _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly View _enclosing;
		}

		private sealed class CheckForTap : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.mPrivateFlags &= ~android.view.View.PREPRESSED;
				this._enclosing.mPrivateFlags |= android.view.View.PRESSED;
				this._enclosing.refreshDrawableState();
				this._enclosing.checkForLongClick(android.view.ViewConfiguration.getTapTimeout());
			}

			internal CheckForTap(View _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly View _enclosing;
		}

		private sealed class PerformClick : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.performClick();
			}

			internal PerformClick(View _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly View _enclosing;
		}

		/// <hide></hide>
		public virtual void hackTurnOffWindowResizeAnim(bool off)
		{
			mAttachInfo.mTurnOffWindowResizeAnim = off;
		}

		/// <summary>
		/// This method returns a ViewPropertyAnimator object, which can be used to animate
		/// specific properties on this View.
		/// </summary>
		/// <remarks>
		/// This method returns a ViewPropertyAnimator object, which can be used to animate
		/// specific properties on this View.
		/// </remarks>
		/// <returns>ViewPropertyAnimator The ViewPropertyAnimator associated with this View.
		/// 	</returns>
		public virtual android.view.ViewPropertyAnimator animate()
		{
			if (mAnimator == null)
			{
				mAnimator = new android.view.ViewPropertyAnimator(this);
			}
			return mAnimator;
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a key event is
		/// dispatched to this view.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a key event is
		/// dispatched to this view. The callback will be invoked before the key
		/// event is given to the view.
		/// </remarks>
		public interface OnKeyListener
		{
			/// <summary>Called when a key is dispatched to a view.</summary>
			/// <remarks>
			/// Called when a key is dispatched to a view. This allows listeners to
			/// get a chance to respond before the target view.
			/// </remarks>
			/// <param name="v">The view the key has been dispatched to.</param>
			/// <param name="keyCode">The code for the physical key that was pressed</param>
			/// <param name="event">
			/// The KeyEvent object containing full information about
			/// the event.
			/// </param>
			/// <returns>True if the listener has consumed the event, false otherwise.</returns>
			bool onKey(android.view.View v, int keyCode, android.view.KeyEvent @event);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a touch event is
		/// dispatched to this view.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a touch event is
		/// dispatched to this view. The callback will be invoked before the touch
		/// event is given to the view.
		/// </remarks>
		public interface OnTouchListener
		{
			/// <summary>Called when a touch event is dispatched to a view.</summary>
			/// <remarks>
			/// Called when a touch event is dispatched to a view. This allows listeners to
			/// get a chance to respond before the target view.
			/// </remarks>
			/// <param name="v">The view the touch event has been dispatched to.</param>
			/// <param name="event">
			/// The MotionEvent object containing full information about
			/// the event.
			/// </param>
			/// <returns>True if the listener has consumed the event, false otherwise.</returns>
			bool onTouch(android.view.View v, android.view.MotionEvent @event);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a hover event is
		/// dispatched to this view.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a hover event is
		/// dispatched to this view. The callback will be invoked before the hover
		/// event is given to the view.
		/// </remarks>
		public interface OnHoverListener
		{
			/// <summary>Called when a hover event is dispatched to a view.</summary>
			/// <remarks>
			/// Called when a hover event is dispatched to a view. This allows listeners to
			/// get a chance to respond before the target view.
			/// </remarks>
			/// <param name="v">The view the hover event has been dispatched to.</param>
			/// <param name="event">
			/// The MotionEvent object containing full information about
			/// the event.
			/// </param>
			/// <returns>True if the listener has consumed the event, false otherwise.</returns>
			bool onHover(android.view.View v, android.view.MotionEvent @event);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a generic motion event is
		/// dispatched to this view.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a generic motion event is
		/// dispatched to this view. The callback will be invoked before the generic motion
		/// event is given to the view.
		/// </remarks>
		public interface OnGenericMotionListener
		{
			/// <summary>Called when a generic motion event is dispatched to a view.</summary>
			/// <remarks>
			/// Called when a generic motion event is dispatched to a view. This allows listeners to
			/// get a chance to respond before the target view.
			/// </remarks>
			/// <param name="v">The view the generic motion event has been dispatched to.</param>
			/// <param name="event">
			/// The MotionEvent object containing full information about
			/// the event.
			/// </param>
			/// <returns>True if the listener has consumed the event, false otherwise.</returns>
			bool onGenericMotion(android.view.View v, android.view.MotionEvent @event);
		}

		/// <summary>Interface definition for a callback to be invoked when a view has been clicked and held.
		/// 	</summary>
		/// <remarks>Interface definition for a callback to be invoked when a view has been clicked and held.
		/// 	</remarks>
		public interface OnLongClickListener
		{
			/// <summary>Called when a view has been clicked and held.</summary>
			/// <remarks>Called when a view has been clicked and held.</remarks>
			/// <param name="v">The view that was clicked and held.</param>
			/// <returns>true if the callback consumed the long click, false otherwise.</returns>
			bool onLongClick(android.view.View v);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a drag is being dispatched
		/// to this view.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a drag is being dispatched
		/// to this view.  The callback will be invoked before the hosting view's own
		/// onDrag(event) method.  If the listener wants to fall back to the hosting view's
		/// onDrag(event) behavior, it should return 'false' from this callback.
		/// <div class="special reference">
		/// <h3>Developer Guides</h3>
		/// <p>For a guide to implementing drag and drop features, read the
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/ui/drag-drop.html"&gt;Drag and Drop</a> developer guide.</p>
		/// </div>
		/// </remarks>
		public interface OnDragListener
		{
			/// <summary>Called when a drag event is dispatched to a view.</summary>
			/// <remarks>
			/// Called when a drag event is dispatched to a view. This allows listeners
			/// to get a chance to override base View behavior.
			/// </remarks>
			/// <param name="v">The View that received the drag event.</param>
			/// <param name="event">
			/// The
			/// <see cref="DragEvent">DragEvent</see>
			/// object for the drag event.
			/// </param>
			/// <returns>
			/// 
			/// <code>true</code>
			/// if the drag event was handled successfully, or
			/// <code>false</code>
			/// if the drag event was not handled. Note that
			/// <code>false</code>
			/// will trigger the View
			/// to call its
			/// <see cref="View.onDragEvent(DragEvent)">onDragEvent()</see>
			/// handler.
			/// </returns>
			bool onDrag(android.view.View v, android.view.DragEvent @event);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the focus state of
		/// a view changed.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the focus state of
		/// a view changed.
		/// </remarks>
		public interface OnFocusChangeListener
		{
			/// <summary>Called when the focus state of a view has changed.</summary>
			/// <remarks>Called when the focus state of a view has changed.</remarks>
			/// <param name="v">The view whose state has changed.</param>
			/// <param name="hasFocus">The new focus state of v.</param>
			void onFocusChange(android.view.View v, bool hasFocus);
		}

		/// <summary>Interface definition for a callback to be invoked when a view is clicked.
		/// 	</summary>
		/// <remarks>Interface definition for a callback to be invoked when a view is clicked.
		/// 	</remarks>
		public interface OnClickListener
		{
			/// <summary>Called when a view has been clicked.</summary>
			/// <remarks>Called when a view has been clicked.</remarks>
			/// <param name="v">The view that was clicked.</param>
			void onClick(android.view.View v);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the context menu
		/// for this view is being built.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the context menu
		/// for this view is being built.
		/// </remarks>
		public interface OnCreateContextMenuListener
		{
			/// <summary>Called when the context menu for this view is being built.</summary>
			/// <remarks>
			/// Called when the context menu for this view is being built. It is not
			/// safe to hold onto the menu after this method returns.
			/// </remarks>
			/// <param name="menu">The context menu that is being built</param>
			/// <param name="v">The view for which the context menu is being built</param>
			/// <param name="menuInfo">
			/// Extra information about the item for which the
			/// context menu should be shown. This information will vary
			/// depending on the class of v.
			/// </param>
			void onCreateContextMenu(android.view.ContextMenu menu, android.view.View v, android.view.ContextMenuClass
				.ContextMenuInfo menuInfo);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the status bar changes
		/// visibility.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the status bar changes
		/// visibility.  This reports <strong>global</strong> changes to the system UI
		/// state, not just what the application is requesting.
		/// </remarks>
		/// <seealso cref="View.setOnSystemUiVisibilityChangeListener(OnSystemUiVisibilityChangeListener)
		/// 	"></seealso>
		public interface OnSystemUiVisibilityChangeListener
		{
			/// <summary>
			/// Called when the status bar changes visibility because of a call to
			/// <see cref="View.setSystemUiVisibility(int)">View.setSystemUiVisibility(int)</see>
			/// .
			/// </summary>
			/// <param name="visibility">
			/// Bitwise-or of flags
			/// <see cref="View.SYSTEM_UI_FLAG_LOW_PROFILE">View.SYSTEM_UI_FLAG_LOW_PROFILE</see>
			/// or
			/// <see cref="View.SYSTEM_UI_FLAG_HIDE_NAVIGATION">View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
			/// 	</see>
			/// .  This tells you the
			/// <strong>global</strong> state of the UI visibility flags, not what your
			/// app is currently applying.
			/// </param>
			void onSystemUiVisibilityChange(int visibility);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when this view is attached
		/// or detached from its window.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when this view is attached
		/// or detached from its window.
		/// </remarks>
		public interface OnAttachStateChangeListener
		{
			/// <summary>Called when the view is attached to a window.</summary>
			/// <remarks>Called when the view is attached to a window.</remarks>
			/// <param name="v">The view that was attached</param>
			void onViewAttachedToWindow(android.view.View v);

			/// <summary>Called when the view is detached from a window.</summary>
			/// <remarks>Called when the view is detached from a window.</remarks>
			/// <param name="v">The view that was detached</param>
			void onViewDetachedFromWindow(android.view.View v);
		}

		private sealed class UnsetPressedState : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.setPressed(false);
			}

			internal UnsetPressedState(View _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly View _enclosing;
		}

		/// <summary>
		/// Base class for derived classes that want to save and restore their own
		/// state in
		/// <see cref="View.onSaveInstanceState()">View.onSaveInstanceState()</see>
		/// .
		/// </summary>
		public class BaseSavedState : android.view.AbsSavedState
		{
			/// <summary>Constructor used when reading from a parcel.</summary>
			/// <remarks>Constructor used when reading from a parcel. Reads the state of the superclass.
			/// 	</remarks>
			/// <param name="source"></param>
			public BaseSavedState(android.os.Parcel source) : base(source)
			{
			}

			/// <summary>Constructor called by derived classes when creating their SavedState objects
			/// 	</summary>
			/// <param name="superState">The state of the superclass of this view</param>
			public BaseSavedState(android.os.Parcelable superState) : base(superState)
			{
			}

			private sealed class _Creator_14227 : android.os.ParcelableClass.Creator<android.view.View
				.BaseSavedState>
			{
				public _Creator_14227()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.View.BaseSavedState createFromParcel(android.os.Parcel @in)
				{
					return new android.view.View.BaseSavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.View.BaseSavedState[] newArray(int size)
				{
					return new android.view.View.BaseSavedState[size];
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.view.View.BaseSavedState
				> CREATOR = new _Creator_14227();
		}

		/// <summary>
		/// A set of information given to a view when it is attached to its parent
		/// window.
		/// </summary>
		/// <remarks>
		/// A set of information given to a view when it is attached to its parent
		/// window.
		/// </remarks>
		internal partial class AttachInfo
		{
			internal interface Callbacks
			{
				void playSoundEffect(int effectId);

				bool performHapticFeedback(int effectId, bool always);
			}

			/// <summary>
			/// InvalidateInfo is used to post invalidate(int, int, int, int) messages
			/// to a Handler.
			/// </summary>
			/// <remarks>
			/// InvalidateInfo is used to post invalidate(int, int, int, int) messages
			/// to a Handler. This class contains the target (View) to invalidate and
			/// the coordinates of the dirty rectangle.
			/// For performance purposes, this class also implements a pool of up to
			/// POOL_LIMIT objects that get reused. This reduces memory allocations
			/// whenever possible.
			/// </remarks>
			internal class InvalidateInfo : android.util.Poolable<android.view.View.AttachInfo
				.InvalidateInfo>
			{
				internal const int POOL_LIMIT = 10;

				private sealed class _PoolableManager_14260 : android.util.PoolableManager<android.view.View.AttachInfo
					.InvalidateInfo>
				{
					public _PoolableManager_14260()
					{
					}

					[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
					public android.view.View.AttachInfo.InvalidateInfo newInstance()
					{
						return new android.view.View.AttachInfo.InvalidateInfo();
					}

					[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
					public void onAcquired(android.view.View.AttachInfo.InvalidateInfo element)
					{
					}

					[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
					public void onReleased(android.view.View.AttachInfo.InvalidateInfo element)
					{
						element.target = null;
					}
				}

				private static readonly android.util.Pool<android.view.View.AttachInfo.InvalidateInfo
					> sPool = null;

				private android.view.View.AttachInfo.InvalidateInfo mNext;

				private bool mIsPooled;

				internal android.view.View target;

				internal int left;

				internal int top;

				internal int right;

				internal int bottom;

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual void setNextPoolable(android.view.View.AttachInfo.InvalidateInfo element
					)
				{
					mNext = element;
				}

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual android.view.View.AttachInfo.InvalidateInfo getNextPoolable()
				{
					return mNext;
				}

				internal static android.view.View.AttachInfo.InvalidateInfo acquire()
				{
					return sPool.acquire();
				}

				internal virtual void release()
				{
					sPool.release(this);
				}

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual bool isPooled()
				{
					return mIsPooled;
				}

				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual void setPooled(bool isPooled_1)
				{
					mIsPooled = isPooled_1;
				}
			}

			internal readonly android.view.IWindowSession mSession;

			internal readonly android.view.IWindow mWindow;

			internal readonly android.os.IBinder mWindowToken;

			internal readonly android.view.View.AttachInfo.Callbacks mRootCallbacks;

			internal android.view.HardwareCanvas mHardwareCanvas;

			/// <summary>The top view of the hierarchy.</summary>
			/// <remarks>The top view of the hierarchy.</remarks>
			internal android.view.View mRootView;

			internal android.os.IBinder mPanelParentWindowToken;

			internal android.view.Surface mSurface;

			internal bool mHardwareAccelerated;

			internal bool mHardwareAccelerationRequested;

			internal android.view.HardwareRenderer mHardwareRenderer;

			/// <summary>Scale factor used by the compatibility mode</summary>
			internal float mApplicationScale;

			/// <summary>Indicates whether the application is in compatibility mode</summary>
			internal bool mScalingRequired;

			/// <summary>If set, ViewAncestor doesn't use its lame animation for when the window resizes.
			/// 	</summary>
			/// <remarks>If set, ViewAncestor doesn't use its lame animation for when the window resizes.
			/// 	</remarks>
			internal bool mTurnOffWindowResizeAnim;

			/// <summary>Left position of this view's window</summary>
			internal int mWindowLeft;

			/// <summary>Top position of this view's window</summary>
			internal int mWindowTop;

			/// <summary>Indicates whether views need to use 32-bit drawing caches</summary>
			internal bool mUse32BitDrawingCache;

			/// <summary>
			/// For windows that are full-screen but using insets to layout inside
			/// of the screen decorations, these are the current insets for the
			/// content of the window.
			/// </summary>
			/// <remarks>
			/// For windows that are full-screen but using insets to layout inside
			/// of the screen decorations, these are the current insets for the
			/// content of the window.
			/// </remarks>
			internal readonly android.graphics.Rect mContentInsets = new android.graphics.Rect
				();

			/// <summary>
			/// For windows that are full-screen but using insets to layout inside
			/// of the screen decorations, these are the current insets for the
			/// actual visible parts of the window.
			/// </summary>
			/// <remarks>
			/// For windows that are full-screen but using insets to layout inside
			/// of the screen decorations, these are the current insets for the
			/// actual visible parts of the window.
			/// </remarks>
			internal readonly android.graphics.Rect mVisibleInsets = new android.graphics.Rect
				();

			/// <summary>The internal insets given by this window.</summary>
			/// <remarks>
			/// The internal insets given by this window.  This value is
			/// supplied by the client (through
			/// <see cref="OnComputeInternalInsetsListener">OnComputeInternalInsetsListener</see>
			/// ) and will
			/// be given to the window manager when changed to be used in laying
			/// out windows behind it.
			/// </remarks>
			internal readonly android.view.ViewTreeObserver.InternalInsetsInfo mGivenInternalInsets
				 = new android.view.ViewTreeObserver.InternalInsetsInfo();

			/// <summary>
			/// All views in the window's hierarchy that serve as scroll containers,
			/// used to determine if the window can be resized or must be panned
			/// to adjust for a soft input area.
			/// </summary>
			/// <remarks>
			/// All views in the window's hierarchy that serve as scroll containers,
			/// used to determine if the window can be resized or must be panned
			/// to adjust for a soft input area.
			/// </remarks>
			internal readonly java.util.ArrayList<android.view.View> mScrollContainers = new 
				java.util.ArrayList<android.view.View>();

			internal readonly android.view.KeyEvent.DispatcherState mKeyDispatchState = new android.view.KeyEvent
				.DispatcherState();

			/// <summary>Indicates whether the view's window currently has the focus.</summary>
			/// <remarks>Indicates whether the view's window currently has the focus.</remarks>
			internal bool mHasWindowFocus;

			/// <summary>The current visibility of the window.</summary>
			/// <remarks>The current visibility of the window.</remarks>
			internal int mWindowVisibility;

			/// <summary>Indicates the time at which drawing started to occur.</summary>
			/// <remarks>Indicates the time at which drawing started to occur.</remarks>
			internal long mDrawingTime;

			/// <summary>Indicates whether or not ignoring the DIRTY_MASK flags.</summary>
			/// <remarks>Indicates whether or not ignoring the DIRTY_MASK flags.</remarks>
			internal bool mIgnoreDirtyState;

			/// <summary>
			/// This flag tracks when the mIgnoreDirtyState flag is set during draw(),
			/// to avoid clearing that flag prematurely.
			/// </summary>
			/// <remarks>
			/// This flag tracks when the mIgnoreDirtyState flag is set during draw(),
			/// to avoid clearing that flag prematurely.
			/// </remarks>
			internal bool mSetIgnoreDirtyState = false;

			/// <summary>Indicates whether the view's window is currently in touch mode.</summary>
			/// <remarks>Indicates whether the view's window is currently in touch mode.</remarks>
			internal bool mInTouchMode;

			/// <summary>
			/// Indicates that ViewAncestor should trigger a global layout change
			/// the next time it performs a traversal
			/// </summary>
			internal bool mRecomputeGlobalAttributes;

			/// <summary>Always report new attributes at next traversal.</summary>
			/// <remarks>Always report new attributes at next traversal.</remarks>
			internal bool mForceReportNewAttributes;

			/// <summary>Set during a traveral if any views want to keep the screen on.</summary>
			/// <remarks>Set during a traveral if any views want to keep the screen on.</remarks>
			internal bool mKeepScreenOn;

			/// <summary>Bitwise-or of all of the values that views have passed to setSystemUiVisibility().
			/// 	</summary>
			/// <remarks>Bitwise-or of all of the values that views have passed to setSystemUiVisibility().
			/// 	</remarks>
			internal int mSystemUiVisibility;

			/// <summary>
			/// True if a view in this hierarchy has an OnSystemUiVisibilityChangeListener
			/// attached.
			/// </summary>
			/// <remarks>
			/// True if a view in this hierarchy has an OnSystemUiVisibilityChangeListener
			/// attached.
			/// </remarks>
			internal bool mHasSystemUiListeners;

			/// <summary>Set if the visibility of any views has changed.</summary>
			/// <remarks>Set if the visibility of any views has changed.</remarks>
			internal bool mViewVisibilityChanged;

			/// <summary>Set to true if a view has been scrolled.</summary>
			/// <remarks>Set to true if a view has been scrolled.</remarks>
			internal bool mViewScrollChanged;

			/// <summary>
			/// Global to the view hierarchy used as a temporary for dealing with
			/// x/y points in the transparent region computations.
			/// </summary>
			/// <remarks>
			/// Global to the view hierarchy used as a temporary for dealing with
			/// x/y points in the transparent region computations.
			/// </remarks>
			internal readonly int[] mTransparentLocation = new int[2];

			/// <summary>
			/// Global to the view hierarchy used as a temporary for dealing with
			/// x/y points in the ViewGroup.invalidateChild implementation.
			/// </summary>
			/// <remarks>
			/// Global to the view hierarchy used as a temporary for dealing with
			/// x/y points in the ViewGroup.invalidateChild implementation.
			/// </remarks>
			internal readonly int[] mInvalidateChildLocation = new int[2];

			/// <summary>
			/// Global to the view hierarchy used as a temporary for dealing with
			/// x/y location when view is transformed.
			/// </summary>
			/// <remarks>
			/// Global to the view hierarchy used as a temporary for dealing with
			/// x/y location when view is transformed.
			/// </remarks>
			internal readonly float[] mTmpTransformLocation = new float[2];

			/// <summary>
			/// The view tree observer used to dispatch global events like
			/// layout, pre-draw, touch mode change, etc.
			/// </summary>
			/// <remarks>
			/// The view tree observer used to dispatch global events like
			/// layout, pre-draw, touch mode change, etc.
			/// </remarks>
			internal readonly android.view.ViewTreeObserver mTreeObserver = new android.view.ViewTreeObserver
				();

			/// <summary>A Canvas used by the view hierarchy to perform bitmap caching.</summary>
			/// <remarks>A Canvas used by the view hierarchy to perform bitmap caching.</remarks>
			internal android.graphics.Canvas mCanvas;

			/// <summary>
			/// A Handler supplied by a view's
			/// <see cref="ViewRootImpl">ViewRootImpl</see>
			/// . This
			/// handler can be used to pump events in the UI events queue.
			/// </summary>
			internal readonly android.os.Handler mHandler;

			/// <summary>Identifier for messages requesting the view to be invalidated.</summary>
			/// <remarks>
			/// Identifier for messages requesting the view to be invalidated.
			/// Such messages should be sent to
			/// <see cref="mHandler">mHandler</see>
			/// .
			/// </remarks>
			internal const int INVALIDATE_MSG = unchecked((int)(0x1));

			/// <summary>Identifier for messages requesting the view to invalidate a region.</summary>
			/// <remarks>
			/// Identifier for messages requesting the view to invalidate a region.
			/// Such messages should be sent to
			/// <see cref="mHandler">mHandler</see>
			/// .
			/// </remarks>
			internal const int INVALIDATE_RECT_MSG = unchecked((int)(0x2));

			/// <summary>
			/// Temporary for use in computing invalidate rectangles while
			/// calling up the hierarchy.
			/// </summary>
			/// <remarks>
			/// Temporary for use in computing invalidate rectangles while
			/// calling up the hierarchy.
			/// </remarks>
			internal readonly android.graphics.Rect mTmpInvalRect = new android.graphics.Rect
				();

			/// <summary>Temporary for use in computing hit areas with transformed views</summary>
			internal readonly android.graphics.RectF mTmpTransformRect = new android.graphics.RectF
				();

			/// <summary>Temporary list for use in collecting focusable descendents of a view.</summary>
			/// <remarks>Temporary list for use in collecting focusable descendents of a view.</remarks>
			internal readonly java.util.ArrayList<android.view.View> mFocusablesTempList = new 
				java.util.ArrayList<android.view.View>(24);

			/// <summary>The id of the window for accessibility purposes.</summary>
			/// <remarks>The id of the window for accessibility purposes.</remarks>
			internal int mAccessibilityWindowId = android.view.View.NO_ID;

			/// <summary>
			/// Creates a new set of attachment information with the specified
			/// events handler and thread.
			/// </summary>
			/// <remarks>
			/// Creates a new set of attachment information with the specified
			/// events handler and thread.
			/// </remarks>
			/// <param name="handler">the events handler the view must use</param>
			internal AttachInfo(android.view.IWindowSession session, android.view.IWindow window
				, android.os.Handler handler, android.view.View.AttachInfo.Callbacks effectPlayer
				)
			{
				mSession = session;
				mWindow = window;
				mWindowToken = window.asBinder();
				mHandler = handler;
				mRootCallbacks = effectPlayer;
			}
		}

		/// <summary>
		/// <p>ScrollabilityCache holds various fields used by a View when scrolling
		/// is supported.
		/// </summary>
		/// <remarks>
		/// <p>ScrollabilityCache holds various fields used by a View when scrolling
		/// is supported. This avoids keeping too many unused fields in most
		/// instances of View.</p>
		/// </remarks>
		private class ScrollabilityCache : java.lang.Runnable
		{
			/// <summary>Scrollbars are not visible</summary>
			public const int OFF = 0;

			/// <summary>Scrollbars are visible</summary>
			public const int ON = 1;

			/// <summary>Scrollbars are fading away</summary>
			public const int FADING = 2;

			public bool fadeScrollBars;

			public int fadingEdgeLength;

			public int scrollBarDefaultDelayBeforeFade;

			public int scrollBarFadeDuration;

			public int scrollBarSize;

			public android.widget.ScrollBarDrawable scrollBar;

			public float[] interpolatorValues;

			public android.view.View host;

			public readonly android.graphics.Paint paint;

			public readonly android.graphics.Matrix matrix;

			public android.graphics.Shader shader;

			public readonly android.graphics.Interpolator scrollBarInterpolator = new android.graphics.Interpolator
				(1, 2);

			internal static readonly float[] OPAQUE = new float[] { 255 };

			internal static readonly float[] TRANSPARENT = new float[] { 0.0f };

			/// <summary>When fading should start.</summary>
			/// <remarks>
			/// When fading should start. This time moves into the future every time
			/// a new scroll happens. Measured based on SystemClock.uptimeMillis()
			/// </remarks>
			public long fadeStartTime;

			/// <summary>The current state of the scrollbars: ON, OFF, or FADING</summary>
			public int state = OFF;

			internal int mLastColor;

			public ScrollabilityCache(android.view.ViewConfiguration configuration, android.view.View
				 host)
			{
				fadingEdgeLength = configuration.getScaledFadingEdgeLength();
				scrollBarSize = configuration.getScaledScrollBarSize();
				scrollBarDefaultDelayBeforeFade = android.view.ViewConfiguration.getScrollDefaultDelay
					();
				scrollBarFadeDuration = android.view.ViewConfiguration.getScrollBarFadeDuration();
				paint = new android.graphics.Paint();
				matrix = new android.graphics.Matrix();
				// use use a height of 1, and then wack the matrix each time we
				// actually use it.
				shader = new android.graphics.LinearGradient(0, 0, 0, 1, unchecked((int)(0xFF000000
					)), 0, android.graphics.Shader.TileMode.CLAMP);
				paint.setShader(shader);
				paint.setXfermode(new android.graphics.PorterDuffXfermode(android.graphics.PorterDuff.Mode
					.DST_OUT));
				this.host = host;
			}

			public virtual void setFadeColor(int color)
			{
				if (color != 0 && color != mLastColor)
				{
					mLastColor = color;
					color |= unchecked((int)(0xFF000000));
					shader = new android.graphics.LinearGradient(0, 0, 0, 1, color | unchecked((int)(
						0xFF000000)), color & unchecked((int)(0x00FFFFFF)), android.graphics.Shader.TileMode
						.CLAMP);
					paint.setShader(shader);
					// Restore the default transfer mode (src_over)
					paint.setXfermode(null);
				}
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				long now = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
				if (now >= fadeStartTime)
				{
					// the animation fades the scrollbars out by changing
					// the opacity (alpha) from fully opaque to fully
					// transparent
					int nextFrame = (int)now;
					int framesCount = 0;
					android.graphics.Interpolator interpolator = scrollBarInterpolator;
					// Start opaque
					interpolator.setKeyFrame(framesCount++, nextFrame, OPAQUE);
					// End transparent
					nextFrame += scrollBarFadeDuration;
					interpolator.setKeyFrame(framesCount, nextFrame, TRANSPARENT);
					state = FADING;
					// Kick off the fade animation
					host.invalidate(true);
				}
			}
		}

		/// <summary>
		/// Resuable callback for sending
		/// <see cref="android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED">android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED
		/// 	</see>
		/// accessibility event.
		/// </summary>
		private class SendViewScrolledAccessibilityEvent : java.lang.Runnable
		{
			public volatile bool mIsPending;

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent
					.TYPE_VIEW_SCROLLED);
				this.mIsPending = false;
			}

			internal SendViewScrolledAccessibilityEvent(View _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly View _enclosing;
		}

		/// <summary>
		/// <p>
		/// This class represents a delegate that can be registered in a
		/// <see cref="View">View</see>
		/// to enhance accessibility support via composition rather via inheritance.
		/// It is specifically targeted to widget developers that extend basic View
		/// classes i.e. classes in package android.view, that would like their
		/// applications to be backwards compatible.
		/// </p>
		/// <p>
		/// A scenario in which a developer would like to use an accessibility delegate
		/// is overriding a method introduced in a later API version then the minimal API
		/// version supported by the application. For example, the method
		/// <see cref="View.onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
		/// 	">View.onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
		/// 	</see>
		/// is not available
		/// in API version 4 when the accessibility APIs were first introduced. If a
		/// developer would like his application to run on API version 4 devices (assuming
		/// all other APIs used by the application are version 4 or lower) and take advantage
		/// of this method, instead of overriding the method which would break the application's
		/// backwards compatibility, he can override the corresponding method in this
		/// delegate and register the delegate in the target View if the API version of
		/// the system is high enough i.e. the API version is same or higher to the API
		/// version that introduced
		/// <see cref="View.onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
		/// 	">View.onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
		/// 	</see>
		/// .
		/// </p>
		/// <p>
		/// Here is an example implementation:
		/// </p>
		/// <code><pre><p>
		/// if (Build.VERSION.SDK_INT &gt;= 14) {
		/// // If the API version is equal of higher than the version in
		/// // which onInitializeAccessibilityNodeInfo was introduced we
		/// // register a delegate with a customized implementation.
		/// View view = findViewById(R.id.view_id);
		/// view.setAccessibilityDelegate(new AccessibilityDelegate() {
		/// public void onInitializeAccessibilityNodeInfo(View host,
		/// AccessibilityNodeInfo info) {
		/// // Let the default implementation populate the info.
		/// super.onInitializeAccessibilityNodeInfo(host, info);
		/// // Set some other information.
		/// info.setEnabled(host.isEnabled());
		/// }
		/// });
		/// }
		/// </code></pre></p>
		/// <p>
		/// This delegate contains methods that correspond to the accessibility methods
		/// in View. If a delegate has been specified the implementation in View hands
		/// off handling to the corresponding method in this delegate. The default
		/// implementation the delegate methods behaves exactly as the corresponding
		/// method in View for the case of no accessibility delegate been set. Hence,
		/// to customize the behavior of a View method, clients can override only the
		/// corresponding delegate method without altering the behavior of the rest
		/// accessibility related methods of the host view.
		/// </p>
		/// </summary>
		public class AccessibilityDelegate
		{
			/// <summary>Sends an accessibility event of the given type.</summary>
			/// <remarks>
			/// Sends an accessibility event of the given type. If accessibility is not
			/// enabled this method has no effect.
			/// <p>
			/// The default implementation behaves as
			/// <see cref="View.sendAccessibilityEvent(int)">sendAccessibilityEvent(int)</see>
			/// for the case of no accessibility delegate
			/// been set.
			/// </p>
			/// </remarks>
			/// <param name="host">The View hosting the delegate.</param>
			/// <param name="eventType">The type of the event to send.</param>
			/// <seealso cref="View.sendAccessibilityEvent(int)">sendAccessibilityEvent(int)</seealso>
			public virtual void sendAccessibilityEvent(android.view.View host, int eventType)
			{
				host.sendAccessibilityEventInternal(eventType);
			}

			/// <summary>Sends an accessibility event.</summary>
			/// <remarks>
			/// Sends an accessibility event. This method behaves exactly as
			/// <see cref="sendAccessibilityEvent(View, int)">sendAccessibilityEvent(View, int)</see>
			/// but takes as an argument an
			/// empty
			/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
			/// 	</see>
			/// and does not perform a check whether
			/// accessibility is enabled.
			/// <p>
			/// The default implementation behaves as
			/// <see cref="View.sendAccessibilityEventUnchecked(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</see>
			/// for
			/// the case of no accessibility delegate been set.
			/// </p>
			/// </remarks>
			/// <param name="host">The View hosting the delegate.</param>
			/// <param name="event">The event to send.</param>
			/// <seealso cref="View.sendAccessibilityEventUnchecked(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</seealso>
			public virtual void sendAccessibilityEventUnchecked(android.view.View host, android.view.accessibility.AccessibilityEvent
				 @event)
			{
				host.sendAccessibilityEventUncheckedInternal(@event);
			}

			/// <summary>
			/// Dispatches an
			/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
			/// 	</see>
			/// to the host
			/// <see cref="View">View</see>
			/// first and then
			/// to its children for adding their text content to the event.
			/// <p>
			/// The default implementation behaves as
			/// <see cref="View.dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</see>
			/// for
			/// the case of no accessibility delegate been set.
			/// </p>
			/// </summary>
			/// <param name="host">The View hosting the delegate.</param>
			/// <param name="event">The event.</param>
			/// <returns>True if the event population was completed.</returns>
			/// <seealso cref="View.dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</seealso>
			public virtual bool dispatchPopulateAccessibilityEvent(android.view.View host, android.view.accessibility.AccessibilityEvent
				 @event)
			{
				return host.dispatchPopulateAccessibilityEventInternal(@event);
			}

			/// <summary>
			/// Gives a chance to the host View to populate the accessibility event with its
			/// text content.
			/// </summary>
			/// <remarks>
			/// Gives a chance to the host View to populate the accessibility event with its
			/// text content.
			/// <p>
			/// The default implementation behaves as
			/// <see cref="View.onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</see>
			/// for
			/// the case of no accessibility delegate been set.
			/// </p>
			/// </remarks>
			/// <param name="host">The View hosting the delegate.</param>
			/// <param name="event">The accessibility event which to populate.</param>
			/// <seealso cref="View.onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</seealso>
			public virtual void onPopulateAccessibilityEvent(android.view.View host, android.view.accessibility.AccessibilityEvent
				 @event)
			{
				host.onPopulateAccessibilityEventInternal(@event);
			}

			/// <summary>
			/// Initializes an
			/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
			/// 	</see>
			/// with information about the
			/// the host View which is the event source.
			/// <p>
			/// The default implementation behaves as
			/// <see cref="View.onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</see>
			/// for
			/// the case of no accessibility delegate been set.
			/// </p>
			/// </summary>
			/// <param name="host">The View hosting the delegate.</param>
			/// <param name="event">The event to initialize.</param>
			/// <seealso cref="View.onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent)
			/// 	">AccessibilityEvent)</seealso>
			public virtual void onInitializeAccessibilityEvent(android.view.View host, android.view.accessibility.AccessibilityEvent
				 @event)
			{
				host.onInitializeAccessibilityEventInternal(@event);
			}

			/// <summary>
			/// Initializes an
			/// <see cref="android.view.accessibility.AccessibilityNodeInfo">android.view.accessibility.AccessibilityNodeInfo
			/// 	</see>
			/// with information about the host view.
			/// <p>
			/// The default implementation behaves as
			/// <see cref="View.onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
			/// 	">AccessibilityNodeInfo)</see>
			/// for
			/// the case of no accessibility delegate been set.
			/// </p>
			/// </summary>
			/// <param name="host">The View hosting the delegate.</param>
			/// <param name="info">The instance to initialize.</param>
			/// <seealso cref="View.onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo)
			/// 	">AccessibilityNodeInfo)</seealso>
			public virtual void onInitializeAccessibilityNodeInfo(android.view.View host, android.view.accessibility.AccessibilityNodeInfo
				 info)
			{
				host.onInitializeAccessibilityNodeInfoInternal(info);
			}

			/// <summary>
			/// Called when a child of the host View has requested sending an
			/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
			/// 	</see>
			/// and gives an opportunity to the parent (the host)
			/// to augment the event.
			/// <p>
			/// The default implementation behaves as
			/// <see cref="ViewGroup.onRequestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
			/// 	">ViewGroup#onRequestSendAccessibilityEvent(View, AccessibilityEvent)</see>
			/// for
			/// the case of no accessibility delegate been set.
			/// </p>
			/// </summary>
			/// <param name="host">The View hosting the delegate.</param>
			/// <param name="child">The child which requests sending the event.</param>
			/// <param name="event">The event to be sent.</param>
			/// <returns>True if the event should be sent</returns>
			/// <seealso cref="ViewGroup.onRequestSendAccessibilityEvent(View, android.view.accessibility.AccessibilityEvent)
			/// 	">ViewGroup#onRequestSendAccessibilityEvent(View, AccessibilityEvent)</seealso>
			public virtual bool onRequestSendAccessibilityEvent(android.view.ViewGroup host, 
				android.view.View child, android.view.accessibility.AccessibilityEvent @event)
			{
				return host.onRequestSendAccessibilityEventInternal(child, @event);
			}
		}
	}
}
