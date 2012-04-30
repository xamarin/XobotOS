using System;
using System.Threading;
using SWF = System.Windows.Forms;

using android.app;
using android.content;
using android.graphics;
using android.graphics.drawable;
using android.widget;
using android.view;
using android.os;

namespace XobotOS.Runtime
{
	internal sealed class XobotWindow : Window, ViewParent
	{
		readonly DecorView view;
		readonly View.AttachInfo attach_info;
		readonly XobotLayoutInflater layout_inflater;

		View focused;
		bool attached;
		string title;

		public XobotWindow (Context context)
			: base (context)
		{
			layout_inflater = new XobotLayoutInflater (context);
			view = new DecorView (context);
			attach_info = new View.AttachInfo (this);
		}

		internal string Title {
			get {
				return title;
			}
		}

		internal void OnDraw (Canvas canvas)
		{
			view.draw (canvas);
		}

		internal void OnAttachedToWindow ()
		{
			if (attached)
				return;

			attached = true;

			view.onAttachedToWindow ();
			view.assignParent (this);

			view.setLayoutParams (getAttributes ());

			view.dispatchAttachedToWindow (attach_info, View.VISIBLE);
		}

		internal void OnVisibilityChanged (bool visible)
		{
			view.onWindowVisibilityChanged (visible ? 1 : 0);
		}

		internal void SendMotionEvent (MotionEvent me)
		{
			getCallback ().dispatchTouchEvent (me);
		}

		internal void SendKeyEvent (KeyEvent e)
		{
			getCallback ().dispatchKeyEvent (e);
		}

		internal void OnFocusChanged (bool focused)
		{
			attach_info.mHasWindowFocus = focused;
			view.dispatchWindowFocusChanged (focused);
		}

		internal void PerformLayout (int left, int top, int right, int bottom)
		{
			int wspec = View.MeasureSpec.makeMeasureSpec (right - left, View.MeasureSpec.EXACTLY);
			int hspec = View.MeasureSpec.makeMeasureSpec (bottom - top, View.MeasureSpec.EXACTLY);
			view.measure (wspec, hspec);
			view.layout (left, top, right, bottom);
		}

		#region Window implementation

		public override void setContentView (int layoutResID)
		{
			layout_inflater.inflate (layoutResID, view);

			if (getCallback () != null)
				getCallback ().onContentChanged ();
		}

		public override void setContentView (View view)
		{
			setContentView (view, new ViewGroup.LayoutParams (
				ViewGroup.LayoutParams.FILL_PARENT,
				ViewGroup.LayoutParams.FILL_PARENT));
		}

		public override void setContentView (View cview, ViewGroup.LayoutParams @params)
		{
			view.addView (cview, @params);

			if (getCallback () != null)
				getCallback ().onContentChanged ();
		}

		public override View getDecorView ()
		{
			return view;
		}

		public override View peekDecorView ()
		{
			return view;
		}

		public override LayoutInflater getLayoutInflater ()
		{
			return layout_inflater;
		}

		public override void setTitle (java.lang.CharSequence title)
		{
			this.title = title.ToString ();
			XobotActivityManager.MainForm.Text = title.ToString ();
		}

		public override bool superDispatchKeyEvent (KeyEvent @event)
		{
			return view.dispatchKeyEvent (@event);
		}

		public override bool superDispatchTouchEvent (MotionEvent @event)
		{
			return view.dispatchTouchEvent (@event);
		}

		#endregion

		#region implemented abstract members of Window
		public override void takeSurface (SurfaceHolderClass.Callback2 callback)
		{
			throw new NotImplementedException ();
		}

		public override void takeInputQueue (InputQueue.Callback callback)
		{
			throw new NotImplementedException ();
		}

		public override bool isFloating ()
		{
			throw new NotImplementedException ();
		}

		public override void alwaysReadCloseOnTouchAttr ()
		{
			throw new NotImplementedException ();
		}

		public override void addContentView (View view, ViewGroup.LayoutParams @params)
		{
			throw new NotImplementedException ();
		}

		public override View getCurrentFocus ()
		{
			return focused;
		}

		public override void setTitleColor (int textColor)
		{
			throw new NotImplementedException ();
		}

		public override void openPanel (int featureId, KeyEvent @event)
		{
			throw new NotImplementedException ();
		}

		public override void closePanel (int featureId)
		{
			throw new NotImplementedException ();
		}

		public override void togglePanel (int featureId, KeyEvent @event)
		{
			throw new NotImplementedException ();
		}

		public override void invalidatePanelMenu (int featureId)
		{
			throw new NotImplementedException ();
		}

		public override bool performPanelShortcut (int featureId, int keyCode, KeyEvent @event, int flags)
		{
			throw new NotImplementedException ();
		}

		public override bool performPanelIdentifierAction (int featureId, int id, int flags)
		{
			throw new NotImplementedException ();
		}

		public override void closeAllPanels ()
		{
			throw new NotImplementedException ();
		}

		public override bool performContextMenuIdentifierAction (int id, int flags)
		{
			throw new NotImplementedException ();
		}

