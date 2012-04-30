using Sharpen;

namespace android.speech
{
	/// <summary>
	/// Constants for supporting speech recognition through starting an
	/// <see cref="android.content.Intent">android.content.Intent</see>
	/// </summary>
	[Sharpen.Sharpened]
	public class RecognizerIntent
	{
		/// <summary>The extra key used in an intent to the speech recognizer for voice search.
		/// 	</summary>
		/// <remarks>
		/// The extra key used in an intent to the speech recognizer for voice search. Not
		/// generally to be used by developers. The system search dialog uses this, for example,
		/// to set a calling package for identification by a voice search API. If this extra
		/// is set by anyone but the system process, it should be overridden by the voice search
		/// implementation.
		/// </remarks>
		public const string EXTRA_CALLING_PACKAGE = "calling_package";

		private RecognizerIntent()
		{
		}

		/// <summary>
		/// Starts an activity that will prompt the user for speech and send it through a
		/// speech recognizer.
		/// </summary>
		/// <remarks>
		/// Starts an activity that will prompt the user for speech and send it through a
		/// speech recognizer.  The results will be returned via activity results (in
		/// <see cref="android.app.Activity.onActivityResult(int, int, android.content.Intent)
		/// 	">android.app.Activity.onActivityResult(int, int, android.content.Intent)</see>
		/// , if you start the intent using
		/// <see cref="android.app.Activity.startActivityForResult(android.content.Intent, int)
		/// 	">android.app.Activity.startActivityForResult(android.content.Intent, int)</see>
		/// ), or forwarded via a PendingIntent
		/// if one is provided.
		/// <p>Starting this intent with just
		/// <see cref="android.app.Activity.startActivity(android.content.Intent)">android.app.Activity.startActivity(android.content.Intent)
		/// 	</see>
		/// is not supported.
		/// You must either use
		/// <see cref="android.app.Activity.startActivityForResult(android.content.Intent, int)
		/// 	">android.app.Activity.startActivityForResult(android.content.Intent, int)</see>
		/// , or provide a
		/// PendingIntent, to receive recognition results.
		/// <p>Required extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_LANGUAGE_MODEL">EXTRA_LANGUAGE_MODEL</see>
		/// </ul>
		/// <p>Optional extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_PROMPT">EXTRA_PROMPT</see>
		/// <li>
		/// <see cref="EXTRA_LANGUAGE">EXTRA_LANGUAGE</see>
		/// <li>
		/// <see cref="EXTRA_MAX_RESULTS">EXTRA_MAX_RESULTS</see>
		/// <li>
		/// <see cref="EXTRA_RESULTS_PENDINGINTENT">EXTRA_RESULTS_PENDINGINTENT</see>
		/// <li>
		/// <see cref="EXTRA_RESULTS_PENDINGINTENT_BUNDLE">EXTRA_RESULTS_PENDINGINTENT_BUNDLE
		/// 	</see>
		/// </ul>
		/// <p> Result extras (returned in the result, not to be specified in the request):
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_RESULTS">EXTRA_RESULTS</see>
		/// </ul>
		/// <p>NOTE: There may not be any applications installed to handle this action, so you should
		/// make sure to catch
		/// <see cref="android.content.ActivityNotFoundException">android.content.ActivityNotFoundException
		/// 	</see>
		/// .
		/// </remarks>
		public const string ACTION_RECOGNIZE_SPEECH = "android.speech.action.RECOGNIZE_SPEECH";

