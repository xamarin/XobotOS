using System;
using android.content;

namespace android.text.method
{
	partial class TextKeyListener
	{
		private void initPrefs (Context context)
		{
			updatePrefs (null);
			mPrefsInited = true;
		}

		private void updatePrefs (ContentResolver resolver)
		{
			bool cap = false;
			bool text = false;
			bool period = false;
			bool pw = false;
			mPrefs = (cap ? AUTO_CAP : 0) | (text ? AUTO_TEXT : 0) | (period ? AUTO_PERIOD :
				0) | (pw ? SHOW_PASSWORD : 0);
		}

		internal virtual int getPrefs (Context context)
		{
			lock (this) {
				if (!mPrefsInited || mResolver == null || mResolver.get () == null) {
					initPrefs (context);
				}
			}
			return mPrefs;
		}

	}
}

