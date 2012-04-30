using Sharpen;

namespace android.widget
{
	/// <summary>A toast is a view containing a quick little message for the user.</summary>
	/// <remarks>
	/// A toast is a view containing a quick little message for the user.  The toast class
	/// helps you create and show those.
	/// <more></more>
	/// <p>
	/// When the view is shown to the user, appears as a floating view over the
	/// application.  It will never receive focus.  The user will probably be in the
	/// middle of typing something else.  The idea is to be as unobtrusive as
	/// possible, while still showing the user the information you want them to see.
	/// Two examples are the volume control, and the brief message saying that your
	/// settings have been saved.
	/// <p>
	/// The easiest way to use this class is to call one of the static methods that constructs
	/// everything you need and returns a new Toast object.
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about creating Toast notifications, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/notifiers/toasts.html"&gt;Toast Notifications</a> developer
	/// guide.</p>
	/// </div>
	/// </remarks>
	[Sharpen.Sharpened]
	public class Toast
	{
		internal const string TAG = "Toast";

		internal const bool localLOGV = false;

		/// <summary>Show the view or text notification for a short period of time.</summary>
		/// <remarks>
		/// Show the view or text notification for a short period of time.  This time
		/// could be user-definable.  This is the default.
		/// </remarks>
		/// <seealso cref="setDuration(int)">setDuration(int)</seealso>
		public const int LENGTH_SHORT = 0;

		/// <summary>Show the view or text notification for a long period of time.</summary>
		/// <remarks>
		/// Show the view or text notification for a long period of time.  This time
		/// could be user-definable.
		/// </remarks>
		/// <seealso cref="setDuration(int)">setDuration(int)</seealso>
		public const int LENGTH_LONG = 1;

		internal readonly android.content.Context mContext;

		private readonly android.widget.Toast.TN mTN;

		internal int mDuration;

		internal android.view.View mNextView;

		/// <summary>Construct an empty Toast object.</summary>
		/// <remarks>
		/// Construct an empty Toast object.  You must call
		/// <see cref="setView(android.view.View)">setView(android.view.View)</see>
		/// before you
		/// can call
		/// <see cref="show()">show()</see>
		/// .
		/// </remarks>
		/// <param name="context">
		/// The context to use.  Usually your
		/// <see cref="android.app.Application">android.app.Application</see>
		/// or
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// object.
		/// </param>
		public Toast(android.content.Context context)
		{
			mContext = context;
			mTN = new android.widget.Toast.TN();
			mTN.mY = context.getResources().getDimensionPixelSize(android.@internal.R.dimen.toast_y_offset
				);
		}

