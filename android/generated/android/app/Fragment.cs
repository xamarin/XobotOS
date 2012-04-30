using Sharpen;

namespace android.app
{
	[Sharpen.Sharpened]
	internal sealed class FragmentState : android.os.Parcelable
	{
		internal readonly string mClassName;

		internal readonly int mIndex;

		internal readonly bool mFromLayout;

		internal readonly int mFragmentId;

		internal readonly int mContainerId;

		internal readonly string mTag;

		internal readonly bool mRetainInstance;

		internal readonly bool mDetached;

		internal readonly android.os.Bundle mArguments;

		internal android.os.Bundle mSavedFragmentState;

		internal android.app.Fragment mInstance;

		public FragmentState(android.app.Fragment frag)
		{
			mClassName = frag.GetType().FullName;
			mIndex = frag.mIndex;
			mFromLayout = frag.mFromLayout;
			mFragmentId = frag.mFragmentId;
			mContainerId = frag.mContainerId;
			mTag = frag.mTag;
			mRetainInstance = frag.mRetainInstance;
			mDetached = frag.mDetached;
			mArguments = frag.mArguments;
		}

		public FragmentState(android.os.Parcel @in)
		{
			mClassName = @in.readString();
			mIndex = @in.readInt();
			mFromLayout = @in.readInt() != 0;
			mFragmentId = @in.readInt();
			mContainerId = @in.readInt();
			mTag = @in.readString();
			mRetainInstance = @in.readInt() != 0;
			mDetached = @in.readInt() != 0;
			mArguments = @in.readBundle();
			mSavedFragmentState = @in.readBundle();
		}

		public android.app.Fragment instantiate(android.app.Activity activity)
		{
			if (mInstance != null)
			{
				return mInstance;
			}
			if (mArguments != null)
			{
				mArguments.setClassLoader(activity.getClassLoader());
			}
			mInstance = android.app.Fragment.instantiate(activity, mClassName, mArguments);
			if (mSavedFragmentState != null)
			{
				mSavedFragmentState.setClassLoader(activity.getClassLoader());
				mInstance.mSavedFragmentState = mSavedFragmentState;
			}
			mInstance.setIndex(mIndex);
			mInstance.mFromLayout = mFromLayout;
			mInstance.mRestored = true;
			mInstance.mFragmentId = mFragmentId;
			mInstance.mContainerId = mContainerId;
			mInstance.mTag = mTag;
			mInstance.mRetainInstance = mRetainInstance;
			mInstance.mDetached = mDetached;
			mInstance.mFragmentManager = activity.mFragments;
			return mInstance;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			dest.writeString(mClassName);
			dest.writeInt(mIndex);
			dest.writeInt(mFromLayout ? 1 : 0);
			dest.writeInt(mFragmentId);
			dest.writeInt(mContainerId);
			dest.writeString(mTag);
			dest.writeInt(mRetainInstance ? 1 : 0);
			dest.writeInt(mDetached ? 1 : 0);
			dest.writeBundle(mArguments);
			dest.writeBundle(mSavedFragmentState);
		}

		private sealed class _Creator_133 : android.os.ParcelableClass.Creator<android.app.FragmentState
			>
		{
			public _Creator_133()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.FragmentState createFromParcel(android.os.Parcel @in)
			{
				return new android.app.FragmentState(@in);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.FragmentState[] newArray(int size)
			{
				return new android.app.FragmentState[size];
			}
		}

		internal static readonly android.os.ParcelableClass.Creator<android.app.FragmentState
			> CREATOR = new _Creator_133();
	}