		/// <summary>
		/// Starts an activity that will prompt the user for speech, send it through a
		/// speech recognizer, and either display a web search result or trigger
		/// another type of action based on the user's speech.
		/// </summary>
		/// <remarks>
		/// Starts an activity that will prompt the user for speech, send it through a
		/// speech recognizer, and either display a web search result or trigger
		/// another type of action based on the user's speech.
		/// <p>If you want to avoid triggering any type of action besides web search, you can use
		/// the
		/// <see cref="EXTRA_WEB_SEARCH_ONLY">EXTRA_WEB_SEARCH_ONLY</see>
		/// extra.
		/// <p>Required extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_LANGUAGE_MODEL">EXTRA_LANGUAGE_MODEL</see>
		/// </ul>
		/// <p>Optional extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_PROMPT">EXTRA_PROMPT</see>
		/// <li>
		/// <see cref="EXTRA_LANGUAGE">EXTRA_LANGUAGE</see>
		/// <li>
		/// <see cref="EXTRA_MAX_RESULTS">EXTRA_MAX_RESULTS</see>
		/// <li>
		/// <see cref="EXTRA_PARTIAL_RESULTS">EXTRA_PARTIAL_RESULTS</see>
		/// <li>
		/// <see cref="EXTRA_WEB_SEARCH_ONLY">EXTRA_WEB_SEARCH_ONLY</see>
		/// <li>
		/// <see cref="EXTRA_ORIGIN">EXTRA_ORIGIN</see>
		/// </ul>
		/// <p> Result extras (returned in the result, not to be specified in the request):
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_RESULTS">EXTRA_RESULTS</see>
		/// <li>
		/// <see cref="EXTRA_CONFIDENCE_SCORES">EXTRA_CONFIDENCE_SCORES</see>
		/// (optional)
		/// </ul>
		/// <p>NOTE: There may not be any applications installed to handle this action, so you should
		/// make sure to catch
		/// <see cref="android.content.ActivityNotFoundException">android.content.ActivityNotFoundException
		/// 	</see>
		/// .
		/// </remarks>
		public const string ACTION_WEB_SEARCH = "android.speech.action.WEB_SEARCH";

		/// <summary>The minimum length of an utterance.</summary>
		/// <remarks>
		/// The minimum length of an utterance. We will not stop recording before this amount of time.
		/// Note that it is extremely rare you'd want to specify this value in an intent. If you don't
		/// have a very good reason to change these, you should leave them as they are. Note also that
		/// certain values may cause undesired or unexpected results - use judiciously! Additionally,
		/// depending on the recognizer implementation, these values may have no effect.
		/// </remarks>
		public const string EXTRA_SPEECH_INPUT_MINIMUM_LENGTH_MILLIS = "android.speech.extras.SPEECH_INPUT_MINIMUM_LENGTH_MILLIS";

		/// <summary>
		/// The amount of time that it should take after we stop hearing speech to consider the input
		/// complete.
		/// </summary>
		/// <remarks>
		/// The amount of time that it should take after we stop hearing speech to consider the input
		/// complete.
		/// Note that it is extremely rare you'd want to specify this value in an intent. If
		/// you don't have a very good reason to change these, you should leave them as they are. Note
		/// also that certain values may cause undesired or unexpected results - use judiciously!
		/// Additionally, depending on the recognizer implementation, these values may have no effect.
		/// </remarks>
		public const string EXTRA_SPEECH_INPUT_COMPLETE_SILENCE_LENGTH_MILLIS = "android.speech.extras.SPEECH_INPUT_COMPLETE_SILENCE_LENGTH_MILLIS";

		/// <summary>
		/// The amount of time that it should take after we stop hearing speech to consider the input
		/// possibly complete.
		/// </summary>
		/// <remarks>
		/// The amount of time that it should take after we stop hearing speech to consider the input
		/// possibly complete. This is used to prevent the endpointer cutting off during very short
		/// mid-speech pauses.
		/// Note that it is extremely rare you'd want to specify this value in an intent. If
		/// you don't have a very good reason to change these, you should leave them as they are. Note
		/// also that certain values may cause undesired or unexpected results - use judiciously!
		/// Additionally, depending on the recognizer implementation, these values may have no effect.
		/// </remarks>
		public const string EXTRA_SPEECH_INPUT_POSSIBLY_COMPLETE_SILENCE_LENGTH_MILLIS = 
			"android.speech.extras.SPEECH_INPUT_POSSIBLY_COMPLETE_SILENCE_LENGTH_MILLIS";

