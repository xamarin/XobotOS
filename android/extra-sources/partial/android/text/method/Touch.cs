using System;
using android.text;
using android.view;
using android.widget;

namespace android.text.method
{
	partial class Touch
	{
		/// <summary>Handles touch events for dragging.</summary>
		/// <remarks>
		/// Handles touch events for dragging.  You may want to do other actions
		/// like moving the cursor on touch as well.
		/// </remarks>
		public static bool onTouchEvent (TextView widget, Spannable buffer, MotionEvent @event)
		{
			DragState[] ds;
			switch (@event.getActionMasked ()) {
			case MotionEvent.ACTION_DOWN:
				{
					ds = buffer.getSpans<DragState> (0, buffer.Length);
					{
						for (int i = 0; i < ds.Length; i++) {
							buffer.removeSpan (ds [i]);
						}
					}
					buffer.setSpan (new DragState (@event.getX (), @event.getY (), widget.getScrollX (), widget.getScrollY ()), 0, 0, SpannedClass.SPAN_MARK_MARK);
					return true;
				}

			case MotionEvent.ACTION_UP:
				{
					ds = buffer.getSpans<DragState> (0, buffer.Length);
					{
						for (int i_1 = 0; i_1 < ds.Length; i_1++) {
							buffer.removeSpan (ds [i_1]);
						}
					}
					if (ds.Length > 0 && ds [0].mUsed) {
						return true;
					} else {
						return false;
					}
					goto case MotionEvent.ACTION_MOVE;
				}

			case android.view.MotionEvent.ACTION_MOVE:
				{
					ds = buffer.getSpans<Touch.DragState> (0, buffer.Length);
					if (ds.Length > 0) {
						if (ds [0].mFarEnough == false) {
							int slop = ViewConfiguration.get (widget.getContext ()).getScaledTouchSlop ();
							if (Math.Abs (@event.getX () - ds [0].mX) >= slop || Math.Abs (@event.getY () - ds [0].mY) >= slop) {
								ds [0].mFarEnough = true;
							}
						}
						if (ds [0].mFarEnough) {
							ds [0].mUsed = true;
							bool cap = (@event.getMetaState () & KeyEvent.META_SHIFT_ON) != 0 ||
								MetaKeyKeyListener.getMetaState (buffer, MetaKeyKeyListener.META_SHIFT_ON) == 1 ||
								MetaKeyKeyListener.getMetaState (buffer, MetaKeyKeyListener.META_SELECTING) != 0;
							float dx;
							float dy;
							if (cap) {
								// if we're selecting, we want the scroll to go in
								// the direction of the drag
								dx = @event.getX () - ds [0].mX;
								dy = @event.getY () - ds [0].mY;
							} else {
								dx = ds [0].mX - @event.getX ();
								dy = ds [0].mY - @event.getY ();
							}
							ds [0].mX = @event.getX ();
							ds [0].mY = @event.getY ();
							int nx = widget.getScrollX () + (int)dx;
							int ny = widget.getScrollY () + (int)dy;
							int padding = widget.getTotalPaddingTop () + widget.getTotalPaddingBottom ();
							Layout layout = widget.getLayout ();
							ny = Math.Min (ny, layout.getHeight () - (widget.getHeight () - padding));
							ny = Math.Max (ny, 0);
							int oldX = widget.getScrollX ();
							int oldY = widget.getScrollY ();
							scrollTo (widget, layout, nx, ny);
							// If we actually scrolled, then cancel the up action.
							if (oldX != widget.getScrollX () || oldY != widget.getScrollY ()) {
								widget.cancelLongPress ();
							}
							return true;
						}
					}
					return false;
				}
			}
			return false;
		}

	}
}

