using Sharpen;

namespace android.app.admin
{
	[Sharpen.Stub]
	public class DevicePolicyManager
	{
		[Sharpen.Stub]
		public static android.app.admin.DevicePolicyManager create(android.content.Context
			 context, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isAdminActive(android.content.ComponentName who)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.content.ComponentName> getActiveAdmins()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool packageHasActiveAdmins(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeActiveAdmin(android.content.ComponentName who)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasGrantedPolicy(android.content.ComponentName admin, int usesPolicy
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordQuality(android.content.ComponentName admin, int quality
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordQuality(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordMinimumLength(android.content.ComponentName admin, 
			int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMinimumLength(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordMinimumUpperCase(android.content.ComponentName admin
			, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMinimumUpperCase(android.content.ComponentName admin
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordMinimumLowerCase(android.content.ComponentName admin
			, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMinimumLowerCase(android.content.ComponentName admin
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordMinimumLetters(android.content.ComponentName admin
			, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMinimumLetters(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordMinimumNumeric(android.content.ComponentName admin
			, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMinimumNumeric(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordMinimumSymbols(android.content.ComponentName admin
			, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMinimumSymbols(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordMinimumNonLetter(android.content.ComponentName admin
			, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMinimumNonLetter(android.content.ComponentName admin
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordHistoryLength(android.content.ComponentName admin, 
			int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPasswordExpirationTimeout(android.content.ComponentName admin
			, long timeout)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getPasswordExpirationTimeout(android.content.ComponentName admin
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getPasswordExpiration(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordHistoryLength(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getPasswordMaximumLength(int quality)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isActivePasswordSufficient()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getCurrentFailedPasswordAttempts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMaximumFailedPasswordsForWipe(android.content.ComponentName
			 admin, int num)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMaximumFailedPasswordsForWipe(android.content.ComponentName
			 admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool resetPassword(string password, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMaximumTimeToLock(android.content.ComponentName admin, long
			 timeMs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getMaximumTimeToLock(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void lockNow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void wipeData(int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ComponentName setGlobalProxy(android.content.ComponentName
			 admin, java.net.Proxy proxySpec, java.util.List<string> exclusionList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ComponentName getGlobalProxyAdmin()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int setStorageEncryption(android.content.ComponentName admin, bool
			 encrypt)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getStorageEncryption(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getStorageEncryptionStatus()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCameraDisabled(android.content.ComponentName admin, bool disabled
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getCameraDisabled(android.content.ComponentName admin)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setActiveAdmin(android.content.ComponentName policyReceiver, 
			bool refreshing)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.admin.DeviceAdminInfo getAdminInfo(android.content.ComponentName
			 cn)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void getRemoveWarning(android.content.ComponentName admin, android.os.RemoteCallback
			 result)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setActivePasswordState(int quality, int length, int letters, 
			int uppercase, int lowercase, int numbers, int symbols, int nonletter)
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
	}
}