		/// <summary>
		/// Informs the recognizer which speech model to prefer when performing
		/// <see cref="ACTION_RECOGNIZE_SPEECH">ACTION_RECOGNIZE_SPEECH</see>
		/// . The recognizer uses this
		/// information to fine tune the results. This extra is required. Activities implementing
		/// <see cref="ACTION_RECOGNIZE_SPEECH">ACTION_RECOGNIZE_SPEECH</see>
		/// may interpret the values as they see fit.
		/// </summary>
		/// <seealso cref="LANGUAGE_MODEL_FREE_FORM">LANGUAGE_MODEL_FREE_FORM</seealso>
		/// <seealso cref="LANGUAGE_MODEL_WEB_SEARCH">LANGUAGE_MODEL_WEB_SEARCH</seealso>
		public const string EXTRA_LANGUAGE_MODEL = "android.speech.extra.LANGUAGE_MODEL";

		/// <summary>Use a language model based on free-form speech recognition.</summary>
		/// <remarks>
		/// Use a language model based on free-form speech recognition.  This is a value to use for
		/// <see cref="EXTRA_LANGUAGE_MODEL">EXTRA_LANGUAGE_MODEL</see>
		/// .
		/// </remarks>
		/// <seealso cref="EXTRA_LANGUAGE_MODEL">EXTRA_LANGUAGE_MODEL</seealso>
		public const string LANGUAGE_MODEL_FREE_FORM = "free_form";

		/// <summary>Use a language model based on web search terms.</summary>
		/// <remarks>
		/// Use a language model based on web search terms.  This is a value to use for
		/// <see cref="EXTRA_LANGUAGE_MODEL">EXTRA_LANGUAGE_MODEL</see>
		/// .
		/// </remarks>
		/// <seealso cref="EXTRA_LANGUAGE_MODEL">EXTRA_LANGUAGE_MODEL</seealso>
		public const string LANGUAGE_MODEL_WEB_SEARCH = "web_search";

		/// <summary>Optional text prompt to show to the user when asking them to speak.</summary>
		/// <remarks>Optional text prompt to show to the user when asking them to speak.</remarks>
		public const string EXTRA_PROMPT = "android.speech.extra.PROMPT";

		/// <summary>Optional IETF language tag (as defined by BCP 47), for example "en-US".</summary>
		/// <remarks>
		/// Optional IETF language tag (as defined by BCP 47), for example "en-US". This tag informs the
		/// recognizer to perform speech recognition in a language different than the one set in the
		/// <see cref="System.Globalization.CultureInfo.CurrentCulture()">System.Globalization.CultureInfo.CurrentCulture()
		/// 	</see>
		/// .
		/// </remarks>
		public const string EXTRA_LANGUAGE = "android.speech.extra.LANGUAGE";

		/// <summary>
		/// Optional value which can be used to indicate the referer url of a page in which
		/// speech was requested.
		/// </summary>
		/// <remarks>
		/// Optional value which can be used to indicate the referer url of a page in which
		/// speech was requested. For example, a web browser may choose to provide this for
		/// uses of speech on a given page.
		/// </remarks>
		public const string EXTRA_ORIGIN = "android.speech.extra.ORIGIN";

		/// <summary>Optional limit on the maximum number of results to return.</summary>
		/// <remarks>
		/// Optional limit on the maximum number of results to return. If omitted the recognizer
		/// will choose how many results to return. Must be an integer.
		/// </remarks>
		public const string EXTRA_MAX_RESULTS = "android.speech.extra.MAX_RESULTS";

		/// <summary>
		/// Optional boolean, to be used with
		/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
		/// , to indicate whether to
		/// only fire web searches in response to a user's speech. The default is false, meaning
		/// that other types of actions can be taken based on the user's speech.
		/// </summary>
		public const string EXTRA_WEB_SEARCH_ONLY = "android.speech.extra.WEB_SEARCH_ONLY";

