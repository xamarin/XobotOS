using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	internal class DoubleDigitManager
	{
		private readonly long timeoutInMillis;

		private readonly android.widget.DoubleDigitManager.CallBack mCallBack;

		private int intermediateDigit;

		[Sharpen.Stub]
		internal DoubleDigitManager(long timeoutInMillis, android.widget.DoubleDigitManager
			.CallBack callBack)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reportDigit(int digit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal interface CallBack
		{
			[Sharpen.Stub]
			bool singleDigitIntermediate(int digit);

			[Sharpen.Stub]
			void singleDigitFinal(int digit);

			[Sharpen.Stub]
			bool twoDigitsFinal(int digit1, int digit2);
		}
	}
}
