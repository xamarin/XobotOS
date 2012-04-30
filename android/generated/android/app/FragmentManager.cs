using Sharpen;

namespace android.app
{
	/// <summary>
	/// Interface for interacting with
	/// <see cref="Fragment">Fragment</see>
	/// objects inside of an
	/// <see cref="Activity">Activity</see>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about using fragments, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/fundamentals/fragments.html"&gt;Fragments</a> developer guide.</p>
	/// </div>
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class FragmentManager
	{
		/// <summary>
		/// Representation of an entry on the fragment back stack, as created
		/// with
		/// <see cref="FragmentTransaction.addToBackStack(string)">FragmentTransaction.addToBackStack()
		/// 	</see>
		/// .  Entries can later be
		/// retrieved with
		/// <see cref="FragmentManager.getBackStackEntryAt(int)">FragmentManager.getBackStackEntry()
		/// 	</see>
		/// .
		/// <p>Note that you should never hold on to a BackStackEntry object;
		/// the identifier as returned by
		/// <see cref="getId()">getId()</see>
		/// is the only thing that
		/// will be persisted across activity instances.
		/// </summary>
		public interface BackStackEntry
		{
			/// <summary>Return the unique identifier for the entry.</summary>
			/// <remarks>
			/// Return the unique identifier for the entry.  This is the only
			/// representation of the entry that will persist across activity
			/// instances.
			/// </remarks>
			int getId();

			/// <summary>
			/// Get the name that was supplied to
			/// <see cref="FragmentTransaction.addToBackStack(string)">FragmentTransaction.addToBackStack(String)
			/// 	</see>
			/// when creating this entry.
			/// </summary>
			string getName();

			/// <summary>
			/// Return the full bread crumb title resource identifier for the entry,
			/// or 0 if it does not have one.
			/// </summary>
			/// <remarks>
			/// Return the full bread crumb title resource identifier for the entry,
			/// or 0 if it does not have one.
			/// </remarks>
			int getBreadCrumbTitleRes();

			/// <summary>
			/// Return the short bread crumb title resource identifier for the entry,
			/// or 0 if it does not have one.
			/// </summary>
			/// <remarks>
			/// Return the short bread crumb title resource identifier for the entry,
			/// or 0 if it does not have one.
			/// </remarks>
			int getBreadCrumbShortTitleRes();

			/// <summary>
			/// Return the full bread crumb title for the entry, or null if it
			/// does not have one.
			/// </summary>
			/// <remarks>
			/// Return the full bread crumb title for the entry, or null if it
			/// does not have one.
			/// </remarks>
			java.lang.CharSequence getBreadCrumbTitle();

			/// <summary>
			/// Return the short bread crumb title for the entry, or null if it
			/// does not have one.
			/// </summary>
			/// <remarks>
			/// Return the short bread crumb title for the entry, or null if it
			/// does not have one.
			/// </remarks>
			java.lang.CharSequence getBreadCrumbShortTitle();
		}

		/// <summary>Interface to watch for changes to the back stack.</summary>
		/// <remarks>Interface to watch for changes to the back stack.</remarks>
		public interface OnBackStackChangedListener
		{
			/// <summary>Called whenever the contents of the back stack change.</summary>
			/// <remarks>Called whenever the contents of the back stack change.</remarks>
			void onBackStackChanged();
		}

		/// <summary>
		/// Start a series of edit operations on the Fragments associated with
		/// this FragmentManager.
		/// </summary>
		/// <remarks>
		/// Start a series of edit operations on the Fragments associated with
		/// this FragmentManager.
		/// <p>Note: A fragment transaction can only be created/committed prior
		/// to an activity saving its state.  If you try to commit a transaction
		/// after
		/// <see cref="Activity.onSaveInstanceState(android.os.Bundle)">Activity.onSaveInstanceState()
		/// 	</see>
		/// (and prior to a following
		/// <see cref="Activity.onStart()">Activity.onStart</see>
		/// or
		/// <see cref="Activity.onResume()">Activity.onResume()</see>
		/// , you will get an error.
		/// This is because the framework takes care of saving your current fragments
		/// in the state, and if changes are made after the state is saved then they
		/// will be lost.</p>
		/// </remarks>
		public abstract android.app.FragmentTransaction beginTransaction();

		/// <hide>-- remove once prebuilts are in.</hide>
		[System.Obsolete]
		public virtual android.app.FragmentTransaction openTransaction()
		{
			return beginTransaction();
		}

		/// <summary>
		/// After a
		/// <see cref="FragmentTransaction">FragmentTransaction</see>
		/// is committed with
		/// <see cref="FragmentTransaction.commit()">FragmentTransaction.commit()</see>
		/// , it
		/// is scheduled to be executed asynchronously on the process's main thread.
		/// If you want to immediately executing any such pending operations, you
		/// can call this function (only from the main thread) to do so.  Note that
		/// all callbacks and other related behavior will be done from within this
		/// call, so be careful about where this is called from.
		/// </summary>
		/// <returns>
		/// Returns true if there were any pending transactions to be
		/// executed.
		/// </returns>
		public abstract bool executePendingTransactions();

		/// <summary>
		/// Finds a fragment that was identified by the given id either when inflated
		/// from XML or as the container ID when added in a transaction.
		/// </summary>
		/// <remarks>
		/// Finds a fragment that was identified by the given id either when inflated
		/// from XML or as the container ID when added in a transaction.  This first
		/// searches through fragments that are currently added to the manager's
		/// activity; if no such fragment is found, then all fragments currently
		/// on the back stack associated with this ID are searched.
		/// </remarks>
		/// <returns>The fragment if found or null otherwise.</returns>
		public abstract android.app.Fragment findFragmentById(int id);

		/// <summary>
		/// Finds a fragment that was identified by the given tag either when inflated
		/// from XML or as supplied when added in a transaction.
		/// </summary>
		/// <remarks>
		/// Finds a fragment that was identified by the given tag either when inflated
		/// from XML or as supplied when added in a transaction.  This first
		/// searches through fragments that are currently added to the manager's
		/// activity; if no such fragment is found, then all fragments currently
		/// on the back stack are searched.
		/// </remarks>
		/// <returns>The fragment if found or null otherwise.</returns>
		public abstract android.app.Fragment findFragmentByTag(string tag);

		/// <summary>
		/// Flag for
		/// <see cref="popBackStack(string, int)">popBackStack(string, int)</see>
		/// and
		/// <see cref="popBackStack(int, int)">popBackStack(int, int)</see>
		/// : If set, and the name or ID of
		/// a back stack entry has been supplied, then all matching entries will
		/// be consumed until one that doesn't match is found or the bottom of
		/// the stack is reached.  Otherwise, all entries up to but not including that entry
		/// will be removed.
		/// </summary>
		public const int POP_BACK_STACK_INCLUSIVE = 1 << 0;

		/// <summary>Pop the top state off the back stack.</summary>
		/// <remarks>
		/// Pop the top state off the back stack.  This function is asynchronous -- it
		/// enqueues the request to pop, but the action will not be performed until the
		/// application returns to its event loop.
		/// </remarks>
		public abstract void popBackStack();

		/// <summary>
		/// Like
		/// <see cref="popBackStack()">popBackStack()</see>
		/// , but performs the operation immediately
		/// inside of the call.  This is like calling
		/// <see cref="executePendingTransactions()">executePendingTransactions()</see>
		/// afterwards.
		/// </summary>
		/// <returns>Returns true if there was something popped, else false.</returns>
		public abstract bool popBackStackImmediate();

		/// <summary>
		/// Pop the last fragment transition from the manager's fragment
		/// back stack.
		/// </summary>
		/// <remarks>
		/// Pop the last fragment transition from the manager's fragment
		/// back stack.  If there is nothing to pop, false is returned.
		/// This function is asynchronous -- it enqueues the
		/// request to pop, but the action will not be performed until the application
		/// returns to its event loop.
		/// </remarks>
		/// <param name="name">
		/// If non-null, this is the name of a previous back state
		/// to look for; if found, all states up to that state will be popped.  The
		/// <see cref="POP_BACK_STACK_INCLUSIVE">POP_BACK_STACK_INCLUSIVE</see>
		/// flag can be used to control whether
		/// the named state itself is popped. If null, only the top state is popped.
		/// </param>
		/// <param name="flags">
		/// Either 0 or
		/// <see cref="POP_BACK_STACK_INCLUSIVE">POP_BACK_STACK_INCLUSIVE</see>
		/// .
		/// </param>
		public abstract void popBackStack(string name, int flags);

		/// <summary>
		/// Like
		/// <see cref="popBackStack(string, int)">popBackStack(string, int)</see>
		/// , but performs the operation immediately
		/// inside of the call.  This is like calling
		/// <see cref="executePendingTransactions()">executePendingTransactions()</see>
		/// afterwards.
		/// </summary>
		/// <returns>Returns true if there was something popped, else false.</returns>
		public abstract bool popBackStackImmediate(string name, int flags);

		/// <summary>Pop all back stack states up to the one with the given identifier.</summary>
		/// <remarks>
		/// Pop all back stack states up to the one with the given identifier.
		/// This function is asynchronous -- it enqueues the
		/// request to pop, but the action will not be performed until the application
		/// returns to its event loop.
		/// </remarks>
		/// <param name="id">
		/// Identifier of the stated to be popped. If no identifier exists,
		/// false is returned.
		/// The identifier is the number returned by
		/// <see cref="FragmentTransaction.commit()">FragmentTransaction.commit()</see>
		/// .  The
		/// <see cref="POP_BACK_STACK_INCLUSIVE">POP_BACK_STACK_INCLUSIVE</see>
		/// flag can be used to control whether
		/// the named state itself is popped.
		/// </param>
		/// <param name="flags">
		/// Either 0 or
		/// <see cref="POP_BACK_STACK_INCLUSIVE">POP_BACK_STACK_INCLUSIVE</see>
		/// .
		/// </param>
		public abstract void popBackStack(int id, int flags);

		/// <summary>
		/// Like
		/// <see cref="popBackStack(int, int)">popBackStack(int, int)</see>
		/// , but performs the operation immediately
		/// inside of the call.  This is like calling
		/// <see cref="executePendingTransactions()">executePendingTransactions()</see>
		/// afterwards.
		/// </summary>
		/// <returns>Returns true if there was something popped, else false.</returns>
		public abstract bool popBackStackImmediate(int id, int flags);

		/// <summary>Return the number of entries currently in the back stack.</summary>
		/// <remarks>Return the number of entries currently in the back stack.</remarks>
		public abstract int getBackStackEntryCount();

		/// <summary>
		/// Return the BackStackEntry at index <var>index</var> in the back stack;
		/// entries start index 0 being the bottom of the stack.
		/// </summary>
		/// <remarks>
		/// Return the BackStackEntry at index <var>index</var> in the back stack;
		/// entries start index 0 being the bottom of the stack.
		/// </remarks>
		public abstract android.app.FragmentManager.BackStackEntry getBackStackEntryAt(int
			 index);

		/// <summary>Add a new listener for changes to the fragment back stack.</summary>
		/// <remarks>Add a new listener for changes to the fragment back stack.</remarks>
		public abstract void addOnBackStackChangedListener(android.app.FragmentManager.OnBackStackChangedListener
			 listener);

		/// <summary>
		/// Remove a listener that was previously added with
		/// <see cref="addOnBackStackChangedListener(OnBackStackChangedListener)">addOnBackStackChangedListener(OnBackStackChangedListener)
		/// 	</see>
		/// .
		/// </summary>
		public abstract void removeOnBackStackChangedListener(android.app.FragmentManager
			.OnBackStackChangedListener listener);

		/// <summary>Put a reference to a fragment in a Bundle.</summary>
		/// <remarks>
		/// Put a reference to a fragment in a Bundle.  This Bundle can be
		/// persisted as saved state, and when later restoring
		/// <see cref="getFragment(android.os.Bundle, string)">getFragment(android.os.Bundle, string)
		/// 	</see>
		/// will return the current
		/// instance of the same fragment.
		/// </remarks>
		/// <param name="bundle">The bundle in which to put the fragment reference.</param>
		/// <param name="key">The name of the entry in the bundle.</param>
		/// <param name="fragment">The Fragment whose reference is to be stored.</param>
		public abstract void putFragment(android.os.Bundle bundle, string key, android.app.Fragment
			 fragment);

		/// <summary>
		/// Retrieve the current Fragment instance for a reference previously
		/// placed with
		/// <see cref="putFragment(android.os.Bundle, string, Fragment)">putFragment(android.os.Bundle, string, Fragment)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="bundle">The bundle from which to retrieve the fragment reference.</param>
		/// <param name="key">The name of the entry in the bundle.</param>
		/// <returns>
		/// Returns the current Fragment instance that is associated with
		/// the given reference.
		/// </returns>
		public abstract android.app.Fragment getFragment(android.os.Bundle bundle, string
			 key);

		/// <summary>Save the current instance state of the given Fragment.</summary>
		/// <remarks>
		/// Save the current instance state of the given Fragment.  This can be
		/// used later when creating a new instance of the Fragment and adding
		/// it to the fragment manager, to have it create itself to match the
		/// current state returned here.  Note that there are limits on how
		/// this can be used:
		/// <ul>
		/// <li>The Fragment must currently be attached to the FragmentManager.
		/// <li>A new Fragment created using this saved state must be the same class
		/// type as the Fragment it was created from.
		/// <li>The saved state can not contain dependencies on other fragments --
		/// that is it can't use
		/// <see cref="putFragment(android.os.Bundle, string, Fragment)">putFragment(android.os.Bundle, string, Fragment)
		/// 	</see>
		/// to
		/// store a fragment reference because that reference may not be valid when
		/// this saved state is later used.  Likewise the Fragment's target and
		/// result code are not included in this state.
		/// </ul>
		/// </remarks>
		/// <param name="f">The Fragment whose state is to be saved.</param>
		/// <returns>
		/// The generated state.  This will be null if there was no
		/// interesting state created by the fragment.
		/// </returns>
		public abstract android.app.Fragment.SavedState saveFragmentInstanceState(android.app.Fragment
			 f);

		/// <summary>Print the FragmentManager's state into the given stream.</summary>
		/// <remarks>Print the FragmentManager's state into the given stream.</remarks>
		/// <param name="prefix">Text to print at the front of each line.</param>
		/// <param name="fd">The raw file descriptor that the dump is being sent to.</param>
		/// <param name="writer">A PrintWriter to which the dump is to be set.</param>
		/// <param name="args">Additional arguments to the dump request.</param>
		public abstract void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args);

