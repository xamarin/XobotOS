using Sharpen;

namespace android.view
{
	/// <summary>
	/// The algorithm used for finding the next focusable view in a given direction
	/// from a view that currently has focus.
	/// </summary>
	/// <remarks>
	/// The algorithm used for finding the next focusable view in a given direction
	/// from a view that currently has focus.
	/// </remarks>
	[Sharpen.Sharpened]
	public class FocusFinder
	{
		private sealed class _ThreadLocal_32 : java.lang.ThreadLocal<android.view.FocusFinder
			>
		{
			public _ThreadLocal_32()
			{
			}

			[Sharpen.OverridesMethod(@"java.lang.ThreadLocal")]
			protected internal override android.view.FocusFinder initialValue()
			{
				return new android.view.FocusFinder();
			}
		}

		private static java.lang.ThreadLocal<android.view.FocusFinder> tlFocusFinder = new 
			_ThreadLocal_32();

		/// <summary>Get the focus finder for this thread.</summary>
		/// <remarks>Get the focus finder for this thread.</remarks>
		public static android.view.FocusFinder getInstance()
		{
			return tlFocusFinder.get();
		}

		internal android.graphics.Rect mFocusedRect = new android.graphics.Rect();

		internal android.graphics.Rect mOtherRect = new android.graphics.Rect();

		internal android.graphics.Rect mBestCandidateRect = new android.graphics.Rect();

		private android.view.FocusFinder.SequentialFocusComparator mSequentialFocusComparator
			 = new android.view.FocusFinder.SequentialFocusComparator();

		private FocusFinder()
		{
		}

		// enforce thread local access
		/// <summary>
		/// Find the next view to take focus in root's descendants, starting from the view
		/// that currently is focused.
		/// </summary>
		/// <remarks>
		/// Find the next view to take focus in root's descendants, starting from the view
		/// that currently is focused.
		/// </remarks>
		/// <param name="root">Contains focused</param>
		/// <param name="focused">Has focus now.</param>
		/// <param name="direction">Direction to look.</param>
		/// <returns>The next focusable view, or null if none exists.</returns>
		public android.view.View findNextFocus(android.view.ViewGroup root, android.view.View
			 focused, int direction)
		{
			if (focused != null)
			{
				// check for user specified next focus
				android.view.View userSetNextFocus = focused.findUserSetNextFocus(root, direction
					);
				if (userSetNextFocus != null && userSetNextFocus.isFocusable() && (!userSetNextFocus
					.isInTouchMode() || userSetNextFocus.isFocusableInTouchMode()))
				{
					return userSetNextFocus;
				}
				// fill in interesting rect from focused
				focused.getFocusedRect(mFocusedRect);
				root.offsetDescendantRectToMyCoords(focused, mFocusedRect);
			}
			else
			{
				switch (direction)
				{
					case android.view.View.FOCUS_RIGHT:
					case android.view.View.FOCUS_DOWN:
					case android.view.View.FOCUS_FORWARD:
					{
						// make up a rect at top left or bottom right of root
						int rootTop = root.getScrollY();
						int rootLeft = root.getScrollX();
						mFocusedRect.set(rootLeft, rootTop, rootLeft, rootTop);
						break;
					}

					case android.view.View.FOCUS_LEFT:
					case android.view.View.FOCUS_UP:
					case android.view.View.FOCUS_BACKWARD:
					{
						int rootBottom = root.getScrollY() + root.getHeight();
						int rootRight = root.getScrollX() + root.getWidth();
						mFocusedRect.set(rootRight, rootBottom, rootRight, rootBottom);
						break;
					}
				}
			}
			return findNextFocus(root, focused, mFocusedRect, direction);
		}

