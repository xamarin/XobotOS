using Sharpen;

namespace android.accounts
{
	[Sharpen.Stub]
	public interface IAccountManager : android.os.IInterface
	{
		[Sharpen.Stub]
		string getPassword(android.accounts.Account account);

		[Sharpen.Stub]
		string getUserData(android.accounts.Account account, string key);

		[Sharpen.Stub]
		android.accounts.AuthenticatorDescription[] getAuthenticatorTypes();

		[Sharpen.Stub]
		android.accounts.Account[] getAccounts(string accountType);

		[Sharpen.Stub]
		void hasFeatures(android.accounts.IAccountManagerResponse response, android.accounts.Account
			 account, string[] features);

		[Sharpen.Stub]
		void getAccountsByFeatures(android.accounts.IAccountManagerResponse response, string
			 accountType, string[] features);

		[Sharpen.Stub]
		bool addAccount(android.accounts.Account account, string password, android.os.Bundle
			 extras);

		[Sharpen.Stub]
		void removeAccount(android.accounts.IAccountManagerResponse response, android.accounts.Account
			 account);

		[Sharpen.Stub]
		void invalidateAuthToken(string accountType, string authToken);

		[Sharpen.Stub]
		string peekAuthToken(android.accounts.Account account, string authTokenType);

		[Sharpen.Stub]
		void setAuthToken(android.accounts.Account account, string authTokenType, string 
			authToken);

		[Sharpen.Stub]
		void setPassword(android.accounts.Account account, string password);

		[Sharpen.Stub]
		void clearPassword(android.accounts.Account account);

		[Sharpen.Stub]
		void setUserData(android.accounts.Account account, string key, string value);

		[Sharpen.Stub]
		void getAuthToken(android.accounts.IAccountManagerResponse response, android.accounts.Account
			 account, string authTokenType, bool notifyOnAuthFailure, bool expectActivityLaunch
			, android.os.Bundle options);

		[Sharpen.Stub]
		void addAcount(android.accounts.IAccountManagerResponse response, string accountType
			, string authTokenType, string[] requiredFeatures, bool expectActivityLaunch, android.os.Bundle
			 options);

		[Sharpen.Stub]
		void updateCredentials(android.accounts.IAccountManagerResponse response, android.accounts.Account
			 account, string authTokenType, bool expectActivityLaunch, android.os.Bundle options
			);

		[Sharpen.Stub]
		void editProperties(android.accounts.IAccountManagerResponse response, string accountType
			, bool expectActivityLaunch);

		[Sharpen.Stub]
		void confirmCredentials(android.accounts.IAccountManagerResponse response, android.accounts.Account
			 account, android.os.Bundle options, bool expectActivityLaunch);
	}

	[Sharpen.Stub]
	public static class IAccountManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.accounts.IAccountManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.accounts.IAccountManager asInterface(android.os.IBinder obj
				)
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

			public abstract bool addAccount(android.accounts.Account arg1, string arg2, android.os.Bundle
				 arg3);

			public abstract void addAcount(android.accounts.IAccountManagerResponse arg1, string
				 arg2, string arg3, string[] arg4, bool arg5, android.os.Bundle arg6);

			public abstract void clearPassword(android.accounts.Account arg1);

			public abstract void confirmCredentials(android.accounts.IAccountManagerResponse 
				arg1, android.accounts.Account arg2, android.os.Bundle arg3, bool arg4);

			public abstract void editProperties(android.accounts.IAccountManagerResponse arg1
				, string arg2, bool arg3);

			public abstract android.accounts.Account[] getAccounts(string arg1);

			public abstract void getAccountsByFeatures(android.accounts.IAccountManagerResponse
				 arg1, string arg2, string[] arg3);

			public abstract void getAuthToken(android.accounts.IAccountManagerResponse arg1, 
				android.accounts.Account arg2, string arg3, bool arg4, bool arg5, android.os.Bundle
				 arg6);

			public abstract android.accounts.AuthenticatorDescription[] getAuthenticatorTypes
				();

			public abstract string getPassword(android.accounts.Account arg1);

			public abstract string getUserData(android.accounts.Account arg1, string arg2);

			public abstract void hasFeatures(android.accounts.IAccountManagerResponse arg1, android.accounts.Account
				 arg2, string[] arg3);

			public abstract void invalidateAuthToken(string arg1, string arg2);

			public abstract string peekAuthToken(android.accounts.Account arg1, string arg2);

			public abstract void removeAccount(android.accounts.IAccountManagerResponse arg1, 
				android.accounts.Account arg2);

			public abstract void setAuthToken(android.accounts.Account arg1, string arg2, string
				 arg3);

			public abstract void setPassword(android.accounts.Account arg1, string arg2);

			public abstract void setUserData(android.accounts.Account arg1, string arg2, string
				 arg3);

			public abstract void updateCredentials(android.accounts.IAccountManagerResponse arg1
				, android.accounts.Account arg2, string arg3, bool arg4, android.os.Bundle arg5);
		}
	}
}
