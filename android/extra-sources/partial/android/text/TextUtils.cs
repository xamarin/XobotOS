using Sharpen;
using java.lang;

namespace android.text
{
	partial class TextUtils
	{
		/// <summary>Returns a string containing the tokens joined by delimiters.</summary>
		/// <remarks>Returns a string containing the tokens joined by delimiters.</remarks>
		/// <param name="tokens">
		/// an array objects to be joined. Strings will be formed from
		/// the objects by calling object.toString().
		/// </param>
		public static string join (CharSequence delimiter, Iterable<CharSequence> tokens)
		{
			StringBuilder sb = new StringBuilder ();
			bool firstTime = true;
			foreach (object token in Sharpen.IterableProxy.Create(tokens)) {
				if (firstTime) {
					firstTime = false;
				} else {
					sb.append (delimiter);
				}
				sb.append (token);
			}
			return sb.ToString ();
		}

	}
}