	/// <summary>
	/// A Fragment is a piece of an application's user interface or behavior
	/// that can be placed in an
	/// <see cref="Activity">Activity</see>
	/// .  Interaction with fragments
	/// is done through
	/// <see cref="FragmentManager">FragmentManager</see>
	/// , which can be obtained via
	/// <see cref="Activity.getFragmentManager()">Activity.getFragmentManager()</see>
	/// and
	/// <see cref="getFragmentManager()">Fragment.getFragmentManager()</see>
	/// .
	/// <p>The Fragment class can be used many ways to achieve a wide variety of
	/// results.  It is core, it represents a particular operation or interface
	/// that is running within a larger
	/// <see cref="Activity">Activity</see>
	/// .  A Fragment is closely
	/// tied to the Activity it is in, and can not be used apart from one.  Though
	/// Fragment defines its own lifecycle, that lifecycle is dependent on its
	/// activity: if the activity is stopped, no fragments inside of it can be
	/// started; when the activity is destroyed, all fragments will be destroyed.
	/// <p>All subclasses of Fragment must include a public empty constructor.
	/// The framework will often re-instantiate a fragment class when needed,
	/// in particular during state restore, and needs to be able to find this
	/// constructor to instantiate it.  If the empty constructor is not available,
	/// a runtime exception will occur in some cases during state restore.
	/// <p>Topics covered here:
	/// <ol>
	/// <li><a href="#OlderPlatforms">Older Platforms</a>
	/// <li><a href="#Lifecycle">Lifecycle</a>
	/// <li><a href="#Layout">Layout</a>
	/// <li><a href="#BackStack">Back Stack</a>
	/// </ol>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about using fragments, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/fundamentals/fragments.html"&gt;Fragments</a> developer guide.</p>
	/// </div>
	/// <a name="OlderPlatforms"></a>
	/// <h3>Older Platforms</h3>
	/// While the Fragment API was introduced in
	/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB">android.os.Build.VERSION_CODES.HONEYCOMB
	/// 	</see>
	/// , a version of the API
	/// is also available for use on older platforms.  See the blog post
	/// <a href="http://android-developers.blogspot.com/2011/03/fragments-for-all.html">
	/// Fragments For All</a> for more details.
	/// <a name="Lifecycle"></a>
	/// <h3>Lifecycle</h3>
	/// <p>Though a Fragment's lifecycle is tied to its owning activity, it has
	/// its own wrinkle on the standard activity lifecycle.  It includes basic
	/// activity lifecycle methods such as
	/// <see cref="onResume()">onResume()</see>
	/// , but also important
	/// are methods related to interactions with the activity and UI generation.
	/// <p>The core series of lifecycle methods that are called to bring a fragment
	/// up to resumed state (interacting with the user) are:
	/// <ol>
	/// <li>
	/// <see cref="onAttach(Activity)">onAttach(Activity)</see>
	/// called once the fragment is associated with its activity.
	/// <li>
	/// <see cref="onCreate(android.os.Bundle)">onCreate(android.os.Bundle)</see>
	/// called to do initial creation of the fragment.
	/// <li>
	/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
	/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
	/// 	</see>
	/// creates and returns the view hierarchy associated
	/// with the fragment.
	/// <li>
	/// <see cref="onActivityCreated(android.os.Bundle)">onActivityCreated(android.os.Bundle)
	/// 	</see>
	/// tells the fragment that its activity has
	/// completed its own
	/// <see cref="Activity.onCreate(android.os.Bundle)">Activity.onCreaate</see>
	/// .
	/// <li>
	/// <see cref="onStart()">onStart()</see>
	/// makes the fragment visible to the user (based on its
	/// containing activity being started).
	/// <li>
	/// <see cref="onResume()">onResume()</see>
	/// makes the fragment interacting with the user (based on its
	/// containing activity being resumed).
	/// </ol>
	/// <p>As a fragment is no longer being used, it goes through a reverse
	/// series of callbacks:
	/// <ol>
	/// <li>
	/// <see cref="onPause()">onPause()</see>
	/// fragment is no longer interacting with the user either
	/// because its activity is being paused or a fragment operation is modifying it
	/// in the activity.
	/// <li>
	/// <see cref="onStop()">onStop()</see>
	/// fragment is no longer visible to the user either
	/// because its activity is being stopped or a fragment operation is modifying it
	/// in the activity.
	/// <li>
	/// <see cref="onDestroyView()">onDestroyView()</see>
	/// allows the fragment to clean up resources
	/// associated with its View.
	/// <li>
	/// <see cref="onDestroy()">onDestroy()</see>
	/// called to do final cleanup of the fragment's state.
	/// <li>
	/// <see cref="onDetach()">onDetach()</see>
	/// called immediately prior to the fragment no longer
	/// being associated with its activity.
	/// </ol>
	/// <a name="Layout"></a>
	/// <h3>Layout</h3>
	/// <p>Fragments can be used as part of your application's layout, allowing
	/// you to better modularize your code and more easily adjust your user
	/// interface to the screen it is running on.  As an example, we can look
	/// at a simple program consisting of a list of items, and display of the
	/// details of each item.</p>
	/// <p>An activity's layout XML can include <code>&lt;fragment&gt;</code> tags
	/// to embed fragment instances inside of the layout.  For example, here is
	/// a simple layout that embeds one fragment:</p>
	/// <sample>development/samples/ApiDemos/res/layout/fragment_layout.xml layout</sample>
	/// <p>The layout is installed in the activity in the normal way:</p>
	/// <sample>
	/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentLayout.java
	/// main
	/// </sample>
	/// <p>The titles fragment, showing a list of titles, is fairly simple, relying
	/// on
	/// <see cref="ListFragment">ListFragment</see>
	/// for most of its work.  Note the implementation of
	/// clicking an item: depending on the current activity's layout, it can either
	/// create and display a new fragment to show the details in-place (more about
	/// this later), or start a new activity to show the details.</p>
	/// <sample>
	/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentLayout.java
	/// titles
	/// </sample>
	/// <p>The details fragment showing the contents of a selected item just
	/// displays a string of text based on an index of a string array built in to
	/// the app:</p>
	/// <sample>
	/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentLayout.java
	/// details
	/// </sample>
	/// <p>In this case when the user clicks on a title, there is no details
	/// container in the current activity, so the titles fragment's click code will
	/// launch a new activity to display the details fragment:</p>
	/// <sample>
	/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentLayout.java
	/// details_activity
	/// </sample>
	/// <p>However the screen may be large enough to show both the list of titles
	/// and details about the currently selected title.  To use such a layout on
	/// a landscape screen, this alternative layout can be placed under layout-land:</p>
	/// <sample>development/samples/ApiDemos/res/layout-land/fragment_layout.xml layout</sample>
	/// <p>Note how the prior code will adjust to this alternative UI flow: the titles
	/// fragment will now embed the details fragment inside of this activity, and the
	/// details activity will finish itself if it is running in a configuration
	/// where the details can be shown in-place.
	/// <p>When a configuration change causes the activity hosting these fragments
	/// to restart, its new instance may use a different layout that doesn't
	/// include the same fragments as the previous layout.  In this case all of
	/// the previous fragments will still be instantiated and running in the new
	/// instance.  However, any that are no longer associated with a &lt;fragment&gt;
	/// tag in the view hierarchy will not have their content view created
	/// and will return false from
	/// <see cref="isInLayout()">isInLayout()</see>
	/// .  (The code here also shows
	/// how you can determine if a fragment placed in a container is no longer
	/// running in a layout with that container and avoid creating its view hierarchy
	/// in that case.)
	/// <p>The attributes of the &lt;fragment&gt; tag are used to control the
	/// LayoutParams provided when attaching the fragment's view to the parent
	/// container.  They can also be parsed by the fragment in
	/// <see cref="onInflate(android.util.AttributeSet, android.os.Bundle)">onInflate(android.util.AttributeSet, android.os.Bundle)
	/// 	</see>
	/// as parameters.
	/// <p>The fragment being instantiated must have some kind of unique identifier
	/// so that it can be re-associated with a previous instance if the parent
	/// activity needs to be destroyed and recreated.  This can be provided these
	/// ways:
	/// <ul>
	/// <li>If nothing is explicitly supplied, the view ID of the container will
	/// be used.
	/// <li><code>android:tag</code> can be used in &lt;fragment&gt; to provide
	/// a specific tag name for the fragment.
	/// <li><code>android:id</code> can be used in &lt;fragment&gt; to provide
	/// a specific identifier for the fragment.
	/// </ul>
	/// <a name="BackStack"></a>
	/// <h3>Back Stack</h3>
	/// <p>The transaction in which fragments are modified can be placed on an
	/// internal back-stack of the owning activity.  When the user presses back
	/// in the activity, any transactions on the back stack are popped off before
	/// the activity itself is finished.
	/// <p>For example, consider this simple fragment that is instantiated with
	/// an integer argument and displays that in a TextView in its UI:</p>
	/// <sample>
	/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentStack.java
	/// fragment
	/// </sample>
	/// <p>A function that creates a new instance of the fragment, replacing
	/// whatever current fragment instance is being shown and pushing that change
	/// on to the back stack could be written as:
	/// <sample>
	/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentStack.java
	/// add_stack
	/// </sample>
	/// <p>After each call to this function, a new entry is on the stack, and
	/// pressing back will pop it to return the user to whatever previous state
	/// the activity UI was in.
	/// </summary>
	[Sharpen.Sharpened]
	public class Fragment : android.content.ComponentCallbacks2, android.view.View.OnCreateContextMenuListener
	{
		private static readonly java.util.HashMap<string, System.Type> sClassMap = new java.util.HashMap
			<string, System.Type>();

		internal const int INITIALIZING = 0;

		internal const int CREATED = 1;

		internal const int ACTIVITY_CREATED = 2;

		internal const int STOPPED = 3;

		internal const int STARTED = 4;

		internal const int RESUMED = 5;

		internal int mState = INITIALIZING;

		internal android.animation.Animator mAnimatingAway;

		internal int mStateAfterAnimating;

		internal android.os.Bundle mSavedFragmentState;

		internal android.util.SparseArray<android.os.Parcelable> mSavedViewState;

		internal int mIndex = -1;

		internal string mWho;

		internal android.os.Bundle mArguments;

		internal android.app.Fragment mTarget;

		internal int mTargetIndex = -1;

		internal int mTargetRequestCode;

		internal bool mAdded;

		internal bool mRemoving;

		internal bool mResumed;

		internal bool mFromLayout;

		internal bool mInLayout;

		internal bool mRestored;

		internal int mBackStackNesting;

		internal android.app.FragmentManager mFragmentManager;

		internal android.app.Activity mActivity;

		internal int mFragmentId;

		internal int mContainerId;

		internal string mTag;

		internal bool mHidden;

		internal bool mDetached;

		internal bool mRetainInstance;

		internal bool mRetaining;

		internal bool mHasMenu;

		internal bool mMenuVisible = true;

		internal bool mCalled;

		internal int mNextAnim;

		internal android.view.ViewGroup mContainer;

		internal android.view.View mView;

		internal android.app.LoaderManagerImpl mLoaderManager;

		internal bool mLoadersStarted;

		internal bool mCheckedForLoaderManager;

		/// <summary>
		/// State information that has been retrieved from a fragment instance
		/// through
		/// <see cref="FragmentManager.saveFragmentInstanceState(Fragment)">FragmentManager.saveFragmentInstanceState
		/// 	</see>
		/// .
		/// </summary>
		public class SavedState : android.os.Parcelable
		{
			internal readonly android.os.Bundle mState;

			internal SavedState(android.os.Bundle state)
			{
				// Not yet created.
				// Created.
				// The activity has finished its creation.
				// Fully created, not started.
				// Created and started, not resumed.
				// Created started and resumed.
				// Non-null if the fragment's view hierarchy is currently animating away,
				// meaning we need to wait a bit on completely destroying it.  This is the
				// animation that is running.
				// If mAnimatingAway != null, this is the state we should move to once the
				// animation is done.
				// When instantiated from saved state, this is the saved state.
				// Index into active fragment array.
				// Internal unique name for this fragment;
				// Construction arguments;
				// Target fragment.
				// For use when retaining a fragment: this is the index of the last mTarget.
				// Target request code.
				// True if the fragment is in the list of added fragments.
				// If set this fragment is being removed from its activity.
				// True if the fragment is in the resumed state.
				// Set to true if this fragment was instantiated from a layout file.
				// Set to true when the view has actually been inflated in its layout.
				// True if this fragment has been restored from previously saved state.
				// Number of active back stack entries this fragment is in.
				// The fragment manager we are associated with.  Set as soon as the
				// fragment is used in a transaction; cleared after it has been removed
				// from all transactions.
				// Activity this fragment is attached to.
				// The optional identifier for this fragment -- either the container ID if it
				// was dynamically added to the view hierarchy, or the ID supplied in
				// layout.
				// When a fragment is being dynamically added to the view hierarchy, this
				// is the identifier of the parent container it is being added to.
				// The optional named tag for this fragment -- usually used to find
				// fragments that are not part of the layout.
				// Set to true when the app has requested that this fragment be hidden
				// from the user.
				// Set to true when the app has requested that this fragment be detached.
				// If set this fragment would like its instance retained across
				// configuration changes.
				// If set this fragment is being retained across the current config change.
				// If set this fragment has menu items to contribute.
				// Set to true to allow the fragment's menu to be shown.
				// Used to verify that subclasses call through to super class.
				// If app has requested a specific animation, this is the one to use.
				// The parent container of the fragment after dynamically added to UI.
				// The View generated for this fragment.
				mState = state;
			}

