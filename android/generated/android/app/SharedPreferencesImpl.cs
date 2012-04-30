using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	internal sealed class SharedPreferencesImpl : android.content.SharedPreferences
	{
		internal const string TAG = "SharedPreferencesImpl";

		internal const bool DEBUG = false;

		private readonly java.io.File mFile;

		private readonly java.io.File mBackupFile;

		private readonly int mMode;

		private java.util.Map<string, object> mMap;

		private int mDiskWritesInFlight = 0;

		private bool mLoaded = false;

		private long mStatTimestamp;

		private long mStatSize;

		private readonly object mWritingToDiskLock = new object();

		private static readonly object mContent = new object();

		private readonly java.util.WeakHashMap<android.content.SharedPreferencesClass.OnSharedPreferenceChangeListener
			, object> mListeners = new java.util.WeakHashMap<android.content.SharedPreferencesClass
			.OnSharedPreferenceChangeListener, object>();

		[Sharpen.Stub]
		internal SharedPreferencesImpl(java.io.File file, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void startLoadFromDisk()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void loadFromDiskLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static java.io.File makeBackupFile(java.io.File prefsFile)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void startReloadIfChangedUnexpectedly()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool hasFileChangedUnexpectedly()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public void registerOnSharedPreferenceChangeListener(android.content.SharedPreferencesClass
			.OnSharedPreferenceChangeListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public void unregisterOnSharedPreferenceChangeListener(android.content.SharedPreferencesClass
			.OnSharedPreferenceChangeListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void awaitLoadedLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public java.util.Map<string, object> getAll()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public string getString(string key, string defValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public java.util.Set<string> getStringSet(string key, java.util.Set<string> defValues
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public int getInt(string key, int defValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public long getLong(string key, long defValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public float getFloat(string key, float defValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public bool getBoolean(string key, bool defValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public bool contains(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.SharedPreferences")]
		public android.content.SharedPreferencesClass.Editor edit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class MemoryCommitResult
		{
			public bool changesMade;

			public java.util.List<string> keysModified;

			public java.util.Set<android.content.SharedPreferencesClass.OnSharedPreferenceChangeListener
				> listeners;

			internal java.util.Map<object, object> mapToWriteToDisk;

			public readonly java.util.concurrent.CountDownLatch writtenToDiskLatch = null;

			public volatile bool writeToDiskResult = false;

			[Sharpen.Stub]
			public virtual void setDiskWriteResult(bool result)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class EditorImpl : android.content.SharedPreferencesClass.Editor
		{
			private readonly java.util.Map<string, object> mModified;

			private bool mClear;

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor putString(string key, string
				 value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor putStringSet(string key, java.util.Set
				<string> values)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor putInt(string key, int value
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor putLong(string key, long value
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor putFloat(string key, float value
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor putBoolean(string key, bool 
				value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor remove(string key)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public android.content.SharedPreferencesClass.Editor clear()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public void apply()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.app.SharedPreferencesImpl.MemoryCommitResult commitToMemory()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.SharedPreferences.Editor")]
			public bool commit()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void notifyListeners(android.app.SharedPreferencesImpl.MemoryCommitResult
				 mcr)
			{
				throw new System.NotImplementedException();
			}

			public EditorImpl(SharedPreferencesImpl _enclosing)
			{
				this._enclosing = _enclosing;
				mModified = null;
				mClear = false;
			}

			private readonly SharedPreferencesImpl _enclosing;
		}

		[Sharpen.Stub]
		private void enqueueDiskWrite(android.app.SharedPreferencesImpl.MemoryCommitResult
			 mcr, java.lang.Runnable postWriteRunnable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static java.io.FileOutputStream createFileOutputStream(java.io.File file)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writeToFile(android.app.SharedPreferencesImpl.MemoryCommitResult mcr
			)
		{
			throw new System.NotImplementedException();
		}
	}
}
