using Sharpen;

namespace android.view
{
	/// <summary>Interface to let you add and remove child views to an Activity.</summary>
	/// <remarks>
	/// Interface to let you add and remove child views to an Activity. To get an instance
	/// of this class, call
	/// <see cref="android.content.Context.getSystemService(string)">Context.getSystemService()
	/// 	</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public interface ViewManager
	{
		void addView(android.view.View view, android.view.ViewGroup.LayoutParams @params);

		void updateViewLayout(android.view.View view, android.view.ViewGroup.LayoutParams
			 @params);

		void removeView(android.view.View view);
	}
}
