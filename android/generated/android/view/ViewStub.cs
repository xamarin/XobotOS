using Sharpen;

namespace android.view
{
	/// <summary>
	/// A ViewStub is an invisible, zero-sized View that can be used to lazily inflate
	/// layout resources at runtime.
	/// </summary>
	/// <remarks>
	/// A ViewStub is an invisible, zero-sized View that can be used to lazily inflate
	/// layout resources at runtime.
	/// When a ViewStub is made visible, or when
	/// <see cref="inflate()">inflate()</see>
	/// is invoked, the layout resource
	/// is inflated. The ViewStub then replaces itself in its parent with the inflated View or Views.
	/// Therefore, the ViewStub exists in the view hierarchy until
	/// <see cref="setVisibility(int)">setVisibility(int)</see>
	/// or
	/// <see cref="inflate()">inflate()</see>
	/// is invoked.
	/// The inflated View is added to the ViewStub's parent with the ViewStub's layout
	/// parameters. Similarly, you can define/override the inflate View's id by using the
	/// ViewStub's inflatedId property. For instance:
	/// <pre>
	/// &lt;ViewStub android:id="@+id/stub"
	/// android:inflatedId="@+id/subTree"
	/// android:layout="@layout/mySubTree"
	/// android:layout_width="120dip"
	/// android:layout_height="40dip" /&gt;
	/// </pre>
	/// The ViewStub thus defined can be found using the id "stub." After inflation of
	/// the layout resource "mySubTree," the ViewStub is removed from its parent. The
	/// View created by inflating the layout resource "mySubTree" can be found using the
	/// id "subTree," specified by the inflatedId property. The inflated View is finally
	/// assigned a width of 120dip and a height of 40dip.
	/// The preferred way to perform the inflation of the layout resource is the following:
	/// <pre>
	/// ViewStub stub = (ViewStub) findViewById(R.id.stub);
	/// View inflated = stub.inflate();
	/// </pre>
	/// When
	/// <see cref="inflate()">inflate()</see>
	/// is invoked, the ViewStub is replaced by the inflated View
	/// and the inflated View is returned. This lets applications get a reference to the
	/// inflated View without executing an extra findViewById().
	/// </remarks>
	/// <attr>ref android.R.styleable#ViewStub_inflatedId</attr>
	/// <attr>ref android.R.styleable#ViewStub_layout</attr>
	[Sharpen.Sharpened]
	public sealed class ViewStub : android.view.View
	{
		private int mLayoutResource = 0;

		private int mInflatedId;

		private java.lang.@ref.WeakReference<android.view.View> mInflatedViewRef;

		private android.view.ViewStub.OnInflateListener mInflateListener;

		public ViewStub(android.content.Context context)
		{
			initialize(context);
		}

		/// <summary>Creates a new ViewStub with the specified layout resource.</summary>
		/// <remarks>Creates a new ViewStub with the specified layout resource.</remarks>
		/// <param name="context">The application's environment.</param>
		/// <param name="layoutResource">The reference to a layout resource that will be inflated.
		/// 	</param>
		public ViewStub(android.content.Context context, int layoutResource)
		{
			mLayoutResource = layoutResource;
			initialize(context);
		}

		public ViewStub(android.content.Context context, android.util.AttributeSet attrs)
			 : this(context, attrs, 0)
		{
		}

		public ViewStub(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ViewStub, defStyle, 0);
			mInflatedId = a.getResourceId(android.@internal.R.styleable.ViewStub_inflatedId, 
				NO_ID);
			mLayoutResource = a.getResourceId(android.@internal.R.styleable.ViewStub_layout, 
				0);
			a.recycle();
			a = context.obtainStyledAttributes(attrs, android.@internal.R.styleable.View, defStyle
				, 0);
			mID = a.getResourceId(android.@internal.R.styleable.View_id, NO_ID);
			a.recycle();
			initialize(context);
		}

		private void initialize(android.content.Context context)
		{
			mContext = context;
			setVisibility(GONE);
			setWillNotDraw(true);
		}

		/// <summary>Returns the id taken by the inflated view.</summary>
		/// <remarks>
		/// Returns the id taken by the inflated view. If the inflated id is
		/// <see cref="View.NO_ID">View.NO_ID</see>
		/// , the inflated view keeps its original id.
		/// </remarks>
		/// <returns>
		/// A positive integer used to identify the inflated view or
		/// <see cref="View.NO_ID">View.NO_ID</see>
		/// if the inflated view should keep its id.
		/// </returns>
		/// <seealso cref="setInflatedId(int)">setInflatedId(int)</seealso>
		/// <attr>ref android.R.styleable#ViewStub_inflatedId</attr>
		public int getInflatedId()
		{
			return mInflatedId;
		}

		/// <summary>Defines the id taken by the inflated view.</summary>
		/// <remarks>
		/// Defines the id taken by the inflated view. If the inflated id is
		/// <see cref="View.NO_ID">View.NO_ID</see>
		/// , the inflated view keeps its original id.
		/// </remarks>
		/// <param name="inflatedId">
		/// A positive integer used to identify the inflated view or
		/// <see cref="View.NO_ID">View.NO_ID</see>
		/// if the inflated view should keep its id.
		/// </param>
		/// <seealso cref="getInflatedId()">getInflatedId()</seealso>
		/// <attr>ref android.R.styleable#ViewStub_inflatedId</attr>
		public void setInflatedId(int inflatedId)
		{
			mInflatedId = inflatedId;
		}

