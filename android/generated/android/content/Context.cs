using Sharpen;

namespace android.content
{
	/// <summary>Interface to global information about an application environment.</summary>
	/// <remarks>
	/// Interface to global information about an application environment.  This is
	/// an abstract class whose implementation is provided by
	/// the Android system.  It
	/// allows access to application-specific resources and classes, as well as
	/// up-calls for application-level operations such as launching activities,
	/// broadcasting and receiving intents, etc.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Context
	{
		/// <summary>
		/// File creation mode: the default mode, where the created file can only
		/// be accessed by the calling application (or all applications sharing the
		/// same user ID).
		/// </summary>
		/// <remarks>
		/// File creation mode: the default mode, where the created file can only
		/// be accessed by the calling application (or all applications sharing the
		/// same user ID).
		/// </remarks>
		/// <seealso cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</seealso>
		/// <seealso cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</seealso>
		public const int MODE_PRIVATE = unchecked((int)(0x0000));

		/// <summary>
		/// File creation mode: allow all other applications to have read access
		/// to the created file.
		/// </summary>
		/// <remarks>
		/// File creation mode: allow all other applications to have read access
		/// to the created file.
		/// </remarks>
		/// <seealso cref="MODE_PRIVATE">MODE_PRIVATE</seealso>
		/// <seealso cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</seealso>
		public const int MODE_WORLD_READABLE = unchecked((int)(0x0001));

		/// <summary>
		/// File creation mode: allow all other applications to have write access
		/// to the created file.
		/// </summary>
		/// <remarks>
		/// File creation mode: allow all other applications to have write access
		/// to the created file.
		/// </remarks>
		/// <seealso cref="MODE_PRIVATE">MODE_PRIVATE</seealso>
		/// <seealso cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</seealso>
		public const int MODE_WORLD_WRITEABLE = unchecked((int)(0x0002));

		/// <summary>
		/// File creation mode: for use with
		/// <see cref="openFileOutput(string, int)">openFileOutput(string, int)</see>
		/// , if the file
		/// already exists then write data to the end of the existing file
		/// instead of erasing it.
		/// </summary>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		public const int MODE_APPEND = unchecked((int)(0x8000));

		/// <summary>
		/// SharedPreference loading flag: when set, the file on disk will
		/// be checked for modification even if the shared preferences
		/// instance is already loaded in this process.
		/// </summary>
		/// <remarks>
		/// SharedPreference loading flag: when set, the file on disk will
		/// be checked for modification even if the shared preferences
		/// instance is already loaded in this process.  This behavior is
		/// sometimes desired in cases where the application has multiple
		/// processes, all writing to the same SharedPreferences file.
		/// Generally there are better forms of communication between
		/// processes, though.
		/// <p>This was the legacy (but undocumented) behavior in and
		/// before Gingerbread (Android 2.3) and this flag is implied when
		/// targetting such releases.  For applications targetting SDK
		/// versions <em>greater than</em> Android 2.3, this flag must be
		/// explicitly set if desired.
		/// </remarks>
		/// <seealso cref="getSharedPreferences(string, int)">getSharedPreferences(string, int)
		/// 	</seealso>
		public const int MODE_MULTI_PROCESS = unchecked((int)(0x0004));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : automatically create the service as long
		/// as the binding exists.  Note that while this will create the service,
		/// its
		/// <see cref="android.app.Service.onStartCommand(Intent, int, int)">android.app.Service.onStartCommand(Intent, int, int)
		/// 	</see>
		/// method will still only be called due to an
		/// explicit call to
		/// <see cref="startService(Intent)">startService(Intent)</see>
		/// .  Even without that, though,
		/// this still provides you with access to the service object while the
		/// service is created.
		/// <p>Note that prior to
		/// <see cref="android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH">android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH
		/// 	</see>
		/// ,
		/// not supplying this flag would also impact how important the system
		/// consider's the target service's process to be.  When set, the only way
		/// for it to be raised was by binding from a service in which case it will
		/// only be important when that activity is in the foreground.  Now to
		/// achieve this behavior you must explicitly supply the new flag
		/// <see cref="BIND_ADJUST_WITH_ACTIVITY">BIND_ADJUST_WITH_ACTIVITY</see>
		/// .  For compatibility, old applications
		/// that don't specify
		/// <see cref="BIND_AUTO_CREATE">BIND_AUTO_CREATE</see>
		/// will automatically have
		/// the flags
		/// <see cref="BIND_WAIVE_PRIORITY">BIND_WAIVE_PRIORITY</see>
		/// and
		/// <see cref="BIND_ADJUST_WITH_ACTIVITY">BIND_ADJUST_WITH_ACTIVITY</see>
		/// set for them in order to achieve
		/// the same result.
		/// </summary>
		public const int BIND_AUTO_CREATE = unchecked((int)(0x0001));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : include debugging help for mismatched
		/// calls to unbind.  When this flag is set, the callstack of the following
		/// <see cref="unbindService(ServiceConnection)">unbindService(ServiceConnection)</see>
		/// call is retained, to be printed if a later
		/// incorrect unbind call is made.  Note that doing this requires retaining
		/// information about the binding that was made for the lifetime of the app,
		/// resulting in a leak -- this should only be used for debugging.
		/// </summary>
		public const int BIND_DEBUG_UNBIND = unchecked((int)(0x0002));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : don't allow this binding to raise
		/// the target service's process to the foreground scheduling priority.
		/// It will still be raised to at least the same memory priority
		/// as the client (so that its process will not be killable in any
		/// situation where the client is not killable), but for CPU scheduling
		/// purposes it may be left in the background.  This only has an impact
		/// in the situation where the binding client is a foreground process
		/// and the target service is in a background process.
		/// </summary>
		public const int BIND_NOT_FOREGROUND = unchecked((int)(0x0004));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : indicates that the client application
		/// binding to this service considers the service to be more important than
		/// the app itself.  When set, the platform will try to have the out of
		/// memory kill the app before it kills the service it is bound to, though
		/// this is not guaranteed to be the case.
		/// </summary>
		public const int BIND_ABOVE_CLIENT = unchecked((int)(0x0008));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : allow the process hosting the bound
		/// service to go through its normal memory management.  It will be
		/// treated more like a running service, allowing the system to
		/// (temporarily) expunge the process if low on memory or for some other
		/// whim it may have, and being more aggressive about making it a candidate
		/// to be killed (and restarted) if running for a long time.
		/// </summary>
		public const int BIND_ALLOW_OOM_MANAGEMENT = unchecked((int)(0x0010));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : don't impact the scheduling or
		/// memory management priority of the target service's hosting process.
		/// Allows the service's process to be managed on the background LRU list
		/// just like a regular application process in the background.
		/// </summary>
		public const int BIND_WAIVE_PRIORITY = unchecked((int)(0x0020));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : this service is very important to
		/// the client, so should be brought to the foreground process level
		/// when the client is.  Normally a process can only be raised to the
		/// visibility level by a client, even if that client is in the foreground.
		/// </summary>
		public const int BIND_IMPORTANT = unchecked((int)(0x0040));

		/// <summary>
		/// Flag for
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : If binding from an activity, allow the
		/// target service's process importance to be raised based on whether the
		/// activity is visible to the user, regardless whether another flag is
		/// used to reduce the amount that the client process's overall importance
		/// is used to impact it.
		/// </summary>
		public const int BIND_ADJUST_WITH_ACTIVITY = unchecked((int)(0x0040));

		/// <summary>Return an AssetManager instance for your application's package.</summary>
		/// <remarks>Return an AssetManager instance for your application's package.</remarks>
		public abstract android.content.res.AssetManager getAssets();

		/// <summary>Return a Resources instance for your application's package.</summary>
		/// <remarks>Return a Resources instance for your application's package.</remarks>
		public abstract android.content.res.Resources getResources();

		/// <summary>Return PackageManager instance to find global package information.</summary>
		/// <remarks>Return PackageManager instance to find global package information.</remarks>
		public abstract android.content.pm.PackageManager getPackageManager();

		/// <summary>Return a ContentResolver instance for your application's package.</summary>
		/// <remarks>Return a ContentResolver instance for your application's package.</remarks>
		public abstract android.content.ContentResolver getContentResolver();

		/// <summary>Return the Looper for the main thread of the current process.</summary>
		/// <remarks>
		/// Return the Looper for the main thread of the current process.  This is
		/// the thread used to dispatch calls to application components (activities,
		/// services, etc).
		/// </remarks>
		public abstract android.os.Looper getMainLooper();

		/// <summary>
		/// Return the context of the single, global Application object of the
		/// current process.
		/// </summary>
		/// <remarks>
		/// Return the context of the single, global Application object of the
		/// current process.  This generally should only be used if you need a
		/// Context whose lifecycle is separate from the current context, that is
		/// tied to the lifetime of the process rather than the current component.
		/// <p>Consider for example how this interacts with
		/// <see cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</see>
		/// :
		/// <ul>
		/// <li> <p>If used from an Activity context, the receiver is being registered
		/// within that activity.  This means that you are expected to unregister
		/// before the activity is done being destroyed; in fact if you do not do
		/// so, the framework will clean up your leaked registration as it removes
		/// the activity and log an error.  Thus, if you use the Activity context
		/// to register a receiver that is static (global to the process, not
		/// associated with an Activity instance) then that registration will be
		/// removed on you at whatever point the activity you used is destroyed.
		/// <li> <p>If used from the Context returned here, the receiver is being
		/// registered with the global state associated with your application.  Thus
		/// it will never be unregistered for you.  This is necessary if the receiver
		/// is associated with static data, not a particular component.  However
		/// using the ApplicationContext elsewhere can easily lead to serious leaks
		/// if you forget to unregister, unbind, etc.
		/// </ul>
		/// </remarks>
		public abstract android.content.Context getApplicationContext();

		/// <summary>
		/// Add a new
		/// <see cref="ComponentCallbacks">ComponentCallbacks</see>
		/// to the base application of the
		/// Context, which will be called at the same times as the ComponentCallbacks
		/// methods of activities and other components are called.  Note that you
		/// <em>must</em> be sure to use
		/// <see cref="unregisterComponentCallbacks(ComponentCallbacks)">unregisterComponentCallbacks(ComponentCallbacks)
		/// 	</see>
		/// when
		/// appropriate in the future; this will not be removed for you.
		/// </summary>
		/// <param name="callback">
		/// The interface to call.  This can be either a
		/// <see cref="ComponentCallbacks">ComponentCallbacks</see>
		/// or
		/// <see cref="ComponentCallbacks2">ComponentCallbacks2</see>
		/// interface.
		/// </param>
		public virtual void registerComponentCallbacks(android.content.ComponentCallbacks
			 callback)
		{
			getApplicationContext().registerComponentCallbacks(callback);
		}

		/// <summary>
		/// Remove a
		/// <see cref="ComponentCallbacks">ComponentCallbacks</see>
		/// objec that was previously registered
		/// with
		/// <see cref="registerComponentCallbacks(ComponentCallbacks)">registerComponentCallbacks(ComponentCallbacks)
		/// 	</see>
		/// .
		/// </summary>
		public virtual void unregisterComponentCallbacks(android.content.ComponentCallbacks
			 callback)
		{
			getApplicationContext().unregisterComponentCallbacks(callback);
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

		/// <summary>Set the base theme for this context.</summary>
		/// <remarks>
		/// Set the base theme for this context.  Note that this should be called
		/// before any views are instantiated in the Context (for example before
		/// calling
		/// <see cref="android.app.Activity.setContentView(int)">android.app.Activity.setContentView(int)
		/// 	</see>
		/// or
		/// <see cref="android.view.LayoutInflater.inflate(int, android.view.ViewGroup)">android.view.LayoutInflater.inflate(int, android.view.ViewGroup)
		/// 	</see>
		/// ).
		/// </remarks>
		/// <param name="resid">The style resource describing the theme.</param>
		public abstract void setTheme(int resid);

		/// <hide>
		/// Needed for some internal implementation...  not public because
		/// you can't assume this actually means anything.
		/// </hide>
		public virtual int getThemeResId()
		{
			return 0;
		}

		/// <summary>Return the Theme object associated with this Context.</summary>
		/// <remarks>Return the Theme object associated with this Context.</remarks>
		public abstract android.content.res.Resources.Theme getTheme();

		/// <summary>Retrieve styled attribute information in this Context's theme.</summary>
		/// <remarks>
		/// Retrieve styled attribute information in this Context's theme.  See
		/// <see cref="android.content.res.Resources.Theme.obtainStyledAttributes(int[])">android.content.res.Resources.Theme.obtainStyledAttributes(int[])
		/// 	</see>
		/// for more information.
		/// </remarks>
		/// <seealso cref="android.content.res.Resources.Theme.obtainStyledAttributes(int[])"
		/// 	>android.content.res.Resources.Theme.obtainStyledAttributes(int[])</seealso>
		public android.content.res.TypedArray obtainStyledAttributes(int[] attrs)
		{
			return getTheme().obtainStyledAttributes(attrs);
		}

		/// <summary>Retrieve styled attribute information in this Context's theme.</summary>
		/// <remarks>
		/// Retrieve styled attribute information in this Context's theme.  See
		/// <see cref="android.content.res.Resources.Theme.obtainStyledAttributes(int, int[])
		/// 	">android.content.res.Resources.Theme.obtainStyledAttributes(int, int[])</see>
		/// for more information.
		/// </remarks>
		/// <seealso cref="android.content.res.Resources.Theme.obtainStyledAttributes(int, int[])
		/// 	">android.content.res.Resources.Theme.obtainStyledAttributes(int, int[])</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public android.content.res.TypedArray obtainStyledAttributes(int resid, int[] attrs
			)
		{
			return getTheme().obtainStyledAttributes(resid, attrs);
		}

		/// <summary>Retrieve styled attribute information in this Context's theme.</summary>
		/// <remarks>
		/// Retrieve styled attribute information in this Context's theme.  See
		/// <see cref="android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	">android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	</see>
		/// for more information.
		/// </remarks>
		/// <seealso cref="android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	">android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	</seealso>
		public android.content.res.TypedArray obtainStyledAttributes(android.util.AttributeSet
			 set, int[] attrs)
		{
			return getTheme().obtainStyledAttributes(set, attrs, 0, 0);
		}

		/// <summary>Retrieve styled attribute information in this Context's theme.</summary>
		/// <remarks>
		/// Retrieve styled attribute information in this Context's theme.  See
		/// <see cref="android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	">android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	</see>
		/// for more information.
		/// </remarks>
		/// <seealso cref="android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	">android.content.res.Resources.Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	</seealso>
		public android.content.res.TypedArray obtainStyledAttributes(android.util.AttributeSet
			 set, int[] attrs, int defStyleAttr, int defStyleRes)
		{
			return getTheme().obtainStyledAttributes(set, attrs, defStyleAttr, defStyleRes);
		}

		/// <summary>Return a class loader you can use to retrieve classes in this package.</summary>
		/// <remarks>Return a class loader you can use to retrieve classes in this package.</remarks>
		public abstract java.lang.ClassLoader getClassLoader();

		/// <summary>Return the name of this application's package.</summary>
		/// <remarks>Return the name of this application's package.</remarks>
		public abstract string getPackageName();

		/// <summary>Return the full application info for this context's package.</summary>
		/// <remarks>Return the full application info for this context's package.</remarks>
		public abstract android.content.pm.ApplicationInfo getApplicationInfo();

		/// <summary>Return the full path to this context's primary Android package.</summary>
		/// <remarks>
		/// Return the full path to this context's primary Android package.
		/// The Android package is a ZIP file which contains the application's
		/// primary resources.
		/// <p>Note: this is not generally useful for applications, since they should
		/// not be directly accessing the file system.
		/// </remarks>
		/// <returns>String Path to the resources.</returns>
		public abstract string getPackageResourcePath();

		/// <summary>Return the full path to this context's primary Android package.</summary>
		/// <remarks>
		/// Return the full path to this context's primary Android package.
		/// The Android package is a ZIP file which contains application's
		/// primary code and assets.
		/// <p>Note: this is not generally useful for applications, since they should
		/// not be directly accessing the file system.
		/// </remarks>
		/// <returns>String Path to the code and assets.</returns>
		public abstract string getPackageCodePath();

		/// <summary>
		/// <hide></hide>
		/// Return the full path to the shared prefs file for the given prefs group name.
		/// <p>Note: this is not generally useful for applications, since they should
		/// not be directly accessing the file system.
		/// </summary>
		public abstract java.io.File getSharedPrefsFile(string name);

		/// <summary>
		/// Retrieve and hold the contents of the preferences file 'name', returning
		/// a SharedPreferences through which you can retrieve and modify its
		/// values.
		/// </summary>
		/// <remarks>
		/// Retrieve and hold the contents of the preferences file 'name', returning
		/// a SharedPreferences through which you can retrieve and modify its
		/// values.  Only one instance of the SharedPreferences object is returned
		/// to any callers for the same name, meaning they will see each other's
		/// edits as soon as they are made.
		/// </remarks>
		/// <param name="name">
		/// Desired preferences file. If a preferences file by this name
		/// does not exist, it will be created when you retrieve an
		/// editor (SharedPreferences.edit()) and then commit changes (Editor.commit()).
		/// </param>
		/// <param name="mode">
		/// Operating mode.  Use 0 or
		/// <see cref="MODE_PRIVATE">MODE_PRIVATE</see>
		/// for the
		/// default operation,
		/// <see cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</see>
		/// and
		/// <see cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</see>
		/// to control permissions.  The bit
		/// <see cref="MODE_MULTI_PROCESS">MODE_MULTI_PROCESS</see>
		/// can also be used if multiple processes
		/// are mutating the same SharedPreferences file.
		/// <see cref="MODE_MULTI_PROCESS">MODE_MULTI_PROCESS</see>
		/// is always on in apps targetting Gingerbread (Android 2.3) and below, and
		/// off by default in later versions.
		/// </param>
		/// <returns>
		/// Returns the single SharedPreferences instance that can be used
		/// to retrieve and modify the preference values.
		/// </returns>
		/// <seealso cref="MODE_PRIVATE">MODE_PRIVATE</seealso>
		/// <seealso cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</seealso>
		/// <seealso cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</seealso>
		/// <seealso cref="MODE_MULTI_PROCESS">MODE_MULTI_PROCESS</seealso>
		public abstract android.content.SharedPreferences getSharedPreferences(string name
			, int mode);

		/// <summary>
		/// Open a private file associated with this Context's application package
		/// for reading.
		/// </summary>
		/// <remarks>
		/// Open a private file associated with this Context's application package
		/// for reading.
		/// </remarks>
		/// <param name="name">
		/// The name of the file to open; can not contain path
		/// separators.
		/// </param>
		/// <returns>FileInputStream Resulting input stream.</returns>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		/// <seealso cref="fileList()">fileList()</seealso>
		/// <seealso cref="deleteFile(string)">deleteFile(string)</seealso>
		/// <seealso cref="java.io.FileInputStream.FileInputStream(string)">java.io.FileInputStream.FileInputStream(string)
		/// 	</seealso>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public abstract java.io.FileInputStream openFileInput(string name);

		/// <summary>
		/// Open a private file associated with this Context's application package
		/// for writing.
		/// </summary>
		/// <remarks>
		/// Open a private file associated with this Context's application package
		/// for writing.  Creates the file if it doesn't already exist.
		/// </remarks>
		/// <param name="name">
		/// The name of the file to open; can not contain path
		/// separators.
		/// </param>
		/// <param name="mode">
		/// Operating mode.  Use 0 or
		/// <see cref="MODE_PRIVATE">MODE_PRIVATE</see>
		/// for the
		/// default operation,
		/// <see cref="MODE_APPEND">MODE_APPEND</see>
		/// to append to an existing file,
		/// <see cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</see>
		/// and
		/// <see cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</see>
		/// to control
		/// permissions.
		/// </param>
		/// <returns>FileOutputStream Resulting output stream.</returns>
		/// <seealso cref="MODE_APPEND">MODE_APPEND</seealso>
		/// <seealso cref="MODE_PRIVATE">MODE_PRIVATE</seealso>
		/// <seealso cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</seealso>
		/// <seealso cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</seealso>
		/// <seealso cref="openFileInput(string)">openFileInput(string)</seealso>
		/// <seealso cref="fileList()">fileList()</seealso>
		/// <seealso cref="deleteFile(string)">deleteFile(string)</seealso>
		/// <seealso cref="java.io.FileOutputStream.FileOutputStream(string)">java.io.FileOutputStream.FileOutputStream(string)
		/// 	</seealso>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public abstract java.io.FileOutputStream openFileOutput(string name, int mode);

		/// <summary>
		/// Delete the given private file associated with this Context's
		/// application package.
		/// </summary>
		/// <remarks>
		/// Delete the given private file associated with this Context's
		/// application package.
		/// </remarks>
		/// <param name="name">
		/// The name of the file to delete; can not contain path
		/// separators.
		/// </param>
		/// <returns>
		/// True if the file was successfully deleted; else
		/// false.
		/// </returns>
		/// <seealso cref="openFileInput(string)">openFileInput(string)</seealso>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		/// <seealso cref="fileList()">fileList()</seealso>
		/// <seealso cref="java.io.File.delete()">java.io.File.delete()</seealso>
		public abstract bool deleteFile(string name);

		/// <summary>
		/// Returns the absolute path on the filesystem where a file created with
		/// <see cref="openFileOutput(string, int)">openFileOutput(string, int)</see>
		/// is stored.
		/// </summary>
		/// <param name="name">
		/// The name of the file for which you would like to get
		/// its path.
		/// </param>
		/// <returns>Returns an absolute path to the given file.</returns>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		/// <seealso cref="getFilesDir()">getFilesDir()</seealso>
		/// <seealso cref="getDir(string, int)">getDir(string, int)</seealso>
		public abstract java.io.File getFileStreamPath(string name);

		/// <summary>
		/// Returns the absolute path to the directory on the filesystem where
		/// files created with
		/// <see cref="openFileOutput(string, int)">openFileOutput(string, int)</see>
		/// are stored.
		/// </summary>
		/// <returns>Returns the path of the directory holding application files.</returns>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		/// <seealso cref="getFileStreamPath(string)">getFileStreamPath(string)</seealso>
		/// <seealso cref="getDir(string, int)">getDir(string, int)</seealso>
		public abstract java.io.File getFilesDir();

		/// <summary>
		/// Returns the absolute path to the directory on the external filesystem
		/// (that is somewhere on
		/// <see cref="android.os.Environment.getExternalStorageDirectory()">Environment.getExternalStorageDirectory()
		/// 	</see>
		/// ) where the application can
		/// place persistent files it owns.  These files are private to the
		/// applications, and not typically visible to the user as media.
		/// <p>This is like
		/// <see cref="getFilesDir()">getFilesDir()</see>
		/// in that these
		/// files will be deleted when the application is uninstalled, however there
		/// are some important differences:
		/// <ul>
		/// <li>External files are not always available: they will disappear if the
		/// user mounts the external storage on a computer or removes it.  See the
		/// APIs on
		/// <see cref="android.os.Environment">android.os.Environment</see>
		/// for information in the storage state.
		/// <li>There is no security enforced with these files.  All applications
		/// can read and write files placed here.
		/// </ul>
		/// <p>Here is an example of typical code to manipulate a file in
		/// an application's private storage:</p>
		/// <sample>
		/// development/samples/ApiDemos/src/com/example/android/apis/content/ExternalStorage.java
		/// private_file
		/// </sample>
		/// <p>If you supply a non-null <var>type</var> to this function, the returned
		/// file will be a path to a sub-directory of the given type.  Though these files
		/// are not automatically scanned by the media scanner, you can explicitly
		/// add them to the media database with
		/// <see cref="android.media.MediaScannerConnection.scanFile(Context, string[], string[], android.media.MediaScannerConnection.OnScanCompletedListener)
		/// 	">MediaScannerConnection.scanFile</see>
		/// .
		/// Note that this is not the same as
		/// <see cref="android.os.Environment.getExternalStoragePublicDirectory(string)">Environment.getExternalStoragePublicDirectory()
		/// 	</see>
		/// , which provides
		/// directories of media shared by all applications.  The
		/// directories returned here are
		/// owned by the application, and their contents will be removed when the
		/// application is uninstalled.  Unlike
		/// <see cref="android.os.Environment.getExternalStoragePublicDirectory(string)">Environment.getExternalStoragePublicDirectory()
		/// 	</see>
		/// , the directory
		/// returned here will be automatically created for you.
		/// <p>Here is an example of typical code to manipulate a picture in
		/// an application's private storage and add it to the media database:</p>
		/// <sample>
		/// development/samples/ApiDemos/src/com/example/android/apis/content/ExternalStorage.java
		/// private_picture
		/// </sample>
		/// </summary>
		/// <param name="type">
		/// The type of files directory to return.  May be null for
		/// the root of the files directory or one of
		/// the following Environment constants for a subdirectory:
		/// <see cref="android.os.Environment.DIRECTORY_MUSIC">android.os.Environment.DIRECTORY_MUSIC
		/// 	</see>
		/// ,
		/// <see cref="android.os.Environment.DIRECTORY_PODCASTS">android.os.Environment.DIRECTORY_PODCASTS
		/// 	</see>
		/// ,
		/// <see cref="android.os.Environment.DIRECTORY_RINGTONES">android.os.Environment.DIRECTORY_RINGTONES
		/// 	</see>
		/// ,
		/// <see cref="android.os.Environment.DIRECTORY_ALARMS">android.os.Environment.DIRECTORY_ALARMS
		/// 	</see>
		/// ,
		/// <see cref="android.os.Environment.DIRECTORY_NOTIFICATIONS">android.os.Environment.DIRECTORY_NOTIFICATIONS
		/// 	</see>
		/// ,
		/// <see cref="android.os.Environment.DIRECTORY_PICTURES">android.os.Environment.DIRECTORY_PICTURES
		/// 	</see>
		/// , or
		/// <see cref="android.os.Environment.DIRECTORY_MOVIES">android.os.Environment.DIRECTORY_MOVIES
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns the path of the directory holding application files
		/// on external storage.  Returns null if external storage is not currently
		/// mounted so it could not ensure the path exists; you will need to call
		/// this method again when it is available.
		/// </returns>
		/// <seealso cref="getFilesDir()">getFilesDir()</seealso>
		/// <seealso cref="android.os.Environment.getExternalStoragePublicDirectory(string)">android.os.Environment.getExternalStoragePublicDirectory(string)
		/// 	</seealso>
		public abstract java.io.File getExternalFilesDir(string type);

		/// <summary>
		/// Return the directory where this application's OBB files (if there
		/// are any) can be found.
		/// </summary>
		/// <remarks>
		/// Return the directory where this application's OBB files (if there
		/// are any) can be found.  Note if the application does not have any OBB
		/// files, this directory may not exist.
		/// </remarks>
		public abstract java.io.File getObbDir();

		/// <summary>
		/// Returns the absolute path to the application specific cache directory
		/// on the filesystem.
		/// </summary>
		/// <remarks>
		/// Returns the absolute path to the application specific cache directory
		/// on the filesystem. These files will be ones that get deleted first when the
		/// device runs low on storage.
		/// There is no guarantee when these files will be deleted.
		/// <strong>Note: you should not <em>rely</em> on the system deleting these
		/// files for you; you should always have a reasonable maximum, such as 1 MB,
		/// for the amount of space you consume with cache files, and prune those
		/// files when exceeding that space.</strong>
		/// </remarks>
		/// <returns>Returns the path of the directory holding application cache files.</returns>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		/// <seealso cref="getFileStreamPath(string)">getFileStreamPath(string)</seealso>
		/// <seealso cref="getDir(string, int)">getDir(string, int)</seealso>
		public abstract java.io.File getCacheDir();

		/// <summary>
		/// Returns the absolute path to the directory on the external filesystem
		/// (that is somewhere on
		/// <see cref="android.os.Environment.getExternalStorageDirectory()">Environment.getExternalStorageDirectory()
		/// 	</see>
		/// where the application can
		/// place cache files it owns.
		/// <p>This is like
		/// <see cref="getCacheDir()">getCacheDir()</see>
		/// in that these
		/// files will be deleted when the application is uninstalled, however there
		/// are some important differences:
		/// <ul>
		/// <li>The platform does not monitor the space available in external storage,
		/// and thus will not automatically delete these files.  Note that you should
		/// be managing the maximum space you will use for these anyway, just like
		/// with
		/// <see cref="getCacheDir()">getCacheDir()</see>
		/// .
		/// <li>External files are not always available: they will disappear if the
		/// user mounts the external storage on a computer or removes it.  See the
		/// APIs on
		/// <see cref="android.os.Environment">android.os.Environment</see>
		/// for information in the storage state.
		/// <li>There is no security enforced with these files.  All applications
		/// can read and write files placed here.
		/// </ul>
		/// </summary>
		/// <returns>
		/// Returns the path of the directory holding application cache files
		/// on external storage.  Returns null if external storage is not currently
		/// mounted so it could not ensure the path exists; you will need to call
		/// this method again when it is available.
		/// </returns>
		/// <seealso cref="getCacheDir()">getCacheDir()</seealso>
		public abstract java.io.File getExternalCacheDir();

		/// <summary>
		/// Returns an array of strings naming the private files associated with
		/// this Context's application package.
		/// </summary>
		/// <remarks>
		/// Returns an array of strings naming the private files associated with
		/// this Context's application package.
		/// </remarks>
		/// <returns>Array of strings naming the private files.</returns>
		/// <seealso cref="openFileInput(string)">openFileInput(string)</seealso>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		/// <seealso cref="deleteFile(string)">deleteFile(string)</seealso>
		public abstract string[] fileList();

		/// <summary>
		/// Retrieve, creating if needed, a new directory in which the application
		/// can place its own custom data files.
		/// </summary>
		/// <remarks>
		/// Retrieve, creating if needed, a new directory in which the application
		/// can place its own custom data files.  You can use the returned File
		/// object to create and access files in this directory.  Note that files
		/// created through a File object will only be accessible by your own
		/// application; you can only set the mode of the entire directory, not
		/// of individual files.
		/// </remarks>
		/// <param name="name">
		/// Name of the directory to retrieve.  This is a directory
		/// that is created as part of your application data.
		/// </param>
		/// <param name="mode">
		/// Operating mode.  Use 0 or
		/// <see cref="MODE_PRIVATE">MODE_PRIVATE</see>
		/// for the
		/// default operation,
		/// <see cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</see>
		/// and
		/// <see cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</see>
		/// to control permissions.
		/// </param>
		/// <returns>
		/// Returns a File object for the requested directory.  The directory
		/// will have been created if it does not already exist.
		/// </returns>
		/// <seealso cref="openFileOutput(string, int)">openFileOutput(string, int)</seealso>
		public abstract java.io.File getDir(string name, int mode);

		/// <summary>
		/// Open a new private SQLiteDatabase associated with this Context's
		/// application package.
		/// </summary>
		/// <remarks>
		/// Open a new private SQLiteDatabase associated with this Context's
		/// application package.  Create the database file if it doesn't exist.
		/// </remarks>
		/// <param name="name">The name (unique in the application package) of the database.</param>
		/// <param name="mode">
		/// Operating mode.  Use 0 or
		/// <see cref="MODE_PRIVATE">MODE_PRIVATE</see>
		/// for the
		/// default operation,
		/// <see cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</see>
		/// and
		/// <see cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</see>
		/// to control permissions.
		/// </param>
		/// <param name="factory">
		/// An optional factory class that is called to instantiate a
		/// cursor when query is called.
		/// </param>
		/// <returns>The contents of a newly created database with the given name.</returns>
		/// <exception cref="android.database.sqlite.SQLiteException">if the database file could not be opened.
		/// 	</exception>
		/// <seealso cref="MODE_PRIVATE">MODE_PRIVATE</seealso>
		/// <seealso cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</seealso>
		/// <seealso cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</seealso>
		/// <seealso cref="deleteDatabase(string)">deleteDatabase(string)</seealso>
		public abstract android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string
			 name, int mode, android.database.sqlite.SQLiteDatabase.CursorFactory factory);

