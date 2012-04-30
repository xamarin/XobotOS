using Sharpen;

namespace android.text
{
	/// <summary>
	/// Please implement this interface if your CharSequence has a
	/// getChars() method like the one in String that is faster than
	/// calling charAt() multiple times.
	/// </summary>
	/// <remarks>
	/// Please implement this interface if your CharSequence has a
	/// getChars() method like the one in String that is faster than
	/// calling charAt() multiple times.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface GetChars : java.lang.CharSequence
	{
		/// <summary>
		/// Exactly like String.getChars(): copy chars <code>start</code>
		/// through <code>end - 1</code> from this CharSequence into <code>dest</code>
		/// beginning at offset <code>destoff</code>.
		/// </summary>
		/// <remarks>
		/// Exactly like String.getChars(): copy chars <code>start</code>
		/// through <code>end - 1</code> from this CharSequence into <code>dest</code>
		/// beginning at offset <code>destoff</code>.
		/// </remarks>
		void getChars(int start, int end, char[] dest, int destoff);
	}
}