		/// <summary>Show the view for the specified duration.</summary>
		/// <remarks>Show the view for the specified duration.</remarks>
		public virtual void show()
		{
			if (mNextView == null)
			{
				throw new java.lang.RuntimeException("setView must have been called");
			}
			android.app.INotificationManager service = getService();
			string pkg = mContext.getPackageName();
			android.widget.Toast.TN tn = mTN;
			tn.mNextView = mNextView;
			try
			{
				service.enqueueToast(pkg, tn, mDuration);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Empty
		/// <summary>Close the view if it's showing, or don't show it if it isn't showing yet.
		/// 	</summary>
		/// <remarks>
		/// Close the view if it's showing, or don't show it if it isn't showing yet.
		/// You do not normally have to call this.  Normally view will disappear on its own
		/// after the appropriate duration.
		/// </remarks>
		public virtual void cancel()
		{
			mTN.hide();
		}

		// TODO this still needs to cancel the inflight notification if any
		/// <summary>Set the view to show.</summary>
		/// <remarks>Set the view to show.</remarks>
		/// <seealso cref="getView()">getView()</seealso>
		public virtual void setView(android.view.View view)
		{
			mNextView = view;
		}

		/// <summary>Return the view.</summary>
		/// <remarks>Return the view.</remarks>
		/// <seealso cref="setView(android.view.View)">setView(android.view.View)</seealso>
		public virtual android.view.View getView()
		{
			return mNextView;
		}

		/// <summary>Set how long to show the view for.</summary>
		/// <remarks>Set how long to show the view for.</remarks>
		/// <seealso cref="LENGTH_SHORT">LENGTH_SHORT</seealso>
		/// <seealso cref="LENGTH_LONG">LENGTH_LONG</seealso>
		public virtual void setDuration(int duration)
		{
			mDuration = duration;
		}

		/// <summary>Return the duration.</summary>
		/// <remarks>Return the duration.</remarks>
		/// <seealso cref="setDuration(int)">setDuration(int)</seealso>
		public virtual int getDuration()
		{
			return mDuration;
		}

		/// <summary>Set the margins of the view.</summary>
		/// <remarks>Set the margins of the view.</remarks>
		/// <param name="horizontalMargin">
		/// The horizontal margin, in percentage of the
		/// container width, between the container's edges and the
		/// notification
		/// </param>
		/// <param name="verticalMargin">
		/// The vertical margin, in percentage of the
		/// container height, between the container's edges and the
		/// notification
		/// </param>
		public virtual void setMargin(float horizontalMargin, float verticalMargin)
		{
			mTN.mHorizontalMargin = horizontalMargin;
			mTN.mVerticalMargin = verticalMargin;
		}

		/// <summary>Return the horizontal margin.</summary>
		/// <remarks>Return the horizontal margin.</remarks>
		public virtual float getHorizontalMargin()
		{
			return mTN.mHorizontalMargin;
		}

		/// <summary>Return the vertical margin.</summary>
		/// <remarks>Return the vertical margin.</remarks>
		public virtual float getVerticalMargin()
		{
			return mTN.mVerticalMargin;
		}

		/// <summary>Set the location at which the notification should appear on the screen.</summary>
		/// <remarks>Set the location at which the notification should appear on the screen.</remarks>
		/// <seealso cref="android.view.Gravity">android.view.Gravity</seealso>
		/// <seealso cref="getGravity()">getGravity()</seealso>
		public virtual void setGravity(int gravity, int xOffset, int yOffset)
		{
			mTN.mGravity = gravity;
			mTN.mX = xOffset;
			mTN.mY = yOffset;
		}

		/// <summary>Get the location at which the notification should appear on the screen.</summary>
		/// <remarks>Get the location at which the notification should appear on the screen.</remarks>
		/// <seealso cref="android.view.Gravity">android.view.Gravity</seealso>
		/// <seealso cref="getGravity()">getGravity()</seealso>
		public virtual int getGravity()
		{
			return mTN.mGravity;
		}

		/// <summary>Return the X offset in pixels to apply to the gravity's location.</summary>
		/// <remarks>Return the X offset in pixels to apply to the gravity's location.</remarks>
		public virtual int getXOffset()
		{
			return mTN.mX;
		}

		/// <summary>Return the Y offset in pixels to apply to the gravity's location.</summary>
		/// <remarks>Return the Y offset in pixels to apply to the gravity's location.</remarks>
		public virtual int getYOffset()
		{
			return mTN.mY;
		}

		/// <summary>Make a standard toast that just contains a text view.</summary>
		/// <remarks>Make a standard toast that just contains a text view.</remarks>
		/// <param name="context">
		/// The context to use.  Usually your
		/// <see cref="android.app.Application">android.app.Application</see>
		/// or
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// object.
		/// </param>
		/// <param name="text">The text to show.  Can be formatted text.</param>
		/// <param name="duration">
		/// How long to display the message.  Either
		/// <see cref="LENGTH_SHORT">LENGTH_SHORT</see>
		/// or
		/// <see cref="LENGTH_LONG">LENGTH_LONG</see>
		/// </param>
		public static android.widget.Toast makeText(android.content.Context context, java.lang.CharSequence
			 text, int duration)
		{
			android.widget.Toast result = new android.widget.Toast(context);
			android.view.LayoutInflater inflate = (android.view.LayoutInflater)context.getSystemService
				(android.content.Context.LAYOUT_INFLATER_SERVICE);
			android.view.View v = inflate.inflate(android.@internal.R.layout.transient_notification
				, null);
			android.widget.TextView tv = (android.widget.TextView)v.findViewById(android.@internal.R
				.id.message);
			tv.setText(text);
			result.mNextView = v;
			result.mDuration = duration;
			return result;
		}

		/// <summary>Make a standard toast that just contains a text view with the text from a resource.
		/// 	</summary>
		/// <remarks>Make a standard toast that just contains a text view with the text from a resource.
		/// 	</remarks>
		/// <param name="context">
		/// The context to use.  Usually your
		/// <see cref="android.app.Application">android.app.Application</see>
		/// or
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// object.
		/// </param>
		/// <param name="resId">The resource id of the string resource to use.  Can be formatted text.
		/// 	</param>
		/// <param name="duration">
		/// How long to display the message.  Either
		/// <see cref="LENGTH_SHORT">LENGTH_SHORT</see>
		/// or
		/// <see cref="LENGTH_LONG">LENGTH_LONG</see>
		/// </param>
		/// <exception cref="android.content.res.Resources.NotFoundException">if the resource can't be found.
		/// 	</exception>
		public static android.widget.Toast makeText(android.content.Context context, int 
			resId, int duration)
		{
			return makeText(context, context.getResources().getText(resId), duration);
		}

		/// <summary>Update the text in a Toast that was previously created using one of the makeText() methods.
		/// 	</summary>
		/// <remarks>Update the text in a Toast that was previously created using one of the makeText() methods.
		/// 	</remarks>
		/// <param name="resId">The new text for the Toast.</param>
		public virtual void setText(int resId)
		{
			setText(mContext.getText(resId));
		}

		/// <summary>Update the text in a Toast that was previously created using one of the makeText() methods.
		/// 	</summary>
		/// <remarks>Update the text in a Toast that was previously created using one of the makeText() methods.
		/// 	</remarks>
		/// <param name="s">The new text for the Toast.</param>
		public virtual void setText(java.lang.CharSequence s)
		{
			if (mNextView == null)
			{
				throw new java.lang.RuntimeException("This Toast was not created with Toast.makeText()"
					);
			}
			android.widget.TextView tv = (android.widget.TextView)mNextView.findViewById(android.@internal.R
				.id.message);
			if (tv == null)
			{
				throw new java.lang.RuntimeException("This Toast was not created with Toast.makeText()"
					);
			}
			tv.setText(s);
		}

		private static android.app.INotificationManager sService;

		// =======================================================================================
		// All the gunk below is the interaction with the Notification Service, which handles
		// the proper ordering of these system-wide.
		// =======================================================================================
		private static android.app.INotificationManager getService()
		{
			if (sService != null)
			{
				return sService;
			}
			sService = android.app.INotificationManagerClass.Stub.asInterface(android.os.ServiceManager
				.getService("notification"));
			return sService;
		}

		private class TN : android.app.ITransientNotificationClass.Stub
		{
			internal sealed class _Runnable_302 : java.lang.Runnable
			{
				public _Runnable_302(TN _enclosing)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					this._enclosing.handleShow();
				}

				private readonly TN _enclosing;
			}

			internal readonly java.lang.Runnable mShow;

			internal sealed class _Runnable_308 : java.lang.Runnable
			{
				public _Runnable_308(TN _enclosing)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					this._enclosing.handleHide();
					// Don't do this in handleHide() because it is also invoked by handleShow()
					this._enclosing.mNextView = null;
				}

				private readonly TN _enclosing;
			}

			internal readonly java.lang.Runnable mHide;

			internal readonly android.view.WindowManagerClass.LayoutParams mParams = new android.view.WindowManagerClass
				.LayoutParams();

			internal readonly android.os.Handler mHandler = new android.os.Handler();

			internal int mGravity = android.view.Gravity.CENTER_HORIZONTAL | android.view.Gravity
				.BOTTOM;

			internal int mX;

			internal int mY;

			internal float mHorizontalMargin;

			internal float mVerticalMargin;

			internal android.view.View mView;

			internal android.view.View mNextView;

			internal android.view.WindowManagerImpl mWM;

			internal TN()
			{
				mShow = new _Runnable_302(this);
				mHide = new _Runnable_308(this);
				// XXX This should be changed to use a Dialog, with a Theme.Toast
				// defined that sets up the layout params appropriately.
				android.view.WindowManagerClass.LayoutParams @params = mParams;
				@params.height = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
				@params.width = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
				@params.flags = android.view.WindowManagerClass.LayoutParams.FLAG_NOT_FOCUSABLE |
					 android.view.WindowManagerClass.LayoutParams.FLAG_NOT_TOUCHABLE | android.view.WindowManagerClass
					.LayoutParams.FLAG_KEEP_SCREEN_ON;
				@params.format = android.graphics.PixelFormat.TRANSLUCENT;
				@params.windowAnimations = android.@internal.R.style.Animation_Toast;
				@params.type = android.view.WindowManagerClass.LayoutParams.TYPE_TOAST;
				@params.setTitle(java.lang.CharSequenceProxy.Wrap("Toast"));
			}

			/// <summary>schedule handleShow into the right thread</summary>
			[Sharpen.ImplementsInterface(@"android.app.ITransientNotification")]
			public override void show()
			{
				mHandler.post(mShow);
			}

			/// <summary>schedule handleHide into the right thread</summary>
			[Sharpen.ImplementsInterface(@"android.app.ITransientNotification")]
			public override void hide()
			{
				mHandler.post(mHide);
			}

			public virtual void handleShow()
			{
				if (mView != mNextView)
				{
					// remove the old view if necessary
					handleHide();
					mView = mNextView;
					mWM = android.view.WindowManagerImpl.getDefault();
					int gravity = mGravity;
					mParams.gravity = gravity;
					if ((gravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK) == android.view.Gravity
						.FILL_HORIZONTAL)
					{
						mParams.horizontalWeight = 1.0f;
					}
					if ((gravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == android.view.Gravity
						.FILL_VERTICAL)
					{
						mParams.verticalWeight = 1.0f;
					}
					mParams.x = mX;
					mParams.y = mY;
					mParams.verticalMargin = mVerticalMargin;
					mParams.horizontalMargin = mHorizontalMargin;
					if (mView.getParent() != null)
					{
						mWM.removeView(mView);
					}
					mWM.addView(mView, mParams);
					trySendAccessibilityEvent();
				}
			}

			internal void trySendAccessibilityEvent()
			{
				android.view.accessibility.AccessibilityManager accessibilityManager = android.view.accessibility.AccessibilityManager
					.getInstance(mView.getContext());
				if (!accessibilityManager.isEnabled())
				{
					return;
				}
				// treat toasts as notifications since they are used to
				// announce a transient piece of information to the user
				android.view.accessibility.AccessibilityEvent @event = android.view.accessibility.AccessibilityEvent
					.obtain(android.view.accessibility.AccessibilityEvent.TYPE_NOTIFICATION_STATE_CHANGED
					);
				@event.setClassName(java.lang.CharSequenceProxy.Wrap(GetType().FullName));
				@event.setPackageName(java.lang.CharSequenceProxy.Wrap(mView.getContext().getPackageName
					()));
				mView.dispatchPopulateAccessibilityEvent(@event);
				accessibilityManager.sendAccessibilityEvent(@event);
			}

			public virtual void handleHide()
			{
				if (mView != null)
				{
					// note: checking parent() just to make sure the view has
					// been added...  i have seen cases where we get here when
					// the view isn't yet added, so let's try not to crash.
					if (mView.getParent() != null)
					{
						mWM.removeView(mView);
					}
					mView = null;
				}
			}
		}
	}
}
