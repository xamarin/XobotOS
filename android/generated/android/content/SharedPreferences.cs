using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface SharedPreferences
	{
		[Sharpen.Stub]
		java.util.Map<string, object> getAll();

		[Sharpen.Stub]
		string getString(string key, string defValue);

		[Sharpen.Stub]
		java.util.Set<string> getStringSet(string key, java.util.Set<string> defValues);

		[Sharpen.Stub]
		int getInt(string key, int defValue);

		[Sharpen.Stub]
		long getLong(string key, long defValue);

		[Sharpen.Stub]
		float getFloat(string key, float defValue);

		[Sharpen.Stub]
		bool getBoolean(string key, bool defValue);

		[Sharpen.Stub]
		bool contains(string key);

		[Sharpen.Stub]
		android.content.SharedPreferencesClass.Editor edit();

		[Sharpen.Stub]
		void registerOnSharedPreferenceChangeListener(android.content.SharedPreferencesClass
			.OnSharedPreferenceChangeListener listener);

		[Sharpen.Stub]
		void unregisterOnSharedPreferenceChangeListener(android.content.SharedPreferencesClass
			.OnSharedPreferenceChangeListener listener);
	}

	[Sharpen.Stub]
	public static class SharedPreferencesClass
	{
		[Sharpen.Stub]
		public interface OnSharedPreferenceChangeListener
		{
			[Sharpen.Stub]
			void onSharedPreferenceChanged(android.content.SharedPreferences sharedPreferences
				, string key);
		}

		[Sharpen.Stub]
		public interface Editor
		{
			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor putString(string key, string value);

			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor putStringSet(string key, java.util.Set
				<string> values);

			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor putInt(string key, int value);

			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor putLong(string key, long value);

			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor putFloat(string key, float value);

			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor putBoolean(string key, bool value);

			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor remove(string key);

			[Sharpen.Stub]
			android.content.SharedPreferencesClass.Editor clear();

			[Sharpen.Stub]
			bool commit();

			[Sharpen.Stub]
			void apply();
		}
	}
}
