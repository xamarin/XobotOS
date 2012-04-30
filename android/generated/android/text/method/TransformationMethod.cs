using Sharpen;

namespace android.text.method
{
	/// <summary>
	/// TextView uses TransformationMethods to do things like replacing the
	/// characters of passwords with dots, or keeping the newline characters
	/// from causing line breaks in single-line text fields.
	/// </summary>
	/// <remarks>
	/// TextView uses TransformationMethods to do things like replacing the
	/// characters of passwords with dots, or keeping the newline characters
	/// from causing line breaks in single-line text fields.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface TransformationMethod
	{
		/// <summary>
		/// Returns a CharSequence that is a transformation of the source text --
		/// for example, replacing each character with a dot in a password field.
		/// </summary>
		/// <remarks>
		/// Returns a CharSequence that is a transformation of the source text --
		/// for example, replacing each character with a dot in a password field.
		/// Beware that the returned text must be exactly the same length as
		/// the source text, and that if the source text is Editable, the returned
		/// text must mirror it dynamically instead of doing a one-time copy.
		/// </remarks>
		java.lang.CharSequence getTransformation(java.lang.CharSequence source, android.view.View
			 view);

		/// <summary>
		/// This method is called when the TextView that uses this
		/// TransformationMethod gains or loses focus.
		/// </summary>
		/// <remarks>
		/// This method is called when the TextView that uses this
		/// TransformationMethod gains or loses focus.
		/// </remarks>
		void onFocusChanged(android.view.View view, java.lang.CharSequence sourceText, bool
			 focused, int direction, android.graphics.Rect previouslyFocusedRect);
	}
}