			internal SavedState(android.os.Parcel @in, java.lang.ClassLoader loader)
			{
				mState = @in.readBundle();
				if (loader != null && mState != null)
				{
					mState.setClassLoader(loader);
				}
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				dest.writeBundle(mState);
			}

			private sealed class _ClassLoaderCreator_490 : android.os.ParcelableClass.ClassLoaderCreator
				<android.app.Fragment.SavedState>
			{
				public _ClassLoaderCreator_490()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.Fragment.SavedState createFromParcel(android.os.Parcel @in)
				{
					return new android.app.Fragment.SavedState(@in, null);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.ClassLoaderCreator")]
				public android.app.Fragment.SavedState createFromParcel(android.os.Parcel @in, java.lang.ClassLoader
					 loader)
				{
					return new android.app.Fragment.SavedState(@in, loader);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.app.Fragment.SavedState[] newArray(int size)
				{
					return new android.app.Fragment.SavedState[size];
				}
			}

			public static readonly android.os.ParcelableClass.ClassLoaderCreator<android.app.Fragment
				.SavedState> CREATOR = new _ClassLoaderCreator_490();
		}

		/// <summary>
		/// Thrown by
		/// <see cref="Fragment.instantiate(android.content.Context, string, android.os.Bundle)
		/// 	">Fragment.instantiate(android.content.Context, string, android.os.Bundle)</see>
		/// when
		/// there is an instantiation failure.
		/// </summary>
		[System.Serializable]
		public class InstantiationException : android.util.AndroidRuntimeException
		{
			public InstantiationException(string msg, System.Exception cause) : base(msg, cause
				)
			{
			}
		}

		/// <summary>Default constructor.</summary>
		/// <remarks>
		/// Default constructor.  <strong>Every</strong> fragment must have an
		/// empty constructor, so it can be instantiated when restoring its
		/// activity's state.  It is strongly recommended that subclasses do not
		/// have other constructors with parameters, since these constructors
		/// will not be called when the fragment is re-instantiated; instead,
		/// arguments can be supplied by the caller with
		/// <see cref="setArguments(android.os.Bundle)">setArguments(android.os.Bundle)</see>
		/// and later retrieved by the Fragment with
		/// <see cref="getArguments()">getArguments()</see>
		/// .
		/// <p>Applications should generally not implement a constructor.  The
		/// first place application code an run where the fragment is ready to
		/// be used is in
		/// <see cref="onAttach(Activity)">onAttach(Activity)</see>
		/// , the point where the fragment
		/// is actually associated with its activity.  Some applications may also
		/// want to implement
		/// <see cref="onInflate(android.util.AttributeSet, android.os.Bundle)">onInflate(android.util.AttributeSet, android.os.Bundle)
		/// 	</see>
		/// to retrieve attributes from a
		/// layout resource, though should take care here because this happens for
		/// the fragment is attached to its activity.
		/// </remarks>
		public Fragment()
		{
		}

		/// <summary>
		/// Like
		/// <see cref="instantiate(android.content.Context, string, android.os.Bundle)">instantiate(android.content.Context, string, android.os.Bundle)
		/// 	</see>
		/// but with a null
		/// argument Bundle.
		/// </summary>
		public static android.app.Fragment instantiate(android.content.Context context, string
			 fname)
		{
			return instantiate(context, fname, null);
		}

		/// <summary>Create a new instance of a Fragment with the given class name.</summary>
		/// <remarks>
		/// Create a new instance of a Fragment with the given class name.  This is
		/// the same as calling its empty constructor.
		/// </remarks>
		/// <param name="context">
		/// The calling context being used to instantiate the fragment.
		/// This is currently just used to get its ClassLoader.
		/// </param>
		/// <param name="fname">The class name of the fragment to instantiate.</param>
		/// <param name="args">
		/// Bundle of arguments to supply to the fragment, which it
		/// can retrieve with
		/// <see cref="getArguments()">getArguments()</see>
		/// .  May be null.
		/// </param>
		/// <returns>Returns a new fragment instance.</returns>
		/// <exception cref="InstantiationException">
		/// If there is a failure in instantiating
		/// the given fragment class.  This is a runtime exception; it is not
		/// normally expected to happen.
		/// </exception>
		public static android.app.Fragment instantiate(android.content.Context context, string
			 fname, android.os.Bundle args)
		{
			try
			{
				System.Type clazz = sClassMap.get(fname);
				if (clazz == null)
				{
					// Class not found in the cache, see if it's real, and try to add it
					clazz = context.getClassLoader().loadClass(fname);
					sClassMap.put(fname, clazz);
				}
				android.app.Fragment f = (android.app.Fragment)System.Activator.CreateInstance(clazz
					);
				if (args != null)
				{
					args.setClassLoader(XobotOS.Runtime.Reflection.GetClassLoader(f.GetType()));
					f.mArguments = args;
				}
				return f;
			}
			catch (java.lang.ClassNotFoundException e)
			{
				throw new android.app.Fragment.InstantiationException("Unable to instantiate fragment "
					 + fname + ": make sure class name exists, is public, and has an" + " empty constructor that is public"
					, e);
			}
			catch (java.lang.InstantiationException e)
			{
				throw new android.app.Fragment.InstantiationException("Unable to instantiate fragment "
					 + fname + ": make sure class name exists, is public, and has an" + " empty constructor that is public"
					, e);
			}
			catch (System.MemberAccessException e)
			{
				throw new android.app.Fragment.InstantiationException("Unable to instantiate fragment "
					 + fname + ": make sure class name exists, is public, and has an" + " empty constructor that is public"
					, e);
			}
		}

		internal void restoreViewState()
		{
			if (mSavedViewState != null)
			{
				mView.restoreHierarchyState(mSavedViewState);
				mSavedViewState = null;
			}
		}

		internal void setIndex(int index)
		{
			mIndex = index;
			mWho = "android:fragment:" + mIndex;
		}

		internal bool isInBackStack()
		{
			return mBackStackNesting > 0;
		}

		/// <summary>Subclasses can not override equals().</summary>
		/// <remarks>Subclasses can not override equals().</remarks>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override bool Equals(object o)
		{
			return base.Equals(o);
		}

		/// <summary>Subclasses can not override hashCode().</summary>
		/// <remarks>Subclasses can not override hashCode().</remarks>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(128);
			android.util.DebugUtils.buildShortClassTag(this, sb);
			if (mIndex >= 0)
			{
				sb.append(" #");
				sb.append(mIndex);
			}
			if (mFragmentId != 0)
			{
				sb.append(" id=0x");
				sb.append(Sharpen.Util.IntToHexString(mFragmentId));
			}
			if (mTag != null)
			{
				sb.append(" ");
				sb.append(mTag);
			}
			sb.append('}');
			return sb.ToString();
		}

		/// <summary>Return the identifier this fragment is known by.</summary>
		/// <remarks>
		/// Return the identifier this fragment is known by.  This is either
		/// the android:id value supplied in a layout or the container view ID
		/// supplied when adding the fragment.
		/// </remarks>
		public int getId()
		{
			return mFragmentId;
		}

		/// <summary>Get the tag name of the fragment, if specified.</summary>
		/// <remarks>Get the tag name of the fragment, if specified.</remarks>
		public string getTag()
		{
			return mTag;
		}