		/// <summary>
		/// Returns the layout resource that will be used by
		/// <see cref="setVisibility(int)">setVisibility(int)</see>
		/// or
		/// <see cref="inflate()">inflate()</see>
		/// to replace this StubbedView
		/// in its parent by another view.
		/// </summary>
		/// <returns>The layout resource identifier used to inflate the new View.</returns>
		/// <seealso cref="setLayoutResource(int)">setLayoutResource(int)</seealso>
		/// <seealso cref="setVisibility(int)">setVisibility(int)</seealso>
		/// <seealso cref="inflate()">inflate()</seealso>
		/// <attr>ref android.R.styleable#ViewStub_layout</attr>
		public int getLayoutResource()
		{
			return mLayoutResource;
		}

		/// <summary>
		/// Specifies the layout resource to inflate when this StubbedView becomes visible or invisible
		/// or when
		/// <see cref="inflate()">inflate()</see>
		/// is invoked. The View created by inflating the layout resource is
		/// used to replace this StubbedView in its parent.
		/// </summary>
		/// <param name="layoutResource">A valid layout resource identifier (different from 0.)
		/// 	</param>
		/// <seealso cref="getLayoutResource()">getLayoutResource()</seealso>
		/// <seealso cref="setVisibility(int)">setVisibility(int)</seealso>
		/// <seealso cref="inflate()">inflate()</seealso>
		/// <attr>ref android.R.styleable#ViewStub_layout</attr>
		public void setLayoutResource(int layoutResource)
		{
			mLayoutResource = layoutResource;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			setMeasuredDimension(0, 0);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
		}

		/// <summary>
		/// When visibility is set to
		/// <see cref="View.VISIBLE">View.VISIBLE</see>
		/// or
		/// <see cref="View.INVISIBLE">View.INVISIBLE</see>
		/// ,
		/// <see cref="inflate()">inflate()</see>
		/// is invoked and this StubbedView is replaced in its parent
		/// by the inflated layout resource.
		/// </summary>
		/// <param name="visibility">
		/// One of
		/// <see cref="View.VISIBLE">View.VISIBLE</see>
		/// ,
		/// <see cref="View.INVISIBLE">View.INVISIBLE</see>
		/// , or
		/// <see cref="View.GONE">View.GONE</see>
		/// .
		/// </param>
		/// <seealso cref="inflate()"></seealso>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setVisibility(int visibility)
		{
			if (mInflatedViewRef != null)
			{
				android.view.View view = mInflatedViewRef.get();
				if (view != null)
				{
					view.setVisibility(visibility);
				}
				else
				{
					throw new System.InvalidOperationException("setVisibility called on un-referenced view"
						);
				}
			}
			else
			{
				base.setVisibility(visibility);
				if (visibility == VISIBLE || visibility == INVISIBLE)
				{
					inflate();
				}
			}
		}

		/// <summary>
		/// Inflates the layout resource identified by
		/// <see cref="getLayoutResource()">getLayoutResource()</see>
		/// and replaces this StubbedView in its parent by the inflated layout resource.
		/// </summary>
		/// <returns>The inflated layout resource.</returns>
		public android.view.View inflate()
		{
			android.view.ViewParent viewParent = getParent();
			if (viewParent != null && viewParent is android.view.ViewGroup)
			{
				if (mLayoutResource != 0)
				{
					android.view.ViewGroup parent = (android.view.ViewGroup)viewParent;
					android.view.LayoutInflater factory = android.view.LayoutInflater.from(mContext);
					android.view.View view = factory.inflate(mLayoutResource, parent, false);
					if (mInflatedId != NO_ID)
					{
						view.setId(mInflatedId);
					}
					int index = parent.indexOfChild(this);
					parent.removeViewInLayout(this);
					android.view.ViewGroup.LayoutParams layoutParams = getLayoutParams();
					if (layoutParams != null)
					{
						parent.addView(view, index, layoutParams);
					}
					else
					{
						parent.addView(view, index);
					}
					mInflatedViewRef = new java.lang.@ref.WeakReference<android.view.View>(view);
					if (mInflateListener != null)
					{
						mInflateListener.onInflate(this, view);
					}
					return view;
				}
				else
				{
					throw new System.ArgumentException("ViewStub must have a valid layoutResource");
				}
			}
			else
			{
				throw new System.InvalidOperationException("ViewStub must have a non-null ViewGroup viewParent"
					);
			}
		}

		/// <summary>
		/// Specifies the inflate listener to be notified after this ViewStub successfully
		/// inflated its layout resource.
		/// </summary>
		/// <remarks>
		/// Specifies the inflate listener to be notified after this ViewStub successfully
		/// inflated its layout resource.
		/// </remarks>
		/// <param name="inflateListener">The OnInflateListener to notify of successful inflation.
		/// 	</param>
		/// <seealso cref="OnInflateListener">OnInflateListener</seealso>
		public void setOnInflateListener(android.view.ViewStub.OnInflateListener inflateListener
			)
		{
			mInflateListener = inflateListener;
		}

		/// <summary>
		/// Listener used to receive a notification after a ViewStub has successfully
		/// inflated its layout resource.
		/// </summary>
		/// <remarks>
		/// Listener used to receive a notification after a ViewStub has successfully
		/// inflated its layout resource.
		/// </remarks>
		/// <seealso cref="ViewStub.setOnInflateListener(OnInflateListener)"></seealso>
		public interface OnInflateListener
		{
			/// <summary>Invoked after a ViewStub successfully inflated its layout resource.</summary>
			/// <remarks>
			/// Invoked after a ViewStub successfully inflated its layout resource.
			/// This method is invoked after the inflated view was added to the
			/// hierarchy but before the layout pass.
			/// </remarks>
			/// <param name="stub">The ViewStub that initiated the inflation.</param>
			/// <param name="inflated">The inflated View.</param>
			void onInflate(android.view.ViewStub stub, android.view.View inflated);
		}
	}
}