		/// <summary>
		/// Optional boolean to indicate whether partial results should be returned by the recognizer
		/// as the user speaks (default is false).
		/// </summary>
		/// <remarks>
		/// Optional boolean to indicate whether partial results should be returned by the recognizer
		/// as the user speaks (default is false).  The server may ignore a request for partial
		/// results in some or all cases.
		/// </remarks>
		public const string EXTRA_PARTIAL_RESULTS = "android.speech.extra.PARTIAL_RESULTS";

		/// <summary>
		/// When the intent is
		/// <see cref="ACTION_RECOGNIZE_SPEECH">ACTION_RECOGNIZE_SPEECH</see>
		/// , the speech input activity will
		/// return results to you via the activity results mechanism.  Alternatively, if you use this
		/// extra to supply a PendingIntent, the results will be added to its bundle and the
		/// PendingIntent will be sent to its target.
		/// </summary>
		public const string EXTRA_RESULTS_PENDINGINTENT = "android.speech.extra.RESULTS_PENDINGINTENT";

		/// <summary>
		/// If you use
		/// <see cref="EXTRA_RESULTS_PENDINGINTENT">EXTRA_RESULTS_PENDINGINTENT</see>
		/// to supply a forwarding intent, you can
		/// also use this extra to supply additional extras for the final intent.  The search results
		/// will be added to this bundle, and the combined bundle will be sent to the target.
		/// </summary>
		public const string EXTRA_RESULTS_PENDINGINTENT_BUNDLE = "android.speech.extra.RESULTS_PENDINGINTENT_BUNDLE";

		/// <summary>Result code returned when no matches are found for the given speech</summary>
		public const int RESULT_NO_MATCH = android.app.Activity.RESULT_FIRST_USER;

		/// <summary>Result code returned when there is a generic client error</summary>
		public const int RESULT_CLIENT_ERROR = android.app.Activity.RESULT_FIRST_USER + 1;

		/// <summary>Result code returned when the recognition server returns an error</summary>
		public const int RESULT_SERVER_ERROR = android.app.Activity.RESULT_FIRST_USER + 2;

		/// <summary>Result code returned when a network error was encountered</summary>
		public const int RESULT_NETWORK_ERROR = android.app.Activity.RESULT_FIRST_USER + 
			3;

		/// <summary>Result code returned when an audio error was encountered</summary>
		public const int RESULT_AUDIO_ERROR = android.app.Activity.RESULT_FIRST_USER + 4;

		/// <summary>
		/// An ArrayList&lt;String&gt; of the recognition results when performing
		/// <see cref="ACTION_RECOGNIZE_SPEECH">ACTION_RECOGNIZE_SPEECH</see>
		/// . Generally this list should be ordered in
		/// descending order of speech recognizer confidence. (See
		/// <see cref="EXTRA_CONFIDENCE_SCORES">EXTRA_CONFIDENCE_SCORES</see>
		/// ).
		/// Returned in the results; not to be specified in the recognition request. Only present
		/// when
		/// <see cref="android.app.Activity.RESULT_OK">android.app.Activity.RESULT_OK</see>
		/// is returned in an activity result. In a PendingIntent,
		/// the lack of this extra indicates failure.
		/// </summary>
		public const string EXTRA_RESULTS = "android.speech.extra.RESULTS";

		/// <summary>
		/// A float array of confidence scores of the recognition results when performing
		/// <see cref="ACTION_RECOGNIZE_SPEECH">ACTION_RECOGNIZE_SPEECH</see>
		/// . The array should be the same size as the ArrayList
		/// returned in
		/// <see cref="EXTRA_RESULTS">EXTRA_RESULTS</see>
		/// , and should contain values ranging from 0.0 to 1.0,
		/// or -1 to represent an unavailable confidence score.
		/// <p>
		/// Confidence values close to 1.0 indicate high confidence (the speech recognizer is
		/// confident that the recognition result is correct), while values close to 0.0 indicate
		/// low confidence.
		/// <p>
		/// Returned in the results; not to be specified in the recognition request. This extra is
		/// optional and might not be provided. Only present when
		/// <see cref="android.app.Activity.RESULT_OK">android.app.Activity.RESULT_OK</see>
		/// is
		/// returned in an activity result.
		/// </summary>
		public const string EXTRA_CONFIDENCE_SCORES = "android.speech.extra.CONFIDENCE_SCORES";

