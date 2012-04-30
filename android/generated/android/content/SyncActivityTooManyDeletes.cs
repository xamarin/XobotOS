using Sharpen;

namespace android.content
{
	/// <summary>
	/// Presents multiple options for handling the case where a sync was aborted because there
	/// were too many pending deletes.
	/// </summary>
	/// <remarks>
	/// Presents multiple options for handling the case where a sync was aborted because there
	/// were too many pending deletes. One option is to force the delete, another is to rollback
	/// the deletes, the third is to do nothing.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class SyncActivityTooManyDeletes : android.app.Activity, android.widget.AdapterView
		.OnItemClickListener
	{
		private long mNumDeletes;

		private android.accounts.Account mAccount;

		private string mAuthority;

		private string mProvider;

		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onCreate(android.os.Bundle savedInstanceState)
		{
			base.onCreate(savedInstanceState);
			android.os.Bundle extras = getIntent().getExtras();
			if (extras == null)
			{
				finish();
				return;
			}
			mNumDeletes = extras.getLong("numDeletes");
			mAccount = (android.accounts.Account)extras.getParcelable("account");
			mAuthority = extras.getString("authority");
			mProvider = extras.getString("provider");
			// the order of these must match up with the constants for position used in onItemClick
			java.lang.CharSequence[] options = new java.lang.CharSequence[] { getResources().
				getText(android.@internal.R.@string.sync_really_delete), getResources().getText(
				android.@internal.R.@string.sync_undo_deletes), getResources().getText(android.@internal.R
				.@string.sync_do_nothing) };
			android.widget.ListAdapter adapter = new android.widget.ArrayAdapter<java.lang.CharSequence
				>(this, android.R.layout.simple_list_item_1, android.R.id.text1, options);
			android.widget.ListView listView = new android.widget.ListView(this);
			listView.setAdapter(adapter);
			listView.setItemsCanFocus(true);
			listView.setOnItemClickListener(this);
			android.widget.TextView textView = new android.widget.TextView(this);
			java.lang.CharSequence tooManyDeletesDescFormat = getResources().getText(android.@internal.R
				.@string.sync_too_many_deletes_desc);
			textView.setText(java.lang.CharSequenceProxy.Wrap(string.Format(tooManyDeletesDescFormat
				.ToString(), mNumDeletes, mProvider, mAccount.name)));
			android.widget.LinearLayout ll = new android.widget.LinearLayout(this);
			ll.setOrientation(android.widget.LinearLayout.VERTICAL);
			android.widget.LinearLayout.LayoutParams lp = new android.widget.LinearLayout.LayoutParams
				(android.view.ViewGroup.LayoutParams.MATCH_PARENT, android.view.ViewGroup.LayoutParams
				.WRAP_CONTENT, 0);
			ll.addView(textView, lp);
			ll.addView(listView, lp);
			// TODO: consider displaying the icon of the account type
			//        AuthenticatorDescription[] descs = AccountManager.get(this).getAuthenticatorTypes();
			//        for (AuthenticatorDescription desc : descs) {
			//            if (desc.type.equals(mAccount.type)) {
			//                try {
			//                    final Context authContext = createPackageContext(desc.packageName, 0);
			//                    ImageView imageView = new ImageView(this);
			//                    imageView.setImageDrawable(authContext.getResources().getDrawable(desc.iconId));
			//                    ll.addView(imageView, lp);
			//                } catch (PackageManager.NameNotFoundException e) {
			//                }
			//                break;
			//            }
			//        }
			setContentView(ll);
		}

		[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
		public virtual void onItemClick(object parent, android.view.View view, int position
			, long id)
		{
			// the constants for position correspond to the items options array in onCreate()
			if (position == 0)
			{
				startSyncReallyDelete();
			}
			else
			{
				if (position == 1)
				{
					startSyncUndoDeletes();
				}
			}
			finish();
		}

		private void startSyncReallyDelete()
		{
			android.os.Bundle extras = new android.os.Bundle();
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_OVERRIDE_TOO_MANY_DELETIONS
				, true);
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_MANUAL, true);
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_EXPEDITED, true);
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_UPLOAD, true);
			android.content.ContentResolver.requestSync(mAccount, mAuthority, extras);
		}

		private void startSyncUndoDeletes()
		{
			android.os.Bundle extras = new android.os.Bundle();
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_DISCARD_LOCAL_DELETIONS
				, true);
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_MANUAL, true);
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_EXPEDITED, true);
			extras.putBoolean(android.content.ContentResolver.SYNC_EXTRAS_UPLOAD, true);
			android.content.ContentResolver.requestSync(mAccount, mAuthority, extras);
		}
	}
}
