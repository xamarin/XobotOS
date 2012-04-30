using Sharpen;

namespace android.app.admin
{
	[Sharpen.Stub]
	public interface IDevicePolicyManager : android.os.IInterface
	{
		[Sharpen.Stub]
		void setPasswordQuality(android.content.ComponentName who, int quality);

		[Sharpen.Stub]
		int getPasswordQuality(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordMinimumLength(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordMinimumLength(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordMinimumUpperCase(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordMinimumUpperCase(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordMinimumLowerCase(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordMinimumLowerCase(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordMinimumLetters(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordMinimumLetters(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordMinimumNumeric(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordMinimumNumeric(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordMinimumSymbols(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordMinimumSymbols(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordMinimumNonLetter(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordMinimumNonLetter(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordHistoryLength(android.content.ComponentName who, int length);

		[Sharpen.Stub]
		int getPasswordHistoryLength(android.content.ComponentName who);

		[Sharpen.Stub]
		void setPasswordExpirationTimeout(android.content.ComponentName who, long expiration
			);

		[Sharpen.Stub]
		long getPasswordExpirationTimeout(android.content.ComponentName who);

		[Sharpen.Stub]
		long getPasswordExpiration(android.content.ComponentName who);

		[Sharpen.Stub]
		bool isActivePasswordSufficient();

		[Sharpen.Stub]
		int getCurrentFailedPasswordAttempts();

		[Sharpen.Stub]
		void setMaximumFailedPasswordsForWipe(android.content.ComponentName admin, int num
			);

		[Sharpen.Stub]
		int getMaximumFailedPasswordsForWipe(android.content.ComponentName admin);

		[Sharpen.Stub]
		bool resetPassword(string password, int flags);

		[Sharpen.Stub]
		void setMaximumTimeToLock(android.content.ComponentName who, long timeMs);

		[Sharpen.Stub]
		long getMaximumTimeToLock(android.content.ComponentName who);

		[Sharpen.Stub]
		void lockNow();

		[Sharpen.Stub]
		void wipeData(int flags);

		[Sharpen.Stub]
		android.content.ComponentName setGlobalProxy(android.content.ComponentName admin, 
			string proxySpec, string exclusionList);

		[Sharpen.Stub]
		android.content.ComponentName getGlobalProxyAdmin();

		[Sharpen.Stub]
		int setStorageEncryption(android.content.ComponentName who, bool encrypt);

		[Sharpen.Stub]
		bool getStorageEncryption(android.content.ComponentName who);

		[Sharpen.Stub]
		int getStorageEncryptionStatus();

		[Sharpen.Stub]
		void setCameraDisabled(android.content.ComponentName who, bool disabled);

		[Sharpen.Stub]
		bool getCameraDisabled(android.content.ComponentName who);

		[Sharpen.Stub]
		void setActiveAdmin(android.content.ComponentName policyReceiver, bool refreshing
			);

		[Sharpen.Stub]
		bool isAdminActive(android.content.ComponentName policyReceiver);

		[Sharpen.Stub]
		java.util.List<android.content.ComponentName> getActiveAdmins();

		[Sharpen.Stub]
		bool packageHasActiveAdmins(string packageName);

		[Sharpen.Stub]
		void getRemoveWarning(android.content.ComponentName policyReceiver, android.os.RemoteCallback
			 result);

		[Sharpen.Stub]
		void removeActiveAdmin(android.content.ComponentName policyReceiver);

		[Sharpen.Stub]
		bool hasGrantedPolicy(android.content.ComponentName policyReceiver, int usesPolicy
			);

		[Sharpen.Stub]
		void setActivePasswordState(int quality, int length, int letters, int uppercase, 
			int lowercase, int numbers, int symbols, int nonletter);

		[Sharpen.Stub]
		void reportFailedPasswordAttempt();

		[Sharpen.Stub]
		void reportSuccessfulPasswordAttempt();
	}

	[Sharpen.Stub]
	public static class IDevicePolicyManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.admin.IDevicePolicyManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.admin.IDevicePolicyManager asInterface(android.os.IBinder
				 obj)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				throw new System.NotImplementedException();
			}

			public abstract java.util.List<android.content.ComponentName> getActiveAdmins();

			public abstract bool getCameraDisabled(android.content.ComponentName arg1);

			public abstract int getCurrentFailedPasswordAttempts();

			public abstract android.content.ComponentName getGlobalProxyAdmin();

			public abstract int getMaximumFailedPasswordsForWipe(android.content.ComponentName
				 arg1);

			public abstract long getMaximumTimeToLock(android.content.ComponentName arg1);

			public abstract long getPasswordExpiration(android.content.ComponentName arg1);

			public abstract long getPasswordExpirationTimeout(android.content.ComponentName arg1
				);

			public abstract int getPasswordHistoryLength(android.content.ComponentName arg1);

			public abstract int getPasswordMinimumLength(android.content.ComponentName arg1);

			public abstract int getPasswordMinimumLetters(android.content.ComponentName arg1);

			public abstract int getPasswordMinimumLowerCase(android.content.ComponentName arg1
				);

			public abstract int getPasswordMinimumNonLetter(android.content.ComponentName arg1
				);

			public abstract int getPasswordMinimumNumeric(android.content.ComponentName arg1);

			public abstract int getPasswordMinimumSymbols(android.content.ComponentName arg1);

			public abstract int getPasswordMinimumUpperCase(android.content.ComponentName arg1
				);

			public abstract int getPasswordQuality(android.content.ComponentName arg1);

			public abstract void getRemoveWarning(android.content.ComponentName arg1, android.os.RemoteCallback
				 arg2);

			public abstract bool getStorageEncryption(android.content.ComponentName arg1);

			public abstract int getStorageEncryptionStatus();

			public abstract bool hasGrantedPolicy(android.content.ComponentName arg1, int arg2
				);

			public abstract bool isActivePasswordSufficient();

			public abstract bool isAdminActive(android.content.ComponentName arg1);

			public abstract void lockNow();

			public abstract bool packageHasActiveAdmins(string arg1);

			public abstract void removeActiveAdmin(android.content.ComponentName arg1);

			public abstract void reportFailedPasswordAttempt();

			public abstract void reportSuccessfulPasswordAttempt();

			public abstract bool resetPassword(string arg1, int arg2);

			public abstract void setActiveAdmin(android.content.ComponentName arg1, bool arg2
				);

			public abstract void setActivePasswordState(int arg1, int arg2, int arg3, int arg4
				, int arg5, int arg6, int arg7, int arg8);

			public abstract void setCameraDisabled(android.content.ComponentName arg1, bool arg2
				);

			public abstract android.content.ComponentName setGlobalProxy(android.content.ComponentName
				 arg1, string arg2, string arg3);

			public abstract void setMaximumFailedPasswordsForWipe(android.content.ComponentName
				 arg1, int arg2);

			public abstract void setMaximumTimeToLock(android.content.ComponentName arg1, long
				 arg2);

			public abstract void setPasswordExpirationTimeout(android.content.ComponentName arg1
				, long arg2);

			public abstract void setPasswordHistoryLength(android.content.ComponentName arg1, 
				int arg2);

			public abstract void setPasswordMinimumLength(android.content.ComponentName arg1, 
				int arg2);

			public abstract void setPasswordMinimumLetters(android.content.ComponentName arg1
				, int arg2);

			public abstract void setPasswordMinimumLowerCase(android.content.ComponentName arg1
				, int arg2);

			public abstract void setPasswordMinimumNonLetter(android.content.ComponentName arg1
				, int arg2);

			public abstract void setPasswordMinimumNumeric(android.content.ComponentName arg1
				, int arg2);

			public abstract void setPasswordMinimumSymbols(android.content.ComponentName arg1
				, int arg2);

			public abstract void setPasswordMinimumUpperCase(android.content.ComponentName arg1
				, int arg2);

			public abstract void setPasswordQuality(android.content.ComponentName arg1, int arg2
				);

			public abstract int setStorageEncryption(android.content.ComponentName arg1, bool
				 arg2);

			public abstract void wipeData(int arg1);
		}
	}
}
