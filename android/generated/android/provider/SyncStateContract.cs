using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public class SyncStateContract
	{
		[Sharpen.Stub]
		public interface Columns : android.provider.BaseColumns
		{
		}

		[Sharpen.Stub]
		public static class ColumnsClass
		{
			public const string ACCOUNT_NAME = "account_name";

			public const string ACCOUNT_TYPE = "account_type";

			public const string DATA = "data";
		}

		[Sharpen.Stub]
		public class Constants : android.provider.SyncStateContract.Columns
		{
			public const string CONTENT_DIRECTORY = "syncstate";
		}

		[Sharpen.Stub]
		public sealed class Helpers
		{
			private static readonly string[] DATA_PROJECTION = new string[] { android.provider.SyncStateContract.ColumnsClass.DATA
				, android.provider.BaseColumnsClass._ID };

			private static readonly string SELECT_BY_ACCOUNT = android.provider.SyncStateContract.ColumnsClass.ACCOUNT_NAME
				 + "=? AND " + android.provider.SyncStateContract.ColumnsClass.ACCOUNT_TYPE + "=?";

			[Sharpen.Stub]
			public static byte[] get(android.content.ContentProviderClient provider, System.Uri
				 uri, android.accounts.Account account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void set(android.content.ContentProviderClient provider, System.Uri
				 uri, android.accounts.Account account, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri insert(android.content.ContentProviderClient provider, System.Uri
				 uri, android.accounts.Account account, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void update(android.content.ContentProviderClient provider, System.Uri
				 uri, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.util.Pair<System.Uri, byte[]> getWithUri(android.content.ContentProviderClient
				 provider, System.Uri uri, android.accounts.Account account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ContentProviderOperation newSetOperation(System.Uri
				 uri, android.accounts.Account account, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ContentProviderOperation newUpdateOperation(System.Uri
				 uri, byte[] data)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