		/// <summary>
		/// Find the next view to take focus in root's descendants, searching from
		/// a particular rectangle in root's coordinates.
		/// </summary>
		/// <remarks>
		/// Find the next view to take focus in root's descendants, searching from
		/// a particular rectangle in root's coordinates.
		/// </remarks>
		/// <param name="root">Contains focusedRect.</param>
		/// <param name="focusedRect">The starting point of the search.</param>
		/// <param name="direction">Direction to look.</param>
		/// <returns>The next focusable view, or null if none exists.</returns>
		public virtual android.view.View findNextFocusFromRect(android.view.ViewGroup root
			, android.graphics.Rect focusedRect, int direction)
		{
			return findNextFocus(root, null, focusedRect, direction);
		}

		private android.view.View findNextFocus(android.view.ViewGroup root, android.view.View
			 focused, android.graphics.Rect focusedRect, int direction)
		{
			java.util.ArrayList<android.view.View> focusables = root.getFocusables(direction);
			if (focusables.isEmpty())
			{
				// The focus cannot change.
				return null;
			}
			if (direction == android.view.View.FOCUS_FORWARD || direction == android.view.View
				.FOCUS_BACKWARD)
			{
				if (focused != null && !focusables.contains(focused))
				{
					// Add the currently focused view to the list to have it sorted
					// along with the other views.
					focusables.add(focused);
				}
				try
				{
					// Note: This sort is stable.
					mSequentialFocusComparator.setRoot(root);
					java.util.Collections.sort(focusables, mSequentialFocusComparator);
				}
				finally
				{
					mSequentialFocusComparator.recycle();
				}
				int count = focusables.size();
				switch (direction)
				{
					case android.view.View.FOCUS_FORWARD:
					{
						if (focused != null)
						{
							int position = focusables.lastIndexOf(focused);
							if (position >= 0 && position + 1 < count)
							{
								return focusables.get(position + 1);
							}
						}
						return focusables.get(0);
					}

					case android.view.View.FOCUS_BACKWARD:
					{
						if (focused != null)
						{
							int position = focusables.indexOf(focused);
							if (position > 0)
							{
								return focusables.get(position - 1);
							}
						}
						return focusables.get(count - 1);
					}
				}
				return null;
			}
			// initialize the best candidate to something impossible
			// (so the first plausible view will become the best choice)
			mBestCandidateRect.set(focusedRect);
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				{
					mBestCandidateRect.offset(focusedRect.width() + 1, 0);
					break;
				}

				case android.view.View.FOCUS_RIGHT:
				{
					mBestCandidateRect.offset(-(focusedRect.width() + 1), 0);
					break;
				}

				case android.view.View.FOCUS_UP:
				{
					mBestCandidateRect.offset(0, focusedRect.height() + 1);
					break;
				}

				case android.view.View.FOCUS_DOWN:
				{
					mBestCandidateRect.offset(0, -(focusedRect.height() + 1));
					break;
				}
			}
			android.view.View closest = null;
			int numFocusables = focusables.size();
			{
				for (int i = 0; i < numFocusables; i++)
				{
					android.view.View focusable = focusables.get(i);
					// only interested in other non-root views
					if (focusable == focused || focusable == root)
					{
						continue;
					}
					// get visible bounds of other view in same coordinate system
					focusable.getDrawingRect(mOtherRect);
					root.offsetDescendantRectToMyCoords(focusable, mOtherRect);
					if (isBetterCandidate(direction, focusedRect, mOtherRect, mBestCandidateRect))
					{
						mBestCandidateRect.set(mOtherRect);
						closest = focusable;
					}
				}
			}
			return closest;
		}

