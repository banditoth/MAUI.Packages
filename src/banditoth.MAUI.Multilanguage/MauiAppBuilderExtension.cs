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

            builder.Services.TryAddSingleton(typeof(ITranslatorSettings), svc => settings);
            builder.Services.TryAddSingleton(typeof(ITranslator), typeof(TranslatorService));
            builder.Services.TryAddSingleton(typeof(TranslationBinder));

            return builder;
        }
    }
}

