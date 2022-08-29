using System;
using banditoth.MAUI.Multilanguage.Interfaces;

namespace banditoth.MAUI.Multilanguage
{
    public static class MAUIServiceProviderWorkaround
    {
        public static ITranslator Translator { get; internal set; }
        public static TranslationBinder TranslatorBinder { get; internal set; }
    }
}

