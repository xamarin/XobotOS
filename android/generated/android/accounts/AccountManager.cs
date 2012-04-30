using Sharpen;

namespace android.accounts
{
	[Sharpen.Stub]
	public class AccountManager
	{
		[Sharpen.Stub]
		public AccountManager(android.content.Context context, android.accounts.IAccountManager
			 service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public AccountManager(android.content.Context context, android.accounts.IAccountManager
			 service, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.Bundle sanitizeResult(android.os.Bundle result)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.accounts.AccountManager get(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getPassword(android.accounts.Account account)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getUserData(android.accounts.Account account, string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AuthenticatorDescription[] getAuthenticatorTypes(
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.Account[] getAccounts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.Account[] getAccountsByType(string type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<bool> hasFeatures(android.accounts.Account
			 account, string[] features, android.accounts.AccountManagerCallback<bool> callback
			, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.accounts.Account[]> 
			getAccountsByTypeAndFeatures(string type, string[] features, android.accounts.AccountManagerCallback
			<android.accounts.Account[]> callback, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool addAccountExplicitly(android.accounts.Account account, string
			 password, android.os.Bundle userdata)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<bool> removeAccount(android.accounts.Account
			 account, android.accounts.AccountManagerCallback<bool> callback, android.os.Handler
			 handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void invalidateAuthToken(string accountType, string authToken)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string peekAuthToken(android.accounts.Account account, string authTokenType
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPassword(android.accounts.Account account, string password
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearPassword(android.accounts.Account account)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setUserData(android.accounts.Account account, string key, string
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAuthToken(android.accounts.Account account, string authTokenType
			, string authToken)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string blockingGetAuthToken(android.accounts.Account account, string
			 authTokenType, bool notifyAuthFailure)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> getAuthToken
			(android.accounts.Account account, string authTokenType, android.os.Bundle options
			, android.app.Activity activity, android.accounts.AccountManagerCallback<android.os.Bundle
			> callback, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use getAuthToken(Account, string, android.os.Bundle, bool, AccountManagerCallback{V}, android.os.Handler) instead"
			)]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> getAuthToken
			(android.accounts.Account account, string authTokenType, bool notifyAuthFailure, 
			android.accounts.AccountManagerCallback<android.os.Bundle> callback, android.os.Handler
			 handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> getAuthToken
			(android.accounts.Account account, string authTokenType, android.os.Bundle options
			, bool notifyAuthFailure, android.accounts.AccountManagerCallback<android.os.Bundle
			> callback, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> addAccount
			(string accountType, string authTokenType, string[] requiredFeatures, android.os.Bundle
			 addAccountOptions, android.app.Activity activity, android.accounts.AccountManagerCallback
			<android.os.Bundle> callback, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> confirmCredentials
			(android.accounts.Account account, android.os.Bundle options, android.app.Activity
			 activity, android.accounts.AccountManagerCallback<android.os.Bundle> callback, 
			android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> updateCredentials
			(android.accounts.Account account, string authTokenType, android.os.Bundle options
			, android.app.Activity activity, android.accounts.AccountManagerCallback<android.os.Bundle
			> callback, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> editProperties
			(string accountType, android.app.Activity activity, android.accounts.AccountManagerCallback
			<android.os.Bundle> callback, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.accounts.AccountManagerFuture<android.os.Bundle> getAuthTokenByFeatures
			(string accountType, string authTokenType, string[] features, android.app.Activity
			 activity, android.os.Bundle addAccountOptions, android.os.Bundle getAuthTokenOptions
			, android.accounts.AccountManagerCallback<android.os.Bundle> callback, android.os.Handler
			 handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.Intent newChooseAccountIntent(android.accounts.Account
			 selectedAccount, java.util.ArrayList<android.accounts.Account> allowableAccounts
			, string[] allowableAccountTypes, bool alwaysPromptForAccount, string descriptionOverrideText
			, string addAccountAuthTokenType, string[] addAccountRequiredFeatures, android.os.Bundle
			 addAccountOptions)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addOnAccountsUpdatedListener(android.accounts.OnAccountsUpdateListener
			 listener, android.os.Handler handler, bool updateImmediately)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeOnAccountsUpdatedListener(android.accounts.OnAccountsUpdateListener
			 listener)
		{
			throw new System.NotImplementedException();
		}
	}
}