		public override void onConfigurationChanged (android.content.res.Configuration newConfig)
		{
			throw new NotImplementedException ();
		}

		public override void setBackgroundDrawable (Drawable drawable)
		{
			throw new NotImplementedException ();
		}

		public override void setFeatureDrawableResource (int featureId, int resId)
		{
			throw new NotImplementedException ();
		}

		public override void setFeatureDrawableUri (int featureId, System.Uri uri)
		{
			throw new NotImplementedException ();
		}

		public override void setFeatureDrawable (int featureId, Drawable drawable)
		{
			throw new NotImplementedException ();
		}

		public override void setFeatureDrawableAlpha (int featureId, int alpha)
		{
			throw new NotImplementedException ();
		}

		public override void setFeatureInt (int featureId, int value)
		{
			throw new NotImplementedException ();
		}

		public override void takeKeyEvents (bool get)
		{
			throw new NotImplementedException ();
		}

		public override bool superDispatchKeyShortcutEvent (KeyEvent @event)
		{
			throw new NotImplementedException ();
		}

		public override bool superDispatchTrackballEvent (MotionEvent @event)
		{
			throw new NotImplementedException ();
		}

		public override bool superDispatchGenericMotionEvent (MotionEvent @event)
		{
			throw new NotImplementedException ();
		}

		public override Bundle saveHierarchyState ()
		{
			throw new NotImplementedException ();
		}

		public override void restoreHierarchyState (Bundle savedInstanceState)
		{
			throw new NotImplementedException ();
		}

		internal protected override void onActive ()
		{
			throw new NotImplementedException ();
		}

		public override void setChildDrawable (int featureId, Drawable drawable)
		{
			throw new NotImplementedException ();
		}

		public override void setChildInt (int featureId, int value)
		{
			throw new NotImplementedException ();
		}

		public override bool isShortcutKey (int keyCode, KeyEvent @event)
		{
			throw new NotImplementedException ();
		}

		public override void setVolumeControlStream (int streamType)
		{
			throw new NotImplementedException ();
		}

		public override int getVolumeControlStream ()
		{
			throw new NotImplementedException ();
		}
		#endregion

		#region ViewParent implementation
		public void requestLayout ()
		{
			XobotActivityManager.RequestLayout (this);
		}

		public bool isLayoutRequested ()
		{
			return false;
		}

		public void requestTransparentRegion (View child)
		{
			throw new NotImplementedException ();
		}

		public void invalidateChild (View child, Rect r)
		{
			XobotActivityManager.RequestInvalidate (this);
		}

		public ViewParent invalidateChildInParent (int[] location, Rect r)
		{
			XobotActivityManager.RequestInvalidate (this);
			return null;
		}

		public ViewParent getParent ()
		{
			return this;
		}

		public void requestChildFocus (View child, View focused)
		{
			if (this.focused != focused) {
				attach_info.mTreeObserver.dispatchOnGlobalFocusChange (this.focused, focused);
				this.focused = focused;
			}
		}

		public void recomputeViewAttributes (View child)
		{
			throw new NotImplementedException ();
		}

		public void clearChildFocus (View child)
		{
			View old_focus = focused;

			focused = null;
			if (view != null && !view.hasFocus ()) {
				// If a view gets the focus, the listener will be invoked from requestChildFocus()
				if (!view.requestFocus(View.FOCUS_FORWARD))
					attach_info.mTreeObserver.dispatchOnGlobalFocusChange(old_focus, null);
			} else if (old_focus != null) {
				attach_info.mTreeObserver.dispatchOnGlobalFocusChange(old_focus, null);
			}
		}

		public bool getChildVisibleRect (View child, Rect r, Point offset)
		{
			throw new NotImplementedException ();
		}

		public View focusSearch (View v, int direction)
		{
			// FIXME
			return null;
		}

		public void bringChildToFront (View child)
		{
			throw new NotImplementedException ();
		}

		public void focusableViewAvailable (View v)
		{
			if (view == null)
				return;

			if (!view.hasFocus ()) {
				v.requestFocus ();
			}
		}

		public bool showContextMenuForChild (View originalView)
		{
			return false;
		}

		public void createContextMenu (ContextMenu menu)
		{
			throw new NotImplementedException ();
		}

		public ActionMode startActionModeForChild (View originalView, ActionMode.Callback callback)
		{
			throw new NotImplementedException ();
		}

		public void childDrawableStateChanged (View child)
		{
			; // Do nothing
		}

		public void requestDisallowInterceptTouchEvent (bool disallowIntercept)
		{
			; //
		}

		public bool requestChildRectangleOnScreen (View child, Rect rectangle, bool immediate)
		{
			return false;
		}

		public bool requestSendAccessibilityEvent (View child, android.view.accessibility.AccessibilityEvent @event)
		{
			throw new NotImplementedException ();
		}
		#endregion

		#region DecorView

		protected class DecorView : FrameLayout
		{
			public DecorView (Context context)
				: base (context)
			{
			}
		}

		#endregion
	}
}
