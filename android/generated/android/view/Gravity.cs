using Sharpen;

namespace android.view
{
	/// <summary>
	/// Standard constants and tools for placing an object within a potentially
	/// larger container.
	/// </summary>
	/// <remarks>
	/// Standard constants and tools for placing an object within a potentially
	/// larger container.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Gravity
	{
		/// <summary>Constant indicating that no gravity has been set</summary>
		public const int NO_GRAVITY = unchecked((int)(0x0000));

		/// <summary>Raw bit indicating the gravity for an axis has been specified.</summary>
		/// <remarks>Raw bit indicating the gravity for an axis has been specified.</remarks>
		public const int AXIS_SPECIFIED = unchecked((int)(0x0001));

		/// <summary>Raw bit controlling how the left/top edge is placed.</summary>
		/// <remarks>Raw bit controlling how the left/top edge is placed.</remarks>
		public const int AXIS_PULL_BEFORE = unchecked((int)(0x0002));

		/// <summary>Raw bit controlling how the right/bottom edge is placed.</summary>
		/// <remarks>Raw bit controlling how the right/bottom edge is placed.</remarks>
		public const int AXIS_PULL_AFTER = unchecked((int)(0x0004));

		/// <summary>
		/// Raw bit controlling whether the right/bottom edge is clipped to its
		/// container, based on the gravity direction being applied.
		/// </summary>
		/// <remarks>
		/// Raw bit controlling whether the right/bottom edge is clipped to its
		/// container, based on the gravity direction being applied.
		/// </remarks>
		public const int AXIS_CLIP = unchecked((int)(0x0008));

		/// <summary>Bits defining the horizontal axis.</summary>
		/// <remarks>Bits defining the horizontal axis.</remarks>
		public const int AXIS_X_SHIFT = 0;

		/// <summary>Bits defining the vertical axis.</summary>
		/// <remarks>Bits defining the vertical axis.</remarks>
		public const int AXIS_Y_SHIFT = 4;

		/// <summary>Push object to the top of its container, not changing its size.</summary>
		/// <remarks>Push object to the top of its container, not changing its size.</remarks>
		public const int TOP = (AXIS_PULL_BEFORE | AXIS_SPECIFIED) << AXIS_Y_SHIFT;

		/// <summary>Push object to the bottom of its container, not changing its size.</summary>
		/// <remarks>Push object to the bottom of its container, not changing its size.</remarks>
		public const int BOTTOM = (AXIS_PULL_AFTER | AXIS_SPECIFIED) << AXIS_Y_SHIFT;

		/// <summary>Push object to the left of its container, not changing its size.</summary>
		/// <remarks>Push object to the left of its container, not changing its size.</remarks>
		public const int LEFT = (AXIS_PULL_BEFORE | AXIS_SPECIFIED) << AXIS_X_SHIFT;

		/// <summary>Push object to the right of its container, not changing its size.</summary>
		/// <remarks>Push object to the right of its container, not changing its size.</remarks>
		public const int RIGHT = (AXIS_PULL_AFTER | AXIS_SPECIFIED) << AXIS_X_SHIFT;

		/// <summary>
		/// Place object in the vertical center of its container, not changing its
		/// size.
		/// </summary>
		/// <remarks>
		/// Place object in the vertical center of its container, not changing its
		/// size.
		/// </remarks>
		public const int CENTER_VERTICAL = AXIS_SPECIFIED << AXIS_Y_SHIFT;

		/// <summary>
		/// Grow the vertical size of the object if needed so it completely fills
		/// its container.
		/// </summary>
		/// <remarks>
		/// Grow the vertical size of the object if needed so it completely fills
		/// its container.
		/// </remarks>
		public const int FILL_VERTICAL = TOP | BOTTOM;

		/// <summary>
		/// Place object in the horizontal center of its container, not changing its
		/// size.
		/// </summary>
		/// <remarks>
		/// Place object in the horizontal center of its container, not changing its
		/// size.
		/// </remarks>
		public const int CENTER_HORIZONTAL = AXIS_SPECIFIED << AXIS_X_SHIFT;

		/// <summary>
		/// Grow the horizontal size of the object if needed so it completely fills
		/// its container.
		/// </summary>
		/// <remarks>
		/// Grow the horizontal size of the object if needed so it completely fills
		/// its container.
		/// </remarks>
		public const int FILL_HORIZONTAL = LEFT | RIGHT;

		/// <summary>
		/// Place the object in the center of its container in both the vertical
		/// and horizontal axis, not changing its size.
		/// </summary>
		/// <remarks>
		/// Place the object in the center of its container in both the vertical
		/// and horizontal axis, not changing its size.
		/// </remarks>
		public const int CENTER = CENTER_VERTICAL | CENTER_HORIZONTAL;

		/// <summary>
		/// Grow the horizontal and vertical size of the object if needed so it
		/// completely fills its container.
		/// </summary>
		/// <remarks>
		/// Grow the horizontal and vertical size of the object if needed so it
		/// completely fills its container.
		/// </remarks>
		public const int FILL = FILL_VERTICAL | FILL_HORIZONTAL;

		/// <summary>
		/// Flag to clip the edges of the object to its container along the
		/// vertical axis.
		/// </summary>
		/// <remarks>
		/// Flag to clip the edges of the object to its container along the
		/// vertical axis.
		/// </remarks>
		public const int CLIP_VERTICAL = AXIS_CLIP << AXIS_Y_SHIFT;

		/// <summary>
		/// Flag to clip the edges of the object to its container along the
		/// horizontal axis.
		/// </summary>
		/// <remarks>
		/// Flag to clip the edges of the object to its container along the
		/// horizontal axis.
		/// </remarks>
		public const int CLIP_HORIZONTAL = AXIS_CLIP << AXIS_X_SHIFT;

		/// <summary>
		/// Raw bit controlling whether the layout direction is relative or not (START/END instead of
		/// absolute LEFT/RIGHT).
		/// </summary>
		/// <remarks>
		/// Raw bit controlling whether the layout direction is relative or not (START/END instead of
		/// absolute LEFT/RIGHT).
		/// </remarks>
		public const int RELATIVE_LAYOUT_DIRECTION = unchecked((int)(0x00800000));

		/// <summary>Binary mask to get the absolute horizontal gravity of a gravity.</summary>
		/// <remarks>Binary mask to get the absolute horizontal gravity of a gravity.</remarks>
		public const int HORIZONTAL_GRAVITY_MASK = (AXIS_SPECIFIED | AXIS_PULL_BEFORE | AXIS_PULL_AFTER
			) << AXIS_X_SHIFT;

		/// <summary>Binary mask to get the vertical gravity of a gravity.</summary>
		/// <remarks>Binary mask to get the vertical gravity of a gravity.</remarks>
		public const int VERTICAL_GRAVITY_MASK = (AXIS_SPECIFIED | AXIS_PULL_BEFORE | AXIS_PULL_AFTER
			) << AXIS_Y_SHIFT;

		/// <summary>
		/// Special constant to enable clipping to an overall display along the
		/// vertical dimension.
		/// </summary>
		/// <remarks>
		/// Special constant to enable clipping to an overall display along the
		/// vertical dimension.  This is not applied by default by
		/// <see cref="apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)
		/// 	">apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)</see>
		/// ; you must do so
		/// yourself by calling
		/// <see cref="applyDisplay(int, android.graphics.Rect, android.graphics.Rect)">applyDisplay(int, android.graphics.Rect, android.graphics.Rect)
		/// 	</see>
		/// .
		/// </remarks>
		public const int DISPLAY_CLIP_VERTICAL = unchecked((int)(0x10000000));

		/// <summary>
		/// Special constant to enable clipping to an overall display along the
		/// horizontal dimension.
		/// </summary>
		/// <remarks>
		/// Special constant to enable clipping to an overall display along the
		/// horizontal dimension.  This is not applied by default by
		/// <see cref="apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)
		/// 	">apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)</see>
		/// ; you must do so
		/// yourself by calling
		/// <see cref="applyDisplay(int, android.graphics.Rect, android.graphics.Rect)">applyDisplay(int, android.graphics.Rect, android.graphics.Rect)
		/// 	</see>
		/// .
		/// </remarks>
		public const int DISPLAY_CLIP_HORIZONTAL = unchecked((int)(0x01000000));

		/// <summary>Push object to x-axis position at the start of its container, not changing its size.
		/// 	</summary>
		/// <remarks>Push object to x-axis position at the start of its container, not changing its size.
		/// 	</remarks>
		public const int START = RELATIVE_LAYOUT_DIRECTION | LEFT;

		/// <summary>Push object to x-axis position at the end of its container, not changing its size.
		/// 	</summary>
		/// <remarks>Push object to x-axis position at the end of its container, not changing its size.
		/// 	</remarks>
		public const int END = RELATIVE_LAYOUT_DIRECTION | RIGHT;

		/// <summary>Binary mask for the horizontal gravity and script specific direction bit.
		/// 	</summary>
		/// <remarks>Binary mask for the horizontal gravity and script specific direction bit.
		/// 	</remarks>
		public const int RELATIVE_HORIZONTAL_GRAVITY_MASK = START | END;

		/// <summary>Apply a gravity constant to an object.</summary>
		/// <remarks>Apply a gravity constant to an object. This suppose that the layout direction is LTR.
		/// 	</remarks>
		/// <param name="gravity">
		/// The desired placement of the object, as defined by the
		/// constants in this class.
		/// </param>
		/// <param name="w">The horizontal size of the object.</param>
		/// <param name="h">The vertical size of the object.</param>
		/// <param name="container">
		/// The frame of the containing space, in which the object
		/// will be placed.  Should be large enough to contain the
		/// width and height of the object.
		/// </param>
		/// <param name="outRect">
		/// Receives the computed frame of the object in its
		/// container.
		/// </param>
		public static void apply(int gravity, int w, int h, android.graphics.Rect container
			, android.graphics.Rect outRect)
		{
			apply(gravity, w, h, container, 0, 0, outRect);
		}

		/// <summary>Apply a gravity constant to an object and take care if layout direction is RTL or not.
		/// 	</summary>
		/// <remarks>Apply a gravity constant to an object and take care if layout direction is RTL or not.
		/// 	</remarks>
		/// <param name="gravity">
		/// The desired placement of the object, as defined by the
		/// constants in this class.
		/// </param>
		/// <param name="w">The horizontal size of the object.</param>
		/// <param name="h">The vertical size of the object.</param>
		/// <param name="container">
		/// The frame of the containing space, in which the object
		/// will be placed.  Should be large enough to contain the
		/// width and height of the object.
		/// </param>
		/// <param name="outRect">
		/// Receives the computed frame of the object in its
		/// container.
		/// </param>
		/// <param name="layoutDirection">The layout direction.</param>
		/// <hide></hide>
		public static void apply(int gravity, int w, int h, android.graphics.Rect container
			, android.graphics.Rect outRect, int layoutDirection)
		{
			int absGravity = getAbsoluteGravity(gravity, layoutDirection);
			apply(absGravity, w, h, container, 0, 0, outRect);
		}

		/// <summary>Apply a gravity constant to an object.</summary>
		/// <remarks>Apply a gravity constant to an object.</remarks>
		/// <param name="gravity">
		/// The desired placement of the object, as defined by the
		/// constants in this class.
		/// </param>
		/// <param name="w">The horizontal size of the object.</param>
		/// <param name="h">The vertical size of the object.</param>
		/// <param name="container">
		/// The frame of the containing space, in which the object
		/// will be placed.  Should be large enough to contain the
		/// width and height of the object.
		/// </param>
		/// <param name="xAdj">
		/// Offset to apply to the X axis.  If gravity is LEFT this
		/// pushes it to the right; if gravity is RIGHT it pushes it to
		/// the left; if gravity is CENTER_HORIZONTAL it pushes it to the
		/// right or left; otherwise it is ignored.
		/// </param>
		/// <param name="yAdj">
		/// Offset to apply to the Y axis.  If gravity is TOP this pushes
		/// it down; if gravity is BOTTOM it pushes it up; if gravity is
		/// CENTER_VERTICAL it pushes it down or up; otherwise it is
		/// ignored.
		/// </param>
		/// <param name="outRect">
		/// Receives the computed frame of the object in its
		/// container.
		/// </param>
		public static void apply(int gravity, int w, int h, android.graphics.Rect container
			, int xAdj, int yAdj, android.graphics.Rect outRect)
		{
			switch (gravity & ((AXIS_PULL_BEFORE | AXIS_PULL_AFTER) << AXIS_X_SHIFT))
			{
				case 0:
				{
					outRect.left = container.left + ((container.right - container.left - w) / 2) + xAdj;
					outRect.right = outRect.left + w;
					if ((gravity & (AXIS_CLIP << AXIS_X_SHIFT)) == (AXIS_CLIP << AXIS_X_SHIFT))
					{
						if (outRect.left < container.left)
						{
							outRect.left = container.left;
						}
						if (outRect.right > container.right)
						{
							outRect.right = container.right;
						}
					}
					break;
				}

				case AXIS_PULL_BEFORE << AXIS_X_SHIFT:
				{
					outRect.left = container.left + xAdj;
					outRect.right = outRect.left + w;
					if ((gravity & (AXIS_CLIP << AXIS_X_SHIFT)) == (AXIS_CLIP << AXIS_X_SHIFT))
					{
						if (outRect.right > container.right)
						{
							outRect.right = container.right;
						}
					}
					break;
				}

				case AXIS_PULL_AFTER << AXIS_X_SHIFT:
				{
					outRect.right = container.right - xAdj;
					outRect.left = outRect.right - w;
					if ((gravity & (AXIS_CLIP << AXIS_X_SHIFT)) == (AXIS_CLIP << AXIS_X_SHIFT))
					{
						if (outRect.left < container.left)
						{
							outRect.left = container.left;
						}
					}
					break;
				}

				default:
				{
					outRect.left = container.left + xAdj;
					outRect.right = container.right + xAdj;
					break;
				}
			}
			switch (gravity & ((AXIS_PULL_BEFORE | AXIS_PULL_AFTER) << AXIS_Y_SHIFT))
			{
				case 0:
				{
					outRect.top = container.top + ((container.bottom - container.top - h) / 2) + yAdj;
					outRect.bottom = outRect.top + h;
					if ((gravity & (AXIS_CLIP << AXIS_Y_SHIFT)) == (AXIS_CLIP << AXIS_Y_SHIFT))
					{
						if (outRect.top < container.top)
						{
							outRect.top = container.top;
						}
						if (outRect.bottom > container.bottom)
						{
							outRect.bottom = container.bottom;
						}
					}
					break;
				}

				case AXIS_PULL_BEFORE << AXIS_Y_SHIFT:
				{
					outRect.top = container.top + yAdj;
					outRect.bottom = outRect.top + h;
					if ((gravity & (AXIS_CLIP << AXIS_Y_SHIFT)) == (AXIS_CLIP << AXIS_Y_SHIFT))
					{
						if (outRect.bottom > container.bottom)
						{
							outRect.bottom = container.bottom;
						}
					}
					break;
				}

				case AXIS_PULL_AFTER << AXIS_Y_SHIFT:
				{
					outRect.bottom = container.bottom - yAdj;
					outRect.top = outRect.bottom - h;
					if ((gravity & (AXIS_CLIP << AXIS_Y_SHIFT)) == (AXIS_CLIP << AXIS_Y_SHIFT))
					{
						if (outRect.top < container.top)
						{
							outRect.top = container.top;
						}
					}
					break;
				}

				default:
				{
					outRect.top = container.top + yAdj;
					outRect.bottom = container.bottom + yAdj;
					break;
				}
			}
		}

		/// <summary>
		/// Apply additional gravity behavior based on the overall "display" that an
		/// object exists in.
		/// </summary>
		/// <remarks>
		/// Apply additional gravity behavior based on the overall "display" that an
		/// object exists in.  This can be used after
		/// <see cref="apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)
		/// 	">apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)</see>
		/// to place the object
		/// within a visible display.  By default this moves or clips the object
		/// to be visible in the display; the gravity flags
		/// <see cref="DISPLAY_CLIP_HORIZONTAL">DISPLAY_CLIP_HORIZONTAL</see>
		/// and
		/// <see cref="DISPLAY_CLIP_VERTICAL">DISPLAY_CLIP_VERTICAL</see>
		/// can be used to change this behavior.
		/// </remarks>
		/// <param name="gravity">
		/// Gravity constants to modify the placement within the
		/// display.
		/// </param>
		/// <param name="display">
		/// The rectangle of the display in which the object is
		/// being placed.
		/// </param>
		/// <param name="inoutObj">
		/// Supplies the current object position; returns with it
		/// modified if needed to fit in the display.
		/// </param>
		public static void applyDisplay(int gravity, android.graphics.Rect display, android.graphics.Rect
			 inoutObj)
		{
			if ((gravity & DISPLAY_CLIP_VERTICAL) != 0)
			{
				if (inoutObj.top < display.top)
				{
					inoutObj.top = display.top;
				}
				if (inoutObj.bottom > display.bottom)
				{
					inoutObj.bottom = display.bottom;
				}
			}
			else
			{
				int off = 0;
				if (inoutObj.top < display.top)
				{
					off = display.top - inoutObj.top;
				}
				else
				{
					if (inoutObj.bottom > display.bottom)
					{
						off = display.bottom - inoutObj.bottom;
					}
				}
				if (off != 0)
				{
					if (inoutObj.height() > (display.bottom - display.top))
					{
						inoutObj.top = display.top;
						inoutObj.bottom = display.bottom;
					}
					else
					{
						inoutObj.top += off;
						inoutObj.bottom += off;
					}
				}
			}
			if ((gravity & DISPLAY_CLIP_HORIZONTAL) != 0)
			{
				if (inoutObj.left < display.left)
				{
					inoutObj.left = display.left;
				}
				if (inoutObj.right > display.right)
				{
					inoutObj.right = display.right;
				}
			}
			else
			{
				int off = 0;
				if (inoutObj.left < display.left)
				{
					off = display.left - inoutObj.left;
				}
				else
				{
					if (inoutObj.right > display.right)
					{
						off = display.right - inoutObj.right;
					}
				}
				if (off != 0)
				{
					if (inoutObj.width() > (display.right - display.left))
					{
						inoutObj.left = display.left;
						inoutObj.right = display.right;
					}
					else
					{
						inoutObj.left += off;
						inoutObj.right += off;
					}
				}
			}
		}

		/// <summary><p>Indicate whether the supplied gravity has a vertical pull.</p></summary>
		/// <param name="gravity">the gravity to check for vertical pull</param>
		/// <returns>true if the supplied gravity has a vertical pull</returns>
		public static bool isVertical(int gravity)
		{
			return gravity > 0 && (gravity & VERTICAL_GRAVITY_MASK) != 0;
		}

		/// <summary><p>Indicate whether the supplied gravity has an horizontal pull.</p></summary>
		/// <param name="gravity">the gravity to check for horizontal pull</param>
		/// <returns>true if the supplied gravity has an horizontal pull</returns>
		public static bool isHorizontal(int gravity)
		{
			return gravity > 0 && (gravity & RELATIVE_HORIZONTAL_GRAVITY_MASK) != 0;
		}

		/// <summary>
		/// <p>Convert script specific gravity to absolute horizontal value.</p>
		/// if horizontal direction is LTR, then START will set LEFT and END will set RIGHT.
		/// </summary>
		/// <remarks>
		/// <p>Convert script specific gravity to absolute horizontal value.</p>
		/// if horizontal direction is LTR, then START will set LEFT and END will set RIGHT.
		/// if horizontal direction is RTL, then START will set RIGHT and END will set LEFT.
		/// </remarks>
		/// <param name="gravity">The gravity to convert to absolute (horizontal) values.</param>
		/// <param name="layoutDirection">The layout direction.</param>
		/// <returns>gravity converted to absolute (horizontal) values.</returns>
		public static int getAbsoluteGravity(int gravity, int layoutDirection)
		{
			int result = gravity;
			// If layout is script specific and gravity is horizontal relative (START or END)
			if ((result & RELATIVE_LAYOUT_DIRECTION) > 0)
			{
				if ((result & android.view.Gravity.START) == android.view.Gravity.START)
				{
					// Remove the START bit
					result &= ~START;
					if (layoutDirection == android.view.View.LAYOUT_DIRECTION_RTL)
					{
						// Set the RIGHT bit
						result |= RIGHT;
					}
					else
					{
						// Set the LEFT bit
						result |= LEFT;
					}
				}
				else
				{
					if ((result & android.view.Gravity.END) == android.view.Gravity.END)
					{
						// Remove the END bit
						result &= ~END;
						if (layoutDirection == android.view.View.LAYOUT_DIRECTION_RTL)
						{
							// Set the LEFT bit
							result |= LEFT;
						}
						else
						{
							// Set the RIGHT bit
							result |= RIGHT;
						}
					}
				}
				// Don't need the script specific bit any more, so remove it as we are converting to
				// absolute values (LEFT or RIGHT)
				result &= ~RELATIVE_LAYOUT_DIRECTION;
			}
			return result;
		}
	}
}
