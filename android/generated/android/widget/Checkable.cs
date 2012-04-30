using Sharpen;

namespace android.widget
{
	/// <summary>Defines an extension for views that make them checkable.</summary>
	/// <remarks>Defines an extension for views that make them checkable.</remarks>
	[Sharpen.Sharpened]
	public interface Checkable
	{
		/// <summary>Change the checked state of the view</summary>
		/// <param name="checked">The new checked state</param>
		void setChecked(bool @checked);

		/// <returns>The current checked state of the view</returns>
		bool isChecked();

		/// <summary>Change the checked state of the view to the inverse of its current state
		/// 	</summary>
		void toggle();
	}
}