		/// <summary>Supply the construction arguments for this fragment.</summary>
		/// <remarks>
		/// Supply the construction arguments for this fragment.  This can only
		/// be called before the fragment has been attached to its activity; that
		/// is, you should call it immediately after constructing the fragment.  The
		/// arguments supplied here will be retained across fragment destroy and
		/// creation.
		/// </remarks>
		public virtual void setArguments(android.os.Bundle args)
		{
			if (mIndex >= 0)
			{
				throw new System.InvalidOperationException("Fragment already active");
			}
			mArguments = args;
		}

		/// <summary>
		/// Return the arguments supplied when the fragment was instantiated,
		/// if any.
		/// </summary>
		/// <remarks>
		/// Return the arguments supplied when the fragment was instantiated,
		/// if any.
		/// </remarks>
		public android.os.Bundle getArguments()
		{
			return mArguments;
		}

		/// <summary>
		/// Set the initial saved state that this Fragment should restore itself
		/// from when first being constructed, as returned by
		/// <see cref="FragmentManager.saveFragmentInstanceState(Fragment)">FragmentManager.saveFragmentInstanceState
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="state">The state the fragment should be restored from.</param>
		public virtual void setInitialSavedState(android.app.Fragment.SavedState state)
		{
			if (mIndex >= 0)
			{
				throw new System.InvalidOperationException("Fragment already active");
			}
			mSavedFragmentState = state != null && state.mState != null ? state.mState : null;
		}

		/// <summary>Optional target for this fragment.</summary>
		/// <remarks>
		/// Optional target for this fragment.  This may be used, for example,
		/// if this fragment is being started by another, and when done wants to
		/// give a result back to the first.  The target set here is retained
		/// across instances via
		/// <see cref="FragmentManager.putFragment(android.os.Bundle, string, Fragment)">FragmentManager.putFragment()
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="fragment">The fragment that is the target of this one.</param>
		/// <param name="requestCode">
		/// Optional request code, for convenience if you
		/// are going to call back with
		/// <see cref="onActivityResult(int, int, android.content.Intent)">onActivityResult(int, int, android.content.Intent)
		/// 	</see>
		/// .
		/// </param>
		public virtual void setTargetFragment(android.app.Fragment fragment, int requestCode
			)
		{
			mTarget = fragment;
			mTargetRequestCode = requestCode;
		}

		/// <summary>
		/// Return the target fragment set by
		/// <see cref="setTargetFragment(Fragment, int)">setTargetFragment(Fragment, int)</see>
		/// .
		/// </summary>
		public android.app.Fragment getTargetFragment()
		{
			return mTarget;
		}

		/// <summary>
		/// Return the target request code set by
		/// <see cref="setTargetFragment(Fragment, int)">setTargetFragment(Fragment, int)</see>
		/// .
		/// </summary>
		public int getTargetRequestCode()
		{
			return mTargetRequestCode;
		}

		/// <summary>Return the Activity this fragment is currently associated with.</summary>
		/// <remarks>Return the Activity this fragment is currently associated with.</remarks>
		public android.app.Activity getActivity()
		{
			return mActivity;
		}

		/// <summary>Return <code>getActivity().getResources()</code>.</summary>
		/// <remarks>Return <code>getActivity().getResources()</code>.</remarks>
		public android.content.res.Resources getResources()
		{
			if (mActivity == null)
			{
				throw new System.InvalidOperationException("Fragment " + this + " not attached to Activity"
					);
			}
			return mActivity.getResources();
		}

		/// <summary>
		/// Return a localized, styled CharSequence from the application's package's
		/// default string table.
		/// </summary>
		/// <remarks>
		/// Return a localized, styled CharSequence from the application's package's
		/// default string table.
		/// </remarks>
		/// <param name="resId">Resource id for the CharSequence text</param>
		public java.lang.CharSequence getText(int resId)
		{
			return getResources().getText(resId);
		}

		/// <summary>
		/// Return a localized string from the application's package's
		/// default string table.
		/// </summary>
		/// <remarks>
		/// Return a localized string from the application's package's
		/// default string table.
		/// </remarks>
		/// <param name="resId">Resource id for the string</param>
		public string getString(int resId)
		{
			return getResources().getString(resId);
		}

		/// <summary>
		/// Return a localized formatted string from the application's package's
		/// default string table, substituting the format arguments as defined in
		/// <see cref="java.util.Formatter">java.util.Formatter</see>
		/// and
		/// <see cref="string.Format(string, object[])">string.Format(string, object[])</see>
		/// .
		/// </summary>
		/// <param name="resId">Resource id for the format string</param>
		/// <param name="formatArgs">The format arguments that will be used for substitution.
		/// 	</param>
		public string getString(int resId, params object[] formatArgs)
		{
			return getResources().getString(resId, formatArgs);
		}

		/// <summary>
		/// Return the FragmentManager for interacting with fragments associated
		/// with this fragment's activity.
		/// </summary>
		/// <remarks>
		/// Return the FragmentManager for interacting with fragments associated
		/// with this fragment's activity.  Note that this will be non-null slightly
		/// before
		/// <see cref="getActivity()">getActivity()</see>
		/// , during the time from when the fragment is
		/// placed in a
		/// <see cref="FragmentTransaction">FragmentTransaction</see>
		/// until it is committed and
		/// attached to its activity.
		/// </remarks>
		public android.app.FragmentManager getFragmentManager()
		{
			return mFragmentManager;
		}

		/// <summary>Return true if the fragment is currently added to its activity.</summary>
		/// <remarks>Return true if the fragment is currently added to its activity.</remarks>
		public bool isAdded()
		{
			return mActivity != null && mAdded;
		}

		/// <summary>Return true if the fragment has been explicitly detached from the UI.</summary>
		/// <remarks>
		/// Return true if the fragment has been explicitly detached from the UI.
		/// That is,
		/// <see cref="FragmentTransaction.detach(Fragment)">FragmentTransaction.detach(Fragment)
		/// 	</see>
		/// has been used on it.
		/// </remarks>
		public bool isDetached()
		{
			return mDetached;
		}

		/// <summary>
		/// Return true if this fragment is currently being removed from its
		/// activity.
		/// </summary>
		/// <remarks>
		/// Return true if this fragment is currently being removed from its
		/// activity.  This is  <em>not</em> whether its activity is finishing, but
		/// rather whether it is in the process of being removed from its activity.
		/// </remarks>
		public bool isRemoving()
		{
			return mRemoving;
		}

		/// <summary>
		/// Return true if the layout is included as part of an activity view
		/// hierarchy via the &lt;fragment&gt; tag.
		/// </summary>
		/// <remarks>
		/// Return true if the layout is included as part of an activity view
		/// hierarchy via the &lt;fragment&gt; tag.  This will always be true when
		/// fragments are created through the &lt;fragment&gt; tag, <em>except</em>
		/// in the case where an old fragment is restored from a previous state and
		/// it does not appear in the layout of the current state.
		/// </remarks>
		public bool isInLayout()
		{
			return mInLayout;
		}

		/// <summary>Return true if the fragment is in the resumed state.</summary>
		/// <remarks>
		/// Return true if the fragment is in the resumed state.  This is true
		/// for the duration of
		/// <see cref="onResume()">onResume()</see>
		/// and
		/// <see cref="onPause()">onPause()</see>
		/// as well.
		/// </remarks>
		public bool isResumed()
		{
			return mResumed;
		}

		/// <summary>Return true if the fragment is currently visible to the user.</summary>
		/// <remarks>
		/// Return true if the fragment is currently visible to the user.  This means
		/// it: (1) has been added, (2) has its view attached to the window, and
		/// (3) is not hidden.
		/// </remarks>
		public bool isVisible()
		{
			return isAdded() && !isHidden() && mView != null && mView.getWindowToken() != null
				 && mView.getVisibility() == android.view.View.VISIBLE;
		}

		/// <summary>Return true if the fragment has been hidden.</summary>
		/// <remarks>
		/// Return true if the fragment has been hidden.  By default fragments
		/// are shown.  You can find out about changes to this state with
		/// <see cref="onHiddenChanged(bool)">onHiddenChanged(bool)</see>
		/// .  Note that the hidden state is orthogonal
		/// to other states -- that is, to be visible to the user, a fragment
		/// must be both started and not hidden.
		/// </remarks>
		public bool isHidden()
		{
			return mHidden;
		}

