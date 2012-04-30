using Sharpen;

namespace android.util
{
	/// <summary>
	/// State sets are arrays of positive ints where each element
	/// represents the state of a
	/// <see cref="android.view.View">android.view.View</see>
	/// (e.g. focused,
	/// selected, visible, etc.).  A
	/// <see cref="android.view.View">android.view.View</see>
	/// may be in
	/// one or more of those states.
	/// A state spec is an array of signed ints where each element
	/// represents a required (if positive) or an undesired (if negative)
	/// <see cref="android.view.View">android.view.View</see>
	/// state.
	/// Utils dealing with state sets.
	/// In theory we could encapsulate the state set and state spec arrays
	/// and not have static methods here but there is some concern about
	/// performance since these methods are called during view drawing.
	/// </summary>
	[Sharpen.Sharpened]
	public class StateSet
	{
		/// <hide></hide>
		public StateSet()
		{
		}

		public static readonly int[] WILD_CARD = new int[0];

		public static readonly int[] NOTHING = new int[] { 0 };

		/// <summary>Return whether the stateSetOrSpec is matched by all StateSets.</summary>
		/// <remarks>Return whether the stateSetOrSpec is matched by all StateSets.</remarks>
		/// <param name="stateSetOrSpec">a state set or state spec.</param>
		public static bool isWildCard(int[] stateSetOrSpec)
		{
			return stateSetOrSpec.Length == 0 || stateSetOrSpec[0] == 0;
		}

		/// <summary>Return whether the stateSet matches the desired stateSpec.</summary>
		/// <remarks>Return whether the stateSet matches the desired stateSpec.</remarks>
		/// <param name="stateSpec">
		/// an array of required (if positive) or
		/// prohibited (if negative)
		/// <see cref="android.view.View">android.view.View</see>
		/// states.
		/// </param>
		/// <param name="stateSet">
		/// an array of
		/// <see cref="android.view.View">android.view.View</see>
		/// states
		/// </param>
		public static bool stateSetMatches(int[] stateSpec, int[] stateSet)
		{
			if (stateSet == null)
			{
				return (stateSpec == null || isWildCard(stateSpec));
			}
			int stateSpecSize = stateSpec.Length;
			int stateSetSize = stateSet.Length;
			{
				for (int i = 0; i < stateSpecSize; i++)
				{
					int stateSpecState = stateSpec[i];
					if (stateSpecState == 0)
					{
						// We've reached the end of the cases to match against.
						return true;
					}
					bool mustMatch;
					if (stateSpecState > 0)
					{
						mustMatch = true;
					}
					else
					{
						// We use negative values to indicate must-NOT-match states.
						mustMatch = false;
						stateSpecState = -stateSpecState;
					}
					bool found = false;
					{
						for (int j = 0; j < stateSetSize; j++)
						{
							int state = stateSet[j];
							if (state == 0)
							{
								// We've reached the end of states to match.
								if (mustMatch)
								{
									// We didn't find this must-match state.
									return false;
								}
								else
								{
									// Continue checking other must-not-match states.
									break;
								}
							}
							if (state == stateSpecState)
							{
								if (mustMatch)
								{
									found = true;
									// Continue checking other other must-match states.
									break;
								}
								else
								{
									// Any match of a must-not-match state returns false.
									return false;
								}
							}
						}
					}
					if (mustMatch && !found)
					{
						// We've reached the end of states to match and we didn't
						// find a must-match state.
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Return whether the state matches the desired stateSpec.</summary>
		/// <remarks>Return whether the state matches the desired stateSpec.</remarks>
		/// <param name="stateSpec">
		/// an array of required (if positive) or
		/// prohibited (if negative)
		/// <see cref="android.view.View">android.view.View</see>
		/// states.
		/// </param>
		/// <param name="state">
		/// a
		/// <see cref="android.view.View">android.view.View</see>
		/// state
		/// </param>
		public static bool stateSetMatches(int[] stateSpec, int state)
		{
			int stateSpecSize = stateSpec.Length;
			{
				for (int i = 0; i < stateSpecSize; i++)
				{
					int stateSpecState = stateSpec[i];
					if (stateSpecState == 0)
					{
						// We've reached the end of the cases to match against.
						return true;
					}
					if (stateSpecState > 0)
					{
						if (state != stateSpecState)
						{
							return false;
						}
					}
					else
					{
						// We use negative values to indicate must-NOT-match states.
						if (state == -stateSpecState)
						{
							// We matched a must-not-match case.
							return false;
						}
					}
				}
			}
			return true;
		}

		public static int[] trimStateSet(int[] states, int newSize)
		{
			if (states.Length == newSize)
			{
				return states;
			}
			int[] trimmedStates = new int[newSize];
			System.Array.Copy(states, 0, trimmedStates, 0, newSize);
			return trimmedStates;
		}

		public static string dump(int[] states)
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			int count = states.Length;
			{
				for (int i = 0; i < count; i++)
				{
					switch (states[i])
					{
						case android.@internal.R.attr.state_window_focused:
						{
							sb.append("W ");
							break;
						}

						case android.@internal.R.attr.state_pressed:
						{
							sb.append("P ");
							break;
						}

						case android.@internal.R.attr.state_selected:
						{
							sb.append("S ");
							break;
						}

						case android.@internal.R.attr.state_focused:
						{
							sb.append("F ");
							break;
						}

						case android.@internal.R.attr.state_enabled:
						{
							sb.append("E ");
							break;
						}
					}
				}
			}
			return sb.ToString();
		}
	}
}
