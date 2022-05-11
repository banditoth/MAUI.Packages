using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using banditoth.MAUI.Multilanguage.Exceptions;
using banditoth.MAUI.Multilanguage.Interfaces;
using Microsoft.Maui.Storage;

namespace banditoth.MAUI.Multilanguage.Implementations
{
    internal class TranslatorService : ITranslator
    {
        private const string LastUsedCulturePreferenceKey = "LASTUSEDLANGUAGE";

        public CultureInfo CurrentCulture
        {
            get;
            private set;
        }

        private readonly List<ResourceManager> resourceManagers = new List<ResourceManager>();
        private readonly ITranslatorSettings settings;

        public TranslatorService(ITranslatorSettings settings)
        {
            this.settings = settings;

            if (settings.IsStoringLastUsedCulture)
            {
                SetCurrentCulture(new CultureInfo(Preferences.Get(LastUsedCulturePreferenceKey, null)) ?? settings.DefaultCulture);
            }
        }


        public string GetTranslation(string key)
        {
            foreach (var manager in resourceManagers)
            {
                var result = manager.GetString(key, CurrentCulture);

                if (string.IsNullOrWhiteSpace(result) == false)
                    return result;
            }

            if (settings.IsThrowingExceptionIfTranslationNotFound)
                throw new TranslationNotFoundException(key);

            return settings.TranslationNotFoundText + (settings.IsAppendingKeyToTranslationNotFoundText ? key : null);
        }

        public void SetCurrentCulture(CultureInfo culture)
        {
            if (culture == null)
                throw new ArgumentNullException(nameof(culture), "Providing culture is mandatory");

            CurrentCulture = culture;

            if (settings.IsStoringLastUsedCulture == false)
                return;

            Preferences.Set(LastUsedCulturePreferenceKey, CurrentCulture.Name);
        }
    }
}