		/// <summary>
		/// Called when the hidden state (as returned by
		/// <see cref="isHidden()">isHidden()</see>
		/// of
		/// the fragment has changed.  Fragments start out not hidden; this will
		/// be called whenever the fragment changes state from that.
		/// </summary>
		/// <param name="hidden">
		/// True if the fragment is now hidden, false if it is not
		/// visible.
		/// </param>
		public virtual void onHiddenChanged(bool hidden)
		{
		}

		/// <summary>
		/// Control whether a fragment instance is retained across Activity
		/// re-creation (such as from a configuration change).
		/// </summary>
		/// <remarks>
		/// Control whether a fragment instance is retained across Activity
		/// re-creation (such as from a configuration change).  This can only
		/// be used with fragments not in the back stack.  If set, the fragment
		/// lifecycle will be slightly different when an activity is recreated:
		/// <ul>
		/// <li>
		/// <see cref="onDestroy()">onDestroy()</see>
		/// will not be called (but
		/// <see cref="onDetach()">onDetach()</see>
		/// still
		/// will be, because the fragment is being detached from its current activity).
		/// <li>
		/// <see cref="onCreate(android.os.Bundle)">onCreate(android.os.Bundle)</see>
		/// will not be called since the fragment
		/// is not being re-created.
		/// <li>
		/// <see cref="onAttach(Activity)">onAttach(Activity)</see>
		/// and
		/// <see cref="onActivityCreated(android.os.Bundle)">onActivityCreated(android.os.Bundle)
		/// 	</see>
		/// <b>will</b>
		/// still be called.
		/// </ul>
		/// </remarks>
		public virtual void setRetainInstance(bool retain)
		{
			mRetainInstance = retain;
		}

		public bool getRetainInstance()
		{
			return mRetainInstance;
		}

		/// <summary>
		/// Report that this fragment would like to participate in populating
		/// the options menu by receiving a call to
		/// <see cref="onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)">onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)
		/// 	</see>
		/// and related methods.
		/// </summary>
		/// <param name="hasMenu">If true, the fragment has menu items to contribute.</param>
		public virtual void setHasOptionsMenu(bool hasMenu)
		{
			if (mHasMenu != hasMenu)
			{
				mHasMenu = hasMenu;
				if (isAdded() && !isHidden())
				{
					mFragmentManager.invalidateOptionsMenu();
				}
			}
		}

		/// <summary>Set a hint for whether this fragment's menu should be visible.</summary>
		/// <remarks>
		/// Set a hint for whether this fragment's menu should be visible.  This
		/// is useful if you know that a fragment has been placed in your view
		/// hierarchy so that the user can not currently seen it, so any menu items
		/// it has should also not be shown.
		/// </remarks>
		/// <param name="menuVisible">
		/// The default is true, meaning the fragment's menu will
		/// be shown as usual.  If false, the user will not see the menu.
		/// </param>
		public virtual void setMenuVisibility(bool menuVisible)
		{
			if (mMenuVisible != menuVisible)
			{
				mMenuVisible = menuVisible;
				if (mHasMenu && isAdded() && !isHidden())
				{
					mFragmentManager.invalidateOptionsMenu();
				}
			}
		}

		/// <summary>Return the LoaderManager for this fragment, creating it if needed.</summary>
		/// <remarks>Return the LoaderManager for this fragment, creating it if needed.</remarks>
		public virtual android.app.LoaderManager getLoaderManager()
		{
			if (mLoaderManager != null)
			{
				return mLoaderManager;
			}
			if (mActivity == null)
			{
				throw new System.InvalidOperationException("Fragment " + this + " not attached to Activity"
					);
			}
			mCheckedForLoaderManager = true;
			mLoaderManager = mActivity.getLoaderManager(mIndex, mLoadersStarted, true);
			return mLoaderManager;
		}

		/// <summary>
		/// Call
		/// <see cref="Activity.startActivity(android.content.Intent)">Activity.startActivity(android.content.Intent)
		/// 	</see>
		/// on the fragment's
		/// containing Activity.
		/// </summary>
		public virtual void startActivity(android.content.Intent intent)
		{
			if (mActivity == null)
			{
				throw new System.InvalidOperationException("Fragment " + this + " not attached to Activity"
					);
			}
			mActivity.startActivityFromFragment(this, intent, -1);
		}

		/// <summary>
		/// Call
		/// <see cref="Activity.startActivityForResult(android.content.Intent, int)">Activity.startActivityForResult(android.content.Intent, int)
		/// 	</see>
		/// on the fragment's
		/// containing Activity.
		/// </summary>
		public virtual void startActivityForResult(android.content.Intent intent, int requestCode
			)
		{
			if (mActivity == null)
			{
				throw new System.InvalidOperationException("Fragment " + this + " not attached to Activity"
					);
			}
			mActivity.startActivityFromFragment(this, intent, requestCode);
		}

		/// <summary>
		/// Receive the result from a previous call to
		/// <see cref="startActivityForResult(android.content.Intent, int)">startActivityForResult(android.content.Intent, int)
		/// 	</see>
		/// .  This follows the
		/// related Activity API as described there in
		/// <see cref="Activity.onActivityResult(int, int, android.content.Intent)">Activity.onActivityResult(int, int, android.content.Intent)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="requestCode">
		/// The integer request code originally supplied to
		/// startActivityForResult(), allowing you to identify who this
		/// result came from.
		/// </param>
		/// <param name="resultCode">
		/// The integer result code returned by the child activity
		/// through its setResult().
		/// </param>
		/// <param name="data">
		/// An Intent, which can return result data to the caller
		/// (various data can be attached to Intent "extras").
		/// </param>
		public virtual void onActivityResult(int requestCode, int resultCode, android.content.Intent
			 data)
		{
		}

		/// <hide>
		/// Hack so that DialogFragment can make its Dialog before creating
		/// its views, and the view construction can use the dialog's context for
		/// inflation.  Maybe this should become a public API. Note sure.
		/// </hide>
		public virtual android.view.LayoutInflater getLayoutInflater(android.os.Bundle savedInstanceState
			)
		{
			return mActivity.getLayoutInflater();
		}

		[System.ObsoleteAttribute(@"Use onInflate(Activity, android.util.AttributeSet, android.os.Bundle) instead."
			)]
		public virtual void onInflate(android.util.AttributeSet attrs, android.os.Bundle 
			savedInstanceState)
		{
			mCalled = true;
		}

		/// <summary>
		/// Called when a fragment is being created as part of a view layout
		/// inflation, typically from setting the content view of an activity.
		/// </summary>
		/// <remarks>
		/// Called when a fragment is being created as part of a view layout
		/// inflation, typically from setting the content view of an activity.  This
		/// may be called immediately after the fragment is created from a <fragment>
		/// tag in a layout file.  Note this is <em>before</em> the fragment's
		/// <see cref="onAttach(Activity)">onAttach(Activity)</see>
		/// has been called; all you should do here is
		/// parse the attributes and save them away.
		/// <p>This is called every time the fragment is inflated, even if it is
		/// being inflated into a new instance with saved state.  It typically makes
		/// sense to re-parse the parameters each time, to allow them to change with
		/// different configurations.</p>
		/// <p>Here is a typical implementation of a fragment that can take parameters
		/// both through attributes supplied here as well from
		/// <see cref="getArguments()">getArguments()</see>
		/// :</p>
		/// <sample>
		/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentArguments.java
		/// fragment
		/// </sample>
		/// <p>Note that parsing the XML attributes uses a "styleable" resource.  The
		/// declaration for the styleable used here is:</p>
		/// <sample>development/samples/ApiDemos/res/values/attrs.xml fragment_arguments</sample>
		/// <p>The fragment can then be declared within its activity's content layout
		/// through a tag like this:</p>
		/// <sample>development/samples/ApiDemos/res/layout/fragment_arguments.xml from_attributes
		/// 	</sample>
		/// <p>This fragment can also be created dynamically from arguments given
		/// at runtime in the arguments Bundle; here is an example of doing so at
		/// creation of the containing activity:</p>
		/// <sample>
		/// development/samples/ApiDemos/src/com/example/android/apis/app/FragmentArguments.java
		/// create
		/// </sample>
		/// </remarks>
		/// <param name="activity">The Activity that is inflating this fragment.</param>
		/// <param name="attrs">
		/// The attributes at the tag where the fragment is
		/// being created.
		/// </param>
		/// <param name="savedInstanceState">
		/// If the fragment is being re-created from
		/// a previous saved state, this is the state.
		/// </param>
		public virtual void onInflate(android.app.Activity activity, android.util.AttributeSet
			 attrs, android.os.Bundle savedInstanceState)
		{
			onInflate(attrs, savedInstanceState);
			mCalled = true;
		}

