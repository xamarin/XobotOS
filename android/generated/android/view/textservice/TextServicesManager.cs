using Sharpen;

namespace android.view.textservice
{
	[Sharpen.Stub]
	public sealed class TextServicesManager
	{
		private static readonly string TAG = typeof(android.view.textservice.TextServicesManager
			).Name;

		internal const bool DBG = false;

		private static android.view.textservice.TextServicesManager sInstance;

		private static android.view.textservice.@internal.ITextServicesManager sService;

		[Sharpen.Stub]
		private TextServicesManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.textservice.TextServicesManager getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.textservice.SpellCheckerSession newSpellCheckerSession(android.os.Bundle
			 bundle, System.Globalization.CultureInfo locale, android.view.textservice.SpellCheckerSession
			.SpellCheckerSessionListener listener, bool referToSpellCheckerLanguageSettings)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.textservice.SpellCheckerInfo[] getEnabledSpellCheckers()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.textservice.SpellCheckerInfo getCurrentSpellChecker()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setCurrentSpellChecker(android.view.textservice.SpellCheckerInfo sci)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.textservice.SpellCheckerSubtype getCurrentSpellCheckerSubtype
			(bool allowImplicitlySelectedSubtype)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setSpellCheckerSubtype(android.view.textservice.SpellCheckerSubtype subtype
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setSpellCheckerEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isSpellCheckerEnabled()
		{
			throw new System.NotImplementedException();
		}
	}
}
