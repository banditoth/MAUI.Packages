using System.Collections.Generic;
using System.Globalization;
using System.Resources;
namespace banditoth.MAUI.Multilanguage.Interfaces
{
	public interface ITranslatorSettings
	{
		List<ResourceManager> ResourceManagers { get; }
		CultureInfo DefaultCulture { get; }
		bool IsStoringLastUsedCulture { get; }
		bool IsThrowingExceptionIfTranslationNotFound { get; }
		bool IsAppendingKeyToTranslationNotFoundText { get; }
		string TranslationNotFoundText { get; }

		void UseResource(ResourceManager manager);

		void UseDefaultCulture(CultureInfo culture);

		void StoreLastUsedCulture(bool store);

		void ThrowExceptionIfTranslationNotFound(bool throwException);

		void SetTranslationNotFoundText(string text, bool appendTranslationKey);
	}
}