		/// <summary>
		/// Is rect1 a better candidate than rect2 for a focus search in a particular
		/// direction from a source rect?  This is the core routine that determines
		/// the order of focus searching.
		/// </summary>
		/// <remarks>
		/// Is rect1 a better candidate than rect2 for a focus search in a particular
		/// direction from a source rect?  This is the core routine that determines
		/// the order of focus searching.
		/// </remarks>
		/// <param name="direction">the direction (up, down, left, right)</param>
		/// <param name="source">The source we are searching from</param>
		/// <param name="rect1">The candidate rectangle</param>
		/// <param name="rect2">The current best candidate.</param>
		/// <returns>Whether the candidate is the new best.</returns>
		internal virtual bool isBetterCandidate(int direction, android.graphics.Rect source
			, android.graphics.Rect rect1, android.graphics.Rect rect2)
		{
			// to be a better candidate, need to at least be a candidate in the first
			// place :)
			if (!isCandidate(source, rect1, direction))
			{
				return false;
			}
			// we know that rect1 is a candidate.. if rect2 is not a candidate,
			// rect1 is better
			if (!isCandidate(source, rect2, direction))
			{
				return true;
			}
			// if rect1 is better by beam, it wins
			if (beamBeats(direction, source, rect1, rect2))
			{
				return true;
			}
			// if rect2 is better, then rect1 cant' be :)
			if (beamBeats(direction, source, rect2, rect1))
			{
				return false;
			}
			// otherwise, do fudge-tastic comparison of the major and minor axis
			return (getWeightedDistanceFor(majorAxisDistance(direction, source, rect1), minorAxisDistance
				(direction, source, rect1)) < getWeightedDistanceFor(majorAxisDistance(direction
				, source, rect2), minorAxisDistance(direction, source, rect2)));
		}

		/// <summary>
		/// One rectangle may be another candidate than another by virtue of being
		/// exclusively in the beam of the source rect.
		/// </summary>
		/// <remarks>
		/// One rectangle may be another candidate than another by virtue of being
		/// exclusively in the beam of the source rect.
		/// </remarks>
		/// <returns>
		/// Whether rect1 is a better candidate than rect2 by virtue of it being in src's
		/// beam
		/// </returns>
		internal virtual bool beamBeats(int direction, android.graphics.Rect source, android.graphics.Rect
			 rect1, android.graphics.Rect rect2)
		{
			bool rect1InSrcBeam = beamsOverlap(direction, source, rect1);
			bool rect2InSrcBeam = beamsOverlap(direction, source, rect2);
			// if rect1 isn't exclusively in the src beam, it doesn't win
			if (rect2InSrcBeam || !rect1InSrcBeam)
			{
				return false;
			}
			// we know rect1 is in the beam, and rect2 is not
			// if rect1 is to the direction of, and rect2 is not, rect1 wins.
			// for example, for direction left, if rect1 is to the left of the source
			// and rect2 is below, then we always prefer the in beam rect1, since rect2
			// could be reached by going down.
			if (!isToDirectionOf(direction, source, rect2))
			{
				return true;
			}
			// for horizontal directions, being exclusively in beam always wins
			if ((direction == android.view.View.FOCUS_LEFT || direction == android.view.View.
				FOCUS_RIGHT))
			{
				return true;
			}
			// for vertical directions, beams only beat up to a point:
			// now, as long as rect2 isn't completely closer, rect1 wins
			// e.g for direction down, completely closer means for rect2's top
			// edge to be closer to the source's top edge than rect1's bottom edge.
			return (majorAxisDistance(direction, source, rect1) < majorAxisDistanceToFarEdge(
				direction, source, rect2));
		}

		/// <summary>
		/// Fudge-factor opportunity: how to calculate distance given major and minor
		/// axis distances.
		/// </summary>
		/// <remarks>
		/// Fudge-factor opportunity: how to calculate distance given major and minor
		/// axis distances.  Warning: this fudge factor is finely tuned, be sure to
		/// run all focus tests if you dare tweak it.
		/// </remarks>
		internal virtual int getWeightedDistanceFor(int majorAxisDistance_1, int minorAxisDistance_1
			)
		{
			return 13 * majorAxisDistance_1 * majorAxisDistance_1 + minorAxisDistance_1 * minorAxisDistance_1;
		}

