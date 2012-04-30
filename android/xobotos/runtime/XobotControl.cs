using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using android.graphics;
using android.view;

namespace XobotOS.Runtime
{
	[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	internal sealed class XobotControl : Control
	{
		[DllImport("libxobotos.dll")]
		static extern int libxobotos_init ();

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr libxobotos_window_new (IntPtr hwnd, IntPtr on_draw, bool init_gl);

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool libxobotos_window_event (IntPtr window, IntPtr hwnd, uint message, IntPtr wparam, IntPtr lparam);

		private delegate void OnDrawHandler (System.IntPtr canvas);

		private IntPtr skia_window;
		private OnDrawHandler on_draw_handler;

		static XobotControl ()
		{
			libxobotos_init ();
		}

		internal XobotControl ()
		{
			on_draw_handler = new OnDrawHandler (OnDraw);

			SetStyle (ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
			SetStyle (ControlStyles.AllPaintingInWmPaint, true);
			Dock = DockStyle.Fill;
		}

		protected override void OnHandleCreated (EventArgs e)
		{
			IntPtr on_draw = Marshal.GetFunctionPointerForDelegate (on_draw_handler);
			skia_window = libxobotos_window_new (Handle, on_draw, false);
			XobotActivityManager.Invoke ((window) => window.OnAttachedToWindow ());
			base.OnHandleCreated (e);
		}

		protected override void OnHandleDestroyed (EventArgs e)
		{
			Console.WriteLine ("ON HANDLE DESTROYED !");
			base.OnHandleDestroyed (e);
		}

		protected override void OnVisibleChanged (EventArgs e)
		{
			XobotActivityManager.Invoke ((window) => window.OnVisibilityChanged (Visible));
			base.OnVisibleChanged (e);
		}

		long mouse_down;

		void SendMotionEvent (int action, MouseEventArgs e)
		{
			long time = android.os.SystemClock.uptimeMillis ();
			if (action == MotionEvent.ACTION_DOWN) {
				mouse_down = time;
			} else if (mouse_down == 0) {
				return;
			}
			using (MotionEvent me = MotionEvent.obtain (mouse_down, time, action, e.X, e.Y, 0))
				XobotActivityManager.Invoke ((window) => window.SendMotionEvent (me));
			if (action == MotionEvent.ACTION_UP)
				mouse_down = 0;
		}

		void SendKeyEvent (KeyEvent e)
		{
			XobotActivityManager.Invoke ((window) => window.SendKeyEvent (e));
		}

		protected override void OnMouseDown (MouseEventArgs e)
		{
			SendMotionEvent (MotionEvent.ACTION_DOWN, e);
			base.OnMouseDown (e);
		}

		protected override void OnMouseUp (MouseEventArgs e)
		{
			SendMotionEvent (MotionEvent.ACTION_UP, e);
			base.OnMouseUp (e);
		}

		protected override void OnMouseMove (MouseEventArgs e)
		{
			SendMotionEvent (MotionEvent.ACTION_MOVE, e);
			base.OnMouseMove (e);
		}

		protected override void OnKeyDown (KeyEventArgs e)
		{
			SendKeyEvent (new KeyEvent (KeyEvent.ACTION_DOWN, e));
			base.OnKeyDown (e);
		}

		protected override void OnKeyUp (KeyEventArgs e)
		{
			SendKeyEvent (new KeyEvent (KeyEvent.ACTION_UP, e));
			base.OnKeyUp (e);
		}

		protected override void OnGotFocus (EventArgs e)
		{
			XobotActivityManager.Invoke ((window) => window.OnFocusChanged (true));
			base.OnGotFocus (e);
		}

		protected override void OnLostFocus (EventArgs e)
		{
			XobotActivityManager.Invoke ((window) => window.OnFocusChanged (false));
			base.OnLostFocus (e);
		}

		protected override void OnLayout (LayoutEventArgs levent)
		{
			XobotActivityManager.Invoke ((window) => window.PerformLayout (Left, Top, Right, Bottom));
			base.OnLayout (levent);
		}

		protected override void OnPaint (PaintEventArgs e)
		{
			; // Do nothing
		}

		protected override void OnPaintBackground (PaintEventArgs e)
		{
			; // Do nothing
		}

		bool drawing;
		bool invalidate_requested;

		void OnDraw (System.IntPtr native_canvas)
		{
			using (Canvas canvas = new Canvas(native_canvas)) {
				canvas.drawColor (Color.BLACK);

				/*
				 * Do not call Control.Invalidate() while we're drawing;
				 * Winforms would simply discard it.
				 */
				do {
					invalidate_requested = false;
					drawing = true;
					XobotActivityManager.Invoke ((window) => window.OnDraw (canvas));
					drawing = false;
				} while (invalidate_requested);
			}
		}

		public void RequestInvalidate ()
		{
			invalidate_requested = true;
			if (!drawing)
				Invalidate ();
		}

		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
		protected override void WndProc (ref Message m)
		{
			if (skia_window != IntPtr.Zero) {
				if (libxobotos_window_event (skia_window, m.HWnd, (uint)m.Msg, m.WParam, m.LParam))
					return;
			}
			base.WndProc (ref m);
		}
	}
}
