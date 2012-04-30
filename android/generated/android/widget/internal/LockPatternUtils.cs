using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class LockPatternUtils
	{
		internal const string OPTION_ENABLE_FACELOCK = "enable_facelock";

		internal const string TAG = "LockPatternUtils";

		internal const string SYSTEM_DIRECTORY = "/system/";

		internal const string LOCK_PATTERN_FILE = "gesture.key";

		internal const string LOCK_PASSWORD_FILE = "password.key";

		public const int FAILED_ATTEMPTS_BEFORE_TIMEOUT = 5;

		public const int FAILED_ATTEMPTS_BEFORE_RESET = 20;

		public const long FAILED_ATTEMPT_TIMEOUT_MS = 30000L;

		public const long FAILED_ATTEMPT_COUNTDOWN_INTERVAL_MS = 1000L;

		public const int FAILED_ATTEMPTS_BEFORE_WIPE_GRACE = 5;

		public const int MIN_LOCK_PATTERN_SIZE = 4;

		public const int MIN_PATTERN_REGISTER_FAIL = MIN_LOCK_PATTERN_SIZE;

		internal const string LOCKOUT_PERMANENT_KEY = "lockscreen.lockedoutpermanently";

		internal const string LOCKOUT_ATTEMPT_DEADLINE = "lockscreen.lockoutattemptdeadline";

		internal const string PATTERN_EVER_CHOSEN_KEY = "lockscreen.patterneverchosen";

		public const string PASSWORD_TYPE_KEY = "lockscreen.password_type";

		public const string PASSWORD_TYPE_ALTERNATE_KEY = "lockscreen.password_type_alternate";

		internal const string LOCK_PASSWORD_SALT_KEY = "lockscreen.password_salt";

		internal const string DISABLE_LOCKSCREEN_KEY = "lockscreen.disabled";

		internal const string LOCKSCREEN_OPTIONS = "lockscreen.options";

		public const string LOCKSCREEN_BIOMETRIC_WEAK_FALLBACK = "lockscreen.biometric_weak_fallback";

		public const string BIOMETRIC_WEAK_EVER_CHOSEN_KEY = "lockscreen.biometricweakeverchosen";

		internal const string PASSWORD_HISTORY_KEY = "lockscreen.passwordhistory";

		private readonly android.content.Context mContext;

		private readonly android.content.ContentResolver mContentResolver;

		private android.app.admin.DevicePolicyManager mDevicePolicyManager;

		private static string sLockPatternFilename;

		private static string sLockPasswordFilename;

		private static readonly java.util.concurrent.atomic.AtomicBoolean sHaveNonZeroPatternFile
			 = null;

		private static readonly java.util.concurrent.atomic.AtomicBoolean sHaveNonZeroPasswordFile
			 = null;

		private static android.os.FileObserver sPasswordObserver;

		[Sharpen.Stub]
		private class PasswordFileObserver : android.os.FileObserver
		{
			[Sharpen.Stub]
			public PasswordFileObserver(string path, int mask) : base(path, mask)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.FileObserver")]
			public override void onEvent(int @event, string path)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual android.app.admin.DevicePolicyManager getDevicePolicyManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public LockPatternUtils(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedMinimumPasswordLength()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordQuality()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordHistoryLength()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordMinimumLetters()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordMinimumUpperCase()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordMinimumLowerCase()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordMinimumNumeric()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordMinimumSymbols()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedPasswordMinimumNonLetter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reportFailedPasswordAttempt()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reportSuccessfulPasswordAttempt()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool checkPattern(java.util.List<android.widget.@internal.LockPatternView
			.Cell> pattern)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool checkPassword(string password)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool checkPasswordHistory(string password)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool savedPatternExists()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool savedPasswordExists()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPatternEverChosen()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isBiometricWeakEverChosen()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getActivePasswordQuality()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearLock(bool isFallback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLockScreenDisabled(bool disable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isLockScreenDisabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void saveLockPattern(java.util.List<android.widget.@internal.LockPatternView
			.Cell> pattern)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void moveTempGallery()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void deleteTempGallery()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void deleteGallery()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void saveLockPattern(java.util.List<android.widget.@internal.LockPatternView
			.Cell> pattern, bool isFallback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int computePasswordQuality(string password)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateEncryptionPassword(string password)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void saveLockPassword(string password, int quality)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void saveLockPassword(string password, int quality, bool isFallback
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getKeyguardStoredPasswordQuality()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool usingBiometricWeak()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<android.widget.@internal.LockPatternView.Cell> stringToPattern
			(string @string)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string patternToString(java.util.List<android.widget.@internal.LockPatternView
			.Cell> pattern)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static byte[] patternToHash(java.util.List<android.widget.@internal.LockPatternView
			.Cell> pattern)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string getSalt()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual byte[] passwordToHash(string password)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string toHex(byte[] ary)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isLockPasswordEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isLockPatternEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isBiometricWeakInstalled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLockPatternEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isVisiblePatternEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVisiblePatternEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isTactileFeedbackEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTactileFeedbackEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long setLockoutAttemptDeadline()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getLockoutAttemptDeadline()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPermanentlyLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPermanentlyLocked(bool locked)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isEmergencyCallCapable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPukUnlockScreenEnable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getNextAlarm()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool getBoolean(string secureSettingKey)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setBoolean(string secureSettingKey, bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private long getLong(string secureSettingKey, long def)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setLong(string secureSettingKey, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string getString(string secureSettingKey)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setString(string secureSettingKey, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSecure()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateEmergencyCallButtonState(android.widget.Button button, 
			int phoneState, bool showIfCapable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool resumeCall()
		{
			throw new System.NotImplementedException();
		}
	}
}
