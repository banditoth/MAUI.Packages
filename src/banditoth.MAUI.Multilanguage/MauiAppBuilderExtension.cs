using banditoth.MAUI.Multilanguage.Implementations;
using banditoth.MAUI.Multilanguage.Interfaces;

namespace banditoth.MAUI.Multilanguage
{
    public static class MauiAppBuilderExtension
    {
        public static MauiAppBuilder ConfigureMultilanguage(this MauiAppBuilder builder, Action<ITranslatorSettings> settingsDelegate)
        {
            ITranslatorSettings settings = new TranslatorSettingsService();

            if (settingsDelegate != null)
            {
                settingsDelegate.Invoke(settings);
            }

            // https://github.com/dotnet/maui/issues/8824 - Xaml MarkupExtensios are not receiving all services from service collection
            ITranslator translator = new TranslatorService(settings);
            MAUIServiceProviderWorkaround.Translator = translator;
            TranslationBinder binder = new TranslationBinder(translator);
            MAUIServiceProviderWorkaround.TranslatorBinder = binder;
            // end of workaround

            builder.Services.AddSingleton(typeof(ITranslatorSettings), svc => settings);
            builder.Services.AddSingleton(typeof(ITranslator), svc => translator);
            builder.Services.AddSingleton(typeof(TranslationBinder), svc => binder);


            return builder;
        }
    }
}

