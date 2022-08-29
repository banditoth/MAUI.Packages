using System;
using System.Globalization;
using System.Resources;
using banditoth.MAUI.Multilanguage.Implementations;
using banditoth.MAUI.Multilanguage.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

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

            builder.Services.TryAddSingleton(typeof(ITranslatorSettings), svc => settings);
            builder.Services.TryAddSingleton(typeof(ITranslator), svc => translator);
            builder.Services.TryAddSingleton(typeof(TranslationBinder), svc => binder);


            return builder;
        }
    }
}