		/// <summary>Called when a fragment is first attached to its activity.</summary>
		/// <remarks>
		/// Called when a fragment is first attached to its activity.
		/// <see cref="onCreate(android.os.Bundle)">onCreate(android.os.Bundle)</see>
		/// will be called after this.
		/// </remarks>
		public virtual void onAttach(android.app.Activity activity)
		{
			mCalled = true;
		}

		/// <summary>Called when a fragment loads an animation.</summary>
		/// <remarks>Called when a fragment loads an animation.</remarks>
		public virtual android.animation.Animator onCreateAnimator(int transit, bool enter
			, int nextAnim)
		{
			return null;
		}

		/// <summary>Called to do initial creation of a fragment.</summary>
		/// <remarks>
		/// Called to do initial creation of a fragment.  This is called after
		/// <see cref="onAttach(Activity)">onAttach(Activity)</see>
		/// and before
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// .
		/// <p>Note that this can be called while the fragment's activity is
		/// still in the process of being created.  As such, you can not rely
		/// on things like the activity's content view hierarchy being initialized
		/// at this point.  If you want to do work once the activity itself is
		/// created, see
		/// <see cref="onActivityCreated(android.os.Bundle)">onActivityCreated(android.os.Bundle)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="savedInstanceState">
		/// If the fragment is being re-created from
		/// a previous saved state, this is the state.
		/// </param>
		public virtual void onCreate(android.os.Bundle savedInstanceState)
		{
			mCalled = true;
		}

		/// <summary>
		/// Called immediately after
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// has returned, but before any saved state has been restored in to the view.
		/// This gives subclasses a chance to initialize themselves once
		/// they know their view hierarchy has been completely created.  The fragment's
		/// view hierarchy is not however attached to its parent at this point.
		/// </summary>
		/// <param name="view">
		/// The View returned by
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// .
		/// </param>
		/// <param name="savedInstanceState">
		/// If non-null, this fragment is being re-constructed
		/// from a previous saved state as given here.
		/// </param>
		public virtual void onViewCreated(android.view.View view, android.os.Bundle savedInstanceState
			)
		{
		}

		/// <summary>Called to have the fragment instantiate its user interface view.</summary>
		/// <remarks>
		/// Called to have the fragment instantiate its user interface view.
		/// This is optional, and non-graphical fragments can return null (which
		/// is the default implementation).  This will be called between
		/// <see cref="onCreate(android.os.Bundle)">onCreate(android.os.Bundle)</see>
		/// and
		/// <see cref="onActivityCreated(android.os.Bundle)">onActivityCreated(android.os.Bundle)
		/// 	</see>
		/// .
		/// <p>If you return a View from here, you will later be called in
		/// <see cref="onDestroyView()">onDestroyView()</see>
		/// when the view is being released.
		/// </remarks>
		/// <param name="inflater">
		/// The LayoutInflater object that can be used to inflate
		/// any views in the fragment,
		/// </param>
		/// <param name="container">
		/// If non-null, this is the parent view that the fragment's
		/// UI should be attached to.  The fragment should not add the view itself,
		/// but this can be used to generate the LayoutParams of the view.
		/// </param>
		/// <param name="savedInstanceState">
		/// If non-null, this fragment is being re-constructed
		/// from a previous saved state as given here.
		/// </param>
		/// <returns>Return the View for the fragment's UI, or null.</returns>
		public virtual android.view.View onCreateView(android.view.LayoutInflater inflater
			, android.view.ViewGroup container, android.os.Bundle savedInstanceState)
		{
			return null;
		}

		/// <summary>
		/// Get the root view for the fragment's layout (the one returned by
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// ),
		/// if provided.
		/// </summary>
		/// <returns>The fragment's root view, or null if it has no layout.</returns>
		public virtual android.view.View getView()
		{
			return mView;
		}

		/// <summary>
		/// Called when the fragment's activity has been created and this
		/// fragment's view hierarchy instantiated.
		/// </summary>
		/// <remarks>
		/// Called when the fragment's activity has been created and this
		/// fragment's view hierarchy instantiated.  It can be used to do final
		/// initialization once these pieces are in place, such as retrieving
		/// views or restoring state.  It is also useful for fragments that use
		/// <see cref="setRetainInstance(bool)">setRetainInstance(bool)</see>
		/// to retain their instance,
		/// as this callback tells the fragment when it is fully associated with
		/// the new activity instance.  This is called after
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// and before
		/// <see cref="onStart()">onStart()</see>
		/// .
		/// </remarks>
		/// <param name="savedInstanceState">
		/// If the fragment is being re-created from
		/// a previous saved state, this is the state.
		/// </param>
		public virtual void onActivityCreated(android.os.Bundle savedInstanceState)
		{
			mCalled = true;
		}

		/// <summary>Called when the Fragment is visible to the user.</summary>
		/// <remarks>
		/// Called when the Fragment is visible to the user.  This is generally
		/// tied to
		/// <see cref="Activity.onStart()">Activity.onStart</see>
		/// of the containing
		/// Activity's lifecycle.
		/// </remarks>
		public virtual void onStart()
		{
			mCalled = true;
			if (!mLoadersStarted)
			{
				mLoadersStarted = true;
				if (!mCheckedForLoaderManager)
				{
					mCheckedForLoaderManager = true;
					mLoaderManager = mActivity.getLoaderManager(mIndex, mLoadersStarted, false);
				}
				if (mLoaderManager != null)
				{
					mLoaderManager.doStart();
				}
			}
		}

		/// <summary>Called when the fragment is visible to the user and actively running.</summary>
		/// <remarks>
		/// Called when the fragment is visible to the user and actively running.
		/// This is generally
		/// tied to
		/// <see cref="Activity.onResume()">Activity.onResume</see>
		/// of the containing
		/// Activity's lifecycle.
		/// </remarks>
		public virtual void onResume()
		{
			mCalled = true;
		}

		/// <summary>
		/// Called to ask the fragment to save its current dynamic state, so it
		/// can later be reconstructed in a new instance of its process is
		/// restarted.
		/// </summary>
		/// <remarks>
		/// Called to ask the fragment to save its current dynamic state, so it
		/// can later be reconstructed in a new instance of its process is
		/// restarted.  If a new instance of the fragment later needs to be
		/// created, the data you place in the Bundle here will be available
		/// in the Bundle given to
		/// <see cref="onCreate(android.os.Bundle)">onCreate(android.os.Bundle)</see>
		/// ,
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// , and
		/// <see cref="onActivityCreated(android.os.Bundle)">onActivityCreated(android.os.Bundle)
		/// 	</see>
		/// .
		/// <p>This corresponds to
		/// <see cref="Activity.onSaveInstanceState(android.os.Bundle)">Activity.onSaveInstanceState(Bundle)
		/// 	</see>
		/// and most of the discussion there
		/// applies here as well.  Note however: <em>this method may be called
		/// at any time before
		/// <see cref="onDestroy()">onDestroy()</see>
		/// </em>.  There are many situations
		/// where a fragment may be mostly torn down (such as when placed on the
		/// back stack with no UI showing), but its state will not be saved until
		/// its owning activity actually needs to save its state.
		/// </remarks>
		/// <param name="outState">Bundle in which to place your saved state.</param>
		public virtual void onSaveInstanceState(android.os.Bundle outState)
		{
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			mCalled = true;
		}

		/// <summary>Called when the Fragment is no longer resumed.</summary>
		/// <remarks>
		/// Called when the Fragment is no longer resumed.  This is generally
		/// tied to
		/// <see cref="Activity.onPause()">Activity.onPause</see>
		/// of the containing
		/// Activity's lifecycle.
		/// </remarks>
		public virtual void onPause()
		{
			mCalled = true;
		}

