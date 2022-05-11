using System;
namespace banditoth.MAUI.Multilanguage.Exceptions
{
	public class TranslationNotFoundException : Exception
	{
        public string TranslationKey { get; set; }

        public TranslationNotFoundException(string translationKey) : base("Translation not found: " + translationKey)
		{
			TranslationKey = translationKey;
		}
	}
}