		/// <summary>
		/// Open a new private SQLiteDatabase associated with this Context's
		/// application package.
		/// </summary>
		/// <remarks>
		/// Open a new private SQLiteDatabase associated with this Context's
		/// application package.  Creates the database file if it doesn't exist.
		/// <p>Accepts input param: a concrete instance of
		/// <see cref="android.database.DatabaseErrorHandler">android.database.DatabaseErrorHandler
		/// 	</see>
		/// to be
		/// used to handle corruption when sqlite reports database corruption.</p>
		/// </remarks>
		/// <param name="name">The name (unique in the application package) of the database.</param>
		/// <param name="mode">
		/// Operating mode.  Use 0 or
		/// <see cref="MODE_PRIVATE">MODE_PRIVATE</see>
		/// for the
		/// default operation,
		/// <see cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</see>
		/// and
		/// <see cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</see>
		/// to control permissions.
		/// </param>
		/// <param name="factory">
		/// An optional factory class that is called to instantiate a
		/// cursor when query is called.
		/// </param>
		/// <param name="errorHandler">
		/// the
		/// <see cref="android.database.DatabaseErrorHandler">android.database.DatabaseErrorHandler
		/// 	</see>
		/// to be used when sqlite reports database
		/// corruption. if null,
		/// <see cref="android.database.DefaultDatabaseErrorHandler">android.database.DefaultDatabaseErrorHandler
		/// 	</see>
		/// is assumed.
		/// </param>
		/// <returns>The contents of a newly created database with the given name.</returns>
		/// <exception cref="android.database.sqlite.SQLiteException">if the database file could not be opened.
		/// 	</exception>
		/// <seealso cref="MODE_PRIVATE">MODE_PRIVATE</seealso>
		/// <seealso cref="MODE_WORLD_READABLE">MODE_WORLD_READABLE</seealso>
		/// <seealso cref="MODE_WORLD_WRITEABLE">MODE_WORLD_WRITEABLE</seealso>
		/// <seealso cref="deleteDatabase(string)">deleteDatabase(string)</seealso>
		public abstract android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string
			 name, int mode, android.database.sqlite.SQLiteDatabase.CursorFactory factory, android.database.DatabaseErrorHandler
			 errorHandler);

		/// <summary>
		/// Delete an existing private SQLiteDatabase associated with this Context's
		/// application package.
		/// </summary>
		/// <remarks>
		/// Delete an existing private SQLiteDatabase associated with this Context's
		/// application package.
		/// </remarks>
		/// <param name="name">
		/// The name (unique in the application package) of the
		/// database.
		/// </param>
		/// <returns>True if the database was successfully deleted; else false.</returns>
		/// <seealso cref="openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	">openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	</seealso>
		public abstract bool deleteDatabase(string name);

		/// <summary>
		/// Returns the absolute path on the filesystem where a database created with
		/// <see cref="openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	">openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	</see>
		/// is stored.
		/// </summary>
		/// <param name="name">
		/// The name of the database for which you would like to get
		/// its path.
		/// </param>
		/// <returns>Returns an absolute path to the given database.</returns>
		/// <seealso cref="openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	">openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	</seealso>
		public abstract java.io.File getDatabasePath(string name);

		/// <summary>
		/// Returns an array of strings naming the private databases associated with
		/// this Context's application package.
		/// </summary>
		/// <remarks>
		/// Returns an array of strings naming the private databases associated with
		/// this Context's application package.
		/// </remarks>
		/// <returns>Array of strings naming the private databases.</returns>
		/// <seealso cref="openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	">openOrCreateDatabase(string, int, android.database.sqlite.SQLiteDatabase.CursorFactory)
		/// 	</seealso>
		/// <seealso cref="deleteDatabase(string)">deleteDatabase(string)</seealso>
		public abstract string[] databaseList();

		[System.ObsoleteAttribute(@"Use android.app.WallpaperManager.getDrawable() WallpaperManager.get() instead."
			)]
		public abstract android.graphics.drawable.Drawable getWallpaper();

		[System.ObsoleteAttribute(@"Use android.app.WallpaperManager.peekDrawable() WallpaperManager.peek() instead."
			)]
		public abstract android.graphics.drawable.Drawable peekWallpaper();

		[System.ObsoleteAttribute(@"Use android.app.WallpaperManager.getDesiredMinimumWidth() WallpaperManager.getDesiredMinimumWidth() instead."
			)]
		public abstract int getWallpaperDesiredMinimumWidth();

		[System.ObsoleteAttribute(@"Use android.app.WallpaperManager.getDesiredMinimumHeight() WallpaperManager.getDesiredMinimumHeight() instead."
			)]
		public abstract int getWallpaperDesiredMinimumHeight();

		/// <exception cref="System.IO.IOException"></exception>
		[System.ObsoleteAttribute(@"Use android.app.WallpaperManager.setBitmap(android.graphics.Bitmap) WallpaperManager.set() instead."
			)]
		public abstract void setWallpaper(android.graphics.Bitmap bitmap);

		/// <exception cref="System.IO.IOException"></exception>
		[System.ObsoleteAttribute(@"Use android.app.WallpaperManager.setStream(java.io.InputStream) WallpaperManager.set() instead."
			)]
		public abstract void setWallpaper(java.io.InputStream data);

		/// <exception cref="System.IO.IOException"></exception>
		[System.ObsoleteAttribute(@"Use android.app.WallpaperManager.clear() WallpaperManager.clear() instead."
			)]
		public abstract void clearWallpaper();

		/// <summary>Launch a new activity.</summary>
		/// <remarks>
		/// Launch a new activity.  You will not receive any information about when
		/// the activity exits.
		/// <p>Note that if this method is being called from outside of an
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// Context, then the Intent must include
		/// the
		/// <see cref="Intent.FLAG_ACTIVITY_NEW_TASK">Intent.FLAG_ACTIVITY_NEW_TASK</see>
		/// launch flag.  This is because,
		/// without being started from an existing Activity, there is no existing
		/// task in which to place the new activity and thus it needs to be placed
		/// in its own separate task.
		/// <p>This method throws
		/// <see cref="ActivityNotFoundException">ActivityNotFoundException</see>
		/// if there was no Activity found to run the given Intent.
		/// </remarks>
		/// <param name="intent">The description of the activity to start.</param>
		/// <exception cref="ActivityNotFoundException">ActivityNotFoundException</exception>
		/// <seealso cref="android.content.pm.PackageManager.resolveActivity(Intent, int)">android.content.pm.PackageManager.resolveActivity(Intent, int)
		/// 	</seealso>
		public abstract void startActivity(android.content.Intent intent);

		/// <summary>Launch multiple new activities.</summary>
		/// <remarks>
		/// Launch multiple new activities.  This is generally the same as calling
		/// <see cref="startActivity(Intent)">startActivity(Intent)</see>
		/// for the first Intent in the array,
		/// that activity during its creation calling
		/// <see cref="startActivity(Intent)">startActivity(Intent)</see>
		/// for the second entry, etc.  Note that unlike that approach, generally
		/// none of the activities except the last in the array will be created
		/// at this point, but rather will be created when the user first visits
		/// them (due to pressing back from the activity on top).
		/// <p>This method throws
		/// <see cref="ActivityNotFoundException">ActivityNotFoundException</see>
		/// if there was no Activity found for <em>any</em> given Intent.  In this
		/// case the state of the activity stack is undefined (some Intents in the
		/// list may be on it, some not), so you probably want to avoid such situations.
		/// </remarks>
		/// <param name="intents">An array of Intents to be started.</param>
		/// <exception cref="ActivityNotFoundException">ActivityNotFoundException</exception>
		/// <seealso cref="android.content.pm.PackageManager.resolveActivity(Intent, int)">android.content.pm.PackageManager.resolveActivity(Intent, int)
		/// 	</seealso>
		public abstract void startActivities(android.content.Intent[] intents);

		/// <summary>
		/// Like
		/// <see cref="startActivity(Intent)">startActivity(Intent)</see>
		/// , but taking a IntentSender
		/// to start.  If the IntentSender is for an activity, that activity will be started
		/// as if you had called the regular
		/// <see cref="startActivity(Intent)">startActivity(Intent)</see>
		/// here; otherwise, its associated action will be executed (such as
		/// sending a broadcast) as if you had called
		/// <see cref="IntentSender.sendIntent(Context, int, Intent, OnFinished, android.os.Handler)
		/// 	">IntentSender.sendIntent</see>
		/// on it.
		/// </summary>
		/// <param name="intent">The IntentSender to launch.</param>
		/// <param name="fillInIntent">
		/// If non-null, this will be provided as the
		/// intent parameter to
		/// <see cref="IntentSender.sendIntent(Context, int, Intent, OnFinished, android.os.Handler)
		/// 	">IntentSender.sendIntent(Context, int, Intent, OnFinished, android.os.Handler)</see>
		/// .
		/// </param>
		/// <param name="flagsMask">
		/// Intent flags in the original IntentSender that you
		/// would like to change.
		/// </param>
		/// <param name="flagsValues">
		/// Desired values for any bits set in
		/// <var>flagsMask</var>
		/// </param>
		/// <param name="extraFlags">Always set to 0.</param>
		/// <exception cref="android.content.IntentSender.SendIntentException"></exception>
		public abstract void startIntentSender(android.content.IntentSender intent, android.content.Intent
			 fillInIntent, int flagsMask, int flagsValues, int extraFlags);

		/// <summary>Broadcast the given intent to all interested BroadcastReceivers.</summary>
		/// <remarks>
		/// Broadcast the given intent to all interested BroadcastReceivers.  This
		/// call is asynchronous; it returns immediately, and you will continue
		/// executing while the receivers are run.  No results are propagated from
		/// receivers and receivers can not abort the broadcast. If you want
		/// to allow receivers to propagate results or abort the broadcast, you must
		/// send an ordered broadcast using
		/// <see cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</see>
		/// .
		/// <p>See
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// for more information on Intent broadcasts.
		/// </remarks>
		/// <param name="intent">
		/// The Intent to broadcast; all receivers matching this
		/// Intent will receive the broadcast.
		/// </param>
		/// <seealso cref="BroadcastReceiver">BroadcastReceiver</seealso>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</seealso>
		/// <seealso cref="sendBroadcast(Intent, string)">sendBroadcast(Intent, string)</seealso>
		/// <seealso cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</seealso>
		/// <seealso cref="sendOrderedBroadcast(Intent, string, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">sendOrderedBroadcast(Intent, string, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</seealso>
		public abstract void sendBroadcast(android.content.Intent intent);

		/// <summary>
		/// Broadcast the given intent to all interested BroadcastReceivers, allowing
		/// an optional required permission to be enforced.
		/// </summary>
		/// <remarks>
		/// Broadcast the given intent to all interested BroadcastReceivers, allowing
		/// an optional required permission to be enforced.  This
		/// call is asynchronous; it returns immediately, and you will continue
		/// executing while the receivers are run.  No results are propagated from
		/// receivers and receivers can not abort the broadcast. If you want
		/// to allow receivers to propagate results or abort the broadcast, you must
		/// send an ordered broadcast using
		/// <see cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</see>
		/// .
		/// <p>See
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// for more information on Intent broadcasts.
		/// </remarks>
		/// <param name="intent">
		/// The Intent to broadcast; all receivers matching this
		/// Intent will receive the broadcast.
		/// </param>
		/// <param name="receiverPermission">
		/// (optional) String naming a permission that
		/// a receiver must hold in order to receive your broadcast.
		/// If null, no permission is required.
		/// </param>
		/// <seealso cref="BroadcastReceiver">BroadcastReceiver</seealso>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</seealso>
		/// <seealso cref="sendBroadcast(Intent)">sendBroadcast(Intent)</seealso>
		/// <seealso cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</seealso>
		/// <seealso cref="sendOrderedBroadcast(Intent, string, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">sendOrderedBroadcast(Intent, string, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</seealso>
		public abstract void sendBroadcast(android.content.Intent intent, string receiverPermission
			);

		/// <summary>
		/// Broadcast the given intent to all interested BroadcastReceivers, delivering
		/// them one at a time to allow more preferred receivers to consume the
		/// broadcast before it is delivered to less preferred receivers.
		/// </summary>
		/// <remarks>
		/// Broadcast the given intent to all interested BroadcastReceivers, delivering
		/// them one at a time to allow more preferred receivers to consume the
		/// broadcast before it is delivered to less preferred receivers.  This
		/// call is asynchronous; it returns immediately, and you will continue
		/// executing while the receivers are run.
		/// <p>See
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// for more information on Intent broadcasts.
		/// </remarks>
		/// <param name="intent">
		/// The Intent to broadcast; all receivers matching this
		/// Intent will receive the broadcast.
		/// </param>
		/// <param name="receiverPermission">
		/// (optional) String naming a permissions that
		/// a receiver must hold in order to receive your broadcast.
		/// If null, no permission is required.
		/// </param>
		/// <seealso cref="BroadcastReceiver">BroadcastReceiver</seealso>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</seealso>
		/// <seealso cref="sendBroadcast(Intent)">sendBroadcast(Intent)</seealso>
		/// <seealso cref="sendOrderedBroadcast(Intent, string, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">sendOrderedBroadcast(Intent, string, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</seealso>
		public abstract void sendOrderedBroadcast(android.content.Intent intent, string receiverPermission
			);

		/// <summary>
		/// Version of
		/// <see cref="sendBroadcast(Intent)">sendBroadcast(Intent)</see>
		/// that allows you to
		/// receive data back from the broadcast.  This is accomplished by
		/// supplying your own BroadcastReceiver when calling, which will be
		/// treated as a final receiver at the end of the broadcast -- its
		/// <see cref="BroadcastReceiver.onReceive(Context, Intent)">BroadcastReceiver.onReceive(Context, Intent)
		/// 	</see>
		/// method will be called with
		/// the result values collected from the other receivers.  The broadcast will
		/// be serialized in the same way as calling
		/// <see cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</see>
		/// .
		/// <p>Like
		/// <see cref="sendBroadcast(Intent)">sendBroadcast(Intent)</see>
		/// , this method is
		/// asynchronous; it will return before
		/// resultReceiver.onReceive() is called.
		/// <p>See
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// for more information on Intent broadcasts.
		/// </summary>
		/// <param name="intent">
		/// The Intent to broadcast; all receivers matching this
		/// Intent will receive the broadcast.
		/// </param>
		/// <param name="receiverPermission">
		/// String naming a permissions that
		/// a receiver must hold in order to receive your broadcast.
		/// If null, no permission is required.
		/// </param>
		/// <param name="resultReceiver">
		/// Your own BroadcastReceiver to treat as the final
		/// receiver of the broadcast.
		/// </param>
		/// <param name="scheduler">
		/// A custom Handler with which to schedule the
		/// resultReceiver callback; if null it will be
		/// scheduled in the Context's main thread.
		/// </param>
		/// <param name="initialCode">
		/// An initial value for the result code.  Often
		/// Activity.RESULT_OK.
		/// </param>
		/// <param name="initialData">
		/// An initial value for the result data.  Often
		/// null.
		/// </param>
		/// <param name="initialExtras">
		/// An initial value for the result extras.  Often
		/// null.
		/// </param>
		/// <seealso cref="sendBroadcast(Intent)">sendBroadcast(Intent)</seealso>
		/// <seealso cref="sendBroadcast(Intent, string)">sendBroadcast(Intent, string)</seealso>
		/// <seealso cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</seealso>
		/// <seealso cref="sendStickyBroadcast(Intent)">sendStickyBroadcast(Intent)</seealso>
		/// <seealso cref="sendStickyOrderedBroadcast(Intent, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">sendStickyOrderedBroadcast(Intent, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</seealso>
		/// <seealso cref="BroadcastReceiver">BroadcastReceiver</seealso>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</seealso>
		/// <seealso cref="android.app.Activity.RESULT_OK">android.app.Activity.RESULT_OK</seealso>
		public abstract void sendOrderedBroadcast(android.content.Intent intent, string receiverPermission
			, android.content.BroadcastReceiver resultReceiver, android.os.Handler scheduler
			, int initialCode, string initialData, android.os.Bundle initialExtras);

		/// <summary>
		/// Perform a
		/// <see cref="sendBroadcast(Intent)">sendBroadcast(Intent)</see>
		/// that is "sticky," meaning the
		/// Intent you are sending stays around after the broadcast is complete,
		/// so that others can quickly retrieve that data through the return
		/// value of
		/// <see cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</see>
		/// .  In
		/// all other ways, this behaves the same as
		/// <see cref="sendBroadcast(Intent)">sendBroadcast(Intent)</see>
		/// .
		/// <p>You must hold the
		/// <see cref="android.Manifest.permission.BROADCAST_STICKY">android.Manifest.permission.BROADCAST_STICKY
		/// 	</see>
		/// permission in order to use this API.  If you do not hold that
		/// permission,
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// will be thrown.
		/// </summary>
		/// <param name="intent">
		/// The Intent to broadcast; all receivers matching this
		/// Intent will receive the broadcast, and the Intent will be held to
		/// be re-broadcast to future receivers.
		/// </param>
		/// <seealso cref="sendBroadcast(Intent)">sendBroadcast(Intent)</seealso>
		/// <seealso cref="sendStickyOrderedBroadcast(Intent, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">sendStickyOrderedBroadcast(Intent, BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</seealso>
		public abstract void sendStickyBroadcast(android.content.Intent intent);

		/// <summary>
		/// Version of
		/// <see cref="sendStickyBroadcast(Intent)">sendStickyBroadcast(Intent)</see>
		/// that allows you to
		/// receive data back from the broadcast.  This is accomplished by
		/// supplying your own BroadcastReceiver when calling, which will be
		/// treated as a final receiver at the end of the broadcast -- its
		/// <see cref="BroadcastReceiver.onReceive(Context, Intent)">BroadcastReceiver.onReceive(Context, Intent)
		/// 	</see>
		/// method will be called with
		/// the result values collected from the other receivers.  The broadcast will
		/// be serialized in the same way as calling
		/// <see cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</see>
		/// .
		/// <p>Like
		/// <see cref="sendBroadcast(Intent)">sendBroadcast(Intent)</see>
		/// , this method is
		/// asynchronous; it will return before
		/// resultReceiver.onReceive() is called.  Note that the sticky data
		/// stored is only the data you initially supply to the broadcast, not
		/// the result of any changes made by the receivers.
		/// <p>See
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// for more information on Intent broadcasts.
		/// </summary>
		/// <param name="intent">
		/// The Intent to broadcast; all receivers matching this
		/// Intent will receive the broadcast.
		/// </param>
		/// <param name="resultReceiver">
		/// Your own BroadcastReceiver to treat as the final
		/// receiver of the broadcast.
		/// </param>
		/// <param name="scheduler">
		/// A custom Handler with which to schedule the
		/// resultReceiver callback; if null it will be
		/// scheduled in the Context's main thread.
		/// </param>
		/// <param name="initialCode">
		/// An initial value for the result code.  Often
		/// Activity.RESULT_OK.
		/// </param>
		/// <param name="initialData">
		/// An initial value for the result data.  Often
		/// null.
		/// </param>
		/// <param name="initialExtras">
		/// An initial value for the result extras.  Often
		/// null.
		/// </param>
		/// <seealso cref="sendBroadcast(Intent)">sendBroadcast(Intent)</seealso>
		/// <seealso cref="sendBroadcast(Intent, string)">sendBroadcast(Intent, string)</seealso>
		/// <seealso cref="sendOrderedBroadcast(Intent, string)">sendOrderedBroadcast(Intent, string)
		/// 	</seealso>
		/// <seealso cref="sendStickyBroadcast(Intent)">sendStickyBroadcast(Intent)</seealso>
		/// <seealso cref="BroadcastReceiver">BroadcastReceiver</seealso>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</seealso>
		/// <seealso cref="android.app.Activity.RESULT_OK">android.app.Activity.RESULT_OK</seealso>
		public abstract void sendStickyOrderedBroadcast(android.content.Intent intent, android.content.BroadcastReceiver
			 resultReceiver, android.os.Handler scheduler, int initialCode, string initialData
			, android.os.Bundle initialExtras);

		/// <summary>
		/// Remove the data previously sent with
		/// <see cref="sendStickyBroadcast(Intent)">sendStickyBroadcast(Intent)</see>
		/// ,
		/// so that it is as if the sticky broadcast had never happened.
		/// <p>You must hold the
		/// <see cref="android.Manifest.permission.BROADCAST_STICKY">android.Manifest.permission.BROADCAST_STICKY
		/// 	</see>
		/// permission in order to use this API.  If you do not hold that
		/// permission,
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// will be thrown.
		/// </summary>
		/// <param name="intent">The Intent that was previously broadcast.</param>
		/// <seealso cref="sendStickyBroadcast(Intent)">sendStickyBroadcast(Intent)</seealso>
		public abstract void removeStickyBroadcast(android.content.Intent intent);

		/// <summary>Register a BroadcastReceiver to be run in the main activity thread.</summary>
		/// <remarks>
		/// Register a BroadcastReceiver to be run in the main activity thread.  The
		/// <var>receiver</var> will be called with any broadcast Intent that
		/// matches <var>filter</var>, in the main application thread.
		/// <p>The system may broadcast Intents that are "sticky" -- these stay
		/// around after the broadcast as finished, to be sent to any later
		/// registrations. If your IntentFilter matches one of these sticky
		/// Intents, that Intent will be returned by this function
		/// <strong>and</strong> sent to your <var>receiver</var> as if it had just
		/// been broadcast.
		/// <p>There may be multiple sticky Intents that match <var>filter</var>,
		/// in which case each of these will be sent to <var>receiver</var>.  In
		/// this case, only one of these can be returned directly by the function;
		/// which of these that is returned is arbitrarily decided by the system.
		/// <p>If you know the Intent your are registering for is sticky, you can
		/// supply null for your <var>receiver</var>.  In this case, no receiver is
		/// registered -- the function simply returns the sticky Intent that
		/// matches <var>filter</var>.  In the case of multiple matches, the same
		/// rules as described above apply.
		/// <p>See
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// for more information on Intent broadcasts.
		/// <p>As of
		/// <see cref="android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH">android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH
		/// 	</see>
		/// , receivers
		/// registered with this method will correctly respect the
		/// <see cref="Intent.setPackage(string)">Intent.setPackage(string)</see>
		/// specified for an Intent being broadcast.
		/// Prior to that, it would be ignored and delivered to all matching registered
		/// receivers.  Be careful if using this for security.</p>
		/// <p class="note">Note: this method <em>cannot be called from a
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// component;</em> that is, from a BroadcastReceiver
		/// that is declared in an application's manifest.  It is okay, however, to call
		/// this method from another BroadcastReceiver that has itself been registered
		/// at run time with
		/// <see cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</see>
		/// , since the lifetime of such a
		/// registered BroadcastReceiver is tied to the object that registered it.</p>
		/// </remarks>
		/// <param name="receiver">The BroadcastReceiver to handle the broadcast.</param>
		/// <param name="filter">Selects the Intent broadcasts to be received.</param>
		/// <returns>
		/// The first sticky intent found that matches <var>filter</var>,
		/// or null if there are none.
		/// </returns>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter, string, android.os.Handler)
		/// 	">registerReceiver(BroadcastReceiver, IntentFilter, string, android.os.Handler)</seealso>
		/// <seealso cref="sendBroadcast(Intent)">sendBroadcast(Intent)</seealso>
		/// <seealso cref="unregisterReceiver(BroadcastReceiver)">unregisterReceiver(BroadcastReceiver)
		/// 	</seealso>
		public abstract android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter);

		/// <summary>
		/// Register to receive intent broadcasts, to run in the context of
		/// <var>scheduler</var>.
		/// </summary>
		/// <remarks>
		/// Register to receive intent broadcasts, to run in the context of
		/// <var>scheduler</var>.  See
		/// <see cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</see>
		/// for more
		/// information.  This allows you to enforce permissions on who can
		/// broadcast intents to your receiver, or have the receiver run in
		/// a different thread than the main application thread.
		/// <p>See
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// for more information on Intent broadcasts.
		/// <p>As of
		/// <see cref="android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH">android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH
		/// 	</see>
		/// , receivers
		/// registered with this method will correctly respect the
		/// <see cref="Intent.setPackage(string)">Intent.setPackage(string)</see>
		/// specified for an Intent being broadcast.
		/// Prior to that, it would be ignored and delivered to all matching registered
		/// receivers.  Be careful if using this for security.</p>
		/// </remarks>
		/// <param name="receiver">The BroadcastReceiver to handle the broadcast.</param>
		/// <param name="filter">Selects the Intent broadcasts to be received.</param>
		/// <param name="broadcastPermission">
		/// String naming a permissions that a
		/// broadcaster must hold in order to send an Intent to you.  If null,
		/// no permission is required.
		/// </param>
		/// <param name="scheduler">
		/// Handler identifying the thread that will receive
		/// the Intent.  If null, the main thread of the process will be used.
		/// </param>
		/// <returns>
		/// The first sticky intent found that matches <var>filter</var>,
		/// or null if there are none.
		/// </returns>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</seealso>
		/// <seealso cref="sendBroadcast(Intent)">sendBroadcast(Intent)</seealso>
		/// <seealso cref="unregisterReceiver(BroadcastReceiver)">unregisterReceiver(BroadcastReceiver)
		/// 	</seealso>
		public abstract android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter, string broadcastPermission, android.os.Handler
			 scheduler);

		/// <summary>Unregister a previously registered BroadcastReceiver.</summary>
		/// <remarks>
		/// Unregister a previously registered BroadcastReceiver.  <em>All</em>
		/// filters that have been registered for this BroadcastReceiver will be
		/// removed.
		/// </remarks>
		/// <param name="receiver">The BroadcastReceiver to unregister.</param>
		/// <seealso cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</seealso>
		public abstract void unregisterReceiver(android.content.BroadcastReceiver receiver
			);

		/// <summary>Request that a given application service be started.</summary>
		/// <remarks>
		/// Request that a given application service be started.  The Intent
		/// can either contain the complete class name of a specific service
		/// implementation to start, or an abstract definition through the
		/// action and other fields of the kind of service to start.  If this service
		/// is not already running, it will be instantiated and started (creating a
		/// process for it if needed); if it is running then it remains running.
		/// <p>Every call to this method will result in a corresponding call to
		/// the target service's
		/// <see cref="android.app.Service.onStartCommand(Intent, int, int)">android.app.Service.onStartCommand(Intent, int, int)
		/// 	</see>
		/// method,
		/// with the <var>intent</var> given here.  This provides a convenient way
		/// to submit jobs to a service without having to bind and call on to its
		/// interface.
		/// <p>Using startService() overrides the default service lifetime that is
		/// managed by
		/// <see cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</see>
		/// : it requires the service to remain
		/// running until
		/// <see cref="stopService(Intent)">stopService(Intent)</see>
		/// is called, regardless of whether
		/// any clients are connected to it.  Note that calls to startService()
		/// are not nesting: no matter how many times you call startService(),
		/// a single call to
		/// <see cref="stopService(Intent)">stopService(Intent)</see>
		/// will stop it.
		/// <p>The system attempts to keep running services around as much as
		/// possible.  The only time they should be stopped is if the current
		/// foreground application is using so many resources that the service needs
		/// to be killed.  If any errors happen in the service's process, it will
		/// automatically be restarted.
		/// <p>This function will throw
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// if you do not
		/// have permission to start the given service.
		/// </remarks>
		/// <param name="service">
		/// Identifies the service to be started.  The Intent may
		/// specify either an explicit component name to start, or a logical
		/// description (action, category, etc) to match an
		/// <see cref="IntentFilter">IntentFilter</see>
		/// published by a service.  Additional values
		/// may be included in the Intent extras to supply arguments along with
		/// this specific start call.
		/// </param>
		/// <returns>
		/// If the service is being started or is already running, the
		/// <see cref="ComponentName">ComponentName</see>
		/// of the actual service that was started is
		/// returned; else if the service does not exist null is returned.
		/// </returns>
		/// <exception cref="System.Security.SecurityException">System.Security.SecurityException
		/// 	</exception>
		/// <seealso cref="stopService(Intent)">stopService(Intent)</seealso>
		/// <seealso cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</seealso>
		public abstract android.content.ComponentName startService(android.content.Intent
			 service);

		/// <summary>Request that a given application service be stopped.</summary>
		/// <remarks>
		/// Request that a given application service be stopped.  If the service is
		/// not running, nothing happens.  Otherwise it is stopped.  Note that calls
		/// to startService() are not counted -- this stops the service no matter
		/// how many times it was started.
		/// <p>Note that if a stopped service still has
		/// <see cref="ServiceConnection">ServiceConnection</see>
		/// objects bound to it with the
		/// <see cref="BIND_AUTO_CREATE">BIND_AUTO_CREATE</see>
		/// set, it will
		/// not be destroyed until all of these bindings are removed.  See
		/// the
		/// <see cref="android.app.Service">android.app.Service</see>
		/// documentation for more details on a
		/// service's lifecycle.
		/// <p>This function will throw
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// if you do not
		/// have permission to stop the given service.
		/// </remarks>
		/// <param name="service">
		/// Description of the service to be stopped.  The Intent may
		/// specify either an explicit component name to start, or a logical
		/// description (action, category, etc) to match an
		/// <see cref="IntentFilter">IntentFilter</see>
		/// published by a service.
		/// </param>
		/// <returns>
		/// If there is a service matching the given Intent that is already
		/// running, then it is stopped and true is returned; else false is returned.
		/// </returns>
		/// <exception cref="System.Security.SecurityException">System.Security.SecurityException
		/// 	</exception>
		/// <seealso cref="startService(Intent)">startService(Intent)</seealso>
		public abstract bool stopService(android.content.Intent service);

		/// <summary>Connect to an application service, creating it if needed.</summary>
		/// <remarks>
		/// Connect to an application service, creating it if needed.  This defines
		/// a dependency between your application and the service.  The given
		/// <var>conn</var> will receive the service object when its created and be
		/// told if it dies and restarts.  The service will be considered required
		/// by the system only for as long as the calling context exists.  For
		/// example, if this Context is an Activity that is stopped, the service will
		/// not be required to continue running until the Activity is resumed.
		/// <p>This function will throw
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// if you do not
		/// have permission to bind to the given service.
		/// <p class="note">Note: this method <em>can not be called from an
		/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
		/// component</em>.  A pattern you can use to
		/// communicate from an BroadcastReceiver to a Service is to call
		/// <see cref="startService(Intent)">startService(Intent)</see>
		/// with the arguments containing the command to be
		/// sent, with the service calling its
		/// <see cref="android.app.Service.stopSelf(int)">android.app.Service.stopSelf(int)</see>
		/// method when done executing
		/// that command.  See the API demo App/Service/Service Start Arguments
		/// Controller for an illustration of this.  It is okay, however, to use
		/// this method from an BroadcastReceiver that has been registered with
		/// <see cref="registerReceiver(BroadcastReceiver, IntentFilter)">registerReceiver(BroadcastReceiver, IntentFilter)
		/// 	</see>
		/// , since the lifetime of this BroadcastReceiver
		/// is tied to another object (the one that registered it).</p>
		/// </remarks>
		/// <param name="service">
		/// Identifies the service to connect to.  The Intent may
		/// specify either an explicit component name, or a logical
		/// description (action, category, etc) to match an
		/// <see cref="IntentFilter">IntentFilter</see>
		/// published by a service.
		/// </param>
		/// <param name="conn">Receives information as the service is started and stopped.</param>
		/// <param name="flags">
		/// Operation options for the binding.  May be 0,
		/// <see cref="BIND_AUTO_CREATE">BIND_AUTO_CREATE</see>
		/// ,
		/// <see cref="BIND_DEBUG_UNBIND">BIND_DEBUG_UNBIND</see>
		/// ,
		/// <see cref="BIND_NOT_FOREGROUND">BIND_NOT_FOREGROUND</see>
		/// ,
		/// <see cref="BIND_ABOVE_CLIENT">BIND_ABOVE_CLIENT</see>
		/// ,
		/// <see cref="BIND_ALLOW_OOM_MANAGEMENT">BIND_ALLOW_OOM_MANAGEMENT</see>
		/// , or
		/// <see cref="BIND_WAIVE_PRIORITY">BIND_WAIVE_PRIORITY</see>
		/// .
		/// </param>
		/// <returns>
		/// If you have successfully bound to the service, true is returned;
		/// false is returned if the connection is not made so you will not
		/// receive the service object.
		/// </returns>
		/// <exception cref="System.Security.SecurityException">System.Security.SecurityException
		/// 	</exception>
		/// <seealso cref="unbindService(ServiceConnection)">unbindService(ServiceConnection)
		/// 	</seealso>
		/// <seealso cref="startService(Intent)">startService(Intent)</seealso>
		/// <seealso cref="BIND_AUTO_CREATE">BIND_AUTO_CREATE</seealso>
		/// <seealso cref="BIND_DEBUG_UNBIND">BIND_DEBUG_UNBIND</seealso>
		/// <seealso cref="BIND_NOT_FOREGROUND">BIND_NOT_FOREGROUND</seealso>
		public abstract bool bindService(android.content.Intent service, android.content.ServiceConnection
			 conn, int flags);

		/// <summary>Disconnect from an application service.</summary>
		/// <remarks>
		/// Disconnect from an application service.  You will no longer receive
		/// calls as the service is restarted, and the service is now allowed to
		/// stop at any time.
		/// </remarks>
		/// <param name="conn">
		/// The connection interface previously supplied to
		/// bindService().
		/// </param>
		/// <seealso cref="bindService(Intent, ServiceConnection, int)">bindService(Intent, ServiceConnection, int)
		/// 	</seealso>
		public abstract void unbindService(android.content.ServiceConnection conn);

		/// <summary>
		/// Start executing an
		/// <see cref="android.app.Instrumentation">android.app.Instrumentation</see>
		/// class.  The given
		/// Instrumentation component will be run by killing its target application
		/// (if currently running), starting the target process, instantiating the
		/// instrumentation component, and then letting it drive the application.
		/// <p>This function is not synchronous -- it returns as soon as the
		/// instrumentation has started and while it is running.
		/// <p>Instrumentation is normally only allowed to run against a package
		/// that is either unsigned or signed with a signature that the
		/// the instrumentation package is also signed with (ensuring the target
		/// trusts the instrumentation).
		/// </summary>
		/// <param name="className">Name of the Instrumentation component to be run.</param>
		/// <param name="profileFile">
		/// Optional path to write profiling data as the
		/// instrumentation runs, or null for no profiling.
		/// </param>
		/// <param name="arguments">
		/// Additional optional arguments to pass to the
		/// instrumentation, or null.
		/// </param>
		/// <returns>
		/// Returns true if the instrumentation was successfully started,
		/// else false if it could not be found.
		/// </returns>
		public abstract bool startInstrumentation(android.content.ComponentName className
			, string profileFile, android.os.Bundle arguments);

		/// <summary>Return the handle to a system-level service by name.</summary>
		/// <remarks>
		/// Return the handle to a system-level service by name. The class of the
		/// returned object varies by the requested name. Currently available names
		/// are:
		/// <dl>
		/// <dt>
		/// <see cref="WINDOW_SERVICE">WINDOW_SERVICE</see>
		/// ("window")
		/// <dd> The top-level window manager in which you can place custom
		/// windows.  The returned object is a
		/// <see cref="android.view.WindowManager">android.view.WindowManager</see>
		/// .
		/// <dt>
		/// <see cref="LAYOUT_INFLATER_SERVICE">LAYOUT_INFLATER_SERVICE</see>
		/// ("layout_inflater")
		/// <dd> A
		/// <see cref="android.view.LayoutInflater">android.view.LayoutInflater</see>
		/// for inflating layout resources
		/// in this context.
		/// <dt>
		/// <see cref="ACTIVITY_SERVICE">ACTIVITY_SERVICE</see>
		/// ("activity")
		/// <dd> A
		/// <see cref="android.app.ActivityManager">android.app.ActivityManager</see>
		/// for interacting with the
		/// global activity state of the system.
		/// <dt>
		/// <see cref="POWER_SERVICE">POWER_SERVICE</see>
		/// ("power")
		/// <dd> A
		/// <see cref="android.os.PowerManager">android.os.PowerManager</see>
		/// for controlling power
		/// management.
		/// <dt>
		/// <see cref="ALARM_SERVICE">ALARM_SERVICE</see>
		/// ("alarm")
		/// <dd> A
		/// <see cref="android.app.AlarmManager">android.app.AlarmManager</see>
		/// for receiving intents at the
		/// time of your choosing.
		/// <dt>
		/// <see cref="NOTIFICATION_SERVICE">NOTIFICATION_SERVICE</see>
		/// ("notification")
		/// <dd> A
		/// <see cref="android.app.NotificationManager">android.app.NotificationManager</see>
		/// for informing the user
		/// of background events.
		/// <dt>
		/// <see cref="KEYGUARD_SERVICE">KEYGUARD_SERVICE</see>
		/// ("keyguard")
		/// <dd> A
		/// <see cref="android.app.KeyguardManager">android.app.KeyguardManager</see>
		/// for controlling keyguard.
		/// <dt>
		/// <see cref="LOCATION_SERVICE">LOCATION_SERVICE</see>
		/// ("location")
		/// <dd> A
		/// <see cref="android.location.LocationManager">android.location.LocationManager</see>
		/// for controlling location
		/// (e.g., GPS) updates.
		/// <dt>
		/// <see cref="SEARCH_SERVICE">SEARCH_SERVICE</see>
		/// ("search")
		/// <dd> A
		/// <see cref="android.app.SearchManager">android.app.SearchManager</see>
		/// for handling search.
		/// <dt>
		/// <see cref="VIBRATOR_SERVICE">VIBRATOR_SERVICE</see>
		/// ("vibrator")
		/// <dd> A
		/// <see cref="android.os.Vibrator">android.os.Vibrator</see>
		/// for interacting with the vibrator
		/// hardware.
		/// <dt>
		/// <see cref="CONNECTIVITY_SERVICE">CONNECTIVITY_SERVICE</see>
		/// ("connection")
		/// <dd> A
		/// <see cref="android.net.ConnectivityManager">ConnectivityManager</see>
		/// for
		/// handling management of network connections.
		/// <dt>
		/// <see cref="WIFI_SERVICE">WIFI_SERVICE</see>
		/// ("wifi")
		/// <dd> A
		/// <see cref="android.net.wifi.WifiManager">WifiManager</see>
		/// for management of
		/// Wi-Fi connectivity.
		/// <dt>
		/// <see cref="INPUT_METHOD_SERVICE">INPUT_METHOD_SERVICE</see>
		/// ("input_method")
		/// <dd> An
		/// <see cref="android.view.inputmethod.InputMethodManager">InputMethodManager</see>
		/// for management of input methods.
		/// <dt>
		/// <see cref="UI_MODE_SERVICE">UI_MODE_SERVICE</see>
		/// ("uimode")
		/// <dd> An
		/// <see cref="android.app.UiModeManager">android.app.UiModeManager</see>
		/// for controlling UI modes.
		/// <dt>
		/// <see cref="DOWNLOAD_SERVICE">DOWNLOAD_SERVICE</see>
		/// ("download")
		/// <dd> A
		/// <see cref="android.app.DownloadManager">android.app.DownloadManager</see>
		/// for requesting HTTP downloads
		/// </dl>
		/// <p>Note:  System services obtained via this API may be closely associated with
		/// the Context in which they are obtained from.  In general, do not share the
		/// service objects between various different contexts (Activities, Applications,
		/// Services, Providers, etc.)
		/// </remarks>
		/// <param name="name">The name of the desired service.</param>
		/// <returns>The service or null if the name does not exist.</returns>
		/// <seealso cref="WINDOW_SERVICE">WINDOW_SERVICE</seealso>
		/// <seealso cref="android.view.WindowManager">android.view.WindowManager</seealso>
		/// <seealso cref="LAYOUT_INFLATER_SERVICE">LAYOUT_INFLATER_SERVICE</seealso>
		/// <seealso cref="android.view.LayoutInflater">android.view.LayoutInflater</seealso>
		/// <seealso cref="ACTIVITY_SERVICE">ACTIVITY_SERVICE</seealso>
		/// <seealso cref="android.app.ActivityManager">android.app.ActivityManager</seealso>
		/// <seealso cref="POWER_SERVICE">POWER_SERVICE</seealso>
		/// <seealso cref="android.os.PowerManager">android.os.PowerManager</seealso>
		/// <seealso cref="ALARM_SERVICE">ALARM_SERVICE</seealso>
		/// <seealso cref="android.app.AlarmManager">android.app.AlarmManager</seealso>
		/// <seealso cref="NOTIFICATION_SERVICE">NOTIFICATION_SERVICE</seealso>
		/// <seealso cref="android.app.NotificationManager">android.app.NotificationManager</seealso>
		/// <seealso cref="KEYGUARD_SERVICE">KEYGUARD_SERVICE</seealso>
		/// <seealso cref="android.app.KeyguardManager">android.app.KeyguardManager</seealso>
		/// <seealso cref="LOCATION_SERVICE">LOCATION_SERVICE</seealso>
		/// <seealso cref="android.location.LocationManager">android.location.LocationManager
		/// 	</seealso>
		/// <seealso cref="SEARCH_SERVICE">SEARCH_SERVICE</seealso>
		/// <seealso cref="android.app.SearchManager">android.app.SearchManager</seealso>
		/// <seealso cref="SENSOR_SERVICE">SENSOR_SERVICE</seealso>
		/// <seealso cref="android.hardware.SensorManager">android.hardware.SensorManager</seealso>
		/// <seealso cref="STORAGE_SERVICE">STORAGE_SERVICE</seealso>
		/// <seealso cref="android.os.storage.StorageManager">android.os.storage.StorageManager
		/// 	</seealso>
		/// <seealso cref="VIBRATOR_SERVICE">VIBRATOR_SERVICE</seealso>
		/// <seealso cref="android.os.Vibrator">android.os.Vibrator</seealso>
		/// <seealso cref="CONNECTIVITY_SERVICE">CONNECTIVITY_SERVICE</seealso>
		/// <seealso cref="android.net.ConnectivityManager">android.net.ConnectivityManager</seealso>
		/// <seealso cref="WIFI_SERVICE">WIFI_SERVICE</seealso>
		/// <seealso cref="android.net.wifi.WifiManager">android.net.wifi.WifiManager</seealso>
		/// <seealso cref="AUDIO_SERVICE">AUDIO_SERVICE</seealso>
		/// <seealso cref="android.media.AudioManager">android.media.AudioManager</seealso>
		/// <seealso cref="TELEPHONY_SERVICE">TELEPHONY_SERVICE</seealso>
		/// <seealso cref="android.telephony.TelephonyManager">android.telephony.TelephonyManager
		/// 	</seealso>
		/// <seealso cref="INPUT_METHOD_SERVICE">INPUT_METHOD_SERVICE</seealso>
		/// <seealso cref="android.view.inputmethod.InputMethodManager">android.view.inputmethod.InputMethodManager
		/// 	</seealso>
		/// <seealso cref="UI_MODE_SERVICE">UI_MODE_SERVICE</seealso>
		/// <seealso cref="android.app.UiModeManager">android.app.UiModeManager</seealso>
		/// <seealso cref="DOWNLOAD_SERVICE">DOWNLOAD_SERVICE</seealso>
		/// <seealso cref="android.app.DownloadManager">android.app.DownloadManager</seealso>
		public abstract object getSystemService(string name);

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.os.PowerManager">android.os.PowerManager</see>
		/// for controlling power management,
		/// including "wake locks," which let you keep the device on while
		/// you're running long tasks.
		/// </summary>
		public const string POWER_SERVICE = "power";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.view.WindowManager">android.view.WindowManager</see>
		/// for accessing the system's window
		/// manager.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.view.WindowManager">android.view.WindowManager</seealso>
		public const string WINDOW_SERVICE = "window";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.view.LayoutInflater">android.view.LayoutInflater</see>
		/// for inflating layout resources in this
		/// context.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.view.LayoutInflater">android.view.LayoutInflater</seealso>
		public const string LAYOUT_INFLATER_SERVICE = "layout_inflater";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.accounts.AccountManager">android.accounts.AccountManager</see>
		/// for receiving intents at a
		/// time of your choosing.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.accounts.AccountManager">android.accounts.AccountManager</seealso>
		public const string ACCOUNT_SERVICE = "account";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.ActivityManager">android.app.ActivityManager</see>
		/// for interacting with the global
		/// system state.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.app.ActivityManager">android.app.ActivityManager</seealso>
		public const string ACTIVITY_SERVICE = "activity";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.AlarmManager">android.app.AlarmManager</see>
		/// for receiving intents at a
		/// time of your choosing.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.app.AlarmManager">android.app.AlarmManager</seealso>
		public const string ALARM_SERVICE = "alarm";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.NotificationManager">android.app.NotificationManager</see>
		/// for informing the user of
		/// background events.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.app.NotificationManager">android.app.NotificationManager</seealso>
		public const string NOTIFICATION_SERVICE = "notification";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.view.accessibility.AccessibilityManager">android.view.accessibility.AccessibilityManager
		/// 	</see>
		/// for giving the user
		/// feedback for UI events through the registered event listeners.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.view.accessibility.AccessibilityManager">android.view.accessibility.AccessibilityManager
		/// 	</seealso>
		public const string ACCESSIBILITY_SERVICE = "accessibility";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.NotificationManager">android.app.NotificationManager</see>
		/// for controlling keyguard.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.app.KeyguardManager">android.app.KeyguardManager</seealso>
		public const string KEYGUARD_SERVICE = "keyguard";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.location.LocationManager">android.location.LocationManager</see>
		/// for controlling location
		/// updates.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.location.LocationManager">android.location.LocationManager
		/// 	</seealso>
		public const string LOCATION_SERVICE = "location";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.location.CountryDetector">android.location.CountryDetector</see>
		/// for detecting the country that
		/// the user is in.
		/// </summary>
		/// <hide></hide>
		public const string COUNTRY_DETECTOR = "country_detector";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.SearchManager">android.app.SearchManager</see>
		/// for handling searches.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.app.SearchManager">android.app.SearchManager</seealso>
		public const string SEARCH_SERVICE = "search";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.hardware.SensorManager">android.hardware.SensorManager</see>
		/// for accessing sensors.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.hardware.SensorManager">android.hardware.SensorManager</seealso>
		public const string SENSOR_SERVICE = "sensor";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.os.storage.StorageManager">android.os.storage.StorageManager</see>
		/// for accessing system storage
		/// functions.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.os.storage.StorageManager">android.os.storage.StorageManager
		/// 	</seealso>
		public const string STORAGE_SERVICE = "storage";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// com.android.server.WallpaperService for accessing wallpapers.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string WALLPAPER_SERVICE = "wallpaper";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.os.Vibrator">android.os.Vibrator</see>
		/// for interacting with the vibration hardware.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.os.Vibrator">android.os.Vibrator</seealso>
		public const string VIBRATOR_SERVICE = "vibrator";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.StatusBarManager">android.app.StatusBarManager</see>
		/// for interacting with the status bar.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.app.StatusBarManager">android.app.StatusBarManager</seealso>
		/// <hide></hide>
		public const string STATUS_BAR_SERVICE = "statusbar";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.net.ConnectivityManager">android.net.ConnectivityManager</see>
		/// for handling management of
		/// network connections.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.net.ConnectivityManager">android.net.ConnectivityManager</seealso>
		public const string CONNECTIVITY_SERVICE = "connectivity";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.net.ThrottleManager">android.net.ThrottleManager</see>
		/// for handling management of
		/// throttling.
		/// </summary>
		/// <hide></hide>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.net.ThrottleManager">android.net.ThrottleManager</seealso>
		public const string THROTTLE_SERVICE = "throttle";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.net.NetworkManagementService">android.net.NetworkManagementService
		/// 	</see>
		/// for handling management of
		/// system network services
		/// </summary>
		/// <hide></hide>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.net.NetworkManagementService">android.net.NetworkManagementService
		/// 	</seealso>
		public const string NETWORKMANAGEMENT_SERVICE = "network_management";

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		public const string NETWORK_STATS_SERVICE = "netstats";

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		public const string NETWORK_POLICY_SERVICE = "netpolicy";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.net.wifi.WifiManager">android.net.wifi.WifiManager</see>
		/// for handling management of
		/// Wi-Fi access.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.net.wifi.WifiManager">android.net.wifi.WifiManager</seealso>
		public const string WIFI_SERVICE = "wifi";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.net.wifi.p2p.WifiP2pManager">android.net.wifi.p2p.WifiP2pManager
		/// 	</see>
		/// for handling management of
		/// Wi-Fi peer-to-peer connections.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.net.wifi.p2p.WifiP2pManager">android.net.wifi.p2p.WifiP2pManager
		/// 	</seealso>
		public const string WIFI_P2P_SERVICE = "wifip2p";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.media.AudioManager">android.media.AudioManager</see>
		/// for handling management of volume,
		/// ringer modes and audio routing.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.media.AudioManager">android.media.AudioManager</seealso>
		public const string AUDIO_SERVICE = "audio";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.telephony.TelephonyManager">android.telephony.TelephonyManager
		/// 	</see>
		/// for handling management the
		/// telephony features of the device.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.telephony.TelephonyManager">android.telephony.TelephonyManager
		/// 	</seealso>
		public const string TELEPHONY_SERVICE = "phone";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.text.ClipboardManager">android.text.ClipboardManager</see>
		/// for accessing and modifying
		/// the contents of the global clipboard.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.text.ClipboardManager">android.text.ClipboardManager</seealso>
		public const string CLIPBOARD_SERVICE = "clipboard";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.view.inputmethod.InputMethodManager">android.view.inputmethod.InputMethodManager
		/// 	</see>
		/// for accessing input
		/// methods.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string INPUT_METHOD_SERVICE = "input_method";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.view.textservice.TextServicesManager">android.view.textservice.TextServicesManager
		/// 	</see>
		/// for accessing
		/// text services.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string TEXT_SERVICES_MANAGER_SERVICE = "textservices";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.appwidget.AppWidgetManager">android.appwidget.AppWidgetManager
		/// 	</see>
		/// for accessing AppWidgets.
		/// </summary>
		/// <hide></hide>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string APPWIDGET_SERVICE = "appwidget";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve an
		/// <see cref="android.app.backup.IBackupManager">IBackupManager</see>
		/// for communicating
		/// with the backup mechanism.
		/// </summary>
		/// <hide></hide>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string BACKUP_SERVICE = "backup";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.os.DropBoxManager">android.os.DropBoxManager</see>
		/// instance for recording
		/// diagnostic logs.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string DROPBOX_SERVICE = "dropbox";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.admin.DevicePolicyManager">android.app.admin.DevicePolicyManager
		/// 	</see>
		/// for working with global
		/// device policy management.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string DEVICE_POLICY_SERVICE = "device_policy";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.UiModeManager">android.app.UiModeManager</see>
		/// for controlling UI modes.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string UI_MODE_SERVICE = "uimode";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.app.DownloadManager">android.app.DownloadManager</see>
		/// for requesting HTTP downloads.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string DOWNLOAD_SERVICE = "download";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.nfc.NfcManager">android.nfc.NfcManager</see>
		/// for using NFC.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		public const string NFC_SERVICE = "nfc";

		/// <hide></hide>
		public const string SIP_SERVICE = "sip";

		/// <summary>
		/// Use with
		/// <see cref="getSystemService(string)">getSystemService(string)</see>
		/// to retrieve a
		/// <see cref="android.hardware.usb.UsbManager">android.hardware.usb.UsbManager</see>
		/// for access to USB devices (as a USB host)
		/// and for controlling this device's behavior as a USB device.
		/// </summary>
		/// <seealso cref="getSystemService(string)">getSystemService(string)</seealso>
		/// <seealso cref="android.harware.usb.UsbManager">android.harware.usb.UsbManager</seealso>
		public const string USB_SERVICE = "usb";

		/// <summary>
		/// Determine whether the given permission is allowed for a particular
		/// process and user ID running in the system.
		/// </summary>
		/// <remarks>
		/// Determine whether the given permission is allowed for a particular
		/// process and user ID running in the system.
		/// </remarks>
		/// <param name="permission">The name of the permission being checked.</param>
		/// <param name="pid">The process ID being checked against.  Must be &gt; 0.</param>
		/// <param name="uid">
		/// The user ID being checked against.  A uid of 0 is the root
		/// user, which will pass every permission check.
		/// </param>
		/// <returns>
		/// Returns
		/// <see cref="android.content.pm.PackageManager.PERMISSION_GRANTED">android.content.pm.PackageManager.PERMISSION_GRANTED
		/// 	</see>
		/// if the given
		/// pid/uid is allowed that permission, or
		/// <see cref="android.content.pm.PackageManager.PERMISSION_DENIED">android.content.pm.PackageManager.PERMISSION_DENIED
		/// 	</see>
		/// if it is not.
		/// </returns>
		/// <seealso cref="android.content.pm.PackageManager.checkPermission(string, string)"
		/// 	>android.content.pm.PackageManager.checkPermission(string, string)</seealso>
		/// <seealso cref="checkCallingPermission(string)">checkCallingPermission(string)</seealso>
		public abstract int checkPermission(string permission, int pid, int uid);

		/// <summary>
		/// Determine whether the calling process of an IPC you are handling has been
		/// granted a particular permission.
		/// </summary>
		/// <remarks>
		/// Determine whether the calling process of an IPC you are handling has been
		/// granted a particular permission.  This is basically the same as calling
		/// <see cref="checkPermission(string, int, int)">checkPermission(string, int, int)</see>
		/// with the pid and uid returned
		/// by
		/// <see cref="android.os.Binder.getCallingPid()">android.os.Binder.getCallingPid()</see>
		/// and
		/// <see cref="android.os.Binder.getCallingUid()">android.os.Binder.getCallingUid()</see>
		/// .  One important difference
		/// is that if you are not currently processing an IPC, this function
		/// will always fail.  This is done to protect against accidentally
		/// leaking permissions; you can use
		/// <see cref="checkCallingOrSelfPermission(string)">checkCallingOrSelfPermission(string)
		/// 	</see>
		/// to avoid this protection.
		/// </remarks>
		/// <param name="permission">The name of the permission being checked.</param>
		/// <returns>
		/// Returns
		/// <see cref="android.content.pm.PackageManager.PERMISSION_GRANTED">android.content.pm.PackageManager.PERMISSION_GRANTED
		/// 	</see>
		/// if the calling
		/// pid/uid is allowed that permission, or
		/// <see cref="android.content.pm.PackageManager.PERMISSION_DENIED">android.content.pm.PackageManager.PERMISSION_DENIED
		/// 	</see>
		/// if it is not.
		/// </returns>
		/// <seealso cref="android.content.pm.PackageManager.checkPermission(string, string)"
		/// 	>android.content.pm.PackageManager.checkPermission(string, string)</seealso>
		/// <seealso cref="checkPermission(string, int, int)">checkPermission(string, int, int)
		/// 	</seealso>
		/// <seealso cref="checkCallingOrSelfPermission(string)">checkCallingOrSelfPermission(string)
		/// 	</seealso>
		public abstract int checkCallingPermission(string permission);

		/// <summary>
		/// Determine whether the calling process of an IPC <em>or you</em> have been
		/// granted a particular permission.
		/// </summary>
		/// <remarks>
		/// Determine whether the calling process of an IPC <em>or you</em> have been
		/// granted a particular permission.  This is the same as
		/// <see cref="checkCallingPermission(string)">checkCallingPermission(string)</see>
		/// , except it grants your own permissions
		/// if you are not currently processing an IPC.  Use with care!
		/// </remarks>
		/// <param name="permission">The name of the permission being checked.</param>
		/// <returns>
		/// Returns
		/// <see cref="android.content.pm.PackageManager.PERMISSION_GRANTED">android.content.pm.PackageManager.PERMISSION_GRANTED
		/// 	</see>
		/// if the calling
		/// pid/uid is allowed that permission, or
		/// <see cref="android.content.pm.PackageManager.PERMISSION_DENIED">android.content.pm.PackageManager.PERMISSION_DENIED
		/// 	</see>
		/// if it is not.
		/// </returns>
		/// <seealso cref="android.content.pm.PackageManager.checkPermission(string, string)"
		/// 	>android.content.pm.PackageManager.checkPermission(string, string)</seealso>
		/// <seealso cref="checkPermission(string, int, int)">checkPermission(string, int, int)
		/// 	</seealso>
		/// <seealso cref="checkCallingPermission(string)">checkCallingPermission(string)</seealso>
		public abstract int checkCallingOrSelfPermission(string permission);

		/// <summary>
		/// If the given permission is not allowed for a particular process
		/// and user ID running in the system, throw a
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// .
		/// </summary>
		/// <param name="permission">The name of the permission being checked.</param>
		/// <param name="pid">The process ID being checked against.  Must be &gt; 0.</param>
		/// <param name="uid">
		/// The user ID being checked against.  A uid of 0 is the root
		/// user, which will pass every permission check.
		/// </param>
		/// <param name="message">A message to include in the exception if it is thrown.</param>
		/// <seealso cref="checkPermission(string, int, int)">checkPermission(string, int, int)
		/// 	</seealso>
		public abstract void enforcePermission(string permission, int pid, int uid, string
			 message);

		/// <summary>
		/// If the calling process of an IPC you are handling has not been
		/// granted a particular permission, throw a
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// .  This is basically the same as calling
		/// <see cref="enforcePermission(string, int, int, string)">enforcePermission(string, int, int, string)
		/// 	</see>
		/// with the
		/// pid and uid returned by
		/// <see cref="android.os.Binder.getCallingPid()">android.os.Binder.getCallingPid()</see>
		/// and
		/// <see cref="android.os.Binder.getCallingUid()">android.os.Binder.getCallingUid()</see>
		/// .  One important
		/// difference is that if you are not currently processing an IPC,
		/// this function will always throw the SecurityException.  This is
		/// done to protect against accidentally leaking permissions; you
		/// can use
		/// <see cref="enforceCallingOrSelfPermission(string, string)">enforceCallingOrSelfPermission(string, string)
		/// 	</see>
		/// to avoid this
		/// protection.
		/// </summary>
		/// <param name="permission">The name of the permission being checked.</param>
		/// <param name="message">A message to include in the exception if it is thrown.</param>
		/// <seealso cref="checkCallingPermission(string)">checkCallingPermission(string)</seealso>
		public abstract void enforceCallingPermission(string permission, string message);

		/// <summary>
		/// If neither you nor the calling process of an IPC you are
		/// handling has been granted a particular permission, throw a
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// .  This is the same as
		/// <see cref="enforceCallingPermission(string, string)">enforceCallingPermission(string, string)
		/// 	</see>
		/// , except it grants your own
		/// permissions if you are not currently processing an IPC.  Use
		/// with care!
		/// </summary>
		/// <param name="permission">The name of the permission being checked.</param>
		/// <param name="message">A message to include in the exception if it is thrown.</param>
		/// <seealso cref="checkCallingOrSelfPermission(string)">checkCallingOrSelfPermission(string)
		/// 	</seealso>
		public abstract void enforceCallingOrSelfPermission(string permission, string message
			);

		/// <summary>
		/// Grant permission to access a specific Uri to another package, regardless
		/// of whether that package has general permission to access the Uri's
		/// content provider.
		/// </summary>
		/// <remarks>
		/// Grant permission to access a specific Uri to another package, regardless
		/// of whether that package has general permission to access the Uri's
		/// content provider.  This can be used to grant specific, temporary
		/// permissions, typically in response to user interaction (such as the
		/// user opening an attachment that you would like someone else to
		/// display).
		/// <p>Normally you should use
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// with the Intent being used to
		/// start an activity instead of this function directly.  If you use this
		/// function directly, you should be sure to call
		/// <see cref="revokeUriPermission(System.Uri, int)">revokeUriPermission(System.Uri, int)
		/// 	</see>
		/// when the target should no longer be allowed
		/// to access it.
		/// <p>To succeed, the content provider owning the Uri must have set the
		/// <see cref="android.R.styleable.AndroidManifestProvider_grantUriPermissions">grantUriPermissions
		/// 	</see>
		/// attribute in its manifest or included the
		/// <see cref="android.R.styleable.AndroidManifestGrantUriPermission">&lt;grant-uri-permissions&gt;
		/// 	</see>
		/// tag.
		/// </remarks>
		/// <param name="toPackage">The package you would like to allow to access the Uri.</param>
		/// <param name="uri">The Uri you would like to grant access to.</param>
		/// <param name="modeFlags">
		/// The desired access modes.  Any combination of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <seealso cref="revokeUriPermission(System.Uri, int)">revokeUriPermission(System.Uri, int)
		/// 	</seealso>
		public abstract void grantUriPermission(string toPackage, System.Uri uri, int modeFlags
			);

		/// <summary>
		/// Remove all permissions to access a particular content provider Uri
		/// that were previously added with
		/// <see cref="grantUriPermission(string, System.Uri, int)">grantUriPermission(string, System.Uri, int)
		/// 	</see>
		/// .  The given
		/// Uri will match all previously granted Uris that are the same or a
		/// sub-path of the given Uri.  That is, revoking "content://foo/one" will
		/// revoke both "content://foo/target" and "content://foo/target/sub", but not
		/// "content://foo".
		/// </summary>
		/// <param name="uri">The Uri you would like to revoke access to.</param>
		/// <param name="modeFlags">
		/// The desired access modes.  Any combination of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <seealso cref="grantUriPermission(string, System.Uri, int)">grantUriPermission(string, System.Uri, int)
		/// 	</seealso>
		public abstract void revokeUriPermission(System.Uri uri, int modeFlags);

		/// <summary>
		/// Determine whether a particular process and user ID has been granted
		/// permission to access a specific URI.
		/// </summary>
		/// <remarks>
		/// Determine whether a particular process and user ID has been granted
		/// permission to access a specific URI.  This only checks for permissions
		/// that have been explicitly granted -- if the given process/uid has
		/// more general access to the URI's content provider then this check will
		/// always fail.
		/// </remarks>
		/// <param name="uri">The uri that is being checked.</param>
		/// <param name="pid">The process ID being checked against.  Must be &gt; 0.</param>
		/// <param name="uid">
		/// The user ID being checked against.  A uid of 0 is the root
		/// user, which will pass every permission check.
		/// </param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns
		/// <see cref="android.content.pm.PackageManager.PERMISSION_GRANTED">android.content.pm.PackageManager.PERMISSION_GRANTED
		/// 	</see>
		/// if the given
		/// pid/uid is allowed to access that uri, or
		/// <see cref="android.content.pm.PackageManager.PERMISSION_DENIED">android.content.pm.PackageManager.PERMISSION_DENIED
		/// 	</see>
		/// if it is not.
		/// </returns>
		/// <seealso cref="checkCallingUriPermission(System.Uri, int)">checkCallingUriPermission(System.Uri, int)
		/// 	</seealso>
		public abstract int checkUriPermission(System.Uri uri, int pid, int uid, int modeFlags
			);

		/// <summary>
		/// Determine whether the calling process and user ID has been
		/// granted permission to access a specific URI.
		/// </summary>
		/// <remarks>
		/// Determine whether the calling process and user ID has been
		/// granted permission to access a specific URI.  This is basically
		/// the same as calling
		/// <see cref="checkUriPermission(System.Uri, int, int, int)">checkUriPermission(System.Uri, int, int, int)
		/// 	</see>
		/// with the pid and uid returned by
		/// <see cref="android.os.Binder.getCallingPid()">android.os.Binder.getCallingPid()</see>
		/// and
		/// <see cref="android.os.Binder.getCallingUid()">android.os.Binder.getCallingUid()</see>
		/// .  One important difference is
		/// that if you are not currently processing an IPC, this function
		/// will always fail.
		/// </remarks>
		/// <param name="uri">The uri that is being checked.</param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns
		/// <see cref="android.content.pm.PackageManager.PERMISSION_GRANTED">android.content.pm.PackageManager.PERMISSION_GRANTED
		/// 	</see>
		/// if the caller
		/// is allowed to access that uri, or
		/// <see cref="android.content.pm.PackageManager.PERMISSION_DENIED">android.content.pm.PackageManager.PERMISSION_DENIED
		/// 	</see>
		/// if it is not.
		/// </returns>
		/// <seealso cref="checkUriPermission(System.Uri, int, int, int)">checkUriPermission(System.Uri, int, int, int)
		/// 	</seealso>
		public abstract int checkCallingUriPermission(System.Uri uri, int modeFlags);

		/// <summary>
		/// Determine whether the calling process of an IPC <em>or you</em> has been granted
		/// permission to access a specific URI.
		/// </summary>
		/// <remarks>
		/// Determine whether the calling process of an IPC <em>or you</em> has been granted
		/// permission to access a specific URI.  This is the same as
		/// <see cref="checkCallingUriPermission(System.Uri, int)">checkCallingUriPermission(System.Uri, int)
		/// 	</see>
		/// , except it grants your own permissions
		/// if you are not currently processing an IPC.  Use with care!
		/// </remarks>
		/// <param name="uri">The uri that is being checked.</param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns
		/// <see cref="android.content.pm.PackageManager.PERMISSION_GRANTED">android.content.pm.PackageManager.PERMISSION_GRANTED
		/// 	</see>
		/// if the caller
		/// is allowed to access that uri, or
		/// <see cref="android.content.pm.PackageManager.PERMISSION_DENIED">android.content.pm.PackageManager.PERMISSION_DENIED
		/// 	</see>
		/// if it is not.
		/// </returns>
		/// <seealso cref="checkCallingUriPermission(System.Uri, int)">checkCallingUriPermission(System.Uri, int)
		/// 	</seealso>
		public abstract int checkCallingOrSelfUriPermission(System.Uri uri, int modeFlags
			);

		/// <summary>Check both a Uri and normal permission.</summary>
		/// <remarks>
		/// Check both a Uri and normal permission.  This allows you to perform
		/// both
		/// <see cref="checkPermission(string, int, int)">checkPermission(string, int, int)</see>
		/// and
		/// <see cref="checkUriPermission(System.Uri, int, int, int)">checkUriPermission(System.Uri, int, int, int)
		/// 	</see>
		/// in one
		/// call.
		/// </remarks>
		/// <param name="uri">
		/// The Uri whose permission is to be checked, or null to not
		/// do this check.
		/// </param>
		/// <param name="readPermission">
		/// The permission that provides overall read access,
		/// or null to not do this check.
		/// </param>
		/// <param name="writePermission">
		/// The permission that provides overall write
		/// acess, or null to not do this check.
		/// </param>
		/// <param name="pid">The process ID being checked against.  Must be &gt; 0.</param>
		/// <param name="uid">
		/// The user ID being checked against.  A uid of 0 is the root
		/// user, which will pass every permission check.
		/// </param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns
		/// <see cref="android.content.pm.PackageManager.PERMISSION_GRANTED">android.content.pm.PackageManager.PERMISSION_GRANTED
		/// 	</see>
		/// if the caller
		/// is allowed to access that uri or holds one of the given permissions, or
		/// <see cref="android.content.pm.PackageManager.PERMISSION_DENIED">android.content.pm.PackageManager.PERMISSION_DENIED
		/// 	</see>
		/// if it is not.
		/// </returns>
		public abstract int checkUriPermission(System.Uri uri, string readPermission, string
			 writePermission, int pid, int uid, int modeFlags);

		/// <summary>
		/// If a particular process and user ID has not been granted
		/// permission to access a specific URI, throw
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// .  This only checks for permissions that have
		/// been explicitly granted -- if the given process/uid has more
		/// general access to the URI's content provider then this check
		/// will always fail.
		/// </summary>
		/// <param name="uri">The uri that is being checked.</param>
		/// <param name="pid">The process ID being checked against.  Must be &gt; 0.</param>
		/// <param name="uid">
		/// The user ID being checked against.  A uid of 0 is the root
		/// user, which will pass every permission check.
		/// </param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <param name="message">A message to include in the exception if it is thrown.</param>
		/// <seealso cref="checkUriPermission(System.Uri, int, int, int)">checkUriPermission(System.Uri, int, int, int)
		/// 	</seealso>
		public abstract void enforceUriPermission(System.Uri uri, int pid, int uid, int modeFlags
			, string message);

		/// <summary>
		/// If the calling process and user ID has not been granted
		/// permission to access a specific URI, throw
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// .  This is basically the same as calling
		/// <see cref="enforceUriPermission(System.Uri, int, int, int, string)">enforceUriPermission(System.Uri, int, int, int, string)
		/// 	</see>
		/// with
		/// the pid and uid returned by
		/// <see cref="android.os.Binder.getCallingPid()">android.os.Binder.getCallingPid()</see>
		/// and
		/// <see cref="android.os.Binder.getCallingUid()">android.os.Binder.getCallingUid()</see>
		/// .  One important difference is
		/// that if you are not currently processing an IPC, this function
		/// will always throw a SecurityException.
		/// </summary>
		/// <param name="uri">The uri that is being checked.</param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <param name="message">A message to include in the exception if it is thrown.</param>
		/// <seealso cref="checkCallingUriPermission(System.Uri, int)">checkCallingUriPermission(System.Uri, int)
		/// 	</seealso>
		public abstract void enforceCallingUriPermission(System.Uri uri, int modeFlags, string
			 message);

		/// <summary>
		/// If the calling process of an IPC <em>or you</em> has not been
		/// granted permission to access a specific URI, throw
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// .  This is the same as
		/// <see cref="enforceCallingUriPermission(System.Uri, int, string)">enforceCallingUriPermission(System.Uri, int, string)
		/// 	</see>
		/// , except it grants your own
		/// permissions if you are not currently processing an IPC.  Use
		/// with care!
		/// </summary>
		/// <param name="uri">The uri that is being checked.</param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <param name="message">A message to include in the exception if it is thrown.</param>
		/// <seealso cref="checkCallingOrSelfUriPermission(System.Uri, int)">checkCallingOrSelfUriPermission(System.Uri, int)
		/// 	</seealso>
		public abstract void enforceCallingOrSelfUriPermission(System.Uri uri, int modeFlags
			, string message);

		/// <summary>Enforce both a Uri and normal permission.</summary>
		/// <remarks>
		/// Enforce both a Uri and normal permission.  This allows you to perform
		/// both
		/// <see cref="enforcePermission(string, int, int, string)">enforcePermission(string, int, int, string)
		/// 	</see>
		/// and
		/// <see cref="enforceUriPermission(System.Uri, int, int, int, string)">enforceUriPermission(System.Uri, int, int, int, string)
		/// 	</see>
		/// in one
		/// call.
		/// </remarks>
		/// <param name="uri">
		/// The Uri whose permission is to be checked, or null to not
		/// do this check.
		/// </param>
		/// <param name="readPermission">
		/// The permission that provides overall read access,
		/// or null to not do this check.
		/// </param>
		/// <param name="writePermission">
		/// The permission that provides overall write
		/// acess, or null to not do this check.
		/// </param>
		/// <param name="pid">The process ID being checked against.  Must be &gt; 0.</param>
		/// <param name="uid">
		/// The user ID being checked against.  A uid of 0 is the root
		/// user, which will pass every permission check.
		/// </param>
		/// <param name="modeFlags">
		/// The type of access to grant.  May be one or both of
		/// <see cref="Intent.FLAG_GRANT_READ_URI_PERMISSION">Intent.FLAG_GRANT_READ_URI_PERMISSION
		/// 	</see>
		/// or
		/// <see cref="Intent.FLAG_GRANT_WRITE_URI_PERMISSION">Intent.FLAG_GRANT_WRITE_URI_PERMISSION
		/// 	</see>
		/// .
		/// </param>
		/// <param name="message">A message to include in the exception if it is thrown.</param>
		/// <seealso cref="checkUriPermission(System.Uri, string, string, int, int, int)">checkUriPermission(System.Uri, string, string, int, int, int)
		/// 	</seealso>
		public abstract void enforceUriPermission(System.Uri uri, string readPermission, 
			string writePermission, int pid, int uid, int modeFlags, string message);

		/// <summary>
		/// Flag for use with
		/// <see cref="createPackageContext(string, int)">createPackageContext(string, int)</see>
		/// : include the application
		/// code with the context.  This means loading code into the caller's
		/// process, so that
		/// <see cref="getClassLoader()">getClassLoader()</see>
		/// can be used to instantiate
		/// the application's classes.  Setting this flags imposes security
		/// restrictions on what application context you can access; if the
		/// requested application can not be safely loaded into your process,
		/// java.lang.SecurityException will be thrown.  If this flag is not set,
		/// there will be no restrictions on the packages that can be loaded,
		/// but
		/// <see cref="getClassLoader()">getClassLoader()</see>
		/// will always return the default system
		/// class loader.
		/// </summary>
		public const int CONTEXT_INCLUDE_CODE = unchecked((int)(0x00000001));

		/// <summary>
		/// Flag for use with
		/// <see cref="createPackageContext(string, int)">createPackageContext(string, int)</see>
		/// : ignore any security
		/// restrictions on the Context being requested, allowing it to always
		/// be loaded.  For use with
		/// <see cref="CONTEXT_INCLUDE_CODE">CONTEXT_INCLUDE_CODE</see>
		/// to allow code
		/// to be loaded into a process even when it isn't safe to do so.  Use
		/// with extreme care!
		/// </summary>
		public const int CONTEXT_IGNORE_SECURITY = unchecked((int)(0x00000002));

		/// <summary>
		/// Flag for use with
		/// <see cref="createPackageContext(string, int)">createPackageContext(string, int)</see>
		/// : a restricted context may
		/// disable specific features. For instance, a View associated with a restricted
		/// context would ignore particular XML attributes.
		/// </summary>
		public const int CONTEXT_RESTRICTED = unchecked((int)(0x00000004));

		/// <summary>Return a new Context object for the given application name.</summary>
		/// <remarks>
		/// Return a new Context object for the given application name.  This
		/// Context is the same as what the named application gets when it is
		/// launched, containing the same resources and class loader.  Each call to
		/// this method returns a new instance of a Context object; Context objects
		/// are not shared, however they share common state (Resources, ClassLoader,
		/// etc) so the Context instance itself is fairly lightweight.
		/// <p>Throws
		/// <see cref="android.content.pm.PackageManager.NameNotFoundException">android.content.pm.PackageManager.NameNotFoundException
		/// 	</see>
		/// if there is no
		/// application with the given package name.
		/// <p>Throws
		/// <see cref="System.Security.SecurityException">System.Security.SecurityException</see>
		/// if the Context requested
		/// can not be loaded into the caller's process for security reasons (see
		/// <see cref="CONTEXT_INCLUDE_CODE">CONTEXT_INCLUDE_CODE</see>
		/// for more information}.
		/// </remarks>
		/// <param name="packageName">Name of the application's package.</param>
		/// <param name="flags">
		/// Option flags, one of
		/// <see cref="CONTEXT_INCLUDE_CODE">CONTEXT_INCLUDE_CODE</see>
		/// or
		/// <see cref="CONTEXT_IGNORE_SECURITY">CONTEXT_IGNORE_SECURITY</see>
		/// .
		/// </param>
		/// <returns>A Context for the application.</returns>
		/// <exception cref="System.Security.SecurityException">System.Security.SecurityException
		/// 	</exception>
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException">
		/// if there is no application with
		/// the given package name
		/// </exception>
		public abstract android.content.Context createPackageContext(string packageName, 
			int flags);

		/// <summary>Indicates whether this Context is restricted.</summary>
		/// <remarks>Indicates whether this Context is restricted.</remarks>
		/// <returns>True if this Context is restricted, false otherwise.</returns>
		/// <seealso cref="CONTEXT_RESTRICTED">CONTEXT_RESTRICTED</seealso>
		public virtual bool isRestricted()
		{
			return false;
		}
	}
}