		/// <summary>
		/// Is destRect a candidate for the next focus given the direction?  This
		/// checks whether the dest is at least partially to the direction of (e.g left of)
		/// from source.
		/// </summary>
		/// <remarks>
		/// Is destRect a candidate for the next focus given the direction?  This
		/// checks whether the dest is at least partially to the direction of (e.g left of)
		/// from source.
		/// Includes an edge case for an empty rect (which is used in some cases when
		/// searching from a point on the screen).
		/// </remarks>
		internal virtual bool isCandidate(android.graphics.Rect srcRect, android.graphics.Rect
			 destRect, int direction)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				{
					return (srcRect.right > destRect.right || srcRect.left >= destRect.right) && srcRect
						.left > destRect.left;
				}

				case android.view.View.FOCUS_RIGHT:
				{
					return (srcRect.left < destRect.left || srcRect.right <= destRect.left) && srcRect
						.right < destRect.right;
				}

				case android.view.View.FOCUS_UP:
				{
					return (srcRect.bottom > destRect.bottom || srcRect.top >= destRect.bottom) && srcRect
						.top > destRect.top;
				}

				case android.view.View.FOCUS_DOWN:
				{
					return (srcRect.top < destRect.top || srcRect.bottom <= destRect.top) && srcRect.
						bottom < destRect.bottom;
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT}."
				);
		}

		/// <summary>Do the "beams" w.r.t the given direcition's axis of rect1 and rect2 overlap?
		/// 	</summary>
		/// <param name="direction">the direction (up, down, left, right)</param>
		/// <param name="rect1">The first rectangle</param>
		/// <param name="rect2">The second rectangle</param>
		/// <returns>whether the beams overlap</returns>
		internal virtual bool beamsOverlap(int direction, android.graphics.Rect rect1, android.graphics.Rect
			 rect2)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				case android.view.View.FOCUS_RIGHT:
				{
					return (rect2.bottom >= rect1.top) && (rect2.top <= rect1.bottom);
				}

				case android.view.View.FOCUS_UP:
				case android.view.View.FOCUS_DOWN:
				{
					return (rect2.right >= rect1.left) && (rect2.left <= rect1.right);
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT}."
				);
		}

		/// <summary>e.g for left, is 'to left of'</summary>
		internal virtual bool isToDirectionOf(int direction, android.graphics.Rect src, android.graphics.Rect
			 dest)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				{
					return src.left >= dest.right;
				}

				case android.view.View.FOCUS_RIGHT:
				{
					return src.right <= dest.left;
				}

				case android.view.View.FOCUS_UP:
				{
					return src.top >= dest.bottom;
				}

				case android.view.View.FOCUS_DOWN:
				{
					return src.bottom <= dest.top;
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT}."
				);
		}

		/// <returns>
		/// The distance from the edge furthest in the given direction
		/// of source to the edge nearest in the given direction of dest.  If the
		/// dest is not in the direction from source, return 0.
		/// </returns>
		internal static int majorAxisDistance(int direction, android.graphics.Rect source
			, android.graphics.Rect dest)
		{
			return System.Math.Max(0, majorAxisDistanceRaw(direction, source, dest));
		}

		internal static int majorAxisDistanceRaw(int direction, android.graphics.Rect source
			, android.graphics.Rect dest)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				{
					return source.left - dest.right;
				}

				case android.view.View.FOCUS_RIGHT:
				{
					return dest.left - source.right;
				}

				case android.view.View.FOCUS_UP:
				{
					return source.top - dest.bottom;
				}

				case android.view.View.FOCUS_DOWN:
				{
					return dest.top - source.bottom;
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT}."
				);
		}

		/// <returns>
		/// The distance along the major axis w.r.t the direction from the
		/// edge of source to the far edge of dest. If the
		/// dest is not in the direction from source, return 1 (to break ties with
		/// <see cref="majorAxisDistance(int, android.graphics.Rect, android.graphics.Rect)">majorAxisDistance(int, android.graphics.Rect, android.graphics.Rect)
		/// 	</see>
		/// ).
		/// </returns>
		internal static int majorAxisDistanceToFarEdge(int direction, android.graphics.Rect
			 source, android.graphics.Rect dest)
		{
			return System.Math.Max(1, majorAxisDistanceToFarEdgeRaw(direction, source, dest));
		}

		internal static int majorAxisDistanceToFarEdgeRaw(int direction, android.graphics.Rect
			 source, android.graphics.Rect dest)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				{
					return source.left - dest.left;
				}

				case android.view.View.FOCUS_RIGHT:
				{
					return dest.right - source.right;
				}

				case android.view.View.FOCUS_UP:
				{
					return source.top - dest.top;
				}

				case android.view.View.FOCUS_DOWN:
				{
					return dest.bottom - source.bottom;
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT}."
				);
		}

		/// <summary>
		/// Find the distance on the minor axis w.r.t the direction to the nearest
		/// edge of the destination rectange.
		/// </summary>
		/// <remarks>
		/// Find the distance on the minor axis w.r.t the direction to the nearest
		/// edge of the destination rectange.
		/// </remarks>
		/// <param name="direction">the direction (up, down, left, right)</param>
		/// <param name="source">The source rect.</param>
		/// <param name="dest">The destination rect.</param>
		/// <returns>The distance.</returns>
		internal static int minorAxisDistance(int direction, android.graphics.Rect source
			, android.graphics.Rect dest)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				case android.view.View.FOCUS_RIGHT:
				{
					// the distance between the center verticals
					return System.Math.Abs(((source.top + source.height() / 2) - ((dest.top + dest.height
						() / 2))));
				}

				case android.view.View.FOCUS_UP:
				case android.view.View.FOCUS_DOWN:
				{
					// the distance between the center horizontals
					return System.Math.Abs(((source.left + source.width() / 2) - ((dest.left + dest.width
						() / 2))));
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT}."
				);
		}

		/// <summary>Find the nearest touchable view to the specified view.</summary>
		/// <remarks>Find the nearest touchable view to the specified view.</remarks>
		/// <param name="root">The root of the tree in which to search</param>
		/// <param name="x">X coordinate from which to start the search</param>
		/// <param name="y">Y coordinate from which to start the search</param>
		/// <param name="direction">Direction to look</param>
		/// <param name="deltas">
		/// Offset from the <x, y> to the edge of the nearest view. Note that this array
		/// may already be populated with values.
		/// </param>
		/// <returns>The nearest touchable view, or null if none exists.</returns>
		public virtual android.view.View findNearestTouchable(android.view.ViewGroup root
			, int x, int y, int direction, int[] deltas)
		{
			java.util.ArrayList<android.view.View> touchables = root.getTouchables();
			int minDistance = int.MaxValue;
			android.view.View closest = null;
			int numTouchables = touchables.size();
			int edgeSlop = android.view.ViewConfiguration.get(root.mContext).getScaledEdgeSlop
				();
			android.graphics.Rect closestBounds = new android.graphics.Rect();
			android.graphics.Rect touchableBounds = mOtherRect;
			{
				for (int i = 0; i < numTouchables; i++)
				{
					android.view.View touchable = touchables.get(i);
					// get visible bounds of other view in same coordinate system
					touchable.getDrawingRect(touchableBounds);
					root.offsetRectBetweenParentAndChild(touchable, touchableBounds, true, true);
					if (!isTouchCandidate(x, y, touchableBounds, direction))
					{
						continue;
					}
					int distance = int.MaxValue;
					switch (direction)
					{
						case android.view.View.FOCUS_LEFT:
						{
							distance = x - touchableBounds.right + 1;
							break;
						}

						case android.view.View.FOCUS_RIGHT:
						{
							distance = touchableBounds.left;
							break;
						}

						case android.view.View.FOCUS_UP:
						{
							distance = y - touchableBounds.bottom + 1;
							break;
						}

						case android.view.View.FOCUS_DOWN:
						{
							distance = touchableBounds.top;
							break;
						}
					}
					if (distance < edgeSlop)
					{
						// Give preference to innermost views
						if (closest == null || closestBounds.contains(touchableBounds) || (!touchableBounds
							.contains(closestBounds) && distance < minDistance))
						{
							minDistance = distance;
							closest = touchable;
							closestBounds.set(touchableBounds);
							switch (direction)
							{
								case android.view.View.FOCUS_LEFT:
								{
									deltas[0] = -distance;
									break;
								}

								case android.view.View.FOCUS_RIGHT:
								{
									deltas[0] = distance;
									break;
								}

								case android.view.View.FOCUS_UP:
								{
									deltas[1] = -distance;
									break;
								}

								case android.view.View.FOCUS_DOWN:
								{
									deltas[1] = distance;
									break;
								}
							}
						}
					}
				}
			}
			return closest;
		}

		/// <summary>Is destRect a candidate for the next touch given the direction?</summary>
		private bool isTouchCandidate(int x, int y, android.graphics.Rect destRect, int direction
			)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_LEFT:
				{
					return destRect.left <= x && destRect.top <= y && y <= destRect.bottom;
				}

				case android.view.View.FOCUS_RIGHT:
				{
					return destRect.left >= x && destRect.top <= y && y <= destRect.bottom;
				}

				case android.view.View.FOCUS_UP:
				{
					return destRect.top <= y && destRect.left <= x && x <= destRect.right;
				}

				case android.view.View.FOCUS_DOWN:
				{
					return destRect.top >= y && destRect.left <= x && x <= destRect.right;
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT}."
				);
		}

		/// <summary>Sorts views according to their visual layout and geometry for default tab order.
		/// 	</summary>
		/// <remarks>
		/// Sorts views according to their visual layout and geometry for default tab order.
		/// This is used for sequential focus traversal.
		/// </remarks>
		private sealed class SequentialFocusComparator : java.util.Comparator<android.view.View
			>
		{
			internal readonly android.graphics.Rect mFirstRect = new android.graphics.Rect();

			internal readonly android.graphics.Rect mSecondRect = new android.graphics.Rect();

			internal android.view.ViewGroup mRoot;

			public void recycle()
			{
				mRoot = null;
			}

			public void setRoot(android.view.ViewGroup root)
			{
				mRoot = root;
			}

			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public int compare(android.view.View first, android.view.View second)
			{
				if (first == second)
				{
					return 0;
				}
				getRect(first, mFirstRect);
				getRect(second, mSecondRect);
				if (mFirstRect.top < mSecondRect.top)
				{
					return -1;
				}
				else
				{
					if (mFirstRect.top > mSecondRect.top)
					{
						return 1;
					}
					else
					{
						if (mFirstRect.left < mSecondRect.left)
						{
							return -1;
						}
						else
						{
							if (mFirstRect.left > mSecondRect.left)
							{
								return 1;
							}
							else
							{
								if (mFirstRect.bottom < mSecondRect.bottom)
								{
									return -1;
								}
								else
								{
									if (mFirstRect.bottom > mSecondRect.bottom)
									{
										return 1;
									}
									else
									{
										if (mFirstRect.right < mSecondRect.right)
										{
											return -1;
										}
										else
										{
											if (mFirstRect.right > mSecondRect.right)
											{
												return 1;
											}
											else
											{
												// The view are distinct but completely coincident so we consider
												// them equal for our purposes.  Since the sort is stable, this
												// means that the views will retain their layout order relative to one another.
												return 0;
											}
										}
									}
								}
							}
						}
					}
				}
			}

			internal void getRect(android.view.View view, android.graphics.Rect rect)
			{
				view.getDrawingRect(rect);
				mRoot.offsetDescendantRectToMyCoords(view, rect);
			}
		}
	}
}