		// Not for instantiating.
		/// <summary>
		/// Returns the broadcast intent to fire with
		/// <see cref="android.content.Context.sendOrderedBroadcast(android.content.Intent, string, android.content.BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">android.content.Context.sendOrderedBroadcast(android.content.Intent, string, android.content.BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</see>
		/// to receive details from the package that implements voice search.
		/// <p>
		/// This is based on the value specified by the voice search
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// in
		/// <see cref="DETAILS_META_DATA">DETAILS_META_DATA</see>
		/// , and if this is not specified, will return null. Also if there
		/// is no chosen default to resolve for
		/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
		/// , this will return null.
		/// <p>
		/// If an intent is returned and is fired, a
		/// <see cref="android.os.Bundle">android.os.Bundle</see>
		/// of extras will be returned to the
		/// provided result receiver, and should ideally contain values for
		/// <see cref="EXTRA_LANGUAGE_PREFERENCE">EXTRA_LANGUAGE_PREFERENCE</see>
		/// and
		/// <see cref="EXTRA_SUPPORTED_LANGUAGES">EXTRA_SUPPORTED_LANGUAGES</see>
		/// .
		/// <p>
		/// (Whether these are actually provided is up to the particular implementation. It is
		/// recommended that
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// s implementing
		/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
		/// provide this
		/// information, but it is not required.)
		/// </summary>
		/// <param name="context">a context object</param>
		/// <returns>the broadcast intent to fire or null if not available</returns>
		public static android.content.Intent getVoiceDetailsIntent(android.content.Context
			 context)
		{
			android.content.Intent voiceSearchIntent = new android.content.Intent(ACTION_WEB_SEARCH
				);
			android.content.pm.ResolveInfo ri = context.getPackageManager().resolveActivity(voiceSearchIntent
				, android.content.pm.PackageManager.GET_META_DATA);
			if (ri == null || ri.activityInfo == null || ri.activityInfo.metaData == null)
			{
				return null;
			}
			string className = ri.activityInfo.metaData.getString(DETAILS_META_DATA);
			if (className == null)
			{
				return null;
			}
			android.content.Intent detailsIntent = new android.content.Intent(ACTION_GET_LANGUAGE_DETAILS
				);
			detailsIntent.setComponent(new android.content.ComponentName(ri.activityInfo.packageName
				, className));
			return detailsIntent;
		}

		/// <summary>
		/// Meta-data name under which an
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// implementing
		/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
		/// can
		/// use to expose the class name of a
		/// <see cref="android.content.BroadcastReceiver">android.content.BroadcastReceiver</see>
		/// which can respond to request for
		/// more information, from any of the broadcast intents specified in this class.
		/// <p>
		/// Broadcast intents can be directed to the class name specified in the meta-data by creating
		/// an
		/// <see cref="android.content.Intent">android.content.Intent</see>
		/// , setting the component with
		/// <see cref="android.content.Intent.setComponent(android.content.ComponentName)">android.content.Intent.setComponent(android.content.ComponentName)
		/// 	</see>
		/// , and using
		/// <see cref="android.content.Context.sendOrderedBroadcast(android.content.Intent, string, android.content.BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">android.content.Context.sendOrderedBroadcast(android.content.Intent, string, android.content.BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</see>
		/// with another
		/// <see cref="android.content.BroadcastReceiver">android.content.BroadcastReceiver</see>
		/// which can receive the results.
		/// <p>
		/// The
		/// <see cref="getVoiceDetailsIntent(android.content.Context)">getVoiceDetailsIntent(android.content.Context)
		/// 	</see>
		/// method is provided as a convenience to create
		/// a broadcast intent based on the value of this meta-data, if available.
		/// <p>
		/// This is optional and not all
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// s which implement
		/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
		/// are required to implement this. Thus retrieving this meta-data may be null.
		/// </summary>
		public const string DETAILS_META_DATA = "android.speech.DETAILS";

