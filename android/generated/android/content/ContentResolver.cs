using Sharpen;

namespace android.content
{
	/// <summary>This class provides applications access to the content model.</summary>
	/// <remarks>
	/// This class provides applications access to the content model.
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about using a ContentResolver with content providers, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/providers/content-providers.html"&gt;Content Providers</a>
	/// developer guide.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class ContentResolver
	{
		[System.ObsoleteAttribute(@"instead userequestSync(android.accounts.Account, string, android.os.Bundle)"
			)]
		public const string SYNC_EXTRAS_ACCOUNT = "account";

		public const string SYNC_EXTRAS_EXPEDITED = "expedited";

		[System.ObsoleteAttribute(@"instead useSYNC_EXTRAS_MANUAL")]
		public const string SYNC_EXTRAS_FORCE = "force";

		/// <summary>
		/// If this extra is set to true then the sync settings (like getSyncAutomatically())
		/// are ignored by the sync scheduler.
		/// </summary>
		/// <remarks>
		/// If this extra is set to true then the sync settings (like getSyncAutomatically())
		/// are ignored by the sync scheduler.
		/// </remarks>
		public const string SYNC_EXTRAS_IGNORE_SETTINGS = "ignore_settings";

		/// <summary>If this extra is set to true then any backoffs for the initial attempt (e.g.
		/// 	</summary>
		/// <remarks>
		/// If this extra is set to true then any backoffs for the initial attempt (e.g. due to retries)
		/// are ignored by the sync scheduler. If this request fails and gets rescheduled then the
		/// retries will still honor the backoff.
		/// </remarks>
		public const string SYNC_EXTRAS_IGNORE_BACKOFF = "ignore_backoff";

		/// <summary>If this extra is set to true then the request will not be retried if it fails.
		/// 	</summary>
		/// <remarks>If this extra is set to true then the request will not be retried if it fails.
		/// 	</remarks>
		public const string SYNC_EXTRAS_DO_NOT_RETRY = "do_not_retry";

		/// <summary>
		/// Setting this extra is the equivalent of setting both
		/// <see cref="SYNC_EXTRAS_IGNORE_SETTINGS">SYNC_EXTRAS_IGNORE_SETTINGS</see>
		/// and
		/// <see cref="SYNC_EXTRAS_IGNORE_BACKOFF">SYNC_EXTRAS_IGNORE_BACKOFF</see>
		/// </summary>
		public const string SYNC_EXTRAS_MANUAL = "force";

		public const string SYNC_EXTRAS_UPLOAD = "upload";

		public const string SYNC_EXTRAS_OVERRIDE_TOO_MANY_DELETIONS = "deletions_override";

		public const string SYNC_EXTRAS_DISCARD_LOCAL_DELETIONS = "discard_deletions";

		/// <summary>
		/// Set by the SyncManager to request that the SyncAdapter initialize itself for
		/// the given account/authority pair.
		/// </summary>
		/// <remarks>
		/// Set by the SyncManager to request that the SyncAdapter initialize itself for
		/// the given account/authority pair. One required initialization step is to
		/// ensure that
		/// <see cref="setIsSyncable(android.accounts.Account, string, int)">setIsSyncable(android.accounts.Account, string, int)
		/// 	</see>
		/// has been
		/// called with a &gt;= 0 value. When this flag is set the SyncAdapter does not need to
		/// do a full sync, though it is allowed to do so.
		/// </remarks>
		public const string SYNC_EXTRAS_INITIALIZE = "initialize";

		public const string SCHEME_CONTENT = "content";

		public const string SCHEME_ANDROID_RESOURCE = "android.resource";

		public const string SCHEME_FILE = "file";

		/// <summary>
		/// This is the Android platform's base MIME type for a content: URI
		/// containing a Cursor of a single item.
		/// </summary>
		/// <remarks>
		/// This is the Android platform's base MIME type for a content: URI
		/// containing a Cursor of a single item.  Applications should use this
		/// as the base type along with their own sub-type of their content: URIs
		/// that represent a particular item.  For example, hypothetical IMAP email
		/// client may have a URI
		/// <code>content://com.company.provider.imap/inbox/1</code> for a particular
		/// message in the inbox, whose MIME type would be reported as
		/// <code>CURSOR_ITEM_BASE_TYPE + "/vnd.company.imap-msg"</code>
		/// <p>Compare with
		/// <see cref="CURSOR_DIR_BASE_TYPE">CURSOR_DIR_BASE_TYPE</see>
		/// .
		/// </remarks>
		public const string CURSOR_ITEM_BASE_TYPE = "vnd.android.cursor.item";

		/// <summary>
		/// This is the Android platform's base MIME type for a content: URI
		/// containing a Cursor of zero or more items.
		/// </summary>
		/// <remarks>
		/// This is the Android platform's base MIME type for a content: URI
		/// containing a Cursor of zero or more items.  Applications should use this
		/// as the base type along with their own sub-type of their content: URIs
		/// that represent a directory of items.  For example, hypothetical IMAP email
		/// client may have a URI
		/// <code>content://com.company.provider.imap/inbox</code> for all of the
		/// messages in its inbox, whose MIME type would be reported as
		/// <code>CURSOR_DIR_BASE_TYPE + "/vnd.company.imap-msg"</code>
		/// <p>Note how the base MIME type varies between this and
		/// <see cref="CURSOR_ITEM_BASE_TYPE">CURSOR_ITEM_BASE_TYPE</see>
		/// depending on whether there is
		/// one single item or multiple items in the data set, while the sub-type
		/// remains the same because in either case the data structure contained
		/// in the cursor is the same.
		/// </remarks>
		public const string CURSOR_DIR_BASE_TYPE = "vnd.android.cursor.dir";

		/// <hide></hide>
		public const int SYNC_ERROR_SYNC_ALREADY_IN_PROGRESS = 1;

		/// <hide></hide>
		public const int SYNC_ERROR_AUTHENTICATION = 2;

		/// <hide></hide>
		public const int SYNC_ERROR_IO = 3;

		/// <hide></hide>
		public const int SYNC_ERROR_PARSE = 4;

		/// <hide></hide>
		public const int SYNC_ERROR_CONFLICT = 5;

		/// <hide></hide>
		public const int SYNC_ERROR_TOO_MANY_DELETIONS = 6;

		/// <hide></hide>
		public const int SYNC_ERROR_TOO_MANY_RETRIES = 7;

		/// <hide></hide>
		public const int SYNC_ERROR_INTERNAL = 8;

		public const int SYNC_OBSERVER_TYPE_SETTINGS = 1 << 0;

		public const int SYNC_OBSERVER_TYPE_PENDING = 1 << 1;

		public const int SYNC_OBSERVER_TYPE_ACTIVE = 1 << 2;

		/// <hide></hide>
		public const int SYNC_OBSERVER_TYPE_STATUS = 1 << 3;

		/// <hide></hide>
		public const int SYNC_OBSERVER_TYPE_ALL = unchecked((int)(0x7fffffff));

		internal const int SLOW_THRESHOLD_MILLIS = 500;

		private readonly System.Random mRandom = new System.Random();

		public ContentResolver(android.content.Context context)
		{
			// Always log queries which take 500ms+; shorter queries are
			// sampled accordingly.
			// guarded by itself
			mContext = context;
		}

		[Sharpen.Stub]
		protected internal abstract android.content.IContentProvider acquireProvider(android.content.Context
			 c, string name);

		[Sharpen.Stub]
		protected internal virtual android.content.IContentProvider acquireExistingProvider
			(android.content.Context c, string name)
		{
			throw new System.NotImplementedException();
		}

		/// <hide></hide>
		public abstract bool releaseProvider(android.content.IContentProvider icp);

		/// <summary>Return the MIME type of the given content URL.</summary>
		/// <remarks>Return the MIME type of the given content URL.</remarks>
		/// <param name="url">
		/// A Uri identifying content (either a list or specific type),
		/// using the content:// scheme.
		/// </param>
		/// <returns>A MIME type for the content, or null if the URL is invalid or the type is unknown
		/// 	</returns>
		public string getType(System.Uri url)
		{
			android.content.IContentProvider provider = acquireExistingProvider(url);
			if (provider != null)
			{
				try
				{
					return provider.getType(url);
				}
				catch (android.os.RemoteException)
				{
					return null;
				}
				catch (System.Exception e)
				{
					android.util.Log.w(TAG, "Failed to get type for: " + url + " (" + e.Message + ")"
						);
					return null;
				}
				finally
				{
					releaseProvider(provider);
				}
			}
			if (!SCHEME_CONTENT.Equals(url.Scheme))
			{
				return null;
			}
			try
			{
				string type = android.app.ActivityManagerNative.getDefault().getProviderMimeType(
					url);
				return type;
			}
			catch (android.os.RemoteException)
			{
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return null;
			}
			catch (System.Exception e)
			{
				android.util.Log.w(TAG, "Failed to get type for: " + url + " (" + e.Message + ")"
					);
				return null;
			}
		}

		/// <summary>
		/// Query for the possible MIME types for the representations the given
		/// content URL can be returned when opened as as stream with
		/// <see cref="openTypedAssetFileDescriptor(System.Uri, string, android.os.Bundle)">openTypedAssetFileDescriptor(System.Uri, string, android.os.Bundle)
		/// 	</see>
		/// .  Note that the types here are
		/// not necessarily a superset of the type returned by
		/// <see cref="getType(System.Uri)">getType(System.Uri)</see>
		/// --
		/// many content providers can not return a raw stream for the structured
		/// data that they contain.
		/// </summary>
		/// <param name="url">
		/// A Uri identifying content (either a list or specific type),
		/// using the content:// scheme.
		/// </param>
		/// <param name="mimeTypeFilter">
		/// The desired MIME type.  This may be a pattern,
		/// such as *\/*, to query for all available MIME types that match the
		/// pattern.
		/// </param>
		/// <returns>
		/// Returns an array of MIME type strings for all availablle
		/// data streams that match the given mimeTypeFilter.  If there are none,
		/// null is returned.
		/// </returns>
		public virtual string[] getStreamTypes(System.Uri url, string mimeTypeFilter)
		{
			android.content.IContentProvider provider = acquireProvider(url);
			if (provider == null)
			{
				return null;
			}
			try
			{
				return provider.getStreamTypes(url, mimeTypeFilter);
			}
			catch (android.os.RemoteException)
			{
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return null;
			}
			finally
			{
				releaseProvider(provider);
			}
		}

		/// <summary>
		/// <p>
		/// Query the given URI, returning a
		/// <see cref="android.database.Cursor">android.database.Cursor</see>
		/// over the result set.
		/// </p>
		/// <p>
		/// For best performance, the caller should follow these guidelines:
		/// <ul>
		/// <li>Provide an explicit projection, to prevent
		/// reading data from storage that aren't going to be used.</li>
		/// <li>Use question mark parameter markers such as 'phone=?' instead of
		/// explicit values in the
		/// <code>selection</code>
		/// parameter, so that queries
		/// that differ only by those values will be recognized as the same
		/// for caching purposes.</li>
		/// </ul>
		/// </p>
		/// </summary>
		/// <param name="uri">
		/// The URI, using the content:// scheme, for the content to
		/// retrieve.
		/// </param>
		/// <param name="projection">
		/// A list of which columns to return. Passing null will
		/// return all columns, which is inefficient.
		/// </param>
		/// <param name="selection">
		/// A filter declaring which rows to return, formatted as an
		/// SQL WHERE clause (excluding the WHERE itself). Passing null will
		/// return all rows for the given URI.
		/// </param>
		/// <param name="selectionArgs">
		/// You may include ?s in selection, which will be
		/// replaced by the values from selectionArgs, in the order that they
		/// appear in the selection. The values will be bound as Strings.
		/// </param>
		/// <param name="sortOrder">
		/// How to order the rows, formatted as an SQL ORDER BY
		/// clause (excluding the ORDER BY itself). Passing null will use the
		/// default sort order, which may be unordered.
		/// </param>
		/// <returns>A Cursor object, which is positioned before the first entry, or null</returns>
		/// <seealso cref="android.database.Cursor">android.database.Cursor</seealso>
		public android.database.Cursor query(System.Uri uri, string[] projection, string 
			selection, string[] selectionArgs, string sortOrder)
		{
			android.content.IContentProvider provider = acquireProvider(uri);
			if (provider == null)
			{
				return null;
			}
			try
			{
				long startTime = android.os.SystemClock.uptimeMillis();
				android.database.Cursor qCursor = provider.query(uri, projection, selection, selectionArgs
					, sortOrder);
				if (qCursor == null)
				{
					releaseProvider(provider);
					return null;
				}
				// force query execution
				qCursor.getCount();
				long durationMillis = android.os.SystemClock.uptimeMillis() - startTime;
				maybeLogQueryToEventLog(durationMillis, uri, projection, selection, sortOrder);
				// Wrap the cursor object into CursorWrapperInner object
				return new android.content.ContentResolver.CursorWrapperInner(this, qCursor, provider
					);
			}
			catch (android.os.RemoteException)
			{
				releaseProvider(provider);
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return null;
			}
			catch (java.lang.RuntimeException e)
			{
				releaseProvider(provider);
				throw;
			}
		}

		[Sharpen.Stub]
		public java.io.InputStream openInputStream(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		// Note: left here to avoid breaking compatibility.  May be removed
		// with sufficient testing.
		// Note: left here to avoid breaking compatibility.  May be removed
		// with sufficient testing.
		/// <summary>
		/// Synonym for
		/// <see cref="openOutputStream(System.Uri, string)">openOutputStream(uri, "w")</see>
		/// .
		/// </summary>
		/// <exception cref="java.io.FileNotFoundException">if the provided URI could not be opened.
		/// 	</exception>
		public java.io.OutputStream openOutputStream(System.Uri uri)
		{
			return openOutputStream(uri, "w");
		}

		/// <summary>Open a stream on to the content associated with a content URI.</summary>
		/// <remarks>
		/// Open a stream on to the content associated with a content URI.  If there
		/// is no data associated with the URI, FileNotFoundException is thrown.
		/// <h5>Accepts the following URI schemes:</h5>
		/// <ul>
		/// <li>content (
		/// <see cref="SCHEME_CONTENT">SCHEME_CONTENT</see>
		/// )</li>
		/// <li>file (
		/// <see cref="SCHEME_FILE">SCHEME_FILE</see>
		/// )</li>
		/// </ul>
		/// <p>See
		/// <see cref="openAssetFileDescriptor(System.Uri, string)">openAssetFileDescriptor(System.Uri, string)
		/// 	</see>
		/// for more information
		/// on these schemes.
		/// </remarks>
		/// <param name="uri">The desired URI.</param>
		/// <param name="mode">May be "w", "wa", "rw", or "rwt".</param>
		/// <returns>OutputStream</returns>
		/// <exception cref="java.io.FileNotFoundException">if the provided URI could not be opened.
		/// 	</exception>
		/// <seealso cref="openAssetFileDescriptor(System.Uri, string)">openAssetFileDescriptor(System.Uri, string)
		/// 	</seealso>
		public java.io.OutputStream openOutputStream(System.Uri uri, string mode)
		{
			android.content.res.AssetFileDescriptor fd = openAssetFileDescriptor(uri, mode);
			try
			{
				return fd != null ? fd.createOutputStream() : null;
			}
			catch (System.IO.IOException)
			{
				throw new java.io.FileNotFoundException("Unable to create stream");
			}
		}

		/// <summary>Open a raw file descriptor to access data under a URI.</summary>
		/// <remarks>
		/// Open a raw file descriptor to access data under a URI.  This
		/// is like
		/// <see cref="openAssetFileDescriptor(System.Uri, string)">openAssetFileDescriptor(System.Uri, string)
		/// 	</see>
		/// , but uses the
		/// underlying
		/// <see cref="ContentProvider.openFile(System.Uri, string)">ContentProvider.openFile(System.Uri, string)
		/// 	</see>
		/// ContentProvider.openFile()} method, so will <em>not</em> work with
		/// providers that return sub-sections of files.  If at all possible,
		/// you should use
		/// <see cref="openAssetFileDescriptor(System.Uri, string)">openAssetFileDescriptor(System.Uri, string)
		/// 	</see>
		/// .  You
		/// will receive a FileNotFoundException exception if the provider returns a
		/// sub-section of a file.
		/// <h5>Accepts the following URI schemes:</h5>
		/// <ul>
		/// <li>content (
		/// <see cref="SCHEME_CONTENT">SCHEME_CONTENT</see>
		/// )</li>
		/// <li>file (
		/// <see cref="SCHEME_FILE">SCHEME_FILE</see>
		/// )</li>
		/// </ul>
		/// <p>See
		/// <see cref="openAssetFileDescriptor(System.Uri, string)">openAssetFileDescriptor(System.Uri, string)
		/// 	</see>
		/// for more information
		/// on these schemes.
		/// </remarks>
		/// <param name="uri">The desired URI to open.</param>
		/// <param name="mode">
		/// The file mode to use, as per
		/// <see cref="ContentProvider.openFile(System.Uri, string)">ContentProvider.openFile
		/// 	</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns a new ParcelFileDescriptor pointing to the file.  You
		/// own this descriptor and are responsible for closing it when done.
		/// </returns>
		/// <exception cref="java.io.FileNotFoundException">
		/// Throws FileNotFoundException of no
		/// file exists under the URI or the mode is invalid.
		/// </exception>
		/// <seealso cref="openAssetFileDescriptor(System.Uri, string)">openAssetFileDescriptor(System.Uri, string)
		/// 	</seealso>
		public android.os.ParcelFileDescriptor openFileDescriptor(System.Uri uri, string 
			mode)
		{
			android.content.res.AssetFileDescriptor afd = openAssetFileDescriptor(uri, mode);
			if (afd == null)
			{
				return null;
			}
			if (afd.getDeclaredLength() < 0)
			{
				// This is a full file!
				return afd.getParcelFileDescriptor();
			}
			// Client can't handle a sub-section of a file, so close what
			// we got and bail with an exception.
			try
			{
				afd.close();
			}
			catch (System.IO.IOException)
			{
			}
			throw new java.io.FileNotFoundException("Not a whole file");
		}

		[Sharpen.Stub]
		public android.content.res.AssetFileDescriptor openAssetFileDescriptor(System.Uri
			 uri, string mode)
		{
			throw new System.NotImplementedException();
		}

		// The provider will be released by the finally{} clause
		// Success!  Don't release the provider when exiting, let
		// ParcelFileDescriptorInner do that when it is closed.
		// Somewhat pointless, as Activity Manager will kill this
		// process shortly anyway if the depdendent ContentProvider dies.
		/// <summary>
		/// Open a raw file descriptor to access (potentially type transformed)
		/// data from a "content:" URI.
		/// </summary>
		/// <remarks>
		/// Open a raw file descriptor to access (potentially type transformed)
		/// data from a "content:" URI.  This interacts with the underlying
		/// <see cref="ContentProvider.openTypedAssetFile(System.Uri, string, android.os.Bundle)
		/// 	">ContentProvider.openTypedAssetFile(System.Uri, string, android.os.Bundle)</see>
		/// method of the provider
		/// associated with the given URI, to retrieve retrieve any appropriate
		/// data stream for the data stored there.
		/// <p>Unlike
		/// <see cref="openAssetFileDescriptor(System.Uri, string)">openAssetFileDescriptor(System.Uri, string)
		/// 	</see>
		/// , this function only works
		/// with "content:" URIs, because content providers are the only facility
		/// with an associated MIME type to ensure that the returned data stream
		/// is of the desired type.
		/// <p>All text/* streams are encoded in UTF-8.
		/// </remarks>
		/// <param name="uri">The desired URI to open.</param>
		/// <param name="mimeType">
		/// The desired MIME type of the returned data.  This can
		/// be a pattern such as *\/*, which will allow the content provider to
		/// select a type, though there is no way for you to determine what type
		/// it is returning.
		/// </param>
		/// <param name="opts">Additional provider-dependent options.</param>
		/// <returns>
		/// Returns a new ParcelFileDescriptor from which you can read the
		/// data stream from the provider.  Note that this may be a pipe, meaning
		/// you can't seek in it.  The only seek you should do is if the
		/// AssetFileDescriptor contains an offset, to move to that offset before
		/// reading.  You own this descriptor and are responsible for closing it when done.
		/// </returns>
		/// <exception cref="java.io.FileNotFoundException">
		/// Throws FileNotFoundException of no
		/// data of the desired type exists under the URI.
		/// </exception>
		public android.content.res.AssetFileDescriptor openTypedAssetFileDescriptor(System.Uri
			 uri, string mimeType, android.os.Bundle opts)
		{
			android.content.IContentProvider provider = acquireProvider(uri);
			if (provider == null)
			{
				throw new java.io.FileNotFoundException("No content provider: " + uri);
			}
			try
			{
				android.content.res.AssetFileDescriptor fd = provider.openTypedAssetFile(uri, mimeType
					, opts);
				if (fd == null)
				{
					// The provider will be released by the finally{} clause
					return null;
				}
				android.os.ParcelFileDescriptor pfd = new android.content.ContentResolver.ParcelFileDescriptorInner
					(this, fd.getParcelFileDescriptor(), provider);
				// Success!  Don't release the provider when exiting, let
				// ParcelFileDescriptorInner do that when it is closed.
				provider = null;
				return new android.content.res.AssetFileDescriptor(pfd, fd.getStartOffset(), fd.getDeclaredLength
					());
			}
			catch (android.os.RemoteException)
			{
				throw new java.io.FileNotFoundException("Dead content provider: " + uri);
			}
			catch (java.io.FileNotFoundException e)
			{
				throw;
			}
			finally
			{
				if (provider != null)
				{
					releaseProvider(provider);
				}
			}
		}

		/// <summary>
		/// A resource identified by the
		/// <see cref="android.content.res.Resources">android.content.res.Resources</see>
		/// that contains it, and a resource id.
		/// </summary>
		/// <hide></hide>
		public class OpenResourceIdResult
		{
			public android.content.res.Resources r;

			public int id;

			internal OpenResourceIdResult(ContentResolver _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ContentResolver _enclosing;
		}

		[Sharpen.Stub]
		public virtual android.content.ContentResolver.OpenResourceIdResult getResourceId
			(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int modeToMode(System.Uri uri, string mode)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Inserts a row into a table at the given URL.</summary>
		/// <remarks>
		/// Inserts a row into a table at the given URL.
		/// If the content provider supports transactions the insertion will be atomic.
		/// </remarks>
		/// <param name="url">The URL of the table to insert into.</param>
		/// <param name="values">
		/// The initial values for the newly inserted row. The key is the column name for
		/// the field. Passing an empty ContentValues will create an empty row.
		/// </param>
		/// <returns>the URL of the newly created row.</returns>
		public System.Uri insert(System.Uri url, android.content.ContentValues values)
		{
			android.content.IContentProvider provider = acquireProvider(url);
			if (provider == null)
			{
				throw new System.ArgumentException("Unknown URL " + url);
			}
			try
			{
				long startTime = android.os.SystemClock.uptimeMillis();
				System.Uri createdRow = provider.insert(url, values);
				long durationMillis = android.os.SystemClock.uptimeMillis() - startTime;
				maybeLogUpdateToEventLog(durationMillis, url, "insert", null);
				return createdRow;
			}
			catch (android.os.RemoteException)
			{
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return null;
			}
			finally
			{
				releaseProvider(provider);
			}
		}

		/// <summary>
		/// Applies each of the
		/// <see cref="ContentProviderOperation">ContentProviderOperation</see>
		/// objects and returns an array
		/// of their results. Passes through OperationApplicationException, which may be thrown
		/// by the call to
		/// <see cref="ContentProviderOperation.apply(ContentProvider, ContentProviderResult[], int)
		/// 	">ContentProviderOperation.apply(ContentProvider, ContentProviderResult[], int)</see>
		/// .
		/// If all the applications succeed then a
		/// <see cref="ContentProviderResult">ContentProviderResult</see>
		/// array with the
		/// same number of elements as the operations will be returned. It is implementation-specific
		/// how many, if any, operations will have been successfully applied if a call to
		/// apply results in a
		/// <see cref="OperationApplicationException">OperationApplicationException</see>
		/// .
		/// </summary>
		/// <param name="authority">the authority of the ContentProvider to which this batch should be applied
		/// 	</param>
		/// <param name="operations">the operations to apply</param>
		/// <returns>the results of the applications</returns>
		/// <exception cref="OperationApplicationException">
		/// thrown if an application fails.
		/// See
		/// <see cref="ContentProviderOperation.apply(ContentProvider, ContentProviderResult[], int)
		/// 	">ContentProviderOperation.apply(ContentProvider, ContentProviderResult[], int)</see>
		/// for more information.
		/// </exception>
		/// <exception cref="android.os.RemoteException">
		/// thrown if a RemoteException is encountered while attempting
		/// to communicate with a remote provider.
		/// </exception>
		/// <exception cref="android.content.OperationApplicationException"></exception>
		public virtual android.content.ContentProviderResult[] applyBatch(string authority
			, java.util.ArrayList<android.content.ContentProviderOperation> operations)
		{
			android.content.ContentProviderClient provider = acquireContentProviderClient(authority
				);
			if (provider == null)
			{
				throw new System.ArgumentException("Unknown authority " + authority);
			}
			try
			{
				return provider.applyBatch(operations);
			}
			finally
			{
				provider.release();
			}
		}

		/// <summary>Inserts multiple rows into a table at the given URL.</summary>
		/// <remarks>
		/// Inserts multiple rows into a table at the given URL.
		/// This function make no guarantees about the atomicity of the insertions.
		/// </remarks>
		/// <param name="url">The URL of the table to insert into.</param>
		/// <param name="values">
		/// The initial values for the newly inserted rows. The key is the column name for
		/// the field. Passing null will create an empty row.
		/// </param>
		/// <returns>the number of newly created rows.</returns>
		public int bulkInsert(System.Uri url, android.content.ContentValues[] values)
		{
			android.content.IContentProvider provider = acquireProvider(url);
			if (provider == null)
			{
				throw new System.ArgumentException("Unknown URL " + url);
			}
			try
			{
				long startTime = android.os.SystemClock.uptimeMillis();
				int rowsCreated = provider.bulkInsert(url, values);
				long durationMillis = android.os.SystemClock.uptimeMillis() - startTime;
				maybeLogUpdateToEventLog(durationMillis, url, "bulkinsert", null);
				return rowsCreated;
			}
			catch (android.os.RemoteException)
			{
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return 0;
			}
			finally
			{
				releaseProvider(provider);
			}
		}

		/// <summary>Deletes row(s) specified by a content URI.</summary>
		/// <remarks>
		/// Deletes row(s) specified by a content URI.
		/// If the content provider supports transactions, the deletion will be atomic.
		/// </remarks>
		/// <param name="url">The URL of the row to delete.</param>
		/// <param name="where">
		/// A filter to apply to rows before deleting, formatted as an SQL WHERE clause
		/// (excluding the WHERE itself).
		/// </param>
		/// <returns>The number of rows deleted.</returns>
		public int delete(System.Uri url, string where, string[] selectionArgs)
		{
			android.content.IContentProvider provider = acquireProvider(url);
			if (provider == null)
			{
				throw new System.ArgumentException("Unknown URL " + url);
			}
			try
			{
				long startTime = android.os.SystemClock.uptimeMillis();
				int rowsDeleted = provider.delete(url, where, selectionArgs);
				long durationMillis = android.os.SystemClock.uptimeMillis() - startTime;
				maybeLogUpdateToEventLog(durationMillis, url, "delete", where);
				return rowsDeleted;
			}
			catch (android.os.RemoteException)
			{
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return -1;
			}
			finally
			{
				releaseProvider(provider);
			}
		}

		/// <summary>Update row(s) in a content URI.</summary>
		/// <remarks>
		/// Update row(s) in a content URI.
		/// If the content provider supports transactions the update will be atomic.
		/// </remarks>
		/// <param name="uri">The URI to modify.</param>
		/// <param name="values">
		/// The new field values. The key is the column name for the field.
		/// A null value will remove an existing field value.
		/// </param>
		/// <param name="where">
		/// A filter to apply to rows before updating, formatted as an SQL WHERE clause
		/// (excluding the WHERE itself).
		/// </param>
		/// <returns>the number of rows updated.</returns>
		/// <exception cref="System.ArgumentNullException">if uri or values are null</exception>
		public int update(System.Uri uri, android.content.ContentValues values, string where
			, string[] selectionArgs)
		{
			android.content.IContentProvider provider = acquireProvider(uri);
			if (provider == null)
			{
				throw new System.ArgumentException("Unknown URI " + uri);
			}
			try
			{
				long startTime = android.os.SystemClock.uptimeMillis();
				int rowsUpdated = provider.update(uri, values, where, selectionArgs);
				long durationMillis = android.os.SystemClock.uptimeMillis() - startTime;
				maybeLogUpdateToEventLog(durationMillis, uri, "update", where);
				return rowsUpdated;
			}
			catch (android.os.RemoteException)
			{
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return -1;
			}
			finally
			{
				releaseProvider(provider);
			}
		}

		/// <summary>Call an provider-defined method.</summary>
		/// <remarks>
		/// Call an provider-defined method.  This can be used to implement
		/// read or write interfaces which are cheaper than using a Cursor and/or
		/// do not fit into the traditional table model.
		/// </remarks>
		/// <param name="method">
		/// provider-defined method name to call.  Opaque to
		/// framework, but must be non-null.
		/// </param>
		/// <param name="arg">provider-defined String argument.  May be null.</param>
		/// <param name="extras">provider-defined Bundle argument.  May be null.</param>
		/// <returns>
		/// a result Bundle, possibly null.  Will be null if the ContentProvider
		/// does not implement call.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">if uri or method is null</exception>
		/// <exception cref="System.ArgumentException">if uri is not known</exception>
		public android.os.Bundle call(System.Uri uri, string method, string arg, android.os.Bundle
			 extras)
		{
			if (uri == null)
			{
				throw new System.ArgumentNullException("uri == null");
			}
			if (method == null)
			{
				throw new System.ArgumentNullException("method == null");
			}
			android.content.IContentProvider provider = acquireProvider(uri);
			if (provider == null)
			{
				throw new System.ArgumentException("Unknown URI " + uri);
			}
			try
			{
				return provider.call(method, arg, extras);
			}
			catch (android.os.RemoteException)
			{
				// Arbitrary and not worth documenting, as Activity
				// Manager will kill this process shortly anyway.
				return null;
			}
			finally
			{
				releaseProvider(provider);
			}
		}

		[Sharpen.Stub]
		public android.content.IContentProvider acquireProvider(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.IContentProvider acquireExistingProvider(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.IContentProvider acquireProvider(string name)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns a
		/// <see cref="ContentProviderClient">ContentProviderClient</see>
		/// that is associated with the
		/// <see cref="ContentProvider">ContentProvider</see>
		/// that services the content at uri, starting the provider if necessary. Returns
		/// null if there is no provider associated wih the uri. The caller must indicate that they are
		/// done with the provider by calling
		/// <see cref="ContentProviderClient.release()">ContentProviderClient.release()</see>
		/// which will allow
		/// the system to release the provider it it determines that there is no other reason for
		/// keeping it active.
		/// </summary>
		/// <param name="uri">specifies which provider should be acquired</param>
		/// <returns>
		/// a
		/// <see cref="ContentProviderClient">ContentProviderClient</see>
		/// that is associated with the
		/// <see cref="ContentProvider">ContentProvider</see>
		/// that services the content at uri or null if there isn't one.
		/// </returns>
		public android.content.ContentProviderClient acquireContentProviderClient(System.Uri
			 uri)
		{
			android.content.IContentProvider provider = acquireProvider(uri);
			if (provider != null)
			{
				return new android.content.ContentProviderClient(this, provider);
			}
			return null;
		}

		/// <summary>
		/// Returns a
		/// <see cref="ContentProviderClient">ContentProviderClient</see>
		/// that is associated with the
		/// <see cref="ContentProvider">ContentProvider</see>
		/// with the authority of name, starting the provider if necessary. Returns
		/// null if there is no provider associated wih the uri. The caller must indicate that they are
		/// done with the provider by calling
		/// <see cref="ContentProviderClient.release()">ContentProviderClient.release()</see>
		/// which will allow
		/// the system to release the provider it it determines that there is no other reason for
		/// keeping it active.
		/// </summary>
		/// <param name="name">specifies which provider should be acquired</param>
		/// <returns>
		/// a
		/// <see cref="ContentProviderClient">ContentProviderClient</see>
		/// that is associated with the
		/// <see cref="ContentProvider">ContentProvider</see>
		/// with the authority of name or null if there isn't one.
		/// </returns>
		public android.content.ContentProviderClient acquireContentProviderClient(string 
			name)
		{
			android.content.IContentProvider provider = acquireProvider(name);
			if (provider != null)
			{
				return new android.content.ContentProviderClient(this, provider);
			}
			return null;
		}

		/// <summary>
		/// Register an observer class that gets callbacks when data identified by a
		/// given content URI changes.
		/// </summary>
		/// <remarks>
		/// Register an observer class that gets callbacks when data identified by a
		/// given content URI changes.
		/// </remarks>
		/// <param name="uri">
		/// The URI to watch for changes. This can be a specific row URI, or a base URI
		/// for a whole class of content.
		/// </param>
		/// <param name="notifyForDescendents">
		/// If <code>true</code> changes to URIs beginning with <code>uri</code>
		/// will also cause notifications to be sent. If <code>false</code> only changes to the exact URI
		/// specified by <em>uri</em> will cause notifications to be sent. If true, than any URI values
		/// at or below the specified URI will also trigger a match.
		/// </param>
		/// <param name="observer">The object that receives callbacks when changes occur.</param>
		/// <seealso cref="unregisterContentObserver(android.database.ContentObserver)">unregisterContentObserver(android.database.ContentObserver)
		/// 	</seealso>
		public void registerContentObserver(System.Uri uri, bool notifyForDescendents, android.database.ContentObserver
			 observer)
		{
			try
			{
				getContentService().registerContentObserver(uri, notifyForDescendents, observer.getContentObserver
					());
			}
			catch (android.os.RemoteException)
			{
			}
		}

		/// <summary>Unregisters a change observer.</summary>
		/// <remarks>Unregisters a change observer.</remarks>
		/// <param name="observer">The previously registered observer that is no longer needed.
		/// 	</param>
		/// <seealso cref="registerContentObserver(System.Uri, bool, android.database.ContentObserver)
		/// 	">registerContentObserver(System.Uri, bool, android.database.ContentObserver)</seealso>
		public void unregisterContentObserver(android.database.ContentObserver observer)
		{
			try
			{
				android.database.IContentObserver contentObserver = observer.releaseContentObserver
					();
				if (contentObserver != null)
				{
					getContentService().unregisterContentObserver(contentObserver);
				}
			}
			catch (android.os.RemoteException)
			{
			}
		}

		/// <summary>Notify registered observers that a row was updated.</summary>
		/// <remarks>
		/// Notify registered observers that a row was updated.
		/// To register, call
		/// <see cref="registerContentObserver(System.Uri, bool, android.database.ContentObserver)
		/// 	">registerContentObserver()</see>
		/// .
		/// By default, CursorAdapter objects will get this notification.
		/// </remarks>
		/// <param name="uri"></param>
		/// <param name="observer">The observer that originated the change, may be <code>null</null>
		/// 	</param>
		public virtual void notifyChange(System.Uri uri, android.database.ContentObserver
			 observer)
		{
			notifyChange(uri, observer, true);
		}

		/// <summary>Notify registered observers that a row was updated.</summary>
		/// <remarks>
		/// Notify registered observers that a row was updated.
		/// To register, call
		/// <see cref="registerContentObserver(System.Uri, bool, android.database.ContentObserver)
		/// 	">registerContentObserver()</see>
		/// .
		/// By default, CursorAdapter objects will get this notification.
		/// </remarks>
		/// <param name="uri"></param>
		/// <param name="observer">The observer that originated the change, may be <code>null</null>
		/// 	</param>
		/// <param name="syncToNetwork">If true, attempt to sync the change to the network.</param>
		public virtual void notifyChange(System.Uri uri, android.database.ContentObserver
			 observer, bool syncToNetwork)
		{
			try
			{
				getContentService().notifyChange(uri, observer == null ? null : observer.getContentObserver
					(), observer != null && observer.deliverSelfNotifications(), syncToNetwork);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"instead userequestSync(android.accounts.Account, string, android.os.Bundle)"
			)]
		public virtual void startSync(System.Uri uri, android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Start an asynchronous sync operation.</summary>
		/// <remarks>
		/// Start an asynchronous sync operation. If you want to monitor the progress
		/// of the sync you may register a SyncObserver. Only values of the following
		/// types may be used in the extras bundle:
		/// <ul>
		/// <li>Integer</li>
		/// <li>Long</li>
		/// <li>Boolean</li>
		/// <li>Float</li>
		/// <li>Double</li>
		/// <li>String</li>
		/// </ul>
		/// </remarks>
		/// <param name="account">which account should be synced</param>
		/// <param name="authority">which authority should be synced</param>
		/// <param name="extras">any extras to pass to the SyncAdapter.</param>
		public static void requestSync(android.accounts.Account account, string authority
			, android.os.Bundle extras)
		{
			validateSyncExtrasBundle(extras);
			try
			{
				getContentService().requestSync(account, authority, extras);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		/// <summary>
		/// Check that only values of the following types are in the Bundle:
		/// <ul>
		/// <li>Integer</li>
		/// <li>Long</li>
		/// <li>Boolean</li>
		/// <li>Float</li>
		/// <li>Double</li>
		/// <li>String</li>
		/// <li>Account</li>
		/// <li>null</li>
		/// </ul>
		/// </summary>
		/// <param name="extras">the Bundle to check</param>
		public static void validateSyncExtrasBundle(android.os.Bundle extras)
		{
			try
			{
				foreach (string key in Sharpen.IterableProxy.Create(extras.keySet()))
				{
					object value = extras.get(key);
					if (value == null)
					{
						continue;
					}
					if (value is long)
					{
						continue;
					}
					if (value is int)
					{
						continue;
					}
					if (value is bool)
					{
						continue;
					}
					if (value is float)
					{
						continue;
					}
					if (value is double)
					{
						continue;
					}
					if (value is string)
					{
						continue;
					}
					if (value is android.accounts.Account)
					{
						continue;
					}
					throw new System.ArgumentException("unexpected value type: " + value.GetType().FullName
						);
				}
			}
			catch (System.ArgumentException e)
			{
				throw;
			}
			catch (java.lang.RuntimeException exc)
			{
				throw new System.ArgumentException("error unparceling Bundle", exc);
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"instead use cancelSync(android.accounts.Account, string)"
			)]
		public virtual void cancelSync(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void cancelSync(android.accounts.Account account, string authority)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Get information about the SyncAdapters that are known to the system.</summary>
		/// <remarks>Get information about the SyncAdapters that are known to the system.</remarks>
		/// <returns>an array of SyncAdapters that have registered with the system</returns>
		public static android.content.SyncAdapterType[] getSyncAdapterTypes()
		{
			try
			{
				return getContentService().getSyncAdapterTypes();
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Check if the provider should be synced when a network tickle is received
		/// 	</summary>
		/// <param name="account">the account whose setting we are querying</param>
		/// <param name="authority">the provider whose setting we are querying</param>
		/// <returns>true if the provider should be synced when a network tickle is received</returns>
		public static bool getSyncAutomatically(android.accounts.Account account, string 
			authority)
		{
			try
			{
				return getContentService().getSyncAutomatically(account, authority);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Set whether or not the provider is synced when it receives a network tickle.
		/// 	</summary>
		/// <remarks>Set whether or not the provider is synced when it receives a network tickle.
		/// 	</remarks>
		/// <param name="account">the account whose setting we are querying</param>
		/// <param name="authority">the provider whose behavior is being controlled</param>
		/// <param name="sync">true if the provider should be synced when tickles are received for it
		/// 	</param>
		public static void setSyncAutomatically(android.accounts.Account account, string 
			authority, bool sync)
		{
			try
			{
				getContentService().setSyncAutomatically(account, authority, sync);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// exception ignored; if this is thrown then it means the runtime is in the midst of
		// being restarted
		/// <summary>
		/// Specifies that a sync should be requested with the specified the account, authority,
		/// and extras at the given frequency.
		/// </summary>
		/// <remarks>
		/// Specifies that a sync should be requested with the specified the account, authority,
		/// and extras at the given frequency. If there is already another periodic sync scheduled
		/// with the account, authority and extras then a new periodic sync won't be added, instead
		/// the frequency of the previous one will be updated.
		/// <p>
		/// These periodic syncs honor the "syncAutomatically" and "masterSyncAutomatically" settings.
		/// Although these sync are scheduled at the specified frequency, it may take longer for it to
		/// actually be started if other syncs are ahead of it in the sync operation queue. This means
		/// that the actual start time may drift.
		/// <p>
		/// Periodic syncs are not allowed to have any of
		/// <see cref="SYNC_EXTRAS_DO_NOT_RETRY">SYNC_EXTRAS_DO_NOT_RETRY</see>
		/// ,
		/// <see cref="SYNC_EXTRAS_IGNORE_BACKOFF">SYNC_EXTRAS_IGNORE_BACKOFF</see>
		/// ,
		/// <see cref="SYNC_EXTRAS_IGNORE_SETTINGS">SYNC_EXTRAS_IGNORE_SETTINGS</see>
		/// ,
		/// <see cref="SYNC_EXTRAS_INITIALIZE">SYNC_EXTRAS_INITIALIZE</see>
		/// ,
		/// <see cref="SYNC_EXTRAS_FORCE">SYNC_EXTRAS_FORCE</see>
		/// ,
		/// <see cref="SYNC_EXTRAS_EXPEDITED">SYNC_EXTRAS_EXPEDITED</see>
		/// ,
		/// <see cref="SYNC_EXTRAS_MANUAL">SYNC_EXTRAS_MANUAL</see>
		/// set to true.
		/// If any are supplied then an
		/// <see cref="System.ArgumentException">System.ArgumentException</see>
		/// will be thrown.
		/// </remarks>
		/// <param name="account">the account to specify in the sync</param>
		/// <param name="authority">the provider to specify in the sync request</param>
		/// <param name="extras">extra parameters to go along with the sync request</param>
		/// <param name="pollFrequency">how frequently the sync should be performed, in seconds.
		/// 	</param>
		/// <exception cref="System.ArgumentException">
		/// if an illegal extra was set or if any of the parameters
		/// are null.
		/// </exception>
		public static void addPeriodicSync(android.accounts.Account account, string authority
			, android.os.Bundle extras, long pollFrequency)
		{
			validateSyncExtrasBundle(extras);
			if (account == null)
			{
				throw new System.ArgumentException("account must not be null");
			}
			if (authority == null)
			{
				throw new System.ArgumentException("authority must not be null");
			}
			if (extras.getBoolean(SYNC_EXTRAS_MANUAL, false) || extras.getBoolean(SYNC_EXTRAS_DO_NOT_RETRY
				, false) || extras.getBoolean(SYNC_EXTRAS_IGNORE_BACKOFF, false) || extras.getBoolean
				(SYNC_EXTRAS_IGNORE_SETTINGS, false) || extras.getBoolean(SYNC_EXTRAS_INITIALIZE
				, false) || extras.getBoolean(SYNC_EXTRAS_FORCE, false) || extras.getBoolean(SYNC_EXTRAS_EXPEDITED
				, false))
			{
				throw new System.ArgumentException("illegal extras were set");
			}
			try
			{
				getContentService().addPeriodicSync(account, authority, extras, pollFrequency);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// exception ignored; if this is thrown then it means the runtime is in the midst of
		// being restarted
		/// <summary>Remove a periodic sync.</summary>
		/// <remarks>
		/// Remove a periodic sync. Has no affect if account, authority and extras don't match
		/// an existing periodic sync.
		/// </remarks>
		/// <param name="account">the account of the periodic sync to remove</param>
		/// <param name="authority">the provider of the periodic sync to remove</param>
		/// <param name="extras">the extras of the periodic sync to remove</param>
		public static void removePeriodicSync(android.accounts.Account account, string authority
			, android.os.Bundle extras)
		{
			validateSyncExtrasBundle(extras);
			if (account == null)
			{
				throw new System.ArgumentException("account must not be null");
			}
			if (authority == null)
			{
				throw new System.ArgumentException("authority must not be null");
			}
			try
			{
				getContentService().removePeriodicSync(account, authority, extras);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Get the list of information about the periodic syncs for the given account and authority.
		/// 	</summary>
		/// <remarks>Get the list of information about the periodic syncs for the given account and authority.
		/// 	</remarks>
		/// <param name="account">the account whose periodic syncs we are querying</param>
		/// <param name="authority">the provider whose periodic syncs we are querying</param>
		/// <returns>a list of PeriodicSync objects. This list may be empty but will never be null.
		/// 	</returns>
		public static java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account
			 account, string authority)
		{
			if (account == null)
			{
				throw new System.ArgumentException("account must not be null");
			}
			if (authority == null)
			{
				throw new System.ArgumentException("authority must not be null");
			}
			try
			{
				return getContentService().getPeriodicSyncs(account, authority);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Check if this account/provider is syncable.</summary>
		/// <remarks>Check if this account/provider is syncable.</remarks>
		/// <returns>&gt;0 if it is syncable, 0 if not, and &lt;0 if the state isn't known yet.
		/// 	</returns>
		public static int getIsSyncable(android.accounts.Account account, string authority
			)
		{
			try
			{
				return getContentService().getIsSyncable(account, authority);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Set whether this account/provider is syncable.</summary>
		/// <remarks>Set whether this account/provider is syncable.</remarks>
		/// <param name="syncable">&gt;0 denotes syncable, 0 means not syncable, &lt;0 means unknown
		/// 	</param>
		public static void setIsSyncable(android.accounts.Account account, string authority
			, int syncable)
		{
			try
			{
				getContentService().setIsSyncable(account, authority, syncable);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// exception ignored; if this is thrown then it means the runtime is in the midst of
		// being restarted
		/// <summary>Gets the master auto-sync setting that applies to all the providers and accounts.
		/// 	</summary>
		/// <remarks>
		/// Gets the master auto-sync setting that applies to all the providers and accounts.
		/// If this is false then the per-provider auto-sync setting is ignored.
		/// </remarks>
		/// <returns>the master auto-sync setting that applies to all the providers and accounts
		/// 	</returns>
		public static bool getMasterSyncAutomatically()
		{
			try
			{
				return getContentService().getMasterSyncAutomatically();
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Sets the master auto-sync setting that applies to all the providers and accounts.
		/// 	</summary>
		/// <remarks>
		/// Sets the master auto-sync setting that applies to all the providers and accounts.
		/// If this is false then the per-provider auto-sync setting is ignored.
		/// </remarks>
		/// <param name="sync">the master auto-sync setting that applies to all the providers and accounts
		/// 	</param>
		public static void setMasterSyncAutomatically(bool sync)
		{
			try
			{
				getContentService().setMasterSyncAutomatically(sync);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// exception ignored; if this is thrown then it means the runtime is in the midst of
		// being restarted
		/// <summary>
		/// Returns true if there is currently a sync operation for the given
		/// account or authority in the pending list, or actively being processed.
		/// </summary>
		/// <remarks>
		/// Returns true if there is currently a sync operation for the given
		/// account or authority in the pending list, or actively being processed.
		/// </remarks>
		/// <param name="account">the account whose setting we are querying</param>
		/// <param name="authority">the provider whose behavior is being queried</param>
		/// <returns>true if a sync is active for the given account or authority.</returns>
		public static bool isSyncActive(android.accounts.Account account, string authority
			)
		{
			try
			{
				return getContentService().isSyncActive(account, authority);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Since multiple concurrent syncs are now supported you should usegetCurrentSyncs() to get the accurate list of current syncs. This method returns the first item from the list of current syncs or null if there are none."
			)]
		public static android.content.SyncInfo getCurrentSync()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Returns a list with information about all the active syncs.</summary>
		/// <remarks>
		/// Returns a list with information about all the active syncs. This list will be empty
		/// if there are no active syncs.
		/// </remarks>
		/// <returns>a List of SyncInfo objects for the currently active syncs.</returns>
		public static java.util.List<android.content.SyncInfo> getCurrentSyncs()
		{
			try
			{
				return getContentService().getCurrentSyncs();
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Returns the status that matches the authority.</summary>
		/// <remarks>Returns the status that matches the authority.</remarks>
		/// <param name="account">the account whose setting we are querying</param>
		/// <param name="authority">the provider whose behavior is being queried</param>
		/// <returns>the SyncStatusInfo for the authority, or null if none exists</returns>
		/// <hide></hide>
		public static android.content.SyncStatusInfo getSyncStatus(android.accounts.Account
			 account, string authority)
		{
			try
			{
				return getContentService().getSyncStatus(account, authority);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Return true if the pending status is true of any matching authorities.</summary>
		/// <remarks>Return true if the pending status is true of any matching authorities.</remarks>
		/// <param name="account">the account whose setting we are querying</param>
		/// <param name="authority">the provider whose behavior is being queried</param>
		/// <returns>true if there is a pending sync with the matching account and authority</returns>
		public static bool isSyncPending(android.accounts.Account account, string authority
			)
		{
			try
			{
				return getContentService().isSyncPending(account, authority);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		private sealed class _Stub_1470 : android.content.ISyncStatusObserverClass.Stub
		{
			public _Stub_1470(android.content.SyncStatusObserver callback)
			{
				this.callback = callback;
			}

			/// <exception cref="android.os.RemoteException"></exception>
			[Sharpen.ImplementsInterface(@"android.content.ISyncStatusObserver")]
			public override void onStatusChanged(int which)
			{
				callback.onStatusChanged(which);
			}

			private readonly android.content.SyncStatusObserver callback;
		}

		/// <summary>Request notifications when the different aspects of the SyncManager change.
		/// 	</summary>
		/// <remarks>
		/// Request notifications when the different aspects of the SyncManager change. The
		/// different items that can be requested are:
		/// <ul>
		/// <li>
		/// <see cref="SYNC_OBSERVER_TYPE_PENDING">SYNC_OBSERVER_TYPE_PENDING</see>
		/// <li>
		/// <see cref="SYNC_OBSERVER_TYPE_ACTIVE">SYNC_OBSERVER_TYPE_ACTIVE</see>
		/// <li>
		/// <see cref="SYNC_OBSERVER_TYPE_SETTINGS">SYNC_OBSERVER_TYPE_SETTINGS</see>
		/// </ul>
		/// The caller can set one or more of the status types in the mask for any
		/// given listener registration.
		/// </remarks>
		/// <param name="mask">the status change types that will cause the callback to be invoked
		/// 	</param>
		/// <param name="callback">observer to be invoked when the status changes</param>
		/// <returns>a handle that can be used to remove the listener at a later time</returns>
		public static object addStatusChangeListener(int mask, android.content.SyncStatusObserver
			 callback)
		{
			if (callback == null)
			{
				throw new System.ArgumentException("you passed in a null callback");
			}
			try
			{
				android.content.ISyncStatusObserverClass.Stub observer = new _Stub_1470(callback);
				getContentService().addStatusChangeListener(mask, observer);
				return observer;
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("the ContentService should always be reachable"
					, e);
			}
		}

		/// <summary>Remove a previously registered status change listener.</summary>
		/// <remarks>Remove a previously registered status change listener.</remarks>
		/// <param name="handle">
		/// the handle that was returned by
		/// <see cref="addStatusChangeListener(int, SyncStatusObserver)">addStatusChangeListener(int, SyncStatusObserver)
		/// 	</see>
		/// </param>
		public static void removeStatusChangeListener(object handle)
		{
			if (handle == null)
			{
				throw new System.ArgumentException("you passed in a null handle");
			}
			try
			{
				getContentService().removeStatusChangeListener((android.content.ISyncStatusObserverClass
					.Stub)handle);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// exception ignored; if this is thrown then it means the runtime is in the midst of
		// being restarted
		/// <summary>Returns sampling percentage for a given duration.</summary>
		/// <remarks>
		/// Returns sampling percentage for a given duration.
		/// Always returns at least 1%.
		/// </remarks>
		private int samplePercentForDuration(long durationMillis)
		{
			if (durationMillis >= SLOW_THRESHOLD_MILLIS)
			{
				return 100;
			}
			return (int)(100 * durationMillis / SLOW_THRESHOLD_MILLIS) + 1;
		}

		private void maybeLogQueryToEventLog(long durationMillis, System.Uri uri, string[]
			 projection, string selection, string sortOrder)
		{
			int samplePercent = samplePercentForDuration(durationMillis);
			if (samplePercent < 100)
			{
				lock (mRandom)
				{
					if (Sharpen.Util.Random_NextInt(mRandom, 100) >= samplePercent)
					{
						return;
					}
				}
			}
			java.lang.StringBuilder projectionBuffer = new java.lang.StringBuilder(100);
			if (projection != null)
			{
				{
					for (int i = 0; i < projection.Length; ++i)
					{
						// Note: not using a comma delimiter here, as the
						// multiple arguments to EventLog.writeEvent later
						// stringify with a comma delimiter, which would make
						// parsing uglier later.
						if (i != 0)
						{
							projectionBuffer.append('/');
						}
						projectionBuffer.append(projection[i]);
					}
				}
			}
			// ActivityThread.currentPackageName() only returns non-null if the
			// current thread is an application main thread.  This parameter tells
			// us whether an event loop is blocked, and if so, which app it is.
			string blockingPackage = android.app.AppGlobals.getInitialPackage();
			android.util.EventLog.writeEvent(android.content.EventLogTags.CONTENT_QUERY_SAMPLE
				, uri.ToString(), projectionBuffer.ToString(), selection != null ? selection : string.Empty
				, sortOrder != null ? sortOrder : string.Empty, durationMillis, blockingPackage 
				!= null ? blockingPackage : string.Empty, samplePercent);
		}

		private void maybeLogUpdateToEventLog(long durationMillis, System.Uri uri, string
			 operation, string selection)
		{
			int samplePercent = samplePercentForDuration(durationMillis);
			if (samplePercent < 100)
			{
				lock (mRandom)
				{
					if (Sharpen.Util.Random_NextInt(mRandom, 100) >= samplePercent)
					{
						return;
					}
				}
			}
			string blockingPackage = android.app.AppGlobals.getInitialPackage();
			android.util.EventLog.writeEvent(android.content.EventLogTags.CONTENT_UPDATE_SAMPLE
				, uri.ToString(), operation, selection != null ? selection : string.Empty, durationMillis
				, blockingPackage != null ? blockingPackage : string.Empty, samplePercent);
		}

		private sealed class CursorWrapperInner : android.database.CursorWrapper
		{
			internal readonly android.content.IContentProvider mContentProvider;

			public const string TAG = "CursorWrapperInner";

			internal readonly dalvik.system.CloseGuard mCloseGuard;

			internal bool mProviderReleased;

			internal CursorWrapperInner(ContentResolver _enclosing, android.database.Cursor cursor
				, android.content.IContentProvider icp) : base(cursor)
			{
				this._enclosing = _enclosing;
				mCloseGuard = dalvik.system.CloseGuard.get();
				this.mContentProvider = icp;
				this.mCloseGuard.open("close");
			}

			[Sharpen.OverridesMethod(@"android.database.CursorWrapper")]
			public override void close()
			{
				base.close();
				this._enclosing.releaseProvider(this.mContentProvider);
				this.mProviderReleased = true;
				if (this.mCloseGuard != null)
				{
					this.mCloseGuard.close();
				}
			}

			~CursorWrapperInner()
			{
				try
				{
					if (this.mCloseGuard != null)
					{
						this.mCloseGuard.warnIfOpen();
					}
					if (!this.mProviderReleased && this.mContentProvider != null)
					{
						// Even though we are using CloseGuard, log this anyway so that
						// application developers always see the message in the log.
						android.util.Log.w(TAG, "Cursor finalized without prior close()");
						this._enclosing.releaseProvider(this.mContentProvider);
					}
				}
				finally
				{
					;
				}
			}

			private readonly ContentResolver _enclosing;
		}

		private sealed class ParcelFileDescriptorInner : android.os.ParcelFileDescriptor
		{
			internal readonly android.content.IContentProvider mContentProvider;

			public const string TAG = "ParcelFileDescriptorInner";

			internal bool mReleaseProviderFlag;

			internal ParcelFileDescriptorInner(ContentResolver _enclosing, android.os.ParcelFileDescriptor
				 pfd, android.content.IContentProvider icp) : base(pfd)
			{
				this._enclosing = _enclosing;
				mReleaseProviderFlag = false;
				this.mContentProvider = icp;
			}

			/// <exception cref="System.IO.IOException"></exception>
			[Sharpen.OverridesMethod(@"android.os.ParcelFileDescriptor")]
			public override void close()
			{
				if (!this.mReleaseProviderFlag)
				{
					base.close();
					this._enclosing.releaseProvider(this.mContentProvider);
					this.mReleaseProviderFlag = true;
				}
			}

			~ParcelFileDescriptorInner()
			{
				if (!this.mReleaseProviderFlag)
				{
					this.close();
				}
			}

			private readonly ContentResolver _enclosing;
		}

		/// <hide></hide>
		public const string CONTENT_SERVICE_NAME = "content";

		/// <hide></hide>
		public static android.content.IContentService getContentService()
		{
			if (sContentService != null)
			{
				return sContentService;
			}
			android.os.IBinder b = android.os.ServiceManager.getService(CONTENT_SERVICE_NAME);
			if (false)
			{
				android.util.Log.v("ContentService", "default service binder = " + b);
			}
			sContentService = android.content.IContentServiceClass.Stub.asInterface(b);
			if (false)
			{
				android.util.Log.v("ContentService", "default service = " + sContentService);
			}
			return sContentService;
		}

		private static android.content.IContentService sContentService;

		private readonly android.content.Context mContext;

		internal const string TAG = "ContentResolver";
	}
}
