using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using banditoth.MAUI.Multilanguage.Interfaces;

namespace banditoth.MAUI.Multilanguage.Implementations
{
    internal class TranslatorSettingsService : ITranslatorSettings
    {
        public List<ResourceManager> ResourceManagers { get; private set; } = new List<ResourceManager>();
        public CultureInfo DefaultCulture { get; private set; } = new CultureInfo("en-US");
        public bool IsStoringLastUsedCulture { get; private set; } = true;
        public bool IsThrowingExceptionIfTranslationNotFound { get; private set; } = false;
        public bool IsAppendingKeyToTranslationNotFoundText { get; private set; } = true;
        public string TranslationNotFoundText { get; private set; } = "Translation_Missing:";

        public TranslatorSettingsService()
        {

        }


        public void SetTranslationNotFoundText(string text, bool appendTranslationKey)
        {
            TranslationNotFoundText = text;
            IsAppendingKeyToTranslationNotFoundText = appendTranslationKey;
        }

        public void StoreLastUsedCulture(bool storeLastUsedCulture)
        {
            IsStoringLastUsedCulture = storeLastUsedCulture;
        }

        public void ThrowExceptionIfTranslationNotFound(bool throwException)
        {
            IsThrowingExceptionIfTranslationNotFound = throwException;
        }

        public void UseDefaultCulture(CultureInfo culture)
        {
            DefaultCulture = culture;
        }

        public void UseResource(ResourceManager manager)
        {
            ResourceManagers.Add(manager);
        }
    }
}