		/// <summary>
		/// Control whether the framework's internal fragment manager debugging
		/// logs are turned on.
		/// </summary>
		/// <remarks>
		/// Control whether the framework's internal fragment manager debugging
		/// logs are turned on.  If enabled, you will see output in logcat as
		/// the framework performs fragment operations.
		/// </remarks>
		public static void enableDebugLogging(bool enabled)
		{
			android.app.FragmentManagerImpl.DEBUG = enabled;
		}

		/// <summary>Invalidate the attached activity's options menu as necessary.</summary>
		/// <remarks>
		/// Invalidate the attached activity's options menu as necessary.
		/// This may end up being deferred until we move to the resumed state.
		/// </remarks>
		public virtual void invalidateOptionsMenu()
		{
		}
	}

	[Sharpen.Sharpened]
	internal sealed class FragmentManagerState : android.os.Parcelable
	{
		internal android.app.FragmentState[] mActive;

		internal int[] mAdded;

		internal android.app.BackStackState[] mBackStack;

		public FragmentManagerState()
		{
		}

		public FragmentManagerState(android.os.Parcel @in)
		{
			mActive = @in.createTypedArray(android.app.FragmentState.CREATOR);
			mAdded = @in.createIntArray();
			mBackStack = @in.createTypedArray(android.app.BackStackState.CREATOR);
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			dest.writeTypedArray(mActive, flags);
			dest.writeIntArray(mAdded);
			dest.writeTypedArray(mBackStack, flags);
		}

		private sealed class _Creator_364 : android.os.ParcelableClass.Creator<android.app.FragmentManagerState
			>
		{
			public _Creator_364()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.FragmentManagerState createFromParcel(android.os.Parcel @in)
			{
				return new android.app.FragmentManagerState(@in);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.FragmentManagerState[] newArray(int size)
			{
				return new android.app.FragmentManagerState[size];
			}
		}

		internal static readonly android.os.ParcelableClass.Creator<android.app.FragmentManagerState
			> CREATOR = new _Creator_364();
	}

	/// <summary>Container for fragments associated with an activity.</summary>
	/// <remarks>Container for fragments associated with an activity.</remarks>
	[Sharpen.Sharpened]
	internal sealed partial class FragmentManagerImpl : android.app.FragmentManager
	{
		internal static bool DEBUG = false;

		internal const string TAG = "FragmentManager";

		internal const string TARGET_REQUEST_CODE_STATE_TAG = "android:target_req_state";

		internal const string TARGET_STATE_TAG = "android:target_state";

		internal const string VIEW_STATE_TAG = "android:view_state";

		internal java.util.ArrayList<java.lang.Runnable> mPendingActions;

		internal java.lang.Runnable[] mTmpActions;

		internal bool mExecutingActions;

		internal java.util.ArrayList<android.app.Fragment> mActive;

		internal java.util.ArrayList<android.app.Fragment> mAdded;

		internal java.util.ArrayList<int> mAvailIndices;

		internal java.util.ArrayList<android.app.BackStackRecord> mBackStack;

		internal java.util.ArrayList<android.app.Fragment> mCreatedMenus;

		internal java.util.ArrayList<android.app.BackStackRecord> mBackStackIndices;

		internal java.util.ArrayList<int> mAvailBackStackIndices;

		internal java.util.ArrayList<android.app.FragmentManager.OnBackStackChangedListener
			> mBackStackChangeListeners;

		internal int mCurState = android.app.Fragment.INITIALIZING;

		internal android.app.Activity mActivity;

		internal bool mNeedMenuInvalidate;

		internal bool mStateSaved;

		internal bool mDestroyed;

		internal string mNoTransactionsBecause;

		internal android.os.Bundle mStateBundle = null;

		internal android.util.SparseArray<android.os.Parcelable> mStateArray = null;

		private sealed class _Runnable_414 : java.lang.Runnable
		{
			public _Runnable_414(FragmentManagerImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Must be accessed while locked.
			// Temporary vars for state save and restore.
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.execPendingActions();
			}

			private readonly FragmentManagerImpl _enclosing;
		}

		internal java.lang.Runnable mExecCommit;

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override android.app.FragmentTransaction beginTransaction()
		{
			return new android.app.BackStackRecord(this);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override bool executePendingTransactions()
		{
			return execPendingActions();
		}

		private sealed class _Runnable_433 : java.lang.Runnable
		{
			public _Runnable_433(FragmentManagerImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.popBackStackState(this._enclosing.mActivity.mHandler, null, -1, 0
					);
			}

			private readonly FragmentManagerImpl _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void popBackStack()
		{
			enqueueAction(new _Runnable_433(this), false);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override bool popBackStackImmediate()
		{
			checkStateLoss();
			executePendingTransactions();
			return popBackStackState(mActivity.mHandler, null, -1, 0);
		}

		private sealed class _Runnable_449 : java.lang.Runnable
		{
			public _Runnable_449(FragmentManagerImpl _enclosing, string name, int flags)
			{
				this._enclosing = _enclosing;
				this.name = name;
				this.flags = flags;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.popBackStackState(this._enclosing.mActivity.mHandler, name, -1, flags
					);
			}

			private readonly FragmentManagerImpl _enclosing;

			private readonly string name;

			private readonly int flags;
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void popBackStack(string name, int flags)
		{
			enqueueAction(new _Runnable_449(this, name, flags), false);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override bool popBackStackImmediate(string name, int flags)
		{
			checkStateLoss();
			executePendingTransactions();
			return popBackStackState(mActivity.mHandler, name, -1, flags);
		}

		private sealed class _Runnable_468 : java.lang.Runnable
		{
			public _Runnable_468(FragmentManagerImpl _enclosing, int id, int flags)
			{
				this._enclosing = _enclosing;
				this.id = id;
				this.flags = flags;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.popBackStackState(this._enclosing.mActivity.mHandler, null, id, flags
					);
			}

			private readonly FragmentManagerImpl _enclosing;

			private readonly int id;

			private readonly int flags;
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void popBackStack(int id, int flags)
		{
			if (id < 0)
			{
				throw new System.ArgumentException("Bad id: " + id);
			}
			enqueueAction(new _Runnable_468(this, id, flags), false);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override bool popBackStackImmediate(int id, int flags)
		{
			checkStateLoss();
			executePendingTransactions();
			if (id < 0)
			{
				throw new System.ArgumentException("Bad id: " + id);
			}
			return popBackStackState(mActivity.mHandler, null, id, flags);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override int getBackStackEntryCount()
		{
			return mBackStack != null ? mBackStack.size() : 0;
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override android.app.FragmentManager.BackStackEntry getBackStackEntryAt(int
			 index)
		{
			return mBackStack.get(index);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void addOnBackStackChangedListener(android.app.FragmentManager.OnBackStackChangedListener
			 listener)
		{
			if (mBackStackChangeListeners == null)
			{
				mBackStackChangeListeners = new java.util.ArrayList<android.app.FragmentManager.OnBackStackChangedListener
					>();
			}
			mBackStackChangeListeners.add(listener);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void removeOnBackStackChangedListener(android.app.FragmentManager
			.OnBackStackChangedListener listener)
		{
			if (mBackStackChangeListeners != null)
			{
				mBackStackChangeListeners.remove(listener);
			}
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void putFragment(android.os.Bundle bundle, string key, android.app.Fragment
			 fragment)
		{
			if (fragment.mIndex < 0)
			{
				throw new System.InvalidOperationException("Fragment " + fragment + " is not currently in the FragmentManager"
					);
			}
			bundle.putInt(key, fragment.mIndex);
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override android.app.Fragment getFragment(android.os.Bundle bundle, string
			 key)
		{
			int index = bundle.getInt(key, -1);
			if (index == -1)
			{
				return null;
			}
			if (index >= mActive.size())
			{
				throw new System.InvalidOperationException("Fragement no longer exists for key " 
					+ key + ": index " + index);
			}
			android.app.Fragment f = mActive.get(index);
			if (f == null)
			{
				throw new System.InvalidOperationException("Fragement no longer exists for key " 
					+ key + ": index " + index);
			}
			return f;
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override android.app.Fragment.SavedState saveFragmentInstanceState(android.app.Fragment
			 fragment)
		{
			if (fragment.mIndex < 0)
			{
				throw new System.InvalidOperationException("Fragment " + fragment + " is not currently in the FragmentManager"
					);
			}
			if (fragment.mState > android.app.Fragment.INITIALIZING)
			{
				android.os.Bundle result = saveFragmentBasicState(fragment);
				return result != null ? new android.app.Fragment.SavedState(result) : null;
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(128);
			sb.append("FragmentManager{");
			sb.append(Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this)));
			sb.append(" in ");
			android.util.DebugUtils.buildShortClassTag(mActivity, sb);
			sb.append("}}");
			return sb.ToString();
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			string innerPrefix = prefix + "    ";
			int N;
			if (mActive != null)
			{
				N = mActive.size();
				if (N > 0)
				{
					writer.print(prefix);
					writer.print("Active Fragments in ");
					writer.print(Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this)));
					writer.println(":");
					{
						for (int i = 0; i < N; i++)
						{
							android.app.Fragment f = mActive.get(i);
							writer.print(prefix);
							writer.print("  #");
							writer.print(i);
							writer.print(": ");
							writer.println(f);
							if (f != null)
							{
								f.dump(innerPrefix, fd, writer, args);
							}
						}
					}
				}
			}
			if (mAdded != null)
			{
				N = mAdded.size();
				if (N > 0)
				{
					writer.print(prefix);
					writer.println("Added Fragments:");
					{
						for (int i = 0; i < N; i++)
						{
							android.app.Fragment f = mAdded.get(i);
							writer.print(prefix);
							writer.print("  #");
							writer.print(i);
							writer.print(": ");
							writer.println(f.ToString());
						}
					}
				}
			}
			if (mCreatedMenus != null)
			{
				N = mCreatedMenus.size();
				if (N > 0)
				{
					writer.print(prefix);
					writer.println("Fragments Created Menus:");
					{
						for (int i = 0; i < N; i++)
						{
							android.app.Fragment f = mCreatedMenus.get(i);
							writer.print(prefix);
							writer.print("  #");
							writer.print(i);
							writer.print(": ");
							writer.println(f.ToString());
						}
					}
				}
			}
			if (mBackStack != null)
			{
				N = mBackStack.size();
				if (N > 0)
				{
					writer.print(prefix);
					writer.println("Back Stack:");
					{
						for (int i = 0; i < N; i++)
						{
							android.app.BackStackRecord bs = mBackStack.get(i);
							writer.print(prefix);
							writer.print("  #");
							writer.print(i);
							writer.print(": ");
							writer.println(bs.ToString());
							bs.dump(innerPrefix, fd, writer, args);
						}
					}
				}
			}
			lock (this)
			{
				if (mBackStackIndices != null)
				{
					N = mBackStackIndices.size();
					if (N > 0)
					{
						writer.print(prefix);
						writer.println("Back Stack Indices:");
						{
							for (int i = 0; i < N; i++)
							{
								android.app.BackStackRecord bs = mBackStackIndices.get(i);
								writer.print(prefix);
								writer.print("  #");
								writer.print(i);
								writer.print(": ");
								writer.println(bs);
							}
						}
					}
				}
				if (mAvailBackStackIndices != null && mAvailBackStackIndices.size() > 0)
				{
					writer.print(prefix);
					writer.print("mAvailBackStackIndices: ");
					writer.println(java.util.Arrays.toString(mAvailBackStackIndices.toArray()));
				}
			}
			if (mPendingActions != null)
			{
				N = mPendingActions.size();
				if (N > 0)
				{
					writer.print(prefix);
					writer.println("Pending Actions:");
					{
						for (int i = 0; i < N; i++)
						{
							java.lang.Runnable r = mPendingActions.get(i);
							writer.print(prefix);
							writer.print("  #");
							writer.print(i);
							writer.print(": ");
							writer.println(r);
						}
					}
				}
			}
			writer.print(prefix);
			writer.println("FragmentManager misc state:");
			writer.print(prefix);
			writer.print("  mCurState=");
			writer.print(mCurState);
			writer.print(" mStateSaved=");
			writer.print(mStateSaved);
			writer.print(" mDestroyed=");
			writer.println(mDestroyed);
			if (mNeedMenuInvalidate)
			{
				writer.print(prefix);
				writer.print("  mNeedMenuInvalidate=");
				writer.println(mNeedMenuInvalidate);
			}
			if (mNoTransactionsBecause != null)
			{
				writer.print(prefix);
				writer.print("  mNoTransactionsBecause=");
				writer.println(mNoTransactionsBecause);
			}
			if (mAvailIndices != null && mAvailIndices.size() > 0)
			{
				writer.print(prefix);
				writer.print("  mAvailIndices: ");
				writer.println(java.util.Arrays.toString(mAvailIndices.toArray()));
			}
		}

		internal android.animation.Animator loadAnimator(android.app.Fragment fragment, int
			 transit, bool enter, int transitionStyle)
		{
			android.animation.Animator animObj = fragment.onCreateAnimator(transit, enter, fragment
				.mNextAnim);
			if (animObj != null)
			{
				return animObj;
			}
			if (fragment.mNextAnim != 0)
			{
				android.animation.Animator anim = android.animation.AnimatorInflater.loadAnimator
					(mActivity, fragment.mNextAnim);
				if (anim != null)
				{
					return anim;
				}
			}
			if (transit == 0)
			{
				return null;
			}
			int styleIndex = transitToStyleIndex(transit, enter);
			if (styleIndex < 0)
			{
				return null;
			}
			if (transitionStyle == 0 && mActivity.getWindow() != null)
			{
				transitionStyle = mActivity.getWindow().getAttributes().windowAnimations;
			}
			if (transitionStyle == 0)
			{
				return null;
			}
			android.content.res.TypedArray attrs = mActivity.obtainStyledAttributes(transitionStyle
				, android.@internal.R.styleable.FragmentAnimation);
			int anim_1 = attrs.getResourceId(styleIndex, 0);
			attrs.recycle();
			if (anim_1 == 0)
			{
				return null;
			}
			return android.animation.AnimatorInflater.loadAnimator(mActivity, anim_1);
		}

		private sealed class _AnimatorListenerAdapter_903 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_903(FragmentManagerImpl _enclosing, android.view.ViewGroup
				 container, android.view.View view, android.app.Fragment fragment)
			{
				this._enclosing = _enclosing;
				this.container = container;
				this.view = view;
				this.fragment = fragment;
			}

			// Fragments that are not currently added will sit in the onCreate() state.
			// While removing a fragment, we can't change it to a higher state.
			// For fragments that are created from a layout, when restoring from
			// state we don't want to allow them to be created until they are
			// being reloaded from the layout.
			// The fragment is currently being animated...  but!  Now we
			// want to move our state back up.  Give up on waiting for the
			// animation, move to whatever the final state should be once
			// the animation is done, and then we can proceed from there.
			// For fragments that are part of the content view
			// layout, we need to instantiate the view immediately
			// and the inflater will take care of adding it.
			// Get rid of this in case we saved it and never needed it.
			// Need to save the current view state if not
			// done already.
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator anim_1)
			{
				container.endViewTransition(view);
				if (fragment.mAnimatingAway != null)
				{
					fragment.mAnimatingAway = null;
					this._enclosing.moveToState(fragment, fragment.mStateAfterAnimating, 0, 0);
				}
			}

			private readonly FragmentManagerImpl _enclosing;

			private readonly android.view.ViewGroup container;

			private readonly android.view.View view;

			private readonly android.app.Fragment fragment;
		}

		internal void moveToState(android.app.Fragment f, int newState, int transit, int 
			transitionStyle)
		{
			if (!f.mAdded && newState > android.app.Fragment.CREATED)
			{
				newState = android.app.Fragment.CREATED;
			}
			if (f.mRemoving && newState > f.mState)
			{
				newState = f.mState;
			}
			if (f.mState < newState)
			{
				if (f.mFromLayout && !f.mInLayout)
				{
					return;
				}
				if (f.mAnimatingAway != null)
				{
					f.mAnimatingAway = null;
					moveToState(f, f.mStateAfterAnimating, 0, 0);
				}
				switch (f.mState)
				{
					case android.app.Fragment.INITIALIZING:
					{
						if (DEBUG)
						{
							android.util.Log.v(TAG, "moveto CREATED: " + f);
						}
						if (f.mSavedFragmentState != null)
						{
							f.mSavedViewState = f.mSavedFragmentState.getSparseParcelableArray<android.os.Parcelable
								>(android.app.FragmentManagerImpl.VIEW_STATE_TAG);
							f.mTarget = getFragment(f.mSavedFragmentState, android.app.FragmentManagerImpl.TARGET_STATE_TAG
								);
							if (f.mTarget != null)
							{
								f.mTargetRequestCode = f.mSavedFragmentState.getInt(android.app.FragmentManagerImpl
									.TARGET_REQUEST_CODE_STATE_TAG, 0);
							}
						}
						f.mActivity = mActivity;
						f.mFragmentManager = mActivity.mFragments;
						f.mCalled = false;
						f.onAttach(mActivity);
						if (!f.mCalled)
						{
							throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onAttach()"
								);
						}
						mActivity.onAttachFragment(f);
						if (!f.mRetaining)
						{
							f.mCalled = false;
							f.onCreate(f.mSavedFragmentState);
							if (!f.mCalled)
							{
								throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onCreate()"
									);
							}
						}
						f.mRetaining = false;
						if (f.mFromLayout)
						{
							f.mView = f.onCreateView(f.getLayoutInflater(f.mSavedFragmentState), null, f.mSavedFragmentState
								);
							if (f.mView != null)
							{
								f.mView.setSaveFromParentEnabled(false);
								if (f.mHidden)
								{
									f.mView.setVisibility(android.view.View.GONE);
								}
								f.onViewCreated(f.mView, f.mSavedFragmentState);
							}
						}
						goto case android.app.Fragment.CREATED;
					}

					case android.app.Fragment.CREATED:
					{
						if (newState > android.app.Fragment.CREATED)
						{
							if (DEBUG)
							{
								android.util.Log.v(TAG, "moveto ACTIVITY_CREATED: " + f);
							}
							if (!f.mFromLayout)
							{
								android.view.ViewGroup container = null;
								if (f.mContainerId != 0)
								{
									container = (android.view.ViewGroup)mActivity.findViewById(f.mContainerId);
									if (container == null && !f.mRestored)
									{
										throw new System.ArgumentException("No view found for id 0x" + Sharpen.Util.IntToHexString
											(f.mContainerId) + " for fragment " + f);
									}
								}
								f.mContainer = container;
								f.mView = f.onCreateView(f.getLayoutInflater(f.mSavedFragmentState), container, f
									.mSavedFragmentState);
								if (f.mView != null)
								{
									f.mView.setSaveFromParentEnabled(false);
									if (container != null)
									{
										android.animation.Animator anim = loadAnimator(f, transit, true, transitionStyle);
										if (anim != null)
										{
											anim.setTarget(f.mView);
											anim.start();
										}
										container.addView(f.mView);
									}
									if (f.mHidden)
									{
										f.mView.setVisibility(android.view.View.GONE);
									}
									f.onViewCreated(f.mView, f.mSavedFragmentState);
								}
							}
							f.mCalled = false;
							f.onActivityCreated(f.mSavedFragmentState);
							if (!f.mCalled)
							{
								throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onActivityCreated()"
									);
							}
							if (f.mView != null)
							{
								f.restoreViewState();
							}
							f.mSavedFragmentState = null;
						}
						goto case android.app.Fragment.ACTIVITY_CREATED;
					}

					case android.app.Fragment.ACTIVITY_CREATED:
					case android.app.Fragment.STOPPED:
					{
						if (newState > android.app.Fragment.STOPPED)
						{
							if (DEBUG)
							{
								android.util.Log.v(TAG, "moveto STARTED: " + f);
							}
							f.mCalled = false;
							f.performStart();
							if (!f.mCalled)
							{
								throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onStart()"
									);
							}
						}
						goto case android.app.Fragment.STARTED;
					}

					case android.app.Fragment.STARTED:
					{
						if (newState > android.app.Fragment.STARTED)
						{
							if (DEBUG)
							{
								android.util.Log.v(TAG, "moveto RESUMED: " + f);
							}
							f.mCalled = false;
							f.mResumed = true;
							f.onResume();
							if (!f.mCalled)
							{
								throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onResume()"
									);
							}
							f.mSavedFragmentState = null;
							f.mSavedViewState = null;
						}
						break;
					}
				}
			}
			else
			{
				if (f.mState > newState)
				{
					switch (f.mState)
					{
						case android.app.Fragment.RESUMED:
						{
							if (newState < android.app.Fragment.RESUMED)
							{
								if (DEBUG)
								{
									android.util.Log.v(TAG, "movefrom RESUMED: " + f);
								}
								f.mCalled = false;
								f.onPause();
								if (!f.mCalled)
								{
									throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onPause()"
										);
								}
								f.mResumed = false;
							}
							goto case android.app.Fragment.STARTED;
						}

						case android.app.Fragment.STARTED:
						{
							if (newState < android.app.Fragment.STARTED)
							{
								if (DEBUG)
								{
									android.util.Log.v(TAG, "movefrom STARTED: " + f);
								}
								f.mCalled = false;
								f.performStop();
								if (!f.mCalled)
								{
									throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onStop()"
										);
								}
							}
							goto case android.app.Fragment.STOPPED;
						}

						case android.app.Fragment.STOPPED:
						case android.app.Fragment.ACTIVITY_CREATED:
						{
							if (newState < android.app.Fragment.ACTIVITY_CREATED)
							{
								if (DEBUG)
								{
									android.util.Log.v(TAG, "movefrom ACTIVITY_CREATED: " + f);
								}
								if (f.mView != null)
								{
									if (!mActivity.isFinishing() && f.mSavedViewState == null)
									{
										saveFragmentViewState(f);
									}
								}
								f.mCalled = false;
								f.performDestroyView();
								if (!f.mCalled)
								{
									throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onDestroyView()"
										);
								}
								if (f.mView != null && f.mContainer != null)
								{
									android.animation.Animator anim = null;
									if (mCurState > android.app.Fragment.INITIALIZING && !mDestroyed)
									{
										anim = loadAnimator(f, transit, false, transitionStyle);
									}
									if (anim != null)
									{
										android.view.ViewGroup container = f.mContainer;
										android.view.View view = f.mView;
										android.app.Fragment fragment = f;
										container.startViewTransition(view);
										f.mAnimatingAway = anim;
										f.mStateAfterAnimating = newState;
										anim.addListener(new _AnimatorListenerAdapter_903(this, container, view, fragment
											));
										anim.setTarget(f.mView);
										anim.start();
									}
									f.mContainer.removeView(f.mView);
								}
								f.mContainer = null;
								f.mView = null;
							}
							goto case android.app.Fragment.CREATED;
						}

						case android.app.Fragment.CREATED:
						{
							if (newState < android.app.Fragment.CREATED)
							{
								if (mDestroyed)
								{
									if (f.mAnimatingAway != null)
									{
										// The fragment's containing activity is
										// being destroyed, but this fragment is
										// currently animating away.  Stop the
										// animation right now -- it is not needed,
										// and we can't wait any more on destroying
										// the fragment.
										android.animation.Animator anim = f.mAnimatingAway;
										f.mAnimatingAway = null;
										anim.cancel();
									}
								}
								if (f.mAnimatingAway != null)
								{
									// We are waiting for the fragment's view to finish
									// animating away.  Just make a note of the state
									// the fragment now should move to once the animation
									// is done.
									f.mStateAfterAnimating = newState;
									newState = android.app.Fragment.CREATED;
								}
								else
								{
									if (DEBUG)
									{
										android.util.Log.v(TAG, "movefrom CREATED: " + f);
									}
									if (!f.mRetaining)
									{
										f.mCalled = false;
										f.onDestroy();
										if (!f.mCalled)
										{
											throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onDestroy()"
												);
										}
									}
									f.mCalled = false;
									f.onDetach();
									if (!f.mCalled)
									{
										throw new android.app.SuperNotCalledException("Fragment " + f + " did not call through to super.onDetach()"
											);
									}
									if (!f.mRetaining)
									{
										makeInactive(f);
									}
									else
									{
										f.mActivity = null;
										f.mFragmentManager = null;
									}
								}
							}
							break;
						}
					}
				}
			}
			f.mState = newState;
		}

		internal void moveToState(android.app.Fragment f)
		{
			moveToState(f, mCurState, 0, 0);
		}

		internal void moveToState(int newState, bool always)
		{
			moveToState(newState, 0, 0, always);
		}

		internal void moveToState(int newState, int transit, int transitStyle, bool always
			)
		{
			if (mActivity == null && newState != android.app.Fragment.INITIALIZING)
			{
				throw new System.InvalidOperationException("No activity");
			}
			if (!always && mCurState == newState)
			{
				return;
			}
			mCurState = newState;
			if (mActive != null)
			{
				{
					for (int i = 0; i < mActive.size(); i++)
					{
						android.app.Fragment f = mActive.get(i);
						if (f != null)
						{
							moveToState(f, newState, transit, transitStyle);
						}
					}
				}
				if (mNeedMenuInvalidate && mActivity != null && mCurState == android.app.Fragment
					.RESUMED)
				{
					mActivity.invalidateOptionsMenu();
					mNeedMenuInvalidate = false;
				}
			}
		}

		internal void makeActive(android.app.Fragment f)
		{
			if (f.mIndex >= 0)
			{
				return;
			}
			if (mAvailIndices == null || mAvailIndices.size() <= 0)
			{
				if (mActive == null)
				{
					mActive = new java.util.ArrayList<android.app.Fragment>();
				}
				f.setIndex(mActive.size());
				mActive.add(f);
			}
			else
			{
				f.setIndex(mAvailIndices.remove(mAvailIndices.size() - 1));
				mActive.set(f.mIndex, f);
			}
		}

		internal void makeInactive(android.app.Fragment f)
		{
			if (f.mIndex < 0)
			{
				return;
			}
			if (DEBUG)
			{
				android.util.Log.v(TAG, "Freeing fragment index " + f.mIndex);
			}
			mActive.set(f.mIndex, null);
			if (mAvailIndices == null)
			{
				mAvailIndices = new java.util.ArrayList<int>();
			}
			mAvailIndices.add(f.mIndex);
			mActivity.invalidateFragmentIndex(f.mIndex);
			f.initState();
		}

		public void addFragment(android.app.Fragment fragment, bool moveToStateNow)
		{
			if (mAdded == null)
			{
				mAdded = new java.util.ArrayList<android.app.Fragment>();
			}
			if (DEBUG)
			{
				android.util.Log.v(TAG, "add: " + fragment);
			}
			makeActive(fragment);
			if (!fragment.mDetached)
			{
				mAdded.add(fragment);
				fragment.mAdded = true;
				fragment.mRemoving = false;
				if (fragment.mHasMenu && fragment.mMenuVisible)
				{
					mNeedMenuInvalidate = true;
				}
				if (moveToStateNow)
				{
					moveToState(fragment);
				}
			}
		}

		public void removeFragment(android.app.Fragment fragment, int transition, int transitionStyle
			)
		{
			if (DEBUG)
			{
				android.util.Log.v(TAG, "remove: " + fragment + " nesting=" + fragment.mBackStackNesting
					);
			}
			bool inactive = !fragment.isInBackStack();
			if (!fragment.mDetached || inactive)
			{
				mAdded.remove(fragment);
				if (fragment.mHasMenu && fragment.mMenuVisible)
				{
					mNeedMenuInvalidate = true;
				}
				fragment.mAdded = false;
				fragment.mRemoving = true;
				moveToState(fragment, inactive ? android.app.Fragment.INITIALIZING : android.app.Fragment
					.CREATED, transition, transitionStyle);
			}
		}

		private sealed class _AnimatorListenerAdapter_1088 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_1088(android.app.Fragment finalFragment)
			{
				this.finalFragment = finalFragment;
			}

			// Delay the actual hide operation until the animation finishes, otherwise
			// the fragment will just immediately disappear
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animation)
			{
				if (finalFragment.mView != null)
				{
					finalFragment.mView.setVisibility(android.view.View.GONE);
				}
			}

			private readonly android.app.Fragment finalFragment;
		}

		public void hideFragment(android.app.Fragment fragment, int transition, int transitionStyle
			)
		{
			if (DEBUG)
			{
				android.util.Log.v(TAG, "hide: " + fragment);
			}
			if (!fragment.mHidden)
			{
				fragment.mHidden = true;
				if (fragment.mView != null)
				{
					android.animation.Animator anim = loadAnimator(fragment, transition, true, transitionStyle
						);
					if (anim != null)
					{
						anim.setTarget(fragment.mView);
						android.app.Fragment finalFragment = fragment;
						anim.addListener(new _AnimatorListenerAdapter_1088(finalFragment));
						anim.start();
					}
					else
					{
						fragment.mView.setVisibility(android.view.View.GONE);
					}
				}
				if (fragment.mAdded && fragment.mHasMenu && fragment.mMenuVisible)
				{
					mNeedMenuInvalidate = true;
				}
				fragment.onHiddenChanged(true);
			}
		}

		public void showFragment(android.app.Fragment fragment, int transition, int transitionStyle
			)
		{
			if (DEBUG)
			{
				android.util.Log.v(TAG, "show: " + fragment);
			}
			if (fragment.mHidden)
			{
				fragment.mHidden = false;
				if (fragment.mView != null)
				{
					android.animation.Animator anim = loadAnimator(fragment, transition, true, transitionStyle
						);
					if (anim != null)
					{
						anim.setTarget(fragment.mView);
						anim.start();
					}
					fragment.mView.setVisibility(android.view.View.VISIBLE);
				}
				if (fragment.mAdded && fragment.mHasMenu && fragment.mMenuVisible)
				{
					mNeedMenuInvalidate = true;
				}
				fragment.onHiddenChanged(false);
			}
		}

		public void detachFragment(android.app.Fragment fragment, int transition, int transitionStyle
			)
		{
			if (DEBUG)
			{
				android.util.Log.v(TAG, "detach: " + fragment);
			}
			if (!fragment.mDetached)
			{
				fragment.mDetached = true;
				if (fragment.mAdded)
				{
					// We are not already in back stack, so need to remove the fragment.
					mAdded.remove(fragment);
					if (fragment.mHasMenu && fragment.mMenuVisible)
					{
						mNeedMenuInvalidate = true;
					}
					fragment.mAdded = false;
					moveToState(fragment, android.app.Fragment.CREATED, transition, transitionStyle);
				}
			}
		}

		public void attachFragment(android.app.Fragment fragment, int transition, int transitionStyle
			)
		{
			if (DEBUG)
			{
				android.util.Log.v(TAG, "attach: " + fragment);
			}
			if (fragment.mDetached)
			{
				fragment.mDetached = false;
				if (!fragment.mAdded)
				{
					mAdded.add(fragment);
					fragment.mAdded = true;
					if (fragment.mHasMenu && fragment.mMenuVisible)
					{
						mNeedMenuInvalidate = true;
					}
					moveToState(fragment, mCurState, transition, transitionStyle);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override android.app.Fragment findFragmentById(int id)
		{
			if (mActive != null)
			{
				{
					// First look through added fragments.
					for (int i = mAdded.size() - 1; i >= 0; i--)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null && f.mFragmentId == id)
						{
							return f;
						}
					}
				}
				{
					// Now for any known fragment.
					for (int i_1 = mActive.size() - 1; i_1 >= 0; i_1--)
					{
						android.app.Fragment f = mActive.get(i_1);
						if (f != null && f.mFragmentId == id)
						{
							return f;
						}
					}
				}
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override android.app.Fragment findFragmentByTag(string tag)
		{
			if (mActive != null && tag != null)
			{
				{
					// First look through added fragments.
					for (int i = mAdded.size() - 1; i >= 0; i--)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null && tag.Equals(f.mTag))
						{
							return f;
						}
					}
				}
				{
					// Now for any known fragment.
					for (int i_1 = mActive.size() - 1; i_1 >= 0; i_1--)
					{
						android.app.Fragment f = mActive.get(i_1);
						if (f != null && tag.Equals(f.mTag))
						{
							return f;
						}
					}
				}
			}
			return null;
		}

		public android.app.Fragment findFragmentByWho(string who)
		{
			if (mActive != null && who != null)
			{
				{
					for (int i = mActive.size() - 1; i >= 0; i--)
					{
						android.app.Fragment f = mActive.get(i);
						if (f != null && who.Equals(f.mWho))
						{
							return f;
						}
					}
				}
			}
			return null;
		}

		private void checkStateLoss()
		{
			if (mStateSaved)
			{
				throw new System.InvalidOperationException("Can not perform this action after onSaveInstanceState"
					);
			}
			if (mNoTransactionsBecause != null)
			{
				throw new System.InvalidOperationException("Can not perform this action inside of "
					 + mNoTransactionsBecause);
			}
		}

		public void enqueueAction(java.lang.Runnable action, bool allowStateLoss)
		{
			if (!allowStateLoss)
			{
				checkStateLoss();
			}
			lock (this)
			{
				if (mActivity == null)
				{
					throw new System.InvalidOperationException("Activity has been destroyed");
				}
				if (mPendingActions == null)
				{
					mPendingActions = new java.util.ArrayList<java.lang.Runnable>();
				}
				mPendingActions.add(action);
				if (mPendingActions.size() == 1)
				{
					mActivity.mHandler.removeCallbacks(mExecCommit);
					mActivity.mHandler.post(mExecCommit);
				}
			}
		}

		internal int allocBackStackIndex(android.app.BackStackRecord bse)
		{
			lock (this)
			{
				if (mAvailBackStackIndices == null || mAvailBackStackIndices.size() <= 0)
				{
					if (mBackStackIndices == null)
					{
						mBackStackIndices = new java.util.ArrayList<android.app.BackStackRecord>();
					}
					int index = mBackStackIndices.size();
					if (DEBUG)
					{
						android.util.Log.v(TAG, "Setting back stack index " + index + " to " + bse);
					}
					mBackStackIndices.add(bse);
					return index;
				}
				else
				{
					int index = mAvailBackStackIndices.remove(mAvailBackStackIndices.size() - 1);
					if (DEBUG)
					{
						android.util.Log.v(TAG, "Adding back stack index " + index + " with " + bse);
					}
					mBackStackIndices.set(index, bse);
					return index;
				}
			}
		}

		internal void setBackStackIndex(int index, android.app.BackStackRecord bse)
		{
			lock (this)
			{
				if (mBackStackIndices == null)
				{
					mBackStackIndices = new java.util.ArrayList<android.app.BackStackRecord>();
				}
				int N = mBackStackIndices.size();
				if (index < N)
				{
					if (DEBUG)
					{
						android.util.Log.v(TAG, "Setting back stack index " + index + " to " + bse);
					}
					mBackStackIndices.set(index, bse);
				}
				else
				{
					while (N < index)
					{
						mBackStackIndices.add(null);
						if (mAvailBackStackIndices == null)
						{
							mAvailBackStackIndices = new java.util.ArrayList<int>();
						}
						if (DEBUG)
						{
							android.util.Log.v(TAG, "Adding available back stack index " + N);
						}
						mAvailBackStackIndices.add(N);
						N++;
					}
					if (DEBUG)
					{
						android.util.Log.v(TAG, "Adding back stack index " + index + " with " + bse);
					}
					mBackStackIndices.add(bse);
				}
			}
		}

		public void freeBackStackIndex(int index)
		{
			lock (this)
			{
				mBackStackIndices.set(index, null);
				if (mAvailBackStackIndices == null)
				{
					mAvailBackStackIndices = new java.util.ArrayList<int>();
				}
				if (DEBUG)
				{
					android.util.Log.v(TAG, "Freeing back stack index " + index);
				}
				mAvailBackStackIndices.add(index);
			}
		}

		internal void reportBackStackChanged()
		{
			if (mBackStackChangeListeners != null)
			{
				{
					for (int i = 0; i < mBackStackChangeListeners.size(); i++)
					{
						mBackStackChangeListeners.get(i).onBackStackChanged();
					}
				}
			}
		}

		internal void addBackStackState(android.app.BackStackRecord state)
		{
			if (mBackStack == null)
			{
				mBackStack = new java.util.ArrayList<android.app.BackStackRecord>();
			}
			mBackStack.add(state);
			reportBackStackChanged();
		}

		internal bool popBackStackState(android.os.Handler handler, string name, int id, 
			int flags)
		{
			if (mBackStack == null)
			{
				return false;
			}
			if (name == null && id < 0 && (flags & POP_BACK_STACK_INCLUSIVE) == 0)
			{
				int last = mBackStack.size() - 1;
				if (last < 0)
				{
					return false;
				}
				android.app.BackStackRecord bss = mBackStack.remove(last);
				bss.popFromBackStack(true);
				reportBackStackChanged();
			}
			else
			{
				int index = -1;
				if (name != null || id >= 0)
				{
					// If a name or ID is specified, look for that place in
					// the stack.
					index = mBackStack.size() - 1;
					while (index >= 0)
					{
						android.app.BackStackRecord bss = mBackStack.get(index);
						if (name != null && name.Equals(bss.getName()))
						{
							break;
						}
						if (id >= 0 && id == bss.mIndex)
						{
							break;
						}
						index--;
					}
					if (index < 0)
					{
						return false;
					}
					if ((flags & POP_BACK_STACK_INCLUSIVE) != 0)
					{
						index--;
						// Consume all following entries that match.
						while (index >= 0)
						{
							android.app.BackStackRecord bss = mBackStack.get(index);
							if ((name != null && name.Equals(bss.getName())) || (id >= 0 && id == bss.mIndex))
							{
								index--;
								continue;
							}
							break;
						}
					}
				}
				if (index == mBackStack.size() - 1)
				{
					return false;
				}
				java.util.ArrayList<android.app.BackStackRecord> states = new java.util.ArrayList
					<android.app.BackStackRecord>();
				{
					for (int i = mBackStack.size() - 1; i > index; i--)
					{
						states.add(mBackStack.remove(i));
					}
				}
				int LAST = states.size() - 1;
				{
					for (int i_1 = 0; i_1 <= LAST; i_1++)
					{
						if (DEBUG)
						{
							android.util.Log.v(TAG, "Popping back stack state: " + states.get(i_1));
						}
						states.get(i_1).popFromBackStack(i_1 == LAST);
					}
				}
				reportBackStackChanged();
			}
			return true;
		}

		internal java.util.ArrayList<android.app.Fragment> retainNonConfig()
		{
			java.util.ArrayList<android.app.Fragment> fragments = null;
			if (mActive != null)
			{
				{
					for (int i = 0; i < mActive.size(); i++)
					{
						android.app.Fragment f = mActive.get(i);
						if (f != null && f.mRetainInstance)
						{
							if (fragments == null)
							{
								fragments = new java.util.ArrayList<android.app.Fragment>();
							}
							fragments.add(f);
							f.mRetaining = true;
							f.mTargetIndex = f.mTarget != null ? f.mTarget.mIndex : -1;
						}
					}
				}
			}
			return fragments;
		}

		internal void saveFragmentViewState(android.app.Fragment f)
		{
			if (f.mView == null)
			{
				return;
			}
			if (mStateArray == null)
			{
				mStateArray = new android.util.SparseArray<android.os.Parcelable>();
			}
			else
			{
				mStateArray.clear();
			}
			f.mView.saveHierarchyState(mStateArray);
			if (mStateArray.size() > 0)
			{
				f.mSavedViewState = mStateArray;
				mStateArray = null;
			}
		}

		internal android.os.Bundle saveFragmentBasicState(android.app.Fragment f)
		{
			android.os.Bundle result = null;
			if (mStateBundle == null)
			{
				mStateBundle = new android.os.Bundle();
			}
			f.onSaveInstanceState(mStateBundle);
			if (!mStateBundle.isEmpty())
			{
				result = mStateBundle;
				mStateBundle = null;
			}
			if (f.mView != null)
			{
				saveFragmentViewState(f);
			}
			if (f.mSavedViewState != null)
			{
				if (result == null)
				{
					result = new android.os.Bundle();
				}
				result.putSparseParcelableArray(android.app.FragmentManagerImpl.VIEW_STATE_TAG, f
					.mSavedViewState);
			}
			return result;
		}

		internal android.os.Parcelable saveAllState()
		{
			// Make sure all pending operations have now been executed to get
			// our state update-to-date.
			execPendingActions();
			mStateSaved = true;
			if (mActive == null || mActive.size() <= 0)
			{
				return null;
			}
			// First collect all active fragments.
			int N = mActive.size();
			android.app.FragmentState[] active = new android.app.FragmentState[N];
			bool haveFragments = false;
			{
				for (int i = 0; i < N; i++)
				{
					android.app.Fragment f = mActive.get(i);
					if (f != null)
					{
						haveFragments = true;
						android.app.FragmentState fs = new android.app.FragmentState(f);
						active[i] = fs;
						if (f.mState > android.app.Fragment.INITIALIZING && fs.mSavedFragmentState == null)
						{
							fs.mSavedFragmentState = saveFragmentBasicState(f);
							if (f.mTarget != null)
							{
								if (f.mTarget.mIndex < 0)
								{
									string msg = "Failure saving state: " + f + " has target not in fragment manager: "
										 + f.mTarget;
									android.util.Slog.e(TAG, msg);
									dump("  ", null, new java.io.PrintWriter(new android.util.LogWriter(android.util.Log
										.ERROR, TAG, android.util.Log.LOG_ID_SYSTEM)), new string[] {  });
									throw new System.InvalidOperationException(msg);
								}
								if (fs.mSavedFragmentState == null)
								{
									fs.mSavedFragmentState = new android.os.Bundle();
								}
								putFragment(fs.mSavedFragmentState, android.app.FragmentManagerImpl.TARGET_STATE_TAG
									, f.mTarget);
								if (f.mTargetRequestCode != 0)
								{
									fs.mSavedFragmentState.putInt(android.app.FragmentManagerImpl.TARGET_REQUEST_CODE_STATE_TAG
										, f.mTargetRequestCode);
								}
							}
						}
						else
						{
							fs.mSavedFragmentState = f.mSavedFragmentState;
						}
						if (DEBUG)
						{
							android.util.Log.v(TAG, "Saved state of " + f + ": " + fs.mSavedFragmentState);
						}
					}
				}
			}
			if (!haveFragments)
			{
				if (DEBUG)
				{
					android.util.Log.v(TAG, "saveAllState: no fragments!");
				}
				return null;
			}
			int[] added = null;
			android.app.BackStackState[] backStack = null;
			// Build list of currently added fragments.
			if (mAdded != null)
			{
				N = mAdded.size();
				if (N > 0)
				{
					added = new int[N];
					{
						for (int i_1 = 0; i_1 < N; i_1++)
						{
							added[i_1] = mAdded.get(i_1).mIndex;
							if (DEBUG)
							{
								android.util.Log.v(TAG, "saveAllState: adding fragment #" + i_1 + ": " + mAdded.get
									(i_1));
							}
						}
					}
				}
			}
			// Now save back stack.
			if (mBackStack != null)
			{
				N = mBackStack.size();
				if (N > 0)
				{
					backStack = new android.app.BackStackState[N];
					{
						for (int i_1 = 0; i_1 < N; i_1++)
						{
							backStack[i_1] = new android.app.BackStackState(this, mBackStack.get(i_1));
							if (DEBUG)
							{
								android.util.Log.v(TAG, "saveAllState: adding back stack #" + i_1 + ": " + mBackStack
									.get(i_1));
							}
						}
					}
				}
			}
			android.app.FragmentManagerState fms = new android.app.FragmentManagerState();
			fms.mActive = active;
			fms.mAdded = added;
			fms.mBackStack = backStack;
			return fms;
		}

		internal void restoreAllState(android.os.Parcelable state, java.util.ArrayList<android.app.Fragment
			> nonConfig)
		{
			// If there is no saved state at all, then there can not be
			// any nonConfig fragments either, so that is that.
			if (state == null)
			{
				return;
			}
			android.app.FragmentManagerState fms = (android.app.FragmentManagerState)state;
			if (fms.mActive == null)
			{
				return;
			}
			// First re-attach any non-config instances we are retaining back
			// to their saved state, so we don't try to instantiate them again.
			if (nonConfig != null)
			{
				{
					for (int i = 0; i < nonConfig.size(); i++)
					{
						android.app.Fragment f = nonConfig.get(i);
						if (DEBUG)
						{
							android.util.Log.v(TAG, "restoreAllState: re-attaching retained " + f);
						}
						android.app.FragmentState fs = fms.mActive[f.mIndex];
						fs.mInstance = f;
						f.mSavedViewState = null;
						f.mBackStackNesting = 0;
						f.mInLayout = false;
						f.mAdded = false;
						f.mTarget = null;
						if (fs.mSavedFragmentState != null)
						{
							fs.mSavedFragmentState.setClassLoader(mActivity.getClassLoader());
							f.mSavedViewState = fs.mSavedFragmentState.getSparseParcelableArray<android.os.Parcelable
								>(android.app.FragmentManagerImpl.VIEW_STATE_TAG);
						}
					}
				}
			}
			// Build the full list of active fragments, instantiating them from
			// their saved state.
			mActive = new java.util.ArrayList<android.app.Fragment>(fms.mActive.Length);
			if (mAvailIndices != null)
			{
				mAvailIndices.clear();
			}
			{
				for (int i_1 = 0; i_1 < fms.mActive.Length; i_1++)
				{
					android.app.FragmentState fs = fms.mActive[i_1];
					if (fs != null)
					{
						android.app.Fragment f = fs.instantiate(mActivity);
						if (DEBUG)
						{
							android.util.Log.v(TAG, "restoreAllState: adding #" + i_1 + ": " + f);
						}
						mActive.add(f);
						// Now that the fragment is instantiated (or came from being
						// retained above), clear mInstance in case we end up re-restoring
						// from this FragmentState again.
						fs.mInstance = null;
					}
					else
					{
						if (DEBUG)
						{
							android.util.Log.v(TAG, "restoreAllState: adding #" + i_1 + ": (null)");
						}
						mActive.add(null);
						if (mAvailIndices == null)
						{
							mAvailIndices = new java.util.ArrayList<int>();
						}
						if (DEBUG)
						{
							android.util.Log.v(TAG, "restoreAllState: adding avail #" + i_1);
						}
						mAvailIndices.add(i_1);
					}
				}
			}
			// Update the target of all retained fragments.
			if (nonConfig != null)
			{
				{
					for (int i = 0; i < nonConfig.size(); i++)
					{
						android.app.Fragment f = nonConfig.get(i);
						if (f.mTargetIndex >= 0)
						{
							if (f.mTargetIndex < mActive.size())
							{
								f.mTarget = mActive.get(f.mTargetIndex);
							}
							else
							{
								android.util.Log.w(TAG, "Re-attaching retained fragment " + f + " target no longer exists: "
									 + f.mTargetIndex);
								f.mTarget = null;
							}
						}
					}
				}
			}
			// Build the list of currently added fragments.
			if (fms.mAdded != null)
			{
				mAdded = new java.util.ArrayList<android.app.Fragment>(fms.mAdded.Length);
				{
					for (int i = 0; i < fms.mAdded.Length; i++)
					{
						android.app.Fragment f = mActive.get(fms.mAdded[i]);
						if (f == null)
						{
							throw new System.InvalidOperationException("No instantiated fragment for index #"
								 + fms.mAdded[i]);
						}
						f.mAdded = true;
						if (DEBUG)
						{
							android.util.Log.v(TAG, "restoreAllState: making added #" + i + ": " + f);
						}
						mAdded.add(f);
					}
				}
			}
			else
			{
				mAdded = null;
			}
			// Build the back stack.
			if (fms.mBackStack != null)
			{
				mBackStack = new java.util.ArrayList<android.app.BackStackRecord>(fms.mBackStack.
					Length);
				{
					for (int i = 0; i < fms.mBackStack.Length; i++)
					{
						android.app.BackStackRecord bse = fms.mBackStack[i].instantiate(this);
						if (DEBUG)
						{
							android.util.Log.v(TAG, "restoreAllState: adding bse #" + i + " (index " + bse.mIndex
								 + "): " + bse);
						}
						mBackStack.add(bse);
						if (bse.mIndex >= 0)
						{
							setBackStackIndex(bse.mIndex, bse);
						}
					}
				}
			}
			else
			{
				mBackStack = null;
			}
		}

		public void attachActivity(android.app.Activity activity)
		{
			if (mActivity != null)
			{
				throw new System.InvalidOperationException();
			}
			mActivity = activity;
		}

		public void noteStateNotSaved()
		{
			mStateSaved = false;
		}

		public void dispatchCreate()
		{
			mStateSaved = false;
			moveToState(android.app.Fragment.CREATED, false);
		}

		public void dispatchActivityCreated()
		{
			mStateSaved = false;
			moveToState(android.app.Fragment.ACTIVITY_CREATED, false);
		}

		public void dispatchStart()
		{
			mStateSaved = false;
			moveToState(android.app.Fragment.STARTED, false);
		}

		public void dispatchResume()
		{
			mStateSaved = false;
			moveToState(android.app.Fragment.RESUMED, false);
		}

		public void dispatchPause()
		{
			moveToState(android.app.Fragment.STARTED, false);
		}

		public void dispatchStop()
		{
			moveToState(android.app.Fragment.STOPPED, false);
		}

		public void dispatchDestroy()
		{
			mDestroyed = true;
			execPendingActions();
			moveToState(android.app.Fragment.INITIALIZING, false);
			mActivity = null;
		}

		public void dispatchConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null)
						{
							f.onConfigurationChanged(newConfig);
						}
					}
				}
			}
		}

		public void dispatchLowMemory()
		{
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null)
						{
							f.onLowMemory();
						}
					}
				}
			}
		}

		public void dispatchTrimMemory(int level)
		{
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null)
						{
							f.onTrimMemory(level);
						}
					}
				}
			}
		}

		public bool dispatchCreateOptionsMenu(android.view.Menu menu, android.view.MenuInflater
			 inflater)
		{
			bool show = false;
			java.util.ArrayList<android.app.Fragment> newMenus = null;
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null && !f.mHidden && f.mHasMenu && f.mMenuVisible)
						{
							show = true;
							f.onCreateOptionsMenu(menu, inflater);
							if (newMenus == null)
							{
								newMenus = new java.util.ArrayList<android.app.Fragment>();
							}
							newMenus.add(f);
						}
					}
				}
			}
			if (mCreatedMenus != null)
			{
				{
					for (int i = 0; i < mCreatedMenus.size(); i++)
					{
						android.app.Fragment f = mCreatedMenus.get(i);
						if (newMenus == null || !newMenus.contains(f))
						{
							f.onDestroyOptionsMenu();
						}
					}
				}
			}
			mCreatedMenus = newMenus;
			return show;
		}

		public bool dispatchPrepareOptionsMenu(android.view.Menu menu)
		{
			bool show = false;
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null && !f.mHidden && f.mHasMenu && f.mMenuVisible)
						{
							show = true;
							f.onPrepareOptionsMenu(menu);
						}
					}
				}
			}
			return show;
		}

		public bool dispatchOptionsItemSelected(android.view.MenuItem item)
		{
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null && !f.mHidden && f.mHasMenu && f.mMenuVisible)
						{
							if (f.onOptionsItemSelected(item))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public bool dispatchContextItemSelected(android.view.MenuItem item)
		{
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null && !f.mHidden)
						{
							if (f.onContextItemSelected(item))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public void dispatchOptionsMenuClosed(android.view.Menu menu)
		{
			if (mActive != null)
			{
				{
					for (int i = 0; i < mAdded.size(); i++)
					{
						android.app.Fragment f = mAdded.get(i);
						if (f != null && !f.mHidden && f.mHasMenu && f.mMenuVisible)
						{
							f.onOptionsMenuClosed(menu);
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.app.FragmentManager")]
		public override void invalidateOptionsMenu()
		{
			if (mActivity != null && mCurState == android.app.Fragment.RESUMED)
			{
				mActivity.invalidateOptionsMenu();
			}
			else
			{
				mNeedMenuInvalidate = true;
			}
		}

		public static int reverseTransit(int transit)
		{
			int rev = 0;
			switch (transit)
			{
				case android.app.FragmentTransaction.TRANSIT_FRAGMENT_OPEN:
				{
					rev = android.app.FragmentTransaction.TRANSIT_FRAGMENT_CLOSE;
					break;
				}

				case android.app.FragmentTransaction.TRANSIT_FRAGMENT_CLOSE:
				{
					rev = android.app.FragmentTransaction.TRANSIT_FRAGMENT_OPEN;
					break;
				}

				case android.app.FragmentTransaction.TRANSIT_FRAGMENT_FADE:
				{
					rev = android.app.FragmentTransaction.TRANSIT_FRAGMENT_FADE;
					break;
				}
			}
			return rev;
		}

		public static int transitToStyleIndex(int transit, bool enter)
		{
			int animAttr = -1;
			switch (transit)
			{
				case android.app.FragmentTransaction.TRANSIT_FRAGMENT_OPEN:
				{
					animAttr = enter ? android.@internal.R.styleable.FragmentAnimation_fragmentOpenEnterAnimation
						 : android.@internal.R.styleable.FragmentAnimation_fragmentOpenExitAnimation;
					break;
				}

				case android.app.FragmentTransaction.TRANSIT_FRAGMENT_CLOSE:
				{
					animAttr = enter ? android.@internal.R.styleable.FragmentAnimation_fragmentCloseEnterAnimation
						 : android.@internal.R.styleable.FragmentAnimation_fragmentCloseExitAnimation;
					break;
				}

				case android.app.FragmentTransaction.TRANSIT_FRAGMENT_FADE:
				{
					animAttr = enter ? android.@internal.R.styleable.FragmentAnimation_fragmentFadeEnterAnimation
						 : android.@internal.R.styleable.FragmentAnimation_fragmentFadeExitAnimation;
					break;
				}
			}
			return animAttr;
		}

		public FragmentManagerImpl()
		{
			mExecCommit = new _Runnable_414(this);
		}
	}
}