		/// <summary>
		/// A broadcast intent which can be fired to the
		/// <see cref="android.content.BroadcastReceiver">android.content.BroadcastReceiver</see>
		/// component specified
		/// in the meta-data defined in the
		/// <see cref="DETAILS_META_DATA">DETAILS_META_DATA</see>
		/// meta-data of an
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// satisfying
		/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
		/// .
		/// <p>
		/// When fired with
		/// <see cref="android.content.Context.sendOrderedBroadcast(android.content.Intent, string, android.content.BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	">android.content.Context.sendOrderedBroadcast(android.content.Intent, string, android.content.BroadcastReceiver, android.os.Handler, int, string, android.os.Bundle)
		/// 	</see>
		/// ,
		/// a
		/// <see cref="android.os.Bundle">android.os.Bundle</see>
		/// of extras will be returned to the provided result receiver, and should
		/// ideally contain values for
		/// <see cref="EXTRA_LANGUAGE_PREFERENCE">EXTRA_LANGUAGE_PREFERENCE</see>
		/// and
		/// <see cref="EXTRA_SUPPORTED_LANGUAGES">EXTRA_SUPPORTED_LANGUAGES</see>
		/// .
		/// <p>
		/// (Whether these are actually provided is up to the particular implementation. It is
		/// recommended that
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// s implementing
		/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
		/// provide this
		/// information, but it is not required.)
		/// </summary>
		public const string ACTION_GET_LANGUAGE_DETAILS = "android.speech.action.GET_LANGUAGE_DETAILS";

		/// <summary>
		/// Specify this boolean extra in a broadcast of
		/// <see cref="ACTION_GET_LANGUAGE_DETAILS">ACTION_GET_LANGUAGE_DETAILS</see>
		/// to
		/// indicate that only the current language preference is needed in the response. This
		/// avoids any additional computation if all you need is
		/// <see cref="EXTRA_LANGUAGE_PREFERENCE">EXTRA_LANGUAGE_PREFERENCE</see>
		/// in the response.
		/// </summary>
		public const string EXTRA_ONLY_RETURN_LANGUAGE_PREFERENCE = "android.speech.extra.ONLY_RETURN_LANGUAGE_PREFERENCE";

		/// <summary>
		/// The key to the extra in the
		/// <see cref="android.os.Bundle">android.os.Bundle</see>
		/// returned by
		/// <see cref="ACTION_GET_LANGUAGE_DETAILS">ACTION_GET_LANGUAGE_DETAILS</see>
		/// which is a
		/// <see cref="string">string</see>
		/// that represents the current language preference this user has
		/// specified - a locale string like "en-US".
		/// </summary>
		public const string EXTRA_LANGUAGE_PREFERENCE = "android.speech.extra.LANGUAGE_PREFERENCE";

		/// <summary>
		/// The key to the extra in the
		/// <see cref="android.os.Bundle">android.os.Bundle</see>
		/// returned by
		/// <see cref="ACTION_GET_LANGUAGE_DETAILS">ACTION_GET_LANGUAGE_DETAILS</see>
		/// which is an
		/// <see cref="java.util.ArrayList{E}">java.util.ArrayList&lt;E&gt;</see>
		/// of
		/// <see cref="string">string</see>
		/// s that represents the languages supported by
		/// this implementation of voice recognition - a list of strings like "en-US", "cmn-Hans-CN",
		/// etc.
		/// </summary>
		public const string EXTRA_SUPPORTED_LANGUAGES = "android.speech.extra.SUPPORTED_LANGUAGES";
	}
}