		/// <summary>Called when the Fragment is no longer started.</summary>
		/// <remarks>
		/// Called when the Fragment is no longer started.  This is generally
		/// tied to
		/// <see cref="Activity.onStop()">Activity.onStop</see>
		/// of the containing
		/// Activity's lifecycle.
		/// </remarks>
		public virtual void onStop()
		{
			mCalled = true;
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onLowMemory()
		{
			mCalled = true;
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks2")]
		public virtual void onTrimMemory(int level)
		{
			mCalled = true;
		}

		/// <summary>
		/// Called when the view previously created by
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// has
		/// been detached from the fragment.  The next time the fragment needs
		/// to be displayed, a new view will be created.  This is called
		/// after
		/// <see cref="onStop()">onStop()</see>
		/// and before
		/// <see cref="onDestroy()">onDestroy()</see>
		/// .  It is called
		/// <em>regardless</em> of whether
		/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
		/// 	</see>
		/// returned a
		/// non-null view.  Internally it is called after the view's state has
		/// been saved but before it has been removed from its parent.
		/// </summary>
		public virtual void onDestroyView()
		{
			mCalled = true;
		}

		/// <summary>Called when the fragment is no longer in use.</summary>
		/// <remarks>
		/// Called when the fragment is no longer in use.  This is called
		/// after
		/// <see cref="onStop()">onStop()</see>
		/// and before
		/// <see cref="onDetach()">onDetach()</see>
		/// .
		/// </remarks>
		public virtual void onDestroy()
		{
			mCalled = true;
			//Log.v("foo", "onDestroy: mCheckedForLoaderManager=" + mCheckedForLoaderManager
			//        + " mLoaderManager=" + mLoaderManager);
			if (!mCheckedForLoaderManager)
			{
				mCheckedForLoaderManager = true;
				mLoaderManager = mActivity.getLoaderManager(mIndex, mLoadersStarted, false);
			}
			if (mLoaderManager != null)
			{
				mLoaderManager.doDestroy();
			}
		}

		/// <summary>
		/// Called by the fragment manager once this fragment has been removed,
		/// so that we don't have any left-over state if the application decides
		/// to re-use the instance.
		/// </summary>
		/// <remarks>
		/// Called by the fragment manager once this fragment has been removed,
		/// so that we don't have any left-over state if the application decides
		/// to re-use the instance.  This only clears state that the framework
		/// internally manages, not things the application sets.
		/// </remarks>
		internal virtual void initState()
		{
			mIndex = -1;
			mWho = null;
			mAdded = false;
			mRemoving = false;
			mResumed = false;
			mFromLayout = false;
			mInLayout = false;
			mRestored = false;
			mBackStackNesting = 0;
			mFragmentManager = null;
			mActivity = null;
			mFragmentId = 0;
			mContainerId = 0;
			mTag = null;
			mHidden = false;
			mDetached = false;
			mRetaining = false;
			mLoaderManager = null;
			mLoadersStarted = false;
			mCheckedForLoaderManager = false;
		}

		/// <summary>Called when the fragment is no longer attached to its activity.</summary>
		/// <remarks>
		/// Called when the fragment is no longer attached to its activity.  This
		/// is called after
		/// <see cref="onDestroy()">onDestroy()</see>
		/// .
		/// </remarks>
		public virtual void onDetach()
		{
			mCalled = true;
		}

		/// <summary>Initialize the contents of the Activity's standard options menu.</summary>
		/// <remarks>
		/// Initialize the contents of the Activity's standard options menu.  You
		/// should place your menu items in to <var>menu</var>.  For this method
		/// to be called, you must have first called
		/// <see cref="setHasOptionsMenu(bool)">setHasOptionsMenu(bool)</see>
		/// .  See
		/// <see cref="Activity.onCreateOptionsMenu(android.view.Menu)">Activity.onCreateOptionsMenu
		/// 	</see>
		/// for more information.
		/// </remarks>
		/// <param name="menu">The options menu in which you place your items.</param>
		/// <seealso cref="setHasOptionsMenu(bool)">setHasOptionsMenu(bool)</seealso>
		/// <seealso cref="onPrepareOptionsMenu(android.view.Menu)">onPrepareOptionsMenu(android.view.Menu)
		/// 	</seealso>
		/// <seealso cref="onOptionsItemSelected(android.view.MenuItem)">onOptionsItemSelected(android.view.MenuItem)
		/// 	</seealso>
		public virtual void onCreateOptionsMenu(android.view.Menu menu, android.view.MenuInflater
			 inflater)
		{
		}

		/// <summary>Prepare the Screen's standard options menu to be displayed.</summary>
		/// <remarks>
		/// Prepare the Screen's standard options menu to be displayed.  This is
		/// called right before the menu is shown, every time it is shown.  You can
		/// use this method to efficiently enable/disable items or otherwise
		/// dynamically modify the contents.  See
		/// <see cref="Activity.onPrepareOptionsMenu(android.view.Menu)">Activity.onPrepareOptionsMenu
		/// 	</see>
		/// for more information.
		/// </remarks>
		/// <param name="menu">
		/// The options menu as last shown or first initialized by
		/// onCreateOptionsMenu().
		/// </param>
		/// <seealso cref="setHasOptionsMenu(bool)">setHasOptionsMenu(bool)</seealso>
		/// <seealso cref="onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)"
		/// 	>onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)</seealso>
		public virtual void onPrepareOptionsMenu(android.view.Menu menu)
		{
		}

		/// <summary>
		/// Called when this fragment's option menu items are no longer being
		/// included in the overall options menu.
		/// </summary>
		/// <remarks>
		/// Called when this fragment's option menu items are no longer being
		/// included in the overall options menu.  Receiving this call means that
		/// the menu needed to be rebuilt, but this fragment's items were not
		/// included in the newly built menu (its
		/// <see cref="onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)">onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)
		/// 	</see>
		/// was not called).
		/// </remarks>
		public virtual void onDestroyOptionsMenu()
		{
		}

		/// <summary>This hook is called whenever an item in your options menu is selected.</summary>
		/// <remarks>
		/// This hook is called whenever an item in your options menu is selected.
		/// The default implementation simply returns false to have the normal
		/// processing happen (calling the item's Runnable or sending a message to
		/// its Handler as appropriate).  You can use this method for any items
		/// for which you would like to do processing without those other
		/// facilities.
		/// <p>Derived classes should call through to the base class for it to
		/// perform the default menu handling.
		/// </remarks>
		/// <param name="item">The menu item that was selected.</param>
		/// <returns>
		/// boolean Return false to allow normal menu processing to
		/// proceed, true to consume it here.
		/// </returns>
		/// <seealso cref="onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)"
		/// 	>onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)</seealso>
		public virtual bool onOptionsItemSelected(android.view.MenuItem item)
		{
			return false;
		}

		/// <summary>
		/// This hook is called whenever the options menu is being closed (either by the user canceling
		/// the menu with the back/menu button, or when an item is selected).
		/// </summary>
		/// <remarks>
		/// This hook is called whenever the options menu is being closed (either by the user canceling
		/// the menu with the back/menu button, or when an item is selected).
		/// </remarks>
		/// <param name="menu">
		/// The options menu as last shown or first initialized by
		/// onCreateOptionsMenu().
		/// </param>
		public virtual void onOptionsMenuClosed(android.view.Menu menu)
		{
		}

		/// <summary>
		/// Called when a context menu for the
		/// <code>view</code>
		/// is about to be shown.
		/// Unlike
		/// <see cref="onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)">onCreateOptionsMenu(android.view.Menu, android.view.MenuInflater)
		/// 	</see>
		/// , this will be called every
		/// time the context menu is about to be shown and should be populated for
		/// the view (or item inside the view for
		/// <see cref="android.widget.AdapterView{T}">android.widget.AdapterView&lt;T&gt;</see>
		/// subclasses,
		/// this can be found in the
		/// <code>menuInfo</code>
		/// )).
		/// <p>
		/// Use
		/// <see cref="onContextItemSelected(android.view.MenuItem)">onContextItemSelected(android.view.MenuItem)
		/// 	</see>
		/// to know when an
		/// item has been selected.
		/// <p>
		/// The default implementation calls up to
		/// <see cref="Activity.onCreateContextMenu(android.view.ContextMenu, android.view.View, android.view.ContextMenuClass.ContextMenuInfo)
		/// 	">Activity.onCreateContextMenu</see>
		/// , though
		/// you can not call this implementation if you don't want that behavior.
		/// <p>
		/// It is not safe to hold onto the context menu after this method returns.
		/// <inheritDoc></inheritDoc>
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.view.View.OnCreateContextMenuListener")]
		public virtual void onCreateContextMenu(android.view.ContextMenu menu, android.view.View
			 v, android.view.ContextMenuClass.ContextMenuInfo menuInfo)
		{
			getActivity().onCreateContextMenu(menu, v, menuInfo);
		}

		/// <summary>
		/// Registers a context menu to be shown for the given view (multiple views
		/// can show the context menu).
		/// </summary>
		/// <remarks>
		/// Registers a context menu to be shown for the given view (multiple views
		/// can show the context menu). This method will set the
		/// <see cref="android.view.View.OnCreateContextMenuListener">android.view.View.OnCreateContextMenuListener
		/// 	</see>
		/// on the view to this fragment, so
		/// <see cref="onCreateContextMenu(android.view.ContextMenu, android.view.View, android.view.ContextMenuClass.ContextMenuInfo)
		/// 	">onCreateContextMenu(android.view.ContextMenu, android.view.View, android.view.ContextMenuClass.ContextMenuInfo)
		/// 	</see>
		/// will be
		/// called when it is time to show the context menu.
		/// </remarks>
		/// <seealso cref="unregisterForContextMenu(android.view.View)">unregisterForContextMenu(android.view.View)
		/// 	</seealso>
		/// <param name="view">The view that should show a context menu.</param>
		public virtual void registerForContextMenu(android.view.View view)
		{
			view.setOnCreateContextMenuListener(this);
		}

		/// <summary>Prevents a context menu to be shown for the given view.</summary>
		/// <remarks>
		/// Prevents a context menu to be shown for the given view. This method will
		/// remove the
		/// <see cref="android.view.View.OnCreateContextMenuListener">android.view.View.OnCreateContextMenuListener
		/// 	</see>
		/// on the view.
		/// </remarks>
		/// <seealso cref="registerForContextMenu(android.view.View)">registerForContextMenu(android.view.View)
		/// 	</seealso>
		/// <param name="view">The view that should stop showing a context menu.</param>
		public virtual void unregisterForContextMenu(android.view.View view)
		{
			view.setOnCreateContextMenuListener(null);
		}

		/// <summary>This hook is called whenever an item in a context menu is selected.</summary>
		/// <remarks>
		/// This hook is called whenever an item in a context menu is selected. The
		/// default implementation simply returns false to have the normal processing
		/// happen (calling the item's Runnable or sending a message to its Handler
		/// as appropriate). You can use this method for any items for which you
		/// would like to do processing without those other facilities.
		/// <p>
		/// Use
		/// <see cref="android.view.MenuItem.getMenuInfo()">android.view.MenuItem.getMenuInfo()
		/// 	</see>
		/// to get extra information set by the
		/// View that added this menu item.
		/// <p>
		/// Derived classes should call through to the base class for it to perform
		/// the default menu handling.
		/// </remarks>
		/// <param name="item">The context menu item that was selected.</param>
		/// <returns>
		/// boolean Return false to allow normal context menu processing to
		/// proceed, true to consume it here.
		/// </returns>
		public virtual bool onContextItemSelected(android.view.MenuItem item)
		{
			return false;
		}

		/// <summary>Print the Fragments's state into the given stream.</summary>
		/// <remarks>Print the Fragments's state into the given stream.</remarks>
		/// <param name="prefix">Text to print at the front of each line.</param>
		/// <param name="fd">The raw file descriptor that the dump is being sent to.</param>
		/// <param name="writer">
		/// The PrintWriter to which you should dump your state.  This will be
		/// closed for you after you return.
		/// </param>
		/// <param name="args">additional arguments to the dump request.</param>
		public virtual void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			writer.print(prefix);
			writer.print("mFragmentId=#");
			writer.print(Sharpen.Util.IntToHexString(mFragmentId));
			writer.print(" mContainerId#=");
			writer.print(Sharpen.Util.IntToHexString(mContainerId));
			writer.print(" mTag=");
			writer.println(mTag);
			writer.print(prefix);
			writer.print("mState=");
			writer.print(mState);
			writer.print(" mIndex=");
			writer.print(mIndex);
			writer.print(" mWho=");
			writer.print(mWho);
			writer.print(" mBackStackNesting=");
			writer.println(mBackStackNesting);
			writer.print(prefix);
			writer.print("mAdded=");
			writer.print(mAdded);
			writer.print(" mRemoving=");
			writer.print(mRemoving);
			writer.print(" mResumed=");
			writer.print(mResumed);
			writer.print(" mFromLayout=");
			writer.print(mFromLayout);
			writer.print(" mInLayout=");
			writer.println(mInLayout);
			writer.print(prefix);
			writer.print("mHidden=");
			writer.print(mHidden);
			writer.print(" mDetached=");
			writer.print(mDetached);
			writer.print(" mMenuVisible=");
			writer.print(mMenuVisible);
			writer.print(" mHasMenu=");
			writer.println(mHasMenu);
			writer.print(prefix);
			writer.print("mRetainInstance=");
			writer.print(mRetainInstance);
			writer.print(" mRetaining=");
			writer.println(mRetaining);
			if (mFragmentManager != null)
			{
				writer.print(prefix);
				writer.print("mFragmentManager=");
				writer.println(mFragmentManager);
			}
			if (mActivity != null)
			{
				writer.print(prefix);
				writer.print("mActivity=");
				writer.println(mActivity);
			}
			if (mArguments != null)
			{
				writer.print(prefix);
				writer.print("mArguments=");
				writer.println(mArguments);
			}
			if (mSavedFragmentState != null)
			{
				writer.print(prefix);
				writer.print("mSavedFragmentState=");
				writer.println(mSavedFragmentState);
			}
			if (mSavedViewState != null)
			{
				writer.print(prefix);
				writer.print("mSavedViewState=");
				writer.println(mSavedViewState);
			}
			if (mTarget != null)
			{
				writer.print(prefix);
				writer.print("mTarget=");
				writer.print(mTarget);
				writer.print(" mTargetRequestCode=");
				writer.println(mTargetRequestCode);
			}
			if (mNextAnim != 0)
			{
				writer.print(prefix);
				writer.print("mNextAnim=");
				writer.println(mNextAnim);
			}
			if (mContainer != null)
			{
				writer.print(prefix);
				writer.print("mContainer=");
				writer.println(mContainer);
			}
			if (mView != null)
			{
				writer.print(prefix);
				writer.print("mView=");
				writer.println(mView);
			}
			if (mAnimatingAway != null)
			{
				writer.print(prefix);
				writer.print("mAnimatingAway=");
				writer.println(mAnimatingAway);
				writer.print(prefix);
				writer.print("mStateAfterAnimating=");
				writer.println(mStateAfterAnimating);
			}
			if (mLoaderManager != null)
			{
				writer.print(prefix);
				writer.println("Loader Manager:");
				mLoaderManager.dump(prefix + "  ", fd, writer, args);
			}
		}

		internal virtual void performStart()
		{
			onStart();
			if (mLoaderManager != null)
			{
				mLoaderManager.doReportStart();
			}
		}

		internal virtual void performStop()
		{
			onStop();
			if (mLoadersStarted)
			{
				mLoadersStarted = false;
				if (!mCheckedForLoaderManager)
				{
					mCheckedForLoaderManager = true;
					mLoaderManager = mActivity.getLoaderManager(mIndex, mLoadersStarted, false);
				}
				if (mLoaderManager != null)
				{
					if (mActivity == null || !mActivity.mChangingConfigurations)
					{
						mLoaderManager.doStop();
					}
					else
					{
						mLoaderManager.doRetain();
					}
				}
			}
		}

		internal virtual void performDestroyView()
		{
			onDestroyView();
			if (mLoaderManager != null)
			{
				mLoaderManager.doReportNextStart();
			}
		}
	}
}
